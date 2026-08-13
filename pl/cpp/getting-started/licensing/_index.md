---
title: Licencjonowanie
type: docs
weight: 120
url: /pl/cpp/licensing/
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
- C++
- Aspose.Slides
description: "Zastosuj, zarządzaj i rozwiąż problemy związane z licencjami w Aspose.Slides dla C++. Zapewnij nieprzerwany dostęp do pełnych funkcji dzięki naszemu przewodnikowi krok po kroku dotyczącym licencjonowania."
---
## **Przegląd**

Aspose.Slides może być używany w trybie ewaluacyjnym lub z ważną licencją. Wersja ewaluacyjna zapewnia taką samą funkcjonalność jak wersja licencjonowana, ale dodaje znak wodny ewaluacji przy otwieraniu lub zapisywaniu prezentacji oraz ogranicza wyodrębnianie tekstu do jednego slajdu.

Ten artykuł wyjaśnia, jak działa licencjonowanie w Aspose.Slides oraz jak zastosować licencję przed użyciem biblioteki. Licencję można załadować z pliku, strumienia lub wbudowanego zasobu przy użyciu klasy `License`. Artykuł pokazuje również, jak zweryfikować, czy licencja została poprawnie zastosowana.

## **Ewaluacja Aspose.Slides**

{{% alert color="info" %}} 

