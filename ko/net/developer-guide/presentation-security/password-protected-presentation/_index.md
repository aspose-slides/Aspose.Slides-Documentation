---
title: .NET에서 비밀번호로 프레젠테이션 보호하기
linktitle: 비밀번호 보호
type: docs
weight: 20
url: /ko/net/password-protected-presentation/
keywords:
- PowerPoint 잠그기
- 프레젠테이션 잠그기
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET를 사용하여 비밀번호로 보호된 PowerPoint 및 OpenDocument 프레젠테이션을 손쉽게 잠그고 풀 수 있는 방법을 알아보세요. 프레젠테이션을 안전하게 보호하세요."
---
## **소개**

프레젠테이션에 비밀번호를 설정하면 해당 비밀번호가 프레젠테이션에 대한 특정 제한을 적용합니다. 이러한 제한을 해제하려면 비밀번호를 입력해야 합니다. 비밀번호가 보호된 프레젠테이션은 잠긴 프레젠테이션으로 간주됩니다.

일반적으로 프레젠테이션에 제한을 적용하기 위해 비밀번호를 설정할 수 있습니다:

- **수정**

특정 사용자만 프레젠테이션을 수정하도록 하려면 수정 제한을 설정할 수 있습니다. 이 제한은 비밀번호를 제공하지 않으면 사용자가 프레젠테이션의 요소를 수정, 변경 또는 복사하는 것을 방지합니다.  

하지만 비밀번호가 없더라도 사용자는 문서를 열어볼 수 있습니다. 이 읽기 전용 모드에서는 사용자가 프레젠테이션 내용(하이퍼링크, 애니메이션, 효과 및 기타 요소 포함)을 볼 수 있지만 항목을 복사하거나 프레젠테이션을 저장할 수 없습니다.

- **열기**

특정 사용자만 프레젠테이션을 열도록 하려면 열기 제한을 설정할 수 있습니다. 이 제한은 비밀번호를 제공하지 않으면 사용자가 프레젠테이션 내용을 볼 수 없게 합니다.  

기술적으로 열기 제한은 사용자가 프레젠테이션을 열 수 없게 하면 수정도 할 수 없게 만들기 때문에 수정 제한을 동시에 적용하는 효과가 있습니다.

**Note:** 열기를 방지하기 위해 프레젠테이션을 비밀번호로 보호하면 파일이 암호화됩니다.

## **Aspose.Slides의 비밀번호 보호**

**지원 형식**

Aspose.Slides는 다음 형식의 프레젠테이션에 대해 비밀번호 보호, 암호화 및 유사한 작업을 지원합니다:

- PPTX 및 PPT – Microsoft PowerPoint 프레젠테이션
- ODP – OpenDocument 프레젠테이션
- OTP – OpenDocument 프레젠테이션 템플릿

**지원 작업**

Aspose.Slides를 사용하면 다음과 같은 방법으로 프레젠테이션 수정 방지를 위해 비밀번호 보호를 적용할 수 있습니다:

- 프레젠테이션 암호화
- 프레젠테이션에 쓰기 보호 적용

**기타 작업**

Aspose.Slides는 비밀번호 보호 및 암호화와 관련된 추가 작업을 다음과 같이 수행할 수 있도록 합니다:

- 프레젠테이션 복호화; 암호화된 프레젠테이션 열기
- 암호화 제거; 비밀번호 보호 비활성화
- 프레젠테이션의 쓰기 보호 제거
- 암호화된 프레젠테이션의 속성 가져오기
- 로드하기 전에 프레젠테이션이 비밀번호로 보호되었는지 확인
- 프레젠테이션이 암호화되었는지 확인
- 프레젠테이션이 비밀번호로 보호되었는지 확인

## **비밀번호로 프레젠테이션 보호**

프레젠테이션에 비밀번호를 설정하면 암호화할 수 있습니다. 그런 다음 잠긴 프레젠테이션을 수정하려면 사용자가 비밀번호를 제공해야 합니다.

