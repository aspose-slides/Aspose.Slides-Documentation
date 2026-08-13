---
title: Publiczne API i zmiany niekompatybilne wstecz w Aspose.Slides dla .NET 14.9.0
linktitle: Aspose.Slides dla .NET 14.9.0
type: docs
weight: 110
url: /pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/
keywords:
- migracja
- kod legacy
- nowoczesny kod
- podejście legacy
- nowoczesne podejście
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Przeglądaj aktualizacje publicznego API i zmiany niekompatybilne w Aspose.Slides dla .NET, aby płynnie migrować rozwiązania prezentacji PowerPoint (PPT, PPTX) oraz ODP."
---
{{% alert color="info" %}} 

Ta strona wymienia wszystkie [dodane](/slides/pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) lub [usunięte](/slides/pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) klasy, metody, właściwości i tak dalej, oraz inne zmiany wprowadzone w API Aspose.Slides for .NET 14.9.0.

{{% /alert %}} 
## **Zmiany w publicznym API**
#### **Dziedziczenie po interfejsach ICollection i Generic IEnumerable dodane do ISmartArtNodeCollection**
Klasa Aspose.Slides.SmartArt.SmartArtNodeCollection (oraz powiązany interfejs Aspose.Slides.SmartArt.ISmartArtNodeCollection) dziedziczy generyczny interfejs IEnumerable<ISmartArtNode> oraz interfejs ICollection.
#### **Dodano wartość wyliczeniową SmartArtLayoutType.Custom**
Typ układu Custom SmartArt reprezentuje diagram z niestandardowym szablonem. Niestandardowe diagramy można załadować jedynie z pliku prezentacji i nie można ich utworzyć za pomocą metody ShapeCollection.AddSmartArt(x, y, width, height, SmartArtLayoutType.Custom).
#### **Dodano klasę SmartArtShape i interfejs ISmartArtShape**
Klasa Aspose.Slides.SmartArt.SmartArtShape (oraz jej interfejs Aspose.Slides.SmartArt.ISmartArtShape) zapewnia dostęp do pojedynczych kształtów w diagramie SmartArt. SmartArtShape może być używany do zmiany FillFormat, LineFormat, dodawania hiperłączy i innych zadań.

{{% alert color="info" %}} 

**Uwaga**: SmartArtShape nie obsługuje właściwości IShape: RawFrame, Frame, Rotation, X, Y, Width, Height i zgłasza System.NotSupportedException podczas próby ich użycia.

Przykład użycia:

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
#### **Dodano klasę SmartArtShapeCollection, interfejs ISmartArtShapeCollection i własność ISmartArtNode.Shapes**
Klasa Aspose.Slides.SmartArt.SmartArtShapeCollection (oraz jej interfejs Aspose.Slides.SmartArt.ISmartArtShapeCollection) umożliwia dostęp do pojedynczych kształtów w diagramie SmartArt. Kolekcja zawiera kształty powiązane ze SmartArtNode. Własność SmartArtNode.Shapes zwraca kolekcje wszystkich kształtów powiązanych z węzłem.

{{% alert color="info" %}} 

**Uwaga**: w zależności od SmartArtLayoutType jeden SmartArtShape może być współdzielony przez kilka węzłów.

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
#### **Dodano metody zapisywania slajdów z zachowaniem numerów stron**
Dodano następujące metody:

- void IPresentation.Save(string fname, int[] slides, SaveFormat format);
- void IPresentation.Save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Metody te umożliwiają programistom zapisanie wybranych slajdów prezentacji w formatach PDF, XPS, TIFF, HTML. Tablica 'slides' służy do określenia numerów stron, zaczynając od 1.
Save(string fname, int[] slides, SaveFormat format);

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("presentation.pptx"))
{
    int[] slides = new int[] { 2, 3, 5 }; //Tablica pozycji slajdów

    presentation.Save("output.pdf", slides, SaveFormat.Pdf);
}
``` 
#### **Dodano metody zastępowania obrazów w PPImage, IPPImage**
Dodano nowe metody:

- IPPImage.ReplaceImage(byte[] newImageData)
- IPPImage.ReplaceImage(Image newImage)
- IPPImage.ReplaceImage(IPPImage newImage)

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("presentation.pptx"))
{
    //Pierwsza metoda

    byte[] data = File.ReadAllBytes("image0.jpeg");

    IPPImage oldImage = presentation.Images[0];

    oldImage.ReplaceImage(data);

    //Druga metoda

    IImage newImage = Images.FromFile("image1.png");

    oldImage = presentation.Images[1];

    oldImage.ReplaceImage(newImage);

    //Trzecia metoda

    oldImage = presentation.Images[2];

    oldImage.ReplaceImage(presentation.Images[3]);

    presentation.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```