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
description: "Migrieren Sie von Microsoft Office-Automatisierung zu Aspose.Slides für .NET und erstellen Sie neue PowerPoint (PPT, PPTX) Präsentationen in C# mit sauberem, zuverlässigem Code."
---

{{% alert color="primary" %}} 
VSTO wurde entwickelt, um Entwicklern zu ermöglichen, Anwendungen zu erstellen, die innerhalb von Microsoft Office ausgeführt werden können. VSTO ist COM-basiert, wird aber in ein .NET-Objekt eingekapselt, sodass es in .NET-Anwendungen verwendet werden kann. VSTO benötigt Unterstützung des .NET Frameworks sowie die CLR-basierte Laufzeit von Microsoft Office. Obwohl es für die Erstellung von Microsoft Office-Add‑Ins verwendet werden kann, ist es nahezu unmöglich, es als serverseitige Komponente zu nutzen. Es hat zudem ernsthafte Bereitstellungsprobleme.

Aspose.Slides for .NET ist eine Komponente, die zum Manipulieren von Microsoft PowerPoint‑Präsentationen verwendet werden kann, genau wie VSTO, bietet jedoch mehrere Vorteile:

- Aspose.Slides enthält ausschließlich verwalteten Code und erfordert nicht, dass die Microsoft Office‑Laufzeit installiert ist.
- Sie kann als clientseitige Komponente oder als serverseitige Komponente verwendet werden.
- Die Bereitstellung ist einfach, da Aspose.Slides in einer einzigen DLL enthalten ist.

{{% /alert %}} 
## **Erstellen einer Präsentation**
Im Folgenden finden Sie zwei Codebeispiele, die zeigen, wie VSTO und Aspose.Slides for .NET verwendet werden können, um dasselbe Ziel zu erreichen. Das erste Beispiel ist [VSTO](/slides/de/net/create-a-new-presentation/); [das zweite Beispiel](/slides/de/net/create-a-new-presentation/) verwendet Aspose.Slides.
### **VSTO‑Beispiel**
**Die VSTO‑Ausgabe** 

![todo:image_alt_text](create-a-new-presentation_1.png)
```c#
//Hinweis: PowerPoint ist ein Namespace, der oben wie folgt definiert wurde
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//Erstelle eine Präsentation
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Hole das Layout der Titelfolie
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[PowerPoint.PpSlideLayout.ppLayoutTitle];

//Füge eine Titelfolie hinzu.
PowerPoint.Slide slide = pres.Slides.AddSlide(1, layout);

//Setze den Titeltext
slide.Shapes.Title.TextFrame.TextRange.Text = "Slide Title Heading";

//Setze den Untertiteltext
slide.Shapes[2].TextFrame.TextRange.Text = "Slide Title Sub-Heading";

//Schreibe die Ausgabe auf die Festplatte
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **Aspose.Slides for .NET Beispiel**
**Die Ausgabe von Aspose.Slides** 

![todo:image_alt_text](create-a-new-presentation_2.png)
```c#
//Erstelle eine Präsentation
Presentation pres = new Presentation();

//Füge die Titelfolie hinzu
ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);


//Setze den Titeltext
((IAutoShape)slide.Shapes[0]).TextFrame.Text = "Slide Title Heading";

//Setze den Untertiteltext
((IAutoShape)slide.Shapes[1]).TextFrame.Text = "Slide Title Sub-Heading";

//Schreibe die Ausgabe auf die Festplatte
pres.Save("c:\\data\\outAsposeSlides.pptx", SaveFormat.Ppt);
```
