---
title: Licencjonowanie
type: docs
weight: 90
url: /pl/androidjava/licensing/
keywords:
- licencja
- licencja tymczasowa
- ustaw licencję
- użyj licencji
- zweryfikuj licencję
- plik licencji
- wersja ewaluacyjna
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Zastosuj, zarządzaj i rozwiąż problemy z licencjami w Aspose.Slides dla Android via Java. Zapewnij nieprzerwany dostęp do pełnych funkcji dzięki naszemu przewodnikowi po licencjonowaniu."
---
## **Przegląd**

Aspose.Slides można używać w trybie ewaluacyjnym lub z ważną licencją. Wersja ewaluacyjna zapewnia taką samą funkcjonalność jak wersja licencjonowana, ale dodaje znak wodny ewaluacji do każdego slajdu każdej prezentacji, którą zapisuje, oraz obcina tekst odczytywany przez Twój kod z prezentacji.

Ten artykuł wyjaśnia, jak działa licencjonowanie w Aspose.Slides i jak zastosować licencję przed użyciem biblioteki. Licencję można załadować z pliku, strumienia lub zasobu osadzonego przy użyciu klasy [License](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/). Artykuł pokazuje także, jak zweryfikować, czy licencja została poprawnie zastosowana.

## **Ewaluacja Aspose.Slides**

{{% alert color="info" title="Note" %}}

