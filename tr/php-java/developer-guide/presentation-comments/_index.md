---
title: PHP'de Sunum Yorumlarını Yönet
linktitle: Sunum Yorumları
type: docs
weight: 100
url: /tr/php-java/presentation-comments/
keywords:
- yorum
- modern yorum
- PowerPoint yorumları
- sunum yorumları
- slayt yorumları
- yorum ekle
- yoruma eriş
- yorum düzenle
- yorum yanıtla
- yorum kaldır
- yorum sil
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile sunum yorumlarını yönetin: PowerPoint sunumlarında yorum ekleyin, okuyun, düzenleyin, yanıtlayın ve kaldırın, hızlı ve kolay bir şekilde."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for PHP via Java ile sunum yorumlarını nasıl yöneteceğinizi açıklar. Ana yorumla ilgili türleri tanıtır ve slaytlara yorum ekleme, mevcut yorumlara erişme, yanıtlar ve modern yorumlarla çalışma ve bir sunumdan yorumları kaldırma konularını gösterir.

Örnekler, PowerPoint'te yaygın inceleme ve işbirliği senaryolarını kapsar; yorumları yazarlara atama, yorum metnini ve meta verileri okuma, yanıt zincirleri oluşturma ve seçili yorumları ya da tüm yorumları kaldırma gibi.

PowerPoint'te yorumlar, slaytlardaki açıklama olarak görünür. Bir yorumu seçmek, metnini ve ilgili tartışmayı gösterir.

Sunum açılırken yorumları göster veya gizlemek için yorumları kendileri değiştirilmeden, bkz. [Sunum Açılırken Yorumları Göster veya Gizle](/slides/tr/php-java/presentation-view-properties/).

## **Sunumlara Neden Yorum Eklenir?**

Sunumları incelerken geri bildirim sağlamak ve çalışma arkadaşlarınızla işbirliği yapmak için yorumları kullanabilirsiniz.

Aspose.Slides for PHP via Java, yorumlarla çalışmak için aşağıdaki API'leri sağlar:

