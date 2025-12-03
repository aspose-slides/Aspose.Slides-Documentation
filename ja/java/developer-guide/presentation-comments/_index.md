---
title: Java でプレゼンテーションコメントを管理する
linktitle: プレゼンテーションコメント
type: docs
weight: 100
url: /ja/java/presentation-comments/
keywords:
  - コメント
  - モダンコメント
  - PowerPoint コメント
  - プレゼンテーションコメント
  - スライドコメント
  - コメントの追加
  - コメントへのアクセス
  - コメントの編集
  - コメントへの返信
  - コメントの削除
  - コメントの削除
  - PowerPoint
  - OpenDocument
  - プレゼンテーション
  - Java
  - Aspose.Slides
description: "Aspose.Slides for Java を使用してプレゼンテーションコメントをマスターし、PowerPoint ファイル内のコメントを高速かつ簡単に追加、取得、編集、削除します。"
---

PowerPoint では、コメントはスライド上のノートまたは注釈として表示されます。コメントをクリックすると、その内容やメッセージが表示されます。

## **プレゼンテーションにコメントを追加する理由**

プレゼンテーションをレビューするときに、フィードバックを提供したり同僚とコミュニケーションを取ったりするためにコメントを使用したくなることがあります。

PowerPoint プレゼンテーションでコメントを使用できるように、Aspose.Slides for Java は次を提供します。

