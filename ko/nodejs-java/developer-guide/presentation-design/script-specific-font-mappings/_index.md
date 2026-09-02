---
title: JavaScript에서 스크립트별 테마 글꼴 관리
linktitle: 스크립트별 테마 글꼴
type: docs
weight: 15
url: /ko/nodejs-java/script-specific-font-mappings/
keywords:
- 스크립트별 글꼴
- 테마 글꼴 매핑
- 다국어 프레젠테이션
- 문자 체계
- 키릴 글꼴
- 아랍어 글꼴
- 일본어 글꼴
- 조지아어 글꼴
- 타아나 글꼴
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js를 사용하여 PowerPoint 테마에서 스크립트별 글꼴 매핑을 검사하고, 추가하고, 교체하고, 제거합니다."
---
## **개요**

프레젠테이션 테마는 다양한 문자 체계에 대해 서로 다른 글꼴 패밀리를 선택할 수 있습니다. 이를 통해 다국어 텍스트가 여전히 테마 글꼴을 사용하면서도, Cyrillic, Arabic, Japanese, Georgian, Thaana 및 기타 스크립트에 적합한 글꼴을 사용하여 하나의 일관된 글꼴 체계를 따를 수 있습니다.

테마의 [FontScheme](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontscheme/)에는 주로 제목에 사용되는 주요 글꼴 컬렉션과 주로 본문에 사용되는 보조 글꼴 컬렉션이 포함됩니다. Latin 및 East Asian 글꼴 설정 외에도, 두 컬렉션 모두 [Fonts](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fonts/) 클래스를 통해 쓰기 시스템 태그에서 글꼴 패밀리 이름으로의 매핑을 노출합니다.

이 문서에서는 프레젠테이션 마스터 테마에서 해당 매핑을 검사하고 수정하는 방법과 변경 사항이 저장 및 재로드 사이클에서도 유지되는지 확인하는 방법을 보여줍니다.

## **스크립트 태그 이해**

스크립트 글꼴 메서드는 네 글자 BCP 47 스크립트 서브태그를 사용하여 쓰기 시스템을 식별합니다. 일반적인 값은 다음과 같습니다:

| 스크립트 태그 | 쓰기 시스템 |
|---|---|
| `Cyrl` | 키릴 문자 |
| `Arab` | 아랍어 |
| `Hans` | 간체 중국어 |
| `Jpan` | 일본어 |
| `Geor` | 조지아 문자 |
| `Thaa` | 타나 문자 |

## **스크립트 글꼴 매핑에 접근하고 검사하기**

프레젠테이션 수준 테마에 접근하려면 [Presentation.getMasterTheme](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/getmastertheme/)를 사용합니다. [FontScheme.getMajor](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontscheme/) 및 [FontScheme.getMinor](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontscheme/) 메서드는 두 개의 [Fonts](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fonts/) 컬렉션을 반환합니다.

[Fonts.getScriptFontMap](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fonts/)을 호출하면 컬렉션의 모든 매핑을 가져올 수 있습니다. 특정 쓰기 시스템을 조회하려면 해당 스크립트 태그와 함께 [Fonts.getScriptFont](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fonts/)를 호출합니다. `getScriptFont`는 해당 컬렉션에 요청된 매핑이 정의되지 않은 경우 `null`을 반환합니다.

## **매핑 수정 및 지속성 확인**

[Fonts.setScriptFont](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fonts/)을 사용하여 매핑을 만들거나 현재 글꼴 패밀리를 교체합니다. [Fonts.removeScriptFont](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fonts/)을 사용하여 매핑을 제거합니다.

