---
title: Új Prezentációk Létrehozása VSTO és Aspose.Slides for .NET Használatával
linktitle: Új Prezentáció Létrehozása
type: docs
weight: 10
url: /hu/net/create-a-new-presentation/
keywords:
- prezentáció létrehozása
- új prezentáció
- migráció
- VSTO
- Office automatizálás
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Migráljon a Microsoft Office automatizálásból az Aspose.Slides for .NET-re, és hozzon létre új PowerPoint (PPT, PPTX) prezentációkat C#-ban tiszta, megbízható kóddal."
---
{{% alert color="info" %}} 

A VSTO azért készült, hogy a fejlesztők olyan alkalmazásokat készíthessenek, amelyek a Microsoft Office-on belül futtathatók. A VSTO COM‑alapú, de egy .NET objektumba van csomagolva, így .NET alkalmazásokban használható. A VSTO‑nak szüksége van a .NET keretrendszer támogatására, valamint a Microsoft Office CLR‑alapú futtatókörnyezetére. Bár használható Microsoft Office kiegészítők készítésére, szinte lehetetlen szerveroldali komponensként használni. Ezen felül súlyos telepítési problémákkal is jár.

- Az Aspose.Slides csak kezelt kódot tartalmaz, és nem igényli a Microsoft Office futtatókörnyezet telepítését.
- Használható kliensoldali komponensként vagy szerveroldali komponensként is.
- A telepítés egyszerű, mivel az Aspose.Slides egyetlen DLL‑ben van.

{{% /alert %}} 
## **Prezentáció létrehozása**
Az alábbiakban két kódrészletet láthat, amelyek bemutatják, hogyan használhatók a VSTO és az Aspose.Slides for .NET ugyanannak a cél elérésére. Az első példa a [VSTO](/slides/hu/net/create-a-new-presentation/); [a második példa](/slides/hu/net/create-a-new-presentation/) az Aspose.Slides‑t használja.
### **VSTO példa**
**A VSTO kimenet** 

![todo:image_alt_text](create-a-new-presentation_1.png)



```c#
//Megjegyzés: A PowerPoint egy névtér, amelyet fentebb így definiáltunk
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//Prezentáció létrehozása
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//A címlap elrendezésének lekérése
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[PowerPoint.PpSlideLayout.ppLayoutTitle];

//Címlap hozzáadása.
PowerPoint.Slide slide = pres.Slides.AddSlide(1, layout);

//A cím szövegének beállítása
slide.Shapes.Title.TextFrame.TextRange.Text = "Slide Title Heading";

//Az alcím szövegének beállítása
slide.Shapes[2].TextFrame.TextRange.Text = "Slide Title Sub-Heading";

//Az eredmény írása lemezre
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **Aspose.Slides for .NET példa**
**Az Aspose.Slides kimenete** 

![todo:image_alt_text](create-a-new-presentation_2.png)



```c#
using Aspose.Slides;
using Aspose.Slides.Export;

//Prezentáció létrehozása
Presentation pres = new Presentation();

//Címlap hozzáadása
ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);


//A cím szövegének beállítása
((IAutoShape)slide.Shapes[0]).TextFrame.Text = "Slide Title Heading";

//Az alcím szövegének beállítása
((IAutoShape)slide.Shapes[1]).TextFrame.Text = "Slide Title Sub-Heading";

//Az eredmény írása lemezre
pres.Save("outAsposeSlides.pptx", SaveFormat.Ppt);
```