---
title: เพิ่มประสิทธิภาพการประมวลผลภาพด้วย Modern API
linktitle: Modern API
type: docs
weight: 280
url: /th/python-net/modern-api/
keywords:
- Modern API
- การวาด
- ภาพย่อสไลด์
- สไลด์เป็นภาพ
- ภาพย่อรูปทรง
- รูปทรงเป็นภาพ
- ภาพย่อพรีเซนเทชั่น
- พรีเซนเทชั่นเป็นภาพ
- เพิ่มภาพ
- เพิ่มรูปภาพ
- Python
- Aspose.Slides
description: "ทำให้การประมวลผลภาพสไลด์เป็นทันสมัยโดยการแทนที่ API การสร้างภาพที่ถูกเลิกใช้งานด้วย Python Modern API เพื่อการทำงานอัตโนมัติของ PowerPoint และ OpenDocument อย่างราบรื่น."
---
## **บทนำ**

Aspose.Slides for Python API สาธารณะในขณะนี้ขึ้นอยู่กับประเภท `aspose.pydrawing` ต่อไปนี้:
- `aspose.pydrawing.Graphics`
- `aspose.pydrawing.Image`
- `aspose.pydrawing.Bitmap`
- `aspose.pydrawing.printing.PrinterSettings`

ตั้งแต่เวอร์ชัน 24.4, API สาธารณะนี้ถูก **เลิกใช้งาน** เนื่องจาก [การเปลี่ยนแปลง](https://releases.aspose.com/slides/th/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/#introducing-a-new-modern-api) ใน Aspose.Slides for Python API สาธารณะ

เพื่อขจัด `aspose.pydrawing` ออกจาก API สาธารณะ, เราได้แนะนำ **Modern API** เมธอดที่ใช้ `aspose.pydrawing.Image` และ `aspose.pydrawing.Bitmap` ถูกเลิกใช้งานและควรแทนที่ด้วยเมธอดที่เทียบเท่าใน Modern API เมธอดที่ใช้ `aspose.pydrawing.Graphics` ถูกเลิกใช้งานและไม่มีการแทนที่โดยตรงใน Modern API

ในเวอร์ชันปัจจุบันให้ถือว่า API สาธารณะที่พึ่งพา `aspose.pydrawing` เป็นรุ่นเก่า/เลิกใช้งาน ใช้ Modern API สำหรับโค้ดใหม่และเมื่อย้ายกระบวนการประมวลผลภาพที่มีอยู่

## **API สมัยใหม่**

คลาสและ enum ต่อไปนี้ได้ถูกเพิ่มเข้าไปใน API สาธารณะ:

- [aspose.slides.IImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/iimage/) - แสดงถึงภาพแบบแรสเตอร์หรือเวกเตอร์
- [aspose.slides.ImageFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/imageformat/) - แสดงถึงฟอร์แมตไฟล์ภาพ
- [aspose.slides.Images](https://reference.aspose.com/slides/th/python-net/aspose.slides/images/) - ให้เมธอดสำหรับสร้างและทำงานกับ [IImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/iimage/)

ใช้ `get_image` เพื่อเรนเดอร์สไลด์หรือรูปร่างเดียว ใช้ `get_images` เพื่อเรนเดอร์สไลด์หลายสไลด์ในพรีเซนเทชัน ใช้เมธอดของ [Images](https://reference.aspose.com/slides/th/python-net/aspose.slides/images/) เพื่อโหลดภาพ, `add_image` กับ [IImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/iimage/) เพื่อเพิ่มภาพเข้าไปในพรีเซนเทชัน, และ `replace_image` กับ [IImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/iimage/) เพื่ออัปเดตภาพที่มีอยู่ในพรีเซนเทชัน

ตัวอย่างการใช้ API ใหม่มีลักษณะดังนี้:

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("image.png") as image:
        pp_image = presentation.images.add_image(image)

    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)

    with slide.get_image(drawing.Size(1920, 1080)) as slide_image:
        slide_image.save("slide1.jpeg", slides.ImageFormat.JPEG)
```

## **แทนที่โค้ดเก่าด้วย Modern API**

เพื่อการเปลี่ยนแปลงที่ง่ายกว่า, คลาส [IImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/iimage/) ใหม่จำลอง API แยกต่างหากของคลาส `aspose.pydrawing.Image` และ `aspose.pydrawing.Bitmap` ในหลายกรณีคุณเพียงแค่ต้องแทนที่การเรียกเมธอดที่ใช้ `aspose.pydrawing` ด้วยเมธอดเทียบเท่าใน Modern API

### **รับภาพย่อของสไลด์**

**API ที่เลิกใช้:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.get_thumbnail().save("slide1.png")
```

**Modern API:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image() as image:
        image.save("slide1.png")
```

### **รับภาพย่อของรูปร่าง**

**API ที่เลิกใช้:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    
    shape.get_thumbnail().save("shape.png")
```

**Modern API:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    with shape.get_image() as image:
        image.save("shape.png")
```

### **รับภาพย่อของพรีเซนเทชัน**

**API ที่เลิกใช้:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("sample.pptx") as presentation:
    thumbnails = presentation.get_thumbnails(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for index, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{index}.png", drawing.imaging.ImageFormat.png)
```

**Modern API:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("sample.pptx") as presentation:
    thumbnails = presentation.get_images(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for index, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

### **เพิ่มรูปภาพลงในพรีเซนเทชัน**

**API ที่เลิกใช้:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    image = drawing.Image.from_file("image.png")
    pp_image = presentation.images.add_image(image)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)
```

**Modern API:**

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("image.png") as image:
        pp_image = presentation.images.add_image(image)

    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)
```

## **เมธอดและพร็อพเพอร์ตีที่จะถูกลบและการแทนที่ใน Modern API**

### **คลาส Presentation**

|ลายเซ็นเมธอด|ลายเซ็นเมธอดแทน|
| :- | :- |
|get_thumbnails(options)|[get_images(options)](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions)|
|get_thumbnails(options, slides)|[get_images(options, slides)](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint)|
|get_thumbnails(options, scale_x, scale_y)|[get_images(options, scale_x, scale_y)](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnails(options, slides, scale_x, scale_y)|[get_images(options, slides, scale_x, scale_y)](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-float-float)|
|get_thumbnails(options, image_size)|[get_images(options, image_size)](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|get_thumbnails(options, slides, image_size)|[get_images(options, slides, image_size)](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-asposepydrawingsize)|
|save(fname, format, response, show_inline)|No Modern API replacement|
|save(fname, format, options, response, show_inline)|No Modern API replacement|
|print()|No Modern API replacement|
|print(printer_settings)|No Modern API replacement|
|print(printer_name)|No Modern API replacement|
|print(printer_settings, pres_name)|No Modern API replacement|

### **คลาส Slide**

|ลายเซ็นเมธอด|ลายเซ็นเมธอดแทน|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/th/python-net/aspose.slides/slide/get_image/#)|
|get_thumbnail(scale_x, scale_y)|[get_image(scale_x, scale_y)](https://reference.aspose.com/slides/th/python-net/aspose.slides/slide/get_image/#float-float)|
|get_thumbnail(image_size)|[get_image(image_size)](https://reference.aspose.com/slides/th/python-net/aspose.slides/slide/get_image/#asposepydrawingsize)|
|get_thumbnail(options)|[get_image(options: ITiffOptions)](https://reference.aspose.com/slides/th/python-net/aspose.slides/slide/get_image/#asposeslidesexportitiffoptions)|
|get_thumbnail(options)|[get_image(options: IRenderingOptions)](https://reference.aspose.com/slides/th/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions)|
|get_thumbnail(options, scale_x, scale_y)|[get_image(options, scale_x, scale_y)](https://reference.aspose.com/slides/th/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnail(options, image_size)|[get_image(options, image_size)](https://reference.aspose.com/slides/th/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|render_to_graphics(options, graphics)|No Modern API replacement|
|render_to_graphics(options, graphics, scale_x, scale_y)|No Modern API replacement|
|render_to_graphics(options, graphics, rendering_size)|No Modern API replacement|

### **คลาส Shape**

|ลายเซ็นเมธอด|ลายเซ็นเมธอดแทน|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/get_image/#)|
|get_thumbnail(bounds, scale_x, scale_y)|[get_image(bounds, scale_x, scale_y)](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/get_image/#shapethumbnailbounds-float-float)|

### **คลาส ImageCollection**

|ลายเซ็นเมธอด|ลายเซ็นเมธอดแทน|
| :- | :- |
|add_image(image: aspose.pydrawing.Image)|[add_image(image)](https://reference.aspose.com/slides/th/python-net/aspose.slides/imagecollection/add_image/#iimage)|

### **คลาส PPImage**

|ลายเซ็นเมธอด/พร็อพเพอร์ตี|ลายเซ็นเมธอด/พร็อพเพอร์ตีแทน|
| :- | :- |
|replace_image(new_image: aspose.pydrawing.Image)|[replace_image(new_image)](https://reference.aspose.com/slides/th/python-net/aspose.slides/ppimage/replace_image/#iimage)|
|system_image|[image](https://reference.aspose.com/slides/th/python-net/aspose.slides/ppimage/image/)|

### **คลาส ImageWrapperFactory**

|ลายเซ็นเมธอด|ลายเซ็นเมธอดแทน|
| :- | :- |
|create_image_wrapper(image: aspose.pydrawing.Image)|[create_image_wrapper(image)](https://reference.aspose.com/slides/th/python-net/aspose.slides/iimagewrapperfactory/create_image_wrapper/#iimage)|

### **คลาส PatternFormat**

|ลายเซ็นเมธอด|ลายเซ็นเมธอดแทน|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile(background, foreground)](https://reference.aspose.com/slides/th/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor-asposepydrawingcolor)|
|get_tile_image(style_color)|[get_tile(style_color)](https://reference.aspose.com/slides/th/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor)|

### **คลาส IPatternFormatEffectiveData**

|ลายเซ็นเมธอด|ลายเซ็นเมธอดแทน|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile_i_image(background, foreground)](https://reference.aspose.com/slides/th/python-net/aspose.slides/ipatternformateffectivedata/get_tile_i_image/#asposepydrawingcolor-asposepydrawingcolor)|

### **คลาส Output**

|ลายเซ็นเมธอด|ลายเซ็นเมธอดแทน|
| :- | :- |
|add(path, image: aspose.pydrawing.Image)|[add(path, image)](https://reference.aspose.com/slides/th/python-net/aspose.slides.export.web/output/add/#str-iimage)|

## **การสนับสนุน API สำหรับ aspose.pydrawing.Graphics**

เมธอดที่ใช้ `aspose.pydrawing.Graphics` ถูกเลิกใช้งานและไม่มีการแทนที่โดยตรงใน Modern API

ใช้เมธอดการเรนเดอร์ภาพของ Modern API แทนการใช้ API ที่เรนเดอร์ไปยัง `aspose.pydrawing.Graphics`:
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, scale_x, scale_y)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, rendering_size)`

# **คำถามที่พบบ่อย**

**ทำไม `aspose.pydrawing.Graphics` ถึงถูกยกเลิก?**

การสนับสนุน `aspose.pydrawing.Graphics` ถูกระบุว่าเลิกใช้งานใน API สาธารณะเพื่อรวมการทำงานของการเรนเดอร์และภาพ, ขจัดการเชื่อมโยงกับการพึ่งพาแพลตฟอร์มเฉพาะ, และเปลี่ยนไปใช้แนวทางข้ามแพลตฟอร์มด้วย [IImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/iimage/). ใช้ `get_image` หรือ `get_images` แทนการเรนเดอร์ไปยัง `aspose.pydrawing.Graphics`.

**ประโยชน์เชิงปฏิบัติของ [IImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/iimage/) เทียบกับ `aspose.pydrawing.Image`/`aspose.pydrawing.Bitmap` คืออะไร?**

[IImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/iimage/) ทำให้การทำงานกับภาพแรสเตอร์และเวกเตอร์ร่วมกัน, ทำให้การบันทึกเป็นฟอร์แมตต่าง ๆ ง่ายขึ้นผ่าน [ImageFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/imageformat/), ลดการพึ่งพา pydrawing, และทำให้โค้ดพกพาได้ดีขึ้นในหลายสภาพแวดล้อม.

**Modern API จะส่งผลต่อประสิทธิภาพการสร้างภาพย่อหรือไม่?**

การสลับจาก `get_thumbnail` ไปยัง `get_image` ไม่ทำให้สถานการณ์แย่ลง: เมธอดใหม่ให้ความสามารถเดียวกันในการสร้างภาพพร้อมตัวเลือกและขนาด, พร้อมการสนับสนุนตัวเลือกการเรนเดอร์ ขึ้นอยู่กับสถานการณ์อาจมีการเพิ่มหรืออาจไม่มีการเปลี่ยนแปลงประสิทธิภาพ, แต่ด้านฟังก์ชันการทำงานเทียบเท่ากัน.