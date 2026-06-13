---
title: Python으로 프레젠테이션에 디지털 서명 추가
linktitle: 디지털 서명
type: docs
weight: 10
url: /ko/python-net/digital-signature-in-powerpoint/
keywords:
- 디지털 서명
- 디지털 인증서
- 인증 기관
- PFX 인증서
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Python 용 Aspose.Slides(.NET)를 사용해 PowerPoint 및 OpenDocument 파일에 디지털 서명을 적용하는 방법을 배웁니다. 명확한 코드 예제로 몇 초 만에 슬라이드를 안전하게 보호하세요."
---
## **소개**

**Digital certificate**는 비밀번호가 보호된 PowerPoint 프레젠테이션을 만들 때 사용되며, 특정 조직이나 사람이 만든 것으로 표시됩니다. Digital certificate는 인증 기관과 연락하여 얻을 수 있습니다. 시스템에 Digital certificate를 설치한 후에는 File -> Info -> Protect Presentation을 통해 프레젠테이션에 디지털 서명을 추가할 수 있습니다.

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

프레젠테이션에는 여러 개의 디지털 서명이 포함될 수 있습니다. 디지털 서명이 프레젠테이션에 추가되면 PowerPoint에 다음과 같은 특수 메시지가 표시됩니다.

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

프레젠테이션에 서명을 추가하거나 서명의 진위 여부를 확인하려면 **Aspose.Slides API**가 제공하는 [**DigitalSignature**](https://reference.aspose.com/slides/ko/python-net/aspose.slides/digitalsignature/) 클래스, [**DigitalSignatureCollection**](https://reference.aspose.com/slides/ko/python-net/aspose.slides/DigitalSignatureCollection/) 클래스 및 [**Presentation.digital_signatures**](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/digital_signatures/) 속성을 사용할 수 있습니다. 현재 디지털 서명은 PPTX 형식에서만 지원됩니다.

## **PFX 인증서에서 디지털 서명 추가**

아래 코드 샘플은 PFX 인증서에서 디지털 서명을 추가하는 방법을 보여줍니다.

1. PFX 파일을 열고 PFX 비밀번호를 [**DigitalSignature**](https://reference.aspose.com/slides/ko/python-net/aspose.slides/digitalsignature/) 객체에 전달합니다.
1. 만든 서명을 프레젠테이션 객체에 추가합니다.

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    # PFX 파일과 PFX 비밀번호로 DigitalSignature 객체 생성 
    signature = slides.DigitalSignature(path + "testsignature1.pfx", "testpass1")

    # 새 디지털 서명에 대한 주석
    signature.comments = "Aspose.Slides digital signing test."

    # 프레젠테이션에 디지털 서명 추가
    pres.digital_signatures.add(signature)

    # 프레젠테이션 저장
    pres.save("SomePresentationSigned.pptx", slides.export.SaveFormat.PPTX)
```

이제 프레젠테이션이 디지털 서명되었고 수정되지 않았는지 확인할 수 있습니다.

```py
# 프레젠테이션 열기
with slides.Presentation("SomePresentationSigned.pptx") as pres:
    if len(pres.digital_signatures) > 0:
        allSignaturesAreValid = True

        print("Signatures used to sign the presentation: ")
        # 모든 디지털 서명이 유효한지 확인
        for signature in pres.digital_signatures :
            print(signature.certificate.subject_name.name + ", "
                    + signature.sign_time.strftime("yyyy-MM-dd HH:mm") + " -- " + "VALID" if signature.is_valid else "INVALID")
            allSignaturesAreValid = allSignaturesAreValid and signature.is_valid
        

        if allSignaturesAreValid:
            print("Presentation is genuine, all signatures are valid.")
        else:
            print("Presentation has been modified since signing.")
```

## **FAQ**

**파일에서 기존 서명을 제거할 수 있나요?**

예. 디지털 서명 컬렉션은 [개별 항목 제거](https://reference.aspose.com/slides/ko/python-net/aspose.slides/digitalsignaturecollection/remove_at/)와 [전체 삭제](https://reference.aspose.com/slides/ko/python-net/aspose.slides/digitalsignaturecollection/clear/)를 지원합니다. 파일을 저장하면 프레젠테이션에 서명이 남지 않습니다.

**서명 후 파일이 “읽기 전용”이 되나요?**

아니요. 서명은 무결성과 저자를 보존하지만 편집을 차단하지는 않습니다. 편집을 제한하려면 ["읽기 전용" 또는 비밀번호](/slides/ko/python-net/password-protected-presentation/)와 결합하세요.

**다양한 PowerPoint 버전에서 서명이 정상적으로 표시되나요?**

이 서명은 OOXML(PPTX) 컨테이너용으로 생성되었습니다. OOXML 서명을 지원하는 최신 PowerPoint 버전에서는 해당 서명의 상태가 올바르게 표시됩니다.