Możesz pobrać wersję ewaluacyjną **Aspose.Slides for Android via Java** z jego [strony pobierania](https://releases.aspose.com/slides/androidjava/). Wersja ewaluacyjna oferuje taką samą funkcjonalność jak licencjonowana wersja produktu. Pakiet ewaluacyjny jest taki sam jak zakupiony pakiet. Wersja ewaluacyjna po prostu staje się licencjonowana po dodaniu kilku wierszy kodu (w celu zastosowania licencji).

Gdy będziesz zadowolony z ewaluacji **Aspose.Slides**, możesz [zakupić licencję](https://purchase.aspose.com/pricing/slides/android-java/). Zachęcamy do zapoznania się z różnymi typami subskrypcji. Jeśli masz pytania, skontaktuj się z zespołem sprzedaży Aspose.

Każda licencja Aspose obejmuje roczną subskrypcję uprawniającą do bezpłatnych aktualizacji do nowych wersji lub poprawek wydanych w okresie subskrypcji. Użytkownicy posiadający licencjonowane produkty (lub nawet wersje ewaluacyjne) otrzymują bezpłatne i nieograniczone wsparcie techniczne.

{{% /alert %}} 

**Ograniczenia wersji ewaluacyjnej**

* Wersja ewaluacyjna (bez określonej licencji) zapewnia pełną funkcjonalność produktu, ale dodaje pole tekstowe z znakiem wodnym ewaluacji do każdego slajdu każdej prezentacji, którą zapisuje.
* Tekst odczytywany przez Twój kod z prezentacji jest obcinany do kilku pierwszych znaków, po których następuje informacja o ograniczeniu ewaluacyjnym. Tekst zapisywany przez Twój kod jest zapisywany w całości.

{{% alert color="info" title="Note" %}}

Aby przetestować Aspose.Slides bez ograniczeń, możesz poprosić o **30‑dniową licencję tymczasową**. Zobacz stronę [How to get a Temporary License](https://purchase.aspose.com/temporary-license) po więcej informacji.

{{% /alert %}}

## **Licencjonowanie w Aspose.Slides**

* Wersja ewaluacyjna staje się licencjonowana po zakupie licencji i dodaniu kilku wierszy kodu (w celu zastosowania licencji).
* Licencja jest zwykłym plikiem XML, który zawiera szczegóły takie jak nazwa produktu, liczba programistów, którym jest licencjonowana, data wygaśnięcia subskrypcji itp.
* Plik licencji jest cyfrowo podpisany, więc nie należy go modyfikować. Nawet przypadkowe dodanie dodatkowego znaku nowej linii do zawartości pliku unieważni licencję.
* Aspose.Slides for Android via Java zazwyczaj próbuje znaleźć licencję w następujących lokalizacjach:
  * Jawna ścieżka
  * Katalog zawierający Aspose.Slides.jar
* Aby uniknąć ograniczeń związanych z wersją ewaluacyjną, musisz ustawić licencję przed użyciem **Aspose.Slides**. Licencję należy ustawić tylko raz na aplikację lub proces.

## **Zastosowanie licencji**

Licencję można załadować z **pliku** lub **strumienia**.

{{% alert color="info" title="Note" %}}

Aspose.Slides udostępnia klasę [License](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/) do operacji licencjonowania.

{{% /alert %}} 

{{% alert color="warning" title="Warning" %}}

Nowe licencje mogą aktywować Aspose.Slides tylko w wersji 21.4 lub późniejszej. Wcześniejsze wersje używają innego systemu licencjonowania i nie rozpoznają tych licencji.

{{% /alert %}}

### **Plik**

Najłatwiejsza metoda ustawienia licencji wymaga umieszczenia pliku licencji w katalogu zawierającym Aspose.Slides.jar lub w pliku JAR Twojej aplikacji.

{{% alert color="info" title="Note" %}}

Na Androidzie biblioteka i Twoja aplikacja są pakowane w plik APK, więc nie istnieje folder zawierający plik JAR biblioteki, a względna ścieżka taka jak *Aspose.Slides.Android.via.Java.lic* nie wskazuje na plik w Twojej aplikacji. Dodaj plik licencji do zasobów aplikacji i załaduj go ze strumienia, jak pokazano w sekcji [Stream from App Assets](#stream-from-app-assets).

{{% /alert %}}

Ten kod Java pokazuje, jak ustawić plik licencji:

``` java
// Instancjonuje klasę License
com.aspose.slides.License license = new com.aspose.slides.License();

// Ustawia ścieżkę do pliku licencji
license.setLicense("Aspose.Slides.Android.via.Java.lic");
```

{{% alert color="warning" title="Warning" %}}

Jeśli umieścisz plik licencji w innym katalogu, przy wywołaniu metody [setLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) nazwa pliku licencji na końcu podanej ścieżki musi być taka sama jak nazwa Twojego pliku licencji.

Na przykład możesz zmienić nazwę pliku licencji na *Aspose.Slides.Android.via.Java.lic.xml*. Wtedy w kodzie musisz przekazać ścieżkę do pliku (kończącą się *Aspose.Slides.Android.via.Java.lic.xml*) do metody [setLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-).

{{% /alert %}}

### **Strumień**

Możesz załadować licencję ze strumienia. Ten kod Java pokazuje, jak zastosować licencję ze strumienia:

``` java
// Instancjonuje klasę License
com.aspose.slides.License license = new com.aspose.slides.License();

// Ustawia licencję przy użyciu strumienia
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Android.via.Java.lic"));
```

### **Strumień z zasobów aplikacji**

W aplikacji Android umieść plik licencji w folderze *assets* modułu aplikacji, *app/src/main/assets*, aby został spakowany do pliku APK. Otwórz plik metodą [getAssets](https://developer.android.com/reference/android/content/Context#getAssets()) i przekaż strumień do metody [setLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-). Kod uruchamiany jest wewnątrz `Activity`, np. w metodzie `onCreate`, przed użyciem Aspose.Slides przez aplikację:

```java
import android.util.Log;
import com.aspose.slides.License;
import java.io.IOException;
import java.io.InputStream;

License license = new License();
try (InputStream licenseStream = getAssets().open("Aspose.Slides.Android.via.Java.lic")) {
    license.setLicense(licenseStream);
} catch (IOException exception) {
    Log.e("Licensing", "Cannot read the license file from the app's assets.", exception);
}
```

Nazwa pliku przekazywana do metody [open](https://developer.android.com/reference/android/content/res/AssetManager#open(java.lang.String)) jest względna względem folderu *assets*. Jeśli pliku tam nie ma, kod loguje błąd i Aspose.Slides pozostaje w trybie ewaluacyjnym. Aby sprawdzić, czy licencja została zastosowana, zobacz sekcję [Validating a License](#validating-a-license).

## **Walidacja licencji**

Aby sprawdzić, czy licencja została poprawnie ustawiona, możesz ją zwalidować. Ten kod Java pokazuje, jak zwalidować licencję:

```java
import com.aspose.slides.*;

License license = new License();
license.setLicense("Aspose.Slides.Android.via.Java.lic");

if (license.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **Bezpieczeństwo wątkowe**

{{% alert color="warning" title="Warning" %}}

Metoda [setLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) nie jest bezpieczna wątkowo. Jeśli metoda ta ma być wywoływana jednocześnie z wielu wątków, warto użyć prymitywów synchronizacji (np. blokady), aby uniknąć problemów.

{{% /alert %}}

## **FAQ**

### Czy mogę zastosować licencję w całkowicie offline środowisku (bez dostępu do Internetu)?

Tak. Walidacja licencji odbywa się lokalnie przy użyciu pliku licencji; połączenie internetowe nie jest wymagane.

### Co się dzieje po wygaśnięciu rocznej subskrypcji? Czy biblioteka przestanie działać?

Nie. Licencja jest wieczysta: możesz nadal korzystać z wersji wydanych przed datą zakończenia subskrypcji; po prostu nie będziesz uprawniony do korzystania z nowszych wydań bez odnowienia.