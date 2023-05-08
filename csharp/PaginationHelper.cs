// For this exercise you will be strengthening your page-fu mastery. You will complete the PaginationHelper class, which is a utility class helpful for querying paging information related to an array.

// The class is designed to take in an array of values and an integer indicating how many items will be allowed per each page. The types of values contained within the collection/array are not relevant.

using System;
using System.Collections.Generic;

public class PagnationHelper<T>
{
    private IList<T> _list;
    private int _index;
 
    public PagnationHelper(IList<T> collection, int itemsPerPage)
    {
        _list = collection;
        _index = itemsPerPage;
    }

    public int ItemCount
    {
        get
        {
            return _list.Count;
        }
    }

    public int PageCount
    {
        get
        {
            return _list.Count / _index + 1;
        }
    }

    public int PageItemCount(int pageIndex)
    {
        if (pageIndex < 0 || pageIndex > _list.Count / _index)
        {
            return -1;
        }
        else if (pageIndex == _list.Count / _index)
        {
            return _list.Count % _index;
        }

        return _index;
    }

    public int PageIndex(int itemIndex)
    {
        if (itemIndex < 0 || itemIndex >= _list.Count)
        {
            return -1;
        }
        return itemIndex / _index;
    }
}