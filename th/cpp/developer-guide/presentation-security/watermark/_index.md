---
title: เพิ่มลายน้ำในงานนำเสนอด้วย C++
linktitle: ลายน้ำ
type: docs
weight: 40
url: /th/cpp/watermark/
keywords:
- ลายน้ำ
- ลายน้ำข้อความ
- ลายน้ำภาพ
- เพิ่มลายน้ำ
- แก้ไขลายน้ำ
- ลบลายน้ำ
- ลบลายน้ำ
- เพิ่มลายน้ำใน PPT
- เพิ่มลายน้ำใน PPTX
- เพิ่มลายน้ำใน ODP
- ลบลายน้ำจาก PPT
- ลบลายน้ำจาก PPTX
- ลบลายน้ำจาก ODP
- ลบลายน้ำจาก PPT
- ลบลายน้ำจาก PPTX
- ลบลายน้ำจาก ODP
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "จัดการลายน้ำแบบข้อความและภาพในงานนำเสนอ PowerPoint และ OpenDocument ด้วย C++ เพื่อบ่งบอกว่าเป็นร่าง, ข้อมูลลับ, ลิขสิทธิ์และอื่น ๆ."
---
## **บทนำ**

**Watermark** ในการพรีเซนเทชันคือเครื่องหมายข้อความหรือรูปภาพที่ใช้บนสไลด์หรือทั่วทั้งสไลด์ของการพรีเซนเทชัน โดยทั่วไป watermark จะใช้เพื่อบ่งบอกว่าการพรีเซนเทชันเป็นร่าง (เช่น watermark “Draft”) มีข้อมูลที่เป็นความลับ (เช่น watermark “Confidential”) ระบุว่าการพรีเซนเทชันเป็นของบริษัทใด (เช่น watermark “Company Name”) หรือบ่งบอกผู้เขียนการพรีเซนเทชัน เป็นต้น Watermark ช่วยป้องกันการละเมิดลิขสิทธิ์โดยบ่งบอกว่าการพรีเซนเทชันไม่ควรคัดลอก Watermark ใช้ได้ทั้งในรูปแบบ PowerPoint และ OpenOffice ใน Aspose.Slides คุณสามารถเพิ่ม watermark ให้กับไฟล์ PowerPoint PPT, PPTX และไฟล์ OpenOffice ODP ได้

