---
title: Dostosowywanie słupków błędów w wykresach prezentacji przy użyciu C++
linktitle: Słupki błędów
type: docs
url: /pl/cpp/error-bar/
keywords:
- słupki błędów
- wartość niestandardowa
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Dowiedz się, jak dodać i dostosować słupki błędów w wykresach za pomocą Aspose.Slides dla C++ — zoptymalizuj wizualizację danych w prezentacjach PowerPoint."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z słupkami błędów w wykresach prezentacji przy użyciu Aspose.Slides. Pokazuje, jak dodać słupki błędów do serii wykresu, skonfigurować ustawienia słupków błędów X i Y oraz zastosować różne typy wartości, takie jak stała, procentowa i własna.

Demonstruje również, jak przypisać własne wartości słupków błędów do pojedynczych punktów danych w serii za pomocą odpowiedniej kolekcji punktów danych. Dodatkowo artykuł zawiera krótkie uwagi na temat zachowania słupków błędów podczas eksportu, ich kompatybilności ze znacznikami i etykietami danych oraz gdzie znaleźć powiązane klasy i wyliczenia w referencji API.

## **Dodawanie słupków błędów**
Aspose.Slides for C++ udostępnia prosty interfejs API do zarządzania wartościami słupków błędów. Przykładowy kod ma zastosowanie przy użyciu własnego typu wartości. Aby określić wartość, użyj właściwości **ErrorBarCustomValues** konkretnego punktu danych w kolekcji **DataPoints** serii:

1. Utwórz instancję klasy [Prezentacja](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
1. Dodaj wykres bąbelkowy na wybranym slajdzie.
1. Uzyskaj dostęp do pierwszej serii wykresu i ustaw format słupka błędu X.
1. Uzyskaj dostęp do pierwszej serii wykresu i ustaw format słupka błędu Y.
1. Ustaw wartości i format słupków.
1. Zapisz zmodyfikowaną prezentację do pliku PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddErrorBars-AddErrorBars.cpp" >}}

## **Dodawanie własnych słupków błędów**
Aspose.Slides for C++ udostępnia prosty interfejs API do zarządzania własnymi wartościami słupków błędów. Przykładowy kod ma zastosowanie, gdy właściwość **IErrorBarsFormat.ValueType** jest równa **Custom**. Aby określić wartość, użyj właściwości **ErrorBarCustomValues** konkretnego punktu danych w kolekcji **DataPoints** serii:

1. Utwórz instancję klasy [Prezentacja](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
1. Dodaj wykres bąbelkowy na wybranym slajdzie.
1. Uzyskaj dostęp do pierwszej serii wykresu i ustaw format słupka błędu X.
1. Uzyskaj dostęp do pierwszej serii wykresu i ustaw format słupka błędu Y.
1. Uzyskaj dostęp do poszczególnych punktów danych serii wykresu i ustaw wartości słupka błędu dla wybranego punktu danych.
1. Ustaw wartości i format słupków.
1. Zapisz zmodyfikowaną prezentację do pliku PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddCustomError-AddCustomError.cpp" >}}

## **FAQ**

**Co się dzieje ze słupkami błędów podczas eksportowania prezentacji do formatu PDF lub obrazów?**

Są renderowane jako część wykresu i zachowywane podczas konwersji wraz z pozostałym formatowaniem wykresu, o ile używana jest zgodna wersja lub silnik renderujący.

**Czy słupki błędów mogą być łączone ze znacznikami i etykietami danych?**

Tak. Słupki błędów są odrębnym elementem i są kompatybilne ze znacznikami oraz etykietami danych; jeśli elementy się nakładają, może być konieczne dostosowanie formatowania.

**Gdzie mogę znaleźć listę właściwości i wyliczeń do pracy ze słupkami błędów w API?**

W dokumentacji API: klasa [ErrorBarsFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/errorbarsformat/) oraz powiązane wyliczenia [ErrorBarType](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/errorbartype/) i [ErrorBarValueType](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/errorbarvaluetype/).