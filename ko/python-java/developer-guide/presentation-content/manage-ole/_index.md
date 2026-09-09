---
title: Python을 사용한 프레젠테이션 OLE 관리
linktitle: OLE 관리
type: docs
weight: 40
url: /ko/python-java/manage-ole/
keywords:
- OLE 개체
- 객체 연결 및 임베딩
- OLE 추가
- OLE 삽입
- 개체 추가
- 개체 삽입
- 파일 추가
- 파일 삽입
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
description: "Aspose.Slides for Python via Java를 사용하여 PowerPoint 및 OpenDocument 파일에서 OLE 개체 관리를 최적화합니다. OLE 콘텐츠를 손쉽게 삽입, 업데이트 및 내보낼 수 있습니다."
---
## **소개**

{{% alert color="info" title="Note" %}}
OLE (Object Linking & Embedding)은 한 응용 프로그램에서 만든 데이터와 개체를 링크하거나 임베드하여 다른 응용 프로그램에 배치할 수 있게 하는 Microsoft 기술입니다.
{{% /alert %}}

MS Excel에서 만든 차트를 생각해 보세요. 해당 차트를 PowerPoint 슬라이드에 삽입합니다. 이 Excel 차트는 OLE 개체로 취급됩니다.

- OLE 개체는 아이콘 형태로 표시될 수 있습니다. 이 경우 아이콘을 더블 클릭하면 차트가 연결된 응용 프로그램(Excel)에서 열리거나, 개체를 열거나 편집할 응용 프로그램을 선택하라는 메시지가 표시됩니다.
- OLE 개체는 차트 내용과 같은 실제 내용을 표시할 수도 있습니다. 이 경우 차트가 PowerPoint에서 활성화되고 차트 인터페이스가 로드되어 PowerPoint 내에서 차트 데이터를 수정할 수 있습니다.

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/ko/python-java/)을 사용하면 OLE 개체 프레임([OleObjectFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/oleobjectframe/))으로 슬라이드에 OLE 개체를 삽입할 수 있습니다.

## **슬라이드에 OLE 개체 프레임 추가**

