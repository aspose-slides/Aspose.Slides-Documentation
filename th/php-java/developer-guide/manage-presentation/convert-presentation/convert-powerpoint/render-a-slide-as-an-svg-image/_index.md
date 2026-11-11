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
description: "ส่งออกสไลด์ PowerPoint เป็นภาพ SVG ใน PHP และควบคุมแบบอักษร, ข้อความ, ภาพ, ID, และเหตุการณ์ด้วย Aspose.Slides."
---
## **ภาพรวม**

SVG คือรูปแบบภาพที่ขยายได้และอิงตาม XML ซึ่งทำงานได้ดีสำหรับการเผยแพร่บนเว็บ, ตัวดูสไลด์, กระบวนการทำให้เข้าถึงได้, และการประมวลผลหลังการส่งออกอัตโนมัติ. Aspose.Slides ส่งออกแต่ละสไลด์เป็นไฟล์ SVG แยกกันและให้คุณควบคุมว่าข้อความ, แบบอักษร, รูปภาพ, และองค์ประกอบ SVG ถูกเขียนอย่างไร.

ใช้ [SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/) เมื่อ SVG ที่ส่งออกต้องกะทัดรัด, คาดเดาได้ในหลายเบราว์เซอร์, หรือพร้อมสำหรับการใช้งานเชิงโต้ตอบ.

## **ส่งออกสไลด์เป็น SVG**

