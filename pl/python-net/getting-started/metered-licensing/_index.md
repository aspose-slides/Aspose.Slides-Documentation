---
title: Licencjonowanie rozliczane
type: docs
weight: 90
url: /pl/python-net/metered-licensing/
keywords:
- licencja
- licencja rozliczana
- klucze licencyjne
- klucz publiczny
- klucz prywatny
- ilość zużycia
- Python
- Aspose.Slides
description: "Dowiedz się, jak Aspose.Slides dla Pythona w środowisku .NET z licencjonowaniem rozliczanym umożliwia elastyczną obsługę plików PowerPoint i OpenDocument, płacąc tylko za to, co wykorzystujesz."
---
## **Wstęp**

Licencjonowanie rozliczane jest mechanizmem licencyjnym, który można stosować wraz z istniejącymi metodami licencjonowania. Jeśli chcesz być rozliczany na podstawie wykorzystania funkcji API Aspose.Slides, wybierasz licencjonowanie rozliczane.

## **Zastosowanie kluczy rozliczanych**

{{% alert color="primary" %}} 

Licencjonowanie rozliczane jest nowym mechanizmem licencyjnym, który można stosować wraz z istniejącymi metodami licencjonowania. Jeśli chcesz być rozliczany na podstawie wykorzystania funkcji API Aspose.Slides, wybierasz licencjonowanie rozliczane.

Po zakupie licencji rozliczanej otrzymujesz klucze (a nie plik licencji). Ten klucz rozliczany można zastosować przy użyciu klasy [Metered](https://reference.aspose.com/slides/pl/python-net/aspose.slides/metered/) udostępnionej przez Aspose do operacji rozliczeniowych. Aby uzyskać więcej informacji, zobacz [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Utwórz instancję klasy [Metered](https://reference.aspose.com/slides/pl/python-net/aspose.slides/metered/).
1. Przekaż swoje publiczne i prywatne klucze do metody [set_metered_key](https://reference.aspose.com/slides/pl/python-net/aspose.slides/metered/set_metered_key/#str-str).
1. Wykonaj przetwarzanie (wykonaj zadania).
1. Wywołaj metodę [get_consumption_quantity](https://reference.aspose.com/slides/pl/python-net/aspose.slides/metered/get_consumption_quantity/#) klasy `Metered`.

Powinieneś zobaczyć liczbę/ilość żądań API, które dotychczas zużyłeś.

Poniższy kod przykładu pokazuje, jak używać licencjonowania rozliczanego:

```python
import aspose.slides as slides

# Tworzy instancję klasy Metered
metered = slides.Metered()

# Przekazuje klucz publiczny i prywatny do obiektu Metered
metered.set_metered_key("<valid public key>", "<valid private key>")

# Pobiera wartość zużytej ilości przed wywołaniami API
amount_before = slides.Metered.get_consumption_quantity()
print("Amount consumed before:", amount_before)

# Zrób coś z API Aspose.Slides tutaj
# ...

# Pobiera wartość zużytej ilości po wywołaniach API
amount_after = slides.Metered.get_consumption_quantity()
print("Amount consumed after:", amount_after)
```

{{% alert color="warning" title="NOTE"  %}} 

Aby używać licencjonowania rozliczanego, potrzebne jest stabilne połączenie internetowe, ponieważ mechanizm licencyjny korzysta z internetu, aby stale komunikować się z naszymi usługami i wykonywać obliczenia.

{{% /alert %}} 

## **FAQ**

**Czy mogę używać licencji rozliczanej razem ze zwykłą (wieczystą lub tymczasową) w tej samej aplikacji?**

Tak. Licencjonowanie rozliczane jest dodatkowym mechanizmem licencyjnym, który można stosować wraz z istniejącymi [metodami licencjonowania](/slides/pl/python-net/licensing/). Wybierasz, który mechanizm zastosować przy uruchamianiu aplikacji.

**Co dokładnie jest liczane jako zużycie w ramach licencji rozliczanej: operacje czy pliki?**

Zużycie jest liczone jako wykorzystanie API, czyli liczba żądań lub operacji. Aktualne zużycie można uzyskać za pomocą [metod śledzenia zużycia](https://reference.aspose.com/slides/pl/python-net/aspose.slides/metered/).

**Czy licencjonowanie rozliczane jest odpowiednie dla mikroserwisów i środowisk serverless, w których instancje często się restartują?**

Tak. Ponieważ rozliczanie odbywa się na poziomie wywołań API, scenariusze z częstymi zimnymi startami są kompatybilne, pod warunkiem stabilnego dostępu sieciowego do obliczeń rozliczeniowych.

**Czy funkcjonalność biblioteki różni się przy użyciu licencji rozliczanej w porównaniu z licencją perpetualną?**

Nie. Dotyczy to wyłącznie mechanizmu licencjonowania i rozliczeń; możliwości produktu są takie same.

**Jak licencjonowanie rozliczane odnosi się do wersji próbnej i licencji tymczasowej?**

Wersja próbna ma ograniczenia i znaki wodne, [licencja tymczasowa](https://purchase.aspose.com/temporary-license/) usuwa ograniczenia na 30 dni, a licencjonowanie rozliczane usuwa ograniczenia i nalicza opłaty na podstawie rzeczywistego użycia.

**Czy mogę kontrolować budżet, automatycznie reagując, gdy przekroczony zostanie próg zużycia?**

Tak. Powszechną praktyką jest okresowe odczytywanie bieżącego zużycia za pomocą [metod śledzenia](https://reference.aspose.com/slides/pl/python-net/aspose.slides/metered/) i wdrażanie własnych limitów lub alertów na poziomie aplikacji lub monitoringu.