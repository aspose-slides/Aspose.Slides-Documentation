---
title: Python을 사용하여 프레젠테이션에서 OLE 관리
linktitle: OLE 관리
type: docs
weight: 40
url: /ko/python-net/manage-ole/
keywords:
- OLE 개체
- 객체 연결 및 포함
- OLE 추가
- OLE 삽입
- 개체 추가
- 개체 삽입
- 파일 추가
- 파일 삽입
- 링크된 개체
- 링크된 파일
- OLE 변경
- OLE 아이콘
- OLE 제목
- OLE 추출
- 개체 추출
- 파일 추출
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint 및 OpenDocument 파일에서 OLE 개체 관리를 최적화합니다. OLE 콘텐츠를 손쉽게 삽입, 업데이트 및 내보낼 수 있습니다."
---
## **소개**

{{% alert title="Info" color="info" %}}

**OLE (Object Linking & Embedding)** 은 하나의 응용 프로그램에서 만든 데이터와 개체를 다른 응용 프로그램에 연결하거나 포함시킬 수 있는 Microsoft 기술입니다.

{{% /alert %}}

예를 들어, Microsoft Excel에서 만든 차트를 PowerPoint 슬라이드에 넣으면 OLE 개체가 됩니다.

- OLE 개체는 아이콘으로 표시될 수 있습니다. 아이콘을 두 번 클릭하면 해당 응용 프로그램(예: Excel)에서 개체가 열리거나 열거나 편집할 앱을 선택하라는 메시지가 표시됩니다.
- OLE 개체가 내용(예: 차트)을 표시할 수도 있습니다. 이 경우 PowerPoint가 포함된 개체를 활성화하고 차트 인터페이스를 로드하여 PowerPoint 내에서 차트 데이터를 편집할 수 있게 합니다.

Aspose.Slides for Python은 OLE 개체를 OLE 개체 프레임([OleObjectFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/oleobjectframe/))으로 슬라이드에 삽입할 수 있게 합니다.

## **슬라이드에 OLE 개체 추가**

Microsoft Excel에서 차트를 이미 만들었고 Aspose.Slides for Python을 사용해 OLE 개체 프레임으로 슬라이드에 삽입하려면 다음 단계를 따르세요.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드에 대한 참조를 얻습니다.
1. Excel 파일을 바이트 배열로 읽어들입니다.
1. 바이트 배열 및 기타 OLE 개체 정보를 제공하면서 슬라이드에 [OleObjectFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/oleobjectframe/)을 추가합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예제에서는 Excel 파일의 차트를 [OleObjectFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/oleobjectframe/)으로 슬라이드에 삽입합니다.

