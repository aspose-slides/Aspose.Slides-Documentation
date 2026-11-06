---
title: PHPでプレゼンテーションコメントを管理
linktitle: プレゼンテーションコメント
type: docs
weight: 100
url: /ja/php-java/presentation-comments/
keywords:
- コメント
- モダンコメント
- PowerPointコメント
- プレゼンテーションコメント
- スライドコメント
- コメント追加
- コメントアクセス
- コメント編集
- コメント返信
- コメント削除
- コメント削除
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用してプレゼンテーションのコメントを管理します：PowerPoint プレゼンテーションでコメントを追加、読み取り、編集、返信、削除を迅速かつ簡単に行えます。"
---
## **概要**

この記事では、Aspose.Slides for PHP via Java を使用したプレゼンテーション コメントの管理方法を説明します。主なコメント関連の型を紹介し、スライドへのコメントの追加、既存コメントへのアクセス、返信およびモダン コメントの操作、プレゼンテーションからのコメントの削除を実演します。

例では、PowerPoint の一般的なレビューおよび共同作業シナリオ、たとえばコメントを作成者に割り当てる、コメントテキストとメタデータを読む、返信チェーンを構築する、選択したコメントまたはすべてのコメントを削除する、などを取り上げています。

PowerPoint では、コメントはスライド上の注釈として表示されます。コメントを選択すると、そのテキストと関連するディスカッションが表示されます。

プレゼンテーションを開くときにコメントを表示または非表示にするだけでコメント自体を変更しないようにするには、[プレゼンテーションを開くときにコメントを表示または非表示にする](/slides/ja/php-java/presentation-view-properties/) を参照してください。

## **なぜプレゼンテーションにコメントを追加するのか？**

プレゼンテーションをレビューする際に、コメントを使用してフィードバックを提供し、同僚と共同作業できます。

Aspose.Slides for PHP via Java は、コメント操作のために次の API を提供します。

