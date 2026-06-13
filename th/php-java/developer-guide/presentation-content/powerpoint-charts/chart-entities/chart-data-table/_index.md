---
title: ปรับแต่งตารางข้อมูลแผนภูมิในงานนำเสนอด้วย PHP
linktitle: ตารางข้อมูล
type: docs
url: /th/php-java/chart-data-table/
keywords:
- ข้อมูลแผนภูมิ
- ตารางข้อมูล
- คุณสมบัติตัวอักษร
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "ปรับแต่งตารางข้อมูลแผนภูมิสำหรับ PPT และ PPTX ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java เพื่อเพิ่มประสิทธิภาพและความน่าสนใจในงานนำเสนอ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีทำงานกับตารางข้อมูลแผนภูมิใน Aspose.Slides โดยแสดงวิธีการแสดงตารางข้อมูลสำหรับแผนภูมิและปรับแต่งรูปแบบข้อความโดยการตั้งค่าคุณสมบัติตัวอักษร เช่น สไตล์ตัวหนาและความสูงของตัวอักษร ตัวอย่างนี้สาธิตการโหลดงานนำเสนอ การเพิ่มแผนภูมิ การเปิดใช้งานตารางข้อมูลแผนภูมิ การกำหนดค่าตัวอักษร และการบันทึกงานนำเสนอที่อัปเดตแล้ว

บทความยังรวมคำตอบสั้น ๆ สำหรับคำถามทั่วไปเกี่ยวกับการแสดงคีย์คำอธิบายในตารางข้อมูลของแผนภูมิ การรักษาตารางข้อมูลขณะส่งออก การทำงานกับแผนภูมิที่โหลดจากงานนำเสนอหรือแม่แบบที่มีอยู่แล้ว และวิธีระบุแผนภูมิที่เปิดใช้ตารางข้อมูลอยู่

## **ตั้งค่าคุณสมบัติตัวอักษรสำหรับตารางข้อมูลแผนภูมิ**
Aspose.Slides for PHP via Java ให้การสนับสนุนการเปลี่ยนอ สีของประเภทในสีของซีรีส์

1. สร้างตัวอ็อบเจ็กต์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation)
1. เพิ่มแผนภูมิบนสไลด์
1. ตั้งค่าตารางแผนภูมิ
1. ตั้งความสูงของตัวอักษร
1. บันทึกการนำเสนอที่แก้ไขแล้ว

ตัวอย่างโค้ดตัวอย่างด้านล่างแสดงให้เห็น

```php
  # สร้างงานนำเสนอเปล่า
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);
    $chart->getChartDataTable()->getTextFormat()->getPortionFormat()->setFontBold(NullableBool::True);
    $chart->getChartDataTable()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **คำถามที่พบบ่อย**

**ฉันสามารถแสดงคีย์คำอธิบายเล็ก ๆ ข้างค่าต่าง ๆ ในตารางข้อมูลของแผนภูมิได้หรือไม่?**

ใช่. ตารางข้อมูลสนับสนุน [คีย์คำอธิบาย](https://reference.aspose.com/slides/th/php-java/aspose.slides/datatable/setshowlegendkey/), และคุณสามารถเปิดหรือปิดได้

**ตารางข้อมูลจะยังคงอยู่เมื่อส่งออกงานนำเสนอเป็น PDF, HTML หรือรูปภาพหรือไม่?**

ใช่. Aspose.Slides แสดงแผนภูมิเป็นส่วนหนึ่งของสไลด์ ดังนั้นไฟล์ที่ส่งออกเป็น [PDF](/slides/th/php-java/convert-powerpoint-to-pdf/)/[HTML](/slides/th/php-java/convert-powerpoint-to-html/)/[image](/slides/th/php-java/convert-powerpoint-to-png/) จะรวมแผนภูมิพร้อมตารางข้อมูลด้วย

**ตารางข้อมูลรองรับสำหรับแผนภูมิที่มาจากไฟล์แม่แบบหรือไม่?**

ใช่. สำหรับแผนภูมิใด ๆ ที่โหลดจากงานนำเสนอหรือแม่แบบที่มีอยู่แล้ว คุณสามารถตรวจสอบและเปลี่ยนแปลงว่าตารางข้อมูล [แสดง](https://reference.aspose.com/slides/th/php-java/aspose.slides/chart/hasdatatable/) หรือไม่โดยใช้คุณสมบัติของแผนภูมิ

**ฉันจะค้นหาแผนภูมิใดบ้างในไฟล์ที่เปิดใช้ตารางข้อมูลได้อย่างรวดเร็วอย่างไร?**

ตรวจสอบคุณสมบัติของแต่ละแผนภูมิที่ระบุว่าตารางข้อมูล [แสดง](https://reference.aspose.com/slides/th/php-java/aspose.slides/chart/hasdatatable/) หรือไม่และวนลูปผ่านสไลด์เพื่อระบุแผนภูมิที่เปิดใช้งานอยู่