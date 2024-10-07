---
title: البحث واستبدال النص دون فقدان التنسيق في العرض التقديمي
type: docs
weight: 100
url: /net/find-and-replace-text-without-losing-format-in-presentation/
---

تتبع كلا الطريقتين الخطوات التالية:

- افتح العرض التقديمي.
- ابحث عن النص.
- استبدل النص.
- اكتب العرض التقديمي.
## **VSTO**
``` csharp

 private void findReplaceText(string strToFind, string strToReplaceWith)

{

//افتح العرض التقديمي

PowerPoint.Presentation pres = null;

pres = Globals.ThisAddIn.Application.Presentations.Open("mytextone.ppt",

						  Microsoft.Office.Core.MsoTriState.msoFalse,

						  Microsoft.Office.Core.MsoTriState.msoFalse,

						  Microsoft.Office.Core.MsoTriState.msoFalse);

//قم بالتكرار عبر الشرائح

foreach (PowerPoint.Slide sld in pres.Slides)

	//قم بالتكرار عبر جميع الأشكال في الشريحة

	foreach (PowerPoint.Shape shp in sld.Shapes)

	{

		//الوصول إلى النص في الشكل

		string str = shp.TextFrame.TextRange.Text;

		//ابحث عن النص ليتم استبداله

		if (str.Contains(strToFind))

		//استبدل النص الموجود بالنص الجديد

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

	//افتح العرض التقديمي

	Presentation pres = new Presentation("mytextone.ppt");

	//احصل على جميع صناديق النص في العرض التقديمي

	ITextBox[] tb = PresentationScanner.GetAllTextBoxes(pres, false);

	for (int i = 0; i < tb.Length; i++)

		foreach (Paragraph para in tb[i].Paragraphs)

			foreach (Portion port in para.Portions)

				//ابحث عن النص ليتم استبداله

				if (port.Text.Contains(strToFind))

				//استبدل النص الموجود بالنص الجديد

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
## **تحميل الكود المصدر**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/772952)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Find.and.Replace.Text.without.Losing.Format.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Find%20and%20Replace%20Text%20without%20Losing%20Format%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Find%20and%20Replace%20Text%20without%20Losing%20Format%20\(Aspose.Slides\).zip)