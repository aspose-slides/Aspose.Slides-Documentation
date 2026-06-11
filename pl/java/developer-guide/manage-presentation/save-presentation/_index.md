---
title: Zapis prezentacji w Javie
linktitle: Zapis prezentacji
type: docs
weight: 80
url: /pl/java/save-presentation/
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
- Java
- Aspose.Slides
description: "Dowiedz się, jak zapisywać prezentacje w Javie przy użyciu Aspose.Slides - eksportuj do PowerPoint lub OpenDocument, zachowując układy, czcionki i efekty."
---
## **Przegląd**

[Open Presentations in Java](/slides/pl/java/open-presentation/) opisuje, jak używać klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) do otwierania prezentacji. Ten artykuł wyjaśnia, jak tworzyć i zapisywać prezentacje. Klasa [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) zawiera zawartość prezentacji. Niezależnie od tego, czy tworzysz prezentację od podstaw, czy modyfikujesz istniejącą, będziesz chciał ją zapisać po zakończeniu pracy. Dzięki Aspose.Slides for Java możesz zapisać do **pliku** lub **strumienia**. Ten artykuł wyjaśnia różne sposoby zapisywania prezentacji.

## **Zapis prezentacji do plików**

Zapisz prezentację do pliku, wywołując metodę `save` klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/). Przekaż nazwę pliku i format zapisu do tej metody. Poniższy przykład pokazuje, jak zapisać prezentację przy użyciu Aspose.Slides.

```java
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
Presentation presentation = new Presentation();
try {
    // Wykonaj tutaj jakąś pracę...

    // Zapisz prezentację do pliku.
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Zapis prezentacji do strumieni**

Możesz zapisać prezentację do strumienia, przekazując strumień wyjściowy do metody `save` klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/). Prezentację można zapisać w wielu typach strumieni. W poniższym przykładzie tworzymy nową prezentację i zapisujemy ją do strumienia pliku.

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

## **Zapis prezentacji z określonym typem widoku**

Aspose.Slides umożliwia ustawienie początkowego widoku, którego PowerPoint używa po otwarciu wygenerowanej prezentacji, za pomocą klasy [ViewProperties](https://reference.aspose.com/slides/pl/java/com.aspose.slides/viewproperties/). Użyj metody [setLastView](https://reference.aspose.com/slides/pl/java/com.aspose.slides/viewproperties/#setLastView-int-) z wartością z wyliczenia [ViewType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/viewtype/).

```java
Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Zapis prezentacji w formacie Strict Office Open XML**

Aspose.Slides pozwala zapisać prezentację w formacie Strict Office Open XML. Użyj klasy [PptxOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/pptxoptions/) i ustaw jej właściwość conformance podczas zapisu. Jeśli ustawisz [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/pl/java/com.aspose.slides/conformance/#Iso29500-2008-Strict), plik wyjściowy zostanie zapisany w formacie Strict Office Open XML.

Poniższy przykład tworzy prezentację i zapisuje ją w formacie Strict Office Open XML.

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

## **Zapis prezentacji w formacie Office Open XML w trybie Zip64**

Plik Office Open XML jest archiwum ZIP, które narzuca limity 4 GB (2^32 bajtów) na nie skompresowany rozmiar dowolnego pliku, skompresowany rozmiar dowolnego pliku oraz całkowity rozmiar archiwum, a także ogranicza liczbę plików w archiwum do 65 535 (2^16‑1). Rozszerzenia formatu ZIP64 podnoszą te limity do 2^64.

Metoda [IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) pozwala wybrać, kiedy używać rozszerzeń formatu ZIP64 podczas zapisywania pliku Office Open XML.

Ta metoda może być używana z następującymi trybami:

- [IfNecessary](https://reference.aspose.com/slides/pl/java/com.aspose.slides/zip64mode/#IfNecessary) używa rozszerzeń formatu ZIP64 tylko wtedy, gdy prezentacja przekracza powyższe ograniczenia. Jest to tryb domyślny.
- [Never](https://reference.aspose.com/slides/pl/java/com.aspose.slides/zip64mode/#Never) nigdy nie używa rozszerzeń formatu ZIP64.
- [Always](https://reference.aspose.com/slides/pl/java/com.aspose.slides/zip64mode/#Always) zawsze używa rozszerzeń formatu ZIP64.

Poniższy kod demonstruje, jak zapisać prezentację jako PPTX z włączonymi rozszerzeniami formatu ZIP64:

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

{{% alert title="UWAGA" color="warning" %}}
Gdy zapisujesz z użyciem [Zip64Mode.Never](https://reference.aspose.com/slides/pl/java/com.aspose.slides/zip64mode/#Never), zostaje rzucony [PptxException](https://reference.aspose.com/slides/pl/java/com.aspose.slides/pptxexception/), jeśli prezentację nie można zapisać w formacie ZIP32.
{{% /alert %}}

## **Zapis prezentacji bez odświeżania miniatury**

Metoda [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/pl/java/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) kontroluje generowanie miniatury przy zapisywaniu prezentacji do PPTX:

- Jeśli ustawiona na `true`, miniatura jest odświeżana podczas zapisu. Jest to wartość domyślna.
- Jeśli ustawiona na `false`, bieżąca miniatura jest zachowana. Jeśli prezentacja nie ma miniatury, nie zostanie wygenerowana.

W poniższym kodzie prezentacja jest zapisywana do PPTX bez odświeżania miniatury.

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

{{% alert title="Informacja" color="info" %}}
Ta opcja pomaga skrócić czas potrzebny na zapisanie prezentacji w formacie PPTX.
{{% /alert %}}

## **Zapisywanie postępu w procentach**

Interfejs [IProgressCallback](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iprogresscallback/) jest używany za pośrednictwem metody `setProgressCallback` udostępnionej przez interfejs [ISaveOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isaveoptions/) oraz abstrakcyjną klasę [SaveOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/saveoptions/). Przypisz implementację [IProgressCallback](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iprogresscallback/) przy użyciu `setProgressCallback`, aby otrzymywać aktualizacje postępu zapisu w procentach.

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

{{% alert title="Informacja" color="info" %}}
Aspose opracowało [darmową aplikację PowerPoint Splitter](https://products.aspose.app/slides/pl/splitter) wykorzystującą własne API. Aplikacja pozwala podzielić prezentację na wiele plików, zapisując wybrane slajdy jako nowe pliki PPTX lub PPT.
{{% /alert %}}

## **FAQ**

**Czy obsługiwany jest „szybki zapis” (zapis przyrostowy), aby zapisywać tylko zmiany?**

Nie. Zapis tworzy pełny plik docelowy za każdym razem; przyrostowy „szybki zapis” nie jest obsługiwany.

**Czy zapisywanie tej samej instancji Presentation z wielu wątków jest bezpieczne wątkowo?**

Nie. Instancja [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) [nie jest bezpieczna wątkowo](/slides/pl/java/multithreading/); zapisuj ją z jednego wątku.

**Co się dzieje z hiperłączami i zewnętrznie powiązanymi plikami podczas zapisu?**

[Hiperłącza](/slides/pl/java/manage-hyperlinks/) są zachowywane. Zewnętrznie powiązane pliki (np. wideo podane względnymi ścieżkami) nie są kopiowane automatycznie — upewnij się, że odwołane ścieżki pozostają dostępne.

**Czy mogę ustawić/zapisać metadane dokumentu (Autor, Tytuł, Firma, Data)?**

Tak. Standardowe [właściwości dokumentu](/slides/pl/java/presentation-properties/) są obsługiwane i zostaną zapisane w pliku podczas zapisu.