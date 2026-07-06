---
title: "จัดการกรอบภาพในงานนำเสนอบน Android"
linktitle: "กรอบภาพ"
type: docs
weight: 10
url: /th/androidjava/picture-frame/
keywords:
- "กรอบภาพ"
- "เพิ่มกรอบภาพ"
- "สร้างกรอบภาพ"
- "เพิ่มภาพ"
- "สร้างภาพ"
- "ดึงภาพ"
- "ภาพเรสเตอร์"
- "ภาพเวกเตอร์"
- "ตัดภาพ"
- "พื้นที่ที่ตัด"
- "คุณสมบัติ StretchOff"
- "การจัดรูปแบบกรอบภาพ"
- "คุณสมบัติกรอบภาพ"
- "สเกลสัมพัทธ์"
- "เอฟเฟกต์ภาพ"
- "อัตราส่วนภาพ"
- "ความโปร่งใสของภาพ"
- "PowerPoint"
- "OpenDocument"
- "งานนำเสนอ"
- "Android"
- "Java"
- "Aspose.Slides"
description: "เพิ่มกรอบภาพลงในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Android ผ่าน Java. ทำให้กระบวนการทำงานของคุณสะดวกขึ้นและพัฒนาการออกแบบสไลด์."
---
## **บทนำ**

กรอบภาพเป็นรูปทรงที่บรรจุภาพ—คล้ายกับรูปภาพในกรอบ  

คุณสามารถเพิ่มภาพลงในสไลด์ผ่านกรอบภาพได้ วิธีนี้ทำให้คุณสามารถจัดรูปแบบภาพโดยการจัดรูปแบบกรอบภาพ  

{{% alert  title="Tip" color="primary" %}} 
Aspose มีเครื่องแปลงฟรี—[JPEG เป็น PowerPoint](https://products.aspose.app/slides/th/import/jpg-to-ppt) และ [PNG เป็น PowerPoint](https://products.aspose.app/slides/th/import/png-to-ppt)—ซึ่งช่วยให้ผู้ใช้สร้างงานนำเสนออย่างรวดเร็วจากภาพ  
{{% /alert %}} 

## **สร้างกรอบภาพ**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)  
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน  
3. สร้างอ็อบเจ็กต์ [IPPImage]() โดยการเพิ่มภาพไปยัง [IImagescollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IImageCollection) ที่เชื่อมโยงกับอ็อบเจ็กต์ Presentation ที่จะใช้เติมรูปทรง  
4. ระบุความกว้างและความสูงของภาพ  
5. สร้าง [PictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/PictureFrame) ตามความกว้างและความสูงของภาพโดยใช้เมธอด `AddPictureFrame` ที่เปิดให้ใช้งานจากอ็อบเจ็กต์ shape ที่เชื่อมโยงกับสไลด์ที่อ้างอิง  
6. เพิ่มกรอบภาพ (ที่บรรจุภาพ) ไปยังสไลด์  
7. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

โค้ด Java นี้แสดงวิธีสร้างกรอบภาพ:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // ดึงสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);
    
    // สร้างอินสแตนซ์ของคลาส Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // เพิ่มกรอบภาพโดยใช้ความสูงและความกว้างเท่ากับของภาพ
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // เขียนไฟล์ PPTX ไปยังดิสก์
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **สร้างกรอบภาพพร้อมสเกลสัมพัทธ์**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)  
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน  
3. เพิ่มภาพไปยังคอลเลกชันภาพของงานนำเสนอ  
4. สร้างอ็อบเจ็กต์ [IPPImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPPImage) โดยการเพิ่มภาพไปยัง [IImagescollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IImageCollection) ที่เชื่อมโยงกับอ็อบเจ็กต์ Presentation ที่จะใช้เติมรูปทรง  
5. ระบุความกว้างและความสูงสัมพัทธ์ของภาพในกรอบภาพ  
6. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

โค้ด Java นี้แสดงวิธีสร้างกรอบภาพพร้อมสเกลสัมพัทธ์:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // ดึงสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);
    
    // สร้างอินสแตนซ์ของคลาส Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // เพิ่มกรอบภาพโดยใช้ความสูงและความกว้างเท่ากับของภาพ
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // ตั้งค่าสเกลสัมพัทธ์ของความกว้างและความสูง
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // เขียนไฟล์ PPTX ไปยังดิสก์
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **ดึงภาพเรสเตอร์จากกรอบภาพ**

