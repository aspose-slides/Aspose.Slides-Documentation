---
title: จัดการกรอบรูปภาพในงานนำเสนอด้วย Java
linktitle: กรอบรูปภาพ
type: docs
weight: 10
url: /th/java/picture-frame/
keywords:
- กรอบรูปภาพ
- เพิ่มกรอบรูปภาพ
- สร้างกรอบรูปภาพ
- ภาพฝังไว้
- ภาพเชื่อมโยง
- สกัดภาพ
- ภาพราสเตอร์
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
- Java
- Aspose.Slides
description: "สร้าง, จัดรูปแบบ, เชื่อมโยง, ครอป, สกัด, และบีบอัดกรอบรูปภาพในงานนำเสนอด้วย Aspose.Slides สำหรับ Java."
---
## **ภาพรวม**

กรอบรูปภาพเป็นรูปทรงบนสไลด์ที่ใช้แสดงภาพ ใน Aspose.Slides แหล่งภาพและรูปทรงที่แสดงภาพเป็นอ็อบเจกต์ที่แยกจากกัน: [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) ถือแหล่งภาพที่ฝังอยู่ผ่าน [IImageCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimagecollection/) ในขณะที่ [IPictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipictureframe/) ควบคุมตำแหน่ง ขนาด การจัดรูปแบบเส้น การหมุน การครอป เอฟเฟกต์ภาพ และการตั้งค่าระดับกรอบอื่น ๆ

การแยกนี้มีประโยชน์เมื่อภาพเดียวกันต้องแสดงหลายครั้ง เพิ่มภาพลงในงานนำเสนอเพียงครั้งเดียว เก็บ [IPPImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/ippimage/) ที่ได้รับคืนไว้ และใช้แหล่งภาพนั้นเมื่อสร้างกรอบรูปภาพ

กรอบรูปภาพสามารถบรรจุภาพราสเตอร์เช่น PNG หรือ JPEG และภาพเวกเตอร์ SVG ได้ อีกทั้งยังสามารถอ้างอิงถึงภาพที่เชื่อมโยงแทนการเก็บข้อมูลไบต์ของภาพในงานนำเสนอ ตัวเลือกนี้ส่งผลต่อความพกพา ขนาดไฟล์ การสกัดข้อมูล และพฤติกรรมการส่งออก ดังนั้นจึงควรตัดสินใจว่าต้องการเก็บภาพอย่างไรก่อนทำการจัดรูปแบบหรือการปรับแต่ง

## **เพิ่มและจัดรูปแบบภาพฝังไว้**

สำหรับภาพฝังไว้ ให้เพิ่มข้อมูลภาพลงในงานนำเสนอและสร้างกรอบรูปภาพด้วย [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) ภาพจะกลายเป็นส่วนหนึ่งของแพ็คเกจงานนำเสนอ ดังนั้นงานนำเสนอจะยังคงเป็นอิสระเมื่อย้ายไปยังคอมพิวเตอร์เครื่องอื่น

ตัวอย่างต่อไปนี้เพิ่มภาพ JPEG สร้างกรอบที่มีขนาดตามมิติดั้งเดิมของภาพ และใช้การจัดรูปแบบเส้นพร้อมการหมุน:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

กรอบรูปภาพควบคุมรูปร่างที่แสดง; การเปลี่ยนขนาดกรอบไม่ได้เปลี่ยนมิติพิกเซลดั้งเดิมที่เก็บในแหล่งภาพฝังไว้ ความแตกต่างนี้สำคัญเมื่อต้องทำการครอปหรือบีบอัดภาพในภายหลัง

## **ใช้สเกลสัมพัทธ์**

[IPictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipictureframe/) เปิดให้กำหนดสเกลความกว้างและสูงสัมพัทธ์ของกรอบผ่าน [setRelativeScaleWidth](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) และ [setRelativeScaleHeight](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-) ค่า `1.0` หมายถึง 100 % ของขนาดภาพต้นฉบับ สเกลสัมพัทธ์เป็นประโยชน์เมื่อเวิร์กโฟลว์ต้องคงอัตราส่วนต่อขนาดภาพต้นฉบับแทนการคำนวณขนาดสุดท้ายด้วยตนเอง

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

