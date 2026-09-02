---
title: Python을 사용한 프레젠테이션에서 태그 및 사용자 정의 데이터 관리
linktitle: 태그 및 사용자 정의 데이터
type: docs
weight: 300
url: /ko/python-net/managing-tags-and-custom-data/
keywords:
- 문서 속성
- 태그
- 사용자 정의 데이터
- 사용자 정의 XML
- 사용자 정의 XML 파트
- XML 메타데이터
- ItemId
- 태그 추가
- 키-값 쌍
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint 프레젠테이션에서 태그 및 사용자 정의 XML 데이터를 관리하는 방법을 배우세요. 여기에는 사용자 정의 XML 파트 추가, 읽기, 업데이트, 감사 및 제거가 포함됩니다."
---
## **개요**

이 문서는 Aspose.Slides가 PowerPoint 프레젠테이션에서 태그와 사용자 정의 데이터를 어떻게 다루는지 설명합니다. 프레젠테이션 별 데이터는 태그 또는 사용자 정의 XML 파트로 저장될 수 있습니다. 태그는 단순한 키‑값 문자열 쌍이며, 사용자 정의 XML 파트는 구조화된 메타데이터와 애플리케이션 전용 XML 페이로드를 저장할 수 있습니다.

Aspose.Slides는 프레젠테이션, 슬라이드 및 도형 수준에서 사용자 정의 XML 파트를 추가, 읽기, 업데이트, 감사 및 제거하기 위한 API를 제공합니다. 사용자 정의 XML 파트는 문서 관리 식별자, 워크플로우 상태, 준수 메타데이터, 템플릿 바인딩 데이터 또는 프레젠테이션 내부에 저장되는 기타 구조화된 애플리케이션 데이터를 저장하는 통합에 유용합니다.

## **프레젠테이션 파일의 데이터 저장**

PPTX 파일—`.pptx` 확장자를 가진 파일—은 PresentationML 형식으로 저장되며, 이는 Office Open XML 사양의 일부입니다. Office Open XML은 프레젠테이션 내용 및 관련 데이터를 저장하기 위해 사용되는 패키지 구조와 관계를 정의합니다.

프레젠테이션은 여러 파트가 관계에 의해 연결된 형태입니다. 예를 들어 슬라이드 파트는 단일 슬라이드의 내용을 포함하고 ISO/IEC 29500에 정의된 다른 파트와 명시적인 관계를 가질 수 있습니다.

사용자 정의 데이터는 태그([TagCollection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/tagcollection/)) 또는 사용자 정의 XML 파트([CustomXmlPartCollection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/customxmlpartcollection/))로 저장할 수 있습니다. 두 방법 모두 [`CustomData`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/customdata/) 클래스를 통해 사용할 수 있습니다.

{{% alert color="primary" %}}
태그는 단순 문자열 키‑값 쌍을 저장합니다. 사용자 정의 XML 파트는 구조화된 XML 데이터를 저장하며 프레젠테이션, 슬라이드 또는 도형에 연결될 수 있습니다.
{{% /alert %}}

## **사용자 정의 XML 파트 작업**

[`CustomData.custom_xml_parts`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/customdata/custom_xml_parts/) 속성은 특정 프레젠테이션 객체와 연결된 사용자 정의 XML 파트 컬렉션을 반환합니다. 예를 들어:

- `presentation.custom_data.custom_xml_parts`는 프레젠테이션 자체와 연결된 사용자 정의 XML 파트를 포함합니다.
- `slide.custom_data.custom_xml_parts`는 특정 슬라이드와 연결된 사용자 정의 XML 파트를 포함합니다.
- `shape.custom_data.custom_xml_parts`는 특정 도형과 연결된 사용자 정의 XML 파트를 포함합니다.

프레젠테이션 전체에 포함된 모든 사용자 정의 XML 파트를 조사하려면 [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/all_custom_xml_parts/)을 사용하십시오.

### **프레젠테이션에 사용자 정의 XML 파트 추가**

[`CustomXmlPartCollection.add`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/customxmlpartcollection/add/)을 사용하여 XML 데이터를 사용자 정의 XML 파트 컬렉션에 추가합니다. XML은 유효하고 비어 있지 않아야 합니다.

다음 예제는 프레젠테이션 수준 사용자 정의 데이터 컬렉션에 구조화된 메타데이터를 추가합니다:

