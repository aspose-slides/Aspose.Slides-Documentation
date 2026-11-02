---
title: Python에서 프레젠테이션 속성 관리
linktitle: 프레젠테이션 속성
type: docs
weight: 70
url: /ko/python-java/presentation-properties/
keywords:
- PowerPoint 속성
- 프레젠테이션 속성
- 문서 속성
- 내장 속성
- 맞춤 속성
- 고급 속성
- 속성 관리
- 속성 수정
- 문서 메타데이터
- 메타데이터 편집
- 교정 언어
- 기본 언어
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java에서 프레젠테이션 속성을 완벽히 관리하고 PowerPoint 및 OpenDocument 파일에서 검색, 브랜딩 및 워크플로를 간소화합니다."
---
## **소개**

Aspose.Slides for Python via Java은 **built-in** 및 **custom** 문서 속성을 지원합니다. 이러한 속성을 사용하여 작성자, 제목 및 사용자 정의 값과 같은 프레젠테이션 메타데이터를 읽고 업데이트할 수 있습니다.

Aspose.Slides는 [DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/) 클래스를 통해 프레젠테이션 문서 속성을 작업할 수 있게 합니다. 이 클래스의 인스턴스는 [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties)에서 반환됩니다. 다음 예제에서는 이러한 속성을 읽고, 수정하고, 관리하는 방법을 보여줍니다.

{{% alert color="info" title="Note" %}}
Aspose.Slides는 프레젠테이션을 저장할 때 응용 프로그램 및 제작자 메타데이터를 관리합니다; 이러한 필드는 출력물을 만든 소프트웨어를 식별합니다.
{{% /alert %}}

## **프레젠테이션 속성 관리**

문서 속성은 프레젠테이션 내용과 함께 설명 정보를 저장합니다. 이들은 두 가지 범주로 나뉩니다:

- **Built-in properties**는 제목, 작성자 및 문서 통계와 같은 표준 메타데이터를 포함합니다.
- **Custom properties**는 사용자 정의 이름/값 쌍을 저장합니다.

Aspose.Slides for Python via Java는 두 범주 모두에 대한 접근을 제공합니다. PowerPoint에서 **File → Info → Properties → Advanced Properties**를 선택하여 문서 메타데이터를 검사합니다. 대화 상자는 정보를 **Summary**, **Statistics**, **Contents**, **Custom**와 같은 탭으로 구분합니다. **Custom** 탭을 사용하여 사용자 정의 속성을 관리합니다.

## **암호화된 프레젠테이션에서 공개 속성 읽기**

열기 비밀번호는 일반적으로 프레젠테이션 내용과 문서 속성을 모두 보호합니다. 프레젠테이션을 [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) `False`와 함께 호출한 후 암호화하면, 해당 문서 속성은 공개 상태로 유지됩니다. 그런 다음 애플리케이션은 [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) `True`와 함께 호출하여 열기 비밀번호를 제공하지 않고 공개 메타데이터를 읽을 수 있습니다.

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) 는 Aspose.Slides가 로드하는 항목을 제어하며, 암호를 해독하지는 않습니다. 속성이 암호화에 포함되어 있다면 비밀번호 없이 로드하는 것은 실패합니다. 프레젠테이션이 암호화되지 않은 경우 이 옵션은 무시되고 전체 프레젠테이션이 로드됩니다.

예제는 문서 속성이 공개된 상태로 남겨진 암호화된 프레젠테이션이 필요합니다. 로드 모드를 [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) 로 확인한 다음 [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties) 를 통해 내장 속성을 읽습니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions

load_options = LoadOptions()
load_options.setOnlyLoadDocumentProperties(True)

presentation = Presentation("public-properties-encrypted.pptx", load_options)
try:
    if presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded():
        properties = presentation.getDocumentProperties()

        print("Author: ", properties.getAuthor())
        print("Title: ", properties.getTitle())
        print("Keywords: ", properties.getKeywords())
    else:
        print("The presentation was not loaded in document-properties-only mode.")

finally:
    presentation.dispose()
