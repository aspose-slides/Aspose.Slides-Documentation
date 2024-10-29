---
title: プレゼンテーションのコメント
type: docs
weight: 100
url: /ja/java/presentation-comments/
keywords: "コメント, PowerPointコメント, PowerPointプレゼンテーション, Java, Aspose.Slides for Java"
description: "JavaでPowerPointプレゼンテーションにコメントと返信を追加"
---

PowerPointでは、コメントはスライド上のメモまたは注釈として表示されます。コメントをクリックすると、その内容やメッセージが表示されます。

### **プレゼンテーションにコメントを追加する理由は？**

プレゼンテーションをレビューする際に、同僚とフィードバックを提供したりコミュニケーションをとるためにコメントを使用したいと思うことがあるかもしれません。

PowerPointプレゼンテーションでコメントを使用できるように、Aspose.Slides for Javaは以下を提供します。

* [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラス、これは著者のコレクション（[ICommentAuthorCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ICommentAuthorCollection)インターフェースから）を含んでいます。著者はスライドにコメントを追加します。
* [ICommentCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ICommentCollection)インターフェース、これは個々の著者のコメントのコレクションを含んでいます。
* [IComment](https://reference.aspose.com/slides/java/com.aspose.slides/IComment)クラス、これは著者とそのコメントに関する情報を含んでいます：コメントを追加した人、コメントが追加された時間、コメントの位置など。
* [CommentAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/CommentAuthor)クラス、これは個々の著者に関する情報を含んでいます：著者の名前、イニシャル、著者の名前に関連するコメントなど。

## **スライドにコメントを追加**
このJavaコードは、PowerPointプレゼンテーションのスライドにコメントを追加する方法を示しています：

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

    // スライド1の著者のためにスライドコメントを追加
    author.getComments().addComment("こんにちはJawad、これはスライドコメントです", pres.getSlides().get_Item(0), point, new Date());

    // スライド2の著者のためにスライドコメントを追加
    author.getComments().addComment("こんにちはJawad、これは2番目のスライドコメントです", pres.getSlides().get_Item(1), point, new Date());

    // ISlide 1にアクセス
    ISlide slide = pres.getSlides().get_Item(0);

    // nullが引数として渡されると、選択されたスライドにすべての著者からのコメントが取得される
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

## **スライドコメントにアクセス**
このJavaコードは、PowerPointプレゼンテーションのスライド上の既存のコメントにアクセスする方法を示しています：

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
            System.out.println("ISlide :" + comment.getSlide().getSlideNumber() + " にはコメントがあります: " + comment.getText() +
                    " 著者: " + comment.getAuthor().getName() + " 投稿時間 :" + comment.getCreatedTime() + "\n");
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **返信コメント**
親コメントは、コメントや返信の階層の中でトップまたは元のコメントです。[getParentComment](https://reference.aspose.com/slides/java/com.aspose.slides/IComment#getParentComment--)または[setParentComment](https://reference.aspose.com/slides/java/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-)メソッド（[IComment](https://reference.aspose.com/slides/java/com.aspose.slides/IComment)インターフェースから）を使用して、親コメントを設定または取得できます。

このJavaコードは、コメントを追加し、それに対する返信を取得する方法を示しています：

```java
Presentation pres = new Presentation();
try {
    // コメントを追加
    ICommentAuthor author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment comment1 = author1.getComments().addComment("コメント1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    // comment1への返信を追加
    ICommentAuthor author2 = pres.getCommentAuthors().addAuthor("Author_2", "B.B.");
    IComment reply1 = author2.getComments().addComment("コメント1への返信1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply1.setParentComment(comment1);

    // comment1への別の返信を追加
    IComment reply2 = author2.getComments().addComment("コメント1への返信2", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply2.setParentComment(comment1);

    // 既存の返信への返信を追加
    IComment subReply = author1.getComments().addComment("返信2への返信3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    subReply.setParentComment(reply2);

    IComment comment2 = author2.getComments().addComment("コメント2", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    IComment comment3 = author2.getComments().addComment("コメント3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    IComment reply3 = author1.getComments().addComment("コメント3への返信4", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
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

* [Remove](https://reference.aspose.com/slides/java/com.aspose.slides/IComment#remove--)メソッド（[IComment](https://reference.aspose.com/slides/java/com.aspose.slides/IComment)インターフェースから）を使用してコメントを削除すると、そのコメントへの返信も削除されます。
* [setParentComment](https://reference.aspose.com/slides/java/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-)設定が循環参照を引き起こす場合、[PptxEditException](https://reference.aspose.com/slides/java/com.aspose.slides/PptxEditException)がスローされます。

{{% /alert %}}

## **モダンコメントを追加**

2021年、MicrosoftはPowerPointで*モダンコメント*を導入しました。モダンコメント機能は、PowerPointでのコラボレーションを大幅に改善します。モダンコメントを通じて、PowerPointのユーザーはコメントを解決し、オブジェクトやテキストにコメントをアンカーし、以前よりもはるかに簡単に相互作用することができます。

[Aspose Slides for Java 21.11](https://docs.aspose.com/slides/java/aspose-slides-for-java-21-11-release-notes/)では、[ModernComment](https://reference.aspose.com/slides/java/com.aspose.slides/ModernComment)クラスを追加することにより、モダンコメントのサポートを実装しました。[addModernComment](https://reference.aspose.com/slides/java/com.aspose.slides/CommentCollection#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-)と[insertModernComment](https://reference.aspose.com/slides/java/com.aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-)メソッドが[CommentCollection](https://reference.aspose.com/slides/java/com.aspose.slides/CommentCollection)クラスに追加されました。

このJavaコードは、PowerPointプレゼンテーションのスライドにモダンコメントを追加する方法を示しています：

```java
Presentation pres = new Presentation();
try {
    ICommentAuthor newAuthor = pres.getCommentAuthors().addAuthor("Some Author", "SA");
    IModernComment modernComment = newAuthor.getComments().addModernComment("これはモダンコメントです", pres.getSlides().get_Item(0), null, new Point2D.Float(100, 100), new Date());

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **コメントを削除**

### **すべてのコメントと著者を削除**

このJavaコードは、プレゼンテーション内のすべてのコメントと著者を削除する方法を示しています：

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

### **特定のコメントを削除**

このJavaコードは、スライド上の特定のコメントを削除する方法を示しています：

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // コメントを追加...
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("著者", "A");
    author.getComments().addComment("コメント1", slide, new Point2D.Float(0.2f, 0.2f), new Date());
    author.getComments().addComment("コメント2", slide, new Point2D.Float(0.3f, 0.2f), new Date());

    // "コメント1"というテキストを含むすべてのコメントを削除
    for (ICommentAuthor commentAuthor : presentation.getCommentAuthors())
    {
        ArrayList<IComment> toRemove = new ArrayList<IComment>();
        for (IComment comment : slide.getSlideComments(commentAuthor))
        {
            if (comment.getText().equals("コメント1"))
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