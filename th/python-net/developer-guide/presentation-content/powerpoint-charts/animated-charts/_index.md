---
title: เคลื่อนที่แผนภูมิ PowerPoint ด้วย Python
linktitle: แผนภูมิเคลื่อนที่
type: docs
weight: 80
url: /th/python-net/animated-charts/
keywords:
- แผนภูมิ
- แผนภูมิเคลื่อนที่
- การเคลื่อนที่แผนภูมิ
- ซีรีส์แผนภูมิ
- ประเภทแผนภูมิ
- ส่วนประกอบซีรีส์
- ส่วนประกอบประเภท
- เพิ่มเอฟเฟกต์
- ประเภทเอฟเฟกต์
- PowerPoint
- การนำเสนอ
- Python
- Aspose.Slides
description: "สร้างแผนภูมิเคลื่อนที่ที่สวยงามใน Python ด้วย Aspose.Slides. เพิ่มประสิทธิภาพการนำเสนอด้วยภาพเคลื่อนไหวในไฟล์ PPT, PPTX และ ODP — เริ่มต้นได้เลยตอนนี้."
---
## **บทนำ**

Aspose.Slides for Python via .NET รองรับการเคลื่อนที่ของส่วนประกอบแผนภูมิ. **Series**, **Categories**, **Series Elements**, **Categories Elements** สามารถเคลื่อนที่ได้ด้วยวิธีการ [ISequence.add_effect](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/isequence/) และสอง enum คือ [EffectChartMajorGroupingType](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/effectchartmajorgroupingtype/) และ [EffectChartMinorGroupingType](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/effectchartminorgroupingtype/).

## **การเคลื่อนที่ของ Series แผนภูมิ**
หากคุณต้องการเคลื่อนที่ Series ของแผนภูมิ ให้เขียนโค้ดตามขั้นตอนที่ระบุด้านล่าง:

1. โหลดงานนำเสนอ
1. รับออปเจกต์อ้างอิงของแผนภูมิ
1. เคลื่อนที่ Series
1. เขียนไฟล์พรีเซนเทชันลงดิสก์

ในตัวอย่างด้านล่างนี้ เราได้ทำการเคลื่อนที่ Series ของแผนภูมิ

```py
import aspose.slides.animation as anim;
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์การนำเสนอ 
with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # รับออบเจกต์อ้างอิงของแผนภูมิ
    slide = presentation.slides[0]
    shapes = slide.shapes
    chart = shapes[0]

    # ทำการเคลื่อนที่ series
    slide.timeline.main_sequence.add_effect(chart, 
        anim.EffectType.FADE, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, 
        anim.EffectChartMajorGroupingType.BY_SERIES, 0, 
        anim.EffectType.APPEAR, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart,
        anim.EffectChartMajorGroupingType.BY_SERIES, 1,
        anim.EffectType.APPEAR, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart,
        anim.EffectChartMajorGroupingType.BY_SERIES, 2,
        anim.EffectType.APPEAR, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart,
        anim.EffectChartMajorGroupingType.BY_SERIES, 3,
        anim.EffectType.APPEAR, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    # บันทึกการนำเสนอที่แก้ไขลงดิสก์ 
    presentation.save("AnimatingSeries_out.pptx", slides.export.SaveFormat.PPTX)
```

## **การเคลื่อนที่ของ Category แผนภูมิ**
หากคุณต้องการเคลื่อนที่ Category ของแผนภูมิ ให้เขียนโค้ดตามขั้นตอนที่ระบุด้านล่าง:

1. โหลดงานนำเสนอ
1. รับออปเจกต์อ้างอิงของแผนภูมิ
1. เคลื่อนที่ Category
1. เขียนไฟล์พรีเซนเทชันลงดิสก์

ในตัวอย่างด้านล่างนี้ เราได้ทำการเคลื่อนที่ Category ของแผนภูมิ

```py
import aspose.slides.animation as anim;
import aspose.slides as slides

with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # รับอ้างอิงของอ็อบเจกต์แผนภูมิ
    slide = presentation.slides[0]
    shapes = slide.shapes
    chart = shapes[0]

    # ทำการเคลื่อนที่ส่วนประกอบของหมวดหมู่
    slide.timeline.main_sequence.add_effect(chart, anim.EffectType.FADE, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    # เขียนไฟล์การนำเสนอลงดิสก์
    presentation.save("AnimatingCategoriesElements_out.pptx", slides.export.SaveFormat.PPTX)
```

## **การเคลื่อนที่ใน Series Element**
หากคุณต้องการเคลื่อนที่ series elements ให้เขียนโค้ดตามขั้นตอนที่ระบุด้านล่าง:

1. โหลดงานนำเสนอ
1. รับออปเจกต์อ้างอิงของแผนภูมิ
1. เคลื่อนที่ series elements
1. เขียนไฟล์พรีเซนเทชันลงดิสก์

