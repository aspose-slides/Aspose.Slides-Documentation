---
title: Licencjonowanie
type: docs
weight: 90
url: /pl/java/licensing/
keywords:
- licencja
- licencja tymczasowa
- ustawianie licencji
- używanie licencji
- weryfikacja licencji
- plik licencji
- wersja ewaluacyjna
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Zastosuj, zarządzaj i rozwiązuj problemy z licencjami w Aspose.Slides dla Javy. Zapewnij nieprzerwany dostęp do pełnych funkcji dzięki naszemu przewodnikowi krok po kroku poświęconemu licencjonowaniu."
---
## **Przegląd**

Aspose.Slides można używać w trybie ewaluacyjnym lub z ważną licencją. Wersja ewaluacyjna zapewnia taką samą funkcjonalność jak wersja licencjonowana, ale dodaje znak wodny ewaluacji przy otwieraniu lub zapisywaniu prezentacji oraz ogranicza wyodrębnianie tekstu do jednego slajdu.

Ten artykuł opisuje, jak działa licencjonowanie w Aspose.Slides oraz jak zastosować licencję przed użyciem biblioteki. Licencja może być wczytana z pliku, strumienia lub zasobu osadzonego przy użyciu klasy `License`. Artykuł pokazuje również, jak zweryfikować, czy licencja została poprawnie zastosowana.

## **Ewaluacja Aspose.Slides**

{{% alert color="primary" %}} 

Możesz pobrać wersję ewaluacyjną **Aspose.Slides for Java** ze swojej [strony pobierania](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). Wersja ewaluacyjna oferuje te same funkcje, co wersja licencjonowana produktu. Pakiet ewaluacyjny jest taki sam jak zakupiony pakiet. Wersja ewaluacyjna po prostu staje się licencjonowana po dodaniu kilku linii kodu (aby zastosować licencję).

