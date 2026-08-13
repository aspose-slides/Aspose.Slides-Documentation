---
title: จัดการ OLE ในการนำเสนอโดยใช้ C++
linktitle: จัดการ OLE
type: docs
weight: 40
url: /th/cpp/manage-ole/
keywords:
- วัตถุ OLE
- การเชื่อมโยงและฝังอ็อบเจ็กต์
- เพิ่ม OLE
- ฝัง OLE
- เพิ่มอ็อบเจ็กต์
- ฝังอ็อบเจ็กต์
- เพิ่มไฟล์
- ฝังไฟล์
- อ็อบเจ็กต์ที่เชื่อมโยง
- ไฟล์ที่เชื่อมโยง
- เปลี่ยนแปลง OLE
- ไอคอน OLE
- ชื่อ OLE
- สกัด OLE
- สกัดอ็อบเจ็กต์
- สกัดไฟล์
- PowerPoint
- การนำเสนอ
- C++
- Aspose.Slides
description: "เพิ่มประสิทธิภาพการจัดการวัตถุ OLE ในไฟล์ PowerPoint และ OpenDocument ด้วย Aspose.Slides for C++. ฝัง, อัปเดตและส่งออกเนื้อหา OLE อย่างราบรื่น."
---
## **บทนำ**

{{% alert title="Info" color="info" %}}

OLE (Object Linking & Embedding) เป็นเทคโนโลยีของ Microsoft ที่ช่วยให้ข้อมูลและอ็อบเจ็กต์ที่สร้างในแอปพลิเคชันหนึ่งสามารถวางในแอปพลิเคชันอื่นได้ผ่านการลิงก์หรือการฝัง

{{% /alert %}} 

พิจารณาชาร์ตที่สร้างใน MS Excel แล้วนำชาร์ตนั้นไปวางภายในสไลด์ PowerPoint ชาร์ต Excel นี้ถือเป็นอ็อบเจ็กต์ OLE

- อ็อบเจ็กต์ OLE อาจปรากฏเป็นไอคอน ในกรณีนี้เมื่อคุณคลิกสองครั้งที่ไอคอน ชาร์ตจะถูกเปิดในแอปพลิเคชันที่เกี่ยวข้อง (Excel) หรือระบบจะขอให้คุณเลือกแอปพลิเคชันสำหรับเปิดหรือแก้ไขอ็อบเจ็กต์
- อ็อบเจ็กต์ OLE อาจแสดงเนื้อหาจริง เช่น เนื้อหาของชาร์ต ในกรณีนี้ชาร์ตจะทำงานใน PowerPoint อินเตอร์เฟซของชาร์ตจะโหลดและคุณสามารถแก้ไขข้อมูลของชาร์ตภายใน PowerPoint ได้

[Aspose.Slides for C++](https://products.aspose.com/slides/th/cpp/) อนุญาตให้คุณแทรกอ็อบเจ็กต์ OLE ลงในสไลด์ในรูปแบบเฟรมอ็อบเจ็กต์ OLE ([OleObjectFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/oleobjectframe/))

## **เพิ่มเฟรมอ็อบเจ็กต์ OLE ลงในสไลด์**

สมมติว่าคุณได้สร้างชาร์ตใน Microsoft Excel แล้วต้องการฝังลงในสไลด์เป็นเฟรมอ็อบเจ็กต์ OLE โดยใช้ Aspose.Slides for C++ คุณสามารถทำได้ดังนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation)
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน
3. อ่านไฟล์ Excel เป็นอาเรย์ไบต์
4. เพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/oleobjectframe/) ลงในสไลด์โดยใส่อาเรย์ไบต์และข้อมูลอื่น ๆ ของอ็อบเจ็กต์ OLE
5. เขียนการนำเสนอที่แก้ไขแล้วออกเป็นไฟล์ PPTX

ในตัวอย่างด้านล่าง เราได้เพิ่มชาร์ตจากไฟล์ Excel ลงในสไลด์เป็น [OleObjectFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/oleobjectframe/) ด้วย Aspose.Slides for C++  
**หมายเหตุ** ว่า constructor ของ [OleEmbeddedDataInfo](https://reference.aspose.com/slides/th/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) รับส่วนขยายของอ็อบเจ็กต์ที่สามารถฝังได้เป็นพารามิเตอร์ที่สอง ส่วนขยายนี้ทำให้ PowerPoint สามารถตีความชนิดไฟล์ได้อย่างถูกต้องและเลือกแอปพลิเคชันที่เหมาะสมเพื่อเปิดอ็อบเจ็กต์ OLE นี้

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

// เตรียมข้อมูลสำหรับอ็อบเจ็กต์ OLE.
auto fileData = File::ReadAllBytes(u"book.xlsx");
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(fileData, u"xlsx");

// เพิ่มเฟรมอ็อบเจ็กต์ OLE ลงในสไลด์.
slide->get_Shapes()->AddOleObjectFrame(0, 0, slideSize.get_Width(), slideSize.get_Height(), dataInfo);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **เพิ่มเฟรมอ็อบเจ็กต์ OLE ที่เชื่อมโยง**

Aspose.Slides for C++ อนุญาตให้คุณเพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/oleobjectframe/) โดยไม่ได้ฝังข้อมูล แค่เชื่อมโยงไปที่ไฟล์เท่านั้น

