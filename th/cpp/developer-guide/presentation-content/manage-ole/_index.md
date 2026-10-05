---
title: จัดการ OLE ในการนำเสนอด้วย C++
linktitle: จัดการ OLE
type: docs
weight: 40
url: /th/cpp/manage-ole/
keywords:
- วัตถุ OLE
- "การเชื่อมโยงและฝังวัตถุ"
- เพิ่ม OLE
- ฝัง OLE
- เพิ่มวัตถุ
- ฝังวัตถุ
- เพิ่มไฟล์
- ฝังไฟล์
- วัตถุที่เชื่อมโยง
- ไฟล์ที่เชื่อมโยง
- เปลี่ยน OLE
- ไอคอน OLE
- ชื่อ OLE
- เรียกออก OLE
- เรียกออกวัตถุ
- เรียกออกไฟล์
- PowerPoint
- การนำเสนอ
- C++
- Aspose.Slides
description: "ปรับแต่งการจัดการวัตถุ OLE ใน PowerPoint และไฟล์ OpenDocument ด้วย Aspose.Slides สำหรับ C++. ฝัง, ปรับปรุง และส่งออกเนื้อหา OLE อย่างราบรื่น."
---
## **บทนำ**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) เป็นเทคโนโลยีของ Microsoft ที่อนุญาตให้ข้อมูลและวัตถุที่สร้างในแอปพลิเคชันหนึ่งสามารถถูกวางในแอปพลิเคชันอื่นผ่านการเชื่อมโยงหรือการฝังตัวได้.

{{% /alert %}} 

พิจารณากราฟที่สร้างใน MS Excel ซึ่งกราฟนั้นถูกวางไว้ในสไลด์ของ PowerPoint กราฟ Excel นี้ถือเป็นวัตถุ OLE. 

- OLE object อาจปรากฏเป็นไอคอน ในกรณีนี้เมื่อคุณดับเบิลคลิกที่ไอคอนกราฟจะเปิดในแอปพลิเคชันที่เกี่ยวข้อง (Excel) หรือจะมีการถามให้คุณเลือกแอปพลิเคชันสำหรับการเปิดหรือแก้ไขวัตถุ
- OLE object อาจแสดงเนื้อหาจริงของมัน เช่น เนื้อหาของกราฟ ในกรณีนี้กราฟจะทำงานใน PowerPoint ส่วนติดต่อของกราฟจะโหลดขึ้นและคุณสามารถแก้ไขข้อมูลของกราฟภายใน PowerPoint

[Aspose.Slides for C++](https://products.aspose.com/slides/cpp/) ช่วยให้คุณแทรก OLE Objects ลงในสไลด์เป็นกรอบวัตถุ OLE ([OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/)).

## **เพิ่มกรอบวัตถุ OLE ลงในสไลด์**

สมมติว่าคุณได้สร้างกราฟใน Microsoft Excel แล้วต้องการฝังมันลงในสไลด์เป็นกรอบวัตถุ OLE ด้วยการใช้ Aspose.Slides for C++ คุณสามารถทำได้ตามนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 
2. รับการอ้างอิงสไลด์ผ่านดัชนีของมัน.
3. อ่านไฟล์ Excel เป็นอาร์เรย์ไบต์.
4. เพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) ไปยังสไลด์โดยใส่อาร์เรย์ไบต์และข้อมูลอื่น ๆ เกี่ยวกับวัตถุ OLE.
5. เขียนพรีเซนเทชันที่แก้ไขแล้วเป็นไฟล์ PPTX.

