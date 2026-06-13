---
title: ปรับแต่งคำอธิบายแผนภูมิในงานนำเสนอบน Android
linktitle: คำอธิบายแผนภูมิ
type: docs
url: /th/androidjava/chart-legend/
keywords:
- คำอธิบายแผนภูมิ
- ตำแหน่งคำอธิบาย
- ขนาดฟอนต์
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ปรับแต่งคำอธิบายแผนภูมิด้วย Aspose.Slides for Android via Java เพื่อเพิ่มประสิทธิภาพงานนำเสนอ PowerPoint ด้วยรูปแบบคำอธิบายที่กำหนดเอง."
---
## **ภาพรวม**

Aspose.Slides มีตัวเลือกสำหรับการปรับแต่งคำอธิบายแผนภูมิในงานนำเสนอ PowerPoint บทความนี้จะแสดงวิธีกำหนดตำแหน่งและขนาดของคำอธิบาย, ตั้งค่าขนาดฟอนต์สำหรับคำอธิบายทั้งหมด, และนำรูปแบบไปใช้กับรายการคำอธิบายเฉพาะรายการหนึ่ง

บทความยังครอบคลุมพฤติกรรมที่เกี่ยวข้องหลายอย่างในส่วน FAQ รวมถึงการใช้โหมดไม่ทับซ้อนเพื่อให้พื้นที่วางแผนภูมิให้ที่สำหรับคำอธิบาย, การให้ป้ายคำอธิบายยาวสามารถตัดบรรทัดหรือใช้การขึ้นบรรทัดใหม่, และการทำให้รูปแบบของคำอธิบายสืบทอดจากธีมของงานนำเสนอเมื่อไม่ได้ตั้งค่าข้อความและการเติมสีอย่างชัดเจน

## **การกำหนดตำแหน่งของคำอธิบาย**
เพื่อกำหนดคุณสมบัติของคำอธิบาย โปรดทำตามขั้นตอนต่อไปนี้:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)
- รับอ้างอิงของสไลด์
- เพิ่มแผนภูมิบนสไลด์
- ตั้งค่าคุณสมบัติของคำอธิบาย
- บันทึกการนำเสนอเป็นไฟล์ PPTX

ในตัวอย่างด้านล่าง เราได้ตั้งค่าตำแหน่งและขนาดสำหรับคำอธิบายแผนภูมิ

```java
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation();
try {
    // รับอ้างอิงของสไลด์
    ISlide slide = pres.getSlides().get_Item(0);
    
    // เพิ่มแผนภูมิคอลัมน์แบบกลุ่มบนสไลด์
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);
    
    // ตั้งค่าคุณสมบัติของ Legend
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    
    // เขียนงานนำเสนอลงดิสก์
    pres.save("Legend_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ตั้งค่าขนาดฟอนต์ของคำอธิบาย**
Aspose.Slides for Android via Java ให้ผู้พัฒนาตั้งค่าขนาดฟอนต์ของคำอธิบาย โปรดทำตามขั้นตอนต่อไปนี้:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)
- สร้างแผนภูมิเริ่มต้น
- ตั้งค่าขนาดฟอนต์
- ตั้งค่าค่าต่ำสุดของแกน
- ตั้งค่าสูงสุดของแกน
- บันทึกการนำเสนอลงดิสก์

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

## **ตั้งค่าขนาดฟอนต์ของคำอธิบายรายการใดรายการหนึ่ง**
Aspose.Slides for Android via Java ให้ผู้พัฒนาตั้งค่าขนาดฟอนต์ของรายการคำอธิบายเฉพาะ โปรดทำตามขั้นตอนต่อไปนี้:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)
- สร้างแผนภูมิเริ่มต้น
- เข้าถึงรายการคำอธิบาย
- ตั้งค่าขนาดฟอนต์
- ตั้งค่าค่าต่ำสุดของแกน
- ตั้งค่าสูงสุดของแกน
- บันทึกการนำเสนอลงดิสก์

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

## **FAQ**

**ฉันสามารถเปิดใช้งานคำอธิบายให้แผนภูมจัดสรรพื้นที่ให้โดยอัตโนมัติโดยไม่ทับซ้อนได้หรือไม่?**

ใช่ ใช้โหมดไม่ทับซ้อน ([setOverlay(false)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/legend/#setOverlay-boolean-)); ในกรณีนี้ พื้นที่แผนภูมิจะหดเล็กลงเพื่อรองรับคำอธิบาย

**ฉันสามารถทำป้ายคำอธิบายหลายบรรทัดได้หรือไม่?**

ใช่ ป้ายยาวจะตัดบรรทัดอัตโนมัติเมื่อพื้นที่ไม่เพียงพอ; การบังคับขึ้นบรรทัดใหม่รองรับโดยใช้ตัวอักษร newline ในชื่อซีรีส์

**ฉันจะทำให้คำอธิบายสอดคล้องกับโทนสีของธีมงานนำเสนอได้อย่างไร?**

ไม่ตั้งค่าสี/การเติม/ฟอนต์อย่างชัดเจนสำหรับคำอธิบายหรือข้อความของมัน คำอธิบายจะสืบทอดจากธีมและจะอัปเดตอย่างถูกต้องเมื่อการออกแบบเปลี่ยนแปลง