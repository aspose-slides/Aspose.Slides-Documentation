---
title: Licencjonowanie rozliczane
type: docs
weight: 90
url: /pl/net/metered-licensing/
keywords:
- licencja
- licencja rozliczana
- klucze licencji
- klucz publiczny
- klucz prywatny
- ilość zużycia
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak licencjonowanie rozliczane Aspose.Slides dla .NET umożliwia elastyczne przetwarzanie plików PowerPoint i OpenDocument, płacąc wyłącznie za to, czego używasz."
---
## **Wprowadzenie**

Licencjonowanie rozliczane to mechanizm licencjonowania, który można stosować wraz z istniejącymi metodami licencjonowania. Jeśli chcesz być rozliczany na podstawie użycia funkcji API Aspose.Slides, wybierasz licencjonowanie rozliczane.

## **Zastosowanie kluczy rozliczanych**

Gdy kupujesz licencję rozliczaną, otrzymujesz klucze (a nie plik licencji). Ten klucz rozliczany można zastosować przy użyciu klasy [Metered](https://reference.aspose.com/slides/pl/net/aspose.slides/metered/) udostępnionej przez Aspose do operacji rozliczania. Po więcej szczegółów zobacz [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

1. Utwórz instancję klasy [Metered](https://reference.aspose.com/slides/pl/net/aspose.slides/metered/).
1. Przekaż swoje klucze publiczny i prywatny do metody [SetMeteredKey](https://reference.aspose.com/slides/pl/net/aspose.slides/metered/setmeteredkey/).
1. Wykonaj pewne przetwarzanie (wykonaj zadania).
1. Wywołaj metodę [GetConsumptionQuantity](https://reference.aspose.com/slides/pl/net/aspose.slides/metered/getconsumptionquantity/) klasy `Metered`.

Powinieneś zobaczyć liczbę żądań API, które dotychczas zużyto.

Ten przykładowy kod pokazuje, jak używać licencjonowania rozliczanego:

```cs
// Tworzy instancję klasy Metered
Aspose.Slides.Metered metered = new Aspose.Slides.Metered();

// Przekazuje klucz publiczny i prywatny do obiektu Metered
metered.SetMeteredKey("<valid public key>", "<valid private key>");

// Pobiera ilość danych rozliczanych przed wywołaniem API
decimal amountBefore = Aspose.Slides.Metered.GetConsumptionQuantity();
Console.WriteLine("Amount consumed before: " + amountBefore.ToString());

// Wykonaj coś z API Aspose.Slides tutaj
// ...

// Pobiera ilość danych rozliczanych po wywołaniu API
decimal amountAfter = Aspose.Slides.Metered.GetConsumptionQuantity();
Console.WriteLine("Amount consumed after: " + amountAfter.ToString());
```

{{% alert color="warning" title="UWAGA"  %}} 
Aby używać licencjonowania rozliczanego, potrzebne jest stabilne połączenie internetowe, ponieważ mechanizm licencjonowania wykorzystuje internet do ciągłej interakcji z naszymi usługami i wykonywania obliczeń.
{{% /alert %}} 

## **FAQ**

**Czy mogę używać licencji rozliczanej razem z regularną (wieczystą lub tymczasową) w tej samej aplikacji?**

Tak. Licencjonowanie rozliczane jest dodatkowym mechanizmem licencjonowania, który można stosować razem z istniejącymi [metodami licencjonowania](/slides/pl/net/licensing/). Wybierasz, który mechanizm zastosować przy uruchamianiu aplikacji.

**Co dokładnie liczy się jako zużycie w ramach licencji rozliczanej: operacje czy pliki?**

Liczone jest użycie API, czyli liczba żądań lub operacji. Aktualne zużycie możesz uzyskać za pomocą [metod śledzenia zużycia](https://reference.aspose.com/slides/pl/net/aspose.slides/metered/).

**Czy licencjonowanie rozliczane jest odpowiednie dla mikroserwisów i środowisk serverless, w których instancje często się restartują?**

Tak. Ponieważ rozliczenia odbywają się na poziomie wywołania API, scenariusze z częstymi zimnymi startami są kompatybilne, o ile dostęp do sieci jest stabilny dla obliczeń rozliczanych.

**Czy funkcjonalność biblioteki różni się przy użyciu licencji rozliczanej w porównaniu z licencją wieczystą?**

Nie. To dotyczy wyłącznie mechanizmu licencjonowania i rozliczeń; możliwości produktu pozostają takie same.

**Jak licencjonowanie rozliczane odnosi się do wersji próbnej i licencji tymczasowej?**

Wersja próbna ma ograniczenia i znaki wodne, [licencja tymczasowa](https://purchase.aspose.com/temporary-license/) usuwa ograniczenia na 30 dni, a licencjonowanie rozliczane usuwa ograniczenia i nalicza opłaty w oparciu o rzeczywiste użycie.

**Czy mogę kontrolować budżet, automatycznie reagując, gdy przekroczony zostanie próg zużycia?**

Tak. Częstą praktyką jest okresowe odczytywanie aktualnego zużycia za pomocą [metod śledzenia](https://reference.aspose.com/slides/pl/net/aspose.slides/metered/) i wdrażanie własnych limitów lub alertów na poziomie aplikacji lub monitoringu.