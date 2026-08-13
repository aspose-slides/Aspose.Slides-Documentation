---
title: "จัดการกรอบรูปภาพในงานนำเสนอบน Android"
linktitle: "กรอบรูปภาพ"
type: docs
weight: 10
url: /th/androidjava/picture-frame/
keywords:
- "กรอบรูปภาพ"
- "เพิ่มกรอบรูปภาพ"
- "สร้างกรอบรูปภาพ"
- "เพิ่มภาพ"
- "สร้างภาพ"
- "แยกภาพ"
- "ภาพราสเตอร์"
- "ภาพเวกเตอร์"
- "ครอบตัดภาพ"
- "พื้นที่ที่ครอบตัด"
- "คุณสมบัติ StretchOff"
- "การจัดรูปแบบกรอบรูปภาพ"
- "คุณสมบัติกรอบรูปภาพ"
- "สเกลสัมพันธ์"
- "เอฟเฟกต์ภาพ"
- "อัตราส่วนภาพ"
- "ความโปร่งใสของภาพ"
- "PowerPoint"
- "OpenDocument"
- "งานนำเสนอ"
- "Android"
- "Java"
- "Aspose.Slides"
description: "เพิ่มกรอบรูปภาพในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Android ผ่าน Java. ทำให้กระบวนการทำงานของคุณเป็นระเบียบและปรับปรุงการออกแบบสไลด์."
---
## **บทนำ**

กรอบรูปเป็นรูปทรงที่บรรจุภาพ—คล้ายกับภาพที่อยู่ในกรอบ

คุณสามารถเพิ่มรูปภาพลงในสไลด์ผ่านกรอบรูปได้ วิธีนี้ทำให้คุณสามารถจัดรูปแบบรูปภาพโดยจัดรูปแบบกรอบรูป

{{% alert  title="เคล็ดลับ" color="info" %}} 
Aspose มีเครื่องแปลงฟรี—[JPEG to PowerPoint](https://products.aspose.app/slides/th/import/jpg-to-ppt) และ [PNG to PowerPoint](https://products.aspose.app/slides/th/import/png-to-ppt)—ซึ่งช่วยให้ผู้ใช้สร้างงานนำเสนอจากภาพได้อย่างรวดเร็ว 
{{% /alert %}} 

## **สร้างกรอบรูปภาพ**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)  
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของสไลด์  
3. สร้างออบเจ็กต์ [IPPImage]() โดยเพิ่มภาพลงใน [IImagescollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IImageCollection) ที่เชื่อมโยงกับออบเจ็กต์ presentation เพื่อใช้เติมรูปร่าง  
4. ระบุความกว้างและความสูงของภาพ  
5. สร้าง [PictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/PictureFrame) ตามความกว้างและความสูงของภาพผ่านเมธอด `AddPictureFrame` ที่เปิดให้ใช้โดยออบเจ็กต์ shape ที่เชื่อมโยงกับสไลด์ที่อ้างอิง  
6. เพิ่มกรอบรูป (ที่บรรจุภาพ) ลงในสไลด์  
7. เขียน presentation ที่ถูกแก้ไขเป็นไฟล์ PPTX  

โค้ด Java นี้แสดงวิธีสร้างกรอบรูปภาพ:

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.IOException;

// สร้างอ็อบเจ็กต์ของคลาส Presentation ที่แทนไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // ดึงสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);
    
    // สร้างอ็อบเจ็กต์ของคลาส Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // เพิ่มกรอบรูปภาพโดยใช้ความสูงและความกว้างเท่ากับภาพ
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // บันทึกไฟล์ PPTX ลงดิสก์
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **สร้างกรอบรูปภาพด้วยสเกลสัมพันธ์**

โดยการปรับสเกลสัมพันธ์ของภาพ คุณสามารถสร้างกรอบรูปที่ซับซ้อนได้มากขึ้น  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)  
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของสไลด์  
3. เพิ่มภาพลงในคอลเลกชันภาพของ presentation  
4. สร้างออบเจ็กต์ [IPPImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPPImage) โดยเพิ่มภาพลงใน [IImagescollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IImageCollection) ที่เชื่อมโยงกับออบเจ็กต์ presentation เพื่อใช้เติมรูปร่าง  
5. ระบุความกว้างและความสูงสัมพันธ์ของภาพในกรอบรูป  
6. เขียน presentation ที่ถูกแก้ไขเป็นไฟล์ PPTX  

