---
title: Find and Replace Text without Losing Format in Presentation
type: docs
weight: 100
url: /net/find-and-replace-text-without-losing-format-in-presentation/
---

Both methods follow these steps:

- Open a presentation.
- Search the text.
- Replace the text.
- Write the presentation.
## **VSTO**
``` csharp

 private void findReplaceText(string strToFind, string strToReplaceWith)

{

//Open the presentation

PowerPoint.Presentation pres = null;

pres = Globals.ThisAddIn.Application.Presentations.Open("mytextone.ppt",

						  Microsoft.Office.Core.MsoTriState.msoFalse,

						  Microsoft.Office.Core.MsoTriState.msoFalse,

						  Microsoft.Office.Core.MsoTriState.msoFalse);

//Loop through slides

foreach (PowerPoint.Slide sld in pres.Slides)

	//Loop through all shapes in slide

	foreach (PowerPoint.Shape shp in sld.Shapes)

	{

		//Access text in the shape

		string str = shp.TextFrame.TextRange.Text;

		//Find text to replace

		if (str.Contains(strToFind))

		//Replace exisitng text with the new text

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
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

static void findReplaceText(string strToFind, string strToReplaceWith)
{
	//Open the presentation
	using Presentation pres = new Presentation("mytextone.ppt");

	//Get all text frames in the presentation
	ITextFrame[] textFrames = SlideUtil.GetAllTextFrames(pres, false);

	for (int i = 0; i < textFrames.Length; i++)
		foreach (IParagraph para in textFrames[i].Paragraphs)
			foreach (IPortion port in para.Portions)
			{
				string str = port.Text;
				int idx = str.IndexOf(strToFind);

				//Find text to be replaced
				if (idx >= 0)
				//Replace exisitng text with the new text, the portion formatting is kept
				{
					string strStartText = str.Substring(0, idx);
					string strEndText = str.Substring(idx + strToFind.Length);
					port.Text = strStartText + strToReplaceWith + strEndText;
				}
			}

	pres.Save("myTextOneAspose.ppt", SaveFormat.Ppt);
}
``` 
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Find.and.Replace.Text.without.Losing.Format.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Find%20and%20Replace%20Text%20without%20Losing%20Format%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Find%20and%20Replace%20Text%20without%20Losing%20Format/)