* The [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスは、プレゼンテーションのコメント作成者へのアクセスを提供します。
* The [CommentCollection](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/) クラスは、個々の作成者に関連付けられたコメントを表します。
* The [Comment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/) クラスは、作成者、作成時刻、位置、テキストを含むコメント情報を提供します。
* The [CommentAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthor/) クラスは、名前、イニシャル、および関連するコメントを含む作成者情報を提供します。

## **スライド コメントの追加**

この例では、2枚のスライドを作成し、[addAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/addauthor/) でコメント作成者を登録します。[addComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addcomment/) を使用して各スライドに1つずつコメントを配置し、[getSlideComments](https://reference.aspose.com/slides/php-java/aspose.slides/slide/getslidecomments/) でその作成者の最初のスライドのコメントを取得します。コンソールは最初のコメントのテキストを2回表示し、スライドと作成者の両方からのアクセスを示し、保存されたプレゼンテーションには両方のコメントが含まれます。

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

## **コメント作成者の検索または作成**

自動レビューが同じプレゼンテーションを繰り返し処理する場合、作成者を追加する前に [getCommentAuthors](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getcommentauthors/) が返すコレクションを検索します。[findByNameAndInitials](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/findbynameandinitials/) は名前とイニシャルの両方を一致させ、該当する作成者の配列を返すか、該当がなければ空配列を返します。対照的に、[findByName](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/findbyname/) はイニシャルに関係なく名前だけで検索します。すでにコレクションに存在する名前とイニシャルで [addAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/addauthor/) を呼び出すと例外がスローされます。

この例は、少なくとも1枚のスライドを含むプレゼンテーション ファイルが必要です。2 回のパスそれぞれで、最初に一致した作成者を再利用するか、結果が空の場合にのみ新規作成します。複数の一致がある場合、他の作成者をマージまたは削除せずに最初の配列要素を選択します。その後、選択した作成者に対して [addComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addcomment/) を呼び出し、プレゼンテーションを保存します。2 回目のパスは 1 回目の出力を開き、同じ操作を繰り返します。

```php
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$authorName = "Reviewer";
$authorInitials = "RV";

$inputFile = "input.pptx";
$position = new Point2DFloat(20, 20);
$arrayClass = new JavaClass("java.lang.reflect.Array");

for ($pass = 1; $pass <= 2; $pass++) {
    $presentation = new Presentation($inputFile);
    try {
        $matches = $presentation->getCommentAuthors()->findByNameAndInitials($authorName, $authorInitials);
        $matchCount = java_values($arrayClass->getLength($matches));

        $author = $matchCount > 0 ? $matches[0] : $presentation->getCommentAuthors()->addAuthor($authorName, $authorInitials);
        $createdTime = new Java("java.util.Date");
        $author->getComments()->addComment("Please review this slide.", $presentation->getSlides()->get_Item(0), $position, $createdTime);

        $outputFile = "review_pass_" . $pass . ".pptx";
        $presentation->save($outputFile, SaveFormat::Pptx);
        $inputFile = $outputFile;
    } finally {
        $presentation->dispose();
    }
}
```

2 回目のパスは、別の作成者を追加したり既存のコメントを削除したりせずに別のコメントを追加します。最終ファイル `review_pass_2.pptx` には、新しいコメントと元のコメントの両方が含まれます。作成者を再利用してもコメントは重複排除されません。同じコメントの繰り返し追加を防ぐには、追加前に別途重複検出を実装してください。

## **スライド コメントへのアクセス**

この例は既存のプレゼンテーションを開き、[getCommentAuthors](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getcommentauthors/) が返すコレクションを読み取ります。各作成者について、[getComments](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthor/getcomments/) が返すコレクションを反復し、スライド番号、コメントテキスト、作成者名、作成時刻を出力します。入力プレゼンテーションにはコメントが含まれている必要があります。

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

親コメントは返信階層のトップにある元のコメントです。[Comment::getParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/getparentcomment/) および [Comment::setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) メソッドを使用して、コメントの親を取得または設定できます。

この例は 2 人の作成者からコメントを作成し、[setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) を使用して返信を構築し、別の返信への返信も作成します。`null` を [getSlideComments](https://reference.aspose.com/slides/php-java/aspose.slides/slide/getslidecomments/) に渡すとすべての作成者からコメントが取得されます。コンソールは返信階層の深さに応じて各エントリをインデントします。例は完全なディスカッションを保存し、最初のルートコメントに対して [remove](https://reference.aspose.com/slides/php-java/aspose.slides/comment/remove/) を呼び出し、そのコメントと返信が削除された 2 番目のプレゼンテーションを保存します。

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
* [Comment::remove](https://reference.aspose.com/slides/php-java/aspose.slides/comment/remove/) メソッドでコメントを削除すると、そのコメントへのすべての返信も削除されます。
* [Comment::setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) が循環参照を作成すると、[PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxeditexception/) がスローされます。
{{% /alert %}}

## **モダン コメントの追加**

モダン コメントはスライド自体、特定のシェイプ、または AutoShape 内のテキスト範囲に関連付けることができます。[CommentCollection::addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addmoderncomment/) メソッドは、スライドとコメントマーカー座標に加えて [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) 引数を受け取ります。

`null` をシェイプ引数に渡すと、コメントはスライドレベルのコメントになります。そのマーカーは指定された座標で配置されますが特定のシェイプには関連付けられないため、[ModernComment::getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/) は `null` を返します。[Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) が指定された場合、コメントはそのシェイプに固定されます。座標は依然としてスライド上のコメントマーカー位置を定義し、シェイプの関連付けは [ModernComment::getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/) を通じて取得できます。

### **シェイプへのモダン コメントの固定**

この例は [addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addmoderncomment/) を 2 回呼び出します。1 回目は `null` シェイプでスライドレベルのコメント、2 回目は矩形をアンカーとして使用します。[getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/) を読むと、スライドレベルコメントの `null` チェックで `true` が、アンカーされたコメントで `Revenue title` が出力されます。両方のコメントはプレゼンテーションに保存されます。

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

### **さまざまなシェイプ種別へのコメント固定**

[Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) クラスで表される任意のスライド オブジェクトをシェイプアンカーとして使用できます。一般的な例として [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/)、[PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/)、[GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/)、[Connector](https://reference.aspose.com/slides/php-java/aspose.slides/connector/)、およびチャートなどの [GraphicalObject](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobject/) インスタンスがあります。

この例は [addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addmoderncomment/) を使用して、5 つのシェイプ種別（AutoShape、画像フレーム、グループ、コネクタ、チャート）それぞれにコメントを関連付けます。画像は埋め込み画像データを使用するため、外部画像は不要です。各コメントは独自のマーカー位置を持ち、保存されたプレゼンテーションは 5 つすべてのシェイプ関連付けを保持します。

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

### **テキストへのコメント固定とステータス設定**

[AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) に関連付けられたモダン コメントの場合、[ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionstart/) と [ModernComment::setTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionstart/) はシェイプのテキストフレーム内で選択されたテキストの開始位置にアクセスします。[ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionlength/) と [ModernComment::setTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionlength/) は選択長にアクセスします。これらの値を組み合わせることで、コメントを AutoShape 内の特定テキスト範囲に関連付けます。

[ModernComment::getStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getstatus/) と [ModernComment::setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/) メソッドは、[ModernCommentStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncommentstatus/) 定数から次の値にアクセスします。

- `NotDefined` — 特定のモダン コメントステータスは未定義です。
- `Active` — コメントはアクティブです。
- `Resolved` — コメントは解決済みです。
- `Closed` — コメントはクローズされています。

この例は矩形のテキスト中の「quarterly revenue」という語句にモダン コメントを固定します。テキストからゼロベースの選択開始位置を計算し、[setTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionstart/) に渡し、[setTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionlength/) で選択文字数を設定します。`Resolved` を指定して [setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/) を呼び出した後、プレゼンテーションを保存して再度開きます。4 つのコンソールチェックはすべて `true` を出力し、シェイプアンカー、テキスト範囲、ステータスが保持されていることを確認します。

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

### **既存モダン コメントの検査**

この例はモダン コメントを含む既存のプレゼンテーションを必要とし、コメントのテキスト、ステータス、アンカーの詳細を出力します。各コメントが [ModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/) かどうかを確認し、[ModernComment::getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/)、[ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionstart/)、[ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionlength/)、[ModernComment::getStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getstatus/) を調べます。`null` シェイプはスライドレベルのコメントを示します。[AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) のアンカーの場合、テキスト選択メソッドがシェイプのテキストフレーム内の対象範囲を特定します。

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

Aspose.Slides for PHP via Java を使用すると、プレゼンテーションからすべてのコメントと作成者を削除するか、特定のコメントだけを削除して残りを保持することができます。以下の例は両方のアプローチを示し、更新されたプレゼンテーションを保存します。

### **すべてのコメントとコメント作成者の削除**

この例は既存のプレゼンテーションを開き、各作成者に対して [CommentCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/clear/) を呼び出し、続いて [CommentAuthorCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/clear/) で作成者自体も削除します。保存されたプレゼンテーションにはコメントもコメント作成者も含まれません。コメントを含むプレゼンテーションで削除を確認してください。

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

この例は1枚のスライドに2つのコメントを作成し、[getSlideComments](https://reference.aspose.com/slides/php-java/aspose.slides/slide/getslidecomments/) を使用して各作成者のコメントを取得します。テキストが「comment 1」と等しいコメントを収集し、[CommentCollection::remove](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/remove/) を呼び出す前に選択します。これにより、選択中にコレクションが変更されるのを防ぎます。保存されたプレゼンテーションには「comment 2」のみが残ります。

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

**Does Aspose.Slides support a resolved status for modern comments?**

はい。[ModernComment::getStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getstatus/) と [ModernComment::setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/) は `Resolved` を含む [ModernCommentStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncommentstatus/) の値にアクセスします。このステータスはプレゼンテーションに保存され、ファイルを再度開いた後でも読み取れます。

**Are threaded discussions (reply chains) supported, and is there a nesting limit?**

はい。各コメントは [parent comment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/getparentcomment/) を参照でき、返信チェーンを実現します。API では特定のネスト深度制限は定義されていません。

**In what coordinate system is a comment marker's position defined on a slide?**

マーカー位置はスライド座標系の浮動小数点座標で定義され、スライド上の任意の位置に正確に配置できます。