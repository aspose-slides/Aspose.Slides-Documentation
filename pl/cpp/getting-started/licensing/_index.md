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
description: "Zastosuj, zarządzaj i rozwiąż problemy z licencjami w Aspose.Slides for C++. Zapewnij nieprzerwany dostęp do pełnych funkcji dzięki naszemu krok po kroku przewodnikowi po licencjonowaniu."
---
## **Przegląd**

Aspose.Slides można używać w trybie ewaluacyjnym lub z ważną licencją. Wersja ewaluacyjna zapewnia taką samą funkcjonalność jak wersja licencjonowana, ale dodaje znak wodny ewaluacji do każdego slajdu każdej prezentacji, którą zapisuje, oraz przycina tekst, który Twój kod odczytuje z prezentacji.

Ten artykuł wyjaśnia, jak działa licencjonowanie w Aspose.Slides oraz jak zastosować licencję przed użyciem biblioteki. Licencję można załadować z pliku lub strumienia przy użyciu klasy `License`. Artykuł również pokazuje, jak zweryfikować, czy licencja została poprawnie zastosowana.

## **Ewaluacja Aspose.Slides**

{{% alert color="info" title="Note" %}}
Możesz pobrać wersję ewaluacyjną **Aspose.Slides for C++** ze [strony pobierania NuGet](https://www.nuget.org/packages/Aspose.Slides.Cpp/) lub, jako pakiet ZIP, ze [strony pobierania](https://releases.aspose.com/slides/pl/cpp/). Wersja ewaluacyjna oferuje taką samą funkcjonalność jak produkt licencjonowany. W rzeczywistości pakiet ewaluacyjny jest identyczny z zakupionym — po prostu staje się licencjonowany po dodaniu kilku linii kodu w celu zastosowania licencji.

Gdy będziesz zadowolony z oceny **Aspose.Slides**, możesz [zakupić licencję](https://purchase.aspose.com/pricing/slides/pl/cpp/). Zalecamy zapoznanie się z dostępnymi typami subskrypcji. Jeśli masz jakiekolwiek pytania, skontaktuj się z zespołem sprzedaży Aspose.

Każda licencja Aspose zawiera roczną subskrypcję na bezpłatne aktualizacje, w tym nowe wersje i poprawki błędów wydane w tym okresie. Niezależnie od tego, czy używasz wersji licencjonowanej czy ewaluacyjnej, otrzymujesz darmowe i nieograniczone wsparcie techniczne.
{{% /alert %}} 

**Ograniczenia wersji ewaluacyjnej**

* Wersja ewaluacyjna (bez określonej licencji) zapewnia pełną funkcjonalność produktu, ale dodaje pole tekstowe znaku wodnego ewaluacji do każdego slajdu każdej prezentacji, którą zapisuje.
* Tekst, który Twój kod odczytuje z prezentacji, jest przycinany do pierwszych kilku znaków, po których następuje informacja o ograniczeniu wersji ewaluacyjnej. Tekst, który Twój kod zapisuje, jest zapisywany w całości.

{{% alert color="info" title="Note" %}}
Aby przetestować Aspose.Slides bez ograniczeń, możesz poprosić o **30-dniową licencję tymczasową**. Aby uzyskać więcej informacji, zobacz stronę [How to Get a Temporary License](https://purchase.aspose.com/temporary-license).
{{% /alert %}}

## **Licencjonowanie w Aspose.Slides**

* Wersja ewaluacyjna staje się licencjonowana po zakupie licencji i jej zastosowaniu poprzez dodanie kilku linii kodu.
* Licencja jest zwykłym plikiem XML w formacie tekstowym, który zawiera szczegóły takie jak nazwa produktu, liczba deweloperów, do których jest licencjonowana, data wygaśnięcia subskrypcji i inne.
* Plik licencji jest cyfrowo podpisany, więc nie należy go modyfikować. Nawet przypadkowa zmiana — np. dodanie znaku nowej linii — unieważni plik.
* Gdy podasz nazwę pliku bez folderu, Aspose.Slides for C++ szuka pliku licencji tylko w bieżącym katalogu roboczym. Nie przeszukuje folderu Twojego pliku wykonywalnego ani biblioteki Aspose.Slides, więc podaj pełną ścieżkę, gdy plik licencji jest przechowywany w innym miejscu.
* Aby uniknąć ograniczeń wersji ewaluacyjnej, musisz ustawić licencję przed użyciem Aspose.Slides. Licencję wystarczy ustawić raz na aplikację lub proces.

## **Zastosowanie licencji**

Licencję można załadować z **pliku** lub **strumienia**.

{{% alert color="info" title="Note" %}}
Aspose.Slides udostępnia klasę [License](https://reference.aspose.com/slides/pl/cpp/aspose.slides/license/) do operacji licencjonowania.
{{% /alert %}} 

{{% alert color="warning" title="Warning" %}}
Nowe licencje mogą aktywować Aspose.Slides tylko w wersji 21.4 lub nowszej. Starsze wersje używają innego systemu licencjonowania i nie rozpoznają tych licencji.
{{% /alert %}}

### **Plik**

Najłatwiejszy sposób ustawienia licencji to umieszczenie pliku licencji w katalogu roboczym programu i podanie tylko nazwy pliku, bez ścieżki. W przeciwnym razie podaj pełną ścieżkę do pliku.

Poniższy kod C++ stosuje plik licencji *Aspose.Slides.lic* z katalogu roboczego programu:

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

Jeśli licencja jest ważna, [License::SetLicense](https://reference.aspose.com/slides/pl/cpp/aspose.slides/license/setlicense/) zwraca i program kończy się bez wyjścia; od tego momentu Aspose.Slides działa bez ograniczeń wersji ewaluacyjnej. Jeśli plik nie znajduje się w katalogu roboczym, metoda wyrzuca [FileNotFoundException](https://reference.aspose.com/slides/pl/cpp/system.io/filenotfoundexception/) z komunikatem *License "Aspose.Slides.lic" doesn't exist or access is restricted*. Przykład nie obsługuje wyjątku, więc program się zatrzymuje.

{{% alert color="warning" title="Warning" %}}
Jeśli umieścisz plik licencji w innym katalogu, to przy wywoływaniu metody [License::SetLicense](https://reference.aspose.com/slides/pl/cpp/aspose.slides/license/setlicense/) nazwa pliku na końcu podanej explicite ścieżki musi dokładnie odpowiadać nazwie Twojego pliku licencji.

Na przykład, jeśli zmienisz nazwę pliku licencji na *Aspose.Slides.lic.xml*, musisz przekazać pełną ścieżkę kończącą się na *Aspose.Slides.lic.xml* do metody [License::SetLicense](https://reference.aspose.com/slides/pl/cpp/aspose.slides/license/setlicense/) w kodzie.
{{% /alert %}}

### **Strumień**

Załaduj licencję ze strumienia, gdy Twój program nie przechowuje licencji jako pliku, który może nazwąć, na przykład gdy odczytuje licencję z bazy danych. [License::SetLicense](https://reference.aspose.com/slides/pl/cpp/aspose.slides/license/setlicense/) akceptuje dowolny [Stream](https://reference.aspose.com/slides/pl/cpp/system.io/stream/) zawierający licencję. Aby skrócić przykład, poniższy kod C++ otwiera *Aspose.Slides.lic* w katalogu roboczym przy użyciu [File::OpenRead](https://reference.aspose.com/slides/pl/cpp/system.io/file/openread/) i stosuje licencję z tego strumienia:

```c++
#include <Util/License.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

int main()
{
    auto license = MakeObject<License>();
    auto stream = File::OpenRead(u"Aspose.Slides.lic");
    license->SetLicense(stream);

    return 0;
}
```

Poprawna licencja daje ten sam wynik co w przykładzie plikowym. Jeśli plik nie istnieje, [File::OpenRead](https://reference.aspose.com/slides/pl/cpp/system.io/file/openread/) wyrzuca [FileNotFoundException](https://reference.aspose.com/slides/pl/cpp/system.io/filenotfoundexception/) przed zastosowaniem licencji i program się zatrzymuje.

## **Walidacja licencji**

Aby sprawdzić, czy licencja została prawidłowo ustawiona, wywołaj [License::IsLicensed](https://reference.aspose.com/slides/pl/cpp/aspose.slides/license/islicensed/). Zwraca `true` tylko po zastosowaniu ważnej licencji, a `false` przed tym. Poniższy kod C++ ustawia plik licencji z katalogu roboczego, a następnie go sprawdza:

```c++
#include <Util/License.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    if (license->IsLicensed())
    {
        Console::WriteLine(u"License is good!");
    }

    return 0;
}
```

Przy ważnej licencji program wypisuje *License is good!*. Jeśli plik jest brakujący lub nie jest plikiem licencji, [License::SetLicense](https://reference.aspose.com/slides/pl/cpp/aspose.slides/license/setlicense/) wyrzuca wyjątek przed sprawdzeniem i program kończy się bez wypisywania czegokolwiek. Jeśli plik jest licencją, której podpis nie pasuje, np. ponieważ został zmodyfikowany, SetLicense zwraca bez błędu, ale `IsLicensed` zwraca `false`, więc nic nie jest wypisywane i Aspose.Slides pozostaje w trybie ewaluacyjnym.

## **Bezpieczeństwo wątków**

{{% alert color="warning" title="Warning" %}}
Metoda [License::SetLicense](https://reference.aspose.com/slides/pl/cpp/aspose.slides/license/setlicense/) nie jest **bezpieczna dla wątków**. Jeśli musisz wywoływać tę metodę z wielu wątków jednocześnie, zaleca się użycie prymitywów synchronizacji (takich jak lock), aby zapobiec potencjalnym problemom.
{{% /alert %}}

## **FAQ**

### Czy mogę zastosować licencję w całkowicie offline środowisku (bez dostępu do internetu)?

Tak. Walidacja licencji odbywa się lokalnie przy użyciu pliku licencji; połączenie internetowe nie jest wymagane.

### Co się dzieje po wygaśnięciu rocznej subskrypcji? Czy biblioteka przestanie działać?

Nie. Licencja jest wieczysta: możesz nadal używać wersji wydanych przed datą zakończenia subskrypcji; po prostu nie będziesz uprawniony do korzystania z nowszych wydań bez odnowienia.