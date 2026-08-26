---
title: Python에서 프레젠테이션 비밀번호 보호
linktitle: 비밀번호 보호
type: docs
weight: 20
url: /ko/python-net/password-protected-presentation/
keywords:
- 비밀번호 보호 프레젠테이션
- 열기 비밀번호
- PowerPoint 암호화
- PowerPoint 복호화
- 프레젠테이션 비밀번호 검증
- 프레젠테이션 비밀번호 확인
- 암호화된 프레젠테이션 열기
- 암호화 제거
- PowerPoint
- PPT
- PPTX
- 프레젠테이션
- Python
- Aspose.Slides
description: "Python과 Aspose.Slides를 사용하여 비밀번호 보호된 PowerPoint PPT 및 PPTX 프레젠테이션을 암호화, 감지, 검증, 열기 및 복호화합니다."
---
## **개요**

열기 비밀번호는 프레젠테이션을 암호화합니다. 올바른 비밀번호가 있어야 프레젠테이션 콘텐츠를 로드하고 볼 수 있으므로 이 보호는 기밀성을 제공합니다.

열기 비밀번호는 쓰기 보호 비밀번호와 다릅니다. 쓰기 보호는 수정을 제한하지만 콘텐츠를 암호화하지 않으며 프레젠테이션을 로드하는 것을 방지하지도 않습니다. 프레젠테이션 수정용 비밀번호를 관리하려면 [Write-Protect Presentations](/slides/ko/python-net/write-protected-presentation/)를 참조하십시오.

아래 워크플로는 PPT 및 PPTX 프레젠테이션 모두에 적용됩니다. 예제에서는 파일 기반 및 스트림 기반 동작이 중요한 경우 두 형식을 모두 사용합니다.

## **열기 비밀번호로 프레젠테이션 암호화**

