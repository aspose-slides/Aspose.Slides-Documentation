---
title: 在 JavaScript 中管理簡報評論
linktitle: 簡報評論
type: docs
weight: 100
url: /zh-hant/nodejs-java/presentation-comments/
keywords:
- 評論
- 現代評論
- PowerPoint 評論
- 簡報評論
- 投影片評論
- 新增評論
- 存取評論
- 編輯評論
- 回覆評論
- 移除評論
- 刪除評論
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js 完整掌握簡報評論：使用 JavaScript 快速且輕鬆地在 PowerPoint 檔案中新增、讀取、編輯和刪除評論。"
---
## **概覽**

本文說明如何在 Aspose.Slides 中管理簡報評論。它展示了主要的與評論相關的類型，並示範如何向投影片新增評論、存取現有評論、處理回覆、使用現代評論以及從簡報中移除評論。

這些範例聚焦於 PowerPoint 中常見的審閱與協作情境，例如指派評論給作者、讀取評論內容與中繼資料、建立回覆鏈，以及清除所有評論或刪除選取的評論。

在 PowerPoint 中，評論顯示為投影片上的註記或標註。點擊評論時，會顯示其內容或訊息。

## **為何要在簡報中加入評論？**

在審閱簡報時，您可能會想使用評論來提供回饋或與同事溝通。

為了讓您在 PowerPoint 簡報中使用評論，Aspose.Slides for Node.js via Java 提供

* The [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) class，包含作者集合（來自 [CommentAuthorCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/CommentAuthorCollection) 類別）。作者會在投影片加入評論。
* The [CommentCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/CommentCollection) class，包含個別作者的評論集合。
* The [Comment](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Comment) class，包含作者與其評論的資訊：誰新增了評論、評論的新增時間、評論的位置等。
* The [CommentAuthor](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/CommentAuthor) class，包含個別作者的資訊：作者名稱、縮寫、與該作者名稱相關的評論等。

## **新增投影片評論**
以下 JavaScript 程式碼示範如何在 PowerPoint 簡報的投影片中新增評論：

