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
- เพิ่มรูปภาพ
- สร้างรูปภาพ
- สกัดรูปภาพ
- รูปภาพแรสเตอร์
- รูปภาพเวกเตอร์
- ตัดรูปภาพ
- พื้นที่ที่ถูกตัด
- คุณสมบัติ StretchOff
- การจัดรูปแบบกรอบรูปภาพ
- คุณสมบัติของกรอบรูปภาพ
- สเกลสัมพันธ์
- เอฟเฟกต์รูปภาพ
- อัตราส่วนด้าน
- ความโปร่งใสของรูปภาพ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Java
- Aspose.Slides
description: "เพิ่มกรอบรูปภาพในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Java. ทำให้กระบวนการทำงานของคุณเป็นระบบและปรับปรุงการออกแบบสไลด์."
---
## **บทนำ**

กรอบรูปภาพคือรูปทรงที่บรรจุรูปภาพ — คล้ายกับรูปภาพที่อยู่ในกรอบ

คุณสามารถเพิ่มรูปภาพลงในสไลด์ผ่านกรอบรูปภาพได้ วิธีนี้ทำให้คุณสามารถจัดรูปแบบรูปภาพได้โดยจัดรูปแบบกรอบรูปภาพ

{{% alert  title="Tip" color="info" %}} 

