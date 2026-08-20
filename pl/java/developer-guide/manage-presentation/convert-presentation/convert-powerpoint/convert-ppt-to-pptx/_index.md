---
title: Konwertuj PPT na PPTX w Javie
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
description: "Konwertuj starsze pliki PPT na PPTX w Javie przy użyciu Aspose.Slides. Zawiera przykłady Java dla konwersji pojedynczych plików i wsadowej, obsługę błędów oraz uwagi dotyczące wierności."
---
## **Przegląd**

PPT jest starszym, binarnym formatem PowerPoint, natomiast PPTX to nowszy format Open XML. Aspose.Slides for Java może wczytać plik PPT i zapisać go jako PPTX bez Microsoft PowerPoint. Ten artykuł pokazuje, jak przekonwertować pojedynczy plik lub katalog plików oraz wyjaśnia, co należy sprawdzić po konwersji.

## **Konwersja pliku PPT do PPTX**

Wczytaj plik źródłowy przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/), a następnie wywołaj [Presentation.save](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#save-java.lang.String-int-) z parametrem [SaveFormat.Pptx](https://reference.aspose.com/slides/pl/java/com.aspose.slides/saveformat/#Pptx). Blok `finally` zwalnia prezentację i uwalnia jej zasoby.

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

Rozszerzenie pliku nie określa formatu wyjściowego samo w sobie; robi to argument [SaveFormat.Pptx](https://reference.aspose.com/slides/pl/java/com.aspose.slides/saveformat/#Pptx). Zachowaj różne ścieżki wejścia i wyjścia, jeśli musisz zachować oryginalny plik PPT.

## **Konwersja wielu plików PPT**

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

W środowiskach produkcyjnych należy logować pełne wyjątki, zdecydować, czy istniejący plik wyjściowy może zostać nadpisany, oraz zapisywać nazwy nieudanych plików do kolejki ponownego przetworzenia lub przeglądu. Uszkodzone pliki, pliki chronione hasłem otwierane bez wymaganego hasła, niedostępne ścieżki oraz nieobsługiwana zawartość mogą spowodować niepowodzenie konwersji. Zobacz [Password-Protected Presentations](/java/password-protected-presentation/) w celu wczytania zaszyfrowanych plików.

## **Wierność i funkcje przestarzałe**

Konwersja zazwyczaj zachowuje slajdy, wzorce, układy, tekst, kształty, obrazy, tabele i wykresy. Jednak PPT i PPTX nie odzwierciedlają każdej funkcji w dokładnie taki sam sposób. Funkcja przestarzała, dla której nie istnieje odpowiednik w PPTX lub nie jest obsługiwana przez bibliotekę, może zostać znormalizowana, pominięta lub wyświetlona inaczej.

Sprawdź przekonwertowany plik, gdy zawiera animacje, przejścia, osadzone lub powiązane obiekty OLE, kontrolki ActiveX, osadzone multimedia, nietypowe czcionki lub makra VBA. Zwykły plik PPTX nie jest formatem obsługującym makra, więc użyj odpowiedniego przepływu pracy obsługującego makra, gdy VBA musi pozostać dostępne. Zweryfikuj także, czy wymagane czcionki i zasoby externalne są dostępne w środowisku, w którym przekonwertowana prezentacja będzie otwierana lub renderowana.

W przypadku ważnych dokumentów otwórz ponownie wygenerowany plik PPTX programowo i sprawdź liczbę slajdów oraz zawartość, a następnie porównaj jego wygląd i zachowanie pokazu slajdów w docelowej aplikacji. Nie traktuj pomyślnego wywołania [Presentation.save](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#save-java.lang.String-int-) jako dowodu, że każda funkcja przestarzała ma dokładny odpowiednik w PPTX.

## **Kiedy używać PPTX**

Używaj PPTX, gdy prezentacja będzie edytowana w aktualnych wersjach PowerPoint, wymieniana z systemami pracującymi z pakietami Open XML lub przechowywana w formacie łatwiejszym do przeglądu i odzyskania niż starszy binarny PPT. Zachowaj oryginalny plik PPT jako kopię archiwalną lub przywracania, dopóki przekonwertowana prezentacja nie przejdzie Twoich kontroli wierności.

Jeśli potrzebujesz zamiast tego PDF, HTML, obrazów, XPS lub innego typu wyjścia, skorzystaj z instrukcji specyficznych dla formatu w [Convert Presentations to Multiple Formats](/java/convert-presentation/), zamiast zakładać, że wszystkie docelowe formaty zachowują edytowalne funkcje PowerPoint.

## **Konwerter online**

W przypadku okazjonalnego pliku lub szybkiego porównania możesz skorzystać z [online PPT to PPTX converter](https://products.aspose.app/slides/pl/conversion/ppt-to-pptx). Do powtarzalnych konwersji, przetwarzania wsadowego lub obsługi błędów na poziomie aplikacji użyj API Java.

## **Powiązane artykuły**

- [PPT vs PPTX](/java/ppt-vs-pptx/)
- [Zapisywanie prezentacji w Javie](/java/save-presentation/)
- [Obsługiwane formaty plików](/java/supported-file-formats/)
- [Otwieranie prezentacji w Javie](/java/open-presentation/)

## **FAQ**

**Czy mogę konwertować PPT na PPTX bez zainstalowanego Microsoft PowerPoint?**

Tak. Aspose.Slides for Java wczytuje i zapisuje pliki prezentacji bez wymogu posiadania Microsoft PowerPoint.

**Czy konwersja PPT do PPTX zachowa całą zawartość dokładnie?**

Zachowuje ona typową zawartość prezentacji, ale dokładna wierność nie jest gwarantowana dla każdej funkcji przestarzałej lub nieobsługiwanej. Przejrzyj wygenerowany plik, gdy zawiera makra, obiekty OLE lub ActiveX, multimedia, specjalistyczne animacje lub nietypowe czcionki.

**Czy mogę konwertować plik PPT chroniony hasłem?**

Tak, pod warunkiem podania prawidłowego hasła podczas wczytywania pliku. Brak lub nieprawidłowe hasło powoduje niepowodzenie operacji wczytywania.

**Czy powinienem usunąć plik PPT po konwersji?**

Zachowaj oryginał, dopóki nie zweryfikujesz pliku PPTX w przeglądarkach i procesach, które są dla Ciebie istotne. To zapewnia kopię przywracania, jeśli funkcja przestarzała zostanie skonwertowana w inny sposób.