---
title: Python에서 프레젠테이션에 디지털 서명 추가
linktitle: 디지털 서명
type: docs
weight: 10
url: /ko/python-java/digital-signature-in-powerpoint/
keywords:
  - 디지털 서명
  - 디지털 인증서
  - 인증서 발급 기관
  - PFX 인증서
  - PKCS#12
  - 서명 검증
  - PowerPoint
  - PPTX
  - 프레젠테이션 보안
  - Python
  - Aspose.Slides
description: "PFX 인증서를 사용해 기존 PPTX 프레젠테이션에 서명하고, Java를 통해 Python용 Aspose.Slides를 이용해 디지털 서명을 검증하거나 제거하는 방법을 배웁니다."
---
## **개요**

디지털 서명은 수신자가 프레젠테이션을 누가 서명했는지와 서명된 내용이 변경되었는지를 판단하는 데 도움을 줍니다. 여기서 중요한 세 가지 관련 보안 개념은 다음과 같습니다:

- **디지털 인증서**는 신원을 공개 키와 연결하는 전자 자격 증명입니다. 신뢰할 수 있는 인증 기관(CA)이 인증서를 발급할 수 있거나, 조직이 내부 워크플로에 대해 자체 서명된 인증서를 사용할 수 있습니다.
- **디지털 서명**은 프레젠테이션 내용과 인증서 소유자의 개인 키를 사용해 생성됩니다. 인증서의 공개 키를 사용해 서명을 검증할 수 있습니다. 서명은 출처와 무결성을 증명하지만 프레젠테이션을 암호화하지는 않습니다.
- **비밀번호 보호**는 사용자가 프레젠테이션을 열거나 수정할 수 있는지를 제어합니다. 이는 디지털 서명과 별개이며, [Password-Protected Presentations](/slides/ko/python-java/password-protected-presentation/)에서 설명합니다.

PowerPoint은 **파일 > 정보 > 프레젠테이션 보호** 아래 **디지털 서명 추가** 명령을 제공합니다.

![PowerPoint 프레젠테이션 보호 메뉴에서 디지털 서명 추가가 강조된 모습](add-digital-signature-in-powerpoint.png)

서명된 프레젠테이션을 열면 PowerPoint이 서명 상태 알림을 표시할 수 있습니다.

![PowerPoint 알림: 프레젠테이션에 유효한 서명이 포함되어 있음](digital-signature-status-in-powerpoint.png)

