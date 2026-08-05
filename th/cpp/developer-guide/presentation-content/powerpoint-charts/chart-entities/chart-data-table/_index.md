---
title: ปรับแต่งตารางข้อมูลแผนภูมิในงานนำเสนอด้วย C++
linktitle: ตารางข้อมูล
type: docs
url: /th/cpp/chart-data-table/
keywords:
- ข้อมูลแผนภูมิ
- ตารางข้อมูล
- คุณสมบัติฟอนต์
- PowerPoint
- งานนำเสนอ
- C++
- Aspose.Slides
description: "ปรับแต่งตารางข้อมูลแผนภูมิใน C++ สำหรับ PPT และ PPTX ด้วย Aspose.Slides เพื่อเพิ่มประสิทธิภาพและความน่าสนใจในงานนำเสนอ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับตารางข้อมูลของแผนภูมิใน Aspose.Slides แสดงวิธีการแสดงตารางข้อมูลสำหรับแผนภูมิและปรับแต่งรูปแบบข้อความโดยตั้งค่าคุณสมบัติของฟอนต์ เช่นสไตล์หนาและความสูงของฟอนต์ ตัวอย่างแสดงการโหลดงานนำเสนอ การเพิ่มแผนภูมิ การเปิดใช้ตารางข้อมูลของแผนภูมิ การกำหนดค่าฟอนต์ และการบันทึกงานนำเสนอที่อัปเดต

## **กำหนดคุณสมบัติฟอนต์สำหรับตารางข้อมูลแผนภูมิ**
Aspose.Slides for C++ อนุญาตให้เปลี่ยนแปลงคุณสมบัติฟอนต์สำหรับตารางข้อมูลของแผนภูมิ

1. สร้างตัวอย่างอ็อบเจกต์คลาส[Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation)
2. เพิ่มแผนภูมิในสไลด์
3. ตั้งค่าตารางแผนภูมิ
4. ตั้งค่าความสูงของฟอนต์
5. บันทึกงานนำเสนอที่แก้ไข

ตัวอย่างโค้ดด้านล่างนี้ให้มา

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);

chart->set_HasDataTable(true);

chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontBold(NullableBool::True);
chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontHeight(20.0f);

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **คำถามที่พบบ่อย**

**ฉันสามารถแสดงคีย์คำอธิบายขนาดเล็กข้างค่าตารางข้อมูลของแผนภูมิได้หรือไม่?**

ใช่ ตารางข้อมูลรองรับ[legend keys](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/datatable/set_showlegendkey/)และคุณสามารถเปิดหรือปิดได้

**ตารางข้อมูลจะยังคงอยู่เมื่อส่งออกงานนำเสนอเป็น PDF, HTML หรือภาพหรือไม่?**

ใช่ Aspose.Slides เรนเดอร์แผนภูมิเป็นส่วนหนึ่งของสไลด์ ดังนั้นไฟล์ที่ส่งออกเป็น[PDF](/slides/th/cpp/convert-powerpoint-to-pdf/)/[HTML](/slides/th/cpp/convert-powerpoint-to-html/)/[image](/slides/th/cpp/convert-powerpoint-to-png/)จะรวมแผนภูมิพร้อมตารางข้อมูลไว้ด้วย

**ตารางข้อมูลได้รับการสนับสนุนสำหรับแผนภูมิที่มาจากไฟล์เทมเพลตหรือไม่?**

ใช่ สำหรับแผนภูมิใด ๆ ที่โหลดมาจากงานนำเสนอหรือเทมเพลตที่มีอยู่ คุณสามารถตรวจสอบและเปลี่ยนแปลงว่าตารางข้อมูล[is shown](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/chart/set_hasdatatable/)หรือไม่โดยใช้คุณสมบัติของแผนภูมิ

**ฉันจะค้นหาแผนภูมิที่มีการเปิดใช้งานตารางข้อมูลในไฟล์ได้อย่างรวดเร็วอย่างไร?**

ตรวจสอบคุณสมบัติของแต่ละแผนภูมิที่บ่งบอกว่าตารางข้อมูล[is shown](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/chart/get_hasdatatable/)หรือไม่และวนลูปผ่านสไลด์เพื่อระบุแผนภูมิที่เปิดใช้งานอยู่