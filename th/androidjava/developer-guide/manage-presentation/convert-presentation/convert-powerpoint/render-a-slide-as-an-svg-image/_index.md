---
title: เรนเดอร์สไลด์การนำเสนอเป็นรูปภาพ SVG บน Android
linktitle: สไลด์เป็น SVG
type: docs
weight: 50
url: /th/androidjava/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint เป็น SVG
- การนำเสนอไปเป็น SVG
- สไลด์ไปเป็น SVG
- PPT เป็น SVG
- PPTX เป็น SVG
- ตัวเลือกการส่งออก SVG
- SVG เชิงโต้ตอบ
- PowerPoint
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ส่งออกสไลด์ PowerPoint เป็นรูปภาพ SVG บน Android และควบคุมฟอนต์, ข้อความ, รูปภาพ, ID, และเหตุการณ์ด้วย Aspose.Slides."
---
## **ภาพรวม**

SVG เป็นรูปแบบภาพที่ขยายได้โดยอิง XML ซึ่งทำงานได้ดีสำหรับการเผยแพร่บนเว็บ, โปรแกรมดูสไลด์, กระบวนการทำให้เข้าถึงได้, และการประมวลผลหลังอัตโนมัติ. Aspose.Slides for Android via Java ส่งออกแต่ละสไลด์เป็นไฟล์ SVG แยกไฟล์และให้คุณควบคุมวิธีการเขียนข้อความ, ฟอนท์, รูปภาพ, และองค์ประกอบ SVG

ใช้ [SVGOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/) เมื่อ SVG ที่ส่งออกต้องมีขนาดกะทัดรัด, คาดการณ์ได้ในหลายเบราว์เซอร์, หรือพร้อมใช้งานแบบโต้ตอบ.

## **ส่งออกสไลด์เป็น SVG**

สร้าง [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/), เลือกสไลด์, และเขียนลงในสตรีมด้วย [ISlide.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-). ตัวอย่างต่อไปนี้ส่งออกทุกสไลด์ในงานนำเสนอเป็นไฟล์ SVG แยกไฟล์

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        String outputFileName = String.format("slide-%d.svg", slide.getSlideNumber());

        try (FileOutputStream svgStream = new FileOutputStream(outputFileName)) {
            slide.writeAsSvg(svgStream);
        }
    }
} finally {
    presentation.dispose();
}
```

ชื่อไฟล์ใช้ [ISlide.getSlideNumber](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getSlideNumber--) แทนการใช้ดัชนีของลูป. คุณยังสามารถส่งออกรูปทรายย์เดียวด้วย [IShape.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) เมื่อโปรแกรมดูสไลด์หรือหน้าเว็บต้องการเฉพาะรูปทรายย์นั้น

## **กำหนดค่าการส่งออก SVG**

[SVGOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/) ควบคุมการเรนเดอร์ SVG. สำหรับกรอบข้อความ, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) จะรวมกรอบข้อความในพื้นที่เรนเดอร์, และ [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) กำหนดว่าการหมุนกรอบจะถูกนำไปใช้หรือไม่. ตั้งค่า [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) เป็น `true` เมื่อข้อความต้องการเรนเดอร์โดยไม่มีลีกาเจอร์

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setDisableFontLigatures(true);
    svgOptions.setUseFrameSize(true);
    svgOptions.setUseFrameRotation(false);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-custom-options.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **ควบคุมข้อความและฟอนท์**

เมื่อส่งออกสไลด์เป็น SVG, คุณสามารถควบคุมว่าข้อความจะคงเป็นข้อความหรือแปลงเป็นกราฟิกเวกเตอร์, และวิธีการรวมหรืออ้างอิงฟอนท์ภายนอก. ตัวเลือกต่อไปนี้ช่วยให้คุณปรับสมดุลระหว่างความสอดคล้องของภาพ, การเลือกข้อความ, และการพึ่งพาฟอนท์ใน SVG ที่ส่งออก

### **เวกเตอร์ข้อความทั้งหมด**

ตั้งค่า [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) เป็น `true` เพื่อเขียนข้อความสไลด์ทั้งหมดเป็นกราฟิกเวกเตอร์. วิธีนี้ขจัดการพึ่งพาฟอนท์และทำให้ผลลัพธ์ภาพสอดคล้องกันมากขึ้นในหลายเบราว์เซอร์, แต่ข้อความจะไม่สามารถเลือกหรือค้นหาได้ในรูปแบบ SVG

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setVectorizeText(true);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-vectorized-text.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

### **เลือกวิธีการจัดการฟอนท์ภายนอก**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) ใช้ค่า [SvgExternalFontsHandling](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) สำหรับฟอนท์ที่โหลดจากภายนอก. เลือก [SvgExternalFontsHandling.AddLinksToFontFiles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) เพื่ออ้างอิงไฟล์ฟอนท์แยก, [SvgExternalFontsHandling.Embed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) เพื่อฝังข้อมูลฟอนท์ใน SVG, หรือ [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) เพื่อเรนเดอร์เฉพาะข้อความที่ใช้ฟอนท์ภายนอกเป็นกราฟิก. ตรวจสอบสิทธิ์การใช้ฟอนท์ก่อนการฝังฟอนท์

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    SVGOptions linkedFontsOptions = new SVGOptions();
    linkedFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.AddLinksToFontFiles);
    try (FileOutputStream linkedFontsStream = new FileOutputStream("slide-with-font-links.svg")) {
        slide.writeAsSvg(linkedFontsStream, linkedFontsOptions);
    }

    SVGOptions embeddedFontsOptions = new SVGOptions();
    embeddedFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.Embed);
    try (FileOutputStream embeddedFontsStream = new FileOutputStream("slide-with-embedded-fonts.svg")) {
        slide.writeAsSvg(embeddedFontsStream, embeddedFontsOptions);
    }

    SVGOptions vectorizedExternalFontsOptions = new SVGOptions();
    vectorizedExternalFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.Vectorize);
    try (FileOutputStream vectorizedExternalFontsStream = new FileOutputStream("slide-with-vectorized-external-fonts.svg")) {
        slide.writeAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
    }
} finally {
    presentation.dispose();
}
```

