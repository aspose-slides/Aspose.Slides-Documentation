---
title: สร้างแอนิเมชันแผนภูมิ PowerPoint ใน JavaScript
linktitle: แผนภูมิแอนิเมชัน
type: docs
weight: 80
url: /th/nodejs-java/animated-charts/
keywords:
- แผนภูมิ
- แผนภูมิแอนิเมชัน
- แอนิเมชันแผนภูมิ
- ซีรีส์แผนภูมิ
- หมวดหมู่แผนภูมิ
- องค์ประกอบซีรีส์
- องค์ประกอบหมวดหมู่
- เพิ่มเอฟเฟกต์
- ประเภทเอฟเฟกต์
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "สร้างแผนภูมิแอนิเมชันที่น่าตื่นตาตื่นใจใน JavaScript ด้วย Aspose.Slides สำหรับ Node.js. เพิ่มประสิทธิภาพงานนำเสนอด้วยภาพเคลื่อนไหวในไฟล์ PPT และ PPTX—เริ่มต้นเลยตอนนี้."
---
## **บทนำ**

Aspose.Slides for Node.js via Java รองรับการทำแอนิเมชันขององค์ประกอบแผนภูมิ. **Series**, **Categories**, **Series Elements**, **Categories Elements** สามารถทำแอนิเมชันได้ด้วยเมธอด [Sequence.addEffect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sequence/#addEffect) และสอง enum [EffectChartMajorGroupingType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/effectchartmajorgroupingtype/) และ [EffectChartMinorGroupingType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/effectchartminorgroupingtype/).

## **การทำแอนิเมชันซีรีส์ของแผนภูมิ**
หากคุณต้องการทำแอนิเมชันซีรีส์ของแผนภูมิ ให้เขียนโค้ดตามขั้นตอนด้านล่าง:

1. โหลดงานนำเสนอ.
2. รับอ้างอิงของอ็อบเจกต์แผนภูมิ.
3. ทำแอนิเมชันซีรีส์.
4. บันทึกไฟล์งานนำเสนอลงดิสก์.

ในตัวอย่างด้านล่าง เราได้ทำแอนิเมชันซีรีส์ของแผนภูมิ.

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์งานนำเสนอ
var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    // รับอ้างอิงของอ็อบเจกต์แผนภูมิ
    var slide = pres.getSlides().get_Item(0);
    var shapes = slide.getShapes();
    var chart = shapes.get_Item(0);
    // ทำแอนิเมชันซีรีส์
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.BySeries, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.BySeries, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.BySeries, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.BySeries, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    // เขียนงานนำเสนอที่แก้ไขแล้วลงดิสก์
    pres.save("AnimatingSeries_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **การทำแอนิเมชันหมวดหมู่ของแผนภูมิ**
หากคุณต้องการทำแอนิเมชันหมวดหมู่ของแผนภูมิ ให้เขียนโค้ดตามขั้นตอนด้านล่าง:

1. โหลดงานนำเสนอ.
2. รับอ้างอิงของอ็อบเจกต์แผนภูมิ.
3. ทำแอนิเมชันหมวดหมู่.
4. บันทึกไฟล์งานนำเสนอลงดิสก์.

ในตัวอย่างด้านล่าง เราได้ทำแอนิเมชันหมวดหมู่ของแผนภูมิ.

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์งานนำเสนอ
var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var shapes = slide.getShapes();
    var chart = shapes.get_Item(0);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.ByCategory, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.ByCategory, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.ByCategory, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.ByCategory, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    pres.save("Sample_Animation_C.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **การทำแอนิเมชันในองค์ประกอบซีรีส์**
หากคุณต้องการทำแอนิเมชันองค์ประกอบซีรีส์ ให้เขียนโค้ดตามขั้นตอนด้านล่าง:

1. โหลดงานนำเสนอ.
2. รับอ้างอิงของอ็อบเจกต์แผนภูมิ.
3. ทำแอนิเมชันองค์ประกอบซีรีส์.
4. บันทึกไฟล์งานนำเสนอลงดิสก์.

ในตัวอย่างด้านล่าง เราได้ทำแอนิเมชันองค์ประกอบของซีรีส์.

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์งานนำเสนอ
var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    // รับอ้างอิงของอ็อบเจกต์แผนภูมิ
    var slide = pres.getSlides().get_Item(0);
    var shapes = slide.getShapes();
    var chart = shapes.get_Item(0);
    // ทำแอนิเมชันองค์ประกอบซีรีส์
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 0, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 0, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 0, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 0, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 1, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 1, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 1, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 1, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 2, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 2, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 2, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 2, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    // เขียนไฟล์งานนำเสนอลงดิสก์
    pres.save("AnimatingSeriesElements_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **การทำแอนิเมชันในองค์ประกอบหมวดหมู่**
หากคุณต้องการทำแอนิเมชันองค์ประกอบหมวดหมู่ ให้เขียนโค้ดตามขั้นตอนด้านล่าง:

1. โหลดงานนำเสนอ.
2. รับอ้างอิงของอ็อบเจกต์แผนภูมิ.
3. ทำแอนิเมชันองค์ประกอบหมวดหมู่.
4. บันทึกไฟล์งานนำเสนอลงดิสก์.

ในตัวอย่างด้านล่าง เราได้ทำแอนิเมชันองค์ประกอบของหมวดหมู่.

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์งานนำเสนอ
var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    // รับอ้างอิงของอ็อบเจกต์แผนภูมิ
    var slide = pres.getSlides().get_Item(0);
    var shapes = slide.getShapes();
    var chart = shapes.get_Item(0);
    // ทำแอนิเมชันองค์ประกอบของหมวดหมู่
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 0, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 0, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 0, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 0, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 1, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 1, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 1, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 1, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 2, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 2, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 2, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 2, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    // เขียนไฟล์งานนำเสนอลงดิสก์
    pres.save("AnimatingCategoriesElements_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**รูปแบบเอฟเฟกต์ที่แตกต่าง (เช่น การเข้าสู่, การเน้น, การออก) รองรับสำหรับแผนภูมิเช่นเดียวกับรูปทรงปกติหรือไม่?**

ใช่. แผนภูมิจัดเป็นรูปทรงหนึ่ง ดังนั้นจึงรองรับรูปแบบเอฟเฟกต์การทำแอนิเมชันมาตรฐาน รวมถึงการเข้าสู่, การเน้น, และการออก โดยสามารถควบคุมได้เต็มที่ผ่านไทม์ไลน์ของสไลด์และลำดับการทำแอนิเมชัน.

**ฉันสามารถรวมการทำแอนิเมชันแผนภูมิกับการเปลี่ยนสไลด์ได้หรือไม่?**

ใช่. [Transitions](/slides/th/nodejs-java/slide-transition/) ใช้กับสไลด์ ในขณะที่เอฟเฟกต์การทำแอนิเมชันใช้กับวัตถุบนสไลด์ คุณสามารถใช้ทั้งสองร่วมกันในงานนำเสนอเดียวและควบคุมแยกกันได้.

**การทำแอนิเมชันของแผนภูมิจะถูกเก็บไว้เมื่อตอนบันทึกเป็น PPTX หรือไม่?**

ใช่. เมื่อคุณ [save to PPTX](/slides/th/nodejs-java/save-presentation/) เอฟเฟกต์การทำแอนิเมชันทั้งหมดและลำดับของมันจะถูกเก็บไว้เนื่องจากเป็นส่วนหนึ่งของโมเดลการทำแอนิเมชันดิบของงานนำเสนอ.

**ฉันสามารถอ่านการทำแอนิเมชันแผนภูมิที่มีอยู่จากงานนำเสนอและแก้ไขได้หรือไม่?**

ใช่. API ให้การเข้าถึงไทม์ไลน์ของสไลด์, ลำดับ, และเอฟเฟกต์ ทำให้คุณสามารถตรวจสอบการทำแอนิเมชันแผนภูมิที่มีอยู่และปรับเปลี่ยนได้โดยไม่ต้องสร้างใหม่ทั้งหมดจากศูนย์.

**ฉันสามารถสร้างวิดีโอที่รวมการทำแอนิเมชันแผนภูมิด้วย Aspose.Slides ได้หรือไม่?**

ใช่. คุณสามารถ [export a presentation to video](/slides/th/nodejs-java/convert-powerpoint-to-video/) พร้อมเก็บเอฟเฟกต์การทำแอนิเมชัน, ตั้งค่าการเวลาและการตั้งค่าอื่นๆ ของการส่งออก เพื่อให้คลิปที่ได้สะท้อนการเล่นแบบแอนิเมชัน.