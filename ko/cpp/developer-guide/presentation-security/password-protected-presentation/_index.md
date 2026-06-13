---
title: C++에서 비밀번호로 프레젠테이션 보호
linktitle: 비밀번호 보호
type: docs
weight: 20
url: /ko/cpp/password-protected-presentation/
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
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 비밀번호로 보호된 PowerPoint 및 OpenDocument 프레젠테이션을 손쉽게 잠그고 해제하는 방법을 배우세요. 프레젠테이션을 안전하게 보호합니다."
---
## **Introduction**

프레젠테이션에 비밀번호를 설정하면 해당 프레젠테이션에 특정 제한을 적용하는 비밀번호를 설정하는 것입니다. 제한을 해제하려면 비밀번호를 입력해야 합니다. 비밀번호로 보호된 프레젠테이션은 잠긴 프레젠테이션으로 간주됩니다.

일반적으로, 프레젠테이션에 이러한 제한을 적용하기 위해 비밀번호를 설정할 수 있습니다:

- **Modification**

  특정 사용자만 프레젠테이션을 수정하도록 하려면 수정 제한을 설정할 수 있습니다. 이 제한은 비밀번호를 제공하지 않는 한 사용자가 프레젠테이션을 수정, 변경 또는 복사하는 것을 방지합니다.

  하지만 이 경우 비밀번호가 없더라도 사용자는 문서에 접근하여 열 수 있습니다. 읽기 전용 모드에서는 사용자가 프레젠테이션 내부의 내용(하이퍼링크, 애니메이션, 효과 등)을 볼 수 있지만 항목을 복사하거나 프레젠테이션을 저장할 수 없습니다.

- **Opening**

  특정 사용자만 프레젠테이션을 열도록 하려면 열기 제한을 설정할 수 있습니다. 이 제한은 비밀번호를 제공하지 않는 한 사용자가 프레젠테이션의 내용을 보는 것 자체를 방지합니다.

  기술적으로, 열기 제한은 사용자가 프레젠테이션을 수정하는 것도 방지합니다. 사용자가 프레젠테이션을 열 수 없으면 수정하거나 변경할 수 없습니다.

  **Note**: 열기를 방지하기 위해 프레젠테이션에 비밀번호를 설정하면 프레젠테이션 파일이 암호화됩니다.

## **How to Password Protect a Presentation Online**

1. 우리의 [**Aspose.Slides Lock**](https://products.aspose.app/slides/ko/lock) 페이지로 이동합니다. 

   ![todo:image_alt_text](slides-lock.png)

2. **파일을 끌어다 놓거나 업로드**를 클릭합니다.

3. 컴퓨터에서 비밀번호로 보호하려는 파일을 선택합니다. 

4. 편집 보호를 위한 원하는 비밀번호를 입력합니다; 보기 보호를 위한 원하는 비밀번호를 입력합니다. 

5. 사용자가 프레젠테이션을 최종 사본으로 보게 하려면 **Mark as final** 체크박스를 선택합니다.

6. **PROTECT NOW.**을 클릭합니다. 

7. **DOWNLOAD NOW.**을 클릭합니다.

## **Password Protection for Presentations in Aspose.Slides**
**Supported formats**

다음 형식의 프레젠테이션에 대해 Aspose.Slides는 비밀번호 보호, 암호화 및 유사한 작업을 지원합니다: 

- PPTX and PPT - Microsoft PowerPoint Presentation 
- ODP - OpenDocument Presentation 
- OTP -  OpenDocument Presentation Template 

**Supported operations**

Aspose.Slides를 사용하면 다음과 같은 방법으로 프레젠테이션에 비밀번호 보호를 적용하여 수정을 방지할 수 있습니다:

- Encrypting a presentation
- Setting a write protection to a presentation

**Other operations**

Aspose.Slides를 사용하면 다음과 같은 방법으로 비밀번호 보호 및 암호화와 관련된 기타 작업을 수행할 수 있습니다:

- Decrypting a presentation; opening an encrypted presentation
- Removing encryption; disabling password protection
- Removing write protection from a presentation
- Getting the properties of an encrypted presentation
- Checking whether a presentation is encrypted
- Checking whether a presentation is password protected.

## **Encrypt a Presentation**

비밀번호를 설정하여 프레젠테이션을 암호화할 수 있습니다. 그런 다음 잠긴 프레젠테이션을 수정하려면 사용자가 비밀번호를 제공해야 합니다.

프레젠테이션을 암호화하거나 비밀번호로 보호하려면 [ProtectionManager](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.protection_manager) 의 encrypt 메서드를 사용하여 프레젠테이션에 비밀번호를 설정해야 합니다. 비밀번호를 encrypt 메서드에 전달하고 save 메서드를 사용하여 이제 암호화된 프레젠테이션을 저장합니다.

다음 샘플 코드는 프레젠테이션을 암호화하는 방법을 보여줍니다:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **Set Write Protection to a Presentation** 

프레젠테이션에 “Do not modify”(수정 금지) 표시를 추가할 수 있습니다. 이렇게 하면 사용자가 프레젠테이션을 변경하지 않도록 알릴 수 있습니다.  

**Note**: 쓰기 보호 과정은 프레젠테이션을 암호화하지 않습니다. 따라서 사용자는 원한다면 프레젠테이션을 수정할 수 있지만, 변경 사항을 저장하려면 다른 이름으로 프레젠테이션을 만들어야 합니다. 

쓰기 보호를 설정하려면 setWriteProtection 메서드를 사용해야 합니다. 다음 샘플 코드는 프레젠테이션에 쓰기 보호를 설정하는 방법을 보여줍니다:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"123123");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **Load an Encrypted Presentation**

