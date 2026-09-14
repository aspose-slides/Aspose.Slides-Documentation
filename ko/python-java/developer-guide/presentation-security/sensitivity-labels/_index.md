---
title: Python에서 PowerPoint 프레젠테이션의 민감도 레이블 관리
linktitle: 민감도 레이블
type: docs
weight: 50
url: /ko/python-java/sensitivity-labels/
keywords:
- 민감도 레이블
- Microsoft Purview
- Microsoft Information Protection
- MIP 메타데이터
- 콘텐츠 표시
- 정보 보호
- 문서 관리
- PowerPoint
- PPTX
- 프레젠테이션 보안
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 PowerPoint PPTX 프레젠테이션에서 Microsoft Purview 민감도 레이블을 읽고, 추가하고, 업데이트하고, 제거하며, 마이그레이션합니다."
---
## **개요**

Microsoft Purview 민감도 레이블은 조직이 문서를 분류하고 관리하도록 도와줍니다. 자동 프레젠테이션 처리 중에 애플리케이션은 기존 레이블을 유지하거나, 정책에 의해 선택된 레이블을 적용하거나, 상태를 업데이트하거나, 이전 Microsoft Information Protection (MIP) 워크플로우에서 작성된 레이블 메타데이터를 마이그레이션해야 할 수 있습니다.

Aspose.Slides는 최신 민감도 레이블 메타데이터를 [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getSensitivityLabels) 를 통해 제공합니다. 이 메서드는 프레젠테이션을 PPTX로 저장하기 전에 검사하고 수정할 수 있는 [SensitivityLabelCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sensitivitylabelcollection/)을 반환합니다.

{{% alert color="info" title="Note" %}}
민감도 레이블 식별자 및 정책 정보는 Microsoft Purview 구성에 의해 정의됩니다. 메타데이터를 추가하거나 마이그레이션하기 전에 환경에서 레이블 가용성과 정책 요구사항을 확인하십시오. [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) 값은 레이블과 연관된 콘텐츠 표시를 설명하며, 슬라이드에 보이는 텍스트나 도형을 직접 추가하지는 않습니다.
{{% /alert %}}

## **민감도 레이블 속성 이해**

각 [SensitivityLabel](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sensitivitylabel/) 은 다음 메타데이터를 포함합니다:

| 메서드 | 목적 |
| --- | --- |
| [getId](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sensitivitylabel/#getId) and [setId](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sensitivitylabel/#setId) | Purview 정책에서 민감도 레이블 식별자를 가져오거나 설정합니다. |
| [getSiteId](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sensitivitylabel/#getSiteId) and [setSiteId](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sensitivitylabel/#setSiteId) | 레이블 정책과 연결된 사이트를 가져오거나 설정합니다. |
| [isEnabled](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sensitivitylabel/#isEnabled) and [setEnabled](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sensitivitylabel/#setEnabled) | 레이블이 활성화되어 있는지 여부를 가져오거나 설정합니다. |
| [isRemoved](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sensitivitylabel/#isRemoved) and [setRemoved](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sensitivitylabel/#setRemoved) | 레이블이 제거되었는지 여부를 가져오거나 설정합니다. 메타데이터에 제거 상태를 유지해야 할 경우 값을 `True` 로 설정합니다. |
| [getAssignmentMethodType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) and [setAssignmentMethodType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | 레이블이 자동으로 적용되었는지 또는 사용자 결정에 따라 적용되었는지 여부를 가져오거나 설정합니다. |
| [getContentMarkTypes](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | 레이블과 연관된 콘텐츠 표시 유형을 가져옵니다. |

[SensitivityLabelAssignmentType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sensitivitylabelassignmenttype/) 클래스는 레이블이 할당된 방식을 정의합니다:

- [Standard](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sensitivitylabelassignmenttype/)는 기본 또는 자동 적용된 레이블을 나타냅니다.
- [Privileged](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sensitivitylabelassignmenttype/)는 수동 적용, 권장 및 필수 레이블을 포함하여 사용자 결정에 따라 적용된 레이블을 나타냅니다.

[SensitivityLabelContentType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sensitivitylabelcontenttype/) 클래스는 레이블과 연관된 표시를 정의합니다:

| 값 | 의미 |
| --- | --- |
| [None](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sensitivitylabelcontenttype/) | 레이블이 기본값이거나 자동으로 적용되었습니다. |
| [Header](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sensitivitylabelcontenttype/) | 레이블에 헤더 콘텐츠 표시가 연관됩니다. |
| [Footer](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sensitivitylabelcontenttype/) | 레이블에 푸터 콘텐츠 표시가 연관됩니다. |
| [Watermark](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sensitivitylabelcontenttype/) | 레이블에 워터마크 콘텐츠 표시가 연관됩니다. |
| [Encryption](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sensitivitylabelcontenttype/) | 레이블에 암호화 보호가 연관됩니다. |

하나의 레이블에 여러 표시 유형을 연관시킬 수 있습니다.

## **기존 민감도 레이블 나열**

[Presentation.getSensitivityLabels](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getSensitivityLabels) 로부터 최신 레이블 컬렉션을 읽고 열거합니다. 다음 예제는 각 레이블에 저장된 모든 속성과 콘텐츠 표시를 나열합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    for sensitivity_label in sensitivity_labels:
        print("Label ID:", sensitivity_label.getId())
        print("Site ID:", sensitivity_label.getSiteId())
        print("Enabled:", sensitivity_label.isEnabled())
        print("Removed:", sensitivity_label.isRemoved())
        print("Assignment method:", sensitivity_label.getAssignmentMethodType())

        for content_mark_type in sensitivity_label.getContentMarkTypes():
            print("Content marking:", content_mark_type)
finally:
    presentation.dispose()
```

## **콘텐츠 표시와 함께 민감도 레이블 추가**

[SensitivityLabelCollection.add](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sensitivitylabelcollection/#add) 를 레이블 식별자, 사이트 식별자, 활성 상태 및 할당 방식을 사용해 호출합니다. 메서드가 새로운 [SensitivityLabel](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sensitivitylabel/) 를 반환하면, [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) 가 반환하는 리스트를 통해 필요한 표시 값을 추가합니다.

다음 예제는 푸터 및 워터마크 표시와 연관된 수동 선택 레이블을 추가하고, 결과를 PPTX로 저장합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SensitivityLabelAssignmentType, SensitivityLabelContentType
from java.util import UUID

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    label_identifier = "{11111111-2222-3333-4444-555555555555}"
    site_identifier = UUID.fromString("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee")
    is_enabled = True
    assignment_method = SensitivityLabelAssignmentType.Privileged

    sensitivity_label = sensitivity_labels.add(label_identifier, site_identifier, is_enabled, assignment_method)

    sensitivity_label.getContentMarkTypes().addItem(jpype.JInt(SensitivityLabelContentType.Footer))
    sensitivity_label.getContentMarkTypes().addItem(jpype.JInt(SensitivityLabelContentType.Watermark))

    presentation.save("presentation_with_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **민감도 레이블 업데이트**

[SensitivityLabel](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sensitivitylabel/) 값은 읽기/쓰기가 가능하지만, [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) 가 반환하는 리스트는 해당 리스트 연산을 통해 수정됩니다. 필요한 레이블을 찾은 후에는 식별자, 사이트 식별자, 활성 상태, 할당 방식, 제거 상태 및 콘텐츠 표시 유형을 업데이트할 수 있습니다. 프레젠테이션을 저장하여 변경 사항을 지속합니다.

다음 예제는 첫 번째 레이블의 활성 상태와 할당 방식을 업데이트합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SensitivityLabelAssignmentType

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    if sensitivity_labels.getCount() > 0:
        sensitivity_label = sensitivity_labels.get_Item(0)
        sensitivity_label.setEnabled(True)
        sensitivity_label.setAssignmentMethodType(SensitivityLabelAssignmentType.Privileged)

    presentation.save("presentation_with_updated_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **민감도 레이블을 제거됨으로 표시**

레이블이 제거된 사실을 보존하려면 해당 레이블을 찾은 뒤 `True` 로 [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sensitivitylabel/#setRemoved) 를 호출합니다. 이렇게 하면 레이블 항목은 유지되면서 제거 상태가 기록됩니다. 대신 최신 컬렉션에서 항목을 삭제해야 하면 [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sensitivitylabelcollection/#removeAt) 를 사용하고, 모든 항목을 삭제하려면 [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sensitivitylabelcollection/#clear) 를 사용합니다.

다음 예제는 특정 레이블을 제거됨으로 표시하고 업데이트된 프레젠테이션을 저장합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()
    target_label_identifier = "{11111111-2222-3333-4444-555555555555}"

    for sensitivity_label in sensitivity_labels:
        is_target_label = str(sensitivity_label.getId()).casefold() == target_label_identifier.casefold()

        if is_target_label:
            sensitivity_label.setRemoved(True)
            break

    presentation.save("presentation_with_removed_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **레거시 MIP 민감도 레이블 읽기 및 마이그레이션**

이전 MIP 기반 워크플로우는 최신 레이블 컬렉션 대신 사용자 지정 문서 속성에 민감도 레이블 메타데이터를 저장할 수 있습니다. 해당 메타데이터는 [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/ko/python-java/aspose.slides/documentproperties/#getSensitivityLabels) 로 읽습니다. 이 메서드는 레거시 사용자 지정 속성을 파싱하여 [SensitivityLabel](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sensitivitylabel/) 객체 배열을 반환합니다.

메타데이터를 마이그레이션하려면, 반환된 각 레이블을 [SensitivityLabelCollection.add](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sensitivitylabelcollection/#add) 를 통해 최신 [SensitivityLabelCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sensitivitylabelcollection/) 에 추가합니다. 중복 레이블 식별자를 추가하면 예외가 발생하므로, 예제에서는 각 레이블을 복사하기 전에 대상 컬렉션을 확인합니다. 또한 각 레거시 레이블이 현재 Purview 정책에 여전히 존재하는지 추가 검증을 할 수 있습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation_with_legacy_labels.pptx")
try:
    legacy_sensitivity_labels = presentation.getDocumentProperties().getSensitivityLabels()
    modern_sensitivity_labels = presentation.getSensitivityLabels()

    for legacy_sensitivity_label in legacy_sensitivity_labels:
        label_already_exists = False

        for modern_sensitivity_label in modern_sensitivity_labels:
            label_already_exists = str(modern_sensitivity_label.getId()).casefold() == str(legacy_sensitivity_label.getId()).casefold()

            if label_already_exists:
                break

        if not label_already_exists:
            modern_sensitivity_labels.add(legacy_sensitivity_label)

    presentation.save("presentation_with_modern_labels.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

마이그레이션은 파싱된 레이블 객체를 최신 컬렉션에 복사합니다. 모든 사용자 지정 문서 속성을 지울 필요가 없으므로 관련 없는 문서 메타데이터는 그대로 유지됩니다. 최신 레이블 메타데이터를 PPTX 파일에 기록하려면 [Presentation.save](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#save) 와 [SaveFormat.Pptx](https://reference.aspose.com/slides/ko/python-java/aspose.slides/saveformat/) 를 사용하십시오.

## **FAQ**

**콘텐츠 표시 유형을 추가하면 슬라이드에 보이는 헤더, 푸터 또는 워터마크가 생성됩니까?**

아니요. [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) 가 반환하는 리스트에 추가된 값은 민감도 레이블과 연관된 표시를 설명합니다. 이는 프레젠테이션에 보이는 텍스트나 도형을 생성하지 않습니다. 워크플로우에서 해당 표시를 렌더링해야 한다면 별도로 해당 슬라이드 콘텐츠를 추가하십시오.

**레이블을 제거됨으로 표시하는 것과 컬렉션에서 삭제하는 것의 차이점은 무엇입니까?**

[SensitivityLabel.setRemoved](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sensitivitylabel/#setRemoved) 를 `True` 로 호출하면 레이블 항목이 유지되고 제거 상태가 기록됩니다. [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sensitivitylabelcollection/#removeAt) 를 호출하면 현대 컬렉션에서 해당 항목이 삭제됩니다. 조직의 메타데이터 보존 요구사항에 맞는 작업을 선택하십시오.

**프레젠테이션에 레거시 MIP 메타데이터와 최신 민감도 레이블을 동시에 포함할 수 있습니까?**

예. 레거시 레이블은 사용자 지정 문서 속성에 남아 있을 수 있고 최신 레이블은 [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getSensitivityLabels) 로 사용할 수 있습니다. 레거시 메타데이터를 읽으려면 [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/ko/python-java/aspose.slides/documentproperties/#getSensitivityLabels) 를 사용하고, 현대 컬렉션에 아직 존재하지 않는 유효한 레이블만 마이그레이션하십시오.

**동일 식별자를 가진 레이블을 여러 번 추가하면 어떻게 됩니까?**

[SensitivityLabelCollection.add](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sensitivitylabelcollection/#add) 는 컬렉션에 동일 식별자를 가진 레이블이 이미 존재하면 예외를 발생시킵니다. 레이블을 추가하거나 마이그레이션하기 전에 [SensitivityLabel.getId](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sensitivitylabel/#getId) 로 반환되는 기존 값을 확인하십시오.

**업데이트된 민감도 레이블을 보존하기 위해 어떤 출력 형식을 사용해야 합니까?**

위 예제와 같이 [Presentation.save](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#save) 에 [SaveFormat.Pptx](https://reference.aspose.com/slides/ko/python-java/aspose.slides/saveformat/) 를 지정하여 프레젠테이션을 PPTX 형식으로 저장하십시오.