```javascript
// 建立 Presentation 類別的實例
var pres = new aspose.slides.Presentation();
try {
    // 新增空白投影片
    pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    // 新增作者
    var author = pres.getCommentAuthors().addAuthor("Jawad", "MF");
    // 設定評論的位置
    var point = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.2), java.newFloat(0.2));
    // 為作者在投影片 1 上新增投影片評論
    author.getComments().addComment("Hello Jawad, this is slide comment", pres.getSlides().get_Item(0), point, java.newInstanceSync("java.util.Date"));
    // 為作者在投影片 2 上新增投影片評論
    author.getComments().addComment("Hello Jawad, this is second slide comment", pres.getSlides().get_Item(1), point, java.newInstanceSync("java.util.Date"));
    // 存取 ISlide 1
    var slide = pres.getSlides().get_Item(0);
    // 當參數為 null 時，會將所有作者的評論帶到選取的投影片
    var Comments = slide.getSlideComments(author);
    // 存取投影片 1 上索引 0 的評論
    var str = Comments[0].getText();
    pres.save("Comments_out.pptx", aspose.slides.SaveFormat.Pptx);
    if (Comments.length > 0) {
        // 選取索引 0 處的作者評論集合
        var commentCollection = Comments[0].getAuthor().getComments();
        var Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **存取投影片評論**
以下 JavaScript 程式碼示範如何在 PowerPoint 簡報的投影片中存取既有評論：

```javascript
var pres = new aspose.slides.Presentation("Comments1.pptx");
try {
    for (let i = 0; i < pres.getCommentAuthors().size(); i++) {
        let commentAuthor = pres.getCommentAuthors().get_Item(i);
        for (let j = 0; j < commentAuthor.getComments().size(); j++) {
            const comment = commentAuthor.getComments().get_Item(j);
            console.log("ISlide :" + comment.getSlide().getSlideNumber() + " has comment: " + comment.getText() + " with Author: " + comment.getAuthor().getName() + " posted on time :" + comment.getCreatedTime() + "\n");
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **回覆評論**
父級評論是評論或回覆層級結構中的頂層或原始評論。使用 [getParentComment](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Comment#getParentComment--) 或 [setParentComment](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Comment#setParentComment-aspose.slides.IComment-) 方法（來自 [Comment](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Comment) 類別），您可以設定或取得父級評論。

以下 JavaScript 程式碼示範如何新增評論以及取得其回覆：

```javascript
var pres = new aspose.slides.Presentation();
try {
    // 新增評論
    var author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    var comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    // 為 comment1 新增回覆
    var author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    var reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply1.setParentComment(comment1);
    // 再為 comment1 新增一個回覆
    var reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply2.setParentComment(comment1);
    // 為已存在的回覆新增回覆
    var subReply = author1.getComments().addComment("subreply 3 for reply 2", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    subReply.setParentComment(reply2);
    var comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    var comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    var reply3 = author1.getComments().addComment("reply 4 for comment 3", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply3.setParentComment(comment3);
    // 在主控台顯示評論層級結構
    var slide = pres.getSlides().get_Item(0);
    var comments = slide.getSlideComments(null);
    for (var i = 0; i < comments.length; i++) {
        var comment = comments[i];
        while (comment.getParentComment() != null) {
            console.log("\t");
            comment = comment.getParentComment();
        }
        console.log((comments[i].getAuthor().getName() + " : ") + comments[i].getText());
        console.log();
    }
    pres.save("parent_comment.pptx", aspose.slides.SaveFormat.Pptx);
    // 移除 comment1 以及所有對它的回覆
    comment1.remove();
    pres.save("remove_comment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="warning" title="Attention" %}} 
* 當使用 [Remove](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Comment#remove--) 方法（來自 [Comment](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Comment) 類別）刪除評論時，該評論的回覆也會被刪除。
* 若 [setParentComment](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Comment#setParentComment-aspose.slides.IComment-) 設定導致循環參考，將拋出 [PptxEditException](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/PptxEditException)。
{{% /alert %}}

## **新增現代評論**

2021 年，Microsoft 在 PowerPoint 中引入了 *modern comments*（現代評論）。現代評論功能大幅提升了 PowerPoint 的協作體驗。透過現代評論，PowerPoint 使用者可以解決評論、將評論錨定在物件與文字上，並更輕鬆地進行互動。

Aspose.Slides 透過 [ModernComment](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ModernComment) 類別支援現代評論。在 [CommentCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/CommentCollection) 類別中加入了 [addModernComment](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/CommentCollection#addModernComment-java.lang.String-aspose.slides.ISlide-aspose.slides.IShape-java.awt.geom.Point2D$Float-java.util.Date-) 及 [insertModernComment](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-aspose.slides.ISlide-aspose.slides.IShape-java.awt.geom.Point2D$Float-java.util.Date-) 方法。

以下 JavaScript 程式碼示範如何在 PowerPoint 簡報的投影片中新增現代評論：

```javascript
var pres = new aspose.slides.Presentation();
try {
    var newAuthor = pres.getCommentAuthors().addAuthor("Some Author", "SA");
    var modernComment = newAuthor.getComments().addModernComment("This is a modern comment", pres.getSlides().get_Item(0), null, java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(100), java.newFloat(100)), java.newInstanceSync("java.util.Date"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **移除評論**

### **刪除所有評論與作者**
以下 JavaScript 程式碼示範如何在簡報中移除所有評論與作者：

```javascript
var presentation = new aspose.slides.Presentation("example.pptx");
try {
    // 刪除簡報中的所有評論
    for (let i = 0; i < presentation.getCommentAuthors().size(); i++) {
    var author = presentation.getCommentAuthors().get_Item(i)
        author.getComments().clear();
    }
    // 刪除所有作者
    presentation.getCommentAuthors().clear();
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

### **刪除特定評論**
以下 JavaScript 程式碼示範如何在投影片上刪除特定評論：

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    // 新增評論...
    var author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comment 1", slide, java.newInstanceSync("com.aspose.slides.Point2DFloat",  java.newFloat(0.2), java.newFloat(0.2)), java.newInstanceSync("java.util.Date"));
    author.getComments().addComment("comment 2", slide, java.newInstanceSync("com.aspose.slides.Point2DFloat",  java.newFloat(0.3), java.newFloat(0.2)), java.newInstanceSync("java.util.Date"));
    // 移除所有包含 "comment 1" 文字的評論
    
    
    for (var i = 0; i < presentation.getCommentAuthors().length; i++) {
        var commentAuthor = presentation.getCommentAuthors().get_Item(i);
        var toRemove = java.newInstanceSync("java.util.ArrayList");
        for (let j = 0; j < slide.getSlideComments(commentAuthor).size(); j++) {
            let comment = slide.getSlideComments(commentAuthor).get_Item(j);
            if (comment.getText() === "comment 1") {
                toRemove.add(comment);
            }
        }
        for (var i = 0; i < toRemove.length; i++) {
            var comment = toRemove.get_Item(i);
            commentAuthor.getComments().remove(comment);
        }
    }
    presentation.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **常見問答**

**Aspose.Slides 是否支援現代評論的 '已解決' 狀態？**

是的。[Modern comments](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/moderncomment/) 提供 [getStatus](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/moderncomment/getstatus/) 及 [setStatus](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/moderncomment/setStatus/) 方法；您可以讀取並設定 [comment’s state](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/moderncommentstatus/)（例如標記為已解決），此狀態會儲存在檔案中，且會被 PowerPoint 辨識。

**是否支援線索討論（回覆鏈），且有巢狀深度限制嗎？**

是的。每個評論都可以參考其 [parent comment](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/comment/getparentcomment/)，以實現任意的回覆鏈。API 並未宣告特定的巢狀深度限制。

**評論標記的位置在投影片上是以哪種座標系定義的？**

位置以浮點座標點儲存在投影片的座標系統中。這讓您能精確地將評論標記放置在所需位置。