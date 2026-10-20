---
title: PPTX에서 차트 크기 조정을 위한 실용적인 해결책
type: docs
weight: 60
url: /ko/net/working-solution-for-chart-resizing-in-pptx/
keywords:
- 차트 크기 조정
- Excel 차트
- OLE 개체
- 차트 삽입
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "PPTX에서 Aspose.Slides for .NET을 사용하여 삽입된 Excel OLE 개체를 사용할 때 발생하는 예기치 않은 차트 크기 조정을 해결합니다. 차트와 OLE 프레임 크기를 일관되게 유지하기 위해 차트의 고정 차원을 설정합니다."
---
## **배경**

Aspose 구성 요소를 사용하여 PowerPoint 프레젠테이션에 OLE 개체로 삽입된 Excel 차트가 처음 활성화된 후 크기가 변경될 수 있습니다. 이로 인해 차트가 활성화 전후에 보이는 모습에 눈에 띄는 차이가 발생합니다. 이 문서는 크기 조정이 발생하는 이유를 설명하고, 차트 크기를 OLE 프레임에 맞게 고정하여 이를 방지하는 방법을 보여줍니다.

[Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/ko/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) 에서는 Aspose.Cells for .NET을 사용해 Excel 차트를 만들고 Aspose.Slides for .NET을 통해 PowerPoint 프레젠테이션에 삽입하는 방법을 설명했습니다. [object preview issue](/slides/ko/net/object-preview-issue-when-adding-oleobjectframe/) 를 해결하기 위해 차트 이미지를 차트의 OLE 개체 프레임에 할당했습니다. 출력 프레젠테이션에서 차트 이미지를 표시하는 OLE 개체 프레임을 더블 클릭하면 Excel 차트가 활성화됩니다. 사용자는 삽입된 Excel 워크북을 편집한 뒤 활성화된 워크북 밖을 클릭해 슬라이드로 돌아갈 수 있습니다. 사용자가 슬라이드로 돌아올 때 OLE 개체 프레임의 크기가 변경되며, 이 크기 조정 비율은 OLE 개체 프레임과 삽입된 Excel 워크북의 원래 크기에 따라 달라집니다.

## **크기 조정 원인**

삽입된 Excel 워크북은 자체 창 크기를 가지고 있으며, Excel은 개체가 처음 활성화될 때 이 크기를 유지하려 합니다. 슬라이드상의 OLE 프레임은 별도로 정의된 크기를 갖습니다. Excel 워크북이 활성화되면 Excel과 PowerPoint가 개체의 비율을 유지하기 위해 크기를 협상합니다. 워크북 창과 OLE 프레임 사이의 차이 때문에 개체가 크기가 조정될 수 있습니다.

## **작동 해결책**

차트 크기를 슬라이드상의 OLE 프레임에 맞추고, 차트 차원을 워크북 창과 무관하게 유지합니다. 이 솔루션은 새 프레젠테이션이든 기존 템플릿이든 적용됩니다.

예제는 Aspose.Cells for .NET과 Aspose.Slides for .NET이 필요합니다. 활성 차트 시트에 간단한 세로 막대 차트를 만들고 워크북을 XLS 형식으로 삽입합니다. 차트 미리보기 이미지는 할당되지 않으며, PowerPoint에서 OLE 개체가 활성화될 때 차트가 표시됩니다.

