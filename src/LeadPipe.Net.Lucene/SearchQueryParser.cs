﻿// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using Lucene.Net.QueryParsers;
using Lucene.Net.Search;

namespace LeadPipe.Net.Lucene
{
    /// <summary>
    /// Parses search queries.
    /// </summary>
    public class SearchQueryParser : ISearchQueryParser
    {
        /// <summary>
        /// Parses the query.
        /// </summary>
        /// <param name="searchQuery">The search query.</param>
        /// <param name="parser">The parser.</param>
        /// <returns></returns>
        public virtual Query ParseQuery(string searchQuery, QueryParser parser)
        {
            /*
             * NOTE: Override this to something like FuzzyQuery if desired.
             */

            Query query;

            try
            {
                query = parser.Parse(searchQuery.Trim());
            }
            catch (ParseException)
            {
                query = parser.Parse(QueryParser.Escape(searchQuery.Trim()));
            }

            return query;
        }
    }
}