---
title: จัดการเฟรมรูปภาพในการนำเสนอบน Android
linktitle: เฟรมรูปภาพ
type: docs
weight: 10
url: /th/androidjava/picture-frame/
keywords:
- เฟรมรูปภาพ
- เพิ่มเฟรมรูปภาพ
- สร้างเฟรมรูปภาพ
- ภาพที่ฝังไว้
- ภาพที่เชื่อมโยง
- สกัดภาพ
- ภาพราสเตอร์
- ภาพ SVG
- ครอบภาพ
- ลบพื้นที่ที่ครอบ
- บีบอัดภาพ
- StretchOffset
- การจัดรูปแบบเฟรมรูปภาพ
- สเกลสัมพัทธ์
- เอฟเฟกต์ภาพ
- อัตราส่วน
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "สร้าง, จัดรูปแบบ, เชื่อมโยง, ครอบ, สกัดและบีบอัดเฟรมรูปภาพในงานนำเสนอด้วย Aspose.Slides สำหรับ Android ผ่าน Java."
---
## **ภาพรวม**

Picture frame คือรูปแบบสไลด์ที่แสดงรูปภาพ ใน Aspose.Slides, แหล่งภาพและรูปแบบที่แสดงภาพนั้นเป็นออบเจกต์แยกกัน: a [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) owns embedded image resources through its [IImageCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimagecollection/), while an [IPictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipictureframe/) controls the image's position, size, line formatting, rotation, cropping, picture effects, and other frame-level settings.

การแยกนี้มีประโยชน์เมื่อภาพเดียวกันถูกแสดงหลายครั้ง ให้เพิ่มภาพลงในพรีเซนเทชันครั้งเดียว, เก็บ [IPPImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/) ที่คืนค่า, แล้วใช้แหล่งภาพนั้นเมื่อสร้าง picture frames.

Picture frames สามารถบรรจุ raster image เช่น PNG หรือ JPEG และ vector SVG image ได้. พวกเขายังสามารถอ้างอิงภาพที่เชื่อมโยงแทนการเก็บไบต์ของภาพในพรีเซนเทชันได้. ตัวเลือกนี้มีผลต่อความพกพา, ขนาดไฟล์, การสกัดและพฤติกรรมการส่งออก, ดังนั้นจึงควรตัดสินใจว่าจะเก็บภาพอย่างไรก่อนทำการจัดรูปแบบหรือการปรับให้เหมาะสม.

## **เพิ่มและจัดรูปแบบ Embedded Image**

สำหรับภาพที่ฝังไว้, ให้เพิ่มข้อมูลภาพลงในพรีเซนเทชันและสร้าง picture frame ด้วย [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-). ภาพจะกลายเป็นส่วนหนึ่งของแพ็กเกจพรีเซนเทชัน, ทำให้พรีเซนเทชันยังคงเป็นอันหนึ่งอันเดียวเมื่อย้ายไปยังคอมพิวเตอร์เครื่องอื่น.

ตัวอย่างต่อไปนี้เพิ่มภาพ JPEG, สร้างเฟรมที่ขนาดดั้งเดิมของภาพ, และใช้การจัดรูปแบบเส้นและการหมุน:

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

picture frame ควบคุมเรขาคณิตที่แสดง; การเปลี่ยนขนาดเฟรมไม่ทำให้มิติพิกเซลดั้งเดิมของแหล่งภาพที่ฝังไว้เปลี่ยนแปลง. ความแตกต่างนี้สำคัญเมื่อทำการครอบหรือบีบอัดภาพในภายหลัง.

## **ใช้ Relative Scale**

[IPictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipictureframe/) เปิดเผยการสเกลความกว้างและความสูงแบบสัมพัทธ์สำหรับเฟรมผ่าน [setRelativeScaleWidth](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) และ [setRelativeScaleHeight](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-). ค่า `1.0` หมายถึง 100% ของขนาดรูปภาพดั้งเดิม. การสเกลแบบสัมพัทธ์เป็นประโยชน์เมื่อ workflow ต้องการคงความสัมพันธ์กับขนาดภาพต้นฉบับแทนการคำนวณขนาดสุดท้ายด้วยตนเอง.

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

