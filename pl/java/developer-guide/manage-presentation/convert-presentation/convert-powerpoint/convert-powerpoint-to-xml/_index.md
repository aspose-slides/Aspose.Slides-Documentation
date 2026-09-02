---
title: Konwertuj prezentacje PowerPoint do XML w Javie
linktitle: PowerPoint do XML
type: docs
weight: 145
url: /pl/java/convert-powerpoint-to-xml/
keywords:
- konwertuj PowerPoint do XML
- konwertuj prezentację do XML
- PPT do XML
- PPTX do XML
- ODP do XML
- Prezentacja PowerPoint XML
- SaveFormat.Xml
- zapisz prezentację jako XML
- eksportuj prezentację do XML
- strumień XML
- Java
- Aspose.Slides
description: "Konwertuj prezentacje PowerPoint i OpenDocument do plików lub strumieni PowerPoint XML w Javie za pomocą Aspose.Slides dla Javy."
---
## **Przegląd**

Aspose.Slides for Java może konwertować prezentacje PowerPoint do formatu PowerPoint XML Presentation. Wyjście XML jest przydatne, gdy potrzebna jest tekstowa reprezentacja do inspekcji struktury prezentacji, rozwiązywania problemów z wygenerowanymi dokumentami, porównywania wyników w testach automatycznych lub integracji z przepływem pracy, który konsumuje XML zamiast pakietu prezentacji.

Użyj metody [Presentation.save](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#save-java.lang.String-int-) z wartością `Xml` z klasy [SaveFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/saveformat/). Wynik można zapisać bezpośrednio do pliku lub do strumienia.

{{% alert color="info" title="Uwaga" %}}
`SaveFormat.Xml` tworzy PowerPoint XML Presentation. Nie wydobywa on poszczególnych części Office Open XML przechowywanych wewnątrz pakietu PPTX. Jeśli potrzebujesz dokładnych części pakietu PPTX, takich jak `ppt/presentation.xml` lub poszczególnych plików XML slajdów, przejrzyj sam pakiet PPTX.
{{% /alert %}}

## **Konwertuj prezentację na plik XML**

Wczytaj źródłową prezentację przy pomocy klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) i przekaż ścieżkę wyjściową oraz `SaveFormat.Xml` do [Presentation.save](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#save-java.lang.String-int-). Źródło może mieć dowolny format obsługiwany przy ładowaniu, np. PPT, PPTX lub ODP.

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

## **Zapisz wynik XML do strumienia**

Użyj przeciążenia strumieniowego metody [Presentation.save](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-), gdy XML ma pozostać w pamięci lub zostać przekazany do innego komponentu, takiego jak usługa sieciowa, dostawca pamięci lub potok przetwarzania XML. Poniższy przykład zapisuje wynik do [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) i uzyskuje wygenerowany XML jako tablicę bajtów:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try (ByteArrayOutputStream xmlStream = new ByteArrayOutputStream()) {
    presentation.save(xmlStream, SaveFormat.Xml);
    byte[] xmlData = xmlStream.toByteArray();

    // Przekaż xmlData do następnego komponentu w przepływie pracy.
} finally {
    presentation.dispose();
}
```

## **Porównaj XML z formatami prezentacji i eksportu**

Wybierz format wyjściowy w zależności od tego, jak wynik będzie używany:

| Format | Wyjście | Typowe zastosowanie |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Prezentacja PowerPoint XML | Inspekcja struktury, rozwiązywanie problemów, porównywanie wygenerowanego wyniku i integracja oparta na XML |
| PPT (`.ppt`) | Plik prezentacji w starszym formacie binarnym | Zgodność ze starszymi przepływami pracy PowerPoint |
| PPTX (`.pptx`) | Pakiet Office Open XML zawierający wiele części | Standardowa edycja w PowerPoint i wymiana prezentacji |
| PDF lub TIFF | Strony o stałym układzie lub obraz wielostronicowy | Przeglądanie, drukowanie i archiwizacja |
| PNG, JPEG lub SVG | Wizualna reprezentacja pojedynczego slajdu | Miniatury, podglądy i zasoby obrazów |
| HTML lub HTML5 | Wynik prezentacji przeznaczony dla sieci | Przeglądanie w przeglądarce i publikowanie w sieci |

W przeciwieństwie do PPT i PPTX, wyjście XML jest przeznaczone głównie do inspekcji i przepływów pracy zorientowanych na dane. W przeciwieństwie do PDF, TIFF, HTML i formatów obrazów slajdów, reprezentuje ono dane prezentacji, a nie renderuje slajdów jako strony lub zasoby wizualne. Tabela [obsługiwanych formatów plików](/slides/pl/java/supported-file-formats/) wymienia PowerPoint XML Presentation jako format jedynie do zapisu, więc nie używaj go, gdy przepływ pracy wymaga ponownego wczytania wyeksportowanego pliku do Aspose.Slides w celu dalszej edycji.

## **Najczęściej zadawane pytania**

**Czy `SaveFormat.Xml` jest tym samym co zapisywanie pliku PPTX?**

Nie. PPTX jest pakietem zawierającym wiele części Office Open XML, podczas gdy `SaveFormat.Xml` tworzy plik PowerPoint XML Presentation.

**Czy mogę zapisać wynik XML bez tworzenia pliku na dysku?**

Tak. Przekaż zapisywalny strumień do [Presentation.save](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-). Na przykład użyj [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) do przetwarzania w pamięci.

**Czy Aspose.Slides może ponownie wczytać wyeksportowany plik XML?**

Nie. PowerPoint XML Presentation jest obecnie obsługiwany tylko do zapisu, a nie do wczytywania. Użyj PPTX lub innego obsługiwanego formatu prezentacji, gdy wymagana jest dwukierunkowa edycja.

**Czy konwersja XML renderuje każdy slajd jako stronę lub obraz?**

Nie. Konwersja XML zapisuje ustrukturyzowane dane prezentacji. Użyj PDF lub TIFF dla wyjścia ukierunkowanego na strony lub PNG, JPEG i SVG dla obrazów poszczególnych slajdów.