---
title: 在 .NET 中管理簡報註解
linktitle: 簡報註解
type: docs
weight: 100
url: /zh-hant/net/presentation-comments/
keywords:
- 註解
- 現代註解
- PowerPoint 註解
- 簡報註解
- 投影片註解
- 新增註解
- 存取註解
- 編輯註解
- 回覆註解
- 移除註解
- 刪除註解
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 精通簡報註解：快速且輕鬆地在 PowerPoint 檔案中新增、讀取、編輯與刪除註解。"
---
## **概述**

本文說明如何在 Aspose.Slides 中管理簡報註解。它展示了主要的與註解相關的類型，並示範如何向投影片新增註解、存取現有註解、處理回覆、使用現代註解以及從簡報中移除註解。

這些範例著重於 PowerPoint 中常見的審閱與協作情境，例如將註解指派給作者、讀取註解內容與中繼資料、建立回覆鏈，以及清除全部註解或刪除所選註解。

在 PowerPoint 中，註解會以投影片上的備註或標註形式顯示。點選註解時，即會顯示其內容或訊息。

## **為何在簡報中加入註解？**

在審閱簡報時，您可能希望使用註解提供回饋或與同事溝通。

為了讓您在 PowerPoint 簡報中使用註解，Aspose.Slides for .NET 提供了

