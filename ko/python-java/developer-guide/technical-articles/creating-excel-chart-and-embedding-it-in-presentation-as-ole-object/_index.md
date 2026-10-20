---
title: Excel 차트를 생성하고 OLE 개체로 프레젠테이션에 삽입하기
type: docs
weight: 30
url: /ko/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel 차트
- 차트 삽입
- OLE 개체
- PowerPoint
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Cells for Python via Java를 사용해 Excel 차트를 생성하고, Aspose.Slides를 사용해 워크북을 PowerPoint 프레젠테이션에 삽입합니다. 차트 미리 보기가 포함됩니다."
---
## **개요**

이 문서에서는 Aspose.Cells for Python via Java를 사용하여 Excel 세로 막대형 차트를 만든 다음, Aspose.Slides for Python via Java를 사용해 해당 워크북을 PowerPoint 프레젠테이션에 삽입하는 방법을 보여줍니다. 삽입된 워크북에는 원본 데이터와 차트가 모두 포함됩니다. 별도의 PNG 미리 보기가 OLE 개체가 활성화되기 전에 슬라이드에 차트를 표시합니다.

결과는 PowerPoint 기본 차트가 아니라 삽입된 Excel 개체입니다. OLE을 통해 워크북을 편집하려면 OLE 활성화를 지원하는 데스크톱 응용 프로그램과 호환되는 Excel이 설치되어 있어야 합니다.

## **전제 조건**

`aspose-cells`와 `aspose-slides-java` Python 패키지 및 호환 가능한 Java 런타임을 설치합니다. JVM을 시작하기 전에 두 패키지를 모두 임포트하여 JPype에서 Java 라이브러리를 사용할 수 있도록 합니다. 이러한 라이브러리를 사용하여 프레젠테이션을 생성하는 데 Microsoft Office는 필요하지 않습니다.

입력 파일이 필요하지 않습니다. 예제는 메모리에서 데이터와 차트를 생성한 후 `OutputChart.pptx`를 현재 작업 디렉터리에 씁니다. 평가 모드가 아닌 경우 두 제품 모두에 대한 라이선스를 적용하십시오.

## **삽입 작동 방식**

1. 데이터 워크시트와 차트 시트가 포함된 워크북을 생성합니다.  
1. 차트 시트를 활성화하여 워크북이 차트에서 열리도록 합니다.  
1. 워크북의 OLE 표시 범위를 설정하고 차트를 PNG로 렌더링합니다.  
1. 워크북을 메모리 내 XLSX 형태로 저장하고 해당 바이트를 슬라이드에 삽입합니다.  
1. PNG를 OLE 개체의 미리 보기로 지정하고 프레젠테이션을 PPTX로 저장합니다.

