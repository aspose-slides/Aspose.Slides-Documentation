---
title: Excel 차트를 만들고 프레젠테이션에 OLE 개체로 삽입하기
type: docs
weight: 50
url: /ko/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel 차트
- 차트 삽입
- OLE 개체
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Cells for .NET을 사용하여 Excel 차트를 만든 다음 Aspose.Slides를 사용해 워크북을 PowerPoint 프레젠테이션에 차트 미리보기를 포함하여 삽입합니다."
---
## **개요**

이 문서에서는 Aspose.Cells for .NET을 사용하여 Excel 세로 막대 차트를 만드는 방법과 해당 워크북을 Aspose.Slides for .NET을 사용하여 PowerPoint 프레젠테이션에 삽입하는 방법을 보여줍니다. 삽입된 워크북에는 원본 데이터와 차트가 모두 포함됩니다. 별도의 PNG 미리보기는 OLE 개체가 활성화되기 전에 슬라이드에 차트를 표시합니다.

결과는 기본 PowerPoint 차트가 아니라 삽입된 Excel 개체입니다. OLE를 통해 워크북을 편집하려면 OLE 활성화를 지원하는 데스크톱 애플리케이션과 호환되는 Excel 설치가 필요합니다.

## **전제 조건**

C# 프로젝트에 Aspose.Cells for .NET 및 Aspose.Slides for .NET에 대한 참조를 추가합니다. 예제는 최상위 문장을 사용하며 C# 9 이상이 필요합니다. 이러한 라이브러리를 사용하여 프레젠테이션을 생성하는 데 Microsoft Office는 필요하지 않습니다.

입력 파일은 필요하지 않습니다. 예제는 메모리에서 데이터와 차트를 생성한 후 `OutputChart.pptx`를 현재 작업 디렉터리에 씁니다. 평가 모드 외에서 실행할 경우 두 제품에 대한 라이선스를 적용하십시오.

## **삽입 작동 방식**

1. 데이터 워크시트와 차트 시트가 포함된 워크북을 생성합니다.
2. 워크북이 차트에서 열리도록 차트 시트를 활성화합니다.
3. 워크북의 OLE 표시 범위를 설정하고 차트를 PNG로 렌더링합니다.
4. 워크북을 메모리에서 XLSX 형식으로 저장하고 해당 바이트를 슬라이드에 삽입합니다.
5. PNG를 OLE 개체의 미리보기로 할당하고 프레젠테이션을 PPTX 형식으로 저장합니다.

