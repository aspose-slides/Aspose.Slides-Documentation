---
title: ".NET에서 프레젠테이션 쓰기 보호"
linktitle: "쓰기 보호"
type: docs
weight: 25
url: /ko/net/write-protected-presentation/
keywords:
- "쓰기 보호"
- "PowerPoint 쓰기 보호"
- "수정 비밀번호"
- "프레젠테이션 편집 제한"
- "쓰기 보호 제거"
- "수정 비밀번호 검증"
- "PowerPoint"
- "프레젠테이션"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET을 사용하여 PowerPoint PPT 및 PPTX 프레젠테이션에서 쓰기 보호 비밀번호를 설정, 감지, 검증 및 제거합니다."
---
## **소개**

쓰기 보호 비밀번호는 프레젠테이션의 수정을 제한하지만 내용을 암호화하지는 않습니다. 사용자는 비밀번호 없이도 쓰기 보호된 프레젠테이션을 로드하고 볼 수 있습니다. 애플리케이션에 따라 콘텐츠를 편집하고 다른 이름으로 저장할 수도 있으므로, 쓰기 보호를 기밀성 메커니즘으로 간주해서는 안 됩니다.

열기 비밀번호는 다른 목적을 가집니다: 프레젠테이션을 암호화하며 내용을 로드하려면 필요합니다. 프레젠테이션을 암호화하거나 열기 비밀번호를 검증하려면 [프레젠테이션 암호 보호](/slides/ko/net/password-protected-presentation/)를 참조하십시오.

이 문서의 워크플로는 PPT와 PPTX 프레젠테이션 모두에 적용됩니다. 예제는 PPTX 파일을 사용합니다; PPT로 저장할 때는 `.ppt` 확장자를 사용하고 해당 PPT 저장 형식을 사용하십시오.

## **프레젠테이션에 쓰기 보호 설정**

프레젠테이션 수정용 비밀번호를 할당하려면 [IProtectionManager.SetWriteProtection](https://reference.aspose.com/slides/ko/net/aspose.slides/iprotectionmanager/setwriteprotection/)을 사용하십시오. 프레젠테이션을 저장하면 보호 설정이 유지됩니다.

다음 예제는 PPTX 프레젠테이션에 쓰기 보호를 설정합니다:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.SetWriteProtection("modify_password");
presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
```

## **쓰기 보호된 프레젠테이션 로드**

쓰기 보호는 프레젠테이션 내용을 암호화하지 않으므로 프레젠테이션을 로드할 때 비밀번호가 필요하지 않습니다. 비밀번호는 보호된 프레젠테이션을 수정할 수 있는 권한을 검증할 때만 관련됩니다.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("write-protected-pres.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

[LoadOptions.Password](https://reference.aspose.com/slides/ko/net/aspose.slides/loadoptions/password/)에 쓰기 보호 비밀번호를 전달하지 마십시오. 해당 속성은 암호화된 내용에 대한 열기 비밀번호를 받습니다. 프레젠테이션에 두 종류의 보호가 모두 있는 경우, 열기 비밀번호를 제공해 로드하고 쓰기 보호 비밀번호는 별도로 처리하십시오.

## **프레젠테이션에서 쓰기 보호 제거**

수정 제한을 제거하려면 [IProtectionManager.RemoveWriteProtection](https://reference.aspose.com/slides/ko/net/aspose.slides/iprotectionmanager/removewriteprotection/)을 사용하고, 그 다음 프레젠테이션을 저장하십시오.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("write-protected-pres.pptx");

presentation.ProtectionManager.RemoveWriteProtection();
presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
```

## **프레젠테이션이 쓰기 보호되었는지 확인**

전체 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 인스턴스를 만들지 않고 파일을 검사하려면 [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/ko/net/aspose.slides/ipresentationfactory/getpresentationinfo/)를 호출하고 [IPresentationInfo.IsWriteProtected](https://reference.aspose.com/slides/ko/net/aspose.slides/ipresentationinfo/iswriteprotected/)를 확인하십시오. 이 속성은 [NullableBool](https://reference.aspose.com/slides/ko/net/aspose.slides/nullablebool/)을 사용하며 쓰기 보호가 감지되면 `NullableBool.True`를 반환합니다.

```csharp
using System;
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.IsWriteProtected == NullableBool.True)
{
    Console.WriteLine("The presentation is write protected.");
}
else
{
    Console.WriteLine("Write protection was not detected.");
}
```

[IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/ko/net/aspose.slides/ipresentationfactory/getpresentationinfo/)의 스트림 오버로드는 스트림으로 제공된 프레젠테이션에 대해서도 동일한 정보를 제공합니다.

## **쓰기 보호 비밀번호 검증**

전체 프레젠테이션을 로드하지 않고 수정 비밀번호를 검증하려면 [IPresentationInfo.CheckWriteProtection](https://reference.aspose.com/slides/ko/net/aspose.slides/ipresentationinfo/checkwriteprotection/)를 사용하십시오. 먼저 [IPresentationInfo.IsWriteProtected](https://reference.aspose.com/slides/ko/net/aspose.slides/ipresentationinfo/iswriteprotected/)를 확인하여 쓰기 보호가 있는 경우에만 애플리케이션이 비밀번호를 요청하거나 검증하도록 합니다.

```csharp
using System;
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.IsWriteProtected != NullableBool.True)
{
    Console.WriteLine("The presentation is not write protected.");
}
else if (presentationInfo.CheckWriteProtection("modify_password"))
{
    Console.WriteLine("The write-protection password is correct.");
}
else
{
    Console.WriteLine("The write-protection password is incorrect.");
}
```

[IPresentationInfo.CheckWriteProtection](https://reference.aspose.com/slides/ko/net/aspose.slides/ipresentationinfo/checkwriteprotection/)은 쓰기 보호 비밀번호만 검증합니다. 열기 비밀번호를 검증하거나 암호화된 콘텐츠를 로드할 수 있는지는 확인하지 않습니다. 반대로, [IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/ko/net/aspose.slides/ipresentationinfo/checkpassword/)은 열기 비밀번호만 검증합니다. 전체 프레젠테이션이 이미 로드된 경우, [IProtectionManager.CheckWriteProtection](https://reference.aspose.com/slides/ko/net/aspose.slides/iprotectionmanager/checkwriteprotection/)은 보호 관리자를 통해 동일한 쓰기 보호 검증을 제공합니다.

운영 환경에서는 비밀번호를 로그에 기록하거나 진단 메시지에 포함시키지 마십시오. 불필요한 반복 검증을 피하고, 비밀번호는 필요한 기간 동안만 메모리에 보관하십시오.

{{% alert color="info" title="See also" %}}
- [프레젠테이션 암호 보호](/slides/ko/net/password-protected-presentation/)
- [읽기 전용 프레젠테이션](/slides/ko/net/read-only-presentation/)
- [PowerPoint 디지털 서명](/slides/ko/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**쓰기 보호가 프레젠테이션을 암호화합니까?**

아니오. 수정은 제한하지만 프레젠테이션 내용은 로드 및 보기 위해 그대로 남아 있습니다.

**프레젠테이션을 열 때 쓰기 보호 비밀번호가 필요합니까?**

아니오. 암호화된 프레젠테이션 내용을 로드하려면 열기 비밀번호만 필요합니다.

**프레젠테이션에 열기 비밀번호와 쓰기 보호 비밀번호를 모두 설정할 수 있습니까?**

예. 로드 옵션을 통해 열기 비밀번호를 제공하여 암호화된 프레젠테이션을 열고, 수정 권한이 필요할 때 쓰기 보호 비밀번호를 별도로 검증하십시오.