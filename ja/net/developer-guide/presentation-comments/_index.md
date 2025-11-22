---
title: プレゼンテーションのコメント
type: docs
weight: 100
url: /ja/net/presentation-comments/
keywords: "コメント, PowerPoint コメント, PowerPoint プレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C# または .NET で PowerPoint プレゼンテーションにコメントと返信を追加する"
---

PowerPoint では、コメントはスライド上のメモや注釈として表示されます。コメントをクリックすると、その内容やメッセージが表示されます。

## **プレゼンテーションにコメントを追加する理由**

プレゼンテーションをレビューする際に、フィードバックを提供したり同僚とやり取りしたりするためにコメントを使用したい場合があります。

PowerPoint プレゼンテーションでコメントを使用できるように、Aspose.Slides for .NET は以下を提供します。

* The [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスは、著者コレクション（[CommentAuthorCollection](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/properties/index) プロパティから）を含みます。著者はスライドにコメントを追加します。
* The  [ICommentCollection](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection) インターフェイスは、個々の著者に対するコメントコレクションを含みます。
* The  [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) クラスは、著者とそのコメントに関する情報（コメントを追加した人物、追加された時間、コメントの位置など）を含みます。
* The [CommentAuthor](https://reference.aspose.com/slides/net/aspose.slides/commentauthor) クラスは、個々の著者に関する情報（著者名、イニシャル、著者名に関連付けられたコメントなど）を含みます。

## **スライド コメントの追加**

この C# コードは、PowerPoint プレゼンテーションのスライドにコメントを追加する方法を示しています：
```c#
// Presentation クラスのインスタンスを作成します
using (Presentation presentation = new Presentation())
{
    // 空のスライドを追加します
    presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

    // 作者を追加します
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Jawad", "MF");

    // コメントの位置を設定します
    PointF point = new PointF();
    point.X = 0.2f;
    point.Y = 0.2f;

    // スライド 1 の作者用スライドコメントを追加します
    author.Comments.AddComment("Hello Jawad, this is slide comment", presentation.Slides[0], point, DateTime.Now);

    // スライド 2 の作者用スライドコメントを追加します
    author.Comments.AddComment("Hello Jawad, this is second slide comment", presentation.Slides[1], point, DateTime.Now);

    // ISlide 1 にアクセスします
    ISlide slide = presentation.Slides[0];

    // 引数に null を渡すと、すべての作者のコメントが選択されたスライドに取得されます
    IComment[] Comments = slide.GetSlideComments(author);

    // スライド 1 のインデックス 0 のコメントにアクセスします
    String str = Comments[0].Text;

    presentation.Save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.GetLength(0) > 0)
    {
        // インデックス 0 の作者のコメントコレクションを選択します
        ICommentCollection commentCollection = Comments[0].Author.Comments;
        String Comment = commentCollection[0].Text;
    }
}
```


## **スライド コメントへのアクセス**

この C#コードは、PowerPoint プレゼンテーションのスライド上にある既存のコメントにアクセスする方法を示しています：
```c#
// Presentation クラスのインスタンスを作成します
using (Presentation presentation = new Presentation("Comments1.pptx"))
{
    foreach (var commentAuthor in presentation.CommentAuthors)
    {
        var author = (CommentAuthor) commentAuthor;
        foreach (var comment1 in author.Comments)
        {
            var comment = (Comment) comment1;
            Console.WriteLine("ISlide :" + comment.Slide.SlideNumber + " has comment: " + comment.Text + " with Author: " + comment.Author.Name + " posted on time :" + comment.CreatedTime + "\n");
        }
    }
}
```


## **コメントへの返信**

親コメントは、コメントや返信の階層における最上位または元のコメントです。[ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/properties/parentcomment) プロパティ（[IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) インターフェイスから）を使用して、親コメントを設定または取得できます。

この C# コードは、コメントを追加し、それに対する返信を取得する方法を示しています：
```c#
using (Presentation pres = new Presentation())
{
    // コメントを追加します
    ICommentAuthor author1 = pres.CommentAuthors.AddAuthor("Author_1", "A.A.");
    IComment comment1 = author1.Comments.AddComment("comment1", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    // comment1 に対する返信を追加します
    ICommentAuthor author2 = pres.CommentAuthors.AddAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.Comments.AddComment("reply 1 for comment 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply1.ParentComment = comment1;

    // comment1 に対する別の返信を追加します
    IComment reply2 = author2.Comments.AddComment("reply 2 for comment 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply2.ParentComment = comment1;

    // 既存の返信に対する返信を追加します
    IComment subReply = author1.Comments.AddComment("subreply 3 for reply 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    subReply.ParentComment = reply2;

    IComment comment2 = author2.Comments.AddComment("comment 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    IComment comment3 = author2.Comments.AddComment("comment 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    IComment reply3 = author1.Comments.AddComment("reply 4 for comment 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply3.ParentComment = comment3;

    // コンソールにコメント階層を表示します
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

    // comment1 とそれへのすべての返信を削除します
    comment1.Remove();

    pres.Save("remove_comment.pptx", SaveFormat.Pptx);
}
```


{{% alert color="warning" title="注意" %}} 
* [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/methods/remove) メソッド（[IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) インターフェイスから）を使用してコメントを削除すると、そのコメントへの返信も削除されます。 
* [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/properties/parentcomment) 設定が循環参照を引き起こす場合、[PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception) がスローされます。
{{% /alert %}}

## **モダン コメントの追加**

2021 年、Microsoft は PowerPoint に *モダン コメント* を導入しました。モダン コメント機能は PowerPoint のコラボレーションを大幅に向上させます。モダン コメントにより、PowerPoint ユーザーはコメントを解決したり、オブジェクトやテキストにコメントを固定したり、従来よりもはるかに簡単にやり取りできるようになります。

[Aspose Slides for .NET 21.11](https://docs.aspose.com/slides/net/aspose-slides-for-net-21-11-release-notes/) では、[ModernComment](https://reference.aspose.com/slides/net/aspose.slides/moderncomment) クラスを追加することでモダン コメントのサポートを実装しました。[AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/commentcollection/methods/addmoderncomment) と [InsertModernComment](https://reference.aspose.com/slides/net/aspose.slides/commentcollection/methods/insertmoderncomment) メソッドが [CommentCollection](https://reference.aspose.com/slides/net/aspose.slides/commentcollection) クラスに追加されました。

この C# コードは、PowerPoint プレゼンテーションのスライドにモダン コメントを追加する方法を示しています： 
```c#
using (Presentation pres = new Presentation())
{
     ICommentAuthor newAuthor = pres.CommentAuthors.AddAuthor("Some Author", "SA");
     IModernComment modernComment = newAuthor.Comments.AddModernComment("This is a modern comment", pres.Slides[0], null, new PointF(100, 100), DateTime.Now);
 
     pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **コメントの削除**

### **すべてのコメントと著者を削除**

この C# コードは、プレゼンテーション内のすべてのコメントと著者を削除する方法を示しています：
```c#
using (var presentation = new Presentation("example.pptx"))
{
    // プレゼンテーションからすべてのコメントを削除します
    foreach (var author in presentation.CommentAuthors)
    {
        author.Comments.Clear();
    }

    // すべての作者を削除します
    presentation.CommentAuthors.Clear();

    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```


### **特定のコメントを削除**

この C# コードは、スライド上の特定のコメントを削除する方法を示しています：
```c#
using (var presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    
    // コメントを追加します...
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Author", "A");
    author.Comments.AddComment("comment 1", slide, new PointF(0.2f, 0.2f), DateTime.Now);
    author.Comments.AddComment("comment 2", slide, new PointF(0.3f, 0.2f), DateTime.Now);
    
    // テキスト "comment 1" を含むすべてのコメントを削除します
    foreach (ICommentAuthor commentAuthor in presentation.CommentAuthors)
    {
        List<IComment> toRemove = new List<IComment>();
        foreach (IComment comment in slide.GetSlideComments(commentAuthor))
        {
            if (comment.Text == "comment 1")
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


## **FAQ**

**Aspose.Slides はモダン コメントに対して「解決済み」などのステータスをサポートしていますか？**

はい。[Modern comments](https://reference.aspose.com/slides/net/aspose.slides/moderncomment/) は [Status](https://reference.aspose.com/slides/net/aspose.slides/moderncomment/status/) プロパティを公開しています。これにより、[コメントの状態](https://reference.aspose.com/slides/net/aspose.slides/moderncommentstatus/)（例として「解決済み」にマークする）を読み書きでき、この状態はファイルに保存され PowerPoint で認識されます。

**スレッド化されたディスカッション（返信チェーン）はサポートされていますか？また、入れ子の深さに制限はありますか？**

はい。各コメントは [parent comment](https://reference.aspose.com/slides/net/aspose.slides/comment/parentcomment/) を参照できるため、任意の長さの返信チェーンを作成できます。API には特定の入れ子深さの上限は定義されていません。

**スライド上のコメント マーカーの位置はどの座標系で定義されていますか？**

位置はスライドの座標系で浮動小数点数のポイントとして保存されます。そのため、コメント マーカーを必要な場所に正確に配置できます。