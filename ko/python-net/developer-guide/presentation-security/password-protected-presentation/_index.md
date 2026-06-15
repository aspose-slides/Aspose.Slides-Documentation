---
title: Python을 사용하여 비밀번호로 프레젠테이션 보호
linktitle: 비밀번호 보호
type: docs
weight: 20
url: /ko/python-net/password-protected-presentation/
keywords:
- PowerPoint 잠금
- 프레젠테이션 잠금
- PowerPoint 잠금 해제
- 프레젠테이션 잠금 해제
- PowerPoint 보호
- 프레젠테이션 보호
- 비밀번호 설정
- 비밀번호 추가
- PowerPoint 암호화
- 프레젠테이션 암호화
- PowerPoint 복호화
- 프레젠테이션 복호화
- 쓰기 보호
- PowerPoint 보안
- 프레젠테이션 보안
- 비밀번호 제거
- 보호 제거
- 암호화 제거
- 비밀번호 비활성화
- 보호 비활성화
- 쓰기 보호 제거
- PowerPoint 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python을 사용하여 .NET 환경에서 비밀번호로 보호된 PowerPoint 및 OpenDocument 프레젠테이션을 손쉽게 잠그고 해제하는 방법을 배워보세요. 단계별 가이드를 통해 생산성을 높이고 프레젠테이션을 안전하게 보호할 수 있습니다."
---
## **소개**

프레젠테이션에 암호 보호를 설정하면 프레젠테이션에 특정 제한을 적용하는 암호를 설정하게 됩니다. 제한을 해제하려면 암호를 입력해야 합니다. 암호가 보호된 프레젠테이션은 잠긴 프레젠테이션으로 간주됩니다.

일반적으로 프레젠테이션에 이러한 제한을 적용하기 위해 암호를 설정할 수 있습니다:

- **수정**

  특정 사용자만 프레젠테이션을 수정하도록 하려면 수정 제한을 설정할 수 있습니다. 이 제한은 사용자가 암호를 제공하지 않는 한 프레젠테이션을 수정, 변경 또는 복사하는 것을 방지합니다.  

  그러나 이 경우 암호가 없어도 사용자는 문서에 접근하여 열 수 있습니다. 읽기 전용 모드에서는 사용자가 프레젠테이션 내부의 하이퍼링크, 애니메이션, 효과 등 내용을 볼 수 있지만 항목을 복사하거나 프레젠테이션을 저장할 수 없습니다.  

- **열기**

  특정 사용자만 프레젠테이션을 열 수 있도록 하려면 열기 제한을 설정할 수 있습니다. 이 제한은 사용자가 암호를 제공하지 않는 한 프레젠테이션 내용을 볼 수 없도록 방지합니다.  

  기술적으로 열기 제한은 사용자가 프레젠테이션을 열 수 없게 함으로써 수정도 불가능하게 합니다. 사용자가 프레젠테이션을 열 수 없으면 수정하거나 변경할 수도 없습니다.  

  **Note** 암호 보호를 통해 열기를 방지하면 프레젠테이션 파일이 암호화됩니다.

## 온라인에서 프레젠테이션에 암호 보호 적용 방법