โค้ด Java นี้แสดงวิธีสร้างกรอบรูปภาพด้วยสเกลสัมพันธ์:

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // ดึงสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);
    
    // สร้างอินสแตนซ์ของคลาส Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // เพิ่มกรอบรูปภาพโดยใช้ความสูงและความกว้างเท่ากับภาพ
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // ตั้งค่าสเกลสัมพันธ์ของความกว้างและความสูง
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // บันทึกไฟล์ PPTX ลงดิสก์
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **แยกรูปภาพ Raster จากกรอบรูปภาพ**

คุณสามารถแยกรูปภาพ Raster จากออบเจ็กต์ [PictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/PictureFrame) แล้วบันทึกเป็น PNG, JPG หรือรูปแบบอื่น ๆ ตัวอย่างโค้ดด้านล่างแสดงการแยกรูปภาพจากเอกสาร “sample.pptx” และบันทึกเป็นรูปแบบ PNG

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    IShape firstShape = firstSlide.getShapes().get_Item(0);

    if (firstShape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) firstShape;
        IImage slideImage = pictureFrame.getPictureFormat().getPicture().getImage().getImage();
        try {
            slideImage.save("slide_1_shape_1.png", ImageFormat.Png);
        } finally {
            if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **แยกรูปภาพ SVG จากกรอบรูปภาพ**

เมื่อ presentation มีกราฟิก SVG อยู่ในรูปร่าง [PictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pictureframe/) Aspose.Slides for Android ผ่าน Java จะให้คุณดึงรูปเวกเตอร์เดิมออกมาโดยคงคุณภาพครบถ้วน เมื่อคุณมี [PictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pictureframe/) ที่ [IPPImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/) มีเนื้อหา SVG คุณสามารถอ่านรูป SVG นั้นและบันทึกลงดิสก์หรือสตรีมในรูปแบบ SVG ดั้งเดิมได้  

โค้ดตัวอย่างต่อไปนี้แสดงวิธีแยกรูป SVG จากกรอบรูปภาพ:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    if (shape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) shape;
        ISvgImage svgImage = pictureFrame.getPictureFormat().getPicture().getImage().getSvgImage();

        FileOutputStream fos = new FileOutputStream("output.svg");
        fos.write(svgImage.getSvgData());
        fos.close();
    }
} catch (IOException e) {
    System.out.println(e.getMessage());
} finally {
    presentation.dispose();
}
```

## **รับค่าความโปร่งใสของภาพ**

Aspose.Slides ให้คุณดึงค่าความโปร่งใสที่ใช้กับภาพได้ โค้ด Java นี้แสดงการทำงาน:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Test.pptx");

var pictureFrame = (IPictureFrame) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
for (var effect : imageTransform) {
    if (effect instanceof IAlphaModulateFixed) {
        var alphaModulateFixed = (IAlphaModulateFixed) effect;
        var transparencyValue = 100 - alphaModulateFixed.getAmount();
        System.out.println("Picture transparency: " + transparencyValue);
    }
}
```

## **รับค่าความสว่างและความคอนทราสต์ของภาพ**

Aspose.Slides ให้คุณดึงค่าผลกระทบความสว่างและความคอนทราสต์ที่ใช้กับภาพ อินเทอร์เฟซ [ILuminance](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iluminance/) แสดงการแปลงภาพนี้  

