---
title: Getting Warning Callbacks for Fonts Substitution in Aspose.Slides
type: docs
weight: 120
url: /pythonnet/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
---

{{% alert color="primary" %}} 

Aspose.Slides for Python via .NET makes it possible to get warning callbacks for fonts substitution in case the used font is not available on machine during rendering process. The warning callbacks are helpful in debugging the issues of missing or inaccessible fonts during rendering process.

{{% /alert %}} 
## **Getting Warning Callbacks for Fonts substitution**
Aspose.Slides for Python via .NET provides a simple API methods to get the Warning Callbacks during rendering process. All you need is to follow the steps below to configure the Warning Callbacks on your end.:

1. Create a custom Callback class to receive the callbacks.
1. Set the Warning Callbacks using using LoadOptions class
1. Load the presentation file that is using a font for text inside that is unavailable on your target machine.
1. Generate the slide thumbnail to see the effect.

```py
//Setting Warning Callbacks
LoadOptions lo = new LoadOptions();
lo.WarningCallback = new HandleFontsWarnings();

//Instantiate the presentation
Presentation presentation = new Presentation("1.ppt", lo);

//Generating slide thumbnail
foreach (ISlide slide in presentation.Slides)
{
    Image image = slide.GetThumbnail();
}
```

```py
class HandleFontsWarnings : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        Console.WriteLine(warning.WarningType); // 1 - WarningType.DataLoss
        Console.WriteLine(warning.Description); // "Font will be substituted from X to Y"
        return ReturnAction.Continue;
    }
}
```



