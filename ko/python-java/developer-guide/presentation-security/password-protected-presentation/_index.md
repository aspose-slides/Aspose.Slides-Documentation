---
title: Python에서 프레젠테이션 암호 보호
linktitle: 비밀번호 보호
type: docs
weight: 20
url: /ko/python-java/password-protected-presentation/
keywords:
- 암호로 보호된 프레젠테이션
- 열기 암호
- PowerPoint 암호화
- PowerPoint 복호화
- 프레젠테이션 암호 검증
- 프레젠테이션 암호 확인
- 암호화된 프레젠테이션 열기
- 암호 제거
- PowerPoint
- PPT
- PPTX
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 암호로 보호된 PowerPoint PPT 및 PPTX 프레젠테이션을 암호화, 감지, 검증, 열기 및 복호화합니다."
---
## **개요**

열기 암호는 프레젠테이션을 암호화합니다. 올바른 암호가 있어야 프레젠테이션 콘텐츠를 로드하고 볼 수 있으므로 이 보호는 기밀성을 제공합니다.

열기 암호는 쓰기 보호 암호와 다릅니다. 쓰기 보호는 수정은 제한하지만 콘텐츠를 암호화하지 않으며 프레젠테이션 로드를 방지하지도 않습니다. 프레젠테이션 수정용 암호를 관리하려면 [Write-Protect Presentations](/slides/ko/python-java/write-protected-presentation/)를 참조하십시오.

아래 워크플로우는 PPT와 PPTX 프레젠테이션 모두에 적용됩니다. 예제는 파일 기반 동작과 스트림 기반 동작이 중요한 경우 두 형식을 모두 사용합니다.

## **열기 암호로 프레젠테이션 암호화**

