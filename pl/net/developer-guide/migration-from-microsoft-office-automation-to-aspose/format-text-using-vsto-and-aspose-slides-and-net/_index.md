---
title: Formatowanie tekstu przy użyciu VSTO i Aspose.Slides dla .NET
linktitle: Formatowanie tekstu
type: docs
weight: 30
url: /pl/net/format-text-using-vsto-and-aspose-slides-and-net/
keywords:
- formatowanie tekstu
- migracja
- VSTO
- automatyzacja Office
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Migruj z automatyzacji Microsoft Office do Aspose.Slides dla .NET i formatuj tekst w prezentacjach PowerPoint (PPT, PPTX) z precyzyjną kontrolą."
---
{{% alert color="info" %}} 
Czasami trzeba programowo formatować tekst na slajdach. Ten artykuł pokazuje, jak wczytać przykładową prezentację z tekstem na pierwszym slajdzie przy użyciu [VSTO](/slides/pl/net/format-text-using-vsto-and-aspose-slides-and-net/) oraz [Aspose.Slides for .NET](/slides/pl/net/format-text-using-vsto-and-aspose-slides-and-net/). Kod formatuje tekst w trzecim polu tekstowym na slajdzie, aby wyglądał tak jak tekst w ostatnim polu tekstowym.
{{% /alert %}} 
## **Formatowanie tekstu**
Zarówno metody VSTO, jak i Aspose.Slides wykonują następujące kroki:

1. Otwórz prezentację źródłową.
1. Uzyskaj dostęp do pierwszego slajdu.
1. Uzyskaj dostęp do trzeciego pola tekstowego.
1. Zmień formatowanie tekstu w trzecim polu tekstowym.
1. Zapisz prezentację na dysku.

Zrzuty ekranu poniżej pokazują przykładowy slajd przed i po wykonaniu kodu VSTO oraz Aspose.Slides for .NET.

**Prezentacja wejściowa** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_1.png)
### **Przykład kodu VSTO**
Poniższy kod pokazuje, jak ponownie sformatować tekst na slajdzie przy użyciu VSTO.

**Tekst sformatowany ponownie przy użyciu VSTO** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_2.png)



```c#
//Uwaga: PowerPoint jest przestrzenią nazw, która została zdefiniowana powyżej w następujący sposób
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;
PowerPoint.Presentation pres = null;

//Otwórz prezentację
pres = Globals.ThisAddIn.Application.Presentations.Open("c:\\source.ppt",
	Microsoft.Office.Core.MsoTriState.msoFalse,
	Microsoft.Office.Core.MsoTriState.msoFalse,
	Microsoft.Office.Core.MsoTriState.msoTrue);

//Uzyskaj dostęp do pierwszego slajdu
PowerPoint.Slide slide = pres.Slides[1];

//Uzyskaj dostęp do trzeciego kształtu
PowerPoint.Shape shp = slide.Shapes[3];

//Zmień czcionkę tekstu na Verdana i rozmiar na 32
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Font.Name = "Verdana";
txtRange.Font.Size = 32;

//Pogrub go
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Ustaw kursywę
txtRange.Font.Italic = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Zmień kolor tekstu
txtRange.Font.Color.RGB = 0x00CC3333;

//Zmień kolor tła kształtu
shp.Fill.ForeColor.RGB = 0x00FFCCCC;

//Przesuń go w poziomie
shp.Left -= 70;

//Zapisz wyjście na dysku
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```




### **Przykład Aspose.Slides for .NET**
Aby sformatować tekst przy użyciu Aspose.Slides, dodaj czcionkę przed formatowaniem tekstu.

**Prezentacja wyjściowa utworzona przy użyciu Aspose.Slides** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_3.png)



```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

 //Otwórz prezentację
Presentation pres = new Presentation("source.ppt");

//Uzyskaj dostęp do pierwszego slajdu
ISlide slide = pres.Slides[0];

//Uzyskaj dostęp do trzeciego kształtu
IShape shp = slide.Shapes[2];

//Zmień czcionkę tekstu na Verdana i wysokość na 32
ITextFrame tf = ((IAutoShape)shp).TextFrame;
IParagraph para = tf.Paragraphs[0];
IPortion port = para.Portions[0];
port.PortionFormat.LatinFont = new FontData("Verdana");

port.PortionFormat.FontHeight = 32;

//Pogrub go
port.PortionFormat.FontBold = NullableBool.True;

//Ustaw kursywę
port.PortionFormat.FontItalic = NullableBool.True;

//Zmień kolor tekstu
//Ustaw kolor czcionki
port.PortionFormat.FillFormat.FillType = FillType.Solid;
port.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(0x33, 0x33, 0xCC);

//Zmień kolor tła kształtu
shp.FillFormat.FillType = FillType.Solid;
shp.FillFormat.SolidFillColor.Color = Color.FromArgb(0xCC, 0xCC, 0xFF);

//Zapisz wynik na dysku
pres.Save("outAspose.ppt", SaveFormat.Ppt);
```