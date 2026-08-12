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
- zapisywanie postępu
- PHP
- Aspose.Slides
description: "Poznaj sposób zapisywania prezentacji przy użyciu Aspose.Slides dla PHP poprzez Java — eksportuj do PowerPoint lub OpenDocument, zachowując układy, czcionki i efekty."
---
## **Przegląd**

[Open Presentations in PHP](/slides/pl/php-java/open-presentation/) opisuje, jak używać klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) do otwierania prezentacji. Ten artykuł wyjaśnia, jak tworzyć i zapisywać prezentacje. Klasa [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) zawiera zawartość prezentacji. Niezależnie od tego, czy tworzysz prezentację od podstaw, czy modyfikujesz istniejącą, będziesz chciał ją zapisać po zakończeniu. Dzięki Aspose.Slides for PHP możesz zapisać do **pliku** lub **strumienia**. Ten artykuł wyjaśnia różne sposoby zapisywania prezentacji.

## **Zapisywanie prezentacji do plików**

Zapisz prezentację do pliku, wywołując metodę `save` klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/). Przekaż nazwę pliku i format zapisu do metody. Poniższy przykład pokazuje, jak zapisać prezentację przy użyciu Aspose.Slides.

```php
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
$presentation = new Presentation();
try {
    // Wykonaj tutaj pewne operacje...

    // Zapisz prezentację do pliku.
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Zapisywanie prezentacji do strumieni**

Możesz zapisać prezentację do strumienia, przekazując strumień wyjściowy do metody `save` klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/). Prezentację można zapisać do wielu typów strumieni. W poniższym przykładzie tworzymy nową prezentację i zapisujemy ją do strumienia pliku.

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

## **Zapisywanie prezentacji z określonym typem widoku**

Aspose.Slides pozwala ustawić początkowy widok, którego PowerPoint używa przy otwieraniu wygenerowanej prezentacji, za pomocą klasy [ViewProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/viewproperties/). Użyj metody [setLastView](https://reference.aspose.com/slides/pl/php-java/aspose.slides/viewproperties/#setLastView) z wartością z wyliczenia [ViewType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/viewtype/).

```php
$presentation = new Presentation();
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("SlideMasterView.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Zapisywanie prezentacji w formacie Strict Office Open XML**

Aspose.Slides umożliwia zapisanie prezentacji w formacie Strict Office Open XML. Skorzystaj z klasy [PptxOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pptxoptions/) i ustaw jej właściwość conformance podczas zapisu. Jeśli ustawisz [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/pl/php-java/aspose.slides/conformance/#Iso29500_2008_Strict), plik wyjściowy zostanie zapisany w formacie Strict Office Open XML.

Poniższy przykład tworzy prezentację i zapisuje ją w formacie Strict Office Open XML.

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

## **Zapisywanie prezentacji w formacie Office Open XML w trybie Zip64**

Plik Office Open XML jest archiwum ZIP, które narzuca ograniczenia 4 GB (2^32 bajtów) na niezakompresowany rozmiar dowolnego pliku, skompresowany rozmiar dowolnego pliku oraz całkowity rozmiar archiwum, a także ogranicza liczbę plików w archiwum do 65 535 (2^16‑1). Rozszerzenia formatu ZIP64 podnoszą te limity do 2^64.

Metoda [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pptxoptions/#setZip64Mode) pozwala wybrać, kiedy używać rozszerzeń formatu ZIP64 przy zapisywaniu pliku Office Open XML.

Metodę tę można używać z następującymi trybami:
- [IfNecessary](https://reference.aspose.com/slides/pl/php-java/aspose.slides/zip64mode/#IfNecessary) używa rozszerzeń formatu ZIP64 tylko wtedy, gdy prezentacja przekracza wymienione powyżej ograniczenia. To domyślny tryb.
- [Never](https://reference.aspose.com/slides/pl/php-java/aspose.slides/zip64mode/#Never) nigdy nie używa rozszerzeń formatu ZIP64.
- [Always](https://reference.aspose.com/slides/pl/php-java/aspose.slides/zip64mode/#Always) zawsze używa rozszerzeń formatu ZIP64.

Poniższy kod demonstruje, jak zapisać prezentację jako plik PPTX z włączonymi rozszerzeniami formatu ZIP64:

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

{{% alert title="UWAGA" color="warning" %}}
Gdy zapisujesz z użyciem [Zip64Mode.Never](https://reference.aspose.com/slides/pl/php-java/aspose.slides/zip64mode/#Never), zostaje rzucony [PptxException](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pptxexception/), jeśli prezentacji nie można zapisać w formacie ZIP32.
{{% /alert %}}

## **Zapisywanie prezentacji w formacie Office Open XML z poziomami kompresji**

Podczas pracy z dużymi prezentacjami możesz dostosować poziom kompresji, aby zrównoważyć rozmiar pliku i czas przetwarzania. W zależności od wymagań możesz preferować szybsze przetwarzanie lub mniejsze pliki wyjściowe.

Aspose.Slides udostępnia metodę [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pptxoptions/#setCompressionLevel), która pozwala określić poziom kompresji używany przy zapisywaniu prezentacji w formacie Office Open XML.

Dostępne są następujące poziomy kompresji:
- [**None**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/compressionlevel/#None): Brak kompresji. Pliki są zapisywane w stanie niezmienionym.
- [**Level1**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/compressionlevel/#Level1): Najszybsza kompresja przy najniższym współczynniku kompresji.
- [**Level2**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/compressionlevel/#Level2): Szybsza kompresja z nieco lepszym współczynnikiem niż **Level1**.
- [**Level3**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/compressionlevel/#Level3): Lepsza kompresja niż **Level2** przy umiarkowanym wpływie na czas przetwarzania.
- [**Level4**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/compressionlevel/#Level4): Lepsza kompresja niż **Level3**.
- [**Level5**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/compressionlevel/#Level5): Poprawiona kompresja w porównaniu do **Level4** przy dodatkowym czasie przetwarzania.
- [**Level6**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/compressionlevel/#Level6): Standardowa kompresja zapewniająca dobrą równowagę między szybkością przetwarzania a rozmiarem pliku. To *domyślny poziom kompresji*.
- [**Level7**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/compressionlevel/#Level7): Lepsza kompresja niż **Level6** przy wolniejszym przetwarzaniu.
- [**Level8**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/compressionlevel/#Level8): Lepsza kompresja niż **Level7**.
- [**Level9**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/compressionlevel/#Level9): Maksymalna kompresja. Produkuje najmniejszy rozmiar pliku kosztem najdłuższego czasu przetwarzania.

Poniższy przykład demonstruje, jak zapisać prezentację jako plik PPTX *bez kompresji*:

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setCompressionLevel(CompressionLevel::None);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Sample-out.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```

Ten przykład pokazuje, jak zapisać prezentację jako plik PPTX z *maksymalną kompresją*:

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setCompressionLevel(CompressionLevel::Level9);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Sample-level9.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```

## **Zapisywanie prezentacji bez odświeżania miniatury**

Metoda [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) kontroluje generowanie miniatury przy zapisywaniu prezentacji do formatu PPTX:
- Jeśli ustawiona na `true`, miniatura jest odświeżana podczas zapisu. To domyślne zachowanie.
- Jeśli ustawiona na `false`, bieżąca miniatura zostaje zachowana. Jeśli prezentacja nie ma miniatury, nie zostanie wygenerowana żadna.

W poniższym kodzie prezentacja jest zapisywana do PPTX bez odświeżania jej miniatury.

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

{{% alert title="Informacja" color="info" %}}
Ta opcja pomaga skrócić czas potrzebny na zapisanie prezentacji w formacie PPTX.
{{% /alert %}}

## **Zapisywanie postępu w procentach**

Raportowanie postępu zapisu jest konfigurowane za pomocą metody [setProgressCallback](https://reference.aspose.com/slides/pl/php-java/aspose.slides/saveoptions/#setProgressCallback) w klasie [SaveOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/saveoptions/) oraz jej podklasach. Dostarcz proxy Java implementujące interfejs [IProgressCallback](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iprogresscallback/); podczas eksportu wywołanie zwrotne otrzymuje okresowe aktualizacje w procentach.

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

{{% alert title="Informacja" color="info" %}}
Aspose opracowało [bezpłatną aplikację PowerPoint Splitter](https://products.aspose.app/slides/pl/splitter) wykorzystującą własne API. Aplikacja umożliwia podzielenie prezentacji na wiele plików, zapisując wybrane slajdy jako nowe pliki PPTX lub PPT.
{{% /alert %}}

## **FAQ**

**Czy „szybki zapis” (zapis przyrostowy) jest obsługiwany, aby zapisywać tylko zmiany?**  
Nie. Przy zapisie tworzony jest pełny plik docelowy za każdym razem; przyrostowy „szybki zapis” nie jest obsługiwany.

**Czy zapisywanie tej samej instancji Presentation z wielu wątków jest bezpieczne wątkowo?**  
Nie. Instancja [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) nie jest bezpieczna wątkowo; należy zapisywać ją z jednego wątku.

**Co się dzieje z hiperłączami i zewnętrznie powiązanymi plikami przy zapisie?**  
[Hyperlinks](/slides/pl/php-java/manage-hyperlinks/) są zachowywane. Zewnętrznie powiązane pliki (np. wideo poprzez ścieżki względne) nie są kopiowane automatycznie — upewnij się, że odwoływane ścieżki pozostają dostępne.

**Czy mogę ustawić/zapisać metadane dokumentu (Autor, Tytuł, Firma, Data)?**  
Tak. Standardowe [document properties](/slides/pl/php-java/presentation-properties/) są obsługiwane i zostaną zapisane w pliku podczas zapisu.