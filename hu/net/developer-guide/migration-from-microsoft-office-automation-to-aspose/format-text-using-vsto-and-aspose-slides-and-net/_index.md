---
title: VSTO és Aspose.Slides for .NET használatával szöveg formázása
linktitle: Szöveg formázása
type: docs
weight: 30
url: /hu/net/format-text-using-vsto-and-aspose-slides-and-net/
keywords:
- szöveg formázása
- migráció
- VSTO
- Office automatizálás
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Migráljon a Microsoft Office automatizálásból az Aspose.Slides for .NET-re, és pontos irányítással formázza a szöveget PowerPoint (PPT, PPTX) prezentációkban."
---
{{% alert color="info" %}} 

Néha programozott módon kell a diák szövegét formázni. Ez a cikk bemutatja, hogyan olvassunk be egy példaprezentációt, amelynek az első diáján szöveg található, a [VSTO](/slides/hu/net/format-text-using-vsto-and-aspose-slides-and-net/) vagy a [Aspose.Slides for .NET](/slides/hu/net/format-text-using-vsto-and-aspose-slides-and-net/) használatával. A kód a dia harmadik szövegdobozának szövegét úgy formázza, hogy hasonlítson az utolsó szövegdoboz szövegére.

{{% /alert %}} 
## **Szöveg formázása**
Mind a VSTO, mind az Aspose.Slides módszerek a következő lépéseket tartalmazzák:

1. Nyissa meg a forrásprezentációt.
1. Hozzáférés az első diahoz.
1. Hozzáférés a harmadik szövegdobozhoz.
1. A harmadik szövegdoboz szövegének formázásának módosítása.
1. A prezentáció mentése lemezre.

Az alábbi képernyőképek a mintadiát mutatják a VSTO és az Aspose.Slides for .NET kód futtatása előtti és utáni állapotban.

**A bemeneti prezentáció** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_1.png)
### **VSTO kódpélda**
Az alábbi kód bemutatja, hogyan lehet a dián lévő szöveget VSTO-val újraformázni.

**A VSTO-val újraformázott szöveg** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_2.png)



```c#
//Megjegyzés: a PowerPoint egy névtér, amelyet fentebb így definiáltunk
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;
PowerPoint.Presentation pres = null;

//Nyissa meg a prezentációt
pres = Globals.ThisAddIn.Application.Presentations.Open("c:\\source.ppt",
	Microsoft.Office.Core.MsoTriState.msoFalse,
	Microsoft.Office.Core.MsoTriState.msoFalse,
	Microsoft.Office.Core.MsoTriState.msoTrue);

//Hozzáférés az első diához
PowerPoint.Slide slide = pres.Slides[1];

//Hozzáférés a harmadik alakzathoz
PowerPoint.Shape shp = slide.Shapes[3];

//Módosítsa a szöveg betűtípusát Verdana-ra és a magasságot 32-re
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Font.Name = "Verdana";
txtRange.Font.Size = 32;

//Állítsa félkövérre
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Állítsa dőltre
txtRange.Font.Italic = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Módosítsa a szöveg színét
txtRange.Font.Color.RGB = 0x00CC3333;

//Módosítsa az alakzat háttérszínét
shp.Fill.ForeColor.RGB = 0x00FFCCCC;

//Vízszintesen helyezze át
shp.Left -= 70;

//Írja ki a kimenetet lemezre
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```




### **Aspose.Slides for .NET példa**
A szöveg formázásához az Aspose.Slides használatával először adja hozzá a betűtípust, mielőtt formázná a szöveget.

**Az Aspose.Slides által létrehozott kimeneti prezentáció** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_3.png)



```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

 //Nyissa meg a prezentációt
Presentation pres = new Presentation("source.ppt");

//Hozzáférés az első diához
ISlide slide = pres.Slides[0];

//Hozzáférés a harmadik alakzathoz
IShape shp = slide.Shapes[2];

//Módosítsa a szöveg betűtípusát Verdana-ra és a magasságot 32-re
ITextFrame tf = ((IAutoShape)shp).TextFrame;
IParagraph para = tf.Paragraphs[0];
IPortion port = para.Portions[0];
port.PortionFormat.LatinFont = new FontData("Verdana");

port.PortionFormat.FontHeight = 32;

//Állítsa félkövérre
port.PortionFormat.FontBold = NullableBool.True;

//Állítsa dőltre
port.PortionFormat.FontItalic = NullableBool.True;

//Módosítsa a szöveg színét
//Állítsa be a betűszínt
port.PortionFormat.FillFormat.FillType = FillType.Solid;
port.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(0x33, 0x33, 0xCC);

//Módosítsa az alakzat háttérszínét
shp.FillFormat.FillType = FillType.Solid;
shp.FillFormat.SolidFillColor.Color = Color.FromArgb(0xCC, 0xCC, 0xFF);

//Írja ki a kimenetet lemezre
pres.Save("outAspose.ppt", SaveFormat.Ppt);
```