---
title: Edycja dokumentów PDF w C++
linktitle: Edycja PDF
type: docs
weight: 65
url: /pl/cpp/edit-pdf/
keywords:
- edycja PDF
- zastępowanie tekstu w PDF
- PDF do PPTX
- PPTX do PDF
- C++
- Aspose.Slides
description: "Edycja dokumentów PDF w C++ poprzez ich importowanie do Aspose.Slides, zastępowanie tekstu i zapisywanie zmodyfikowanej prezentacji z powrotem do PDF."
---
## **Przegląd**

Aspose.Slides for C++ umożliwia edytowanie treści PDF poprzez importowanie jego stron jako slajdy, modyfikowanie prezentacji i eksportowanie jej z powrotem do PDF. Ten artykuł pokazuje prostą zamianę tekstu. Prezentacja pozostaje w pamięci, więc zapisanie pośredniego pliku PPTX jest opcjonalne.

## **Zamiana tekstu w pliku PDF**

Użyj [SlideCollection::AddFromPdf](https://reference.aspose.com/slides/pl/cpp/aspose.slides/slidecollection/addfrompdf/), aby zaimportować strony, [Presentation::ReplaceText](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/replacetext/), aby zaktualizować tekst, oraz [Presentation::Save](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/save/), aby wyeksportować wynik.

Poniższy przykład zakłada, że `input.pdf` zawiera słowo „Draft” jako edytowalny tekst po imporcie. Zastępuje ono to słowo słowem „Final” i zapisuje `edited.pdf`. Wyczyszczenie początkowego slajdu przed importem zapobiega dodatkowej pustej stronie w wyniku. Wyszukiwanie dopasowuje całe słowa z taką samą wielkością liter; `nullptr` oznacza, że nie jest potrzebny zwrotny wywołanie wyniku.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
presentation->get_Slides()->RemoveAt(0);

presentation->get_Slides()->AddFromPdf(u"input.pdf");

auto searchOptions = MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);
searchOptions->set_CaseSensitive(true);
presentation->ReplaceText(u"Draft", u"Final", searchOptions, nullptr);

presentation->Save(u"edited.pdf", SaveFormat::Pdf);
presentation->Dispose();
```

Aby uzyskać więcej opcji, zobacz [Wyszukiwanie i zamiana tekstu](/slides/pl/cpp/search-and-replace-text/) oraz [Konwertowanie PowerPoint do PDF](/slides/pl/cpp/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
Zamiana tekstu działa na zaimportowanym tekście, a nie na tekście znajdującym się w zeskanowanych obrazach. Konwersja może wpływać na układ i formatowanie, więc należy przejrzeć wynik, szczególnie gdy zamieniany tekst jest dłuższy niż oryginalny.
{{% /alert %}}

## **FAQ**

**Czy muszę zapisać plik PPTX przed wyeksportowaniem PDF?**

Nie. Możesz edytować i wyeksportować tę samą prezentację w pamięci. Zapisz kopię PPTX tylko wtedy, gdy chcesz kontynuować edycję w programie PowerPoint; zobacz [Zapisz prezentacje](/slides/pl/cpp/save-presentation/).

**Dlaczego niektóry tekst może pozostać niezmieniony?**

Przykład dopasowuje całe słowo „Draft” z dokładną wielkością liter. Tekst zaimportowany jako obraz lub podzielony na osobne ramki tekstowe niekoniecznie zostanie dopasowany. Sprawdź zaimportowaną zawartość i dostosuj wyszukiwanie do swojego dokumentu.