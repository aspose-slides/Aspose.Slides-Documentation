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
### **VSTO**
{{< highlight csharp >}}

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

{{< /highlight >}}
### **Aspose.Slides**
{{< highlight csharp >}}

 static void AddTextBox()

{

	//Create a presentation

	Presentation pres = new Presentation();

	//Blank slide is added by default, when you create

	//presentation from default constructor

	//So, we don't need to add any blank slide

	Slide sld = pres.GetSlideByPosition(1);

	//Get the font index for Arial

	//It is always 0 if you create presentation from

	//default constructor

	int arialFontIndex = 0;

	//Add a textbox

	//To add it, we will first add a rectangle

	Shape shp = sld.Shapes.AddRectangle(1200, 800, 3200, 370);

	//Hide its line

	shp.LineFormat.ShowLines = false;

	//Then add a textframe inside it

	TextFrame tf = shp.AddTextFrame("");

	//Set a text

	tf.Text = "Text added dynamically";

	Portion port = tf.Paragraphs[0].Portions[0];

	port.FontIndex = arialFontIndex;

	port.FontBold = true;

	port.FontHeight = 32;

	//Write the output to disk

	pres.Write("outAspose.ppt");

}

{{< /highlight >}}
## **Download Sample Code**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/772947)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Adding.Text.Dynamically.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Text%20Dynamically%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Adding%20Text%20Dynamically%20\(Aspose.Slides\).zip)