โค้ด Java นี้แสดงวิธีดึงการตั้งค่าความสว่างและความคอนทราสต์จากกรอบรูปภาพ:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame) shape;

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    for (IImageTransformOperation effect : imageTransform) {
        if (effect instanceof ILuminance) {
            ILuminanceEffectiveData luminance = ((ILuminance) effect).getEffective();
            float brightness = luminance.getBrightness();
            float contrast = luminance.getContrast();

            System.out.println("Brightness: " + brightness);
            System.out.println("Contrast: " + contrast);
        }
    }
} finally {
    presentation.dispose();
}
```

## **การจัดรูปแบบกรอบรูปภาพ**

Aspose.Slides มีตัวเลือกการจัดรูปแบบหลายอย่างที่สามารถใช้กับกรอบรูปภาพได้ ด้วยตัวเลือกเหล่านั้นคุณสามารถปรับกรอบรูปให้ตรงตามข้อกำหนดเฉพาะได้  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)  
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของสไลด์  
3. สร้างออบเจ็กต์ [IPPImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPPImage) โดยเพิ่มภาพลงใน [IImagescollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IImageCollection) ที่เชื่อมโยงกับออบเจ็กต์ presentation เพื่อใช้เติมรูปร่าง  
4. ระบุความกว้างและความสูงของภาพ  
5. สร้าง `PictureFrame` ตามความกว้างและความสูงของภาพผ่านเมธอด [AddPictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) ที่เปิดให้ใช้โดยออบเจ็กต์ [IShapes](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShapeCollection) ที่เชื่อมโยงกับสไลด์ที่อ้างอิง  
6. เพิ่มกรอบรูป (ที่บรรจุภาพ) ลงในสไลด์  
7. ตั้งค่าสีเส้นของกรอบรูป  
8. ตั้งค่าความกว้างของเส้นกรอบรูป  
9. หมุนกรอบรูปโดยให้ค่าเป็นบวกหรือเป็นลบ  
   * ค่าบวกหมุนภาพตามเข็มนาฬิกา  
   * ค่าลบหมุนภาพทวนเข็มนาฬิกา  
10. เพิ่มกรอบรูป (ที่บรรจุภาพ) ลงในสไลด์ (ขั้นตอนซ้ำเพื่อให้สอดคล้องกับตัวอย่างต้นฉบับ)  
11. เขียน presentation ที่ถูกแก้ไขเป็นไฟล์ PPTX  

โค้ด Java นี้แสดงกระบวนการจัดรูปแบบกรอบรูปภาพ:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // ดึงสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);
    
    // สร้างอินสแตนซ์ของคลาส Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // เพิ่มกรอบรูปภาพโดยใช้ความสูงและความกว้างเท่ากับภาพ
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // นำการจัดรูปแบบบางอย่างไปใช้กับ PictureFrameEx
    pf.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    
    // บันทึกไฟล์ PPTX ลงดิสก์
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="เคล็ดลับ" color="info" %}}
Aspose เพิ่งพัฒนา [free Collage Maker](https://products.aspose.app/slides/th/collage) หากคุณต้องการรวมภาพ JPG/JPEG หรือ PNG, หรือสร้างกริดจากรูปถ่าย คุณสามารถใช้บริการนี้ได้
{{% /alert %}}

## **เพิ่มภาพเป็นลิงก์**

เพื่อหลีกเลี่ยงขนาด presentation ที่ใหญ่ขึ้น คุณสามารถเพิ่มภาพ (หรือวิดีโอ) ผ่านลิงก์แทนการฝังไฟล์โดยตรง โค้ด Java นี้แสดงวิธีการเพิ่มภาพและวิดีโอเข้าไปในตัวจับตำแหน่ง:

```java
import com.aspose.slides.*;
import java.util.ArrayList;

Presentation presentation = new Presentation("input.pptx");
try {
    ArrayList<IShape> shapesToRemove = new ArrayList<IShape>();
    int shapesCount = presentation.getSlides().get_Item(0).getShapes().size();

    for (int i = 0; i < shapesCount; i++)
    {
        IShape autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(i);

        if (autoShape.getPlaceholder() == null)
        {
            continue;
        }

        switch (autoShape.getPlaceholder().getType())
        {
            case PlaceholderType.Picture:
                IPictureFrame pictureFrame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle,
                        autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), null);

                pictureFrame.getPictureFormat().getPicture().setLinkPathLong(
                        "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");

                shapesToRemove.add(autoShape);
                break;

            case PlaceholderType.Media:
                IVideoFrame videoFrame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(
                        autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), "");

                videoFrame.getPictureFormat().getPicture().setLinkPathLong(
                        "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");

                videoFrame.setLinkPathLong("https://youtu.be/t_1LYZ102RA");

                shapesToRemove.add(autoShape);
                break;
        }
    }

    for (IShape shape : shapesToRemove)
    {
        presentation.getSlides().get_Item(0).getShapes().remove(shape);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **ครอปภาพ**

โค้ด Java นี้แสดงวิธีการครอปภาพที่มีอยู่บนสไลด์:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
// สร้างอ็อบเจ็กต์ภาพใหม่
try {
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // เพิ่ม PictureFrame ไปยังสไลด์
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // ครอปภาพ (ค่าร้อยละ)
    picFrame.getPictureFormat().setCropLeft(23.6f);
    picFrame.getPictureFormat().setCropRight(21.5f);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);

    // บันทึกผลลัพธ์
    pres.save("cropped_image.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ลบพื้นที่ที่ครอปของกรอบรูปภาพ**

หากต้องการลบพื้นที่ที่ครอปของภาพที่อยู่ในกรอบ คุณสามารถใช้เมธอด [deletePictureCroppedAreas()](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) เมธอดนี้จะคืนภาพที่ถูกครอปหรือภาพต้นฉบับหากไม่ต้องครอป  

โค้ด Java นี้แสดงการทำงาน:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // ดึง PictureFrame จากสไลด์แรก
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // ลบพื้นที่ที่ครอปของรูปใน PictureFrame และคืนค่ารูปที่ถูกครอป
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // บันทึกผลลัพธ์
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="บันทึก" color="warning" %}} 
เมธอด [deletePictureCroppedAreas()](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) จะเพิ่มภาพที่ถูกครอปเข้าไปในคอลเลกชันภาพของ presentation หากภาพถูกใช้เฉพาะใน [PictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pictureframe/) ที่ประมวลผลแล้ว การตั้งค่านี้สามารถลดขนาด presentation ได้ มิฉะนั้นจำนวนภาพใน presentation ที่ได้จะเพิ่มขึ้น  

