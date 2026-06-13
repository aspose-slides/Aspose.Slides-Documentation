---
title: ปรับแต่งตารางข้อมูลของแผนภูมิในงานนำเสนอด้วย JavaScript
linktitle: ตารางข้อมูล
type: docs
url: /th/nodejs-java/chart-data-table/
keywords:
- ข้อมูลแผนภูมิ
- ตารางข้อมูล
- คุณสมบัติของฟอนต์
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ปรับแต่งตารางข้อมูลของแผนภูมิใน JavaScript สำหรับ PPT และ PPTX ด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java เพื่อเพิ่มประสิทธิภาพและความน่าสนใจในงานนำเสนอ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับตารางข้อมูลของแผนภูมิใน Aspose.Slides มันแสดงวิธีการแสดงตารางข้อมูลสำหรับแผนภูมิและปรับแต่งการจัดรูปแบบข้อความโดยการตั้งค่าคุณสมบัติโฟนต์ เช่น การทำให้เป็นตัวหนาและความสูงของฟอนต์ ตัวอย่างแสดงการโหลดงานนำเสนอ, เพิ่มแผนภูมิ, เปิดใช้งานตารางข้อมูลของแผนภูมิ, ใช้การตั้งค่าแบบอักษร, และบันทึกงานนำเสนอที่อัปเดต

ส่วนนี้ยังรวมคำตอบสั้น ๆ สำหรับคำถามทั่วไปเกี่ยวกับการแสดงคีย์คำอธิบายสีในตารางข้อมูลของแผนภูมิ, การรักษาตารางข้อมูลระหว่างการส่งออก, การทำงานกับแผนภูมิที่โหลดมาจากงานนำเสนอหรือเทมเพลตที่มีอยู่, และการระบุแผนภูมิที่เปิดใช้งานตารางข้อมูล

## **กำหนดคุณสมบัติโฟนต์สำหรับตารางข้อมูลของแผนภูมิ**

Aspose.Slides สำหรับ Node.js ผ่าน Java ให้การสนับสนุนการเปลี่ยนสีของหมวดหมู่ในสีของชุดข้อมูล  

1. สร้างอ็อบเจ็กต์คลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation)
1. เพิ่มแผนภูมิบนสไลด์
1. ตั้งค่าตารางแผนภูมิ
1. ตั้งค่าความสูงของฟอนต์
1. บันทึกงานนำเสนอที่แก้ไข  

ตัวอย่างต่อไปนี้ให้ไว้  

```javascript
// สร้างงานนำเสนอเปล่า
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontHeight(20);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถแสดงคีย์คำอธิบายสีขนาดเล็กข้างค่าตัวเลขในตารางข้อมูลของแผนภูมิได้หรือไม่?**

ใช่ ตารางข้อมูลสนับสนุน [legend keys](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/datatable/setshowlegendkey/), และคุณสามารถเปิดหรือปิดได้

**ตารางข้อมูลจะถูกเก็บรักษาไว้เมื่อต้องส่งออกงานนำเสนอเป็น PDF, HTML หรือรูปภาพหรือไม่?**

ใช่ Aspose.Slides แสดงแผนภูมิเป็นส่วนหนึ่งของสไลด์ ดังนั้นการส่งออก [PDF](/slides/th/nodejs-java/convert-powerpoint-to-pdf/)/[HTML](/slides/th/nodejs-java/convert-powerpoint-to-html/)/[image](/slides/th/nodejs-java/convert-powerpoint-to-png/) จะรวมแผนภูมิพร้อมตารางข้อมูลของมัน

**ตารางข้อมูลได้รับการสนับสนุนสำหรับแผนภูมิที่มาจากไฟล์เทมเพลตหรือไม่?**

ใช่ สำหรับแผนภูมิใด ๆ ที่โหลดมาจากงานนำเสนอหรือเทมเพลตที่มีอยู่ คุณสามารถตรวจสอบและเปลี่ยนแปลงว่าตารางข้อมูล [is shown](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chart/hasdatatable/) หรือไม่โดยใช้คุณสมบัติของแผนภูมิ

**ฉันจะค้นหาอย่างรวดเร็วว่าแผนภูมิใดในไฟล์ที่เปิดใช้งานตารางข้อมูลได้บ้าง?**

ตรวจสอบคุณสมบัติของแต่ละแผนภูมิที่บ่งบอกว่าตารางข้อมูล [is shown](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chart/hasdatatable/) และวนรอบสไลด์เพื่อระบุแผนภูมิที่เปิดใช้งานอยู่