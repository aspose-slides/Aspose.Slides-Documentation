---  
title: Dostosuj czcionki PowerPoint w PHP  
linktitle: Niestandardowa czcionka  
type: docs  
weight: 20  
url: /pl/php-java/custom-font/  
keywords:  
- czcionka  
- niestandardowa czcionka  
- zewnętrzna czcionka  
- załaduj czcionkę  
- zarządzaj czcionkami  
- folder czcionek  
- PowerPoint  
- OpenDocument  
- prezentacja  
- PHP  
- Aspose.Slides  
description: "Dostosuj czcionki w slajdach PowerPoint przy użyciu Aspose.Slides dla PHP poprzez Java, aby Twoje prezentacje były wyraźne i spójne na każdym urządzeniu."  
---
## **Przegląd**

Aspose.Slides umożliwia używanie niestandardowych czcionek w prezentacjach bez konieczności instalowania ich w systemie operacyjnym. Możesz ładować czcionki z własnych folderów, udostępniać czcionki dla konkretnej prezentacji za pośrednictwem źródeł czcionek na poziomie dokumentu lub ładować czcionki zewnętrzne bezpośrednio z danych binarnych.

Załadowane czcionki są używane podczas renderowania lub eksportu prezentacji, np. do PDF, obrazów i innych obsługiwanych formatów. Pomaga to zachować spójność wyjścia prezentacji w różnych środowiskach. Artykuł wyjaśnia także, jak sprawdzić foldery czcionek używane przez Aspose.Slides oraz jak wyczyścić pamięć podręczną czcionek po pracy z czcionkami zewnętrznymi.

Rejestrowanie niestandardowych czcionek do renderowania jest oddzielne od osadzania czcionek w pliku PPTX. Jeśli czcionka ma być przechowywana wewnątrz samej prezentacji, użyj wyraźnie funkcji osadzania czcionek.

Motyw prezentacji może odwoływać się do różnych rodzin czcionek dla poszczególnych systemów pisma. Te mapowania przechowują nazwy czcionek, ale nie instalują ani nie ładują plików czcionek. Zobacz [Czcionki tematyczne specyficzne dla skryptu](/slides/pl/php-java/script-specific-font-mappings/), aby zarządzać mapowaniami, i użyj opcji ładowania poniżej, aby udostępnić odwoływane czcionki dla spójnego renderowania.

{{% alert color="info" title="Uwaga" %}}

