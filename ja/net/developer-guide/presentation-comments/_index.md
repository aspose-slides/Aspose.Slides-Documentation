---
title: .NETでプレゼンテーション コメントを管理する
linktitle: プレゼンテーション コメント
type: docs
weight: 100
url: /ja/net/presentation-comments/
keywords:
- コメント
- モダン コメント
- PowerPoint コメント
- プレゼンテーション コメント
- スライド コメント
- コメント 追加
- コメント アクセス
- コメント 編集
- コメント 返信
- コメント 削除
- コメント 削除
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用してプレゼンテーション コメントを管理します。PowerPoint プレゼンテーションでコメントの追加、読み取り、編集、返信、削除を迅速かつ簡単に行えます。"
---
## **概要**

このドキュメントでは、Aspose.Slides for .NET を使用したプレゼンテーション コメントの管理方法について説明します。主なコメント関連型を紹介し、スライドへのコメント追加、既存コメントへのアクセス、返信とモダン コメントの操作、プレゼンテーションからのコメント削除方法を実演します。

例では、PowerPoint の一般的なレビューおよびコラボレーション シナリオ（コメントの作成者割り当て、コメント本文とメタデータの取得、返信チェーンの構築、選択したコメントまたはすべてのコメントの削除）を扱います。

PowerPoint では、コメントはスライド上のアノテーションとして表示されます。コメントを選択すると、そのテキストと関連ディスカッションが表示されます。

## **プレゼンテーションにコメントを追加する目的は？**

プレゼンテーションのレビュー時に、同僚とフィードバックを共有し、共同作業を行う手段としてコメントを使用できます。

Aspose.Slides for .NET は、コメント操作のために以下の API を提供します。

