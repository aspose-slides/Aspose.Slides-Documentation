---
title: 텍스트 동적으로 추가하기
type: docs
weight: 40
url: /ko/net/adding-text-dynamically/
---
두 메서드는 다음 단계를 따릅니다:

- 프레젠테이션을 생성합니다.
- 빈 슬라이드를 추가합니다.
- 텍스트 상자를 추가합니다.
- 텍스트를 설정합니다.
- 프레젠테이션을 씁니다.
## **VSTO**
``` csharp

 private void AddTextBox()

{

	//프레젠테이션을 생성합니다
	PowerPoint.Presentation pres = Globals.ThisAddIn.Application
		.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);
	//빈 슬라이드 레이아웃을 가져옵니다
	PowerPoint.CustomLayout layout = pres.SlideMaster.
		CustomLayouts[7];
	//빈 슬라이드를 추가합니다
	PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);
	//텍스트를 추가합니다
	PowerPoint.Shape shp =sld.Shapes.AddTextbox
	(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal,150, 100, 400, 100);
	//텍스트를 설정합니다
	PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
	txtRange.Text = "Text added dynamically";
	txtRange.Font.Name = "Arial";
	txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;
	txtRange.Font.Size = 32;
	//출력을 디스크에 저장합니다
	pres.SaveAs("outVSTOAddingText.ppt",
		PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
		Microsoft.Office.Core.MsoTriState.msoFalse);
}

``` 
## **Aspose.Slides**
``` csharp

 static void AddTextBox()

{

	//프레젠테이션을 생성합니다
	Presentation pres = new Presentation();

	//빈 슬라이드는 기본적으로 추가되며, 생성할 때
	//기본 생성자를 사용한 프레젠테이션
	//따라서 빈 슬라이드를 추가할 필요가 없습니다
	Slide sld = pres.GetSlideByPosition(1);

	//Arial 글꼴 인덱스를 가져옵니다
	//프레젠테이션을 생성하면 항상 0입니다
	//기본 생성자
	int arialFontIndex = 0;

	//텍스트 상자를 추가합니다
	//추가하려면 먼저 사각형을 추가합니다
	Shape shp = sld.Shapes.AddRectangle(1200, 800, 3200, 370);

	//라인을 숨깁니다
	shp.LineFormat.ShowLines = false;

	//그 안에 텍스트 프레임을 추가합니다
	TextFrame tf = shp.AddTextFrame("");

	//텍스트를 설정합니다
	tf.Text = "Text added dynamically";

	Portion port = tf.Paragraphs[0].Portions[0];

	port.FontIndex = arialFontIndex;

	port.FontBold = true;

	port.FontHeight = 32;

	//출력을 디스크에 저장합니다
	pres.Write("outAspose.ppt");

}

``` 
## **샘플 코드 다운로드**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Adding.Text.Dynamically.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Text%20Dynamically%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Text%20Dynamically%20using%20VSTO%20and%20Aspose.Slides/)