---
title: 管理 Node.js 中的簡報註解
linktitle: 簡報註解
type: docs
weight: 100
url: /zh-hant/nodejs-java/presentation-comments/
keywords:
- 註解
- 現代註解
- PowerPoint 註解
- 簡報註解
- 投影片註解
- 新增註解
- 讀取註解
- 編輯註解
- 回覆註解
- 移除註解
- 刪除註解
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java 管理簡報註解：在 PowerPoint 簡報中新增、閱讀、編輯、回覆及移除註解。"
---
## **概述**

本文說明如何使用 Aspose.Slides for Node.js via Java 來管理簡報註解。它介紹了與註解相關的主要類型，示範如何在投影片上添加註解、存取現有註解、處理回覆與現代註解，以及如何從簡報中移除註解。

示例涵蓋 PowerPoint 中常見的審閱與協作情境，例如為註解指派作者、讀取註解文字與中繼資料、建立回覆鏈，以及刪除選取的註解或全部註解。

在 PowerPoint 中，註解以投影片上的標註形式顯示。選取註解時會顯示其文字及相關討論。

若要在開啟簡報時要求顯示或隱藏註解（而不更改註解本身），請參閱[在開啟簡報時顯示或隱藏註解](/slides/zh-hant/nodejs-java/presentation-view-properties/)。

## **為什麼要在簡報中添加註解？**

在審閱簡報時，您可以使用註解提供回饋並與同事協作。

Aspose.Slides for Node.js via Java 提供以下 API 來操作註解：

* [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 類別，提供存取簡報的註解作者。
* [CommentCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/) 類別，表示與單一作者相關的註解集合。
* [Comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/) 類別，提供註解的資訊，包括作者、建立時間、位置與文字。
* [CommentAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthor/) 類別，提供作者資訊，包括名稱、縮寫與相關註解。

## **添加投影片註解**

範例建立兩張投影片，並使用 [addAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/addauthor/) 註冊一位註解作者。接著使用 [addComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addcomment/) 在每張投影片上放置一則註解，然後透過 [getSlideComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidecomments/) 取得該作者在第一張投影片上的註解。主控台會兩次顯示第一則註解的文字，示範了同時透過投影片與作者存取的方式，且儲存的簡報包含兩則註解。

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

        const commentText = firstComment.getAuthor().getComments().get_Item(0).getText();
        console.log(commentText);
    }

    presentation.save("Comments_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **尋找或建立註解作者**

當自動審閱重複處理同一簡報時，應在新增作者之前先搜尋 [getCommentAuthors](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getcommentauthors/) 回傳的集合。[findByNameAndInitials](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/findbynameandinitials/) 會同時比對名稱與縮寫，並回傳符合的作者陣列，若無符合則回傳空陣列。相較之下，[findByName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/findbyname/) 僅依名稱搜尋，與縮寫無關。使用已存在的名稱與縮寫呼叫 [addAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/addauthor/) 會拋出例外。

此範例需要一個至少包含一張投影片的簡報檔案。於兩次執行中，它會重複使用第一個符合的作者，或在結果為空時才建立新作者。若有多筆符合，會選取陣列的第一個元素，而不合併或移除其他作者。接著針對選取的作者呼叫 [addComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addcomment/) 並儲存簡報。第二次執行會開啟第一次的輸出檔案並重複此操作。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const authorName = "Reviewer";
const authorInitials = "RV";

let inputFile = "input.pptx";
const position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(20), java.newFloat(20));

