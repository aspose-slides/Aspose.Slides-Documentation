---
title: PHPでプレゼンテーションコメントを管理
linktitle: プレゼンテーションコメント
type: docs
weight: 100
url: /ja/php-java/presentation-comments/
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
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用してプレゼンテーションコメントを管理します。PowerPoint プレゼンテーション内のコメントを簡単かつ迅速に追加、読み取り、編集、返信、削除できます。"
---
## **概要**

この記事では、Aspose.Slides for PHP via Java を使用してプレゼンテーションのコメントを管理する方法を説明します。主なコメント関連の型を紹介し、スライドへのコメントの追加、既存コメントへのアクセス、返信やモダンコメントの操作、プレゼンテーションからのコメント削除の手順を実演します。

例では、PowerPoint の一般的なレビューおよび共同作業シナリオ、たとえばコメントの作成者への割り当て、コメント本文やメタデータの読み取り、返信チェーンの構築、選択したコメントまたはすべてのコメントの削除などを取り上げています。

PowerPoint では、コメントはスライド上の注釈として表示されます。コメントを選択すると、そのテキストと関連するディスカッションが表示されます。

## **プレゼンテーションにコメントを追加する理由**

プレゼンテーションのレビュー時に、コメントを使用してフィードバックを提供したり、同僚と共同作業したりできます。

Aspose.Slides for PHP via Java は、コメント操作のために以下の API を提供します。

