---
title: PPTX에서 차트 크기 조정을 위한 실전 해결책
type: docs
weight: 40
url: /ko/python-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- 차트 크기 조정
- Excel 차트
- OLE 개체
- 차트 삽입
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 삽입된 Excel OLE 개체와 함께 PPTX에서 발생하는 예기치 않은 차트 크기 조정을 해결합니다. 크기를 일관되게 유지하기 위한 두 가지 방법과 코드를 배웁니다."
---
## **배경**

Aspose 구성 요소를 통해 PowerPoint 프레젠테이션에 OLE 개체로 삽입된 Excel 차트가 첫 번째 활성화 후 지정되지 않은 비율로 크기가 조정되는 현상이 관찰되었습니다. 이 동작은 차트의 활성화 전후 상태 사이에 눈에 띄는 시각적 차이를 발생시킵니다. Aspose 팀은 문제를 상세히 조사한 결과 해결책을 찾았습니다. 이 문서는 문제의 원인과 해당 해결 방법을 설명합니다.

[이전 기사](/slides/ko/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)에서는 Aspose.Cells for Python via Java를 사용해 Excel 차트를 만들고 Aspose.Slides for Python via Java를 사용해 PowerPoint 프레젠테이션에 OLE 개체로 삽입하는 방법을 설명했습니다. [객체 미리 보기 문제](/slides/ko/python-java/object-preview-issue-when-adding-oleobjectframe/)를 해결하기 위해 차트 이미지를 차트의 OLE 개체 프레임에 할당했습니다. 출력 프레젠테이션에서 차트 이미지를 표시하는 OLE 개체 프레임을 더블 클릭하면 Excel 차트가 활성화됩니다. 최종 사용자는 기본 Excel 워크북에서 원하는 변경을 수행한 뒤 활성화된 워크북 외부를 클릭하여 해당 슬라이드로 돌아갈 수 있습니다. 사용자가 슬라이드로 돌아올 때 OLE 개체 프레임의 크기가 변하며, 크기 조정 비율은 OLE 개체 프레임과 삽입된 Excel 워크북의 원래 크기에 따라 달라집니다.

## **크기 조정 원인**

Excel 워크북은 자체 창 크기를 가지고 있어 첫 번째 활성화 시 원래 크기를 유지하려고 합니다. 반면 OLE 개체 프레임은 자체 크기를 갖습니다. Microsoft에 따르면 Excel 워크북이 활성화될 때 Excel과 PowerPoint가 크기를 협상하여 삽입 프로세스의 일환으로 올바른 비율을 유지합니다. Excel 창 크기와 OLE 개체 프레임의 크기 또는 위치 차이에 따라 크기 조정이 발생합니다.

## **작업 해결책**

Aspose.Slides for Python via Java를 사용해 PowerPoint 프레젠테이션을 만드는 두 가지 시나리오가 있습니다.

**시나리오 1:** 기존 템플릿을 기반으로 프레젠테이션을 생성합니다.

**시나리오 2:** 처음부터 프레젠테이션을 생성합니다.

여기서 제공하는 해결책은 두 시나리오 모두에 적용됩니다. 모든 해결 접근 방식의 기본은 **삽입된 OLE 개체의 창 크기가 PowerPoint 슬라이드의 OLE 개체 프레임 크기와 일치해야 한다**는 점입니다. 이제 두 가지 접근 방식을 논의하겠습니다.

## **첫 번째 접근법**

이 접근법에서는 삽입된 Excel 워크북의 창 크기를 PowerPoint 슬라이드의 OLE 개체 프레임 크기와 일치하도록 설정하는 방법을 배웁니다.

**시나리오 1**