ในตัวอย่างด้านล่าง เราได้เพิ่มกราฟจากไฟล์ Excel ลงในสไลด์เป็น [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) โดยใช้ Aspose.Slides for C++ **หมายเหตุ** ว่า คอนสตรัคเตอร์ของ [OleEmbeddedDataInfo](https://reference.aspose.com/slides/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) รับส่วนขยายของวัตถุที่ฝังได้เป็นพารามิเตอร์ที่สอง ส่วนขยายนี้ทำให้ PowerPoint สามารถตีความประเภทไฟล์ได้อย่างถูกต้องและเลือกแอปพลิเคชันที่เหมาะสมเพื่อเปิดวัตถุ OLE นี้.

``` cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <drawing/size_f.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slide(0);

// Prepare data for the OLE object.
auto fileData = File::ReadAllBytes(u"book.xlsx");
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(fileData, u"xlsx");

// Add the OLE object frame to the slide.
slide->get_Shapes()->AddOleObjectFrame(0, 0, slideSize.get_Width(), slideSize.get_Height(), dataInfo);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **เพิ่มกรอบวัตถุ OLE เชื่อมโยง**

Aspose.Slides for C++ อนุญาตให้คุณเพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) โดยไม่ต้องฝังข้อมูล แต่เพียงเชื่อมโยงไปยังไฟล์เท่านั้น.

โค้ด C++ นี้แสดงวิธีการเพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) ที่เชื่อมโยงไฟล์ Excel ไปยังสไลด์:

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// เพิ่มกรอบวัตถุ OLE พร้อมไฟล์ Excel ที่เชื่อมโยง.
slide->get_Shapes()->AddOleObjectFrame(20, 20, 200, 150, u"Excel.Sheet.12", u"book.xlsx");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **เข้าถึงกรอบวัตถุ OLE**

หากวัตถุ OLE ถูกฝังไว้ในสไลด์แล้ว คุณสามารถค้นหาและเข้าถึงได้อย่างง่ายดายโดยทำตามขั้นตอนต่อไปนี้:

1. โหลดพรีเซนเทชันที่มีวัตถุ OLE ฝังอยู่โดยสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 
2. รับการอ้างอิงของสไลด์โดยใช้ดัชนีของมัน. 
3. เข้าถึง shape ของ [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) ในตัวอย่างของเรา เราใช้ PPTX ที่สร้างก่อนหน้านี้ซึ่งมี shape เพียงหนึ่งอันบนสไลด์แรก จากนั้นเราจะ *cast* วัตถุนั้นเป็น [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/). นี้คือกรอบวัตถุ OLE ที่ต้องการเข้าถึง.
4. เมื่อเข้าถึงกรอบวัตถุ OLE แล้ว คุณสามารถดำเนินการใด ๆ กับมันได้.

ในตัวอย่างด้านล่าง เราได้เข้าถึงกรอบวัตถุ OLE (วัตถุกราฟ Excel ที่ฝังในสไลด์) และข้อมูลไฟล์ของมัน.

``` cpp
#include <DOM/IOleEmbeddedDataInfo.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{ 
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // รับข้อมูลไฟล์ที่ฝังไว้.
    auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

    // รับส่วนขยายของไฟล์ที่ฝังไว้.
    auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

    // ...
}
```

### **เข้าถึงคุณสมบัติกรอบวัตถุ OLE ที่เชื่อมโยง**

Aspose.Slides ให้คุณเข้าถึงคุณสมบัติกรอบวัตถุ OLE ที่เชื่อมโยงได้

โค้ด C++ นี้แสดงวิธีตรวจสอบว่าวัตถุ OLE ถูกเชื่อมโยงหรือไม่และจากนั้นรับพาธของไฟล์ที่เชื่อมโยง:

```cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.ppt");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // ตรวจสอบว่าอ็อบเจกต์ OLE เชื่อมโยงหรือไม่.
    if (oleFrame->get_IsObjectLink())
    {
        // พิมพ์พาธเต็มของไฟล์ที่เชื่อมโยง.
        std::wcout << L"OLE object frame is linked to: " << oleFrame->get_LinkPathLong() << std::endl;

        // พิมพ์พาธสัมพัทธ์ของไฟล์ที่เชื่อมโยงหากมี.
        // เฉพาะพรีเซนเทชัน PPT เท่านั้นที่สามารถมีพาธสัมพัทธ์ได้.
        if (!String::IsNullOrEmpty(oleFrame->get_LinkPathRelative()))
        {
            std::wcout << L"OLE object frame relative path: " << oleFrame->get_LinkPathRelative() << std::endl;
        }
    }
}
```

## **เปลี่ยนข้อมูลวัตถุ OLE**

{{% alert color="info" title="Note" %}}

ในส่วนนี้ ตัวอย่างโค้ดด้านล่างใช้ [Aspose.Cells for C++](https://docs.aspose.com/cells/cpp/).

{{% /alert %}}

หากวัตถุ OLE ถูกฝังในสไลด์แล้ว คุณสามารถเข้าถึงวัตถุนั้นและแก้ไขข้อมูลของมันได้อย่างง่ายดายโดยทำตามขั้นตอนต่อไปนี้:

1. โหลดพรีเซนเทชันที่มีวัตถุ OLE ฝังอยู่โดยสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 
2. รับการอ้างอิงของสไลด์ผ่านดัชนีของมัน. 
3. เข้าถึง shape ของ [OLEObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) ในตัวอย่างของเรา เราใช้ PPTX ที่สร้างก่อนหน้านี้ซึ่งมี shape หนึ่งอันบนสไลด์แรก จากนั้นเรา *cast* วัตถุนั้นเป็น [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/). นี้คือกรอบวัตถุ OLE ที่ต้องการเข้าถึง.
4. เมื่อเข้าถึงกรอบวัตถุ OLE แล้ว คุณสามารถดำเนินการใด ๆ กับมันได้.
5. สร้างออบเจ็กต์ `Workbook` และเข้าถึงข้อมูล OLE.
6. เข้าถึง `Worksheet` ที่ต้องการและแก้ไขข้อมูล.
7. บันทึก `Workbook` ที่อัปเดตลงในสตรีม.
8. เปลี่ยนข้อมูลวัตถุ OLE จากสตรีม.

ในตัวอย่างด้านล่าง เราได้เข้าถึงกรอบวัตถุ OLE (วัตถุกราฟ Excel ที่ฝังในสไลด์) และแก้ไขข้อมูลไฟล์ของมันเพื่ออัปเดตข้อมูลกราฟ.

``` cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/OoxmlSaveOptions.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/U16String.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