* The [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfı, sunumun yorum yazarlarına erişim sağlar.
* The [CommentCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/commentcollection/) sınıfı, belirli bir yazarla ilişkili yorumları temsil eder.
* The [Comment](https://reference.aspose.com/slides/tr/php-java/aspose.slides/comment/) sınıfı, bir yorum hakkında bilgi sağlar; yazarını, oluşturulma zamanını, konumunu ve metnini içerir.
* The [CommentAuthor](https://reference.aspose.com/slides/tr/php-java/aspose.slides/commentauthor/) sınıfı, bir yazar hakkında bilgi verir; adını, baş harflerini ve ilişkili yorumları içerir.

## **Slayt Yorumları Ekleme**

Aşağıdaki örnek, bir PowerPoint sunumunda slaytlara yorum eklemenin nasıl yapılacağını gösterir:

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

## **Slayt Yorumlarına Erişim**

Aşağıdaki örnek, bir PowerPoint sunumundaki mevcut yorumlara nasıl erişileceğini gösterir:

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

## **Yorumlara Yanıt Verme**

Bir üst yorum, yanıt hiyerarşisinin en üstündeki özgün yorumdur. [Comment::getParentComment](https://reference.aspose.com/slides/tr/php-java/aspose.slides/comment/getparentcomment/) ve [Comment::setParentComment](https://reference.aspose.com/slides/tr/php-java/aspose.slides/comment/setparentcomment/) yöntemleri, bir yorumun üst yorumunu almanıza veya ayarlamanıza olanak tanır.

Aşağıdaki örnek, yanıt eklemenin ve ortaya çıkan yorum hiyerarşisini incelemenin nasıl yapılacağını gösterir:

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

{{% alert color="warning" title="Uyarı" %}}
* [Comment::remove](https://reference.aspose.com/slides/tr/php-java/aspose.slides/comment/remove/) yöntemi bir yorumu silmek için kullanıldığında, o yoruma ait tüm yanıtlar da silinir.
* [Comment::setParentComment](https://reference.aspose.com/slides/tr/php-java/aspose.slides/comment/setparentcomment/) bir döngüsel referans oluşturursa, bir [PptxEditException](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pptxeditexception/) fırlatılır.
{{% /alert %}}

## **Modern Yorumlar Ekleme**

Modern yorumlar, slaytın kendisiyle, belirli bir şekille veya bir AutoShape içindeki metin aralığıyla ilişkilendirilebilir. [CommentCollection::addModernComment](https://reference.aspose.com/slides/tr/php-java/aspose.slides/commentcollection/addmoderncomment/) yöntemi, slayt ve yorum işaretleyici koordinatlarına ek olarak bir [Shape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/) argümanı kabul eder.

`null` bir şekil argümanı olarak geçirildiğinde, yorum slayt düzeyinde bir yorum olur. İşaretleyici verilen koordinatlarla konumlandırılır, ancak belirli bir şekille ilişkilendirilmez, bu yüzden [ModernComment::getShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/moderncomment/getshape/) `null` döndürür. Bir [Shape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/) sağlandığında, yorum o şekle sabitlenir. Koordinatlar hâlâ yorum işaretleyicisinin slayttaki konumunu tanımlar, şekil ilişkilendirmesi ise [ModernComment::getShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/moderncomment/getshape/) ile alınabilir.

### **Modern Yorumu Bir Şekle Sabitleme**

Aşağıdaki örnek, hem slayt düzeyinde bir modern yorum hem de belirli bir AutoShape'e sabitlenmiş bir modern yorum oluşturur. Ardından her bir yorumdan ilişkili şekli okur.

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

### **Yorumları Farklı Şekil Türlerine Sabitleme**

[Shape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/) sınıfı tarafından temsil edilen herhangi bir slayt nesnesi şekil sabitleyicisi olarak kullanılabilir. Yaygın örnekler arasında [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/tr/php-java/aspose.slides/connector/) ve grafik nesnesi (örneğin grafikler) gibi [GraphicalObject](https://reference.aspose.com/slides/tr/php-java/aspose.slides/graphicalobject/) örnekleri bulunur.

Aşağıdaki örnek, birkaç yaygın şekil türü oluşturur ve her biriyle bir modern yorum ilişkilendirir.

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

### **Yorumu Metne Sabitleme ve Durumunu Ayarlama**

Bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) ile ilişkili modern yorum için, [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/tr/php-java/aspose.slides/moderncomment/gettextselectionstart/) ve [ModernComment::setTextSelectionStart](https://reference.aspose.com/slides/tr/php-java/aspose.slides/moderncomment/settextselectionstart/) şeklin metin çerçevesindeki seçili metnin başlangıç konumuna erişir. [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/tr/php-java/aspose.slides/moderncomment/gettextselectionlength/) ve [ModernComment::setTextSelectionLength](https://reference.aspose.com/slides/tr/php-java/aspose.slides/moderncomment/settextselectionlength/) seçimin uzunluğunu alır. Bu iki değer bir arada, yorumu AutoShape içindeki belirli bir metin aralığıyla ilişkilendirir.

[ModernComment::getStatus](https://reference.aspose.com/slides/tr/php-java/aspose.slides/moderncomment/getstatus/) ve [ModernComment::setStatus](https://reference.aspose.com/slides/tr/php-java/aspose.slides/moderncomment/setstatus/) yöntemleri, [ModernCommentStatus](https://reference.aspose.com/slides/tr/php-java/aspose.slides/moderncommentstatus/) sabitlerinden bir değer alır:

- `NotDefined` — belirli bir modern yorum durumu tanımlanmamıştır.
- `Active` — yorum aktiftir.
- `Resolved` — yorum çözülmüştür.
- `Closed` — yorum kapatılmıştır.

Aşağıdaki örnek, şekle sabitlenmiş bir modern yorum oluşturur, bir metin seçimiyle ilişkilendirir, çözülmüş olarak işaretler, sunumu kaydeder ve dosyayı yeniden açtıktan sonra değerleri doğrular.

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

### **Mevcut Modern Yorumları İnceleme**

Mevcut bir sunumu incelemek için, her yorumun bir [ModernComment](https://reference.aspose.com/slides/tr/php-java/aspose.slides/moderncomment/) olup olmadığını kontrol edin, ardından [ModernComment::getShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/moderncomment/getshape/), [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/tr/php-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/tr/php-java/aspose.slides/moderncomment/gettextselectionlength/) ve [ModernComment::getStatus](https://reference.aspose.com/slides/tr/php-java/aspose.slides/moderncomment/getstatus/) inceleyin. `null` bir şekil, slayt düzeyinde bir yorum olduğunu gösterir. Bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) sabitleyicisi için, metin‑seçim yöntemleri şeklin metin çerçevesindeki ilgili aralığı belirler.

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

## **Yorumları Kaldırma**

### **Tüm Yorumları ve Yorum Yazarlarını Kaldırma**

Aşağıdaki örnek, bir sunumdan tüm yorumları ve yorum yazarlarını nasıl kaldıracağınızı gösterir:

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

### **Belirli Yorumları Kaldırma**

Aşağıdaki örnek, bir slayttan belirli yorumları nasıl kaldıracağınızı gösterir:

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

## **SSS**

**Aspose.Slides modern yorumlar için çözülmüş durumunu destekliyor mu?**

Evet. [ModernComment::getStatus](https://reference.aspose.com/slides/tr/php-java/aspose.slides/moderncomment/getstatus/) ve [ModernComment::setStatus](https://reference.aspose.com/slides/tr/php-java/aspose.slides/moderncomment/setstatus/) bir [ModernCommentStatus](https://reference.aspose.com/slides/tr/php-java/aspose.slides/moderncommentstatus/) değerine erişir, `Resolved` dahil. Durum sunumda depolanır ve dosya yeniden açıldığında tekrar okunabilir.

**İş parçacıklı tartışmalar (yanıt zincirleri) destekleniyor mu ve bir iç içeleme sınırı var mı?**

Evet. Her yorum, [parent comment](https://reference.aspose.com/slides/tr/php-java/aspose.slides/comment/getparentcomment/)’a referans verebilir, bu da yanıt zincirlerini etkinleştirir. API, belirli bir iç içeleme derinliği sınırı tanımlamaz.

**Bir yorum işaretleyicisinin konumu slayt üzerinde hangi koordinat sisteminde tanımlanır?**

İşaretleyici konumu, slayt koordinat sistemindeki kayan noktalı koordinatlarla tanımlanır; bu sayede onu slayt üzerinde kesin olarak yerleştirebilirsiniz.