---
title: Zapisz prezentacje w PHP
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
- predefiniowany typ widoku
- Ścisły format Office Open XML
- tryb Zip64
- odświeżanie miniaturki
- postęp zapisu
- PHP
- Aspose.Slides
description: "Zapisz prezentacje PowerPoint i OpenDocument do plików lub strumieni w PHP przy użyciu Aspose.Slides, oraz skonfiguruj wyjście PPTX i raportowanie postępu."
---
## **Przegląd**

Po utworzeniu prezentacji lub [otwarciu istniejącej](/slides/pl/php-java/open-presentation/), użyj metody [Presentation::save](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#save), aby zapisać wynik. Aspose.Slides for PHP via Java może zapisać prezentację do pliku lub strumienia w formatach PowerPoint, OpenDocument, PDF i innych. Poniższe sekcje opisują standardowe operacje zapisu oraz dostępne opcje dla wyjścia PPTX.

## **Zapisywanie prezentacji do plików**

Aby zapisać prezentację do pliku, przekaż ścieżkę wyjściową oraz wartość [SaveFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/saveformat/) do metody [Presentation::save](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#save). Wartość formatu określa typ pliku, który tworzy Aspose.Slides.

Poniższy przykład tworzy prezentację i zapisuje ją jako plik PPTX:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    // Dodaj lub zmodyfikuj zawartość prezentacji tutaj.

    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Zapisywanie prezentacji w ich oryginalnym formacie**

Przykłady wykrywania formatu pliku i strumienia, zachowanie nowo utworzonych prezentacji oraz różnica między formatem źródłowym a wyjściowym opisano w sekcji [Determine the Original Presentation Format](/slides/pl/php-java/detect-presentation-source-format/).

W aplikacji przetwarzającej partie, format wejściowy może nie być znany z góry. Po załadowaniu pliku odczytaj jego oryginalny format z metody [Presentation::getSourceFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#getSourceFormat). Przekaż uzyskaną wartość [SourceFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/sourceformat/) do [SlideUtil::toSaveFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slideutil/#toSaveFormat), aby otrzymać odpowiadającą wartość [SaveFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/saveformat/), a następnie użyj [Presentation::save](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#save), aby zapisać zmodyfikowaną prezentację.

Poniższy kompletny przykład przetwarza każdy plik w katalogu wejściowym, aktualizuje jego tytuł i zapisuje go do katalogu wyjściowego w formacie, z którego został wczytany:

```php
use aspose\slides\Presentation;
use aspose\slides\SlideUtil;

$inputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "Input";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "Output";

if (!is_dir($outputDirectory) && !mkdir($outputDirectory, 0777, true)) {
    echo("Cannot create the output directory." . PHP_EOL);
}

$inputFiles = is_dir($inputDirectory) ? scandir($inputDirectory) : false;
if ($inputFiles !== false && is_dir($outputDirectory)) {
    foreach ($inputFiles as $fileName) {
        $inputPath = $inputDirectory . DIRECTORY_SEPARATOR . $fileName;
        if (!is_file($inputPath)) {
            continue;
        }

        $presentation = null;
        $presentationLoaded = false;
        try {
            $presentation = new Presentation($inputPath);
            $presentationLoaded = true;
            $saveFormat = SlideUtil::toSaveFormat($presentation->getSourceFormat());
            $presentation->getDocumentProperties()->setTitle("Processed by the batch application");

            $outputPath = $outputDirectory . DIRECTORY_SEPARATOR . $fileName;
            $presentation->save($outputPath, $saveFormat);
        } catch (\Throwable $exception) {
            echo("Cannot process '" . $inputPath . "': " . $exception->getMessage() . PHP_EOL);
        } finally {
            if ($presentationLoaded) {
                $presentation->dispose();
            }
        }
    }
}
```

[SlideUtil::toSaveFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slideutil/#toSaveFormat) mapuje PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP oraz PowerPoint XML na odpowiadające formaty zapisu prezentacji. Mapuje jedynie formaty źródłowe prezentacji; nie służy do wyboru formatów eksportu, takich jak PDF, HTML, TIFF czy obrazy. Przekazanie nieobsługiwanej lub nieprawidłowej wartości [SourceFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/sourceformat/) powoduje wyrzucenie [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html).

Starsze pliki PPT, PPS i POT używają tego samego binarnego kontenera. Gdy taka prezentacja zostanie załadowana ze strumienia bez rozszerzenia pliku, plik PPS lub POT może zostać zidentyfikowany jako PPT. Jeśli wymagana jest zachowanie tych starszych podtypów, zachowaj oryginalną nazwę pliku lub metadane formatu osobno i użyj ich przy wyborze nazwy i formatu pliku wyjściowego.

## **Zapisywanie prezentacji do strumieni**

Aby zapisać prezentację bez określania ostatecznej ścieżki pliku, przekaż zapisywalny strumień oraz wartość [SaveFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/saveformat/) do metody [Presentation::save](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#save). Takie podejście jest przydatne, gdy wynik musi zostać zwrócony z usługi sieciowej, zapisany w bazie danych lub przetworzony w pamięci.

Poniższy przykład zapisuje nową prezentację do strumienia pliku:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $outputStream = new Java("java.io.FileOutputStream", "Output.pptx");
    try {
        $presentation->save($outputStream, SaveFormat::Pptx);
    } finally {
        $outputStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **Zapisywanie prezentacji z określonym typem widoku**

Możesz określić widok, w którym PowerPoint otwiera zapisany plik początkowo. Użyj metody [ViewProperties::setLastView](https://reference.aspose.com/slides/pl/php-java/aspose.slides/viewproperties/#setLastView) z wartością [ViewType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/viewtype/) przed zapisem.

Poniższy przykład konfiguruje widok Slide Master jako widok początkowy:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation();
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("SlideMasterView.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Zapisywanie prezentacji w ściśle określonym formacie Office Open XML**

Aby utworzyć plik PPTX zgodny z profilem Strict Office Open XML, utwórz instancję [PptxOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pptxoptions/) i użyj jej metody [PptxOptions::setConformance](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pptxoptions/#setConformance) z wartością [Conformance::Iso29500_2008_Strict](https://reference.aspose.com/slides/pl/php-java/aspose.slides/conformance/#Iso29500-2008-Strict). Następnie przekaż opcje do metody [Presentation::save](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#save).

```php
use aspose\slides\Conformance;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

$presentation = new Presentation();
try {
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **Zapisywanie prezentacji w formacie Office Open XML w trybie Zip64**

Standardowe archiwum ZIP ogranicza rozmiar skompresowanych i nieskompresowanych wpisów, łączny rozmiar archiwum oraz liczbę wpisów. Ponieważ plik PPTX jest archiwum ZIP, bardzo duża prezentacja może przekroczyć te limity. Rozszerzenia ZIP64 podnoszą obowiązujące limity rozmiaru i liczby wpisów.

Użyj metody [PptxOptions::setZip64Mode](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pptxoptions/#setZip64Mode), aby kontrolować, czy Aspose.Slides zapisuje rozszerzenia ZIP64:

- [IfNecessary](https://reference.aspose.com/slides/pl/php-java/aspose.slides/zip64mode/#IfNecessary) używa ZIP64 tylko wtedy, gdy prezentacja przekracza standardowe limity ZIP. To domyślny tryb.
- [Never](https://reference.aspose.com/slides/pl/php-java/aspose.slides/zip64mode/#Never) wyłącza rozszerzenia ZIP64.
- [Always](https://reference.aspose.com/slides/pl/php-java/aspose.slides/zip64mode/#Always) zawsze zapisuje rozszerzenia ZIP64.

Poniższy przykład zawsze włącza rozszerzenia ZIP64 dla prezentacji wyjściowej:

```php
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\Zip64Mode;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setZip64Mode(Zip64Mode::Always);

    $presentation->save("OutputZip64.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="warning" title="Warning" %}}
Jeśli użyto [Zip64Mode::Never](https://reference.aspose.com/slides/pl/php-java/aspose.slides/zip64mode/#Never) i prezentacja nie mieści się w standardowych limitach ZIP, operacja zapisu zgłasza [PptxException](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pptxexception/).
{{% /alert %}}

## **Zapisywanie prezentacji w formacie Office Open XML z poziomami kompresji**

Dla wyjścia PPTX możesz zrównoważyć szybkość zapisu z rozmiarem pliku, używając metody [PptxOptions::setCompressionLevel](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pptxoptions/#setCompressionLevel). Klasa [CompressionLevel](https://reference.aspose.com/slides/pl/php-java/aspose.slides/compressionlevel/) udostępnia następujące wartości:

- [None](https://reference.aspose.com/slides/pl/php-java/aspose.slides/compressionlevel/#None) przechowuje dane bez kompresji.
- [Level1](https://reference.aspose.com/slides/pl/php-java/aspose.slides/compressionlevel/#Level1) zapewnia najszybszą kompresję i największy skompresowany wynik.
- [Level2](https://reference.aspose.com/slides/pl/php-java/aspose.slides/compressionlevel/#Level2) do [Level5](https://reference.aspose.com/slides/pl/php-java/aspose.slides/compressionlevel/#Level5) stopniowo preferują mniejszy wynik kosztem szybkości zapisu.
- [Level6](https://reference.aspose.com/slides/pl/php-java/aspose.slides/compressionlevel/#Level6) równoważy szybkość zapisu i rozmiar pliku. To domyślny poziom.
- [Level7](https://reference.aspose.com/slides/pl/php-java/aspose.slides/compressionlevel/#Level7) i [Level8](https://reference.aspose.com/slides/pl/php-java/aspose.slides/compressionlevel/#Level8) jeszcze bardziej faworyzują mniejszy wynik kosztem szybkości zapisu.
- [Level9](https://reference.aspose.com/slides/pl/php-java/aspose.slides/compressionlevel/#Level9) zapewnia najsilniejszą kompresję i wymaga najwięcej czasu przetwarzania.

Poniższy przykład zapisuje prezentację bez kompresji:

```php
use aspose\slides\CompressionLevel;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setCompressionLevel(CompressionLevel::None);

    $presentation->save("OutputNoCompression.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

Poniższy przykład używa maksymalnego poziomu kompresji:

```php
use aspose\slides\CompressionLevel;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setCompressionLevel(CompressionLevel::Level9);

    $presentation->save("OutputMaximumCompression.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **Zapisywanie prezentacji bez odświeżania miniaturki**

Gdy prezentacja jest zapisywana jako PPTX, metoda [PptxOptions::setRefreshThumbnail](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) kontroluje jej miniaturkę dokumentu:

- `true` odtwarza miniaturkę podczas operacji zapisu. To wartość domyślna.
- `false` zachowuje istniejącą miniaturkę. Jeśli prezentacja nie ma miniaturki, Aspose.Slides jej nie generuje.

Poniższy przykład zapisuje prezentację bez odświeżania miniaturki:

```php
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setRefreshThumbnail(false);

    $presentation->save("Output.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Wyłączenie odświeżania miniaturki może skrócić czas zapisu pliku PPTX.
{{% /alert %}}

## **Aktualizacje postępu zapisu w procentach**

Aby monitorować operację zapisu, dostarcz proxy w Javie implementujące interfejs [IProgressCallback](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iprogresscallback/) i przekaż proxy do metody [SaveOptions::setProgressCallback](https://reference.aspose.com/slides/pl/php-java/aspose.slides/saveoptions/#setProgressCallback). Aspose.Slides wywoła metodę [IProgressCallback::reporting](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iprogresscallback/#reporting-double-) z wartościami postępu podczas eksportu.

Poniższy przykład raportuje postęp eksportu PDF do konsoli:

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

class ExportProgressHandler {
    function reporting($progressValue) {
        $progress = java("java.lang.Double")->valueOf($progressValue)->intValue();
        echo($progress . "% of the file has been converted." . PHP_EOL);
    }
}

$progressHandler = java_closure(new ExportProgressHandler(), null, java("com.aspose.slides.IProgressCallback"));

$options = new PdfOptions();
$options->setProgressCallback($progressHandler);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pdf", SaveFormat::Pdf, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose udostępnia bezpłatny [PowerPoint Splitter](https://products.aspose.app/slides/pl/splitter) zbudowany w oparciu o API Aspose.Slides. Umożliwia on zapis wybranych slajdów z prezentacji jako oddzielne pliki PPT lub PPTX.
{{% /alert %}}

## **FAQ**

**Czy Aspose.Slides obsługuje zapis przyrostowy lub „fast save”?**

Nie. Każda operacja zapisu tworzy pełny plik wyjściowy zamiast aktualizować tylko zmienione części.

**Czy wiele wątków może zapisywać tę samą instancję Presentation?**

Nie. Instancja [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) **nie jest thread‑safe** (/slides/pl/php-java/multithreading/). Dostęp i zapis każdej instancji powinny odbywać się z jednego wątku naraz.

**Co się dzieje z hiperłączami i zewnętrznie powiązanymi plikami po zapisaniu prezentacji?**

[Hyperlinks](/slides/pl/php-java/manage-hyperlinks/) pozostają w prezentacji. Aspose.Slides nie kopiuje plików powiązanych zewnętrznie, więc zapisana prezentacja musi nadal mieć dostęp do ich lokalizacji.

**Czy mogę zapisać metadane dokumentu, takie jak autor, tytuł, firma i data utworzenia?**

Tak. Ustaw odpowiednie [document properties](/slides/pl/php-java/presentation-properties/) przed zapisem, a Aspose.Slides zapisze je w pliku wyjściowym.