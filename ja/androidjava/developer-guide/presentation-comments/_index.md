---
title: Android でプレゼンテーション コメントを管理する
linktitle: プレゼンテーション コメント
type: docs
weight: 100
url: /ja/androidjava/presentation-comments/
keywords:
- コメント
- モダンコメント
- PowerPoint コメント
- プレゼンテーション コメント
- スライド コメント
- コメントを追加
- コメントにアクセス
- コメントを編集
- コメントに返信
- コメントを削除
- コメントの削除
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用してプレゼンテーション コメントをマスターしましょう：PowerPoint ファイル内のコメントを高速かつ簡単に追加、読み取り、編集、削除できます。"
---

PowerPointでは、コメントはスライド上のノートまたは注釈として表示されます。コメントをクリックすると、その内容やメッセージが表示されます。

### **プレゼンテーションにコメントを追加する理由**

プレゼンテーションをレビューする際に、フィードバックを提供したり同僚とコミュニケーションしたりするためにコメントを使用したい場合があります。

PowerPoint プレゼンテーションでコメントを使用できるように、Aspose.Slides for Android via Java は以下を提供します。

* スライド上のコメントを追加する [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラス（著者コレクションは [ICommentAuthorCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICommentAuthorCollection) インターフェイスから取得）。
* 個々の著者向けコメントコレクションを保持する [ICommentCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICommentCollection) インターフェイス。
* コメントの作成者、作成日時、位置などの情報を含む [IComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment) クラス。
* 作成者名、イニシャル、コメントなど個別の情報を保持する [CommentAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommentAuthor) クラス。

## **スライド コメントの追加**
スライドにコメントを追加する方法を示す Java コードです:
```java
// Presentation クラスのインスタンス化
Presentation pres = new Presentation();
try {
    // 空のスライドを追加
    pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    // 作者を追加
    ICommentAuthor author = pres.getCommentAuthors().addAuthor("Jawad", "MF");

    // コメントの位置を設定
    Point2D.Float point = new Point2D.Float(0.2f, 0.2f);

    // スライド 1 の作者に対してスライドコメントを追加
    author.getComments().addComment("Hello Jawad, this is slide comment", pres.getSlides().get_Item(0), point, new Date());

    // スライド 2 の作者に対してスライドコメントを追加
    author.getComments().addComment("Hello Jawad, this is second slide comment", pres.getSlides().get_Item(1), point, new Date());

    // ISlide 1 にアクセス
    ISlide slide = pres.getSlides().get_Item(0);

    // null を引数として渡すと、すべての作者のコメントが選択されたスライドに取得される
    IComment[] Comments = slide.getSlideComments(author);

    // スライド 1 のインデックス 0 のコメントにアクセス
    String str = Comments[0].getText();

    pres.save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.length > 0)
    {
        // インデックス 0 の作者のコメントコレクションを選択
        ICommentCollection commentCollection = Comments[0].getAuthor().getComments();
        String Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **スライド コメントへのアクセス**
スライド内の既存コメントにアクセスする方法を示す Java コードです:
```java
// Presentation クラスのインスタンス化
Presentation pres = new Presentation("Comments1.pptx");
try {
    for (ICommentAuthor commentAuthor : pres.getCommentAuthors())
    {
        CommentAuthor author = (CommentAuthor) commentAuthor;
        for (IComment comment1 : author.getComments())
        {
            Comment comment = (Comment) comment1;
            System.out.println("ISlide :" + comment.getSlide().getSlideNumber() + " has comment: " + comment.getText() +
                    " with Author: " + comment.getAuthor().getName() + " posted on time :" + comment.getCreatedTime() + "\n");
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **コメントへの返信**
親コメントは、コメントや返信の階層における最上位（元）コメントです。[IComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment) インターフェイスの [getParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment#getParentComment--) または [setParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) メソッドを使用して、親コメントを取得または設定できます。

コメントを追加し、返信を取得する方法を示す Java コードです:
```java
Presentation pres = new Presentation();
try {
    // コメントを追加
    ICommentAuthor author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    // comment1 の返信を追加
    ICommentAuthor author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply1.setParentComment(comment1);

    // comment1 の別の返信を追加
    IComment reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    reply2.setParentComment(comment1);

    // 既存の返信に対して返信を追加
    IComment subReply = author1.getComments().addComment("subreply 3 for reply 2", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    subReply.setParentComment(reply2);

    IComment comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    IComment comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    IComment reply3 = author1.getComments().addComment("reply 4 for comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply3.setParentComment(comment3);

    // コンソールにコメント階層を表示
    ISlide slide = pres.getSlides().get_Item(0);
    IComment[] comments = slide.getSlideComments(null);
    for (int i = 0; i < comments.length; i++)
    {
        IComment comment = comments[i];
        while (comment.getParentComment() != null)
        {
            System.out.print("\t");
            comment = comment.getParentComment();
        }

        System.out.println(comments[i].getAuthor().getName() +  " : " + comments[i].getText());
        System.out.println();
    }
    pres.save("parent_comment.pptx",SaveFormat.Pptx);

    // comment1 とそれへのすべての返信を削除
    comment1.remove();

    pres.save("remove_comment.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="warning" title="Attention" %}} 

* [IComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment) インターフェイスの [Remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment#remove--) メソッドでコメントを削除すると、そのコメントへの返信もすべて削除されます。
* [setParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) の設定で循環参照が発生した場合、[PptxEditException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PptxEditException) がスローされます。

{{% /alert %}}

## **モダン コメントの追加**

2021 年に Microsoft は PowerPoint に *モダン コメント* を導入しました。モダン コメント機能は PowerPoint におけるコラボレーションを大幅に向上させます。モダン コメントにより、コメントの解決、オブジェクトやテキストへのコメント固定、やり取りが以前より簡単に行えるようになりました。

[Aspose Slides for Java 21.11](https://docs.aspose.com/slides/androidjava/aspose-slides-for-java-21-11-release-notes/) では、[ModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ModernComment) クラスを追加してモダン コメントのサポートを実装しました。[CommentCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommentCollection) クラスに [addModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommentCollection#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) と [insertModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) メソッドが追加されました。

スライドにモダン コメントを追加する方法を示す Java コードです:
```java
Presentation pres = new Presentation();
try {
    ICommentAuthor newAuthor = pres.getCommentAuthors().addAuthor("Some Author", "SA");
    IModernComment modernComment = newAuthor.getComments().addModernComment("This is a modern comment", pres.getSlides().get_Item(0), null, new Point2D.Float(100, 100), new Date());

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **コメントの削除**

### **すべてのコメントと著者を削除**

プレゼンテーション内のすべてのコメントと著者を削除する方法を示す Java コードです:
```java
Presentation presentation = new Presentation("example.pptx");
try {
    // プレゼンテーションからすべてのコメントを削除
    for (ICommentAuthor author : presentation.getCommentAuthors())
    {
        author.getComments().clear();
    }

    // すべての作者を削除
    presentation.getCommentAuthors().clear();

    presentation.save("example_out.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


### **特定のコメントを削除**

スライド上の特定のコメントを削除する方法を示す Java コードです:
```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // コメントを追加...
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comment 1", slide, new Point2D.Float(0.2f, 0.2f), new Date());
    author.getComments().addComment("comment 2", slide, new Point2D.Float(0.3f, 0.2f), new Date());

    // "comment 1" テキストを含むすべてのコメントを削除
    for (ICommentAuthor commentAuthor : presentation.getCommentAuthors())
    {
        ArrayList<IComment> toRemove = new ArrayList<IComment>();
        for (IComment comment : slide.getSlideComments(commentAuthor))
        {
            if (comment.getText().equals("comment 1"))
            {
                toRemove.add(comment);
            }
        }

        for (IComment comment : toRemove)
        {
            commentAuthor.getComments().remove(comment);
        }
    }

    presentation.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **FAQ**

**モダン コメントに「解決済み」などのステータスはサポートされていますか？**

はい。[Modern comments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/moderncomment/) は [setStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/moderncomment/#setStatus-byte-) メソッドを公開しており、コメントの状態（例: 解決済み）を書き込むことができます。この状態はファイルに保存され、PowerPoint でも認識されます。

**スレッド化されたディスカッション（返信チェーン）はサポートされていますか？ ネストの上限はありますか？**

はい。各コメントは [parent comment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/comment/#getParentComment--) を参照できるため、任意の深さの返信チェーンを作成できます。API には具体的なネスト深さの上限は定義されていません。

**コメントマーカーの位置はスライドのどの座標系で定義されていますか？**

位置はスライドの座標系における浮動小数点数のポイントとして保存されます。これにより、必要な場所に正確にコメントマーカーを配置できます。