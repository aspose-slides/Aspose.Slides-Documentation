---
title: Android에서 PowerPoint 글꼴 사용자 지정
linktitle: 맞춤 글꼴
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
description: "Android용 Aspose.Slides와 Java를 사용하여 PowerPoint 슬라이드의 글꼴을 사용자 지정함으로써 프레젠테이션을 모든 기기에서 선명하고 일관되게 유지하세요."
---
## **개요**

Aspose.Slides는 운영 체제에 설치하지 않고도 프레젠테이션에서 사용자 지정 글꼴을 사용할 수 있게 합니다. 사용자 지정 폴더에서 글꼴을 로드하거나 문서 수준 글꼴 소스를 통해 특정 프레젠테이션에 글꼴을 제공하거나 이진 데이터에서 외부 글꼴을 직접 로드할 수 있습니다.

로드된 글꼴은 프레젠테이션이 렌더링되거나 PDF, 이미지 및 기타 지원되는 형식으로 내보내질 때 사용됩니다. 이는 다양한 환경에서 프레젠테이션 출력이 일관되게 유지되도록 도와줍니다. 이 문서에서는 Aspose.Slides가 사용하는 글꼴 폴더를 검사하는 방법과 외부 글꼴을 사용한 후 글꼴 캐시를 지우는 방법도 설명합니다.

렌더링을 위한 사용자 지정 글꼴 등록은 PPTX 파일에 글꼴을 포함시키는 것과 별개입니다. 글꼴을 프레젠테이션 자체에 저장해야 하는 경우 명시적으로 글꼴 포함 기능을 사용하십시오.

프레젠테이션 테마는 개별 쓰기 시스템에 대해 서로 다른 글꼴 패밀리를 참조할 수 있습니다. 이러한 매핑은 글꼴 이름만 저장하며 글꼴 파일을 설치하거나 로드하지는 않습니다. 매핑을 관리하려면 [Script-Specific Theme Fonts](/slides/ko/androidjava/script-specific-font-mappings/)을 참조하고, 아래 로딩 옵션을 사용하여 참조된 글꼴을 일관된 렌더링을 위해 사용할 수 있도록 하세요.

{{% alert color="info" title="Note" %}}
Aspose Slides는 [loadExternalFonts](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) 메서드를 사용하여 이러한 글꼴을 로드할 수 있도록 합니다:

* TrueType(.ttf) 및 TrueType Collection(.ttc) 글꼴. 자세한 내용은 [TrueType](https://en.wikipedia.org/wiki/TrueType)을 참조하세요.
* OpenType(.otf) 글꼴. 자세한 내용은 [OpenType](https://en.wikipedia.org/wiki/OpenType)을 참조하세요.
{{% /alert %}}

## **맞춤 글꼴 로드**

Aspose.Slides는 시스템에 설치하지 않고도 프레젠테이션에서 사용되는 글꼴을 로드할 수 있게 합니다. 이는 PDF, 이미지 및 기타 지원되는 형식과 같은 내보내기 결과에 영향을 주어, 다양한 환경에서 문서가 일관되게 보이도록 합니다. 글꼴은 사용자 지정 디렉터리에서 로드됩니다.

1. 글꼴 파일이 포함된 하나 이상의 폴더를 지정합니다.
2. 해당 폴더에서 글꼴을 로드하려면 정적 [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) 메서드를 호출합니다.
3. 프레젠테이션을 로드하고 렌더링/내보내기합니다.
4. 글꼴 캐시를 지우려면 [FontsLoader.clearCache](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/FontsLoader#clearCache--)를 호출합니다.

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

    // 로드된 글꼴을 사용하여 프레젠테이션을 렌더링/내보냅니다 (예: PDF, 이미지 또는 기타 형식).
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // 작업이 끝난 후 글꼴 캐시를 정리합니다.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---)은 글꼴 검색 경로에 추가 폴더를 포함하지만, 글꼴 초기화 순서는 변경하지 않습니다.
글꼴은 다음 순서대로 초기화됩니다:

1. 기본 운영 체제 글꼴 경로.
1. [FontsLoader](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/fontsloader/)를 통해 로드된 경로.
{{%/alert %}}

## **맞춤 글꼴 폴더 가져오기**
Aspose.Slides는 [getFontFolders](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) 메서드를 제공하여 글꼴 폴더를 찾을 수 있게 합니다. 이 메서드는 `LoadExternalFonts` 메서드를 통해 추가된 폴더와 시스템 글꼴 폴더를 반환합니다.

다음 Java 코드가 [getFontFolders](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) 사용 방법을 보여줍니다:

```java
import com.aspose.slides.*;

// 이 줄은 글꼴 파일이 검색되는 폴더를 출력합니다.
// 이는 LoadExternalFonts 메서드를 통해 추가된 폴더와 시스템 글꼴 폴더입니다.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **프레젠테이션에 사용되는 맞춤 글꼴 지정**
Aspose.Slides는 [setDocumentLevelFontSources](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) 속성을 제공하여 프레젠테이션에 사용할 외부 글꼴을 지정할 수 있게 합니다.

다음 Java 코드가 [setDocumentLevelFontSources](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) 속성 사용 방법을 보여줍니다:

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
    // CustomFont1, CustomFont2 및 assets\fonts와 global\fonts 폴더와 그 하위 폴더의 글꼴이 프레젠테이션에서 사용 가능합니다.
} finally {
    if (pres != null) pres.dispose();
}
```

## **글꼴을 외부에서 관리하기**

Aspose.Slides는 [loadExternalFont](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) 메서드를 제공하여 이진 데이터에서 외부 글꼴을 로드할 수 있게 합니다.

다음 Java 코드가 바이트 배열을 사용한 글꼴 로드 과정을 보여줍니다:

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

## **자주 묻는 질문**

### 사용자 지정 글꼴이 모든 형식(PDF, PNG, SVG, HTML)으로의 내보내기에 영향을 미칩니까?

예. 연결된 글꼴은 모든 내보내기 형식에서 렌더러에 의해 사용됩니다.

### 사용자 지정 글꼴이 결과 PPTX에 자동으로 포함됩니까?

아니요. 렌더링을 위한 글꼴 등록은 PPTX에 포함시키는 것과 동일하지 않습니다. 프레젠테이션 파일에 글꼴을 포함해야 하는 경우 명시적인 [embedding features](/slides/ko/androidjava/embedded-font/)를 사용해야 합니다.

### 사용자 지정 글꼴에 특정 글리프가 없을 때 대체 동작을 제어할 수 있습니까?

예. [font substitution](/slides/ko/androidjava/font-substitution/), [replacement rules](/slides/ko/androidjava/font-replacement/), 및 [fallback sets](/slides/ko/androidjava/fallback-font/)을 구성하여 요청된 글리프가 없을 때 정확히 어떤 글꼴을 사용할지 정의할 수 있습니다.

### Linux/Docker 컨테이너에서 시스템 전체에 설치하지 않고 글꼴을 사용할 수 있습니까?

예. 자체 글꼴 폴더를 지정하거나 바이트 배열에서 글꼴을 로드하면 컨테이너 이미지에 시스템 글꼴 디렉터리에 대한 의존성을 없앨 수 있습니다.

### 라이선스 측면에서 제한 없이 모든 사용자 지정 글꼴을 포함할 수 있습니까?

글꼴 라이선스 준수는 사용자의 책임입니다. 라이선스에 따라 포함이 금지되거나 상업적 사용이 제한될 수 있습니다. 출판 전에 항상 글꼴의 EULA를 검토하십시오.