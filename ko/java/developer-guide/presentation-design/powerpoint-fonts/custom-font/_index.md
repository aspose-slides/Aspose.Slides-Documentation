---
title: Java에서 PowerPoint 글꼴 사용자 정의
linktitle: 사용자 정의 글꼴
type: docs
weight: 20
url: /ko/java/custom-font/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 PowerPoint 슬라이드의 글꼴을 사용자 정의하여 프레젠테이션을 언제든지 선명하고 일관되게 유지합니다."
---
## **개요**

Aspose.Slides를 사용하면 운영 체제에 폰트를 설치하지 않고도 프레젠테이션에서 사용자 정의 폰트를 사용할 수 있습니다. 사용자 정의 폴더에서 폰트를 로드하거나, 문서 수준 폰트 소스를 통해 특정 프레젠테이션에 폰트를 제공하거나, 바이너리 데이터에서 외부 폰트를 직접 로드할 수 있습니다.

로드된 폰트는 프레젠테이션을 렌더링하거나 PDF, 이미지 및 기타 지원 형식으로 내보낼 때 사용됩니다. 이를 통해 다양한 환경에서 프레젠테이션 출력이 일관되게 유지됩니다. 이 문서에서는 Aspose.Slides에서 사용하는 폰트 폴더를 확인하는 방법과 외부 폰트를 사용한 후 폰트 캐시를 지우는 방법에 대해서도 설명합니다.

렌더링을 위해 사용자 정의 폰트를 등록하는 것은 PPTX 파일에 폰트를 삽입하는 것과 별개입니다. 폰트를 프레젠테이션 자체에 저장해야 하는 경우, 폰트 삽입 기능을 명시적으로 사용하십시오.

{{% alert color="info" %}} 