ใน [**Aspose.Slides**](https://products.aspose.com/slides/th/cpp/) มีวิธีต่าง ๆ ที่คุณสามารถสร้าง watermark ในเอกสาร PowerPoint หรือ OpenOffice และปรับแก้การออกแบบและพฤติกรรมของมันได้ ส่วนร่วมคือ หากต้องการเพิ่ม watermark แบบข้อความ คุณควรใช้อินเตอร์เฟซ [ITextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/) และหากต้องการเพิ่ม watermark แบบภาพ ให้ใช้คลาส [PictureFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/pictureframe/) หรือเติมรูปร่าง watermark ด้วยภาพ `PictureFrame` implements อินเตอร์เฟซ [IShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/) ทำให้คุณสามารถใช้การตั้งค่าต่าง ๆ ของวัตถุรูปร่างได้อย่างยืดหยุ่น เนื่องจาก `ITextFrame` ไม่ใช่รูปร่างและการตั้งค่ามีข้อจำกัด จึงถูกห่อหุ้มอยู่ในอ็อบเจกต์ [IShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/)

มีสองวิธีในการใช้ watermark: กับสไลด์เดี่ยวหรือกับสไลด์ทั้งหมด Slide Master จะใช้เพื่อเพิ่ม watermark ให้กับสไลด์ทั้งหมด — watermark จะถูกเพิ่มไปที่ Slide Master ออกแบบที่นั่นแล้วนำไปใช้กับสไลด์ทั้งหมดโดยไม่กระทบต่อสิทธิ์การแก้ไข watermark บนสไลด์แต่ละอัน

โดยทั่วไป watermark ถือว่าไม่สามารถแก้ไขได้โดยผู้ใช้คนอื่น ๆ เพื่อป้องกันไม่ให้ watermark (หรือรูปร่างแม่ของ watermark) ถูกแก้ไข Aspose.Slides มีฟังก์ชันการล็อกรูปร่าง คุณสามารถล็อกรูปร่างเฉพาะบนสไลด์ปกติหรือบน Slide Master ได้ เมื่อนำ watermark shape ไปล็อกบน Slide Master จะถูกล็อกบนสไลด์ทั้งหมดโดยอัตโนมัติ

คุณสามารถตั้งชื่อให้กับ watermark เพื่อให้ในอนาคตถ้าต้องการลบ สามารถค้นหาได้จากชื่อของรูปร่างบนสไลด์

คุณสามารถออกแบบ watermark ได้ทุกแบบ อย่างไรก็ตาม watermark ส่วนใหญ่จะมีคุณลักษณะทั่วไป เช่น การจัดกึ่งกลาง การหมุน การวางเป็นชั้นหน้า ฯลฯ เราจะพิจารณาการใช้คุณลักษณะเหล่านี้ในตัวอย่างต่อไป

## **Watermark แบบข้อความ**

### **เพิ่ม Watermark แบบข้อความลงในสไลด์**

เพื่อเพิ่ม watermark แบบข้อความใน PPT, PPTX หรือ ODP คุณสามารถเพิ่มรูปร่างลงในสไลด์ก่อน แล้วเพิ่ม text frame ให้กับรูปร่างนั้น Text frame แทนด้วยอินเตอร์เฟซ [ITextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/) ประเภทนี้ไม่ได้สืบทอดจาก [IShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/) ซึ่งมีคุณสมบัติมากมายสำหรับการวางตำแหน่ง watermark อย่างยืดหยุ่น ดังนั้นอ็อบเจกต์ [ITextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/) จะถูกห่อหุ้มในอ็อบเจกต์ [IAutoShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/) เพื่อเพิ่มข้อความ watermark ให้กับรูปร่าง ให้ใช้เมธอด [AddTextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/addtextframe/) ตามตัวอย่างด้านล่าง

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="info" title="ดูเพิ่มเติม" %}} 
- [วิธีใช้คลาส TextFrame](/slides/th/cpp/text-formatting/)
{{% /alert %}}

### **เพิ่ม Watermark แบบข้อความให้กับพรีเซนเทชันทั้งหมด**

หากต้องการเพิ่ม watermark แบบข้อความให้กับพรีเซนเทชันทั้งหมด (หมายถึงทุกสไลด์พร้อมกัน) ให้เพิ่มลงใน [MasterSlide](https://reference.aspose.com/slides/th/cpp/aspose.slides/masterslide/) ส่วนตรรกะที่เหลือเหมือนกับการเพิ่ม watermark ให้กับสไลด์เดี่ยว — สร้างอ็อบเจกต์ [IAutoShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/) แล้วเพิ่ม watermark ให้กับมันโดยใช้เมธอด [AddTextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/addtextframe/)

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);

auto watermarkShape = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="info" title="ดูเพิ่มเติม" %}} 
- [วิธีใช้ Slide Master](/slides/th/cpp/slide-master/)
{{% /alert %}}

### **ตั้งค่าความโปร่งใสของรูปร่าง Watermark**

โดยค่าเริ่มต้น รูปร่างสี่เหลี่ยมจะมีสีเติมและสีขอบ บรรทัดโค้ดต่อไปนี้ทำให้รูปร่างเป็นแบบโปร่งใส

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

watermarkShape->get_FillFormat()->set_FillType(FillType::NoFill);
watermarkShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
```

### **ตั้งค่าแบบอักษรสำหรับ Watermark แบบข้อความ**

คุณสามารถเปลี่ยนแบบอักษรของข้อความ watermark ได้ตามตัวอย่างด้านล่าง

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(u"CONFIDENTIAL");

auto textFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat();
textFormat->set_LatinFont(MakeObject<FontData>(u"Arial"));
textFormat->set_FontHeight(50);
```