1. 당사의 [**Aspose.Slides Lock**](https://products.aspose.app/slides/ko/lock) 페이지로 이동합니다.  

   ![todo:image_alt_text](slides-lock.png)

2. **Drop or upload your files** 를 클릭합니다.  

3. 컴퓨터에서 암호 보호할 파일을 선택합니다.  

4. 편집 보호용 비밀번호와 보기 보호용 비밀번호를 입력합니다.  

5. 사용자가 프레젠테이션을 최종 사본으로 보게 하려면 **Mark as final** 체크박스를 선택합니다.  

6. **PROTECT NOW.** 를 클릭합니다.  

7. **DOWNLOAD NOW.** 를 클릭합니다.  

## **Aspose.Slides에서 프레젠테이션 암호 보호**
**지원 형식**

Aspose.Slides는 다음 형식의 프레젠테이션에 대해 암호 보호, 암호화 및 유사한 작업을 지원합니다:  

- PPTX 및 PPT - Microsoft PowerPoint 프레젠테이션  
- ODP - OpenDocument 프레젠테이션  
- OTP - OpenDocument 프레젠테이션 템플릿  

**지원 작업**

Aspose.Slides를 사용하면 다음과 같은 방법으로 프레젠테이션 수정 방지를 위해 암호 보호를 적용할 수 있습니다:  

- 프레젠테이션 암호화  
- 프레젠테이션에 쓰기 보호 설정  

**기타 작업**

Aspose.Slides를 사용하면 다음과 같은 방법으로 암호 보호 및 암호화와 관련된 기타 작업을 수행할 수 있습니다:  

- 프레젠테이션 복호화; 암호화된 프레젠테이션 열기  
- 암호화 제거; 암호 보호 비활성화  
- 프레젠테이션의 쓰기 보호 제거  
- 암호화된 프레젠테이션의 속성 가져오기  
- 프레젠테이션이 암호화되었는지 확인하기  
- 프레젠테이션이 암호로 보호되었는지 확인하기.  

## **프레젠테이션 암호화**

프레젠테이션에 암호를 설정하여 암호화할 수 있습니다. 그런 다음 잠긴 프레젠테이션을 수정하려면 사용자가 암호를 제공해야 합니다.  

프레젠테이션을 암호화하거나 암호 보호하려면 [ProtectionManager](https://reference.aspose.com/slides/ko/python-net/aspose.slides/protectionmanager/)의 `encrypt` 메서드를 사용하여 프레젠테이션에 암호를 설정합니다. `encrypt` 메서드에 암호를 전달하고 `save` 메서드로 이제 암호화된 프레젠테이션을 저장합니다.  

다음 샘플 코드는 프레젠테이션을 암호화하는 방법을 보여줍니다:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt("123123")
    pres.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **프레젠테이션에 쓰기 보호 설정** 

프레젠테이션에 “수정 금지” 표시를 추가할 수 있습니다. 이를 통해 사용자가 프레젠테이션을 변경하지 않도록 알릴 수 있습니다.  

**Note** 쓰기 보호 과정은 프레젠테이션을 암호화하지 않습니다. 따라서 사용자는 실제로 원한다면 프레젠테이션을 수정할 수 있지만 변경 사항을 저장하려면 다른 이름으로 파일을 만들어야 합니다.  

쓰기 보호를 설정하려면 `setWriteProtection` 메서드를 사용합니다. 다음 샘플 코드는 프레젠테이션에 쓰기 보호를 설정하는 방법을 보여줍니다:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.set_write_protection("123123")
    pres.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **프레젠테이션 복호화; 암호화된 프레젠테이션 열기**

Aspose.Slides는 암호를 전달하여 암호화된 파일을 로드할 수 있게 해줍니다. 프레젠테이션을 복호화하려면 매개변수가 없는 `remove_encryption` 메서드를 호출해야 합니다. 그런 다음 올바른 암호를 입력하여 프레젠테이션을 로드합니다.  

다음 샘플 코드는 프레젠테이션을 복호화하는 방법을 보여줍니다: 

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    print(pres.document_properties.author)
```

## **암호화 제거; 암호 보호 비활성화**

프레젠테이션에서 암호화 또는 암호 보호를 제거할 수 있습니다. 이렇게 하면 사용자가 제한 없이 프레젠테이션에 접근하거나 수정할 수 있게 됩니다.  

암호화 또는 암호 보호를 제거하려면 `remove_encryption` 메서드를 호출합니다. 다음 샘플 코드는 프레젠테이션에서 암호화를 제거하는 방법을 보여줍니다:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    pres.protection_manager.remove_encryption()
    pres.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **프레젠테이션의 쓰기 보호 제거**

Aspose.Slides를 사용하여 프레젠테이션 파일에 적용된 쓰기 보호를 제거할 수 있습니다. 이렇게 하면 사용자는 원하는 대로 수정할 수 있으며, 해당 작업을 수행할 때 경고가 표시되지 않습니다.  

`remove_write_protection` 메서드를 사용하여 프레젠테이션의 쓰기 보호를 제거합니다. 다음 샘플 코드는 프레젠테이션에서 쓰기 보호를 제거하는 방법을 보여줍니다:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    pres.protection_manager.remove_write_protection()
    pres.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **암호화된 프레젠테이션의 속성 가져오기**

일반적으로 사용자는 암호화되거나 암호로 보호된 프레젠테이션의 문서 속성을 얻는 데 어려움을 겪습니다. 그러나 Aspose.Slides는 프레젠테이션을 암호 보호하면서도 사용자가 해당 프레젠테이션의 속성에 접근할 수 있는 메커니즘을 제공합니다.  

**Note** Aspose.Slides가 프레젠테이션을 암호화하면 프레젠테이션의 문서 속성도 기본적으로 암호 보호됩니다. 하지만 암호화 후에도 프레젠테이션 속성을 접근 가능하게 해야 하는 경우 Aspose.Slides에서 이를 정확히 수행할 수 있습니다.  

암호화된 프레젠테이션의 속성을 사용자가 계속 접근하도록 하려면 `EncryptDocumentProperties` 속성을 `True` 로 설정합니다. 다음 샘플 코드는 프레젠테이션을 암호화하면서 문서 속성에 대한 접근 권한을 제공하는 방법을 보여줍니다:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt_document_properties = True
    pres.protection_manager.encrypt("123123")
```

## **로드하기 전에 프레젠테이션이 암호 보호되었는지 확인하기**

프레젠테이션을 로드하기 전에 해당 프레젠테이션이 암호로 보호되지 않았는지 확인하고 싶을 수 있습니다. 이렇게 하면 암호가 없는 상태로 암호 보호된 프레젠테이션을 로드할 때 발생할 수 있는 오류와 유사한 문제를 피할 수 있습니다.  

다음 Python 코드는 프레젠테이션을 실제로 로드하지 않고도 암호로 보호되었는지 검사하는 방법을 보여줍니다:

```python
import aspose.slides as slides

presentationInfo = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print("The presentation is password protected: " + str(presentationInfo.is_password_protected))
```

## **프레젠테이션이 암호화되었는지 확인하기**

Aspose.Slides를 사용하면 프레젠테이션이 암호화되었는지 확인할 수 있습니다. 이를 수행하려면 `is_encrypted` 속성을 사용하면 되며, 프레젠테이션이 암호화된 경우 `True` 를, 그렇지 않은 경우 `False` 를 반환합니다.  

다음 샘플 코드는 프레젠테이션이 암호화되었는지 확인하는 방법을 보여줍니다:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    print(str(pres.protection_manager.is_encrypted))
```

## **프레젠테이션이 쓰기 보호되었는지 확인하기**

Aspose.Slides를 사용하면 프레젠테이션이 쓰기 보호되었는지 확인할 수 있습니다. 이를 수행하려면 `is_write_protected` 속성을 사용하면 되며, 프레젠테이션이 쓰기 보호된 경우 `True` 를, 그렇지 않은 경우 `False` 를 반환합니다.  

다음 샘플 코드는 프레젠테이션이 쓰기 보호되었는지 확인하는 방법을 보여줍니다:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    print(str(pres.protection_manager.is_write_protected))
```

## **특정 비밀번호가 프레젠테이션을 보호하는 데 사용되었는지 검증하기**

특정 비밀번호가 프레젠테이션 문서를 보호하는 데 사용되었는지 확인하고 싶을 수 있습니다. Aspose.Slides는 비밀번호를 검증할 수 있는 방법을 제공합니다.  

다음 샘플 코드는 비밀번호를 검증하는 방법을 보여줍니다:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    # "pass"와 일치하는지 확인
    matched = pres.protection_manager.check_write_protection("my_password")
    print(str(matched))
```

비밀번호가 지정된 경우 프레젠테이션이 해당 비밀번호로 암호화되었으면 `True` 를 반환하고, 그렇지 않으면 `False` 를 반환합니다.  

{{% alert color="primary" title="또 보기" %}} 
- [Digital Signature in PowerPoint](/slides/ko/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Aspose.Slides에서 지원하는 암호화 방법은 무엇인가요?**

Aspose.Slides는 AES 기반 알고리즘을 포함한 최신 암호화 방법을 지원하여 프레젠테이션 데이터의 높은 수준의 보안을 보장합니다.

**프레젠테이션을 열려고 할 때 잘못된 비밀번호를 입력하면 어떻게 되나요?**

잘못된 비밀번호가 사용되면 예외가 발생하여 프레젠테이션에 대한 접근이 거부되었음을 알립니다. 이는 무단 접근을 방지하고 콘텐츠를 보호하는 데 도움이 됩니다.

**암호로 보호된 프레젠테이션을 사용할 때 성능에 영향을 미치나요?**

암호화 및 복호화 과정으로 인해 열기 및 저장 작업 시 약간의 오버헤드가 발생할 수 있습니다. 대부분의 경우 이 성능 영향은 최소에 불과하며 전반적인 프레젠테이션 작업 처리 시간에 큰 영향을 주지 않습니다.