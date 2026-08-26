---
title: PHP'de Sunum Yorumlarını Yönetin
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
- yorumu ekle
- yoruma eriş
- yorumu düzenle
- yoruma yanıtla
- yorumu kaldır
- yorumu sil
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile sunum yorumlarını yönetin: PowerPoint sunumlarında yorumları hızlı ve kolay bir şekilde ekleyin, okuyun, düzenleyin, yanıtlayın ve kaldırın."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for PHP via Java ile sunum yorumlarını nasıl yöneteceğinizi açıklar. Ana yorumla ilgili tipleri tanıtır ve slaytlara yorum ekleme, mevcut yorumlara erişme, yanıtlar ve modern yorumlarla çalışma ve bir sunumdan yorumları kaldırma konularını gösterir.

Örnekler, PowerPoint'teki yaygın inceleme ve iş birliği senaryolarını kapsar; örneğin yorumları yazarlara atama, yorum metni ve meta verileri okuma, yanıt zincirleri oluşturma ve seçili yorumları ya da tüm yorumları kaldırma.

PowerPoint'te yorumlar slaytlar üzerindeki ek açıklamalar olarak görünür. Bir yorumu seçmek, metnini ve ilgili tartışmayı gösterir.

## **Sunumlara Neden Yorum Eklemeliyiz?**

Yorumları, sunumları incelerken geri bildirim sağlamak ve meslektaşlarınızla iş birliği yapmak için kullanabilirsiniz.

Aspose.Slides for PHP via Java, yorumlarla çalışmak için aşağıdaki API'leri sağlar:

* The [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfı, sunumun yorum yazarlarına erişim sağlar.
* The [CommentCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/commentcollection/) sınıfı, belirli bir yazarla ilişkili yorumları temsil eder.
* The [Comment](https://reference.aspose.com/slides/tr/php-java/aspose.slides/comment/) sınıfı, bir yorum hakkında yazar, oluşturulma zamanı, konum ve metin gibi bilgiler sunar.
* The [CommentAuthor](https://reference.aspose.com/slides/tr/php-java/aspose.slides/commentauthor/) sınıfı, ad, baş harfler ve ilişkili yorumlar gibi yazar bilgisini sağlar.

## **Slayt Yorumları Ekle**

Aşağıdaki örnek, PowerPoint sunumundaki slaytlara yorum eklemenin nasıl yapılacağını gösterir:

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

## **Slayt Yorumlarına Erişme**

Aşağıdaki örnek, PowerPoint sunumundaki mevcut yorumlara nasıl erişileceğini gösterir:

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

Üst yorum, yanıt hiyerarşisinin en üstündeki orijinal yorumdur. The [Comment::getParentComment](https://reference.aspose.com/slides/tr/php-java/aspose.slides/comment/getparentcomment/) ve [Comment::setParentComment](https://reference.aspose.com/slides/tr/php-java/aspose.slides/comment/setparentcomment/) yöntemleri bir yorumun üst yorumunu almanıza veya ayarlamanıza olanak tanır.

Aşağıdaki örnek, yanıt eklemeyi ve ortaya çıkan yorum hiyerarşisini incelemeyi gösterir:

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
* [Comment::setParentComment](https://reference.aspose.com/slides/tr/php-java/aspose.slides/comment/setparentcomment/) dairesel bir referans oluşturursa, bir [PptxEditException](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pptxeditexception/) fırlatılır.
{{% /alert %}}

## **Modern Yorumlar Ekle**

Modern yorumlar slaytın kendisiyle, belirli bir şekilyle veya bir AutoShape içindeki metin aralığıyla ilişkilendirilebilir. The [CommentCollection::addModernComment](https://reference.aspose.com/slides/tr/php-java/aspose.slides/commentcollection/addmoderncomment/) yöntemi, slayt ve yorum işaretleyici koordinatlarına ek olarak bir [Shape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/) argümansını kabul eder.

`null` şekil argümanı verildiğinde yorum bir slayt‑seviyesi yorum olur. İşaretleyicisi sağlanan koordinatlarla konumlandırılır, ancak belirli bir şekille ilişkilendirilmez, bu yüzden [ModernComment::getShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/moderncomment/getshape/) `null` döndürür. Bir [Shape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/) sağlandığında yorum o şekle sabitlenir. Koordinatlar hâlâ yorum işaretleyicisinin slayt üzerindeki konumunu tanımlar, şekil ilişkisi ise [ModernComment::getShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/moderncomment/getshape/) üzerinden alınabilir.

### **Modern Yorumları Bir Şekle Bağlama**

Aşağıdaki örnek, hem slayt‑seviyesi modern yorum hem de belirli bir AutoShape'e sabitlenmiş modern yorum oluşturur. Ardından her iki yorumdan da ilişkili şekli okur.

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

### **Yorumları Farklı Şekil Türlerine Bağlama**

[Shape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/) sınıfı ile temsil edilen herhangi bir slayt nesnesi şekil bağlantısı olarak kullanılabilir. Yaygın örnekler arasında [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/tr/php-java/aspose.slides/connector/) ve grafik nesneleri (örneğin grafikler) bulunur.

Aşağıdaki örnek, birkaç yaygın şekil türü oluşturur ve her birine modern bir yorum ilişkilendirir.

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

### **Yorumu Metne Bağlama ve Durumunu Ayarlama**

Bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) ile ilişkili modern yorum için [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/tr/php-java/aspose.slides/moderncomment/gettextselectionstart/) ve [ModernComment::setTextSelectionStart](https://reference.aspose.com/slides/tr/php-java/aspose.slides/moderncomment/settextselectionstart/) şeklin metin çerçevesindeki seçili metnin başlangıç konumunu alır ve ayarlar. [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/tr/php-java/aspose.slides/moderncomment/gettextselectionlength/) ve [ModernComment::setTextSelectionLength](https://reference.aspose.com/slides/tr/php-java/aspose.slides/moderncomment/settextselectionlength/) seçimin uzunluğunu alır. Bu değerler birlikte yorumu AutoShape içinde belirli bir metin aralığıyla ilişkilendirir.

[ModernComment::getStatus](https://reference.aspose.com/slides/tr/php-java/aspose.slides/moderncomment/getstatus/) ve [ModernComment::setStatus](https://reference.aspose.com/slides/tr/php-java/aspose.slides/moderncomment/setstatus/) yöntemleri, [ModernCommentStatus](https://reference.aspose.com/slides/tr/php-java/aspose.slides/moderncommentstatus/) sabitlerinden bir değer alır:

- `NotDefined` — özel bir modern‑yorum durumu tanımlanmamış.
- `Active` — yorum etkin.
- `Resolved` — yorum çözülmüş.
- `Closed` — yorum kapalı.

Aşağıdaki örnek, şekle sabitlenmiş bir modern yorum oluşturur, bir metin seçimiyle ilişkilendirir, çözülmüş olarak işaretler, sunumu kaydeder ve dosya yeniden açıldıktan sonra değerleri doğrular.

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

Mevcut bir sunumu incelerken, her yorumun bir [ModernComment](https://reference.aspose.com/slides/tr/php-java/aspose.slides/moderncomment/) olup olmadığını kontrol edin, ardından [ModernComment::getShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/moderncomment/getshape/), [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/tr/php-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/tr/php-java/aspose.slides/moderncomment/gettextselectionlength/) ve [ModernComment::getStatus](https://reference.aspose.com/slides/tr/php-java/aspose.slides/moderncomment/getstatus/) incelenir. `null` bir şekil, slayt‑seviyesi yorum olduğunu gösterir. Bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) bağlantısı için metin‑seçim yöntemleri, şeklin metin çerçevesindeki ilgili aralığı belirler.

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

## **Yorumları Kaldır**

### **Tüm Yorumları ve Yorum Yazarlarını Kaldır**

Aşağıdaki örnek, bir sunumdan tüm yorumları ve yorum yazarlarını kaldırmayı gösterir:

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

### **Belirli Yorumları Kaldır**

Aşağıdaki örnek, bir slayttan belirli yorumları kaldırmayı gösterir:

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

**Aspose.Slides modern yorumlar için çözülmüş bir durum desteği sağlar mı?**

Evet. [ModernComment::getStatus](https://reference.aspose.com/slides/tr/php-java/aspose.slides/moderncomment/getstatus/) ve [ModernComment::setStatus](https://reference.aspose.com/slides/tr/php-java/aspose.slides/moderncomment/setstatus/) bir [ModernCommentStatus](https://reference.aspose.com/slides/tr/php-java/aspose.slides/moderncommentstatus/) değeri, `Resolved` dahil, erişir. Durum sunumda depolanır ve dosya yeniden açıldıktan sonra tekrar okunabilir.

**İş parçacıklı tartışmalar (yanıt zincirleri) destekleniyor mu ve bir iç içe derinlik sınırı var mı?**

Evet. Her yorum, bir [parent comment](https://reference.aspose.com/slides/tr/php-java/aspose.slides/comment/getparentcomment/) referansı ile yanıt zincirleri oluşturabilir. API, belirli bir iç içe derinlik sınırı tanımlamaz.

**Bir slaytta yorum işaretleyicisinin konumu hangi koordinat sistemine göre tanımlanır?**

İşaretleyici konumu, slayt koordinat sistemindeki kayan nokta koordinatlarıyla tanımlanır; bu, işaretleyiciyi slayt üzerinde tam olarak konumlandırmanıza olanak tanır.