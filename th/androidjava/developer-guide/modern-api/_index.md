---
title: ปรับปรุงการประมวลผลภาพด้วย Modern API
linktitle: API สมัยใหม่
type: docs
weight: 237
url: /th/androidjava/modern-api/
keywords:
- android.graphics
- API สมัยใหม่
- การวาด
- ภาพย่อสไลด์
- สไลด์เป็นภาพ
- ภาพย่อรูปทรง
- รูปทรงเป็นภาพ
- ภาพย่อการนำเสนอ
- การนำเสนอเป็นภาพ
- เพิ่มภาพ
- เพิ่มรูปภาพ
- Android
- Java
- Aspose.Slides
description: "ทำให้การประมวลผลภาพของสไลด์ทันสมัยโดยแทนที่ API การสร้างภาพที่เลิกใช้ด้วย Java Modern API เพื่อการทำงานอัตโนมัติของ PowerPoint และ OpenDocument อย่างไร้รอยต่อ."
---
## **บทนำ**

โดยประวัติการทำงาน, Aspose Slides มีการพึ่งพา android.graphics และมีคลาสต่อไปนี้ใน API สาธารณะจากนั้น:
- [Canvas](https://developer.android.com/reference/android/graphics/Canvas)
- [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap)

ตั้งแต่เวอร์ชัน 24.4, API สาธารณะนี้ถูกประกาศให้เลิกใช้

เพื่อกำจัดการพึ่งพาเหล่านี้, เราได้เพิ่มสิ่งที่เรียกว่า “Modern API” – คือ API ที่ควรใช้แทนที่ที่เลิกใช้, ซึ่งลายเซ็นของมันมีการพึ่งพา [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap). [Canvas](https://developer.android.com/reference/android/graphics/Canvas) ถูกประกาศให้เลิกใช้และการสนับสนุนของมันถูกลบออกจาก API สาธารณะของ Slides

ในเวอร์ชันปัจจุบัน, ให้ถือว่า API สาธารณะที่ขึ้นอยู่กับประเภท android.graphics เป็น API เก่า/เลิกใช้. ใช้ Modern API สำหรับโค้ดใหม่และเมื่อย้ายการทำงานด้านการประมวลผลภาพที่มีอยู่

## **API สมัยใหม่**

เพิ่มคลาสและ enum ต่อไปนี้ไปยัง API สาธารณะ:

- [IImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimage/) – แทนภาพแบบราสเตอร์หรือเวกเตอร์
- [ImageFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imageformat/) – แทนรูปแบบไฟล์ของภาพ
- [Images](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/images/) – วิธีการสร้างและทำงานกับอินเทอร์เฟซ [IImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimage/)

โปรดทราบว่า [IImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimage/) เป็นวัตถุที่ต้องทำลายและการใช้ควรตามด้วยการเรียก `dispose()` หรือรูปแบบการทำลายอื่นที่สะดวก

ใช้ `getImage` เพื่อเรนเดอร์สไลด์หรือรูปร่างเดียว ใช้ `getImages` เพื่อเรนเดอร์หลายสไลด์ของงานนำเสนอ ใช้เมธอดของ [Images](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/images/) เพื่อโหลดภาพ, `addImage` พร้อมกับ [IImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimage/) เพื่อเพิ่มภาพเหล่านั้นลงในงานนำเสนอ, และ `replaceImage` พร้อมกับ [IImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimage/) เพื่ออัปเดตภาพในงานนำเสนอที่มีอยู่

สถานการณ์ทั่วไปของการใช้ API ใหม่อาจมีลักษณะดังต่อไปนี้:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    // สร้างอินสแตนซ์ IImage ที่ต้องทำลายจากไฟล์บนดิสก์
    IImage image = Images.fromFile("image.png");
    try {
        // สร้างภาพ PowerPoint โดยเพิ่มอินสแตนซ์ IImage ไปยังคอลเลกชันภาพของงานนำเสนอ
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // เพิ่มรูปร่างรูปภาพบนสไลด์ที่ 1
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // รับอินสแตนซ์ IImage ที่แสดงสไลด์ที่ 1
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Size(1920, 1080));
    try {
        // บันทึกภาพลงบนดิสก์
        slideImage.save("slide1.jpeg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **การแทนที่โค้ดเก่าด้วย Modern API**

โดยทั่วไป, คุณจะต้องแทนที่การเรียกที่ใช้ [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap) ด้วยเมธอดใหม่ที่ใช้ [IImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimage/)

API เก่า/เลิกใช้:
``` java
Presentation pres = new Presentation();
try {
    Bitmap slideImage = pres.getSlides().get_Item(0).getThumbnail(new Size(1920, 1080));
    FileOutputStream fos = null;
    try {
        fos = new FileOutputStream("image.png");
        slideImage.compress(android.graphics.Bitmap.CompressFormat.PNG, 100, fos);
    } catch (FileNotFoundException e) {
        e.printStackTrace();
    } finally {
        if (fos != null) {
            try {
                fos.close();
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```
Modern API:
``` java
Presentation pres = new Presentation();
try {
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Size(1920, 1080));
    try {
        slideImage.save("image.png", ImageFormat.Png);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **การรับภาพย่อสไลด์**

API เก่า/เลิกใช้:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    Bitmap slideImage = pres.getSlides().get_Item(0).getThumbnail();
    FileOutputStream fos = null;
    try {
        fos = new FileOutputStream("slide1.png");
        slideImage.compress(android.graphics.Bitmap.CompressFormat.PNG, 100, fos);
    } catch (FileNotFoundException e) {
        e.printStackTrace();
    } finally {
        if (fos != null) {
            try {
                fos.close();
            } catch (IOException e) {
                e.printStackTrace();
            }
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

### **การรับภาพย่อรูปร่าง**

API เก่า/เลิกใช้:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    Bitmap shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail();
    FileOutputStream fos = null;
    try {
        fos = new FileOutputStream("shape.png");
        shapeImage.compress(android.graphics.Bitmap.CompressFormat.PNG, 100, fos);
    } catch (FileNotFoundException e) {
        e.printStackTrace();
    } finally {
        if (fos != null) {
            try {
                fos.close();
            } catch (IOException e) {
                e.printStackTrace();
            }
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

### **การรับภาพย่อการนำเสนอ**

API เก่า/เลิกใช้:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    Bitmap[] bitmaps = pres.getThumbnails(new RenderingOptions(), new Size(1980, 1028));
    for (int index = 0; index < bitmaps.length; index++)
    {
        android.graphics.Bitmap thumbnail = bitmaps[index];
        FileOutputStream fos = null;
        try {
            fos = new FileOutputStream("slide" + index + ".png");
            thumbnail.compress(android.graphics.Bitmap.CompressFormat.PNG, 100, fos);
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } finally {
            if (fos != null) {
                try {
                    fos.close();
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
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
    IImage[] images = pres.getImages(new RenderingOptions(), new Size(1980, 1028));
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

### **การเพิ่มรูปภาพลงในงานนำเสนอ**

API เก่า/เลิกใช้:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage = null;
    File file = new File("image.png");
    Bitmap bitmap = BitmapFactory.decodeFile(file.getAbsolutePath());
    ppImage = pres.getImages().addImage(bitmap);

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

## **เมธอดที่เลิกใช้และการแทนที่ใน Modern API**

### **Presentation**
| ลายเซ็นเมธอด | ลายเซ็นเมธอดที่แทนที่ |
|---|---|
| public final Bitmap[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, Size imageSize) | public final IImage[] getImages(IRenderingOptions options, Size imageSize) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Size imageSize) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |

### **Shape**
| ลายเซ็นเมธอด | ลายเซ็นเมธอดที่แทนที่ |
|---|---|
| public final Bitmap getThumbnail() | public final IImage getImage() |
| public final Bitmap getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| ลายเซ็นเมธอด | ลายเซ็นเมธอดที่แทนที่ |
|---|---|
| public final Bitmap getThumbnail() | public final IImage getImage() |
| public final Bitmap getThumbnail(Size imageSize) | public final IImage getImage(Size imageSize) |
| public final Bitmap getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final Bitmap getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final Bitmap getThumbnail(IRenderingOptions options, Size imageSize) | public final IImage getImage(IRenderingOptions options, Size imageSize) |
| public final Bitmap getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options, float scaleX, float scaleY) |
| public final Bitmap getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final void renderToGraphics(IRenderingOptions options, Canvas graphics) | No Modern API replacement |
| public final void renderToGraphics(IRenderingOptions options, Canvas graphics, Size renderingSize) | No Modern API replacement |
| public final void renderToGraphics(IRenderingOptions options, Canvas graphics, float scaleX, float scaleY) | No Modern API replacement |

### **Output**
| ลายเซ็นเมธอด | ลายเซ็นเมธอดที่แทนที่ |
|---|---|
| public final IOutputFile add(String path, Bitmap image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| ลายเซ็นเมธอด | ลายเซ็นเมธอดที่แทนที่ |
|---|---|
| public final IPPImage addImage(Bitmap image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| ลายเซ็นเมธอด | ลายเซ็นเมธอดที่แทนที่ |
|---|---|
| public final Bitmap getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| ลายเซ็นเมธอด | ลายเซ็นเมธอดที่แทนที่ |
|---|---|
| public final Bitmap getTileImage(Integer styleColor) | public final IImage getTile(Integer styleColor) |
| public final Bitmap getTileImage(Integer background, Integer foreground) | public final IImage getTile(Integer background, Integer foreground) |

### **PatternFormatEffectiveData**
| ลายเซ็นเมธอด | ลายเซ็นเมธอดที่แทนที่ |
|---|---|
| public final Bitmap getTileImage(Integer background, Integer foreground) | public final IImage getTileIImage(Integer background, Integer foreground) |

## **การสนับสนุน API สำหรับ Canvas**

เมธอดที่ใช้ [Canvas](https://developer.android.com/reference/android/graphics/Canvas) ถูกประกาศให้เลิกใช้และไม่มีการแทนที่โดยตรงใน Modern API

ใช้เมธอดการเรนเดอร์ภาพของ Modern API แทนการใช้ API ที่เรนเดอร์ไปยัง [Canvas](https://developer.android.com/reference/android/graphics/Canvas):

[Slide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-)
- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics, Size renderingSize)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-com.aspose.slides.android.Size-)

## **คำถามที่พบบ่อย**

**ทำไม android.graphics.Canvas ถึงถูกตัดออก?**

การสนับสนุน [Canvas](https://developer.android.com/reference/android/graphics/Canvas) ถูกเลิกใช้ใน API สาธารณะเพื่อทำให้การทำงานกับการเรนเดอร์และภาพสอดคล้องกัน, เลิกพึ่งพาการขึ้นอยู่กับแพลตฟอร์มเฉพาะ, และสลับไปสู่แนวทางข้ามแพลตฟอร์มด้วย [IImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimage/). ใช้ `getImage` หรือ `getImages` แทนการเรนเดอร์ไปยัง [Canvas](https://developer.android.com/reference/android/graphics/Canvas).

**ประโยชน์เชิงปฏิบัติของ [IImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimage/) เทียบกับ [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap) คืออะไร?**

[IImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimage/) ทำให้การทำงานกับภาพราสเตอร์และเวกเตอร์เป็นหนึ่งเดียวและทำให้การบันทึกเป็นรูปแบบต่าง ๆ ง่ายขึ้นผ่าน [ImageFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imageformat/).

**Modern API จะส่งผลต่อประสิทธิภาพของการสร้างภาพย่อหรือไม่?**

การเปลี่ยนจาก `getThumbnail` ไปเป็น `getImage` ไม่ทำให้สถานการณ์แย่ลง: เมธอดใหม่ให้ความสามารถเดียวกันในการสร้างภาพด้วยตัวเลือกและขนาดต่าง ๆ, พร้อมคงการสนับสนุนตัวเลือกการเรนเดอร์. ผลตอบแทนหรือการสูญเสียขึ้นอยู่กับสถานการณ์, แต่โดยฟังก์ชันเมธอดแทนที่เทียบเท่ากัน.