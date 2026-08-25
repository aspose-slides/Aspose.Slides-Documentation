---
title: .NET에서 프레젠테이션에 디지털 서명 추가
linktitle: 디지털 서명
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

디지털 서명은 수신자가 프레젠테이션에 누가 서명했는지 및 서명된 내용이 변경되었는지 여부를 판단하는 데 도움을 줍니다. 여기서는 세 가지 관련 보안 개념이 중요합니다:

- **디지털 인증서**는 신원을 공개 키와 연결하는 전자 증명서입니다. 신뢰할 수 있는 인증 기관(CA)이 인증서를 발급하거나, 조직에서 내부 워크플로에 자체 서명 인증서를 사용할 수 있습니다.
- **디지털 서명**은 프레젠테이션 내용과 인증서 소유자의 개인 키로부터 생성됩니다. 인증서의 공개 키를 사용해 서명을 검증할 수 있습니다. 서명은 출처와 무결성의 증거를 제공하지만 프레젠테이션을 암호화하지는 않습니다.
- **비밀번호 보호**는 사용자가 프레젠테이션을 열거나 수정할 수 있는지를 제어합니다. 이는 디지털 서명과 별개이며, [Password-Protected Presentations](/slides/ko/net/password-protected-presentation/)에서 설명합니다.

PowerPoint는 **파일 > 정보 > 프레젠테이션 보호** 아래에 **디지털 서명 추가** 명령을 제공합니다.

![디지털 서명 추가가 강조된 PowerPoint 프레젠테이션 보호 메뉴](add-digital-signature-in-powerpoint.png)

서명된 프레젠테이션을 열면 PowerPoint가 서명 상태 알림을 표시할 수 있습니다.

![프레젠테이션에 유효한 서명이 포함되어 있음을 나타내는 PowerPoint 알림](digital-signature-status-in-powerpoint.png)