for (let pass = 1; pass <= 2; pass++) {
    const presentation = new aspose.slides.Presentation(inputFile);
    try {
        const matches = presentation.getCommentAuthors().findByNameAndInitials(authorName, authorInitials);

        const author = matches.length > 0 ? matches[0] : presentation.getCommentAuthors().addAuthor(authorName, authorInitials);
        const createdTime = java.newInstanceSync("java.util.Date");
        author.getComments().addComment("Please review this slide.", presentation.getSlides().get_Item(0), position, createdTime);

        const outputFile = "review_pass_" + pass + ".pptx";
        presentation.save(outputFile, aspose.slides.SaveFormat.Pptx);
        inputFile = outputFile;
    } finally {
        presentation.dispose();
    }
}
```

第二次執行會再加入一則註解，但不會再新增作者或移除既有註解。最終檔案 `review_pass_2.pptx` 會同時包含新舊兩則註解。重複使用作者不會自動去除重複註解：若要避免反覆加入相同註解，請在新增前自行實作去重機制。

## **存取投影片註解**

此範例開啟既有簡報，並讀取 [getCommentAuthors](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getcommentauthors/) 回傳的集合。對每位作者，遍歷 [getComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthor/getcomments/) 回傳的集合，並印出投影片編號、註解文字、作者名稱與建立時間。輸入的簡報必須包含註解才會有主控台輸出。

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

## **回覆註解**

父註解是回覆階層最上層的原始註解。[Comment.getParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/getparentcomment/) 與 [Comment.setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/setparentcomment/) 方法可取得或設定註解的父項。

範例從兩位作者建立註解，並使用 [setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/setparentcomment/) 建立回覆，包括對另一回覆的回覆。將 `null` 傳入 [getSlideComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidecomments/) 會取得所有作者的註解；主控台會根據回覆階層深度縮排顯示每筆條目。範例儲存完整討論，對第一筆根註解呼叫 [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/remove/)，並儲存第二個已移除該註解及其回覆的簡報。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10));
    const createdTime = java.newInstanceSync("java.util.Date");

    const originalAuthor = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.");
    const rootComment = originalAuthor.getComments().addComment("comment 1", slide, position, createdTime);

    const reviewer = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.");
    const firstReply = reviewer.getComments().addComment("reply 1 for comment 1", slide, position, createdTime);
    firstReply.setParentComment(rootComment);

    const secondReply = reviewer.getComments().addComment("reply 2 for comment 1", slide, position, createdTime);
    secondReply.setParentComment(rootComment);

    const subReply = originalAuthor.getComments().addComment("subreply 3 for reply 2", slide, position, createdTime);
    subReply.setParentComment(secondReply);

    reviewer.getComments().addComment("comment 2", slide, position, createdTime);
    const separateComment = reviewer.getComments().addComment("comment 3", slide, position, createdTime);

    const separateReply = originalAuthor.getComments().addComment("reply 4 for comment 3", slide, position, createdTime);
    separateReply.setParentComment(separateComment);

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

    rootComment.remove();
    presentation.save("remove_comment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
* 當使用 [Comment.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/remove/) 方法刪除註解時，該註解的所有回覆亦會被刪除。
* 若 [Comment.setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/setparentcomment/) 造成循環引用，會拋出 [PptxEditException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxeditexception/)。
{{% /alert %}}

## **添加現代註解**

現代註解可以與投影片本身、特定圖形，或 AutoShape 內的文字區間相關聯。[CommentCollection.addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) 方法除了接受投影片與註解標記座標外，還接受一個 [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) 參數。

當將 `null` 傳入 shape 參數時，註解為投影片層級註解。其標記位置由提供的座標決定，但不會與特定圖形關聯，因此 [ModernComment.getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/) 會回傳 `null`。當提供 [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) 時，註解會錨定至該圖形。座標仍決定註解標記在投影片上的位置，而圖形關聯可透過 [ModernComment.getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/) 取得。

### **將現代註解錨定至圖形**

範例兩次呼叫 [addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addmoderncomment/)：一次傳入 `null` shape 以建立投影片層級註解，另一次傳入矩形作為錨點。讀取 [getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/) 時，投影片層級註解會回傳 `true`（null 檢查），而錨定的註解會回傳 `Revenue title`。兩則註解皆與簡報一起儲存。

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

### **將註解錨定至不同圖形類型**

任何繼承自 [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) 的投影片物件皆可作為圖形錨點。常見範例包括 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/)、[PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/)、[GroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/)、[Connector](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connector/)，以及類似圖表的 [GraphicalObject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobject/)。

範例使用 [addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) 為五種圖形類型各加入一則註解：AutoShape、圖片框、群組、連接線與圖表。圖片使用內嵌影像資料，無需外部影像檔。每則註解都有自己的標記位置，儲存的簡報保留所有五種圖形的關聯。

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

### **將註解錨定至文字並設定其狀態**

對於與 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) 相關的現代註解，[ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/) 與 [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionstart/) 取得該圖形文字框中選取文字的起始位置。[ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) 與 [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionlength/) 取得選取的長度。這兩個值共同將註解與 AutoShape 內特定文字區間關聯。

[ModernComment.getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/) 與 [ModernComment.setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setstatus/) 方法存取來自 [ModernCommentStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncommentstatus/) 列舉的值：

- `NotDefined` — 未定義特定的現代註解狀態。
- `Active` — 註解為啟用狀態。
- `Resolved` — 註解已解決。
- `Closed` — 註解已關閉。

範例將現代註解錨定至矩形文字中的「quarterly revenue」字詞。它先計算零基準的選取起始位置，傳入 [setTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionstart/)，再使用 [setTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionlength/) 設定選取的字元數。最後以 `Resolved` 呼叫 [setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setstatus/)，儲存並重新開啟簡報。四個主控台檢查皆應印出 `true`，確認圖形錨點、文字區間與狀態均被保留。

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
    comment.setStatus(java.newByte(aspose.slides.ModernCommentStatus.Resolved));

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

### **檢查現有的現代註解**

此範例需要一個包含現代註解的既有簡報，並印出它們的文字、狀態與錨點細節。檢查時，先判斷哪些註解是 [ModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/) 的實例，然後檢視 [ModernComment.getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/)、[ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/)、[ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/)、以及 [ModernComment.getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/)。`null` shape 表示投影片層級註解。若錨點為 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/)，文字選取方法會指示該圖形文字框中的相關區間。

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

## **刪除註解**

Aspose.Slides for Node.js via Java 允許您刪除簡報中所有註解與其作者，或刪除特定註解而保留其他註解。以下範例示範兩種作法，並儲存更新後的簡報。

### **刪除所有註解與註解作者**

此範例開啟既有簡報，對每位作者呼叫 [CommentCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/clear/)，然後呼叫 [CommentAuthorCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/clear/) 移除作者本身。儲存的簡報將不再含有任何註解或註解作者。請使用包含註解的簡報以觀察刪除效果。

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

### **刪除特定註解**

此範例在同一張投影片上建立兩則註解，並使用 [getSlideComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidecomments/) 取得每位作者的註解。它會收集文字等於「comment 1」的註解，然後呼叫 [CommentCollection.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/remove/)，避免在選取過程中修改集合。儲存的簡報僅保留「comment 2」。

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

**Aspose.Slides 是否支援現代註解的已解決狀態？**

是的。[ModernComment.getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/) 與 [ModernComment.setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setstatus/) 可以取得或設定 [ModernCommentStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncommentstatus/) 中的 `Resolved` 狀態。此狀態會寫入簡報，重新開啟檔案後仍可讀取。

**是否支援串接式討論（回覆鏈），且有深度限制嗎？**

支援。每則註解皆可參照其 [parent comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/getparentcomment/)，形成回覆鏈。API 未定義特定的巢狀深度上限。

**註解標記在投影片上的座標系統是什麼？**

標記位置以浮點座標表示，使用投影片的座標系統，讓您能精確定位於投影片上的任意位置。