คุณสามารถดึงภาพเรสเตอร์จากอ็อบเจ็กต์ [PictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/PictureFrame) และบันทึกเป็นรูปแบบ PNG, JPG และอื่น ๆ ตัวอย่างโค้ดด้านล่างแสดงวิธีดึงภาพจากเอกสาร “sample.pptx” และบันทึกเป็นรูปแบบ PNG  

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

## **ดึงภาพ SVG จากกรอบภาพ**

เมื่อการนำเสนอมีกราฟิก SVG ใส่ภายในรูปทรง [PictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pictureframe/) Aspose.Slides สำหรับ Android ผ่าน Java ให้คุณดึงภาพเวกเตอร์ต้นฉบับออกมาด้วยความแม่นยำเต็มรูปแบบ โดยการวนผ่านคอลเลกชันรูปทรงของสไลด์ คุณสามารถระบุแต่ละ [PictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pictureframe/) ตรวจสอบว่า [IPPImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/) ทำงานในรูปแบบ SVG หรือไม่ แล้วบันทึกภาพนั้นไปยังดิสก์หรือสตรีมในรูปแบบ SVG ดั้งเดิม  

โค้ดตัวอย่างต่อไปนี้แสดงวิธีดึงภาพ SVG จากกรอบภาพ:

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

Aspose.Slides อนุญาตให้คุณรับค่าผลลัพธ์ความโปร่งใสที่ใช้กับภาพ โค้ด Java นี้แสดงการทำงาน:

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

## **รับค่าความสว่างและคอนทราสต์ของภาพ**

Aspose.Slides อนุญาตให้คุณรับค่าผลลัพธ์ความสว่างและคอนทราสต์ที่ใช้กับภาพ อินเทอร์เฟซ [ILuminance](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iluminance/) แสดงถึงการแปลงภาพนี้  

โค้ด Java นี้แสดงวิธีรับการตั้งค่าความสว่างและคอนทราสต์จากกรอบภาพ:

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

## **การจัดรูปแบบกรอบภาพ**

Aspose.Slides ให้ตัวเลือกการจัดรูปแบบหลายแบบที่สามารถใช้กับกรอบภาพได้ โดยใช้ตัวเลือกเหล่านั้น คุณสามารถปรับกรอบภาพให้ตรงกับข้อกำหนดเฉพาะได้  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)  
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน  
3. สร้างอ็อบเจ็กต์ [IPPImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPPImage) โดยการเพิ่มภาพไปยัง [IImagescollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IImageCollection) ที่เชื่อมโยงกับอ็อบเจ็กต์ Presentation ที่จะใช้เติมรูปทรง  
4. ระบุความกว้างและความสูงของภาพ  
5. สร้าง `PictureFrame` ตามความกว้างและความสูงของภาพโดยใช้เมธอด [AddPictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) ที่เปิดให้ใช้งานจากอ็อบเจ็กต์ [IShapes](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShapeCollection) ที่เชื่อมโยงกับสไลด์ที่อ้างอิง  
6. เพิ่มกรอบภาพ (ที่บรรจุภาพ) ไปยังสไลด์  
7. ตั้งค่าสีเส้นของกรอบภาพ  
8. ตั้งค่าความกว้างของเส้นกรอบภาพ  
9. หมุนกรอบภาพโดยให้ค่าบวกหรือค่าลบ  
   * ค่าบวกจะหมุนภาพตามเข็มนาฬิกา  
   * ค่าลบจะหมุนภาพทวนเข็มนาฬิกา  
10. เพิ่มกรอบภาพ (ที่บรรจุภาพ) ไปยังสไลด์  
11. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

