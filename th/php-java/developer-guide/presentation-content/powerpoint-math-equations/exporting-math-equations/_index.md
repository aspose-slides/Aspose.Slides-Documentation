---
title: ส่งออกสมการคณิตศาสตร์จากงานนำเสนอใน PHP
linktitle: ส่งออกสมการ
type: docs
weight: 30
url: /th/php-java/exporting-math-equations/
keywords:
- ส่งออกสมการคณิตศาสตร์
- ส่งออกสมการเป็น LaTeX
- PowerPoint เป็น LaX
- MathML
- LaTeX
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "ส่งออกสมการคณิตศาสตร์จากงานนำเสนอ PowerPoint ไปยัง LaTeX หรือ MathML โดยตรงด้วย Aspose.Slides สำหรับ PHP ผ่าน Java."
---
## **บทนำ**

Aspose.Slides for PHP ผ่าน Java ช่วยให้คุณสามารถส่งออกสมการคณิตศาสตร์จากงานนำเสนอได้ ตัวอย่างเช่น คุณอาจต้องการดึงสมการคณิตศาสตร์บนสไลด์ (จากงานนำเสนอเฉพาะ) และใช้ในโปรแกรมหรือแพลตฟอร์มอื่น

{{% alert color="primary" %}} 
คุณสามารถส่งออกสมการโดยตรงเป็น LaTeX หรือ MathML ซึ่งเป็นมาตรฐานที่นิยมสำหรับเนื้อหาคณิตศาสตร์ที่ใช้บนเว็บและในหลายแอปพลิเคชัน
{{% /alert %}}

## **ส่งออกสมการคณิตศาสตร์เป็น LaTeX**

