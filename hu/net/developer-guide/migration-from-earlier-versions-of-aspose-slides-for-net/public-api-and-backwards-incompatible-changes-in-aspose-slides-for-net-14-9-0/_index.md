---
title: "Nyilvános API és visszafelé nem kompatibilis változások az Aspose.Slides for .NET 14.9.0 verzióban"
linktitle: "Aspose.Slides for .NET 14.9.0"
type: docs
weight: 110
url: /hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/
keywords:
- migráció
- régi kód
- modern kód
- régi megközelítés
- modern megközelítés
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Tekintse át a nyilvános API frissítéseket és a visszafelé nem kompatibilis változásokat az Aspose.Slides for .NET-ben, hogy zökkenőmentesen migrálhassa PowerPoint PPT, PPTX és ODP prezentációs megoldásait."
---
{{% alert color="primary" %}} 

Ez az oldal felsorolja az összes [hozzáadott](/slides/hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) vagy [eltávolított](/slides/hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) osztályt, metódust, tulajdonságot stb., valamint a Aspose.Slides for .NET 14.9.0 API-val bevezetett egyéb változásokat.

{{% /alert %}} 
## **Nyilvános API változások**
#### **Az ISmartArtNodeCollectionhez hozzáadott öröklődés az ICollection és a generikus IEnumerable interfészekből**
Az Aspose.Slides.SmartArt.SmartArtNodeCollection osztály (és a kapcsolódó Aspose.Slides.SmartArt.ISmartArtNodeCollection interfész) örökli a generikus IEnumerable<ISmartArtNode> interfészt és az ICollection interfészt.
#### **SmartArtLayoutType.Custom enum érték hozzáadva**
Az egyedi SmartArt elrendezéstípus egy saját sablonnal rendelkező diagramot jelöl. Az egyedi diagramok csak egy prezentációs fájlból tölthetők be, és nem hozhatók létre a ShapeCollection.AddSmartArt(x, y, width, height, SmartArtLayoutType.Custom) metódussal.
#### **SmartArtShape osztály és ISmartArtShape interfész hozzáadva**
Az Aspose.Slides.SmartArt.SmartArtShape osztály (és az Aspose.Slides.SmartArt.ISmartArtShape interfész) hozzáférést biztosít az egyes alakzatokhoz egy SmartArt diagramon. A SmartArtShape használható a FillFormat, LineFormat módosítására, hiperhivatkozások hozzáadására és egyéb feladatokra.

{{% alert color="primary" %}} 

**Megjegyzés**: A SmartArtShape nem támogatja az IShape tulajdonságokat RawFrame, Frame, Rotation, X, Y, Width, Height, és System.NotSupportedException kivételt dob, ha megpróbálják elérni őket.

Használati példa:

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
#### **SmartArtShapeCollection osztály, ISmartArtShapeCollection interfész és ISmartArtNode.Shapes tulajdonság hozzáadva**
Az Aspose.Slides.SmartArt.SmartArtShapeCollection osztály (és az Aspose.Slides.SmartArt.ISmartArtShapeCollection interfész) hozzáférést biztosít az egyes alakzatokhoz egy SmartArt diagramon. A gyűjtemény tartalmazza a SmartArtNode-hoz kapcsolódó alakzatokat. Az ISmartArtNode.Shapes tulajdonság visszaadja a csomóponthoz tartozó összes alakzat gyűjteményét.

{{% alert color="primary" %}} 

**Megjegyzés**: a SmartArtLayoutType-tól függően egy SmartArtShape több csomópont között is megosztható.

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
#### **Az oldalszámok megtartásával történő diák mentéséhez kapcsolódó metódusok hozzáadva**
A következő metódusok lettek hozzáadva:

- void IPresentation.Save(string fname, int[] slides, SaveFormat format);
- void IPresentation.Save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Ezek a metódusok lehetővé teszik a fejlesztők számára, hogy a megadott prezentációs diát PDF, XPS, TIFF, HTML formátumokba mentse. A `slides` tömb a lapok számait adja meg, 1‑től kezdődően.
Save(string fname, int[] slides, SaveFormat format);

``` csharp

 Presentation presentation = new Presentation(presentationFileName);
int[] slides = new int[] { 2, 3, 5 }; //Diák pozícióinak tömbje
presentation.Save(outFileName, slides, SaveFormat.Pdf);

``` 
#### **Képek cseréjéhez kapcsolódó metódusok hozzáadva a PPImage, IPPImage típusokhoz**
Új metódusok hozzáadva:

- IPPImage.ReplaceImage(byte[] newImageData)
- IPPImage.ReplaceImage(Image newImage)
- IPPImage.ReplaceImage(IPPImage newImage)

``` csharp

 Presentation presentation = new Presentation(presentation.pptx);
//Első módszer

byte[] data = File.ReadAllBytes(image0.jpeg);

IPPImage oldImage = presentation.Images[0];

oldImage.ReplaceImage(data);
//Második módszer

Image newImage = Image.FromFile(image1.png);

oldImage = presentation.Images[1];

oldImage.ReplaceImage(newImage);
//Harmadik módszer

oldImage = presentation.Images[2];

oldImage.ReplaceImage(presentation.Images[3]);

presentation.Save(presentation_out.pptx, SaveFormat.Pptx);

```