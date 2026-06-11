---
title: Licencjonowanie
type: docs
weight: 120
url: /pl/cpp/licensing/
keywords:
- licencja
- tymczasowa licencja
- ustaw licencję
- użyj licencji
- zweryfikuj licencję
- plik licencji
- wersja ewaluacyjna
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Zastosuj, zarządzaj i rozwiązywaj problemy z licencjami w Aspose.Slides dla C++. Zapewnij nieprzerwany dostęp do pełnych funkcji dzięki naszemu krok po kroku przewodnikowi po licencjonowaniu."
---
## **Przegląd**

Aspose.Slides może być używany w trybie ewaluacyjnym lub z ważną licencją. Wersja ewaluacyjna zapewnia taką samą funkcjonalność jak wersja licencjonowana, ale dodaje znak wodny ewaluacji podczas otwierania lub zapisywania prezentacji oraz ogranicza wyodrębnianie tekstu do jednego slajdu.

Ten artykuł wyjaśnia, jak działa licencjonowanie w Aspose.Slides oraz jak zastosować licencję przed użyciem biblioteki. Licencję można wczytać z pliku, strumienia lub zasobu osadzonego przy użyciu klasy `License`. Artykuł pokazuje także, jak zweryfikować, czy licencja została poprawnie zastosowana.

## **Ocena Aspose.Slides**

{{% alert color="primary" %}} 

