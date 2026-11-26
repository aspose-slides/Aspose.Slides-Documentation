---
title: Python을 사용한 프레젠테이션 속성 관리
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
description: "Aspose.Slides for Python via .NET에서 프레젠테이션 속성을 마스터하고 PowerPoint 파일의 검색, 브랜딩 및 워크플로를 간소화합니다."
---
## **소개**

Aspose.Slides for Python via .NET는 **built-in** 및 **custom** 문서 속성을 지원합니다. 이러한 속성을 사용하여 작성자, 제목 및 사용자 정의 값과 같은 프레젠테이션 메타데이터를 읽고 업데이트할 수 있습니다.

Aspose.Slides를 사용하면 [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) 클래스를 통해 프레젠테이션 문서 속성을 작업할 수 있습니다. 이 클래스의 인스턴스는 [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/)에 의해 반환됩니다. 다음 예제에서는 이러한 속성을 읽고, 수정하고, 관리하는 방법을 보여줍니다.

{{% alert color="info" title="Note" %}}
Aspose.Slides는 프레젠테이션을 저장할 때 애플리케이션 및 제작자 메타데이터를 관리합니다. 이 필드들은 출력을 만든 소프트웨어를 식별합니다.
{{% /alert %}}

## **프레젠테이션 속성 관리**

문서 속성은 프레젠테이션 내용과 함께 설명 정보를 저장합니다. 이들은 두 가지 범주로 나뉩니다:

- **Built-in properties**는 제목, 작성자 및 문서 통계와 같은 표준 메타데이터를 포함합니다.
- **Custom properties**는 사용자 정의 이름/값 쌍을 저장합니다.

Aspose.Slides for Python via .NET는 두 범주 모두에 대한 액세스를 제공합니다. PowerPoint에서 **File → Info → Properties → Advanced Properties**를 선택하여 문서 메타데이터를 확인합니다. 대화 상자는 정보를 **Summary**, **Statistics**, **Contents**, **Custom** 같은 탭으로 구분합니다. 사용자 정의 속성을 관리하려면 **Custom** 탭을 사용하십시오.

## **암호화된 프레젠테이션에서 공개 속성 읽기**

오프닝 비밀번호는 일반적으로 프레젠테이션 내용과 문서 속성을 모두 보호합니다. 프레젠테이션이 [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/)를 `False`로 설정하여 암호화된 경우, 문서 속성은 공개 상태로 유지됩니다. 애플리케이션은 이후 [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/)를 `True`로 설정하여 오프닝 비밀번호를 제공하지 않고도 공개 메타데이터를 읽을 수 있습니다.

[LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/)는 Aspose.Slides가 로드하는 내용을 제어합니다; 이는 아무 것도 복호화하지 않습니다. 속성이 암호화에 포함된 경우, 비밀번호 없이 로드하면 실패합니다. 프레젠테이션이 암호화되지 않은 경우, 이 옵션은 무시되고 전체 프레젠테이션이 로드됩니다.

예제는 문서 속성이 공개된 암호화된 프레젠테이션이 필요합니다. 로드 모드를 [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/)를 통해 확인하고, 이후 [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/)를 통해 built-in 속성을 읽습니다:

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

이 모드에서는 슬라이드 내용이 로드되지 않습니다. 슬라이드, 마스터, 레이아웃, 도형, 미디어 및 기타 프레젠테이션 객체를 사용할 수 없습니다. 애플리케이션은 전체 프레젠테이션 객체 모델이 필요한 작업을 수행하기 전에 항상 [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/)를 확인해야 합니다.

{{% alert color="warning" title="Security" %}}
공개 메타데이터는 작성자 이름, 제목, 주제, 키워드, 회사 정보, 코멘트 및 사용자 정의 값을 노출할 수 있습니다. 민감한 속성은 프레젠테이션과 함께 암호화하십시오. 인덱싱, 분류, 검색 또는 문서 관리 시스템이 비밀번호 없이 접근해야 하는 특정 요구가 있는 경우에만 공개 상태로 유지하십시오.
{{% /alert %}}

## **암호화된 프레젠테이션 속성 업데이트**

암호화된 PPTX 파일의 경우, [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/)로 로드된 프레젠테이션은 공개 메타데이터를 읽기 위한 것입니다. Aspose.Slides는 해당 메타데이터 전용 객체에서 변경된 속성을 저장할 수 없습니다. 공개 속성은 암호화된 프레젠테이션 내부의 해당 데이터와 일치해야 하기 때문입니다. 따라서 속성을 업데이트하려면 올바른 오프닝 비밀번호와 전체 로드가 필요합니다.

