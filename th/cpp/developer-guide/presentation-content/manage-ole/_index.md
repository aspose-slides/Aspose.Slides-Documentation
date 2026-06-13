---
title: จัดการ OLE ในงานนำเสนอโดยใช้ C++
linktitle: จัดการ OLE
type: docs
weight: 40
url: /th/cpp/manage-ole/
keywords:
- อ็อบเจ็กต์ OLE
- การเชื่อมโยงและฝังอ็อบเจ็กต์
- เพิ่ม OLE
- ฝัง OLE
- เพิ่มอ็อบเจ็กต์
- ฝังอ็อบเจ็กต์
- เพิ่มไฟล์
- ฝังไฟล์
- อ็อบเจ็กต์ที่เชื่อมโยง
- ไฟล์ที่เชื่อมโยง
- เปลี่ยน OLE
- ไอคอน OLE
- หัวข้อ OLE
- สกัด OLE
- สกัดอ็อบเจ็กต์
- สกัดไฟล์
- PowerPoint
- งานนำเสนอ
- C++
- Aspose.Slides
description: "เพิ่มประสิทธิภาพการจัดการอ็อบเจ็กต์ OLE ในไฟล์ PowerPoint และ OpenDocument ด้วย Aspose.Slides for C++. ฝัง, อัปเดต, และส่งออกเนื้อหา OLE อย่างราบรื่น"
---
## **บทนำ**

{{% alert title="Info" color="info" %}}
OLE (Object Linking & Embedding) เป็นเทคโนโลยีของ Microsoft ที่อนุญาตให้ข้อมูลและอ็อบเจ็กต์ที่สร้างในแอปพลิเคชันหนึ่งสามารถวางในแอปพลิเคชันอื่นผ่านการเชื่อมโยงหรือการฝัง  
{{% /alert %}}

ให้พิจารณากราฟที่สร้างใน MS Excel กราฟนั้นถูกวางไว้ในสไลด์ PowerPoint และกราฟ Excel นี้ถือเป็นอ็อบเจ็กต์ OLE

- OLE object อาจปรากฏเป็นไอคอน ในกรณีนี้เมื่อคุณดับเบิล‑คลิกไอคอนกราฟจะเปิดในแอปพลิเคชันที่เกี่ยวข้อง (Excel) หรือระบบจะถามคุณให้เลือกแอปพลิเคชันสำหรับการเปิดหรือแก้ไขอ็อบเจ็กต์  
- OLE object อาจแสดงเนื้อหาจริง เช่น เนื้อหาของกราฟ ในกรณีนี้กราฟจะทำงานใน PowerPoint อินเทอร์เฟซของกราฟจะโหลดและคุณสามารถแก้ไขข้อมูลของกราฟภายใน PowerPoint ได้  

[Aspose.Slides for C++](https://products.aspose.com/slides/th/cpp/) ช่วยให้คุณแทรก OLE Objects ลงในสไลด์เป็นกรอบอ็อบเจ็กต์ OLE ([OleObjectFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/oleobjectframe/))

## **เพิ่มกรอบอ็อบเจ็กต์ OLE ลงในสไลด์**

สมมติว่าคุณได้สร้างกราฟใน Microsoft Excel แล้วต้องการฝังลงในสไลด์เป็นกรอบอ็อบเจ็กต์ OLE ด้วย Aspose.Slides for C++ คุณสามารถทำได้โดยวิธีนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation)  
2. รับการอ้างอิงของสไลด์ผ่านตำแหน่ง (index) ของมัน  
3. อ่านไฟล์ Excel เป็นอาร์เรย์ไบต์  
4. เพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/oleobjectframe/) ลงในสไลด์โดยใส่อาร์เรย์ไบต์และข้อมูลอื่น ๆ ของอ็อบเจ็กต์ OLE  
5. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

