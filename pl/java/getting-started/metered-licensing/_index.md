---
title: Licencjonowanie rozliczane
type: docs
weight: 100
url: /pl/java/metered-licensing/
keywords:
- licencja
- licencja rozliczana
- klucze licencyjne
- klucz publiczny
- klucz prywatny
- ilość zużycia
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Dowiedz się, jak licencjonowanie rozliczane Aspose.Slides dla Javy umożliwia elastyczną obsługę plików PowerPoint i OpenDocument, płacąc tylko za to, co wykorzystujesz."
---
## **Wprowadzenie**

Licencjonowanie rozliczane według zużycia jest mechanizmem licencyjnym, który może być używany wraz z istniejącymi metodami licencjonowania. Jeśli chcesz być rozliczany na podstawie wykorzystania funkcji API Aspose.Slides, wybierasz licencjonowanie rozliczane według zużycia.

## **Zastosowanie kluczy rozliczanych**

{{% alert color="info" %}} 

Licencjonowanie rozliczane według zużycia jest nowym mechanizmem licencyjnym, który może być używany wraz z istniejącymi metodami licencjonowania. Jeśli chcesz być rozliczany na podstawie wykorzystania funkcji API Aspose.Slides, wybierasz licencjonowanie rozliczane według zużycia.

Po zakupie licencji rozliczanej otrzymujesz klucze (a nie plik licencji). Ten klucz rozliczany można zastosować przy użyciu klasy [Metered](https://reference.aspose.com/slides/pl/java/com.aspose.slides/metered/) udostępnionej przez Aspose do operacji rozliczeniowych. Po więcej szczegółów zobacz [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Utwórz instancję klasy [Metered](https://reference.aspose.com/slides/pl/java/com.aspose.slides/metered/).

1. Przekaż swoje klucze publiczny i prywatny do metody [setMeteredKey](https://reference.aspose.com/slides/pl/java/com.aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-).

1. Wykonaj pewne przetwarzanie (wykonaj zadania).

1. Wywołaj metodę [getConsumptionQuantity](https://reference.aspose.com/slides/pl/java/com.aspose.slides/metered/#getConsumptionQuantity--) klasy `Metered`.

Powinieneś zobaczyć liczbę żądań API, które dotąd zużyłeś.

Poniższy kod przykładowy pokazuje, jak używać licencjonowania rozliczanego:

```java
// Tworzy instancję klasy Metered
com.aspose.slides.Metered metered = new com.aspose.slides.Metered();

try {
    // Przekazuje klucze publiczny i prywatny do obiektu Metered
    metered.setMeteredKey("<valid public key>", "<valid private key>");

    // Pobiera wartość zużytej ilości przed wywołaniami API
    double amountBefore = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed before: " + amountBefore);

    // Zrób coś z API Aspose.Slides tutaj
    // ...

    // Pobiera wartość zużytej ilości po wywołaniach API
    double amountAfter = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed after: " + amountAfter);
} catch (Exception ex) {
    ex.printStackTrace();
}
```

{{% alert color="warning" title="NOTE"  %}} 

Aby korzystać z licencjonowania rozliczanego, potrzebne jest stabilne połączenie internetowe, ponieważ mechanizm licencyjny używa internetu do ciągłej interakcji z naszymi usługami i wykonywania obliczeń.

{{% /alert %}} 

## **FAQ**

### Czy mogę używać licencji rozliczanej razem ze standardową (wieczystą lub tymczasową) w tej samej aplikacji?

Tak. Licencjonowanie rozliczane jest dodatkowym mechanizmem, który może być używany wraz z istniejącymi [metodami licencjonowania](/slides/pl/java/licensing/). Wybierasz, który mechanizm zastosować przy uruchamianiu aplikacji.

### Co dokładnie liczy się jako zużycie w ramach licencji rozliczanej: operacje czy pliki?

Liczone jest użycie API, czyli liczba żądań lub operacji. Aktualne zużycie możesz uzyskać za pomocą [consumption‑tracking methods](https://reference.aspose.com/slides/pl/java/com.aspose.slides/metered/).

### Czy licencjonowanie rozliczane jest odpowiednie dla mikroserwisów i środowisk serverless, w których instancje często się restartują?

Tak. Ponieważ rozliczanie odbywa się na poziomie wywołań API, scenariusze z częstymi zimnymi startami są kompatybilne, o ile istnieje stabilny dostęp sieciowy do obliczeń rozliczanych.

### Czy funkcjonalność biblioteki różni się przy użyciu licencji rozliczanej w porównaniu do licencji wieczystej?

Nie. To tylko kwestia mechanizmu licencjonowania i rozliczania; możliwości produktu są takie same.

### Jak licencjonowanie rozliczane odnosi się do wersji próbnej i licencji tymczasowej?

Wersja próbna ma ograniczenia i znaki wodne, [licencja tymczasowa](https://purchase.aspose.com/temporary-license/) usuwa ograniczenia na 30 dni, a licencjonowanie rozliczane usuwa ograniczenia i nalicza opłaty w oparciu o rzeczywiste użycie.

### Czy mogę kontrolować budżet, automatycznie reagując, gdy przekroczony zostanie próg zużycia?

Tak. Częstą praktyką jest okresowe odczytywanie bieżącego zużycia za pomocą [tracking methods](https://reference.aspose.com/slides/pl/java/com.aspose.slides/metered/) i wdrożenie własnych limitów lub alertów na poziomie aplikacji lub monitoringu.