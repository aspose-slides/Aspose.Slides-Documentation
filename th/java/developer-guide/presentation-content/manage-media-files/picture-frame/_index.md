---
title: จัดการกรอบรูปในงานนำเสนอด้วย Java
linktitle: กรอบรูป
type: docs
weight: 10
url: /th/java/picture-frame/
keywords:
- กรอบรูป
- เพิ่มกรอบรูป
- สร้างกรอบรูป
- เพิ่มภาพ
- สร้างภาพ
- สกัดภาพ
- ภาพเรสเตอร์
- ภาพเวกเตอร์
- ครอบภาพ
- พื้นที่ที่ครอป
- คุณสมบัติ StretchOff
- การจัดรูปแบบกรอบรูป
- คุณสมบัติกรอบรูป
- สเกลสัมพัทธ์
- เอฟเฟกต์ภาพ
- อัตราส่วน
- ความโปร่งใสของภาพ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Java
- Aspose.Slides
description: "เพิ่มกรอบรูปในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides for Java. ทำให้กระบวนการทำงานของคุณเป็นระเบียบและเสริมการออกแบบสไลด์."
---
## **บทนำ**

กรอบรูปเป็นรูปร่างที่บรรจุภาพ—เหมือนรูปภาพในกรอบ  

คุณสามารถเพิ่มรูปภาพลงในสไลด์ผ่านกรอบรูปได้ วิธีนี้คุณสามารถจัดรูปแบบภาพโดยการจัดรูปแบบกรอบรูป  

