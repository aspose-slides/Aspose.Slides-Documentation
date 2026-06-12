---
title: Conversie van PPT naar PPTX-formaat in Aspose.Slides
type: docs
weight: 10
url: /nl/net/conversion-from-ppt-to-pptx-format-in-aspose-slides/
---
**Aspose.Slides** voor .NET stelt ontwikkelaars nu in staat om de PPT te benaderen met een Presentation class instance en deze om te zetten naar het bijbehorende PPTX formaat. Momenteel ondersteunt het gedeeltelijke conversie van PPT naar PPTX. Voor meer details over welke functies wel of niet ondersteund worden bij de conversie van PPT naar PPTX, ga naar deze documentatielink.

**Aspose.Slides** voor .NET biedt de Presentation class die een PPTX presentatiebestand vertegenwoordigt. De Presentation class kan nu ook PPT benaderen via Presentation wanneer het object wordt geinstantieerd.

``` csharp

 //Instantieer een Presentation-object dat een PPTX-bestand vertegenwoordigt

PresentationEx pres = new PresentationEx("Conversion.ppt");

//De PPTX-presentatie opslaan in PPTX-indeling

pres.Save(MyDir +"Converted.pptx", SaveFormat.Pptx);

``` 
## **Download Sample Code**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20PPT%20to%20PPTX%20%28Aspose.Slides%29.zip)