Możesz pobrać wersję ewaluacyjną **Aspose.Slides for C++** z [jej strony pobierania NuGet](https://www.nuget.org/packages/Aspose.Slides.CPP/). Wersja ewaluacyjna oferuje taką samą funkcjonalność jak produkt licencjonowany. W rzeczywistości pakiet ewaluacyjny jest identyczny z zakupionym — po dodaniu kilku linii kodu, które zastosują licencję, staje się licencjonowany.

Gdy będziesz zadowolony z oceny **Aspose.Slides**, możesz [zakupić licencję](https://purchase.aspose.com/buy). Zalecamy zapoznanie się z dostępnymi typami subskrypcji. Jeśli masz pytania, skontaktuj się z zespołem sprzedaży Aspose.

Każda licencja Aspose obejmuje roczną subskrypcję zapewniającą bezpłatne aktualizacje, w tym nowe wersje i poprawki błędów wydane w tym okresie. Niezależnie od tego, czy używasz wersji licencjonowanej, czy ewaluacyjnej, otrzymujesz bezpłatne i nieograniczone wsparcie techniczne.

{{% /alert %}} 

**Ograniczenia wersji ewaluacyjnej**

* Chociaż wersja ewaluacyjna Aspose.Slides (gdy nie zastosowano licencji) zapewnia pełną funkcjonalność produktu, wstawia znak wodny ewaluacji na górze dokumentu podczas operacji otwierania i zapisywania.
* Wyodrębnianie tekstu jest ograniczone do jednego slajdu w wersji ewaluacyjnej.

{{% alert color="primary" %}} 

Aby przetestować Aspose.Slides bez ograniczeń, możesz poprosić o **30‑dniową tymczasową licencję**. Więcej informacji znajdziesz na stronie [Jak uzyskać tymczasową licencję](https://purchase.aspose.com/temporary-license).

{{% /alert %}}

## **Licencjonowanie w Aspose.Slides**

* Wersja ewaluacyjna staje się licencjonowana po zakupie licencji i jej zastosowaniu poprzez dodanie kilku linii kodu.
* Licencja jest zwykłym plikiem XML w formacie tekstowym, który zawiera szczegóły takie jak nazwa produktu, liczba programistów, do których jest licencjonowana, data wygaśnięcia subskrypcji i inne.
* Plik licencji jest cyfrowo podpisany, więc nie może być modyfikowany. Nawet przypadkowa zmiana — na przykład dodanie znaku nowej linii — unieważni plik.
* Aspose.Slides for C++ zazwyczaj poszukuje pliku licencji w następujących lokalizacjach:
  * Ścieżka podana jawnie w kodzie
  * Folder zawierający plik DLL komponentu (dołączony do Aspose.Slides)
  * Folder zawierający zestaw (assembly), który wywołuje DLL komponentu
* Aby uniknąć ograniczeń wersji ewaluacyjnej, musisz ustawić licencję przed użyciem Aspose.Slides. Licencję należy ustawić tylko raz na aplikację lub proces.

## **Zastosowanie licencji**

Licencję można wczytać z **pliku**, **strumienia** lub **zasobu osadzonego**.

{{% alert color="primary" %}}

Aspose.Slides udostępnia klasę [License](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.license/) do operacji licencjonowania.

{{% /alert %}} 

{{% alert color="warning" %}}

Nowe licencje mogą aktywować Aspose.Slides wyłącznie w wersji 21.4 lub nowszej. Starsze wersje używają innego systemu licencjonowania i nie rozpoznają tych licencji.

{{% /alert %}}

### **Plik**

Najprostszy sposób ustawienia licencji to umieszczenie pliku licencji w tym samym folderze co plik DLL komponentu (dołączony do Aspose.Slides) i podanie jedynie nazwy pliku, bez ścieżki.

Poniższy kod C++ pokazuje, jak ustawić plik licencji:

```c++
#include <Util/License.h>

using namespace Aspose::Slides;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    return 0;
}
```

{{% alert color="warning" %}} 

Jeśli umieścisz plik licencji w innym katalogu, to podczas wywoływania metody [License::SetLicense](https://reference.aspose.com/slides/pl/cpp/aspose.slides/license/setlicense/) nazwa pliku na końcu podanej jawnej ścieżki musi dokładnie odpowiadać nazwie Twojego pliku licencji.

Na przykład, jeśli zmienisz nazwę pliku licencji na *Aspose.Slides.lic.xml*, musisz przekazać pełną ścieżkę kończącą się na *Aspose.Slides.lic.xml* do metody [License::SetLicense](https://reference.aspose.com/slides/pl/cpp/aspose.slides/license/setlicense/) w swoim kodzie.

{{% /alert %}}

### **Strumień**

Możesz wczytać licencję ze strumienia. Poniższy kod C++ pokazuje, jak zastosować licencję ze strumienia:

```c++
auto license = MakeObject<License>();

auto stream = File::OpenRead(u"Aspose.Slides.lic");

license->SetLicense(stream);
```

## **Walidacja licencji**

Aby sprawdzić, czy licencja została prawidłowo ustawiona, możesz ją zwalidować. Poniższy kod C++ pokazuje, jak zwalidować licencję:

```c++
auto license = MakeObject<License>();

license->SetLicense(u"Aspose.Slides.lic");

if (license->IsLicensed())
{
    Console::WriteLine(u"License is good!");
    Console::ReadKey();
}
```

## **Bezpieczeństwo wątkowe**

{{% alert title="Uwaga" color="warning" %}} 

Metoda [License::SetLicense](https://reference.aspose.com/slides/pl/cpp/aspose.slides/license/setlicense/) nie jest **bezpieczna wątkowo**. Jeśli musisz wywoływać tę metodę jednocześnie z wielu wątków, zaleca się użycie mechanizmów synchronizacji (takich jak blokada), aby zapobiec potencjalnym problemom.

{{% /alert %}}

## **FAQ**

**Czy mogę zastosować licencję w całkowicie offline środowisku (bez dostępu do internetu)?**

Tak. Walidacja licencji odbywa się lokalnie przy użyciu pliku licencji; połączenie internetowe nie jest wymagane.

**Co się stanie po wygaśnięciu rocznej subskrypcji? Czy biblioteka przestanie działać?**

Nie. Licencja jest wieczysta: możesz nadal używać wersji wydanych przed datą końca subskrypcji; po prostu nie będziesz uprawniony do używania nowszych wydań bez odnowienia.