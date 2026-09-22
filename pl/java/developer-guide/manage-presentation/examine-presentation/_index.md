---
title: Pobieranie i aktualizacja informacji o prezentacji w Javie
linktitle: Informacje o prezentacji
type: docs
weight: 30
url: /pl/java/examine-presentation/
keywords:
- format prezentacji
- właściwości prezentacji
- właściwości dokumentu
- pobierz właściwości
- odczytaj właściwości
- zmień właściwości
- modyfikuj właściwości
- zaktualizuj właściwości
- analizuj PPTX
- analizuj PPT
- analizuj ODP
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Poznaj slajdy, strukturę i metadane w prezentacjach PowerPoint i OpenDocument przy użyciu Javy, aby szybciej uzyskać wgląd i przeprowadzić inteligentne kontrole zawartości."
---
## **Przegląd**

Aspose.Slides może zidentyfikować format prezentacji i odczytać metadane dokumentu bez tworzenia pełnego modelu obiektowego prezentacji. Jest to przydatne, gdy trzeba sklasyfikować pliki, stworzyć inwentaryzację lub sprawdzić właściwości przed podjęciem decyzji o załadowaniu i przetworzeniu zawartości prezentacji.

Ten artykuł demonstruje lekką inspekcję przy użyciu [PresentationFactory](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentationfactory/) oraz [IPresentationInfo](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentationinfo/), a także ukierunkowane aktualizacje przy użyciu [IDocumentProperties](https://reference.aspose.com/slides/pl/java/com.aspose.slides/idocumentproperties/).

## **Sprawdź format prezentacji**

Jeśli masz już załadowaną prezentację, zobacz [Determine the Original Presentation Format](/slides/pl/java/detect-presentation-source-format/) dla wykrywania po załadowaniu i ograniczeń starszych strumieni PPT, PPS i POT.

Użyj [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) aby sprawdzić plik bez tworzenia instancji [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/). Metoda [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentationinfo/#getLoadFormat--) raportuje wykryty format, taki jak PPTX, PPT lub ODP.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadFormat;
import com.aspose.slides.PresentationFactory;

String[] fileNames = { "pres.pptx", "pres.ppt", "pres.odp" };

for (String fileName : fileNames) {
    IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(fileName);
    int loadFormat = presentationInfo.getLoadFormat();
    String formatName = "Other (" + loadFormat + ")";

    if (loadFormat == LoadFormat.Pptx) {
        formatName = "PPTX";
    } else if (loadFormat == LoadFormat.Ppt) {
        formatName = "PPT";
    } else if (loadFormat == LoadFormat.Odp) {
        formatName = "ODP";
    }

    System.out.println(fileName + ": " + formatName);
}
```

## **Zbuduj lekką inwentaryzację prezentacji**

Kiedy przetwarzasz wiele plików prezentacji, możesz potrzebować zwartej inwentaryzacji w celu walidacji, indeksowania lub systemu zarządzania dokumentami. W takim scenariuszu użyj [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) aby uzyskać obiekt [IPresentationInfo](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentationinfo/), a następnie wywołaj [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) aby odczytać metadane dokumentu. To podejście nie tworzy instancji [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) ani nie wymaga przeglądania pełnego modelu obiektowego prezentacji.

Rozszerzone właściwości udostępniane przez [IDocumentProperties](https://reference.aspose.com/slides/pl/java/com.aspose.slides/idocumentproperties/) zapewniają następujące wartości inwentaryzacji:

| Metoda | Wartość inwentaryzacji |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/pl/java/com.aspose.slides/idocumentproperties/#getSlides--) | Całkowita liczba slajdów. |
| [getHiddenSlides](https://reference.aspose.com/slides/pl/java/com.aspose.slides/idocumentproperties/#getHiddenSlides--) | Liczba ukrytych slajdów. |
| [getNotes](https://reference.aspose.com/slides/pl/java/com.aspose.slides/idocumentproperties/#getNotes--) | Liczba slajdów zawierających notatki. |
| [getParagraphs](https://reference.aspose.com/slides/pl/java/com.aspose.slides/idocumentproperties/#getParagraphs--) | Całkowita liczba akapitów, jeśli dostępna. |
| [getWords](https://reference.aspose.com/slides/pl/java/com.aspose.slides/idocumentproperties/#getWords--) | Całkowita liczba słów. |
| [getMultimediaClips](https://reference.aspose.com/slides/pl/java/com.aspose.slides/idocumentproperties/#getMultimediaClips--) | Całkowita liczba klipów audio i wideo. |

Poniższy przykład odczytuje te wartości bez tworzenia obiektu [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) i wypisuje zwartą inwentaryzację. Łączy także [getHeadingPairs](https://reference.aspose.com/slides/pl/java/com.aspose.slides/idocumentproperties/#getHeadingPairs--) z [getTitlesOfParts](https://reference.aspose.com/slides/pl/java/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) aby wyświetlić grupy zawartości, takie jak czcionki, motywy i tytuły slajdów.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IHeadingPair;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadFormat;
import com.aspose.slides.PresentationFactory;
import java.nio.file.Paths;

String filePath = "sample.pptx";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(filePath);
IDocumentProperties documentProperties = presentationInfo.readDocumentProperties();

int loadFormat = presentationInfo.getLoadFormat();
String formatName = "Other (" + loadFormat + ")";

if (loadFormat == LoadFormat.Pptx) {
    formatName = "PPTX";
} else if (loadFormat == LoadFormat.Ppt) {
    formatName = "PPT";
} else if (loadFormat == LoadFormat.Odp) {
    formatName = "ODP";
}

System.out.println("File: " + Paths.get(filePath).getFileName());
System.out.println("Format: " + formatName);
System.out.println("Title: " + documentProperties.getTitle());
System.out.println("Author: " + documentProperties.getAuthor());
System.out.println("Statistics:");
System.out.println("  Slides: " + documentProperties.getSlides());
System.out.println("  Hidden slides: " + documentProperties.getHiddenSlides());
System.out.println("  Slides with notes: " + documentProperties.getNotes());
System.out.println("  Paragraphs: " + documentProperties.getParagraphs());
System.out.println("  Words: " + documentProperties.getWords());
System.out.println("  Multimedia clips: " + documentProperties.getMultimediaClips());

IHeadingPair[] headingPairs = documentProperties.getHeadingPairs();
String[] titlesOfParts = documentProperties.getTitlesOfParts();
headingPairs = headingPairs != null ? headingPairs : new IHeadingPair[0];
titlesOfParts = titlesOfParts != null ? titlesOfParts : new String[0];
int partIndex = 0;

if (headingPairs.length == 0 || titlesOfParts.length == 0) {
    System.out.println("Content groups: not available");
} else {
    System.out.println("Content groups:");

    for (IHeadingPair headingPair : headingPairs) {
        System.out.println("  " + headingPair.getName() + " (" + headingPair.getCount() + ")");

        for (int partOffset = 0; partOffset < headingPair.getCount() && partIndex < titlesOfParts.length; partOffset++) {
            System.out.println("    - " + titlesOfParts[partIndex]);
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.length) {
        System.out.println("  Other parts:");

        while (partIndex < titlesOfParts.length) {
            System.out.println("    - " + titlesOfParts[partIndex]);
            partIndex++;
        }
    }
}
```

Każdy [IHeadingPair](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iheadingpair/) dostarcza nazwę grupy i liczbę elementów w tej grupie. [IDocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/pl/java/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) zwraca płaską, uporządkowaną tablicę, więc przetwarzaj liczbę kolejnych tytułów określoną przez każdą parę nagłówka.

### **Przechowywane metadane i ograniczenia formatów**

Właściwości inwentaryzacji zwracane przez [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) odzwierciedlają metadane dostępne w źródłowym dokumencie. Aspose.Slides nie ładuje i nie przegląda modelu obiektowego prezentacji, aby przeliczyć te wartości przy tym wywołaniu. Brakujące właściwości są reprezentowane wartościami domyślnymi, a przechowywane wartości mogą być nieaktualne, jeśli aplikacja ostatnio zapisująca plik nie zaktualizowała właściwości dokumentu.

- **PPTX:** Format zapewnia rozszerzone właściwości dokumentu dla liczby slajdów, notatek, ukrytych slajdów, akapitów, słów i multimediów, a także par nagłówków i tytułów części. Dostępność zależy od tego, które właściwości zostały zapisane przez twórcę dokumentu.
- **PPT:** Format binarny może przechowywać odpowiadające właściwości podsumowania dokumentu. Jeśli właściwość jest nieobecna lub nie została odświeżona przez twórcę dokumentu, Aspose.Slides zwraca jej zapisaną lub domyślną wartość zamiast obliczać ją na podstawie slajdów.
- **ODP:** Metadane OpenDocument dostarczają ogólne statystyki dokumentu, takie jak liczba stron, akapitów i słów, ale te wartości nie mapują się na wszystkie specyficzne dla PowerPointa rozszerzone właściwości. Metadane dotyczące ukrytych slajdów, notatek, multimediów, par nagłówków i tytułów części mogą być niedostępne, a właściwości inwentaryzacji mogą zwracać wartości domyślne. Nie traktuj wartości zerowej ani pustej tablicy jako ostatecznego dowodu, że odpowiadająca zawartość jest nieobecna.

Użyj lekkiego podejścia opartego na metadanych do inwentaryzacji i wstępnych kontroli. Załaduj prezentację i sprawdź jej żywy model obiektowy, gdy wynik musi odzwierciedlać zmiany w pamięci lub gdy potrzebujesz zweryfikować faktyczną zawartość prezentacji.

## **Aktualizuj właściwości prezentacji**

Właściwości zwracane przez [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) mogą być również zmieniane bez tworzenia instancji [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/). Zastosuj zmiany za pomocą [IPresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentationinfo/#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), a następnie zapisz powiązaną prezentację metodą [IPresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentationinfo/#writeBindedPresentation-java.io.OutputStream-).

Poniższy obraz przedstawia oryginalne właściwości dokumentu prezentacji PowerPoint:

![Oryginalne właściwości dokumentu prezentacji PowerPoint](input_properties.png)

Poniższy przykład zmienia tytuł oraz czas ostatniego zapisu i zapisuje wynik do nowego pliku:

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;
import java.io.FileOutputStream;
import java.io.OutputStream;
import java.util.Date;

String sourceFile = "sample.pptx";
String outputFile = "sample_with_updated_properties.pptx";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(sourceFile);
IDocumentProperties documentProperties = presentationInfo.readDocumentProperties();

documentProperties.setTitle("Quarterly sales report");
documentProperties.setLastSavedTime(new Date());

presentationInfo.updateDocumentProperties(documentProperties);
try (OutputStream outputStream = new FileOutputStream(outputFile)) {
    presentationInfo.writeBindedPresentation(outputStream);
}
```

Poniższy obraz przedstawia zaktualizowane właściwości dokumentu prezentacji PowerPoint:

![Zaktualizowane właściwości dokumentu prezentacji PowerPoint](output_properties.png)

## **Przydatne linki**

W odniesieniu do powiązanych kontroli bezpieczeństwa i ustawień ochrony, zobacz następujące artykuły:

- [Password-Protect Presentations](/slides/pl/java/password-protected-presentation/)
- [Write-Protect Presentations](/slides/pl/java/write-protected-presentation/)

## **FAQ**

**Jak mogę sprawdzić, czy czcionki są osadzone i które to są?**

Załaduj prezentację i użyj [Presentation.getFontsManager](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#getFontsManager--). Wywołaj [IFontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) aby uzyskać osadzone czcionki oraz [IFontsManager.getFonts](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ifontsmanager/#getFonts--) aby uzyskać czcionki używane w prezentacji. Porównaj oba wyniki, aby znaleźć czcionki wymagane do renderowania, które nie są osadzone.

**Jak szybko stwierdzić, czy plik zawiera ukryte slajdy i ile ich jest?**

Gdy przechowywane metadane dokumentu są wystarczające, odczytaj [IDocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/pl/java/com.aspose.slides/idocumentproperties/#getHiddenSlides--) poprzez [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) i [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--). Jest to odpowiednie dla lekkiej inwentaryzacji. Jeśli prezentacja została zmodyfikowana w pamięci, przechowywane metadane mogą być niekompletne lub nieaktualne, lub potrzebujesz zweryfikować wartości bieżące – w takim wypadku iteruj przez [Presentation.getSlides](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#getSlides--) i sprawdź metodę [ISlide.getHidden](https://reference.aspose.com/slides/pl/java/com.aspose.slides/islide/#getHidden--) każdego slajdu.

**Czy mogę wykryć, czy używany jest niestandardowy rozmiar i orientacja slajdu oraz czy różnią się od domyślnych?**

Tak. Załaduj prezentację i wywołaj [Presentation.getSlideSize](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#getSlideSize--). Użyj [ISlideSize.getType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/islidesize/#getType--), [ISlideSize.getSize](https://reference.aspose.com/slides/pl/java/com.aspose.slides/islidesize/#getSize--) oraz [ISlideSize.getOrientation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/islidesize/#getOrientation--) aby porównać bieżące ustawienia z domyślnym zestawem i wymiarami.

**Czy istnieje szybki sposób, aby sprawdzić, czy wykresy odwołują się do zewnętrznych źródeł danych?**

Tak. Zlokalizuj każdy [Chart](https://reference.aspose.com/slides/pl/java/com.aspose.slides/chart/) i wywołaj [IChartData.getDataSourceType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichartdata/#getDataSourceType--). Dla zewnętrznego skoroszytu wywołaj [IChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--). Typ źródła danych i ścieżka wskazują odwołanie zewnętrzne, ale weryfikacja dostępności celu wymaga osobnego sprawdzenia zasobów.

**Jak mogę ocenić „ciężkie” slajdy, które mogą spowalniać renderowanie lub eksport do PDF?**

Nie istnieje pojedyncza właściwość opisująca złożoność. Przeglądaj [Presentation.getSlides](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#getSlides--) i kolekcję [IBaseSlide.getShapes](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibaseslide/#getShapes--) każdego slajdu. Używaj liczby kształtów oraz obecności dużych obrazów, efektów, animacji czy multimediów jako wskaźników, a także przeprowadź reprezentatywny test renderingu lub eksportu, zanim uznasz slajd za potwierdzony wąskie gardło wydajności.