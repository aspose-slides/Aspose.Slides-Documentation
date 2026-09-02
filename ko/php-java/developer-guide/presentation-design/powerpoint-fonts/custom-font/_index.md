---
title: "PHP에서 PowerPoint 글꼴 사용자 정의"
linktitle: "맞춤 글꼴"
type: docs
weight: 20
url: /ko/php-java/custom-font/
keywords:
- "글꼴"
- "맞춤 글꼴"
- "외부 글꼴"
- "글꼴 로드"
- "글꼴 관리"
- "글꼴 폴더"
- "PowerPoint"
- "OpenDocument"
- "프레젠테이션"
- "PHP"
- "Aspose.Slides"
description: "Java를 통해 PHP용 Aspose.Slides를 사용하여 PowerPoint 슬라이드의 글꼴을 사용자 정의하고, 프레젠테이션을 어느 장치에서도 선명하고 일관되게 유지합니다."
---
## **개요**

Aspose.Slides를 사용하면 운영 체제에 폰트를 설치하지 않고도 프레젠테이션에서 사용자 정의 폰트를 사용할 수 있습니다. 사용자 지정 폴더에서 폰트를 로드하거나, 문서 수준 폰트 소스를 통해 특정 프레젠테이션에 폰트를 제공하거나, 바이너리 데이터에서 외부 폰트를 직접 로드할 수 있습니다.

로드된 폰트는 프레젠테이션을 렌더링하거나 PDF, 이미지 및 기타 지원 형식으로 내보낼 때 사용됩니다. 이를 통해 다양한 환경에서 프레젠테이션 출력이 일관되게 유지됩니다. 이 문서에서는 Aspose.Slides에서 사용하는 폰트 폴더를 확인하는 방법과 외부 폰트를 사용한 후 폰트 캐시를 지우는 방법도 설명합니다.

렌더링을 위한 사용자 정의 폰트 등록은 PPTX 파일에 폰트를 포함시키는 것과 별개입니다. 폰트를 프레젠테이션에 직접 저장해야 하는 경우, 폰트 포함 기능을 명시적으로 사용하십시오.

프레젠테이션 테마는 개별 쓰기 시스템에 대해 서로 다른 폰트 패밀리를 참조할 수 있습니다. 이러한 매핑은 폰트 이름을 저장하지만 폰트 파일을 설치하거나 로드하지는 않습니다. 매핑을 관리하려면 [스크립트 별 테마 글꼴](/slides/ko/php-java/script-specific-font-mappings/)을 참조하고, 아래 로드 옵션을 사용하여 일관된 렌더링을 위해 참조된 폰트를 사용할 수 있게 하십시오.

{{% alert color="info" title="Note" %}}
Aspose Slides에서는 [loadExternalFonts](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) 메서드를 사용하여 이러한 폰트를 로드할 수 있습니다:

* TrueType(.ttf) 및 TrueType Collection(.ttc) 폰트. 자세한 내용은 [TrueType](https://en.wikipedia.org/wiki/TrueType)을 참조하십시오.
* OpenType(.otf) 폰트. 자세한 내용은 [OpenType](https://en.wikipedia.org/wiki/OpenType)을 참조하십시오.
{{% /alert %}}

## **사용자 정의 폰트 로드**

Aspose.Slides를 사용하면 시스템에 폰트를 설치하지 않고 프레젠테이션에 사용되는 폰트를 로드할 수 있습니다. 이는 PDF, 이미지 및 기타 지원 형식과 같은 내보내기 결과에 영향을 주어, 생성된 문서가 다양한 환경에서 일관되게 보이도록 합니다. 폰트는 사용자 지정 디렉터리에서 로드됩니다.

1. 폰트 파일이 포함된 하나 이상의 폴더를 지정합니다.
2. 정적 [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) 메서드를 호출하여 해당 폴더에서 폰트를 로드합니다.
3. 프레젠테이션을 로드하고 렌더링/내보냅니다.
4. [FontsLoader::clearCache](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fontsloader/#clearCache--)를 호출하여 폰트 캐시를 지웁니다.

다음 코드 예제는 폰트 로드 과정을 보여줍니다:
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

    // 작업이 끝난 후 글꼴 캐시를 삭제합니다.
    FontsLoader::clearCache();
}
```

{{% alert color="info" title="Note" %}}
[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---)은 폰트 검색 경로에 추가 폴더를 넣지만 폰트 초기화 순서는 변경하지 않습니다.
폰트는 다음 순서로 초기화됩니다:

1. 기본 운영 체제 폰트 경로.
1. [FontsLoader](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fontsloader/)를 통해 로드된 경로.
{{%/alert %}}

## **사용자 정의 폰트 폴더 가져오기**

Aspose.Slides는 폰트 폴더를 찾을 수 있도록 [getFontFolders](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fontsloader/#getFontFolders--) 메서드를 제공합니다. 이 메서드는 `LoadExternalFonts` 메서드를 통해 추가된 폴더와 시스템 폰트 폴더를 반환합니다.

다음 PHP 코드는 [getFontFolders](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fontsloader/#getFontFolders--)를 사용하는 방법을 보여줍니다:
```php
# 이 줄은 글꼴 파일이 검색되는 폴더를 출력합니다.
# 이는 LoadExternalFonts 메서드를 통해 추가된 폴더와 시스템 글꼴 폴더입니다.
$fontFolders = FontsLoader::getFontFolders();
```

## **프레젠테이션에 사용되는 사용자 정의 폰트 지정**

Aspose.Slides는 프레젠테이션에 사용할 외부 폰트를 지정할 수 있도록 [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/ko/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) 메서드를 제공합니다.

다음 PHP 코드는 [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/ko/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) 메서드를 사용하는 방법을 보여줍니다:
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
    # CustomFont1, CustomFont2 및 assets\fonts와 global\fonts 폴더와 그 하위 폴더의 글꼴이 프레젠테이션에서 사용 가능합니다
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **외부에서 폰트 관리**

Aspose.Slides는 바이너리 데이터(byte[] data)에서 외부 폰트를 로드할 수 있도록 [loadExternalFont](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fontsloader/#loadExternalFont-byte---) 메서드를 제공합니다.

다음 PHP 코드는 바이트 배열을 사용한 폰트 로드 과정을 보여줍니다:
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
        # 프레젠테이션 수명 동안 로드된 외부 글꼴
    } finally {
        if (!java_is_null($presentation)) {
            $presentation->dispose();
        }
    }
} finally {
    FontsLoader->clearCache();
}
```

## **FAQ**

### 맞춤 폰트가 모든 형식(PDF, PNG, SVG, HTML)으로 내보내기에 영향을 줍니까?
예. 연결된 폰트는 모든 내보내기 형식에서 렌더러에 의해 사용됩니다.

### 맞춤 폰트가 결과 PPTX에 자동으로 포함됩니까?
아니요. 렌더링을 위해 폰트를 등록하는 것은 PPTX에 포함시키는 것과 동일하지 않습니다. 프레젠테이션 파일에 폰트를 포함시켜야 할 경우, 명시적인 [포함 기능](/slides/ko/php-java/embedded-font/)을 사용해야 합니다.

### 맞춤 폰트에 특정 글리프가 없을 때 대체 동작을 제어할 수 있습니까?
예. 요청한 글리프가 없을 때 사용되는 폰트를 정확히 정의하려면 [폰트 대체](/slides/ko/php-java/font-substitution/), [대체 규칙](/slides/ko/php-java/font-replacement/), 및 [대체 세트](/slides/ko/php-java/fallback-font/)를 구성하십시오.

### Linux/Docker 컨테이너에서 시스템 전체에 설치하지 않고 폰트를 사용할 수 있습니까?
예. 자체 폰트 폴더를 지정하거나 바이트 배열에서 폰트를 로드하면 됩니다. 이렇게 하면 컨테이너 이미지에서 시스템 폰트 디렉터리에 대한 의존성이 제거됩니다.

### 라이선스는 어떻게 되나요—제한 없이 어떤 맞춤 폰트든 포함시킬 수 있습니까?
폰트 라이선스 준수는 사용자 책임입니다. 조건은 다양하며, 일부 라이선스는 포함이나 상업적 사용을 금지합니다. 출력물을 배포하기 전에 항상 해당 폰트의 EULA를 검토하십시오.