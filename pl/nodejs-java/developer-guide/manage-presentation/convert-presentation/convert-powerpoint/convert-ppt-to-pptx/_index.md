---
title: Konwertuj PPT na PPTX w Node.js
linktitle: PPT na PPTX
type: docs
weight: 20
url: /pl/nodejs-java/convert-ppt-to-pptx/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Konwertuj starsze pliki PPT na PPTX w Node.js przy użyciu Aspose.Slides. Zawiera przykłady JavaScript dla konwersji pojedynczych plików i wsadowej, obsługę błędów oraz uwagi dotyczące wierności."
---
## **Przegląd**

PPT jest starszym binarnym formatem PowerPoint, natomiast PPTX jest nowszym formatem Open XML. Aspose.Slides for Node.js via Java może wczytać plik PPT i zapisać go jako PPTX bez Microsoft PowerPoint. Ten artykuł pokazuje, jak konwertować pojedynczy plik lub katalog plików oraz wyjaśnia, co należy zweryfikować po konwersji.

## **Konwertowanie pliku PPT do PPTX**

Załaduj plik źródłowy za pomocą klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/), a następnie wywołaj [Presentation.save](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#save) z argumentem [SaveFormat.Pptx](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/saveformat/). Blok `finally` zwalnia prezentację i uwalnia jej zasoby.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Załaduj starszą prezentację PPT.
let presentation = new aspose.slides.Presentation("presentation.ppt");
try {
    // Zapisz prezentację w formacie PPTX.
    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Rozszerzenie pliku nie wybiera formatu wyjściowego samo w sobie; robi to argument [SaveFormat.Pptx](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/saveformat/). Zachowaj różne ścieżki wejścia i wyjścia, jeśli potrzebujesz zachować oryginalny plik PPT.

## **Konwertowanie wielu plików PPT**

Poniższy przykład konwertuje każdy plik `.ppt` w jednym katalogu. Każdy plik jest przetwarzany niezależnie, więc niepowodzenie jednej konwersji nie zatrzymuje pozostałych w partii.

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

W środowiskach produkcyjnych należy rejestrować pełny błąd, decydować, czy istniejący plik wyjściowy może zostać nadpisany, oraz zapisywać nazwy nieudanych plików do kolejki ponownego przetworzenia lub przeglądu. Uszkodzone pliki, pliki zabezpieczone hasłem otwierane bez wymaganego hasła, niedostępne ścieżki oraz nieobsługiwana zawartość mogą spowodować niepowodzenie konwersji. Zobacz sekcję [Password-Protected Presentations](/nodejs-java/password-protected-presentation/) aby wczytywać zaszyfrowane pliki.

## **Wierność i funkcje starszej wersji**

Konwersja zazwyczaj zachowuje slajdy, wzory, układy, tekst, kształty, obrazy, tabele i wykresy. Jednak PPT i PPTX nie przedstawiają każdej funkcji w dokładnie taki sam sposób. Funkcja starszej wersji, która nie ma odpowiednika w PPTX lub nie jest wspierana przez bibliotekę, może zostać znormalizowana, pominięta lub wyświetlona inaczej.

Sprawdź przekonwertowany plik, gdy zawiera animacje, przejścia, osadzone lub połączone obiekty OLE, kontrolki ActiveX, osadzone media, nietypowe czcionki lub makra VBA. Zwykły plik PPTX nie jest formatem obsługującym makra, więc użyj odpowiedniego przepływu pracy obsługującego makra, gdy VBA musi pozostać dostępne. Zweryfikuj także, czy wymagane czcionki i zasoby zewnętrzne są dostępne w środowisku, w którym przekonwertowana prezentacja zostanie otwarta lub renderowana.

W przypadku ważnych dokumentów otwórz ponownie wygenerowany PPTX programowo i sprawdź liczbę kluczowych slajdów oraz zawartość, a następnie porównaj jego wygląd i zachowanie pokazu slajdów w docelowym odbiorcy. Nie traktuj udanego wywołania [Presentation.save](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#save) jako dowodu, że każda funkcja starszej wersji ma dokładny odpowiednik w PPTX.

## **Kiedy używać PPTX**

Używaj PPTX, gdy prezentacja będzie edytowana w aktualnych wersjach PowerPoint, wymieniana z systemami obsługującymi pakiety Open XML lub przechowywana w formacie łatwiejszym do przeglądania i odzyskiwania niż starszy binarny PPT. Zachowaj oryginalny plik PPT jako kopię archiwalną lub przywracającą, dopóki skonwertowana prezentacja nie przejdzie Twoich kontroli wierności.

Jeśli potrzebujesz zamiast tego PDF, HTML, obrazów, XPS lub innego typu wyjściowego, użyj wskazówek specyficznych dla formatu w sekcji [Convert Presentations to Multiple Formats](/nodejs-java/convert-presentation/) zamiast zakładać, że wszystkie cele zachowują edytowalne funkcje PowerPoint.

## **Konwerter online**

W przypadku pojedynczego pliku lub szybkiego porównania możesz skorzystać z [online PPT to PPTX converter](https://products.aspose.app/slides/pl/conversion/ppt-to-pptx). Do powtarzalnych konwersji, przetwarzania wsadowego lub obsługi błędów na poziomie aplikacji użyj interfejsu API Node.js via Java.

## **Powiązane artykuły**

- [PPT vs PPTX](/nodejs-java/ppt-vs-pptx/)
- [Save Presentations in Node.js](/nodejs-java/save-presentation/)
- [Supported File Formats](/nodejs-java/supported-file-formats/)
- [Open Presentations in Node.js](/nodejs-java/open-presentation/)

## **FAQ**

**Czy mogę konwertować PPT na PPTX bez zainstalowanego Microsoft PowerPoint?**

Tak. Aspose.Slides for Node.js via Java wczytuje i zapisuje pliki prezentacji bez wymogu Microsoft PowerPoint.

**Czy konwersja PPT do PPTX zachowa całą zawartość dokładnie?**

Zachowuje ona typową zawartość prezentacji, ale dokładna wierność nie jest gwarantowana dla każdej funkcji starszej wersji lub nieobsługiwanej. Przejrzyj wygenerowany plik, gdy zawiera makra, obiekty OLE lub ActiveX, media, specjalistyczne animacje lub nietypowe czcionki.

**Czy mogę konwertować plik PPT chroniony hasłem?**

Tak, jeśli podasz poprawne hasło podczas wczytywania pliku. Brak lub nieprawidłowe hasło powoduje niepowodzenie operacji wczytywania.

**Czy powinienem usunąć plik PPT po konwersji?**

Zachowaj oryginał, dopóki nie zweryfikujesz PPTX w odbiorcach i przepływach pracy, które są dla Ciebie istotne. To zapewnia kopię awaryjną, jeśli funkcja starszej wersji zostanie skonwertowana inaczej.