ในตัวอย่างด้านล่าง เราได้เพิ่มกราฟจากไฟล์ Excel ไปยังสไลด์เป็น [OleObjectFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/oleobjectframe/) ด้วย Aspose.Slides for C++ **หมายเหตุ** ว่า คอนสตรัคเตอร์ของ [OleEmbeddedDataInfo](https://reference.aspose.com/slides/th/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) รับส่วนขยายของอ็อบเจ็กต์ที่ฝังได้เป็นพารามิเตอร์ที่สอง ส่วนขยายนี้ช่วยให้ PowerPoint สามารถตีความประเภทไฟล์ได้อย่างถูกต้องและเลือกแอปพลิเคชันที่เหมาะสมเพื่อเปิดอ็อบเจ็กต์ OLE นี้  
``` cpp
auto presentation = MakeObject<Presentation>();
auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slide(0);

// เตรียมข้อมูลสำหรับอ็อบเจ็กต์ OLE.
auto fileData = File::ReadAllBytes(u"book.xlsx");
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(fileData, u"xlsx");

// เพิ่มกรอบอ็อบเจ็กต์ OLE ลงในสไลด์.
slide->get_Shapes()->AddOleObjectFrame(0, 0, slideSize.get_Width(), slideSize.get_Height(), dataInfo);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **เพิ่มกรอบอ็อบเจ็กต์ OLE ที่เชื่อมโยง**

Aspose.Slides for C++ อนุญาตให้คุณเพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/oleobjectframe/) โดยไม่ฝังข้อมูล แต่เพียงแค่เชื่อมโยงไปยังไฟล์เท่านั้น  

โค้ด C++ นี้แสดงวิธีเพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/oleobjectframe/) ที่เชื่อมโยงไฟล์ Excel ไปยังสไลด์:  
```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// เพิ่มกรอบอ็อบเจ็กต์ OLE พร้อมไฟล์ Excel ที่เชื่อมโยง.
slide->get_Shapes()->AddOleObjectFrame(20, 20, 200, 150, u"Excel.Sheet.12", u"book.xlsx");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **เข้าถึงกรอบอ็อบเจ็กต์ OLE**

หากอ็อบเจ็กต์ OLE ถูกฝังอยู่ในสไลด์แล้ว คุณสามารถค้นหาและเข้าถึงได้อย่างง่ายดายโดยทำตามขั้นตอนต่อไปนี้:

1. โหลดงานนำเสนอที่มีอ็อบเจ็กต์ OLE ฝังอยู่โดยสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation)  
2. รับการอ้างอิงของสไลด์โดยใช้ตำแหน่ง (index) ของมัน  
3. เข้าถึงรูปทรง [OleObjectFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/oleobjectframe/)  
   ในตัวอย่างของเรา เราใช้ PPTX ที่สร้างไว้ก่อนหน้านี้ซึ่งมีรูปทรงเพียงอันเดียวบนสไลด์แรก จากนั้น *cast* อ็อบเจ็กต์นั้นเป็น [IOleObjectFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/ioleobjectframe/) ซึ่งเป็นกรอบ OLE ที่ต้องการเข้าถึง  
4. เมื่อเข้าถึงกรอบอ็อบเจ็กต์ OLE แล้ว คุณสามารถดำเนินการใด ๆ กับมันได้  

