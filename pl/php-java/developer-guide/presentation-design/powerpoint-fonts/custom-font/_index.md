---
title: Dostosuj czcionki PowerPoint w PHP
linktitle: Czcionka niestandardowa
type: docs
weight: 20
url: /pl/php-java/custom-font/
keywords:
- czcionka
- czcionka niestandardowa
- czcionka zewnętrzna
- wczytaj czcionkę
- zarządzaj czcionkami
- folder czcionek
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Dostosuj czcionki w slajdach PowerPoint przy użyciu Aspose.Slides dla PHP poprzez Java, aby Twoje prezentacje były wyraziste i spójne na każdym urządzeniu."
---
## **Przegląd**

Aspose.Slides pozwala używać niestandardowych czcionek w prezentacjach bez ich instalowania w systemie operacyjnym. Możesz wczytać czcionki z własnych folderów, udostępnić czcionki dla konkretnej prezentacji poprzez źródła czcionek na poziomie dokumentu lub wczytać czcionki zewnętrzne bezpośrednio z danych binarnych.

Wczytane czcionki są używane podczas renderowania lub eksportu prezentacji, np. do PDF, obrazów i innych obsługiwanych formatów. Pomaga to utrzymać spójność wyników prezentacji w różnych środowiskach. Artykuł wyjaśnia również, jak sprawdzić foldery czcionek używane przez Aspose.Slides oraz jak wyczyścić pamięć podręczną czcionek po pracy z czcionkami zewnętrznymi.

Rejestrowanie niestandardowych czcionek do renderowania jest oddzielne od osadzania czcionek w pliku PPTX. Jeśli czcionka musi być przechowywana wewnątrz prezentacji, użyj wyraźnie funkcji osadzania czcionek.

{{% alert color="primary" %}} 

Aspose Slides pozwala wczytać te czcionki przy użyciu metody [loadExternalFonts](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* Czcionki TrueType (.ttf) i kolekcje TrueType (.ttc). Zobacz [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Czcionki OpenType (.otf). Zobacz [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Ładowanie niestandardowych czcionek**

Aspose.Slides pozwala wczytać czcionki używane w prezentacji bez ich instalowania w systemie. Ma to wpływ na wynik eksportu — takiego jak PDF, obrazy i inne obsługiwane formaty — dzięki czemu powstałe dokumenty wyglądają spójnie w różnych środowiskach. Czcionki są wczytywane z własnych katalogów.

1. Określ jeden lub więcej folderów zawierających pliki czcionek.
2. Wywołaj statyczną metodę [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) aby wczytać czcionki z tych folderów.
3. Wczytaj i renderuj/eksportuj prezentację.
4. Wywołaj [FontsLoader::clearCache](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontsloader/#clearCache--) aby wyczyścić pamięć podręczną czcionek.

Poniższy przykład kodu demonstruje proces ładowania czcionek:

```php
// Zdefiniuj foldery zawierające własne pliki czcionek.
$externalFontFolder1 = __DIR__ . "/external-fonts-1";
$externalFontFolder2 = __DIR__ . "/external-fonts-2";
$fontFolders = array($externalFontFolder1, $externalFontFolder2);

// Wczytaj własne czcionki z określonych folderów.
FontsLoader::loadExternalFonts($fontFolders);

$presentation = null;
try {
    $presentationPath = __DIR__ . "/sample.pptx";
    $presentation = new Presentation($presentationPath);
    
    // Renderuj/wyeksportuj prezentację (np. do PDF, obrazów lub innych formatów) używając wczytanych czcionek.
    $outputPath = __DIR__ . "/output.pdf";
    $presentation->save($outputPath, SaveFormat::Pdf);
} finally {
    if ($presentation != null) $presentation->dispose();

    // Wyczyść pamięć podręczną czcionek po zakończeniu pracy.
    FontsLoader::clearCache();
}
```

{{% alert color="info" title="Note" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) dodaje dodatkowe foldery do ścieżek wyszukiwania czcionek, ale nie zmienia kolejności inicjalizacji czcionek.
Czcionki są inicjalizowane w następującej kolejności:

1. Domyślna ścieżka czcionek systemu operacyjnego.
1. Ścieżki wczytane za pomocą [FontsLoader](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontsloader/).

{{%/alert %}}

## **Pobieranie niestandardowych folderów czcionek**

Aspose.Slides udostępnia metodę [getFontFolders](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontsloader/#getFontFolders--) , która pozwala znaleźć foldery czcionek. Metoda ta zwraca foldery dodane poprzez metodę `LoadExternalFonts` oraz foldery czcionek systemowych.

Ten kod PHP pokazuje, jak używać [getFontFolders](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontsloader/#getFontFolders--):

```php
# Ten wiersz wyświetla foldery, w których wyszukiwane są pliki czcionek.
# Są to foldery dodane metodą LoadExternalFonts oraz foldery czcionek systemowych.
$fontFolders = FontsLoader::getFontFolders();
```

## **Określanie niestandardowych czcionek używanych w prezentacji**

Aspose.Slides udostępnia metodę [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/pl/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) , która pozwala określić zewnętrzne czcionki, które będą używane w prezentacji.

Ten kod PHP pokazuje, jak używać metody [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/pl/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) :

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

## **Zarządzanie czcionkami zewnętrznie**

Aspose.Slides udostępnia metodę [loadExternalFont](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data), która pozwala wczytać czcionki zewnętrzne z danych binarnych.

Ten kod PHP demonstruje proces ładowania czcionek z tablicy bajtów:

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
        # czcionka zewnętrzna załadowana w czasie trwania prezentacji
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

**Czy niestandardowe czcionki wpływają na eksport do wszystkich formatów (PDF, PNG, SVG, HTML)?**

Tak. Powiązane czcionki są używane przez renderownik we wszystkich formatach eksportu.

**Czy niestandardowe czcionki są automatycznie osadzane w powstałym pliku PPTX?**

Nie. Zarejestrowanie czcionki do renderowania nie jest tym samym co osadzenie jej w pliku PPTX. Jeśli potrzebujesz, aby czcionka była zawarta w pliku prezentacji, musisz użyć wyraźnych [funkcji osadzania](/slides/pl/php-java/embedded-font/).

**Czy mogę kontrolować zachowanie awaryjne, gdy niestandardowa czcionka nie zawiera niektórych glifów?**

Tak. Skonfiguruj [zastępowanie czcionek](/slides/pl/php-java/font-substitution/), [zasady zamiany](/slides/pl/php-java/font-replacement/) i [zestawy awaryjne](/slides/pl/php-java/fallback-font/), aby dokładnie określić, która czcionka ma być użyta, gdy żądany glif jest nieobecny.

**Czy mogę używać czcionek w kontenerach Linux/Docker bez instalacji systemowej?**

Tak. Wskaż własne foldery czcionek lub wczytaj czcionki z tablic bajtów. Eliminuję to zależność od katalogów czcionek systemowych w obrazie kontenera.

**Co z licencjonowaniem — czy mogę osadzić dowolną niestandardową czcionkę bez ograniczeń?**

Odpowiedzialność za zgodność z licencją czcionki spoczywa na Tobie. Warunki różnią się; niektóre licencje zabraniają osadzania lub użycia komercyjnego. Zawsze sprawdzaj EULA czcionki przed rozpowszechnianiem wyników.