การเปลี่ยนสเกลสัมพัทธ์จะปรับตั้งค่าการสเกลของกรอบ; มันไม่ได้ทำการรีแซมปล์หรือบีบอัดภาพฝังไว้

## **ภาพฝังและภาพเชื่อมโยง**

ภาพฝังไว้เก็บข้อมูลภาพภายในงานนำเสนอและจึงเป็นตัวเลือกที่ปลอดภัยที่สุดสำหรับความพกพาและการแสดงผลที่คาดการณ์ได้ ภาพเชื่อมโยงจะเก็บตำแหน่งภายนอกผ่านเมธอด [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/th/java/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) แทนการฝังข้อมูลภาพแบบเดียวกัน

ภาพเชื่อมโยงอาจลดปริมาณข้อมูลภาพที่เก็บใน PPTX ได้ แต่ต้องพึ่งพาความพร้อมใช้งานของไฟล์ภายนอก หากเส้นทางเปลี่ยน ไฟล์ถูกย้าย หรือแหล่งข้อมูลไม่พร้อมใช้งาน ภาพเชื่อมโยงอาจไม่แสดงตามคาด สำหรับงานนำเสนอที่ต้องส่งอีเมล ถูกรักษาเป็นไฟล์เก่า หรือแสดงผลในสภาพแวดล้อมที่แยกออกจากกัน ภาพฝังไว้มักจะเชื่อถือได้มากกว่า

### **เพิ่มภาพเชื่อมโยง**

ตัวอย่างต่อไปนี้สร้างกรอบรูปภาพและชี้ไปที่ไฟล์ภาพในเครื่องเท่านั้น โดยมุ่งเน้นที่การเชื่อมโยงภาพเท่านั้น; การเชื่อมโยงวิดีโอเป็นเวิร์กโฟลว์สื่อแยกต่างหากและไม่ได้รวมไว้ในตัวอย่างนี้

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

ใช้ลิงก์เมื่อการจัดการไฟล์ภายนอกเป็นเจตนา ไม่ควรใช้เพื่อแทนที่การบีบอัด: PPTX ที่มีลิงก์เสียหายมักจะใช้งานได้น้อยกว่าไฟล์ที่มีขนาดใหญ่แต่เป็นอิสระ

## **สกัดภาพจากกรอบรูปภาพ**

ก่อนสกัดภาพจากงานนำเสนอที่มีอยู่ ควรตรวจสอบว่ารูปร่างเป็น [IPictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipictureframe/) จริง ๆ และว่ามีภาพฝังอยู่หรือไม่ กรอบรูปภาพที่เชื่อมโยงอาจไม่มีไบต์ของภาพที่สามารถสกัดได้ในลักษณะเดียวกัน

### **สกัดภาพราสเตอร์**

API ภาพสมัยใหม่ใช้ [IImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimage/) โดยตรงและไม่ต้องอาศัยตัวห่อภาพ Java เวอร์ชันเก่า ตัวอย่างต่อไปนี้ค้นหาภาพราสเตอร์ฝังแรกบนสไลด์และบันทึกเป็น PNG:

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

