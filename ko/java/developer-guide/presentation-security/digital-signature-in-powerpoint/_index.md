---
title: Java에서 프레젠테이션에 디지털 서명 추가하기
linktitle: 디지털 서명
type: docs
weight: 10
url: /ko/java/digital-signature-in-powerpoint/
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
- Java
- Aspose.Slides
description: "PFX 인증서를 사용해 기존 PPTX 프레젠테이션에 서명하는 방법과 Aspose.Slides for Java를 이용해 디지털 서명을 검증하거나 제거하는 방법을 배웁니다."
---
## **개요**

디지털 서명은 수신자가 프레젠테이션에 누가 서명했는지와 서명된 내용이 변경되었는지 판단하는 데 도움을 줍니다. 여기서 중요한 세 가지 관련 보안 개념이 있습니다:

- **디지털 인증서**는 신원을 공개 키와 연결하는 전자 자격 증명입니다. 신뢰할 수 있는 인증 기관(CA)이 인증서를 발급할 수 있으며, 조직은 내부 작업 흐름을 위해 자체 서명 인증서를 사용할 수 있습니다.
- **디지털 서명**은 프레젠테이션 콘텐츠와 인증서 소유자의 개인 키로부터 생성됩니다. 인증서의 공개 키를 사용하여 서명을 검증할 수 있습니다. 서명은 출처와 무결성의 증거를 제공하지만 프레젠테이션을 암호화하지는 않습니다.
- **암호 보호**는 사용자가 프레젠테이션을 열거나 수정할 수 있는지를 제어합니다. 이는 디지털 서명과 별개이며 [Password-Protected Presentations](/java/password-protected-presentation/)에 설명되어 있습니다.

PowerPoint는 **File > Info > Protect Presentation** 아래에 **Add a Digital Signature** 명령을 제공합니다.

![Add a Digital Signature가 강조 표시된 PowerPoint Protect Presentation 메뉴](add-digital-signature-in-powerpoint.png)

프레젠테이션을 열면 PowerPoint가 서명 상태 알림을 표시할 수 있습니다.

![프레젠테이션에 유효한 서명이 포함되어 있음을 나타내는 PowerPoint 알림](digital-signature-status-in-powerpoint.png)

