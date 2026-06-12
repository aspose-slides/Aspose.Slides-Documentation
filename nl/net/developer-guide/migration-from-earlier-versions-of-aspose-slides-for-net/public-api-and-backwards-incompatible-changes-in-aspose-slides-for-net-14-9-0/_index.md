---
title: Publieke API en terugwaartse incompatibele wijzigingen in Aspose.Slides for .NET 14.9.0
linktitle: Aspose.Slides for .NET 14.9.0
type: docs
weight: 110
url: /nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/
keywords:
- migratie
- legacy-code
- moderne code
- legacy-aanpak
- moderne aanpak
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Bekijk de publieke API-updates en breaking changes in Aspose.Slides for .NET om uw PowerPoint PPT-, PPTX- en ODP-presentatieoplossingen soepel te migreren."
---
{{% alert color="primary" %}} 

Deze pagina geeft een overzicht van alle [toegevoegd](/slides/nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) of [verwijderd](/slides/nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) klassen, methoden, eigenschappen enzovoort, en andere wijzigingen die geïntroduceerd zijn met de Aspose.Slides for .NET 14.9.0 API.

{{% /alert %}} 
## **Aanpassingen van de publieke API**
#### **Erfenis van ICollection- en generieke IEnumerable‑interfaces toegevoegd aan ISmartArtNodeCollection**
De klasse Aspose.Slides.SmartArt.SmartArtNodeCollection (en de gerelateerde interface Aspose.Slides.SmartArt.ISmartArtNodeCollection) erven de generieke interface IEnumerable<ISmartArtNode> en de interface ICollection.
#### **SmartArtLayoutType.Custom enum‑waarde toegevoegd**
Het type Custom SmartArt‑layout staat voor een diagram met een aangepast sjabloon. Aangepaste diagrammen kunnen alleen worden geladen uit een presentatiedossier en kunnen niet worden aangemaakt via de methode ShapeCollection.AddSmartArt(x, y, width, height, SmartArtLayoutType.Custom).
#### **SmartArtShape‑klasse en ISmartArtShape‑interface toegevoegd**
De klasse Aspose.Slides.SmartArt.SmartArtShape (en de bijbehorende interface Aspose.Slides.SmartArt.ISmartArtShape) biedt toegang tot individuele vormen in een SmartArt‑diagram. SmartArtShape kan worden gebruikt om FillFormat, LineFormat te wijzigen, hyperlinks toe te voegen en andere taken uit te voeren.

{{% alert color="primary" %}} 

**Opmerking**: SmartArtShape ondersteunt de IShape‑eigenschappen RawFrame, Frame, Rotation, X, Y, Width, Height niet en gooit een System.NotSupportedException wanneer geprobeerd wordt ze te benaderen.

Voorbeeld van gebruik:

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  ISmartArtNode node = smart.AllNodes[0];

  foreach (SmartArtShape shape in node.Shapes)

  {

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.Color = Color.Red;

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 

{{% /alert %}} 
#### **SmartArtShapeCollection‑klasse, ISmartArtShapeCollection‑interface en ISmartArtNode.Shapes‑eigenschap toegevoegd**
De klasse Aspose.Slides.SmartArt.SmartArtShapeCollection (en de bijbehorende interface Aspose.Slides.SmartArt.ISmartArtShapeCollection) biedt toegang tot individuele vormen in een SmartArt‑diagram. De collectie bevat vormen die gekoppeld zijn aan SmartArtNode. De eigenschap SmartArtNode.Shapes retourneert collecties van alle vormen die aan het knooppunt zijn gekoppeld.

{{% alert color="primary" %}} 

**Opmerking**: afhankelijk van het SmartArtLayoutType kan één SmartArtShape gedeeld worden tussen meerdere knooppunten.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  ISmartArtNode node = smart.AllNodes[0];

  foreach (SmartArtShape shape in node.Shapes)

  {

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.Color = Color.Red;

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 

{{% /alert %}} 
#### **Methoden toegevoegd om dia's met paginanummers op te slaan**
De volgende methoden zijn toegevoegd:

- void IPresentation.Save(string fname, int[] slides, SaveFormat format);
- void IPresentation.Save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Met deze methoden kunnen ontwikkelaars opgegeven presentatiedia's opslaan in PDF-, XPS-, TIFF- of HTML‑formaten. De array 'slides' wordt gebruikt om paginanummers op te geven, beginnend bij 1.
Save(string fname, int[] slides, SaveFormat format);

``` csharp

 Presentation presentation = new Presentation(presentationFileName);

int[] slides = new int[] { 2, 3, 5 }; //Array van dia posities

presentation.Save(outFileName, slides, SaveFormat.Pdf);

``` 
#### **Methoden toegevoegd voor het vervangen van afbeeldingen in PPImage, IPPImage**
Nieuwe methoden toegevoegd:

- IPPImage.ReplaceImage(byte[] newImageData)
- IPPImage.ReplaceImage(Image newImage)
- IPPImage.ReplaceImage(IPPImage newImage)

``` csharp

 Presentation presentation = new Presentation(presentation.pptx);

//Eerste methode

byte[] data = File.ReadAllBytes(image0.jpeg);

IPPImage oldImage = presentation.Images[0];

oldImage.ReplaceImage(data);

//Tweede methode

Image newImage = Image.FromFile(image1.png);

oldImage = presentation.Images[1];

oldImage.ReplaceImage(newImage);

//Derde methode

oldImage = presentation.Images[2];

oldImage.ReplaceImage(presentation.Images[3]);

presentation.Save(presentation_out.pptx, SaveFormat.Pptx);

```