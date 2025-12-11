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
- コメントを削除
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用してプレゼンテーション コメントをマスターし、PowerPoint ファイル内のコメントを迅速かつ簡単に追加、読み取り、編集、削除できます。"
---

PowerPoint では、コメントはスライド上のメモまたは注釈として表示されます。コメントをクリックすると、その内容やメッセージが表示されます。

### **プレゼンテーションにコメントを追加する理由は？**

プレゼンテーションをレビューする際に、フィードバックを提供したり同僚とやり取りしたりするためにコメントを使用したい場合があります。

PowerPoint プレゼンテーションでコメントを使用できるように、Aspose.Slides for Android via Java は以下を提供します。

* [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスは、著者コレクション（[ICommentAuthorCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICommentAuthorCollection) インターフェイス）を含みます。著者はスライドにコメントを追加します。
* [ICommentCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICommentCollection) インターフェイスは、個々の著者に対するコメントのコレクションを保持します。
* [IComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment) クラスは、著者とそのコメントに関する情報（コメントを追加した人、追加時刻、コメントの位置など）を含みます。
* [CommentAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommentAuthor) クラスは、個々の著者に関する情報（著者名、イニシャル、著者名に紐づくコメントなど）を保持します。

## **スライド コメントの追加**
次の Java コードは、PowerPoint プレゼンテーションのスライドにコメントを追加する方法を示しています。
```java
// Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // 空のスライドを追加します
    pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    // 著者を追加します
    ICommentAuthor author = pres.getCommentAuthors().addAuthor("Jawad", "MF");

    // コメントの位置を設定します
    Point2D.Float point = new Point2D.Float(0.2f, 0.2f);

    // スライド 1 の著者用スライドコメントを追加します
    author.getComments().addComment("Hello Jawad, this is slide comment", pres.getSlides().get_Item(0), point, new Date());

    // スライド 2 の著者用スライドコメントを追加します
    author.getComments().addComment("Hello Jawad, this is second slide comment", pres.getSlides().get_Item(1), point, new Date());

    // ISlide 1 にアクセスします
    ISlide slide = pres.getSlides().get_Item(0);

    // 引数に null を渡すと、すべての著者のコメントが選択されたスライドに取得されます
    IComment[] Comments = slide.getSlideComments(author);

    // スライド 1 のインデックス 0 のコメントにアクセスします
    String str = Comments[0].getText();

    pres.save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.length > 0)
    {
        // インデックス 0 の著者のコメントコレクションを選択します
        ICommentCollection commentCollection = Comments[0].getAuthor().getComments();
        String Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **スライド コメントへのアクセス**
次の Java コードは、PowerPoint プレゼンテーションのスライド上に既存のコメントにアクセスする方法を示しています。
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
親コメントは、コメントや返信の階層構造における最上位（元）コメントです。[IComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment) インターフェイスの [getParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment#getParentComment--) または [setParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) メソッドを使用して、親コメントの取得または設定ができます。

次の Java コードは、コメントを追加し、その返信を取得する方法を示しています。
```java
Presentation pres = new Presentation();
try {
    // コメントを追加します
    ICommentAuthor author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    // comment1 への返信を追加します
    ICommentAuthor author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply1.setParentComment(comment1);

    // comment1 への別の返信を追加します
    IComment reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    reply2.setParentComment(comment1);

    // 既存の返信に対して返信を追加します
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

    // comment1 とそれへのすべての返信を削除します
    comment1.remove();

    pres.save("remove_comment.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="warning" title="Attention" %}} 

* [IComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment) インターフェイスの [Remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment#remove--) メソッドでコメントを削除すると、そのコメントへの返信もすべて削除されます。
* [setParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) の設定が循環参照を生じさせた場合、[PptxEditException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PptxEditException) がスローされます。

{{% /alert %}}

## **モダン コメントの追加**

2021 年に Microsoft は PowerPoint に *モダン コメント* を導入しました。モダン コメント機能は PowerPoint におけるコラボレーションを大幅に向上させます。モダン コメントを使用すると、コメントの解決、オブジェクトやテキストへのコメントの固定、そして従来よりもずっと簡単にやり取りが行えるようになります。

[Aspose Slides for Java 21.11](https://docs.aspose.com/slides/androidjava/aspose-slides-for-java-21-11-release-notes/) では、[ModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ModernComment) クラスを追加してモダン コメントのサポートを実装しました。[CommentCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommentCollection) クラスに [addModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommentCollection#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) と [insertModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) メソッドが追加されました。

次の Java コードは、PowerPoint プレゼンテーションのスライドにモダン コメントを追加する方法を示しています。 
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

次の Java コードは、プレゼンテーション内のすべてのコメントと著者を削除する方法を示しています。
```java
Presentation presentation = new Presentation("example.pptx");
try {
    // プレゼンテーション内のすべてのコメントを削除します
    for (ICommentAuthor author : presentation.getCommentAuthors())
    {
        author.getComments().clear();
    }

    // すべての著者を削除します
    presentation.getCommentAuthors().clear();

    presentation.save("example_out.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


### **特定のコメントを削除**

次の Java コードは、スライド上の特定のコメントを削除する方法を示しています。
```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // コメントを追加します...
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comment 1", slide, new Point2D.Float(0.2f, 0.2f), new Date());
    author.getComments().addComment("comment 2", slide, new Point2D.Float(0.3f, 0.2f), new Date());

    // "comment 1" を含むすべてのコメントを削除します
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

**Aspose.Slides はモダン コメントに「解決済み」などのステータスをサポートしていますか？**

はい。[Modern comments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/moderncomment/) は [setStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/moderncomment/#setStatus-byte-) メソッドを公開しており、コメントの状態（例: 解決済みとしてマーク）を書き込むことができます。この状態はファイルに保存され、PowerPoint でも認識されます。

**スレッド化されたディスカッション（返信チェーン）はサポートされていますか？また、入れ子の上限はありますか？**

はい。各コメントは [parent comment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/comment/#getParentComment--) を参照できるため、任意の深さの返信チェーンを構築できます。API には具体的な入れ子深さの制限は定義されていません。

**スライド上のコメントマーカーの位置はどの座標系で定義されていますか？**

位置はスライドの座標系における浮動小数点のポイントとして保存されます。これにより、コメントマーカーを必要な正確な場所に配置できます。