โค้ด C++ นี้แสดงวิธีการเพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/oleobjectframe/) ที่เชื่อมโยงไฟล์ Excel ไปยังสไลด์:

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

// เพิ่มเฟรมอ็อบเจ็กต์ OLE พร้อมไฟล์ Excel ที่เชื่อมโยง.
slide->get_Shapes()->AddOleObjectFrame(20, 20, 200, 150, u"Excel.Sheet.12", u"book.xlsx");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **เข้าถึงเฟรมอ็อบเจ็กต์ OLE**

หากอ็อบเจ็กต์ OLE ถูกฝังไว้ในสไลด์แล้ว คุณสามารถค้นหา หรือเข้าถึงได้ง่ายดังนี้:

1. โหลดการนำเสนอที่มีอ็อบเจ็กต์ OLE ฝังอยู่โดยสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation)
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน
3. เข้าถึง shape ของ [OleObjectFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/oleobjectframe/)  
   ในตัวอย่างของเรา เราใช้ PPTX ที่สร้างไว้ก่อนหน้านี้ซึ่งมี shape เพียงหนึ่งอันบนสไลด์แรก แล้ว *cast* อ็อบเจ็กต์นั้นเป็น [IOleObjectFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/ioleobjectframe/) ซึ่งเป็นเฟรมอ็อบเจ็กต์ OLE ที่ต้องการเข้าถึง
4. เมื่อเข้าถึงเฟรมอ็อบเจ็กต์ OLE แล้ว คุณสามารถทำการดำเนินการใด ๆ กับมันได้

ในตัวอย่างด้านล่าง จะเข้าถึงเฟรมอ็อบเจ็กต์ OLE (อ็อบเจ็กต์ชาร์ต Excel ที่ฝังอยู่ในสไลด์) และข้อมูลไฟล์ของมัน

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

### **เข้าถึงคุณสมบัติของเฟรมอ็อบเจ็กต์ OLE ที่เชื่อมโยง**

Aspose.Slides อนุญาตให้คุณเข้าถึงคุณสมบัติของเฟรมอ็อบเจ็กต์ OLE ที่เชื่อมโยง

