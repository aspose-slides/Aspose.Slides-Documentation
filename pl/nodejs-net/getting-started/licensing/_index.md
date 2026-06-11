---
title: Licencjonowanie
description: "Aspose.Slides dla Node.js via .NET oferuje różne plany zakupu lub udostępnia bezpłatną wersję próbną i 30-dniową licencję tymczasową do oceny, wykorzystując zasady licencjonowania i subskrypcji."
type: docs
weight: 80
url: /pl/nodejs-net/licensing/
---
Czasami, aby uzyskać najlepsze wyniki oceny, potrzebne może być praktyczne podejście. Z tego powodu Aspose.Slides oferuje różne plany zakupowe oraz udostępnia Bezpłatną wersję próbną i 30‑dniową Licencję tymczasową do oceny.

{{% alert color="primary" %}}

Zauważ, że istnieje wiele ogólnych zasad i praktyk, które wskazują, jak oceniać, prawidłowo licencjonować i kupować nasze produkty. Możesz je znaleźć w sekcji [Polityki zakupu i FAQ](https://purchase.aspose.com/policies).

{{% /alert %}}

## **Ocena Aspose.Slides**
Możesz łatwo pobrać Aspose.Slides do oceny. Pakiet ewaluacyjny jest taki sam jak zakupiony pakiet. Wersja ewaluacyjna po prostu staje się licencjonowana po dodaniu kilku linii kodu, które zastosują licencję. 

## **Ograniczenia wersji ewaluacyjnej**
Wersja ewaluacyjna Aspose.Slides (bez określonej licencji) zapewnia pełną funkcjonalność produktu, ale wstawia znak wodny ewaluacji u góry dokumentu podczas otwierania i zapisywania. Dodatkowo jesteś ograniczony do jednego slajdu przy wyodrębnianiu tekstu z prezentacji.

{{% alert color="primary" %}} 

Jeśli chcesz przetestować Aspose.Slides bez ograniczeń wersji ewaluacyjnej, możesz złożyć wniosek o **30‑dniową Licencję tymczasową**. Więcej informacji znajdziesz w artykule [Jak uzyskać licencję tymczasową?](https://purchase.aspose.com/temporary-license).

{{% /alert %}} 

## **O licencji**
Możesz łatwo pobrać wersję ewaluacyjną Aspose.Slides dla Node.js via .NET ze swojej [strony pobierania](https://releases.aspose.com/slides/pl/nodejs-net/). Wersja ewaluacyjna zapewnia absolutnie **takie same możliwości** jak licencjonowana wersja Aspose.Slides. Co więcej, wersja ewaluacyjna po prostu staje się licencjonowana po zakupie licencji i dodaniu kilku linii kodu, które zastosują licencję.

Licencja jest zwykłym plikiem XML, który zawiera szczegóły takie jak nazwa produktu, liczba deweloperów, dla których jest licencjonowana, data wygaśnięcia subskrypcji itp. Plik jest podpisany cyfrowo, więc nie należy go modyfikować. Nawet przypadkowe dodanie dodatkowego znaku nowej linii do zawartości pliku unieważni go.

Aby uniknąć ograniczeń związanych z wersją ewaluacyjną, musisz ustawić licencję przed użyciem **Aspose.Slides**. Licencję należy ustawić tylko raz na aplikację lub proces.

## Licencja zakupiona

Po zakupie musisz zastosować plik licencji lub strumień. 

{{% alert color="primary" %}}

Musisz ustawić licencję:
* tylko raz na domenę aplikacji
* przed użyciem jakiejkolwiek innej klasy Aspose.Slides

{{% /alert %}}

{{% alert color="primary" %}}

Możesz znaleźć informacje o cenach na stronie [Informacje o cenach](https://purchase.aspose.com/pricing/slides/pl/family).

{{% /alert %}}

### **Ustawianie licencji w Aspose.Slides dla Node.js via .NET**

Licencje mogą być stosowane z następujących lokalizacji:

* Ścieżka bezpośrednia
* Strumień
* Jako licencja metrowana – nowy mechanizm licencjonowania

{{% alert color="primary" %}}

Użyj metody **setLicense**, aby licencjonować komponent.

Choć wielokrotne wywołania **setLicense** nie szkodzą, są marnotrawstwem zasobów (procesora).

{{% /alert %}}

{{% alert color="warning" %}}

Nowe licencje mogą aktywować Aspose.Slides tylko w wersji 21.4 lub nowszej. Wcześniejsze wersje używają innego systemu licencjonowania i nie rozpoznają tych licencji.

{{% /alert %}}

#### **Stosowanie licencji przy użyciu pliku**

Ten fragment kodu służy do ustawienia pliku licencji:

**Node.js**

```javascript
// Importuj moduł Aspose.Slides do manipulacji plikami PowerPoint
const asposeSlides = require('aspose.slides.via.net');

// Ta funkcja konfiguruje bibliotekę Aspose.Slides z licencją
function setupAsposeSlidesLicense() {
	
    // Inicjalizuj klasę License z modułu Aspose.Slides
    var license = new asposeSlides.License();
    
    // Zastosuj licencję z pliku
    // Zamień "your_license_file.lic" na ścieżkę do rzeczywistego pliku licencji
    license.setLicense("your_license_file.lic");
}

// Uruchom funkcję, aby skonfigurować licencję dla Aspose.Slides
setupAsposeSlidesLicense();
```
{{% alert color="primary" %}}

Podczas wywoływania metody setLicense, nazwa licencji powinna być taka sama jak nazwa twojego pliku licencji. Na przykład możesz zmienić nazwę pliku licencji na "Aspose.Slides.lic.xml". Następnie w kodzie musisz przekazać nową nazwę licencji (Aspose.Slides.lic.xml) do metody setLicense.

{{% /alert %}}