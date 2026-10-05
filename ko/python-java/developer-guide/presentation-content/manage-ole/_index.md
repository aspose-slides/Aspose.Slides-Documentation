---
title: Python을 사용하여 프레젠테이션에서 OLE 관리
linktitle: OLE 관리
type: docs
weight: 40
url: /ko/python-java/manage-ole/
keywords:
- OLE 개체
- 객체 연결 및 임베딩
- OLE 추가
- OLE 임베드
- 개체 추가
- 개체 임베드
- 파일 추가
- 파일 임베드
- 연결된 개체
- 연결된 파일
- OLE 변경
- OLE 아이콘
- OLE 제목
- OLE 추출
- 개체 추출
- 파일 추출
- PowerPoint
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 PowerPoint 및 OpenDocument 파일에서 OLE 개체 관리를 최적화합니다. OLE 콘텐츠를 원활하게 임베드, 업데이트 및 내보냅니다."
---
## **소개**

{{% alert color="info" title="참고" %}}
OLE(Object Linking & Embedding)는 한 애플리케이션에서 만든 데이터와 개체를 다른 애플리케이션에 링크하거나 임베드하여 배치할 수 있게 해 주는 Microsoft 기술입니다.
{{% /alert %}}

MS Excel에서 만든 차트를 생각해 보세요. 그 차트를 PowerPoint 슬라이드에 넣은 경우, 해당 Excel 차트는 OLE 개체로 간주됩니다.

- OLE 개체는 아이콘으로 표시될 수 있습니다. 이 경우 아이콘을 더블 클릭하면 차트가 연결된 애플리케이션(Excel)에서 열리거나, 개체를 열거나 편집할 애플리케이션을 선택하라는 메시지가 표시됩니다.
- OLE 개체는 차트와 같은 실제 내용을 표시할 수도 있습니다. 이 경우 차트가 PowerPoint에서 활성화되고 차트 인터페이스가 로드되어 PowerPoint 내에서 차트 데이터를 수정할 수 있습니다.

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/python-java/)를 사용하면 OLE 개체 프레임([OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/))으로 슬라이드에 OLE 개체를 삽입할 수 있습니다.

## **슬라이드에 OLE 개체 프레임 추가**

Microsoft Excel에서 차트를 이미 만들고 이를 Aspose.Slides for Python via Java를 사용해 OLE 개체 프레임으로 슬라이드에 임베드하려는 경우 다음과 같이 수행할 수 있습니다:

