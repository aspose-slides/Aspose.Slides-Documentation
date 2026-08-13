---
title: Skapa nya presentationer med VSTO och Aspose.Slides för .NET
linktitle: Skapa ny presentation
type: docs
weight: 10
url: /sv/net/create-a-new-presentation/
keywords:
- skapa presentation
- ny presentation
- migrering
- VSTO
- Office-automatisering
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Migrera från Microsoft Office-automatisering till Aspose.Slides för .NET och skapa nya PowerPoint (PPT, PPTX) presentationer i C# med ren, pålitlig kod."
---
{{% alert color="info" %}} 

VSTO utvecklades för att låta utvecklare bygga applikationer som kan köras i Microsoft Office. VSTO är COM-baserat men det är inbäddat i ett .NET-objekt så att det kan användas i .NET-applikationer. VSTO kräver stöd för .NET framework samt Microsoft Office CLR-baserad körtid. Även om det kan användas för att skapa Microsoft Office-tillägg är det nästan omöjligt att använda som en komponent på serversidan. Det har också allvarliga distributionsproblem.

Aspose.Slides for .NET är en komponent som kan användas för att manipulera Microsoft PowerPoint-presentationer, precis som VSTO, men den har flera fördelar:

- Aspose.Slides innehåller endast hanterad kod och kräver inte att Microsoft Office-körtid är installerad.
- Den kan användas som en klient-sides komponent eller som en server-sides komponent.
- Distribution är enkel eftersom Aspose.Slides finns i en enda DLL.

{{% /alert %}} 
## **Skapa en presentation**
Nedan följer två kodexempel som visar hur VSTO och Aspose.Slides for .NET kan användas för att uppnå samma mål. Det första exemplet är [VSTO](/slides/sv/net/create-a-new-presentation/); [det andra exemplet](/slides/sv/net/create-a-new-presentation/) använder Aspose.Slides.
### **VSTO‑exempel**
**VSTO‑utdata** 

![todo:image_alt_text](create-a-new-presentation_1.png)



```c#
//Obs: PowerPoint är ett namnrum som har definierats ovan på detta sätt
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//Skapa en presentation
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


### **Aspose.Slides for .NET‑exempel**
**Utdata från Aspose.Slides** 

![todo:image_alt_text](create-a-new-presentation_2.png)



```c#
using Aspose.Slides;
using Aspose.Slides.Export;

//Skapa en presentation
Presentation pres = new Presentation();

//Lägg till titelsliden
ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);


//Ange titeltexten
((IAutoShape)slide.Shapes[0]).TextFrame.Text = "Slide Title Heading";

//Ange underrubrikstexten
((IAutoShape)slide.Shapes[1]).TextFrame.Text = "Slide Title Sub-Heading";

//Skriv utdata till disk
pres.Save("outAsposeSlides.pptx", SaveFormat.Ppt);
```