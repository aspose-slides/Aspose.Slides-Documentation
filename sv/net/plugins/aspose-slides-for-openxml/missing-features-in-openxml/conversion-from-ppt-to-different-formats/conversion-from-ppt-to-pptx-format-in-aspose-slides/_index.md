---
title: Konvertering från PPT till PPTX-format i Aspose.Slides
type: docs
weight: 10
url: /sv/net/conversion-from-ppt-to-pptx-format-in-aspose-slides/
---
**Aspose.Slides** för .NET underlättar nu för utvecklare att komma åt PPT med hjälp av ett Presentation class‑objekt och konvertera det till motsvarande PPTX‑format. För närvarande stöder den partiell konvertering av PPT till PPTX. För mer information om vilka funktioner som stöds och vilka som inte stöds i PPT‑till‑PPTX‑konvertering, gå till den här dokumentationslänken.

**Aspose.Slides** för .NET erbjuder Presentation class som representerar en PPTX‑presentationsfil. Presentation class kan nu också få åtkomst till PPT via Presentation när objektet instansieras.

``` csharp

 //Instansiera ett Presentation-objekt som representerar en PPTX-fil

PresentationEx pres = new PresentationEx("Conversion.ppt");

//Sparar PPTX-presentationen i PPTX-format

pres.Save(MyDir +"Converted.pptx", SaveFormat.Pptx);

``` 
## **Download Sample Code**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20PPT%20to%20PPTX%20%28Aspose.Slides%29.zip)