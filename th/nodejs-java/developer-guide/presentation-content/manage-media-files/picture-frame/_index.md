---
title: จัดการกรอบรูปภาพในงานนำเสนอโดยใช้ JavaScript
linktitle: กรอบรูปภาพ
type: docs
weight: 10
url: /th/nodejs-java/picture-frame/
keywords:
- กรอบรูปภาพ
- เพิ่มกรอบรูปภาพ
- สร้างกรอบรูปภาพ
- ภาพฝังอยู่
- ภาพเชื่อมโยง
- สกัดภาพ
- ภาพแรสเตอร์
- ภาพ SVG
- ครอบภาพ
- ลบพื้นที่ที่ครอบ
- บีบอัดภาพ
- StretchOffset
- การจัดรูปแบบกรอบรูปภาพ
- สเกลสัมพัทธ์
- เอฟเฟกต์ภาพ
- สัดส่วนภาพ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "สร้าง, จัดรูปแบบ, เชื่อมโยง, ครอบ, สกัด, และบีบอัดกรอบรูปภาพในงานนำเสนอด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java."
---
## **ภาพรวม**

Picture frame คือรูปร่างบนสไลด์ที่แสดงภาพ ใน Aspose.Slides, ทรัพยากรภาพและรูปร่างที่แสดงภาพเป็นอ็อบเจ็กต์ที่แยกกัน: **Presentation** เป็นเจ้าของทรัพยากรภาพที่ฝังอยู่ผ่าน **ImageCollection** ของมัน, ในขณะที่ **PictureFrame** ควบคุมตำแหน่งของภาพ, ขนาด, การจัดรูปแบบเส้น, การหมุน, การครอบ, เอฟเฟกต์ภาพ, และการตั้งค่าอื่น ๆ ในระดับเฟรม

การแยกนี้มีประโยชน์เมื่อภาพเดียวกันแสดงหลายครั้ง เพิ่มภาพไปยังพรีเซนเทชันเพียงครั้งเดียว, เก็บ **PPImage** ที่คืนค่าไว้, และใช้ทรัพยากรภาพนั้นเมื่อต้องสร้าง picture frames

Picture frames สามารถบรรจุภาพแรสเตอร์เช่น PNG หรือ JPEG และภาพเวกเตอร์ SVG ได้ นอกจากนี้ยังสามารถอ้างอิงภาพเชื่อมโยงแทนการจัดเก็บไบต์ภาพในพรีเซนเทชัน ตัวเลือกนี้ส่งผลต่อความพกพา, ขนาดไฟล์, การสกัด, และพฤติกรรมการส่งออก ดังนั้นจึงเป็นประโยชน์ที่จะกำหนดวิธีการจัดเก็บภาพก่อนนำไปจัดรูปแบบหรือปรับแต่ง

## **เพิ่มและจัดรูปแบบภาพที่ฝังไว้**

