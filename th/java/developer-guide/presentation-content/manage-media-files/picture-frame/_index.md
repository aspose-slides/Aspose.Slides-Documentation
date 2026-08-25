---
title: จัดการกรอบรูปภาพในงานนำเสนอโดยใช้ Java
linktitle: กรอบรูปภาพ
type: docs
weight: 10
url: /th/java/picture-frame/
keywords:
- กรอบรูปภาพ
- เพิ่มกรอบรูปภาพ
- สร้างกรอบรูปภาพ
- ภาพที่ฝังไว้
- ภาพที่เชื่อมโยง
- สกัดภาพ
- ภาพแรสเซอร์
- ภาพ SVG
- ครอปภาพ
- ลบพื้นที่ที่ครอป
- บีบอัดภาพ
- StretchOffset
- การฟอร์แมตกรอบรูปภาพ
- สเกลสัมพัทธ์
- เอฟเฟกต์ภาพ
- อัตราส่วนภาพ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Java
- Aspose.Slides
description: "สร้าง, กำหนดรูปแบบ, เชื่อมโยง, ครอป, สกัด และบีบอัดกรอบรูปภาพในงานนำเสนอด้วย Aspose.Slides สำหรับ Java."
---
## **ภาพรวม**

Picture frame คือรูปทรงสไลด์ที่แสดงภาพ ใน Aspose.Slides แหล่งข้อมูลภาพและรูปทรงที่แสดงภาพเป็นออบเจกต์แยกกัน: a [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) มีทรัพยากรภาพที่ฝังอยู่ผ่าน [IImageCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimagecollection/) ในขณะที่ [IPictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipictureframe/) ควบคุมตำแหน่ง ขนาด การฟอร์แมตเส้น การหมุน การครอป เอฟเฟกต์ภาพ และการตั้งค่าอื่น ๆ ของระดับเฟรม

การแยกนี้มีประโยชน์เมื่อภาพเดียวกันต้องแสดงหลายครั้ง เพิ่มภาพลงในงานนำเสนอเพียงครั้งเดียว เก็บ [IPPImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/ippimage/) ที่คืนค่าไว้ และใช้ทรัพยากรภาพนั้นเมื่อสร้าง picture frame

Picture frame สามารถบรรจุภาพเรสเตอร์เช่น PNG หรือ JPEG และภาพเวกเตอร์ SVG ได้ นอกจากนี้ยังสามารถอ้างอิงภาพที่เชื่อมโยงแทนการเก็บไบต์ของภาพไว้ในงานนำเสนอ ตัวเลือกนี้มีผลต่อความพกพา ขนาดไฟล์ การสกัดและพฤติกรรมการส่งออก ดังนั้นจึงควรตัดสินใจว่าจะเก็บภาพอย่างไรก่อนนำไปฟอร์แมตหรือทำการเพิ่มประสิทธิภาพ

## **เพิ่มและกำหนดรูปแบบภาพที่ฝังไว้**

สำหรับภาพที่ฝังไว้ ให้เพิ่มข้อมูลภาพลงในงานนำเสนอและสร้าง picture frame ด้วย [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) ภาพจะกลายเป็นส่วนหนึ่งของแพคเกจงานนำเสนอ ทำให้งานนำเสนอคงเป็นอิสระเมื่อย้ายไปยังคอมพิวเตอร์เครื่องอื่น

ตัวอย่างต่อไปนี้เพิ่มภาพ JPEG สร้างเฟรมที่มีขนาดตามมิติเดิมของภาพ และใช้การฟอร์แมตเส้นและการหมุน:

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

picture frame ควบคุมเรขาคณิตที่แสดง; การเปลี่ยนขนาดเฟรมไม่ได้เปลี่ยนมิติพิกเซลเดิมที่เก็บอยู่ในทรัพยากรภาพที่ฝังไว้ ความแตกต่างนี้สำคัญเมื่อทำการครอปหรือบีบอัดภาพในภายหลัง

## **ใช้สเกลสัมพัทธ์**

[IPictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipictureframe/) เปิดให้ใช้การสเกลความกว้างและความสูงแบบสัมพัทธ์สำหรับเฟรมผ่าน [setRelativeScaleWidth](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) และ [setRelativeScaleHeight](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-) ค่า `1.0` ตรงกับ 100 % ของขนาดภาพต้นฉบับ สเกลสัมพัทธ์มีประโยชน์เมื่อเวิร์กโฟลว์ต้องคงความสัมพันธ์กับขนาดภาพต้นฉบับแทนการคำนวณขนาดสุดท้ายด้วยตนเอง

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

สเกลสัมพัทธ์เปลี่ยนการตั้งค่าการสเกลของเฟรม; ไม่ทำการรีแซมเปิลหรือบีบอัดภาพที่ฝังไว้

## **ภาพที่ฝังและภาพที่เชื่อมโยง**

ภาพที่ฝังไว้เก็บข้อมูลภาพภายในงานนำเสนอและเป็นตัวเลือกที่ปลอดภัยที่สุดสำหรับความพกพาและการเรนเดอร์ที่คาดการณ์ได้ อย่างไรก็ตามภาพที่เชื่อมโยงจะเก็บตำแหน่งภายนอกผ่านเมธอด [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/th/java/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) แทนการฝังข้อมูลภาพด้วยวิธีเดียวกัน

ภาพที่เชื่อมโยงสามารถลดปริมาณข้อมูลภาพที่เก็บใน PPTX ได้ แต่จะสร้างการขึ้นต่อภายนอก ไฟล์ที่เชื่อมโยงต้องยังคงเข้าถึงได้สำหรับแอปพลิเคชันที่เปิดหรือเรนเดอร์งานนำเสนอ หากเส้นทางเปลี่ยน ไฟล์ถูกย้าย หรือทรัพยากรไม่สามารถใช้ได้ ภาพที่เชื่อมโยงอาจไม่แสดงตามคาด สำหรับงานนำเสนอที่ต้องส่งอีเมล เก็บถาวร หรือเรนเดอร์ในสภาพแวดล้อมที่แยกจากกัน ภาพที่ฝังไว้มักจะเชื่อถือได้กว่า

### **เพิ่มภาพที่เชื่อมโยง**

ตัวอย่างต่อไปนี้สร้าง picture frame และชี้ไปยังไฟล์ภาพในเครื่องท้องถิ่น มุ่งเน้นที่การเชื่อมโยงภาพเท่านั้น; การเชื่อมโยงวิดีโอเป็นเวิร์กโฟลว์สื่อแยกต่างหากและไม่ได้ผสานในตัวอย่างนี้

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

ใช้ลิงก์เมื่อต้องการจัดการไฟล์ภายนอกโดยเจตนา อย่าใช้เป็นวิธีแทนการบีบอัด: PPTX ที่เล็กแต่มีการพึ่งพาภาพที่เสียหายมักจะใช้การได้น้อยกว่าการนำเสนอที่เต็มรูปแบบและเป็นอิสระ

## **ดึงภาพจากเฟรมรูปภาพ**

ก่อนดึงภาพจากงานนำเสนอที่มีอยู่ ตรวจสอบให้แน่ใจว่า shape นั้นเป็น [IPictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipictureframe/) จริงและมีภาพที่ฝังอยู่ ภาพที่เชื่อมโยงอาจไม่มีไบต์ของภาพที่สามารถดึงออกได้ในลักษณะเดียวกัน

### **ดึงภาพแบบแรสเซอร์**

API ภาพสมัยใหม่ใช้ [IImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimage/) โดยตรงและไม่ต้องอาศัย wrapper ของ Java รุ่นเก่า ตัวอย่างต่อไปนี้ค้นหาภาพแรสเซอร์ที่ฝังอยู่แรกบนสไลด์และบันทึกเป็น PNG

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

