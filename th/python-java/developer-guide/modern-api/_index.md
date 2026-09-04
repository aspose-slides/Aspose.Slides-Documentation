---
title: เพิ่มประสิทธิภาพการประมวลผลภาพด้วย API สมัยใหม่ใน Python
linktitle: API สมัยใหม่
type: docs
weight: 237
url: /th/python-java/modern-api/
keywords:
- API สมัยใหม่
- การวาด
- ภาพย่อสไลด์
- สไลด์เป็นภาพ
- ภาพย่อรูปร่าง
- รูปร่างเป็นภาพ
- ภาพย่อพรีเซนเทชัน
- พรีเซนเทชันเป็นภาพ
- เพิ่มภาพ
- เพิ่มรูปภาพ
- Python
- Java
- Aspose.Slides
description: "ทำให้การประมวลผลภาพใน Python ผ่าน Java เป็นสมัยใหม่: เรนเดอร์สไลด์และรูปร่าง, เพิ่มรูปภาพ, และย้ายการเรียกที่เลิกใช้ของการทำภาพไปยัง Aspose.Slides Modern API."
---
## **บทนำ**

Aspose.Slides for Python via Java เข้าถึงไลบรารี Java ผ่าน JPype. API การประมวลผลภาพรุ่นเก่าของมันใช้ [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) และ [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) จาก `java.awt`.

ไลบรารี Java ได้ทำให้ API การประมวลผลภาพเหล่านี้เลิกใช้ตั้งแต่เวอร์ชัน 24.4. Modern API ใช้ [IImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/iimage/) เพื่อโหลด เรนเดอร์ และบันทึกภาพ. ใช้สำหรับโค้ด Python ใหม่และเมื่อต้องย้ายกระบวนการประมวลผลภาพที่มีอยู่.

{{% alert color="info" title="Note" %}}

ชื่อเมธอดเก่าด้านล่างเป็นการอ้างอิงการย้าย. พวกมันไม่มีในรุ่นปัจจุบันแล้ว. ตัวอย่างที่ทำงานได้ใช้ Modern API.

