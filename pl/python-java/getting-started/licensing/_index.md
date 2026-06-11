---
title: Licencjonowanie
description: "Aspose.Slides for Python via Java oferuje różne plany zakupu lub udostępnia bezpłatną wersję próbną i 30-dniową tymczasową licencję do oceny, korzystając z zasad licencjonowania i subskrypcji."
type: docs
weight: 80
url: /pl/python-java/licensing/
---
Czasami, aby uzyskać najlepsze wyniki oceny, potrzebne może być podejście praktyczne. Z tego powodu Aspose.Slides oferuje różne plany zakupu oraz udostępnia bezpłatną wersję próbną i 30‑dniową tymczasową licencję do oceny.

{{% alert color="primary" %}}
Należy zauważyć, że istnieje szereg ogólnych zasad i praktyk, które wskazują, jak oceniać, prawidłowo licencjonować i kupować nasze produkty. Można je znaleźć w sekcji [Polityki zakupu i FAQ](https://purchase.aspose.com/policies).
{{% /alert %}}

## **Ocena Aspose.Slides**
Można łatwo pobrać Aspose.Slides do oceny. Pakiet ewaluacyjny jest taki sam jak zakupiony pakiet. Wersja ewaluacyjna po prostu zostaje licencjonowana po dodaniu kilku linii kodu, które zastosują licencję. 

## **Ograniczenia wersji ewaluacyjnej**
Wersja ewaluacyjna Aspose.Slides (bez określonej licencji) zapewnia pełną funkcjonalność produktu, ale wstawia znak wodny ewaluacji u góry dokumentu podczas otwierania i zapisywania. Dodatkowo przy wyodrębnianiu tekstu ze slajdów prezentacji jesteś ograniczony do jednego slajdu.

{{% alert color="primary" %}} 
Jeśli chcesz przetestować Aspose.Slides bez ograniczeń wersji ewaluacyjnej, możesz poprosić o **30‑dniową tymczasową licencję**. Więcej informacji znajdziesz w [Jak uzyskać tymczasową licencję?](https://purchase.aspose.com/temporary-license).
{{% /alert %}} 

## **O licencji**
Można łatwo pobrać wersję ewaluacyjną Aspose.Slides for Python via Java z jego [strony pobierania](https://releases.aspose.com/slides/pl/python-java/). Wersja ewaluacyjna oferuje absolutnie **te same możliwości** co licencjonowana wersja Aspose.Slides. Co więcej, wersja ewaluacyjna po prostu zostaje licencjonowana po zakupie licencji i dodaniu kilku linii kodu, które zastosują licencję.

Licencja jest plikiem XML w formacie zwykłego tekstu, który zawiera informacje takie jak nazwa produktu, liczba programistów, dla których jest licencjonowana, data wygaśnięcia subskrypcji i inne. Plik jest cyfrowo podpisany, więc nie należy go modyfikować. Nawet przypadkowe dodanie dodatkowego znaku nowej linii do zawartości pliku spowoduje, że stanie się nieważny.

Aby uniknąć ograniczeń związanych z wersją ewaluacyjną, należy ustawić licencję przed użyciem **Aspose.Slides**. Licencję trzeba ustawić tylko raz na aplikację lub proces.

## Licencja zakupiona
Po zakupie należy zastosować plik licencji lub strumień. 

{{% alert color="primary" %}}
Musisz ustawić licencję:
* tylko raz na domenę aplikacji
* przed użyciem jakichkolwiek innych klas Aspose.Slides
{{% /alert %}}

{{% alert color="primary" %}}
Informacje o cenach można znaleźć na stronie [Informacje o cenach](https://purchase.aspose.com/pricing/slides/pl/family).
{{% /alert %}}

### **Ustawianie licencji w Aspose.Slides for Python via Java**
Licencje można zastosować z następujących miejsc:

* Ścieżka jawna
* Strumień
* Jako licencja metrowana – nowy mechanizm licencjonowania

{{% alert color="primary" %}}
Użyj metody **setLicense**, aby licencjonować komponent.

Choć wielokrotne wywołania **setLicense** nie są szkodliwe, marnują zasoby (procesor).
{{% /alert %}}

{{% alert color="warning" %}}
Nowe licencje mogą aktywować Aspose.Slides tylko w wersji 21.4 lub nowszej. Starsze wersje używają innego systemu licencjonowania i nie rozpoznają tych licencji.
{{% /alert %}}

#### **Zastosowanie licencji przy użyciu pliku**
Ten fragment kodu służy do ustawienia pliku licencji:

**Python**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, License

license = License();
pres = Presentation()
license.setLicense("Aspose.Slides.lic");

jpype.shutdownJVM()
```

Podczas wywoływania metody setLicense nazwa licencji powinna być taka sama jak nazwa pliku licencji. Na przykład możesz zmienić nazwę pliku licencji na "Aspose.Slides.lic.xml". Następnie w kodzie musisz przekazać nową nazwę licencji (Aspose.Slides.lic.xml) do metody setLicense.

#### **Zastosowanie licencji z bajtów**
Ten fragment kodu służy do zastosowania licencji z bajtów:

**Python**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, License

license = License();
input = open("Aspose.Slides.lic", mode="rb")
data = input.read()
pres = Presentation()
license.setLicenseFromBytes(data);

jpype.shutdownJVM()
```

#### Zastosowanie licencji metrowanej
Aspose.Slides umożliwia programistom zastosowanie klucza metrowanego. Jest to nowy mechanizm licencjonowania.

Nowy mechanizm licencjonowania będzie używany wraz z istniejącą metodą licencjonowania. Klienci, którzy chcą być rozliczani na podstawie użycia funkcji API, mogą korzystać z licencjonowania metrowanego.

Po zakończeniu wszystkich niezbędnych kroków uzyskania tego typu licencji otrzymasz klucze, a nie plik licencji. Ten klucz metrowany można zastosować przy użyciu klasy **Metered**, specjalnie wprowadzonej w tym celu.

Poniższy przykład kodu pokazuje, jak ustawić publiczny i prywatny klucz metrowany:

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, Metered, SaveFormat

# Utwórz instancję klasy CAD Metered
metered = Metered();

# Uzyskaj dostęp do właściwości set_metered_key i przekaż klucze publiczny i prywatny jako parametry
metered.setMeteredKey("*****", "*****");

# Pobierz ilość danych metrowanych przed wywołaniem API
amountbefore = Metered.getConsumptionQuantity()

# Wyświetl informacje
print("Amount Consumed Before: \" + amountbefore + \"" )

# Załaduj dokument z dysku.
pres = Presentation();

# Pobierz liczbę stron w dokumencie
print("Amount Consumed After: \" +  pres.getSlides().size()) + \"" )

# zapisz jako PDF
pres.save("out_pdf.pdf", SaveFormat.Pdf);

# Pobierz ilość danych metrowanych po wywołaniu API
amountafter = Metered.getConsumptionQuantity()

# Wyświetl informacje
print("Amount Consumed After: \" + amountafter + \"" )

jpype.shutdownJVM()
```

{{% alert color="primary" %}}
Należy pamiętać, że do prawidłowego użycia licencji metrowanej wymagane jest stabilne połączenie internetowe, ponieważ mechanizm metrowany wymaga stałej interakcji z naszymi usługami w celu prawidłowych obliczeń. Aby uzyskać więcej szczegółów, zapoznaj się z sekcją [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).
{{% /alert %}}