โค้ด Java นี้แสดงกระบวนการจัดรูปแบบกรอบภาพ:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // ดึงสไลด์แรก
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
    
    // เขียนไฟล์ PPTX ไปยังดิสก์
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Tip" color="primary" %}}
Aspose เพิ่งพัฒนา [free Collage Maker](https://products.aspose.app/slides/th/collage) หากคุณต้องการ [merge JPG/JPEG](https://products.aspose.app/slides/th/collage/jpg) หรือ PNG images, [create grids from photos](https://products.aspose.app/slides/th/collage/photo-grid) สามารถใช้บริการนี้ได้  
{{% /alert %}}

## **เพิ่มภาพเป็นลิงก์**

เพื่อหลีกเลี่ยงขนาดงานนำเสนอที่ใหญ่ คุณสามารถเพิ่มภาพ (หรือวิดีโอ) ผ่านลิงก์แทนการฝังไฟล์ลงในงานนำเสนอโดยตรง โค้ด Java นี้แสดงวิธีเพิ่มภาพและวิดีโอลงใน placeholder:

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

## **ตัดภาพ**

โค้ด Java นี้แสดงวิธีตัดภาพที่มีอยู่บนสไลด์:

```java
Presentation pres = new Presentation();
// สร้างอ็อบเจ็กต์ภาพใหม่
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

    // ทำการครอปภาพ (ค่าร้อยละ)
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

## **ลบส่วนที่ถูกตัดของภาพ**

หากต้องการลบส่วนที่ถูกตัดของภาพที่อยู่ในกรอบ คุณสามารถใช้เมธอด [deletePictureCroppedAreas()](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) เมธอดนี้จะคืนค่าภาพที่ถูกตัดหรือภาพต้นฉบับหากไม่จำเป็นต้องตัด  

โค้ด Java นี้แสดงการทำงาน:

```java
Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // ดึง PictureFrame จากสไลด์แรก
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // ลบส่วนที่ถูกครอปของภาพ PictureFrame และคืนค่าภาพที่ถูกครอป
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // บันทึกผลลัพธ์
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
เมธอด [deletePictureCroppedAreas()](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) จะเพิ่มภาพที่ถูกตัดลงในคอลเลกชันภาพของงานนำเสนอ หากภาพนั้นใช้เพียงใน [PictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pictureframe/) ที่ประมวลผล วิธีนี้สามารถลดขนาดงานนำเสนอได้ หากไม่เช่นนั้น จำนวนภาพในงานนำเสนอที่ได้จะเพิ่มขึ้น  

เมธอดนี้แปลงไฟล์เมต้าไฟล์ WMF/EMF เป็นภาพ PNG เรสเตอร์ในขั้นตอนการตัดภาพ  
{{% /alert %}}

## **บีบอัดภาพ**

คุณสามารถบีบอัดรูปในงานนำเสนอโดยใช้เมธอด [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-)  
เมธอดนี้บีบอัดภาพโดยลดขนาดตามขนาดรูปทรงและความละเอียดที่กำหนด พร้อมตัวเลือกการลบส่วนที่ถูกตัด  

เมธอดนี้ปรับขนาดและความละเอียดของภาพคล้ายคุณลักษณะ **Picture Format > Compress Pictures > Resolution** ของ PowerPoint  

ตัวอย่าง Java ด้านล่างแสดงวิธีบีบอัดภาพในงานนำเสนอโดยระบุความละเอียดเป้าหมายและอาจลบส่วนที่ถูกตัด:

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // บีบอัดภาพด้วยความละเอียดเป้าหมาย 150 DPI (ความละเอียดเว็บ) และลบส่วนที่ถูกครอป
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

หรือตั้งค่า DPI เองโดยตรง:

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // บีบอัดภาพเป็น 150 DPI (ความละเอียดเว็บ) โดยลบส่วนที่ถูกครอป.
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
เมธอดนี้แปลงภาพเป็นความละเอียดต่ำกว่าโดยอิงจากขนาดรูปทรงและ DPI ที่กำหนด สามารถลบส่วนที่ถูกตัดเพื่อเพิ่มประสิทธิภาพขนาดไฟล์  
หากภาพเป็นเมต้าไฟล์ (WMF/EMF) หรือ SVG การบีบอัดจะไม่ถูกนำมาใช้ นอกจากนี้คุณภาพ JPEG จะคงไว้หรือถูกลดลงเล็กน้อยตามความละเอียด คล้ายกับการจัดการภาพ JPEG ความละเอียดสูงของ PowerPoint  
{{% /alert %}}

## **ล็อคอัตราส่วนภาพ**

หากต้องการให้รูปทรงที่บรรจุภาพรักษาอัตราส่วนภาพแม้จะเปลี่ยนขนาดภาพแล้ว คุณสามารถใช้เมธอด [setAspectRatioLocked](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) เพื่อกำหนดการตั้งค่า *Lock Aspect Ratio*  

โค้ด Java นี้แสดงวิธีล็อคอัตราส่วนของรูปทรง:

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

    // ตั้งค่าให้รูปทรงรักษาอัตราส่วนเมื่อปรับขนาด
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
การตั้งค่า *Lock Aspect Ratio* นี้จะรักษาอัตราส่วนของรูปทรงเท่านั้น ไม่ได้รักษาภาพที่อยู่ภายในรูปทรง  
{{% /alert %}}

## **ใช้คุณสมบัติ StretchOff**

โดยใช้คุณสมบัติ [StretchOffsetLeft](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) และ [StretchOffsetBottom](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) จากอินเทอร์เฟซ [IPictureFillFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPictureFillFormat) และคลาส [PictureFillFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPictureFillFormat) คุณสามารถระบุสี่เหล็บเติม  

เมื่อกำหนดการยืดสำหรับภาพ สี่เหล็บต้นฉบับจะถูกปรับขนาดให้พอดีกับสี่เหล็บเติมที่ระบุ แต่ละด้านของสี่เหล็บเติมถูกกำหนดโดยออฟเซ็ตเปอร์เซ็นต์จากด้านที่สอดคล้องของกล่องขอบรูปทรง ค่าบวกหมายถึงการซ่อนภายใน ส่วนค่าลบหมายถึงการขยายออก  

1. สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)  
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน  
3. เพิ่มสี่เหล็บ `AutoShape`  
4. สร้างภาพ  
5. ตั้งค่าแบบเติมของรูปทรง  
6. ตั้งค่าโหมดเติมภาพของรูปทรง  
7. เพิ่มภาพที่ตั้งค่าเพื่อเติมรูปทรง  
8. ระบุออฟเซ็ตของภาพจากด้านที่สอดคล้องของกล่องขอบรูปทรง  
9. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

