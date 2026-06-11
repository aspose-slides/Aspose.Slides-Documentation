---
title: Licencjonowanie rozliczeniowe
type: docs
weight: 100
url: /pl/php-java/metered-licensing/
keywords:
- licencja
- licencja rozliczeniowa
- klucze licencyjne
- klucz publiczny
- klucz prywatny
- ilość zużycia
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Dowiedz się, jak Aspose.Slides dla PHP via Java z licencjonowaniem rozliczeniowym umożliwia elastyczne przetwarzanie plików PowerPoint i OpenDocument, płacąc tylko za to, co używasz."
---
## **Wprowadzenie**

Licencjonowanie na zasadzie zużycia (metered licensing) jest mechanizmem licencjonowania, który można stosować razem z istniejącymi metodami licencjonowania. Jeśli chcesz być rozliczany na podstawie używania funkcji API Aspose.Slides, wybierasz licencjonowanie na zasadzie zużycia.

## **Zastosowanie kluczy metered**

Kiedy kupujesz licencję rozliczeniową, otrzymujesz klucze (a nie plik licencji). Ten klucz rozliczeniowy można zastosować przy użyciu klasy [Metered](https://reference.aspose.com/slides/pl/php-java/aspose.slides/metered/) udostępnionej przez Aspose do operacji rozliczeniowych. Po więcej szczegółów zobacz [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

1. Utwórz instancję klasy [Metered](https://reference.aspose.com/slides/pl/php-java/aspose.slides/metered/).

1. Przekaż swoje klucze publiczny i prywatny do metody [setMeteredKey](https://reference.aspose.com/slides/pl/php-java/aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-).

1. Wykonaj pewne przetwarzanie (wykonaj zadania).

1. Wywołaj metodę [getConsumptionQuantity](https://reference.aspose.com/slides/pl/php-java/aspose.slides/metered/#getConsumptionQuantity--) klasy `Metered`.

Powinieneś zobaczyć liczbę żądań API, które zużyłeś do tej pory.

Ten przykładowy kod pokazuje, jak używać licencjonowania rozliczeniowego:

```php
// Tworzy instancję klasy Metered
$metered = new Metered();

try {
    // Przekazuje klucz publiczny i prywatny do obiektu Metered
    $metered->setMeteredKey("<valid pablic key>", "<valid private key>");

    // Pobiera wartość zużytej ilości przed wywołaniami API
    $amountBefore = Metered::getConsumptionQuantity();
    echo("Amount consumed before: " . $amountBefore);

    // Zrób coś z API Aspose.Slides tutaj
    // ...

    // Pobiera wartość zużytej ilości po wywołaniach API
    $amountAfter = Metered::getConsumptionQuantity();
    echo("Amount consumed after: " . $amountAfter);
} catch (JavaException $ex) {
  $ex->printStackTrace();
}
```

{{% alert color="warning" title="NOTE"  %}} 
Aby używać licencjonowania rozliczeniowego, potrzebne jest stabilne połączenie internetowe, ponieważ mechanizm licencjonowania korzysta z internetu do ciągłej interakcji z naszymi usługami i wykonywania obliczeń.
{{% /alert %}} 

## **FAQ**

**Czy mogę używać licencji rozliczeniowej razem z regularną (wieczystą lub tymczasową) w tej samej aplikacji?**

Tak. Licencjonowanie rozliczeniowe jest dodatkowym mechanizmem licencjonowania, który można stosować razem z istniejącymi [metody licencjonowania](/slides/pl/php-java/licensing/). Wybierasz, który mechanizm zastosować przy uruchamianiu aplikacji.

**Co dokładnie liczy się jako zużycie w licencji rozliczeniowej: operacje czy pliki?**

Liczone jest użycie API, czyli liczba żądań lub operacji. Aktualne zużycie można uzyskać za pomocą [metody śledzenia zużycia](https://reference.aspose.com/slides/pl/php-java/aspose.slides/metered/).

**Czy licencjonowanie rozliczeniowe jest odpowiednie dla mikroserwisów i środowisk serverless, w których instancje często się restartują?**

Tak. Ponieważ rozliczenia odbywają się na poziomie wywołań API, scenariusze z częstymi zimnymi startami są kompatybilne, pod warunkiem, że istnieje stabilny dostęp sieciowy do obliczeń rozliczeniowych.

**Czy funkcjonalność biblioteki różni się przy użyciu licencji rozliczeniowej w porównaniu do licencji wieczystej?**

Nie. To dotyczy wyłącznie mechanizmu licencjonowania i rozliczeń; możliwości produktu są takie same.

**Jak licencjonowanie rozliczeniowe odnosi się do wersji próbnej i licencji tymczasowej?**

Wersja próbna ma ograniczenia i znaki wodne, [licencja tymczasowa](https://purchase.aspose.com/temporary-license/) usuwa ograniczenia na 30 dni, a licencjonowanie rozliczeniowe usuwa ograniczenia i nalicza opłaty w oparciu o rzeczywiste użycie.

**Czy mogę kontrolować budżet, automatycznie reagując, gdy przekroczony zostanie próg zużycia?**

Tak. Powszechną praktyką jest okresowe odczytywanie bieżącego zużycia za pomocą [metod śledzenia](https://reference.aspose.com/slides/pl/php-java/aspose.slides/metered/) i wdrażanie własnych limitów lub alertów na poziomie aplikacji lub monitoringu.