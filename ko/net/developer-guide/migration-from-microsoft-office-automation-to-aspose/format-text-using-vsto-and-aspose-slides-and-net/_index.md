---
title: VSTO 및 Aspose.Slides for .NET을 사용한 텍스트 서식 지정
linktitle: 텍스트 서식 지정
type: docs
weight: 30
url: /ko/net/format-text-using-vsto-and-aspose-slides-and-net/
keywords:
- 텍스트 서식 지정
- 마이그레이션
- VSTO
- Office 자동화
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Microsoft Office 자동화에서 Aspose.Slides for .NET으로 마이그레이션하고 PowerPoint(PPT, PPTX) 프레젠테이션의 텍스트를 정밀하게 제어하며 서식 지정합니다."
---
{{% alert color="info" %}} 

때때로 슬라이드의 텍스트를 프로그래밍 방식으로 서식 지정해야 할 때가 있습니다. 이 문서에서는 [VSTO](/slides/ko/net/format-text-using-vsto-and-aspose-slides-and-net/) 또는 [Aspose.Slides for .NET](/slides/ko/net/format-text-using-vsto-and-aspose-slides-and-net/)을 사용하여 첫 번째 슬라이드에 텍스트가 포함된 샘플 프레젠테이션을 읽는 방법을 보여줍니다. 코드는 슬라이드의 세 번째 텍스트 상자에 있는 텍스트를 마지막 텍스트 상자의 텍스트와 동일한 형태로 서식 지정합니다.

{{% /alert %}} 
## **텍스트 서식 지정**
VSTO와 Aspose.Slides 방법 모두 다음 단계로 진행합니다:

1. 원본 프레젠테이션을 엽니다.
1. 첫 번째 슬라이드에 접근합니다.
1. 세 번째 텍스트 상자에 접근합니다.
1. 세 번째 텍스트 상자 내부 텍스트의 서식을 변경합니다.
1. 프레젠테이션을 디스크에 저장합니다.

아래 스크린샷은 VSTO 및 Aspose.Slides for .NET 코드 실행 전후의 샘플 슬라이드를 보여줍니다.

**입력 프레젠테이션** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_1.png)
### **VSTO 코드 예제**
아래 코드는 VSTO를 사용하여 슬라이드의 텍스트를 다시 서식 지정하는 방법을 보여줍니다.

**VSTO로 서식 지정된 텍스트** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_2.png)



```c#
//Note: PowerPoint은 위와 같이 정의된 네임스페이스입니다
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;
 //Open the presentation
 //Access the first slide
 //Access the third shape
 //Change its text의 폰트를 Verdana로, 크기를 32로 변경
 //Bolden it
 //Italicize it
 //Change text color
 //Change shape background color
 //Reposition it horizontally
 //Write the output to disk
PowerPoint.Presentation pres = null;

pres = Globals.ThisAddIn.Application.Presentations.Open("c:\\source.ppt",
    Microsoft.Office.Core.MsoTriState.msoFalse,
    Microsoft.Office.Core.MsoTriState.msoFalse,
    Microsoft.Office.Core.MsoTriState.msoTrue);

PowerPoint.Slide slide = pres.Slides[1];

PowerPoint.Shape shp = slide.Shapes[3];

PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Font.Name = "Verdana";
txtRange.Font.Size = 32;

txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoCTrue;

txtRange.Font.Italic = Microsoft.Office.Core.MsoTriState.msoCTrue;

txtRange.Font.Color.RGB = 0x00CC3333;

shp.Fill.ForeColor.RGB = 0x00FFCCCC;

shp.Left -= 70;

pres.SaveAs("c:\\outVSTO.ppt",
    PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
    Microsoft.Office.Core.MsoTriState.msoFalse);
```




### **Aspose.Slides for .NET 예제**
Aspose.Slides를 사용하여 텍스트를 서식 지정하려면, 텍스트를 서식 지정하기 전에 폰트를 추가합니다.

**Aspose.Slides로 만든 출력 프레젠테이션** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_3.png)



```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

 //프레젠테이션 열기
Presentation pres = new Presentation("source.ppt");

//첫 번째 슬라이드에 접근
ISlide slide = pres.Slides[0];

//세 번째 도형에 접근
IShape shp = slide.Shapes[2];

//텍스트의 폰트를 Verdana로, 크기를 32로 변경
ITextFrame tf = ((IAutoShape)shp).TextFrame;
IParagraph para = tf.Paragraphs[0];
IPortion port = para.Portions[0];
port.PortionFormat.LatinFont = new FontData("Verdana");

port.PortionFormat.FontHeight = 32;

//굵게 적용
port.PortionFormat.FontBold = NullableBool.True;

//기울임 적용
port.PortionFormat.FontItalic = NullableBool.True;

//텍스트 색상 변경
//폰트 색상 설정
port.PortionFormat.FillFormat.FillType = FillType.Solid;
port.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(0x33, 0x33, 0xCC);

//도형 배경 색상 변경
shp.FillFormat.FillType = FillType.Solid;
shp.FillFormat.SolidFillColor.Color = Color.FromArgb(0xCC, 0xCC, 0xFF);

//출력을 디스크에 저장
pres.Save("outAspose.ppt", SaveFormat.Ppt);
```