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
description: "Migracja z automatyzacji Microsoft Office do Aspose.Slides dla .NET oraz formatowanie tekstu w prezentacjach PowerPoint (PPT, PPTX) z precyzyjną kontrolą."
---
{{% alert color="primary" %}} 

Czasami musisz programowo formatować tekst na slajdach. Ten artykuł pokazuje, jak odczytać przykładową prezentację z tekstem na pierwszym slajdzie, używając [VSTO](/slides/pl/net/format-text-using-vsto-and-aspose-slides-and-net/) oraz [Aspose.Slides for .NET](/slides/pl/net/format-text-using-vsto-and-aspose-slides-and-net/). Kod formatuje tekst w trzecim polu tekstowym na slajdzie, aby wyglądał jak tekst w ostatnim polu tekstowym.

{{% /alert %}} 
## **Formatowanie tekstu**
Metody VSTO i Aspose.Slides wykonują następujące kroki:

1. Otwórz źródłową prezentację.
1. Uzyskaj dostęp do pierwszego slajdu.
1. Uzyskaj dostęp do trzeciego pola tekstowego.
1. Zmień formatowanie tekstu w trzecim polu tekstowym.
1. Zapisz prezentację na dysku.

Zrzuty ekranu poniżej pokazują przykładowy slajd przed i po wykonaniu kodu VSTO oraz Aspose.Slides for .NET.

**Prezentacja wejściowa** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_1.png)
### **Przykład kodu VSTO**
Poniższy kod pokazuje, jak sformatować ponownie tekst na slajdzie przy użyciu VSTO.

**Tekst sformatowany ponownie przy użyciu VSTO** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_2.png)



```c#
//Uwaga: PowerPoint jest przestrzenią nazw, która została zdefiniowana powyżej w następujący sposób
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;
PowerPoint.Presentation pres = null;

//Open the presentation
pres = Globals.ThisAddIn.Application.Presentations.Open("c:\\source.ppt",
	Microsoft.Office.Core.MsoTriState.msoFalse,
	Microsoft.Office.Core.MsoTriState.msoFalse,
	Microsoft.Office.Core.MsoTriState.msoTrue);

//Access the first slide
PowerPoint.Slide slide = pres.Slides[1];

//Access the third shape
PowerPoint.Shape shp = slide.Shapes[3];

//Change its text's font to Verdana and height to 32
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Font.Name = "Verdana";
txtRange.Font.Size = 32;

//Bolden it
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Italicize it
txtRange.Font.Italic = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Change text color
txtRange.Font.Color.RGB = 0x00CC3333;

//Change shape background color
shp.Fill.ForeColor.RGB = 0x00FFCCCC;

//Reposition it horizontally
shp.Left -= 70;

//Write the output to disk
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```




### **Przykład Aspose.Slides for .NET**
Aby sformatować tekst przy użyciu Aspose.Slides, dodaj czcionkę przed formatowaniem tekstu.

**Prezentacja wyjściowa utworzona przy użyciu Aspose.Slides** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_3.png)



```c#
 //Otwórz prezentację
Presentation pres = new Presentation("c:\\source.ppt");

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

//Zastosuj kursywę
port.PortionFormat.FontItalic = NullableBool.True;

//Zmień kolor tekstu
//Ustaw kolor czcionki
port.PortionFormat.FillFormat.FillType = FillType.Solid;
port.PortionFormat.SolidFillColor.Color = Color.FromArgb(0x33, 0x33, 0xCC);

//Zmień kolor tła kształtu
shp.FillFormat.FillType = FillType.Solid;
shp.FillFormat.SolidFillColor.Color = Color.FromArgb(0xCC, 0xCC, 0xFF);

//Zapisz wynik na dysku
pres.Save("c:\\outAspose.ppt", SaveFormat.Ppt);
```