เมธอดนี้จะแปลงไฟล์เมต้าไฟล์ WMF/EMF เป็นภาพ raster PNG ในขั้นตอนการครอป 
{{% /alert %}}

## **บีบอัดภาพ**

คุณสามารถบีบอัดรูปใน presentation โดยใช้เมธอด [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) เมธอดนี้บีบอัดภาพโดยลดขนาดตามขนาดรูปร่างและความละเอียดที่กำหนด พร้อมตัวเลือกลบพื้นที่ที่ครอป  

มันปรับขนาดและความละเอียดของรูปภาพคล้ายกับฟีเจอร์ **Picture Format > Compress Pictures > Resolution** ของ PowerPoint  

ตัวอย่าง Java ต่อไปนี้แสดงวิธีบีบอัดภาพใน presentation โดยระบุความละเอียดเป้าหมายและเลือกลบพื้นที่ที่ครอป:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // บีบอัดภาพโดยกำหนดความละเอียดเป้าหมายเป็น 150 DPI (ความละเอียดเว็บ) และลบพื้นที่ที่ครอป
    boolean result = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);

    // Check the result of the compression.
    if (result) {
        System.out.println("Image successfully compressed.");
    } else {
        System.out.println("Image compression failed or no changes were necessary.");
    }

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

หรือใช้ค่า DPI ที่กำหนดเองโดยตรง:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // บีบอัดภาพเป็น 150 DPI (ความละเอียดเว็บ) และลบพื้นที่ที่ครอปออก.
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="บันทึก" color="warning" %}} 
เมธอดนี้จะแปลงภาพเป็นความละเอียดต่ำกว่าโดยอิงตามขนาดรูปร่างและ DPI ที่ให้ หากภาพเป็นเมต้าไฟล์ (WMF/EMF) หรือ SVG การบีบอัดจะไม่ถูกนำไปใช้ นอกจากนี้คุณภาพ JPEG จะถูกเก็บไว้หรือปรับลดเล็กน้อยตามความละเอียด เช่นเดียวกับที่ PowerPoint จัดการ JPEG ความละเอียดสูง 
{{% /alert %}}

## **ล็อคอัตราส่วนภาพ**

หากต้องการให้รูปร่างที่บรรจุภาพคงอัตราส่วนแม้หลังจากเปลี่ยนขนาดภาพ คุณสามารถใช้เมธอด [setAspectRatioLocked](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) เพื่อกำหนดการตั้งค่า *Lock Aspect Ratio*  

โค้ด Java นี้แสดงวิธีล็อคอัตราส่วนของรูปร่าง:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    ILayoutSlide layout = pres.getLayoutSlides().getByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.getSlides().addEmptySlide(layout);
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    IPictureFrame pictureFrame = emptySlide.getShapes().addPictureFrame(
            ShapeType.Rectangle, 50, 150, picture.getWidth(), picture.getHeight(), picture);

    // ตั้งรูปร่างให้คงอัตราส่วนเมื่อปรับขนาด
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="บันทึก" color="warning" %}} 
การตั้งค่า *Lock Aspect Ratio* นี้จะคงอัตราส่วนของรูปร่างเท่านั้น ไม่ได้คงอัตราส่วนของภาพที่บรรจุอยู่ 
{{% /alert %}}

## **ใช้คุณสมบัติ StretchOff**

โดยใช้คุณสมบัติ [StretchOffsetLeft](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) และ [StretchOffsetBottom](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) จากอินเทอร์เฟซ [IPictureFillFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPictureFillFormat) และคลาส [PictureFillFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPictureFillFormat) คุณสามารถระบุสี่เหลี่ยมเติมได้  

