---
title: Openbare API en achterwaarts incompatibele wijzigingen in Aspose.Slides voor .NET 14.9.0
linktitle: Aspose.Slides voor .NET 14.9.0
type: docs
weight: 110
url: /nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/
keywords:
- migratie
- verouderde code
- moderne code
- verouderde aanpak
- moderne aanpak
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Bekijk de updates van de openbare API en de brekende wijzigingen in Aspose.Slides voor .NET om uw PowerPoint PPT, PPTX en ODP presentatiesoftware soepel te migreren."
---
{{% alert color="info" %}} 

Deze pagina somt alle [toegevoegde](/slides/nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) of [verwijderde](/slides/nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) klassen, methoden, eigenschappen enzovoort, en andere wijzigingen geïntroduceerd met de Aspose.Slides for .NET 14.9.0 API.

{{% /alert %}} 
## **Openbare API-wijzigingen**
#### **Erfenis van ICollection en Generic IEnumerable Interfaces toegevoegd aan ISmartArtNodeCollection**
De klasse Aspose.Slides.SmartArt.SmartArtNodeCollection (en de gerelateerde interface Aspose.Slides.SmartArt.ISmartArtNodeCollection) erven de generieke interface IEnumerable<ISmartArtNode> en de interface ICollection.
#### **SmartArtLayoutType.Custom enum‑waarde toegevoegd**
Het type Custom SmartArt‑indeling vertegenwoordigt een diagram met een aangepast sjabloon. Aangepaste diagrammen kunnen alleen worden geladen vanuit een presentatiedocument en kunnen niet worden aangemaakt via de methode ShapeCollection.AddSmartArt(x, y, width, height, SmartArtLayoutType.Custom).
#### **SmartArtShape‑klasse en ISmartArtShape‑interface toegevoegd**
De klasse Aspose.Slides.SmartArt.SmartArtShape (en de interface Aspose.Slides.SmartArt.ISmartArtShape) biedt toegang tot afzonderlijke vormen in een SmartArt‑diagram. SmartArtShape kan worden gebruikt om FillFormat, LineFormat, hyperlinks toe te voegen en andere taken uit te voeren.

{{% alert color="info" %}} 

**Opmerking**: SmartArtShape ondersteunt de IShape‑eigenschappen RawFrame, Frame, Rotation, X, Y, Width, Height niet en werpt een System.NotSupportedException wanneer geprobeerd wordt deze te benaderen.

Voorbeeld van gebruik:

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using (Presentation pres = new Presentation())
{
  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  ISmartArtNode node = smart.AllNodes[0];

  foreach (ISmartArtShape shape in node.Shapes)
  {
    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.Color = Color.Red;
  }

  pres.Save("out.pptx", SaveFormat.Pptx);
}
``` 

{{% /alert %}} 
#### **SmartArtShapeCollection‑klasse, ISmartArtShapeCollection‑interface en ISmartArtNode.Shapes‑eigenschap toegevoegd**
De klasse Aspose.Slides.SmartArt.SmartArtShapeCollection (en de interface Aspose.Slides.SmartArt.ISmartArtShapeCollection) geven toegang tot afzonderlijke vormen in een SmartArt‑diagram. De collectie bevat vormen die zijn gekoppeld aan SmartArtNode. De eigenschap SmartArtNode.Shapes retourneert collecties van alle vormen die bij het knooppunt horen.

{{% alert color="info" %}} 

**Opmerking**: afhankelijk van de SmartArtLayoutType kan één SmartArtShape door meerdere knooppunten worden gedeeld.

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using (Presentation pres = new Presentation())
{
  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  ISmartArtNode node = smart.AllNodes[0];

  foreach (ISmartArtShape shape in node.Shapes)
  {
    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.Color = Color.Red;
  }

  pres.Save("out.pptx", SaveFormat.Pptx);
}
``` 

{{% /alert %}} 
#### **Methoden voor opslaan van dia's met paginanummers behouden**
De volgende methoden zijn toegevoegd:

- void IPresentation.Save(string fname, int[] slides, SaveFormat format);
- void IPresentation.Save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Deze methoden stellen ontwikkelaars in staat om opgegeven presentatiedia's op te slaan als PDF, XPS, TIFF, HTML‑formaten. Het 'slides'-array wordt gebruikt om paginanummers op te geven, beginnend bij 1.
Save(string fname, int[] slides, SaveFormat format);

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("presentation.pptx"))
{
    int[] slides = new int[] { 2, 3, 5 }; //Array met dia posities

    presentation.Save("output.pdf", slides, SaveFormat.Pdf);
}
``` 
#### **Methoden voor het vervangen van afbeeldingen toegevoegd aan PPImage, IPPImage**
Nieuwe methoden toegevoegd:

- IPPImage.ReplaceImage(byte[] newImageData)
- IPPImage.ReplaceImage(Image newImage)
- IPPImage.ReplaceImage(IPPImage newImage)

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("presentation.pptx"))
{
    //Eerste methode

    byte[] data = File.ReadAllBytes("image0.jpeg");

    IPPImage oldImage = presentation.Images[0];

    oldImage.ReplaceImage(data);

    //Tweede methode

    IImage newImage = Images.FromFile("image1.png");

    oldImage = presentation.Images[1];

    oldImage.ReplaceImage(newImage);

    //Derde methode

    oldImage = presentation.Images[2];

    oldImage.ReplaceImage(presentation.Images[3]);

    presentation.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```