**Note:** [OleEmbeddedDataInfo](https://reference.aspose.com/slides/ko/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/) 생성자는 임베드 가능한 개체의 파일 확장자를 두 번째 매개변수로 받습니다. PowerPoint는 이 확장자를 사용해 파일 유형을 식별하고 OLE 개체를 열 적절한 응용 프로그램을 선택합니다.

```py
with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[0]

    # OLE 개체에 대한 데이터를 준비합니다.
    with open("book.xlsx", "rb") as file_stream:
        file_data = file_stream.read()
        data_info = slides.dom.ole.OleEmbeddedDataInfo(file_data, "xlsx")

    # 슬라이드에 OLE 개체 프레임을 추가합니다.
    ole_frame = slide.shapes.add_ole_object_frame(0, 0, slide_size.width, slide_size.height, data_info)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **링크된 OLE 개체 추가**

Aspose.Slides for Python은 데이터를 삽입하는 대신 파일에 링크되는 [OleObjectFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/oleobjectframe/)을 추가할 수 있게 합니다.

다음 Python 예제는 슬라이드에 Excel 파일에 링크된 [OleObjectFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/oleobjectframe/)을 추가하는 방법을 보여줍니다.

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 링크된 Excel 파일을 사용하여 OLE 개체 프레ーム을 추가합니다.
    slide.shapes.add_ole_object_frame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **OLE 개체 접근**

슬라이드에 OLE 개체가 이미 포함되어 있으면 다음과 같이 접근할 수 있습니다.

1. Presentation 클래스를 인스턴스화하여 포함된 OLE 개체가 있는 프레젠테이션을 로드합니다.
1. 인덱스로 슬라이드에 대한 참조를 얻습니다.
1. OleObjectFrame 셰이프에 접근합니다.
1. OLE 개체 프레임을 얻은 후 필요한 작업을 수행합니다.

아래 예제는 OLE 개체 프레임(임베드된 Excel 차트)에 접근하고 파일 데이터를 가져옵니다. 이 예제에서는 첫 번째 슬라이드에 하나의 셰이프만 있는 PPTX를 사용합니다.

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # 삽입된 파일 데이터를 가져옵니다.
        file_data = ole_frame.embedded_data.embedded_file_data

        # 삽입된 파일의 확장자를 가져옵니다.
        file_extension = ole_frame.embedded_data.embedded_file_extension

        # ...
```

### **링크된 OLE 개체 속성 접근**

Aspose.Slides는 링크된 OLE 개체 프레임의 속성을 접근할 수 있게 합니다.

아래 Python 예제는 OLE 개체가 링크되어 있는지 확인하고, 링크된 경우 해당 파일 경로를 반환합니다.

```py
with slides.Presentation("sample.ppt") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # OLE 개체가 링크되어 있는지 확인합니다.
        if ole_frame.is_object_link:
            # 링크된 파일의 전체 경로를 출력합니다.
            print("OLE object frame is linked to:", ole_frame.link_path_long)

            # 존재한다면 링크된 파일의 상대 경로를 출력합니다.
            # .ppt 프레젠테이션만 상대 경로를 포함할 수 있습니다.
            if ole_frame.link_path_relative:
                print("OLE object frame relative path:", ole_frame.link_path_relative)
```

## **OLE 개체 데이터 변경**

{{% alert color="primary" %}}

이 섹션의 코드 예제는 [Aspose.Cells for Python via .NET](/cells/python-net/)를 사용합니다.

{{% /alert %}}

슬라이드에 OLE 개체가 이미 포함되어 있으면 다음과 같이 데이터를 접근하고 수정할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성하여 프레젠테이션을 로드합니다.
1. 인덱스로 대상 슬라이드를 얻습니다.
1. [OleObjectFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/oleobjectframe/) 셰이프에 접근합니다.
1. OLE 개체 프레임을 얻은 후 필요한 작업을 수행합니다.
1. `Workbook` 객체를 생성하고 OLE 데이터를 읽어들입니다.
1. 원하는 `Worksheet`를 열고 데이터를 편집합니다.
1. 업데이트된 `Workbook`을 스트림에 저장합니다.
1. 해당 스트림을 사용해 OLE 개체의 데이터를 교체합니다.

아래 예제에서는 OLE 개체 프레임(임베드된 Excel 차트)에 접근하여 파일 데이터를 수정해 차트를 업데이트합니다. 샘플은 첫 번째 슬라이드에 하나의 셰이프만 포함된 기존 PPTX를 사용합니다.

```py
import io
import aspose.slides as slides
import aspose.cells as cells

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        with io.BytesIO(ole_frame.embedded_data.embedded_file_data) as ole_stream:
            # OLE 개체 데이터를 Workbook 객체로 읽습니다.
            workbook = cells.Workbook(ole_stream)

        with io.BytesIO() as new_ole_stream:
            # 워크북 데이터를 수정합니다.
            workbook.worksheets.get(0).cells.get(0, 4).put_value("E")
            workbook.worksheets.get(0).cells.get(1, 4).put_value(12)
            workbook.worksheets.get(0).cells.get(2, 4).put_value(14)
            workbook.worksheets.get(0).cells.get(3, 4).put_value(15)

            file_options = cells.OoxmlSaveOptions(cells.SaveFormat.XLSX)
            workbook.save(new_ole_stream, file_options)

            # OLE 프레임 개체 데이터를 변경합니다.
            new_data = slides.dom.ole.OleEmbeddedDataInfo(new_ole_stream.getvalue(), ole_frame.embedded_data.embedded_file_extension)
            ole_frame.set_embedded_data(new_data)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **슬라이드에 파일 삽입**

Excel 차트 외에도 Aspose.Slides for Python을 사용하면 다른 파일 유형도 슬라이드에 삽입할 수 있습니다. 예를 들어 HTML, PDF 및 ZIP 파일을 개체로 삽입할 수 있습니다. 사용자가 삽입된 개체를 두 번 클릭하면 연결된 응용 프로그램에서 자동으로 열리거나 적절한 프로그램을 선택하라는 메시지가 표시됩니다.

다음 Python 코드는 슬라이드에 HTML 및 ZIP 파일을 삽입하는 방법을 보여줍니다.

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("sample.html", "rb") as html_stream:
        html_data = html_stream.read()

    html_data_info = slides.dom.ole.OleEmbeddedDataInfo(html_data, "html")
    html_ole_frame = slide.shapes.add_ole_object_frame(150, 120, 50, 50, html_data_info)
    html_ole_frame.is_object_icon = True

    with open("sample.zip", "rb") as zip_stream:
        zip_data = zip_stream.read()

    zip_data_info = slides.dom.ole.OleEmbeddedDataInfo(zip_data, "zip")
    zip_ole_frame = slide.shapes.add_ole_object_frame(150, 220, 50, 50, zip_data_info)
    zip_ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **삽입된 개체의 파일 유형 설정**

프레젠테이션 작업 중에 기존 OLE 개체를 새 개체로 교체하거나 지원되지 않는 OLE 개체를 지원되는 개체로 교체해야 할 경우가 있습니다. Aspose.Slides for Python은 삽입된 개체의 파일 유형을 설정할 수 있게 하여 OLE 프레임 데이터나 파일 확장자를 업데이트할 수 있게 합니다.

다음 Python 코드는 삽입된 OLE 개체의 파일 유형을 `zip`으로 설정하는 방법을 보여줍니다.

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    file_extension = ole_frame.embedded_data.embedded_file_extension
    file_data = ole_frame.embedded_data.embedded_file_data

    print(f"Current embedded file extension is: {file_extension}")

    # 파일 유형을 ZIP으로 변경합니다.
    ole_frame.set_embedded_data(slides.dom.ole.OleEmbeddedDataInfo(file_data, "zip"))

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **삽입된 개체의 아이콘 이미지 및 제목 설정**

OLE 개체를 삽입하면 아이콘 기반 미리보기가 자동으로 추가됩니다. 이 미리보기가 사용자가 OLE 개체에 접근하거나 열기 전에 보게 되는 화면입니다. 특정 이미지와 텍스트를 미리보기로 사용하려면 Aspose.Slides for Python을 사용해 아이콘 이미지와 제목을 설정할 수 있습니다.

다음 Python 코드는 삽입된 개체의 아이콘 이미지와 제목을 설정하는 방법을 보여줍니다.

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # 프레젠테이션 리소스에 이미지를 추가합니다.
    with slides.Images.from_file("image.png") as image:
        ole_image = presentation.images.add_image(image)

    # OLE 미리보기를 위한 제목과 이미지를 설정합니다.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **OLE 개체 프레임의 크기 및 위치 변경 방지**

링크된 OLE 개체를 슬라이드에 추가하면 프레젠테이션을 열 때 PowerPoint가 링크 업데이트 여부를 묻는 메시지를 표시할 수 있습니다. “Update Links”를 선택하면 PowerPoint가 링크된 개체의 데이터를 사용해 미리보기를 새로 고치면서 OLE 개체 프레임의 크기와 위치가 변경될 수 있습니다. PowerPoint가 개체 데이터를 업데이트하도록 묻지 않게 하려면 [OleObjectFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/oleobjectframe/) 클래스의 `update_automatic` 속성을 `False`로 설정합니다:

```py
ole_frame.update_automatic = False
```

## **삽입된 파일 추출**

Aspose.Slides for Python은 슬라이드에 OLE 개체로 삽입된 파일을 다음과 같이 추출할 수 있습니다.

1. 추출하려는 OLE 개체가 포함된 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 프레젠테이션의 모든 셰이프를 반복하면서 OLEObjectFrame 셰이프를 찾습니다.
1. 각 [OLEObjectFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/oleobjectframe/)에서 삽입된 파일 데이터를 가져와 디스크에 저장합니다.

다음 Python 코드는 슬라이드에 삽입된 파일을 OLE 개체로 추출하는 방법을 보여줍니다.

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for index, shape in enumerate(slide.shapes):
        if isinstance(shape, slides.OleObjectFrame):
            ole_frame = shape

            file_data = ole_frame.embedded_data.embedded_file_data
            file_extension = ole_frame.embedded_data.embedded_file_extension

            file_path = f"OLE_object_{index}{file_extension}"
            with open(file_path, 'wb') as file_stream:
                file_stream.write(file_data)
```

## **FAQ**

**슬라이드를 PDF/이미지로 내보낼 때 OLE 내용이 렌더링됩니까?**

슬라이드에 표시되는 것이 렌더링됩니다—아이콘/대체 이미지(미리보기)만 렌더링됩니다. “실시간” OLE 내용은 렌더링 중에 실행되지 않습니다. 필요하면 직접 미리보기 이미지를 설정해 내보낸 PDF에서 기대한 모습을 보이게 할 수 있습니다.

**PowerPoint에서 사용자가 OLE 개체를 이동/편집하지 못하도록 슬라이드에 잠그려면 어떻게 해야 하나요?**

셰이프를 잠급니다: Aspose.Slides는 [shape-level locks](/slides/ko/python-net/applying-protection-to-presentation/)를 제공합니다. 이는 암호화가 아니라 실수로 인한 편집 및 이동을 방지합니다.

**링크된 Excel 개체가 프레젠테이션을 열 때 “점프”하거나 크기가 바뀌는 이유는 무엇인가요?**

PowerPoint가 링크된 OLE의 미리보기를 새로 고칠 수 있습니다. 안정적인 표시를 위해 [Worksheet Resizing에 대한 작업 해결책](/slides/ko/python-net/working-solution-for-worksheet-resizing/)을 따르세요—프레임을 범위에 맞추거나 범위를 고정 프레임에 맞게 스케일링하고 적절한 대체 이미지를 설정합니다.

**링크된 OLE 개체의 상대 경로가 PPTX 형식에 보존됩니까?**

PPTX에서는 “상대 경로” 정보를 제공하지 않으며 전체 경로만 포함됩니다. 상대 경로는 오래된 PPT 형식에만 존재합니다. 이동성을 위해 신뢰할 수 있는 절대 경로/접근 가능한 URI 또는 삽입을 사용하는 것이 좋습니다.

---
title: Python을 사용하여 프레젠테이션에서 OLE 관리
linktitle: OLE 관리
type: docs
weight: 40
url: /ko/python-net/manage-ole/
keywords:
- OLE 개체
- 객체 연결 및 포함
- OLE 추가
- OLE 삽입
- 개체 추가
- 개체 삽입
- 파일 추가
- 파일 삽입
- 링크된 개체
- 링크된 파일
- OLE 변경
- OLE 아이콘
- OLE 제목
- OLE 추출
- 개체 추출
- 파일 추출
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint 및 OpenDocument 파일에서 OLE 개체 관리를 최적화합니다. OLE 콘텐츠를 손쉽게 삽입, 업데이트 및 내보낼 수 있습니다."
---