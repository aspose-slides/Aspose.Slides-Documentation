---
title: Licencjonowanie
type: docs
weight: 80
url: /pl/nodejs-java/licensing/
keywords:
- licencja
- tymczasowa licencja
- ustawianie licencji
- używanie licencji
- weryfikacja licencji
- plik licencji
- wersja ewaluacyjna
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Zastosuj, zarządzaj i rozwiąż problemy z licencjami w Aspose.Slides dla Node.js. Zapewnij nieprzerwane korzystanie z pełnych funkcji dzięki naszemu szczegółowemu przewodnikowi licencjonowania."
---
## **Wstęp**

Czasami, aby uzyskać najlepsze wyniki oceny, potrzebne może być praktyczne podejście. Z tego powodu Aspose.Slides oferuje różne plany zakupu oraz udostępnia bezpłatną wersję próbną i 30‑dniową tymczasową licencję do oceny.

{{% alert color="primary" %}}

Należy zauważyć, że istnieje wiele ogólnych zasad i praktyk, które wskazują, jak oceniać, prawidłowo licencjonować i kupować nasze produkty. Można je znaleźć w sekcji ["Polityki zakupu i FAQ"](https://purchase.aspose.com/policies).

{{% /alert %}}

## **Ocena Aspose.Slides**
Możesz łatwo pobrać Aspose.Slides do oceny. Pakiet oceny jest taki sam jak zakupiony pakiet. Wersja ewaluacyjna po prostu zostaje licencjonowana po dodaniu kilku linii kodu służących do zastosowania licencji. 

## **Ograniczenia wersji ewaluacyjnej**
Wersja ewaluacyjna Aspose.Slides (bez określonej licencji) zapewnia pełną funkcjonalność produktu, ale wstawia znak wodny oceny w górnej części dokumentu podczas otwierania i zapisywania. Dodatkowo, przy wyodrębnianiu tekstu z slajdów prezentacji jesteś ograniczony do jednego slajdu.

{{% alert color="primary" %}} 

Jeśli chcesz przetestować Aspose.Slides bez ograniczeń wersji ewaluacyjnej, możesz poprosić o **30‑dniową tymczasową licencję**. Więcej informacji znajdziesz w [Jak uzyskać tymczasową licencję?](https://purchase.aspose.com/temporary-license).

{{% /alert %}} 

## **O licencji**
Możesz łatwo pobrać wersję ewaluacyjną Aspose.Slides dla Node.js przy użyciu Java ze swojej [strony pobierania](https://releases.aspose.com/slides/pl/nodejs-java/). Wersja ewaluacyjna zapewnia absolutnie **te same możliwości** co licencjonowana wersja Aspose.Slides. Co więcej, wersja ewaluacyjna po prostu zostaje licencjonowana po zakupie licencji i dodaniu kilku linii kodu służących do jej zastosowania.

Licencja jest plikiem XML w formacie czystego tekstu, który zawiera szczegóły takie jak nazwa produktu, liczba programistów, do których jest licencjonowana, data wygaśnięcia subskrypcji i tak dalej. Plik jest cyfrowo podpisany, więc nie należy go modyfikować. Nawet przypadkowe dodanie dodatkowego znaku końca linii do zawartości pliku spowoduje jego unieważnienie.

Aby uniknąć ograniczeń związanych z wersją ewaluacyjną, musisz ustawić licencję przed użyciem **Aspose.Slides**. Licencję należy ustawić tylko raz na aplikację lub proces.

{{% alert color="primary" %}}

Możesz chcieć zobaczyć [Licencjonowanie rozliczane według zużycia](https://docs.aspose.com/slides/pl/nodejs-java/metered-licensing/).

{{% /alert %}} 

## **Licencja zakupiona**

Po zakupie musisz zastosować plik licencji lub strumień. 

{{% alert color="primary" %}}

Musisz ustawić licencję:
* tylko raz na domenę aplikacji
* przed użyciem jakichkolwiek innych klas Aspose.Slides

{{% /alert %}}

{{% alert color="primary" %}}

Możesz znaleźć informacje o cenach na stronie [„Informacje o cenach”](https://purchase.aspose.com/pricing/slides/pl/family).

{{% /alert %}}

### **Ustawianie licencji w Aspose.Slides dla Node.js poprzez Java**

Licencje mogą być zastosowane z następujących lokalizacji:

* Ścieżka jawna
* Strumień
* Jako licencja rozliczana według zużycia – nowy mechanizm licencjonowania

{{% alert color="primary" %}}

Użyj metody **setLicense**, aby licencjonować komponent.

Chociaż wielokrotne wywołania **setLicense** nie są szkodliwe, są marnotrawstwem zasobów (procesora).

{{% /alert %}}

{{% alert color="warning" %}}

Nowe licencje mogą aktywować Aspose.Slides tylko w wersji 21.4 lub nowszej. Wcześniejsze wersje używają innego systemu licencjonowania i nie rozpoznają tych licencji.

{{% /alert %}}

#### **Zastosowanie licencji za pomocą pliku**

Ten fragment kodu służy do ustawienia pliku licencji:

**Node.js**

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var license = new aspose.slides.License();
license.setLicense("Aspose.Slides.lic");
```

Podczas wywoływania metody setLicense, nazwa licencji powinna być taka sama jak nazwa Twojego pliku licencji. Na przykład możesz zmienić nazwę pliku licencji na "Aspose.Slides.lic.xml". Następnie w kodzie musisz przekazać nową nazwę licencji (Aspose.Slides.lic.xml) do metody setLicense.

#### **Zastosowanie licencji ze strumienia**

Ten fragment kodu służy do zastosowania licencji ze strumienia:

**Node.js**

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var license = new aspose.slides.License();

var fs = require("fs");

var readStream = fs.createReadStream("Aspose.Slides.lic");

license.setLicense(readStream, function(err, list) {
    if(err) { 
        console.error(err); return; 
    }});
```

## **FAQ**

**Czy mogę zastosować licencję w całkowicie offline środowisku (brak dostępu do internetu)?**

Tak. Walidacja licencji odbywa się lokalnie przy użyciu pliku licencji; połączenie z internetem nie jest wymagane.

**Co się stanie po wygaśnięciu rocznej subskrypcji? Czy biblioteka przestanie działać?**

Nie. Licencja jest wieczysta: możesz nadal używać wersji wydanych przed datą zakończenia subskrypcji; po prostu nie będziesz uprawniony do korzystania z nowszych wydań bez odnowienia.