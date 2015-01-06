﻿using NUnit.Framework;
using Storyteller.Core.Engine;

namespace Storyteller.Core.Testing
{
    public static class SpecificationExtensions
    {
        public static void ShouldEqual(this Counts counts, int rights, int wrongs, int exceptions, int syntaxErrors)
        {
            var expected = new Counts
            {
                Rights = rights,
                Wrongs = wrongs,
                Exceptions = exceptions,
                SyntaxErrors = syntaxErrors
            };

            Assert.AreEqual(expected, counts);
        }
    }
}