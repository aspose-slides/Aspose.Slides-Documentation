---
title: JavaScript でプレゼンテーションコメントを管理する
linktitle: プレゼンテーションコメント
type: docs
weight: 100
url: /ja/nodejs-java/presentation-comments/
keywords:
- コメント
- モダンコメント
- PowerPoint コメント
- プレゼンテーション コメント
- スライド コメント
- コメントの追加
- コメントへのアクセス
- コメントの編集
- コメントへの返信
- コメントの削除
- コメントの削除
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js を使用してプレゼンテーションコメントをマスターし、JavaScript で PowerPoint ファイルのコメントを高速かつ簡単に追加、読み取り、編集、削除できます。"
---

PowerPoint では、コメントはスライド上のメモまたは注釈として表示されます。コメントをクリックすると、内容やメッセージが表示されます。

## **プレゼンテーションにコメントを追加する理由**

プレゼンテーションをレビューする際に、フィードバックを提供したり同僚とやり取りしたりするためにコメントを使用したい場合があります。

PowerPoint プレゼンテーションでコメントを使用できるように、Aspose.Slides for Node.js via Java は次の機能を提供します

* [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスは、[CommentAuthorCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentAuthorCollection) からの著者コレクションを含みます。著者はスライドにコメントを追加します。
* [CommentCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentCollection) クラスは、個々の著者向けのコメントコレクションを含みます。
* [Comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment) クラスは、著者とそのコメントに関する情報（コメントを追加した人、追加日時、コメントの位置など）を含みます。
* [CommentAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentAuthor) クラスは、個々の著者に関する情報（著者名、イニシャル、著者名に関連付けられたコメントなど）を含みます。

## **スライドコメントの追加**
この JavaScript コードは、PowerPoint プレゼンテーションのスライドにコメントを追加する方法を示します。
```javascript
// Presentation クラスのインスタンスを作成します
var pres = new aspose.slides.Presentation();
try {
    // 空のスライドを追加します
    pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    // 著者を追加します
    var author = pres.getCommentAuthors().addAuthor("Jawad", "MF");
    // コメントの位置を設定します
    var point = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.2), java.newFloat(0.2));
    // スライド 1 の著者に対してスライドコメントを追加します
    author.getComments().addComment("Hello Jawad, this is slide comment", pres.getSlides().get_Item(0), point, java.newInstanceSync("java.util.Date"));
    // スライド 2 の著者に対してスライドコメントを追加します
    author.getComments().addComment("Hello Jawad, this is second slide comment", pres.getSlides().get_Item(1), point, java.newInstanceSync("java.util.Date"));
    // ISlide 1 にアクセスします
    var slide = pres.getSlides().get_Item(0);
    // 引数に null を渡すと、すべての著者のコメントが選択したスライドに取得されます
    var Comments = slide.getSlideComments(author);
    // スライド 1 のインデックス 0 のコメントにアクセスします
    var str = Comments[0].getText();
    pres.save("Comments_out.pptx", aspose.slides.SaveFormat.Pptx);
    if (Comments.length > 0) {
        // インデックス 0 の著者のコメントコレクションを選択します
        var commentCollection = Comments[0].getAuthor().getComments();
        var Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **スライドコメントへのアクセス**
この JavaScript コードは、PowerPoint プレゼンテーションのスライド上の既存のコメントにアクセスする方法を示します。
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
親コメントは、コメントや返信の階層における最上位または元のコメントです。[getParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment#getParentComment--) または [setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment#setParentComment-aspose.slides.IComment-) メソッド（[Comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment) クラス）を使用して、親コメントを取得または設定できます。

この JavaScript コードは、コメントを追加し、それへの返信を取得する方法を示します。
```javascript
var pres = new aspose.slides.Presentation();
try {
    // コメントを追加
    var author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    var comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    // comment1 に対する返信を追加
    var author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    var reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply1.setParentComment(comment1);
    // comment1 に対する別の返信を追加
    var reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply2.setParentComment(comment1);
    // 既存の返信に対する返信を追加
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
    // comment1 とそのすべての返信を削除
    comment1.remove();
    pres.save("remove_comment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="warning" title="注意" %}} 

* [Remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment#remove--) メソッド（[Comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment) クラス）を使用してコメントを削除すると、コメントへの返信も削除されます。
* [setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment#setParentComment-aspose.slides.IComment-) の設定で循環参照が発生した場合、[PptxEditException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PptxEditException) がスローされます。

{{% /alert %}}

## **モダンコメントの追加**

2021 年、Microsoft は PowerPoint に *モダンコメント* を導入しました。モダンコメント機能は PowerPoint におけるコラボレーションを大幅に向上させます。モダンコメントにより、PowerPoint ユーザーはコメントを解決したり、オブジェクトやテキストにコメントを固定したり、以前よりもはるかに簡単にやり取りできるようになります。

Aspose.Slides は [ModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ModernComment) クラスによりモダンコメントをサポートします。[CommentCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentCollection) クラスに [addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentCollection#addModernComment-java.lang.String-aspose.slides.ISlide-aspose.slides.IShape-java.awt.geom.Point2D$Float-java.util.Date-) および [insertModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-aspose.slides.ISlide-aspose.slides.IShape-java.awt.geom.Point2D$Float-java.util.Date-) メソッドが追加されました。

この JavaScript コードは、PowerPoint プレゼンテーションのスライドにモダンコメントを追加する方法を示します。
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

### **すべてのコメントと作者の削除**

この JavaScript コードは、プレゼンテーション内のすべてのコメントと作者を削除する方法を示します。
```javascript
var presentation = new aspose.slides.Presentation("example.pptx");
try {
    // プレゼンテーションからすべてのコメントを削除します
    for (let i = 0; i < presentation.getCommentAuthors().size(); i++) {
    var author = presentation.getCommentAuthors().get_Item(i)
        author.getComments().clear();
    }
    // すべての著者を削除します
    presentation.getCommentAuthors().clear();
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


### **特定のコメントの削除**

この JavaScript コードは、スライド上の特定のコメントを削除する方法を示します。
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

**Aspose.Slides はモダンコメントに対して「解決済み」などのステータスをサポートしていますか？**

はい。[Modern comments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/) は [getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/) と [setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setStatus/) メソッドを提供します。コメントの状態（例：解決済みとしてマーク）を取得および設定でき、この状態はファイルに保存され、PowerPoint に認識されます。

**スレッド化されたディスカッション（返信チェーン）はサポートされていますか？ また、ネストの上限はありますか？**

はい。各コメントは [parent comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/getparentcomment/) を参照できるため、任意の深さの返信チェーンが可能です。API では特定のネスト深さの上限は明示されていません。

**スライド上のコメントマーカーの位置はどの座標系で定義されていますか？**

位置はスライドの座標系における浮動小数点のポイントとして保存されます。これにより、コメントマーカーを必要な正確な場所に配置できます。