* The [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスは、著者のコレクション（[ICommentAuthorCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ICommentAuthorCollection) インターフェイスから） を含みます。著者はスライドにコメントを追加します。 
* The [ICommentCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ICommentCollection) インターフェイスは、個々の著者のコメントコレクションを保持します。 
* The [IComment](https://reference.aspose.com/slides/java/com.aspose.slides/IComment) クラスは、著者とそのコメントに関する情報（コメントを追加した人物、追加された日時、コメントの位置など） を含みます。 
* The [CommentAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/CommentAuthor) クラスは、個々の著者に関する情報（著者名、イニシャル、著者名に関連付けられたコメントなど） を含みます。 

## **スライドコメントの追加**
この Java コードは、PowerPoint プレゼンテーションのスライドにコメントを追加する方法を示します:
```java
// Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // 空のスライドを追加します
    pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    // 作成者を追加します
    ICommentAuthor author = pres.getCommentAuthors().addAuthor("Jawad", "MF");

    // コメントの位置を設定します
    Point2D.Float point = new Point2D.Float(0.2f, 0.2f);

    // スライド1の作成者のスライドコメントを追加します
    author.getComments().addComment("Hello Jawad, this is slide comment", pres.getSlides().get_Item(0), point, new Date());

    // スライド2の作成者のスライドコメントを追加します
    author.getComments().addComment("Hello Jawad, this is second slide comment", pres.getSlides().get_Item(1), point, new Date());

    // ISlide 1 にアクセスします
    ISlide slide = pres.getSlides().get_Item(0);

    // null を引数として渡すと、すべての作成者のコメントが選択されたスライドに取得されます
    IComment[] Comments = slide.getSlideComments(author);

    // スライド1のインデックス0のコメントにアクセスします
    String str = Comments[0].getText();

    pres.save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.length > 0)
    {
        // インデックス0の作成者のコメントコレクションを選択します
        ICommentCollection commentCollection = Comments[0].getAuthor().getComments();
        String Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **スライドコメントへのアクセス**
この Java コードは、PowerPoint プレゼンテーションのスライドに既存のコメントにアクセスする方法を示します:
```java
// Presentation クラスのインスタンスを作成します
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
親コメントは、コメントや返信の階層における最上位または元のコメントです。[getParentComment](https://reference.aspose.com/slides/java/com.aspose.slides/IComment#getParentComment--) または [setParentComment](https://reference.aspose.com/slides/java/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) メソッド（[IComment](https://reference.aspose.com/slides/java/com.aspose.slides/IComment) インターフェイス）を使用して、親コメントを設定または取得できます。 

この Java コードは、コメントを追加しそれへの返信を取得する方法を示します:
```java
Presentation pres = new Presentation();
try {
    // コメントを追加します
    ICommentAuthor author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    // comment1 の返信を追加します
    ICommentAuthor author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply1.setParentComment(comment1);

    // comment1 の別の返信を追加します
    IComment reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    reply2.setParentComment(comment1);

    // 既存の返信に対する返信を追加します
    IComment subReply = author1.getComments().addComment("subreply 3 for reply 2", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    subReply.setParentComment(reply2);

    IComment comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    IComment comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    IComment reply3 = author1.getComments().addComment("reply 4 for comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply3.setParentComment(comment3);

    // コンソールにコメント階層を表示します
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

    // comment1 とそれに対するすべての返信を削除します
    comment1.remove();

    pres.save("remove_comment.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="warning" title="Attention" %}} 

* [Remove](https://reference.aspose.com/slides/java/com.aspose.slides/IComment#remove--) メソッド（[IComment](https://reference.aspose.com/slides/java/com.aspose.slides/IComment) インターフェイス）を使用してコメントを削除すると、そのコメントへの返信もすべて削除されます。 
* [setParentComment](https://reference.aspose.com/slides/java/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) の設定が循環参照を引き起こす場合、[PptxEditException](https://reference.aspose.com/slides/java/com.aspose.slides/PptxEditException) がスローされます。

{{% /alert %}}

## **モダンコメントの追加**

2021 年に、Microsoft は PowerPoint に *モダンコメント* を導入しました。モダンコメント機能は、PowerPoint におけるコラボレーションを大幅に向上させます。モダンコメントを使用すると、ユーザーはコメントを解決したり、オブジェクトやテキストにコメントを固定したり、以前よりもはるかに簡単にやり取りできるようになります。 

[Aspose Slides for Java 21.11](https://docs.aspose.com/slides/java/aspose-slides-for-java-21-11-release-notes/) では、[ModernComment](https://reference.aspose.com/slides/java/com.aspose.slides/ModernComment) クラスを追加することでモダンコメントのサポートを実装しました。[addModernComment](https://reference.aspose.com/slides/java/com.aspose.slides/CommentCollection#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) および [insertModernComment](https://reference.aspose.com/slides/java/com.aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) メソッドが [CommentCollection](https://reference.aspose.com/slides/java/com.aspose.slides/CommentCollection) クラスに追加されました。 

この Java コードは、PowerPoint プレゼンテーションのスライドにモダンコメントを追加する方法を示します: 
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

### **すべてのコメントと作者の削除**

この Java コードは、プレゼンテーション内のすべてのコメントと作者を削除する方法を示します:
```java
Presentation presentation = new Presentation("example.pptx");
try {
    // プレゼンテーションからすべてのコメントを削除します
    for (ICommentAuthor author : presentation.getCommentAuthors())
    {
        author.getComments().clear();
    }

    // すべての作成者を削除します
    presentation.getCommentAuthors().clear();

    presentation.save("example_out.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


### **特定のコメントの削除**

この Java コードは、スライド上の特定のコメントを削除する方法を示します:
```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // コメントを追加...
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comment 1", slide, new Point2D.Float(0.2f, 0.2f), new Date());
    author.getComments().addComment("comment 2", slide, new Point2D.Float(0.3f, 0.2f), new Date());

    // "comment 1" のテキストを含むすべてのコメントを削除する
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


## **よくある質問**

**Aspose.Slides はモダンコメントに「解決済み」などのステータスをサポートしていますか？**

はい。[Modern comments](https://reference.aspose.com/slides/java/com.aspose.slides/moderncomment/) は [setStatus](https://reference.aspose.com/slides/java/com.aspose.slides/moderncomment/#setStatus-byte-) メソッドを公開しています。コメントの状態（例: 解決済みとしてマーク）を書き込み、この状態はファイルに保存され、PowerPoint で認識されます。

**スレッド化されたディスカッション（返信チェーン）はサポートされますか？ ネストの制限はありますか？**

はい。各コメントはその [parent comment](https://reference.aspose.com/slides/java/com.aspose.slides/comment/#getParentComment--) を参照できるため、任意の深さの返信チェーンを構築できます。API では特定のネスト深度制限は宣言されていません。

**スライド上のコメントマーカーの位置はどの座標系で定義されていますか？**

位置はスライドの座標系で浮動小数点のポイントとして保存されます。これにより、必要な正確な位置にコメントマーカーを配置できます。