### **ตั้งค่าสีข้อความ Watermark**

เพื่อกำหนดสีของข้อความ watermark ให้ใช้โค้ดนี้

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(u"CONFIDENTIAL");

auto alpha = 150, red = 200, green = 200, blue = 200;

auto fillFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Solid);
fillFormat->get_SolidFillColor()->set_Color(Color::FromArgb(alpha, red, green, blue));
```

### **จัดกึ่งกลาง Watermark แบบข้อความ**

สามารถจัดกึ่งกลาง watermark บนสไลด์ได้ โดยทำตามขั้นตอนต่อไปนี้

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto slideSize = presentation->get_SlideSize()->get_Size();

auto watermarkWidth = 400;
auto watermarkHeight = 40;
auto watermarkX = (slideSize.get_Width() - watermarkWidth) / 2;
auto watermarkY = (slideSize.get_Height() - watermarkHeight) / 2;

auto watermarkShape = slide->get_Shapes()->AddAutoShape(
    ShapeType::Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);
```

รูปด้านล่างแสดงผลลัพธ์สุดท้าย

![The text watermark](text_watermark.png)

## **Watermark แบบภาพ**

### **เพิ่ม Watermark แบบภาพให้กับพรีเซนเทชัน**

เพื่อเพิ่ม watermark แบบภาพให้กับสไลด์พรีเซนเทชัน คุณสามารถทำตามขั้นตอนต่อไปนี้

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

auto imageStream = File::ReadAllBytes(u"watermark.png");
auto image = presentation->get_Images()->AddImage(imageStream);

watermarkShape->get_FillFormat()->set_FillType(FillType::Picture);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
```

## **ล็อก Watermark ไม่ให้แก้ไข**

หากต้องการป้องกันไม่ให้ watermark ถูกแก้ไข ให้ใช้เมธอด [IAutoShape::get_AutoShapeLock](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/get_autoshapelock/) บนรูปร_shape ด้วยคุณสมบัตินี้คุณสามารถป้องกันการเลือก การปรับขนาด การย้ายตำแหน่ง การจัดกลุ่มกับองค์ประกอบอื่น ๆ การล็อกข้อความจากการแก้ไข และอื่น ๆ อีกมากมาย

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IAutoShapeLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

// ล็อกรูปร่างลายน้ำไม่ให้แก้ไขได้
watermarkShape->get_AutoShapeLock()->set_SelectLocked(true);
watermarkShape->get_AutoShapeLock()->set_SizeLocked(true);
watermarkShape->get_AutoShapeLock()->set_TextLocked(true);
watermarkShape->get_AutoShapeLock()->set_PositionLocked(true);
watermarkShape->get_AutoShapeLock()->set_GroupingLocked(true);
```

## **นำ Watermark ไปอยู่ชั้นหน้า**

ใน Aspose.Slides คำสั่ง Z-order ของรูปร่างสามารถตั้งค่าได้ผ่านเมธอด [IShapeCollection::Reorder](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishapecollection/reorder/) โดยเรียกเมธอดนี้จากรายการสไลด์ของพรีเซนเทชันและส่งอ้างอิงรูปร่างและลำดับเลขเข้าไป ซึ่งทำให้สามารถนำรูปร่างไปอยู่ชั้นหน้า หรือย้ายไปอยู่ชั้นหลังของสไลด์ได้ ฟีเจอร์นี้เป็นประโยชน์อย่างยิ่งหากต้องการวาง watermark ไว้หน้าพรีเซนเทชัน

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

auto shapeCount = slide->get_Shapes()->get_Count();
slide->get_Shapes()->Reorder(shapeCount - 1, watermarkShape);
```

## **ตั้งค่าการหมุนของ Watermark**

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีปรับการหมุนของ watermark ให้วางแนวเฉียงผ่านสไลด์

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/size_f.h>
#include <system/math.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto slideSize = presentation->get_SlideSize()->get_Size();

auto diagonalAngle = Math::Atan((slideSize.get_Height() / slideSize.get_Width())) * 180 / Math::PI;

watermarkShape->set_Rotation((float)diagonalAngle);
```