프레젠테이션을 암호화(또는 비밀번호 보호)하려면 [ProtectionManager](https://reference.aspose.com/slides/ko/net/aspose.slides/protectionmanager)의 `Encrypt` 메서드를 사용하여 비밀번호를 설정합니다. 비밀번호를 `Encrypt` 메서드에 전달한 후 `Save` 메서드를 사용해 이제 암호화된 프레젠테이션을 저장합니다.

다음 샘플 코드는 프레젠테이션을 암호화하는 방법을 보여줍니다:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.Encrypt("123123");
    presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
}
```

## **프레젠테이션에 쓰기 보호 설정** 

프레젠테이션에 “Do not modify”(수정 금지) 표시를 추가할 수 있습니다. 이는 사용자에게 프레젠테이션을 변경하지 말라는 의도를 전달합니다.

**Note:** 쓰기 보호 과정은 프레젠테이션을 암호화하지 않습니다. 따라서 사용자는 원하는 경우 프레젠테이션을 수정할 수 있지만, 변경 사항을 저장하려면 다른 이름으로 저장해야 합니다.

쓰기 보호를 설정하려면 `SetWriteProtection` 메서드를 사용합니다. 다음 샘플 코드는 프레젠테이션에 쓰기 보호를 설정하는 방법을 보여줍니다:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.SetWriteProtection("123123");
    presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
}
```

## **암호화된 프레젠테이션 로드**

Aspose.Slides를 사용하면 올바른 비밀번호를 전달하여 암호화된 프레젠테이션을 로드할 수 있습니다. 다음 샘플 코드는 암호화된 프레젠테이션을 로드하는 방법을 보여줍니다:

```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    // 복호화된 프레젠테이션으로 작업합니다.
}
```

## **프레젠테이션에서 암호화 제거**

프레젠테이션에서 암호화 또는 비밀번호 보호를 제거하면 사용자가 제한 없이 접근하거나 수정할 수 있습니다.

