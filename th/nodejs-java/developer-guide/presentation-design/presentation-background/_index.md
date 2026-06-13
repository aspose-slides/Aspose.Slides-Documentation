---
title: จัดการพื้นหลังงานนำเสนอใน JavaScript
linktitle: พื้นหลังสไลด์
type: docs
weight: 20
url: /th/nodejs-java/presentation-background/
keywords:
- พื้นหลังงานนำเสนอ
- พื้นหลังสไลด์
- สีทึบ
- สีไล่สี
- พื้นหลังรูปภาพ
- ความโปร่งใสของพื้นหลัง
- คุณสมบัติของพื้นหลัง
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้วิธีตั้งค่าพื้นหลังแบบไดนามิกในไฟล์ PowerPoint และ OpenDocument โดยใช้ Aspose.Slides สำหรับ Node.js พร้อมเคล็ดลับโค้ดเพื่อเพิ่มประสิทธิภาพการนำเสนอของคุณ."
---
## **บทนำ**

สีทึบ, ไล่สี, และรูปภาพมักใช้เป็นพื้นหลังของสไลด์ คุณสามารถตั้งค่าพื้นหลังสำหรับ **สไลด์ปกติ** (สไลด์เดี่ยว) หรือ **สไลด์มาสเตอร์** (ใช้กับหลายสไลด์พร้อมกัน)

![พื้นหลัง PowerPoint](powerpoint-background.png)

## **ตั้งค่าสีทึบเป็นพื้นหลังสำหรับสไลด์ปกติ**

