---
title: Jak vytvořit prezentace Hello World v .NET
linktitle: Prezentace Hello World
type: docs
weight: 10
url: /cs/net/how-to-create-hello-world-presentation-document/
keywords:
- migrace
- hello world
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
description: "Vytvořte prezentaci PowerPoint PPT, PPTX a ODP Hello World v .NET s využitím Aspose.Slides pomocí jak starých, tak moderních API v jednoduchém průvodci."
---
{{% alert color="info" %}} 

Bylo vydáno nové [Aspose.Slides for .NET API](/slides/cs/net/) a nyní tento jedinečný produkt podporuje možnost generovat PowerPoint dokumenty od nuly i upravovat existující.

{{% /alert %}} 
## **Podpora starého kódu**
Aby bylo možné použít starý kód vyvinutý pro Aspose.Slides pro .NET ve verzích starších než 13.x, je třeba provést drobné úpravy v kódu a kód bude fungovat jako dříve. Všechny třídy, které byly v minulých verzích Aspose.Slides pro .NET v jmenných prostorech Aspose.Slide a Aspose.Slides.Pptx, jsou nyní sloučeny do jediného jmenného prostoru Aspose.Slides. Podívejte se na následující jednoduchý úryvek kódu pro vytvoření prezentace Hello World v legacy API Aspose.Slides a následujte kroky popisující, jak migrovat na nové sloučené API.
## **Legacy Aspose.Slides pro .NET přístup**
```c#
using System.Drawing;
using Aspose.Slides;

//Vytvořte objekt Presentation, který představuje soubor PPT
Presentation pres = new Presentation();

//Vytvořte objekt License
License license = new License();

//Nastavte licenci Aspose.Slides pro .NET, aby se předešlo omezením vyhodnocení
license.SetLicense("Aspose.Slides.lic");

//Přidání prázdného slidu do prezentace a získání reference na
//tento prázdný slid
Slide slide = pres.AddEmptySlide();

//Přidání obdélníku (X=2400, Y=1800, Šířka=1000 & Výška=500) do slidu
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//Skrytí čar obdélníku
rect.LineFormat.ShowLines = false;

//Přidání textového rámce do obdélníku s "Hello World" jako výchozím textem
rect.AddTextFrame("Hello World");

//Odstranění prvního slidu prezentace, který je vždy přidán
//Aspose.Slides pro .NET ve výchozím nastavení při vytváření prezentace
pres.Slides.RemoveAt(0);

//Zapsání prezentace jako soubor PPT
pres.Write("C:\\hello.ppt");
```

## **Nový Aspose.Slides pro .NET 13.x přístup**
```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instantiate Presentation
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