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
- predefiniowany typ widoku
- Ścisły format Office Open XML
- tryb Zip64
- odświeżanie miniatury
- zapisywanie postępu
- Node.js
- JavaScript
- Aspose.Slides
description: "Poznaj sposoby zapisywania prezentacji przy użyciu Aspose.Slides dla Node.js w JavaScript — eksportuj do PowerPoint lub OpenDocument zachowując układy, czcionki i efekty."
---
## **Przegląd**

[Open Presentations in JavaScript](/slides/pl/nodejs-java/open-presentation/) opisuje, jak używać klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) do otwierania prezentacji. Ten artykuł wyjaśnia, jak tworzyć i zapisywać prezentacje. Klasa [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) zawiera zawartość prezentacji. Niezależnie od tego, czy tworzysz prezentację od podstaw, czy modyfikujesz istniejącą, będziesz chciał ją zapisać po zakończeniu. Dzięki Aspose.Slides dla Node.js możesz zapisywać do **pliku** lub **strumienia**. Ten artykuł opisuje różne sposoby zapisywania prezentacji.

## **Zapisz prezentacje do plików**

Zapisz prezentację do pliku, wywołując metodę `save` klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/). Przekaż nazwę pliku i format zapisu do metody. Poniższy przykład pokazuje, jak zapisać prezentację przy użyciu Aspose.Slides.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
let presentation = new aspose.slides.Presentation();
try {
    // Wykonaj tutaj pewne operacje...

    // Zapisz prezentację do pliku.
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Zapisz prezentacje do strumieni**

Możesz zapisać prezentację do strumienia, przekazując strumień wyjściowy do metody `save` klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/). Prezentację można zapisać do wielu typów strumieni. W poniższym przykładzie tworzymy nową prezentację i zapisujemy ją do strumienia plikowego.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

