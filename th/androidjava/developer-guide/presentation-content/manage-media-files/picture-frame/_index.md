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
- ภาพฝัง
- ภาพที่เชื่อมโยง
- สกัดภาพ
- ภาพเรสเตอร์
- ภาพ SVG
- ครอปภาพ
- ลบพื้นที่ที่ครอป
- บีบอัดภาพ
- StretchOffset
- การจัดรูปแบบกรอบรูปภาพ
- สเกลสัมพัทธ์
- เอฟเฟกต์ภาพ
- อัตราส่วนภาพ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "สร้าง, จัดรูปแบบ, ลิงก์, ครอป, สกัด, และบีบอัดกรอบรูปภาพในงานนำเสนอด้วย Aspose.Slides สำหรับ Android ผ่าน Java."
---
## **ภาพรวม**

กรอบรูปภาพคือรูปทรงสไลด์ที่แสดงภาพ ใน Aspose.Slides, แหล่งข้อมูลภาพและรูปทรงที่แสดงภาพนั้นเป็นอ็อบเจกต์แยกกัน: [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) เป็นเจ้าของแหล่งข้อมูลภาพฝังผ่าน [IImageCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimagecollection/), ในขณะที่ [IPictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipictureframe/) ควบคุมตำแหน่ง ขนาด การจัดรูปแบบเส้น การหมุน การครอป เอฟเฟกต์ภาพ และการตั้งค่าอื่น ๆ ระดับกรอบ

การแยกนี้มีประโยชน์เมื่อภาพเดียวกันถูกแสดงหลายครั้ง เพิ่มภาพลงในงานนำเสนอเพียงครั้งเดียว เก็บ [IPPImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/) ที่ส่งกลับมาไว้ แล้วใช้แหล่งข้อมูลภาพนั้นเมื่อสร้างกรอบรูปภาพ

กรอบรูปภาพสามารถบรรจุภาพเรสเตอร์เช่น PNG หรือ JPEG และภาพเวกเตอร์ SVG ได้ นอกจากนี้ยังสามารถอ้างอิงภาพที่ลิงก์แทนการจัดเก็บไบต์ของภาพไว้ในงานนำเสนอ ตัวเลือกนี้ส่งผลต่อการพกพา ขนาดไฟล์ การสกัดและพฤติกรรมการส่งออก ดังนั้นควรตัดสินใจว่าเก็บภาพอย่างไรก่อนทำการจัดรูปแบบหรือเพิ่มประสิทธิภาพ

## **เพิ่มและจัดรูปแบบภาพฝัง**

สำหรับภาพฝัง ให้เพิ่มข้อมูลภาพลงในงานนำเสนอและสร้างกรอบรูปภาพด้วย [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-)  ภาพจะกลายเป็นส่วนหนึ่งของแพ็กเกจงานนำเสนอ ดังนั้นงานนำเสนอจะคงเป็นอิสระเมื่อนำไปย้ายไปยังคอมพิวเตอร์เครื่องอื่น

ตัวอย่างต่อไปนี้เพิ่มภาพ JPEG สร้างกรอบที่มีขนาดตามมิติดั้งเดิมของภาพ และใช้การจัดรูปแบบเส้นและการหมุน:

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

กรอบรูปภาพควบคุมรูปทรงที่แสดง; การเปลี่ยนขนาดกรอบไม่ทำให้มิตพิกเซลดั้งเดิมที่เก็บในแหล่งข้อมูลภาพฝังเปลี่ยนแปลง ความแตกต่างนี้สำคัญเมื่อทำการครอปหรือบีบอัดภาพในภายหลัง

## **ใช้สเกลสัมพัทธ์**

[IPictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipictureframe/) เปิดเผยการสเกลความกว้างและความสูงสัมพัทธ์ของกรอบผ่าน [setRelativeScaleWidth](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) และ [setRelativeScaleHeight](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-)  ค่าที่เป็น `1.0` แทน 100% ของขนาดภาพต้นฉบับ สเกลสัมพัทธ์มีประโยชน์เมื่อกระบวนการทำงานต้องการรักษาความสัมพันธ์กับขนาดภาพต้นฉบับแทนการคำนวณมิติสุดท้ายด้วยตนเอง

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