Aspose.Slides를 사용하면 암호와 함께 암호화된 파일을 로드할 수 있습니다. 프레젠테이션을 복호화하려면 매개변수 없이 [RemoveEncryption](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) 메서드를 호출해야 합니다. 그런 다음 올바른 비밀번호를 입력하여 프레젠테이션을 로드합니다. 

다음 샘플 코드는 프레젠테이션을 복호화하는 방법을 보여줍니다: 

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

// 복호화된 프레젠테이션 작업
```

## **Remove Encryption from a Presentation**

프레젠테이션의 암호화 또는 비밀번호 보호를 제거할 수 있습니다. 이렇게 하면 사용자는 제한 없이 프레젠테이션에 접근하거나 수정할 수 있게 됩니다. 

암호화 또는 비밀번호 보호를 제거하려면 [RemoveEncryption](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) 메서드를 호출해야 합니다. 다음 샘플 코드는 프레젠테이션에서 암호화를 제거하는 방법을 보여줍니다:

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **Remove Write Protection from a Presentation**

Aspose.Slides를 사용하여 프레젠테이션 파일에 적용된 쓰기 보호를 제거할 수 있습니다. 이렇게 하면 사용자는 원하는 대로 수정할 수 있으며, 이러한 작업을 수행할 때 경고가 표시되지 않습니다.

[RemoveWriteProtection](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.protection_manager#a9f9e6de5983965157dac0f270a0a9e50) 메서드를 사용하여 프레젠테이션에서 쓰기 보호를 제거할 수 있습니다. 다음 샘플 코드는 프레젠테이션에서 쓰기 보호를 제거하는 방법을 보여줍니다:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **Get the Properties of an Encrypted Presentation**

일반적으로 사용자는 암호화되거나 비밀번호로 보호된 프레젠테이션의 문서 속성을 가져오는 데 어려움을 겪습니다. 그러나 Aspose.Slides는 프레젠테이션을 비밀번호로 보호하면서도 사용자가 해당 프레젠테이션의 속성에 접근할 수 있는 방법을 제공합니다.

**Note**: Aspose.Slides가 프레젠테이션을 암호화하면 기본적으로 프레젠테이션의 문서 속성도 비밀번호로 보호됩니다. 그러나 암호화된 후에도 프레젠테이션 속성에 접근할 수 있도록 하려면 Aspose.Slides를 사용해 정확히 그렇게 할 수 있습니다. 

암호화된 프레젠테이션의 속성에 접근할 수 있는 기능을 사용자가 유지하도록 하려면 [set_EncryptDocumentProperties()](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.protection_manager#a67e041b432552969d106f72fa7fe5a1d) 메서드에 `true`를 전달하면 됩니다. 다음 샘플 코드는 사용자가 문서 속성에 접근할 수 있도록 하면서 프레젠테이션을 암호화하는 방법을 보여줍니다:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->set_EncryptDocumentProperties(true);
presentation->get_ProtectionManager()->Encrypt(u"123123");
```

