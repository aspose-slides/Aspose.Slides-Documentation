---
title: Slide Size
type: docs
weight: 70
url: /cpp/slide-size/

---

## Slide Sizes in PowerPoint Presentations

Aspose.Slides for C++ allows you to change the slide size or aspect ratio in PowerPoint presentations. If you plan to print your presentation or display its slides on a screen, you have to pay attention to its slide size or aspect ratio. 

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

 This sample code shows you how to change the slide size in a presentation in C++ using Aspose.Slides:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres-4x3-aspect-ratio.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
```

## Specifying Custom Slide Sizes in Presentations

If you find the common slide sizes (4:3 and 16:9) unsuitable for your work, you may decide to use a specific or unique slide size. For example, if you plan to print full-size slides from your presentation on a custom page layout or if you intend to display your presentation on certain screen types, you are likely to benefit from using a custom size setting for your presentation. 

This sample code shows you how to use Aspose.Slides for C++ to specify a custom slide size for a presentation in C++:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
// A4 paper size
pres->get_SlideSize()->SetSize(780.0f, 540.0f, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-a4-slide-size.pptx", SaveFormat::Pptx);
```

## Dealing With Issues When Changing the Size of Slides in Presentations

After you change the slide size for a presentation, the slides’ contents (images or objects, for example) may become distorted. By default, the objects get automatically resized to fit the new slide size. However, when changing a presentation's slide size, you can specify a setting that determines how Aspose.Slides deals with the contents on the slides.

Depending on what you intend to do or achieve, you can use any of these settings:

- `DoNotScale`

  If you do NOT want the objects on the slides to be resized, use this setting.

- `EnsureFit`

  If you want to scale to a smaller slide size and you need Aspose.Slides to scale down the slides’ objects to ensure they all fit on slides (this way, you avoid losing content), use this setting. 

- `Maximize`

  If you want to scale to a larger slide size and you need Aspose.Slides to enlarge the slides’ objects to make them proportional to the new slide size, use this setting. 

This sample code shows you how to use the `Maximize` setting when changing the size of a presentation’s slide:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
```