สเกลสัมพัทธ์เปลี่ยนการตั้งค่าขนาดของกรอบ; ไม่ทำการรีแซมเปิลหรือบีบอัดภาพฝัง

## **ภาพฝังและภาพที่ลิงก์**

ภาพฝังเก็บข้อมูลภาพภายในงานนำเสนอและจึงเป็นตัวเลือกที่ปลอดภัยที่สุดสำหรับการพกพาและการเรนเดอร์ที่คาดเดาได้ ภาพที่ลิงก์เก็บตำแหน่งภายนอกผ่านวิธีการ [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) แทนการฝังข้อมูลภาพในลักษณะเดียวกัน

ภาพที่ลิงก์สามารถลดปริมาณข้อมูลภาพที่เก็บใน PPTX ได้ แต่จะสร้างการพึ่งพาไฟล์ภายนอก ไฟล์ที่ลิงก์ต้องสามารถเข้าถึงได้โดยแอปพลิเคชันที่เปิดหรือเรนเดอร์งานนำเสนอ หากเส้นทางเปลี่ยน ไฟล์ถูกย้าย หรือแหล่งข้อมูลไม่พร้อมใช้งาน ภาพที่ลิงก์อาจไม่แสดงตามที่คาดหวัง สำหรับงานนำเสนอที่ต้องส่งอีเมล เก็บถาวร หรือเรนเดอร์ในสภาพแวดล้อมแยกกัน ภาพฝังคือทางเลือกที่เชื่อถือได้มากกว่า

### **เพิ่มภาพที่ลิงก์**

ตัวอย่างต่อไปนี้สร้างกรอบรูปภาพและชี้ไปยังไฟล์ภาพในเครื่องเท่านั้น มุ่งเน้นที่การลิงก์ภาพ; การลิงก์วิดีโอเป็นกระบวนการสื่อแบบแยกต่างหากและไม่ได้ผสมเข้ากับตัวอย่างนี้โดยเจตนา

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

ใช้ลิงก์เมื่อการจัดการไฟล์ภายนอกเป็นเจตนาที่ตั้งใจ อย่าใช้เป็นการแทนที่การบีบอัด: PPTX ขนาดเล็กที่มีการพึ่งพาภาพเสียหายมักจะใช้งานได้น้อยกว่าการนำเสนอที่มีขนาดใหญ่และเป็นอิสระ

## **สกัดภาพจากกรอบรูปภาพ**

ก่อนที่จะสกัดภาพจากงานนำเสนอที่มีอยู่ ตรวจสอบว่ารูปทรงเป็น [IPictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipictureframe/) จริง ๆ และว่ามีภาพฝังอยู่หรือไม่ กรอบรูปภาพที่ลิงก์อาจไม่มีไบต์ภาพที่สามารถสกัดได้ในลักษณะเดียวกัน

### **สกัดภาพเรสเตอร์**

API ภาพสมัยใหม่ใช้ [IImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimage/) โดยตรงและไม่จำเป็นต้องใช้ wrapper ของ Java รุ่นเก่า ตัวอย่างต่อไปนี้ค้นหาภาพเรสเตอร์ฝังตัวแรกบนสไลด์และบันทึกเป็น PNG:

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

การบันทึกผ่าน [IImage.save](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) จะแปลงภาพที่สกัดเป็นรูปแบบผลลัพธ์ที่ร้องขอ หากต้องการไบต์ที่เข้ารหัสเก็บไว้ในงานนำเสนอแทนไฟล์เรสเตอร์ที่แปลงแล้ว ให้ใช้ข้อมูลไบนารีของแหล่งภาพแทน

### **สกัดภาพ SVG**

สำหรับภาพ SVG, [IPPImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/) เปิดเผยอ็อบเจกต์ [ISvgImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isvgimage/) ซึ่งทำให้คุณดึงข้อมูล SVG ได้โดยตรงแทนการเรสเตอร์ไอคอนก่อน

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