Relative scale ปรับการตั้งค่าสเกลของเฟรม; มันไม่ได้ทำการรีสแแปลหรือบีบอัดภาพที่ฝังไว้.

## **Embedded and Linked Images**

ภาพที่ฝังไว้ (embedded picture) เก็บข้อมูลภาพภายในพรีเซนเทชันและจึงเป็นทางเลือกที่ปลอดภัยที่สุดสำหรับความพกพาและการเรนเดอร์ที่คาดเดาได้. ภาพที่เชื่อมโยง (linked picture) เก็บตำแหน่งภายนอกผ่านเมธอด [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) แทนการฝังข้อมูลภาพในแบบเดียวกัน.

ภาพที่เชื่อมโยงสามารถลดปริมาณข้อมูลภาพที่เก็บใน PPTX ได้, แต่ก็สร้างการพึ่งพิงภายนอก. ไฟล์ที่เชื่อมโยงต้องสามารถเข้าถึงได้โดยแอปพลิเคชันที่เปิดหรือเรนเดอร์พรีเซนเทชัน. หากเส้นทางเปลี่ยน, ไฟล์ถูกย้าย, หรือแหล่งข้อมูลไม่พร้อมใช้งาน, ภาพที่เชื่อมโยงอาจไม่แสดงตามที่คาดหวัง. สำหรับพรีเซนเทชันที่ต้องส่งทางอีเมล, จัดเก็บ, หรือเรนเดอร์ในสภาพแวดล้อมแยก, ภาพที่ฝังไว้มักจะเชื่อถือได้มากกว่า.

### **เพิ่ม Linked Image**

ตัวอย่างต่อไปนี้สร้าง picture frame และชี้ไปที่ไฟล์ภาพภายในเครื่อง. ตัวอย่างนี้จัดการเฉพาะการเชื่อมโยงภาพ; การเชื่อมโยงวิดีโอเป็น workflow สื่อแยกและไม่ได้ผสมไว้ในตัวอย่างนี้.

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

ใช้ลิงก์เมื่อการจัดการไฟล์ภายนอกเป็นเจตนา. อย่าใช้ลิงก์เป็นทางเลือกแทนการบีบอัด: PPTX ขนาดเล็กที่มีการพึ่งพาภาพเสียหายมักจะใช้งานได้น้อยกว่าพรีเซนเทชันขนาดใหญ่ที่เป็นอันหนึ่งอันเดียว.

## **สกัด Images จาก Picture Frames**

ก่อนสกัดภาพจากพรีเซนเทชันที่มีอยู่, ตรวจสอบว่า shape เป็น [IPictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipictureframe/) จริง ๆ และว่ามีภาพที่ฝังไว้. picture frames ที่เชื่อมโยงอาจไม่มีไบต์ของภาพที่สามารถสกัดได้ในลักษณะเดียวกัน.

### **สกัด Raster Image**

API ภาพสมัยใหม่ใช้ [IImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimage/) โดยตรงและไม่ต้องการ wrapper ของ Java เวอร์ชันเก่า. ตัวอย่างต่อไปนี้ค้นหา raster picture ที่ฝังไว้แรกบนสไลด์และบันทึกเป็น PNG:

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

การบันทึกผ่าน [IImage.save](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) จะแปลงภาพที่สกัดเป็นรูปแบบผลลัพธ์ที่ร้องขอ. หากต้องการไบต์ที่เข้ารหัสเก็บในพรีเซนเทชันแทนไฟล์ raster ที่แปลงแล้ว, ให้ใช้ข้อมูลไบต์ของแหล่งภาพโดยตรง.

### **สกัด SVG Image**

สำหรับภาพ SVG, [IPPImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/) เปิดเผยอ็อบเจ็กต์ [ISvgImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isvgimage/). สิ่งนี้ทำให้คุณดึงข้อมูล SVG ตรง ๆ แทนการเรนเดอร์ภาพก่อน.

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

