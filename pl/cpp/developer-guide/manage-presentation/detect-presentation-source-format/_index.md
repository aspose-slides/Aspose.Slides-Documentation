---
title: Określenie oryginalnego formatu prezentacji w C++
linktitle: Format źródłowy
type: docs
weight: 35
url: /pl/cpp/detect-presentation-source-format/
keywords:
- format źródłowy
- wykrywanie formatu prezentacji
- PowerPoint
- OpenDocument
- prezentacja
- PPT
- PPTX
- C++
- Aspose.Slides
description: "Odczytaj oryginalny format załadowanej prezentacji w C++ przy użyciu Aspose.Slides dla C++, porównaj interfejsy API wykrywania oraz obsługuj pliki, strumienie i starsze formaty."
---
## **Przegląd**

Po załadowaniu prezentacji wywołaj [Presentation::get_SourceFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/get_sourceformat/) aby określić jej oryginalny format. Metoda jest również dostępna poprzez [IPresentation::get_SourceFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentation/get_sourceformat/). Użyj jej, gdy dalsze przetwarzanie zależy od formatu, z którego została załadowana bieżąca instancja.

Format źródłowy różni się od [SaveFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/saveformat/) wybranego dla pliku wyjściowego. Zapis do innego formatu nie zmienia formatu źródłowego istniejącej instancji.

## **Odczytanie formatu źródłowego pliku**

Ten przykład wymaga istniejącego pliku `sample.pptx`. Ładuje plik i wybiera politykę przetwarzania aplikacji przy użyciu [Presentation::get_SourceFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/get_sourceformat/), zamiast nazwy pliku. Zmień ścieżkę wejściową, aby wypróbować inne formaty. Przykład wypisuje wybraną politykę; zastąp komunikaty własną logiką aplikacji.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

switch (presentation->get_SourceFormat())
{
    case SourceFormat::Ppt:
    case SourceFormat::Pps:
    case SourceFormat::Pot:
        Console::WriteLine(u"Use the legacy PowerPoint processing policy.");
        break;
    case SourceFormat::Pptx:
        Console::WriteLine(u"Use the standard PPTX processing policy.");
        break;
    default:
        Console::WriteLine(String::Format(u"Use the general policy for {0}.", ObjectExt::ToString(presentation->get_SourceFormat())));
        break;
}
```

## **Rozpoznawanie obsługiwanych wartości**

Wyliczenie [SourceFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/sourceformat/) rozróżnia następujące formaty prezentacji. Poniższe rozszerzenia są konwencjonalnymi rozszerzeniami, a nie odtworzeniem oryginalnej nazwy pliku.

| Wartość SourceFormat | Rozszerzenie | Format |
| --- | --- | --- |
| `Ppt` | `.ppt` | Prezentacja PowerPoint 97–2003 |
| `Pptx` | `.pptx` | Prezentacja Office Open XML |
| `Pptm` | `.pptm` | Prezentacja Office Open XML z włączonymi makrami |
| `Pps` | `.pps` | Pokaz slajdów PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | Pokaz slajdów Office Open XML |
| `Ppsm` | `.ppsm` | Pokaz slajdów Office Open XML z włączonymi makrami |
| `Pot` | `.pot` | Szablon PowerPoint 97–2003 |
| `Potx` | `.potx` | Szablon Office Open XML |
| `Potm` | `.potm` | Szablon Office Open XML z włączonymi makrami |
| `Odp` | `.odp` | Prezentacja OpenDocument |
| `Otp` | `.otp` | Szablon prezentacji OpenDocument |
| `Fodp` | `.fodp` | Prezentacja Flat XML ODF |
| `Xml` | `.xml` | Prezentacja PowerPoint XML |

## **Odczytanie formatu źródłowego ze strumienia**

Ten przykład wymaga istniejącego pliku `sample.pps`. Odczytanie jego bajtów do strumienia pamięciowego symuluje dane otrzymane bez nazwy pliku, np. wartość z bazy danych lub przesłaną tablicę bajtów. Konstruktor [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) przyjmuje jedynie strumień.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto bytes = File::ReadAllBytes(u"sample.pps");
auto stream = MakeObject<MemoryStream>(bytes);
auto presentation = MakeObject<Presentation>(stream);

Console::WriteLine(String::Format(u"Source format: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));
```

