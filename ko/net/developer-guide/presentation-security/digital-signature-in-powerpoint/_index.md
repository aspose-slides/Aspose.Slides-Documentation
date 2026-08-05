---
title: ".NET에서 프레젠테이션에 디지털 서명 추가"
linktitle: "디지털 서명"
type: docs
weight: 10
url: /ko/net/digital-signature-in-powerpoint/
keywords:
- 디지털 서명
- 디지털 인증서
- 인증 기관
- PFX 인증서
- PKCS#12
- 서명 검증
- PowerPoint
- PPTX
- 프레젠테이션 보안
- .NET
- C#
- Aspose.Slides
description: "PFX 인증서를 사용하여 기존 PPTX 프레젠테이션에 서명하고, Aspose.Slides for .NET을 이용해 디지털 서명을 검증하거나 제거하는 방법을 배웁니다."
---
## **개요**

디지털 서명은 수신자가 프레젠테이션에 누가 서명했는지와 서명된 내용이 변경되었는지를 판단하도록 도와줍니다. 여기서는 다음 세 가지 보안 개념이 중요합니다:

- **디지털 인증서**는 신원을 공개 키와 연결하는 전자 자격 증명입니다. 신뢰할 수 있는 인증 기관(CA)이 인증서를 발급할 수 있으며, 조직은 내부 워크플로에 자체 서명 인증서를 사용할 수 있습니다.
- **디지털 서명**은 프레젠테이션 내용과 인증서 소유자의 개인 키를 사용해 생성됩니다. 인증서의 공개 키를 사용해 서명을 검증할 수 있습니다. 서명은 출처와 무결성에 대한 증거를 제공하지만 프레젠테이션을 암호화하지는 않습니다.
- **암호 보호**는 사용자가 프레젠테이션을 열거나 수정할 수 있는지를 제어합니다. 이는 디지털 서명과 별개이며 [암호 보호 프레젠테이션](/net/password-protected-presentation/)에 설명되어 있습니다.

PowerPoint은 **파일 > 정보 > 프레젠테이션 보호** 아래 **디지털 서명 추가** 명령을 제공합니다.

![PowerPoint 프레젠테이션 보호 메뉴에서 디지털 서명 추가가 강조된 모습](add-digital-signature-in-powerpoint.png)

서명된 프레젠테이션을 열면 PowerPoint은 서명 상태 알림을 표시할 수 있습니다.

![프레젠테이션에 유효한 서명이 포함되어 있다는 PowerPoint 알림](digital-signature-status-in-powerpoint.png)

