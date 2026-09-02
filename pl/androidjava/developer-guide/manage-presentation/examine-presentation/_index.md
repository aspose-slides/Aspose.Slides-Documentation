---
title: Pobieranie i aktualizacja informacji o prezentacji na Androidzie
linktitle: Informacje o prezentacji
type: docs
weight: 30
url: /pl/androidjava/examine-presentation/
keywords:
- format prezentacji
- właściwości prezentacji
- właściwości dokumentu
- pobieranie właściwości
- odczyt właściwości
- zmiana właściwości
- modyfikacja właściwości
- aktualizacja właściwości
- analiza PPTX
- analiza PPT
- analiza ODP
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Poznaj slajdy, strukturę i metadane w prezentacjach PowerPoint i OpenDocument przy użyciu Javy, aby uzyskać szybsze wnioski i inteligentniejsze audyty treści."
---
## **Przegląd**

Aspose.Slides może rozpoznać format prezentacji i odczytać jej metadane dokumentu bez tworzenia pełnego modelu obiektowego prezentacji. Jest to przydatne, gdy trzeba klasyfikować pliki, tworzyć inwentarz lub sprawdzać właściwości przed podjęciem decyzji o załadowaniu i przetworzeniu zawartości prezentacji.

Ten artykuł demonstruje lekką inspekcję przy użyciu [PresentationFactory](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentationfactory/) oraz [IPresentationInfo](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentationinfo/), a także ukierunkowane aktualizacje przez [IDocumentProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/idocumentproperties/).

## **Sprawdź format prezentacji**

