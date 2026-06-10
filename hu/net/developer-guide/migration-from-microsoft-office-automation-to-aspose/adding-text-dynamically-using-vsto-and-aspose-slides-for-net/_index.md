---
title: Dinamikus szöveg hozzáadása VSTO és Aspose.Slides for .NET használatával
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
description: "Lásd, hogyan lehet átállni a Microsoft Office automatizálásról az Aspose.Slides for .NET-re, és dinamikus szöveget hozzáadni a PowerPoint (PPT, PPTX) prezentációkhoz C#-ban."
---
{{% alert color="primary" %}} 

A fejlesztők gyakran végrehajtandó feladat a szöveg dinamikus hozzáadása a diákhoz. Ez a cikk kódpéldákat mutat be a szöveg dinamikus hozzáadásához a [VSTO](/slides/hu/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/) és az [Aspose.Slides for .NET](/slides/hu/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/) használatával.

{{% /alert %}} 
## **Adding Text Dynamically**
Mindkét módszer a következő lépéseket követi:

1. Hozzon létre egy prezentációt.
1. Adjon hozzá egy üres diát.
1. Adjon hozzá egy szövegdobozt.
1. Állítson be szöveget.
1. Írja ki a prezentációt.
## **VSTO Code Example**
Az alábbi kódrészletek egy egyszerű diát és egy szövegsort tartalmazó prezentációt eredményeznek.

**The presentation as created in VSTO** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_1.png)

```c#
//Megjegyzés: a PowerPoint egy névtér, amelyet fentebb így definiáltunk
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//Prezentáció létrehozása
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Üres dia elrendezésének lekérése
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[7];

//Üres dia hozzáadása
PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);

//Szöveg hozzáadása
PowerPoint.Shape shp = sld.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 150, 100, 400, 100);

//Szöveg beállítása
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Text = "Text added dynamically";
txtRange.Font.Name = "Arial";
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;
txtRange.Font.Size = 32;

//Kimenet mentése lemezre
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);

```



## **Aspose.Slides for .NET Example**
Az alábbi kódrészletek az Aspose.Slides segítségével hoznak létre egy egyszerű diát és egy szövegsort tartalmazó prezentációt.

**The presentation as created using Aspose.Slides for .NET** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_2.png)

```c#
//Prezentáció létrehozása
Presentation pres = new Presentation();

//Az üres dia alapértelmezés szerint hozzáadódik, amikor létrehozod
//a prezentációt az alapértelmezett konstruktorral
//Ezért nem kell semmilyen üres diát hozzáadni
ISlide sld = pres.Slides[1];

//Szövegdoboz hozzáadása
//A hozzáadáshoz először egy négyzetet adunk hozzá
IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 1200, 800, 3200, 370);

//Elrejti a vonalat
shp.LineFormat.Style = LineStyle.NotDefined;

//Ezután szövegkeretet adunk hozzá benne
ITextFrame tf = ((IAutoShape)shp).TextFrame;

//Szöveg beállítása
tf.Text = "Text added dynamically";
IPortion port = tf.Paragraphs[0].Portions[0];

port.PortionFormat.FontBold = NullableBool.True;
port.PortionFormat.FontHeight = 32;

//Kimenet írása lemezre
pres.Save("c:\\outAspose.ppt", SaveFormat.Ppt);
```