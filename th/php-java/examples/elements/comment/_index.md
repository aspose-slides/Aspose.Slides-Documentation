---
title: คอมเมนต์
type: docs
weight: 230
url: /th/php-java/examples/elements/comment/
keywords:
- คอมเมนต์
- คอมเมนต์สมัยใหม่
- เพิ่มคอมเมนต์
- เข้าถึงคอมเมนต์
- ลบคอมเมนต์
- ตอบกลับคอมเมนต์
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "จัดการคอมเมนต์สไลด์ใน PHP ด้วย Aspose.Slides: เพิ่ม, อ่าน, ตอบกลับ, แก้ไข, ลบ และทำงานกับคอมเมนต์แบบเธรดสำหรับ PowerPoint และ OpenDocument."
---
สาธิตการเพิ่ม, อ่าน, ลบ และตอบกลับคอมเมนต์สมัยใหม่โดยใช้ **Aspose.Slides for PHP via Java**.

## **เพิ่มคอมเมนต์สมัยใหม่**
สร้างคอมเมนต์ที่เขียนโดยผู้ใช้และบันทึกงานนำเสนอ

```php
function addModernComment() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // เพิ่มคอมเมนต์สมัยใหม่.
        $author = $presentation->getCommentAuthors()->addAuthor("User", "U1");
        $author->getComments()->addModernComment("This is a modern comment", $slide, null, new Point2DFloat(100, 100), new Java("java.util.Date"));

        $presentation->save("modern_comment.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **เข้าถึงคอมเมนต์สมัยใหม่**
อ่านคอมเมนต์สมัยใหม่จากงานนำเสนอที่มีอยู่

```php
function accessModernComment() {
    $presentation = new Presentation("modern_comment.pptx");
    try {
        $author = $presentation->getCommentAuthors()->get_Item(0);
        $comment = $author->getComments()->get_Item(0);
        echo "Author: " . $author->getName() . ", Comment: " . $comment->getText() . PHP_EOL;
    } finally {
        $presentation->dispose();
    }
}
```

## **ลบคอมเมนต์สมัยใหม่**
ลบคอมเมนต์และบันทึกไฟล์ที่อัปเดต

```php
function removeModernComment() {
    $presentation = new Presentation("modern_comment.pptx");
    try {
        $author = $presentation->getCommentAuthors()->get_Item(0);
        $comment = $author->getComments()->get_Item(0);

        $comment->remove();

        $presentation->save("modern_comment_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **ตอบกลับคอมเมนต์สมัยใหม่**
เพิ่มการตอบกลับให้กับคอมเมนต์สมัยใหม่หลัก

```php
function replyToModernComment() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // เพิ่มผู้เขียนคอมเมนต์.
        $author = $presentation->getCommentAuthors()->addAuthor("User", "U1");

        // เพิ่มคอมเมนต์หลักและการตอบกลับ.
        $parent = $author->getComments()->addModernComment("Parent comment", $slide, null, new Point2DFloat(100, 100), new Java("java.util.Date"));
        $reply1 = $author->getComments()->addModernComment("Reply 1", $slide, null, new Point2DFloat(110, 100), new Java("java.util.Date"));
        $reply2 = $author->getComments()->addModernComment("Reply 2", $slide, null, new Point2DFloat(120, 100), new Java("java.util.Date"));

        // ตั้งค่าคอมเมนต์หลักสำหรับการตอบกลับ.
        $reply1->setParentComment($parent);
        $reply2->setParentComment($parent);

        // บันทึกงานนำเสนอพร้อมการตอบกลับ.
        $presentation->save("modern_comment_replies.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```