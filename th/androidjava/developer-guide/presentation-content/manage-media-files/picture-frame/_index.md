---
title: จัดการกรอบภาพในงานนำเสนอบน Android
linktitle: กรอบภาพ
type: docs
weight: 10
url: /th/androidjava/picture-frame/
keywords:
- กรอบภาพ
- เพิ่มกรอบภาพ
- สร้างกรอบภาพ
- เพิ่มภาพ
- สร้างภาพ
- สกัดภาพ
- ภาพเรสเตอร์
- ภาพเวคเตอร์
- ครอบภาพ
- พื้นที่ที่ถูกครอบ
- คุณสมบัติ StretchOff
- การจัดรูปแบบกรอบภาพ
- คุณสมบัติของกรอบภาพ
- สเกลสัมพัทธ์
- เอฟเฟกต์ภาพ
- อัตราส่วน
- ความโปร่งใสของภาพ
- PowerPoint
- OpenDocument
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เพิ่มกรอบภาพลงในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Android ผ่าน Java เพื่อทำให้กระบวนการทำงานของคุณเป็นระเบียบและปรับปรุงการออกแบบสไลด์."
---
## **บทนำ**

รูปแบบภาพเป็นรูปร่างที่บรรจุภาพ—มันเหมือนภาพที่อยู่ในกรอบ  

คุณสามารถเพิ่มภาพลงในสไลด์ผ่านรูปแบบภาพได้ วิธีนี้ทำให้คุณสามารถจัดรูปแบบภาพโดยการจัดรูปแบบรูปแบบภาพ  

