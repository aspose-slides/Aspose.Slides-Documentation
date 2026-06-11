---
title: Zapisywanie prezentacji w C++
linktitle: Zapisz prezentację
type: docs
weight: 80
url: /pl/cpp/save-presentation/
keywords:
- zapis PowerPoint
- zapis OpenDocument
- zapis prezentacji
- zapis slajdu
- zapis PPT
- zapis PPTX
- zapis ODP
- prezentacja do pliku
- prezentacja do strumienia
- wstępnie określony typ widoku
- Ścisły format Office Open XML
- tryb Zip64
- odświeżanie miniatury
- postęp zapisu
- C++
- Aspose.Slides
description: "Odkryj, jak zapisywać prezentacje w C++ przy użyciu Aspose.Slides — eksportuj do PowerPoint lub OpenDocument, zachowując układy, czcionki i efekty."
---
## **Przegląd**

[Open Presentations in C++](/slides/pl/cpp/open-presentation/) opisuje, jak używać klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) do otwierania prezentacji. Ten artykuł wyjaśnia, jak tworzyć i zapisywać prezentacje. Klasa [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) zawiera zawartość prezentacji. Niezależnie od tego, czy tworzysz prezentację od zera, czy modyfikujesz istniejącą, będziesz chciał ją zapisać po zakończeniu. Dzięki Aspose.Slides for C++ możesz zapisać do **pliku** lub **strumienia**. Ten artykuł opisuje różne sposoby zapisywania prezentacji.

## **Zapis prezentacji do plików**

Zapisz prezentację do pliku, wywołując metodę `Save` klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/). Przekaż nazwę pliku i format zapisu do metody. Poniższy przykład pokazuje, jak zapisać prezentację za pomocą Aspose.Slides.

```cpp
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
auto presentation = MakeObject<Presentation>();

// Wykonaj tutaj jakieś czynności...

// Zapisz prezentację do pliku.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Zapis prezentacji do strumieni**

Możesz zapisać prezentację do strumienia, przekazując strumień wyjściowy do metody `Save` klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/). Prezentację można zapisać do wielu typów strumieni. W poniższym przykładzie tworzymy nową prezentację i zapisujemy ją do strumienia pliku.

```cpp
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
auto presentation = MakeObject<Presentation>();

auto fileStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

// Zapisz prezentację do strumienia.
presentation->Save(fileStream, SaveFormat::Pptx);

presentation->Dispose();
fileStream->Close();
```

## **Zapis prezentacji z określonym typem widoku**

Aspose.Slides umożliwia ustawienie początkowego widoku, którego PowerPoint używa po otwarciu wygenerowanej prezentacji, za pomocą klasy [ViewProperties](https://reference.aspose.com/slides/pl/cpp/aspose.slides/viewproperties/). Użyj metody [set_LastView](https://reference.aspose.com/slides/pl/cpp/aspose.slides/viewproperties/set_lastview/) z wartością z wyliczenia [ViewType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/viewtype/).

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);

presentation->Save(u"SlideMasterView.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Zapis prezentacji w formacie Strict Office Open XML**

Aspose.Slides pozwala zapisać prezentację w formacie Strict Office Open XML. Użyj klasy [PptxOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/pptxoptions/) i ustaw jej właściwość `Conformance` podczas zapisu. Jeśli ustawisz `Conformance.Iso29500_2008_Strict`, plik wyjściowy zostanie zapisany w formacie Strict Office Open XML.

Poniższy przykład tworzy prezentację i zapisuje ją w formacie Strict Office Open XML.

```cpp
auto options = MakeObject<PptxOptions>();
options->set_Conformance(Conformance::Iso29500_2008_Strict);

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
auto presentation = MakeObject<Presentation>();

// Zapisz prezentację w ścisłym formacie Office Open XML.
presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Zapis prezentacji w formacie Office Open XML w trybie Zip64**

Plik Office Open XML jest archiwum ZIP, które narzuca limit 4 GB (2^32 bajtów) na nie­skompresowany rozmiar dowolnego pliku, skompresowany rozmiar dowolnego pliku oraz całkowity rozmiar archiwum, a także ogranicza liczbę plików w archiwum do 65 535 (2^16‑1). Rozszerzenia formatu ZIP64 podnoszą te limity do 2^64.

