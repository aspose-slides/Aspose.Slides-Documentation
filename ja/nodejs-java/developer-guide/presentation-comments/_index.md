---
title: Node.js でプレゼンテーション コメントを管理
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
- コメントの追加
- コメントへのアクセス
- コメントの編集
- コメントへの返信
- コメントの削除
- コメントの削除
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java を使用してプレゼンテーション コメントを管理します：PowerPoint プレゼンテーション内のコメントを追加、読み取り、編集、返信、削除します。"
---
## **概要**

この記事では、Aspose.Slides for Node.js via Java を使用してプレゼンテーションのコメントを管理する方法を説明します。コメントに関連する主要な型を紹介し、スライドへのコメントの追加、既存のコメントへのアクセス、返信やモダンコメントの操作、プレゼンテーションからのコメントの削除を実演します。

例では、PowerPoint の一般的なレビューおよび共同作業シナリオ、たとえばコメントを作成者に割り当てる方法、コメントテキストとメタデータの取得、返信チェーンの構築、選択したコメントまたはすべてのコメントの削除などを取り上げています。

PowerPoint では、コメントはスライド上の注釈として表示されます。コメントを選択すると、そのテキストと関連するディスカッションが表示されます。

プレゼンテーションを開くときにコメントを表示または非表示にする方法については、[Show or Hide Comments When Opening a Presentation](/slides/ja/nodejs-java/presentation-view-properties/) を参照してください。

## **なぜプレゼンテーションにコメントを追加するのか？**

プレゼンテーションのレビュー時にフィードバックを提供し、同僚と共同作業するためにコメントを使用できます。

Aspose.Slides for Node.js via Java は、コメント操作のために次の API を提供します。

* **[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)** クラスは、プレゼンテーションのコメント作成者へのアクセスを提供します。
* **[CommentCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/)** クラスは、個々の作成者に関連付けられたコメントを表します。
* **[Comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/)** クラスは、作成者、作成時刻、位置、テキストなど、コメントに関する情報を提供します。
* **[CommentAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthor/)** クラスは、名前、イニシャル、および関連付けられたコメントを含む作成者に関する情報を提供します。

## **スライドコメントの追加**

この例は 2 つのスライドを作成し、**[addAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/addauthor/)** でコメント作成者を登録します。**[addComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addcomment/)** を使用して各スライドに 1 つずつコメントを配置し、**[getSlideComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidecomments/)** でその作成者の最初のスライドのコメントを取得します。コンソールは最初のコメントのテキストを 2 回表示し、スライドと作成者の両方からのアクセスを示し、保存されたプレゼンテーションには両方のコメントが含まれます。

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

## **コメント作成者の検索または作成**

自動レビューが同じプレゼンテーションを繰り返し処理する場合、作成者を追加する前に **[getCommentAuthors](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getcommentauthors/)** が返すコレクションを検索します。**[findByNameAndInitials](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/findbynameandinitials/)** は名前とイニシャルの両方を一致させ、該当する作成者の配列を返します。該当がない場合は空の配列が返ります。これに対し、**[findByName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/findbyname/)** はイニシャルに関係なく名前だけで検索します。**[addAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/addauthor/)** に既にコレクションに存在する名前とイニシャルを指定すると例外がスローされます。

この例は、少なくとも 1 つのスライドを含むプレゼンテーション ファイルが必要です。2 回のパスそれぞれで、最初に一致した作成者を再利用するか、結果が空の場合にのみ新規作成します。複数の一致がある場合は、他の作成者をマージまたは削除せずに最初の配列要素を選択します。その後、選択した作成者に対して **[addComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addcomment/)** を呼び出し、プレゼンテーションを保存します。2 回目のパスは 1 回目の出力を開き、同じ操作を繰り返します。

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

2 回目のパスは別の作成者を追加せず、既存のコメントを削除せずに別のコメントを追加します。最終ファイル `review_pass_2.pptx` には、元のコメントとともに新しいコメントが両方含まれます。作成者を再利用してもコメントは重複除去されません。同じコメントを繰り返し追加しないようにするには、追加前に別途重複検出を実装してください。

## **スライドコメントへのアクセス**

この例は既存のプレゼンテーションを開き、**[getCommentAuthors](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getcommentauthors/)** が返すコレクションを取得します。各作成者について、**[getComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthor/getcomments/)** が返すコレクションを反復処理し、スライド番号、コメントテキスト、作成者名、作成時刻を出力します。入力プレゼンテーションにはコンソール出力を生成するためのコメントが含まれている必要があります。

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

親コメントは返信階層の最上位にある元のコメントです。**[Comment.getParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/getparentcomment/)** と **[Comment.setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/setparentcomment/)** メソッドでコメントの親を取得または設定できます。

この例は 2 人の作成者からコメントを作成し、**[setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/setparentcomment/)** を使用して返信を構築します。別の返信への返信も含まれます。`null` を **[getSlideComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidecomments/)** に渡すと、すべての作成者からコメントが取得されます。コンソールは返信階層の深さに応じて各エントリをインデント表示します。例は完全なディスカッションを保存し、最初のルートコメントに対して **[remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/remove/)** を呼び出して、そのコメントと返信を削除した 2 番目のプレゼンテーションを保存します。

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
* **[Comment.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/remove/)** メソッドでコメントを削除すると、そのコメントへのすべての返信も削除されます。
* **[Comment.setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/setparentcomment/)** が循環参照を作成すると、**[PptxEditException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxeditexception/)** がスローされます。
{{% /alert %}}

## **モダンコメントの追加**

