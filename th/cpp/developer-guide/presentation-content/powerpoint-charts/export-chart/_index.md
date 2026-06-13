---
title: ส่งออกแผนภูมิการนำเสนอใน C++
linktitle: ส่งออกแผนภูมิ
type: docs
weight: 90
url: /th/cpp/export-chart/
keywords:
- แผนภูมิ
- แผนภูมิเพื่อเป็นภาพ
- แผนภูมิเป็นภาพ
- สกัดภาพแผนภูมิ
- PowerPoint
- การนำเสนอ
- C++
- Aspose.Slides
description: "เรียนรู้วิธีส่งออกแผนภูมิการนำเสนอด้วย Aspose.Slides สำหรับ C++ ที่รองรับรูปแบบ PPT และ PPTX และทำให้การรายงานเป็นกระบวนการที่ราบรื่นในทุกเวิร์กโฟลว์"
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณส่งออกแผนภูมิจากการนำเสนอเป็นรูปภาพ บทความนี้แสดงวิธีการดึงรูปภาพจากแผนภูมิและบันทึกไว้ ซึ่งเป็นประโยชน์เมื่อคุณต้องการนำภาพแผนภูมิกลับใช้ภายนอกการนำเสนอ PowerPoint

## **รับรูปภาพแผนภูมิ**
Aspose.Slides for C++ ให้การสนับสนุนการสกัดรูปภาพของแผนภูมิเฉพาะ ตัวอย่างต่อไปนี้แสดงให้เห็น

```cpp
auto presentation = MakeObject<Presentation>(u"test.pptx");

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 0, 0, 500, 500);

auto image = chart->GetImage();
image->Save(u"image.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **คำถามที่พบบ่อย**

**ฉันสามารถส่งออกแผนภูมิเป็นเวกเตอร์ (SVG) แทนรูปภาพแรสเตอร์ได้หรือไม่?**  
ได้. แผนภูมิเป็นรูปร่างและเนื้อหาของมันสามารถบันทึกเป็น SVG โดยใช้ [shape-to-SVG saving method](https://reference.aspose.com/slides/th/cpp/aspose.slides/shape/writeassvg/).

**ฉันจะตั้งขนาดที่แน่นอนของแผนภูมิที่ส่งออกเป็นพิกเซลได้อย่างไร?**  
ใช้ overload ของการเรนเดอร์รูปภาพที่ให้คุณระบุขนาดหรือสเกล—ไลบรารีสนับสนุนการเรนเดอร์อ็อบเจ็กต์ด้วยมิติ/สเกลที่กำหนด

**ควรทำอย่างไรหากฟอนต์ในป้ายรายการและคำอธิบายแสดงผลผิดหลังการส่งออก?**  
[โหลดฟอนต์ที่จำเป็น](/slides/th/cpp/custom-font/) ผ่าน [FontsLoader](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsloader/) เพื่อให้การเรนเดอร์แผนภูมิรักษาเมตริกและลักษณะข้อความ

**การส่งออกเคารพธีม สไตล์ และเอฟเฟกต์ของ PowerPoint หรือไม่?**  
ใช่. ตัวเรนเดอร์ของ Aspose.Slides ปฏิบัติตามการจัดรูปแบบของการนำเสนอ (ธีม, สไตล์, การเติม, เอฟเฟกต์) ดังนั้นลักษณะของแผนภูมิจึงถูกเก็บไว้

**ฉันจะหาความสามารถในการเรนเดอร์/ส่งออกที่มีอยู่นอกเหนือจากรูปภาพแผนภูมิได้จากที่ไหน?**  
ดูส่วนการส่งออกของ [API](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/)/[documentation](/slides/th/cpp/convert-powerpoint/) สำหรับเป้าหมายการออกผล ([PDF](/slides/th/cpp/convert-powerpoint-to-pdf/), [SVG](/slides/th/cpp/render-a-slide-as-an-svg-image/), [XPS](/slides/th/cpp/convert-powerpoint-to-xps/), [HTML](/slides/th/cpp/convert-powerpoint-to-html/), เป็นต้น) และตัวเลือกการเรนเดอร์ที่เกี่ยวข้อง