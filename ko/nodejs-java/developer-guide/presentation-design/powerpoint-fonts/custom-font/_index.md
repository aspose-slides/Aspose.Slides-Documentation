---
title: JavaScript에서 PowerPoint 글꼴 사용자 지정
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
description: "Java를 통해 Node.js용 Aspose.Slides와 JavaScript를 사용하여 PowerPoint 슬라이드의 글꼴을 사용자 지정하고, 프레젠테이션을 모든 장치에서 선명하고 일관되게 유지하세요."
---
## **개요**

Aspose.Slides는 운영 체제에 설치하지 않고도 프레젠테이션에서 사용자 정의 글꼴을 사용할 수 있도록 합니다. 사용자 정의 폴더에서 글꼴을 로드하거나, 문서 수준 글꼴 소스를 통해 특정 프레젠테이션에 글꼴을 제공하거나, 바이너리 데이터에서 직접 외부 글꼴을 로드할 수 있습니다.

로드된 글꼴은 프레젠테이션이 렌더링되거나 PDF, 이미지 및 기타 지원 형식으로 내보내질 때 사용됩니다. 이는 다양한 환경에서 프레젠테이션 출력이 일관되도록 도와줍니다. 이 문서에서는 Aspose.Slides가 사용하는 글꼴 폴더를 확인하는 방법과 외부 글꼴을 사용한 후 글꼴 캐시를 지우는 방법도 설명합니다.

렌더링을 위한 사용자 정의 글꼴 등록은 PPTX 파일에 글꼴을 삽입하는 것과 별개입니다. 글꼴을 프레젠테이션 자체에 저장해야 하는 경우, 글꼴 삽입 기능을 명시적으로 사용하십시오.

{{% alert color="primary" %}} 
Aspose Slides는 다음 메서드인 [loadExternalFonts](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) 를 사용하여 이러한 글꼴을 로드할 수 있습니다:

