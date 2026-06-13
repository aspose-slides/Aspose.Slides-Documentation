---
title: ส่งออกแผนภูมิการนำเสนอใน .NET
linktitle: ส่งออกแผนภูมิ
type: docs
weight: 90
url: /th/net/export-chart/
keywords:
- แผนภูมิ
- แผนภูมิเป็นภาพ
- แผนภูมิในรูปแบบภาพ
- สกัดภาพแผนภูมิ
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีส่งออกแผนภูมิการนำเสนอด้วย Aspose.Slides สำหรับ .NET รองรับรูปแบบ PPT และ PPTX และทำให้กระบวนการรายงานเป็นไปอย่างไร้รอยต่อในทุกเวิร์คโฟลว์"
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณสามารถส่งออกแผนภูมิจากงานนำเสนอเป็นภาพได้ บทความนี้แสดงวิธีดึงภาพจากแผนภูมิและบันทึก ซึ่งเป็นประโยชน์เมื่อคุณต้องการนำภาพแผนภูมิไปใช้ซ้ำนอกงานนำเสนอ PowerPoint  

นอกเหนือจากกระบวนการส่งออกภาพพื้นฐานแล้ว บทความนี้ยังตอบคำถามทั่วไปเกี่ยวกับการส่งออก รวมถึงการบันทึกเนื้อหาแผนภูมิเป็น SVG การควบคุมขนาดผลลัพธ์ผ่านตัวเลือกการเรนเดอร์ การโหลดฟอนต์เพื่อคงลักษณะของป้ายและคำอธิบาย และการรักษาการจัดรูปแบบงานนำเสนอเดิม เช่น ธีม, สไตล์, การเติมสี และเอฟเฟกต์ระหว่างการเรนเดอร์  

Aspose.Slides for .NET มีการรองรับการสกัดภาพของแผนภูมิที่ระบุ ตัวอย่างด้านล่างนี้ให้ไว้.  

```c#
using (Presentation presentation = new Presentation("test.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    using (IImage image = chart.GetImage())
    {
        image.Save("image.png", ImageFormat.Png);
    }
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถส่งออกแผนภูมิในรูปแบบเวกเตอร์ (SVG) แทนภาพแรสเตอร์ได้หรือไม่?**  
ได้เลย แผนภูมิเป็นรูปร่างและเนื้อหาของมันสามารถบันทึกเป็น SVG ได้โดยใช้ [วิธีการบันทึก shape-to-SVG](https://reference.aspose.com/slides/th/net/aspose.slides/shape/writeassvg/).

**ฉันจะกำหนดขนาดที่แน่นอนของแผนภูมิที่ส่งออกเป็นพิกเซลได้อย่างไร?**  
ใช้การ overload ของ image-rendering ที่ให้คุณระบุขนาดหรือสเกล — ไลบรารีรองรับการเรนเดอร์วัตถุด้วยมิติหรือสเกลที่กำหนด

**ควรทำอย่างไรหากฟอนต์ในป้ายและคำอธิบายแสดงผลไม่ถูกต้องหลังการส่งออก?**  
[โหลดฟอนต์ที่จำเป็น](/slides/th/net/custom-font/) ผ่าน [FontsLoader](https://reference.aspose.com/slides/th/net/aspose.slides/fontsloader/) เพื่อให้การเรนเดอร์แผนภูมิคงเมตริกและลักษณะของข้อความ

**การส่งออกเคารพธีม, สไตล์และเอฟเฟกต์ของ PowerPoint หรือไม่?**  
ใช้ได้ ตัวเรนเดอร์ของ Aspose.Slides ปฏิบัติตามการจัดรูปแบบของงานนำเสนอ (ธีม, สไตล์, การเติมสี, เอฟเฟกต์) ดังนั้นลักษณะของแผนภูมิจึงคงเดิม

**ฉันจะหาความสามารถในการเรนเดอร์/ส่งออกที่มีอยู่เพิ่มเติมนอกเหนือจากภาพแผนภูมิได้จากที่ไหน?**  
ดูส่วนการส่งออกของ [API](https://reference.aspose.com/slides/th/net/aspose.slides.export/)/[เอกสาร](/slides/th/net/convert-powerpoint/) สำหรับเป้าหมายผลลัพธ์ ([PDF](/slides/th/net/convert-powerpoint-to-pdf/), [SVG](/slides/th/net/render-a-slide-as-an-svg-image/), [XPS](/slides/th/net/convert-powerpoint-to-xps/), [HTML](/slides/th/net/convert-powerpoint-to-html/), เป็นต้น) และตัวเลือกการเรนเดอร์ที่เกี่ยวข้อง.