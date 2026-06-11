---
title: Zapisywanie prezentacji w .NET
linktitle: Zapisz prezentację
type: docs
weight: 80
url: /pl/net/save-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak zapisywać prezentacje w .NET przy użyciu Aspose.Slides — eksport do PowerPoint lub OpenDocument przy zachowaniu układów, czcionek i efektów."
---
## **Przegląd**

[Open Presentations in C#](/slides/pl/net/open-presentation/) opisuje, jak używać klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) do otwierania prezentacji. Ten artykuł wyjaśnia, jak tworzyć i zapisywać prezentacje. Klasa [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) zawiera zawartość prezentacji. Niezależnie od tego, czy tworzysz prezentację od podstaw, czy modyfikujesz istniejącą, po zakończeniu będziesz chciał ją zapisać. Dzięki Aspose.Slides dla .NET możesz zapisać do **pliku** lub **strumienia**. Ten artykuł opisuje różne sposoby zapisywania prezentacji.

## **Zapisywanie prezentacji do plików**

Zapisz prezentację do pliku, wywołując metodę `Save` klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/). Przekaż nazwę pliku i format zapisu do metody. Poniższy przykład pokazuje, jak zapisać prezentację przy użyciu Aspose.Slides.

```cs
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
using (Presentation presentation = new Presentation())
{
    // Wykonaj tutaj pewne działania...

    // Zapisz prezentację do pliku.
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Zapisywanie prezentacji do strumieni**

Możesz zapisać prezentację do strumienia, przekazując strumień wyjściowy do metody `Save` klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/). Prezentację można zapisać do wielu typów strumieni. W poniższym przykładzie tworzymy nową prezentację i zapisujemy ją do strumienia pliku.

```cs
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
using (Presentation presentation = new Presentation())
{
    using (FileStream fileStream = new FileStream("Output.pptx", FileMode.Create))
    {
        // Zapisz prezentację do strumienia.
        presentation.Save(fileStream, SaveFormat.Pptx);
    }
}
```

## **Zapisywanie prezentacji z określonym typem widoku**

Aspose.Slides umożliwia ustawienie początkowego widoku, którego PowerPoint używa po otwarciu wygenerowanej prezentacji, za pomocą klasy [ViewProperties](https://reference.aspose.com/slides/pl/net/aspose.slides/viewproperties/). Ustaw właściwość [LastView](https://reference.aspose.com/slides/pl/net/aspose.slides/viewproperties/lastview/) na wartość z wyliczenia [ViewType](https://reference.aspose.com/slides/pl/net/aspose.slides/viewtype/).

```cs
using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```

## **Zapisywanie prezentacji w ścisłym formacie Office Open XML**

Aspose.Slides umożliwia zapisanie prezentacji w ścisłym formacie Office Open XML. Użyj klasy [PptxOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/pptxoptions/) i ustaw jej właściwość conformancja podczas zapisu. Jeśli ustawisz `Conformance.Iso29500_2008_Strict`, plik wyjściowy zostanie zapisany w ścisłym formacie Office Open XML.

Poniższy przykład tworzy prezentację i zapisuje ją w ścisłym formacie Office Open XML.

```cs
PptxOptions options = new PptxOptions()
{
    Conformance = Conformance.Iso29500_2008_Strict
};

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
using (Presentation presentation = new Presentation())
{
    // Zapisz prezentację w ścisłym formacie Office Open XML.
    presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
}
```

## **Zapisywanie prezentacji w formacie Office Open XML w trybie Zip64**

Plik Office Open XML jest archiwum ZIP, które nakłada limity 4 GB (2^32 bajtów) na rozmiar niekompresowany dowolnego pliku, rozmiar skompresowany dowolnego pliku oraz całkowity rozmiar archiwum, a także limituje liczbę plików w archiwum do 65 535 (2^16‑1). Rozszerzenia formatu ZIP64 podnoszą te limity do 2^64.

Właściwość [IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/pl/net/aspose.slides.export/ipptxoptions/zip64mode/) pozwala wybrać, kiedy używać rozszerzeń formatu ZIP64 podczas zapisywania pliku Office Open XML.

Ta właściwość udostępnia następujące tryby:
- `IfNecessary` używa rozszerzeń formatu ZIP64 tylko wtedy, gdy prezentacja przekracza powyższe ograniczenia. To domyślny tryb.
- `Never` nigdy nie używa rozszerzeń formatu ZIP64.
- `Always` zawsze używa rozszerzeń formatu ZIP64.

Poniższy kod demonstruje, jak zapisać prezentację jako PPTX z włączonymi rozszerzeniami formatu ZIP64:

```cs
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        Zip64Mode = Zip64Mode.Always
    });
}
```

{{% alert title="NOTE" color="warning" %}}
Gdy zapisujesz z `Zip64Mode.Never`, zostaje rzucony wyjątek [PptxException](https://reference.aspose.com/slides/pl/net/aspose.slides/pptxexception/), jeśli prezentacji nie można zapisać w formacie ZIP32.
{{% /alert %}}

## **Zapisywanie prezentacji bez odświeżania miniatury**

Właściwość [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/pl/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) kontroluje generowanie miniatury podczas zapisywania prezentacji do PPTX:
- Jeśli ustawiona na `true`, miniatura jest odświeżana podczas zapisu. To domyślne ustawienie.
- Jeśli ustawiona na `false`, bieżąca miniatura jest zachowywana. Jeśli prezentacja nie ma miniatury, nie zostanie wygenerowana.

W poniższym kodzie prezentacja jest zapisywana do PPTX bez odświeżania jej miniatury.

```cs
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        RefreshThumbnail = false
    });
}
```

{{% alert title="Info" color="info" %}}
Ta opcja pomaga skrócić czas potrzebny na zapisanie prezentacji w formacie PPTX.
{{% /alert %}}

## **Aktualizacje postępu zapisu w procentach**

Interfejs [IProgressCallback](https://reference.aspose.com/slides/pl/net/aspose.slides/iprogresscallback/) jest używany poprzez właściwość `ProgressCallback` udostępnioną przez interfejs [ISaveOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/isaveoptions/) oraz abstrakcyjną klasę [SaveOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/saveoptions/). Przypisz implementację [IProgressCallback](https://reference.aspose.com/slides/pl/net/aspose.slides/iprogresscallback/) do `ProgressCallback`, aby otrzymywać aktualizacje postępu zapisu w procentach.

Poniższe fragmenty kodu pokazują, jak używać `IProgressCallback`.

```cs
ISaveOptions saveOptions = new PdfOptions();
saveOptions.ProgressCallback = new ExportProgressHandler();

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pdf", SaveFormat.Pdf, saveOptions);
}
```

```cs
class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        // Użyj tutaj wartości procentowej postępu.
        int progress = Convert.ToInt32(progressValue);

        Console.WriteLine(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose opracowało [bezpłatną aplikację PowerPoint Splitter](https://products.aspose.app/slides/pl/splitter) korzystającą z własnego API. Aplikacja umożliwia podzielenie prezentacji na wiele plików poprzez zapis wybranych slajdów jako nowych plików PPTX lub PPT.
{{% /alert %}}

## **FAQ**

**Czy „szybki zapis” (zapis przyrostowy) jest obsługiwany, tak aby zapisywać tylko zmiany?**

Nie. Przy zapisie tworzony jest pełny plik docelowy za każdym razem; przyrostowy „szybki zapis” nie jest obsługiwany.

**Czy zapisywanie tej samej instancji Presentation z wielu wątków jest bezpieczne wątkowo?**

Nie. Instancja [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) [nie jest bezpieczna wątkowo](/slides/pl/net/multithreading/); zapisz ją z jednego wątku.

**Co dzieje się z hiperłączami i zewnętrznie powiązanymi plikami podczas zapisu?**

[Hiperłącza](/slides/pl/net/manage-hyperlinks/) są zachowywane. Zewnętrznie powiązane pliki (np. wideo wskazane względnymi ścieżkami) nie są kopiowane automatycznie — należy zapewnić, aby odwoływane ścieżki pozostawały dostępne.

**Czy mogę ustawić/zapisać metadane dokumentu (Autor, Tytuł, Firma, Data)?**

Tak. Standardowe [właściwości dokumentu](/slides/pl/net/presentation-properties/) są obsługiwane i zostaną zapisane do pliku podczas zapisu.