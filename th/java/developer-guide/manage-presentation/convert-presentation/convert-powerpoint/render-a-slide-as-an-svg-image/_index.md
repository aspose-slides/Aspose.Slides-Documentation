---
title: แปลงสไลด์การนำเสนอเป็นภาพ SVG ใน Java
linktitle: สไลด์เป็น SVG
type: docs
weight: 50
url: /th/java/render-a-slide-as-an-svg-image/
keywords:
  - PowerPoint เป็น SVG
  - การนำเสนอเป็น SVG
  - สไลด์เป็น SVG
  - PPT เป็น SVG
  - PPTX เป็น SVG
  - ตัวเลือกการส่งออก SVG
  - SVG แบบโต้ตอบ
  - PowerPoint
  - การนำเสนอ
  - Java
  - Aspose.Slides
description: "ส่งออกสไลด์ PowerPoint เป็นภาพ SVG ใน Java และควบคุมแบบอักษร, ข้อความ, รูปภาพ, ID, และเหตุการณ์ด้วย Aspose.Slides."
---
## **ภาพรวม**

SVG เป็นรูปแบบภาพที่ขยายได้โดยอิง XML ซึ่งทำงานได้ดีสำหรับการเผยแพร่บนเว็บ, ตัวดูสไลด์, กระบวนการเข้าถึง, และการประมวลผลหลังอัตโนมัติ. Aspose.Slides ส่งออกแต่ละสไลด์เป็นไฟล์ SVG แยกและให้คุณควบคุมวิธีการเขียนข้อความ, แบบอักษร, รูปภาพ, และองค์ประกอบ SVG.

ใช้ [SVGOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/svgoptions/) เมื่อ SVG ที่ส่งออกต้องมีขนาดกะทัดรัด, คาดการณ์ได้ในทุกเบราว์เซอร์, หรือพร้อมสำหรับการใช้งานแบบโต้ตอบ.

## **ส่งออกสไลด์เป็น SVG**

