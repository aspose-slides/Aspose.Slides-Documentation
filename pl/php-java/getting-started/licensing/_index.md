---
title: Licencjonowanie
type: docs
weight: 80
url: /pl/php-java/licensing/
keywords:
- licencja
- licencja tymczasowa
- ustaw licencję
- używanie licencji
- walidacja licencji
- plik licencji
- wersja ewaluacyjna
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Zastosuj, zarządzaj i rozwiąż problemy z licencjami w Aspose.Slides dla PHP poprzez Java. Zapewnij nieprzerwany dostęp do pełnych funkcji dzięki naszemu przewodnikowi krok po kroku dotyczącym licencjonowania."
---
## **Wprowadzenie**

Czasami, aby uzyskać najlepsze wyniki oceny, potrzebne może być praktyczne podejście. Z tego powodu Aspose.Slides oferuje różne plany zakupu oraz udostępnia Bezpłatną wersję próbną i 30‑dniową tymczasową licencję do oceny.

{{% alert color="primary" %}}

Należy zauważyć, że istnieje szereg ogólnych zasad i praktyk, które wskazują, jak oceniać, prawidłowo licencjonować i kupować nasze produkty. Można je znaleźć w sekcji ["Polityki zakupu i FAQ"](https://purchase.aspose.com/policies).

{{% /alert %}}

## **Ocena Aspose.Slides**

Możesz łatwo pobrać Aspose.Slides do oceny. Pakiet oceny jest taki sam jak pakiet zakupiony. Wersja ewaluacyjna po prostu staje się licencjonowana po dodaniu kilku linii kodu, które zastosują licencję. 

## **Ograniczenia wersji ewaluacyjnej**

Wersja ewaluacyjna Aspose.Slides (bez określonej licencji) zapewnia pełną funkcjonalność produktu, ale wstawia znak wodny oceny u góry dokumentu przy otwieraniu i zapisywaniu. Dodatkowo jesteś ograniczony do jednego slajdu przy wyodrębnianiu tekstu z prezentacji.

{{% alert color="primary" %}} 

Jeśli chcesz przetestować Aspose.Slides bez ograniczeń wersji ewaluacyjnej, możesz poprosić o **30‑dniową tymczasową licencję**. Więcej informacji znajdziesz w [Jak uzyskać tymczasową licencję?](https://purchase.aspose.com/temporary-license).

{{% /alert %}} 

## **O licencji**

Możesz łatwo pobrać wersję ewaluacyjną Aspose.Slides dla PHP poprzez Java ze swojej [strony pobierania](https://packagist.org/packages/aspose/slides). Wersja ewaluacyjna zapewnia absolutnie **takie same możliwości** jak licencjonowana wersja Aspose.Slides. Co więcej, wersja ewaluacyjna po prostu staje się licencjonowana po zakupie licencji i dodaniu kilku linii kodu, które zastosują licencję.

Licencja jest zwykłym plikiem XML zawierającym takie szczegóły jak nazwa produktu, liczba programistów, do których jest licencjonowana, data wygaśnięcia subskrypcji i inne. Plik jest cyfrowo podpisany, więc nie należy go modyfikować. Nawet przypadkowe dodanie dodatkowego znaku końca linii do zawartości pliku spowoduje jego unieważnienie.

Aby uniknąć ograniczeń związanych z wersją ewaluacyjną, musisz ustawić licencję przed użyciem **Aspose.Slides**. Licencję należy ustawić tylko raz na aplikację lub proces.

{{% alert color="primary" %}} 

Możesz chcieć zobaczyć [Licencjonowanie metryczne](https://docs.aspose.com/slides/pl/php-java/metered-licensing/).

{{% /alert %}} 

## **Licencja zakupiona**

Po zakupie musisz zastosować plik licencji lub strumień. 

{{% alert color="primary" %}}

Musisz ustawić licencję:
* tylko raz na domenę aplikacji
* przed użyciem jakichkolwiek innych klas Aspose.Slides

{{% /alert %}}

{{% alert color="primary" %}}

Informacje o cenach znajdziesz na stronie [„Informacje o cenach”](https://purchase.aspose.com/pricing/slides/pl/family).

{{% /alert %}}

### **Ustaw licencję w Aspose.Slides dla PHP poprzez Java**

Licencje można zastosować z następujących miejsc:

* Ścieżka jawna
* Strumień
* Jako licencja metryczna – nowy mechanizm licencjonowania

{{% alert color="primary" %}}

Użyj metody **setLicense**, aby licencjonować komponent.

Chociaż wiele wywołań **setLicense** nie szkodzi, stanowią one marnotrawstwo zasobów (procesora).

{{% /alert %}}

{{% alert color="warning" %}}

Nowe licencje mogą aktywować Aspose.Slides tylko w wersji 21.4 lub późniejszej. Wcześniejsze wersje używają innego systemu licencjonowania i nie rozpoznają tych licencji.

{{% /alert %}}

#### **Zastosowanie licencji przy użyciu pliku**

Ten fragment kodu służy do ustawienia pliku licencji:

**PHP**

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\License;

$license = new License();
$license->setLicense("Aspose.Slides.lic");
?>
```

Podczas wywoływania metody setLicense nazwa licencji powinna być taka sama jak nazwa pliku licencji. Na przykład możesz zmienić nazwę pliku licencji na „Aspose.Slides.lic.xml”. Następnie w kodzie musisz przekazać nową nazwę licencji (Aspose.Slides.lic.xml) do metody setLicense.

#### **Zastosowanie licencji ze strumienia**

Ten fragment kodu służy do zastosowania licencji ze strumienia:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\License;

$license = new License();
$license->setLicense($stream);
?>
```

## **FAQ**

**Czy mogę zastosować licencję w całkowicie offline środowisku (brak dostępu do internetu)?**

Tak. Walidacja licencji odbywa się lokalnie przy użyciu pliku licencji; połączenie z internetem nie jest wymagane.

**Co się stanie po wygaśnięciu rocznej subskrypcji? Czy biblioteka przestanie działać?**

Nie. Licencja jest wieczysta: możesz nadal używać wersji wydanych przed datą zakończenia subskrypcji; po prostu nie będziesz mógł korzystać z nowszych wydań bez odnowienia.