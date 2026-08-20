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
- รูปภาพฝัง
- รูปภาพเชื่อมโยง
- ดึงรูปภาพ
- รูปภาพเรสเตอร์
- รูปภาพ SVG
- ครอบรูปภาพ
- ลบพื้นที่ที่ถูกครอบ
- บีบอัดรูปภาพ
- การยืดออฟเซ็ต
- การจัดรูปแบบกรอบรูปภาพ
- สเกลสัมพัทธ์
- เอฟเฟกต์รูปภาพ
- อัตราส่วนภาพ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "สร้าง, จัดรูปแบบ, เชื่อมโยง, ครอบ, ดึง, และบีบอัดกรอบรูปภาพในงานนำเสนอด้วย Aspose.Slides สำหรับ Node.js ผ่าน JavaScript."
---
## **ภาพรวม**

กรอบภาพเป็นรูปร่างบนสไลด์ที่แสดงรูปภาพ ใน Aspose.Slides, แหล่งข้อมูลรูปภาพและรูปร่างที่แสดงรูปนั้นเป็นออบเจกต์แยกกัน: a [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) owns embedded image resources through its [ImageCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/imagecollection/), while a [PictureFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pictureframe/) controls the image's position, size, line formatting, rotation, cropping, picture effects, and other frame-level settings.

การแยกนี้เป็นประโยชน์เมื่อรูปเดียวกันถูกแสดงหลายครั้ง เพิ่มรูปภาพเข้าไปในงานนำเสนอเพียงครั้งเดียว เก็บ [PPImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ppimage/) ที่ส่งคืน และใช้แหล่งข้อมูลรูปภาพนั้นเมื่อสร้างกรอบภาพ.

กรอบภาพสามารถบรรจุรูปภาพเรสเตอร์เช่น PNG หรือ JPEG และรูปเวกเตอร์ SVG ได้ ทั้งนี้ยังสามารถอ้างอิงรูปภาพที่เชื่อมโยงแทนการเก็บไบต์รูปภาพในงานนำเสนอ ตัวเลือกนี้ส่งผลต่อการพกพา ขนาดไฟล์ การดึงข้อมูล และพฤติกรรมการส่งออก จึงควรตัดสินใจว่ารูปภาพจะจัดเก็บอย่างไรก่อนนำไปจัดรูปแบบหรือทำให้เหมาะสม.

## **เพิ่มและจัดรูปแบบรูปภาพฝัง**

