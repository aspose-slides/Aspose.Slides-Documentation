---
title: Dostosuj czcionki PowerPoint na Androidzie
linktitle: Niestandardowa czcionka
type: docs
weight: 20
url: /pl/androidjava/custom-font/
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
- Android
- Java
- Aspose.Slides
description: "Dostosuj czcionki w slajdach PowerPoint przy użyciu Aspose.Slides dla Androida w Javie, aby Twoje prezentacje były wyraźne i spójne na każdym urządzeniu."
---
## **Przegląd**

Aspose.Slides umożliwia używanie niestandardowych czcionek w prezentacjach bez instalowania ich w systemie operacyjnym. Możesz ładować czcionki z własnych folderów, udostępniać czcionki dla konkretnej prezentacji za pomocą źródeł czcionek na poziomie dokumentu lub ładować czcionki zewnętrzne bezpośrednio z danych binarnych.

Załadowane czcionki są używane podczas renderowania lub eksportu prezentacji, na przykład do PDF, obrazów i innych obsługiwanych formatów. Pomaga to zachować spójność wyjścia prezentacji w różnych środowiskach. Artykuł wyjaśnia również, jak sprawdzić foldery czcionek używane przez Aspose.Slides oraz jak wyczyścić pamięć podręczną czcionek po pracy z czcionkami zewnętrznymi.

Rejestrowanie niestandardowych czcionek do renderowania jest oddzielne od ich osadzania w pliku PPTX. Jeśli czcionka musi być przechowywana w samej prezentacji, należy wyraźnie skorzystać z funkcji osadzania czcionek.

Motyw prezentacji może odwoływać się do różnych rodzin czcionek dla poszczególnych systemów pisma. Te mapowania przechowują nazwy czcionek, ale nie instalują ani nie ładują plików czcionek. Zobacz [Czcionki tematyczne specyficzne dla skryptu](/slides/pl/androidjava/script-specific-font-mappings/), aby zarządzać mapowaniami, i użyj poniższych opcji ładowania, aby udostępnić odwoływane czcionki dla spójnego renderowania.

{{% alert color="info" title="Uwaga" %}}
Aspose Slides umożliwia ładowanie tych czcionek za pomocą metody [loadExternalFonts](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* Czcionki TrueType (.ttf) i kolekcje TrueType (.ttc). Zobacz [TrueType](https://en.wikipedia.org/wiki/TrueType).
* Czcionki OpenType (.otf). Zobacz [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **Ładowanie niestandardowych czcionek**

Aspose.Slides umożliwia ładowanie czcionek używanych w prezentacji bez instalowania ich w systemie. Ma to wpływ na wynik eksportu — taki jak PDF, obrazy i inne obsługiwane formaty — tak aby powstałe dokumenty wyglądały spójnie w różnych środowiskach. Czcionki są ładowane z własnych katalogów.

1. Określ jeden lub więcej folderów zawierających pliki czcionek.
2. Wywołaj statyczną metodę [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---), aby załadować czcionki z tych folderów.
3. Załaduj i renderuj/wyeksportuj prezentację.
4. Wywołaj [FontsLoader.clearCache](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/FontsLoader#clearCache--) aby wyczyścić pamięć podręczną czcionek.

Poniższy przykład kodu demonstruje proces ładowania czcionek:

```java
import com.aspose.slides.*;

// Zdefiniuj foldery zawierające niestandardowe pliki czcionek.
String externalFontFolder1 = "assets/fonts";
String externalFontFolder2 = "global/fonts";

String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// Załaduj niestandardowe czcionki z podanych folderów.
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
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) dodaje dodatkowe foldery do ścieżek wyszukiwania czcionek, ale nie zmienia kolejności inicjalizacji czcionek.
Czcionki są inicjalizowane w następującej kolejności:

1. Domyślna ścieżka czcionek systemu operacyjnego.
2. Ścieżki załadowane za pomocą [FontsLoader](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fontsloader/).
{{%/alert %}}

## **Pobieranie folderów z niestandardowymi czcionkami**
Aspose.Slides udostępnia metodę [getFontFolders](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) umożliwiającą odnalezienie folderów z czcionkami. Metoda ta zwraca foldery dodane poprzez metodę `LoadExternalFonts` oraz systemowe foldery czcionek.

Ten kod w języku Java pokazuje, jak używać [getFontFolders](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fontsloader/#getFontFolders--):

```java
import com.aspose.slides.*;

// Ta linia wyświetla foldery, w których wyszukiwane są pliki czcionek.
// Są to foldery dodane metodą LoadExternalFonts oraz systemowe foldery czcionek.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Określenie niestandardowych czcionek używanych w prezentacji**
Aspose.Slides udostępnia właściwość [setDocumentLevelFontSources](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) umożliwiającą określenie zewnętrznych czcionek, które będą używane w prezentacji.

Ten kod w języku Java pokazuje, jak używać właściwości [setDocumentLevelFontSources](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

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

Aspose.Slides udostępnia metodę [loadExternalFont](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) umożliwiającą ładowanie zewnętrznych czcionek z danych binarnych.

Ten kod w języku Java demonstruje proces ładowania czcionki z tablicy bajtów:

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
        // zewnętrzna czcionka załadowana w czasie trwania prezentacji
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

### Czy niestandardowe czcionki są automatycznie osadzane w powstałym pliku PPTX?

Nie. Rejestrowanie czcionki do renderowania nie jest tym samym co osadzanie jej w pliku PPTX. Jeśli potrzebujesz, aby czcionka była zawarta w pliku prezentacji, musisz użyć wyraźnych [funkcji osadzania](/slides/pl/androidjava/embedded-font/).

### Czy mogę kontrolować zachowanie awaryjne, gdy niestandardowa czcionka nie zawiera niektórych glifów?

Tak. Skonfiguruj [zastępowanie czcionek](/slides/pl/androidjava/font-substitution/), [reguły zamiany](/slides/pl/androidjava/font-replacement/) i [zestawy awaryjne](/slides/pl/androidjava/fallback-font/), aby dokładnie określić, która czcionka jest używana, gdy żądany glif jest nieobecny.

### Czy mogę używać czcionek w kontenerach Linux/Docker bez instalowania ich systemowo?

Tak. Wskaż własne foldery z czcionkami lub ładuj czcionki z tablic bajtów. Dzięki temu usuwa się zależność od systemowych katalogów czcionek w obrazie kontenera.

### A co z licencjonowaniem — czy mogę osadzać dowolną niestandardową czcionkę bez ograniczeń?

Odpowiedzialność za zgodność z licencjami czcionek spoczywa na Tobie. Warunki różnią się; niektóre licencje zakazują osadzania lub komercyjnego użycia. Zawsze sprawdzaj EULA czcionki przed rozpowszechnianiem wyników.