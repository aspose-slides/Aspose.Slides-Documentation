---
title: Python을 사용하여 읽기 전용 모드로 프레젠테이션 저장
linktitle: 읽기 전용 프레젠테이션
type: docs
weight: 30
url: /ko/python-java/read-only-presentation/
keywords:
- 읽기 전용
- 프레젠테이션 보호
- 편집 방지
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 PowerPoint 파일(PPT, PPTX)을 읽기 전용 모드로 로드하고 저장하며, 프레젠테이션을 변경하지 않고 정확한 슬라이드 미리보기를 제공합니다."
---
## **소개**

PowerPoint 2019에서 Microsoft는 프레젠테이션을 보호하기 위한 옵션 중 하나로 **항상 읽기 전용으로 열기** 설정을 도입했습니다. 다음과 같은 경우에 이 읽기 전용 설정을 사용하고 싶을 수 있습니다:

- 실수로 편집되는 것을 방지하고 프레젠테이션 내용을 안전하게 유지하고 싶을 때.  
- 제공한 프레젠테이션이 최종 버전임을 사용자에게 알리고 싶을 때.  

프레젠테이션에 **항상 읽기 전용으로 열기** 옵션을 선택하면 사용자가 파일을 열 때 **읽기 전용** 권고가 표시되고 다음과 같은 메시지가 나타날 수 있습니다: *실수로 변경되는 것을 방지하기 위해 작성자가 이 파일을 읽기 전용으로 열도록 설정했습니다.*

읽기 전용 권고는 사용자가 프레젠테이션을 편집하기 전에 이를 해제해야 하므로 편집을 억제하는 간단하지만 효과적인 방지 수단입니다. 사용자가 프레젠테이션을 수정하지 못하게 하고 정중하게 알리고 싶다면 읽기 전용 권고가 좋은 옵션이 될 수 있습니다.

> **읽기 전용** 보호가 적용된 프레젠테이션이 최근에 도입된 기능을 지원하지 않는 오래된 Microsoft PowerPoint 애플리케이션에서 열릴 경우 **읽기 전용** 권고는 무시되고 (프레젠테이션이 정상적으로 열립니다).

## **읽기 전용 모드 적용**

Aspose.Slides for Python via Java를 사용하면 프레젠테이션을 **읽기 전용**으로 설정할 수 있습니다. 즉, 사용자가 프레젠테이션을 연 후 **읽기 전용** 권고가 표시됩니다. 다음 샘플 코드는 Aspose.Slides를 사용해 Python에서 프레젠테이션을 **읽기 전용**으로 설정하는 방법을 보여줍니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getProtectionManager().setReadOnlyRecommended(True)
    presentation.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 

**읽기 전용** 권고는 PowerPoint 프레젠테이션을 편집하거나 실수로 변경하는 것을 억제하기 위한 단순한 안내입니다. 작업에 익숙한 사람이 의도적으로 프레젠테이션을 편집하려 한다면 읽기 전용 설정을 쉽게 해제할 수 있습니다. 무단 편집을 확실히 방지해야 한다면 [보다 강력한 암호화 및 비밀번호 보호](/slides/ko/python-java/password-protected-presentation/)를 사용하는 것이 좋습니다. 

{{% /alert %}} 

## **FAQ**

**'읽기 전용 권고'와 전체 비밀번호 보호는 어떻게 다른가요?**  
'읽기 전용 권고'는 파일을 읽기 전용 모드로 열라는 제안만 표시되며 쉽게 우회할 수 있습니다. [비밀번호 보호](/slides/ko/python-java/password-protected-presentation/)는 실제로 열기 또는 편집을 제한하며, 실질적인 보안이 필요할 때 적합합니다.

**'읽기 전용 권고'를 워터마크와 결합해 편집을 더욱 억제할 수 있나요?**  
예. 권고는 [워터마크](/slides/ko/python-java/watermark/)와 함께 사용하면 시각적인 억제 효과를 제공하며, 두 메커니즘은 별도로 작동하면서도 잘 어울립니다.

**권고가 활성화된 상태에서도 매크로나 외부 도구가 파일을 수정할 수 있나요?**  
예. 권고는 프로그램적인 변경을 차단하지 않습니다. 자동화된 편집을 방지하려면 [비밀번호와 암호화](/slides/ko/python-java/password-protected-presentation/)를 사용하세요.

**'읽기 전용 권고'는 [isEncrypted](https://reference.aspose.com/slides/ko/python-java/aspose.slides/protectionmanager/#isEncrypted) 및 [isWriteProtected](https://reference.aspose.com/slides/ko/python-java/aspose.slides/protectionmanager/#isWriteProtected) 메서드와 어떤 관련이 있나요?**  
이들은 서로 다른 신호입니다. '읽기 전용 권고'는 부드럽고 선택적인 안내이며, [isWriteProtected](https://reference.aspose.com/slides/ko/python-java/aspose.slides/protectionmanager/#isWriteProtected)와 [isEncrypted](https://reference.aspose.com/slides/ko/python-java/aspose.slides/protectionmanager/#isEncrypted)는 비밀번호나 암호화에 따라 실제 쓰기 또는 읽기 제한을 나타냅니다.