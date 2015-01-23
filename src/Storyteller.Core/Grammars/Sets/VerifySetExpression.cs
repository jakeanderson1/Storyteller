using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Storyteller.Core.Grammars.Sets
{
    public class VerifySetExpression<T>
    {
        private readonly Func<ISpecContext, IEnumerable<T>> _dataSource;
        private string _description = string.Empty;
        private bool _ordered;
        private string _leafName = "rows";
        private string _title = "Verify Set of " + typeof(T).Name;

        public VerifySetExpression(Func<ISpecContext, IEnumerable<T>> dataSource)
        {
            _dataSource = dataSource;
        }

        public VerifySetExpression<T> Description(string description)
        {
            _description = description;
            return this;
        }

        public VerifySetExpression<T> Titled(string title)
        {
            _title = title;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stepName"></param>
        /// <returns></returns>
        public VerifySetExpression<T> LeafNameIs(string stepName)
        {
            _leafName = stepName;
            return this;
        }

        public SetVerificationGrammar MatchOn(params Expression<Func<T, object>>[] properties)
        {
            var comparer = new ObjectComparison<T>(_dataSource);
            foreach (var property in properties)
            {
                comparer.MatchOn(property);
            }

            var grammar = new SetVerificationGrammar(_leafName, _title, comparer);
            if (_ordered)
            {
                grammar.Ordered();
            }

            return grammar;
        }


        public VerifySetExpression<T> Ordered()
        {
            _ordered = true;
            return this;
        }
    }
}