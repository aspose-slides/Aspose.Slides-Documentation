---
title: "จัดการพื้นหลังการนำเสนอใน Java"
linktitle: "พื้นหลังสไลด์"
type: docs
weight: 20
url: /th/java/presentation-background/
keywords:
- "พื้นหลังการนำเสนอ"
- "พื้นหลังสไลด์"
- "สีทึบ"
- "สีไล่ระดับ"
- "พื้นหลังรูปภาพ"
- "ความโปร่งใสของพื้นหลัง"
- "คุณสมบัติพื้นหลัง"
- "PowerPoint"
- "OpenDocument"
- "การนำเสนอ"
- "Java"
- "Aspose.Slides"
description: "เรียนรู้วิธีตั้งค่าพื้นหลังแบบไดนามิกในไฟล์ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Java พร้อมเคล็ดลับโค้ดเพื่อเสริมประสิทธิภาพการนำเสนอของคุณ."
---
## **บทนำ**

สีทึบ, การไล่สี, และรูปภาพเป็นที่นิยมใช้เป็นพื้นหลังสไลด์ คุณสามารถตั้งค่าพื้นหลังสำหรับ **สไลด์ปกติ** (สไลด์เดียว) หรือ **สไลด์แม่แบบ** (ใช้กับหลายสไลด์พร้อมกัน)

![PowerPoint background](powerpoint-background.png)

## **ตั้งค่าสีพื้นหลังทึบสำหรับสไลด์ปกติ**

