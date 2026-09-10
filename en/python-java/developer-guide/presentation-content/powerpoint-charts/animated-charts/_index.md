---
title: Animate PowerPoint Charts in Python via Java
linktitle: Animated Charts
type: docs
weight: 80
url: /python-java/animated-charts/
keywords:
- chart
- animated chart
- chart animation
- chart series
- chart category
- series element
- category element
- add effect
- effect type
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Create stunning animated charts in Python via Java with Aspose.Slides. Boost presentations with dynamic visuals in PPT and PPTX files—get started now."
---

## **Introduction**

Aspose.Slides for Python via Java supports animating chart elements. **Series**, **Categories**, **Series Elements**, and **Category Elements** can be animated using the [Sequence.addEffect](https://reference.aspose.com/slides/python-java/aspose.slides/sequence/#addEffect) method and two enumerations: [EffectChartMajorGroupingType](https://reference.aspose.com/slides/python-java/aspose.slides/effectchartmajorgroupingtype/) and [EffectChartMinorGroupingType](https://reference.aspose.com/slides/python-java/aspose.slides/effectchartminorgroupingtype/).

## **Chart Series Animation**

If you want to animate a chart series, write the code according to the steps listed below:

1. Load a presentation.
1. Get a reference to the chart object.
1. Animate the series.
1. Write the presentation file to disk.

The following example animates chart series. The chart in the example file has three series, so one effect is added for each index from 0 to 2. Aspose.Slides does not check the index against the chart data, and an effect added for a series that does not exist is written to the file but animates nothing—keep the index below the number of series in your own chart.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMajorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Load the presentation.
presentation = Presentation("ExistingChart.pptx")
try:
    # Get a reference to the chart object.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Animate the chart elements.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # Write the modified presentation to disk.
    presentation.save("AnimatingSeries_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Chart Category Animation**

If you want to animate a chart category, write the code according to the steps listed below:

1. Load a presentation.
1. Get a reference to the chart object.
1. Animate the category.
1. Write the presentation file to disk.

The following example animates chart categories.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMajorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Load the presentation.
presentation = Presentation("ExistingChart.pptx")
try:
    # Get a reference to the chart object.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Animate the chart elements.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # Write the modified presentation to disk.
    presentation.save("Sample_Animation_C.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Animation in a Series Element**

If you want to animate series elements, write the code according to the steps listed below:

1. Load a presentation.
1. Get a reference to the chart object.
1. Animate series elements.
1. Write the presentation file to disk.

The following example animates series elements.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMinorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Load the presentation.
presentation = Presentation("ExistingChart.pptx")
try:
    # Get a reference to the chart object.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Animate the chart elements.
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

    # Write the modified presentation to disk.
    presentation.save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Animation in a Category Element**

If you want to animate category elements, write the code according to the steps listed below:

1. Load a presentation.
1. Get a reference to the chart object.
1. Animate category elements.
1. Write the presentation file to disk.

The following example animates category elements.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMinorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Load the presentation.
presentation = Presentation("ExistingChart.pptx")
try:
    # Get a reference to the chart object.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Animate the chart elements.
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

    # Write the modified presentation to disk.
    presentation.save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Are different effect types (e.g., entrance, emphasis, exit) supported for charts like for regular shapes?**

Yes. A chart is treated as a shape, so it supports the standard animation effect types, including entrance, emphasis, and exit, with full control via the slide's timeline and animation sequences.

**Can I combine chart animation with slide transitions?**

Yes. [Transitions](/slides/python-java/slide-transition/) apply to the slide, while animation effects apply to objects on the slide. You can use both together in the same presentation and control them independently.

**Are chart animations preserved when saving to PPTX?**

Yes. When you [save to PPTX](/slides/python-java/save-presentation/), all animation effects and their ordering are preserved because they are part of the presentation's native animation model.

**Can I read existing chart animations from a presentation and modify them?**

Yes. The API provides access to the slide timeline, sequences, and effects, allowing you to inspect existing chart animations and adjust them without recreating everything from scratch.

**Can I produce a video that includes chart animations using Aspose.Slides?**

Yes. You can [export a presentation to video](/slides/python-java/convert-powerpoint-to-video/) while preserving animations, configuring timings and other export settings so the resulting clip reflects the animated playback.