Aspose มีตัวแปลงฟรี — [แปลง JPEG เป็น PowerPoint](https://products.aspose.app/slides/th/import/jpg-to-ppt) และ [แปลง PNG เป็น PowerPoint](https://products.aspose.app/slides/th/import/png-to-ppt) — ที่ช่วยให้ผู้ใช้สร้างงานนำเสนอจากรูปภาพได้อย่างรวดเร็ว  

{{% /alert %}} 

## **สร้างกรอบรูปภาพ**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)  
2. รับอ้างอิงสไลด์ผ่านดัชนีของสไลด์  
3. สร้างอ็อบเจกต์ [IPPImage]() โดยเพิ่มรูปภาพลงใน [IImagescollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/IImageCollection) ที่เชื่อมโยงกับอ็อบเจกต์ presentation ซึ่งจะใช้เพื่อเติมรูปทรง  
4. กำหนดความกว้างและความสูงของรูปภาพ  
5. สร้าง [PictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/PictureFrame) ตามความกว้างและความสูงของรูปภาพผ่านเมธอด `AddPictureFrame` ที่เปิดให้ใช้งานโดยอ็อบเจกต์ shape ที่เชื่อมโยงกับสไลด์ที่อ้างอิง  
6. เพิ่มกรอบรูปภาพ (ที่บรรจุรูปภาพ) ลงในสไลด์  
7. เขียนงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX  

โค้ด Java ด้านล่างแสดงวิธีสร้างกรอบรูปภาพ:

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // รับสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);
    
    // สร้างอินสแตนซ์ของคลาส Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // เพิ่มกรอบรูปภาพโดยใช้ความสูงและความกว้างที่เท่ากับภาพ
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // บันทึกไฟล์ PPTX ลงดิสก์
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 

กรอบรูปภาพช่วยให้คุณสร้างสไลด์งานนำเสนอจากรูปภาพได้อย่างรวดเร็ว เมื่อคุณรวมกรอบรูปภาพกับตัวเลือกการบันทึก Aspose.Slides คุณสามารถจัดการการทำงานอินพุต/เอาต์พุตเพื่อแปลงรูปภาพจากรูปแบบหนึ่งเป็นอีกรูปแบบหนึ่งได้ คุณอาจต้องการดูหน้าเหล่านี้: แปลง [รูปภาพเป็น JPG](https://products.aspose.com/slides/th/java/conversion/image-to-jpg/) ; แปลง [JPG เป็นรูปภาพ](https://products.aspose.com/slides/th/java/conversion/jpg-to-image/) ; แปลง [JPG เป็น PNG](https://products.aspose.com/slides/th/java/conversion/jpg-to-png/), แปลง [PNG เป็น JPG](https://products.aspose.com/slides/th/java/conversion/png-to-jpg/) ; แปลง [PNG เป็น SVG](https://products.aspose.com/slides/th/java/conversion/png-to-svg/), แปลง [SVG เป็น PNG](https://products.aspose.com/slides/th/java/conversion/svg-to-png/)  

{{% /alert %}}

## **สร้างกรอบรูปภาพด้วยสเกลสัมพันธ์**

โดยการปรับสเกลสัมพันธ์ของรูปภาพ คุณสามารถสร้างกรอบรูปภาพที่ซับซ้อนได้มากขึ้น  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)  
2. รับอ้างอิงสไลด์ผ่านดัชนีของสไลด์  
3. เพิ่มรูปภาพลงในคอลlection ของรูปภาพใน presentation  
4. สร้างอ็อบเจกต์ [IPPImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPPImage) โดยเพิ่มรูปภาพลงใน [IImagescollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/IImageCollection) ที่เชื่อมโยงกับอ็อบเจกต์ presentation ซึ่งจะใช้เพื่อเติมรูปทรง  
5. กำหนดความกว้างและความสูงสัมพันธ์ของรูปภาพในกรอบรูปภาพ  
6. เขียนงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX  

โค้ด Java ด้านล่างแสดงวิธีสร้างกรอบรูปภาพด้วยสเกลสัมพันธ์:

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // รับสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);
    
    // สร้างอินสแตนซ์ของคลาส Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // เพิ่มกรอบรูปภาพโดยใช้ความสูงและความกว้างที่เท่ากับภาพ
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // กำหนดสเกลสัมพันธ์ของความกว้างและความสูง
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // บันทึกไฟล์ PPTX ลงดิสก์
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **สกัดภาพ Raster จากกรอบรูปภาพ**

คุณสามารถสกัดภาพ Raster จากอ็อบเจกต์ [PictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/PictureFrame) และบันทึกเป็น PNG, JPG และรูปแบบอื่น ๆ ตัวอย่างโค้ดด้านล่างแสดงวิธีสกัดรูปภาพจากไฟล์ “sample.pptx” แล้วบันทึกเป็นรูปแบบ PNG

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

## **สกัดภาพ SVG จากกรอบรูปภาพ**

เมื่อการพรีเซนเทชันมีกราฟิก SVG ที่วางอยู่ภายในรูปทรง [PictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/pictureframe/) Aspose.Slides for Java จะช่วยให้คุณดึงภาพเวกเตอร์ดั้งเดิมที่มีความละเอียดเต็มออกมาได้ โดยการเดินทางผ่านคอลlection รูปทรงของสไลด์ คุณสามารถระบุแต่ละ [PictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/pictureframe/), ตรวจสอบว่า [IPPImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/ippimage/) ที่อยู่ภายใต้มีเนื้อหา SVG หรือไม่ และจากนั้นบันทึกภาพนั้นลงดิสก์หรือสตรีมในรูปแบบ SVG ดั้งเดิม  

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีสกัดภาพ SVG จากกรอบรูปภาพ:

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

        // เมธอด getSvgImage จะคืนค่า null เมื่อรูปภาพเป็นภาพแรสเตอร์
        if (svgImage != null) {
            FileOutputStream fos = new FileOutputStream("output.svg");
            fos.write(svgImage.getSvgData());
            fos.close();
        }
    }
} catch (IOException e) {
    System.out.println(e.getMessage());
} finally {
    presentation.dispose();
}
```

## **รับค่าความโปร่งใสของภาพ**

Aspose.Slides ให้คุณรับค่าผลกระทบความโปร่งใสที่ใช้กับภาพ โค้ด Java ด้านล่างแสดงการทำงาน:

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

## **รับค่าความสว่างและคอนทราสต์ของภาพ**

Aspose.Slides ให้คุณรับค่าความสว่างและคอนทราสต์ที่ใช้กับภาพ อินเทอร์เฟซ [ILuminance](https://reference.aspose.com/slides/th/java/com.aspose.slides/iluminance/) แสดงผลการแปลงภาพนี้  

โค้ด Java ด้านล่างแสดงวิธีรับการตั้งค่าความสว่างและคอนทราสต์จากกรอบรูปภาพ:

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

## **จัดรูปแบบกรอบรูปภาพ**

Aspose.Slides มีตัวเลือกการจัดรูปแบบหลายอย่างที่สามารถนำไปใช้กับกรอบรูปภาพได้ โดยใช้ตัวเลือกเหล่านั้นคุณสามารถปรับกรอบรูปภาพให้ตรงกับความต้องการเฉพาะได้  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)  
2. รับอ้างอิงสไลด์ผ่านดัชนีของสไลด์  
3. สร้างอ็อบเจกต์ [IPPImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPPImage) โดยเพิ่มรูปภาพลงใน [IImagescollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/IImageCollection) ที่เชื่อมโยงกับอ็อบเจกต์ presentation ซึ่งจะใช้เพื่อเติมรูปทรง  
4. กำหนดความกว้างและความสูงของรูปภาพ  
5. สร้าง `PictureFrame` ตามความกว้างและความสูงของรูปภาพผ่านเมธอด [AddPictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) ที่เปิดให้ใช้งานโดยอ็อบเจกต์ [IShapes](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShapeCollection) ที่เชื่อมโยงกับสไลด์ที่อ้างอิง  
6. เพิ่มกรอบรูปภาพ (ที่บรรจุรูปภาพ) ลงในสไลด์  
7. ตั้งค่าสีเส้นของกรอบรูปภาพ  
8. ตั้งค่าความกว้างของเส้นกรอบรูปภาพ  
9. หมุนกรอบรูปภาพโดยกำหนดค่าบวกหรือเป็นลบ  
   * ค่าบวกจะหมุนภาพตามเข็มนาฬิกา  
   * ค่าลบจะหมุนภาพทวนเข็มนาฬิกา  
10. เพิ่มกรอบรูปภาพ (ที่บรรจุรูปภาพ) ลงในสไลด์  
11. เขียนงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX  

โค้ด Java ด้านล่างแสดงกระบวนการจัดรูปแบบกรอบรูปภาพ:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // รับสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);
    
    // สร้างอินสแตนซ์ของคลาส Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // เพิ่มกรอบรูปภาพโดยใช้ความสูงและความกว้างที่เท่ากับภาพ
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // ใช้การจัดรูปแบบบางอย่างกับ PictureFrameEx
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

{{% alert title="Tip" color="info" %}}

Aspose เพิ่งพัฒนา [Collage Maker ฟรี](https://products.aspose.app/slides/th/collage) หากคุณต้องการ [รวม JPG/JPEG](https://products.aspose.app/slides/th/collage/jpg) หรือ PNG, หรือ [สร้างกริดจากภาพถ่าย](https://products.aspose.app/slides/th/collage/photo-grid) คุณสามารถใช้บริการนี้ได้  

{{% /alert %}}

## **เพิ่มภาพเป็นลิงก์**

เพื่อหลีกเลี่ยงขนาดงานนำเสนอที่ใหญ่ คุณสามารถเพิ่มภาพ (หรือวิดีโอ) ผ่านลิงก์แทนการฝังไฟล์ลงในงานนำเสนอโดยตรง โค้ด Java ด้านล่างแสดงวิธีเพิ่มภาพและวิดีโอลงใน placeholder:

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

## **ตัดภาพ**

โค้ด Java ด้านล่างแสดงวิธีตัดส่วนของภาพที่มีอยู่บนสไลด์:

```java
import com.aspose.slides.*;

