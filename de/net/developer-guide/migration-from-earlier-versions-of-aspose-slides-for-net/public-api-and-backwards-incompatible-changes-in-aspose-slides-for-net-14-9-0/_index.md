---
title: Öffentliche API und rückwärts inkompatible Änderungen in Aspose.Slides für .NET 14.9.0
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
description: "Überprüfen Sie die öffentlichen API-Updates und Breaking Changes in Aspose.Slides für .NET, um Ihre PowerPoint PPT, PPTX und ODP Präsentationslösungen reibungslos zu migrieren."
---

{{% alert color="primary" %}} 

Diese Seite listet alle [added](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) oder [removed](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) Klassen, Methoden, Eigenschaften und so weiter sowie weitere Änderungen, die mit der Aspose.Slides für .NET 14.9.0 API eingeführt wurden.

{{% /alert %}} 
## **Öffentliche API-Änderungen**
#### **Vererbung von ICollection- und generischen IEnumerable-Schnittstellen zu ISmartArtNodeCollection hinzugefügt**
Die Klasse Aspose.Slides.SmartArt.SmartArtNodeCollection (und das zugehörige Interface Aspose.Slides.SmartArt.ISmartArtNodeCollection) erben das generische Interface IEnumerable<ISmartArtNode> und das Interface ICollection.
#### **SmartArtLayoutType.Custom-Enum-Wert hinzugefügt**
Der benutzerdefinierte SmartArt-Layouttyp stellt ein Diagramm mit einer benutzerdefinierten Vorlage dar. Benutzerdefinierte Diagramme können nur aus einer Präsentationsdatei geladen werden und können nicht über die Methode ShapeCollection.AddSmartArt(x, y, width, height, SmartArtLayoutType.Custom) erstellt werden.
#### **SmartArtShape-Klasse und ISmartArtShape-Interface hinzugefügt**
Die Klasse Aspose.Slides.SmartArt.SmartArtShape (und ihr Interface Aspose.Slides.SmartArt.ISmartArtShape) ermöglicht den Zugriff auf einzelne Formen in einem SmartArt-Diagramm. SmartArtShape kann verwendet werden, um FillFormat, LineFormat zu ändern, Hyperlinks hinzuzufügen und weitere Aufgaben auszuführen.

{{% alert color="primary" %}} 

**Hinweis**: SmartArtShape unterstützt die IShape-Eigenschaften RawFrame, Frame, Rotation, X, Y, Width, Height nicht und wirft eine System.NotSupportedException, wenn versucht wird, auf sie zuzugreifen.

Beispiel zur Verwendung:

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
#### **SmartArtShapeCollection-Klasse, ISmartArtShapeCollection-Interface und ISmartArtNode.Shapes-Eigenschaft hinzugefügt**
Die Klasse Aspose.Slides.SmartArt.SmartArtShapeCollection (und ihr Interface Aspose.Slides.SmartArt.ISmartArtShapeCollection) ermöglichen den Zugriff auf einzelne Formen in einem SmartArt-Diagramm. Die Sammlung enthält Formen, die einem SmartArtNode zugeordnet sind. Die Eigenschaft SmartArtNode.Shapes gibt Sammlungen aller dem Knoten zugeordneten Formen zurück.

{{% alert color="primary" %}} 

**Hinweis**: Abhängig vom SmartArtLayoutType kann eine SmartArtShape zwischen mehreren Knoten geteilt werden.

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
#### **Methoden zum Speichern von Folien mit Seitenzahlenbeibehaltung hinzugefügt**
Die folgenden Methoden wurden hinzugefügt:

- void IPresentation.Save(string fname, int[] slides, SaveFormat format);
- void IPresentation.Save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Diese Methoden ermöglichen es Entwicklern, bestimmte Präsentationsfolien in PDF-, XPS-, TIFF- und HTML-Formaten zu speichern. Das Array 'slides' wird verwendet, um Seitennummern anzugeben, beginnend bei 1.
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