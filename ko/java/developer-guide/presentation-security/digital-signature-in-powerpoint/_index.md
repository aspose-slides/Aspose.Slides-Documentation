---
title: Java에서 프레젠테이션에 디지털 서명 추가
linktitle: 디지털 서명
type: docs
weight: 10
url: /ko/java/digital-signature-in-powerpoint/
keywords:
- 디지털 서명
- 디지털 인증서
- 인증 기관
- PFX 인증서
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 PowerPoint 및 OpenDocument 파일에 디지털 서명하는 방법을 배웁니다. 명확한 코드 예제로 몇 초 만에 슬라이드를 보호하세요."
---
## **Introduction**

**디지털 인증서**는 비밀번호로 보호된 PowerPoint 프레젠테이션을 만들 때 사용되며, 특정 조직이나 사람에 의해 만든 것으로 표시됩니다. 디지털 인증서는 인증 기관이라는 권한 있는 조직에 연락하여 얻을 수 있습니다. 시스템에 디지털 인증서를 설치한 후에는 파일 -> 정보 -> 프레젠테이션 보호를 통해 프레젠테이션에 디지털 서명을 추가할 수 있습니다:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

프레젠테이션에는 하나 이상의 디지털 서명이 포함될 수 있습니다. 디지털 서명이 프레젠테이션에 추가되면 PowerPoint에 특수 메시지가 표시됩니다:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

프레젠테이션에 서명하거나 프레젠테이션 서명의 진위 여부를 확인하려면 **Aspose.Slides API**가 [**IDigitalSignature**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IDigitalSignature) 인터페이스, [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IDigitalSignatureCollection) 인터페이스 및 [**IPresentation.getDigitalSignatures**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IPresentation#getDigitalSignatures--) 메서드를 제공합니다. 현재 디지털 서명은 PPTX 형식에서만 지원됩니다.

## **PFX 인증서에서 디지털 서명 추가**

아래 코드 샘플은 PFX 인증서에서 디지털 서명을 추가하는 방법을 보여줍니다:

1. PFX 파일을 열고 PFX 비밀번호를 [**DigitalSignature**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/DigitalSignature) 객체에 전달합니다.
2. 생성된 서명을 프레젠테이션 객체에 추가합니다.

```java
// 프레젠테이션 파일 열기
Presentation pres = new Presentation();
try {
    // PFX 파일과 PFX 비밀번호로 DigitalSignature 객체 생성
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", "testpass1");

    // 새 디지털 서명에 대한 주석
    signature.setComments("Aspose.Slides digital signing test.");

    // 프레젠테이션에 디지털 서명 추가
    pres.getDigitalSignatures().add(signature);

    // 프레젠테이션 저장
    pres.save("SomePresentationSigned.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

이제 프레젠테이션이 디지털 서명되었으며 수정되지 않았는지 확인할 수 있습니다:

```java
// 프레젠테이션 열기
Presentation pres = new Presentation("SomePresentationSigned.pptx");
try {
    if (pres.getDigitalSignatures().size() > 0)
    {
        boolean allSignaturesAreValid = true;

        System.out.println("Signatures used to sign the presentation: ");

        // 모든 디지털 서명이 유효한지 확인
        for (IDigitalSignature signature : pres.getDigitalSignatures())
        {
            System.out.println(signature.getComments() + ", "
                    + signature.getSignTime().toString() + " -- " + (signature.isValid() ? "VALID" : "INVALID"));
            allSignaturesAreValid &= signature.isValid();
        }

        if (allSignaturesAreValid)
            System.out.println("Presentation is genuine, all signatures are valid.");
        else
            System.out.println("Presentation has been modified since signing.");
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **자주 묻는 질문**

**파일에서 기존 서명을 제거할 수 있나요?**

예. 디지털 서명 컬렉션은 개별 항목을 [제거](https://reference.aspose.com/slides/ko/java/com.aspose.slides/digitalsignaturecollection/#removeAt-int-)할 수 있으며 전체를 [전체 삭제](https://reference.aspose.com/slides/ko/java/com.aspose.slides/digitalsignaturecollection/#clear--)할 수도 있습니다. 파일을 저장하면 프레젠테이션에 서명이 전혀 없게 됩니다.

**서명 후 파일이 "읽기 전용"이 되나요?**

아니요. 서명은 무결성과 저작자를 보존하지만 편집을 차단하지는 않습니다. 편집을 제한하려면 ["읽기 전용" 또는 비밀번호](/slides/ko/java/password-protected-presentation/)와 결합하십시오.

**서명이 다양한 PowerPoint 버전에서 올바르게 표시되나요?**

서명은 OOXML (PPTX) 컨테이너용으로 생성됩니다. OOXML 서명을 지원하는 최신 PowerPoint 버전은 이러한 서명의 상태를 올바르게 표시합니다.