---
title: Convert Presentation to XPS
type: docs
weight: 60
url: /net/convert-presentation-to-xps/
---

**XPS** format is also widely used for exchange of data. Aspose.Slides for .NET takes care of its importance and provides the built-in support for converting a presentation into XPS document.

The **Save** method exposed by Presentation class can be used to convert the whole presentation into **XPS** document. Further, **XpsOptions** class exposes **SaveMetafileAsPng** property that can be set to true or false as per requirement.
## **Example**

``` 

 //Instantiate a Presentation object that represents a presentation file

Presentation pres = new Presentation("Conversion.ppt");

//Saving the presentation to TIFF document

pres.Save("converted.xps", Aspose.Slides.Export.SaveFormat.Xps);

``` 
## **Download Running Example**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/Converting to XPS/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20XPS)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode)
## **Download Sample Code**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)

{{% alert color="primary" %}} 

For more details, visit [Conversion to XPS](/slides/net/convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document/).

{{% /alert %}}