โค้ด Java นี้แสดงกระบวนการที่ใช้คุณสมบัติ StretchOff:

```java
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

    // ตั้งค่าประเภทการเติมของรูปทรง
    aShape.getFillFormat().setFillType(FillType.Picture);

    // ตั้งค่าโหมดการเติมรูปภาพของรูปทรง
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // ตั้งค่าภาพเพื่อเติมรูปทรง
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // ระบุตำแหน่งออฟเซ็ตของภาพจากขอบที่สอดคล้องของกล่องขอบรูปทรง
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    
    // เขียนไฟล์ PPTX ไปยังดิสก์
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **คำถามที่พบบ่อย**

**How can I find out which image formats are supported for PictureFrame?**  
Aspose.Slides รองรับทั้งภาพเรสเตอร์ (PNG, JPEG, BMP, GIF, ฯลฯ) และภาพเวกเตอร์ (เช่น SVG) ผ่านอ็อบเจ็กต์ภาพที่กำหนดให้กับ [PictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pictureframe/) รายการฟอร์แมตที่สนับสนุนมักจะสอดคล้องกับความสามารถของเอนจินการแปลงสไลด์และภาพ  

**How will adding dozens of large images affect PPTX size and performance?**  
การฝังภาพขนาดใหญ่จะทำให้ไฟล์และการใช้หน่วยความจำเพิ่มขึ้น; การลิงก์ภาพช่วยลดขนาดงานนำเสนอแต่ต้องให้ไฟล์ภายนอกยังคงเข้าถึงได้ Aspose.Slides มีความสามารถในการเพิ่มภาพโดยลิงก์เพื่อช่วยลดขนาดไฟล์  

**How can I lock an image object from accidental moving/resizing?**  
ใช้ [shape locks](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pictureframe/#getPictureFrameLock--) กับ [PictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pictureframe/) (เช่น ปิดการย้ายหรือการปรับขนาด) กลไกการล็อคนี้รองรับรูปทรงหลายประเภทรวมถึง [PictureFrame] ด้วย  

**Is SVG vector fidelity preserved when exporting a presentation to PDF/images?**  
Aspose.Slides สามารถดึง SVG จาก [PictureFrame] เป็นเวกเตอร์ต้นฉบับได้ เมื่อ [exporting to PDF](/slides/th/androidjava/convert-powerpoint-to-pdf/) หรือ [raster formats](/slides/th/androidjava/convert-powerpoint-to-png/) ผลลัพธ์อาจถูกแรสเตอร์ขึ้นอยู่กับการตั้งค่าการส่งออก; การที่ SVG ดั้งเดิมยังคงเป็นเวกเตอร์จะได้รับการยืนยันจากพฤติกรรมการดึงออก  