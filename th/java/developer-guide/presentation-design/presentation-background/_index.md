---
title: จัดการพื้นหลังการนำเสนอใน Java
linktitle: พื้นหลังสไลด์
type: docs
weight: 20
url: /th/java/presentation-background/
keywords:
- พื้นหลังการนำเสนอ
- พื้นหลังสไลด์
- สีทึบ
- สีไล่ระดับ
- พื้นหลังภาพ
- ความโปร่งใสของพื้นหลัง
- คุณสมบัติของพื้นหลัง
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้วิธีตั้งค่าพื้นหลังแบบไดนามิกในไฟล์ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Java พร้อมเคล็ดลับโค้ดเพื่อยกระดับการนำเสนอของคุณ"
---
## **บทนำ**

สีทึบ, การไล่สี, และรูปภาพมักใช้เป็นพื้นหลังของสไลด์ คุณสามารถตั้งค่าพื้นหลังสำหรับ **สไลด์ปกติ** (สไลด์เดียว) หรือ **สไลด์แม่แบบ** (ใช้กับหลายสไลด์พร้อมกัน)

![พื้นหลัง PowerPoint](powerpoint-background.png)

## **ตั้งค่าพื้นหลังสีทึบสำหรับสไลด์ปกติ**

Aspose.Slides ให้คุณตั้งค่าสีทึบเป็นพื้นหลังของสไลด์เฉพาะในพรีเซนเทชัน — แม้ว่าพรีเซนเทชันจะใช้สไลด์แม่แบบ การเปลี่ยนแปลงจะใช้เฉพาะกับสไลด์ที่เลือกเท่านั้น

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/).
2. ตั้งค่า [BackgroundType](https://reference.aspose.com/slides/th/java/com.aspose.slides/backgroundtype/) ของสไลด์เป็น `OwnBackground`.
3. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/java/com.aspose.slides/filltype/) ของพื้นหลังสไลด์เป็น `Solid`.
4. ใช้เมธอด [getSolidFillColor](https://reference.aspose.com/slides/th/java/com.aspose.slides/fillformat/#getSolidFillColor--) ของ [FillFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/fillformat/) เพื่อระบุสีพื้นหลังแบบทึบ.
5. บันทึกพรีเซนเทชันที่แก้ไขแล้ว.

ตัวอย่าง Java ด้านล่างแสดงวิธีตั้งค่าสีทึบสีฟ้าเป็นพื้นหลังสำหรับสไลด์ปกติ:

```java
import com.aspose.slides.*;
import java.awt.Color;

// สร้างอินสแตนซ์ของคลาส Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // ตั้งค่าสีพื้นหลังของสไลด์เป็นสีน้ำเงิน.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    // บันทึกพรีเซนเทชันลงดิสก์.
    presentation.save("SolidColorBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตั้งค่าพื้นหลังสีทึบสำหรับสไลด์แม่แบบ**

Aspose.Slides ให้คุณตั้งค่าสีทึบเป็นพื้นหลังของสไลด์แม่แบบในพรีเซนเทชัน สไลด์แม่แบบทำหน้าที่เป็นเทมเพลตที่ควบคุมการจัดรูปแบบสำหรับสไลด์ทั้งหมด ดังนั้นเมื่อคุณเลือกสีทึบเป็นพื้นหลังของสไลด์แม่แบบ มันจะใช้กับทุกสไลด์

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/).
2. ตั้งค่า [BackgroundType](https://reference.aspose.com/slides/th/java/com.aspose.slides/backgroundtype/) ของสไลด์แม่แบบ (ผ่าน `getMasters`) เป็น `OwnBackground`.
3. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/java/com.aspose.slides/filltype/) ของพื้นหลังสไลด์แม่แบบเป็น `Solid`.
4. ใช้เมธอด [getSolidFillColor](https://reference.aspose.com/slides/th/java/com.aspose.slides/fillformat/#getSolidFillColor--) เพื่อระบุสีพื้นหลังแบบทึบ.
5. บันทึกพรีเซนเทชันที่แก้ไขแล้ว.

ตัวอย่าง Java ด้านล่างแสดงวิธีตั้งค่าสีทึบสีเขียวเป็นพื้นหลังสำหรับสไลด์แม่แบบ:

```java
import com.aspose.slides.*;
import java.awt.Color;

// สร้างอินสแตนซ์ของคลาส Presentation.
Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

    // ตั้งค่าสีพื้นหลังสำหรับสไลด์แม่แบบเป็นสีเขียว.
    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

    // บันทึกพรีเซนเทชันลงดิสก์.
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตั้งค่าพื้นหลังเป็นการไล่สีสำหรับสไลด์**

การไล่สีเป็นเอฟเฟกต์กราฟิกที่สร้างจากการเปลี่ยนสีอย่างค่อยเป็นค่อยไป เมื่อใช้เป็นพื้นหลังของสไลด์ การไล่สีสามารถทำให้พรีเซนเทชันดูศิลปะและเป็นมืออาชีพมากยิ่งขึ้น Aspose.Slides ให้คุณตั้งค่าสีการไล่สีเป็นพื้นหลังของสไลด์

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/).
2. ตั้งค่า [BackgroundType](https://reference.aspose.com/slides/th/java/com.aspose.slides/backgroundtype/) ของสไลด์เป็น `OwnBackground`.
3. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/java/com.aspose.slides/filltype/) ของพื้นหลังสไลด์เป็น `Gradient`.
4. ใช้เมธอด [getGradientFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/fillformat/#getGradientFormat--) ของ [FillFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/fillformat/) เพื่อกำหนดการตั้งค่าการไล่สีที่ต้องการ
5. บันทึกพรีเซนเทชันที่แก้ไขแล้ว.

ตัวอย่าง Java ด้านล่างแสดงวิธีตั้งค่าการไล่สีเป็นพื้นหลังของสไลด์:

```java
import com.aspose.slides.*;
import java.awt.Color;

// สร้างอินสแตนซ์ของคลาส Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    // ใช้เอฟเฟกต์การไล่สีกับพื้นหลัง.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient);

    IGradientFormat gradientFormat = slide.getBackground().getFillFormat().getGradientFormat();
    gradientFormat.setTileFlip(TileFlip.FlipBoth);

    // เพิ่มสีไล่ระดับ. หากไม่มีจุดไล่ระดับ พื้นหลังจะกลับไปเป็นสีดำถึงขาวเริ่มต้น.
    gradientFormat.getGradientStops().add(0f, Color.CYAN);
    gradientFormat.getGradientStops().add(1f, Color.BLUE);

    // บันทึกพรีเซนเทชันลงดิสก์.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตั้งค่ารูปภาพเป็นพื้นหลังของสไลด์**

นอกจากการเติมสีทึบและการไล่สีแล้ว Aspose.Slides ยังให้คุณใช้รูปภาพเป็นพื้นหลังของสไลด์ได้

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/).
2. ตั้งค่า [BackgroundType](https://reference.aspose.com/slides/th/java/com.aspose.slides/backgroundtype/) ของสไลด์เป็น `OwnBackground`.
3. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/java/com.aspose.slides/filltype/) ของพื้นหลังสไลด์เป็น `Picture`.
4. โหลดรูปภาพที่ต้องการใช้เป็นพื้นหลังสไลด์
5. เพิ่มรูปภาพลงในคอลเลกชันรูปภาพของพรีเซนเทชัน
6. ใช้เมธอด [getPictureFillFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/fillformat/#getPictureFillFormat--) ของ [FillFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/fillformat/) เพื่อกำหนดรูปภาพเป็นพื้นหลัง
7. บันทึกพรีเซนเทชันที่แก้ไขแล้ว

ตัวอย่าง Java ด้านล่างแสดงวิธีตั้งค่ารูปภาพเป็นพื้นหลังของสไลด์:

```java
import com.aspose.slides.*;

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
    // เพิ่มภาพไปยังคอลเลกชันภาพของพรีเซนเทชัน.
    IPPImage ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // บันทึกพรีเซนเทชันลงดิสก์.
    presentation.save("ImageAsBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีตั้งค่า Fill Type ของพื้นหลังเป็นรูปภาพที่ทำเป็นกระเบื้องและปรับคุณสมบัติการทำเป็นกระเบื้อง:

```java
import com.aspose.slides.*;

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

    // ตั้งค่าโหมดการเติมรูปเป็นแบบกระเบื้องและปรับคุณสมบัติกระเบื้อง.
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

{{% alert color="info" %}}
อ่านเพิ่มเติม: [**Tile Picture As Texture**](/slides/th/java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **เปลี่ยนความโปร่งใสของรูปภาพพื้นหลัง**

คุณอาจต้องการปรับความโปร่งใสของรูปภาพพื้นหลังสไลด์เพื่อให้เนื้อหาของสไลด์เด่นชัดขึ้น ตัวอย่าง Java ด้านล่างแสดงวิธีเปลี่ยนความโปร่งใสสำหรับรูปภาพพื้นหลังสไลด์:

```java
import com.aspose.slides.*;

int transparencyValue = 30; // ตัวอย่างเช่น.

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // รับคอลเลกชันของการแปลงรูปภาพ.
    IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

    // ค้นหาเอฟเฟกต์ความโปร่งใสแบบเปอร์เซ็นต์คงที่ที่มีอยู่.
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

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **รับค่าพื้นหลังของสไลด์**

Aspose.Slides มีอินเทอร์เฟซ [IBackgroundEffectiveData](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibackgroundeffectivedata/) สำหรับดึงค่าพื้นหลังที่มีประสิทธิภาพของสไลด์ อินเทอร์เฟซนี้เปิดเผย [FillFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) และ [EffectFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--) ที่มีประสิทธิภาพ

โดยใช้เมธอด `getBackground` ของคลาส [BaseSlide](https://reference.aspose.com/slides/th/java/com.aspose.slides/baseslide/) คุณสามารถรับพื้นหลังที่มีประสิทธิภาพของสไลด์ได้

ตัวอย่าง Java ด้านล่างแสดงวิธีรับค่าพื้นหลังที่มีประสิทธิภาพของสไลด์:

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation.
Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // ดึงพื้นหลังที่มีประสิทธิภาพโดยคำนึงถึงสไลด์แม่แบบ, เลเอาต์, และธีม.
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

### ฉันสามารถรีเซ็ตพื้นหลังที่กำหนดเองและคืนค่าแบ็คกราวด์จากธีม/เลเอาต์ได้หรือไม่?

ใช่ ลบการเติมแบบกำหนดเองของสไลด์ แล้วพื้นหลังจะสืบทอดจากสไลด์ [layout](/slides/th/java/slide-layout/)/[master](/slides/th/java/slide-master/) ที่สอดคล้องกัน (คือ [theme background](/slides/th/java/presentation-theme/))

### จะเกิดอะไรขึ้นกับพื้นหลังหากฉันเปลี่ยนธีมของพรีเซนเทชันในภายหลัง?

หากสไลด์มีการเติมของตนเอง จะคงไว้ไม่เปลี่ยนแปลง หากพื้นหลังถูกสืบทอดจาก [layout](/slides/th/java/slide-layout/)/[master](/slides/th/java/slide-master/) จะอัปเดตให้ตรงกับ [new theme](/slides/th/java/presentation-theme/)