---
title: จัดการความคิดเห็นในงานนำเสนอด้วย PHP
linktitle: ความคิดเห็นของงานนำเสนอ
type: docs
weight: 100
url: /th/php-java/presentation-comments/
keywords:
- ความคิดเห็น
- ความคิดเห็นสมัยใหม่
- ความคิดเห็น PowerPoint
- ความคิดเห็นงานนำเสนอ
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

บทความนี้อธิบายวิธีการจัดการความคิดเห็นในงานนำเสนอด้วย Aspose.Slides for PHP via Java โดยนำเสนอประเภทที่เกี่ยวข้องกับความคิดเห็นหลักและแสดงวิธีการเพิ่มความคิดเห็นลงบนสไลด์ เข้าถึงความคิดเห็นที่มีอยู่ ทำงานกับการตอบกลับและความคิดเห็นสมัยใหม่ และลบความคิดเห็นออกจากงานนำเสนอ

ตัวอย่างเหล่านี้ครอบคลุมสถานการณ์การตรวจสอบและการทำงานร่วมกันทั่วไปใน PowerPoint เช่น การกำหนดความคิดเห็นให้กับผู้เขียน การอ่านข้อความและเมตาดาต้าของความคิดเห็น การสร้างสายตอบกลับ และการลบความคิดเห็นที่เลือกหรือทั้งหมด

ใน PowerPoint ความคิดเห็นจะแสดงเป็นคำอธิบายบนสไลด์ การเลือกความคิดเห็นจะแสดงข้อความและการสนทนาที่เกี่ยวข้อง

หากต้องการกำหนดให้ความคิดเห็นแสดงหรือซ่อนเมื่องานนำเสนอเปิดโดยไม่เปลี่ยนแปลงความคิดเห็นเอง ดูที่ [แสดงหรือซ่อนความคิดเห็นเมื่อเปิดงานนำเสนอ](/slides/th/php-java/presentation-view-properties/).

## **ทำไมต้องเพิ่มความคิดเห็นในงานนำเสนอ?**

คุณสามารถใช้ความคิดเห็นเพื่อให้ข้อเสนอแนะและร่วมงานกับเพื่อนร่วมงานเมื่อทำการตรวจสอบงานนำเสนอ

* คลาส [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) ให้การเข้าถึงผู้เขียนความคิดเห็นของงานนำเสนอ
* คลาส [CommentCollection](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/) แสดงถึงความคิดเห็นที่เชื่อมโยงกับผู้เขียนแต่ละคน
* คลาส [Comment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/) ให้ข้อมูลเกี่ยวกับความคิดเห็น รวมถึงผู้เขียน เวลาสร้าง ตำแหน่ง และข้อความ
* คลาส [CommentAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthor/) ให้ข้อมูลเกี่ยวกับผู้เขียน รวมถึงชื่อ ย่อชื่อ และความคิดเห็นที่เชื่อมโยง

## **เพิ่มความคิดเห็นบนสไลด์**

