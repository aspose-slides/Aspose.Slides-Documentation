---
title: สร้างแผนภูมิ PowerPoint แบบเคลื่อนไหวใน .NET
linktitle: แผนภูมิเคลื่อนไหว
type: docs
weight: 80
url: /th/net/animated-charts/
keywords:
- แผนภูมิ
- แผนภูมิเคลื่อนไหว
- การเคลื่อนไหวของแผนภูมิ
- ซีรีส์แผนภูมิ
- หมวดหมู่แผนภูมิ
- องค์ประกอบซีรีส์
- องค์ประกอบหมวดหมู่
- เพิ่มเอฟเฟกต์
- ประเภทเอฟเฟกต์
- พาวเวอร์พอยท์
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "สร้างแผนภูมิเคลื่อนไหวที่สวยงามใน .NET ด้วย Aspose.Slides. เพิ่มประสิทธิภาพงานนำเสนอด้วยภาพเคลื่อนไหวในไฟล์ PPT และ PPTX—เริ่มต้นกันเลยตอนนี้."
---
## **บทนำ**

Aspose.Slides for .NET รองรับการเคลื่อนไหวขององค์ประกอบแผนภูมิ. **Series**, **Categories**, **Series Elements**, **Categories Elements** สามารถเคลื่อนไหวได้ด้วยเมธอด [ISequence.AddEffect](https://reference.aspose.com/slides/th/net/aspose.slides.animation/isequence/methods/addeffect) และสอง enum [EffectChartMajorGroupingType](https://reference.aspose.com/slides/th/net/aspose.slides.animation/effectchartmajorgroupingtype) และ [EffectChartMinorGroupingType](https://reference.aspose.com/slides/th/net/aspose.slides.animation/effectchartminorgroupingtype).

## **การเคลื่อนไหวของซีรีส์แผนภูมิ**
หากคุณต้องการเคลื่อนไหวซีรีส์แผนภูมิ ให้เขียนโค้ดตามขั้นตอนที่ระบุด้านล่าง:

1. โหลดงานนำเสนอ
1. รับอ้างอิงของวัตถุแผนภูมิ
1. เคลื่อนไหวซีรีส์
1. บันทึกไฟล์งานนำเสนอลงดิสก์

ในตัวอย่างที่ให้ด้านล่าง เราได้เคลื่อนไหวซีรีส์แผนภูมิ

```c#
// สร้างคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ 
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // รับอ้างอิงของอ็อบเจ็กต์แผนภูมิ
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // เคลื่อนไหวซีรีส์
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None,
    EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
    EffectChartMajorGroupingType.BySeries, 0,
    EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
    EffectChartMajorGroupingType.BySeries, 1,
    EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
    EffectChartMajorGroupingType.BySeries, 2,
    EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
    EffectChartMajorGroupingType.BySeries, 3,
    EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // บันทึกงานนำเสนอที่แก้ไขลงดิสก์ 
    presentation.Save("AnimatingSeries_out.pptx", SaveFormat.Pptx);
}
```

## **การเคลื่อนไหวของหมวดหมู่แผนภูมิ**
หากคุณต้องการเคลื่อนไหวหมวดหมู่แผนภูมิ ให้เขียนโค้ดตามขั้นตอนที่ระบุด้านล่าง:

1. โหลดงานนำเสนอ
1. รับอ้างอิงของวัตถุแผนภูมิ
1. เคลื่อนไหวหมวดหมู่
1. บันทึกไฟล์งานนำเสนอลงดิสก์

ในตัวอย่างที่ให้ด้านล่าง เราได้เคลื่อนไหวหมวดหมู่แผนภูมิ

```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // รับอ้างอิงของอ็อบเจ็กต์แผนภูมิ
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // เคลื่อนไหวองค์ประกอบของหมวดหมู่
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // บันทึกไฟล์งานนำเสนอลงดิสก์
    presentation.Save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
}
```

## **การเคลื่อนไหวในองค์ประกอบซีรีส์**
หากคุณต้องการเคลื่อนไหวองค์ประกอบของซีรีส์ ให้เขียนโค้ดตามขั้นตอนที่ระบุด้านล่าง:

1. โหลดงานนำเสนอ
1. รับอ้างอิงของวัตถุแผนภูมิ
1. เคลื่อนไหวองค์ประกอบของซีรีส์
1. บันทึกไฟล์งานนำเสนอลงดิสก์

ในตัวอย่างที่ให้ด้านล่าง เราได้เคลื่อนไหวองค์ประกอบของซีรีส์

```c#
// โหลดงานนำเสนอ
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // รับอ้างอิงของอ็อบเจ็กต์แผนภูมิ
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // เคลื่อนไหวองค์ประกอบของซีรีส์
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // บันทึกไฟล์งานนำเสนอลงดิสก์ 
    presentation.Save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx);
```

## **การเคลื่อนไหวในองค์ประกอบหมวดหมู่**
หากคุณต้องการเคลื่อนไหวองค์ประกอบของหมวดหมู่ ให้เขียนโค้ดตามขั้นตอนที่ระบุด้านล่าง:

1. โหลดงานนำเสนอ
1. รับอ้างอิงของวัตถุแผนภูมิ
1. เคลื่อนไหวองค์ประกอบของหมวดหมู่
1. บันทึกไฟล์งานนำเสนอลงดิสก์

ในตัวอย่างที่ให้ด้านล่าง เราได้เคลื่อนไหวองค์ประกอบของหมวดหมู่

```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // รับอ้างอิงของอ็อบเจ็กต์แผนภูมิ
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // เคลื่อนไหวองค์ประกอบของหมวดหมู่
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // บันทึกไฟล์งานนำเสนอลงดิสก์
    presentation.Save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
}
```

## **คำถามที่พบบ่อย**

**ประเภทเอฟเฟกต์ที่ต่างกัน (เช่น, เข้าสู่, เน้น, ออกจาก) รองรับสำหรับแผนภูมิเช่นเดียวกับรูปทรงธรรมดาไหม?**

ใช่. แผนภูมิถือเป็นรูปทรงหนึ่ง ดังนั้นจึงรองรับประเภทเอฟเฟกต์การเคลื่อนไหวมาตรฐาน รวมถึงการเข้าสู่, เน้น, และออก, พร้อมการควบคุมเต็มรูปแบบผ่านไทม์ไลน์ของสไลด์และลำดับการเคลื่อนไหว.

**ฉันสามารถรวมการเคลื่อนไหวของแผนภูมิพร้อมกับการเปลี่ยนสไลด์ได้หรือไม่?**

ใช่. [Transitions](/slides/th/net/slide-transition/) ใช้กับสไลด์ ในขณะที่เอฟเฟกต์การเคลื่อนไหวใช้กับวัตถุบนสไลด์ คุณสามารถใช้ทั้งสองพร้อมกันในงานนำเสนอเดียวและควบคุมแยกกันได้.

**การเคลื่อนไหวของแผนภูมิจะคงอยู่เมื่อตบลงเป็น PPTX หรือไม่?**

ใช่. เมื่อคุณ [save to PPTX](/slides/th/net/save-presentation/) เอฟเฟกต์การเคลื่อนไหวทั้งหมดและลำดับของมันจะถูกเก็บไว้เนื่องจากเป็นส่วนหนึ่งของโมเดลการเคลื่อนไหวดั้งเดิมของงานนำเสนอ.

**ฉันสามารถอ่านการเคลื่อนไหวของแผนภูมิที่มีอยู่จากงานนำเสนอและแก้ไขได้หรือไม่?**

ใช่. [API](https://reference.aspose.com/slides/th/net/aspose.slides.animation/) ให้เข้าถึงไทม์ไลน์ของสไลด์, ลำดับ, และเอฟเฟกต์ ทำให้คุณสามารถตรวจสอบการเคลื่อนไหวของแผนภูมิที่มีอยู่และปรับเปลี่ยนได้โดยไม่ต้องสร้างทุกอย่างใหม่ตั้งแต่ต้น.

**ฉันสามารถสร้างวิดีโอที่รวมการเคลื่อนไหวของแผนภูมิโดยใช้ Aspose.Slides ได้หรือไม่?**

ใช่. คุณสามารถ [export a presentation to video](/slides/th/net/convert-powerpoint-to-video/) พร้อมเก็บการเคลื่อนไหวไว้ กำหนดเวลาและการตั้งค่าอื่น ๆ ของการส่งออก เพื่อให้คลิปที่ได้สะท้อนการเล่นแบบเคลื่อนไหว.