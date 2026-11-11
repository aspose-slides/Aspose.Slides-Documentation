---
title: เรนเดอร์สไลด์การนำเสนอเป็นภาพ SVG ใน PHP
linktitle: สไลด์เป็น SVG
type: docs
weight: 50
url: /th/php-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint เป็น SVG
- การนำเสนอเป็น SVG
- สไลด์เป็น SVG
- PPT เป็น SVG
- PPTX เป็น SVG
- ตัวเลือกการส่งออก SVG
- SVG เชิงโต้ตอบ
- PowerPoint
- การนำเสนอ
- PHP
- Aspose.Slides
description: "ส่งออกสไลด์ PowerPoint เป็นภาพ SVG ใน PHP และควบคุมฟอนต์, ข้อความ, รูปภาพ, ID, และเหตุการณ์ด้วย Aspose.Slides."
---
## **ภาพรวม**

SVG เป็นรูปแบบภาพแบบ XML ที่ปรับขนาดได้ ซึ่งทำงานได้ดีสำหรับการเผยแพร่บนเว็บ, โปรแกรมดูสไลด์, กระบวนการทำงานเพื่อการเข้าถึง, และการประมวลผลหลังการสร้างอัตโนมัติ. Aspose.Slides ส่งออกแต่ละสไลด์เป็นไฟล์ SVG แยกส่วนและให้คุณควบคุมว่าข้อความ, ฟอนต์, รูปภาพ และองค์ประกอบ SVG ถูกเขียนอย่างไร.

ใช้ [SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/) เมื่อ SVG ที่ส่งออกต้องมีขนาดกะทัดรัด, คาดการณ์ได้ในหลายเบราว์เซอร์, หรือพร้อมสำหรับการใช้งานแบบโต้ตอบ.

## **ส่งออกสไลด์เป็น SVG**

