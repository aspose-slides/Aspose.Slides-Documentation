---
title: Java를 사용한 읽기 전용 모드에서 프레젠테이션 저장
linktitle: 읽기 전용 프레젠테이션
type: docs
weight: 30
url: /ko/java/read-only-presentation/
keywords:
- 읽기 전용
- 프레젠테이션 보호
- 편집 방지
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 읽기 전용 모드에서 PowerPoint 파일(PPT, PPTX)을 로드하고 저장하면 프레젠테이션을 변경하지 않고도 정확한 슬라이드 미리보기를 제공합니다."
---
## **Introduction**

PowerPoint 2019에서 Microsoft는 프레젠테이션을 보호하기 위한 옵션 중 하나인 **Always Open Read-Only** 설정을 도입했습니다. 다음과 같은 경우에 이 읽기 전용 설정을 사용하여 프레젠테이션을 보호하고 싶을 수 있습니다.

- 실수로 편집되는 것을 방지하고 프레젠테이션 내용의 안전을 유지하고 싶을 때.  
- 제공한 프레젠테이션이 최종 버전임을 사람들에게 알리고 싶을 때.  

프레젠테이션에 **Always Open Read-Only** 옵션을 선택하면 사용자가 프레젠테이션을 열 때 **Read-Only** 권고 메시지를 보게 되며, 다음과 같은 형태의 문구가 표시될 수 있습니다: *To prevent accidental changes, the author has set this file to open as read-only.*

Read-Only 권고는 사용자가 편집하기 전에 이를 해제해야 하므로 편집을 억제하는 간단하지만 효과적인 방법입니다. 프레젠테이션에 대한 변경을 원하지 않으며 이를 정중하게 알리고 싶다면 Read-Only 권고가 좋은 옵션이 될 수 있습니다.

> 프레젠테이션에 **Read-Only** 보호가 적용된 상태에서 이 기능을 지원하지 않는 이전 버전 Microsoft PowerPoint 응용 프로그램으로 열면 **Read-Only** 권고가 무시되고(프레젠테이션이 정상적으로 열림) 됩니다.

## **Apply Read-Only Mode**

Aspose.Slides for Java를 사용하면 프레젠테이션을 **Read-Only** 상태로 설정할 수 있습니다. 이렇게 하면 사용자가 프레젠테이션을 연 후 **Read-Only** 권고를 보게 됩니다. 다음 샘플 코드는 Aspose.Slides를 이용해 Java에서 프레젠테이션을 **Read-Only** 로 설정하는 방법을 보여줍니다.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getProtectionManager().setReadOnlyRecommended(true);
    pres.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 

**Note**: **Read-Only** 권고는 PowerPoint 프레젠테이션에 대한 편집을 억제하거나 실수로 변경되는 것을 방지하기 위한 용도입니다. 동작을 잘 아는 사람이 프레젠테이션을 편집하려고 하면 쉽게 Read-Only 설정을 해제할 수 있습니다. 실제로 무단 편집을 방지해야 한다면 [more stringent protections that involve encryptions and passwords](https://docs.aspose.com/slides/ko/java/password-protected-presentation/)을 사용하는 것이 좋습니다. 

{{% /alert %}} 

## **FAQ**

### How is 'Read-Only recommended' different from full password protection?

'Read-Only recommended'는 파일을 읽기 전용 모드로 열 것을 제안하는 정도이며 쉽게 우회할 수 있습니다. [Password protection](/slides/ko/java/password-protected-presentation/)는 실제로 열기 및 편집을 제한하며, 실제 보안 제어가 필요할 때 적합합니다.

### Can 'Read-Only recommended' be combined with watermarks to further discourage edits?

예. 권고는 [watermarks](/slides/ko/java/watermark/)와 결합해 시각적인 억제 효과를 줄 수 있으며, 두 메커니즘은 별개이면서 함께 잘 작동합니다.

### Can a macro or external tool still modify the file when the recommendation is enabled?

예. 권고는 프로그램적인 변경을 차단하지 않습니다. 자동화된 편집을 방지하려면 [passwords and encryption](/slides/ko/java/password-protected-presentation/)를 사용하십시오.

### How does 'Read-Only recommended' relate to the methods 'isEncrypted' and 'isWriteProtected'?

두 신호는 다릅니다. 'Read-Only recommended'는 부드럽고 선택적인 알림이며; [isWriteProtected](https://reference.aspose.com/slides/ko/java/com.aspose.slides/protectionmanager/#isWriteProtected--)와 [isEncrypted](https://reference.aspose.com/slides/ko/java/com.aspose.slides/protectionmanager/#isEncrypted--)는 비밀번호나 암호화에 따라 실제 쓰기 또는 읽기 제한을 나타냅니다.