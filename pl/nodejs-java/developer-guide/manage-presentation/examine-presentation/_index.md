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
- Node.js
- JavaScript
- Aspose.Slides
description: "Przeglądaj slajdy, strukturę i metadane w prezentacjach PowerPoint i OpenDocument przy użyciu JavaScript, aby uzyskać szybsze wnioski i inteligentniejsze audyty treści."
---
## **Przegląd**

Aspose.Slides może zidentyfikować format prezentacji i odczytać jej metadane dokumentu bez tworzenia pełnego modelu obiektowego prezentacji. Jest to przydatne, gdy trzeba klasyfikować pliki, stworzyć inwentaryzację lub sprawdzić właściwości przed podjęciem decyzji o wczytaniu i przetworzeniu zawartości prezentacji.

Ten artykuł demonstruje lekką inspekcję przy użyciu [PresentationFactory](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationfactory/) i [PresentationInfo](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationinfo/), a także ukierunkowane aktualizacje przy użyciu [DocumentProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/documentproperties/).

## **Sprawdź format prezentacji**

Jeśli masz już wczytaną prezentację, zobacz [Determine the Original Presentation Format](/slides/pl/nodejs-java/detect-presentation-source-format/) aby wykryć format po wczytaniu oraz ograniczenia starszych strumieni PPT, PPS i POT.

Użyj [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) aby zbadać plik bez tworzenia instancji [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/). Metoda [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationinfo/getloadformat/) zwraca wykryty format, taki jak PPTX, PPT lub ODP.

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

Gdy przetwarzasz wiele plików prezentacji, możesz potrzebować kompaktowej inwentaryzacji do walidacji, indeksowania lub systemu zarządzania dokumentami. W takim scenariuszu użyj [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/), aby uzyskać obiekt [PresentationInfo](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationinfo/), a następnie wywołaj [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/), aby odczytać metadane dokumentu. To podejście nie tworzy instancji [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) ani nie wymaga przechodzenia po pełnym modelu obiektowym prezentacji.

Rozszerzone właściwości udostępniane przez [DocumentProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/documentproperties/) dostarczają następujące wartości inwentaryzacji:

