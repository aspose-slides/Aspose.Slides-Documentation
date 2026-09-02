---
title: C++에서 PowerPoint 프레젠테이션의 민감도 레이블 관리
linktitle: 민감도 레이블
type: docs
weight: 50
url: /ko/cpp/sensitivity-labels/
keywords:
- 민감도 레이블
- Microsoft Purview
- Microsoft Information Protection
- MIP 메타데이터
- 콘텐츠 마킹
- 정보 보호
- 문서 관리
- PowerPoint
- PPTX
- 프레젠테이션 보안
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint PPTX 프레젠테이션에서 Microsoft Purview 민감도 레이블을 읽고, 추가하고, 업데이트하고, 제거하고, 마이그레이션합니다."
---
## **개요**

Microsoft Purview 민감도 레이블은 조직이 문서를 분류하고 관리하도록 도와줍니다. 자동 프레젠테이션 처리 중에 애플리케이션은 기존 레이블을 보존하거나 정책에서 선택된 레이블을 적용하고, 상태를 업데이트하거나, 이전 Microsoft Information Protection (MIP) 워크플로우에서 작성된 레이블 메타데이터를 마이그레이션해야 할 수 있습니다.

Aspose.Slides는 최신 민감도 레이블 메타데이터를 [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipresentation/get_sensitivitylabels/)을 통해 노출합니다. 이 메서드는 프레젠테이션을 PPTX로 저장하기 전에 검사하고 수정할 수 있는 [ISensitivityLabelCollection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isensitivitylabelcollection/)을 반환합니다.

{{% alert color="primary" title="참고" %}}
민감도 레이블 식별자와 정책 정보는 Microsoft Purview 구성에 따라 정의됩니다. 메타데이터를 추가하거나 마이그레이션하기 전에 환경에서 레이블 가용성 및 정책 요구사항을 확인하십시오. [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) 값은 레이블과 연결된 콘텐츠 마킹을 설명하지만, 슬라이드에 보이는 텍스트나 도형을 자체적으로 추가하지는 않습니다.
{{% /alert %}}

## **민감도 레이블 속성 이해**

각 [ISensitivityLabel](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isensitivitylabel/)에는 다음 메타데이터가 포함됩니다:

| 액세서 | 목적 |
| --- | --- |
| [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isensitivitylabel/get_id/), [ISensitivityLabel::set_Id](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isensitivitylabel/set_id/) | Purview 정책에서 민감도 레이블을 식별합니다. |
| [ISensitivityLabel::get_SiteId](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isensitivitylabel/get_siteid/), [ISensitivityLabel::set_SiteId](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isensitivitylabel/set_siteid/) | 레이블 정책과 연결된 사이트를 식별합니다. |
| [ISensitivityLabel::get_IsEnabled](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isensitivitylabel/get_isenabled/), [ISensitivityLabel::set_IsEnabled](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isensitivitylabel/set_isenabled/) | 레이블이 활성화되어 있는지 여부를 나타냅니다. |
| [ISensitivityLabel::get_IsRemoved](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isensitivitylabel/get_isremoved/), [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isensitivitylabel/set_isremoved/) | 레이블이 제거되었음을 나타냅니다. 제거 상태를 메타데이터에 유지해야 할 경우 값을 `true`로 설정하십시오. |
| [ISensitivityLabel::get_AssignmentMethodType](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isensitivitylabel/get_assignmentmethodtype/), [ISensitivityLabel::set_AssignmentMethodType](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isensitivitylabel/set_assignmentmethodtype/) | 레이블이 자동으로 적용되었는지 사용자 결정에 따라 적용되었는지를 지정합니다. |
| [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) | 레이블과 연결된 콘텐츠 마킹 유형을 나열합니다. |