예제는 공개 문서 속성을 가진 암호화된 PPTX 프레젠테이션과 알려진 오프닝 비밀번호가 필요합니다. [LoadOptions.password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/)를 사용하여 전체 프레젠테이션을 열고, 공개 built-in 속성을 업데이트한 뒤 결과를 저장합니다. 그런 다음 [PresentationInfo.is_encrypted](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/is_encrypted/)를 사용하여 암호화가 유지되는지 확인하고, 비밀번호 없이 공개 메타데이터를 다시 열어 새 값을 검증합니다:

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

애플리케이션이 프레젠테이션 내용을 복호화하거나 로드할 수 없는 경우, 암호화된 PPTX 파일의 공개 속성은 읽기 전용으로 취급해야 합니다.

## **Built-in 속성 접근**

[DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) 클래스는 [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/), [DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/), 및 [DocumentProperties.created_time](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/created_time/)과 같은 typed 속성을 통해 built-in 메타데이터를 제공합니다. 이 예제는 기존 프레젠테이션을 열고 저장된 메타데이터를 콘솔에 출력합니다. 값은 입력 프레젠테이션에 따라 다르며, 일부 필드는 비어 있을 수 있습니다.

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

### **리비전 번호 및 편집 시간 보고**

`presentations` 폴더에 있는 각 PPTX 파일에 대한 리비전 번호와 총 편집 시간을 보고하려면, [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/)를 사용하여 슬라이드를 로드하지 않고 [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/)를 가져옵니다. Python은 기간을 `timedelta`로 표시하며, 기록된 시간이 24시간에 도달하면 일 수를 포함합니다.

```python
from pathlib import Path

import aspose.slides as slides

print("File | RevisionNumber | TotalEditingTime")
for path in Path("presentations").glob("*.pptx"):
    if path.is_file():
        info = slides.PresentationFactory.instance.get_presentation_info(str(path))
        properties = info.read_document_properties()
        print(f"{path.name} | {properties.revision_number} | {properties.total_editing_time}")
```

