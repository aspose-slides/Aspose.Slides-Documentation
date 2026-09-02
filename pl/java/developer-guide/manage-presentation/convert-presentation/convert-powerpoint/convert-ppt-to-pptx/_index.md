---
title: Konwertuj PPT do PPTX w Javie
linktitle: PPT do PPTX
type: docs
weight: 20
url: /pl/java/convert-ppt-to-pptx/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- konwertuj slajd
- konwertuj PPT
- PPT do PPTX
- zapisz PPT jako PPTX
- eksportuj PPT do PPTX
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Konwertuj starsze pliki PPT do PPTX w Javie za pomocą Aspose.Slides. Zawiera przykłady w Javie dla konwersji pojedynczych plików i wsadowej, obsługę błędów oraz uwagi dotyczące wierności."
---
## **Przegląd**

PPT jest starszym binarnym formatem PowerPoint, podczas gdy PPTX jest nowszym formatem Open XML. Aspose.Slides for Java może wczytać plik PPT i zapisać go jako PPTX bez Microsoft PowerPoint. Ten artykuł pokazuje, jak przekonwertować pojedynczy plik lub katalog plików oraz wyjaśnia, co należy sprawdzić po konwersji.

## **Konwertuj plik PPT do PPTX**

Załaduj plik źródłowy przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/), następnie wywołaj [Presentation.save](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#save-java.lang.String-int-) z argumentem [SaveFormat.Pptx](https://reference.aspose.com/slides/pl/java/com.aspose.slides/saveformat/#Pptx). Blok `finally` zwalnia prezentację i zwalnia jej zasoby.

```java
// Wczytaj starszą prezentację PPT.
com.aspose.slides.Presentation presentation = new com.aspose.slides.Presentation("presentation.ppt");
try {
    // Zapisz prezentację w formacie PPTX.
    presentation.save("presentation.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Rozszerzenie pliku nie wybiera formatu wyjściowego samo w sobie; robi to argument [SaveFormat.Pptx](https://reference.aspose.com/slides/pl/java/com.aspose.slides/saveformat/#Pptx). Zachowaj różne ścieżki wejściowe i wyjściowe, jeśli musisz zachować pierwotny plik PPT.

## **Konwertuj wiele plików PPT**

```java
java.io.File inputDirectory = new java.io.File("input");
java.io.File outputDirectory = new java.io.File("output");
if (!outputDirectory.exists() && !outputDirectory.mkdirs()) {
    throw new IllegalStateException("Cannot create the output directory: " + outputDirectory);
}

java.io.File[] inputFiles = inputDirectory.listFiles((directory, name) -> name.toLowerCase(java.util.Locale.ROOT).endsWith(".ppt"));
if (inputFiles == null) {
    throw new IllegalStateException("Cannot read the input directory: " + inputDirectory);
}

for (java.io.File inputFile : inputFiles) {
    String inputPath = inputFile.getPath();
    String fileName = inputFile.getName();
    String outputFileName = fileName.substring(0, fileName.length() - 4) + ".pptx";
    String outputPath = new java.io.File(outputDirectory, outputFileName).getPath();
    com.aspose.slides.Presentation presentation = null;

    try {
        presentation = new com.aspose.slides.Presentation(inputPath);
        presentation.save(outputPath, com.aspose.slides.SaveFormat.Pptx);
        System.out.println("Converted: " + inputPath);
    } catch (Exception exception) {
        System.err.println("Failed: " + inputPath + " (" + exception.getMessage() + ")");
    } finally {
        if (presentation != null) {
            presentation.dispose();
        }
    }
}
```

Poniższy przykład konwertuje każdy plik `.ppt` w jednym katalogu. Każdy plik jest przetwarzany niezależnie, więc jedna nieudana konwersja nie zatrzymuje pozostałej partii.

W środowiskach produkcyjnych zaloguj pełny wyjątek, zdecyduj, czy istniejący plik wyjściowy może zostać nadpisany, oraz zapisz nazwy nieudanych plików do kolejki ponownych prób lub przeglądu. Uszkodzone pliki, pliki zabezpieczone hasłem otwierane bez wymaganego hasła, niedostępne ścieżki oraz nieobsługiwana zawartość mogą spowodować niepowodzenie konwersji. Zobacz [Password-Protected Presentations](/slides/pl/java/password-protected-presentation/) aby wczytać zaszyfrowane pliki.

## **Wierność i funkcje starsze**

Konwersja zazwyczaj zachowuje slajdy, mastery, układy, tekst, kształty, obrazy, tabele i wykresy. Jednak PPT i PPTX nie odzwierciedlają każdej funkcji w identyczny sposób. Funkcja starsza, która nie ma odpowiednika w PPTX lub nie jest obsługiwana przez bibliotekę, może zostać znormalizowana, pominięta lub wyświetlona inaczej.

Sprawdź przekonwertowany plik, gdy zawiera animacje, przejścia, osadzone lub powiązane obiekty OLE, kontrolki ActiveX, osadzone multimedia, rzadkie czcionki lub makra VBA. Zwykły plik PPTX nie jest formatem obsługującym makra, więc użyj odpowiedniego przepływu pracy z obsługą makr, gdy VBA musi pozostać dostępne. Również zweryfikuj, że wymagane czcionki i zasoby zewnętrzne są dostępne w środowisku, w którym otwarty lub renderowany będzie przekonwertowany prezentacja.

W przypadku ważnych dokumentów, otwórz ponownie wygenerowany plik PPTX programowo i sprawdź liczbę kluczowych slajdów oraz ich zawartość, a następnie porównaj wygląd i zachowanie pokazu slajdów w docelowym odtwarzaczu. Nie traktuj udanego wywołania [Presentation.save](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#save-java.lang.String-int-) jako dowodu, że każda starsza funkcja ma dokładny odpowiednik w PPTX.

## **Kiedy używać PPTX**

Używaj PPTX, gdy prezentacja będzie edytowana w aktualnych wersjach PowerPoint, wymieniana z systemami obsługującymi pakiety Open XML lub przechowywana w formacie łatwiejszym do inspekcji i odzyskiwania niż starszy binarny PPT. Zachowaj oryginalny PPT jako kopię archiwalną lub kopię awaryjną, aż przekonwertowana prezentacja przejdzie Twoje kontrole wierności.

Jeśli potrzebujesz zamiast tego PDF, HTML, obrazów, XPS lub innego typu wyjścia, skorzystaj z instrukcji specyficznych dla formatu w [Convert Presentations to Multiple Formats](/slides/pl/java/convert-presentation/), zamiast zakładać, że wszystkie cele zachowują edytowalne funkcje PowerPoint.

## **Konwerter online**

W przypadku okazjonalnego pliku lub szybkiego porównania możesz użyć [online PPT to PPTX converter](https://products.aspose.app/slides/pl/conversion/ppt-to-pptx). Do powtarzalnych konwersji, przetwarzania wsadowego lub obsługi błędów na poziomie aplikacji, użyj API Java.

## **Powiązane artykuły**

- [PPT vs PPTX](/slides/pl/java/ppt-vs-pptx/)
- [Zapisz prezentacje w Javie](/slides/pl/java/save-presentation/)
- [Obsługiwane formaty plików](/slides/pl/java/supported-file-formats/)
- [Otwórz prezentacje w Javie](/slides/pl/java/open-presentation/)

## **FAQ**

**Czy mogę konwertować PPT do PPTX bez zainstalowanego Microsoft PowerPoint?**

Tak. Aspose.Slides for Java wczytuje i zapisuje pliki prezentacji bez wymogu posiadania Microsoft PowerPoint.

**Czy konwersja PPT do PPTX zachowa całą zawartość dokładnie?**

Zachowuje ona typową zawartość prezentacji, ale dokładna wierność nie jest gwarantowana dla każdej funkcji starszej lub nieobsługiwanej. Przejrzyj wygenerowany plik, gdy zawiera makra, obiekty OLE lub ActiveX, multimedia, specjalistyczne animacje lub rzadkie czcionki.

**Czy mogę konwertować zabezpieczony hasłem plik PPT?**

Tak, jeśli podasz prawidłowe hasło podczas wczytywania pliku. Brak lub nieprawidłowe hasło powoduje niepowodzenie operacji wczytywania.

**Czy powinienem usunąć plik PPT po konwersji?**

Zachowaj oryginał, dopóki nie zweryfikujesz pliku PPTX w odtwarzaczach i procesach, które są dla Ciebie istotne. To zapewnia kopię awaryjną, jeśli funkcja starsza zostanie skonwertowana inaczej.