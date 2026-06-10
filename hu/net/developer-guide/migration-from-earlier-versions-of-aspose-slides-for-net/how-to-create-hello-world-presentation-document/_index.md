---
title: Hogyan hozzunk létre Hello World prezentációkat .NET-ben
linktitle: Hello World prezentáció
type: docs
weight: 10
url: /hu/net/how-to-create-hello-world-presentation-document/
keywords:
- migráció
- hello world
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
- description: "Készítsen egy Hello World PowerPoint PPT, PPTX és ODP prezentációt .NET-ben az Aspose.Slides segítségével, mind az örökölt, mind a modern API-kat felhasználva egy egyszerű útmutatóban."
---
{{% alert color="primary" %}} 
Megjelent egy új [Aspose.Slides for .NET API](/slides/hu/net/), és most ez a termék képes PowerPoint dokumentumok létrehozására a semmiből, valamint a meglévők szerkesztésére.
{{% /alert %}} 
## **Örökölt kód támogatása**
Az Aspose.Slides for .NET 13.x előtti verziókkal fejlesztett öröklött kód használatához néhány kisebb módosítást kell végrehajtania a kódban, hogy az úgy működjön, ahogy korábban. Az összes, a régi Aspose.Slides for .NET-ben az Aspose.Slide és az Aspose.Slides.Pptx névterek alatt megtalálható osztály most egyetlen Aspose.Slides névtérbe lett egyesítve. Tekintse meg az alábbi egyszerű kódrészletet, amely egy Hello World prezentációs dokumentumot hoz létre a régi Aspose.Slides API-val, és kövesse a lépéseket, amelyek leírják, hogyan lehet átmenni az új egyesített API-ra.
## **Legacy Aspose.Slides for .NET megközelítés**
```c#
//Egy Presentation objektum példányosítása, amely egy PPT fájlt képvisel
Presentation pres = new Presentation();

//License objektum létrehozása
License license = new License();

//A Aspose.Slides for .NET licencének beállítása az értékelési korlátozások elkerülése érdekében
license.SetLicense("Aspose.Slides.lic");

//Üres dia hozzáadása a prezentációhoz és az üres dia hivatkozásának lekérése
//az üres diára
Slide slide = pres.AddEmptySlide();

//Téglalap (X=2400, Y=1800, Szélesség=1000 & Magasság=500) hozzáadása a diára
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//A téglalap vonalainak elrejtése
rect.LineFormat.ShowLines = false;

//Szövegkeret hozzáadása a téglalaphoz a "Hello World" alapértelmezett szöveggel
rect.AddTextFrame("Hello World");

//A prezentáció első diájának eltávolítása, amely mindig hozzáadódik
//az Aspose.Slides for .NET alapértelmezés szerint a prezentáció létrehozásakor
pres.Slides.RemoveAt(0);

//Writing the presentation as a PPT file
pres.Write("C:\\hello.ppt");
```



## **Új Aspose.Slides for .NET 13.x megközelítés**
```c#
// Presentation példányosítása
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
pres.Save("D:\\data\\HelloWorld.pptx", SaveFormat.Pptx);
```