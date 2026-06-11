---
title: "Hur man skapar Hello World-presentationer i .NET"
linktitle: "Hello World-presentation"
type: docs
weight: 10
url: /sv/net/how-to-create-hello-world-presentation-document/
keywords:
- migrering
- hej världen
- gammal kod
- modern kod
- gammal metod
- modern metod
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Skapa en Hello World PowerPoint PPT-, PPTX- och ODP-presentation i .NET med Aspose.Slides med både den äldre och den moderna API:n i en enkel guide."
---
{{% alert color="primary" %}}

En ny [Aspose.Slides for .NET API](/slides/sv/net/) har släppts och nu stödjer denna enda produkt möjligheten att generera PowerPoint-dokument från grunden samt redigera befintliga.

{{% /alert %}}
## **Stöd för gammal kod**
För att kunna använda den äldre kod som utvecklats med Aspose.Slides för .NET versioner före 13.x måste du göra några mindre ändringar i din kod så att den fungerar som tidigare. Alla klasser som fanns i den gamla Aspose.Slides för .NET under namnrymderna Aspose.Slide och Aspose.Slides.Pptx har nu slagits ihop i en enda Aspose.Slides namnrymd. Titta på följande enkla kodsnutt för att skapa ett Hello World presentationsdokument i den äldre Aspose.Slides API:n och följ stegen som beskriver hur du migrerar till den nya sammanslagna API:n.
## **Legacy Aspose.Slides for .NET Approach**
```c#
//Instansiera ett Presentation-objekt som representerar en PPT-fil
Presentation pres = new Presentation();

//Skapa ett Licens-objekt
License license = new License();

//Ange licensen för Aspose.Slides for .NET för att undvika utvärderingsbegränsningar
license.SetLicense("Aspose.Slides.lic");

//Lägger till en tom bild i presentationen och får referensen till
//den tomma bilden
Slide slide = pres.AddEmptySlide();

//Lägger till en rektangel (X=2400, Y=1800, Bredd=1000 & Höjd=500) på bilden
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//Döljer rektangelns linjer
rect.LineFormat.ShowLines = false;

//Lägger till en textruta i rektangeln med "Hello World" som standardtext
rect.AddTextFrame("Hello World");

//Tar bort den första bilden i presentationen som alltid läggs till av
//Aspose.Slides for .NET som standard vid skapandet av presentationen
pres.Slides.RemoveAt(0);

//Skriver presentationen som en PPT-fil
pres.Write("C:\\hello.ppt");
```



## **New Aspose.Slides for .NET 13.x Approach**
```c#
// Instansiera Presentation
Presentation pres = new Presentation();

// Hämta den första bilden
ISlide sld = (ISlide)pres.Slides[0];

// Lägg till en AutoShape av rektangulär typ
IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

// Lägg till ITextFrame i rektangeln
ashp.AddTextFrame("Hello World");

// Ändra textfärgen till svart (som är vit som standard)
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Ändra linjefärgen på rektangeln till vit
ashp.ShapeStyle.LineColor.Color = Color.White;

// Ta bort eventuell fyllningsformatering i formen
ashp.FillFormat.FillType = FillType.NoFill;

// Spara presentationen till disk
pres.Save("D:\\data\\HelloWorld.pptx", SaveFormat.Pptx);
```