---
title: Nyilvános API és visszafelé nem kompatibilis változások az Aspose.Slides for .NET 14.9.0-ban
linktitle: Aspose.Slides for .NET 14.9.0
type: docs
weight: 110
url: /hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/
keywords:
- migráció
- örökölt kód
- modern kód
- örökölt megközelítés
- modern megközelítés
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Tekintse át a nyilvános API frissítéseket és a törő változásokat az Aspose.Slides for .NET-ben, hogy zökkenőmentesen migrálhassa PowerPoint PPT, PPTX és ODP prezentációs megoldásait."
---
{{% alert color="info" %}} 

Ez az oldal felsorolja az összes [hozzáadva](/slides/hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) vagy [eltávolítva](/slides/hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) osztályt, metódust, tulajdonságot stb., és a Aspose.Slides for .NET 14.9.0 API-val bevezetett egyéb változásokat.

{{% /alert %}} 
## **Nyilvános API változások**
#### **Az ICollection és a generikus IEnumerable interfészek öröklése hozzáadva az ISmartArtNodeCollection-hez**
Az Aspose.Slides.SmartArt.SmartArtNodeCollection osztály (és a hozzá tartozó Aspose.Slides.SmartArt.ISmartArtNodeCollection interfész) örökli a generikus IEnumerable<ISmartArtNode> interfészt és az ICollection interfészt.
#### **SmartArtLayoutType.Custom enumerációs érték hozzáadva**
Az egyedi SmartArt elrendezéstípus egy saját sablonnal rendelkező diagramot képvisel. Az egyedi diagramok csak prezentációfájlból tölthetők be, és nem hozhatók létre a ShapeCollection.AddSmartArt(x, y, width, height, SmartArtLayoutType.Custom) metódussal.
#### **SmartArtShape osztály és ISmartArtShape interfész hozzáadva**
Az Aspose.Slides.SmartArt.SmartArtShape osztály (és annak Aspose.Slides.SmartArt.ISmartArtShape interfésze) hozzáférést biztosít az egyes alakzatokhoz egy SmartArt diagramban. A SmartArtShape használható a FillFormat, a LineFormat módosítására, hiperhivatkozások hozzáadására és egyéb feladatokra.

{{% alert color="info" %}} 

**Megjegyzés**: A SmartArtShape nem támogatja az IShape tulajdonságokat RawFrame, Frame, Rotation, X, Y, Width, Height, és System.NotSupportedException kivételt dob, ha megpróbálják elérni őket.

Használati példa:

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
#### **SmartArtShapeCollection osztály, ISmartArtShapeCollection interfész és az ISmartArtNode.Shapes tulajdonság hozzáadva**
Az Aspose.Slides.SmartArt.SmartArtShapeCollection osztály (és annak Aspose.Slides.SmartArt.ISmartArtShapeCollection interfésze) hozzáférést biztosít az egyes alakzatokhoz egy SmartArt diagramban. A gyűjtemény a SmartArtNode-hoz kapcsolódó alakzatokat tartalmazza. Az ISmartArtNode.Shapes tulajdonság visszaadja az adott csomóponthoz tartozó összes alakzat gyűjteményét.

{{% alert color="info" %}} 

**Megjegyzés**: a SmartArtLayoutType-tól függően egy SmartArtShape több csomópont között is megosztható.

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
#### **Diák mentéséhez oldalszámok megőrzésével kapcsolatos módszerek hozzáadva**
A következő módszerek kerültek hozzáadásra:

- void IPresentation.Save(string fname, int[] slides, SaveFormat format);
- void IPresentation.Save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Ezek a módszerek lehetővé teszik a fejlesztők számára, hogy a megadott prezentációs diáket PDF, XPS, TIFF, HTML formátumokba mentsék. A 'slides' tömb az oldalszámok megadására szolgál, 1-től kezdődően.
Save(string fname, int[] slides, SaveFormat format);

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("presentation.pptx"))
{
    int[] slides = new int[] { 2, 3, 5 }; //Diák pozícióinak tömbje

    presentation.Save("output.pdf", slides, SaveFormat.Pdf);
}
``` 
#### **Képek cseréjéhez hozzáadott módszerek a PPImage, IPPImage esetén**
Új módszerek hozzáadva:

- IPPImage.ReplaceImage(byte[] newImageData)
- IPPImage.ReplaceImage(Image newImage)
- IPPImage.ReplaceImage(IPPImage newImage)

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("presentation.pptx"))
{
    //Első módszer

    byte[] data = File.ReadAllBytes("image0.jpeg");

    IPPImage oldImage = presentation.Images[0];

    oldImage.ReplaceImage(data);

    //Második módszer

    IImage newImage = Images.FromFile("image1.png");

    oldImage = presentation.Images[1];

    oldImage.ReplaceImage(newImage);

    //Harmadik módszer

    oldImage = presentation.Images[2];

    oldImage.ReplaceImage(presentation.Images[3]);

    presentation.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```