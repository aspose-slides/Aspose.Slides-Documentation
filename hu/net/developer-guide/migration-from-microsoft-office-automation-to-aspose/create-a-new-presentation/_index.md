---
title: Új prezentációk létrehozása VSTO-val és az Aspose.Slides for .NET-tel
linktitle: Új prezentáció létrehozása
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
description: "Migráljon a Microsoft Office automatizálásból az Aspose.Slides for .NET-re, és hozza létre az új PowerPoint (PPT, PPTX) prezentációkat C#-ban tiszta, megbízható kóddal."
---
{{% alert color="primary" %}} 

A VSTO-t úgy fejlesztették ki, hogy a fejlesztők olyan alkalmazásokat készíthessenek, amelyek a Microsoft Office-on belül futtathatók. A VSTO COM-alapú, de egy .NET objektumba van csomagolva, így .NET alkalmazásokban használható. A VSTO-nak .NET keretrendszer támogatásra, valamint Microsoft Office CLR-alapú futtatókörnyezetre van szüksége. Bár használható Microsoft Office kiegészítők készítésére, szinte lehetetlen szerveroldali komponensként alkalmazni. Emellett súlyos telepítési problémákkal is küzd.

Az Aspose.Slides for .NET egy olyan komponens, amely a Microsoft PowerPoint prezentációk manipulálására használható, akárcsak a VSTO, de több előnnyel is rendelkezik:

- Az Aspose.Slides csak kezelt kódot tartalmaz, és nem igényli a Microsoft Office futtatókörnyezet telepítését.
- Használható kliensoldali vagy szerveroldali komponensként.
- A telepítés egyszerű, mivel az Aspose.Slides egyetlen DLL-ben található.

{{% /alert %}} 
## **Prezentáció létrehozása**
Az alábbiakban két kódrészletet láthat, amelyek bemutatják, hogyan használható a VSTO és az Aspose.Slides for .NET ugyanazzal a céllal. Az első példa a [VSTO](/slides/hu/net/create-a-new-presentation/); a [második példa](/slides/hu/net/create-a-new-presentation/) az Aspose.Slides-et használja.
### **VSTO példa**
**A VSTO kimenete** 

![todo:image_alt_text](create-a-new-presentation_1.png)



```c#
//Megjegyzés: A PowerPoint egy névtér, amelyet fentebb így definiáltunk
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//Create a presentation
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Get the title slide layout
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[PowerPoint.PpSlideLayout.ppLayoutTitle];

//Add a title slide.
PowerPoint.Slide slide = pres.Slides.AddSlide(1, layout);

//Set the title text
slide.Shapes.Title.TextFrame.TextRange.Text = "Slide Title Heading";

//Set the sub title text
slide.Shapes[2].TextFrame.TextRange.Text = "Slide Title Sub-Heading";

//Write the output to disk
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **Aspose.Slides for .NET példa**
**Az Aspose.Slides kimenete** 

![todo:image_alt_text](create-a-new-presentation_2.png)



```c#
//Prezentáció létrehozása
Presentation pres = new Presentation();

//Címlap hozzáadása
ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);



//A cím szövegének beállítása
((IAutoShape)slide.Shapes[0]).TextFrame.Text = "Slide Title Heading";

//Az alcím szövegének beállítása
((IAutoShape)slide.Shapes[1]).TextFrame.Text = "Slide Title Sub-Heading";

//Kimenet írása lemezre
pres.Save("c:\\data\\outAsposeSlides.pptx", SaveFormat.Ppt);
```