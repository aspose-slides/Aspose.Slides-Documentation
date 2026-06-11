---
title: Jak utworzyć prezentacje Hello World w .NET
linktitle: Prezentacja Hello World
type: docs
weight: 10
url: /pl/net/how-to-create-hello-world-presentation-document/
keywords:
- migracja
- hello world
- kod przestarzały
- nowoczesny kod
- podejście przestarzałe
- nowoczesne podejście
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
- description: "Utwórz prezentację Hello World w formatach PowerPoint PPT, PPTX i ODP w .NET przy użyciu Aspose.Slides, korzystając zarówno z interfejsów legacy, jak i nowoczesnych, w prostym przewodniku."
---
{{% alert color="primary" %}} 

Nowe [Aspose.Slides for .NET API](/slides/pl/net/) zostało wydane i teraz ten pojedynczy produkt obsługuje możliwość generowania dokumentów PowerPoint od podstaw oraz edytowania istniejących.

{{% /alert %}} 
## **Wsparcie dla kodu legacy**
Aby używać kodu legacy opracowanego w wersjach Aspose.Slides for .NET starszych niż 13.x, należy wprowadzić drobne zmiany w kodzie, a kod będzie działał jak wcześniej. Wszystkie klasy, które znajdowały się w starszych wersjach Aspose.Slides for .NET w przestrzeniach nazw Aspose.Slide i Aspose.Slides.Pptx, są teraz połączone w jedną przestrzeń nazw Aspose.Slides. Zapoznaj się z poniższym prostym fragmentem kodu tworzącym dokument prezentacji Hello World w starszym API Aspose.Slides i postępuj zgodnie z krokami opisującymi, jak migrować do nowego połączonego API.
## **Podejście Legacy Aspose.Slides for .NET**
```c#
//Utwórz obiekt Presentation reprezentujący plik PPT
//Utwórz obiekt License
//Ustaw licencję Aspose.Slides dla .NET, aby uniknąć ograniczeń wersji ewaluacyjnej
//Dodaj pusty slajd do prezentacji i pobierz odwołanie do
//tego pustego slajdu
//Dodaj prostokąt (X=2400, Y=1800, Szerokość=1000 i Wysokość=500) do slajdu
//Ukryj linie prostokąta
//Dodaj ramkę tekstową do prostokąta z domyślnym tekstem "Hello World"
//Usuń pierwszy slajd prezentacji, który jest zawsze dodawany przez
//Aspose.Slides dla .NET domyślnie podczas tworzenia prezentacji
//Zapisz prezentację jako plik PPT
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



## **Nowe podejście Aspose.Slides for .NET 13.x**
```c#
// Utwórz obiekt Presentation
Presentation pres = new Presentation();

// Pobierz pierwszy slajd
ISlide sld = (ISlide)pres.Slides[0];

// Dodaj AutoShape typu Rectangle
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
pres.Save("D:\\data\\HelloWorld.pptx", SaveFormat.Pptx);
```