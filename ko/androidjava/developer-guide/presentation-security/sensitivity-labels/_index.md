---
title: Android에서 PowerPoint 프레젠테이션 민감도 레이블 관리
linktitle: 민감도 레이블
type: docs
weight: 50
url: /ko/androidjava/sensitivity-labels/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java를 사용하여 PowerPoint PPTX 프레젠테이션에서 Microsoft Purview 민감도 레이블을 읽고, 추가하고, 업데이트하고, 제거하며, 마이그레이션합니다."
---
## **개요**

Microsoft Purview 민감도 레이블은 조직이 문서를 분류하고 관리하도록 돕습니다. 자동 프레젠테이션 처리 중에 애플리케이션은 기존 레이블을 보존하거나, 정책에서 선택된 레이블을 적용하거나, 상태를 업데이트하거나, 이전 Microsoft Information Protection (MIP) 워크플로우에서 작성된 레이블 메타데이터를 마이그레이션해야 할 수 있습니다.

Aspose.Slides for Android via Java는 최신 민감도 레이블 메타데이터를 [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels-- )을 통해 노출합니다. 이 메서드는 프레젠테이션을 PPTX로 저장하기 전에 검토 및 수정할 수 있는 [ISensitivityLabelCollection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/isensitivitylabelcollection/ )을 반환합니다.

{{% alert color="primary" title="Note" %}}
민감도 레이블 식별자와 정책 정보는 Microsoft Purview 구성에 의해 정의됩니다. 메타데이터를 추가하거나 마이그레이션하기 전에 환경에서 레이블 가용성 및 정책 요구 사항을 확인하십시오. [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes-- ) 값은 레이블과 연결된 콘텐츠 마킹을 설명하지만, 자체적으로 슬라이드에 보이는 텍스트나 도형을 추가하지는 않습니다.
{{% /alert %}}

## **민감도 레이블 속성 이해**

각 [ISensitivityLabel](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/isensitivitylabel/ )에는 다음 메타데이터가 포함됩니다:

| 메서드 | 목적 |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/isensitivitylabel/#getId--) 및 [ISensitivityLabel.setId](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | Purview 정책에서 민감도 레이블 식별자를 가져오거나 설정합니다. |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/isensitivitylabel/#getSiteId--) 및 [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | 레이블 정책과 연결된 사이트를 가져오거나 설정합니다. |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/isensitivitylabel/#isEnabled--) 및 [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | 레이블이 활성화되어 있는지 여부를 가져오거나 설정합니다. |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/isensitivitylabel/#isRemoved--) 및 [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | 레이블이 제거되었는지 여부를 가져오거나 설정합니다. 메타데이터에 제거 상태를 유지해야 할 경우 값을 `true` 로 설정하십시오. |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--) 및 [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | 레이블이 자동으로 적용되었는지 또는 사용자 결정에 의해 적용되었는지 여부를 가져오거나 설정합니다. |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | 레이블과 연결된 콘텐츠 마킹 유형을 가져옵니다. |

[SensitivityLabelAssignmentType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/ ) 클래스는 레이블이 어떻게 할당되었는지를 정의합니다:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/ ) 은 기본 또는 자동 적용된 레이블을 나타냅니다.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/ ) 은 사용자가 결정하여 적용한 레이블을 나타내며, 수동 적용, 권장 및 필수 레이블을 포함합니다.

[SensitivityLabelContentType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/sensitivitylabelcontenttype/ ) 클래스는 레이블과 연결된 마킹을 정의합니다:

| Value | Meaning |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/sensitivitylabelcontenttype/ ) | 레이블이 기본값이나 자동으로 적용되었습니다. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/sensitivitylabelcontenttype/ ) | 헤더 콘텐츠 마킹이 레이블과 연결됩니다. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/sensitivitylabelcontenttype/ ) | 푸터 콘텐츠 마킹이 레이블과 연결됩니다. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/sensitivitylabelcontenttype/ ) | 워터마크 콘텐츠 마킹이 레이블과 연결됩니다. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/sensitivitylabelcontenttype/ ) | 암호화 보호가 레이블과 연결됩니다. |

하나의 레이블에 여러 마킹 유형을 연결할 수 있습니다.

## **기존 민감도 레이블 나열**

[IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels-- )에서 최신 레이블 컬렉션을 읽고 열거하십시오. 다음 예제는 각 레이블에 저장된 모든 속성 및 콘텐츠 마킹을 나열합니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();

    for (ISensitivityLabel sensitivityLabel : sensitivityLabels) {
        System.out.println("Label ID: " + sensitivityLabel.getId());
        System.out.println("Site ID: " + sensitivityLabel.getSiteId());
        System.out.println("Enabled: " + sensitivityLabel.isEnabled());
        System.out.println("Removed: " + sensitivityLabel.isRemoved());
        System.out.println("Assignment method: " + sensitivityLabel.getAssignmentMethodType());

        for (Integer contentMarkType : sensitivityLabel.getContentMarkTypes()) {
            System.out.println("Content marking: " + contentMarkType);
        }
    }
} finally {
    presentation.dispose();
}
```

## **콘텐츠 마킹이 있는 민감도 레이블 추가**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int- )을 사용하여 레이블 식별자, 사이트 식별자, 활성 상태 및 할당 방식을 지정합니다. 메서드가 새로운 [ISensitivityLabel](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/isensitivitylabel/ )을 반환한 후, [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes-- )에서 반환된 목록을 통해 필요한 마킹 값을 추가하십시오.

다음 예제는 푸터 및 워터마크 마킹과 연결된 수동 선택 레이블을 추가하고, 결과를 PPTX로 저장합니다:

```java
import com.aspose.slides.*;
import java.util.UUID;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();

    String labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    UUID siteIdentifier = UUID.fromString("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");
    boolean isEnabled = true;
    int assignmentMethod = SensitivityLabelAssignmentType.Privileged;

    ISensitivityLabel sensitivityLabel = sensitivityLabels.add(
            labelIdentifier,
            siteIdentifier,
            isEnabled,
            assignmentMethod);

    sensitivityLabel.getContentMarkTypes().addItem(SensitivityLabelContentType.Footer);
    sensitivityLabel.getContentMarkTypes().addItem(SensitivityLabelContentType.Watermark);

    presentation.save("presentation_with_label.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **민감도 레이블 업데이트**

[ISensitivityLabel](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/isensitivitylabel/ ) 값은 읽기/쓰기가 가능하지만, [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes-- )에서 반환된 목록은 해당 목록 연산을 통해 수정됩니다. 필요한 레이블을 찾은 후, 식별자, 사이트 식별자, 활성 상태, 할당 방식, 제거 상태 및 콘텐츠 마킹 유형을 업데이트할 수 있습니다. 프레젠테이션을 저장하여 변경 사항을 영구히 저장하십시오.

다음 예제는 첫 번째 레이블의 활성 상태와 할당 방식을 업데이트합니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();

    if (sensitivityLabels.getCount() > 0) {
        ISensitivityLabel sensitivityLabel = sensitivityLabels.get_Item(0);
        sensitivityLabel.setEnabled(true);
        sensitivityLabel.setAssignmentMethodType(SensitivityLabelAssignmentType.Privileged);
    }

    presentation.save("presentation_with_updated_label.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **민감도 레이블을 제거됨으로 표시**

레이블이 제거된 사실을 보존하려면 해당 레이블을 찾아 [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean- )을 `true` 로 호출하십시오. 이렇게 하면 레이블 항목이 유지되면서 제거 상태가 기록됩니다. 대신 최신 컬렉션에서 항목을 삭제해야 하는 경우 [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/isensitivitylabelcollection/#removeAt-int- )을 사용하고, 모든 항목을 삭제하려면 [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/isensitivitylabelcollection/#clear-- )을 사용하십시오.

다음 예제는 특정 레이블을 제거됨으로 표시하고 업데이트된 프레젠테이션을 저장합니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();
    String targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";

    for (ISensitivityLabel sensitivityLabel : sensitivityLabels) {
        boolean isTargetLabel = sensitivityLabel.getId().equalsIgnoreCase(targetLabelIdentifier);

        if (isTargetLabel) {
            sensitivityLabel.setRemoved(true);
            break;
        }
    }

    presentation.save("presentation_with_removed_label.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **레거시 MIP 민감도 레이블 읽기 및 마이그레이션**

이전 MIP 기반 워크플로우는 최신 레이블 컬렉션 대신 사용자 지정 문서 속성에 민감도 레이블 메타데이터를 저장할 수 있습니다. 해당 메타데이터를 [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/idocumentproperties/#getSensitivityLabels-- )으로 읽으십시오. 이 메서드는 레거시 사용자 지정 속성을 파싱하여 [ISensitivityLabel](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/isensitivitylabel/ ) 객체 배열을 반환합니다.

메타데이터를 마이그레이션하려면 반환된 각 레이블을 [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel- )을 통해 최신 [ISensitivityLabelCollection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/isensitivitylabelcollection/ )에 추가하십시오. 중복 레이블 식별자를 추가하면 예외가 발생하므로, 예제에서는 각 레이블을 복사하기 전에 대상 컬렉션을 확인합니다. 현재 Purview 정책에 각 레거시 레이블이 아직 존재하는지 확인하는 추가 검증을 추가할 수 있습니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation_with_legacy_labels.pptx");
try {
    ISensitivityLabel[] legacySensitivityLabels = presentation.getDocumentProperties().getSensitivityLabels();
    ISensitivityLabelCollection modernSensitivityLabels = presentation.getSensitivityLabels();

    for (ISensitivityLabel legacySensitivityLabel : legacySensitivityLabels) {
        boolean labelAlreadyExists = false;

        for (ISensitivityLabel modernSensitivityLabel : modernSensitivityLabels) {
            labelAlreadyExists = modernSensitivityLabel.getId().equalsIgnoreCase(
                    legacySensitivityLabel.getId());

            if (labelAlreadyExists) {
                break;
            }
        }

        if (!labelAlreadyExists) {
            modernSensitivityLabels.add(legacySensitivityLabel);
        }
    }

    presentation.save("presentation_with_modern_labels.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

마이그레이션은 파싱된 레이블 객체를 최신 컬렉션에 복사합니다. 모든 사용자 지정 문서 속성을 지울 필요가 없으므로 관련 없는 문서 메타데이터는 그대로 유지됩니다. 최신 레이블 메타데이터를 PPTX 파일에 기록하려면 [IPresentation.save](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int- )에 [SaveFormat.Pptx](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/saveformat/ )를 사용하십시오.

## **FAQ**

**콘텐츠 마킹 유형을 추가하면 슬라이드에 보이는 헤더, 푸터 또는 워터마크가 생성됩니까?**

아니요. [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes-- )에서 반환된 목록에 추가된 값은 민감도 레이블과 연결된 마킹을 설명할 뿐이며, 프레젠테이션에 보이는 텍스트나 도형을 생성하지 않습니다. 워크플로우에서 해당 마킹을 렌더링해야 한다면 별도로 해당 슬라이드 콘텐츠를 추가하십시오.

**레이블을 제거됨으로 표시하는 것과 컬렉션에서 삭제하는 것의 차이점은 무엇입니까?**

[ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean- )을 `true` 로 호출하면 레이블 항목을 유지하면서 제거 상태를 기록합니다. [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/isensitivitylabelcollection/#removeAt-int- )을 호출하면 최신 컬렉션에서 해당 항목이 삭제됩니다. 조직의 메타데이터 보존 요구 사항에 맞는 작업을 선택하십시오.

**프레젠테이션에 레거시 MIP 메타데이터와 최신 민감도 레이블을 모두 포함할 수 있나요?**

예. 레거시 레이블은 사용자 지정 문서 속성에 남아 있을 수 있으며, 최신 레이블은 [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels-- )을 통해 사용할 수 있습니다. 레거시 메타데이터를 읽고 최신 컬렉션에 아직 존재하지 않는 유효한 레이블만 마이그레이션하려면 [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/idocumentproperties/#getSensitivityLabels-- )을 사용하십시오.

**동일한 식별자를 가진 레이블을 여러 번 추가하면 어떻게 됩니까?**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int- )은 컬렉션에 동일 식별자를 가진 레이블이 이미 존재하면 예외를 발생시킵니다. 레이블을 추가하거나 마이그레이션하기 전에 [ISensitivityLabel.getId](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/isensitivitylabel/#getId-- )으로 반환된 기존 값을 확인하십시오.

**업데이트된 민감도 레이블을 유지하려면 어떤 출력 형식을 사용해야 합니까?**

위의 예제와 같이 [IPresentation.save](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int- )에 [SaveFormat.Pptx](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/saveformat/ )를 지정하여 프레젠테이션을 PPTX 형식으로 저장하십시오.