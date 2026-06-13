---
title: ปรับแต่งแผนภูมิโดนัตในงานนำเสนอด้วย PHP
linktitle: แผนภูมิโดนัต
type: docs
weight: 30
url: /th/php-java/doughnut-chart/
keywords:
- แผนภูมิโดนัต
- ช่องว่างศูนย์กลาง
- ขนาดรู
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "ค้นพบวิธีสร้างและปรับแต่งแผนภูมิโดนัตใน Aspose.Slides สำหรับ PHP ผ่าน Java รองรับรูปแบบ PowerPoint สำหรับการนำเสนอแบบไดนามิก"
---
## **ภาพรวม**

บทความนี้แสดงวิธีทำงานกับแผนภูมิโดนัตใน Aspose.Slides โดยการเพิ่มแผนภูมิลงในสไลด์ ตั้งค่าขนาดของรูศูนย์กลาง และบันทึกการนำเสนอ มุ่งเน้นที่เมธอด `setDoughnutHoleSize` และสาธิตขั้นตอนพื้นฐานที่จำเป็นสำหรับการปรับแต่งประเภทแผนภูมินี้ในโค้ด

บทความยังรวมส่วน FAQ สั้น ๆ ที่ครอบคลุมสถานการณ์ที่เกี่ยวข้องกับแผนภูมิโดนัต เช่น การใช้หลายซีรีส์เพื่อสร้างหลายแหวน การทำงานกับแผนภูมิ Exploded Doughnut และการส่งออกแผนภูมิเป็นภาพราสเตอร์หรือ SVG

## **กำหนดช่องว่างศูนย์กลางในแผนภูมิโดนัต**

เพื่อกำหนดขนาดของรูในแผนภูมิโดนัต โปรดทำตามขั้นตอนด้านล่าง:

1. สร้างอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation)
1. เพิ่มแผนภูมิโดนัตบนสไลด์
1. กำหนดขนาดของรูในแผนภูมิโดนัต
1. บันทึกการนำเสนอลงดิสก์

ในตัวอย่างด้านล่าง เราได้กำหนดขนาดของรูในแผนภูมิโดนัต

```php
  # สร้างอินสแตนซ์ของคลาส Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Doughnut, 50, 50, 400, 400);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setDoughnutHoleSize(90);
    # บันทึกงานนำเสนอลงดิสก์
    $pres->save("DoughnutHoleSize_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **คำถามที่พบบ่อย**

**ฉันสามารถสร้างโดนัทหลายระดับที่มีหลายแหวนได้หรือไม่?**

ใช่ การเพิ่มหลายซีรีส์ลงในแผนภูมิโดนัทเดียว—แต่ละซีรีส์จะกลายเป็นแหวนแยกต่างหาก ลำดับของแหวนจะกำหนดโดยลำดับของซีรีส์ในคอลเลกชัน

**โดนัทแบบ "exploded" (ชิ้นส่วนแยก) ได้รับการสนับสนุนหรือไม่?**

ใช่ มีประเภทแผนภูมิ Exploded Doughnut[chart type](https://reference.aspose.com/slides/th/php-java/aspose.slides/charttype/)และคุณสมบัติ explosion บนจุดข้อมูล; คุณสามารถแยกชิ้นส่วนแต่ละชิ้นได้

**ฉันจะรับภาพของแผนภูมิโดนัท (PNG/SVG) สำหรับรายงานได้อย่างไร?**

แผนภูมิเป็นรูปทรง; คุณสามารถเรนเดอร์เป็น[raster image](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/#getImage)หรือส่งออกแผนภูมิเป็น[SVG image](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/#writeAsSvg)ได้