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
description: "Zastosuj, zarządzaj i rozwiązuj problemy z licencjami w Aspose.Slides for Java. Zapewnij nieprzerwany dostęp do pełnych funkcji dzięki naszemu przewodnikowi krok po kroku po licencjonowaniu."
---
## **Przegląd**

Aspose.Slides może być używany w trybie ewaluacyjnym lub z ważną licencją. Wersja ewaluacyjna zapewnia taką samą funkcjonalność jak wersja licencjonowana, ale dodaje znak wodny ewaluacji do każdego slajdu każdej prezentacji, którą zapisuje, oraz przycina tekst odczytywany przez API.

Ten artykuł wyjaśnia, jak działa licencjonowanie w Aspose.Slides oraz jak zastosować licencję przed użyciem biblioteki. Licencję można załadować z pliku, strumienia lub zasobu osadzonego przy użyciu klasy `License`. Artykuł pokazuje również, jak zweryfikować, czy licencja została zastosowana prawidłowo.

## **Ewaluacja Aspose.Slides**

{{% alert color="info" title="Note" %}}

Możesz pobrać wersję ewaluacyjną **Aspose.Slides for Java** z jego [strona pobierania](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). Wersja ewaluacyjna zapewnia te same funkcje co licencjonowana wersja produktu. Pakiet ewaluacyjny jest taki sam jak zakupiony pakiet. Wersja ewaluacyjna po prostu staje się licencjonowana po dodaniu kilku linii kodu (aby zastosować licencję).

Gdy będziesz zadowolony z ewaluacji **Aspose.Slides**, możesz [zakupić licencję](https://purchase.aspose.com/pricing/slides/pl/java/). Zalecamy zapoznanie się z różnymi typami subskrypcji. Jeśli masz pytania, skontaktuj się z zespołem sprzedaży Aspose.

Każda licencja Aspose zawiera roczną subskrypcję na bezpłatne aktualizacje do nowych wersji lub poprawek wydanych w okresie subskrypcji. Użytkownicy posiadający licencjonowane produkty (lub nawet wersje ewaluacyjne) otrzymują bezpłatne i nieograniczone wsparcie techniczne.

{{% /alert %}} 

**Ograniczenia wersji ewaluacyjnej**

* Wersja ewaluacyjna (bez określonej licencji) zapewnia pełną funkcjonalność produktu, ale dodaje pole tekstowe z znakiem wodnym ewaluacji do każdego slajdu każdej prezentacji, którą zapisuje.
* Tekst odczytywany przez API, w tym tekst właśnie ustawiony, jest przycinany do kilku pierwszych znaków, po których pojawia się informacja o ograniczeniu ewaluacji. Tekst zapisywany przez API jest zachowywany w całości.

{{% alert color="info" title="Note" %}}

Aby przetestować Aspose.Slides bez ograniczeń, możesz poprosić o **30‑dniową licencję tymczasową**. Zobacz stronę [Jak uzyskać licencję tymczasową](https://purchase.aspose.com/temporary-license) po więcej informacji.

{{% /alert %}}

## **Licencjonowanie w Aspose.Slides**

* Wersja ewaluacyjna staje się licencjonowana po zakupie licencji i dodaniu kilku linii kodu (aby zastosować licencję).
* Licencja to zwykły plik XML zawierający szczegóły, takie jak nazwa produktu, liczba programistów, dla których jest licencjonowana, data wygaśnięcia subskrypcji itp.
* Plik licencji jest cyfrowo podpisany, więc nie wolno go modyfikować. Nawet niezamierzone dodanie dodatkowego znaku nowej linii do zawartości pliku spowoduje jego unieważnienie.
* Aspose.Slides for Java zwykle szuka licencji w następujących miejscach:
  * Jawna ścieżka
  * Folder zawierający Aspose.Slides.jar
* Aby uniknąć ograniczeń wersji ewaluacyjnej, musisz ustawić licencję przed użyciem **Aspose.Slides**. Licencję należy ustawić tylko raz na aplikację lub proces.

{{% alert color="info" title="Note" %}}

Możesz chcieć zobaczyć [Licencjonowanie metered](/slides/pl/java/metered-licensing/).

{{% /alert %}} 


## **Zastosowanie licencji**

Licencję można załadować z **pliku** lub **strumienia**.

{{% alert color="info" title="Note" %}}

Aspose.Slides udostępnia klasę [License](https://reference.aspose.com/slides/pl/java/com.aspose.slides/license/) do operacji licencjonowania.

{{% /alert %}} 

{{% alert color="warning" title="Warning" %}}

Nowe licencje mogą aktywować Aspose.Slides tylko w wersji 21.4 lub nowszej. Wcześniejsze wersje używają innego systemu licencjonowania i nie rozpoznają tych licencji.

{{% /alert %}}

### **Plik**

Najłatwiejsza metoda ustawienia licencji wymaga umieszczenia pliku licencji w folderze zawierającym Aspose.Slides.jar lub w Twoim pliku JAR aplikacji.

Ten kod Java pokazuje, jak ustawić plik licencji:

``` java
// Tworzy instancję klasy License
com.aspose.slides.License license = new com.aspose.slides.License();

// Ustawia ścieżkę do pliku licencji
license.setLicense("Aspose.Slides.Java.lic");
```

{{% alert color="warning" title="Warning" %}}

Jeśli umieścisz plik licencji w innym katalogu, przy wywołaniu metody [setLicense](https://reference.aspose.com/slides/pl/java/com.aspose.slides/license/#setLicense-java.lang.String-) nazwa pliku licencji na końcu określonej ścieżki musi być taka sama jak Twoja nazwa pliku licencji.

Na przykład możesz zmienić nazwę pliku licencji na *Aspose.Slides.Java.lic.xml*. Następnie w kodzie musisz przekazać ścieżkę do tego pliku (kończącą się *Aspose.Slides.Java.lic.xml*) metodzie [setLicense](https://reference.aspose.com/slides/pl/java/com.aspose.slides/license/#setLicense-java.lang.String-).

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

Jeśli używasz Aspose.Slides for PHP poprzez Java, możesz ustawić licencję przez most PHP/Java. Ten most umożliwia używanie klas Java w składni PHP. Po więcej informacji zobacz [Licencja w PHP](/slides/pl/php-java/licensing/).

## **Walidacja licencji**

Aby sprawdzić, czy licencja została poprawnie ustawiona, możesz ją zwalidować. Ten kod Java pokazuje, jak zwalidować licencję:

```java
import com.aspose.slides.*;

License license = new License();
license.setLicense("Aspose.Slides.Java.lic");

if (license.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **Bezpieczeństwo wątkowe**

{{% alert color="warning" title="Warning" %}}

Metoda [setLicense](https://reference.aspose.com/slides/pl/java/com.aspose.slides/license/#setLicense-java.io.InputStream-) nie jest bezpieczna wątkowo. Jeśli metoda ta ma być wywoływana jednocześnie z wielu wątków, rozważ użycie prymitywów synchronizacji (np. blokady), aby uniknąć problemów.

{{% /alert %}}

## **FAQ**

### Czy mogę zastosować licencję w całkowicie offline środowisku (bez dostępu do internetu)?

Tak. Walidacja licencji odbywa się lokalnie przy użyciu pliku licencji; połączenie internetowe nie jest wymagane.

### Co się dzieje po wygaśnięciu rocznej subskrypcji? Czy biblioteka przestanie działać?

Nie. Licencja jest wieczysta: możesz nadal używać wersji wydanych przed datą wygaśnięcia subskrypcji; po prostu nie będziesz kwalifikował się do nowszych wydań bez odnowienia.