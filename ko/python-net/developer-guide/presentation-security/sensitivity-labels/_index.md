---
title: Python에서 PowerPoint 프레젠테이션의 민감도 레이블 관리
linktitle: 민감도 레이블
type: docs
weight: 50
url: /ko/python-net/sensitivity-labels/
keywords:
- 민감도 레이블
- Microsoft Purview
- Microsoft Information Protection
- MIP 메타데이터
- 콘텐츠 표시
- 정보 보호
- 문서 거버넌스
- PowerPoint
- PPTX
- 프레젠테이션 보안
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint PPTX 프레젠테이션에서 Microsoft Purview 민감도 레이블을 읽고, 추가하고, 업데이트하고, 제거하고, 마이그레이션합니다."
---
## **개요**

Microsoft Purview 민감도 레이블은 조직이 문서를 분류하고 관리하도록 도와줍니다. 자동 프레젠테이션 처리 중에 애플리케이션은 기존 레이블을 보존하거나, 정책에 의해 선택된 레이블을 적용하거나, 상태를 업데이트하거나, 이전 Microsoft Information Protection(MIP) 워크플로우에서 작성된 레이블 메타데이터를 마이그레이션해야 할 수 있습니다.

Aspose.Slides for Python via .NET는 최신 민감도 레이블 메타데이터를 [Presentation.sensitivity_labels](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/sensitivity_labels/)을 통해 노출합니다. 이 속성은 프레젠테이션을 PPTX로 저장하기 전에 검사하고 수정할 수 있는 [SensitivityLabelCollection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/sensitivitylabelcollection/)을 반환합니다.

{{% alert color="primary" title="Note" %}}
민감도 레이블 식별자 및 정책 정보는 Microsoft Purview 구성에 의해 정의됩니다. 메타데이터를 추가하거나 마이그레이션하기 전에 환경에서 레이블 사용 가능 여부와 정책 요구 사항을 확인하십시오. [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/ko/python-net/aspose.slides/sensitivitylabel/content_mark_types/) 값은 레이블과 연결된 콘텐츠 표시를 설명하지만 슬라이드에 눈에 보이는 텍스트나 도형을 추가하지는 않습니다.
{{% /alert %}}

## **민감도 레이블 속성 이해**