Aspose.Slides สามารถแปลงสมการคณิตศาสตร์ใน PowerPoint เป็น LaTeX ได้โดยตรง ไม่จำเป็นต้องใช้ไฟล์ MathML ขั้นกลางหรือโปรแกรมแปลงภายนอก สมการคณิตศาสตร์จะถูกจัดเก็บในกรอบข้อความเป็น [MathPortion](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathportion/) ใช้ [MathPortion::getMathParagraph](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathportion/#getMathParagraph) เพื่อรับ [MathParagraph](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathparagraph/) จากนั้นเรียก [MathParagraph::toLatex](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathparagraph/#toLatex) วิธีนี้จะคืนสตริงที่คุณสามารถบันทึก แสดง ส่งไปยังแอปพลิเคชันอื่น หรือดำเนินการต่อได้

ตัวอย่างต่อไปนี้ตรวจสอบกรอบข้อความทุกกรอบในทุกสไลด์ ค้นหาส่วนของคณิตศาสตร์ทั้งหมด และเขียนสมการแต่ละอันลงในไฟล์ `.tex` แยกกัน:

```php
$presentation = new Presentation("equations.pptx");
$arrayClass = new JavaClass("java.lang.reflect.Array");
$mathPortionClass = new JavaClass("com.aspose.slides.MathPortion");

try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = $slideIndex + 1;
        $equationNumber = 1;
        $textFrames = SlideUtil::getAllTextBoxes($slide);
        $textFrameCount = java_values($arrayClass->getLength($textFrames));

        for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
            $textFrame = $textFrames[$textFrameIndex];
            $paragraphCount = java_values($textFrame->getParagraphs()->getCount());
            for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
                $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
                $portionCount = java_values($paragraph->getPortions()->getCount());
                for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    if (!java_instanceof($portion, $mathPortionClass)) {
                        continue;
                    }

                    $mathParagraph = $portion->getMathParagraph();
                    $latexFileName = "slide_" . $slideNumber . "_equation_" . $equationNumber . ".tex";

                    $latexText = java_values($mathParagraph->toLatex());
                    file_put_contents($latexFileName, $latexText);
                    $equationNumber++;
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

[SlideUtil::getAllTextBoxes](https://reference.aspose.com/slides/th/php-java/aspose.slides/slideutil/#getAllTextBoxes) คืนค่ากรอบข้อความทั้งหมดที่พบในสไลด์ การตรวจสอบประเภท [MathPortion](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathportion/) แยกสมการที่แก้ไขได้จริงออกจากข้อความและรูปภาพทั่วไป

เครื่องยนต์ LaTeX และเทมเพลตเอกสารไม่ได้สนับสนุนคำสั่ง แพกเกจ หรืออักขระ Unicode เดียวกันทั้งหมด ทดสอบสตริงที่คืนค่าด้วยเครื่องยนต์ LaTeX ที่แอปพลิเคชันของคุณใช้ หากสัญลักษณ์หรือองค์ประกอบ Office Math ไม่มีการแสดงผลที่เหมาะสมในสภาพแวดล้อมนั้น ให้แทนที่ในสตริงที่คืนค่าด้วยคำสั่งเฉพาะโครงการ หรือข้ามสมการและบันทึกปัญหาเพื่อตรวจสอบต่อไป

## **บันทึกสมการคณิตศาสตร์เป็น MathML**

แม้ว่ามนุษย์จะเขียนโค้ดสำหรับรูปแบบสมการบางประเภทอย่าง LaTeX ได้ง่าย แต่การเขียนโค้ดสำหรับ MathML นั้นยาก เพราะ MathML ถูกออกแบบให้สร้างขึ้นโดยอัตโนมัติจากแอปพลิเคชัน โปรแกรมต่างๆ สามารถอ่านและแยกวิเคราะห์ MathML ได้ง่าย เนื่องจากโค้ดเป็น XML ทำให้ MathML ถูกใช้งานอย่างทั่วไปเป็นรูปแบบผลลัพธ์และการพิมพ์ในหลายสาขา

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

**สิ่งที่ส่งออกเป็น MathML คืออะไร—ย่อหน้าทั้งหมดหรือบล็อกสูตรแยกส่วน?**

คุณสามารถส่งออกทั้งย่อหน้าคณิตศาสตร์ทั้งหมด ([MathParagraph](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathparagraph/)) หรือบล็อกสูตรแยกส่วน ([MathBlock](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathblock/)) เป็น MathML ทั้งสองประเภทมีเมธอดสำหรับเขียนเป็น MathML

**ฉันจะรู้ได้อย่างไรวัตถุในสไลด์เป็นสูตรคณิตศาสตร์ ไม่ใช่ข้อความหรือรูปภาพทั่วไป?**

สูตรจะอยู่ใน [MathPortion](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathportion/) และมี [MathParagraph](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathparagraph/) ส่วนรูปภาพและข้อความทั่วไปที่ไม่มี [MathParagraph](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathparagraph/) จะไม่สามารถส่งออกเป็นสูตรได้

**MathML ในงานนำมามาจากไหน—เป็นของ PowerPoint เท่านั้นหรือเป็นมาตรฐาน?**

การส่งออกมุ่งหมายที่ MathML มาตรฐาน (XML) Aspose ใช้ Presentation MathML ซึ่งเป็นส่วนย่อยของมาตรฐานที่ได้รับการใช้งานอย่างกว้างขวางในแอปพลิเคชันและบนเว็บ

**การส่งออกสูตรที่อยู่ในตาราง SmartArt กลุ่ม ฯลฯ รองรับหรือไม่?**

รองรับ หากวัตถุนั้นมีส่วนข้อความที่มี [MathParagraph](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathparagraph/) (คือสูตร PowerPoint ของจริง) จะถูกส่งออก หากสูตรฝังเป็นรูปภาพจะไม่ถูกส่งออก

**การส่งออกเป็น MathML ทำให้ไฟล์งานนำเสนอเดิมเปลี่ยนแปลงหรือไม่?**

ไม่ การเขียน MathML เป็นการสืบทอดข้อมูลสูตรเท่านั้น ไม่ได้ทำการแก้ไขไฟล์งานนำเสนอต้นฉบับ