ตัวอย่างนี้สร้างสไลด์สองสไลด์และลงทะเบียนผู้เขียนความคิดเห็นด้วย [addAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/addauthor/). ใช้ [addComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addcomment/) เพื่่วางความคิดเห็นหนึ่งรายการบนแต่ละสไลด์ แล้วเรียกดูความคิดเห็นของสไลด์แรกสำหรับผู้เขียนคนนั้นด้วย [getSlideComments](https://reference.aspose.com/slides/php-java/aspose.slides/slide/getslidecomments/). คอนโซลจะแสดงข้อความของความคิดเห็นแรกสองครั้ง เพื่อแสดงการเข้าถึงผ่านสไลด์และผู้เขียน และงานนำเสนอที่บันทึกจะมีความคิดเห็นทั้งสองรายการ

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

## **ค้นหา หรือสร้างผู้เขียนความคิดเห็น**

เมื่อการตรวจสอบอัตโนมัติโปรเซสงานนำเสนอเดียวกันหลายครั้ง ให้ค้นหาคอลเล็กชันที่ [getCommentAuthors](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getcommentauthors/) ส่งคืนก่อนเพิ่มผู้เขียน [findByNameAndInitials](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/findbynameandinitials/) จะจับคู่ทั้งชื่อและอักษรย่อและคืนอาเรย์ของผู้เขียนที่ตรงกัน หรืออาเรย์ว่างหากไม่มีผลลัพธ์ ตรงกันข้าม [findByName](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/findbyname/) จะค้นหาเฉพาะตามชื่อโดยไม่คำนึงถึงอักษรย่อ การเรียก [addAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/addauthor/) ด้วยชื่อและอักษรย่อที่มีอยู่แล้วในคอลเล็กชันจะทำให้เกิดข้อยกเว้น

ตัวอย่างต้องการไฟล์งานนำเสนอที่มีอย่างน้อยหนึ่งสไลด์ ในแต่ละรอบสองครั้ง จะใช้ผู้เขียนที่ตรงกันคนแรกซ้ำ หรือสร้างใหม่เมื่อผลลัพธ์ว่าง หากมีหลายรายการตรงกัน จะเลือกอิลเมนต์แรกของอาเรย์โดยไม่รวมหรือลบผู้เขียนอื่น ๆ จากนั้นจะเรียก [addComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addcomment/) สำหรับผู้เขียนที่เลือกและบันทึกงานนำเสนอ รอบที่สองจะเปิดผลลัพธ์ของรอบแรกและทำซ้ำขั้นตอน

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

รอบที่สองจะเพิ่มความคิดเห็นอีกหนึ่งรายการโดยไม่เพิ่มผู้เขียนใหม่หรือ حذفความคิดเห็นที่มีอยู่ ไฟล์สุดท้าย `review_pass_2.pptx` มีความคิดเห็นใหม่สองรายการพร้อมกับความคิดเห็นเดิมที่อาจมีอยู่ การใช้ผู้เขียนซ้ำไม่ได้ทำให้ความคิดเห็นซ้ำกันถูกกรองออก: เพื่อหลีกเลี่ยงการเพิ่มความคิดเห็นเดียวกันซ้ำ ๆ ควรตรวจจับความซ้ำก่อนทำการเพิ่ม

## **เข้าถึงความคิดเห็นบนสไลด์**

ตัวอย่างนี้เปิดงานนำเสนอที่มีอยู่และอ่านคอลเล็กชันที่ [getCommentAuthors](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getcommentauthors/) ส่งคืน สำหรับผู้เขียนแต่ละคนจะวนผ่านคอลเล็กชันที่ [getComments](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthor/getcomments/) ส่งคืนและพิมพ์หมายเลขสไลด์ ข้อความความคิดเห็น ชื่อผู้เขียน และเวลาสร้าง งานนำเข้าต้องมีความคิดเห็นเพื่อให้คอนโซลแสดงผล

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

ความคิดเห็นแม่คือความคิดเห็นต้นฉบับอยู่บนสุดของโครงสร้างการตอบกลับ เมธอด [Comment::getParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/getparentcomment/) และ [Comment::setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) ให้คุณรับหรือกำหนดความคิดเห็นแม่ของความคิดเห็น

ตัวอย่างสร้างความคิดเห็นจากผู้เขียนสองคนและใช้ [setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) เพื่อสร้างการตอบกลับ รวมถึงการตอบกลับต่อการตอบกลับอีกหนึ่งระดับ การส่งค่า `null` ไปยัง [getSlideComments](https://reference.aspose.com/slides/php-java/aspose.slides/slide/getslidecomments/) จะดึงความคิดเห็นจากผู้เขียนทั้งหมด; คอนโซลจะแสดงการเยื้องแต่ละรายการตามระดับความลึกในโครงสร้างการตอบกลับ ตัวอย่างบันทึกการสนทนาทั้งหมด เรียก [remove](https://reference.aspose.com/slides/php-java/aspose.slides/comment/remove/) กับความคิดเห็นรากแรกและบันทึกงานนำเสนอที่สองที่มีความคิดเห็นนั้นและการตอบกลับของมันถูกลบออก

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
* เมื่อใช้เมธอด [Comment::remove](https://reference.aspose.com/slides/php-java/aspose.slides/comment/remove/) เพื่อลบความคิดเห็น การตอบกลับทั้งหมดของความคิดเห็นนั้นก็จะถูกลบด้วย.
* หาก [Comment::setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) สร้างการอ้างอิงแบบวงกลม จะมีการโยนข้อยกเว้น [PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **เพิ่มความคิดเห็นสมัยใหม่**

ความคิดเห็นสมัยใหม่สามารถเชื่อมโยงกับสไลด์เอง, กับรูปทรงเฉพาะ, หรือกับช่วงข้อความภายใน AutoShape เมธอด [CommentCollection::addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addmoderncomment/) รับอาร์กิวเมนต์ [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) นอกเหนือจากสไลด์และพิกัดของตัวบ่งชี้ความคิดเห็น

เมื่อส่งค่า `null` เป็นอาร์กิวเมนต์รูปทรง ความคิดเห็นจะเป็นความคิดเห็นระดับสไลด์ ตัวบ่งชี้จะถูกวางตามพิกัดที่กำหนด แต่ไม่เชื่อมโยงกับรูปทรงใดโดยเฉพาะ ดังนั้น [ModernComment::getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/) จะคืนค่า `null` เมื่อให้ค่า [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) จะทำให้ความคิดเห็นยึดกับรูปทรงนั้น พิกัดยังคงกำหนดตำแหน่งของตัวบ่งชี้บนสไลด์ ในขณะที่การเชื่อมโยงรูปทรงสามารถดึงได้ผ่าน [ModernComment::getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/)

### **ยึดความคิดเห็นสมัยใหม่ให้กับรูปทรง**

ตัวอย่างเรียก [addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addmoderncomment/) สองครั้ง: ครั้งหนึ่งด้วยรูปทรง `null` สำหรับความคิดเห็นระดับสไลด์และครั้งหนึ่งด้วยสี่เหลี่ยมเป็นจุดยึด การอ่าน [getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/) จะพิมพ์ `true` สำหรับการตรวจสอบ null ของความคิดเห็นระดับสไลด์และพิมพ์ `Revenue title` สำหรับความคิดเห็นที่ยึดรูปทรง ทั้งสองความคิดเห็นจะถูกบันทึกพร้อมกับงานนำเสนอ

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

### **ยึดความคิดเห็นให้กับรูปทรัพย์ประเภทต่าง ๆ**

ออบเจ็กต์สไลด์ใด ๆ ที่แสดงโดยคลาส [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) สามารถใช้เป็นจุดยึดรูปทรงได้ ตัวอย่างทั่วไปรวมถึง [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/php-java/aspose.slides/connector/), และอินสแตนซ์ [GraphicalObject](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobject/) เช่น แผนภูมิ

ตัวอย่างใช้ [addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addmoderncomment/) เพื่อเชื่อมโยงความคิดเห็นกับรูปทรงประเภทห้าชนิด: AutoShape, PictureFrame, GroupShape, Connector, และ Chart ภาพใช้ข้อมูลรูปแบบฝังภายใน จึงไม่ต้องใช้รูปภาพภายนอก แต่ละความคิดเห็นมีตำแหน่งตัวบ่งชี้ของตนเองและงานนำเสนอที่บันทึกจะรักษาการเชื่อมโยงกับรูปทรงทั้งห้าไว้

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

### **ยึดความคิดเห็นให้กับข้อความและตั้งสถานะของมัน**

สำหรับความคิดเห็นสมัยใหม่ที่เชื่อมโยงกับ [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/), เมธอด [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionstart/) และ [ModernComment::setTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionstart/) เข้าถึงตำแหน่งเริ่มต้นของข้อความที่เลือกในกรอบข้อความของรูปทรงนั้น [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionlength/) และ [ModernComment::setTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionlength/) เข้าถึงความยาวของการเลือก ค่าเหล่านี้ร่วมกันทำให้ความคิดเห็นเชื่อมโยงกับช่วงข้อความเฉพาะภายใน AutoShape

เมธอด [ModernComment::getStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getstatus/) และ [ModernComment::setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/) เข้าถึงค่าจากคอนสแตนท์ [ModernCommentStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncommentstatus/):

- `NotDefined` — ไม่ได้กำหนดสถานะความคิดเห็นสมัยใหม่ใด ๆ
- `Active` — ความคิดเห็นอยู่ในสถานะทำงาน
- `Resolved` — ความคิดเห็นได้รับการแก้ไขแล้ว
- `Closed` — ความคิดเห็นถูกปิด

ตัวอย่างยึดความคิดเห็นสมัยใหม่ให้กับคำว่า "quarterly revenue" ในข้อความของสี่เหลี่ยม มันคำนวณตำแหน่งเริ่มต้นของการเลือก (เลขศูนย์ฐาน) จากข้อความและส่งค่าไปยัง [setTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionstart/) และใช้ [setTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionlength/) เพื่อกำหนดจำนวนอักขระที่เลือก หลังจากเรียก [setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/) ด้วยค่า `Resolved` แล้วจะบันทึกและเปิดงานนำเข้าใหม่ การตรวจสอบคอนโซลสี่ครั้งควรพิมพ์ `true` เพื่อยืนยันว่าการยึดรูปทรง, ช่วงข้อความ, และสถานะถูกเก็บไว้

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

ตัวอย่างต้องการงานนำเสนอที่มีความคิดเห็นสมัยใหม่และพิมพ์ข้อความ, สถานะ, และรายละเอียดจุดยึดของแต่ละความคิดเห็น เพื่อทำการตรวจสอบ ให้ตรวจสอบว่าความคิดเห็นแต่ละรายการเป็น [ModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/) หรือไม่ จากนั้นตรวจสอบ [ModernComment::getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/), [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionlength/), และ [ModernComment::getStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getstatus/). รูปทรง `null` หมายถึงความคิดเห็นระดับสไลด์ สำหรับจุดยึดที่เป็น [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) เมธอดการเลือกข้อความจะระบุช่วงที่เชื่อมโยงในกรอบข้อความของรูปทรง

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

Aspose.Slides for PHP via Java ให้คุณลบความคิดเห็นทั้งหมดและผู้เขียนของมันออกจากงานนำเสนอ หรือจะลบความคิดเห็นที่เลือกไว้โดยคงส่วนที่เหลือ ตัวอย่างต่อไปนี้แสดงวิธีทั้งสองและบันทึกงานนำเสนอที่อัปเดต

### **ลบความคิดเห็นทั้งหมดและผู้เขียนความคิดเห็น**

ตัวอย่างเปิดงานนำเสนอที่มีอยู่และเรียก [CommentCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/clear/) สำหรับผู้เขียนแต่ละคน จากนั้นเรียก [CommentAuthorCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/clear/) เพื่อลบผู้เขียนเอง งานนำเสนอที่บันทึกจะไม่มีความคิดเห็นหรือผู้เขียนความคิดเห็นใด ๆ ใช้งานนำเสนอที่มีความคิดเห็นเพื่อสังเกตการลบ

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

### **ลบความคิดเห็นที่ระบุ**

ตัวอย่างสร้างความคิดเห็นสองรายการบนสไลด์หนึ่งและใช้ [getSlideComments](https://reference.aspose.com/slides/php-java/aspose.slides/slide/getslidecomments/) เพื่อค้นหาความคิดเห็นตามผู้เขียนแต่ละคน มันรวบรวมความคิดเห็นที่ข้อความเท่ากับ "comment 1" ก่อนเรียก [CommentCollection::remove](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/remove/) เพื่อหลีกเลี่ยงการเปลี่ยนแปลงคอลเล็กชันระหว่างการคัดเลือก งานนำเสนอที่บันทึกจะเหลือเฉพาะ "comment 2"

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

## **คำถามยอดนิยม**

**Aspose.Slides รองรับสถานะ "Resolved" สำหรับความคิดเห็นสมัยใหม่หรือไม่?**

ใช่. [ModernComment::getStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getstatus/) และ [ModernComment::setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/) เข้าถึงค่าจาก [ModernCommentStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncommentstatus/) รวมถึง `Resolved` สถานะนี้ถูกเก็บในงานนำเสนอและสามารถอ่านได้อีกครั้งหลังจากไฟล์ถูกเปิดใหม่

**การสนทนาแบบเธรด (สายตอบกลับ) ได้รับการสนับสนุนหรือไม่ และมีข้อจำกัดการซ้อนระดับใดหรือไม่?**

ใช่. ความคิดเห็นแต่ละรายการสามารถอ้างอิงถึง [parent comment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/getparentcomment/) ของมัน ทำให้สามารถสร้างสายตอบกลับได้ API ไม่ได้กำหนดขีดจำกัดระดับการซ้อนใดเป็นพิเศษ

**ตำแหน่งของตัวบ่งชี้ความคิดเห็นบนสไลด์กำหนดในระบบพิกัดใด?**

ตำแหน่งตัวบิกชี้ถูกกำหนดด้วยพิกัดแบบ floating-point ในระบบพิกัดของสไลด์ ทำให้คุณสามารถวางได้อย่างแม่นยำบนสไลด์