Aspose.Slides는 [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipresentation/#getDigitalSignatures--)를 통해 서명을 노출하며, 이는 [IDigitalSignatureCollection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/idigitalsignaturecollection/)을 반환하고, 해당 컬렉션의 항목은 [IDigitalSignature](https://reference.aspose.com/slides/ko/java/com.aspose.slides/idigitalsignature/)을 구현합니다. 하나의 프레젠테이션에 여러 서명이 포함될 수 있습니다.

## **PFX 인증서와 비밀번호 이해하기**

PFX 파일은 PKCS#12 파일이라고도 하며 일반적으로 `.pfx` 또는 `.p12` 확장자를 가집니다. 이 파일에는 X.509 인증서, 해당 개인 키 및 인증서 체인이 들어 있을 수 있습니다. 개인 키는 소유자가 서명을 만들 수 있게 하는 요소입니다. 접근 가능한 개인 키가 없는 인증서는 프레젠테이션에 서명하는 데 사용할 수 없습니다.

PFX 비밀번호는 인증서 패키지와 개인 키를 보호합니다. 이는 프레젠테이션을 열거나 편집하기 위한 비밀번호가 **아닙니다**. PFX 파일이나 비밀번호를 소스 컨트롤에 커밋하지 마세요. 프로덕션 환경에서는 인증서 파일에 대한 접근을 제한하고 비밀번호는 비밀 저장소 또는 다른 보호된 구성 원본에서 가져와야 합니다. 아래 예제는 코드에 비밀번호를 직접 삽입하지 않기 위해 환경 변수를 사용합니다.

## **프레젠테이션에 디지털 서명 추가하기**

실제 프레젠테이션 워크플로에 서명하려면 기존 PPTX 파일을 로드하고, PFX 인증서와 비밀번호에서 [DigitalSignature](https://reference.aspose.com/slides/ko/java/com.aspose.slides/digitalsignature/)을 생성한 뒤, 서명을 프레젠테이션 컬렉션에 추가하고 PPTX 파일로 저장합니다.

```java
String certificatePassword = System.getenv("PFX_PASSWORD");
if (certificatePassword == null || certificatePassword.isEmpty()) {
    throw new IllegalStateException("Set the PFX_PASSWORD environment variable.");
}

Presentation presentation = new Presentation("InputPresentation.pptx");
try {
    DigitalSignature signature = new DigitalSignature("signing-certificate.pfx", certificatePassword);
    signature.setComments("Approved for release.");

    presentation.getDigitalSignatures().add(signature);
    presentation.save("InputPresentation-signed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

새 이름으로 저장하면 서명되지 않은 원본 파일이 보존됩니다. [IDigitalSignature.setComments](https://reference.aspose.com/slides/ko/java/com.aspose.slides/idigitalsignature/#setComments-java.lang.String-) 로 설정한 값은 서명의 목적을 설명할 뿐, 보안 제어가 아닙니다.

## **디지털 서명 검증하기**

서명된 PPTX 파일을 로드할 때 [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipresentation/#getDigitalSignatures--)이 반환하는 모든 항목을 검사합니다. [IDigitalSignature.isValid](https://reference.aspose.com/slides/ko/java/com.aspose.slides/idigitalsignature/#isValid--) 메서드는 현재 프레젠테이션 내용에 대해 포함된 서명이 유효한지 여부를 나타냅니다.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    IDigitalSignatureCollection signatures = presentation.getDigitalSignatures();
    int signatureCount = signatures.size();

    if (signatureCount == 0) {
        System.out.println("The presentation does not contain digital signatures.");
    } else {
        boolean allSignaturesAreValid = true;
        java.text.SimpleDateFormat signTimeFormat = new java.text.SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
        java.security.cert.CertificateFactory certificateFactory = java.security.cert.CertificateFactory.getInstance("X.509");

        for (IDigitalSignature signature : signatures) {
            boolean signatureIsValid = signature.isValid();
            String signatureStatus = signatureIsValid ? "VALID" : "INVALID";
            java.util.Date signTime = signature.getSignTime();
            String formattedSignTime = signTimeFormat.format(signTime);

            byte[] certificateData = signature.getCertificate();
            java.io.ByteArrayInputStream certificateStream = new java.io.ByteArrayInputStream(certificateData);
            java.security.cert.X509Certificate certificate = (java.security.cert.X509Certificate) certificateFactory.generateCertificate(certificateStream);
            javax.security.auth.x500.X500Principal signerPrincipal = certificate.getSubjectX500Principal();
            String signerName = signerPrincipal.getName();

            System.out.println(signerName + ", " + formattedSignTime + " -- " + signatureStatus);

            allSignaturesAreValid &= signatureIsValid;
        }

        if (allSignaturesAreValid) {
            System.out.println("All embedded signatures are valid for the current presentation.");
        } else {
            System.out.println("At least one embedded signature is invalid.");
        }
    }
} finally {
    presentation.dispose();
}
```

무효 결과는 일반적으로 서명 후 프레젠테이션 내용이나 서명 데이터가 변경되었거나 파일이 손상되었음을 의미합니다. 모든 서명을 제거하면 서명되지 않은 프레젠테이션이 되므로 항목의 유효성만 확인하는 것으로는 충분하지 않습니다. 보안이 중요한 워크플로에서는 기대되는 서명 수와 서명자 신원이 모두 존재하는지도 확인해야 합니다.

이 유효성 결과만으로 인증서 신뢰 결정을 완전하게 내리면 안 됩니다. 보안 정책에 따라 애플리케이션은 X.509 인증서 체인을 구축·검증하고, 인증서 유효 기간 및 폐기 상태를 확인하며, 기대되는 주체 또는 지문을 확인하고, 키 사용을 검증하고, 신뢰된 타임스탬프를 평가해야 할 수도 있습니다. [IDigitalSignature.getSignTime](https://reference.aspose.com/slides/ko/java/com.aspose.slides/idigitalsignature/#getSignTime--) 값 자체는 신뢰된 타임스탬프 권한기관의 증거가 아닙니다.

## **디지털 서명 제거하기**

서명을 제거하면 프레젠테이션의 보안 상태가 변경됩니다. 다음 예제는 서명된 PPTX 파일을 로드하고, [IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/ko/java/com.aspose.slides/idigitalsignaturecollection/#clear--) 로 모든 서명을 제거한 뒤, 서명되지 않은 사본을 저장합니다.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

하나의 서명만 제거하려면 해당 서명의 0 기반 인덱스로 [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/ko/java/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-) 를 호출합니다. 워크플로에서 서명된 원본을 명시적으로 덮어쓰는 것이 아니라면 새 파일에 저장하세요.

## **편집 및 형식 고려 사항**

- 서명은 프레젠테이션을 읽기 전용으로 만들지 않습니다. 사용자와 애플리케이션은 파일을 계속 편집할 수 있지만, 서명된 내용을 변경하면 일반적으로 기존 서명이 무효화됩니다.
- 서명하기 전에 모든 의도된 편집을 완료하세요. 프레젠테이션을 변경해야 할 경우 수정된 파일을 저장하고 해당 개정본에 다시 서명합니다.
- 최종 출력은 PPTX 형식으로 유지하세요. 서명된 프레젠테이션을 다른 형식으로 변환해도 원본 PPTX 서명이 변환된 파일에 대한 유효한 서명으로 전달되지 않습니다.
- 인증서의 개인 키는 민감한 자료로 취급하세요. 개인 키와 비밀번호를 얻은 사람은 해당 인증서 소유자로 가장하는 서명을 만들 수 있습니다.
- 문서 보존 정책에 따라 서명되지 않은 원본이나 다른 관리된 사본을 보관하세요.

## **FAQ**

**디지털 서명이 프레젠테이션을 암호화합니까?**

아니요. 디지털 서명은 출처와 무결성에 대한 증거를 제공하지만, 별도의 암호화가 적용되지 않는 한 프레젠테이션 내용은 읽을 수 있습니다. 내용 접근을 제한해야 하면 [password protection](/java/password-protected-presentation/)을 사용하세요.

**PFX 비밀번호가 프레젠테이션 비밀번호와 동일합니까?**

아니요. PFX 비밀번호는 인증서 패키지에 저장된 개인 키를 해제하는 용도이며, PPTX 파일을 열거나 편집할 수 있는 권한을 제어하지 않습니다.

**자체 서명 인증서를 사용할 수 있나요?**

기술적으로는 접근 가능한 개인 키가 포함된 자체 서명 인증서를 사용할 수 있습니다. 그러나 수신자는 해당 인증서를 명시적으로 신뢰 환경에 추가하지 않는 한 자동으로 신뢰하지 않습니다. 일반적인 조직 간 워크플로에서는 신뢰된 CA가 발급한 인증서를 사용합니다.

**어떤 경우에 서명이 무효가 되나요?**

서명 후 프레젠테이션 내용이나 서명 데이터를 변경하거나 파일이 손상되면 서명이 무효화됩니다. 모든 서명을 제거하면 프레젠테이션 자체가 서명되지 않은 상태가 되며, 이는 “무효 서명”이 아니라 “서명 없음”입니다.

**유효한 서명이 서명자를 신뢰해야 한다는 의미인가요?**

그 자체만으로는 충분하지 않습니다. 서명 무결성과 서명자 신뢰는 별개의 판단입니다. 운영 환경에서는 인증서 체인, 유효 기간, 폐기 상태, 기대 신원, 키 사용 및 신뢰된 타임스탬프 등을 함께 검증해야 합니다.

**인증서가 만료되면 어떻게 되나요?**

인증서 만료는 프레젠테이션 바이트 자체를 변경하지 않지만, 인증서 신뢰 평가에 영향을 줍니다. 서명이 여전히 허용될지는 정책에 따라 다르며, 서명 시점에 인증서가 유효했음을 입증하는 신뢰된 타임스탬프가 있는지 여부가 중요합니다. 표시되는 서명 시간만을 신뢰된 타임스탬프로 간주하지 마세요.

**서명된 프레젠테이션을 여전히 편집할 수 있나요?**

예. 서명은 파일을 잠그지 않습니다. 서명된 내용을 편집하면 일반적으로 기존 서명이 무효화되므로, 최종 버전을 먼저 완성하고 그에 서명하는 것이 좋습니다.

**프레젠테이션에 여러 서명이 포함될 수 있나요?**

예. 저장하기 전에 [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipresentation/#getDigitalSignatures--)이 반환하는 컬렉션에 각각의 서명을 추가하세요. 검증 시에는 모든 서명을 검사하고 필요한 서명자 모두가 존재하는지 확인합니다.

**어떤 프레젠테이션 형식이 이러한 작업을 지원하나요?**

Aspose.Slides는 여기서 설명한 디지털 서명 작업을 오직 PPTX 형식에만 지원합니다. PPT 및 OpenDocument 프레젠테이션 형식은 이 API 워크플로에서 지원되지 않습니다.

**슬라이드에 영향을 주지 않고 서명을 제거할 수 있나요?**

예. 하나의 서명을 제거하거나 전체 컬렉션을 비운 뒤 프레젠테이션을 저장하면 슬라이드 내용은 그대로 유지되지만, 저장된 파일에는 더 이상 서명 증거가 포함되지 않습니다.