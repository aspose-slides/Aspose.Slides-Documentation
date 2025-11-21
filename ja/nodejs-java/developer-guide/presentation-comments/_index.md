---
title: プレゼンテーション コメント
type: docs
weight: 100
url: /ja/nodejs-java/presentation-comments/
keywords: "コメント, PowerPoint コメント, PowerPoint プレゼンテーション, Java, Aspose.Slides for Node.js via Java"
description: "JavaScript で PowerPoint プレゼンテーションにコメントと返信を追加する"
---

PowerPoint では、コメントはスライド上のメモや注釈として表示されます。コメントをクリックすると、内容やメッセージが表示されます。

## **プレゼンテーションにコメントを追加する理由**

プレゼンテーションをレビューするときに、フィードバックを提供したり同僚とやり取りしたりするためにコメントを使用したい場合があります。

PowerPoint プレゼンテーションでコメントを使用できるように、Aspose.Slides for Node.js via Java は次を提供します。

* [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスは、[CommentAuthorCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentAuthorCollection) クラスからの著者コレクションを含みます。著者はスライドにコメントを追加します。
* [CommentCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentCollection) クラスは、個々の著者向けのコメントコレクションを含みます。
* [Comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment) クラスは、著者とコメントに関する情報（コメントを追加した人物、追加日時、コメントの位置など）を含みます。
* [CommentAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentAuthor) クラスは、個々の著者に関する情報（著者名、イニシャル、著者名に関連付けられたコメントなど）を含みます。

## **スライド コメントの追加**
この JavaScript コードは、PowerPoint プレゼンテーションのスライドにコメントを追加する方法を示します:
```javascript
// Presentation クラスのインスタンス化
var pres = new aspose.slides.Presentation();
try {
    // 空のスライドを追加
    pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    // 作成者を追加
    var author = pres.getCommentAuthors().addAuthor("Jawad", "MF");
    // コメントの位置を設定
    var point = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.2), java.newFloat(0.2));
    // スライド1の作成者にスライド コメントを追加
    author.getComments().addComment("Hello Jawad, this is slide comment", pres.getSlides().get_Item(0), point, java.newInstanceSync("java.util.Date"));
    // スライド2の作成者にスライド コメントを追加
    author.getComments().addComment("Hello Jawad, this is second slide comment", pres.getSlides().get_Item(1), point, java.newInstanceSync("java.util.Date"));
    // ISlide 1 にアクセス
    var slide = pres.getSlides().get_Item(0);
    // null を引数として渡すと、すべての作成者のコメントが選択されたスライドに取得される
    var Comments = slide.getSlideComments(author);
    // スライド1のインデックス0のコメントにアクセス
    var str = Comments[0].getText();
    pres.save("Comments_out.pptx", aspose.slides.SaveFormat.Pptx);
    if (Comments.length > 0) {
        // インデックス0の作成者のコメントコレクションを選択
        var commentCollection = Comments[0].getAuthor().getComments();
        var Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **スライド コメントへのアクセス**
この JavaScript コードは、PowerPoint プレゼンテーションのスライドにある既存のコメントにアクセスする方法を示します:
```javascript
var pres = new aspose.slides.Presentation("Comments1.pptx");
try {
    for (let i = 0; i < pres.getCommentAuthors().size(); i++) {
        let commentAuthor = pres.getCommentAuthors().get_Item(i);
        for (let j = 0; j < commentAuthor.getComments().size(); j++) {
            const comment = commentAuthor.getComments().get_Item(j);
            console.log("ISlide :" + comment.getSlide().getSlideNumber() + " has comment: " + comment.getText() + " with Author: " + comment.getAuthor().getName() + " posted on time :" + comment.getCreatedTime() + "\n");
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **コメントへの返信**
親コメントは、コメントや返信の階層で最上位または元のコメントです。[Comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment) クラスの [getParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment#getParentComment--) または [setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment#setParentComment-aspose.slides.IComment-) メソッドを使用して、親コメントを取得または設定できます。

この JavaScript コードは、コメントを追加しそれへの返信を取得する方法を示します:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // コメントを追加
    var author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    var comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    // comment1 への返信を追加
    var author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    var reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply1.setParentComment(comment1);
    // comment1 への別の返信を追加
    var reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply2.setParentComment(comment1);
    // 既存の返信に対して返信を追加
    var subReply = author1.getComments().addComment("subreply 3 for reply 2", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    subReply.setParentComment(reply2);
    var comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    var comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    var reply3 = author1.getComments().addComment("reply 4 for comment 3", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply3.setParentComment(comment3);
    // コンソールにコメント階層を表示
    var slide = pres.getSlides().get_Item(0);
    var comments = slide.getSlideComments(null);
    for (var i = 0; i < comments.length; i++) {
        var comment = comments[i];
        while (comment.getParentComment() != null) {
            console.log("\t");
            comment = comment.getParentComment();
        }
        console.log((comments[i].getAuthor().getName() + " : ") + comments[i].getText());
        console.log();
    }
    pres.save("parent_comment.pptx", aspose.slides.SaveFormat.Pptx);
    // comment1 とそれへのすべての返信を削除
    comment1.remove();
    pres.save("remove_comment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="warning" title="Attention" %}} 
* [Comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment) クラスの [Remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment#remove--) メソッドでコメントを削除すると、コメントへの返信も削除されます。
* [setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment#setParentComment-aspose.slides.IComment-) の設定により循環参照が発生した場合、[PptxEditException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PptxEditException) がスローされます。
{{% /alert %}}

## **モダン コメントの追加**

2021 年に Microsoft は PowerPoint に *モダン コメント* を導入しました。モダン コメント機能は PowerPoint におけるコラボレーションを大幅に改善します。モダン コメントにより、コメントの解決、オブジェクトやテキストへのコメントの固定、そして以前よりもはるかに簡単にやり取りできるようになりました。

[Aspose.Slides for Node.js via Java 21.11](https://docs.aspose.com/slides/nodejs-java/aspose-slides-for-java-21-11-release-notes/) では、[ModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ModernComment) クラスを追加してモダン コメントのサポートを実装しました。[CommentCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentCollection) クラスに [addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentCollection#addModernComment-java.lang.String-aspose.slides.ISlide-aspose.slides.IShape-java.awt.geom.Point2D$Float-java.util.Date-) および [insertModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-aspose.slides.ISlide-aspose.slides.IShape-java.awt.geom.Point2D$Float-java.util.Date-) メソッドが追加されました。

この JavaScript コードは、PowerPoint プレゼンテーションのスライドにモダン コメントを追加する方法を示します:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var newAuthor = pres.getCommentAuthors().addAuthor("Some Author", "SA");
    var modernComment = newAuthor.getComments().addModernComment("This is a modern comment", pres.getSlides().get_Item(0), null, java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(100), java.newFloat(100)), java.newInstanceSync("java.util.Date"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **コメントの削除**

### **すべてのコメントと著者の削除**

この JavaScript コードは、プレゼンテーション内のすべてのコメントと著者を削除する方法を示します:
```javascript
var presentation = new aspose.slides.Presentation("example.pptx");
try {
    // プレゼンテーションからすべてのコメントを削除
    for (let i = 0; i < presentation.getCommentAuthors().size(); i++) {
    var author = presentation.getCommentAuthors().get_Item(i)
        author.getComments().clear();
    }
    // すべての著者を削除
    presentation.getCommentAuthors().clear();
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


### **特定のコメントの削除**

この JavaScript コードは、スライド上の特定のコメントを削除する方法を示します:
```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    // コメントを追加...
    var author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comment 1", slide, java.newInstanceSync("com.aspose.slides.Point2DFloat",  java.newFloat(0.2), java.newFloat(0.2)), java.newInstanceSync("java.util.Date"));
    author.getComments().addComment("comment 2", slide, java.newInstanceSync("com.aspose.slides.Point2DFloat",  java.newFloat(0.3), java.newFloat(0.2)), java.newInstanceSync("java.util.Date"));
    // 「comment 1」を含むすべてのコメントを削除
    
    
    for (var i = 0; i < presentation.getCommentAuthors().length; i++) {
        var commentAuthor = presentation.getCommentAuthors().get_Item(i);
        var toRemove = java.newInstanceSync("java.util.ArrayList");
        for (let j = 0; j < slide.getSlideComments(commentAuthor).size(); j++) {
            let comment = slide.getSlideComments(commentAuthor).get_Item(j);
            if (comment.getText() === "comment 1") {
                toRemove.add(comment);
            }
        }
        for (var i = 0; i < toRemove.length; i++) {
            var comment = toRemove.get_Item(i);
            commentAuthor.getComments().remove(comment);
        }
    }
    presentation.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **FAQ**

**Aspose.Slides はモダン コメントに「解決済み」などのステータスをサポートしていますか？**

はい。[Modern comments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/) は [getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/) および [setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setStatus/) メソッドを公開しています。コメントの状態 (例: 解決済みとしてマーク) を取得および設定でき、この状態はファイルに保存され PowerPoint で認識されます。

**スレッド化されたディスカッション (返信チェーン) はサポートされていますか？ネストの上限はありますか？**

はい。各コメントは [parent comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/getparentcomment/) を参照できるため、任意の深さの返信チェーンを作成できます。API では特定のネスト深さ上限は宣言されていません。

**コメント マーカーの位置はスライドのどの座標系で定義されていますか？**

位置はスライド座標系の浮動小数点ポイントとして保存されます。これにより、コメント マーカーを必要な正確な位置に配置できます。