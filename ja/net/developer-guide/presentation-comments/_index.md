---
title: .NET でプレゼンテーション コメントを管理する
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
description: "Aspose.Slides for .NET を使用してプレゼンテーション コメントをマスターし、PowerPoint ファイル内のコメントを素早く簡単に追加、読み取り、編集、削除します。"
---

PowerPoint では、コメントはスライド上のノートや注釈として表示されます。コメントをクリックすると、その内容やメッセージが表示されます。

## **プレゼンテーションにコメントを追加する理由**

プレゼンテーションをレビューする際に、フィードバックを提供したり同僚とコミュニケーションを取るためにコメントを使用したい場合があります。

PowerPoint プレゼンテーションでコメントを使用できるように、Aspose.Slides for .NET は以下を提供します。

* スライドの作成者コレクション（[CommentAuthorCollection](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/properties/index) プロパティ）を含む [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラス。作成者はスライドにコメントを追加します。  
* 個々の作成者のコメントコレクションを含む [ICommentCollection](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection) インターフェイス。  
* コメントを追加した作成者、追加日時、コメントの位置などの情報を含む [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) クラス。  
* 作成者名、イニシャル、作成者に紐付くコメントなど、個々の作成者情報を含む [CommentAuthor](https://reference.aspose.com/slides/net/aspose.slides/commentauthor) クラス。  

## **スライド コメントの追加**
次の C# コードは、PowerPoint プレゼンテーションのスライドにコメントを追加する方法を示しています。
```c#
// Presentation クラスのインスタンスを作成します
using (Presentation presentation = new Presentation())
{
    // 空のスライドを追加します
    presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

    // 作成者を追加します
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Jawad", "MF");

    // コメントの位置を設定します
    PointF point = new PointF();
    point.X = 0.2f;
    point.Y = 0.2f;

    // スライド 1 の作成者に対してスライドコメントを追加します
    author.Comments.AddComment("Hello Jawad, this is slide comment", presentation.Slides[0], point, DateTime.Now);

    // スライド 2 の作成者に対してスライドコメントを追加します
    author.Comments.AddComment("Hello Jawad, this is second slide comment", presentation.Slides[1], point, DateTime.Now);

    // ISlide 1 にアクセスします
    ISlide slide = presentation.Slides[0];

    // 引数に null を渡すと、すべての作成者のコメントが選択したスライドに取得されます
    IComment[] Comments = slide.GetSlideComments(author);

    // スライド 1 のインデックス 0 のコメントにアクセスします
    String str = Comments[0].Text;

    presentation.Save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.GetLength(0) > 0)
    {
        // インデックス 0 の作成者のコメントコレクションを選択します
        ICommentCollection commentCollection = Comments[0].Author.Comments;
        String Comment = commentCollection[0].Text;
    }
}
```


## **スライド コメントへのアクセス**
次の C# コードは、PowerPoint プレゼンテーションのスライドにある既存のコメントにアクセスする方法を示しています。
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
親コメントは、コメントや返信の階層構造における最上位（元）のコメントです。[IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) インターフェイスの [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/properties/parentcomment) プロパティを使用して、親コメントを設定または取得できます。

次の C# コードは、コメントを追加し、それへの返信を取得する方法を示しています。
```c#
using (Presentation pres = new Presentation())
{
    // コメントを追加します
    ICommentAuthor author1 = pres.CommentAuthors.AddAuthor("Author_1", "A.A.");
    IComment comment1 = author1.Comments.AddComment("comment1", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    // comment1 に返信を追加します
    ICommentAuthor author2 = pres.CommentAuthors.AddAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.Comments.AddComment("reply 1 for comment 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply1.ParentComment = comment1;

    // comment1 に別の返信を追加します
    IComment reply2 = author2.Comments.AddComment("reply 2 for comment 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply2.ParentComment = comment1;

    // 既存の返信に返信を追加します
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

    // comment1 とそれに対するすべての返信を削除します
    comment1.Remove();

    pres.Save("remove_comment.pptx", SaveFormat.Pptx);
}
```


{{% alert color="warning" title="Attention" %}} 

* [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) インターフェイスの [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/methods/remove) メソッドでコメントを削除すると、そのコメントへの返信もすべて削除されます。  
* [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/properties/parentcomment) の設定が循環参照になると、[PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception) がスローされます。

{{% /alert %}}

## **モダン コメントの追加**

2021 年に Microsoft は PowerPoint に *モダン コメント* を導入しました。モダン コメント機能は PowerPoint におけるコラボレーションを大幅に向上させます。モダン コメントを利用すると、コメントの解決、オブジェクトやテキストへのコメントの固定、また以前よりもはるかに簡単にやり取りができるようになります。

[Aspose Slides for .NET 21.11](https://docs.aspose.com/slides/net/aspose-slides-for-net-21-11-release-notes/) では、[ModernComment](https://reference.aspose.com/slides/net/aspose.slides/moderncomment) クラスを追加することでモダン コメントのサポートを実装しました。[CommentCollection](https://reference.aspose.com/slides/net/aspose.slides/commentcollection) クラスに [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/commentcollection/methods/addmoderncomment) と [InsertModernComment](https://reference.aspose.com/slides/net/aspose.slides/commentcollection/methods/insertmoderncomment) メソッドが追加されました。

次の C# コードは、PowerPoint プレゼンテーションのスライドにモダン コメントを追加する方法を示しています。 
```c#
using (Presentation pres = new Presentation())
{
     ICommentAuthor newAuthor = pres.CommentAuthors.AddAuthor("Some Author", "SA");
     IModernComment modernComment = newAuthor.Comments.AddModernComment("This is a modern comment", pres.Slides[0], null, new PointF(100, 100), DateTime.Now);
 
     pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **コメントの削除**

### **すべてのコメントと作成者を削除**

次の C# コードは、プレゼンテーション内のすべてのコメントと作成者を削除する方法を示しています。
```c#
using (var presentation = new Presentation("example.pptx"))
{
    // プレゼンテーションからすべてのコメントを削除します
    foreach (var author in presentation.CommentAuthors)
    {
        author.Comments.Clear();
    }

    // すべての作成者を削除します
    presentation.CommentAuthors.Clear();

    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```


### **特定のコメントを削除**

次の C# コードは、スライド上の特定のコメントを削除する方法を示しています。
```c#
using (var presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    
    // コメントを追加...
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Author", "A");
    author.Comments.AddComment("comment 1", slide, new PointF(0.2f, 0.2f), DateTime.Now);
    author.Comments.AddComment("comment 2", slide, new PointF(0.3f, 0.2f), DateTime.Now);
    
    // "comment 1" テキストを含むすべてのコメントを削除
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

**モダン コメントに「解決済み」などのステータスはサポートされていますか？**

はい。[Modern comments](https://reference.aspose.com/slides/net/aspose.slides/moderncomment/) は [Status](https://reference.aspose.com/slides/net/aspose.slides/moderncomment/status/) プロパティを公開しています。コメントの状態（例: 解決済み）を読み書きでき、この状態はファイルに保存され PowerPoint でも認識されます。

**スレッド化されたディスカッション（返信チェーン）はサポートされていますか？ネストの上限はありますか？**

はい。各コメントは [parent comment](https://reference.aspose.com/slides/net/aspose.slides/comment/parentcomment/) を参照できるため、任意の深さの返信チェーンを構築できます。API には特定のネスト深度上限は定義されていません。

**スライド上のコメントマーカーの位置はどの座標系で定義されていますか？**

位置はスライドの座標系における浮動小数点のポイントとして格納されます。これにより、コメントマーカーを必要な正確な位置に配置できます。