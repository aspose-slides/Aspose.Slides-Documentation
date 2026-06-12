---
title: Jak vytvořit prezentace Hello World v .NET
linktitle: Prezentace Hello World
type: docs
weight: 10
url: /cs/net/how-to-create-hello-world-presentation-document/
keywords:
- migrace
- ahoj svět
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
description: "Vytvořte prezentaci PowerPoint PPT, PPTX a ODP Hello World v .NET pomocí Aspose.Slides s využitím jak legacy, tak moderních API v jednom jednoduchém průvodci."
---
{{% alert color="primary" %}} 
Bylo vydáno nové rozhraní [Aspose.Slides for .NET API](/slides/cs/net/) a nyní tento jedinečný produkt podporuje možnost generovat PowerPoint dokumenty od nuly a upravovat existující.
{{% /alert %}} 
## **Podpora starého kódu**
Abyste mohli používat starý kód vyvinutý s Aspose.Slides pro .NET ve verzích starších než 13.x, musíte provést několik drobných úprav ve svém kódu a kód bude fungovat jako dříve. Všechny třídy, které byly v staré verzi Aspose.Slides pro .NET v jmenných prostorech Aspose.Slide a Aspose.Slides.Pptx, jsou nyní sloučeny do jediného jmenného prostoru Aspose.Slides. Podívejte se na následující jednoduchý úryvek kódu pro vytvoření prezentace „Hello World“ v legacy Aspose.Slides API a postupujte podle kroků, které popisují, jak migrovat na nově sloučené API.
## **Legacy přístup k Aspose.Slides pro .NET**
```c#
//Vytvořte objekt Presentation, který představuje soubor PPT
Presentation pres = new Presentation();

//Vytvořte objekt License
License license = new License();

//Nastavte licenci Aspose.Slides pro .NET, abyste se vyhnuli omezením vyhodnocení
license.SetLicense("Aspose.Slides.lic");

//Přidání prázdného snímku do prezentace a získání reference na
//tento prázdný snímek
Slide slide = pres.AddEmptySlide();

//Přidání obdélníku (X=2400, Y=1800, Šířka=1000 & Výška=500) na snímek
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//Skrytí čar obdélníku
rect.LineFormat.ShowLines = false;

//Přidání textového rámce do obdélníku s výchozím textem "Hello World"
rect.AddTextFrame("Hello World");

//Odstranění prvního snímku prezentace, který je vždy přidán
//Aspose.Slides pro .NET ve výchozím stavu při vytváření prezentace
pres.Slides.RemoveAt(0);

//Zapsání prezentace jako soubor PPT
pres.Write("C:\\hello.ppt");
```


## **Nový přístup k Aspose.Slides pro .NET 13.x**
```c#
// Vytvořte instanci Presentation
Presentation pres = new Presentation();

// Získejte první snímek
ISlide sld = (ISlide)pres.Slides[0];

// Přidejte AutoShape typu Rectangle
IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

// Přidejte ITextFrame do obdélníku
ashp.AddTextFrame("Hello World");

// Změňte barvu textu na černou (což je ve výchozím nastavení bílá)
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Změňte barvu čáry obdélníku na bílou
ashp.ShapeStyle.LineColor.Color = Color.White;

// Odstraňte ve tvaru všechny výplňové formátování
ashp.FillFormat.FillType = FillType.NoFill;

// Uložte prezentaci na disk
pres.Save("D:\\data\\HelloWorld.pptx", SaveFormat.Pptx);
```