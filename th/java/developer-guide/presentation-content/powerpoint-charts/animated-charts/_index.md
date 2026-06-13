---
title: สร้างแอนิเมชันแผนภูมิ PowerPoint ใน Java
linktitle: แผนภูมิที่เคลื่อนไหว
type: docs
weight: 80
url: /th/java/animated-charts/
keywords:
- แผนภูมิ
- แผนภูมิเคลื่อนไหว
- การแอนิเมชันแผนภูมิ
- ซีรีส์แผนภูมิ
- หมวดหมู่แผนภูมิ
- องค์ประกอบซีรีส์
- องค์ประกอบหมวดหมู่
- เพิ่มเอฟเฟกต์
- ประเภทเอฟเฟกต์
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "สร้างแผนภูมิเคลื่อนไหวที่น่าประทับใจใน Java ด้วย Aspose.Slides. ยกระดับการนำเสนอด้วยภาพเคลื่อนไหวแบบไดนามิกในไฟล์ PPT และ PPTX—เริ่มต้นได้เลยตอนนี้."
---
## **คำนำ**

Aspose.Slides for Java รองรับการทำแอนิเมชันให้กับองค์ประกอบของแผนภูมิ **Series**, **Categories**, **Series Elements**, **Categories Elements** สามารถทำแอนิเมชันได้ด้วยเมธอด [ISequence.addEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISequence#addEffect-com.aspose.slides.IChart-int-int-int-int-int-) และสอง enum คือ [EffectChartMajorGroupingType](https://reference.aspose.com/slides/th/java/com.aspose.slides/EffectChartMajorGroupingType) และ [EffectChartMinorGroupingType](https://reference.aspose.com/slides/th/java/com.aspose.slides/EffectChartMinorGroupingType)

## **การแอนิเมชันซีรีส์แผนภูมิ**
หากคุณต้องการทำแอนิเมชันซีรีส์ของแผนภูมิ ให้เขียนโค้ดตามขั้นตอนด้านล่าง:

1. โหลดพรีเซนเทชัน.
1. ดึงอ้างอิงของออบเจกต์แผนภูมิ.
1. ทำแอนิเมชันให้กับซีรีส์.
1. เขียนไฟล์พรีเซนเทชันไปยังดิสก์.

ในตัวอย่างด้านล่าง เราได้ทำแอนิเมชันซีรีส์ของแผนภูมิ.

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์พรีเซนเทชัน
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // ดึงอ้างอิงของออบเจกต์แผนภูมิ
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // ทำแอนิเมชันให้กับซีรีส์
    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None,
            EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 0,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 1,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 2,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 3,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // เขียนพรีเซนเทชันที่แก้ไขแล้วลงดิสก์
    pres.save("AnimatingSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **การแอนิเมชันหมวดหมู่ของแผนภูมิ**
หากคุณต้องการทำแอนิเมชันหมวดหมู่ของแผนภูมิ ให้เขียนโค้ดตามขั้นตอนด้านล่าง:

1. โหลดพรีเซนเทชัน.
1. ดึงอ้างอิงของออบเจกต์แผนภูมิ.
1. ทำแอนิเมชันให้กับหมวดหมู่.
1. เขียนไฟล์พรีเซนเทชันไปยังดิสก์.

ในตัวอย่างด้านล่าง เราได้ทำแอนิเมชันหมวดหมู่ของแผนภูมิ.

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์พรีเซนเทชัน
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None,
            EffectTriggerType.AfterPrevious);

    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.ByCategory, 0, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    
    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart, 
            EffectChartMajorGroupingType.ByCategory, 1, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    
    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart, 
            EffectChartMajorGroupingType.ByCategory, 2, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    
    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart, 
            EffectChartMajorGroupingType.ByCategory, 3, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    pres.save("Sample_Animation_C.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **การแอนิเมชันในองค์ประกอบของซีรีส์**
หากคุณต้องการทำแอนิเมชันองค์ประกอบของซีรีส์ ให้เขียนโค้ดตามขั้นตอนด้านล่าง:

1. โหลดพรีเซนเทชัน.
1. ดึงอ้างอิงของออบเจกต์แผนภูมิ.
1. ทำแอนิเมชันให้กับองค์ประกอบของซีรีส์.
1. เขียนไฟล์พรีเซนเทชันไปยังดิสก์.

ในตัวอย่างด้านล่าง เราได้ทำแอนิเมชันองค์ประกอบของซีรีส์.

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์พรีเซนเทชัน
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // ดึงอ้างอิงของออบเจกต์แผนภูมิ
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // ทำแอนิเมชันให้กับองค์ประกอบของซีรีส์
    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // เขียนไฟล์พรีเซนเทชันลงดิสก์ 
    pres.save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **การแอนิเมชันในองค์ประกอบของหมวดหมู่**
หากคุณต้องการทำแอนิเมชันองค์ประกอบของหมวดหมู่ ให้เขียนโค้ดตามขั้นตอนด้านล่าง:

1. โหลดพรีเซนเทชัน.
1. ดึงอ้างอิงของออบเจกต์แผนภูมิ.
1. ทำแอนิเมชันให้กับองค์ประกอบของหมวดหมู่.
1. เขียนไฟล์พรีเซนเทชันไปยังดิสก์.

ในตัวอย่างด้านล่าง เราได้ทำแอนิเมชันองค์ประกอบของหมวดหมู่.

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์พรีเซนเทชัน
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // ดึงอ้างอิงของออบเจกต์แผนภูมิ
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // ทำแอนิเมชันให้กับองค์ประกอบของหมวดหมู่
    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // เขียนไฟล์พรีเซนเทชันลงดิสก์
    pres.save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **คำถามที่พบบ่อย**

**ประเภทเอฟเฟกต์ที่ต่างกัน (เช่น การเข้า, การเน้น, การออก) รองรับสำหรับแผนภูมิแบบเดียวกับรูปร่างทั่วไปหรือไม่?**

ใช่. แผนภูมิถือเป็นรูปร่าง ดังนั้นจึงรองรับประเภทเอฟเฟกต์แอนิเมชันมาตรฐาน รวมถึงการเข้า, การเน้น, และการออก โดยสามารถควบคุมเต็มที่ผ่านไทม์ไลน์และลำดับแอนิเมชันของสไลด์.

**Can I combine chart animation with slide transitions?**

ใช่. [Transitions](/slides/th/java/slide-transition/) ใช้กับสไลด์ ในขณะที่เอฟเฟกต์แอนิเมชันใช้กับออบเจกต์บนสไลด์ คุณสามารถใช้ทั้งสองร่วมกันในพรีเซนเทชันเดียวกันและควบคุมแยกกันได้.

**Are chart animations preserved when saving to PPTX?**

ใช่. เมื่อคุณ [save to PPTX](/slides/th/java/save-presentation/) เอฟเฟกต์แอนิเมชันทั้งหมดและลำดับของมันจะถูกเก็บรักษาไว้ เพราะเป็นส่วนหนึ่งของโมเดลแอนิเมชันดั้งเดิมของพรีเซนเทชัน.

**Can I read existing chart animations from a presentation and modify them?**

ใช่. API ให้เข้าถึงไทม์ไลน์ของสไลด์, ลำดับ, และเอฟเฟกต์ ทำให้คุณสามารถตรวจสอบแอนิเมชันแผนภูมิที่มีอยู่และปรับเปลี่ยนได้โดยไม่ต้องสร้างใหม่ทั้งหมดตั้งแต่ต้น.

**Can I produce a video that includes chart animations using Aspose.Slides?**

ใช่. คุณสามารถ [export a presentation to video](/slides/th/java/convert-powerpoint-to-video/) พร้อมคงเอฟเฟกต์แอนิเมชัน, ตั้งค่าเวลาและการตั้งค่าอื่น ๆ ของการส่งออก เพื่อให้คลิปที่ได้สะท้อนการเล่นแอนิเมชัน.