---
title: Jak tworzyć prezentacje Hello World w .NET
linktitle: Prezentacja Hello World
type: docs
weight: 10
url: /pl/net/how-to-create-hello-world-presentation-document/
keywords:
- migracja
- hello world
- starszy kod
- nowoczesny kod
- starsze podejście
- nowoczesne podejście
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Utwórz prezentację PowerPoint PPT, PPTX i ODP Hello World w .NET przy użyciu Aspose.Slides, korzystając zarówno ze starszych, jak i nowoczesnych interfejsów API w prostym przewodniku."
---
{{% alert color="info" %}} 

Nowe [Aspose.Slides for .NET API](/slides/pl/net/) zostało wydane i teraz ten jeden produkt obsługuje możliwość generowania dokumentów PowerPoint od podstaw oraz edytowania istniejących.

{{% /alert %}} 
## **Support for Legacy Code**
Aby używać starszego kodu opracowanego w wersjach Aspose.Slides for .NET sprzed 13.x, musisz wprowadzić drobne zmiany w swoim kodzie, po czym będzie on działał jak wcześniej. Wszystkie klasy, które były dostępne w starszych wersjach Aspose.Slides for .NET w przestrzeniach nazw Aspose.Slide i Aspose.Slides.Pptx, zostały teraz połączone w jedną przestrzeń nazw Aspose.Slides. Zapoznaj się z poniższym prostym fragmentem kodu tworzącym dokument prezentacji Hello World w starszym API Aspose.Slides i postępuj zgodnie z krokami opisującymi migrację do nowego, scalonego API.
## **Legacy Aspose.Slides for .NET Approach**
```c#
using System.Drawing;
using Aspose.Slides;

//Utwórz obiekt Presentation, który reprezentuje plik PPT
Presentation pres = new Presentation();

//Utwórz obiekt License
License license = new License();

//Ustaw licencję Aspose.Slides dla .NET, aby uniknąć ograniczeń wersji próbnej
license.SetLicense("Aspose.Slides.lic");

//Dodawanie pustego slajdu do prezentacji i pobieranie referencji do
//tego pustego slajdu
Slide slide = pres.AddEmptySlide();

//Dodawanie prostokąta (X=2400, Y=1800, Szerokość=1000 & Height=500) do slajdu
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//Ukrywanie linii prostokąta
rect.LineFormat.ShowLines = false;

//Dodawanie ramki tekstowej do prostokąta z "Hello World" jako domyślnym tekstem
rect.AddTextFrame("Hello World");

//Usuwanie pierwszego slajdu prezentacji, który jest zawsze dodawany przez
//Aspose.Slides for .NET domyślnie podczas tworzenia prezentacji
pres.Slides.RemoveAt(0);

//Zapisywanie prezentacji jako plik PPT
pres.Write("C:\\hello.ppt");
```



## **New Aspose.Slides for .NET 13.x Approach**
```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Zainicjalizuj prezentację
Presentation pres = new Presentation();

// Pobierz pierwszy slajd
ISlide sld = (ISlide)pres.Slides[0];

// Dodaj AutoShape typu Prostokąt
IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

// Dodaj ITextFrame do prostokąta
ashp.AddTextFrame("Hello World");

// Zmień kolor tekstu na czarny (domyślnie jest biały)
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Zmień kolor linii prostokąta na biały
ashp.ShapeStyle.LineColor.Color = Color.White;

// Usuń wszelkie formatowanie wypełnienia w kształcie
ashp.FillFormat.FillType = FillType.NoFill;

// Zapisz prezentację na dysku
pres.Save("HelloWorld.pptx", SaveFormat.Pptx);
```