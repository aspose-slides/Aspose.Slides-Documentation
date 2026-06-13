---
title: เพิ่มประสิทธิภาพการประมวลผลภาพด้วย Modern API
linktitle: API โมเดิร์น
type: docs
weight: 237
url: /th/java/modern-api/
keywords:
- API โมเดิร์น
- การวาด
- ภาพย่อสไลด์
- สไลด์เป็นภาพ
- ภาพย่อรูปร่าง
- รูปร่างเป็นภาพ
- ภาพย่อพรีเซนเทชัน
- พรีเซนเทชันเป็นภาพ
- เพิ่มภาพ
- เพิ่มรูปภาพ
- Java
- Aspose.Slides
description: "ทำให้การประมวลผลภาพสไลด์ทันสมัยโดยการแทนที่ API การทำภาพที่ล้าสมัยด้วย Java Modern API เพื่อการทำงานอัตโนมัติของ PowerPoint และ OpenDocument อย่างราบรื่น."
---
## **บทนำ**

โดยประวัติศาสตร์ Aspose Slides มีการพึ่งพา java.awt และมีใน API สาธารณะคลาสต่อไปนี้จากนั้น:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

ตั้งแต่เวอร์ชัน 24.4 API สาธารณะนี้ถูกประกาศให้เป็นรุ่นล้าสมัยแล้ว

เพื่อกำจัดการพึ่งพาเหล่านี้ เราได้เพิ่ม “Modern API” – คือ API ที่ควรใช้แทน API ที่ล้าสมัย ซึ่งลายเซ็นของมันยังคงอ้างอิงถึง [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) ส่วน [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) ถูกประกาศให้เป็นรุ่นล้าสมัยและการสนับสนุนถูกลบออกจาก API สาธารณะของ Slides

ในเวอร์ชันปัจจุบัน ให้ถือ API สาธารณะที่พึ่งพาชนิดจาก java.awt เป็นรุ่นเก่า/ล้าสมัย ใช้ Modern API สำหรับโค้ดใหม่และเมื่อต้องย้ายงานประมวลผลภาพที่มีอยู่

## **Modern API**

เพิ่มคลาสและ enum ต่อไปนี้ไปยัง API สาธารณะ:

- [IImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimage/) – แทนภาพแบบ raster หรือ vector
- [ImageFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/imageformat/) – แทนรูปแบบไฟล์ของภาพ
- [Images](https://reference.aspose.com/slides/th/java/com.aspose.slides/images/) – วิธีการสร้างและทำงานกับอินเทอร์เฟซ [IImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimage/)

โปรดทราบว่า [IImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimage/) เป็นออบเจกต์ที่ต้องทำลายและควรตามด้วยการเรียก `dispose()` หรือรูปแบบการทำลายที่สะดวกอื่น ๆ

ใช้ `getImage` เพื่อเรนเดอร์สไลด์หรือรูปร่างเดี่ยว ใช้ `getImages` เพื่อเรนเดอร์สไลด์หลายหน้า ใช้วิธีการจาก [Images](https://reference.aspose.com/slides/th/java/com.aspose.slides/images/) เพื่อโหลดภาพ, `addImage` พร้อม [IImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimage/) เพื่อเพิ่มลงในพรีเซนเทชัน, และ `replaceImage` พร้อม [IImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimage/) เพื่ออัปเดตภาพที่มีอยู่ในพรีเซนเทชัน

ตัวอย่างการใช้ API ใหม่อาจมีลักษณะดังนี้:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    // สร้างอินสแตนซ์ IImage ที่สามารถทำลายได้จากไฟล์บนดิสก์.
    IImage image = Images.fromFile("image.png");
    try {
        // สร้างภาพ PowerPoint โดยเพิ่มอินสแตนซ์ของ IImage ลงในคอลเลกชันภาพของพรีเซนเทชัน.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // เพิ่มรูปร่างรูปภาพบนสไลด์ที่ 1
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // รับอินสแตนซ์ของ IImage ที่แสดงสไลด์ที่ 1.
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1920, 1080));
    try {
        // บันทึกภาพลงบนดิสก์.
        slideImage.save("slide1.jpeg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **การแทนที่โค้ดเก่าด้วย Modern API**

โดยทั่วไป คุณจะต้องแทนที่การเรียกที่ใช้ [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) และ ImageIO ด้วยเมธอดใหม่ที่ใช้ [IImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimage/)

API รุ่นเก่า/ล้าสมัย:
``` java
BufferedImage slideImage = pres.getSlides().get_Item(0).getThumbnail(new Dimension(1920, 1080));
try {
    ImageIO.write(slideImage, "PNG", new File("image.png"));
} catch (IOException e) {
    e.printStackTrace();
}
```
Modern API:
``` java
IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1920, 1080));
try {
    slideImage.save("image.png", ImageFormat.Png);
} finally {
    if (slideImage != null) slideImage.dispose();
}
```

### **การดึง Thumbnail ของสไลด์**

API รุ่นเก่า/ล้าสมัย:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    BufferedImage slideImage = pres.getSlides().get_Item(0).getThumbnail();
    try {
        ImageIO.write(slideImage, "PNG", new File("slide1.png"));
    } catch (IOException e) {
        e.printStackTrace();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

Modern API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    IImage slideImage = pres.getSlides().get_Item(0).getImage();
    try {
        slideImage.save("slide1.png", ImageFormat.Png);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **การดึง Thumbnail ของรูปร่าง**

API รุ่นเก่า/ล้าสมัย:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    BufferedImage shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail();
    try {
        ImageIO.write(shapeImage, "PNG", new File("shape.png"));
    } catch (IOException e) {
        e.printStackTrace();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

Modern API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    IImage shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    try {
        shapeImage.save("shape.png");
    } finally {
        if (shapeImage != null) shapeImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **การดึง Thumbnail ของพรีเซนเทชัน**

API รุ่นเก่า/ล้าสมัย:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    BufferedImage[] bitmaps = pres.getThumbnails(new RenderingOptions(), new Dimension(1980, 1028));
    for (int index = 0; index < bitmaps.length; index++)
    {
        try 
        {
            BufferedImage thumbnail = bitmaps[index];
            ImageIO.write(thumbnail, "PNG", new File("slide" + index + ".png"));
        } 
        catch (IOException e) 
        {
            e.printStackTrace();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

Modern API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    IImage[] images = pres.getImages(new RenderingOptions(), new Dimension(1980, 1028));
    try
    {
        for (int index = 0; index < images.length; index++)
        {
            IImage thumbnail = images[index];
            thumbnail.save("slide" + index + ".png", ImageFormat.Png);
        }
    }
    finally
    {
        for (IImage image : images)
        {
            image.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **การเพิ่มรูปภาพลงในพรีเซนเทชัน**

API รุ่นเก่า/ล้าสมัย:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage = null;
    try {
        BufferedImage bufferedImages = ImageIO.read(new File("image.png"));
        ppImage = pres.getImages().addImage(bufferedImages);
    } catch (IOException e) {
        e.printStackTrace();
    }

    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
} finally {
    if (pres != null) pres.dispose();
}
```

Modern API:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    IImage image = Images.fromFile("image.png");
    try {
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
} finally {
    if (pres != null) pres.dispose();
}
```

## **เมธอดที่ล้าสมัยและการแทนที่ใน Modern API**

### **Presentation**
| ลายเซ็นของเมธอด | ลายเซ็นเมธอดทดแทน |
|-------------------|-------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Shape**
| ลายเซ็นของเมธอด | ลายเซ็นเมธอดทดแทน |
|-------------------|-------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| ลายเซ็นของเมธอด | ลายเซ็นเมธอดทดแทน |
|-------------------|-------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final BufferedImage getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, Dimension imageSize) | public final IImage getImage(IRenderingOptions options, Dimension imageSize) |
| public final BufferedImage getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final BufferedImage getThumbnail(Dimension imageSize) | public final IImage getImage(Dimension imageSize) |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics) | No Modern API replacement |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY) | No Modern API replacement |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize) | No Modern API replacement |

### **Output**
| ลายเซ็นของเมธอด | ลายเซ็นเมธอดทดแทน |
|-------------------|-------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| ลายเซ็นของเมธอด | ลายเซ็นเมธอดทดแทน |
|-------------------|-------------------|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| ลายเซ็นของเมธอด | ลายเซ็นเมธอดทดแทน |
|-------------------|-------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| ลายเซ็นของเมธอด | ลายเซ็นเมธอดทดแทน |
|-------------------|-------------------|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| ลายเซ็นของเมธอด | ลายเซ็นเมธอดทดแทน |
|-------------------|-------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **การสนับสนุน API สำหรับ Graphics2D**

เมธอดที่มี [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) ถูกประกาศให้เป็นรุ่นล้าสมัยและไม่มีการแทนที่โดยตรงใน Modern API

ใช้เมธอดเรนเดอร์ภาพของ Modern API แทนการเรนเดอร์ไปยัง [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html):

[Slide](https://reference.aspose.com/slides/th/java/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/th/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/th/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/th/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

## **FAQ**

**ทำไมจึงยกเลิกการใช้ [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)?**

การสนับสนุน [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) ถูกทำให้เป็นรุ่นล้าสมัยใน API สาธารณะเพื่อ統合การทำงานกับการเรนเดอร์และภาพ, กำจัดการเชื่อมโยงกับการพึ่งพาแพลตฟอร์มเฉพาะ, และเปลี่ยนไปใช้แนวทางข้ามแพลตฟอร์มกับ [IImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimage/). ใช้ `getImage` หรือ `getImages` แทนการเรนเดอร์ไปยัง [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html).

**ประโยชน์เชิงปฏิบัติของ [IImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimage/) เปรียบเทียบกับ [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) คืออะไร?**

[IImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimage/) ทำให้การทำงานกับภาพ raster และ vector เป็นหนึ่งเดียวและทำให้การบันทึกเป็นรูปแบบต่าง ๆ ง่ายขึ้นผ่าน [ImageFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/imageformat/).

**Modern API จะส่งผลต่อประสิทธิภาพของการสร้าง thumbnail หรือไม่?**

การสลับจาก `getThumbnail` ไปเป็น `getImage` ไม่ทำให้สถานการณ์แย่ลง: เมธอดใหม่ให้ความสามารถเดียวกันในการสร้างภาพพร้อมตัวเลือกและขนาดต่าง ๆ พร้อมยังคงสนับสนุนตัวเลือกการเรนเดอร์ ผลลัพธ์ที่ดีหรือเสียขึ้นอยู่กับกรณีการใช้งาน แต่ด้านฟังก์ชันการแทนที่นั้นเท่าเทียมกัน.