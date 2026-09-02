---
title: Pobieranie i aktualizacja informacji o prezentacji w JavaScript
linktitle: Informacje o prezentacji
type: docs
weight: 30
url: /pl/nodejs-java/examine-presentation/
keywords:
- format prezentacji
- właściwości prezentacji
- właściwości dokumentu
- pobierz właściwości
- odczytaj właściwości
- zmień właściwości
- modyfikuj właściwości
- aktualizuj właściwości
- analiza PPTX
- analiza PPT
- analiza ODP
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Przeglądaj slajdy, strukturę i metadane w prezentacjach PowerPoint i OpenDocument przy użyciu JavaScript, aby szybciej uzyskać wgląd i inteligentniej audytować treść."
---
## **Przegląd**

Aspose.Slides może rozpoznać format prezentacji i odczytać metadane dokumentu bez tworzenia pełnego modelu obiektowego prezentacji. Jest to przydatne, gdy trzeba klasyfikować pliki, tworzyć inwentaryzację lub sprawdzać właściwości przed podjęciem decyzji o załadowaniu i przetworzeniu zawartości prezentacji.

Ten artykuł demonstruje lekką inspekcję za pomocą [PresentationFactory](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationfactory/) i [PresentationInfo](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationinfo/), a także skierowane aktualizacje za pomocą [DocumentProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/documentproperties/).

## **Sprawdź format prezentacji**

Użyj [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) do sprawdzenia pliku bez tworzenia instancji [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/). Metoda [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationinfo/getloadformat/) zwraca wykryty format, taki jak PPTX, PPT lub ODP.

```javascript
const aspose = require("aspose.slides.via.java");

const fileNames = ["pres.pptx", "pres.ppt", "pres.odp"];

for (const fileName of fileNames) {
    const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(fileName);
    const loadFormat = presentationInfo.getLoadFormat();
    let formatName = `Other (${loadFormat})`;

    if (loadFormat === aspose.LoadFormat.Pptx) {
        formatName = "PPTX";
    } else if (loadFormat === aspose.LoadFormat.Ppt) {
        formatName = "PPT";
    } else if (loadFormat === aspose.LoadFormat.Odp) {
        formatName = "ODP";
    }

    console.log(`${fileName}: ${formatName}`);
}
```

## **Zbuduj lekką inwentaryzację prezentacji**

Gdy przetwarzasz wiele plików prezentacji, możesz potrzebować kompaktowej inwentaryzacji do walidacji, indeksowania lub systemu zarządzania dokumentami. W takim scenariuszu użyj [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/), aby uzyskać obiekt [PresentationInfo](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationinfo/), a następnie wywołaj [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/), aby odczytać metadane dokumentu. To podejście nie tworzy instancji [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) ani nie wymaga przeglądania pełnego modelu obiektowego prezentacji.

Rozszerzone właściwości udostępniane przez [DocumentProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/documentproperties/) zapewniają następujące wartości inwentaryzacji:

| Metoda | Wartość inwentaryzacji |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/documentproperties/#getSlides) | Łączna liczba slajdów. |
| [getHiddenSlides](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) | Liczba ukrytych slajdów. |
| [getNotes](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/documentproperties/#getNotes) | Liczba slajdów zawierających notatki. |
| [getParagraphs](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/documentproperties/#getParagraphs) | Łączna liczba akapitów, jeśli dostępna. |
| [getWords](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/documentproperties/#getWords) | Łączna liczba słów. |
| [getMultimediaClips](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/documentproperties/#getMultimediaClips) | Łączna liczba klipów audio i wideo. |

Poniższy przykład odczytuje te wartości bez tworzenia obiektu [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) i wyświetla zwartą inwentaryzację. Łączy również [DocumentProperties.getHeadingPairs](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/documentproperties/#getHeadingPairs) z [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts), aby wyświetlić grupy zawartości, takie jak czcionki, motywy i tytuły slajdów.

```javascript
const path = require("path");
const aspose = require("aspose.slides.via.java");

const filePath = "sample.pptx";
const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(filePath);
const documentProperties = presentationInfo.readDocumentProperties();

const loadFormat = presentationInfo.getLoadFormat();
let formatName = `Other (${loadFormat})`;

if (loadFormat === aspose.LoadFormat.Pptx) {
    formatName = "PPTX";
} else if (loadFormat === aspose.LoadFormat.Ppt) {
    formatName = "PPT";
} else if (loadFormat === aspose.LoadFormat.Odp) {
    formatName = "ODP";
}

console.log(`File: ${path.basename(filePath)}`);
console.log(`Format: ${formatName}`);
console.log(`Title: ${documentProperties.getTitle()}`);
console.log(`Author: ${documentProperties.getAuthor()}`);
console.log("Statistics:");
console.log(`  Slides: ${documentProperties.getSlides()}`);
console.log(`  Hidden slides: ${documentProperties.getHiddenSlides()}`);
console.log(`  Slides with notes: ${documentProperties.getNotes()}`);
console.log(`  Paragraphs: ${documentProperties.getParagraphs()}`);
console.log(`  Words: ${documentProperties.getWords()}`);
console.log(`  Multimedia clips: ${documentProperties.getMultimediaClips()}`);

const headingPairs = documentProperties.getHeadingPairs() || [];
const titlesOfParts = documentProperties.getTitlesOfParts() || [];
let partIndex = 0;

if (headingPairs.length === 0 || titlesOfParts.length === 0) {
    console.log("Content groups: not available");
} else {
    console.log("Content groups:");

    for (const headingPair of headingPairs) {
        const partCount = headingPair.getCount();
        console.log(`  ${headingPair.getName()} (${partCount})`);

        for (let partOffset = 0; partOffset < partCount && partIndex < titlesOfParts.length; partOffset++) {
            console.log(`    - ${titlesOfParts[partIndex]}`);
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.length) {
        console.log("  Other parts:");

        while (partIndex < titlesOfParts.length) {
            console.log(`    - ${titlesOfParts[partIndex]}`);
            partIndex++;
        }
    }
}
```

Każdy [HeadingPair](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/headingpair/) dostarcza nazwę grupy przez [HeadingPair.getName](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/headingpair/#getName), oraz liczbę elementów w tej grupie przez [HeadingPair.getCount](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/headingpair/#getCount). [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts) zwraca płaską, uporządkowaną tablicę, więc należy pobrać liczbę kolejnych tytułów określoną przez każdy heading pair.

### **Zapisane metadane i ograniczenia formatu**

Właściwości inwentaryzacji zwracane przez [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) odzwierciedlają metadane dostępne w dokumencie źródłowym. Aspose.Slides nie ładuje i nie przegląda modelu obiektowego prezentacji, aby przeliczyć te wartości w tym wywołaniu. Brakujące właściwości są reprezentowane przez wartości domyślne, a zapisane wartości mogą być nieaktualne, jeśli aplikacja ostatnio zapisująca plik nie zaktualizowała właściwości dokumentu.

- **PPTX:** Format zapewnia rozszerzone właściwości dokumentu dla liczby slajdów, notatek, ukrytych slajdów, akapitów, słów i multimediów, a także par nagłówków i tytułów części. Dostępność zależy od tego, które właściwości zostały zapisane przez twórcę dokumentu.
- **PPT:** Format binarny może przechowywać odpowiadające właściwości podsumowujące dokument. Jeśli właściwość jest nieobecna lub nie została odświeżona przez twórcę dokumentu, Aspose.Slides zwraca jej zapisaną lub wartość domyślną, zamiast obliczać ją na podstawie slajdów.
- **ODP:** Metadane OpenDocument dostarczają ogólne statystyki dokumentu, takie jak liczba stron, akapitów i słów, ale te wartości nie odpowiadają wszystkim rozszerzonym właściwościom specyficznym dla PowerPointa. Metadane ukrytych slajdów, slajdów z notatkami, multimediów, par nagłówków i tytułów części mogą być niedostępne, a właściwości inwentaryzacji mogą zwracać wartości domyślne. Nie traktuj wartości zero ani pustej tablicy jako ostatecznego dowodu, że odpowiadająca zawartość jest nieobecna.

Używaj lekkiego podejścia opartego na metadanych do inwentaryzacji i wstępnych sprawdzeń. Załaduj prezentację i przeanalizuj jej bieżący model obiektowy, gdy wynik musi odzwierciedlać zmiany w pamięci lub gdy trzeba zweryfikować rzeczywistą zawartość prezentacji.

## **Zaktualizuj właściwości prezentacji**

Właściwości zwracane przez [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) mogą być również zmieniane bez tworzenia instancji [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/). Zastosuj zmiany za pomocą [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationinfo/updatedocumentproperties/), a następnie zapisz powiązaną prezentację przy użyciu [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationinfo/writebindedpresentation/).

Poniższy obraz pokazuje oryginalne właściwości dokumentu prezentacji PowerPoint:

![Oryginalne właściwości dokumentu prezentacji PowerPoint](input_properties.png)

Poniższy przykład zmienia tytuł i czas ostatniego zapisu, a wynik zapisuje do nowego pliku:

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");

const sourceFile = "sample.pptx";
const outputFile = "sample_with_updated_properties.pptx";
const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(sourceFile);
const documentProperties = presentationInfo.readDocumentProperties();

documentProperties.setTitle("Quarterly sales report");
documentProperties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

presentationInfo.updateDocumentProperties(documentProperties);
const outputStream = java.newInstanceSync("java.io.FileOutputStream", outputFile);
try {
    presentationInfo.writeBindedPresentation(outputStream);
} finally {
    outputStream.close();
}
```

Poniższy obraz pokazuje zaktualizowane właściwości dokumentu:

![Zmienione właściwości dokumentu prezentacji PowerPoint](output_properties.png)

## **Przydatne linki**

W celu sprawdzenia powiązanych ustawień bezpieczeństwa i ochrony, zobacz następujące artykuły:

- [Prezentacje zabezpieczone hasłem](/slides/pl/nodejs-java/password-protected-presentation/)
- [Prezentacje zabezpieczone przed zapisem](/slides/pl/nodejs-java/write-protected-presentation/)

## **FAQ**

**Jak mogę sprawdzić, czy czcionki są osadzone i które to są?**

Załaduj prezentację i użyj [Presentation.getFontsManager](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/getfontsmanager/). Wywołaj [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/), aby uzyskać osadzone czcionki oraz [FontsManager.getFonts](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontsmanager/getfonts/), aby uzyskać czcionki używane w prezentacji. Porównaj dwa wyniki, aby znaleźć czcionki potrzebne do renderowania, które nie są osadzone.

**Jak szybko sprawdzić, czy plik zawiera ukryte slajdy i ile ich jest?**

Gdy zapisane metadane dokumentu są wystarczające, odczytaj [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) za pomocą [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) i [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/). Jest to odpowiednie dla lekkiej inwentaryzacji. Jeśli prezentacja została zmodyfikowana w pamięci, zapisane metadane mogą być niekompletne lub nieaktualne, lub gdy konieczne jest zweryfikowanie bieżących wartości, przeiteruj [Presentation.getSlides](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/getslides/) i sprawdź metodę [Slide.getHidden](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slide/gethidden/) każdego slajdu.

**Czy mogę wykryć, czy używany jest niestandardowy rozmiar i orientacja slajdu oraz czy różnią się one od wartości domyślnych?**

Tak. Załaduj prezentację i wywołaj [Presentation.getSlideSize](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/getslidesize/). Użyj [SlideSize.getType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slidesize/gettype/), [SlideSize.getSize](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slidesize/getsize/), oraz [SlideSize.getOrientation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slidesize/getorientation/), aby porównać bieżące ustawienia z oczekiwanymi predefiniowanymi i wymiarami.

**Czy istnieje szybki sposób, aby sprawdzić, czy wykresy odwołują się do zewnętrznych źródeł danych?**

Tak. Znajdź każdy [Chart](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chart/) i wywołaj [ChartData.getDataSourceType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartdata/getdatasourcetype/). Dla zewnętrznego skoroszytu wywołaj [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/). Typ źródła danych i ścieżka określają odwołanie zewnętrzne, lecz weryfikacja dostępności celu wymaga osobnego sprawdzenia zasobów.

**Jak mogę ocenić „ciężkie” slajdy, które mogą spowolnić renderowanie lub eksport do PDF?**

Nie istnieje pojedyncza właściwość określająca złożoność. Przeglądaj [Presentation.getSlides](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/getslides/) oraz kolekcję [BaseSlide.getShapes](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/baseslide/#getShapes) każdego slajdu. Używaj liczby kształtów oraz obecności dużych obrazów, efektów, animacji lub multimediów jako sygnałów kontrolnych oraz zmierz reprezentatywne renderowanie lub eksport przed uznaniem slajdu za potwierdzony wąskie gardło wydajności.