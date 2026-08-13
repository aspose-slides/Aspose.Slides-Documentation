---
title: .NET에서 PowerPoint 프레젠테이션의 민감도 레이블 관리
linktitle: 민감도 레이블
type: docs
weight: 50
url: /ko/net/sensitivity-labels/
keywords:
- 민감도 레이블
- Microsoft Purview
- Microsoft 정보 보호
- MIP 메타데이터
- 콘텐츠 마킹
- 정보 보호
- 문서 거버넌스
- PowerPoint
- PPTX
- 프레젠테이션 보안
- .NET
- C#
- Aspose.Slides
description: ".NET용 Aspose.Slides를 사용하여 PowerPoint PPTX 프레젠테이션에서 Microsoft Purview 민감도 레이블을 읽고, 추가하고, 업데이트하고, 제거하며, 마이그레이션합니다."
---
## **개요**

Microsoft Purview 민감도 레이블은 조직이 문서를 분류하고 관리하도록 도와줍니다. 자동 프레젠테이션 처리 중에 애플리케이션은 기존 레이블을 보존하거나, 정책에 의해 선택된 레이블을 적용하거나, 상태를 업데이트하거나, 이전 Microsoft Information Protection(MIP) 워크플로에서 작성된 레이블 메타데이터를 마이그레이션해야 할 수 있습니다.

Aspose.Slides는 최신 민감도 레이블 메타데이터를 [Presentation.SensitivityLabels](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/sensitivitylabels/)를 통해 노출합니다. 이 속성은 [ISensitivityLabelCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/isensitivitylabelcollection/)을 반환하며, 프레젠테이션을 PPTX로 저장하기 전에 검사하고 수정할 수 있습니다.

{{% alert color="info" title="Note" %}}
민감도 레이블 식별자와 정책 정보는 Microsoft Purview 구성에 의해 정의됩니다. 메타데이터를 추가하거나 마이그레이션하기 전에 환경에서 레이블 가용성 및 정책 요구 사항을 확인하십시오. [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/ko/net/aspose.slides/isensitivitylabel/contentmarktypes/) 값은 레이블과 연결된 콘텐츠 마킹을 설명하지만, 슬라이드에 보이는 텍스트나 도형을 직접 추가하지는 않습니다.
{{% /alert %}}

## **민감도 레이블 속성 이해**