Microsoft Excel에서 차트를 이미 만든 상태이며, Aspose.Slides for Python via Java를 사용해 OLE 개체 프레임으로 슬라이드에 임베드하려는 경우 다음과 같이 할 수 있습니다:

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
3. Excel 파일을 바이트 배열로 읽어들입니다.
4. 바이트 배열 및 OLE 개체에 대한 기타 정보를 포함하여 슬라이드에 [OleObjectFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/oleobjectframe/)을 추가합니다.
5. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예제에서는 Aspose.Slides for Python via Java를 사용해 Excel 파일의 차트를 OLE 개체 프레임으로 슬라이드에 추가했습니다.
**참고**: [OleEmbeddedDataInfo](https://reference.aspose.com/slides/ko/python-java/aspose.slides/oleembeddeddatainfo/) 생성자는 두 번째 매개변수로 임베드 가능한 개체 확장자를 받습니다. 이 확장자는 PowerPoint가 파일 유형을 올바르게 해석하고 해당 OLE 개체를 열 적절한 응용 프로그램을 선택하도록 합니다.

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

    # 슬라이드에 OLE 개체 프레임을 추가합니다.
    frame_width = jpype.JFloat(slide_size.getWidth())
    frame_height = jpype.JFloat(slide_size.getHeight())
    slide.getShapes().addOleObjectFrame(0, 0, frame_width, frame_height, data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **연결된 OLE 개체 프레임 추가**

Aspose.Slides for Python via Java를 사용하면 임베드된 데이터 대신 파일에 대한 링크를 포함한 [OleObjectFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/oleobjectframe/)을 추가할 수 있습니다.

다음 Python 코드는 Excel 파일에 대한 링크가 포함된 [OleObjectFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/oleobjectframe/)을 슬라이드에 추가하는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # 연결된 Excel 파일이 있는 OLE 개체 프레임을 추가합니다.
    slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **OLE 개체 프레임 액세스**

슬라이드에 OLE 개체가 이미 임베드되어 있는 경우 다음과 같이 쉽게 찾거나 액세스할 수 있습니다:

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성하여 임베드된 OLE 개체가 포함된 프레젠테이션을 로드합니다.
2. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
3. [OleObjectFrame] 모양에 액세스합니다. 예제에서는 첫 번째 슬라이드에 하나의 모양만 있는 이전에 만든 PPTX를 사용했습니다. 그런 다음 해당 개체가 [OleObjectFrame]인지 확인했습니다. 이것이 액세스하려는 원하는 OLE 개체 프레임이었습니다.
4. OLE 개체 프레임에 액세스하면 원하는 모든 작업을 수행할 수 있습니다.

아래 예제에서는 슬라이드에 임베드된 Excel 차트 개체(OLE 개체 프레임)와 해당 파일 데이터를 액세스합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

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

### **연결된 OLE 개체 프레임 속성 액세스**

Aspose.Slides를 사용하면 연결된 OLE 개체 프레임 속성에 접근할 수 있습니다.

다음 Python 코드는 OLE 개체가 연결되어 있는지 확인하고 연결된 파일의 경로를 얻는 방법을 보여줍니다:

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

        # OLE 개체가 연결되어 있는지 확인합니다.
        if ole_frame.isObjectLink():
            # 연결된 파일의 전체 경로를 출력합니다.
            print("OLE object frame is linked to: " + str(ole_frame.getLinkPathLong()))

            # 존재한다면 연결된 파일의 상대 경로를 출력합니다.
            # 상대 경로는 PPT 프레젠테이션에만 포함될 수 있습니다.
            relative_path = ole_frame.getLinkPathRelative()
            if relative_path is not None and not relative_path.isEmpty():
                print("OLE object frame relative path: " + str(relative_path))
finally:
    presentation.dispose()
```

## **OLE 개체 데이터 변경**

{{% alert color="info" title="Note" %}}
이 섹션에서는 아래 코드 예제가 [Aspose.Cells for Python via Java](https://products.aspose.com/cells/python-java/)를 사용합니다.
{{% /alert %}}

슬라이드에 OLE 개체가 이미 임베드되어 있는 경우 다음과 같이 해당 개체에 접근하여 데이터를 수정할 수 있습니다:

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성하여 임베드된 OLE 개체가 포함된 프레젠테이션을 로드합니다.
2. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
3. OLE 개체 프레임 모양에 액세스합니다. 예제에서는 첫 번째 슬라이드에 하나의 모양만 있는 이전에 만든 PPTX를 사용했습니다. 그런 다음 개체가 [OleObjectFrame]인지 확인했습니다. 이것이 액세스하려는 원하는 OLE 개체 프레임이었습니다.
4. OLE 개체 프레임에 액세스하면 원하는 모든 작업을 수행할 수 있습니다.
5. [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) 객체를 생성하고 OLE 데이터를 접근합니다.
6. 원하는 [Worksheet](https://reference.aspose.com/cells/python-java/asposecells.api/worksheet/)에 접근하여 데이터를 수정합니다.
7. 업데이트된 [Workbook]을 스트림에 저장합니다.
8. 스트림에서 OLE 개체 데이터를 변경합니다.

아래 예제에서는 슬라이드에 임베드된 Excel 차트 개체(OLE 개체 프레임)에 접근한 뒤 파일 데이터를 수정하여 차트 데이터를 업데이트합니다.

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

        # OLE 개체 데이터를 Workbook 객체로 읽습니다.
        workbook = Workbook(ole_stream)

        new_ole_stream = ByteArrayOutputStream()

        # Workbook 데이터를 수정합니다.
        cells = workbook.getWorksheets().get(0).getCells()
        cells.get(0, 4).putValue("E")
        cells.get(1, 4).putValue(jpype.JInt(12))
        cells.get(2, 4).putValue(jpype.JInt(14))
        cells.get(3, 4).putValue(jpype.JInt(15))

        file_options = OoxmlSaveOptions(CellsSaveFormat.XLSX)
        workbook.save(new_ole_stream, file_options)

        # OLE 프레임 객체 데이터를 변경합니다.
        new_file_data = new_ole_stream.toByteArray()
        new_data = OleEmbeddedDataInfo(new_file_data, ole_frame.getEmbeddedData().getEmbeddedFileExtension())
        ole_frame.setEmbeddedData(new_data)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **다른 파일 형식 슬라이드에 삽입**

Excel 차트 외에도 Aspose.Slides for Python via Java를 사용하면 HTML, PDF, ZIP 파일과 같은 다른 유형의 파일을 슬라이드에 삽입할 수 있습니다. 사용자가 삽입된 개체를 더블 클릭하면 해당 프로그램이 자동으로 열리거나, 적절한 프로그램을 선택하라는 프롬프트가 표시됩니다.

다음 Python 코드는 HTML과 ZIP 파일을 슬라이드에 삽입하는 방법을 보여줍니다:

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

## **삽입된 개체의 파일 형식 설정**

프레젠테이션 작업 중에는 오래된 OLE 개체를 새 개체로 교체하거나 지원되지 않는 OLE 개체를 지원되는 개체로 교체해야 할 수 있습니다. Aspose.Slides for Python via Java를 사용하면 삽입된 개체의 파일 형식을 설정하여 OLE 프레임 데이터나 확장자를 업데이트할 수 있습니다.

다음 Python 코드는 삽입된 OLE 개체의 파일 형식을 `zip`으로 설정하는 방법을 보여줍니다:

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

    # 파일 유형을 ZIP으로 변경합니다.
    data_info = OleEmbeddedDataInfo(file_data, "zip")
    ole_frame.setEmbeddedData(data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **삽입된 개체의 아이콘 이미지 및 제목 설정**

OLE 개체를 삽입하면 아이콘 이미지로 구성된 미리보기가 자동으로 추가됩니다. 이 미리보기는 사용자가 OLE 개체에 접근하거나 열기 전에 보는 모습입니다. 미리보기에 특정 이미지와 텍스트를 사용하려면 Aspose.Slides for Python via Java를 사용해 아이콘 이미지와 제목을 설정할 수 있습니다.

다음 Python 코드는 삽입된 개체의 아이콘 이미지와 제목을 설정하는 방법을 보여줍니다:

```python
from pathlib import Path

import jpate
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

    # OLE 미리보드에 제목과 이미지를 설정합니다.
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **OLE 개체 프레임의 크기 조정 및 위치 변경 방지**

연결된 OLE 개체를 프레젠테이션 슬라이드에 추가한 후 PowerPoint에서 프레젠테이션을 열면 링크 업데이트를 묻는 메시지가 표시될 수 있습니다. "Update Links" 버튼을 클릭하면 PowerPoint가 연결된 OLE 개체의 데이터를 업데이트하고 미리보기를 새로 고치면서 OLE 개체 프레임의 크기와 위치가 변경될 수 있습니다. PowerPoint가 개체 데이터 업데이트를 요청하지 않도록 하려면 [OleObjectFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/oleobjectframe/) 클래스의 [setUpdateAutomatic](https://reference.aspose.com/slides/ko/python-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) 메서드를 `False`로 설정합니다:

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

## **삽입된 파일 추출**

Aspose.Slides for Python via Java를 사용하면 슬라이드에 OLE 개체로 삽입된 파일을 다음과 같이 추출할 수 있습니다:

1. 추출하려는 OLE 개체가 포함된 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 프레젠테이션의 모든 모양을 순회하면서 [OleObjectFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/oleobjectframe/) 모양을 찾습니다.
3. OLE 개체 프레임에서 삽입된 파일 데이터를 접근하고 디스크에 저장합니다.

다음 Python 코드는 슬라이드에 OLE 개체로 삽입된 파일을 추출하는 방법을 보여줍니다:

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

**슬라이드를 PDF/이미지로 내보낼 때 OLE 내용이 렌더링되나요?**

슬라이드에 표시되는 부분만 렌더링됩니다—아이콘/대체 이미지(미리보기)만 표시됩니다. "실시간" OLE 내용은 렌더링 중에 실행되지 않습니다. 필요하다면 자체 미리보기 이미지를 설정하여 내보낸 PDF에서 기대한 모습이 나오도록 할 수 있습니다.

**PowerPoint에서 사용자가 OLE 개체를 이동하거나 편집하지 못하도록 슬라이드에 고정하려면 어떻게 해야 하나요?**

모양을 잠급니다: Aspose.Slides는 [shape-level locks](/slides/ko/python-java/applying-protection-to-presentation/)를 제공합니다. 이는 암호화는 아니지만 실수로 인한 편집 및 이동을 효과적으로 방지합니다.

**연결된 Excel 개체가 프레젠테이션을 열 때 "점프"하거나 크기가 변하는 이유는 무엇인가요?**

PowerPoint가 연결된 OLE의 미리보기를 새로 고칠 수 있습니다. 안정적인 표시를 위해 [Worksheet Resizing에 대한 작업 솔루션](/slides/ko/python-java/working-solution-for-worksheet-resizing/)을 따르세요—프레임을 범위에 맞추거나 범위를 고정 프레임에 맞게 스케일링하고 적절한 대체 이미지를 설정합니다.

**연결된 OLE 개체의 상대 경로가 PPTX 형식에 보존되나요?**

PPTX에서는 "상대 경로" 정보가 제공되지 않고 전체 경로만 저장됩니다. 상대 경로는 오래된 PPT 형식에서만 지원됩니다. 이식성을 위해 신뢰할 수 있는 절대 경로나 접근 가능한 URI, 또는 임베드를 사용하는 것이 좋습니다.