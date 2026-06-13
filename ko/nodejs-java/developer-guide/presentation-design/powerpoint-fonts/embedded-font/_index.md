---
title: JavaScript를 사용하여 프레젠테이션에 폰트 임베드하기
linktitle: 폰트 임베드
type: docs
weight: 40
url: /ko/nodejs-java/embedded-font/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Java를 통해 Node.js용 Aspose.Slides로 PowerPoint 및 OpenDocument 프레젠테이션에 TrueType 폰트를 임베드하여 모든 플랫폼에서 정확한 렌더링을 보장합니다."
---
## **소개**

**PowerPoint의 임베디드 폰트**는 프레젠테이션을 어떤 시스템이나 장치에서 열어도 올바르게 표시되도록 할 때 유용합니다. 작업에 창의성을 더하기 위해 타사 또는 비표준 폰트를 사용했다면 폰트를 임베드해야 할 이유가 더욱 많아집니다. 그렇지 않으면(임베디드 폰트가 없을 경우) 슬라이드의 텍스트나 숫자, 레이아웃, 스타일 등이 변경되거나 혼란스러운 사각형으로 표시될 수 있습니다.  

[FontsManager](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/FontsManager) 클래스, [FontData](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontdata/) 클래스, [Compress](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/compress/) 클래스와 해당 클래스들은 PowerPoint 프레젠테이션에서 임베디드 폰트를 다루는 데 필요한 대부분의 속성과 메서드를 포함합니다.

## **프레젠테이션에서 임베디드 폰트 가져오기 또는 제거하기**

Aspose.Slides는 프레젠테이션에 임베드된 폰트를 가져오거나(확인) 할 수 있도록 [FontsManager](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/FontsManager) 클래스에서 제공하는 [getEmbeddedFonts](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) 메서드를 제공합니다. 폰트를 제거하려면 동일한 클래스에서 제공하는 [removeEmbeddedFont](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontsmanager/#removeEmbeddedFont-aspose.slides.IFontData-) 메서드를 사용합니다.

이 JavaScript 코드는 프레젠테이션에서 임베디드 폰트를 가져오고 제거하는 방법을 보여줍니다:

```javascript
// 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다
var pres = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    // 임베드된 "FunSized"를 사용하는 텍스트 프레임이 포함된 슬라이드를 렌더링합니다
    var slideImage = pres.getSlides().get_Item(0).getImage(java.newInstanceSync("java.awt.Dimension", 960, 720));
    // 이미지를 JPEG 형식으로 디스크에 저장합니다
    try {
        slideImage.save("picture1_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    var fontsManager = pres.getFontsManager();
    // 모든 임베드된 폰트를 가져옵니다
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    // "Calibri" 폰트를 찾습니다
    var calibriEmbeddedFont = null;
    for (var i = 0; i < embeddedFonts.length; i++) {
        console.log("" + embeddedFonts[i].getFontName());
        if ("Calibri" == embeddedFonts[i].getFontName()) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }
    // "Calibri" 폰트를 제거합니다
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);
    // 프레젠테이션을 렌더링합니다; "Calibri" 폰트가 기존 폰트로 대체됩니다
    slideImage = pres.getSlides().get_Item(0).getImage(java.newInstanceSync("java.awt.Dimension", 960, 720));
    // 이미지를 JPEG 형식으로 디스크에 저장합니다
    try {
        slideImage.save("picture2_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    // 임베드된 "Calibri" 폰트 없이 프레젠테이션을 디스크에 저장합니다
    pres.save("WithoutManageEmbeddedFonts_out.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **프레젠테이션에 임베디드 폰트 추가하기**

[EmbedFontCharacters](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/embedfontcharacters/) 열거형과 [addEmbeddedFont](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontsmanager/#addEmbeddedFont-aspose.slides.IFontData-int-) 메서드의 두 오버로드를 사용하여 프레젠테이션에 폰트를 임베드하기 위한 원하는(임베드) 규칙을 선택할 수 있습니다. 이 JavaScript 코드는 프레젠테이션에 폰트를 임베드하고 추가하는 방법을 보여줍니다:

```javascript
// 프레젠테이션을 로드합니다
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    var allFonts = pres.getFontsManager().getFonts();
    var embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
    allFonts.forEach(font => {
        var embeddedFontsContainsFont = false;
        for (var i = 0; i < embeddedFonts.length; i++) {
            if (embeddedFonts[i].equals(font)) {
                embeddedFontsContainsFont = true;
                break;
            }
        }
        if (!embeddedFontsContainsFont) {
            pres.getFontsManager().addEmbeddedFont(font, aspose.slides.EmbedFontCharacters.All);
            embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
        }
    });
    // 프레젠테이션을 디스크에 저장합니다
    pres.save("AddEmbeddedFont_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **임베디드 폰트 압축하기**

프레젠테이션에 임베드된 폰트를 압축하여 파일 크기를 줄일 수 있도록 Aspose.Slides는 [Compress](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/compress/) 클래스에서 제공하는 [compressEmbeddedFonts](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/compress/#compressEmbeddedFonts-aspose.slides.Presentation-) 메서드를 제공합니다.

이 JavaScript 코드는 임베디드 PowerPoint 폰트를 압축하는 방법을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    aspose.slides.Compress.compressEmbeddedFonts(pres);
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**프레젠테이션에서 특정 폰트가 임베드되었음에도 렌더링 시 대체되는지 어떻게 알 수 있나요?**  
폰트 관리자에서 [substitution information](/slides/ko/nodejs-java/font-substitution/)와 [fallback/substitution rules](/slides/ko/nodejs-java/fallback-font/)를 확인하세요. 폰트를 사용할 수 없거나 제한된 경우 대체 폰트가 사용됩니다.

**Arial/Calibri와 같은 "시스템" 폰트를 임베드할 가치가 있나요?**  
보통은 아닙니다—대부분 언제나 사용 가능하기 때문입니다. 그러나 Docker와 같이 폰트가 사전 설치되지 않은 Linux 서버와 같은 “경량” 환경에서 완전한 이식성을 확보하려면 시스템 폰트를 임베드하면 예상치 못한 대체 위험을 없앨 수 있습니다.