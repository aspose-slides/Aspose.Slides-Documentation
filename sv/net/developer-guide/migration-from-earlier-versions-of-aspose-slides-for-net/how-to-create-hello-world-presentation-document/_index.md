---
title: Så skapar du Hello World-presentationer i .NET
linktitle: Hello World-presentation
type: docs
weight: 10
url: /sv/net/how-to-create-hello-world-presentation-document/
keywords:
- migrering
- hello world
- äldre kod
- modern kod
- äldre metod
- modern metod
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Skapa en Hello World PowerPoint PPT, PPTX och ODP-presentation i .NET med Aspose.Slides med både äldre och moderna API:er i en enkel guide."
---
{{% alert color="info" %}}

En ny [Aspose.Slides for .NET API](/slides/sv/net/) har släppts och nu stödjer denna enda produkt möjligheten att generera PowerPoint-dokument från grunden och redigera befintliga.

{{% /alert %}}
## **Stöd för äldre kod**
För att kunna använda den äldre koden som utvecklats med Aspose.Slides for .NET versioner tidigare än 13.x måste du göra några mindre ändringar i din kod så att den fungerar som tidigare. Alla klasser som fanns i den gamla Aspose.Slides for .NET under namnutrymmena Aspose.Slide och Aspose.Slides.Pptx har nu slagits ihop i ett enda namnutrymme Aspose.Slides. Titta på följande enkla kodexempel för att skapa ett Hello World Presentation-dokument i det äldre Aspose.Slides API och följ stegen som beskriver hur du migrerar till det nya sammanslagna API.

## **Legacy Aspose.Slides for .NET metod**
```c#
using System.Drawing;
using Aspose.Slides;

//Skapa ett Presentation-objekt som representerar en PPT-fil
//Skapa ett License-objekt
//Ange licensen för Aspose.Slides for .NET för att undvika utvärderingsbegränsningarna
//Lägger till en tom bild i presentationen och får referensen till
//denna tomma bild
//Lägger till en rektangel (X=2400, Y=1800, Bredd=1000 & Höjd=500) på bilden
//Döljer rektangelns linjer
//Lägger till en textram i rektangeln med "Hello World" som standardtext
//Tar bort den första bilden i presentationen som alltid läggs till av
//Aspose.Slides for .NET som standard vid skapande av presentationen
//Skriver presentationen som en PPT-fil
Presentation pres = new Presentation();

//Create a License object
License license = new License();

//Set the license of Aspose.Slides for .NET to avoid the evaluation limitations
license.SetLicense("Aspose.Slides.lic");

//Adding an empty slide to the presentation and getting the reference of
//that empty slide
Slide slide = pres.AddEmptySlide();

//Adding a rectangle (X=2400, Y=1800, Width=1000 & Height=500) to the slide
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//Hiding the lines of rectangle
rect.LineFormat.ShowLines = false;

//Adding a text frame to the rectangle with "Hello World" as a default text
rect.AddTextFrame("Hello World");

//Removing the first slide of the presentation which is always added by
//Aspose.Slides for .NET by default while creating the presentation
pres.Slides.RemoveAt(0);

//Writing the presentation as a PPT file
pres.Write("C:\\hello.ppt");
```

## **Ny Aspose.Slides for .NET 13.x metod**
```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instansiera Presentation
Presentation pres = new Presentation();

// Hämta den första bilden
ISlide sld = (ISlide)pres.Slides[0];

// Lägg till en AutoShape av rektangeltyp
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
pres.Save("HelloWorld.pptx", SaveFormat.Pptx);
```