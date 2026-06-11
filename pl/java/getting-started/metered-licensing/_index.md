---
title: Licencjonowanie metryczne
type: docs
weight: 100
url: /pl/java/metered-licensing/
keywords:
- licencja
- licencja metryczna
- klucze licencyjne
- klucz publiczny
- klucz prywatny
- ilość zużycia
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Dowiedz się, jak licencjonowanie metryczne Aspose.Slides dla Javy umożliwia elastyczne przetwarzanie plików PowerPoint i OpenDocument, płacąc tylko za to, co używasz."
---
## **Wprowadzenie**

Licencjonowanie metryczne jest mechanizmem licencjonowania, który może być używany równolegle z istniejącymi metodami licencjonowania. Jeśli chcesz być rozliczany na podstawie wykorzystania funkcji API Aspose.Slides, wybierasz licencjonowanie metryczne.

## **Zastosowanie kluczy metrycznych**

{{% alert color="primary" %}} 

Licencjonowanie metryczne jest nowym mechanizmem licencjonowania, który może być używany równolegle z istniejącymi metodami licencjonowania. Jeśli chcesz być rozliczany na podstawie wykorzystania funkcji API Aspose.Slides, wybierasz licencjonowanie metryczne.

Po zakupie licencji metrycznej otrzymujesz klucze (a nie plik licencji). Ten klucz metryczny można zastosować przy użyciu klasy [Metered](https://reference.aspose.com/slides/pl/java/com.aspose.slides/metered/) udostępnionej przez Aspose do operacji metrowania. Po więcej szczegółów zobacz [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Utwórz instancję klasy [Metered](https://reference.aspose.com/slides/pl/java/com.aspose.slides/metered/).

1. Przekaż swoje klucze publiczny i prywatny do metody [setMeteredKey](https://reference.aspose.com/slides/pl/java/com.aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-).

1. Wykonaj pewne przetwarzanie (wykonaj zadania).

1. Wywołaj metodę [getConsumptionQuantity](https://reference.aspose.com/slides/pl/java/com.aspose.slides/metered/#getConsumptionQuantity--) klasy `Metered`.

Powinieneś zobaczyć ilość/ilość żądań API, które zostały dotychczas zużyte.

Ten przykładowy kod pokazuje, jak używać licencjonowania metrycznego:

```java
// Tworzy instancję klasy Metered
com.aspose.slides.Metered metered = new com.aspose.slides.Metered();

try {
    // Przekazuje klucz publiczny i prywatny do obiektu Metered
    metered.setMeteredKey("<valid public key>", "<valid private key>");

    // Pobiera wartość zużytej ilości przed wywołaniami API
    double amountBefore = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed before: " + amountBefore);

    // Wykonaj coś przy użyciu API Aspose.Slides tutaj
    // ...

    // Pobiera wartość zużytej ilości po wywołaniach API
    double amountAfter = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed after: " + amountAfter);
} catch (Exception ex) {
    ex.printStackTrace();
}
```

{{% alert color="warning" title="NOTE"  %}} 

Aby korzystać z licencjonowania metrycznego, potrzebne jest stabilne połączenie internetowe, ponieważ mechanizm licencjonowania używa internetu do ciągłej interakcji z naszymi usługami i wykonywania obliczeń.

{{% /alert %}} 

## **FAQ**

**Czy mogę używać licencji metrycznej razem z regularną (wieczystą lub tymczasową) w tej samej aplikacji?**

Tak. Metryczne jest dodatkowym mechanizmem licencjonowania, który może być używany równolegle z istniejącymi [metodami licencjonowania](/slides/pl/java/licensing/). Decydujesz, którego mechanizmu użyć przy uruchamianiu aplikacji.

**Co dokładnie liczy się jako zużycie w licencji metrycznej: operacje czy pliki?**

Liczone jest wykorzystanie API, czyli liczba żądań lub operacji. Aktualne zużycie możesz uzyskać za pomocą [metod śledzenia zużycia](https://reference.aspose.com/slides/pl/java/com.aspose.slides/metered/).

**Czy licencja metryczna jest odpowiednia dla mikrousług i środowisk serverless, gdzie instancje często się restartują?**

Tak. Ponieważ rozliczanie odbywa się na poziomie wywołań API, scenariusze z częstymi zimnymi startami są kompatybilne, pod warunkiem stabilnego dostępu sieciowego do obliczeń metrycznych.

**Czy funkcjonalność biblioteki różni się przy użyciu licencji metrycznej w porównaniu do licencji wieczystej?**

Nie. To tylko mechanizm licencjonowania i rozliczania; możliwości produktu są takie same.

**Jak licencja metryczna odnosi się do wersji próbnej i licencji tymczasowej?**

Wersja próbna ma ograniczenia i znaki wodne, [licencja tymczasowa](https://purchase.aspose.com/temporary-license/) usuwa ograniczenia na 30 dni, a licencja metryczna usuwa ograniczenia i nalicza opłaty na podstawie rzeczywistego zużycia.

**Czy mogę kontrolować budżet, automatycznie reagując, gdy przekroczony zostanie próg zużycia?**

Tak. Powszechną praktyką jest okresowe odczytywanie bieżącego zużycia za pomocą [metod śledzenia](https://reference.aspose.com/slides/pl/java/com.aspose.slides/metered/) i wdrażanie własnych limitów lub alertów na poziomie aplikacji lub monitoringu.