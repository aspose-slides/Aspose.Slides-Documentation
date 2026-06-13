---
title: 읽기 전용 모드에서 프레젠테이션 저장 (.NET)
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
description: "Aspose.Slides for .NET을 사용하여 PowerPoint 파일(PPT, PPTX)을 읽기 전용 모드로 로드하고 저장하여 프레젠테이션을 변경하지 않고도 정확한 슬라이드 미리보기를 제공합니다."
---
## **소개**

PowerPoint 2019에서 Microsoft는 프레젠테이션을 보호하기 위해 사용자가 사용할 수 있는 옵션 중 하나로 **Always Open Read-Only** 설정을 도입했습니다. 다음과 같은 경우에 이 읽기 전용 설정을 사용하여 프레젠테이션을 보호하고 싶을 수 있습니다.

- 우발적인 편집을 방지하고 프레젠테이션 내용을 안전하게 유지하고 싶을 때. 
- 제공한 프레젠테이션이 최종 버전임을 사람들에게 알리고 싶을 때. 

프레젠테이션에 **Always Open Read-Only** 옵션을 선택하면, 사용자가 프레젠테이션을 열었을 때 **Read-Only** 권고가 표시되며 다음과 같은 메시지를 볼 수 있습니다: *우발적인 변경을 방지하기 위해 작성자가 이 파일을 읽기 전용으로 열도록 설정했습니다.*

Read-Only 권고는 간단하면서도 효과적인 억제 수단으로, 사용자가 프레젠테이션을 편집하려면 이를 제거하는 작업을 해야 하므로 편집을 방지합니다. 프레젠테이션에 대한 변경을 원하지 않으며 이를 정중하게 알리고 싶다면 Read-Only 권고가 좋은 옵션이 될 수 있습니다. 

> **Read-Only** 보호가 적용된 프레젠테이션을 최근 도입된 기능을 지원하지 않는 오래된 Microsoft PowerPoint 애플리케이션에서 열면, **Read-Only** 권고가 무시되고 (프레젠테이션이 정상적으로 열립니다).

## **읽기 전용 모드 적용**

Aspose.Slides for .NET을 사용하면 프레젠테이션을 **Read-Only**로 설정할 수 있으며, 이는 사용자가 프레젠테이션을 연 후 **Read-Only** 권고를 보게 됨을 의미합니다. 다음 샘플 코드는 Aspose.Slides를 사용하여 C#에서 프레젠테이션을 **Read-Only**로 설정하는 방법을 보여줍니다.

```c#
using (Presentation pres = new Presentation())
{
    pres.ProtectionManager.ReadOnlyRecommended = true;
    pres.Save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}} 

**Note**: **Read-Only** 권고는 PowerPoint 프레젠테이션에 대한 편집을 억제하거나 우발적인 변경을 방지하기 위한 간단한 권고일 뿐입니다. 작업을 잘 아는 의욕적인 사용자가 프레젠테이션을 편집하기로 결정하면 쉽게 Read-Only 설정을 제거할 수 있습니다. 무단 편집을 확실히 방지해야 한다면 [암호화와 비밀번호를 포함하는 보다 엄격한 보호](https://docs.aspose.com/slides/ko/net/password-protected-presentation/)을 사용하는 것이 좋습니다. 

{{% /alert %}} 

## **FAQ**

**'Read-Only recommended'는 전체 암호 보호와 어떻게 다릅니까?**

'Read-Only recommended'는 파일을 읽기 전용 모드로 열 것을 제안하는 메시지일 뿐이며 쉽게 우회할 수 있습니다. [비밀번호 보호](/slides/ko/net/password-protected-presentation/)은 실제로 열기나 편집을 제한하며 실제 보안 제어가 필요할 때 적합합니다.

**'Read-Only recommended'는 워터마크와 결합하여 편집을 더욱 억제할 수 있습니까?**

예. 이 권고는 시각적 억제 수단으로 [워터마크](/slides/ko/net/watermark/)와 함께 사용할 수 있으며, 두 메커니즘은 별개이며 함께 잘 작동합니다.

**'Read-Only recommended'가 활성화된 경우 매크로나 외부 도구가 여전히 파일을 수정할 수 있습니까?**

예. 이 권고는 프로그래밍 방식의 변경을 차단하지 않습니다. 자동 편집을 방지하려면 [비밀번호와 암호화](/slides/ko/net/password-protected-presentation/)를 사용하십시오.

**'Read-Only recommended'는 'IsEncrypted' 및 'IsWriteProtected' 플래그와 어떻게 관련되어 있습니까?**

이들은 서로 다른 신호입니다. **Read-Only recommended**는 부드럽고 선택적인 프롬프트이며, [IsWriteProtected](https://reference.aspose.com/slides/ko/net/aspose.slides/protectionmanager/iswriteprotected/)와 [IsEncrypted](https://reference.aspose.com/slides/ko/net/aspose.slides/protectionmanager/isencrypted/)는 비밀번호나 암호화에 따라 실제 쓰기 또는 읽기 제한을 나타냅니다.