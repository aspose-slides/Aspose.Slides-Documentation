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
description: "Zastosuj, zarządzaj i rozwiąż problemy z licencjami w Aspose.Slides dla .NET. Zapewnij nieprzerwany dostęp do pełnych funkcji dzięki naszemu krok po kroku przewodnikowi po licencjonowaniu."
---
## **Przegląd**

Aspose.Slides może być używany w trybie ewaluacyjnym lub z ważną licencją. Wersja ewaluacyjna zapewnia taką samą funkcjonalność jak wersja licencjonowana, ale dodaje znak wodny ewaluacji przy otwieraniu lub zapisywaniu prezentacji oraz ogranicza wyodrębnianie tekstu do jednego slajdu.

Ten artykuł wyjaśnia, jak działa licencjonowanie w Aspose.Slides oraz jak zastosować licencję przed użyciem biblioteki. Licencję można wczytać z pliku, strumienia lub zasobu osadzonego przy użyciu klasy `License`. Artykuł pokazuje także, jak zweryfikować, czy licencja została poprawnie zastosowana.

## **Ewaluacja Aspose.Slides**

{{% alert color="info" %}} 

Możesz pobrać wersję ewaluacyjną **Aspose.Slides for NET** z [its NuGet download page](https://www.nuget.org/packages/Aspose.Slides.NET/). Wersja ewaluacyjna zapewnia te same funkcje co licencjonowana wersja produktu. Pakiet ewaluacyjny jest identyczny z pakietem zakupionym. Wersja ewaluacyjna po prostu staje się licencjonowana po dodaniu kilku linii kodu (aby zastosować licencję).

Gdy będziesz zadowolony z testowania **Aspose.Slides**, możesz [purchase a license](https://purchase.aspose.com/buy). Zalecamy zapoznanie się z różnymi typami subskrypcji. Jeśli masz pytania, skontaktuj się z zespołem sprzedaży Aspose.

Każda licencja Aspose jest dostarczana z roczną subskrypcją obejmującą bezpłatne aktualizacje do nowych wersji oraz poprawki wydane w okresie subskrypcji. Użytkownicy posiadający licencjonowane produkty lub nawet wersje ewaluacyjne otrzymują bezpłatne i nieograniczone wsparcie techniczne.

{{% /alert %}} 

**Ograniczenia wersji ewaluacyjnej**

* Chociaż wersja ewaluacyjna Aspose.Slides (bez określonej licencji) zapewnia pełną funkcjonalność produktu, wstawia znak wodny ewaluacji na górze dokumentu przy operacjach otwierania i zapisywania. 
* Przy wyodrębnianiu tekstu z slajdów jesteś ograniczony do jednego slajdu.

{{% alert color="info" %}} 

Aby przetestować Aspose.Slides bez ograniczeń, możesz poprosić o **30‑dniową tymczasową licencję**. Zobacz stronę [How to get a Temporary License](https://purchase.aspose.com/temporary-license) po więcej informacji.

{{% /alert %}}

## **Licencjonowanie w Aspose.Slides**
* Wersja ewaluacyjna staje się licencjonowana po zakupie licencji i dodaniu kilku linii kodu (aby zastosować licencję).
* Licencja jest zwykłym plikiem XML zawierającym informacje takie jak nazwa produktu, liczba programistów, do których jest licencjonowana, data wygaśnięcia subskrypcji itp. 
* Plik licencji jest cyfrowo podpisany, więc nie należy go modyfikować. Nawet przypadkowe dodanie dodatkowego znaku końca linii do zawartości pliku spowoduje jego unieważnienie.
* Aspose.Slides for .NET zazwyczaj próbuje znaleźć licencję w następujących lokalizacjach:
  * Podana explicite ścieżka
  * Folder zawierający dll komponentu (dołączony w Aspose.Slides)
  * Folder zawierający zestaw, który wywołał dll komponentu (dołączony w Aspose.Slides)
  * Folder zawierający zestaw wejściowy (twój .exe)
  * Zasób osadzony w zestawie, który wywołał dll komponentu (dołączony w Aspose.Slides).
* Aby uniknąć ograniczeń związanych z wersją ewaluacyjną, musisz ustawić licencję przed użyciem Aspose.Slides. Licencję trzeba ustawić tylko raz na aplikację lub proces.

{{% alert color="info" %}} 

Możesz chcieć zobaczyć [Metered Licensing](https://docs.aspose.com/slides/pl/net/metered-licensing/).

{{% /alert %}} 


## **Zastosowanie licencji**
Licencję można wczytać z **pliku**, **strumienia** lub **zasobu osadzonego**. 

{{% alert color="info" %}}

Aspose.Slides udostępnia klasę [License](https://reference.aspose.com/slides/pl/net/aspose.slides/license) do operacji licencjonowania.

{{% /alert %}} 

{{% alert color="warning" %}} 

Nowe licencje mogą aktywować Aspose.Slides wyłącznie w wersji 21.4 lub późniejszej. Wcześniejsze wersje używają innego systemu licencjonowania i nie rozpoznają tych licencji.

{{% /alert %}}

### **Plik**
Najprostszą metodą ustawienia licencji jest umieszczenie pliku licencyjnego w tym samym folderze co DLL komponentu (dołączony w Aspose.Slides) i podanie jedynie nazwy pliku bez ścieżki.

Ten kod C# pokazuje, jak ustawić plik licencji:

``` csharp
// Tworzy instancję klasy License
Aspose.Slides.License license = new Aspose.Slides.License();

// Ustawia ścieżkę do pliku licencji
license.SetLicense("Aspose.Slides.lic");
```

{{% alert color="warning" %}} 

Jeśli umieścisz plik licencji w innym katalogu, przy wywołaniu metody [SetLicense](https://reference.aspose.com/slides/pl/net/aspose.slides/license/setlicense/#setlicense_1) nazwa pliku licencji na końcu podanej ścieżki musi być taka sama jak w rzeczywistym pliku licencji.

Na przykład możesz zmienić nazwę pliku licencji na *Aspose.Slides.lic.xml*. Następnie w kodzie musisz przekazać ścieżkę do pliku (kończącą się *Aspose.Slides.lic.xml*) do metody [SetLicense](https://reference.aspose.com/slides/pl/net/aspose.slides/license/setlicense/#setlicense_1).

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
Możesz spakować licencję razem z aplikacją (aby nie stracić jej) dodając licencję jako zasób osadzony do jednego z zestawów, które wywołują DLL komponentu (dołączony w Aspose.Slides). 

Tak dodaje się plik licencji jako zasób osadzony:

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

## **Walidacja licencji**

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

{{% alert title="Note" color="warning" %}} 

Metoda [license.SetLicense](https://reference.aspose.com/slides/pl/net/aspose.slides/license/setlicense/) nie jest bezpieczna wątkowo. Jeśli metoda ta musi być wywoływana jednocześnie z wielu wątków, warto użyć prymitywów synchronizacji (np. blokady), aby uniknąć problemów. 

{{% /alert %}}

## **FAQ**

### Czy mogę zastosować licencję w całkowicie środowisku offline (bez dostępu do Internetu)?

Tak. Walidacja licencji odbywa się lokalnie przy użyciu pliku licencji; połączenie internetowe nie jest wymagane.

### Co się stanie po wygaśnięciu rocznej subskrypcji? Czy biblioteka przestanie działać?

Nie. Licencja jest trwała: możesz nadal używać wersji wydanych przed datą zakończenia subskrypcji; po prostu nie będziesz uprawniony do korzystania z nowszych wydań bez odnowienia.