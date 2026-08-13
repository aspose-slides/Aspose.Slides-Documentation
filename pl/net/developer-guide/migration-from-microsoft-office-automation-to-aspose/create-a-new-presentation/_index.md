---
title: Tworzenie nowych prezentacji przy użyciu VSTO i Aspose.Slides dla .NET
linktitle: Utwórz nową prezentację
type: docs
weight: 10
url: /pl/net/create-a-new-presentation/
keywords:
- tworzenie prezentacji
- nowa prezentacja
- migracja
- VSTO
- automatyzacja Office
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Migracja z automatyzacji Microsoft Office do Aspose.Slides dla .NET oraz tworzenie nowych prezentacji PowerPoint (PPT, PPTX) w C# przy użyciu czystego, niezawodnego kodu."
---
{{% alert color="info" %}}

VSTO zostało opracowane, aby umożliwić programistom tworzenie aplikacji działających wewnątrz Microsoft Office. VSTO jest oparte na COM, ale jest opakowane w obiekt .NET, dzięki czemu może być używane w aplikacjach .NET. VSTO wymaga wsparcia .NET Framework oraz środowiska uruchomieniowego CLR Microsoft Office. Chociaż może być używane do tworzenia dodatków do Microsoft Office, prawie niemożliwe jest jego użycie jako komponentu po stronie serwera. Ma również poważne problemy z wdrażaniem.

Aspose.Slides for .NET jest komponentem, który może służyć do manipulacji prezentacjami Microsoft PowerPoint, tak jak VSTO, ale posiada kilka zalet:

- Aspose.Slides zawiera wyłącznie kod zarządzany i nie wymaga instalacji środowiska uruchomieniowego Microsoft Office.
- Może być używany jako komponent po stronie klienta lub po stronie serwera.
- Wdrażanie jest proste, ponieważ Aspose.Slides jest zawarte w jednym pliku DLL.

{{% /alert %}} 
## **Tworzenie prezentacji**
Poniżej znajdują się dwa przykłady kodu, które ilustrują, jak VSTO i Aspose.Slides for .NET mogą być użyte do osiągnięcia tego samego celu. Pierwszy przykład to [VSTO](/slides/pl/net/create-a-new-presentation/); [drugi przykład](/slides/pl/net/create-a-new-presentation/) używa Aspose.Slides.
### **Przykład VSTO**
**Wyjście VSTO** 

![todo:image_alt_text](create-a-new-presentation_1.png)



```c#
//Uwaga: PowerPoint jest przestrzenią nazw, która została zdefiniowana powyżej w następujący sposób
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//Utwórz prezentację
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


### **Przykład Aspose.Slides for .NET**
**Wyjście z Aspose.Slides** 

![todo:image_alt_text](create-a-new-presentation_2.png)



```c#
using Aspose.Slides;
using Aspose.Slides.Export;

//Utwórz prezentację
Presentation pres = new Presentation();

//Dodaj slajd tytułowy
ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);


//Ustaw tekst tytułu
((IAutoShape)slide.Shapes[0]).TextFrame.Text = "Slide Title Heading";

//Ustaw tekst podtytułu
((IAutoShape)slide.Shapes[1]).TextFrame.Text = "Slide Title Sub-Heading";

//Zapisz wynik na dysku
pres.Save("outAsposeSlides.pptx", SaveFormat.Ppt);
```