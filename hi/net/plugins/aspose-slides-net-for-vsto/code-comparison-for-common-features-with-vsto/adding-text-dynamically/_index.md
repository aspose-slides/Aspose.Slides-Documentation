---
title: पाठ को गतिशील रूप से जोड़ना
type: docs
weight: 40
url: /hi/net/adding-text-dynamically/
---
दोनों विधियाँ इन चरणों का पालन करती हैं:

- एक प्रस्तुति बनाएं।
- एक खाली स्लाइड जोड़ें।
- एक टेक्स्ट बॉक्स जोड़ें।
- कुछ पाठ सेट करें।
- प्रस्तुति लिखें।
## **VSTO**
``` csharp

 private void AddTextBox()

{

	//एक प्रस्तुति बनाएं

	PowerPoint.Presentation pres = Globals.ThisAddIn.Application

		.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

	//रिक्त स्लाइड लेआउट प्राप्त करें

	PowerPoint.CustomLayout layout = pres.SlideMaster.

		CustomLayouts[7];

	//एक खाली स्लाइड जोड़ें

	PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);

	//पाठ जोड़ें

	PowerPoint.Shape shp =sld.Shapes.AddTextbox

	(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal,150, 100, 400, 100);

	//पाठ सेट करें

	PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;

	txtRange.Text = "Text added dynamically";

	txtRange.Font.Name = "Arial";

	txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;

	txtRange.Font.Size = 32;

	//आउटपुट को डिस्क पर लिखें

	pres.SaveAs("outVSTOAddingText.ppt",

		PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

		Microsoft.Office.Core.MsoTriState.msoFalse);

}

``` 
## **Aspose.Slides**
``` csharp

 static void AddTextBox()

{

	//एक प्रस्तुति बनाएं
	Presentation pres = new Presentation();
	//डिफ़ॉल्ट रूप से एक खाली स्लाइड जोड़ दी जाती है, जब आप बनाते हैं
	//डिफ़ॉल्ट कन्स्ट्रक्टर से प्रस्तुति
	//इसलिए, हमें कोई खाली स्लाइड जोड़ने की आवश्यकता नहीं है
	Slide sld = pres.GetSlideByPosition(1);
	//Arial के लिए फ़ॉन्ट इंडेक्स प्राप्त करें
	//यदि आप प्रस्तुति बनाते हैं तो यह हमेशा 0 होता है
	//डिफ़ॉल्ट कन्स्ट्रक्टर
	int arialFontIndex = 0;
	//एक टेक्स्टबॉक्स जोड़ें
	//इसे जोड़ने के लिए, हम पहले एक आयत जोड़ेंगे
	Shape shp = sld.Shapes.AddRectangle(1200, 800, 3200, 370);
	//उसकी रेखा छिपाएँ
	shp.LineFormat.ShowLines = false;
	//फिर इसके भीतर एक टेक्स्टफ़्रेम जोड़ें
	TextFrame tf = shp.AddTextFrame("");
	//पाठ सेट करें
	tf.Text = "Text added dynamically";
	Portion port = tf.Paragraphs[0].Portions[0];
	port.FontIndex = arialFontIndex;
	port.FontBold = true;
	port.FontHeight = 32;
	//आउटपुट को डिस्क पर लिखें
	pres.Write("outAspose.ppt");
}

``` 
## **नमूना कोड डाउनलोड करें**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Adding.Text.Dynamically.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Text%20Dynamically%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Text%20Dynamically%20using%20VSTO%20and%20Aspose.Slides/)