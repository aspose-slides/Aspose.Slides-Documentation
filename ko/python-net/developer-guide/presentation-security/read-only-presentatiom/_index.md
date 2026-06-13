---
title: Python을 사용하여 읽기 전용 모드에서 프레젠테이션 저장
linktitle: 읽기 전용 프레젠테이션
type: docs
weight: 30
url: /ko/python-net/read-only-presentation/
keywords:
- 읽기 전용
- 프레젠테이션 보호
- 편집 방지
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint 파일(PPT, PPTX)을 읽기 전용 모드로 로드하고 저장하며, 프레젠테이션을 변경하지 않고 정확한 슬라이드 미리보기를 제공합니다."
---
## **소개**

PowerPoint 2019에서 Microsoft는 프레젠테이션을 보호하기 위해 사용자가 사용할 수 있는 옵션 중 하나로 **Always Open Read-Only** 설정을 도입했습니다. 다음과 같은 경우 프레젠테이션을 보호하기 위해 이 읽기 전용 설정을 사용하고 싶을 수 있습니다.

- 실수로 인한 편집을 방지하고 프레젠테이션 내용이 안전하게 유지되기를 원합니다.
- 제공한 프레젠테이션이 최종 버전임을 알리고 싶습니다.

프레젠테이션에 **Always Open Read-Only** 옵션을 선택하면 사용자가 프레젠테이션을 열 때 **Read-Only** 권고가 표시되고 다음과 같은 메시지가 나타날 수 있습니다: *실수로 인한 변경을 방지하기 위해 작성자가 이 파일을 읽기 전용으로 열도록 설정했습니다.*

Read-Only 권고는 사용자가 편집하기 전에 이를 해제해야 하므로 편집을 억제하는 간단하지만 효과적인 방지책입니다. 프레젠테이션을 수정하지 못하도록 하고 이를 정중하게 알리고 싶다면 Read-Only 권고가 좋은 옵션이 될 수 있습니다.

> **Read-Only** 보호가 적용된 프레젠테이션을 최근 도입된 기능을 지원하지 않는 이전 버전 Microsoft PowerPoint 애플리케이션에서 열 경우, **Read-Only** 권고가 무시되고 (프레젠테이션이 정상적으로 열립니다).

## **읽기 전용 모드 적용**

Aspose.Slides for Python via .NET을 사용하면 프레젠테이션을 **Read-Only**로 설정할 수 있으며, 이는 사용자가 프레젠테이션을 연 후 **Read-Only** 권고를 보게 됨을 의미합니다. 아래 샘플 코드는 Aspose.Slides를 사용하여 Python에서 프레젠테이션을 **Read-Only**로 설정하는 방법을 보여줍니다.

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.read_only_recommended = True
    pres.save("ReadOnlyPresentation.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 
**Note**: **Read-Only** 권고는 단순히 편집을 억제하거나 사용자가 PowerPoint 프레젠테이션을 실수로 변경하는 것을 방지하기 위한 것입니다. 작업을 잘 아는 의욕적인 사용자가 프레젠테이션을 편집하기로 결정하면 읽기 전용 설정을 쉽게 제거할 수 있습니다. 무단 편집을 실제로 방지해야 한다면 [암호화와 비밀번호를 포함하는 보다 강력한 보호](https://docs.aspose.com/slides/ko/python-net/password-protected-presentation/)를 사용하는 것이 좋습니다. 
{{% /alert %}} 

## **자주 묻는 질문**

**'Read-Only recommended'는 전체 비밀번호 보호와 어떻게 다른가요?**

'Read-Only recommended'는 파일을 읽기 전용 모드로 열라는 제안만 표시하며 쉽게 우회할 수 있습니다. [비밀번호 보호](/slides/ko/python-net/password-protected-presentation/)는 실제로 열기나 편집을 제한하며 실제 보안 제어가 필요할 때 적합합니다.

**'Read-Only recommended'를 워터마크와 결합하여 편집을 더욱 억제할 수 있나요?**

예. 권고는 시각적 억제 수단인 [워터마크](/slides/ko/python-net/watermark/)와 함께 사용할 수 있으며, 두 메커니즘은 별개이면서도 잘 작동합니다.

**권고가 활성화된 상태에서도 매크로나 외부 도구가 파일을 수정할 수 있나요?**

예. 권고는 프로그래밍 방식의 변경을 차단하지 않습니다. 자동 편집을 방지하려면 [비밀번호 및 암호화](/slides/ko/python-net/password-protected-presentation/)를 사용하세요.

**'Read-Only recommended'는 'is_encrypted'와 'is_write_protected' 플래그와는 어떻게 관련되나요?**

이들은 서로 다른 신호입니다. 'Read-Only recommended'는 부드럽고 선택적인 프롬프트이며, [is_write_protected](https://reference.aspose.com/slides/ko/python-net/aspose.slides/protectionmanager/is_write_protected/)와 [is_encrypted](https://reference.aspose.com/slides/ko/python-net/aspose.slides/protectionmanager/is_encrypted/)는 비밀번호 또는 암호화에 따라 실제 쓰기 또는 읽기 제한을 나타냅니다.