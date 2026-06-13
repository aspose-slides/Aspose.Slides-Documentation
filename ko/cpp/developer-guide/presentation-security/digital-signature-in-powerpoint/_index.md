---
title: C++에서 프레젠테이션에 디지털 서명 추가
linktitle: 디지털 서명
type: docs
weight: 10
url: /ko/cpp/digital-signature-in-powerpoint/
keywords:
- 디지털 서명
- 디지털 인증서
- 인증 기관
- PFX 인증서
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 및 OpenDocument 파일에 디지털 서명하는 방법을 배우세요. 명확한 코드 예제로 몇 초 만에 슬라이드를 보호할 수 있습니다."
---
## **소개**

**디지털 인증서**는 비밀번호로 보호된 PowerPoint 프레젠테이션을 만들 때 사용되며, 특정 기관이나 개인이 만든 것으로 표시됩니다. 디지털 인증서는 인증 기관(인증서 발급 기관)에 연락하여 얻을 수 있습니다. 시스템에 디지털 인증서를 설치한 후에는 파일 → 정보 → 프레젠테이션 보호를 통해 프레젠테이션에 디지털 서명을 추가할 수 있습니다:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

프레젠테이션에는 하나 이상의 디지털 서명이 포함될 수 있습니다. 디지털 서명이 프레젠테이션에 추가되면 PowerPoint에 특별한 메시지가 표시됩니다:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

프레젠테이션에 서명하거나 서명의 진위 여부를 확인하려면 **Aspose.Slides API**가 제공하는[**IDigitalSignature**](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_digital_signature) 인터페이스, [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_digital_signature_collection) 인터페이스 및[**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_presentation#a6f78aff0f8ffa07ff67368fa003722b1) 메서드를 사용할 수 있습니다. 현재 디지털 서명은 PPTX 형식에서만 지원됩니다.
## **PFX 인증서에서 디지털 서명 추가하기**
다음 코드는 PFX 인증서에서 디지털 서명을 추가하는 방법을 보여줍니다:

1. PFX 파일을 열고 PFX 비밀번호를 [**DigitalSignature**](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.digital_signature) 객체에 전달합니다.
2. 만든 서명을 프레젠테이션 객체에 추가합니다.

``` cpp
auto pres = System::MakeObject<Presentation>();

// PFX 파일 및 PFX 비밀번호로 DigitalSignature 객체 생성 
auto signature = System::MakeObject<DigitalSignature>(u"testsignature1.pfx", u"testpass1");

// 새 디지털 서명에 대한 코멘트
signature->set_Comments(u"Aspose.Slides digital signing test.");

// 프레젠테이션에 디지털 서명 추가
pres->get_DigitalSignatures()->Add(signature);

// 프레젠테이션 저장
pres->Save(u"SomePresentationSigned.pptx", SaveFormat::Pptx);
```

이제 프레젠테이션이 디지털 서명되었으며 수정되지 않았는지 확인할 수 있습니다:

``` cpp
// 프레젠테이션 열기
auto pres = System::MakeObject<Presentation>(u"SomePresentationSigned.pptx");

if (pres->get_DigitalSignatures()->get_Count() > 0)
{
    bool allSignaturesAreValid = true;

    Console::WriteLine(u"Signatures used to sign the presentation: ");

    // 모든 디지털 서명이 유효한지 확인
    for (auto signature : pres->get_DigitalSignatures())
    {
        Console::WriteLine(signature->get_Certificate()->get_SubjectName()->get_Name() 
            + u", " 
            + signature->get_SignTime().ToString(u"yyyy-MM-dd HH:mm") 
            + u" -- " 
            + (signature->get_IsValid() ? System::String(u"VALID") : System::String(u"INVALID")));
        allSignaturesAreValid &= signature->get_IsValid();
    }

    if (allSignaturesAreValid)
    {
        Console::WriteLine(u"Presentation is genuine, all signatures are valid.");
    }
    else
    {
        Console::WriteLine(u"Presentation has been modified since signing.");
    }
}
```

## **FAQ**

**파일에서 기존 서명을 제거할 수 있나요?**

예. 디지털 서명 컬렉션은 [개별 항목 제거](https://reference.aspose.com/slides/ko/cpp/aspose.slides/digitalsignaturecollection/removeat/)와 [전체 삭제](https://reference.aspose.com/slides/ko/cpp/aspose.slides/digitalsignaturecollection/clear/)를 지원합니다. 파일을 저장하면 프레젠테이션에 서명이 남지 않습니다.

**서명 후 파일이 "읽기 전용"이 되나요?**

아니요. 서명은 무결성과 저자를 보호하지만 편집을 차단하지는 않습니다. 편집을 제한하려면 ["읽기 전용" 또는 비밀번호](/slides/ko/cpp/password-protected-presentation/)와 함께 사용하십시오.

**다양한 PowerPoint 버전에서 서명이 정상적으로 표시됩니까?**

서명은 OOXML(PPTX) 컨테이너용으로 만들어졌습니다. OOXML 서명을 지원하는 최신 PowerPoint 버전에서는 해당 서명의 상태가 올바르게 표시됩니다.