Aspose Slides는 다음 메서드인 [loadExternalFonts](https://reference.aspose.com/slides/ko/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---)를 사용하여 이러한 폰트를 로드할 수 있습니다:

* TrueType(.ttf) 및 TrueType Collection(.ttc) 폰트. 자세히 보려면 [TrueType](https://en.wikipedia.org/wiki/TrueType)를 참조하세요.
* OpenType(.otf) 폰트. 자세히 보려면 [OpenType](https://en.wikipedia.org/wiki/OpenType)를 참조하세요.

{{% /alert %}}

## **사용자 정의 폰트 로드**

Aspose.Slides를 사용하면 시스템에 폰트를 설치하지 않고도 프레젠테이션에서 사용하는 폰트를 로드할 수 있습니다. 이는 PDF, 이미지 및 기타 지원 형식과 같은 내보내기 결과에 영향을 주어, 다양한 환경에서 생성된 문서가 일관되게 보이도록 합니다. 폰트는 사용자 정의 디렉터리에서 로드됩니다.

1. 폰트 파일이 들어 있는 하나 이상의 폴더를 지정합니다.
2. 해당 폴더에서 폰트를 로드하기 위해 정적 메서드 [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ko/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---)를 호출합니다.
3. 프레젠테이션을 로드하고 렌더링/내보냅니다.
4. 폰트 캐시를 지우기 위해 [FontsLoader.clearCache](https://reference.aspose.com/slides/ko/java/com.aspose.slides/FontsLoader#clearCache--)를 호출합니다.

다음 코드 예제는 폰트 로드 과정을 보여줍니다:

```java
import com.aspose.slides.*;

// 사용자 정의 글꼴 파일이 들어 있는 폴더를 정의합니다.
String[] fontFolders = new String[] { "assets/fonts", "global/fonts" };

// 지정된 폴더에서 사용자 정의 글꼴을 로드합니다.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // 로드된 글꼴을 사용하여 프레젠테이션을 렌더링/내보냅니다(예: PDF, 이미지 또는 기타 형식).
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // 작업이 끝난 후 글꼴 캐시를 지웁니다.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ko/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---)는 폰트 검색 경로에 추가 폴더를 포함하지만, 폰트 초기화 순서는 변경하지 않습니다.  
폰트는 다음 순서대로 초기화됩니다:

1. 기본 운영 체제 폰트 경로.
2. [FontsLoader](https://reference.aspose.com/slides/ko/java/com.aspose.slides/fontsloader/)를 통해 로드된 경로.

{{%/alert %}}

## **사용자 정의 폰트 폴더 가져오기**
Aspose.Slides는 [getFontFolders](https://reference.aspose.com/slides/ko/java/com.aspose.slides/fontsloader/#getFontFolders--) 메서드를 제공하여 폰트 폴더를 찾을 수 있게 합니다. 이 메서드는 `LoadExternalFonts` 메서드를 통해 추가된 폴더와 시스템 폰트 폴더를 반환합니다.

다음 Java 코드는 [getFontFolders](https://reference.aspose.com/slides/ko/java/com.aspose.slides/fontsloader/#getFontFolders--)를 사용하는 방법을 보여줍니다:

```java
import com.aspose.slides.*;

// 이 줄은 글꼴 파일이 검색되는 폴더를 출력합니다.
// 이는 LoadExternalFonts 메서드를 통해 추가된 폴더와 시스템 글꼴 폴더입니다.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **프레젠테이션에 사용되는 사용자 정의 폰트 지정**
Aspose.Slides는 프레젠테이션에 사용될 외부 폰트를 지정할 수 있도록 [setDocumentLevelFontSources](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) 속성을 제공합니다.

다음 Java 코드는 [setDocumentLevelFontSources](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) 속성을 사용하는 방법을 보여줍니다:

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
    // CustomFont1, CustomFont2 및 assets\fonts와 global\fonts 폴더와 그 하위 폴더의 글꼴이 프레젠테이션에서 사용 가능합니다
} finally {
    if (pres != null) pres.dispose();
}
```

## **외부에서 폰트 관리**

Aspose.Slides는 바이너리 데이터에서 외부 폰트를 로드할 수 있도록 [loadExternalFont](https://reference.aspose.com/slides/ko/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) 메서드를 제공합니다.

다음 Java 코드는 바이트 배열 폰트 로드 과정을 보여줍니다:

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

### 사용자 정의 폰트가 모든 형식(PDF, PNG, SVG, HTML)으로의 내보내기에 영향을 줍니까?

예. 연결된 폰트는 렌더러에 의해 모든 내보내기 형식에서 사용됩니다.

### 사용자 정의 폰트가 결과 PPTX에 자동으로 삽입됩니까?

아니오. 렌더링을 위해 폰트를 등록하는 것은 PPTX에 삽입하는 것과 동일하지 않습니다. 프레젠테이션 파일에 폰트를 포함해야 하면 명시적인 [embedding features](/slides/ko/java/embedded-font/)를 사용해야 합니다.

### 사용자 정의 폰트에 특정 글리프가 없을 때 대체 동작을 제어할 수 있습니까?

예. 요청된 글리프가 없을 때 어떤 폰트를 사용할지 정확히 정의하려면 [font substitution](/slides/ko/java/font-substitution/), [replacement rules](/slides/ko/java/font-replacement/), [fallback sets](/slides/ko/java/fallback-font/)를 설정하십시오.

### Linux/Docker 컨테이너에서 시스템 전체에 설치하지 않고 폰트를 사용할 수 있습니까?

예. 자체 폰트 폴더를 지정하거나 바이트 배열에서 폰트를 로드하면 됩니다. 이렇게 하면 컨테이너 이미지에서 시스템 폰트 디렉터리에 대한 종속성이 제거됩니다.

### 라이선스는 어떻게 되나요—제한 없이 어떤 사용자 정의 폰트든 삽입할 수 있습니까?

폰트 라이선스 준수는 사용자의 책임입니다. 조건은 다양하며, 일부 라이선스는 삽입이나 상업적 사용을 금지합니다. 출력을 배포하기 전에 항상 해당 폰트의 EULA를 확인하십시오.