// Aspose.Cells สำหรับ C++ ต้องเริ่มต้นก่อนจะใช้ประเภทใด ๆ ของมัน.
Aspose::Cells::Startup();

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

// ดึงรูปร่างแรกเป็นกรอบวัตถุ OLE.
auto oleFrame = AsCast<IOleObjectFrame>(slide->get_Shape(0));

if (oleFrame != nullptr)
{
    auto oleStream = MakeObject<MemoryStream>(oleFrame->get_EmbeddedData()->get_EmbeddedFileData());

    // อ่านข้อมูลวัตถุ OLE เป็นอ็อบเจกต์ Workbook.
    auto oleArray = oleStream->ToArray();
    std::vector<uint8_t> workbookData(oleArray->data().begin(), oleArray->data().end());
    Aspose::Cells::Workbook workbook(Aspose::Cells::Vector<uint8_t>(workbookData.data(), workbookData.size()));

    // ปรับแก้ข้อมูล workbook.
    auto worksheet = workbook.GetWorksheets().Get(0);
    worksheet.GetCells().Get(0, 4).PutValue(Aspose::Cells::U16String("E"));
    worksheet.GetCells().Get(1, 4).PutValue(12);
    worksheet.GetCells().Get(2, 4).PutValue(14);
    worksheet.GetCells().Get(3, 4).PutValue(15);

    Aspose::Cells::OoxmlSaveOptions fileOptions(Aspose::Cells::SaveFormat::Xlsx);
    auto newWorkbookData = workbook.Save(fileOptions);

    auto newOleStream = MakeObject<MemoryStream>();
    newOleStream->Write(
        MakeArray<uint8_t>(std::vector<uint8_t>(newWorkbookData.GetData(), newWorkbookData.GetData() + newWorkbookData.GetLength())),
        0, newWorkbookData.GetLength());

    // เปลี่ยนข้อมูลอ็อบเจกต์ของกรอบ OLE.
    auto newData = MakeObject<OleEmbeddedDataInfo>(newOleStream->ToArray(), oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension());
    oleFrame->SetEmbeddedData(newData);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);

