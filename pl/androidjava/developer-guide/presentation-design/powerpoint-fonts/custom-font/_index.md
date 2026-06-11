---
title: Dostosuj czcionki PowerPoint na Androidzie
linktitle: Niestandardowa czcionka
type: docs
weight: 20
url: /pl/androidjava/custom-font/
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
- Android
- Java
- Aspose.Slides
description: "Dostosuj czcionki w slajdach PowerPoint przy użyciu Aspose.Slides dla Androida w Javie, aby Twoje prezentacje były wyraźne i spójne na każdym urządzeniu."
---
## **Overview**

Aspose.Slides umożliwia używanie niestandardowych czcionek w prezentacjach bez ich instalowania w systemie operacyjnym. Możesz ładować czcionki z własnych folderów, udostępniać czcionki dla konkretnej prezentacji poprzez źródła czcionek na poziomie dokumentu lub ładować zewnętrzne czcionki bezpośrednio z danych binarnych.

Załadowane czcionki są używane podczas renderowania lub eksportu prezentacji, na przykład do PDF, obrazów i innych obsługiwanych formatów. Pomaga to utrzymać spójność wyjścia prezentacji w różnych środowiskach. Artykuł wyjaśnia także, jak sprawdzić foldery czcionek używane przez Aspose.Slides oraz jak wyczyścić pamięć podręczną czcionek po pracy ze zewnętrznymi czcionkami.

Rejestrowanie niestandardowych czcionek do renderowania jest oddzielne od osadzania czcionek w pliku PPTX. Jeśli czcionka ma być przechowywana w samej prezentacji, należy używać funkcji osadzania czcionek w sposób explicite.

{{% alert color="primary" %}} 

Aspose Slides umożliwia ładowanie tych czcionek przy użyciu metody [loadExternalFonts](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* Czcionki TrueType (.ttf) i TrueType Collection (.ttc). Zobacz [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Czcionki OpenType (.otf). Zobacz [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Load Custom Fonts**

Aspose.Slides umożliwia ładowanie czcionek używanych w prezentacji bez instalowania ich w systemie. Ma to wpływ na wynik eksportu — takiego jak PDF, obrazy i inne obsługiwane formaty — dzięki czemu powstałe dokumenty wyglądają spójnie w różnych środowiskach. Czcionki są ładowane z własnych katalogów.

1. Określ jeden lub więcej folderów zawierających pliki czcionek.  
2. Wywołaj statyczną metodę [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) aby załadować czcionki z tych folderów.  
3. Załaduj i renderuj/eksportuj prezentację.  
4. Wywołaj [FontsLoader.clearCache](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/FontsLoader#clearCache--) aby wyczyścić pamięć podręczną czcionek.

Poniższy przykład kodu demonstruje proces ładowania czcionek:

```java
// Określ foldery zawierające pliki czcionek niestandardowych.
String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// Załaduj niestandardowe czcionki z określonych folderów.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");
    
    // Renderuj/eksportuj prezentację (np. do PDF, obrazów lub innych formatów) przy użyciu załadowanych czcionek.
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
2. Ścieżki załadowane przez [FontsLoader](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fontsloader/).

{{%/alert %}}

## **Get Custom Font Folders**
Aspose.Slides udostępnia metodę [getFontFolders](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) umożliwiającą znajdowanie folderów czcionek. Metoda ta zwraca foldery dodane przy pomocy metody `LoadExternalFonts` oraz foldery czcionek systemowych.

Ten kod Java pokazuje, jak używać [getFontFolders](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fontsloader/#getFontFolders--):

```java
// Ta linia wypisuje foldery, w których wyszukiwane są pliki czcionek.
// Są to foldery dodane metodą LoadExternalFonts oraz foldery czcionek systemowych.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Specify Custom Fonts Used with a Presentation**
Aspose.Slides udostępnia właściwość [setDocumentLevelFontSources](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) umożliwiającą określenie zewnętrznych czcionek, które będą używane w prezentacji.

Ten kod Java pokazuje, jak używać właściwości [setDocumentLevelFontSources](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

```java
byte[] memoryFont1 = Files.readAllBytes("customfonts/CustomFont1.ttf");
byte[] memoryFont2 = Files.readAllBytes("customfonts/CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // Pracuj z prezentacją
    // Czcionki CustomFont1, CustomFont2 oraz czcionki z folderów assets\fonts i global\fonts oraz ich podfolderów są dostępne w prezentacji
} finally {
    if (pres != null) pres.dispose();
}
```

## **Manage Fonts Externally**

Aspose.Slides udostępnia metodę [loadExternalFont](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data), umożliwiającą ładowanie zewnętrznych czcionek z danych binarnych.

Ten kod Java demonstruje proces ładowania czcionki z tablicy bajtów:

```java
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // zewnętrzna czcionka załadowana w trakcie życia prezentacji
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **FAQ**

**Czy niestandardowe czcionki wpływają na eksport do wszystkich formatów (PDF, PNG, SVG, HTML)?**

Tak. Połączone czcionki są używane przez renderer we wszystkich formatach eksportu.

**Czy niestandardowe czcionki są automatycznie osadzane w powstałym pliku PPTX?**

Nie. Zarejestrowanie czcionki do renderowania nie jest tym samym co osadzenie jej w pliku PPTX. Jeśli potrzebujesz, aby czcionka była zawarta w pliku prezentacji, musisz użyć wyraźnie [funkcji osadzania](/slides/pl/androidjava/embedded-font/).

**Czy mogę kontrolować zachowanie awaryjne, gdy niestandardowa czcionka nie posiada niektórych glifów?**

Tak. Skonfiguruj [zastępowanie czcionek](/slides/pl/androidjava/font-substitution/), [reguły zamiany](/slides/pl/androidjava/font-replacement/) oraz [zestawy awaryjne](/slides/pl/androidjava/fallback-font/), aby dokładnie określić, jaka czcionka ma być użyta, gdy żądany glif jest nieobecny.

**Czy mogę używać czcionek w kontenerach Linux/Docker bez instalacji ich systemowo?**

Tak. Wskaż własne foldery czcionek lub ładuj czcionki z tablic bajtów. Eliminuję to zależność od katalogów czcionek systemowych w obrazie kontenera.

**Co z licencjonowaniem — czy mogę osadzać dowolną niestandardową czcionkę bez ograniczeń?**

Odpowiadasz za zgodność z licencjami czcionek. Warunki różnią się; niektóre licencje zakazują osadzania lub komercyjnego użycia. Zawsze zapoznaj się z umową licencyjną (EULA) czcionki przed rozpowszechnianiem wyników.