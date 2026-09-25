---
title: Zarządzanie dostępnością prezentacji w .NET
linktitle: Dostępność prezentacji
type: docs
weight: 30
url: /pl/net/presentation-accessibility/
keywords:
- dostępność prezentacji
- tekst alternatywny
- tytuł tekstu alternatywnego
- opis tekstu alternatywnego
- oznacz jako dekoracyjne
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Automatyzuj kontrole dostępności prezentacji w plikach PPT, PPTX i ODP przy użyciu Aspose.Slides for .NET—popraw doświadczenie czytników ekranu i zwiększ zgodność."
---
## **Wprowadzenie**

Tekst alternatywny pomaga osobom korzystającym z technologii wspomagających zrozumieć znaczenie obrazów, wykresów i innych informacyjnych kształtów. Ten artykuł wyjaśnia, jak odczytywać i aktualizować tytuły i opisy tekstu alternatywnego przy użyciu Aspose.Slides for .NET, rozróżniać opisy dostępności od nazw kształtów używanych w kodzie oraz sprawdzać, czy kształt jest oznaczony jako dekoracyjny.

Funkcje te wspierają dostępność prezentacji, ale nie gwarantują jej. Należy również przeanalizować kolejność czytania, kontrast kolorów, czytelność tekstu i inne wymagania dotyczące dostępności.

## **Zarządzanie tytułami i opisami tekstu alternatywnego**

Użyj tekstu alternatywnego, aby wyjaśnić znaczenie obrazów, wykresów i innych informacyjnych kształtów dla osób, które nie mogą ich zobaczyć. Następujące właściwości służą różnym celom:

| Właściwość lub zawartość | Cel |
| --- | --- |
| [AlternativeTextTitle](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/alternativetexttitle/) | Krótki tytuł opisu alternatywnego. |
| [AlternativeText](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/alternativetext/) | Znaczący opis zawartości lub celu kształtu w kontekście slajdu. |
| [Name](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/name/) | Nazwa kształtu, której kod może używać do znalezienia konkretnego kształtu w prezentacji. |
| Visible text | Widoczny tekst – treść wyświetlana na slajdzie, np. tekst kształtu lub tytuł i etykiety wykresu. Aktualizacja tekstu alternatywnego nie zmienia tej treści. |

Podczas ponownego użycia prezentacji jako szablonu, kod może znajdować kształt po jego [Name](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/name/) przed jego aktualizacją. Ta nazwa pełni inną funkcję niż tekst alternatywny, który wyjaśnia, co wizualnie przekazuje czytelnikowi. Wyszukiwanie po nazwie pozwala autorom ulepszyć lub przetłumaczyć opisy bez zmiany sposobu, w jaki kod znajduje kształt. Nazwy mogą być edytowane i nie są gwarantowane jako unikalne, dlatego należy sprawdzić, czy nazwa odpowiada zamierzonemu kształtowi; zobacz [Identify and Find Shapes](/slides/pl/net/shape-manipulations/#identify-and-find-shapes).

Poniższy przykład wymaga pliku `input.pptx` zawierającego obraz wejścia biurowego jako pierwszy kształt na pierwszym slajdzie. Obraz nie powinien być oznaczony jako dekoracyjny. Przykład odczytuje i wypisuje bieżący tytuł i opis tekstu alternatywnego, aktualizuje obie wartości i zapisuje prezentację jako `output.pptx`. Dostosuj treść do rzeczywistego obrazu i przekazywanych informacji.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var shape = presentation.Slides[0].Shapes[0];

Console.WriteLine($"Alternative text title: {shape.AlternativeTextTitle}");
Console.WriteLine($"Alternative text description: {shape.AlternativeText}");

shape.AlternativeTextTitle = "Office entrance";
shape.AlternativeText = "The office entrance has a wheelchair ramp to the right of the steps.";

presentation.Save("output.pptx", SaveFormat.Pptx);
```

Dodanie samego tekstu alternatywnego nie gwarantuje dostępności prezentacji ani zgodności ze standardami dostępności. Należy zweryfikować opisy pod kątem dokładności i istotności, a także sprawdzić kolejność czytania, kontrast kolorów, czytelny tekst i inne wymagania dostępności. Informacyjne elementy wizualne nie powinny być oznaczane jako dekoracyjne; w kolejnym rozdziale pokazano, jak odczytać [IsDecorative](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/isdecorative/).

## **Oznacz jako dekoracyjne**

Flaga Oznacz jako dekoracyjne oznacza wyłącznie ozdobne elementy wizualne, aby czytniki ekranu je pomijały, redukując szum i skupiając uwagę na istotnej treści. Stosuj ją do tła, ozdobnych elementów i wypełniaczy — nigdy do wykresów, ikon ani obrazów przekazujących informacje. Aspose.Slides udostępnia tę flagę do wykrywania i walidacji, umożliwiając automatyczne kontrole dostępności i czyszczenie.

![Mark as Decorative](mark_as_decorative.png)

Poniższy przykład kodu pokazuje, jak określić, czy kształt jest oznaczony jako dekoracyjny.

```cs
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var shape = presentation.Slides[0].Shapes[0];
Console.WriteLine($"Is shape decorative: {shape.IsDecorative}");
```

## **FAQ**

**Co powinienem umieścić w tytule i opisie tekstu alternatywnego?**

Użyj krótkiego tytułu, aby zidentyfikować temat, oraz opisu, który wyjaśni informacje, jakie przekazuje wizualizacja w kontekście slajdu. W przypadku wykresu opisz istotny trend lub porównanie, zamiast jedynie używać słowa „wykres”.

**Czy powinienem używać tekstu alternatywnego do lokalizowania kształtów w szablonie?**

Zaleca się znajdowanie kształtu po jego [Name](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/name/) i sprawdzanie, czy jest to oczekiwany kształt. Tekst alternatywny może być edytowany lub tłumaczony, co może spowodować awarię kodu wyszukującego dokładny opis; zobacz [Identify and Find Shapes](/slides/pl/net/shape-manipulations/).

**Kiedy kształt powinien być oznaczony jako dekoracyjny?**

Używaj flagi dekoracyjnej dla elementów wizualnych, które nie dodają informacji, np. ozdobnych zdobień. Obrazy i wykresy przekazujące znaczenie wymagają odpowiedniego opisu.

**Czy dodanie tekstu alternatywnego sprawia, że prezentacja jest w pełni dostępna?**

Nie. Tekst alternatywny obejmuje tylko część wymogów dostępności. Należy również sprawdzić kolejność czytania, kontrast kolorów, czytelność tekstu i inne obowiązujące wymagania; ustawienie samych tych właściwości nie zapewnia zgodności.