Metoda [IPptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/ipptxoptions/set_zip64mode/) pozwala wybrać, kiedy używać rozszerzeń ZIP64 podczas zapisu pliku Office Open XML.

Ta metoda może być użyta w następujących trybach:

- `IfNecessary` używa rozszerzeń ZIP64 tylko wtedy, gdy prezentacja przekracza powyższe ograniczenia. Jest to tryb domyślny.
- `Never` nigdy nie używa rozszerzeń ZIP64.
- `Always` zawsze używa rozszerzeń ZIP64.

Poniższy kod demonstruje, jak zapisać prezentację jako PPTX z włączonymi rozszerzeniami ZIP64:

```cpp
auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_Zip64Mode(Zip64Mode::Always);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}}
Gdy zapisujesz z `Zip64Mode.Never`, zostaje rzucony [PptxException](https://reference.aspose.com/slides/pl/cpp/aspose.slides/pptxexception/), jeśli prezentacja nie może zostać zapisana w formacie ZIP32.
{{% /alert %}}

## **Zapis prezentacji bez odświeżania miniatury**

Metoda [PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) kontroluje generowanie miniatury podczas zapisywania prezentacji do PPTX:

- Jeśli ustawiona na `true`, miniatura jest odświeżana podczas zapisu. Jest to zachowanie domyślne.
- Jeśli ustawiona na `false`, zachowywana jest bieżąca miniatura. Jeśli prezentacja nie ma miniatury, nie zostanie wygenerowana żadna.

W poniższym kodzie prezentacja jest zapisywana do PPTX bez odświeżania jej miniatury.

```cpp
auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_RefreshThumbnail(false);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
Ta opcja pomaga skrócić czas potrzebny na zapis prezentacji w formacie PPTX.
{{% /alert %}}

## **Aktualizacje postępu zapisu w procentach**

Interfejs [IProgressCallback](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iprogresscallback/) jest używany poprzez metodę `set_ProgressCallback` udostępnioną przez interfejs [ISaveOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/isaveoptions/) oraz abstrakcyjną klasę [SaveOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/saveoptions/). Przypisz implementację [IProgressCallback](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iprogresscallback/) przy pomocy `set_ProgressCallback`, aby otrzymywać aktualizacje postępu zapisu w procentach.

Poniższe fragmenty kodu pokazują, jak używać `IProgressCallback`.

```cpp
class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue)
    {
        // Użyj tutaj wartości procentowej postępu.
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};
```
```cpp
auto saveOptions = MakeObject<PdfOptions>();
saveOptions->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, saveOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
Aspose opracowało [bezpłatną aplikację PowerPoint Splitter](https://products.aspose.app/slides/pl/splitter) wykorzystującą własne API. Aplikacja pozwala podzielić prezentację na wiele plików, zapisując wybrane slajdy jako nowe pliki PPTX lub PPT.
{{% /alert %}}

## **FAQ**

**Czy „szybki zapis” (zapis przyrostowy) jest obsługiwany, tak aby zapisywane były tylko zmiany?**

Nie. Zapisywanie tworzy pełny plik docelowy przy każdym zapisie; przyrostowy „szybki zapis” nie jest obsługiwany.

**Czy zapisywanie tej samej instancji Presentation z wielu wątków jest bezpieczne?**

Nie. Instancja [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) nie jest bezpieczna wątkowo; zapisuj ją z jednego wątku.

**Co dzieje się z hiperłączami i zewnętrznie powiązanymi plikami przy zapisie?**

[Hyperlinki](/slides/pl/cpp/manage-hyperlinks/) są zachowywane. Zewnętrznie powiązane pliki (np. wideo wskazane względnymi ścieżkami) nie są kopiowane automatycznie — należy upewnić się, że odwoływane ścieżki pozostają dostępne.

**Czy mogę ustawić/zapisać metadane dokumentu (Autor, Tytuł, Firma, Data)?**

Tak. Standardowe [właściwości dokumentu](/slides/pl/cpp/presentation-properties/) są obsługiwane i zostaną zapisane w pliku przy zapisie.