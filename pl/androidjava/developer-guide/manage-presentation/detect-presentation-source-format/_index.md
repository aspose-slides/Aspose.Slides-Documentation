---
title: Określenie oryginalnego formatu prezentacji na Androidzie
linktitle: Format źródłowy
type: docs
weight: 35
url: /pl/androidjava/detect-presentation-source-format/
keywords:
- format źródłowy
- wykrywanie formatu prezentacji
- PowerPoint
- OpenDocument
- prezentacja
- PPT
- PPTX
- Android
- Java
- Aspose.Slides
description: "Odczytaj oryginalny format załadowanej prezentacji na Androidzie przy użyciu Aspose.Slides dla Androida w Javie, porównaj API wykrywania i obsługuj pliki, strumienie oraz starsze formaty."
---
## **Przegląd**

Po załadowaniu prezentacji wywołaj metodę [Presentation.getSourceFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#getSourceFormat--) aby określić jej pierwotny format. Metoda jest również dostępna poprzez [IPresentation.getSourceFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentation/#getSourceFormat--). Użyj jej, gdy dalsze przetwarzanie zależy od formatu, z którego została załadowana bieżąca instancja.

Format źródłowy różni się od [SaveFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/saveformat/) wybranego dla pliku wyjściowego. Zapis do innego formatu nie zmienia formatu źródłowego istniejącej instancji.

Przykłady używają Javy i ścieżek plików. Na Androidzie zamień przykładowe ścieżki na ścieżki w dostępnym dla aplikacji magazynie, na przykład w wewnętrznym katalogu plików aplikacji.

## **Odczyt formatu źródłowego pliku**

Ten przykład wymaga istniejącego pliku `sample.pptx`. Ładuje plik i wybiera politykę przetwarzania aplikacji przy użyciu [Presentation.getSourceFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#getSourceFormat--), zamiast nazwy pliku. Zmień ścieżkę wejściową, aby wypróbować inne formaty. Przykład wypisuje wybraną politykę; zamień komunikaty na własną logikę aplikacji.

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

Klasa [SourceFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/sourceformat/) definiuje stałe całkowite, które rozróżniają następujące formaty prezentacji. Poniższe rozszerzenia są konwencjonalne, a nie odtworzeniem oryginalnej nazwy pliku.

| Wartość SourceFormat | Rozszerzenie | Format |
| --- | --- | --- |
| `Ppt` | `.ppt` | prezentacja PowerPoint 97–2003 |
| `Pptx` | `.pptx` | prezentacja Office Open XML |
| `Pptm` | `.pptm` | prezentacja Office Open XML z włączonymi makrami |
| `Pps` | `.pps` | pokaz slajdów PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | pokaz slajdów Office Open XML |
| `Ppsm` | `.ppsm` | pokaz slajdów Office Open XML z włączonymi makrami |
| `Pot` | `.pot` | szablon PowerPoint 97–2003 |
| `Potx` | `.potx` | szablon Office Open XML |
| `Potm` | `.potm` | szablon Office Open XML z włączonymi makrami |
| `Odp` | `.odp` | prezentacja OpenDocument |
| `Otp` | `.otp` | szablon prezentacji OpenDocument |
| `Fodp` | `.fodp` | prezentacja Flat XML ODF |
| `Xml` | `.xml` | prezentacja PowerPoint XML |

## **Odczyt formatu źródłowego ze strumienia**

Ten przykład wymaga istniejącego pliku `sample.pps`. Odczytanie jego bajtów do strumienia w pamięci symuluje dane otrzymane bez nazwy pliku, na przykład wartość w bazie danych lub przesłaną tablicę bajtów. Konstruktor [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) otrzymuje tylko strumień.

```java
import com.aspose.slides.Presentation;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.ByteArrayOutputStream;
import java.io.FileInputStream;

try {
    byte[] bytes;
    try (FileInputStream input = new FileInputStream("sample.pps");
         ByteArrayOutputStream output = new ByteArrayOutputStream()) {
        byte[] buffer = new byte[8192];
        int bytesRead;
        while ((bytesRead = input.read(buffer)) != -1) {
            output.write(buffer, 0, bytesRead);
        }
        bytes = output.toByteArray();
    }
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

PPT, PPS i POT używają tego samego podstawowego formatu binarnego. Przy ładowaniu ze ścieżki pliku rozszerzenie może pomóc odróżnić pokaz slajdów lub szablon. Bez nazwy pliku starsze treści PPS i POT mogą być raportowane jako `SourceFormat.Ppt`; powyższy przykład PPS wypisuje wartość całkowitą `SourceFormat.Ppt`.

Jeśli aplikacja musi zachować rozróżnienie, przechowuj oryginalną nazwę pliku lub metadane podtypu osobno. Rozszerzenie jest użyteczną wskazówką dla tych starszych podtypów, ale nie powinno być jedyną podstawą do identyfikacji dowolnej zawartości prezentacji.

## **Porównaj wykrywanie przed i po załadowaniu**

Użyj [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) i [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentationinfo/#getLoadFormat--) gdy potrzebujesz sprawdzić plik przed załadowaniem pełnego modelu obiektu prezentacji. Użyj [Presentation.getSourceFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#getSourceFormat--) gdy instancja już istnieje.

Ten przykład wymaga `sample.pptx` i wypisuje wartości całkowite `LoadFormat.Pptx` oraz `SourceFormat.Pptx`. W produkcji wybierz odpowiednie API do etapu przetwarzania; już załadowana prezentacja nie wymaga drugiej inspekcji wyłącznie w celu uzyskania jej formatu źródłowego.

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

Wyniki używają stałych z różnych klas: [LoadFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/loadformat/) i [SourceFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/sourceformat/). Nie porównuj ich wartości liczbowych ani nie zakładaj, że każdy format ma identyczne wyniki wykrywania. PowerPoint XML może być zgłoszony jako `LoadFormat.Unknown` przed ładowaniem i jako `SourceFormat.Xml` po ładowaniu.

## **Trzymaj formaty źródłowy i wyjściowy oddzielnie**

Ten przykład wymaga `sample.pptx` i zapisuje `converted.odp`. Wypisuje wartość całkowitą `SourceFormat.Pptx` zarówno przed, jak i po zapisaniu oryginalnej instancji. Tylko nowa instancja załadowana z wyjścia ODP raportuje `Odp`.

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

Prezentacja utworzona od zera przy użyciu `new Presentation()` raportuje `SourceFormat.Pptx`. Nie ma pliku wejściowego: jest to wartość domyślna nowo utworzonej instancji, a nie dowód, że załadowano plik PPTX. Śledź, czy aplikacja utworzyła, czy załadowała instancję osobno, jeśli to rozróżnienie ma znaczenie.

## **Mapowanie formatu źródłowego na rozszerzenie**

Poniższy przykład wymaga `sample.pptx`. Mapuje każdy aktualnie obsługiwany wartość [SourceFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/sourceformat/) na konwencjonalne rozszerzenie, bez analizowania nazwy pliku wejściowego. Zapasowe rozwiązanie zapobiega cichej asignacji rozszerzenia do nierozpoznanej wartości.

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

To mapowanie nie konwertuje pliku ani nie przywraca starszego podtypu PPS/POT utraconego podczas ładowania ze strumienia. Do rzeczywistego zapisu wybierz [SaveFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/saveformat/) explicite, lub użyj konwersji pokazanej w [Save Presentations in Their Original Format](/slides/pl/androidjava/save-presentation/#save-presentations-in-their-original-format).

## **Sprawdź formaty przez zapis i ponowne otwarcie**

Ten niezależny przykład tworzy prezentację i zapisuje trzy pliki w katalogu roboczym, nadpisując pliki o tych samych nazwach. Ponownie otwiera każdy wynik zarówno ze ścieżki, jak i przez strumień w pamięci. Dla PPTX i ODP oba sposoby raportują zapisany format. Dla PPS ładowanie ze ścieżki raportuje `Pps`, podczas gdy ładowanie tych samych bajtów bez nazwy pliku raportuje `Ppt`.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.ByteArrayOutputStream;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    int[] formats = { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };
    String[] extensions = { "pptx", "odp", "pps" };

    for (int i = 0; i < formats.length; i++) {
        String path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        Presentation fromFile = new Presentation(path);
        try {
            byte[] bytes;
            try (FileInputStream input = new FileInputStream(path);
                 ByteArrayOutputStream output = new ByteArrayOutputStream()) {
                byte[] buffer = new byte[8192];
                int bytesRead;
                while ((bytesRead = input.read(buffer)) != -1) {
                    output.write(buffer, 0, bytesRead);
                }
                bytes = output.toByteArray();
            }
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

Poniższa tabela podsumowuje identyfikację formatów źródłowych dla prezentacji o dopasowanych rozszerzeniach. Nazwy oznaczają stałe; przykłady w Javie wypisują ich wartości całkowite:

| Zapisany format | SourceFormat ze ścieżki pliku | SourceFormat ze strumienia bez nazwy |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` odpowiednio | Takie same jak ścieżka pliku |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` odpowiednio | Takie same jak ścieżka pliku |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` odpowiednio | Takie same jak ścieżka pliku |
| ODP, OTP | `Odp`, `Otp` odpowiednio | Takie same jak ścieżka pliku |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

PPS/POT treść jest identyfikowana jako `Ppt` dla strumieni bez nazwy. Tabela opisuje identyfikację formatu, nie zachowanie wszystkich cech prezentacji podczas konwersji.

## **FAQ**

**Czy zapis do ODP zmienia format źródłowy prezentacji załadowanej z PPTX?**

Nie. Istniejąca instancja nadal raportuje `Pptx`. Instancja załadowana z zapisanego pliku ODP raportuje `Odp`.

**Czy strumień zawsze potrafi rozróżnić starszą prezentację, pokaz slajdów i szablon?**

Nie. PPT, PPS i POT mają wspólny format binarny. Przechowuj nazwę pliku lub metadane podtypu osobno, gdy to rozróżnienie jest wymagane.

**Jakiego API powinienem używać, jeśli prezentacja jest już załadowana?**

Użyj [Presentation.getSourceFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#getSourceFormat--). Użyj [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) do inspekcji przed załadowaniem.