Aspose.Slides umożliwia ustawienie początkowego widoku, który PowerPoint używa po otwarciu wygenerowanej prezentacji, za pomocą klasy [ViewProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/viewproperties/). Użyj metody [setLastView](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/viewproperties/#setLastView) z wartością z wyliczenia [ViewType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/viewtype/).

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

Plik Office Open XML jest archiwum ZIP, które nakłada limit 4 GB (2^32 bajtów) na niekompresowany rozmiar dowolnego pliku, skompresowany rozmiar dowolnego pliku oraz całkowity rozmiar archiwum, a także ogranicza liczbę plików w archiwum do 65 535 (2^16‑1). Rozszerzenia formatu ZIP64 podnoszą te limity do 2^64.

Metoda [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pptxoptions/#getZip64Mode) umożliwia wybranie, kiedy używać rozszerzeń formatu ZIP64 podczas zapisywania pliku Office Open XML.

Ta metoda może być używana z następującymi trybami:

- [IfNecessary](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/zip64mode/#IfNecessary) używa rozszerzeń formatu ZIP64 tylko wtedy, gdy prezentacja przekracza powyższe ograniczenia. To domyślny tryb.
- [Never](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/zip64mode/#Never) nigdy nie używa rozszerzeń formatu ZIP64.
- [Always](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/zip64mode/#Always) zawsze używa rozszerzeń formatu ZIP64.

Poniższy kod demonstruje, jak zapisać prezentację jako plik PPTX z włączonymi rozszerzeniami formatu ZIP64:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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
Kiedy zapisujesz z [Zip64Mode.Never](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/zip64mode/#Never), zostaje wyrzucony [PptxException](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pptxexception/), jeśli prezentacji nie można zapisać w formacie ZIP32.
{{% /alert %}}

## **Zapisz prezentacje w formacie Office Open XML z poziomami kompresji**

Podczas pracy z dużymi prezentacjami możesz dostosować poziom kompresji, aby zrównoważyć rozmiar pliku i czas przetwarzania. W zależności od wymagań możesz preferować szybsze przetwarzanie lub mniejsze pliki wyjściowe.

Aspose.Slides udostępnia metodę [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pptxoptions/#setCompressionLevel), która pozwala określić poziom kompresji używany przy zapisywaniu prezentacji w formacie Office Open XML.

Dostępne są następujące poziomy kompresji:

- **None**: Nie stosuje się kompresji. Pliki są przechowywane w oryginalnej formie.
- **Level1**: Najszybsza kompresja przy najniższym współczynniku kompresji.
- **Level2**: Szybsza kompresja z nieco lepszym współczynnikiem kompresji niż **Level1**.
- **Level3**: Zapewnia lepszą kompresję niż **Level2**, przy umiarkowanym wpływie na czas przetwarzania.
- **Level4**: Zapewnia lepszą kompresję niż **Level3**.
- **Level5**: Zapewnia lepszą kompresję niż **Level4**, kosztem dodatkowego czasu przetwarzania.
- **Level6**: Standardowa kompresja, oferująca dobry balans między szybkością przetwarzania a rozmiarem pliku. To jest *domyślny poziom kompresji*.
- **Level7**: Zapewnia lepszą kompresję niż **Level6**, przy wolniejszym przetwarzaniu.
- **Level8**: Zapewnia lepszą kompresję niż **Level7**.
- **Level9**: Maksymalna kompresja. Produkuje najmniejszy rozmiar pliku kosztem najdłuższego czasu przetwarzania.

Poniższy przykład demonstruje, jak zapisać prezentację jako plik PPTX *bez kompresji*:

```js
const aspose = { slides: require("aspose.slides.via.java") };

const pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setCompressionLevel(aspose.slides.CompressionLevel.None);

const presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Sample-out.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

Ten przykład pokazuje, jak zapisać prezentację jako plik PPTX z *maksymalną kompresją*:

```js
const aspose = { slides: require("aspose.slides.via.java") };

const pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setCompressionLevel(aspose.slides.CompressionLevel.Level9);

const presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Sample-level9.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

## **Zapisz prezentacje bez odświeżania miniatury**

Metoda [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) steruje generowaniem miniaturki przy zapisywaniu prezentacji do PPTX:

- Jeśli ustawiona na `true`, miniaturka jest odświeżana podczas zapisu. To domyślne zachowanie.
- Jeśli ustawiona na `false`, obecna miniaturka jest zachowywana. Jeśli prezentacja nie ma miniaturki, nie zostanie ona wygenerowana.

W poniższym kodzie prezentacja jest zapisywana do PPTX bez odświeżania jej miniaturki.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

## **Zapisuj aktualizacje postępu w procentach**

Raportowanie postępu zapisu jest konfigurowane za pomocą metody [setProgressCallback](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/saveoptions/#setProgressCallback) w klasie [SaveOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/saveoptions/) oraz jej podklasach. Dostarcz proxy w języku Java implementujące interfejs [IProgressCallback](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iprogresscallback/); podczas eksportu wywołanie zwrotne otrzymuje okresowe aktualizacje procentowe.

Poniższe fragmenty kodu pokazują, jak używać `IProgressCallback`.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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
Aspose opracowało [darmową aplikację PowerPoint Splitter](https://products.aspose.app/slides/pl/splitter) wykorzystującą własne API. Aplikacja umożliwia podzielenie prezentacji na wiele plików, zapisując wybrane slajdy jako nowe pliki PPTX lub PPT.
{{% /alert %}}

## **FAQ**

**Czy wsparcie jest dla "szybkiego zapisu" (zapis przyrostowy), aby zapisywane były tylko zmiany?**

Nie. Zapis tworzy pełny plik docelowy przy każdym zapisie; przyrostowy „szybki zapis” nie jest obsługiwany.

**Czy zapisywanie tej samej instancji Presentation z wielu wątków jest bezpieczne wątkowo?**

Nie. Instancja [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) [nie jest bezpieczna wątkowo](/slides/pl/nodejs-java/multithreading/); zapisuj ją z jednego wątku.

**Co się dzieje z hiperłączami i zewnętrznie powiązanymi plikami podczas zapisu?**

[Hyperlinks](/slides/pl/nodejs-java/manage-hyperlinks/) są zachowywane. Zewnętrznie powiązane pliki (np. wideo za pomocą ścieżek względnych) nie są kopiowane automatycznie — upewnij się, że odwołane ścieżki pozostają dostępne.

**Czy mogę ustawiać/zapisywać metadane dokumentu (Autor, Tytuł, Firma, Data)?**

Tak. Standardowe [właściwości dokumentu](/slides/pl/nodejs-java/presentation-properties/) są obsługiwane i zostaną zapisane w pliku przy zapisie.