สร้าง [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), เลือกสไลด์, แล้วเขียนลงสตรีมด้วย [Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#writeAsSvg). ตัวอย่างต่อไปนี้ส่งออกทุกสไลด์ในงานนำเสนอเป็นไฟล์ SVG แยกส่วน.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());

    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = java_values($slide->getSlideNumber());
        $outputFileName = sprintf("slide-%d.svg", $slideNumber);

        $svgStream = new Java("java.io.FileOutputStream", $outputFileName);
        $slide->writeAsSvg($svgStream);
        $svgStream->close();
    }
} finally {
    $presentation->dispose();
}
```

ชื่อไฟล์ใช้ [Slide.getSlideNumber](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getSlideNumber) แทนการใช้ดัชนีของลูป. คุณยังสามารถส่งออกรูปทรงเดี่ยวด้วย [Shape.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#writeAsSvg) เมื่อโปรแกรมดูสไลด์หรือหน้าเว็บต้องการเฉพาะรูปทรงนั้น.

## **กำหนดค่าการส่งออก SVG**

[SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/) ควบคุมการเรนเดอร์ SVG. สำหรับกรอบข้อความ, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameSize) จะรวมกรอบข้อความในพื้นที่การเรนเดอร์, และ [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameRotation) จะกำหนดว่าการหมุนกรอบจะถูกนำไปใช้หรือไม่. ตั้งค่า [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDisableFontLigatures) เป็น `true` เมื่อต้องการให้ข้อความแสดงผลโดยไม่มีลิเกม.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setDisableFontLigatures(true);
    $svgOptions->setUseFrameSize(true);
    $svgOptions->setUseFrameRotation(false);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-custom-options.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **ควบคุมข้อความและฟอนต์**

เมื่อส่งออกสไลด์เป็น SVG, คุณสามารถควบคุมว่าข้อความจะคงเป็นข้อความหรือแปลงเป็นกราฟิกเวกเตอร์, และวิธีการรวมหรืออ้างอิงฟอนต์ภายนอก. ตัวเลือกต่อไปนี้ช่วยให้คุณปรับสมดุลระหว่างความสอดคล้องของภาพ, การเลือกข้อความ, และการขึ้นอยู่กับฟอนต์ใน SVG ที่ส่งออก.

### **ทำเวกเตอร์ข้อความทั้งหมด**

ตั้งค่า [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) เป็น `true` เพื่อเขียนข้อความทั้งหมดของสไลด์เป็นกราฟิกเวกเตอร์. การทำเช่นนี้จะขจัดการพึ่งพาฟอนต์และทำให้ผลลัพธ์ภาพสอดคล้องกันมากขึ้นในหลายเบราว์เซอร์, แต่ข้อความจะไม่สามารถเลือกหรือค้นหาได้ในรูปแบบข้อความ SVG อีกต่อไป.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setVectorizeText(true);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-vectorized-text.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

### **เลือกวิธีการจัดการฟอนต์ภายนอก**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setExternalFontsHandling) ใช้ค่า [SvgExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) สำหรับฟอนต์ที่โหลดจากภายนอก. เลือก `AddLinksToFontFiles` เพื่ออ้างอิงไฟล์ฟอนต์แยกต่างหาก, `Embed` เพื่อฝังข้อมูลฟอนต์ใน SVG, หรือ `Vectorize` เพื่อเรนเดอร์เฉพาะข้อความที่ใช้ฟอนต์ภายนอกเป็นกราฟิก. ตรวจสอบสิทธิ์การใช้ฟอนต์ก่อนทำการฝังฟอนต์.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $linkedFontsOptions = new SVGOptions();
    $linkedFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::AddLinksToFontFiles);
    $linkedFontsStream = new Java("java.io.FileOutputStream", "slide-with-font-links.svg");
    try {
        $slide->writeAsSvg($linkedFontsStream, $linkedFontsOptions);
    } finally {
        $linkedFontsStream->close();
    }

    $embeddedFontsOptions = new SVGOptions();
    $embeddedFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::Embed);
    $embeddedFontsStream = new Java("java.io.FileOutputStream", "slide-with-embedded-fonts.svg");
    try {
        $slide->writeAsSvg($embeddedFontsStream, $embeddedFontsOptions);
    } finally {
        $embeddedFontsStream->close();
    }

    $vectorizedExternalFontsOptions = new SVGOptions();
    $vectorizedExternalFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::Vectorize);
    $vectorizedExternalFontsStream = new Java("java.io.FileOutputStream", "slide-with-vectorized-external-fonts.svg");
    try {
        $slide->writeAsSvg($vectorizedExternalFontsStream, $vectorizedExternalFontsOptions);
    } finally {
        $vectorizedExternalFontsStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **ลดขนาดภาพที่ฝังอยู่**

ใช้ [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setPicturesCompression) เพื่อลดความละเอียดของภาพที่ฝังอยู่, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) เพื่อละเว้นพื้นที่แหล่งภาพที่ตัด, และ [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setJpegQuality) เพื่อควบคุมคุณภาพการเข้ารหัส JPEG. การตั้งค่าเหล่านี้จะทำให้ขนาดไฟล์ลดลงแต่ครอบคลุมความคมชัดของภาพหรือข้อมูลภาพที่เก็บไว้.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setPicturesCompression(PicturesCompression::Dpi150);
    $svgOptions->setDeletePicturesCroppedAreas(true);
    $svgOptions->setJpegQuality(80);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "compressed-slide.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **ควบคุมความละเอียดการเรสเตอร์ไลซ์เมทาไฟล์**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/) กำหนดขีดจำกัดความละเอียดต่ำสุดสำหรับการแรสเตอร์ไลซ์เมทาไฟล์ระหว่างการส่งออก SVG. ใช้มันเพื่อปรับสมดุลระหว่างรายละเอียดและขนาดไฟล์เมื่อภาพ EMF หรือ WMF ถูกแรสเตอร์ไลซ์. มันไม่ได้กำหนด DPI ทั้งหมดสำหรับ SVG หรือบังคับให้ทุกวัตถุบนสไลด์กลายเป็นภาพแรสเตอร์.

ดาวน์โหลด [metafile-rasterization.pptx](metafile-rasterization.pptx) ซึ่งมีภาพ EMF ที่มีเส้นแนวทแยงมุมใกล้เคียงกัน. ตัวอย่างต่อไปนี้ส่งออกสไลด์แรกของไฟล์นั้นที่ความละเอียดการแรสเตอร์ไลซ์สามระดับผ่าน [Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/writeassvg/). การตั้งค่าอื่น ๆ ของการส่งออกยังคงเหมือนเดิมเพื่อให้ผลลัพธ์สามารถเปรียบเทียบได้.

```php
$presentation = new Presentation("metafile-rasterization.pptx");

