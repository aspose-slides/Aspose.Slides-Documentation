---
title: Conversion of OpenOffice Document
type: docs
weight: 30
url: /net/conversion-of-openoffice-document/
---

Aspose.Slides for .NET offers **Presentation** class that represents a presentation file. **Presentation** class can now also access **ODP** through Presentation constructor when the object is instantiated.

Below is the example of converting from ODP to PPT/PPTX.
#### **Example**
{{< highlight cs >}}

 //Instantiate a Presentation object that represents a presentation file

using(PresentationEx pres = new PresentationEx("OpenOfficePresentation.odp"))

{

   //Saving the PPTX presentation to PPTX format

   pres.Save("ConvertedFromOdp",Aspose.Slides.Export.SaveFormat.Pptx);

}

```

Below is the example of converting from PPT/PPTX to ODP.
#### **Example**
{{< highlight cs >}}

 //Instantiate a Presentation object that represents a presentation file

using (PresentationEx pres = new PresentationEx("ConversionFromPresentation.pptx"))

{

   //Saving the PPTX presentation to PPTX format

   pres.Save("ConvertedToOdp", Aspose.Slides.Export.SaveFormat.Odp);

}

```
#### **Download Running Example**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/Conversion from ODP to PPTX/Converting From and To ODP/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Conversion%20from%20ODP%20to%20PPTX)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode)
#### **Download Sample Code**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)

{{% alert color="primary" %}} 

For more details, visit [Accessing OpenDocument Presentation](http://www.aspose.com/docs/display/slidesnet/Accessing+OpenDocument+Presentation).

{{% /alert %}}