การเปลี่ยนแปลงนี้ไม่ได้ลบประเภท `java.awt` ทั้งหมด: ตัวโอเวอร์โหลดที่รับขนาดภาพและสีลวดลายยังคงรับ [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) และ [Color](https://docs.oracle.com/javase/8/docs/api/java/awt/Color.html).

{{% /alert %}}

## **Modern API**

ประเภทการประมวลผลภาพหลักมีดังนี้:

- [IImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/iimage/) — แทนภาพราสเตอร์หรือเวกเตอร์.
- [ImageFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/imageformat/) — ให้ค่าคงที่ของรูปแบบไฟล์ภาพ.
- [Images](https://reference.aspose.com/slides/th/python-java/aspose.slides/images/) — สร้างภาพ, ตัวอย่างเช่นด้วย [Images.fromFile](https://reference.aspose.com/slides/th/python-java/aspose.slides/images/#fromFile).

ใช้ [Slide.getImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/slide/#getImage) หรือ [Shape.getImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getImage) เพื่อเรนเดอร์สไลด์หรือรูปร่างหนึ่งรายการ. ใช้ [Presentation.getImages](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getImages) พร้อมตัวเลือกการเรนเดอร์เพื่อเรนเดอร์หลายสไลด์. ตัวโอเวอร์โหลดที่ไม่มีอาร์กิวเมนต์จะคืนคอลเลกชันภาพของพรีเซนเทชันแทน.

โหลดภาพด้วย [Images.fromFile](https://reference.aspose.com/slides/th/python-java/aspose.slides/images/#fromFile), เพิ่มภาพด้วย [ImageCollection.addImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/imagecollection/#addImage), หรืออัปเดตภาพพรีเซนเทชันที่มีอยู่ด้วย [PPImage.replaceImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/ppimage/#replaceImage). การดำเนินการทั้งสองในคอลเลกชันภาพรับ [IImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/iimage/).

ปล่อยแต่ละภาพที่คุณโหลดหรือเรนเดอร์โดยเรียกเมธอด `dispose` ของมันในบล็อก `finally`. ปล่อยพรีเซนเทชันด้วย [Presentation.dispose](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#dispose).

### **เตรียมสภาพแวดล้อม Python**

ติดตั้งแพ็กเกจตามที่อธิบายใน [Installation](/slides/th/python-java/installation/). ตัวอย่างแต่ละตัวนำเข้า `asposeslides` ก่อนเริ่ม JVM, จากนั้นนำเข้า API หลังจากที่ JVM ทำงานแล้ว. ตัวอย่างเหล่านี้ปล่อยให้ JVM ทำงานต่อเพื่อให้สามารถใช้ซ้ำได้. ดู [Limitations and API Differences](/slides/th/python-java/limitations-and-api-differences/#import-the-library) สำหรับคำแนะนำเกี่ยวกับอายุการใช้งานของโน๊ตบุ๊กและ JVM.

ตัวอย่างที่เปิด `pres.pptx` ต้องการพรีเซนเทชันในไดเรกทอรีทำงาน. ตัวอย่างที่โหลด `image.png` ต้องการไฟล์ภาพที่มีอยู่แล้ว.

### **โหลดรูปภาพและเรนเดอร์สไลด์**

ตัวอย่างนี้เพิ่มรูปภาพไปยังสไลด์แรกและบันทึกสไลด์เป็นไฟล์ภาพ JPEG. [IImage.save](https://reference.aspose.com/slides/th/python-java/aspose.slides/iimage/#save) จะเขียนภาพที่เรนเดอร์ออกในรูปแบบที่ระบุ.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Images, Presentation, ShapeType
from java.awt import Dimension

presentation = Presentation()
try:
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)

    image_size = Dimension(1920, 1080)
    slide_image = slide.getImage(image_size)
    try:
        slide_image.save("slide1.jpeg", ImageFormat.Jpeg)
    finally:
        slide_image.dispose()
finally:
    presentation.dispose()
```

## **การแทนที่โค้ดเก่าด้วย Modern API**

แทนที่การเรียก thumbnail รุ่นเก่าด้วยเมธอดที่คืนค่า [IImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/iimage/), จากนั้นบันทึกผลลัพธ์ด้วย [IImage.save](https://reference.aspose.com/slides/th/python-java/aspose.slides/iimage/#save). วิธีนี้จะไม่ต้องส่งภาพที่เรนเดอร์ให้กับ [ImageIO.write](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html#write-java.awt.image.RenderedImage-java.lang.String-java.io.File-).

### **เรนเดอร์สไลด์ที่มีขนาดที่ระบุ**

แทนที่การเรียก `slide.getThumbnail(image_size)` รุ่นเก่าด้วย [Slide.getImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/slide/#getImage) โดยใช้ขนาดภาพเดียวกัน.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        image_size = Dimension(1920, 1080)
        slide_image = presentation.getSlides().get_Item(0).getImage(image_size)
        try:
            slide_image.save("image.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **รับ Thumbnail ของสไลด์**

แทนที่การเรียก `slide.getThumbnail()` รุ่นเก่าด้วย [Slide.getImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/slide/#getImage) โดยไม่มีอาร์กิวเมนต์.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        slide_image = presentation.getSlides().get_Item(0).getImage()
        try:
            slide_image.save("slide1.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **รับ Thumbnail ของรูปร่าง**

แทนที่การเรียก `shape.getThumbnail()` รุ่นเก่าด้วย [Shape.getImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getImage). ตรวจสอบว่าสไลด์มีรูปร่างก่อนเข้าถึง.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        slide = presentation.getSlides().get_Item(0)
        if slide.getShapes().size() > 0:
            shape_image = slide.getShapes().get_Item(0).getImage()
            try:
                shape_image.save("shape.png", ImageFormat.Png)
            finally:
                shape_image.dispose()
        else:
            print("The first slide contains no shapes.")
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **รับ Thumbnail ของพรีเซนเทชัน**

แทนที่การเรียก `presentation.getThumbnails(options, image_size)` รุ่นเก่าด้วย [Presentation.getImages](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getImages). ใช้ [RenderingOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/renderingoptions/) เพื่อกำหนดค่าการเรนเดอร์.

วนลูปผ่านอาเรย์ที่คืนโดยตรงด้วย `enumerate` ของ Python. ทำ `dispose` กับภาพที่คืนทุกภาพในบล็อก `finally` เพื่อให้การบันทึกล้มเหลวไม่ทำให้ภาพที่เหลือค้างอยู่โดยไม่ได้ปล่อย.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, RenderingOptions
from java.awt import Dimension

presentation = Presentation("pres.pptx")
try:
    rendering_options = RenderingOptions()
    image_size = Dimension(1920, 1080)
    images = presentation.getImages(rendering_options, image_size)
    try:
        for index, image in enumerate(images, start=1):
            image.save(f"slide{index}.png", ImageFormat.Png)
    finally:
        for image in images:
            image.dispose()
finally:
    presentation.dispose()
```

### **เพิ่มรูปภาพลงพรีเซนเทชัน**

แทนที่การโหลดผ่าน [ImageIO.read](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html#read-java.io.File-) ด้วย [Images.fromFile](https://reference.aspose.com/slides/th/python-java/aspose.slides/images/#fromFile), จากนั้นส่งภาพที่ได้ให้กับ [ImageCollection.addImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/imagecollection/#addImage). เพิ่มรูปภาพลงสไลด์และบันทึกพรีเซนเทชัน.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)
    presentation.save("picture.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **เมธอดที่เลิกใช้และการแทนที่ใน Modern API**

ตารางใช้รูปแบบการเรียกของ Python. ชื่อในคอลัมน์ Legacy ระบุ API ที่ถูกลบ; ใช้เมธอดการแทนที่ที่เชื่อมโยง. เมธอดการเรนเดอร์ภาพสมัยใหม่จะคืนอ็อบเจกต์ [IImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/iimage/) แทนภาพบัฟเฟอร์ของ Java.

### **Presentation**

[Presentation.getImages](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getImages) จะคืนอาเรย์ของภาพที่เรนเดอร์เมื่อเรียกพร้อมตัวเลือกการเรนเดอร์.

| การเรียกแบบเก่า | การแทนที่แบบใหม่ |
| --- | --- |
| `presentation.getThumbnails(options)` | [getImages](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getImages) กับ `options` |
| `presentation.getThumbnails(options, scale_x, scale_y)` | [getImages](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getImages) กับ `options, scale_x, scale_y` |
| `presentation.getThumbnails(options, slides)` | [getImages](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getImages) กับ `options, slides` |
| `presentation.getThumbnails(options, slides, scale_x, scale_y)` | [getImages](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getImages) กับ `options, slides, scale_x, scale_y` |
| `presentation.getThumbnails(options, slides, image_size)` | [getImages](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getImages) กับ `options, slides, image_size` |
| `presentation.getThumbnails(options, image_size)` | [getImages](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getImages) กับ `options, image_size` |

ที่นี้, `slides` คือ `int[]` ของ Java ที่ระบุหมายเลขสไลด์เริ่มจาก 1; สร้างด้วย `jpype.JArray(jpype.JInt)([1, 3])` เพื่อเลือกสไลด์ที่ 1 และ 3. `image_size` คือ [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html).

### **Shape**

| การเรียกแบบเก่า | การแทนที่แบบใหม่ |
| --- | --- |
| `shape.getThumbnail()` | [getImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getImage) ไม่มีอาร์กิวเมนต์ |
| `shape.getThumbnail(bounds, scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getImage) กับ `bounds, scale_x, scale_y` |

### **Slide**

| การเรียกแบบเก่า | การแทนที่แบบใหม่ |
| --- | --- |
| `slide.getThumbnail()` | [getImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/slide/#getImage) ไม่มีอาร์กิวเมนต์ |
| `slide.getThumbnail(scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/slide/#getImage) กับ `scale_x, scale_y` |
| `slide.getThumbnail(options)` | [getImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/slide/#getImage) กับ `options` |
| `slide.getThumbnail(options, scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/slide/#getImage) กับ `options, scale_x, scale_y` |
| `slide.getThumbnail(options, image_size)` | [getImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/slide/#getImage) กับ `options, image_size` |
| `slide.getThumbnail(tiff_options)` | [getImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/slide/#getImage) กับ `tiff_options` |
| `slide.getThumbnail(image_size)` | [getImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/slide/#getImage) กับ `image_size` |
| `slide.renderToGraphics(options, graphics)` | ไม่มีการแทนที่โดยตรง; ให้เรนเดอร์เป็นภาพแทน |
| `slide.renderToGraphics(options, graphics, scale_x, scale_y)` | ไม่มีการแทนที่โดยตรง; ให้เรนเดอร์เป็นภาพแทน |
| `slide.renderToGraphics(options, graphics, image_size)` | ไม่มีการแทนที่โดยตรง; ให้เรนเดอร์เป็นภาพแทน |

ที่นี้, `options` คือ [RenderingOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/renderingoptions/), และ `tiff_options` คือ [TiffOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/tiffoptions/).

### **Output**

| การเรียกแบบเก่า | การแทนที่แบบใหม่ |
| --- | --- |
| `output.add(path, buffered_image)` | [Output.add](https://reference.aspose.com/slides/th/python-java/aspose.slides/output/#add) กับ `path, image` โดยที่ `image` คือ [IImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/iimage/) |

### **ImageCollection**

| การเรียกแบบเก่า | การแทนที่แบบใหม่ |
| --- | --- |
| `collection.addImage(buffered_image)` | [ImageCollection.addImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/imagecollection/#addImage) กับ [IImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/iimage/) |

### **PPImage**

| การเรียกแบบเก่า | การแทนที่แบบใหม่ |
| --- | --- |
| `picture.getSystemImage()` | [PPImage.getImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/ppimage/#getImage) |

เพื่อแทนที่เนื้อหาของภาพพรีเซนเทชันที่มีอยู่, ใช้ [PPImage.replaceImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/ppimage/#replaceImage) กับ [IImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/iimage/).

### **PatternFormat**

| การเรียกแบบเก่า | การแทนที่แบบใหม่ |
| --- | --- |
| `pattern.getTileImage(style_color)` | [PatternFormat.getTile](https://reference.aspose.com/slides/th/python-java/aspose.slides/patternformat/#getTile) กับ `style_color` |
| `pattern.getTileImage(background, foreground)` | [PatternFormat.getTile](https://reference.aspose.com/slides/th/python-java/aspose.slides/patternformat/#getTile) กับ `background, foreground` |

อากิวเมนต์สียังคงเป็นอ็อบเจกต์ Java [Color](https://docs.oracle.com/javase/8/docs/api/java/awt/Color.html).

### **PatternFormatEffectiveData**

สำหรับข้อมูลลวดลายที่มีประสิทธิภาพที่คืนโดย API Java ผ่าน JPype, เมธอดการแทนที่จะยังคงชื่อ `getTileIImage`.

| การเรียกแบบเก่า | การแทนที่แบบใหม่ |
| --- | --- |
| `effective_pattern.getTileImage(background, foreground)` | `effective_pattern.getTileIImage(background, foreground)`, คืนค่า [IImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/iimage/) |

## **การสนับสนุน Graphics2D ใน API**

โอเวอร์โหลด `renderToGraphics` รุ่นเก่าเคยวาดลงในคอนเท็กซ์ [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) ที่ผู้เรียกจัดหา. Modern API ไม่มีการแทนที่โดยตรงที่วาดลงในคอนเท็กซ์นั้น.

ใช้ [Slide.getImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/slide/#getImage) เพื่อเรนเดอร์สไลด์หรือ [Presentation.getImages](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getImages) เพื่อเรนเดอร์หลายสไลด์, แล้วบันทึกภาพที่คืนด้วย [IImage.save](https://reference.aspose.com/slides/th/python-java/aspose.slides/iimage/#save). แอปพลิเคชันที่ผสานการเรนเดอร์สไลด์กับการวาด Java ที่กำหนดเองต้องปรับขั้นตอนการผสานภาพของตนเอง.

## **FAQ**

**ทำไม API การประมวลผลภาพ Java รุ่นเก่าถึงถูกแทนที่?**

Modern API ย้ายการโหลด, เรนเดอร์, และบันทึกภาพไปยัง [IImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/iimage/). วิธีนี้ให้กระบวนการทำงานมีการนามธรรมภาพร่วมกันแทนการเปิดเผยภาพบัฟเฟอร์ของ Java หรือคอนเท็กซ์กราฟิกของ Java.

**ฉันยังต้องใช้ Java และ JPype หรือไม่?**

ต้อง. Aspose.Slides for Python via Java ยังทำงานบน JVM. Modern API เปลี่ยนแปลงการเรียกการประมวลผลภาพเท่านั้น, ไม่ได้เปลี่ยนความต้องการด้าน runtime. ดู [System Requirements](/slides/th/python-java/system-requirements/).

**ฉันจะปล่อยภาพใน Python อย่างไร?**

เรียก `dispose` กับแต่ละภาพที่คุณโหลดหรือเรนเดอร์ในบล็อก `finally`. หากคุณเรนเดอร์หลายสไลด์, ให้ปล่อยทุกภาพในอาเรย์ที่คืน. ปล่อยพรีเซนเทชันแยกต่างหากด้วย [Presentation.dispose](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#dispose).

**การเปลี่ยนไปใช้ Modern API จะรับประกันการสร้าง thumbnail ที่เร็วขึ้นหรือไม่?**

ไม่มีการรับประกันว่าประสิทธิภาพจะเพิ่มขึ้น. การแทนที่ให้การสนับสนุนตัวเลือกการเรนเดอร์, การสเกล, และขนาดภาพ; คุณควรวัดประสิทธิภาพด้วยพรีเซนเทชันและการตั้งค่าการส่งออกของคุณเอง.

**ทำไมเมธอดการดึงภาพบางครั้งถึงคืนคอลเลกชัน?**

[Presentation.getImages](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getImages) ที่ไม่มีอาร์กิวเมนต์จะคืนภาพที่ฝังอยู่ในพรีเซนเทชัน. ตัวโอเวอร์โหลดที่มีตัวเลือกการเรนเดอร์จะคืนภาพสไลด์ที่เรนเดอร์.