{{% alert  title="เคล็ดลับ" color="primary" %}} 
Aspose ให้บริการตัวแปลงฟรี—[JPEG to PowerPoint](https://products.aspose.app/slides/th/import/jpg-to-ppt) และ [PNG to PowerPoint](https://products.aspose.app/slides/th/import/png-to-ppt)—ซึ่งช่วยให้ผู้ใช้สร้างงานนำเสนอได้อย่างรวดเร็วจากภาพ  
{{% /alert %}} 

## **สร้างกรอบรูป**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)  
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน  
3. สร้างอ็อบเจกต์ [IPPImage]() โดยเพิ่มรูปภาพไปยัง [IImagescollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/IImageCollection) ที่เชื่อมโยงกับวัตถุการนำเสนอซึ่งจะใช้เพื่อเติมรูปร่าง  
4. ระบุความกว้างและความสูงของภาพ  
5. สร้าง [PictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/PictureFrame) ตามความกว้างและความสูงของภาพผ่านเมธอด `AddPictureFrame` ที่เปิดให้ใช้โดยอ็อบเจกต์ shape ที่เชื่อมโยงกับสไลด์ที่อ้างถึง  
6. เพิ่มกรอบรูป (ที่บรรจุภาพ) ลงในสไลด์  
7. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // ดึงสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);
    
    // สร้างอินสแตนซ์ของคลาส Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // เพิ่มกรอบรูปด้วยความสูงและความกว้างที่เทียบเท่าของรูปภาพ
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // บันทึกไฟล์ PPTX ลงดิสก์
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 
กรอบรูปช่วยให้คุณสร้างสไลด์งานนำเสนอจากภาพได้อย่างรวดเร็ว เมื่อคุณใช้กรอบรูปร่วมกับตัวเลือกการบันทึกของ Aspose.Slides คุณสามารถจัดการการทำงานแบบอินพุต/เอาต์พุตเพื่อแปลงภาพจากรูปแบบหนึ่งเป็นอีกรูปแบบหนึ่ง คุณอาจต้องการดูหน้าเหล่านี้: แปลง [image to JPG](https://products.aspose.com/slides/th/java/conversion/image-to-jpg/); แปลง [JPG to image](https://products.aspose.com/slides/th/java/conversion/jpg-to-image/); แปลง [JPG to PNG](https://products.aspose.com/slides/th/java/conversion/jpg-to-png/), แปลง [PNG to JPG](https://products.aspose.com/slides/th/java/conversion/png-to-jpg/); แปลง [PNG to SVG](https://products.aspose.com/slides/th/java/conversion/png-to-svg/), แปลง [SVG to PNG](https://products.aspose.com/slides/th/java/conversion/svg-to-png/)  
{{% /alert %}} 

## **สร้างกรอบรูปด้วยสเกลสัมพัทธ์**

โดยการปรับสเกลสัมพัทธ์ของภาพ คุณสามารถสร้างกรอบรูปที่ซับซ้อนยิ่งขึ้นได้  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)  
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน  
3. เพิ่มรูปภาพไปยังคอลเล็กชันรูปภาพของงานนำเสนอ  
4. สร้างอ็อบเจกต์ [IPPImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPPImage) โดยเพิ่มรูปภาพไปยัง [IImagescollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/IImageCollection) ที่เชื่อมโยงกับวัตถุการนำเสนอซึ่งจะใช้เพื่อเติมรูปร่าง  
5. ระบุความกว้างและความสูงสัมพัทธ์ของภาพในกรอบรูป  
6. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // ดึงสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);
    
    // สร้างอินสแตนซ์ของคลาส Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // เพิ่มกรอบรูปด้วยความสูงและความกว้างที่เทียบเท่าของรูปภาพ
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // ตั้งค่าสเกลสัมพัทธ์ของความกว้างและความสูง
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // บันทึกไฟล์ PPTX ลงดิสก์
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **สกัดภาพเรสเตอร์จากกรอบรูป**

คุณสามารถสกัดภาพเรสเตอร์จากอ็อบเจกต์ [PictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/PictureFrame) แล้วบันทึกเป็น PNG, JPG หรือรูปแบบอื่น ๆ ตัวอย่างโค้ดด้านล่างแสดงวิธีสกัดภาพจากเอกสาร “sample.pptx” และบันทึกเป็นรูปแบบ PNG  

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

## **สกัดภาพ SVG จากกรอบรูป**

เมื่อการนำเสนอมีกราฟิก SVG อยู่ภายในรูปร่าง [PictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/pictureframe/) Aspose.Slides for Java จะให้คุณดึงภาพเวกเตอร์ดั้งเดิมพร้อมความแม่นยำเต็มที่ ด้วยการวนผ่านคอลเล็กชันรูปร่างของสไลด์ คุณสามารถระบุแต่ละ [PictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/pictureframe/), ตรวจสอบว่า [IPPImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/ippimage/) มีเนื้อหา SVG หรือไม่ แล้วบันทึกภาพนั้นลงดิสก์หรือสตรีมในรูปแบบ SVG ดั้งเดิม  

ตัวอย่างโค้ดต่อไปนี้สาธิตวิธีสกัดภาพ SVG จากกรอบรูป  

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

## **รับค่าความโปร่งใสของภาพ**

Aspose.Slides ให้คุณดึงเอ็ฟเฟ็กต์ความโปร่งใสที่ใช้กับภาพได้ โค้ด Java ด้านล่างแสดงการทำงานนี้  

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

## **รับค่าความสว่างและความคอนทราสต์ของภาพ**

Aspose.Slides ให้คุณดึงเอ็ฟเฟ็กต์ความสว่างและความคอนทราสต์ที่ใช้กับภาพได้ อินเทอร์เฟซ [ILuminance](https://reference.aspose.com/slides/th/java/com.aspose.slides/iluminance/) แทนการแปลงภาพนี้  

โค้ด Java ด้านล่างแสดงวิธีดึงค่าความสว่างและความคอนทราสต์จากกรอบรูป  

```java
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

## **การจัดรูปแบบกรอบรูป**

Aspose.Slides มีตัวเลือกการจัดรูปแบบหลายอย่างที่สามารถนำไปใช้กับกรอบรูปได้ ด้วยตัวเลือกเหล่านี้คุณสามารถปรับกรอบรูปให้ตรงตามความต้องการเฉพาะได้  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)  
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน  
3. สร้างอ็อบเจกต์ [IPPImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPPImage) โดยเพิ่มรูปภาพไปยัง [IImagescollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/IImageCollection) ที่เชื่อมโยงกับวัตถุการนำเสนอซึ่งจะใช้เพื่อเติมรูปร่าง  
4. ระบุความกว้างและความสูงของภาพ  
5. สร้าง `PictureFrame` ตามความกว้างและความสูงของภาพผ่านเมธอด [AddPictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) ที่เปิดให้ใช้โดยอ็อบเจกต์ [IShapes](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShapeCollection) ที่เชื่อมโยงกับสไลด์ที่อ้างถึง  
6. เพิ่มกรอบรูป (ที่บรรจุภาพ) ลงในสไลด์  
7. ตั้งค่าสีเส้นของกรอบรูป  
8. ตั้งค่าความกว้างของเส้นกรอบรูป  
9. หมุนกรอบรูปโดยระบุค่าบวกหรือค่าลบ  
   * ค่าบวกจะหมุนภาพตามเข็มนาฬิกา  
   * ค่าลบจะหมุนภาพทวนเข็มนาฬิกา  
10. เพิ่มกรอบรูป (ที่บรรจุภาพ) ลงในสไลด์  
11. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // ดึงสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);
    
    // สร้างอินสแตนซ์ของคลาส Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // เพิ่มกรอบรูปด้วยความสูงและความกว้างที่เทียบเท่าของรูปภาพ
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

{{% alert title="เคล็ดลับ" color="primary" %}}
Aspose เพิ่งพัฒนา [Collage Maker ฟรี](https://products.aspose.app/slides/th/collage) หากคุณต้องการ [รวม JPG/JPEG](https://products.aspose.app/slides/th/collage/jpg) หรือ PNG, หรือ [สร้างกริดจากรูปถ่าย](https://products.aspose.app/slides/th/collage/photo-grid) คุณสามารถใช้บริการนี้ได้  
{{% /alert %}}

## **เพิ่มภาพเป็นลิงก์**

เพื่อหลีกเลี่ยงขนาดงานนำเสนอที่ใหญ่เกินไป คุณสามารถเพิ่มภาพ (หรือวิดีโอ) ผ่านลิงก์แทนการฝังไฟล์โดยตรงในงานนำเสนอ โค้ด Java ด้านล่างแสดงวิธีเพิ่มภาพและวิดีโอลงใน placeholder  

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

## **ครอบภาพ**

โค้ด Java ด้านล่างแสดงวิธีครอบภาพที่มีอยู่บนสไลด์  

```java
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

    // ครอบภาพ (ค่าร้อยละ)
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

## **ลบพื้นที่ที่ถูกครอปจากกรอบรูป**

หากต้องการลบพื้นที่ที่ถูกครอปของภาพที่อยู่ในกรอบรูป คุณสามารถใช้เมธอด [deletePictureCroppedAreas()](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) เมธอดนี้จะคืนค่าภาพที่ครอปแล้วหรือภาพต้นฉบับหากการครอปไม่จำเป็น  

โค้ด Java ด้านล่างสาธิตการทำงานนี้  

```java
Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // ดึง PictureFrame จากสไลด์แรก
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // ลบพื้นที่ที่ถูกครอปของภาพใน PictureFrame และคืนค่าภาพที่ถูกครอป
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // บันทึกผลลัพธ์
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="บันทึก" color="warning" %}} 
เมธอด [deletePictureCroppedAreas()](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) จะเพิ่มภาพที่ครอปแล้วเข้าไปในคอลเล็กชันรูปภาพของงานนำเสนอ หากภาพถูกใช้เฉพาะใน [PictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/pictureframe/) ที่ประมวลผล วิธีนี้สามารถลดขนาดงานนำเสนอได้ มิฉะนั้นจำนวนภาพในงานนำเหตุผลที่ได้จะเพิ่มขึ้น  

เมธอดนี้แปลงไฟล์เมตาฟายล์ WMF/EMF เป็นภาพ PNG แบบเรสเตอร์ในขั้นตอนการครอป  
{{% /alert %}}

## **บีบอัดภาพ**

คุณสามารถบีบอัดรูปในงานนำเสนอโดยใช้เมธอด [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) เมธอดนี้บีบอัดภาพโดยลดขนาดตามขนาดรูปร่างและความละเอียดที่ระบุ พร้อมตัวเลือกให้ลบพื้นที่ที่ครอป  

มันปรับขนาดและความละเอียดของรูปคล้ายกับฟีเจอร์ **Picture Format → Compress Pictures → Resolution** ของ PowerPoint  

ตัวอย่าง Java ด้านล่างแสดงวิธีบีบอัดภาพในงานนำเสนอโดยกำหนดความละเอียดเป้าหมายและเลือกลบพื้นที่ที่ครอปหรือไม่  

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // บีบอัดภาพด้วยความละเอียดเป้าหมาย 150 DPI (ความละเอียดเว็บ) และลบพื้นที่ที่ถูกครอป
    boolean result = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);

    // ตรวจสอบผลของการบีบอัด
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

หรือใช้ค่าความละเอียด DPI ที่กำหนดเองโดยตรง  

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // บีบอัดภาพเป็น 150 DPI (ความละเอียดเว็บ) โดยลบพื้นที่ที่ถูกครอปออก.
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="บันทึก" color="warning" %}} 
เมธอดนี้แปลงภาพเป็นความละเอียดต่ำกว่าโดยอิงตามขนาดของรูปร่างและ DPI ที่ให้ไว้ สามารถลบพื้นที่ที่ครอปเพื่อเพิ่มประสิทธิภาพขนาดไฟล์ได้  
หากภาพเป็นเมตาฟายล์ (WMF/EMF) หรือ SVG การบีบอัดจะไม่ถูกนำไปใช้ อีกทั้งคุณภาพ JPEG จะถูกเก็บรักษาหรือปรับลดเล็กน้อยตามความละเอียดเช่นเดียวกับการจัดการของ PowerPoint  
{{% /alert %}}

## **ล็อกอัตราส่วน**

หากต้องการให้รูปร่างที่บรรจุภาพคงอัตราส่วนเดิมแม้เปลี่ยนขนาดภาพ คุณสามารถใช้เมธอด [setAspectRatioLocked](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) เพื่อตั้งค่าการ *Lock Aspect Ratio*  

โค้ด Java ด้านล่างแสดงวิธีล็อกอัตราส่วนของรูปร่าง  

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

    // ตั้งค่ารูปร่างให้รักษาอัตราส่วนเมื่อปรับขนาด
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="บันทึก" color="warning" %}} 
การตั้งค่า *Lock Aspect Ratio* นี้จะรักษาอัตราส่วนของรูปร่างเท่านั้น ไม่รวมถึงภาพที่บรรจุอยู่ภายใน  
{{% /alert %}}

## **ใช้คุณสมบัติ StretchOff**

โดยใช้คุณสมบัติ [StretchOffsetLeft](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) และ [StretchOffsetBottom](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) จากอินเทอร์เฟซ [IPictureFillFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPictureFillFormat) และคลาส [PictureFillFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPictureFillFormat) คุณสามารถกำหนดสี่เหลี่ยมเติมได้  

เมื่อกำหนดการยืดสำหรับภาพ สี่เหลี่ยมต้นฉบับจะถูกสเกลให้พอดีกับสี่เหลี่ยมเติมที่ระบุ แต่ละขอบของสี่เหลี่ยมเติมถูกกำหนดด้วยออฟเซ็ตเปอร์เซ็นต์จากขอบที่สอดคล้องของกล่องขอบเขตรูปร่าง ออฟเซ็ตเปอร์เซ็นต์บวกแสดงการเว้นระยะในขณะออฟเซ็ตเปอร์เซ็นต์ลบแสดงการขยายออก  

1. สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)  
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน  
3. เพิ่ม `AutoShape` แบบสี่เหลี่ยม  
4. สร้างภาพ  
5. ตั้งค่าประเภทการเติมของรูปร่าง  
6. ตั้งค่าโหมดการเติมรูปของรูปร่าง  
7. เพิ่มภาพเพื่อเติมรูปร่าง  
8. ระบุออฟเซ็ตของภาพจากขอบที่สอดคล้องของกล่องขอบเขตรูปร่าง  
9. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
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

    // เพิ่ม AutoShape ตั้งค่าเป็นสี่เหลี่ยม
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // ตั้งค่าชนิดการเติมของรูปร่าง
    aShape.getFillFormat().setFillType(FillType.Picture);

    // ตั้งค่าโหมดการเติมรูปภาพของรูปร่าง
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // ตั้งค่าภาพเพื่อเติมรูปร่าง
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // ระบุออฟเซ็ตของภาพจากขอบที่สอดคล้องของกล่องขอบเขตรูปร่าง
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    
    //บันทึกไฟล์ PPTX ลงดิสก์
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **คำถามที่พบบ่อย**

**ฉันจะตรวจสอบได้ว่ารูปแบบภาพใดบ้างที่รองรับสำหรับ PictureFrame?**  
Aspose.Slides รองรับทั้งภาพเรสเตอร์ (PNG, JPEG, BMP, GIF ฯลฯ) และภาพเวกเตอร์ (เช่น SVG) ผ่านอ็อบเจกต์ภาพที่กำหนดให้กับ [PictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/pictureframe/) รายชื่อรูปแบบที่รองรับมักสอดคล้องกับความสามารถของเอนจินการแปลงสไลด์และภาพ

**การเพิ่มรูปภาพจำนวนมากขนาดใหญ่จะส่งผลต่อขนาดและประสิทธิภาพของไฟล์ PPTX อย่างไร?**  
การฝังรูปภาพขนาดใหญ่จะเพิ่มขนาดไฟล์และการใช้หน่วยความจำ; การลิงก์รูปภาพช่วยลดขนาดงานนำเสนอแต่ต้องให้ไฟล์ภายนอกยังคงเข้าถึงได้ Aspose.Slides มีความสามารถในการเพิ่มรูปภาพโดยลิงก์เพื่อประหยัดขนาดไฟล์

**ฉันจะล็อกอ็อบเจกต์ภาพไม่ให้ถูกย้ายหรือปรับขนาดโดยไม่ได้ตั้งใจได้อย่างไร?**  
ใช้ [shape locks](https://reference.aspose.com/slides/th/java/com.aspose.slides/pictureframe/#getPictureFrameLock--) สำหรับ [PictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/pictureframe/) (เช่น ปิดการย้ายหรือปรับขนาด) กลไกการล็อกนี้อธิบายไว้สำหรับรูปร่างในบทความการป้องกันแยกต่างหาก [/slides/th/java/applying-protection-to-presentation/] และรองรับหลายประเภทรูปร่างรวมถึง [PictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/pictureframe/)

**ความแม่นยำของเวกเตอร์ SVG จะถูกเก็บรักษาเมื่อส่งออกงานนำเสนอเป็น PDF/รูปภาพหรือไม่?**  
Aspose.Slides สามารถสกัด SVG จาก [PictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/pictureframe/) ได้เป็นเวกเตอร์ดั้งเดิม เมื่อ [ส่งออกเป็น PDF](/slides/th/java/convert-powerpoint-to-pdf/) หรือ [รูปแบบเรสเตอร์](/slides/th/java/convert-powerpoint-to-png/) ผลลัพธ์อาจถูกเรสเตอร์ขึ้นขึ้นอยู่กับการตั้งค่าการส่งออก; ความจริงว่า SVG ดั้งเดิมถูกเก็บเป็นเวกเตอร์จะได้รับการยืนยันจากพฤติกรรมการสกัด  

