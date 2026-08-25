---
title: จัดการกรอบรูปภาพในงานนำเสนอบน Android
linktitle: กรอบรูปภาพ
type: docs
weight: 10
url: /th/androidjava/picture-frame/
keywords:
- กรอบรูปภาพ
- เพิ่มกรอบรูปภาพ
- สร้างกรอบรูปภาพ
- ภาพที่ฝังไว้
- ภาพที่เชื่อมโยง
- สกัดภาพ
- ภาพราสเตอร์
- ภาพ SVG
- ครอปภาพ
- ลบพื้นที่ที่ครอป
- บีบอัดภาพ
- StretchOffset
- การจัดรูปแบบกรอบรูปภาพ
- สเกลเชิงสัมพัทธ์
- เอฟเฟกต์ภาพ
- อัตราส่วน
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "สร้าง จัดรูปแบบ เชื่อมโยง ครอป สกัด และบีบอัดกรอบรูปภาพในงานนำเสนอด้วย Aspose.Slides สำหรับ Android ผ่าน Java."
---
## **ภาพรวม**

กรอบรูปภาพเป็นรูปร่างบนสไลด์ที่แสดงภาพหนึ่งภาพ ใน Aspose.Slides, แหล่งข้อมูลภาพและรูปร่างที่แสดงภาพนั้นเป็นวัตถุต่างกัน: [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) มีทรัพยากรภาพที่ฝังอยู่ผ่าน [IImageCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimagecollection/), ขณะที่ [IPictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipictureframe/) ควบคุมตำแหน่งของภาพ, ขนาด, การจัดรูปแบบเส้น, การหมุน, การครอป, เอฟเฟกต์รูปภาพ, และการตั้งค่าอื่น ๆ ระดับกรอบ

การแยกนี้มีประโยชน์เมื่อภาพเดียวกันแสดงหลายครั้ง เพิ่มภาพเข้าไปในงานนำเสนอเพียงครั้งเดียว, เก็บออบเจ็กต์ [IPPImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/) ที่คืนค่า, แล้วใช้แหล่งข้อมูลภาพนั้นเมื่อสร้างกรอบรูปภาพ

กรอบรูปภาพสามารถบรรจุภาพแบบราสเตอร์เช่น PNG หรือ JPEG และภาพเวกเตอร์ SVG ได้ นอกจากนี้ยังสามารถอ้างอิงถึงภาพที่เชื่อมโยงแทนการเก็บไบต์ของภาพไว้ในงานนำเสนอ ตัวเลือกนี้มีผลต่อความพกพา, ขนาดไฟล์, การสกัดและการส่งออก ดังนั้นจึงควรตัดสินใจว่าจะเก็บภาพอย่างไรก่อนทำการจัดรูปแบบหรือเพิ่มประสิทธิภาพ

## **เพิ่มและจัดรูปแบบภาพที่ฝังไว้**

สำหรับภาพที่ฝังไว้ ให้เพิ่มข้อมูลภาพเข้าไปในงานนำเสนอและสร้างกรอบรูปภาพด้วย [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-). ภาพจะกลายเป็นส่วนหนึ่งของแพคเกจงานนำเสนอ ดังนั้นงานนำเสนอจะคงเป็นอิสระเมื่อย้ายไปยังคอมพิวเตอร์เครื่องอื่น

