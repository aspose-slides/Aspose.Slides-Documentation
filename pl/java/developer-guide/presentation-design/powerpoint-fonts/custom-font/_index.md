---
title: Dostosuj czcionki PowerPoint w Javie
linktitle: Czcionka niestandardowa
type: docs
weight: 20
url: /pl/java/custom-font/
keywords:
- czcionka
- czcionka niestandardowa
- czcionka zewnętrzna
- wczytywanie czcionki
- zarządzanie czcionkami
- folder czcionek
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Dostosuj czcionki w slajdach PowerPoint za pomocą Aspose.Slides dla Javy, aby Twoje prezentacje były wyraźne i spójne na każdym urządzeniu."
---
## **Przegląd**

Aspose.Slides pozwala używać własnych czcionek w prezentacjach bez instalowania ich w systemie operacyjnym. Możesz ładować czcionki z własnych folderów, dostarczać czcionki dla konkretnej prezentacji poprzez źródła czcionek na poziomie dokumentu lub ładować zewnętrzne czcionki bezpośrednio z danych binarnych.

Załadowane czcionki są używane podczas renderowania lub eksportu prezentacji, na przykład do PDF, obrazów i innych obsługiwanych formatów. Pomaga to zachować spójność wyjściową prezentacji w różnych środowiskach. Artykuł wyjaśnia również, jak sprawdzić foldery czcionek używane przez Aspose.Slides i jak wyczyścić pamięć podręczną czcionek po pracy ze zewnętrznymi czcionkami.

Rejestrowanie własnych czcionek do renderowania jest oddzielne od osadzania czcionek w pliku PPTX. Jeśli czcionka ma być przechowywana wewnątrz samej prezentacji, użyj funkcji osadzania czcionek explicite.

{{% alert color="primary" %}} 

Aspose Slides pozwala ładować te czcionki przy użyciu metody [loadExternalFonts](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* Czcionki TrueType (.ttf) i TrueType Collection (.ttc). Zobacz [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Czcionki OpenType (.otf). Zobacz [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Ładowanie własnych czcionek**

Aspose.Slides pozwala ładować czcionki używane w prezentacji bez ich instalacji w systemie. Ma to wpływ na wynik eksportu — takiego jak PDF, obrazy i inne obsługiwane formaty — więc powstałe dokumenty wyglądają spójnie w różnych środowiskach. Czcionki są ładowane z własnych katalogów.

1. Określ jeden lub więcej folderów zawierających pliki czcionek.
2. Wywołaj statyczną metodę [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) aby załadować czcionki z tych folderów.
3. Załaduj i renderuj/wyeksportuj prezentację.
4. Wywołaj [FontsLoader.clearCache](https://reference.aspose.com/slides/pl/java/com.aspose.slides/FontsLoader#clearCache--) aby wyczyścić pamięć podręczną czcionek.

Przykład kodu poniżej demonstruje proces ładowania czcionek:

```java
// Zdefiniuj foldery zawierające własne pliki czcionek.
String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// Wczytaj własne czcionki z określonych folderów.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");
    
    // Renderuj/wyeksportuj prezentację (np. do PDF, obrazów lub innych formatów) używając załadowanych czcionek.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Wyczyść pamięć podręczną czcionek po zakończeniu pracy.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) dodaje dodatkowe foldery do ścieżek wyszukiwania czcionek, ale nie zmienia kolejności inicjalizacji czcionek.
Czcionki są inicjalizowane w następującej kolejności:

1. Domyślna ścieżka czcionek systemu operacyjnego.
1. Ścieżki załadowane poprzez [FontsLoader](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fontsloader/).

{{%/alert %}}

## **Uzyskiwanie własnych folderów czcionek**
Aspose.Slides udostępnia metodę [getFontFolders](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fontsloader/#getFontFolders--) umożliwiającą znalezienie folderów czcionek. Metoda ta zwraca foldery dodane przez metodę `LoadExternalFonts` oraz systemowe foldery czcionek.

Poniższy kod Java pokazuje, jak używać [getFontFolders](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fontsloader/#getFontFolders--):

```java
// Ten wiersz wyświetla foldery, w których wyszukiwane są pliki czcionek.
// Są to foldery dodane przez metodę LoadExternalFonts oraz systemowe foldery czcionek.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Określanie własnych czcionek używanych w prezentacji**
Aspose.Slides udostępnia właściwość [setDocumentLevelFontSources](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) pozwalającą określić zewnętrzne czcionki, które będą używane w prezentacji. 

Poniższy kod Java pokazuje, jak używać właściwości [setDocumentLevelFontSources](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

```java
byte[] memoryFont1 = Files.readAllBytes("customfonts/CustomFont1.ttf");
byte[] memoryFont2 = Files.readAllBytes("customfonts/CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // Pracuj z prezentacją
    // CustomFont1, CustomFont2 oraz czcionki z folderów assets\fonts i global\fonts oraz ich podfolderów są dostępne dla prezentacji
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zarządzanie czcionkami zewnętrznie**

Aspose.Slides udostępnia metodę [loadExternalFont](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) pozwalającą ładować zewnętrzne czcionki z danych binarnych.

Poniższy kod Java demonstruje proces ładowania czcionki z tablicy bajtów:

```java
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // zewnętrzna czcionka wczytana podczas życia prezentacji
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **FAQ**

**Czy własne czcionki wpływają na eksport do wszystkich formatów (PDF, PNG, SVG, HTML)?**

Tak. Połączone czcionki są używane przez renderer we wszystkich formatach eksportu.

**Czy własne czcionki są automatycznie osadzane w powstałym pliku PPTX?**

Nie. Rejestracja czcionki do renderowania nie jest tym samym co jej osadzenie w pliku PPTX. Jeśli czcionka ma być zawarta w pliku prezentacji, należy użyć explicite funkcji [embedding features](/slides/pl/java/embedded-font/).

**Czy mogę kontrolować zachowanie alternatywne, gdy własna czcionka nie ma niektórych glifów?**

Tak. Skonfiguruj [font substitution](/slides/pl/java/font-substitution/), [replacement rules](/slides/pl/java/font-replacement/) oraz [fallback sets](/slides/pl/java/fallback-font/), aby dokładnie określić, która czcionka jest używana, gdy żądany glif jest nieobecny.

**Czy mogę używać czcionek w kontenerach Linux/Docker bez instalacji systemowej?**

Tak. Wskaż własne foldery czcionek lub ładować czcionki z tablic bajtów. To usuwa wszelkie zależności od systemowych katalogów czcionek w obrazie kontenera.

**Co z licencjonowaniem — czy mogę osadzić dowolną własną czcionkę bez ograniczeń?**

Jesteś odpowiedzialny za zgodność z licencją czcionki. Warunki się różnią; niektóre licencje zakazują osadzania lub użycia komercyjnego. Zawsze sprawdzaj EULA czcionki przed rozpowszechnianiem wyników.