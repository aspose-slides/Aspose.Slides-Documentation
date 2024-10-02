---
title: Slide Size
type: docs
weight: 70
url: /python-net/slide-size/
keywords: "Set slide, edit slide size, PowerPoint Presentation, custom slide size, resolve slide problems, Python, Aspose.Slides"
descriptions: "Set and edit slide size or aspect ratio in PowerPoint in Python"
---

## Slide Sizes in PowerPoint Presentations

Aspose.Slides for Python via .NET allows you to change the slide size or aspect ratio in PowerPoint presentations. If you plan to print your presentation or display its slides on a screen, you have to pay attention to its slide size or aspect ratio. 

These are the most common slide sizes and aspect ratios:

- **Standard (4:3 aspect ratio)**

  If your presentation is going to be displayed or viewed on relatively older devices or screens, you may want to use this setting. 

- **Widescreen (16:9 aspect ratio)** 

  If your presentation is going to be seen on modern projectors or displays, you may want to use this setting. 

You cannot use multiple slide size settings in a single presentation. When you select a slide size for a presentation, that slide size setting gets applied to all slides in the presentation. 

If you prefer to use a special slide size for your presentations, we strongly recommend you do it early. Ideally, you should specify your preferred slide at the beginning, i.e., when you are just setting up the presentation—before you add any content to the presentation. This way, you get to avoid complications resulting from (future) changes made to the size of slides. 

{{% alert color="primary" %}} 

 When you use Aspose.Slides to create a presentation, all the slides in the presentation automatically get the standard size or 4:3 aspect ratio.

{{% /alert %}} 

## Changing the Slide Size in Presentations 

 This sample code shows you how to change the slide size in a presentation in Python using Aspose.Slides:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(slides.SlideSizeType.ON_SCREEN16X9, slides.SlideSizeScaleType.DO_NOT_SCALE)
    pres.save("pres-4x3-aspect-ratio.pptx", slides.export.SaveFormat.PPTX)
```

## Specifying Custom Slide Sizes in Presentations

If you find the common slide sizes (4:3 and 16:9) unsuitable for your work, you may decide to use a specific or unique slide size. For example, if you plan to print full-size slides from your presentation on a custom page layout or if you intend to display your presentation on certain screen types, you are likely to benefit from using a custom size setting for your presentation. 

This sample code shows you how to use Aspose.Slides for Python via .NET to specify a custom slide size for a presentation in Python:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(780, 540, slides.SlideSizeScaleType.DO_NOT_SCALE) # A4 paper size
    pres.save("pres-a4-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

## Dealing With Issues When Changing the Size of Slides in Presentations

After you change the slide size for a presentation, the slides’ contents (images or objects, for example) may become distorted. By default, the objects get automatically resized to fit the new slide size. However, when changing a presentation's slide size, you can specify a setting that determines how Aspose.Slides deals with the contents on the slides.

Depending on what you intend to do or achieve, you can use any of these settings:

- `DO_NOT_SCALE`

  If you do NOT want the objects on the slides to be resized, use this setting.

- `ENSURE_FIT`

  If you want to scale to a smaller slide size and you need Aspose.Slides to scale down the slides’ objects to ensure they all fit on slides (this way, you avoid losing content), use this setting. 

- `MAXIMIZE`

  If you want to scale to a larger slide size and you need Aspose.Slides to enlarge the slides’ objects to make them proportional to the new slide size, use this setting. 

This sample code shows you how to use the `MAXIMIZE` setting when changing the size of a presentation’s slide:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
   pres.slide_size.set_size(slides.SlideSizeType.LEDGER, slides.SlideSizeScaleType.MAXIMIZE)
```

