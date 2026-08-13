---
title: "Aspose.Slides for .NET 16.2.0의 공용 API 및 이전 버전과 호환되지 않는 변경 사항"
linktitle: "Aspose.Slides for .NET 16.2.0"
type: docs
weight: 230
url: /ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/
keywords:
- 마이그레이션
- 레거시 코드
- 현대 코드
- 레거시 접근 방식
- 현대 접근 방식
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET의 공용 API 업데이트와 호환성 깨짐 변경 사항을 검토하여 PowerPoint PPT, PPTX 및 ODP 프레젠테이션 솔루션을 원활하게 마이그레이션하십시오."
---
{{% alert color="info" %}} 

이 페이지는 Aspose.Slides for .NET 16.2.0 API에 도입된 [added](/slides/ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) 또는 [removed](/slides/ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) 클래스, 메서드, 속성 등을 모두 나열합니다.

{{% /alert %}} 
## **공용 API 변경 사항**
#### **Properties UpdateDateTimeFields와 UpdateSlideNumberFields가 제거되었습니다**
Properties UpdateDateTimeFields와 UpdateSlideNumberFields는 Aspose.Slides.Presentation 클래스와 Aspose.Slides.IPresentation 인터페이스에서 제거되었습니다.
Aspose.Slides.TextFrame, Paragraph, Portion 클래스와 Aspose.Slides.ITextFrame, IParagraph, IPortion 인터페이스의 Text 속성은 업데이트된 "datetime" 필드가 포함된 텍스트를 반환합니다.
또한 Presentation.DocumentProperties.CreatedTime, LastSavedTime 및 LastPrinted 속성은 읽기 전용이 되었습니다.
#### **Enum Slides.Charts.CategoryAxisType이 공개로 전환되었습니다**
IAxis.CategoryAxisType 및 Axis.CategoryAxisType 속성에서 카테고리 축 유형을 결정하는 데 사용됩니다.
CategoryAxisType.Auto - 카테고리 축 유형이 직렬화 중에 자동으로 결정됩니다(현재 이 동작은 구현되지 않음)
CategoryAxisType.Text - 카테고리 축 유형은 Text입니다
CategoryAxisType.Date - 카테고리 축 유형은 DateTime입니다
#### **빠른 텍스트 추출**
Presentation 클래스에 새로운 정적 메서드 GetPresentationText가 추가되었습니다. 이 메서드에는 두 개의 오버로드가 있습니다:

``` csharp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)

``` 

ExtractionMode 열거형 인수는 텍스트 결과의 출력 방식을 지정하며 다음 값 중 하나로 설정할 수 있습니다:
Unarranged - 슬라이드 위치와 무관한 원시 텍스트
Arranged - 텍스트가 슬라이드상의 순서와 동일하게 배치됩니다

속도가 중요한 경우 Unarranged 모드를 사용할 수 있으며, Arranged 모드보다 빠릅니다.

PresentationText는 프레젠테이션에서 추출된 원시 텍스트를 나타냅니다. Aspose.Slides.Util 네임스페이스의 SlidesText 속성을 포함하며, 이 속성은 ISlideText 객체 배열을 반환합니다. 각 객체는 해당 슬라이드의 텍스트를 나타냅니다. ISlideText 객체는 다음 속성을 가집니다:
ISlideText.Text - 슬라이드 도형에 있는 텍스트
ISlideText.MasterText - 이 슬라이드에 대한 마스터 페이지 도형의 텍스트
ISlideText.LayoutText - 이 슬라이드에 대한 레이아웃 페이지 도형의 텍스트
ISlideText.NotesText - 이 슬라이드에 대한 노트 페이지 도형의 텍스트

또한 ISlideText 인터페이스를 구현하는 SlideText 클래스도 존재합니다.

새 API는 다음과 같이 사용할 수 있습니다:

``` csharp
using System;
using Aspose.Slides;

// 슬라이드에서 텍스트의 위치를 무시하고 텍스트를 추출합니다 (가장 빠른 모드).
IPresentationText text1 = PresentationFactory.Instance.GetPresentationText(
    "presentation.ppt", TextExtractionArrangingMode.Unarranged);

Console.WriteLine(text1.SlidesText[0].Text);
Console.WriteLine(text1.SlidesText[0].LayoutText);
Console.WriteLine(text1.SlidesText[0].MasterText);
Console.WriteLine(text1.SlidesText[0].NotesText);

// 슬라이드와 동일한 순서대로 배치된 텍스트를 추출합니다.
IPresentationText text2 = PresentationFactory.Instance.GetPresentationText(
    "presentation.pptx", TextExtractionArrangingMode.Arranged);

Console.WriteLine(text2.SlidesText[0].Text);
``` 
#### **ILegacyDiagram 인터페이스와 LegacyDiagram 클래스가 추가되었습니다**
Aspose.Slides.ILegacyDiagram 인터페ace와 Aspose.Slides.LegacyDiagram 클래스가 레거시 다이어그램 객체를 나타내기 위해 추가되었습니다. 레거시 다이어그램 객체는 PowerPoint 97-2003의 옛 형식 다이어그램입니다.
새 클래스는 레거시 다이어그램을 최신 편집 가능한 SmartArt 객체 또는 편집 가능한 GroupShape으로 변환하는 메서드를 제공합니다.
#### **새 Aspose.Slides.TextAlignment 열거형 멤버 추가 (JustifyLow)**
TextAlignment 열거형에 새로운 멤버가 추가되었습니다:
JustifyLow - Kashida 저쪽 정렬.
#### **Aspose.Slides.IOleObjectFrame 및 OleObjectFrame에 새로운 속성 추가**
IOleObjectFrame 인터페이스와 이를 구현하는 OleObjectFrame 클래스에 새로운 속성이 추가되었습니다. 이 속성들은 프레젠테이션에 삽입된 객체에 대한 정보를 제공하는 데 사용됩니다:
EmbeddedFileExtension - 현재 임베드된 객체의 파일 확장자를 반환하며, 객체가 링크가 아닌 경우 빈 문자열을 반환합니다
EmbeddedFileLabel - 임베드된 OLE 객체의 파일 이름을 반환합니다
EmbeddedFileName - 임베드된 OLE 객체의 경로를 반환합니다
#### **IAxis 및 Axis 클래스에 새 속성 CategoryAxisType 추가**
CategoryAxisType 속성은 카테고리 축의 유형을 지정합니다.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

string sourcePptxFileName = "chart.pptx";
string pptxOutPath = "chart_out.pptx";

using (Presentation pres = new Presentation(sourcePptxFileName))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;

    chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
    chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;
    chart.Axes.HorizontalAxis.MajorUnit = 1;
    chart.Axes.HorizontalAxis.MajorUnitScale = TimeUnitType.Months;

    pres.Save(pptxOutPath, SaveFormat.Pptx);
}
``` 
#### **DataLabelFormat 클래스와 IDataLabelFormat 인터페이스에 새 속성 ShowLabelAsDataCallout 추가**
ShowLabelAsDataCallout 속성은 지정된 차트의 데이터 레이블을 데이터 호출(Callout)으로 표시할지 데이터 레이블로 표시할지를 결정합니다.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

string pptxFileName = "callout_labels.pptx";

using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 500, 400);

    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;
    chart.ChartData.Series[0].Labels[2].DataLabelFormat.ShowLabelAsDataCallout = false;

    pres.Save(pptxFileName, SaveFormat.Pptx);
}
``` 
#### **PdfOptions 및 XpsOptions에 속성 DrawSlidesFrame 추가**
Boolean 속성 DrawSlidesFrame이 Aspose.Slides.Export.IPdfOptions, Aspose.Slides.Export.IXpsOptions 인터페이스와 관련 클래스 Aspose.Slides.Export.PdfOptions, Aspose.Slides.Export.XpsOptions에 추가되었습니다.
이 속성이 true로 설정되면 각 슬라이드 주변에 검은 프레임이 그려집니다.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


 using (Presentation pres = new Presentation("input.pptx"))

{

    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });

}
```