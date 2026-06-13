---
title: ปรับแต่งตารางข้อมูลแผนภูมิในงานนำเสนอบน Android
linktitle: ตารางข้อมูล
type: docs
url: /th/androidjava/chart-data-table/
keywords:
  - ข้อมูลแผนภูมิ
  - ตารางข้อมูล
  - คุณสมบัติฟอนต์
  - PowerPoint
  - งานนำเสนอ
  - Android
  - Java
  - Aspose.Slides
description: "ปรับแต่งตารางข้อมูลแผนภูมิใน Java สำหรับ PPT และ PPTX ด้วย Aspose.Slides สำหรับ Android เพื่อเพิ่มประสิทธิภาพและความน่าสนใจในงานนำเสนอ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับตารางข้อมูลของแผนภูมิใน Aspose.Slides แสดงวิธีการแสดงตารางข้อมูลสำหรับแผนภูมิและปรับแต่งรูปแบบข้อความโดยการตั้งค่าคุณสมบัติของฟอนต์ เช่น รูปแบบตัวหนาและความสูงของฟอนต์ ตัวอย่างแสดงการโหลดงานนำเสนอ การเพิ่มแผนภูมิ การเปิดใช้งานตารางข้อมูลของแผนภูมิ การกำหนดค่าฟอนต์ และการบันทึกงานนำเสนอที่อัปเดต

## **ตั้งค่าคุณสมบัติฟอนต์สำหรับตารางข้อมูลของแผนภูมิ**
Aspose.Slides for Android via Java ให้การสนับสนุนการเปลี่ยนสีของหมวดหมู่ในสีของชุดข้อมูล  

1. สร้างอ็อบเจกต์คลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)  
1. เพิ่มแผนภูมิบนสไลด์  
1. ตั้งค่าตารางแผนภูมิ  
1. ตั้งค่าความสูงของฟอนต์  
1. บันทึกงานนำเสนอที่ถูกแก้ไข  

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

## **คำถามที่พบบ่อย**

**ฉันสามารถแสดงคีย์คำอธิบายย่อยข้างค่าต่าง ๆ ในตารางข้อมูลของแผนภูมิได้หรือไม่?**

ใช่ ตารางข้อมูลรองรับ [legend keys](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/datatable/#setShowLegendKey-boolean-) และคุณสามารถเปิดหรือปิดได้  

**ตารางข้อมูลจะถูกเก็บไว้เมื่อส่งออกงานนำเสนอเป็น PDF, HTML หรือภาพหรือไม่?**

ใช่ Aspose.Slides จะเรนเดอร์แผนภูมิเป็นส่วนหนึ่งของสไลด์ ดังนั้น [PDF](/slides/th/androidjava/convert-powerpoint-to-pdf/)/[HTML](/slides/th/androidjava/convert-powerpoint-to-html/)/[image](/slides/th/androidjava/convert-powerpoint-to-png/) ที่ส่งออกจะรวมแผนภูมิพร้อมตารางข้อมูลของมัน  

**ตารางข้อมูลได้รับการสนับสนุนสำหรับแผนภูมิที่มาจากไฟล์แม่แบบหรือไม่?**

ใช่ สำหรับแผนภูมิใด ๆ ที่โหลดจากงานนำเสนอหรือแม่แบบที่มีอยู่ คุณสามารถตรวจสอบและเปลี่ยนแปลงว่าแผนภูมิมีการแสดง [is shown](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/chart/#hasDataTable--) หรือไม่โดยใช้คุณสมบัติของแผนภูมิ  

**ฉันจะหาแผนภูมิที่เปิดใช้งานตารางข้อมูลในไฟล์ได้อย่างรวดเร็วอย่างไร?**

ตรวจสอบคุณสมบัติของแต่ละแผนภูมิที่ระบุว่าตารางข้อมูล [is shown](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/chart/#hasDataTable--) หรือไม่และวนซ้ำผ่านสไลด์เพื่อระบุแผนภูมิที่เปิดใช้งาน  