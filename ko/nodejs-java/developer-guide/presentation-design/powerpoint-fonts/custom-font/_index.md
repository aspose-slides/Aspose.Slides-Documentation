---
title: JavaScript에서 PowerPoint 글꼴 사용자 정의
linktitle: 사용자 정의 글꼴
type: docs
weight: 20
url: /ko/nodejs-java/custom-font/
keywords:
- 글꼴
- 사용자 정의 글꼴
- 외부 글꼴
- 글꼴 로드
- 글꼴 관리
- 글꼴 폴더
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Java와 Aspose.Slides for Node.js를 사용하여 JavaScript로 PowerPoint 슬라이드의 글꼴을 사용자 정의하고, 프레젠테이션을 어떤 장치에서도 선명하고 일관되게 유지합니다."
---
## **개요**

Aspose.Slides를 사용하면 운영 체제에 설치하지 않고도 프레젠테이션에서 사용자 정의 글꼴을 사용할 수 있습니다. 사용자 정의 폴더에서 글꼴을 로드하거나 문서 수준 글꼴 소스를 통해 특정 프레젠테이션에 대한 글꼴을 제공하거나 이진 데이터에서 외부 글꼴을 직접 로드할 수 있습니다.

로드된 글꼴은 프레젠테이션이 렌더링되거나 PDF, 이미지 및 기타 지원되는 형식으로 내보낼 때 사용됩니다. 이를 통해 서로 다른 환경에서도 프레젠테이션 출력이 일관되게 유지됩니다. 이 문서에서는 Aspose.Slides에서 사용되는 글꼴 폴더를 검사하는 방법과 외부 글꼴 작업 후 글꼴 캐시를 지우는 방법도 설명합니다.

렌더링을 위한 사용자 정의 글꼴 등록은 PPTX 파일에 글꼴을 포함하는 것과 별개입니다. 글꼴을 프레젠테이션 자체에 저장해야 하는 경우, 글꼴 포함 기능을 명시적으로 사용하십시오.

프레젠테이션 테마는 개별 쓰기 시스템마다 다른 글꼴 패밀리를 참조할 수 있습니다. 이러한 매핑은 글꼴 이름을 저장하지만 글꼴 파일을 설치하거나 로드하지는 않습니다. 매핑을 관리하려면 [Script-Specific Theme Fonts](/slides/ko/nodejs-java/script-specific-font-mappings/)를 확인하고, 아래 로딩 옵션을 사용하여 참조된 글꼴을 일관된 렌더링을 위해 사용할 수 있게 하십시오.

{{% alert color="info" title="참고" %}}
Aspose Slides를 사용하면 다음 메서드로 이러한 글꼴을 로드할 수 있습니다:

