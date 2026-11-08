---
title: Manage Presentation Comments in .NET
linktitle: Presentation Comments
type: docs
weight: 100
url: /net/presentation-comments/
keywords:
- comment
- modern comment
- PowerPoint comments
- presentation comments
- slide comments
- add comment
- access comment
- edit comment
- reply comment
- remove comment
- delete comment
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Manage presentation comments with Aspose.Slides for .NET: add, read, edit, reply to, and remove comments in PowerPoint presentations quickly and easily."
---

## **Overview**

This article explains how to manage presentation comments with Aspose.Slides for .NET. It introduces the main comment-related types and demonstrates how to add comments to slides, access existing comments, work with replies and modern comments, and remove comments from a presentation.

The examples cover common review and collaboration scenarios in PowerPoint, such as assigning comments to authors, reading comment text and metadata, building reply chains, and removing selected comments or all comments.

In PowerPoint, comments appear as annotations on slides. Selecting a comment displays its text and related discussion.

To request that comments be shown or hidden when a presentation opens without changing the comments themselves, see [Show or Hide Comments When Opening a Presentation](/slides/net/presentation-view-properties/).

## **Why Add Comments to Presentations?**

You can use comments to provide feedback and collaborate with colleagues when reviewing presentations.

Aspose.Slides for .NET provides the following APIs for working with comments:

* The [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class, which provides access to the presentation's comment authors.
* The [ICommentCollection](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection) interface, which represents the comments associated with an individual author.
* The [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) interface, which provides information about a comment, including its author, creation time, position, and text.
* The [CommentAuthor](https://reference.aspose.com/slides/net/aspose.slides/commentauthor) class, which provides information about an author, including their name, initials, and associated comments.

## **Add Slide Comments**

The example creates two slides and registers a comment author with [AddAuthor](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/addauthor/). It uses [AddComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addcomment/) to place one comment on each slide, then retrieves the first slide's comments for that author with [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/). The console displays the first comment's text twice, demonstrating access through both the slide and the author, and the saved presentation contains both comments.

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

## **Find or Create a Comment Author**

When an automated review processes the same presentation repeatedly, search its [CommentAuthors](https://reference.aspose.com/slides/net/aspose.slides/presentation/commentauthors/) collection before adding an author. [FindByNameAndInitials](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/findbynameandinitials/) matches both the name and initials and returns an array of matching authors, or an empty array if no matches exist. In contrast, [FindByName](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/findbyname/) searches by name alone, regardless of initials. Calling [AddAuthor](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/addauthor/) with a name and initials already present in the collection throws an exception.

The example requires a presentation file with at least one slide. On each of two passes, it reuses the first matching author, or creates one only when the result is empty. If there are multiple matches, it selects the first array element without merging or removing the other authors. It then calls [AddComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addcomment/) for the selected author and saves the presentation. The second pass opens the first pass's output and repeats the operation.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const string authorName = "Reviewer";
const string authorInitials = "RV";

var inputFile = "input.pptx";
var position = new PointF(20, 20);

for (var pass = 1; pass <= 2; pass++)
{
    using var presentation = new Presentation(inputFile);

    var matches = presentation.CommentAuthors.FindByNameAndInitials(authorName, authorInitials);
    
    var author = matches.Length > 0 ? matches[0] : presentation.CommentAuthors.AddAuthor(authorName, authorInitials);
    author.Comments.AddComment("Please review this slide.", presentation.Slides[0], position, DateTime.Now);

    var outputFile = $"review_pass_{pass}.pptx";
    presentation.Save(outputFile, SaveFormat.Pptx);
    inputFile = outputFile;
}
```

The second pass adds another comment without adding another author or removing existing comments. The final file, `review_pass_2.pptx`, contains both new comments alongside any original comments. Reusing an author does not deduplicate comments: to avoid repeatedly adding the same comment, implement separate duplicate detection before adding it.

## **Access Slide Comments**

The example opens an existing presentation and reads its [CommentAuthors](https://reference.aspose.com/slides/net/aspose.slides/presentation/commentauthors/) collection. For each author, it iterates through [Comments](https://reference.aspose.com/slides/net/aspose.slides/icommentauthor/comments/) and prints the slide number, comment text, author name, and creation time. The input presentation must contain comments to produce console output.

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

## **Reply to Comments**

A parent comment is the original comment at the top of a reply hierarchy. The [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) property of the [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) interface lets you get or set the parent of a comment.

The example creates comments from two authors and uses [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) to build replies, including a reply to another reply. Passing `null` to [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/) retrieves comments from all authors; the console indents each entry according to its depth in the reply hierarchy. The example saves the complete discussion, calls [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/remove/) on the first root comment, and saves a second presentation with that comment and its replies removed.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var position = new PointF(10, 10);
var createdTime = DateTime.Now;

var originalAuthor = presentation.CommentAuthors.AddAuthor("Author_1", "A.A.");
var rootComment = originalAuthor.Comments.AddComment("comment 1", slide, position, createdTime);

var reviewer = presentation.CommentAuthors.AddAuthor("Author_2", "B.B.");
var firstReply = reviewer.Comments.AddComment("reply 1 for comment 1", slide, position, createdTime);
firstReply.ParentComment = rootComment;

var secondReply = reviewer.Comments.AddComment("reply 2 for comment 1", slide, position, createdTime);
secondReply.ParentComment = rootComment;

var subReply = originalAuthor.Comments.AddComment("subreply 3 for reply 2", slide, position, createdTime);
subReply.ParentComment = secondReply;

reviewer.Comments.AddComment("comment 2", slide, position, createdTime);
var separateComment = reviewer.Comments.AddComment("comment 3", slide, position, createdTime);

var separateReply = originalAuthor.Comments.AddComment("reply 4 for comment 3", slide, position, createdTime);
separateReply.ParentComment = separateComment;

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

rootComment.Remove();
presentation.Save("remove_comment.pptx", SaveFormat.Pptx);
```

{{% alert color="warning" title="Warning" %}}

* When the [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/remove/) method of the [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) interface is used to delete a comment, all replies to that comment are also deleted.
* If the [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) property creates a circular reference, a [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception) is thrown.

{{% /alert %}}

## **Add Modern Comments**

Modern comments can be associated with the slide itself, with a specific shape, or with a text range inside an AutoShape. The [ICommentCollection.AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) method accepts an [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) argument in addition to the slide and comment-marker coordinates.

When `null` is passed for the shape argument, the comment is a slide-level comment. Its marker is positioned by the supplied coordinates, but it is not associated with a particular shape, so [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/) returns `null`. When an [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) is supplied, the comment is anchored to that shape. The coordinates still define the position of the comment marker on the slide, while the shape association can be retrieved through [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/).

### **Anchor a Modern Comment to a Shape**

The example calls [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) twice: once with a `null` shape for a slide-level comment and once with a rectangle as the anchor. Reading [Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/) prints `True` for the slide-level comment's null check and `Revenue title` for the anchored comment. Both comments are saved with the presentation.

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

### **Anchor Comments to Different Shape Types**

Any slide object that implements [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) can be used as a shape anchor. Common examples include [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/net/aspose.slides/iconnector/), and [IGraphicalObject](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobject/) instances such as charts.

The example uses [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) to associate a comment with each of five shape types: an AutoShape, a picture frame, a group, a connector, and a chart. The picture uses embedded image data, so no external image is required. Each comment has its own marker position, and the saved presentation retains all five shape associations.

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

### **Anchor a Comment to Text and Set Its Status**

For a modern comment associated with an [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/), [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/) specifies the starting position of the selected text in the shape's text frame, while [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) specifies the length of the selection. Together, these properties associate the comment with a specific text range inside the AutoShape.

The [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) property can be read or updated with a value from the [ModernCommentStatus](https://reference.aspose.com/slides/net/aspose.slides/moderncommentstatus/) enumeration:

- `NotDefined` — no specific modern-comment status is defined.
- `Active` — the comment is active.
- `Resolved` — the comment has been resolved.
- `Closed` — the comment is closed.

The example anchors a modern comment to the words "quarterly revenue" in a rectangle's text. It calculates the zero-based [TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/) from the text and sets [TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) to the number of selected characters. After setting [Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) to `Resolved`, it saves and reopens the presentation. The four console checks should each print `True`, confirming that the shape anchor, text range, and status were preserved.

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


<!-- visual-explanation:presentation-comments:start -->
[![The phrase quarterly revenue is highlighted inside Forecast text; stored start 11, length 17 and Resolved status are listed separately from marker coordinates (60, 60).](visual-presentation-comments-94241d308643.svg)](visual-presentation-comments-94241d308643.svg)

*Schematic annotation of the example’s text range. A licensed .NET 26.11 save/reopen check retained the Forecast text anchor, start 11, length 17 and Resolved status. Marker coordinates are separate from the anchor; this figure does not depict a client comment pane.*
<!-- visual-explanation:presentation-comments:end -->

### **Inspect Existing Modern Comments**

The example requires an existing presentation containing modern comments and prints their text, status, and anchor details. To inspect it, check which comments implement [IModernComment](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/), then examine [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/), [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/), [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/), and [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/). A `null` shape indicates a slide-level comment. For an [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) anchor, the text-selection properties identify the associated range in the shape's text frame.

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

## **Remove Comments**

Aspose.Slides for .NET lets you remove all comments and their authors from a presentation or delete selected comments while keeping the rest. The following examples demonstrate both approaches and save the updated presentation.

### **Remove All Comments and Comment Authors**

The example opens an existing presentation and calls [ICommentCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/clear/) for each author, then calls [ICommentAuthorCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/clear/) to remove the authors themselves. The saved presentation contains neither comments nor comment authors. Use a presentation containing comments to observe the removal.

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

### **Remove Specific Comments**

The example creates two comments on one slide and uses [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/) to find comments by each author. It collects comments whose text equals "comment 1" before calling [ICommentCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/remove/), avoiding changes to the collection during selection. The saved presentation retains only "comment 2".

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

**Does Aspose.Slides support a resolved status for modern comments?**

Yes. [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) can be read and set with a [ModernCommentStatus](https://reference.aspose.com/slides/net/aspose.slides/moderncommentstatus/) value, including `Resolved`. The status is stored in the presentation and can be read again after the file is reopened.

**Are threaded discussions (reply chains) supported, and is there a nesting limit?**

Yes. Each comment can reference its [parent comment](https://reference.aspose.com/slides/net/aspose.slides/comment/parentcomment/), enabling reply chains. The API does not define a specific nesting-depth limit.

**In what coordinate system is a comment marker's position defined on a slide?**

The marker position is defined by floating-point coordinates in the slide coordinate system, allowing you to place it precisely on the slide.