각 [SensitivityLabel](https://reference.aspose.com/slides/ko/python-net/aspose.slides/sensitivitylabel/)은 다음 메타데이터를 포함합니다:

| 속성 | 용도 |
| --- | --- |
| [SensitivityLabel.id](https://reference.aspose.com/slides/ko/python-net/aspose.slides/sensitivitylabel/id/) | Purview 정책에서 민감도 레이블을 식별합니다. |
| [SensitivityLabel.site_id](https://reference.aspose.com/slides/ko/python-net/aspose.slides/sensitivitylabel/site_id/) | 레이블 정책과 연결된 사이트를 식별합니다. |
| [SensitivityLabel.is_enabled](https://reference.aspose.com/slides/ko/python-net/aspose.slides/sensitivitylabel/is_enabled/) | 레이블이 활성화되어 있는지 여부를 나타냅니다. |
| [SensitivityLabel.is_removed](https://reference.aspose.com/slides/ko/python-net/aspose.slides/sensitivitylabel/is_removed/) | 레이블이 제거되었음을 나타냅니다. 메타데이터에 제거 상태를 유지해야 할 때 이 속성을 `True`로 설정합니다. |
| [SensitivityLabel.assignment_method_type](https://reference.aspose.com/slides/ko/python-net/aspose.slides/sensitivitylabel/assignment_method_type/) | 레이블이 자동으로 적용되었는지 사용자 결정에 의해 적용되었는지 지정합니다. |
| [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/ko/python-net/aspose.slides/sensitivitylabel/content_mark_types/) | 레이블과 연결된 콘텐츠 표시 유형을 나열합니다. |

[SensitivityLabelAssignmentType](https://reference.aspose.com/slides/ko/python-net/aspose.slides/sensitivitylabelassignmenttype/) 열거형은 레이블이 할당된 방식을 설명합니다:

- [SensitivityLabelAssignmentType.STANDARD](https://reference.aspose.com/slides/ko/python-net/aspose.slides/sensitivitylabelassignmenttype/)는 기본 또는 자동 적용된 레이블을 나타냅니다.
- [SensitivityLabelAssignmentType.PRIVILEGED](https://reference.aspose.com/slides/ko/python-net/aspose.slides/sensitivitylabelassignmenttype/)는 사용자 결정에 의해 적용된 레이블을 나타내며, 수동 적용, 권장 및 필수 레이블을 포함합니다.

[SensitivityLabelContentType](https://reference.aspose.com/slides/ko/python-net/aspose.slides/sensitivitylabelcontenttype/) 열거형은 레이블과 연관된 표시를 식별합니다:

| 값 | 의미 |
| --- | --- |
| [SensitivityLabelContentType.NONE](https://reference.aspose.com/slides/ko/python-net/aspose.slides/sensitivitylabelcontenttype/) | 레이블이 기본 또는 자동으로 적용되었습니다. |
| [SensitivityLabelContentType.HEADER](https://reference.aspose.com/slides/ko/python-net/aspose.slides/sensitivitylabelcontenttype/) | 헤더 콘텐츠 표시가 레이블과 연결됩니다. |
| [SensitivityLabelContentType.FOOTER](https://reference.aspose.com/slides/ko/python-net/aspose.slides/sensitivitylabelcontenttype/) | 푸터 콘텐츠 표시가 레이블과 연결됩니다. |
| [SensitivityLabelContentType.WATERMARK](https://reference.aspose.com/slides/ko/python-net/aspose.slides/sensitivitylabelcontenttype/) | 워터마크 콘텐츠 표시가 레이블과 연결됩니다. |
| [SensitivityLabelContentType.ENCRYPTION](https://reference.aspose.com/slides/ko/python-net/aspose.slides/sensitivitylabelcontenttype/) | 암호화 보호가 레이블과 연결됩니다. |

여러 표시 유형을 하나의 레이블에 연결할 수 있습니다.

## **기존 민감도 레이블 나열**

[Presentation.sensitivity_labels](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/sensitivity_labels/)에서 최신 레이블 컬렉션을 읽고 열거합니다. 다음 예제는 각 레이블에 저장된 모든 속성과 콘텐츠 표시를 나열합니다:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    for sensitivity_label in sensitivity_labels:
        print("Label ID:", sensitivity_label.id)
        print("Site ID:", sensitivity_label.site_id)
        print("Enabled:", sensitivity_label.is_enabled)
        print("Removed:", sensitivity_label.is_removed)
        print("Assignment method:", sensitivity_label.assignment_method_type)

        for content_mark_type in sensitivity_label.content_mark_types:
            print("Content marking:", content_mark_type)
```

## **콘텐츠 표시와 함께 민감도 레이블 추가**

[SensitivityLabelCollection.add](https://reference.aspose.com/slides/ko/python-net/aspose.slides/sensitivitylabelcollection/add/)를 사용하여 레이블 식별자, 사이트 식별자, 활성 상태 및 할당 방법을 지정합니다. 사이트 식별자는 Python `uuid.UUID` 객체로 전달합니다. 메서드가 새 [SensitivityLabel](https://reference.aspose.com/slides/ko/python-net/aspose.slides/sensitivitylabel/)을 반환하면 필요한 표시 값을 [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/ko/python-net/aspose.slides/sensitivitylabel/content_mark_types/)에 추가합니다.

다음 예제는 푸터 및 워터마크 표시와 연결된 수동 선택 레이블을 추가하고 결과를 PPTX로 저장합니다:

```python
import uuid
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    label_identifier = "{11111111-2222-3333-4444-555555555555}"
    site_identifier = uuid.UUID("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee")
    is_enabled = True
    assignment_method = slides.SensitivityLabelAssignmentType.PRIVILEGED

    sensitivity_label = sensitivity_labels.add(
        label_identifier,
        site_identifier,
        is_enabled,
        assignment_method
    )

    sensitivity_label.content_mark_types.append(slides.SensitivityLabelContentType.FOOTER)
    sensitivity_label.content_mark_types.append(slides.SensitivityLabelContentType.WATERMARK)

    presentation.save("presentation_with_label.pptx", slides.export.SaveFormat.PPTX)
```

## **민감도 레이블 업데이트**

[SensitivityLabel] 속성은 읽기/쓰기 가능하지만, [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/ko/python-net/aspose.slides/sensitivitylabel/content_mark_types/)가 반환하는 목록은 해당 리스트 연산을 통해 수정합니다. 필요한 레이블을 찾은 후 식별자, 사이트 식별자, 활성 상태, 할당 방법, 제거 상태 및 콘텐츠 표시 유형을 업데이트할 수 있습니다. 프레젠테이션을 저장하여 변경 사항을 유지합니다.

다음 예제는 첫 번째 레이블의 활성 상태와 할당 방법을 업데이트합니다:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    if sensitivity_labels.count > 0:
        sensitivity_label = sensitivity_labels[0]
        sensitivity_label.is_enabled = True
        sensitivity_label.assignment_method_type = (
            slides.SensitivityLabelAssignmentType.PRIVILEGED
        )

    presentation.save("presentation_with_updated_label.pptx", slides.export.SaveFormat.PPTX)
```

## **민감도 레이블을 제거된 것으로 표시**

레이블이 제거된 사실을 보존하려면 해당 레이블을 찾아 [SensitivityLabel.is_removed](https://reference.aspose.com/slides/ko/python-net/aspose.slides/sensitivitylabel/is_removed/)를 `True`로 설정합니다. 이렇게 하면 레이블 항목을 유지하면서 제거된 상태를 기록합니다. 대신 최신 컬렉션에서 항목을 삭제해야 하는 경우 [SensitivityLabelCollection.remove_at](https://reference.aspose.com/slides/ko/python-net/aspose.slides/sensitivitylabelcollection/remove_at/)를 사용하고, 모든 항목을 삭제하려면 [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/ko/python-net/aspose.slides/sensitivitylabelcollection/clear/)를 사용하십시오.

다음 예제는 특정 레이블을 제거된 것으로 표시하고 업데이트된 프레젠테이션을 저장합니다:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels
    target_label_identifier = "{11111111-2222-3333-4444-555555555555}"

    for sensitivity_label in sensitivity_labels:
        identifiers_match = (
            sensitivity_label.id.casefold() == target_label_identifier.casefold()
        )

        if identifiers_match:
            sensitivity_label.is_removed = True
            break

    presentation.save("presentation_with_removed_label.pptx", slides.export.SaveFormat.PPTX)
```

## **레거시 MIP 민감도 레이블 읽기 및 마이그레이션**

이전 MIP 기반 워크플로우는 최신 레이블 컬렉션 대신 사용자 지정 문서 속성에 민감도 레이블 메타데이터를 저장할 수 있습니다. 해당 메타데이터는 [DocumentProperties.get_sensitivity_labels](https://reference.aspose.com/slides/ko/python-net/aspose.slides/documentproperties/get_sensitivity_labels/)로 읽습니다. 이 메서드는 레거시 사용자 지정 속성을 파싱하고 [SensitivityLabel](https://reference.aspose.com/slides/ko/python-net/aspose.slides/sensitivitylabel/) 객체를 반환합니다.

메타데이터를 마이그레이션하려면 반환된 각 레이블을 [SensitivityLabelCollection.add](https://reference.aspose.com/slides/ko/python-net/aspose.slides/sensitivitylabelcollection/add/)를 통해 최신 [SensitivityLabelCollection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/sensitivitylabelcollection/)에 추가합니다. 중복 레이블 식별자를 추가하면 예외가 발생하므로 예제에서는 복사하기 전에 대상 컬렉션을 확인합니다. 현재 Purview 정책에 각 레거시 레이블이 아직 존재하는지 확인하는 추가 검증을 추가할 수 있습니다.

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_legacy_labels.pptx") as presentation:
    legacy_sensitivity_labels = (
        presentation.document_properties.get_sensitivity_labels()
    )
    modern_sensitivity_labels = presentation.sensitivity_labels

    for legacy_sensitivity_label in legacy_sensitivity_labels:
        label_already_exists = False

        for modern_sensitivity_label in modern_sensitivity_labels:
            label_already_exists = (
                modern_sensitivity_label.id.casefold()
                == legacy_sensitivity_label.id.casefold()
            )

            if label_already_exists:
                break

        if not label_already_exists:
            modern_sensitivity_labels.add(legacy_sensitivity_label)

    presentation.save("presentation_with_modern_labels.pptx", slides.export.SaveFormat.PPTX)
```

마이그레이션은 파싱된 레이블 객체를 최신 컬렉션에 복사합니다. 모든 사용자 지정 문서 속성을 삭제할 필요가 없으므로 관련 없는 문서 메타데이터는 그대로 유지됩니다. 최신 레이블 메타데이터를 PPTX 파일에 기록하려면 [Presentation.save](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/save/)를 [SaveFormat.PPTX](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/saveformat/)와 함께 사용하십시오.

## **FAQ**

**콘텐츠 표시 유형을 추가하면 슬라이드에 눈에 보이는 헤더, 푸터 또는 워터마크가 생성됩니까?**

아니요. [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/ko/python-net/aspose.slides/sensitivitylabel/content_mark_types/)를 통해 추가된 값은 민감도 레이블과 연결된 표시를 설명합니다. 프레젠테이션에 눈에 보이는 텍스트나 도형을 생성하지 않습니다. 워크플로우에서 해당 표시를 표시해야 하는 경우 별도로 해당 슬라이드 콘텐츠를 추가하십시오.

**레이블을 제거된 것으로 표시하는 것과 컬렉션에서 삭제하는 것의 차이는 무엇입니까?**

[SensitivityLabel.is_removed](https://reference.aspose.com/slides/ko/python-net/aspose.slides/sensitivitylabel/is_removed/)를 `True`로 설정하면 레이블 항목을 유지하고 제거된 상태를 기록합니다. [SensitivityLabelCollection.remove_at](https://reference.aspose.com/slides/ko/python-net/aspose.slides/sensitivitylabelcollection/remove_at/)를 호출하면 최신 컬렉션에서 해당 항목이 삭제됩니다. 조직의 메타데이터 보존 요구 사항에 맞는 작업을 선택하십시오.

**프레젠테이션에 레거시 MIP 메타데이터와 최신 민감도 레이블을 모두 포함할 수 있습니까?**

예. 레거시 레이블은 사용자 지정 문서 속성에 남아 있을 수 있으며 최신 레이블은 [Presentation.sensitivity_labels](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/sensitivity_labels/)를 통해 사용할 수 있습니다. [DocumentProperties.get_sensitivity_labels](https://reference.aspose.com/slides/ko/python-net/aspose.slides/documentproperties/get_sensitivity_labels/)를 사용하여 레거시 메타데이터를 읽고 최신 컬렉션에 아직 존재하지 않는 유효한 레이블만 마이그레이션하십시오.

**같은 식별자를 가진 레이블을 여러 번 추가하면 어떻게 됩니까?**

[SensitivityLabelCollection.add](https://reference.aspose.com/slides/ko/python-net/aspose.slides/sensitivitylabelcollection/add/)는 컬렉션에 동일한 식별자를 가진 레이블이 이미 존재할 경우 예외를 발생시킵니다. 레이블을 추가하거나 마이그레이션하기 전에 기존 [SensitivityLabel.id](https://reference.aspose.com/slides/ko/python-net/aspose.slides/sensitivitylabel/id/) 값을 확인하십시오.

**업데이트된 민감도 레이블을 보존하려면 어떤 출력 형식을 사용해야 합니까?**

위 예시와 같이 [Presentation.save](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/save/)를 [SaveFormat.PPTX](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/saveformat/)와 함께 호출하여 프레젠테이션을 PPTX 형식으로 저장하십시오.