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
- walidacja licencji
- plik licencji
- wersja ewaluacyjna
- Python
- Aspose.Slides
description: "Dowiedz się, jak stosować, zarządzać i rozwiązywać problemy z licencjami w Aspose.Slides dla Pythona poprzez .NET. Zapewnij nieprzerwany dostęp do pełnych funkcji dzięki naszemu przewodnikowi krok po kroku dotyczącym licencjonowania."
---
## **Przegląd**

Aspose.Slides można używać w trybie ewaluacyjnym lub z ważną licencją. Wersja ewaluacyjna zapewnia taką samą funkcjonalność jak wersja licencjonowana, ale dodaje znak wodny ewaluacji do każdego slajdu każdej prezentacji, którą zapisuje, oraz przycina tekst odczytywany przez Twój kod z prezentacji.

## **Wypróbuj Aspose.Slides**

Możesz pobrać wersję ewaluacyjną **Aspose.Slides for Python via .NET** ze swojej [strony pobierania](https://pypi.org/project/Aspose.Slides/). Wersja ewaluacyjna zapewnia te same funkcje co produkt licencjonowany. Pakiet ewaluacyjny jest identyczny z zakupionym pakietem i zostaje licencjonowany po dodaniu kilku linii kodu w celu zastosowania licencji.

Kiedy będziesz zadowolony z oceny **Aspose.Slides**, możesz [zakupić licencję](https://purchase.aspose.com/pricing/slides/pl/python-net/). Zalecamy przegląd dostępnych opcji subskrypcji. Jeśli masz pytania, skontaktuj się z zespołem sprzedaży Aspose.

Każda licencja Aspose zawiera roczną subskrypcję z bezpłatnymi aktualizacjami do nowych wersji oraz poprawkami wydanymi w tym okresie. Zarówno użytkownicy licencjonowani, jak i ewaluacyjni otrzymują bezpłatne, nieograniczone wsparcie techniczne.

**Ograniczenia wersji ewaluacyjnej**

* Wersja ewaluacyjna (gdy nie zastosowano licencji) zapewnia pełną funkcjonalność, ale dodaje pole tekstowe znaku wodnego ewaluacji do każdego slajdu każdej prezentacji, którą zapisuje.
* Tekst odczytywany przez Twój kod z prezentacji jest przycinany do kilku pierwszych znaków, po których pojawia się informacja o ograniczeniu wersji ewaluacyjnej. Tekst zapisywany przez Twój kod jest zapisywany w całości.

{{% alert color="info" title="Note" %}}
Aby przetestować Aspose.Slides bez ograniczeń, możesz poprosić o **30‑dniową Tymczasową Licencję**. Zobacz stronę [Jak uzyskać tymczasową licencję](https://purchase.aspose.com/temporary-license) po szczegóły.
{{% /alert %}}

## **Licencjonowanie w Aspose.Slides**

* Wersja ewaluacyjna staje się licencjonowana po zakupie licencji i dodaniu kilku linii kodu w celu jej zastosowania.
* Licencja jest plikiem XML w formacie czystego tekstu, zawierającym szczegóły takie jak nazwa produktu, liczba programistów, których obejmuje, data wygaśnięcia subskrypcji i inne.
* Plik licencji jest cyfrowo podpisany, więc nie należy go modyfikować. Nawet dodanie jednego znaku nowej linii sprawi, że stanie się nieważny.
* Aspose.Slides for Python via .NET szuka licencji w ścieżce przekazanej mu. Ścieżka względna lub nazwa pliku bez ścieżki jest rozwiązywana względem bieżącego katalogu roboczego, który nie musi być folderem zawierającym Twój skrypt Pythona.
* Aby uniknąć ograniczeń wersji ewaluacyjnej, ustaw licencję przed użyciem Aspose.Slides. Wystarczy ustawić ją raz na aplikację lub proces.

{{% alert color="info" title="Note" %}}
Możesz również chcieć przejrzeć [Licencjonowanie zliczane](/slides/pl/python-net/metered-licensing/).
{{% /alert %}}

## **Zastosowanie licencji**

Licencję można załadować z **pliku** lub **strumienia**.

{{% alert color="info" title="Note" %}}
Aspose.Slides udostępnia klasę [License](https://reference.aspose.com/slides/pl/python-net/aspose.slides/license/) do obsługi licencjonowania.
{{% /alert %}}

{{% alert color="warning" title="Warning" %}}
Nowe licencje mogą aktywować Aspose.Slides tylko w wersji 21.4 lub nowszej. Wcześniejsze wersje używają innego systemu licencjonowania i nie rozpoznają tych licencji.
{{% /alert %}}

### **Plik**

Najprostszym sposobem ustawienia licencji jest przekazanie ścieżki do pliku licencji metodzie [set_license](https://reference.aspose.com/slides/pl/python-net/aspose.slides/license/set_license/). Jeśli przekażesz tylko nazwę pliku, jak w poniższym przykładzie, Aspose.Slides będzie szukać pliku w bieżącym katalogu roboczym.

Poniższy kod Pythona pokazuje, jak ustawić plik licencji:

```py
import aspose.slides as slides

# Tworzy instancję klasy License.
license = slides.License()

# Ustawia ścieżkę pliku licencji.
license.set_license("Aspose.Slides.lic")
```

{{% alert color="warning" title="Warning" %}}
Jeśli umieścisz plik licencji w innym katalogu, wywołując [License.set_license](https://reference.aspose.com/slides/pl/python-net/aspose.slides/license/set_license/#str), nazwa pliku na końcu podanej ścieżki musi odpowiadać nazwie Twojego pliku licencji.

Na przykład możesz zmienić nazwę pliku licencji na *Aspose.Slides.lic.xml*. Następnie w kodzie przekaż pełną ścieżkę do tego pliku (kończącą się Aspose.Slides.lic.xml) metodzie [License.set_license](https://reference.aspose.com/slides/pl/python-net/aspose.slides/license/set_license/#str).
{{% /alert %}}

### **Strumień**

Możesz załadować licencję ze strumienia. Poniższy przykład w Pythonie pokazuje, jak zastosować licencję ze strumienia:

```py
import aspose.slides as slides

# Tworzy instancję klasy License.
license = slides.License()

# Ustaw licencję ze strumienia.
with open("Aspose.Slides.lic", "rb") as stream:
    license.set_license(stream)
```

## **Weryfikacja licencji**

Aby sprawdzić, czy licencja została prawidłowo zastosowana, możesz ją zweryfikować. Poniższy kod Pythona demonstruje, jak zweryfikować licencję:

```py
import aspose.slides as slides

license = slides.License()

license.set_license("Aspose.Slides.lic")

if license.is_licensed():
    print("License is good!")
```

## **Bezpieczeństwo wątków**

{{% alert color="warning" title="Warning" %}}
Metoda [License.set_license](https://reference.aspose.com/slides/pl/python-net/aspose.slides/license/set_license/) nie jest bezpieczna wątkowo. Jeśli musisz wywoływać ją równocześnie z wielu wątków, użyj prymitywu synchronizacji, takiego jak `threading.Lock`, aby uniknąć problemów.
{{% /alert %}}

## **FAQ**

### Czy mogę zastosować licencję w całkowicie offline środowisku (bez dostępu do Internetu)?

Tak. Weryfikacja licencji odbywa się lokalnie przy użyciu pliku licencji; połączenie z internetem nie jest wymagane.

### Co się dzieje po wygaśnięciu rocznej subskrypcji? Czy biblioteka przestanie działać?

Nie. Licencja jest nieograniczona czasowo: możesz dalej korzystać z wersji wydanych przed datą zakończenia subskrypcji; po prostu nie będziesz uprawniony do korzystania z nowszych wydań bez odnowienia.