* [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) クラスは、プレゼンテーションのコメント作成者へのアクセスを提供します。
* [ICommentCollection](https://reference.aspose.com/slides/ja/net/aspose.slides/icommentcollection) インターフェイスは、個々の作成者に関連付けられたコメントを表します。
* [IComment](https://reference.aspose.com/slides/ja/net/aspose.slides/icomment) インターフェイスは、作成者、作成時刻、位置、テキストなど、コメントに関する情報を提供します。
* [CommentAuthor](https://reference.aspose.com/slides/ja/net/aspose.slides/commentauthor) クラスは、名前、イニシャル、関連コメントなど、作成者に関する情報を提供します。

## **スライド コメントの追加**
以下の例は、PowerPoint プレゼンテーションのスライドにコメントを追加する方法を示しています。

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];
var secondSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var author = presentation.CommentAuthors.AddAuthor("Jawad", "MF");
var position = new PointF(0.2f, 0.2f);
var createdTime = DateTime.Now;

author.Comments.AddComment("Hello Jawad, this is a slide comment", firstSlide, position, createdTime);
author.Comments.AddComment("Hello Jawad, this is the second slide comment", secondSlide, position, createdTime);

var comments = firstSlide.GetSlideComments(author);
if (comments.Length > 0)
{
    var firstComment = comments[0];
    Console.WriteLine(firstComment.Text);

    var commentText = firstComment.Author.Comments[0].Text;
    Console.WriteLine(commentText);
}

presentation.Save("Comments_out.pptx", SaveFormat.Pptx);
```

## **スライド コメントへのアクセス**
以下の例は、PowerPoint プレゼンテーション内の既存コメントにアクセスする方法を示しています。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Comments1.pptx");

foreach (var author in presentation.CommentAuthors)
{
    foreach (var comment in author.Comments)
    {
        Console.WriteLine($"Slide: {comment.Slide.SlideNumber}");
        Console.WriteLine($"Comment: {comment.Text}");
        Console.WriteLine($"Author: {comment.Author.Name}");
        Console.WriteLine($"Posted at: {comment.CreatedTime}");
        Console.WriteLine();
    }
}
```

## **コメントへの返信**
親コメントは、返信階層のトップにある元のコメントです。[IComment](https://reference.aspose.com/slides/ja/net/aspose.slides/icomment) インターフェイスの [ParentComment](https://reference.aspose.com/slides/ja/net/aspose.slides/icomment/properties/parentcomment) プロパティを使用して、コメントの親を取得または設定できます。

以下の例は、返信を追加し、結果として得られるコメント階層を検査する方法を示しています。

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var position = new PointF(10, 10);
var createdTime = DateTime.Now;

var author1 = presentation.CommentAuthors.AddAuthor("Author_1", "A.A.");
var comment1 = author1.Comments.AddComment("comment 1", slide, position, createdTime);

var author2 = presentation.CommentAuthors.AddAuthor("Author_2", "B.B.");
var reply1 = author2.Comments.AddComment("reply 1 for comment 1", slide, position, createdTime);
reply1.ParentComment = comment1;

var reply2 = author2.Comments.AddComment("reply 2 for comment 1", slide, position, createdTime);
reply2.ParentComment = comment1;

var subReply = author1.Comments.AddComment("subreply 3 for reply 2", slide, position, createdTime);
subReply.ParentComment = reply2;

author2.Comments.AddComment("comment 2", slide, position, createdTime);
var comment3 = author2.Comments.AddComment("comment 3", slide, position, createdTime);

var reply3 = author1.Comments.AddComment("reply 4 for comment 3", slide, position, createdTime);
reply3.ParentComment = comment3;

var comments = slide.GetSlideComments(null);
for (var i = 0; i < comments.Length; i++)
{
    var comment = comments[i];
    while (comment.ParentComment != null)
    {
        Console.Write("\t");
        comment = comment.ParentComment;
    }

    Console.WriteLine($"{comments[i].Author.Name}: {comments[i].Text}");
}

presentation.Save("parent_comment.pptx", SaveFormat.Pptx);

comment1.Remove();
presentation.Save("remove_comment.pptx", SaveFormat.Pptx);
```

{{% alert color="warning" title="Attention" %}} 
* [IComment](https://reference.aspose.com/slides/ja/net/aspose.slides/icomment) インターフェイスの [Remove](https://reference.aspose.com/slides/ja/net/aspose.slides/icomment/methods/remove) メソッドでコメントを削除すると、そのコメントへのすべての返信も同時に削除されます。  
* [ParentComment](https://reference.aspose.com/slides/ja/net/aspose.slides/icomment/properties/parentcomment) プロパティで循環参照が作成されると、[PptxEditException](https://reference.aspose.com/slides/ja/net/aspose.slides/pptxeditexception) がスローされます。  
{{% /alert %}}

## **モダン コメントの追加**

モダン コメントは、スライド全体、特定のシェイプ、または AutoShape 内のテキスト範囲に関連付けることができます。[ICommentCollection.AddModernComment](https://reference.aspose.com/slides/ja/net/aspose.slides/icommentcollection/addmoderncomment/) メソッドは、スライドとコメントマーカー座標に加えて、[IShape](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/) 引数も受け取ります。

`null` がシェイプ引数として渡された場合、コメントはスライド レベルのコメントとなります。マーカーは指定された座標で配置されますが、特定のシェイプには紐付いていないため、[IModernComment.Shape](https://reference.aspose.com/slides/ja/net/aspose.slides/imoderncomment/shape/) は `null` を返します。シェイプが指定された場合、コメントはそのシェイプに固定されます。座標は依然としてスライド上のマーカー位置を定義し、シェイプの関連付けは [IModernComment.Shape](https://reference.aspose.com/slides/ja/net/aspose.slides/imoderncomment/shape/) から取得できます。

### **シェイプにモダン コメントを固定する**

以下の例は、スライド レベルのモダン コメントと、特定の AutoShape に固定されたモダン コメントの両方を作成し、それぞれのコメントから関連シェイプを取得します。

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var author = presentation.CommentAuthors.AddAuthor("Reviewer", "RV");
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 300, 80);
shape.Name = "Revenue title";
shape.TextFrame.Text = "Quarterly revenue";

var createdTime = DateTime.Now;
var slideCommentPosition = new PointF(20, 20);
var shapeCommentPosition = new PointF(60, 60);
var slideComment = author.Comments.AddModernComment("Review the overall slide layout.", slide, null, slideCommentPosition, createdTime);
var shapeComment = author.Comments.AddModernComment("Check this title.", slide, shape, shapeCommentPosition, createdTime);

Console.WriteLine(slideComment.Shape == null);
Console.WriteLine(shapeComment.Shape?.Name);

presentation.Save("modern_comments.pptx", SaveFormat.Pptx);
```

### **異なるシェイプ型へのコメント固定**

[IShape](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/) を実装するスライド オブジェクトはすべて、シェイプ アンカーとして使用できます。代表的な例として、[IAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/)、[IPictureFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/ipictureframe/)、[IGroupShape](https://reference.aspose.com/slides/ja/net/aspose.slides/igroupshape/)、[IConnector](https://reference.aspose.com/slides/ja/net/aspose.slides/iconnector/)、およびチャートなどの [IGraphicalObject](https://reference.aspose.com/slides/ja/net/aspose.slides/igraphicalobject/) インスタンスがあります。

以下の例は、複数の一般的なシェイプ型を作成し、それぞれにモダン コメントを関連付けます。

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var author = presentation.CommentAuthors.AddAuthor("Reviewer", "RV");
var createdTime = DateTime.Now;

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 180, 60);
autoShape.TextFrame.Text = "AutoShape";
var autoShapeCommentPosition = new PointF(30, 30);
author.Comments.AddModernComment("Comment on an AutoShape.", slide, autoShape, autoShapeCommentPosition, createdTime);

var imageBase64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
var imageData = Convert.FromBase64String(imageBase64);
var image = presentation.Images.AddImage(imageData);
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 220, 20, 120, 80, image);
var pictureCommentPosition = new PointF(230, 30);
author.Comments.AddModernComment("Comment on a picture.", slide, pictureFrame, pictureCommentPosition, createdTime);

var groupShape = slide.Shapes.AddGroupShape();
groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 80, 40);
groupShape.Shapes.AddAutoShape(ShapeType.Ellipse, 100, 0, 80, 40);
var groupCommentPosition = new PointF(40, 150);
author.Comments.AddModernComment("Comment on a group.", slide, groupShape, groupCommentPosition, createdTime);

var connector = slide.Shapes.AddConnector(ShapeType.StraightConnector1, 220, 150, 140, 40);
var connectorCommentPosition = new PointF(240, 150);
author.Comments.AddModernComment("Comment on a connector.", slide, connector, connectorCommentPosition, createdTime);

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 400, 20, 250, 180);
var chartCommentPosition = new PointF(420, 40);
author.Comments.AddModernComment("Comment on a graphical object.", slide, chart, chartCommentPosition, createdTime);

