---
title: Erstellen einer neuen Präsentation
type: docs
weight: 10
url: /de/net/create-a-new-presentation/
---

{{% alert color="primary" %}} 

VSTO wurde entwickelt, damit Entwickler Anwendungen erstellen können, die innerhalb von Microsoft Office ausgeführt werden können. VSTO basiert auf COM, ist jedoch in ein .NET-Objekt gekapselt, sodass es in .NET-Anwendungen verwendet werden kann. VSTO benötigt Unterstützung des .NET Frameworks sowie eine CLR-basierte Laufzeit von Microsoft Office. Obwohl es zur Erstellung von Microsoft Office-Add-Ins verwendet werden kann, ist es nahezu unmöglich, es als serverseitige Komponente zu verwenden. Es hat auch ernsthafte Bereitstellungsprobleme.

Aspose.Slides für .NET ist eine Komponente, die verwendet werden kann, um Microsoft PowerPoint-Präsentationen zu manipulieren, ähnlich wie VSTO, aber es hat mehrere Vorteile:

- Aspose.Slides enthält nur verwalteten Code und erfordert keine Installation der Microsoft Office-Laufzeit.
- Es kann als clientseitige Komponente oder als serverseitige Komponente verwendet werden.
- Die Bereitstellung ist einfach, da sich Aspose.Slides in einer einzigen DLL befindet.

{{% /alert %}} 
## **Erstellen einer Präsentation**
Im Folgenden finden Sie zwei Codebeispiele, die veranschaulichen, wie VSTO und Aspose.Slides für .NET verwendet werden können, um dasselbe Ziel zu erreichen. Das erste Beispiel ist [VSTO](/slides/de/net/create-a-new-presentation/); [das zweite Beispiel](/slides/de/net/create-a-new-presentation/) verwendet Aspose.Slides.
### **VSTO-Beispiel**
**Die VSTO-Ausgabe** 

![todo:image_alt_text](create-a-new-presentation_1.png)



```c#
//Hinweis: PowerPoint ist ein Namespace, der oben definiert wurde
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//Eine Präsentation erstellen
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Das Layout der Titelfolie abrufen
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[PowerPoint.PpSlideLayout.ppLayoutTitle];

//Eine Titelfolie hinzufügen.
PowerPoint.Slide slide = pres.Slides.AddSlide(1, layout);

//Den Titeltext festlegen
slide.Shapes.Title.TextFrame.TextRange.Text = "Titel der Folie";

//Den Untertiteltext festlegen
slide.Shapes[2].TextFrame.TextRange.Text = "Untertitel der Folie";

//Die Ausgabe auf die Festplatte schreiben
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **Aspose.Slides für .NET Beispiel**
**Die Ausgabe von Aspose.Slides** 

![todo:image_alt_text](create-a-new-presentation_2.png)



```c#
//Eine Präsentation erstellen
Presentation pres = new Presentation();

//Die Titelfolie hinzufügen
ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);


//Den Titeltext festlegen
((IAutoShape)slide.Shapes[0]).TextFrame.Text = "Titel der Folie";

//Den Untertiteltext festlegen
((IAutoShape)slide.Shapes[1]).TextFrame.Text = "Untertitel der Folie";

//Die Ausgabe auf die Festplatte schreiben
pres.Save("c:\\data\\outAsposeSlides.pptx", SaveFormat.Ppt);
```