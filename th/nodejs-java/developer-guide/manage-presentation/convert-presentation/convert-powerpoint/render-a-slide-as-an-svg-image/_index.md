---
title: แปลงสไลด์การนำเสนอเป็นภาพ SVG ใน JavaScript
linktitle: สไลด์เป็น SVG
type: docs
weight: 50
url: /th/nodejs-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint เป็น SVG
- งานนำเสนอเป็น SVG
- สไลด์เป็น SVG
- PPT เป็น SVG
- PPTX เป็น SVG
- ตัวเลือกการส่งออก SVG
- SVG เชิงโต้ตอบ
- PowerPoint
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ส่งออกสไลด์ PowerPoint เป็นภาพ SVG ใน JavaScript และควบคุมฟอนต์ ข้อความ รูปภาพ ID และเหตุการณ์ด้วย Aspose.Slides."
---
## **ภาพรวม**

SVG เป็นรูปแบบรูปภาพแบบ XML ที่ปรับขนาดได้ซึ่งทำงานได้ดีสำหรับการเผยแพร่บนเว็บ ผู้ดูสไลด์ การทำงานที่เกี่ยวกับการเข้าถึง และการประมวลผลหลังการแปลงอัตโนมัติ Aspose.Slides for Node.js via Java ส่งออกแต่ละสไลด์เป็นไฟล์ SVG แยกไฟล์และให้คุณควบคุมวิธีการเขียนข้อความ ฟอนต์ ภาพ และองค์ประกอบ SVG

ใช้ [SVGOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/svgoptions/) เมื่อ SVG ที่ส่งออกต้องกะทัดรัด มีพฤติกรรมที่คาดเดาได้ข้ามเบราว์เซอร์ หรือพร้อมสำหรับการใช้งานเชิงโต้ตอบ

## **ส่งออกสไลด์เป็น SVG**

