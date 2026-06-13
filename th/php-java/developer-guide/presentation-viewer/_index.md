---
title: สร้างตัวแสดงงานนำเสนอใน PHP
linktitle: ตัวแสดงงานนำเสนอ
type: docs
weight: 50
url: /th/php-java/presentation-viewer/
keywords:
- ดูงานนำเสนอ
- ตัวแสดงงานนำเสนอ
- สร้างตัวแสดงงานนำเสนอ
- ดูไฟล์ PPT
- ดูไฟล์ PPTX
- ดูไฟล์ ODP
- PowerPoint
- OpenDocument
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "สร้างตัวแสดงงานนำเสนอแบบกำหนดเองโดยใช้ Aspose.Slides สำหรับ PHP ผ่าน Java แสดงไฟล์ PowerPoint และ OpenDocument ได้อย่างง่ายดายโดยไม่ต้องใช้ Microsoft PowerPoint."
---
## **บทนำ**

Aspose.Slides for PHP via Java ใช้ในการสร้างไฟล์งานนำเสนอที่มีสไลด์ สไลด์เหล่านี้สามารถดูได้โดยเปิดงานนำเสนอใน Microsoft PowerPoint เป็นต้น อย่างไรก็ตาม บางครั้งนักพัฒนอาจต้องการดูสไลด์เป็นภาพในโปรแกรมดูภาพที่ตนชอบหรือสร้างตัวแสดงงานนำเสนอของตนเอง ในกรณีดังกล่าว Aspose.Slides อนุญาตให้คุณส่งออกสไลด์เดียวเป็นภาพ บทความนี้อธิบายวิธีทำ

## **สร้างภาพ SVG จากสไลด์**

เพื่อสร้างภาพ SVG จากสไลด์การนำเสนอด้วย Aspose.Slides โปรดทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)
1. รับอ้างอิงสไลด์ตามดัชนีของมัน
1. เปิดสตรีมไฟล์
1. บันทึกสไลด์เป็นภาพ SVG ลงในสตรีมไฟล์

```php
$slideIndex = 0;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$svgStream = new Java("java.io.FileOutputStream", "output.svg");
$slide->writeAsSvg($svgStream);
$svgStream->close();

$presentation->dispose();
```

## **สร้าง SVG พร้อม ID รูปร่างที่กำหนดเอง**

Aspose.Slides สามารถใช้เพื่อสร้าง [SVG](https://docs.fileformat.com/page-description-language/svg/) จากสไลด์ที่มี ID รูปร่างที่กำหนดเอง เพื่อทำเช่นนี้ ให้ใช้เมธอด `setId` จาก [SvgShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/svgshape/) `CustomSvgShapeFormattingController` สามารถใช้เพื่อกำหนด ID ของรูปร่าง

```php
$slideIndex = 0;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$shapeFormattingController = java_closure(new CustomSvgShapeFormattingController(0), null, java("com.aspose.slides.ISvgShapeFormattingController"));

$svgOptions = new SVGOptions();
$svgOptions->setShapeFormattingController($shapeFormattingController);

$svgStream = new Java("java.io.FileOutputStream", "output.svg");
$slide->writeAsSvg($svgStream, $svgOptions);
$svgStream->close();

$presentation->dispose();
```
```php
class CustomSvgShapeFormattingController {
    private $m_shapeIndex;

    public function __construct($shapeStartIndex) {
        $this->m_shapeIndex = $shapeStartIndex;
    }

    public function formatShape($svgShape, $shape) {
        $svgShape->setId(sprintf("shape-%d", $m_shapeIndex++));
    }
}
```

## **สร้างภาพย่อสไลด์**

Aspose.Slides ช่วยคุณสร้างภาพย่อของสไลด์ เพื่อสร้างภาพย่อของสไลด์โดยใช้ Aspose.Slides โปรดทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)
1. รับอ้างอิงสไลด์ตามดัชนีของมัน
1. รับภาพย่อของสไลด์ที่อ้างอิงด้วยสเกลที่กำหนด
1. บันทึกภาพย่อในรูปแบบภาพที่ต้องการใดก็ได้

