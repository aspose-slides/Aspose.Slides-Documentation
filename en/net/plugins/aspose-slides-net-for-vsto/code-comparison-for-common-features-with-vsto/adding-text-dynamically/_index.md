---
title: Adding Text Dynamically
type: docs
weight: 40
url: /net/adding-text-dynamically/
---

Both methods follow these steps:

- Create a presentation.
- Add a blank slide.
- Add a text box.
- Set some text.
- Write the presentation.
## **VSTO**
``` csharp

 private void AddTextBox()

{

	//Create a presentation

	PowerPoint.Presentation pres = Globals.ThisAddIn.Application

		.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

	//Get the blank slide layout

	PowerPoint.CustomLayout layout = pres.SlideMaster.

		CustomLayouts[7];

	//Add a blank slide

	PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);

	//Add a text

	PowerPoint.Shape shp =sld.Shapes.AddTextbox

	(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal,150, 100, 400, 100);

	//Set a text

	PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;

	txtRange.Text = "Text added dynamically";

	txtRange.Font.Name = "Arial";

	txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;

	txtRange.Font.Size = 32;

	//Write the output to disk

	pres.SaveAs("outVSTOAddingText.ppt",

		PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

		Microsoft.Office.Core.MsoTriState.msoFalse);

}

``` 
## **Aspose.Slides**
``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

static void AddTextBox()
{
	//Create a presentation
	//Blank slide is added by default, when you create
	//presentation from default constructor
	//So, we don't need to add any blank slide
	using (Presentation pres = new Presentation())
	{
		ISlide sld = pres.Slides[0];

		//Add a textbox
		//To add it, we will first add a rectangle
		IAutoShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 100, 400, 100);

		//Hide its line
		shp.LineFormat.FillFormat.FillType = FillType.NoFill;

		//Then add a textframe inside it
		ITextFrame tf = shp.AddTextFrame("");

		//Set a text
		tf.Text = "Text added dynamically";

		IPortion port = tf.Paragraphs[0].Portions[0];

		port.PortionFormat.LatinFont = new FontData("Arial");
		port.PortionFormat.FontBold = NullableBool.True;
		port.PortionFormat.FontHeight = 32;

		//Write the output to disk
		pres.Save("outAspose.pptx", SaveFormat.Pptx);
	}
}
``` 
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Adding.Text.Dynamically.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Text%20Dynamically%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Text%20Dynamically%20using%20VSTO%20and%20Aspose.Slides/)