{{% alert  title="Tip" color="primary" %}} 
Aspose ให้บริการแปลงฟรี—[JPEG to PowerPoint](https://products.aspose.app/slides/th/import/jpg-to-ppt) และ [PNG to PowerPoint](https://products.aspose.app/slides/th/import/png-to-ppt)—ซึ่งช่วยให้ผู้ใช้สร้างงานนำเสนอจากภาพได้อย่างรวดเร็ว. 
{{% /alert %}} 

## **Create a Picture Frame**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation).  
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน.  
3. สร้างอ็อบเจกต์ [IPPImage]() ด้วยการเพิ่มภาพลงใน [IImagescollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IImageCollection) ที่เชื่อมกับอ็อบเจกต์ Presentation ซึ่งจะใช้เพื่อเติมรูปร่าง.  
4. ระบุความกว้างและความสูงของภาพ.  
5. สร้าง [PictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/PictureFrame) ตามความกว้างและความสูงของภาพโดยใช้เมธอด `AddPictureFrame` ที่เปิดเผยโดยอ็อบเจกต์ shape ที่เชื่อมกับสไลด์ที่อ้างอิง.  
6. เพิ่ม Picture Frame (ที่บรรจุภาพ) ลงในสไลด์.  
7. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX.  

โค้ด Java นี้แสดงวิธีการสร้าง Picture Frame:  
```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // ดึงสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);
    
    // สร้างอินสแตนซ์ของคลาส Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // เพิ่มกรอบภาพด้วยความสูงและความกว้างที่เท่ากับภาพ
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // บันทึกไฟล์ PPTX ลงดิสก์
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Create a Picture Frame with Relative Scale**

โดยการปรับสเกลสัมพันธ์ของภาพ คุณสามารถสร้าง Picture Frame ที่ซับซ้อนได้มากขึ้น.  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation).  
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน.  
3. เพิ่มภาพลงในคอลเลกชันภาพของงานนำเสนอ.  
4. สร้างอ็อบเจกต์ [IPPImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPPImage) ด้วยการเพิ่มภาพลงใน [IImagescollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IImageCollection) ที่เชื่อมกับอ็อบเจกต์ Presentation ซึ่งจะใช้เพื่อเติมรูปร่าง.  
5. ระบุความกว้างและความสูงเชิงสัมพันธ์ของภาพใน Picture Frame.  
6. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX.  

โค้ด Java นี้แสดงวิธีการสร้าง Picture Frame ด้วยสเกลสัมพันธ์:  
```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // ดึงสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);
    
    // สร้างอินสแตนซ์ของคลาส Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // เพิ่มกรอบภาพด้วยความสูงและความกว้างที่เท่ากับภาพ
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // ตั้งค่าความกว้างและความสูงของสเกลสัมพัทธ์
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // บันทึกไฟล์ PPTX ลงดิสก์
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Extract Raster Images from Picture Frames**

คุณสามารถสกัดภาพเรสเตอร์จากอ็อบเจกต์ [PictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/PictureFrame) แล้วบันทึกเป็นรูปแบบ PNG, JPG และรูปแบบอื่น ๆ  
ตัวอย่างโค้ดด้านล่างแสดงวิธีสกัดภาพจากเอกสาร "sample.pptx" แล้วบันทึกเป็นรูปแบบ PNG.  
```java
Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    IShape firstShape = firstSlide.getShapes().get_Item(0);

    if (firstShape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) firstShape;
        try {
			IImage slideImage = pictureFrame.getPictureFormat().getPicture().getImage().getImage();
			slideImage.save("slide_1_shape_1.png", ImageFormat.Png);
		} finally {
			if (slideImage != null) slideImage.dispose();
		}
    }
} catch (IOException e) {
} finally {
    presentation.dispose();
}
```

## **Extract SVG Images from Picture Frames**

เมื่อการนำเสนอมีกราฟิก SVG ที่วางอยู่ภายในรูปแบบ [PictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pictureframe/) Aspose.Slides สำหรับ Android ผ่าน Java จะช่วยให้คุณดึงภาพเวกเตอร์ดั้งเดิมโดยคงความละเอียดเต็ม สามารถวนรอบคอลเลกชันรูปร่างของสไลด์เพื่อระบุแต่ละ [PictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pictureframe/), ตรวจสอบว่า [IPPImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/) ด้านล่างมีเนื้อหา SVG หรือไม่ แล้วบันทึกภาพนั้นลงดิสก์หรือสตรีมในรูปแบบ SVG ดั้งเดิม.  

โค้ดต่อไปนี้แสดงวิธีสกัดภาพ SVG จาก Picture Frame:  
```java
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

## **Get Transparency of an Image**

Aspose.Slides ให้คุณรับเอ็ฟเฟ็กต์ความโปร่งใสที่ใช้กับภาพได้ โค้ด Java นี้แสดงการทำงาน:  
```java
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

## **Picture Frame Formatting**

Aspose.Slides มีตัวเลือกการจัดรูปแบบหลายอย่างที่สามารถใช้กับ Picture Frame ได้ โดยใช้ตัวเลือกเหล่านั้นคุณสามารถปรับ Picture Frame ให้ตรงตามข้อกำหนดเฉพาะ.  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation).  
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน.  
3. สร้างอ็อบเจกต์ [IPPImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPPImage) ด้วยการเพิ่มภาพลงใน [IImagescollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IImageCollection) ที่เชื่อมกับอ็อบเจกต์ Presentation ซึ่งจะใช้เพื่อเติมรูปร่าง.  
4. ระบุความกว้างและความสูงของภาพ.  
5. สร้าง `PictureFrame` ตามความกว้างและความสูงของภาพโดยใช้เมธอด [AddPictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) ที่เปิดเผยโดยอ็อบเจกต์ [IShapes](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShapeCollection) ที่เชื่อมกับสไลด์ที่อ้างอิง.  
6. เพิ่ม Picture Frame (ที่บรรจุภาพ) ลงในสไลด์.  
7. ตั้งค่าสีเส้นของ Picture Frame.  
8. ตั้งค่าความกว้างของเส้น Picture Frame.  
9. หมุน Picture Frame โดยใส่ค่าเป็นบวกหรือเป็นลบ  
   * ค่าเป็นบวกจะหมุนภาพตามเข็มนาฬิกา.  
   * ค่าเป็นลบจะหมุนภาพทวนเข็มนาฬิกา.  
10. เพิ่ม Picture Frame (ที่บรรจุภาพ) ลงในสไลด์.  
11. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX.  

โค้ด Java นี้แสดงกระบวนการจัดรูปแบบ Picture Frame:  
```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // ดึงสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);
    
    // สร้างอินสแตนซ์ของคลาส Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // เพิ่มกรอบภาพด้วยความสูงและความกว้างที่เท่ากับภาพ
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // ใช้รูปแบบบางอย่างกับ PictureFrameEx
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

{{% alert title="Tip" color="primary" %}} 
Aspose เพิ่งพัฒนา [free Collage Maker](https://products.aspose.app/slides/th/collage). หากคุณต้องการ [merge JPG/JPEG](https://products.aspose.app/slides/th/collage/jpg) หรือ PNG images, [create grids from photos](https://products.aspose.app/slides/th/collage/photo-grid) คุณสามารถใช้บริการนี้ได้. 
{{% /alert %}} 

## **Add an Image as a Link**

เพื่อหลีกเลี่ยงขนาดไฟล์งานนำเสนอที่ใหญ่ คุณสามารถเพิ่มภาพ (หรือวิดีโอ) ผ่านลิงก์แทนการฝังไฟล์ลงในงานนำเสนอโดยตรง โค้ด Java นี้แสดงวิธีเพิ่มภาพและวิดีโอลงใน placeholder:  
```java
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

