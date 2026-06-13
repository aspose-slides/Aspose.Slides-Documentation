---
title: प्रेजेंटेशन में फ़ॉर्मेट खोए बिना टेक्स्ट खोजें और बदलें
type: docs
weight: 100
url: /hi/net/find-and-replace-text-without-losing-format-in-presentation/
---
दोनों विधियाँ इन चरणों का पालन करती हैं:

- एक प्रस्तुति खोलें।
- पाठ खोजें।
- पाठ को बदलें।
- प्रस्तुति लिखें।
## **VSTO**
``` csharp

 private void findReplaceText(string strToFind, string strToReplaceWith)

{

//प्रेजेंटेशन खोलें
PowerPoint.Presentation pres = null;

pres = Globals.ThisAddIn.Application.Presentations.Open("mytextone.ppt",

						  Microsoft.Office.Core.MsoTriState.msoFalse,

						  Microsoft.Office.Core.MsoTriState.msoFalse,

						  Microsoft.Office.Core.MsoTriState.msoFalse);

//स्लाइड्स के माध्यम से लूप करें
foreach (PowerPoint.Slide sld in pres.Slides)

	//स्लाइड में सभी शेप्स के माध्यम से लूप करें
	foreach (PowerPoint.Shape shp in sld.Shapes)

	{

		//शेप में टेक्स्ट तक पहुँचें
		string str = shp.TextFrame.TextRange.Text;

		//बदलने के लिए टेक्स्ट खोजें
		if (str.Contains(strToFind))

		//मौजूदा टेक्स्ट को नए टेक्स्ट से बदलें
		{

			int idx = str.IndexOf(strToFind);

			string strStartText = str.Substring(0, idx);

			string strEndText = str.Substring(idx + strToFind.Length, str.Length - 1 - (idx + strToFind.Length - 1));

			shp.TextFrame.TextRange.Text = strStartText + strToReplaceWith + strEndText;

		}

		pres.SaveAs("MyTextOne___.ppt",

		PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

		Microsoft.Office.Core.MsoTriState.msoFalse);

	}
``` 
## **Aspose.Slides**
``` csharp

 private static void findReplaceText(string strToFind, string strToReplaceWith)

{

	//प्रेजेंटेशन खोलें
	Presentation pres = new Presentation("mytextone.ppt");

	//प्रेजेंटेशन में सभी टेक्स्ट बॉक्स प्राप्त करें
	ITextBox[] tb = PresentationScanner.GetAllTextBoxes(pres, false);

	for (int i = 0; i < tb.Length; i++)

		foreach (Paragraph para in tb[i].Paragraphs)

			foreach (Portion port in para.Portions)

				//बदलने के लिए टेक्स्ट खोजें
				if (port.Text.Contains(strToFind))

				//मौजूदा टेक्स्ट को नए टेक्स्ट से बदलें
				{

					string str = port.Text;

					int idx = str.IndexOf(strToFind);

					string strStartText = str.Substring(0, idx);

					string strEndText = str.Substring(idx + strToFind.Length, str.Length - 1 - (idx + strToFind.Length - 1));

					port.Text = strStartText + strToReplaceWith + strEndText;

				}

	pres.Write("myTextOneAspose.ppt");

}
``` 
## **नमूना कोड डाउनलोड करें**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Find.and.Replace.Text.without.Losing.Format.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Find%20and%20Replace%20Text%20without%20Losing%20Format%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Find%20and%20Replace%20Text%20without%20Losing%20Format/)