โค้ด C++ นี้แสดงวิธีตรวจสอบว่าอ็อบเจ็กต์ OLE ถูกเชื่อมโยงหรือไม่และจากนั้นได้รับเส้นทางของไฟล์ที่เชื่อมโยง:

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

    // ตรวจสอบว่าอ็อบเจ็กต์ OLE ถูกลิงก์หรือไม่.
    if (oleFrame->get_IsObjectLink())
    {
        // แสดงเส้นทางเต็มของไฟล์ที่เชื่อมโยง.
        std::wcout << L"OLE object frame is linked to: " << oleFrame->get_LinkPathLong() << std::endl;

        // แสดงเส้นทางสัมพันธ์ของไฟล์ที่เชื่อมโยงหากมี.
        // เพียงไฟล์นำเสนอ PPT เท่านั้นที่สามารถมีเส้นทางสัมพันธ์ได้.
        if (!String::IsNullOrEmpty(oleFrame->get_LinkPathRelative()))
        {
            std::wcout << L"OLE object frame relative path: " << oleFrame->get_LinkPathRelative() << std::endl;
        }
    }
}
```

## **เปลี่ยนแปลงข้อมูลอ็อบเจ็กต์ OLE**

{{% alert color="info" %}} 

ในส่วนนี้ ตัวอย่างโค้ดด้านล่างใช้ [Aspose.Cells for C++](/cells/cpp/)

{{% /alert %}}

หากอ็อบเจ็กต์ OLE ถูกฝังไว้ในสไลด์แล้ว คุณสามารถเข้าถึงอ็อบเจ็กต์นั้นและแก้ไขข้อมูลของมันได้ดังนี้:

1. โหลดการนำเสนอที่มีอ็อบเจ็กต์ OLE ฝังอยู่โดยสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation)
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน
3. เข้าถึง shape ของ [OLEObjectFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/oleobjectframe/)  
   ในตัวอย่างของเรา เราใช้ PPTX ที่สร้างไว้ก่อนหน้านี้ซึ่งมี shape หนึ่งอันบนสไลด์แรก แล้ว *cast* อ็อบเจ็กต์นั้นเป็น [IOleObjectFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/ioleobjectframe/) ซึ่งเป็นเฟรมอ็อบเจ็กต์ OLE ที่ต้องการเข้าถึง
4. เมื่อเข้าถึงเฟรมอ็อบเจ็กต์ OLE แล้ว คุณสามารถทำการดำเนินการใด ๆ กับมันได้
5. สร้างอ็อบเจ็กต์ `Workbook` และเข้าถึงข้อมูล OLE
6. เข้าถึง `Worksheet` ที่ต้องการแล้วแก้ไขข้อมูล
7. บันทึก `Workbook` ที่อัปเดตลงในสตรีม
8. เปลี่ยนแปลงข้อมูลอ็อบเจ็กต์ OLE จากสตรีม

ในตัวอย่างด้านล่าง จะเข้าถึงเฟรมอ็อบเจ็กต์ OLE (อ็อบเจ็กต์ชาร์ต Excel ที่ฝังในสไลด์) และแก้ไขข้อมูลไฟล์ของมันเพื่ออัปเดตข้อมูลของชาร์ต

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

// Aspose.Cells for C++ ต้องเริ่มต้นก่อนที่จะใช้ประเภทใด ๆ ของมัน.
Aspose::Cells::Startup();

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

// ดึง shape แรกเป็นเฟรมอ็อบเจ็กต์ OLE.
auto oleFrame = AsCast<IOleObjectFrame>(slide->get_Shape(0));

if (oleFrame != nullptr)
{
    auto oleStream = MakeObject<MemoryStream>(oleFrame->get_EmbeddedData()->get_EmbeddedFileData());

    // อ่านข้อมูลอ็อบเจ็กต์ OLE เป็นอ็อบเจ็กต์ Workbook.
    auto oleArray = oleStream->ToArray();
    std::vector<uint8_t> workbookData(oleArray->data().begin(), oleArray->data().end());
    Aspose::Cells::Workbook workbook(Aspose::Cells::Vector<uint8_t>(workbookData.data(), workbookData.size()));

    // แก้ไขข้อมูล workbook.
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

    // เปลี่ยนข้อมูลอ็อบเจ็กต์เฟรม OLE.
    auto newData = MakeObject<OleEmbeddedDataInfo>(newOleStream->ToArray(), oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension());
    oleFrame->SetEmbeddedData(newData);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);

Aspose::Cells::Cleanup();
```

## **ฝังไฟล์ประเภทอื่นลงในสไลด์**

นอกจากชาร์ต Excel แล้ว Aspose.Slides for C++ ยังอนุญาตให้คุณฝังไฟล์ประเภทอื่นลงในสไลด์ได้ เช่น สามารถแทรกไฟล์ HTML, PDF และ ZIP เป็นอ็อบเจ็กต์ เมื่อผู้ใช้คลิกสองครั้งที่อ็อบเจ็กต์ที่แทรกไว้ มันจะเปิดโดยอัตโนมัติในโปรแกรมที่เกี่ยวข้อง หรือระบบจะขอให้ผู้ใช้เลือกโปรแกรมที่เหมาะสมเพื่อเปิดไฟล์

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

## **กำหนดประเภทไฟล์สำหรับอ็อบเจ็กต์ที่ฝัง**

เมื่อต้องทำงานกับการนำเสนอ คุณอาจต้องการแทนที่อ็อบเจ็กต์ OLE เก่าด้วยอ็อบเจ็กต์ใหม่ หรือแทนที่อ็อบเจ็กต์ OLE ที่ไม่รองรับด้วยอ็อบเจ็กต์ที่รองรับ Aspose.Slides for C++ อนุญาตให้คุณกำหนดประเภทไฟล์สำหรับอ็อบเจ็กต์ที่ฝังไว้ ทำให้คุณสามารถอัปเดตข้อมูลเฟรม OLE หรือส่วนขยายของมันได้

โค้ด C++ นี้แสดงวิธีการกำหนดประเภทไฟล์สำหรับอ็อบเจ็กต์ OLE ที่ฝังเป็น `zip`:

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

## **ตั้งค่าไอคอนและหัวข้อสำหรับอ็อบเจ็กต์ที่ฝัง**

หลังจากฝังอ็อบเจ็กต์ OLE แล้ว พรีวิวที่ประกอบด้วยภาพไอคอนจะถูกเพิ่มโดยอัตโนมัติ พรีวิวนี้เป็นสิ่งที่ผู้ใช้เห็นก่อนเข้าถึงหรือเปิดอ็อบเจ็กต์ OLE หากคุณต้องการใช้ภาพและข้อความเฉพาะเป็นส่วนประกอบของพรีวิว คุณสามารถตั้งค่าภาพไอคอนและหัวข้อโดยใช้ Aspose.Slides for C++