| Metoda | Wartość inwentaryzacji |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/documentproperties/#getSlides) | Całkowita liczba slajdów. |
| [getHiddenSlides](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) | Liczba ukrytych slajdów. |
| [getNotes](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/documentproperties/#getNotes) | Liczba slajdów zawierających notatki. |
| [getParagraphs](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/documentproperties/#getParagraphs) | Całkowita liczba akapitów, jeśli dostępna. |
| [getWords](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/documentproperties/#getWords) | Całkowita liczba słów. |
| [getMultimediaClips](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/documentproperties/#getMultimediaClips) | Całkowita liczba klipów audio i wideo. |

Poniższy przykład odczytuje te wartości bez tworzenia obiektu [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) i wypisuje zwartą inwentaryzację. Łączy również [DocumentProperties.getHeadingPairs](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/documentproperties/#getHeadingPairs) z [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts), aby wyświetlić grupy zawartości, takie jak czcionki, motywy i tytuły slajdów.

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

Każdy [HeadingPair](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/headingpair/) dostarcza nazwę grupy poprzez [HeadingPair.getName](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/headingpair/#getName) oraz liczbę elementów w tej grupie poprzez [HeadingPair.getCount](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/headingpair/#getCount). [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts) zwraca płaską, uporządkowaną tablicę, więc należy pobrać liczbę kolejnych tytułów określoną przez każdy heading pair.

### **Przechowywane metadane i ograniczenia formatu**

Właściwości inwentaryzacji zwracane przez [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) odzwierciedlają metadane dostępne w źródłowym dokumencie. Aspose.Slides nie wczytuje i nie przegląda modelu obiektowego prezentacji, aby przeliczyć te wartości w trakcie tego wywołania. Brakujące właściwości są reprezentowane wartościami domyślnymi, a przechowywane wartości mogą być nieaktualne, jeśli aplikacja ostatnio zapisująca plik nie zaktualizowała właściwości dokumentu.

- **PPTX:** Format udostępnia rozszerzone właściwości dokumentu dotyczące liczby slajdów, notatek, ukrytych slajdów, akapitów, słów i multimediów, a także par nagłówków i tytułów części. Dostępność zależy od tego, które właściwości zostały zapisane przez producenta dokumentu.
- **PPT:** Format binarny może przechowywać odpowiadające właściwości podsumowania dokumentu. Jeśli właściwość jest nieobecna lub nie została odświeżona przez producenta dokumentu, Aspose.Slides zwraca jej zapisaną lub domyślną wartość zamiast obliczać ją na podstawie slajdów.
- **ODP:** Metadane OpenDocument dostarczają ogólne statystyki dokumentu, takie jak liczba stron, akapitów i słów, ale te wartości nie mapują na wszystkie specyficzne dla PowerPointa rozszerzone właściwości. Metadane dotyczące ukrytych slajdów, slajdów z notatkami, multimediów, par nagłówków i tytułów części mogą być niedostępne, a właściwości inwentaryzacji mogą zwracać wartości domyślne. Nie należy traktować zera lub pustej tablicy jako ostatecznego dowodu, że odpowiadająca zawartość jest nieobecna.

Używaj lekkiego podejścia opartego na metadanych do inwentaryzacji i wstępnych sprawdzeń. Wczytaj prezentację i sprawdź jej żywy model obiektowy, gdy wynik musi odzwierciedlać zmiany w pamięci lub gdy potrzebujesz zweryfikować rzeczywistą zawartość prezentacji.

## **Aktualizuj właściwości prezentacji**

Właściwości zwracane przez [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) można również zmienić bez tworzenia instancji [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/). Zastosuj zmiany za pomocą [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationinfo/updatedocumentproperties/), a następnie zapisz powiązaną prezentację przy użyciu [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationinfo/writebindedpresentation/).

Poniższy obraz przedstawia oryginalne właściwości dokumentu.

![Original document properties of the PowerPoint presentation](input_properties.png)

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

Poniższy obraz przedstawia zaktualizowane właściwości dokumentu.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **Przydatne linki**

W odniesieniu do powiązanych kontroli bezpieczeństwa i ustawień ochrony, zobacz następujące artykuły:

- [Password-Protect Presentations](/slides/pl/nodejs-java/password-protected-presentation/)
- [Write-Protect Presentations](/slides/pl/nodejs-java/write-protected-presentation/)

## **FAQ**

**Jak mogę sprawdzić, czy czcionki są osadzone i które to są?**

Wczytaj prezentację i użyj [Presentation.getFontsManager](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/getfontsmanager/). Wywołaj [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/), aby uzyskać listę osadzonych czcionek, oraz [FontsManager.getFonts](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontsmanager/getfonts/), aby uzyskać czcionki używane w prezentacji. Porównaj oba wyniki, aby znaleźć czcionki potrzebne do renderowania, które nie są osadzone.

**Jak szybko sprawdzić, czy plik ma ukryte slajdy i ile ich jest?**

Gdy przechowywane metadane dokumentu wystarczają, odczytaj [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) przez [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) i [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/). To rozwiązanie jest odpowiednie dla lekkiej inwentaryzacji. Jeśli prezentacja została zmodyfikowana w pamięci, przechowywane metadane mogą być brakujące lub nieaktualne; w takim wypadku przeiteruj [Presentation.getSlides](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/getslides/) i sprawdź metodę [Slide.getHidden](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slide/gethidden/) dla każdego slajdu.

**Czy mogę wykryć, czy użyto niestandardowego rozmiaru slajdu i orientacji oraz czy różnią się od domyślnych?**

Tak. Wczytaj prezentację i wywołaj [Presentation.getSlideSize](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/getslidesize/). Użyj [SlideSize.getType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slidesize/gettype/), [SlideSize.getSize](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slidesize/getsize/), oraz [SlideSize.getOrientation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slidesize/getorientation/), aby porównać bieżące ustawienia z oczekiwanymi domyślnymi i wymiarami.

**Czy istnieje szybki sposób, aby sprawdzić, czy wykresy odwołują się do zewnętrznych źródeł danych?**

Tak. Znajdź każdy [Chart](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chart/) i wywołaj [ChartData.getDataSourceType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartdata/getdatasourcetype/). Dla zewnętrznego skoroszytu wywołaj [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/). Typ źródła danych i ścieżka identyfikują odwołanie zewnętrzne, ale weryfikacja dostępności docelowego zasobu wymaga osobnego sprawdzenia zasobów.

**Jak mogę ocenić „ciężkie” slajdy, które mogą spowalniać renderowanie lub eksport do PDF?**

Nie ma jednej właściwości określającej złożoność. Przejrzyj [Presentation.getSlides](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/getslides/) i kolekcję [BaseSlide.getShapes](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/baseslide/#getShapes) każdego slajdu. Używaj liczby kształtów oraz obecności dużych obrazów, efektów, animacji lub multimediów jako wskaźników, a także zmierz reprezentatywny czas renderowania lub eksportu, zanim uznasz slajd za potwierdzony wąski gardło wydajności.