try {
    foreach ([72, 150, 300] as $dpi) {
        $svgOptions = new SVGOptions();
        $svgOptions->setMetafileRasterizationDpi($dpi);
        $svgOptions->setPicturesCompression(PicturesCompression::Dpi330);
        $svgOptions->setJpegQuality(90);

        $outputFileName = sprintf("slide-%d.svg", $dpi);
        $svgStream = new Java("java.io.FileOutputStream", $outputFileName);

        try {
            $presentation->getSlides()->get_Item(0)->writeAsSvg($svgStream, $svgOptions);
        } finally {
            $svgStream->close();
        }
    }
} finally {
    $presentation->dispose();
}
```

ในผลลัพธ์, EMF จะกลายเป็น PNG ที่ฝังอยู่หนึ่งไฟล์ในแต่ละ SVG. การวัดต่อไปนี้เป็นของงานนำเสนอที่ให้มา; ไม่ใช่สูตรทั่วไปสำหรับการแปลง DPI เป็นขนาดพิกเซล.

| ความละเอียดการแรสเตอร์ไลซ์เมทาไฟล์ DPI | ขนาด PNG ที่ฝัง | ขนาดไฟล์ SVG (ไบต์) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

การเปรียบเทียบด้านล่างแสดงพื้นที่เดียวกันของภาพแรสเตอร์ที่ฝังที่ขนาดการแสดงผลที่ขยายเท่าเดิม. เส้นแนวทแยงมุมแสดงการเป็นพิกเซลที่มองเห็นได้ที่ 72 DPI และขอบที่เรียบกว่าในความละเอียดสูงกว่า, ในขณะที่ไฟล์ SVG จะเพิ่มขนาด. การเพิ่มค่าดังกล่าวไม่ได้หมายความว่าจะปรับปรุงรายละเอียดทุกอย่างหรือเปลี่ยนภาพที่ส่งออกทุกภาพ.

![รายละเอียดเส้นแนวทแยงมุมที่ขยายที่ 72, 150, และ 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setpicturescompression/) ควบคุมการลดความละเอียดของภาพและสามารถทำให้เห็นผลของการเปลี่ยนความละเอียดการแรสเตอร์ไลซ์เมทาไฟล์. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setjpegquality/) ควบคุมคุณภาพการเข้ารหัส JPEG, ไม่ใช่ความละเอียดการแรสเตอร์ไลซ์เมทาไฟล์.

## **กำหนด ID ที่คงที่ให้กับรูปทรงและข้อความ**

ให้คอลแบ็คการจัดรูปแบบกับ [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController) เพื่อกำหนดค่า [SvgShape.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setId) สำหรับแต่ละรูปทรง SVG. คอลแบ็คยังสามารถกำหนดค่า [SvgTSpan.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgtspan/#setId) ให้กับองค์ประกอบ `tspan` ของข้อความได้.

PhpJavaBridge ไม่สามารถเรียกคอลแบ็ค PHP จาก `writeAsSvg` เมื่อทำงานในโหมดสตรีม. ให้วางตรรกะการจัดรูปแบบในคลาสช่วยเหลือ Java ขนาดเล็ก, คอมไพล์มัน, และเพิ่มไฟล์ JAR ที่ได้ลงในคลาสพาธของ bridge. ตัวช่วยสามารถใช้ [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getOfficeInteropShapeId) ซึ่งคงที่ตลอดอายุของรูปทรง, และตัวนับที่ทำซ้ำได้สำหรับช่วงข้อความของมัน. ดู [Java implementation of `StableSvgIdController`](/slides/th/java/render-a-slide-as-an-svg-image/#assign-stable-ids-to-shapes-and-text) สำหรับโค้ดตัวช่วย.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $shapeFormattingController = new Java("com.example.slides.StableSvgIdController");

    $svgOptions = new SVGOptions();
    $svgOptions->setShapeFormattingController($shapeFormattingController);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-stable-ids.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **เพิ่มตัวจัดการเหตุการณ์ SVG**

ในคอลแบ็คการจัดรูปแบบ, เรียก [SvgShape.setEventHandler](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setEventHandler) พร้อมค่าของ [SvgEvent](https://reference.aspose.com/slides/php-java/aspose.slides/svgevent/) เพื่อเพิ่มตัวจัดการเหตุการณ์ JavaScript ให้กับรูปทรงที่ส่งออก. กำหนดคอลแบ็คด้วย [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController) และกำหนดฟังก์ชัน JavaScript ในหน้าเว็บหรือเอกสาร SVG ที่เป็นโฮสต์ผลลัพธ์.

เช่นเดียวกับ ID ที่คงที่, ให้ดำเนินการคอลแบ็คในตัวช่วย Java เมื่อ PhpJavaBridge ใช้โหมดสตรีม. [Java implementation of `SvgEventController`](/slides/th/java/render-a-slide-as-an-svg-image/#add-svg-event-handlers) กำหนด ID และตัวจัดการ `OnClick` ให้กับรูปทรงที่ชื่อ `ActionButton`. คอมไพล์ตัวช่วยนั้น, เพิ่มลงในคลาสพาธของ bridge เป็น `com.example.slides.SvgEventController`, และใช้จาก PHP ตามต่อไปนี้:

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $shapeFormattingController = new Java("com.example.slides.SvgEventController");

    $svgOptions = new SVGOptions();
    $svgOptions->setShapeFormattingController($shapeFormattingController);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "interactive-slide.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

หน้าโฮสต์สามารถกำหนดฟังก์ชัน JavaScript ที่อ้างอิงโดยตัวจัดการได้. การกำหนด ID และตัวจัดการเหตุการณ์ทำให้โปรแกรมดูสไลด์, การปรับปรุงการเข้าถึง, และกระบวนการทำงาน SVG แบบโต้ตอบอื่น ๆ เป็นไปได้.

## **คำถามที่พบบ่อย**

**เมื่อใดควรใช้ [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) แทน [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/)?**

ใช้ [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) เมื่อข้อความทั้งหมดต้องเป็นอิสระจากฟอนต์. ใช้ [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) เมื่อเพียงข้อความที่ใช้ฟอนต์ภายนอกเท่านั้นที่ควรแปลงเป็นกราฟิก.

**วิธีที่ดีที่สุดในการทำให้ SVG มีขนาดเล็กลงคืออะไร?**

เริ่มต้นด้วยการบีบอัดภาพที่ฝังอยู่, ลบพื้นที่ภาพที่ถูกตัด, และเลือกไฟล์ฟอนต์แบบลิงก์เมื่อสภาพแวดล้อมเป้าหมายสามารถให้บริการไฟล์เหล่านั้นได้. ทดสอบผลลัพธ์เนื่องจากความละเอียดภาพที่ต่ำลง, คุณภาพ JPEG ที่ต่ำลง, และข้อความที่ทำเวกเตอร์แต่ละอย่างมีการแลกเปลี่ยนระหว่างคุณภาพและขนาดที่แตกต่างกัน.

**ฉันสามารถแก้ไของค์ประกอบ SVG ที่ส่งออกหลังจากการส่งออกได้หรือไม่?**

ได้. กำหนด ID ผ่านคอลแบ็คการจัดรูปแบบ, จากนั้นเลือกองค์ประกอบ SVG ที่ตรงกันในเครื่องมือหลังการประมวลผลหรือสคริปต์ของเบราว์เซอร์ของคุณ.