## **Crop Images**

โค้ด Java นี้แสดงวิธีการครอบภาพที่มีอยู่บนสไลด์:  
```java
Presentation pres = new Presentation();
// สร้างอ็อบเจกต์รูปภาพใหม่
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

    // ครอบภาพ (ค่าเป็นเปอร์เซ็นต์)
    picFrame.getPictureFormat().setCropLeft(23.6f);
    picFrame.getPictureFormat().setCropRight(21.5f);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);

    // บันทึกผลลัพธ์
    pres.save(outPptxFile, SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Delete Cropped Areas of a Picture**

หากคุณต้องการลบพื้นที่ที่ถูกตัดของภาพที่อยู่ในกรอบ คุณสามารถใช้เมธอด [deletePictureCroppedAreas()](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) ได้ เมธอดนี้จะคืนค่าภาพที่ถูกตัดหรือภาพต้นฉบับหากไม่จำเป็นต้องครอบ.  

โค้ด Java นี้แสดงการทำงาน:  
```java
Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // ดึง PictureFrame จากสไลด์แรก
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // ลบพื้นที่ที่ถูกครอบของภาพใน PictureFrame และคืนค่าภาพที่ถูกครอบ
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // บันทึกผลลัพธ์
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
เมธอด [deletePictureCroppedAreas()](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) จะเพิ่มภาพที่ถูกตัดลงในคอลเลกชันภาพของงานนำเสนอ หากภาพนั้นใช้เฉพาะใน [PictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pictureframe/) ที่ประมวลผลแล้ว การตั้งค่านี้สามารถลดขนาดไฟล์งานนำเสนอได้ มิฉะนั้นจำนวนภาพในงานนำเสนอที่ได้จะเพิ่มขึ้น.  

เมธอดนี้แปลงไฟล์เมต้าไฟล์ WMF/EMF ให้เป็นภาพ PNG เรสเตอร์ในกระบวนการครอบ. 
{{% /alert %}} 

## **Compress Images**

คุณสามารถบีบอัดรูปภาพในงานนำเสนอโดยใช้เมธอด [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) นี้บีบอัดภาพโดยลดขนาดตามขนาดของรูปร่างและความละเอียดที่ระบุ พร้อมตัวเลือกการลบพื้นที่ที่ถูกตัด.  

มันปรับขนาดและความละเอียดของรูปภาพคล้ายกับฟีเจอร์ **Picture Format > Compress Pictures > Resolution** ของ PowerPoint.  

ตัวอย่าง Java ด้านล่างแสดงวิธีบีบอัดภาพในงานนำเสนอโดยระบุความละเอียดเป้าหมายและอาจลบพื้นที่ที่ถูกตัด:  
```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // บีบอัดภาพด้วยความละเอียดเป้าหมาย 150 DPI (ความละเอียดเว็บ) และลบพื้นที่ที่ถูกครอบ
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

หรือใช้ค่ DPI ที่กำหนดเองโดยตรง:  
```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // บีบอัดภาพเป็น 150 DPI (ความละเอียดเว็บ) และลบพื้นที่ที่ถูกครอบ.
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
เมธอดนี้แปลงภาพเป็นความละเอียดต่ำกว่าโดยอิงจากขนาดของรูปร่างและ DPI ที่ให้ไว้ พื้นที่ที่ถูกตัดก็สามารถลบได้เพื่อเพิ่มประสิทธิภาพขนาดไฟล์.  
หากภาพเป็นเมต้าไฟล์ (WMF/EMF) หรือ SVG การบีบอัดจะไม่ถูกนำมาใช้ อีกทั้งคุณภาพ JPEG จะถูกคงไว้หรือถูกลดเล็กน้อยตามความละเอียด เหมือนกับที่ PowerPoint จัดการกับ JPEG ความละเอียดสูง. 
{{% /alert %}} 

## **Lock Aspect Ratio**

หากต้องการให้รูปร่างที่บรรจุภาพคงอัตราส่วนแม้เปลี่ยนขนาดภาพ คุณสามารถใช้เมธอด [setAspectRatioLocked](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) เพื่อตั้งค่า *Lock Aspect Ratio*.  