다음 엔드‑투‑엔드 예제는 기존 주요 및 보조 매핑을 모두 읽고, 일본어 주요 글꼴을 조회한 뒤, 키릴 주요 글꼴을 변경하고, 타나 보조 매핑을 제거한 뒤 프레젠테이션을 저장하고 다시 열어 두 변경 사항을 확인합니다. 초기 테마와 무관하게 제거 단계를 수행하도록 예제는 먼저 타나 매핑이 정의되지 않은 경우에만 타나 매핑을 생성합니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var fontScheme = presentation.getMasterTheme().getFontScheme();
    var majorFonts = fontScheme.getMajor();
    var minorFonts = fontScheme.getMinor();

    console.log("Existing major mappings:");
    var majorMappings = majorFonts.getScriptFontMap().iterator();
    while (majorMappings.hasNext()) {
        var mapping = majorMappings.next();
        console.log("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    console.log("Existing minor mappings:");
    var minorMappings = minorFonts.getScriptFontMap().iterator();
    while (minorMappings.hasNext()) {
        var mapping = minorMappings.next();
        console.log("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    var japaneseFont = majorFonts.getScriptFont("Jpan");
    if (japaneseFont == null) {
        console.log("No major Japanese font is defined.");
    } else {
        console.log("Major Japanese font: " + japaneseFont);
    }

    majorFonts.setScriptFont("Cyrl", "Arial");

    if (minorFonts.getScriptFont("Thaa") == null) {
        minorFonts.setScriptFont("Thaa", "Arial");
    }

    minorFonts.removeScriptFont("Thaa");
    presentation.save("script-font-mappings.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

var savedPresentation = new aspose.slides.Presentation("script-font-mappings.pptx");
try {
    var savedMajorFonts = savedPresentation.getMasterTheme().getFontScheme().getMajor();
    var savedMinorFonts = savedPresentation.getMasterTheme().getFontScheme().getMinor();
    var savedCyrillicFont = savedMajorFonts.getScriptFont("Cyrl");
    var savedThaanaFont = savedMinorFonts.getScriptFont("Thaa");

    if (savedCyrillicFont === "Arial") {
        console.log("The Cyrillic mapping was preserved.");
    } else {
        console.log("The Cyrillic mapping was not preserved.");
    }

    if (savedThaanaFont == null) {
        console.log("The Thaana mapping removal was preserved.");
    } else {
        console.log("The Thaana mapping still exists.");
    }
} finally {
    savedPresentation.dispose();
}
```

검증은 일반 조회와 동일한 `null` 동작을 사용합니다: 제거가 저장된 후, `getScriptFont("Thaa")`는 보조 컬렉션에 대해 `null`을 반환합니다.

## **테마 매핑과 기타 글꼴 설정 구분**

스크립트별 테마 매핑은 글꼴 선택에 참여하지만, 직접 텍스트 서식, 대체 및 폴백과는 다른 문제를 해결합니다:

| 메커니즘 | 목적 | 테마 매핑 변경 시 효과 |
|---|---|---|
| 스크립트별 테마 글꼴 매핑 | 쓰기 시스템에 대한 주요 또는 보조 테마 글꼴을 선택합니다. | 해당 테마 글꼴을 계속 사용하는 텍스트는 새 매핑된 패밀리로 해석될 수 있습니다. |
| 텍스트 구간에 명시적으로 할당된 글꼴 | 테마에 의존하지 않고 해당 구간에 요청된 글꼴 패밀리를 고정합니다. | 직접 서식이 테마 선택을 무시하므로 구간이 변경되지 않을 수 있습니다. |
| 글꼴 대체 | 요청된 글꼴이 없거나 대체 규칙이 적용될 때 해당 글꼴을 교체합니다. | 글꼴이 요청된 후에 작동하며, 테마의 스크립트 매핑을 재정의하지 않습니다. |
| 글꼴 폴백 | 선택된 글꼴에 포함되지 않은 글리프를 제공하며, 주로 특정 Unicode 범위에 대해 적용됩니다. | 누락된 글리프를 채우지만 저장된 테마 매핑을 변경하지는 않습니다. |

마지막 두 메커니즘에 대한 자세한 내용은 [Font Substitution](/slides/ko/nodejs-java/font-substitution/) 및 [Fallback Fonts](/slides/ko/nodejs-java/fallback-font/)을 참고하십시오.

[Presentation.getMasterTheme](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/getmastertheme/)에서 매핑을 변경하면 해당 테마에 여전히 의존하는 콘텐츠에만 영향을 미칩니다. 텍스트는 마스터, 레이아웃 또는 슬라이드에서 테마 오버라이드를 상속하거나 명시적으로 할당된 글꼴을 사용할 수 있습니다. 보이는 결과가 프레젠테이션 수준 매핑을 따르지 않을 때는 이러한 수준을 검사하십시오.

## **매핑된 글꼴을 사용할 수 있게 만들고 결과 검증**

스크립트 매핑은 글꼴 패밀리 이름만 저장하며, 해당 글꼴 파일을 설치하거나 로드하지는 않습니다. 일관된 렌더링 및 내보내기를 위해 매핑된 모든 글꼴은 환경에 설치되어 있거나 [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) 또는 [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/loadoptions/)와 같은 사용자 지정 소스를 통해 Aspose.Slides에 제공되어야 합니다. 사용 가능한 로드 옵션은 [Custom Fonts](/slides/ko/nodejs-java/custom-font/)를 참고하십시오.

저장된 매핑을 검증하는 것은 테마 정의가 보존되었음을 확인할 뿐이며, 글꼴이 실제로 사용 가능하거나 필요한 모든 글리프를 포함하고 있는지, 의도한 레이아웃을 생성하는지는 증명하지 못합니다. 각 필요 쓰기 시스템에 대해 대표 텍스트를 이미지 또는 PDF로 렌더링하고 출력물을 검사하십시오. 이렇게 하면 프레젠테이션 배포 전 누락된 글꼴, 불완전한 글리프 커버리지, 폴백 동작 및 레이아웃 변경을 잡아낼 수 있습니다. 렌더링 및 내보내기 예시는 [Convert PowerPoint Presentations](/slides/ko/nodejs-java/convert-powerpoint/)를 참고하십시오.

## **FAQ**

**스크립트가 매핑되지 않았을 때 `getScriptFont`는 무엇을 반환합니까?**

[Fonts.getScriptFont](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fonts/)은 해당 주요 또는 보조 글꼴 컬렉션에 요청된 스크립트 매핑이 정의되지 않은 경우 `null`을 반환합니다.

**스크립트가 이미 존재할 때 `setScriptFont`가 두 번째 매핑을 추가합니까?**

아니요. [Fonts.setScriptFont](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fonts/)은 매핑이 없을 때 생성하고, 동일한 스크립트 태그가 이미 존재하면 매핑된 글꼴 패밀리를 교체합니다.

**테마 매핑을 변경했음에도 일부 텍스트가 변경되지 않은 이유는 무엇입니까?**

텍스트에 명시적으로 할당된 글꼴이 있거나, 다른 마스터·레이아웃·슬라이드에서 테마 오버라이드를 상속했거나, 렌더링 중 대체 또는 폴백에 영향을 받았을 수 있습니다. 프레젠테이션 수준 스크립트 매핑은 해당 테마 글꼴 컬렉션에 여전히 의존하는 텍스트에만 영향을 미칩니다.

**저장하고 다시 열어 보는 것만으로 다국어 출력이 검증되나요?**

아니요. 다시 열어 보는 것은 테마 데이터의 지속성을 확인할 뿐입니다. 또한 각 필수 쓰기 시스템에 대한 대표 텍스트를 렌더링하여 매핑된 글꼴이 사용 가능하고 필요한 글리프를 모두 포함하는지 확인해야 합니다.