## **ลดขนาดภาพที่ฝังไว้**

ใช้ [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-) เพื่อลดความละเอียดของรูปภาพที่ฝัง, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) เพื่อละเว้นพื้นที่ภาพที่ถูกตัด, และ [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-) เพื่อควบคุมคุณภาพการเข้ารหัส JPEG. การตั้งค่าเหล่านี้ช่วยลดขนาดไฟล์โดยอาจเสียคุณภาพหรือข้อมูลรูปภาพที่เก็บไว้

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setPicturesCompression(PicturesCompression.Dpi150);
    svgOptions.setDeletePicturesCroppedAreas(true);
    svgOptions.setJpegQuality(80);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("compressed-slide.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **ควบคุมความละเอียดการเรสเตอร์ไลเซชันของเมตาฟายล์**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setMetafileRasterizationDpi-int-) กำหนดขีดจำกัดความละเอียดต่ำสุดสำหรับการเรสเตอร์ไลซ์เมตาฟายล์ระหว่างการส่งออก SVG. ใช้เพื่อปรับสมดุลระหว่างรายละเอียดและขนาดไฟล์เมื่อภาพ EMF หรือ WMF ถูกเรสเตอร์ไลซ์. มันไม่ได้กำหนด DPI ทั้งหมดสำหรับ SVG หรือบังคับให้ทุกวัตถุบนสไลด์กลายเป็นภาพเรสเตอร์

ดาวน์โหลด [metafile-rasterization.pptx](metafile-rasterization.pptx), ซึ่งมีภาพ EMF ที่มีเส้นแนวทแยงใกล้กัน. ตัวอย่างต่อไปนี้ส่งออกสไลด์แรกของไฟล์ที่ความละเอียดเรสเตอร์ไลซ์สามระดับผ่าน [ISlide.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-). การตั้งค่าอื่น ๆ ของการส่งออกจะเหมือนเดิมเพื่อเปรียบเทียบผลลัพธ์

```java
import com.aspose.slides.PicturesCompression;
import com.aspose.slides.Presentation;
import com.aspose.slides.SVGOptions;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("metafile-rasterization.pptx");
try {
    for (int dpi : new int[] { 72, 150, 300 }) {
        SVGOptions svgOptions = new SVGOptions();
        svgOptions.setMetafileRasterizationDpi(dpi);
        svgOptions.setPicturesCompression(PicturesCompression.Dpi330);
        svgOptions.setJpegQuality(90);

        String outputFileName = String.format("slide-%d.svg", dpi);
        try (FileOutputStream svgStream = new FileOutputStream(outputFileName)) {
            presentation.getSlides().get_Item(0).writeAsSvg(svgStream, svgOptions);
        }
    }
} finally {
    presentation.dispose();
}
```

ในผลลัพธ์, EMF กลายเป็น PNG ที่ฝังในแต่ละ SVG. การวัดต่อไปนี้เป็นสำหรับงานนำเสนอที่ให้มา; ไม่ใช่สูตรทั่วไปสำหรับการแปลง DPI เป็นมิติพิกเซล

| ความละเอียดการเรสเตอร์ไลซ์เมตาฟายล์ DPI | มิติ PNG ที่ฝัง | ขนาดไฟล์ SVG (ไบต์) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

การเปรียบเทียบด้านล่างแสดงพื้นที่เดียวกันของภาพเรสเตอร์ที่ฝังในขนาดแสดงผลที่ขยายเดียวกัน. เส้นแนวทแยงแสดงการเป็นพิกเซลที่มองเห็นได้ที่ 72 DPI และขอบที่เรียบขึ้นที่ความละเอียดสูงกว่า, ในขณะที่ไฟล์ SVG เติบโต. การเพิ่มค่าดังกล่าวไม่ได้หมายความว่าจะปรับปรุงทุกรายละเอียดหรือเปลี่ยนแปลงภาพที่ส่งออกทุกภาพ

![รายละเอียดเส้นทแยงที่ขยายที่ 72, 150, และ 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-) ควบคุมการลดความละเอียดของภาพและอาจซ่อนผลของการเปลี่ยนความละเอียดการเรสเตอร์ไลซ์เมตาฟายล์. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-) ควบคุมคุณภาพการเข้ารหัส JPEG, ไม่ใช่ความละเอียดการเรสเตอร์ไลซ์เมตาฟายล์

