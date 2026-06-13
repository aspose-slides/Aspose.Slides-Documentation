---
title: เพิ่มการประมวลผลภาพด้วย Modern API
linktitle: API สมัยใหม่
type: docs
weight: 237
url: /th/nodejs-java/modern-api/
keywords:
- API สมัยใหม่
- การวาด
- ภาพย่อสไลด์
- สไลด์เป็นภาพ
- ภาพย่อรูปร่าง
- รูปร่างเป็นภาพ
- ภาพย่อการนำเสนอ
- การนำเสนอเป็นภาพ
- เพิ่มภาพ
- เพิ่มรูปภาพ
- Node.js
- JavaScript
- Aspose.Slides
description: "ทำให้การประมวลผลภาพสไลด์ทันสมัยโดยการแทนที่ API การจัดการภาพที่เลิกใช้ด้วย JavaScript Modern API เพื่อการอัตโนมัติ PowerPoint และ OpenDocument อย่างราบรื่น."
---
## **บทนำ**

โดยประวัติศาสตร์ Aspose Slides มีการพึ่งพา java.awt และมีใน API สาธารณะคลาสต่อไปนี้จากนั้น:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

ตั้งแต่เวอร์ชัน 24.4 API สาธารณะนี้ได้ถูกประกาศว่าเลิกใช้แล้ว

เพื่อกำจัดการพึ่งพาเหล่านี้ เราได้เพิ่ม “Modern API” ที่ควรใช้แทน API ที่เลิกใช้ซึ่งลายเซ็นของมันยังคงพึ่งพา [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) ส่วน [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) ถูกประกาศว่าเลิกใช้และการสนับสนุนถูกลบออกจาก API สาธารณะของ Slides

ในเวอร์ชันปัจจุบันให้ถือว่า API สาธารณะที่พึ่งพา java.awt เป็นแบบ legacy/เลิกใช้ ใช้ Modern API สำหรับโค้ดใหม่และเมื่อต้องย้าย workflow การประมวลผลภาพที่มีอยู่

## **API สมัยใหม่**

เพิ่มคลาสและ enum ต่อไปนี้ลงใน API สาธารณะ:

- [IImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/iimage/) – แทนภาพแบบ raster หรือ vector
- [ImageFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/imageformat/) – แทนรูปแบบไฟล์ของภาพ
- [Images](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/images/) – วิธีการสร้างและทำงานกับคลาส [IImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/iimage/)

โปรดทราบว่า [IImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/iimage/) เป็นวัตถุที่ต้องทำลายและการใช้ควรตามด้วยการเรียก `dispose()` หรือรูปแบบการทำลายที่สะดวกอื่น

ใช้ `getImage` เพื่อเรนเดอร์สไลด์หรือรูปร่างเดียว ใช้ `getImages` เพื่อเรนเดอร์หลายสไลด์ ใช้เมธอดของ [Images](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/images/) ในการโหลดภาพ, `addImage` พร้อม [IImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/iimage/) เพื่อเพิ่มเข้าสู่งานนำเสนอ, และ `replaceImage` พร้อม [IImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/iimage/) เพื่ออัปเดตภาพที่มีอยู่ในงานนำเสนอ

สถานการณ์ทั่วไปของการใช้ API ใหม่อาจมีลักษณะดังนี้:

``` javascript
var pres = new aspose.slides.Presentation();
try {
    var ppImage;
    // สร้างอินสแตนซ์ IImage ที่สามารถทำลายได้จากไฟล์บนดิสก์.
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        // สร้างภาพ PowerPoint โดยเพิ่มอินสแตนซ์ของ IImage เข้าไปในคอลเลกชันภาพของงานนำเสนอ.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // เพิ่มรูปร่างรูปภาพบนสไลด์ที่ 1
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
    // รับอินสแตนซ์ของ IImage ที่เป็นตัวแทนของสไลด์ที่ 1.
    var slideImage = pres.getSlides().get_Item(0).getImage(size);
    try {
        // บันทึกภาพลงบนดิสก์.
        slideImage.save("slide1.jpeg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **การแทนที่โค้ดเก่าด้วย Modern API**

โดยทั่วไปคุณจะต้องแทนที่การเรียกที่ใช้ [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) และ [ImageIO](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html) ด้วยเมธอดใหม่ที่ใช้ [IImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/iimage/)

API legacy/เลิกใช้:
``` javascript
var imageio = java.import("javax.imageio.ImageIO");
var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
var slideImage = pres.getSlides().get_Item(0).getThumbnail(size);
var file = java.newInstanceSync("java.io.File", "image.png");
imageio.write(slideImage, "PNG", file);
```
Modern API:
``` javascript
var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
var slideImage = pres.getSlides().get_Item(0).getImage(size);
slideImage.save("image.png", aspose.slides.ImageFormat.Png);
slideImage.dispose();
```

### **การรับ Thumbnail ของสไลด์**

Legacy/เลิกใช้ API:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var slideImage = pres.getSlides().get_Item(0).getThumbnail();
    var imageio = java.import("javax.imageio.ImageIO");
    var file = java.newInstanceSync("java.io.File", "slide1.png");
    imageio.write(slideImage, "PNG", file);
} finally {
    if (pres != null) pres.dispose();
}
```

