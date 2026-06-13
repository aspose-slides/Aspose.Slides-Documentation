---
title: จัดการกรอบภาพในงานนำเสนอโดยใช้ Java
linktitle: กรอบภาพ
type: docs
weight: 10
url: /th/java/picture-frame/
keywords:
- กรอบภาพ
- เพิ่มกรอบภาพ
- สร้างกรอบภาพ
- เพิ่มรูปภาพ
- สร้างรูปภาพ
- สกัดรูปภาพ
- รูปแรสเตอร์
- รูปเวกเตอร์
- ครอบรูปภาพ
- พื้นที่ที่ถูกครอบ
- คุณสมบัติ StretchOff
- การจัดรูปแบบกรอบภาพ
- คุณสมบัติกรอบภาพ
- สเกลสัมพัทธ์
- เอฟเฟกต์รูปภาพ
- อัตราส่วนภาพ
- ความโปร่งใสของรูปภาพ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Java
- Aspose.Slides
description: "เพิ่มกรอบภาพในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Java. ปรับกระบวนการทำงานของคุณให้ราบรื่นและเพิ่มคุณภาพการออกแบบสไลด์."
---
## **บทนำ**

กรอบภาพคือรูปทรงที่บรรจุภาพ—คล้ายกับภาพในกรอบ

คุณสามารถเพิ่มรูปภาพลงในสไลด์ผ่านกรอบภาพได้ วิธีนี้ทำให้คุณสามารถจัดรูปแบบรูปภาพโดยการจัดรูปแบบกรอบภาพ

{{% alert  title="เคล็ดลับ" color="primary" %}} 

