---
title: Określenie oryginalnego formatu prezentacji w Javie
linktitle: Format źródłowy
type: docs
weight: 35
url: /pl/java/detect-presentation-source-format/
keywords:
- format źródłowy
- wykrywanie formatu prezentacji
- PowerPoint
- OpenDocument
- prezentacja
- PPT
- PPTX
- Java
- Aspose.Slides
description: "Odczytaj oryginalny format załadowanej prezentacji w Javie przy użyciu Aspose.Slides for Java, porównaj API wykrywania i obsługuj pliki, strumienie oraz starsze formaty."
---
## **Przegląd**

Po załadowaniu prezentacji wywołaj metodę [Presentation.getSourceFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#getSourceFormat--) aby określić jej oryginalny format. Metoda jest również dostępna przez [IPresentation.getSourceFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentation/#getSourceFormat--). Użyj jej, gdy dalsze przetwarzanie zależy od formatu, z którego została załadowana bieżąca instancja.

Format źródłowy różni się od [SaveFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/saveformat/) wybranego dla pliku wyjściowego. Zapis do innego formatu nie zmienia formatu źródłowego istniejącej instancji.

## **Odczyt formatu źródłowego pliku**

Ten przykład wymaga istniejącego pliku `sample.pptx`. Ładuje on plik i wybiera politykę przetwarzania aplikacji przy użyciu [Presentation.getSourceFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#getSourceFormat--), zamiast nazwy pliku. Zmień ścieżkę wejściową, aby wypróbować inne formaty. Przykład wypisuje wybraną politykę; zamień komunikaty na własną logikę aplikacji.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SourceFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    switch (presentation.getSourceFormat()) {
        case SourceFormat.Ppt:
        case SourceFormat.Pps:
        case SourceFormat.Pot:
            System.out.println("Use the legacy PowerPoint processing policy.");
            break;
        case SourceFormat.Pptx:
            System.out.println("Use the standard PPTX processing policy.");
            break;
        default:
            System.out.println("Use the general policy for source format " + presentation.getSourceFormat() + ".");
            break;
    }
} finally {
    presentation.dispose();
}
```

## **Rozpoznaj obsługiwane wartości**

Klasa [SourceFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/sourceformat/) definiuje stałe całkowite, które rozróżniają następujące formaty prezentacji. Poniższe rozszerzenia są konwencjonalne i nie stanowią rekonstrukcji oryginalnej nazwy pliku.

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

## **Odczyt formatu źródłowego ze strumienia**

Ten przykład wymaga istniejącego pliku `sample.pps`. Odczytanie jego bajtów do strumienia pamięciowego symuluje dane otrzymane bez nazwy pliku, np. wartość z bazy danych lub przesłaną tablicę bajtów. Konstruktor [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) przyjmuje jedynie strumień.

```java
import com.aspose.slides.Presentation;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

try {
    byte[] bytes = Files.readAllBytes(Paths.get("sample.pps"));
    try (ByteArrayInputStream stream = new ByteArrayInputStream(bytes)) {
        Presentation presentation = new Presentation(stream);
        try {
            System.out.println("Source format: " + presentation.getSourceFormat());
        } finally {
            presentation.dispose();
        }
    }
} catch (IOException exception) {
    System.err.println("Cannot read the presentation: " + exception.getMessage());
}
```

PPT, PPS i POT używają tego samego podstawowego formatu binarnego. Przy ładowaniu z ścieżki pliku rozszerzenie może pomóc odróżnić pokaz slajdów lub szablon. Bez nazwy pliku starsze treści PPS i POT mogą być zgłaszane jako `SourceFormat.Ppt`; przykład PPS powyżej wypisuje wartość całkowitą `SourceFormat.Ppt`.

Jeśli aplikacja musi zachować tę różnicę, zachowaj oryginalną nazwę pliku lub metadane podtypu oddzielnie. Rozszerzenie jest użyteczną wskazówką dla tych starszych podtypów, ale nie powinno być jedyną podstawą do identyfikacji dowolnej zawartości prezentacji.

## **Porównanie wykrywania przed i po załadowaniu**

Użyj [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) i [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentationinfo/#getLoadFormat--) gdy potrzebujesz zbadać plik przed załadowaniem pełnego modelu obiektowego prezentacji. Użyj [Presentation.getSourceFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#getSourceFormat--) gdy instancja już istnieje.

Ten przykład wymaga `sample.pptx` i wypisuje wartości całkowite `LoadFormat.Pptx` oraz `SourceFormat.Pptx`. W produkcji wybierz API odpowiednie do etapu przetwarzania; już załadowana prezentacja nie wymaga dodatkowego sprawdzania wyłącznie w celu uzyskania formatu źródłowego.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;

String path = "sample.pptx";
IPresentationInfo information = PresentationFactory.getInstance().getPresentationInfo(path);
System.out.println("Before loading: " + information.getLoadFormat());

Presentation presentation = new Presentation(path);
try {
    System.out.println("After loading: " + presentation.getSourceFormat());
} finally {
    presentation.dispose();
}
```

Wyniki używają stałych z różnych klas: [LoadFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/loadformat/) i [SourceFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/sourceformat/). Nie porównuj ich wartości liczbowych ani nie zakładaj, że każdy format ma identyczne wyniki wykrywania. PowerPoint XML może być zgłoszony jako `LoadFormat.Unknown` przed załadowaniem i jako `SourceFormat.Xml` po załadowaniu.

## **Utrzymanie formatów źródłowego i wyjściowego osobno**

