---
title: Python에서 프레젠테이션에 디지털 서명 추가
linktitle: 디지털 서명
type: docs
weight: 10
url: /ko/python-net/digital-signature-in-powerpoint/
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
- Python
- Aspose.Slides
description: "PFX 인증서를 사용하여 기존 PPTX 프레젠테이션에 서명하고, .NET을 통해 Python용 Aspose.Slides를 이용해 디지털 서명을 검증하거나 제거하는 방법을 배웁니다."
---
## **개요**

디지털 서명은 수신자가 누가 프레젠테이션에 서명했는지 및 서명된 내용이 변경되었는지 확인하는 데 도움을 줍니다. 여기서는 세 가지 관련 보안 개념이 중요합니다:

- **디지털 인증서**는 신원을 공개 키와 연결하는 전자 증명서입니다. 신뢰할 수 있는 인증 기관(CA)이 인증서를 발급할 수 있으며, 조직은 내부 워크플로에 대해 자체 서명 인증서를 사용할 수 있습니다.
- **디지털 서명**은 프레젠테이션 내용과 인증서 소유자의 개인 키를 사용하여 생성됩니다. 그런 다음 인증서의 공개 키를 사용해 서명을 검증할 수 있습니다. 서명은 출처와 무결성을 증명하지만 프레젠테이션을 암호화하지는 않습니다.
- **비밀번호 보호**는 사용자가 프레젠테이션을 열거나 수정할 수 있는지를 제어합니다. 이는 디지털 서명과 별개이며 [비밀번호 보호된 프레젠테이션](/python-net/password-protected-presentation/)에 설명되어 있습니다.

PowerPoint는 **File > Info > Protect Presentation** 아래에 **Add a Digital Signature** 명령을 제공합니다.

![PowerPoint Protect Presentation 메뉴에서 Add a Digital Signature가 강조된 모습](add-digital-signature-in-powerpoint.png)

서명된 프레젠테이션을 연 후 PowerPoint는 서명 상태 알림을 표시할 수 있습니다.

![PowerPoint 알림: 프레젠테이션에 유효한 서명이 포함되어 있습니다](digital-signature-status-in-powerpoint.png)

