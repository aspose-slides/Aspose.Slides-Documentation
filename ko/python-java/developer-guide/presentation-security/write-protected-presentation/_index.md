---
title: Python에서 프레젠테이션 쓰기 보호
linktitle: 쓰기 보호
type: docs
weight: 25
url: /ko/python-java/write-protected-presentation/
keywords:
- 쓰기 보호
- PowerPoint 쓰기 보호
- 수정 비밀번호
- 프레젠테이션 편집 제한
- 쓰기 보호 제거
- 수정 비밀번호 검증
- PowerPoint
- 프레젠테이션
- 파이썬
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 PowerPoint PPT 및 PPTX 프레젠테이션에서 쓰기 보호 비밀번호를 설정하고, 감지하며, 검증하고, 제거합니다."
---
## **소개**

쓰기 보호 비밀번호는 프레젠테이션의 수정은 제한하지만 내용은 암호화하지 않습니다. 사용자는 비밀번호 없이도 쓰기 보호된 프레젠테이션을 로드하고 볼 수 있습니다. 애플리케이션에 따라 내용 편집 및 다른 이름으로 저장이 가능할 수 있으므로, 쓰기 보호를 기밀성 메커니즘으로 취급해서는 안 됩니다.

열기 비밀번호는 다른 목적을 가집니다: 프레젠테이션을 암호화하며 내용 로드 시 필요합니다. 프레젠테이션을 암호화하거나 열기 비밀번호를 확인하려면 [Password-Protect Presentations](/slides/ko/python-java/password-protected-presentation/)를 참조하세요.

이 문서의 워크플로는 PPT와 PPTX 프레젠테이션 모두에 적용됩니다. 예제는 PPTX 파일을 사용합니다; PPT로 저장할 때는 `.ppt` 확장자와 해당 PPT 저장 형식을 사용하십시오.

## **프레젠테이션에 쓰기 보호 설정**

[ProtectionManager.setWriteProtection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/protectionmanager/#setWriteProtection) 메서드를 사용하여 프레젠테이션 수정용 비밀번호를 지정합니다. 프레젠테이션을 저장하면 보호 설정이 유지됩니다.

다음 예제는 PPTX 프레젠테이션에 쓰기 보호를 설정합니다:
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.getProtectionManager().setWriteProtection("modify_password")
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **쓰기 보호된 프레젠테이션 로드**

쓰기 보호는 프레젠테이션 내용을 암호화하지 않으므로, 프레젠테이션을 로드하는 데 비밀번호가 필요하지 않습니다. 비밀번호는 보호된 프레젠테이션을 수정할 권한을 검증할 때만 사용됩니다.
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("write-protected-pres.pptx")
try:
    print("Slide count: " + str(presentation.getSlides().size()))
finally:
    presentation.dispose()
```

[LoadOptions.setPassword](https://reference.aspose.com/slides/ko/python-java/aspose.slides/loadoptions/#setPassword)에 쓰기 보호 비밀번호를 전달하지 마십시오. 이 메서드는 암호화된 내용에 대한 열기 비밀번호를 받습니다. 프레젠테이션에 두 종류의 보호가 모두 있는 경우, 열기 비밀번호를 제공해 로드하고 쓰기 보호 비밀번호는 별도로 처리하십시오.

## **프레젠테이션에서 쓰기 보호 제거**

[ProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/protectionmanager/#removeWriteProtection) 메서드를 사용해 수정 제한을 제거한 후 프레젠테이션을 저장합니다.
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("write-protected-pres.pptx")
try:
    presentation.getProtectionManager().removeWriteProtection()
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **프레젠테이션이 쓰기 보호인지 확인**

전체 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 인스턴스를 만들지 않고 파일을 검사하려면 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentationfactory/#getPresentationInfo)를 호출하고 [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentationinfo/#isWriteProtected)를 확인합니다. 이 메서드는 [NullableBool](https://reference.aspose.com/slides/ko/python-java/aspose.slides/nullablebool/)을 사용하며 쓰기 보호가 감지되면 `NullableBool.True_`를 반환합니다.
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx")

if presentation_info.isWriteProtected() == NullableBool.True_:
    print("The presentation is write protected.")
else:
    print("Write protection was not detected.")
```

[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentationfactory/#getPresentationInfo)의 스트림 오버로드는 스트림으로 제공된 프레젠테이션에 대해 동일한 정보를 제공합니다.

## **쓰기 보호 비밀번호 검증**

[PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentationinfo/#checkWriteProtection) 를 사용해 전체 프레젠테이션을 로드하지 않고 수정 비밀번호를 검증합니다. 먼저 [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentationinfo/#isWriteProtected)를 확인하여 쓰기 보호가 있을 때만 애플리케이션이 비밀번호를 요청하거나 검증하도록 합니다.
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx")

if presentation_info.isWriteProtected() != NullableBool.True_:
    print("The presentation is not write protected.")
elif presentation_info.checkWriteProtection("modify_password"):
    print("The write-protection password is correct.")
else:
    print("The write-protection password is incorrect.")
```

[PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentationinfo/#checkWriteProtection) 은 쓰기 보호 비밀번호만 검증합니다. 열기 비밀번호를 검증하거나 암호화된 내용을 로드할 수 있는지는 확인하지 않습니다. 반대로, [PresentationInfo.checkPassword](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentationinfo/#checkPassword) 은 열기 비밀번호만 검증합니다. 전체 프레젠테이션이 이미 로드된 경우, [ProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/protectionmanager/#checkWriteProtection) 은 보호 관리자를 통해 동일한 쓰기 보호 검사를 제공합니다.

프로덕션 애플리케이션에서는 비밀번호를 로그에 기록하거나 진단 메시지에 포함하지 마십시오. 불필요한 반복 검증 시도를 피하고, 비밀번호는 필요한 기간 동안만 메모리에 보관하십시오.

{{% alert color="info" title="관련 문서" %}}
- [프레젠테이션 암호 보호](/slides/ko/python-java/password-protected-presentation/)
- [읽기 전용 프레젠테이션](/slides/ko/python-java/read-only-presentation/)
- [PowerPoint 디지털 서명](/slides/ko/python-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **자주 묻는 질문**

**쓰기 보호가 프레젠테이션을 암호화합니까?**

아니오. 수정은 제한하지만 프레젠테이션 내용은 로드 및 조회가 가능하도록 남겨 둡니다.

**프레젠테이션을 열 때 쓰기 보호 비밀번호가 필요합니까?**

아니오. 암호화된 프레젠테이션 내용을 로드하려면 열기 비밀번호만 필요합니다.

**프레젠테이션에 열기 비밀번호와 쓰기 보호 비밀번호를 모두 설정할 수 있습니까?**

예. 로드 옵션을 통해 열기 비밀번호를 제공하여 암호화된 프레젠테이션을 열고, 수정 권한이 필요할 때 쓰기 보호 비밀번호를 별도로 검증합니다.