---
title: ปรับแต่งคำอธิบายแผนภูมิในงานนำเสนอโดยใช้ Java
linktitle: คำอธิบายแผนภูมิ
type: docs
url: /th/java/chart-legend/
keywords:
  - คำอธิบายแผนภูมิ
  - ตำแหน่งคำอธิบาย
  - ขนาดฟอนต์
  - PowerPoint
  - งานนำเสนอ
  - Java
  - Aspose.Slides
description: "ปรับแต่งคำอธิบายแผนภูมิด้วย Aspose.Slides สำหรับ Java เพื่อเพิ่มประสิทธิภาพงานนำเสนอ PowerPoint ด้วยการจัดรูปแบบคำอธิบายที่กำหนดเอง."
---
## **ภาพรวม**

Aspose.Slides มีตัวเลือกสำหรับการปรับแต่งคำอธิบายแผนภูมิในงานนำเสนอ PowerPoint บทความนี้แสดงวิธีการกำหนตำแหน่งและขนาดของคำอธิบาย, ตั้งขนาดฟอนต์สำหรับคำอธิบายทั้งหมด, และใช้การจัดรูปแบบกับรายการคำอธิบายแต่ละรายการ.

นอกจากนี้ยังครอบคลุมพฤติกรรมที่เกี่ยวข้องหลายอย่างในคำถามที่พบบ่อย, รวมถึงการใช้โหมดไม่ซ้อนทับเพื่อให้พื้นที่แผนภูมิมีที่ว่างสำหรับคำอธิบาย, การอนุญาตให้ป้ายคำอธิบายยาวห่อหุ้มหรือใช้การขึ้นบรรทัดใหม่, และการให้การจัดรูปแบบของคำอธิบายสืบทอดจากธีมของงานนำเสนอเมื่อไม่ได้กำหนดข้อความและการเติมสีอย่างชัดเจน.

## **การกำหนดตำแหน่งคำอธิบาย**
เพื่อกำหนดคุณสมบัติของคำอธิบาย โปรดทำตามขั้นตอนต่อไปนี้:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)
- ดึงอ้างอิงของสไลด์
- เพิ่มแผนภูมิบนสไลด์
- ตั้งค่าคุณสมบัติของคำอธิบาย
- บันทึกงานนำเสนอเป็นไฟล์ PPTX

ในตัวอย่างด้านล่าง เราได้ตั้งค่าตำแหน่งและขนาดสำหรับคำอธิบายแผนภูมิ.

```java
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation();
try {
    // รับอ้างอิงของสไลด์
    ISlide slide = pres.getSlides().get_Item(0);
    
    // เพิ่มแผนภูมิคอลัมน์แบบกลุ่มบนสไลด์
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);
    
    // ตั้งค่าคุณสมบัติของคำอธิบาย
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    
    // บันทึกงานนำเสนอลงดิสก์
    pres.save("Legend_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ตั้งค่าขนาดฟอนต์ของคำอธิบาย**
Aspose.Slides for Java ให้ผู้พัฒนาสามารถตั้งค่าขนาดฟอนต์ของคำอธิบายได้ โปรดทำตามขั้นตอนต่อไปนี้:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)
- สร้างแผนภูมิเริ่มต้น
- ตั้งค่าขนาดฟอนต์
- ตั้งค่าค่าต่ำสุดของแกน
- ตั้งค่าสูงสุดของแกน
- บันทึกงานนำเสนอลงดิสก์

```java
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);

    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ตั้งค่าขนาดฟอนต์ของคำอธิบายแต่ละรายการ**
Aspose.Slides for Java ให้ผู้พัฒนาสามารถตั้งค่าขนาดฟอนต์ของรายการคำอธิบายแต่ละรายการได้ โปรดทำตามขั้นตอนต่อไปนี้:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)
- สร้างแผนภูมิเริ่มต้น
- เข้าถึงรายการคำอธิบาย
- ตั้งค่าขนาดฟอนต์
- ตั้งค่าค่าต่ำสุดของแกน
- ตั้งค่าสูงสุดของแกน
- บันทึกงานนำเสนอลงดิสก์

```java
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    IChartTextFormat tf = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    tf.getPortionFormat().setFontBold(NullableBool.True);
    tf.getPortionFormat().setFontHeight(20);
    tf.getPortionFormat().setFontItalic(NullableBool.True);
    tf.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    tf.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถเปิดใช้งานคำอธิบายเพื่อให้แผนภูกกำหนดพื้นที่ให้โดยอัตโนมัติแทนการซ้อนทับได้หรือไม่?**  
**ใช่**. ใช้โหมดไม่ซ้อนทับ ([setOverlay(false)](https://reference.aspose.com/slides/th/java/com.aspose.slides/legend/#setOverlay-boolean-)); ในกรณีนี้ พื้นที่แผนภูมิจะหดลงเพื่อรองรับคำอธิบาย.

**ฉันสามารถทำให้ป้ายคำอธิบายหลายบรรทัดได้หรือไม่?**  
**ใช่**. ป้ายที่ยาวจะห่อหุ้มอัตโนมัติเมื่อพื้นที่ไม่พอ; การบังคับขึ้นบรรทัดใหม่รองรับโดยใช้ตัวอักษร newline ในชื่อซีรีส์.

**ฉันจะทำให้คำอธิบายสืบทอดสีตามธีมของงานนำเสนอได้อย่างไร?**  
**ไม่ต้องกำหนดสี/การเติม/ฟอนต์อย่างชัดเจนสำหรับคำอธิบายหรือข้อความของมัน**. พวกมันจะสืบทอดจากธีมและอัปเดตอย่างถูกต้องเมื่อการออกแบบเปลี่ยนแปลง.