---
title: Dinamikus szöveg hozzáadása VSTO-val és Aspose.Slides for .NET használatával
linktitle: Dinamikus szöveg hozzáadása
type: docs
weight: 20
url: /hu/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/
keywords:
- szöveg hozzáadása
- migráció
- VSTO
- Office automatizálás
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Lássa, hogyan lehet migrálni a Microsoft Office automatizálásból az Aspose.Slides for .NET-re, és dinamikus szöveget hozzáadni a PowerPoint (PPT, PPTX) prezentációkhoz C#-ban."
---
{{% alert color="info" %}} 

A fejlesztők gyakran végzett feladata a szöveg dinamikus hozzáadása a diákhoz. Ez a cikk kódrészleteket mutat be a szöveg dinamikus hozzáadásához a [VSTO](/slides/hu/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/) és a [Aspose.Slides for .NET](/slides/hu/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/) használatával.

{{% /alert %}} 
## **Szöveg dinamikus hozzáadása**
Mindkét módszer ezeket a lépéseket követi:

1. Készítsen egy bemutatót.
1. Adjon hozzá egy üres diát.
1. Adjon hozzá egy szövegdobozt.
1. Állítson be némi szöveget.
1. Mentse el a bemutatót.
## **VSTO kódpélda**
Az alábbi kódrészletek egy egyszerű diát és egy szövegsort tartalmazó bemutatót hoznak létre.

**A VSTO-val létrehozott bemutató** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_1.png)

```c#
//Megjegyzés: a PowerPoint egy névtér, amely fentebb így lett definiálva
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//Prezentáció létrehozása
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Get the blank slide layout
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[7];

//Add a blank slide
PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);

//Add a text
PowerPoint.Shape shp = sld.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 150, 100, 400, 100);

//Set a text
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Text = "Text added dynamically";
txtRange.Font.Name = "Arial";
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;
txtRange.Font.Size = 32;

//Write the output to disk
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```



## **Aspose.Slides for .NET példa**
Az alábbi kódrészletek az Aspose.Slides használatával hoznak létre egy egyszerű diát és egy szövegsort tartalmazó bemutatót.

**Az Aspose.Slides for .NET használatával létrehozott bemutató** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_2.png)

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

//Prezentáció létrehozása
Presentation pres = new Presentation();

//Az üres dia alapértelmezés szerint hozzáadódik, amikor létrehozza
//a prezentációt az alapértelmezett konstruktorral
//Tehát nincs szükség további üres dia hozzáadására
ISlide sld = pres.Slides[1];

//Szövegmező hozzáadása
//A hozzáadáshoz először egy téglalapot fogunk hozzáadni
IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 1200, 800, 3200, 370);

//A vonal elrejtése
shp.LineFormat.Style = LineStyle.NotDefined;

//Ezután egy szövegkeretet adunk hozzá benne
ITextFrame tf = ((IAutoShape)shp).TextFrame;

//Szöveg beállítása
tf.Text = "Text added dynamically";
IPortion port = tf.Paragraphs[0].Portions[0];

port.PortionFormat.FontBold = NullableBool.True;
port.PortionFormat.FontHeight = 32;

//Az eredmény mentése lemezre
pres.Save("outAspose.ppt", SaveFormat.Ppt);
```