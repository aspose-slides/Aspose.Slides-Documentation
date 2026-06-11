---
title: Zapisz prezentacje w JavaScript
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
- odświeżanie miniatury
- postęp zapisu
- Node.js
- JavaScript
- Aspose.Slides
description: "Dowiedz się, jak zapisywać prezentacje przy użyciu Aspose.Slides dla Node.js w języku JavaScript — eksportuj do PowerPoint lub OpenDocument, zachowując układy, czcionki i efekty."
---
## **Przegląd**

[Otwieranie prezentacji w JavaScript](/slides/pl/nodejs-java/open-presentation/) opisuje jak używać klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) do otwierania prezentacji. Ten artykuł wyjaśnia, jak tworzyć i zapisywać prezentacje. Klasa [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) zawiera zawartość prezentacji. Niezależnie od tego, czy tworzysz prezentację od podstaw, czy modyfikujesz istniejącą, będziesz chciał ją zapisać po zakończeniu. Dzięki Aspose.Slides dla Node.js możesz zapisać do **pliku** lub **strumienia**. Ten artykuł wyjaśnia różne sposoby zapisywania prezentacji.

## **Zapisz prezentacje do plików**

Zapisz prezentację do pliku, wywołując metodę `save` klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/). Przekaż nazwę pliku i format zapisu do metody. Poniższy przykład pokazuje, jak zapisać prezentację przy użyciu Aspose.Slides.

