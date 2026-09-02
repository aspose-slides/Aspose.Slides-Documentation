---
title: ผสานการนำเสนออย่างมีประสิทธิภาพใน PHP
linktitle: ผสานการนำเสนอ
type: docs
weight: 40
url: /th/php-java/merge-presentation/
keywords:
- ผสาน PowerPoint
- ผสานการนำเสนอ
- ผสานสไลด์
- ผสาน PPT
- ผสาน PPTX
- ผสาน ODP
- รวม PowerPoint
- รวมการนำเสนอ
- รวมสไลด์
- รวม PPT
- รวม PPTX
- รวม ODP
- PHP
- Aspose.Slides
description: "เรียนรู้วิธีผสานการนำเสนอ PowerPoint และ OpenDocument ใน PHP ด้วยการโคลนสไลด์ การควบคุมมาสเตอร์และเลเอาต์ การปรับขนาดเนื้อหาสไลด์ การคงส่วนต่าง ๆ และการจัดการไฟล์ที่มีการป้องกันหรือมีขนาดใหญ่"
---
## **ภาพรวม**

Aspose.Slides for PHP via Java ผสานการนำเสนอโดยการโคลนสไลด์จาก [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) หนึ่งไปยังอีกอันหนึ่ง การดำเนินการหลักคือ [SlideCollection::addClone()](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidecollection/addclone/)，ซึ่งสามารถคงรูปแบบของสไลด์ต้นฉบับหรือแนบสไลด์ที่โคลนไปยังมาสเตอร์หรือเลเอาต์ในงานนำเสนอปลายทางได้

บทความนี้ครอบคลุมเวิร์กโฟลว์การผสานที่พบมากที่สุด:

- ผสานสไลด์ทั้งหมดพร้อมคงรูปแบบต้นฉบับ;
- ผสานสไลด์ที่เลือก;
- ใช้มาสเตอร์จากงานนำเสนอปลายทาง;
- ใช้เลเอาต์เฉพาะจากงานนำเสนอปลายทาง;
- ปรับขนาดสไลด์ที่ต่างกันให้เป็นมาตรฐานก่อนผสาน;
- เพิ่มสไลด์ที่โคลนเข้าไปในส่วน (section);
- ผสานหลายงานนำเสนอในเวิร์กโฟลว์แบบต้นสุดถึงปลายสุด;
- จัดการมาสเตอร์, แหล่งข้อมูล, โน้ต, ความคิดเห็น, สื่อ, ฟอนต์, รหัสผ่าน, ไฟล์ขนาดใหญ่, และข้อกังวลเกี่ยวกับการทำงานหลายเธรด

## **วิธีการโคลนสไลด์มีผลต่อมาสเตอร์และเลเอาต์อย่างไร**

สไลด์สืบมรดกรูปลักษณ์ส่วนใหญ่จากเลเอาต์และมาสเตอร์ ด้วยเหตุนี้ overload ของการโคลนที่คุณเลือกจะกำหนดว่าการผสานสไลด์จะถูกรวมเข้ากับงานนำเสนอปลายทางอย่างไร

ใช้ [SlideCollection::addClone()](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidecollection/addclone/) หนึ่งในวิธีต่อไปนี้:

- `addClone(sourceSlide)` — คงเลเอาต์และรูปแบบของสไลด์ต้นฉบับ เมื่อจำเป็น มาสเตอร์ต้นฉบับจะถูกโคลนเข้าสู่งานนำเสนอปลายทางโดยอัตโนมัติ Aspose.Slides จะติดตามมาสเตอร์ที่โคลนอัตโนมัติเพื่อป้องกันการโคลนมาสเตอร์เดียวกันซ้ำหลายครั้ง
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — แนบสไลด์ที่โคลนไปยัง [MasterSlide](https://reference.aspose.com/slides/th/php-java/aspose.slides/masterslide/) ปลายทางเฉพาะ Aspose.Slides จะค้นหาเลเอาต์ที่ตรงกันภายใต้มาสเตอร์นั้นตามประเภทหรือชื่อของเลเอาต์
- `addClone(sourceSlide, destinationLayout)` — แนบสไลด์ที่โคลนโดยตรงไปยัง [LayoutSlide](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutslide/) ปลายทางเฉพาะ

มาสเตอร์หรือเลเอาต์ที่ส่งให้ overload `addClone` ต้องเป็นของ **งานนำเสนอปลายทาง** ไม่ใช่งานนำเสนอแหล่ง

## **ผสานการนำเสนอทั้งหมดและคงรูปแบบต้นฉบับ**

วิธีการผสานที่ง่ายที่สุดคือคัดลอกสไลด์ทุกสไลด์จากงานนำเสนอแหล่งไปยังงานนำเสนอปลายทาง นี่เป็นตัวเลือกที่เหมาะเมื่อสไลด์ที่นำเข้าต้องรักษาธีม, มาสเตอร์, และความสัมพันธ์ของเลเอาต์เดิมไว้

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

ผลลัพธ์อาจมีมาสเตอร์หลายชุดเมื่อแหล่งและปลายทางใช้ดีไซน์ต่างกัน ซึ่งเป็นการคาดหวังเมื่อต้องการคงรูปแบบต้นฉบับไว้

## **ผสานสไลด์ที่เลือก**

คุณไม่จำเป็นต้องโคลนสไลด์ทั้งหมด ตัวอย่างต่อไปนี้นำเข้าเฉพาะสไลด์ที่เลือกตามดัชนีจากงานนำเสนอแหล่ง

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $slideIndexes = [0, 2, 4];

        foreach ($slideIndexes as $index) {
            $destination->getSlides()->addClone($source->getSlides()->get_Item($index));
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-selected-slides.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

ตรวจสอบดัชนีสไลด์ก่อนโคลนเมื่อมาจากข้อมูลผู้ใช้หรือการกำหนดค่าภายนอก

## **ผสานสไลด์โดยใช้มาสเตอร์ปลายทาง**

ใช้ overload [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidecollection/addclone/) เมื่อสไลด์ที่นำเข้าต้องใช้มาสเตอร์ที่มีอยู่แล้วในงานนำเสนอปลายทาง

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $destinationMaster = $destination->getMasters()->get_Item(0);

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $destinationMaster, true);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-destination-master.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Aspose.Slides จะเลือกเลเอาต์ที่เหมาะสมภายใต้มาสเตอร์ที่ระบุโดยการจับคู่ประเภทหรือชื่อของเลเอาต์ต้นทาง หากไม่มีเลเอาต์ที่เหมาะสมและ `allowCloneMissingLayout` มีค่า `true` เลเอาต์ต้นทางจะถูกโคลนเพื่อให้สไลด์สามารถเพิ่มได้ หากเป็น `false` จะมีการโยน [PptxEditException](https://reference.aspose.com/slides/th/php-java/aspose.slides/pptxeditexception/)

ใช้ `false` เมื่อคุณต้องการให้การผสานล้มเหลวแทนการเพิ่มเลเอาต์ใหม่ในมาสเตอร์ปลายทาง

## **ผสานสไลด์โดยใช้เลเอาต์ปลายทางเฉพาะ**

ใช้ overload [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidecollection/addclone/) เมื่อคุณทราบเลเอาต์ปลายทางที่สไลด์ที่นำเข้าต้องใช้อย่างชัดเจน

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $destinationLayout = $destination->getLayoutSlides()->get_Item(0);

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $destinationLayout);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-destination-layout.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

การใช้เลเอาต์ปลายทางจะเปลี่ยนความสัมพันธ์ของเลเอาต์ที่สืบมรดก; ไม่ได้ออกแบบใหม่เนื้อหาของสไลด์ต้นทาง หากเลเอาต์ของแหล่งและปลายทางมีโครงสร้าง placeholder แตกต่างกัน ให้ตรวจสอบผลลัพธ์เพื่อยืนยันว่าการจัดรูปแบบและพฤติกรรมของ placeholder เหมาะสม

## **ผสานการนำเสนอที่มีขนาดสไลด์ต่างกัน**

การนำเสนอที่มีขนาดสไลด์ต่างกันสามารถผสานกันได้ แต่การโคลนสไลด์เข้าไปในงานนำเสนอที่มีขนาดสไลด์อื่นจะไม่ออกแบบเนื้อหาใหม่ให้เข้ากับแคนวาสขนาดใหม่ รูปร่างอาจหลุดตำแหน่ง, ถูกยืด/ย่อโดยไม่คาดคิด, หรืออยู่นอกพื้นที่สไลด์ที่มองเห็นได้

วิธีที่เป็นประโยชน์คือปรับขนาดงานนำเสนอแหล่งก่อนโคลน วิธี [SlideSize::setSize()](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidesize/setsize/) สามารถย่อ/ขยายเนื้อหาที่มีอยู่พร้อมกับเปลี่ยนขนาดสไลด์ได้ [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidesizescaletype/) จะย่อเนื้อหาให้พอดีกับขนาดที่ระบุ

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $sourceWidth = java_values($source->getSlideSize()->getSize()->getWidth());
        $sourceHeight = java_values($source->getSlideSize()->getSize()->getHeight());
        $destinationWidth = java_values($destination->getSlideSize()->getSize()->getWidth());
        $destinationHeight = java_values($destination->getSlideSize()->getSize()->getHeight());

        if ($sourceWidth != $destinationWidth || $sourceHeight != $destinationHeight) {
            $source->getSlideSize()->setSize($destinationWidth, $destinationHeight, SlideSizeScaleType::EnsureFit);
        }

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-same-slide-size.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

การปรับขนาดจะเปลี่ยนวัตถุงานนำเสนอแหล่งในหน่วยความจำ หากคุณต้องการให้งานนำเสนอแหล่งต้นฉบับคงอยู่สำหรับการทำงานอื่น เปิดอินสแตนซ์แยกสำหรับการผสาน

## **ผสานสไลด์เข้าสู่ Section ของงานนำเสนอ**

ลูปโคลนสไลด์พื้นฐานจะไม่สร้างโครงสร้าง Section ของงานนำเสนอแหล่งใหม่ หาก Section มีความสำคัญในผลลัพธ์ ให้สร้างหรือเลือก Section ในงานนำเสนอปลายทางและโคลนสไลด์เข้าไปในนั้นโดยใช้ [addClone(Slide, Section)](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidecollection/addclone/)

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $importedSection = $destination->getSections()->appendEmptySection("Imported slides");

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $importedSection);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-section.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

