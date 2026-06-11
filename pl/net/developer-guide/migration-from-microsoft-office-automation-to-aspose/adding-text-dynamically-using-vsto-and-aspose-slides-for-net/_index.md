---
title: Dynamiczne dodawanie tekstu przy użyciu VSTO i Aspose.Slides dla .NET
linktitle: Dynamiczne dodawanie tekstu
type: docs
weight: 20
url: /pl/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/
keywords:
- dodawanie tekstu
- migracja
- VSTO
- automatyzacja Office
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Zobacz, jak migrować z automatyzacji Microsoft Office do Aspose.Slides dla .NET oraz dodawać dynamiczny tekst do prezentacji PowerPoint (PPT, PPTX) w języku C#."
---
{{% alert color="primary" %}} 

Typowym zadaniem, które programiści muszą wykonać, jest dynamiczne dodawanie tekstu do slajdów. Ten artykuł pokazuje przykłady kodu dodającego tekst dynamicznie przy użyciu [VSTO](/slides/pl/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/) i [Aspose.Slides for .NET](/slides/pl/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/).

{{% /alert %}} 
## **Dynamiczne dodawanie tekstu**
Obie metody wykonują następujące kroki:

1. Utwórz prezentację.
1. Dodaj pusty slajd.
1. Dodaj pole tekstowe.
1. Ustaw tekst.
1. Zapisz prezentację.
## **Przykład kodu VSTO**
Poniższe fragmenty kodu tworzą prezentację z pustym slajdem i ciągiem tekstu.

**Prezentacja utworzona w VSTO** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_1.png)

```c#
//Uwaga: PowerPoint jest przestrzenią nazw, która została zdefiniowana powyżej w następujący sposób
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//Utwórz prezentację
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Pobierz układ pustego slajdu
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[7];

//Dodaj pusty slajd
PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);

//Dodaj tekst
PowerPoint.Shape shp = sld.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 150, 100, 400, 100);

//Ustaw tekst
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Text = "Text added dynamically";
txtRange.Font.Name = "Arial";
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;
txtRange.Font.Size = 32;

//Zapisz wynik na dysk
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);

```



## **Przykład Aspose.Slides dla .NET**
Poniższe fragmenty kodu używają Aspose.Slides do utworzenia prezentacji z pustym slajdem i ciągiem tekstu.

**Prezentacja utworzona przy użyciu Aspose.Slides dla .NET** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_2.png)

```c#
//Utwórz prezentację
Presentation pres = new Presentation();

//Pusty slajd jest dodawany domyślnie, gdy tworzysz
//prezentację z domyślnego konstruktora
//Dlatego nie musimy dodawać żadnego pustego slajdu
ISlide sld = pres.Slides[1];

//Dodaj pole tekstowe
//Aby to zrobić, najpierw dodamy prostokąt
IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 1200, 800, 3200, 370);

//Ukryj jego linię
shp.LineFormat.Style = LineStyle.NotDefined;

//Następnie dodaj ramkę tekstową wewnątrz niego
ITextFrame tf = ((IAutoShape)shp).TextFrame;

//Ustaw tekst
tf.Text = "Text added dynamically";
IPortion port = tf.Paragraphs[0].Portions[0];

port.PortionFormat.FontBold = NullableBool.True;
port.PortionFormat.FontHeight = 32;

//Zapisz wynik na dysku
pres.Save("c:\\outAspose.ppt", SaveFormat.Ppt);
```