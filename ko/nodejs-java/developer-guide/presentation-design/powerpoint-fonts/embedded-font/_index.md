---
title: JavaScript에서 프레젠테이션에 폰트 삽입
linktitle: 삽입된 폰트
type: docs
weight: 40
url: /ko/nodejs-java/embedded-font/
keywords:
- 폰트 추가
- 폰트 삽입
- 폰트 임베딩
- 삽입된 폰트 가져오기
- 삽입된 폰트 추가
- 삽입된 폰트 제거
- 삽입된 폰트 압축
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Java를 통해 Node.js용 Aspose.Slides로 PowerPoint의 삽입된 폰트를 관리합니다. 텍스트 모양을 유지하고 파일 크기를 줄이기 위해 폰트를 추가, 검색, 제거 및 압축합니다."
---
## **소개**

폰트 삽입은 폰트 데이터를 PowerPoint 프레젠테이션 내부에 저장합니다. 뷰어가 삽입된 폰트를 지원하면 대상 시스템에 폰트가 설치되어 있지 않더라도 해당 폰트로 텍스트를 표시할 수 있습니다. 이는 줄 바꿈, 텍스트 간격 및 슬라이드 레이아웃을 유지하는 데 도움이 됩니다.

Aspose.Slides for Node.js via Java를 사용하면 [FontsManager](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontsmanager/) 클래스(이 클래스는 [Presentation.getFontsManager](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/getfontsmanager/)에서 반환됨)를 통해 삽입된 폰트를 검색, 추가 및 제거할 수 있습니다. 또한 프레젠테이션에서 사용되지 않는 문자를 제거하여 삽입된 폰트 데이터의 크기를 줄일 수도 있습니다.

아래 예제는 PPTX 파일을 대상으로 합니다. 폰트를 삽입하기 전에 해당 폰트 데이터가 Aspose.Slides에서 사용할 수 있고 라이선스가 삽입을 허용하는지 확인하십시오.

## **삽입된 폰트 가져오기 및 제거**

[FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/)를 사용하여 프레젠테이션에 저장된 폰트를 나열합니다. 폰트를 하나 제거하려면 해당 목록에서 폰트를 선택해 [FontsManager.removeEmbeddedFont](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontsmanager/removeembeddedfont/)에 전달한 후 프레젠테이션을 저장합니다.

