---
title: Node.js でプレゼンテーションのコメントを管理する
linktitle: プレゼンテーション コメント
type: docs
weight: 100
url: /ja/nodejs-java/presentation-comments/
keywords:
- コメント
- モダンコメント
- PowerPoint コメント
- プレゼンテーション コメント
- スライド コメント
- コメントを追加する
- コメントにアクセスする
- コメントを編集する
- コメントへ返信する
- コメントを削除する
- コメントを削除する
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java を使用して、PowerPoint プレゼンテーションのコメントを管理します：コメントの追加、読み取り、編集、返信、および削除が可能です。"
---
## **概要**

この記事では、Aspose.Slides for Node.js via Java を使用してプレゼンテーションのコメントを管理する方法を説明します。主なコメント関連タイプを紹介し、スライドへのコメントの追加、既存コメントへのアクセス、返信やモダンコメントの操作、プレゼンテーションからのコメント削除をデモします。

例では、PowerPoint の一般的なレビューおよびコラボレーションシナリオ、たとえばコメントを作成者に割り当てる方法、コメントテキストやメタデータの読み取り、返信チェーンの構築、選択したコメントまたはすべてのコメントの削除などを扱います。

PowerPoint では、コメントはスライド上の注釈として表示されます。コメントを選択すると、そのテキストと関連するディスカッションが表示されます。

## **プレゼンテーションにコメントを追加する理由は？**

コメントを使用すると、プレゼンテーションのレビュー時にフィードバックを提供し、同僚と共同作業ができます。

Aspose.Slides for Node.js via Java は、コメント操作のために次の API を提供します。

* The [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) class, which provides access to the presentation's comment authors.
* The [CommentCollection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/commentcollection/) class, which represents the comments associated with an individual author.
* The [Comment](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/comment/) class, which provides information about a comment, including its author, creation time, position, and text.
* The [CommentAuthor](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/commentauthor/) class, which provides information about an author, including their name, initials, and associated comments.

## **スライドコメントの追加**

以下の例は、PowerPoint プレゼンテーションのスライドにコメントを追加する方法を示しています:

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

## **スライドコメントへのアクセス**

以下の例は、PowerPoint プレゼンテーション内の既存コメントにアクセスする方法を示しています:

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

## **コメントへの返信**

親コメントは返信階層のトップにある元のコメントです。[Comment.getParentComment](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/comment/getparentcomment/) および [Comment.setParentComment](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/comment/setparentcomment/) メソッドを使用すると、コメントの親を取得または設定できます。

以下の例は、返信を追加し、結果として得られるコメント階層を検査する方法を示しています:

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

{{% alert color="warning" title="警告" %}}
* [Comment.remove](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/comment/remove/) メソッドでコメントを削除すると、そのコメントへのすべての返信も削除されます。
* [Comment.setParentComment](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/comment/setparentcomment/) が循環参照を作成した場合、[PptxEditException](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pptxeditexception/) がスローされます。
{{% /alert %}}

## **モダンコメントの追加**

モダンコメントは、スライド自体、特定のシェイプ、または [AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/) 内のテキスト範囲に関連付けることができます。[CommentCollection.addModernComment](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) メソッドは、スライドとコメントマーカー座標に加えて [Shape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/) 引数を受け取ります。

`null` がシェイプ引数として渡された場合、コメントはスライドレベルのコメントとなります。マーカーは指定された座標で配置されますが、特定のシェイプに関連付けられないため、[ModernComment.getShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/moderncomment/getshape/) は `null` を返します。シェイプが指定された場合、コメントはそのシェイプにアンカリングされます。座標は依然としてスライド上のコメントマーカーの位置を定義し、シェイプとの関連は [ModernComment.getShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/moderncomment/getshape/) で取得できます。

### **モダンコメントをシェイプに固定**

以下の例は、スライドレベルのモダンコメントと、特定の [AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/) にアンカリングされたモダンコメントの両方を作成し、各コメントから関連シェイプを取得します。

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

### **異なるシェイプタイプへのコメントのアンカリング**

[Shape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/) を継承するスライドオブジェクトはすべてシェイプアンカーとして使用できます。一般的な例としては、[AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/)、[PictureFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pictureframe/)、[GroupShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/groupshape/)、[Connector](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/connector/)、およびグラフなどの [GraphicalObject](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/graphicalobject/) インスタンスが含まれます。

以下の例は、いくつかの一般的なシェイプタイプを作成し、それぞれにモダンコメントを関連付けます。

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

### **テキストへのコメントのアンカリングとステータス設定**

[AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/) に関連付けられたモダンコメントの場合、[ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/) と [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/moderncomment/settextselectionstart/) はシェイプのテキストフレーム内で選択されたテキストの開始位置にアクセスします。[ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) と [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/moderncomment/settextselectionlength/) は選択範囲の長さにアクセスします。これらの値を組み合わせることで、コメントを特定のテキスト範囲に関連付けます。

[ModernComment.getStatus](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/moderncomment/getstatus/) と [ModernComment.setStatus](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/moderncomment/setstatus/) メソッドは、[ModernCommentStatus](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/moderncommentstatus/) 列挙体の値にアクセスします。

- `NotDefined` — 特定のモダンコメントステータスは定義されていません。
- `Active` — コメントはアクティブです。
- `Resolved` — コメントは解決済みです。
- `Closed` — コメントはクローズされています。

以下の例は、シェイプにアンカリングされたモダンコメントを作成し、テキスト選択に関連付け、解決済みとしてマークし、プレゼンテーションを保存した後にファイルを再度開いて値を検証します。

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

### **既存のモダンコメントの検査**

既存のプレゼンテーションを検査するには、どのコメントが [ModernComment](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/moderncomment/) インスタンスであるかを確認し、[ModernComment.getShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/moderncomment/getshape/)、[ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/)、[ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/)、および [ModernComment.getStatus](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/moderncomment/getstatus/) を調べます。`null` シェイプはスライドレベルのコメントを示します。[AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/) にアンカリングされた場合、テキスト選択メソッドはシェイプのテキストフレーム内の対象範囲を特定します。

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

## **コメントの削除**

### **すべてのコメントとコメント作成者の削除**

以下の例は、プレゼンテーションからすべてのコメントとコメント作成者を削除する方法を示しています:

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

### **特定のコメントの削除**

以下の例は、スライドから特定のコメントを削除する方法を示しています:

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

## **FAQ**

**Aspose.Slidesはモダンコメントの解決済ステータスをサポートしていますか？**

はい。[ModernComment.getStatus](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/moderncomment/getstatus/) と [ModernComment.setStatus](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/moderncomment/setstatus/) は、`Resolved` を含む [ModernCommentStatus](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/moderncommentstatus/) の値にアクセスできます。このステータスはプレゼンテーションに保存され、ファイルを再度開いた後でも読み取れます。

**スレッド化されたディスカッション（返信チェーン）はサポートされていますか？また、ネストの上限はありますか？**

はい。各コメントは [parent comment](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/comment/getparentcomment/) を参照できるため、返信チェーンが可能です。API には特定のネスト深度の上限は定義されていません。

**スライド上のコメントマーカーの位置はどの座標系で定義されていますか？**

マーカーの位置はスライド座標系の浮動小数点座標で定義されており、スライド上の任意の場所に正確に配置できます。