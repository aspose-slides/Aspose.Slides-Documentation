---
title: Zarządzanie dostępnością prezentacji w C++
linktitle: Dostępność prezentacji
type: docs
weight: 30
url: /pl/cpp/presentation-accessibility/
keywords:
- dostępność prezentacji
- tekst alternatywny
- tytuł tekstu alternatywnego
- opis tekstu alternatywnego
- oznacz jako dekoracyjny
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Automatyzuj kontrole dostępności prezentacji w plikach PPT, PPTX i ODP przy użyciu Aspose.Slides for C++ — popraw doświadczenie czytników ekranowych i zwiększ zgodność."
---
## **Introduction**

Tekst alternatywny pomaga osobom korzystającym z technologii wspomagających zrozumieć znaczenie obrazów, wykresów i innych informacyjnych kształtów. Ten artykuł wyjaśnia, jak odczytywać i aktualizować tytuły oraz opisy tekstu alternatywnego przy użyciu Aspose.Slides for C++, odróżnić opisy dostępności od nazw kształtów używanych w kodzie oraz sprawdzić, czy kształt jest oznaczony jako dekoracyjny.

Te funkcje wspierają dostępność prezentacji, ale nie gwarantują jej. Należy również sprawdzić kolejność odczytu, kontrast kolorów, czytelność tekstu oraz inne wymagania dostępności.

## **Manage Alternative Text Titles and Descriptions**

Używaj tekstu alternatywnego, aby wyjaśnić znaczenie obrazów, wykresów i innych informacyjnych kształtów osobom, które nie mogą ich zobaczyć. Poniższe właściwości służą różnym celom:

| Property or content | Purpose |
| --- | --- |
| [AlternativeTextTitle](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishape/get_alternativetexttitle/) | Krótki tytuł opisu alternatywnego. |
| [AlternativeText](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishape/get_alternativetext/) | Znaczący opis zawartości lub przeznaczenia kształtu w kontekście slajdu. |
| [Name](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishape/get_name/) | Nazwa kształtu, której kod może używać do znalezienia konkretnego kształtu w prezentacji. |
| Visible text | Zawartość wyświetlana na slajdzie, np. tekst kształtu lub tytuł i etykiety wykresu. Aktualizacja tekstu alternatywnego nie zmienia tej treści. |

Kiedy prezentacja jest ponownie używana jako szablon, kod może znaleźć kształt po jego [Name](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishape/get_name/) przed jego aktualizacją. Ta nazwa służy innemu celowi niż tekst alternatywny, który wyjaśnia, co wizualnie przekazuje czytelnikowi. Wyszukiwanie po nazwie pozwala autorom ulepszać lub tłumaczyć opisy bez zmiany sposobu, w jaki kod znajduje kształt. Nazwy mogą być edytowane i nie muszą być unikalne, dlatego sprawdź, czy nazwa odpowiada zamierzonemu kształtowi; zobacz [Identify and Find Shapes](/slides/pl/cpp/shape-manipulations/#identify-and-find-shapes).

The following example requires `input.pptx` with an image of an office entrance as the first shape on the first slide. The image should not be marked as decorative. The example reads and prints its current alternative text title and description, updates both values, and saves the presentation as `output.pptx`. Adapt the wording to the actual image and the information it conveys.

```cpp
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

Console::WriteLine(u"Alternative text title: {0}", shape->get_AlternativeTextTitle());
Console::WriteLine(u"Alternative text description: {0}", shape->get_AlternativeText());

shape->set_AlternativeTextTitle(u"Office entrance");
shape->set_AlternativeText(u"The office entrance has a wheelchair ramp to the right of the steps.");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Dodanie samego tekstu alternatywnego nie gwarantuje dostępności prezentacji ani zgodności ze standardami dostępności. Przejrzyj opisy pod kątem dokładności i istotności oraz sprawdź kolejność odczytu, kontrast kolorów, czytelny tekst i inne wymagania dostępności. Wizualizacje informacyjne nie powinny być oznaczane jako dekoracyjne; w kolejnej sekcji pokazano, jak odczytać [IsDecorative](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishape/get_isdecorative/).

## **Mark as Decorative**

Oznacz jako dekoracyjny flaguje wyłącznie ozdobne wizualizacje, aby czytniki ekranu je pomijały, redukując szum i skupiając uwagę na istotnej treści. Stosuj to w tle, ozdobach i elementach odstępu — nigdy w wykresach, ikonach ani obrazach przekazujących informacje. Aspose.Slides udostępnia tę flagę do wykrywania i walidacji, umożliwiając automatyczne kontrole dostępności i czyszczenie.

![Oznacz jako dekoracyjny](mark_as_decorative.png)

Poniższy przykład kodu pokazuje, jak określić, czy kształt jest oznaczony jako dekoracyjny.

```cpp
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);
Console::WriteLine(u"Is shape decorative: {0}", shape->get_IsDecorative());

presentation->Dispose();
```

## **FAQ**

**What should I put in the alternative text title and description?**  
**Co powinienem umieścić w tytule i opisie tekstu alternatywnego?**

Użyj krótkiego tytułu, aby zidentyfikować temat, oraz opisu, aby wyjaśnić informacje, które wizualizacja przekazuje w kontekście slajdu. Dla wykresu opisz istotny trend lub porównanie, zamiast po prostu pisać „wykres”.

**Should I use alternative text to locate shapes in a template?**  
**Czy powinienem używać tekstu alternatywnego do lokalizowania kształtów w szablonie?**

Preferuj znajdowanie kształtu po jego [Name](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishape/get_name/) i sprawdzanie, czy jest to oczekiwany kształt. Tekst alternatywny może być edytowany lub tłumaczony, co może przerwać kod wyszukujący dokładny opis; zobacz [Identify and Find Shapes](/slides/pl/cpp/shape-manipulations/).

**When should a shape be marked as decorative?**  
**Kiedy kształt powinien być oznaczony jako dekoracyjny?**

Używaj flagi dekoracyjnej dla wizualizacji, które nie dodają żadnej informacji, np. ozdobnych wzorów. Obrazy i wykresy przekazujące znaczenie wymagają odpowiedniego opisu zamiast flagi dekoracyjnej.

**Does adding alternative text make a presentation fully accessible?**  
**Czy dodanie tekstu alternatywnego sprawia, że prezentacja jest w pełni dostępna?**

Nie. Tekst alternatywny rozwiązuje tylko część problemów dostępności. Należy również przejrzeć kolejność odczytu, kontrast kolorów, czytelność tekstu i inne obowiązujące wymagania; samo ustawienie tych właściwości nie zapewnia zgodności.