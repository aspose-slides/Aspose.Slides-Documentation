---
title: Manage Slide Show
type: docs
weight: 90
url: /net/manage-slide-show/
keywords:
- show type
- presented by a speaker
- browsed by an individual
- browsed at a kiosk
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
- presentation
- C#
- .NET
- Aspose.Slides for .NET
description: "Manage slide show settings in PowerPoint presentations using C#"
---

In Microsoft PowerPoint, the **Slide Show** settings are a key tool for preparing and delivering professional presentations. One of the most important features in this section is **Set Up Show**, which allows you to tailor your presentation to specific conditions and audiences, ensuring flexibility and convenience. With this feature, you can select the show type (e.g., presented by a speaker, browsed by an individual, or browsed at a kiosk), enable or disable looping, choose specific slides to display, and use timings. This step in preparation is crucial for making your presentation more effective and professional.

`SlideShowSettings` is a property of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class, of type [SlideShowSettings](https://reference.aspose.com/slides/net/aspose.slides/presentation/slideshowsettings/), which allows you to manage the slide show settings in a PowerPoint presentation. In this article, we will explore how to use this property to configure and control various aspects of slide show settings. 

## **Select Show Type**

`SlideShowSettings.SlideShowType` defines the type of slide show, which can be an instance of the following classes: [PresentedBySpeaker](https://reference.aspose.com/slides/net/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/net/aspose.slides/browsedbyindividual/), or [BrowsedAtKiosk](https://reference.aspose.com/slides/net/aspose.slides/browsedatkiosk/). Using this property allows you to adapt the presentation for different usage scenarios, such as automated kiosks or manual presentations.

The code example below creates a new presentation and sets the show type to "Browsed by an individual" without displaying the scrollbar.

```cs
using var presentation = new Presentation();

var showType = new BrowsedByIndividual
{
    ShowScrollbar = false
};

presentation.SlideShowSettings.SlideShowType = showType;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Enable Show Options**

`SlideShowSettings.Loop` determines whether the slide show should repeat in a loop until manually stopped. This is useful for automated presentations that need to run continuously. `SlideShowSettings.ShowNarration` determines whether voice narrations should be played during the slide show. It is useful for automated presentations that contain voice guidance for the audience. `SlideShowSettings.ShowAnimation` determines whether animations added to slide objects should be played. This is useful for providing the full visual effect of the presentation.

The following code example creates a new presentation and loops the slide show.

```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.Loop = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Select Slides to Show**

`SlideShowSettings.Slides` property allows you to select a range of slides to be shown during the presentation. This is useful when you need to show only part of the presentation rather than all slides. The following code example creates a new presentation and sets the slide range to display from slides `2` to `9`.

```cs
using var presentation = new Presentation();

var slideRange = new SlidesRange 
{
    Start = 2,
    End = 9
};

presentation.SlideShowSettings.Slides = slideRange;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Use Advance Slides**

`SlideShowSettings.UseTimings` property allows you to enable or disable the use of preset timings for each slide. This is useful for automatically showing slides with pre-defined display durations. The code example below creates a new presentation and disables the use of timings.

```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.UseTimings = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Show Media Controls**

`SlideShowSettings.ShowMediaControls` property determines whether media controls (such as play, pause, and stop) should be displayed during the slide show when multimedia content (e.g., video or audio) is played. This is useful when you want to give the presenter control over media playback during the presentation.

The following code example creates a new presentation and enables media controls to be displayed.

```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.ShowMediaControls = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```