암호화 또는 비밀번호 보호를 제거하려면 [RemoveEncryption](https://reference.aspose.com/slides/ko/net/aspose.slides/protectionmanager/methods/removeencryption) 메서드를 호출합니다. 다음 샘플 코드는 프레젠테이션에서 암호화를 제거하는 방법을 보여줍니다:

```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    presentation.ProtectionManager.RemoveEncryption();
    presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
}
```

## **프레젠테이션의 쓰기 보호 제거**

Aspose.Slides를 사용하면 프레젠테이션 파일의 쓰기 보호를 제거할 수 있습니다. 이렇게 하면 사용자가 원하는 대로 수정할 수 있으며, 해당 작업을 수행할 때 경고가 표시되지 않습니다.

쓰기 보호를 제거하려면 [RemoveWriteProtection](https://reference.aspose.com/slides/ko/net/aspose.slides/protectionmanager/methods/removewriteprotection) 메서드를 사용합니다. 다음 샘플 코드는 프레젠테이션에서 쓰기 보호를 제거하는 방법을 보여줍니다:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.RemoveWriteProtection();
    presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
}
```

## **암호화된 프레젠테이션 속성 가져오기**

일반적으로 사용자는 암호화되거나 비밀번호로 보호된 프레젠테이션의 문서 속성을 가져오기가 어렵습니다. 그러나 Aspose.Slides는 프레젠테이션을 비밀번호로 보호하면서도 사용자가 속성에 접근할 수 있는 메커니즘을 제공합니다.

**Note:** 기본적으로 Aspose.Slides가 프레젠테이션을 암호화하면 문서 속성도 비밀번호로 보호됩니다. 암호화 후에도 문서 속성에 접근하도록 하려면 Aspose.Slides에서 해당 기능을 지원합니다.

사용자가 암호화된 프레젠테이션의 속성에 계속 접근하도록 하려면 [EncryptDocumentProperties](https://reference.aspose.com/slides/ko/net/aspose.slides/protectionmanager/properties/encryptdocumentproperties) 속성을 `true` 로 설정하면 됩니다. 다음 샘플 코드는 프레젠테이션을 암호화하면서도 문서 속성에 접근하도록 하는 방법을 보여줍니다:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.EncryptDocumentProperties = true;
    presentation.ProtectionManager.Encrypt("123123");
}
```

## **프레젠테이션이 비밀번호로 보호되었는지 확인**

프레젠테이션을 로드하기 전에 해당 파일이 비밀번호로 보호되지 않았는지 확인하고 싶을 수 있습니다. 이렇게 하면 올바른 비밀번호 없이 비밀번호 보호된 프레젠테이션을 로드할 때 발생할 수 있는 오류 등을 방지할 수 있습니다.

다음 C# 코드는 실제로 로드하지 않고도 프레젠테이션이 비밀번호 보호된 상태인지 검사하는 방법을 보여줍니다:

```c#
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("example.pptx");
Console.WriteLine("The presentation is password protected: " + presentationInfo.IsPasswordProtected);
```

## **프레젠테이션이 암호화되었는지 확인**

Aspose.Slides를 사용하면 프레젠테이션이 암호화되었는지 확인할 수 있습니다. 이를 위해 [IsEncrypted](https://reference.aspose.com/slides/ko/net/aspose.slides/protectionmanager/properties/isencrypted) 속성을 사용하면 되며, 프레젠테이션이 암호화된 경우 `true`, 그렇지 않은 경우 `false` 를 반환합니다.

다음 샘플 코드는 프레젠테이션이 암호화되었는지 확인하는 방법을 보여줍니다:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsEncrypted;
}
```

## **프레젠테이션이 쓰기 보호된 상태인지 확인**

Aspose.Slides를 사용하면 프레젠테이션이 쓰기 보호되었는지 확인할 수 있습니다. 이를 위해 [IsWriteProtected](https://reference.aspose.com/slides/ko/net/aspose.slides/protectionmanager/properties/iswriteprotected) 속성을 사용하면 되며, 쓰기 보호된 경우 `true`, 그렇지 않은 경우 `false` 를 반환합니다.

다음 샘플 코드는 프레젠테이션이 쓰기 보호된 상태인지 확인하는 방법을 보여줍니다:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsWriteProtected;
}
```

## **프레젠테이션 비밀번호 사용 여부 확인**

특정 비밀번호가 프레젠테이션 문서를 보호하는 데 사용되었는지 확인하고 싶을 수 있습니다. Aspose.Slides는 비밀번호를 검증할 수 있는 방법을 제공합니다.

다음 샘플 코드는 비밀번호를 검증하는 방법을 보여줍니다:

```c#
using (IPresentation presentation = new Presentation("pres.pptx"))
{
    // 비밀번호가 일치하는지 확인합니다.
    bool isWriteProtected = presentation.ProtectionManager.CheckWriteProtection("my_password");
}
```

비밀번호가 일치하면 `true` 를 반환하고, 그렇지 않으면 `false` 를 반환합니다.

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/ko/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **온라인에서 프레젠테이션 비밀번호 보호**

1. 우리의 [**Aspose.Slides Lock**](https://products.aspose.app/slides/ko/lock) 페이지로 이동합니다. 
2. **Drop or upload your files** 를 클릭합니다.
3. 컴퓨터에서 비밀번호로 보호할 파일을 선택합니다. 
4. 편집 보호용 비밀번호와 보기 보호용 비밀번호를 입력합니다.
5. 프레젠테이션을 최종 사본으로 표시하려면 **Mark as final** 체크박스를 선택합니다.
6. **PROTECT NOW.** 를 클릭합니다. 
7. **DOWNLOAD NOW.** 를 클릭합니다.

![Password protect PowerPoint presentations](slides-lock.png)

## **FAQ**

**Aspose.Slides에서 지원하는 암호화 방법은 무엇인가요?**

Aspose.Slides는 AES 기반 알고리즘을 포함한 최신 암호화 방식을 지원하여 프레젠테이션 데이터 보안을 높은 수준으로 유지합니다.

**프레젠테이션을 열 때 잘못된 비밀번호를 입력하면 어떻게 되나요?**

잘못된 비밀번호가 사용되면 예외가 발생하여 프레젠테이션 접근이 거부됩니다. 이는 무단 접근을 방지하고 내용 보호에 도움이 됩니다.

**비밀번호로 보호된 프레젠테이션을 다룰 때 성능에 영향을 미치나요?**

암호화 및 복호화 과정으로 인해 열기와 저장 작업 시 약간의 오버헤드가 발생할 수 있습니다. 대부분의 경우 이 성능 영향은 최소이며 프레젠테이션 작업 전체 처리 시간에 큰 영향을 주지 않습니다.