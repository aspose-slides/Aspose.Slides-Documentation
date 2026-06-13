---
title: 텍스트 서식 지정
type: docs
weight: 110
url: /ko/net/format-text/
---
VSTO와 Aspose.Slides 메서드는 다음 단계로 진행됩니다:

- 원본 프레젠테이션을 엽니다.
- 첫 번째 슬라이드에 접근합니다.
- 세 번째 텍스트 상자에 접근합니다.
- 세 번째 텍스트 상자의 텍스트 서식을 변경합니다.
- 프레젠테이션을 디스크에 저장합니다.
## **VSTO**
``` csharp

 //프레젠테이션 열기
Presentation pres = new Presentation("source.ppt");

//Verdana 글꼴 추가
FontEntity font = pres.Fonts[0];

FontEntity verdanaFont = new FontEntity(pres, font);

verdanaFont.FontName = "Verdana";

int verdanaFontIndex = pres.Fonts.Add(verdanaFont);

//첫 번째 슬라이드에 접근
Slide slide = pres.GetSlideByPosition(1);

//세 번째 도형에 접근
Shape shp = slide.Shapes[2];

//텍스트의 글꼴을 Verdana로, 높이를 32로 변경
TextFrame tf = shp.TextFrame;

Paragraph para = tf.Paragraphs[0];

Portion port = para.Portions[0];

port.FontIndex = verdanaFontIndex;

port.FontHeight = 32;

//굵게 만들기
port.FontBold = true;

//기울임꼴 적용
port.FontItalic = true;

//텍스트 색상 변경
port.FontColor = Color.FromArgb(0x33, 0x33, 0xCC);

//도형 배경 색상 변경
shp.FillFormat.Type = FillType.Solid;

shp.FillFormat.ForeColor = Color.FromArgb(0xCC, 0xCC, 0xFF);

//출력을 디스크에 기록
pres.Write("outAspose.ppt");

``` 
## **Aspose.Slides**
``` csharp

 PowerPoint.Presentation pres = null;

//프레젠테이션 열기
pres = Globals.ThisAddIn.Application.Presentations.Open("source.ppt",

    Microsoft.Office.Core.MsoTriState.msoFalse,

    Microsoft.Office.Core.MsoTriState.msoFalse,

    Microsoft.Office.Core.MsoTriState.msoTrue);

//첫 번째 슬라이드에 접근
PowerPoint.Slide slide = pres.Slides[1];

//세 번째 도형에 접근
PowerPoint.Shape shp = slide.Shapes[3];

//텍스트의 글꼴을 Verdana로, 높이를 32로 변경
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;

txtRange.Font.Name = "Verdana";

txtRange.Font.Size = 32;

//굵게 만들기
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoCTrue;

//기울임꼴 적용
txtRange.Font.Italic = Microsoft.Office.Core.MsoTriState.msoCTrue;

//텍스트 색상 변경
txtRange.Font.Color.RGB = 0x00CC3333;

//도형 배경 색상 변경
shp.Fill.ForeColor.RGB = 0x00FFCCCC;

//수평으로 재배치
shp.Left -= 70;

//출력을 디스크에 저장
pres.SaveAs("outVSTO.ppt",

    PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

    Microsoft.Office.Core.MsoTriState.msoFalse);

``` 
## **샘플 코드 다운로드**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Format.Text.using.VSTO.and.Aspose.Slides.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Format%20Text%20using%20VSTO%20and%20Aspose.Slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Format%20Text%20using%20VSTO%20and%20Aspose.Slides/)