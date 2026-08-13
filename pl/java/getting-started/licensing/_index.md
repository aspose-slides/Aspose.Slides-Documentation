---
title: Licencjonowanie
type: docs
weight: 90
url: /pl/java/licensing/
keywords:
- licencja
- licencja tymczasowa
- ustaw licencję
- użyj licencję
- weryfikuj licencję
- plik licencji
- wersja ewaluacyjna
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Zastosuj, zarządzaj i rozwiąż problemy z licencjami w Aspose.Slides for Java. Zapewnij nieprzerwaną dostępność pełnych funkcji dzięki naszemu przewodnikowi krok po kroku po licencjonowaniu."
---
## **Przegląd**

Aspose.Slides można używać w trybie ewaluacyjnym lub z ważną licencją. Wersja ewaluacyjna zapewnia tę samą funkcjonalność co wersja licencjonowana, ale dodaje znak wodny ewaluacji przy otwieraniu lub zapisywaniu prezentacji oraz ogranicza wyodrębnianie tekstu do jednego slajdu.

Ten artykuł wyjaśnia, jak działają licencje w Aspose.Slides oraz jak zastosować licencję przed użyciem biblioteki. Licencję można załadować z pliku, strumienia lub zasobu osadzonego przy użyciu klasy `License`. Artykuł pokazuje również, jak zweryfikować, czy licencja została poprawnie zastosowana.

## **Ewaluacja Aspose.Slides**

{{% alert color="info" %}} 

Możesz pobrać wersję ewaluacyjną **Aspose.Slides for Java** ze swojej [strony pobierania](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). Wersja ewaluacyjna zapewnia te same funkcje co licencjonowana wersja produktu. Pakiet ewaluacyjny jest taki sam jak zakupiony pakiet. Wersja ewaluacyjna po prostu staje się licencjonowana po dodaniu kilku linii kodu (aby zastosować licencję).

