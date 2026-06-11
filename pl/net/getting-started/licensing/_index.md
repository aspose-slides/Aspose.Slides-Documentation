---
title: Licencjonowanie
type: docs
weight: 80
url: /pl/net/licensing/
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
- .NET
- C#
- Aspose.Slides
description: "Zastosuj, zarządzaj i rozwiązuj problemy z licencjami w Aspose.Slides dla .NET. Zapewnij nieprzerwany dostęp do pełnych funkcji dzięki naszemu przewodnikowi krok po kroku dotyczącym licencjonowania."
---
## **Przegląd**

Aspose.Slides można używać w trybie ewaluacyjnym lub z ważną licencją. Wersja ewaluacyjna zapewnia taką samą funkcjonalność jak wersja licencjonowana, ale dodaje znak wodny „evaluation” podczas otwierania lub zapisywania prezentacji oraz ogranicza ekstrakcję tekstu do jednego slajdu.

Ten artykuł wyjaśnia, jak działa licencjonowanie w Aspose.Slides oraz jak zastosować licencję przed użyciem biblioteki. Licencję można wczytać z pliku, strumienia lub zasobu osadzonego przy użyciu klasy `License`. Artykuł pokazuje również, jak zweryfikować, czy licencja została poprawnie zastosowana.

## **Ewaluacja Aspose.Slides**

{{% alert color="primary" %}} 

