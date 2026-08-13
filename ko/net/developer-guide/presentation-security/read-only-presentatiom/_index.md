---
title: .NET에서 읽기 전용 모드로 프레젠테이션 저장
linktitle: 읽기 전용 프레젠테이션
type: docs
weight: 30
url: /ko/net/read-only-presentation/
keywords:
- 읽기 전용
- 프레젠테이션 보호
- 편집 방지
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET를 사용하여 PowerPoint 파일(PPT, PPTX)을 읽기 전용 모드로 로드하고 저장하면 프레젠테이션을 변경하지 않고 정확한 슬라이드 미리보기를 제공합니다."
---
## **소개**

PowerPoint 2019에서 Microsoft는 프레젠테이션을 보호하기 위해 사용자가 사용할 수 있는 옵션 중 하나로 **Always Open Read-Only** 설정을 도입했습니다. 다음과 같은 경우 프레젠테이션을 보호하기 위해 이 읽기 전용 설정을 사용하고 싶을 수 있습니다.

- 우발적인 편집을 방지하고 프레젠테이션 내용을 안전하게 보관하고 싶을 때. 
- 제공한 프레젠테이션이 최종 버전임을 사람들에게 알리고 싶을 때. 

프레젠테이션에 **Always Open Read-Only** 옵션을 선택하면 사용자가 프레젠테이션을 열었을 때 **Read-Only** 권고가 표시되고 다음과 같은 메시지를 볼 수 있습니다: *우발적인 변경을 방지하기 위해 작성자가 이 파일을 읽기 전용으로 열도록 설정했습니다.*

Read-Only 권고는 간단하지만 효과적인 억제 수단으로, 사용자가 프레젠테이션을 편집하려면 이를 제거하는 작업을 수행해야 하기 때문에 편집을 억제합니다. 사용자가 프레젠테이션을 변경하지 않도록 하고 이를 정중하게 알리고 싶다면 Read-Only 권고가 좋은 옵션이 될 수 있습니다. 

> **Read-Only** 보호가 적용된 프레젠테이션을 최근 도입된 기능을 지원하지 않는 오래된 Microsoft PowerPoint 응용 프로그램에서 열 경우, **Read-Only** 권고가 무시됩니다(프레젠테이션이 정상적으로 열립니다).

## **읽기 전용 모드 적용**

Aspose.Slides for .NET을 사용하면 프레젠테이션을 **Read-Only**로 설정할 수 있으며, 사용자는 (프레젠테이션을 연 후) **Read-Only** 권고를 보게 됩니다. 다음 샘플 코드는 Aspose.Slides를 이용해 C#에서 프레젠테이션을 **Read-Only**로 설정하는 방법을 보여줍니다:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    pres.ProtectionManager.ReadOnlyRecommended = true;
    pres.Save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert color="info" %}} 

**Note**: **Read-Only** 권고는 단순히 편집을 억제하거나 PowerPoint 프레젠테이션에 대한 우발적인 변경을 방지하기 위한 것입니다. 작업에 능숙한 사람이 프레젠테이션을 편집하려고 하면 Read-Only 설정을 쉽게 제거할 수 있습니다. 무단 편집을 확실히 방지해야 한다면 [암호화와 비밀번호를 포함한 보다 엄격한 보호](https://docs.aspose.com/slides/ko/net/password-protected-presentation/)를 사용하는 것이 좋습니다. 

{{% /alert %}} 

## **FAQ**

### 'Read-Only recommended'는 전체 비밀번호 보호와 어떻게 다른가?

'Read-Only recommended'는 파일을 읽기 전용 모드로 열라는 제안만 표시하며 우회하기 쉽습니다. [Password protection](/slides/ko/net/password-protected-presentation/)은 실제로 열기 또는 편집을 제한하며 실제 보안 제어가 필요할 때 적합합니다.

### 'Read-Only recommended'를 워터마크와 결합하여 편집을 더 억제할 수 있나요?

예. 권고는 [watermarks](/slides/ko/net/watermark/)와 함께 사용될 수 있으며, 시각적인 억제 수단으로 서로 별개의 메커니즘이지만 함께 잘 작동합니다.

### 권고가 활성화된 상태에서도 매크로나 외부 도구가 파일을 수정할 수 있나요?

예. 권고는 프로그래밍 방식의 변경을 차단하지 않습니다. 자동화된 편집을 방지하려면 [passwords and encryption](/slides/ko/net/password-protected-presentation/)를 사용하십시오.

### 'Read-Only recommended'와 'IsEncrypted' 및 'IsWriteProtected' 플래그는 어떻게 관련되어 있나요?

두 신호는 서로 다릅니다. 'Read-Only recommended'는 부드럽고 선택적인 프롬프트이며, [IsWriteProtected](https://reference.aspose.com/slides/ko/net/aspose.slides/protectionmanager/iswriteprotected/)와 [IsEncrypted](https://reference.aspose.com/slides/ko/net/aspose.slides/protectionmanager/isencrypted/)는 비밀번호나 암호화에 따라 실제 쓰기 또는 읽기 제한을 나타냅니다.