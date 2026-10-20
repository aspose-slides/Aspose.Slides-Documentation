---
title: PPTX에서 차트 크기 조정에 대한 실용적인 해결책
type: docs
weight: 60
url: /ko/python-net/working-solution-for-chart-resizing-in-pptx/
keywords:
- 차트 크기 조정
- Excel 차트
- OLE 개체
- 차트 삽입
- PowerPoint
- 프레젠테이션
- .NET을 통한 Python
- 파이썬
- Aspose.Slides
description: "Aspose.Slides for Python via .NET을 사용하여 삽입된 Excel OLE 개체와 함께 PPTX에서 발생하는 예상치 못한 차트 크기 조정을 해결합니다. 차트와 OLE 프레임의 크기를 일관되게 유지하기 위해 고정 차트 치수를 설정합니다."
---
## **개요**

Aspose 구성 요소를 사용하여 PowerPoint 프레젠테이션에 OLE 개체로 삽입된 Excel 차트는 첫 번째 활성화 후 크기가 변경될 수 있습니다. 이는 차트가 활성화되기 전후의 모습에 눈에 띄는 차이를 만들 수 있습니다. 이 기사에서는 크기 변경이 발생하는 이유를 설명하고 고정 차트 크기를 OLE 프레임에 맞추어 이를 방지하는 방법을 보여줍니다.

[프레젠테이션에 Excel 차트를 만들고 OLE 개체로 삽입하기](/slides/ko/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)에서 Aspose.Cells for Python via .NET으로 Excel 차트를 만들고 Aspose.Slides for Python via .NET으로 PowerPoint 프레젠테이션에 삽입하는 방법을 설명했습니다. [개체 미리보기 문제](/slides/ko/python-net/object-preview-issue-when-adding-oleobjectframe/)를 해결하기 위해 차트 이미지를 차트의 OLE 개체 프레임에 할당했습니다. 출력 프레젠테이션에서 차트 이미지를 표시하는 OLE 개체 프레임을 두 번 클릭하면 Excel 차트가 활성화됩니다. 사용자는 삽입된 Excel 워크북을 편집한 후 활성화된 워크북 밖을 클릭하여 슬라이드로 돌아갈 수 있습니다. 사용자가 슬라이드로 돌아올 때 OLE 개체 프레임의 크기가 변경되며, 크기 변경 비율은 OLE 개체 프레임과 삽입된 Excel 워크북의 원래 크기에 따라 달라집니다.

## **크기 변경 원인**

삽입된 Excel 워크북은 자체 창 크기를 가지고 있으며, Excel은 개체가 처음 활성화될 때 이 크기를 유지하려고 합니다. 슬라이드의 OLE 프레임은 독립적으로 정의된 치수를 갖습니다. Excel 워크북이 활성화되면 Excel과 PowerPoint가 개체의 비율을 유지하도록 크기를 협상합니다. 워크북 창과 OLE 프레임 사이의 차이 때문에 개체가 크기가 조정될 수 있습니다.

## **해결 방법**

차트 크기를 슬라이드의 OLE 프레임에 맞추고 차트 치수를 워크북 창과 독립적으로 유지합니다. 이 솔루션은 새 프레젠테이션이나 기존 템플릿 모두에서 작동합니다.

예제는 Aspose.Cells for Python via .NET와 Aspose.Slides for Python via .NET이 필요합니다. 활성 차트 시트에 간단한 세로 막대형 차트를 만들고 워크북을 XLS 형식으로 삽입합니다. 차트 미리보기 이미지는 할당되지 않으며, PowerPoint에서 OLE 개체가 활성화될 때 차트가 표시됩니다.