Możesz pobrać wersję ewaluacyjną **Aspose.Slides for C++** ze [strony pobierania NuGet](https://www.nuget.org/packages/Aspose.Slides.CPP/). Wersja ewaluacyjna oferuje taką samą funkcjonalność jak produkt licencjonowany. W rzeczywistości pakiet ewaluacyjny jest identyczny z zakupionym – po dodaniu kilku linii kodu, które zastosują licencję, staje się licencjonowany.

Gdy będziesz zadowolony z ewaluacji **Aspose.Slides**, możesz [zakupić licencję](https://purchase.aspose.com/buy). Zalecamy zapoznanie się z dostępnymi typami subskrypcji. Jeśli masz jakiekolwiek pytania, skontaktuj się z zespołem sprzedaży Aspose.

Każda licencja Aspose zawiera roczną subskrypcję uprawniającą do bezpłatnych aktualizacji, w tym nowych wersji i poprawek wydawanych w tym okresie. Niezależnie od tego, czy używasz wersji licencjonowanej, czy ewaluacyjnej, otrzymujesz bezpłatne i nieograniczone wsparcie techniczne.

{{% /alert %}} 

**Ograniczenia wersji ewaluacyjnej**

* Chociaż wersja ewaluacyjna Aspose.Slides (gdy nie zastosowano licencji) zapewnia pełną funkcjonalność produktu, wstawia znak wodny ewaluacji u góry dokumentu podczas otwierania i zapisywania.
* Wyodrębnianie tekstu jest ograniczone do jednego slajdu w wersji ewaluacyjnej.

{{% alert color="info" %}} 

Aby przetestować Aspose.Slides bez ograniczeń, możesz poprosić o **30‑dniową licencję tymczasową**. Więcej informacji znajdziesz na stronie [How to Get a Temporary License](https://purchase.aspose.com/temporary-license).

{{% /alert %}}

## **Licencjonowanie w Aspose.Slides**

* Wersja ewaluacyjna staje się licencjonowana po zakupie licencji i jej zastosowaniu poprzez dodanie kilku linii kodu.
* Licencja jest zwykłym plikiem XML w formacie tekstowym, zawierającym takie informacje jak nazwa produktu, liczba deweloperów, dla których jest licencjonowana, data wygaśnięcia subskrypcji i inne.
* Plik licencji jest cyfrowo podpisany, więc nie powinien być modyfikowany. Nawet przypadkowa zmiana, np. dodanie znaku nowej linii, unieważni plik.
* Aspose.Slides for C++ zazwyczaj szuka pliku licencji w następujących lokalizacjach:
  * Ścieżka podana explicite w kodzie
  * Folder zawierający plik DLL komponentu (dołączony do Aspose.Slides)
  * Folder zawierający zestaw, który wywołuje DLL komponentu
* Aby uniknąć ograniczeń wersji ewaluacyjnej, licencję należy ustawić przed użyciem Aspose.Slides. Licencję trzeba ustawić tylko raz na aplikację lub proces.

## **Zastosowanie licencji**

Licencję można załadować z **pliku**, **strumienia** lub **wbudowanego zasobu**.

{{% alert color="info" %}}

Aspose.Slides udostępnia klasę [License](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.license/) do operacji licencjonowania.

{{% /alert %}} 

{{% alert color="warning" %}}

Nowe licencje mogą aktywować Aspose.Slides wyłącznie w wersji 21.4 lub późniejszej. Wcześniejsze wersje używają innego systemu licencjonowania i nie rozpoznają tych licencji.

{{% /alert %}}

### **Plik**

Najprostszym sposobem ustawienia licencji jest umieszczenie pliku licencji w tym samym folderze co plik DLL komponentu (dołączony do Aspose.Slides) i podanie jedynie nazwy pliku, bez ścieżki.

Poniższy kod C++ pokazuje, jak ustawić plik licencji:

```c++
#include <Util/License.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    return 0;
}
```

{{% alert color="warning" %}} 

Jeśli umieścisz plik licencji w innym katalogu, to przy wywołaniu metody [License::SetLicense](https://reference.aspose.com/slides/pl/cpp/aspose.slides/license/setlicense/) nazwa pliku na końcu podanej explicite ścieżki musi dokładnie odpowiadać nazwie Twojego pliku licencji.

Na przykład, jeśli zmienisz nazwę pliku licencji na *Aspose.Slides.lic.xml*, musisz przekazać pełną ścieżkę kończącą się na *Aspose.Slides.lic.xml* do metody [License::SetLicense](https://reference.aspose.com/slides/pl/cpp/aspose.slides/license/setlicense/) w swoim kodzie.

{{% /alert %}}

### **Strumień**

Możesz załadować licencję ze strumienia. Poniższy kod C++ pokazuje, jak zastosować licencję ze strumienia:

```c++
#include <Util/License.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto license = MakeObject<License>();

auto stream = File::OpenRead(u"Aspose.Slides.lic");

license->SetLicense(stream);
```

## **Walidacja licencji**

Aby sprawdzić, czy licencja została prawidłowo ustawiona, możesz ją zweryfikować. Poniższy kod C++ pokazuje, jak zwalidować licencję:

```c++
#include <Util/License.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto license = MakeObject<License>();

license->SetLicense(u"Aspose.Slides.lic");

if (license->IsLicensed())
{
    Console::WriteLine(u"License is good!");
    Console::ReadKey();
}
```

## **Bezpieczeństwo wątków**

{{% alert title="Uwaga" color="warning" %}} 

Metoda [License::SetLicense](https://reference.aspose.com/slides/pl/cpp/aspose.slides/license/setlicense/) nie jest **bezpieczna wątkowo**. Jeśli musisz wywoływać tę metodę jednocześnie z wielu wątków, zaleca się użycie prymitywów synchronizacji (np. blokady), aby zapobiec potencjalnym problemom.

{{% /alert %}}

## **FAQ**

### Czy mogę zastosować licencję w całkowicie offline środowisku (bez dostępu do Internetu)?

Tak. Walidacja licencji odbywa się lokalnie przy użyciu pliku licencji; połączenie z Internetem nie jest wymagane.

### Co się stanie po wygaśnięciu rocznej subskrypcji? Czy biblioteka przestanie działać?

Nie. Licencja jest perpetualna: możesz nadal korzystać z wersji wydanych przed datą wygaśnięcia subskrypcji; po prostu nie będziesz kwalifikować się do używania nowszych wydań bez odnowienia.