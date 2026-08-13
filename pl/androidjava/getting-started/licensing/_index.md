---
title: Licencjonowanie
type: docs
weight: 90
url: /pl/androidjava/licensing/
keywords:
- licencja
- tymczasowa licencja
- ustaw licencję
- użyj licencji
- waliduj licencję
- plik licencji
- wersja ewaluacyjna
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Zastosuj, zarządzaj i rozwiązywuj problemy z licencjami w Aspose.Slides for Android via Java. Zapewnij nieprzerwany dostęp do pełnych funkcji dzięki naszemu przewodnikowi po licencjonowaniu."
---
## **Przegląd**

Aspose.Slides można używać w trybie ewaluacyjnym lub z ważną licencją. Wersja ewaluacyjna zapewnia tę samą funkcjonalność co wersja licencjonowana, ale dodaje znak wodny ewaluacji podczas otwierania lub zapisywania prezentacji oraz ogranicza wyodrębnianie tekstu do jednego slajdu.

Ten artykuł wyjaśnia, jak działa licencjonowanie w Aspose.Slides oraz jak zastosować licencję przed użyciem biblioteki. Licencję można załadować z pliku, strumienia lub zasobu osadzonego przy użyciu klasy `License`. Artykuł pokazuje również, jak zweryfikować, czy licencja została poprawnie zastosowana.

## **Ewaluacja Aspose.Slides**

{{% alert color="info" %}} 

Możesz pobrać wersję ewaluacyjną **Aspose.Slides for Android via Java** ze swojej [strony pobierania](https://releases.aspose.com/slides/pl/androidjava/). Wersja ewaluacyjna zapewnia te same funkcje co licencjonowana wersja produktu. Pakiet ewaluacyjny jest taki sam jak zakupiony pakiet. Wersja ewaluacyjna po prostu staje się licencjonowana po dodaniu kilku linii kodu (aby zastosować licencję).

Gdy będziesz zadowolony z ewaluacji **Aspose.Slides**, możesz [zakupić licencję](https://purchase.aspose.com/buy). Zalecamy zapoznanie się z różnymi typami subskrypcji. Jeśli masz pytania, skontaktuj się z zespołem sprzedaży Aspose.

Każda licencja Aspose zawiera roczną subskrypcję, umożliwiającą darmowe aktualizacje do nowych wersji lub poprawek wydanych w okresie subskrypcji. Użytkownicy posiadający licencjonowane produkty (lub nawet wersje ewaluacyjne) otrzymują darmowe i nieograniczone wsparcie techniczne.

{{% /alert %}} 

**Ograniczenia wersji ewaluacyjnej**

* Chociaż wersja ewaluacyjna Aspose.Slides (bez podanej licencji) zapewnia pełną funkcjonalność produktu, wstawia znak wodny ewaluacji u góry dokumentu podczas operacji otwierania i zapisywania. 
* Masz ograniczenie do jednego slajdu przy wyodrębnianiu tekstu z prezentacji.

{{% alert color="info" %}} 

Aby przetestować Aspose.Slides bez ograniczeń, możesz poprosić o **30‑dniową tymczasową licencję**. Zobacz stronę [How to get a Temporary License](https://purchase.aspose.com/temporary-license) po więcej informacji.

{{% /alert %}}

## **Licencjonowanie w Aspose.Slides**

* Wersja ewaluacyjna staje się licencjonowana po zakupie licencji i dodaniu kilku linii kodu (aby zastosować licencję).  
* Licencja jest zwykłym plikiem XML zawierającym takie informacje jak nazwa produktu, liczba deweloperów, którym jest licencjonowana, data wygaśnięcia subskrypcji i podobne.  
* Plik licencji jest cyfrowo podpisany, więc nie należy go modyfikować. Nawet niezamierzone dodanie dodatkowego znaku końca wiersza do zawartości pliku unieważni go.  
* Aspose.Slides for Android via Java zazwyczaj próbuje znaleźć licencję w następujących lokalizacjach:  
  * Ścieżka jawna  
  * Folder zawierający Aspose.Slides.jar  
* Aby uniknąć ograniczeń związanych z wersją ewaluacyjną, musisz ustawić licencję przed użyciem **Aspose.Slides**. Licencję trzeba ustawić tylko raz na aplikację lub proces.

## **Stosowanie licencji**

Licencję można załadować z **pliku** lub **strumienia**.

{{% alert color="info" %}}

Aspose.Slides udostępnia klasę [License](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/license/) do operacji licencjonowania.

{{% /alert %}} 

{{% alert color="warning" %}}

Nowe licencje mogą aktywować Aspose.Slides tylko w wersji 21.4 lub nowszej. Starsze wersje używają innego systemu licencjonowania i nie rozpoznają tych licencji.

{{% /alert %}}

### **Plik**

Najprostsza metoda ustawienia licencji wymaga umieszczenia pliku licencji w folderze zawierającym Aspose.Slides.jar lub w pliku JAR twojej aplikacji.

Ten kod Java pokazuje, jak ustawić plik licencji:

``` java
// Tworzy instancję klasy License
com.aspose.slides.License license = new com.aspose.slides.License();

// Ustawia ścieżkę do pliku licencji
license.setLicense("Aspose.Slides.Android.via.Java.lic");
```

{{% alert color="warning" %}} 

Jeśli umieścisz plik licencji w innym katalogu, przy wywołaniu metody [SetLicense](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) nazwa pliku licencji na końcu podanej ścieżki musi być taka sama jak Twoja rzeczywista nazwa pliku licencji.

Na przykład możesz zmienić nazwę pliku licencji na *Aspose.Slides.Android.via.Java.lic.xml*. Następnie w kodzie musisz przekazać ścieżkę do pliku (kończącą się *Aspose.Slides.Android.via.Java.lic.xml*) do metody [SetLicense](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-).

{{% /alert %}}

### **Strumień**

Możesz załadować licencję ze strumienia. Ten kod Java pokazuje, jak zastosować licencję ze strumienia:

``` java
// Tworzy instancję klasy License
com.aspose.slides.License license = new com.aspose.slides.License();

// Ustawia licencję za pomocą strumienia
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Android.via.Java.lic"));
```

## **Walidacja licencji**

Aby sprawdzić, czy licencja została poprawnie ustawiona, możesz ją zweryfikować. Ten kod Java pokazuje, jak walidować licencję:

```java
import com.aspose.slides.*;

License license = new License();
license.setLicense("Aspose.Slides.Android.via.Java.lic");

if (license.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **Bezpieczeństwo wątków**

{{% alert title="Note" color="warning" %}} 

Metoda [SetLicense](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) nie jest bezpieczna w środowiskach wielowątkowych. Jeśli metoda ta musi być wywoływana jednocześnie z wielu wątków, warto użyć prymitywów synchronizacji (np. blokady), aby uniknąć problemów. 

{{% /alert %}}

## **FAQ**

### Czy mogę zastosować licencję w całkowicie offline środowisku (bez dostępu do internetu)?

Tak. Walidacja licencji odbywa się lokalnie przy użyciu pliku licencji; połączenie internetowe nie jest wymagane.

### Co się stanie po wygaśnięciu rocznej subskrypcji? Czy biblioteka przestanie działać?

Nie. Licencja jest wieczysta: możesz nadal używać wersji wydanych przed datą zakończenia subskrypcji; po prostu nie będziesz uprawniony do korzystania z nowszych wydań bez odnowienia subskrypcji.