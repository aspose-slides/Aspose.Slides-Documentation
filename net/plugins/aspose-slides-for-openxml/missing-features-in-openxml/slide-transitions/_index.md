---
title: Slide Transitions
type: docs
weight: 80
url: /net/slide-transitions/
---

To make it easier to understand, we have demonstrated the use of Aspose.Slides for .NET to manage simple slide transitions. Developers can not only apply different slide transition effects on the slides, but also customize the behavior of these transition effects.To create a simple slide transition effect, follow the steps below:

- Create an instance of Presentation class
- Apply a Slide Transition Type on the slide from one of the transition effects offered by Aspose.Slides for .NET through **TransitionType** enum
- Write the modified presentation file.
##### **Example**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Managing Slides Transitions.pptx";

//Instantiate Presentation class that represents a presentation file

using (Presentation pres = new Presentation(FileName))

{

    //Apply circle type transition on slide 1

    pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

    //Apply comb type transition on slide 2

    pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    //Apply zoom type transition on slide 3

    pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;

    //Write the presentation to disk

    pres.Save(FileName, SaveFormat.Pptx);

}

``` 
## **Download Sample Code**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
## **Download Running Example**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in OpenXML/Managing Slides Transitions/)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Managing%20Slides%20Transitions)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c/view/SourceCode)

{{% alert color="primary" %}} 

For more details, visit [Managing Slides Transitions](/slides/net/slide-transition/).

{{% /alert %}}