Aspose มีตัวแปลงฟรี—[JPEG to PowerPoint](https://products.aspose.app/slides/th/import/jpg-to-ppt) และ [PNG to PowerPoint](https://products.aspose.app/slides/th/import/png-to-ppt)—ซึ่งช่วยให้ผู้ใช้สร้างงานนำเสนออย่างรวดเร็วจากรูปภาพ

{{% /alert %}} 

## **สร้างกรอบภาพ**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)  
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน  
3. สร้างอ็อบเจกต์ [IPPImage]() โดยการเพิ่มรูปภาพลงใน [IImagescollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/IImageCollection) ที่เชื่อมโยงกับอ็อบเจกต์ Presentation ซึ่งจะใช้เพื่อเติมรูปทรง  
4. ระบุความกว้างและความสูงของรูปภาพ  
5. สร้าง [PictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/PictureFrame) ตามความกว้างและความสูงของรูปภาพผ่านเมธอด `AddPictureFrame` ที่เปิดให้ใช้งานโดยอ็อบเจกต์ shape ที่เชื่อมโยงกับสไลด์ที่อ้างอิง  
6. เพิ่มกรอบภาพ (ซึ่งบรรจุรูปภาพ) ลงในสไลด์  
7. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

โค้ด Java นี้แสดงวิธีสร้างกรอบภาพ:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // รับสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);
    
    // สร้างอินสแตนซ์ของคลาส Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // เพิ่มกรอบภาพโดยใช้ความกว้างและความสูงเท่ากับของภาพ
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // บันทึกไฟล์ PPTX ไปยังดิสก์
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 

กรอบภาพช่วยให้คุณสร้างสไลด์งานนำเสนอจากรูปภาพได้อย่างรวดเร็ว เมื่อผสมกรอบภาพกับตัวเลือกการบันทึกของ Aspose.Slides คุณสามารถจัดการการป้อน/ส่งออกเพื่อแปลงรูปภาพจากฟอร์แมตหนึ่งเป็นอีกฟอร์แมตหนึ่ง คุณอาจต้องการดูหน้านี้: แปลง [image to JPG](https://products.aspose.com/slides/th/java/conversion/image-to-jpg/); แปลง [JPG to image](https://products.aspose.com/slides/th/java/conversion/jpg-to-image/); แปลง [JPG to PNG](https://products.aspose.com/slides/th/java/conversion/jpg-to-png/), แปลง [PNG to JPG](https://products.aspose.com/slides/th/java/conversion/png-to-jpg/); แปลง [PNG to SVG](https://products.aspose.com/slides/th/java/conversion/png-to-svg/), แปลง [SVG to PNG](https://products.aspose.com/slides/th/java/conversion/svg-to-png/)

{{% /alert %}}

## **สร้างกรอบภาพด้วยสเกลสัมพัทธ์**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)  
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน  
3. เพิ่มรูปภาพลงในคอลเลกชันรูปภาพของงานนำเสนอ  
4. สร้างอ็อบเจกต์ [IPPImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPPImage) โดยการเพิ่มรูปภาพลงใน [IImagescollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/IImageCollection) ที่เชื่อมโยงกับอ็อบเจกต์ Presentation ซึ่งจะใช้เพื่อเติมรูปทรง  
5. ระบุความกว้างและความสูงสัมพัทธ์ของรูปภาพในกรอบภาพ  
6. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

โค้ด Java นี้แสดงวิธีสร้างกรอบภาพด้วยสเกลสัมพัทธ์:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // รับสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);
    
    // สร้างอินสแตนซ์ของคลาส Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // เพิ่มกรอบภาพโดยใช้ความสูงและความกว้างเท่ากับของภาพ
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // ตั้งค่าสเกลสัมพัทธ์ของความกว้างและความสูง
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // บันทึกไฟล์ PPTX ไปยังดิสก์
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **สกัดภาพแรสเตอร์จากกรอบภาพ**

คุณสามารถสกัดภาพแรสเตอร์จากอ็อบเจกต์ [PictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/PictureFrame) และบันทึกเป็น PNG, JPG หรือฟอร์แมตอื่น ๆ ตัวอย่างโค้ดด้านล่างแสดงวิธีสกัดภาพจากเอกสาร “sample.pptx” และบันทึกเป็นฟอร์แมต PNG

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

## **สกัดภาพ SVG จากกรอบภาพ**

เมื่อการนำเสนอมีกราฟิก SVG ที่วางอยู่ภายในรูปทรง [PictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/pictureframe/) Aspose.Slides for Java ให้คุณดึงภาพเวกเตอร์ต้นฉบับด้วยความแม่นยำเต็มรูปแบบ โดยการวนผ่านคอลเลกชันรูปทรงของสไลด์ คุณสามารถระบุแต่ละ [PictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/pictureframe/) ตรวจสอบว่า [IPPImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/ippimage/) รองรับเนื้อหา SVG หรือไม่ แล้วบันทึกภาพนั้นลงดิสก์หรือสตรีมในฟอร์แมต SVG ดิบ

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีสกัดภาพ SVG จากกรอบภาพ:

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

Aspose.Slides ให้คุณดึงเอาผลกระทบของความโปร่งใสที่ใช้กับภาพได้ โค้ด Java นี้แสดงการทำงาน:

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

## **การจัดรูปแบบกรอบภาพ**

Aspose.Slides มีตัวเลือกการจัดรูปแบบหลายอย่างที่สามารถใช้กับกรอบภาพได้ ด้วยตัวเลือกเหล่านั้นคุณสามารถปรับกรอบภาพให้ตรงตามความต้องการเฉพาะได้

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)  
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน  
3. สร้างอ็อบเจกต์ [IPPImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPPImage) โดยการเพิ่มรูปภาพลงใน [IImagescollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/IImageCollection) ที่เชื่อมโยงกับอ็อบเจกต์ Presentation ซึ่งจะใช้เพื่อเติมรูปทรง  
4. ระบุความกว้างและความสูงของรูปภาพ  
5. สร้าง `PictureFrame` ตามความกว้างและความสูงของรูปภาพผ่านเมธอด [AddPictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) ที่เปิดให้ใช้งานโดยอ็อบเจกต์ [IShapes](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShapeCollection) ที่เชื่อมโยงกับสไลด์ที่อ้างอิง  
6. เพิ่มกรอบภาพ (ซึ่งบรรจุรูปภาพ) ลงในสไลด์  
7. ตั้งค่าสีเส้นของกรอบภาพ  
8. ตั้งค่าความกว้างของเส้นกรอบภาพ  
9. หมุนกรอบภาพโดยกำหนดค่าที่เป็นบวกหรือเป็นลบ  
   * ค่าบวกหมุนภาพตามเข็มนาฬิกา  
   * ค่าลบหมุนภาพทวนเข็มนาฬิกา  
10. เพิ่มกรอบภาพ (ซึ่งบรรจุรูปภาพ) ลงในสไลด์  
11. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

โค้ด Java นี้แสดงกระบวนการจัดรูปแบบกรอบภาพ:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // รับสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);
    
    // สร้างอินสแตนซ์ของคลาส Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // เพิ่มกรอบภาพโดยใช้ความสูงและความกว้างเท่ากับของภาพ
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // ใช้การจัดรูปแบบบางอย่างกับ PictureFrameEx
    pf.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    
    // บันทึกไฟล์ PPTX ไปยังดิสก์
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="เคล็ดลับ" color="primary" %}}

