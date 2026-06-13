---
title: เพิ่มประสิทธิภาพการประมวลผลภาพด้วย API สมัยใหม่
linktitle: API สมัยใหม่
type: docs
weight: 280
url: /th/cpp/modern-api/
keywords:
- System.Drawing
- API สมัยใหม่
- การวาด
- ภาพย่อสไลด์
- สไลด์เป็นภาพ
- ภาพย่อรูปทรง
- รูปทรงเป็นภาพ
- ภาพย่อการนำเสนอ
- การนำเสนอเป็นภาพหลายภาพ
- เพิ่มภาพ
- เพิ่มรูปภาพ
- C++
- Aspose.Slides
description: "ทำให้การประมวลผลภาพสไลด์ทันสมัยโดยการเปลี่ยนจาก API ภาพที่เลิกใช้เป็น API สมัยใหม่ของ C++ เพื่อการอัตโนมัติ PowerPoint และ OpenDocument อย่างราบรื่น."
---
## **บทนำ**

ขณะนี้ไลบรารี Aspose.Slides สำหรับ C++ มีการพึ่งพาใน API สาธารณะต่อคลาสต่อไปนี้จาก System::Drawing:
- [System::Drawing::Graphics](https://reference.aspose.com/slides/th/cpp/system.drawing/graphics/)
- [System::Drawing::Image](https://reference.aspose.com/slides/th/cpp/system.drawing/image/)
- [System::Drawing::Bitmap](https://reference.aspose.com/slides/th/cpp/system.drawing/bitmap/)

ตั้งแต่เวอร์ชัน 24.4 API สาธารณะนี้ได้รับการประกาศว่าเลิกใช้แล้ว

เพื่อขจัดการพึ่งพา System::Drawing ใน API สาธารณะ เราได้เพิ่มที่เรียกว่า “Modern API” เมธอดที่ใช้ [System::Drawing::Image](https://reference.aspose.com/slides/th/cpp/system.drawing/image/) และ [System::Drawing::Bitmap](https://reference.aspose.com/slides/th/cpp/system.drawing/bitmap/) ถูกประกาศว่าเลิกใช้และควรแทนที่ด้วยเมธอดที่สอดคล้องจาก Modern API เมธอดที่ใช้ [System::Drawing::Graphics](https://reference.aspose.com/slides/th/cpp/system.drawing/graphics/) ถูกประกาศว่าเลิกใช้และไม่มีการแทนที่โดยตรงใน Modern API

ในเวอร์ชันปัจจุบัน ให้ถือว่า API สาธารณะที่พึ่งพา type ของ System::Drawing เป็นรุ่น legacy/เลิกใช้ ใช้ Modern API สำหรับโค้ดใหม่และเมื่อย้าย workflow การประมวลผลภาพที่มีอยู่

## **API สมัยใหม่**

เพิ่มคลาสและ enum ต่อไปนี้ใน API สาธารณะ:

- [Aspose::Slides::IImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/iimage/) - แทนภาพเรสเตอร์หรือเวกเตอร์
- [Aspose::Slides::ImageFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/imageformat/) - แทนรูปแบบไฟล์ของภาพ
- [Aspose::Slides::Images](https://reference.aspose.com/slides/th/cpp/aspose.slides/images/) - วิธีการสร้างและทำงานกับอินเทอร์เฟซ [IImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/iimage/)

ใช้ `GetImage` เพื่อเรนเดอร์สไลด์หรือรูปทรงเดียว ใช้ `GetImages` เพื่อเรนเดอร์หลายสไลด์ของงานนำเสนอ ใช้เมธอดจาก [Images](https://reference.aspose.com/slides/th/cpp/aspose.slides/images/) เพื่อโหลดภาพ, `AddImage` กับ [IImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/iimage/) เพื่อเพิ่มเข้าไปในงานนำเสนอ, และ `ReplaceImage` กับ [IImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/iimage/) เพื่อปรับปรุงภาพที่มีอยู่ในงานนำเสนอ

สถานการณ์ทั่วไปของการใช้ API ใหม่อาจมีลักษณะดังต่อไปนี้:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();
        
// สร้างอินสแตนซ์ IImage ที่ใช้ได้ครั้งเดียวจากไฟล์บนดิสก์.  
System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
            
// สร้างภาพ PowerPoint โดยเพิ่มอินสแตนซ์ของ IImage ไปยังภาพของงานนำเสนอ.
System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);
        
// เพิ่มรูปทรงภาพบนสไลด์ที่ 1
pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
        
// รับอินสแตนซ์ของ IImage ที่เป็นตัวแทนสไลด์ที่ 1.
auto slideImage = pres->get_Slide(0)->GetImage(System::Drawing::Size(1920, 1080));

// บันทึกภาพลงบนดิสก์.
slideImage->Save(u"slide1.jpeg", Aspose::Slides::ImageFormat::Jpeg);
```

## **การแทนที่โค้ดเดิมด้วย API สมัยใหม่**

เพื่ออำนวยความสะดวกในการเปลี่ยนแปลง อินเทอร์เฟซของ [IImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/iimage/) ใหม่ทำซ้ำลายเซ็นที่แยกจากคลาส [System::Drawing::Image](https://reference.aspose.com/slides/th/cpp/system.drawing/image/) และ [System::Drawing::Bitmap](https://reference.aspose.com/slides/th/cpp/system.drawing/bitmap/) โดยทั่วไปคุณแค่ต้องแทนที่การเรียกเมธอดเก่าที่ใช้ System::Drawing ด้วยเมธอดใหม่

### **การดึงภาพย่อของสไลด์**

API เดิม/เลิกใช้:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->GetThumbnail()->Save(u"slide1.png");
```

API สมัยใหม่:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->GetImage()->Save(u"slide1.png");
```

### **การดึงภาพย่อของรูปทรง**

API เดิม/เลิกใช้:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->get_Shape(0)->GetThumbnail()->Save(u"shape.png");
```

API สมัยใหม่:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->get_Shape(0)->GetImage()->Save(u"shape.png");
```

### **การดึงภาพย่อของงานนำเสนอ**

API เดิม/เลิกใช้:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

auto bitmaps = pres->GetThumbnails(System::MakeObject<RenderingOptions>(), System::Drawing::Size(1980, 1028));

for (int32_t index = 0; index < bitmaps->get_Length(); index++)
{
    System::SharedPtr<System::Drawing::Bitmap> thumbnail = bitmaps[index];
    thumbnail->Save(System::String::Format(u"slide_{0}.png", index), System::Drawing::Imaging::ImageFormat::get_Png());
}
```

API สมัยใหม่:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

auto images = pres->GetImages(System::MakeObject<RenderingOptions>(), System::Drawing::Size(1980, 1028));

for (int32_t index = 0; index < images->get_Length(); index++)
{
    System::SharedPtr<IImage> thumbnail = images[index];
    thumbnail->Save(System::String::Format(u"slide_{0}.png", index), Aspose::Slides::ImageFormat::Png);
}
```

### **การเพิ่มรูปภาพลงในงานนำเสนอ**

API เดิม/เลิกใช้:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<System::Drawing::Image> image = System::Drawing::Image::FromFile(u"image.png");

System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);

pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
```

API สมัยใหม่:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<Aspose::Slides::IImage> image = Aspose::Slides::Images::FromFile(u"image.png");

System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);

pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
```

## **เมธอด/คุณสมบัติที่เลิกใช้และการแทนที่ใน API สมัยใหม่**

### **คลาส Presentation**
|ลายเซ็นเมธอด|ลายเซ็นเมธอดแทน|
| :- | :- |
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format)|No Modern API replacement|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format, System::SharedPtr&lt;Export::ISaveOptions&gt; options)|No Modern API replacement|

### **คลาส Slide**
|ลายเซ็นเมธอด|ลายเซ็นเมธอดแทน|
| :- | :- |
|GetThumbnail()|GetImage()|
|GetThumbnail(float scaleX, float scaleY)|GetImage(float scaleX, float scaleY)|
|GetThumbnail(System::Drawing::Size imageSize)|GetImage(System::Drawing::Size imageSize)|
|GetThumbnail(System::SharedPtr&lt;Export::ITiffOptions&gt; options)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics)|No Modern API replacement|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics, float scaleX, float scaleY)|No Modern API replacement|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics, System::Drawing::Size renderingSize)|No Modern API replacement|

### **คลาส Shape**
|ลายเซ็นเมธอด|ลายเซ็นเมธอดแทน|
| :- | :- |
|GetThumbnail()|GetImage()|
|GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|

### **คลาส ImageCollection**
|ลายเซ็นเมธอด|ลายเซ็นเมธอดแทน|
| :- | :- |
|AddImage(System::SharedPtr&lt;System::Drawing::Image&gt; image)|AddImage(System::SharedPtr&lt;IImage&gt; image)|

### **คลาส PPImage**
|ลายเซ็นเมธอด|ลายเซ็นเมธอดแทน|
| :- | :- |
|ReplaceImage(System::SharedPtr&lt;System::Drawing::Image&gt; newImage)|ReplaceImage(System::SharedPtr&lt;Aspose::Slides::IImage&gt; newImage)|
|get_SystemImage()|get_Image()|

### **คลาส PatternFormat**
|ลายเซ็นเมธอด|ลายเซ็นเมธอดแทน|
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTile(System::Drawing::Color background, System::Drawing::Color foreground)|
|GetTileImage(System::Drawing::Color styleColor)|GetTile(System::Drawing::Color styleColor)|

### **คลาส IPatternFormatEffectiveData**
|ลายเซ็นเมธอด|ลายเซ็นเมธอดแทน|
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTileIImage(System::Drawing::Color background, System::Drawing::Color foreground)|

## **การสนับสนุน API สำหรับ System::Drawing::Graphics**

เมธอดที่ใช้ [System::Drawing::Graphics](https://reference.aspose.com/slides/th/cpp/system.drawing/graphics/) ถูกประกาศว่าเลิกใช้และไม่มีการแทนที่โดยตรงใน Modern API

ใช้เมธอดการเรนเดอร์ภาพของ Modern API แทนการเรนเดอร์ไปยัง [System::Drawing::Graphics](https://reference.aspose.com/slides/th/cpp/system.drawing/graphics/):
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;)](https://reference.aspose.com/slides/th/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, float, float)](https://reference.aspose.com/slides/th/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-float-float-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, System::Drawing::Size)](https://reference.aspose.com/slides/th/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-systemdrawingsize-method)

## **ถามตอบ**

**ทำไมจึงเลิกใช้ [System::Drawing::Graphics](https://reference.aspose.com/slides/th/cpp/system.drawing/graphics/)?**

การสนับสนุน [System::Drawing::Graphics](https://reference.aspose.com/slides/th/cpp/system.drawing/graphics/) ถูกเลิกใช้ใน API สาธารณะเพื่อรวมการทำงานด้านการเรนเดอร์และภาพ, กำจัดการพึ่งพาแพลตฟอร์มเฉพาะ, และเปลี่ยนไปใช้แนวทางข้ามแพลตฟอร์มกับ [IImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/iimage/) ใช้ `GetImage` หรือ `GetImages` แทนการเรนเดอร์ไปยัง [System::Drawing::Graphics](https://reference.aspose.com/slides/th/cpp/system.drawing/graphics/)

**ประโยชน์เชิงปฏิบัติของ [IImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/iimage/) เทียบกับ [System::Drawing::Image](https://reference.aspose.com/slides/th/cpp/system.drawing/image/)/[System::Drawing::Bitmap](https://reference.aspose.com/slides/th/cpp/system.drawing/bitmap/) คืออะไร?**

[IImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/iimage/) ทำให้การทำงานกับภาพเรสเตอร์และเวกเตอร์เป็นหนึ่งเดียว, ทำให้การบันทึกเป็นหลายรูปแบบง่ายขึ้นผ่าน [ImageFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/imageformat/), ลดการพึ่งพา `System::Drawing`, และทำให้โค้ดพกพาได้ดีขึ้นในสภาพแวดล้อมต่างๆ

**API สมัยใหม่จะส่งผลต่อประสิทธิภาพการสร้างภาพย่อหรือไม่?**

การเปลี่ยนจาก `GetThumbnail` ไปเป็น `GetImage` ไม่ทำให้สถานการณ์แย่ลง: เมธอดใหม่ให้ความสามารถเดียวกันในการสร้างภาพพร้อมตัวเลือกและขนาดต่างๆ, ในขณะที่ยังคงรองรับตัวเลือกการเรนเดอร์ ผลลัพธ์ที่ได้อาจเพิ่มหรือดรอปขึ้นอยู่กับกรณีใช้งาน, แต่ในเชิงฟังก์ชันการแทนที่ถือว่าเทียบเท่ากัน