---
title: PPTX에서 차트 크기 조정 문제 해결
type: docs
weight: 40
url: /ko/python-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- 차트 크기 조정
- Excel 차트
- OLE 개체
- 차트 삽입
- PowerPoint
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 삽입된 Excel OLE 개체와 함께 PPTX에서 발생하는 예기치 않은 차트 크기 조정을 수정합니다. 차트와 OLE 프레임 크기를 일관되게 유지하려면 고정 차트 차원을 설정하십시오."
---
## **배경**

Excel 차트가 Aspose 구성 요소를 사용하여 PowerPoint 프레젠테이션에 OLE 개체로 삽입될 경우 처음 활성화된 후 크기가 변경될 수 있습니다. 이는 차트가 활성화 전후에 보이는 모양에 눈에 띄는 차이를 야기할 수 있습니다. 이 문서에서는 크기 조정이 발생하는 이유를 설명하고 고정 차트 크기를 OLE 프레임에 맞추어 이를 방지하는 방법을 보여줍니다.

In [프레젠테이션에 OLE 개체로 Excel 차트 생성 및 삽입](/slides/ko/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), we explained how to create an Excel chart with Aspose.Cells for Python via Java and embed it in a PowerPoint presentation using Aspose.Slides for Python via Java. To address the [개체 미리보기 문제](/slides/ko/python-java/object-preview-issue-when-adding-oleobjectframe/), we assigned the chart image to the chart’s OLE object frame. In the output presentation, when you double-click the OLE object frame displaying the chart image, the Excel chart is activated. Users can edit the embedded Excel workbook and then return to the slide by clicking outside the activated workbook. The size of the OLE object frame changes when the user returns to the slide, and the resizing factor varies depending on the original sizes of both the OLE object frame and the embedded Excel workbook.

## **크기 조정 원인**

The embedded Excel workbook has its own window dimensions, which Excel tries to retain when the object is first activated. The OLE frame on the slide has independently defined dimensions. When the Excel workbook is activated, Excel and PowerPoint negotiate the object's size to maintain its proportions as part of the embedding process. Differences between the workbook window and the OLE frame can therefore cause the object to resize.

## **작동 솔루션**

Match the chart size to the OLE frame on the slide and keep the chart dimensions independent of the workbook window. This solution works with a new presentation or an existing template.

The example requires Aspose.Cells for Python via Java and Aspose.Slides for Python via Java. It creates a simple column chart on an active chart sheet and embeds the workbook in XLS format. No chart preview image is assigned; the chart becomes visible when the OLE object is activated in PowerPoint.

