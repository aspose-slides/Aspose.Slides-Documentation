---
title: Dostosowywanie pasków błędów w wykresach prezentacji przy użyciu C++
linktitle: Pasek błędu
type: docs
url: /pl/cpp/error-bar/
keywords:
- pasek błędu
- wartość niestandardowa
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Dowiedz się, jak dodawać i dostosowywać paski błędów w wykresach za pomocą Aspose.Slides dla C++ — optymalizuj wizualizację danych w prezentacjach PowerPoint."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z słupkami błędów w wykresach prezentacji przy użyciu Aspose.Slides. Pokazuje, jak dodać słupki błędów do serii wykresu, skonfigurować ustawienia słupków błędów X i Y oraz zastosować różne typy wartości, takie jak stałe, procentowe i niestandardowe.

Pokazuje także, jak przypisać niestandardowe wartości słupków błędów do poszczególnych punktów danych w serii, używając odpowiedniej kolekcji punktów danych. Dodatkowo artykuł zawiera krótkie uwagi na temat zachowania słupków błędów podczas eksportu, ich kompatybilności z markerami i etykietami danych oraz gdzie znaleźć powiązane klasy i wyliczenia referencji API.

## **Dodaj paski błędów**
Aspose.Slides for C++ udostępnia prosty interfejs API do zarządzania wartościami pasków błędów. Przykładowy kod ma zastosowanie przy użyciu typu wartości niestandardowej. Aby określić wartość, użyj właściwości **ErrorBarCustomValues** konkretnego punktu danych w kolekcji **DataPoints** serii:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
1. Dodaj wykres bąbelkowy na wybranym slajdzie.
1. Uzyskaj dostęp do pierwszej serii wykresu i ustaw format pasków błędów X.
1. Uzyskaj dostęp do pierwszej serii wykresu i ustaw format pasków błędów Y.
1. Ustawienie wartości i formatu pasków.
1. Zapisz zmodyfikowaną prezentację do pliku PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddErrorBars-AddErrorBars.cpp" >}}

## **Dodaj niestandardowe paski błędów**
Aspose.Slides for C++ udostępnia prosty interfejs API do zarządzania niestandardowymi wartościami pasków błędów. Przykładowy kod ma zastosowanie, gdy właściwość **IErrorBarsFormat.ValueType** jest równa **Custom**. Aby określić wartość, użyj właściwości **ErrorBarCustomValues** konkretnego punktu danych w kolekcji **DataPoints** serii:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
1. Dodaj wykres bąbelkowy na wybranym slajdzie.
1. Uzyskaj dostęp do pierwszej serii wykresu i ustaw format pasków błędów X.
1. Uzyskaj dostęp do pierwszej serii wykresu i ustaw format pasków błędów Y.
1. Uzyskaj dostęp do poszczególnych punktów danych serii wykresu i ustaw wartości pasków błędów dla pojedynczego punktu danych serii.
1. Ustawienie wartości i formatu pasków.
1. Zapisz zmodyfikowaną prezentację do pliku PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddCustomError-AddCustomError.cpp" >}}

## **FAQ**

**Co się dzieje z paskami błędów podczas eksportu prezentacji do formatu PDF lub obrazów?**

Są renderowane jako część wykresu i zachowywane podczas konwersji wraz z resztą formatowania wykresu, pod warunkiem użycia kompatybilnej wersji lub renderera.

**Czy paski błędów mogą być łączone z markerami i etykietami danych?**

Tak. Paski błędów są odrębnym elementem i są kompatybilne z markerami oraz etykietami danych; jeśli elementy nakładają się na siebie, może być konieczne dostosowanie formatowania.

**Gdzie mogę znaleźć listę właściwości i wyliczeń do pracy z paskami błędów w API?**

W referencji API: klasa [ErrorBarsFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/errorbarsformat/) oraz powiązane wyliczenia [ErrorBarType](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/errorbartype/) i [ErrorBarValueType](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/errorbarvaluetype/).