```

이 모드에서는 슬라이드 내용이 로드되지 않습니다. 슬라이드, 마스터, 레이아웃, 도형, 미디어 및 기타 프레젠테이션 개체를 사용할 수 없습니다. 전체 프레젠테이션 개체 모델이 필요한 작업을 수행하기 전에 항상 [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) 를 확인해야 합니다.

{{% alert color="warning" title="Warning" %}}
공개 메타데이터는 작성자 이름, 제목, 주제, 키워드, 회사 정보, 댓글 및 사용자 정의 값을 노출할 수 있습니다. 민감한 속성은 프레젠테이션과 함께 암호화하십시오. 색인, 분류, 검색 또는 문서 관리 시스템이 비밀번호 없이 접근해야 하는 특별한 요구가 있는 경우에만 공개 상태로 두십시오.
{{% /alert %}}

## **암호화된 프레젠테이션 속성 업데이트**

암호화된 PPTX 파일의 경우, [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) `True`와 함께 호출한 후 로드된 프레젠테이션은 공개 메타데이터를 읽기 위한 용도입니다. Aspose.Slides는 해당 메타데이터 전용 객체에서 변경된 속성을 저장할 수 없습니다. 공개 속성은 암호화된 프레젠테이션 내부 데이터와 일관성을 유지해야 하기 때문입니다. 따라서 속성을 업데이트하려면 올바른 열기 비밀번호와 전체 로드가 필요합니다.

예제는 공개 문서 속성을 가진 암호화된 PPTX 프레젠테이션과 알려진 열기 비밀번호가 필요합니다. [LoadOptions.setPassword](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setPassword) 로 전체 프레젠테이션을 열고, 공개 내장 속성을 업데이트한 뒤 결과를 저장합니다. 그런 다음 [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#isEncrypted) 로 암호화가 유지되는지 확인하고, 비밀번호 없이 공개 메타데이터를 다시 열어 새 값을 검증합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions, PresentationFactory, SaveFormat

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation(input_path, load_options)
try:
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap")
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed")
    
    presentation.save(output_path, SaveFormat.Pptx)
finally:
    presentation.dispose()

presentation_info = PresentationFactory.getInstance().getPresentationInfo(output_path)
print("The presentation is encrypted: ", presentation_info.isEncrypted())

metadata_load_options = LoadOptions()
metadata_load_options.setOnlyLoadDocumentProperties(True)

metadata_presentation = Presentation(output_path, metadata_load_options)
try:
    if metadata_presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded():
        print("Title: ", metadata_presentation.getDocumentProperties().getTitle())
        print("Keywords: ", metadata_presentation.getDocumentProperties().getKeywords())
    else:
        print("The presentation was not loaded in document-properties-only mode.")

finally:
    metadata_presentation.dispose()
```

애플리케이션이 프레젠테이션 내용을 복호화하거나 로드할 수 없는 경우, 암호화된 PPTX 파일의 공개 속성을 읽기 전용으로 취급해야 합니다.

## **내장 속성에 액세스**

[DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/) 클래스는 [getAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getAuthor), [getTitle](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getTitle), [getCreatedTime](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCreatedTime) 과 같은 getter 메서드를 통해 내장 메타데이터를 제공합니다. 이 예제는 기존 프레젠테이션을 열어 콘솔에 저장된 메타데이터를 출력합니다. 값은 입력 프레젠테이션에 따라 다르며 일부 필드는 비어 있을 수 있습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("AccessBuiltInProperties.pptx")
try:
    document_properties = presentation.getDocumentProperties()

    print("Category:", document_properties.getCategory())
    print("Content status:", document_properties.getContentStatus())
    print("Creation date:", document_properties.getCreatedTime())
    print("Author:", document_properties.getAuthor())
    print("Comments:", document_properties.getComments())
    print("Keywords:", document_properties.getKeywords())
    print("Last modified by:", document_properties.getLastSavedBy())
    print("Manager:", document_properties.getManager())
    print("Modified date:", document_properties.getLastSavedTime())
    print("Presentation format:", document_properties.getPresentationFormat())
    print("Last print date:", document_properties.getLastPrinted())
    print("Is shared between producers:", document_properties.getSharedDoc())
    print("Subject:", document_properties.getSubject())
    print("Title:", document_properties.getTitle())
