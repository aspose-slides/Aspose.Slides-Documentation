---
title: Vytvoření nových prezentací pomocí VSTO a Aspose.Slides pro .NET
linktitle: Vytvořit novou prezentaci
type: docs
weight: 10
url: /cs/net/create-a-new-presentation/
keywords:
- vytvořit prezentaci
- nová prezentace
- migrace
- VSTO
- automatizace Office
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Přesuňte se z automatizace Microsoft Office na Aspose.Slides pro .NET a vytvořte nové PowerPoint (PPT, PPTX) prezentace v C# s čistým, spolehlivým kódem."
---
{{% alert color="info" %}} 

VSTO bylo vyvinuto, aby vývojářům umožnilo vytvářet aplikace, které mohou běžet uvnitř Microsoft Office. VSTO je založeno na COM, ale je zabaleno do objektu .NET, aby ho šlo použít v aplikacích .NET. VSTO vyžaduje podporu .NET Framework a také runtime Microsoft Office založený na CLR. Ačkoliv jej lze použít pro tvorbu doplňků Microsoft Office, je téměř nemožné jej použít jako komponentu na straně serveru. Má také vážné problémy s nasazením.

Aspose.Slides for .NET je komponenta, která může být použita k manipulaci s prezentacemi Microsoft PowerPoint, podobně jako VSTO, ale má několik výhod:

- Aspose.Slides obsahuje pouze spravovaný kód a nevyžaduje instalaci runtime Microsoft Office.
- Lze jej použít jako komponentu na straně klienta nebo na straně serveru.
- Nasazení je snadné, protože Aspose.Slides je obsaženo v jediném DLL souboru.

{{% /alert %}} 
## **Vytvoření prezentace**
Níže jsou dva příklady kódu, které ukazují, jak lze VSTO a Aspose.Slides for .NET použít k dosažení stejného cíle. První příklad je [VSTO](/slides/cs/net/create-a-new-presentation/); [druhý příklad](/slides/cs/net/create-a-new-presentation/) používá Aspose.Slides.
### **Příklad VSTO**
**Výstup VSTO** 

![todo:image_alt_text](create-a-new-presentation_1.png)



```c#
//Poznámka: PowerPoint je jmenný prostor, který byl výše definován takto
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//Vytvořit prezentaci
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Získat rozvržení titulního snímku
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[PowerPoint.PpSlideLayout.ppLayoutTitle];

//Přidat titulní snímek.
PowerPoint.Slide slide = pres.Slides.AddSlide(1, layout);

//Nastavit text názvu
slide.Shapes.Title.TextFrame.TextRange.Text = "Slide Title Heading";

//Nastavit text podnadpisu
slide.Shapes[2].TextFrame.TextRange.Text = "Slide Title Sub-Heading";

//Zapsat výstup na disk
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **Příklad Aspose.Slides for .NET**
**Výstup z Aspose.Slides** 

![todo:image_alt_text](create-a-new-presentation_2.png)



```c#
using Aspose.Slides;
using Aspose.Slides.Export;

//Vytvořit prezentaci
Presentation pres = new Presentation();

//Přidat titulní snímek
ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);


//Nastavit text názvu
((IAutoShape)slide.Shapes[0]).TextFrame.Text = "Slide Title Heading";

//Nastavit text podnadpisu
((IAutoShape)slide.Shapes[1]).TextFrame.Text = "Slide Title Sub-Heading";

//Zapsat výstup na disk
pres.Save("outAsposeSlides.pptx", SaveFormat.Ppt);
```