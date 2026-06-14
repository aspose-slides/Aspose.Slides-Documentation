---
title: 在 Android 上管理簡報註解
linktitle: 簡報註解
type: docs
weight: 100
url: /zh-hant/androidjava/presentation-comments/
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
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 徹底掌握簡報註解：快速且輕鬆地在 PowerPoint 檔案中新增、讀取、編輯與刪除註解。"
---
## **概覽**

本文說明如何在 Aspose.Slides 中管理簡報註解。它展示了主要的與註解相關的類型，並示範如何將註解新增到投影片、存取現有註解、處理回覆、使用現代註解，以及從簡報中移除註解。

範例聚焦於 PowerPoint 中常見的審閱與協作情境，例如將註解指派給作者、讀取註解內容與中繼資料、建立回覆鏈，以及清除所有註解或刪除選取的註解。

在 PowerPoint 中，註解會以投影片上的備註或標註形式顯示。點擊註解時，其內容或訊息會展開顯示。

### **為什麼要在簡報中添加註解？**

在審閱簡報時，您可能會想使用註解來提供回饋或與同事溝通。

為了讓您能在 PowerPoint 簡報中使用註解，Aspose.Slides for Android via Java 提供了

* [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別，包含作者集合（來自 [ICommentAuthorCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ICommentAuthorCollection) 介面）。作者會將註解新增至投影片。
* [ICommentCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ICommentCollection) 介面，包含個別作者的註解集合。
* [IComment](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IComment) 類別，提供作者及其註解的資訊：誰新增了註解、註解的新增時間、註解的位置等。
* [CommentAuthor](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/CommentAuthor) 類別，包含個別作者的資訊：作者名稱、縮寫、與該作者相關的註解等。

## **新增投影片註解**
以下 Java 程式碼示範如何在 PowerPoint 簡報的投影片中新增註解：

```java
// 建立 Presentation 類別的實例
Presentation pres = new Presentation();
try {
    // 新增空白投影片
    pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    // 新增作者
    ICommentAuthor author = pres.getCommentAuthors().addAuthor("Jawad", "MF");

    // 設定註解的位置
    Point2D.Float point = new Point2D.Float(0.2f, 0.2f);

    // 為作者在投影片 1 上新增投影片註解
    author.getComments().addComment("Hello Jawad, this is slide comment", pres.getSlides().get_Item(0), point, new Date());

    // 為作者在投影片 2 上新增投影片註解
    author.getComments().addComment("Hello Jawad, this is second slide comment", pres.getSlides().get_Item(1), point, new Date());

    // 取得 ISlide 1
    ISlide slide = pres.getSlides().get_Item(0);

    // 當參數傳入 null 時，會將所有作者的註解帶入選取的投影片
    IComment[] Comments = slide.getSlideComments(author);

    // 取得投影片 1 中索引 0 的註解
    String str = Comments[0].getText();

    pres.save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.length > 0)
    {
        // 取得作者在索引 0 的註解集合
        ICommentCollection commentCollection = Comments[0].getAuthor().getComments();
        String Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **存取投影片註解**
以下 Java 程式碼示範如何存取 PowerPoint 簡報中投影片的現有註解：

```java
// 實例化 Presentation 類別
Presentation pres = new Presentation("Comments1.pptx");
try {
    for (ICommentAuthor commentAuthor : pres.getCommentAuthors())
    {
        CommentAuthor author = (CommentAuthor) commentAuthor;
        for (IComment comment1 : author.getComments())
        {
            Comment comment = (Comment) comment1;
            System.out.println("ISlide :" + comment.getSlide().getSlideNumber() + " has comment: " + comment.getText() +
                    " with Author: " + comment.getAuthor().getName() + " posted on time :" + comment.getCreatedTime() + "\n");
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **回覆註解**
父註解是註解或回覆階層中的最上層或原始註解。使用 [getParentComment](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IComment#getParentComment--) 或 [setParentComment](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) 方法（來自 [IComment](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IComment) 介面），即可取得或設定父註解。

以下 Java 程式碼示範如何新增註解以及取得其回覆：

```java
Presentation pres = new Presentation();
try {
    // 新增註解
    ICommentAuthor author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    // 為 comment1 新增回覆
    ICommentAuthor author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply1.setParentComment(comment1);

    // 為 comment1 再新增另一個回覆
    IComment reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    reply2.setParentComment(comment1);

    // 為既有回覆新增回覆
    IComment subReply = author1.getComments().addComment("subreply 3 for reply 2", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    subReply.setParentComment(reply2);

    IComment comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    IComment comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    IComment reply3 = author1.getComments().addComment("reply 4 for comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply3.setParentComment(comment3);

    // 在主控台顯示註解階層
    ISlide slide = pres.getSlides().get_Item(0);
    IComment[] comments = slide.getSlideComments(null);
    for (int i = 0; i < comments.length; i++)
    {
        IComment comment = comments[i];
        while (comment.getParentComment() != null)
        {
            System.out.print("\t");
            comment = comment.getParentComment();
        }

        System.out.println(comments[i].getAuthor().getName() +  " : " + comments[i].getText());
        System.out.println();
    }
    pres.save("parent_comment.pptx",SaveFormat.Pptx);

    // 移除 comment1 以及其所有回覆
    comment1.remove();

    pres.save("remove_comment.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" title="Attention" %}} 
* 當使用 [Remove](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IComment#remove--) 方法（來自 [IComment](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IComment) 介面）刪除註解時，該註解的回覆也會一起被刪除。
* 若將 [setParentComment](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) 設定為循環參考，將拋出 [PptxEditException](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/PptxEditException)。
{{% /alert %}}

## **新增現代註解**

2021 年，Microsoft 在 PowerPoint 中推出了 *現代註解*。現代註解功能大幅提升了 PowerPoint 的協作能力。透過現代註解，PowerPoint 使用者可以解決註解、將註解錨定於物件與文字，並更輕鬆地進行互動。

Aspose.Slides 透過 [ModernComment](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ModernComment) 類別支援現代註解。已在 [CommentCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/CommentCollection) 類別中加入 [addModernComment](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/CommentCollection#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) 與 [insertModernComment](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) 方法。

以下 Java 程式碼示範如何在 PowerPoint 簡報的投影片中新增現代註解：

```java
Presentation pres = new Presentation();
try {
    ICommentAuthor newAuthor = pres.getCommentAuthors().addAuthor("Some Author", "SA");
    IModernComment modernComment = newAuthor.getComments().addModernComment("This is a modern comment", pres.getSlides().get_Item(0), null, new Point2D.Float(100, 100), new Date());

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **移除註解**

### **刪除所有註解與作者**
以下 Java 程式碼示範如何在簡報中移除所有註解與作者：

```java
Presentation presentation = new Presentation("example.pptx");
try {
    // 刪除簡報中的所有註解
    for (ICommentAuthor author : presentation.getCommentAuthors())
    {
        author.getComments().clear();
    }

    // 刪除所有作者
    presentation.getCommentAuthors().clear();

    presentation.save("example_out.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **刪除特定註解**
以下 Java 程式碼示範如何刪除投影片上的特定註解：

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 新增註解...
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comment 1", slide, new Point2D.Float(0.2f, 0.2f), new Date());
    author.getComments().addComment("comment 2", slide, new Point2D.Float(0.3f, 0.2f), new Date());

    // 移除所有包含 "comment 1" 文字的註解
    for (ICommentAuthor commentAuthor : presentation.getCommentAuthors())
    {
        ArrayList<IComment> toRemove = new ArrayList<IComment>();
        for (IComment comment : slide.getSlideComments(commentAuthor))
        {
            if (comment.getText().equals("comment 1"))
            {
                toRemove.add(comment);
            }
        }

        for (IComment comment : toRemove)
        {
            commentAuthor.getComments().remove(comment);
        }
    }

    presentation.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **常見問題**

**Aspose.Slides 是否支援類似「已解決」的狀態於現代註解？**  
是的。[Modern comments](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/moderncomment/) 提供 [setStatus](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/moderncomment/#setStatus-byte-) 方法；您可以寫入 [comment’s state](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/moderncommentstatus/)（例如將其標記為已解決），此狀態會儲存在檔案中並被 PowerPoint 識別。

**是否支援串聯討論（回覆鏈），且是否有巢狀深度限制？**  
是的。每個註解都可以參照其 [parent comment](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/comment/#getParentComment--)，從而允許任意深度的回覆鏈。API 並未宣告特定的巢狀深度限制。

**註解標記在投影片上的位置是以哪種座標系統定義的？**  
位置以浮點座標點儲存在投影片的座標系統中，讓您能精確地將註解標記放置在所需位置。