ในตัวอย่างด้านล่าง เราเข้าถึงกรอบอ็อบเจ็กต์ OLE (อ็อบเจ็กต์กราฟ Excel ที่ฝังในสไลด์) และข้อมูลไฟล์ของมัน  
``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{ 
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // รับข้อมูลไฟล์ที่ฝังไว้.
    // รับส่วนขยายของไฟล์ที่ฝังไว้.
    // ...
}
```

### **เข้าถึงคุณสมบัติของกรอบอ็อบเจ็กต์ OLE ที่เชื่อมโยง**

Aspose.Slides ให้คุณเข้าถึงคุณสมบัติของกรอบอ็อบเจ็กต์ OLE ที่เชื่อมโยง  

โค้ด C++ นี้แสดงวิธีตรวจสอบว่าอ็อบเจ็กต์ OLE ถูกเชื่อมโยงหรือไม่และจากนั้นรับพาธของไฟล์ที่เชื่อมโยง:  
```cpp
auto presentation = MakeObject<Presentation>(u"sample.ppt");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // ตรวจสอบว่าอ็อบเจ็กต์ OLE ถูกเชื่อมโยงหรือไม่.
    if (oleFrame->get_IsObjectLink())
    {
        // พิมพ์พาธเต็มของไฟล์ที่เชื่อมโยง.
        std::wcout << L"OLE object frame is linked to: " << oleFrame->get_LinkPathLong() << std::endl;

        // พิมพ์พาธสัมพัทธ์ของไฟล์ที่เชื่อมโยงหากมี.
        // เฉพาะงานนำเสนอ PPT เท่านั้นที่สามารถมีพาธสัมพัทธ์ได้.
        if (!String::IsNullOrEmpty(oleFrame->get_LinkPathRelative()))
        {
            std::wcout << L"OLE object frame relative path: " << oleFrame->get_LinkPathRelative() << std::endl;
        }
    }
}
```

## **เปลี่ยนข้อมูลอ็อบเจ็กต์ OLE**

{{% alert color="primary" %}}  
ในส่วนนี้ ตัวอย่างโค้ดด้านล่างใช้ [Aspose.Cells for C++](/cells/cpp/).  
{{% /alert %}}

หากอ็อบเจ็กต์ OLE ได้ถูกฝังอยู่ในสไลด์แล้ว คุณสามารถเข้าถึงอ็อบเจ็กต์นั้นและแก้ไขข้อมูลของมันได้โดยทำตามขั้นตอนต่อไปนี้:

1. โหลดงานนำเสนอที่มีอ็อบเจ็กต์ OLE ฝังอยู่โดยสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation)  
2. รับการอ้างอิงของสไลด์ผ่านตำแหน่ง (index) ของมัน  
3. เข้าถึงรูปทรง [OLEObjectFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/oleobjectframe/)  
   ในตัวอย่างของเรา เราใช้ PPTX ที่มีรูปทรงหนึ่งอันบนสไลด์แรก จากนั้น *cast* อ็อบเจ็กต์นั้นเป็น [IOleObjectFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/ioleobjectframe/) ซึ่งเป็นกรอบ OLE ที่ต้องการเข้าถึง  
4. เมื่อเข้าถึงกรอบอ็อบเจ็กต์ OLE แล้ว คุณสามารถดำเนินการใด ๆ กับมันได้  
5. สร้างอ็อบเจ็กต์ `Workbook` และเข้าถึงข้อมูล OLE  
6. เข้าถึง `Worksheet` ที่ต้องการและแก้ไขข้อมูล  
7. บันทึก `Workbook` ที่อัปเดตไว้ในสตรีม  
8. เปลี่ยนข้อมูลอ็อบเจ็กต์ OLE จากสตรีม  

ในตัวอย่างด้านล่าง เราเข้าถึงกรอบอ็อบเจ็กต์ OLE (อ็อบเจ็กต์กราฟ Excel ที่ฝังในสไลด์) และแก้ไขข้อมูลไฟล์ของมันเพื่ออัปเดตข้อมูลกราฟ  
``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

// รับรูปทรงแรกเป็นกรอบอ็อบเจ็กต์ OLE.
auto oleFrame = AsCast<IOleObjectFrame>(slide->get_Shape(0));

if (oleFrame != nullptr)
{
    auto oleStream = MakeObject<MemoryStream>(oleFrame->get_EmbeddedData()->get_EmbeddedFileData());

    // อ่านข้อมูลอ็อบเจ็กต์ OLE เป็นอ็อบเจ็กต์ Workbook.
    auto oleArray = oleStream->ToArray();
    std::vector<uint8_t> workbookData(oleArray->data().begin(), oleArray->data().end());
    Aspose::Cells::Workbook workbook(Aspose::Cells::Vector<uint8_t>(workbookData.data(), workbookData.size()));

    // แก้ไขข้อมูล Workbook.
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

    // เปลี่ยนข้อมูลอ็อบเจ็กต์กรอบ OLE.
    auto newData = MakeObject<OleEmbeddedDataInfo>(newOleStream->ToArray(), oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension());
    oleFrame->SetEmbeddedData(newData);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **ฝังประเภทไฟล์อื่นลงในสไลด์**

นอกจากกราฟ Excel แล้ว Aspose.Slides for C++ ยังอนุญาตให้คุณฝังไฟล์ประเภทอื่นลงในสไลด์ได้ เช่น HTML, PDF และ ZIP เมื่อผู้ใช้ดับเบิล‑คลิกอ็อบเจ็กต์ที่แทรกเข้าไป มันจะเปิดอัตโนมัติในโปรแกรมที่เกี่ยวข้อง หรือระบบจะถามให้ผู้ใช้เลือกโปรแกรมที่เหมาะสมเพื่อเปิดไฟล์  

โค้ด C++ นี้แสดงวิธีฝัง HTML และ ZIP ลงในสไลด์:  
``` cpp
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

