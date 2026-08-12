---
title: Zapisywanie prezentacji w C++
linktitle: Zapisz prezentację
type: docs
weight: 80
url: /pl/cpp/save-presentation/
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
- zapis postępu
- C++
- Aspose.Slides
description: "Dowiedz się, jak zapisywać prezentacje w C++ przy użyciu Aspose.Slides — eksportuj do PowerPoint lub OpenDocument, zachowując układy, czcionki i efekty."
---
## **Przegląd**

[Open Presentations in C++](/slides/pl/cpp/open-presentation/) opisuje, jak używać klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) do otwarcia prezentacji. Ten artykuł wyjaśnia, jak tworzyć i zapisywać prezentacje. Klasa [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) zawiera zawartość prezentacji. Niezależnie od tego, czy tworzysz prezentację od podstaw, czy modyfikujesz istniejącą, będziesz chciał ją zapisać po zakończeniu. Z Aspose.Slides for C++ możesz zapisać ją do **pliku** lub **strumienia**. Ten artykuł opisuje różne sposoby zapisywania prezentacji.

## **Zapisywanie prezentacji do plików**

Zapisz prezentację do pliku, wywołując metodę `Save` klasy Presentation. Przekaż nazwę pliku i format zapisu do metody. Poniższy przykład pokazuje, jak zapisać prezentację przy użyciu Aspose.Slides.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
auto presentation = MakeObject<Presentation>();

// Wykonaj tutaj pewne operacje...

// Zapisz prezentację do pliku.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Zapisywanie prezentacji do strumieni**

Możesz zapisać prezentację do strumienia, przekazując strumień wyjściowy do metody `Save` klasy Presentation. Prezentację można zapisać w wielu typach strumieni. W poniższym przykładzie tworzymy nową prezentację i zapisujemy ją do strumienia pliku.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
auto presentation = MakeObject<Presentation>();

auto fileStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

// Zapisz prezentację do strumienia.
presentation->Save(fileStream, SaveFormat::Pptx);

presentation->Dispose();
fileStream->Close();
```

## **Zapisywanie prezentacji z określonym typem widoku**

Aspose.Slides pozwala ustawić początkowy widok, którego PowerPoint używa po otwarciu wygenerowanej prezentacji, za pomocą klasy ViewProperties. Użyj metody set_LastView z wartością z enumeracji ViewType.

```cpp
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <ViewType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);