```py
import uuid
import aspose.slides as slides

custom_xml_content = (
    '<?xml version="1.0" encoding="UTF-8"?>'
    '<metadata xmlns="urn:example:metadata">'
    '<documentId>DOC-1001</documentId>'
    '<workflowState>Draft</workflowState>'
    '</metadata>'
)

with slides.Presentation() as presentation:
    custom_xml_part = presentation.custom_data.custom_xml_parts.add(custom_xml_content)

    # add는 식별자를 자동으로 할당합니다. 특정 GUID는 필요할 때만 설정합니다.
    custom_xml_part.item_id = uuid.uuid4()

    presentation.save("presentation_with_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

`add` 메서드는 XML을 바이트 배열이나 스트림 형태로도 받을 수 있으며, 이는 XML 내용이 이미 바이너리 형태로 존재할 때 유용합니다.

### **슬라이드 또는 도형에 사용자 정의 XML 파트 추가**

사용자 정의 XML 데이터는 전체 프레젠테이션이 아니라 특정 슬라이드나 도형에 연결할 수 있습니다. 이는 메타데이터가 템플릿 키, 외부 레코드 식별자 또는 바인딩 정보와 같이 하나의 객체에만 적용될 때 유용합니다.

다음 예제는 슬라이드에 하나의 사용자 정의 XML 파트를, 도형에 또 하나를 추가합니다:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.custom_data.custom_xml_parts.add(
        '<slideMetadata xmlns="urn:example:slides">'
        '<templateKey>TitleSlide</templateKey>'
        '</slideMetadata>'
    )

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 250, 80)

    shape.text_frame.text = "Customer data"
    shape.custom_data.custom_xml_parts.add(
        '<shapeMetadata xmlns="urn:example:shapes">'
        '<recordId>CRM-4281</recordId>'
        '</shapeMetadata>'
    )

    presentation.save("object_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

파트가 추가된 수준에 따라 해당 객체의 `custom_data.custom_xml_parts` 컬렉션에 관계가 저장됩니다. 프레젠테이션 수준 데이터는 문서 전체 메타데이터에, 슬라이드 수준 데이터는 특정 슬라이드에, 도형 수준 데이터는 개별 도형에 연결됩니다.

### **모든 사용자 정의 XML 파트 나열 및 감사**

[`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/all_custom_xml_parts/)을 사용하여 프레젠테이션에서 모든 사용자 정의 XML 파트를 가져올 수 있습니다. 각 [`CustomXmlPart`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/customxmlpart/)은 식별자, XML 내용 및 연결된 네임스페이스 스키마를 노출합니다.

다음 예제는 모든 사용자 정의 XML 파트와 해당 네임스페이스 스키마를 나열합니다:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for custom_xml_part in presentation.all_custom_xml_parts:
        print("ItemId: " + str(custom_xml_part.item_id))
        print("XML:")
        print(custom_xml_part.xml_as_string)

        for namespace_schema in custom_xml_part.namespace_schemas:
            print("Namespace schema: " + namespace_schema)

        print()