예제는 왼쪽 가장자리에서 0.5인치, 위쪽에서 1인치 떨어진 위치에 9.5 × 4인치 OLE 프레임을 배치하여 새 프레젠테이션을 생성합니다. 슬라이드 좌표와 치수는 포인트 단위(인치당 72포인트)입니다. 기존 프레젠테이션의 경우 [템플릿 사용](#use-a-template)을 참조하십시오.

## **고정 차트 크기 설정**

[size_with_window](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/size_with_window/)을 false로 설정하여 차트 치수가 워크북 창에 의존하지 않도록 합니다. [chart_object](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/chart_object/) 치수를 [width](https://reference.aspose.com/cells/python-net/aspose.cells.drawing/shape/width/)와 [height](https://reference.aspose.com/cells/python-net/aspose.cells.drawing/shape/height/)를 통해 지정하고, 인치당 96픽셀을 사용해 포인트를 픽셀로 변환합니다: 684 × 288 포인트 프레임은 912 × 384 픽셀 차트에 해당합니다. [print_size](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/print_size/)를 [PrintSizeType](https://reference.aspose.com/cells/python-net/aspose.cells/printsizetype/)의 CUSTOM 값으로 설정합니다. 예제는 [add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/add_ole_object_frame/)을 사용해 워크북을 삽입하고 9.5 × 4인치 OLE 프레임이 포함된 프레젠테이션을 저장합니다.

```python
import io
import aspose.cells as cells
import aspose.cells.charts as charts
import aspose.slides as slides

workbook = cells.Workbook()
data_sheet = workbook.worksheets[0]
data_sheet.name = "Data"
data_sheet.cells.get("A1").put_value(10)
data_sheet.cells.get("A2").put_value(20)

chart_sheet_index = workbook.worksheets.add(cells.SheetType.CHART)
chart_sheet = workbook.worksheets[chart_sheet_index]
chart_index = chart_sheet.charts.add(charts.ChartType.COLUMN, 0, 0, 20, 10)
chart = chart_sheet.charts[chart_index]
chart.n_series.add("Data!A1:A2", True)
workbook.worksheets.active_sheet_index = chart_sheet_index

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 슬라이드 좌표와 차원은 포인트 단위(인치당 72포인트)입니다.
    width = 684.0  # 9.5인치.
    height = 288.0  # 4인치.

    chart.size_with_window = False
    # 포인트를 인치당 96픽셀을 사용해 차트 픽셀로 변환합니다.
    chart.chart_object.width = int(width / 72 * 96)
    chart.chart_object.height = int(height / 72 * 96)
    chart.print_size = cells.PrintSizeType.CUSTOM

    with io.BytesIO() as workbook_stream:
        workbook.save(workbook_stream, cells.SaveFormat.EXCEL_97_TO_2003)
        data_info = slides.dom.ole.OleEmbeddedDataInfo(workbook_stream.getvalue(), "xls")
        slide.shapes.add_ole_object_frame(36, 72, width, height, data_info)

    presentation.save("chart-fixed-size.pptx", slides.export.SaveFormat.PPTX)
```

## **템플릿 사용**

기존 프레젠테이션에서도 동일한 크기 지정 논리를 적용합니다. 예제를 적용하려면 다음을 수행합니다:

1. 빈 프레젠테이션을 만들지 말고 템플릿 프레젠테이션을 로드합니다.
2. 첫 번째 슬라이드에 최소 세 개의 도형이 포함되어 있는지 확인한 후 인덱스 2에 있는 도형을 자리 표시자로 사용합니다.
3. 고정 값 684와 288 대신 해당 도형에서 프레임 너비와 높이를 가져옵니다. 크기 계산은 그대로 유지합니다.
4. 고정 좌표 36과 72 대신 자리 표시자의 위치에 OLE 프레임을 추가합니다.
5. 프레젠테이션을 저장하기 전에 자리 표시자를 제거합니다.

## **FAQ**

**PowerPoint에서 활성화한 후 삽입된 Excel 차트의 크기가 변경되는 이유는 무엇인가요?**  
Excel은 처음 활성화될 때 원래 창 크기를 복원하려고 하고, PowerPoint의 OLE 개체 프레임은 자체 치수를 가지고 있기 때문입니다. PowerPoint와 Excel이 비율을 유지하도록 크기를 협상하면서 크기 변경이 발생할 수 있습니다.

**차트와 OLE 프레임 크기를 일관되게 유지하려면 어떻게 해야 하나요?**  
OLE 프레임에 맞는 고정 차트 치수를 설정하고 워크북을 삽입하기 전에 사용자 지정 차트 인쇄 크기를 사용합니다. 위 예제에 필요한 설정과 단위 변환이 표시되어 있습니다.

**워크북 창 크기만 맞추면 충분한가요?**  
워크북 창 크기만 맞추어도 활성화 후 OLE 프레임이 크기가 변하는 상황을 신뢰성 있게 방지하지 못합니다. 예제와 같이 고정 차트 치수를 사용하십시오.

**이 솔루션은 템플릿 기반 프레젠테이션과 새 프레젠테이션 모두에 적용되나요?**  
예. 템플릿의 경우 자리 표시자 치수와 위치를 사용하고, 새 프레젠테이션의 경우 프레임 치수와 위치를 직접 지정합니다.

**다른 스프레드시트 프로그램에서 만든 차트에도 이 예제를 사용할 수 있나요?**  
이 예제는 Aspose.Cells로 만든 Excel 워크북을 사용합니다. 다른 스프레드시트 프로그램의 활성화 동작은 보여주지 않습니다.

## **관련 섹션**

- [프레젠테이션에 Excel 차트를 만들고 OLE 개체로 삽입하기](/slides/ko/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [PowerPoint 추가 기능을 사용하여 OLE 개체 자동 업데이트](/slides/ko/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)