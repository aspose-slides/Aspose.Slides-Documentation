---
title: C++를 사용하여 읽기 전용 모드로 프레젠테이션 저장
linktitle: 읽기 전용 프레젠테이션
type: docs
weight: 30
url: /ko/cpp/read-only-presentation/
keywords:
- 읽기 전용
- 프레젠테이션 보호
- 편집 방지
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용해 PowerPoint 파일(PPT, PPTX)을 읽기 전용 모드로 로드하고 저장하여 프레젠테이션을 변경하지 않고 정확한 슬라이드 미리보기를 제공합니다."
---
## **소개**

PowerPoint 2019에서 Microsoft는 프레젠테이션을 보호하기 위해 사용자가 사용할 수 있는 옵션 중 하나로 **Always Open Read-Only** 설정을 도입했습니다. 다음과 같은 경우 프레젠테이션을 보호하기 위해 이 읽기 전용 설정을 사용하고 싶을 수 있습니다.

- 실수로 편집되는 것을 방지하고 프레젠테이션 내용을 안전하게 유지하고 싶을 때. 
- 제공한 프레젠테이션이 최종 버전임을 사람들에게 알리고 싶을 때. 

프레젠테이션에 **Always Open Read-Only** 옵션을 선택하면 사용자가 프레젠테이션을 열었을 때 **Read-Only** 권고가 표시되고 다음과 같은 메시지가 나타날 수 있습니다: *실수로 변경되는 것을 방지하기 위해 작성자가 이 파일을 읽기 전용으로 열도록 설정했습니다.*

Read-Only 권고는 사용자가 편집하기 전에 이를 해제해야 하므로 편집을 억제하는 간단하지만 효과적인 방지책입니다. 프레젠테이션에 대한 변경을 원하지 않으며 이를 정중하게 알리고 싶다면 Read-Only 권고가 좋은 옵션이 될 수 있습니다.

> **Read-Only** 보호가 적용된 프레젠테이션을 최근에 도입된 기능을 지원하지 않는 오래된 Microsoft PowerPoint 애플리케이션에서 열면 **Read-Only** 권고가 무시되고(프레젠테이션이 정상적으로 열림) 됩니다.

## **읽기 전용 모드 적용**

Aspose.Slides for C++를 사용하면 프레젠테이션을 **Read-Only** 로 설정할 수 있으며, 이는 사용자가 프레젠테이션을 연 후 **Read-Only** 권고를 보게 됨을 의미합니다. 다음 샘플 코드는 Aspose.Slides를 사용해 C++에서 프레젠테이션을 **Read-Only** 로 설정하는 방법을 보여줍니다.

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
pres->get_ProtectionManager()->set_ReadOnlyRecommended(true);
pres->Save(u"ReadOnlyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert color="info" %}} 

**Note**: The **Read-Only** recommendation is simply meant to discourage editing or stop users from making accidental changes to a PowerPoint presentation. If a motivated person—who knows what they are doing—decides to edit your presentation, they can easily remove the Read-Only setting. If you seriously need to prevent unauthorized editing, you are better off using [more stringent protections that involve encryptions and passwords](https://docs.aspose.com/slides/ko/cpp/password-protected-presentation/). 

{{% /alert %}} 

## **FAQ**

### 'Read-Only recommended'는 전체 암호 보호와 어떻게 다릅니까?

'Read-Only recommended'는 파일을 읽기 전용 모드로 열라는 제안만 표시되며 쉽게 우회할 수 있습니다. [암호 보호](/slides/ko/cpp/password-protected-presentation/)는 실제로 열기와 편집을 제한하며 실제 보안 제어가 필요할 때 적합합니다.

### 'Read-Only recommended'를 워터마크와 결합해 편집을 더 억제할 수 있나요?

예. 권고는 [워터마크](/slides/ko/cpp/watermark/)와 함께 시각적인 억제 수단으로 사용할 수 있으며, 두 메커니즘은 별개이면서도 잘 함께 동작합니다.

### 권고가 활성화된 상태에서 매크로나 외부 도구가 파일을 수정할 수 있나요?

예. 권고는 프로그래밍 방식의 변경을 차단하지 않습니다. 자동화된 편집을 방지하려면 [암호와 암호화](/slides/ko/cpp/password-protected-presentation/)를 사용하세요.

### 'Read-Only recommended'는 'is encrypted'와 'is write protected' 플래그와 어떤 관련이 있나요?

이들은 서로 다른 신호입니다. 'Read-Only recommended'는 부드러운 선택적 프롬프트이며, [get_IsWriteProtected](https://reference.aspose.com/slides/ko/cpp/aspose.slides/protectionmanager/get_iswriteprotected/)와 [get_IsEncrypted](https://reference.aspose.com/slides/ko/cpp/aspose.slides/protectionmanager/get_isencrypted/)는 실제 비밀번호나 암호화에 기반한 쓰기 또는 읽기 제한을 나타냅니다.