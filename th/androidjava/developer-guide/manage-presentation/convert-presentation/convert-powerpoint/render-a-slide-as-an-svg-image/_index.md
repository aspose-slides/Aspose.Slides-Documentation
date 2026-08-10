---
title: เรนเดอร์สไลด์การนำเสนอเป็นภาพ SVG บน Android
linktitle: สไลด์เป็น SVG
type: docs
weight: 50
url: /th/androidjava/render-a-slide-as-an-svg-image/
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
- Android
- Java
- Aspose.Slides
description: "ส่งออกสไลด์ PowerPoint เป็นภาพ SVG บน Android และควบคุมฟอนต์, ข้อความ, รูปภาพ, ID และเหตุการณ์ด้วย Aspose.Slides."
---
## **ภาพรวม**

SVG เป็นรูปแบบภาพแบบ XML ที่ขยายได้ซึ่งทำงานได้ดีสำหรับการเผยแพร่บนเว็บ, ตัวดูสไลด์, กระบวนการทำให้เข้าถึงได้, และการประมวลผลอัตโนมัติหลังการสร้าง. Aspose.Slides สำหรับ Android ผ่าน Java จะส่งออกแต่ละสไลด์เป็นไฟล์ SVG แยกไฟล์และให้คุณควบคุมว่าข้อความ, ฟอนต์, รูปภาพ และองค์ประกอบ SVG จะถูกเขียนอย่างไร.

ใช้ [SVGOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/svgoptions/) เมื่อ SVG ที่ส่งออกต้องกระชับ, มีความคาดการณ์ได้ในหลายเบราว์เซอร์, หรือพร้อมสำหรับการใช้งานเชิงโต้ตอบ.

## **ส่งออกสไลด์เป็น SVG**

สร้าง [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/), เลือกสไลด์, และเขียนลงสตรีมด้วย [ISlide.writeAsSvg](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-). ตัวอย่างต่อไปนี้ส่งออกทุกสไลด์ในพรีเซนเทชันเป็นไฟล์ SVG แยกไฟล์.

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

ชื่อไฟล์ใช้ [ISlide.getSlideNumber](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islide/#getSlideNumber--) แทนการใช้ดัชนีของลูป. คุณยังสามารถส่งออกรูปทรงเดี่ยวด้วย [IShape.writeAsSvg](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) เมื่อโปรแกรมดูสไลด์หรือหน้าเว็บต้องการเฉพาะรูปทรงนั้น.

## **กำหนดค่าการส่งออก SVG**

[SVGOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/svgoptions/) ควบคุมการเรนเดอร์ SVG. สำหรับกรอบข้อความ, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) จะรวมกรอบข้อความในพื้นที่เรนเดอร์, และ [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) กำหนดว่าจะใช้การหมุนของกรอบหรือไม่. ตั้งค่า [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) เป็น `true` เมื่อข้อความต้องการเรนเดอร์โดยไม่มีลิเกเจอร์.

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

## **ควบคุมข้อความและฟอนต์**

### **แปลงเวคเตอร์ข้อความทั้งหมด**

ตั้งค่า [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) เป็น `true` เพื่อเขียนข้อความทั้งหมดของสไลด์เป็นกราฟิกเวคเตอร์. วิธีนี้จะขจัดการพึ่งพาฟอนต์และทำให้ผลลัพธ์ทางภาพสอดคล้องกันมากขึ้นในหลายเบราว์เซอร์, แต่ข้อความจะไม่สามารถเลือกหรือค้นหาได้ในรูปแบบ SVG.

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

### **เลือกวิธีการจัดการฟอนต์ภายนอก**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) ใช้ค่าของ [SvgExternalFontsHandling](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/svgexternalfontshandling/) สำหรับฟอนต์ที่โหลดจากภายนอก. เลือก [SvgExternalFontsHandling.AddLinksToFontFiles](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/svgexternalfontshandling/) เพื่ออ้างอิงไฟล์ฟอนต์แยก, [SvgExternalFontsHandling.Embed](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/svgexternalfontshandling/) เพื่อฝังข้อมูลฟอนต์ใน SVG, หรือ [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/svgexternalfontshandling/) เพื่อเรนเดอร์เฉพาะข้อความที่ใช้ฟอนต์ภายนอกเป็นกราฟิก. ตรวจสอบลิขสิทธิ์ฟอนต์ก่อนการฝังฟอนต์.

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

