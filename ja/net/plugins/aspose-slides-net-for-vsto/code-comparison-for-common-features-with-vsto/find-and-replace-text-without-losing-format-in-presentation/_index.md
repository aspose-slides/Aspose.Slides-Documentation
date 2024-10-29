---
title: プレゼンテーションでフォーマットを失わずにテキストを検索および置換する
type: docs
weight: 100
url: /ja/net/find-and-replace-text-without-losing-format-in-presentation/
---

両方の方法は以下の手順に従います：

- プレゼンテーションを開く。
- テキストを検索する。
- テキストを置換する。
- プレゼンテーションを書き込む。
## **VSTO**
``` csharp

 private void findReplaceText(string strToFind, string strToReplaceWith)

{

//プレゼンテーションを開く

PowerPoint.Presentation pres = null;

pres = Globals.ThisAddIn.Application.Presentations.Open("mytextone.ppt",

						  Microsoft.Office.Core.MsoTriState.msoFalse,

						  Microsoft.Office.Core.MsoTriState.msoFalse,

						  Microsoft.Office.Core.MsoTriState.msoFalse);

//スライドをループする

foreach (PowerPoint.Slide sld in pres.Slides)

	//スライド内のすべてのシェイプをループする

	foreach (PowerPoint.Shape shp in sld.Shapes)

	{

		//シェイプ内のテキストにアクセスする

		string str = shp.TextFrame.TextRange.Text;

		//置換するテキストを見つける

		if (str.Contains(strToFind))

		//既存のテキストを新しいテキストで置換する

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

	//プレゼンテーションを開く

	Presentation pres = new Presentation("mytextone.ppt");

	//プレゼンテーション内のすべてのテキストボックスを取得する

	ITextBox[] tb = PresentationScanner.GetAllTextBoxes(pres, false);

	for (int i = 0; i < tb.Length; i++)

		foreach (Paragraph para in tb[i].Paragraphs)

			foreach (Portion port in para.Portions)

				//置換するテキストを見つける

				if (port.Text.Contains(strToFind))

				//既存のテキストを新しいテキストで置換する

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
## **サンプルコードをダウンロード**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/772952)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Find.and.Replace.Text.without.Losing.Format.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Find%20and%20Replace%20Text%20without%20Losing%20Format%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Find%20and%20Replace%20Text%20without%20Losing%20Format%20\(Aspose.Slides\).zip)