---
title: จัดการ Picture Frame ในงานนำเสนอโดยใช้ JavaScript
linktitle: กรอบรูป
type: docs
weight: 10
url: /th/nodejs-java/picture-frame/
keywords:
- กรอบรูป
- เพิ่มกรอบรูป
- สร้างกรอบรูป
- ภาพฝัง
- ภาพเชื่อมโยง
- สกัดภาพ
- ภาพแรสเตอร์
- ภาพ SVG
- ครอบภาพ
- ลบพื้นที่ที่ครอบ
- บีบอัดภาพ
- StretchOffset
- การจัดรูปแบบกรอบรูป
- สเกลสัมพัทธ์
- เอฟเฟกต์ภาพ
- อัตราส่วนภาพ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "สร้าง, จัดรูปแบบ, เชื่อมโยง, ครอบ, สกัด, และบีบอัดกรอบรูปในงานนำเสนอด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java."
---
## **ภาพรวม**

PictureFrame คือรูปทรงสไลด์ที่แสดงภาพ ใน Aspose.Slides, แหล่งข้อมูลภาพและรูปทรงที่แสดงภาพเป็นอ็อบเจกต์แยกกัน: a [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) มีแหล่งข้อมูลภาพฝังอยู่ผ่าน [ImageCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/imagecollection/), ในขณะที่ [PictureFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pictureframe/) ควบคุมตำแหน่งของภาพ, ขนาด, การจัดรูปแบบเส้น, การหมุน, การครอป, เอฟเฟกต์ภาพ, และการตั้งค่าระดับเฟรมอื่น ๆ

การแยกนี้มีประโยชน์เมื่อภาพเดียวกันต้องแสดงหลายครั้ง เพิ่มภาพลงในงานนำเสนอเพียงครั้งเดียว, เก็บ [PPImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ppimage/) ที่คืนค่า, แล้วใช้แหล่งข้อมูลภาพนั้นเมื่อต้องสร้าง PictureFrame

PictureFrame สามารถบรรจุภาพแรสเตอร์เช่น PNG หรือ JPEG และภาพเวกเตอร์ SVG ได้ ทั้งนี้ยังสามารถอ้างอิงภาพที่เชื่อมโยง (linked) แทนการเก็บไบต์ของภาพไว้ในงานนำเสนอ ตัวเลือกนี้ส่งผลต่อความพกพา, ขนาดไฟล์, การสกัดข้อมูล, และพฤติกรรมการส่งออก ดังนั้นควรตัดสินใจว่าภาพจะถูกเก็บอย่างไรก่อนทำการจัดรูปแบบหรือปรับแต่ง

## **เพิ่มและจัดรูปแบบภาพฝัง**