สร้าง [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/), เลือกสไลด์, และเขียนออกไปยังสตรีมโดยใช้ [ISlide.writeAsSvg](https://reference.aspose.com/slides/th/java/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-). ตัวอย่างต่อไปนี้ส่งออกทุกสไลด์ในงานนำเสนอเป็นไฟล์ SVG แยก.

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

ชื่อไฟล์ใช้ [ISlide.getSlideNumber](https://reference.aspose.com/slides/th/java/com.aspose.slides/islide/#getSlideNumber--) แทนการใช้ดัชนีของลูป. คุณยังสามารถส่งออกรูปทรงเดี่ยวด้วย [IShape.writeAsSvg](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) เมื่อผู้ดูสไลด์หรือเว็บเพจต้องการเฉพาะรูปทรงนั้น.

## **กำหนดค่าการส่งออก SVG**

[SVGOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/svgoptions/) ควบคุมการแสดงผล SVG. สำหรับกรอบข้อความ, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/th/java/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) จะรวมกรอบข้อความในพื้นที่การแสดงผล, และ [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/th/java/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) กำหนดว่าการหมุนกรอบจะถูกนำไปใช้หรือไม่. ตั้งค่า [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/th/java/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) เป็น `true` เมื่อข้อความต้องถูกแสดงโดยไม่มีลิกาเชอร์.

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

## **ควบคุมข้อความและแบบอักษร**

### **แปลงเวกเตอร์ข้อความทั้งหมด**

ตั้งค่า [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/th/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) เป็น `true` เพื่อบันทึกข้อความทั้งหมดในสไลด์เป็นกราฟิกเวกเตอร์. วิธีนี้กำจัดการพึ่งพาแบบอักษรและทำให้ผลลัพธ์ภาพสอดคล้องกันมากขึ้นในทุกเบราว์เซอร์, แต่ข้อความจะไม่สามารถเลือกหรือค้นหาได้ในรูปแบบข้อความ SVG อีกต่อไป.

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

### **เลือกวิธีการจัดการแบบอักษรภายนอก**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/th/java/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) ใช้ค่า [SvgExternalFontsHandling](https://reference.aspose.com/slides/th/java/com.aspose.slides/svgexternalfontshandling/) สำหรับแบบอักษรที่โหลดจากภายนอก. เลือก `AddLinksToFontFiles` เพื่ออ้างอิงไฟล์แบบอักษรแยก, `Embed` เพื่อฝังข้อมูลแบบอักษรใน SVG, หรือ `Vectorize` เพื่อเรนเดอร์เฉพาะข้อความที่ใช้แบบอักษรภายนอกเป็นกราฟิก. ตรวจสอบลิขสิทธิ์ของแบบอักษรก่อนฝัง.

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

## **ลดขนาดภาพฝัง**

ใช้ [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/th/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-) เพื่อลดความละเอียดของภาพฝัง, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/th/java/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) เพื่อตัดส่วนที่ถูกตัดของแหล่งภาพ, และ [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/th/java/com.aspose.slides/svgoptions/#setJpegQuality-int-) เพื่อควบคุมคุณภาพการเข้ารหัส JPEG. การตั้งค่าเหล่านี้ช่วยลดขนาดไฟล์แต่อาจสูญเสียความคมชัดของภาพหรือข้อมูลภาพที่เก็บไว้.

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

## **กำหนด ID ที่คงที่ให้กับรูปทรงและข้อความ**

ใช้ [ISvgShapeFormattingController](https://reference.aspose.com/slides/th/java/com.aspose.slides/isvgshapeformattingcontroller/) เพื่อกำหนด [ISvgShape.setId](https://reference.aspose.com/slides/th/java/com.aspose.slides/isvgshape/#setId-java.lang.String-) ให้กับรูปทรง SVG แต่ละรูป. เพื่อกำหนดค่าของ [ISvgTSpan.setId](https://reference.aspose.com/slides/th/java/com.aspose.slides/isvgtspan/#setId-java.lang.String-) ให้กับองค์ประกอบข้อความ `tspan` ด้วย, ให้ดำเนินการ [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/th/java/com.aspose.slides/isvgshapeandtextformattingcontroller/). กำหนดคอนโทรลเลอร์ใดก็ได้ด้วย [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/th/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-).

คอนโทรลเลอร์ต่อไปนี้ใช้ [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--) ซึ่งคงที่ตลอดอายุของรูปทรง, และตัวนับที่ทำซ้ำได้สำหรับข้อความ `tspan` ของมัน. สิ่งนี้ทำให้ ID ที่สร้างขึ้นเหมาะกับการประมวลผลหลังจากงานนำเสนอที่ไม่เปลี่ยนแปลง.

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

ใน [ISvgShapeFormattingController](https://reference.aspose.com/slides/th/java/com.aspose.slides/isvgshapeformattingcontroller/), เรียก [ISvgShape.setEventHandler](https://reference.aspose.com/slides/th/java/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) พร้อมค่าของ [SvgEvent](https://reference.aspose.com/slides/th/java/com.aspose.slides/svgevent/) เพื่อเพิ่มตัวจัดการเหตุการณ์ JavaScript ให้กับรูปทรงที่ส่งออก. กำหนดคอนโทรลเลอร์ด้วย [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/th/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) และกำหนดฟังก์ชัน JavaScript ในหน้าเว็บหรือเอกสาร SVG ที่โฮสต์ผลลัพธ์.

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

หน้าโฮสต์สามารถกำหนดฟังก์ชัน JavaScript ที่อ้างอิงโดยตัวจัดการเหตุการณ์ได้. การกำหนด ID และตัวจัดการเหตุการณ์ทำให้ตัวดูสไลด์, การปรับปรุงการเข้าถึง, และกระบวนการ SVG แบบโต้ตอบอื่น ๆ ทำงานได้.

## **คำถามที่พบบ่อย**

**เมื่อใดที่ควรใช้ [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/th/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) แทน [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/th/java/com.aspose.slides/svgexternalfontshandling/)?**

ใช้ [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/th/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) เมื่อข้อความทั้งหมดต้องเป็นอิสระจากแบบอักษร. ใช้ [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/th/java/com.aspose.slides/svgexternalfontshandling/) เมื่อเฉพาะข้อความที่ใช้แบบอักษรภายนอกเท่านั้นที่ควรแปลงเป็นกราฟิก.

**วิธีที่ดีที่สุดในการทำให้ SVG มีขนาดเล็กลงคืออะไร?**

เริ่มต้นด้วยการบีบอัดภาพฝัง, ลบส่วนที่ถูกตัดของรูปภาพ, และเลือกไฟล์แบบอักษรที่เป็นลิงก์เมื่อสภาพแวดล้อมเป้าหมายสามารถให้บริการได้. ทดสอบผลลัพธ์เนื่องจากความละเอียดภาพที่ต่ำลง, คุณภาพ JPEG ที่ต่ำลง, และข้อความที่แปลงเป็นเวกเตอร์แต่ละอย่างมีการแลกเปลี่ยนคุณภาพและขนาดที่แตกต่างกัน.

**ฉันสามารถแก้ไของค์ประกอบ SVG ที่ส่งออกหลังจากการส่งออกได้หรือไม่?**

ได้. กำหนด ID ผ่านคอนโทรลเลอร์การฟอร์แมต, แล้วเลือกองค์ประกอบ SVG ที่ตรงกันในเครื่องมือหรือสคริปต์เบราว์เซอร์สำหรับการประมวลผลหลัง.