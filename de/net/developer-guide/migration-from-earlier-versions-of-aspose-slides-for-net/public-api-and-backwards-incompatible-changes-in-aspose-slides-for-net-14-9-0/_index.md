---
title: Öffentliche API und rückwärtsinkompatible Änderungen in Aspose.Slides für .NET 14.9.0
linktitle: Aspose.Slides für .NET 14.9.0
type: docs
weight: 110
url: /de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/
keywords:
- Migration
- Legacy-Code
- Moderner Code
- Legacy-Ansatz
- Moderner Ansatz
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Überblick über öffentliche API‑Aktualisierungen und Breaking Changes in Aspose.Slides für .NET, um Ihre PowerPoint‑PPT, PPTX‑ und ODP‑Präsentationslösungen reibungslos zu migrieren."
---
{{% alert color="info" %}} 

Diese Seite listet alle [added](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) oder [removed](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) Klassen, Methoden, Eigenschaften usw. sowie weitere Änderungen, die mit der Aspose.Slides for .NET 14.9.0 API eingeführt wurden.

{{% /alert %}} 
## **Öffentliche API-Änderungen**
#### **Vererbung von ICollection und generischen IEnumerable‑Schnittstellen zu ISmartArtNodeCollection hinzugefügt**
Die Klasse Aspose.Slides.SmartArt.SmartArtNodeCollection (und das zugehörige Interface Aspose.Slides.SmartArt.ISmartArtNodeCollection) erben die generische Schnittstelle IEnumerable<ISmartArtNode> sowie die Schnittstelle ICollection.
#### **Enum‑Wert SmartArtLayoutType.Custom hinzugefügt**
Der benutzerdefinierte SmartArt‑Layout‑Typ stellt ein Diagramm mit einer eigenen Vorlage dar. Benutzerdefinierte Diagramme können nur aus einer Präsentationsdatei geladen werden und können nicht über die Methode ShapeCollection.AddSmartArt(x, y, width, height, SmartArtLayoutType.Custom) erstellt werden.
#### **Klasse SmartArtShape und Interface ISmartArtShape hinzugefügt**
Die Klasse Aspose.Slides.SmartArt.SmartArtShape (und ihr Interface Aspose.Slides.SmartArt.ISmartArtShape) ermöglichen den Zugriff auf einzelne Formen in einem SmartArt‑Diagramm. SmartArtShape kann verwendet werden, um FillFormat, LineFormat, Hyperlinks und weitere Aufgaben zu ändern.

{{% alert color="info" %}} 

**Hinweis**: SmartArtShape unterstützt die IShape‑Eigenschaften RawFrame, Frame, Rotation, X, Y, Width, Height nicht und wirft eine System.NotSupportedException, wenn versucht wird, auf diese zuzugreifen.

Beispiel für die Verwendung:

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
#### **Klasse SmartArtShapeCollection, Interface ISmartArtShapeCollection und Eigenschaft ISmartArtNode.Shapes hinzugefügt**
Die Klasse Aspose.Slides.SmartArt.SmartArtShapeCollection (und ihr Interface Aspose.Slides.SmartArt.ISmartArtShapeCollection) ermöglichen den Zugriff auf einzelne Formen in einem SmartArt‑Diagramm. Die Sammlung enthält Formen, die einem SmartArtNode zugeordnet sind. Die Eigenschaft SmartArtNode.Shapes gibt Sammlungen aller dem Knoten zugewiesenen Formen zurück.

{{% alert color="info" %}} 

**Hinweis**: Abhängig vom SmartArtLayoutType kann ein SmartArtShape zwischen mehreren Knoten gemeinsam genutzt werden.

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
#### **Methoden zum Speichern von Folien mit Angabe von Seitenzahlen hinzugefügt**
Folgende Methoden wurden hinzugefügt:

- void IPresentation.Save(string fname, int[] slides, SaveFormat format);
- void IPresentation.Save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Diese Methoden ermöglichen Entwicklern, ausgewählte Präsentationsfolien in PDF, XPS, TIFF, HTML‑Formaten zu speichern. Das Array „slides“ wird verwendet, um Seitenzahlen anzugeben, beginnend bei 1.
Save(string fname, int[] slides, SaveFormat format);

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("presentation.pptx"))
{
    int[] slides = new int[] { 2, 3, 5 }; //Array von Folienpositionen

    presentation.Save("output.pdf", slides, SaveFormat.Pdf);
}
``` 
#### **Methoden zum Ersetzen von Bildern zu PPImage, IPPImage hinzugefügt**
Neue Methoden:

- IPPImage.ReplaceImage(byte[] newImageData)
- IPPImage.ReplaceImage(Image newImage)
- IPPImage.ReplaceImage(IPPImage newImage)

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("presentation.pptx"))
{
    //Erste Methode

    byte[] data = File.ReadAllBytes("image0.jpeg");

    IPPImage oldImage = presentation.Images[0];

    oldImage.ReplaceImage(data);

    //Zweite Methode

    IImage newImage = Images.FromFile("image1.png");

    oldImage = presentation.Images[1];

    oldImage.ReplaceImage(newImage);

    //Dritte Methode

    oldImage = presentation.Images[2];

    oldImage.ReplaceImage(presentation.Images[3]);

    presentation.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```