[SensitivityLabelAssignmentType](https://reference.aspose.com/slides/ko/cpp/aspose.slides/sensitivitylabelassignmenttype/) 열거형은 레이블이 어떻게 할당되었는지를 설명합니다:

- [SensitivityLabelAssignmentType::Standard](https://reference.aspose.com/slides/ko/cpp/aspose.slides/sensitivitylabelassignmenttype/) 은 기본값이거나 자동으로 적용된 레이블을 나타냅니다.
- [SensitivityLabelAssignmentType::Privileged](https://reference.aspose.com/slides/ko/cpp/aspose.slides/sensitivitylabelassignmenttype/) 은 사용자의 결정에 따라 적용된 레이블을 나타내며, 수동 적용, 권장 및 필수 레이블을 포함합니다.

[SensitivityLabelContentType](https://reference.aspose.com/slides/ko/cpp/aspose.slides/sensitivitylabelcontenttype/) 열거형은 레이블에 연결된 마킹을 식별합니다:

| 값 | 의미 |
| --- | --- |
| [SensitivityLabelContentType::None](https://reference.aspose.com/slides/ko/cpp/aspose.slides/sensitivitylabelcontenttype/) | 레이블이 기본값이거나 자동으로 적용되었습니다. |
| [SensitivityLabelContentType::Header](https://reference.aspose.com/slides/ko/cpp/aspose.slides/sensitivitylabelcontenttype/) | 헤더 콘텐츠 마킹이 레이블과 연결되어 있습니다. |
| [SensitivityLabelContentType::Footer](https://reference.aspose.com/slides/ko/cpp/aspose.slides/sensitivitylabelcontenttype/) | 풋터 콘텐츠 마킹이 레이블과 연결되어 있습니다. |
| [SensitivityLabelContentType::Watermark](https://reference.aspose.com/slides/ko/cpp/aspose.slides/sensitivitylabelcontenttype/) | 워터마크 콘텐츠 마킹이 레이블과 연결되어 있습니다. |
| [SensitivityLabelContentType::Encryption](https://reference.aspose.com/slides/ko/cpp/aspose.slides/sensitivitylabelcontenttype/) | 암호화 보호가 레이블과 연결되어 있습니다. |

하나의 레이블에 여러 마킹 유형이 연결될 수 있습니다.

## **기존 민감도 레이블 나열**

[IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipresentation/get_sensitivitylabels/)에서 최신 레이블 컬렉션을 읽고 열거합니다. 다음 예제는 각 레이블에 저장된 모든 속성과 콘텐츠 마킹을 나열합니다:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <DOM/SensitivityLabelAssignmentType.h>
#include <DOM/SensitivityLabelContentType.h>
#include <system/collections/ilist.h>
#include <system/console.h>
#include <system/guid.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Presentation;
using System::Console;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();

for (auto&& sensitivityLabel : sensitivityLabels)
{
    auto labelIdentifier = sensitivityLabel->get_Id();
    auto siteIdentifier = sensitivityLabel->get_SiteId();
    auto isEnabled = sensitivityLabel->get_IsEnabled();
    auto isRemoved = sensitivityLabel->get_IsRemoved();
    auto assignmentMethod = sensitivityLabel->get_AssignmentMethodType();

    Console::WriteLine(u"Label ID: {0}", labelIdentifier);
    Console::WriteLine(u"Site ID: {0}", siteIdentifier);
    Console::WriteLine(u"Enabled: {0}", isEnabled);
    Console::WriteLine(u"Removed: {0}", isRemoved);
    Console::WriteLine(u"Assignment method: {0}", assignmentMethod);

    for (auto contentMarkType : sensitivityLabel->get_ContentMarkTypes())
    {
        Console::WriteLine(u"Content marking: {0}", contentMarkType);
    }
}

presentation->Dispose();
```

## **콘텐츠 마킹이 포함된 민감도 레이블 추가**

[ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isensitivitylabelcollection/add/)를 사용하여 레이블 식별자, 사이트 식별자, 활성 상태 및 할당 방법을 지정합니다. 메서드가 새로운 [ISensitivityLabel](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isensitivitylabel/)을 반환하면 [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/)를 통해 필요한 마킹 값을 추가합니다.

다음 예제는 풋터 및 워터마크 마킹과 연결된 수동 선택 레이블을 추가하고 결과를 PPTX로 저장합니다:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <DOM/SensitivityLabelAssignmentType.h>
#include <DOM/SensitivityLabelContentType.h>
#include <Export/SaveFormat.h>
#include <system/collections/ilist.h>
#include <system/guid.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::SensitivityLabelAssignmentType;
using Aspose::Slides::SensitivityLabelContentType;
using Aspose::Slides::Export::SaveFormat;
using System::Guid;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();

auto labelIdentifier = u"{11111111-2222-3333-4444-555555555555}";
auto siteIdentifier = Guid::Parse(u"{aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee}");
bool isEnabled = true;
auto assignmentMethod = SensitivityLabelAssignmentType::Privileged;

auto sensitivityLabel = sensitivityLabels->Add(
    labelIdentifier,
    siteIdentifier,
    isEnabled,
    assignmentMethod);

sensitivityLabel->get_ContentMarkTypes()->Add(SensitivityLabelContentType::Footer);
sensitivityLabel->get_ContentMarkTypes()->Add(SensitivityLabelContentType::Watermark);

presentation->Save(u"presentation_with_label.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **민감도 레이블 업데이트**

[ISensitivityLabel](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isensitivitylabel/) 값은 getter와 setter 메서드를 통해 읽고 쓸 수 있으며, [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/)가 반환하는 컬렉션은 리스트 연산을 통해 수정됩니다. 필요한 레이블을 찾은 후 식별자, 사이트 식별자, 활성 상태, 할당 방법, 제거 상태 및 콘텐츠 마킹 유형을 업데이트할 수 있습니다. 프레젠테이션을 저장하여 변경 사항을 영구히 적용하십시오.

다음 예제는 첫 번째 레이블의 활성 상태와 할당 방법을 업데이트합니다:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <DOM/SensitivityLabelAssignmentType.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::SensitivityLabelAssignmentType;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();
int labelCount = sensitivityLabels->get_Count();

if (labelCount > 0)
{
    auto sensitivityLabel = sensitivityLabels->idx_get(0);
    sensitivityLabel->set_IsEnabled(true);
    sensitivityLabel->set_AssignmentMethodType(SensitivityLabelAssignmentType::Privileged);
}

presentation->Save(u"presentation_with_updated_label.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **민감도 레이블을 제거된 상태로 표시**

레이블이 제거된 사실을 보존하려면 레이블을 찾아 [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isensitivitylabel/set_isremoved/)를 `true`와 함께 호출합니다. 이렇게 하면 레이블 항목이 유지되면서 제거 상태가 기록됩니다. 최신 컬렉션에서 항목을 완전히 삭제해야 하는 경우 [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isensitivitylabelcollection/removeat/)를 사용하고, 모든 항목을 삭제하려면 [ISensitivityLabelCollection::Clear](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isensitivitylabelcollection/clear/)를 사용하십시오.

다음 예제는 특정 레이블을 제거된 상태로 표시하고 업데이트된 프레젠테이션을 저장합니다:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;
using System::String;
using System::StringComparison;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();
auto targetLabelIdentifier = u"{11111111-2222-3333-4444-555555555555}";

for (auto&& sensitivityLabel : sensitivityLabels)
{
    auto labelIdentifier = sensitivityLabel->get_Id();
    bool isTargetLabel = String::Equals(
        labelIdentifier,
        targetLabelIdentifier,
        StringComparison::OrdinalIgnoreCase);

    if (isTargetLabel)
    {
        sensitivityLabel->set_IsRemoved(true);
        break;
    }
}

presentation->Save(u"presentation_with_removed_label.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **레거시 MIP 민감도 레이블 읽기 및 마이그레이션**

이전 MIP 기반 워크플로우는 최신 레이블 컬렉션 대신 사용자 정의 문서 속성에 민감도 레이블 메타데이터를 저장할 수 있습니다. 해당 메타데이터를 [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/ko/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/)로 읽어옵니다. 이 메서드는 레거시 사용자 정의 속성을 구문 분석하고 [ISensitivityLabel](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isensitivitylabel/) 객체 배열을 반환합니다.

메타데이터를 마이그레이션하려면 반환된 각 레이블을 [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isensitivitylabelcollection/add/)를 통해 최신 [ISensitivityLabelCollection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isensitivitylabelcollection/)에 추가합니다. 중복 레이블 식별자를 추가하면 예외가 발생하므로, 예제에서는 복사하기 전에 대상 컬렉션을 확인합니다. 현재 Purview 정책에 여전히 존재하는 레거시 레이블인지 확인하는 추가 검증을 수행할 수 있습니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/IDocumentProperties.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;
using System::String;
using System::StringComparison;

auto presentation = MakeObject<Presentation>(u"presentation_with_legacy_labels.pptx");
auto documentProperties = presentation->get_DocumentProperties();
auto legacySensitivityLabels = documentProperties->GetSensitivityLabels();
auto modernSensitivityLabels = presentation->get_SensitivityLabels();

for (auto&& legacySensitivityLabel : legacySensitivityLabels)
{
    bool labelAlreadyExists = false;
    auto legacyLabelIdentifier = legacySensitivityLabel->get_Id();

    for (auto&& modernSensitivityLabel : modernSensitivityLabels)
    {
        auto modernLabelIdentifier = modernSensitivityLabel->get_Id();
        labelAlreadyExists = String::Equals(
            modernLabelIdentifier,
            legacyLabelIdentifier,
            StringComparison::OrdinalIgnoreCase);

        if (labelAlreadyExists)
        {
            break;
        }
    }

    if (!labelAlreadyExists)
    {
        modernSensitivityLabels->Add(legacySensitivityLabel);
    }
}

presentation->Save(u"presentation_with_modern_labels.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

마이그레이션은 구문 분석된 레이블 객체를 최신 컬렉션에 복사합니다. 모든 사용자 정의 문서 속성을 삭제할 필요가 없으므로, 관련 없는 문서 메타데이터는 그대로 유지됩니다. [IPresentation::Save](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipresentation/save/)를 [SaveFormat::Pptx](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/saveformat/)와 함께 사용하여 최신 레이블 메타데이터를 PPTX 파일에 기록하십시오.

## **FAQ**

**콘텐츠 마킹 유형을 추가하면 슬라이드에 보이는 헤더, 풋터 또는 워터마크가 생성됩니까?**

아니요. [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/)를 통해 추가된 값은 민감도 레이블과 연결된 마킹을 설명하지만 프레젠테이션에 보이는 텍스트나 도형을 생성하지 않습니다. 해당 마킹을 실제 슬라이드에 표시해야 한다면 워크플로우에서 별도로 슬라이드 콘텐츠를 추가해야 합니다.

**레이블을 “제거된” 상태로 표시하는 것과 컬렉션에서 삭제하는 것의 차이는 무엇입니까?**

[ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isensitivitylabel/set_isremoved/)에 `true`를 지정하면 레이블 항목은 유지되면서 제거 상태가 기록됩니다. 반면 [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isensitivitylabelcollection/removeat/)를 호출하면 최신 컬렉션에서 해당 항목이 완전히 삭제됩니다. 조직의 메타데이터 보존 요구사항에 맞는 작업을 선택하십시오.

**프레젠테이션에 레거시 MIP 메타데이터와 최신 민감도 레이블을 모두 포함할 수 있습니까?**

예. 레거시 레이블은 사용자 정의 문서 속성에 남아 있을 수 있으며 최신 레이블은 [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipresentation/get_sensitivitylabels/)를 통해 접근할 수 있습니다. [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/ko/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/)를 사용하여 레거시 메타데이터를 읽고, 아직 최신 컬렉션에 없는 유효한 레이블만 마이그레이션하면 됩니다.

**동일한 식별자를 가진 레이블을 여러 번 추가하면 어떻게 됩니까?**

[ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isensitivitylabelcollection/add/)는 컬렉션에 동일한 식별자를 가진 레이블이 이미 존재할 경우 인수 예외를 발생시킵니다. 레이블을 추가하거나 마이그레이션하기 전에 기존 [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isensitivitylabel/get_id/) 값을 확인하십시오.

**업데이트된 민감도 레이블을 보존하려면 어떤 출력 형식을 사용해야 합니까?**

위 예제와 같이 [IPresentation::Save](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipresentation/save/)에 [SaveFormat::Pptx](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/saveformat/)를 지정하여 프레젠테이션을 PPTX 형식으로 저장하십시오.