열기 비밀번호를 지정하려면 [ProtectionManager.encrypt](https://reference.aspose.com/slides/ko/python-net/aspose.slides/protectionmanager/encrypt/)을 사용합니다. 그런 다음 암호화된 프레젠테이션을 저장하려면 [Presentation.save](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/save/)을 사용합니다.

다음 예제는 PPTX 프레젠테이션을 암호화합니다:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.encrypt("open_password")
    presentation.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **암호화된 프레젠테이션 로드**

[LoadOptions.password](https://reference.aspose.com/slides/ko/python-net/aspose.slides/loadoptions/password/)에 열기 비밀번호를 설정하고 파일을 로드할 때 옵션을 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/)에 전달합니다. 열기 비밀번호가 필요하지만 제공된 비밀번호가 없거나 올바르지 않으면 로드에 실패합니다.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    # 복호화된 프레젠테이션 작업.
    pass
```

## **프레젠테이션 암호 해제**

열기 비밀번호와 함께 프레젠테이션을 로드하고, [ProtectionManager.remove_encryption](https://reference.aspose.com/slides/ko/python-net/aspose.slides/protectionmanager/remove_encryption/)을 호출한 뒤 결과를 저장합니다. 저장된 프레젠테이션은 비밀번호 없이 로드할 수 있습니다.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    presentation.protection_manager.remove_encryption()
    presentation.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **로드 전 열기 비밀번호 검증**

전체 프레젠테이션 인스턴스를 만들지 않고 [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentationfactory/get_presentation_info/)를 사용해 [PresentationInfo](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentationinfo/)를 얻습니다. 비밀번호가 필요한지 확인하려면 [PresentationInfo.is_password_protected](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentationinfo/is_password_protected/)을 확인합니다. 보호가 존재하면 제공된 값을 [PresentationInfo.check_password](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentationinfo/check_password/)으로 검증합니다.

### **파일 경로 워크플로**

다음 예제는 PPTX 파일에 대한 열기 비밀번호를 검증하고, 검증된 값을 [LoadOptions.password](https://reference.aspose.com/slides/ko/python-net/aspose.slides/loadoptions/password/)에 전달한 뒤 전체 프레젠테이션을 로드합니다:

```python
import aspose.slides as slides

file_path = "protected-presentation.pptx"
password = "open_password"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_path)

if not presentation_info.is_password_protected:
    print("The presentation does not have an opening password.")
elif not presentation_info.check_password(password):
    print("The opening password is incorrect.")
else:
    load_options = slides.LoadOptions()
    load_options.password = password

    with slides.Presentation(file_path, load_options) as presentation:
        print("The presentation was validated and loaded successfully.")
```

### **스트림 워크플로**

[PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentationfactory/get_presentation_info/)의 스트림 오버로드는 동일한 워크플로를 제공합니다. 스트림에서 전체 프레젠테이션을 로드하기 전에 스트림 위치를 재설정하십시오.

다음 예제는 PPT 파일을 사용합니다:

```python
import aspose.slides as slides

password = "open_password"

with open("protected-presentation.ppt", "rb") as presentation_stream:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(presentation_stream)

    if not presentation_info.is_password_protected:
        print("The presentation does not have an opening password.")
    elif not presentation_info.check_password(password):
        print("The opening password is incorrect.")
    else:
        presentation_stream.seek(0)
        load_options = slides.LoadOptions()
        load_options.password = password

        with slides.Presentation(presentation_stream, load_options) as presentation:
            print("The presentation was validated and loaded successfully.")
```

### **CheckPassword 반환 값**

[PresentationInfo.check_password](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentationinfo/check_password/)은 프레젠테이션에 열기 비밀번호가 있고 제공된 비밀번호가 올바른 경우에만 `True`를 반환합니다. 다음 경우에는 `False`를 반환합니다:

- 비밀번호가 올바르지 않은 경우.
- 프레젠테이션에 열기 비밀번호가 없는 경우.
- 제공된 비밀번호가 `None`이거나 비어 있는 경우.

동작은 PPT와 PPTX 프레젠테이션 모두 동일합니다.

## **로드된 프레젠테이션이 암호화되었는지 확인**

올바른 비밀번호로 프레젠테이션을 로드한 후 [ProtectionManager.is_encrypted](https://reference.aspose.com/slides/ko/python-net/aspose.slides/protectionmanager/is_encrypted/)을 검사하여 원본 프레젠테이션이 암호화되었는지 확인합니다. 로드 전에 열기 비밀번호 보호를 감지하려면 위에서 설명한 대로 `PresentationInfo.is_password_protected`를 사용하십시오.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    is_encrypted = presentation.protection_manager.is_encrypted
    print("The presentation is encrypted: " + str(is_encrypted))
```

## **보안 권장 사항**

{{% alert color="warning" title="Security" %}}
열기 비밀번호를 로그에 기록하거나 진단 메시지에 포함하지 마세요. 불필요한 반복 검증 시도를 피하고, 비밀번호는 필요한 동안만 메모리에 보관하며, 프레젠테이션을 즉시 로드할 경우 성공적인 검증 결과를 재사용하십시오.
{{% /alert %}}

## **온라인에서 프레젠테이션에 비밀번호 보호 적용**

1. [Aspose.Slides Lock](https://products.aspose.app/slides/ko/lock) 애플리케이션을 엽니다.
1. 프레젠테이션을 선택하거나 업로드합니다.
1. 보기 보호용 비밀번호를 입력합니다.
1. 필요에 따라 편집 보호용 별도 비밀번호를 입력합니다.
1. 보호를 적용하고 결과 파일을 다운로드합니다.

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/ko/python-net/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/ko/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**열기 비밀번호와 쓰기 보호 비밀번호의 차이점은 무엇인가요?**

열기 비밀번호는 프레젠테이션을 암호화하고 콘텐츠를 로드하려면 필요합니다. 쓰기 보호 비밀번호는 콘텐츠를 암호화하지 않고 수정만 제한합니다.

**전체 슬라이드를 로드하지 않고 열기 비밀번호를 검증할 수 있나요?**

예. 프레젠테이션 정보를 얻고, 열기 비밀번호 보호가 있는지 확인한 뒤, 전체 프레젠테이션 인스턴스를 만들기 전에 비밀번호를 검증합니다.

**비밀번호 검증 워크플로는 PPT와 PPTX 모두를 지원하나요?**

예. 파일 경로 및 스트림 기반 비밀번호 감지와 검증은 PPT와 PPTX 프레젠테이션 모두에서 동일하게 동작합니다.