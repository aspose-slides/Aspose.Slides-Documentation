---
title: วิธีแก้ปัญหาการปรับขนาดแผนภูมิใน PPTX
type: docs
weight: 60
url: /th/cpp/working-solution-for-chart-resizing-in-pptx/
keywords:
- การปรับขนาดแผนภูมิ
- แผนภูมิ Excel
- อ็อบเจ็กต์ OLE
- ฝังแผนภูมิ
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "แก้ไขการปรับขนาดแผนภูมิที่ไม่คาดคิดใน PPTX เมื่อใช้วัตถุ OLE ของ Excel ที่ฝังอยู่กับ Aspose.Slides สำหรับ C++. เรียนรู้สองวิธีพร้อมโค้ดเพื่อรักษาขนาดให้สม่ำเสมอ."
---
## **พื้นหลัง**

พบว่าแผนภูมิ Excel ที่ฝังเป็นอ็อบเจ็กต์ OLE ในการนำเสนอ PowerPoint ผ่านคอมโพเนนท์ของ Aspose จะถูกปรับขนาดเป็นสเกลที่ไม่ระบุหลังจากการเปิดใช้งานครั้งแรก พฤติกรรมนี้ทำให้เกิดความแตกต่างทางภาพที่ชัดเจนในการนำเสนอระหว่างสถานะก่อนและหลังการเปิดใช้งานของแผนภูมิ ทีมงาน Aspose ได้ทำการตรวจสอบปัญหาอย่างละเอียดและพบวิธีแก้ บทความนี้อธิบายสาเหตุของปัญหาและวิธีแก้ที่สอดคล้องกัน

ใน[บทความก่อนหน้า](/slides/th/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), เราได้อธิบายวิธีการสร้างแผนภูมิ Excel ด้วย Aspose.Cells for C++ และฝังมันในการนำเสนอ PowerPoint ด้วย Aspose.Slides for C++ เพื่อแก้ไข[ปัญหาการแสดงตัวอย่างอ็อบเจ็กต์](/slides/th/cpp/object-preview-issue-when-adding-oleobjectframe/), เราได้กำหนดภาพของแผนภูมิให้กับกรอบอ็อบเจ็กต์ OLE ของแผนภูมิ ในการนำเสนอที่ออกมา เมื่อคุณดับเบิลคลิกที่กรอบอ็อบเจ็กต์ OLE ที่แสดงภาพแผนภูมิ แผนภูมิ Excel จะถูกเปิดใช้งาน ผู้ใช้สามารถทำการเปลี่ยนแปลงใดๆ ที่ต้องการในสมุดงาน Excel ด้านล่างและจากนั้นกลับไปยังสไลด์ที่สอดคล้องกันโดยการคลิกนอกสมุดงานที่เปิดใช้งาน ขนาดของกรอบอ็อบเจ็กต์ OLE จะเปลี่ยนแปลงเมื่อผู้ใช้กลับไปยังสไลด์ และปัจจัยการปรับขนาดจะแตกต่างกันขึ้นอยู่กับขนาดดั้งเดิมของทั้งกรอบอ็อบเจ็กต์ OLE และสมุดงาน Excel ที่ฝังอยู่

## **สาเหตุของการปรับขนาด**

เนื่องจากสมุดงาน Excel มีขนาดหน้าต่างของตนเอง มันพยายามรักษาขนาดเดิมไว้ในการเปิดใช้งานครั้งแรก อย่างไรก็ตามกรอบอ็อบเจ็กต์ OLE มีขนาดของตัวเอง ตามที่ Microsoft ระบุ เมื่อสมุดงาน Excel ถูกเปิดใช้งาน Excel และ PowerPoint จะเจรจาขนาดและรักษาสัดส่วนที่ถูกต้องเป็นส่วนหนึ่งของกระบวนการฝัง ขึ้นอยู่กับความแตกต่างระหว่างขนาดหน้าต่าง Excel กับขนาดหรือสถานะของกรอบอ็อบเจ็กต์ OLE การปรับขนาดจะเกิดขึ้น

## **วิธีแก้ที่ใช้งานได้**

มีสองสถานการณ์ที่เป็นไปได้สำหรับการสร้างการนำเสนอ PowerPoint ด้วย Aspose.Slides for C++.

**สถานการณ์ 1:** สร้างการนำเสนอจากเทมเพลตที่มีอยู่แล้ว.

