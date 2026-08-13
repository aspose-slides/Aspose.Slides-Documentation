---
title: Android에서 PowerPoint 글꼴 맞춤
linktitle: 사용자 정의 글꼴
type: docs
weight: 20
url: /ko/androidjava/custom-font/
keywords:
- 글꼴
- 맞춤 글꼴
- 외부 글꼴
- 글꼴 로드
- 글꼴 관리
- 글꼴 폴더
- PowerPoint
- OpenDocument
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android와 Java를 사용하여 PowerPoint 슬라이드의 글꼴을 맞춤 설정하면 프레젠테이션을 모든 장치에서 선명하고 일관되게 유지할 수 있습니다."
---
## **개요**

Aspose.Slides는 운영 체제에 설치하지 않고도 프레젠테이션에서 사용자 지정 글꼴을 사용할 수 있도록 합니다. 사용자 지정 폴더에서 글꼴을 로드하거나, 문서 수준 글꼴 소스를 통해 특정 프레젠테이션에 글꼴을 제공하거나, 바이너리 데이터에서 외부 글꼴을 직접 로드할 수 있습니다.

로드된 글꼴은 프레젠테이션이 렌더링되거나 PDF, 이미지 및 기타 지원 형식으로 내보낼 때 사용됩니다. 이를 통해 다양한 환경에서 프레젠테이션 출력이 일관되게 유지됩니다. 이 문서에서는 Aspose.Slides가 사용하는 글꼴 폴더를 확인하는 방법과 외부 글꼴 작업 후 글꼴 캐시를 지우는 방법도 설명합니다.

렌더링을 위한 사용자 지정 글꼴 등록은 PPTX 파일에 글꼴을 포함시키는 것과 별개입니다. 글꼴을 프레젠테이션 자체에 저장해야 하는 경우, 글꼴 포함 기능을 명시적으로 사용하십시오.

{{% alert color="info" %}} 