モダンコメントはスライド自体、特定のシェイプ、または AutoShape 内のテキスト範囲に関連付けることができます。**[CommentCollection.addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addmoderncomment/)** メソッドは、スライドとコメントマーカー座標に加えて **[Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/)** 引数を受け取ります。

`null` をシェイプ引数に渡すと、コメントはスライドレベルのコメントとなります。そのマーカーは指定された座標で配置されますが、特定のシェイプには関連付けられません。そのため **[ModernComment.getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/)** は `null` を返します。**[Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/)** が提供されると、コメントはそのシェイプにアンカリングされます。座標は依然としてスライド上のコメントマーカー位置を定義し、シェイプの関連付けは **[ModernComment.getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/)** で取得できます。

### **モダンコメントをシェイプにアンカリングする**

この例は **[addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addmoderncomment/)** を 2 回呼び出します。1 回目はスライドレベルコメント用に `null` シェイプを渡し、2 回目は矩形をアンカーとして渡します。**[getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/)** を読み取ると、スライドレベルコメントの `null` チェックで `true` が出力され、アンカリングされたコメントでは `Revenue title` が出力されます。両方のコメントはプレゼンテーションに保存されます。

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

**[Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/)** から派生したスライドオブジェクトはすべてシェイプアンカーとして使用できます。一般的な例として **[AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/)**、**[PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/)**、**[GroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/)**、**[Connector](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connector/)**、およびチャートなどの **[GraphicalObject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobject/)** インスタンスがあります。

この例は **[addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addmoderncomment/)** を使用し、5 種類のシェイプ（AutoShape、PictureFrame、GroupShape、Connector、Chart）それぞれにコメントを関連付けます。画像は埋め込み画像データを使用するため、外部画像は不要です。各コメントは独自のマーカー位置を持ち、保存されたプレゼンテーションは 5 つのシェイプ関連付けをすべて保持します。

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

### **テキストへのアンカリングとステータス設定**

**[AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/)** に関連付けられたモダンコメントの場合、**[ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/)** と **[ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionstart/)** でシェイプのテキストフレーム内で選択されたテキストの開始位置にアクセスします。**[ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/)** と **[ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionlength/)** で選択の長さにアクセスします。これらの値を組み合わせて、コメントを AutoShape 内の特定のテキスト範囲に関連付けます。

**[ModernComment.getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/)** と **[ModernComment.setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setstatus/)** メソッドは **[ModernCommentStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncommentstatus/)** 列挙型の値にアクセスします。

- `NotDefined` — 特定のモダンコメントステータスは定義されていません。
- `Active` — コメントはアクティブです。
- `Resolved` — コメントは解決済みです。
- `Closed` — コメントはクローズされています。

この例は矩形のテキスト中の「quarterly revenue」という語句にモダンコメントをアンカリングします。テキストからゼロベースの選択開始位置を計算し、**[setTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionstart/)** に渡し、**[setTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionlength/)** で選択文字数を設定します。`Resolved` を指定して **[setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setstatus/)** を呼び出した後、プレゼンテーションを保存および再オープンします。4 つのコンソールチェックはすべて `true` を出力し、シェイプアンカー、テキスト範囲、ステータスが保持されていることを確認します。

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

### **既存のモダンコメントの検査**

この例はモダンコメントを含む既存のプレゼンテーションを必要とし、コメントのテキスト、ステータス、アンカーの詳細を出力します。検査するには、コメントが **[ModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/)** のインスタンスかどうかを確認し、続いて **[ModernComment.getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/)**、**[ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/)**、**[ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/)**、**[ModernComment.getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/)** を調べます。`null` のシェイプはスライドレベルのコメントを示します。**[AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/)** がアンカーの場合、テキスト選択メソッドはシェイプのテキストフレーム内の関連範囲を特定します。

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

Aspose.Slides for Node.js via Java を使用すると、プレゼンテーションからすべてのコメントとその作成者を削除したり、コメントの一部だけを削除して残りを保持したりできます。以下の例は両方のアプローチを示し、更新されたプレゼンテーションを保存します。

### **すべてのコメントとコメント作成者の削除**

この例は既存のプレゼンテーションを開き、各作成者に対して **[CommentCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/clear/)** を呼び出し、続いて **[CommentAuthorCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/clear/)** で作成者自体を削除します。保存されたプレゼンテーションにはコメントもコメント作成者も含まれません。コメントを含むプレゼンテーションで削除を確認してください。

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

この例は 1 つのスライドに 2 つのコメントを作成し、**[getSlideComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidecomments/)** を使用して各作成者のコメントを取得します。テキストが「comment 1」に等しいコメントを収集し、**[CommentCollection.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/remove/)** を呼び出して削除します。これによりコレクションの変更を回避します。保存されたプレゼンテーションには「comment 2」のみが残ります。

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

**Aspose.Slides はモダンコメントの解決済みステータスをサポートしていますか？**

はい。**[ModernComment.getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/)** と **[ModernComment.setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setstatus/)** は **[ModernCommentStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncommentstatus/)** の値にアクセスでき、`Resolved` も含まれます。このステータスはプレゼンテーションに保存され、ファイルを再度開いた後でも読み取れます。

**スレッド化されたディスカッション（返信チェーン）はサポートされていますか？ ネストの上限はありますか？**

はい。各コメントは **[parent comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/getparentcomment/)** を参照でき、返信チェーンを実現します。API では特定のネスト深度上限は定義されていません。

**コメントマーカーの位置はスライドのどの座標系で定義されていますか？**

マーカー位置はスライド座標系の浮動小数点座標で定義され、スライド上の任意の位置に正確に配置できます。