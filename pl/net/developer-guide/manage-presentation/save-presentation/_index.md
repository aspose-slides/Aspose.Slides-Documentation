---
title: Zapisz prezentacje w .NET
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
- zdefiniowany typ widoku
- Ścisły format Office Open XML
- tryb Zip64
- odświeżanie miniatury
- postęp zapisu
- .NET
- C#
- Aspose.Slides
description: "Poznaj sposób zapisywania prezentacji w .NET przy użyciu Aspose.Slides — eksportuj do PowerPoint lub OpenDocument, zachowując układy, czcionki i efekty."
---
## **Przegląd**

[Open Presentations in C#](/slides/pl/net/open-presentation/) opisuje, jak używać klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) do otwierania prezentacji. Ten artykuł wyjaśnia, jak tworzyć i zapisywać prezentacje. Klasa [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) zawiera zawartość prezentacji. Niezależnie od tego, czy tworzysz prezentację od podstaw, czy modyfikujesz istniejącą, będziesz chciał ją zapisać po zakończeniu. Z Aspose.Slides for .NET możesz zapisać do **pliku** lub **strumienia**. Ten artykuł opisuje różne sposoby zapisywania prezentacji.

## **Zapisz prezentacje do plików**

Zapisz prezentację do pliku, wywołując metodę `Save` klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/). Przekaż nazwę pliku i format zapisu do metody. Poniższy przykład pokazuje, jak zapisać prezentację przy użyciu Aspose.Slides.