Aspose::Cells::Cleanup();
```

## **ฝังไฟล์ประเภทอื่นในสไลด์**

นอกจากกราฟ Excel แล้ว Aspose.Slides for C++ ยังอนุญาตให้คุณฝังไฟล์ประเภทอื่นลงในสไลด์ได้ ตัวอย่างเช่น คุณสามารถแทรกไฟล์ HTML, PDF และ ZIP เป็นวัตถุได้ เมื่อผู้ใช้ดับเบิลคลิกวัตถุที่แทรกไว้ โปรแกรมที่เกี่ยวข้องจะเปิดโดยอัตโนมัติ หรือผู้ใช้จะถูกถามให้เลือกโปรแกรมที่เหมาะสมเพื่อเปิดไฟล์นั้น

โค้ด C++ นี้แสดงวิธีการฝัง HTML และ ZIP ลงในสไลด์:

``` cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto htmlData = File::ReadAllBytes(u"sample.html");
auto htmlDataInfo = MakeObject<OleEmbeddedDataInfo>(htmlData, u"html");
auto htmlOleFrame = slide->get_Shapes()->AddOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame->set_IsObjectIcon(true);

auto zipData = File::ReadAllBytes(u"sample.zip");
auto zipDataInfo = MakeObject<OleEmbeddedDataInfo>(zipData, u"zip");
auto zipOleFrame = slide->get_Shapes()->AddOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **ตั้งประเภทไฟล์สำหรับวัตถุที่ฝัง**

เมื่อทำงานกับพรีเซนเทชัน คุณอาจต้องการแทนที่วัตถุ OLE เก่าด้วยวัตถุใหม่หรือแทนที่วัตถุ OLE ที่ไม่รองรับด้วยวัตถุที่รองรับ Aspose.Slides for C++ ให้คุณตั้งประเภทไฟล์สำหรับวัตถุที่ฝังได้ ซึ่งทำให้คุณสามารถอัปเดตข้อมูลหรือส่วนขยายของกรอบ OLE ได้

โค้ด C++ นี้แสดงวิธีการตั้งประเภทไฟล์สำหรับวัตถุ OLE ที่ฝังเป็น `zip`:

``` cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();
auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

std::wcout << L"Current embedded file extension is: " << fileExtension << std::endl;

// เปลี่ยนประเภทไฟล์เป็น ZIP.
oleFrame->SetEmbeddedData(MakeObject<OleEmbeddedDataInfo>(fileData, u"zip"));

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **ตั้งภาพไอคอนและชื่อเรื่องสำหรับวัตถุที่ฝัง**

หลังจากฝังวัตถุ OLE แล้ว ระบบจะเพิ่มตัวอย่างภาพร่างที่ประกอบด้วยภาพไอคอนโดยอัตโนมัติ ตัวอย่างนี้คือสิ่งที่ผู้ใช้จะเห็นก่อนเข้าถึงหรือเปิดวัตถุ OLE หากคุณต้องการใช้ภาพและข้อความเฉพาะเป็นองค์ประกอบในตัวอย่าง คุณสามารถตั้งค่าภาพไอคอนและชื่อเรื่องโดยใช้ Aspose.Slides for C++

โค้ด C++ นี้แสดงวิธีการตั้งค่าภาพไอคอนและชื่อเรื่องสำหรับวัตถุที่ฝัง: 

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

// เพิ่มรูปภาพไปยังทรัพยากรของพรีเซนเทชัน.
auto imageData = File::ReadAllBytes(u"image.png");
auto oleImage = presentation->get_Images()->AddImage(imageData);

// Set a title and the image for the OLE preview.
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **ป้องกันไม่ให้กรอบวัตถุ OLE ถูกปรับขนาดและย้ายตำแหน่ง**

หลังจากคุณเพิ่มวัตถุ OLE ที่เชื่อมโยงลงในสไลด์พรีเซนเทชัน เมื่อเปิดพรีเซนเทชันใน PowerPoint คุณอาจเห็นข้อความขอให้คุณอัปเดตลิงก์ การคลิกปุ่ม "Update Links" อาจทำให้ขนาดและตำแหน่งของกรอบวัตถุ OLE เปลี่ยนไป เนื่องจาก PowerPoint จะอัปเดตข้อมูลจากวัตถุ OLE ที่เชื่อมโยงและรีเฟรชตัวอย่างของวัตถุ เพื่อป้องกันไม่ให้ PowerPoint ขออัปเดตข้อมูลของวัตถุ ให้เรียกเมธอด [set_UpdateAutomatic](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/set_updateautomatic/) ของอินเทอร์เฟซ [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/) ด้วยค่า `false`:

```cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

