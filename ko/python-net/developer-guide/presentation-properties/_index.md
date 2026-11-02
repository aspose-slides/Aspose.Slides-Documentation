---
title: Python으로 프레젠테이션 속성 관리
linktitle: 프레젠테이션 속성
type: docs
weight: 70
url: /ko/python-net/presentation-properties/
keywords:
- PowerPoint 속성
- 프레젠테이션 속성
- 문서 속성
- 내장 속성
- 사용자 정의 속성
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
description: "Aspose.Slides for Python via .NET에서 프레젠테이션 속성을 마스터하고 PowerPoint 파일에서 검색, 브랜드 지정 및 워크플로를 간소화합니다."
---
## **소개**

Aspose.Slides for Python via .NET는 **내장** 및 **사용자 정의** 문서 속성을 지원합니다. 이러한 속성을 사용하여 저자, 제목 및 사용자 정의 값과 같은 프레젠테이션 메타데이터를 읽고 업데이트할 수 있습니다.

Aspose.Slides를 사용하면 [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) 클래스를 통해 프레젠테이션 문서 속성을 작업할 수 있습니다. 이 클래스의 인스턴스는 [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/)에서 반환됩니다. 다음 예제에서는 이러한 속성을 읽고, 수정하고, 관리하는 방법을 보여줍니다.

{{% alert color="info" title="Note" %}}
Aspose.Slides는 프레젠테이션을 저장할 때 애플리케이션 및 제작자 메타데이터를 관리합니다; 이 필드들은 출력물을 만든 소프트웨어를 식별합니다.
{{% /alert %}}

## **프레젠테이션 속성 관리**

문서 속성은 프레젠테이션 콘텐츠와 함께 설명 정보를 저장합니다. 두 가지 범주로 나뉩니다:

- **내장 속성**은 제목, 저자 및 문서 통계와 같은 표준 메타데이터를 포함합니다.
- **사용자 정의 속성**은 사용자 정의 이름/값 쌍을 저장합니다.

Aspose.Slides for Python via .NET는 두 범주 모두에 대한 액세스를 제공합니다. PowerPoint에서 **파일 → 정보 → 속성 → 고급 속성**을 선택하여 문서 메타데이터를 검사합니다. 대화 상자는 **요약**, **통계**, **목차**, **사용자 정의**와 같은 탭으로 정보를 그룹화합니다. **사용자 정의** 탭을 사용하여 사용자 정의 속성을 관리합니다.

## **암호화된 프레젠테이션에서 공개 속성 읽기**

열기 비밀번호는 일반적으로 프레젠테이션 콘텐츠와 문서 속성을 모두 보호합니다. 프레젠테이션이 [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/)을 `False`로 설정하여 암호화된 경우, 문서 속성은 공개 상태로 유지됩니다. 그런 다음 애플리케이션은 [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/)을 `True`로 설정하고 열기 비밀번호 없이 공개 메타데이터를 읽을 수 있습니다.

[LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/)은 Aspose.Slides가 로드하는 항목을 제어합니다; 복호화는 수행하지 않습니다. 속성이 암호화에 포함된 경우 비밀번호 없이 로드하면 실패합니다. 프레젠테이션이 암호화되지 않은 경우 옵션은 무시되고 전체 프레젠테이션이 로드됩니다.

예제에는 문서 속성이 공개된 암호화된 프레젠테이션이 필요합니다. [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/)을 통해 로드 모드를 확인한 다음 [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/)을 사용하여 내장 속성을 읽습니다:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.only_load_document_properties = True

