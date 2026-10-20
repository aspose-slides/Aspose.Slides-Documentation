---
title: Excel 차트 만들고 OLE 객체로 프레젠테이션에 삽입하기
type: docs
weight: 50
url: /ko/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel 차트
- 차트 삽입
- OLE 객체
- PowerPoint
- 프레젠테이션
- Python
- .NET을 통한 Python
- Aspose.Slides
description: "Aspose.Cells for Python via .NET을 사용하여 Excel 차트를 만들고, Aspose.Slides로 워크북을 PowerPoint 프레젠테이션에 삽입하며 차트 미리보기를 포함합니다."
---
## **개요**

이 문서에서는 .NET을 통해 Python용 Aspose.Cells를 사용하여 Excel 세로 막대 차트를 생성하고, 해당 워크북을 .NET을 통해 Python용 Aspose.Slides를 사용하여 PowerPoint 프레젠테이션에 삽입하는 방법을 보여줍니다. 삽입된 워크북에는 원본 데이터와 차트가 모두 포함됩니다. 별도의 PNG 미리보기가 OLE 개체가 활성화되기 전에 슬라이드에 차트를 표시합니다.

결과는 네이티브 PowerPoint 차트가 아닌 삽입된 Excel 개체입니다. OLE를 통해 워크북을 편집하려면 OLE 활성화를 지원하는 데스크톱 애플리케이션과 호환되는 Excel이 설치되어 있어야 합니다.

## **전제 조건**

`aspose-cells-python` 및 `aspose-slides` 패키지를 Python 환경에 설치하십시오. Microsoft Office는 이러한 라이브러리를 사용해 프레젠테이션을 생성하는 데 필요하지 않습니다.

입력 파일이 필요하지 않습니다. 예제는 메모리에서 데이터와 차트를 생성한 다음 `OutputChart.pptx`를 현재 작업 디렉터리에 기록합니다. 평가 모드가 아닌 경우 두 제품 모두에 대한 라이선스를 적용하십시오.

## **삽입 작동 방식**

1. 데이터 워크시트와 차트 시트를 포함하는 워크북을 생성합니다.
1. 차트 시트를 활성화하여 워크북이 차트에서 열리도록 합니다.
1. 워크북의 OLE 표시 범위를 설정하고 차트를 PNG로 렌더링합니다.
1. 워크북을 메모리에서 XLSX 형식으로 저장하고 해당 바이트를 슬라이드에 삽입합니다.
1. PNG를 OLE 개체의 미리보기로 지정하고 프레젠테이션을 PPTX 형식으로 저장합니다.

워크북 표시 범위와 슬라이드의 프레임은 서로 다른 역할을 합니다. [set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/)은 0부터 시작하는 시작/끝 행 및 열 인덱스를 사용합니다. [ChartCollection.add](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chartcollection/add/)은 대신 최상위 행, 왼쪽 열, 최하위 행, 오른쪽 열을 사용합니다. 예제에서는 행 인덱스 55와 열 인덱스 25를 오른쪽 하단 경계로 사용합니다; 이러한 값은 레이아웃 선택이며 데이터 행이나 열의 수를 의미하지 않습니다.

슬라이드 프레임은 포인트 단위를 사용합니다. 예제에서는 PNG의 가로세로 비율을 유지하면서 슬라이드에 맞게 크기를 조정하고 중앙에 배치하여 미리보기가 슬라이드를 가득 채우도록 늘어나지 않도록 합니다.

## **차트 만들기 및 삽입**

다음 전체 예제는 `DataSheet`에 4개의 행과 5개의 열 값을 채웁니다. 각 행은 차트 시리즈가 됩니다. 워크북을 저장하기 전에 `ChartSheet`를 활성 시트로 선택합니다.

워크북은 명시적으로 XLSX 형식으로 저장되며, 이는 [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/)에 전달된 `xlsx` 확장자와 일치합니다. PNG는 중간 비트맵 변환 없이 스트림에서 직접 로드됩니다. [substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/ioleobjectframe/substitute_picture_format/)을 통해 할당하면 기본 OLE 자리 표시자를 교체합니다.