การเก็บเนื้อหา SVG เป็น SVG จะคงแหล่งเวกเตอร์ภายในงานนำเสนอ การส่งออกเรสเตอร์เช่น PNG หรือ JPEG จำเป็นต้องเรนเดอร์เวกเตอร์นั้นเป็นพิกเซล การส่งออกสไลด์เป็น PDF หรือ SVG ก็เป็นการเรนเดอร์เช่นกัน ดังนั้นกราฟิกที่ส่งออกไม่ควรถูกมองว่าเป็นสำเนาไบต์ต่อไบต์ของ SVG ฝังต้นฉบับ; ให้ใช้ข้อมูลจาก [ISvgImage.getSvgData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isvgimage/#getSvgData--) เมื่อต้องการแหล่งเวกเตอร์เดิม

## **ครอปภาพ**

การครอปเปลี่ยนส่วนของภาพที่มองเห็นได้ภายในกรอบ ค่าแบบครอปบน [IPictureFillFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipicturefillformat/) เป็นเปอร์เซ็นต์ของมิตภาพต้นฉบับ การครอปไม่ลบพิกเซลที่ซ่อนอยู่จากภาพฝัง; เพียงเปลี่ยนพื้นที่ที่มองเห็นเท่านั้น

ตัวอย่างต่อไปนี้ค้นหากรอบรูปภาพอย่างปลอดภัยและใช้ค่าแบบครอป:

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

เนื่องจากข้อมูลภาพที่ซ่อนอยู่ยังคงอยู่ การครอปสามารถแก้ไขได้ในภายหลังโดยไม่สูญเสียพิกเซลต้นฉบับ หากขนาดไฟล์มีความสำคัญมากกว่าการย้อนกลับ พื้นที่ครอปสามารถลบออกได้ตามที่อธิบายในส่วนต่อไป

## **ลบข้อมูลภาพที่ถูกครอป**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) จะลบข้อมูลภาพที่อยู่นอกสี่เหลี่ยมครอปปัจจุบันและคืนค่าแหล่งภาพที่เหลือ วิธีนี้สามารถลดขนาดไฟล์ได้ แต่เป็นการเพิ่มประสิทธิภาพที่ทำลาย: หลังจากบันทึกงานนำเสนอแล้ว พิกเซลที่ถูกลบจะไม่มีอยู่เพื่อทำการยกเลิกครอปในภายหลัง

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

เมธอดนี้อาจเพิ่มแหล่งภาพใหม่เข้าไปในงานนำเสนอ หากภาพต้นฉบับถูกใช้โดยกรอบรูปภาพอื่น ๆ กรอบเหล่านั้นยังต้องการแหล่งเดิมอยู่ ดังนั้นการลบพื้นที่ที่ครอปไม่จำเป็นต้องลดจำนวนภาพทั้งหมด การครอปเนื้อหา WMF หรือ EMF ด้วยวิธีนี้จะทำให้ผลลัพธ์ที่ครอปถูกเรสเตอร์เป็น PNG

## **บีบอัดภาพเรสเตอร์**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) ลดความละเอียดของภาพเรสเตอร์สัมพันธ์กับขนาดที่ภาพแสดง มันยังสามารถลบพื้นที่ที่ครอปในขั้นตอนเดียวได้ เมธอดจะคืนค่า `true` เมื่อภาพถูกปรับขนาดหรือครอป และ `false` เมื่อไม่จำเป็นต้องเปลี่ยนแปลง

ใช้ค่าที่กำหนดไว้ล่วงหน้าใน [PicturesCompression](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/picturescompression/) เมื่อความละเอียดเป้าหมายมาตรฐานเพียงพอ:

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

สามารถส่งค่าความละเอียด DPI บวกแบบกำหนดเองแทนค่าที่กำหนดไว้ล่วงหน้าเมื่อจำเป็นต้องมีเป้าหมายเฉพาะ

การบีบอัดมุ่งเน้นที่ภาพเรสเตอร์; เนื้อหา SVG และเมตาไฟล์จะไม่ถูกลดลงด้วยกระบวนการบีบอัดนี้ อีกทั้งจำไว้ว่า ความละเอียดที่ต่ำลงและการลบพื้นที่ที่ครอปไม่สามารถกู้คืนจากงานนำเสนอที่เพิ่มประสิทธิภาพได้ เลือกความละเอียดเป้าหมายตามขนาดสูงสุดที่ภาพจะถูกดูหรือส่งออกจริง ไม่ใช่การใช้ DPI ต่ำสุดทั่วถึง

## **จัดการเอฟเฟกต์การแปลงภาพ**

สำหรับกระบวนการทำงานที่ครอบคลุมความสว่าง ความคอนทราสต์ การแปลงสี เบลอ เอฟเฟกต์แอลฟา เชนที่จัดลำดับ การตรวจสอบ การลบ และการตรวจสอบรอบเดียว ดูที่ [Image Transform Effects](/slides/th/androidjava/image-transform-effects/)

## **ล็อกเรขาคณิตของกรอบรูปภาพ**

การตั้งค่าใน [IPictureFrameLock](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipictureframelock/) ควบคุมว่าการดำเนินการแก้ไขใดถูกปิดการใช้งานสำหรับกรอบรูปภาพ ตัวอย่างเช่น [setAspectRatioLocked](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) จะคงอัตราส่วนของรูปทรงขณะเปลี่ยนขนาด

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

การล็อกนี้มีผลต่อรูปทรงกรอบรูปภาพ ไม่ได้บังคับให้ภาพต้นฉบับถูกรีแซมเปิลหรือเปลี่ยนอัตราส่วนถาวร

## **ปรับค่า StretchOffset**

เมื่อโหมดการเติมรูปภาพเป็น stretch, ค่าตำแหน่ง stretch‑offset บน [IPictureFillFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipicturefillformat/) จะกำหนดสี่เหลี่ยมเติมสัมพันธ์กับกล่องขอบของกรอบรูปภาพ เปอร์เซ็นต์บวกจะสร้างการเว้นจากขอบ, ส่วนเปอร์เซ็นต์ลบจะสร้างการขยายออก

นี่ต่างจากการครอป ค่าแบบครอปเลือกส่วนของภาพต้นฉบับที่มองเห็น; stretch‑offset เปลี่ยนสี่เหลี่ยมที่ภาพเติมจะถูกยืดขยายไป

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

ใช้ stretch‑offset สำหรับการวางตำแหน่งการเติม ใช้คุณสมบัติการครอปเมื่อเป้าหมายคือการซ่อนขอบของภาพต้นฉบับ

## **การจัดเก็บ, ขนาดไฟล์, และข้อพิจารณาการส่งออก**

การแลกเปลี่ยนหลักจัดการได้ง่ายเมื่อการจัดเก็บภาพและการจัดรูปแบบกรอบรูปภาพถูกแยกออกจากกัน:

- **ภาพฝัง** ทำให้งานนำเสนอเป็นอิสระและเป็นทางเลือกที่เชื่อถือได้ที่สุดสำหรับการแชร์และการเรนเดอร์บนเซิร์ฟเวอร์ แต่ภาพเรสเตอร์ขนาดใหญ่จะเพิ่มขนาด PPTX และการใช้หน่วยความจำ
- **ภาพที่ลิงก์** สามารถทำให้แพ็คเกจมีขนาดเล็กลง, แต่การนำเสนอขึ้นกับไฟล์ภายนอกที่ต้องคงอยู่ที่เส้นทางหรือสถานที่ที่จัดเก็บไว้
- **การครอป** เริ่มต้นเป็นแบบไม่ทำลาย; พิกเซลที่ซ่อนยังคงฝังอยู่จนกว่าจะลบพื้นที่ที่ครอปโดยเจตนาหรือระหว่างการบีบอัด
- **การบีบอัด** สามารถลดขนาดไฟล์ได้อย่างมากสำหรับภาพเรสเตอร์ที่ใหญ่เกินไป, แต่จะเสียความละเอียดของแหล่งต้นฉบับ ควรทำหลังจากทราบขนาดที่จะแสดงบนสไลด์แล้ว
- **ภาพ SVG** ควรคงเป็น SVG เมื่อการรักษาเวกเตอร์สำคัญ; สกัด SVG ฝังโดยตรงเมื่อต้องการแหล่งเวกเตอร์เอง การส่งออกสไลด์เป็นเรสเตอร์จะเปลี่ยนสไลด์ที่เรนเดอร์เป็นพิกเซลเสมอ
- **ภาพที่ใชซ้ำ** ควรใช้แหล่ง [IPPImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/) ที่มีอยู่แล้วเมื่อเป็นไปได้ แทนการโหลดไฟล์เดียวกันหลายครั้งในกระบวนการทำงานของงานนำเสนอ

สำหรับงานนำเสนอขนาดใหญ่ การเพิ่มประสิทธิภาพภาพมักจะมีประสิทธิผลมากที่สุดเมื่อทำแบบเลือกเฉพาะ: เก็บโลโก้และแผนภาพเป็นเนื้อหาเวกเตอร์, บีบอัดภาพถ่ายตามขนาดการแสดงจริง, ลบพิกเซลที่ครอปเฉพาะเมื่อไม่ต้องการการแก้ไขต่อภายหลัง, และหลีกเลี่ยงลิงก์ภายนอกเว้นแต่การจัดการการพึ่งพาจะเป็นส่วนหนึ่งของการออกแบบการปรับใช้

## **FAQ**

**ความแตกต่างระหว่างกรอบรูปภาพและแหล่งข้อมูลภาพคืออะไร?**

[IPPImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/) แสดงถึงแหล่งข้อมูลภาพที่เชื่อมโยงกับงานนำเสนอ ส่วน [IPictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipictureframe/) เป็นรูปทรงบนสไลด์ที่แสดงภาพและเก็บเรขาคณิตและการจัดรูปแบบระดับกรอบ เช่น ขนาด, การหมุน, ค่าแบบครอป, เอฟเฟกต์และการล็อก

**ควรฝังหรือเชื่อมโยงภาพ?**

ฝังภาพเมื่อการนำเสนอจำเป็นต้องพกพา, เก็บถาวร หรือเรนเดอร์โดยไม่ต้องอ้างอิงแหล่งภายนอก เชื่อมโยงภาพเฉพาะเมื่อต้องการเก็บไฟล์ภาพออกจาก PPTX อย่างตั้งใจและตำแหน่งภายนอกสามารถดูแลได้อย่างน่าเชื่อถือ

**การครอปลดขนาดไฟล์ PPTX หรือไม่?**

ไม่โดยตรง การตั้งค่าครอปปกติจะซ่อนส่วนของภาพต้นฉบับแต่ยังคงเก็บพิกเซลไว้ ใช้ [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) หรือบีบอัดภาพพร้อมการลบพื้นที่ที่ครอปเมื่อพิกเซลเหล่านั้นสามารถละทิ้งได้อย่างถาวร

**สามารถคืนคุณภาพของภาพหลังบีบอัดได้หรือไม่?**

ไม่ การบีบอัดอาจลดความละเอียดเรสเตอร์ที่เก็บไว้และการลบพื้นที่ที่ครอปจะทำให้ข้อมูลภาพหายไป หากอาจต้องการการแก้ไขความละเอียดสูงในภายหลัง ควรเก็บภาพต้นฉบับแยกนอกงานนำเสนอ

**ควรจัดการกับภาพ SVG อย่างไร?**

เก็บเนื้อหา SVG เป็น SVG เมื่อความแม่นยำของเวกเตอร์สำคัญ [ISvgImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isvgimage/) ที่ฝังสามารถสกัดได้โดยตรง การเรนเดอร์สไลด์เป็นรูปแบบเรสเตอร์เช่น PNG หรือ JPEG จะทำให้ SVG เป็นพิกเซล การส่งออกสไลด์เป็น PDF หรือ SVG ก็เป็นการเรนเดอร์เช่นกัน

**จะหลีกเลี่ยงการแคสต์ที่ไม่ปลอดภัยเมื่ออ่านสไลด์ที่มีอยู่ได้อย่างไร?**

ตรวจสอบประเภทของรูปทรงก่อนใช้สมาชิกเฉพาะกรอบรูปภาพ การตรวจสอบ `instanceof` กับ [IPictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipictureframe/) จะหลีกเลี่ยงการแคสต์ที่ไม่ถูกต้องและให้โค้ดจัดการกับสไลด์ที่ไม่มีกรอบรูปภาพได้อย่างเหมาะสม.