presentation.Save("modern_comment_shape_types.pptx", SaveFormat.Pptx);
```

### **テキストにコメントを固定しステータスを設定する**

[IAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/) に関連付けられたモダン コメントでは、[IModernComment.TextSelectionStart](https://reference.aspose.com/slides/ja/net/aspose.slides/imoderncomment/textselectionstart/) がシェイプのテキスト フレーム内で選択されたテキストの開始位置を、[IModernComment.TextSelectionLength](https://reference.aspose.com/slides/ja/net/aspose.slides/imoderncomment/textselectionlength/) が選択範囲の長さを指定します。これらのプロパティにより、コメントは AutoShape 内の特定のテキスト範囲に結び付けられます。

[IModernComment.Status](https://reference.aspose.com/slides/ja/net/aspose.slides/imoderncomment/status/) プロパティは、[ModernCommentStatus](https://reference.aspose.com/slides/ja/net/aspose.slides/moderncommentstatus/) 列挙体の値で読み取り・更新できます。

- `NotDefined` — 特定のモダン コメントステータスが未定義です。  
- `Active` — コメントはアクティブです。  
- `Resolved` — コメントは解決済みです。  
- `Closed` — コメントは閉じられています。  

以下の例は、シェイプに固定されたモダン コメントを作成し、テキスト選択に関連付け、ステータスを「Resolved」に設定し、プレゼンテーションを保存した後に再度開いて値を検証します。

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const string outputFile = "modern_comment_text_anchor.pptx";
const string shapeText = "Review the quarterly revenue forecast.";
const string selectedText = "quarterly revenue";
var expectedSelectionStart = shapeText.IndexOf(selectedText, StringComparison.Ordinal);

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.Name = "Forecast text";
shape.TextFrame.Text = shapeText;

var author = presentation.CommentAuthors.AddAuthor("Reviewer", "RV");
var commentPosition = new PointF(60, 60);
var comment = author.Comments.AddModernComment("Verify this forecast wording.", slide, shape, commentPosition, DateTime.Now);
comment.TextSelectionStart = expectedSelectionStart;
comment.TextSelectionLength = selectedText.Length;
comment.Status = ModernCommentStatus.Resolved;

presentation.Save(outputFile, SaveFormat.Pptx);

using var reopenedPresentation = new Presentation(outputFile);
var reopenedSlide = reopenedPresentation.Slides[0];
var reopenedComments = reopenedSlide.GetSlideComments(null);

foreach (var reopenedComment in reopenedComments)
{
    if (reopenedComment is not IModernComment modernComment)
    {
        continue;
    }

    var shapeMatches = modernComment.Shape?.Name == "Forecast text";
    var selectionStartMatches = modernComment.TextSelectionStart == expectedSelectionStart;
    var selectionLengthMatches = modernComment.TextSelectionLength == selectedText.Length;
    var statusMatches = modernComment.Status == ModernCommentStatus.Resolved;

    Console.WriteLine($"Shape anchor preserved: {shapeMatches}");
    Console.WriteLine($"Text selection start preserved: {selectionStartMatches}");
    Console.WriteLine($"Text selection length preserved: {selectionLengthMatches}");
    Console.WriteLine($"Resolved status preserved: {statusMatches}");
}
```