* The [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別，包含作者集合（來自 [CommentAuthorCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icommentauthorcollection/properties/index) 屬性）。作者會在投影片上加入註解。 
* The  [ICommentCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icommentcollection) 介面，包含個別作者的註解集合。 
* The  [IComment](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icomment) 類別，包含作者及其註解的資訊：誰新增了註解、註解新增的時間、註解的位置等。 
* The [CommentAuthor](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/commentauthor) 類別，包含個別作者的資訊：作者名稱、其縮寫、與該作者名稱相關的註解等。 

## **新增投影片註解**
以下 C# 程式碼示範如何在 PowerPoint 簡報的投影片中新增註解：

```c#
// 實例化 Presentation 類別
using (Presentation presentation = new Presentation())
{
    // 新增空白投影片
    presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

    // 新增作者
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Jawad", "MF");

    // 設定註解的位置
    PointF point = new PointF();
    point.X = 0.2f;
    point.Y = 0.2f;

    // 在第 1 張投影片為作者新增註解
    author.Comments.AddComment("Hello Jawad, this is slide comment", presentation.Slides[0], point, DateTime.Now);

    // 在第 2 張投影片為作者新增註解
    author.Comments.AddComment("Hello Jawad, this is second slide comment", presentation.Slides[1], point, DateTime.Now);

    // 存取 ISlide 1
    ISlide slide = presentation.Slides[0];

    // 當傳入 null 作為參數時，會將所有作者的註解帶到選取的投影片
    IComment[] Comments = slide.GetSlideComments(author);

    // 存取第 1 張投影片索引 0 的註解
    String str = Comments[0].Text;

    presentation.Save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.GetLength(0) > 0)
    {
        // 選取索引 0 處的作者註解集合
        ICommentCollection commentCollection = Comments[0].Author.Comments;
        String Comment = commentCollection[0].Text;
    }
}
```

## **存取投影片註解**
以下 C# 程式碼示範如何在 PowerPoint 簡報的投影片上存取現有註解：

```c#
// 實例化 Presentation 類別
using (Presentation presentation = new Presentation("Comments1.pptx"))
{
    foreach (var commentAuthor in presentation.CommentAuthors)
    {
        var author = (CommentAuthor) commentAuthor;
        foreach (var comment1 in author.Comments)
        {
            var comment = (Comment) comment1;
            Console.WriteLine("ISlide :" + comment.Slide.SlideNumber + " has comment: " + comment.Text + " with Author: " + comment.Author.Name + " posted on time :" + comment.CreatedTime + "\n");
        }
    }
}
```

## **回覆註解**
父註解是註解或回覆層級中的最上層或原始註解。使用 [ParentComment](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icomment/properties/parentcomment) 屬性（來自 [IComment](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icomment) 介面），您可以設定或取得父註解。

以下 C# 程式碼示範如何新增註解並取得其回覆：

```c#
using (Presentation pres = new Presentation())
{
    // 新增註解
    ICommentAuthor author1 = pres.CommentAuthors.AddAuthor("Author_1", "A.A.");
    IComment comment1 = author1.Comments.AddComment("comment1", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    // 為 comment1 新增回覆
    ICommentAuthor author2 = pres.CommentAuthors.AddAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.Comments.AddComment("reply 1 for comment 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply1.ParentComment = comment1;

    // 為 comment1 新增另一筆回覆
    IComment reply2 = author2.Comments.AddComment("reply 2 for comment 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply2.ParentComment = comment1;

    // 為現有回覆新增回覆
    IComment subReply = author1.Comments.AddComment("subreply 3 for reply 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    subReply.ParentComment = reply2;

    IComment comment2 = author2.Comments.AddComment("comment 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    IComment comment3 = author2.Comments.AddComment("comment 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    IComment reply3 = author1.Comments.AddComment("reply 4 for comment 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply3.ParentComment = comment3;

    // 在主控台顯示註解層級結構
    ISlide slide = pres.Slides[0];
    var comments = slide.GetSlideComments(null);
    for (int i = 0; i < comments.Length; i++)
    {
        IComment comment = comments[i];
        while (comment.ParentComment != null)
        {
            Console.Write("\t");
            comment = comment.ParentComment;
        }

        Console.Write("{0} : {1}", comments[i].Author.Name, comments[i].Text);
        Console.WriteLine();
    }

    pres.Save("parent_comment.pptx",SaveFormat.Pptx);

    // 移除 comment1 以及所有回覆
    comment1.Remove();

    pres.Save("remove_comment.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" title="注意" %}} 

* 使用來自 [IComment](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icomment) 介面的 [Remove](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icomment/methods/remove) 方法刪除註解時，該註解的回覆也會被刪除。 
* 若 [ParentComment](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icomment/properties/parentcomment) 設定導致循環參考，將拋出 [PptxEditException](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/pptxeditexception)。

{{% /alert %}}

## **新增現代註解**

2021 年，Microsoft 在 PowerPoint 中引入了*現代註解*。現代註解功能顯著提升了 PowerPoint 的協作體驗。透過現代註解，PowerPoint 使用者可以解決註解、將註解錨定於物件與文字，並更輕鬆地進行互動。

在 [Aspose Slides for .NET 21.11](https://docs.aspose.com/slides/zh-hant/net/aspose-slides-for-net-21-11-release-notes/) 中，我們透過加入 [ModernComment](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/moderncomment) 類別實作了對現代註解的支援。[AddModernComment](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/commentcollection/methods/addmoderncomment) 與 [InsertModernComment](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/commentcollection/methods/insertmoderncomment) 方法亦被加入至 [CommentCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/commentcollection) 類別。

以下 C# 程式碼示範如何在 PowerPoint 簡報的投影片中新增現代註解：

```c#
using (Presentation pres = new Presentation())
{
     ICommentAuthor newAuthor = pres.CommentAuthors.AddAuthor("Some Author", "SA");
     IModernComment modernComment = newAuthor.Comments.AddModernComment("This is a modern comment", pres.Slides[0], null, new PointF(100, 100), DateTime.Now);
 
     pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **移除註解**

### **刪除全部註解與作者**

以下 C# 程式碼示範如何在簡報中移除全部註解與作者：

```c#
using (var presentation = new Presentation("example.pptx"))
{
    // 刪除簡報中的所有註解
    foreach (var author in presentation.CommentAuthors)
    {
        author.Comments.Clear();
    }

    // 刪除所有作者
    presentation.CommentAuthors.Clear();

    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```

### **刪除特定註解**

以下 C# 程式碼示範如何刪除投影片上特定的註解：

```c#
using (var presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    
    // 新增註解...
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Author", "A");
    author.Comments.AddComment("comment 1", slide, new PointF(0.2f, 0.2f), DateTime.Now);
    author.Comments.AddComment("comment 2", slide, new PointF(0.3f, 0.2f), DateTime.Now);
    
    // 移除所有包含 "comment 1" 文字的註解
    foreach (ICommentAuthor commentAuthor in presentation.CommentAuthors)
    {
        List<IComment> toRemove = new List<IComment>();
        foreach (IComment comment in slide.GetSlideComments(commentAuthor))
        {
            if (comment.Text == "comment 1")
            {
                toRemove.Add(comment);
            }
        }
        
        foreach (IComment comment in toRemove)
        {
            commentAuthor.Comments.Remove(comment);
        }
    }
    
    presentation.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **常見問題**

**Aspose.Slides 是否支援類似「已解決」的狀態於現代註解？**

是。[Modern comments](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/moderncomment/) 提供 [Status](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/moderncomment/status/) 屬性；您可以讀取和設定 [註解的狀態](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/moderncommentstatus/)（例如將其標記為已解決），此狀態會儲存在檔案中，且 PowerPoint 會辨識。

**是否支援有層次的討論（回覆鏈），且是否有巢狀深度限制？**

是。每個註解皆可參考其 [parent comment](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/comment/parentcomment/)，因此可以建立任意深度的回覆鏈。API 並未宣告特定的巢狀深度限制。

**註解標記在投影片上的位置是以什麼座標系統定義的？**

位置以浮點座標點儲存在投影片的座標系統中，讓您能將註解標記精確放置於所需位置。