* TrueType (.ttf) 및 TrueType Collection (.ttc) 글꼴. [TrueType](https://en.wikipedia.org/wiki/TrueType) 을 참고하십시오.

* OpenType (.otf) 글꼴. [OpenType](https://en.wikipedia.org/wiki/OpenType) 을 참고하십시오.
{{% /alert %}}

## **사용자 정의 글꼴 로드**

Aspose.Slides를 사용하면 시스템에 설치하지 않고도 프레젠테이션에 사용되는 글꼴을 로드할 수 있습니다. 이는 PDF, 이미지 및 기타 지원 형식과 같은 내보내기 결과에 영향을 주어, 생성된 문서가 다양한 환경에서 일관되게 보이도록 합니다. 글꼴은 사용자 정의 디렉터리에서 로드됩니다.

1. 글꼴 파일이 들어 있는 하나 이상의 폴더를 지정합니다.
2. [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) 정적 메서드를 호출하여 해당 폴더에서 글꼴을 로드합니다.
3. 프레젠테이션을 로드하고 렌더링/내보내기합니다.
4. [FontsLoader.clearCache](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontsloader/clearcache/) 를 호출하여 글꼴 캐시를 지웁니다.

다음 코드 예제는 글꼴 로드 프로세스를 보여줍니다:

```js
// 사용자 정의 글꼴 파일이 들어 있는 폴더를 정의합니다.
let fontFolders = java.newArray("java.lang.String", [externalFontFolder1, externalFontFolder2]);

// 지정된 폴더에서 사용자 정의 글꼴을 로드합니다.
aspose.slides.FontsLoader.loadExternalFonts(fontFolders);

let presentation = null;
try {
    presentation = new aspose.slides.Presentation("sample.pptx");
    
    // 로드된 글꼴을 사용하여 프레젠테이션을 렌더링/내보냅니다 (예: PDF, 이미지 또는 기타 형식).
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // 작업이 끝난 후 글꼴 캐시를 지웁니다.
    aspose.slides.FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) 은 글꼴 검색 경로에 추가 폴더를 포함하지만, 글꼴 초기화 순서는 변경하지 않습니다.
글꼴은 다음 순서대로 초기화됩니다:

1. 기본 운영 체제 글꼴 경로.
1. [FontsLoader](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontsloader/) 를 통해 로드된 경로.
{{%/alert %}}

## **사용자 정의 글꼴 폴더 가져오기**
Aspose.Slides는 [getFontFolders](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) 메서드를 제공하여 글꼴 폴더를 찾을 수 있게 합니다. 이 메서드는 `LoadExternalFonts` 메서드를 통해 추가된 폴더와 시스템 글꼴 폴더를 반환합니다.

다음 JavaScript 코드는 [getFontFolders](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) 를 사용하는 방법을 보여줍니다:

```javascript
// 이 행은 글꼴 파일이 검색되는 폴더를 출력합니다.
// 이는 LoadExternalFonts 메서드와 시스템 글꼴 폴더를 통해 추가된 폴더입니다.
var fontFolders = aspose.slides.FontsLoader.getFontFolders();
```

## **프레젠테이션에 사용되는 사용자 정의 글꼴 지정**
Aspose.Slides는 프레젠테이션과 함께 사용할 외부 글꼴을 지정할 수 있도록 [setDocumentLevelFontSources](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-) 속성을 제공합니다.

다음 JavaScript 코드는 [setDocumentLevelFontSources](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-) 속성을 사용하는 방법을 보여줍니다:

```javascript
var memoryFont1 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont1.ttf"));
var memoryFont2 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont2.ttf"));
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(java.newArray("java.lang.String", ["assets/fonts", "global/fonts"]));
loadOptions.getDocumentLevelFontSources().setMemoryFonts(java.newArray("[B", [java.newArray("byte", ["item1", "item2", "item3"])]));
var pres = new aspose.slides.Presentation("MyPresentation.pptx", loadOptions);
try {
    // 프레젠테이션 작업
    // CustomFont1, CustomFont2 및 assets\fonts와 global\fonts 폴더와 그 하위 폴더의 글꼴이 프레젠테이션에서 사용 가능합니다
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **외부에서 글꼴 관리**

Aspose.Slides는 바이너리 데이터(byte[] data)에서 외부 글꼴을 로드할 수 있도록 [loadExternalFont](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) 메서드를 제공합니다.

다음 JavaScript 코드는 바이트 배열을 사용한 글꼴 로드 과정을 보여줍니다:

```javascript
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALN.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNBI.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNI.TTF")));
try {
    var pres = new aspose.slides.Presentation("");
    try {
        // 프레젠테이션 수명 동안 로드된 외부 글꼴
    } finally {
    }
} finally {
    java.callStaticMethodSync("com.aspose.slides.FontsLoader", "clearCache");
}
```

## **FAQ**

**사용자 정의 글꼴이 모든 형식(PDF, PNG, SVG, HTML)으로의 내보내기에 영향을 줍니까?**

예. 연결된 글꼴은 모든 내보내기 형식에서 렌더러에 의해 사용됩니다.

**사용자 정의 글꼴이 결과 PPTX에 자동으로 삽입됩니까?**

아니요. 렌더링을 위해 글꼴을 등록하는 것은 PPTX에 삽입하는 것과 동일하지 않습니다. 프레젠테이션 파일에 글꼴을 포함해야 하는 경우, 명시적인 [embedding features](/slides/ko/nodejs-java/embedded-font/) 를 사용해야 합니다.

**사용자 정의 글꼴에 특정 글리프가 없을 때 대체 동작을 제어할 수 있습니까?**

예. [font substitution](/slides/ko/nodejs-java/font-substitution/), [replacement rules](/slides/ko/nodejs-java/font-replacement/), [fallback sets](/slides/ko/nodejs-java/fallback-font/) 를 구성하여 요청한 글리프가 없을 때 정확히 어떤 글꼴을 사용할지 정의할 수 있습니다.

**Linux/Docker 컨테이너에서 시스템 전체에 설치하지 않고 글꼴을 사용할 수 있습니까?**

예. 자체 글꼴 폴더를 지정하거나 바이트 배열에서 글꼴을 로드하면 됩니다. 이렇게 하면 컨테이너 이미지에서 시스템 글꼴 디렉터리에 대한 의존성이 제거됩니다.

**라이선스는 어떻습니까—제한 없이 사용자 정의 글꼴을 삽입할 수 있나요?**

글꼴 라이선스 준수는 사용자 책임입니다. 조건은 다양하며, 일부 라이선스는 삽입이나 상업적 사용을 금지합니다. 결과물을 배포하기 전에 항상 글꼴의 EULA를 검토하십시오.