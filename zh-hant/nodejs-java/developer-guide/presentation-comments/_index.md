---
title: 管理 Node.js 中的簡報評論
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
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java 管理簡報評論：在 PowerPoint 簡報中新增、閱讀、編輯、回覆和移除評論。"
---
## **概覽**

本文說明如何使用 Aspose.Slides for Node.js via Java 來管理簡報評論。它介紹了主要的與評論相關的類型，並示範如何在投影片上新增評論、存取現有評論、處理回覆與現代評論，以及從簡報中移除評論。

範例涵蓋了 PowerPoint 中常見的審閱與協作情境，例如將評論指派給作者、讀取評論文字與中繼資料、建立回覆鏈，以及移除選取的評論或全部評論。

在 PowerPoint 中，評論會以投影片上的標註形式出現。選取評論時會顯示其文字與相關討論。

若要在開啟簡報時請求顯示或隱藏評論而不變更評論本身，請參閱[在開啟簡報時顯示或隱藏評論](/slides/zh-hant/nodejs-java/presentation-view-properties/)。

## **為何在簡報中加入評論？**

在審閱簡報時，您可以使用評論來提供回饋並與同事協作。

Aspose.Slides for Node.js via Java 提供以下用於處理評論的 API：

* [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別，提供存取簡報的評論作者。
* [CommentCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/commentcollection/) 類別，代表與單一作者相關聯的評論。
* [Comment](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/comment/) 類別，提供有關評論的資訊，包括作者、建立時間、位置與文字。
* [CommentAuthor](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/commentauthor/) 類別，提供有關作者的資訊，包括其名稱、縮寫與相關評論。

## **新增投影片評論**

以下範例示範如何在 PowerPoint 簡報的投影片中新增評論：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const secondSlide = presentation.getSlides().addEmptySlide(presentation.getLayoutSlides().get_Item(0));
    const author = presentation.getCommentAuthors().addAuthor("Jawad", "MF");
    const position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.2), java.newFloat(0.2));
    const createdTime = java.newInstanceSync("java.util.Date");

    author.getComments().addComment("Hello Jawad, this is a slide comment", firstSlide, position, createdTime);
    author.getComments().addComment("Hello Jawad, this is the second slide comment", secondSlide, position, createdTime);

    const comments = firstSlide.getSlideComments(author);
    if (comments.length > 0) {
        const firstComment = comments[0];
        console.log(firstComment.getText());

        const authorComments = firstComment.getAuthor().getComments();
        const commentText = authorComments.get_Item(0).getText();
        console.log(commentText);
    }

    presentation.save("Comments_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **存取投影片評論**

以下範例示範如何在 PowerPoint 簡報中存取現有評論：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("Comments1.pptx");
try {
    const authors = presentation.getCommentAuthors();
    for (let authorIndex = 0; authorIndex < authors.size(); authorIndex++) {
        const author = authors.get_Item(authorIndex);
        const comments = author.getComments();

        for (let commentIndex = 0; commentIndex < comments.size(); commentIndex++) {
            const comment = comments.get_Item(commentIndex);
            console.log("Slide: " + comment.getSlide().getSlideNumber());
            console.log("Comment: " + comment.getText());
            console.log("Author: " + comment.getAuthor().getName());
            console.log("Posted at: " + comment.getCreatedTime());
            console.log();
        }
    }
} finally {
    presentation.dispose();
}
```

## **回覆評論**

父評論是回覆層級最上方的原始評論。[Comment.getParentComment](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/comment/getparentcomment/) 與 [Comment.setParentComment](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/comment/setparentcomment/) 方法可讓您取得或設定評論的父評論。

以下範例示範如何新增回覆並檢查產生的評論層級結構：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10));
    const createdTime = java.newInstanceSync("java.util.Date");

    const author1 = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.");
    const comment1 = author1.getComments().addComment("comment 1", slide, position, createdTime);

    const author2 = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.");
    const reply1 = author2.getComments().addComment("reply 1 for comment 1", slide, position, createdTime);
    reply1.setParentComment(comment1);

    const reply2 = author2.getComments().addComment("reply 2 for comment 1", slide, position, createdTime);
    reply2.setParentComment(comment1);

    const subReply = author1.getComments().addComment("subreply 3 for reply 2", slide, position, createdTime);
    subReply.setParentComment(reply2);

    author2.getComments().addComment("comment 2", slide, position, createdTime);
    const comment3 = author2.getComments().addComment("comment 3", slide, position, createdTime);

    const reply3 = author1.getComments().addComment("reply 4 for comment 3", slide, position, createdTime);
    reply3.setParentComment(comment3);

    const comments = slide.getSlideComments(null);
    for (let index = 0; index < comments.length; index++) {
        let comment = comments[index];
        let indentation = "";
        while (comment.getParentComment() != null) {
            indentation += "\t";
            comment = comment.getParentComment();
        }

        console.log(indentation + comments[index].getAuthor().getName() + ": " + comments[index].getText());
    }

    presentation.save("parent_comment.pptx", aspose.slides.SaveFormat.Pptx);

    comment1.remove();
    presentation.save("remove_comment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
* 當使用 [Comment.remove](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/comment/remove/) 方法刪除評論時，該評論的所有回覆也會被刪除。
* 若 [Comment.setParentComment](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/comment/setparentcomment/) 產生循環參考，則會拋出 [PptxEditException](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pptxeditexception/)。
{{% /alert %}}

## **新增現代評論**

現代評論可以與投影片本身、特定圖形，或是 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/) 內的文字範圍關聯。[CommentCollection.addModernComment](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) 方法接受一個 [Shape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/) 參數，除投影片與評論標記座標之外。

當 `null` 被傳入 shape 參數時，評論為投影片層級的評論。其標記由提供的座標定位，但不會關聯到特定圖形，因此 [ModernComment.getShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/moderncomment/getshape/) 會回傳 `null`。當提供了 [Shape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/) 時，評論會錨定於該圖形。座標仍然定義評論標記在投影片上的位置，而圖形關聯可透過 [ModernComment.getShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/moderncomment/getshape/) 取得。

### **將現代評論錨定至圖形**

以下範例同時建立投影片層級的現代評論與錨定於特定 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/) 的現代評論，然後從每個評論中讀取其關聯的圖形。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 300, 80);
    shape.setName("Revenue title");
    shape.getTextFrame().setText("Quarterly revenue");

    const createdTime = java.newInstanceSync("java.util.Date");
    const slideCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(20), java.newFloat(20));
    const shapeCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(60), java.newFloat(60));
    const slideComment = author.getComments().addModernComment("Review the overall slide layout.", slide, null, slideCommentPosition, createdTime);
    const shapeComment = author.getComments().addModernComment("Check this title.", slide, shape, shapeCommentPosition, createdTime);

    console.log(slideComment.getShape() == null);
    console.log(shapeComment.getShape().getName());

    presentation.save("modern_comments.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **將評論錨定至不同圖形類型**

任何繼承自 [Shape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/) 的投影片物件皆可作為圖形錨點。常見範例包括 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/)、[PictureFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pictureframe/)、[GroupShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/groupshape/)、[Connector](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/connector/) 與 [GraphicalObject](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/graphicalobject/)（例如圖表）之實例。

以下範例建立多種常見圖形類型，並為每一個圖形關聯一個現代評論。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    const createdTime = java.newInstanceSync("java.util.Date");

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 180, 60);
    autoShape.getTextFrame().setText("AutoShape");
    const autoShapeCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(30), java.newFloat(30));
    author.getComments().addModernComment("Comment on an AutoShape.", slide, autoShape, autoShapeCommentPosition, createdTime);

    const imageBase64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
    const imageData = java.newArray("byte", Array.from(Buffer.from(imageBase64, "base64")));
    const image = presentation.getImages().addImage(imageData);
    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 220, 20, 120, 80, image);
    const pictureCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(230), java.newFloat(30));
    author.getComments().addModernComment("Comment on a picture.", slide, pictureFrame, pictureCommentPosition, createdTime);

    const groupShape = slide.getShapes().addGroupShape();
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 80, 40);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 100, 0, 80, 40);
    const groupCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(40), java.newFloat(150));
    author.getComments().addModernComment("Comment on a group.", slide, groupShape, groupCommentPosition, createdTime);

    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.StraightConnector1, 220, 150, 140, 40);
    const connectorCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(240), java.newFloat(150));
    author.getComments().addModernComment("Comment on a connector.", slide, connector, connectorCommentPosition, createdTime);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 400, 20, 250, 180);
    const chartCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(420), java.newFloat(40));
    author.getComments().addModernComment("Comment on a graphical object.", slide, chart, chartCommentPosition, createdTime);

    presentation.save("modern_comment_shape_types.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **將評論錨定至文字並設定其狀態**

對於與 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/) 關聯的現代評論，[ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/) 與 [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/moderncomment/settextselectionstart/) 讀取形狀文字框中所選文字的起始位置。[ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) 與 [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/moderncomment/settextselectionlength/) 讀取選取的長度。結合這些值即可將評論與 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/) 內的特定文字範圍關聯。

[ModernComment.getStatus](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/moderncomment/getstatus/) 與 [ModernComment.setStatus](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/moderncomment/setstatus/) 方法存取 [ModernCommentStatus](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/moderncommentstatus/) 列舉中的值：

- `NotDefined` — 未定義特定的現代評論狀態。
- `Active` — 評論處於活躍狀態。
- `Resolved` — 評論已解決。
- `Closed` — 評論已關閉。

以下範例建立一個錨定於圖形的現代評論，將其與文字選取關聯，標記為已解決，儲存簡報，並在重新開啟檔案後驗證其值。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const outputFile = "modern_comment_text_anchor.pptx";
const shapeText = "Review the quarterly revenue forecast.";
const selectedText = "quarterly revenue";
const expectedSelectionStart = shapeText.indexOf(selectedText);

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.setName("Forecast text");
    shape.getTextFrame().setText(shapeText);

    const author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    const commentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(60), java.newFloat(60));
    const createdTime = java.newInstanceSync("java.util.Date");
    const comment = author.getComments().addModernComment("Verify this forecast wording.", slide, shape, commentPosition, createdTime);
    comment.setTextSelectionStart(expectedSelectionStart);
    comment.setTextSelectionLength(selectedText.length);
    comment.setStatus(aspose.slides.ModernCommentStatus.Resolved);

    presentation.save(outputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation(outputFile);
try {
    const reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    const reopenedComments = reopenedSlide.getSlideComments(null);

    for (let index = 0; index < reopenedComments.length; index++) {
        const reopenedComment = reopenedComments[index];
        if (!java.instanceOf(reopenedComment, "com.aspose.slides.IModernComment")) {
            continue;
        }

        const shapeMatches = reopenedComment.getShape() != null && reopenedComment.getShape().getName() === "Forecast text";
        const selectionStartMatches = reopenedComment.getTextSelectionStart() === expectedSelectionStart;
        const selectionLengthMatches = reopenedComment.getTextSelectionLength() === selectedText.length;
        const statusMatches = reopenedComment.getStatus() === aspose.slides.ModernCommentStatus.Resolved;

        console.log("Shape anchor preserved: " + shapeMatches);
        console.log("Text selection start preserved: " + selectionStartMatches);
        console.log("Text selection length preserved: " + selectionLengthMatches);
        console.log("Resolved status preserved: " + statusMatches);
    }
} finally {
    reopenedPresentation.dispose();
}
```

### **檢查現有的現代評論**

若要檢查現有簡報，請先確認哪些評論是 [ModernComment](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/moderncomment/) 例項，然後檢視 [ModernComment.getShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/moderncomment/getshape/)、[ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/)、[ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/)、以及 [ModernComment.getStatus](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/moderncomment/getstatus/)。`null` 的 shape 表示投影片層級的評論。對於 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/) 錨點，文字選取方法會識別形狀文字框中關聯的範圍。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("comments.pptx");
try {
    const slides = presentation.getSlides();
    for (let slideIndex = 0; slideIndex < slides.size(); slideIndex++) {
        const slide = slides.get_Item(slideIndex);
        const comments = slide.getSlideComments(null);

        for (let commentIndex = 0; commentIndex < comments.length; commentIndex++) {
            const comment = comments[commentIndex];
            if (!java.instanceOf(comment, "com.aspose.slides.IModernComment")) {
                continue;
            }

            console.log("Slide: " + slide.getSlideNumber());
            console.log("Text: " + comment.getText());
            console.log("Status: " + comment.getStatus());

            const shape = comment.getShape();
            if (shape == null) {
                console.log("Anchor: slide level");
            } else {
                console.log("Anchor shape: " + shape.getName());
                console.log("Anchor type: " + shape.getClass().getSimpleName());

                if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                    console.log("Text selection start: " + comment.getTextSelectionStart());
                    console.log("Text selection length: " + comment.getTextSelectionLength());
                }
            }

            console.log();
        }
    }
} finally {
    presentation.dispose();
}
```

## **移除評論**

### **移除所有評論與評論作者**

以下範例示範如何從簡報中移除所有評論與評論作者：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("example.pptx");
try {
    const authors = presentation.getCommentAuthors();
    for (let index = 0; index < authors.size(); index++) {
        authors.get_Item(index).getComments().clear();
    }

    authors.clear();
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **移除特定評論**

以下範例示範如何從投影片中移除特定評論：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const author = presentation.getCommentAuthors().addAuthor("Author", "A");
    const createdTime = java.newInstanceSync("java.util.Date");

    const firstCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.2), java.newFloat(0.2));
    const secondCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.3), java.newFloat(0.2));
    author.getComments().addComment("comment 1", slide, firstCommentPosition, createdTime);
    author.getComments().addComment("comment 2", slide, secondCommentPosition, createdTime);

    const authors = presentation.getCommentAuthors();
    for (let authorIndex = 0; authorIndex < authors.size(); authorIndex++) {
        const commentAuthor = authors.get_Item(authorIndex);
        const commentsToRemove = [];
        const comments = slide.getSlideComments(commentAuthor);

        for (let commentIndex = 0; commentIndex < comments.length; commentIndex++) {
            const comment = comments[commentIndex];
            if (comment.getText() === "comment 1") {
                commentsToRemove.push(comment);
            }
        }

        for (const comment of commentsToRemove) {
            commentAuthor.getComments().remove(comment);
        }
    }

    presentation.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常見問題**

**Aspose.Slides 是否支援現代評論的已解決狀態？**

是。[ModernComment.getStatus](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/moderncomment/getstatus/) 與 [ModernComment.setStatus](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/moderncomment/setstatus/) 會存取 [ModernCommentStatus](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/moderncommentstatus/) 的值，其中包含 `Resolved`。此狀態會儲存在簡報中，重新開啟檔案後仍可再次讀取。

**是否支援串聯討論（回覆鏈），且是否有巢狀深度限制？**

是。每個評論皆可參照其 [parent comment](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/comment/getparentcomment/)，從而形成回覆鏈。API 並未定義特定的巢狀深度限制。

**評論標記在投影片上的位置是以哪種座標系統定義的？**

標記位置是以投影片座標系統中的浮點座標定義，允許您精確地將其放置在投影片上。