## **ตั้งชื่อตัว Watermark**

Aspose.Slides อนุญาตให้คุณตั้งชื่อให้กับรูปร่างได้ โดยใช้ชื่อรูปร่างคุณสามารถเข้าถึงในภายหลังเพื่อแก้ไขหรือทำการลบได้ เพื่อกำหนดชื่อให้กับรูปร่าง watermark ให้เรียกเมธอด [IAutoShape::set_Name](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/set_name/)

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

watermarkShape->set_Name(u"watermark");
```

## **ลบ Watermark**

เพื่อทำการลบรูปร่าง watermark ให้ใช้เมธอด [IAutoShape::get_Name](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/get_name/) เพื่อค้นหาในรายการรูปร่างของสไลด์ แล้วส่งรูปร่าง watermark เข้าเมธอด [IShapeCollection::Remove](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishapecollection/remove/)

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/smart_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation_with_watermark.pptx");
auto slide = presentation->get_Slide(0);

auto slideShapes = slide->get_Shapes()->ToArray();
for(auto shape : slideShapes)
{
    if (String::Compare(shape->get_Name(), u"watermark", StringComparison::Ordinal) == 0)
    {
        slide->get_Shapes()->Remove(shape);
    }
}
```

## **ตัวอย่างการทำงานจริง**

คุณอาจต้องการลองใช้เครื่องมือออนไลน์ **Aspose.Slides free** [Add Watermark](https://products.aspose.app/slides/th/watermark) และ [Remove Watermark](https://products.aspose.app/slides/th/watermark/remove-watermark)

![Online tools to add and remove watermarks](online_tools.png)

## **คำถามที่พบบ่อย**

### Watermark คืออะไรและทำไมต้องใช้?

Watermark คือการวางข้อความหรือรูปภาพบนสไลด์เพื่อช่วยปกป้องทรัพย์สินทางปัญญา เพิ่มการจดจำแบรนด์ หรือป้องกันการใช้พรีเซนเทชันโดยไม่ได้รับอนุญาต

### ฉันสามารถเพิ่ม watermark ให้กับสไลด์ทั้งหมดในพรีเซนเทชันได้หรือไม่?

ได้ Aspose.Slides รองรับการเพิ่ม watermark ให้กับทุกสไลด์ในพรีเซนเทชันโดยอัตโนมัติ คุณสามารถวนลูปผ่านสไลด์ทั้งหมดและตั้งค่าการแสดง watermark แยกแต่ละสไลด์ได้

### ฉันจะปรับความโปร่งใสของ watermark ได้อย่างไร?

คุณสามารถปรับความโปร่งใสของ watermark ได้โดยแก้ไขการตั้งค่า fill ([FillFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/shape/get_fillformat/)) ของรูปร่าง ซึ่งจะทำให้ watermark ดูอ่อนโยนและไม่รบกวนเนื้อหาสไลด์

### รูปแบบภาพใดบ้างที่รองรับสำหรับ watermark?

Aspose.Slides รองรับรูปแบบภาพหลายประเภท เช่น PNG, JPEG, GIF, BMP, SVG และอื่น ๆ

### ฉันสามารถกำหนดแบบอักษรและสไตล์ของ watermark แบบข้อความได้หรือไม่?

ได้ คุณสามารถเลือกแบบอักษร, ขนาด และสไตล์ใดก็ได้เพื่อให้สอดคล้องกับการออกแบบพรีเซนเทชันและรักษาความสอดคล้องของแบรนด์

### ฉันจะเปลี่ยนตำแหน่งหรือทิศทางของ watermark อย่างไร?

คุณสามารถปรับตำแหน่งและทิศทางของ watermark ได้โดยโปรแกรมโดยการแก้ไขพิกัด, ขนาด และคุณสมบัติการหมุนของรูปร่าง 