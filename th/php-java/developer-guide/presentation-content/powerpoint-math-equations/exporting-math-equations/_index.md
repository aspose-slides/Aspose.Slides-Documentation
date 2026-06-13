---
title: ส่งออกสมการคณิตศาสตร์จากงานนำเสนอใน PHP
linktitle: ส่งออกสมการ
type: docs
weight: 30
url: /th/php-java/exporting-math-equations/
keywords:
- ส่งออกสมการคณิตศาสตร์
- MathML
- LaTeX
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "เปิดใช้งานการส่งออกสมการคณิตศาสตร์จาก PowerPoint ไปยัง MathML ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java อย่างไร้รอยต่อ — รักษาการจัดรูปแบบและเพิ่มความเข้ากันได้."
---
## **บทนำ**

Aspose.Slides for PHP via Java ช่วยให้คุณสามารถส่งออกสมการคณิตศาสตร์จากงานนำเสนอได้ ตัวอย่างเช่น คุณอาจต้องการดึงสมการคณิตศาสตร์จากสไลด์ (จากงานนำเสนอเฉพาะ) และใช้ในโปรแกรมหรือแพลตฟอร์มอื่น

{{% alert color="primary" %}} 
คุณสามารถส่งออกสมการเป็น MathML ซึ่งเป็นรูปแบบหรือมาตรฐานที่ได้รับความนิยมสำหรับสมการคณิตศาสตร์และเนื้อหาอื่นที่คล้ายกันที่พบบนเว็บและในหลายแอปพลิเคชัน
{{% /alert %}}

## **บันทึกสมการคณิตศาสตร์เป็น MathML**

แม้ผู้คนจะเขียนโค้ดสำหรับรูปแบบสมการบางอย่างอย่าง LaTeX ได้ง่าย แต่การเขียนโค้ดสำหรับ MathML นั้นยาก เนื่องจาก MathML ถูกออกแบบให้สร้างโดยแอปพลิเคชันโดยอัตโนมัติ โปรแกรมต่าง ๆ สามารถอ่านและแปล MathML ได้อย่างง่ายดายเพราะโค้ดของมันอยู่ในรูปแบบ XML ดังนั้น MathML จึงเป็นรูปแบบการส่งออกและการพิมพ์ที่ใช้กันทั่วไปในหลายสาขา

ตัวอย่างโค้ดนี้แสดงวิธีส่งออกสมการคณิตศาสตร์จากงานนำเสนอเป็น MathML:
```php
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addMathShape(0, 0, 500, 50);
    $mathParagraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();
    $mathParagraph->add(new MathematicalText("a")->setSuperscript("2")->join("+")->join(new MathematicalText("b")->setSuperscript("2"))->join("=")->join(new MathematicalText("c")->setSuperscript("2")));
    $stream = new Java("java.io.FileOutputStream", "mathml.xml");
    $mathParagraph->writeAsMathMl($stream);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **คำถามที่พบบ่อย**

**อะไรที่ถูกส่งออกเป็น MathML จริง ๆ — ย่อหน้าหรือบล็อกสูตรแยกส่วน?**

คุณสามารถส่งออกได้ทั้งย่อหน้าคณิตศาสตร์ทั้งหมด ([MathParagraph](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathparagraph/)) หรือบล็อกสูตรแยกส่วน ([MathBlock](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathblock/)) เป็น MathML ทั้งสองประเภทมีเมธอดสำหรับเขียนเป็น MathML

**ฉันจะรู้ได้อย่างไรวัตถุบนสไลด์เป็นสูตรคณิตศาสตร์ไม่ใช่ข้อความหรือรูปภาพทั่วไป?**

สูตรจะอยู่ใน [MathPortion](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathportion/) และมี [MathParagraph](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathparagraph/) ภาพและข้อความทั่วไปที่ไม่มี [MathParagraph](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathparagraph/) จะไม่สามารถส่งออกเป็นสูตรได้

**MathML มาจากงานนำเสนอจากที่ไหน — เป็นของ PowerPoint เฉพาะหรือเป็นมาตรฐาน?**

การส่งออกมุ่งเป้าไปที่ MathML มาตรฐาน (XML) Aspose ใช้ Presentation MathML ซึ่งเป็นส่วนย่อยของมาตรฐานที่ใช้สำหรับการนำเสนอ ซึ่งเป็นที่ใช้กันอย่างกว้างขวางในแอปพลิเคชันและบนเว็บ

**การส่งออกสูตรภายในตาราง, SmartArt, กลุ่ม ฯลฯ รองรับหรือไม่?**

ใช่ หากวัตถุนั้นมีส่วนข้อความที่มี [MathParagraph](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathparagraph/) (เช่นสูตร PowerPointของจริง) จะถูกส่งออก หากสูตรฝังเป็นรูปภาพจะไม่ถูกส่งออก

**การส่งออกเป็น MathML ทำให้ไฟล์งานนำเสนอเดิมเปลี่ยนแปลงหรือไม่?**

ไม่ การเขียน MathML เป็นการทำซีเรียลไลเซชันของเนื้อหาสูตร จึงไม่ได้แก้ไขไฟล์งานนำเสนอ