Aspose.Slides는 [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/ko/net/aspose.slides/ipresentation/digitalsignatures/)와, 항목이 [IDigitalSignature](https://reference.aspose.com/slides/ko/net/aspose.slides/idigitalsignature/)를 구현하는 [IDigitalSignatureCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/idigitalsignaturecollection/)를 통해 서명을 노출합니다. 프레젠테이션에는 여러 서명이 포함될 수 있습니다.

## **PFX 인증서와 비밀번호 이해**

PFX 파일은 PKCS#12 파일이라고도 하며 일반적으로 `.pfx` 또는 `.p12` 확장자를 가집니다. X.509 인증서, 해당 개인 키 및 인증서 체인이 포함될 수 있습니다. 개인 키는 소유자가 서명을 만들 수 있게 해 줍니다. 개인 키에 접근할 수 없는 인증서는 프레젠테이션에 서명하는 데 사용할 수 없습니다.

PFX 비밀번호는 인증서 패키지와 개인 키를 보호합니다. 이는 프레젠테이션을 열거나 편집하기 위한 비밀번호가 **아닙니다**. PFX 파일이나 그 비밀번호를 소스 제어에 커밋하지 마세요. 운영 환경에서는 인증서 파일에 대한 접근을 제한하고 비밀번호를 비밀 저장소 또는 다른 보호된 구성 소스에서 가져와야 합니다. 아래 예제에서는 비밀번호를 코드에 포함하지 않기 위해 환경 변수를 사용합니다.

## **프레젠테이션에 디지털 서명 추가**

실제 프레젠테이션 워크플로에 서명하려면 기존 PPTX 파일을 로드하고, PFX 인증서와 비밀번호로부터 [DigitalSignature](https://reference.aspose.com/slides/ko/net/aspose.slides/digitalsignature/)을 만든 뒤, 서명을 프레젠테이션 컬렉션에 추가하고 PPTX 파일로 저장합니다.

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

결과를 새 이름으로 저장하면 서명되지 않은 원본 파일을 보존할 수 있습니다. [DigitalSignature.Comments](https://reference.aspose.com/slides/ko/net/aspose.slides/digitalsignature/comments/) 값은 서명의 목적을 설명하며 보안 제어가 아닙니다.

## **디지털 서명 검증**

서명된 PPTX 파일을 로드할 때 [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/ko/net/aspose.slides/ipresentation/digitalsignatures/)의 모든 항목을 검사합니다. [IDigitalSignature.IsValid](https://reference.aspose.com/slides/ko/net/aspose.slides/idigitalsignature/isvalid/) 속성은 현재 프레젠테이션 내용에 대해 삽입된 서명이 유효한지 여부를 나타냅니다.

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

잘못된 결과는 일반적으로 서명된 프레젠테이션 내용이나 서명 데이터가 서명 후 변경되었거나 파일이 손상되었음을 의미합니다. 모든 서명을 제거하면 서명되지 않은 프레젠테이션이 되므로, 항목의 유효성만 확인하는 것으로는 충분하지 않습니다. 보안에 민감한 워크플로에서는 기대되는 서명 수와 서명자 신원이 존재하는지도 확인해야 합니다.

이 유효성 결과만으로 전체 인증서 신뢰 결정을 내리면 안 됩니다. 보안 정책에 따라 응용 프로그램은 X.509 인증서 체인을 구축·검증하고, 인증서 유효 기간 및 폐기 상태를 확인하며, 기대되는 주체 또는 지문을 확인하고, 키 사용을 검증하고, 신뢰된 타임스탬프를 평가해야 할 수도 있습니다. [IDigitalSignature.SignTime](https://reference.aspose.com/slides/ko/net/aspose.slides/idigitalsignature/signtime/) 값만으로는 신뢰된 타임스탬프 권한 기관의 증명으로 볼 수 없습니다.

## **디지털 서명 제거**

서명을 제거하면 프레젠테이션의 보안 상태가 변경됩니다. 다음 예제는 서명된 PPTX 파일을 로드하고, [IDigitalSignatureCollection.Clear](https://reference.aspose.com/slides/ko/net/aspose.slides/idigitalsignaturecollection/clear/)로 모든 서명을 제거한 뒤, 서명되지 않은 복사본을 저장합니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("InputPresentation-signed.pptx");

presentation.DigitalSignatures.Clear();
presentation.Save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
```

하나의 서명만 제거하려면 해당 서명의 0 기반 인덱스를 사용해 [IDigitalSignatureCollection.RemoveAt](https://reference.aspose.com/slides/ko/net/aspose.slides/idigitalsignaturecollection/removeat/)를 호출합니다. 서명된 원본을 덮어쓰는 것이 명시적인 워크플로의 일부가 아니라면 새 파일에 저장하세요.

## **편집 및 형식 고려 사항**

- 서명은 프레젠테이션을 읽기 전용으로 만들지 않습니다. 사용자와 애플리케이션은 여전히 파일을 편집할 수 있지만, 서명된 내용이 변경되면 일반적으로 기존 서명이 무효화됩니다.
- 서명하기 전에 모든 의도된 편집을 완료하십시오. 프레젠테이션을 변경해야 하면 수정된 프레젠테이션을 저장하고 그 개정본에 다시 서명하십시오.
- 최종 출력은 PPTX 형식으로 유지하십시오. 서명된 프레젠테이션을 다른 형식으로 변환해도 원본 PPTX 서명이 변환된 파일에 대한 유효한 서명으로 전달되지 않습니다.
- 인증서의 개인 키는 민감한 정보로 취급해야 합니다. 개인 키와 비밀번호를 입수한 사람은 해당 인증서 소유자처럼 보이는 서명을 만들 수 있습니다.
- 문서 보존 정책에 따라 서명되지 않은 원본 또는 다른 제어된 사본을 유지하십시오.

## **FAQ**

**디지털 서명이 프레젠테이션을 암호화합니까?**

아니요. 디지털 서명은 출처와 무결성에 대한 증거를 제공하지만, 별도의 암호화가 적용되지 않는 한 프레젠테이션 내용은 그대로 읽을 수 있습니다. 내용 접근을 제한해야 할 경우 [password protection](/slides/ko/net/password-protected-presentation/)을 사용하십시오.

**PFX 비밀번호가 프레젠테이션 비밀번호와 동일합니까?**

아니요. PFX 비밀번호는 인증서 패키지에 저장된 개인 키를 해제합니다. 이는 PPTX 파일을 열거나 편집할 수 있는 권한을 제어하지 않습니다.

**자체 서명 인증서를 사용할 수 있나요?**

기술적으로는 접근 가능한 개인 키가 포함된 경우 자체 서명 인증서를 사용할 수 있습니다. 하지만 수신자는 해당 인증서를 자동으로 신뢰하지 않으며, 신뢰된 환경에 명시적으로 추가해야 합니다. 일반적인 공용 또는 조직 간 워크플로에서는 신뢰할 수 있는 CA가 발급한 인증서를 사용합니다.

**서명이 무효가 되는 이유는 무엇인가요?**

서명 후 프레젠테이션 내용이나 서명 데이터를 변경하면 서명이 무효가 될 수 있습니다. 파일 손상도 검증 실패의 원인이 됩니다. 모든 서명을 제거하면 파일에 무효 서명이 있는 것이 아니라 서명되지 않은 상태가 됩니다.

**유효한 서명이 signer를 신뢰해야 함을 의미합니까?**

그 자체만으로는 아닙니다. 서명 무결성과 서명자 신뢰는 별개의 판단입니다. 실제 검증 정책에서는 인증서 체인, 유효 기간, 폐기 상태, 기대되는 신원, 키 사용 및 신뢰된 타임스탬프 요구 사항 등을 확인해야 합니다.

**인증서가 만료되면 어떻게 됩니까?**

인증서 만료 자체는 프레젠테이션 바이트를 변경하지 않지만, 인증서 신뢰 평가에 영향을 미칩니다. 서명이 여전히 허용되는지는 정책과 유효한 신뢰 타임스탬프가 서명 시점에 인증서가 유효했음을 증명하는지 여부에 달려 있습니다. 표시된 서명 시간만을 신뢰된 타임스탬프로 사용하지 마세요.

**서명된 프레젠테이션을 편집할 수 있나요?**

예. 서명은 파일을 잠그지 않습니다. 서명된 내용을 편집하면 일반적으로 기존 서명이 무효가 되므로, 최종 버전을 먼저 완성하고 그에 서명하십시오.

**프레젠테이션에 여러 서명을 포함할 수 있나요?**

예. 저장하기 전에 각 서명을 [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/ko/net/aspose.slides/ipresentation/digitalsignatures/)에 추가하십시오. 검증 시 모든 서명을 검사하고 필요한 모든 서명자가 존재하는지 확인합니다.

**어떤 프레젠테이션 형식이 이러한 작업을 지원합니까?**

Aspose.Slides는 여기서 설명한 디지털 서명 작업을 PPTX에만 지원합니다. PPT 및 OpenDocument 프레젠테이션 형식은 이 API 워크플로에서 지원되지 않습니다.

**슬라이드에 영향을 주지 않고 서명을 제거할 수 있나요?**

예. 하나의 서명을 제거하거나 전체 컬렉션을 비운 다음 프레젠테이션을 저장하면 슬라이드 내용은 유지되지만 저장된 파일에 서명 증거가 남지 않습니다.