Aspose.Slides ให้คุณตั้งค่าสีทึบเป็นพื้นหลังสำหรับสไลด์เฉพาะในงานนำเสนอ — แม้ว่างานนำเสนอจะใช้สไลด์มาสเตอร์ การเปลี่ยนแปลงจะมีผลเฉพาะกับสไลด์ที่เลือกเท่านั้น

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) .
2. ตั้งค่า [BackgroundType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/backgroundtype/) ของสไลด์เป็น `OwnBackground` .
3. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/filltype/) ของพื้นหลังสไลด์เป็น `Solid` .
4. ใช้เมธอด [getSolidFillColor](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fillformat/#getSolidFillColor--) ของ [FillFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fillformat/) เพื่อระบุสีพื้นหลังทึบ
5. บันทึกงานนำเสนอที่แก้ไข

ตัวอย่าง JavaScript ต่อไปนี้แสดงวิธีตั้งค่าสีทึบสีฟ้าเป็นพื้นหลังสำหรับสไลด์ปกติ:

```js
// สร้างอินสแตนซ์ของคลาส Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // ตั้งค่าสีพื้นหลังของสไลด์เป็นสีฟ้า.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    
    // บันทึกงานนำเสนอลงดิสก์.
    presentation.save("SolidColorBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตั้งค่าสีทึบเป็นพื้นหลังสำหรับสไลด์มาสเตอร์**

Aspose.Slides ให้คุณตั้งค่าสีทึบเป็นพื้นหลังสำหรับสไลด์มาสเตอร์ในงานนำเสนอ สไลด์มาสเตอร์ทำหน้าที่เป็นเทมเพลตที่ควบคุมการจัดรูปแบบของทุกสไลด์ ดังนั้นเมื่อคุณเลือกสีทึบเป็นพื้นหลังของสไลด์มาสเตอร์ จะมีผลกับทุกสไลด์

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) .
2. ตั้งค่า [BackgroundType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/backgroundtype/) ของสไลด์มาสเตอร์ (ผ่าน `getMasters`) เป็น `OwnBackground` .
3. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/filltype/) ของพื้นหลังสไลด์มาสเตอร์เป็น `Solid` .
4. ใช้เมธอด [getSolidFillColor](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fillformat/#getSolidFillColor--) เพื่อระบุสีพื้นหลังทึบ
5. บันทึกงานนำเสนอที่แก้ไข

ตัวอย่าง JavaScript ต่อไปนี้แสดงวิธีตั้งค่าสีทึบ (สีเขียว) เป็นพื้นหลังสำหรับสไลด์มาสเตอร์:

```js
// สร้างอินสแตนซ์ของคลาส Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let masterSlide = presentation.getMasters().get_Item(0);

    // ตั้งค่าสีพื้นหลังของสไลด์มาสเตอร์เป็นสีเขียวป่า.
    masterSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    masterSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));

    // บันทึกงานนำเสนอลงดิสก์.
    presentation.save("MasterSlideBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตั้งค่าพื้นหลังไล่สีสำหรับสไลด์**

ไล่สีเป็นเอฟเฟกต์กราฟิกที่สร้างจากการเปลี่ยนสีอย่างค่อยเป็นค่อยไป เมื่อใช้เป็นพื้นหลังของสไลด์ ไล่สีสามารถทำให้การนำเสนอดูศิลป์และเป็นมืออาชีพมากขึ้น Aspose.Slides ให้คุณตั้งค่าสีไล่สีเป็นพื้นหลังของสไลด์

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) .
2. ตั้งค่า [BackgroundType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/backgroundtype/) ของสไลด์เป็น `OwnBackground` .
3. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/filltype/) ของพื้นหลังสไลด์เป็น `Gradient` .
4. ใช้เมธอด [getGradientFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fillformat/#getGradientFormat) ของ [FillFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fillformat/) เพื่อกำหนดการตั้งค่าไล่สีที่คุณต้องการ
5. บันทึกงานนำเสนอที่แก้ไข

ตัวอย่าง JavaScript ต่อไปนี้แสดงวิธีตั้งค่าสีไล่สีเป็นพื้นหลังสำหรับสไลด์:

```js
// สร้างอินสแตนซ์ของคลาส Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // ใช้เอฟเฟกต์ไล่สีกับพื้นหลัง.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    slide.getBackground().getFillFormat().getGradientFormat().setTileFlip(aspose.slides.TileFlip.FlipBoth);

    // บันทึกงานนำเสนอลงดิสก์.
    presentation.save("GradientBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตั้งค่าภาพเป็นพื้นหลังสไลด์**

นอกจากการเติมสีทึบและไล่สีแล้ว Aspose.Slides ยังอนุญาตให้คุณใช้รูปภาพเป็นพื้นหลังของสไลด์

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) .
2. ตั้งค่า [BackgroundType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/backgroundtype/) ของสไลด์เป็น `OwnBackground` .
3. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/filltype/) ของพื้นหลังสไลด์เป็น `Picture` .
4. โหลดรูปภาพที่คุณต้องการใช้เป็นพื้นหลังสไลด์
5. เพิ่มรูปภาพลงในคอลเลกชันรูปภาพของงานนำเสนอ
6. ใช้เมธอด [getPictureFillFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fillformat/#getPictureFillFormat) ของ [FillFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fillformat/) เพื่อกำหนดรูปภาพเป็นพื้นหลัง
7. บันทึกงานนำเสนอที่แก้ไข

ตัวอย่าง JavaScript ต่อไปนี้แสดงวิธีตั้งค่ารูปภาพเป็นพื้นหลังสำหรับสไลด์:

```js
// สร้างอินสแตนซ์ของคลาส Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // ตั้งค่าคุณสมบัติของรูปภาพพื้นหลัง.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

    // โหลดรูปภาพ.
    let image = aspose.slides.Images.fromFile("Tulips.jpg");
    // เพิ่มรูปภาพลงในคอลเลกชันรูปภาพของงานนำเสนอ.
    let ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // บันทึกงานนำเสนอลงดิสก์.
    presentation.save("ImageAsBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

```js
let presentation = new aspose.slides.Presentation();
try {
    let firstSlide = presentation.getSlides().get_Item(0);

    let background = firstSlide.getBackground();

    background.setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    background.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    let newImage = aspose.slides.Images.fromFile("image.png");
    let ppImage = presentation.getImages().addImage(newImage);
    newImage.dispose();

    // ตั้งค่ารูปภาพที่ใช้สำหรับเติมพื้นหลัง.
    let backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // ตั้งค่าโหมดการเติมรูปเป็นแบบต่อภาพ (Tile) และปรับคุณสมบัติการต่อ.
    backPictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    backPictureFillFormat.setTileOffsetX(15.0);
    backPictureFillFormat.setTileOffsetY(15.0);
    backPictureFillFormat.setTileScaleX(46.0);
    backPictureFillFormat.setTileScaleY(87.0);
    backPictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.Center));
    backPictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipY);

    presentation.save("TileBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
อ่านต่อ: [**Tile Picture As Texture**](/slides/th/nodejs-java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **เปลี่ยนความโปร่งแสงของรูปภาพพื้นหลัง**

คุณอาจต้องการปรับความโปร่งแสงของรูปภาพพื้นหลังของสไลด์เพื่อให้เนื้อหาของสไลด์โดดเด่นขึ้น ตัวอย่าง JavaScript ต่อไปนี้แสดงวิธีเปลี่ยนความโปร่งแสงของรูปภาพพื้นหลังสไลด์:

```js
var transparencyValue = 30; // ตัวอย่างเช่น.

// รับคอลเลกชันของการแปลงรูปภาพ.
var imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

// ค้นหาเอฟเฟกต์ความโปร่งใสแบบเปอร์เซ็นต์คงที่ที่มีอยู่.
var transparencyOperation = null;
for (let i = 0; i < imageTransform.size(); i++) {
    let operation = imageTransform.get_Item(i);
    if (java.instanceOf(operation, "com.aspose.slides.AlphaModulateFixed")) {
        transparencyOperation = operation;
        break;
    }
}

// ตั้งค่าค่าความโปร่งใสใหม่.
if (transparencyOperation == null) {
    imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
} else {
    transparencyOperation.setAmount(100 - transparencyValue);
}
```

## **รับค่าพื้นหลังของสไลด์**

Aspose.Slides มีคลาส `BackgroundEffectiveData` สำหรับดึงค่าพื้นหลังที่มีผลของสไลด์ คลาสนี้เปิดเผย [FillFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fillformat/) และ [EffectFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/effectformat/) ที่มีผล

โดยใช้เมธอด `getBackground` ของคลาส [BaseSlide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseslide/) คุณสามารถรับพื้นหลังที่มีผลของสไลด์ได้

ตัวอย่าง JavaScript ต่อไปนี้แสดงวิธีรับค่าพื้นหลังที่มีผลของสไลด์:

```js
// สร้างอินสแตนซ์ของคลาส Presentation.
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);

    // ดึงพื้นหลังที่มีผลโดยคำนึงถึงมาสเตอร์, เลย์เอาต์ และธีม.
    let effBackground = slide.getBackground().getEffective();

    if (effBackground.getFillFormat().getFillType() == aspose.slides.FillType.Solid)
        console.log("Fill color:", effBackground.getFillFormat().getSolidFillColor().toString());
    else
        console.log("Fill type:", effBackground.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

## **FAQ**

**ฉันสามารถรีเซ็ตพื้นหลังที่กำหนดเองและกู้คืนพื้นหลังของธีม/เลย์เอาต์ได้หรือไม่?**

ใช่. ลบการเติมสีที่กำหนดเองของสไลด์ แล้วพื้นหลังจะถูกสืบทอดใหม่จากสไลด์ [layout](/slides/th/nodejs-java/slide-layout/)/[master](/slides/th/nodejs-java/slide-master/) ที่สอดคล้อง (เช่น [theme background](/slides/th/nodejs-java/presentation-theme/)).

**เกิดอะไรขึ้นกับพื้นหลังหากฉันเปลี่ยนธีมของงานนำเสนอในภายหลัง?**

หากสไลด์มีการเติมสีของตนเอง จะคงไว้โดยไม่เปลี่ยนแปลง หากพื้นหลังถูกสืบทอดจาก [layout](/slides/th/nodejs-java/slide-layout/)/[master](/slides/th/nodejs-java/slide-master/) จะอัปเดตให้ตรงกับ [new theme](/slides/th/nodejs-java/presentation-theme/).