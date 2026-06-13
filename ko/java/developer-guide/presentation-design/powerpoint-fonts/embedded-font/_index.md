---
title: Java를 사용한 프레젠테이션에 폰트 임베드
linktitle: 폰트 임베드
type: docs
weight: 40
url: /ko/java/embedded-font/
keywords:
- 폰트 추가
- 폰트 임베드
- 폰트 임베딩
- 임베드된 폰트 가져오기
- 임베드된 폰트 추가
- 임베드된 폰트 제거
- 임베드된 폰트 압축
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에 TrueType 폰트를 임베드하여 모든 플랫폼에서 정확한 렌더링을 보장합니다."
---
## **소개**

**PowerPoint의 임베디드 폰트**는 프레젠테이션을 어떤 시스템이나 장치에서도 올바르게 표시하고 싶을 때 유용합니다. 작업에 창의성을 더하기 위해 서드 파티 또는 비표준 폰트를 사용했다면 폰트를 임베드할 이유가 더 많아집니다. 임베디드 폰트가 없으면 슬라이드의 텍스트나 숫자, 레이아웃, 스타일 등이 변경되거나 알아보기 힘든 사각형으로 표시될 수 있습니다.

The [FontsManager](https://reference.aspose.com/slides/ko/java/com.aspose.slides/FontsManager) class, [FontData](https://reference.aspose.com/slides/ko/java/com.aspose.slides/fontdata/) class, [Compress](https://reference.aspose.com/slides/ko/java/com.aspose.slides/compress/) class, and their interfaces contain most of the properties and methods you need to work with embedded fonts in PowerPoint presentations.

## **임베디드 폰트 가져오기 및 제거**

Aspose.Slides는 프레젠테이션에 임베드된 폰트를 가져오거나 확인할 수 있도록 [getEmbeddedFonts](https://reference.aspose.com/slides/ko/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) 메서드([FontsManager](https://reference.aspose.com/slides/ko/java/com.aspose.slides/FontsManager) 클래스에 노출)를 제공합니다. 폰트를 제거하려면 같은 클래스의 [removeEmbeddedFont](https://reference.aspose.com/slides/ko/java/com.aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) 메서드를 사용합니다.

이 Java 코드에서는 프레젠테이션에서 임베디드 폰트를 가져오고 제거하는 방법을 보여줍니다:

```java
// 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다
Presentation pres = new Presentation("EmbeddedFonts.pptx");
try {
    // 임베드된 "FunSized"를 사용하는 텍스트 프레임을 포함한 슬라이드를 렌더링합니다
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

    //이미지를 JPEG 형식으로 디스크에 저장합니다
    try {
        slideImage.save("picture1_out.jpg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }

    IFontsManager fontsManager = pres.getFontsManager();

    // 모든 임베드된 폰트를 가져옵니다
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();

    // "Calibri" 폰트를 찾습니다
    IFontData calibriEmbeddedFont = null;
    for (int i = 0; i < embeddedFonts.length; i++) {
        System.out.println(""+ embeddedFonts[i].getFontName());
        if ("Calibri".equals(embeddedFonts[i].getFontName())) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }

    // "Calibri" 폰트를 제거합니다
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);

    // 프레젠테이션을 렌더링합니다; "Calibri" 폰트가 기존 폰트로 대체됩니다
     slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

     //이미지를 JPEG 형식으로 디스크에 저장합니다
     try {
         slideImage.save("picture2_out.jpg", ImageFormat.Jpeg);
     } finally {
         if (slideImage != null) slideImage.dispose();
     }

    // 임베드된 "Calibri" 폰트 없이 프레젠테이션을 디스크에 저장합니다
    pres.save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
} finally {
    if (pres != null) pres.dispose();
}
```

## **임베디드 폰트 추가**

[EmbedFontCharacters](https://reference.aspose.com/slides/ko/java/com.aspose.slides/embedfontcharacters/) 열거형과 [addEmbeddedFont](https://reference.aspose.com/slides/ko/java/com.aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) 메서드의 두 가지 오버로드를 사용하면 프레젠테이션에 폰트를 임베드하기 위한 선호 규칙을 선택할 수 있습니다. 이 Java 코드는 폰트를 임베드하고 추가하는 방법을 보여줍니다:

```java
// 프레젠테이션을 로드합니다
Presentation pres = new Presentation("Fonts.pptx");
try {
    IFontData[] allFonts = pres.getFontsManager().getFonts();
    IFontData[] embeddedFonts = pres.getFontsManager().getEmbeddedFonts();

    for (IFontData font : allFonts)
    {
        boolean embeddedFontsContainsFont = false;
        for (int i = 0; i < embeddedFonts.length; i++)
        {
            if (embeddedFonts[i].equals(font))
            {
                embeddedFontsContainsFont = true;
                break;
            }
        }
        if (!embeddedFontsContainsFont)
        {
            pres.getFontsManager().addEmbeddedFont(font, EmbedFontCharacters.All);

            embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
        }
    }

    // 프레젠테이션을 디스크에 저장합니다
    pres.save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **임베디드 폰트 압축**

프레젠테이션에 임베드된 폰트를 압축하고 파일 크기를 줄일 수 있도록 Aspose.Slides는 [compressEmbeddedFonts](https://reference.aspose.com/slides/ko/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) 메서드([Compress](https://reference.aspose.com/slides/ko/java/com.aspose.slides/compress/) 클래스에 노출)를 제공합니다.

이 Java 코드는 임베디드 PowerPoint 폰트를 압축하는 방법을 보여줍니다:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.compressEmbeddedFonts(pres);
    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**임베드된 폰트임에도 불구하고 프레젠테이션에서 특정 폰트가 렌더링 시 여전히 대체되는지 어떻게 확인할 수 있나요?**

폰트 매니저에서 [대체 정보](/slides/ko/java/font-substitution/)와 [대체/백업 규칙](/slides/ko/java/fallback-font/)을 확인하십시오. 폰트가 없거나 제한된 경우 백업 폰트가 사용됩니다.

**Arial/Calibri와 같은 "시스템" 폰트를 임베드하는 것이 가치가 있나요?**

대체로 필요하지 않습니다 — 대부분의 시스템에 항상 존재하기 때문입니다. 하지만 Docker와 같이 폰트가 사전 설치되지 않은 “슬림” 환경(리눅스 서버 등)에서 완전한 이식성을 확보하려면 시스템 폰트를 임베드하여 예기치 않은 대체 위험을 없앨 수 있습니다.