String imagePath = "image.png";
String outPptxFile = "CroppedImage_out.pptx";

Presentation pres = new Presentation();
// สร้างอ็อบเจกต์ภาพใหม่
try {
    IPPImage picture;
    IImage image = Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // เพิ่ม PictureFrame ไปยังสไลด์
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // ตัดรูปภาพ (ค่าร้อยละ)
    picFrame.getPictureFormat().setCropLeft(23.6f);
    picFrame.getPictureFormat().setCropRight(21.5f);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);

    // บันทึกผลลัพธ์
    pres.save(outPptxFile, SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ลบพื้นที่ที่ถูกตัดของรูปภาพ**

หากต้องการลบพื้นที่ที่ถูกตัดของภาพที่อยู่ในกรอบรูปภาพ คุณสามารถใช้เมธอด [deletePictureCroppedAreas()](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) เมธอดนี้จะคืนค่าภาพที่ถูกตัดหรือภาพต้นฉบับหากไม่จำเป็นต้องตัด  

โค้ด Java ด้านล่างแสดงการทำงาน:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // รับ PictureFrame จากสไลด์แรก
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // ลบพื้นที่ที่ถูกตัดของภาพใน PictureFrame และคืนค่าภาพที่ถูกตัด
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // บันทึกผลลัพธ์
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

เมธอด [deletePictureCroppedAreas()](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) จะเพิ่มภาพที่ถูกตัดลงในคอลlection ของรูปภาพใน presentation หากภาพถูกใช้เพียงใน [PictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/pictureframe/) ที่ประมวลผลอยู่ การตั้งค่านี้สามารถลดขนาดงานนำเสนอได้ มิฉะนั้นจำนวนภาพในงานนำเสนอที่ได้จะเพิ่มขึ้น  

เมธอดนี้แปลงไฟล์เมตาฟाइल WMF/EMF เป็นภาพ PNG raster ในกระบวนการตัด  

{{% /alert %}}

## **บีบอัดภาพ**

คุณสามารถบีบอัดภาพในงานนำเสนอโดยใช้เมธอด [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) เมธอดนี้บีบอัดภาพโดยลดขนาดตามขนาดรูปทรงและความละเอียดที่กำหนด พร้อมทั้งมีตัวเลือกเพื่อลบพื้นที่ที่ถูกตัด  

มันปรับขนาดและความละเอียดของภาพคล้ายคุณสมบัติ **Picture Format → Compress Pictures → Resolution** ของ PowerPoint  

ตัวอย่าง Java ด้านล่างแสดงวิธีบีบอัดภาพในงานนำเสนอโดยกำหนดความละเอียดเป้าหมายและเลือกลบพื้นที่ที่ถูกตัด:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // บีบอัดภาพโดยกำหนดความละเอียดเป้าหมายเป็น 150 DPI (ความละเอียดเว็บ) และลบพื้นที่ที่ถูกตัด
    boolean result = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);

    // ตรวจสอบผลลัพธ์ของการบีบอัด
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

    // บีบอัดภาพเป็น 150 DPI (ความละเอียดเว็บ) และลบพื้นที่ที่ถูกตัด.
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

