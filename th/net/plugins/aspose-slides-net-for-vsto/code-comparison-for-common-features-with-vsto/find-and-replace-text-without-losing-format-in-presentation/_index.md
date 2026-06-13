---
title: ค้นหาและแทนที่ข้อความโดยไม่สูญเสียรูปแบบในการนำเสนอ
type: docs
weight: 100
url: /th/net/find-and-replace-text-without-losing-format-in-presentation/
---
วิธีทั้งสองทำตามขั้นตอนต่อไปนี้:

- เปิดการนำเสนอ.
- ค้นหาข้อความ.
- แทนที่ข้อความ.
- บันทึกการนำเสนอ.
## **VSTO**
``` csharp

 private void findReplaceText(string strToFind, string strToReplaceWith)

{

//เปิดการนำเสนอ
PowerPoint.Presentation pres = null;

pres = Globals.ThisAddIn.Application.Presentations.Open("mytextone.ppt",

						  Microsoft.Office.Core.MsoTriState.msoFalse,

						  Microsoft.Office.Core.MsoTriState.msoFalse,

						  Microsoft.Office.Core.MsoTriState.msoFalse);

//วนลูปผ่านสไลด์
foreach (PowerPoint.Slide sld in pres.Slides)

	//วนลูปผ่านรูปร่างทั้งหมดในสไลด์
	foreach (PowerPoint.Shape shp in sld.Shapes)

	{

		//เข้าถึงข้อความในรูปร่าง
		string str = shp.TextFrame.TextRange.Text;

		//ค้นหาข้อความที่ต้องแทนที่
		if (str.Contains(strToFind))

		//แทนที่ข้อความเดิมด้วยข้อความใหม่
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

	//เปิดการนำเสนอ
	Presentation pres = new Presentation("mytextone.ppt");

	//รับกล่องข้อความทั้งหมดในงานนำเสนอ
	ITextBox[] tb = PresentationScanner.GetAllTextBoxes(pres, false);

	for (int i = 0; i < tb.Length; i++)

		foreach (Paragraph para in tb[i].Paragraphs)

			foreach (Portion port in para.Portions)

				//ค้นหาข้อความที่ต้องแทนที่
				if (port.Text.Contains(strToFind))

				//แทนที่ข้อความเดิมด้วยข้อความใหม่
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
## **ดาวน์โหลดตัวอย่างโค้ด**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Find.and.Replace.Text.without.Losing.Format.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Find%20and%20Replace%20Text%20without%20Losing%20Format%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Find%20and%20Replace%20Text%20without%20Losing%20Format/)