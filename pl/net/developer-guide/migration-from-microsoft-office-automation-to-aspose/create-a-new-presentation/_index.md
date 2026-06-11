---
title: Utwórz nowe prezentacje przy użyciu VSTO i Aspose.Slides dla .NET
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
description: "Migracja z automatyzacji Microsoft Office do Aspose.Slides dla .NET i tworzenie nowych prezentacji PowerPoint (PPT, PPTX) w C# przy użyciu czystego, niezawodnego kodu."
---
{{% alert color="primary" %}} 

VSTO zostało opracowane, aby umożliwić programistom tworzenie aplikacji działających wewnątrz Microsoft Office. VSTO jest oparte na COM, ale jest opakowane w obiekt .NET, aby mogło być używane w aplikacjach .NET. VSTO wymaga wsparcia .NET Framework oraz środowiska uruchomieniowego Microsoft Office opartego na CLR. Chociaż może być używane do tworzenia dodatków Microsoft Office, prawie niemożliwe jest użycie go jako komponentu po stronie serwera. Ma też poważne problemy z wdrożeniem.

Aspose.Slides for .NET jest komponentem, który może być używany do manipulacji prezentacjami Microsoft PowerPoint, podobnie jak VSTO, ale posiada kilka zalet:

- Aspose.Slides zawiera wyłącznie kod zarządzany i nie wymaga instalacji środowiska uruchomieniowego Microsoft Office.
- Może być używany jako komponent po stronie klienta lub po stronie serwera.
- Wdrożenie jest proste, ponieważ Aspose.Slides jest zawarte w jednym pliku DLL.

{{% /alert %}} 
## **Tworzenie prezentacji**
Poniżej znajdują się dwa przykłady kodu, które ilustrują, jak VSTO i Aspose.Slides for .NET mogą być użyte do osiągnięcia tego samego celu. Pierwszy przykład to [VSTO](/slides/pl/net/create-a-new-presentation/); [drugi przykład](/slides/pl/net/create-a-new-presentation/) używa Aspose.Slides.
### **Przykład VSTO**
**Wyjście VSTO** 

![todo:image_alt_text](create-a-new-presentation_1.png)



```c#
//Uwaga: PowerPoint jest przestrzenią nazw, która została zdefiniowana powyżej w ten sposób
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//Utwórz prezentację
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Pobierz układ slajdu tytułowego
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[PowerPoint.PpSlideLayout.ppLayoutTitle];

//Dodaj slajd tytułowy.
PowerPoint.Slide slide = pres.Slides.AddSlide(1, layout);

//Ustaw tekst tytułu
slide.Shapes.Title.TextFrame.TextRange.Text = "Slide Title Heading";

//Ustaw tekst podtytułu
slide.Shapes[2].TextFrame.TextRange.Text = "Slide Title Sub-Heading";

//Zapisz wynik na dysku
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **Przykład Aspose.Slides for .NET**
**Wyjście z Aspose.Slides** 

![todo:image_alt_text](create-a-new-presentation_2.png)



```c#
//Utwórz prezentację
Presentation pres = new Presentation();

//Dodaj slajd tytułowy
ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);


//Ustaw tekst tytułu
((IAutoShape)slide.Shapes[0]).TextFrame.Text = "Slide Title Heading";

//Ustaw tekst podtytułu
((IAutoShape)slide.Shapes[1]).TextFrame.Text = "Slide Title Sub-Heading";

//Zapisz wynik na dysku
pres.Save("c:\\data\\outAsposeSlides.pptx", SaveFormat.Ppt);
```