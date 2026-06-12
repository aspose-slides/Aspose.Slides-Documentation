---
title: Formátování textu pomocí VSTO a Aspose.Slides pro .NET
linktitle: Formátování textu
type: docs
weight: 30
url: /cs/net/format-text-using-vsto-and-aspose-slides-and-net/
keywords:
- formátovat text
- migrace
- VSTO
- automatizace Office
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Přechod z automatizace Microsoft Office na Aspose.Slides pro .NET a formátování textu v prezentacích PowerPoint (PPT, PPTX) s přesnou kontrolou."
---
{{% alert color="primary" %}} 

Někdy potřebujete programově formátovat text na snímcích. Tento článek ukazuje, jak načíst ukázkovou prezentaci s textem na první snímku pomocí buď [VSTO](/slides/cs/net/format-text-using-vsto-and-aspose-slides-and-net/) a [Aspose.Slides pro .NET](/slides/cs/net/format-text-using-vsto-and-aspose-slides-and-net/). Kód formátuje text ve třetím textovém poli na snímku tak, aby vypadal jako text v posledním textovém poli.

{{% /alert %}} 
## **Formátování textu**
Metody VSTO i Aspose.Slides provádějí následující kroky:

1. Otevřete zdrojovou prezentaci.
1. Získejte první snímek.
1. Získejte třetí textové pole.
1. Změňte formátování textu ve třetím textovém poli.
1. Uložte prezentaci na disk.

Níže uvedené snímky ukazují ukázkový snímek před a po provedení kódu VSTO a Aspose.Slides pro .NET.

**Vstupní prezentace** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_1.png)
### **Příklad kódu VSTO**
Kód níže ukazuje, jak přeformátovat text na snímku pomocí VSTO.

**Text přeformátovaný pomocí VSTO** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_2.png)



```c#
//Poznámka: PowerPoint je jmenný prostor, který byl výše definován takto
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;
PowerPoint.Presentation pres = null;

//Otevřít prezentaci
pres = Globals.ThisAddIn.Application.Presentations.Open("c:\\source.ppt",
    Microsoft.Office.Core.MsoTriState.msoFalse,
    Microsoft.Office.Core.MsoTriState.msoFalse,
    Microsoft.Office.Core.MsoTriState.msoTrue);

//Přístup k prvnímu snímku
PowerPoint.Slide slide = pres.Slides[1];

//Přístup ke třetímu tvaru
PowerPoint.Shape shp = slide.Shapes[3];

//Změnit písmo textu na Verdana a velikost na 32
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Font.Name = "Verdana";
txtRange.Font.Size = 32;

//Ztučnit
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Nastavit kurzívu
txtRange.Font.Italic = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Změnit barvu textu
txtRange.Font.Color.RGB = 0x00CC3333;

//Změnit barvu pozadí tvaru
shp.Fill.ForeColor.RGB = 0x00FFCCCC;

//Přemístit vodorovně
shp.Left -= 70;

//Zapsat výstup na disk
pres.SaveAs("c:\\outVSTO.ppt",
    PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
    Microsoft.Office.Core.MsoTriState.msoFalse);
```




### **Příklad Aspose.Slides pro .NET**
Pro formátování textu pomocí Aspose.Slides přidejte písmo před formátováním textu.

**Výstupní prezentace vytvořená pomocí Aspose.Slides** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_3.png)



```c#
 //Otevřít prezentaci
Presentation pres = new Presentation("c:\\source.ppt");

//Přístup k prvnímu snímku
ISlide slide = pres.Slides[0];

//Přístup ke třetímu tvaru
IShape shp = slide.Shapes[2];

//Změnit písmo textu na Verdana a výšku na 32
ITextFrame tf = ((IAutoShape)shp).TextFrame;
IParagraph para = tf.Paragraphs[0];
IPortion port = para.Portions[0];
port.PortionFormat.LatinFont = new FontData("Verdana");

port.PortionFormat.FontHeight = 32;

//Ztučnit
port.PortionFormat.FontBold = NullableBool.True;

//Nastavit kurzívu
port.PortionFormat.FontItalic = NullableBool.True;

//Změnit barvu textu
//Nastavit barvu písma
port.PortionFormat.FillFormat.FillType = FillType.Solid;
port.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(0x33, 0x33, 0xCC);

//Změnit barvu pozadí tvaru
shp.FillFormat.FillType = FillType.Solid;
shp.FillFormat.SolidFillColor.Color = Color.FromArgb(0xCC, 0xCC, 0xFF);

//Zapsat výstup na disk
pres.Save("c:\\outAspose.ppt", SaveFormat.Ppt);
```