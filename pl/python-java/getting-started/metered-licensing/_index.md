---
title: Licencjonowanie taryfowe
type: docs
weight: 100
url: /pl/python-java/metered-licensing/
keywords:
- licencja
- licencja taryfowa
- klucze licencyjne
- klucz publiczny
- klucz prywatny
- ilość zużycia
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Dowiedz się, jak licencjonowanie taryfowe Aspose.Slides dla Pythona poprzez Java umożliwia elastyczne przetwarzanie plików PowerPoint i OpenDocument, płacąc tylko za to, czego używasz."
---
## **Wprowadzenie**

Licencjonowanie taryfowe to mechanizm licencjonowania, który może być używany razem z istniejącymi metodami licencjonowania. Jeśli chcesz być rozliczany na podstawie wykorzystania funkcji API Aspose.Slides, wybierz licencjonowanie taryfowe.

## **Zastosowanie kluczy taryfowych**

{{% alert color="info" title="Uwaga" %}}
Licencjonowanie taryfowe jest nowym mechanizmem licencjonowania, który może być używany razem z istniejącymi metodami licencjonowania. Jeśli chcesz być rozliczany na podstawie wykorzystania funkcji API Aspose.Slides, wybierz licencjonowanie taryfowe.

Kupując licencję taryfową, otrzymujesz klucze (a nie plik licencyjny). Ten klucz taryfowy można zastosować przy użyciu klasy [Metered](https://reference.aspose.com/slides/pl/python-java/aspose.slides/metered/) udostępnionej przez Aspose do operacji taryfowych. Aby uzyskać więcej informacji, zobacz [FAQ o licencjonowaniu taryfowym](https://purchase.aspose.com/faqs/licensing/metered).
{{% /alert %}}

1. Utwórz instancję klasy [Metered](https://reference.aspose.com/slides/pl/python-java/aspose.slides/metered/).

2. Przekaż swoje klucze publiczny i prywatny do metody [setMeteredKey](https://reference.aspose.com/slides/pl/python-java/aspose.slides/metered/#setMeteredKey).

3. Wykonaj pewne przetwarzanie (wykonaj zadania).

4. Wywołaj metodę [getConsumptionQuantity](https://reference.aspose.com/slides/pl/python-java/aspose.slides/metered/#getConsumptionQuantity) klasy [Metered](https://reference.aspose.com/slides/pl/python-java/aspose.slides/metered/).

Powinieneś zobaczyć ilość/zliczenie żądań API, które dotychczas zużyłeś.

Ten przykładowy kod pokazuje, jak używać licencjonowania taryfowego:

```python
import jpype
import asposeslides

if not jpway.isJVMStarted():
    jpway.startJVM()

from asposeslides.api import Metered

# Utwórz instancję klasy Metered.
metered = Metered()

try:
    # Przekaż klucz publiczny i prywatny do obiektu Metered.
    metered.setMeteredKey("<valid public key>", "<valid private key>")

    # Pobierz zużytą ilość przed wywołaniami API.
    amount_before = Metered.getConsumptionQuantity()
    print("Amount consumed before:", amount_before)

    # Wykonaj tutaj jakąś operację przy użyciu API Aspose.Slides.
    # ...

    # Pobierz zużytą ilość po wywołaniach API.
    amount_after = Metered.getConsumptionQuantity()
    print("Amount consumed after:", amount_after)
except Exception as error:
    print(error)
```

{{% alert color="warning" title="Ostrzeżenie"  %}}
Aby używać licencjonowania taryfowego, potrzebne jest stabilne połączenie internetowe, ponieważ mechanizm licencjonowania korzysta z internetu, aby stale komunikować się z naszymi usługami i wykonywać obliczenia.
{{% /alert %}}

## **FAQ**

**Czy mogę używać licencji taryfowej razem ze zwykłą licencją (wieczystą lub tymczasową) w tej samej aplikacji?**

Tak. Licencjonowanie taryfowe jest dodatkowym mechanizmem, który może być używany razem z istniejącymi [metodami licencjonowania](/slides/pl/python-java/licensing/). Wybierasz, który mechanizm zastosować przy uruchamianiu aplikacji.

**Co dokładnie liczy się jako zużycie w ramach licencji taryfowej: operacje czy pliki?**

Liczone jest użycie API, czyli liczba żądań lub operacji. Aktualne zużycie można uzyskać za pomocą [metod śledzenia zużycia](https://reference.aspose.com/slides/pl/python-java/aspose.slides/metered/).

**Czy licencjonowanie taryfowe jest odpowiednie dla mikroserwisów i środowisk serverless, w których instancje często się restartują?**

Tak. Ponieważ rozliczenia odbywają się na poziomie wywołań API, scenariusze z częstymi zimnymi uruchomieniami są kompatybilne, pod warunkiem stabilnego dostępu sieciowego do obliczeń taryfowych.

**Czy funkcjonalność biblioteki różni się przy użyciu licencji taryfowej w porównaniu do licencji wieczystej?**

Nie. Dotyczy to wyłącznie mechanizmu licencjonowania i rozliczeń; możliwości produktu pozostają niezmienione.

**Jak licencjonowanie taryfowe odnosi się do wersji próbnej i licencji tymczasowej?**

Wersja próbna ma ograniczenia i znaki wodne, [licencja tymczasowa](https://purchase.aspose.com/temporary-license/) usuwa ograniczenia na 30 dni, a licencja taryfowa usuwa ograniczenia i nalicza opłaty na podstawie rzeczywistego zużycia.

**Czy mogę kontrolować budżet, automatycznie reagując, gdy przekroczony zostanie próg zużycia?**

Tak. Częstą praktyką jest okresowe odczytywanie bieżącego zużycia za pomocą [metod śledzenia](https://reference.aspose.com/slides/pl/python-java/aspose.slides/metered/) i wdrażanie własnych limitów lub alertów na poziomie aplikacji lub monitoringu.