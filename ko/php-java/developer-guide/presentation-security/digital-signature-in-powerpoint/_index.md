---
title: PHP에서 프레젠테이션에 디지털 서명 추가
linktitle: 디지털 서명
type: docs
weight: 10
url: /ko/php-java/digital-signature-in-powerpoint/
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
- PHP
- Aspose.Slides
description: "PFX 인증서를 사용하여 기존 PPTX 프레젠테이션에 서명하고, Java를 통해 PHP용 Aspose.Slides를 이용해 디지털 서명을 검증하거나 제거하는 방법을 배웁니다."
---
## **Overview**

디지털 서명은 수신자가 프레젠테이션을 누가 서명했는지와 서명된 내용이 변경되었는지 여부를 판단하는 데 도움이 됩니다. 여기서는 세 가지 관련 보안 개념이 중요합니다:

- **디지털 인증서**는 신원을 공개 키와 연결하는 전자 자격 증명입니다. 신뢰할 수 있는 인증 기관(CA)이 인증서를 발급하거나, 조직이 내부 워크플로에 자체 서명 인증서를 사용할 수 있습니다.
- **디지털 서명**은 프레젠테이션 내용과 인증서 보유자의 개인 키를 사용하여 생성됩니다. 인증서의 공개 키를 사용하여 서명을 검증할 수 있습니다. 서명은 출처와 무결성에 대한 증거를 제공하지만 프레젠테이션을 암호화하지는 않습니다.
- **암호 보호**는 사용자가 프레젠테이션을 열거나 수정할 수 있는지를 제어합니다. 이는 디지털 서명과 별개이며, [Password-Protected Presentations](/slides/ko/php-java/password-protected-presentation/)에 설명되어 있습니다.

PowerPoint은 **파일 > 정보 > 프레젠테이션 보호** 아래 **디지털 서명 추가** 명령을 제공합니다.

![PowerPoint Protect Presentation menu with Add a Digital Signature highlighted](add-digital-signature-in-powerpoint.png)

서명된 프레젠테이션을 열면 PowerPoint에서 서명 상태 알림을 표시할 수 있습니다.

![PowerPoint notification stating that the presentation contains valid signatures](digital-signature-status-in-powerpoint.png)

