﻿/*
   Copyright 2011 Michael Edwards
 
   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
 
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Data.Items;

namespace Glass.Sitecore.Mapper
{
    public class SitecoreContext : SitecoreService, ISitecoreContext
    {
        public SitecoreContext() :base(global::Sitecore.Context.Database)
        {

        }
        #region ISitecoreContext Members

      


        public T GetHomeItem<T>() where T : class
        {

            return base.GetItem<T>(global::Sitecore.Context.Site.StartPath);
        }

        public IEnumerable<T> QueryRelative<T>(string query, bool isLazy, bool inferType) where T : class
        {
            Item item = global::Sitecore.Context.Item;
            var results = item.Axes.SelectItems(query);
            return base.CreateClasses(isLazy, inferType, typeof(T), () => { return results; }) as IEnumerable<T>;

        }

        public T QuerySingleRelative<T>(string query, bool isLazy, bool inferType) where T : class
        {
            Item item = global::Sitecore.Context.Item;
            var result = item.Axes.SelectSingleItem(query);
            return base.CreateClass<T>(isLazy, inferType, result);
        }


        public object GetCurrentItem(Type type)
        {
            return base.CreateClass(false, false, type, global::Sitecore.Context.Item);
        }

        public T GetCurrentItem<T>() where T : class
        {
            return base.CreateClass<T>(false, false, global::Sitecore.Context.Item);
        }

        public T GetCurrentItem<T, K>(K param1) where T : class
        {

            return base.CreateClass<T,K>(false, false, global::Sitecore.Context.Item, param1);

        }

        public T GetCurrentItem<T, K, L>(K param1, L param2) where T : class
        {
            return base.CreateClass<T, K, L>(false, false, global::Sitecore.Context.Item, param1, param2);

        }

        public T GetCurrentItem<T, K, L, M>(K param1, L param2, M param3) where T : class
        {
            return base.CreateClass<T, K, L, M>(false, false, global::Sitecore.Context.Item, param1, param2, param3);

        }

        public T GetCurrentItem<T, K, L, M, N>(K param1, L param2, M param3, N param4) where T : class
        {
            return base.CreateClass<T, K, L, M, N>(false, false, global::Sitecore.Context.Item, param1, param2, param3, param4);

        }

        #endregion

    }
}
