---
title: Android에서 PowerPoint 폰트 사용자 정의
linktitle: 사용자 정의 폰트
type: docs
weight: 20
url: /ko/androidjava/custom-font/
keywords:
- 폰트
- 사용자 정의 폰트
- 외부 폰트
- 폰트 로드
- 폰트 관리
- 폰트 폴더
- PowerPoint
- OpenDocument
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android를 사용하여 Java로 PowerPoint 슬라이드의 폰트를 사용자 정의하여 모든 기기에서 프레젠테이션을 선명하고 일관되게 유지합니다."
---
## **개요**

Aspose.Slides는 운영 체제에 폰트를 설치하지 않고도 프레젠테이션에서 사용자 정의 폰트를 사용할 수 있게 합니다. 사용자 정의 폴더에서 폰트를 로드하거나, 문서 수준 폰트 소스를 통해 특정 프레젠테이션에 폰트를 제공하거나, 바이너리 데이터에서 직접 외부 폰트를 로드할 수 있습니다.

로드된 폰트는 프레젠테이션이 렌더링되거나 PDF, 이미지 및 기타 지원 형식으로 내보내질 때 사용됩니다. 이를 통해 다양한 환경에서 프레젠테이션 출력이 일관되게 유지됩니다. 이 문서에서는 Aspose.Slides에서 사용하는 폰트 폴더를 확인하는 방법과 외부 폰트를 사용한 후 폰트 캐시를 지우는 방법도 설명합니다.

렌더링을 위한 사용자 정의 폰트 등록은 PPTX 파일에 폰트를 포함시키는 것과 별개입니다. 폰트를 프레젠테이션 자체에 저장해야 하는 경우, 폰트 포함 기능을 명시적으로 사용하십시오.

{{% alert color="primary" %}} 

Aspose Slides는 다음 메서드를 사용하여 이러한 폰트를 로드할 수 있습니다: [loadExternalFonts](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---)

* TrueType(.ttf) 및 TrueType Collection(.ttc) 폰트. 자세한 내용은 [TrueType](https://en.wikipedia.org/wiki/TrueType) 을 참고하세요.

* OpenType(.otf) 폰트. 자세한 내용은 [OpenType](https://en.wikipedia.org/wiki/OpenType) 을 참고하세요.

{{% /alert %}}

## **사용자 정의 폰트 로드**

Aspose.Slides는 시스템에 폰트를 설치하지 않고도 프레젠테이션에서 사용되는 폰트를 로드할 수 있게 합니다. 이는 PDF, 이미지 및 기타 지원 형식과 같은 내보내기 결과에 영향을 주어, 다양한 환경에서 일관된 문서가 생성됩니다. 폰트는 사용자 정의 디렉터리에서 로드됩니다.

1. 폰트 파일이 들어 있는 하나 이상의 폴더를 지정합니다.
2. 정적 [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) 메서드를 호출하여 해당 폴더에서 폰트를 로드합니다.
3. 프레젠테이션을 로드하고 렌더링/내보내기합니다.
4. [FontsLoader.clearCache](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/FontsLoader#clearCache--) 메서드를 호출하여 폰트 캐시를 지웁니다.

다음 코드 예제는 폰트 로드 프로세스를 보여줍니다:

```java
// 사용자 정의 폰트 파일이 포함된 폴더를 정의합니다.
String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// 지정된 폴더에서 사용자 정의 폰트를 로드합니다.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");
    
    // 로드된 폰트를 사용하여 프레젠테이션을 렌더링/내보냅니다 (예: PDF, 이미지 또는 기타 형식).
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // 작업이 끝난 후 폰트 캐시를 지웁니다.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) 은 폰트 검색 경로에 추가 폴더를 포함하지만, 폰트 초기화 순서는 변경되지 않습니다.
폰트는 다음 순서대로 초기화됩니다:

1. 기본 운영 체제 폰트 경로.
1. [FontsLoader](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/fontsloader/) 를 통해 로드된 경로.

{{%/alert %}}

## **사용자 정의 폰트 폴더 가져오기**
Aspose.Slides는 [getFontFolders](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) 메서드를 제공하여 폰트 폴더를 찾을 수 있게 합니다. 이 메서드는 `LoadExternalFonts` 메서드를 통해 추가된 폴더와 시스템 폰트 폴더를 반환합니다.

다음 Java 코드는 [getFontFolders](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) 를 사용하는 방법을 보여줍니다:

```java
// 이 줄은 폰트 파일이 검색되는 폴더를 출력합니다.
// 이는 LoadExternalFonts 메서드를 통해 추가된 폴더와 시스템 폰트 폴더입니다.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **프레젠테이션에 사용되는 사용자 정의 폰트 지정**
Aspose.Slides는 [setDocumentLevelFontSources](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) 속성을 제공하여 프레젠테이션에 사용할 외부 폰트를 지정할 수 있게 합니다.

다음 Java 코드는 [setDocumentLevelFontSources](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) 속성을 사용하는 방법을 보여줍니다:

```java
byte[] memoryFont1 = Files.readAllBytes("customfonts/CustomFont1.ttf");
byte[] memoryFont2 = Files.readAllBytes("customfonts/CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // 프레젠테이션 작업
    // CustomFont1, CustomFont2 및 assets\fonts와 global\fonts 폴더와 그 하위 폴더의 폰트가 프레젠테이션에서 사용 가능합니다
} finally {
    if (pres != null) pres.dispose();
}
```

## **외부에서 폰트 관리**

Aspose.Slides는 (byte[] data) 매개변수를 받는 [loadExternalFont](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---) 메서드를 제공하여 바이너리 데이터에서 외부 폰트를 로드할 수 있게 합니다.

다음 Java 코드는 바이트 배열을 사용한 폰트 로드 과정을 보여줍니다:

```java
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // 프레젠테이션 수명 동안 로드된 외부 폰트
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **FAQ**

**사용자 정의 폰트가 모든 형식(PDF, PNG, SVG, HTML)으로의 내보내기에 영향을 줍니까?**

예. 연결된 폰트는 모든 내보내기 형식에서 렌더러에 의해 사용됩니다.

**사용자 정의 폰트가 결과 PPTX에 자동으로 포함됩니까?**

아니오. 렌더링을 위한 폰트 등록은 PPTX에 포함시키는 것과 동일하지 않습니다. 프레젠테이션 파일에 폰트를 포함해야 하면 명시적인 [embedding features](/slides/ko/androidjava/embedded-font/) 를 사용해야 합니다.

**사용자 정의 폰트에 특정 글리프가 없을 때 대체 동작을 제어할 수 있나요?**

예. [font substitution](/slides/ko/androidjava/font-substitution/), [replacement rules](/slides/ko/androidjava/font-replacement/), [fallback sets](/slides/ko/androidjava/fallback-font/) 를 구성하여 요청된 글리프가 없을 경우 사용될 폰트를 정확히 정의할 수 있습니다.

**Linux/Docker 컨테이너에서 폰트를 시스템 전체에 설치하지 않고 사용할 수 있나요?**

예. 자체 폰트 폴더를 지정하거나 바이트 배열에서 폰트를 로드하면 컨테이너 이미지에서 시스템 폰트 디렉터리에 대한 종속성을 제거할 수 있습니다.

**라이선스는 어떻습니까—제한 없이 어떤 사용자 정의 폰트든 포함시킬 수 있나요?**

폰트 라이선스 준수는 사용자 책임입니다. 라이선스마다 다르며, 일부는 포함 또는 상업적 사용을 금지합니다. 출력물을 배포하기 전에 반드시 폰트의 EULA를 검토하십시오.