สร้าง [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/), เลือกสไลด์ และเขียนลงสตรีมด้วย [Slide.writeAsSvg](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slide/writeassvg/). ตัวอย่างต่อไปนี้ส่งออกทุกสไลด์ในงานนำเสนอเป็นไฟล์ SVG แยกไฟล์

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const outputFileName = `slide-${slide.getSlideNumber()}.svg`;
        const svgStream = java.newInstanceSync("java.io.FileOutputStream", outputFileName);
        try {
            slide.writeAsSvg(svgStream);
        } finally {
            svgStream.close();
        }
    }
} finally {
    presentation.dispose();
}
```

ชื่อไฟล์ใช้ [Slide.getSlideNumber](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slide/getslidenumber/) แทนการใช้เลขลูป คุณยังสามารถส่งออกรูปร่างเดี่ยวโดยใช้ [Shape.writeAsSvg](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/writeassvg/) เมื่อผู้ดูสไลด์หรือหน้าเว็บต้องการเพียงรูปร่างนั้นเท่านั้น

## **กำหนดค่าเอาต์พุต SVG**

[SVGOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/svgoptions/) ควบคุมการเรนเดอร์ SVG สำหรับกรอบข้อความ, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/svgoptions/setuseframesize/) จะรวมกรอบข้อความในพื้นที่เรนเดอร์, และ [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/svgoptions/setuseframerotation/) กำหนดว่าจะใช้การหมุนกรอบหรือไม่ ตั้งค่า [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/svgoptions/#setDisableFontLigatures) เป็น `true` เมื่อข้อความต้องเรนเดอร์โดยไม่มีลิการเจอร์

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    svgOptions.setDisableFontLigatures(true);
    svgOptions.setUseFrameSize(true);
    svgOptions.setUseFrameRotation(false);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-custom-options.svg"
    );
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **ควบคุมข้อความและฟอนต์**

### **ทำเวกเตอร์ข้อความทั้งหมด**

ตั้งค่า [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) เป็น `true` เพื่อเขียนข้อความทั้งหมดของสไลด์เป็นกราฟิกเวกเตอร์ สิ่งนี้จะขจัดการพึ่งพาฟอนต์และทำให้ผลลัพธ์ภาพเหมือนกันข้ามเบราว์เซอร์มากขึ้น แต่ข้อความจะไม่สามารถเลือกหรือค้นหาได้อีกต่อไปในรูปแบบ SVG

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    svgOptions.setVectorizeText(true);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-vectorized-text.svg"
    );
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

### **เลือกวิธีจัดการฟอนต์ภายนอก**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/svgoptions/setexternalfontshandling/) ใช้ค่า [SvgExternalFontsHandling](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/svgexternalfontshandling/) สำหรับฟอนต์ที่โหลดจากภายนอก เลือก `AddLinksToFontFiles` เพื่ออ้างอิงไฟล์ฟอนต์แยกส่วน, `Embed` เพื่อฝังข้อมูลฟอนต์ใน SVG, หรือ `Vectorize` เพื่อเรนเดอร์เฉพาะข้อความที่ใช้ฟอนต์ภายนอกเป็นกราฟิก ตรวจสอบลิขสิทธิ์ฟอนต์ก่อนฝังฟอนต์เข้าไป

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const linkedFontsOptions = new slides.SVGOptions();
    linkedFontsOptions.setExternalFontsHandling(
        slides.SvgExternalFontsHandling.AddLinksToFontFiles
    );
    const linkedFontsStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-font-links.svg"
    );
    try {
        slide.writeAsSvg(linkedFontsStream, linkedFontsOptions);
    } finally {
        linkedFontsStream.close();
    }

    const embeddedFontsOptions = new slides.SVGOptions();
    embeddedFontsOptions.setExternalFontsHandling(
        slides.SvgExternalFontsHandling.Embed
    );
    const embeddedFontsStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-embedded-fonts.svg"
    );
    try {
        slide.writeAsSvg(embeddedFontsStream, embeddedFontsOptions);
    } finally {
        embeddedFontsStream.close();
    }

    const vectorizedExternalFontsOptions = new slides.SVGOptions();
    vectorizedExternalFontsOptions.setExternalFontsHandling(
        slides.SvgExternalFontsHandling.Vectorize
    );
    const vectorizedExternalFontsStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-vectorized-external-fonts.svg"
    );
    try {
        slide.writeAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
    } finally {
        vectorizedExternalFontsStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **ลดขนาดภาพฝัง**

ใช้ [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) เพื่อลดความละเอียดของภาพฝัง, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/svgoptions/setdeletepicturescroppedareas/) เพื่อตัดส่วนที่ครอบภาพออก, และ [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/svgoptions/setjpegquality/) เพื่อควบคุมคุณภาพการเข้ารหัส JPEG การตั้งค่าเหล่านี้จะลดขนาดไฟล์โดยอาจทำให้คุณภาพหรือข้อมูลภาพลดลง

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    svgOptions.setPicturesCompression(slides.PicturesCompression.Dpi150);
    svgOptions.setDeletePicturesCroppedAreas(true);
    svgOptions.setJpegQuality(80);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync("java.io.FileOutputStream", "compressed-slide.svg");
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **กำหนด ID คงที่ให้กับรูปร่างและข้อความ**

ส่งผ่านคอนโทรลเลอร์การจัดรูปแบบไปยัง [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) เพื่อกำหนดค่า [SvgShape.setId](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/svgshape/setid/) ให้กับแต่ละรูปร่าง SVG คอนโทรลเลอร์ที่จัดการช่วงข้อความเพิ่มเติมได้สามารถกำหนดค่า [SvgTSpan.setId](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/svgtspan/setid/) ให้กับองค์ประกอบ `tspan` ของข้อความได้

คอนโทรลเลอร์ต่อไปนี้ใช้ [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/), ซึ่งคงที่ตลอดอายุของรูปร่าง, และตัวนับที่ทำซ้ำได้สำหรับช่วงข้อความของมัน ทำให้ ID ที่สร้างขึ้นเหมาะสำหรับการประมวลผลต่อไปของงานนำเสนอที่ไม่เปลี่ยนแปลง

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

class StableSvgIdController {
    constructor() {
        this.currentShapeId = "";
        this.textSpanIndex = 0;
    }

    formatShape(svgShape, shape) {
        this.currentShapeId = `shape-${shape.getOfficeInteropShapeId()}`;
        this.textSpanIndex = 0;
        svgShape.setId(this.currentShapeId);
    }

    formatText(svgTSpan, portion, textFrame) {
        const textSpanId = `${this.currentShapeId}-text-${this.textSpanIndex++}`;
        svgTSpan.setId(textSpanId);
    }

    createProxy() {
        const controller = this;
        const interfaceName = "com.aspose.slides.ISvgShapeAndTextFormattingController";
        const proxyMethods = {
            formatShape(svgShape, shape) {
                controller.formatShape(svgShape, shape);
            },
            formatText(svgTSpan, portion, textFrame) {
                controller.formatText(svgTSpan, portion, textFrame);
            }
        };
        return java.newProxy(interfaceName, proxyMethods);
    }
}

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    const stableSvgIdController = new StableSvgIdController();
    const controllerProxy = stableSvgIdController.createProxy();
    svgOptions.setShapeFormattingController(controllerProxy);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-stable-ids.svg"
    );
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **เพิ่มตัวจัดการเหตุการณ์ SVG**

ในคอนโทรลเลอร์การจัดรูปแบบ, เรียก [SvgShape.setEventHandler](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/svgshape/seteventhandler/) พร้อมค่าของ [SvgEvent](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/svgevent/) เพื่อใส่ตัวจัดการเหตุการณ์ JavaScript ให้กับรูปร่างที่ส่งออก กำหนดคอนโทรลเลอร์ด้วย [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) และกำหนดฟังก์ชัน JavaScript ในหน้า หรือเอกสาร SVG ที่โฮสต์ผลลัพธ์

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

class SvgEventController {
    formatShape(svgShape, shape) {
        if (shape.getName() === "ActionButton") {
            svgShape.setId("action-button");
            svgShape.setEventHandler(
                slides.SvgEvent.OnClick,
                "handleShapeClick(event)"
            );
        }
    }

    createProxy() {
        const controller = this;
        const interfaceName = "com.aspose.slides.ISvgShapeFormattingController";
        const proxyMethods = {
            formatShape(svgShape, shape) {
                controller.formatShape(svgShape, shape);
            }
        };
        return java.newProxy(interfaceName, proxyMethods);
    }
}

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    const svgEventController = new SvgEventController();
    const controllerProxy = svgEventController.createProxy();
    svgOptions.setShapeFormattingController(controllerProxy);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync("java.io.FileOutputStream", "interactive-slide.svg");
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

หน้าโฮสต์สามารถกำหนดฟังก์ชัน JavaScript ที่อ้างอิงโดยตัวจัดการเหตุการณ์ การกำหนด ID และตัวจัดการเหตุการณ์ทำให้ผู้ดูสไลด์, การปรับปรุงการเข้าถึง, และเวิร์กโฟลว์ SVG เชิงโต้ตอบอื่น ๆ ทำงานได้

## **FAQ**

**เมื่อใดควรใช้ [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) แทน [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/svgexternalfontshandling/)?**

ใช้ [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) เมื่อข้อความทั้งหมดต้องไม่พึ่งพาฟอนต์ ใช้ [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/svgexternalfontshandling/) เมื่อต้องการแปลงเป็นกราฟิกเฉพาะข้อความที่ใช้ฟอนต์ภายนอกเท่านั้น

**วิธีที่ดีที่สุดในการทำให้ SVG เล็กลงคืออะไร?**

เริ่มต้นด้วยการบีบอัดภาพที่ฝังอยู่, ลบพื้นที่ภาพที่ถูกตัด, และเลือกใช้ไฟล์ฟอนต์แบบลิงก์เมื่อสภาพแวดล้อมเป้าหมายสามารถให้บริการได้ ทดสอบผลลัพธ์ เพราะการลดความละเอียดของภาพ, ลดคุณภาพ JPEG, และการทำเวกเตอร์ข้อความแต่ละอย่างมีการประนีประนอมด้านคุณภาพและขนาดที่ต่างกัน

**ฉันสามารถแก้ไของค์ประกอบ SVG ที่ส่งออกหลังจากการส่งออกได้หรือไม่?**

ทำได้ ให้กำหนด ID ผ่านคอนโทรลเลอร์การจัดรูปแบบ แล้วเลือกองค์ประกอบ SVG ที่ตรงกันในเครื่องมือประมวลผลต่อหรือสคริปต์ในเบราว์เซอร์ของคุณ