## **ตั้งค่าประเภทไฟล์สำหรับอ็อบเจ็กต์ที่ฝังอยู่**

เมื่อทำงานกับงานนำเสนอ คุณอาจต้องการแทนที่อ็อบเจ็กต์ OLE เก่าใหม่หรือแทนที่อ็อบเจ็กต์ OLE ที่ไม่รองรับด้วยอ็อบเจ็กต์ที่รองรับ Aspose.Slides for C++ ให้คุณตั้งค่าประเภทไฟล์สำหรับอ็อบเจ็กต์ที่ฝังอยู่ เพื่อให้คุณสามารถอัปเดตข้อมูลกรอบ OLE หรือส่วนขยายของไฟล์ได้  

โค้ด C++ นี้แสดงวิธีตั้งค่าประเภทไฟล์สำหรับอ็อบเจ็กต์ OLE ที่ฝังอยู่เป็น `zip`:  
``` cpp
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

## **ตั้งค่าภาพไอคอนและหัวข้อสำหรับอ็อบเจ็กต์ที่ฝังอยู่**

หลังจากฝังอ็อบเจ็กต์ OLE แล้ว ระบบจะเพิ่มตัวอย่างที่ประกอบด้วยรูปภาพไอคอนโดยอัตโนมัติ ตัวอย่างนี้คือสิ่งที่ผู้ใช้เห็นก่อนเข้าถึงหรือเปิดอ็อบเจ็กต์ OLE หากคุณต้องการใช้รูปภาพและข้อความเฉพาะเป็นส่วนประกอบของตัวอย่าง คุณสามารถตั้งค่าภาพไอคอนและหัวข้อได้ด้วย Aspose.Slides for C++  

โค้ด C++ นี้แสดงวิธีตั้งค่าภาพไอคอนและหัวข้อสำหรับอ็อบเจ็กต์ที่ฝังอยู่:  
``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

// เพิ่มรูปภาพไปยังทรัพยากรของงานนำเสนอ.
auto imageData = File::ReadAllBytes(u"image.png");
auto oleImage = presentation->get_Images()->AddImage(imageData);

// ตั้งค่าชื่อเรื่องและรูปภาพสำหรับการแสดงตัวอย่าง OLE.
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **ป้องกันไม่ให้กรอบอ็อบเจ็กต์ OLE ถูกปรับขนาดและกำหนดตำแหน่งใหม่**

หลังจากคุณเพิ่มอ็อบเจ็กต์ OLE ที่เชื่อมโยงลงในสไลด์ของงานนำเสนอ เมื่อเปิดงานนำเสนอใน PowerPoint คุณอาจเห็นข้อความแจ้งให้คุณอัปเดตลิงก์ การคลิกปุ่ม “Update Links” อาจทำให้ขนาดและตำแหน่งของกรอบอ็อบเจ็กต์ OLE เปลี่ยนแปลงไป เพราะ PowerPoint จะอัปเดตข้อมูลจากอ็อบเจ็กต์ OLE ที่เชื่อมโยงและรีเฟรชตัวอย่างของอ็อบเจ็กต์ เพื่อป้องกันไม่ให้ PowerPoint แจ้งให้อัปเดตข้อมูลของอ็อบเจ็กต์ ให้ตั้งค่าเมธอด `set_UpdateAutomatic` ของอินเทอร์เฟซ [IOleObjectFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/ioleobjectframe/) ให้เป็น `false`:  
```cpp
oleFrame->set_UpdateAutomatic(false);
```

## **สกัดไฟล์ที่ฝังอยู่**

Aspose.Slides for C++ ให้คุณสกัดไฟล์ที่ฝังอยู่ในสไลด์เป็นอ็อบเจ็กต์ OLE ได้โดยทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation) ที่มีอ็อบเจ็กต์ OLE ที่ต้องการสกัด  
2. วนลูปผ่านรูปทรงทั้งหมดในงานนำเสนอและเข้าถึงรูปทรง [OLEObjectFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/oleobjectframe/)  
3. เข้าถึงข้อมูลของไฟล์ที่ฝังอยู่จากกรอบอ็อบเจ็กต์ OLE แล้วเขียนลงดิสก์  

โค้ด C++ นี้แสดงวิธีสกัดไฟล์ที่ฝังอยู่ในสไลด์เป็นอ็อบเจ็กต์ OLE:  
``` cpp
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