Gdy będziesz zadowolony z ewaluacji **Aspose.Slides**, możesz [zakupić licencję](https://purchase.aspose.com/buy). Zalecamy zapoznanie się z różnymi typami subskrypcji. Jeśli masz pytania, skontaktuj się z zespołem sprzedaży Aspose.

Każda licencja Aspose zawiera roczną subskrypcję uprawniającą do bezpłatnych aktualizacji do nowych wersji lub poprawek wydanych w okresie subskrypcji. Użytkownicy posiadający licencjonowane produkty (nawet wersje ewaluacyjne) otrzymują darmowe i nieograniczone wsparcie techniczne.

{{% /alert %}} 

**Ograniczenia wersji ewaluacyjnej**

* Chociaż wersja ewaluacyjna Aspose.Slides (bez podanej licencji) zapewnia pełną funkcjonalność produktu, wstawia znak wodny ewaluacji na górze dokumentu podczas operacji otwierania i zapisywania.  
* Masz ograniczenie do jednego slajdu przy wyodrębnianiu tekstu z prezentacji.

{{% alert color="primary" %}} 

Aby przetestować Aspose.Slides bez ograniczeń, możesz poprosić o **30‑dniową Tymczasową Licencję**. Zobacz stronę [Jak uzyskać tymczasową licencję](https://purchase.aspose.com/temporary-license) po więcej informacji.

{{% /alert %}}

## **Licencjonowanie w Aspose.Slides**

* Wersja ewaluacyjna staje się licencjonowana po zakupie licencji i dodaniu kilku linii kodu (aby zastosować licencję).  
* Licencja jest plikiem XML w formacie tekstowym, który zawiera szczegóły takie jak nazwa produktu, liczba programistów, do których jest licencjonowana, data wygaśnięcia subskrypcji i inne.  
* Plik licencji jest cyfrowo podpisany, więc nie należy go modyfikować. Nawet przypadkowe dodanie dodatkowego znaku nowej linii do zawartości pliku unieważni go.  
* Aspose.Slides for Java zazwyczaj poszukuje licencji w następujących lokalizacjach:  
  * Ścieżka jawna  
  * Folder zawierający Aspose.Slides.jar  

* Aby uniknąć ograniczeń związanych z wersją ewaluacyjną, musisz ustawić licencję przed użyciem **Aspose.Slides**. Licencję trzeba ustawić tylko raz na aplikację lub proces.

{{% alert color="primary" %}} 

Możesz chcieć zobaczyć [Licencjonowanie rozliczane](/slides/pl/java/metered-licensing/).

{{% /alert %}} 

## **Zastosowanie licencji**

Licencję można wczytać z **pliku** lub **strumienia**.

{{% alert color="primary" %}}

Aspose.Slides udostępnia klasę [License](https://reference.aspose.com/slides/pl/java/com.aspose.slides/License) do operacji licencjonowania.

{{% /alert %}} 

{{% alert color="warning" %}}

Nowe licencje mogą aktywować Aspose.Slides tylko w wersji 21.4 lub nowszej. Wcześniejsze wersje używają innego systemu licencjonowania i nie rozpoznają tych licencji.

{{% /alert %}}

### **Plik**

Najłatwiejsza metoda ustawienia licencji wymaga umieszczenia pliku licencji w folderze zawierającym Aspose.Slides.jar lub w pliku JAR Twojej aplikacji.

Ten kod Java pokazuje, jak ustawić plik licencji:

``` java
// Tworzy instancję klasy License
com.aspose.slides.License license = new com.aspose.slides.License();

// Ustawia ścieżkę do pliku licencji
license.setLicense("Aspose.Slides.Java.lic");
```

{{% alert color="warning" %}} 

Jeśli umieścisz plik licencji w innym katalogu, wywołując metodę [SetLicense](https://reference.aspose.com/slides/pl/java/com.aspose.slides/License#setLicense-java.lang.String-), nazwa pliku licencji na końcu podanej ścieżki musi być taka sama jak Twoja licencja.

Na przykład możesz zmienić nazwę pliku licencji na *Aspose.Slides.Java.lic.xml*. Wtedy w kodzie musisz przekazać ścieżkę do pliku (kończącą się na *Aspose.Slides.Java.lic.xml*) do metody [SetLicense](https://reference.aspose.com/slides/pl/java/com.aspose.slides/License#setLicense-java.lang.String-).

{{% /alert %}}

### **Strumień**

Możesz wczytać licencję ze strumienia. Ten kod Java pokazuje, jak zastosować licencję ze strumienia:

``` java
// Tworzy instancję klasy License
com.aspose.slides.License license = new com.aspose.slides.License();

// Ustawia licencję za pomocą strumienia
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Java.lic"));
```

### **PHP/Java Bridge**

Jeśli używasz Aspose.Slides for PHP poprzez Java, możesz ustawić licencję za pośrednictwem mostu PHP/Java. Ten most pozwala używać klas Java w składni PHP. Więcej informacji znajdziesz w [Licencja w PHP](/slides/pl/php-java/licensing/).

## **Weryfikacja licencji**

Aby sprawdzić, czy licencja została poprawnie ustawiona, możesz ją zweryfikować. Ten kod Java pokazuje, jak zweryfikować licencję:

```java
License license = new License();
license.setLicense("Aspose.Slides.Java.lic");

if (License.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **Bezpieczeństwo wątków**

{{% alert title="Note" color="warning" %}} 

Metoda [SetLicense](https://reference.aspose.com/slides/pl/java/com.aspose.slides/License#setLicense-java.io.InputStream-) nie jest bezpieczna wątkowo. Jeśli metoda ta ma być wywoływana jednocześnie z wielu wątków, warto użyć mechanizmów synchronizacji (takich jak blokada), aby uniknąć problemów. 

{{% /alert %}}

## **FAQ**

**Czy mogę zastosować licencję w całkowicie offline środowisku (bez dostępu do internetu)?**

Tak. Weryfikacja licencji odbywa się lokalnie przy użyciu pliku licencji; połączenie z internetem nie jest wymagane.

**Co się dzieje po wygaśnięciu rocznej subskrypcji? Czy biblioteka przestanie działać?**

Nie. Licencja jest wieczysta: możesz nadal używać wersji wydanych przed datą zakończenia subskrypcji; po prostu nie będziesz uprawniony do korzystania z nowszych wydań bez odnowienia.