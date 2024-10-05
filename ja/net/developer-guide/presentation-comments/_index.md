---
title: プレゼンテーションコメント
type: docs
weight: 100
url: /net/presentation-comments/
keywords: "コメント, PowerPoint コメント, PowerPoint プレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C# または .NET で PowerPoint プレゼンテーションにコメントと返信を追加します"
---

PowerPoint では、コメントはスライド上のノートまたは注釈として表示されます。コメントをクリックすると、その内容やメッセージが表示されます。

## **プレゼンテーションにコメントを追加する理由は何ですか？**

プレゼンテーションをレビューする際に、フィードバックを提供したり、同僚とコミュニケーションを取るためにコメントを使用したい場合があります。

PowerPoint プレゼンテーションでコメントを使用できるように、Aspose.Slides for .NET は以下を提供します。

* [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラス。このクラスには、スライドにコメントを追加する著者のコレクション（[CommentAuthorCollection](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/properties/index) プロパティから）があります。
* [ICommentCollection](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection) インターフェース。このインターフェースには、個々の著者に対するコメントのコレクションがあります。
* [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) クラス。このクラスには、著者およびそのコメントに関する情報が含まれています：コメントを追加した人、コメントが追加された時間、コメントの位置など。
* [CommentAuthor](https://reference.aspose.com/slides/net/aspose.slides/commentauthor) クラス。このクラスには、個々の著者に関する情報が含まれています：著者の名前、イニシャル、著者の名前に関連付けられたコメントなど。

## **スライドコメントを追加する**
この C# コードは、PowerPoint プレゼンテーションのスライドにコメントを追加する方法を示しています。

```c#
// Presentation クラスをインスタンス化
using (Presentation presentation = new Presentation())
{
    // 空のスライドを追加
    presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

    // 著者を追加
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Jawad", "MF");

    // コメントの位置を設定
    PointF point = new PointF();
    point.X = 0.2f;
    point.Y = 0.2f;

    // スライド 1 の著者用のスライドコメントを追加
    author.Comments.AddComment("こんにちは Jawad、これはスライドコメントです", presentation.Slides[0], point, DateTime.Now);

    // スライド 2 の著者用のスライドコメントを追加
    author.Comments.AddComment("こんにちは Jawad、これは2つ目のスライドコメントです", presentation.Slides[1], point, DateTime.Now);

    // ISlide 1 にアクセス
    ISlide slide = presentation.Slides[0];

    // 引数に null を渡すと、全著者のコメントが選択したスライドに取得されます
    IComment[] Comments = slide.GetSlideComments(author);

    // スライド 1 のインデックス 0 のコメントにアクセス
    String str = Comments[0].Text;

    presentation.Save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.GetLength(0) > 0)
    {
        // インデックス 0 で著者のコメントコレクションを選択
        ICommentCollection commentCollection = Comments[0].Author.Comments;
        String Comment = commentCollection[0].Text;
    }
}
```

## **スライドコメントにアクセスする**
この C# コードは、PowerPoint プレゼンテーションのスライドにある既存のコメントにアクセスする方法を示しています。

```c#
// Presentation クラスをインスタンス化
using (Presentation presentation = new Presentation("Comments1.pptx"))
{
    foreach (var commentAuthor in presentation.CommentAuthors)
    {
        var author = (CommentAuthor) commentAuthor;
        foreach (var comment1 in author.Comments)
        {
            var comment = (Comment) comment1;
            Console.WriteLine("ISlide :" + comment.Slide.SlideNumber + " のコメント: " + comment.Text + " 著者: " + comment.Author.Name + " 投稿日時 :" + comment.CreatedTime + "\n");
        }
    }
}
```

## **返信コメント**
親コメントは、コメントや返信の階層における最上位または元のコメントです。[ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/properties/parentcomment) プロパティ（[IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) インターフェースから）を使用して、親コメントを設定または取得できます。

この C# コードは、コメントを追加し、その返信を取得する方法を示しています。

```c#
using (Presentation pres = new Presentation())
{
    // コメントを追加
    ICommentAuthor author1 = pres.CommentAuthors.AddAuthor("Author_1", "A.A.");
    IComment comment1 = author1.Comments.AddComment("コメント1", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    // コメント1への返信を追加
    ICommentAuthor author2 = pres.CommentAuthors.AddAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.Comments.AddComment("コメント1への返信 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply1.ParentComment = comment1;

    // コメント1への別の返信を追加
    IComment reply2 = author2.Comments.AddComment("コメント1への返信 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply2.ParentComment = comment1;

    // 既存の返信への返信を追加
    IComment subReply = author1.Comments.AddComment("返信 2へのサブ返信 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    subReply.ParentComment = reply2;

    IComment comment2 = author2.Comments.AddComment("コメント 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    IComment comment3 = author2.Comments.AddComment("コメント 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    IComment reply3 = author1.Comments.AddComment("コメント 3への返信 4", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply3.ParentComment = comment3;

    // コンソールにコメントの階層を表示
    ISlide slide = pres.Slides[0];
    var comments = slide.GetSlideComments(null);
    for (int i = 0; i < comments.Length; i++)
    {
        IComment comment = comments[i];
        while (comment.ParentComment != null)
        {
            Console.Write("\t");
            comment = comment.ParentComment;
        }

        Console.Write("{0} : {1}", comments[i].Author.Name, comments[i].Text);
        Console.WriteLine();
    }

    pres.Save("parent_comment.pptx",SaveFormat.Pptx);

    // comment1 とそれに対する全ての返信を削除
    comment1.Remove();

    pres.Save("remove_comment.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" title="注意" %}} 

* [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/methods/remove) メソッド（[IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) インターフェースから）を使用してコメントを削除すると、そのコメントへの返信も削除されます。
* [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/properties/parentcomment) 設定が循環参照を引き起こすと、[PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception) がスローされます。

{{% /alert %}}

## **モダンコメントを追加する**

2021年、Microsoft は PowerPoint に*モダンコメント*を導入しました。モダンコメント機能は、PowerPoint におけるコラボレーションを大幅に改善します。モダンコメントを通じて、PowerPoint ユーザーはコメントを解決し、オブジェクトやテキストにコメントを固定し、以前よりも簡単に対話を行うことができます。

[Aspose Slides for .NET 21.11](https://docs.aspose.com/slides/net/aspose-slides-for-net-21-11-release-notes/) では、[ModernComment](https://reference.aspose.com/slides/net/aspose.slides/moderncomment) クラスを追加することにより、モダンコメントのサポートを実装しました。[AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/commentcollection/methods/addmoderncomment) と [InsertModernComment](https://reference.aspose.com/slides/net/aspose.slides/commentcollection/methods/insertmoderncomment) メソッドが [CommentCollection](https://reference.aspose.com/slides/net/aspose.slides/commentcollection) クラスに追加されました。

この C# コードは、PowerPoint プレゼンテーションのスライドにモダンコメントを追加する方法を示しています：

```c#
using (Presentation pres = new Presentation())
{
     ICommentAuthor newAuthor = pres.CommentAuthors.AddAuthor("著者名", "SA");
     IModernComment modernComment = newAuthor.Comments.AddModernComment("これはモダンコメントです", pres.Slides[0], null, new PointF(100, 100), DateTime.Now);
 
     pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **コメントを削除する**

### **全コメントと著者を削除する**

この C# コードは、プレゼンテーションのすべてのコメントと著者を削除する方法を示しています。

```c#
using (var presentation = new Presentation("example.pptx"))
{
    // プレゼンテーションの全てのコメントを削除
    foreach (var author in presentation.CommentAuthors)
    {
        author.Comments.Clear();
    }

    // すべての著者を削除
    presentation.CommentAuthors.Clear();

    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```

### **特定のコメントを削除する**

この C# コードは、スライドで特定のコメントを削除する方法を示しています。

```c#
using (var presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    
    // コメントを追加...
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("著者", "A");
    author.Comments.AddComment("コメント 1", slide, new PointF(0.2f, 0.2f), DateTime.Now);
    author.Comments.AddComment("コメント 2", slide, new PointF(0.3f, 0.2f), DateTime.Now);
    
    // "コメント 1" テキストを含むすべてのコメントを削除
    foreach (ICommentAuthor commentAuthor in presentation.CommentAuthors)
    {
        List<IComment> toRemove = new List<IComment>();
        foreach (IComment comment in slide.GetSlideComments(commentAuthor))
        {
            if (comment.Text == "コメント 1")
            {
                toRemove.Add(comment);
            }
        }
        
        foreach (IComment comment in toRemove)
        {
            commentAuthor.Comments.Remove(comment);
        }
    }
    
    presentation.Save("pres.pptx", SaveFormat.Pptx);
}
```