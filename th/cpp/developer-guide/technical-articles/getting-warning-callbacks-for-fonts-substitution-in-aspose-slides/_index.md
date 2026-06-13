---
title: รับการเรียกคืนคำเตือนสำหรับการแทนที่ฟอนต์
type: docs
weight: 70
url: /th/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- การเรียกคืนคำเตือน
- การแทนที่ฟอนต์
- กระบวนการเรนเดอร์
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "เรียนรู้วิธีรับการเรียกคืนคำเตือนสำหรับการแทนที่ฟอนต์ใน Aspose.Slides for C++ และแสดงการนำเสนอ PowerPoint และ OpenDocument อย่างแม่นยำ."
---
## **บทนำ**

Aspose.Slides for C++ ช่วยให้คุณสามารถรับการเรียกคืนคำเตือนสำหรับการแทนที่ฟอนต์เมื่อฟอนต์ที่ต้องการไม่มีอยู่ในเครื่องระหว่างการเรนเดอร์ การเรียกคืนเหล่านี้ช่วยวินิจฉัยปัญหาเกี่ยวกับฟอนต์ที่หายไปหรือไม่สามารถเข้าถึงได้

## **เปิดใช้งานการเรียกคืนคำเตือน**

Aspose.Slides for C++ มี API ที่ใช้งานง่ายสำหรับรับการเรียกคืนคำเตือนเมื่อเรนเดอร์สไลด์พรีเซนเทชัน ทำตามขั้นตอนต่อไปนี้เพื่อกำหนดการเรียกคืนคำเตือน:

1. สร้างคลาส callback ที่กำหนดเองซึ่ง implements อินเทอร์เฟซ [IWarningCallback](https://reference.aspose.com/slides/th/cpp/aspose.slides.warnings/iwarningcallback/) เพื่อจัดการคำเตือน
1. ตั้งค่าการเรียกคืนคำเตือนโดยใช้คลาสตัวเลือก เช่น [RenderingOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/renderingoptions/), [PdfOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/htmloptions/), และอื่น ๆ
1. โหลดพรีเซนเทชันที่ใช้ฟอนต์ซึ่งไม่มีในเครื่องเป้าหมาย
1. สร้างภาพย่อสไลด์หรือส่งออกพรีเซนเทชันเพื่อสังเกตผลลัพธ์

**คลาสการเรียกคืนคำเตือนที่กำหนดเอง:**

```cpp
#include <Warnings/IWarningCallback.h>

class FontWarningHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override;
};

ReturnAction FontWarningHandler::Warning(SharedPtr<IWarningInfo> warning)
{
    if (warning->get_WarningType() == WarningType::DataLoss)
    {
        Console::WriteLine(warning->get_Description());
    }

    return ReturnAction::Continue;
}

// ผลลัพธ์ตัวอย่าง:
//
// ฟอนต์จะถูกแทนที่จาก XYZ ไปยัง {Calibri,Cambria Math,MS Gothic,Gulim,Arial Unicode,SimSun,Segoe UI Symbol}}
```

**สร้างภาพย่อสไลด์:**

```cpp
// ตั้งค่าการเรียกคืนคำเตือนเพื่อจัดการคำเตือนที่เกี่ยวกับฟอนต์ระหว่างการเรนเดอร์สไลด์.
auto options = MakeObject<RenderingOptions>();
options->set_WarningCallback(MakeObject<FontWarningHandler>());

// โหลดพรีเซนเทชันจากเส้นทางไฟล์ที่ระบุ.
auto presentation = MakeObject<Presentation>(u"sample.pptx");
    
// สร้างภาพย่อสไลด์สำหรับแต่ละสไลด์ในพรีเซนเทชัน.
for(auto&& slide : presentation->get_Slides())
{
    // รับภาพย่อสไลด์โดยใช้ตัวเลือกการเรนเดอร์ที่ระบุ.
    auto image = slide->GetImage(options);
    // ...

    image->Dispose();
}

presentation->Dispose();
```

**ส่งออกเป็นรูปแบบ PDF:**

```cpp
// ตั้งค่าการเรียกคืนคำเตือนเพื่อจัดการคำเตือนที่เกี่ยวกับฟอนต์ระหว่างการส่งออกเป็น PDF.
auto options = MakeObject<PdfOptions>();
options->set_WarningCallback(MakeObject<FontWarningHandler>());

// โหลดพรีเซนเทชันจากเส้นทางไฟล์ที่ระบุ.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// ส่งออกพรีเซนเทชันเป็น PDF.
auto stream = MakeObject<MemoryStream>();
presentation->Save(stream, SaveFormat::Pdf, options);
// ...

stream->Dispose();
presentation->Dispose();
```

**ส่งออกเป็นรูปแบบ HTML:**

```cpp
// ตั้งค่าการเรียกคืนคำเตือนเพื่อจัดการคำเตือนที่เกี่ยวกับฟอนต์ระหว่างการส่งออกเป็น HTML.
auto options = MakeObject<HtmlOptions>();
options->set_WarningCallback(MakeObject<FontWarningHandler>());

// โหลดพรีเซนเทชันจากเส้นทางไฟล์ที่ระบุ.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// ส่งออกพรีเซนเทชันในรูปแบบ HTML.
auto stream = MakeObject<MemoryStream>();
presentation->Save(stream, SaveFormat::Html, options);
// ...

stream->Dispose();
presentation->Dispose();
```