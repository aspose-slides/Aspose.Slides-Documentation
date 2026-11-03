---
title: Comment
type: docs
weight: 230
url: /net/examples/elements/comment/
keywords:
- comment
- modern comment
- add comment
- access comment
- remove comment
- reply to comment
- code example
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Work with slide comments in Aspose.Slides for .NET: add, reply, edit, resolve, and export comments in PPT, PPTX, and ODP presentations with C# code examples."
---

This article demonstrates adding, reading, removing, and replying to modern comments using **Aspose.Slides for .NET**.

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.

## Download and run

[Download the complete project](example.zip), extract it, and open `Example.sln` or run:

```console
dotnet restore Example.sln
dotnet run --project Example.csproj -- --mode evaluation
```

The download includes every case below, its fixture helpers and inputs. `Program.cs` runs all cases; use `--action block-001` to run one independently. Outputs and an action report are written to the printed output directory. No previous example or working-directory setup is required. Evaluation adds a watermark and can truncate read-back text; the short fixtures still have explicit structural checks. For full text and no watermark, use `--mode licensed --license PATH` with your own valid license. See the [setup guide](/slides/net/examples/getting-started/) for supported SDKs and native prerequisites.

## **Add a Modern Comment**

Create a comment authored by a user and save the presentation.

```csharp
using System;
using Aspose.Slides.Export;
using Aspose.Slides;
using System.Drawing;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var author = presentation.CommentAuthors.AddAuthor("User", "U1");
author.Comments.AddModernComment("Note", slide, null, new PointF(100, 100), new DateTime(2026, 1, 1));

presentation.Save("modern_comment.pptx", SaveFormat.Pptx);
```

## **Access a Modern Comment**

Read a modern comment from an existing presentation.

```csharp
using System;
using Aspose.Slides.Export;
using Aspose.Slides;

using var presentation = new Presentation();

var initialAuthor = presentation.CommentAuthors.AddAuthor("User", "U1");
initialAuthor.Comments.AddModernComment("Note", presentation.Slides[0], null,
    new System.Drawing.PointF(100, 100), new DateTime(2026, 1, 1));

var author = presentation.CommentAuthors[0];

var comment = (IModernComment)author.Comments[0];
Console.WriteLine($"Author: {author.Name}, Comment: {comment.Text}, Position: {comment.Position}");

presentation.Save("comment-02.pptx", SaveFormat.Pptx);
```

## **Remove a Modern Comment**

Remove a comment and save the updated file.

```csharp
using System;
using Aspose.Slides.Export;
using Aspose.Slides;

using var presentation = new Presentation();

var initialAuthor = presentation.CommentAuthors.AddAuthor("User", "U1");
initialAuthor.Comments.AddModernComment("Note", presentation.Slides[0], null,
    new System.Drawing.PointF(100, 100), new DateTime(2026, 1, 1));

var author = presentation.CommentAuthors[0];

var comment = author.Comments[0];
comment.Remove();

presentation.Save("modern_comment_removed.pptx", SaveFormat.Pptx);
```

## **Reply to a Modern Comment**

Add replies to a parent modern comment.

```csharp
using System;
using Aspose.Slides.Export;
using Aspose.Slides;
using System.Drawing;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var author = presentation.CommentAuthors.AddAuthor("User", "U1");

var parentComment = author.Comments.AddModernComment("Root", slide, null, new PointF(100, 100), new DateTime(2026, 1, 1));
var reply1 = author.Comments.AddModernComment("One", slide, null, new PointF(110, 100), new DateTime(2026, 1, 1));
var reply2 = author.Comments.AddModernComment("Two", slide, null, new PointF(120, 100), new DateTime(2026, 1, 1));

reply1.ParentComment = parentComment;
reply2.ParentComment = parentComment;

presentation.Save("modern_comment_replies.pptx", SaveFormat.Pptx);
```