Użyj [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) , aby sprawdzić plik bez tworzenia instancji [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) . Metoda [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentationinfo/#getLoadFormat--) zwraca wykryty format, taki jak PPTX, PPT lub ODP.

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

## **Zbuduj lekki inwentarz prezentacji**

Gdy przetwarzasz wiele plików prezentacji, możesz potrzebować kompaktowego inwentarza do walidacji, indeksowania lub systemu zarządzania dokumentami. W takim scenariuszu użyj [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) , aby uzyskać obiekt [IPresentationInfo](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentationinfo/) , a następnie wywołaj [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) , aby odczytać metadane dokumentu. To podejście nie tworzy instancji [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) ani nie wymaga przeglądania pełnego modelu obiektowego prezentacji.

Rozszerzone właściwości udostępniane przez [IDocumentProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/idocumentproperties/) dostarczają następujące wartości inwentarza:

| Metoda | Wartość inwentarza |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/idocumentproperties/#getSlides--) | Całkowita liczba slajdów. |
| [getHiddenSlides](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/idocumentproperties/#getHiddenSlides--) | Liczba ukrytych slajdów. |
| [getNotes](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/idocumentproperties/#getNotes--) | Liczba slajdów zawierających notatki. |
| [getParagraphs](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/idocumentproperties/#getParagraphs--) | Całkowita liczba akapitów, jeśli dostępna. |
| [getWords](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/idocumentproperties/#getWords--) | Całkowita liczba słów. |
| [getMultimediaClips](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/idocumentproperties/#getMultimediaClips--) | Całkowita liczba klipów audio i wideo. |

Poniższy przykład odczytuje te wartości bez tworzenia obiektu [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) i wyświetla kompaktowy inwentarz. Łączy również [getHeadingPairs](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/idocumentproperties/#getHeadingPairs--) z [getTitlesOfParts](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) , aby wyświetlić grupy zawartości, takie jak czcionki, style i tytuły slajdów.

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

Każdy [IHeadingPair](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iheadingpair/) dostarcza nazwę grupy oraz liczbę elementów w tej grupie. [IDocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) zwraca płaską, uporządkowaną tablicę, więc należy pobrać liczbę kolejnych tytułów określoną przez każdy nagłówek grupy.

### **Przechowywane metadane i ograniczenia formatów**

Właściwości inwentarza zwracane przez [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) odzwierciedlają metadane dostępne w dokumencie źródłowym. Aspose.Slides nie ładuje i nie przegląda modelu obiektowego prezentacji w celu przeliczenia tych wartości przy tym wywołaniu. Brakujące właściwości są reprezentowane przez wartości domyślne, a przechowywane wartości mogą być nieaktualne, jeśli aplikacja, która ostatnio zapisała plik, nie zaktualizowała właściwości dokumentu.

- **PPTX:** Format zapewnia rozszerzone właściwości dokumentu dla liczby slajdów, notatek, ukrytych slajdów, akapitów, słów i multimediów, a także par nagłówków i tytułów części. Dostępność zależy od tego, które właściwości zostały zapisane przez twórcę dokumentu.
- **PPT:** Format binarny może przechowywać odpowiadające właściwości streszczenia dokumentu. Jeśli właściwość jest nieobecna lub nie została odświeżona przez twórcę dokumentu, Aspose.Slides zwraca jej przechowywaną lub domyślną wartość zamiast obliczać ją na podstawie slajdów.
- **ODP:** Metadane OpenDocument dostarczają ogólne statystyki dokumentu, takie jak liczba stron, akapitów i słów, ale te wartości nie mapują na wszystkie specyficzne dla PowerPoint rozszerzone właściwości. Metadane dotyczące ukrytych slajdów, notatek, multimediów, par nagłówków i tytułów części mogą być niedostępne, a właściwości inwentarza mogą zwracać wartości domyślne. Nie traktuj zerowej wartości ani pustej tablicy jako ostatecznego dowodu, że odpowiadająca zawartość jest nieobecna.

Użyj podejścia opartego na lekkich metadanych przy tworzeniu inwentarzy i wstępnych kontroli. Załaduj prezentację i sprawdź jej bieżący model obiektowy, gdy wynik musi odzwierciedlać zmiany w pamięci lub gdy trzeba zweryfikować rzeczywistą zawartość prezentacji.

## **Zaktualizuj właściwości prezentacji**

Właściwości zwracane przez [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) można również zmienić bez tworzenia instancji [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) . Zastosuj zmiany przy użyciu [IPresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentationinfo/#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) , a następnie zapisz powiązaną prezentację przy pomocy [IPresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentationinfo/#writeBindedPresentation-java.io.OutputStream-) .

![Oryginalne właściwości dokumentu prezentacji PowerPoint](input_properties.png)

Poniższy przykład zmienia tytuł i czas ostatniego zapisu oraz zapisuje wynik do nowego pliku:

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

![Zaktualizowane właściwości dokumentu prezentacji PowerPoint](output_properties.png)

## **Przydatne linki**

Aby zapoznać się z powiązanymi kontrolami bezpieczeństwa i ustawieniami ochrony, zobacz następujące artykuły:

- [Prezentacje chronione hasłem](/slides/pl/androidjava/password-protected-presentation/)
- [Prezentacje chronione przed zapisem](/slides/pl/androidjava/write-protected-presentation/)

## **FAQ**

**Jak mogę sprawdzić, czy czcionki są osadzone i które to są?**

Załaduj prezentację i użyj [Presentation.getFontsManager](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#getFontsManager--) . Wywołaj [IFontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) , aby uzyskać osadzone czcionki oraz [IFontsManager.getFonts](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ifontsmanager/#getFonts--) , aby uzyskać czcionki używane w prezentacji. Porównaj oba wyniki, aby znaleźć czcionki wymagane do renderowania, które nie są osadzone.

**Jak szybko sprawdzić, czy plik ma ukryte slajdy i ile ich jest?**

Gdy przechowywane metadane dokumentu są wystarczające, odczytaj [IDocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/idocumentproperties/#getHiddenSlides--) za pośrednictwem [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) i [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) . Jest to odpowiednie dla lekkiego inwentarza. Jeśli prezentacja została zmodyfikowana w pamięci, przechowywane metadane mogą być brakujące lub nieaktualne, lub gdy trzeba zweryfikować bieżące wartości, przeiteruj [Presentation.getSlides](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#getSlides--) i sprawdź metodę [ISlide.getHidden](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islide/#getHidden--) każdego slajdu.

**Czy mogę wykryć, czy używany jest niestandardowy rozmiar i orientacja slajdu, i czy różnią się od domyślnych?**

Tak. Załaduj prezentację i wywołaj [Presentation.getSlideSize](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#getSlideSize--) . Użyj [ISlideSize.getType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islidesize/#getType--) , [ISlideSize.getSize](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islidesize/#getSize--) oraz [ISlideSize.getOrientation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islidesize/#getOrientation--) , aby porównać bieżące ustawienia z oczekiwanymi domyślnymi i wymiarami.

**Czy istnieje szybki sposób, aby sprawdzić, czy wykresy odwołują się do zewnętrznych źródeł danych?**

Tak. Zlokalizuj każdy [Chart](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/chart/) i wywołaj [IChartData.getDataSourceType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartdata/#getDataSourceType--) . Dla zewnętrznego skoroszytu wywołaj [IChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) . Typ źródła danych i ścieżka identyfikują odwołanie zewnętrzne, ale weryfikacja dostępności docelowego zasobu wymaga osobnego sprawdzenia.

**Jak mogę ocenić „ciężkie” slajdy, które mogą spowalniać renderowanie lub eksport do PDF?**

Nie istnieje pojedyncza właściwość określająca złożoność. Przejrzyj [Presentation.getSlides](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#getSlides--) oraz kolekcję [IBaseSlide.getShapes](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibaseslide/#getShapes--) każdego slajdu. Użyj liczby kształtów oraz obecności dużych obrazów, efektów, animacji lub multimediów jako wskaźników, i wykonaj reprezentacyjne renderowanie lub eksport, zanim uznasz slajd za potwierdzony wąski gardeł wydajności.