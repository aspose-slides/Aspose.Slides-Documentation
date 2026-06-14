---
title: Tìm và Thay Thế Văn Bản mà Không Mất Định Dạng trong Bài Thuyết Trình
type: docs
weight: 100
url: /vi/net/find-and-replace-text-without-losing-format-in-presentation/
---
Cả hai phương pháp đều thực hiện các bước sau:

- Mở bài thuyết trình.
- Tìm kiếm văn bản.
- Thay thế văn bản.
- Lưu lại bài thuyết trình.
## **VSTO**
``` csharp

 private void findReplaceText(string strToFind, string strToReplaceWith)

{

//Mở bài thuyết trình
PowerPoint.Presentation pres = null;

pres = Globals.ThisAddIn.Application.Presentations.Open("mytextone.ppt",

						  Microsoft.Office.Core.MsoTriState.msoFalse,

						  Microsoft.Office.Core.MsoTriState.msoFalse,

						  Microsoft.Office.Core.MsoTriState.msoFalse);

//Duyệt qua các slide
foreach (PowerPoint.Slide sld in pres.Slides)

	//Duyệt qua tất cả các hình trong slide
	foreach (PowerPoint.Shape shp in sld.Shapes)

	{

		//Truy cập văn bản trong hình
		string str = shp.TextFrame.TextRange.Text;

		//Tìm văn bản cần thay thế
		if (str.Contains(strToFind))

		//Thay thế văn bản hiện có bằng văn bản mới
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

	//Mở bài thuyết trình
	Presentation pres = new Presentation("mytextone.ppt");

	//Lấy tất cả các hộp văn bản trong bài thuyết trình
	ITextBox[] tb = PresentationScanner.GetAllTextBoxes(pres, false);

	for (int i = 0; i < tb.Length; i++)

		foreach (Paragraph para in tb[i].Paragraphs)

			foreach (Portion port in para.Portions)

				//Tìm văn bản cần thay thế
				if (port.Text.Contains(strToFind))

				//Thay thế văn bản hiện có bằng văn bản mới
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
## **Tải Mã Mẫu**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Find.and.Replace.Text.without.Losing.Format.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Find%20and%20Replace%20Text%20without%20Losing%20Format%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Find%20and%20Replace%20Text%20without%20Losing%20Format/)