워크북 표시 범위와 슬라이드의 프레임은 서로 다른 역할을 합니다. [SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/)는 0부터 시작하는 시작/끝 행과 열 인덱스를 사용합니다. [ChartCollection.Add](https://reference.aspose.com/cells/net/aspose.cells.charts/chartcollection/add/)는 대신 상단 행, 왼쪽 열, 하단 행 및 오른쪽 열을 사용합니다. 예제에서는 행 인덱스 55와 열 인덱스 25를 오른쪽 하단 경계로 사용합니다; 이 값들은 레이아웃 선택이며 데이터 행 또는 열의 수와는 관계가 없습니다.

슬라이드 프레임은 포인트 단위를 사용합니다. 예제에서는 슬라이드에 맞게 조정하고 PNG의 종횡비를 유지하면서 중앙에 배치합니다. 미리보기를 슬라이드 전체에 늘리지는 않습니다.

## **차트 만들기 및 삽입**

다음 완전한 예제는 `DataSheet`에 4개의 행과 5개의 열 값을 채웁니다. 각 행은 차트 시리즈가 됩니다. 워크북을 저장하기 전에 `ChartSheet`를 활성 시트로 선택합니다.

워크북은 명시적으로 XLSX 형식으로 저장되며, 이는 [OleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides.dom.ole/oleembeddeddatainfo/)에 전달된 `xlsx` 확장자와 일치합니다. PNG는 중간 비트맵 변환 없이 스트림에서 직접 로드됩니다. [SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/substitutepictureformat/)을 통해 할당하면 기본 OLE 자리표시자를 교체합니다.

```cs
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;

using var workbook = new Aspose.Cells.Workbook();
var dataSheet = workbook.Worksheets[0];
dataSheet.Name = "DataSheet";

int[,] values =
{
    { 67, 44, 46, 43, 24 },
    { 86, 64, 97, 29, 40 },
    { 68, 89, 78, 69, 38 },
    { 91, 48, 60, 26, 25 }
};

for (var row = 0; row < values.GetLength(0); row++)
{
    for (var column = 0; column < values.GetLength(1); column++)
    {
        dataSheet.Cells[row, column].PutValue(values[row, column]);
    }
}

var chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
var chartSheet = workbook.Worksheets[chartSheetIndex];
chartSheet.Name = "ChartSheet";

var lastChartRow = 55;
var lastChartColumn = 25;
var chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, 0, lastChartRow, lastChartColumn);
var chart = chartSheet.Charts[chartIndex];
for (var row = 1; row <= values.GetLength(0); row++)
{
    chart.NSeries.Add($"DataSheet!A{row}:E{row}", false);
}

workbook.Worksheets.ActiveSheetIndex = chartSheetIndex;
workbook.Worksheets.SetOleSize(0, lastChartRow, 0, lastChartColumn);

// 차트 미리보기를 렌더링하고 편집 가능한 워크북을 별도로 직렬화합니다.
using var chartImageStream = new MemoryStream();
chart.ToImage(chartImageStream, Aspose.Cells.Drawing.ImageType.Png);
chartImageStream.Position = 0;
using var chartImage = Images.FromStream(chartImageStream);

using var workbookStream = new MemoryStream();
workbook.Save(workbookStream, Aspose.Cells.SaveFormat.Xlsx);
var workbookBytes = workbookStream.ToArray();

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var slideSize = presentation.SlideSize.Size;

// Fit the preview within the slide without changing its aspect ratio.
var scale = Math.Min(slideSize.Width / chartImage.Width, slideSize.Height / chartImage.Height);
var frameWidth = chartImage.Width * scale;
var frameHeight = chartImage.Height * scale;
var frameX = (slideSize.Width - frameWidth) / 2;
var frameY = (slideSize.Height - frameHeight) / 2;

var embeddedData = new OleEmbeddedDataInfo(workbookBytes, "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
var previewImage = presentation.Images.AddImage(chartImage);
oleFrame.SubstitutePictureFormat.Picture.Image = previewImage;

presentation.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **예상 결과**

`OutputChart.pptx`에는 삽입된 Excel 워크북과 차트 미리보기가 있는 하나의 슬라이드가 포함됩니다. 워크북에는 원본 데이터와 4개의 시리즈가 있는 세로 막대 차트가 들어 있습니다. 미리보기는 슬라이드 중앙에 배치되고 비율을 유지합니다.

![삽입된 워크북의 미리보기로 표시된 Excel 세로 막대 차트](excel-chart-ole-preview.png)

Excel이 설치된 호환 가능한 데스크톱 PowerPoint 환경에서는 객체를 더블 클릭하여 삽입된 워크북을 활성화하고 편집할 수 있습니다. 활성화 및 편집은 호스트 애플리케이션의 OLE 지원 및 보안 설정에 따라 달려 있습니다.

## **자주 묻는 질문**

**왜 미리보기 이미지가 필요합니까?**

삽입된 워크북과 슬라이드 미리보기는 별개의 내용입니다. 차트 이미지를 제공하면 슬라이드가 기본 "EMBEDDED OLE OBJECT" 자리표시자 대신 차트를 표시합니다. [OleObjectFrame 추가 시 개체 미리보기 문제](/slides/ko/net/object-preview-issue-when-adding-oleobjectframe/)를 참고하십시오.

**코드에서 워크북을 변경할 때 미리보기가 자동으로 업데이트됩니까?**

미리보기는 스냅샷으로 간주하십시오. 프로그램matically 워크북 데이터를 업데이트할 때 차트 이미지를 다시 생성하고 미리보기와 삽입된 워크북 데이터를 모두 교체합니다.

**XLS 대신 XLSX를 사용할 수 있습니까?**

예. 워크북을 XLS 형식으로 저장하고 `xls`를 삽입 데이터 확장자로 사용합니다. 확장자는 실제 워크북 형식과 일치해야 하며, 확장자만 변경해도 데이터가 변환되지 않습니다.

**활성화 후 개체 크기가 변경되는 이유는 무엇입니까?**

호스트 애플리케이션은 워크북을 활성화할 때 OLE 개체의 표시를 업데이트할 수 있습니다. 워크북의 OLE 표시 범위와 슬라이드 프레임 크기 모두 중요합니다. [PPTX에서 차트 크기 조정에 대한 작업 솔루션](/slides/ko/net/working-solution-for-chart-resizing-in-pptx/)을 참고하십시오.

## **관련 섹션**

- [PPTX에서 차트 크기 조정에 대한 작업 솔루션](/slides/ko/net/working-solution-for-chart-resizing-in-pptx/)
- [OleObjectFrame 추가 시 개체 미리보기 문제](/slides/ko/net/object-preview-issue-when-adding-oleobjectframe/)
- [PowerPoint 추가 기능을 사용한 OLE 개체 자동 업데이트](/slides/ko/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)