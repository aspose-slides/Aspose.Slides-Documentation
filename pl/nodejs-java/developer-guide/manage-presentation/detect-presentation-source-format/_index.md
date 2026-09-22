---
title: Określenie oryginalnego formatu prezentacji w Node.js
linktitle: Format źródłowy
type: docs
weight: 35
url: /pl/nodejs-java/detect-presentation-source-format/
keywords:
- format źródłowy
- wykryj format prezentacji
- PowerPoint
- OpenDocument
- prezentacja
- PPT
- PPTX
- Node.js
- JavaScript
- Aspose.Slides
description: "Odczytaj oryginalny format załadowanej prezentacji w Node.js przy użyciu Aspose.Slides for Node.js przez Java, porównaj API wykrywania i obsłuż pliki, strumienie oraz starsze formaty."
---
## **Przegląd**

Po załadowaniu prezentacji wywołaj metodę [Presentation.getSourceFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#getSourceFormat), aby określić jej oryginalny format. Używaj jej, gdy dalsze przetwarzanie zależy od formatu, z którego została załadowana bieżąca instancja.

Format źródłowy różni się od [SaveFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/saveformat/) wybranego dla pliku wyjściowego. Zapis do innego formatu nie zmienia formatu źródłowego istniejącej instancji.

## **Odczytanie formatu źródłowego pliku**

Ten przykład wymaga istniejącego pliku `sample.pptx`. Ładuje on plik i wybiera politykę przetwarzania aplikacji przy użyciu [Presentation.getSourceFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#getSourceFormat), zamiast nazwy pliku. Zmień ścieżkę wejściową, aby wypróbować inne formaty. Przykład wypisuje wybraną politykę; zastąp komunikaty własną logiką aplikacji.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    switch (presentation.getSourceFormat()) {
        case aspose.SourceFormat.Ppt:
        case aspose.SourceFormat.Pps:
        case aspose.SourceFormat.Pot:
            console.log("Use the legacy PowerPoint processing policy.");
            break;
        case aspose.SourceFormat.Pptx:
            console.log("Use the standard PPTX processing policy.");
            break;
        default:
            console.log("Use the general policy for source format " + presentation.getSourceFormat() + ".");
            break;
    }
} finally {
    presentation.dispose();
}
```

## **Rozpoznaj obsługiwane wartości**

Klasa [SourceFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sourceformat/) definiuje stałe liczbowe, które rozróżniają następujące formaty prezentacji. Poniższe rozszerzenia są konwencjonalne, a nie odtworzeniem oryginalnej nazwy pliku.

| Wartość SourceFormat | Rozszerzenie | Format |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003 presentation |
| `Pptx` | `.pptx` | Office Open XML presentation |
| `Pptm` | `.pptm` | Macro-enabled Office Open XML presentation |
| `Pps` | `.pps` | PowerPoint 97–2003 slide show |
| `Ppsx` | `.ppsx` | Office Open XML slide show |
| `Ppsm` | `.ppsm` | Macro-enabled Office Open XML slide show |
| `Pot` | `.pot` | PowerPoint 97–2003 template |
| `Potx` | `.potx` | Office Open XML template |
| `Potm` | `.potm` | Macro-enabled Office Open XML template |
| `Odp` | `.odp` | OpenDocument presentation |
| `Otp` | `.otp` | OpenDocument presentation template |
| `Fodp` | `.fodp` | Flat XML ODF presentation |
| `Xml` | `.xml` | PowerPoint XML presentation |

## **Odczytanie formatu źródłowego ze strumienia**

Ten przykład wymaga istniejącego pliku `sample.pps`. Odczytanie jego bajtów do strumienia pamięciowego symuluje dane otrzymane bez nazwy pliku, np. wartość z bazy danych lub przesłaną tablicę bajtów. Konstruktor [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) przyjmuje jedynie strumień.

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const buffer = fs.readFileSync("sample.pps");
const bytes = java.newArray("byte", Array.from(buffer));
const stream = java.newInstanceSync("java.io.ByteArrayInputStream", bytes);
try {
    const presentation = new aspose.Presentation(stream);
    try {
        console.log("Source format: " + presentation.getSourceFormat());
    } finally {
        presentation.dispose();
    }
} finally {
    stream.close();
}
```

