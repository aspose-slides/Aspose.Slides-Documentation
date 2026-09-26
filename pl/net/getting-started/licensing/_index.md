---
title: Licencjonowanie
type: docs
weight: 80
url: /pl/net/licensing/
keywords:
- licencja
- licencja tymczasowa
- ustaw licencję
- użyj licencji
- weryfikuj licencję
- plik licencji
- wersja ewaluacyjna
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Zastosuj, zarządzaj i rozwiąż problemy z licencjami w Aspose.Slides dla .NET. Zapewnij nieprzerwany dostęp do pełnych funkcji dzięki naszemu krok po kroku przewodnikowi po licencjonowaniu."
---
## **Przegląd**

Aspose.Slides może być używany w trybie ewaluacyjnym lub z ważną licencją. Wersja ewaluacyjna zapewnia tę samą funkcjonalność co wersja licencjonowana, ale dodaje znak wodny „evaluation” do każdego slajdu każdej prezentacji, którą zapisuje, oraz obcina tekst odczytywany z prezentacji przez Twój kod.

Ten artykuł wyjaśnia, jak działa licencjonowanie w Aspose.Slides oraz jak zastosować licencję przed użyciem biblioteki. Licencję można wczytać z pliku, strumienia lub zasobu osadzonego przy użyciu klasy `License`. Artykuł pokazuje również, jak zweryfikować, czy licencja została zastosowana prawidłowo.

## **Ewaluacja Aspose.Slides**

{{% alert color="info" title="Uwaga" %}}

