---
title: PHP에서 PowerPoint 글꼴 사용자 지정
linktitle: 사용자 정의 글꼴
type: docs
weight: 20
url: /ko/php-java/custom-font/
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
- PHP
- Aspose.Slides
description: "Java를 통해 PHP용 Aspose.Slides로 PowerPoint 슬라이드의 글꼴을 사용자 지정하여 프레젠테이션을 어떤 장치에서도 선명하고 일관되게 유지합니다."
---
## **개요**

Aspose.Slides는 운영 체제에 설치하지 않고도 프레젠테이션에서 사용자 지정 글꼴을 사용할 수 있게 합니다. 사용자 지정 폴더에서 글꼴을 로드하거나, 문서 수준 글꼴 소스를 통해 특정 프레젠테이션에 글꼴을 제공하거나, 바이너리 데이터에서 외부 글꼴을 직접 로드할 수 있습니다.

로드된 글꼴은 프레젠테이션이 렌더링되거나 PDF, 이미지 및 기타 지원 형식으로 내보내질 때 사용됩니다. 이를 통해 서로 다른 환경에서도 프레젠테이션 출력이 일관되게 유지됩니다. 이 문서에서는 Aspose.Slides가 사용하는 글꼴 폴더를 확인하는 방법과 외부 글꼴 작업 후 글꼴 캐시를 지우는 방법도 설명합니다.

렌더링용으로 사용자 지정 글꼴을 등록하는 것은 PPTX 파일에 글꼴을 포함시키는 것과 별개입니다. 프레젠테이션 자체에 글꼴을 저장해야 하는 경우 명시적으로 글꼴 포함 기능을 사용하십시오.

{{% alert color="primary" %}} 
Aspose Slides는 다음 메서드를 사용하여 이러한 글꼴을 로드할 수 있습니다:

* TrueType (.ttf) 및 TrueType Collection (.ttc) 글꼴. 자세히 보기 [TrueType](https://en.wikipedia.org/wiki/TrueType).
* OpenType (.otf) 글꼴. 자세히 보기 [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **사용자 지정 글꼴 로드**

Aspose.Slides는 시스템에 설치하지 않고도 프레젠테이션에서 사용되는 글꼴을 로드할 수 있게 합니다. 이는 PDF, 이미지 및 기타 지원 형식과 같은 내보내기 결과가 환경에 관계없이 일관되게 보이도록 영향을 줍니다. 글꼴은 사용자 지정 디렉터리에서 로드됩니다.

1. 글꼴 파일이 들어 있는 하나 이상의 폴더를 지정합니다.
2. 해당 폴더에서 글꼴을 로드하려면 정적 [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) 메서드를 호출합니다.
3. 프레젠테이션을 로드하고 렌더링/내보냅니다.
4. 글꼴 캐시를 지우려면 [FontsLoader::clearCache](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fontsloader/#clearCache--) 메서드를 호출합니다.

다음 코드 예제는 글꼴 로드 과정을 보여줍니다:

```php
// 사용자 정의 글꼴 파일이 들어 있는 폴더를 정의합니다.
$externalFontFolder1 = __DIR__ . "/external-fonts-1";
$externalFontFolder2 = __DIR__ . "/external-fonts-2";
$fontFolders = array($externalFontFolder1, $externalFontFolder2);

// 지정된 폴더에서 사용자 정의 글꼴을 로드합니다.
FontsLoader::loadExternalFonts($fontFolders);

$presentation = null;
try {
    $presentationPath = __DIR__ . "/sample.pptx";
    $presentation = new Presentation($presentationPath);
    
    // 로드된 글꼴을 사용하여 프레젠테이션을 렌더링/내보냅니다 (예: PDF, 이미지 또는 기타 형식).
    $outputPath = __DIR__ . "/output.pdf";
    $presentation->save($outputPath, SaveFormat::Pdf);
} finally {
    if ($presentation != null) $presentation->dispose();

    // 작업이 끝난 후 글꼴 캐시를 지웁니다.
    FontsLoader::clearCache();
}
```

{{% alert color="info" title="참고" %}}
[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---)은 글꼴 검색 경로에 추가 폴더를 포함하지만 글꼴 초기화 순서는 변경하지 않습니다.
글꼴은 다음 순서대로 초기화됩니다:

1. 기본 운영 체제 글꼴 경로.
1. [FontsLoader](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fontsloader/)를 통해 로드된 경로.
{{%/alert %}}

## **사용자 지정 글꼴 폴더 가져오기**

Aspose.Slides는 [getFontFolders](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fontsloader/#getFontFolders--) 메서드를 제공하여 글꼴 폴더를 찾을 수 있게 합니다. 이 메서드는 `LoadExternalFonts` 메서드를 통해 추가된 폴더와 시스템 글꼴 폴더를 반환합니다.

다음 PHP 코드는 [getFontFolders](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fontsloader/#getFontFolders--) 사용 방법을 보여 줍니다:

```php
# 이 라인은 폰트 파일이 검색되는 폴더를 출력합니다.
# 이는 LoadExternalFonts 메서드를 통해 추가된 폴더와 시스템 폰트 폴더입니다.
$fontFolders = FontsLoader::getFontFolders();
```

## **프레젠테이션에 사용되는 사용자 지정 글꼴 지정**

Aspose.Slides는 [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/ko/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) 메서드를 제공하여 프레젠테이션에 사용할 외부 글꼴을 지정할 수 있게 합니다.

다음 PHP 코드는 [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/ko/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) 사용 방법을 보여 줍니다:

```php
$javaArray = new JavaClass("java.lang.reflect.Array");
$javaByteType = (new JavaClass("java.lang.Byte"))->TYPE;

$customFontsDirectory = __DIR__ . "/customfonts/";
$customFont1Path = $customFontsDirectory . "CustomFont1.ttf";
$customFontFile1 = new Java("java.io.File", $customFont1Path);
$customFontFile1Length = $customFontFile1->length();
$memoryFont1 = $javaArray->newInstance($javaByteType, $customFontFile1Length);
$dataInputStream1 = null;
try {
    $fileInputStream1 = new Java("java.io.FileInputStream", $customFontFile1);
    $dataInputStream1 = new Java("java.io.DataInputStream", $fileInputStream1);
    $dataInputStream1->readFully($memoryFont1);
} finally {
    if (!java_is_null($dataInputStream1)) $dataInputStream1->close();
}

$customFont2Path = $customFontsDirectory . "CustomFont2.ttf";
$customFontFile2 = new Java("java.io.File", $customFont2Path);
$customFontFile2Length = $customFontFile2->length();
$memoryFont2 = $javaArray->newInstance($javaByteType, $customFontFile2Length);
$dataInputStream2 = null;
try {
    $fileInputStream2 = new Java("java.io.FileInputStream", $customFontFile2);
    $dataInputStream2 = new Java("java.io.DataInputStream", $fileInputStream2);
    $dataInputStream2->readFully($memoryFont2);
} finally {
    if (!java_is_null($dataInputStream2)) $dataInputStream2->close();
}

$loadOptions = new LoadOptions();
$assetFontsFolder = __DIR__ . "/assets/fonts";
$globalFontsFolder = __DIR__ . "/global/fonts";
$loadOptions->getDocumentLevelFontSources()->setFontFolders(array($assetFontsFolder, $globalFontsFolder));
$loadOptions->getDocumentLevelFontSources()->setMemoryFonts(array($memoryFont1, $memoryFont2 ));

$presentationPath = __DIR__ . "/MyPresentation.pptx";
$presentation = new Presentation($presentationPath, $loadOptions);
try {
    # 프레젠테이션 작업
    # CustomFont1, CustomFont2 및 assets\fonts와 global\fonts 폴더와 그 하위 폴더의 글꼴이 프레젠테이션에서 사용 가능합니다.
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **외부에서 글꼴 관리**

Aspose.Slides는 [loadExternalFont](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) 메서드를 제공하여 바이너리 데이터에서 외부 글꼴을 로드할 수 있게 합니다.

다음 PHP 코드는 바이트 배열을 이용한 글꼴 로드 과정을 시연합니다:

```php
$javaArray = new JavaClass("java.lang.reflect.Array");
$javaByteType = (new JavaClass("java.lang.Byte"))->TYPE;
$fontDirectory = __DIR__ . "/";

$dataInputStream = null;
try {
    $fontPath = $fontDirectory . "ARIALN.TTF";
    $fileInputStream = new Java("java.io.FileInputStream", $fontPath);
    $dataInputStream = new Java("java.io.DataInputStream", $fileInputStream);
    $fontBytes = $javaArray->newInstance($javaByteType, $dataInputStream->available());
    $dataInputStream->readFully($fontBytes);
} finally {
    if (!java_is_null($dataInputStream)) $dataInputStream->close();
}
FontsLoader::loadExternalFont($fontBytes);

$dataInputStream = null;
try {
    $fontPath = $fontDirectory . "ARIALNBI.TTF";
    $fileInputStream = new Java("java.io.FileInputStream", $fontPath);
    $dataInputStream = new Java("java.io.DataInputStream", $fileInputStream);
    $fontBytes = $javaArray->newInstance($javaByteType, $dataInputStream->available());
    $dataInputStream->readFully($fontBytes);
} finally {
    if (!java_is_null($dataInputStream)) $dataInputStream->close();
}
FontsLoader::loadExternalFont($fontBytes);

$dataInputStream = null;
try {
    $fontPath = $fontDirectory . "ARIALNI.TTF";
    $fileInputStream = new Java("java.io.FileInputStream", $fontPath);
    $dataInputStream = new Java("java.io.DataInputStream", $fileInputStream);
    $fontBytes = $javaArray->newInstance($javaByteType, $dataInputStream->available());
    $dataInputStream->readFully($fontBytes);
} finally {
    if (!java_is_null($dataInputStream)) $dataInputStream->close();
}
FontsLoader::loadExternalFont($fontBytes);

try {
    $presentation = new Presentation();
    try {
        # 프레젠테이션 수명 동안 외부 글꼴이 로드되었습니다.
    } finally {
        if (!java_is_null($presentation)) {
            $presentation->dispose();
        }
    }
} finally {
    FontsLoader->clearCache();
}
```

## **자주 묻는 질문**

**사용자 지정 글꼴이 모든 형식(PDF, PNG, SVG, HTML)으로의 내보내기에 영향을 줍니까?**

예. 연결된 글꼴은 렌더러에 의해 모든 내보내기 형식에서 사용됩니다.

**사용자 지정 글꼴이 결과 PPTX에 자동으로 포함됩니까?**

아니요. 렌더링용으로 글꼴을 등록하는 것은 PPTX에 포함시키는 것과 동일하지 않습니다. 프레젠테이션 파일에 글꼴을 포함해야 하면 명시적인 [embedding features](/slides/ko/php-java/embedded-font/)를 사용해야 합니다.

**사용자 지정 글꼴에 특정 글리프가 없을 때 폴백 동작을 제어할 수 있습니까?**

예. [font substitution](/slides/ko/php-java/font-substitution/), [replacement rules](/slides/ko/php-java/font-replacement/), 및 [fallback sets](/slides/ko/php-java/fallback-font/)를 구성하여 요청된 글리프가 없을 때 정확히 어떤 글꼴을 사용할지 정의할 수 있습니다.

**Linux/Docker 컨테이너에서 시스템 전체에 설치하지 않고도 글꼴을 사용할 수 있습니까?**

예. 자체 글꼴 폴더를 지정하거나 바이트 배열에서 글꼴을 로드하면 됩니다. 이를 통해 컨테이너 이미지 내 시스템 글꼴 디렉터리에 대한 의존성을 제거할 수 있습니다.

**라이선스는 어떻게 되나요—제한 없이 모든 사용자 지정 글꼴을 포함할 수 있습니까?**

글꼴 라이선스 준수는 사용자의 책임입니다. 라이선스 조건은 다양하며, 일부는 포함이나 상업적 사용을 금지합니다. 출력물을 배포하기 전에 항상 글꼴의 EULA를 검토하십시오.