with slides.Presentation("public-properties-encrypted.pptx", load_options) as presentation:
    if presentation.protection_manager.is_only_document_properties_loaded:
        document_properties = presentation.document_properties

        print("Author: " + document_properties.author)
        print("Title: " + document_properties.title)
        print("Keywords: " + document_properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

이 모드에서는 슬라이드 콘텐츠가 로드되지 않습니다. 슬라이드, 마스터, 레이아웃, 도형, 미디어 및 기타 프레젠테이션 객체를 사용할 수 없습니다. 전체 프레젠테이션 객체 모델이 필요한 작업을 수행하기 전에 항상 [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/)을 확인해야 합니다.

{{% alert color="warning" title="Security" %}}
공개 메타데이터는 저자 이름, 제목, 주제, 키워드, 회사 정보, 댓글 및 사용자 정의 값을 노출할 수 있습니다. 민감한 속성은 프레젠테이션과 함께 암호화하십시오. 인덱싱, 분류, 검색 또는 문서 관리 시스템이 비밀번호 없이 접근해야 하는 특별한 요구가 있는 경우에만 공개 상태로 두십시오.
{{% /alert %}}

## **암호화된 프레젠테이션 속성 업데이트**

암호화된 PPTX 파일에 대해 [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/)으로 로드된 프레젠테이션은 공개 메타데이터를 읽기 위한 용도입니다. Aspose.Slides는 해당 메타데이터 전용 객체에서 변경된 속성을 저장할 수 없으며, 공개 속성은 암호화된 프레젠테이션 내부 데이터와 일치해야 합니다. 따라서 속성을 업데이트하려면 올바른 열기 비밀번호와 전체 로드가 필요합니다.

예제에는 공개 문서 속성을 가진 암호화된 PPTX 프레젠테이션과 알려진 열기 비밀번호가 필요합니다. [LoadOptions.password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/)로 전체 프레젠테이션을 열고, 공개 내장 속성을 업데이트한 뒤 저장합니다. 그런 다음 [PresentationInfo.is_encrypted](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/is_encrypted/)를 사용해 암호화가 유지되는지 확인하고, 비밀번호 없이 공개 메타데이터를 다시 열어 새로운 값을 검증합니다:

```python
import aspose.slides as slides

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation(input_path, load_options) as presentation:
    document_properties = presentation.document_properties
    document_properties.title = "Updated Product Roadmap"
    document_properties.keywords = "roadmap, planning, indexed"
    
    presentation.save(output_path, slides.export.SaveFormat.PPTX)

presentation_info = slides.PresentationFactory.instance.get_presentation_info(output_path)
print("The presentation is encrypted: " + str(presentation_info.is_encrypted))

metadata_load_options = slides.LoadOptions()
metadata_load_options.only_load_document_properties = True

with slides.Presentation(output_path, metadata_load_options) as metadata_presentation:
    if metadata_presentation.protection_manager.is_only_document_properties_loaded:
        print("Title: " + metadata_presentation.document_properties.title)
        print("Keywords: " + metadata_presentation.document_properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

애플리케이션이 프레젠테이션 콘텐츠를 복호화하거나 로드할 수 없는 경우, 암호화된 PPTX 파일의 공개 속성을 읽기 전용으로 취급해야 합니다.

## **내장 속성 접근**

[DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) 클래스는 [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/), [DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/), [DocumentProperties.created_time](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/created_time/) 등 타입이 지정된 속성을 통해 내장 메타데이터를 노출합니다. 이 예제는 기존 프레젠테이션을 열어 저장된 메타데이터를 콘솔에 출력합니다. 값은 입력 프레젠테이션에 따라 다르며 일부 필드는 비어 있을 수 있습니다.

```python
import aspose.slides as slides

with slides.Presentation("AccessBuiltInProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    print("Category:", document_properties.category)
    print("Content status:", document_properties.content_status)
    print("Creation date:", document_properties.created_time)
    print("Author:", document_properties.author)
    print("Comments:", document_properties.comments)
    print("Keywords:", document_properties.keywords)
    print("Last modified by:", document_properties.last_saved_by)
    print("Manager:", document_properties.manager)
    print("Modified date:", document_properties.last_saved_time)
    print("Presentation format:", document_properties.presentation_format)
    print("Last print date:", document_properties.last_printed)
    print("Is shared between producers:", document_properties.shared_doc)
    print("Subject:", document_properties.subject)
    print("Title:", document_properties.title)
```

## **내장 속성 수정**

내장 메타데이터를 업데이트하려면 [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/)에서 노출된 쓰기 가능한 속성에 값을 할당합니다. 이 예제는 기존 프레젠테이션을 열어 [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/), [DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/), [DocumentProperties.subject](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/subject/), [DocumentProperties.comments](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/comments/), [DocumentProperties.manager](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/manager/)를 설정한 뒤 [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/)으로 업데이트된 프레젠테이션을 저장합니다. 저장된 PPTX에는 새로운 메타데이터가 포함됩니다.

```python
import aspose.slides as slides

with slides.Presentation("ModifyBuiltInProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    document_properties.author = "Aspose.Slides for Python via .NET"
    document_properties.title = "Manage PowerPoint Presentation Properties"
    document_properties.subject = "Modify Built-in Properties"
    document_properties.comments = "Aspose description"
    document_properties.manager = "Aspose manager"

    presentation.save("DocumentProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

## **하이퍼링크 기본값 관리**

[DocumentProperties.hyperlink_base](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/hyperlink_base/)는 상대 하이퍼링크를 위한 문서 수준 기본값을 저장합니다. 프레젠테이션과 연결된 파일을 다른 위치로 이동할 때 유용합니다. 이는 개별 하이퍼링크의 [Hyperlink.external_url](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url/)와 별개이며, 기본값을 변경해도 저장된 링크 주소가 다시 작성되거나 절대 대상이 변경되지 않습니다.

예제에는 `target.html`과 같은 상대 링크와 파일 또는 웹사이트에 대한 절대 링크가 모두 포함된 프레젠테이션이 필요합니다. 기존 기본값을 읽고 새 기본 주소를 할당한 뒤 프레젠테이션을 저장하고 다시 열어 값을 확인합니다. 그런 다음 `""`으로 기본값을 지우고 별도 저장 파일에서 빈 값을 검증합니다. 예제 기본 주소를 연결 파일이 위치한 경로로 교체하십시오.

```python
import aspose.slides as slides

with slides.Presentation("hyperlinks.pptx") as presentation:
    print("Original base:", presentation.document_properties.hyperlink_base)

    new_base = "https://example.com/new/"
    presentation.document_properties.hyperlink_base = new_base
    presentation.save("hyperlinks-updated.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlinks-updated.pptx") as updated_presentation:
    print("Base preserved:", updated_presentation.document_properties.hyperlink_base == new_base)

    updated_presentation.document_properties.hyperlink_base = ""
    updated_presentation.save("hyperlinks-cleared.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlinks-cleared.pptx") as cleared_presentation:
    print("Base cleared:", cleared_presentation.document_properties.hyperlink_base == "")
```

두 검증 메시지는 `True`를 출력해야 합니다. 기본값을 지워도 개별 하이퍼링크 주소는 그대로 유지됩니다.

`target.pptx`에 대한 상대 링크는 기본값이 `old` 폴더를 가리킬 때 `old/target.pptx`를 열었습니다. 기본값을 `new` 폴더로 변경하고 저장·재열면 동일한 링크가 `new/target.pptx`를 엽니다. 절대 링크는 동일한 파일을 계속 엽니다. 프레젠테이션을 이동하거나 기본값을 변경하기 전후에 PowerPoint에서 상대 링크를 테스트하십시오.

## **맞춤 프레젠테이션 속성 추가**

맞춤 속성은 내장 필드에 해당하지 않는 메타데이터를 저장합니다. [DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/) 메서드를 사용하면 속성 이름으로 값을 할당할 수 있습니다. 이 예제는 프레젠테이션을 생성하고 두 개의 텍스트 값과 정수 형식 버전 값을 추가한 뒤 [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/)으로 저장합니다. 기존 이름에 값을 할당하면 해당 속성의 값이 교체됩니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    document_properties = presentation.document_properties

    document_properties.set_custom_property_value("Reviewed by", "John Smith")
    document_properties.set_custom_property_value("Confidentiality level", "Internal")
    document_properties.set_custom_property_value("Document version", 2)

    presentation.save("CustomDocumentProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

## **맞춤 속성 접근 및 수정**

이 예제는 맞춤 속성을 포함한 프레젠테이션을 열고 [DocumentProperties.count_of_custom_properties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/count_of_custom_properties/)를 사용해 이를 순회합니다. [DocumentProperties.get_custom_property_name](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_name/)은 0부터 시작하는 인덱스를 받아 [DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/)에서 사용된 이름을 반환합니다. 예제는 맞춤 속성이 모두 문자열인 프레젠테이션이 필요합니다. 각 원래 이름과 값을 출력하고, 모든 값을 번호가 매겨진 문자열로 교체한 뒤 변경 사항을 저장합니다. 맞춤 속성이 없으면 루프는 아무 변화도 만들지 않습니다.

```python
import aspose.slides as slides

with slides.Presentation("AccessAndModifyProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    for i in range(document_properties.count_of_custom_properties):
        property_name = document_properties.get_custom_property_name(i)
        property_value = [""]
        document_properties.get_custom_property_value(property_name, property_value)

        print("Custom property name:", property_name)
        print("Custom property value:", property_value[0])

        document_properties.set_custom_property_value(property_name, "New Value " + str(i + 1))

    presentation.save("CustomProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

[DocumentProperties.get_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_value/)은 두 번째 인수로 전달된 한 요소 리스트를 통해 값을 반환합니다. 자리표시자는 저장된 속성 타입과 일치해야 합니다: 문자열에는 `[""]`, 정수에는 `[0]`을 사용하십시오. 타입이 일치하지 않으면 `InvalidCastException`이 발생합니다; 맞춤 속성 스키마에 따라 적절한 자리표시자를 선택하십시오.

## **실시간 예제**

Aspose.Slides API를 사용해 문서 속성을 다루는 방법을 보려면 온라인 앱 [**PowerPoint 메타데이터 보기 및 편집**](https://products.aspose.app/slides/metadata) 을 사용해 보세요:

[![PowerPoint 메타데이터 보기 및 편집](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**프레젠테이션에서 내장 속성을 제거하려면 어떻게 해야 하나요?**

내장 속성은 프레젠테이션의 필수 구성 요소이며 완전히 제거할 수 없습니다. 다만, 해당 속성이 허용하는 경우 값을 변경하거나 빈 값으로 설정할 수 있습니다.

**이미 존재하는 사용자 정의 속성을 추가하면 어떻게 되나요?**

이미 존재하는 사용자 정의 속성을 추가하면 기존 값이 새 값으로 덮어써집니다. 속성을 미리 제거하거나 확인할 필요 없이 Aspose.Slides가 자동으로 값을 업데이트합니다.

**프레젠테이션을 완전히 로드하지 않고도 속성에 접근할 수 있나요?**

예. [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/get_presentation_info/)을 사용한 다음 [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/)을 호출하면 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 인스턴스를 만들지 않고도 저장된 문서 메타데이터를 읽을 수 있습니다. 전체 보고 예제와 형식별 제한 사항은 [경량 프레젠테이션 인벤토리 만들기](/slides/ko/python-net/examine-presentation/)를 참조하십시오.

**암호화된 프레젠테이션의 공개 속성을 열기 비밀번호 없이 읽을 수 있나요?**

예. 프레젠테이션이 [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/)을 `False`로 설정하여 암호화되었고, [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/)을 `True`로 로드해야 합니다.

**문서 속성 전용 모드에서 암호화된 PPTX 파일을 업데이트할 수 있나요?**

아니요. 공개 및 암호화된 속성 데이터는 일관성을 유지해야 하므로, 암호화된 PPTX 파일을 업데이트하려면 올바른 열기 비밀번호를 사용해 전체 프레젠테이션을 로드해야 합니다.