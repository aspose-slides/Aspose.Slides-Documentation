---
title: VSTO 및 Aspose.Slides for .NET을 사용한 텍스트 동적 추가
linktitle: 텍스트 동적 추가
type: docs
weight: 20
url: /ko/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/
keywords:
- 텍스트 추가
- 마이그레이션
- VSTO
- Office 자동화
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Microsoft Office 자동화에서 Aspose.Slides for .NET으로 마이그레이션하고 C#에서 PowerPoint(PPT, PPTX) 프레젠테이션에 동적 텍스트를 추가하는 방법을 확인하세요."
---
{{% alert color="primary" %}} 

개발자들이 흔히 수행하는 작업은 슬라이드에 텍스트를 동적으로 추가하는 것입니다. 이 문서에서는 [VSTO](/slides/ko/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/) 및 [Aspose.Slides for .NET](/slides/ko/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/)을 사용하여 텍스트를 동적으로 추가하는 코드 예제를 보여줍니다.

{{% /alert %}} 
## **텍스트 동적으로 추가하기**
두 방법 모두 다음 단계에 따라 진행됩니다:

1. 프레젠테이션을 생성합니다.
1. 빈 슬라이드를 추가합니다.
1. 텍스트 상자를 추가합니다.
1. 텍스트를 설정합니다.
1. 프레젠테이션을 저장합니다.
## **VSTO 코드 예제**
아래 코드 스니펫은 단순 슬라이드와 텍스트 문자열이 포함된 프레젠테이션을 생성합니다.

**VSTO에서 생성된 프레젠테이션** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_1.png)

```c#
//참고: PowerPoint은 위와 같이 정의된 네임스페이스입니다
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//프레젠테이션 생성
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Get the blank slide layout
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[7];

//Add a blank slide
PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);

//Add a text
PowerPoint.Shape shp = sld.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 150, 100, 400, 100);

//Set a text
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Text = "Text added dynamically";
txtRange.Font.Name = "Arial";
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;
txtRange.Font.Size = 32;

//Write the output to disk
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```



## **Aspose.Slides for .NET 예제**
아래 코드 스니펫은 Aspose.Slides를 사용하여 단순 슬라이드와 텍스트 문자열이 포함된 프레젠테이션을 생성합니다.

**Aspose.Slides for .NET을 사용해 생성된 프레젠테이션** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_2.png)

```c#
// 프레젠테이션을 생성합니다
Presentation pres = new Presentation();

// 기본 생성자를 사용할 때 빈 슬라이드가 기본적으로 추가됩니다
// 프레젠테이션이 기본 생성자에서 만들어집니다
// 따라서 빈 슬라이드를 추가할 필요가 없습니다
ISlide sld = pres.Slides[1];

// 텍스트 박스를 추가합니다
// 이를 추가하기 위해 먼저 사각형을 추가합니다
IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 1200, 800, 3200, 370);

// 라인을 숨깁니다
shp.LineFormat.Style = LineStyle.NotDefined;

// 그런 다음 그 안에 텍스트 프레임을 추가합니다
ITextFrame tf = ((IAutoShape)shp).TextFrame;

// 텍스트를 설정합니다
tf.Text = "Text added dynamically";
IPortion port = tf.Paragraphs[0].Portions[0];

port.PortionFormat.FontBold = NullableBool.True;
port.PortionFormat.FontHeight = 32;

// 출력을 디스크에 저장합니다
pres.Save("c:\\outAspose.ppt", SaveFormat.Ppt);
```