---
title: แปลงสไลด์การนำเสนอเป็นภาพใน C++
linktitle: สไลด์เป็นภาพ
type: docs
weight: 41
url: /th/cpp/convert-slide/
keywords:
- แปลงสไลด์
- ส่งออกสไลด์
- สไลด์เป็นภาพ
- บันทึกสไลด์เป็นภาพ
- สไลด์เป็น EMF
- สไลด์เป็น PNG
- สไลด์เป็น JPEG
- สไลด์เป็นบิตแมพ
- สไลด์เป็น TIFF
- PowerPoint
- OpenDocument
- งานนำเสนอ
- C++
- Aspose.Slides
description: "แปลงสไลด์จากงานนำเสนอ PPT, PPTX และ ODP เป็น PNG, JPEG, GIF, TIFF, EMF และรูปแบบภาพอื่น ๆ ใน C++ ด้วย Aspose.Slides สำหรับ C++."
---
## **บทนำ**

Aspose.Slides สำหรับ C++ สามารถเรนเดอร์สไลด์แต่ละสไลด์จากงานนำเสนอ PowerPoint และ OpenDocument ให้เป็นรูปแบบ PNG, JPEG, GIF, TIFF และรูปแบบภาพอื่น ๆ

เพื่อแปลงสไลด์เป็นภาพ ให้ทำตามขั้นตอนต่อไปนี้:
1. โหลดงานนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) 
2. เลือกสไลด์ที่คุณต้องการเรนเดอร์ 
3. หากจำเป็น ให้กำหนดค่าการเรนเดอร์ด้วยคลาส [RenderingOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/renderingoptions/) หรือ [TiffOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/tiffoptions/) 
4. เรียกเมธอด [ISlide::GetImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/islide/getimage/) ซึ่งจะคืนค่าอ็อบเจ็กต์ [IImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/iimage/) 
5. เรียกเมธอด [IImage::Save](https://reference.aspose.com/slides/th/cpp/aspose.slides/iimage/save/) และระบุรูปแบบเอาต์พุตด้วยค่า [ImageFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/imageformat/)

## **แปลงสไลด์เป็นภาพ PNG**

การแปลงที่ง่ายที่สุดใช้การตั้งค่าเรนเดอร์เริ่มต้น อ็อบเจ็กต์ [IImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/iimage/) ที่ได้สามารถประมวลผลในหน่วยความจำหรือบันทึกลงไฟล์ได้

ตัวอย่าง C++ ด้านล่างจะเรนเดอร์สไลด์แรกและบันทึกเป็นภาพ PNG:
```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage();
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

## **แปลงสไลด์เป็นภาพด้วยขนาดที่กำหนดเอง**

ใช้การโอเวอร์โหลดของ [ISlide::GetImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/islide/getimage/) ที่รับค่า [Size](https://reference.aspose.com/slides/th/cpp/system.drawing/size/) เพื่อเรนเดอร์สไลด์ด้วยขนาดพิกเซลที่แน่นอน

ตัวอย่างต่อไปนี้สร้างภาพ JPEG ขนาด 1820 × 1040:
```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Drawing;

Size imageSize(1820, 1040);

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(imageSize);
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

## **แปลงสไลด์ที่มีบันทึกย่อและคอมเมนต์เป็นภาพ**

โดยค่าเริ่มต้น ภาพสไลด์จะไม่รวมบันทึกย่อหรือคอมเมนต์ ให้กำหนดอ็อบเจ็กต์ [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/notescommentslayoutingoptions/) ให้กับเมธอด [RenderingOptions::set_SlidesLayoutOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/renderingoptions/set_slideslayoutoptions/) เพื่อควบคุมตำแหน่งที่บันทึกย่อและคอมเมนต์จะแสดง

ตัวอย่างต่อไปนี้วางบันทึกย่อที่ถูกตัดท้ายด้านล่างสไลด์และคอมเมนต์ทางด้านขวาของสไลด์:
```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/CommentsPositions.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/RenderingOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

float scaleX = 2.0f;
float scaleY = scaleX;

auto layoutOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_NotesPosition(NotesPositions::BottomTruncated);
layoutOptions->set_CommentsPosition(CommentsPositions::Right);
layoutOptions->set_CommentsAreaWidth(500);
layoutOptions->set_CommentsAreaColor(Color::get_AntiqueWhite());

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layoutOptions);

auto presentation = MakeObject<Presentation>(u"Presentation_with_notes_and_comments.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(renderingOptions, scaleX, scaleY);
image->Save(u"Image_with_notes_and_comments_0.gif", ImageFormat::Gif);

image->Dispose();
presentation->Dispose();
```

{{% alert title="Warning" color="warning" %}}
สำหรับการแปลงสไลด์เป็นภาพ อย่าเรียกเมธอด [NotesCommentsLayoutingOptions::set_NotesPosition](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/) ให้เป็นค่า [BottomFull](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/notespositions/) เนื่องจากบันทึกย่ออาจมีข้อความมากกว่าที่ขนาดภาพคงที่จะบรรจุได้ ให้ใช้ [BottomTruncated](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/notespositions/) แทน
{{% /alert %}}

## **แปลงสไลด์เป็นภาพโดยใช้ตัวเลือก TIFF**

คลาส [TiffOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/tiffoptions/) ให้คุณควบคุมขนาด ความละเอียด และคุณสมบัติอื่น ๆ ของภาพ TIFF ที่เรนเดอร์

ตัวอย่างต่อไปนี้เรนเดอร์สไลด์แรกเป็นภาพ TIFF ขนาด 2160 × 2880 ที่ความละเอียด 300 DPI:
```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/TiffOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_ImageSize(Size(2160, 2880));
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(tiffOptions);
image->Save(u"output.tiff", ImageFormat::Tiff);

image->Dispose();
presentation->Dispose();
```

## **แปลงสไลด์ทั้งหมดเป็นภาพ**

วนลูปผ่านคอลเลกชันสไลด์เพื่อแปลงงานนำเสนอทั้งหมดเป็นชุดของภาพ โดยสไลด์ที่ซ่อนอยู่จะถูกรวมไว้ เว้นแต่คุณจะข้ามโดยเจตนา

ตัวอย่างต่อไปนี้เรนเดอร์สไลด์ทั้งหมดเป็นภาพ JPEG โดยใช้ค่าสเกลแนวนอนและแนวตั้งเป็น 2:
```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

float scaleX = 2.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

int32_t slideCount = presentation->get_Slides()->get_Count();
for (int32_t index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(scaleX, scaleY);
    image->Save(String::Format(u"Slide_{0}.jpg", index), ImageFormat::Jpeg);
    image->Dispose();
}

presentation->Dispose();
```

## **สร้างเอาต์พุต Enhanced Metafile**

Enhanced Metafile (EMF) มีประโยชน์เมื่อกราฟิกแบบเวกเตอร์ต้องแลกเปลี่ยนกับ Microsoft Office หรือแอปพลิเคชัน Windows อื่น ๆ ที่สนับสนุน Windows metafile ต่างจากภาพแบบพิกเซล EMF สามารถเก็บการวาดเวกเตอร์ที่ขยายได้โดยไม่สูญเสียความคมชัด อย่างไรก็ตาม EMF เป็นรูปแบบความเข้ากันได้สำหรับแอปพลิเคชันที่รองรับ Windows metafile ไม่ได้เป็นรูปแบบการแลกเปลี่ยนสากล นอกจากนี้เนื้อหาในสไลด์ที่ซับซ้อน เช่น ภาพบิตแมปและเอฟเฟกต์บางอย่าง อาจถูกจัดเก็บเป็นองค์ประกอบแบบเรสเตอร์ภายในคอนเทนเนอร์เมตาฟายล์เวกเตอร์

### **ส่งออกสไลด์เป็น EMF**

เมธอด [ISlide::WriteAsEmf](https://reference.aspose.com/slides/th/cpp/aspose.slides/islide/writeasemf/) จะเขียนอ็อบเจ็กต์ [ISlide](https://reference.aspose.com/slides/th/cpp/aspose.slides/islide/) ไปยังสตรีมเป้าหมายในรูปแบบ EMF ตัวอย่างต่อไปนี้โหลดงานนำเสนอ เลือกสไลด์แรก และเขียนลงสตรีมไฟล์ EMF:
```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto emfStream = File::Create(u"Slide_0.emf");
slide->WriteAsEmf(emfStream);

emfStream->Close();
presentation->Dispose();
```

ผู้เรียกต้องเป็นเจ้าของสตรีมที่ส่งให้กับ [ISlide::WriteAsEmf](https://reference.aspose.com/slides/th/cpp/aspose.slides/islide/writeasemf/) และต้องปิดหรือทำลายสตรีมนั้น Aspose.Slides จะเขียนที่ตำแหน่งปัจจุบันของสตรีมและปล่อยให้สตรีมเปิดอยู่

### **แปลงภาพ SVG เป็น EMF แล้วเพิ่มลงในงานนำเสนอ**

ใช้ [ISvgImage::WriteAsEmf](https://reference.aspose.com/slides/th/cpp/aspose.slides/isvgimage/writeasemf/) เพื่อแปลงเนื้อหา SVG เป็น EMF ไบต์ที่ได้สามารถเพิ่มลงในงานนำเสนอผ่าน [IImageCollection::AddImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/iimagecollection/addimage/) และวางบนสไลด์ด้วย [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishapecollection/addpictureframe/)

ตัวอย่างต่อไปนี้สร้างอ็อบเจ็กต์ [SvgImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/svgimage/) จากโค้ด SVG แปลงเป็น EMF ในหน่วยความจำ แทรกเมตาฟายล์ในสไลด์แรก และบันทึกงานนำเสนอ:
```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

String svgContent = u"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
auto svgImage = MakeObject<SvgImage>(svgContent);

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto emfStream = MakeObject<MemoryStream>();
svgImage->WriteAsEmf(emfStream);

auto emfData = emfStream->ToArray();
auto image = presentation->get_Images()->AddImage(emfData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20, 20, 200, 100, image);

presentation->Save(u"Presentation_with_emf.pptx", SaveFormat::Pptx);

emfStream->Close();
presentation->Dispose();
```

[ISvgImage::WriteAsEmf](https://reference.aspose.com/slides/th/cpp/aspose.slides/isvgimage/writeasemf/) ไม่ได้เป็นเจ้าของสตรีมปลายทาง หลังจากเขียน สตรีมจะอยู่ที่ตำแหน่งท้ายข้อมูลที่สร้างขึ้น ตัวอย่างเรียก [MemoryStream::ToArray](https://reference.aspose.com/slides/th/cpp/system.io/memorystream/toarray/) เพื่อรับบัฟเฟอร์เต็มโดยไม่คำนึงถึงตำแหน่งสตรีมปัจจุบัน แล้วส่งอาร์เรย์ไบต์นั้นไปยัง [IImageCollection::AddImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/iimagecollection/addimage/) ให้เปิดสตรีมไว้จนกว่าผู้ใช้จะอ่านจบ แล้วปิดสตรีมหลังจากนั้น

การสร้าง EMF มีให้ใช้บนระบบปฏิบัติการที่สนับสนุนโดย Aspose.Slides สำหรับ C++ แต่การเรนเดอร์อาจแตกต่างกันระหว่างแพลตฟอร์มเมื่อไม่มีฟอนต์หรือไลบรารีกราฟิกพื้นฐาน ติดตั้งฟอนต์ที่ใช้ในเนื้อหาเดิมหรือกำหนดการทดแทนที่เหมาะสม ปฏิบัติตาม [platform requirements](/slides/th/cpp/system-requirements/) ของ Aspose.Slides สำหรับ C++ และตรวจสอบผลลัพธ์ในแอปพลิเคชันที่รับ EMF เป้าหมาย แอปพลิเคชันบน Linux และ macOS มักมีการสนับสนุนการแสดงและแก้ไข Windows metafile ที่จำกัดหรือไม่สม่ำเสมอ

## **การเรนเดอร์ Emoji สี**

{{% alert title="Note" color="info" %}}
เพื่อให้การเรนเดอร์ emoji สีถูกต้องเมื่อแปลงสไลด์งานนำเสนอเป็นภาพ ต้องติดตั้งและให้ฟอนต์ emoji ที่ใช้ในงานนำเสนอพร้อมใช้งานบนระบบที่ทำการแปลง ตัวอย่างเช่น หากงานนำเสนอใช้ **Segoe UI Emoji** แต่ฟอนต์นี้หายไป emoji อาจปรากฏเป็นสีเดียวในภาพผลลัพธ์
{{% /alert %}}

## **คำถามที่พบบ่อย**

**Aspose.Slides รองรับการเรนเดอร์สไลด์ที่มีแอนิเมชันหรือไม่?**
ไม่มี เมธอด [ISlide::GetImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/islide/getimage/) จะเรนเดอร์ภาพสไลด์แบบคงที่และไม่ส่งออกแอนิเมชัน

**สามารถส่งออกสไลด์ที่ซ่อนอยู่เป็นภาพได้หรือไม่?**
ได้ สไลด์ที่ซ่อนอยู่สามารถเรนเดอร์ได้เช่นสไลด์ปกติ ให้รวมสไลด์เหล่านั้นในลูปประมวลผลตามตัวอย่างข้างต้น

**เงาและเอฟเฟกต์อื่น ๆ ถูกเก็บไว้ในภาพสไลด์หรือไม่?**
ได้ Aspose.Slides จะเรนเดอร์เงา, ความโปร่งใส และเอฟเฟกต์กราฟิกที่สนับสนุนอื่น ๆ ในภาพสไลด์