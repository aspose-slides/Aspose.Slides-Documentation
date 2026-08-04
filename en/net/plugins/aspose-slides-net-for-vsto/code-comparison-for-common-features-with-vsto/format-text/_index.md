---
title: Format Text
type: docs
weight: 110
url: /net/format-text/
---

Both the VSTO and Aspose.Slides methods take the following steps:

- Open the source presentation.
- Access the first slide.
- Access the third text box.
- Change the formatting of the text in the third text box.
- Save the presentation to disk.
## **VSTO**
``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

//Open the presentation
using (Presentation pres = new Presentation("source.ppt"))
{
    //Access the first slide
    ISlide slide = pres.Slides[0];

    //Access the third shape
    IAutoShape shp = (IAutoShape)slide.Shapes[2];

    //Change its text's font to Verdana and height to 32
    IPortionFormat portionFormat = shp.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
    portionFormat.LatinFont = new FontData("Verdana");
    portionFormat.FontHeight = 32;

    //Bolden it
    portionFormat.FontBold = NullableBool.True;

    //Italicize it
    portionFormat.FontItalic = NullableBool.True;

    //Change text color
    portionFormat.FillFormat.FillType = FillType.Solid;
    portionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(0x33, 0x33, 0xCC);

    //Change shape background color
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.FromArgb(0xCC, 0xCC, 0xFF);

    //Write the output to disk
    pres.Save("outAspose.ppt", SaveFormat.Ppt);
}

``` 
## **Aspose.Slides**
``` csharp

 PowerPoint.Presentation pres = null;

//Open the presentation

pres = Globals.ThisAddIn.Application.Presentations.Open("source.ppt",

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

pres.SaveAs("outVSTO.ppt",

	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	Microsoft.Office.Core.MsoTriState.msoFalse);

``` 
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Format.Text.using.VSTO.and.Aspose.Slides.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Format%20Text%20using%20VSTO%20and%20Aspose.Slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Format%20Text%20using%20VSTO%20and%20Aspose.Slides/)