finally:
    presentation.dispose()
```

## **내장 속성 수정**

내장 메타데이터를 업데이트하려면 [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties) 로 반환된 객체의 setter 메서드를 사용합니다. 이 예제는 기존 프레젠테이션을 열고, [setAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setAuthor), [setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setTitle), [setSubject](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setSubject), [setComments](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setComments), [setManager](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setManager) 를 호출한 뒤, [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) 로 업데이트된 프레젠테이션을 저장합니다. 저장된 PPTX에는 새로운 메타데이터가 포함됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("ModifyBuiltInProperties.pptx")
try:
    document_properties = presentation.getDocumentProperties()

    document_properties.setAuthor("Aspose.Slides for Python via Java")
    document_properties.setTitle("Manage PowerPoint Presentation Properties")
    document_properties.setSubject("Modify Built-in Properties")
    document_properties.setComments("Aspose description")
    document_properties.setManager("Aspose manager")

    presentation.save("DocumentProperties_output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **하이퍼링크 기본값 관리**

[DocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getHyperlinkBase) 은 상대 하이퍼링크용 문서 수준 기본값을 반환합니다. [DocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setHyperlinkBase) 를 사용하여 이를 변경하거나 지울 수 있습니다. 이는 프레젠테이션과 연결된 파일을 다른 위치로 이동할 때 유용합니다. 이는 개별 하이퍼링크의 [Hyperlink.getExternalUrl](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrl) 와는 별개이며, 기본값을 변경해도 저장된 링크 주소가 재작성되거나 절대 목적지가 바뀌지는 않습니다.

예제는 `target.html` 과 같은 상대 링크와 `https://example.org/absolute.html` 과 같은 절대 링크를 모두 포함한 프레젠테이션이 필요합니다. 기존 기본값을 읽고 새로운 기본 주소를 할당한 뒤 프레젠테이션을 저장하고 다시 열어 값을 확인합니다. 그런 다음 빈 문자열로 기본값을 삭제하고 별도 저장 파일에서 빈 값을 검증합니다. 예제의 기본 주소를 연결된 파일이 위치한 곳으로 교체하십시오.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("hyperlinks.pptx")
try:
    print("Original base:", presentation.getDocumentProperties().getHyperlinkBase())

    new_base = "https://example.com/new/"
    presentation.getDocumentProperties().setHyperlinkBase(new_base)
    presentation.save("hyperlinks-updated.pptx", SaveFormat.Pptx)

    updated_presentation = Presentation("hyperlinks-updated.pptx")
    try:
        print("Base preserved:", new_base == updated_presentation.getDocumentProperties().getHyperlinkBase())

        updated_presentation.getDocumentProperties().setHyperlinkBase("")
        updated_presentation.save("hyperlinks-cleared.pptx", SaveFormat.Pptx)

        cleared_presentation = Presentation("hyperlinks-cleared.pptx")
        try:
            print("Base cleared:", "" == cleared_presentation.getDocumentProperties().getHyperlinkBase())
        finally:
            cleared_presentation.dispose()
    finally:
        updated_presentation.dispose()
finally:
    presentation.dispose()