โค้ด Java นี้แสดงวิธีล็อกอัตราส่วนของรูปร่าง:  
```java
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
            ShapeType.Rectangle, 50, 150, presImage.getWidth(), presImage.getHeight(), picture);

    // ตั้งค่าให้รูปร่างคงอัตราส่วนเมื่อปรับขนาด
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
การตั้งค่า *Lock Aspect Ratio* นี้จะคงอัตราส่วนของรูปร่างเท่านั้น ไม่ใช่ของภาพที่บรรจุอยู่. 
{{% /alert %}} 

## **Use the StretchOff Property**

โดยใช้คุณสมบัติ [StretchOffsetLeft](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) และ [StretchOffsetBottom](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) จากอินเทอร์เฟซ [IPictureFillFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPictureFillFormat) และคลาส [PictureFillFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPictureFillFormat) คุณสามารถกำหนดสี่เหลี่ยมเติมได้.  

เมื่อกำหนดการยืดสำหรับภาพ สี่เหลี่ยมต้นฉบับจะถูกสเกลให้พอดีกับสี่เหลี่ยมเติมที่ระบุ แต่ละขอบของสี่เหลี่ยมเติมถูกกำหนดโดยออฟเซ็ตเปอร์เซ็นต์จากขอบของกล่องล้อมรอบของรูปร่าง ค่าเปอร์เซ็นต์บวกหมายถึงการย่อลด ส่วนค่าเปอร์เซ็นต์ลบหมายถึงการขยายออก.  

1. สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation).  
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน.  
3. เพิ่มสี่เหลี่ยม `AutoShape`.  
4. สร้างภาพ.  
5. ตั้งค่าชนิดการเติมของรูปร่าง.  
6. ตั้งค่าโหมดเติมภาพของรูปร่าง.  
7. เพิ่มภาพเพื่อเติมรูปร่าง.  
8. ระบุออฟเซ็ตของภาพจากขอบที่สอดคล้องของกล่องล้อมรอบของรูปร่าง.  
9. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX.  

โค้ด Java นี้แสดงกระบวนการที่ใช้คุณสมบัติ StretchOff:  
```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์ PPTX
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

    // ตั้งค่าโหมดเติมภาพของรูปร่าง
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // ตั้งค่าภาพเพื่อเติมรูปร่าง
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // กำหนดออฟเซ็ตของภาพจากขอบที่สอดคล้องของกล่องล้อมรอบของรูปร่าง
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    
    // บันทึกไฟล์ PPTX ลงดิสก์
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**How can I find out which image formats are supported for PictureFrame?**  
Aspose.Slides รองรับทั้งภาพเรสเตอร์ (PNG, JPEG, BMP, GIF ฯลฯ) และภาพเวกเตอร์ (เช่น SVG) ผ่านอ็อบเจกต์ภาพที่กำหนดให้กับ [PictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pictureframe/). รายการฟอร์แมตที่รองรับโดยทั่วไปสอดคล้องกับความสามารถของเอนจินแปลงสไลด์และภาพ.

**How will adding dozens of large images affect PPTX size and performance?**  
การฝังภาพขนาดใหญ่เพิ่มขนาดไฟล์และการใช้หน่วยความจำ; การลิงก์ภาพช่วยให้ขนาดงานนำเสนอเล็กลงแต่ไฟล์ภายนอกต้องเข้าถึงได้เสมอ. Aspose.Slides มีคุณสมบัติการเพิ่มภาพโดยลิงก์เพื่อช่วยลดขนาดไฟล์.

**How can I lock an image object from accidental moving/resizing?**  
ใช้ [shape locks](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pictureframe/#getPictureFrameLock--) สำหรับ [PictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pictureframe/) (เช่น ปิดการย้ายหรือการปรับขนาด). กลไกการล็อกนี้รองรับรูปแบบรูปร่างหลายประเภทรวมถึง [PictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pictureframe/).

**Is SVG vector fidelity preserved when exporting a presentation to PDF/images?**  
Aspose.Slides สามารถสกัด SVG ออกจาก [PictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pictureframe/) เป็นเวกเตอร์ดั้งเดิมได้อย่างเต็มที่ เมื่อ[exporting to PDF](/slides/th/androidjava/convert-powerpoint-to-pdf/) หรือ [raster formats](/slides/th/androidjava/convert-powerpoint-to-png/) ผลลัพธ์อาจถูกเรสเตอร์ขึ้นอยู่กับการตั้งค่าการส่งออก; ความจริงที่ว่า SVG ดั้งเดิมยังคงเป็นเวกเตอร์ได้รับการยืนยันโดยพฤติกรรมการสกัด.