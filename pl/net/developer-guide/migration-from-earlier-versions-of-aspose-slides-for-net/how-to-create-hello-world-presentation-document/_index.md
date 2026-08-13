---
title: Jak tworzyć prezentacje Hello World w .NET
linktitle: Prezentacja Hello World
type: docs
weight: 10
url: /pl/net/how-to-create-hello-world-presentation-document/
keywords:
- migracja
- hello world
- kod legacy
- nowoczesny kod
- podejście legacy
- podejście nowoczesne
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Utwórz prezentację PowerPoint PPT, PPTX i ODP Hello World w .NET przy użyciu Aspose.Slides, korzystając zarówno ze starszego, jak i nowego API w prostym przewodniku."
---
{{% alert color="info" %}} 

Nowe [Aspose.Slides for .NET API](/slides/pl/net/) zostało wydane i teraz ten pojedynczy produkt obsługuje możliwość generowania dokumentów PowerPoint od podstaw oraz edytowania istniejących.

{{% /alert %}} 
## **Wsparcie dla kodu starszego**
Aby używać kodu legacy opracowanego przy użyciu wersji Aspose.Slides for .NET wcześniejszych niż 13.x, musisz wprowadzić niewielkie zmiany w swoim kodzie i będzie on działał tak jak wcześniej. Wszystkie klasy, które znajdowały się w starszej wersji Aspose.Slides for .NET w przestrzeniach nazw Aspose.Slide i Aspose.Slides.Pptx, zostały teraz scalone w jedną przestrzeń nazw Aspose.Slides. Zapoznaj się z poniższym prostym fragmentem kodu tworzącym dokument prezentacji Hello World w starszym API Aspose.Slides i postępuj zgodnie z krokami opisującymi migrację do nowego, scalanego API.
## **Starsze podejście Aspose.Slides for .NET**
```c#
using System.Drawing;
using Aspose.Slides;

//Utwórz obiekt Presentation, który reprezentuje plik PPT
Presentation pres = new Presentation();

//Utwórz obiekt License
License license = new License();

//Ustaw licencję Aspose.Slides for .NET, aby uniknąć ograniczeń wersji próbnej
license.SetLicense("Aspose.Slides.lic");

//Dodawanie pustego slajdu do prezentacji i pobranie odwołania do
//tego pustego slajdu
Slide slide = pres.AddEmptySlide();

//Dodawanie prostokąta (X=2400, Y=1800, Width=1000 & Height=500) do slajdu
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//Ukrywanie linii prostokąta
rect.LineFormat.ShowLines = false;

//Dodawanie ramki tekstowej do prostokąta z "Hello World" jako domyślnym tekstem
rect.AddTextFrame("Hello World");

//Usuwanie pierwszego slajdu prezentacji, który jest zawsze dodawany przez
//Aspose.Slides for .NET domyślnie podczas tworzenia prezentacji
pres.Slides.RemoveAt(0);

//Zapis prezentacji jako plik PPT
pres.Write("C:\\hello.ppt");
```



## **Nowe podejście Aspose.Slides for .NET 13.x**
```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Utwórz obiekt Presentation
Presentation pres = new Presentation();

// Pobierz pierwszy slajd
ISlide sld = (ISlide)pres.Slides[0];

// Dodaj AutoShape typu prostokąt
IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

// Dodaj ITextFrame do prostokąta
ashp.AddTextFrame("Hello World");

// Zmień kolor tekstu na czarny (domyślnie jest biały)
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Zmień kolor linii prostokąta na biały
ashp.ShapeStyle.LineColor.Color = Color.White;

// Usuń wszystkie formatowania wypełnienia w kształcie
ashp.FillFormat.FillType = FillType.NoFill;

// Zapisz prezentację na dysku
pres.Save("HelloWorld.pptx", SaveFormat.Pptx);
```