presentation->Save(u"SlideMasterView.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Zapisywanie prezentacji w ścisłym formacie Office Open XML**

Aspose.Slides umożliwia zapisanie prezentacji w ścisłym formacie Office Open XML. Użyj klasy PptxOptions i ustaw jej właściwość conformance podczas zapisywania. Jeśli ustawisz `Conformance.Iso29500_2008_Strict`, plik wyjściowy zostanie zapisany w ścisłym formacie Office Open XML.

Poniższy przykład tworzy prezentację i zapisuje ją w ścisłym formacie Office Open XML.

```cpp
#include <DOM/Presentation.h>
#include <Export/Conformance.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto options = MakeObject<PptxOptions>();
options->set_Conformance(Conformance::Iso29500_2008_Strict);

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
auto presentation = MakeObject<Presentation>();

// Zapisz prezentację w ścisłym formacie Office Open XML.
presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Zapisywanie prezentacji w formacie Office Open XML w trybie Zip64**

Plik Office Open XML jest archiwum ZIP, które narzuca limity 4 GB (2^32 bajtów) na nieskompresowany rozmiar dowolnego pliku, skompresowany rozmiar dowolnego pliku oraz całkowity rozmiar archiwum, a także ogranicza archiwum do 65 535 (2^16‑1) plików. Rozszerzenia formatu ZIP64 podnoszą te limity do 2^64.

Metoda IPptxOptions::set_Zip64Mode pozwala wybrać, kiedy używać rozszerzeń formatu ZIP64 podczas zapisywania pliku Office Open XML.

Ta metoda może być użyta z następującymi trybami:

- `IfNecessary` używa rozszerzeń ZIP64 tylko wtedy, gdy prezentacja przekracza powyższe ograniczenia. Jest to tryb domyślny.
- `Never` nigdy nie używa rozszerzeń ZIP64.
- `Always` zawsze używa rozszerzeń ZIP64.

Poniższy kod demonstruje, jak zapisać prezentację jako plik PPTX z włączonymi rozszerzeniami formatu ZIP64:

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <Export/Zip64Mode.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_Zip64Mode(Zip64Mode::Always);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}}
Gdy zapisujesz z `Zip64Mode.Never`, zostaje zgłoszony PptxException, jeśli prezentacji nie można zapisać w formacie ZIP32.
{{% /alert %}}

## **Zapisywanie prezentacji w formacie Office Open XML z poziomami kompresji**

Podczas pracy z dużymi prezentacjami możesz dostosować poziom kompresji, aby zrównoważyć rozmiar pliku i czas przetwarzania. W zależności od wymagań możesz preferować szybsze przetwarzanie lub mniejsze pliki wyjściowe.

Aspose.Slides udostępnia metodę PptxOptions::set_CompressionLevel, która pozwala określić poziom kompresji używany przy zapisywaniu prezentacji w formacie Office Open XML.

Dostępne poziomy kompresji:

- **None**: Nie stosuje się kompresji. Pliki są przechowywane w niezmienionej formie.
- **Level1:** Najszybsza kompresja przy najniższym współczynniku kompresji.
- **Level2:** Szybsza kompresja z nieco lepszym współczynnikiem niż **Level1**.
- **Level3:** Lepsza kompresja niż **Level2**, przy umiarkowanym wpływie na czas przetwarzania.
- **Level4:** Lepsza kompresja niż **Level3**.
- **Level5:** Ulepszona kompresja w stosunku do **Level4**, przy dodatkowym czasie przetwarzania.
- **Level6:** Standardowa kompresja zapewniająca dobrą równowagę między szybkością przetwarzania a rozmiarem pliku. To jest *domyślny poziom kompresji*.
- **Level7:** Lepsza kompresja niż **Level6**, przy wolniejszym przetwarzaniu.
- **Level8:** Lepsza kompresja niż **Level7**.
- **Level9:** Maksymalna kompresja. Produkuje najmniejszy rozmiar pliku kosztem najdłuższego czasu przetwarzania.

Poniższy przykład demonstruje, jak zapisać prezentację jako plik PPTX *bez kompresji*:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Export::CompressionLevel;
using Aspose::Slides::Export::PptxOptions;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::MakeObject;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_CompressionLevel(CompressionLevel::None);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");
presentation->Save(u"Sample-out.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

Ten przykład pokazuje, jak zapisać prezentację jako plik PPTX z *maksymalną kompresją*:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Export::CompressionLevel;
using Aspose::Slides::Export::PptxOptions;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::MakeObject;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_CompressionLevel(CompressionLevel::Level9);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");
presentation->Save(u"Sample-level9.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

## **Zapisywanie prezentacji bez odświeżania miniaturki**

Metoda PptxOptions::set_RefreshThumbnail kontroluje generowanie miniaturki przy zapisywaniu prezentacji do PPTX:

- Jeśli ustawiona na `true`, miniaturka jest odświeżana podczas zapisu. Jest to ustawienie domyślne.
- Jeśli ustawiona na `false`, obecna miniaturka jest zachowana. Jeśli prezentacja nie ma miniaturki, nie zostanie wygenerowana.

W poniższym kodzie prezentacja jest zapisywana do PPTX bez odświeżania miniaturki.

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_RefreshThumbnail(false);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
Ta opcja pomaga skrócić czas potrzebny do zapisania prezentacji w formacie PPTX.
{{% /alert %}}

## **Zapisywanie postępu w procentach**

Interfejs IProgressCallback jest używany poprzez metodę `set_ProgressCallback` udostępnioną przez interfejs ISaveOptions oraz abstrakcyjną klasę SaveOptions. Przypisz implementację IProgressCallback przy użyciu `set_ProgressCallback`, aby otrzymywać aktualizacje postępu zapisu w procentach.

Poniższe fragmenty kodu pokazują, jak używać `IProgressCallback`.

```cpp
#include <IProgressCallback.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        // Użyj tutaj wartości procentowej postępu.
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};
```
```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <IProgressCallback.h>
#include <system/console.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Klasa obsługi zwrotu postępu zdefiniowana powyżej.
class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};

auto saveOptions = MakeObject<PdfOptions>();
saveOptions->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, saveOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
Aspose opracowało bezpłatną aplikację PowerPoint Splitter wykorzystującą własne API. Aplikacja umożliwia podzielenie prezentacji na wiele plików poprzez zapis wybranych slajdów jako nowych plików PPTX lub PPT.
{{% /alert %}}

## **FAQ**

**Czy „szybki zapis” (zapis przyrostowy) jest obsługiwany, aby zapisywać tylko zmiany?**

Nie. Zapisywanie tworzy pełny plik docelowy za każdym razem; przyrostowy „szybki zapis” nie jest obsługiwany.

**Czy zapisywanie tej samej instancji Presentation z wielu wątków jest bezpieczne wątkowo?**

Nie. Instancja Presentation nie jest bezpieczna wątkowo; zapisuj ją z jednego wątku.

**Co się dzieje z odnośnikami i zewnętrznie powiązanymi plikami podczas zapisywania?**

Odnośniki są zachowane. Zewnętrznie powiązane pliki (np. wideo przy użyciu ścieżek względnych) nie są kopiowane automatycznie — upewnij się, że odwoływane ścieżki pozostają dostępne.

**Czy mogę ustawiać/zapisywać metadane dokumentu (Autor, Tytuł, Firma, Data)?**

Tak. Standardowe właściwości dokumentu są obsługiwane i zostaną zapisane w pliku podczas zapisu.