Aspose Slides는 다음 메서드를 사용하여 이러한 글꼴을 로드할 수 있습니다. [loadExternalFonts](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* TrueType(.ttf) 및 TrueType Collection(.ttc) 글꼴. 자세히 보기 [TrueType](https://en.wikipedia.org/wiki/TrueType).
* OpenType(.otf) 글꼴. 자세히 보기 [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **사용자 정의 글꼴 로드**

Aspose.Slides는 시스템에 설치하지 않고도 프레젠테이션에서 사용되는 글꼴을 로드할 수 있습니다. 이는 PDF, 이미지 및 기타 지원 형식과 같은 내보내기 결과에 영향을 주어, 다양한 환경에서 문서가 일관되게 보이도록 합니다. 글꼴은 사용자 정의 디렉터리에서 로드됩니다.

1. 글꼴 파일이 포함된 하나 이상의 폴더를 지정합니다.
2. 정적 [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) 메서드를 호출하여 해당 폴더에서 글꼴을 로드합니다.
3. 프레젠테이션을 로드하고 렌더링/내보냅니다.
4. [FontsLoader.clearCache](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/FontsLoader#clearCache--) 메서드를 호출하여 글꼴 캐시를 정리합니다.

다음 코드 예제는 글꼴 로드 과정을 보여줍니다:

```java
import com.aspose.slides.*;

// 사용자 정의 글꼴 파일이 포함된 폴더를 정의합니다.
String externalFontFolder1 = "assets/fonts";
String externalFontFolder2 = "global/fonts";

String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// 지정된 폴더에서 사용자 정의 글꼴을 로드합니다.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // 로드된 글꼴을 사용하여 프레젠테이션을 렌더링/내보냅니다(예: PDF, 이미지 또는 다른 형식).
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // 작업이 끝난 후 글꼴 캐시를 지웁니다.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) 은 추가 폴더를 글꼴 검색 경로에 추가하지만, 글꼴 초기화 순서는 변경하지 않습니다.
글꼴은 다음 순서로 초기화됩니다:

1. 기본 운영 체제 글꼴 경로.
1. [FontsLoader](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/fontsloader/) 를 통해 로드된 경로.

{{%/alert %}}

## **사용자 정의 글꼴 폴더 가져오기**

Aspose.Slides는 [getFontFolders](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) 메서드를 제공하여 글꼴 폴더를 찾을 수 있게 합니다. 이 메서드는 `LoadExternalFonts` 메서드를 통해 추가된 폴더와 시스템 글꼴 폴더를 반환합니다.

다음 Java 코드는 [getFontFolders](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) 를 사용하는 방법을 보여줍니다:

```java
import com.aspose.slides.*;

// 이 라인은 글꼴 파일이 검색되는 폴더를 출력합니다.
// 이 폴더들은 LoadExternalFonts 메서드를 통해 추가된 폴더와 시스템 글꼴 폴더입니다.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **프레젠테이션에 사용할 사용자 정의 글꼴 지정**

Aspose.Slides는 [setDocumentLevelFontSources](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) 속성을 제공하여 프레젠테이션에 사용할 외부 글꼴을 지정할 수 있게 합니다.

다음 Java 코드는 [setDocumentLevelFontSources](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) 속성을 사용하는 방법을 보여줍니다:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

byte[] memoryFont1 = Files.readAllBytes(Paths.get("customfonts/CustomFont1.ttf"));
byte[] memoryFont2 = Files.readAllBytes(Paths.get("customfonts/CustomFont2.ttf"));

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // 프레젠테이션 작업
    // CustomFont1, CustomFont2, 그리고 assets\fonts 및 global\fonts 폴더와 그 하위 폴더의 글꼴이 프레젠테이션에서 사용 가능합니다.
} finally {
    if (pres != null) pres.dispose();
}
```

## **외부에서 글꼴 관리**

Aspose.Slides는 [loadExternalFont](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) 메서드를 제공하여 바이너리 데이터에서 외부 글꼴을 로드할 수 있게 합니다.

다음 Java 코드는 바이트 배열을 사용한 글꼴 로드 과정을 보여줍니다:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // 프레젠테이션 수명 동안 로드된 외부 글꼴
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **FAQ**

### 사용자 지정 글꼴이 모든 형식(PDF, PNG, SVG, HTML)으로의 내보내기에 영향을 미칩니까?

예. 연결된 글꼴은 모든 내보내기 형식에서 렌더러에 의해 사용됩니다.

### 사용자 지정 글꼴이 결과 PPTX에 자동으로 포함됩니까?

아니요. 렌더링을 위한 글꼴 등록은 PPTX에 포함시키는 것과 동일하지 않습니다. 프레젠테이션 파일에 글꼴을 포함해야 하면 명시적인 [포함 기능](/slides/ko/androidjava/embedded-font/)을 사용해야 합니다.

### 특정 글리프가 없는 경우 폰트 대체 동작을 제어할 수 있습니까?

예. [글꼴 대체](/slides/ko/androidjava/font-substitution/), [대체 규칙](/slides/ko/androidjava/font-replacement/) 및 [대체 세트](/slides/ko/androidjava/fallback-font/) 를 구성하여 요청된 글리프가 없을 때 어떤 글꼴을 사용할지 정확히 정의할 수 있습니다.

### Linux/Docker 컨테이너에서 시스템 전체에 설치하지 않고 글꼴을 사용할 수 있습니까?

예. 자체 글꼴 폴더를 지정하거나 바이트 배열에서 글꼴을 로드하면 컨테이너 이미지의 시스템 글꼴 디렉터리에 대한 의존성이 제거됩니다.

### 라이선스는 어떻게 됩니까—제한 없이 사용자 지정 글꼴을 포함할 수 있나요?

글꼴 라이선스 준수는 사용자 책임입니다. 라이선스에 따라 포함이나 상업적 사용이 금지될 수 있습니다. 출력물을 배포하기 전에 반드시 해당 글꼴의 EULA를 확인하십시오.