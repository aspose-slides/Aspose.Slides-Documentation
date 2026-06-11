---
title: Dostosuj czcionki PowerPoint w JavaScript
linktitle: Niestandardowa czcionka
type: docs
weight: 20
url: /pl/nodejs-java/custom-font/
keywords:
- czcionka
- niestandardowa czcionka
- czcionka zewnętrzna
- ładowanie czcionki
- zarządzanie czcionkami
- folder czcionek
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Dostosuj czcionki w slajdach PowerPoint za pomocą JavaScript i Aspose.Slides dla Node.js poprzez Java, aby Twoje prezentacje były wyraźne i spójne na każdym urządzeniu."
---
## **Przegląd**

Aspose.Slides umożliwia używanie niestandardowych czcionek w prezentacjach bez ich instalowania w systemie operacyjnym. Możesz ładować czcionki z własnych folderów, udostępniać czcionki dla konkretnej prezentacji poprzez źródła czcionek na poziomie dokumentu lub ładować czcionki zewnętrzne bezpośrednio z danych binarnych.

Załadowane czcionki są używane podczas renderowania lub eksportu prezentacji, np. do PDF, obrazów i innych obsługiwanych formatów. Pomaga to zachować spójność wyjścia prezentacji w różnych środowiskach. Artykuł wyjaśnia również, jak sprawdzić foldery czcionek używane przez Aspose.Slides oraz jak wyczyścić pamięć podręczną czcionek po pracy z czcionkami zewnętrznymi.

Rejestrowanie niestandardowych czcionek do renderowania jest oddzielne od osadzania czcionek w pliku PPTX. Jeśli czcionka musi być przechowywana wewnątrz prezentacji, użyj funkcji osadzania czcionek w sposób explicite.

{{% alert color="primary" %}} 
Aspose Slides umożliwia ładowanie tych czcionek przy użyciu metody [loadExternalFonts](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* Czcionki TrueType (.ttf) i kolekcje TrueType (.ttc). Zobacz [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Czcionki OpenType (.otf). Zobacz [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Ładowanie niestandardowych czcionek**

Aspose.Slides umożliwia ładowanie czcionek używanych w prezentacji bez ich instalowania w systemie. Ma to wpływ na wynik eksportu — takiego jak PDF, obrazy i inne obsługiwane formaty — więc powstałe dokumenty wyglądają spójnie w różnych środowiskach. Czcionki są ładowane z własnych katalogów.

1. Określ jeden lub więcej folderów zawierających pliki czcionek.
2. Wywołaj statyczną metodę [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/), aby załadować czcionki z tych folderów.
3. Załaduj i renderuj/wyeksportuj prezentację.
4. Wywołaj [FontsLoader.clearCache](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontsloader/clearcache/), aby wyczyścić pamięć podręczną czcionek.

Poniższy przykład kodu demonstruje proces ładowania czcionek:

```js
// Zdefiniuj foldery zawierające niestandardowe pliki czcionek.
let fontFolders = java.newArray("java.lang.String", [externalFontFolder1, externalFontFolder2]);

// Załaduj niestandardowe czcionki z określonych folderów.
aspose.slides.FontsLoader.loadExternalFonts(fontFolders);

let presentation = null;
try {
    presentation = new aspose.slides.Presentation("sample.pptx");
    
    // Renderuj/eksportuj prezentację (np. do PDF, obrazów lub innych formatów) używając załadowanych czcionek.
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
1. Ścieżki załadowane przez [FontsLoader](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontsloader/).

{{%/alert %}}

## **Uzyskaj folder niestandardowych czcionek**
Aspose.Slides udostępnia metodę [getFontFolders](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) , która pozwala odnaleźć foldery czcionek. Metoda ta zwraca foldery dodane za pomocą metody `LoadExternalFonts` oraz foldery czcionek systemowych.

Ten kod JavaScript pokazuje, jak używać [getFontFolders](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontsloader/#getFontFolders--):

```javascript
// Ten wiersz wypisuje foldery, w których wyszukiwane są pliki czcionek.
// Są to foldery dodane metodą LoadExternalFonts oraz foldery czcionek systemowych.
var fontFolders = aspose.slides.FontsLoader.getFontFolders();
```

## **Określ niestandardowe czcionki używane w prezentacji**
Aspose.Slides udostępnia właściwość [setDocumentLevelFontSources](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-), aby umożliwić określenie zewnętrznych czcionek, które będą używane w prezentacji.

Ten kod JavaScript pokazuje, jak używać właściwości [setDocumentLevelFontSources](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-):

```javascript
var memoryFont1 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont1.ttf"));
var memoryFont2 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont2.ttf"));
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(java.newArray("java.lang.String", ["assets/fonts", "global/fonts"]));
loadOptions.getDocumentLevelFontSources().setMemoryFonts(java.newArray("[B", [java.newArray("byte", ["item1", "item2", "item3"])]));
var pres = new aspose.slides.Presentation("MyPresentation.pptx", loadOptions);
try {
    // Pracuj z prezentacją
    // Czcionki CustomFont1, CustomFont2 oraz czcionki z folderów assets\fonts i global\fonts oraz ich podfolderów są dostępne dla prezentacji
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Zarządzaj czcionkami zewnętrznie**

Aspose.Slides udostępnia metodę [loadExternalFont](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data), która pozwala ładować zewnętrzne czcionki z danych binarnych.

Ten kod JavaScript demonstruje proces ładowania czcionki z tablicy bajtów:

```javascript
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALN.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNBI.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNI.TTF")));
try {
    var pres = new aspose.slides.Presentation("");
    try {
        // zewnętrzna czcionka załadowana podczas życia prezentacji
    } finally {
    }
} finally {
    java.callStaticMethodSync("com.aspose.slides.FontsLoader", "clearCache");
}
```

## **FAQ**

**Czy niestandardowe czcionki wpływają na eksport do wszystkich formatów (PDF, PNG, SVG, HTML)?**

Tak. Połączone czcionki są używane przez renderer we wszystkich formatach eksportu.

**Czy niestandardowe czcionki są automatycznie osadzane w powstałym pliku PPTX?**

Nie. Rejestrowanie czcionki do renderowania nie jest tym samym co osadzanie jej w pliku PPTX. Jeśli potrzebujesz, aby czcionka była zawarta w pliku prezentacji, musisz użyć explicite [funkcje osadzania](/slides/pl/nodejs-java/embedded-font/).

**Czy mogę kontrolować zachowanie awaryjne, gdy niestandardowa czcionka brakuje niektórych glifów?**

Tak. Skonfiguruj [zastępowanie czcionek](/slides/pl/nodejs-java/font-substitution/), [reguły zamiany](/slides/pl/nodejs-java/font-replacement/) i [zestawy awaryjne](/slides/pl/nodejs-java/fallback-font/), aby dokładnie określić, jaka czcionka jest używana, gdy żądany glif jest nieobecny.

**Czy mogę używać czcionek w kontenerach Linux/Docker bez ich instalacji w całym systemie?**

Tak. Wskaż własne foldery czcionek lub ładuj czcionki z tablic bajtów. Usuwa to wszelkie zależności od katalogów czcionek systemowych w obrazie kontenera.

**Co z licencjonowaniem — czy mogę osadzić dowolną niestandardową czcionkę bez ograniczeń?**

Jesteś odpowiedzialny za zgodność z licencją czcionki. Warunki różnią się; niektóre licencje zabraniają osadzania lub komercyjnego użycia. Zawsze sprawdzaj umowę EULA czcionki przed dystrybucją wyników.