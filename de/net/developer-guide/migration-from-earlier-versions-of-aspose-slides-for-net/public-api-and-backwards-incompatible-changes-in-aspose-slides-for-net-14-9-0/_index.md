---
title: Öffentliches API und nicht rückwärtskompatible Änderungen in Aspose.Slides für .NET 14.9.0
type: docs
weight: 110
url: /de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügten](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) oder [entfernten](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) Klassen, Methoden, Eigenschaften und so weiter auf und andere Änderungen, die mit der Aspose.Slides für .NET 14.9.0 API eingeführt wurden.

{{% /alert %}} 
## **Änderungen der öffentlichen API**
#### **Vererbung von ICollection und generischen IEnumerable-Schnittstellen zu ISmartArtNodeCollection hinzugefügt**
Die Klasse Aspose.Slides.SmartArt.SmartArtNodeCollection (und die zugehörige Schnittstelle Aspose.Slides.SmartArt.ISmartArtNodeCollection) erbt die generische Schnittstelle IEnumerable<ISmartArtNode> und die Schnittstelle ICollection.
#### **Enum-Wert SmartArtLayoutType.Custom hinzugefügt**
Der benutzerdefinierte SmartArt-Layouttyp stellt ein Diagramm mit einer benutzerdefinierten Vorlage dar. Benutzerdefinierte Diagramme können nur aus einer Präsentationsdatei geladen werden und können nicht über die Methode ShapeCollection.AddSmartArt(x, y, width, height, SmartArtLayoutType.Custom) erstellt werden.
#### **SmartArtShape-Klasse und ISmartArtShape-Schnittstelle hinzugefügt**
Die Aspose.Slides.SmartArt.SmartArtShape-Klasse (und ihre Schnittstelle Aspose.Slides.SmartArt.ISmartArtShape) geben Zugriff auf einzelne Formen in einem SmartArt-Diagramm. SmartArtShape kann verwendet werden, um FillFormat, LineFormat zu ändern, Hyperlinks hinzuzufügen und andere Aufgaben auszuführen.

{{% alert color="primary" %}} 

**Hinweis**: SmartArtShape unterstützt die IShape-Eigenschaften RawFrame, Frame, Rotation, X, Y, Width, Height nicht und löst eine System.NotSupportedException aus, wenn versucht wird, auf sie zuzugreifen.

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
#### **SmartArtShapeCollection-Klasse, ISmartArtShapeCollection-Schnittstelle und ISmartArtNode.Shapes-Eigenschaft hinzugefügt**
Die Aspose.Slides.SmartArt.SmartArtShapeCollection-Klasse (und ihre Schnittstelle Aspose.Slides.SmartArt.ISmartArtShapeCollection) ermöglichen den Zugriff auf einzelne Formen in einem SmartArt-Diagramm. Die Sammlung enthält Formen, die mit SmartArtNode assoziiert sind. Die SmartArtNode.Shapes-Eigenschaft gibt Sammlungen aller Formen zurück, die mit dem Knoten verknüpft sind.

{{% alert color="primary" %}} 

**Hinweis**: Je nach SmartArtLayoutType kann eine SmartArtShape zwischen mehreren Knoten geteilt werden.

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
#### **Methoden zum Speichern von Folien mit Seitenzahlen hinzugefügt**
Die folgenden Methoden wurden hinzugefügt:

- void IPresentation.Save(string fname, int[] slides, SaveFormat format);
- void IPresentation.Save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Diese Methoden ermöglichen es Entwicklern, angegebene Präsentationsfolien in PDF-, XPS-, TIFF- und HTML-Formate zu speichern. Das 'slides'-Array wird verwendet, um die Seitennummern anzugeben, beginnend mit 1.
Save(string fname, int[] slides, SaveFormat format);

``` csharp

 Presentation presentation = new Presentation(presentationFileName);

int[] slides = new int[] { 2, 3, 5 }; //Array der Folienpositionen

presentation.Save(outFileName, slides, SaveFormat.Pdf);

``` 
#### **Methoden zum Ersetzen von Bildern zu PPImage, IPPImage hinzugefügt**
Neue Methoden wurden hinzugefügt:

- IPPImage.ReplaceImage(byte[] newImageData)
- IPPImage.ReplaceImage(Image newImage)
- IPPImage.ReplaceImage(IPPImage newImage)

``` csharp

 Presentation presentation = new Presentation(presentation.pptx);

//Erste Methode

byte[] data = File.ReadAllBytes(image0.jpeg);

IPPImage oldImage = presentation.Images[0];

oldImage.ReplaceImage(data);

//Zweite Methode

Image newImage = Image.FromFile(image1.png);

oldImage = presentation.Images[1];

oldImage.ReplaceImage(newImage);

//Dritte Methode

oldImage = presentation.Images[2];

oldImage.ReplaceImage(presentation.Images[3]);

presentation.Save(presentation_out.pptx, SaveFormat.Pptx);

``` 