สร้าง [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), เลือกสไลด์, และเขียนลงสตรีมด้วย [Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#writeAsSvg). ตัวอย่างต่อไปนี้ส่งออกสไลด์ทุกสไลด์ในงานนำเสนอเป็นไฟล์ SVG แยกแต่ละไฟล์.

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

ชื่อไฟล์ใช้ [Slide.getSlideNumber](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getSlideNumber) แทนการใช้ดัชนีของลูป. คุณยังสามารถส่งออกรูปร่างเดี่ยวด้วย [Shape.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#writeAsSvg) เมื่อโปรแกรมดูสไลด์หรือหน้าเว็บต้องการเฉพาะรูปร่างนั้นเท่านั้น.

## **กำหนดการส่งออก SVG**

[SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/) ควบคุมการเรนเดอร์ SVG. สำหรับกรอบข้อความ, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameSize) จะรวมกรอบข้อความในพื้นที่เรนเดอร์, และ [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameRotation) กำหนดว่าจะใช้การหมุนกรอบหรือไม่. ตั้งค่า [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDisableFontLigatures) เป็น `true` เมื่อข้อความต้องเรนเดอร์โดยไม่มีลิกเจอร์.

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

## **ควบคุมการตัดส่วนปลายเส้นที่หัวลูกศร**

SVG 1.1 ไม่มีการตั้งค่า marker inset เพื่อระบุตำแหน่งที่เส้นควรหยุดใต้หัวลูกศร. โดยค่าเริ่มต้น, Aspose.Slides จะสั้นเส้นที่ส่งออกเพื่อให้เส้นขอบไม่ยื่นออกมาผ่าน marker. เรียก [SVGOptions::setDisableLineEndCropping](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setdisablelineendcropping/) ด้วยค่า `true` เพื่อวาดเส้นจนถึงตำแหน่งปลายเดิมของเส้น. การตั้งค่านี้ส่งผลต่อการส่งออก SVG เท่านั้น. เส้นยังคงตำแหน่งและความยาวบนสไลด์.

ตัวอย่างวาดหัวลูกศรรูปสามเหลี่ยมและเพชรบนเส้นที่กว้าง 2 และ 10 จุด. มันส่งออกสไลด์เดียวกันสองครั้ง, โดยเปลี่ยนเฉพาะตัวเลือกการตัด.

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\SVGOptions;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $y = 40;

    foreach ([LineArrowheadStyle::Triangle, LineArrowheadStyle::Diamond] as $style) {
        foreach ([2, 10] as $width) {
            $line = $slide->getShapes()->addAutoShape(ShapeType::Line, 40, $y, 200, 0);
            $format = $line->getLineFormat();
            $format->getFillFormat()->setFillType(FillType::Solid);
            $color = new Java("java.awt.Color", 0, 0, 139);
            $format->getFillFormat()->getSolidFillColor()->setColor($color);
            $format->setWidth($width);
            $format->setEndArrowheadStyle($style);
            $y += 50;
        }
    }

    $options = new SVGOptions();
    $options->setDisableLineEndCropping(false);
    $cropped = new Java("java.io.FileOutputStream", "cropped.svg");
    try {
        $slide->writeAsSvg($cropped, $options);
    } finally {
        $cropped->close();
    }

    $options->setDisableLineEndCropping(true);
    $uncropped = new Java("java.io.FileOutputStream", "uncropped.svg");
    try {
        $slide->writeAsSvg($uncropped, $options);
    } finally {
        $uncropped->close();
    }
} finally {
    $presentation->dispose();
}
```

การเปรียบเทียบแสดงหัวลูกศรรูปสามเหลี่ยมบนเส้น 10 จุด. เมื่อเปิดการตัด, ปลายคม. เมื่อปิดการตัด, เส้นขอบยื่นออกมาผ่านด้านเอียงของ marker และทิ้งปลายแบน.

![สามเหลี่ยมขนาด 10 จุดที่ขยายใหญ่พร้อมปลายคมเมื่อเปิดการตัดและปลายแบนเมื่อปิดการตัด](line-end-cropping.png)

ในเส้นอื่นจากตัวอย่าง, เส้นขอบที่ยื่นน้อยลงบนสามเหลี่ยม 2 จุด. เพชรที่เติมเต็มปิดปลายของเส้นขอบทั้งสองความกว้าง.

## **ควบคุมข้อความและแบบอักษร**

เมื่อส่งออกสไลด์เป็น SVG, คุณสามารถควบคุมว่าข้อความจะคงเป็นข้อความหรือแปลงเป็นกราฟิกเวกเตอร์, และวิธีการรวมหรืออ้างอิงแบบอักษรภายนอก. ตัวเลือกต่อไปนี้ช่วยให้คุณสมดุลระหว่างความสอดคล้องของภาพ, การเลือกข้อความ, และการพึ่งพาแบบอักษรใน SVG ที่ส่งออก.

### **เวกเตอร์ข้อความทั้งหมด**

ตั้งค่า [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) เป็น `true` เพื่อเขียนข้อความทั้งหมดของสไลด์เป็นกราฟิกเวกเตอร์. สิ่งนี้ขจัดการพึ่งพาแบบอักษรและทำให้ผลลัพธ์ภาพสอดคล้องกันมากขึ้นในหลายเบราว์เซอร์, แต่ข้อความจะไม่สามารถเลือกหรือค้นหาได้ในรูปแบบข้อความ SVG อีกต่อไป.

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

### **เลือกวิธีจัดการแบบอักษรภายนอก**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setExternalFontsHandling) ใช้ค่า [SvgExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) สำหรับแบบอักษรที่โหลดจากภายนอก. เลือก `AddLinksToFontFiles` เพื่ออ้างอิงไฟล์แบบอักษรแยกต่างหาก, `Embed` เพื่อฝังข้อมูลแบบอักษรใน SVG, หรือ `Vectorize` เพื่อเรนเดอร์เฉพาะข้อความที่ใช้แบบอักษรภายนอกเป็นกราฟิก. ตรวจสอบการอนุญาตใช้แบบอักษรก่อนทำการฝัง.

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

## **ลดขนาดรูปภาพที่ฝัง**

ใช้ [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setPicturesCompression) เพื่อลดความละเอียดของรูปภาพที่ฝัง, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) เพื่อตัดส่วนที่ถูกตัดของแหล่งรูป, และ [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setJpegQuality) เพื่อควบคุมคุณภาพการเข้ารหัส JPEG. การตั้งค่าเหล่านี้จะลดขนาดไฟล์โดยแลกกับความละเอียดของรูปภาพหรือข้อมูลรูปภาพที่คงอยู่.

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

## **ควบคุมความละเอียดการเรสเตอร์ไลเซชันของ Metafile**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/) กำหนดขีดจำกัดความละเอียดล่างสุดสำหรับการแรสเตอร์ไลซ์ metafile ระหว่างการส่งออก SVG. ใช้มันเพื่อปรับสมดุลระหว่างรายละเอียดและขนาดไฟล์เมื่อภาพ EMF หรือ WMF ถูกแรสเตอร์ไลซ์. มันไม่ได้กำหนด DPI ทั้งหมดสำหรับ SVG หรือบังคับให้ทุกวัตถุบนสไลด์กลายเป็นภาพแรสเตอร์.

ดาวน์โหลด [metafile-rasterization.pptx](metafile-rasterization.pptx), ซึ่งมีภาพ EMF ที่มีเส้นทแยงมุมใกล้กัน. ตัวอย่างต่อไปนี้ส่งออกสไลด์แรกของไฟล์นั้นที่ความละเอียดการแรสเตอร์ไลซ์สามระดับผ่าน [Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/writeassvg/). การตั้งค่าอื่น ๆ ของการส่งออกทั้งหมดยังคงเท่าเดิมเพื่อให้สามารถเปรียบเทียบผลลัพธ์ได้.

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

ในผลลัพธ์, EMF ถูกแปลงเป็น PNG ฝังหนึ่งไฟล์ในแต่ละ SVG. การวัดต่อไปนี้เป็นของงานนำเสนอที่ให้มา; ไม่ใช่สูตรทั่วไปสำหรับการแปลง DPI เป็นขนาดพิกเซล.

| ความละเอียดการแรสเตอร์ไลซ์ Metafile DPI | ขนาด PNG ที่ฝัง | ขนาดไฟล์ SVG (ไบต์) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

การเปรียบเทียบด้านล่างแสดงพื้นที่เดียวกันของภาพแรสเตอร์ที่ฝังในขนาดการแสดงผลที่ขยายเท่าเดิม. เส้นทแยงมุมแสดงการเป็นพิกเซลที่มองเห็นได้ที่ 72 DPI และขอบที่เรียบขึ้นที่ความละเอียดสูงกว่า, ขณะที่ไฟล์ SVG เพิ่มขนาด. การเพิ่มค่าดังกล่าวไม่ได้รับประกันว่าจะปรับปรุงรายละเอียดทุกอย่างหรือเปลี่ยนแปลงภาพที่ส่งออกทั้งหมด.

![รายละเอียดเส้นทแยงมุมที่ขยายใหญ่ที่ 72, 150, และ 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setpicturescompression/) ควบคุมการลดความละเอียดของภาพและสามารถบังผลของการเปลี่ยนความละเอียดการแรสเตอร์ไลซ์ metafile. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setjpegquality/) ควบคุมคุณภาพการเข้ารหัส JPEG, ไม่ใช่ความละเอียดการแรสเตอร์ไลซ์ของ metafile.

## **กำหนด ID คงที่ให้กับรูปร่างและข้อความ**

ให้ callback การจัดรูปแบบกับ [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController) เพื่อกำหนดค่า [SvgShape.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setId) ให้กับแต่ละรูปร่าง SVG. Callback นี้ยังสามารถกำหนดค่า [SvgTSpan.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgtspan/#setId) ให้กับองค์ประกอบ `tspan` ของข้อความได้.

PhpJavaBridge ไม่สามารถเรียก callback PHP จาก `writeAsSvg` เมื่อทำงานในโหมดสตรีม. ให้วางตรรกะการจัดรูปแบบไว้ในคลาสช่วยเหลือเล็ก ๆ ของ Java, คอมไพล์และเพิ่มไฟล์ JAR ที่ได้ลงใน classpath ของ bridge. ตัวช่วยสามารถใช้ [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getOfficeInteropShapeId) ซึ่งคงที่ตลอดอายุของรูปร่าง, และตัวนับที่ทำซ้ำได้สำหรับ `tspan` ของข้อความ. ดู [Java implementation of `StableSvgIdController`](/slides/th/java/render-a-slide-as-an-svg-image/#assign-stable-ids-to-shapes-and-text) สำหรับโค้ดตัวช่วย.

หลังจากเพิ่มคลาส `com.example.slides.StableSvgIdController` ที่คอมไพล์แล้วลงใน classpath ของ bridge, ให้สร้างอินสแตนซ์จาก PHP และกำหนดให้กับ `SVGOptions`:

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

## **เพิ่ม Event Handler ของ SVG**

ใน callback การจัดรูปแบบ, เรียก [SvgShape.setEventHandler](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setEventHandler) พร้อมค่าของ [SvgEvent](https://reference.aspose.com/slides/php-java/aspose.slides/svgevent/) เพื่อเพิ่ม event handler ของ JavaScript ให้กับรูปร่างที่ส่งออก. กำหนด callback ด้วย [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController) และกำหนดฟังก์ชัน JavaScript ในหน้าเว็บหรือเอกสาร SVG ที่เป็นโฮสต์ผลลัพธ์.

เช่นเดียวกับ ID คงที่, ให้ทำการ implement callback ในตัวช่วยของ Java เมื่อ PhpJavaBridge ใช้โหมดสตรีม. [Java implementation of `SvgEventController`](/slides/th/java/render-a-slide-as-an-svg-image/#add-svg-event-handlers) กำหนด ID และ handler `OnClick` ให้กับรูปร่างที่ชื่อ `ActionButton`. คอมไพล์ตัวช่วยนั้น, เพิ่มลงใน classpath ของ bridge เป็น `com.example.slides.SvgEventController`, และใช้จาก PHP ดังต่อไปนี้:

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

หน้าโฮสต์สามารถกำหนดฟังก์ชัน JavaScript ที่อ้างอิงโดย handler ได้. การกำหนด ID และ event handler ทำให้ตัวดูสไลด์, การเพิ่มประสิทธิภาพการเข้าถึง, และกระบวนการทำงาน SVG เชิงโต้ตอบอื่น ๆ สามารถทำงานได้.

## **คำถามที่พบบ่อย**

**เมื่อไหร่ควรใช้ [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) แทน [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/)?**

ใช้ [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) เมื่อข้อความทั้งหมดต้องไม่ขึ้นกับแบบอักษร. ใช้ [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) เมื่อเฉพาะข้อความที่ใช้แบบอักษรภายนอกเท่านั้นที่ควรแปลงเป็นกราฟิก.

**วิธีที่ดีที่สุดในการทำให้ SVG มีขนาดเล็กลงคืออะไร?**

เริ่มจากการบีบอัดรูปภาพที่ฝัง, ลบพื้นที่รูปภาพที่ถูกตัด, และเลือกการเชื่อมโยงไฟล์แบบอักษรเมื่อตัวแวดล้อมเป้าหมายสามารถให้บริการไฟล์เหล่านั้นได้. ทดสอบผลลัพธ์เนื่องจากการลดความละเอียดของรูปภาพ, การลดคุณภาพ JPEG, และการเวกเตอร์ข้อความแต่ละอย่างมีการแลกเปลี่ยนคุณภาพและขนาดที่แตกต่างกัน.

**ฉันสามารถแก้ไของค์ประกอบ SVG ที่ส่งออกได้หลังจากส่งออกหรือไม่?**

ได้. กำหนด ID ผ่าน callback การจัดรูปแบบ, จากนั้นเลือกองค์ประกอบ SVG ที่ตรงกันในเครื่องมือหลังการประมวลผลหรือสคริปต์ในเบราว์เซอร์ของคุณ.