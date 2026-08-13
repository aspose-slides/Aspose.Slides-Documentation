---
title: Dostosuj czcionki PowerPoint w Javie
linktitle: Niestandardowa czcionka
type: docs
weight: 20
url: /pl/java/custom-font/
keywords:
- czcionka
- niestandardowa czcionka
- zewnętrzna czcionka
- ładowanie czcionki
- zarządzanie czcionkami
- folder czcionek
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Dostosuj czcionki w slajdach PowerPoint przy użyciu Aspose.Slides dla Javy, aby Twoje prezentacje były wyraźne i spójne na każdym urządzeniu."
---
## **Przegląd**

Aspose.Slides umożliwia używanie niestandardowych czcionek w prezentacjach bez instalowania ich w systemie operacyjnym. Możesz ładować czcionki z własnych folderów, udostępniać czcionki dla określonej prezentacji za pośrednictwem źródeł czcionek na poziomie dokumentu lub ładować czcionki zewnętrzne bezpośrednio z danych binarnych.

Załadowane czcionki są używane podczas renderowania lub eksportu prezentacji, na przykład do PDF, obrazów i innych obsługiwanych formatów. Pomaga to zachować spójność wyjścia prezentacji w różnych środowiskach. Artykuł wyjaśnia również, jak sprawdzić foldery czcionek używane przez Aspose.Slides oraz jak wyczyścić pamięć podręczną czcionek po pracy z czcionkami zewnętrznymi.

Rejestrowanie niestandardowych czcionek do renderowania jest oddzielne od osadzania czcionek w pliku PPTX. Jeśli czcionka musi być przechowywana wewnątrz samej prezentacji, użyj wyraźnie funkcji osadzania czcionek.

{{% alert color="info" %}} 
Aspose Slides umożliwia ładowanie tych czcionek przy użyciu metody [loadExternalFonts](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* Czcionki TrueType (.ttf) i TrueType Collection (.ttc). Zobacz [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Czcionki OpenType (.otf). Zobacz [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Ładowanie niestandardowych czcionek**

Aspose.Slides umożliwia ładowanie czcionek używanych w prezentacji bez ich instalowania w systemie. Ma to wpływ na wynik eksportu — takiego jak PDF, obrazy i inne obsługiwane formaty — więc powstałe dokumenty wyglądają spójnie w różnych środowiskach. Czcionki są ładowane z własnych katalogów.

1. Określ jeden lub więcej folderów zawierających pliki czcionek.
2. Wywołaj statyczną metodę [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---), aby załadować czcionki z tych folderów.
3. Załaduj i renderuj/wyeksportuj prezentację.
4. Wywołaj metodę [FontsLoader.clearCache](https://reference.aspose.com/slides/pl/java/com.aspose.slides/FontsLoader#clearCache--) , aby wyczyścić pamięć podręczną czcionek.

Poniższy przykład kodu demonstruje proces ładowania czcionek:

```java
import com.aspose.slides.*;

// Zdefiniuj foldery zawierające niestandardowe pliki czcionek.
String[] fontFolders = new String[] { "assets/fonts", "global/fonts" };

// Załaduj niestandardowe czcionki z określonych folderów.
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

{{% alert color="info" title="Uwaga" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) dodaje dodatkowe foldery do ścieżek wyszukiwania czcionek, ale nie zmienia kolejności inicjalizacji czcionek.
Czcionki są inicjowane w następującej kolejności:

1. Domyślna ścieżka czcionek systemu operacyjnego.
1. Ścieżki załadowane przy użyciu [FontsLoader](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fontsloader/).

{{%/alert %}}

## **Uzyskaj foldery niestandardowych czcionek**
Aspose.Slides udostępnia metodę [getFontFolders](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fontsloader/#getFontFolders--) umożliwiającą znalezienie folderów czcionek. Metoda ta zwraca foldery dodane poprzez metodę `LoadExternalFonts` oraz systemowe foldery czcionek.

Poniższy kod Java pokazuje, jak używać [getFontFolders](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fontsloader/#getFontFolders--):

```java
import com.aspose.slides.*;

// Ten wiersz wypisuje foldery, w których przeszukiwane są pliki czcionek.
// Są to foldery dodane metodą LoadExternalFonts oraz systemowe foldery czcionek.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Określ niestandardowe czcionki używane w prezentacji**
Aspose.Slides udostępnia właściwość [setDocumentLevelFontSources](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) umożliwiającą określenie zewnętrznych czcionek, które będą używane w prezentacji.

Poniższy kod Java pokazuje, jak używać właściwości [setDocumentLevelFontSources](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

byte[] memoryFont1 = Files.readAllBytes(Paths.get("customfonts/CustomFont1.ttf"));
byte[] memoryFont2 = Files.readAllBytes(Paths.get("customfonts/CustomFont2.ttf"));

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // Pracuj z prezentacją
    // CustomFont1, CustomFont2 oraz czcionki z folderów assets\fonts i global\fonts oraz ich podfolderów są dostępne w prezentacji
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zarządzanie czcionkami zewnętrznie**

Aspose.Slides udostępnia metodę [loadExternalFont](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) umożliwiającą ładowanie czcionek zewnętrznych z danych binarnych.

Poniższy kod Java demonstruje proces ładowania czcionki z tablicy bajtów:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // zewnętrzna czcionka ładowana w trakcie życia prezentacji
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **FAQ**

### Czy niestandardowe czcionki wpływają na eksport do wszystkich formatów (PDF, PNG, SVG, HTML)?

Tak. Podłączone czcionki są używane przez renderer we wszystkich formatach eksportu.

### Czy niestandardowe czcionki są automatycznie osadzane w wynikowym pliku PPTX?

Nie. Rejestrowanie czcionki do renderowania nie jest tym samym co jej osadzanie w pliku PPTX. Jeśli potrzebujesz, aby czcionka była zawarta w pliku prezentacji, musisz użyć wyraźnie funkcji osadzania.

### Czy mogę kontrolować zachowanie awaryjne, gdy niestandardowa czcionka nie ma niektórych glifów?

Tak. Skonfiguruj [font substitution](/slides/pl/java/font-substitution/), [replacement rules](/slides/pl/java/font-replacement/) i [fallback sets](/slides/pl/java/fallback-font/), aby dokładnie określić, która czcionka ma być użyta, gdy żądany glif jest nieobecny.

### Czy mogę używać czcionek w kontenerach Linux/Docker bez instalacji systemowej?

Tak. Wskaż własne foldery czcionek lub załaduj czcionki z tablicy bajtów. Usuwa to zależność od systemowych katalogów czcionek w obrazie kontenera.

### A co z licencjonowaniem — czy mogę osadzać dowolną niestandardową czcionkę bez ograniczeń?

Jesteś odpowiedzialny za zgodność z licencjami czcionek. Warunki różnią się; niektóre licencje zabraniają osadzania lub komercyjnego użycia. Zawsze sprawdzaj umowę licencyjną czcionki przed dystrybucją wyników.