PPT, PPS i POT używają tego samego podstawowego formatu binarnego. Przy ładowaniu po ścieżce pliku rozszerzenie może pomóc odróżnić pokaz slajdów lub szablon. Bez nazwy pliku starsze treści PPS i POT mogą być raportowane jako `SourceFormat::Ppt`; przykład PPS powyżej raportuje `Ppt`.

Jeśli aplikacja musi zachować rozróżnienie, przechowuj oryginalną nazwę pliku lub metadane podtypów osobno. Rozszerzenie jest przydatną wskazówką dla tych starszych podtypów, ale nie powinno być jedyną podstawą do identyfikacji dowolnej zawartości prezentacji.

## **Porównanie wykrycia przed i po załadowaniu**

Użyj [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentationfactory/getpresentationinfo/) i [IPresentationInfo::get_LoadFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentationinfo/get_loadformat/) gdy trzeba przeanalizować plik przed załadowaniem pełnego modelu obiektu prezentacji. Użyj [Presentation::get_SourceFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/get_sourceformat/) gdy instancja już istnieje.

Ten przykład wymaga `sample.pptx` i wypisuje `Pptx` dla obu sprawdzeń. W produkcji wybierz API odpowiednie do etapu przetwarzania; już załadowana prezentacja nie wymaga drugiej inspekcji wyłącznie w celu uzyskania jej formatu źródłowego.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <DOM/PresentationFactory.h>
#include <DOM/IPresentationInfo.h>
#include <LoadFormat.h>

using namespace Aspose::Slides;
using namespace System;

auto path = String(u"sample.pptx");
auto information = PresentationFactory::get_Instance()->GetPresentationInfo(path);
Console::WriteLine(String::Format(u"Before loading: {0}", ObjectExt::ToString(information->get_LoadFormat())));