[ProtectionManager.encrypt](https://reference.aspose.com/slides/ko/python-java/aspose.slides/protectionmanager/#encrypt) 를 사용하여 열기 암호를 지정합니다. 그런 다음 [Presentation.save](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#save) 을 사용해 암호화된 프레젠테이션을 저장합니다.

다음 예제는 PPTX 프레젠테이션을 암호화합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.getProtectionManager().encrypt("open_password")
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **문서 속성을 공개 유지**

기본적으로 Aspose.Slides는 프레젠테이션 암호화에 문서 속성을 포함합니다. [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/ko/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) 메서드는 슬라이드 콘텐츠 암호화와는 별도로 이 동작을 제어합니다. 인덱싱, 분류, 검색 또는 문서 관리 시스템이 열기 암호 없이 메타데이터를 읽어야 하는 경우 [ProtectionManager.encrypt](https://reference.aspose.com/slides/ko/python-java/aspose.slides/protectionmanager/#encrypt) 호출 전에 `False` 를 전달하십시오.

다음 예제는 내장 문서 속성을 공개한 채 암호화된 PPTX 프레젠테이션을 생성합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    properties = presentation.getDocumentProperties()
    properties.setAuthor("Contoso Knowledge Management")
    properties.setTitle("Quarterly Product Roadmap")
    properties.setKeywords("roadmap, planning, internal")

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content")
    presentation.getProtectionManager().setEncryptDocumentProperties(False)
    presentation.getProtectionManager().encrypt("open_password")
    presentation.save("public-properties-encrypted.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/ko/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) 에 `False` 를 전달해도 슬라이드, 마스터, 레이아웃, 도형, 미디어 또는 기타 프레젠테이션 콘텐츠가 공개되는 것은 아닙니다. 이는 오직 문서 속성만 영향을 미칩니다. 암호화된 콘텐츠를 로드하지 않고 해당 속성을 읽으려면 [Manage Presentation Properties](/slides/ko/python-java/presentation-properties/)를 참조하십시오.

## **암호화된 프레젠테이션 로드**

[LoadOptions.setPassword](https://reference.aspose.com/slides/ko/python-java/aspose.slides/loadoptions/#setPassword) 에 열기 암호를 설정하고 파일을 로드할 때 옵션을 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 에 전달합니다. 열기 암호가 필요하지만 제공된 암호가 없거나 잘못된 경우 로드가 실패합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    # 복호화된 프레젠테이션 작업.
    pass
finally:
    presentation.dispose()
```

## **프레젠테이션에서 암호 제거**

프레젠테이션을 열기 암호와 함께 로드하고 [ProtectionManager.removeEncryption](https://reference.aspose.com/slides/ko/python-java/aspose.slides/protectionmanager/#removeEncryption) 을 호출한 뒤 결과를 저장합니다. 저장된 프레젠테이션은 이제 암호 없이 로드할 수 있습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    presentation.getProtectionManager().removeEncryption()
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **로드하기 전에 열기 암호 검증**

[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentationfactory/#getPresentationInfo) 를 사용하여 전체 프레젠테이션 인스턴스를 만들지 않고도 [PresentationInfo](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentationinfo/) 를 가져옵니다. 암호를 요청하거나 검증하기 전에 [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentationinfo/#isPasswordProtected) 를 확인하십시오. 보호가 있는 경우 제공된 값을 [PresentationInfo.checkPassword](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentationinfo/#checkPassword) 로 검증합니다.

### **파일 경로 워크플로우**

다음 예제는 PPTX 파일에 대한 열기 암호를 검증하고, 검증된 값을 [LoadOptions.setPassword](https://reference.aspose.com/slides/ko/python-java/aspose.slides/loadoptions/#setPassword) 에 전달한 뒤 전체 프레젠테이션을 로드합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationFactory

file_path = "protected-presentation.pptx"
password = "open_password"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_path)

if not presentation_info.isPasswordProtected():
    print("The presentation does not have an opening password.")
elif not presentation_info.checkPassword(password):
    print("The opening password is incorrect.")
else:
    load_options = LoadOptions()
    load_options.setPassword(password)

    presentation = Presentation(file_path, load_options)
    try:
        print("The presentation was validated and loaded successfully.")
    finally:
        presentation.dispose()
```

### **스트림 워크플로우**

[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentationfactory/#getPresentationInfo) 의 스트림 오버로드는 동일한 워크플로우를 제공합니다. 해당 스트림에서 전체 프레젠테이션을 로드하기 전에 스트림 위치를 재설정하십시오.

다음 예제는 PPT 파일을 사용합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationFactory

FileInputStream = jpype.JClass("java.io.FileInputStream")

password = "open_password"

presentation_stream = FileInputStream("protected-presentation.ppt")
try:
    presentation_info = PresentationFactory.getInstance().getPresentationInfo(presentation_stream)

    if not presentation_info.isPasswordProtected():
        print("The presentation does not have an opening password.")
    elif not presentation_info.checkPassword(password):
        print("The opening password is incorrect.")
    else:
        presentation_stream.getChannel().position(0)

        load_options = LoadOptions()
        load_options.setPassword(password)

        presentation = Presentation(presentation_stream, load_options)
        try:
            print("The presentation was validated and loaded successfully.")
        finally:
            presentation.dispose()
finally:
    presentation_stream.close()
```

### **checkPassword 반환 값**

[PresentationInfo.checkPassword](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentationinfo/#checkPassword) 은 프레젠테이션에 열기 암호가 있고 제공된 암호가 올바른 경우에만 `True` 를 반환합니다. 다음 경우에는 `False` 를 반환합니다:

- 암호가 올바르지 않은 경우.
- 프레젠테이션에 열기 암호가 없는 경우.
- 제공된 암호가 `None` 이거나 비어 있는 경우.

PPT와 PPTX 프레젠테이션 모두에 동일하게 적용됩니다.

## **로드된 프레젠테이션이 암호화되었는지 확인**

올바른 암호로 프레젠테이션을 로드한 후 [ProtectionManager.isEncrypted](https://reference.aspose.com/slides/ko/python-java/aspose.slides/protectionmanager/#isEncrypted) 를 확인하여 원본 프레젠테이션이 암호화되었는지 확인합니다. 로드하기 전에 열기 암호 보호를 감지하려면 위에서 설명한 대로 [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentationinfo/#isPasswordProtected) 를 사용하십시오.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    is_encrypted = presentation.getProtectionManager().isEncrypted()
    print(f"The presentation is encrypted: {is_encrypted}")
finally:
    presentation.dispose()
```

## **보안 권장 사항**

{{% alert color="warning" title="Security" %}}
열기 암호를 로그에 기록하거나 진단 메시지에 포함하지 마십시오. 불필요한 반복 검증 시도를 피하고, 암호를 메모리에 필요한 시간만 유지하며, 프레젠테이션을 즉시 로드할 경우 성공적인 검증 결과를 재사용하십시오.

문서 속성이 공개되면 저자 이름, 제목, 주제, 키워드, 회사 정보, 주석 및 사용자 지정 값이 암호화된 프레젠테이션 콘텐츠와 무관하게 노출될 수 있습니다. 민감한 메타데이터는 프레젠테이션과 함께 암호화하십시오. 속성을 공개하는 경우는 시스템이 열기 암호 없이 파일을 인덱싱, 분류, 검색 또는 관리해야 할 때만 명시적인 결정이어야 합니다.
{{% /alert %}}

## **온라인에서 프레젠테이션 암호 보호**

1. [Aspose.Slides Lock](https://products.aspose.app/slides/ko/lock) 애플리케이션을 엽니다.
2. 프레젠테이션을 선택하거나 업로드합니다.
3. 보기 보호용 암호를 입력합니다.
4. 필요에 따라 편집 보호용 별도 암호를 입력합니다.
5. 보호를 적용하고 결과 파일을 다운로드합니다.

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/ko/python-java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/ko/python-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**열기 암호와 쓰기 보호 암호의 차이점은 무엇인가요?**

열기 암호는 프레젠테이션을 암호화하고 콘텐츠를 로드하려면 필요합니다. 쓰기 보호 암호는 콘텐츠를 암호화하지 않고 수정만 제한합니다.

**모든 슬라이드를 로드하지 않고 열기 암호를 검증할 수 있나요?**

예. 프레젠테이션 정보를 가져와 열기 암호 보호가 존재하는지 확인하고 전체 프레젠테이션 인스턴스를 만들기 전에 암호를 검증하십시오.

**응용 프로그램이 열기 암호 없이 메타데이터를 읽을 수 있나요?**

예, 단지 문서 속성 암호화가 비활성화된 경우에만 가능합니다. 이 경우에는 [Manage Presentation Properties](/slides/ko/python-java/presentation-properties/)에 설명된 문서 속성 전용 로드 모드를 사용해야 합니다.

**암호 검증 워크플로우가 PPT와 PPTX 모두를 지원하나요?**

예. 파일 경로 및 스트림 기반 암호 감지와 검증은 PPT와 PPTX 프레젠테이션에 동일하게 동작합니다.