สำหรับภาพฝัง, ให้เพิ่มข้อมูลภาพลงในงานนำเสนอและสร้าง PictureFrame ด้วย [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shapecollection/#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) ภาพจะกลายเป็นส่วนหนึ่งของแพ็กเกจงานนำเสนอ ทำให้งานนำเสนอยังคงเป็นไฟล์เดียวเมื่อย้ายไปยังคอมพิวเตอร์เครื่องอื่น

ตัวอย่างต่อไปนี้เพิ่มภาพ PNG, สร้างเฟรมที่มีขนาดตามมิติเดิมของภาพ, และใช้การจัดรูปแบบเส้นและการหมุน:

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

PictureFrame ควบคุมเรขาคณิตที่แสดง; การเปลี่ยนขนาดเฟรมไม่ได้เปลี่ยนมิติกระทุกรูปพิกเซลที่เก็บในแหล่งข้อมูลภาพฝัง ความแตกต่างนี้สำคัญเมื่อทำการครอปหรือบีบอัดภาพในภายหลัง

## **ใช้สเกลสัมพัทธ์**

[PictureFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pictureframe/) เปิดเผยการสเกลความกว้างและความสูงแบบสัมพัทธ์สำหรับเฟรมผ่าน [setRelativeScaleWidth](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleWidth-float-) และ [setRelativeScaleHeight](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleHeight-float-) ค่าที่ `1.0` หมายถึง 100% ของขนาดภาพเดิม สเกลสัมพัทธ์มีประโยชน์เมื่อเวิร์กโฟลว์ต้องคงอัตราส่วนต่อขนาดภาพต้นทางแทนการคำนวณขนาดสุดท้ายด้วยตนเอง

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

สเกลสัมพัทธ์เปลี่ยนการตั้งค่าสเกลของเฟรม; มันไม่ทำการรีแซมพลิงหรือบีบอัดภาพฝัง

## **ภาพฝังและภาพเชื่อมโยง**

ภาพฝังจะเก็บข้อมูลภาพไว้ภายในงานนำเสนอ จึงเป็นตัวเลือกที่ปลอดภัยที่สุดสำหรับความพกพาและการเรนเดอร์ที่คาดเดาได้ ภาพเชื่อมโยงจะเก็บตำแหน่งภายนอกผ่านเมธอด [Picture.setLinkPathLong](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picture/#setLinkPathLong-java.lang.String-) แทนการฝังข้อมูลภาพในลักษณะเดียวกัน

ภาพเชื่อมโยงสามารถลดปริมาณข้อมูลภาพที่เก็บใน PPTX ได้ แต่ก็เพิ่มการพึ่งพิงภายนอก ไฟล์ที่เชื่อมโยงต้องยังคงเข้าถึงได้สำหรับแอปพลิเคชันที่เปิดหรือเรนเดอร์งานนำเสนอ หากเส้นทางเปลี่ยน, ไฟล์ถูกย้าย, หรือแหล่งข้อมูลไม่พร้อมใช้งาน, ภาพเชื่อมโยงอาจไม่แสดงตามคาด สำหรับงานนำเสนอที่ต้องส่งอีเมล, เก็บเป็นที่เก็บถาวร, หรือเรนเดอร์ในสภาพแวดล้อมแยก, ภาพฝังมักจะเชื่อถือได้มากกว่า

### **เพิ่มภาพเชื่อมโยง**

ตัวอย่างต่อไปนี้สร้าง PictureFrame และชี้ไปที่ไฟล์ภาพในเครื่อง มุ่งเน้นที่การเชื่อมโยงภาพเท่านั้น; การเชื่อมโยงวิดีโอเป็นเวิร์กโฟลว์สื่อแยกต่างหากและไม่ได้ผสมเข้ากับตัวอย่างนี้

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

ใช้การเชื่อมโยงเมื่อการจัดการไฟล์ภายนอกเป็นเจตนา อย่าใช้เป็นตัวแทนการบีบอัด: PPTX เล็กที่มีการเชื่อมโยงภาพเสียหายมักจะใช้งานได้น้อยกว่า งานนำเสนอขนาดใหญ่ที่เป็นไฟล์เดียว

## **สกัดภาพจาก PictureFrame**

ก่อนสกัดภาพจากงานนำเสนอที่มีอยู่, ตรวจสอบให้แน่ใจว่า Shape นั้นเป็น [PictureFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pictureframe/) จริงและมีภาพฝังอยู่ PictureFrame ที่เชื่อมโยงอาจไม่มีไบต์ภาพที่สกัดได้แบบเดียวกัน

### **สกัดภาพแรสเตอร์**

API ภาพสมัยใหม่ใช้ [IImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/iimage/) โดยตรง ตัวอย่างต่อไปนี้ค้นหาภาพแรสเตอร์ฝังตัวแรกบนสไลด์และบันทึกเป็น PNG:

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

การบันทึกผ่าน [IImage.save](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/iimage/#save) จะแปลงภาพที่สกัดเป็นรูปแบบเอาต์พุตที่ร้องขอ หากต้องการไบต์ที่เข้ารหัสเก็บไว้ในงานนำเสนอแทนไฟล์แรสเตอร์ที่แปลงแล้ว, ให้ใช้ข้อมูลไบต์ของแหล่งภาพโดยตรง

### **สกัดภาพ SVG**

สำหรับภาพ SVG, [PPImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ppimage/) เปิดเผยอ็อบเจกต์ [SvgImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/svgimage/) ทำให้คุณสามารถดึงข้อมูล SVG โดยตรงแทนการเรซอลูชั่นภาพก่อน

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

การเก็บเนื้อหา SVG เป็น SVG จะคงแหล่งเวกเตอร์ไว้ในงานนำเสนอ การส่งออกเป็นแรสเตอร์เช่น PNG หรือ JPEG จะต้องเรนเดอร์เวกเตอร์เป็นพิกเซล การส่งออกสไลด์เป็น PDF หรือ SVG ก็เป็นการเรนเดอร์เช่นกัน ดังนั้นกราฟิกที่ส่งออกไม่ควรถูกมองว่าเป็นสำเนาไบต์ต่อไบต์ของ SVG ฝังเดิม; ใช้ข้อมูลจาก [SvgImage.getSvgData](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/svgimage/#getSvgData--) เมื่อต้องการแหล่งเวกเตอร์ต้นฉบับ

## **ครอบภาพ**

การครอบเปลี่ยนส่วนที่มองเห็นของภาพภายในเฟรม ค่าการครอบบน [PictureFillFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picturefillformat/) เป็นเปอร์เซ็นต์ของมิติภาพต้นทาง การครอบไม่ลบพิกเซลที่ซ่อนอยู่จากภาพฝัง; เพียงเปลี่ยนพื้นที่ที่มองเห็น

ตัวอย่างต่อไปนี้ค้นหา PictureFrame อย่างปลอดภัยและใช้ค่าการครอบ:

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

เนื่องจากข้อมูลภาพที่ซ่อนอยู่นายยังคงอยู่ การครอบสามารถเปลี่ยนแปลงได้ภายหลังโดยไม่สูญเสียพิกเซลต้นฉบับ หากขนาดไฟล์เป็นข้อพิจารณามากกว่าความสามารถในการย้อนกลับ, พื้นที่ที่ครอบสามารถลบออกได้ตามที่อธิบายในส่วนต่อไป

## **ลบข้อมูลภาพที่ครอบไว้**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) จะลบข้อมูลภาพที่อยู่นอกสี่เหลี่ยมการครอบปัจจุบันและคืนแหล่งภาพที่ได้ ผลลัพธ์นี้สามารถลดขนาดไฟล์ได้ แต่เป็นการปรับแต่งทำลาย: หลังจากบันทึกงานนำเสนอ พิกเซลที่ลบจะไม่สามารถกู้คืนเพื่อทำการ Uncrop ได้อีก

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

เมธอดอาจเพิ่มแหล่งภาพใหม่เข้าไปในงานนำเสนอ หากภาพต้นฉบับยังถูกใช้โดย PictureFrame อื่น ๆ, เฟรมเหล่านั้นยังต้องการแหล่งเดิม ดังนั้นการลบพื้นที่ที่ครอบไว้ไม่ได้จำเป็นต้องลดจำนวนภาพทั้งหมด การครอบ WMF หรือ EMF ด้วยเมธอดนี้จะทำให้ผลลัพธ์ที่ครอบเป็น PNG

## **บีบอัดภาพแรสเตอร์**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) ลดความละเอียดของภาพแรสเตอร์สัมพันธ์กับขนาดที่ภาพแสดง นอกจากนี้ยังสามารถลบพื้นที่ที่ครอบไว้ในขั้นตอนเดียว เมธอดคืนค่า `true` เมื่อภาพถูกปรับขนาดหรือครอบ และ `false` เมื่อไม่มีการเปลี่ยนแปลงใด ๆ

ใช้ค่าที่กำหนดไว้ล่วงหน้าใน [PicturesCompression](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picturescompression/) เมื่อความละเอียดเป้าหมายมาตรฐานเพียงพอ:

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

สามารถส่งค่าความละเอียด DPI บวกแบบกำหนดเองแทนค่าที่กำหนดไว้เมื่อจำเป็นต้องมีเป้าหมายเฉพาะ

การบีบอัดนี้มุ่งเน้นที่ภาพแรสเตอร์ ไม่ได้ลดขนาด SVG หรือเมทาฟายล์ การลดความละเอียดและการลบพื้นที่ที่ครอบไว้ไม่สามารถกู้คืนจากงานนำเสนอที่ปรับแล้วได้ เลือกความละเอียดเป้าหมายโดยอิงจากขนาดสูงสุดที่ภาพจะถูกมองหรือส่งออกจริง แทนการใช้ DPI ต่ำที่สุดทั่วทั้งไฟล์

## **จัดการเอฟเฟกต์การแปลงภาพ**

สำหรับเวิร์กโฟลว์ครบถ้วนที่ครอบคลุมความสว่าง, คอนทราสต์, การแปลงสี, เบลอ, เอฟเฟกต์อัลฟา, เชนสั่ง, การตรวจสอบ, การลบ, และการตรวจสอบรอบเดียว, ดูที่ [Image Transform Effects](/slides/th/nodejs-java/image-transform-effects/)

## **ล็อกเรขาคณิตของ PictureFrame**

การตั้งค่า [PictureFrameLock](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pictureframelock/) ควบคุมว่าการดำเนินการแก้ไขใดบ้างที่ถูกปิดใช้งานสำหรับ PictureFrame ตัวอย่างเช่น [setAspectRatioLocked](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) จะรักษาสัดส่วนของรูปทรงขณะปรับขนาด

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

การล็อกนี้ใช้กับรูปทรง PictureFrame ไม่ได้บังคับให้ภาพต้นฉบับต้องรีแซมพลิงหรือเปลี่ยนสัดส่วนอย่างถาวร

## **ปรับค่า StretchOffset**

เมื่อโหมดการเติมภาพเป็น stretch, ค่าการ offset การยืดบน [PictureFillFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picturefillformat/) จะกำหนดสี่เหลี่ยมเติมสัมพันธ์กับกล่องขอบของ PictureFrame ค่าเปอร์เซ็นต์บวกสร้างการ inset จากขอบ, ส่วนค่าเปอร์เซ็นต์ลบสร้างการ outset

สิ่งนี้แตกต่างจากการครอป ค่าการครอปเลือกส่วนของภาพต้นทางที่จะแสดง; ส่วน stretch offset เปลี่ยนสี่เหลี่ยมที่ภาพเติมที่มองเห็นถูกยืดออก

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

ใช้ stretch offset สำหรับการวางตำแหน่งการเติม ใช้ค่าการครอปเมื่อเป้าหมายคือซ่อนขอบของภาพต้นทาง

## **ข้อพิจารณาด้านการจัดเก็บ, ขนาดไฟล์, และการส่งออก**

การตัดสินใจหลักจะจัดการได้ง่ายขึ้นเมื่อการจัดเก็บภาพและการจัดรูปแบบ PictureFrame แยกกัน:

- **Embedded images** ทำให้งานนำเสนอเป็นไฟล์เดียวและเป็นตัวเลือกที่เชื่อถือได้ที่สุดสำหรับการแชร์และการเรนเดอร์บนเซิร์ฟเวอร์ แต่ภาพแรสเตอร์ขนาดใหญ่ทำให้ PPTX พื้นที่เก็บและการใช้หน่วยความจำเพิ่มขึ้น
- **Linked images** ช่วยให้แพ็กเกจเล็กลง, แต่งานนำเสนอพึ่งพาไฟล์ภายนอกที่ต้องยังคงเข้าถึงได้ตามเส้นทางหรือที่ตั้งที่บันทึกไว้
- **Cropping** เริ่มต้นเป็นแบบไม่ทำลาย; พิกเซลที่ซ่อนอยู่ยังคงฝังอยู่จนกว่าจะลบพื้นที่ที่ครอบโดยชัดเจนหรือระหว่างการบีบอัด
- **Compression** สามารถลดขนาดไฟล์ได้อย่างมีนัยสำคัญสำหรับภาพแรสเตอร์ขนาดเกิน, แต่จะสูญเสียความละเอียดต้นทาง ควรทำหลังจากที่รู้ขนาดบนสไลด์ที่ต้องการแล้ว
- **SVG images** ควรคงเป็น SVG เมื่อสำคัญต่อการรักษาเวกเตอร์ สกัด SVG ฝังโดยตรงเมื่อต้องการแหล่งเวกเตอร์เอง การส่งออกสไลด์เป็นแรสเตอร์จะเปลี่ยนสไลด์ที่เรนเดอร์เป็นพิกเซลเสมอ
- **Repeated images** ควรใช้แหล่ง [PPImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ppimage/) ที่มีอยู่แล้วเมื่อเป็นไปได้ แทนการโหลดไฟล์เดียวกันหลายครั้งในเวิร์กโฟลว์งานนำเสนอ

สำหรับงานนำเสนอขนาดใหญ่ การปรับแต่งภาพมักให้ผลดีที่สุดเมื่อทำแบบเลือกเฉพาะ: เก็บโลโก้และไดอะแกรมเป็นเนื้อหาเวกเตอร์, บีบอัดภาพถ่ายตามขนาดการแสดงจริง, ลบพิกเซลที่ครอบเมื่อไม่มีการแก้ไขต่อในอนาคต, และหลีกเลี่ยงลิงก์ภายนอกหากการจัดการการพึ่งพิงไม่ใช่ส่วนหนึ่งของการออกแบบการปรับใช้

## **FAQ**

**ความแตกต่างระหว่าง PictureFrame กับแหล่งข้อมูลภาพคืออะไร?**

[PPImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ppimage/) แทนแหล่งข้อมูลภาพที่เชื่อมโยงกับงานนำเสนอ ส่วน [PictureFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pictureframe/) เป็นรูปทรงบนสไลด์ที่แสดงภาพและเก็บเรขาคณิตระดับเฟรมรวมถึงการจัดรูปแบบเช่น ขนาด, การหมุน, ค่าครอป, เอฟเฟกต์, และการล็อก

**ควรฝังหรือเชื่อมโยงภาพ?**

ฝังภาพเมื่อจำเป็นต้องให้งานนำเสนอสามารถพกพา, เก็บเป็นที่เก็บถาวร, หรือเรนเดอร์โดยไม่ต้องอ้างอิงแหล่งภายนอก เชื่อมโยงภาพเฉพาะเมื่อต้องการเก็บไฟล์ภาพอยู่นอก PPTX อย่างตั้งใจและสามารถรักษาตำแหน่งภายนอกได้อย่างเชื่อถือได้

**การครอปทำให้ขนาดไฟล์ PPTX ลดลงหรือไม่?**

ไม่โดยตรง การตั้งค่าครอปธรรมดาจะซ่อนส่วนของภาพต้นทางแต่ยังคงเก็บพิกเซลอยู่ ใช้ [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) หรือบีบอัดภาพพร้อมการลบพื้นที่ที่ครอบเมื่อพิกเซลเหล่านั้นสามารถทิ้งได้อย่างถาวร

**สามารถคืนคุณภาพภาพหลังบีบอัดได้หรือไม่?**

ไม่ได้ การบีบอัดอาจลดความละเอียดแรสเตอร์ที่เก็บไว้, และการลบพื้นที่ที่ครอบจะทำให้ข้อมูลภาพหายไป หากอาจต้องแก้ไขภาพด้วยความละเอียดสูงในภายหลัง, ควรเก็บภาพต้นฉบับอยู่นอกงานนำเสนอ

**ควรจัดการกับภาพ SVG อย่างไร?**

เก็บเนื้อหา SVG เป็น SVG เมื่อความถูกต้องของเวกเตอร์สำคัญ สามารถสกัด [SvgImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/svgimage/) ฝังได้โดยตรง การเรนเดอร์สไลด์เป็นรูปแรสเตอร์เช่น PNG หรือ JPEG จะทำให้ SVG ถูก rasterize เป็นพิกเซล

**ทำอย่างไรจึงจะหลีกเลี่ยงการแคสต์ที่ไม่ปลอดภัยเมื่ออ่านสไลด์ที่มีอยู่?**

ตรวจสอบประเภทของ Shape ก่อนใช้สมาชิกเฉพาะ PictureFrame การตรวจสอบ `java.instanceOf` กับ [PictureFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pictureframe/) จะช่วยหลีกเลี่ยงการแคสต์ที่ไม่ถูกต้องและทำให้โค้ดจัดการสไลด์ที่ไม่มี PictureFrame ได้อย่างเหมาะสม