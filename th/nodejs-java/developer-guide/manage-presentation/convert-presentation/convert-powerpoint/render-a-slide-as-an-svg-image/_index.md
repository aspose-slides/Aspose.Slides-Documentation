---
title: เรนเดอร์สไลด์การนำเสนอเป็นภาพ SVG ใน JavaScript
linktitle: สไลด์เป็น SVG
type: docs
weight: 50
url: /th/nodejs-java/render-a-slide-as-an-svg-image/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "ส่งออกสไลด์ PowerPoint เป็นภาพ SVG ใน JavaScript และควบคุมแบบอักษร, ข้อความ, รูปภาพ, ID, และเหตุการณ์ด้วย Aspose.Slides."
---
## **ภาพรวม**

SVG เป็นรูปแบบภาพแบบ XML ที่สามารถปรับขนาดได้ ซึ่งทำงานได้ดีสำหรับการเผยแพร่บนเว็บ, ตัวชมสไลด์, กระบวนการทำให้เข้าถึงได้, และการประมวลผลต่อท้ายอัตโนมัติ. Aspose.Slides for Node.js via Java ส่งออกแต่ละสไลด์เป็นไฟล์ SVG แยกไฟล์และให้คุณควบคุมวิธีที่ข้อความ, แบบอักษร, รูปภาพ, และองค์ประกอบ SVG ถูกเขียน

ใช้ [SVGOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/) เมื่อ SVG ที่ส่งออกต้องกะทัดรัด, คาดเดาได้ในหลายเบราว์เซอร์, หรือพร้อมสำหรับการใช้งานแบบโต้ตอบ

## **ส่งออกรูปสไลด์เป็น SVG**

สร้าง [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/), เลือกสไลด์และเขียนลงสตรีมด้วย [Slide.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/writeassvg/). ตัวอย่างต่อไปนี้ส่งออกรูปสไลด์ทั้งหมดในงานนำเสนอเป็นไฟล์ SVG แยกไฟล์

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

ไฟล์ชื่อใช้ [Slide.getSlideNumber](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidenumber/) แทนการใช้ดัชนีของลูป คุณยังสามารถส่งออกรูปร่างเดี่ยวด้วย [Shape.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/) เมื่อตัวชมสไลด์หรือหน้าเว็บต้องการเพียงรูปร่างนั้นเท่านั้น

## **กำหนดค่าเอาต์พุต SVG**

[SVGOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/) ควบคุมการเรนเดอร์ SVG สำหรับกรอบข้อความ, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setuseframesize/) จะรวมกรอบข้อความในพื้นที่เรนเดอร์, และ [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setuseframerotation/) จะกำหนดว่าจะใช้การหมุนของกรอบหรือไม่ ตั้งค่า [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/#setDisableFontLigatures) เป็น `true` เมื่อต้องการให้ข้อความแสดงผลโดยไม่มีลิการ์

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

## **ควบคุมการตัดขอบเส้นที่หัวลูกศร**

SVG 1.1 ไม่มีการตั้งค่า marker inset เพื่อระบุว่าเส้นควรหยุดที่จุดใดใต้หัวลูกศร โดยค่าเริ่มต้น Aspose.Slides จะสั้นเส้นที่ส่งออกเพื่อให้เส้นขอบไม่ยืดออกผ่าน marker เรียกใช้ [SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/#setDisableLineEndCropping) ด้วยค่า `true` เพื่อวาดเส้นถึงจุดสิ้นสุดเดิมของเส้น การตั้งค่านี้ส่งผลต่อผลลัพธ์ SVG เท่านั้น เส้นยังคงตำแหน่งและความยาวบนสไลด์เดิม

ตัวอย่างวาดหัวลูกศรรูปสามเหลี่ยมและเพชรบนเส้นที่กว้าง 2 จุดและ 10 จุด ส่งออกสไลด์เดียวกันสองครั้งโดยเปลี่ยนเฉพาะตัวเลือกการตัดขอบ

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const lineColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    let y = 40;

    for (const style of [slides.LineArrowheadStyle.Triangle, slides.LineArrowheadStyle.Diamond]) {
        for (const width of [2, 10]) {
            const line = slide.getShapes().addAutoShape(slides.ShapeType.Line, 40, y, 200, 0);
            const format = line.getLineFormat();
            format.getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
            format.getFillFormat().getSolidFillColor().setColor(lineColor);
            format.setWidth(width);
            format.setEndArrowheadStyle(java.newByte(style));
            y += 50;
        }
    }

    const options = new slides.SVGOptions();
    options.setDisableLineEndCropping(false);
    const cropped = java.newInstanceSync("java.io.FileOutputStream", "cropped.svg");
    try {
        slide.writeAsSvg(cropped, options);
    } finally {
        cropped.close();
    }

    options.setDisableLineEndCropping(true);
    const uncropped = java.newInstanceSync("java.io.FileOutputStream", "uncropped.svg");
    try {
        slide.writeAsSvg(uncropped, options);
    } finally {
        uncropped.close();
    }
} finally {
    presentation.dispose();
}
```

การเปรียบเทียบแสดงหัวลูกศรรูปสามเหลี่ยมบนเส้น 10 จุด เมื่อเปิดการตัดขอบ ปลายจะคม เมื่อปิดการตัดขอบ เส้นขอบจะยื่นผ่านด้านลาดของ marker และเหลือปลายแบน

![Enlarged 10-point triangle with a sharp tip when cropping is enabled and a flat end when cropping is disabled](line-end-cropping.png)

ในเส้นอื่นจากตัวอย่าง เส้นที่ยื่นออกมาน้อยเห็นได้ชัดบนสามเหลี่ยม 2 จุด เพชรที่เติมเต็มจะปิดส่วนปลายของเส้นทั้งสองความกว้าง

## **ควบคุมข้อความและแบบอักษร**

เมื่อส่งออกสไลด์เป็น SVG คุณสามารถควบคุมว่าข้อความจะคงเป็นข้อความหรือแปลงเป็นกราฟิกเวกเตอร์ และวิธีการรวมหรืออ้างอิงแบบอักษรภายนอก ตัวเลือกต่อไปนี้ช่วยให้คุณสมดุลความสอดคล้องของภาพ, การเลือกข้อความ, และการพึ่งพาแบบอักษรใน SVG ที่ส่งออก

### **แปลงเวกเตอร์ข้อความทั้งหมด**

ตั้งค่า [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) เป็น `true` เพื่อเขียนข้อความสไลด์ทั้งหมดเป็นกราฟิกเวกเตอร์ สิ่งนี้จะขจัดการพึ่งพาแบบอักษรและทำให้ผลลัพธ์มีความสอดคล้องมากขึ้นในหลายเบราว์เซอร์ แต่ข้อความจะไม่สามารถเลือกหรือค้นหาได้ในฐานะข้อความ SVG

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

### **เลือกวิธีจัดการกับแบบอักษรภายนอก**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setexternalfontshandling/) ใช้ค่า [SvgExternalFontsHandling](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/) สำหรับแบบอักษรที่โหลดจากภายนอก เลือก `AddLinksToFontFiles` เพื่ออ้างอิงไฟล์แบบอักษรแยกต่างหาก, `Embed` เพื่อฝังข้อมูลแบบอักษรลงใน SVG, หรือ `Vectorize` เพื่อเรนเดอร์เฉพาะข้อความที่ใช้แบบอักษรภายนอกเป็นกราฟิก ตรวจสอบลิขสิทธิ์ของแบบอักษรก่อนฝัง

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

## **ลดขนาดภาพที่ฝังไว้**

ใช้ [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) เพื่อลดความละเอียดของรูปภาพที่ฝัง, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setdeletepicturescroppedareas/) เพื่อตัดส่วนภาพที่ถูกครอปออก, และ [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setjpegquality/) เพื่อควบคุมคุณภาพการเข้ารหัส JPEG การตั้งค่าเหล่านี้จะลดขนาดไฟล์โดยอาจเสียคุณภาพหรือข้อมูลภาพที่ถูกเก็บ

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

## **ควบคุมความละเอียดการเรสเตอร์ไลซ์ของ Metafile**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/) ตั้งค่าขีดจำกัดความละเอียดต่ำสุดสำหรับการเรสเตอร์ไลซ์ Metafile ระหว่างการส่งออก SVG ใช้ค่าเพื่อสมดุลระหว่างความละเอียดและขนาดไฟล์เมื่อภาพ EMF หรือ WMF ถูกเรสเตอร์ไลซ์ มันไม่ได้กำหนด DPI สากลสำหรับ SVG หรือบังคับให้ทุกวัตถุบนสไลด์กลายเป็นภาพเรสเตอร์

ดาวน์โหลด [metafile-rasterization.pptx](metafile-rasterization.pptx) ซึ่งมีภาพ EMF ที่มีเส้นทแยงมุมใกล้กัน ตัวอย่างต่อไปนี้ส่งออกสไลด์แรกของไฟล์นั้นที่ความละเอียดเรสเตอร์ไลซ์สามระดับผ่าน [Slide.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/writeassvg/) การตั้งค่าอื่นทั้งหมดคงเดิมเพื่อให้เปรียบเทียบได้

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("metafile-rasterization.pptx");
try {
    for (const dpi of [72, 150, 300]) {
        const svgOptions = new slides.SVGOptions();
        svgOptions.setMetafileRasterizationDpi(dpi);
        svgOptions.setPicturesCompression(slides.PicturesCompression.Dpi330);
        svgOptions.setJpegQuality(90);

        const outputFileName = `slide-${dpi}.svg`;
        const svgStream = java.newInstanceSync("java.io.FileOutputStream", outputFileName);
        try {
            presentation.getSlides().get_Item(0).writeAsSvg(svgStream, svgOptions);
        } finally {
            svgStream.close();
        }
    }
} finally {
    presentation.dispose();
}
```

ในผลลัพธ์ EMF กลายเป็น PNG ฝังในแต่ละ SVG การวัดต่อไปนี้เป็นของงานนำเสนอที่ให้มา; ไม่ใช่สูตรทั่วไปสำหรับแปลง DPI เป็นพิกเซล

| DPI การเรสเตอร์ไลซ์ Metafile | ขนาด PNG ที่ฝัง | ขนาดไฟล์ SVG (ไบต์) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

การเปรียบเทียบด้านล่างแสดงพื้นที่เดียวของภาพเรสเตอร์ที่ฝังที่ขนาดการแสดงผลขยายเท่ากัน เส้นทแยงมุมแสดงพิกเซลที่มองเห็นได้ที่ 72 DPI และขอบที่เรียบขึ้นที่ความละเอียดสูงกว่า ในขณะที่ไฟล์ SVG มีขนาดเพิ่มขึ้น การเพิ่มค่าดังกล่าวไม่ได้ทำให้รายละเอียดทุกอย่างดีขึ้นหรือเปลี่ยนภาพที่ส่งออกทั้งหมด

![Enlarged diagonal-line detail at 72, 150, and 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) ควบคุมการลดความละเอียดของภาพและอาจบังผลของการเปลี่ยนความละเอียดการเรสเตอร์ไลซ์ของ Metafile [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setjpegquality/) ควบคุมคุณภาพการเข้ารหัส JPEG ไม่ใช่ความละเอียดการเรสเตอร์ไลซ์ของ Metafile

## **กำหนด ID ที่เสถียรให้กับรูปร่างและข้อความ**

ส่งตัวควบคุมการจัดรูปแบบไปที่ [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) เพื่อกำหนดค่า [SvgShape.setId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/setid/) ให้กับแต่ละรูปร่าง SVG ตัวควบคุมที่จัดการกับช่วงข้อความด้วยสามารถตั้งค่า [SvgTSpan.setId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgtspan/setid/) ให้กับองค์ประกอบ `tspan` ของข้อความ

ตัวควบคุมต่อไปนี้ใช้ [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/), ซึ่งคงที่ตลอดอายุของรูปร่าง, และตัวนับที่ทำซ้ำได้สำหรับช่วงข้อความของมัน ทำให้ ID ที่สร้างขึ้นเหมาะสำหรับการประมวลผลต่อหลังจากการนำเสนอไม่มีการเปลี่ยนแปลง

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

ในตัวควบคุมการจัดรูปแบบ ให้เรียก [SvgShape.setEventHandler](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/seteventhandler/) พร้อมค่าของ [SvgEvent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgevent/) เพื่อเพิ่มตัวจัดการเหตุการณ์ JavaScript ให้กับรูปร่างที่ส่งออก กำหนดตัวควบคุมด้วย [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) และกำหนดฟังก์ชัน JavaScript ในหน้า หรือเอกสาร SVG ที่โฮสต์ผลลัพธ์

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

หน้าโฮสต์สามารถกำหนดฟังก์ชัน JavaScript ที่ตัวจัดการอ้างอิงได้ การกำหนด ID และตัวจัดการเหตุการณ์ทำให้ตัวชมสไลด์, การปรับปรุงการเข้าถึง, และเวิร์กโฟลว์ SVG แบบโต้ตอบอื่น ๆ ทำงานได้

## **คำถามที่พบบ่อย**

**เมื่อใดควรใช้ [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) แทน [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/)?**

ใช้ [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) เมื่อข้อความทั้งหมดต้องอิสระจากแบบอักษร ใช้ [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/) เมื่อต้องการแปลงเป็นกราฟิกเพียงข้อความที่ใช้แบบอักษรภายนอก

**วิธีที่ดีที่สุดในการทำให้ SVG มีขนาดเล็กลงคืออะไร?**

เริ่มต้นด้วยการบีบอัดรูปภาพที่ฝังไว้, ลบพื้นที่ภาพที่ถูกครอป, และเลือกเชื่อมโยงไฟล์แบบอักษรเมื่อสภาพแวดล้อมเป้าหมายสามารถให้บริการไฟล์เหล่านั้น ทดสอบผลลัพธ์เนื่องจากการลดความละเอียดของภาพ, การลดคุณภาพ JPEG, และการแปลงเป็นเวกเตอร์มีผลต่อคุณภาพและขนาดที่แตกต่างกัน

**ฉันสามารถแก้ไของค์ประกอบ SVG ที่ส่งออกหลังจากการส่งออกได้หรือไม่?**

ได้ คุณสามารถกำหนด ID ผ่านตัวควบคุมการจัดรูปแบบ แล้วเลือกองค์ประกอบ SVG ที่ตรงกันในเครื่องมือหลังการประมวลผลหรือสคริปต์เบราว์เซอร์ของคุณ