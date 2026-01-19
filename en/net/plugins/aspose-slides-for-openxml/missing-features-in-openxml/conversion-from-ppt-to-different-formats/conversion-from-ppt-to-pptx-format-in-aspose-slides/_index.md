---
title: Conversion from PPT to PPTX format in Aspose.Slides
type: docs
weight: 10
url: /net/conversion-from-ppt-to-pptx-format-in-aspose-slides/
---

**Aspose.Slides** for .NET now facilitates the developers to access the PPT using Presentation class instance and converting that to respective PPTX format. Presently, it supports partial conversion of PPT to PPTX. For more details about what features are supported and unsupported in PPT to PPTX conversion, please proceed to this documentation link.

**Aspose.Slides** for .NET offers Presentation class that represents a PPTX presentation file. Presentation class can now also access PPT through Presentation when the object is instantiated.

``` csharp

 //Instantiate a Presentation object that represents a PPTX file

PresentationEx pres = new PresentationEx("Conversion.ppt");

//Saving the PPTX presentation to PPTX format

pres.Save(MyDir +"Converted.pptx", SaveFormat.Pptx);

``` 
## **Download Sample Code**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20PPT%20to%20PPTX%20%28Aspose.Slides%29.zip)
