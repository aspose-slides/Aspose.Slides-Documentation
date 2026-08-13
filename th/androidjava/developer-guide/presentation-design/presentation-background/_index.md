---
title: จัดการพื้นหลังงานนำเสนอบน Android
linktitle: พื้นหลังสไลด์
type: docs
weight: 20
url: /th/androidjava/presentation-background/
keywords:
- พื้นหลังงานนำเสนอ
- พื้นหลังสไลด์
- สีทึบ
- สีไล่ระดับ
- พื้นหลังภาพ
- ความโปร่งใสของพื้นหลัง
- คุณสมบัติพื้นหลัง
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีตั้งค่าพื้นหลังแบบไดนามิกในไฟล์ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Android ผ่าน Java พร้อมเคล็ดลับโค้ดเพื่อยกระดับการพรีเซนเทชันของคุณ."
---
## **แนะนำ**

สีทึบ, การไล่สี, และภาพมักใช้เป็นพื้นหลังของสไลด์ คุณสามารถตั้งค่าพื้นหลังสำหรับ **สไลด์ปกติ** (สไลด์เดียว) หรือ **สไลด์มาสเตอร์** (ใช้กับหลายสไลด์พร้อมกัน)

![พื้นหลัง PowerPoint](powerpoint-background.png)

## **ตั้งค่าสีพื้นหลังทึบสำหรับสไลด์ปกติ**

Aspose.Slides ให้คุณตั้งค่าสีทึบเป็นพื้นหลังสำหรับสไลด์เฉพาะในงานนำเสนอ — แม้ว่างานนำเสนอจะใช้สไลด์มาสเตอร์ก็ตาม การเปลี่ยนแปลงนี้จะมีผลต่อสไลด์ที่เลือกเท่านั้น

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/)  
2. ตั้งค่า [BackgroundType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/backgroundtype/) ของสไลด์เป็น `OwnBackground`  
3. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/filltype/) ของพื้นหลังสไลด์เป็น `Solid`  
4. ใช้เมธอด [getSolidFillColor](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) บน [FillFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fillformat/) เพื่อระบุสีพื้นหลังทึบ  
5. บันทึกงานนำเสนอที่แก้ไขแล้ว  

ตัวอย่าง Java ด้านล่างแสดงวิธีตั้งค่าสีทึบแบบสีฟ้าเป็นพื้นหลังสำหรับสไลด์ปกติ:

```java
import com.aspose.slides.*;
import java.awt.Color;

// สร้างอินสแตนซ์ของคลาส Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // ตั้งค่าสีพื้นหลังของสไลด์เป็นสีฟ้า.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    // บันทึกงานนำเสนอไปยังดิสก์.
    presentation.save("SolidColorBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตั้งค่าสีพื้นหลังทึบสำหรับสไลด์มาสเตอร์**

Aspose.Slides ให้คุณตั้งค่าสีทึบเป็นพื้นหลังสำหรับสไลด์มาสเตอร์ในงานนำเสนอ สไลด์มาสเตอร์ทำหน้าที่เป็นเทมเพลตที่ควบคุมรูปแบบของสไลด์ทั้งหมด ดังนั้นเมื่อคุณเลือกสีทึบสำหรับพื้นหลังของสไลด์มาสเตอร์ มันจะนำไปใช้กับทุกสไลด์

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/)  
2. ตั้งค่า [BackgroundType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/backgroundtype/) ของสไลด์มาสเตอร์ (ผ่าน `getMasters`) เป็น `OwnBackground`  
3. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/filltype/) ของพื้นหลังสไลด์มาสเตอร์เป็น `Solid`  
4. ใช้เมธอด [getSolidFillColor](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) เพื่อระบุสีพื้นหลังทึบ  
5. บันทึกรายการนำเสนอที่แก้ไขแล้ว  

ตัวอย่าง Java ด้านล่างแสดงวิธีตั้งค่าสีทึบ (สีเขียว) เป็นพื้นหลังสำหรับสไลด์มาสเตอร์:

```java
import com.aspose.slides.*;
import java.awt.Color;

// สร้างอินสแตนซ์ของคลาส Presentation.
Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

    // ตั้งค่าสีพื้นหลังของสไลด์มาสเตอร์เป็นสีเขียว.
    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

    // บันทึกงานนำเสนอไปยังดิสก์.
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตั้งค่าพื้นหลังแบบไล่สีสำหรับสไลด์**