ตัวอย่างต่อไปนี้เพิ่มภาพ JPEG, สร้างกรอบที่มีขนาดตามมิติพื้นฐานของภาพ, แล้วกำหนดการจัดรูปแบบเส้นและการหมุน:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pictureFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pictureFrame.getLineFormat().setWidth(3);
    pictureFrame.setRotation(15);

    presentation.save("picture-frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

กรอบรูปภาพควบคุมรูปทรงที่แสดง; การเปลี่ยนขนาดกรอบไม่ได้เปลี่ยนมิติพิกเซลดั้งเดิมที่เก็บอยู่ในแหล่งข้อมูลภาพที่ฝังไว้ ความแตกต่างนี้สำคัญเมื่อต้องครอปหรือบีบอัดภาพในภายหลัง

## **ใช้สเกลเชิงสัมพัทธ์**

[IPictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipictureframe/) เปิดให้ปรับสเกลความกว้างและความสูงเชิงสัมพันธ์ของกรอบผ่าน [setRelativeScaleWidth](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) และ [setRelativeScaleHeight](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-). ค่า `1.0` หมายถึง 100 % ของขนาดภาพต้นฉบับ สเกลเชิงสัมพันธ์มีประโยชน์เมื่อเวิร์กโฟลว์ต้องคงอัตราส่วนต่อขนาดภาพต้นแบบแทนการคำนวณขนาดสุดท้ายด้วยตนเอง

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image);
    pictureFrame.setRelativeScaleWidth(1.35f);
    pictureFrame.setRelativeScaleHeight(0.8f);

    presentation.save("relative-scale.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

การปรับสเกลเชิงสัมพันธ์เปลี่ยนการตั้งค่าสเกลของกรอบ; มันไม่ได้ทำการรีแซมป์หรือบีบอัดภาพที่ฝังไว้

## **ภาพที่ฝังไว้และภาพที่เชื่อมโยง**

ภาพที่ฝังไว้จะเก็บข้อมูลภาพภายในงานนำเสนอ จึงเป็นตัวเลือกที่ปลอดภัยที่สุดสำหรับความพกพาและการเรนเดอร์ที่คาดเดาได้ ส่วนภาพที่เชื่อมโยงจะเก็บตำแหน่งภายนอกผ่านเมธอด [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) แทนการฝังข้อมูลภาพแบบเดียวกัน

ภาพที่เชื่อมโยงสามารถลดปริมาณข้อมูลภาพที่เก็บในไฟล์ PPTX ได้แต่ทำให้เกิดการพึ่งพาไฟล์ภายนอก ไฟล์ที่เชื่อมโยงต้องยังคงเข้าถึงได้สำหรับแอปพลิเคชันที่เปิดหรือเรนเดอร์งานนำเสนอ หากเส้นทางเปลี่ยน, ไฟล์ถูกย้าย, หรือทรัพยากรไม่พร้อมใช้งาน, ภาพที่เชื่อมโยงอาจไม่แสดงตามที่คาดหวัง สำหรับงานนำเสนอที่ต้องการส่งอีเมล, เก็บเป็นไฟล์เก่า, หรือเรนเดอร์ในสภาพแวดล้อมแยก, ภาพที่ฝังไว้โดยทั่วไปจะเชื่อถือได้มากกว่า

### **เพิ่มภาพที่เชื่อมโยง**

ตัวอย่างต่อไปนี้สร้างกรอบรูปภาพและชี้ไปยังไฟล์ภาพภายในเครื่อง มุ่งเน้นเฉพาะการเชื่อมโยงภาพ; การเชื่อมโยงวิดีโอเป็นเวิร์กโฟลว์สื่อที่แยกออกจากกันและไม่ได้ผสมไว้ในตัวอย่างนี้

```java
import com.aspose.slides.*;
import java.io.File;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, null);
    File linkedImageFile = new File("linked-image.jpg");
    String linkPath = linkedImageFile.getAbsolutePath();
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong(linkPath);

    presentation.save("linked-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ใช้ลิงก์เมื่อการจัดการไฟล์ภายนอกเป็นเจตนา อย่าใช้เป็นวิธีทดแทนการบีบอัด: PPTX ขนาดเล็กที่มีการเชื่อมโยงภาพขัดข้องมักไม่มีประโยชน์เท่ากับงานนำเสนอที่มีขนาดใหญ่แต่เป็นอิสระ

## **สกัดภาพจากกรอบรูปภาพ**

ก่อนสกัดภาพจากงานนำเสนอที่มีอยู่, ตรวจสอบให้แน่ใจว่ารูปร่างเป็น [IPictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipictureframe/) จริงและมีภาพที่ฝังอยู่ กรอบรูปภาพที่เชื่อมโยงอาจไม่มีไบต์ของภาพที่สามารถสกัดได้ในลักษณะเดียวกัน

### **สกัดภาพราสเตอร์**

API ภาพสมัยใหม่ใช้ [IImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimage/) โดยตรงและไม่ต้องอาศัย Java wrapper รุ่นเก่า ตัวอย่างต่อไปนี้ค้นหาภาพราสเตอร์ที่ฝังอยู่เป็นภาพแรกบนสไลด์และบันทึกเป็น PNG

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IPictureFrame)) {
            continue;
        }

        IPictureFrame pictureFrame = (IPictureFrame) shape;
        IPPImage embeddedImage = pictureFrame.getPictureFormat().getPicture().getImage();
        if (embeddedImage == null || embeddedImage.getSvgImage() != null) {
            continue;
        }

        IImage rasterImage = embeddedImage.getImage();
        try {
            rasterImage.save("extracted-image.png", ImageFormat.Png);
        } finally {
            rasterImage.dispose();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

การบันทึกโดยใช้ [IImage.save](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) จะเปลี่ยนภาพที่สกัดเป็นรูปแบบผลลัพธ์ที่ร้องขอ หากต้องการไบต์ที่เข้ารหัสเก็บไว้ในงานนำเสนอแทนไฟล์ราสเตอร์ที่แปลงแล้ว, ให้ใช้ข้อมูลไบนารีของแหล่งภาพโดยตรง

### **สกัดภาพ SVG**

สำหรับภาพ SVG, [IPPImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/) เปิดให้เข้าถึงออบเจ็กต์ [ISvgImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isvgimage/) ซึ่งทำให้คุณดึงข้อมูล SVG โดยตรงแทนการทำเรสเตอร์ก่อน

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IPictureFrame)) {
            continue;
        }

        IPictureFrame pictureFrame = (IPictureFrame) shape;
        IPPImage embeddedImage = pictureFrame.getPictureFormat().getPicture().getImage();
        ISvgImage svgImage = embeddedImage != null ? embeddedImage.getSvgImage() : null;
        if (svgImage == null) {
            continue;
        }

        byte[] svgData = svgImage.getSvgData();
        FileOutputStream outputStream = new FileOutputStream("extracted-image.svg");
        try {
            outputStream.write(svgData);
        } finally {
            outputStream.close();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

การเก็บเนื้อหา SVG เป็น SVG จะรักษาแหล่งเวกเตอร์ไว้ในงานนำเสนอ การส่งออกเป็นราสเตอร์เช่น PNG หรือ JPEG จะต้องเรนเดอร์เวกเตอร์เป็นพิกเซล การส่งออกสไลด์เป็น PDF หรือ SVG ก็เป็นกระบวนการเรนเดอร์เช่นกัน ดังนั้นกราฟิกที่ส่งออกไม่ควรถือว่าเป็นสำเนาไบต์ต่อไบต์ของ SVG ที่ฝังไว้; ให้ใช้ข้อมูลที่ได้จาก [ISvgImage.getSvgData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isvgimage/#getSvgData--) เมื่อจำเป็นต้องใช้แหล่งเวกเตอร์ดั้งเดิม

## **ครอปภาพ**

การครอปรูปเปลี่ยนส่วนของภาพที่มองเห็นได้ภายในกรอบ ค่าโครปบน [IPictureFillFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipicturefillformat/) เป็นเปอร์เซ็นต์ของมิติภาพต้นฉบับ การครอปไม่ได้ลบพิกเซลที่ซ่อนไว้จากภาพที่ฝังไว้; มันเพียงเปลี่ยนพื้นที่ที่มองเห็น

ตัวอย่างต่อไปนี้ค้นหากรอบรูปภาพอย่างปลอดภัยและใช้ค่าโครป:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        pictureFrame.getPictureFormat().setCropLeft(23.6f);
        pictureFrame.getPictureFormat().setCropRight(21.5f);
        pictureFrame.getPictureFormat().setCropTop(3f);
        pictureFrame.getPictureFormat().setCropBottom(31f);
        presentation.save("cropped-image.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

เนื่องจากข้อมูลภาพที่ซ่อนอยู่ยังคงอยู่, สามารถเปลี่ยนค่าโครปภายหลังโดยไม่สูญเสียพิกเซลดั้งเดิม หากขนาดไฟล์เป็นข้อกำหนดสำคัญกว่าการกลับคืนค่า, พื้นที่ที่ครอปสามารถลบออกอย่างเป็นกายภาพตามที่อธิบายในส่วนถัดไป

## **ลบข้อมูลภาพที่ถูกครอป**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) จะลบข้อมูลภาพที่อยู่นอกสี่เหลี่ยมครอปปัจจุบันและคืนค่าแหล่งภาพที่ได้ผลลัพธ์ การทำเช่นนี้สามารถลดขนาดไฟล์ได้ แต่เป็นการเพิ่มประสิทธิภาพแบบทำลาย: หลังจากบันทึกงานนำเสนอแล้ว พิกเซลที่ถูกลบจะไม่มีให้ใช้สำหรับการทำ “uncrop” อีกต่อไป

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("cropped-image.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IPPImage croppedImage = pictureFrame.getPictureFormat().deletePictureCroppedAreas();
        if (croppedImage != null) {
            presentation.save("cropped-data-removed.pptx", SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

เมธอดอาจเพิ่มแหล่งภาพใหม่เข้าสู่งานนำเสนอ หากภาพต้นฉบับถูกใช้โดยกรอบรูปภาพอื่น ๆ อยู่, กรอบเหล่านั้นยังต้องใช้แหล่งเดิมของตน, ดังนั้นการลบพื้นที่ที่ครอปไม่ได้จำเป็นต้องลดจำนวนภาพทั้งหมด การครอปเนื้อหา WMF หรือ EMF ด้วยเมธอดนี้จะทำให้ผลลัพธ์ที่ครอปเป็น PNG

## **บีบอัดภาพราสเตอร์**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) ลดความละเอียดของภาพราสเตอร์ตามขนาดที่ภาพถูกแสดง มันสามารถลบพื้นที่ที่ครอปในขั้นตอนเดียวได้ เมธอดจะคืนค่า `true` เมื่อภาพถูกปรับขนาดหรือครอปและ `false` เมื่อไม่จำเป็นต้องเปลี่ยน

ใช้ค่า [PicturesCompression](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/picturescompression/) ที่กำหนดไว้ล่วงหน้าเมื่อความละเอียดเป้าหมายมาตรฐานเพียงพอ:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        boolean compressed = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);
        System.out.println(compressed ? "The image was compressed." : "No compression was necessary.");
        presentation.save("compressed-image.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

สามารถส่งค่าความละเอียด DPI เชิงบวกที่กำหนดเองแทนค่าที่กำหนดไว้ล่วงหน้าเมื่อจำเป็นต้องมีเป้าหมายเฉพาะ

การบีบอัดมีจุดประสงค์เพื่อภาพราสเตอร์ เท่านั้น เนื้อหา SVG และเมต้าไฟล์ไม่ถูกลดลงโดยเวิร์กโฟลว์การบีบอัดราสเตอร์นี้ นอกจากนี้จำไว้ว่า ความละเอียดต่ำและการลบพื้นที่ที่ครอปแล้วไม่สามารถกู้คืนจากงานนำเสนอที่ผ่านการเพิ่มประสิทธิภาพได้ เลือกความละเอียดเป้าหมายตามขนาดที่ภาพจะถูกดูหรือส่งออกจริง ๆ แทนการกำหนด DPI ต่ำสุดทั่วทั้งงานนำเสนอ

## **จัดการเอฟเฟกต์การแปลงภาพ**

สำหรับเวิร์กโฟลว์ครบถ้วนที่ครอบคลุมความสว่าง, ความคอนทราสต์, การแปลงสี, เบลอ, เอฟเฟกต์อัลฟ่า, เชนสั่ง, การตรวจสอบ, การลบ, และการตรวจสอบรอบ ๆ, ดูที่ [Image Transform Effects](/androidjava/image-transform-effects/)

## **ล็อกรูปทรงของกรอบรูปภาพ**

การตั้งค่าใน [IPictureFrameLock](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipictureframelock/) ควบคุมว่าการทำงานแก้ไขใดบ้างที่ถูกปิดใช้งานสำหรับกรอบรูปภาพ ตัวอย่างเช่น [setAspectRatioLocked](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) จะรักษาส่วนสัดส่วนของรูปร่างขณะปรับขนาด

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);

    presentation.save("locked-picture-frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

การล็อกมีผลกับรูปร่างของกรอบรูปภาพ ไม่ได้บังคับให้ภาพต้นฉบับต้องรีแซมพลหรือเปลี่ยนสัดส่วนอย่างถาวร

## **ปรับค่า StretchOffset**

เมื่อโหมดการเติมรูปเป็นแบบ stretch, ค่าการยืด-offset บน [IPictureFillFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipicturefillformat/) จะกำหนดสี่เหลี่ยมเติมสัมพันธ์กับกล่องขอบของกรอบรูปภาพ ค่าร้อยละบวกสร้างช่องว่างจากขอบ, ส่วนค่าร้อยละลบสร้างการขยายออก

นี่ต่างจากการครอป ค่าโครปเลือกส่วนของภาพต้นฉบับที่จะแสดง; ส่วนการยืด-offset ปรับสี่เหลี่ยมที่ภาพเติมจะถูกยืดให้เต็ม

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image);
    pictureFrame.getPictureFormat().setPictureFillMode(PictureFillMode.Stretch);
    pictureFrame.getPictureFormat().setStretchOffsetLeft(12f);
    pictureFrame.getPictureFormat().setStretchOffsetRight(12f);
    pictureFrame.getPictureFormat().setStretchOffsetTop(8f);
    pictureFrame.getPictureFormat().setStretchOffsetBottom(8f);

    presentation.save("stretch-offsets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ใช้การยืด-offset เพื่อกำหนดตำแหน่งการเติม ใช้คุณสมบัติการครอปเมื่อเป้าหมายคือซ่อนขอบของภาพต้นฉบับ

## **เรื่องการจัดเก็บ, ขนาดไฟล์, และการส่งออก**

การพิจารณาหลัก ๆ จะจัดการได้ง่ายขึ้นเมื่อการจัดเก็บภาพและการจัดรูปแบบกรอบรูปภาพถูกแยกออกจากกัน:

- **ภาพที่ฝังไว้** ทำให้งานนำเสนอเป็นอิสระและเป็นตัวเลือกที่เชื่อถือได้สูงสุดสำหรับการแชร์และการเรนเดอร์บนเซิร์ฟเวอร์ แต่ภาพราสเตอร์ขนาดใหญ่จะทำให้ไฟล์ PPTX ใหญ่ขึ้นและใช้หน่วยความจำมากขึ้น
- **ภาพที่เชื่อมโยง** สามารถทำให้แพคเกจมีขนาดเล็กลงได้ แต่การนำเสนอต้องพึ่งพาไฟล์ภายนอกที่ยังคงเข้าถึงได้ตามเส้นทางหรือที่ตั้งที่บันทึกไว้
- **การครอป** เริ่มต้นเป็นแบบไม่ทำลาย พิกเซลที่ซ่อนอยู่ยังคงฝังอยู่จนกว่าจะลบพื้นที่ที่ครอปออกโดยเจตนาหรือระหว่างการบีบอัด
- **การบีบอัด** สามารถลดขนาดไฟล์ได้อย่างมากสำหรับภาพราสเตอร์ขนาดใหญ่เกินไป แต่จะเสียความละเอียดต้นฉบับ ควรทำหลังจากทราบขนาดที่จะแสดงบนสไลด์แล้ว
- **ภาพ SVG** ควรคงอยู่เป็น SVG เมื่อความสมบูรณ์ของเวกเตอร์สำคัญ สกัด SVG ที่ฝังไว้โดยตรงเมื่อคุณต้องการแหล่งเวกเตอร์เอง การส่งออกสไลด์เป็นราสเตอร์จะเปลี่ยนสไลด์เป็นพิกเซลเสมอ
- **ภาพที่ใช้ซ้ำ** ควรใช้แหล่งภาพ [IPPImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/) เดิมเมื่อเป็นไปได้แทนการโหลดไฟล์เดียวกันหลายครั้งในเวิร์กโฟลว์ของงานนำเสนอ

สำหรับงานนำเสนอขนาดใหญ่ การเพิ่มประสิทธิภาพภาพมักจะได้ผลที่สุดเมื่อทำแบบเลือกใช้: เก็บโลโก้และแผนภาพเป็นเนื้อหาเวกเตอร์, บีบอัดภาพถ่ายตามขนาดการแสดงจริง, ลบพิกเซลที่ครอปเมื่อไม่ต้องการแก้ไขต่อ, และหลีกเลี่ยงลิงก์ภายนอกเว้นแต่การจัดการการพึ่งพาจะเป็นส่วนหนึ่งของการออกแบบการปรับใช้

## **คำถามที่พบบ่อย**

**กรอบรูปภาพต่างจากแหล่งข้อมูลภาพอย่างไร?**

[IPPImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/) แทนแหล่งข้อมูลภาพที่เชื่อมโยงกับงานนำเสนอ ส่วน [IPictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipictureframe/) เป็นรูปร่างบนสไลด์ที่แสดงภาพและเก็บเราจัดรูปแบบระดับกรอบ เช่น ขนาด, การหมุน, ค่าครอป, เอฟเฟกต์, และการล็อก

**ควรฝังภาพหรือเชื่อมโยงภาพ?**

ฝังภาพเมื่อจำเป็นต้องให้งานนำเสนอเป็นอิสระ, เก็บเป็นไฟล์เก่า, หรือเรนเดอร์โดยไม่ต้องพึ่งพาแหล่งภายนอก เชื่อมโยงภาพเฉพาะเมื่อต้องการเก็บไฟล์ภาพแยกจาก PPTX อย่างตั้งใจและสามารถดูแลตำแหน่งภายนอกได้อย่างเสถียร

**การครอปทำให้ไฟล์ PPTX เล็กลงหรือไม่?**

ไม่โดยตรง การตั้งค่าครอปทั่วไปจะซ่อนส่วนของภาพต้นฉบับแต่ยังคงเก็บพิกเซลไว้ ใช้ [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) หรือการบีบอัดพร้อมการลบพื้นที่ที่ครอปเมื่อพิกเซลดังกล่าวสามารถลบได้ถาวร

**สามารถกู้คืนคุณภาพภาพหลังการบีบอัดได้หรือไม่?**

ไม่ได้ การบีบอัดอาจลดความละเอียดของราสเตอร์และการลบพื้นที่ที่ครอปจะทำให้ข้อมูลภาพหายไป หากอาจต้องแก้ไขด้วยความละเอียดสูงในภายหลัง ควรเก็บภาพต้นฉบับแยกไว้เป็นไฟล์ภายนอก

**ควรจัดการกับภาพ SVG อย่างไร?**

เก็บเนื้อหา SVG เป็น SVG เมื่อความแม่นยำของเวกเตอร์สำคัญ สามารถสกัด [ISvgImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isvgimage/) ที่ฝังไว้โดยตรง การเรนเดอร์สไลด์เป็นรูปแบบราสเตอร์เช่น PNG หรือ JPEG จะทำให้ SVG ถูกเรนเดอร์เป็นพิกเซล

**จะหลีกเลี่ยงการแคสท์ที่ไม่ปลอดภัยเมื่ออ่านสไลด์ที่มีอยู่ได้อย่างไร?**

ตรวจสอบประเภทของรูปร่างก่อนใช้งานสมาชิกเฉพาะกรอบรูปภาพ การตรวจสอบ `instanceof` ต่อ [IPictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipictureframe/) จะป้องกันการแคสท์ที่ไม่ถูกต้องและช่วยให้โค้ดจัดการสไลด์ที่ไม่มีกรอบรูปภาพได้อย่างเหมาะสม