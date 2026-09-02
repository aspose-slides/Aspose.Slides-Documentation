---
title: Konwertuj prezentacje PowerPoint do XML w C++
linktitle: PowerPoint do XML
type: docs
weight: 145
url: /pl/cpp/convert-powerpoint-to-xml/
keywords:
- konwertuj PowerPoint do XML
- konwertuj prezentację do XML
- PPT do XML
- PPTX do XML
- ODP do XML
- Prezentacja PowerPoint XML
- SaveFormat::Xml
- zapisz prezentację jako XML
- eksportuj prezentację do XML
- strumień XML
- C++
- Aspose.Slides
description: "Konwertuj prezentacje PowerPoint i OpenDocument do plików lub strumieni PowerPoint XML w C++ przy użyciu Aspose.Slides for C++."
---
## **Przegląd**

Aspose.Slides for C++ może konwertować prezentacje PowerPoint na format PowerPoint XML Presentation. Wyjście XML jest przydatne, gdy potrzebujesz tekstowej reprezentacji do przeglądania struktury prezentacji, rozwiązywania problemów z wygenerowanymi dokumentami, porównywania wyników w automatycznych testach lub integracji z przepływem pracy, który konsumuje XML zamiast pakietu prezentacji.

Użyj metody [Presentation::Save](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/save/) z wartością `Xml` z wyliczenia [SaveFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/saveformat/). Wynik możesz zapisać bezpośrednio do pliku lub do strumienia.

{{% alert color="info" title="Note" %}}

`SaveFormat::Xml` tworzy PowerPoint XML Presentation. Nie wyodrębnia ona poszczególnych części Office Open XML przechowywanych w pakiecie PPTX. Jeśli potrzebujesz dokładnych części pakietu PPTX, takich jak `ppt/presentation.xml` lub pojedyncze pliki XML slajdów, zbadaj sam pakiet PPTX.

{{% /alert %}}

## **Konwertuj prezentację na plik XML**

Wczytaj prezentację źródłową przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/), a następnie przekaż ścieżkę wyjściową i `SaveFormat::Xml` do [Presentation::Save](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/save/). Źródłem może być dowolny format prezentacji obsługiwany przy wczytywaniu, taki jak PPT, PPTX lub ODP.

Poniższy przykład konwertuje prezentację PPTX na plik XML:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.xml", SaveFormat::Xml);
presentation->Dispose();
```

## **Zapisz wyjście XML do strumienia**

Użyj przeciążenia strumieniowego metody [Presentation::Save](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/save/) , gdy XML musi pozostać w pamięci lub zostać przekazane do innego komponentu, takiego jak usługa sieciowa, dostawca pamięci lub potok przetwarzania XML. Poniższy przykład zapisuje wynik do [MemoryStream](https://reference.aspose.com/slides/pl/cpp/system.io/memorystream/) i przewija go w celu późniejszego odczytu:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto xmlStream = System::MakeObject<MemoryStream>();

presentation->Save(xmlStream, SaveFormat::Xml);
xmlStream->set_Position(0);
presentation->Dispose();

// Przekaż xmlStream do następnego komponentu w przepływie pracy.
```

## **Porównaj XML z formatami prezentacji i eksportu**

Wybierz format wyjścia w zależności od tego, jak wynik będzie używany:

| Format | Wyjście | Typowe zastosowanie |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Prezentacja PowerPoint XML | Inspekcja struktury, rozwiązywanie problemów, porównywanie wygenerowanego wyjścia oraz integracja oparta na XML |
| PPT (`.ppt`) | Plik prezentacji binarnej starszej generacji | Zgodność ze starszymi przepływami pracy PowerPoint |
| PPTX (`.pptx`) | Pakiet Office Open XML zawierający wiele części | Standardowa edycja PowerPoint i wymiana prezentacji |
| PDF or TIFF | Strony o stałym układzie lub obraz wielostronicowy | Wyświetlanie, drukowanie i archiwizacja |
| PNG, JPEG, or SVG | Wizualna reprezentacja pojedynczego slajdu | Miniatury, podglądy i zasoby graficzne |
| HTML or HTML5 | Wyjście prezentacji skierowane do sieci | Wyświetlanie w przeglądarce i publikacja internetowa |

W przeciwieństwie do PPT i PPTX, wyjście XML jest przeznaczone głównie do inspekcji i przepływów danych. W przeciwieństwie do PDF, TIFF, HTML i formatów obrazów slajdów, reprezentuje dane prezentacji, a nie renderuje slajdów jako strony lub zasoby wizualne. Tabela [obsługiwanych formatów plików](/slides/pl/cpp/supported-file-formats/) wymienia PowerPoint XML Presentation jako format wyłącznie do zapisu, więc nie używaj go, gdy przepływ wymaga wczytania wyeksportowanego pliku z powrotem do Aspose.Slides w celu dalszej edycji.

## **FAQ**

**Czy `SaveFormat::Xml` jest tym samym co zapisanie pliku PPTX?**

Nie. PPTX jest pakietem zawierającym wiele części Office Open XML, podczas gdy `SaveFormat::Xml` tworzy plik PowerPoint XML Presentation.

**Czy mogę zapisać wyjście XML bez tworzenia pliku na dysku?**

Tak. Przekaż zapisywalny strumień do [Presentation::Save](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/save/). Na przykład użyj [MemoryStream](https://reference.aspose.com/slides/pl/cpp/system.io/memorystream/) do przetwarzania w pamięci.

**Czy Aspose.Slides może ponownie wczytać wyeksportowany plik XML?**

Nie. PowerPoint XML Presentation jest obecnie obsługiwany jedynie przy zapisywaniu, nie przy wczytywaniu. Użyj PPTX lub innego obsługiwanego formatu prezentacji, gdy wymagana jest edycja w obie strony.

**Czy konwersja XML renderuje każdy slajd jako stronę lub obraz?**

Nie. Konwersja XML zapisuje ustrukturyzowane dane prezentacji. Użyj PDF lub TIFF do wyjścia opartego na stronach lub PNG, JPEG i SVG do obrazów pojedynczych slajdów.