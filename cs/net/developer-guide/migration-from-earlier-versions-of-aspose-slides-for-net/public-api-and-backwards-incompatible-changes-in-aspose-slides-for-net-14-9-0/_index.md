---
title: Veřejné API a zpětně nekompatibilní změny v Aspose.Slides pro .NET 14.9.0
linktitle: Aspose.Slides pro .NET 14.9.0
type: docs
weight: 110
url: /cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/
keywords:
- migrace
- starý kód
- moderní kód
- starý přístup
- moderní přístup
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Prohlédněte si aktualizace veřejného API a rozbití změny v Aspose.Slides pro .NET, abyste hladce migrovali svá řešení prezentací PowerPoint PPT, PPTX a ODP."
---
{{% alert color="primary" %}} 

Tato stránka vypisuje všechny [přidané](/slides/cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) nebo [odebrané](/slides/cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) třídy, metody, vlastnosti a podobně a další změny zavedené v API Aspose.Slides pro .NET 14.9.0.

{{% /alert %}} 
## **Změny veřejného API**
#### **Dědičnost z rozhraní ICollection a generického IEnumerable přidána do ISmartArtNodeCollection**
Třída Aspose.Slides.SmartArt.SmartArtNodeCollection (a související rozhraní Aspose.Slides.SmartArt.ISmartArtNodeCollection) dědí generické rozhraní IEnumerable<ISmartArtNode> a rozhraní ICollection.
#### **Přidána hodnota výčtu SmartArtLayoutType.Custom**
Typ rozvržení Custom SmartArt představuje diagram s vlastním šablonou. Vlastní diagramy lze načíst pouze ze souboru prezentace a nelze je vytvořit pomocí metody ShapeCollection.AddSmartArt(x, y, width, height, SmartArtLayoutType.Custom).
#### **Přidána třída SmartArtShape a rozhraní ISmartArtShape**
Třída Aspose.Slides.SmartArt.SmartArtShape (a její rozhraní Aspose.Slides.SmartArt.ISmartArtShape) poskytuje přístup k jednotlivým tvarům v diagramu SmartArt. SmartArtShape lze použít ke změně FillFormat, LineFormat, přidávání hyperodkazů a dalších úloh.

{{% alert color="primary" %}} 

**Poznámka**: SmartArtShape nepodporuje vlastnosti IShape RawFrame, Frame, Rotation, X, Y, Width, Height a při pokusu o jejich přístup vyhodí výjimku System.NotSupportedException.

Příklad použití:

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
#### **Přidána třída SmartArtShapeCollection, rozhraní ISmartArtShapeCollection a vlastnost ISmartArtNode.Shapes**
Třída Aspose.Slides.SmartArt.SmartArtShapeCollection (a její rozhraní Aspose.Slides.SmartArt.ISmartArtShapeCollection) poskytuje přístup k jednotlivým tvarům v diagramu SmartArt. Kolekce obsahuje tvary spojené se SmartArtNode. Vlastnost SmartArtNode.Shapes vrací kolekce všech tvarů spojených s uzlem.

{{% alert color="primary" %}} 

**Poznámka**: v závislosti na SmartArtLayoutType může být jeden SmartArtShape sdílen mezi několika uzly.

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
#### **Přidány metody pro ukládání snímků s zachováním čísel stránek**
Byly přidány následující metody:

- void IPresentation.Save(string fname, int[] slides, SaveFormat format);
- void IPresentation.Save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Tyto metody umožňují vývojářům uložit určené snímky prezentace do formátů PDF, XPS, TIFF, HTML. Pole 'slides' slouží k určení čísel stránek, počínaje 1.
Save(string fname, int[] slides, SaveFormat format);

``` csharp

 Presentation presentation = new Presentation(presentationFileName);
int[] slides = new int[] { 2, 3, 5 }; //Pole pozic snímků

presentation.Save(outFileName, slides, SaveFormat.Pdf);

``` 
#### **Přidány metody pro nahrazování obrázků v PPImage, IPPImage**
Nové metody jsou přidány:

- IPPImage.ReplaceImage(byte[] newImageData)
- IPPImage.ReplaceImage(Image newImage)
- IPPImage.ReplaceImage(IPPImage newImage)

``` csharp

 Presentation presentation = new Presentation(presentation.pptx);
//První metoda
byte[] data = File.ReadAllBytes(image0.jpeg);
IPPImage oldImage = presentation.Images[0];
oldImage.ReplaceImage(data);
//Druhá metoda
Image newImage = Image.FromFile(image1.png);
oldImage = presentation.Images[1];
oldImage.ReplaceImage(newImage);
//Třetí metoda
oldImage = presentation.Images[2];
oldImage.ReplaceImage(presentation.Images[3]);
presentation.Save(presentation_out.pptx, SaveFormat.Pptx);
```