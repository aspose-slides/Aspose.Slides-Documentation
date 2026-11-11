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
description: "ส่งออกสไลด์ PowerPoint เป็นภาพ SVG บน Android และควบคุมฟอนต์, ข้อความ, รูปภาพ, ID, และเหตุการณ์ด้วย Aspose.Slides."
---
## **ภาพรวม**

SVG เป็นรูปแบบภาพที่ใช้ XML ที่สามารถปรับขนาดได้ ซึ่งทำงานได้ดีสำหรับการเผยแพร่บนเว็บ, โปรแกรมดูสไลด์, กระบวนการทำให้เข้าถึงได้, และการประมวลผลหลังการสร้างอัตโนมัติ Aspose.Slides สำหรับ Android ผ่าน Java จะส่งออกแต่ละสไลด์เป็นไฟล์ SVG แยกไฟล์และให้คุณควบคุมวิธีการเขียนข้อความ, ฟอนต์, รูปภาพ, और SVG elements ได้

ใช้ [SVGOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/) เมื่อ SVG ที่ส่งออกต้องมีขนาดกระชับ, คาดการณ์ได้ในหลายเบราว์เซอร์, หรือพร้อมสำหรับการใช้แบบโต้ตอบ

## **ส่งออกสไลด์เป็น SVG**

สร้าง [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/), เลือกสไลด์, แล้วเขียนลงสตรีมด้วย [ISlide.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-). ตัวอย่างต่อไปนี้ส่งออกสไลด์ทุกสไลด์ในงานนำเสนอเป็นไฟล์ SVG แยกไฟล์

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

ชื่อไฟล์ใช้ [ISlide.getSlideNumber](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getSlideNumber--) แทนการใช้ดัชนีของลูป คุณสามารถส่งออกรูปทรงเดี่ยวด้วย [IShape.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) เมื่อโปรแกรมดูสไลด์หรือหน้าเว็บต้องการเฉพาะรูปทรงนั้นเท่านั้น

## **กำหนดค่าการส่งออก SVG**

[SVGOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/) ควบคุมการเรนเดอร์ SVG สำหรับกรอบข้อความ, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) จะรวมกรอบข้อความในพื้นที่เรนเดอร์, และ [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) กำหนดว่าการหมุนของกรอบจะถูกนำไปใช้หรือไม่ ตั้งค่า [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) เป็น `true` เมื่อข้อความต้องการเรนเดอร์โดยไม่มีลิแกเจอร์

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

## **ควบคุมการตัดส่วนปลายเส้นที่หัวลูกศร**

SVG 1.1 ไม่มีการตั้งค่า marker inset เพื่อระบุว่าจุดเส้นควรหยุดตรงใต้หัวลูกศรก่อนหรือไม่ โดยค่าเริ่มต้น Aspose.Slides จะย่อเส้นที่ส่งออกให้ส่วน stroke ไม่ทะลุผ่าน marker เรียกใช้ [SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setDisableLineEndCropping-boolean-) ด้วยค่า `true` เพื่อวาด stroke ถึงจุดสิ้นสุดดั้งเดิมของเส้น การตั้งค่านี้มีผลต่อการส่งออก SVG เท่านั้น เส้นจะคงตำแหน่งและความยาวบนสไลด์

