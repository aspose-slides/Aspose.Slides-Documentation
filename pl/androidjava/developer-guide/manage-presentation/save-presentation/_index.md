---
title: Zapisz prezentacje na Androidzie
linktitle: Zapisz prezentację
type: docs
weight: 80
url: /pl/androidjava/save-presentation/
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
- postęp zapisu
- Android
- Java
- Aspose.Slides
description: "Dowiedz się, jak zapisywać prezentacje w Javie przy użyciu Aspose.Slides dla Androida — eksportować do PowerPoint lub OpenDocument, zachowując układy, czcionki i efekty."
---
## **Przegląd**

[Otwórz prezentacje na Androidzie](/slides/pl/androidjava/open-presentation/) opisuje, jak używać klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) do otwierania prezentacji. Ten artykuł wyjaśnia, jak tworzyć i zapisywać prezentacje. Klasa [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) zawiera zawartość prezentacji. Niezależnie od tego, czy tworzysz prezentację od podstaw, czy modyfikujesz istniejącą, po zakończeniu będziesz chciał ją zapisać. Dzięki Aspose.Slides dla Androida możesz zapisać do **pliku** lub **strumienia**. Ten artykuł opisuje różne sposoby zapisywania prezentacji.

## **Zapisz prezentacje do plików**

Zapisz prezentację do pliku, wywołując metodę `save` klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/). Przekaż nazwę pliku i format zapisu do metody. Poniższy przykład pokazuje, jak zapisać prezentację przy użyciu Aspose.Slides.

