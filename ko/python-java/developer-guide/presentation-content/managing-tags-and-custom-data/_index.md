---
title: "Python을 사용하여 프레젠테이션에서 태그 및 사용자 정의 데이터 관리"
linktitle: "태그 및 사용자 정의 데이터"
type: docs
weight: 300
url: /ko/python-java/managing-tags-and-custom-data/
keywords:
- "문서 속성"
- "태그"
- "사용자 정의 데이터"
- "사용자 정의 XML"
- "사용자 정의 XML 파트"
- "XML 메타데이터"
- ItemId
- "태그 추가"
- "값 쌍"
- PowerPoint
- "프레젠테이션"
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 PowerPoint 프레젠테이션에서 태그 및 사용자 정의 XML 데이터를 관리하는 방법을 배우세요. 여기에는 사용자 정의 XML 파트 추가, 읽기, 업데이트, 감사 및 제거가 포함됩니다."
---
## **개요**

이 문서는 Aspose.Slides가 PowerPoint 프레젠테이션에서 태그 및 사용자 정의 데이터를 어떻게 처리하는지 설명합니다. 프레젠테이션 별 데이터는 태그 또는 사용자 정의 XML 파트로 저장될 수 있습니다. 태그는 간단한 키-값 문자열 쌍이며, 사용자 정의 XML 파트는 구조화된 메타데이터와 애플리케이션 별 XML 페이로드를 저장할 수 있습니다.

Aspose.Slides는 프레젠테이션, 슬라이드 및 개체 수준에서 사용자 정의 XML 파트를 추가, 읽기, 업데이트, 감사 및 제거하기 위한 API를 제공합니다. 사용자 정의 XML 파트는 문서 관리 식별자, 워크플로 상태, 규정 준수 메타데이터, 템플릿 바인딩 데이터 또는 프레젠테이션 내부의 기타 구조화된 애플리케이션 데이터를 저장하는 통합에 유용합니다.

## **프레젠테이션 파일의 데이터 저장**

PPTX 파일(`.pptx` 확장자를 가진 파일)은 Office Open XML 사양의 일부인 PresentationML 형식으로 저장됩니다. Office Open XML은 프레젠테이션 콘텐츠 및 관련 데이터를 저장하기 위해 사용되는 패키지 구조와 관계를 정의합니다.

프레젠테이션은 관계로 연결된 여러 파트로 구성됩니다. 예를 들어, 슬라이드 파트는 단일 슬라이드의 내용을 포함하며 ISO/IEC 29500에 정의된 다른 파트와 명시적인 관계를 가질 수 있습니다.

