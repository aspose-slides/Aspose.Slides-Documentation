---
title: Dostosuj czcionki PowerPoint w JavaScript
linktitle: Własna czcionka
type: docs
weight: 20
url: /pl/nodejs-java/custom-font/
keywords:
- czcionka
- własna czcionka
- czcionka zewnętrzna
- wczytaj czcionkę
- zarządzaj czcionkami
- folder czcionek
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Dostosuj czcionki w slajdach PowerPoint przy użyciu JavaScript i Aspose.Slides dla Node.js poprzez Java, aby Twoje prezentacje były wyraźne i spójne na każdym urządzeniu."
---
## **Przegląd**

Aspose.Slides umożliwia używanie własnych czcionek w prezentacjach bez ich instalowania w systemie operacyjnym. Można wczytywać czcionki z własnych folderów, udostępniać czcionki dla określonej prezentacji poprzez źródła czcionek na poziomie dokumentu lub wczytywać zewnętrzne czcionki bezpośrednio z danych binarnych.

Wczytane czcionki są wykorzystywane podczas renderowania lub eksportu prezentacji, np. do PDF, obrazów i innych obsługiwanych formatów. Dzięki temu wyjściowy dokument jest spójny w różnych środowiskach. Artykuł opisuje także, jak sprawdzić foldery czcionek używane przez Aspose.Slides oraz jak wyczyścić pamięć podręczną czcionek po pracy z czcionkami zewnętrznymi.

Rejestrowanie własnych czcionek do renderowania jest odrębne od osadzania czcionek w pliku PPTX. Jeśli czcionka ma być przechowywana wewnątrz prezentacji, należy użyć funkcji osadzania czcionek explicite.

Motyw prezentacji może odwoływać się do różnych rodzin czcionek dla poszczególnych systemów pisma. Te mapowania przechowują nazwy czcionek, ale nie instalują ani nie wczytują plików czcionek. Zobacz [Script-Specific Theme Fonts](/slides/pl/nodejs-java/script-specific-font-mappings/), aby zarządzać mapowaniami, oraz użyj poniższych opcji ładowania, aby udostępnić odwoływane czcionki dla spójnego renderowania.

