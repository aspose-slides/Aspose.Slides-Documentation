---
title: Найдите и замените текст без потери формата в презентации
type: docs
weight: 100
url: /ru/net/find-and-replace-text-without-losing-format-in-presentation/
---

Обе метода следуют этим шагам:

- Откройте презентацию.
- Поиск текста.
- Замените текст.
- Сохраните презентацию.
## **VSTO**
``` csharp

 private void findReplaceText(string strToFind, string strToReplaceWith)

{

//Откройте презентацию

PowerPoint.Presentation pres = null;

pres = Globals.ThisAddIn.Application.Presentations.Open("mytextone.ppt",

						  Microsoft.Office.Core.MsoTriState.msoFalse,

						  Microsoft.Office.Core.MsoTriState.msoFalse,

						  Microsoft.Office.Core.MsoTriState.msoFalse);

//Перебор слайдов

foreach (PowerPoint.Slide sld in pres.Slides)

	//Перебор всех фигур на слайде

	foreach (PowerPoint.Shape shp in sld.Shapes)

	{

		//Доступ к тексту в фигуре

		string str = shp.TextFrame.TextRange.Text;

		//Найдите текст для замены

		if (str.Contains(strToFind))

		//Замените существующий текст на новый текст

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

	//Откройте презентацию

	Presentation pres = new Presentation("mytextone.ppt");

	//Получите все текстовые поля в презентации

	ITextBox[] tb = PresentationScanner.GetAllTextBoxes(pres, false);

	for (int i = 0; i < tb.Length; i++)

		foreach (Paragraph para in tb[i].Paragraphs)

			foreach (Portion port in para.Portions)

				//Найдите текст для замены

				if (port.Text.Contains(strToFind))

				//Замените существующий текст на новый текст

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
## **Скачать пример кода**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/772952)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Find.and.Replace.Text.without.Losing.Format.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Find%20and%20Replace%20Text%20without%20Losing%20Format%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Find%20and%20Replace%20Text%20without%20Losing%20Format%20\(Aspose.Slides\).zip)