사용자 정의 데이터는 태그([TagCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/tagcollection/)) 또는 사용자 정의 XML 파트([CustomXmlPartCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/customxmlpartcollection/))로 저장될 수 있습니다. 두 기능 모두 [CustomData](https://reference.aspose.com/slides/ko/python-java/aspose.slides/customdata/) 클래스를 통해 사용할 수 있습니다.

{{% alert color="info" title="Note" %}}
태그는 간단한 문자열 키-값 쌍을 저장합니다. 사용자 정의 XML 파트는 구조화된 XML 데이터를 저장하며 프레젠테이션, 슬라이드 또는 개체와 연결될 수 있습니다.
{{% /alert %}}

## **사용자 정의 XML 파트 작업**

The [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/ko/python-java/aspose.slides/customdata/#getCustomXmlParts) 메서드는 특정 프레젠테이션 객체와 연결된 사용자 정의 XML 파트 컬렉션을 반환합니다. 예를 들어:

- 프레젠테이션의 [CustomData.getCustomXmlParts] 컬렉션에는 프레젠테이션 자체와 연결된 사용자 정의 XML 파트가 포함됩니다.
- 슬라이드의 [CustomData.getCustomXmlParts] 컬렉션에는 특정 슬라이드와 연결된 사용자 정의 XML 파트가 포함됩니다.
- 개체의 [CustomData.getCustomXmlParts] 컬렉션에는 특정 개체와 연결된 사용자 정의 XML 파트가 포함됩니다.

프레젠테이션에 연결된 위치와 관계없이 모든 사용자 정의 XML 파트를 검사해야 할 경우 [Presentation.getAllCustomXmlParts]를 사용하세요.

### **프레젠테이션에 사용자 정의 XML 파트 추가**

[CustomXmlPartCollection.add]를 사용하여 XML 데이터를 사용자 정의 XML 파트 컬렉션에 추가합니다. XML은 유효하고 비어 있지 않아야 합니다.

다음 예제는 프레젠테이션 수준 사용자 정의 데이터 컬렉션에 구조화된 메타데이터를 추가합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.util import UUID

presentation = Presentation()
try:
    custom_xml_content = '<?xml version="1.0" encoding="UTF-8"?><metadata xmlns="urn:example:metadata"><documentId>DOC-1001</documentId><workflowState>Draft</workflowState></metadata>'
    custom_xml_part = presentation.getCustomData().getCustomXmlParts().add(custom_xml_content)

    # add는 식별자를 자동으로 할당합니다. 필요한 경우에만 특정 UUID를 설정하십시오.
    item_id = UUID.randomUUID()
    custom_xml_part.setItemId(item_id)

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[add] 메서드는 XML을 바이트 배열이나 입력 스트림으로도 받아들일 수 있으며, XML 콘텐츠가 이미 바이너리 형태로 제공될 때 유용합니다.

### **슬라이드 또는 개체에 사용자 정의 XML 파트 추가**

사용자 정의 XML 데이터는 전체 프레젠테이션이 아니라 특정 슬라이드 또는 개체와 연결될 수 있습니다. 이는 메타데이터가 템플릿 키, 외부 레코드 식별자 또는 바인딩 정보와 같이 단일 객체만을 설명할 때 유용합니다.

다음 예제는 슬라이드에 하나의 사용자 정의 XML 파트를, 개체에 또 하나를 추가합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide_xml_content = '<slideMetadata xmlns="urn:example:slides"><templateKey>TitleSlide</templateKey></slideMetadata>'
    slide.getCustomData().getCustomXmlParts().add(slide_xml_content)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 250, 80)
    shape.getTextFrame().setText("Customer data")
    shape_xml_content = '<shapeMetadata xmlns="urn:example:shapes"><recordId>CRM-4281</recordId></shapeMetadata>'
    shape.getCustomData().getCustomXmlParts().add(shape_xml_content)

    presentation.save("object_custom_xml.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

파트를 추가하는 수준에 따라 어떤 객체의 [CustomData.getCustomXmlParts] 컬렉션에 해당 파트와의 관계가 포함되는지가 결정됩니다. 프레젠테이션 수준 데이터는 문서 전체 메타데이터에 적합하고, 슬라이드 수준 데이터는 특정 슬라이드에 속하는 정보에, 개체 수준 데이터는 개별 개체에 연결된 메타데이터에 적합합니다.

### **모든 사용자 정의 XML 파트 나열 및 감사**

[Presentation.getAllCustomXmlParts]를 사용하여 프레젠테이션에서 모든 사용자 정의 XML 파트를 검색합니다. 각 [CustomXmlPart]는 식별자, XML 내용 및 연결된 네임스페이스 스키마를 제공합니다.

다음 예제는 모든 사용자 정의 XML 파트와 해당 네임스페이스 스키마를 나열합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    for custom_xml_part in presentation.getAllCustomXmlParts():
        print("ItemId:", custom_xml_part.getItemId())
        print("XML:")
        print(custom_xml_part.getXmlAsString())

        for namespace_schema in custom_xml_part.getNamespaceSchemas():
            print("Namespace schema:", namespace_schema)

        print()
finally:
    presentation.dispose()
```

[CustomXmlPart.getNamespaceSchemas]는 사용자 정의 XML 파트와 연결된 XML 스키마를 반환합니다. 이 정보는 외부 시스템에서 생성된 XML을 포함하는 프레젠테이션을 감사할 때 유용할 수 있습니다.

### **XML 내용 및 ItemId 읽기 및 업데이트**

[CustomXmlPart.getXmlAsString]와 [setXmlAsString]을 사용하여 XML을 UTF-8 문자열로 작업하거나, [getXmlData]와 [setXmlData]를 사용하여 원시 XML 바이트를 작업합니다.

[CustomXmlPart.getItemId] 메서드는 Office Open XML 문서에서 사용자 정의 XML 파트를 식별하는 UUID를 반환합니다. 통합에서 새 식별자가 필요할 경우 [setItemId]를 사용합니다.

다음 예제는 XML 내용과 식별자를 업데이트합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.util import UUID

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getAllCustomXmlParts()
    if len(custom_xml_parts) > 0:
        custom_xml_part = custom_xml_parts[0]

        # 현재 XML을 텍스트로 읽습니다.
        current_xml_content = custom_xml_part.getXmlAsString()
        print(current_xml_content)

        # UTF-8 문자열로 XML을 업데이트합니다.
        custom_xml_content = '<metadata xmlns="urn:example:metadata"><documentId>DOC-1001</documentId><workflowState>Approved</workflowState></metadata>'
        custom_xml_part.setXmlAsString(custom_xml_content)

        # getXmlData는 동일한 XML 콘텐츠를 원시 바이트로 제공합니다.
        custom_xml_data = custom_xml_part.getXmlData()
        print(bytes(custom_xml_data).decode("utf-8"))

        # 통합에서 필요할 때 식별자를 교체합니다.
        item_id = UUID.randomUUID()
        custom_xml_part.setItemId(item_id)

        presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx)
    else:
        print("No custom XML parts found.")
finally:
    presentation.dispose()
```

[setXmlAsString] 또는 [setXmlData]를 호출할 때는 유효하고 비어 있지 않은 XML을 제공하십시오. 애플리케이션이 주로 문자열로 작업하는지 바이트 데이터로 작업하는지에 따라 하나의 표현 방식을 선택하세요.

### **사용자 정의 XML 파트 제거**

Aspose.Slides는 사용자 정의 XML 데이터를 제거하는 여러 방법을 제공합니다:

- [CustomXmlPart.remove]는 프레젠테이션에서 사용자 정의 XML 파트를 제거합니다.
- [CustomXmlPartCollection.remove]는 사용자 정의 XML 파트 컬렉션에서 특정 파트를 제거합니다.
- [CustomXmlPartCollection.removeAt]는 지정된 컬렉션 인덱스에 있는 파트를 제거합니다.
- [CustomXmlPartCollection.clear]는 특정 컬렉션의 모든 파트를 제거합니다.

다음 예제는 참조를 통해 하나의 프레젠테이션 수준 사용자 정의 XML 파트를 제거합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getCustomData().getCustomXmlParts()
    if custom_xml_parts.size() > 0:
        custom_xml_part = custom_xml_parts.get_Item(0)
        custom_xml_parts.remove(custom_xml_part)

    presentation.save("custom_xml_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

이미 [CustomXmlPart]가 있고 특정 컬렉션을 지정하지 않고 프레젠테이션에서 해당 파트를 제거하려면 [CustomXmlPart.remove]를 호출하십시오.

인덱스로 항목을 제거할 수도 있습니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getCustomData().getCustomXmlParts()
    if custom_xml_parts.size() > 0:
        custom_xml_parts.removeAt(0)
finally:
    presentation.dispose()
```

### **컬렉션에서 모든 사용자 정의 XML 파트 삭제**

특정 프레젠테이션 객체와 연결된 모든 사용자 정의 XML 파트를 제거해야 할 경우 [clear]를 사용합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear()

    presentation.save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[clear]는 선택된 컬렉션에만 영향을 미칩니다. 예를 들어 슬라이드의 컬렉션을 비우면 프레젠테이션 수준 또는 개체 수준 컬렉션은 비워지지 않습니다.

프레젠테이션의 모든 사용자 정의 XML 파트를 제거하려면 [getAllCustomXmlParts]를 순회하면서 각 파트를 제거합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    for custom_xml_part in presentation.getAllCustomXmlParts():
        custom_xml_part.remove()

    presentation.save("all_custom_xml_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **링크되거나 공유된 사용자 정의 XML 파트 처리**

Office Open XML 프레젠테이션에서는 동일한 사용자 정의 XML 파트를 둘 이상의 프레젠테이션 객체가 참조할 수 있습니다. 예를 들어, 기존 파일에 여러 슬라이드나 개체가 동일한 기본 사용자 정의 XML 파트와 관계를 가질 수 있습니다.

공유 파트는 여러 참조를 가진 하나의 데이터 객체로 취급해야 합니다:

- [setXmlAsString], [setXmlData] 또는 [setItemId]로 업데이트하면 기본 사용자 정의 XML 파트가 변경되어 해당 파트를 참조하는 모든 위치에 변경 사항이 적용됩니다.
- [getItemId]는 객체 수준 컬렉션을 감사하는 동안 동일한 사용자 정의 XML 파트를 식별하는 데 사용할 수 있습니다.
- 특정 [getCustomXmlParts] 컬렉션에서 파트를 제거하면 해당 컬렉션에서만 제거됩니다. 파트를 프레젠테이션에서 완전히 제거해야 할 경우 [CustomXmlPart.remove]를 사용하십시오.
- 공유 파트를 삭제하거나 교체하기 전에 객체 수준 컬렉션을 조사하여 다른 슬라이드나 개체가 아직 해당 파트를 참조하고 있는지 확인하십시오.

[add] 오버로드는 XML 콘텐츠에서 새로운 사용자 정의 XML 파트를 생성합니다; 기존 [CustomXmlPart]를 받아들이지 않습니다. 따라서 공유 관계는 이미 해당 파트를 포함하고 있는 프레젠테이션을 로드할 때 가장 많이 발생합니다.

다음 예제는 `ItemId`로 프레젠테이션, 슬라이드 및 개체 수준 컬렉션을 감사하고 하나 이상의 위치에서 참조되는 파트를 보고합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    references_by_item_id = {}

    def register_custom_xml_parts(owner_name, custom_xml_parts):
        for i in range(custom_xml_parts.size()):
            custom_xml_part = custom_xml_parts.get_Item(i)
            item_id = str(custom_xml_part.getItemId())
            references_by_item_id.setdefault(item_id, []).append(owner_name)

    register_custom_xml_parts("Presentation", presentation.getCustomData().getCustomXmlParts())

    for slide_index in range(presentation.getSlides().size()):
        slide = presentation.getSlides().get_Item(slide_index)
        register_custom_xml_parts(f"Slide {slide_index + 1}", slide.getCustomData().getCustomXmlParts())

        for shape_index in range(slide.getShapes().size()):
            shape = slide.getShapes().get_Item(shape_index)
            register_custom_xml_parts(f"Slide {slide_index + 1}, shape {shape_index}", shape.getCustomData().getCustomXmlParts())

    for item_id, owner_names in references_by_item_id.items():
        if len(owner_names) > 1:
            print("Shared custom XML part:", item_id)
            for owner_name in owner_names:
                print("  Referenced by:", owner_name)
finally:
    presentation.dispose()
```

이러한 감사는 외부 시스템에서 만든 프레젠테이션의 사용자 정의 XML 데이터를 수정하거나 삭제하기 전에 유용합니다. 동일한 메타데이터 파트가 여러 관계에 참여할 수 있기 때문입니다.

## **태그 값 가져오기**

슬라이드에서 태그는 [DocumentProperties.getKeywords] 메서드에 해당합니다. 이 샘플 코드는 Aspose.Slides for Python via Java를 사용하여 [Presentation]에서 태그 값을 가져오는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    keywords = presentation.getDocumentProperties().getKeywords()
finally:
    presentation.dispose()
```

## **프레젠테이션에 태그 추가**

Aspose.Slides를 사용하면 프레젠테이션에 태그를 추가할 수 있습니다. 태그는 일반적으로 두 항목으로 구성됩니다:

- 예를 들어 `MyTag`와 같은 사용자 정의 속성 이름;
- 예를 들어 `My Tag Value`와 같은 사용자 정의 속성 값.

특정 규칙이나 속성을 기준으로 프레젠테이션을 분류해야 하는 경우 해당 목적을 위해 태그를 추가할 수 있습니다. 예를 들어 북미 국가의 프레젠테이션을 분류하려면 북미 태그를 만들고 해당 국가를 값으로 할당하면 됩니다.

다음 샘플 코드는 Aspose.Slides for Python via Java를 사용하여 [Presentation]에 태그를 추가하는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    tags = presentation.getCustomData().getTags()
    tags.set_Item("MyTag", "My Tag Value")
finally:
    presentation.dispose()
```

태그는 [Slide]에도 설정할 수 있습니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide.getCustomData().getTags().set_Item("tag", "value")
finally:
    presentation.dispose()
```

또는 개별 [Shape]에 대해 설정할 수 있습니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50)
    shape.getTextFrame().setText("My text")
    shape.getCustomData().getTags().set_Item("tag", "value")
finally:
    presentation.dispose()
```

### **제한 사항**

[CustomData.getTags] 컬렉션을 통해 추가된 태그는 PowerPoint 파일에만 저장됩니다. 프레젠테이션을 PDF로 내보낼 때 해당 태그가 PDF 태그 구조에 **전송되지** 않습니다. 따라서 태그로 할당된 사용자 정의 식별자는 태그된 PDF에서 검색할 수 없습니다.

**우회 방법**: 객체의 **Alt Text**에 사용자 정의 식별자를 저장할 수 있습니다(예: 값이 `"MyId"`인 [Shape.setAlternativeText] 사용). PDF로 내보낸 후 Alt Text가 PDF 태그 구조에 나타날 수 있습니다.

## **FAQ**

**프레젠테이션, 슬라이드 또는 개체에서 모든 태그를 한 번에 제거할 수 있나요?**

예. The [tag collection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/tagcollection/) supports a [clear](https://reference.aspose.com/slides/ko/python-java/aspose.slides/tagcollection/#clear) operation that deletes all key-value pairs at once.

**전체 컬렉션을 반복하지 않고 이름으로 단일 태그를 삭제하려면 어떻게 해야 하나요?**

Use [remove](https://reference.aspose.com/slides/ko/python-java/aspose.slides/tagcollection/#remove) on the [tag collection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/tagcollection/) to delete the tag by its key.

**분석 또는 필터링을 위해 모든 태그 이름 목록을 가져오려면 어떻게 해야 하나요?**

Use [getNamesOfTags](https://reference.aspose.com/slides/ko/python-java/aspose.slides/tagcollection/#getNamesOfTags) on the [tag collection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/tagcollection/); it returns an array of all tag names.

**저장 위치와 관계없이 모든 사용자 정의 XML 파트를 찾으려면 어떻게 해야 하나요?**

Use [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getAllCustomXmlParts) to retrieve all custom XML parts in the presentation.

**사용자 정의 XML 파트를 업데이트할 때 [getXmlAsString]/[setXmlAsString]와 [getXmlData]/[setXmlData] 중 어느 것을 사용해야 하나요?**

Use [getXmlAsString](https://reference.aspose.com/slides/ko/python-java/aspose.slides/customxmlpart/#getXmlAsString) and [setXmlAsString](https://reference.aspose.com/slides/ko/python-java/aspose.slides/customxmlpart/#setXmlAsString) when the application works with UTF-8 XML text. Use [getXmlData](https://reference.aspose.com/slides/ko/python-java/aspose.slides/customxmlpart/#getXmlData) and [setXmlData](https://reference.aspose.com/slides/ko/python-java/aspose.slides/customxmlpart/#setXmlData) when the XML is already available as a byte array or when binary-oriented processing is more convenient. Both representations refer to the XML content of the same custom XML part.