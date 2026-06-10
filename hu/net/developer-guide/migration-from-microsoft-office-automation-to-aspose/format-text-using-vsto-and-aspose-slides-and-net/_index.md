---
title: Szöveg formázása VSTO és Aspose.Slides for .NET használatával
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
description: "Migráljon a Microsoft Office automatizálásról az Aspose.Slides for .NET-re, és pontos vezérléssel formázza a szöveget PowerPoint (PPT, PPTX) prezentációkban."
---
{{% alert color="primary" %}} 

Néha szükség van arra, hogy a diákon lévő szöveget programozott módon formázzuk. Ez a cikk azt mutatja be, hogyan olvassunk be egy mintaprezentációt, amelynek első diáján van egy szöveg, akár a [VSTO](/slides/hu/net/format-text-using-vsto-and-aspose-slides-and-net/) vagy az [Aspose.Slides for .NET](/slides/hu/net/format-text-using-vsto-and-aspose-slides-and-net/) segítségével. A kód a dia harmadik szövegdobozában lévő szöveget úgy formázza, hogy az az utolsó szövegdoboz szövegéhez hasonlítson.

{{% /alert %}} 
## **Szöveg formázása**
A VSTO és az Aspose.Slides módszerek a következő lépéseket hajtják végre:

1. Nyissa meg a forrásprezentációt.
1. Nyissa meg az első diát.
1. Nyissa meg a harmadik szövegdobozt.
1. Módosítsa a harmadik szövegdobozban lévő szöveg formázását.
1. Mentse a prezentációt a lemezen.

Az alábbi képernyőképek a mintadiát mutatják a VSTO és az Aspose.Slides for .NET kód végrehajtása előtt és után.

**A bemeneti prezentáció** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_1.png)
### **VSTO kódpélda**
Az alábbi kód bemutatja, hogyan lehet a szöveget újraformázni egy dián a VSTO segítségével.

**A VSTO-val újraformázott szöveg** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_2.png)



```c#
//Megjegyzés: A PowerPoint egy névtér, amelyet fentebb úgy definiáltunk, mint ez
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;
PowerPoint.Presentation pres = null;

//Nyissa meg a prezentációt
pres = Globals.ThisAddIn.Application.Presentations.Open("c:\\source.ppt",
	Microsoft.Office.Core.MsoTriState.msoFalse,
	Microsoft.Office.Core.MsoTriState.msoFalse,
	Microsoft.Office.Core.MsoTriState.msoTrue);

//Az első dia elérése
PowerPoint.Slide slide = pres.Slides[1];

//A harmadik alakzat elérése
PowerPoint.Shape shp = slide.Shapes[3];

//A szöveg betűtípusa Verdana, a méret 32
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Font.Name = "Verdana";
txtRange.Font.Size = 32;

//Félkövérre állítja
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Döntötté teszi
txtRange.Font.Italic = Microsoft.Office.Core.MsoTriState.msoCTrue;

//A szöveg színének módosítása
txtRange.Font.Color.RGB = 0x00CC3333;

//Az alakzat háttérszínének módosítása
shp.Fill.ForeColor.RGB = 0x00FFCCCC;

//Vízszintesen áthelyezi
shp.Left -= 70;

//Az eredményt lemezre írja
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```




### **Aspose.Slides for .NET példa**
A szöveg formázásához az Aspose.Slides segítségével, először adja hozzá a betűtípust, mielőtt formázná a szöveget.

**Az Aspose.Slides által létrehozott kimeneti prezentáció** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_3.png)



```c#
 //Nyissa meg a prezentációt
Presentation pres = new Presentation("c:\\source.ppt");

//Az első dia elérése
ISlide slide = pres.Slides[0];

//A harmadik alakzat elérése
IShape shp = slide.Shapes[2];

//A szöveg betűtípusa Verdana, a méret 32
ITextFrame tf = ((IAutoShape)shp).TextFrame;
IParagraph para = tf.Paragraphs[0];
IPortion port = para.Portions[0];
port.PortionFormat.LatinFont = new FontData("Verdana");

port.PortionFormat.FontHeight = 32;

//Félkövérre állítja
port.PortionFormat.FontBold = NullableBool.True;

//Döntötté teszi
port.PortionFormat.FontItalic = NullableBool.True;

//A szöveg színének módosítása
//Betűszín beállítása
port.PortionFormat.FillFormat.FillType = FillType.Solid;
port.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(0x33, 0x33, 0xCC);

//Az alakzat háttérszínének módosítása
shp.FillFormat.FillType = FillType.Solid;
shp.FillFormat.SolidFillColor.Color = Color.FromArgb(0xCC, 0xCC, 0xFF);

//Az eredményt lemezre írja
pres.Save("c:\\outAspose.ppt", SaveFormat.Ppt);
```