Możesz pobrać wersję ewaluacyjną **Aspose.Slides for .NET** ze [strony pobierania w NuGet](https://www.nuget.org/packages/Aspose.Slides.NET/). Wersja ewaluacyjna oferuje te same funkcje, co wersja licencjonowana produktu. Pakiet ewaluacyjny jest taki sam jak zakupiony pakiet. Wersja ewaluacyjna po prostu staje się licencjonowana po dodaniu kilku linijek kodu (aby zastosować licencję).

Gdy już będziesz zadowolony z ewaluacji **Aspose.Slides**, możesz [zakupić licencję](https://purchase.aspose.com/pricing/slides/pl/net/). Zalecamy zapoznanie się z różnymi typami subskrypcji. Jeśli masz pytania, skontaktuj się z zespołem sprzedaży Aspose.

Każda licencja Aspose zawiera roczną subskrypcję na bezpłatne aktualizacje do nowych wersji lub poprawek wydanych w okresie subskrypcji. Użytkownicy posiadający licencjonowane produkty lub nawet wersje ewaluacyjne otrzymują bezpłatne i nieograniczone wsparcie techniczne.

{{% /alert %}} 

**Ograniczenia wersji ewaluacyjnej**

* Wersja ewaluacyjna (bez podanej licencji) zapewnia pełną funkcjonalność produktu, ale dodaje pole tekstowe z znakiem wodnym „evaluation” do każdego slajdu każdej prezentacji, którą zapisuje.
* Tekst odczytywany z prezentacji jest obcinany do kilku pierwszych znaków, po których pojawia się informacja o ograniczeniu ewaluacyjnym. Tekst zapisywany przez Twój kod jest zachowywany w całości.

{{% alert color="info" title="Uwaga" %}}

Aby przetestować Aspose.Slides bez ograniczeń, możesz poprosić o **30‑dniową licencję tymczasową**. Zobacz stronę [Jak uzyskać licencję tymczasową](https://purchase.aspose.com/temporary-license) po więcej informacji.

{{% /alert %}}

## **Licencjonowanie w Aspose.Slides**
* Wersja ewaluacyjna staje się licencjonowana po zakupie licencji i dodaniu kilku linijek kodu (aby zastosować licencję).
* Licencja jest zwykłym plikiem XML w postaci tekstowej, który zawiera takie informacje jak nazwa produktu, liczba deweloperów, do których jest licencjonowana, data wygaśnięcia subskrypcji itp.
* Plik licencji jest cyfrowo podpisany, więc nie należy go modyfikować. Nawet przypadkowe dodanie dodatkowego znaku nowej linii do zawartości pliku spowoduje jego unieważnienie.
* Aspose.Slides for .NET zazwyczaj szuka licencji w następujących lokalizacjach:
  * Jawna ścieżka
  * Folder zawierający dll komponentu (dołączony w Aspose.Slides)
  * Folder zawierający asembla, który wywołał dll komponentu (dołączony w Aspose.Slides)
  * Folder zawierający asembla startowego (Twój .exe)
  * Zasób osadzony w asembla, który wywołał dll komponentu (dołączony w Aspose.Slides).
* Aby uniknąć ograniczeń związanych z wersją ewaluacyjną, musisz ustawić licencję przed użyciem Aspose.Slides. Wystarczy zrobić to raz na aplikację lub proces.

{{% alert color="info" title="Uwaga" %}}

Możesz chcieć zobaczyć [Licencjonowanie rozliczeniowe](/slides/pl/net/metered-licensing/).

{{% /alert %}} 


## **Zastosowanie licencji**
Licencję można wczytać z **pliku**, **strumienia** lub **zasobu osadzonego**. 

{{% alert color="info" title="Uwaga" %}}

Aspose.Slides udostępnia klasę [License](https://reference.aspose.com/slides/pl/net/aspose.slides/license) do operacji licencjonowania.

{{% /alert %}} 

{{% alert color="warning" title="Ostrzeżenie" %}}

Nowe licencje mogą aktywować Aspose.Slides wyłącznie w wersji 21.4 lub późniejszej. Wcześniejsze wersje używają innego systemu licencjonowania i nie rozpoznają tych licencji.

{{% /alert %}}

### **Plik**
Najprostszą metodą ustawienia licencji jest umieszczenie pliku licencji w tym samym folderze, w którym znajduje się DLL komponentu (dołączony w Aspose.Slides) i podanie jedynie nazwy pliku bez ścieżki.

Ten kod C# pokazuje, jak ustawić plik licencji:

``` csharp
// Tworzy instancję klasy License 
Aspose.Slides.License license = new Aspose.Slides.License();

// Ustawia ścieżkę do pliku licencji
license.SetLicense("Aspose.Slides.lic");
```

{{% alert color="warning" title="Ostrzeżenie" %}}

Jeśli umieścisz plik licencji w innym katalogu, przy wywołaniu metody [SetLicense](https://reference.aspose.com/slides/pl/net/aspose.slides/license/setlicense/#setlicense_1) nazwa pliku licencji na końcu podanej ścieżki musi być taka sama jak nazwa Twojego pliku licencji.

Na przykład możesz zmienić nazwę pliku licencji na *Aspose.Slides.lic.xml*. Następnie w kodzie musisz przekazać ścieżkę do pliku (kończącą się na *Aspose.Slides.lic.xml*) do metody [SetLicense](https://reference.aspose.com/slides/pl/net/aspose.slides/license/setlicense/#setlicense_1).

{{% /alert %}}

### **Strumień**
Możesz wczytać licencję ze strumienia. Ten kod C# pokazuje, jak zastosować licencję ze strumienia:

``` csharp
// Tworzy instancję klasy License
Aspose.Slides.License license = new Aspose.Slides.License();

// Otwiera plik licencji jako strumień
using FileStream licenseStream = File.OpenRead("Aspose.Slides.lic");

// Ustawia licencję przy użyciu strumienia
license.SetLicense(licenseStream);
```

### **Zasób osadzony**
Możesz dołączyć licencję do aplikacji (aby nie zgubić jej) poprzez dodanie licencji jako zasobu osadzonego do jednego z asemblerów wywołujących DLL komponentu (dołączony w Aspose.Slides). 

Tak dodaje się plik licencji jako zasób osadzony:

1. W Visual Studio dodaj plik licencji (.lic) do projektu w następujący sposób: przejdź do **File** > **Add Existing Item** > **Add**. 
2. Wybierz plik w **Solution Explorer**.
3. W oknie **Properties** ustaw **Build Action** na **Embedded Resource**.
4. Aby uzyskać dostęp do licencji osadzonej w asembla, dodaj plik licencji jako zasób osadzony do projektu, a następnie przekaż nazwę pliku licencji do metody `SetLicense`. 


Klasa `License` automatycznie znajduje plik licencji w zasobach osadzonych. Nie musisz wywoływać metod `GetExecutingAssembly` i `GetManifestResourceStream` klasy `System.Reflection.Assembly` w Microsoft .NET Framework.

Ten kod C# pokazuje, jak ustawić licencję jako zasób osadzony:

``` csharp
// Tworzy instancję klasy License
Aspose.Slides.License license = new Aspose.Slides.License();

// Przekazuje nazwę pliku licencji osadzonego w asembli
license.SetLicense("Aspose.Slides.lic");
```

## **Weryfikacja licencji**

Aby sprawdzić, czy licencja została poprawnie ustawiona, możesz ją zweryfikować. Ten kod C# pokazuje, jak zweryfikować licencję:

```c#
Aspose.Slides.License license = new Aspose.Slides.License();

license.SetLicense("Aspose.Slides.lic");

if (license.IsLicensed())
{
    Console.WriteLine("License is good!");
    Console.Read();
}
```

## **Bezpieczeństwo wątków**

{{% alert color="warning" title="Ostrzeżenie" %}}

Metoda [license.SetLicense](https://reference.aspose.com/slides/pl/net/aspose.slides/license/setlicense/) nie jest bezpieczna wątkowo. Jeśli metoda ta ma być wywoływana jednocześnie z wielu wątków, rozważ użycie prymitywów synchronizacji (takich jak lock), aby uniknąć problemów. 

{{% /alert %}}

## **FAQ**

### Czy mogę zastosować licencję w środowisku całkowicie offline (bez dostępu do internetu)?

Tak. Walidacja licencji odbywa się lokalnie przy użyciu pliku licencji; połączenie internetowe nie jest wymagane.

### Co się stanie po wygaśnięciu rocznej subskrypcji? Czy biblioteka przestanie działać?

Nie. Licencja jest wieczysta: możesz nadal używać wersji wydanych przed datą zakończenia subskrypcji; po prostu nie będziesz mieć prawa do korzystania z nowszych wydań bez odnowienia.