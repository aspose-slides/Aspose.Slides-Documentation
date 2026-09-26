---
title: Jak vytvořit Hello World prezentace v .NET
linktitle: Hello World prezentace
type: docs
weight: 10
url: /cs/net/how-to-create-hello-world-presentation-document/
keywords:
- migrace
- Ahoj světe
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
description: "Vytvořte Hello World PowerPoint PPT, PPTX a ODP prezentaci v .NET s Aspose.Slides pomocí jak starých, tak moderních API v jednom jednoduchém průvodci."
---
{{% alert color="info" %}} 

Bylo vydáno nové [Aspose.Slides for .NET API](/slides/cs/net/) a nyní tento jediný produkt umožňuje vytvářet PowerPoint dokumenty od základu i upravovat existující.

{{% /alert %}} 
## **Podpora starého kódu**
Chcete-li používat starý kód vyvinutý pro Aspose.Slides pro .NET ve verzích před 13.x, musíte provést několik drobných úprav ve svém kódu a kód bude fungovat stejně jako dříve. Všechny třídy, které byly v starých verzích Aspose.Slides pro .NET v prostorách názvů Aspose.Slide a Aspose.Slides.Pptx, jsou nyní sloučeny do jediné oboru názvů Aspose.Slides. Podívejte se na následující jednoduchý úryvek kódu, který vytváří dokument Hello World Presentation v legacy API Aspose.Slides, a postupujte podle kroků popisujících, jak migrovat na nové sloučené API.
## **Legacy Aspose.Slides pro .NET přístup**
```c#
using System.Drawing;
using Aspose.Slides;

//Vytvořte objekt Presentation, který představuje soubor PPT
Presentation pres = new Presentation();

//Vytvořte objekt License
License license = new License();

//Nastavte licenci Aspose.Slides pro .NET, aby se předešlo omezením hodnocení
license.SetLicense("Aspose.Slides.lic");

//Přidání prázdného snímku do prezentace a získání reference na
//tento prázdný snímek
Slide slide = pres.AddEmptySlide();

//Přidání obdélníku (X=2400, Y=1800, Šířka=1000 & Výška=500) na snímek
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//Skrytí čar obdélníku
rect.LineFormat.ShowLines = false;

//Přidání textového rámce do obdélníku s "Hello World" jako výchozím textem
rect.AddTextFrame("Hello World");

//Odstraňování prvního snímku prezentace, který je vždy přidán
//Aspose.Slides pro .NET ve výchozím nastavení při vytváření prezentace
pres.Slides.RemoveAt(0);

//Zapisování prezentace jako soubor PPT
pres.Write("C:\\hello.ppt");
```



## **Nový přístup Aspose.Slides pro .NET 13.x**
```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Vytvořte objekt Presentation
Presentation pres = new Presentation();

// Získejte první snímek
ISlide sld = (ISlide)pres.Slides[0];

// Přidejte AutoShape typu Rectangle
IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

// Přidejte ITextFrame do obdélníku
ashp.AddTextFrame("Hello World");

// Změňte barvu textu na černou (což je výchozí bílá)
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Změňte barvu čáry obdélníku na bílou
ashp.ShapeStyle.LineColor.Color = Color.White;

// Odstraňte jakékoli výplňové formátování ve tvaru
ashp.FillFormat.FillType = FillType.NoFill;

// Uložte prezentaci na disk
pres.Save("HelloWorld.pptx", SaveFormat.Pptx);
```