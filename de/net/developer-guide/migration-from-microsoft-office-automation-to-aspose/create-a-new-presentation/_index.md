---
title: Neue Präsentationen mit VSTO und Aspose.Slides für .NET erstellen
linktitle: Neue Präsentation erstellen
type: docs
weight: 10
url: /de/net/create-a-new-presentation/
keywords:
- Präsentation erstellen
- neue Präsentation
- Migration
- VSTO
- Office-Automatisierung
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Von der Microsoft Office-Automatisierung zu Aspose.Slides für .NET migrieren und neue PowerPoint (PPT, PPTX)-Präsentationen in C# mit sauberem, zuverlässigem Code erstellen."
---

{{% alert color="primary" %}} 

VSTO wurde entwickelt, um Entwicklern das Erstellen von Anwendungen zu ermöglichen, die innerhalb von Microsoft Office ausgeführt werden können. VSTO basiert auf COM, ist aber in ein .NET‑Objekt eingebettet, sodass es in .NET‑Anwendungen verwendet werden kann. VSTO benötigt sowohl .NET‑Framework‑Support als auch die CLR‑basierte Laufzeit von Microsoft Office. Obwohl es zum Erstellen von Microsoft Office‑Add‑Ins verwendet werden kann, ist es nahezu unmöglich, es als serverseitige Komponente einzusetzen. Außerdem gibt es gravierende Deployments‑Probleme.

Aspose.Slides für .NET ist eine Komponente, die zum Manipulieren von Microsoft PowerPoint‑Präsentationen verwendet werden kann, ähnlich wie VSTO, bietet jedoch mehrere Vorteile:

- Aspose.Slides enthält nur verwalteten Code und erfordert nicht, dass die Microsoft Office‑Laufzeit installiert ist.
- Es kann als clientseitige Komponente oder als serverseitige Komponente verwendet werden.
- Die Bereitstellung ist einfach, da Aspose.Slides in einer einzigen DLL enthalten ist.

{{% /alert %}} 
## **Erstellen einer Präsentation**
Unten sind zwei Codebeispiele, die zeigen, wie VSTO und Aspose.Slides für .NET verwendet werden können, um dasselbe Ziel zu erreichen. Das erste Beispiel ist [VSTO](/slides/de/net/create-a-new-presentation/); das zweite Beispiel verwendet Aspose.Slides.
### **VSTO-Beispiel**
**Die VSTO-Ausgabe** 

![todo:image_alt_text](create-a-new-presentation_1.png)
```c#
//Hinweis: PowerPoint ist ein Namespace, der oben wie folgt definiert wurde
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//Eine Präsentation erstellen
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



### **Aspose.Slides für .NET-Beispiel**
**Die Ausgabe von Aspose.Slides** 

![todo:image_alt_text](create-a-new-presentation_2.png)
```c#
//Eine Präsentation erstellen
Presentation pres = new Presentation();

//Titelfolie hinzufügen
ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);


//Titeltext festlegen
((IAutoShape)slide.Shapes[0]).TextFrame.Text = "Slide Title Heading";

//Untertitel festlegen
((IAutoShape)slide.Shapes[1]).TextFrame.Text = "Slide Title Sub-Heading";

//Ausgabe auf Festplatte schreiben
pres.Save("c:\\data\\outAsposeSlides.pptx", SaveFormat.Ppt);
```
