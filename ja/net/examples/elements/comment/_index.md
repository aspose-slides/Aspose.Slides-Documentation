---
title: コメント
type: docs
weight: 230
url: /ja/net/examples/elements/comment/
keywords:
- コメント
- モダンコメント
- コメントを追加
- コメントにアクセス
- コメントを削除
- コメントに返信
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET でスライドコメントを操作します。コメントの追加、返信、編集、解決、および PPT、PPTX、ODP プレゼンテーションへのエクスポートを C# コード例で示します。"
---
この記事では、**Aspose.Slides for .NET** を使用してモダン コメントの追加、読み取り、削除、および返信を行う方法を示します。

## **モダン コメントを追加**
ユーザーが作成したコメントを作成し、プレゼンテーションを保存します。

```csharp
static void AddModernComment()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var author = presentation.CommentAuthors.AddAuthor("User", "U1");
    author.Comments.AddModernComment("This is a modern comment", slide, null, new PointF(100, 100), DateTime.Now);

    presentation.Save("modern_comment.pptx", SaveFormat.Pptx);
}
```

## **モダン コメントにアクセス**
既存のプレゼンテーションからモダン コメントを読み取ります。

```csharp
static void AccessModernComment()
{
    using var presentation = new Presentation("modern_comment.pptx");
    var author = presentation.CommentAuthors[0];

    var comment = (IModernComment)author.Comments[0];
    Console.WriteLine($"Author: {author.Name}, Comment: {comment.Text}, Position: {comment.Position}");
}
```

## **モダン コメントを削除**
コメントを削除し、更新されたファイルを保存します。

```csharp
static void RemoveModernComment()
{
    using var presentation = new Presentation("modern_comment.pptx");
    var author = presentation.CommentAuthors[0];

    var comment = author.Comments[0];
    comment.Remove();

    presentation.Save("modern_comment_removed.pptx", SaveFormat.Pptx);
}
```

## **モダン コメントに返信**
親のモダン コメントに返信を追加します。

```csharp
static void ReplyToModernComment()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var author = presentation.CommentAuthors.AddAuthor("User", "U1");

    var parentComment = author.Comments.AddModernComment("Parent comment", slide, null, new PointF(100, 100), DateTime.Now);
    var reply1 = author.Comments.AddModernComment("Reply 1", slide, null, new PointF(110, 100), DateTime.Now);
    var reply2 = author.Comments.AddModernComment("Reply 2", slide, null, new PointF(120, 100), DateTime.Now);

    reply1.ParentComment = parentComment;
    reply2.ParentComment = parentComment;

    presentation.Save("modern_comment_replies.pptx", SaveFormat.Pptx);
}
```