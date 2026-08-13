---
title: Java에서 PowerPoint 프레젠테이션의 민감도 라벨 관리
linktitle: 민감도 라벨
type: docs
weight: 50
url: /ko/java/sensitivity-labels/
keywords:
- 민감도 라벨
- Microsoft Purview
- Microsoft Information Protection
- MIP 메타데이터
- 콘텐츠 마킹
- 정보 보호
- 문서 거버넌스
- PowerPoint
- PPTX
- 프레젠테이션 보안
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 PowerPoint PPTX 프레젠테이션에서 Microsoft Purview 민감도 라벨을 읽고, 추가하고, 업데이트하고, 제거하며, 마이그레이션합니다."
---
## **개요**

Microsoft Purview 민감도 라벨은 조직이 문서를 분류하고 관리하도록 도와줍니다. 자동 프레젠테이션 처리 중에 애플리케이션은 기존 라벨을 보존하거나 정책에서 선택한 라벨을 적용하고, 상태를 업데이트하거나 이전 Microsoft Information Protection (MIP) 워크플로에서 작성된 라벨 메타데이터를 마이그레이션해야 할 수 있습니다.

Aspose.Slides는 [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipresentation/#getSensitivityLabels--)을 통해 최신 민감도 라벨 메타데이터를 노출합니다. 이 메서드는 프레젠테이션을 PPTX로 저장하기 전에 검사 및 수정할 수 있는 [ISensitivityLabelCollection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isensitivitylabelcollection/)을 반환합니다.

{{% alert color="info" title="참고" %}}

민감도 라벨 식별자와 정책 정보는 Microsoft Purview 구성에 의해 정의됩니다. 메타데이터를 추가하거나 마이그레이션하기 전에 환경에서 라벨 가용성 및 정책 요구 사항을 확인하십시오. [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) 값은 라벨과 연결된 콘텐츠 마킹을 설명하지만, 슬라이드에 눈에 보이는 텍스트나 도형을 자동으로 추가하지는 않습니다.

{{% /alert %}}

## **민감도 라벨 속성 이해**

각 [ISensitivityLabel](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isensitivitylabel/)에는 다음 메타데이터가 포함됩니다:

| 메서드 | 목적 |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isensitivitylabel/#getId--) 및 [ISensitivityLabel.setId](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | Purview 정책에서 민감도 라벨 식별자를 가져오거나 설정합니다. |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isensitivitylabel/#getSiteId--) 및 [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | 라벨 정책과 연결된 사이트를 가져오거나 설정합니다. |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isensitivitylabel/#isEnabled--) 및 [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | 라벨이 활성화되어 있는지 여부를 가져오거나 설정합니다. |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isensitivitylabel/#isRemoved--) 및 [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | 라벨이 제거되었는지 여부를 가져오거나 설정합니다. 메타데이터에 제거 상태를 유지해야 할 경우 값을 `true`로 설정하십시오. |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--) 및 [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | 라벨이 자동으로 적용되었는지 사용자 결정에 의해 적용되었는지 여부를 가져오거나 설정합니다. |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | 라벨과 연결된 콘텐츠 마킹 유형을 가져옵니다. |

[SensitivityLabelAssignmentType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/sensitivitylabelassignmenttype/) 클래스는 라벨 할당 방식을 정의합니다:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/ko/java/com.aspose.slides/sensitivitylabelassignmenttype/) 은 기본 또는 자동 적용 라벨을 나타냅니다.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/ko/java/com.aspose.slides/sensitivitylabelassignmenttype/) 은 사용자가 선택한 라벨을 나타내며, 수동 적용, 권장 및 필수 라벨을 포함합니다.

[SensitivityLabelContentType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/sensitivitylabelcontenttype/) 클래스는 라벨에 연결된 마킹을 정의합니다:

| 값 | 의미 |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/ko/java/com.aspose.slides/sensitivitylabelcontenttype/) | 라벨이 기본값이나 자동으로 적용되었습니다. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/ko/java/com.aspose.slides/sensitivitylabelcontenttype/) | 헤더 콘텐츠 마킹이 라벨에 연결되었습니다. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/ko/java/com.aspose.slides/sensitivitylabelcontenttype/) | 푸터 콘텐츠 마킹이 라벨에 연결되었습니다. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/ko/java/com.aspose.slides/sensitivitylabelcontenttype/) | 워터마크 콘텐츠 마킹이 라벨에 연결되었습니다. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/ko/java/com.aspose.slides/sensitivitylabelcontenttype/) | 암호화 보호가 라벨에 연결되었습니다. |

여러 마킹 유형을 하나의 라벨에 연관시킬 수 있습니다.

## **기존 민감도 라벨 나열**

[IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipresentation/#getSensitivityLabels--)에서 최신 라벨 컬렉션을 읽고 열거합니다. 다음 예제는 각 라벨에 저장된 모든 속성과 콘텐츠 마킹을 나열합니다:

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

## **콘텐츠 마킹이 포함된 민감도 라벨 추가**

라벨 식별자, 사이트 식별자, 활성화 상태, 할당 방식을 지정하여 [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-)를 사용합니다. 메서드가 새 [ISensitivityLabel](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isensitivitylabel/)을 반환하면, [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--)가 반환하는 목록에 필요한 마킹 값을 추가합니다.

다음 예제는 푸터와 워터마크 마킹이 연결된 수동 선택 라벨을 추가하고 결과를 PPTX로 저장합니다:

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

## **민감도 라벨 업데이트**

[ISensitivityLabel](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isensitivitylabel/) 값은 읽기/쓰기 가능하지만, [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--)가 반환하는 목록은 해당 리스트 연산을 통해 수정합니다. 필요한 라벨을 찾은 후 식별자, 사이트 식별자, 활성화 상태, 할당 방식, 제거 상태 및 콘텐츠 마킹 유형을 업데이트할 수 있습니다. 프레젠테이션을 저장하여 변경 내용을 지속합니다.

다음 예제는 첫 번째 라벨의 활성화 상태와 할당 방식을 업데이트합니다:

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

## **라벨을 제거된 상태로 표시**

라벨이 제거된 사실을 보존하려면 라벨을 찾아 [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-)에 `true`를 전달합니다. 이렇게 하면 라벨 항목은 남아 있으면서 제거 상태가 기록됩니다. 최신 컬렉션에서 항목을 완전히 삭제하려면 [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-)를 사용하고, 모든 항목을 삭제하려면 [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isensitivitylabelcollection/#clear--)를 사용합니다.

다음 예제는 특정 라벨을 제거된 상태로 표시하고 업데이트된 프레젠테이션을 저장합니다:

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

## **레거시 MIP 민감도 라벨 읽기 및 마이그레이션**

구식 MIP 기반 워크플로는 최신 라벨 컬렉션 대신 사용자 지정 문서 속성에 민감도 라벨 메타데이터를 저장할 수 있습니다. 해당 메타데이터는 [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/ko/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--)로 읽습니다. 이 메서드는 레거시 사용자 지정 속성을 구문 분석하고 [ISensitivityLabel](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isensitivitylabel/) 객체 배열을 반환합니다.

메타데이터를 마이그레이션하려면 반환된 각 라벨을 [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-)를 통해 최신 [ISensitivityLabelCollection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isensitivitylabelcollection/)에 추가합니다. 중복 라벨 식별자를 추가하면 예외가 발생하므로, 예제에서는 복사하기 전에 대상 컬렉션을 확인합니다. 각 레거시 라벨이 현재 Purview 정책에 아직 존재하는지 확인하는 추가 검증을 구현할 수 있습니다.

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

마이그레이션은 구문 분석된 라벨 객체를 최신 컬렉션에 복사합니다. 모든 사용자 지정 문서 속성을 삭제할 필요가 없으므로 관련 없는 문서 메타데이터는 그대로 유지됩니다. [IPresentation.save](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-)를 [SaveFormat.Pptx](https://reference.aspose.com/slides/ko/java/com.aspose.slides/saveformat/)와 함께 사용하여 최신 라벨 메타데이터를 PPTX 파일에 기록합니다.

## **FAQ**

**콘텐츠 마킹 유형을 추가하면 슬라이드에 눈에 보이는 헤더, 푸터 또는 워터마크가 생성됩니까?**

아니요. [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--)가 반환하는 목록에 추가된 값은 민감도 라벨에 연결된 마킹을 설명할 뿐이며, 프레젠테이션에 눈에 보이는 텍스트나 도형을 만들지는 않습니다. 워크플로에서 해당 마킹을 표시해야 한다면 별도로 슬라이드 콘텐츠를 추가하십시오.

**라벨을 제거된 것으로 표시하는 것과 컬렉션에서 삭제하는 것의 차이는 무엇입니까?**

[ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-)에 `true`를 전달하면 라벨 항목은 유지되면서 제거 상태가 기록됩니다. 반면 [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-)를 호출하면 최신 컬렉션에서 항목 자체가 삭제됩니다. 조직의 메타데이터 보존 요구 사항에 맞는 작업을 선택하십시오.

**프레젠테이션에 레거시 MIP 메타데이터와 최신 민감도 라벨을 동시에 포함할 수 있습니까?**

예. 레거시 라벨은 사용자 지정 문서 속성에 남아 있을 수 있고, 최신 라벨은 [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipresentation/#getSensitivityLabels--)를 통해 접근할 수 있습니다. 레거시 메타데이터를 읽으려면 [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/ko/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--)를 사용하고, 최신 컬렉션에 아직 없는 유효한 라벨만 마이그레이션하십시오.

**동일한 식별자를 가진 라벨을 여러 번 추가하면 어떻게 됩니까?**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-)는 컬렉션에 동일한 식별자를 가진 라벨이 이미 존재할 경우 예외를 발생시킵니다. 라벨을 추가하거나 마이그레이션하기 전에 [ISensitivityLabel.getId](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isensitivitylabel/#getId--)가 반환하는 기존 값을 반드시 확인하십시오.

**업데이트된 민감도 라벨을 보존하려면 어떤 출력 형식을 사용해야 합니까?**

위 예제와 같이 [IPresentation.save](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-)에 [SaveFormat.Pptx](https://reference.aspose.com/slides/ko/java/com.aspose.slides/saveformat/)를 지정하여 프레젠테이션을 PPTX 형식으로 저장하십시오.