Aspose Slides pozwala ładować te czcionki za pomocą metody [loadExternalFonts](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* Czcionki TrueType (.ttf) i TrueType Collection (.ttc). Zobacz [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Czcionki OpenType (.otf). Zobacz [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Załaduj niestandardowe czcionki**

Aspose.Slides umożliwia ładowanie czcionek używanych w prezentacji bez instalacji ich w systemie. Ma to wpływ na wynik eksportu — takiego jak PDF, obrazy i inne obsługiwane formaty — dzięki czemu powstałe dokumenty wyglądają spójnie w różnych środowiskach. Czcionki są ładowane z własnych katalogów.

1. Określ jeden lub więcej folderów zawierających pliki czcionek.  
2. Wywołaj statyczną metodę [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---), aby załadować czcionki z tych folderów.  
3. Załaduj i renderuj/wyeksportuj prezentację.  
4. Wywołaj metodę [FontsLoader::clearCache](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontsloader/#clearCache--) w celu wyczyszczenia pamięci podręcznej czcionek.

```php
// Zdefiniuj foldery zawierające niestandardowe pliki czcionek.
$externalFontFolder1 = __DIR__ . "/external-fonts-1";
$externalFontFolder2 = __DIR__ . "/external-fonts-2";
$fontFolders = array($externalFontFolder1, $externalFontFolder2);

// Załaduj niestandardowe czcionki z określonych folderów.
FontsLoader::loadExternalFonts($fontFolders);

$presentation = null;
try {
    $presentationPath = __DIR__ . "/sample.pptx";
    $presentation = new Presentation($presentationPath);
    
    // Renderuj/eksportuj prezentację (np. do PDF, obrazów lub innych formatów) używając załadowanych czcionek.
    $outputPath = __DIR__ . "/output.pdf";
    $presentation->save($outputPath, SaveFormat::Pdf);
} finally {
    if ($presentation != null) $presentation->dispose();

    // Wyczyść pamięć podręczną czcionek po zakończeniu pracy.
    FontsLoader::clearCache();
}
```

{{% alert color="info" title="Uwaga" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) dodaje dodatkowe foldery do ścieżek wyszukiwania czcionek, ale nie zmienia kolejności inicjalizacji czcionek.  
Czcionki są inicjalizowane w następującej kolejności:

1. Domyślna ścieżka czcionek systemu operacyjnego.  
1. Ścieżki wczytane za pośrednictwem [FontsLoader](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontsloader/).

{{%/alert %}}

## **Uzyskaj foldery czcionek niestandardowych**

Aspose.Slides udostępnia metodę [getFontFolders](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontsloader/#getFontFolders--) umożliwiającą odnalezienie folderów czcionek. Metoda ta zwraca foldery dodane poprzez metodę `LoadExternalFonts` oraz systemowe foldery czcionek.

Poniższy kod PHP pokazuje, jak używać [getFontFolders](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontsloader/#getFontFolders--):

```php
# Ten wiersz wyświetla foldery, w których wyszukiwane są pliki czcionek.
# Są to foldery dodane za pośrednictwem metody LoadExternalFonts oraz systemowe foldery czcionek.
$fontFolders = FontsLoader::getFontFolders();
```

## **Określ niestandardowe czcionki używane w prezentacji**

Aspose.Slides udostępnia metodę [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/pl/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) umożliwiającą określenie zewnętrznych czcionek, które będą używane w prezentacji.

Poniższy kod PHP pokazuje, jak używać metody [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/pl/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

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
    # Pracuj z prezentacją
    # CustomFont1, CustomFont2 oraz czcionki z folderów assets\fonts i global\fonts oraz ich podfolderów są dostępne dla prezentacji
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Zarządzaj czcionkami zewnętrznie**

Aspose.Slides udostępnia metodę [loadExternalFont](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) umożliwiającą ładowanie zewnętrznych czcionek z danych binarnych.

Poniższy kod PHP demonstruje proces ładowania czcionki z tablicy bajtów:

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
        # zewnętrzna czcionka załadowana w czasie życia prezentacji
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

### Czy niestandardowe czcionki wpływają na eksport do wszystkich formatów (PDF, PNG, SVG, HTML)?

Tak. Powiązane czcionki są używane przez proces renderowania we wszystkich formatach eksportu.

### Czy niestandardowe czcionki są automatycznie osadzane w powstałym pliku PPTX?

Nie. Zarejestrowanie czcionki do renderowania nie jest tym samym co jej osadzenie w pliku PPTX. Jeśli potrzebujesz, aby czcionka była zawarta w pliku prezentacji, musisz użyć wyraźnie [funkcje osadzania](/slides/pl/php-java/embedded-font/).

### Czy mogę kontrolować zachowanie awaryjne, gdy niestandardowa czcionka nie zawiera niektórych glifów?

Tak. Skonfiguruj [font substitution](/slides/pl/php-java/font-substitution/), [replacement rules](/slides/pl/php-java/font-replacement/) oraz [fallback sets](/slides/pl/php-java/fallback-font/), aby dokładnie określić, która czcionka ma być użyta, gdy żądany glif jest nieobecny.

### Czy mogę używać czcionek w kontenerach Linux/Docker bez instalowania ich systemowo?

Tak. Wskaż własne foldery czcionek lub ładuj czcionki z tablic bajtów. Dzięki temu usuwasz zależność od systemowych katalogów czcionek w obrazie kontenera.

### Co z licencjonowaniem — czy mogę osadzać dowolną niestandardową czcionkę bez ograniczeń?

Odpowiadasz za zgodność z licencją czcionki. Warunki różnią się; niektóre licencje zakazują osadzania lub komercyjnego użycia. Zawsze sprawdzaj EULA czcionki przed rozpowszechnianiem wyników.