Możesz pobrać wersję ewaluacyjną **Aspose.Slides for NET** z [jej strony pobierania NuGet](https://www.nuget.org/packages/Aspose.Slides.NET/). Wersja ewaluacyjna zapewnia te same funkcje co licencjonowana wersja produktu. Pakiet ewaluacyjny jest taki sam jak zakupiony pakiet. Wersja ewaluacyjna po prostu staje się licencjonowana po dodaniu kilku linii kodu (aby zastosować licencję).

Gdy będziesz zadowolony z ewaluacji **Aspose.Slides**, możesz [zakupić licencję](https://purchase.aspose.com/buy). Zachęcamy do zapoznania się z różnymi typami subskrypcji. Jeśli masz pytania, skontaktuj się z zespołem sprzedaży Aspose.

Każda licencja Aspose zawiera roczną subskrypcję na bezpłatne aktualizacje do nowych wersji lub poprawek wydanych w okresie subskrypcji. Użytkownicy posiadający licencjonowane produkty lub nawet wersje ewaluacyjne otrzymują bezpłatne i nieograniczone wsparcie techniczne.

{{% /alert %}} 

**Ograniczenia wersji ewaluacyjnej**

* Chociaż wersja ewaluacyjna Aspose.Slides (bez określonej licencji) zapewnia pełną funkcjonalność produktu, wstawia znak wodny „evaluation” u góry dokumentu podczas operacji otwierania i zapisywania. 
* Masz ograniczenie do jednego slajdu przy ekstrakcji tekstu z prezentacji.

{{% alert color="primary" %}} 

Aby przetestować Aspose.Slides bez ograniczeń, możesz poprosić o **30‑dniową licencję tymczasową**. Zobacz stronę [How to get a Temporary License](https://purchase.aspose.com/temporary-license) po więcej informacji.

{{% /alert %}}

## **Licencjonowanie w Aspose.Slides**
* Wersja ewaluacyjna staje się licencjonowana po zakupie licencji i dodaniu kilku linii kodu (aby zastosować licencję).
* Licencja jest zwykłym plikiem XML tekstowym, który zawiera szczegóły takie jak nazwa produktu, liczba deweloperów, do których jest licencjonowana, data wygaśnięcia subskrypcji i tak dalej. 
* Plik licencji jest cyfrowo podpisany, więc nie należy go modyfikować. Nawet niezamierzone dodanie dodatkowego znaku nowej linii do zawartości pliku unieważni go.
* Aspose.Slides for .NET zazwyczaj próbuje znaleźć licencję w następujących lokalizacjach:
  * Jawna ścieżka
  * Folder zawierający plik DLL komponentu (dołączony do Aspose.Slides)
  * Folder zawierający zestaw (assembly), który wywołał plik DLL komponentu (dołączony do Aspose.Slides)
  * Folder zawierający główny zestaw (entry assembly) (twój .exe)
  * Osadzony zasób w zestawie, który wywołał plik DLL komponentu (dołączony do Aspose.Slides).
* Aby uniknąć ograniczeń związanych z wersją ewaluacyjną, musisz ustawić licencję przed użyciem Aspose.Slides. Licencję trzeba ustawić tylko raz na aplikację lub proces.

{{% alert color="primary" %}} 

Możesz również zobaczyć [Metered Licensing](https://docs.aspose.com/slides/pl/net/metered-licensing/).

{{% /alert %}} 


## **Zastosowanie licencji**
Licencję można wczytać z **pliku**, **strumienia** lub **zasobu osadzonego**. 

{{% alert color="primary" %}}

Aspose.Slides udostępnia klasę [License](https://reference.aspose.com/slides/pl/net/aspose.slides/license) do operacji licencjonowania.

{{% /alert %}} 

{{% alert color="warning" %}} 

Nowe licencje mogą aktywować Aspose.Slides tylko w wersji 21.4 lub późniejszej. Wcześniejsze wersje używają innego systemu licencjonowania i nie rozpoznają tych licencji.

{{% /alert %}}

### **Plik**
Najłatwiejsza metoda ustawienia licencji wymaga umieszczenia pliku licencji w tym samym folderze, w którym znajduje się DLL komponentu (dołączony do Aspose.Slides) i podania jedynie nazwy pliku bez ścieżki.

Ten kod C# pokazuje, jak ustawić plik licencji:

``` csharp
// Tworzy instancję klasy License 
Aspose.Slides.License license = new Aspose.Slides.License();

// Ustawia ścieżkę pliku licencji
license.SetLicense("Aspose.Slides.lic");
```

{{% alert color="warning" %}} 

Jeśli umieścisz plik licencji w innym katalogu, przy wywołaniu metody [SetLicense](https://reference.aspose.com/slides/pl/net/aspose.slides/license/setlicense/#setlicense_1) nazwa pliku licencji na końcu podanej jawnej ścieżki musi być taka sama jak nazwą twojego pliku licencji.

Na przykład możesz zmienić nazwę pliku licencji na *Aspose.Slides.lic.xml*. Wtedy w kodzie musisz przekazać ścieżkę do pliku (kończącą się *Aspose.Slides.lic.xml*) do metody [SetLicense](https://reference.aspose.com/slides/pl/net/aspose.slides/license/setlicense/#setlicense_1).

{{% /alert %}}

### **Strumień**
Możesz wczytać licencję ze strumienia. Ten kod C# pokazuje, jak zastosować licencję ze strumienia:

``` csharp
// Tworzy instancję klasy License 
Aspose.Slides.License license = new Aspose.Slides.License();

// Ustawia licencję za pośrednictwem strumienia
license.SetLicense(myStream);
```

### **Zasób osadzony**
Możesz spakować licencję razem z aplikacją (aby nie zgubić jej), dodając licencję jako zasób osadzony do jednego z zestawów, które wywołują DLL komponentu (dołączony do Aspose.Slides). 

Tak dodajesz plik licencji jako zasób osadzony:

1. W Visual Studio dodaj plik licencji (.lic) do projektu w następujący sposób: przejdź do **File** > **Add Existing Item** > **Add**. 
2. Wybierz plik w **Solution Explorer**.
3. W oknie **Properties** ustaw **Build Action** na **Embedded Resource**.
4. Aby uzyskać dostęp do licencji osadzonej w zestawie, dodaj plik licencji jako zasób osadzony do projektu, a następnie przekaż nazwę pliku licencji do metody `SetLicense`. 


Klasa `License` automatycznie znajduje plik licencji w zasobach osadzonych. Nie musisz wywoływać metod `GetExecutingAssembly` i `GetManifestResourceStream` klasy `System.Reflection.Assembly` w Microsoft .NET Framework.

Ten kod C# pokazuje, jak ustawić licencję jako zasób osadzony:

``` csharp
// Tworzy instancję klasy License
Aspose.Slides.License license = new Aspose.Slides.License();

// Przekazuje nazwę pliku licencji osadzonego w zestawie
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

## **Bezpieczeństwo wątkowe**

{{% alert title="Uwaga" color="warning" %}} 

Metoda [license.SetLicense](https://reference.aspose.com/slides/pl/net/aspose.slides/license/setlicense/) nie jest bezpieczna wątkowo. Jeśli metoda ta ma być wywoływana jednocześnie z wielu wątków, rozważ użycie prymitywów synchronizacji (np. blokady), aby uniknąć problemów. 

{{% /alert %}}

## **FAQ**

**Czy mogę zastosować licencję w całkowicie offline środowisku (bez dostępu do Internetu)?**

Tak. Weryfikacja licencji odbywa się lokalnie przy użyciu pliku licencji; połączenie internetowe nie jest wymagane.

**Co się stanie po wygaśnięciu rocznej subskrypcji? Czy biblioteka przestanie działać?**

Nie. Licencja jest wieczysta: możesz nadal korzystać z wersji wydanych przed datą zakończenia subskrypcji; po prostu nie będziesz mógł używać nowszych wydań bez odnowienia.