**สถานการณ์ 2:** สร้างการนำเสนอจากศูนย์.

วิธีแก้ที่เรานำเสนอที่นี่ใช้ได้กับทั้งสองสถานการณ์ พื้นฐานของแนวทางการแก้ทั้งหมดคือเดียวกัน: **ขนาดหน้าต่างของอ็อบเจ็กต์ OLE ที่ฝังควรตรงกับกรอบอ็อบเจ็กต์ OLE ในสไลด์ PowerPoint** เราจะอธิบายสองวิธีการแก้ไขต่อไปนี้

## **วิธีการที่หนึ่ง**

ในวิธีการนี้ เราจะเรียนรู้วิธีการตั้งค่าขนาดหน้าต่างของสมุดงาน Excel ที่ฝังให้ตรงกับขนาดของกรอบอ็อบเจ็กต์ OLE ในสไลด์ PowerPoint.

**สถานการณ์ 1**

สมมติว่าเรามีการกำหนดเทมเพลตและต้องการสร้างการนำเสนอจากเทมเพลตนั้น สมมติว่ามีรูปร่างที่ดัชนี 2 ในเทมเพลตที่เราต้องการวางกรอบ OLE ที่บรรจุสมุดงาน Excel ที่ฝังไว้ ในสถานการณ์นี้ขนาดของกรอบอ็อบเจ็กต์ OLE ถูกกำหนดล่วงหน้า—ตรงกับขนาดของรูปร่างที่ดัชนี 2 ในเทมเพลต สิ่งที่เราต้องทำคือกำหนดขนาดหน้าต่างของสมุดงานให้เท่ากับขนาดของรูปร่างนั้น โค้ดตัวอย่างต่อไปนี้ทำหน้าที่ดังกล่าว:

```cpp
System::SharedPtr<System::IO::MemoryStream> ToSlidesMemoryStream(intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> inputStream)
{
    auto outputBuffer = System::MakeArray<uint8_t>(inputStream->GetLength(), inputStream->GetBuffer()->ArrayPoint());
    auto outputStream = System::MakeObject<System::IO::MemoryStream>(outputBuffer);

    return outputStream;
}
```

```cpp
// กำหนดขนาดแผนภูมิด้วยหน้าต่าง. 
chart->SetSizeWithWindow(true);

auto shape = slide->get_Shape(2);

// ตั้งค่าความกว้างของหน้าต่างสมุดงานเป็นนิ้ว (หารด้วย 72 เนื่องจาก PowerPoint ใช้ 72 พิกเซลต่ออินช.).
workbook->GetISettings()->SetWindowWidthInch(shape->get_Width() / 72.f);

// ตั้งค่าความสูงของหน้าต่างสมุดงานเป็นนิ้ว.
workbook->GetISettings()->SetWindowHeightInch(shape->get_Height() / 72.f);

// บันทึกสมุดงานไปยังสตรีมหน่วยความจำ.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream3(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// สร้างเฟรมอ็อบเจ็กต์ OLE พร้อมข้อมูล Excel ที่ฝังอยู่.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    shape->get_X(), 
    shape->get_Y(), 
    shape->get_Width(), 
    shape->get_Height(),
    dataInfo);
```

**สถานการณ์ 2**

สมมติว่าเราต้องการสร้างการนำเสนอจากศูนย์และรวมกรอบอ็อบเจ็กต์ OLE ขนาดใดก็ได้พร้อมสมุดงาน Excel ที่ฝังไว้ ในโค้ดตัวอย่างต่อไปนี้ เราจะสร้างกรอบอ็อบเจ็ต OLE สูง 4 นิ้ว และกว้าง 9.5 นิ้ว ที่ตำแหน่ง x = 0.5 นิ้ว y = 1 นิ้วบนสไลด์ จากนั้นเราจะตั้งค่าหน้าต่างสมุดงาน Excel ให้มีขนาดเดียวกัน—สูง 4 นิ้ว และกว้าง 9.5 นิ้ว

