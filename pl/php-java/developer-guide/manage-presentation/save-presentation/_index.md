---
title: Zapisywanie prezentacji w PHP
linktitle: Zapisz prezentację
type: docs
weight: 80
url: /pl/php-java/save-presentation/
keywords:
- zapisz PowerPoint
- zapisz OpenDocument
- zapisz prezentację
- zapisz slajd
- zapisz PPT
- zapisz PPTX
- zapisz ODP
- prezentacja do pliku
- prezentacja do strumienia
- wstępnie określony typ widoku
- ścisły format Office Open XML
- tryb Zip64
- odświeżanie miniatury
- zapis postępu
- PHP
- Aspose.Slides
description: "Odkryj, jak zapisywać prezentacje przy użyciu Aspose.Slides dla PHP via Java — eksportuj do PowerPoint lub OpenDocument, zachowując układy, czcionki i efekty."
---
## **Przegląd**

[Open Presentations in PHP](/slides/pl/php-java/open-presentation/) opisuje, jak używać klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) do otwierania prezentacji. Ten artykuł wyjaśnia, jak tworzyć i zapisywać prezentacje. Klasa [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) zawiera zawartość prezentacji. Niezależnie od tego, czy tworzysz prezentację od podstaw, czy modyfikujesz istniejącą, chcesz ją zapisać po zakończeniu. Dzięki Aspose.Slides dla PHP możesz zapisać do **pliku** lub **strumienia**. Ten artykuł opisuje różne sposoby zapisywania prezentacji.

## **Zapisz prezentacje do plików**

Zapisz prezentację do pliku, wywołując metodę `save` klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/). Przekaż nazwę pliku i format zapisu do tej metody. Poniższy przykład pokazuje, jak zapisać prezentację przy użyciu Aspose.Slides.

