---
title: Hogyan hozzunk létre Hello World prezentációkat .NET-ben
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
- description: "Hozzon létre egy Hello World PowerPoint PPT, PPTX és ODP prezentációt .NET-ben az Aspose.Slides segítségével, mind az örökölt, mind a modern API-kat használva egy egyszerű útmutatóban."
---
{{% alert color="info" %}} 

Új [Aspose.Slides for .NET API](/slides/hu/net/) került kiadásra, és most ez a termék képes PowerPoint‑dokumentumok generálására a semmiből, valamint a meglévők szerkesztésére.

{{% /alert %}} 
## **Támogatás a régi kódokhoz**
Az Aspose.Slides for .NET 13.x előtti verziókkal készült régi kód használatához néhány kisebb módosításra van szükség a kódban, és a kód úgy fog működni, mint korábban. Az összes osztály, amelyek korábban az Aspose.Slides for .NET régi Aspose.Slide és Aspose.Slides.Pptx névtérben voltak, most egyetlen Aspose.Slides névtérbe össze vannak vonva. Kérjük, tekintse meg az alábbi egyszerű kódrészletet, amely egy Hello World prezentációs dokumentumot hoz létre a régi Aspose.Slides API-val, és kövesse a lépéseket, amelyek leírják, hogyan lehet átállni az új egyesített API-ra.
## **Régi Aspose.Slides for .NET megközelítés**
```c#
using System.Drawing;
using Aspose.Slides;

//Instantiate a Presentation object that represents a PPT file
//Példányosít egy Presentation objektumot, amely egy PPT fájlt képvisel

//Create a License object
//Létrehoz egy License objektumot

//Set the license of Aspose.Slides for .NET to avoid the evaluation limitations
//Beállítja az Aspose.Slides for .NET licencet az értékelési korlátozások elkerülése érdekében

Presentation pres = new Presentation();

License license = new License();

//Adding an empty slide to the presentation and getting the reference of
//Üres diát ad a prezentációhoz, és lekéri az
//that empty slide
//az üres diát

Slide slide = pres.AddEmptySlide();

//Adding a rectangle (X=2400, Y=1800, Width=1000 & Height=500) to the slide
//Rectangle-ot (X=2400, Y=1800, Szélesség=1000 és Magasság=500) ad a diára
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//Hiding the lines of rectangle
//A rectangle vonalait elrejti
rect.LineFormat.ShowLines = false;

//Adding a text frame to the rectangle with "Hello World" as a default text
//Szövegkeretet ad a rectangle-hoz, alapértelmezett szöveggel: "Hello World"
rect.AddTextFrame("Hello World");

//Removing the first slide of the presentation which is always added by
//Eltávolítja a prezentáció első diáját, amelyet a
//Aspose.Slides for .NET by default while creating the presentation
//Az Aspose.Slides for .NET alapértelmezés szerint a prezentáció létrehozásakor ad hozzá
pres.Slides.RemoveAt(0);

//Writing the presentation as a PPT file
pres.Write("C:\\hello.ppt");
```



## **Új Aspose.Slides for .NET 13.x megközelítés**
```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instantiate Presentation
// Példányosítja a Presentation objektumot
Presentation pres = new Presentation();

// Get the first slide
// Lekéri az első diát
ISlide sld = (ISlide)pres.Slides[0];

// Add an AutoShape of Rectangle type
// Hozzáad egy Rectangle típusú AutoShape-ot
IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

// Add ITextFrame to the Rectangle
// Hozzáad egy ITextFrame-et a Rectangle-hez
ashp.AddTextFrame("Hello World");

// Change the text color to Black (which is White by default)
 // A szöveg színét feketére állítja (ami alapértelmezés szerint fehér)
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Change the line color of the rectangle to White
// A rectangle vonal színét fehérre állítja
ashp.ShapeStyle.LineColor.Color = Color.White;

// Remove any fill formatting in the shape
// Eltávolítja a forma minden kitöltési formátumát
ashp.FillFormat.FillType = FillType.NoFill;

// Save the presentation to disk
// Mentse a prezentációt a lemezen
pres.Save("HelloWorld.pptx", SaveFormat.Pptx);
```