โค้ด C++ นี้แสดงวิธีตั้งค่าภาพไอคอนและหัวข้อสำหรับอ็อบเจ็กต์ที่ฝัง:

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

// เพิ่มรูปภาพไปยังทรัพยากรของการนำเสนอ.
auto imageData = File::ReadAllBytes(u"image.png");
auto oleImage = presentation->get_Images()->AddImage(imageData);

// ตั้งชื่อเรื่องและรูปภาพสำหรับพรีวิว OLE.
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **ป้องกันไม่ให้เฟรมอ็อบเจ็กต์ OLE ถูกปรับขนาดและย้ายตำแหน่ง**

หลังจากคุณเพิ่มอ็อบเจ็กต์ OLE ที่เชื่อมโยงลงในสไลด์การนำเสนอ เมื่อเปิดการนำเสนอใน PowerPoint คุณอาจเห็นข้อความแจ้งให้คุณอัปเดตลิงก์ การคลิกปุ่ม "Update Links" อาจทำให้ขนาดและตำแหน่งของเฟรมอ็อบเจ็กต์ OLE เปลี่ยนแปลง เนื่องจาก PowerPoint จะอัปเดตข้อมูลจากอ็อบเจ็กต์ OLE ที่เชื่อมโยงและรีเฟรชพรีวิวของอ็อบเจ็กต์ เพื่อป้องกันไม่ให้ PowerPoint ขออัปเดตข้อมูลของอ็อบเจ็กต์ ให้ตั้งค่าเมธอด `set_UpdateAutomatic` ของอินเทอร์เฟซ [IOleObjectFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/ioleobjectframe/) เป็น `false`:

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

## **สกัดไฟล์ที่ฝังคไว้**

Aspose.Slides for C++ อนุญาตให้คุณสกัดไฟล์ที่ฝังอยู่ในสไลด์เป็นอ็อบเจ็กต์ OLE ได้ดังนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation) ที่มีอ็อบเจ็กต์ OLE ที่คุณต้องการสกัด
2. วนลูปผ่าน shape ทั้งหมดในการนำเสนอและเข้าถึง shape ของ [OLEObjectFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/oleobjectframe/)
3. เข้าถึงข้อมูลของไฟล์ที่ฝังจากเฟรมอ็อบเจ็กต์ OLE แล้วเขียนลงดิสก์

โค้ด C++ นี้แสดงวิธีสกัดไฟล์ที่ฝังอยู่ในสไลด์เป็นอ็อบเจ็กต์ OLE:

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

### เนื้อหา OLE จะถูกเรนเดอร์เมื่อส่งออกสไลด์เป็น PDF/รูปภาพหรือไม่?

สิ่งที่มองเห็นบนสไลด์จะถูกเรนเดอร์คือไอคอน/ภาพแทน (พรีวิว) เนื้อหา OLE แบบ "live" จะไม่ทำงานระหว่างการเรนเดอร์ หากต้องการ ให้ตั้งค่าภาพพรีวิวของคุณเองเพื่อให้ได้ลักษณะที่ต้องการใน PDF ที่ส่งออก

### จะล็อคอ็อบเจ็กต์ OLE บนสไลด์เพื่อไม่ให้ผู้ใช้ย้าย/แก้ไขได้อย่างไรใน PowerPoint?

ล็อค shape: Aspose.Slides มี [shape-level locks](/slides/th/cpp/applying-protection-to-presentation/) นี่ไม่ใช่การเข้ารหัส แต่ช่วยป้องกันการแก้ไขหรือการย้ายโดยไม่ได้ตั้งใจ

### ทำไมอ็อบเจ็กต์ Excel ที่เชื่อมโยง "กระโดด" หรือเปลี่ยนขนาดเมื่อเปิดการนำเสนอ?

PowerPoint อาจรีเฟรชพรีวิวของ OLE ที่เชื่อมโยง เพื่อให้รูปแบบคงที่ ให้ปฏิบัติตามวิธีการ [Working Solution for Worksheet Resizing](/slides/th/cpp/working-solution-for-worksheet-resizing/) — หรือปรับเฟรมให้พอดีกับช่วงข้อมูล หรือสเกลช่วงเป็นเฟรมคงที่และตั้งภาพแทนที่เหมาะสม

### เส้นทางสัมพันธ์ของอ็อบเจ็กต์ OLE ที่เชื่อมโยงจะถูกเก็บไว้ในรูปแบบ PPTX หรือไม่?

ใน PPTX ไม่มีข้อมูล "เส้นทางสัมพันธ์" — มีเพียงเส้นทางเต็มเท่านั้น เส้นทางสัมพันธ์พบได้ในรูปแบบ PPT เก่า สำหรับการพกพาแนะนำให้ใช้เส้นทางเต็มที่เชื่อถือได้/URI ที่เข้าถึงได้ หรือฝังไฟล์