ใช้ [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-) เพื่อลดความละเอียดของภาพที่ฝังไว้, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) เพื่อตัดส่วนภาพที่ถูกครอบ, และ [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-) เพื่อควบคุมคุณภาพการเข้ารหัส JPEG. การตั้งค่าเหล่านี้จะลดขนาดไฟล์โดยอาจสูญเสียความละเอียดหรือข้อมูลภาพที่เก็บไว้.

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

## **กำหนด ID คงที่ให้กับรูปทรงและข้อความ**

ใช้ [ISvgShapeFormattingController](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isvgshapeformattingcontroller/) เพื่อกำหนด [ISvgShape.setId](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isvgshape/#setId-java.lang.String-) สำหรับแต่ละรูปทรง SVG. เพื่อกำหนดค่า [ISvgTSpan.setId](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isvgtspan/#setId-java.lang.String-) ให้กับองค์ประกอบ `tspan` ของข้อความด้วย, ให้ทำการติดตั้ง [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isvgshapeandtextformattingcontroller/). กำหนดคอนโทรลเลอร์ใดก็ได้ด้วย [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-).

คอนโทรลเลอร์ต่อไปนี้ใช้ [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) ซึ่งคงที่ตลอดอายุของรูปทรง, และตัวนับซ้ำได้สำหรับสแปนข้อความของมัน. วิธีนี้ทำให้ ID ที่สร้างขึ้นเหมาะสำหรับการประมวลผลต่อเนื่องของพรีเซนเทชันที่ไม่ได้เปลี่ยนแปลง.

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

ใน [ISvgShapeFormattingController](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isvgshapeformattingcontroller/), เรียก [ISvgShape.setEventHandler](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) พร้อมค่าของ [SvgEvent](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/svgevent/) เพื่อเพิ่มตัวจัดการเหตุการณ์ JavaScript ให้กับรูปทรงที่ส่งออก. กำหนดคอนโทรลเลอร์ด้วย [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) และกำหนดฟังก์ชัน JavaScript ในหน้าเว็บหรือเอกสาร SVG ที่โฮสต์ผลลัพธ์.

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

หน้าผู้โฮสต์สามารถกำหนดฟังก์ชัน JavaScript ที่อ้างอิงโดยตัวจัดการได้. การกำหนด ID และตัวจัดการเหตุการณ์ช่วยให้ตัวดูสไลด์, ปรับปรุงการเข้าถึง, และเวิร์กโฟลว์ SVG เชิงโต้ตอบอื่น ๆ ทำงานได้.

## **คำถามที่พบบ่อย**

**เมื่อใดควรใช้ [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) แทน [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/svgexternalfontshandling/)?**

ใช้ [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) เมื่อข้อความทั้งหมดต้องอิสระจากฟอนต์. ใช้ [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/svgexternalfontshandling/) เมื่อต้องการแปลงเป็นกราฟิกเฉพาะข้อความที่ใช้ฟอนต์ภายนอกเท่านั้น.

**วิธีที่ดีที่สุดในการทำให้ SVG มีขนาดเล็กลงคืออะไร?**

เริ่มต้นด้วยการบีบอัดภาพที่ฝังไว้, ลบพื้นที่ภาพที่ถูกครอบ, และเลือกไฟล์ฟอนต์ที่ลิงก์เมื่อสภาพแวดล้อมเป้าหมายสามารถให้บริการไฟล์เหล่านี้ได้. ทดสอบผลลัพธ์เนื่องจากการลดความละเอียดของภาพ, การลดคุณภาพ JPEG, และการแปลงข้อความเป็นเวคเตอร์แต่ละอย่างมีการแลกเปลี่ยนคุณภาพและขนาดที่แตกต่างกัน.

**ฉันสามารถแก้ไของค์ประกอบ SVG ที่ส่งออกแล้วได้หรือไม่?**

ได้. กำหนด ID ผ่านคอนโทรลเลอร์การจัดรูปแบบ, จากนั้นเลือกองค์ประกิบ SVG ที่ตรงกันในเครื่องมือประมวลผลต่อหรือสคริปต์ของเบราว์เซอร์ของคุณ.