```php
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
$presentation = new Presentation();
try {
    // Wykonaj tutaj pewne działania...

    // Zapisz prezentację do pliku.
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Zapisz prezentacje do strumieni**

Możesz zapisać prezentację do strumienia, przekazując strumień wyjściowy do metody `save` klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/). Prezentację można zapisać w wielu typach strumieni. W poniższym przykładzie tworzymy nową prezentację i zapisujemy ją do strumienia plikowego.

```php
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
$presentation = new Presentation();
try {
    $fileStream = new Java("java.io.FileOutputStream", "Output.pptx");
    try {
        // Zapisz prezentację do strumienia.
        $presentation->save($fileStream, SaveFormat::Pptx);
    } finally {
        $fileStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **Zapisz prezentacje z określonym typem widoku**

Aspose.Slides umożliwia ustawienie początkowego widoku, który PowerPoint używa przy otwieraniu wygenerowanej prezentacji, za pomocą klasy [ViewProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/viewproperties/). Użyj metody [setLastView](https://reference.aspose.com/slides/pl/php-java/aspose.slides/viewproperties/#setLastView) z wartością z wyliczenia [ViewType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/viewtype/).

```php
$presentation = new Presentation();
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("SlideMasterView.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Zapisz prezentacje w ścisłym formacie Office Open XML**

Aspose.Slides umożliwia zapisanie prezentacji w ścisłym formacie Office Open XML. Użyj klasy [PptxOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pptxoptions/) i ustaw jej właściwość conformance podczas zapisu. Jeśli ustawisz [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/pl/php-java/aspose.slides/conformance/#Iso29500_2008_Strict), plik wyjściowy zostanie zapisany w ścisłym formacie Office Open XML.

Poniższy przykład tworzy prezentację i zapisuje ją w ścisłym formacie Office Open XML.

```php
$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
$presentation = new Presentation();
try {
    // Zapisz prezentację w ścisłym formacie Office Open XML.
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **Zapisz prezentacje w formacie Office Open XML w trybie Zip64**

Plik Office Open XML jest archiwum ZIP, które nakłada limity 4 GB (2^32 bajtów) na niekompresowany rozmiar dowolnego pliku, skompresowany rozmiar dowolnego pliku oraz całkowity rozmiar archiwum, a także ogranicza liczbę plików w archiwum do 65 535 (2^16‑1). Rozszerzenia formatu ZIP64 podnoszą te limity do 2^64.

Metoda [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pptxoptions/#setZip64Mode) pozwala wybrać, kiedy używać rozszerzeń formatu ZIP64 przy zapisywaniu pliku Office Open XML.

Metodę tę można używać w następujących trybach:

- [IfNecessary](https://reference.aspose.com/slides/pl/php-java/aspose.slides/zip64mode/#IfNecessary) używa rozszerzeń ZIP64 tylko wtedy, gdy prezentacja przekracza powyższe ograniczenia. To tryb domyślny.
- [Never](https://reference.aspose.com/slides/pl/php-java/aspose.slides/zip64mode/#Never) nigdy nie używa rozszerzeń ZIP64.
- [Always](https://reference.aspose.com/slides/pl/php-java/aspose.slides/zip64mode/#Always) zawsze używa rozszerzeń ZIP64.

Poniższy kod demonstruje, jak zapisać prezentację jako PPTX z włączonymi rozszerzeniami formatu ZIP64:

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setZip64Mode(Zip64Mode::Always);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("OutputZip64.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="NOTE" color="warning" %}}
Gdy zapiszesz z [Zip64Mode.Never](https://reference.aspose.com/slides/pl/php-java/aspose.slides/zip64mode/#Never), zostanie zgłoszony [PptxException](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pptxexception/), jeśli prezentacja nie może zostać zapisana w formacie ZIP32.
{{% /alert %}}

## **Zapisz prezentacje bez odświeżania miniatury**

Metoda [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) kontroluje generowanie miniatury przy zapisywaniu prezentacji do PPTX:

- Jeśli ustawiona na `true`, miniatura jest odświeżana podczas zapisu. To domyślne zachowanie.
- Jeśli ustawiona na `false`, bieżąca miniatura jest zachowywana. Jeśli prezentacja nie ma miniatury, nie zostanie wygenerowana.

W poniższym kodzie prezentacja jest zapisana do PPTX bez odświeżania jej miniatury.

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setRefreshThumbnail(false);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pptx", SaveFormat::Pptx, $pptxOptions);
}
finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}
Ta opcja pomaga zmniejszyć czas potrzebny na zapisanie prezentacji w formacie PPTX.
{{% /alert %}}

## **Zapisuj postęp w procentach**

Raportowanie postępu zapisu jest konfigurowane za pomocą metody [setProgressCallback](https://reference.aspose.com/slides/pl/php-java/aspose.slides/saveoptions/#setProgressCallback) w klasie [SaveOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/saveoptions/) oraz jej podklasach. Dostarcz proxy w Javie, które implementuje interfejs [IProgressCallback](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iprogresscallback/); podczas eksportu wywołanie zwrotne otrzymuje okresowe aktualizacje procentowe.

Poniższe fragmenty kodu pokazują, jak używać `IProgressCallback`.

```php
class ExportProgressHandler {
    function reporting($progressValue) {
        // Użyj tutaj wartości procentowej postępu.
        $progress = java("java.lang.Double")->valueOf($progressValue)->intValue();
        echo($progress . "% of the file has been converted.");
    }
}

$progressHandler = java_closure(new ExportProgressHandler(), null, java("com.aspose.slides.IProgressCallback"));

$saveOptions = new PdfOptions();
$saveOptions->setProgressCallback($progressHandler);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pdf", SaveFormat::Pdf, $saveOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}
Aspose opracowało [bezpłatną aplikację PowerPoint Splitter](https://products.aspose.app/slides/pl/splitter) wykorzystującą własne API. Aplikacja pozwala podzielić prezentację na wiele plików, zapisując wybrane slajdy jako nowe pliki PPTX lub PPT.
{{% /alert %}}

## **FAQ**

**Czy „szybkie zapisywanie” (zapis przyrostowy) jest obsługiwane, tak aby zapisywać tylko zmiany?**

Nie. Zapis tworzy pełny plik docelowy przy każdym wywołaniu; zapis przyrostowy („fast save”) nie jest obsługiwany.

**Czy zapisywanie tej samej instancji Presentation z wielu wątków jest bezpieczne wątkowo?**

Nie. Instancja [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) [nie jest bezpieczna wątkowo](/slides/pl/php-java/multithreading/); zapisuj ją z jednego wątku.

**Co się dzieje z hiperłączami i zewnętrznie powiązanymi plikami podczas zapisu?**

[Hyperlinks](/slides/pl/php-java/manage-hyperlinks/) są zachowywane. Zewnętrzne pliki powiązane (np. filmy przy użyciu ścieżek względnych) nie są kopiowane automatycznie — upewnij się, że odwołane ścieżki pozostają dostępne.

**Czy mogę ustawić/zapisać metadane dokumentu (Autor, Tytuł, Firma, Data)?**

Tak. Standardowe [właściwości dokumentu](/slides/pl/php-java/presentation-properties/) są obsługiwane i zostaną zapisane w pliku podczas zapisu.