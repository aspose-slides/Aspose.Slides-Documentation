---
title: Manage Slide Show in C++
linktitle: Slide Show
type: docs
weight: 90
url: /cpp/manage-slide-show/
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
- C++
- Aspose.Slides
description: "Learn how to manage slide shows in Aspose.Slides for C++. Control slide transitions, timings and more across PPT, PPTX and ODP formats with ease."
---

In Microsoft PowerPoint, the **Slide Show** settings are a key tool for preparing and delivering professional presentations. One of the most important features in this section is **Set Up Show**, which allows you to tailor your presentation to specific conditions and audiences, ensuring flexibility and convenience. With this feature, you can select the show type (e.g., presented by a speaker, browsed by an individual, or browsed at a kiosk), enable or disable looping, choose specific slides to display, and use timings. This step in preparation is crucial for making your presentation more effective and professional.

`get_SlideShowSettings` is a method of the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class that returns an object of type [SlideShowSettings](https://reference.aspose.com/slides/cpp/aspose.slides/slideshowsettings/), which allows you to manage the slide show settings in a PowerPoint presentation. In this article, we will explore how to use this method to configure and control various aspects of slide show settings. 

## **Select Show Type**

`SlideShowSettings.set_SlideShowType` defines the type of slide show, which can be an instance of the following classes: [PresentedBySpeaker](https://reference.aspose.com/slides/cpp/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/cpp/aspose.slides/browsedbyindividual/), or [BrowsedAtKiosk](https://reference.aspose.com/slides/cpp/aspose.slides/browsedatkiosk/). Using this method allows you to adapt the presentation for different usage scenarios, such as automated kiosks or manual presentations.

The code example below creates a new presentation and sets the show type to "Browsed by an individual" without displaying the scrollbar.

```cpp
auto presentation = MakeObject<Presentation>();

auto showType = MakeObject<BrowsedByIndividual>();
showType->set_ShowScrollbar(false);

presentation->get_SlideShowSettings()->set_SlideShowType(showType);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Enable Show Options**

`SlideShowSettings.set_Loop` determines whether the slide show should repeat in a loop until manually stopped. This is useful for automated presentations that need to run continuously. `SlideShowSettings.set_ShowNarration` determines whether voice narrations should be played during the slide show. It is useful for automated presentations that contain voice guidance for the audience. `SlideShowSettings.set_ShowAnimation` determines whether animations added to slide objects should be played. This is useful for providing the full visual effect of the presentation.

The following code example creates a new presentation and loops the slide show.

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_Loop(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Select Slides to Show**

`SlideShowSettings.set_Slides` method allows you to select a range of slides to be shown during the presentation. This is useful when you need to show only part of the presentation rather than all slides. The following code example creates a new presentation and sets the slide range to display from slides `2` to `9`.

```cpp
auto presentation = MakeObject<Presentation>();

auto slideRange = MakeObject<SlidesRange>();
slideRange->set_Start(2);
slideRange->set_End(9);

presentation->get_SlideShowSettings()->set_Slides(slideRange);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Use Advance Slides**

`SlideShowSettings.set_UseTimings` method allows you to enable or disable the use of preset timings for each slide. This is useful for automatically showing slides with pre-defined display durations. The code example below creates a new presentation and disables the use of timings.

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_UseTimings(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Show Media Controls**

`SlideShowSettings.set_ShowMediaControls` method determines whether media controls (such as play, pause, and stop) should be displayed during the slide show when multimedia content (e.g., video or audio) is played. This is useful when you want to give the presenter control over media playback during the presentation.

The following code example creates a new presentation and enables media controls to be displayed.

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_ShowMediaControls(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```