การบันทึกผ่าน [IImage.save](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimage/#save-java.lang.String-int-) จะเปลี่ยนภาพที่สกัดเป็นรูปแบบผลลัพธ์ที่ร้องขอ หากต้องการไบต์ที่เข้ารหัสเก็บอยู่ในงานนำเสนอแทนไฟล์แรสเซอร์ที่แปลงแล้ว ให้ใช้ข้อมูลไบนารีของทรัพยากรภาพแทน

### **ดึงภาพ SVG**

สำหรับภาพ SVG, [IPPImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/ippimage/) เปิดให้เข้าถึงออบเจกต์ [ISvgImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/isvgimage/) ซึ่งทำให้คุณสามารถดึงข้อมูล SVG โดยตรงโดยไม่ต้องเรสเซอร์ไลซ์ภาพก่อน

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

การเก็บเนื้อหา SVG เป็น SVG จะรักษาแหล่งเวกเตอร์ไว้ในงานนำเสนอ การส่งออกเป็นแรสเซอร์เช่น PNG หรือ JPEG จะต้องเรนเดอร์เนื้อหาเวกเตอร์เป็นพิกเซล การส่งออกสไลด์เป็น PDF หรือ SVG ก็เป็นกระบวนการเรนเดอร์เช่นกัน ดังนั้นกราฟิกที่ส่งออกไม่ควรถูกมองว่าเป็นสำเนาไบต์ต่อไบต์ของ SVG ที่ฝังไว้; ใช้ข้อมูลจาก [ISvgImage.getSvgData](https://reference.aspose.com/slides/th/java/com.aspose.slides/isvgimage/#getSvgData--) เมื่อจำเป็นต้องใช้ทรัพยากรเวกเตอร์ต้นฉบับ

## **ครอปภาพ**

การครอปเปลี่ยนส่วนของภาพที่มองเห็นได้ภายในเฟรม ค่า crop บน [IPictureFillFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipicturefillformat/) เป็นเปอร์เซ็นต์ของมิติภาพต้นฉบับ การครอปไม่ลบพิกเซลที่ซ่อนอยู่จากภาพที่ฝังไว้ทันที; มันเพียงเปลี่ยนพื้นที่ที่แสดงเท่านั้น

ตัวอย่างต่อไปนี้ค้นหา picture frame อย่างปลอดภัยและใช้ค่า crop:

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

เนื่องจากข้อมูลภาพที่ซ่อนยังคงอยู่ ค่าครอปสามารถเปลี่ยนได้ภายหลังโดยไม่สูญเสียพิกเซลเดิม หากขนาดไฟล์เป็นสิ่งสำคัญกว่าการย้อนกลับ พื้นที่ที่ครอปสามารถลบออกได้จริงตามที่อธิบายในส่วนต่อไป

## **ลบข้อมูลภาพที่ครอป**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) จะลบข้อมูลภาพที่อยู่นอกสี่เหลี่ยมครอปปัจจุบันและคืนทรัพยากรภาพที่ได้ผลลัพธ์ การทำเช่นนี้ช่วยลดขนาดไฟล์ได้ แต่เป็นการเพิ่มประสิทธิภาพแบบทำลาย: หลังจากบันทึกงานนำเสนอแล้ว พิกเซลที่ลบจะไม่มีอยู่ให้ทำการ un‑crop อีกต่อไป

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

เมธอดนี้อาจเพิ่มทรัพยากรภาพใหม่ลงในงานนำเสนอ หากภาพต้นฉบับยังถูกใช้งานโดย picture frame อื่น ๆ เฟรมเหล่านั้นยังคงต้องการทรัพยากรเดิม ดังนั้นการลบพื้นที่ที่ครอปไม่จำเป็นต้องลดจำนวนภาพทั้งหมด การครอป WMF หรือ EMF ด้วยเมธอดนี้จะทำให้ผลลัพธ์ที่ครอปถูกเรสเซอร์ไลซ์เป็น PNG

## **บีบอัดภาพแรสเซอร์**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) ลดความละเอียดของภาพแรสเซอร์ตามขนาดที่แสดงภาพบนสไลด์ สามารถลบพื้นที่ที่ครอปในขั้นตอนเดียวได้ เมธอดจะคืนค่า `true` เมื่อภาพถูกปรับขนาดหรือครอปและ `false` เมื่อไม่มีการเปลี่ยนแปลงใด ๆ

ใช้ค่าที่กำหนดไว้ล่วงหน้าใน [PicturesCompression](https://reference.aspose.com/slides/th/java/com.aspose.slides/picturescompression/) เมื่อความละเอียดเป้าหมายมาตรฐานเพียงพอ:

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

การบีบอัดมุ่งเน้นที่ภาพแรสเซอร์เท่านั้น SVG และเนื้อหาเมท้าไฟล์ไม่ถูกลดขนาดด้วยกระบวนการบีบอัดนี้ จำไว้ว่าความละเอียดที่ต่ำลงและพื้นที่ที่ครอปที่ถูกลบไม่สามารถกู้คืนจากงานนำเสนอที่ทำการเพิ่มประสิทธิภาพแล้ว ควรเลือกความละเอียดเป้าหมายตามขนาดสูงสุดที่ภาพจะถูกดูหรือส่งออกจริง ๆ แทนการตั้งค่า DPI ต่ำสุดทั่วทั้งงานนำเสนอ

## **จัดการเอฟเฟกต์การแปลงภาพ**

สำหรับเวิร์กโฟลว์ครบถ้วนที่ครอบคลุมความสว่าง ความคอนทราสต์ การแปลงสี เบลอ เอฟเฟกต์อัลฟา โซ่ที่จัดลำดับ การตรวจสอบ การลบ และการตรวจสอบแบบรอบต่อรอบ ดูที่ [Image Transform Effects](/java/image-transform-effects/).

## **ล็อกรูปทรงเฟรมรูปภาพ**

การตั้งค่าใน [IPictureFrameLock](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipictureframelock/) ควบคุมการทำงานแก้ไขใดที่ถูกปิดใช้งานสำหรับ picture frame ตัวอย่างเช่น [setAspectRatioLocked](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) จะคงอัตราส่วนของรูปทรงขณะปรับขนาด

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

การล็อกใช้กับรูปทรง picture frame ไม่ทำให้ภาพต้นฉบับต้องถูกรีแซมเปิลหรือเปลี่ยนอัตราส่วนอย่างถาวร

## **ปรับค่าการยืด StretchOffset**

เมื่อโหมดการเติมรูปภาพเป็น stretch ค่าการยืด offset บน [IPictureFillFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipicturefillformat/) กำหนดสี่เหลี่ยมเติมสัมพันธ์กับกล่องขอบเขตของ picture frame เปอร์เซ็นต์บวกสร้างการเว้นจากขอบ ส่วนเปอร์เซ็นต์ลบสร้างการขยายออก

นี่แตกต่างจากการครอป ค่า crop เลือกส่วนของภาพต้นฉบับที่มองเห็นได้ ส่วน stretch offset ปรับสี่เหลี่ยมที่ภาพเติมจะแสดง

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

ใช้ stretch offset สำหรับการวางตำแหน่งเติม ใช้คุณสมบัติ crop เมื่อต้องการซ่อนขอบของภาพต้นฉบับ

## **การจัดเก็บ ขนาดไฟล์ และข้อควรพิจารณาการส่งออก**

ข้อแลกเปลี่ยนหลักจะจัดการได้ง่ายเมื่อการจัดเก็บภาพและการฟอร์แมตเฟรมรูปภาพแยกจากกัน:

- **ภาพที่ฝัง** ทำให้งานนำเสนอเป็นอิสระและเป็นตัวเลือกที่น่าเชื่อถือที่สุดสำหรับการแชร์และการเรนเดอร์บนเซิร์ฟเวอร์ แต่ภาพแรสเซอร์ขนาดใหญ่จะเพิ่มขนาด PPTX และการใช้หน่วยความจำ
- **ภาพที่เชื่อมโยง** สามารถทำให้แพคเกจมีขนาดเล็กลง แต่งานนำเสนอจะพึ่งพาไฟล์ภายนอกที่ต้องคงอยู่ที่เส้นทางหรือสถานที่ที่เก็บไว้
- **การครอป** เริ่มต้นเป็นแบบไม่ทำลาย พิกเซลที่ซ่อนจะยังคงฝังอยู่จนกว่าจะลบพื้นที่ที่ครอปอย่างชัดเจนหรือระหว่างการบีบอัด
- **การบีบอัด** สามารถลดขนาดไฟล์ได้อย่างมากสำหรับภาพแรสเซอร์ที่ใหญ่เกินไป แต่จะเสียความละเอียดต้นฉบับ ควรทำหลังจากทราบขนาดที่จะแสดงบนสไลด์แล้ว
- **ภาพ SVG** ควรคงเป็น SVG เมื่อการรักษาเวกเตอร์สำคัญ ดึง SVG ที่ฝังโดยตรงเมื่อคุณต้องการทรัพยากรเวกเตอร์เอง การส่งออกสไลด์เป็นแรสเซอร์จะเปลี่ยนสไลด์เป็นพิกเซลเสมอ
- **ภาพที่ซ้ำ** ควรใช้ทรัพยากร [IPPImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/ippimage/) ที่มีอยู่แล้วเมื่อเป็นไปได้ แทนการโหลดไฟล์เดียวกันหลายครั้งในกระบวนการงานนำเสนอ

สำหรับงานนำเสนอขนาดใหญ่ การเพิ่มประสิทธิภาพภาพมักทำได้ดีที่สุดเมื่อทำอย่างเลือกเฉพาะ: เก็บโลโก้และแผนภาพเป็นเนื้อหาเวกเตอร์ บีบอัดภาพถ่ายตามขนาดการแสดงจริง ลบพิกเซลที่ครอปเฉพาะเมื่อไม่ต้องการแก้ไขต่อไป และหลีกเลี่ยงลิงก์ภายนอกหากการจัดการการพึ่งพาไม่เป็นส่วนหนึ่งของการออกแบบการปรับใช้

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่าง picture frame กับ image resource คืออะไร?**

[IPPImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/ippimage/) แสดงถึงทรัพยากรภาพที่เชื่อมโยงกับงานนำเสนอ ส่วน [IPictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipictureframe/) คือรูปทรงบนสไลด์ที่แสดงภาพและเก็บเรขาคณิตระดับเฟรมและการฟอร์แมต เช่น ขนาด การหมุน ค่า crop เอฟเฟกต์และการล็อก

**ควรฝังภาพหรือเชื่อมโยงภาพ?**

ฝังภาพเมื่องานนำเสนอจำเป็นต้องพกพา เก็บถาวร หรือเรนเดอร์โดยไม่มีทรัพยากรภายนอก ใช้การเชื่อมโยงภาพเท่าที่ต้องการเก็บไฟล์ภาพนอก PPTX อย่างเจตนาและสามารถรักษาตำแหน่งภายนอกได้อย่างเชื่อถือได้

**การครอปลดขนาดไฟล์ PPTX หรือไม่?**

ไม่โดยตรง การตั้งค่าครอปปกติจะซ่อนส่วนของภาพต้นฉบับแต่ยังคงเก็บพิกเซลไว้ ใช้ [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) หรือการบีบอัดภาพพร้อมการลบพื้นที่ที่ครอปเมื่อต้องการลบพิกเซลเหล่านั้นอย่างถาวร

**สามารถกู้คืนคุณภาพภาพหลังการบีบอัดได้หรือไม่?**

ไม่ได้ การบีบอัดอาจลดความละเอียดแรสเซอร์ที่เก็บไว้และการลบพื้นที่ที่ครอปจะทำให้ข้อมูลภาพหายไป ควรเก็บภาพต้นฉบับนอกงานนำเสนอหากอาจต้องการแก้ไขด้วยความละเอียดสูงในภายหลัง

**ควรจัดการภาพ SVG อย่างไร?**

ควรเก็บเนื้อหา SVG เป็น SVG เมื่อความแม่นยำของเวกเตอร์สำคัญ สามารถดึง [ISvgImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/isvgimage/) ที่ฝังไว้โดยตรง การเรนเดอร์สไลด์เป็นรูปแบบแรสเซอร์เช่น PNG หรือ JPEG จะทำให้ SVG ถูกแปลงเป็นพิกเซล

**จะหลีกเลี่ยงการแคสต์ที่ไม่ปลอดภัยเมื่ออ่านสไลด์ที่มีอยู่ได้อย่างไร?**

ตรวจสอบประเภทของ shape ก่อนใช้สมาชิกเฉพาะ picture‑frame การตรวจสอบ `instanceof` กับ [IPictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipictureframe/) จะหลีกเลี่ยงการแคสต์ที่ไม่ถูกต้องและช่วยให้โค้ดจัดการสไลด์ที่ไม่มี picture frame ได้อย่างเหมาะสม