```

[`CustomXmlPart.namespace_schemas`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/customxmlpart/namespace_schemas/)은 해당 파트와 연결된 XML 스키마를 반환합니다. 외부 시스템에서 생성된 XML이 포함된 프레젠테이션을 감사할 때 유용합니다.

### **XML 내용 및 ItemId 읽기·수정**

[`CustomXmlPart.xml_as_string`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/customxmlpart/xml_as_string/)을 사용하면 XML을 UTF‑8 문자열로 작업할 수 있고, [`CustomXmlPart.xml_data`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/customxmlpart/xml_data/)을 사용하면 원시 XML 바이트를 처리할 수 있습니다. 두 속성 모두 읽기 및 업데이트가 가능합니다.

[`CustomXmlPart.item_id`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/customxmlpart/item_id/) 속성은 Office Open XML 문서에서 해당 사용자 정의 XML 파트를 식별하는 GUID를 포함합니다. 통합에서 새로운 식별자가 필요할 경우 변경할 수 있습니다.

다음 예제는 XML 내용과 식별자를 업데이트합니다:

```py
import uuid
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    custom_xml_part = presentation.all_custom_xml_parts[0]

    # 현재 XML을 텍스트로 읽습니다.
    current_xml_content = custom_xml_part.xml_as_string
    print(current_xml_content)

    # XML을 UTF-8 문자열로 업데이트합니다.
    custom_xml_part.xml_as_string = (
        '<metadata xmlns="urn:example:metadata">'
        '<documentId>DOC-1001</documentId>'
        '<workflowState>Approved</workflowState>'
        '</metadata>'
    )

    # xml_data는 동일한 XML 내용을 원시 바이트로 제공합니다.
    custom_xml_data = custom_xml_part.xml_data
    print(custom_xml_data.decode("utf-8"))

    # 통합에서 필요할 경우 식별자를 교체합니다.
    custom_xml_part.item_id = uuid.uuid4()

    presentation.save("updated_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

`xml_as_string` 또는 `xml_data`에 값을 할당할 때는 유효하고 비어 있지 않은 XML을 제공하십시오. 애플리케이션이 문자열 중심인지 바이트 데이터 중심인지에 따라 하나를 선택하면 됩니다.

### **사용자 정의 XML 파트 제거**

Aspose.Slides는 사용자 정의 XML 데이터를 제거하는 여러 방법을 제공합니다:

- [`CustomXmlPart.remove`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/customxmlpart/remove/)은 프레젠테이션에서 해당 파트를 제거합니다.
- [`CustomXmlPartCollection.remove`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/customxmlpartcollection/remove/)은 컬렉션에서 특정 파트를 제거합니다.
- [`CustomXmlPartCollection.remove_at`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/customxmlpartcollection/remove_at/)은 지정된 인덱스의 파트를 제거합니다.
- [`CustomXmlPartCollection.clear`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/customxmlpartcollection/clear/)은 해당 컬렉션의 모든 파트를 제거합니다.

다음 예제는 프레젠테이션 수준 사용자 정의 XML 파트를 참조로 제거합니다:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    custom_xml_parts = presentation.custom_data.custom_xml_parts

    if len(custom_xml_parts) > 0:
        custom_xml_part = custom_xml_parts[0]
        custom_xml_parts.remove(custom_xml_part)

    presentation.save("custom_xml_removed.pptx", slides.export.SaveFormat.PPTX)
```

이미 `CustomXmlPart` 객체를 가지고 있고 컬렉션이 아닌 프레젠테이션 전체에서 해당 파트를 제거하려면 `custom_xml_part.remove()`를 호출하십시오.

인덱스로 항목을 제거할 수도 있습니다:

```py
presentation.custom_data.custom_xml_parts.remove_at(0)
```

### **컬렉션에서 모든 사용자 정의 XML 파트 정리**

특정 프레젠테이션 객체와 연결된 모든 사용자 정의 XML 파트를 제거해야 할 때 `clear`를 사용하십시오.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.slides[0].custom_data.custom_xml_parts.clear()

    presentation.save("slide_custom_xml_cleared.pptx", slides.export.SaveFormat.PPTX)
```

`clear`는 선택한 컬렉션에만 영향을 미칩니다. 예를 들어 슬라이드 컬렉션을 비우더라도 프레젠테이션 수준이나 도형 수준 컬렉션은 그대로 유지됩니다.

프레젠테이션의 모든 사용자 정의 XML 파트를 제거하려면 `all_custom_xml_parts`를 순회하면서 각 파트를 제거하십시오:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for custom_xml_part in presentation.all_custom_xml_parts:
        custom_xml_part.remove()

    presentation.save("all_custom_xml_removed.pptx", slides.export.SaveFormat.PPTX)
```

### **연결되거나 공유된 사용자 정의 XML 파트 처리**

Office Open XML 프레젠테이션에서는 동일한 사용자 정의 XML 파트가 여러 프레젠테이션 객체에서 참조될 수 있습니다. 예를 들어 기존 파일에 여러 슬라이드 또는 도형이 동일한 사용자 정의 XML 파트에 대한 관계를 가지고 있을 수 있습니다.

공유 파트는 여러 참조를 가진 단일 데이터 객체로 취급해야 합니다:

- `xml_as_string`, `xml_data` 또는 `item_id`를 업데이트하면 기본 XML 파트가 변경되며, 해당 파트를 참조하는 모든 위치에 적용됩니다.
- `item_id`는 객체 수준 컬렉션을 감사하면서 동일한 사용자 정의 XML 파트를 식별하는 데 사용할 수 있습니다.
- 특정 `custom_xml_parts` 컬렉션에서 파트를 제거하면 해당 컬렉션에서만 삭제됩니다. 파트 자체를 프레젠테이션 전체에서 제거하려면 `CustomXmlPart.remove()`를 사용하십시오.
- 공유 파트를 삭제하거나 교체하기 전에 다른 슬라이드나 도형이 아직 참조하고 있는지 객체 수준 컬렉션을 확인하십시오.

`add` 오버로드는 XML 콘텐츠에서 새로운 사용자 정의 XML 파트를 생성하며 기존 `CustomXmlPart`를 받아들이지 않습니다. 따라서 공유 관계는 이미 해당 파트를 포함하고 있는 프레젠테이션을 로드할 때 가장 흔히 나타납니다.

다음 예제는 `item_id`별로 프레젠테이션·슬라이드·도형 수준 컬렉션을 감사하고, 여러 위치에서 참조되는 파트를 보고합니다:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    references_by_item_id = {}

    def register_custom_xml_parts(owner_name, custom_xml_parts):
        for custom_xml_part in custom_xml_parts:
            references_by_item_id.setdefault(custom_xml_part.item_id, []).append(owner_name)

    register_custom_xml_parts("Presentation", presentation.custom_data.custom_xml_parts)

    for slide_index, slide in enumerate(presentation.slides):
        register_custom_xml_parts(
            "Slide " + str(slide_index + 1),
            slide.custom_data.custom_xml_parts
        )

        for shape_index, shape in enumerate(slide.shapes):
            register_custom_xml_parts(
                "Slide " + str(slide_index + 1) + ", shape " + str(shape_index),
                shape.custom_data.custom_xml_parts
            )

    for item_id, owner_names in references_by_item_id.items():
        if len(owner_names) > 1:
            print("Shared custom XML part: " + str(item_id))

            for owner_name in owner_names:
                print("  Referenced by: " + owner_name)
```

이러한 감사는 외부 시스템이 만든 프레젠테이션에서 사용자 정의 XML 데이터를 수정하거나 삭제하기 전에 유용합니다. 동일 메타데이터 파트가 여러 관계에 참여할 수 있기 때문입니다.

## **태그 값 가져오기**

슬라이드에서 태그는 `DocumentProperties.keywords` 속성과 동일합니다. 이 샘플 코드는 Aspose.Slides for Python via .NET을 사용하여 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/)에서 태그 값을 가져오는 방법을 보여줍니다:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    keywords = presentation.document_properties.keywords
```

## **프레젠테이션에 태그 추가**

Aspose.Slides를 사용하면 프레젠테이션에 태그를 추가할 수 있습니다. 태그는 일반적으로 두 항목으로 구성됩니다:

- 사용자 정의 속성 이름, 예: `MyTag`;
- 사용자 정의 속성 값, 예: `My Tag Value`.

특정 규칙이나 속성을 기준으로 프레젠테이션을 분류해야 할 경우 해당 목적을 위해 태그를 추가할 수 있습니다. 예를 들어 북미 국가의 프레젠테이션을 구분하고 싶다면 북미 태그를 만들고 해당 국가명을 값으로 지정하면 됩니다.

다음 샘플 코드는 Aspose.Slides for Python via .NET을 사용하여 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/)에 태그를 추가하는 방법을 보여줍니다:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    tags = presentation.custom_data.tags
    tags.add("MyTag", "My Tag Value")
```