```python
import io
import aspose.cells as cells
import aspose.cells.charts as charts
import aspose.cells.drawing as drawing
import aspose.slides as slides

workbook = cells.Workbook()
data_sheet = workbook.worksheets[0]
data_sheet.name = "DataSheet"

values = [
    [67, 44, 46, 43, 24],
    [86, 64, 97, 29, 40],
    [68, 89, 78, 69, 38],
    [91, 48, 60, 26, 25],
]

for row, row_values in enumerate(values):
    for column, value in enumerate(row_values):
        data_sheet.cells.get(row, column).put_value(value)

chart_sheet_index = workbook.worksheets.add(cells.SheetType.CHART)
chart_sheet = workbook.worksheets[chart_sheet_index]
chart_sheet.name = "ChartSheet"

last_chart_row = 55
last_chart_column = 25
chart_index = chart_sheet.charts.add(charts.ChartType.COLUMN, 0, 0, last_chart_row, last_chart_column)
chart = chart_sheet.charts[chart_index]
for row in range(1, len(values) + 1):
    chart.n_series.add(f"DataSheet!A{row}:E{row}", False)

workbook.worksheets.active_sheet_index = chart_sheet_index
workbook.worksheets.set_ole_size(0, last_chart_row, 0, last_chart_column)

# 차트 미리보기를 렌더링하고 편집 가능한 워크북을 별도로 직렬화합니다.
with io.BytesIO() as chart_image_stream, io.BytesIO() as workbook_stream:
    chart.to_image(chart_image_stream, drawing.ImageType.PNG)
    chart_image_stream.seek(0)
    workbook.save(workbook_stream, cells.SaveFormat.XLSX)
    workbook_bytes = workbook_stream.getvalue()

    with slides.Images.from_stream(chart_image_stream) as chart_image:
        with slides.Presentation() as presentation:
            slide = presentation.slides[0]
            slide_size = presentation.slide_size.size

            # 미리보기를 슬라이드 내에 맞추되 가로세로 비율을 변경하지 않습니다.
            scale = min(slide_size.width / chart_image.width, slide_size.height / chart_image.height)
            frame_width = chart_image.width * scale
            frame_height = chart_image.height * scale
            frame_x = (slide_size.width - frame_width) / 2
            frame_y = (slide_size.height - frame_height) / 2

            embedded_data = slides.dom.ole.OleEmbeddedDataInfo(workbook_bytes, "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(frame_x, frame_y, frame_width, frame_height, embedded_data)
            preview_image = presentation.images.add_image(chart_image)
            ole_frame.substitute_picture_format.picture.image = preview_image

            presentation.save("OutputChart.pptx", slides.export.SaveFormat.PPTX)
```

## **예상 결과**

`OutputChart.pptx`에는 삽입된 Excel 워크북과 차트 미리보기가 있는 하나의 슬라이드가 포함됩니다. 워크북에는 원본 데이터와 네 개의 시리즈가 있는 세로 막대 차트가 포함됩니다. 미리보기는 슬라이드 중앙에 배치되고 비율을 유지합니다.

![삽입된 워크북의 미리보기로 표시된 Excel 세로 막대 차트](excel-chart-ole-preview.png)

Excel이 설치된 호환 가능한 데스크톱 PowerPoint 환경에서는 개체를 더블 클릭하여 삽입된 워크북을 활성화하고 편집할 수 있습니다. 활성화 및 편집은 호스트 애플리케이션의 OLE 지원 및 보안 설정에 따라 달라집니다.

## **자주 묻는 질문**

**미리보기 이미지가 필요한 이유는 무엇입니까?**

삽입된 워크북과 슬라이드 미리보기는 별개의 콘텐츠입니다. 차트 이미지를 제공하여 슬라이드가 기본 "EMBEDDED OLE OBJECT" 자리 표시자 대신 차트를 표시하도록 합니다. [Object Preview Issue when Adding OleObjectFrame](/slides/ko/python-net/object-preview-issue-when-adding-oleobjectframe/)를 참조하십시오.

**코드에서 워크북을 변경하면 미리보기가 자동으로 업데이트됩니까?**

미리보기를 스냅샷으로 간주하십시오. 워크북 데이터를 프로그래밍 방식으로 업데이트할 때 차트 이미지를 새로 생성하고 미리보기와 삽입된 워크북 데이터를 모두 교체해야 합니다.

**XLS 대신 XLSX를 사용할 수 있나요?**

예. 워크북을 XLS 형식으로 저장하고 `xls`를 삽입된 데이터 확장자로 사용하십시오. 확장자는 실제 워크북 형식과 일치해야 하며, 확장자만 변경해도 데이터가 변환되지 않습니다.

**활성화 후 개체 크기가 변할 수 있는 이유는 무엇입니까?**

호스트 애플리케이션은 워크북을 활성화할 때 OLE 개체의 표시를 업데이트할 수 있습니다. 워크북의 OLE 표시 범위와 슬라이드 프레임 크기가 모두 중요합니다. [Resize OLE Objects Automatically in PowerPoint Presentations](/slides/ko/python-net/working-solution-for-worksheet-resizing/)를 참고하십시오.

## **관련 섹션**

- [PowerPoint 프레젠테이션에서 OLE 개체 자동 크기 조정](/slides/ko/python-net/working-solution-for-worksheet-resizing/)
- [OleObjectFrame 추가 시 객체 미리보기 문제](/slides/ko/python-net/object-preview-issue-when-adding-oleobjectframe/)
- [OLE 개체 관리](/slides/ko/python-net/manage-ole/)