템플릿을 정의하고 해당 템플릿을 기반으로 프레젠테이션을 만들고자 한다고 가정해 보겠습니다. 템플릿의 인덱스 2에 OLE 프레임을 배치하려는 도형이 있다고 가정합니다. 이 경우 OLE 개체 프레임의 크기는 미리 정의되어 있으며—템플릿의 인덱스 2 도형 크기와 일치합니다. 해야 할 일은 워크북의 창 크기를 해당 도형 크기와 동일하게 설정하는 것입니다. 아래 코드 스니펫이 그 목적을 수행합니다:

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# 차트를 포함하는 Excel 워크북을 로드합니다.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(2)

    # 워크북 창 크기를 인치 단위로 설정합니다 (PowerPoint는 인치당 72 포인트를 사용합니다).
    workbook.getSettings().setWindowWidthInch(shape.getWidth() / 72.0)
    workbook.getSettings().setWindowHeightInch(shape.getHeight() / 72.0)

    # 워크북을 메모리 스트림에 저장합니다.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # 삽입된 Excel 데이터를 사용해 OLE 개체 프레임을 생성합니다.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), data_info)
finally:
    presentation.dispose()
```

**시나리오 2**

처음부터 프레젠테이션을 만들고 임의 크기의 OLE 개체 프레임에 삽입된 Excel 워크북을 포함하고자 한다고 가정합니다. 아래 코드 스니펫에서는 슬라이드의 x = 0.5인치, y = 1인치 위치에 높이 4인치, 너비 9.5인치인 OLE 개체 프레임을 생성합니다. 그런 다음 Excel 워크북 창을 동일한 크기—높이 4인치, 너비 9.5인치—로 설정합니다.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# 차트를 포함하는 Excel 워크북을 로드합니다.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    desired_height = 288  # 4인치 (4 * 72).
    desired_width = 684  # 9.5인치 (9.5 * 72).

    # 창을 사용하여 차트 크기를 정의합니다.
    chart.setSizeWithWindow(True)

    # 워크북 창 크기를 인치 단위로 설정합니다 (PowerPoint는 인치당 72 포인트를 사용합니다).
    workbook.getSettings().setWindowWidthInch(desired_width / 72.0)
    workbook.getSettings().setWindowHeightInch(desired_height / 72.0)

    # 워크북을 메모리 스트림에 저장합니다.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # 삽입된 Excel 데이터를 사용해 OLE 개체 프레임을 생성합니다.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(36.0, 72.0, desired_width, desired_height, data_info)
finally:
    presentation.dispose()
```

## **두 번째 접근법**

이 접근법에서는 삽입된 Excel 워크북 내 차트의 크기를 PowerPoint 슬라이드의 OLE 개체 프레임 크기와 일치하도록 설정하는 방법을 배웁니다. 차트 크기가 사전에 알려져 있고 이후에 변하지 않을 경우에 유용합니다.

**시나리오 1**

템플릿을 정의하고 해당 템플릿을 기반으로 프레젠테이션을 만들고자 한다고 가정해 보겠습니다. 템플릿의 인덱스 2에 OLE 프레임을 배치하려는 도형이 있다고 가정합니다. 이 경우 OLE 프레임 크기는 미리 정의되어 있으며—템플릿의 인덱스 2 도형 크기와 일치합니다. 해야 할 일은 워크북 내 차트 크기를 해당 도형 크기와 동일하게 설정하는 것입니다. 아래 코드 스니펫이 그 목적을 수행합니다:

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpime.JClass("java.io.ByteArrayOutputStream")

# 차트를 포함하는 Excel 워크북을 로드합니다.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(2)

    # 창 없이 차트 크기를 정의합니다.
    chart.setSizeWithWindow(False)

    # 차트 크기를 픽셀 단위로 설정합니다 (Excel은 인치당 96픽셀을 사용합니다).
    chart.getChartObject().setWidth(int((shape.getWidth() / 72.0) * 96.0))
    chart.getChartObject().setHeight(int((shape.getHeight() / 72.0) * 96.0))

    # 차트 인쇄 크기를 정의합니다.
    chart.setPrintSize(PrintSizeType.CUSTOM)

    # 워크북을 메모리 스트림에 저장합니다.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # 삽입된 Excel 데이터를 사용해 OLE 개체 프레임을 생성합니다.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), data_info)
