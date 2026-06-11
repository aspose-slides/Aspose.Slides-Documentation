---
title: Offentliga API- och bakåtinkompatibla förändringar i Aspose.Slides för .NET 14.9.0
linktitle: Aspose.Slides för .NET 14.9.0
type: docs
weight: 110
url: /sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/
keywords:
- migration
- gammal kod
- modern kod
- gammal metod
- modern metod
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Granska offentliga API-uppdateringar och brytande förändringar i Aspose.Slides för .NET för att smidigt migrera dina PowerPoint PPT-, PPTX- och ODP-presentationslösningar."
---
{{% alert color="primary" %}} 

Denna sida listar alla [tillagda](/slides/sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) eller [borttagna](/slides/sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) klasser, metoder, egenskaper med mera, samt andra ändringar som införts med Aspose.Slides for .NET 14.9.0 API.

{{% /alert %}} 
## **Offentliga API-ändringar**
#### **Arv från ICollection- och generiska IEnumerable-gränssnitt har lagts till i ISmartArtNodeCollection**
Klassen Aspose.Slides.SmartArt.SmartArtNodeCollection (och det relaterade gränssnittet Aspose.Slides.SmartArt.ISmartArtNodeCollection) ärver det generiska gränssnittet IEnumerable<ISmartArtNode> och gränssnittet ICollection.
#### **SmartArtLayoutType.Custom enum‑värde har lagts till**
Den anpassade SmartArt‑layouttypen representerar ett diagram med en anpassad mall. Anpassade diagram kan endast laddas från en presentationsfil och kan inte skapas via metoden ShapeCollection.AddSmartArt(x, y, width, height, SmartArtLayoutType.Custom).
#### **SmartArtShape-klass och ISmartArtShape-gränssnitt har lagts till**
Klassen Aspose.Slides.SmartArt.SmartArtShape (och dess gränssnitt Aspose.Slides.SmartArt.ISmartArtShape) ger åtkomst till enskilda former i ett SmartArt‑diagram. SmartArtShape kan användas för att ändra FillFormat, LineFormat, lägga till hyperlänkar och andra uppgifter.

{{% alert color="primary" %}} 

**Note**: SmartArtShape stöder inte IShape‑egenskaperna RawFrame, Frame, Rotation, X, Y, Width, Height och kastar ett System.NotSupportedException när man försöker komma åt dem.

Exempel på användning:

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
#### **SmartArtShapeCollection-klass, ISmartArtShapeCollection-gränssnitt och ISmartArtNode.Shapes‑egenskap har lagts till**
Klassen Aspose.Slides.SmartArt.SmartArtShapeCollection (och dess gränssnitt Aspose.Slides.SmartArt.ISmartArtShapeCollection) ger åtkomst till enskilda former i ett SmartArt‑diagram. Samlingen innehåller former som är knutna till SmartArtNode. Egenskapen SmartArtNode.Shapes returnerar samlingar av alla former som är kopplade till noden.

{{% alert color="primary" %}} 

**Note**: beroende på SmartArtLayoutType kan en SmartArtShape delas mellan flera noder.

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
#### **Metoder för att spara bilder med sidnummer bibehållna har lagts till**
Följande metoder har lagts till:

- void IPresentation.Save(string fname, int[] slides, SaveFormat format);
- void IPresentation.Save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Dessa metoder låter utvecklare spara angivna presentationsbilder till PDF-, XPS-, TIFF- och HTML-format. 'slides'-arrayen används för att ange sidnummer, med början på 1.
Save(string fname, int[] slides, SaveFormat format);

``` csharp

 Presentation presentation = new Presentation(presentationFileName);
int[] slides = new int[] { 2, 3, 5 }; //Array med bildpositioner

presentation.Save(outFileName, slides, SaveFormat.Pdf);

``` 
#### **Metoder för att ersätta bilder har lagts till till PPImage, IPPImage**
Nya metoder har lagts till:

- IPPImage.ReplaceImage(byte[] newImageData)
- IPPImage.ReplaceImage(Image newImage)
- IPPImage.ReplaceImage(IPPImage newImage)

``` csharp

 Presentation presentation = new Presentation(presentation.pptx);
//Första metoden

byte[] data = File.ReadAllBytes(image0.jpeg);

IPPImage oldImage = presentation.Images[0];

oldImage.ReplaceImage(data);

//Andra metoden

Image newImage = Image.FromFile(image1.png);

oldImage = presentation.Images[1];

oldImage.ReplaceImage(newImage);

//Tredje metoden

oldImage = presentation.Images[2];

oldImage.ReplaceImage(presentation.Images[3]);

presentation.Save(presentation_out.pptx, SaveFormat.Pptx);

```