---
title: Konwertuj PPT do PPTX w Node.js
linktitle: PPT do PPTX
type: docs
weight: 20
url: /pl/nodejs-java/convert-ppt-to-pptx/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Konwertuj starsze pliki PPT do PPTX w Node.js przy użyciu Aspose.Slides. Zawiera przykłady JavaScript dla konwersji pojedynczych plików i wsadowej, obsługę błędów oraz uwagi dotyczące wierności."
---
## **Przegląd**

PPT jest starszym binarnym formatem PowerPoint, podczas gdy PPTX to nowszy format Open XML. Aspose.Slides for Node.js via Java może wczytać plik PPT i zapisać go jako PPTX bez potrzeby posiadania Microsoft PowerPoint. Ten artykuł pokazuje, jak konwertować pojedynczy plik lub katalog plików oraz wyjaśnia, co należy zweryfikować po konwersji.

## **Konwertowanie pliku PPT do PPTX**

Załaduj plik źródłowy przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/), a następnie wywołaj [Presentation.save](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#save) z argumentem [SaveFormat.Pptx](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/saveformat/). Blok `finally` zwalnia prezentację i zwalnia jej zasoby.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Wczytaj starszą prezentację PPT.
let presentation = new aspose.slides.Presentation("presentation.ppt");
try {
    // Zapisz prezentację w formacie PPTX.
    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Rozszerzenie pliku nie określa formatu wyjściowego samo w sobie; robi to argument [SaveFormat.Pptx](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/saveformat/). Utrzymuj różne ścieżki wejścia i wyjścia, jeśli potrzebujesz zachować oryginalny plik PPT.

## **Konwertowanie wielu plików PPT**

Poniższy przykład konwertuje każdy plik `.ppt` w jednym katalogu. Każdy plik jest przetwarzany niezależnie, więc niepowodzenie jednej konwersji nie zatrzymuje pozostałych.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");

const inputDirectory = "input";
const outputDirectory = "output";
fs.mkdirSync(outputDirectory, { recursive: true });

const inputFiles = fs.readdirSync(inputDirectory, { withFileTypes: true })
    .filter(entry => entry.isFile() && path.extname(entry.name).toLowerCase() === ".ppt")
    .map(entry => entry.name);

for (const fileName of inputFiles) {
    const inputPath = path.join(inputDirectory, fileName);
    const outputFileName = path.basename(fileName, path.extname(fileName)) + ".pptx";
    const outputPath = path.join(outputDirectory, outputFileName);
    let presentation = null;

    try {
        presentation = new aspose.slides.Presentation(inputPath);
        presentation.save(outputPath, aspose.slides.SaveFormat.Pptx);
        console.log("Converted: " + inputPath);
    } catch (error) {
        console.error("Failed: " + inputPath + " (" + error.message + ")");
    } finally {
        if (presentation !== null) {
            presentation.dispose();
        }
    }
}
```

W środowiskach produkcyjnych loguj pełny błąd, zdecyduj, czy istniejący plik wyjściowy może zostać nadpisany, i zapisz nazwy nieudanych plików do kolejki ponownych prób lub przeglądu. Uszkodzone pliki, pliki chronione hasłem otwierane bez wymaganego hasła, niedostępne ścieżki oraz nieobsługiwana zawartość mogą spowodować niepowodzenie konwersji. Zobacz [Prezentacje chronione hasłem](/slides/pl/nodejs-java/password-protected-presentation/) w celu wczytania zaszyfrowanych plików.

## **Wierność i funkcje dziedziczone**

Konwersja zazwyczaj zachowuje slajdy, mastery, układy, tekst, kształty, obrazy, tabele i wykresy. Jednak PPT i PPTX nie odwzorowują każdej funkcji w dokładnie taki sam sposób. Funkcja starsza, dla której nie istnieje odpowiednik w PPTX lub nie jest obsługiwana przez bibliotekę, może zostać znormalizowana, pominięta lub wyświetlona inaczej.

Sprawdź skonwertowany plik, gdy zawiera animacje, przejścia, osadzone lub połączone obiekty OLE, kontrolki ActiveX, osadzone multimedia, rzadkie czcionki lub makra VBA. Zwykły plik PPTX nie jest formatem obsługującym makra, więc użyj odpowiedniego przepływu pracy w przypadku, gdy VBA musi pozostać dostępne. Zweryfikuj także, czy wymagane czcionki i zasoby zewnętrzne są dostępne w środowisku, w którym otwierana lub renderowana będzie skonwertowana prezentacja.

Dla ważnych dokumentów otwórz ponownie wygenerowany PPTX programowo i sprawdź kluczowe liczby slajdów oraz zawartość, a następnie porównaj jego wygląd i zachowanie pokazu slajdów w docelowej przeglądarce. Nie traktuj udanego wywołania [Presentation.save](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#save) jako dowodu, że każda funkcja starsza ma dokładny odpowiednik w PPTX.

## **Kiedy używać PPTX**

Używaj PPTX, gdy prezentacja będzie edytowana w aktualnych wersjach PowerPoint, wymieniana z systemami pracującymi z pakietami Open XML lub przechowywana w formacie łatwiejszym do przeglądania i odzyskiwania niż starszy binarny PPT. Zachowaj oryginalny PPT jako archiwalną lub przywracającą kopię, dopóki skonwertowana prezentacja nie przejdzie twoich kontroli wierności.

Jeśli potrzebujesz PDF, HTML, obrazów, XPS lub innego typu wyjściowego, skorzystaj z wskazówek specyficznych dla formatu w [Konwertowanie prezentacji do wielu formatów](/slides/pl/nodejs-java/convert-presentation/), zamiast zakładać, że wszystkie cele zachowują edytowalne funkcje PowerPoint.

## **Konwerter online**

Dla okazjonalnego pliku lub szybkiego porównania możesz użyć [internetowego konwertera PPT do PPTX](https://products.aspose.app/slides/pl/conversion/ppt-to-pptx). Do powtarzalnych konwersji, przetwarzania wsadowego lub obsługi błędów na poziomie aplikacji użyj API Node.js via Java.

## **Powiązane artykuły**

- [PPT vs PPTX](/slides/pl/nodejs-java/ppt-vs-pptx/)
- [Zapisywanie prezentacji w Node.js](/slides/pl/nodejs-java/save-presentation/)
- [Obsługiwane formaty plików](/slides/pl/nodejs-java/supported-file-formats/)
- [Otwieranie prezentacji w Node.js](/slides/pl/nodejs-java/open-presentation/)

## **FAQ**

**Czy mogę konwertować PPT do PPTX bez zainstalowanego Microsoft PowerPoint?**

Tak. Aspose.Slides for Node.js via Java wczytuje i zapisuje pliki prezentacji bez wymogu posiadania Microsoft PowerPoint.

**Czy konwersja PPT do PPTX zachowa całą zawartość w 100 %?**

Zachowuje ona typową zawartość prezentacji, ale dokładna wierność nie jest gwarantowana dla każdej funkcji starszej lub nieobsługiwanej. Przejrzyj wygenerowany plik, gdy zawiera makra, obiekty OLE lub ActiveX, multimedia, specjalistyczne animacje lub rzadkie czcionki.

**Czy mogę konwertować plik PPT chroniony hasłem?**

Tak, pod warunkiem podania poprawnego hasła podczas wczytywania pliku. Brak lub nieprawidłowe hasło powoduje niepowodzenie operacji wczytywania.

**Czy powinienem usunąć plik PPT po konwersji?**

Zachowaj oryginał, dopóki nie zweryfikujesz PPTX w przeglądarkach i przepływach pracy, które są dla Ciebie istotne. Dzięki temu masz kopię przywracającą w razie różnic w konwersji funkcji starszych.