다음 예제는 `EmbeddedFonts.pptx`에 삽입된 폰트를 나열하고 Calibri가 존재하면 제거합니다:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var embeddedFonts = fontsManager.getEmbeddedFonts();

    for (var i = 0; i < embeddedFonts.length; i++) {
        console.log(embeddedFonts[i].getFontName());
    }

    var fontToRemove = null;
    for (var i = 0; i < embeddedFonts.length; i++) {
        if (String(embeddedFonts[i].getFontName()).toLowerCase() === "calibri") {
            fontToRemove = embeddedFonts[i];
            break;
        }
    }

    if (fontToRemove !== null) {
        fontsManager.removeEmbeddedFont(fontToRemove);
        presentation.save("WithoutEmbeddedCalibri.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("Calibri is not embedded. No output file was created.");
    }
} finally {
    presentation.dispose();
}
```

삽입된 폰트를 제거하면 해당 폰트의 저장된 데이터가 삭제되지만 텍스트에 할당된 폰트는 변경되지 않습니다. 대상 시스템에 폰트가 설치되어 있으면 텍스트는 여전히 해당 폰트를 사용할 수 있습니다. 그렇지 않으면 렌더링 시 [font substitution](/slides/ko/nodejs-java/font-substitution/)이 필요할 수 있으며, 이는 레이아웃에 영향을 줄 수 있습니다.

## **폰트 데이터 및 삽입 권한 검사**

[FontsManager](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontsmanager/) 클래스를 사용하여 폰트를 삽입하기 전에 검토합니다. 프레젠테이션에서 사용된 폰트를 가져오려면 [FontsManager.getFonts](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontsmanager/getfonts/)를 호출합니다. 각 폰트에 대해 [FontData](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontdata/) 개체와 필요한 [FontStyleType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontstyletype/) 값을 [FontsManager.getFontBytes](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontsmanager/#getFontBytes) 에 전달합니다. 이 메서드는 해당 폰트 스타일의 바이너리 데이터를 반환하거나, 요청한 폰트 또는 스타일이 없을 경우 `null`을 반환합니다. `null` 결과를 [FontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel) 에 전달하지 마십시오. 해당 메서드는 바이트 배열을 필요로 합니다. Node.js에서는 반환된 JavaScript 배열을 `java.newArray`를 사용해 Java 바이트 배열로 변환한 후 `getFontEmbeddingLevel`에 전달합니다.

[EmbeddingLevel](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/embeddinglevel/)은 폰트에 저장된 삽입 제한을 플래그 집합으로 보고합니다:

- `Installable`은 폰트 라이선스에 따라 다른 시스템에 삽입 및 영구 설치를 허용합니다.
- `Restricted`는 사용 권한 플래그가 하나뿐인 경우 폰트 소유자의 허가를 받지 않으면 삽입을 금지합니다.
- `PreviewPrint`는 보기 및 인쇄를 위한 일시적 사용을 허용합니다. 해당 폰트를 포함한 문서는 읽기 전용이어야 합니다.
- `Editable`은 일시적 사용을 허용하고 문서를 편집 및 저장할 수 있게 합니다.
- `NoSubsetting`은 추가 제한으로, 글리프의 일부만 삽입하는 것을 금지합니다. 이 플래그가 있을 경우 모든 문자를 삽입해야 합니다.
- `BitmapOnly`는 추가 제한으로, 비트맵 스트라이크만 삽입을 허용하고 윤곽 데이터는 삽입할 수 없습니다. 폰트에 비트맵 스트라이크가 없으면 삽입할 수 없습니다.

첫 네 값은 사용 권한을 설명하고, `NoSubsetting`과 `BitmapOnly`는 이들과 결합될 수 있습니다. 비트 연산을 사용해 수정자를 확인하십시오. `Installable`이 0이므로 사용 권한 비트를 마스크하고 결과를 `Installable`과 비교해 플래그로 확인하지 마십시오. 현재 폰트는 최대 하나의 사용 권한 비트를 설정해야 합니다. 하나보다 여러 개를 설정한 오래된 폰트와의 호환성을 위해 아래 헬퍼는 가장 제한이 적은 권한을 선택합니다: `Editable`, 다음 `PreviewPrint`, 마지막 `Restricted`.

다음 예제는 `getFonts`에서 반환된 각 폰트에 대해 일반, 굵게, 기울임, 굵게 기울임 스타일 데이터를 감사합니다. 사용 불가능한 스타일, 제한된 폰트, 비트맵 전용 폰트, 미리 보기 및 인쇄만 허용되는 폰트(출력이 편집 가능하게 유지됨), 이미 삽입된 폰트는 건너뜁니다. 사용 가능한 스타일 중 `NoSubsetting`이 있으면 해당 폰트 패밀리 전체 문자를 삽입합니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
var java = require("java");

function getUsagePermission(level) {
    var permissionMask = aspose.slides.EmbeddingLevel.Restricted | aspose.slides.EmbeddingLevel.PreviewPrint | aspose.slides.EmbeddingLevel.Editable;
    var permissions = level & permissionMask;

    if ((permissions & aspose.slides.EmbeddingLevel.Editable) !== 0) {
        return aspose.slides.EmbeddingLevel.Editable;
    }

    if ((permissions & aspose.slides.EmbeddingLevel.PreviewPrint) !== 0) {
        return aspose.slides.EmbeddingLevel.PreviewPrint;
    }

    if ((permissions & aspose.slides.EmbeddingLevel.Restricted) !== 0) {
        return aspose.slides.EmbeddingLevel.Restricted;
    }

    return aspose.slides.EmbeddingLevel.Installable;
}

var presentation = new aspose.slides.Presentation("Fonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var fontStyles = [aspose.slides.FontStyleType.Regular, aspose.slides.FontStyleType.Bold, aspose.slides.FontStyleType.Italic, aspose.slides.FontStyleType.Bold | aspose.slides.FontStyleType.Italic];

    var embeddedFontNames = new Set();
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    for (var i = 0; i < embeddedFonts.length; i++) {
        embeddedFontNames.add(String(embeddedFonts[i].getFontName()).toLowerCase());
    }

    var fontsToEmbed = [];
    var embeddingRules = [];
    var fonts = fontsManager.getFonts();
    for (var i = 0; i < fonts.length; i++) {
        var font = fonts[i];
        var fontName = String(font.getFontName());
        if (embeddedFontNames.has(fontName.toLowerCase())) {
            console.log(fontName + ": already embedded.");
            continue;
        }

        var hasAvailableData = false;
        var allAvailableStylesCanBeEmbedded = true;
        var previewPrintOnly = false;
        var requiresFullFont = false;

        for (var j = 0; j < fontStyles.length; j++) {
            var fontStyle = fontStyles[j];
            var fontBytes = fontsManager.getFontBytes(font, fontStyle);
            if (fontBytes === null) {
                console.log(fontName + " (" + fontStyle + "): font data is unavailable.");
                continue;
            }

            hasAvailableData = true;
            var fontByteValues = Array.from(fontBytes);
            var javaFontBytes = java.newArray("byte", fontByteValues);
            var embeddingLevel = fontsManager.getFontEmbeddingLevel(javaFontBytes, fontName);
            var usagePermission = getUsagePermission(embeddingLevel);
            var noSubsetting = (embeddingLevel & aspose.slides.EmbeddingLevel.NoSubsetting) !== 0;
            var bitmapOnly = (embeddingLevel & aspose.slides.EmbeddingLevel.BitmapOnly) !== 0;

            requiresFullFont = requiresFullFont || noSubsetting;
            previewPrintOnly = previewPrintOnly || usagePermission === aspose.slides.EmbeddingLevel.PreviewPrint;
            allAvailableStylesCanBeEmbedded = allAvailableStylesCanBeEmbedded && usagePermission !== aspose.slides.EmbeddingLevel.Restricted && !bitmapOnly;

            console.log(fontName + " (" + fontStyle + "): " + embeddingLevel + ".");
        }

        if (!hasAvailableData) {
            console.log(fontName + ": skipped because no requested style is available.");
        } else if (!allAvailableStylesCanBeEmbedded) {
            console.log(fontName + ": skipped because at least one available style does not permit outline embedding.");
        } else if (previewPrintOnly) {
            console.log(fontName + ": skipped because this example produces an editable presentation.");
        } else {
            var rule = requiresFullFont ? aspose.slides.EmbedFontCharacters.All : aspose.slides.EmbedFontCharacters.OnlyUsed;
            fontsToEmbed.push(font);
            embeddingRules.push(rule);
        }
    }

    for (var i = 0; i < fontsToEmbed.length; i++) {
        fontsManager.addEmbeddedFont(fontsToEmbed[i], embeddingRules[i]);
    }

    presentation.save("WithAuditedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

이 검사는 각 폰트 파일에 인코딩된 제한 사항을 보고합니다. 이는 라이선스를 부여하거나, 폰트를 합법적으로 입수했음을 증명하거나, 삽입된 복사본을 배포하기 전에 폰트 라이선스 계약을 확인하는 것을 대체하지 않습니다.

## **삽입된 폰트 추가**

[FontsManager.addEmbeddedFont](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontsmanager/addembeddedfont/)을 사용하여 폰트를 삽입합니다. 이 메서드의 오버로드는 [FontData](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontdata/) 개체 또는 폰트 데이터를 포함하는 바이트 배열을 받습니다. [EmbedFontCharacters](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/embedfontcharacters/)은 포함할 문자를 제어합니다:

- `All`은 폰트의 모든 문자를 삽입합니다. 수신자가 프레젠테이션을 편집하고 새 텍스트를 입력해야 할 경우 이 옵션을 사용합니다.
- `OnlyUsed`는 프레젠테이션에서 사용된 문자만 삽입하여 파일 크기를 줄입니다. 주로 보기용인 최종 프레젠테이션에 이 옵션을 선택하십시오.

다음 예제는 [FontsManager.getFonts](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontsmanager/getfonts/)을 사용해 `Fonts.pptx`에서 사용된 폰트를 가져오고 아직 삽입되지 않은 폰트를 삽입합니다. 추가할 폰트는 코드를 실행하는 머신에 있어야 합니다. 기존에 삽입된 폰트는 현재 문자 집합을 유지합니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("Fonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var allFonts = fontsManager.getFonts();
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    var embeddedFontNames = new Set();
    var fontStyles = [aspose.slides.FontStyleType.Regular, aspose.slides.FontStyleType.Bold, aspose.slides.FontStyleType.Italic, aspose.slides.FontStyleType.Bold | aspose.slides.FontStyleType.Italic];

    for (var i = 0; i < embeddedFonts.length; i++) {
        embeddedFontNames.add(String(embeddedFonts[i].getFontName()).toLowerCase());
    }

    for (var i = 0; i < allFonts.length; i++) {
        var font = allFonts[i];
        var fontName = String(font.getFontName()).toLowerCase();
        if (!embeddedFontNames.has(fontName)) {
            var hasAvailableData = false;
            for (var j = 0; j < fontStyles.length; j++) {
                if (fontsManager.getFontBytes(font, fontStyles[j]) !== null) {
                    hasAvailableData = true;
                    break;
                }
            }

            if (hasAvailableData) {
                fontsManager.addEmbeddedFont(font, aspose.slides.EmbedFontCharacters.All);
                embeddedFontNames.add(fontName);
            } else {
                console.log(font.getFontName() + ": skipped because its font data is unavailable.");
            }
        }
    }

    presentation.save("WithEmbeddedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **삽입된 폰트 압축**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/compress/compressembeddedfonts/)은 사용되지 않은 문자를 제거하여 삽입된 폰트 데이터를 감소시킵니다. 이미 삽입된 폰트를 대상으로 동작하므로 크기 감소는 프레젠테이션에 포함된 사용되지 않은 폰트 데이터 양에 따라 달라집니다.

다음 예제는 `EmbeddedFonts.pptx`의 폰트를 압축하고 결과를 별도 파일로 저장합니다:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    aspose.slides.Compress.compressEmbeddedFonts(presentation);
    presentation.save("CompressedEmbeddedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

수신자가 나중에 텍스트를 추가해야 할 가능성이 있으면 원본 파일을 보관하십시오. 압축 중에 제거된 문자는 원래 모든 문자를 삽입했더라도 삽입된 폰트에서 더 이상 사용할 수 없습니다.

## **FAQ**

**렌더링 시 삽입된 폰트가 여전히 대체되는지 어떻게 확인할 수 있나요?**

프레젠테이션을 렌더링하는 환경에서 [FontsManager.getSubstitutions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/)을 호출하면 Aspose.Slides가 교체할 폰트를 확인할 수 있습니다. 또한 [font substitution](/slides/ko/nodejs-java/font-substitution/) 설정과 [font fallback](/slides/ko/nodejs-java/fallback-font/) 규칙을 확인하십시오. 폰트 대체는 누락된 문자를 처리하므로, 폰트를 삽입해도 해당 폰트에 포함되지 않은 문자는 해결되지 않습니다.

**Arial 및 Calibri와 같은 일반 폰트를 삽입해야 할까요?**

결정은 대상 환경을 기준으로 해야 합니다. 프레젠테이션을 열거나 렌더링하는 모든 머신에 필요한 폰트가 이미 설치되어 있다면 삽입은 불필요한 파일 크기를 초래할 수 있습니다. 수신자나 서버에 해당 폰트가 없을 가능성이 있다면, 라이선스가 허용하는 범위 내에서 삽입하면 의도된 모습을 유지하는 데 도움이 됩니다.