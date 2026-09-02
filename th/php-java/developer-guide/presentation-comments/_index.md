---
title: จัดการความคิดเห็นในงานนำเสนอด้วย PHP
linktitle: ความคิดเห็นในงานนำเสนอ
type: docs
weight: 100
url: /th/php-java/presentation-comments/
keywords:
- ความคิดเห็น
- ความคิดเห็นสมัยใหม่
- ความคิดเห็น PowerPoint
- ความคิดเห็นในงานนำเสนอ
- ความคิดเห็นสไลด์
- เพิ่มความคิดเห็น
- เข้าถึงความคิดเห็น
- แก้ไขความคิดเห็น
- ตอบกลับความคิดเห็น
- ลบความคิดเห็น
- ลบความคิดเห็น
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "จัดการความคิดเห็นในงานนำเสนอด้วย Aspose.Slides for PHP via Java: เพิ่ม, อ่าน, แก้ไข, ตอบกลับ, และลบความคิดเห็นในงานนำเสนอ PowerPoint อย่างรวดเร็วและง่ายดาย."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการจัดการความคิดเห็นในงานนำเสนอด้วย Aspose.Slides for PHP via Java โดยแนะนำประเภทที่เกี่ยวข้องกับความคิดเห็นหลักและสาธิตวิธีเพิ่มความคิดเห็นลงในสไลด์, เข้าถึงความคิดเห็นที่มีอยู่, ทำงานกับการตอบกลับและความคิดเห็นสมัยใหม่, และลบความคิดเห็นจากงานนำเสนอ  

ตัวอย่างครอบคลุมสถานการณ์การตรวจสอบและการทำงานร่วมกันทั่วไปใน PowerPoint เช่น การกำหนดความคิดเห็นให้กับผู้เขียน, การอ่านข้อความและเมตาดาต้าของความคิดเห็น, การสร้างสายตอบกลับ, และการลบความคิดเห็นที่เลือกหรือทั้งหมด  

ใน PowerPoint, ความคิดเห็นปรากฏเป็นหมายเหตุบนสไลด์ การเลือกความคิดเห็นจะแสดงข้อความและการสนทนาที่เกี่ยวข้อง  

## **ทำไมต้องเพิ่มความคิดเห็นลงในงานนำเสนอ?**

คุณสามารถใช้ความคิดเห็นเพื่อให้ข้อเสนอแนะและทำงานร่วมกับเพื่อนร่วมงานเมื่อตรวจสอบงานนำเสนอ  

Aspose.Slides for PHP via Java มี API ต่อไปนี้สำหรับการทำงานกับความคิดเห็น:  

* คลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) ให้เข้าถึงผู้เขียนความคิดเห็นของงานนำเสนอ  
* คลาส [CommentCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/commentcollection/) แสดงความคิดเห็นที่เชื่อมโยงกับผู้เขียนแต่ละคน  
* คลาส [Comment](https://reference.aspose.com/slides/th/php-java/aspose.slides/comment/) ให้ข้อมูลเกี่ยวกับความคิดเห็น รวมถึงผู้เขียน, เวลาสร้าง, ตำแหน่ง, และข้อความ  
* คลาส [CommentAuthor](https://reference.aspose.com/slides/th/php-java/aspose.slides/commentauthor/) ให้ข้อมูลเกี่ยวกับผู้เขียน รวมถึงชื่อ, ชื่อย่อ, และความคิดเห็นที่เชื่อมโยง  

## **เพิ่มความคิดเห็นในสไลด์**

ตัวอย่างต่อไปนี้แสดงวิธีเพิ่มความคิดเห็นลงในสไลด์ของงานนำเสนอ PowerPoint:

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

## **เข้าถึงความคิดเห็นในสไลด์**

ตัวอย่างต่อไปนี้แสดงวิธีเข้าถึงความคิดเห็นที่มีอยู่ในงานนำเสนอ PowerPoint:

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

## **ตอบกลับความคิดเห็น**

คอมเมนต์พาเรนต์คือคอมเมนต์ต้นฉบับที่อยู่บนสุดของลำดับการตอบกลับ. เมธอด [Comment::getParentComment](https://reference.aspose.com/slides/th/php-java/aspose.slides/comment/getparentcomment/) และ [Comment::setParentComment](https://reference.aspose.com/slides/th/php-java/aspose.slides/comment/setparentcomment/) ให้คุณรับหรือกำหนดพาเรนต์ของคอมเมนต์  

ตัวอย่างต่อไปนี้แสดงวิธีเพิ่มการตอบกลับและตรวจสอบโครงสร้างคอมเมนต์ที่ได้:

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
* เมื่อใช้เมธอด [Comment::remove](https://reference.aspose.com/slides/th/php-java/aspose.slides/comment/remove/) เพื่อลบคอมเมนต์, การตอบกลับทั้งหมดของคอมเมนต์นั้นก็จะถูกลบด้วย  
* หาก [Comment::setParentComment](https://reference.aspose.com/slides/th/php-java/aspose.slides/comment/setparentcomment/) สร้างการอ้างอิงแบบวงกลม, จะมีการโยน [PptxEditException](https://reference.aspose.com/slides/th/php-java/aspose.slides/pptxeditexception/) ขึ้น  
{{% /alert %}}

## **เพิ่มความคิดเห็นสมัยใหม่**

ความคิดเห็นสมัยใหม่สามารถเชื่อมโยงกับสไลด์เอง, กับรูปทรงเฉพาะ, หรือกับช่วงข้อความภายใน AutoShape. เมธอด [CommentCollection::addModernComment](https://reference.aspose.com/slides/th/php-java/aspose.slides/commentcollection/addmoderncomment/) รับอาร์กิวเมนต์ [Shape](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/) นอกเหนือจากพิกัดของสไลด์และเครื่องหมายความคิดเห็น  

เมื่อส่งค่า `null` เป็นอาร์กิวเมนต์ shape, ความคิดเห็นจะเป็นความคิดเห็นระดับสไลด์. เครื่องหมายจะถูกวางตามพิกัดที่ให้, แต่ไม่ได้เชื่อมโยงกับรูปทรงใด, ดังนั้น [ModernComment::getShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/moderncomment/getshape/) จะคืนค่า `null`. เมื่อให้ค่า [Shape](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/), ความคิดเห็นจะถูกผูกติดกับรูปทรงนั้น. พิกัดยังคงกำหนดตำแหน่งของเครื่องหมายความคิดเห็นบนสไลด์, ในขณะที่การเชื่อมโยงรูปทรงสามารถดึงได้ผ่าน [ModernComment::getShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/moderncomment/getshape/)  

### **ผูกความคิดเห็นสมัยใหม่กับรูปทรง**

ตัวอย่างต่อไปนี้สร้างความคิดเห็นสมัยใหม่ระดับสไลด์และความคิดเห็นสมัยใหม่ที่ผูกกับ AutoShape เฉพาะ. จากนั้นอ่านรูปทรงที่เชื่อมโยงจากแต่ละความคิดเห็น

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

### **ผูกความคิดเห็นกับรูปทรงประเภทต่าง ๆ**

อ็อบเจกต์สไลด์ใด ๆ ที่แสดงโดยคลาส [Shape](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/) สามารถใช้เป็นจุดยึดรูปทรงได้. ตัวอย่างทั่วไปรวมถึง [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/th/php-java/aspose.slides/connector/), และอินสแตนซ์ของ [GraphicalObject](https://reference.aspose.com/slides/th/php-java/aspose.slides/graphicalobject/) เช่นแผนภูมิ  

ตัวอย่างต่อไปนี้สร้างรูปทรงประเภททั่วไปหลายประเภทและเชื่อมโยงความคิดเห็นสมัยใหม่กับแต่ละรูปทรง

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

### **ผูกความคิดเห็นกับข้อความและกำหนดสถานะ**

สำหรับความคิดเห็นสมัยใหม่ที่เชื่อมโยงกับ [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/), เมธอด [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/th/php-java/aspose.slides/moderncomment/gettextselectionstart/) และ [ModernComment::setTextSelectionStart](https://reference.aspose.com/slides/th/php-java/aspose.slides/moderncomment/settextselectionstart/) เข้าถึงตำแหน่งเริ่มต้นของข้อความที่เลือกในเฟรมข้อความของรูปทรง. เมธอด [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/th/php-java/aspose.slides/moderncomment/gettextselectionlength/) และ [ModernComment::setTextSelectionLength](https://reference.aspose.com/slides/th/php-java/aspose.slides/moderncomment/settextselectionlength/) เข้าถึงความยาวของการเลือก. ค่าทั้งสองร่วมกันทำให้ความคิดเห็นเชื่อมโยงกับช่วงข้อความเฉพาะภายใน AutoShape  

เมธอด [ModernComment::getStatus](https://reference.aspose.com/slides/th/php-java/aspose.slides/moderncomment/getstatus/) และ [ModernComment::setStatus](https://reference.aspose.com/slides/th/php-java/aspose.slides/moderncomment/setstatus/) เข้าถึงค่าจากคอนสแตนท์ [ModernCommentStatus](https://reference.aspose.com/slides/th/php-java/aspose.slides/moderncommentstatus/):  

- `NotDefined` — ไม่ได้กำหนดสถานะของความคิดเห็นสมัยใหม่เฉพาะ  
- `Active` — ความคิดเห็นอยู่ในสถานะใช้งาน  
- `Resolved` — ความคิดเห็นได้ถูกแก้ไขแล้ว  
- `Closed` — ความคิดเห็นถูกปิด  

ตัวอย่างต่อไปนี้สร้างความคิดเห็นสมัยใหม่ที่ผูกกับรูปทรง, เชื่อมโยงกับการเลือกข้อความ, ทำเครื่องหมายว่าแก้ไขแล้ว, บันทึกงานนำเสนอ, และตรวจสอบค่าหลังจากเปิดไฟล์อีกครั้ง

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

### **ตรวจสอบความคิดเห็นสมัยใหม่ที่มีอยู่**

เพื่อทำการตรวจสอบงานนำเสนอที่มีอยู่, ตรวจสอบว่าคอมเมนต์แต่ละรายการเป็น [ModernComment](https://reference.aspose.com/slides/th/php-java/aspose.slides/moderncomment/) หรือไม่, จากนั้นตรวจสอบ [ModernComment::getShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/moderncomment/getshape/), [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/th/php-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/th/php-java/aspose.slides/moderncomment/gettextselectionlength/), และ [ModernComment::getStatus](https://reference.aspose.com/slides/th/php-java/aspose.slides/moderncomment/getstatus/). รูปทรง `null` หมายถึงความคิดเห็นระดับสไลด์. สำหรับจุดยึด [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/), เมธอดการเลือกข้อความจะระบุช่วงที่เชื่อมโยงในเฟรมข้อความของรูปทรง  

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

## **ลบความคิดเห็น**

### **ลบความคิดเห็นและผู้เขียนความคิดเห็นทั้งหมด**

ตัวอย่างต่อไปนี้แสดงวิธีลบความคิดเห็นและผู้เขียนความคิดเห็นทั้งหมดจากงานนำเสนอ:

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

### **ลบความคิดเห็นเฉพาะ**

ตัวอย่างต่อไปนี้แสดงวิธีลบความคิดเห็นเฉพาะจากสไลด์:

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

## **คำถามที่พบบ่อย**

**Aspose.Slides รองรับสถานะ resolved สำหรับความคิดเห็นสมัยใหม่หรือไม่?**  

ใช่. [ModernComment::getStatus](https://reference.aspose.com/slides/th/php-java/aspose.slides/moderncomment/getstatus/) และ [ModernComment::setStatus](https://reference.aspose.com/slides/th/php-java/aspose.slides/moderncomment/setstatus/) เข้าถึงค่า [ModernCommentStatus](https://reference.aspose.com/slides/th/php-java/aspose.slides/moderncommentstatus/) ซึ่งรวมถึง `Resolved`. สถานะนี้ถูกเก็บในงานนำเสนอและสามารถอ่านได้อีกครั้งหลังจากเปิดไฟล์ใหม่  

**การสนทนาที่เป็นเธรด (สายตอบกลับ) ได้รับการสนับสนุนหรือไม่, และมีขีดจำกัดในการซ้อนกันหรือไม่?**  

ใช่. คอมเมนต์แต่ละรายการสามารถอ้างอิงถึง [parent comment](https://reference.aspose.com/slides/th/php-java/aspose.slides/comment/getparentcomment/) ของตน, ทำให้สามารถสร้างสายตอบกลับได้. API ไม่ได้กำหนดขีดจำกัดความลึกของการซ้อนกันโดยเฉพาะ  

**พิกัดของตำแหน่งเครื่องหมายความคิดเห็นบนสไลด์ถูกกำหนดในระบบพิกัดใด?**  

ตำแหน่งของเครื่องหมายจะถูกกำหนดโดยพิกัดแบบ floating-point ในระบบพิกัดของสไลด์, ทำให้คุณสามารถวางตำแหน่งได้อย่างแม่นยำบนสไลด์