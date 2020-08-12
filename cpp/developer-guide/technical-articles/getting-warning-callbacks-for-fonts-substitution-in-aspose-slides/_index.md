---
title: Getting Warning Callbacks for Fonts Substitution in Aspose.Slides
type: docs
weight: 70
url: /cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
---

{{% alert color="primary" %}} 

Aspose.Slides for C++ makes it possible to get warning callbacks for fonts substitution in case the used font is not available on machine during rendering process. The warning callbacks are helpful in debugging the issues of missing or inaccessible fonts during rendering process.

{{% /alert %}} 
#### **Getting Warning Callbacks for Fonts substitution**
Aspose.Slides for C++ provides a simple API methods to get the Warning Callbacks during rendering process. All you need is to follow the steps below to configure the Warning Callbacks on your end.:

1. Create a custom Callback class to receive the callbacks.
1. Set the Warning Callbacks using using LoadOptions class
1. Load the presentation file that is using a font for text inside that is unavailable on your target machine.
1. Generate the slide thumbnail to see the effect.

[**C#**](/pages/createpage.action?spaceKey=slidescpp&title=C&linkCreation=true&fromPageId=60228444)

```

 class HandleFontsWarnings : Aspose.Slides.Warnings.IWarningCallback

{

    public int warning(IWarningInfo warning)

    {

        Console.WriteLine(warning.getWarningType()); // 1 - WarningType.DataLoss

        Console.WriteLine(warning.getDescription()); // "Font will be substituted from X to Y"

        return ReturnAction.Continue;

    }

}

//Setting Warning Callbacks

LoadOptions lo = new LoadOptions();

lo.WarningCallback=new HandleFontsWarnings();

//Instantiate the presentation

Presentation presentation = new Presentation(path+"1.ppt", lo);

//Generating slide thumbnail

foreach(ISlide slide in presentation.Slides)

{

	Image image = slide.getThumbnail();

}


```




