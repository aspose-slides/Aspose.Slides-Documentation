---
title: C++ में PowerPoint स्लाइड्स को PNG में बदलें
linktitle: PowerPoint से PNG
type: docs
weight: 30
url: /hi/cpp/convert-powerpoint-to-png/
keywords:
- PowerPoint बदलें
- प्रस्तुति रूपांतरित करें
- स्लाइड रूपांतरित करें
- PPT बदलें
- PPTX बदलें
- PowerPoint से PNG
- प्रस्तुति से PNG
- स्लाइड से PNG
- PPT से PNG
- PPTX से PNG
- PPT को PNG के रूप में सहेजें
- PPTX को PNG के रूप में सहेजें
- PPT को PNG में निर्यात करें
- PPTX को PNG में निर्यात करें
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ PowerPoint प्रस्तुतियों को तेज़ी से उच्च-गुणवत्ता वाली PNG छवियों में बदलें, सटीक और स्वचालित परिणाम सुनिश्चित करते हुए।"
---
## **सारांश**

यह लेख Aspose.Slides for C++ का उपयोग करके प्रस्तुति स्लाइड्स को PNG छवियों में बदलने की विधि समझाता है। आप PPT, PPTX और ODP जैसे फ़ॉर्मेट की प्रस्तुतियों को लोड कर सकते हैं, प्रत्येक स्लाइड को रेंडर कर सकते हैं, और इसे अलग‑अलग PNG छवि के रूप में सहेज सकते हैं।

नीचे दिए गए उदाहरण डिफ़ॉल्ट स्केल पर रेंडरिंग, स्केल बढ़ाने, पिक्सल में आउटपुट आयाम निर्धारित करने, और ग्रेडिएंट रेंडरिंग शैली चुनने को दर्शाते हैं।

## **PowerPoint को PNG में बदलें**

Load a presentation with the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class and access its slides through the [Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/) accessor. The example renders every slide with [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) without parameters to create a thumbnail. It then calls [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) with [ImageFormat::Png](https://reference.aspose.com/slides/cpp/aspose.slides/imageformat/) to save each rendered slide as a PNG image.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage();
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
पैरामीटर‑रहित [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) ओवरलोड 0.2 के स्केल पर रेंडर करता है। उदाहरण के लिए, 720 × 540 पॉइंट की स्लाइड 144 × 108 पिक्सल की थंबनेल उत्पन्न करती है। आउटपुट आयाम को नियंत्रित करने के लिए नीचे दिखाए गए स्केल फ़ैक्टर या स्पष्ट इमेज आकार वाले ओवरलोड का उपयोग करें।
{{% /alert %}}

## **PowerPoint को PNG में कस्टम आयामों के साथ बदलें**

Pass horizontal and vertical scale factors to [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) to control the rendered dimensions. In this example, both factors are 2, so a slide measuring 720 × 540 points produces a 1440 × 1080 pixel image. Equal scale factors preserve the slide's aspect ratio. Each image is saved in PNG format with [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/).

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto scaleX = 2.f;
auto scaleY = scaleX;

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(scaleX, scaleY);
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

## **PowerPoint को PNG में कस्टम आकार के साथ बदलें**

To specify output dimensions in pixels, pass a size to [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) instead of scale factors. This example renders every slide at 960 × 720 pixels and saves the result with [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/). Choose dimensions that match the slide's aspect ratio to avoid stretching the image.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>
#include <drawing/size.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto imageSize = System::Drawing::Size(960, 720);

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(imageSize);
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

## **ग्रेडिएंट रेंडरिंग शैली चुनें**

Suppose a slide contains gradient fills, but the transitions in the exported PNG look lighter or otherwise different from what you see in PowerPoint. You can use the [SaveOptions::set_GradientStyle](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_gradientstyle/) method of [RenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/renderingoptions/) to choose how the gradients are rendered.

Download [gradient-styles.pptx](gradient-styles.pptx) and place it in the application's working directory. Its first slide contains two linear gradients: cyan to orange at the top and blue to yellow at the bottom. Each gradient has two stops, at 0% and 100%.

The following example loads this presentation and renders the same first slide in both modes with [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/).

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>
#include <DOM/GradientStyle.h>
#include <Export/RenderingOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"gradient-styles.pptx");
auto slide = presentation->get_Slide(0);

auto gradientStyles = { GradientStyle::Default, GradientStyle::PowerPointUI };
for (auto style : gradientStyles)
{
    auto options = MakeObject<RenderingOptions>();
    options->set_GradientStyle(style);

    auto image = slide->GetImage(options, 1.f, 1.f);
    auto styleName = style == GradientStyle::Default ? u"Default" : u"PowerPointUI";
    image->Save(String::Format(u"gradient-{0}.png", styleName), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

The images below show the output from the same slide, with both gradients in each image:

| Default | PowerPointUI |
| --- | --- |
| ![Default के साथ रेंडर किए गए स्यान‑से‑ऑरेंज और ब्लू‑से‑येलो ग्रेडिएंट](gradient-Default.png) | ![PowerPointUI के साथ रेंडर किए गए समान ग्रेडिएंट](gradient-PowerPointUI.png) |

In this example, `Default` produces lighter intermediate colors, while `PowerPointUI` produces darker intermediate colors. The difference depends on the colors and stops in the gradient.

Choose `Default` when the standard Aspose.Slides output suits your needs. Try `PowerPointUI` when your priority is matching the appearance in PowerPoint. Compare both outputs with your intended result; neither mode is universally preferable.

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं पूरी स्लाइड के बजाय कोई विशिष्ट आकार, जैसे चार्ट या चित्र, को कैसे निर्यात करूँ?**

Aspose.Slides supports [व्यक्तिगत आकृतियों के लिए थंबनेल उत्पन्न करना](/slides/hi/cpp/shape-thumbnails/), allowing you to render a shape as a PNG image.

**क्या सर्वर पर समानांतर रूपांतरण समर्थित है?**

Yes. Use a separate presentation instance for each thread or process; [थ्रेड्स के बीच एक ही उदाहरण साझा न करें](/slides/hi/cpp/multithreading/).

**PNG निर्यात करते समय मूल्यांकन सीमाएँ क्या हैं?**

Evaluation mode adds a watermark to output images and applies [अन्य प्रतिबंध](/slides/hi/cpp/licensing/) until a license is applied.