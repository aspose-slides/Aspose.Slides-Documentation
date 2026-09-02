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
- ภาพฝัง
- ภาพเชื่อมโยง
- สกัดภาพ
- ภาพแรสเตอร์
- ภาพ SVG
- ครอบภาพ
- ลบพื้นที่ที่ครอบ
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
description: "สร้าง, จัดรูปแบบ, เชื่อมโยง, ครอบ, สกัด, และบีบอัดกรอบรูปภาพในงานนำเสนอด้วย Aspose.Slides สำหรับ Java."
---
## **ภาพรวม**

กรอบรูปภาพเป็นรูปร่างบนสไลด์ที่แสดงภาพ ใน Aspose.Slides แหล่งข้อมูลภาพและรูปร่างที่แสดงภาพเป็นออบเจ็กต์แยกกัน: a [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) มีแหล่งข้อมูลภาพที่ฝังอยู่ผ่าน [IImageCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimagecollection/), ในขณะที่ [IPictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipictureframe/) ควบคุมตำแหน่งของภาพ, ขนาด, การจัดรูปแบบเส้น, การหมุน, การครอบ, เอฟเฟกต์รูปภาพ, และการตั้งค่าระดับกรอบอื่น ๆ

การแยกนี้มีประโยชน์เมื่อภาพเดียวกันต้องแสดงหลายครั้ง เพิ่มภาพลงในงานนำเสนอเพียงครั้งเดียว เก็บ [IPPImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/ippimage/) ที่คืนค่าไว้ และใช้แหล่งภาพนั้นเมื่อสร้างกรอบรูปภาพ

กรอบรูปภาพสามารถบรรจุภาพแรสเตอร์ เช่น PNG หรือ JPEG และภาพเวกเตอร์ SVG ได้ นอกจากนี้ยังสามารถอ้างอิงถึงภาพที่เชื่อมโยงแทนการเก็บไบต์ของภาพในงานนำเสนอ ตัวเลือกนี้มีผลต่อความพกพา, ขนาดไฟล์, การสกัดและพฤติกรรมการส่งออก ดังนั้นจึงควรตัดสินใจว่าจะเก็บภาพอย่างไรก่อนที่จะทำการจัดรูปแบบหรือเพิ่มประสิทธิภาพ

## **เพิ่มและจัดรูปแบบภาพฝัง**

สำหรับภาพฝัง ให้เพิ่มข้อมูลภาพลงในงานนำเสนอและสร้างกรอบรูปด้วย [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-). ภาพจะกลายเป็นส่วนหนึ่งของแพ็กเกจงานนำเสนอ ดังนั้นงานนำเสนอจะคงเป็นแบบอิสระเมื่อนำไปยังคอมพิวเตอร์เครื่องอื่น

ตัวอย่างต่อไปนี้เพิ่มภาพ JPEG, สร้างกรอบที่มีขนาดตามมิติเดิมของภาพ, และใช้การจัดรูปแบบเส้นและการหมุน:

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

กรอบรูปภาพควบคุมรูปทรงที่แสดง; การเปลี่ยนขนาดกรอบจะไม่เปลี่ยนมิติพิกเซลเดิมที่เก็บอยู่ในแหล่งภาพฝัง การแยกนี้สำคัญเมื่อทำการครอบหรือบีบอัดภาพในภายหลัง

## **ใช้การปรับสเกลสัมพัทธ์**

[IPictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipictureframe/) เปิดเผยการสเกลความกว้างและความสูงแบบสัมพัทธ์สำหรับกรอบผ่าน [setRelativeScaleWidth](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) และ [setRelativeScaleHeight](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-). ค่า `1.0` หมายถึง 100% ของขนาดภาพต้นฉบับ การสเกลสัมพัทธ์มีประโยชน์เมื่อเวิร์กโฟลว์ต้องรักษาความสัมพันธ์กับขนาดภาพต้นฉบับแทนการคำนวณขนาดสุดท้ายด้วยตนเอง

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

การสเกลสัมพัทธ์เปลี่ยนการตั้งค่าสเกลของกรอบ; มันไม่ทำการรีซampled หรือบีบอัดภาพฝัง

## **ภาพฝังและภาพเชื่อมโยง**