PPT, PPS i POT używają tego samego podstawowego formatu binarnego. Przy ładowaniu z ścieżki pliku rozszerzenie może pomóc odróżnić pokaz slajdów lub szablon. Bez nazwy pliku starsza zawartość PPS i POT może być zgłaszana jako `SourceFormat.Ppt`; powyższy przykład PPS wypisuje wartość całkowitą `SourceFormat.Ppt`.

Jeśli aplikacja musi zachować to rozróżnienie, przechowuj oryginalną nazwę pliku lub metadane podtypu osobno. Rozszerzenie jest przydatną wskazówką dla tych starszych podtypów, ale nie powinno być jedyną podstawą identyfikacji dowolnej zawartości prezentacji.

## **Porównaj wykrywanie przed i po załadowaniu**

Użyj [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) i [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationinfo/#getLoadFormat), gdy potrzebujesz zbadać plik przed pełnym załadowaniem jego modelu obiektowego. Użyj [Presentation.getSourceFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#getSourceFormat), gdy instancja już istnieje.

Ten przykład wymaga `sample.pptx` i wypisuje wartości liczbowe `LoadFormat.Pptx` oraz `SourceFormat.Pptx`. W środowisku produkcyjnym wybierz API odpowiednie do etapu przetwarzania; już załadowana prezentacja nie wymaga drugiej inspekcji wyłącznie w celu uzyskania jej formatu źródłowego.

```javascript
const aspose = require("aspose.slides.via.java");

const path = "sample.pptx";
const information = aspose.PresentationFactory.getInstance().getPresentationInfo(path);
console.log("Before loading: " + information.getLoadFormat());

const presentation = new aspose.Presentation(path);
try {
    console.log("After loading: " + presentation.getSourceFormat());
} finally {
    presentation.dispose();
}
```

Wyniki używają stałych z różnych klas: [LoadFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/loadformat/) i [SourceFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sourceformat/). Nie porównuj ich wartości liczbowych ani nie zakładaj, że każdy format ma identyczne wyniki wykrywania. PowerPoint XML może być zgłaszany jako `LoadFormat.Unknown` przed załadowaniem i jako `SourceFormat.Xml` po załadowaniu.

## **Utrzymuj osobno formaty źródłowe i wyjściowe**

Ten przykład wymaga `sample.pptx` i zapisuje `converted.odp`. Wypisuje wartość liczbową `SourceFormat.Pptx` zarówno przed, jak i po zapisaniu oryginalnej instancji. Tylko nowa instancja wczytana z pliku ODP zgłasza `Odp`.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    console.log("Before saving: " + presentation.getSourceFormat());

    presentation.save("converted.odp", aspose.SaveFormat.Odp);
    console.log("After saving: " + presentation.getSourceFormat());

    const reopened = new aspose.Presentation("converted.odp");
    try {
        console.log("Reopened output: " + reopened.getSourceFormat());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Prezentacja utworzona od podstaw za pomocą `new Presentation()` zgłasza `SourceFormat.Pptx`. Nie ma pliku wejściowego: jest to domyślna wartość dla nowo utworzonej instancji, a nie dowód, że plik PPTX został załadowany. Śledź osobno, czy aplikacja utworzyła, czy wczytała instancję, jeśli to rozróżnienie ma znaczenie.

## **Mapowanie formatu źródłowego na rozszerzenie**

Poniższy przykład wymaga `sample.pptx`. Mapuje każdą aktualnie obsługiwaną wartość [SourceFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sourceformat/) na konwencjonalne rozszerzenie, bez parsowania nazwy pliku wejściowego. Zapasowy mechanizm zapobiega cichej asignacji rozszerzenia do nie rozpoznanej wartości.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    let extension;
    switch (presentation.getSourceFormat()) {
        case aspose.SourceFormat.Ppt:
            extension = ".ppt";
            break;
        case aspose.SourceFormat.Pptx:
            extension = ".pptx";
            break;
        case aspose.SourceFormat.Pptm:
            extension = ".pptm";
            break;
        case aspose.SourceFormat.Pps:
            extension = ".pps";
            break;
        case aspose.SourceFormat.Ppsx:
            extension = ".ppsx";
            break;
        case aspose.SourceFormat.Ppsm:
            extension = ".ppsm";
            break;
        case aspose.SourceFormat.Pot:
            extension = ".pot";
            break;
        case aspose.SourceFormat.Potx:
            extension = ".potx";
            break;
        case aspose.SourceFormat.Potm:
            extension = ".potm";
            break;
        case aspose.SourceFormat.Odp:
            extension = ".odp";
            break;
        case aspose.SourceFormat.Otp:
            extension = ".otp";
            break;
        case aspose.SourceFormat.Fodp:
            extension = ".fodp";
            break;
        case aspose.SourceFormat.Xml:
            extension = ".xml";
            break;
        default:
            extension = null;
            break;
    }

    console.log(extension != null ? extension : "No extension mapping is available.");
} finally {
    presentation.dispose();
}
```

To mapowanie nie konwertuje pliku ani nie odzyskuje starszego podtypu PPS/POT utraconego podczas ładowania ze strumienia. Do rzeczywistego zapisu wybierz wyraźnie [SaveFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/saveformat/), lub użyj konwersji pokazanej w [Save Presentations in Their Original Format](/slides/pl/nodejs-java/save-presentation/#save-presentations-in-their-original-format).

## **Sprawdź formaty poprzez zapis i ponowne otwarcie**

Ten samodzielny przykład tworzy prezentację i zapisuje trzy pliki w katalogu roboczym, nadpisując pliki o tych samych nazwach. Otwiera każdy wynik ponownie zarówno z użyciem ścieżki, jak i poprzez strumień pamięciowy. Dla PPTX i ODP oba sposoby zgłaszają zapisany format. Dla PPS ładowanie ze ścieżki zgłasza `Pps`, podczas gdy ładowanie tych samych bajtów bez nazwy pliku zgłasza `Ppt`.

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.Presentation();
try {
    const formats = [aspose.SaveFormat.Pptx, aspose.SaveFormat.Odp, aspose.SaveFormat.Pps];
    const extensions = ["pptx", "odp", "pps"];

    for (let i = 0; i < formats.length; i++) {
        const path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        const fromFile = new aspose.Presentation(path);
        try {
            const buffer = fs.readFileSync(path);
            const bytes = java.newArray("byte", Array.from(buffer));
            const stream = java.newInstanceSync("java.io.ByteArrayInputStream", bytes);
            try {
                const fromStream = new aspose.Presentation(stream);
                try {
                    console.log(extensions[i] + ": file=" + fromFile.getSourceFormat() + ", stream=" + fromStream.getSourceFormat());
                } finally {
                    fromStream.dispose();
                }
            } finally {
                stream.close();
            }
        } finally {
            fromFile.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

Poniższa tabela podsumowuje identyfikację formatu źródłowego dla prezentacji z dopasowanymi rozszerzeniami. Nazwy oznaczają stałe; przykłady JavaScript wypisują ich wartości liczbowe:

| Zapisany format | SourceFormat ze ścieżki pliku | SourceFormat ze strumienia bez nazwy |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` respectively | Same as file path |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` respectively | Same as file path |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` respectively | Same as file path |
| ODP, OTP | `Odp`, `Otp` respectively | Same as file path |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

Zawartość PPS/POT jest identyfikowana jako `Ppt` w strumieniach bez nazwy. Tabela opisuje identyfikację formatu, a nie zachowanie wszystkich funkcji prezentacji podczas konwersji.

## **FAQ**

**Czy zapis do ODP zmienia format źródłowy prezentacji załadowanej z PPTX?**

Nie. Istniejąca instancja nadal zgłasza `Pptx`. Instancja wczytana z zapisanego pliku ODP zgłasza `Odp`.

**Czy strumień zawsze potrafi odróżnić starszą prezentację, pokaz slajdów i szablon?**

Nie. PPT, PPS i POT używają tego samego formatu binarnego. Przechowuj nazwę pliku lub metadane podtypu osobno, gdy to rozróżnienie jest wymagane.

**Jakie API powinienem używać, jeśli prezentacja jest już załadowana?**

Przeczytaj [Presentation.getSourceFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#getSourceFormat). Użyj [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) do inspekcji przed załadowaniem.