Aspose.Slides는 [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getDigitalSignatures)를 통해 서명을 노출하며, 이는 [DigitalSignatureCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/digitalsignaturecollection/)을 반환하고 해당 컬렉션의 항목은 [DigitalSignature](https://reference.aspose.com/slides/ko/python-java/aspose.slides/digitalsignature/) 인스턴스입니다. 프레젠테이션에는 여러 서명이 포함될 수 있습니다.

## **PFX 인증서와 비밀번호 이해하기**

PFX 파일은 PKCS#12 파일이라고도 하며 일반적으로 `.pfx` 또는 `.p12` 확장자를 갖습니다. 이 파일에는 X.509 인증서, 해당 개인 키 및 인증서 체인이 포함될 수 있습니다. 개인 키는 소유자가 서명을 만들 수 있게 해줍니다. 접근 가능한 개인 키가 없는 인증서는 프레젠테이션에 서명하는 데 사용할 수 없습니다.

PFX 비밀번호는 인증서 패키지와 개인 키를 보호합니다. 이는 프레젠테이션을 열거나 편집하기 위한 비밀번호가 **아닙니다**. PFX 파일이나 비밀번호를 소스 제어에 커밋하지 마세요. 운영 환경에서는 인증서 파일에 대한 접근을 제한하고 비밀번호를 비밀 저장소 또는 다른 보호된 구성 소스에서 가져오세요. 아래 예제에서는 비밀번호를 코드에 직접 삽입하지 않기 위해 환경 변수를 사용합니다.

## **프레젠테이션에 디지털 서명 추가하기**

실제 프레젠테이션 워크플로에서 서명하려면 기존 PPTX 파일을 로드하고, PFX 인증서와 비밀번호로부터 [DigitalSignature](https://reference.aspose.com/slides/ko/python-java/aspose.slides/digitalsignature/)을 만든 다음, 서명을 프레젠테이션의 컬렉션에 추가하고 PPTX 파일로 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

import os
from asposeslides.api import Presentation, DigitalSignature, SaveFormat

certificate_password = os.environ.get("PFX_PASSWORD")
if not certificate_password:
    print("Set the PFX_PASSWORD environment variable.")
else:
    presentation = Presentation("InputPresentation.pptx")
    try:
        signature = DigitalSignature("signing-certificate.pfx", certificate_password)
        signature.setComments("Approved for release.")

        presentation.getDigitalSignatures().add(signature)
        presentation.save("InputPresentation-signed.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
```

새 이름으로 저장하면 서명되지 않은 원본 파일이 보존됩니다. [DigitalSignature.setComments](https://reference.aspose.com/slides/ko/python-java/aspose.slides/digitalsignature/#setComments)로 설정한 값은 서명의 목적을 설명할 뿐이며 보안 제어가 아닙니다.

## **디지털 서명 검증하기**

서명된 PPTX 파일을 로드할 때 [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getDigitalSignatures)에서 반환된 모든 항목을 검사합니다. [DigitalSignature.isValid](https://reference.aspose.com/slides/ko/python-java/aspose.slides/digitalsignature/#isValid) 메서드는 삽입된 서명이 현재 프레젠테이션 내용에 대해 유효한지를 나타냅니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

ByteArrayInputStream = jpype.JClass("java.io.ByteArrayInputStream")
CertificateFactory = jpype.JClass("java.security.cert.CertificateFactory")
SimpleDateFormat = jpype.JClass("java.text.SimpleDateFormat")

presentation = Presentation("InputPresentation-signed.pptx")
try:
    signatures = presentation.getDigitalSignatures()
    signature_count = signatures.size()

    if signature_count == 0:
        print("The presentation does not contain digital signatures.")
    else:
        all_signatures_are_valid = True
        sign_time_format = SimpleDateFormat("yyyy-MM-dd HH:mm:ss")
        certificate_factory = CertificateFactory.getInstance("X.509")

        for signature in signatures:
            signature_is_valid = signature.isValid()
            signature_status = "VALID" if signature_is_valid else "INVALID"
            sign_time = signature.getSignTime()
            formatted_sign_time = sign_time_format.format(sign_time)

            certificate_data = signature.getCertificate()
            certificate_stream = ByteArrayInputStream(certificate_data)
            certificate = certificate_factory.generateCertificate(certificate_stream)
            signer_principal = certificate.getSubjectX500Principal()
            signer_name = signer_principal.getName()

            print(f"{signer_name}, {formatted_sign_time} -- {signature_status}")

            all_signatures_are_valid = all_signatures_are_valid and signature_is_valid

        if all_signatures_are_valid:
            print("All embedded signatures are valid for the current presentation.")
        else:
            print("At least one embedded signature is invalid.")
finally:
    presentation.dispose()
```

유효하지 않은 결과는 일반적으로 서명 후 프레젠테이션 내용이나 서명 데이터가 변경되었거나 파일이 손상되었음을 의미합니다. 모든 서명을 제거하면 서명되지 않은 프레젠테이션이 되므로, 항목의 유효성만 확인하는 것으로는 부족합니다. 보안이 중요한 워크플로에서는 예상되는 서명 수와 서명자 신원이 모두 존재하는지 확인해야 합니다.

이 유효성 결과만으로 전체 인증서 신뢰 결정을 내리면 안 됩니다. 보안 정책에 따라 애플리케이션은 X.509 인증서 체인을 구축·검증하고, 인증서 유효 기간·폐기 상태를 확인하며, 예상되는 주체 또는 지문을 확인하고, 키 사용을 검증하고, 신뢰된 타임스탬프를 평가해야 할 수 있습니다. [DigitalSignature.getSignTime](https://reference.aspose.com/slides/ko/python-java/aspose.slides/digitalsignature/#getSignTime) 값 자체는 신뢰된 타임스탬프 권한기관의 증거가 아닙니다.

## **디지털 서명 제거하기**

서명을 제거하면 프레젠테이션의 보안 상태가 변경됩니다. 다음 예제는 서명된 PPTX 파일을 로드하고, [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/ko/python-java/aspose.slides/digitalsignaturecollection/#clear)으로 모든 서명을 제거한 뒤, 서명되지 않은 복사본을 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("InputPresentation-signed.pptx")
try:
    presentation.getDigitalSignatures().clear()
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

하나의 서명만 제거하려면 해당 서명의 0 기반 인덱스를 사용해 [DigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/ko/python-java/aspose.slides/digitalsignaturecollection/#removeAt)를 호출합니다. 서명된 원본을 덮어쓰는 것이 명시적인 워크플로의 일부가 아니라면 새 파일에 저장하세요.

## **편집 및 형식 고려사항**

- 서명은 프레젠테이션을 읽기 전용으로 만들지 않습니다. 사용자와 애플리케이션은 여전히 파일을 편집할 수 있지만, 서명된 내용이 변경되면 기존 서명이 일반적으로 무효화됩니다.
- 서명하기 전에 모든 의도된 편집을 완료하세요. 프레젠테이션을 변경해야 할 경우, 수정된 프레젠테이션을 저장하고 다시 서명하세요.
- 최종 출력은 PPTX 형식으로 유지하세요. 서명된 프레젠테이션을 다른 형식으로 변환해도 원본 PPTX 서명이 유효한 서명으로 전달되지 않습니다.
- 인증서의 개인 키는 민감한 정보입니다. 개인 키와 비밀번호를 입수한 사람은 해당 인증서 소유자처럼 보이는 서명을 만들 수 있습니다.
- 문서 보존 정책에 따라 서명되지 않은 원본 또는 다른 관리된 사본을 보관하세요.

## **FAQ**

**디지털 서명이 프레젠테이션을 암호화합니까?**

아니요. 디지털 서명은 출처와 무결성에 대한 증거를 제공하지만, 별도의 암호화가 적용되지 않는 한 프레젠테이션 내용은 읽을 수 있습니다. 내용 접근을 제한해야 할 경우 [비밀번호 보호](/slides/ko/python-java/password-protected-presentation/)를 사용하세요.

**PFX 비밀번호가 프레젠테이션 비밀번호와 동일합니까?**

아니요. PFX 비밀번호는 인증서 패키지에 저장된 개인 키를 해제합니다. 이는 PPTX 파일을 열거나 편집할 수 있는 권한을 제어하지 않습니다.

**자체 서명 인증서를 사용할 수 있나요?**

기술적으로는 접근 가능한 개인 키가 포함된 자체 서명 인증서를 사용할 수 있습니다. 다만 수신자가 해당 인증서를 신뢰하도록 명시적으로 추가하지 않으면 자동으로 신뢰되지 않습니다. 일반적인 퍼블릭 또는 조직 간 워크플로에서는 신뢰할 수 있는 CA가 발급한 인증서를 사용합니다.

**서명이 무효가 되는 경우는 무엇입니까?**

서명 후 프레젠테이션 내용이나 서명 데이터를 변경하면 서명이 무효화됩니다. 파일 손상도 검증 실패의 원인이 될 수 있습니다. 모든 서명을 제거하면 프레젠테이션은 서명되지 않은 상태가 되며, 이는 무효 서명이 포함된 파일과 다릅니다.

**유효한 서명이 서명자를 신뢰해야 함을 의미합니까?**

그 자체만으로는 아닙니다. 서명 무결성과 서명자 신뢰는 별개의 판단입니다. 실제 검증 정책에서는 인증서 체인, 유효 기간, 폐기 상태, 예상 신원, 키 사용 및 신뢰된 타임스탬프 요구사항 등을 추가로 확인해야 합니다.

**인증서가 만료되면 어떻게 됩니까?**

인증서 만료는 프레젠테이션 바이트 자체를 변경하지 않지만, 인증서 신뢰 평가에 영향을 줍니다. 서명이 허용되는지는 정책과 유효한 신뢰 타임스탬프가 서명 시점에 인증서가 유효했음을 증명하는지에 따라 달라집니다. 표시된 서명 시간만을 신뢰 타임스탬프로 활용하지 마세요.

**서명된 프레젠테이션을 여전히 편집할 수 있나요?**

예. 서명은 파일을 잠그지 않습니다. 서명된 내용을 편집하면 기존 서명이 일반적으로 무효화되므로, 먼저 프레젠테이션을 완성하고 최종 버전에 서명하세요.

**프레젠테이션에 여러 서명을 포함할 수 있나요?**

예. 저장하기 전에 [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getDigitalSignatures)에서 반환된 컬렉션에 각 서명을 추가하세요. 검증 시 모든 서명을 검사하고 필요한 서명자가 모두 존재하는지 확인합니다.

**어떤 프레젠테이션 형식이 이 작업을 지원합니까?**

Aspose.Slides는 여기서 설명하는 디지털 서명 작업을 PPTX 형식에만 지원합니다. PPT 및 OpenDocument 프레젠테이션 형식은 이 API 워크플로에서 지원되지 않습니다.

**슬라이드에 영향을 주지 않고 서명을 제거할 수 있나요?**

예. 하나의 서명만 제거하거나 전체 컬렉션을 비운 뒤 프레젠테이션을 저장하면 슬라이드 내용은 그대로 유지되지만, 저장된 파일에는 제거된 서명 증거가 남지 않습니다.