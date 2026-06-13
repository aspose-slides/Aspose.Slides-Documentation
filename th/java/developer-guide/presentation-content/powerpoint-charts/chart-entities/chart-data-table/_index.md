---
title: ปรับแต่งตารางข้อมูลแผนภูมิในการนำเสนอด้วย Java
linktitle: ตารางข้อมูล
type: docs
url: /th/java/chart-data-table/
keywords:
- ข้อมูลแผนภูมิ
- ตารางข้อมูล
- คุณสมบัติฟอนต์
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "ปรับแต่งตารางข้อมูลแผนภูมิใน Java สำหรับ PPT และ PPTX ด้วย Aspose.Slides เพื่อเพิ่มประสิทธิภาพและความน่าสนใจในงานนำเสนอ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับตารางข้อมูลแผนภูมิใน Aspose.Slides โดยแสดงวิธีการแสดงตารางข้อมูลสำหรับแผนภูมิและปรับแต่งรูปแบบข้อความโดยตั้งค่าคุณสมบัติฟอนต์ เช่น การทำตัวหนาและความสูงของฟอนต์ ตัวอย่างจะแสดงการโหลดงานนำเสนอ, การเพิ่มแผนภูมิ, การเปิดใช้งานตารางข้อมูลแผนภูมิ, การใช้การตั้งค่าฟอนต์, และการบันทึกงานนำเสนอที่อัปเดต

ส่วนนี้ยังรวมคำตอบสั้น ๆ สำหรับคำถามทั่วไปเกี่ยวกับการแสดงคีย์คำอธิบายในตารางข้อมูลแผนภูมิ, การคงตารางข้อมูลไว้ระหว่างการส่งออก, การทำงานกับแผนภูมิที่โหลดจากงานนำเสนอหรือเทมเพลตที่มีอยู่, และการระบุแผนภูมิที่เปิดใช้งานตารางข้อมูล

## **ตั้งค่าคุณสมบัติฟอนต์สำหรับตารางข้อมูลแผนภูมิ**
Aspose.Slides for Java มีการสนับสนุนการเปลี่ยนสีของประเภทในสีของซีรีส์  

1. สร้างอ็อบเจ็กต์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)
2. เพิ่มแผนภูมิบนสไลด์
3. ตั้งค่าตารางแผนภูมิ
4. ตั้งค่าความสูงของฟอนต์
5. บันทึกงานนำเสนอที่แก้ไข  

ตัวอย่างโค้ดด้านล่างนี้ให้ไว้  

```java
// สร้างงานนำเสนอเปล่า
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.setDataTable(true);

    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontBold(NullableBool.True);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontHeight(20);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Can I show small legend keys next to the values in the chart’s data table?**

ใช่ ตารางข้อมูลรองรับ [legend keys](https://reference.aspose.com/slides/th/java/com.aspose.slides/datatable/#setShowLegendKey-boolean-) และคุณสามารถเปิดหรือปิดได้

**Will the data table be preserved when exporting the presentation to PDF, HTML, or images?**

ใช่ Aspose.Slides เรนเดอร์แผนภูมิเป็นส่วนหนึ่งของสไลด์ ดังนั้นไฟล์ที่ส่งออกเป็น [PDF](/slides/th/java/convert-powerpoint-to-pdf/)/[HTML](/slides/th/java/convert-powerpoint-to-html/)/[image](/slides/th/java/convert-powerpoint-to-png/) จะรวมแผนภูมิพร้อมตารางข้อมูลด้วย

**Are data tables supported for charts that come from a template file?**

ใช่ สำหรับแผนภูมิใด ๆ ที่โหลดจากงานนำเสนอหรือเทมเพลตที่มีอยู่ คุณสามารถตรวจสอบและเปลี่ยนแปลงว่าตารางข้อมูล [is shown](https://reference.aspose.com/slides/th/java/com.aspose.slides/chart/#hasDataTable--) โดยใช้คุณสมบัติของแผนภูมิ

**How can I quickly find which charts in a file have the data table enabled?**

ตรวจสอบคุณสมบัติของแต่ละแผนภูมิที่บ่งชี้ว่าตารางข้อมูล [is shown](https://reference.aspose.com/slides/th/java/com.aspose.slides/chart/#hasDataTable--) และวนผ่านสไลด์เพื่อระบุแผนภูมิที่เปิดใช้งาน