ภาพฝังเก็บข้อมูลภาพภายในงานนำเสนอและเป็นตัวเลือกที่ปลอดภัยที่สุดสำหรับความพกพาและการเรนเดอร์ที่คาดการณ์ได้ ภาพเชื่อมโยงเก็บตำแหน่งภายนอกผ่านวิธี [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/th/java/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) แทนการฝังข้อมูลภาพในลักษณะเดียวกัน

ภาพเชื่อมโยงสามารถลดปริมาณข้อมูลภาพที่จัดเก็บใน PPTX ได้ แต่จะสร้างการพึ่งพาภายนอก ไฟล์ที่เชื่อมโยงต้องสามารถเข้าถึงได้โดยแอปพลิเคชันที่เปิดหรือเรนเดอร์งานนำเสนอ หากเส้นทางเปลี่ยน, ไฟล์ถูกย้าย, หรือทรัพยากรไม่พร้อมใช้งาน ภาพเชื่อมโยงอาจไม่แสดงตามที่คาดหวัง สำหรับงานนำเสนอที่ต้องส่งอีเมล, เก็บถาวร, หรือเรนเดอร์ในสภาพแวดล้อมแยกเดี่ยว ภาพฝังมักจะเชื่อถือได้มากกว่า

### **เพิ่มภาพเชื่อมโยง**

ตัวอย่างต่อไปนี้สร้างกรอบรูปภาพและชี้ไปที่ไฟล์ภาพในเครื่อง มุ่งเน้นเฉพาะการเชื่อมโยงภาพ; การเชื่อมโยงวิดีโอเป็นเวิร์กโฟลว์สื่อแยกต่างหากและไม่ได้รวมอยู่ในตัวอย่างนี้

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

ใช้ลิงก์เมื่อการจัดการไฟล์ภายนอกเป็นเจตนา ไม่ควรใช้เป็นตัวแทนการบีบอัด: PPTX เล็กที่มีการเชื่อมโยงภาพเสียหายมักจะใช้งานได้น้อยกว่า presentation ขนาดใหญ่ที่เป็นอิสระ

## **สกัดภาพจากกรอบรูปภาพ**

ก่อนสกัดภาพจากงานนำเสนอที่มีอยู่ ตรวจสอบว่ารูปร่างเป็น [IPictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipictureframe/) จริงและว่ามันมีภาพฝังอยู่หรือไม่ กรอบรูปภาพเชื่อมโยงอาจไม่มีไบต์ของภาพที่สามารถสกัดได้ในลักษณะเดียวกัน

### **สกัดภาพแรสเตอร์**

API ภาพสมัยใหม่ใช้ [IImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimage/) โดยตรงและไม่จำเป็นต้องใช้ wrapper ของ Java ที่เก่า ตัวอย่างต่อไปนี้ค้นหาภาพแรสเตอร์ฝังแรกบนสไลด์และบันทึกเป็น PNG:

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