`1일 2시간 5분`의 기록된 편집 시간이 있는 프레젠테이션에 대해 보고서에 다음 행이 포함됩니다.

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1 day, 2:05:00
```

[DocumentProperties.revision_number](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/revision_number/)은 쓰기 가능한 메타데이터입니다. 해당 값만으로는 프레젠테이션이 저장된 횟수를 판단하거나 버전 기록을 재구성할 수 없습니다.

[DocumentProperties.total_editing_time](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/total_editing_time/)은 파일에 저장된 편집 기간을 보고합니다. `0:00:00` 값은 기록된 기간이 0임을 의미하며, 누군가 프레젠테이션을 편집했더라도 그렇습니다.

## **Built-in 속성 수정**

Built-in 메타데이터를 업데이트하려면 [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/)가 노출하는 쓰기 가능한 속성에 값을 할당합니다. 이 예제는 기존 프레젠테이션을 열고, [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/), [DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/), [DocumentProperties.subject](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/subject/), [DocumentProperties.comments](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/comments/), 및 [DocumentProperties.manager](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/manager/)를 설정한 다음 [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/)으로 업데이트된 프레젠테이션을 저장합니다. 저장된 PPTX에는 새로운 메타데이터가 포함됩니다.

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

## **하이퍼링크 기반 관리**

[DocumentProperties.hyperlink_base](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/hyperlink_base/)은 상대 하이퍼링크를 위한 문서 수준 기본값을 저장합니다. 이는 프레젠테이션 및 연결된 파일을 다른 위치로 이동할 때 유용합니다. 이는 개별 하이퍼링크의 [Hyperlink.external_url](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url/)와 별개이며, 기본값을 변경해도 저장된 링크 주소가 재작성되거나 절대 목적지가 변경되지는 않습니다.

예제는 `target.html`과 같은 상대 링크 및 파일이나 웹사이트에 대한 절대 링크를 모두 포함하는 프레젠테이션이 필요합니다. 기존 기본값을 읽고 새 기본 주소를 할당한 뒤 프레젠테이션을 저장 및 다시 열어 값을 확인합니다. 그런 다음 `""`로 기본값을 지우고 별도 저장 파일에서 빈 값을 검증합니다. 예제 기본 주소를 연결된 파일 위치로 교체하세요.

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

`target.pptx`에 대한 상대 링크는 기본값이 `old` 폴더를 가리킬 때 `old/target.pptx`를 열었습니다. 기본값을 `new` 폴더로 변경하고 저장 및 다시 열면 동일한 링크가 `new/target.pptx`를 엽니다. 절대 링크는 동일한 파일을 계속 엽니다. 프레젠테이션을 이동하거나 기본값을 변경하기 전후에 PowerPoint에서 상대 링크를 테스트하십시오.

## **사용자 정의 프레젠테이션 속성 추가**

사용자 정의 속성은 해당하는 built-in 필드가 없는 메타데이터를 저장합니다. [DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/) 메서드를 사용하면 속성 이름으로 값을 할당할 수 있습니다. 이 예제는 프레젠테이션을 생성하고 두 개의 텍스트 값과 정수 버전 값을 추가한 뒤 [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/)으로 프레젠테이션을 저장합니다. 기존 이름에 값을 할당하면 해당 속성의 값이 교체됩니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    document_properties = presentation.document_properties

    document_properties.set_custom_property_value("Reviewed by", "John Smith")
    document_properties.set_custom_property_value("Confidentiality level", "Internal")
    document_properties.set_custom_property_value("Document version", 2)

    presentation.save("CustomDocumentProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

## **사용자 정의 속성 접근 및 수정**

이 예제는 사용자 정의 속성을 포함하는 프레젠테이션을 열고 [DocumentProperties.count_of_custom_properties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/count_of_custom_properties/)를 사용해 이를 반복합니다. [DocumentProperties.get_custom_property_name](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_name/)는 0 기반 인덱스를 받아 [DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/)에서 사용된 이름을 반환합니다. 예제는 모든 사용자 정의 속성이 문자열인 프레젠테이션이 필요합니다. 각 원래 이름과 값을 출력하고, 모든 값을 번호가 매겨진 문자열로 교체한 뒤 변경사항을 저장합니다. 사용자 정의 속성이 없으면 반복문은 아무 변경도 수행하지 않습니다.

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

[DocumentProperties.get_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_value/)는 두 번째 인수로 전달된 한 요소 리스트를 통해 값을 반환합니다. 플레이스홀더는 저장된 속성의 유형과 일치해야 합니다: 문자열의 경우 `[""]`, 정수의 경우 `[0]`을 사용하십시오. 유형 불일치는 `InvalidCastException`을 발생시키며, 사용자 정의 속성 스키마에 맞게 플레이스홀더를 선택하세요.

## **실시간 예제**

Aspose.Slides API를 사용하여 문서 속성을 다루는 방법을 보려면 온라인 앱인 [**PowerPoint 메타데이터 보기 및 편집**](https://products.aspose.app/slides/metadata)를 사용해 보세요:

[![PowerPoint 메타데이터 보기 및 편집](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**프레젠테이션에서 built-in 속성을 제거하려면 어떻게 해야 하나요?**

Built-in 속성은 프레젠테이션의 필수 부분이며 완전히 제거할 수 없습니다. 하지만 값은 변경하거나, 해당 속성이 허용하는 경우 빈값으로 설정할 수 있습니다.

**이미 존재하는 사용자 정의 속성을 추가하면 어떻게 되나요?**

이미 존재하는 사용자 정의 속성을 추가하면 기존 값이 새 값으로 덮어써집니다. 속성을 미리 제거하거나 확인할 필요 없이 Aspose.Slides가 자동으로 값을 업데이트합니다.

**프레젠테이션을 전체 로드하지 않고 속성에 접근할 수 있나요?**

예. [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/get_presentation_info/)를 사용하고, 이어서 [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/)를 호출하면 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 인스턴스를 생성하지 않고도 저장된 문서 메타데이터를 읽을 수 있습니다. 전체 보고 예제와 형식별 제한 사항은 [Build a Lightweight Presentation Inventory](/slides/ko/python-net/examine-presentation/)를 확인하십시오.

**오프닝 비밀번호 없이 암호화된 프레젠테이션의 공개 속성을 읽을 수 있나요?**

예. 프레젠테이션이 [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/)를 `False`로 설정하여 암호화되었고, [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/)를 `True`로 로드한 경우 가능합니다.

**문서-속성 전용 모드에서 암호화된 PPTX 파일을 업데이트할 수 있나요?**

아니오. 공개 속성과 암호화된 속성 데이터는 일관성을 유지해야 하므로, 암호화된 PPTX 파일을 업데이트하려면 올바른 오프닝 비밀번호로 전체 프레젠테이션을 로드해야 합니다.