워크북 표시 범위와 슬라이드의 프레임은 서로 다른 역할을 합니다. [setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) 은 0 기반 시작/끝 행 및 열 인덱스를 사용합니다. [ChartCollection.add](https://reference.aspose.com/cells/python-java/asposecells.api/chartcollection/#add) 은 대신 상단 행, 왼쪽 열, 하단 행, 오른쪽 열을 사용합니다. 예제에서는 오른쪽 아래 경계값으로 행 인덱스 55와 열 인덱스 25를 사용합니다; 이 값들은 레이아웃 선택이며 데이터 행 또는 열 수를 의미하지 않습니다.

슬라이드 프레임은 포인트 단위로 지정됩니다. 예제는 슬라이드 안에 프레임을 맞추고 PNG의 가로세로 비율을 유지하면서 가운데 정렬합니다. 미리 보기를 슬라이드 전체에 늘리지 않습니다.

## **차트 만들기 및 삽입**

다음 완전한 예제는 `DataSheet`에 4행 5열의 값을 채웁니다. 각 행은 차트 시리즈가 됩니다. `ChartSheet`를 활성 시트로 선택한 후 워크북을 저장합니다.

워크북은 `xlsx` 확장자를 전달하는 [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-java/aspose.slides/oleembeddeddatainfo/)와 일치하도록 명시적으로 XLSX 형식으로 저장됩니다. Java 바이트 배열 스트림은 워크북과 이미지를 메모리 내에 보관하고 Java API에 필요한 바이트 배열을 제공합니다. PNG는 중간 비트맵 변환 없이 바이트에서 직접 로드됩니다. [getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) 을 통해 할당하면 기본 OLE 자리 표시자가 교체됩니다.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ChartType, SheetType, ImageOrPrintOptions, ImageType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Images, OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

workbook = Workbook()
try:
    data_sheet = workbook.getWorksheets().get(0)
    data_sheet.setName("DataSheet")

    values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25],
    ]
    for row, row_values in enumerate(values):
        for column, value in enumerate(row_values):
            data_sheet.getCells().get(row, column).putValue(jpype.JInt(value))

    chart_sheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(chart_sheet_index)
    chart_sheet.setName("ChartSheet")

    last_chart_row = 55
    last_chart_column = 25
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, 0, last_chart_row, last_chart_column)
    chart = chart_sheet.getCharts().get(chart_index)
    for row in range(1, len(values) + 1):
        chart.getNSeries().add(f"DataSheet!A{row}:E{row}", False)

    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)
    workbook.getWorksheets().setOleSize(0, last_chart_row, 0, last_chart_column)

    # 차트 미리 보기를 렌더링하고 편집 가능한 워크북을 별도로 직렬화합니다.
    image_options = ImageOrPrintOptions()
    image_options.setImageType(ImageType.PNG)
    chart_image_stream = ByteArrayOutputStream()
    chart.toImage(chart_image_stream, image_options)
    chart_image_bytes = chart_image_stream.toByteArray()

    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.XLSX)
    workbook_bytes = workbook_stream.toByteArray()

    chart_image = Images.fromData(chart_image_bytes)
    try:
        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)
            slide_width = presentation.getSlideSize().getSize().getWidth()
            slide_height = presentation.getSlideSize().getSize().getHeight()

            # 미리 보기를 슬라이드 안에 맞추되 종횡비를 변경하지 않습니다.
            scale = min(slide_width / chart_image.getWidth(), slide_height / chart_image.getHeight())
            frame_width = chart_image.getWidth() * scale
            frame_height = chart_image.getHeight() * scale
            frame_x = (slide_width - frame_width) / 2
            frame_y = (slide_height - frame_height) / 2

            embedded_data = OleEmbeddedDataInfo(workbook_bytes, "xlsx")
            ole_frame = slide.getShapes().addOleObjectFrame(frame_x, frame_y, frame_width, frame_height, embedded_data)
            preview_image = presentation.getImages().addImage(chart_image)
            ole_frame.getSubstitutePictureFormat().getPicture().setImage(preview_image)

            presentation.save("OutputChart.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        chart_image.dispose()
finally:
    workbook.dispose()
```

## **예상 결과**

`OutputChart.pptx`에는 삽입된 Excel 워크북과 차트 미리 보기가 포함된 슬라이드가 하나 들어 있습니다. 워크북에는 원본 데이터와 4개의 시리즈가 있는 세로 막대형 차트가 들어 있습니다. 미리 보기는 슬라이드 가운데에 위치하고 비율을 유지합니다.

![Excel column chart displayed as the preview of an embedded workbook](excel-chart-ole-preview.png)

호환 가능한 데스크톱 PowerPoint 환경에서 Excel이 설치되어 있으면 개체를 두 번 클릭하여 활성화하고 삽입된 워크북을 편집할 수 있습니다. 활성화 및 편집은 호스트 응용 프로그램의 OLE 지원 및 보안 설정에 따라 달라집니다.

## **FAQ**

**미리 보기 이미지가 필요한 이유는?**

삽입된 워크북과 슬라이드 미리 보기는 별개의 콘텐츠입니다. 슬라이드가 기본 "EMBEDDED OLE OBJECT" 자리 표시자가 아닌 차트를 표시하도록 차트 이미지를 제공하십시오. 자세한 내용은 [OleObjectFrame 추가 시 객체 미리 보기 문제](/slides/ko/python-java/object-preview-issue-when-adding-oleobjectframe/)를 참조하십시오.

**코드에서 워크북을 변경하면 미리 보기가 자동으로 업데이트되나요?**

미리 보기는 스냅샷으로 취급합니다. 프로그램matically 워크북 데이터를 업데이트할 때 차트 이미지를 다시 생성하고 미리 보기와 삽입된 워크북 데이터를 모두 교체해야 합니다.

**XLS 대신 XLSX를 사용할 수 있나요?**

예. 워크북을 XLS 형식으로 저장하고 `xls`를 삽입된 데이터 확장자로 사용하십시오. 확장자는 실제 워크북 형식과 일치해야 하며, 확장자만 변경해도 데이터가 변환되지 않습니다.

**활성화 후 개체 크기가 변할 수 있는 이유는?**

호스트 응용 프로그램은 워크북을 활성화할 때 OLE 개체의 표시를 업데이트할 수 있습니다. 워크북의 OLE 표시 범위와 슬라이드 프레임 크기 모두가 영향을 미칩니다. 자세한 내용은 [PPTX에서 차트 크기 조정에 대한 작업 솔루션](/slides/ko/python-java/working-solution-for-chart-resizing-in-pptx/)을 확인하십시오.

## **관련 섹션**

- [PPTX에서 차트 크기 조정에 대한 작업 솔루션](/slides/ko/python-java/working-solution-for-chart-resizing-in-pptx/)
- [OleObjectFrame 추가 시 객체 미리 보기 문제](/slides/ko/python-java/object-preview-issue-when-adding-oleobjectframe/)