```php
$slideIndex = 0;
$scaleX = 1.0;
$scaleY = $scaleX;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($scaleX, $scaleY);
$image->save("output.jpg", ImageFormat::Jpeg);
$image->dispose();

$presentation->dispose();
```

## **สร้างภาพย่อสไลด์พร้อมขนาดที่กำหนดโดยผู้ใช้**

เพื่อสร้างภาพย่อสไลด์พร้อมขนาดที่กำหนดโดยผู้ใช้ โปรดทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)
1. รับอ้างอิงสไลด์ตามดัชนีของมัน
1. รับภาพย่อของสไลด์ที่อ้างอิงพร้อมขนาดที่กำหนด
1. บันทึกภาพย่อในรูปแบบภาพที่ต้องการใดก็ได้

```php
$slideIndex = 0;
$slideSize = new Java("java.awt.Dimension", 1200, 800);

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($slideSize);
$image->save("output.jpg", ImageFormat::Jpeg);
$image->dispose();

$presentation->dispose();
```

## **สร้างภาพย่อสไลด์พร้อมบันทึกผู้พูด**

เพื่อสร้างภาพย่อของสไลด์พร้อมบันทึกผู้พูดโดยใช้ Aspose.Slides โปรดทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [RenderingOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/renderingoptions/)
1. ใช้เมธอด `RenderingOptions.setSlidesLayoutOptions` เพื่อตั้งตำแหน่งของบันทึกผู้พูด
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)
1. รับอ้างอิงสไลด์ตามดัชนีของมัน
1. รับภาพย่อของสไลด์ที่อ้างอิงโดยใช้ตัวเลือกการเรนเดอร์
1. บันทึกภาพย่อในรูปแบบภาพที่ต้องการใดก็ได้

```php
$slideIndex = 0;

$layoutingOptions = new NotesCommentsLayoutingOptions();
$layoutingOptions->setNotesPosition(NotesPositions::BottomTruncated);

$renderingOptions = new RenderingOptions();
$renderingOptions->setSlidesLayoutOptions($layoutingOptions);

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($renderingOptions);
$image->save("output.png", ImageFormat::Png);
$image->dispose();

$presentation->dispose();
```

## **ตัวอย่างสด**

คุณสามารถลองแอปฟรี [**Aspose.Slides Viewer**](https://products.aspose.app/slides/th/viewer/) เพื่อดูว่าคุณสามารถทำอะไรได้บ้างด้วย Aspose.Slides API:

![ตัวแสดง PowerPoint ออนไลน์](online-PowerPoint-viewer.png)

## **คำถามที่พบบ่อย**

**ฉันสามารถฝังตัวแสดงงานนำเสนอในเว็บแอปพลิเคชันได้หรือไม่?**

ใช่ คุณสามารถใช้ Aspose.Slides ที่ฝั่งเซิร์ฟเวอร์เพื่อเรนเดอร์สไลด์เป็นภาพหรือ HTML แล้วแสดงผลในเบราว์เซอร์ ฟีเจอร์การนำทางและการซูมสามารถทำได้ด้วย JavaScript เพื่อประสบการณ์ที่โต้ตอบได้

**วิธีที่ดีที่สุดในการแสดงสไลด์ภายในตัวแสดงแบบกำหนดเองคืออะไร?**

วิธีแนะนำคือเรนเดอร์แต่ละสไลด์เป็นภาพ (เช่น PNG หรือ SVG) หรือแปลงเป็น HTML ด้วย Aspose.Slides แล้วแสดงผลลัพธ์ภายใน picture box (สำหรับเดสก์ท็อป) หรือคอนเทนเนอร์ HTML (สำหรับเว็บ)

**ฉันจะจัดการกับงานนำเสนอขนาดใหญ่ที่มีสไลด์จำนวนมากอย่างไร?**

สำหรับเดคขนาดใหญ่ ควรพิจารณาการโหลดแบบ lazy-loading หรือการเรนเดอร์ตามความต้องการของสไลด์ หมายความว่าจะสร้างเนื้อหาสไลด์เมื่อผู้ใช้นำทางไปยังสไลด์นั้นเท่านั้น เพื่อลดการใช้หน่วยความจำและเวลาโหลด