## **Check Whether a Presentation Is Password Protected**

프레젠테이션을 로드하기 전에 해당 프레젠테이션이 비밀번호로 보호되지 않았는지 확인하고 싶을 수 있습니다. 이렇게 하면 비밀번호가 없는 상태로 비밀번호 보호된 프레젠테이션을 로드할 때 발생하는 오류와 유사한 문제를 피할 수 있습니다.

다음 C++ 코드는 프레젠테이션을 로드하지 않고도 비밀번호로 보호되었는지 확인하는 방법을 보여줍니다:

```c++
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"example.pptx");
System::Console::WriteLine(System::String(u"The presentation is password protected: ") +
                           presentationInfo->get_IsPasswordProtected());
```

## **Check Whether a Presentation Is Encrypted**

Aspose.Slides를 사용하면 프레젠테이션이 암호화되었는지 확인할 수 있습니다. 이를 위해 [get_IsEncrypted()](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.protection_manager#ad88b984e44b378f335317ded49b34e68) 메서드를 사용할 수 있으며, 프레젠테이션이 암호화된 경우 `true`, 암호화되지 않은 경우 `false`를 반환합니다. 

다음 샘플 코드는 프레젠테이션이 암호화되었는지 확인하는 방법을 보여줍니다:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
```

## **Check Whether a Presentation Is Write Protected**

Aspose.Slides를 사용하면 프레젠테이션이 쓰기 보호된 상태인지 확인할 수 있습니다. 이를 위해 [get_IsWriteProtected()](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.protection_manager#a0b4a82c0f7b3a32ca5762c5fcc8844a2) 메서드를 사용할 수 있으며, 프레젠테이션이 쓰기 보호된 경우 `true`, 그렇지 않은 경우 `false`를 반환합니다. 

다음 샘플 코드는 프레젠테이션이 쓰기 보호된 상태인지 확인하는 방법을 보여줍니다:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsWriteProtected();
```

## **Verify Presentation Password Usage**

특정 비밀번호가 프레젠테이션 문서를 보호하는 데 사용되었는지 확인하고 싶을 수 있습니다. Aspose.Slides는 비밀번호를 검증할 수 있는 방법을 제공합니다. 

다음 샘플 코드는 비밀번호를 검증하는 방법을 보여줍니다:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

// 패스워드가 일치하는지 확인
bool isWriteProtected = pres->get_ProtectionManager()->CheckWriteProtection(u"my_password");
```

지정된 비밀번호로 프레젠테이션이 암호화된 경우 `true`를 반환합니다. 그렇지 않으면 `false`를 반환합니다.

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/ko/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Aspose.Slides에서 지원하는 암호화 방식은 무엇인가요?**

Aspose.Slides는 AES 기반 알고리즘을 포함한 최신 암호화 방식을 지원하여 프레젠테이션 데이터 보안을 높은 수준으로 보장합니다.

**프레젠테이션을 열 때 잘못된 비밀번호를 입력하면 어떻게 되나요?**

잘못된 비밀번호를 사용하면 예외가 발생하여 프레젠테이션 접근이 거부되었음을 알립니다. 이는 무단 접근을 방지하고 프레젠테이션 내용을 보호하는 데 도움이 됩니다.

**비밀번호로 보호된 프레젠테이션을 사용할 때 성능에 영향을 미치나요?**

암호화 및 복호화 과정은 열기와 저장 작업 시 약간의 오버헤드를 발생시킬 수 있습니다. 대부분의 경우 이 성능 영향은 최소 수준이며 프레젠테이션 작업 전반의 처리 시간에 큰 영향을 주지는 않습니다.