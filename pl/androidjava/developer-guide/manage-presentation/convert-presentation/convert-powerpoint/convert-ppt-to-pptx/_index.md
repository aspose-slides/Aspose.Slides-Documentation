---
title: Konwertuj PPT na PPTX na Androidzie
linktitle: PPT na PPTX
type: docs
weight: 20
url: /pl/androidjava/convert-ppt-to-pptx/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- konwertuj slajd
- konwertuj PPT
- PPT na PPTX
- zapisz PPT jako PPTX
- eksportuj PPT do PPTX
- PowerPoint
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Konwertuj starsze pliki PPT do PPTX na Androidzie przy użyciu Aspose.Slides. Zawiera przykłady Java dla konwersji pojedynczych plików i wsadowej, obsługę błędów oraz uwagi dotyczące wierności."
---
## **Przegląd**

PPT to starszy binarny format PowerPoint, natomiast PPTX jest nowszym formatem Open XML. Aspose.Slides for Android via Java może wczytać plik PPT i zapisać go jako PPTX bez Microsoft PowerPoint. Ten artykuł pokazuje, jak przekonwertować pojedynczy plik lub katalog plików oraz wyjaśnia, co należy zweryfikować po konwersji.

## **Konwertuj plik PPT na PPTX**

Wczytaj plik źródłowy przy pomocy klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/), a następnie wywołaj [Presentation.save](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) z argumentem [SaveFormat.Pptx](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/saveformat/#Pptx). Blok `finally` zwalnia prezentację i uwalnia jej zasoby.

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

Rozszerzenie pliku nie wybiera formatu wyjściowego samo w sobie; robi to argument [SaveFormat.Pptx](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/saveformat/#Pptx). Trzymaj różne ścieżki wejścia i wyjścia, jeśli musisz zachować oryginalny plik PPT.

## **Konwertuj wiele plików PPT**

Poniższy przykład konwertuje każdy plik `.ppt` w jednym katalogu. Każdy plik jest przetwarzany niezależnie, więc jedna nieudana konwersja nie zatrzymuje pozostałych w partii.

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

W środowiskach produkcyjnych należy zapisać pełny wyjątek, zdecydować, czy istniejący plik wyjściowy może zostać nadpisany, oraz zapisać nazwy nieudanych plików do kolejki ponownej próby lub przeglądu. Uszkodzone pliki, pliki chronione hasłem otwierane bez wymaganego hasła, niedostępne ścieżki oraz nieobsługiwana zawartość mogą spowodować niepowodzenie konwersji. Zobacz [Password-Protected Presentations](/androidjava/password-protected-presentation/) w celu wczytania zaszyfrowanych plików.

## **Wierność i funkcje dziedziczone**

Konwersja zazwyczaj zachowuje slajdy, mastery, układy, tekst, kształty, obrazy, tabele i wykresy. Jednak PPT i PPTX nie odwzorowują każdej funkcji dokładnie w ten sam sposób. Funkcja starsza, która nie ma odpowiednika w PPTX lub nie jest obsługiwana przez bibliotekę, może zostać znormalizowana, pominięta lub wyświetlona inaczej.

Sprawdź przekonwertowany plik, gdy zawiera animacje, przejścia, osadzone lub powiązane obiekty OLE, kontrolki ActiveX, osadzone multimedia, nietypowe czcionki lub makra VBA. Zwykły plik PPTX nie jest formatem obsługującym makra, więc użyj odpowiedniego przepływu pracy z obsługą makr, gdy VBA musi pozostać dostępne. Również zweryfikuj, czy wymagane czcionki i zasoby zewnętrzne są dostępne w środowisku, w którym otwierana lub renderowana będzie przekonwertowana prezentacja.

Dla ważnych dokumentów otwórz ponownie wygenerowany PPTX programowo i sprawdź liczbę kluczowych slajdów oraz zawartość, a następnie porównaj jego wygląd i zachowanie pokazu slajdów w docelowym przeglądarce. Nie traktuj udanego wywołania [Presentation.save](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) jako dowodu, że każda funkcja dziedziczona ma dokładny odpowiednik w PPTX.

## **Kiedy używać PPTX**

Używaj PPTX, gdy prezentacja będzie edytowana w aktualnych wersjach PowerPoint, wymieniana z systemami obsługującymi pakiety Open XML lub przechowywana w formacie, który jest łatwiejszy do inspekcji i odzyskania niż starszy binarny PPT. Przechowuj oryginalny PPT jako kopię archiwalną lub zapasową, dopóki przekonwertowana prezentacja nie przejdzie Twoich kontroli wierności.

Jeśli potrzebujesz zamiast tego PDF, HTML, obrazów, XPS lub innego formatu wyjściowego, użyj wskazówek specyficznych dla formatu w [Convert Presentations to Multiple Formats](/androidjava/convert-presentation/), zamiast zakładać, że wszystkie cele zachowują edytowalne funkcje PowerPoint.

## **Konwerter online**

Dla jednorazowego pliku lub szybkiego porównania możesz użyć [online PPT to PPTX converter](https://products.aspose.app/slides/pl/conversion/ppt-to-pptx). Do powtarzalnych konwersji, przetwarzania wsadowego lub obsługi błędów na poziomie aplikacji użyj API Android via Java.

## **Powiązane artykuły**

- [PPT vs PPTX](/androidjava/ppt-vs-pptx/)
- [Zapisz prezentacje na Androidzie](/androidjava/save-presentation/)
- [Obsługiwane formaty plików](/androidjava/supported-file-formats/)
- [Otwórz prezentacje na Androidzie](/androidjava/open-presentation/)

## **FAQ**

**Czy mogę konwertować PPT na PPTX bez zainstalowanego Microsoft PowerPoint?**

Tak. Aspose.Slides for Android via Java wczytuje i zapisuje pliki prezentacji bez wymogu posiadania Microsoft PowerPoint.

**Czy konwersja PPT na PPTX zachowa całą zawartość dokładnie?**

Zachowuje ona typową zawartość prezentacji, ale dokładna wierność nie jest gwarantowana dla każdej funkcji dziedziczonej lub nieobsługiwanej. Przejrzyj wygenerowany plik, gdy zawiera makra, obiekty OLE lub ActiveX, multimedia, specjalistyczne animacje lub nietypowe czcionki.

**Czy mogę konwertować plik PPT chroniony hasłem?**

Tak, jeśli podasz poprawne hasło podczas wczytywania pliku. Brak lub nieprawidłowe hasło powoduje niepowodzenie operacji wczytywania.

**Czy powinienem usunąć plik PPT po konwersji?**

Zachowaj oryginał, dopóki nie zweryfikujesz PPTX w przeglądarkach i przepływach pracy, które są dla Ciebie istotne. Zapewnia to kopię zapasową, jeśli funkcja dziedziczona zostanie skonwertowana inaczej.