1. [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
3. Excel 파일을 바이트 배열로 읽어들입니다.
4. 바이트 배열 및 OLE 개체에 대한 기타 정보를 포함하여 슬라이드에 [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/)을 추가합니다.
5. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예제에서는 Aspose.Slides for Python via Java를 사용해 Excel 파일의 차트를 OLE 개체 프레임으로 슬라이드에 추가했습니다.
**노트**: [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-java/aspose.slides/oleembeddeddatainfo/) 생성자는 두 번째 매개변수로 임베드 가능한 개체 확장자를 받습니다. 이 확장자는 PowerPoint가 파일 유형을 올바르게 해석하고 해당 OLE 개체를 열 적절한 애플리케이션을 선택하도록 도와줍니다.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    slide = presentation.getSlides().get_Item(0)

    # OLE 개체를 위한 데이터를 준비합니다.
    file_data = Path("book.xlsx").read_bytes()
    file_data = jpype.JArray(jpype.JByte)(file_data)
    data_info = OleEmbeddedDataInfo(file_data, "xlsx")

    # Add the OLE object frame to the slide.
    frame_width = jpype.JFloat(slide_size.getWidth())
    frame_height = jpype.JFloat(slide_size.getHeight())
    slide.getShapes().addOleObjectFrame(0, 0, frame_width, frame_height, data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **링크된 OLE 개체 프레임 추가**

Aspose.Slides for Python via Java를 사용하면 임베드된 데이터 대신 파일에 대한 링크를 포함하는 [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/)을 추가할 수 있습니다.

다음 Python 코드는 Excel 파일에 대한 링크를 포함한 [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/)을 슬라이드에 추가하는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # 링크된 Excel 파일이 있는 OLE 개체 프레임을 추가합니다.
    slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **OLE 개체 프레임 액세스**

슬라이드에 OLE 개체가 이미 임베드된 경우 다음과 같이 쉽게 찾거나 액세스할 수 있습니다:

1. [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성하여 임베드된 OLE 개체가 포함된 프레젠테이션을 로드합니다.
2. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
3. [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) 모양에 액세스합니다. 예제에서는 첫 번째 슬라이드에 하나의 모양만 있는 앞서 만든 PPTX를 사용했습니다. 그런 다음 해당 개체가 [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/)인지 확인했습니다. 이것이 접근하려는 OLE 개체 프레임이었습니다.
4. OLE 개체 프레임에 접근한 후에는 원하는 작업을 수행할 수 있습니다.

아래 예제에서는 슬라이드에 임베드된 Excel 차트 개체와 해당 파일 데이터를 액세스합니다.

```python
import jpype
import asposeslides

if not jpile.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        # 임베드된 파일 데이터를 가져옵니다.
        file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()

        # 임베드된 파일의 확장자를 가져옵니다.
        file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()

        # ...
finally:
    presentation.dispose()
```

### **링크된 OLE 개체 프레임 속성 액세스**

Aspose.Slides를 사용하면 링크된 OLE 개체 프레임 속성을 확인할 수 있습니다.

다음 Python 코드는 OLE 개체가 링크된 상태인지 확인하고, 링크된 파일 경로를 얻는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.ppt")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        # OLE 개체가 링크되어 있는지 확인합니다.
        if ole_frame.isObjectLink():
            # 링크된 파일의 전체 경로를 출력합니다.
            print("OLE object frame is linked to: " + str(ole_frame.getLinkPathLong()))

            # 존재하는 경우 링크된 파일의 상대 경로를 출력합니다.
            # PPT 프레젠테이션만 상대 경로를 포함할 수 있습니다.
            relative_path = ole_frame.getLinkPathRelative()
            if relative_path is not None and not relative_path.isEmpty():
                print("OLE object frame relative path: " + str(relative_path))
finally:
    presentation.dispose()
```

## **OLE 개체 데이터 변경**

{{% alert color="info" title="참고" %}}
이 섹션의 코드 예제는 [Aspose.Cells for Python via Java](https://products.aspose.com/cells/python-java/)를 사용합니다.
{{% /alert %}}

슬라이드에 OLE 개체가 이미 임베드된 경우 다음과 같이 해당 개체에 접근해 데이터를 수정할 수 있습니다:

1. [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성하여 임베드된 OLE 개체가 포함된 프레젠테이션을 로드합니다.
2. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
3. OLE 개체 프레임 모양에 액세스합니다. 예제에서는 첫 번째 슬라이드에 하나의 모양만 있는 앞서 만든 PPTX를 사용했습니다. 그런 다음 해당 개체가 [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/)인지 확인했습니다. 이것이 접근하려는 OLE 개체 프레임이었습니다.
4. OLE 개체 프레임에 접근한 후에는 원하는 작업을 수행할 수 있습니다.
5. [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) 객체를 생성하고 OLE 데이터를 액세스합니다.
6. 원하는 [Worksheet](https://reference.aspose.com/cells/python-java/asposecells.api/worksheet/)에 접근하여 데이터를 수정합니다.
7. 업데이트된 [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/)을 스트림에 저장합니다.
8. 스트림에서 OLE 개체 데이터를 변경합니다.

아래 예제에서는 슬라이드에 임베드된 Excel 차트 개체를 액세스하고 파일 데이터를 수정해 차트 데이터를 업데이트합니다.

```python
import jpype
import asposeslides
import asposecells

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, OleObjectFrame, Presentation, SaveFormat
from asposecells.api import Workbook, OoxmlSaveOptions
from asposecells.api import SaveFormat as CellsSaveFormat
from java.io import ByteArrayInputStream, ByteArrayOutputStream

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()
        ole_stream = ByteArrayInputStream(file_data)

        # OLE 개체 데이터를 Workbook 객체로 읽어옵니다.
        workbook = Workbook(ole_stream)

        new_ole_stream = ByteArrayOutputStream()

        # 워크북 데이터를 수정합니다.
        cells = workbook.getWorksheets().get(0).getCells()
        cells.get(0, 4).putValue("E")
        cells.get(1, 4).putValue(jpype.JInt(12))
        cells.get(2, 4).putValue(jpype.JInt(14))
        cells.get(3, 4).putValue(jpype.JInt(15))

        file_options = OoxmlSaveOptions(CellsSaveFormat.XLSX)
        workbook.save(new_ole_stream, file_options)

        # OLE 프레임 개체 데이터를 변경합니다.
        new_file_data = new_ole_stream.toByteArray()
        new_data = OleEmbeddedDataInfo(new_file_data, ole_frame.getEmbeddedData().getEmbeddedFileExtension())
        ole_frame.setEmbeddedData(new_data)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **다른 파일 형식 슬라이드에 임베드**

Excel 차트 외에도 Aspose.Slides for Python via Java를 사용하면 HTML, PDF, ZIP 파일과 같은 다양한 형식의 파일을 슬라이드에 객체로 삽입할 수 있습니다. 사용자가 삽입된 객체를 더블 클릭하면 해당 프로그램에서 자동으로 열리거나, 적절한 프로그램을 선택하라는 프롬프트가 표시됩니다.

다음 Python 코드는 HTML 및 ZIP 파일을 슬라이드에 임베드하는 방법을 보여줍니다:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    html_data = Path("sample.html").read_bytes()
    html_data = jpype.JArray(jpype.JByte)(html_data)
    html_data_info = OleEmbeddedDataInfo(html_data, "html")
    html_ole_frame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, html_data_info)
    html_ole_frame.setObjectIcon(True)

    zip_data = Path("sample.zip").read_bytes()
    zip_data = jpype.JArray(jpype.JByte)(zip_data)
    zip_data_info = OleEmbeddedDataInfo(zip_data, "zip")
    zip_ole_frame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zip_data_info)
    zip_ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **임베드된 객체 파일 형식 지정**

프레젠테이션 작업 중에 기존 OLE 개체를 새 개체로 교체하거나 지원되지 않는 OLE 개체를 지원되는 개체로 바꿔야 할 때가 있습니다. Aspose.Slides for Python via Java를 사용하면 임베드된 객체의 파일 형식을 지정하여 OLE 프레임 데이터나 확장자를 업데이트할 수 있습니다.

다음 Python 코드는 임베드된 OLE 객체의 파일 형식을 `zip`으로 설정하는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()
    file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()

    print("Current embedded file extension is: " + str(file_extension))

    # 파일 형식을 ZIP으로 변경합니다.
    data_info = OleEmbeddedDataInfo(file_data, "zip")
    ole_frame.setEmbeddedData(data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **임베드된 객체 아이콘 이미지 및 제목 설정**

OLE 객체가 임베드되면 아이콘 이미지로 구성된 미리보기가 자동으로 추가됩니다. 이는 사용자가 OLE 객체에 접근하거나 열기 전에 보게 되는 미리보기입니다. 특정 이미지와 텍스트를 미리보기 요소로 사용하려면 Aspose.Slides for Python via Java를 사용해 아이콘 이미지와 제목을 설정할 수 있습니다.

다음 Python 코드는 임베드된 객체에 아이콘 이미지와 제목을 설정하는 방법을 보여줍니다:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    # 프레젠테이션 리소스에 이미지를 추가합니다.
    image_data = Path("image.png").read_bytes()
    image_data = jpype.JArray(jpype.JByte)(image_data)
    ole_image = presentation.getImages().addImage(image_data)

    # OLE 미리보기를 위한 제목과 이미지를 설정합니다.
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **OLE 개체 프레임 크기 및 위치 변경 방지**

링크된 OLE 개체를 프레젠테이션 슬라이드에 추가한 후 PowerPoint에서 프레젠테이션을 열면 링크 업데이트 여부를 묻는 메시지가 표시될 수 있습니다. "Update Links" 버튼을 클릭하면 PowerPoint가 링크된 OLE 개체의 데이터를 업데이트하고 개체 미리보기를 새로 고치면서 OLE 개체 프레임의 크기와 위치가 변경될 수 있습니다. PowerPoint가 객체 데이터를 업데이트하도록 요청하는 것을 방지하려면 [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) 클래스의 [setUpdateAutomatic](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) 메서드를 `False`로 호출합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    ole_frame.setUpdateAutomatic(False)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **임베드된 파일 추출**

Aspose.Slides for Python via Java를 사용하면 슬라이드에 OLE 객체로 임베드된 파일을 다음과 같이 추출할 수 있습니다:

1. 추출하려는 OLE 객체가 포함된 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 프레젠테이션의 모든 모양을 반복하면서 [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) 모양에 접근합니다.
3. OLE 개체 프레임에서 임베드된 파일 데이터를 가져와 디스크에 기록합니다.

다음 Python 코드는 슬라이드에 임베드된 파일을 OLE 객체로 추출하는 방법을 보여줍니다:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)

        if isinstance(shape, OleObjectFrame):
            ole_frame = shape

            file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()
            file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()

            file_path = Path(f"OLE_object_{index}.{str(file_extension).lstrip('.')}")
            file_path.write_bytes(bytes(file_data))
finally:
    presentation.dispose()
```

## **FAQ**

**OLE 콘텐츠가 PDF/이미지로 내보낼 때 렌더링됩니까?**

슬라이드에 보이는 내용(아이콘/대체 이미지)이 렌더링됩니다. “실시간” OLE 콘텐츠는 렌더링 중에 실행되지 않습니다. 필요하다면 내보낸 PDF에서 기대한 모양을 보장하기 위해 자체 미리보기 이미지를 설정하십시오.

임베드된 파일을 PDF 첨부 파일로도 유지하려면 `True`와 함께 [setIncludeOleData](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setIncludeOleData) 를 호출합니다. 이 옵션은 기본적으로 비활성화되어 있습니다. 예제와 첨부 파일 확인 방법은 [Preserve Embedded OLE Files as PDF Attachments](/slides/ko/python-java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments) 를 참고하세요.

**슬라이드에서 OLE 객체를 잠가 사용자가 PowerPoint에서 이동/편집하지 못하게 하려면 어떻게 합니까?**

모양을 잠급니다: Aspose.Slides는 [shape-level locks](/slides/ko/python-java/applying-protection-to-presentation/) 를 제공합니다. 이는 암호화가 아니라 실수로 인한 편집 및 이동을 방지합니다.

**링크된 Excel 객체가 프레젠테이션을 열 때 “점프”하거나 크기가 변하는 이유는 무엇입니까?**

PowerPoint가 링크된 OLE의 미리보기를 새로 고칠 수 있습니다. 안정된 모양을 유지하려면 [Working Solution for Worksheet Resizing](/slides/ko/python-java/working-solution-for-worksheet-resizing/) 에서 제시한 방법을 따르세요—프레임을 범위에 맞추거나, 범위를 고정 프레임에 맞게 스케일링하고 적절한 대체 이미지를 설정합니다.

**PPTX 형식에서 링크된 OLE 객체의 상대 경로가 유지됩니까?**

PPTX에서는 “상대 경로” 정보가 제공되지 않고 전체 경로만 저장됩니다. 상대 경로는 오래된 PPT 형식에서만 사용할 수 있습니다. 이동성을 위해 신뢰할 수 있는 절대 경로나 접근 가능한 URI, 혹은 임베드 방식을 선호하십시오.