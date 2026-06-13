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
- ความคิดเห็นงานนำเสนอ
- ความคิดเห็นสไลด์
- เพิ่มความคิดเห็น
- เข้าถึงความคิดเห็น
- แก้ไขความคิดเห็น
- ตอบกลับความคิดเห็น
- ลบความคิดเห็น
- ลบความคิดเห็น
- PowerPoint
- OpenDocument
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "ควบคุมความคิดเห็นในงานนำเสนอด้วย Aspose.Slides สำหรับ PHP ผ่าน Java: เพิ่ม, อ่าน, แก้ไข และลบความคิดเห็นในไฟล์ PowerPoint อย่างรวดเร็วและง่ายดาย."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีจัดการความคิดเห็นในงานนำเสนอด้วย Aspose.Slides แสดงประเภทหลักที่เกี่ยวกับความคิดเห็นและสาธิตวิธีเพิ่มความคิดเห็นลงสไลด์, เข้าถึงความคิดเห็นที่มีอยู่, ทำงานกับการตอบกลับ, ใช้ความคิดเห็นสมัยใหม่, และลบความคิดเห็นออกจากงานนำเสนอ

ตัวอย่างมุ่งเน้นไปที่สถานการณ์การตรวจทานและการร่วมมือที่พบบ่อยใน PowerPoint เช่น การกำหนดผู้เขียนให้กับความคิดเห็น, อ่านเนื้อหาและเมตาดาต้าของความคิดเห็น, สร้างสายตอบกลับ, และลบความคิดเห็นทั้งหมดหรือความคิดเห็นที่เลือก

ใน PowerPoint ความคิดเห็นจะแสดงเป็นบันทึกหรือหมายเหตุบนสไลด์ เมื่อคลิกที่ความคิดเห็น เนื้อหาหรือข้อความจะปรากฏขึ้น

## **ทำไมต้องเพิ่มความคิดเห็นในงานนำเสนอ?**

คุณอาจต้องการใช้ความคิดเห็นเพื่อให้ข้อเสนอแนะหรือสื่อสารกับเพื่อนร่วมงานเมื่อทำการตรวจทานงานนำเสนอ

เพื่อให้คุณสามารถใช้ความคิดเห็นในงานนำเสนอ PowerPoint, Aspose.Slides for PHP via Java มีให้