ตัวอย่างวาดหัวลูกศรรูปสามเหลี่ยมและเพชรบนเส้นที่กว้าง 2 และ 10 จุด ส่งออกสไลด์เดียวกันสองครั้งโดยเปลี่ยนเพียงตัวเลือกการตัดส่วนปลายเท่านั้น

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.io.FileOutputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    int y = 40;

    for (byte style : new byte[] { LineArrowheadStyle.Triangle, LineArrowheadStyle.Diamond }) {
        for (int width : new int[] { 2, 10 }) {
            IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 40, y, 200, 0);
            ILineFormat format = line.getLineFormat();
            format.getFillFormat().setFillType(FillType.Solid);
            format.getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
            format.setWidth(width);
            format.setEndArrowheadStyle(style);
            y += 50;
        }
    }

    SVGOptions options = new SVGOptions();
    options.setDisableLineEndCropping(false);
    try (FileOutputStream cropped = new FileOutputStream("cropped.svg")) {
        slide.writeAsSvg(cropped, options);
    }

    options.setDisableLineEndCropping(true);
    try (FileOutputStream uncropped = new FileOutputStream("uncropped.svg")) {
        slide.writeAsSvg(uncropped, options);
    }
} finally {
    presentation.dispose();
}
```

การเปรียบเทียบแสดงหัวลูกศรรูปสามเหลี่ยมบนเส้น 10 จุด เมื่อเปิดการตัดส่วนปลาย ปลายจะคม เมื่อปิดการตัดส่วนปลาย stroke จะทะลุผ่านด้านลาดของ marker และเหลือปลายแบน

![Enlarged 10-point triangle with a sharp tip when cropping is enabled and a flat end when cropping is disabled](line-end-cropping.png)

ในเส้นอื่น ๆ ของตัวอย่าง เส้นที่ยื่นออกมาน้อยกว่าเมื่อเป็นสามเหลี่ยม 2 จุด เพชรที่เติมสีจะปกปิดส่วนปลายของ stroke ทั้งสองความกว้าง

## **ควบคุมข้อความและฟอนต์**

เมื่อส่งออกสไลด์เป็น SVG คุณสามารถควบคุมได้ว่าข้อความจะคงเป็นข้อความหรือแปลงเป็นกราฟิกเวกเตอร์, และการรวมหรืออ้างอิงฟอนต์ภายนอก ตัวเลือกต่อไปนี้ช่วยให้คุณปรับสมดุลระหว่างความสอดคล้องของภาพ, การเลือกข้อความ, และการพึ่งพาฟอนต์ใน SVG ที่ส่งออก

### **เวกเตอร์ข้อความทั้งหมด**

ตั้งค่า [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) เป็น `true` เพื่อเขียนข้อความสไลด์ทั้งหมดเป็นกราฟิกเวกเตอร์ วิธีนี้ขจัดการพึ่งพาฟอนต์และทำให้ผลลัพธ์ภาพคงที่ข้ามเบราว์เซอร์มากขึ้น, แต่ข้อความจะไม่สามารถเลือกหรือค้นหาเป็นข้อความ SVG ได้อีกต่อไป

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

### **เลือกวิธีจัดการฟอนต์ภายนอก**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) ใช้ค่า [SvgExternalFontsHandling](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) สำหรับฟอนต์ที่โหลดจากภายนอก เลือก [SvgExternalFontsHandling.AddLinksToFontFiles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) เพื่ออ้างอิงไฟล์ฟอนต์แยกไฟล์, [SvgExternalFontsHandling.Embed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) เพื่อใส่ข้อมูลฟอนต์ใน SVG, หรือ [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) เพื่อเรนเดอร์ข้อความที่ใช้ฟอนต์ภายนอกเป็นกราฟิก ตรวจสอบลิขสิทธิ์ฟอนต์ก่อนทำการฝังฟอนต์

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

## **ลดขนาดภาพฝังใน SVG**

ใช้ [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-) เพื่อลดความละเอียดของรูปภาพที่ฝังอยู่, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) เพื่อลบพื้นที่รูปภาพที่ถูกตัด, และ [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-) เพื่อควบคุมคุณภาพการเข้ารหัส JPEG การตั้งค่าเหล่านี้จะลดขนาดไฟล์แต่จะมีผลต่อความคมชัดหรือข้อมูลรูปภาพที่เก็บไว้

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

## **ควบคุมความละเอียดการเรนเดอร์เมทาฟายล์เป็นแรสเตอร์**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setMetafileRasterizationDpi-int-) กำหนดขีดจำกัดความละเอียดต่ำสุดสำหรับการแรสเตอร์เมทาฟายล์ระหว่างการส่งออก SVG ใช้เพื่อปรับสมดุลระหว่างรายละเอียดและขนาดไฟล์เมื่อมีการแรสเตอร์ภาพ EMF หรือ WMF ไม่ได้กำหนด DPI ทั้งหมดสำหรับ SVG หรือบังคับให้ทุกวัตถุบนสไลด์กลายเป็นภาพแรสเตอร์

ดาวน์โหลด [metafile-rasterization.pptx](metafile-rasterization.pptx) ซึ่งมีภาพ EMF ที่มีเส้นทแยงมุมระยะห่างใกล้กัน ตัวอย่างต่อไปนี้ส่งออกสไลด์แรกของไฟล์นั้นที่ความละเอียดการแรสเตอร์สามระดับผ่าน [ISlide.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-). การตั้งค่าอื่น ๆ เหมือนเดิมเพื่อให้ผลลัพธ์สามารถเปรียบเทียบได้

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

ในผลลัพธ์, EMF ถูกแปลงเป็น PNG ฝังอยู่ในแต่ละ SVG การวัดต่อไปนี้เป็นของงานนำเสนอที่จัดหาให้; ไม่ใช่สูตรทั่วไปสำหรับแปลง DPI เป็นขนาดพิกเซล

| ความละเอียดการแรสเตอร์เมทาฟายล์ DPI | ขนาด PNG ฝัง | ขนาดไฟล์ SVG (ไบต์) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

การเปรียบเทียบด้านล่างแสดงบริเวณเดียวกันของแรสเตอร์ที่ฝังโดยมีขนาดการแสดงผลขยายเท่าเดิม เส้นทแยงมุมแสดงการเป็นพิกเซลที่มองเห็นได้ที่ 72 DPI และขอบที่เรียบขึ้นที่ความละเอียดสูงขึ้น ในขณะที่ไฟล์ SVG ขยายขึ้น การเพิ่มค่าดังกล่าวไม่ได้หมายความว่าจะปรับปรุงรายละเอียดทุกอย่างหรือเปลี่ยนรูปภาพที่ส่งออกทุกภาพ

![Enlarged diagonal-line detail at 72, 150, and 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-) ควบคุมการลดความละเอียดของภาพและอาจบังผลของการเปลี่ยนความละเอียดการแรสเตอร์เมทาฟายล์ [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-) ควบคุมคุณภาพการเข้ารหัส JPEG ไม่ใช่ความละเอียดการแรสเตอร์เมทาฟายล์

## **กำหนด ID คงที่ให้กับรูปทรงและข้อความ**

ใช้ [ISvgShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeformattingcontroller/) เพื่อกำหนดค่า [ISvgShape.setId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshape/#setId-java.lang.String-) ให้กับแต่ละรูปทรง SVG เพื่อกำหนดค่า [ISvgTSpan.setId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgtspan/#setId-java.lang.String-) บนองค์ประกอบ `tspan` ของข้อความด้วย, ให้ใช้ [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeandtextformattingcontroller/). กำหนดคอนโทรลเลอร์ใดก็ได้ผ่าน [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-)

คอนโทรลเลอร์ต่อไปนี้ใช้ [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) ซึ่งคงที่ตลอดอายุของรูปทรง, และตัวนับที่ทำซ้ำได้สำหรับ tspan ของข้อความ ทำให้ ID ที่สร้างขึ้นเหมาะสำหรับการประมวลผลต่อเนื่องของงานนำเสนอที่ไม่ได้เปลี่ยนแปลง

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

ใน [ISvgShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeformattingcontroller/), เรียก [ISvgShape.setEventHandler](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) พร้อมค่าของ [SvgEvent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgevent/) เพื่อเพิ่มตัวจัดการเหตุการณ์ JavaScript ให้กับรูปทรงที่ส่งออก กำหนดคอนโทรลเลอร์ผ่าน [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) และกำหนดฟังก์ชัน JavaScript ในหน้าเว็บหรือเอกสาร SVG ที่โฮสต์ผลลัพธ์

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

หน้าโฮสต์สามารถกำหนดฟังก์ชัน JavaScript ที่อ้างอิงโดยตัวจัดการได้ การกำหนด ID และตัวจัดการเหตุการณ์ทำให้โปรแกรมดูสไลด์, การเพิ่มความสามารถในการเข้าถึง, และกระบวนการโต้ตอบ SVG อื่น ๆ ทำงานได้

## **คำถามที่พบบ่อย**

**ควรใช้ [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) แทน [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) เมื่อไหร่?**

ใช้ [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) เมื่อข้อความทั้งหมดต้องอิสระจากฟอนต์ ใช้ [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) เมื่อเฉพาะข้อความที่ใช้ฟอนต์ภายนอกต้องการแปลงเป็นกราฟิก

**วิธีที่ดีที่สุดในการทำให้ SVG มีขนาดเล็กลงคืออะไร?**

เริ่มด้วยการบีบอัดรูปภาพที่ฝังอยู่, ลบพื้นที่รูปภาพที่ถูกตัด, และเลือกการเชื่อมโยงไฟล์ฟอนต์เมื่อสภาพแวดล้อมเป้าหมายสามารถให้บริการไฟล์เหล่านั้นได้ ทดสอบผลลัพธ์เนื่องจากการลดความละเอียดของรูปภาพ, การลดคุณภาพ JPEG, และการเวกเตอร์ข้อความแต่ละอย่างมีการแลกเปลี่ยนคุณภาพและขนาดที่ต่างกัน

**ฉันสามารถแก้ไของค์ประกอบ SVG ที่ส่งออกหลังการส่งออกได้หรือไม่?**

ได้ คุณสามารถกำหนด ID ผ่านคอนโทรลเลอร์การจัดรูปแบบ, จากนั้นเลือกองค์ประกอบ SVG ที่ตรงกันในเครื่องมือประมวลผลต่อหรือสคริปต์ของเบราว์เซอร์ของคุณ