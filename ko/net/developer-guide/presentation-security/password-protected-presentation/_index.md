---
title: ".NET에서 프레젠테이션 비밀번호 보호"
linktitle: "비밀번호 보호"
type: docs
weight: 20
url: /ko/net/password-protected-presentation/
keywords:
- "비밀번호 보호 프레젠테이션"
- "오프닝 비밀번호"
- "PowerPoint 암호화"
- "PowerPoint 복호화"
- "프레젠테이션 비밀번호 검증"
- "프레젠테이션 비밀번호 확인"
- "암호화된 프레젠테이션 열기"
- "암호화 제거"
- "PowerPoint"
- "PPT"
- "PPTX"
- "프레젠테이션"
- ".NET"
- "C#"
- "Aspose.Slides"
description: ".NET용 Aspose.Slides와 C#를 사용하여 비밀번호 보호된 PowerPoint PPT 및 PPTX 프레젠테이션을 암호화하고, 감지하고, 검증하고, 열고, 복호화합니다."
---
## **개요**

오프닝 비밀번호는 프레젠테이션을 암호화합니다. 올바른 비밀번호가 있어야 프레젠테이션 내용을 로드하고 볼 수 있으므로 이 보호는 기밀성을 제공합니다.

오프닝 비밀번호는 쓰기 보호 비밀번호와 다릅니다. 쓰기 보호는 수정 제한만 할 뿐 내용을 암호화하거나 프레젠테이션 로드를 방지하지 않습니다. 프레젠테이션 수정용 비밀번호를 관리하려면 [프레젠테이션 쓰기 보호](/slides/ko/net/write-protected-presentation/)를 참조하세요.

아래 워크플로는 PPT와 PPTX 프레젠테이션 모두에 적용됩니다. 예제에서는 파일 기반 및 스트림 기반 동작이 중요한 경우 두 형식을 모두 사용합니다.

## **오프닝 비밀번호로 프레젠테이션 암호화**