สำหรับภาพที่ฝังไว้, ให้เพิ่มข้อมูลภาพไปยังพรีเซนเทชันและสร้าง picture frame ด้วย **ShapeCollection.addPictureFrame**(https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shapecollection/#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) ภาพจะกลายเป็นส่วนหนึ่งของแพ็คเกจพรีเซนเทชัน ทำให้พรีเซนเทชันคงเป็นอิสระเมื่อย้ายไปยังคอมพิวเตอร์เครื่องอื่น

ตัวอย่างต่อไปนี้เพิ่มภาพ PNG, สร้างเฟรมตามขนาดดั้งเดิมของภาพ, และนำไปใช้กับการจัดรูปแบบเส้นและการหมุน:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    pictureFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pictureFrame.getLineFormat().setWidth(3);
    pictureFrame.setRotation(15);

    presentation.save("picture-frame.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Picture frame ควบคุมรูปทรงที่แสดง; การเปลี่ยนขนาดเฟรมไม่ส่งผลต่อมิติพิกเซลดั้งเดิมที่จัดเก็บในทรัพยากรภาพที่ฝังไว้ ความแตกต่างนี้สำคัญเมื่อทำการครอบหรือบีบอัดภาพในภายหลัง

## **ใช้สเกลสัมพัทธ์**

**PictureFrame**(https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pictureframe/) เปิดเผยการสเกลความกว้างและความสูงสัมพัทธ์ของเฟรมผ่าน **setRelativeScaleWidth**(https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleWidth-float-) และ **setRelativeScaleHeight**(https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleHeight-float-) ค่าของ `1.0` ตรงกับ 100% ของขนาดภาพต้นฉบับ สเกลสัมพัทธ์มีประโยชน์เมื่อเวิร์กโฟลว์ต้องคงอัตราส่วนต่อขนาดภาพต้นฉบับแทนการคำนวณขนาดสุดท้ายด้วยตนเอง

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 100, image);
    pictureFrame.setRelativeScaleWidth(java.newFloat(1.35));
    pictureFrame.setRelativeScaleHeight(java.newFloat(0.8));

    presentation.save("relative-scale.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

สเกลสัมพัทธ์เปลี่ยนการตั้งค่าสเกลของเฟรม; ไม่ทำการรีแซมพลิงหรือบีบอัดภาพที่ฝังไว้

## **ภาพที่ฝังไว้และภาพเชื่อมโยง**

ภาพที่ฝังไว้เก็บข้อมูลภาพภายในพรีเซนเทชันและจึงเป็นตัวเลือกที่ปลอดภัยที่สุดสำหรับความพกพาและการแสดงผลที่คาดเดาได้ ภาพเชื่อมโยงเก็บตำแหน่งภายนอกผ่านเมธอด **Picture.setLinkPathLong**(https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picture/#setLinkPathLong-java.lang.String-) แทนการฝังข้อมูลภาพในลักษณะเดียวกัน

ภาพเชื่อมโยงสามารถลดปริมาณข้อมูลภาพที่เก็บในไฟล์ PPTX ได้ แต่ก็เพิ่มการพึ่งพาไฟล์ภายนอก ไฟล์ที่เชื่อมโยงต้องยังคงเข้าถึงได้สำหรับแอปพลิเคชันที่เปิดหรือเรนเดอร์พรีเซนเทชัน หากเส้นทางเปลี่ยน, ไฟล์ถูกย้าย, หรือทรัพยากรไม่พร้อมใช้งาน picture ที่เชื่อมโยงอาจไม่แสดงตามที่คาดไว้ สำหรับพรีเซนเทชันที่ต้องส่งอีเมล, เก็บเป็นแฟ้มเก่า, หรือเรนเดอร์ในสภาพแวดล้อมแยก, ภาพที่ฝังไว้มักจะเชื่อถือได้มากกว่า

### **เพิ่มภาพเชื่อมโยง**

ตัวอย่างต่อไปนี้สร้าง picture frame และชี้ไปยังไฟล์ภาพท้องถิ่น มุ่งเน้นที่การเชื่อมโยงภาพเท่านั้น; การเชื่อมโยงวิดีโอเป็นเวิร์กโฟลว์สื่อแยกต่างหากและไม่ได้ผสมไว้ในตัวอย่างนี้

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const path = require("path");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 180, null);
    const linkPath = path.resolve("image.png");
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong(linkPath);

    presentation.save("linked-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ใช้ลิงก์เมื่อการจัดการไฟล์ภายนอกเป็นจุดประสงค์ ไม่ควรใช้เป็นวิธีทดแทนการบีบอัด: PPTX ที่มีการพึ่งพาภาพที่ขัดข้องมักจะน้อยประโยชน์กว่าไฟล์ที่ใหญ่แต่เป็นอิสระ

## **สกัดภาพจาก Picture Frame**

ก่อนสกัดภาพจากพรีเซนเทชันที่มีอยู่, ตรวจสอบว่า shape เป็น **PictureFrame**(https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pictureframe/) จริงและมีภาพที่ฝังอยู่ PictureFrame ที่เชื่อมโยงอาจไม่มีไบต์ภาพที่สามารถสกัดได้ในลักษณะเดียวกัน

### **สกัดภาพแรสเตอร์**

API ภาพสมัยใหม่ใช้ **IImage**(https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/iimage/) โดยตรง ตัวอย่างต่อไปนี้ค้นหาภาพแรสเตอร์ที่ฝังอยู่เป็นอันดับแรกบนสไลด์และบันทึกเป็น PNG:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            continue;
        }

        const embeddedImage = shape.getPictureFormat().getPicture().getImage();
        if (embeddedImage == null || embeddedImage.getSvgImage() != null) {
            continue;
        }

        const rasterImage = embeddedImage.getImage();
        try {
            rasterImage.save("extracted-image.png", aspose.slides.ImageFormat.Png);
        } finally {
            rasterImage.dispose();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

การบันทึกผ่าน **IImage.save**(https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/iimage/#save) จะทำการแปลงภาพที่สกัดเป็นรูปแบบผลลัพธ์ที่ต้องการ หากต้องการไบต์ที่เข้ารหัสเก็บไว้ในพรีเซนเทชันแทนไฟล์แรสเตอร์ที่แปลงแล้ว ให้ใช้ข้อมูลไบนารีของทรัพยากรภาพแทน

### **สกัดภาพ SVG**

สำหรับภาพ SVG, **PPImage**(https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ppimage/) เปิดเผยอ็อบเจ็กต์ **SvgImage**(https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/svgimage/) นี้ทำให้คุณดึงข้อมูล SVG ได้โดยตรงโดยไม่ต้องแรสเตอร์ภาพก่อน

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            continue;
        }

        const embeddedImage = shape.getPictureFormat().getPicture().getImage();
        const svgImage = embeddedImage != null ? embeddedImage.getSvgImage() : null;
        if (svgImage == null) {
            continue;
        }

        fs.writeFileSync("extracted-image.svg", svgImage.getSvgData());
        break;
    }
} finally {
    presentation.dispose();
}
```

การเก็บเนื้อหา SVG เป็น SVG จะรักษาเวกเตอร์ต้นฉบับภายในพรีเซนเทชัน การส่งออกเป็นแรสเตอร์เช่น PNG หรือ JPEG จำเป็นต้องเรนเดอร์เวกเตอร์เป็นพิกเซล การส่งออกสไลด์เป็น PDF หรือ SVG ก็เป็นขั้นตอนการเรนเดอร์เช่นกัน ดังนั้นกราฟิกที่ส่งออกไม่ควรถือว่าเป็นสำเนาไบต์ต่อไบต์ของ SVG ที่ฝังไว้; ควรใช้ข้อมูลจาก **SvgImage.getSvgData**(https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/svgimage/#getSvgData--) เมื่อจำเป็นต้องใช้ทรัพยากรเวกเตอร์ดั้งเดิม

## **ครอบภาพ**

การครอบเปลี่ยนส่วนที่มองเห็นของภาพภายในเฟรม ค่าการครอบบน **PictureFillFormat**(https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picturefillformat/) เป็นเปอร์เซ็นต์ของมิติภาพต้นฉบับ การครอบไม่ได้ลบพิกเซลที่ซ่อนอยู่จากภาพที่ฝังไว้โดยตรง มันเพียงเปลี่ยนพื้นที่ที่มองเห็นเท่านั้น

ตัวอย่างต่อไปนี้ค้นหา picture frame อย่างปลอดภัยและนำค่าการครอบไปใช้:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        pictureFrame.getPictureFormat().setCropLeft(java.newFloat(23.6));
        pictureFrame.getPictureFormat().setCropRight(java.newFloat(21.5));
        pictureFrame.getPictureFormat().setCropTop(java.newFloat(3));
        pictureFrame.getPictureFormat().setCropBottom(java.newFloat(31));
        presentation.save("cropped-image.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

เนื่องจากข้อมูลภาพที่ซ่อนอยู่ยังคงอยู่, สามารถเปลี่ยนการครอบในภายหลังโดยไม่เสียพิกเซลเดิม หากขนาดไฟล์สำคัญกว่าการย้อนกลับ, สามารถลบส่วนที่ครอบอย่างจริงจังตามที่อธิบายในส่วนถัดไป

## **ลบข้อมูลภาพที่ครอบ**

**PictureFillFormat.deletePictureCroppedAreas**(https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) จะลบข้อมูลภาพที่อยู่นอกสี่เหลี่ยมครอบปัจจุบันและคืนทรัพยากรภาพที่ได้ผลลัพธ์ การทำเช่นนี้สามารถลดขนาดไฟล์ได้ แต่เป็นการเพิ่มประสิทธิภาพแบบทำลาย: หลังจากบันทึกพรีเซนเทชัน พิกเซลที่ถูกลบจะไม่สามารถกู้คืนเพื่อการยกเลิกการครอบได้อีก

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const croppedImage = pictureFrame.getPictureFormat().deletePictureCroppedAreas();
        if (croppedImage != null) {
            presentation.save("cropped-data-removed.pptx", aspose.slides.SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

เมธอดนี้อาจเพิ่มทรัพยากรภาพใหม่ไปยังพรีเซนเทชัน หากภาพต้นฉบับยังถูกใช้โดย picture frame อื่น ๆ, เฟรมเหล่านั้นยังคงต้องใช้ทรัพยากรเดิม ดังนั้นการลบพื้นที่ที่ครอบอาจไม่ได้ลดจำนวนภาพโดยรวม การครอบเนื้อหา WMF หรือ EMF ด้วยเมธอดนี้จะทำให้ผลลัพธ์ที่ครอบแรสเตอร์เป็น PNG

## **บีบอัดภาพแรสเตอร์**

**PictureFillFormat.compressImage**(https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) ลดความละเอียดภาพแรสเตอร์สัมพันธ์กับขนาดที่ภาพแสดง สามารถลบพื้นที่ที่ครอบในขั้นตอนเดียวได้ เมธอดจะคืนค่า `true` เมื่อภาพถูกปรับขนาดหรือครอบ และ `false` เมื่อไม่จำเป็นต้องเปลี่ยนแปลง

ใช้ค่าตัวแปร **PicturesCompression**(https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picturescompression/) ที่กำหนดล่วงหน้าหากความละเอียดเป้าหมายมาตรฐานเพียงพอ:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const compressed = pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi150);
        console.log(compressed ? "The image was compressed." : "No compression was necessary.");
        presentation.save("compressed-image.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

สามารถส่งค่าความละเอียด DPI บวกที่กำหนดเองแทนค่าที่กำหนดล่วงหน้าเมื่อจำเป็นต้องมีเป้าหมายเฉพาะ

การบีบอัดมุ่งเน้นที่ภาพแรสเตอร์ SVG และเมตาไฟล์ไม่ได้รับผลโดยกระบวนการบีบอัดนี้ อย่าลืมว่าความละเอียดต่ำและการลบพื้นที่ที่ครอบไม่สามารถกู้คืนได้จากพรีเซนเทชันที่ปรับแล้ว ควรเลือกความละเอียดเป้าหมายตามขนาดที่ภาพจะถูกดูหรือส่งออกจริง มากกว่าการใช้ DPI ต่ำสุดทั่วทุกสถานการณ์

## **จัดการเอฟเฟกต์การแปลงภาพ**

สำหรับเวิร์กโฟลว์ครบถ้วนที่ครอบคลุมการปรับความสว่าง, คอนทราสต์, การแปลงสี, เบลอ, เอฟเฟกต์อัลฟา, การจัดลำดับ, การตรวจสอบ, การลบ, และการตรวจสอบรอบกลับ, ดู **Image Transform Effects**(/nodejs-java/image-transform-effects/)

## **ล็อกรูปร่างของ Picture Frame**

การตั้งค่า **PictureFrameLock**(https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pictureframelock/) ควบคุมว่าการแก้ไขใดบ้างที่ถูกปิดสำหรับ picture frame ตัวอย่างเช่น **setAspectRatioLocked**(https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) จะรักษาสัดส่วนของรูปร่างขณะปรับขนาด

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);

    presentation.save("locked-picture-frame.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

การล็อกนี้ใช้กับรูปร่าง picture frame เท่านั้น ไม่บังคับให้ภาพต้นฉบับต้องรีแซมพลิงหรือเปลี่ยนสัดส่วนอย่างถาวร

## **ปรับค่า StretchOffset**

เมื่อโหมดเติมภาพเป็น stretch, ค่า stretch‑offset บน **PictureFillFormat**(https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picturefillformat/) กำหนดสี่เหลี่ยมเติมสัมพันธ์กับกรอบของ picture frame เปอร์เซ็นต์บวกสร้างการเว้นระยะจากขอบ, ส่วนเปอร์เซ็นต์ลบสร้างการขยายออก

นี่แตกต่างจากการครอบ ค่าการครอบเลือกส่วนของภาพต้นฉบับที่มองเห็น, ส่วน stretch‑offset ปรับสี่เหลี่ยมที่ภาพเติมจะถูกขยายเข้า

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 400, 300, image);
    pictureFrame.getPictureFormat().setPictureFillMode(java.newByte(aspose.slides.PictureFillMode.Stretch));
    pictureFrame.getPictureFormat().setStretchOffsetLeft(java.newFloat(12));
    pictureFrame.getPictureFormat().setStretchOffsetRight(java.newFloat(12));
    pictureFrame.getPictureFormat().setStretchOffsetTop(java.newFloat(8));
    pictureFrame.getPictureFormat().setStretchOffsetBottom(java.newFloat(8));

    presentation.save("stretch-offsets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ใช้ stretch‑offset สำหรับการวางตำแหน่งการเติม ใช้คุณสมบัติการครอบเมื่อเป้าหมายคือซ่อนขอบของภาพต้นฉบับ

## **การจัดเก็บ, ขนาดไฟล์, และการพิจารณาการส่งออก**

การตัดสินใจหลักจะง่ายขึ้นเมื่อการจัดเก็บภาพและการจัดรูปแบบ picture‑frame แยกกัน:

- **Embedded images** ทำให้พรีเซนเทชันเป็นอิสระและเป็นตัวเลือกที่เชื่อถือได้ที่สุดสำหรับการแชร์และการเรนเดอร์บนเซิร์ฟเวอร์, แต่ภาพแรสเตอร์ขนาดใหญ่จะเพิ่มขนาด PPTX และการใช้หน่วยความจำ
- **Linked images** สามารถทำให้แพคเกจมีขนาดเล็กลง, แต่พรีเซนเทชันจะพึ่งพาไฟล์ภายนอกที่ต้องคงอยู่ที่เส้นทางหรือที่ตั้งที่บันทึกไว้
- **Cropping** ในเบื้องต้นไม่ทำลาย; พิกเซลที่ซ่อนอยู่ยังคงฝังไว้จนกว่าจะลบพื้นที่ที่ครอบอย่างชัดเจนหรือระหว่างการบีบอัด
- **Compression** สามารถลดขนาดไฟล์ได้อย่างมีนัยสำคัญสำหรับภาพแรสเตอร์ที่ใหญ่เกินไป, แต่จะเสียความละเอียดต้นฉบับ ควรใช้หลังจากรู้ขนาดแสดงบนสไลด์แล้ว
- **SVG images** ควรคงเป็น SVG เมื่อความคงที่ของเวกเตอร์สำคัญ; สกัด SVG ที่ฝังไว้โดยตรงเมื่อต้องการทรัพยากรเวกเตอร์เอง การส่งออกสไลด์เป็นแรสเตอร์จะเปลี่ยน SVG เป็นพิกเซลเสมอ
- **Repeated images** ควรใช้ทรัพยากร **PPImage** ที่มีอยู่แล้วเมื่อทำได้ แทนการโหลดไฟล์เดียวกันหลายครั้งในเวิร์กโฟลว์พรีเซนเทชัน

สำหรับพรีเซนเทชันขนาดใหญ่, การปรับแต่งภาพมักจะมีประสิทธิภาพมากที่สุดเมื่อทำแบบเลือกเฉพาะ: เก็บโลโก้และแผนภาพเป็นเนื้อหาเวกเตอร์, บีบอัดภาพถ่ายตามขนาดแสดงจริง, ลบพิกเซลที่ครอบเมื่อไม่ต้องการแก้ไขต่อ, และหลีกเลี่ยงลิงก์ภายนอกหากไม่เป็นส่วนหนึ่งของการจัดการการพึ่งพาในการปรับใช้

## **คำถามที่พบบ่อย**

**ภาพ picture frame แตกต่างจากทรัพยากรภาพอย่างไร?**

**PPImage**(https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ppimage/) แทนทรัพยากรภาพที่เชื่อมโยงกับพรีเซนเทชัน **PictureFrame**(https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pictureframe/) คือรูปร่างบนสไลด์ที่แสดงภาพและจัดเก็บรูปทรงระดับเฟรมและการจัดรูปแบบ เช่น ขนาด, การหมุน, ค่าการครอบ, เอฟเฟกต์, และการล็อก

**ควรฝังหรือเชื่อมโยงภาพ?**

ฝังภาพเมื่อพรีเซนเทชันต้องการความพกพา, การเก็บเป็นแฟ้มเก่า, หรือการเรนเดอร์โดยไม่ต้องอ้างอิงทรัพยากรภายนอก; เชื่อมโยงภาพเฉพาะเมื่อต้องการเก็บไฟล์ภาพแยกจาก PPTX อย่างตั้งใจและสามารถรักษาตำแหน่งภายนอกได้อย่างน่าเชื่อถือ

**การครอบลดขนาดไฟล์ PPTX หรือไม่?**

ไม่โดยตรง การตั้งค่าการครอบปกติซ่อนส่วนของภาพต้นฉบับแต่ยังคงเก็บพิกเซลอยู่ ใช้ **PictureFillFormat.deletePictureCroppedAreas**(https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) หรือบีบอัดภาพพร้อมการลบพื้นที่ที่ครอบเมื่อพิกเซลนั้นสามารถลบทิ้งได้โดยถาวร

**สามารถกู้คืนคุณภาพภาพหลังจากบีบอัดได้หรือไม่?**

ไม่ได้ การบีบอัดอาจลดความละเอียดแรสเตอร์ที่จัดเก็บ, และการลบพื้นที่ที่ครอบจะทิ้งข้อมูลภาพออกไป ควรเก็บภาพต้นฉบับแยกไว้หากอาจต้องแก้ไขความละเอียดสูงในภายหลัง

**ควรจัดการกับภาพ SVG อย่างไร?**

เก็บเนื้อหา SVG เป็น SVG เมื่อความแม่นยำของเวกเตอร์สำคัญ; **SvgImage**(https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/svgimage/) ที่ฝังไว้สามารถสกัดได้โดยตรง การเรนเดอร์สไลด์เป็นรูปแบบแรสเตอร์เช่น PNG หรือ JPEG จะทำให้ SVG แรสเตอร์เป็นส่วนของภาพสไลด์

**จะหลีกเลี่ยงการแคสท์ที่ไม่ปลอดภัยเมื่ออ่านสไลด์ที่มีอยู่ได้อย่างไร?**

ตรวจสอบประเภทของ shape ก่อนใช้สมาชิกเฉพาะ picture‑frame การตรวจสอบ `java.instanceOf` ต่อ **PictureFrame**(https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pictureframe/) จะหลีกเลี่ยงการแคสท์ที่ไม่ถูกต้องและให้โค้ดจัดการสไลด์ที่ไม่มี picture frame ได้อย่างเหมาะสม