ไล่สีเป็นเอฟเฟกต์กราฟิกที่เกิดจากการเปลี่ยนสีอย่างค่อยเป็นค่อยไป เมื่อใช้เป็นพื้นหลังสไลด์ ไล่สีสามารถทำให้งานนำเสนอดูมีศิลปะและเป็นมืออาชีพมากขึ้น Aspose.Slides ให้คุณตั้งค่าสีไล่สีเป็นพื้นหลังสำหรับสไลด์

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/)  
2. ตั้งค่า [BackgroundType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/backgroundtype/) ของสไลด์เป็น `OwnBackground`  
3. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/filltype/) ของพื้นหลังสไลด์เป็น `Gradient`  
4. ใช้เมธอด [getGradientFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fillformat/#getGradientFormat--) บน [FillFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fillformat/) เพื่อตั้งค่าการไล่สีที่ต้องการ  
5. บันทึกงานนำเสนอที่แก้ไขแล้ว  

ตัวอย่าง Java ด้านล่างแสดงวิธีตั้งค่าสีไล่สีเป็นพื้นหลังสำหรับสไลด์:

```java
import com.aspose.slides.*;
import java.awt.Color;

// สร้างอินสแตนซ์ของคลาส Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    // ใช้เอฟเฟกต์ไล่สีกับพื้นหลัง.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient);

    IGradientFormat gradientFormat = slide.getBackground().getFillFormat().getGradientFormat();
    gradientFormat.setTileFlip(TileFlip.FlipBoth);

    // เพิ่มสีไล่ระดับ. หากไม่มีจุดไล่สี, พื้นหลังจะกลับไปใช้การไล่สีดำถึงขาวเริ่มต้น.
    gradientFormat.getGradientStops().add(0f, Color.CYAN);
    gradientFormat.getGradientStops().add(1f, Color.BLUE);

    // บันทึกงานนำเสนอไปยังดิสก์.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตั้งค่าภาพเป็นพื้นหลังของสไลด์**

นอกจากการเติมสีทึบและไล่สีแล้ว Aspose.Slides ยังให้คุณใช้ภาพเป็นพื้นหลังของสไลด์ได้

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/)  
2. ตั้งค่า [BackgroundType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/backgroundtype/) ของสไลด์เป็น `OwnBackground`  
3. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/filltype/) ของพื้นหลังสไลด์เป็น `Picture`  
4. โหลดภาพที่ต้องการใช้เป็นพื้นหลังของสไลด์  
5. เพิ่มภาพไปยังคอลเลกชันภาพของงานนำเสนอ  
6. ใช้เมธอด [getPictureFillFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fillformat/#getPictureFillFormat--) บน [FillFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fillformat/) เพื่อตั้งค่าภาพเป็นพื้นหลัง  
7. บันทึกงานนำเสนอที่แก้ไขแล้ว  

ตัวอย่าง Java ด้านล่างแสดงวิธีตั้งค่าภาพเป็นพื้นหลังสำหรับสไลด์:

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
    // เพิ่มภาพไปยังคอลเลกชันภาพของงานนำเสนอ.
    IPPImage ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // บันทึกงานนำเสนอไปยังดิสก์.
    presentation.save("ImageAsBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีตั้งค่าชนิดการเติมพื้นหลังเป็นรูปภาพแบบต่อกัน (tiled picture) และปรับคุณสมบัติการต่อกัน:

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

    // ตั้งค่าโหมดการเติมรูปแบบเป็น Tile และปรับคุณสมบัติการต่อภาพ.
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
อ่านเพิ่มได้ที่: [**Tile Picture As Texture**](/slides/th/androidjava/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **เปลี่ยนความโปร่งใสของภาพพื้นหลัง**

คุณอาจต้องการปรับความโปร่งใสของภาพพื้นหลังสไลด์เพื่อให้เนื้อหาของสไลด์โดดเด่นขึ้น โค้ด Java ด้านล่างแสดงวิธีการเปลี่ยนความโปร่งใสของภาพพื้นหลังสไลด์:

```java
import com.aspose.slides.*;

int transparencyValue = 30; // เช่น ตัวอย่าง.

Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // รับคอลเลกชันของการแปลงรูปภาพ.
    IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

    // ค้นหาเอฟเฟกต์ความโปร่งใสแบบเปอร์เซ็นต์คงที่ที่มีอยู่แล้ว.
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

    presentation.save("TransparentBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **รับค่าพื้นหลังของสไลด์**

Aspose.Slides มีอินเทอร์เฟซ [IBackgroundEffectiveData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibackgroundeffectivedata/) สำหรับดึงค่าพื้นหลังที่มีผลของสไลด์ อินเทอร์เฟซนี้เปิดเผย [FillFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) และ [EffectFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--) ที่มีผล

โดยใช้เมธอด `getBackground` ของคลาส [BaseSlide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/baseslide/) คุณสามารถรับพื้นหลังที่มีผลของสไลด์ได้

ตัวอย่าง Java ด้านล่างแสดงวิธีรับค่าพื้นหลังที่มีผลของสไลด์:

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation.
Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // ดึงพื้นหลังที่มีประสิทธิภาพโดยคำนึงถึงมาสเตอร์, เลเอาต์, และธีม.
    IBackgroundEffectiveData effBackground = slide.getBackground().getEffective();
    
    if (effBackground.getFillFormat().getFillType() == FillType.Solid)
        System.out.println("Fill color: " + effBackground.getFillFormat().getSolidFillColor());
    else
        System.out.println("Fill type: " + effBackground.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

## **FAQ**

### ฉันสามารถรีเซ็ตพื้นหลังที่กำหนดเองและคืนค่าเป็นพื้นหลังของธีม/เลเอาต์ได้หรือไม่?

ใช่. ลบการเติมสีที่กำหนดเองของสไลด์ แล้วพื้นหลังจะสืบทอดจาก [layout](/slides/th/androidjava/slide-layout/)/[master](/slides/th/androidjava/slide-master/) ที่สอดคล้องกัน (เช่น [theme background](/slides/th/androidjava/presentation-theme/))

### จะเกิดอะไรขึ้นกับพื้นหลังหากฉันเปลี่ยนธีมของงานนำเสนอในภายหลัง?

หากสไลด์มีการเติมสีของตนเอง จะคงอยู่ไม่ถูกเปลี่ยน หากพื้นหลังสืบทอดจาก [layout](/slides/th/androidjava/slide-layout/)/[master](/slides/th/androidjava/slide-master/) มันจะอัปเดตให้ตรงกับ [new theme](/slides/th/androidjava/presentation-theme/) ใหม่.