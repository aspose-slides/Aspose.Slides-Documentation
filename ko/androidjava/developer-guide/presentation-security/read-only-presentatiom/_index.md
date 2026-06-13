---
title: Android에서 읽기 전용 모드로 프레젠테이션 저장
linktitle: 읽기 전용 프레젠테이션
type: docs
weight: 30
url: /ko/androidjava/read-only-presentation/
keywords:
- 읽기 전용
- 프레젠테이션 보호
- 편집 방지
- PowerPoint
- OpenDocument
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java를 사용하여 PowerPoint 파일(PPT, PPTX)을 읽기 전용 모드로 저장하고 프레젠테이션을 변경하지 않고 정확한 슬라이드 미리보기를 제공합니다."
---
## **소개**

PowerPoint 2019에서 Microsoft는 프레젠테이션을 보호하기 위해 사용자가 사용할 수 있는 옵션 중 하나로 **Always Open Read-Only** 설정을 도입했습니다. 다음과 같은 경우에 이 읽기 전용 설정을 사용하여 프레젠테이션을 보호하고 싶을 수 있습니다.

- 실수로 편집되는 것을 방지하고 프레젠테이션 내용을 안전하게 유지하고 싶을 때. 
- 제공한 프레젠테이션이 최종 버전임을 알리고 싶을 때. 

프레젠테이션에 대해 **Always Open Read-Only** 옵션을 선택하면 사용자가 프레젠테이션을 열 때 **Read-Only** 권장 메시지가 표시되며 다음과 같은 형태의 메시지를 볼 수 있습니다: *To prevent accidental changes, the author has set this file to open as read-only.*

Read-Only 권장은 단순하지만 효과적인 억제 수단으로, 사용자가 편집하려면 이를 제거해야 하므로 편집을 억제합니다. 프레젠테이션에 대한 변경을 원하지 않고 이를 정중하게 알리고 싶다면 Read-Only 권장이 좋은 옵션이 될 수 있습니다. 

> **Read-Only** 보호가 적용된 프레젠테이션을 최근에 도입된 기능을 지원하지 않는 이전 버전 Microsoft PowerPoint 애플리케이션에서 열면 **Read-Only** 권장이 무시됩니다(프레젠테이션이 일반적으로 열립니다).

## **읽기 전용 모드 적용**

Aspose.Slides for Android via Java를 사용하면 프레젠테이션을 **Read-Only** 로 설정할 수 있으며, 이는 사용자가 프레젠테이션을 연 후 **Read-Only** 권장을 보게 됨을 의미합니다. 다음 샘플 코드는 Aspose.Slides를 사용해 Java에서 프레젠테이션을 **Read-Only** 로 설정하는 방법을 보여줍니다:

```java
Presentation pres = new Presentation();
try {
    pres.getProtectionManager().setReadOnlyRecommended(true);
    pres.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 

**참고**: **Read-Only** 권장은 PowerPoint 프레젠테이션의 편집을 억제하거나 실수로 변경되는 것을 방지하기 위한 것입니다. 작업을 잘 아는 의욕적인 사용자가 프레젠테이션을 편집하려고 하면 **Read-Only** 설정을 쉽게 제거할 수 있습니다. 무단 편집을 확실히 방지해야 한다면 [암호화 및 비밀번호를 포함한 보다 엄격한 보호](https://docs.aspose.com/slides/ko/androidjava/password-protected-presentation/)를 사용하는 것이 좋습니다.

{{% /alert %}} 

## **FAQ**

**'Read-Only recommended'는 전체 비밀번호 보호와 어떻게 다릅니까?**

'Read-Only recommended'는 파일을 읽기 전용 모드로 열라는 제안만 표시하며 쉽게 우회할 수 있습니다. [비밀번호 보호](/slides/ko/androidjava/password-protected-presentation/)은 실제로 열기나 편집을 제한하며 실제 보안 제어가 필요할 때 적합합니다.

**'Read-Only recommended'를 워터마크와 결합하여 편집을 더 억제할 수 있습니까?**

예. 권장은 [워터마크](/slides/ko/androidjava/watermark/)와 결합하여 시각적 억제 수단으로 사용할 수 있으며, 두 메커니즘은 별개이면서 함께 잘 작동합니다.

**권장이 활성화된 경우 매크로나 외부 도구가 여전히 파일을 수정할 수 있습니까?**

예. 권장은 프로그래밍 방식의 변경을 차단하지 않습니다. 자동화된 편집을 방지하려면 [비밀번호 및 암호화](/slides/ko/androidjava/password-protected-presentation/)을 사용하십시오.

**'Read-Only recommended'는 'isEncrypted' 및 'isWriteProtected' 메서드와 어떻게 관련이 있습니까?**

이들은 서로 다른 신호입니다. 'Read-Only recommended'는 부드럽고 선택적인 프롬프트이며, [isWriteProtected](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/protectionmanager/#isWriteProtected--) 및 [isEncrypted](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/protectionmanager/#isEncrypted--)는 비밀번호 또는 암호화에 따라 실제 쓰기 또는 읽기 제한을 나타냅니다.