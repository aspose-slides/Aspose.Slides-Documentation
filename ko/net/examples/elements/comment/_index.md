---
title: 주석
type: docs
weight: 230
url: /ko/net/examples/elements/comment/
keywords:
- 주석
- 현대 주석
- 주석 추가
- 주석 액세스
- 주석 제거
- 주석 회신
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET에서 슬라이드 주석을 작업합니다: 추가, 회신, 편집, 해결 및 PPT, PPTX, ODP 프레젠테이션에서 주석을 내보내는 C# 코드 예제 포함."
---
이 문서에서는 **Aspose.Slides for .NET**을 사용하여 최신 주석을 추가, 읽기, 삭제 및 응답하는 방법을 보여줍니다.

## **현대 주석 추가**

사용자가 작성한 주석을 만들고 프레젠테이션을 저장합니다.

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

## **현대 주석 액세스**

기존 프레젠테이션에서 현대 주석을 읽어옵니다.

```csharp
static void AccessModernComment()
{
    using var presentation = new Presentation("modern_comment.pptx");
    var author = presentation.CommentAuthors[0];

    var comment = (IModernComment)author.Comments[0];
    Console.WriteLine($"Author: {author.Name}, Comment: {comment.Text}, Position: {comment.Position}");
}
```

## **현대 주석 제거**

주석을 제거하고 업데이트된 파일을 저장합니다.

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

## **현대 주석에 회신**

부모 현대 주석에 대한 회신을 추가합니다.

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