Aspose.Slides는 [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/ko/net/aspose.slides/ipresentation/digitalsignatures/)를 통해 서명을 노출합니다. 이는 [IDigitalSignatureCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/idigitalsignaturecollection/)이며, 그 항목은 [IDigitalSignature](https://reference.aspose.com/slides/ko/net/aspose.slides/idigitalsignature/)를 구현합니다. 프레젠테이션에는 여러 서명이 포함될 수 있습니다.

## **PFX 인증서 및 암호 이해하기**

PFX 파일은 PKCS#12 파일이라고도 하며 일반적으로 `.pfx` 또는 `.p12` 확장자를 가집니다. 여기에는 X.509 인증서, 해당 개인 키 및 인증서 체인이 포함될 수 있습니다. 개인 키는 서명을 생성할 수 있게 해줍니다. 접근 가능한 개인 키가 없는 인증서는 프레젠테이션에 서명할 수 없습니다.

PFX 암호는 인증서 패키지와 개인 키를 보호합니다. 이는 프레젠테이션을 열거나 편집하기 위한 암호가 **아닙니다**. PFX 파일이나 암호를 소스 제어에 커밋하지 마세요. 프로덕션 환경에서는 인증서 파일에 대한 접근을 제한하고 암호를 비밀 저장소나 기타 보호된 구성 소스에서 가져와야 합니다. 아래 예제에서는 암호를 코드에 직접 포함하지 않기 위해 환경 변수를 사용합니다.

## **프레젠테이션에 디지털 서명 추가하기**

실제 프레젠테이션 워크플로에 서명하려면 기존 PPTX 파일을 로드하고, PFX 인증서와 해당 암호를 사용해 [DigitalSignature](https://reference.aspose.com/slides/ko/net/aspose.slides/digitalsignature/)을 만든 뒤, 서명을 프레젠테이션 컬렉션에 추가하고 PPTX 파일로 저장합니다.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

var certificatePassword = Environment.GetEnvironmentVariable("PFX_PASSWORD")
    ?? throw new InvalidOperationException("Set the PFX_PASSWORD environment variable.");

using var presentation = new Presentation("InputPresentation.pptx");

var signature = new DigitalSignature("signing-certificate.pfx", certificatePassword)
{
    Comments = "Approved for release."
};

presentation.DigitalSignatures.Add(signature);
presentation.Save("InputPresentation-signed.pptx", SaveFormat.Pptx);
```

새 이름으로 저장하면 서명되지 않은 원본 파일을 보존할 수 있습니다. [DigitalSignature.Comments](https://reference.aspose.com/slides/ko/net/aspose.slides/digitalsignature/comments/) 값은 서명의 목적을 설명할 뿐이며 보안 제어가 아닙니다.

## **디지털 서명 검증하기**

서명된 PPTX 파일을 로드할 때 [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/ko/net/aspose.slides/ipresentation/digitalsignatures/)의 모든 항목을 검사합니다. [IDigitalSignature.IsValid](https://reference.aspose.com/slides/ko/net/aspose.slides/idigitalsignature/isvalid/) 속성은 현재 프레젠테이션 내용에 대해 포함된 서명이 유효한지 여부를 나타냅니다.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("InputPresentation-signed.pptx");

var signatureCount = presentation.DigitalSignatures.Count;

if (signatureCount == 0)
{
    Console.WriteLine("The presentation does not contain digital signatures.");
}
else
{
    var allSignaturesAreValid = true;

    foreach (var signature in presentation.DigitalSignatures)
    {
        var signatureStatus = signature.IsValid ? "VALID" : "INVALID";
        var signerName = signature.Certificate.SubjectName.Name;

        Console.WriteLine(
            $"{signerName}, {signature.SignTime:yyyy-MM-dd HH:mm:ss} -- {signatureStatus}");

        allSignaturesAreValid &= signature.IsValid;
    }

    Console.WriteLine(allSignaturesAreValid
        ? "All embedded signatures are valid for the current presentation."
        : "At least one embedded signature is invalid.");
}
```

유효하지 않은 결과는 서명 후 프레젠테이션 내용이나 서명 데이터가 변경되었거나 파일이 손상되었음을 의미합니다. 모든 서명을 제거하면 서명되지 않은 프레젠테이션이 되므로, 항목의 유효성만 확인하는 것으로는 충분하지 않습니다. 보안이 중요한 워크플로에서는 기대하는 서명 수와 서명자 신원이 존재하는지도 확인해야 합니다.

이 유효성 결과만으로 인증서 신뢰 결정을 내리면 안 됩니다. 보안 정책에 따라 애플리케이션은 X.509 인증서 체인을 구축·검증하고, 인증서 유효 기간과 폐기 상태를 확인하며, 기대하는 주체나 지문을 확인하고, 키 사용을 검증하며, 신뢰된 타임스탬프를 평가해야 할 수도 있습니다. [IDigitalSignature.SignTime](https://reference.aspose.com/slides/ko/net/aspose.slides/idigitalsignature/signtime/) 값 자체는 신뢰된 타임스탬프 기관의 증명이 아닙니다.

## **디지털 서명 제거하기**

서명을 제거하면 프레젠테이션의 보안 상태가 변경됩니다. 다음 예제는 서명된 PPTX 파일을 로드하고, [IDigitalSignatureCollection.Clear](https://reference.aspose.com/slides/ko/net/aspose.slides/idigitalsignaturecollection/clear/) 로 모든 서명을 제거한 뒤, 서명되지 않은 복사본을 저장합니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("InputPresentation-signed.pptx");

presentation.DigitalSignatures.Clear();
presentation.Save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
```

하나의 서만 제거하려면 해당 서명의 0부터 시작하는 인덱스를 사용해 [IDigitalSignatureCollection.RemoveAt](https://reference.aspose.com/slides/ko/net/aspose.slides/idigitalsignaturecollection/removeat/) 를 호출합니다. 서명된 원본을 덮어쓰는 것이 명시적인 워크플로가 아니라면 새 파일에 저장하세요.

## **편집 및 형식 고려 사항**

- 서명은 프레젠테이션을 읽기 전용으로 만들지 않습니다. 사용자와 애플리케이션은 파일을 계속 편집할 수 있지만, 서명된 내용이 변경되면 기존 서명이 무효화됩니다.
- 서명하기 전에 모든 편집을 완료하세요. 프레젠테이션을 변경해야 하면 수정된 프레젠테이션을 저장하고 다시 서명하십시오.
- 최종 출력은 PPTX 형식으로 유지하세요. 서명된 프레젠테이션을 다른 형식으로 변환해도 원본 PPTX 서명이 유효한 서명으로 전송되지 않습니다.
- 인증서의 개인 키는 민감한 정보입니다. 개인 키와 암호를 입수한 사람은 해당 인증서 소유자인 척 서명을 만들 수 있습니다.
- 문서 보존 정책에 따라 서명되지 않은 원본이나 다른 관리된 복사본을 보관하세요.

## **FAQ**

**디지털 서명이 프레젠테이션을 암호화하나요?**

아니요. 디지털 서명은 출처와 무결성에 대한 증거를 제공하지만, 별도의 암호화가 적용되지 않는 한 프레젠테이션 내용은 읽을 수 있습니다. 내용 접근을 제한해야 할 경우 [암호 보호](/net/password-protected-presentation/)를 사용하세요.

**PFX 암호와 프레젠테이션 암호는 같은 것인가요?**

아니요. PFX 암호는 인증서 패키지에 저장된 개인 키를 잠금 해제합니다. 이는 PPTX 파일을 열거나 편집할 수 있는 권한을 제어하지 않습니다.

**자가 서명 인증서를 사용할 수 있나요?**

기술적으로는 접근 가능한 개인 키가 포함된 경우 자가 서명 인증서를 사용할 수 있습니다. 수신자는 자동으로 이를 신뢰하지 않으며, 해당 인증서를 신뢰된 환경에 명시적으로 추가해야 합니다. 일반적인 조직 간 워크플로에서는 신뢰할 수 있는 CA가 발급한 인증서를 사용합니다.

**서명이 무효가 되는 경우는 무엇인가요?**

서명 후 프레젠테이션 내용이나 서명 데이터를 변경하면 서명이 무효가 됩니다. 파일 손상도 검증 실패를 일으킬 수 있습니다. 모든 서명이 제거되면 프레젠테이션은 서명되지 않은 상태가 됩니다.

**유효한 서명이 있다고 해서 서명을 신뢰해야 하나요?**

그 자체만으로는 충분하지 않습니다. 서명 무결성과 서명자 신뢰는 별개의 판단 요소입니다. 프로덕션 검증 정책에서는 인증서 체인, 유효 기간, 폐기 상태, 기대 신원, 키 사용 및 신뢰된 타임스탬프 요구 사항 등을 함께 확인해야 합니다.

**인증서가 만료되면 어떻게 되나요?**

인증서 만료는 프레젠테이션 파일의 바이트를 변경하지 않지만, 인증서 신뢰 평가에 영향을 줍니다. 서명이 허용되는지는 정책과, 인증서가 유효한 동안 서명되었음을 증명하는 유효한 신뢰 타임스탬프가 있는지에 따라 달라집니다. 표시된 서명 시간만을 신뢰된 타임스탬프로 의존하지 마세요.

**서명된 프레젠테이션을 편집할 수 있나요?**

가능합니다. 서명은 파일을 잠그지 않습니다. 서명된 내용을 편집하면 기존 서명이 일반적으로 무효화되므로, 프레젠테이션을 완성한 뒤 최종 버전에 서명하십시오.

**프레젠테이션에 여러 서명을 포함할 수 있나요?**

네. 저장하기 전에 각 서명을 [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/ko/net/aspose.slides/ipresentation/digitalsignatures/)에 추가하면 됩니다. 검증 시 모든 서명을 검사하고 필요한 서명자가 모두 존재하는지 확인하세요.

**어떤 프레젠테이션 형식이 이 작업을 지원하나요?**

Aspose.Slides는 여기서 설명한 디지털 서명 작업을 PPTX 형식에만 지원합니다. PPT 및 OpenDocument 프레젠테이션 형식은 이 API 워크플로에서 지원되지 않습니다.

**슬라이드에 영향을 주지 않고 서명을 제거할 수 있나요?**

네. 하나의 서명을 제거하거나 전체 컬렉션을 비운 뒤 프레젠테이션을 저장하면 슬라이드 내용은 그대로 유지되지만, 저장된 파일에는 제거된 서명에 대한 증거가 남지 않습니다.