---
title: Zapisywanie prezentacji w JavaScript
linktitle: Zapisz prezentację
type: docs
weight: 80
url: /pl/nodejs-java/save-presentation/
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
- Ścisły format Office Open XML
- tryb Zip64
- odświeżanie miniaturki
- zapisywanie postępu
- Node.js
- JavaScript
- Aspose.Slides
description: "Zapisz prezentacje PowerPoint i OpenDocument do plików lub strumieni w JavaScript przy użyciu Aspose.Slides oraz skonfiguruj wyjście PPTX i raportowanie postępu."
---
## **Przegląd**

Po utworzeniu prezentacji lub [otwarciu istniejącej](/slides/pl/nodejs-java/open-presentation/), użyj metody [Presentation.save](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#save), aby zapisać wynik. Aspose.Slides dla Node.js przez Java może zapisać prezentację do pliku lub strumienia w formatach PowerPoint, OpenDocument, PDF i innych. Poniższe sekcje obejmują standardowe operacje zapisu oraz dostępne opcje dla wyjścia PPTX.

## **Zapisywanie prezentacji do plików**

Aby zapisać prezentację do pliku, przekaż ścieżkę wyjściową i wartość [SaveFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/saveformat/) do metody [Presentation.save](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#save). Wartość formatu określa typ pliku, który tworzy Aspose.Slides.

Poniższy przykład tworzy prezentację i zapisuje ją jako plik PPTX:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    // Dodaj lub zmodyfikuj zawartość prezentacji tutaj.

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Zapisywanie prezentacji w ich oryginalnym formacie**

Przykłady wykrywania plików i strumieni, zachowanie nowo tworzonych prezentacji oraz rozróżnienie między formatami źródłowymi i wyjściowymi znajdziesz w [Determine the Original Presentation Format](/slides/pl/nodejs-java/detect-presentation-source-format/).

W aplikacji przetwarzania wsadowego format wejściowy może nie być znany z góry. Po załadowaniu pliku odczytaj jego oryginalny format za pomocą metody [Presentation.getSourceFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#getSourceFormat). Przekaż otrzymaną wartość [SourceFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sourceformat/) do [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slideutil/#toSaveFormat), aby uzyskać odpowiadającą wartość [SaveFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/saveformat/), a następnie użyj [Presentation.save](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#save), aby zapisać zmodyfikowaną prezentację.

Poniższy kompletny przykład przetwarza każdy plik w katalogu wejściowym, aktualizuje jego tytuł i zapisuje go do katalogu wyjściowego w formacie, z którego został wczytany:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const fs = require("fs");
const path = require("path");

const inputDirectory = "Input";
const outputDirectory = "Output";

if (!fs.existsSync(inputDirectory)) {
    console.error("The input directory does not exist.");
} else {
    fs.mkdirSync(outputDirectory, { recursive: true });

    const inputFiles = fs.readdirSync(inputDirectory, { withFileTypes: true })
        .filter((entry) => entry.isFile());

    for (const inputFile of inputFiles) {
        const inputPath = path.join(inputDirectory, inputFile.name);
        try {
            const presentation = new aspose.slides.Presentation(inputPath);
            try {
                const saveFormat = aspose.slides.SlideUtil.toSaveFormat(presentation.getSourceFormat());
                presentation.getDocumentProperties().setTitle("Processed by the batch application");

                const outputPath = path.join(outputDirectory, inputFile.name);
                presentation.save(outputPath, saveFormat);
            } finally {
                presentation.dispose();
            }
        } catch (error) {
            console.error(`Cannot process '${inputPath}': ${error.message}`);
        }
    }
}
```

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slideutil/#toSaveFormat) mapuje PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP oraz PowerPoint XML na ich odpowiadające formaty zapisu prezentacji. Mapuje tylko formaty źródłowe prezentacji; nie służy do wyboru formatów eksportu, takich jak PDF, HTML, TIFF czy obrazy. Przekazanie nieobsługiwanej lub nieprawidłowej wartości [SourceFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sourceformat/) powoduje błąd.

Starsze pliki PPT, PPS i POT używają tego samego kontenera binarnego. Gdy taka prezentacja jest wczytywana ze strumienia bez rozszerzenia pliku, plik PPS lub POT może zostać zidentyfikowany jako PPT. Jeśli konieczne jest zachowanie tych starszych podtypów, zachowaj oryginalną nazwę pliku lub metadane formatu osobno i użyj ich przy wyborze nazwy i formatu pliku wyjściowego.

## **Zapisywanie prezentacji do strumieni**

Aby zapisać prezentację bez korzystania z ostatecznej ścieżki pliku, przekaż strumień zapisu i wartość [SaveFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/saveformat/) do metody [Presentation.save](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#save). Takie podejście jest przydatne, gdy wynik musi zostać zwrócony z usługi sieciowej, zapisany w bazie danych lub przetworzony w pamięci.

Poniższy przykład zapisuje nową prezentację do strumienia pliku:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const outputStream = java.newInstanceSync("java.io.FileOutputStream", "output.pptx");
    try {
        presentation.save(outputStream, aspose.slides.SaveFormat.Pptx);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Zapisywanie prezentacji z określonym typem widoku**

Możesz określić widok, w którym PowerPoint otwiera zapisaną prezentację. Użyj metody [ViewProperties.setLastView](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/viewproperties/#setLastView) z wartością [ViewType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/viewtype/) przed zapisem.

Poniższy przykład konfiguruje widok Slide Master jako widok początkowy:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("slide-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Zapisywanie prezentacji w ścisłym formacie Office Open XML**

Aby utworzyć plik PPTX zgodny ze ścisłym profilem Office Open XML, utwórz instancję [PptxOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pptxoptions/) i użyj jej metody [setConformance](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pptxoptions/#setConformance) z [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict). Następnie przekaż opcje do metody [Presentation.save](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#save).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

const presentation = new aspose.slides.Presentation();
try {
    presentation.save("strict-office-open-xml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Zapisywanie prezentacji w formacie Office Open XML w trybie Zip64**

Standardowe archiwum ZIP ogranicza skompresowany i nieskompresowany rozmiar każdego wpisu, łączny rozmiar archiwum oraz liczbę wpisów. Ponieważ plik PPTX jest archiwum ZIP, bardzo duża prezentacja może przekroczyć te limity. Rozszerzenia ZIP64 podnoszą odpowiednie limity rozmiaru i liczby wpisów.

Użyj metody [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pptxoptions/#setZip64Mode), aby kontrolować, czy Aspose.Slides zapisuje rozszerzenia ZIP64:

- `IfNecessary` używa ZIP64 tylko wtedy, gdy prezentacja przekracza standardowe limity ZIP. To tryb domyślny.
- `Never` wyłącza rozszerzenia ZIP64.
- `Always` zawsze zapisuje rozszerzenia ZIP64.

Poniższy przykład zawsze włącza rozszerzenia ZIP64 dla prezentacji wyjściowej:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setZip64Mode(aspose.slides.Zip64Mode.Always);

    presentation.save("output-zip64.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
Jeśli użyto [Zip64Mode.Never](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/zip64mode/#Never) i prezentacja nie mieści się w standardowych limitach ZIP, operacja zapisu zgłasza [PptxException](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pptxexception/).
{{% /alert %}}

## **Zapisywanie prezentacji w formacie Office Open XML z poziomami kompresji**

Dla wyjścia PPTX możesz zrównoważyć szybkość zapisu i rozmiar pliku, używając metody [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pptxoptions/#setCompressionLevel). Klasa [CompressionLevel](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/compressionlevel/) udostępnia następujące wartości:

- `None` przechowuje dane bez kompresji.
- `Level1` zapewnia najszybszą kompresję i największy rozmiar skompresowanego wyniku.
- `Level2` … `Level5` stopniowo faworyzują mniejszy rozmiar wyjścia kosztem szybkości zapisu.
- `Level6` równoważy szybkość zapisu i rozmiar pliku. To domyślny poziom.
- `Level7` i `Level8` jeszcze bardziej faworyzują mniejszy rozmiar wyjścia kosztem szybkości zapisu.
- `Level9` zapewnia najsilniejszą kompresję i wymaga najdłuższego czasu przetwarzania.

Poniższy przykład zapisuje prezentację bez kompresji:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setCompressionLevel(aspose.slides.CompressionLevel.None);

    presentation.save("output-no-compression.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

Poniższy przykład używa maksymalnego poziomu kompresji:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setCompressionLevel(aspose.slides.CompressionLevel.Level9);

    presentation.save("output-maximum-compression.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Zapisywanie prezentacji bez odświeżania miniatury**

Gdy prezentacja jest zapisywana jako PPTX, metoda [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) kontroluje miniaturkę dokumentu:

- `true` regeneruje miniaturkę podczas operacji zapisu. To wartość domyślna.
- `false` zachowuje istniejącą miniaturkę. Jeśli prezentacja nie ma miniaturki, Aspose.Slides jej nie generuje.

Poniższy przykład zapisuje prezentację bez odświeżania jej miniaturki:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setRefreshThumbnail(false);

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Wyłączenie odświeżania miniaturki może skrócić czas potrzebny na zapis pliku PPTX.
{{% /alert %}}

## **Zapisywanie postępu w procentach**

Aby monitorować operację zapisu, zaimplementuj interfejs [IProgressCallback](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iprogresscallback/) przy użyciu proxy Java i przekaż implementację do metody [SaveOptions.setProgressCallback](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/saveoptions/#setProgressCallback). Aspose.Slides wywoła wtedy metodę [IProgressCallback.reporting](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iprogresscallback/#reporting-double-) z wartościami postępu podczas eksportu.

Poniższy przykład zgłasza postęp eksportu PDF do konsoli:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const exportProgressHandler = java.newProxy("com.aspose.slides.IProgressCallback", {
    reporting: function(progressValue) {
        const progress = Math.floor(progressValue);
        console.log(`${progress}% of the file has been converted.`);
    }
});

const options = new aspose.slides.PdfOptions();
options.setProgressCallback(exportProgressHandler);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose udostępnia darmowy [PowerPoint Splitter](https://products.aspose.app/slides/pl/splitter) oparty na API Aspose.Slides. Zapisuje wybrane slajdy z prezentacji jako osobne pliki PPT lub PPTX.
{{% /alert %}}

## **FAQ**

**Czy Aspose.Slides obsługuje przyrostowy lub „szybki zapis”?**

Nie. Każda operacja zapisu tworzy pełny plik wyjściowy, a nie aktualizuje jedynie zmienione części.

**Czy wiele wątków może zapisywać tę samą instancję Presentation?**

Nie. Instancja [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) [nie jest wątkowo‑bezpieczna](/slides/pl/nodejs-java/multithreading/). Dostęp i zapis każdej instancji powinien odbywać się tylko z jednego wątku jednocześnie.

**Co się dzieje z hiperłączami i zewnętrznie powiązanymi plikami podczas zapisywania prezentacji?**

[Hyperlinki](/slides/pl/nodejs-java/manage-hyperlinks/) pozostają w prezentacji. Aspose.Slides nie kopiuje zewnętrznie powiązanych plików, więc zapisana prezentacja musi nadal mieć dostęp do ich lokalizacji.

**Czy mogę zapisać metadane dokumentu, takie jak autor, tytuł, firma i data utworzenia?**

Tak. Ustaw odpowiednie [właściwości dokumentu](/slides/pl/nodejs-java/presentation-properties/) przed zapisem, a Aspose.Slides zapisze je do pliku wyjściowego.