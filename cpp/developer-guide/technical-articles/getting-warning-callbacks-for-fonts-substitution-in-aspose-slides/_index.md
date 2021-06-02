---
title: Getting Warning Callbacks for Fonts Substitution in Aspose.Slides
type: docs
weight: 70
url: /cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
---

{{% alert color="primary" %}} 

Aspose.Slides for C++ makes it possible to get warning callbacks for fonts substitution in case the used font is not available on a machine during the rendering process. The warning callbacks are helpful when debugging issues of missing or inaccessible fonts during the rendering process.

{{% /alert %}} 
## **Getting Warning Callbacks for Fonts substitution**
Aspose.Slides for C++ provides a simple API methods to get the Warning Callbacks during the rendering process. All you need is to follow the steps below to configure the Warning Callbacks on your end:

1. Create a custom Callback class to receive the callbacks.
1. Set the Warning Callbacks using [LoadOptions](https://apireference.aspose.com/slides/cpp/class/aspose.slides.load_options) class.
1. Load the presentation file that is using a font for text inside that is unavailable on your target machine.
1. Generate the slide thumbnail to see the effect.

``` cpp
class HandleFontsWarnings : public Warnings::IWarningCallback
{
public:
    Warnings::ReturnAction Warning(SharedPtr<Warnings::IWarningInfo> warning) override
    {
        if (warning->get_WarningType() == Warnings::WarningType::CompatibilityIssue)
        {
            return Warnings::ReturnAction::Continue;
        }

        // 1 - WarningType.DataLoss
        Console::WriteLine(System::ObjectExt::ToString(warning->get_WarningType()));
        // "Font will be substituted from X to Y"
        Console::WriteLine(warning->get_Description());

        return Warnings::ReturnAction::Continue;
    }
};
        
void Run()
{
    String dataDir = GetDataPath();

    // Setting Warning Callbacks
    SharedPtr<LoadOptions> options = System::MakeObject<LoadOptions>();
    options->set_WarningCallback(System::MakeObject<HandleFontsWarnings>());

    // Instantiate the presentation
    SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(dataDir + u"presentation.pptx", options);

    // Generating slide thumbnails
    for (auto slide : presentation->get_Slides())
    {
        SharedPtr<System::Drawing::Image> image = slide->GetThumbnail();
    }
}
```
