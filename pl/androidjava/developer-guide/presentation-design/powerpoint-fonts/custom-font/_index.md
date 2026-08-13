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
description: "Dostosuj czcionki w slajdach PowerPoint przy użyciu Aspose.Slides dla Androida w Javie, aby Twoje prezentacje były wyraziste i spójne na każdym urządzeniu."
---
## **Przegląd**

Aspose.Slides pozwala na używanie własnych czcionek w prezentacjach bez ich instalowania w systemie operacyjnym. Możesz ładować czcionki z własnych folderów, udostępniać czcionki dla konkretnej prezentacji poprzez źródła czcionek na poziomie dokumentu lub ładować zewnętrzne czcionki bezpośrednio z danych binarnych.

Załadowane czcionki są używane podczas renderowania lub eksportu prezentacji, na przykład do PDF, obrazów i innych obsługiwanych formatów. Dzięki temu wynik prezentacji jest spójny w różnych środowiskach. W artykule wyjaśniono także, jak sprawdzić foldery czcionek używane przez Aspose.Slides oraz jak wyczyścić pamięć podręczną czcionek po pracy ze zewnętrznymi czcionkami.

Rejestrowanie własnych czcionek do renderowania jest oddzielne od ich osadzania w pliku PPTX. Jeśli czcionka musi być przechowywana w samej prezentacji, użyj funkcji osadzania czcionek w sposób jawny.

{{% alert color="info" %}} 

Aspose Slides umożliwia ładowanie tych czcionek przy użyciu metody [loadExternalFonts](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* Czcionki TrueType (.ttf) i TrueType Collection (.ttc). Zobacz [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Czcionki OpenType (.otf). Zobacz [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Ładowanie własnych czcionek**

Aspose.Slides pozwala ładować czcionki używane w prezentacji bez ich instalacji w systemie. Ma to wpływ na wynik eksportu — takiego jak PDF, obrazy i inne obsługiwane formaty — dzięki czemu powstałe dokumenty wyglądają identycznie w różnych środowiskach. Czcionki są ładowane z własnych katalogów.

1. Określ jeden lub więcej folderów zawierających pliki czcionek.
2. Wywołaj statyczną metodę [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---), aby załadować czcionki z tych folderów.
3. Załaduj i renderuj/eksportuj prezentację.
4. Wywołaj metodę [FontsLoader.clearCache](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/FontsLoader#clearCache--) w celu wyczyszczenia pamięci podręcznej czcionek.

Poniższy przykład kodu demonstruje proces ładowania czcionek:

```java
import com.aspose.slides.*;

// Zdefiniuj foldery zawierające własne pliki czcionek.
String externalFontFolder1 = "assets/fonts";
String externalFontFolder2 = "global/fonts";

String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// Załaduj własne czcionki z określonych folderów.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // Renderuj/eksportuj prezentację (np. do PDF, obrazów lub innych formatów) używając załadowanych czcionek.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Wyczyść pamięć podręczną czcionek po zakończeniu pracy.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) dodaje dodatkowe foldery do ścieżek wyszukiwania czcionek, ale nie zmienia kolejności inicjalizacji czcionek.
Czcionki są inicjalizowane w następującej kolejności:

1. Domyślna ścieżka czcionek systemu operacyjnego.
1. Ścieżki załadowane za pomocą [FontsLoader](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fontsloader/).

{{%/alert %}}

## **Pobieranie własnych folderów czcionek**
Aspose.Slides udostępnia metodę [getFontFolders](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) umożliwiającą odnalezienie folderów czcionek. Metoda ta zwraca foldery dodane za pośrednictwem metody `LoadExternalFonts` oraz systemowe foldery czcionek.

Poniższy kod Java pokazuje, jak używać [getFontFolders](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fontsloader/#getFontFolders--):

```java
import com.aspose.slides.*;

// Ten wiersz wypisuje foldery, w których przeszukiwane są pliki czcionek.
// Są to foldery dodane metodą LoadExternalFonts oraz systemowe foldery czcionek.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Określanie własnych czcionek używanych w prezentacji**
Aspose.Slides udostępnia właściwość [setDocumentLevelFontSources](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) umożliwiającą określenie zewnętrznych czcionek, które będą używane w prezentacji.

Poniższy kod Java pokazuje, jak używać właściwości [setDocumentLevelFontSources](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

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
        // zewnętrzna czcionka załadowana na czas trwania prezentacji
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

Tak. Powiązane czcionki są używane przez renderer we wszystkich formatach eksportu.

### Czy własne czcionki są automatycznie osadzane w wynikowym pliku PPTX?

Nie. Rejestrowanie czcionki do renderowania nie jest tym samym co jej osadzenie w pliku PPTX. Jeśli chcesz, aby czcionka była zawarta w pliku prezentacji, musisz użyć jawnych [funkcji osadzania](/slides/pl/androidjava/embedded-font/).

### Czy mogę kontrolować zachowanie awaryjne, gdy własna czcionka nie posiada niektórych glifów?

Tak. Skonfiguruj [substytucję czcionek](/slides/pl/androidjava/font-substitution/), [reguły zamiany](/slides/pl/androidjava/font-replacement/) oraz [zestawy awaryjne](/slides/pl/androidjava/fallback-font/), aby określić dokładnie, która czcionka zostanie użyta, gdy żądany glif jest nieobecny.

### Czy mogę używać czcionek w kontenerach Linux/Docker bez instalacji systemowej?

Tak. Wskaż własne foldery czcionek lub ładowaj czcionki z tablic bajtów. Dzięki temu nie ma zależności od systemowych katalogów czcionek w obrazie kontenera.

### Co z licencjonowaniem — czy mogę osadzać dowolną własną czcionkę bez ograniczeń?

Jesteś odpowiedzialny za zgodność z licencjami czcionek. Warunki różnią się; niektóre licencje zabraniają osadzania lub komercyjnego użycia. Zawsze zapoznaj się z umową licencyjną (EULA) czcionki przed rozpowszechnianiem wyników.