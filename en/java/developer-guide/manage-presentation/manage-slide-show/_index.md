---
title: Manage Slide Show in Java
linktitle: Slide Show
type: docs
weight: 90
url: /java/manage-slide-show/
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
- Java
- Aspose.Slides
description: "Learn how to manage slide shows in Aspose.Slides for Java. Control slide transitions, timings and more across PPT, PPTX and ODP formats with ease."
---

In Microsoft PowerPoint, the **Slide Show** settings are a key tool for preparing and delivering professional presentations. One of the most important features in this section is **Set Up Show**, which allows you to tailor your presentation to specific conditions and audiences, ensuring flexibility and convenience. With this feature, you can select the show type (e.g., presented by a speaker, browsed by an individual, or browsed at a kiosk), enable or disable looping, choose specific slides to display, and use timings. This step in preparation is crucial for making your presentation more effective and professional.

`getSlideShowSettings` is a method of the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) class that returns an object of type [SlideShowSettings](https://reference.aspose.com/slides/java/com.aspose.slides/slideshowsettings/), which allows you to manage the slide show settings in a PowerPoint presentation. In this article, we will explore how to use this method to configure and control various aspects of slide show settings. 

## **Select Show Type**

`SlideShowSettings.setSlideShowType` defines the type of slide show, which can be an instance of the following classes: [PresentedBySpeaker](https://reference.aspose.com/slides/java/com.aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/java/com.aspose.slides/browsedbyindividual/), or [BrowsedAtKiosk](https://reference.aspose.com/slides/java/com.aspose.slides/browsedatkiosk/). Using this method allows you to adapt the presentation for different usage scenarios, such as automated kiosks or manual presentations.

The code example below creates a new presentation and sets the show type to "Browsed by an individual" without displaying the scrollbar.

```java
Presentation presentation = new Presentation();

BrowsedByIndividual showType = new BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Enable Show Options**

`SlideShowSettings.setLoop` determines whether the slide show should repeat in a loop until manually stopped. This is useful for automated presentations that need to run continuously. `SlideShowSettings.setShowNarration` determines whether voice narrations should be played during the slide show. It is useful for automated presentations that contain voice guidance for the audience. `SlideShowSettings.setShowAnimation` determines whether animations added to slide objects should be played. This is useful for providing the full visual effect of the presentation.

The following code example creates a new presentation and loops the slide show.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Select Slides to Show**

`SlideShowSettings.setSlides` method allows you to select a range of slides to be shown during the presentation. This is useful when you need to show only part of the presentation rather than all slides. The following code example creates a new presentation and sets the slide range to display from slides `2` to `9`.

```java
Presentation presentation = new Presentation();

SlidesRange slideRange = new SlidesRange();
slideRange.setStart(2);
slideRange.setEnd(9);

presentation.getSlideShowSettings().setSlides(slideRange);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Use Advance Slides**

`SlideShowSettings.setUseTimings` method allows you to enable or disable the use of preset timings for each slide. This is useful for automatically showing slides with pre-defined display durations. The code example below creates a new presentation and disables the use of timings.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Show Media Controls**

`SlideShowSettings.setShowMediaControls` method determines whether media controls (such as play, pause, and stop) should be displayed during the slide show when multimedia content (e.g., video or audio) is played. This is useful when you want to give the presenter control over media playback during the presentation.

The following code example creates a new presentation and enables media controls to be displayed.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **FAQ**

**Can I save a presentation so it opens directly in slide show mode?**

Yes. Save the file as PPSX or PPSM; these formats launch directly in slide show when opened in PowerPoint. In Aspose.Slides, choose the corresponding save format [during export](/slides/java/save-presentation/).

**Can I exclude individual slides from the show without deleting them from the file?**

Yes. Mark a slide as [hidden](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#setHidden-boolean-). Hidden slides remain in the presentation but are not displayed during the slide show.

**Can Aspose.Slides play a slide show or control a live presentation on screen?**

No. Aspose.Slides edits, analyzes, and converts presentation files; the actual playback is handled by a viewer application such as PowerPoint.
