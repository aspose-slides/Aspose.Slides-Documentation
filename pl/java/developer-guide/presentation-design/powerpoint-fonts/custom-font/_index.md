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
- ładowanie czcionki
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

Aspose.Slides umożliwia korzystanie z własnych czcionek w prezentacjach bez ich instalowania w systemie operacyjnym. Możesz ładować czcionki z własnych folderów, udostępniać czcionki dla konkretnej prezentacji poprzez źródła czcionek na poziomie dokumentu lub ładować zewnętrzne czcionki bezpośrednio z danych binarnych.

Załadowane czcionki są używane podczas renderowania lub eksportu prezentacji, na przykład do PDF, obrazów i innych obsługiwanych formatów. Pomaga to zachować spójność wyjścia prezentacji w różnych środowiskach. Artykuł wyjaśnia również, jak sprawdzić foldery czcionek używane przez Aspose.Slides oraz jak wyczyścić pamięć podręczną czcionek po pracy z czcionkami zewnętrznymi.

Rejestrowanie własnych czcionek do renderowania jest oddzielne od osadzania czcionek w pliku PPTX. Jeśli czcionka musi zostać przechowywana wewnątrz samej prezentacji, użyj funkcji osadzania czcionek explicite.

Motyw prezentacji może odwoływać się do różnych rodzin czcionek dla poszczególnych systemów pisma. Te mapowania przechowują nazwy czcionek, ale nie instalują ani nie ładują plików czcionek. Zobacz [Mapowania czcionek specyficzne dla skryptu](/slides/pl/java/script-specific-font-mappings/), aby zarządzać mapowaniami, i użyj opcji ładowania poniżej, aby udostępnić odwoływane czcionki dla spójnego renderowania.

{{% alert color="info" title="Uwaga" %}}

Aspose Slides pozwala ładować te czcionki za pomocą metody [loadExternalFonts](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* Czcionki TrueType (.ttf) i TrueType Collection (.ttc). Zobacz [TrueType](https://en.wikipedia.org/wiki/TrueType).
* Czcionki OpenType (.otf). Zobacz [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Ładowanie własnych czcionek**

Aspose.Slides umożliwia ładowanie czcionek używanych w prezentacji bez instalowania ich w systemie. Ma to wpływ na wynik eksportu — takiego jak PDF, obrazy i inne obsługiwane formaty — więc powstałe dokumenty wyglądają spójnie w różnych środowiskach. Czcionki są ładowane z własnych katalogów.

1. Określ jeden lub więcej folderów zawierających pliki czcionek.
2. Wywołaj statyczną metodę [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---), aby załadować czcionki z tych folderów.
3. Załaduj i renderuj/wyeksportuj prezentację.
4. Wywołaj [FontsLoader.clearCache](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fontsloader/#clearCache--) w celu wyczyszczenia pamięci podręcznej czcionek.

Poniższy przykład kodu demonstruje proces ładowania czcionek:

```java
import com.aspose.slides.*;

// Zdefiniuj foldery zawierające własne pliki czcionek.
String[] fontFolders = new String[] { "assets/fonts", "global/fonts" };

// Załaduj własne czcionki z określonych folderów.
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
Czcionki są inicjalizowane w następującej kolejności:

1. Domyślna ścieżka czcionek systemu operacyjnego.
1. Ścieżki załadowane za pośrednictwem [FontsLoader](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fontsloader/).

{{%/alert %}}

## **Uzyskiwanie własnych folderów czcionek**

Aspose.Slides udostępnia metodę [getFontFolders](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fontsloader/#getFontFolders--) pozwalającą znaleźć foldery czcionek. Metoda zwraca foldery dodane poprzez metodę `LoadExternalFonts` oraz systemowe foldery czcionek.

Poniższy kod w Javie pokazuje, jak używać [getFontFolders](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fontsloader/#getFontFolders--):

```java
import com.aspose.slides.*;

// Ta linia wyświetla foldery, w których wyszukiwane są pliki czcionek.
// Są to foldery dodane metodą LoadExternalFonts oraz systemowe foldery czcionek.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Określanie własnych czcionek używanych w prezentacji**

Aspose.Slides udostępnia właściwość [setDocumentLevelFontSources](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) pozwalającą wskazać zewnętrzne czcionki, które będą używane w prezentacji.

Poniższy kod w Javie pokazuje, jak używać właściwości [setDocumentLevelFontSources](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

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
    // CustomFont1, CustomFont2 i czcionki z folderów assets\fonts oraz global\fonts oraz ich podfolderów są dostępne w prezentacji
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zarządzanie czcionkami zewnętrznie**

Aspose.Slides udostępnia metodę [loadExternalFont](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) pozwalającą ładować zewnętrzne czcionki z danych binarnych.

Poniższy kod w Javie demonstruje proces ładowania czcionki z tablicy bajtów:

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
        // zewnętrzna czcionka załadowana podczas trwania prezentacji
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **FAQ**

### Czy własne czcionki wpływają na eksport do wszystkich formatów (PDF, PNG, SVG, HTML)?

Tak. Połączone czcionki są używane przez renderer we wszystkich formatach eksportu.

### Czy własne czcionki są automatycznie osadzane w powstałym pliku PPTX?

Nie. Rejestrowanie czcionki do renderowania nie jest tym samym co osadzanie jej w pliku PPTX. Jeśli potrzebujesz, aby czcionka była zawarta w pliku prezentacji, musisz użyć explicite [funkcji osadzania](/slides/pl/java/embedded-font/).

### Czy mogę kontrolować zachowanie fallbacku, gdy własna czcionka nie zawiera niektórych glifów?

Tak. Skonfiguruj [zastępowanie czcionek](/slides/pl/java/font-substitution/), [reguły zamiany](/slides/pl/java/font-replacement/) oraz [zestawy fallback](/slides/pl/java/fallback-font/), aby dokładnie określić, która czcionka zostanie użyta, gdy żądany glif jest nieobecny.

### Czy mogę używać czcionek w kontenerach Linux/Docker bez ich instalacji systemowej?

Częściowo. Aspose.Slides może używać czcionek z własnych folderów lub z tablic bajtów bez instalacji, ale wsparcie czcionek w Javie nadal wymaga przynajmniej jednej zainstalowanej czcionki w obrazie. Bez niej ładowanie kończy się błędem „Fontconfig head is null, check your fonts or fonts configuration”. Zobacz [Wdrażanie czcionek](/slides/pl/java/deploy-fonts/).

### Co z licencjonowaniem — czy mogę osadzić dowolną własną czcionkę bez ograniczeń?

Odpowiadasz za zgodność licencyjną czcionek. Warunki różnią się; niektóre licencje zabraniają osadzania lub komercyjnego użycia. Zawsze sprawdzaj EULA czcionki przed rozpowszechnianiem wyników.