## **กำหนด ID เสถียรให้กับรูปร่างและข้อความ**

ใช้ [ISvgShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeformattingcontroller/) เพื่อตั้งค่า [ISvgShape.setId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshape/#setId-java.lang.String-) สำหรับแต่ละรูปร่าง SVG. เพื่อกำหนดค่า [ISvgTSpan.setId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgtspan/#setId-java.lang.String-) ให้กับองค์ประกอบ `tspan` ของข้อความด้วย, ให้ติดตั้ง [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeandtextformattingcontroller/). กำหนดคอนโทรลเลอร์ใดก็ได้ด้วย [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-)

คอนโทรลเลอร์ต่อไปนี้ใช้ [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--), ซึ่งคงที่ตลอดอายุของรูปร่าง, และตัวนับที่ทำซ้ำได้สำหรับสแปรนด์ข้อความของมัน. สิ่งนี้ทำให้ ID ที่สร้างขึ้นเหมาะสำหรับการประมวลผลต่อจากงานนำเสนอที่ไม่เปลี่ยนแปลง

```java
class StableSvgIdController implements ISvgShapeAndTextFormattingController {
    private String currentShapeId = "";
    private int textSpanIndex;

    public void formatShape(ISvgShape svgShape, IShape shape) {
        currentShapeId = String.format("shape-%d", shape.getOfficeInteropShapeId());
        textSpanIndex = 0;
        svgShape.setId(currentShapeId);
    }

    public void formatText(ISvgTSpan svgTSpan, IPortion portion, ITextFrame textFrame) {
        svgTSpan.setId(String.format("%s-text-%d", currentShapeId, textSpanIndex++));
    }
}

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setShapeFormattingController(new StableSvgIdController());

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-stable-ids.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **เพิ่มตัวจัดการเหตุการณ์ SVG**

ใน [ISvgShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeformattingcontroller/), เรียก [ISvgShape.setEventHandler](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) พร้อมค่า [SvgEvent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgevent/) เพื่อเพิ่มตัวจัดการเหตุการณ์ JavaScript ให้กับรูปร่างที่ส่งออก. กำหนดคอนโทรลเลอร์ด้วย [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) และกำหนดฟังก์ชัน JavaScript ในหน้าเว็บหรือเอกสาร SVG ที่เป็นโฮสต์ของผลลัพธ์

```java
class SvgEventController implements ISvgShapeFormattingController {
    public void formatShape(ISvgShape svgShape, IShape shape) {
        if ("ActionButton".equals(shape.getName())) {
            svgShape.setId("action-button");
            svgShape.setEventHandler(SvgEvent.OnClick, "handleShapeClick(event)");
        }
    }
}

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setShapeFormattingController(new SvgEventController());

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("interactive-slide.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

หน้าโฮสต์สามารถกำหนดฟังก์ชัน JavaScript ที่ตัวจัดการอ้างอิงได้. การกำหนด ID และตัวจัดการเหตุการณ์ทำให้โปรแกรมดูสไลด์, การปรับปรุงการเข้าถึง, และเวิร์กโฟลว์ SVG ที่โต้ตอบได้อื่น ๆ ทำงานได้

## **คำถามที่พบบ่อย**

**เมื่อใดควรใช้ [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) แทน [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/)?**

ใช้ [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) เมื่อข้อความทั้งหมดต้องไม่พึ่งพาฟอนท์. ใช้ [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) เมื่อต้องการแปลงเป็นกราฟิกเฉพาะข้อความที่ใช้ฟอนท์ภายนอก

**วิธีที่ดีที่สุดในการทำให้ SVG มีขนาดเล็กลงคืออะไร?**

เริ่มด้วยการบีบอัดรูปภาพที่ฝังไว้, ลบพื้นที่ภาพที่ถูกตัด, และเลือกไฟล์ฟอนท์แบบลิงก์เมื่อสภาพแวดล้อมเป้าหมายสามารถให้บริการได้. ทดสอบผลลัพธ์เนื่องจากความละเอียดภาพที่ต่ำลง, คุณภาพ JPEG ที่ต่ำลง, และข้อความที่เวกเตอร์ จะมีการแลกเปลี่ยนคุณภาพและขนาดที่แตกต่างกัน

**ฉันสามารถแก้ไของค์ประกอบ SVG ที่ส่งออกแล้วได้หรือไม่?**

ได้. กำหนด ID ผ่านคอนโทรลเลอร์การจัดรูปแบบ, จากนั้นเลือกองค์ประกอบ SVG ที่ตรงกันในเครื่องมือประมวลผลต่อหรือสคริปต์ของเบราว์เซอร์.