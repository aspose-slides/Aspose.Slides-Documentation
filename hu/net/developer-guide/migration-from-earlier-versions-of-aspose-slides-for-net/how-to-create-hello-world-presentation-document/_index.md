---
title: Hogyan készítsünk Hello World prezentációkat .NET-ben
linktitle: Hello World prezentáció
type: docs
weight: 10
url: /hu/net/how-to-create-hello-world-presentation-document/
keywords:
- migráció
- helló világ
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
description: "Készítsen egy Hello World PowerPoint PPT, PPTX és ODP prezentációt .NET-ben az Aspose.Slides segítségével, a régi és az új API-k használatával egy egyszerű útmutatóban."
---
{{% alert color="info" %}} 

Egy új [Aspose.Slides for .NET API](/slides/hu/net/) jelent meg, és most ez a termék képes PowerPoint dokumentumok létrehozására a semmiből, valamint a meglévők szerkesztésére.

{{% /alert %}} 
## **Legacy kód támogatása**
Az Aspose.Slides for .NET 13.x előtti verziókkal fejlesztett legacy kód használatához néhány kisebb módosításra van szükség a kódban, és a kód ugyanúgy fog működni, mint korábban. Az összes régi Aspose.Slides for .NET alatt, az Aspose.Slide és Aspose.Slides.Pptx névterekben lévő osztály most egyetlen Aspose.Slides névtérbe van egyesítve. Tekintse meg az alábbi egyszerű kódrészletet, amely egy Hello World prezentációs dokumentumot hoz létre a legacy Aspose.Slides API-val, és kövesse a lépéseket, amelyek leírják, hogyan lehet átmenni az új egyesített API-ra.
## **Legacy Aspose.Slides for .NET megközelítés**
```c#
using System.Drawing;
using Aspose.Slides;

//Példányosítsunk egy Presentation objektumot, amely egy PPT fájlt képvisel
Presentation pres = new Presentation();

//Hozzunk létre egy License objektumot
License license = new License();

//Állítsuk be az Aspose.Slides for .NET licencét az értékelési korlátozások elkerüléséhez
license.SetLicense("Aspose.Slides.lic");

//Üres diát adunk a prezentációhoz, és lekérjük a hivatkozását
//az üres diát
Slide slide = pres.AddEmptySlide();

//Téglalap hozzáadása (X=2400, Y=1800, Szélesség=1000 & Magasság=500) a diára
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//A téglalap vonalainak elrejtése
rect.LineFormat.ShowLines = false;

//"Hello World" alapértelmezett szöveggel szövegkeret hozzáadása a téglalaphoz
rect.AddTextFrame("Hello World");

//Az első diát eltávolítjuk a prezentációból, amelyet mindig hozzáad a
//az Aspose.Slides for .NET alapértelmezés szerint a prezentáció létrehozásakor
pres.Slides.RemoveAt(0);

//A prezentáció mentése PPT fájlként
pres.Write("C:\\hello.ppt");
```



## **Új Aspose.Slides for .NET 13.x megközelítés**
```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Példányosítsuk a prezentációt
Presentation pres = new Presentation();

// Get the first slide
ISlide sld = (ISlide)pres.Slides[0];

// Add an AutoShape of Rectangle type
IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

// Add ITextFrame to the Rectangle
ashp.AddTextFrame("Hello World");

// Change the text color to Black (which is White by default)
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Change the line color of the rectangle to White
ashp.ShapeStyle.LineColor.Color = Color.White;

// Remove any fill formatting in the shape
ashp.FillFormat.FillType = FillType.NoFill;

// Save the presentation to disk
pres.Save("HelloWorld.pptx", SaveFormat.Pptx);
```