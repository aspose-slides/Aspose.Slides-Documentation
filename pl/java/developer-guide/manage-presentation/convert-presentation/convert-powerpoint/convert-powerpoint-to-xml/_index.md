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
description: "Konwertuj prezentacje PowerPoint i OpenDocument do plików lub strumieni PowerPoint XML w Javie przy użyciu Aspose.Slides for Java."
---
## **Przegląd**

Aspose.Slides for Java może konwertować prezentacje PowerPoint do formatu PowerPoint XML Presentation. Wyjście XML jest przydatne, gdy potrzebujesz tekstowej reprezentacji do analizowania struktury prezentacji, rozwiązywania problemów z wygenerowanymi dokumentami, porównywania wyników w testach automatycznych lub integrowania z przepływem pracy, który konsumuje XML zamiast pakietu prezentacji.

Użyj metody [Presentation.save](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#save-java.lang.String-int-) z wartością `Xml` z klasy [SaveFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/saveformat/). Wynik możesz zapisać bezpośrednio do pliku lub do strumienia.

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` tworzy prezentację PowerPoint XML. Nie wyodrębnia on poszczególnych części Office Open XML przechowywanych w pakiecie PPTX. Jeśli potrzebujesz dokładnych części pakietu PPTX, takich jak `ppt/presentation.xml` lub pojedynczych plików XML slajdów, sprawdź sam pakiet PPTX.
{{% /alert %}}

## **Konwersja prezentacji do pliku XML**

Wczytaj źródłową prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/), a następnie przekaż ścieżkę wyjściową i `SaveFormat.Xml` do [Presentation.save](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#save-java.lang.String-int-). Źródło może być w dowolnym formacie prezentacji obsługiwanym przy ładowaniu, takim jak PPT, PPTX lub ODP.

Poniższy przykład konwertuje prezentację PPTX do pliku XML:

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

## **Zapis wyjścia XML do strumienia**

Użyj przeciążenia metodą strumienia [Presentation.save](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-), gdy XML musi pozostać w pamięci lub zostać przekazany do innego komponentu, takiego jak usługa sieciowa, dostawca pamięci lub potok przetwarzania XML. Poniższy przykład zapisuje wynik do [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) i uzyskuje powstały XML jako tablicę bajtów:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try (ByteArrayOutputStream xmlStream = new ByteArrayOutputStream()) {
    presentation.save(xmlStream, SaveFormat.Xml);
    byte[] xmlData = xmlStream.toByteArray();

    // Przekaż xmlData do kolejnego komponentu w przepływie pracy.
} finally {
    presentation.dispose();
}
```

## **Porównanie XML z formatami prezentacji i eksportu**

Wybierz format wyjściowy w zależności od tego, jak wynik będzie używany:

| Format | Wyjście | Typowe zastosowanie |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Prezentacja PowerPoint XML | Analiza struktury, rozwiązywanie problemów, porównywanie wygenerowanego wyniku oraz integracja oparta na XML |
| PPT (`.ppt`) | Starszy binarny plik prezentacji | Kompatybilność ze starszymi przepływami pracy PowerPoint |
| PPTX (`.pptx`) | Pakiet Office Open XML zawierający wiele części | Standardowa edycja PowerPoint i wymiana prezentacji |
| PDF or TIFF | Strony o stałym układzie lub obraz wielostronicowy | Przeglądanie, drukowanie i archiwizacja |
| PNG, JPEG, or SVG | Wizualna reprezentacja pojedynczego slajdu | Miniatury, podglądy i zasoby graficzne |
| HTML or HTML5 | Wyjście prezentacji przeznaczone dla sieci | Wyświetlanie w przeglądarce i publikowanie w sieci |

W przeciwieństwie do PPT i PPTX, wyjście XML jest przeznaczone głównie do inspekcji i przepływów pracy ukierunkowanych na dane. W przeciwieństwie do PDF, TIFF, HTML i formatów obrazów slajdów, reprezentuje dane prezentacji, a nie renderuje slajdów jako strony lub zasoby wizualne. Tabela [obsługiwane formaty plików](/slides/pl/java/supported-file-formats/) wymienia wszystkie formaty, które Aspose.Slides może wczytywać, importować, zapisywać lub renderować.

## **FAQ**

**Czy `SaveFormat.Xml` jest tym samym, co zapisanie pliku PPTX?**

Nie. PPTX jest pakietem zawierającym wiele części Office Open XML, natomiast `SaveFormat.Xml` tworzy plik prezentacji PowerPoint XML.

**Czy mogę zapisać wynik XML bez tworzenia pliku na dysku?**

Tak. Przekaż zapisywalny strumień do [Presentation.save](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-). Na przykład użyj [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) do przetwarzania w pamięci.

**Czy Aspose.Slides może ponownie wczytać wyeksportowany plik XML?**

Tak. Przekaż plik XML lub strumień do konstruktora [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#Presentation-java.lang.String-). [Presentation.getSourceFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#getSourceFormat--) zwróci wtedy `SourceFormat.Xml`. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) zgłasza `LoadFormat.Unknown` dla tego formatu, dlatego nie używaj go do decydowania, czy plik XML może być otwarty.

**Czy konwersja do XML renderuje każdy slajd jako stronę lub obraz?**

Nie. Konwersja do XML zapisuje ustrukturyzowane dane prezentacji. Użyj PDF lub TIFF dla wyjścia ukierunkowanego na strony, lub PNG, JPEG i SVG dla obrazów poszczególnych slajdów.