태그는 [Slide](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slide/)에도 설정할 수 있습니다:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.custom_data.tags.add("tag", "value")
```

또는 개별 [Shape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/)에도 설정할 수 있습니다:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 50)
    shape.text_frame.text = "My text"
    shape.custom_data.tags.add("tag", "value")
```

### **제한 사항**

`custom_data.tags` 컬렉션을 통해 추가된 태그는 PowerPoint 파일에만 저장됩니다. 프레젠테이션을 PDF로 내보낼 때 PDF 태그 구조로 전송되지 **않습니다**. 따라서 태그로 지정한 사용자 정의 식별자는 태그가 적용된 PDF에서 검색할 수 없습니다.

**해결 방법**: 객체의 **Alt Text**에 사용자 정의 식별자를 저장할 수 있습니다(예: `shape.alternative_text = "MyId"`). PDF로 내보낸 후 Alt Text가 PDF 태그 구조에 나타날 수 있습니다.

## **FAQ**

**프레젠테이션, 슬라이드 또는 도형에서 모든 태그를 한 번에 제거할 수 있나요?**

예. [tag collection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/tagcollection/)은 모든 키‑값 쌍을 한 번에 삭제하는 [clear](https://reference.aspose.com/slides/ko/python-net/aspose.slides/tagcollection/clear/) 작업을 지원합니다.

**전체 컬렉션을 순회하지 않고 이름으로 단일 태그를 삭제하려면 어떻게 하나요?**

[TagCollection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/tagcollection/)의 [remove(name)](https://reference.aspose.com/slides/ko/python-net/aspose.slides/tagcollection/remove/)을 사용하여 키로 태그를 삭제하십시오.

**분석 또는 필터링을 위해 모든 태그 이름 목록을 가져오려면?**

[tag collection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/tagcollection/)의 [get_names_of_tags](https://reference.aspose.com/slides/ko/python-net/aspose.slides/tagcollection/get_names_of_tags/)을 사용하면 모든 태그 이름이 배열로 반환됩니다.

**저장 위치에 관계없이 모든 사용자 정의 XML 파트를 찾으려면?**

[`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/all_custom_xml_parts/)을 사용하여 프레젠테이션의 모든 사용자 정의 XML 파트를 가져오십시오.

**사용자 정의 XML 파트를 업데이트할 때 `xml_as_string`과 `xml_data` 중 어느 것을 사용해야 하나요?**

애플리케이션이 UTF‑8 XML 텍스트와 함께 작업한다면 `xml_as_string`을 사용하십시오. XML이 이미 바이트 배열 형태이거나 바이너리 중심 처리가 더 편리하면 `xml_data`를 사용하십시오. 두 속성은 동일한 사용자 정의 XML 파트의 내용을 나타냅니다.