auto presentation = MakeObject<Presentation>(path);
Console::WriteLine(String::Format(u"After loading: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));
```

Wyniki mają różne typy wyliczeń: [LoadFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/loadformat/) i [SourceFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/sourceformat/). Nie porównuj ich poprzez rzutowanie ich wartości liczbowych ani nie zakładaj, że każdy format ma identyczne wyniki wykrywania. PowerPoint XML może być zgłaszany jako `LoadFormat::Unknown` przed załadowaniem i `SourceFormat::Xml` po załadowaniu.

## **Utrzymanie formatu źródłowego i wyjściowego osobno**

Ten przykład wymaga `sample.pptx` i zapisuje `converted.odp`. Wypisuje `Pptx` zarówno przed, jak i po zapisaniu oryginalnej instancji. Tylko nowa instancja załadowana z wyjściowego pliku ODP raportuje `Odp`.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
Console::WriteLine(String::Format(u"Before saving: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));

presentation->Save(u"converted.odp", SaveFormat::Odp);
Console::WriteLine(String::Format(u"After saving: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));

auto reopened = MakeObject<Presentation>(u"converted.odp");
Console::WriteLine(String::Format(u"Reopened output: {0}", ObjectExt::ToString(reopened->get_SourceFormat())));
```

Prezentacja utworzona od zera przy użyciu `MakeObject<Presentation>()` raportuje `SourceFormat::Pptx`. Nie ma pliku wejściowego: jest to wartość domyślna dla nowo utworzonej instancji, a nie dowód, że został załadowany plik PPTX. Śledź, czy aplikacja utworzyła, czy załadowała instancję osobno, jeśli to rozróżnienie ma znaczenie.

## **Mapowanie formatu źródłowego na rozszerzenie**

Poniższy przykład wymaga `sample.pptx`. Mapuje każdą aktualnie obsługiwaną wartość [SourceFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/sourceformat/) na konwencjonalne rozszerzenie, bez parsowania nazwy pliku wejściowego. Zapasowy mechanizm zapobiega cichemu przypisaniu rozszerzenia do nierozpoznanej wartości.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto extension = String::Empty;
switch (presentation->get_SourceFormat())
{
    case SourceFormat::Ppt:
        extension = u".ppt";
        break;
    case SourceFormat::Pptx:
        extension = u".pptx";
        break;
    case SourceFormat::Pptm:
        extension = u".pptm";
        break;
    case SourceFormat::Pps:
        extension = u".pps";
        break;
    case SourceFormat::Ppsx:
        extension = u".ppsx";
        break;
    case SourceFormat::Ppsm:
        extension = u".ppsm";
        break;
    case SourceFormat::Pot:
        extension = u".pot";
        break;
    case SourceFormat::Potx:
        extension = u".potx";
        break;
    case SourceFormat::Potm:
        extension = u".potm";
        break;
    case SourceFormat::Odp:
        extension = u".odp";
        break;
    case SourceFormat::Otp:
        extension = u".otp";
        break;
    case SourceFormat::Fodp:
        extension = u".fodp";
        break;
    case SourceFormat::Xml:
        extension = u".xml";
        break;
    default:
        break;
}

Console::WriteLine(extension.IsEmpty() ? u"No extension mapping is available." : extension);
```

To mapowanie nie konwertuje pliku ani nie odzyskuje starszego podtypu PPS/POT utraconego podczas ładowania ze strumienia. Do rzeczywistego zapisu wybierz explicite [SaveFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/saveformat/), lub użyj konwersji pokazanej w [Save Presentations in Their Original Format](/slides/pl/cpp/save-presentation/#save-presentations-in-their-original-format).

## **Weryfikacja formatów przez zapis i ponowne otwarcie**

Ten samodzielny przykład tworzy prezentację i zapisuje trzy pliki w katalogu roboczym, nadpisując pliki o tych samych nazwach. Otwiera ponownie każdy wynik zarówno po ścieżce, jak i przez strumień pamięciowy. Dla PPTX i ODP oba sposoby raportują zapisany format. Dla PPS ładowanie po ścieżce raportuje `Pps`, podczas gdy ładowanie tych samych bajtów bez nazwy pliku raportuje `Ppt`.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto formats = MakeArray<SaveFormat>({SaveFormat::Pptx, SaveFormat::Odp, SaveFormat::Pps});

for (auto format : formats)
{
    auto formatName = ObjectExt::ToString(format);
    auto path = String::Format(u"roundtrip.{0}", formatName.ToLowerInvariant());
    presentation->Save(path, format);

    auto fromFile = MakeObject<Presentation>(path);
    auto bytes = File::ReadAllBytes(path);
    auto stream = MakeObject<MemoryStream>(bytes);
    auto fromStream = MakeObject<Presentation>(stream);

    Console::WriteLine(String::Format(u"{0}: file={1}, stream={2}", formatName, ObjectExt::ToString(fromFile->get_SourceFormat()), ObjectExt::ToString(fromStream->get_SourceFormat())));
}
```

Poniższa tabela podsumowuje identyfikację formatu źródłowego dla prezentacji o dopasowanych rozszerzeniach:

| Zapisany format | SourceFormat ze ścieżki pliku | SourceFormat ze strumienia bez nazwy |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` respectively | Jak w ścieżce pliku |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` respectively | Jak w ścieżce pliku |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` respectively | Jak w ścieżce pliku |
| ODP, OTP | `Odp`, `Otp` respectively | Jak w ścieżce pliku |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

Starszy zawartość PPS/POT jest normalizowana do `Ppt` w strumieniach bez nazwy. Tabela opisuje identyfikację formatu, a nie zachowanie wszystkich cech prezentacji podczas konwersji.

## **FAQ**

**Czy zapis do ODP zmienia format źródłowy prezentacji załadowanej z PPTX?**

Nie. Istniejąca instancja nadal raportuje `Pptx`. Instancja załadowana z zapisanego pliku ODP raportuje `Odp`.

**Czy strumień zawsze potrafi odróżnić starszą prezentację, pokaz slajdów i szablon?**

Nie. PPT, PPS i POT dzielą ten sam format binarny. Przechowuj nazwę pliku lub metadane podtypu osobno, gdy to rozróżnienie jest wymagane.

**Jakie API powinienem używać, jeśli prezentacja jest już załadowana?**

Użyj [Presentation::get_SourceFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/get_sourceformat/). Użyj [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentationfactory/getpresentationinfo/) do inspekcji przed załadowaniem.