oleFrame->set_UpdateAutomatic(false);
```

## **สกัดไฟล์ที่ฝัง**

Aspose.Slides for C++ ให้คุณสกัดไฟล์ที่ฝังอยู่ในสไลด์เป็นวัตถุ OLE ได้โดยทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) ที่มีวัตถุ OLE ที่คุณต้องการสกัด
2. วนลูปผ่านทุก shape ในพรีเซนเทชันและเข้าถึง shape ของ [OLEObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/)
3. เข้าถึงข้อมูลของไฟล์ที่ฝังจากกรอบวัตถุ OLE และเขียนลงดิสก์

โค้ด C++ นี้แสดงวิธีสกัดไฟล์ที่ฝังในสไลด์เป็นวัตถุ OLE:

``` cpp
#include <DOM/IOleEmbeddedDataInfo.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (int index = 0; index < slide->get_Shapes()->get_Count(); index++)
{
    auto shape = slide->get_Shape(index);

    if (ObjectExt::Is<IOleObjectFrame>(shape))
    { 
        auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

        auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();
        auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

        auto fileName = String::Format(u"OLE_object_{0}{1}", index, fileExtension);
        File::WriteAllBytes(fileName, fileData);
    }
}

presentation->Dispose();
```

## **FAQ**

**เนื้อหา OLE จะถูกเรนเดอร์เมื่อส่งออกสไลด์เป็น PDF/รูปภาพหรือไม่?**

สิ่งที่มองเห็นบนสไลด์คือที่ถูกเรนเดอร์—ไอคอน/ภาพทดแทน (preview) เนื้อหา OLE แบบ “สด” จะไม่ได้รับการประมวลผลระหว่างการเรนเดอร์ หากต้องการ สามารถตั้งค่าภาพตัวอย่างของคุณเองเพื่อให้ได้ลักษณะที่ต้องการใน PDF ที่ส่งออก

เพื่อรักษาไฟล์ที่ฝังเป็นไฟล์แนบ PDF ด้วย ให้เรียก [PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/) ด้วยค่า `true` ตัวเลือกนี้ปิดอยู่เป็นค่าเริ่มต้น สำหรับตัวอย่างและวิธีตรวจสอบไฟล์แนบ ดูที่ [Preserve Embedded OLE Files as PDF Attachments](/slides/th/cpp/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**ฉันจะล็อควัตถุ OLE บนสไลด์เพื่อให้ผู้ใช้ไม่สามารถย้าย/แก้ไขได้ใน PowerPoint อย่างไร?**

ล็อค shape: Aspose.Slides มี [shape-level locks](/slides/th/cpp/applying-protection-to-presentation/) ซึ่งไม่ใช่การเข้ารหัส แต่ช่วยป้องกันการแก้ไขและการย้ายโดยไม่ได้ตั้งใจอย่างมีประสิทธิภาพ.

**ทำไมวัตถุ Excel ที่เชื่อมโยงถึง “กระโดด” หรือเปลี่ยนขนาดเมื่อฉันเปิดพรีเซนเทชัน?**

PowerPoint อาจรีเฟรช preview ของ OLE ที่เชื่อมโยง เพื่อให้แสดงผลคงที่ ให้ปฏิบัติตามแนวทางของ [Working Solution for Worksheet Resizing](/slides/th/cpp/working-solution-for-worksheet-resizing/) — คือปรับกรอบให้พอดีกับช่วง หรือสเกลช่วงให้เข้ากับกรอบคงที่และตั้งค่าภาพทดแทนที่เหมาะสม.

**เส้นทางสัมพัทธ์ของวัตถุ OLE ที่เชื่อมโยงจะถูกเก็บไว้ในรูปแบบ PPTX หรือไม่?**

ใน PPTX ข้อมูล "relative path" ไม่พร้อมใช้งาน—มีเฉพาะเส้นทางเต็มเท่านั้น เส้นทางสัมพัทธ์พบได้ในรูปแบบ PPT เก่า สำหรับการพกพา ควรใช้เส้นทางเต็มที่เชื่อถือได้/URI ที่เข้าถึงได้หรือการฝังไฟล์.