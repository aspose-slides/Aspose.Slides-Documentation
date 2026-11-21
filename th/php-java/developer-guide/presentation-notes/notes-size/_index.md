---
title: เปลี่ยนขนาดและทิศทางหน้าบันทึกใน PHP
linktitle: ขนาดหน้าบันทึก
type: docs
weight: 10
url: /th/php-java/notes-size/
keywords:
- ขนาดหน้าบันทึก
- ทิศทางบันทึก
- บันทึกแนวนอน
- บันทึกแนวตั้ง
- ขนาดแฮนด์เอาต์
- PowerPoint
- การนำเสนอ
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "อ่านและเปลี่ยนขนาดหน้าบันทึกใน Aspose.Slides สำหรับ PHP ผ่าน Java, สลับทิศทาง, ตรวจสอบขนาดที่บันทึกไว้, และส่งออกบันทึกหรือแฮนด์เอาต์เป็น PDF และรูปภาพ."
---
## **ภาพรวม**

ใช้ [Presentation::getNotesSize](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/getnotessize/) เพื่อเข้าถึงการตั้งค่าหน้าบันทึกของงานนำเสนอ มันส่งคืนอ็อบเจกต์ [NotesSize](https://reference.aspose.com/slides/th/php-java/aspose.slides/notessize/) ที่เมธอด [setSize](https://reference.aspose.com/slides/th/php-java/aspose.slides/notessize/setsize/) จะกำหนดขนาดหน้ากระดาษ แม้ว่าจะไม่สามารถแทนที่อ็อบเจกต์การตั้งค่าได้ แต่คุณสามารถกำหนดขนาดใหม่ผ่านเมธอดนี้ได้

ความกว้างและความสูงระบุเป็น **points** โดยมี 72 points ต่อหนึ่งนิ้ว ตัวอย่างเช่น 900 × 600 points เท่ากับ 12.5 × 8⅓ นิ้ว การตั้งค่าเหล่านี้ใช้กับงานนำเสนอ ไม่ใช่กับบันทึกของสไลด์แต่ละสไลด์

| การตั้งค่า | วัตถุประสงค์ |
| --- | --- |
| [Presentation::getNotesSize](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/getnotessize/) | ควบคุมขนาดหน้าบันทึกและขนาดหน้ากระดาษที่ใช้สำหรับการส่งออกแฮนด์เอาต์ |
| [Presentation::getSlideSize](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/getslidesize/) | ควบคุมขนาดสไลด์ของงานนำเสนอปกติโดยผ่าน [SlideSize](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidesize/) |

การเปลี่ยนแปลงการตั้งค่าใดๆ จะไม่ทำให้การตั้งค่าอื่นเปลี่ยนโดยอัตโนมัติ การเปลี่ยนทิศทางของหน้าบันทึกก็ไม่ทำให้สไลด์ปกติหมุน ดู [Slide Size](/slides/th/php-java/slide-size/) เพื่อปรับขนาดสไลด์ปกติ

ตัวอย่างด้านล่างใช้ไฟล์ `sample.pptx` ที่มีอยู่แล้ว สำหรับตัวอย่างการส่งออก ให้ใช้งานนำเสนอที่มีสไลด์อย่างน้อยหนึ่งสไลด์ที่มีบันทึกบรรยาย ตัวอย่างแต่ละอันสามารถทำงานแยกกันได้หลังจากโหลด PHP/Java Bridge และ Aspose.Slides PHP wrapper ค่าตัวเลขที่ Java คืนค่าจะถูกแปลงเป็นค่า PHP ด้วย `java_values` ก่อนการเปรียบเทียบหรือการคำนวณ

## **อ่านขนาดและทิศทางของหน้าบันทึก**

อ่านความกว้างและความสูงแล้วเปรียบเทียบเพื่อกำหนดทิศทาง: หน้ากว้างกว่าถือเป็นแนวนอน, หน้า​สูงกว่าถือเป็นแนวตั้ง, และขนาดเท่ากันเป็นหน้ากลมสี่เหลี่ยม ตัวอย่างนี้พิมพ์ขนาดจริงเป็น points โดยไม่สมมติขนาดกระดาษมาตรฐาน

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $size = $presentation->getNotesSize()->getSize();
    $orientation = "Square";

    if (java_values($size->getWidth()) > java_values($size->getHeight())) {
        $orientation = "Landscape";
    } else if (java_values($size->getWidth()) < java_values($size->getHeight())) {
        $orientation = "Portrait";
    }

    echo "Notes page: " . java_values($size->getWidth()) . " x " . java_values($size->getHeight()) . " points" . PHP_EOL;
    echo "Orientation: " . $orientation . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **เปลี่ยนเป็นแนวนอนโดยไม่เปลี่ยนขนาดกระดาษ**

เพื่อเปลี่ยนเฉพาะทิศทาง ให้สลับความกว้างและความสูงที่มีอยู่ สิ่งนี้จะรักษาความยาวของด้านทั้งสองไว้รวมถึงขนาดกระดาษที่กำหนดเอง เงื่อนไขด้านล่างจะป้องกันไม่ให้หน้าที่เป็นแนวนอนอยู่แล้วถูกสลับกลับเป็นแนวตั้งและจะปล่อยหน้าสี่เหลี่ยมให้คงเดิม

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $size = $presentation->getNotesSize()->getSize();

    if (java_values($size->getWidth()) < java_values($size->getHeight())) {
        $width = java_values($size->getWidth());
        $size->setSize(java_values($size->getHeight()), $width);
        $presentation->getNotesSize()->setSize($size);
    }

    $presentation->save("landscape-notes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

สำหรับทิศทางแนวตั้ง ให้ใช้การกำหนดค่าเดียวกันเมื่อ `java_values($size->getWidth()) > java_values($size->getHeight())` ไม่ต้องแทนที่ขนาด A4 หรือ Letter เว้นแต่คุณต้องการเปลี่ยนขนาดกระดาษด้วย

## **ตั้งค่าและตรวจสอบขนาดหน้าบันทึกที่กำหนดเอง**

กำหนดขนาดทั้งสองพร้อมกัน แล้วใช้ [Presentation::save](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/save/) เพื่อบันทึกงานนำเสนอ ตัวอย่างนี้ตั้งค่าหน้าแนวนอนขนาด 900 × 600 points บันทึกเป็น PPTX และเปิดไฟล์ที่บันทึกใหม่อีกครั้งเพื่อตรวจสอบค่าที่บันทึกไว้ การเปรียบเทียบอนุญาตความคลาดเคลื่อน 0.01 point สำหรับค่าจุดทศนิยม; ไม่ได้เป็นการรับประกันความแม่นยำสำหรับทุกรูปแบบไฟล์

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $expectedSize = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($expectedSize);

    $presentation->save("custom-notes.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("custom-notes.pptx");
    try {
        $actualSize = $reopened->getNotesSize()->getSize();
        $widthMatches = abs(java_values($actualSize->getWidth()) - java_values($expectedSize->getWidth())) < 0.01;
        $heightMatches = abs(java_values($actualSize->getHeight()) - java_values($expectedSize->getHeight())) < 0.01;
        $preserved = $widthMatches && $heightMatches;

        echo "Stored notes page: " . java_values($actualSize->getWidth()) . " x " . java_values($actualSize->getHeight()) . " points" . PHP_EOL;
        echo "Size preserved: " . ($preserved ? "true" : "false") . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์ที่คาดไว้คือ `900 x 600 points` และ `Size preserved: true` การตรวจสอบงานนำเสนอที่เปิดใหม่ยืนยันไฟล์ที่บันทึกไว้ ไม่ใช่แค่การตั้งค่าในหน่วยความจำ

## **ส่งออกบันทึกและแฮนด์เอาต์**

ขนาดหน้าเป็นการกำหนดพื้นที่ที่ใช้ได้สำหรับบันทึกหรือการจัดวางแฮนด์เอาต์ ไม่ได้ทำให้รูปแบบเหล่านั้นทำงานโดยอัตโนมัติ: ต้องกำหนดตัวเลือกการส่งออกด้วยเช่นกัน การส่งออกสไลด์ปกติยังคงใช้ขนาดสไลด์เดิม

### **ส่งออกบันทึกเป็น PDF และ PNG**

กำหนด [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/notescommentslayoutingoptions/) ให้กับ [PdfOptions::setSlidesLayoutOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) เพื่อใส่บันทึกใน PDF ตัวอย่างนี้ยังเรนเดอร์สไลด์แรกที่มีบันทึกเป็น PNG โดยใช้ [Slide::getImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/slide/#getImage) และ [RenderingOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/renderingoptions/)

โหมด [BottomTruncated](https://reference.aspose.com/slides/th/php-java/aspose.slides/notespositions/) จะทำให้บันทึกอยู่ในหน้าหนึ่งหน้า; บันทึกที่ไม่พอดีจะถูกตัด PDF ใช้หน้าขนาด 900 × 600 points ที่สเกลภาพ 1 × 1 ตามด้านล่าง PNG จะได้ขนาด 900 × 600 พิกเซล Points บรรยายเรขาคณิตของหน้า; พิกเซลบรรยายผลลัพธ์ raster ซึ่งขนาดยังขึ้นกับสเกลการเรนเดอร์

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\PdfOptions;
use aspose\slides\RenderingOptions;
use aspose\slides\ImageFormat;

$presentation = new Presentation("sample.pptx");
try {
    $size = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($size);

    $layout = new NotesCommentsLayoutingOptions();
    $layout->setNotesPosition(NotesPositions::BottomTruncated);

    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($layout);

    $presentation->save("notes.pdf", SaveFormat::Pdf, $pdfOptions);

    $renderingOptions = new RenderingOptions();
    $renderingOptions->setSlidesLayoutOptions($layout);

    $image = $presentation->getSlides()->get_Item(0)->getImage($renderingOptions, 1, 1);
    try {
        $image->save("first-slide-notes.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

สำหรับการส่งออก PDF ที่มีบันทึกยาว [BottomFull](https://reference.aspose.com/slides/th/php-java/aspose.slides/notespositions/) จะอนุญาตหน้าเพิ่มเติมตามต้องการ อย่าใช้โหมดนี้กับการเรียกภาพสไลด์เดียวด้านบนซึ่งไม่รองรับ หลังจากปรับขนาด ให้ตรวจสอบผลลัพธ์ว่ามีบันทึกถูกตัดหรือไม่และตำแหน่งของออบเจกต์ notes‑master ที่มีอยู่; การเปลี่ยนขนาดหน้าเพียงอย่างเดียวไม่ควรถูกถือว่าเป็นการรับประกันว่าเนื้อหาทั้งหมดจะพอดี ดู [Convert PowerPoint to PDF with Notes](/slides/th/php-java/convert-powerpoint-to-pdf-with-notes/) เพื่อเรียนรู้เพิ่มเติมเกี่ยวกับการส่งออกบันทึก

### **ส่งออกแฮนด์เอาต์เป็น PDF**

ใช้ [HandoutLayoutingOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/handoutlayoutingoptions/) เพื่อวางรูปย่อของหลายสไลด์ในหนึ่งหน้า ตัวอย่างต่อไปนี้ตั้งค่าหน้า 900 × 600 points และใช้ [HandoutType::Handouts4Horizontal](https://reference.aspose.com/slides/th/php-java/aspose.slides/handouttype/) เพื่อจัดสไลด์สูงสุดสี่สไลด์ต่อหน้า การตั้งค่ารูปแนวนอนควบคุมลำดับสไลด์; ทิศทางหน้ามาจากความกว้างและความสูงของมัน

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PdfOptions;
use aspose\slides\HandoutLayoutingOptions;
use aspose\slides\HandoutType;

$presentation = new Presentation("sample.pptx");
try {
    $size = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($size);

    $layout = new HandoutLayoutingOptions();
    $layout->setHandout(HandoutType::Handouts4Horizontal);

    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($layout);

    $presentation->save("handouts.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

การเปลี่ยนขนาดหน้าจะเปลี่ยนพื้นที่ที่ใช้ได้สำหรับกริดแฮนด์เอาต์โดยไม่เปลี่ยนขนาดสไลด์ต้นฉบับ สำหรับภาพแฮนด์เอาต์ ให้ใช้ [Presentation::getImages](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/getimages/) พร้อมการจัดวางแฮนด์เอาต์ แทนการใช้เมธอดภาพของสไลด์เดี่ยว ใน Aspose.Slides การเรนเดอร์แฮนด์เอาต์ระดับงานนำใช้ขนาดหน้าบันทึก ขณะที่การเรียกภาพสไลด์เดี่ยวจะไม่สร้างหน้าแฮนด์เอาต์ ดู [Handout Mode](/slides/th/php-java/convert-powerpoint-in-handout-mode/) เพื่อดูตัวเลือกการจัดวาง

## **ขนาดหน้าในการดู, การส่งออกและการพิมพ์**

เก็บขนาดงานนำเสนอที่จัดเก็บ, ขนาดหน้าที่ส่งออก, และขนาดกระดาษที่พิมพ์แยกกันอย่างชัดเจน:

- **Presentation viewers:** ตัวดูสามารถแสดงหรือพิมพ์บันทึกโดยใช้กฎการจัดวางของตัวเอง หากแอปพลิเคชันอื่นบันทึกไฟล์ ให้เปิดใหม่และตรวจสอบขนาดอีกครั้ง; การแปลงรูปแบบของแอปนั้นอาจทำให้ค่าปกติ化
- **Export formats:** ตัวอย่าง PDF ของบันทึกและแฮนด์เอาต์ข้างบนใช้ขนาดหน้าที่กำหนดไว้ รูปภาพ raster ใช้ขนาดพิกเซลจำนวนเต็มและสเกลการเรนเดอร์ ดังนั้นค่าจุดเศษส่วนอาจถูกปัดเป็นจำนวนเต็มในผลลัพธ์ภาพ การส่งออกสไลด์ปกติไม่ใช้ขนาดหน้าบันทึก
- **Printer drivers:** การเลือกกระดาษ, การหมุนอัตโนมัติ, และการตั้งค่าให้พอดีกับหน้าอาจเปลี่ยนผลลัพธ์ทางกายภาพโดยไม่เปลี่ยนขนาดที่เก็บในงานนำเสนอหรือ PDF สำหรับขนาดกระดาษเฉพาะ ให้จับคู่การตั้งค่าปริ๊นเตอร์และตรวจสอบตัวอย่างการพิมพ์

## **คำถามที่พบบ่อย**

**ฉันสามารถตั้งค่าขนาดบันทึกสำหรับสไลด์เดียวได้ไหม?**

ขนาดหน้าบันทึกเป็นการตั้งค่าระดับงานนำเสนอ สไลด์แต่ละสไลด์อาจมีเนื้อหาบันทึกที่แตกต่างกัน แต่คุณสมบัตินี้ไม่ได้ให้ขนาดหน้าที่แยกกันสำหรับแต่ละสไลด์

**ทำไมการเปลี่ยนทิศทางของบันทึกไม่ทำให้สไลด์ของฉันเปลี่ยน?**

หน้าบันทึกและสไลด์ปกติมีขนาดอิสระกัน ใช้การตั้งค่าขนาดสไลด์ปกติเมื่อคุณต้องการปรับขนาดสไลด์เอง

**ทำไมผลลัพธ์ที่บันทึกหรือพิมพ์ออกมามีขนาดต่างกัน?**

เปิดงานนำเสนอที่บันทึกไว้ใหม่และเปรียบเทียบขนาดบันทึกของมัน หากมีการเปลี่ยนแปลง ให้ตรวจสอบว่าการบันทึกหรือการแปลงไฟล์ในแอปพลิเคชันอื่นทำให้การตั้งค่าหน้าเปลี่ยนหรือไม่ หากไม่เปลี่ยนให้ตรวจสอบการจัดวางการส่งออก, สเกลภาพ, การตั้งค่าตัวดู, และการเลือกกระดาษของเครื่องพิมพ์