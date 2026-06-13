---
title: یافتن و جایگزینی متن بدون از دست دادن قالب در ارائه
type: docs
weight: 100
url: /fa/net/find-and-replace-text-without-losing-format-in-presentation/
---
هر دو روش این مراحل را دنبال می‌کنند:

- یک ارائه را باز کنید.
- متن را جستجو کنید.
- متن را جایگزین کنید.
- ارائه را بنویسید.
## **VSTO**
``` csharp

 private void findReplaceText(string strToFind, string strToReplaceWith)

{

//ارائه را باز کنید
PowerPoint.Presentation pres = null;

pres = Globals.ThisAddIn.Application.Presentations.Open("mytextone.ppt",

						  Microsoft.Office.Core.MsoTriState.msoFalse,

						  Microsoft.Office.Core.MsoTriState.msoFalse,

						  Microsoft.Office.Core.MsoTriState.msoFalse);

//اسلایدها را پیمایش کنید
foreach (PowerPoint.Slide sld in pres.Slides)

	//تمام اشکال موجود در اسلاید را پیمایش کنید
	foreach (PowerPoint.Shape shp in sld.Shapes)

	{

		//دسترسی به متن در شکل
		string str = shp.TextFrame.TextRange.Text;

		//متن برای جایگزینی را پیدا کنید
		if (str.Contains(strToFind))

		//متن موجود را با متن جدید جایگزین کنید
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

	//ارائه را باز کنید
	Presentation pres = new Presentation("mytextone.ppt");

	//دریافت همه جعبه‌های متن در ارائه
	ITextBox[] tb = PresentationScanner.GetAllTextBoxes(pres, false);

	for (int i = 0; i < tb.Length; i++)

		foreach (Paragraph para in tb[i].Paragraphs)

			foreach (Portion port in para.Portions)

				//متن برای جایگزینی را پیدا کنید
				if (port.Text.Contains(strToFind))

				//متن موجود را با متن جدید جایگزین کنید
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
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Find.and.Replace.Text.without.Losing.Format.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Find%20and%20Replace%20Text%20without%20Losing%20Format%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Find%20and%20Replace%20Text%20without%20Losing%20Format/)