สำหรับรูปภาพฝัง ให้นำข้อมูลรูปภาพเพิ่มเข้าไปในงานนำเสนอและสร้างกรอบภาพด้วย [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shapecollection/#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-). รูปภาพจะกลายเป็นส่วนหนึ่งของแพ็กเกจงานนำเสนอ ทำให้งานนำเสนอยังคงเป็นแบบอิสระเมื่อย้ายไปยังคอมพิวเตอร์เครื่องอื่น.

ตัวอย่างต่อไปนี้เพิ่มรูป PNG สร้างกรอบที่มีขนาดตามมิติเดิมของรูปภาพ และใช้การจัดรูปแบบเส้นและการหมุน:

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

กรอบภาพควบคุมเรขาคณิตที่แสดง; การเปลี่ยนขนาดกรอบไม่ได้เปลี่ยนมิติพิกเซลเดิมที่เก็บในแหล่งข้อมูลรูปภาพฝัง ความแตกต่างนี้สำคัญเมื่อทำการครอบหรือบีบอัดรูปภาพในภายหลัง.

## **ใช้สเกลสัมพัทธ์**

[PictureFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pictureframe/) เปิดเผยการสเกลความกว้างและความสูงสัมพัทธ์สำหรับกรอบผ่าน [setRelativeScaleWidth](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleWidth-float-) และ [setRelativeScaleHeight](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleHeight-float-). ค่า `1.0` หมายถึง 100% ของขนาดภาพต้นฉบับ สเกลสัมพัทธ์มีประโยชน์เมื่อขั้นตอนการทำงานต้องคงความสัมพันธ์กับขนาดภาพต้นฉบับแทนการคำนวณมิติสุดท้ายด้วยตนเอง.

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

สเกลสัมพัทธ์เปลี่ยนการตั้งค่าขนาดของกรอบ; ไม่ทำการรีแซมเพิลหรือบีบอัดรูปภาพฝัง.

## **รูปภาพฝังและเชื่อมโยง**

รูปภาพฝังจะเก็บข้อมูลรูปภาพภายในงานนำเสนอ จึงเป็นตัวเลือกที่ปลอดภัยที่สุดสำหรับการพกพาและการเรนเดอร์ที่คาดเดาได้ รูปภาพเชื่อมโยงจะเก็บตำแหน่งภายนอกผ่านเมธอด [Picture.setLinkPathLong](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picture/#setLinkPathLong-java.lang.String-) แทนการฝังข้อมูลรูปภาพในลักษณะเดียวกัน.

รูปภาพเชื่อมโยงสามารถลดปริมาณข้อมูลรูปภาพที่เก็บใน PPTX ได้ แต่ก็ทำให้เกิดการพึ่งพาไฟล์ภายนอก ไฟล์ที่เชื่อมโยงต้องยังคงสามารถเข้าถึงได้สำหรับแอปพลิเคชันที่เปิดหรือเรนเดอร์งานนำเสนอ หากเส้นทางเปลี่ยนแปลง ไฟล์ย้ายตำแหน่ง หรือแหล่งข้อมูลไม่พร้อมใช้งาน รูปภาพเชื่อมโยงอาจไม่แสดงตามที่คาดไว้ สำหรับงานนำเสนอที่ต้องส่งอีเมล เก็บเป็นไฟล์เก่า หรือเรนเดอร์ในสภาพแวดล้อมแยก, รูปภาพฝังมักจะเชื่อถือได้มากกว่า.

### **เพิ่มรูปภาพเชื่อมโยง**

ตัวอย่างต่อไปนี้สร้างกรอบภาพและชี้ไปที่ไฟล์รูปภาพในเครื่อง โดยจัดการเฉพาะการเชื่อมโยงรูปภาพ; การเชื่อมโยงวิดีโอเป็นขั้นตอนสื่อแยกต่างหากและไม่ได้รวมไว้ในตัวอย่างนี้โดยเจตนา.

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

ใช้ลิงก์เมื่อการจัดการไฟล์ภายนอกเป็นเจตนา อย่าใช้ลิงก์เป็นเพียงการทดแทนการบีบอัด: PPTX ขนาดเล็กที่มีการพึ่งพาภาพเสียบกพร่องมักจะใช้งานได้น้อยกว่างานนำเสนอขนาดใหญ่ที่เป็นอิสระ.

## **ดึงรูปภาพจากกรอบภาพ**

ก่อนดึงรูปภาพจากงานนำเสนอที่มีอยู่ ควรตรวจสอบว่ารูปร่างเป็น [PictureFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pictureframe/) จริงและว่ามีรูปภาพฝังอยู่หรือไม่ กรอบภาพเชื่อมโยงอาจไม่มีไบต์รูปภาพที่สามารถดึงได้ในรูปแบบเดียวกัน.

### **ดึงรูปเรสเตอร์**

API รูปภาพสมัยใหม่ใช้ [IImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/iimage/) โดยตรง ตัวอย่างต่อไปนี้ค้นหารูปเรสเตอร์ฝังแรกบนสไลด์และบันทึกเป็น PNG:

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

การบันทึกผ่าน [IImage.save](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/iimage/#save) จะเปลี่ยนรูปที่ดึงมาเป็นรูปแบบเอาต์พุตที่ร้องขอ หากต้องการไบต์ที่เข้ารหัสเก็บไว้ในงานนำเสนอแทนไฟล์เรสเตอร์ที่แปลงแล้ว ให้ใช้ข้อมูลไบต์ของแหล่งข้อมูลรูปภาพแทน.

### **ดึงรูป SVG**

สำหรับรูป SVG, [PPImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ppimage/) ให้เข้าถึงอ็อบเจ็กต์ [SvgImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/svgimage/) ซึ่งทำให้คุณสามารถดึงข้อมูล SVG โดยตรงโดยไม่ต้องแรสเตอร์รูปภาพก่อน.

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

การเก็บเนื้อหา SVG เป็น SVG จะรักษาแหล่งเวกเตอร์ภายในงานนำเสนอ การส่งออกแบบเรสเตอร์เช่น PNG หรือ JPEG จะต้องเรนเดอร์เนื้อหาเวกเตอร์เป็นพิกเซล การส่งออกสไลด์เป็น PDF หรือ SVG ก็เป็นการเรนเดอร์เช่นกัน ดังนั้นกราฟิกที่ส่งออกไม่ควรถือว่าเป็นสำเนาไบต์ต่อไบต์ของ SVG ฝังต้นฉบับ; ให้ใช้ข้อมูล [SvgImage.getSvgData](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/svgimage/#getSvgData--) ที่ฝังอยู่เมื่อจำเป็นต้องใช้ทรัพยากรเวกเตอร์ต้นฉบับ.

## **ครอบรูปภาพ**

การครอบจะเปลี่ยนส่วนของรูปภาพที่มองเห็นในกรอบ ค่าเพรเซ็นต์การครอบบน [PictureFillFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picturefillformat/) เป็นเปอร์เซ็นต์ของมิติภาพต้นฉบับ การครอบไม่ได้ลบพิกเซลที่ซ่อนอยู่จากรูปภาพฝังตั้งแต่แรก; เพียงเปลี่ยนบริเวณที่มองเห็น.

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

เนื่องจากข้อมูลรูปภาพที่ซ่อนยังคงอยู่ การครอบสามารถเปลี่ยนได้ในภายหลังโดยไม่สูญเสียพิกเซลต้นฉบับ หากขนาดไฟล์สำคัญกว่า ความสามารถย้อนกลับ, พื้นที่ที่ครอบสามารถลบออกจริง ๆ ตามที่อธิบายในส่วนต่อไป.

## **ลบข้อมูลรูปภาพที่ถูกครอบ**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) จะลบข้อมูลรูปภาพที่อยู่นอกสี่เหลี่ยมครอบปัจจุบันและคืนค่าแหล่งข้อมูลรูปภาพที่ได้ การทำเช่นนี้สามารถลดขนาดไฟล์ แต่เป็นการเพิ่มประสิทธิภาพแบบทำลาย: หลังจากบันทึกงานนำเสนอ พิกเซลที่ลบจะไม่สามารถนำกลับมาครอบใหม่ได้อีก.

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

เมธอดนี้อาจเพิ่มแหล่งข้อมูลรูปภาพใหม่เข้าไปในงานนำเสนอ หากรูปภาพต้นฉบับถูกใช้โดยกรอบภาพอื่น ๆ กรอบเหล่านั้นยังคงต้องการแหล่งข้อมูลเดิม ดังนั้นการลบพื้นที่ที่ครอบไม่ได้จำเป็นต้องลดจำนวนรูปภาพทั้งหมด การครอบเนื้อหา WMF หรือ EMF ด้วยเมธอดนี้จะทำให้ผลลัพธ์ที่ครอบแรสเตอร์เป็น PNG.

## **บีบอัดรูปเรสเตอร์**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) ลดความละเอียดของรูปเรสเตอร์สัมพันธ์กับขนาดที่รูปแสดง สามารถลบพื้นที่ที่ครอบได้ในขั้นตอนเดียว เมธอดจะคืนค่า `true` เมื่อรูปภาพถูกปรับขนาดหรือครอบ และ `false` เมื่อไม่จำเป็นต้องเปลี่ยนแปลง.

ใช้ค่า [PicturesCompression](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picturescompression/) ที่กำหนดล่วงหน้าเมื่อความละเอียดเป้าหมายมาตรฐานเพียงพอ:

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

สามารถส่งค่า DPI บวกที่กำหนดเองแทนค่าเดิมเมื่อจำเป็นต้องมีเป้าหมายเฉพาะ.

การบีบอัดมุ่งเน้นที่รูปเรสเตอร์ SVG และเนื้อหาเมตาไฟล์จะไม่ถูกลดโดยขั้นตอนบีบอัดเรสเตอร์นี้ นอกจากนี้ควรจำว่าความละเอียดที่ต่ำลงและพื้นที่ที่ลบจะไม่สามารถกู้คืนจากงานนำเสนอที่ปรับแล้ว เลือกความละเอียดเป้าหมายตามขนาดสูงสุดที่รูปภาพจะถูกมองหรือส่งออกจริง แทนการใช้ DPI ต่ำสุดทั่วทั้งไฟล์.

## **ตรวจสอบเอฟเฟกต์รูปภาพ**

เอฟเฟกต์ของรูปภาพถูกเก็บบนรูปที่ใช้โดยกรอบ คอลเลกชันการแปลงรูปภาพอาจมีเอฟเฟกต์เช่นการปรับค่าตามอัลฟ่าแบบคงที่สำหรับความโปร่งใสและการปรับความสว่างสำหรับความสว่างและความคมชัด ตัวอย่างด้านล่างอ่านเอฟเฟกต์ทั้งสองประเภทจากกรอบภาพแรกบนสไลด์อย่างปลอดภัย:

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
        const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        for (let i = 0; i < imageTransform.size(); i++) {
            const effect = imageTransform.get_Item(i);
            if (java.instanceOf(effect, "com.aspose.slides.IAlphaModulateFixed")) {
                const transparency = 100 - effect.getAmount();
                console.log("Transparency: " + transparency);
            }

            if (java.instanceOf(effect, "com.aspose.slides.ILuminance")) {
                const luminance = effect.getEffective();
                console.log("Brightness: " + luminance.getBrightness());
                console.log("Contrast: " + luminance.getContrast());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

เอฟเฟกต์เหล่านี้เปลี่ยนวิธีการเรนเดอร์รูปภาพในกรอบ; ไม่ได้เขียนทับไบต์รูปภาพฝังต้นฉบับ.

## **ล็อกเรขาคณิตกรอบภาพ**

การตั้งค่า [PictureFrameLock](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pictureframelock/) ควบคุมว่าการแก้ไขใดจะถูกปิดใช้งานสำหรับกรอบภาพ ตัวอย่างเช่น [setAspectRatioLocked](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) จะคงสัดส่วนของรูปร่างขณะปรับขนาด.

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

การล็อกนี้ใช้กับรูปร่างกรอบภาพ ไม่บังคับให้รูปภาพต้นฉบับต้องรีแซมเพิลหรือเปลี่ยนสัดส่วนแบบถาวร.

## **ปรับค่า StretchOffset**

เมื่อโหมดเติมรูปภาพเป็น stretch, ค่า stretch-offset บน [PictureFillFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picturefillformat/) จะกำหนดสี่เหลี่ยมเติมสัมพันธ์กับกล่องขอบของกรอบภาพ ค่าเปอร์เซ็นต์บวกจะสร้างการย่อจากขอบ, ส่วนค่าเปอร์เซ็นต์ลบจะสร้างการขยายออก.

นี่แตกต่างจากการครอบ ค่าการครอบเลือกส่วนของภาพต้นฉบับที่จะแสดง; stretch offset จะเปลี่ยนสี่เหลี่ยมที่ภาพเติมที่มองเห็นถูกยืด.

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

ใช้ stretch offset เพื่อกำหนดตำแหน่งการเติม ใช้คุณสมบัติการครอบเมื่อต้องการซ่อนขอบภาพต้นฉบับ.

## **การจัดเก็บ, ขนาดไฟล์, และการพิจารณาการส่งออก**

การแลกเปลี่ยนหลักจะจัดการได้ง่ายขึ้นเมื่อการจัดเก็บรูปภาพและการจัดรูปแบบกรอบภาพแยกกัน:

- **รูปภาพฝัง** ทำให้งานนำเสนอเป็นอิสระและเป็นที่เชื่อถือที่สุดสำหรับการแชร์และการเรนเดอร์บนเซิร์ฟเวอร์, แต่รูปเรสเตอร์ขนาดใหญ่จะเพิ่มขนาด PPTX และการใช้หน่วยความจำ.
- **รูปภาพเชื่อมโยง** สามารถทำให้แพคเกจมีขนาดเล็กลง, แต่งานนำเสนอจะพึ่งพาไฟล์ภายนอกที่ยังคงสามารถเข้าถึงได้ตามเส้นทางหรือที่ตั้งที่บันทึก.
- **การครอบ** ในตอนแรกไม่ทำลายข้อมูล พิกเซลที่ซ่อนอยู่ยังคงฝังอยู่จนกว่าจะมีการลบพื้นที่ที่ครอบอย่างชัดเจนหรือระหว่างการบีบอัด.
- **การบีบอัด** สามารถลดขนาดไฟล์อย่างมากสำหรับรูปเรสเตอร์ที่ใหญ่เกินไป, แต่จะสูญเสียความละเอียดต้นฉบับ ควรทำหลังจากทราบขนาดที่ต้องการบนสไลด์.
- **รูปภาพ SVG** ควรเก็บเป็น SVG เมื่อการรักษาเวกเตอร์สำคัญ ดึง SVG ฝังโดยตรงเมื่อคุณต้องการทรัพยากรเวกเตอร์เอง การส่งออกสไลด์เป็นเรสเตอร์จะเปลี่ยนสไลด์ที่เรนเดอร์เป็นพิกเซลเสมอ.
- **รูปภาพที่ใช้ซ้ำ** ควรใช้แหล่งข้อมูล [PPImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ppimage/) ที่มีอยู่แล้วเมื่อเป็นไปได้ แทนการโหลดไฟล์เดียวกันหลายครั้งเข้าสู่ขั้นตอนทำงานของงานนำเสนอ.

สำหรับงานนำเสนอขนาดใหญ่ การปรับรูปภาพมักจะมีประสิทธิภาพสูงสุดเมื่อทำอย่างคัดเลือก: เก็บโลโก้และแผนภาพเป็นเนื้อหาเวกเตอร์, บีบอัดภาพถ่ายตามขนาดการแสดงจริง, ลบพิกเซลที่ถูกครอบเฉพาะเมื่อไม่ต้องการแก้ไขต่อในอนาคต, และหลีกเลี่ยงลิงก์ภายนอกหากการจัดการการพึ่งพาไม่เป็นส่วนหนึ่งของการออกแบบการใช้งาน.

## **FAQ**

**ความแตกต่างระหว่างกรอบภาพและแหล่งข้อมูลรูปภาพคืออะไร?**

[PPImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ppimage/) แสดงถึงแหล่งข้อมูลรูปภาพที่เชื่อมโยงกับงานนำเสนอ. ส่วน [PictureFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pictureframe/) เป็นรูปร่างบนสไลด์ที่แสดงรูปภาพและเก็บเรขาคณิตระดับกรอบและการจัดรูปแบบเช่น ขนาด, การหมุน, ค่าการครอบ, เอฟเฟกต์, และการล็อก.

**ควรฝังรูปภาพหรือเชื่อมโยงรูปภาพ?**

ควรฝังรูปภาพเมื่อจำเป็นต้องให้งานนำเสนอพกพาได้, เก็บเป็นไฟล์เก่า, หรือเรนเดอร์โดยไม่ต้องอ้างอิงทรัพยากรภายนอก. ควรเชื่อมโยงรูปภาพเฉพาะเมื่อต้องการเก็บไฟล์รูปภาพอยู่นอก PPTX อย่างตั้งใจและตำแหน่งภายนอกสามารถจัดการได้อย่างแม่นยำ.

**การครอบทำให้ขนาดไฟล์ PPTX ลดลงหรือไม่?**

ไม่โดยตรง การตั้งค่าการครอบปกติจะซ่อนส่วนของภาพต้นฉบับแต่ยังคงเก็บพิกเซลอยู่ ควรใช้ [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) หรือการบีบอัดรูปภาพพร้อมการลบพื้นที่ที่ครอบเมื่อพิกเซลเหล่านั้นสามารถลบทิ้งได้อย่างถาวร.

**ฉันสามารถกู้คุณภาพรูปภาพหลังการบีบอัดได้หรือไม่?**

ไม่ได้ การบีบอัดอาจลดความละเอียดของเรสเตอร์ที่เก็บไว้, และการลบพื้นที่ที่ครอบจะทำให้ข้อมูลรูปภาพหายไป ควรเก็บรูปภาพต้นฉบับนอกงานนำเสนอหากต้องการแก้ไขคุณภาพสูงในภายหลัง.

**ควรจัดการรูปภาพ SVG อย่างไร?**

ควรเก็บเนื้อหา SVG เป็น SVG เมื่อความเที่ยงตรงของเวกเตอร์สำคัญ. [SvgImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/svgimage/) ที่ฝังสามารถดึงโดยตรง. การเรนเดอร์สไลด์เป็นรูปแบบเรสเตอร์เช่น PNG หรือ JPEG จะทำให้ SVG แรสเตอร์เป็นส่วนหนึ่งของรูปสไลด์.

**ฉันจะหลีกเลี่ยงการแคสต์ที่ไม่ปลอดภัยเมื่ออ่านสไลด์ที่มีอยู่ได้อย่างไร?**

ตรวจสอบประเภทของรูปร่างก่อนใช้สมาชิกเฉพาะกรอบภาพ การตรวจสอบ `java.instanceOf` ต่อ [PictureFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pictureframe/) จะหลีกเลี่ยงการแคสต์ที่ไม่ถูกต้องและให้โค้ดจัดการสไลด์ที่ไม่มีกรอบภาพได้.