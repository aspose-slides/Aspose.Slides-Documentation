---
title: ปรับแต่งแผนภูมิบับเบิลในงานนำเสนอด้วย PHP
linktitle: แผนภูมิบับเบิล
type: docs
url: /th/php-java/bubble-chart/
keywords:
- แผนภูมิบับเบิล
- ขนาดบับเบิล
- การสเกลขนาด
- การแสดงผลขนาด
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "สร้างและปรับแต่งแผนภูมิบับเบิลที่ทรงพลังใน PowerPoint ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java เพื่อเสริมการแสดงผลข้อมูลของคุณได้อย่างง่ายดาย."
---
## **ภาพรวม**

บทความนี้แสดงวิธีการทำงานกับแผนภูมิบับเบิลใน Aspose.Slides ครอบคลุมตัวเลือกการปรับแต่งสองอย่างเฉพาะ: การปรับขนาดบับเบิลโดยใช้เมธอด `setBubbleSizeScale` และการควบคุมวิธีที่ค่าขนาดบับเบิลถูกแสดงโดยใช้เมธอด `setBubbleSizeRepresentation`.

ตัวอย่างจะแสดงวิธีการสร้างแผนภูมิบับเบิล ปรับการสเกลขนาดของมัน และสลับการแสดงค่าขนาดบับเบิลให้ใช้ความกว้าง บทความยังรวมส่วน FAQ สั้น ๆ ที่อธิบายการสนับสนุนประเภทแผนภูมิ “Bubble with 3-D” หมายเหตุว่าขีดจำกัดเชิงปฏิบัติของแผนภูมิจะแตกต่างตามประสิทธิภาพและเวอร์ชัน PowerPoint เป้าหมาย และอธิบายว่าการส่งออกจะคงลักษณะของแผนภูมิผ่านเอนจินการเรนเดอร์ของ Aspose.Slides

## **การสเกลขนาดแผนภูมิบับเบิล**
Aspose.Slides for PHP via Java ให้การสนับสนุนการสเกลขนาดของแผนภูมิบับเบิล ใน Aspose.Slides for PHP via Java [**ChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseries/getbubblesizescale/), [**ChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseriesgroup/getbubblesizescale/) และ [**ChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseriesgroup/setbubblesizescale/) ได้ถูกเพิ่มเข้าไป ตัวอย่างโค้ดด้านล่างนี้

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 100, 100, 400, 300);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setBubbleSizeScale(150);
    $pres->save("Result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **แสดงข้อมูลเป็นขนาดบับเบิล**
เมธอด [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseriesgroup/setbubblesizerepresentation/) และ [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseriesgroup/getbubblesizerepresentation/) ได้ถูกเพิ่มลงในคลาส [ChartSeries](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseries/), [ChartSeriesGroup](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseriesgroup/) และคลาสที่เกี่ยวข้อง **BubbleSizeRepresentation** ระบุวิธีที่ค่าขนาดบับเบิลถูกนำเสนอในแผนภูมิบับเบิล ค่าได้แก่: [**BubbleSizeRepresentationType::Area**](https://reference.aspose.com/slides/th/php-java/aspose.slides/BubbleSizeRepresentationType#Area) และ [**BubbleSizeRepresentationType::Width**](https://reference.aspose.com/slides/th/php-java/aspose.slides/BubbleSizeRepresentationType#Width) ตามนั้นได้มีการเพิ่ม enum [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/th/php-java/aspose.slides/BubbleSizeRepresentationType) เพื่อระบุวิธีที่เป็นไปได้ในการแสดงข้อมูลเป็นขนาดบับเบิล ตัวอย่างโค้ดอยู่ด้านล่าง

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 600, 400, true);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setBubbleSizeRepresentation(BubbleSizeRepresentationType::Width);
    $pres->save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**แผนภูมิ “Bubble with 3-D effect” ได้รับการสนับสนุนหรือไม่ และมีความแตกต่างจากแผนภูมิปกติอย่างไร?**

ใช่ มีประเภทแผนภูมิเฉพาะ “Bubble with 3-D” ซึ่งใช้สไตล์ 3 มิติบนบับเบิลแต่ไม่ได้เพิ่มแกนเพิ่มเติม; ข้อมูลยังคงเป็น X‑Y‑S (ขนาด) ประเภทนี้สามารถเลือกได้ในคลาส [chart type](https://reference.aspose.com/slides/th/php-java/aspose.slides/charttype/)

**มีขีดจำกัดจำนวนซีรีส์และจุดในแผนภูบับเบิลหรือไม่?**

ไม่มีขีดจำกัดที่กำหนดไว้ระดับ API; ข้อจำกัดขึ้นอยู่กับประสิทธิภาพและเวอร์ชัน PowerPoint ที่เป้าหมาย แนะนำให้จำนวนจุดอยู่ในระดับที่เหมาะสมเพื่อความอ่านง่ายและความเร็วในการเรนเดอร์

**การส่งออกจะมีผลต่อการแสดงผลของแผนภูมิบับเบิล (PDF, รูปภาพ) อย่างไร?**

การส่งออกเป็นฟอร์แมตที่รองรับจะคงลักษณะของแผนภูมิ; การเรนเดอร์ดำเนินการโดยเอนจิน Aspose.Slides สำหรับฟอร์แมตแบบแรสเตอร์/เวกเตอร์ จะใช้กฎการเรนเดอร์กราฟิกของแผนภูมิโดยทั่วไป (ความละเอียด, การตัดขอบ) ดังนั้นควรเลือก DPI ที่เพียงพอสำหรับการพิมพ์