การบันทึกผ่าน [IImage.save](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimage/#save-java.lang.String-int-) จะเปลี่ยนภาพที่สกัดเป็นรูปแบบผลลัพธ์ที่ร้องขอ หากต้องการไบต์ที่เข้ารหัสเก็บไว้ในงานนำเสนอแทนไฟล์แรสเตอร์ที่แปลงแล้ว ให้ใช้ข้อมูลไบต์ของแหล่งภาพแทน

### **สกัดภาพ SVG**

สำหรับภาพ SVG, [IPPImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/ippimage/) เปิดเผยอ็อบเจ็กต์ [ISvgImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/isvgimage/). สิ่งนี้ทำให้คุณดึงข้อมูล SVG โดยตรงแทนการแปลงภาพเป็นแรสเตอร์ก่อน

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

การเก็บเนื้อหา SVG เป็น SVG จะรักษาแหล่งเวกเตอร์ภายในงานนำเสนอ การส่งออกเป็นแรสเตอร์ เช่น PNG หรือ JPEG จำเป็นต้องเรนเดอร์เนื้อหาเวกเตอร์นั้นเป็นพิกเซล การส่งออกสไลด์เป็น PDF หรือ SVG ก็เป็นกระบวนการเรนเดอร์ ดังนั้นกราฟิกที่ส่งออกไม่ควรถูกมองว่าเป็นสำเนาไบต์ต่อไบต์ของ SVG ฝัง; ใช้ข้อมูลจาก [ISvgImage.getSvgData](https://reference.aspose.com/slides/th/java/com.aspose.slides/isvgimage/#getSvgData--) เมื่อจำเป็นต้องใช้แหล่งเวกเตอร์ดั้งเดิม

## **ครอบภาพ**

การครอบเปลี่ยนส่วนของภาพที่มองเห็นได้ภายในกรอบ ค่าครอบบน [IPictureFillFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipicturefillformat/) เป็นเปอร์เซ็นต์ของมิติภาพต้นฉบับ การครอบไม่ได้ลบพิกเซลที่ซ่อนอยู่จากภาพฝัง; มันเพียงแค่เปลี่ยนพื้นที่ที่มองเห็น

ตัวอย่างต่อไปนี้ค้นหากรอบรูปภาพอย่างปลอดภัยและใช้ค่าครอบ:

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

เนื่องจากข้อมูลภาพที่ซ่อนยังคงอยู่ การครอบสามารถเปลี่ยนแปลงได้ภายหลังโดยไม่สูญเสียพิกเซลดั้งเดิม หากขนาดไฟล์เป็นปัจจัยสำคัญกว่าความสามารถย้อนกลับ พื้นที่ที่ครอบแล้วสามารถลบออกอย่างจริงจังตามที่อธิบายในส่วนต่อไป

## **ลบข้อมูลภาพที่ครอบแล้ว**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) จะลบข้อมูลภาพที่อยู่นอกสี่เหลี่ยมครอบปัจจุบันและคืนแหล่งภาพผลลัพธ์ สิ่งนี้สามารถลดขนาดไฟล์ได้ แต่เป็นการเพิ่มประสิทธิภาพที่ทำลาย: หลังจากบันทึกงานนำเสนอ พิกเซลที่ถูกลบจะไม่สามารถกู้คืนสำหรับการยกเลิกครอบในภายหลัง

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

วิธีการนี้อาจเพิ่มแหล่งภาพใหม่ลงในงานนำเสนอ หากภาพต้นฉบับยังถูกใช้โดยกรอบรูปภาพอื่น ๆ กรอบเหล่านั้นยังคงต้องการแหล่งเดิมของตน ดังนั้นการลบพื้นที่ที่ครอบไม่จำเป็นต้องลดจำนวนภาพทั้งหมด การครอบเนื้อหา WMF หรือ EMF ด้วยวิธีนี้จะทำให้ผลลัพธ์ที่ครอบถูกแปลงเป็น PNG

## **บีบอัดภาพแรสเตอร์**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) ลดความละเอียดของภาพแรสเตอร์สัมพันธ์กับขนาดที่ภาพแสดง มันยังสามารถลบพื้นที่ที่ครอบในขั้นตอนเดียวได้ เมธอดจะคืนค่า `true` เมื่อภาพถูกปรับขนาดหรือครอบและ `false` เมื่อไม่มีการเปลี่ยนแปลงใด ๆ จำเป็น

ใช้ค่า [PicturesCompression](https://reference.aspose.com/slides/th/java/com.aspose.slides/picturescompression/) ล่วงหน้าหากความละเอียดเป้าหมายมาตรฐานเพียงพอ:

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

สามารถส่งค่าความละเอียด DPI บวกแบบกำหนดเองแทนค่าล่วงหน้าได้เมื่อจำเป็นต้องการเป้าหมายเฉพาะ

การบีบอัดตั้งใจสำหรับภาพแรสเตอร์ SVG และเนื้อหาเมตาฟายล์ไม่ถูกลดโดยกระบวนการบีบอัดแรสเตอร์นี้ นอกจากนี้อย่าลืมว่าความละเอียดต่ำและการลบพื้นที่ที่ครอบไม่สามารถกู้คืนจากงานนำเสนอที่เพิ่มประสิทธิภาพแล้ว เลือกความละเอียดเป้าหมายโดยอิงจากขนาดสูงสุดที่ภาพจะถูกดูหรือส่งออกจริง ๆ แทนการกำหนด DPI ต่ำสุดทั่วทั้งงานนำเสนอ

## **ตรวจสอบเอฟเฟกต์ภาพ**

เอฟเฟกต์รูปภาพถูกเก็บบนภาพที่ใช้โดยกรอบ คอลเลกชันการแปลงภาพสามารถมีเอฟเฟกต์เช่นการปรับค่าแอลฟ่าคงที่สำหรับความโปร่งใสและความสว่างของลูมินานซ์ ตัวอย่างด้านล่างอ่านเอฟเฟกต์ทั้งสองประเภทจากกรอบรูปภาพแรกบนสไลด์อย่างปลอดภัย:

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
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        for (IImageTransformOperation effect : imageTransform) {
            if (effect instanceof IAlphaModulateFixed) {
                IAlphaModulateFixed alphaModulateFixed = (IAlphaModulateFixed) effect;
                float transparency = 100 - alphaModulateFixed.getAmount();
                System.out.println("Transparency: " + transparency);
            }

            if (effect instanceof ILuminance) {
                ILuminance luminanceEffect = (ILuminance) effect;
                ILuminanceEffectiveData luminance = luminanceEffect.getEffective();
                System.out.println("Brightness: " + luminance.getBrightness());
                System.out.println("Contrast: " + luminance.getContrast());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

เอฟเฟกต์เหล่านี้เปลี่ยนวิธีการเรนเดอร์ภาพในกรอบ; พวกมันไม่เขียนทับไบต์ของภาพฝังดั้งเดิม

## **ล็อกเรขาคณิตของกรอบรูปภาพ**

การตั้งค่า [IPictureFrameLock](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipictureframelock/) ควบคุมว่าการดำเนินการแก้ไขใดบ้างที่ถูกปิดใช้งานสำหรับกรอบรูปภาพ ตัวอย่างเช่น [setAspectRatioLocked](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) จะรักษาอัตราส่วนของรูปร่างขณะปรับขนาด

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

การล็อกนี้ใช้กับรูปร่างกรอบรูปภาพ ไม่ได้บังคับให้ภาพต้นฉบับถูกรีแซมพลหรือเปลี่ยนอัตราส่วนอย่างถาวร

## **ปรับค่า StretchOffset**

เมื่อโหมดการเติมรูปภาพเป็น stretch, ค่าระยะ offset บน [IPictureFillFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipicturefillformat/) กำหนดสี่เหลี่ยมเติมสัมพันธ์กับกล่องขอบของกรอบรูปภาพ เปอร์เซ็นต์บวกสร้างการเว้นจากขอบ, ส่วนเปอร์เซ็นต์ลบสร้างการขยายออก

นี่แตกต่างจากการครอบ ค่าครอบเลือกส่วนของภาพต้นฉบับที่จะแสดง, ส่วน offset จะเปลี่ยนสี่เหลี่ยมที่ภาพเติมจะถูกยืดออก

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

ใช้ offset สำหรับการวางเติม ใช้คุณสมบัติการครอบเมื่อเป้าหมายคือซ่อนขอบของภาพต้นฉบับ

## **การจัดเก็บ, ขนาดไฟล์, และการพิจารณาการส่งออก**

การตัดสินใจหลักเป็นเรื่องง่ายขึ้นเมื่อการจัดเก็บภาพและการจัดรูปแบบกรอบรูปภาพแยกกัน:

- **ภาพฝัง** ทำให้งานนำเสนอเป็นแบบอิสระและเชื่อถือได้ที่สุดสำหรับการแชร์และการเรนเดอร์บนเซิร์ฟเวอร์, แต่ภาพแรสเตอร์ขนาดใหญ่จะเพิ่มขนาด PPTX และการใช้หน่วยความจำ
- **ภาพเชื่อมโยง** สามารถทำให้แพ็กเกจมีขนาดเล็กลง, แต่งานนำเข้าพึ่งพาไฟล์ภายนอกที่ต้องคงอยู่ที่เส้นทางหรือสถานที่ที่จัดเก็บไว้
- **การครอบ** เริ่มต้นเป็นแบบไม่ทำลาย พิกเซลที่ซ่อนไว้ยังคงฝังอยู่จนกว่าจะมีการลบพื้นที่ที่ครอบอย่างชัดเจนหรือระหว่างการบีบอัด
- **การบีบอัด** สามารถลดขนาดไฟล์ได้อย่างมากสำหรับภาพแรสเตอร์ที่ใหญ่เกินขนาด, แต่จะทำให้ความละเอียดต้นฉบับสูญเสีย ควรทำหลังจากที่知ขนาดบนสไลด์ที่ต้องการแสดงแล้ว
- **ภาพ SVG** ควรคงเป็น SVG เมื่อการรักษาเวกเตอร์สำคัญ สกัด SVG ฝังโดยตรงเมื่อคุณต้องการแหล่งเวกเตอร์เอง การส่งออกสไลด์เป็นแรสเตอร์จะเปลี่ยนสไลด์ที่เรนเดอร์เป็นพิกเซลเสมอ
- **ภาพที่ใช้ซ้ำ** ควรใช้แหล่ง [IPPImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/ippimage/) ที่มีอยู่แล้วเมื่อเป็นไปได้ แทนการโหลดไฟล์เดียวกันหลายครั้งเข้าสู่เวิร์กโฟลว์งานนำเสนอ

สำหรับงานนำเสนอขนาดใหญ่ การเพิ่มประสิทธิภาพภาพมักจะได้ผลดีที่สุดเมื่อทำแบบเลือกเฉพาะ: เก็บโลโก้และไดอะแกรมเป็นเนื้อหาเวกเตอร์, บีบอัดภาพถ่ายตามขนาดการแสดงจริง, ลบพิกเซลที่ครอบเมื่อไม่มีการแก้ไขต่อไป, และหลีกเลี่ยงลิงก์ภายนอกเว้นแต่การจัดการการพึ่งพาจะเป็นส่วนหนึ่งของการออกแบบการนำส่ง

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่างกรอบรูปภาพและแหล่งภาพคืออะไร?**

[IPPImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/ippimage/) แทนแหล่งภาพที่เชื่อมโยงกับงานนำเสนอ ส่วน [IPictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipictureframe/) เป็นรูปร่างบนสไลด์ที่แสดงภาพและเก็บเรขาคณิตระดับกรอบและการจัดรูปแบบ เช่น ขนาด, การหมุน, ค่าครอบ, เอฟเฟกต์, และล็อก

**ควรฝังหรือเชื่อมโยงภาพ?**

ฝังภาพเมื่อจำเป็นต้องการความพกพา, การเก็บถาวร, หรือการเรนเดอร์โดยไม่มีแหล่งภายนอก เชื่อมโยงภาพเฉพาะเมื่อตั้งใจเก็บไฟล์ภาพอยู่นอก PPTX และสามารถรักษาตำแหน่งภายนอกได้อย่างน่าเชื่อถือ

**การครอบลดขนาดไฟล์ PPTX หรือไม่?**

ไม่โดยตรง การตั้งค่าครอบปกติจะซ่อนไฟล์ภาพส่วนที่ไม่ได้ใช้แต่ยังคงเก็บพิกเซลไว้ ใช้ [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) หรือการบีบอุ่นพร้อมการลบพื้นที่ที่ครอบเมื่อพิกเซลเหล่านั้นสามารถลบได้โดยถาวร

**ฉันสามารถกู้คืนคุณภาพภาพหลังบีบอัดได้หรือไม่?**

ไม่ การบีบอัดอาจลดความละเอียดแรสเตอร์ที่เก็บไว้และการลบพื้นที่ที่ครอบจะทำให้ข้อมูลภาพหายไป เก็บภาพต้นฉบับอยู่ภายนอกงานนำเสนอหากอาจต้องการการแก้ไขความละเอียดสูงในภายหลัง

**ควรจัดการภาพ SVG อย่างไร?**

เก็บเนื้อหา SVG เป็น SVG เมื่อความแม่นยำของเวกเตอร์สำคัญ สามารถสกัด [ISvgImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/isvgimage/) ฝังได้โดยตรง การเรนเดอร์สไลด์เป็นรูปแบบแรสเตอร์เช่น PNG หรือ JPEG จะทำให้ SVG ถูกแปลงเป็นพิกเซล

**ฉันจะหลีกเลี่ยงการแคสที่ไม่ปลอดภัยเมื่ออ่านสไลด์ที่มีอยู่ได้อย่างไร?**

ตรวจสอบประเภทรูปร่างก่อนใช้สมาชิกเฉพาะกรอบรูปภาพ การตรวจสอบ `instanceof` กับ [IPictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipictureframe/) จะหลีกเลี่ยงการแคสที่ไม่ถูกต้องและให้โค้ดจัดการสไลด์ที่ไม่มีกรอบรูปภาพได้อย่างเหมาะสม