Aspose.Slides는 [Presentation.digital_signatures](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/digital_signatures/)을 통해 서명을 노출합니다. 이는 [DigitalSignatureCollection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/digitalsignaturecollection/)이며, 항목은 [DigitalSignature](https://reference.aspose.com/slides/ko/python-net/aspose.slides/digitalsignature/) 객체입니다. 프레젠테이션은 여러 서명을 포함할 수 있습니다.

## **PFX 인증서와 비밀번호 이해**

PFX 파일은 PKCS#12 파일이라고도 하며 일반적으로 `.pfx` 또는 `.p12` 확장자를 갖습니다. 여기에는 X.509 인증서, 해당 개인 키 및 인증서 체인이 포함될 수 있습니다. 개인 키는 소유자가 서명을 만들 수 있게 해줍니다. 접근 가능한 개인 키가 없는 인증서는 프레젠테이션에 서명하는 데 사용할 수 없습니다.

PFX 비밀번호는 인증서 패키지와 개인 키를 보호합니다. 이는 프레젠테이션을 열거나 편집하기 위한 비밀번호가 **아닙니다**. PFX 파일이나 비밀번호를 소스 컨트롤에 커밋하지 마세요. 운영 환경에서는 인증서 파일에 대한 접근을 제한하고 비밀번호를 비밀 저장소나 다른 보호된 구성 소스에서 가져와야 합니다. 아래 예제에서는 비밀번호를 코드에 직접 포함하지 않기 위해 환경 변수를 사용합니다.

## **프레젠테이션에 디지털 서명 추가**

실제 프레젠테이션 워크플로에 서명하려면 기존 PPTX 파일을 로드하고, PFX 인증서와 비밀번호로부터 [DigitalSignature](https://reference.aspose.com/slides/ko/python-net/aspose.slides/digitalsignature/)을 만든 다음, 서명을 프레젠테이션 컬렉션에 추가하고 PPTX 파일로 저장합니다.

```python
import os
import aspose.slides as slides

certificate_password = os.environ.get("PFX_PASSWORD")
if certificate_password is None:
    raise RuntimeError("Set the PFX_PASSWORD environment variable.")

with slides.Presentation("InputPresentation.pptx") as presentation:
    signature = slides.DigitalSignature("signing-certificate.pfx", certificate_password)
    signature.comments = "Approved for release."

    presentation.digital_signatures.add(signature)
    presentation.save("InputPresentation-signed.pptx", slides.export.SaveFormat.PPTX)
```

새 이름으로 저장하면 서명되지 않은 원본 파일을 보존할 수 있습니다. [DigitalSignature.comments](https://reference.aspose.com/slides/ko/python-net/aspose.slides/digitalsignature/comments/) 값은 서명의 목적을 설명할 뿐, 보안 제어가 아닙니다.

## **디지털 서명 검증**

서명된 PPTX 파일을 로드할 때 [Presentation.digital_signatures](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/digital_signatures/)의 모든 항목을 검사합니다. [DigitalSignature.is_valid](https://reference.aspose.com/slides/ko/python-net/aspose.slides/digitalsignature/is_valid/) 속성은 포함된 서명이 현재 프레젠테이션 내용에 대해 유효한지 여부를 나타냅니다.

```python
import hashlib
import aspose.slides as slides

with slides.Presentation("InputPresentation-signed.pptx") as presentation:
    signature_count = len(presentation.digital_signatures)

    if signature_count == 0:
        print("The presentation does not contain digital signatures.")
    else:
        all_signatures_are_valid = True

        for signature in presentation.digital_signatures:
            signature_status = "VALID" if signature.is_valid else "INVALID"
            certificate_fingerprint = hashlib.sha256(signature.certificate).hexdigest().upper()
            signing_time = signature.sign_time.strftime("%Y-%m-%d %H:%M:%S")

            print(
                f"Certificate SHA-256: {certificate_fingerprint}, "
                f"{signing_time} -- {signature_status}"
            )

            all_signatures_are_valid = (all_signatures_are_valid and signature.is_valid)

        if all_signatures_are_valid:
            print("All embedded signatures are valid for the current presentation.")
        else:
            print("At least one embedded signature is invalid.")
```

유효하지 않은 결과는 일반적으로 서명 후 프레젠테이션 내용이나 서명 데이터가 변경되었거나 파일이 손상되었음을 의미합니다. 모든 서명을 제거하면 서명되지 않은 프레젠테이션이 되므로, 항목의 유효성만 확인하는 것으로는 충분하지 않습니다. 보안이 중요한 워크플로에서는 기대하는 서명 수와 서명자 신원이 모두 존재하는지도 확인해야 합니다.

[DigitalSignature.certificate](https://reference.aspose.com/slides/ko/python-net/aspose.slides/digitalsignature/certificate/) 속성은 인증서 데이터를 바이트 배열로 제공합니다. 예제에서는 SHA-256 지문을 계산해 애플리케이션에서 기대하는 서명자 인증서의 지문과 비교할 수 있게 합니다.

이 유효성 결과만으로 전체 인증서 신뢰 판단을 내리면 안 됩니다. 보안 정책에 따라 애플리케이션은 X.509 인증서 체인을 구축·검증하고, 인증서 유효 기간·폐기 상태를 확인하며, 기대하는 주체 또는 지문을 확인하고, 키 사용을 검증하며, 신뢰된 타임스탬프를 평가해야 할 수 있습니다. [DigitalSignature.sign_time](https://reference.aspose.com/slides/ko/python-net/aspose.slides/digitalsignature/sign_time/) 값 자체는 신뢰된 타임스탬프 기관의 증명이 아닙니다.

## **디지털 서명 제거**

서명을 제거하면 프레젠테이션의 보안 상태가 변경됩니다. 다음 예제는 서명된 PPTX 파일을 로드하고, [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/ko/python-net/aspose.slides/digitalsignaturecollection/clear/) 로 모든 서명을 제거한 뒤, 서명되지 않은 복사본을 저장합니다.

```python
import aspose.slides as slides

with slides.Presentation("InputPresentation-signed.pptx") as presentation:
    presentation.digital_signatures.clear()
    presentation.save("InputPresentation-unsigned.pptx", slides.export.SaveFormat.PPTX)
```

하나의 서명만 제거하려면 해당 서명의 0 기반 인덱스를 사용해 [DigitalSignatureCollection.remove_at](https://reference.aspose.com/slides/ko/python-net/aspose.slides/digitalsignaturecollection/remove_at/) 를 호출합니다. 서명된 원본을 덮어쓰는 것이 명시적인 워크플로의 일부가 아니라면 새 파일에 저장하세요.

## **편집 및 형식 고려 사항**

- 서명은 프레젠테이션을 읽기 전용으로 만들지 않습니다. 사용자는 여전히 파일을 편집할 수 있지만, 서명된 내용이 변경되면 기존 서명이 보통 무효화됩니다.
- 서명 전에 모든 편집을 완료하세요. 프레젠테이션을 다시 변경해야 하는 경우, 수정된 프레젠테이션을 저장하고 그 개정본에 다시 서명합니다.
- 최종 출력은 PPTX 형식으로 유지하세요. 서명된 프레젠테이션을 다른 형식으로 변환하면 원본 PPTX 서명이 변환된 파일에 대한 유효한 서명으로 전달되지 않습니다.
- 인증서의 개인 키는 민감한 정보로 다루세요. 개인 키와 비밀번호를 입수한 사람은 해당 인증서 소유자처럼 서명을 만들 수 있습니다.
- 문서 보존 정책에 따라 서명되지 않은 원본 또는 다른 통제된 복사본을 보관하세요.

## **FAQ**

**디지털 서명이 프레젠테이션을 암호화합니까?**

아니요. 디지털 서명은 출처와 무결성을 증명하지만, 별도의 암호화가 적용되지 않는 한 프레젠테이션 내용은 읽을 수 있습니다. 콘텐츠 접근을 제한해야 할 경우 [비밀번호 보호](/python-net/password-protected-presentation/)를 사용하세요.

**PFX 비밀번호가 프레젠테이션 비밀번호와 동일합니까?**

아니요. PFX 비밀번호는 인증서 패키지에 저장된 개인 키를 풀어주는 역할을 합니다. PPTX 파일을 열거나 편집할 수 있는지를 제어하지 않습니다.

**자체 서명 인증서를 사용할 수 있습니까?**

기술적으로는 접근 가능한 개인 키가 포함된 경우 자체 서명 인증서를 사용할 수 있습니다. 다만 수신자가 자동으로 신뢰하지는 않으며, 해당 인증서를 신뢰 환경에 명시적으로 추가해야 합니다. 공개 또는 조직 간 워크플로에서는 일반적으로 신뢰할 수 있는 CA에서 발급한 인증서를 사용합니다.

**서명이 무효가 되는 경우는 무엇입니까?**

서명 후 프레젠테이션 내용이나 서명 데이터를 변경하면 서명이 무효화될 수 있습니다. 파일 손상도 검증 실패의 원인이 됩니다. 모든 서명을 제거하면 프레젠테이션은 서명되지 않은 상태가 되며, 이는 “무효 서명”이 아니라 “서명 없음”입니다.

**유효한 서명이 신뢰할 수 있다는 의미입니까?**

그 자체만으로는 아닙니다. 서명 무결성과 서명자 신뢰는 별개의 판단입니다. 실제 검증 정책에서는 인증서 체인, 유효 기간, 폐기 상태, 기대 신원, 키 사용 및 필요한 경우 신뢰된 타임스탬프 등을 추가로 확인해야 합니다.

**인증서가 만료되면 어떻게 됩니까?**

인증서 만료는 프레젠테이션 바이트 자체를 변경하지 않지만, 인증서 신뢰 평가에 영향을 줍니다. 서명이 허용되는지는 정책 및 유효한 신뢰 타임스탬프가 서명 시점에 인증서가 유효했음을 입증하는지에 따라 달라집니다. 표시된 서명 시간을 신뢰된 타임스탬프로만 의존하지 마세요.

**서명된 프레젠테이션을 여전히 편집할 수 있습니까?**

예. 서명은 파일을 잠그지 않습니다. 서명된 내용을 편집하면 기존 서명이 일반적으로 무효화되므로, 프레젠테이션을 먼저 완성하고 최종 개정본에 서명하세요.

**프레젠테이션에 여러 서명을 포함할 수 있습니까?**

예. 저장하기 전에 각 서명을 [Presentation.digital_signatures](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/digital_signatures/)에 추가하세요. 검증 시 모든 서명을 검사하고 필요한 모든 서명자가 존재하는지 확인합니다.

**어떤 프레젠테이션 형식이 이 작업을 지원합니까?**

Aspose.Slides는 여기서 설명한 디지털 서명 작업을 PPTX 형식에만 지원합니다. PPT 및 OpenDocument 프레젠테이션 형식은 이 API 워크플로에서 지원되지 않습니다.

**슬라이드에 영향을 주지 않고 서명을 제거할 수 있습니까?**

예. 하나의 서명을 제거하거나 전체 컬렉션을 비운 후 프레젠테이션을 저장하면 됩니다. 슬라이드 내용은 그대로 유지되지만 저장된 파일에는 제거된 서명에 대한 증거가 남지 않습니다.