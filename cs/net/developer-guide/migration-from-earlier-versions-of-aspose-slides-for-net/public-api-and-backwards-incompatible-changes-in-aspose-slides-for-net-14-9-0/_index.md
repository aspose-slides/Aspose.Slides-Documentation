---
title: Veřejné API a nekompatibilní změny v Aspose.Slides pro .NET 14.9.0
linktitle: Aspose.Slides pro .NET 14.9.0
type: docs
weight: 110
url: /cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/
keywords:
- migrace
- starý kód
- moderní kód
- zastaralý přístup
- moderní přístup
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Prozkoumejte aktualizace veřejného API a zásadní změny v Aspose.Slides pro .NET, abyste hladce migrovali své řešení prezentací PowerPoint PPT, PPTX a ODP."
---
{{% alert color="info" %}} 

Tato stránka uvádí všechny [přidaných](/slides/cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) nebo [odebraných](/slides/cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) tříd, metod, vlastností a podobně a další změny zavedené v API Aspose.Slides pro .NET 14.9.0.

{{% /alert %}} 
## **Změny veřejného API**
#### **Do ISmartArtNodeCollection přidáno dědění z rozhraní ICollection a obecného IEnumerable**
Třída Aspose.Slides.SmartArt.SmartArtNodeCollection (a související rozhraní Aspose.Slides.SmartArt.ISmartArtNodeCollection) dědí obecné rozhraní IEnumerable<ISmartArtNode> a rozhraní ICollection.
#### **Přidána hodnota výčtu SmartArtLayoutType.Custom**
Typ rozvržení Custom SmartArt představuje diagram s vlastním šablonou. Vlastní diagramy lze načíst pouze z prezentačního souboru a nelze je vytvořit pomocí metody ShapeCollection.AddSmartArt(x, y, width, height, SmartArtLayoutType.Custom).
#### **Přidána třída SmartArtShape a rozhraní ISmartArtShape**
Třída Aspose.Slides.SmartArt.SmartArtShape (a její rozhraní Aspose.Slides.SmartArt.ISmartArtShape) poskytuje přístup k jednotlivým tvarům v diagramu SmartArt. SmartArtShape lze použít k změně FillFormat, LineFormat, přidávání Hyperlinků a dalším úkolům.

{{% alert color="info" %}} 

**Poznámka**: SmartArtShape nepodporuje vlastnosti IShape RawFrame, Frame, Rotation, X, Y, Width, Height a při pokusu o jejich přístup vyvolá System.NotSupportedException.

Příklad použití:

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
#### **Přidána třída SmartArtShapeCollection, rozhraní ISmartArtShapeCollection a vlastnost ISmartArtNode.Shapes**
Třída Aspose.Slides.SmartArt.SmartArtShapeCollection (a její rozhraní Aspose.Slides.SmartArt.ISmartArtShapeCollection) poskytuje přístup k jednotlivým tvarům v diagramu SmartArt. Kolekce obsahuje tvary přiřazené k SmartArtNode. Vlastnost SmartArtNode.Shapes vrací kolekce všech tvarů přiřazených k uzlu.

{{% alert color="info" %}} 

**Poznámka**: v závislosti na SmartArtLayoutType může být jeden SmartArtShape sdílen mezi několika uzly.

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
#### **Přidány metody pro ukládání snímků se zachováním čísel stránek**
Byly přidány následující metody:

- void IPresentation.Save(string fname, int[] slides, SaveFormat format);
- void IPresentation.Save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Tyto metody umožňují vývojářům uložit vybrané snímky prezentace do formátů PDF, XPS, TIFF, HTML. Pole „slides“ se používá k určení čísel stránek, počínaje od 1.
Save(string fname, int[] slides, SaveFormat format);

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("presentation.pptx"))
{
    int[] slides = new int[] { 2, 3, 5 }; //Pole pozic snímků

    presentation.Save("output.pdf", slides, SaveFormat.Pdf);
}
``` 
#### **Přidány metody pro nahrazování obrázků pro PPImage, IPPImage**
Nové metody:

- IPPImage.ReplaceImage(byte[] newImageData)
- IPPImage.ReplaceImage(Image newImage)
- IPPImage.ReplaceImage(IPPImage newImage)

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("presentation.pptx"))
{
    //První metoda

    byte[] data = File.ReadAllBytes("image0.jpeg");

    IPPImage oldImage = presentation.Images[0];

    oldImage.ReplaceImage(data);

    //Druhá metoda

    IImage newImage = Images.FromFile("image1.png");

    oldImage = presentation.Images[1];

    oldImage.ReplaceImage(newImage);

    //Třetí metoda

    oldImage = presentation.Images[2];

    oldImage.ReplaceImage(presentation.Images[3]);

    presentation.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```