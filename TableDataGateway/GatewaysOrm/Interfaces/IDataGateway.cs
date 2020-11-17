﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TableDataGateway.Gateways
{
    interface IDataGateway<T> where T : class
    {
        IEnumerable<T> SelectAll();
        T SelectById(int? id);
        void Insert(T obj);
        void Update(T obj);
        T Delete(int? id);
        void Save();
    }
}
