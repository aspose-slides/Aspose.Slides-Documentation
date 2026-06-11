---
title: Publiczne API oraz zmiany niezgodne wstecz w Aspose.Slides dla .NET 14.9.0
linktitle: Aspose.Slides dla .NET 14.9.0
type: docs
weight: 110
url: /pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/
keywords:
- migracja
- kod przestarzały
- nowoczesny kod
- przestarzałe podejście
- nowoczesne podejście
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Przeglądaj aktualizacje publicznego API oraz zmiany niekompatybilne w Aspose.Slides dla .NET, aby płynnie migrować rozwiązania prezentacji PowerPoint PPT, PPTX i ODP."
---
{{% alert color="primary" %}} 

Ta strona wymienia wszystkie [dodane](/slides/pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) lub [usunięte](/slides/pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) klasy, metody, właściwości itp., a także inne zmiany wprowadzone w API Aspose.Slides dla .NET 14.9.0.

{{% /alert %}} 
## **Public API Changes**
#### **Inheritance from ICollection and Generic IEnumerable Interfaces Added to ISmartArtNodeCollection**
Klasa Aspose.Slides.SmartArt.SmartArtNodeCollection (oraz powiązany interfejs Aspose.Slides.SmartArt.ISmartArtNodeCollection) dziedziczy po generycznym interfejsie IEnumerable<ISmartArtNode> oraz interfejsie ICollection.
#### **SmartArtLayoutType.Custom Enum Value Added**
Wartość wyliczeniowa SmartArtLayoutType.Custom reprezentuje diagram z niestandardowym szablonem. Niestandardowe diagramy mogą być ładowane wyłącznie z pliku prezentacji i nie mogą być tworzone za pomocą metody ShapeCollection.AddSmartArt(x, y, width, height, SmartArtLayoutType.Custom).
#### **SmartArtShape Class and ISmartArtShape Interface Added**
Klasa Aspose.Slides.SmartArt.SmartArtShape (oraz jej interfejs Aspose.Slides.SmartArt.ISmartArtShape) zapewnia dostęp do poszczególnych kształtów w diagramie SmartArt. SmartArtShape może być używana do zmiany FillFormat, LineFormat, dodawania hiperłączy i innych zadań.

{{% alert color="primary" %}} 

**Uwaga**: SmartArtShape nie obsługuje właściwości IShape: RawFrame, Frame, Rotation, X, Y, Width, Height i zgłasza System.NotSupportedException przy próbie ich użycia.

Przykład użycia:

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
#### **SmartArtShapeCollection Class, ISmartArtShapeCollection Interface and ISmartArtNode.Shapes Property Added**
Klasa Aspose.Slides.SmartArt.SmartArtShapeCollection (oraz jej interfejs Aspose.Slides.SmartArt.ISmartArtShapeCollection) zapewnia dostęp do poszczególnych kształtów w diagramie SmartArt. Kolekcja zawiera kształty powiązane z SmartArtNode. Właściwość SmartArtNode.Shapes zwraca kolekcje wszystkich kształtów powiązanych z węzłem.

{{% alert color="primary" %}} 

**Uwaga**: w zależności od SmartArtLayoutType jeden SmartArtShape może być współdzielony przez kilka węzłów.

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
#### **Methods for Saving Slides with Page Numbers Keeping Added**
Dodano następujące metody:

- void IPresentation.Save(string fname, int[] slides, SaveFormat format);
- void IPresentation.Save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Metody te umożliwiają programistom zapisanie wybranych slajdów prezentacji w formatach PDF, XPS, TIFF, HTML. Tablica 'slides' służy do określenia numerów stron, zaczynając od 1.
Save(string fname, int[] slides, SaveFormat format);

``` csharp

 Presentation presentation = new Presentation(presentationFileName);
int[] slides = new int[] { 2, 3, 5 }; //Tablica pozycji slajdów

presentation.Save(outFileName, slides, SaveFormat.Pdf);

``` 
#### **Methods for Replacing Images Added to PPImage, IPPImage**
Dodano nowe metody:

- IPPImage.ReplaceImage(byte[] newImageData)
- IPPImage.ReplaceImage(Image newImage)
- IPPImage.ReplaceImage(IPPImage newImage)

``` csharp

 Presentation presentation = new Presentation(presentation.pptx);
//Pierwsza metoda

byte[] data = File.ReadAllBytes(image0.jpeg);

IPPImage oldImage = presentation.Images[0];

oldImage.ReplaceImage(data);
//Druga metoda

Image newImage = Image.FromFile(image1.png);

oldImage = presentation.Images[1];

oldImage.ReplaceImage(newImage);
//Trzecia metoda

oldImage = presentation.Images[2];

oldImage.ReplaceImage(presentation.Images[3]);

presentation.Save(presentation_out.pptx, SaveFormat.Pptx);

```