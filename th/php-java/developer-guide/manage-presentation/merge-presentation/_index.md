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
description: "เรียนรู้วิธีผสานการนำเสนอ PowerPoint และ OpenDocument ใน PHP โดยการโคลนสไลด์, ควบคุมมาสเตอร์และเลย์เอาต์, ปรับขนาดเนื้อหาสไลด์, รักษาเซคชัน, และจัดการไฟล์ที่มีการป้องกันหรือขนาดใหญ่."
---
## **ภาพรวม**

Aspose.Slides for PHP via Java ผสานการนำเสนอโดยการโคลนสไลด์จาก [การนำเสนอ](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) หนึ่งไปยังอีกหนึ่งสไลด์ การดำเนินการหลักคือ [SlideCollection::addClone()](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidecollection/addclone/), ซึ่งสามารถรักษาการจัดรูปแบบของสไลด์ต้นฉบับหรือแนบสไลด์ที่โคลนไปยังมาสเตอร์หรือเลย์เอาต์ในการนำเสนอปลายทางได้

บทความนี้ครอบคลุมกระบวนการผสานที่พบบ่อยที่สุด:

- ผสานสไลด์ทั้งหมดโดยคงการจัดรูปแบบต้นฉบับ;
- ผสานสไลด์ที่เลือก;
- ใช้มาสเตอร์จากการนำเสนอปลายทาง;
- ใช้เลย์เอาต์เฉพาะจากการนำเสนอปลายทาง;
- ปรับขนาดสไลด์ต่างๆ ให้เท่ากันก่อนผสาน;
- เพิ่มสไลด์ที่โคลนเข้าไปในเซคชัน;
- ผสานหลายการนำเสนอในเวิร์กโฟลว์จากต้นจนจบ;
- จัดการมาสเตอร์, ทรัพยากร, โน้ต, คอมเมนต์, สื่อ, ฟอนต์, รหัสผ่าน, ไฟล์ขนาดใหญ่, และข้อกังวลเรื่องการทำงานหลายเธรด

## **การโคลนสไลด์มีผลต่อมาสเตอร์และเลย์เอาต์อย่างไร**

สไลด์สืบทอดลักษณะส่วนใหญ่จากเลย์เอาต์และมาสเตอร์ของมัน ด้วยเหตุนี้รูปแบบการโคลนที่คุณเลือกจะกำหนดว่าสต่างถูกผสานเข้าไปในการนำเสนอปลายทางอย่างไร

ใช้ [SlideCollection::addClone()](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidecollection/addclone/) หนึ่งในวิธีต่อไปนี้:

- `addClone(sourceSlide)` — รักษาเลย์เอาต์และการจัดรูปแบบของสไลด์ต้นฉบับ เมื่อจำเป็นมาสเตอร์ต้นฉบับสามารถถูกโคลนเข้าไปในการนำเสนอปลายทางโดยอัตโนมัติ Aspose.Slides จะติดตามมาสเตอร์ที่โคลนอัตโนมัติเพื่อให้สไลด์ที่ซ้ำใช้มาสเตอร์เดียวกันไม่ต้องโคลนหลายครั้ง
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — แนบสไลด์ที่โคลนไปยัง [MasterSlide](https://reference.aspose.com/slides/th/php-java/aspose.slides/masterslide/) ปลายทางที่ระบุ Aspose.Slides จะค้นหาเลย์เอาต์ที่ตรงกันภายใต้มาสเตอร์นั้นโดยประเภทหรือชื่อของเลย์เอาต์
- `addClone(sourceSlide, destinationLayout)` — แนบสไลด์ที่โคลนโดยตรงไปยัง [LayoutSlide](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutslide/) ปลายทางที่ระบุ

มาสเตอร์หรือเลย์เอาต์ที่ส่งเข้าไปใน overload ของ `addClone` ต้องเป็นของ **การนำเสนอปลายทาง**, ไม่ใช่ของการนำเสนอต้นฉบับ

## **ผสานการนำเสนอทั้งหมดและรักษาการจัดรูปแบบต้นฉบับ**

การผสานที่ง่ายที่สุดคือคัดลอกทุกสไลด์จากการนำเสนอต้นฉบับไปยังการนำเสนอปลายทาง นี่เป็นตัวเลือกที่เหมาะสมเมื่อสไลด์ที่นำเข้า ควรคงธีม, มาสเตอร์, และความสัมพันธ์ของเลย์เอต์เดิม

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

การนำเสนอที่ได้อาจมีหลายมาสเตอร์เมื่อทั้งต้นฉบับและปลายทางใช้การออกแบบที่แตกต่างกัน ซึ่งคาดหวังได้เมื่อการจัดรูปแบบต้นฉบับถูกเก็บไว้โดยเจตนา

## **ผสานสไลด์ที่เลือก**

คุณไม่จำเป็นต้องโคลนทุกสไลด์ ตัวอย่างต่อไปนี้นำเข้าเฉพาะดัชนีสไลด์ที่เลือกจากการนำเสนอต้นฉบับ

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

ตรวจสอบดัชนีสไลด์ก่อนทำการโคลนเมื่อมาจากการป้อนข้อมูลของผู้ใช้หรือการกำหนดค่าภายนอก

## **ผสานสไลด์โดยใช้มาสเตอร์ปลายทาง**

ใช้ overload [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidecollection/addclone/) เมื่อสไลด์ที่นำเข้าควรปฏิบัติตามมาสเตอร์ที่มีอยู่แล้วในการนำเสนอปลายทาง

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

Aspose.Slides จะเลือกเลย์เอาต์ที่เหมาะสมภายใต้มาสเตอร์ที่ระบุโดยการจับคู่ประเภทหรือชื่อของเลย์เอาต์ต้นฉบับ หากไม่มีเลย์เอาต์ที่เหมาะสมและ `allowCloneMissingLayout` เป็น `true` เลย์เอาต์ต้นฉบับจะถูกโคลนเพื่อให้สไลด์สามารถเพิ่มได้ หากเป็น `false` จะเกิดข้อผิดพลาด [PptxEditException](https://reference.aspose.com/slides/th/php-java/aspose.slides/pptxeditexception/)

ใช้ `false` เมื่อคุณต้องการให้การผสานล้มเหลวแทนที่จะเพิ่มเลย์เอาต์ใหม่ลงในมาสเตอร์ปลายทาง

## **ผสานสไลด์โดยใช้เลย์เอาต์ปลายทางเฉพาะ**

ใช้ overload [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidecollection/addclone/) เมื่อคุณทราบอย่างชัดเจนว่าเลย์เอาต์ปลายทางใดที่สไลด์ที่นำเข้าควรใช้

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

การใช้เลย์เอาต์ปลายทางจะเปลี่ยนความสัมพันธ์ของเลย์เอาต์ที่สืบทอด; มันไม่ได้ออกแบบเนื้อหาสไลด์ต้นฉบับใหม่ หากเลย์เอาต์ของต้นฉบับและปลายทางมีโครงสร้าง placeholder ที่แตกต่างกัน ให้ตรวจสอบผลลัพธ์เพื่อยืนยันว่าการจัดรูปแบบและพฤติกรรมของ placeholder เหมาะสม

## **ผสานการนำเสนอที่มีขนาดสไลด์ต่างกัน**

การนำเสนอที่มีมิติสไลด์ต่างกันสามารถผสานได้ แต่การโคลนสไลด์ไปยังการนำเสนอที่มีขนาดสไลด์อื่นไม่ทำการออกแบบเนื้อหาใหม่อัตโนมัติเพื่อให้เข้ากับผ้าใบใหม่ รูปร่างอาจปรากฏเป็นการย้าย, ยืดขยายอย่างไม่คาดคิด, หรืออยู่นอกพื้นที่สไลด์ที่มองเห็นได้

แนวทางปฏิบัติที่เป็นประโยชน์คือการปรับขนาดการนำเสนอต้นฉบับก่อนทำการโคลน วิธี [SlideSize::setSize()](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidesize/setsize/) สามารถปรับสเกลเนื้อหาที่มีอยู่ขณะเปลี่ยนขนาดสไลด์ได้ [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidesizescaletype/) จะปรับสเกลเนื้อหาให้พอดีกับขนาดที่ต้องการ

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

การปรับขนาดจะเปลี่ยนวัตถุการนำเสนอต้นฉบับในหน่วยความจำ หากคุณต้องการให้การนำเสนอต้นฉบับเดิมไม่เปลี่ยนแปลงสำหรับการทำงานอื่น ให้เปิดอินสแตนซ์แยกสำหรับการผสาน

## **ผสานสไลด์เข้าสู่เซคชันของการนำเสนอ**

ลูปการโคลนสไลด์พื้นฐานไม่สร้างลำดับชั้นเซคชันของการนำเสนอต้นฉบับ หากเซคชันมีความสำคัญในผลลัพธ์ ให้สร้างหรือเลือกเซคชันในการนำเสนอปลายทางและโคลนสไลด์เข้าไปในเซคชันนั้นโดยใช้ [addClone(Slide, Section)](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidecollection/addclone/)

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

สไลด์ที่โคลนจะถูกเพิ่มต่อท้ายเซคชันปลายทางที่ระบุ เพื่อคงหลายเซคชันต้นฉบับ ให้สร้างเซคชันเหล่านั้นในปลายทางและแมพสไลด์ต้นฉบับแต่ละสไลด์ไปยังเซคชันปลายทางที่สอดคล้องกัน

## **ผสานหลายการนำเสนออย่างปลอดภัย**

ตัวอย่างการทำงานจากต้นจนจบต่อไปนี้ใช้การนำเสนอแรกเป็นปลายทาง, ปรับขนาดสไลด์ของแต่ละแหล่งเพิ่ม, เปิดแต่ละแหล่งเฉพาะขณะคัดลอก, และบันทึกไฟล์สุดท้ายเมื่อเสร็จ

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

นี่เป็นพื้นฐานที่มีประโยชน์สำหรับการคงการจัดรูปแบบต้นฉบับของสไลด์ที่นำเข้า หากผลลัพธ์ของคุณต้องใช้ธีมปลายทางเดียว ให้แทนที่การเรียก `addClone($slide)` อย่างง่ายด้วย overload มาสเตอร์หรือเลย์เอาต์ปลายทางที่เหมาะสมตามที่แสดงข้างต้น

## **ข้อพิจารณาปฏิบัติ**

### **มาสเตอร์, เลย์เอาต์, และความแม่นยำของการจัดรูปแบบ**

การโคลนสไลด์โดยค่าเริ่มต้นสามารถนำมาสเตอร์ต้นฉบับที่จำเป็นเข้าสู่การนำเสนอปลายทางโดยอัตโนมัติ Aspose.Slides จะเก็บรีจิสทรีภายในสำหรับมาสเตอร์ที่โคลนอัตโนมเพื่อหลีกเลี่ยงการโคลนมาสเตอร์เดียวกันหลายครั้ง มาสเตอร์ที่โคลนด้วยตนเองจะไม่ได้รับการติดตามโดยรีจิสทรีนั้น ดังนั้นหลีกเลี่ยงการโคลนมาสเตอร์ล่วงหน้าเว้นแต่คุณต้องการควบคุมโครงสร้างมาสเตอร์อย่างชัดเจน

อย่าถือว่ามาสเตอร์หรือเลย์เอาต์สองตัวที่มีชื่อเดียวกันเทียบเท่าในแง่ภาพ หากเทมเพลตองค์กรต้องควบคุมรูปลักษณ์สุดท้าย ให้เลือกมาสเตอร์หรือเลย์เอาต์ปลายทางอย่างชัดเจนและตรวจสอบผลลัพธ์หลังการผสาน

### **โน้ตและคอมเมนต์**

โน้ตของผู้พูดและคอมเมนต์ของสไลด์เชื่อมโยงกับเนื้อหาสไลด์และจะถูกคัดลอกเมื่อตัวสไลด์ถูกโคลน Aspose.Slides ยังให้ API เฉพาะสำหรับ [presentation notes](https://docs.aspose.com/slides/th/php-java/presentation-notes/) และ [presentation comments](https://docs.aspose.com/slides/th/php-java/presentation-comments/)

หากการจัดรูปแบบของหน้าโน้ตสำคัญ ให้ตรวจสอบการนำเสนอที่ผสานแล้วเนื่องจากมาสเตอร์โน้ตเป็นวัตถุระดับการนำเสนอและอาจแตกต่างระหว่างไฟล์ต้นฉบับ สำหรับเวิร์กโฟลว์การตรวจสอบ ให้ตรวจสอบผู้เขียนคอมเมนต์และคอมเมนต์แบบเธรดหลังการรวมไฟล์จากผู้เขียนหรือเทมเพลตต่างกัน

### **รูปภาพ, เสียง, วีดีโอ, วัตถุ OLE, และลิงก์ภายนอก**

สไลด์สามารถอ้างอิงทรัพยากรระดับการนำเสนอเช่นรูปภาพ, เสียงฝัง, วิดีโอฝัง, และข้อมูล OLE ได้ ให้โคลนสไลด์เองแทนการคัดลอรูปแบบที่มองเห็นได้เท่านั้นเพื่อให้ Aspose.Slides สามารถรักษาความสัมพันธ์ของสไลด์กับทรัพยากรเหล่านั้นได้

ทรัพยากรที่ฝังและที่เชื่อมโยงควรจัดการแตกต่างกัน เสียง, วีดีโอ, วัตถุ OLE หรือไฮเปอร์ลิงก์ที่เชื่อมโยงจะยังคงขึ้นอยู่กับเป้าหมายภายนอก; การโคลนสไลด์ไม่ได้ทำให้ลิงก์ภายนอกกลายเป็นเนื้อหาฝัง ทดสอบเส้นทางและ URL ของทรัพยากรที่เชื่อมโยงในสภาพแวดล้อมที่การนำเสนอที่ผสานจะถูกเปิด

Aspose.Slides ติดตามมาสเตอร์ที่โคลนอัตโนมัติอย่างชัดเจน แต่ไม่ควรถือว่าเป็นการรับประกันทั่วไปว่าทรัพยากรไบนารีที่เหมือนกันจากการนำเสนอแหล่งที่ไม่เกี่ยวข้องจะถูกตัดซ้ำเสมอ หากขนาดไฟล์ผลลัพธ์สำคัญ ให้ตรวจสอบแพ็กเกจที่ผสานและวัดผลลัพธ์แทนการพึ่งพาการตัดซ้ำโดยปริยาย

### **ฟอนต์ฝังและความพร้อมใช้งานของฟอนต์**

ฟอนต์จะถูกจัดการระดับการนำเสนอ หากการพิมพ์ต้องคงที่ข้ามเครื่อง อย่าเชื่อว่าการโคลนสไลด์อย่างเดียวทำให้ฟอนต์ที่จำเป็นทั้งหมดพร้อมใช้งานในสภาพแวดล้อมปลายทาง คุณสามารถตรวจสอบฟอนต์ที่ฝังด้วย [FontsManager::getEmbeddedFonts()](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontsmanager/getembeddedfonts/) และจัดการการฝังอย่างชัดเจนตามที่อธิบายใน [Embed Fonts in Presentations](https://docs.aspose.com/slides/th/php-java/embedded-font/)

นอกจากนี้ยังต้องตรวจสอบว่าคุณได้รับอนุญาตให้ฝังฟอนต์ที่ใช้ในไฟล์ต้นฉบับหรือไม่ ใบอนุญาตฟอนต์อาจจำกัดการฝัง

### **การนำเสนอที่มีรหัสผ่าน**

แหล่งที่มีรหัสผ่านต้องเปิดสำเร็จก่อนที่สไลด์จะสามารถโคลนได้ ให้ใส่รหัสผ่านผ่าน [LoadOptions::setPassword()](https://reference.aspose.com/slides/th/php-java/aspose.slides/loadoptions/setpassword/)

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("YOUR_PASSWORD");

$source = new Presentation("protected.pptx", $loadOptions);
try {
    // ทำงานกับการนำเสนอที่ถอดรหัสแล้ว.
} finally {
    $source->dispose();
}
```

การเปิดแหล่งที่เข้ารหัสไม่ได้ทำให้การป้องกันเดียวกันถูกนำไปใช้กับการนำเสนอปลายทางโดยอัตโนมัติ ให้กำหนดค่าการป้องกันผลลัพธ์แยกต่างหากเมื่อจำเป็น

### **การนำเสนอขนาดใหญ่และการใช้หน่วยความจำ**

การนำเสนอขนาดใหญ่ที่มีรูปภาพความละเอียดสูง, เสียง, วีดีโอ หรือวัตถุไบนารีขนาดใหญ่อื่นๆ สามารถใช้หน่วยความจำได้มาก [LoadOptions::getBlobManagementOptions()](https://reference.aspose.com/slides/th/php-java/aspose.slides/loadoptions/getblobmanagementoptions/) ให้การควบคุมการจัดการ BLOB และการใช้ไฟล์ชั่วคราว ดูตัวอย่างไฟล์ขนาดใหญ่ของ PHP via Java ที่ [Open Presentations](https://docs.aspose.com/slides/th/php-java/open-presentation/#open-large-presentations)

สำหรับไฟล์ใหญ่ ควรโหลดจากเส้นทางไฟล์เมื่อตำแหน่งเป็นไปได้ ปล่อยการนำเสนอแหล่งแต่ละตัวให้เร็วที่สุดหลังจากที่ผสานเสร็จ และหลีกเลี่ยงการบันทึกผลลัพธ์กลางหลายครั้งหากเวิร์กโฟลว์ไม่จำเป็นต้องมีจุดตรวจ

### **ความปลอดภัยของเธรด**

ไม่ควรโหลด, แก้ไข, บันทึก หรือโคลนอินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) ในหลายเธรด การดำเนินการเหล่านี้ไม่รองรับการใช้งานหลายเธรดใน PHP via Java หากต้องการงานผสานแบบขนาน ให้รันในกระบวนการที่แยกจากกันโดยแต่ละกระบวนการใช้อินสแตนซ์การนำเสนอของตนเองและปฏิบัติตาม [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/th/php-java/multithreading/)

## **คำถามที่พบบ่อย**

**ฉันจะคงการออกแบบเดิมของการนำเสนอแต่ละไฟล์อย่างไร?**

ใช้ [`addClone(sourceSlide)`](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidecollection/addclone/) โดยไม่ระบุมาสเตอร์หรือเลย์เอาต์ปลายทาง Aspose.Slides สามารถโคลนมาสเตอร์ต้นฉบับโดยอัตโนมัติเมื่อต้องการโดยสไลด์ที่นำเข้า

**ฉันจะทำให้สไลด์ที่นำเข้าใช้ธีมปลายทางอย่างไร?**

ใช้ overload ที่รับมาสเตอร์ปลายทาง ส่งมาสเตอร์จากการนำเสนอปลายทาง ไม่ได้จากต้นฉบับ Aspose.Slides จะพยายามแมพสไลด์ต้นฉบับแต่ละสไลด์ไปยังเลย์เอาต์ที่เหมาะสมภายใต้มาสเตอร์นั้น

**ควรใช้เลย์เอาต์ปลายทางเฉพาะแทนมาสเตอร์ปลายทางเมื่อใด?**

ใช้เลย์เอาต์เฉพาะเมื่อสไลด์ที่นำเข้าทุกสไลด์ควรใช้เลย์เอาต์ที่รู้จักหนึ่งเลย์เอาต์ ใช้มาสเตอร์เมื่อคุณต้องการให้ Aspose.Slides เลือกจากเลย์เอาต์ของมาสเตอร์นั้นตามประเภทหรือชื่อของเลย์เอาต์ต้นฉบับ

**สามารถผสานการนำเสนอที่มีขนาดสไลด์ต่างกันได้หรือไม่?**

ได้ แต่เนื้อหาสไลด์จะไม่ถูกออกแบบใหม่โดยอัตโนมัติสำหรับมิติปลายทาง ให้ปรับขนาดการนำเสนอต้นฉบับก่อนเมื่อคุณต้องการตำแหน่งที่คาดเดาได้ เช่นใช้ [SlideSize::setSize()](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidesize/setsize/) และ [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidesizescaletype/)

**ผมสามารถผสานไฟล์ PPT, PPTX, และ ODP เป็นไฟล์เดียวได้หรือไม่?**

ได้ โหลดแต่ละไฟล์ต้นฉบับ, โคลนสไลด์ที่ต้องการลงในปลายทางหนึ่งและบันทึกปลายทางในรูปแบบที่สนับสนุน เนื่องจากฟอร์แมตการนำเสนอไม่รองรับชุดฟีเจอร์เดียวกันทั้งหมด ให้ตรวจสอบเนื้อหาที่ซับซ้อนหลังการผสานข้ามฟอร์แมต ดู [Supported File Formats](https://docs.aspose.com/slides/th/php-java/supported-file-formats/)

**เซคชันต้นฉบับจะถูกเก็บรักษาโดยอัตโนมัติหรือไม่?**

ไม่ใช่ด้วยลูปพื้นฐานที่เพียงโคลนสไลด์ ให้สร้างเซคชันในปลายทางและใช้ overload ของ [addClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidecollection/addclone/) เมื่อโครงสร้างเซคชันต้องการการรักษา

**โน้ตของผู้พูดและคอมเมนต์จะถูกเก็บรักษาไว้หรือไม่?**

พวกมันถูกคัดลอกพร้อมสไลด์ที่โคลน สำหรับเวิร์กโฟลว์ที่พึ่งพาการจัดรูปแบบของโน้ตมาสเตอร์, ผู้เขียนคอมเมนต์, หรือข้อมูลการตรวจสอบแบบเธรด, โปรดตรวจสอบผลลัพธ์ที่ผสานเนื่องจากสถานการณ์เหล่านั้นเกี่ยวข้องกับโครงสร้างระดับการนำเสนอเช่นกันกับเนื้อหาระดับสไลด์

**เกิดอะไรขึ้นกับเสียง, วีดีโอ, วัตถุ OLE, และไฮเปอร์ลิงก์?**

เนื้อหาฝังจะถูกร่วมเป็นส่วนหนึ่งของความสัมพันธ์ของทรัพยากรสไลด์ที่โคลน ลิงก์ภายนอกยังคงเป็นภายนอก ดังนั้นไฟล์หรือ URL เป้าหมายต้องยังคงเข้าถึงได้หลังการผสาน

**ฟอนต์ที่ฝังจากทุกแหล่งรับประกันว่าจะพร้อมใช้งานในการนำเสนอที่ผสานหรือไม่?**

อย่าอ้างอิงการโคลนสไลด์อย่างเดียวสำหรับการจัดการฟอนต์ ตรวจสอบฟอนต์ที่ฝังในปลายทางและจัดการการฝังหรือความพร้อมใช้งานของฟอนต์ภายนอกอย่างชัดเจนเมื่อการพิมพ์สำคัญ

**วิธีผสานไฟล์ที่มีรหัสผ่าน?**

เปิดไฟล์ด้วย [LoadOptions::setPassword()](https://reference.aspose.com/slides/th/php-java/aspose.slides/loadoptions/setpassword/) แล้วโคลนสไลด์ตามปกติ การป้องกันผลลัพธ์ตั้งค่าแยกต่างหาก

**ควรจัดการการนำเสนอขนาดใหญ่อย่างไร?**

ใช้การจัดการ BLOB เมื่อวัตถุไบนารีขนาดใหญ่ครอบคลุมหน่วยความจำ, โหลดจากเส้นทางไฟล์สำหรับไฟล์ขนาดใหญ่, ปล่อยการนำเสนอแหล่งโดยเร็ว, และบันทึกผลลัพธ์สุดท้ายเมื่อจำเป็น

**สามารถผสานสไลด์จากหลายเธรดได้หรือไม่?**

การโหลด, บันทึก, หรือโคลนการนำเสนอในหลายเธรดไม่รองรับใน PHP via Java สำหรับงานที่ต้องทำขนาน ให้ใช้กระบวนการแยกแบบ single‑threaded และแยกอินสแตนซ์การนำเสนอในแต่ละกระบวนการ