```cpp
// ความสูงที่ต้องการของเรา.
int32_t desiredHeight = 288; // 4 นิ้ว (4 * 72)

// ความกว้างที่ต้องการของเรา.
int32_t desiredWidth = 684; // 9.5 นิ้ว (9.5 * 72)

// กำหนดขนาดแผนภูมิด้วยหน้าต่าง. 
chart->SetSizeWithWindow(true);

// ตั้งค่าความกว้างของหน้าต่างสมุดงานเป็นนิ้ว.
workbook->GetISettings()->SetWindowWidthInch(desiredWidth / 72.f);

// ตั้งค่าความสูงของหน้าต่างสมุดงานเป็นนิ้ว.
workbook->GetISettings()->SetWindowHeightInch(desiredHeight / 72.f);

// บันทึกสมุดงานไปยังสตรีมหน่วยความจำ.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// สร้างเฟรมอ็อบเจ็กต์ OLE พร้อมข้อมูล Excel ที่ฝังอยู่.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    36.0f,
    72.0f, 
    desiredWidth, 
    desiredHeight,
    dataInfo);
```

## **วิธีการที่สอง**

ในวิธีการนี้ เราจะเรียนรู้วิธีการกำหนดขนาดของแผนภูมิในสมุดงาน Excel ที่ฝังให้ตรงกับขนาดของกรอบอ็อบเจ็กต์ OLE ในสไลด์ PowerPoint วิธีนี้มีประโยชน์เมื่อขนาดของแผนภูมิรู้ล่วงหน้าและจะไม่เปลี่ยนแปลง

**สถานการณ์ 1**

สมมติว่าเรามีการกำหนดเทมเพลตและต้องการสร้างการนำเสนอจากเทมเพลตนั้น สมมติว่ามีรูปร่างที่ดัชนี 2 ในเทมเพลตที่เราตั้งใจจะวางกรอบ OLE ที่บรรจุสมุดงาน Excel ที่ฝังไว้ ในสถานการณ์นี้ขนาดของกรอบ OLE ถูกกำหนดล่วงหน้า—ตรงกับขนาดของรูปร่างที่ดัชนี 2 ในเทมเพลต สิ่งที่เราต้องทำคือกำหนดขนาดของแผนภูมิในสมุดงานให้เท่ากับขนาดของรูปร่างนั้น โค้ดตัวอย่างต่อไปนี้ทำหน้าที่ดังกล่าว:

```cpp
// กำหนดขนาดแผนภูมิโดยไม่มีหน้าต่าง. 
chart->SetSizeWithWindow(false);

auto shape = slide->get_Shape(2);

// ตั้งค่าความกว้างของแผนภูมิเป็นพิกเซล (คูณด้วย 96 เนื่องจาก Excel ใช้ 96 พิกเซลต่อหนึ่งอินช.)    
chart->GetIChartObject()->SetWidth((int32_t)(shape->get_Width() / 72.f * 96.f));

// ตั้งค่าความสูงของแผนภูมิเป็นพิกเซล.
chart->GetIChartObject()->SetHeight((int32_t)(shape->get_Height() / 72.f) * 96.f);

// กำหนดขนาดการพิมพ์ของแผนภูมิ.
chart->SetPrintSize(Aspose::Cells::PrintSizeType::PrintSizeType_Custom);

// บันทึกสมุดงานไปยังสตรีมหน่วยความจำ.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// สร้างเฟรมอ็อบเจ็กต์ OLE ด้วยข้อมูล Excel ที่ฝังอยู่.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    shape->get_X(), 
    shape->get_Y(), 
    shape->get_Width(),
    shape->get_Height(),
    dataInfo);
```

**สถานการณ์ 2**

สมมติว่าเราต้องการสร้างการนำเสนอจากศูนย์และรวมกรอบอ็อบเจ็กต์ OLE ขนาดใดก็ได้พร้อมสมุดงาน Excel ที่ฝังไว้ ในโค้ดตัวอย่างต่อไปนี้ เราจะสร้างกรอบอ็อบเจ็กต์ OLE ที่มีความสูง 4 นิ้วและความกว้าง 9.5 นิ้วบนสไลด์ที่ตำแหน่ง x = 0.5 นิ้ว y = 1 นิ้ว เราก็จะตั้งค่าขนาดของแผนภูมิให้ตรงกับมิติเดียวกัน: ความสูง 4 นิ้วและความกว้าง 9.5 นิ้ว