เมธอดนี้แปลงภาพเป็นความละเอียดที่ต่ำกว่าโดยอิงตามขนาดรูปทรงและ DPI ที่ระบุ พื้นที่ที่ถูกตัดสามารถลบได้เพื่อเพิ่มประสิทธิภาพขนาดไฟล์  
หากภาพเป็นเมตาฟाइल (WMF/EMF) หรือ SVG การบีบอัดจะไม่ถูกนำไปใช้ อีกทั้งคุณภาพ JPEG จะถูกเก็บไว้หรือเสียเล็กน้อยตามความละเอียดเช่นเดียวกับที่ PowerPoint จัดการ JPEG ความละเอียดสูง  

{{% /alert %}}

## **ล็อคอัตราส่วนด้าน**

หากคุณต้องการให้รูปร่างที่บรรจุภาพคงอัตราส่วนด้านไว้แม้หลังจากเปลี่ยนมิติของภาพ คุณสามารถใช้เมธอด [setAspectRatioLocked](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) เพื่อตั้งค่าการ *Lock Aspect Ratio*  

โค้ด Java ด้านล่างแสดงวิธีล็อคอัตราส่วนด้านของรูปร่าง:

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

    // ตั้งค่าให้รูปร่างคงอัตราส่วนด้านเมื่อปรับขนาด
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

การตั้งค่า *Lock Aspect Ratio* นี้จะรักษาเฉพาะอัตราส่วนของรูปร่าง ไม่ได้รักษาภาพที่อยู่ภายใน  

{{% /alert %}}

## **ใช้คุณสมบัติ StretchOff**

โดยใช้คุณสมบัติ [StretchOffsetLeft](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) และ [StretchOffsetBottom](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) จากอินเทอร์เฟซ [IPictureFillFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPictureFillFormat) และคลาส [PictureFillFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPictureFillFormat) คุณสามารถระบุสี่เหลี่ยมเติมได้  

