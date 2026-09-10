---
title: ทำแอนิเมชันแผนภูมิ PowerPoint ใน Python ผ่าน Java
linktitle: แผนภูมิแอนิเมชัน
type: docs
weight: 80
url: /th/python-java/animated-charts/
keywords:
- แผนภูมิ
- แผนภูมิแอนิเมชัน
- แอนิเมชันของแผนภูมิ
- ซีรีส์แผนภูมิ
- หมวดหมูแผนภูมิ
- องค์ประกอบซีรีส์
- องค์ประกอบหมวดหมู่
- เพิ่มเอฟเฟกต์
- ประเภทเอฟเฟกต์
- PowerPoint
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "สร้างแผนภูมิที่เคลื่อนไหวสวยงามใน Python ผ่าน Java ด้วย Aspose.Slides. เพิ่มประสิทธิภาพการนำเสนอด้วยภาพเคลื่อนไหวในไฟล์ PPT และ PPTX—เริ่มต้นเลยตอนนี้."
---
## **บทนำ**

Aspose.Slides for Python via Java รองรับการทำแอนิเมชันขององค์ประกอบแผนภูมิ. **Series**, **Categories**, **Series Elements**, และ **Category Elements** สามารถทำแอนิเมชันได้โดยใช้เมธอด [Sequence.addEffect](https://reference.aspose.com/slides/th/python-java/aspose.slides/sequence/#addEffect) และสอง enumeration: [EffectChartMajorGroupingType](https://reference.aspose.com/slides/th/python-java/aspose.slides/effectchartmajorgroupingtype/) และ [EffectChartMinorGroupingType](https://reference.aspose.com/slides/th/python-java/aspose.slides/effectchartminorgroupingtype/).

## **การทำแอนิเมชันซีรีส์ของแผนภูมิ**

If you want to animate a chart series, write the code according to the steps listed below:

1. โหลดการนำเสนอ.
1. รับอ้างอิงถึงออบเจ็กต์แผนภูมิ.
1. ทำแอนิเมชันซีรีส์.
1. บันทึกไฟล์การนำเสนอลงดิสก์.

ตัวอย่างต่อไปนี้ทำแอนิเมชันซีรีส์ของแผนภูมิ. แผนภูมิในไฟล์ตัวอย่างมีสามซีรีส์, ดังนั้นจึงเพิ่มเอฟเฟกต์หนึ่งรายการสำหรับแต่ละดัชนีตั้งแต่ 0 ถึง 2. Aspose.Slides ไม่ตรวจสอบดัชนีกับข้อมูลแผนภูมิ, และเอฟเฟกต์ที่เพิ่มสำหรับซีรีส์ที่ไม่มีอยู่จะถูกเขียนลงไฟล์แต่ไม่ได้ทำแอนิเมชันอะไร—ให้ดัชนีต่ำกว่าจำนวนซีรีส์ในแผนภูมิของคุณ.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMajorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# โหลดการนำเสนอ.
presentation = Presentation("ExistingChart.pptx")
try:
    # รับอ้างอิงถึงออบเจ็กต์แผนภูมิ.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # ทำแอนิเมชันองค์ประกอบแผนภูมิ.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # บันทึกการนำเสนอที่แก้ไขลงดิสก์.
    presentation.save("AnimatingSeries_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **การทำแอนิเมชันหมวดหมู่ของแผนภูมิ**

If you want to animate a chart category, write the code according to the steps listed below:

1. โหลดการนำเสนอ.
1. รับอ้างอิงถึงออบเจ็กต์แผนภูมิ.
1. ทำแอนิเมชันหมวดหมู่.
1. บันทึกไฟล์การนำเสนอลงดิสก์.

ตัวอย่างต่อไปนี้ทำแอนิเมชันหมวดหมู่ของแผนภูมิ.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMajorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# โหลดการนำเสนอ.
presentation = Presentation("ExistingChart.pptx")
try:
    # รับอ้างอิงถึงออบเจ็กต์แผนภูมิ.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # ทำแอนิเมชันองค์ประกอบแผนภูมิ.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # บันทึกการนำเสนอที่แก้ไขลงดิสก์.
    presentation.save("Sample_Animation_C.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **การทำแอนิเมชันในองค์ประกอบซีรีส์**

If you want to animate series elements, write the code according to the steps listed below:

1. โหลดการนำเสนอ.
1. รับอ้างอิงถึงออบเจ็กต์แผนภูมิ.
1. ทำแอนิเมชันองค์ประกอบซีรีส์.
1. บันทึกไฟล์การนำเสนอลงดิสก์.

ตัวอย่างต่อไปนี้ทำแอนิเมชันองค์ประกอบซีรีส์.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMinorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# โหลดการนำเสนอ.
presentation = Presentation("ExistingChart.pptx")
try:
    # รับอ้างอิงถึงออบเจ็กต์แผนภูมิ.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # ทำแอนิเมชันองค์ประกอบแผนภูมิ.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # บันทึกการนำเสนอที่แก้ไขลงดิสก์.
    presentation.save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **การทำแอนิเมชันในองค์ประกอบหมวดหมู่**

If you want to animate category elements, write the code according to the steps listed below:

1. โหลดการนำเสนอ.
1. รับอ้างอิงถึงออบเจ็กต์แผนภูมิ.
1. ทำแอนิเมชันองค์ประกอบหมวดหมู่.
1. บันทึกไฟล์การนำเสนอลงดิสก์.

ตัวอย่างต่อไปนี้ทำแอนิเมชันองค์ประกอบหมวดหมู่.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMinorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# โหลดการนำเสนอ.
presentation = Presentation("ExistingChart.pptx")
try:
    # รับอ้างอิงถึงออบเจ็กต์แผนภูมิ.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # ทำแอนิเมชันองค์ประกอบแผนภูมิ.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # บันทึกการนำเสนอที่แก้ไขลงดิสก์.
    presentation.save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```


## **คำถามที่พบบ่อย**

**Are different effect types (e.g., entrance, emphasis, exit) supported for charts like for regular shapes?**  
ใช่. แผนภูมิถือเป็นรูปทรงเดียวกัน, ดังนั้นจึงรองรับประเภทเอฟเฟกต์แอนิเมชันมาตรฐาน, รวมถึง entrance, emphasis, และ exit, โดยสามารถควบคุมเต็มที่ผ่านไทม์ไลน์ของสไลด์และลำดับแอนิเมชัน.

**Can I combine chart animation with slide transitions?**  
ใช่. [Transitions](/slides/th/python-java/slide-transition/) ใช้กับสไลด์, ส่วนเอฟเฟกต์แอนิเมชันใช้กับออบเจ็กต์บนสไลด์. คุณสามารถใช้ทั้งสองพร้อมกันในงานนำเสนอเดียวกันและควบคุมแยกกันได้.

**Are chart animations preserved when saving to PPTX?**  
ใช่. เมื่อคุณ [save to PPTX](/slides/th/python-java/save-presentation/), เอฟเฟกต์แอนิเมชันทั้งหมดและลำดับของมันจะถูกเก็บไว้เนื่องจากเป็นส่วนหนึ่งของโมเดลแอนิเมชันดั้งเดิมของงานนำเสนอ.

**Can I read existing chart animations from a presentation and modify them?**  
ใช่. API ให้การเข้าถึงไทม์ไลน์ของสไลด์, ลำดับ, และเอฟเฟกต์, ทำให้คุณสามารถตรวจสอบแอนิเมชันแผนภูมิที่มีอยู่และปรับเปลี่ยนได้โดยไม่ต้องสร้างใหม่ทั้งหมดตั้งแต่ต้น.

**Can I produce a video that includes chart animations using Aspose.Slides?**  
ใช่. คุณสามารถ [export a presentation to video](/slides/th/python-java/convert-powerpoint-to-video/) พร้อมกับคงแอนิเมชันไว้, ตั้งค่าการกำหนดเวลาและการตั้งค่าอื่นๆ ของการส่งออกเพื่อให้คลิปที่ได้สะท้อนการเล่นแอนิเมชัน.