The example creates a new presentation with a 9.5 × 4-inch OLE frame positioned 0.5 inches from the left edge and 1 inch from the top. Slide coordinates and dimensions are in points (72 points per inch). For an existing presentation, see [템플릿 사용](#use-a-template).

## **고정 차트 크기 설정**

Set [setSizeWithWindow](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#sizewithwindow) to false so that the chart dimensions are independent of the workbook window. Set the [getChartObject](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#chartobject) dimensions through [setWidth](https://reference.aspose.com/cells/python-java/asposecells.api/shape/#width) and [setHeight](https://reference.aspose.com/cells/python-java/asposecells.api/shape/#height), converting points to pixels using 96 pixels per inch: a frame measuring 684 × 288 points corresponds to a chart measuring 912 × 384 pixels. Set [setPrintSize](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#printsize) to the CUSTOM value of [PrintSizeType](https://reference.aspose.com/cells/python-java/asposecells.api/printsizetype/). The example embeds the workbook with [addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) and saves a presentation with a 9.5 × 4-inch OLE frame.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import ChartType, FileFormatType, PrintSizeType, SheetType, Workbook
from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

workbook = Workbook()
try:
    data_sheet = workbook.getWorksheets().get(0)
    data_sheet.setName("Data")
    data_sheet.getCells().get("A1").putValue(10)
    data_sheet.getCells().get("A2").putValue(20)

    chart_sheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(chart_sheet_index)
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, 0, 20, 10)
    chart = chart_sheet.getCharts().get(chart_index)
    chart.getNSeries().add("Data!A1:A2", True)
    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)

    presentation = Presentation()
    try:
        slide = presentation.getSlides().get_Item(0)

        # 슬라이드 좌표와 크기는 포인트 단위이며 (인치당 72 포인트)입니다.
        width = 684.0  # 9.5인치.
        height = 288.0  # 4인치.

        chart.setSizeWithWindow(False)
        # 인치당 96 픽셀을 사용하여 포인트를 차트 픽셀로 변환합니다.
        chart.getChartObject().setWidth(int(width / 72.0 * 96.0))
        chart.getChartObject().setHeight(int(height / 72.0 * 96.0))
        chart.setPrintSize(PrintSizeType.CUSTOM)

        workbook_stream = ByteArrayOutputStream()
        workbook.save(workbook_stream, FileFormatType.EXCEL_97_TO_2003)
        workbook_data = workbook_stream.toByteArray()
        data_info = OleEmbeddedDataInfo(workbook_data, "xls")
        slide.getShapes().addOleObjectFrame(36.0, 72.0, width, height, data_info)

        presentation.save("chart-fixed-size.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    workbook.dispose()
```

## **템플릿 사용**

The sizing logic is the same for an existing presentation. To adapt the example:

1. 빈 프레젠테이션을 만드는 대신 템플릿 프레젠테이션을 로드합니다.
1. 첫 번째 슬라이드에 최소 세 개의 도형이 포함되어 있는지 확인한 후 인덱스 2에 있는 도형을 자리표시자로 사용합니다.
1. 고정 값 684와 288을 사용하는 대신 해당 도형에서 프레임 너비와 높이를 가져옵니다. 크기 계산은 그대로 유지합니다.
1. 고정 좌표 36과 72 대신 자리표시자의 위치에 OLE 프레임을 추가합니다.
1. 프레젠테이션을 저장하기 전에 자리표시자를 제거합니다.

## **FAQ**

**PowerPoint에서 활성화한 후 내 삽입된 Excel 차트가 크기가 변하는 이유는 무엇인가요?**

Excel이 처음 활성화될 때 원래 창 크기를 복원하려고 시도하고, PowerPoint의 OLE 개체 프레임은 자체적인 치수를 가지고 있기 때문에 발생합니다. PowerPoint와 Excel이 비율을 유지하려고 협상하면서 크기 조정이 일어날 수 있습니다.

**차트와 OLE 프레임의 크기를 일관되게 유지하려면 어떻게 해야 하나요?**

고정 차트 치수를 OLE 프레임에 맞추고 워크북을 삽입하기 전에 사용자 정의 차트 인쇄 크기를 설정합니다. 위 예제에 필요한 설정과 단위 변환이 나와 있습니다.

**워크북 창 크기만 맞추면 충분한가요?**

워크북 창 크기만 맞추어도 활성화 후 OLE 프레임 크기 변경을 안정적으로 방지할 수 없습니다. 예제와 같이 고정 차트 치수를 사용해야 합니다.

**이 솔루션은 템플릿 기반 프레젠테이션과 새 프레젠테이션 모두에 적용되나요?**

예. 템플릿을 사용할 경우 자리표시자의 치수와 위치를 사용하고, 새 프레젠테이션을 만들 때는 프레임 치수와 위치를 직접 지정합니다.

**다른 스프레드시트 프로그램으로 만든 차트에도 이 예제를 사용할 수 있나요?**

예제는 Aspose.Cells로 만든 Excel 워크북을 사용합니다. 다른 스프레드시트 프로그램에 대한 활성화 동작은 보여주지 않습니다.

## **관련 섹션**

- [프레젠테이션에 OLE 개체로 Excel 차트 생성 및 삽입](/slides/ko/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)