---
title: Licencjonowanie
type: docs
weight: 80
url: /pl/php-java/licensing/
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
- PHP
- Aspose.Slides
description: "Zastosuj, zarządzaj i rozwiąż problemy z licencjami w Aspose.Slides dla PHP via Java. Zapewnij nieprzerwany dostęp do pełnych funkcji dzięki naszemu przewodnikowi po licencjonowaniu krok po kroku."
---
## **Wprowadzenie**

Czasami, aby uzyskać najlepsze wyniki oceny, potrzebne może być praktyczne podejście. Z tego powodu Aspose.Slides oferuje różne plany zakupu oraz bezpłatną wersję próbną i 30‑dniową licencję tymczasową do oceny.

{{% alert color="info" title="Note" %}}
Należy pamiętać, że istnieje szereg ogólnych polityk i praktyk, które wskazują, jak oceniać, prawidłowo licencjonować i kupować nasze produkty. Znajdziesz je w sekcji [Polityki zakupu i FAQ](https://purchase.aspose.com/policies).
{{% /alert %}}

## **Ocena Aspose.Slides**
Możesz łatwo pobrać Aspose.Slides do oceny. Pakiet ewaluacyjny jest identyczny z pakietem zakupionym. Wersja ewaluacyjna po prostu staje się licencjonowana po dodaniu kilku wierszy kodu, które zastosują licencję.

## **Ograniczenia wersji ewaluacyjnej**
Wersja ewaluacyjna Aspose.Slides (bez określonej licencji) zapewnia pełną funkcjonalność produktu, z dwoma ograniczeniami:

* Dodaje pole tekstowe z wodnym znakiem oceny w środkowej części każdego slajdu każdej prezentacji, którą zapisuje.
* Tekst, który Twój kod odczytuje z prezentacji, jest przycinany do kilku pierwszych znaków, po których pojawia się informacja o ograniczeniu wersji ewaluacyjnej. Tekst zapisany przez Twój kod jest zapisywany w całości.

{{% alert color="info" title="Note" %}}
Jeśli chcesz przetestować Aspose.Slides bez ograniczeń wersji ewaluacyjnej, możesz poprosić o **30‑dniową licencję tymczasową**. Więcej informacji znajdziesz w [Jak uzyskać licencję tymczasową?](https://purchase.aspose.com/temporary-license).
{{% /alert %}} 

## **O licencji**
Możesz łatwo pobrać wersję ewaluacyjną Aspose.Slides dla PHP via Java ze swojej [strony pobierania](https://packagist.org/packages/aspose/slides). Wersja ewaluacyjna zapewnia absolutnie **te same możliwości** co licencjonowana wersja Aspose.Slides. Ponadto wersja ewaluacyjna po prostu staje się licencjonowana po zakupie licencji i dodaniu kilku wierszy kodu, które zastosują licencję.

Licencja jest plikiem XML w formacie zwykłego tekstu, który zawiera szczegóły takie jak nazwa produktu, liczba deweloperów, dla których jest licencjonowana, data wygaśnięcia subskrypcji i inne. Plik jest cyfrowo podpisany, więc nie należy go modyfikować. Nawet przypadkowe dodanie dodatkowego znaku końca linii do zawartości pliku unieważni go.

Aby uniknąć ograniczeń związanych z wersją ewaluacyjną, musisz ustawić licencję przed użyciem **Aspose.Slides**. Licencję należy ustawić tylko raz na aplikację lub proces.

{{% alert color="info" title="Note" %}}
Możesz chcieć zobaczyć [Licencjonowanie rozliczane](/slides/pl/php-java/metered-licensing/).
{{% /alert %}} 

## **Licencja zakupiona**
Po zakupie musisz zastosować plik licencji lub strumień.

{{% alert color="info" title="Note" %}}
Musisz ustawić licencję:
* tylko raz na domenę aplikacji
* przed użyciem jakichkolwiek innych klas Aspose.Slides
{{% /alert %}}

{{% alert color="info" title="Note" %}}
Informacje o cenach znajdziesz na stronie [„Informacje o cenach”](https://purchase.aspose.com/pricing/slides/family).
{{% /alert %}}

### **Ustawienie licencji w Aspose.Slides dla PHP via Java**
Licencje mogą być stosowane z następujących lokalizacji:

* Ścieżka jawna
* Strumień
* Jako licencja rozliczana – nowy mechanizm licencjonowania

{{% alert color="info" title="Note" %}}
Użyj metody **setLicense**, aby licencjonować komponent.

Choć wielokrotne wywołania **setLicense** nie są szkodliwe, są marnotrawstwem zasobów (procesora).
{{% /alert %}}

{{% alert color="warning" title="Warning" %}}
Nowe licencje mogą aktywować Aspose.Slides tylko w wersji 21.4 lub nowszej. Wcześniejsze wersje używają innego systemu licencjonowania i nie rozpoznają tych licencji.
{{% /alert %}}

#### **Zastosowanie licencji przy użyciu pliku**
Ten fragment kodu służy do ustawienia pliku licencji:

**PHP**

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/pl/lib/aspose.slides.php");

use aspose\slides\License;

$license = new License();
$license->setLicense(__DIR__ . "/Aspose.Slides.lic");
```

Przykład oczekuje, że plik licencji znajduje się obok skryptu i przekazuje jego absolutną ścieżkę: Aspose.Slides działa w środowisku Tomcat, więc nie rozwiązuje ścieżki względnej względem folderu skryptu. Przy wywoływaniu metody setLicense, nazwa licencji powinna być taka sama jak nazwa pliku licencji. Na przykład, możesz zmienić nazwę pliku licencji na "Aspose.Slides.lic.xml". Następnie w kodzie musisz przekazać nową nazwę licencji (Aspose.Slides.lic.xml) do metody setLicense.

#### **Zastosowanie licencji ze strumienia**
Ten fragment kodu służy do zastosowania licencji ze strumienia:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/pl/lib/aspose.slides.php");

use aspose\slides\License;

$stream = new Java("java.io.FileInputStream", __DIR__ . "/Aspose.Slides.lic");

$license = new License();
$license->setLicense($stream);

$stream->close();
```

## **FAQ**

### Czy mogę zastosować licencję w całkowicie offline środowisku (bez dostępu do Internetu)?
Tak. Walidacja licencji jest wykonywana lokalnie przy użyciu pliku licencji; połączenie z internetem nie jest wymagane.

### Co się dzieje po wygaśnięciu rocznej subskrypcji? Czy biblioteka przestanie działać?
Nie. Licencja jest nieograniczona czasowo: możesz nadal korzystać z wersji wydanych przed datą wygaśnięcia subskrypcji; nie będziesz jednak uprawniony do używania nowszych wydań bez odnowienia.