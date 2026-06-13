---
title: ทำแอนิเมชันแผนภูมิ PowerPoint บน Android
linktitle: แผนภูมิที่เคลื่อนไหว
type: docs
weight: 80
url: /th/androidjava/animated-charts/
keywords:
- แผนภูมิ
- แผนภูมิแอนิเมชัน
- การเคลื่อนไหวของแผนภูมิ
- ชุดข้อมูลแผนภูมิ
- ประเภทแผนภูมิ
- องค์ประกอบชุดข้อมูล
- องค์ประกอบประเภท
- เพิ่มเอฟเฟกต์
- ประเภทเอฟเฟกต์
- PowerPoint
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "สร้างแผนภูมิแอนิเมชันที่น่าตื่นตาตื่นใจใน Java ด้วย Aspose.Slides สำหรับ Android. เพิ่มประสิทธิภาพการนำเสนอด้วยภาพเคลื่อนไหวในไฟล์ PPT และ PPTX—เริ่มต้นเลยตอนนี้."
---
## **บทนำ**

Aspose.Slides for Android via Java รองรับการเคลื่อนไหวขององค์ประกอบแผนภูมิ **Series**, **Categories**, **Series Elements**, **Categories Elements** สามารถทำให้เคลื่อนที่ได้ด้วยวิธีการ [ISequence.addEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISequence#addEffect-com.aspose.slides.IChart-int-int-int-int-int-) และสองค่าสัมพัทธ์ enum [EffectChartMajorGroupingType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/EffectChartMajorGroupingType) และ [EffectChartMinorGroupingType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/EffectChartMinorGroupingType)

## **การเคลื่อนไหวของชุดข้อมูลในแผนภูมิ**
หากต้องการทำให้ชุดข้อมูลของแผนภูมิเคลื่อนที่ ให้เขียนโค้ดตามขั้นตอนต่อไปนี้:

1. โหลดการนำเสนอ
1. รับอ้างอิงของออบเจ็กต์แผนภูมิ
1. ทำให้ชุดข้อมูลเคลื่อนที่
1. เขียนไฟล์การนำเสนอไปยังดิสก์

ในตัวอย่างด้านล่าง เราได้ทำให้ชุดข้อมูลของแผนภูมิเคลื่อนที่

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์การนำเสนอ
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // รับอ้างอิงของอ็อบเจ็กต์แผนภูมิ
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // ทำให้ชุดข้อมูลเคลื่อนที่
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

    // เขียนการนำเสนอที่แก้ไขแล้วลงดิสก์
    pres.save("AnimatingSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **การเคลื่อนไหวของประเภทในแผนภูมิ**
หากต้องการทำให้ประเภทของแผนภูมิเคลื่อนที่ ให้เขียนโค้ดตามขั้นตอนต่อไปนี้:

1. โหลดการนำเสนอ
1. รับอ้างอิงของออบเจ็กต์แผนภูมิ
1. ทำให้ Category เคลื่อนที่
1. เขียนไฟล์การนำเสนอไปยังดิสก์

ในตัวอย่างด้านล่าง เราได้ทำให้ประเภทของแผนภูมิเคลื่อนที่

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์การนำเสนอ
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

## **การเคลื่อนไหวขององค์ประกอบในชุดข้อมูล**
หากต้องการทำให้องค์ประกอบของชุดข้อมูลเคลื่อนที่ ให้เขียนโค้ดตามขั้นตอนต่อไปนี้:

1. โหลดการนำเสนอ
1. รับอ้างอิงของออบเจ็กต์แผนภูมิ
1. ทำให้องค์ประกอบของชุดข้อมูลเคลื่อนที่
1. เขียนไฟล์การนำเสนอไปยังดิสก์

ในตัวอย่างด้านล่าง เราได้ทำให้องค์ประกอบของชุดข้อมูลเคลื่อนที่

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์การนำเสนอ
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // รับอ้างอิงของอ็อบเจ็กต์แผนภูมิ
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // ทำให้องค์ประกอบของชุดข้อมูลเคลื่อนที่
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

    // เขียนไฟล์การนำเสนอลงดิสก์ 
    pres.save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **การเคลื่อนไหวขององค์ประกอบประเภท**
หากต้องการทำให้องค์ประกอบของประเภทเคลื่อนที่ ให้เขียนโค้ดตามขั้นตอนต่อไปนี้:

1. โหลดการนำเสนอ
1. รับอ้างอิงของออบเจ็กต์แผนภูมิ
1. ทำให้องค์ประกอบของประเภทเคลื่อนที่
1. เขียนไฟล์การนำเสนอไปยังดิสก์

ในตัวอย่างด้านล่าง เราได้ทำให้องค์ประกอบของประเภทเคลื่อนที่

```java
// สร้างอินสแทนซ์ของคลาส Presentation ที่แทนไฟล์การนำเสนอ
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // รับอ้างอิงของอ็อบเจ็กต์แผนภูมิ
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // ทำให้องค์ประกอบของประเภทเคลื่อนที่
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

    // เขียนไฟล์การนำเสนอลงดิสก์
    pres.save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**รูปแบบเอฟเฟกต์ที่แตกต่าง (เช่น เข้าสู่, เน้น, ออกจาก) รองรับสำหรับแผนภูมิเช่นเดียวกับรูปทรงทั่วไปหรือไม่?**

ใช่ แผนภูมิจัดเป็นรูปทรงหนึ่ง ดังนั้นจึงรองรับประเภทเอฟเฟกต์การเคลื่อนไหวมาตรฐาน รวมถึงการเข้ามา, การเน้น, และการออก พร้อมการควบคุมเต็มรูปแบบผ่านไทม์ไลน์สไลด์และลำดับการเคลื่อนไหว

**ฉันสามารถผสานการเคลื่อนไหวของแผนภูมิกับการเปลี่ยนสไลด์ได้หรือไม่?**

ใช่ [Transitions](/slides/th/androidjava/slide-transition/) จะใช้กับสไลด์ทั้งหมด ส่วนเอฟเฟกต์การเคลื่อนไหวจะใช้กับวัตถุบนสไลด์ คุณสามารถใช้ทั้งสองร่วมกันในงานนำเสนอเดียวและควบคุมแยกกันได้

**การเคลื่อนไหวของแผนภูมิจะคงอยู่เมื่อบันทึกเป็น PPTX หรือไม่?**

ใช่ เมื่อคุณ [save to PPTX](/slides/th/androidjava/save-presentation/) เอฟเฟกต์การเคลื่อนไหวทั้งหมดและลำดับของมันจะถูกรักษาไว้ เนื่องจากเป็นส่วนหนึ่งของโมเดลการเคลื่อนไหวโดยธรรมชาติของงานนำเสนอ

**ฉันสามารถอ่านการเคลื่อนไหวของแผนภูมิที่มีอยู่ในงานนำเสนอและแก้ไขได้หรือไม่?**

ใช่ API ให้การเข้าถึงไทม์ไลน์สไลด์, ลำดับ, และเอฟเฟกต์ ช่วยให้คุณตรวจสอบการเคลื่อนไหวของแผนภูมิที่มีอยู่และปรับเปลี่ยนได้โดยไม่ต้องสร้างใหม่ทั้งหมดจากศูนย์

**ฉันสามารถสร้างวิดีโอที่รวมการเคลื่อนไหวของแผนภูมิด้วย Aspose.Slides ได้หรือไม่?**

ใช่ คุณสามารถ [export a presentation to video](/slides/th/androidjava/convert-powerpoint-to-video/) พร้อมคงการเคลื่อนไหว, ตั้งค่าเวลา, และการตั้งค่าอื่น ๆ เพื่อให้คลิปที่ได้สะท้อนการเล่นแบบเคลื่อนไหวอย่างถูกต้อง