การบันทึกผ่าน [IImage.save](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimage/#save-java.lang.String-int-) จะเปลี่ยนภาพที่สกัดเป็นรูปแบบผลลัพธ์ที่ร้องขอ หากต้องการไบต์ที่เข้ารหัสเก็บในงานนำเสนอแทนไฟล์ราสเตอร์ที่แปลงแล้ว ให้ใช้ข้อมูลไบต์ของแหล่งภาพโดยตรง

### **สกัดภาพ SVG**

สำหรับภาพ SVG, [IPPImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/ippimage/) เปิดให้เข้าถึงอ็อบเจกต์ [ISvgImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/isvgimage/) ซึ่งทำให้สามารถดึงข้อมูล SVG ได้โดยตรงโดยไม่ต้องเรสเตอร์ไอภาพก่อน

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

การเก็บเนื้อหา SVG เป็น SVG คงความเป็นเวกเตอร์ภายในงานนำเสนอ การส่งออกเป็นราสเตอร์ เช่น PNG หรือ JPEG จะต้องเรสเตอร์เนื้อหาเวกเตอร์นั้น PDF หรือการส่งออกสไลด์เป็น SVG ก็เป็นการเรสเตอร์เช่นกัน ดังนั้นกราฟิกที่ส่งออกไม่ควรถือว่าเป็นสำเนาไบต์ต่อไบต์ของ SVG ดั้งเดิม; ใช้ข้อมูลจาก [ISvgImage.getSvgData](https://reference.aspose.com/slides/th/java/com.aspose.slides/isvgimage/#getSvgData--) เมื่อจำเป็นต้องใช้แหล่งเวกเตอร์ต้นฉบับ

## **ครอปภาพ**

การครอปเปลี่ยนส่วนที่มองเห็นของภาพภายในกรอบ ค่าเดิมบน [IPictureFillFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipicturefillformat/) เป็นเปอร์เซ็นต์ของมิติภาพต้นฉบับ การครอปไม่ได้ลบพิกเซลที่ซ่อนอยู่จากภาพฝังไว้; มันเพียงเปลี่ยนบริเวณที่แสดงเท่านั้น

ตัวอย่างต่อไปนี้ค้นหากรอบรูปภาพอย่างปลอดภัยและใช้ค่าครอป:

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

เนื่องจากข้อมูลภาพที่ซ่อนยังคงอยู่ การครอปสามารถเปลี่ยนแปลงได้ภายหลังโดยไม่สูญเสียพิกเซลต้นฉบับ หากขนาดไฟล์สำคัญกว่าการกู้คืน ภาพที่ครอปแล้วสามารถลบออกได้ตามที่อธิบายในส่วนต่อไป

## **ลบข้อมูลภาพที่ครอปไว้**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) จะลบข้อมูลภาพที่อยู่นอกสี่เหลี่ยมครอปปัจจุบันและคืนแหล่งภาพที่เหลือ ซึ่งสามารถลดขนาดไฟล์ได้ แต่เป็นการปรับแต่งที่ทำลายข้อมูล: หลังจากบันทึกงานนำเสนอ พิกเซลที่ถูกลบจะไม่มีให้ทำการยกเลิกครอปในภายหลัง

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

เมธอดนี้อาจเพิ่มแหล่งภาพใหม่ลงในงานนำเสนอ หากภาพต้นฉบับยังถูกใช้โดยกรอบรูปภาพอื่น ๆ กรอบเหล่านั้นยังต้องใช้แหล่งเดิม ดังนั้นการลบพื้นที่ครอปไม่จำเป็นต้องลดจำนวนภาพทั้งหมด การครอป WMF หรือ EMF ด้วยเมธอดนี้จะทำให้ผลลัพธ์ที่ครอปเป็น PNG

## **บีบอัดภาพราสเตอร์**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) ลดความละเอียดของภาพราสเตอร์เทียบกับขนาดที่ภาพปรากฎบนสไลด์ สามารถลบส่วนที่ครอปได้ในขั้นตอนเดียว เมธอดจะคืนค่า `true` เมื่อภาพถูกปรับขนาดหรือครอป และ `false` เมื่อไม่ต้องเปลี่ยนแปลงใด ๆ

ใช้ค่า [PicturesCompression](https://reference.aspose.com/slides/th/java/com.aspose.slides/picturescompression/) ที่กำหนดไว้ล่วงหน้าหากความละเอียดเป้าหมายมาตรฐานเพียงพอ:

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

สามารถส่งค่า DPI บวกที่กำหนดเองแทนค่าที่กำหนดไว้ล่วงหน้าเมื่อจำเป็นต้องมีเป้าหมายเฉพาะ

การบีบอัดมุ่งเน้นที่ภาพราสเตอร์; เนื้อหา SVG และเมต้าไฟล์จะไม่ได้รับผลจากการบีบอัดราสเตอร์นี้ อีกทั้งจำไว้ว่า ความละเอียดที่ต่ำลงและการลบส่วนที่ครอปไม่สามารถกู้คืนจากงานนำเสนอที่ปรับแต่งแล้ว ควรเลือกความละเอียดเป้าหมายตามขนาดการดูหรือส่งออกที่ใหญ่ที่สุดที่ภาพจะถูกแสดงจริง ๆ แทนการใช้ DPI ต่ำสุดทั่วทั้งไฟล์

## **จัดการเอฟเฟกต์การแปลงภาพ**

สำหรับเวิร์กโฟลว์เต็มรูปแบบที่ครอบคลุมความสว่าง คอนทราสต์ การแปลงสี เบลอ เอฟเฟกต์อัลฟา สายงานที่จัดลำดับ การตรวจสอบ การลบ และการตรวจสอบรอบต่อรอบ ดูที่ [Image Transform Effects](/slides/th/java/image-transform-effects/)

## **ล็อกรูปทรงกรอบรูปภาพ**

การตั้งค่าใน [IPictureFrameLock](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipictureframelock/) ควบคุมว่าการแก้ไขใดบ้างจะถูกปิดใช้งานสำหรับกรอบรูปภาพ ตัวอย่างเช่น [setAspectRatioLocked](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) จะรักษาอัตราส่วนของรูปทรงขณะเปลี่ยนขนาด

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

การล็อกนี้ใช้กับรูปทรงกรอบรูปภาพ ไม่ได้บังคับให้ภาพต้นฉบับต้องรีแซมปล์หรือเปลี่ยนอัตราส่วนอย่างถาวร

## **ปรับค่าการขยาย StretchOffset**

เมื่อโหมดเติมรูปเป็นการขยาย ค่าการขยาย‑offset บน [IPictureFillFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipicturefillformat/) จะกำหนดสี่เหลี่ยมเติมสัมพันธ์กับกล่องขอบของกรอบรูปภาพ เปอร์เซ็นต์บวกจะสร้างการเว้นระยะจากขอบ ส่วนเปอร์เซ็นต์ลบจะสร้างการขยายออก

สิ่งนี้ต่างจากการครอป ค่า crop จะเลือกส่วนของภาพต้นฉบับที่ต้องการให้มองเห็น ส่วน stretch offset จะเปลี่ยนสี่เหลี่ยมที่ภาพเติมถูกขยายเข้าไป

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

ใช้ stretch offset เพื่อจัดตำแหน่งการเติม ใช้คุณสมบัติ crop เมื่อต้องการซ่อนขอบของภาพต้นฉบับ

## **การจัดเก็บ ขนาดไฟล์ และการพิจารณาการส่งออก**

การพิจารณาตัวเลือกหลักจะง่ายขึ้นเมื่อการจัดเก็บภาพและการจัดรูปแบบกรอบรูปภาพแยกกัน:

- **ภาพฝังไว้** ทำให้งานนำเสนอเป็นอิสระและเป็นทางเลือกที่เชื่อถือได้ที่สุดสำหรับการแชร์และการเรนเดอร์บนเซิร์ฟเวอร์ แต่ภาพราสเตอร์ขนาดใหญ่จะเพิ่มขนาด PPTX และการใช้หน่วยความจำ
- **ภาพเชื่อมโยง** สามารถทำให้แพ็คเกจมีขนาดเล็กลงได้ แต่งานนำเสนอจะพึ่งพาไฟล์ภายนอกที่ต้องยังคงเข้าถึงได้ตามที่บันทึกไว้
- **การครอป** ในขั้นต้นไม่ทำลายข้อมูล พิกเซลที่ซ่อนอยู่จะยังคงฝังอยู่จนกว่าจะลบพื้นที่ที่ครอปโดยตรงหรือระหว่างการบีบอัด
- **การบีบอัด** สามารถลดขนาดไฟล์ได้อย่างมีนัยสำคัญสำหรับภาพราสเตอร์ที่ใหญ่เกินไป แต่จะเสียความละเอียดของต้นฉบับ ควรทำหลังจากทราบขนาดภาพบนสไลด์ที่ต้องการแล้ว
- **ภาพ SVG** ควรคงเป็น SVG เมื่อการคงไว้ซึ่งเวกเตอร์สำคัญ สกัด SVG ฝังโดยตรงเมื่อจำเป็นต้องใช้แหล่งเวกเตอร์เอง การส่งออกสไลด์เป็นราสเตอร์จะเปลี่ยน SVG เป็นพิกเซลเสมอ
- **ภาพที่ใช้ซ้ำ** ควรใช้แหล่ง [IPPImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/ippimage/) เดิมเมื่อทำได้ แทนการโหลดไฟล์เดียวกันหลายครั้งในกระบวนการทำงานของงานนำเสนอ

สำหรับงานนำเสนอขนาดใหญ่ การปรับแต่งภาพมักจะได้ผลดีที่สุดเมื่อทำอย่างคัดเลือก: เก็บโลโก้และแผนภาพเป็นเนื้อหาเวกเตอร์ บีบอัดภาพถ่ายตามขนาดการแสดงจริง ลบพิกเซลที่ครอปเฉพาะเมื่อไม่ต้องการแก้ไขในภายหลัง และหลีกเลี่ยงลิงก์ภายนอกเว้นแต่การจัดการการพึ่งพาจะเป็นส่วนหนึ่งของการออกแบบการปรับใช้

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่างกรอบรูปภาพและแหล่งภาพคืออะไร?**

[IPPImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/ippimage/) แทนแหล่งภาพที่เชื่อมโยงกับงานนำเสนอ ส่วน [IPictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipictureframe/) คือรูปทรงบนสไลด์ที่แสดงภาพและเก็บข้อมูลเรขาคณิตและการจัดรูปแบบระดับกรอบ เช่น ขนาด การหมุน ค่า crop เอฟเฟกต์และการล็อก

**ควรฝังหรือเชื่อมโยงภาพ?**

ควรฝังภาพเมื่อจำเป็นต้องให้งานนำเสนอพกพาได้ จัดเก็บหรือเรนเดอร์โดยไม่ต้องอาศัยทรัพยากรภายนอก เชื่อมโยงภาพเฉพาะเมื่อต้องการเก็บไฟล์ภาพแยกจาก PPTX อย่างตั้งใจและสามารถรักษาตำแหน่งภายนอกได้อย่างน่าเชื่อถือ

**การครอปลดขนาดไฟล์ PPTX หรือไม่?**

ไม่โดยตรง การตั้งค่าครอปปกติจะซ่อนส่วนของภาพต้นฉบับแต่ยังคงเก็บพิกเซลไว้ ใช้ [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) หรือบีบอัดภาพพร้อมการลบส่วนที่ครอปเมื่อพิกเซลเหล่านั้นสามารถละทิ้งได้อย่างถาวร

**สามารถกู้คืนคุณภาพภาพหลังบีบอัดได้หรือไม่?**

ไม่ได้ การบีบอัดอาจลดความละเอียดราสเตอร์ที่เก็บไว้และการลบส่วนที่ครอปจะทำให้ข้อมูลภาพหายไป ควรเก็บไฟล์ภาพต้นฉบับแยกไว้หากต้องการแก้ไขคุณภาพสูงในภายหลัง

**ควรจัดการภาพ SVG อย่างไร?**

ควรเก็บเนื้อหา SVG เป็น SVG เมื่อต้องการคงความคมชัดของเวกเตอร์ [ISvgImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/isvgimage/) สามารถสกัดได้โดยตรง การเรนเดอร์สไลด์เป็นรูปแบบราสเตอร์เช่น PNG หรือ JPEG จะทำให้ SVG ถูกแปลงเป็นพิกเซล

**จะหลีกเลี่ยงการแคสต์ที่ไม่ปลอดภัยเมื่ออ่านสไลด์ที่มีอยู่ได้อย่างไร?**

ตรวจสอบประเภทรูปทรงก่อนใช้สมาชิกที่เฉพาะกับกรอบรูปภาพ การตรวจสอบ `instanceof` ต่อ [IPictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipictureframe/) จะป้องกันการแคสต์ที่ไม่ถูกต้องและทำให้โค้ดจัดการสไลด์ที่ไม่มีกรอบรูปภาพได้อย่างเหมาะสม