---
title: Licencjonowanie zliczeniowe
type: docs
weight: 100
url: /pl/nodejs-java/metered-licensing/
keywords:
- licencja
- licencja zliczeniowa
- klucze licencji
- klucz publiczny
- klucz prywatny
- ilość zużycia
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Dowiedz się, jak Aspose.Slides dla Node.js przy użyciu licencjonowania zliczeniowego w Javie umożliwia elastyczne przetwarzanie plików PowerPoint i OpenDocument, płacąc tylko za to, co używasz."
---
## **Wprowadzenie**

Licencjonowanie zliczeniowe jest mechanizmem licencjonowania, który można stosować obok istniejących metod licencjonowania. Jeśli chcesz płacić za korzystanie z funkcji API Aspose.Slides, wybierasz licencjonowanie zliczeniowe.

## **Zastosowanie kluczy zliczeniowych**

Kiedy kupujesz licencję zliczeniową, otrzymujesz klucze (a nie plik licencji). Ten klucz zliczeniowy można zastosować przy użyciu klasy [Metered](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/metered/) udostępnionej przez Aspose do operacji zliczeniowych. Po więcej szczegółów zobacz [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

1. Utwórz instancję klasy [Metered](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/metered/).

1. Przekaż swoje klucze publiczny i prywatny do metody [setMeteredKey](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/metered/#setMeteredKey).

1. Wykonaj przetwarzanie (wykonaj zadania).

1. Wywołaj metodę [getConsumptionQuantity](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/metered/#getConsumptionQuantity) klasy `Metered`.

Powinieneś zobaczyć ilość/ilość żądań API, które dotychczas zużyłeś.

Ten przykładowy kod pokazuje, jak używać licencjonowania zliczeniowego:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Tworzy instancję klasy Metered
var metered = new aspose.slides.Metered();

// Przekazuje klucz publiczny i prywatny do obiektu Metered
metered.setMeteredKey("<valid public key>", "<valid private key>");

// Pobiera wartość zużytej ilości przed wywołaniami API
var amountBefore = aspose.slides.Metered.getConsumptionQuantity();
console.log("Amount consumed before:", amountBefore);

// Zrób coś z API Aspose.Slides tutaj
// ...

// Pobiera wartość zużytej ilości po wywołaniach API
var amountAfter = aspose.slides.Metered.getConsumptionQuantity();
console.log("Amount consumed after:", amountAfter);
```

{{% alert color="warning" title="NOTE"  %}} 
Aby używać licencjonowania zliczeniowego, potrzebujesz stabilnego połączenia internetowego, ponieważ mechanizm licencjonowania korzysta z internetu do ciągłej interakcji z naszymi usługami i wykonywania obliczeń.
{{% /alert %}} 

## **FAQ**

**Czy mogę używać licencji zliczeniowej razem z licencją zwykłą (wieczystą lub tymczasową) w tej samej aplikacji?**

Tak. Zliczeniowe to dodatkowy mechanizm licencjonowania, który można stosować obok istniejących [metod licencjonowania](/slides/pl/nodejs-java/licensing/). Decydujesz, którego mechanizmu użyć przy uruchamianiu aplikacji.

**Co dokładnie liczy się jako zużycie w licencji zliczeniowej: operacje czy pliki?**

Liczone jest użycie API, czyli liczba żądań lub operacji. Aktualne zużycie możesz uzyskać za pomocą [metod śledzenia zużycia](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/metered/).

**Czy licencja zliczeniowa jest odpowiednia dla mikroserwisów i środowisk serverless, gdzie instancje często się restartują?**

Tak. Ponieważ rozliczenia odbywają się na poziomie wywołań API, scenariusze z częstymi zimnymi startami są zgodne, pod warunkiem stabilnego dostępu sieciowego do obliczeń zliczeniowych.

**Czy funkcjonalność biblioteki różni się przy użyciu licencji zliczeniowej w porównaniu z licencją wieczystą?**

Nie. To tylko kwestia mechanizmu licencjonowania i rozliczeń; możliwości produktu pozostają takie same.

**Jak licencja zliczeniowa odnosi się do wersji próbnej i licencji tymczasowej?**

Wersja próbna ma ograniczenia i znak wodny, [licencja tymczasowa](https://purchase.aspose.com/temporary-license/) usuwa ograniczenia na 30 dni, a licencja zliczeniowa usuwa ograniczenia i nalicza opłaty na podstawie rzeczywistego użycia.

**Czy mogę kontrolować budżet, automatycznie reagując, gdy przekroczony zostanie próg zużycia?**

Tak. Popularną praktyką jest okresowe odczytywanie aktualnego zużycia za pomocą [metod śledzenia](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/metered/) i implementowanie własnych limitów lub alertów na poziomie aplikacji lub monitoringu.