예제는 왼쪽 가장자리에서 0.5인치, 위쪽 가장자리에서 1인치 떨어진 위치에 9.5 × 4인치 OLE 프레임을 만들고 새로운 프레젠테이션을 생성합니다. 슬라이드 좌표와 크기는 포인트 단위(인치당 72 포인트)로 지정됩니다. 기존 프레젠테이션의 경우, [Use a Template](#use-a-template) 을 참조하십시오.

## **고정 차트 크기 설정**

[SizeWithWindow](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/sizewithwindow/)을 false 로 설정하여 차트 차원이 워크북 창과 무관하도록 합니다. [ChartObject](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/chartobject/)의 차원은 [Width](https://reference.aspose.com/cells/net/aspose.cells.drawing/shape/width/)와 [Height](https://reference.aspose.com/cells/net/aspose.cells.drawing/shape/height/)를 통해 설정하고, 인치당 96 픽셀을 사용해 포인트를 픽셀로 변환합니다: 684 × 288 포인트 프레임은 912 × 384 픽셀 차트에 해당합니다. [PrintSize](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/printsize/)를 [PrintSizeType](https://reference.aspose.com/cells/net/aspose.cells/printsizetype/)의 Custom 값으로 설정합니다. 예제는 [AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addoleobjectframe/)을 사용해 워크북을 삽입하고 9.5 × 4인치 OLE 프레임이 포함된 프레젠테이션을 저장합니다.

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;

using var workbook = new Aspose.Cells.Workbook();
var dataSheet = workbook.Worksheets[0];
dataSheet.Name = "Data";
dataSheet.Cells["A1"].PutValue(10);
dataSheet.Cells["A2"].PutValue(20);

var chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
var chartSheet = workbook.Worksheets[chartSheetIndex];
var chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, 0, 20, 10);
var chart = chartSheet.Charts[chartIndex];
chart.NSeries.Add("Data!A1:A2", true);
workbook.Worksheets.ActiveSheetIndex = chartSheetIndex;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// 슬라이드 좌표와 크기는 포인트 단위(인치당 72 포인트)입니다.
var width = 684f; // 9.5인치.
var height = 288f; // 4인치.

chart.SizeWithWindow = false;
// 포인트를 인치당 96픽셀을 사용해 차트 픽셀로 변환합니다.
chart.ChartObject.Width = (int)(width / 72f * 96f);
chart.ChartObject.Height = (int)(height / 72f * 96f);
chart.PrintSize = Aspose.Cells.PrintSizeType.Custom;

using var workbookStream = new MemoryStream();
workbook.Save(workbookStream, Aspose.Cells.SaveFormat.Excel97To2003);
var dataInfo = new OleEmbeddedDataInfo(workbookStream.ToArray(), "xls");
slide.Shapes.AddOleObjectFrame(36, 72, width, height, dataInfo);

presentation.Save("chart-fixed-size.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **템플릿 사용**

기존 프레젠테이션에서도 동일한 크기 지정 로직을 적용합니다. 예제를 다음과 같이 조정합니다:

1. 빈 프레젠테이션을 만드는 대신 템플릿 프레젠테이션을 로드합니다.
1. 첫 번째 슬라이드에 최소 세 개의 도형이 있는지 확인하고, 인덱스 2에 해당하는 도형을 자리표시자로 사용합니다.
1. 고정값 684와 288 대신 해당 도형의 프레임 너비와 높이를 사용합니다. 크기 계산은 그대로 유지합니다.
1. 고정 좌표 36과 72 대신 자리표시자의 위치에 OLE 프레임을 추가합니다.
1. 프레젠테이션을 저장하기 전에 자리표시자를 제거합니다.

## **FAQ**

**PowerPoint에서 활성화된 후 삽입된 Excel 차트의 크기가 변하는 이유는 무엇인가요?**

Excel이 처음 활성화될 때 원래 창 크기를 복원하려고 시도하고, PowerPoint의 OLE 개체 프레임은 자체 크기를 가지고 있기 때문입니다. PowerPoint와 Excel이 비율을 유지하기 위해 크기를 협상하면서 크기 변경이 발생합니다.

**차트와 OLE 프레임 크기를 일관되게 유지하려면 어떻게 해야 하나요?**

OLE 프레임과 일치하는 고정 차트 차원을 설정하고, 워크북을 삽입하기 전에 사용자 정의 차트 인쇄 크기를 사용합니다. 위 예제에 필요한 설정 및 단위 변환이 포함되어 있습니다.

**워크북 창 크기만 맞추면 충분한가요?**

워크북 창 크기만 맞추어도 활성화 후 OLE 프레임 크기가 변하는 현상을 안정적으로 방지할 수 없습니다. 예제와 같이 고정 차트 차원을 사용해야 합니다.

**이 솔루션은 템플릿 기반 프레젠테이션과 새 프레젠테이션 모두에서 작동하나요?**

예. 템플릿을 사용할 경우 자리표시자의 차원과 위치를 사용하고, 새로운 프레젠테이션을 만들 때는 프레임 차원과 위치를 직접 지정합니다.

**다른 스프레드시트 프로그램으로 만든 차트에도 이 예제를 사용할 수 있나요?**

이 예제는 Aspose.Cells 로 만든 Excel 워크북을 사용합니다. 다른 스프레드시트 프로그램에 대한 활성화 동작은 보여주지 않습니다.

## **관련 섹션**

- [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/ko/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [Update OLE Objects Automatically Using a PowerPoint Add-In](/slides/ko/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)