เมื่อกำหนดการยืดสำหรับภาพ สี่เหลี่ยมต้นฉบับจะถูกสเกลให้พอดีกับสี่เหลี่ยมเติมที่ระบุ แต่ละขอบของสี่เหลี่ยมเติมจะกำหนดด้วยออฟเซ็ตเปอร์เซ็นต์จากขอบที่สอดคล้องของกล่องขอบเขตรูปร่าง ออฟเซ็ตเป็นเปอร์เซ็นต์บวกหมายถึงการยืดเข้าในขณะที่บวกลบหมายถึงการยืดออกนอก  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)  
2. รับอ้างอิงสไลด์ผ่านดัชนีของสไลด์  
3. เพิ่มสี่เหลี่ยม `AutoShape`  
4. สร้างภาพ  
5. ตั้งค่าประเภทการเติมของรูปร่าง  
6. ตั้งค่าโหมดการเติมรูปภาพของรูปร่าง  
7. เพิ่มภาพที่ตั้งค่าเพื่อเติมรูปร่าง  
8. ระบุออฟเซ็ตของภาพจากขอบที่สอดคล้องของกล่องขอบเขตรูปร่าง  
9. เขียนงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX  

โค้ด Java ด้านล่างแสดงกระบวนการที่ใช้คุณสมบัติ StretchOff:

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // รับสไลด์แรก
    ISlide slide = pres.getSlides().get_Item(0);

    // สร้างอินสแตนซ์ของคลาส ImageEx
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // เพิ่ม AutoShape ที่ตั้งค่าเป็น Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // ตั้งค่าชนิดการเติมของรูปร่าง
    aShape.getFillFormat().setFillType(FillType.Picture);

    // ตั้งค่าโหมดการเติมรูปภาพของรูปร่าง
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // ตั้งค่าภาพเพื่อเติมรูปร่าง
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // ระบุออฟเซ็ตของภาพจากขอบที่สอดคล้องของกล่องขอบเขตของรูปร่าง
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);

    // บันทึกไฟล์ PPTX ลงดิสก์
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### ฉันจะตรวจสอบรูปแบบไฟล์ภาพที่รองรับสำหรับ PictureFrame ได้อย่างไร?

Aspose.Slides รองรับทั้งภาพ raster (PNG, JPEG, BMP, GIF ฯลฯ) และภาพเวกเตอร์ (เช่น SVG) ผ่านอ็อบเจกต์ภาพที่กำหนดให้กับ [PictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/pictureframe/) รายการรูปแบบที่รองรับมักจะตรงกับความสามารถของเอนจินการแปลงสไลด์และภาพ

### การเพิ่มรูปภาพขนาดใหญ่หลายสิบไฟล์จะส่งผลต่อขนาดและประสิทธิภาพของ PPTX อย่างไร?

การฝังรูปภาพขนาดใหญ่จะเพิ่มขนาดไฟล์และการใช้หน่วยความจำ; การเชื่อมโยงรูปภาพช่วยให้ขนาดงานนำเสนอคงที่แต่ต้องให้ไฟล์ภายนอกยังคงเข้าถึงได้ Aspose.Slides มีวิธีเพิ่มรูปภาพโดยลิงก์เพื่อช่วยลดขนาดไฟล์

### ฉันจะล็อคอ็อบเจกต์ภาพไม่ให้เคลื่อนย้ายหรือปรับขนาดโดยบังเอิญได้อย่างไร?

ใช้ [shape locks](https://reference.aspose.com/slides/th/java/com.aspose.slides/pictureframe/#getPictureFrameLock--) สำหรับ [PictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/pictureframe/) (เช่น ปิดการย้ายหรือการปรับขนาด) กลไกการล็อคอธิบายไว้ในบทความการปกป้องรูปทรงแยกต่างหาก [/slides/th/java/applying-protection-to-presentation/] และรองรับรูปทรงหลายประเภทรวมถึง [PictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/pictureframe/)

### ความแม่นยำของเวกเตอร์ SVG จะยังคงอยู่เมื่อส่งออกงานนำเสนอเป็น PDF/ภาพหรือไม่?

Aspose.Slides สามารถสกัด SVG จาก [PictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/pictureframe/) เป็นเวกเตอร์ดั้งเดิมได้ เมื่อ [ส่งออกเป็น PDF](/slides/th/java/convert-powerpoint-to-pdf/) หรือ [รูปแบบ raster](/slides/th/java/convert-powerpoint-to-png/) ผลลัพธ์อาจแปลงเป็น raster ขึ้นอยู่กับการตั้งค่าการส่งออก; การที่ SVG ดั้งเดิมถูกเก็บเป็นเวกเตอร์จะได้รับการยืนยันจากพฤติกรรมการสกัด.