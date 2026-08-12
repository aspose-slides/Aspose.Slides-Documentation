---
title: PowerPoint 프레젠테이션에서 PHP로 민감도 레이블 관리
linktitle: 민감도 레이블
type: docs
weight: 50
url: /ko/php-java/sensitivity-labels/
keywords:
- 민감도 레이블
- Microsoft Purview
- Microsoft Information Protection
- MIP 메타데이터
- 콘텐츠 마킹
- 정보 보호
- 문서 거버넌스
- PowerPoint
- PPTX
- 프레젠테이션 보안
- PHP
- Aspose.Slides
description: "PHP에서 PowerPoint PPTX 프레젠테이션의 Microsoft Purview 민감도 레이블을 읽고, 추가하고, 업데이트하고, 제거하며, 마이그레이션합니다."
---
## **개요**

Microsoft Purview 민감도 레이블은 조직이 문서를 분류하고 관리하도록 도와줍니다. 자동 프레젠테이션 처리 중에 애플리케이션은 기존 레이블을 유지하거나, 정책에 의해 선택된 레이블을 적용하거나, 상태를 업데이트하거나, 오래된 Microsoft Information Protection(MIP) 워크플로에서 기록된 레이블 메타데이터를 마이그레이션해야 할 수 있습니다.

Aspose.Slides for PHP via Java은 최신 민감도 레이블 메타데이터를 [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#getSensitivityLabels) 를 통해 노출합니다. 이 메서드는 [SensitivityLabelCollection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/sensitivitylabelcollection/)을 반환하며, 프레젠테이션을 PPTX로 저장하기 전에 검사 및 수정할 수 있습니다.

{{% alert color="primary" title="Note" %}}
민감도 레이블 식별자와 정책 정보는 Microsoft Purview 구성에 의해 정의됩니다. 메타데이터를 추가하거나 마이그레이션하기 전에 환경에서 레이블 가용성과 정책 요구 사항을 확인하십시오. [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/ko/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) 값은 레이블에 연결된 콘텐츠 마킹을 설명하지만, 자체적으로 슬라이드에 보이는 텍스트나 도형을 추가하지는 않습니다.
{{% /alert %}}

## **민감도 레이블 속성 이해**

각 [SensitivityLabel](https://reference.aspose.com/slides/ko/php-java/aspose.slides/sensitivitylabel/)에는 다음 메타데이터가 포함되어 있습니다:

| 메서드 | 목적 |
| --- | --- |
| [SensitivityLabel::getId](https://reference.aspose.com/slides/ko/php-java/aspose.slides/sensitivitylabel/#getId) 및 [SensitivityLabel::setId](https://reference.aspose.com/slides/ko/php-java/aspose.slides/sensitivitylabel/#setId) | Purview 정책에서 민감도 레이블 식별자를 가져오거나 설정합니다. |
| [SensitivityLabel::getSiteId](https://reference.aspose.com/slides/ko/php-java/aspose.slides/sensitivitylabel/#getSiteId) 및 [SensitivityLabel::setSiteId](https://reference.aspose.com/slides/ko/php-java/aspose.slides/sensitivitylabel/#setSiteId) | 레이블 정책과 연결된 사이트를 가져오거나 설정합니다. |
| [SensitivityLabel::isEnabled](https://reference.aspose.com/slides/ko/php-java/aspose.slides/sensitivitylabel/#isEnabled) 및 [SensitivityLabel::setEnabled](https://reference.aspose.com/slides/ko/php-java/aspose.slides/sensitivitylabel/#setEnabled) | 레이블이 활성화되어 있는지 여부를 가져오거나 설정합니다. |
| [SensitivityLabel::isRemoved](https://reference.aspose.com/slides/ko/php-java/aspose.slides/sensitivitylabel/#isRemoved) 및 [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/ko/php-java/aspose.slides/sensitivitylabel/#setRemoved) | 레이블이 제거되었는지 여부를 가져오거나 설정합니다. 제거 상태를 메타데이터에 보존해야 할 경우 값을 `true` 로 설정하십시오. |
| [SensitivityLabel::getAssignmentMethodType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) 및 [SensitivityLabel::setAssignmentMethodType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | 레이블이 자동으로 적용되었는지 사용자 결정에 의해 적용되었는지 여부를 가져오거나 설정합니다. |
| [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/ko/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | 레이블에 연결된 콘텐츠 마킹 유형을 가져옵니다. |

[SensitivityLabelAssignmentType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/sensitivitylabelassignmenttype/) 클래스는 레이블이 어떻게 할당되었는지를 정의합니다:

- [SensitivityLabelAssignmentType::Standard](https://reference.aspose.com/slides/ko/php-java/aspose.slides/sensitivitylabelassignmenttype/) 은 기본 또는 자동 적용된 레이블을 나타냅니다.
- [SensitivityLabelAssignmentType::Privileged](https://reference.aspose.com/slides/ko/php-java/aspose.slides/sensitivitylabelassignmenttype/) 은 사용자가 직접 선택한 레이블을 나타내며, 수동 적용, 권장, 필수 레이블을 포함합니다.

[SensitivityLabelContentType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/sensitivitylabelcontenttype/) 클래스는 레이블에 연결된 마킹을 정의합니다:

| 값 | 의미 |
| --- | --- |
| [SensitivityLabelContentType::None](https://reference.aspose.com/slides/ko/php-java/aspose.slides/sensitivitylabelcontenttype/) | 레이블이 기본 또는 자동으로 적용되었습니다. |
| [SensitivityLabelContentType::Header](https://reference.aspose.com/slides/ko/php-java/aspose.slides/sensitivitylabelcontenttype/) | 레이블에 헤더 콘텐츠 마킹이 연결되어 있습니다. |
| [SensitivityLabelContentType::Footer](https://reference.aspose.com/slides/ko/php-java/aspose.slides/sensitivitylabelcontenttype/) | 레이블에 푸터 콘텐츠 마킹이 연결되어 있습니다. |
| [SensitivityLabelContentType::Watermark](https://reference.aspose.com/slides/ko/php-java/aspose.slides/sensitivitylabelcontenttype/) | 레이블에 워터마크 콘텐츠 마킹이 연결되어 있습니다. |
| [SensitivityLabelContentType::Encryption](https://reference.aspose.com/slides/ko/php-java/aspose.slides/sensitivitylabelcontenttype/) | 레이블에 암호화 보호가 연결되어 있습니다. |

하나의 레이블에 여러 마킹 유형을 연결할 수 있습니다.

## **기존 민감도 레이블 나열**

[Presentation::getSensitivityLabels](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#getSensitivityLabels) 에서 최신 레이블 컬렉션을 읽어 열거합니다. 아래 예제는 각 레이블에 저장된 모든 속성과 콘텐츠 마킹을 나열합니다:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();
    $sensitivityLabelCount = java_values($sensitivityLabels->getCount());

    for ($labelIndex = 0; $labelIndex < $sensitivityLabelCount; $labelIndex++) {
        $sensitivityLabel = $sensitivityLabels->get_Item($labelIndex);

        echo "Label ID: " . java_values($sensitivityLabel->getId()) . PHP_EOL;
        echo "Site ID: " . java_values($sensitivityLabel->getSiteId()->toString()) . PHP_EOL;
        echo "Enabled: " . (java_values($sensitivityLabel->isEnabled()) ? "true" : "false") . PHP_EOL;
        echo "Removed: " . (java_values($sensitivityLabel->isRemoved()) ? "true" : "false") . PHP_EOL;
        echo "Assignment method: " . java_values($sensitivityLabel->getAssignmentMethodType()) . PHP_EOL;

        $contentMarkIterator = $sensitivityLabel->getContentMarkTypes()->iterator();
        while (java_values($contentMarkIterator->hasNext())) {
            $contentMarkType = java_values($contentMarkIterator->next());
            echo "Content marking: " . $contentMarkType . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **콘텐츠 마킹이 있는 민감도 레이블 추가**

레이블 식별자, 사이트 식별자, 활성 상태 및 할당 방법과 함께 [SensitivityLabelCollection::add](https://reference.aspose.com/slides/ko/php-java/aspose.slides/sensitivitylabelcollection/#add) 를 사용하십시오. 메서드가 새 [SensitivityLabel](https://reference.aspose.com/slides/ko/php-java/aspose.slides/sensitivitylabel/) 을 반환하면, [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/ko/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) 가 반환하는 목록을 통해 필요한 마킹 값을 추가합니다.

아래 예제는 푸터와 워터마크 마킹이 연결된 수동 선택 레이블을 추가하고 결과를 PPTX 로 저장합니다:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();

    $labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    $UUID = new JavaClass("java.util.UUID");
    $siteIdentifier = $UUID->fromString("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");
    $isEnabled = true;
    $assignmentMethod = SensitivityLabelAssignmentType::Privileged;

    $sensitivityLabel = $sensitivityLabels->add(
        $labelIdentifier,
        $siteIdentifier,
        $isEnabled,
        $assignmentMethod
    );

    $contentMarkTypes = $sensitivityLabel->getContentMarkTypes();
    $contentMarkTypes->addItem(SensitivityLabelContentType::Footer);
    $contentMarkTypes->addItem(SensitivityLabelContentType::Watermark);

    $presentation->save("presentation_with_label.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **민감도 레이블 업데이트**

[SensitivityLabel](https://reference.aspose.com/slides/ko/php-java/aspose.slides/sensitivitylabel/) 값은 읽기/쓰기 가능하지만, [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/ko/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) 가 반환하는 목록은 해당 리스트 연산을 통해 수정됩니다. 필요한 레이블을 찾은 후 식별자, 사이트 식별자, 활성 상태, 할당 방법, 제거 상태 및 콘텐츠 마킹 유형을 업데이트할 수 있습니다. 프레젠테이션을 저장하여 변경 사항을 영구히 적용하십시오.

아래 예제는 첫 번째 레이블의 활성 상태와 할당 방법을 업데이트합니다:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();
    $sensitivityLabelCount = java_values($sensitivityLabels->getCount());

    if ($sensitivityLabelCount > 0) {
        $sensitivityLabel = $sensitivityLabels->get_Item(0);
        $sensitivityLabel->setEnabled(true);
        $sensitivityLabel->setAssignmentMethodType(SensitivityLabelAssignmentType::Privileged);
    }

    $presentation->save("presentation_with_updated_label.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **민감도 레이블을 제거된 것으로 표시**

레이블이 제거되었음을 보존하려면 해당 레이블을 찾아 [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/ko/php-java/aspose.slides/sensitivitylabel/#setRemoved) 에 `true` 를 전달하십시오. 이렇게 하면 레이블 항목은 유지되면서 제거된 상태가 기록됩니다. 최신 컬렉션에서 항목을 완전히 삭제해야 할 경우 [SensitivityLabelCollection::removeAt](https://reference.aspose.com/slides/ko/php-java/aspose.slides/sensitivitylabelcollection/#removeAt) 를 사용하고, 모든 항목을 삭제하려면 [SensitivityLabelCollection::clear](https://reference.aspose.com/slides/ko/php-java/aspose.slides/sensitivitylabelcollection/#clear) 를 사용하십시오.

아래 예제는 특정 레이블을 제거된 것으로 표시하고 업데이트된 프레젠테이션을 저장합니다:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();
    $targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    $sensitivityLabelCount = java_values($sensitivityLabels->getCount());

    for ($labelIndex = 0; $labelIndex < $sensitivityLabelCount; $labelIndex++) {
        $sensitivityLabel = $sensitivityLabels->get_Item($labelIndex);
        $labelIdentifier = java_values($sensitivityLabel->getId());
        $isTargetLabel = strcasecmp($labelIdentifier, $targetLabelIdentifier) === 0;

        if ($isTargetLabel) {
            $sensitivityLabel->setRemoved(true);
            break;
        }
    }

    $presentation->save("presentation_with_removed_label.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **레거시 MIP 민감도 레이블 읽기 및 마이그레이션**

이전 MIP 기반 워크플로는 최신 레이블 컬렉션 대신 사용자 지정 문서 속성에 민감도 레이블 메타데이터를 저장할 수 있습니다. [DocumentProperties::getSensitivityLabels](https://reference.aspose.com/slides/ko/php-java/aspose.slides/documentproperties/#getSensitivityLabels) 로 해당 메타데이터를 읽어옵니다. 이 메서드는 레거시 사용자 지정 속성을 파싱하고 [SensitivityLabel](https://reference.aspose.com/slides/ko/php-java/aspose.slides/sensitivitylabel/) 객체의 Java 배열을 반환합니다.

메타데이터를 마이그레이션하려면 반환된 각 레이블을 [SensitivityLabelCollection::add](https://reference.aspose.com/slides/ko/php-java/aspose.slides/sensitivitylabelcollection/#add) 를 통해 최신 [SensitivityLabelCollection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/sensitivitylabelcollection/) 에 추가합니다. 중복 레이블 식별자를 추가하면 예외가 발생하므로, 예제에서는 복사하기 전에 대상 컬렉션에 존재하는지 확인합니다. 또한 각 레거시 레이블이 현재 Purview 정책에 여전히 존재하는지 검증하는 로직을 추가할 수 있습니다.

```php
$presentation = new Presentation("presentation_with_legacy_labels.pptx");
try {
    $legacySensitivityLabels = $presentation->getDocumentProperties()->getSensitivityLabels();
    $modernSensitivityLabels = $presentation->getSensitivityLabels();

    $Array = new JavaClass("java.lang.reflect.Array");
    $legacyLabelCount = java_values($Array->getLength($legacySensitivityLabels));

    for ($legacyLabelIndex = 0; $legacyLabelIndex < $legacyLabelCount; $legacyLabelIndex++) {
        $legacySensitivityLabel = $legacySensitivityLabels[$legacyLabelIndex];
        $legacyLabelIdentifier = java_values($legacySensitivityLabel->getId());
        $labelAlreadyExists = false;
        $modernLabelCount = java_values($modernSensitivityLabels->getCount());

        for ($modernLabelIndex = 0; $modernLabelIndex < $modernLabelCount; $modernLabelIndex++) {
            $modernSensitivityLabel = $modernSensitivityLabels->get_Item($modernLabelIndex);
            $modernLabelIdentifier = java_values($modernSensitivityLabel->getId());
            $labelAlreadyExists = strcasecmp(
                $modernLabelIdentifier,
                $legacyLabelIdentifier
            ) === 0;

            if ($labelAlreadyExists) {
                break;
            }
        }

        if (!$labelAlreadyExists) {
            $modernSensitivityLabels->add($legacySensitivityLabel);
        }
    }

    $presentation->save("presentation_with_modern_labels.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

마이그레이션은 파싱된 레이블 객체를 최신 컬렉션에 복사합니다. 모든 사용자 지정 문서 속성을 비울 필요가 없으므로 관련 없는 문서 메타데이터는 그대로 유지됩니다. 최신 레이블 메타데이터를 PPTX 파일에 기록하려면 [Presentation::save](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#save) 와 함께 [SaveFormat::Pptx](https://reference.aspose.com/slides/ko/php-java/aspose.slides/saveformat/) 를 사용하십시오.

## **FAQ**

**콘텐츠 마킹 유형을 추가하면 슬라이드에 보이는 헤더, 푸터 또는 워터마크가 생성됩니까?**

아니요. [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/ko/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) 가 반환하는 목록에 추가된 값은 민감도 레이블에 연결된 마킹을 설명할 뿐, 프레젠테이션에 보이는 텍스트나 도형을 만들지는 않습니다. 워크플로에서 해당 마킹을 시각적으로 표시해야 한다면 별도로 슬라이드 콘텐츠를 추가하십시오.

**레벨을 제거된 것으로 표시하는 것과 컬렉션에서 삭제하는 것의 차이는 무엇입니까?**

[SensitivityLabel::setRemoved](https://reference.aspose.com/slides/ko/php-java/aspose.slides/sensitivitylabel/#setRemoved) 에 `true` 를 전달하면 레이블 항목은 유지되고 제거된 상태가 기록됩니다. 반면 [SensitivityLabelCollection::removeAt](https://reference.aspose.com/slides/ko/php-java/aspose.slides/sensitivitylabelcollection/#removeAt) 를 호출하면 최신 컬렉션에서 해당 항목이 완전히 삭제됩니다. 조직의 메타데이터 보존 요구 사항에 맞는 작업을 선택하십시오.

**프레젠테이션에 레거시 MIP 메타데이터와 최신 민감도 레이블을 동시에 포함할 수 있나요?**

예 가능합니다. 레거시 레이블은 사용자 지정 문서 속성에 남아 있을 수 있으며, 최신 레이블은 [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#getSensitivityLabels) 를 통해 접근할 수 있습니다. 레거시 메타데이터를 읽고 아직 최신 컬렉션에 존재하지 않는 유효한 레이블만 마이그레이션하려면 [DocumentProperties::getSensitivityLabels](https://reference.aspose.com/slides/ko/php-java/aspose.slides/documentproperties/#getSensitivityLabels) 를 사용하십시오.

**동일한 식별자를 가진 레이블을 여러 번 추가하면 어떻게 됩니까?**

[SensitivityLabelCollection::add](https://reference.aspose.com/slides/ko/php-java/aspose.slides/sensitivitylabelcollection/#add) 은 컬렉션에 동일한 식별자를 가진 레이블이 이미 존재할 경우 예외를 발생시킵니다. 레이블을 추가하거나 마이그레이션하기 전에 [SensitivityLabel::getId](https://reference.aspose.com/slides/ko/php-java/aspose.slides/sensitivitylabel/#getId) 로 기존 값을 확인하십시오.

**업데이트된 민감도 레이블을 보존하려면 어떤 출력 형식을 사용해야 합니까?**

위 예제와 같이 [SaveFormat::Pptx](https://reference.aspose.com/slides/ko/php-java/aspose.slides/saveformat/) 를 지정하고 [Presentation::save](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#save) 를 호출하여 프레젠테이션을 PPTX 형식으로 저장하십시오.