Aspose.Slides는 [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#getDigitalSignatures)를 통해 서명을 노출하며, 이는 [DigitalSignatureCollection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/digitalsignaturecollection/)을 반환하고, 해당 컬렉션의 항목은 [DigitalSignature](https://reference.aspose.com/slides/ko/php-java/aspose.slides/digitalsignature/) 객체로 표현됩니다. 하나의 프레젠테이션에 여러 서명이 포함될 수 있습니다.

## **Understand PFX Certificates and Passwords**

PFX 파일은 PKCS#12 파일이라고도 하며 일반적으로 `.pfx` 또는 `.p12` 확장자를 사용합니다. 여기에는 X.509 인증서, 해당 개인 키 및 인증서 체인이 포함될 수 있습니다. 개인 키는 보유자가 서명을 생성할 수 있게 해줍니다. 접근 가능한 개인 키가 없는 인증서는 프레젠테이션에 서명하는 데 사용할 수 없습니다.

PFX 비밀번호는 인증서 패키지와 개인 키를 보호합니다. 이는 프레젠테이션을 열거나 편집하기 위한 비밀번호가 **아닙니다**. PFX 파일이나 비밀번호를 소스 제어에 커밋하지 마세요. 운영 환경에서는 인증서 파일에 대한 접근을 제한하고 비밀번호를 비밀 저장소 또는 다른 보호된 구성 소스에서 가져와야 합니다. 아래 예제에서는 비밀번호를 코드에 직접 포함하지 않기 위해 환경 변수를 사용합니다.

## **Add a Digital Signature to a Presentation**

실제 프레젠테이션 워크플로에 서명하려면 기존 PPTX 파일을 로드하고, PFX 인증서와 비밀번호로부터 [DigitalSignature](https://reference.aspose.com/slides/ko/php-java/aspose.slides/digitalsignature/)을 만든 다음, 서명을 프레젠테이션 컬렉션에 추가하고 PPTX 파일로 저장합니다.

```php
$certificatePassword = getenv("PFX_PASSWORD");
if ($certificatePassword === false || $certificatePassword === "") {
    throw new RuntimeException("Set the PFX_PASSWORD environment variable.");
}

$presentation = new Presentation("InputPresentation.pptx");
try {
    $signature = new DigitalSignature("signing-certificate.pfx", $certificatePassword);
    $signature->setComments("Approved for release.");

    $presentation->getDigitalSignatures()->add($signature);
    $presentation->save("InputPresentation-signed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

새 이름으로 저장하면 서명되지 않은 원본 파일을 보존할 수 있습니다. [DigitalSignature::setComments](https://reference.aspose.com/slides/ko/php-java/aspose.slides/digitalsignature/setcomments/)로 설정한 값은 서명의 목적을 설명하며 보안 제어가 아닙니다.

## **Validate Digital Signatures**

서명된 PPTX 파일을 로드할 때, [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#getDigitalSignatures)에서 반환된 모든 항목을 검사합니다. [DigitalSignature::isValid](https://reference.aspose.com/slides/ko/php-java/aspose.slides/digitalsignature/isvalid/) 메서드는 포함된 서명이 현재 프레젠테이션 내용에 대해 유효한지 여부를 나타냅니다.

```php
$presentation = new Presentation("InputPresentation-signed.pptx");
try {
    $signatures = $presentation->getDigitalSignatures();
    $signatureCount = java_values($signatures->size());

    if ($signatureCount === 0) {
        echo "The presentation does not contain digital signatures." . PHP_EOL;
    } else {
        $allSignaturesAreValid = true;
        $signTimeFormat = new Java("java.text.SimpleDateFormat", "yyyy-MM-dd HH:mm:ss");
        $certificateFactoryClass = new JavaClass("java.security.cert.CertificateFactory");
        $certificateFactory = $certificateFactoryClass->getInstance("X.509");

        for ($index = 0; $index < $signatureCount; $index++) {
            $signature = $signatures->get_Item($index);
            $signatureIsValid = java_values($signature->isValid());
            $signatureStatus = $signatureIsValid ? "VALID" : "INVALID";
            $formattedSignTime = java_values($signTimeFormat->format($signature->getSignTime()));

            $certificateData = $signature->getCertificate();
            $certificateStream = new Java("java.io.ByteArrayInputStream", $certificateData);
            try {
                $certificate = $certificateFactory->generateCertificate($certificateStream);
                $signerName = java_values($certificate->getSubjectX500Principal()->getName());
            } finally {
                $certificateStream->close();
            }

            echo $signerName . ", " . $formattedSignTime . " -- " . $signatureStatus . PHP_EOL;

            $allSignaturesAreValid = $allSignaturesAreValid && $signatureIsValid;
        }

        if ($allSignaturesAreValid) {
            echo "All embedded signatures are valid for the current presentation." . PHP_EOL;
        } else {
            echo "At least one embedded signature is invalid." . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

유효하지 않은 결과는 일반적으로 서명 후 프레젠테이션 내용이나 서명 데이터가 변경되었거나 파일이 손상된 경우에 발생합니다. 모든 서명을 제거하면 서명되지 않은 프레젠테이션이 되므로, 항목의 유효성만 확인하는 것으로는 충분하지 않습니다. 보안이 중요한 워크플로에서는 예상 서명 수와 예상 서명자 식별자가 존재하는지도 확인해야 합니다.

이 유효성 결과만으로 인증서 신뢰 결정을 완전하게 내릴 수 없습니다. 보안 정책에 따라 애플리케이션은 X.509 인증서 체인을 구축하고 검증하며, 인증서 유효 기간과 폐기 상태를 확인하고, 예상 주체 또는 지문을 확인하고, 키 사용을 검증하며, 신뢰된 타임스탬프를 평가해야 할 수 있습니다. [DigitalSignature::getSignTime](https://reference.aspose.com/slides/ko/php-java/aspose.slides/digitalsignature/getsigntime/) 값 자체는 신뢰된 타임스탬프 기관의 증명이 아닙니다.

## **Remove Digital Signatures**

서명을 제거하면 프레젠테이션 보안 상태가 변경됩니다. 다음 예제는 서명된 PPTX 파일을 로드하고, [DigitalSignatureCollection::clear](https://reference.aspose.com/slides/ko/php-java/aspose.slides/digitalsignaturecollection/clear/) 로 모든 서명을 제거한 뒤, 서명되지 않은 복사본을 저장합니다.

```php
$presentation = new Presentation("InputPresentation-signed.pptx");
try {
    $presentation->getDigitalSignatures()->clear();
    $presentation->save("InputPresentation-unsigned.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

하나의 서명만 제거하려면 해당 서명의 0 기반 인덱스로 [DigitalSignatureCollection::removeAt](https://reference.aspose.com/slides/ko/php-java/aspose.slides/digitalsignaturecollection/removeat/) 를 호출합니다. 서명된 원본을 덮어쓰는 것이 워크플로의 명시적 일부가 아닌 한, 새 파일에 저장하십시오.

## **Editing and Format Considerations**

- 서명은 프레젠테이션을 읽기 전용으로 만들지 않습니다. 사용자와 애플리케이션은 여전히 파일을 편집할 수 있지만, 서명된 내용에 대한 변경은 일반적으로 기존 서명을 무효화합니다.
- 서명하기 전에 모든 편집을 완료하십시오. 프레젠테이션을 변경해야 하는 경우, 수정된 프레젠테이션을 저장하고 해당 버전을 다시 서명하십시오.
- 최종 출력은 PPTX 형식으로 유지하십시오. 서명된 프레젠테이션을 다른 형식으로 변환하면 원본 PPTX 서명이 변환된 파일에 대한 유효한 서명으로 전송되지 않습니다.
- 인증서의 개인 키는 민감한 정보로 취급하십시오. 개인 키와 비밀번호를 얻은 사람은 해당 인증서 보유자 명의의 서명을 생성할 수 있습니다.
- 문서 보존 정책에 따라 서명되지 않은 원본 또는 다른 통제된 사본을 보관하십시오.

## **FAQ**

**Does a digital signature encrypt the presentation?**

No. A digital signature provides evidence about origin and integrity, but presentation content remains readable unless separate encryption is applied. Use [password protection](/slides/ko/php-java/password-protected-presentation/) when access to the content must be restricted.

**Is the PFX password the same as a presentation password?**

No. The PFX password unlocks the private key stored in the certificate package. It does not control who can open or edit the PPTX file.

**Can I use a self-signed certificate?**

Technically, a self-signed certificate can be used when it includes an accessible private key. Recipients will not automatically trust it, however, unless that certificate has been explicitly added to their trusted environment. Public or cross-organization workflows generally use a certificate issued by a trusted CA.

**What makes a signature invalid?**

Changing signed presentation content or the signature data after signing can invalidate the signature. File corruption can also cause validation to fail. If all signatures are removed, the presentation is unsigned rather than a file containing an invalid signature.

**Does a valid signature mean that I should trust the signer?**

Not by itself. Signature integrity and signer trust are separate decisions. A production validation policy should also check the certificate chain, validity period, revocation status, expected identity, key usage, and any trusted timestamp requirements.

**What happens when the certificate expires?**

Certificate expiration does not alter the presentation bytes, but it affects certificate-trust evaluation. Whether a signature remains acceptable depends on your policy and on whether a valid trusted timestamp proves that signing occurred while the certificate was valid. Do not rely on the displayed signing time alone as a trusted timestamp.

**Can a signed presentation still be edited?**

Yes. Signing does not lock the file. Editing signed content generally makes the existing signature invalid, so finish the presentation first and sign the final revision.

**Can a presentation contain more than one signature?**

Yes. Add each signature to the collection returned by [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#getDigitalSignatures) before saving. During validation, inspect every signature and confirm that all required signers are present.

**Which presentation formats support these operations?**

Aspose.Slides supports the digital-signature operations described here only for PPTX. PPT and OpenDocument presentation formats are not supported by this API workflow.

**Can I remove a signature without affecting the slides?**

Yes. You can remove one signature or clear the entire collection and then save the presentation. The slide content remains available, but the saved file no longer carries the removed signature evidence.