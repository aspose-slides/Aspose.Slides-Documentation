---
title: Get Warning Callbacks for Font Substitution
type: docs
weight: 70
url: /cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- warning callback
- font substitution
- rendering process
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Learn to get warning callbacks for font substitution in Aspose.Slides for C++ and display PowerPoint and OpenDocument presentations accurately."
---

## **Overview**

Aspose.Slides for C++ allows you to receive warning callbacks for font substitution when a required font isn’t available on the machine during rendering. These callbacks help diagnose issues with missing or inaccessible fonts.

## **Enable Warning Callbacks**

Aspose.Slides for C++ provides straightforward APIs for receiving warning callbacks when rendering presentation slides. Follow these steps to configure warning callbacks:

1. Create a custom callback class that implements the [IWarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.warnings/iwarningcallback/) interface to handle warnings.
1. Set the warning callback using option classes such as [RenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/renderingoptions/), [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/htmloptions/), and others.
1. Load a presentation that uses a font not available on the target machine.
1. Generate a slide thumbnail or export the presentation to observe the effect.

**Custom Warning Callback Class:**

```cpp
#include <Warnings/IWarningCallback.h>

class FontWarningHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override;
};

ReturnAction FontWarningHandler::Warning(SharedPtr<IWarningInfo> warning)
{
    if (warning->get_WarningType() == WarningType::DataLoss)
    {
        Console::WriteLine(warning->get_Description());
    }

    return ReturnAction::Continue;
}

// Example output:
//
// Font will be substituted from XYZ to {Calibri,Cambria Math,MS Gothic,Gulim,Arial Unicode,SimSun,Segoe UI Symbol}}
```

**Generate a Slide Thumbnail:**

```cpp
// Set up a warning callback to handle font-related warnings during slide rendering.
auto options = MakeObject<RenderingOptions>();
options->set_WarningCallback(MakeObject<FontWarningHandler>());

// Load the presentation from the specified file path.
auto presentation = MakeObject<Presentation>(u"sample.pptx");
    
// Generate a thumbnail image for each slide in the presentation.
for(auto&& slide : presentation->get_Slides())
{
    // Get the slide thumbnail image using the specified rendering options.
    auto image = slide->GetImage(options);
    // ...

    image->Dispose();
}

presentation->Dispose();
```

**Export to PDF Format:**

```cpp
// Set up a warning callback to handle font-related warnings during PDF export.
auto options = MakeObject<PdfOptions>();
options->set_WarningCallback(MakeObject<FontWarningHandler>());

// Load the presentation from the specified file path.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Export the presentation as PDF.
auto stream = MakeObject<MemoryStream>();
presentation->Save(stream, SaveFormat::Pdf, options);
// ...

stream->Dispose();
presentation->Dispose();
```

**Export to HTML Format:**

```cpp
// Set up a warning callback to handle font-related warnings during HTML export.
auto options = MakeObject<HtmlOptions>();
options->set_WarningCallback(MakeObject<FontWarningHandler>());

// Load the presentation from the specified file path.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Export the presentation in HTML format.
auto stream = MakeObject<MemoryStream>();
presentation->Save(stream, SaveFormat::Html, options);
// ...

stream->Dispose();
presentation->Dispose();
```