```

두 검증 메시지는 `True` 를 출력해야 합니다. 기본값을 삭제해도 개별 하이퍼링크 주소는 그대로 유지됩니다.

`target.pptx`에 대한 상대 링크는 기본값이 `old` 폴더를 가리킬 때 `old/target.pptx` 를 열었습니다. 기본값을 `new` 폴더로 변경하고 저장 후 프레젠테이션을 다시 열면 동일한 링크가 `new/target.pptx` 를 엽니다. 절대 링크는 같은 파일을 계속 엽니다. 프레젠테이션을 이동하거나 기본값을 변경하기 전후에 PowerPoint에서 상대 링크를 테스트하십시오.

## **맞춤 프레젠테이션 속성 추가**

맞춤 속성은 내장 필드와 대응되지 않는 메타데이터를 저장합니다. [DocumentProperties.set_Item](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#set_Item) 메서드를 사용하면 속성 이름으로 값을 할당할 수 있습니다. 이 예제는 프레젠테이션을 생성하고 두 개의 텍스트 값과 정수 버전 값(`jpype.JInt` 로 Java 정수를 전달)을 추가한 뒤 [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) 로 저장합니다. 기존 이름에 값을 할당하면 해당 속성의 값이 교체됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    document_properties = presentation.getDocumentProperties()

    document_properties.set_Item("Reviewed by", "John Smith")
    document_properties.set_Item("Confidentiality level", "Internal")
    document_properties.set_Item("Document version", jpype.JInt(2))

    presentation.save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **맞춤 속성 액세스 및 수정**

이 예제는 맞춤 속성을 포함한 프레젠테이션을 열고 [getCountOfCustomProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCountOfCustomProperties) 로 반복합니다. [getCustomPropertyName](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCustomPropertyName) 은 0부터 시작하는 인덱스를 받아 [DocumentProperties.set_Item](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#set_Item) 에 사용된 이름을 반환합니다. 예제는 각 원래 이름과 값을 출력하고, 모든 값을 원래 유형에 관계없이 번호가 매겨진 문자열로 교체한 뒤 변경 사항을 저장합니다. 맞춤 속성이 없으면 루프는 아무 변화도 일으키지 않습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("AccessAndModifyProperties.pptx")
try:
    document_properties = presentation.getDocumentProperties()

    for i in range(document_properties.getCountOfCustomProperties()):
        property_name = document_properties.getCustomPropertyName(i)
        property_value = document_properties.get_Item(property_name)

        print("Custom property name:", property_name)
        print("Custom property value:", property_value)

        document_properties.set_Item(property_name, f"New Value {i + 1}")

    presentation.save("CustomProperties_output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **실시간 예제**

Aspose.Slides API를 사용하여 문서 속성을 다루는 방법을 보려면 온라인 앱 [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) 을 사용해 보세요:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**프레젠테이션에서 내장 속성을 제거하려면 어떻게 해야 하나요?**

내장 속성은 프레젠테이션의 필수 부분이며 완전히 제거할 수 없습니다. 그러나 해당 속성의 값을 변경하거나, 해당 속성이 허용하는 경우 빈 값으로 설정할 수 있습니다.

**이미 존재하는 맞춤 속성을 추가하면 어떻게 되나요?**

이미 존재하는 맞춤 속성을 추가하면 기존 값이 새 값으로 덮어쓰기됩니다. 속성을 미리 삭제하거나 확인할 필요 없이 Aspose.Slides가 자동으로 값을 업데이트합니다.

**프레젠테이션을 완전히 로드하지 않고 속성에 접근할 수 있나요?**

예. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/python-java/aspose.slides/presentationfactory/#getPresentationInfo) 를 사용한 뒤 [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#readDocumentProperties) 를 호출하면 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 인스턴스를 만들지 않고도 저장된 문서 메타데이터를 읽을 수 있습니다. 전체 보고 예제와 형식별 제한 사항은 [Build a Lightweight Presentation Inventory](/slides/ko/python-java/examine-presentation/) 를 참고하십시오.

**암호화된 프레젠테이션의 공개 속성을 열기 비밀번호 없이 읽을 수 있나요?**

예. 프레젠테이션이 [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) `False` 로 호출된 후 암호화되었고, [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) `True` 로 로드된 경우에 가능합니다.

**문서‑속성 전용 모드에서 암호화된 PPTX 파일을 업데이트할 수 있나요?**

아니요. 공개 속성과 암호화된 속성 데이터는 일관성을 유지해야 하므로, 암호화된 PPTX 파일을 업데이트하려면 올바른 열기 비밀번호로 전체 프레젠테이션을 로드해야 합니다.