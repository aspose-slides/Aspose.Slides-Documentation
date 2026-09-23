---
title: .NET でプレゼンテーションコメントを管理する
linktitle: プレゼンテーションコメント
type: docs
weight: 100
url: /ja/net/presentation-comments/
keywords:
- コメント
- モダンコメント
- PowerPoint コメント
- プレゼンテーションコメント
- スライドコメント
- コメントの追加
- コメントへのアクセス
- コメントの編集
- コメントへの返信
- コメントの削除
- コメントの除去
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用してプレゼンテーションコメントを管理します。PowerPoint プレゼンテーションのコメントを追加、読み取り、編集、返信、削除を迅速かつ簡単に行えます。"
---
## **概要**

本記事では、Aspose.Slides for .NET を使用してプレゼンテーションのコメントを管理する方法を説明します。主なコメント関連型を紹介し、スライドへのコメントの追加、既存コメントへのアクセス、返信やモダンコメントの操作、およびプレゼンテーションからのコメントの削除方法を示します。

例では、PowerPoint の一般的なレビューおよび共同作業シナリオ（コメントを作成者に割り当てる、コメントテキストやメタデータを読み取る、返信チェーンを構築する、選択したコメントまたはすべてのコメントを削除する）を取り上げています。

PowerPoint では、コメントはスライド上の注釈として表示されます。コメントを選択すると、そのテキストと関連するディスカッションが表示されます。

プレゼンテーションを開く際にコメントを表示または非表示にする（コメント自体は変更しない）場合は、[Show or Hide Comments When Opening a Presentation](/slides/ja/net/presentation-view-properties/) を参照してください。

## **なぜプレゼンテーションにコメントを追加するのか？**

プレゼンテーションのレビュー時に、コメントを使用してフィードバックを提供し、同僚と共同作業できます。

Aspose.Slides for .NET は、コメント操作のために以下の API を提供します。

* プレゼンテーションのコメント作成者へのアクセスを提供する [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) クラス。
* 個々の作成者に関連付けられたコメントを表す [ICommentCollection](https://reference.aspose.com/slides/ja/net/aspose.slides/icommentcollection) インターフェイス。
* コメントの作者、作成時刻、位置、テキストなどの情報を提供する [IComment](https://reference.aspose.com/slides/ja/net/aspose.slides/icomment) インターフェイス。
* 作成者の名前、イニシャル、関連コメントなどの情報を提供する [CommentAuthor](https://reference.aspose.com/slides/ja/net/aspose.slides/commentauthor) クラス。

## **スライドコメントの追加**
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

## **スライドコメントへのアクセス**
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
親コメントは、返信階層の最上位にある元のコメントです。 [IComment](https://reference.aspose.com/slides/ja/net/aspose.slides/icomment) インターフェイスの [ParentComment](https://reference.aspose.com/slides/ja/net/aspose.slides/icomment/properties/parentcomment) プロパティを使用して、コメントの親を取得または設定できます。

以下の例は、返信を追加し、結果として得られるコメント階層を検査する方法を示しています：

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
* IComment インターフェイスの [Remove](https://reference.aspose.com/slides/ja/net/aspose.slides/icomment/methods/remove) メソッドを使用してコメントを削除すると、そのコメントへのすべての返信も削除されます。
* [ParentComment] プロパティが循環参照を作成した場合、[PptxEditException](https://reference.aspose.com/slides/ja/net/aspose.slides/pptxeditexception) がスローされます。
{{% /alert %}}

## **モダンコメントの追加**

モダンコメントは、スライド自体、特定のシェイプ、または AutoShape 内のテキスト範囲に関連付けることができます。 [ICommentCollection.AddModernComment](https://reference.aspose.com/slides/ja/net/aspose.slides/icommentcollection/addmoderncomment/) メソッドは、スライドとコメントマーカーの座標に加えて [IShape](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/) 引数を受け取ります。

`null` がシェイプ引数として渡された場合、コメントはスライドレベルのコメントになります。マーカーは指定された座標で配置されますが、特定のシェイプには関連付けられないため、[IModernComment.Shape](https://reference.aspose.com/slides/ja/net/aspose.slides/imoderncomment/shape/) は `null` を返します。`IShape` が指定された場合、コメントはそのシェイプに固定されます。座標は引き続きスライド上のコメントマーカーの位置を定義し、シェイプの関連付けは [IModernComment.Shape](https://reference.aspose.com/slides/ja/net/aspose.slides/imoderncomment/shape/) で取得できます。

### **モダンコメントをシェイプに固定する**
以下の例は、スライドレベルのモダンコメントと、特定の AutoShape に固定されたモダンコメントの両方を作成し、各コメントから関連付けられたシェイプを取得します。

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

### **異なるシェイプタイプへのコメント固定**
[IShape] を実装するスライドオブジェクトは、シェイプのアンカーとして使用できます。一般的な例として、[IAutoShape]、[IPictureFrame]、[IGroupShape]、[IConnector]、およびチャートなどの [IGraphicalObject] インスタンスがあります。

以下の例は、いくつかの一般的なシェイプタイプを作成し、それぞれにモダンコメントを関連付けます。

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

### **テキストへのコメント固定とステータス設定**
[IAutoShape] に関連付けられたモダンコメントの場合、[IModernComment.TextSelectionStart](https://reference.aspose.com/slides/ja/net/aspose.slides/imoderncomment/textselectionstart/) はシェイプのテキストフレーム内で選択されたテキストの開始位置を示し、[IModernComment.TextSelectionLength](https://reference.aspose.com/slides/ja/net/aspose.slides/imoderncomment/textselectionlength/) は選択範囲の長さを示します。これらのプロパティを組み合わせることで、コメントは AutoShape 内の特定のテキスト範囲に関連付けられます。

[IModernComment.Status] プロパティは、[ModernCommentStatus] 列挙体の値で読み取りまたは設定できます。

- `NotDefined` — 特定のモダンコメントステータスは定義されていません。
- `Active` — コメントはアクティブです。
- `Resolved` — コメントは解決済みです。
- `Closed` — コメントはクローズされています。

以下の例は、シェイプに固定されたモダンコメントを作成し、テキスト選択に関連付け、解決済みとしてマークし、プレゼンテーションを保存し、ファイルを再度開いた後に値を検証します。

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

### **既存のモダンコメントの検査**
既存のプレゼンテーションを検査するには、どのコメントが [IModernComment] を実装しているかを確認し、[IModernComment.Shape]、[IModernComment.TextSelectionStart]、[IModernComment.TextSelectionLength]、および [IModernComment.Status] を調べます。`null` のシェイプはスライドレベルのコメントを示します。[IAutoShape] がアンカーの場合、テキスト選択プロパティはシェイプのテキストフレーム内の関連範囲を示します。

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

### **すべてのコメントとコメント作成者の削除**
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

### **特定のコメントの削除**
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

## **よくある質問**

**Aspose.Slides はモダンコメントの解決済みステータスをサポートしていますか？**
はい。[IModernComment.Status] は、`Resolved` を含む [ModernCommentStatus] の値で読み取りおよび設定できます。ステータスはプレゼンテーションに保存され、ファイルを再度開いた後でも読み取れます。

**スレッド化されたディスカッション（返信チェーン）はサポートされていますか？また、ネストの上限はありますか？**
はい。各コメントは [parent comment] を参照できるため、返信チェーンを構築できます。API には特定のネスト深さの上限は定義されていません。

**コメントマーカーの位置はスライド上のどの座標系で定義されていますか？**
マーカーの位置は、スライド座標系の浮動小数点座標で定義されており、スライド上の正確な位置に配置できます。