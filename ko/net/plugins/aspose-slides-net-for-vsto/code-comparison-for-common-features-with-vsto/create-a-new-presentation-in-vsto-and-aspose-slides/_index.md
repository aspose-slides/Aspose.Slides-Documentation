---
title: VSTO 및 Aspose.Slides에서 새 프레젠테이션 만들기
type: docs
weight: 80
url: /ko/net/create-a-new-presentation-in-vsto-and-aspose-slides/
---
아래는 VSTO와 Aspose.Slides for .NET를 사용하여 동일한 목표를 달성하는 두 가지 코드 예제입니다.
## **VSTO**
``` csharp

 private void CreatePresentation()

{

PowerPoint.Presentation pres = Globals.ThisAddIn.Application

	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);
//제목 슬라이드 레이아웃 가져오기

PowerPoint.CustomLayout layout = pres.SlideMaster.

	CustomLayouts[PowerPoint.PpSlideLayout.ppLayoutTitle];
//제목 슬라이드 추가.

PowerPoint.Slide slide=pres.Slides.AddSlide(1, layout);

//제목 텍스트 설정

slide.Shapes.Title.TextFrame.TextRange.Text = "Slide Title Heading";

//부제목 텍스트 설정

slide.Shapes[2].TextFrame.TextRange.Text = "Slide Title Sub-Heading";

//출력을 디스크에 저장

pres.SaveAs("outVSTO.ppt",

	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	Microsoft.Office.Core.MsoTriState.msoFalse);

}

``` 
## **Aspose.Slides**
``` csharp

 private static void CreatePresentation()

{

	//프레젠테이션 생성

	Presentation pres = new Presentation();

	//제목 슬라이드 추가

	Slide slide = pres.AddTitleSlide();

	//제목 텍스트 설정

	((TextHolder)slide.Placeholders[0]).Text = "Slide Title Heading";

	//부제목 텍스트 설정

	((TextHolder)slide.Placeholders[1]).Text = "Slide Title Sub-Heading";

	//출력을 디스크에 저장

	pres.Write("outAsposeSlides.ppt");

}

``` 
## **샘플 코드 다운로드**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Create.a.New.Presentation.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20New%20Presentation%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20New%20Presentation/)