ในตัวอย่างด้านล่างนี้ เราได้ทำการเคลื่อนที่ elements ของ series

```py
import aspose.slides.animation as anim;
import aspose.slides as slides

# โหลดพรีเซนเทชัน
with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # รับอ้างอิงของอ็อบเจกต์แผนภูมิ
    slide = presentation.slides[0]
    shapes = slide.shapes
    chart = shapes[0]

    # ทำการเคลื่อนที่ส่วนประกอบของ series
    slide.timeline.main_sequence.add_effect(chart, anim.EffectType.FADE, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 0, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 0, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 0, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 0, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 1, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 1, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 1, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 1, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 2, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 2, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 2, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 2, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    # บันทึกไฟล์พรีเซนเทชันลงดิสก์ 
    presentation.save("AnimatingSeriesElements_out.pptx", slides.export.SaveFormat.PPTX)
```

## **การเคลื่อนที่ใน Category Element**
หากคุณต้องการเคลื่อนที่ categories elements ให้เขียนโค้ดตามขั้นตอนที่ระบุด้านล่าง:

1. โหลดงานนำเสนอ
1. รับออปเจกต์อ้างอิงของแผนภูมิ
1. เคลื่อนที่ categories elements
1. เขียนไฟล์พรีเซนเทชันลงดิสก์

ในตัวอย่างด้านล่างนี้ เราได้ทำการเคลื่อนที่ categories elements

```py
import aspose.slides.animation as anim;
import aspose.slides as slides

with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # รับอ้างอิงของอ็อบเจกต์แผนภูมิ
    slide = presentation.slides[0]
    shapes = slide.shapes
    chart = shapes[0]

    # ทำการเคลื่อนที่ส่วนประกอบของหมวดหมู่
    slide.timeline.main_sequence.add_effect(chart, anim.EffectType.FADE, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    # บันทึกไฟล์การนำเสนอลงดิสก์
    presentation.save("AnimatingCategoriesElements_out.pptx", slides.export.SaveFormat.PPTX)
```

## **คำถามที่พบบ่อย**

**รองรับประเภทเอฟเฟกต์ที่แตกต่างกัน (เช่น entrance, emphasis, exit) สำหรับแผนภูมิเหมือนกับรูปทรงทั่วไปหรือไม่?**  
ใช่. แผนภูมิจัดเป็นรูปทรงหนึ่ง ดังนั้นจึงรองรับประเภทเอฟเฟกต์การเคลื่อนที่มาตรฐาน รวมถึง entrance, emphasis, และ exit พร้อมการควบคุมเต็มรูปแบบผ่านไทม์ไลน์ของสไลด์และลำดับการเคลื่อนที่.

**ฉันสามารถรวมการเคลื่อนที่ของแผนภูมิกับการเปลี่ยนสไลด์ได้หรือไม่?**  
ใช่. [Transitions](/slides/th/python-net/slide-transition/) จะนำไปใช้กับสไลด์ ในขณะที่เอฟเฟกต์การเคลื่อนที่จะนำไปใช้กับวัตถุบนสไลด์ คุณสามารถใช้ทั้งสองอย่างพร้อมกันในพรีเซนเทชันเดียวและควบคุมแยกกันได้.

**การเคลื่อนที่ของแผนภูมิจะถูกเก็บไว้เมื่อบันทึกเป็น PPTX หรือไม่?**  
ใช่. เมื่อคุณ [save to PPTX](/slides/th/python-net/save-presentation/) เอฟเฟกต์การเคลื่อนที่ทั้งหมดและลำดับของมันจะถูกเก็บไว้เนื่องจากเป็นส่วนหนึ่งของโมเดลการเคลื่อนที่ดั้งเดิมของพรีเซนเทชัน.

**ฉันสามารถอ่านการเคลื่อนที่ของแผนภูมิที่มีอยู่จากพรีเซนเทชันและแก้ไขได้หรือไม่?**  
ใช่. [API](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/) ให้การเข้าถึงไทม์ไลน์ของสไลด์ ลำดับและเอฟเฟกต์ ช่วยให้คุณตรวจสอบการเคลื่อนที่ของแผนภูมิที่มีอยู่และปรับเปลี่ยนได้โดยไม่ต้องสร้างใหม่ตั้งแต่ต้น.

**ฉันสามารถสร้างวิดีโอที่รวมการเคลื่อนที่ของแผนภูมิด้วย Aspose.Slides for Python via .NET ได้หรือไม่?**  
ใช่. คุณสามารถ [export a presentation to video](/slides/th/python-net/convert-powerpoint-to-video/) พร้อมคงการเคลื่อนที่ไว้ กำหนดเวลาการเล่นและการตั้งค่าอื่น ๆ ของการส่งออก เพื่อให้คลิปที่ได้สะท้อนการเล่นแบบเคลื่อนที่.