[IProtectionManager.Encrypt](https://reference.aspose.com/slides/ko/net/aspose.slides/iprotectionmanager/encrypt/)을 사용해 오프닝 비밀번호를 지정합니다. 그런 다음 [IPresentation.Save](https://reference.aspose.com/slides/ko/net/aspose.slides/ipresentation/save/)을 사용해 암호화된 프레젠테이션을 저장합니다.

다음 예제는 PPTX 프레젠테이션을 암호화합니다:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.Encrypt("open_password");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **암호화된 프레젠테이션 로드**

[LoadOptions.Password](https://reference.aspose.com/slides/ko/net/aspose.slides/loadoptions/password/)에 오프닝 비밀번호를 설정하고 파일 로드 시 옵션을 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/)에 전달합니다. 오프닝 비밀번호가 필요하지만 제공된 비밀번호가 없거나 틀린 경우 로드에 실패합니다.

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

// 복호화된 프레젠테이션으로 작업합니다.
```

## **프레젠테이션 암호 해제**

오프닝 비밀번호로 프레젠테이션을 로드한 뒤 [IProtectionManager.RemoveEncryption](https://reference.aspose.com/slides/ko/net/aspose.slides/iprotectionmanager/removeencryption/)을 호출하고 결과를 저장합니다. 저장된 프레젠테이션은 이제 비밀번호 없이 로드할 수 있습니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

presentation.ProtectionManager.RemoveEncryption();
presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
```

## **로드 전에 오프닝 비밀번호 검증**

[IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/ko/net/aspose.slides/ipresentationfactory/getpresentationinfo/)를 사용해 전체 프레젠테이션 인스턴스를 만들지 않고 [IPresentationInfo](https://reference.aspose.com/slides/ko/net/aspose.slides/ipresentationinfo/)를 가져옵니다. 비밀번호가 필요한지 확인하려면 [IPresentationInfo.IsPasswordProtected](https://reference.aspose.com/slides/ko/net/aspose.slides/ipresentationinfo/ispasswordprotected/)를 확인하세요. 보호가 존재하면 [IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/ko/net/aspose.slides/ipresentationinfo/checkpassword/)로 제공된 값을 검증합니다.

### **파일 경로 워크플로**

다음 예제는 PPTX 파일에 대한 오프닝 비밀번호를 검증하고 검증된 값을 [LoadOptions.Password](https://reference.aspose.com/slides/ko/net/aspose.slides/loadoptions/password/)에 전달한 뒤 전체 프레젠테이션을 로드합니다:

```csharp
using System;
using Aspose.Slides;

var filePath = "protected-presentation.pptx";
var password = "open_password";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(filePath);

if (!presentationInfo.IsPasswordProtected)
{
    Console.WriteLine("The presentation does not have an opening password.");
}
else if (!presentationInfo.CheckPassword(password))
{
    Console.WriteLine("The opening password is incorrect.");
}
else
{
    var loadOptions = new LoadOptions { Password = password };
    using var presentation = new Presentation(filePath, loadOptions);

    Console.WriteLine("The presentation was validated and loaded successfully.");
}
```

### **스트림 워크플로**

[IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/ko/net/aspose.slides/ipresentationfactory/getpresentationinfo/)의 스트림 오버로드도 동일한 워크플로를 제공합니다. 스트림에서 전체 프레젠테이션을 로드하기 전에 위치를 재설정하십시오.

다음 예제는 PPT 파일을 사용합니다:

```csharp
using System;
using System.IO;
using Aspose.Slides;

var password = "open_password";
using var presentationStream = File.OpenRead("protected-presentation.ppt");
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(presentationStream);

if (!presentationInfo.IsPasswordProtected)
{
    Console.WriteLine("The presentation does not have an opening password.");
}
else if (!presentationInfo.CheckPassword(password))
{
    Console.WriteLine("The opening password is incorrect.");
}
else
{
    presentationStream.Position = 0;

    var loadOptions = new LoadOptions { Password = password };
    using var presentation = new Presentation(presentationStream, loadOptions);

    Console.WriteLine("The presentation was validated and loaded successfully.");
}
```

### **CheckPassword 반환 값**

[IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/ko/net/aspose.slides/ipresentationinfo/checkpassword/)은 프레젠테이션에 오프닝 비밀번호가 있고 제공된 비밀번호가 올바른 경우에만 `true`를 반환합니다. 다음 경우에는 `false`를 반환합니다:

- 비밀번호가 올바르지 않은 경우.
- 프레젠테이션에 오프닝 비밀번호가 없는 경우.
- 제공된 비밀번호가 `null`이거나 비어 있는 경우.

동작은 PPT와 PPTX 프레젠테이션 모두에서 동일합니다.

## **로드된 프레젠테이션이 암호화되었는지 확인**

올바른 비밀번호로 프레젠테이션을 로드한 후 [IProtectionManager.IsEncrypted](https://reference.aspose.com/slides/ko/net/aspose.slides/iprotectionmanager/isencrypted/)을 확인해 원본 프레젠테이션이 암호화되었는지 확인합니다. 로드 전에 오프닝 비밀번호 보호를 감지하려면 위에서 소개한 `IPresentationInfo.IsPasswordProtected`를 사용하세요.

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

var isEncrypted = presentation.ProtectionManager.IsEncrypted;
Console.WriteLine("The presentation is encrypted: " + isEncrypted);
```

## **보안 권장 사항**

{{% alert color="warning" title="보안" %}}
오프닝 비밀번호를 로그에 기록하거나 진단 메시지에 포함하지 마세요. 불필요한 반복 검증을 피하고 비밀번호는 필요한 기간 동안만 메모리에 보관하며, 즉시 프레젠테이션을 로드할 경우 성공적인 검증 결과를 재사용하세요.
{{% /alert %}}

## **온라인에서 프레젠테이션 비밀번호 보호**

1. [Aspose.Slides Lock](https://products.aspose.app/slides/ko/lock) 애플리케이션을 엽니다.
2. 프레젠테이션을 선택하거나 업로드합니다.
3. 보기 보호용 비밀번호를 입력합니다.
4. 필요에 따라 편집 보호용 별도 비밀번호를 입력합니다.
5. 보호를 적용하고 결과 파일을 다운로드합니다.

{{% alert color="info" title="참고" %}}
- [프레젠테이션 쓰기 보호](/slides/ko/net/write-protected-presentation/)
- [PowerPoint 디지털 서명](/slides/ko/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**오프닝 비밀번호와 쓰기 보호 비밀번호의 차이는 무엇인가요?**

오프닝 비밀번호는 프레젠테이션을 암호화하고 내용을 로드하려면 필요합니다. 쓰기 보호 비밀번호는 내용을 암호화하지 않고 수정만 제한합니다.

**전체 슬라이드를 로드하지 않고 오프닝 비밀번호를 검증할 수 있나요?**

예. 프레젠테이션 정보를 얻어 오프닝 비밀번호 보호가 존재하는지 확인하고, 전체 프레젠테이션 인스턴스를 만들기 전에 비밀번호를 검증합니다.

**비밀번호 검증 워크플로는 PPT와 PPTX 모두 지원하나요?**

예. 파일 경로와 스트림 기반 비밀번호 감지 및 검증은 PPT와 PPTX 프레젠테이션에서 동일하게 동작합니다.