각 [ISensitivityLabel](https://reference.aspose.com/slides/ko/net/aspose.slides/isensitivitylabel/)에는 다음 메타데이터가 포함됩니다:

| 속성 | 목적 |
| --- | --- |
| [ISensitivityLabel.Id](https://reference.aspose.com/slides/ko/net/aspose.slides/isensitivitylabel/id/) | Purview 정책에서 민감도 레이블을 식별합니다. |
| [ISensitivityLabel.SiteId](https://reference.aspose.com/slides/ko/net/aspose.slides/isensitivitylabel/siteid/) | 레이블 정책과 연결된 사이트를 식별합니다. |
| [ISensitivityLabel.IsEnabled](https://reference.aspose.com/slides/ko/net/aspose.slides/isensitivitylabel/isenabled/) | 레이블이 활성화되어 있는지 여부를 나타냅니다. |
| [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/ko/net/aspose.slides/isensitivitylabel/isremoved/) | 레이블이 제거되었음을 나타냅니다. 메타데이터에 제거 상태를 유지해야 할 경우 이 속성을 `true` 로 설정하십시오. |
| [ISensitivityLabel.AssignmentMethodType](https://reference.aspose.com/slides/ko/net/aspose.slides/isensitivitylabel/assignmentmethodtype/) | 레이블이 자동으로 적용되었는지 사용자 결정에 의해 적용되었는지를 지정합니다. |
| [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/ko/net/aspose.slides/isensitivitylabel/contentmarktypes/) | 레이블과 연결된 콘텐츠 마킹 유형을 나열합니다. |

[SensitivityLabelAssignmentType](https://reference.aspose.com/slides/ko/net/aspose.slides/sensitivitylabelassignmenttype/) 열거형은 레이블이 할당된 방식을 설명합니다:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/ko/net/aspose.slides/sensitivitylabelassignmenttype/) 은 기본 또는 자동 적용된 레이블을 나타냅니다.  
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/ko/net/aspose.slides/sensitivitylabelassignmenttype/) 은 사용자가 선택한 레이블을 나타내며, 수동 적용, 권장 및 필수 레이블을 포함합니다.

[SensitivityLabelContentType](https://reference.aspose.com/slides/ko/net/aspose.slides/sensitivitylabelcontenttype/) 열거형은 레이블과 연결된 마킹을 식별합니다:

| 값 | 의미 |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/ko/net/aspose.slides/sensitivitylabelcontenttype/) | 레이블이 기본 또는 자동으로 적용되었습니다. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/ko/net/aspose.slides/sensitivitylabelcontenttype/) | 머리글 콘텐츠 마킹이 레이블과 연결됩니다. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/ko/net/aspose.slides/sensitivitylabelcontenttype/) | 바닥글 콘텐츠 마킹이 레이블과 연결됩니다. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/ko/net/aspose.slides/sensitivitylabelcontenttype/) | 워터마크 콘텐츠 마킹이 레이블과 연결됩니다. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/ko/net/aspose.slides/sensitivitylabelcontenttype/) | 암호화 보호가 레이블과 연결됩니다. |

여러 마킹 유형을 하나의 레이블에 연결할 수 있습니다.

## **기존 민감도 레이블 나열**

[Presentation.SensitivityLabels](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/sensitivitylabels/)에서 최신 레이블 컬렉션을 읽고 열거합니다. 다음 예제는 각 레이블에 대해 저장된 모든 속성과 콘텐츠 마킹을 나열합니다:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

foreach (var sensitivityLabel in sensitivityLabels)
{
    Console.WriteLine("Label ID: " + sensitivityLabel.Id);
    Console.WriteLine("Site ID: " + sensitivityLabel.SiteId);
    Console.WriteLine("Enabled: " + sensitivityLabel.IsEnabled);
    Console.WriteLine("Removed: " + sensitivityLabel.IsRemoved);
    Console.WriteLine("Assignment method: " + sensitivityLabel.AssignmentMethodType);

    foreach (var contentMarkType in sensitivityLabel.ContentMarkTypes)
    {
        Console.WriteLine("Content marking: " + contentMarkType);
    }
}
```

## **컨텐츠 마킹이 있는 민감도 레이블 추가**

레이블 식별자, 사이트 식별자, 활성 상태 및 할당 방법을 사용하여 [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/ko/net/aspose.slides/isensitivitylabelcollection/add/)를 호출합니다. 메서드가 새 [ISensitivityLabel](https://reference.aspose.com/slides/ko/net/aspose.slides/isensitivitylabel/)을 반환하면 [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/ko/net/aspose.slides/isensitivitylabel/contentmarktypes/)를 통해 필요한 마킹 값을 추가합니다.

다음 예제는 바닥글 및 워터마크 마킹과 연결된 수동 선택 레이블을 추가하고, 결과를 PPTX로 저장합니다:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

var labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
var siteIdentifier = Guid.Parse("{aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee}");
var isEnabled = true;
var assignmentMethod = SensitivityLabelAssignmentType.Privileged;

var sensitivityLabel = sensitivityLabels.Add(
    labelIdentifier,
    siteIdentifier,
    isEnabled,
    assignmentMethod);

sensitivityLabel.ContentMarkTypes.Add(SensitivityLabelContentType.Footer);
sensitivityLabel.ContentMarkTypes.Add(SensitivityLabelContentType.Watermark);

presentation.Save("presentation_with_label.pptx", SaveFormat.Pptx);
```

## **민감도 레이블 업데이트**

[ISensitivityLabel](https://reference.aspose.com/slides/ko/net/aspose.slides/isensitivitylabel/) 속성은 읽기/쓰기 가능하지만, [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/ko/net/aspose.slides/isensitivitylabel/contentmarktypes/)가 반환하는 컬렉션은 리스트 연산을 통해 수정합니다. 필요한 레이블을 찾은 후 식별자, 사이트 식별자, 활성 상태, 할당 방법, 제거 상태 및 콘텐츠 마킹 유형을 업데이트할 수 있습니다. 프레젠테이션을 저장하여 변경 사항을 지속하십시오.

다음 예제는 첫 번째 레이블의 활성 상태와 할당 방법을 업데이트합니다:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

if (sensitivityLabels.Count > 0)
{
    var sensitivityLabel = sensitivityLabels[0];
    sensitivityLabel.IsEnabled = true;
    sensitivityLabel.AssignmentMethodType = SensitivityLabelAssignmentType.Privileged;
}

presentation.Save("presentation_with_updated_label.pptx", SaveFormat.Pptx);
```

## **민감도 레이블을 제거된 것으로 표시**

레이블이 제거된 사실을 보존하려면 해당 레이블을 찾아 [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/ko/net/aspose.slides/isensitivitylabel/isremoved/)을 `true` 로 설정합니다. 이렇게 하면 레이블 항목은 유지되면서 제거 상태가 기록됩니다. 현대 컬렉션에서 항목 자체를 삭제하려면 [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/ko/net/aspose.slides/isensitivitylabelcollection/removeat/)를 사용하고, 모든 항목을 삭제하려면 [ISensitivityLabelCollection.Clear](https://reference.aspose.com/slides/ko/net/aspose.slides/isensitivitylabelcollection/clear/)를 사용하십시오.

다음 예제는 특정 레이블을 제거된 것으로 표시하고 업데이트된 프레젠테이션을 저장합니다:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;
var targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";

foreach (var sensitivityLabel in sensitivityLabels)
{
    var isTargetLabel = string.Equals(
        sensitivityLabel.Id,
        targetLabelIdentifier,
        StringComparison.OrdinalIgnoreCase);

    if (isTargetLabel)
    {
        sensitivityLabel.IsRemoved = true;
        break;
    }
}

presentation.Save("presentation_with_removed_label.pptx", SaveFormat.Pptx);
```

## **레거시 MIP 민감도 레이블 읽기 및 마이그레이션**

이전 MIP 기반 워크플로는 최신 레이블 컬렉션 대신 사용자 정의 문서 속성에 민감도 레이블 메타데이터를 저장할 수 있습니다. [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/ko/net/aspose.slides/idocumentproperties/getsensitivitylabels/)를 사용해 해당 메타데이터를 읽습니다. 이 메서드는 레거시 사용자 정의 속성을 구문 분석하고 [ISensitivityLabel](https://reference.aspose.com/slides/ko/net/aspose.slides/isensitivitylabel/) 객체 배열을 반환합니다.

메타데이터를 마이그레이션하려면 반환된 각 레이블을 [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/ko/net/aspose.slides/isensitivitylabelcollection/add/)를 통해 최신 [ISensitivityLabelCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/isensitivitylabelcollection/)에 추가합니다. 중복 레이블 식별자를 추가하면 예외가 발생하므로, 예제에서는 대상 컬렉션을 사전 검사하여 각 레이블을 복사하기 전에 확인합니다. 추가 검증을 통해 각 레거시 레이블이 현재 Purview 정책에 여전히 존재하는지 확인할 수 있습니다.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation_with_legacy_labels.pptx");
var legacySensitivityLabels = presentation.DocumentProperties.GetSensitivityLabels();
var modernSensitivityLabels = presentation.SensitivityLabels;

foreach (var legacySensitivityLabel in legacySensitivityLabels)
{
    var labelAlreadyExists = false;

    foreach (var modernSensitivityLabel in modernSensitivityLabels)
    {
        labelAlreadyExists = string.Equals(
            modernSensitivityLabel.Id,
            legacySensitivityLabel.Id,
            StringComparison.OrdinalIgnoreCase);

        if (labelAlreadyExists)
        {
            break;
        }
    }

    if (!labelAlreadyExists)
    {
        modernSensitivityLabels.Add(legacySensitivityLabel);
    }
}

presentation.Save("presentation_with_modern_labels.pptx", SaveFormat.Pptx);
```

마이그레이션은 구문 분석된 레이블 객체를 최신 컬렉션에 복사합니다. 모든 사용자 정의 문서 속성을 지울 필요가 없으므로, 관련 없는 문서 메타데이터는 그대로 유지됩니다. [IPresentation.Save](https://reference.aspose.com/slides/ko/net/aspose.slides/ipresentation/save/)와 [SaveFormat.Pptx](https://reference.aspose.com/slides/ko/net/aspose.slides.export/saveformat/)를 사용하여 최신 레이블 메타데이터를 PPTX 파일에 기록하십시오.

## **FAQ**

**콘텐츠 마킹 유형을 추가하면 슬라이드에 보이는 머리글, 바닥글 또는 워터마크가 생성됩니까?**

아니오. [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/ko/net/aspose.slides/isensitivitylabel/contentmarktypes/)를 통해 추가된 값은 민감도 레이블과 연결된 마킹을 설명할 뿐이며, 프레젠테이션에 보이는 텍스트나 도형을 생성하지 않습니다. 이러한 마킹을 실제 슬라이드에 표시해야 하는 경우 별도로 해당 슬라이드 콘텐츠를 추가하십시오.

**레이블을 제거된 것으로 표시하는 것과 컬렉션에서 삭제하는 것의 차이점은 무엇입니까?**

[ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/ko/net/aspose.slides/isensitivitylabel/isremoved/)를 `true` 로 설정하면 레이블 항목은 유지되면서 제거 상태가 기록됩니다. 반면 [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/ko/net/aspose.slides/isensitivitylabelcollection/removeat/)를 호출하면 현대 컬렉션에서 해당 항목 자체가 삭제됩니다. 조직의 메타데이터 보존 요구 사항에 맞는 작업을 선택하십시오.

**프레젠테이션에 레거시 MIP 메타데이터와 최신 민감도 레이블을 동시에 포함할 수 있습니까?**

예. 레거시 레이블은 사용자 정의 문서 속성에 남아 있을 수 있으며, 최신 레이블은 [Presentation.SensitivityLabels](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/sensitivitylabels/)를 통해 액세스할 수 있습니다. [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/ko/net/aspose.slides/idocumentproperties/getsensitivitylabels/)를 사용해 레거시 메타데이터를 읽고, 현대 컬렉션에 아직 없는 유효한 레이블만 마이그레이션하십시오.

**동일한 식별자를 가진 레이블을 여러 번 추가하면 어떻게 됩니까?**

[ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/ko/net/aspose.slides/isensitivitylabelcollection/add/)는 컬렉션에 동일한 식별자를 가진 레이블이 이미 존재할 경우 `ArgumentException`을 발생시킵니다. 레이블을 추가하거나 마이그레이션하기 전에 기존 [ISensitivityLabel.Id](https://reference.aspose.com/slides/ko/net/aspose.slides/isensitivitylabel/id/) 값을 확인하십시오.

**업데이트된 민감도 레이블을 보존하려면 어떤 출력 형식을 사용해야 합니까?**

위 예제와 같이 [IPresentation.Save](https://reference.aspose.com/slides/ko/net/aspose.slides/ipresentation/save/)와 [SaveFormat.Pptx](https://reference.aspose.com/slides/ko/net/aspose.slides.export/saveformat/)를 사용하여 프레젠테이션을 PPTX 형식으로 저장하십시오.