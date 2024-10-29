---
title: プレゼンテーションのコメント
type: docs
weight: 100
url: /ja/androidjava/presentation-comments/
keywords: "コメント, PowerPoint コメント, PowerPoint プレゼンテーション, Java, Aspose.Slides for Android via Java"
description: "JavaでPowerPointプレゼンテーションにコメントや返信を追加する"
---

PowerPointでは、コメントはスライド上のノートまたは注釈として表示されます。コメントをクリックすると、その内容やメッセージが表示されます。

### **なぜプレゼンテーションにコメントを追加するのか？**

プレゼンテーションをレビューする際に、フィードバックを提供したり同僚とコミュニケーションを取るために、コメントを使用したい場合があります。

PowerPointプレゼンテーションでコメントを使用できるように、Aspose.Slides for Android via Javaは以下を提供します。

* [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスは、スライドにコメントを追加する著者のコレクション（[ICommentAuthorCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICommentAuthorCollection)インターフェイスから）を含みます。
* 単一の著者のためのコメントのコレクションを含む[ICommentCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICommentCollection)インターフェイス。
* 著者とそのコメントに関する情報を含む[IComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment)クラス：コメントを追加した人物、コメントが追加された時間、コメントの位置など。
* 個々の著者に関する情報を含む[CommentAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommentAuthor)クラス：著者の名前、イニシャル、著者名に関連付けられたコメントなど。

## **スライドコメントの追加**
このJavaコードは、PowerPointプレゼンテーションのスライドにコメントを追加する方法を示しています。

```java
// Presentationクラスをインスタンス化
Presentation pres = new Presentation();
try {
    // 空のスライドを追加
    pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    // 著者を追加
    ICommentAuthor author = pres.getCommentAuthors().addAuthor("Jawad", "MF");

    // コメントの位置を設定
    Point2D.Float point = new Point2D.Float(0.2f, 0.2f);

    // スライド1の著者にスライドコメントを追加
    author.getComments().addComment("Hello Jawad, this is slide comment", pres.getSlides().get_Item(0), point, new Date());

    // スライド2の著者にスライドコメントを追加
    author.getComments().addComment("Hello Jawad, this is second slide comment", pres.getSlides().get_Item(1), point, new Date());

    // ISlide 1にアクセス
    ISlide slide = pres.getSlides().get_Item(0);

    // nullが引数として渡されると、すべての著者からのコメントが選択されたスライドに表示される
    IComment[] Comments = slide.getSlideComments(author);

    // スライド1のインデックス0のコメントにアクセス
    String str = Comments[0].getText();

    pres.save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.length > 0)
    {
        // インデックス0の著者のコメントコレクションを選択
        ICommentCollection commentCollection = Comments[0].getAuthor().getComments();
        String Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **スライドコメントへのアクセス**
このJavaコードは、PowerPointプレゼンテーションのスライド上の既存のコメントにアクセスする方法を示しています。

```java
// Presentationクラスをインスタンス化
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

## **返信コメント**
親コメントは、コメントや返信の階層での最上位または元のコメントです。[getParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment#getParentComment--)または[setParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-)メソッド（[IComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment)インターフェイスから）を使用して、親コメントを設定または取得できます。

このJavaコードは、コメントを追加し、それに対する返信を取得する方法を示しています。

```java
Presentation pres = new Presentation();
try {
    // コメントを追加
    ICommentAuthor author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    // comment1に対する返信を追加
    ICommentAuthor author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply1.setParentComment(comment1);

    // comment1に対する別の返信を追加
    IComment reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    reply2.setParentComment(comment1);

    // 既存の返信に対する返信を追加
    IComment subReply = author1.getComments().addComment("subreply 3 for reply 2", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    subReply.setParentComment(reply2);

    IComment comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    IComment comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    IComment reply3 = author1.getComments().addComment("reply 4 for comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply3.setParentComment(comment3);

    // コンソールにコメントの階層を表示
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

    // comment1とそのすべての返信を削除
    comment1.remove();

    pres.save("remove_comment.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" title="注意" %}} 

* [Remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment#remove--)メソッド（[IComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment)インターフェイスから）がコメントを削除するために使用されると、コメントへの返信も削除されます。
* [setParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-)の設定が循環参照を引き起こすと、[PptxEditException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PptxEditException)がスローされます。

{{% /alert %}}

## **モダンコメントの追加**

2021年、MicrosoftはPowerPointに*モダンコメント*を導入しました。モダンコメント機能は、PowerPointにおけるコラボレーションを大幅に改善します。モダンコメントを通じて、PowerPointユーザーはコメントを解決したり、コメントをオブジェクトやテキストに固定し、以前よりもはるかに簡単にやり取りを行うことができます。

[Aspose Slides for Java 21.11](https://docs.aspose.com/slides/androidjava/aspose-slides-for-java-21-11-release-notes/)では、[ModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ModernComment)クラスを追加することでモダンコメントのサポートを実装しました。 [addModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommentCollection#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-)および[insertModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-)メソッドが[CommentCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommentCollection)クラスに追加されました。

このJavaコードは、PowerPointプレゼンテーションのスライドにモダンコメントを追加する方法を示しています。 

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

### **すべてのコメントと著者の削除**

このJavaコードは、プレゼンテーションからすべてのコメントと著者を削除する方法を示しています。

```java
Presentation presentation = new Presentation("example.pptx");
try {
    // プレゼンテーションからすべてのコメントを削除
    for (ICommentAuthor author : presentation.getCommentAuthors())
    {
        author.getComments().clear();
    }

    // すべての著者を削除
    presentation.getCommentAuthors().clear();

    presentation.save("example_out.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **特定のコメントの削除**

このJavaコードは、スライド上の特定のコメントを削除する方法を示しています。

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // コメントを追加...
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comment 1", slide, new Point2D.Float(0.2f, 0.2f), new Date());
    author.getComments().addComment("comment 2", slide, new Point2D.Float(0.3f, 0.2f), new Date());

    // "comment 1"というテキストを含むすべてのコメントを削除
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