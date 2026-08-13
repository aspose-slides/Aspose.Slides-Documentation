---
title: Nieuwe presentaties maken met VSTO en Aspose.Slides voor .NET
linktitle: Nieuwe presentatie maken
type: docs
weight: 10
url: /nl/net/create-a-new-presentation/
keywords:
- presentatie maken
- nieuwe presentatie
- migratie
- VSTO
- Office-automatisering
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Migreer van Microsoft Office-automatisering naar Aspose.Slides voor .NET en maak nieuwe PowerPoint (PPT, PPTX) presentaties in C# met schone, betrouwbare code."
---
{{% alert color="info" %}} 

VSTO werd ontwikkeld om ontwikkelaars toe te staan applicaties te bouwen die binnen Microsoft Office kunnen draaien. VSTO is COM-gebaseerd, maar is verpakt in een .NET‑object zodat het kan worden gebruikt in .NET‑applicaties. VSTO vereist .NET‑frameworkondersteuning evenals een CLR‑gebaseerde runtime voor Microsoft Office. Hoewel het kan worden gebruikt voor het maken van Microsoft Office‑add‑ins, is het vrijwel onmogelijk om het als server‑side component te gebruiken. Het heeft bovendien serieuze implementatieproblemen.

Aspose.Slides for .NET is een component die kan worden gebruikt om Microsoft PowerPoint‑presentaties te manipuleren, net als VSTO, maar het heeft verschillende voordelen:

- Aspose.Slides bevat alleen beheerde code en vereist niet dat de Microsoft Office‑runtime geïnstalleerd is.
- Het kan worden gebruikt als client‑side component of als server‑side component.
- Implementatie is eenvoudig omdat Aspose.Slides in één enkele DLL zit.

{{% /alert %}} 
## **Een presentatie maken**
Hieronder staan twee code‑voorbeelden die laten zien hoe VSTO en Aspose.Slides for .NET kunnen worden gebruikt om hetzelfde doel te bereiken. Het eerste voorbeeld is [VSTO](/slides/nl/net/create-a-new-presentation/); [het tweede voorbeeld](/slides/nl/net/create-a-new-presentation/) gebruikt Aspose.Slides.
### **VSTO‑voorbeeld**
**De VSTO‑uitvoer** 

![todo:image_alt_text](create-a-new-presentation_1.png)



```c#
//Opmerking: PowerPoint is een namespace die hierboven op deze manier is gedefinieerd
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//Maak een presentatie
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Haal de titel‑dia‑indeling op
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[PowerPoint.PpSlideLayout.ppLayoutTitle];

//Voeg een titel‑dia toe.
PowerPoint.Slide slide = pres.Slides.AddSlide(1, layout);

//Stel de titelteks in
slide.Shapes.Title.TextFrame.TextRange.Text = "Slide Title Heading";

//Stel de ondertiteltekst in
slide.Shapes[2].TextFrame.TextRange.Text = "Slide Title Sub-Heading";

//Schrijf de uitvoer naar schijf
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **Aspose.Slides for .NET‑voorbeeld**
**De uitvoer van Aspose.Slides** 

![todo:image_alt_text](create-a-new-presentation_2.png)



```c#
using Aspose.Slides;
using Aspose.Slides.Export;

//Maak een presentatie
Presentation pres = new Presentation();

//Voeg de titel-dia toe
ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);


//Stel de titelteks in
((IAutoShape)slide.Shapes[0]).TextFrame.Text = "Slide Title Heading";

//Stel de ondertiteltekst in
((IAutoShape)slide.Shapes[1]).TextFrame.Text = "Slide Title Sub-Heading";

//Schrijf de uitvoer naar schijf
pres.Save("outAsposeSlides.pptx", SaveFormat.Ppt);
```