เมื่อกำหนดการยืดสำหรับภาพ สี่เหลี่ยมต้นฉบับจะถูกสเกลให้พอดีกับสี่เหลี่ยมเติมที่ระบุ แต่ละขอบของสี่เหลี่ยมเติมจะกำหนดโดยออฟเซ็ตเป็นเปอร์เซ็นต์จากขอบที่สอดคล้องของกล่องขอบเขตของรูปร่าง ค่าเปอร์เซ็นต์บวกหมายถึงการเข้าในขณะที่ค่าเปอร์เซ็นต์ลบหมายถึงการกว้างออก  

1. สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)  
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของสไลด์  
3. เพิ่มสี่เหลี่ยม `AutoShape`  
4. สร้างภาพ  
5. ตั้งค่าชนิดการเติมของรูปร่าง  
6. ตั้งค่าโหมดเติมรูปภาพของรูปร่าง  
7. เพิ่มภาพที่กำหนดให้เติมรูปร่าง  
8. ระบุออฟเซ็ตของภาพจากขอบที่สอดคล้องของกล่องขอบเขตของรูปร่าง  
9. เขียน presentation ที่ถูกแก้ไขเป็นไฟล์ PPTX  

โค้ด Java นี้แสดงกระบวนการใช้คุณสมบัติ StretchOff:

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // ดึงสไลด์แรก
    ISlide slide = pres.getSlides().get_Item(0);

    // สร้างอินสแตนซ์ของคลาส ImageEx
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // เพิ่ม AutoShape ตั้งค่าเป็น Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // ตั้งค่าชนิดการเติมของรูปร่าง
    aShape.getFillFormat().setFillType(FillType.Picture);

    // ตั้งค่าโหมดการเติมภาพของรูปร่าง
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // ตั้งค่าภาพเพื่อเติมรูปร่าง
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // ระบุออฟเซ็ตของภาพจากขอบที่สอดคล้องของกล่องขอบเขตของรูปร่าง
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);

    //Writes the PPTX file to disk
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **คำถามที่พบบ่อย**

### วิธีตรวจสอบว่ารูปแบบไฟล์ภาพใดบ้างที่รองรับสำหรับ PictureFrame?

Aspose.Slides รองรับทั้งรูปภาพ raster (PNG, JPEG, BMP, GIF ฯลฯ) และรูปภาพเวกเตอร์ (เช่น SVG) ผ่านออบเจ็กต์ภาพที่กำหนดให้กับ [PictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pictureframe/) รายการรูปแบบที่รองรับมักสอดคล้องกับความสามารถของเอนจินการแปลงสไลด์และภาพ  

### การเพิ่มภาพขนาดใหญ่หลายสิบไฟล์จะส่งผลต่อขนาดและประสิทธิภาพของ PPTX อย่างไร?

การฝังภาพขนาดใหญ่ทำให้ไฟล์ใหญ่ขึ้นและใช้หน่วยความจำเพิ่มขึ้น; การลิงก์ภาพช่วยลดขนาด presentation แต่ต้องให้ไฟล์ภายนอกยังคงเข้าถึงได้ Aspose.Slides มีความสามารถในการเพิ่มภาพโดยลิงก์เพื่อช่วยลดขนาดไฟล์  

### วิธีล็อคออบเจ็กต์ภาพไม่ให้ถูกย้าย/ปรับขนาดโดยบังเอิญ?

ใช้ [shape locks](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pictureframe/#getPictureFrameLock--) สำหรับ [PictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pictureframe/) (เช่น ปิดการย้ายหรือการปรับขนาด) กลไกการล็อคนี้รองรับหลายประเภทของรูปร่างรวมถึง [PictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pictureframe/)  

### การส่งออก SVG เวกเตอร์จาก presentation ไปเป็น PDF/รูปภาพจะคงคุณภาพเวกเตอร์หรือไม่?

Aspose.Slides สามารถแยก SVG จาก [PictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pictureframe/) เป็นเวกเตอร์ดั้งเดิมได้ เมื่อ [exporting to PDF](/slides/th/androidjava/convert-powerpoint-to-pdf/) หรือ [raster formats](/slides/th/androidjava/convert-powerpoint-to-png/) ผลลัพธ์อาจถูกแปลงเป็น raster ขึ้นอยู่กับการตั้งค่าการส่งออก; ความเป็นเวกเตอร์ของ SVG ดั้งเดิมจะได้รับการยืนยันโดยพฤติกรรมการแยกออก.