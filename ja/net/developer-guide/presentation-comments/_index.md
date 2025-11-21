---
title: .NET でプレゼンテーション コメントを管理
linktitle: プレゼンテーション コメント
type: docs
weight: 100
url: /ja/net/presentation-comments/
keywords:
- コメント
- モダンコメント
- PowerPoint コメント
- プレゼンテーションコメント
- スライドコメント
- コメントを追加
- コメントにアクセス
- コメントを編集
- コメントに返信
- コメントを削除
- コメントを削除
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET でプレゼンテーションのコメントをマスターし、PowerPoint ファイルのコメントを高速かつ簡単に追加、読み取り、編集、削除できます。"
---

PowerPoint では、コメントはスライド上のノートや注釈として表示されます。コメントをクリックすると、その内容やメッセージが表示されます。

## **プレゼンテーションにコメントを追加する理由**

プレゼンテーションをレビューする際に、フィードバックを提供したり同僚とやり取りしたりするためにコメントを使用したい場合があります。

PowerPoint プレゼンテーションでコメントを使用できるように、Aspose.Slides for .NET は次の機能を提供します。

* スライドの著者コレクション（[CommentAuthorCollection](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/properties/index) プロパティ）を保持する [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラス。著者はスライドにコメントを追加します。  
* 個々の著者向けのコメントコレクションを保持する [ICommentCollection](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection) インターフェイス。  
* コメントの作成者やコメント情報（誰が追加したか、追加時間、コメントの位置など）を保持する [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) クラス。  
* 個々の著者情報（著者名、イニシャル、著者名に関連付けられたコメントなど）を保持する [CommentAuthor](https://reference.aspose.com/slides/net/aspose.slides/commentauthor) クラス。

## **スライドコメントの追加**
この C# コードは、PowerPoint プレゼンテーションのスライドにコメントを追加する方法を示しています:
```c#
 // Presentation クラスのインスタンスを作成します
using (Presentation presentation = new Presentation())
{
    // 空のスライドを追加します
    presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

    // 著者を追加します
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Jawad", "MF");

    // コメントの位置を設定します
    PointF point = new PointF();
    point.X = 0.2f;
    point.Y = 0.2f;

    // 著者のスライド1へのスライドコメントを追加します
    author.Comments.AddComment("Hello Jawad, this is slide comment", presentation.Slides[0], point, DateTime.Now);

    // 著者のスライド2へのスライドコメントを追加します
    author.Comments.AddComment("Hello Jawad, this is second slide comment", presentation.Slides[1], point, DateTime.Now);

    // ISlide 1 にアクセスします
    ISlide slide = presentation.Slides[0];

    // 引数に null を渡すと、すべての著者からのコメントが選択したスライドに持ち込まれます
    IComment[] Comments = slide.GetSlideComments(author);

    // スライド1のインデックス0のコメントにアクセスします
    String str = Comments[0].Text;

    presentation.Save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.GetLength(0) > 0)
    {
        // インデックス0の著者のコメントコレクションを選択します
        ICommentCollection commentCollection = Comments[0].Author.Comments;
        String Comment = commentCollection[0].Text;
    }
}
```


## **スライドコメントへのアクセス**
この C# コードは、PowerPoint プレゼンテーションのスライド上に既存のコメントにアクセスする方法を示しています:
```c#
// Presentation クラスのインスタンスを生成します
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
親コメントは、コメントや返信の階層における最上位（元）コメントです。[IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) インターフェイスの [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/properties/parentcomment) プロパティを使用して、親コメントの取得または設定ができます。

この C# コードは、コメントを追加し、返信を取得する方法を示しています:
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

    // comment1 とそのすべての返信を削除します
    comment1.Remove();

    pres.Save("remove_comment.pptx", SaveFormat.Pptx);
}
```


{{% alert color="warning" title="Attention" %}} 

* [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) インターフェイスの [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/methods/remove) メソッドでコメントを削除すると、コメントへの返信もすべて削除されます。  
* [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/properties/parentcomment) の設定が循環参照になると、[PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception) がスローされます。

{{% /alert %}}

## **モダンコメントの追加**

2021 年に Microsoft は PowerPoint に *モダンコメント* を導入しました。モダンコメント機能は、PowerPoint の共同作業を大幅に向上させます。モダンコメントにより、コメントの解決、オブジェクトやテキストへのコメントの固定、そしてこれまで以上に簡単にやり取りできるようになりました。

[Aspose Slides for .NET 21.11](https://docs.aspose.com/slides/net/aspose-slides-for-net-21-11-release-notes/) では、[ModernComment](https://reference.aspose.com/slides/net/aspose.slides/moderncomment) クラスを追加してモダンコメントのサポートを実装しました。[CommentCollection](https://reference.aspose.com/slides/net/aspose.slides/commentcollection) クラスに [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/commentcollection/methods/addmoderncomment) および [InsertModernComment](https://reference.aspose.com/slides/net/aspose.slides/commentcollection/methods/insertmoderncomment) メソッドが追加されました。

この C# コードは、PowerPoint プレゼンテーションのスライドにモダンコメントを追加する方法を示しています: 
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

この C# コードは、プレゼンテーション内のすべてのコメントと著者を削除する方法を示しています:
```c#
using (var presentation = new Presentation("example.pptx"))
{
    // プレゼンテーションからすべてのコメントを削除します
    foreach (var author in presentation.CommentAuthors)
    {
        author.Comments.Clear();
    }

    // すべての著者を削除します
    presentation.CommentAuthors.Clear();

    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```


### **特定のコメントを削除**

この C# コードは、スライド上の特定のコメントを削除する方法を示しています:
```c#
using (var presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    
    // コメントを追加します...
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Author", "A");
    author.Comments.AddComment("comment 1", slide, new PointF(0.2f, 0.2f), DateTime.Now);
    author.Comments.AddComment("comment 2", slide, new PointF(0.3f, 0.2f), DateTime.Now);
    
    // テキスト "comment 1" 를 포함하는 모든 댓글을 제거합니다
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

**Aspose.Slides はモダンコメントに「解決済み」などのステータスをサポートしていますか？**

はい。[Modern comments](https://reference.aspose.com/slides/net/aspose.slides/moderncomment/) は [Status](https://reference.aspose.com/slides/net/aspose.slides/moderncomment/status/) プロパティを公開しています。コメントの状態（例: 解決済み）を取得および設定でき、この状態はファイルに保存され PowerPoint でも認識されます。

**スレッド形式のディスカッション（返信チェーン）はサポートされますか？ネストの上限はありますか？**

はい。各コメントは [parent comment](https://reference.aspose.com/slides/net/aspose.slides/comment/parentcomment/) を参照できるため、任意の深さの返信チェーンを構成できます。API で特定のネスト深さ上限は宣言されていません。

**コメントマーカーの位置はスライドのどの座標系で定義されていますか？**

位置はスライドの座標系における浮動小数点のポイントとして保存されます。これにより、必要な正確な位置にコメントマーカーを配置できます。