finally:
    presentation.dispose()
```

**시나리오 2**:

처음부터 프레젠테이션을 만들고 임의 크기의 OLE 개체 프레임에 삽입된 Excel 워크북을 포함하고자 한다고 가정합니다. 아래 코드 스니펫에서는 슬라이드의 x = 0.5인치, y = 1인치 위치에 높이 4인치, 너비 9.5인치인 OLE 개체 프레임을 생성합니다. 또한 차트 크기도 동일한 차원—높이 4인치, 너비 9.5인치—으로 설정합니다.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# 차트를 포함하는 Excel 워크북을 로드합니다.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    desired_height = 288  # 4인치 (4 * 72).
    desired_width = 684  # 9.5인치 (9.5 * 72).

    # 창 없이 차트 크기를 정의합니다.
    chart.setSizeWithWindow(False)

    # 차트 크기를 픽셀 단위로 설정합니다 (Excel은 인치당 96픽셀을 사용합니다).
    chart.getChartObject().setWidth(int((desired_width / 72.0) * 96.0))
    chart.getChartObject().setHeight(int((desired_height / 72.0) * 96.0))

    # 워크북을 메모리 스트림에 저장합니다.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # 삽입된 Excel 데이터를 사용해 OLE 개체 프레임을 생성합니다.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(36.0, 72.0, desired_width, desired_height, data_info)
finally:
    presentation.dispose()
```

## **결론**

차트 크기 조정 문제를 해결하는 두 가지 접근법이 있습니다. 접근법 선택은 요구 사항과 사용 사례에 따라 다릅니다. 두 접근법 모두 템플릿 기반이든 처음부터 만든 것이든 동일하게 작동합니다. 또한 이 해결책에서는 OLE 개체 프레임 크기에 제한이 없습니다.

## **FAQ**

**PowerPoint에서 활성화한 후 내 삽입된 Excel 차트 크기가 왜 변하나요?**

Excel이 첫 활성화 시 원래 창 크기를 복원하려고 시도하는 반면, PowerPoint의 OLE 개체 프레임은 자체 치수를 가지고 있기 때문입니다. PowerPoint와 Excel이 비율을 유지하기 위해 크기를 협상하면서 크기 조정이 발생합니다.

**이 크기 조정 문제를 완전히 방지할 수 있나요?**

예. 삽입하기 전에 Excel 워크북 창 크기 또는 차트 크기를 OLE 개체 프레임 크기와 일치시키면 차트 크기를 일관되게 유지할 수 있습니다.

**워크북 창 크기 설정과 차트 크기 설정 중 어느 접근법을 선택해야 하나요?**

워크북의 비율을 유지하고 이후에 크기 조정을 허용하고 싶다면 **접근법 1(창 크기)**을 사용하세요.  
차트 치수가 고정되어 있으며 삽입 후 변하지 않을 경우 **접근법 2(차트 크기)**를 사용하세요.

**이 방법들은 템플릿 기반 프레젠테이션과 새 프레젠테이션 모두에 적용되나요?**

예. 두 접근법 모두 템플릿으로 만든 프레젠테이션과 처음부터 만든 프레젠테이션에 동일하게 적용됩니다.

**OLE 개체 프레임 크기에 제한이 있나요?**

아니요. 워크북이나 차트 크기에 맞게 적절히 스케일링되는 한 OLE 프레임을 원하는 크기로 설정할 수 있습니다.

**다른 스프레드시트 프로그램으로 만든 차트에도 이 방법을 사용할 수 있나요?**

예시 코드는 Aspose.Cells를 사용해 만든 Excel 차트를 대상으로 하지만, 유사한 크기 조정 옵션을 지원하는 OLE 호환 스프레드시트 프로그램에도 원칙을 적용할 수 있습니다.

## **관련 섹션**

- [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/ko/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)