## **คำถามที่พบบ่อย**

**เนื้อหา OLE จะถูกเรนเดอร์เมื่อส่งออกสไลด์เป็น PDF/รูปภาพหรือไม่?**  
สิ่งที่ปรากฏบนสไลด์จะถูกเรนเดอร์คือไอคอนหรือภาพแทน (preview) เนื้อหา OLE แบบ “สด” จะไม่ถูกประมวลผลในระหว่างการเรนเดอร์ หากจำเป็นให้ตั้งค่าภาพตัวอย่างของคุณเองเพื่อให้แน่ใจว่าการแสดงผลใน PDF ที่ส่งออกตรงตามที่คาดหวัง  

**ฉันจะล็อคอ็อบเจ็กต์ OLE บนสไลด์เพื่อไม่ให้ผู้ใช้ย้ายหรือแก้ไขได้ใน PowerPoint อย่างไร?**  
ล็อครูปทรง: Aspose.Slides มี [shape-level locks](/slides/th/cpp/applying-protection-to-presentation/) ซึ่งไม่ใช่การเข้ารหัส แต่ช่วยป้องกันการแก้ไขหรือการย้ายโดยบังเอิญ  

**ทำไมอ็อบเจ็กต์ Excel ที่เชื่อมโยงถึง “กระโดด” หรือเปลี่ยนขนาดเมื่อเปิดงานนำเสนอ?**  
PowerPoint อาจรีเฟรชตัวอย่างของ OLE ที่เชื่อมโยง สำหรับให้แสดงผลคงที่ ให้ทำตามแนวทางใน [Working Solution for Worksheet Resizing](/slides/th/cpp/working-solution-for-worksheet-resizing/) เช่น ปรับกรอบให้พอดีกับช่วงข้อมูล หรือสเกลช่วงให้เข้ากับกรอบคงที่และตั้งภาพแทนที่เหมาะสม  

**พาธสัมพันธ์สำหรับอ็อบเจ็กต์ OLE ที่เชื่อมโยงจะถูกเก็บรักษาในรูปแบบ PPTX หรือไม่?**  
ใน PPTX ข้อมูล “พาธสัมพันธ์” ไม่ได้ถูกบันทึกไว้ – มีเฉพาะพาธเต็มเท่านั้น พาธสัมพันธ์พบได้ในรูปแบบ PPT เก่า สำหรับความพกพา ควรใช้พาธเต็มที่เชื่อถือได้หรือ URI ที่เข้าถึงได้ หรือเลือกฝังไฟล์แทนการอ้างอิงทางพาธ.