```cpp
// ความสูงที่ต้องการของเรา.
int32_t desiredHeight = 288; // 4 นิ้ว (4 * 576)

// ความกว้างที่ต้องการของเรา.
int32_t desiredWidth = 684; // 9.5 นิ้ว(9.5 * 576)

// กำหนดขนาดแผนภูมิโดยไม่มีหน้าต่าง. 
chart->SetSizeWithWindow(false);

// ตั้งค่าความกว้างของแผนภูมิเป็นพิกเซล.    
chart->GetIChartObject()->SetWidth((int32_t)((desiredWidth / 72.f) * 96.f));

// ตั้งค่าความสูงของแผนภูมิเป็นพิกเซล.
chart->GetIChartObject()->SetHeight((int32_t)((desiredHeight / 72.f) * 96.f));

// บันทึกสมุดงานไปยังสตรีมหน่วยความจำ.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// สร้างเฟรมอ็อบเจ็กต์ OLE พร้อมข้อมูล Excel ที่ฝังอยู่.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    36.0f, 
    72.0f, 
    desiredWidth, 
    desiredHeight,
    dataInfo);
```

## **สรุป**

มีสองวิธีการแก้ไขปัญหาการปรับขนาดแผนภูมิ การเลือกวิธีขึ้นอยู่กับความต้องการและกรณีการใช้งาน ทั้งสองวิธีทำงานแบบเดียวกันไม่ว่าจะสร้างการนำเสนอจากเทมเพลตหรือจากศูนย์ นอกจากนี้ไม่มีขีดจำกัดขนาดของกรอบอ็อบเจ็กต์ OLE ในวิธีการนี้

## **คำถามที่พบบ่อย**

**ทำไมแผนภูมิ Excel ที่ฝังอยู่จึงเปลี่ยนขนาดหลังจากเปิดใช้งานใน PowerPoint?**

เกิดจาก Excel พยายามคืนค่าขนาดหน้าต่างเดิมเมื่อเปิดใช้งานครั้งแรก ในขณะที่กรอบอ็อบเจ็กต์ OLE ใน PowerPoint มีขนาดของตัวเอง PowerPoint และ Excel จะเจรจาขนาดเพื่อรักษาอัตราส่วน ซึ่งอาจทำให้เกิดการปรับขนาด

**สามารถป้องกันปัญหาการปรับขนาดนี้ได้ทั้งหมดหรือไม่?**

ทำได้โดยการตรงกับขนาดหน้าต่างของสมุดงาน Excel หรือขนาดแผนภูมิให้เท่ากรอบอ็อบเจ็กต์ OLE ก่อนการฝัง จะทำให้ขนาดแผนภูมิคงที่

**ควรเลือกวิธีใด ระหว่างการตั้งค่าขนาดหน้าต่างสมุดงานหรือการตั้งค่าขนาดแผนภูมิ?**

ใช้ **วิธีที่ 1 (ขนาดหน้าต่าง)** หากต้องการรักษาอัตราส่วนของสมุดงานและอาจให้ผู้ใช้ปรับขนาดต่อไปในภายหลัง  
ใช้ **วิธีที่ 2 (ขนาดแผนภูมิ)** หากขนาดแผนภูมิมีค่าคงที่และจะไม่เปลี่ยนแปลงหลังการฝัง

**วิธีเหล่านี้จะทำงานกับการนำเสนอที่สร้างจากเทมเพลตและการนำเสนอใหม่หรือไม่?**

ใช่ ทั้งสองวิธีทำงานเช่นเดียวกันสำหรับการนำเสนอที่สร้างจากเทมเพลตและจากศูนย์

**มีขีดจำกัดขนาดของกรอบอ็อบเจ็กต์ OLE หรือไม่?**

ไม่มี คุณสามารถตั้งค่ากรอบ OLE เป็นขนาดใดก็ได้ตราบใดที่สเกลอย่างเหมาะสมกับขนาดของสมุดงานหรือแผนภูมิ

**สามารถใช้วิธีเหล่านี้กับแผนภูมิที่สร้างด้วยโปรแกรมสเปรดชีตอื่นได้หรือไม่?**

ตัวอย่างออกแบบมาสำหรับแผนภูมิ Excel ที่สร้างด้วย Aspose.Cells แต่หลักการสามารถใช้ได้กับโปรแกรมสเปรดชีตที่เข้ากันได้กับ OLE หากรองรับตัวเลือกการกำหนดขนาดที่คล้ายกัน

## **ส่วนที่เกี่ยวข้อง**

- [สร้างแผนภูมิ Excel และฝังเป็นอ็อบเจ็กต์ OLE ในการนำเสนอ](/slides/th/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)