Gdy będziesz zadowolony z testowania **Aspose.Slides**, możesz [zakupić licencję](https://purchase.aspose.com/buy). Zalecamy zapoznanie się z różnymi typami subskrypcji. Jeśli masz pytania, skontaktuj się z zespołem sprzedaży Aspose.

Każda licencja Aspose zawiera roczną subskrypcję na bezpłatne aktualizacje do nowych wersji lub poprawek wydanych w okresie subskrypcji. Użytkownicy posiadający licencjonowane produkty (lub nawet wersje ewaluacyjne) otrzymują bezpłatne i nieograniczone wsparcie techniczne.

{{% /alert %}} 

**Ograniczenia wersji ewaluacyjnej**

* Chociaż wersja ewaluacyjna Aspose.Slides (bez określonej licencji) zapewnia pełną funkcjonalność produktu, wstawia znak wodny ewaluacji u góry dokumentu podczas operacji otwierania i zapisywania. 
* Masz ograniczenie do jednego slajdu przy wyodrębnianiu tekstu z prezentacji.

{{% alert color="info" %}} 

Aby przetestować Aspose.Slides bez ograniczeń, możesz poprosić o **30-dniową tymczasową licencję**. Zobacz stronę [Jak uzyskać tymczasową licencję](https://purchase.aspose.com/temporary-license) po więcej informacji.

{{% /alert %}}

## **Licencjonowanie w Aspose.Slides**

* Wersja ewaluacyjna staje się licencjonowana po zakupie licencji i dodaniu kilku linijek kodu (aby zastosować licencję).
* Licencja jest zwykłym plikiem XML w formacie tekstowym, który zawiera szczegóły, takie jak nazwa produktu, liczba programistów, którym jest licencjonowana, data wygaśnięcia subskrypcji i podobne. 
* Plik licencji jest podpisany cyfrowo, dlatego nie należy go modyfikować. Nawet przypadkowe dodanie dodatkowego znaku końca linii do zawartości pliku unieważni licencję.
* Aspose.Slides for Java zazwyczaj próbuje znaleźć licencję w następujących miejscach:
  * Ścieżka jawna
  * Folder zawierający Aspose.Slides.jar
* Aby uniknąć ograniczeń związanych z wersją ewaluacyjną, należy ustawić licencję przed użyciem **Aspose.Slides**. Licencję trzeba ustawić tylko raz na aplikację lub proces.

{{% alert color="info" %}} 

Możesz chcieć zobaczyć [Licencjonowanie rozliczane w zależności od zużycia](/slides/pl/java/metered-licensing/).

{{% /alert %}} 


## **Zastosowanie licencji**

Licencję można załadować z **pliku** lub **strumienia**.

{{% alert color="info" %}}

Aspose.Slides udostępnia klasę [License](https://reference.aspose.com/slides/pl/java/com.aspose.slides/License) do operacji licencyjnych.

{{% /alert %}} 

{{% alert color="warning" %}}

Nowe licencje mogą aktywować Aspose.Slides tylko w wersji 21.4 lub późniejszej. Wcześniejsze wersje używają innego systemu licencjonowania i nie rozpoznają tych licencji.

{{% /alert %}}

### **Plik**

Najprostszą metodą ustawienia licencji jest umieszczenie pliku licencji w folderze zawierającym Aspose.Slides.jar lub w jarze Twojej aplikacji.

Ten kod Java pokazuje, jak ustawić plik licencji:

``` java
// Tworzy instancję klasy License
com.aspose.slides.License license = new com.aspose.slides.License();

// Ustawia ścieżkę do pliku licencji
license.setLicense("Aspose.Slides.Java.lic");
```

{{% alert color="warning" %}} 

Jeśli umieścisz plik licencji w innym katalogu, wywołując metodę [SetLicense](https://reference.aspose.com/slides/pl/java/com.aspose.slides/License#setLicense-java.lang.String-), nazwa pliku licencji na końcu podanej ścieżki musi być taka sama jak Twoja licencja.

Na przykład możesz zmienić nazwę pliku licencji na *Aspose.Slides.Java.lic.xml*. Następnie w kodzie musisz przekazać ścieżkę do tego pliku (kończącą się na *Aspose.Slides.Java.lic.xml*) do metody [SetLicense](https://reference.aspose.com/slides/pl/java/com.aspose.slides/License#setLicense-java.lang.String-).

{{% /alert %}}

### **Strumień**

Możesz załadować licencję ze strumienia. Ten kod Java pokazuje, jak zastosować licencję ze strumienia:

``` java
// Tworzy instancję klasy License
com.aspose.slides.License license = new com.aspose.slides.License();

// Ustawia licencję za pomocą strumienia
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Java.lic"));
```

### **PHP/Java Bridge**

Jeśli używasz Aspose.Slides for PHP przez Java, możesz ustawić licencję za pośrednictwem mostu PHP/Java. Ten most pozwala używać klas Java w składni PHP. Więcej informacji znajdziesz w [License in PHP](/slides/pl/php-java/licensing/).

## **Weryfikacja licencji**

Aby sprawdzić, czy licencja została poprawnie ustawiona, możesz ją zweryfikować. Ten kod Java pokazuje, jak zweryfikować licencję:

```java
import com.aspose.slides.*;

License license = new License();
license.setLicense("Aspose.Slides.Java.lic");

if (license.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **Bezpieczeństwo wątków**

{{% alert title="Note" color="warning" %}} 

Metoda [SetLicense](https://reference.aspose.com/slides/pl/java/com.aspose.slides/License#setLicense-java.io.InputStream-) nie jest bezpieczna wątkowo. Jeśli metoda ma być wywoływana jednocześnie z wielu wątków, warto użyć prymitywów synchronizacji (takich jak blokada), aby uniknąć problemów. 

{{% /alert %}}

## **FAQ**

### Czy mogę zastosować licencję w całkowicie offline środowisku (bez dostępu do internetu)?

Tak. Walidacja licencji odbywa się lokalnie przy użyciu pliku licencji; połączenie internetowe nie jest wymagane.

### Co się dzieje po wygaśnięciu rocznej subskrypcji? Czy biblioteka przestanie działać?

Nie. Licencja jest wieczysta: możesz dalej używać wersji wydanych przed datą zakończenia subskrypcji; po prostu nie będziesz uprawniony do korzystania z nowszych wydań bez odnowienia.