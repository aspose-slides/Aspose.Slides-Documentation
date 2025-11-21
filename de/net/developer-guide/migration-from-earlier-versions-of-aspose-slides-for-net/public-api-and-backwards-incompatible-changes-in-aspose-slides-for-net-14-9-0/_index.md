---
title: Öffentliche API und rückwärtsinkompatible Änderungen in Aspose.Slides für .NET 14.9.0
linktitle: Aspose.Slides für .NET 14.9.0
type: docs
weight: 110
url: /de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/
keywords:
- Migration
- Altcode
- Moderner Code
- Altansatz
- Moderner Ansatz
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Überblick über die öffentlichen API‑Aktualisierungen und Breaking‑Changes in Aspose.Slides für .NET, um Ihre PowerPoint‑PPT-, PPTX‑ und ODP‑Präsentationslösungen reibungslos zu migrieren."
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügt](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) oder [entfernt](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) Klassen, Methoden, Eigenschaften und so weiter auf und weitere Änderungen, die mit der Aspose.Slides for .NET 14.9.0 API eingeführt wurden.

{{% /alert %}} 
## **Öffentliche API-Änderungen**
#### **Vererbung von ICollection- und generischen IEnumerable-Schnittstellen zu ISmartArtNodeCollection hinzugefügt**
Die Klasse Aspose.Slides.SmartArt.SmartArtNodeCollection (und die zugehörige Schnittstelle Aspose.Slides.SmartArt.ISmartArtNodeCollection) erben die generische Schnittstelle IEnumerable<ISmartArtNode> und die Schnittstelle ICollection.
#### **Wert SmartArtLayoutType.Custom zum Enum hinzugefügt**
Der benutzerdefinierte SmartArt-Layouttyp stellt ein Diagramm mit einer benutzerdefinierten Vorlage dar. Benutzerdefinierte Diagramme können nur aus einer Präsentationsdatei geladen werden und können nicht über die Methode ShapeCollection.AddSmartArt(x, y, width, height, SmartArtLayoutType.Custom) erstellt werden.
#### **Klasse SmartArtShape und Schnittstelle ISmartArtShape hinzugefügt**
Die Klasse Aspose.Slides.SmartArt.SmartArtShape (und ihre Schnittstelle Aspose.Slides.SmartArt.ISmartArtShape) bietet Zugriff auf einzelne Formen in einem SmartArt-Diagramm. SmartArtShape kann verwendet werden, um FillFormat, LineFormat zu ändern, Hyperlinks hinzuzufügen und weitere Aufgaben auszuführen.

{{% alert color="primary" %}} 

**Hinweis**: SmartArtShape unterstützt die IShape-Eigenschaften RawFrame, Frame, Rotation, X, Y, Width, Height nicht und wirft beim Versuch, auf diese zuzugreifen, eine System.NotSupportedException.

Beispiel für die Verwendung:

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
#### **Klasse SmartArtShapeCollection, Schnittstelle ISmartArtShapeCollection und Eigenschaft ISmartArtNode.Shapes hinzugefügt**
Die Klasse Aspose.Slides.SmartArt.SmartArtShapeCollection (und ihre Schnittstelle Aspose.Slides.SmartArt.ISmartArtShapeCollection) ermöglicht Zugriff auf einzelne Formen in einem SmartArt-Diagramm. Die Sammlung enthält Formen, die einem SmartArtNode zugeordnet sind. Die Eigenschaft SmartArtNode.Shapes liefert Sammlungen aller mit dem Knoten verbundenen Formen.

{{% alert color="primary" %}} 

**Hinweis**: Je nach SmartArtLayoutType kann ein SmartArtShape zwischen mehreren Knoten gemeinsam verwendet werden.

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
#### **Methoden zum Speichern von Folien unter Beibehaltung der Seitennummern hinzugefügt**
Folgende Methoden wurden hinzugefügt:

- void IPresentation.Save(string fname, int[] slides, SaveFormat format);
- void IPresentation.Save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Diese Methoden ermöglichen Entwicklern, angegebene Präsentationsfolien in PDF-, XPS-, TIFF- und HTML-Formaten zu speichern. Das Array 'slides' wird verwendet, um Seitennummern anzugeben, beginnend bei 1.
Save(string fname, int[] slides, SaveFormat format);

``` csharp

 Presentation presentation = new Presentation(presentationFileName);

int[] slides = new int[] { 2, 3, 5 }; //Array of slides positions

presentation.Save(outFileName, slides, SaveFormat.Pdf);

``` 
#### **Methoden zum Ersetzen von Bildern zu PPImage, IPPImage hinzugefügt**
Neue Methoden hinzugefügt:

- IPPImage.ReplaceImage(byte[] newImageData)
- IPPImage.ReplaceImage(Image newImage)
- IPPImage.ReplaceImage(IPPImage newImage)

``` csharp

 Presentation presentation = new Presentation(presentation.pptx);

//First method

byte[] data = File.ReadAllBytes(image0.jpeg);

IPPImage oldImage = presentation.Images[0];

oldImage.ReplaceImage(data);

//Second method

Image newImage = Image.FromFile(image1.png);

oldImage = presentation.Images[1];

oldImage.ReplaceImage(newImage);

//Third method

oldImage = presentation.Images[2];

oldImage.ReplaceImage(presentation.Images[3]);

presentation.Save(presentation_out.pptx, SaveFormat.Pptx);

```