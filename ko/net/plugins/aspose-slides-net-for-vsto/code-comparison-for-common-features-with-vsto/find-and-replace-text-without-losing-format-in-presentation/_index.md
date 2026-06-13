---
title: 프레젠테이션에서 형식 손실 없이 텍스트 찾기 및 교체
type: docs
weight: 100
url: /ko/net/find-and-replace-text-without-losing-format-in-presentation/
---
두 메서드는 다음 절차를 따릅니다:

- 프레젠테이션을 엽니다.
- 텍스트를 검색합니다.
- 텍스트를 교체합니다.
- 프레젠테이션을 작성합니다.
## **VSTO**
```csharp

 private void findReplaceText(string strToFind, string strToReplaceWith)

{

//프레젠테이션을 엽니다
PowerPoint.Presentation pres = null;

pres = Globals.ThisAddIn.Application.Presentations.Open("mytextone.ppt",
						  Microsoft.Office.Core.MsoTriState.msoFalse,
						  Microsoft.Office.Core.MsoTriState.msoFalse,
						  Microsoft.Office.Core.MsoTriState.msoFalse);

//슬라이드를 순회합니다
foreach (PowerPoint.Slide sld in pres.Slides)
	//슬라이드의 모든 도형을 순회합니다
	foreach (PowerPoint.Shape shp in sld.Shapes)
	{
		//도형의 텍스트에 접근합니다
		string str = shp.TextFrame.TextRange.Text;
		//교체할 텍스트를 찾습니다
		if (str.Contains(strToFind))
		//기존 텍스트를 새 텍스트로 교체합니다
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
```csharp

 private static void findReplaceText(string strToFind, string strToReplaceWith)

{

	//프레젠테이션을 엽니다
	Presentation pres = new Presentation("mytextone.ppt");

	//프레젠테이션의 모든 텍스트 상자를 가져옵니다
	ITextBox[] tb = PresentationScanner.GetAllTextBoxes(pres, false);

	for (int i = 0; i < tb.Length; i++)

		foreach (Paragraph para in tb[i].Paragraphs)

			foreach (Portion port in para.Portions)

				//교체할 텍스트를 찾습니다
				if (port.Text.Contains(strToFind))

				//기존 텍스트를 새 텍스트로 교체합니다
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