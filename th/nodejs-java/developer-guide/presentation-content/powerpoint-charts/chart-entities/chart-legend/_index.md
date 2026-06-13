---
title: ปรับแต่งคำบรรยายแผนภูมิในงานนำเสนอด้วย JavaScript
linktitle: คำบรรยายแผนภูมิ
type: docs
url: /th/nodejs-java/chart-legend/
keywords:
- คำบรรยายแผนภูมิ
- ตำแหน่งคำบรรยาย
- ขนาดฟอนต์
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ปรับแต่งคำบรรยายแผนภูมิด้วย JavaScript และ Aspose.Slides สำหรับ Node.js เพื่อเพิ่มประสิทธิภาพงานนำเสนอ PowerPoint ด้วยการจัดรูปแบบคำบรรยายที่กำหนดเอง."
---
## **ภาพรวม**

Aspose.Slides มีตัวเลือกสำหรับการปรับแต่งคำบรรยายของแผนภูมิในงานนำเสนอ PowerPoint บทความนี้แสดงวิธีการกำหนดตำแหน่งและขนาดของคำบรรยาย ตั้งขนาดฟอนต์สำหรับคำบรรยายทั้งหมด และใช้การจัดรูปแบบกับรายการคำบรรยายแต่ละรายการ.  
บทความยังครอบคลุมพฤติกรรมที่เกี่ยวข้องหลายอย่างในส่วนคำถามที่พบบ่อย รวมถึงการใช้โหมดไม่ซ้อนกันเพื่อให้พื้นที่พล็อตทำให้มีที่ว่างสำหรับคำบรรยาย การอนุญาตให้ป้ายคำบรรยายยาวห่อหุ้มหรือใช้การย่อบรรทัด และให้การจัดรูปแบบของคำบรรยายสืบทอดจากธีมของงานนำเสนอเมื่อไม่ได้ตั้งค่าข้อความและพื้นสีอย่างชัดเจน.

## **การกำหนดตำแหน่งคำบรรยาย**

เพื่อกำหนดคุณสมบัติของคำบรรยาย กรุณาติดตามขั้นตอนด้านล่าง:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation)
- รับอ้างอิงของสไลด์
- เพิ่มแผนภูมิบนสไลด์
- ตั้งค่าคุณสมบัติของคำบรรยาย
- เขียนงานนำเสนอเป็นไฟล์ PPTX

ในตัวอย่างด้านล่าง เราได้ตั้งค่าตำแหน่งและขนาดสำหรับคำบรรยายของแผนภูมิ.

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation
var pres = new aspose.slides.Presentation();
try {
    // รับอ้างอิงของสไลด์
    var slide = pres.getSlides().get_Item(0);
    // เพิ่มแผนภูมิคอลัมน์แบบกลุ่มบนสไลด์
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 500);
    // ตั้งค่าคุณสมบัติของคำบรรยาย
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    // บันทึกงานนำเสนอลงดิสก์
    pres.save("Legend_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ตั้งค่าขนาดฟอนต์ของคำบรรยาย**

Aspose.Slides สำหรับ Node.js ผ่าน Java ทำให้ผู้พัฒนาสามารถตั้งค่าขนาดฟอนต์ของคำบรรยายได้ กรุณาติดตามขั้นตอนด้านล่าง:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation)
- สร้างแผนภูมิเริ่มต้น
- ตั้งค่าขนาดฟอนต์
- ตั้งค่าค่าต่ำสุดของแกน
- ตั้งค่าค่าสูงสุดของแกน
- บันทึกงานนำเสนอลงดิสก์

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ตั้งค่าขนาดฟอนต์ของคำบรรยายแต่ละรายการ**

Aspose.Slides สำหรับ Node.js ผ่าน Java ทำให้ผู้พัฒนาสามารถตั้งค่าขนาดฟอนต์ของรายการคำบรรยายแต่ละรายการได้ กรุณาติดตามขั้นตอนด้านล่าง:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation)
- สร้างแผนภูมิเริ่มต้น
- เข้าถึงรายการคำบรรยาย
- ตั้งค่าขนาดฟอนต์
- ตั้งค่าค่าต่ำสุดของแกน
- ตั้งค่าค่าสูงสุดของแกน
- บันทึกงานนำเสนอลงดิสก์

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var tf = chart.getLegend().getEntries().get_Item(1).getTextFormat();
    tf.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    tf.getPortionFormat().setFontHeight(20);
    tf.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    tf.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    tf.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถเปิดใช้งานคำบรรยายเพื่อให้แผนภูมิจัดสรรพื้นที่ให้โดยอัตโนมัติแทนการซ้อนกันได้หรือไม่?**  
ใช่ ใช้โหมดไม่ซ้อนกัน ([setOverlay(false)](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/legend/setoverlay/)); ในกรณีนี้ พื้นที่พล็อตจะหดลงเพื่อรองรับคำบรรยาย.

**ฉันสามารถทำให้ป้ายคำบรรยายหลายบรรทัดได้หรือไม่?**  
ใช่ ป้ายที่ยาวจะห่อหุ้มโดยอัตโนมัติเมื่อตำแหน่งไม่พอ; การบังคับให้ขึ้นบรรทัดใหม่สนับสนุนโดยอักขระ newline ในชื่อซีรีส์.

**ฉันจะทำให้คำบรรยายสอดคล้องกับโครงสร้างสีของธีมงานนำเสนอได้อย่างไร?**  
อย่า ตั้งค่าสี/พื้น/ฟอนต์อย่างเจาะจงสำหรับคำบรรยายหรือข้อความของมัน ระบบจะสืบทอดจากธีมและอัพเดตอย่างถูกต้องเมื่อการออกแบบเปลี่ยนแปลง.