```java
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
Presentation presentation = new Presentation();
try {
    // Wykonaj tutaj jakieś operacje...

    // Zapisz prezentację do pliku.
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Zapisz prezentacje do strumieni**

Możesz zapisać prezentację do strumienia, przekazując strumień wyjściowy do metody `save` klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/). Prezentację można zapisać do wielu typów strumieni. W poniższym przykładzie tworzymy nową prezentację i zapisujemy ją do strumienia pliku.

```java
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
Presentation presentation = new Presentation();
try {
    OutputStream fileStream = new FileOutputStream("Output.pptx");
    try {
        // Zapisz prezentację do strumienia.
        presentation.save(fileStream, SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Zapisz prezentacje z określonym typem widoku**

Aspose.Slides umożliwia ustawienie początkowego widoku, który PowerPoint używa po otwarciu wygenerowanej prezentacji, za pomocą klasy [ViewProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/viewproperties/). Użyj metody [setLastView](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/viewproperties/#setLastView-int-) z wartością z wyliczenia [ViewType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/viewtype/).

```java
Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Zapisz prezentacje w ścisłym formacie Office Open XML**

Aspose.Slides umożliwia zapisanie prezentacji w ścisłym formacie Office Open XML. Użyj klasy [PptxOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pptxoptions/) i ustaw jej właściwość `conformance` podczas zapisu. Jeśli ustawisz [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict), plik wyjściowy zostanie zapisany w ścisłym formacie Office Open XML.

Poniższy przykład tworzy prezentację i zapisuje ją w ścisłym formacie Office Open XML.

```java
PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
Presentation presentation = new Presentation();
try {
    // Zapisz prezentację w ścisłym formacie Office Open XML.
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Zapisz prezentacje w formacie Office Open XML w trybie Zip64**

Plik Office Open XML jest archiwum ZIP, które narzuca limity 4 GB (2^32 bajtów) na nieskompresowany rozmiar dowolnego pliku, skompresowany rozmiar dowolnego pliku oraz całkowity rozmiar archiwum, a także ogranicza liczbę plików w archiwum do 65 535 (2^16‑1). Rozszerzenia formatu ZIP64 podnoszą te limity do 2^64.

Metoda [IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) umożliwia wybranie, kiedy używać rozszerzeń formatu ZIP64 przy zapisywaniu pliku Office Open XML.

Ta metoda może być użyta z następującymi trybami:

- [IfNecessary](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/zip64mode/#IfNecessary) używa rozszerzeń ZIP64 tylko wtedy, gdy prezentacja przekracza powyższe ograniczenia. To domyślny tryb.
- [Never](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/zip64mode/#Never) nigdy nie używa rozszerzeń ZIP64.
- [Always](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/zip64mode/#Always) zawsze używa rozszerzeń ZIP64.

Poniższy kod demonstruje, jak zapisać prezentację jako PPTX z włączonymi rozszerzeniami ZIP64:

```java
PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setZip64Mode(Zip64Mode.Always);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}}
Gdy zapisujesz z [Zip64Mode.Never](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/zip64mode/#Never), zostaje rzucony [PptxException](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pptxexception/), jeśli prezentacji nie można zapisać w formacie ZIP32.
{{% /alert %}}

## **Zapisz prezentacje bez odświeżania miniatury**

Metoda [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) kontroluje generowanie miniatury przy zapisywaniu prezentacji do PPTX:

- Jeśli ustawiona na `true`, miniatura jest odświeżana podczas zapisu. To domyślne zachowanie.
- Jeśli ustawiona na `false`, zachowywana jest bieżąca miniatura. Jeśli prezentacja nie ma miniatury, żadna nie zostanie wygenerowana.

W poniższym kodzie prezentacja jest zapisywana do PPTX bez odświeżania jej miniatury.

```java
PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setRefreshThumbnail(false);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pptx", SaveFormat.Pptx, pptxOptions);
}
finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Ta opcja pomaga skrócić czas potrzebny na zapisanie prezentacji w formacie PPTX.
{{% /alert %}}

## **Zapisz postępy jako procenty**

Interfejs [IProgressCallback](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iprogresscallback/) jest używany za pośrednictwem metody `setProgressCallback` udostępnionej przez interfejs [ISaveOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isaveoptions/) oraz abstrakcyjną klasę [SaveOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/saveoptions/). Przypisz implementację [IProgressCallback](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iprogresscallback/) przy pomocy `setProgressCallback`, aby otrzymywać aktualizacje postępu zapisu w procentach.

Poniższe fragmenty kodu pokazują, jak używać `IProgressCallback`.

```java
ISaveOptions saveOptions = new PdfOptions();
saveOptions.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```
```java
class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        // Użyj tutaj wartości procentowej postępu.
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose opracowało bezpłatną aplikację [PowerPoint Splitter](https://products.aspose.app/slides/pl/splitter) korzystającą z własnego API. Aplikacja pozwala podzielić prezentację na wiele plików, zapisując wybrane slajdy jako nowe pliki PPTX lub PPT.
{{% /alert %}}

## **FAQ**

**Czy obsługiwany jest „szybki zapis” (zapis przyrostowy), aby zapisywać tylko zmiany?**

Nie. Zapis tworzy pełny plik docelowy przy każdym wywołaniu; przyrostowy „szybki zapis” nie jest obsługiwany.

**Czy zapis tego samego obiektu Presentation z wielu wątków jest bezpieczny?**

Nie. Obiekt [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) **nie jest bezpieczny dla wielu wątków**; zapisz go z jednego wątku.

**Co się dzieje z hiperłączami i zewnętrznie powiązanymi plikami podczas zapisu?**

[Hiperłącza](/slides/pl/androidjava/manage-hyperlinks/) są zachowywane. Zewnętrznie powiązane pliki (np. wideo wskazywane względnymi ścieżkami) nie są kopiowane automatycznie — należy upewnić się, że odwoływane ścieżki pozostają dostępne.

**Czy mogę ustawić/zapisać metadane dokumentu (Autor, Tytuł, Firma, Data)?**

Tak. Standardowe [właściwości dokumentu](/slides/pl/androidjava/presentation-properties/) są obsługiwane i zostaną zapisane w pliku podczas zapisu.