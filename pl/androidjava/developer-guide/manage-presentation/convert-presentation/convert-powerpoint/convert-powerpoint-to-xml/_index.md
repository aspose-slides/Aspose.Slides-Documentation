---
title: Konwertuj prezentacje PowerPoint na XML w Androidzie
linktitle: PowerPoint na XML
type: docs
weight: 145
url: /pl/androidjava/convert-powerpoint-to-xml/
keywords:
- konwertuj PowerPoint na XML
- konwertuj prezentację na XML
- PPT na XML
- PPTX na XML
- ODP na XML
- Prezentacja PowerPoint XML
- SaveFormat.Xml
- zapisz prezentację jako XML
- wyeksportuj prezentację do XML
- strumień XML
- Android
- Java
- Aspose.Slides
description: "Konwertuj prezentacje PowerPoint i OpenDocument na pliki lub strumienie PowerPoint XML w Androidzie przy użyciu Aspose.Slides."
---
## **Przegląd**

Aspose.Slides for Android via Java może konwertować prezentacje PowerPoint do formatu PowerPoint XML Presentation. Wyjście XML jest przydatne, gdy potrzebna jest reprezentacja tekstowa do analizowania struktury prezentacji, rozwiązywania problemów z wygenerowanymi dokumentami, porównywania wyników w testach automatycznych lub integracji z przepływem pracy, który konsumuje XML zamiast pakietu prezentacji.

Użyj metody [Presentation.save](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) z [SaveFormat.Xml](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/saveformat/#Xml). Wynik można zapisać bezpośrednio do pliku lub do strumienia.

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` tworzy PowerPoint XML Presentation. Nie wyodrębnia poszczególnych części Office Open XML przechowywanych w pakiecie PPTX. Jeśli potrzebne są dokładne części pakietu PPTX, takie jak `ppt/presentation.xml` lub indywidualne pliki XML slajdów, należy przeanalizować sam pakiet PPTX.
{{% /alert %}}

## **Konwertuj prezentację na plik XML**

Załaduj prezentację źródłową przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) , a następnie przekaż ścieżkę wyjściową i [SaveFormat.Xml](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/saveformat/#Xml) do [Presentation.save](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-). Źródło może być w dowolnym formacie prezentacji obsługiwanym przy ładowaniu, takim jak PPT, PPTX lub ODP.

Poniższy przykład konwertuje prezentację PPTX na plik XML:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.xml", SaveFormat.Xml);
} finally {
    presentation.dispose();
}
```

## **Zapisz wyjście XML do strumienia**

Użyj przeciążenia strumieniowego metody [Presentation.save](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) , gdy XML musi pozostać w pamięci lub być przekazane do innego komponentu, takiego jak usługa sieciowa, dostawca przechowywania lub potok przetwarzania XML. Poniższy przykład zapisuje wynik do [ByteArrayOutputStream](https://developer.android.com/reference/java/io/ByteArrayOutputStream) i uzyskuje wygenerowane XML jako tablicę bajtów:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ByteArrayOutputStream xmlStream = new ByteArrayOutputStream();
    try {
        presentation.save(xmlStream, SaveFormat.Xml);
        byte[] xmlData = xmlStream.toByteArray();

        // Przekaż xmlData do następnego komponentu w przepływie pracy.
    } finally {
        xmlStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Porównaj XML z formatami prezentacji i eksportu**

Wybierz format wyjściowy w zależności od tego, jak wynik będzie używany:

| Format | Wyjście | Typowe zastosowanie |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Prezentacja PowerPoint XML | Analiza struktury, rozwiązywanie problemów, porównywanie wygenerowanego wyniku i integracja oparta na XML |
| PPT (`.ppt`) | Starszy plik prezentacji binarny | Kompatybilność ze starszymi przepływami pracy PowerPoint |
| PPTX (`.pptx`) | Pakiet Office Open XML zawierający wiele części | Standardowa edycja PowerPoint i wymiana prezentacji |
| PDF or TIFF | Strony o stałym układzie lub obraz wielostronicowy | Wyświetlanie, drukowanie i archiwizacja |
| PNG, JPEG, or SVG | Wizualna reprezentacja pojedynczego slajdu | Miniatury, podglądy i zasoby graficzne |
| HTML or HTML5 | Wyjście prezentacji skierowane do sieci | Wyświetlanie w przeglądarce i publikowanie w sieci |

W odróżnieniu od PPT i PPTX, wyjście XML jest głównie przeznaczone do inspekcji i przepływów pracy zorientowanych na dane. W odróżnieniu od PDF, TIFF, HTML i formatów obrazów slajdów, reprezentuje dane prezentacji zamiast renderować slajdy jako strony lub zasoby wizualne. Tabela [supported file formats](/slides/pl/androidjava/supported-file-formats/) wskazuje, że PowerPoint XML Presentation jest formatem tylko do zapisu, dlatego nie należy go używać, gdy przepływ pracy wymaga ponownego wczytania wyeksportowanego pliku do Aspose.Slides w celu dalszej edycji.

## **FAQ**

**Czy `SaveFormat.Xml` jest tym samym, co zapisywanie pliku PPTX?**

Nie. PPTX jest pakietem zawierającym wiele części Office Open XML, natomiast `SaveFormat.Xml` tworzy plik PowerPoint XML Presentation.

**Czy mogę zapisać wyjście XML bez tworzenia pliku na dysku?**

Tak. Przekaż zapisywalny strumień do [Presentation.save](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-). Na przykład użyj [ByteArrayOutputStream](https://developer.android.com/reference/java/io/ByteArrayOutputStream) do przetwarzania w pamięci.

**Czy Aspose.Slides może ponownie wczytać wyeksportowany plik XML?**

Nie. PowerPoint XML Presentation jest obecnie obsługiwany tylko do zapisu, a nie do wczytywania. Użyj PPTX lub innego obsługiwanego formatu prezentacji, gdy wymagana jest edycja w trybie dwukierunkowym.

**Czy konwersja XML renderuje każdy slajd jako stronę lub obraz?**

Nie. Konwersja XML zapisuje ustrukturyzowane dane prezentacji. Użyj PDF lub TIFF do wyjścia ukierunkowanego na strony lub PNG, JPEG i SVG do obrazów poszczególnych slajdów.