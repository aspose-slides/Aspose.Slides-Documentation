---
title: Licencjonowanie
type: docs
weight: 80
url: /pl/python-net/licensing/
keywords:
- licencja
- licencja tymczasowa
- ustaw licencję
- używanie licencji
- weryfikacja licencji
- plik licencji
- wersja ewaluacyjna
- Python
- Aspose.Slides
description: "Dowiedz się, jak zastosować, zarządzać i rozwiązywać problemy z licencjami w Aspose.Slides for Python via .NET. Zapewnij nieprzerwany dostęp do pełnych funkcji dzięki naszemu przewodnikowi po licencjonowaniu krok po kroku."
---
## **Przegląd**

Aspose.Slides może być używany w trybie ewaluacyjnym lub z ważną licencją. Wersja ewaluacyjna zapewnia taką samą funkcjonalność jak wersja licencjonowana, ale dodaje znak wodny ewaluacji przy otwieraniu lub zapisywaniu prezentacji oraz ogranicza wyodrębnianie tekstu do jednego slajdu.

## **Ewaluacja Aspose.Slides**

Możesz pobrać wersję ewaluacyjną **Aspose.Slides for Python via .NET** ze swojej [strony pobierania](https://pypi.org/project/Aspose.Slides/). Wersja ewaluacyjna zapewnia te same funkcje co produkt licencjonowany. Pakiet ewaluacyjny jest identyczny z zakupionym pakietem i staje się licencjonowany po dodaniu kilku linii kodu w celu zastosowania licencji.

Gdy będziesz zadowolony z ewaluacji **Aspose.Slides**, możesz [zakupić licencję](https://purchase.aspose.com/buy). Zalecamy zapoznanie się z dostępnymi opcjami subskrypcji. Jeśli masz pytania, skontaktuj się z zespołem sprzedaży Aspose.

Każda licencja Aspose obejmuje roczną subskrypcję z bezpłatnymi aktualizacjami do nowych wersji oraz poprawek wydanych w tym okresie. Zarówno licencjonowani, jak i użytkownicy wersji ewaluacyjnej otrzymują darmowe, nieograniczone wsparcie techniczne.

**Ograniczenia wersji ewaluacyjnej**

* Choć wersja ewaluacyjna Aspose.Slides (gdy nie zastosowano licencji) zapewnia pełną funkcjonalność, dodaje znak wodny ewaluacji na górze dokumentu przy każdym otwarciu lub zapisaniu.
* Przy wyodrębnianiu tekstu z prezentacji jesteś ograniczony do jednego slajdu.

{{% alert color="primary" %}}
Aby przetestować Aspose.Slides bez ograniczeń, możesz poprosić o **30‑dniową tymczasową licencję**. Zobacz stronę [Jak uzyskać tymczasową licencję](https://purchase.aspose.com/temporary-license) po szczegóły.
{{% /alert %}}

## **Licencjonowanie w Aspose.Slides**

* Wersja ewaluacyjna staje się licencjonowana po zakupie licencji i dodaniu kilku linii kodu w celu jej zastosowania.
* Licencja jest plikiem XML w formacie zwykłego tekstu, zawierającym szczegóły takie jak nazwa produktu, liczba programistów, które obejmuje, data wygaśnięcia subskrypcji i inne.
* Plik licencji jest cyfrowo podpisany, więc nie wolno go modyfikować. Nawet dodanie pojedynczego znaku nowej linii unieważni go.
* Aspose.Slides for Python via .NET zazwyczaj szuka licencji w następujących lokalizacjach:
  * Ścieżka podana jawnie
  * Folder zawierający skrypt Pythona wywołujący Aspose.Slides for Python via .NET
* Aby uniknąć ograniczeń wersji ewaluacyjnej, ustaw licencję przed użyciem Aspose.Slides. Wystarczy ustawić ją raz na aplikację lub proces.

{{% alert color="primary" %}}
Możesz również chcieć przejrzeć [Licencjonowanie na podstawie zużycia](/slides/pl/python-net/metered-licensing/).
{{% /alert %}}

## **Zastosowanie licencji**

Licencję można wczytać z **pliku**, **strumienia** lub **osadzonego zasobu**. 

{{% alert color="primary" %}}
Aspose.Slides udostępnia klasę [License](https://reference.aspose.com/slides/pl/python-net/aspose.slides/license/) do obsługi licencjonowania.
{{% /alert %}}

{{% alert color="warning" %}}
Nowe licencje mogą aktywować Aspose.Slides tylko w wersji 21.4 lub późniejszej. Wcześniejsze wersje używają innego systemu licencjonowania i nie rozpoznają tych licencji.
{{% /alert %}}

### **Plik**

Najprostszym sposobem ustawienia licencji jest umieszczenie pliku licencji w tym samym folderze co plik DLL komponentu i podanie tylko nazwy pliku (bez ścieżki).

Poniższy kod Python pokazuje, jak ustawić plik licencji:

```py
import aspose.slides as slides

# Tworzy instancję klasy License. 
license = slides.License()

# Ustawia ścieżkę pliku licencji.
license.set_license("Aspose.Slides.lic")
```

{{% alert color="warning" %}}
Jeśli umieścisz plik licencji w innym katalogu, przy wywoływaniu [License.set_license()](https://reference.aspose.com/slides/pl/python-net/aspose.slides/license/set_license/#str), nazwa pliku na końcu podanej ścieżki musi odpowiadać nazwie Twojego pliku licencji.

Na przykład możesz zmienić nazwę pliku licencji na *Aspose.Slides.lic.xml*. Następnie w kodzie przekaż pełną ścieżkę do tego pliku (kończącą się Aspose.Slides.lic.xml) do metody [License.set_license()](https://reference.aspose.com/slides/pl/python-net/aspose.slides/license/set_license/#str).
{{% /alert %}}

### **Strumień**

Możesz wczytać licencję ze strumienia. Poniższy przykład w Pythonie pokazuje, jak zastosować licencję ze strumienia:

```py
import aspose.slides as slides

# Tworzy instancję klasy License.
license = slides.License()

# Ustaw licencję ze strumienia.
license.set_license(stream)
```

## **Walidacja licencji**

Aby zweryfikować, że licencja została poprawnie zastosowana, możesz ją zweryfikować. Poniższy kod Python demonstruje, jak zweryfikować licencję:

```py
import aspose.slides as slides

license = slides.License()

license.set_license("Aspose.Slides.lic")

if license.is_licensed():
    print("License is good!")
```

## **Bezpieczeństwo wątków**

{{% alert title="Uwaga" color="warning" %}}
Metody [License.set_license](https://reference.aspose.com/slides/pl/python-net/aspose.slides/license/) nie są bezpieczne wątkowo. Jeśli muszą być wywoływane jednocześnie z wielu wątków, użyj prymitywów synchronizacji (np. `threading.Lock`), aby uniknąć problemów.
{{% /alert %}}

## **FAQ**

**Czy mogę zastosować licencję w całkowicie offline środowisku (brak dostępu do internetu)?**

Tak. Walidacja licencji odbywa się lokalnie przy użyciu pliku licencji; połączenie z internetem nie jest wymagane.

**Co się stanie po wygaśnięciu rocznej subskrypcji? Czy biblioteka przestanie działać?**

Nie. Licencja jest nieograniczona czasowo: możesz nadal korzystać z wersji wydanych przed datą wygaśnięcia subskrypcji; po prostu nie będziesz mógł korzystać z nowszych wydań bez odnowienia.