Ten przykład wymaga `sample.pptx` i zapisuje `converted.odp`. Wypisuje wartość całkowitą `SourceFormat.Pptx` zarówno przed, jak i po zapisaniu pierwotnej instancji. Tylko nowa instancja załadowana z wyjściowego pliku ODP raportuje `Odp`.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Before saving: " + presentation.getSourceFormat());

    presentation.save("converted.odp", SaveFormat.Odp);
    System.out.println("After saving: " + presentation.getSourceFormat());

    Presentation reopened = new Presentation("converted.odp");
    try {
        System.out.println("Reopened output: " + reopened.getSourceFormat());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Prezentacja utworzona od zera za pomocą `new Presentation()` raportuje `SourceFormat.Pptx`. Nie ma pliku wejściowego: jest to wartość domyślna dla nowo utworzonej instancji, a nie dowód, że został załadowany plik PPTX. Śledź, czy aplikacja stworzyła, czy załadowała instancję, jeśli ta różnica ma znaczenie.

## **Mapowanie formatu źródłowego na rozszerzenie**

Poniższy przykład wymaga `sample.pptx`. Mapuje on każdą aktualnie obsługiwaną wartość [SourceFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/sourceformat/) na konwencjonalne rozszerzenie, bez parsowania nazwy pliku wejściowego. Mechanizm awaryjny zapobiega cichemu przypisywaniu rozszerzenia do nierozpoznanej wartości.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SourceFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    String extension;
    switch (presentation.getSourceFormat()) {
        case SourceFormat.Ppt:
            extension = ".ppt";
            break;
        case SourceFormat.Pptx:
            extension = ".pptx";
            break;
        case SourceFormat.Pptm:
            extension = ".pptm";
            break;
        case SourceFormat.Pps:
            extension = ".pps";
            break;
        case SourceFormat.Ppsx:
            extension = ".ppsx";
            break;
        case SourceFormat.Ppsm:
            extension = ".ppsm";
            break;
        case SourceFormat.Pot:
            extension = ".pot";
            break;
        case SourceFormat.Potx:
            extension = ".potx";
            break;
        case SourceFormat.Potm:
            extension = ".potm";
            break;
        case SourceFormat.Odp:
            extension = ".odp";
            break;
        case SourceFormat.Otp:
            extension = ".otp";
            break;
        case SourceFormat.Fodp:
            extension = ".fodp";
            break;
        case SourceFormat.Xml:
            extension = ".xml";
            break;
        default:
            extension = null;
            break;
    }

    System.out.println(extension != null ? extension : "No extension mapping is available.");
} finally {
    presentation.dispose();
}
```

To mapowanie nie konwertuje pliku ani nie przywraca starszego podtypu PPS/POT utraconego podczas ładowania ze strumienia. Do rzeczywistego zapisu wybierz [SaveFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/saveformat/) explicite, lub użyj konwersji pokazanej w [Save Presentations in Their Original Format](/slides/pl/java/save-presentation/#save-presentations-in-their-original-format).

## **Weryfikacja formatów przez zapis i ponowne otwarcie**

Ten samodzielny przykład tworzy prezentację i zapisuje trzy pliki w katalogu roboczym, nadpisując pliki o tych samych nazwach. Ponownie otwiera każdy wynik zarówno z użyciem ścieżki, jak i strumienia pamięciowego. Dla PPTX i ODP oba sposoby raportują zapisany format. Dla PPS ładowanie z ścieżki raportuje `Pps`, podczas gdy ładowanie tych samych bajtów bez nazwy pliku raportuje `Ppt`.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    int[] formats = { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };
    String[] extensions = { "pptx", "odp", "pps" };

    for (int i = 0; i < formats.length; i++) {
        String path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        Presentation fromFile = new Presentation(path);
        try {
            byte[] bytes = Files.readAllBytes(Paths.get(path));
            try (ByteArrayInputStream stream = new ByteArrayInputStream(bytes)) {
                Presentation fromStream = new Presentation(stream);
                try {
                    System.out.println(extensions[i] + ": file=" + fromFile.getSourceFormat() + ", stream=" + fromStream.getSourceFormat());
                } finally {
                    fromStream.dispose();
                }
            }
        } finally {
            fromFile.dispose();
        }
    }
} catch (IOException exception) {
    System.err.println("Cannot read a saved presentation: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

Poniższa tabela podsumowuje identyfikację formatu źródłowego dla prezentacji z pasującymi rozszerzeniami. Nazwy oznaczają stałe; przykłady w Javie wypisują ich wartości całkowite:

| Zapisany format | SourceFormat z ścieżki pliku | SourceFormat z beznazowego strumienia |
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

Zawartość PPS/POT jest identyfikowana jako `Ppt` dla strumieni bez nazwy. Tabela opisuje identyfikację formatu, a nie zachowanie każdej funkcji prezentacji podczas konwersji.

## **FAQ**

**Czy zapis do ODP zmienia format źródłowy prezentacji załadowanej z PPTX?**

Nie. Istniejąca instancja nadal raportuje `Pptx`. Instancja załadowana z zapisanego pliku ODP raportuje `Odp`.

**Czy strumień zawsze może odróżnić starszą prezentację, pokaz slajdów i szablon?**

Nie. PPT, PPS i POT współdzielą format binarny. Zachowaj nazwę pliku lub metadane podtypu oddzielnie, gdy ta różnica jest wymagana.

**Jakie API powinienem używać, jeśli prezentacja jest już załadowana?**

Użyj [Presentation.getSourceFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#getSourceFormat--). Użyj [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) do inspekcji przed załadowaniem.