---
title: Manage Slide Shows in Python via Java
linktitle: Slide Show
type: docs
weight: 90
url: /python-java/manage-slide-show/
keywords:
- show type
- presented by speaker
- browsed by individual
- browsed at kiosk
- show options
- loop continuously
- show without narration
- show without animation
- pen color
- show slides
- custom show
- advance slides
- manually
- using timings
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Learn how to manage slide shows in Aspose.Slides for Python via Java. Control slide transitions, timings and more across PPT, PPTX and ODP formats with ease."
---

## **Introduction**

Microsoft PowerPoint's **Set Up Show** options let you choose the show type, enable looping, select slides, and control how slides advance. With Aspose.Slides for Python via Java, you can configure these options programmatically and save them in a presentation file.

The [Presentation.getSlideShowSettings](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlideShowSettings) method returns a [SlideShowSettings](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowsettings/) object that controls these options. The examples below require Aspose.Slides for Python via Java and a compatible Java runtime. Each example starts the JVM if needed and releases the presentation when finished.

## **Select Show Type**

[SlideShowSettings.setSlideShowType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowsettings/#setSlideShowType) defines the type of slide show, which can be an instance of the following classes: [PresentedBySpeaker](https://reference.aspose.com/slides/python-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/python-java/aspose.slides/browsedbyindividual/), or [BrowsedAtKiosk](https://reference.aspose.com/slides/python-java/aspose.slides/browsedatkiosk/). Using this method allows you to adapt the presentation for different usage scenarios, such as automated kiosks or manual presentations.

The code example below creates a new presentation and sets the show type to "Browsed by an individual" without displaying the scrollbar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, BrowsedByIndividual

presentation = Presentation()
try:
    show_type = BrowsedByIndividual()
    show_type.setShowScrollbar(False)
    presentation.getSlideShowSettings().setSlideShowType(show_type)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Enable Show Options**

[SlideShowSettings.setLoop](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowsettings/#setLoop) determines whether the slide show should repeat in a loop until manually stopped. This is useful for automated presentations that need to run continuously. [SlideShowSettings.setShowNarration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowsettings/#setShowNarration) determines whether voice narrations should be played during the slide show. It is useful for automated presentations that contain voice guidance for the audience. [SlideShowSettings.setShowAnimation](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowsettings/#setShowAnimation) determines whether animations added to slide objects should be played. This is useful for providing the full visual effect of the presentation.

The following code example creates a new presentation and loops the slide show.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setLoop(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Select Slides to Show**

The [SlideShowSettings.setSlides](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowsettings/#setSlides) method allows you to select a range of slides to be shown during the presentation. This is useful when you need to show only part of the presentation rather than all slides. The following code example creates a presentation with nine slides and selects slides 2 through 9. The range uses one-based slide numbers.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlidesRange

presentation = Presentation()
try:
    # Create nine slides so the selected range exists.
    first_slide = presentation.getSlides().get_Item(0)
    for _ in range(8):
        presentation.getSlides().addClone(first_slide)

    slide_range = SlidesRange()
    slide_range.setStart(2)
    slide_range.setEnd(9)
    presentation.getSlideShowSettings().setSlides(slide_range)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Control Slide Advancement**

The [SlideShowSettings.setUseTimings](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowsettings/#setUseTimings) method allows you to enable or disable the use of preset timings for each slide. This is useful for automatically showing slides with pre-defined display durations. The code example below creates a new presentation and disables the use of timings.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setUseTimings(False)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Show Media Controls**

The [SlideShowSettings.setShowMediaControls](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowsettings/#setShowMediaControls) method determines whether media controls (such as play, pause, and stop) should be displayed during the slide show when multimedia content (e.g., video or audio) is played. This is useful when you want to give the presenter control over media playback during the presentation.

The following code example creates a new presentation and enables media controls to be displayed.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setShowMediaControls(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Can I save a presentation so it opens directly in slide show mode?**

Yes. Save the file as PPSX or PPSM; these formats launch directly in slide show mode when opened in PowerPoint. In Aspose.Slides, choose the corresponding save format [during export](/slides/python-java/save-presentation/).

**Can I exclude individual slides from the show without deleting them from the file?**

Yes. Mark a slide as [hidden](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#setHidden). Hidden slides remain in the presentation but are not displayed during the slide show.

**Can Aspose.Slides play a slide show or control a live presentation on screen?**

No. Aspose.Slides edits, analyzes, and converts presentation files; the actual playback is handled by a viewer application such as PowerPoint.