* TrueType(.ttf) 및 TrueType Collection(.ttc) 글꼴. 자세히 보려면 [TrueType](https://en.wikipedia.org/wiki/TrueType).
* OpenType(.otf) 글꼴. 자세히 보려면 [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **맞춤 글꼴 로드**

Aspose.Slides를 사용하면 시스템에 설치하지 않고도 프레젠테이션에 사용되는 글꼴을 로드할 수 있습니다. 이는 PDF, 이미지 및 기타 지원되는 형식과 같은 내보내기 결과에 영향을 미치므로, 환경이 달라도 문서가 일관된 모습을 유지합니다. 글꼴은 사용자 정의 디렉터리에서 로드됩니다.

1. 글꼴 파일이 들어 있는 하나 이상의 폴더를 지정합니다.
2. 정적 [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) 메서드를 호출하여 해당 폴더에서 글꼴을 로드합니다.
3. 프레젠테이션을 로드하고 렌더링/내보냅니다.
4. [FontsLoader.clearCache](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontsloader/clearcache/)를 호출하여 글꼴 캐시를 지웁니다.

다음 코드 예제는 글꼴 로드 프로세스를 보여줍니다:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// 사용자 정의 글꼴 파일이 포함된 폴더를 정의합니다.
let externalFontFolder1 = "fonts";
let externalFontFolder2 = "extra-fonts";
let fontFolders = java.newArray("java.lang.String", [externalFontFolder1, externalFontFolder2]);

// 지정된 폴더에서 사용자 정의 글꼴을 로드합니다.
aspose.slides.FontsLoader.loadExternalFonts(fontFolders);

let presentation = null;
try {
    presentation = new aspose.slides.Presentation("sample.pptx");
    
    // 렌더링/내보내기 프레젠테이션을 로드된 글꼴을 사용하여 수행합니다(예: PDF, 이미지 또는 기타 형식).
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // 작업이 끝난 후 글꼴 캐시를 지웁니다.
    aspose.slides.FontsLoader.clearCache();
}
```

{{% alert color="info" title="참고" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/)는 글꼴 검색 경로에 추가 폴더를 더하지만 글꼴 초기화 순서는 변경되지 않습니다.
글꼴은 다음 순서로 초기화됩니다:

1. 기본 운영 체제 글꼴 경로.
1. [FontsLoader](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontsloader/)를 통해 로드된 경로.
{{%/alert %}}

## **맞춤 글꼴 폴더 가져오기**

Aspose.Slides는 [getFontFolders](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) 메서드를 제공하여 글꼴 폴더를 찾을 수 있게 합니다. 이 메서드는 `LoadExternalFonts` 메서드를 통해 추가된 폴더와 시스템 글꼴 폴더를 반환합니다.

다음 JavaScript 코드는 [getFontFolders](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontsloader/#getFontFolders--)를 사용하는 방법을 보여줍니다:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// 이 라인은 글꼴 파일이 검색되는 폴더를 출력합니다.
// 이는 LoadExternalFonts 메서드를 통해 추가된 폴더와 시스템 글꼴 폴더입니다.
var fontFolders = aspose.slides.FontsLoader.getFontFolders();
```

## **프레젠테이션에 사용되는 맞춤 글꼴 지정**

Aspose.Slides는 [setDocumentLevelFontSources](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-) 속성을 제공하여 프레젠테이션에 사용할 외부 글꼴을 지정할 수 있게 합니다.

다음 JavaScript 코드는 [setDocumentLevelFontSources](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-) 속성을 사용하는 방법을 보여줍니다:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var memoryFont1 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont1.ttf"));
var memoryFont2 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont2.ttf"));
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(java.newArray("java.lang.String", ["assets/fonts", "global/fonts"]));
loadOptions.getDocumentLevelFontSources().setMemoryFonts(java.newArray("[B", [java.newArray("byte", ["item1", "item2", "item3"])]));
var pres = new aspose.slides.Presentation("MyPresentation.pptx", loadOptions);
try {
    // 프레젠테이션 작업
    // CustomFont1, CustomFont2 및 assets\fonts와 global\fonts 폴더 및 그 하위 폴더의 글꼴이 프레젠테이션에서 사용 가능합니다
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **외부에서 글꼴 관리**

Aspose.Slides는 [loadExternalFont](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) 메서드를 제공하여 이진 데이터에서 외부 글꼴을 로드할 수 있게 합니다.

다음 JavaScript 코드는 바이트 배열을 이용한 글꼴 로드 프로세스를 보여줍니다:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALN.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNBI.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNI.TTF")));
try {
    var pres = new aspose.slides.Presentation("");
    try {
        // 프레젠테이션 수명 동안 외부 글꼴이 로드되었습니다
    } finally {
    }
} finally {
    java.callStaticMethodSync("com.aspose.slides.FontsLoader", "clearCache");
}
```

## **FAQ**

### 맞춤 글꼴이 모든 형식(PDF, PNG, SVG, HTML)으로의 내보내기에 영향을 미칩니까?

예. 연결된 글꼴은 모든 내보내기 형식에서 렌더러에 의해 사용됩니다.

### 맞춤 글꼴이 결과 PPTX에 자동으로 포함됩니까?

아니요. 렌더링을 위해 글꼴을 등록하는 것은 PPTX에 포함하는 것과 동일하지 않습니다. 프레젠테이션 파일에 글꼴을 포함해야 하는 경우 명시적인 [embedding features](/slides/ko/nodejs-java/embedded-font/)를 사용해야 합니다.

### 맞춤 글꼴에 특정 글리프가 없을 때 대체 동작을 제어할 수 있습니까?

예. [font substitution](/slides/ko/nodejs-java/font-substitution/), [replacement rules](/slides/ko/nodejs-java/font-replacement/) 및 [fallback sets](/slides/ko/nodejs-java/fallback-font/)을 구성하여 요청된 글리프가 없을 때 정확히 어떤 글꼴이 사용되는지 정의할 수 있습니다.

### Linux/Docker 컨테이너에서 시스템 전체에 설치하지 않고 글꼴을 사용할 수 있습니까?

예. 자체 글꼴 폴더를 지정하거나 바이트 배열에서 글꼴을 로드하십시오. 이렇게 하면 컨테이너 이미지에서 시스템 글꼴 디렉터리에 대한 의존성이 제거됩니다.

### 라이선스는 어떻습니까—제한 없이 맞춤 글꼴을 포함할 수 있나요?

글꼴 라이선스 준수는 사용자의 책임입니다. 라이선스에 따라 포함이나 상업적 사용이 금지될 수 있습니다. 출력을 배포하기 전에 항상 글꼴의 EULA를 검토하십시오.