### **既存のモダン コメントを検査する**

既存のプレゼンテーションを検査する際は、[IModernComment](https://reference.aspose.com/slides/ja/net/aspose.slides/imoderncomment/) を実装しているコメントを確認し、[IModernComment.Shape](https://reference.aspose.com/slides/ja/net/aspose.slides/imoderncomment/shape/)、[IModernComment.TextSelectionStart](https://reference.aspose.com/slides/ja/net/aspose.slides/imoderncomment/textselectionstart/)、[IModernComment.TextSelectionLength](https://reference.aspose.com/slides/ja/net/aspose.slides/imoderncomment/textselectionlength/)、[IModernComment.Status](https://reference.aspose.com/slides/ja/net/aspose.slides/imoderncomment/status/) を調べます。`null` のシェイプはスライド レベルのコメントを示します。[IAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/) がアンカーの場合、テキスト選択プロパティはシェイプのテキスト フレーム内の対象範囲を示します。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("comments.pptx");

foreach (var slide in presentation.Slides)
{
    var comments = slide.GetSlideComments(null);
    foreach (var comment in comments)
    {
        if (comment is not IModernComment modernComment)
        {
            continue;
        }

        Console.WriteLine($"Slide: {slide.SlideNumber}");
        Console.WriteLine($"Text: {modernComment.Text}");
        Console.WriteLine($"Status: {modernComment.Status}");

        var shape = modernComment.Shape;
        if (shape == null)
        {
            Console.WriteLine("Anchor: slide level");
        }
        else
        {
            Console.WriteLine($"Anchor shape: {shape.Name}");
            Console.WriteLine($"Anchor type: {shape.GetType().Name}");

            if (shape is IAutoShape)
            {
                Console.WriteLine($"Text selection start: {modernComment.TextSelectionStart}");
                Console.WriteLine($"Text selection length: {modernComment.TextSelectionLength}");
            }
        }

        Console.WriteLine();
    }
}
```

## **コメントの削除**

### **すべてのコメントとコメント作成者を削除する**

以下の例は、プレゼンテーションからすべてのコメントとコメント作成者を削除する方法を示しています。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("example.pptx");

foreach (var author in presentation.CommentAuthors)
{
    author.Comments.Clear();
}

presentation.CommentAuthors.Clear();
presentation.Save("example_out.pptx", SaveFormat.Pptx);
```

### **特定のコメントを削除する**

以下の例は、スライドから特定のコメントを削除する方法を示しています。

```csharp
using System;
using System.Collections.Generic;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var author = presentation.CommentAuthors.AddAuthor("Author", "A");
var createdTime = DateTime.Now;

var firstCommentPosition = new PointF(0.2f, 0.2f);
var secondCommentPosition = new PointF(0.3f, 0.2f);
author.Comments.AddComment("comment 1", slide, firstCommentPosition, createdTime);
author.Comments.AddComment("comment 2", slide, secondCommentPosition, createdTime);

foreach (var commentAuthor in presentation.CommentAuthors)
{
    var commentsToRemove = new List<IComment>();
    var comments = slide.GetSlideComments(commentAuthor);

    foreach (var comment in comments)
    {
        if (comment.Text == "comment 1")
        {
            commentsToRemove.Add(comment);
        }
    }

    foreach (var comment in commentsToRemove)
    {
        commentAuthor.Comments.Remove(comment);
    }
}

presentation.Save("pres.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Aspose.Slides はモダン コメントの「Resolved」ステータスをサポートしていますか？**

はい。[IModernComment.Status](https://reference.aspose.com/slides/ja/net/aspose.slides/imoderncomment/status/) は、[ModernCommentStatus](https://reference.aspose.com/slides/ja/net/aspose.slides/moderncommentstatus/) の値で読み取りおよび設定でき、`Resolved` も含まれます。ステータスはプレゼンテーションに保存され、ファイルを再度開いた後でも読み取れます。

**スレッド化されたディスカッション（返信チェーン）はサポートされていますか？また、入れ子の制限はありますか？**

はい。各コメントはその **parent comment** を参照できるため、返信チェーンを実現できます。API では特定の入れ子深度の上限は定義されていません。

**コメントマーカーの位置はどの座標系で定義されていますか？**

マーカーの位置は、スライド座標系の浮動小数点数座標で定義されます。これにより、スライド上の任意の場所に正確に配置できます。