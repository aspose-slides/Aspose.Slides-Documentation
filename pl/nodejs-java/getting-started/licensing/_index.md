---
title: Licencjonowanie
type: docs
weight: 80
url: /pl/nodejs-java/licensing/
keywords:
- licencja
- licencja tymczasowa
- ustaw licencję
- użyj licencji
- zweryfikuj licencję
- plik licencji
- wersja ewaluacyjna
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Zastosuj, zarządzaj i rozwiązuj problemy z licencjami w Aspose.Slides dla Node.js. Zapewnij nieprzerwany dostęp do pełnych funkcji dzięki naszemu przewodnikowi krok po kroku dotyczącym licencjonowania."
---
## **Wprowadzenie**

Czasami, aby uzyskać najlepsze wyniki oceny, potrzebne może być podejście praktyczne. Z tego powodu Aspose.Slides oferuje różne plany zakupu oraz udostępnia Bezpłatną wersję próbną i 30‑dniową Tymczasową Licencję do oceny.

{{% alert color="info" title="Note" %}}
Należy zauważyć, że istnieje szereg ogólnych zasad i praktyk, które wskazują, jak oceniać, prawidłowo licencjonować i kupować nasze produkty. Można je znaleźć w sekcji ["Purchase Policies and FAQ"](https://purchase.aspose.com/policies).
{{% /alert %}}

## **Ocena Aspose.Slides**
Możesz łatwo pobrać Aspose.Slides do oceny. Pakiet ewaluacyjny jest taki sam jak pakiet zakupiony. Wersja ewaluacyjna po prostu zostaje licencjonowana po dodaniu kilku linii kodu pozwalających zastosować licencję. 

## **Ograniczenia wersji ewaluacyjnej**
Wersja ewaluacyjna Aspose.Slides (bez określonej licencji) oferuje pełną funkcjonalność produktu, z dwoma ograniczeniami:

* Dodaje pole tekstowe z znakiem wodnym „evaluation” do każdego slajdu każdej prezentacji, którą zapisuje.  
* Tekst dłuższy niż pięć znaków, który Twój kod odczytuje z prezentacji, jest przycinany do pierwszych pięciu znaków, po których następuje `... text has been truncated due to evaluation version limitation.` Tekst o długości pięciu znaków lub mniej jest zwracany bez zmian, a tekst, który Twój kod zapisuje, jest zapisywany w całości.

{{% alert color="info" title="Note" %}}
Jeśli chcesz przetestować Aspose.Slides bez ograniczeń wersji ewaluacyjnej, możesz poprosić o **30‑dniową Tymczasową Licencję**. Więcej informacji znajdziesz w artykule [How to get a Temporary License?](https://purchase.aspose.com/temporary-license).
{{% /alert %}}

## **O licencji**
Możesz łatwo pobrać wersję ewaluacyjną Aspose.Slides dla Node.js poprzez Java ze swojej [strony pobierania](https://releases.aspose.com/slides/pl/nodejs-java/). Wersja ewaluacyjna ma te same funkcje co wersja licencjonowana, z opisanymi wyżej ograniczeniami. Ponadto wersja ewaluacyjna po prostu zostaje licencjonowana po zakupie licencji i dodaniu kilku linii kodu służących do zastosowania licencji.

Licencja jest zwykłym plikiem XML zawierającym informacje takie jak nazwa produktu, liczba programistów, którym jest licencjonowana, data wygaśnięcia subskrypcji i inne. Plik jest cyfrowo podpisany, dlatego nie należy go modyfikować. Nawet przypadkowe dodanie dodatkowego znaku nowej linii do zawartości pliku unieważni go.

Aby uniknąć ograniczeń związanych z wersją ewaluacyjną, musisz ustawić licencję przed użyciem **Aspose.Slides**. Licencję trzeba ustawić tylko raz na aplikację lub proces.

{{% alert color="info" title="Note" %}}
Możesz chcieć zobaczyć [Metered Licensing](/slides/pl/nodejs-java/metered-licensing/).
{{% /alert %}}

## **Licencja zakupiona**

Po zakupie musisz zastosować plik licencji lub strumień. 

{{% alert color="info" title="Note" %}}
Musisz ustawić licencję:
* tylko raz na proces
* przed użyciem jakichkolwiek innych klas Aspose.Slides
{{% /alert %}}

{{% alert color="info" title="Note" %}}
Informacje o cenach znajdziesz na stronie ["Pricing Information"](https://purchase.aspose.com/pricing/slides/pl/family).
{{% /alert %}}

### **Ustawianie licencji w Aspose.Slides dla Node.js przez Java**

Licencje można zastosować z następujących lokalizacji:

* Ścieżka jawna
* Strumień
* Jako licencja metrowana – nowy mechanizm licencjonowania

{{% alert color="info" title="Note" %}}
Użyj metody **setLicense**, aby licencjonować komponent.

Choć wielokrotne wywołania **setLicense** nie są szkodliwe, marnują zasoby (procesor).
{{% /alert %}}

#### **Zastosowanie licencji przy użyciu pliku**

Ten fragment kodu służy do ustawienia pliku licencji:

**Node.js**

```javascript
const asposeSlides = require("aspose.slides.via.java");

const license = new asposeSlides.License();
license.setLicense("Aspose.Slides.lic");
console.log("The license was applied.");

// Aspose.Slides działa w wirtualnej maszynie Java, która utrzymuje działanie Node.js, więc zakończ proces wyraźnie.
process.exit(0);
```

Podczas wywoływania metody setLicense, nazwa licencji powinna być taka sama jak nazwa Twojego pliku licencji. Na przykład możesz zmienić nazwę pliku licencji na "Aspose.Slides.lic.xml". Następnie w kodzie musisz przekazać nową nazwę licencji (Aspose.Slides.lic.xml) do metody setLicense. Jeśli plik jest nieobecny lub nie zawiera ważnej licencji, [setLicense](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/license/setlicense/) wyrzuca wyjątek, który kończy skrypt błędem.

#### **Zastosowanie licencji ze strumienia**

Aby zastosować licencję ze strumienia, przekaż obiekt [License](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/license/) oraz strumień do odczytu do statycznej metody [setLicenseFromStream](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/license/setlicense/). Strumień jest odczytywany asynchronicznie, a wywołanie zwrotne otrzymuje błąd, jeśli strumień nie zawiera ważnej licencji:

**Node.js**

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");

const license = new asposeSlides.License();
const readStream = fs.createReadStream("Aspose.Slides.lic");
asposeSlides.License.setLicenseFromStream(license, readStream, function (error) {
    if (error) {
        console.error("The license was not applied:", error.message);
    } else {
        console.log("The license was applied.");
    }

    // Aspose.Slides działa w wirtualnej maszynie Java, która utrzymuje działanie Node.js, więc zakończ proces wyraźnie.
    process.exit(0);
});
```

Licencja zostaje zastosowana po pełnym odczytaniu strumienia, zaraz przed uruchomieniem wywołania zwrotnego, więc rozpocznij dalszą pracę z Aspose.Slides w tym wywołaniu zwrotnym.

Oba przykłady wywołują `process.exit(0)` po zakończeniu, ponieważ wirtualna maszyna Javy uruchamiająca Aspose.Slides utrzymuje Node.js w działaniu. W aplikacji kontynuuj kod Aspose.Slides zamiast kończyć proces.

## **FAQ**

### Czy mogę zastosować licencję w całkowicie offline środowisku (brak dostępu do internetu)?

Tak. Walidacja licencji odbywa się lokalnie przy użyciu pliku licencji; połączenie z internetem nie jest wymagane.

### Co się dzieje po wygaśnięciu rocznej subskrypcji? Czy biblioteka przestanie działać?

Nie. Licencja jest wieczysta: możesz nadal używać wersji wydanych przed datą zakończenia subskrypcji; po prostu nie będziesz mógł korzystać z nowszych wydań bez odnowienia.