Modern API:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var slideImage = pres.getSlides().get_Item(0).getImage();
    slideImage.save("slide1.png", aspose.slides.ImageFormat.Png);
    slideImage.dispose();
} finally {
    if (pres != null) pres.dispose();
}
```

### **การรับ Thumbnail ของรูปร่าง**

Legacy/เลิกใช้ API:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail();
    var imageio = java.import("javax.imageio.ImageIO");
    var file = java.newInstanceSync("java.io.File", "shape.png");
    imageio.write(shapeImage, "PNG", file);
} finally {
    if (pres != null) pres.dispose();
}
```

Modern API:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    shapeImage.save("shape.png");
    shapeImage.dispose();
} finally {
    if (pres != null) pres.dispose();
}
```

### **การรับ Thumbnail ของงานนำเสนอ**

Legacy/เลิกใช้ API:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var size = java.newInstanceSync("java.awt.Dimension", 1980, 1028);
    var bitmaps = pres.getThumbnails(new aspose.slides.RenderingOptions(), size);
    for (var index = 0; index < bitmaps.length; index++)
    {
        var thumbnail = bitmaps[index];
        var imageio = java.import("javax.imageio.ImageIO");
        var file = java.newInstanceSync("java.io.File", "slide" + index + ".png");
        imageio.write(thumbnail, "PNG", file);
    }
} finally {
    if (pres != null) pres.dispose();
}
```

Modern API:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var size = java.newInstanceSync("java.awt.Dimension", 1980, 1028);
    var images = pres.getImages(new aspose.slides.RenderingOptions(), size);
    try
    {
        for (var index = 0; index < images.length; index++)
        {
            var thumbnail = images[index];
            thumbnail.save("slide" + index + ".png", aspose.slides.ImageFormat.Png);
        }
    }
    finally
    {
        images.forEach(item => {item.dispose();});
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **การเพิ่มรูปภาพลงในงานนำเสนอ**

Legacy/เลิกใช้ API:

``` javascript
var pres = new aspose.slides.Presentation();
try {
    var imageio = java.import("javax.imageio.ImageIO");
    var file = java.newInstanceSync("java.io.File", "image.png");
    var bufferedImages = imageio.read(file);
    var ppImage = pres.getImages().addImage(bufferedImages);

    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
} finally {
    if (pres != null) pres.dispose();
}
```

Modern API:

``` javascript
var pres = new aspose.slides.Presentation();
try {
    var image = aspose.slides.Images.fromFile("image.png");
    var ppImage = pres.getImages().addImage(image);
    image.dispose();

    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
} finally {
    if (pres != null) pres.dispose();
}
```

## **เมธอดที่เลิกใช้และการแทนที่ใน Modern API**

### **Presentation**
| ลายเซ็นเมธอด | ลายเซ็นเมธอดที่แทน |
|---|---|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Shape**
| ลายเซ็นเมธอด | ลายเซ็นเมธอดที่แทน |
|---|---|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| ลายเซ็นเมธอด | ลายเซ็นเมธอดที่แทน |
|---|---|
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
| ลายเซ็นเมธอด | ลายเซ็นเมธอดที่แทน |
|---|---|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| ลายเซ็นเมธอด | ลายเซ็นเมธอดที่แทน |
|---|---|
| public final PPImage addImage(BufferedImage image) | public final PPImage addImage(IImage image) |

### **PPImage**
| ลายเซ็นเมธอด | ลายเซ็นเมธอดที่แทน |
|---|---|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| ลายเซ็นเมธอด | ลายเซ็นเมธอดที่แทน |
|---|---|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| ลายเซ็นเมธอด | ลายเซ็นเมธอดที่แทน |
|---|---|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **การสนับสนุน API สำหรับ Graphics2D**

เมธอดที่ใช้ [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) ถูกประกาศว่าเลิกใช้และไม่มีการแทนที่โดย Modern API โดยตรง

ใช้เมธอดเรนเดอร์ภาพของ Modern API แทน API ที่เรนเดอร์ไปยัง [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html):

[Slide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

# **FAQ**

**IImage มีประโยชน์เชิงปฏิบัติอย่างไรเมื่อเทียบกับ BufferedImage?**

[IImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/iimage/) รวมการทำงานกับภาพ raster และ vector ไว้ในหนึ่งเดียวและทำให้การบันทึกเป็นรูปแบบต่าง ๆ ผ่าน [ImageFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/imageformat/) ง่ายขึ้น

**Modern API จะส่งผลต่อประสิทธิภาพของการสร้าง thumbnail หรือไม่?**

การสลับจาก `getThumbnail` เป็น `getImage` ไม่ทำให้สถานการณ์แย่ลง: เมธอดใหม่มีความสามารถเท่าเดิมในการผลิตภาพด้วยตัวเลือกและขนาดต่าง ๆ พร้อมคงการสนับสนุนตัวเลือกการเรนเดอร์ การได้เปรียบหรือเสียเปรียบเฉพาะขึ้นอยู่กับสถานการณ์ แต่ในเชิงฟังก์ชันการแทนที่นั้นเทียบเท่ากัน