* The [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスは、プレゼンテーションのコメント作成者へのアクセスを提供します。
* The [CommentCollection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/commentcollection/) クラスは、個々の作成者に関連付けられたコメントを表します。
* The [Comment](https://reference.aspose.com/slides/ja/php-java/aspose.slides/comment/) クラスは、作成者、作成時刻、位置、テキストなど、コメントに関する情報を提供します。
* The [CommentAuthor](https://reference.aspose.com/slides/ja/php-java/aspose.slides/commentauthor/) クラスは、名前、イニシャル、関連コメントなど、作成者に関する情報を提供します。

## **スライドコメントの追加**

以下の例は、PowerPoint プレゼンテーションのスライドにコメントを追加する方法を示します：

```php
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $secondSlide = $presentation->getSlides()->addEmptySlide($presentation->getLayoutSlides()->get_Item(0));
    $author = $presentation->getCommentAuthors()->addAuthor("Jawad", "MF");
    $position = new Point2DFloat(0.2, 0.2);
    $createdTime = new Java("java.util.Date");

    $author->getComments()->addComment("Hello Jawad, this is a slide comment", $firstSlide, $position, $createdTime);
    $author->getComments()->addComment("Hello Jawad, this is the second slide comment", $secondSlide, $position, $createdTime);

    $comments = $firstSlide->getSlideComments($author);
    $arrayClass = new JavaClass("java.lang.reflect.Array");
    $commentCount = java_values($arrayClass->getLength($comments));
    if ($commentCount > 0) {
        $firstComment = $comments[0];
        echo java_values($firstComment->getText()) . PHP_EOL;

        $authorComments = $firstComment->getAuthor()->getComments();
        $commentText = $authorComments->get_Item(0)->getText();
        echo java_values($commentText) . PHP_EOL;
    }

    $presentation->save("Comments_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **スライドコメントへのアクセス**

以下の例は、PowerPoint プレゼンテーション内の既存コメントにアクセスする方法を示します：

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Comments1.pptx");
try {
    foreach ($presentation->getCommentAuthors() as $author) {
        foreach ($author->getComments() as $comment) {
            echo "Slide: " . java_values($comment->getSlide()->getSlideNumber()) . PHP_EOL;
            echo "Comment: " . java_values($comment->getText()) . PHP_EOL;
            echo "Author: " . java_values($comment->getAuthor()->getName()) . PHP_EOL;
            echo "Posted at: " . java_values($comment->getCreatedTime()->toString()) . PHP_EOL;
            echo PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **コメントへの返信**

親コメントとは、返信階層の最上位にある元のコメントです。 [Comment::getParentComment](https://reference.aspose.com/slides/ja/php-java/aspose.slides/comment/getparentcomment/) および [Comment::setParentComment](https://reference.aspose.com/slides/ja/php-java/aspose.slides/comment/setparentcomment/) メソッドを使用して、コメントの親を取得または設定できます。

以下の例は、返信を追加し、生成されたコメント階層を検査する方法を示します：

```php
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $position = new Point2DFloat(10, 10);
    $createdTime = new Java("java.util.Date");

    $author1 = $presentation->getCommentAuthors()->addAuthor("Author_1", "A.A.");
    $comment1 = $author1->getComments()->addComment("comment 1", $slide, $position, $createdTime);

    $author2 = $presentation->getCommentAuthors()->addAuthor("Author_2", "B.B.");
    $reply1 = $author2->getComments()->addComment("reply 1 for comment 1", $slide, $position, $createdTime);
    $reply1->setParentComment($comment1);

    $reply2 = $author2->getComments()->addComment("reply 2 for comment 1", $slide, $position, $createdTime);
    $reply2->setParentComment($comment1);

    $subReply = $author1->getComments()->addComment("subreply 3 for reply 2", $slide, $position, $createdTime);
    $subReply->setParentComment($reply2);

    $author2->getComments()->addComment("comment 2", $slide, $position, $createdTime);
    $comment3 = $author2->getComments()->addComment("comment 3", $slide, $position, $createdTime);

    $reply3 = $author1->getComments()->addComment("reply 4 for comment 3", $slide, $position, $createdTime);
    $reply3->setParentComment($comment3);

    $comments = $slide->getSlideComments(null);
    $arrayClass = new JavaClass("java.lang.reflect.Array");
    $commentCount = java_values($arrayClass->getLength($comments));
    for ($i = 0; $i < $commentCount; $i++) {
        $comment = $comments[$i];
        while (!java_is_null($comment->getParentComment())) {
            echo "\t";
            $comment = $comment->getParentComment();
        }

        echo java_values($comments[$i]->getAuthor()->getName()) . ": " . java_values($comments[$i]->getText()) . PHP_EOL;
    }

    $presentation->save("parent_comment.pptx", SaveFormat::Pptx);

    $comment1->remove();
    $presentation->save("remove_comment.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert color="warning" title="Warning" %}}
* When the [Comment::remove](https://reference.aspose.com/slides/ja/php-java/aspose.slides/comment/remove/) メソッドが使用されてコメントを削除すると、そのコメントへのすべての返信も削除されます。
* If [Comment::setParentComment](https://reference.aspose.com/slides/ja/php-java/aspose.slides/comment/setparentcomment/) が循環参照を作成した場合、[PptxEditException](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pptxeditexception/) がスローされます。
{{% /alert %}}

## **モダンコメントの追加**

モダンコメントは、スライド自体、特定のシェイプ、または AutoShape 内のテキスト範囲に関連付けることができます。 [CommentCollection::addModernComment](https://reference.aspose.com/slides/ja/php-java/aspose.slides/commentcollection/addmoderncomment/) メソッドは、スライドとコメントマーカー座標に加えて [Shape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/) 引数を受け取ります。

`null` がシェイプ引数として渡された場合、コメントはスライドレベルのコメントになります。マーカーは指定された座標で配置されますが、特定のシェイプには紐付いていないため、[ModernComment::getShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/moderncomment/getshape/) は `null` を返します。シェイプが指定された場合、コメントはそのシェイプにアンカーされます。座標は依然としてスライド上のマーカー位置を定義し、シェイプの関連付けは [ModernComment::getShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/moderncomment/getshape/) で取得できます。

### **モダンコメントをシェイプにアンカーする**

以下の例は、スライドレベルのモダンコメントと、特定の AutoShape にアンカーされたモダンコメントの両方を作成し、各コメントから関連シェイプを取得します。

```php
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $author = $presentation->getCommentAuthors()->addAuthor("Reviewer", "RV");
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 300, 80);
    $shape->setName("Revenue title");
    $shape->getTextFrame()->setText("Quarterly revenue");

    $createdTime = new Java("java.util.Date");
    $slideCommentPosition = new Point2DFloat(20, 20);
    $shapeCommentPosition = new Point2DFloat(60, 60);
    $slideComment = $author->getComments()->addModernComment("Review the overall slide layout.", $slide, null, $slideCommentPosition, $createdTime);
    $shapeComment = $author->getComments()->addModernComment("Check this title.", $slide, $shape, $shapeCommentPosition, $createdTime);

    echo (java_is_null($slideComment->getShape()) ? "true" : "false") . PHP_EOL;
    echo java_values($shapeComment->getShape()->getName()) . PHP_EOL;

    $presentation->save("modern_comments.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **異なるシェイプタイプへのコメントのアンカー**

[Shape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/) クラスで表される任意のスライドオブジェクトをシェイプアンカーとして使用できます。代表的な例として [AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/)、[PictureFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pictureframe/)、[GroupShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/groupshape/)、[Connector](https://reference.aspose.com/slides/ja/php-java/aspose.slides/connector/)、およびチャートなどの [GraphicalObject](https://reference.aspose.com/slides/ja/php-java/aspose.slides/graphicalobject/) インスタンスがあります。

以下の例は、いくつかの一般的なシェイプタイプを作成し、各シェイプにモダンコメントを関連付けます。

```php
use aspose\slides\ChartType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $author = $presentation->getCommentAuthors()->addAuthor("Reviewer", "RV");
    $createdTime = new Java("java.util.Date");

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 180, 60);
    $autoShape->getTextFrame()->setText("AutoShape");
    $autoShapeCommentPosition = new Point2DFloat(30, 30);
    $author->getComments()->addModernComment("Comment on an AutoShape.", $slide, $autoShape, $autoShapeCommentPosition, $createdTime);

    $imageBase64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
    $base64Class = new JavaClass("java.util.Base64");
    $imageData = $base64Class->getDecoder()->decode($imageBase64);
    $image = $presentation->getImages()->addImage($imageData);
    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 220, 20, 120, 80, $image);
    $pictureCommentPosition = new Point2DFloat(230, 30);
    $author->getComments()->addModernComment("Comment on a picture.", $slide, $pictureFrame, $pictureCommentPosition, $createdTime);

    $groupShape = $slide->getShapes()->addGroupShape();
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, 80, 40);
    $groupShape->getShapes()->addAutoShape(ShapeType::Ellipse, 100, 0, 80, 40);
    $groupCommentPosition = new Point2DFloat(40, 150);
    $author->getComments()->addModernComment("Comment on a group.", $slide, $groupShape, $groupCommentPosition, $createdTime);

    $connector = $slide->getShapes()->addConnector(ShapeType::StraightConnector1, 220, 150, 140, 40);
    $connectorCommentPosition = new Point2DFloat(240, 150);
    $author->getComments()->addModernComment("Comment on a connector.", $slide, $connector, $connectorCommentPosition, $createdTime);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 400, 20, 250, 180);
    $chartCommentPosition = new Point2DFloat(420, 40);
    $author->getComments()->addModernComment("Comment on a graphical object.", $slide, $chart, $chartCommentPosition, $createdTime);

    $presentation->save("modern_comment_shape_types.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **テキストへのコメントのアンカーとステータス設定**

[AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/) に関連付けられたモダンコメントの場合、[ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/ja/php-java/aspose.slides/moderncomment/gettextselectionstart/) および [ModernComment::setTextSelectionStart](https://reference.aspose.com/slides/ja/php-java/aspose.slides/moderncomment/settextselectionstart/) はシェイプのテキストフレーム内で選択されたテキストの開始位置にアクセスします。[ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/ja/php-java/aspose.slides/moderncomment/gettextselectionlength/) と [ModernComment::setTextSelectionLength](https://reference.aspose.com/slides/ja/php-java/aspose.slides/moderncomment/settextselectionlength/) は選択範囲の長さにアクセスします。これらの値を組み合わせることで、コメントを AutoShape 内の特定のテキスト範囲に関連付けます。

[ModernComment::getStatus](https://reference.aspose.com/slides/ja/php-java/aspose.slides/moderncomment/getstatus/) および [ModernComment::setStatus](https://reference.aspose.com/slides/ja/php-java/aspose.slides/moderncomment/setstatus/) メソッドは、[ModernCommentStatus](https://reference.aspose.com/slides/ja/php-java/aspose.slides/moderncommentstatus/) 定数から以下の値を取得または設定します:

- `NotDefined` — 特定のモダンコメントステータスは定義されていません。
- `Active` — コメントはアクティブです。
- `Resolved` — コメントは解決済みです。
- `Closed` — コメントはクローズされています。

以下の例は、シェイプにアンカーされたモダンコメントを作成し、テキスト選択に関連付け、解決済みとしてマークし、プレゼンテーションを保存した後にファイルを再度開いて値を検証します。

```php
use aspose\slides\ModernCommentStatus;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$outputFile = "modern_comment_text_anchor.pptx";
$shapeText = "Review the quarterly revenue forecast.";
$selectedText = "quarterly revenue";
$expectedSelectionStart = strpos($shapeText, $selectedText);

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    $shape->setName("Forecast text");
    $shape->getTextFrame()->setText($shapeText);

    $author = $presentation->getCommentAuthors()->addAuthor("Reviewer", "RV");
    $commentPosition = new Point2DFloat(60, 60);
    $comment = $author->getComments()->addModernComment("Verify this forecast wording.", $slide, $shape, $commentPosition, new Java("java.util.Date"));
    $comment->setTextSelectionStart($expectedSelectionStart);
    $comment->setTextSelectionLength(strlen($selectedText));
    $comment->setStatus(ModernCommentStatus::Resolved);

    $presentation->save($outputFile, SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation($outputFile);
try {
    $reopenedSlide = $reopenedPresentation->getSlides()->get_Item(0);
    $reopenedComments = $reopenedSlide->getSlideComments(null);
    $modernCommentClass = new JavaClass("com.aspose.slides.ModernComment");

    foreach ($reopenedComments as $reopenedComment) {
        if (!java_instanceof($reopenedComment, $modernCommentClass)) {
            continue;
        }

        $shape = $reopenedComment->getShape();
        $shapeMatches = !java_is_null($shape) && java_values($shape->getName()) === "Forecast text";
        $selectionStartMatches = java_values($reopenedComment->getTextSelectionStart()) === $expectedSelectionStart;
        $selectionLengthMatches = java_values($reopenedComment->getTextSelectionLength()) === strlen($selectedText);
        $statusMatches = java_values($reopenedComment->getStatus()) === ModernCommentStatus::Resolved;

        echo "Shape anchor preserved: " . ($shapeMatches ? "true" : "false") . PHP_EOL;
        echo "Text selection start preserved: " . ($selectionStartMatches ? "true" : "false") . PHP_EOL;
        echo "Text selection length preserved: " . ($selectionLengthMatches ? "true" : "false") . PHP_EOL;
        echo "Resolved status preserved: " . ($statusMatches ? "true" : "false") . PHP_EOL;
    }
} finally {
    $reopenedPresentation->dispose();
}
```

### **既存のモダンコメントの検査**

既存のプレゼンテーションを検査するには、各コメントが [ModernComment](https://reference.aspose.com/slides/ja/php-java/aspose.slides/moderncomment/) かどうかを確認し、[ModernComment::getShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/moderncomment/getshape/)、[ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/ja/php-java/aspose.slides/moderncomment/gettextselectionstart/)、[ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/ja/php-java/aspose.slides/moderncomment/gettextselectionlength/)、および [ModernComment::getStatus](https://reference.aspose.com/slides/ja/php-java/aspose.slides/moderncomment/getstatus/) を調べます。`null` のシェイプはスライドレベルのコメントを示します。AutoShape アンカーの場合、テキスト選択メソッドはシェイプのテキストフレーム内の該当範囲を特定します。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("comments.pptx");
try {
    $modernCommentClass = new JavaClass("com.aspose.slides.ModernComment");
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");

    foreach ($presentation->getSlides() as $slide) {
        $comments = $slide->getSlideComments(null);
        foreach ($comments as $comment) {
            if (!java_instanceof($comment, $modernCommentClass)) {
                continue;
            }

            echo "Slide: " . java_values($slide->getSlideNumber()) . PHP_EOL;
            echo "Text: " . java_values($comment->getText()) . PHP_EOL;
            echo "Status: " . java_values($comment->getStatus()) . PHP_EOL;

            $shape = $comment->getShape();
            if (java_is_null($shape)) {
                echo "Anchor: slide level" . PHP_EOL;
            } else {
                echo "Anchor shape: " . java_values($shape->getName()) . PHP_EOL;
                echo "Anchor type: " . java_values($shape->getClass()->getSimpleName()) . PHP_EOL;

                if (java_instanceof($shape, $autoShapeClass)) {
                    echo "Text selection start: " . java_values($comment->getTextSelectionStart()) . PHP_EOL;
                    echo "Text selection length: " . java_values($comment->getTextSelectionLength()) . PHP_EOL;
                }
            }

            echo PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **コメントの削除**

### **すべてのコメントとコメント作成者の削除**

以下の例は、プレゼンテーションからすべてのコメントとコメント作成者を削除する方法を示します：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("example.pptx");
try {
    foreach ($presentation->getCommentAuthors() as $author) {
        $author->getComments()->clear();
    }

    $presentation->getCommentAuthors()->clear();
    $presentation->save("example_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **特定のコメントの削除**

以下の例は、スライドから特定のコメントを削除する方法を示します：

```php
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $author = $presentation->getCommentAuthors()->addAuthor("Author", "A");
    $createdTime = new Java("java.util.Date");

    $firstCommentPosition = new Point2DFloat(0.2, 0.2);
    $secondCommentPosition = new Point2DFloat(0.3, 0.2);
    $author->getComments()->addComment("comment 1", $slide, $firstCommentPosition, $createdTime);
    $author->getComments()->addComment("comment 2", $slide, $secondCommentPosition, $createdTime);

    foreach ($presentation->getCommentAuthors() as $commentAuthor) {
        $commentsToRemove = new Java("java.util.ArrayList");
        $comments = $slide->getSlideComments($commentAuthor);

        foreach ($comments as $comment) {
            if ($comment->getText()->equals("comment 1")) {
                $commentsToRemove->add($comment);
            }
        }

        foreach ($commentsToRemove as $comment) {
            $commentAuthor->getComments()->remove($comment);
        }
    }

    $presentation->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Aspose.Slides はモダンコメントに対して解決済みステータスをサポートしていますか？**

はい。[ModernComment::getStatus](https://reference.aspose.com/slides/ja/php-java/aspose.slides/moderncomment/getstatus/) と [ModernComment::setStatus](https://reference.aspose.com/slides/ja/php-java/aspose.slides/moderncomment/setstatus/) は、`Resolved` を含む [ModernCommentStatus](https://reference.aspose.com/slides/ja/php-java/aspose.slides/moderncommentstatus/) の値にアクセスできます。ステータスはプレゼンテーションに保存され、ファイルを再度開いた後でも読み取れます。

**スレッド化されたディスカッション（返信チェーン）はサポートされていますか？また、入れ子の上限はありますか？**

はい。各コメントは [parent comment](https://reference.aspose.com/slides/ja/php-java/aspose.slides/comment/getparentcomment/) を参照できるため、返信チェーンが可能です。API には具体的な入れ子深さの上限は定義されていません。

**スライド上のコメントマーカーの位置はどの座標系で定義されていますか？**

マーカーの位置はスライド座標系の浮動小数点座標で定義されており、スライド上の任意の場所に正確に配置できます。