---
title: แปลงสไลด์งานนำเสนอเป็นภาพใน JavaScript
linktitle: สไลด์เป็นภาพ
type: docs
weight: 35
url: /th/nodejs-java/convert-slide/
keywords:
- แปลงสไลด์
- ส่งออกสไลด์
- สไลด์เป็นภาพ
- บันทึกสไลด์เป็นภาพ
- สไลด์เป็น EMF
- สไลด์เป็น PNG
- สไลด์เป็น JPEG
- สไลด์เป็นบิตแมพ
- สไลด์เป็น TIFF
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "แปลงสไลด์จากงานนำเสนอรูปแบบ PPT, PPTX และ ODP เป็น PNG, JPEG, GIF, TIFF, EMF และรูปแบบภาพอื่น ๆ ใน JavaScript ด้วย Aspose.Slides."
---
## **บทนำ**

Aspose.Slides for Node.js via Java สามารถเรนเดอร์สไลด์แต่ละสไลด์จากงานนำเสนอ PowerPoint และ OpenDocument เป็นรูปแบบ PNG, JPEG, GIF, TIFF และรูปแบบภาพอื่น ๆ

เพื่อแปลงสไลด์เป็นภาพ ให้ทำตามขั้นตอนต่อไปนี้:

1. โหลดงานนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)  
2. เลือกสไลด์ที่ต้องการเรนเดอร์  
3. หากจำเป็น ให้กำหนดค่าการเรนเดอร์ด้วยคลาส [RenderingOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/renderingoptions/) หรือ [TiffOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/tiffoptions/)  
4. เรียกใช้เมธอด [Slide.getImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slide/#getImage) เมธอดนี้จะคืนค่าอ็อบเจ็กต์ที่เป็น [IImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/iimage/)  
5. เรียกใช้เมธอด [IImage.save](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/iimage/#save) และระบุรูปแบบของไฟล์ผลลัพธ์ด้วยค่า [ImageFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/imageformat/)

## **แปลงสไลด์เป็นภาพ PNG**

การแปลงที่ง่ายที่สุดใช้การตั้งค่าเรนเดอร์เริ่มต้น อ็อบเจ็กต์ [IImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/iimage/) ที่ได้สามารถประมวลผลในหน่วยความจำหรือบันทึกลงไฟล์ได้

ตัวอย่าง JavaScript ด้านล่างเรนเดอร์สไลด์แรกและบันทึกเป็นภาพ PNG:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage();
    try {
        image.save("Slide_0.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **แปลงสไลด์เป็นภาพด้วยขนาดกำหนดเอง**

ใช้เมธอดโอเวอร์โหลดของ [Slide.getImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slide/#getImage) ที่รับค่า `java.awt.Dimension` เพื่อเรนเดอร์สไลด์ด้วยขนาดพิกเซลที่ต้องการอย่างแม่นยำ

ตัวอย่างต่อไปนี้สร้างภาพ JPEG ขนาด 1820 × 1040 พิกเซล:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const imageSize = java.newInstanceSync("java.awt.Dimension", 1820, 1040);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage(imageSize);
    try {
        image.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **แปลงสไลด์พร้อมบันทึกบันทึกย่อและความคิดเห็นเป็นภาพ**

โดยค่าเริ่มต้น ภาพสไลด์จะไม่รวมบันทึกย่อหรือความคิดเห็น ส่งอ็อบเจ็กต์ [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/notescommentslayoutingoptions/) ไปยังเมธอด [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) เพื่อกำหนดตำแหน่งที่ต้องการให้บันทึกย่อและความคิดเห็นแสดงผล

ตัวอย่างต่อไปนี้วางบันทึกย่อที่ตัดทอนไว้ด้านล่างสไลด์และวางความคิดเห็นไว้ทางด้านขวา:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const scaleX = 2;
const scaleY = scaleX;

const commentsAreaColor = java.newInstanceSync("java.awt.Color", 250, 235, 215);

const layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);
layoutOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);
layoutOptions.setCommentsAreaWidth(500);
layoutOptions.setCommentsAreaColor(commentsAreaColor);

const renderingOptions = new aspose.slides.RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutOptions);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage(renderingOptions, scaleX, scaleY);
    try {
        image.save("Image_with_notes_and_comments_0.gif", aspose.slides.ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Warning" color="warning" %}}
สำหรับการแปลงสไลด์เป็นภาพ ห้ามส่งค่า [BottomFull](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/notespositions/) ไปยังเมธอด [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) เนื่องจากบันทึกย่ออาจมีข้อความมากกว่าขนาดภาพที่กำหนดได้ ใช้ค่า [BottomTruncated](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/notespositions/) แทน
{{% /alert %}}

## **แปลงสไลด์เป็นภาพโดยใช้ตัวเลือก TIFF**

คลาส [TiffOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/tiffoptions/) ช่วยให้คุณควบคุมขนาด ความละเอียด และคุณสมบัติอื่น ๆ ของภาพ TIFF ที่เรนเดอร์

ตัวอย่างต่อไปนี้เรนเดอร์สไลด์แรกเป็นภาพ TIFF ขนาด 2160 × 2880 พิกเซลที่ความละเอียด 300 DPI:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const imageSize = java.newInstanceSync("java.awt.Dimension", 2160, 2880);

const tiffOptions = new aspose.slides.TiffOptions();
tiffOptions.setImageSize(imageSize);
tiffOptions.setDpiX(300);
tiffOptions.setDpiY(300);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage(tiffOptions);
    try {
        image.save("output.tiff", aspose.slides.ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Warning" color="warning" %}}
การสนับสนุน TIFF ไม่ได้รับการรับประกันในรุ่น Java ก่อน JDK 9
{{% /alert %}}

## **แปลงสไลด์ทั้งหมดเป็นภาพ**

วนลูปผ่านคอลเลกชันสไลด์เพื่อแปลงงานนำเสนอทั้งหมดเป็นชุดของภาพ สไลด์ที่ซ่อนไว้จะถูกรวมด้วย เว้นแต่คุณจะข้ามอย่างชัดเจน

ตัวอย่างต่อไปนี้เรนเดอร์ทุกสไลด์เป็นภาพ JPEG โดยใช้ค่าขยายในแนวนอนและแนวตั้งเท่ากับ 2:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const scaleX = 2;
const scaleY = scaleX;

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        const slide = presentation.getSlides().get_Item(index);
        const image = slide.getImage(scaleX, scaleY);
        try {
            image.save("Slide_" + index + ".jpg", aspose.slides.ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **สร้างเอาต์พุตแบบ Enhanced Metafile**

Enhanced Metafile (EMF) มีประโยชน์เมื่อจำเป็นต้องแลกเปลี่ยนกราฟิกแบบเวกเตอร์กับ Microsoft Office หรือแอปพลิเคชัน Windows อื่น ๆ ที่รองรับ Windows metafile เทียบกับภาพแบบพิกเซล EMF สามารถเก็บการดำเนินการวาดเวกเตอร์ที่ปรับขนาดได้โดยไม่สูญเสียความคมชัด อย่างไรก็ตาม EMF เป็นรูปแบบความเข้ากันได้สำหรับแอปพลิเคชันที่สนับสนุน Windows metafile เท่านั้น ไม่ใช่รูปแบบการแลกเปลี่ยนสากล นอกจากนี้ เนื้อหาสไลด์ที่ซับซ้อน เช่น รูปภาพบิตแมพและเอฟเฟกต์บางอย่าง อาจถูกจัดเก็บเป็นองค์ประกอบที่แปลงเป็นราสเตอร์ภายในคอนเทนเนอร์ metafile เวกเตอร์

### **ส่งออกสไลด์เป็น EMF**

เมธอด [Slide.writeAsEmf](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slide/#writeAsEmf) เขียนสไลด์ลงสตรีมเป้าหมายในรูปแบบ EMF ตัวอย่างต่อไปนี้โหลดงานนำเสนอ เลือกสไลด์แรก แล้วเขียนลงสตรีมไฟล์ EMF:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const emfStream = java.newInstanceSync("java.io.FileOutputStream", "Slide_0.emf");
    try {
        slide.writeAsEmf(emfStream);
    } finally {
        emfStream.close();
    }
} finally {
    presentation.dispose();
}
```

ผู้เรียกจะเป็นเจ้าของสตรีมที่ส่งให้กับ [Slide.writeAsEmf](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slide/#writeAsEmf) และต้องรับผิดชอบการปิดสตรีมนั้น ตามที่แสดงข้างต้น

### **แปลงภาพ SVG เป็น EMF แล้วเพิ่มลงในงานนำเสนอ**

ใช้เมธอด [SvgImage.writeAsEmf](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/svgimage/#writeAsEmf) เพื่อแปลงเนื้อหา SVG เป็น EMF ไบต์ที่ได้สามารถเพิ่มลงในงานนำเสนอผ่านเมธอด [ImageCollection.addImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/imagecollection/#addImage) และวางบนสไลด์ด้วยเมธอด [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shapecollection/#addPictureFrame)

ตัวอย่างต่อไปนี้สร้างอ็อบเจ็กต์ [SvgImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/svgimage/) จากโค้ด SVG แปลงเป็น EMF ในหน่วยความจำ แทรก metafile ลงบนสไลด์แรก และบันทึกงานนำเสนอ:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
const svgImage = new aspose.slides.SvgImage(svgContent);

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const emfStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    try {
        svgImage.writeAsEmf(emfStream);

        const emfData = java.newArray("byte", Array.from(emfStream.toByteArray()));
        const image = presentation.getImages().addImage(emfData);
        slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 100, image);
    } finally {
        emfStream.close();
    }

    presentation.save("Presentation_with_emf.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[SvgImage.writeAsEmf](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/svgimage/#writeAsEmf) ไม่รับการเป็นเจ้าของสตรีมปลายทาง `java.io.ByteArrayOutputStream` เก็บข้อมูลทั้งหมดในหน่วยความจำ จึงไม่ต้องรีเซ็ตตำแหน่งก่อนเรียก `toByteArray` อาร์เรย์ไบต์ที่คืนค่าจะยังคงใช้ได้หลังจากสตรีมถูกปิด

การสร้าง EMF มีให้ใช้บนระบบปฏิบัติการที่สนับสนุนโดย Aspose.Slides for Node.js via Java และการกำหนดค่า JDK ที่เลือก แต่การเรนเดอร์อาจแตกต่างกันระหว่างแพลตฟอร์มเมื่อฟอนต์หรือไลบรารีกราฟิกขาดหาย ลองติดตั้งฟอนต์ที่ใช้ในเนื้อหาแหล่งต้น หรือกำหนดการทดแทนที่เหมาะสม ปฏิบัติตาม [platform requirements](/slides/th/nodejs-java/system-requirements/) สำหรับ Aspose.Slides for Node.js via Java แล้วตรวจสอบผลลัพธ์ในแอปพลิเคชันที่รับ EMF เป้าหมาย แอปพลิเคชันบน Linux และ macOS มักมีการสนับสนุนการแสดงและแก้ไข Windows metafile อย่างจำกัดหรือไม่สม่ำเสมอ

## **การเรนเดอร์สี Emoji**

{{% alert title="Note" color="info" %}}
เพื่อให้สี Emoji แสดงผลอย่างถูกต้องเมื่อแปลงสไลด์นำเสนอเป็นภาพ ฟอนต์ Emoji ที่ใช้ในงานนำเสนอจำเป็นต้องติดตั้งและพร้อมใช้งานบนระบบที่ทำการแปลง ตัวอย่างเช่น หากงานนำเสนอใช้ **Segoe UI Emoji** แต่ฟอนต์นี้ไม่มีอยู่ Emoji อาจปรากฏเป็นสีเดียว (โมโนโครม) ในภาพผลลัพธ์
{{% /alert %}}

## **คำถามที่พบบ่อย**

**Aspose.Slides รองรับการเรนเดอร์สไลด์พร้อมแอนิเมชันหรือไม่?**  
ไม่. เมธอด [Slide.getImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slide/#getImage) เรนเดอร์ภาพสไลด์แบบคงที่และไม่ได้ส่งออกแอนิเมชัน

**สไลด์ที่ซ่อนไว้สามารถส่งออกเป็นภาพได้หรือไม่?**  
ได้. สไลด์ที่ซ่อนไว้สามารถเรนเดอร์ได้เช่นเดียวกับสไลด์ปกติ ให้วางไว้ในลูปการประมวลผลตามตัวอย่างข้างต้น

**เงาและเอฟเฟกต์อื่น ๆ ถูกเก็บรักษาในภาพสไลด์หรือไม่?**  
ได้. Aspose.Slides จะเรนเดอร์เงา ความโปร่งใส และเอฟเฟกต์กราฟิกที่สนับสนุนอื่น ๆ ในภาพสไลด์