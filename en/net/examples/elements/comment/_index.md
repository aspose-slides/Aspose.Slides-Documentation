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

## Download and run

[Download the complete project](example.zip), extract it, and open `Example.sln` or run:

```console
dotnet restore Example.sln
dotnet run --project Example.csproj -- --mode evaluation
```

The download includes every case below, its fixture helpers and inputs. `Program.cs` runs all cases; use `--action block-001` to run one independently. Outputs and an action report are written to the printed output directory. No previous example or working-directory setup is required. Evaluation adds a watermark and can truncate read-back text; the short fixtures still have explicit structural checks. For full text and no watermark, use `--mode licensed --license PATH` with your own valid license. See the [setup guide](/slides/net/examples/getting-started/) for supported SDKs and native prerequisites.

Each printed `CaseNN.cs` file is compiled verbatim with the included `Program.cs` and bootstrap. Checks run before saving and after reopening the result.

## **Add a Modern Comment**

Create a comment authored by a user and save the presentation.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

internal static partial class Program
{
    static void Case01()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var author = presentation.CommentAuthors.AddAuthor("User", "U1");
        author.Comments.AddModernComment("Note", slide, null, new PointF(100, 100), new DateTime(2026, 1, 1));

        presentation.Save("modern_comment.pptx", SaveFormat.Pptx);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-001", p =>
        {
            Context.Require(p.CommentAuthors.Count == 1 && p.CommentAuthors[0].Comments.Count == 1 && p.CommentAuthors[0].Comments[0].Text == "Note", "AddModernComment: semantic check 1 failed.");
        });
        Context.Pass("elements/comment/block-001", "AddModernComment", "save-reopen-structure");
    }
}
```

## **Access a Modern Comment**

Read a modern comment from an existing presentation.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    static void Case02()
    {
        using var presentation = new Presentation(Seed("comment"));
        var author = presentation.CommentAuthors[0];

        var comment = (IModernComment)author.Comments[0];
        Console.WriteLine($"Author: {author.Name}, Comment: {comment.Text}, Position: {comment.Position}");

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(p.CommentAuthors[0].Comments[0] is IModernComment && p.CommentAuthors[0].Comments[0].Text == "Note", "AccessModernComment: semantic check 1 failed.");
        });
        Context.Pass("elements/comment/block-002", "AccessModernComment", "save-reopen-structure");
    }
}
```

## **Remove a Modern Comment**

Remove a comment and save the updated file.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    static void Case03()
    {
        using var presentation = new Presentation(Seed("comment"));
        var author = presentation.CommentAuthors[0];

        var comment = author.Comments[0];
        comment.Remove();

        presentation.Save("modern_comment_removed.pptx", SaveFormat.Pptx);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-003", p =>
        {
            Context.Require(p.CommentAuthors[0].Comments.Count == 0, "RemoveModernComment: semantic check 1 failed.");
        });
        Context.Pass("elements/comment/block-003", "RemoveModernComment", "save-reopen-structure");
    }
}
```

## **Reply to a Modern Comment**

Add replies to a parent modern comment.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

internal static partial class Program
{
    static void Case04()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var author = presentation.CommentAuthors.AddAuthor("User", "U1");

        var parentComment = author.Comments.AddModernComment("Root", slide, null, new PointF(100, 100), new DateTime(2026, 1, 1));
        var reply1 = author.Comments.AddModernComment("One", slide, null, new PointF(110, 100), new DateTime(2026, 1, 1));
        var reply2 = author.Comments.AddModernComment("Two", slide, null, new PointF(120, 100), new DateTime(2026, 1, 1));

        reply1.ParentComment = parentComment;
        reply2.ParentComment = parentComment;

        presentation.Save("modern_comment_replies.pptx", SaveFormat.Pptx);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-004", p =>
        {
            Context.Require(p.CommentAuthors[0].Comments.Count == 3 && p.CommentAuthors[0].Comments[1].ParentComment == p.CommentAuthors[0].Comments[0] && p.CommentAuthors[0].Comments[2].ParentComment == p.CommentAuthors[0].Comments[0], "ReplyToModernComment: semantic check 1 failed.");
        });
        Context.Pass("elements/comment/block-004", "ReplyToModernComment", "save-reopen-structure");
    }
}
```