Aspose.Slides ให้คุณตั้งค่าสีทึบเป็นพื้นหลังของสไลด์เฉพาะในงานนำเสนอ — แม้ว่างานนำเสนอจะใช้สไลด์แม่แบบ การเปลี่ยนแปลงนี้จะใช้เฉพาะสไลด์ที่เลือกเท่านั้น

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) 
2. ตั้งค่า [BackgroundType](https://reference.aspose.com/slides/th/java/com.aspose.slides/backgroundtype/) ของสไลด์เป็น `OwnBackground`
3. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/java/com.aspose.slides/filltype/) ของพื้นหลังสไลด์เป็น `Solid`
4. ใช้เมธอด [getSolidFillColor](https://reference.aspose.com/slides/th/java/com.aspose.slides/fillformat/#getSolidFillColor--) ของ [FillFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/fillformat/) เพื่อกำหนดสีพื้นหลังทึบ
5. บันทึกการนำเสนอที่แก้ไขแล้ว

ตัวอย่าง Java ด้านล่างแสดงวิธีตั้งค่าสีฟ้าเป็นพื้นหลังทึบสำหรับสไลด์ปกติ:

```java
// สร้างอินสแตนซ์ของคลาส Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // ตั้งค่าสีพื้นหลังของสไลด์เป็นสีน้ำเงิน.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    // บันทึกการนำเสนอลงดิสก์.
    presentation.save("SolidColorBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตั้งค่าสีพื้นหลังทึบสำหรับสไลด์แม่แบบ**

Aspose.Slides ให้คุณตั้งค่าสีทึบเป็นพื้นหลังของสไลด์แม่แบบในงานนำเสนอ สไลด์แม่แบบทำหน้าที่เป็นเท็มเพลตที่ควบคุมการจัดรูปแบบของสไลด์ทั้งหมด ดังนั้นเมื่อคุณเลือกสีทึบสำหรับพื้นหลังของสไลด์แม่แบบ สีนี้จะใช้กับทุกสไลด์

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) 
2. ตั้งค่า [BackgroundType](https://reference.aspose.com/slides/th/java/com.aspose.slides/backgroundtype/) ของสไลด์แม่แบบ (ผ่าน `getMasters`) เป็น `OwnBackground`
3. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/java/com.aspose.slides/filltype/) ของพื้นหลังสไลด์แม่แบบเป็น `Solid`
4. ใช้เมธอด [getSolidFillColor](https://reference.aspose.com/slides/th/java/com.aspose.slides/fillformat/#getSolidFillColor--) เพื่อกำหนดสีพื้นหลังทึบ
5. บันทึกการนำเสนอที่แก้ไขแล้ว

ตัวอย่าง Java ด้านล่างแสดงวิธีตั้งค่าสีเขียวเป็นพื้นหลังทึบสำหรับสไลด์แม่แบบ:

```java
// สร้างอินสแตนซ์ของคลาส Presentation.
Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

    // ตั้งค่าสีพื้นหลังของสไลด์ Master เป็นสีเขียวป่า.
    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

    // บันทึกการนำเสนอลงดิสก์.
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตั้งค่าพื้นหลังไล่สีสำหรับสไลด์**

ไล่สีเป็นเอฟเฟกต์กราฟิกที่สร้างโดยการเปลี่ยนสีอย่างค่อยเป็นค่อยไป เมื่อใช้เป็นพื้นหลังสไลด์ ไล่สีสามารถทำให้การนำเสนอดูศิลปะและมืออาชีพมากขึ้น Aspose.Slides ให้คุณตั้งค่าสีไล่สีเป็นพื้นหลังของสไลด์

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) 
2. ตั้งค่า [BackgroundType](https://reference.aspose.com/slides/th/java/com.aspose.slides/backgroundtype/) ของสไลด์เป็น `OwnBackground`
3. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/java/com.aspose.slides/filltype/) ของพื้นหลังสไลด์เป็น `Gradient`
4. ใช้เมธอด [getGradientFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/fillformat/#getGradientFormat--) ของ [FillFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/fillformat/) เพื่อกำหนดการตั้งค่าไล่สีที่ต้องการ
5. บันทึกการนำเสนอที่แก้ไขแล้ว

ตัวอย่าง Java ด้านล่างแสดงวิธีตั้งค่าไล่สีเป็นพื้นหลังของสไลด์:

```java
// สร้างอินสแตนซ์ของคลาส Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    // ใช้เอฟเฟกต์ไล่สีกับพื้นหลัง.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient);
    slide.getBackground().getFillFormat().getGradientFormat().setTileFlip(TileFlip.FlipBoth);

    // บันทึกการนำเสนอลงดิสก์.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตั้งรูปภาพเป็นพื้นหลังสไลด์**

นอกเหนือจากการเติมสีทึบและไล่สี Aspose.Slides ยังอนุญาตให้คุณใช้รูปภาพเป็นพื้นหลังสไลด์ได้

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) 
2. ตั้งค่า [BackgroundType](https://reference.aspose.com/slides/th/java/com.aspose.slides/backgroundtype/) ของสไลด์เป็น `OwnBackground`
3. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/java/com.aspose.slides/filltype/) ของพื้นหลังสไลด์เป็น `Picture`
4. โหลดรูปภาพที่ต้องการใช้เป็นพื้นหลังสไลด์
5. เพิ่มรูปภาพลงในคอลเลกชันของงานนำเสนอ
6. ใช้เมธอด [getPictureFillFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/fillformat/#getPictureFillFormat--) ของ [FillFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/fillformat/) เพื่อกำหนดรูปภาพเป็นพื้นหลัง
7. บันทึกการนำเสนอที่แก้ไขแล้ว

ตัวอย่าง Java ด้านล่างแสดงวิธีตั้งรูปภาพเป็นพื้นหลังของสไลด์:

```java
// สร้างอินสแตนซ์ของคลาส Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // ตั้งค่าคุณสมบัติของภาพพื้นหลัง.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Picture);
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    
    // โหลดภาพ.
    IImage image = Images.fromFile("Tulips.jpg");
    // เพิ่มภาพลงในคอลเลกชันภาพของการนำเสนอ.
    IPPImage ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // บันทึกการนำเสนอลงดิสก์.
    presentation.save("ImageAsBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีตั้งค่าชนิดการเติมพื้นหลังเป็นภาพที่ทำการต่อกระเบื้องและแก้ไขคุณสมบัติต่อกระเบื้อง:

```java
Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IBackground background = firstSlide.getBackground();

    background.setType(BackgroundType.OwnBackground);
    background.getFillFormat().setFillType(FillType.Picture);

    IImage newImage = Images.fromFile("image.png");
    IPPImage ppImage = presentation.getImages().addImage(newImage);
    newImage.dispose();

    // ตั้งค่าภาพที่ใช้สำหรับการเติมพื้นหลัง.
    IPictureFillFormat backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // ตั้งค่าโหมดการเติมรูปเป็น Tile และปรับคุณสมบัติของการต่อกระเบื้อง.
    backPictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    backPictureFillFormat.setTileOffsetX(15f);
    backPictureFillFormat.setTileOffsetY(15f);
    backPictureFillFormat.setTileScaleX(46f);
    backPictureFillFormat.setTileScaleY(87f);
    backPictureFillFormat.setTileAlignment(RectangleAlignment.Center);
    backPictureFillFormat.setTileFlip(TileFlip.FlipY);

    presentation.save("TileBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
อ่านเพิ่มเติม: [**ภาพต่อเป็นพื้นผิว**](/slides/th/java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **เปลี่ยนความโปร่งแสงของภาพพื้นหลัง**

คุณอาจต้องการปรับความโปร่งแสงของภาพพื้นหลังสไลด์เพื่อให้เนื้อหาของสไลด์เด่นชัดขึ้น โค้ด Java ด้านล่างแสดงวิธีเปลี่ยนความโปร่งแสงของภาพพื้นหลังสไลด์:

```java
int transparencyValue = 30; // ตัวอย่างเช่น.

// Get the collection of picture transform operations.
IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

// ค้นหาผลกระทบความโปร่งใสแบบเปอร์เซ็นต์คงที่ที่มีอยู่.
IAlphaModulateFixed transparencyOperation = null;
for (IImageTransformOperation operation : imageTransform) {
    if (operation instanceof IAlphaModulateFixed) {
        transparencyOperation = (IAlphaModulateFixed)operation;
        break;
    }
}

// ตั้งค่าความโปร่งใสใหม่.
if (transparencyOperation == null) {
    imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
}
else {
    transparencyOperation.setAmount(100 - transparencyValue);
}
```

## **รับค่าพื้นหลังสไลด์**

Aspose.Slides มีอินเทอร์เฟซ [IBackgroundEffectiveData](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibackgroundeffectivedata/) สำหรับการดึงค่าพื้นหลังที่มีผลของสไลด์ อินเทอร์เฟซนี้ให้เข้าถึง [FillFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) และ [EffectFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--) ที่มีผล

โดยใช้เมธอด `getBackground` ของคลาส [BaseSlide](https://reference.aspose.com/slides/th/java/com.aspose.slides/baseslide/) คุณสามารถรับพื้นหลังที่มีผลของสไลด์ได้

ตัวอย่าง Java ด้านล่างแสดงวิธีรับค่าพื้นหลังที่มีผลของสไลด์:

```java
// สร้างอินสแตนซ์ของคลาส Presentation.
Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // ดึงพื้นหลังที่มีผลโดยคำนึงถึงสไลด์แม่แบบ, เลย์เอาต์, และธีม.
    IBackgroundEffectiveData effBackground = slide.getBackground().getEffective();
    
    if (effBackground.getFillFormat().getFillType() == FillType.Solid)
        System.out.println("Fill color: " + effBackground.getFillFormat().getSolidFillColor());
    else
        System.out.println("Fill type: " + effBackground.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถรีเซ็ตพื้นหลังที่กำหนดเองและเรียกคืนพื้นหลังของธีม/เลย์เอาท์ได้หรือไม่?**

ได้ คุณเพียงลบการเติมที่กำหนดเองของสไลด์ แล้วพื้นหลังจะถูกสืบทอดใหม่จากสไลด์ [layout](/slides/th/java/slide-layout/)/[master](/slides/th/java/slide-master/) ที่สอดคล้อง (เช่น [theme background](/slides/th/java/presentation-theme/))

**จะเกิดอะไรขึ้นกับพื้นหลังหากฉันเปลี่ยนธีมของงานนำเสนอในภายหลัง?**

หากสไลด์มีการเติมของตนเอง มันจะคงอยู่โดยไม่มีการเปลี่ยนแปลง หากพื้นหลังถูกสืบทอดจาก [layout](/slides/th/java/slide-layout/)/[master](/slides/th/java/slide-master/) มันจะอัปเดตให้ตรงกับ [new theme](/slides/th/java/presentation-theme/) ใหม่.