Aspose เพิ่งพัฒนา [free Collage Maker](https://products.aspose.app/slides/th/collage) หากคุณต้องการ [รวม JPG/JPEG](https://products.aspose.app/slides/th/collage/jpg) หรือ PNG, หรือ [สร้างกริดจากรูปภาพ](https://products.aspose.app/slides/th/collage/photo-grid) คุณสามารถใช้บริการนี้ได้

{{% /alert %}}

## **เพิ่มรูปภาพเป็นลิงก์**

เพื่อหลีกเลี่ยงขนาดงานนำเสนอที่ใหญ่ คุณสามารถเพิ่มรูปภาพ (หรือวิดีโอ) ผ่านลิงก์แทนการฝังไฟล์โดยตรงในงานนำเสนอ โค้ด Java นี้แสดงวิธีเพิ่มรูปภาพและวิดีโอลงใน placeholder:

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

โค้ด Java นี้แสดงวิธีครอบภาพที่มีอยู่บนสไลด์:

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

    // ครอบตัดรูปภาพ (ค่าร้อยละ)
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

## **ลบพื้นที่ที่ครอบของภาพในกรอบ**

หากคุณต้องการลบพื้นที่ที่ครอบของภาพที่อยู่ในกรอบ คุณสามารถใช้เมธอด [deletePictureCroppedAreas()](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) เมธอดนี้คืนค่าภาพที่ถูกครอบหรือต้นฉบับหากไม่จำเป็นต้องครอบ

โค้ด Java นี้แสดงการทำงาน:

```java
Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // รับ PictureFrame จากสไลด์แรก
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // ลบพื้นที่ที่ครอบของรูปใน PictureFrame และคืนค่ารูปที่ถูกครอบ
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // บันทึกผลลัพธ์
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="หมายเหตุ" color="warning" %}} 

เมธอด [deletePictureCroppedAreas()](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) จะเพิ่มภาพที่ถูกครอบเข้าคอลเลกชันรูปภาพของงานนำเสนอ หากรูปภาพถูกใช้เฉพาะใน [PictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/pictureframe/) ที่ประมวลผล การตั้งค่านี้จะช่วยลดขนาดงานนำเสนอได้ มิฉะนั้นจำนวนรูปภาพในงานนำเสนอที่ได้จะเพิ่มขึ้น

เมธอดนี้จะทำการแปลงไฟล์เมท้าไฟล์ WMF/EMF เป็นภาพ PNG แรสเตอร์ในกระบวนการครอบ

{{% /alert %}}

## **บีบอัดภาพ**

คุณสามารถบีบอัดรูปในงานนำเสนอโดยใช้เมธอด [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) เมธอดนี้บีบอัดภาพโดยลดขนาดตามขนาดรูปทรงและความละเอียดที่ระบุ พร้อมตัวเลือกให้ลบพื้นที่ที่ครอบ

มันปรับขนาดและความละเอียดของรูปภาพคล้ายกับคุณลักษณะ **Picture Format -> Compress Pictures -> Resolution** ของ PowerPoint

ตัวอย่าง Java ด้านล่างแสดงวิธีบีบอัดภาพในงานนำเสนอโดยระบุความละเอียดเป้าหมายและอาจลบพื้นที่ที่ครอบ:

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // บีบอัดภาพด้วยความละเอียดเป้าหมาย 150 DPI (ความละเอียดเว็บ) และลบพื้นที่ที่ครอบ
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

หรือใช้ค่า DPI กำหนดเองโดยตรง:

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // บีบอัดภาพเป็น 150 DPI (ความละเอียดเว็บ) และลบพื้นที่ที่ครอบ
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="หมายเหตุ" color="warning" %}} 

เมธอดจะทำการแปลงภาพเป็นความละเอียดต่ำกว่าโดยอิงตามขนาดรูปทรงและ DPI ที่ให้ไว้ พื้นที่ที่ครอบก็สามารถลบเพื่อเพิ่มประสิทธิภาพขนาดไฟล์ได้  
หากภาพเป็นเมท้าไฟล์ (WMF/EMF) หรือ SVG การบีบอัดจะไม่ถูกนำไปใช้ นอกจากนี้คุณภาพ JPEG จะถูกรักษาหรือปรับลดเล็กน้อยตามความละเอียดเช่นเดียวกับที่ PowerPoint จัดการกับ JPEG ความละเอียดสูง

{{% /alert %}}

## **ล็อกอัตราส่วนภาพ**

หากคุณต้องการให้รูปทรงที่บรรจุภาพคงอัตราส่วนภาพแม้จะเปลี่ยนขนาดภาพแล้ว คุณสามารถใช้เมธอด [setAspectRatioLocked](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) เพื่อตั้งค่าการ *Lock Aspect Ratio*

โค้ด Java นี้แสดงวิธีล็อกอัตราส่วนของรูปทรง:

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

    // ตั้งรูปทรงให้คงอัตราส่วนเมื่อตัดขนาดใหม่
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="หมายเหตุ" color="warning" %}} 

การตั้งค่า *Lock Aspect Ratio* นี้จะคงอัตราส่วนของรูปทรงเท่านั้น ไม่ได้คงอัตราส่วนของภาพที่อยู่ภายใน

{{% /alert %}}

## **ใช้คุณสมบัติ StretchOff**

โดยใช้คุณสมบัติ [StretchOffsetLeft](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) และ [StretchOffsetBottom](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) จากอินเทอร์เฟซ [IPictureFillFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPictureFillFormat) และคลาส [PictureFillFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPictureFillFormat) คุณสามารถระบุสี่เหลี่ยมเติม

เมื่อกำหนดการยืดสำหรับภาพ สี่เหลี่ยมต้นฉบับจะถูกสเกลให้พอดีกับสี่เหลี่ยมเติมที่ระบุ แต่ละขอบของสี่เหลี่ยมเติมถูกกำหนดด้วยการเยื้องเป็นเปอร์เซ็นต์จากขอบที่สอดคล้องของกล่องขอบเขตของรูปทรง ค่าเปอร์เซ็นต์บวกหมายถึงการเยื้องเข้า ส่วนค่าเปอร์เซ็นต์ลบหมายถึงการเยื้องออก

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)  
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน  
3. เพิ่มสี่เหลี่ยม `AutoShape`  
4. สร้างรูปภาพ  
5. ตั้งค่าชนิดการเติมของรูปทรง  
6. ตั้งค่าโหมดการเติมรูปภาพของรูปทรง  
7. เพิ่มรูปภาพที่ใช้เติมรูปทรง  
8. ระบุการเยื้องของภาพจากขอบที่สอดคล้องของกล่องขอบเขตของรูปทรง  
9. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

โค้ด Java นี้แสดงกระบวนการที่ใช้คุณสมบัติ StretchOff:

```java
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

    // เพิ่ม AutoShape ตั้งค่าเป็น Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // ตั้งค่าชนิดการเติมของรูปทรง
    aShape.getFillFormat().setFillType(FillType.Picture);

    // ตั้งค่าโหมดการเติมรูปภาพของรูปทรง
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // ตั้งค่ารูปภาพเพื่อเติมรูปทรง
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // ระบุการเยื้องของรูปภาพจากขอบที่สอดคล้องของกล่องขอบเขตรูปทรง
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    
    // บันทึกไฟล์ PPTX ไปยังดิสก์
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **คำถามที่พบบ่อย**

**ฉันจะค้นหาฟอร์แมตภาพที่รองรับสำหรับ PictureFrame ได้อย่างไร?**

Aspose.Slides รองรับทั้งภาพแรสเตอร์ (PNG, JPEG, BMP, GIF ฯลฯ) และภาพเวกเตอร์ (เช่น SVG) ผ่านอ็อบเจกต์ภาพที่กำหนดให้กับ [PictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/pictureframe/) รายการฟอร์แมตที่รองรับมักจะตรงกับความสามารถของเอนจินแปลงสไลด์และภาพ

**การเพิ่มรูปภาพขนาดใหญ่หลายสิบรูปจะส่งผลต่อขนาดและประสิทธิภาพของ PPTX อย่างไร?**

การฝังรูปภาพขนาดใหญ่เพิ่มขนาดไฟล์และการใช้หน่วยความจำ; การลิงก์รูปภาพช่วยลดขนาดงานนำเสนอได้ แต่ไฟล์ภายนอกต้องยังคงเข้าถึงได้ Aspose.Slides รองรับการเพิ่มรูปภาพด้วยลิงก์เพื่อช่วยลดขนาดไฟล์

**ฉันจะล็อกอ็อบเจกต์ภาพไม่ให้เคลื่อนย้ายหรือปรับขนาดโดยบังเอิญได้อย่างไร?**

ใช้ [shape locks](https://reference.aspose.com/slides/th/java/com.aspose.slides/pictureframe/#getPictureFrameLock--) สำหรับ [PictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/pictureframe/) (เช่น ปิดการเคลื่อนย้ายหรือการปรับขนาด) กลไกการล็อกอธิบายไว้ในบทความการป้องกันรูปทรงแยกต่างหาก (/slides/th/java/applying-protection-to-presentation/) และรองรับหลายประเภทของรูปทรงรวมถึง [PictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/pictureframe/)

**ความแม่นยำของเวกเตอร์ SVG จะถูกเก็บไว้เมื่อส่งออกงานนำเสนอเป็น PDF/รูปภาพหรือไม่?**

Aspose.Slides ให้คุณสกัด SVG จาก [PictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/pictureframe/) เป็นเวกเตอร์ต้นฉบับ เมื่อ [ส่งออกเป็น PDF](/slides/th/java/convert-powerpoint-to-pdf/) หรือ [รูปแบบแรสเตอร์](/slides/th/java/convert-powerpoint-to-png/) ผลลัพธ์อาจถูกแรสเตอร์ขึ้นอยู่กับการตั้งค่าการส่งออก; การที่ SVG ดั้งเดิมยังคงเป็นเวกเตอร์ได้รับการยืนยันโดยพฤติกรรมการสกัดนี้