```cs
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
using (Presentation presentation = new Presentation())
{
    // Wykonaj tutaj jakieś operacje...

    // Zapisz prezentację do pliku.
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Zapisz prezentacje do strumieni**

Możesz zapisać prezentację do strumienia, przekazując strumień wyjściowy do metody `Save` klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/). Prezentację można zapisać do różnych typów strumieni. W poniższym przykładzie tworzymy nową prezentację i zapisujemy ją do strumienia pliku.

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

## **Zapisz prezentacje z określonym typem widoku**

Aspose.Slides umożliwia ustawienie początkowego widoku, który PowerPoint używa przy otwieraniu wygenerowanej prezentacji, za pomocą klasy [ViewProperties](https://reference.aspose.com/slides/pl/net/aspose.slides/viewproperties/). Ustaw właściwość [LastView](https://reference.aspose.com/slides/pl/net/aspose.slides/viewproperties/lastview/) na wartość z wyliczenia [ViewType](https://reference.aspose.com/slides/pl/net/aspose.slides/viewtype/).

```cs
using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```

## **Zapisz prezentacje w ścisłym formacie Office Open XML**

Aspose.Slides pozwala zapisać prezentację w ścisłym formacie Office Open XML. Użyj klasy [PptxOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/pptxoptions/) i ustaw jej właściwość conformance podczas zapisu. Jeśli ustawisz `Conformance.Iso29500_2008_Strict`, plik wyjściowy zostanie zapisany w ścisłym formacie Office Open XML.

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

## **Zapisz prezentacje w formacie Office Open XML w trybie Zip64**

Plik Office Open XML jest archiwum ZIP, które narzuca limity 4 GB (2^32 bajtów) na nie skompresowany rozmiar dowolnego pliku, skompresowany rozmiar dowolnego pliku oraz całkowity rozmiar archiwum, a także ogranicza liczbę plików w archiwum do 65 535 (2^16‑1). Rozszerzenia formatu ZIP64 podnoszą te limity do 2^64.

Właściwość [IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/pl/net/aspose.slides.export/ipptxoptions/zip64mode/) pozwala wybrać, kiedy używać rozszerzeń formatu ZIP64 przy zapisie pliku Office Open XML.

Ta właściwość oferuje następujące tryby:

- `IfNecessary` używa rozszerzeń ZIP64 tylko wtedy, gdy prezentacja przekracza powyższe ograniczenia. To domyślny tryb.
- `Never` nigdy nie używa rozszerzeń ZIP64.
- `Always` zawsze używa rozszerzeń ZIP64.

Poniższy kod demonstruje, jak zapisać prezentację jako plik PPTX z włączonymi rozszerzeniami formatu ZIP64:

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
Podczas zapisu z `Zip64Mode.Never` zostaje zgłoszony [PptxException](https://reference.aspose.com/slides/pl/net/aspose.slides/pptxexception/), jeśli prezentacji nie można zapisać w formacie ZIP32.
{{% /alert %}}

## **Zapisz prezentacje w formacie Office Open XML z poziomami kompresji**

Pracując z dużymi prezentacjami, możesz dostosować poziom kompresji, aby zrównoważyć rozmiar pliku i czas przetwarzania. W zależności od wymagań możesz preferować szybsze przetwarzanie lub mniejsze pliki wyjściowe.

Aspose.Slides udostępnia właściwość [IPptxOptions.CompressionLevel](https://reference.aspose.com/slides/pl/net/aspose.slides.export/ipptxoptions/compressionlevel/), która pozwala określić poziom kompresji używany podczas zapisu prezentacji w formacie Office Open XML.

Dostępne są następujące poziomy kompresji:

- **None**: Nie stosuje się kompresji. Pliki są przechowywane w niezmienionej formie.
- **Level1**: Najszybsza kompresja o najniższym współczynniku kompresji.
- **Level2**: Szybsza kompresja z nieco lepszym współczynnikiem kompresji niż **Level1**.
- **Level3**: Zapewnia lepszą kompresję niż **Level2**, przy umiarkowanym wpływie na czas przetwarzania.
- **Level4**: Zapewnia lepszą kompresję niż **Level3**.
- **Level5**: Zapewnia jeszcze lepszą kompresję niż **Level4**, kosztem dodatkowego czasu przetwarzania.
- **Level6**: Standardowa kompresja, która zapewnia dobrą równowagę między szybkością przetwarzania a rozmiarem pliku. To *domyślny poziom kompresji*.
- **Level7**: Zapewnia lepszą kompresję niż **Level6**, przy wolniejszym przetwarzaniu.
- **Level8**: Zapewnia lepszą kompresję niż **Level7**.
- **Level9**: Maksymalna kompresja. Produkuje najmniejszy rozmiar pliku kosztem najdłuższego czasu przetwarzania.

Poniższy przykład demonstruje, jak zapisać prezentację jako plik PPTX *bez kompresji*:
```cs
using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-out.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.None
    });
}
```

Ten przykład pokazuje, jak zapisać prezentację jako plik PPTX z *maksymalną kompresją*:
```cs
using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-level9.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.Level9
    });
}
```

## **Zapisz prezentacje bez odświeżania miniatury**

Właściwość [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/pl/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) kontroluje generowanie miniatury podczas zapisywania prezentacji do PPTX:

- Jeśli ustawiona na `true`, miniatura jest odświeżana podczas zapisu. To jest domyślne zachowanie.
- Jeśli ustawiona na `false`, bieżąca miniatura jest zachowywana. Jeśli prezentacja nie ma miniatury, nie zostanie wygenerowana żadna.

W poniższym kodzie prezentacja jest zapisywana do PPTX bez odświeżania miniatury.

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
Ta opcja pomaga skrócić czas potrzebny na zapis prezentacji w formacie PPTX.
{{% /alert %}}

## **Zapisuj aktualizacje postępu w procentach**

Interfejs [IProgressCallback](https://reference.aspose.com/slides/pl/net/aspose.slides/iprogresscallback/) jest używany poprzez właściwość `ProgressCallback` udostępnianą przez interfejs [ISaveOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/isaveoptions/) oraz abstrakcyjną klasę [SaveOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/saveoptions/). Przypisz implementację [IProgressCallback](https://reference.aspose.com/slides/pl/net/aspose.slides/iprogresscallback/) do `ProgressCallback`, aby otrzymywać aktualizacje postępu zapisu w procentach.

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
Aspose opracowało [darmową aplikację PowerPoint Splitter](https://products.aspose.app/slides/pl/splitter) wykorzystującą własne API. Aplikacja umożliwia podzielenie prezentacji na wiele plików poprzez zapis wybranych slajdów jako nowych plików PPTX lub PPT.
{{% /alert %}}

## **FAQ**

**Czy „szybki zapis” (zapis przyrostowy) jest obsługiwany, tak aby zapisywać tylko zmiany?**

Nie. Zapisywanie tworzy pełny plik docelowy za każdym razem; przyrostowy „szybki zapis” nie jest obsługiwany.

**Czy zapisywanie tej samej instancji Presentation z wielu wątków jest bezpieczne wątkowo?**

Nie. Instancja [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) [nie jest bezpieczna wątkowo](/slides/pl/net/multithreading/); zapisuj ją z jednego wątku.

**Co się dzieje z hiperłączami i zewnętrznie powiązanymi plikami podczas zapisu?**

[Hiperłącza](/slides/pl/net/manage-hyperlinks/) są zachowywane. Zewnętrznie powiązane pliki (np. wideo za pomocą ścieżek względnych) nie są kopiowane automatycznie — upewnij się, że odwołane ścieżki pozostają dostępne.

**Czy mogę ustawić/zapisać metadane dokumentu (Autor, Tytuł, Firma, Data)?**

Tak. Standardowe [właściwości dokumentu](/slides/pl/net/presentation-properties/) są obsługiwane i zostaną zapisane do pliku podczas zapisu.