การเก็บ SVG เป็น SVG จะคงแหล่งเวกเตอร์ไว้ในพรีเซนเทชัน. การส่งออก raster เช่น PNG หรือ JPEG จำเป็นต้องเรนเดอร์เวกเตอร์นั้นเป็นพิกเซล. การส่งออกสไลด์เป็น PDF หรือ SVG ก็เป็นการเรนเดอร์เช่นกัน, ดังนั้นกราฟิกที่ส่งออกไม่ควรถือเป็นสำเนาไบต์ต่อไบต์ของ SVG ที่ฝังไว้; ให้ใช้ข้อมูลจาก [ISvgImage.getSvgData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isvgimage/#getSvgData--) เมื่อต้องการแหล่งเวกเตอร์ดั้งเดิม.

## **ครอบ Image**

การครอบเปลี่ยนส่วนที่มองเห็นของภาพภายในเฟรม. ค่าครอบบน [IPictureFillFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipicturefillformat/) เป็นเปอร์เซ็นต์ของมิติภาพต้นฉบับ. การครอบไม่ลบพิกเซลที่ซ่อนอยู่จากภาพที่ฝังไว้; มันเพียงเปลี่ยนพื้นที่ที่มองเห็น.

ตัวอย่างต่อไปนี้ค้นหา picture frame อย่างปลอดภัยและใช้ค่าครอบ:

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

เนื่องจากข้อมูลภาพที่ซ่อนอยู่ยังคงอยู่, การครอบสามารถเปลี่ยนแปลงในภายหลังได้โดยไม่สูญเสียพิกเซลดั้งเดิม. หากขนาดไฟล์สำคัญกว่าการย้อนกลับ, พื้นที่ที่ครอบสามารถลบออกได้จริงตามที่อธิบายในส่วนต่อไป.

## **ลบข้อมูลภาพที่ถูกครอบ**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) ลบข้อมูลภาพที่อยู่นอกสี่เหลี่ยมครอบปัจจุบันและคืนค่าแหล่งภาพที่ได้. วิธีนี้สามารถลดขนาดไฟล์ได้, แต่เป็นการปรับให้เหมาะสมที่ทำลายข้อมูล: หลังจากบันทึกพรีเซนเทชัน, พิกเซลที่ลบแล้วจะไม่สามารถกู้คืนได้สำหรับการยกเลิกครอบในภายหลัง.

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

เมธอดอาจเพิ่มแหล่งภาพใหม่เข้าไปในพรีเซนเทชัน. หากภาพต้นฉบับถูกใช้โดย picture frames อื่น, เฟรมเหล่านั้นยังต้องการแหล่งเดิม, ดังนั้นการลบพื้นที่ที่ครอบอาจไม่ได้ลดจำนวนภาพทั้งหมด. การครอบ WMF หรือ EMF ด้วยเมธอดนี้จะเรนเดอร์ผลลัพธ์ที่ครอบเป็น PNG.

## **บีบอัด Raster Images**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) ลดความละเอียดของ raster image ตามขนาดที่ภาพแสดง. มันยังสามารถลบพื้นที่ที่ครอบในขั้นตอนเดียว. เมธอดคืนค่า `true` เมื่อภาพถูกปรับขนาดหรือครอบและ `false` เมื่อไม่มีการเปลี่ยนแปลงใด ๆ ที่จำเป็น.

ใช้ค่าพรีดิฟายน์ [PicturesCompression](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/picturescompression/) เมื่อเป้าหมายความละเอียดมาตรฐานเพียงพอ:

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

ค่าสำหรับ DPI บวกแบบกำหนดเองสามารถส่งแทนค่าพรีดิฟายน์เมื่อจำเป็นต้องมีเป้าหมายเฉพาะ.

การบีบอัดออกแบบมาสำหรับ raster images. เนื้อหา SVG และ metafile ไม่ถูกลดลงโดย workflow การบีบอัด raster นี้. อย่าลืมว่าความละเอียดที่ต่ำลงและพื้นที่ที่ลบแล้วไม่สามารถกู้คืนจากพรีเซนเทชันที่ปรับให้เหมาะสมได้. เลือกความละเอียดเป้าหมายตามขนาดสูงสุดที่ภาพจะถูกมองเห็นหรือส่งออกจริง ๆ แทนการใช้ DPI ต่ำสุดทั่วทั้งไฟล์.

## **ตรวจสอบ Image Effects**

เอฟเฟกต์ของรูปภาพถูกเก็บบนรูปภาพที่ใช้โดยเฟรม. คอลเลกชันการแปลงภาพสามารถมีเอฟเฟกต์เช่นการโมดูเลชันอัลฟ่าเพื่อความโปร่งใสและลูมินานซ์เพื่อความสว่างและคอนทราสต์. ตัวอย่างด้านล่างอ่านเอฟเฟกต์ทั้งสองประเภทจาก picture frame แรกบนสไลด์อย่างปลอดภัย:

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

เอฟเฟกต์เหล่านี้เปลี่ยนวิธีที่ภาพถูกเรนเดอร์ในเฟรม; พวกมันไม่ได้เขียนทับไบต์ของภาพที่ฝังไว้เดิม.

## **ล็อก Geometry ของ Picture Frame**

การตั้งค่า [IPictureFrameLock](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipictureframelock/) ควบคุมการดำเนินการแก้ไขที่ปิดใช้งานสำหรับ picture frame. ตัวอย่างเช่น, [setAspectRatioLocked](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) รักษาอัตราส่วนของรูปแบบขณะปรับขนาด.

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

การล็อกใช้กับ shape ของ picture frame. มันไม่ได้บังคับให้ภาพต้นฉบับถูกรีสแแปลหรือเปลี่ยนแปลงถาวรให้ตรงกับอัตราส่วนเดียวกัน.

## **ปรับค่า StretchOffset**

เมื่อโหมด fill ของรูปภาพเป็น stretch, ค่า stretch‑offset บน [IPictureFillFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipicturefillformat/) กำหนดสี่เหลี่ยม fill ที่สัมพันธ์กับกล่องขอบของ picture frame. เปอร์เซ็นต์บวกสร้างการเยื้องจากข้าง, ส่วนเปอร์เซ็นต์ลบสร้างการขยายออก.

สิ่งนี้แตกต่างจากการครอบ. ค่าครอบเลือกส่วนของภาพต้นฉบับที่มองเห็น; stretch offsets เปลี่ยนสี่เหลี่ยมที่ภาพ fill ถูกยืดขยายเข้าไป.

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

ใช้ stretch offsets สำหรับการวาง fill. ใช้คุณลักษณะการครอบเมื่อเป้าหมายคือซ่อนขอบของภาพต้นฉบับ.

## **การจัดเก็บ, ขนาดไฟล์, และข้อควรพิจารณาการส่งออก**

ข้อแลกเปลี่ยนหลักง่ายต่อการจัดการเมื่อการจัดเก็บภาพและการจัดรูปแบบ picture‑frame แยกจากกัน:

- **Embedded images** ทำให้พรีเซนเทชันเป็นอันหนึ่งอันเดียวและเป็นทางเลือกที่น่าเชื่อถือที่สุดสำหรับการแบ่งปันและการเรนเดอร์บนเซิร์ฟเวอร์, แต่ภาพ raster ขนาดใหญ่จะเพิ่มขนาด PPTX และการใช้หน่วยความจำ.
- **Linked images** สามารถทำให้แพ็กเกจเล็กลง, แต่พรีเซนเทชันจะพึ่งพาไฟล์ภายนอกที่ต้องคงอยู่ที่ตำแหน่งหรือเส้นทางที่จัดเก็บ.
- **Cropping** ในตอนแรกไม่ทำลายข้อมูล. พิกเซลที่ซ่อนอยู่ยังคงฝังไว้จนกว่าจะลบพื้นที่ที่ครอบโดยชัดเจนหรือถูกลบระหว่างการบีบอัด.
- **Compression** สามารถลดขนาดไฟล์ได้อย่างมากสำหรับ raster image ที่ใหญ่เกินไป, แต่จะลดความละเอียดต้นฉบับ. ควรใช้หลังจากทราบขนาดที่จะแสดงบนสไลด์แล้ว.
- **SVG images** ควรคงเป็น SVG เมื่อการคงรักษาเวกเตอร์สำคัญ. สกัด SVG ที่ฝังไว้โดยตรงเมื่อคุณต้องการทรัพยากรเวกเตอร์นั้นเอง. การส่งออกสไลด์เป็น raster เช่น PNG หรือ JPEG จะต้องแปลงเวกเตอร์เป็นพิกเซล.
- **Repeated images** ควรใช้แหล่ง [IPPImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/) ที่มีอยู่แล้วเมื่อเป็นไปได้แทนการโหลดไฟล์เดียวกันหลายครั้งเข้าสู่ workflow ของพรีเซนเทชัน.

สำหรับพรีเซนเทชันขนาดใหญ่, การปรับภาพมักจะได้ผลดีที่สุดเมื่อทำแบบเลือกเลือก: เก็บโลโก้และไดอะแกรมเป็นเนื้อหาเวกเตอร์, บีบอัดภาพถ่ายตามขนาดการแสดงผลจริง, ลบพิกเซลที่ครอบเมื่อไม่ต้องการการแก้ไขต่อไป, และหลีกเลี่ยงลิงก์ภายนอกเว้นเสียแต่การจัดการการพึ่งพาเป็นส่วนหนึ่งของการออกแบบการเผยแพร่.

## **FAQ**

**ความแตกต่างระหว่าง picture frame กับ image resource คืออะไร?**

[IPPImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/) แทนแหล่งภาพที่เชื่อมโยงกับพรีเซนเทชัน. [IPictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipictureframe/) คือ shape บนสไลด์ที่แสดงภาพและเก็บเรขาคณิตและการจัดรูปแบบระดับเฟรมเช่น ขนาด, การหมุน, ค่าครอบ, เอฟเฟกต์, และการล็อก.

**ควรฝังหรือเชื่อมโยงภาพ?**

ฝังภาพเมื่อพรีเซนเทชันต้องพกพาได้, จัดเก็บ, หรือเรนเดอร์โดยไม่ต้องเข้าถึงทรัพยากรภายนอก. เชื่อมโยงภาพเฉพาะเมื่อการเก็บไฟล์ภาพแยกออกจาก PPTX เป็นเจตนาและตำแหน่งภายนอกสามารถดูแลได้อย่างเชื่อถือได้.

**การครอบลดขนาดไฟล์ PPTX หรือไม่?**

ไม่โดยตรง. การตั้งค่าครอบปกติจะซ่อนส่วนของภาพต้นฉบับแต่ยังคงเก็บพิกเซลไว้. ใช้ [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) หรือการบีบอัดภาพพร้อมการลบพื้นที่ที่ครอบเมื่อต้องการลบพิกเซลเหล่านั้นอย่างถาวร.

**สามารถกู้คืนคุณภาพภาพหลังการบีบอัดได้หรือไม่?**

ไม่ได้. การบีบอัดสามารถลดความละเอียด raster ที่จัดเก็บได้, และการลบพื้นที่ที่ครอบจะทำให้ข้อมูลภาพหายไป. เก็บภาพต้นฉบับนอกพรีเซนเทชันหากอาจต้องการแก้ไขความละเอียดสูงในภายหลัง.

**ควรจัดการกับ SVG images อย่างไร?**

เก็บเนื้อหา SVG ยังคงเป็น SVG เมื่อความแม่นยำของเวกเตอร์สำคัญ. สามารถสกัด [ISvgImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isvgimage/) ที่ฝังไว้โดยตรง. การเรนเดอร์สไลด์เป็นรูปแบบ raster เช่น PNG หรือ JPEG จะทำให้ SVG แปลงเป็นพิกเซล.

**จะหลีกเลี่ยง unsafe casts เมื่ออ่านสไลด์ที่มีอยู่ได้อย่างไร?**

ตรวจสอบประเภทของ shape ก่อนใช้สมาชิกเฉพาะ picture‑frame. การตรวจสอบ `instanceof` กับ [IPictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipictureframe/) จะช่วยหลีกเลี่ยงการ cast ที่ไม่ถูกต้องและทำให้โค้ดจัดการกับสไลด์ที่ไม่มี picture frames ได้อย่างปลอดภัย.