{{% alert color="info" title="Uwaga" %}}
Aspose Slides pozwala wczytywać te czcionki za pomocą metody [loadExternalFonts](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* TrueType (.ttf) oraz TrueType Collection (.ttc). Zobacz [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf). Zobacz [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **Wczytywanie własnych czcionek**

Aspose.Slides umożliwia wczytywanie czcionek używanych w prezentacji bez ich instalowania w systemie. Ma to wpływ na eksport – np. do PDF, obrazów i innych formatów – dzięki czemu powstałe dokumenty wyglądają tak samo w różnych środowiskach. Czcionki są wczytywane z własnych katalogów.

1. Określ jeden lub więcej folderów zawierających pliki czcionek.
2. Wywołaj statyczną metodę [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/), aby wczytać czcionki z tych folderów.
3. Wczytaj i renderuj/eksportuj prezentację.
4. Wywołaj [FontsLoader.clearCache](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontsloader/clearcache/), aby wyczyścić pamięć podręczną czcionek.

Poniższy przykład kodu demonstruje proces wczytywania czcionek:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Zdefiniuj foldery zawierające własne pliki czcionek.
let externalFontFolder1 = "fonts";
let externalFontFolder2 = "extra-fonts";
let fontFolders = java.newArray("java.lang.String", [externalFontFolder1, externalFontFolder2]);

// Wczytaj własne czcionki z podanych folderów.
aspose.slides.FontsLoader.loadExternalFonts(fontFolders);

let presentation = null;
try {
    presentation = new aspose.slides.Presentation("sample.pptx");
    
    // Renderuj/eksportuj prezentację (np. do PDF, obrazów lub innych formatów) używając wczytanych czcionek.
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Wyczyść pamięć podręczną czcionek po zakończeniu pracy.
    aspose.slides.FontsLoader.clearCache();
}
```

{{% alert color="info" title="Uwaga" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) dodaje dodatkowe foldery do ścieżek wyszukiwania czcionek, ale nie zmienia kolejności inicjalizacji czcionek.
Czcionki są inicjalizowane w następującej kolejności:

1. Domyślna ścieżka czcionek systemu operacyjnego.
1. Ścieżki wczytane za pośrednictwem [FontsLoader](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontsloader/).
{{%/alert %}}

## **Uzyskanie folderu własnych czcionek**

Aspose.Slides udostępnia metodę [getFontFolders](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) umożliwiającą odnalezienie folderów czcionek. Metoda zwraca foldery dodane przez metodę `LoadExternalFonts` oraz systemowe foldery czcionek.

Ten kod JavaScript pokazuje, jak używać [getFontFolders](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontsloader/#getFontFolders--):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Ten wiersz wyświetla foldery, w których wyszukiwane są pliki czcionek.
// Są to foldery dodane metodą LoadExternalFonts oraz systemowe foldery czcionek.
var fontFolders = aspose.slides.FontsLoader.getFontFolders();
```

## **Określenie własnych czcionek używanych w prezentacji**

Aspose.Slides udostępnia właściwość [setDocumentLevelFontSources](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-) umożliwiającą wskazanie zewnętrznych czcionek, które będą używane z prezentacją.

Ten kod JavaScript pokazuje, jak używać właściwości [setDocumentLevelFontSources](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var memoryFont1 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont1.ttf"));
var memoryFont2 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont2.ttf"));
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(java.newArray("java.lang.String", ["assets/fonts", "global/fonts"]));
loadOptions.getDocumentLevelFontSources().setMemoryFonts(java.newArray("[B", [java.newArray("byte", ["item1", "item2", "item3"])]));
var pres = new aspose.slides.Presentation("MyPresentation.pptx", loadOptions);
try {
    // Pracuj z prezentacją
    // CustomFont1, CustomFont2 oraz czcionki z folderów assets\fonts i global\fonts oraz ich podfolderów są dostępne w prezentacji
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Zarządzanie czcionkami zewnętrznie**

Aspose.Slides udostępnia metodę [loadExternalFont](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) umożliwiającą wczytywanie zewnętrznych czcionek z danych binarnych.

Ten kod JavaScript demonstruje proces wczytywania czcionki z tablicy bajtów:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALN.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNBI.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNI.TTF")));
try {
    var pres = new aspose.slides.Presentation("");
    try {
        // zewnętrzna czcionka wczytana w czasie życia prezentacji
    } finally {
    }
} finally {
    java.callStaticMethodSync("com.aspose.slides.FontsLoader", "clearCache");
}
```

## **FAQ**

### Czy własne czcionki wpływają na eksport do wszystkich formatów (PDF, PNG, SVG, HTML)?

Tak. Połączone czcionki są używane przez renderer we wszystkich formatach eksportu.

### Czy własne czcionki są automatycznie osadzane w wynikowym pliku PPTX?

Nie. Rejestrowanie czcionki do renderowania nie jest tym samym co osadzanie jej w pliku PPTX. Jeśli czcionka ma być zawarta w pliku prezentacji, należy użyć explicite [funkcji osadzania](/slides/pl/nodejs-java/embedded-font/).

### Czy mogę kontrolować zachowanie fallbacku, gdy własna czcionka nie posiada niektórych glifów?

Tak. Skonfiguruj [zastępowanie czcionek](/slides/pl/nodejs-java/font-substitution/), [reguły zamiany](/slides/pl/nodejs-java/font-replacement/) oraz [zestawy fallback](/slides/pl/nodejs-java/fallback-font/), aby określić, która czcionka ma być użyta, gdy żądany glif jest nieobecny.

### Czy mogę używać czcionek w kontenerach Linux/Docker bez ich instalacji systemowo?

Tak. Wskaż własne foldery czcionek lub wczytuj czcionki z tablic bajtów. Dzięki temu nie ma zależności od systemowych katalogów czcionek w obrazie kontenera.

### Co z licencjonowaniem – czy mogę osadzać dowolną własną czcionkę bez ograniczeń?

Odpowiedzialność za zgodność licencyjną czcionek leży po Twojej stronie. Warunki licencji się różnią; niektóre licencje zakazują osadzania lub komercyjnego użycia. Zawsze przeglądaj EULA czcionki przed rozpowszechnianiem wyników.