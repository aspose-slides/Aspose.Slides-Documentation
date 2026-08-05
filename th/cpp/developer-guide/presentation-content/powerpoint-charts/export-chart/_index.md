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
description: "เรียนรู้วิธีส่งออกแผนภูมิการนำเสนอด้วย Aspose.Slides สำหรับ C++ รองรับรูปแบบไฟล์ PPT และ PPTX และทำให้การรายงานเป็นกระบวนการที่ราบรื่นในทุกเวิร์กโฟลว์"
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณส่งออกแผนภูมิจากงานนำเสนอเป็นภาพ บทความนี้แสดงวิธีดึงภาพจากแผนภูมิและบันทึกไว้ ซึ่งมีประโยชน์เมื่อคุณต้องการนำภาพแผนภูมิไปใช้ซ้ำนอกงานนำเสนอ PowerPoint

## **รับภาพแผนภูมิ**
Aspose.Slides for C++ มีการสนับสนุนการสกัดภาพของแผนภูมิที่ระบุ ตัวอย่างด้านล่างแสดงให้ดู

```cpp
auto presentation = MakeObject<Presentation>(u"test.pptx");

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 0, 0, 500, 500);

auto image = chart->GetImage();
image->Save(u"image.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **FAQ**

**Can I export a chart as a vector (SVG) instead of a raster image?**

ใช่ แผนภูมิเป็นรูปทรงและเนื้อหาของมันสามารถบันทึกเป็น SVG ได้โดยใช้ [shape-to-SVG saving method](https://reference.aspose.com/slides/th/cpp/aspose.slides/shape/writeassvg/).

**How can I set the exact size of the exported chart in pixels?**

ใช้ฟังก์ชัน image-rendering overloads ที่ให้คุณระบุขนาดหรือสเกล—ไลบรารีรองรับการเรนเดอร์อ็อบเจ็กต์ด้วยมิติหรือสเกลที่กำหนด

**What should I do if fonts in labels and the legend look wrong after export?**

[โหลดฟอนต์ที่ต้องการ](/slides/th/cpp/custom-font/) ผ่าน [FontsLoader](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsloader/) เพื่อให้การเรนเดอร์แผนภูมิรักษาเมตริกซ์และลักษณะของข้อความ

**Does export honor the PowerPoint theme, styles, and effects?**

ใช่ เรเดอร์ของ Aspose.Slides ปฏิบัติตามการฟอร์แมตของงานนำเสนอ (ธีม, สไตล์, การเติมสี, เอฟเฟกต์) ดังนั้นลักษณะของแผนภูมิจะถูกเก็บไว้

**Where can I find available rendering/export capabilities beyond chart images?**

ดูส่วนการส่งออกของ [API](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/)/[documentation](/slides/th/cpp/convert-powerpoint/) เพื่อดูเป้าหมายการส่งออก ([PDF](/slides/th/cpp/convert-powerpoint-to-pdf/), [SVG](/slides/th/cpp/render-a-slide-as-an-svg-image/), [XPS](/slides/th/cpp/convert-powerpoint-to-xps/), [HTML](/slides/th/cpp/convert-powerpoint-to-html/), ฯลฯ) และตัวเลือกการเรนเดอร์ที่เกี่ยวข้อง