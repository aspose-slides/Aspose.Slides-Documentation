---
title: 在簡報中尋找並取代文字而不失去格式
type: docs
weight: 100
url: /zh-hant/net/find-and-replace-text-without-losing-format-in-presentation/
---
兩種方法遵循以下步驟：

- 開啟簡報。
- 搜尋文字。
- 取代文字。
- 寫入簡報。
## **VSTO**
``` csharp

 private void findReplaceText(string strToFind, string strToReplaceWith)

{

//開啟簡報
PowerPoint.Presentation pres = null;
pres = Globals.ThisAddIn.Application.Presentations.Open("mytextone.ppt",
						  Microsoft.Office.Core.MsoTriState.msoFalse,
						  Microsoft.Office.Core.MsoTriState.msoFalse,
						  Microsoft.Office.Core.MsoTriState.msoFalse);
//遍歷投影片
foreach (PowerPoint.Slide sld in pres.Slides)
	//遍歷投影片中的所有圖形
	foreach (PowerPoint.Shape shp in sld.Shapes)
	{
		//取得圖形中的文字
		string str = shp.TextFrame.TextRange.Text;
		//尋找要取代的文字
		if (str.Contains(strToFind))
		//以新文字取代現有文字
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

	//開啟簡報
	Presentation pres = new Presentation("mytextone.ppt");

	//取得簡報中的所有文字方塊
	ITextBox[] tb = PresentationScanner.GetAllTextBoxes(pres, false);

	for (int i = 0; i < tb.Length; i++)

		foreach (Paragraph para in tb[i].Paragraphs)

			foreach (Portion port in para.Portions)

				//尋找要取代的文字
				if (port.Text.Contains(strToFind))

				//以新文字取代現有文字
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
## **下載範例程式碼**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Find.and.Replace.Text.without.Losing.Format.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Find%20and%20Replace%20Text%20without%20Losing%20Format%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Find%20and%20Replace%20Text%20without%20Losing%20Format/)