สไลด์ที่โคลนจะถูกเพิ่มต่อท้าย Section ปลายทางที่กำหนด เพื่อคงหลาย Section ของแหล่ง ให้เรียกใช้ [Presentation::getSections](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation/#getSections) เพื่อนับ Section ของแหล่ง, ดึงสไลด์ของแต่ละ Section ด้วย [Section::getSlidesListOfSection](https://reference.aspose.com/slides/th/php-java/aspose.slides/Section/#getSlidesListOfSection), สร้าง Section ใหม่ในปลายทาง, แล้วโคลนสไลด์ที่ได้ไปยัง Section ที่สอดคล้องกัน ดูตัวอย่างการนับ Section ทั้งหมดใน [Manage Slide Sections](/slides/th/php-java/slide-section/) สำหรับกรณีที่รวม Section ว่างและการเปลี่ยนแปลงโครงสร้าง

## **ผสานหลายงานนำเสนออย่างปลอดภัย**

ตัวอย่างแบบต้นสุดถึงปลายสุดต่อไปนี้ใช้งานนำเสนอแรกเป็นปลายทาง, ปรับขนาดสไลด์ของแต่ละแหล่งเพิ่มเติม, เปิดแต่ละแหล่งเฉพาะช่วงที่ทำการคัดลอก, และบันทึกไฟล์สุดท้ายเมื่อเสร็จ

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$inputFiles = ["part1.pptx", "part2.pptx", "part3.pptx"];

$merged = new Presentation($inputFiles[0]);
try {
    $mergedWidth = java_values($merged->getSlideSize()->getSize()->getWidth());
    $mergedHeight = java_values($merged->getSlideSize()->getSize()->getHeight());

    for ($fileIndex = 1; $fileIndex < count($inputFiles); $fileIndex++) {
        $source = new Presentation($inputFiles[$fileIndex]);
        try {
            $sourceWidth = java_values($source->getSlideSize()->getSize()->getWidth());
            $sourceHeight = java_values($source->getSlideSize()->getSize()->getHeight());

            if ($sourceWidth != $mergedWidth || $sourceHeight != $mergedHeight) {
                $source->getSlideSize()->setSize($mergedWidth, $mergedHeight, SlideSizeScaleType::EnsureFit);
            }

            foreach ($source->getSlides() as $slide) {
                $merged->getSlides()->addClone($slide);
            }
        } finally {
            $source->dispose();
        }
    }

    $merged->save("merged.pptx", SaveFormat::Pptx);
} finally {
    $merged->dispose();
}
```

นี่เป็นฐานที่ดีสำหรับคงรูปแบบต้นฉบับของสไลด์ที่นำเข้า หากผลลัพธ์ต้องใช้ธีมเดียวของปลายทาง ให้แทนที่การเรียก `addClone($slide)` ธรรมดาด้วย overload มาสเตอร์หรือเลเอาต์ปลายทางที่ได้อธิบายไว้ก่อนหน้า

## **ข้อควรพิจารณาเชิงปฏิบัติ**

### **มาสเตอร์, เลเอาต์, และความแม่นยำของรูปแบบ**

การโคลนสไลด์พื้นฐานอาจนำมาสเตอร์ของแหล่งเข้ามาในงานนำเสนอปลายทางโดยอัตโนมัติ Aspose.Slides เก็บทะเบียนสำหรับมาสเตอร์ที่โคลนอัตโนมัติเพื่อหลีกเลี่ยงการโคลนมาสเตอร์เดียวกันซ้ำหลายครั้ง มาสเตอร์ที่โคลนด้วยตนเองจะไม่ได้ถูกบันทึกในทะเบียนนั้น ดังนั้นหลีกเลี่ยงการโคลนมาสเตอร์ล่วงหน้าหากไม่ได้ต้องการควบคุมโครงสร้างมาสเตอร์อย่างชัดเจน

อย่า assume ว่ามาสเตอร์หรือเลเอาต์สองชุดที่มีชื่อเดียวกันจะเหมือนกันในเชิงภาพ หากเทมเพลตขององค์กรต้องควบคุมลักษณะสุดท้าย ให้เลือกมาสเตอร์หรือเลเอาต์ปลายทางอย่างเจาะจงและตรวจสอบผลลัพธ์หลังการผสาน

### **โน้ตและคอมเมนต์**

โน้ตของผู้พูดและคอมเมนต์ของสไลด์ถูกเชื่อมกับเนื้อหาสไลด์และจะคัดลอกเมื่อสไลด์ถูกโคลน Aspose.Slides ยังมี API เฉพาะสำหรับ [presentation notes](/slides/th/php-java/presentation-notes/) และ [presentation comments](/slides/th/php-java/presentation-comments/)

หากการจัดรูปแบบของหน้าโน้ตสำคัญ ให้ตรวจสอบงานนำเสนอที่ผสานแล้ว เนื่องจากโน้ตมาสเตอร์เป็นวัตถุระดับงานนำเสนอและอาจแตกต่างกันระหว่างไฟล์แหล่ง สำหรับเวิร์กโฟลว์การตรวจสอบ ให้ตรวจสอบผู้เขียนคอมเมนต์และคอมเมนต์แบบเธรดหลังการรวมไฟล์จากผู้เขียนหรือเทมเพลตต่างกัน

### **รูปภาพ, เสียง, วิดีโอ, วัตถุ OLE, และลิงก์ภายนอก**

สไลด์อาจอ้างอิงแหล่งทรัพยากรระดับงานนำเสนอ เช่น รูปภาพ, เสียงฝัง, วิดีโอฝัง, และข้อมูล OLE ให้โคลนสไลด์โดยตรงแทนการคัดลอกรูปแบบที่มองเห็นเท่านั้น เพื่อให้ Aspose.Slides สามารถคงความสัมพันธ์ของสไลด์ต่อทรัพยากรเหล่านั้น

ทรัพยากรที่ฝังและลิงก์ควรจัดการแตกต่างกัน ลิงก์เสียง, วิดีโอ, วัตถุ OLE หรือ hyperlink ยังคงขึ้นกับเป้าหมายภายนอก; การโคลนสไลด์ไม่ได้เปลี่ยนลิงก์ภายนอกให้เป็นเนื้อหาฝัง ตรวจสอบเส้นทางและ URL ของทรัพยากรที่ลิงก์ในสภาพแวดล้อมที่งานนำเสนอที่ผสานจะถูกเปิด

Aspose.Slides ติดตามมาสเตอร์ที่โคลนอัตโนมัติ แต่ไม่ได้รับประกันว่าทรัพยากรไบนารีที่ตรงกันจากงานนำเสนอแหล่งที่ไม่เกี่ยวข้องจะถูกลบซ้ำอย่างทั่วไป หากขนาดไฟล์ผลลัพธ์สำคัญ ให้ตรวจสอบแพ็กเกจที่ผสานและวัดขนาดผลลัพธ์ด้วยตนเอง แทนพึ่งพาการลบซ้ำโดยนัย

### **ฟอนต์ฝังและความพร้อมใช้งานของฟอนต์**

ฟอนต์จัดการระดับงานนำเสนอ หากต้องการให้ตัวอักษรคงที่ในเครื่องหลายเครื่อง อย่า assume ว่าการโคลนสไลด์อย่างเดียวรับประกันว่าฟอนต์ที่ต้องการทั้งหมดจะพร้อมในสภาพแวดล้อมปลายทาง คุณสามารถตรวจสอบฟอนต์ที่ฝังด้วย [FontsManager::getEmbeddedFonts()](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontsmanager/getembeddedfonts/) และจัดการการฝังอย่างชัดเจนตามที่อธิบายใน [Embed Fonts in Presentations](/slides/th/php-java/embedded-font/)

นอกจากนี้ต้องตรวจสอบว่าคุณได้รับอนุญาตให้ฝังฟอนต์ที่ใช้ในไฟล์แหล่งหรือไม่ เนื้อหาใบอนุญาตฟอนต์อาจจำกัดการฝังได้

### **งานนำเสนอที่มีรหัสผ่าน**

ไฟล์แหล่งที่มีรหัสผ่านต้องเปิดสำเร็จก่อนจึงจะโคลนสไลด์ได้ ให้ใส่รหัสผ่านผ่าน [LoadOptions::setPassword()](https://reference.aspose.com/slides/th/php-java/aspose.slides/loadoptions/setpassword/)

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("YOUR_PASSWORD");

$source = new Presentation("protected.pptx", $loadOptions);
try {
    // ทำงานกับงานนำเสนอที่ถอดรหัสแล้ว.
} finally {
    $source->dispose();
}
```

การเปิดไฟล์ที่เข้ารหัสไม่ได้ทำให้การป้องกันเดียวกันถูกนำไปใช้กับงานนำเสนอปลายทางโดยอัตโนมัติ ต้องกำหนดการป้องกันผลลัพธ์แยกต่างหากเมื่อจำเป็น

### **งานนำเสนอขนาดใหญ่และการใช้หน่วยความจำ**

งานนำเสนอขนาดใหญ่ที่มีรูปภาพความละเอียดสูง, เสียง, วิดีโอ หรือวัตถุไบนารีขนาดใหญ่สามารถใช้หน่วยความจำมาก [LoadOptions::getBlobManagementOptions()](https://reference.aspose.com/slides/th/php-java/aspose.slides/loadoptions/getblobmanagementoptions/) ให้ตัวเลือกสำหรับการจัดการ BLOB และไฟล์ชั่วคราว ดูตัวอย่างไฟล์ขนาดใหญ่ใน PHP via Java ที่ [Open Presentations](/slides/th/php-java/open-presentation/#open-large-presentations)

สำหรับไฟล์ขนาดใหญ่ ให้โหลดจากเส้นทางไฟล์เมื่อเป็นไปได้ ปิดการใช้งานงานนำเสนอแหล่งทันทีเมื่อผสานเสร็จ และหลีกเลี่ยงการบันทึกผลลัพธ์ชั่วคราวบ่อย ๆ เว้นแต่ว่าเวิร์กโฟลว์ต้องการจุดตรวจสอบ

### **ความปลอดภัยของเธรด**

อย้าโหลด, แก้ไข, บันทึก, หรือโคลนอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) ในหลายเธรด การดำเนินการเหล่านี้ไม่ได้รับการสนับสนุนสำหรับการใช้หลายเธรดใน PHP via Java หากต้องการงานผสานแบบขนาน ให้รันในกระบวนการแยกที่แต่ละกระบวนการใช้อินสแตนซ์งานนำเสนอของตนเองและปฏิบัติตาม [Aspose.Slides multithreading guidance](/slides/th/php-java/multithreading/)

## **FAQ**

**ฉันจะคงการออกแบบดั้งเดิมของงานนำเสนอแต่ละไฟล์อย่างไร?**

ใช้ [SlideCollection::addClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidecollection/addclone/) โดยไม่กำหนดมาสเตอร์หรือเลเอาต์ปลายทาง Aspose.Slides สามารถโคลนมาสเตอร์ของแหล่งโดยอัตโนมัติเมื่อสไลด์ที่นำเข้าต้องการ

**ฉันจะทำให้สไลด์ที่นำเข้าใช้ธีมของปลายทางได้อย่างไร?**

ใช้ overload ที่รับมาสเตอร์ปลายทาง ส่งมาสเตอร์จากงานนำเสนอปลายทาง ไม่ใช่จากแหล่ง Aspose.Slides จะพยายามแมปสไลด์แต่ละสไลด์ไปยังเลเอ็ตที่เหมาะสมภายใต้มาสเตอร์นั้น

**เมื่อใดควรใช้เลเอาต์ปลายทางเฉพาะแทนมาสเตอร์ปลายทาง?**

ใช้เลเอาต์เฉพาะเมื่อสไลด์ที่นำเข้าทุกสไลด์ต้องใช้เลเอาต์เดียวที่รู้จัก ใช้มาสเตอร์เมื่อให้ Aspose.Slides เลือกเลเออต่าง ๆ ของมาสเตอร์นั้นตามประเภทหรือชื่อของเลเอาต์ต้นทาง

**งานนำเสนอที่มีขนาดสไลด์ต่างกันสามารถผสานได้หรือไม่?**

ได้ แต่เนื้อหาสไลด์จะไม่ออกแบบใหม่ให้เข้ากับมิติปลายทาง ให้ปรับขนาดงานนำแหล่งก่อน เช่นใช้ [SlideSize::setSize()](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidesize/setsize/) และ [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidesizescaletype/)

**ฉันสามารถผสานไฟล์ PPT, PPTX, และ ODP ให้เป็นไฟล์เดียวได้หรือไม่?**

ได้ เปิดงานนำเสนอแหล่งแต่ละไฟล์ โคลนสไลด์ที่ต้องการเข้าสู่งานนำเสนอปลายทางแล้วบันทึกเป็นฟอร์แมตที่รองรับ อย่างไรก็ตามฟอร์แมตงานนำเสนอไม่ได้สนับสนุนคุณสมบัติเหมือนกันทั้งหมด ควรตรวจสอบเนื้อหาซับซ้อนหลังการผสานหลายฟอร์แมต ดู [Supported File Formats](/slides/th/php-java/supported-file-formats/)

**ส่วน (sections) ของแหล่งจะถูกคงโดยอัตโนมัติหรือไม่?**

ไม่ หากใช้ลูปพื้นฐานที่โคลนเฉพาะสไลด์ ต้องสร้างส่วนที่ต้องการในปลายทางและใช้ overload ของ [addClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidecollection/addclone/) ที่รับ Section เพื่อคงโครงสร้างส่วน

**โน้ตและคอมเมนต์จะถูกคงไว้หรือไม่?**

พวกมันจะถูกคัดลอกพร้อมกับสไลด์ที่โคลน สำหรับเวิร์กโฟลว์ที่พึ่งพาการจัดรูปแบบของโน้ตมาสเตอร์, ผู้เขียนคอมเมนต์, หรือการรีวิวแบบเธรด ควรตรวจสอบผลลัพธ์หลังการผสาน เนื่องจากสถานการณ์เหล่านี้เกี่ยวข้องกับโครงสร้างระดับงานนำเสนอเช่นเดียวกับระดับสไลด์

**สิ่งที่เกิดขึ้นกับไฟล์เสียง, วิดีโอ, วัตถุ OLE, และไฮเปอร์ลิงก์?**

เนื้อหาที่ฝังจะถูกนำมาพร้อมกับความสัมพันธ์ของทรัพยากรของสไลด์ที่โคลน ส่วนลิงก์ภายนอกจะคงเป็นลิงก์ภายนอก ดังนั้นไฟล์หรือ URL ปลายทางต้องยังคงพร้อมใช้งานหลังการผสาน

**ฟอนต์ที่ฝังจากทุกแหล่งจะมีในงานนำเสนอที่ผสานแล้วหรือไม่?**

ไม่ควรพึ่งพาการโคลนสไลด์อย่างเดียวสำหรับการจัดจำหน่ายฟอนต์ ตรวจสอบฟอนต์ที่ฝังในปลายทางและจัดการการฝังฟอนต์หรือการให้บริการฟอนต์ภายนอกอย่างชัดเจนเมื่อการจัดรูปแบบของข้อความสำคัญ

**ฉันจะผสานไฟล์ที่มีรหัสผ่านได้อย่างไร?**

เปิดไฟล์ด้วย [LoadOptions::setPassword()](https://reference.aspose.com/slides/th/php-java/aspose.slides/loadoptions/setpassword/) ที่ถูกต้อง แล้วโคลนสไลด์ตามปกติ การป้องกันผลลัพธ์ต้องกำหนดแยกต่างหาก

**ควรจัดการงานนำเสนอขนาดใหญ่อย่างไร?**

ใช้การจัดการ BLOB เมื่อวัตถุไบนารีใช้หน่วยความจำมาก, โหลดจากเส้นทางไฟล์สำหรับไฟล์ขนาดใหญ่, ปิดงานนำเสนอแหล่งทันทีหลังการผสาน, และบันทึกผลลัพธ์ขั้นสุดท้ายเมื่อจำเป็นเท่านั้น

**ฉันสามารถผสานสไลด์จากหลายเธรดได้หรือไม่?**

การโหลด, บันทึก, หรือโคลนงานนำเสนอในหลายเธรดไม่รองรับใน PHP via Java หากต้องการทำงานขนาน ให้ใช้กระบวนการแยกที่แต่ละกระบวนการทำงานในเธรดเดียวและแยกอินสแตนซ์งานนำเสนออย่างชัดเจนตามแนวทางการทำงานหลายเธรดของ Aspose.Slides.