```js
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
let presentation = new aspose.slides.Presentation();
try {
    // Wykonaj tutaj jakieś operacje...

    // Zapisz prezentację do pliku.
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Zapisz prezentacje do strumieni**

Możesz zapisać prezentację do strumienia, przekazując strumień wyjściowy do metody `save` klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/). Prezentację można zapisać do wielu typów strumieni. W poniższym przykładzie tworzymy nową prezentację i zapisujemy ją do strumienia plikowego.

```js
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
let presentation = new aspose.slides.Presentation();
try {
    let fileStream = java.newInstanceSync("java.io.FileOutputStream", "Output.pptx");
    try {
        // Zapisz prezentację do strumienia.
        presentation.save(fileStream, aspose.slides.SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Zapisz prezentacje z określonym typem widoku**

Aspose.Slides umożliwia ustawienie początkowego widoku, którego PowerPoint używa, gdy otwiera wygenerowaną prezentację, za pomocą klasy [ViewProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/viewproperties/). Użyj metody [setLastView](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/viewproperties/#setLastView) z wartością z wyliczenia [ViewType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/viewtype/).

```js
let presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Zapisz prezentacje w ścisłym formacie Office Open XML**

Aspose.Slides umożliwia zapisanie prezentacji w ścisłym formacie Office Open XML. Użyj klasy [PptxOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pptxoptions/) i ustaw jej właściwość conformance podczas zapisu. Jeśli ustawisz [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict), plik wyjściowy zostanie zapisany w ścisłym formacie Office Open XML.

Poniższy przykład tworzy prezentację i zapisuje ją w ścisłym formacie Office Open XML.

```js
let options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
let presentation = new aspose.slides.Presentation();
try {
    // Zapisz prezentację w ścisłym formacie Office Open XML.
    presentation.save("StrictOfficeOpenXml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Zapisz prezentacje w formacie Office Open XML w trybie Zip64**

Plik Office Open XML jest archiwum ZIP, które narzuca limity 4 GB (2^32 bajtów) na niekompresowany rozmiar dowolnego pliku, skompresowany rozmiar dowolnego pliku oraz całkowity rozmiar archiwum, a także ogranicza liczbę plików w archiwum do 65 535 (2^16‑1). Rozszerzenia formatu ZIP64 podnoszą te limity do 2^64.

Metoda [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pptxoptions/#getZip64Mode) umożliwia wybranie, kiedy używać rozszerzeń formatu ZIP64 przy zapisywaniu pliku Office Open XML.

Ta metoda może być użyta z następującymi trybami:

- [IfNecessary] używa rozszerzeń formatu ZIP64 tylko wtedy, gdy prezentacja przekracza powyższe ograniczenia. To jest tryb domyślny.
- [Never] nigdy nie używa rozszerzeń formatu ZIP64.
- [Always] zawsze używa rozszerzeń formatu ZIP64.

Poniższy kod demonstruje, jak zapisać prezentację jako PPTX z włączonymi rozszerzeniami formatu ZIP64:

```js
let pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setZip64Mode(aspose.slides.Zip64Mode.Always);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("OutputZip64.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}}
Gdy zapisujesz z [Zip64Mode.Never](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/zip64mode/#Never), zostaje zgłoszony [PptxException](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pptxexception/), jeśli prezentacji nie można zapisać w formacie ZIP32.
{{% /alert %}}

## **Zapisz prezentacje bez odświeżania miniatury**

Metoda [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) kontroluje generowanie miniatury przy zapisywaniu prezentacji do PPTX:

- Jeśli ustawiono na `true`, miniatura jest odświeżana podczas zapisu. To jest domyślne.
- Jeśli ustawiono na `false`, bieżąca miniatura jest zachowana. Jeśli prezentacja nie ma miniatury, nie zostanie wygenerowana.

W poniższym kodzie prezentacja jest zapisywana do PPTX bez odświeżania jej miniatury.

```js
let pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setRefreshThumbnail(false);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
}
finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Ta opcja pomaga skrócić czas potrzebny na zapisanie prezentacji w formacie PPTX.
{{% /alert %}}

## **Zapisz aktualizacje postępu w procentach**

Raportowanie postępu zapisu jest konfigurowane za pomocą metody [setProgressCallback](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/saveoptions/#setProgressCallback) klasy [SaveOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/saveoptions/) i jej podklas. Dostarcz proxy Java implementujące interfejs [IProgressCallback](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iprogresscallback/); podczas eksportu wywołanie zwrotne otrzymuje okresowe aktualizacje procentowe.

Poniższe fragmenty kodu pokazują, jak używać `IProgressCallback`.

```javascript
const ExportProgressHandler = java.newProxy("com.aspose.slides.IProgressCallback", {
    reporting: function(progressValue) {
        // Użyj tutaj wartości procentowej postępu.
        const progress = Math.floor(progressValue);
        console.log(`${progress}% of the file has been converted.`);
    }
});

let saveOptions = new aspose.slides.PdfOptions();
saveOptions.setProgressCallback(ExportProgressHandler);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", aspose.slides.SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Aspose opracowało darmową aplikację [PowerPoint Splitter](https://products.aspose.app/slides/pl/splitter) wykorzystującą własne API. Aplikacja umożliwia podzielenie prezentacji na wiele plików poprzez zapis wybranych slajdów jako nowe pliki PPTX lub PPT.
{{% /alert %}}

## **FAQ**

**Czy obsługiwany jest „szybki zapis” (zapis przyrostowy), aby zapisywać tylko zmiany?**

Nie. Zapis tworzy pełny plik docelowy przy każdym zapisie; przyrostowy „szybki zapis” nie jest obsługiwany.

**Czy zapisywanie tej samej instancji Presentation z wielu wątków jest bezpieczne wątkowo?**

Nie. Instancja [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) [nie jest bezpieczna wątkowo](/slides/pl/nodejs-java/multithreading/); zapisuj ją z jednego wątku.

**Co się dzieje z hiperłączami i zewnętrznie powiązanymi plikami podczas zapisywania?**

[Hyperlinks](/slides/pl/nodejs-java/manage-hyperlinks/) są zachowywane. Zewnętrznie powiązane pliki (np. filmy za pomocą ścieżek względnych) nie są kopiowane automatycznie — upewnij się, że odwołane ścieżki pozostają dostępne.

**Czy mogę ustawić/zapisać metadane dokumentu (Autor, Tytuł, Firma, Data)?**

Tak. Standardowe [właściwości dokumentu](/slides/pl/nodejs-java/presentation-properties/) są obsługiwane i zostaną zapisane w pliku podczas zapisu.