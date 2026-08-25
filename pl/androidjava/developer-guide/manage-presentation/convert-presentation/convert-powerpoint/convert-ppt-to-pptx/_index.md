---
title: Konwertuj PPT do PPTX na Androidzie
linktitle: PPT do PPTX
type: docs
weight: 20
url: /pl/androidjava/convert-ppt-to-pptx/
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
- Android
- Java
- Aspose.Slides
description: "Konwertuj starsze pliki PPT do PPTX na Androidzie przy użyciu Aspose.Slides. Zawiera przykłady w Javie dla konwersji pojedynczych plików i wsadowej, obsługę błędów oraz informacje o wierności."
---
## **Przegląd**

PPT jest starszym binarnym formatem PowerPoint, natomiast PPTX to nowszy format Open XML. Aspose.Slides for Android via Java może wczytać plik PPT i zapisać go jako PPTX bez Microsoft PowerPoint. Ten artykuł pokazuje, jak przekonwertować pojedynczy plik lub katalog plików oraz wyjaśnia, co należy zweryfikować po konwersji.

## **Konwertuj plik PPT do PPTX**

Wczytaj plik źródłowy przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/), a następnie wywołaj [Presentation.save](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) z argumentem [SaveFormat.Pptx](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/saveformat/#Pptx). Blok `finally` zwalnia prezentację i zwalnia jej zasoby.

```java
// Załaduj starszą prezentację PPT.
com.aspose.slides.Presentation presentation = new com.aspose.slides.Presentation("presentation.ppt");
try {
    // Zapisz prezentację w formacie PPTX.
    presentation.save("presentation.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Rozszerzenie pliku nie wybiera formatu wyjściowego samo w sobie; robi to argument [SaveFormat.Pptx](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/saveformat/#Pptx). Zachowaj różne ścieżki wejścia i wyjścia, jeśli musisz zachować oryginalny plik PPT.

## **Konwertuj wiele plików PPT**

Poniższy przykład konwertuje każdy plik `.ppt` w jednym katalogu. Każdy plik jest przetwarzany niezależnie, więc niepowodzenie jednej konwersji nie zatrzymuje pozostałych w partii.

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

W środowiskach produkcyjnych rejestruj pełne wyjątki, określ, czy istniejący plik wyjściowy może zostać nadpisany, oraz zapisuj nazwy nieudanych plików do kolejki ponownych prób lub przeglądu. Uszkodzone pliki, pliki zabezpieczone hasłem otwarte bez wymaganego hasła, niedostępne ścieżki i nieobsługiwana zawartość mogą spowodować niepowodzenie konwersji. Zobacz [Password-Protected Presentations](/androidjava/password-protected-presentation/) w celu wczytywania zaszyfrowanych plików.

## **Wierność i funkcje dziedziczone**

Konwersja zazwyczaj zachowuje slajdy, wzorce, układy, tekst, kształty, obrazy, tabele i wykresy. Jednak PPT i PPTX nie odwzorowują każdej funkcji w dokładnie taki sam sposób. Funkcja starsza, która nie ma odpowiednika w PPTX lub nie jest obsługiwana przez bibliotekę, może zostać znormalizowana, pominięta lub wyświetlona inaczej.

Sprawdź przekonwertowany plik, gdy zawiera animacje, przejścia, osadzone lub powiązane obiekty OLE, kontrolki ActiveX, osadzone multimedia, rzadkie czcionki lub makra VBA. Zwykły plik PPTX nie jest formatem obsługującym makra, więc użyj odpowiedniego przepływu pracy z obsługą makr, gdy VBA musi pozostać dostępne. Zweryfikuj także, czy wymagane czcionki i zasoby zewnętrzne są dostępne w środowisku, w którym otwierana lub renderowana będzie skonwertowana prezentacja.

W przypadku ważnych dokumentów otwórz wygenerowany PPTX programowo i sprawdź kluczowe liczby slajdów oraz zawartość, a następnie porównaj jego wygląd i zachowanie pokazu slajdów w docelowej aplikacji odtwarzającej. Nie traktuj udanego wywołania [Presentation.save](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) jako dowodu, że każda funkcja starsza ma dokładny odpowiednik w PPTX.

## **Kiedy używać PPTX**

Używaj PPTX, gdy prezentacja będzie edytowana w aktualnych wersjach PowerPoint, wymieniana z systemami pracującymi z pakietami Open XML lub przechowywana w formacie łatwiejszym do przeglądania i odzyskiwania niż starszy binarny PPT. Zachowaj oryginalny PPT jako archiwalną lub przywracalną kopię, dopóki skonwertowana prezentacja nie przejdzie Twoich kontroli wierności.

Jeśli potrzebujesz PDF, HTML, obrazów, XPS lub innego typu wyjściowego, skorzystaj z wskazówek specyficznych dla formatu w [Convert Presentations to Multiple Formats](/slides/pl/androidjava/convert-presentation/) zamiast zakładać, że wszystkie cele zachowają edytowalne funkcje PowerPoint.

## **Konwerter online**

Dla okazjonalnego pliku lub szybkiego porównania możesz użyć [online PPT to PPTX converter](https://products.aspose.app/slides/pl/conversion/ppt-to-pptx). Do powtarzalnych konwersji, przetwarzania wsadowego lub obsługi błędów na poziomie aplikacji użyj API Android via Java.

## **Powiązane artykuły**

- [PPT vs PPTX](/slides/pl/androidjava/ppt-vs-pptx/)
- [Save Presentations on Android](/slides/pl/androidjava/save-presentation/)
- [Supported File Formats](/slides/pl/androidjava/supported-file-formats/)
- [Open Presentations on Android](/slides/pl/androidjava/open-presentation/)

## **FAQ**

**Czy mogę konwertować PPT do PPTX bez zainstalowanego Microsoft PowerPoint?**

Tak. Aspose.Slides for Android via Java wczytuje i zapisuje pliki prezentacji bez wymogu Microsoft PowerPoint.

**Czy konwersja PPT do PPTX zachowa całą zawartość dokładnie?**

Zachowuje typową zawartość prezentacji, ale dokładna wierność nie jest gwarantowana dla każdej funkcji starszej lub nieobsługiwanej. Przejrzyj wygenerowany plik, gdy zawiera makra, obiekty OLE lub ActiveX, multimedia, specjalistyczne animacje lub rzadkie czcionki.

**Czy mogę konwertować plik PPT zabezpieczony hasłem?**

Tak, jeśli podasz prawidłowe hasło podczas wczytywania pliku. Brak lub nieprawidłowe hasło powoduje niepowodzenie operacji wczytywania.

**Czy powinienem usunąć plik PPT po konwersji?**

Zachowaj oryginał, dopóki nie zweryfikujesz PPTX w przeglądarkach i przepływach pracy, które mają znaczenie. To zapewnia kopię zapasową na wypadek, gdyby funkcja starsza została skonwertowana inaczej.