* The [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) class, which contains the collections of authors (from the [CommentAuthorCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/commentauthorcollection/) class). The authors add comments to slides.
* The [CommentCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/commentcollection/) class, which contains the collection of comments for individual authors.
* The [Comment](https://reference.aspose.com/slides/th/php-java/aspose.slides/comment/) class, which contains information on authors and their comments: who added the comment, the time the comment was added, the comment's position, etc.
* The [CommentAuthor](https://reference.aspose.com/slides/th/php-java/aspose.slides/commentauthor/) class, which contains information on individual authors: the author's name, his initials, comments associated with the author's name, etc.

## **เพิ่มความคิดเห็นในสไลด์**
โค้ด PHP นี้แสดงวิธีเพิ่มความคิดเห็นลงสไลด์ในงานนำเสนอ PowerPoint:

```php
  # สร้างอินสแตนซ์ของคลาส Presentation
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # เพิ่มสไลด์เปล่า
    $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    # เพิ่มผู้เขียน
    $author = $pres->getCommentAuthors()->addAuthor("Jawad", "MF");
    # ตั้งตำแหน่งสำหรับความคิดเห็น
    $point = new Point2DFloat(0.2, 0.2);
    # เพิ่มความคิดเห็นสไลด์สำหรับผู้เขียนบนสไลด์ที่ 1
    $author->getComments()->addComment("Hello Jawad, this is slide comment", $pres->getSlides()->get_Item(0), $point, new Java("java.util.Date"));
    # เพิ่มความคิดเห็นสไลด์สำหรับผู้เขียนบนสไลด์ที่ 2
    $author->getComments()->addComment("Hello Jawad, this is second slide comment", $pres->getSlides()->get_Item(1), $point, new Java("java.util.Date"));
    # เข้าถึง ISlide ที่ 1
    $slide = $pres->getSlides()->get_Item(0);
    # เมื่อส่งค่า null เป็นอาร์กิวเมนต์ ความคิดเห็นจากผู้เขียนทั้งหมดจะถูกนำมาที่สไลด์ที่เลือก
    $Comments = $slide->getSlideComments($author);
    # เข้าถึงความคิดเห็นที่ตำแหน่งดัชนี 0 สำหรับสไลด์ที่ 1
    $str = $Comments[0]->getText();
    $pres->save("Comments_out.pptx", SaveFormat::Pptx);
    if (java_values($Array->getLength($Comments)) > 0) {
      # เลือกคอลเลกชันความคิดเห็นของผู้เขียนที่ดัชนี 0
      $commentCollection = $Comments[0]->getAuthor()->getComments();
      $Comment = $commentCollection->get_Item(0)->getText();
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **เข้าถึงความคิดเห็นในสไลด์**
โค้ด PHP นี้แสดงวิธีเข้าถึงความคิดเห็นที่มีอยู่บนสไลด์ในงานนำเสนอ PowerPoint:

```php
  # สร้างอินสแตนซ์ของคลาส Presentation
  $pres = new Presentation("Comments1.pptx");
  try {
    foreach($pres->getCommentAuthors() as $commentAuthor) {
      $author = $commentAuthor;
      foreach($author->getComments() as $comment1) {
        $comment = $comment1;
        echo("ISlide :" . $comment->getSlide()->getSlideNumber() . " has comment: " . $comment->getText() . " with Author: " . $comment->getAuthor()->getName() . " posted on time :" . $comment->getCreatedTime() . "\n");
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ตอบกลับความคิดเห็น**
ความคิดเห็นแม่คือความคิดเห็นต้นฉบับหรือความคิดเห็นระดับบนสุดในลำดับชั้นของความคิดเห็นหรือการตอบกลับ การใช้เมธอด [getParentComment](https://reference.aspose.com/slides/th/php-java/aspose.slides/comment/getparentcomment/) หรือ [setParentComment](https://reference.aspose.com/slides/th/php-java/aspose.slides/comment/setparentcomment/) (จากคลาส [Comment](https://reference.aspose.com/slides/th/php-java/aspose.slides/comment/)) คุณสามารถตั้งหรือรับความคิดเห็นแม่ได้

โค้ด PHP นี้แสดงวิธีเพิ่มความคิดเห็นและรับการตอบกลับจากความคิดเห็นเหล่านั้น:

```php
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # เพิ่มความคิดเห็น
    $author1 = $pres->getCommentAuthors()->addAuthor("Author_1", "A.A.");
    $comment1 = $author1->getComments()->addComment("comment1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    # เพิ่มการตอบกลับให้กับ comment1
    $author2 = $pres->getCommentAuthors()->addAuthor("Autror_2", "B.B.");
    $reply1 = $author2->getComments()->addComment("reply 1 for comment 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply1->setParentComment($comment1);
    # เพิ่มการตอบกลับอีกอันให้กับ comment1
    $reply2 = $author2->getComments()->addComment("reply 2 for comment 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply2->setParentComment($comment1);
    # เพิ่มการตอบกลับให้กับการตอบกลับที่มีอยู่
    $subReply = $author1->getComments()->addComment("subreply 3 for reply 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $subReply->setParentComment($reply2);
    $comment2 = $author2->getComments()->addComment("comment 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $comment3 = $author2->getComments()->addComment("comment 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3 = $author1->getComments()->addComment("reply 4 for comment 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3->setParentComment($comment3);
    # แสดงลำดับความสัมพันธ์ของความคิดเห็นบนคอนโซล
    $slide = $pres->getSlides()->get_Item(0);
    $comments = $slide->getSlideComments(null);
    for($i = 0; $i < java_values($Array->getLength($comments)) ; $i++) {
      $comment = $comments[$i];
      while (!java_is_null($comment->getParentComment())) {
        System->out->print("\t");
        $comment = $comment->getParentComment();
      } 
      echo($comments[$i]->getAuthor()->getName() . " : " . $comments[$i]->getText());
      echo();
    }
    $pres->save("parent_comment.pptx", SaveFormat::Pptx);
    # ลบ comment1 และการตอบกลับทั้งหมดของมัน
    $comment1->remove();
    $pres->save("remove_comment.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" title="คำเตือน" %}} 

* เมื่อใช้เมธอด [remove](https://reference.aspose.com/slides/th/php-java/aspose.slides/comment/remove/) (จากคลาส [Comment](https://reference.aspose.com/slides/th/php-java/aspose.slides/comment/)) เพื่อลบความคิดเห็น การตอบกลับของความคิดเห็นนั้นก็จะถูกลบไปด้วย
* หากการตั้งค่า [setParentComment](https://reference.aspose.com/slides/th/php-java/aspose.slides/comment/setparentcomment/) ทำให้เกิดการอ้างอิงแบบวงกลม จะเกิดข้อยกเว้น [PptxEditException](https://reference.aspose.com/slides/th/php-java/aspose.slides/pptxeditexception/)

{{% /alert %}}

## **เพิ่มความคิดเห็นสมัยใหม่**

ในปี 2021 Microsoft ได้นำเสนอ *ความคิดเห็นสมัยใหม่* ใน PowerPoint ฟีเจอร์ความคิดเห็นสมัยใหม่ช่วยปรับปรุงการทำงานร่วมกันใน PowerPoint อย่างมาก ผ่านความคิดเห็นสมัยใหม่ ผู้ใช้ PowerPoint สามารถแก้ไขสถานะความคิดเห็น, ยึดความคิดเห็นกับออบเจกต์และข้อความ, และมีการโต้ตอบได้ง่ายขึ้นอย่างมาก

Aspose Slides รองรับความคิดเห็นสมัยใหม่ด้วยคลาส [ModernComment](https://reference.aspose.com/slides/th/php-java/aspose.slides/moderncomment/) เมธอด [addModernComment](https://reference.aspose.com/slides/th/php-java/aspose.slides/commentcollection/addmoderncomment/) และ [insertModernComment](https://reference.aspose.com/slides/th/php-java/aspose.slides/commentcollection/insertmoderncomment/) ได้เพิ่มเข้าไปในคลาส [CommentCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/commentcollection/)

โค้ด PHP นี้แสดงวิธีเพิ่มความคิดเห็นสมัยใหม่ลงสไลด์ในงานนำเสนอ PowerPoint:

```php
  $pres = new Presentation();
  try {
    $newAuthor = $pres->getCommentAuthors()->addAuthor("Some Author", "SA");
    $modernComment = $newAuthor->getComments()->addModernComment("This is a modern comment", $pres->getSlides()->get_Item(0), null, new Point2DFloat(100, 100), new Java("java.util.Date"));
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ลบความคิดเห็น**

### **ลบทุกความคิดเห็นและผู้เขียน**
โค้ด PHP นี้แสดงวิธีลบความคิดเห็นและผู้เขียนทั้งหมดในงานนำเสนอ:

```php
  $presentation = new Presentation("example.pptx");
  try {
    # ลบความคิดเห็นทั้งหมดจากงานนำเสนอ
    foreach($presentation->getCommentAuthors() as $author) {
      $author->getComments()->clear();
    }
    # ลบผู้เขียนทั้งหมด
    $presentation->getCommentAuthors()->clear();
    $presentation->save("example_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

### **ลบความคิดเห็นที่ระบุ**
โค้ด PHP นี้แสดงวิธีลบความคิดเห็นที่ระบุบนสไลด์:

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # เพิ่มความคิดเห็น...
    $author = $presentation->getCommentAuthors()->addAuthor("Author", "A");
    $author->getComments()->addComment("comment 1", $slide, new Point2DFloat(0.2, 0.2), new Java("java.util.Date"));
    $author->getComments()->addComment("comment 2", $slide, new Point2DFloat(0.3, 0.2), new Java("java.util.Date"));
    # ลบความคิดเห็นทั้งหมดที่มีข้อความ "comment 1"
    foreach($presentation->getCommentAuthors() as $commentAuthor) {
      $toRemove = new Java("java.util.ArrayList");
      foreach($slide->getSlideComments($commentAuthor) as $comment) {
        if ($comment->getText()->equals("comment 1")) {
          $toRemove->add($comment);
        }
      }
      foreach($toRemove as $comment) {
        $commentAuthor->getComments()->remove($comment);
      }
    }
    $presentation->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **คำถามที่พบบ่อย**

**Aspose.Slides รองรับสถานะเช่น ‘resolved’ สำหรับความคิดเห็นสมัยใหม่หรือไม่?**

ใช่. [Modern comments](https://reference.aspose.com/slides/th/php-java/aspose.slides/moderncomment/) มีเมธอด [setStatus](https://reference.aspose.com/slides/th/php-java/aspose.slides/moderncomment/setstatus/) คุณสามารถกำหนดสถานะของความคิดเห็น (เช่น ทำเครื่องหมายว่าแก้ไขแล้ว) และสถานะนี้จะถูกบันทึกในไฟล์และ PowerPoint จะรับรู้

**รองรับการสนทนาที่เป็นเธรด (สายตอบกลับ) หรือไม่ และมีขีดจำกัดการซ้อนกันหรือไม่?**

ใช่. ทุกความคิดเห็นสามารถอ้างอิงถึง [parent comment](https://reference.aspose.com/slides/th/php-java/aspose.slides/comment/getparentcomment/) ของมัน ทำให้สร้างสายตอบกลับได้โดยอิสระ API ไม่ได้ระบุขีดจำกัดความลึกของการซ้อนกัน

**ตำแหน่งของเครื่องหมายความคิดเห็นบนสไลด์กำหนดในระบบพิกัดใด?**

ตำแหน่งจะถูกจัดเก็บเป็นจุดทศนิยมในระบบพิกัดของสไลด์ ซึ่งทำให้คุณสามารถวางเครื่องหมายความคิดเห็นได้อย่างแม่นยำตรงตำแหน่งที่ต้องการ