---
title: ปรับแต่งตารางข้อมูลแผนภูมิในงานนำเสนอโดยใช้ С++
linktitle: ตารางข้อมูล
type: docs
url: /th/cpp/chart-data-table/
keywords:
- ข้อมูลแผนภูมิ
- ตารางข้อมูล
- คุณสมบัติฟอนต์
- PowerPoint
- งานนำเสนอ
- С++
- Aspose.Slides
description: "ปรับแต่งตารางข้อมูลแผนภูมิใน С++ สำหรับ PPT และ PPTX ด้วย Aspose.Slides เพื่อเพิ่มประสิทธิภาพและความน่าสนใจในงานนำเสนอ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับตารางข้อมูลแผนภูมิใน Aspose.Slides แสดงวิธีการแสดงตารางข้อมูลสำหรับแผนภูมิและปรับรูปแบบข้อความโดยตั้งค่าคุณสมบัติฟอนต์ เช่น สไตล์หนาและความสูงของฟอนต์ ตัวอย่างจะแสดงการโหลดงานนำเสนอ การเพิ่มแผนภูมิ การเปิดใช้งานตารางข้อมูลแผนภูมิ การกำหนดค่าฟอนต์ และการบันทึกงานนำเสนอที่อัปเดต

## **ตั้งค่าคุณสมบัติฟอนต์สำหรับตารางข้อมูลแผนภูมิ**
Aspose.Slides for C++ รองรับการเปลี่ยนคุณสมบัติฟอนต์สำหรับตารางข้อมูลแผนภูมิ

1. สร้างออบเจกต์คลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation)
1. เพิ่มแผนภูมิบนสไลด์
1. ตั้งค่าตารางแผนภูมิ
1. ตั้งค่าความสูงของฟอนต์
1. บันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่างโค้ดตัวอย่างมีดังต่อไปนี้

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);

chart->set_HasDataTable(true);

chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontBold(NullableBool::True);
chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontHeight(20.0f);

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **คำถามที่พบบ่อย**

**ฉันสามารถแสดงคีย์คำอธิบายขนาดเล็กข้างค่าต่าง ๆ ในตารางข้อมูลของแผนภูมิได้หรือไม่?**

ได้ ตารางข้อมูลสนับสนุน [legend keys](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/datatable/set_showlegendkey/) และคุณสามารถเปิดหรือปิดได้

**ตารางข้อมูลจะถูกเก็บไว้เมื่อส่งออกงานนำเสนอเป็น PDF, HTML หรือรูปภาพหรือไม่?**

ได้ Aspose.Slides จะเรนเดอร์แผนภูมิเป็นส่วนหนึ่งของสไลด์ ดังนั้นไฟล์ที่ส่งออกเป็น [PDF](/slides/th/cpp/convert-powerpoint-to-pdf/)/[HTML](/slides/th/cpp/convert-powerpoint-to-html/)/[image](/slides/th/cpp/convert-powerpoint-to-png/) จะรวมแผนภูมิพร้อมตารางข้อมูลไว้ด้วย

**ตารางข้อมูลรองรับสำหรับแผนภูมิที่มาจากไฟล์เทมเพลตหรือไม่?**

ได้ สำหรับแผนภูมิใด ๆ ที่โหลดจากงานนำเสนอหรือเทมเพลตเดิม คุณสามารถตรวจสอบและเปลี่ยนแปลงว่าตารางข้อมูล [is shown](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/chart/set_hasdatatable/) หรือไม่โดยใช้คุณสมบัติของแผนภูมิ

**ฉันจะค้นหาแผนภูมิที่เปิดใช้งานตารางข้อมูลในไฟล์ได้อย่างรวดเร็วอย่างไร?**

ตรวจสอบคุณสมบัติของแต่ละแผนภูมิที่บ่งบอกว่าตารางข้อมูล [is shown](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/chart/get_hasdatatable/) หรือไม่ แล้ววนลูปผ่านสไลด์เพื่อระบุแผนภูมิที่เปิดใช้คุณลักษณะนี้