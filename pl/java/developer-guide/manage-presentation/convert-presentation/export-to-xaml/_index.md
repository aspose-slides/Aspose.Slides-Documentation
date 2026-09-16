---
title: Eksportowanie prezentacji do XAML w Javie
linktitle: Prezentacja do XAML
type: docs
weight: 30
url: /pl/java/export-to-xaml/
keywords:
- eksport PowerPoint
- eksport OpenDocument
- eksport prezentacji
- konwersja PowerPoint
- konwersja OpenDocument
- konwersja prezentacji
- PowerPoint do XAML
- OpenDocument do XAML
- prezentacja do XAML
- PPT do XAML
- PPTX do XAML
- ODP do XAML
- zapisz PPT jako XAML
- zapisz PPTX jako XAML
- zapisz ODP jako XAML
- eksport PPT do XAML
- eksport PPTX do XAML
- eksport ODP do XAML
- Java
- Aspose.Slides
description: "Konwertuj slajdy PowerPoint i OpenDocument do XAML w Javie przy użyciu Aspose.Slides — szybkie, niezależne od Office rozwiązanie, które zachowuje układ."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak wyeksportować prezentacje PowerPoint do XAML przy użyciu Aspose.Slides. Zawiera krótki wstęp do XAML, pokazuje, jak zapisać prezentację w formacie XAML z ustawieniami domyślnymi oraz demonstruje, jak dostosować eksport przy użyciu [XamlOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/xamloptions/), w tym eksportowanie ukrytych slajdów. Artykuł odpowiada również na kilka powszechnych pytań dotyczących czcionek awaryjnych, kompatybilności stosu XAML oraz zachowania przy eksporcie ukrytych slajdów.

## **O XAML**

XAML to język znaczników oparty na XML, używany do opisywania interfejsów użytkownika w frameworkach takich jak WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) i Xamarin.Forms.

Można pracować z plikami XAML w wizualnym projektancie lub pisać i edytować znacznik bezpośrednio.

## **Eksportowanie prezentacji do XAML z opcjami domyślnymi**

Poniższy przykład w języku Java pokazuje, jak wyeksportować prezentację do XAML z ustawieniami domyślnymi:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions xamlOptions = new XamlOptions();
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

Domyślnie wyeksportowane slajdy są zapisywane w podfolderze `pres` bieżącego katalogu roboczego procesu, uzyskiwanego z pustej ścieżki przy użyciu [Paths.get](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Paths.html#get-java.lang.String-java.lang.String...). Folder jest tworzony automatycznie, a wszystkie wymagane obrazy są tam również zapisywane.

Nazwa folderu wyjściowego jest pobierana z nazwy pliku źródłowego bez rozszerzenia. Dla pliku `pres.pptx` pliki wyjściowe mają nazwy `pres/Slide_1.xaml`, `pres/Slide_2.xaml` i tak dalej. Nawet jeśli przekażesz bezwzględną ścieżkę do prezentacji wejściowej, folder wyjściowy zostanie utworzony względem bieżącego katalogu roboczego, a nie obok pliku wejściowego.

## **Eksportowanie prezentacji do XAML z opcjami niestandardowymi**

Użyj interfejsu [IXamlOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ixamloptions/), aby kontrolować sposób, w jaki Aspose.Slides eksportuje prezentację do XAML.

Aby zapisać wynik w niestandardowej lokalizacji, zaimplementuj [IXamlOutputSaver](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ixamloutputsaver/) i przekaż instancję swojej implementacji metodzie [setOutputSaver](https://reference.aspose.com/slides/pl/java/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) klasy [XamlOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/xamloptions/).

Aby uwzględnić ukryte slajdy w wyjściu XAML, wywołaj [setExportHiddenSlides](https://reference.aspose.com/slides/pl/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) z wartością `true`, jak pokazano w poniższym przykładzie Java:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions xamlOptions = new XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

## **Zbieranie wszystkich wygenerowanych artefaktów XAML**

Eksport XAML może wygenerować dokument XAML dla każdego wyeksportowanego slajdu oraz osobne obrazy i zasoby pomocnicze. Przypisz niestandardowy [IXamlOutputSaver](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ixamloutputsaver/) do [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/pl/java/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-), aby otrzymywać te artefakty zamiast używać domyślnego zapisu na systemie plików. Rozpocznij eksport za pomocą specyficznej dla XAML przeciążonej metody [Presentation.save](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-), która przyjmuje opcje XAML.

### **Zrozumienie cyklu życia wywołań zwrotnych**

Eksporter wywołuje [IXamlOutputSaver.save](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) oddzielnie dla każdego wygenerowanego artefaktu:

- `path` identyfikuje artefakt i może zawierać katalogi względne. Zachowaj tę informację, ponieważ XAML może odwoływać się do zasobów przy użyciu ścieżek względnych.
- `data` zawiera bajty artefaktu. Obrazy i inne zasoby binarne nie powinny być dekodowane jako tekst.
- Zapisujący jest odpowiedzialny za przechowanie lub utrwalenie danych przed zwróceniem. Przykłady kopiują każdą tablicę bajtów do pamięci zarządzanej przez aplikację.
- Traktuj eksport jako udany tylko wtedy, gdy operacja zapisu prezentacji zwróci się i każdy wywołanie zwrotne zakończy się pomyślnie. Nie ukrywaj błędów przechowywania ani nie rozpoczynaj niewyświetlonych zapisów w tle. Jeśli utrwalenie następuje później, zgłoś całkowity sukces dopiero po pomyślnym zakończeniu tego kroku.

[setExportHiddenSlides](https://reference.aspose.com/slides/pl/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) obowiązuje również przy niestandardowym zapisie. Ustawienie domyślne, `false`, wyklucza dokumenty XAML ukrytych slajdów. Przekazanie `true` obejmuje je oraz wszystkie zasoby niezbędne do ich eksportu. Liczba zasobów zależy od prezentacji; nie zakładaj jednego wywołania zwrotnego na slajd ani stałej kolejności wywołań.

### **Eksport do pamięci i inspekcja artefaktów**

Ten kompletny przykład wczytuje `pres.pptx`, zbiera każdy artefakt w [Map<String, byte[]>](https://docs.oracle.com/javase/8/docs/api/java/util/Map.html) i wypisuje jego nazwę, typ oraz liczbę bajtów. Zachowuje dokładnie podane nazwy. Powielone nazwy oznaczają zbiór jako nieprawidłowy zamiast cichego nadpisania artefaktu. Przykład sprawdza to przed użyciem wyników.

```java
import com.aspose.slides.*;
import java.util.LinkedHashMap;
import java.util.Map;
import java.nio.charset.StandardCharsets;
import java.util.Locale;

class MemoryXamlSaver implements IXamlOutputSaver {
    final Map<String, byte[]> artifacts = new LinkedHashMap<>();
    boolean valid = true;

    @Override
    public void save(String path, byte[] data) {
        if (artifacts.containsKey(path)) {
            valid = false;
            System.err.println("Export rejected: duplicate artifact name: " + path);
            return;
        }
        byte[] retainedData = data.clone();
        artifacts.put(path, retainedData);
    }
}

MemoryXamlSaver saver = new MemoryXamlSaver();
Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions options = new XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(true);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!saver.valid) {
    System.err.println("Export rejected: the artifact collection is invalid.");
    return;
}

boolean inspectXamlText = false;
for (Map.Entry<String, byte[]> artifact : saver.artifacts.entrySet()) {
    String name = artifact.getKey().toLowerCase(Locale.ROOT);
    boolean isXaml = name.endsWith(".xaml");
    boolean isImage = name.matches(".*\\.(png|jpg|jpeg|gif|bmp|tif|tiff|svg)$");
    String kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
    System.out.println(artifact.getKey() + ": " + artifact.getValue().length + " bytes (" + kind + ")");

    // Dekoduj wyłącznie XAML i tylko wtedy, gdy potrzebna jest inspekcja tekstowa.
    if (isXaml && inspectXamlText) {
        String markup = new String(artifact.getValue(), StandardCharsets.UTF_8);
        System.out.println(markup);
    }
}
```

Sprawdzanie rozszerzeń jest przydatne przy inspekcji; zachowaj wszystkie artefakty, w tym nieznane typy zasobów. Pozostaw bajty niezmienione przy ich przechowywaniu lub transmisji. Użyj konstruktora [String](https://docs.oracle.com/javase/8/docs/api/java/lang/String.html#String-byte:A-java.nio.charset.Charset-) z kodowaniem UTF‑8 wyłącznie dla XAML, który wymaga przetwarzania tekstowego.

### **Pakowanie zebranych artefaktów w archiwum ZIP**

Ten niezależny przykład zbiera eksport, weryfikuje jego nazwy i zapisuje oryginalne bajty do archiwum ZIP. Unikalna nazwa archiwum oddziela równoległe zadania eksportu. Pozycje ZIP używają ukośników i zachowują katalogi względne. Nieprawidłowe nazwy lub kolizje po normalizacji odrzucają cały pakiet przed jego zapisaniem.

```java
import com.aspose.slides.*;
import java.util.LinkedHashMap;
import java.util.Map;
import java.io.IOException;
import java.io.OutputStream;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.nio.file.StandardOpenOption;
import java.util.Set;
import java.util.TreeSet;
import java.util.UUID;
import java.util.zip.ZipEntry;
import java.util.zip.ZipOutputStream;

class MemoryXamlSaver implements IXamlOutputSaver {
    final Map<String, byte[]> artifacts = new LinkedHashMap<>();
    boolean valid = true;

    @Override
    public void save(String path, byte[] data) {
        if (artifacts.containsKey(path)) {
            valid = false;
            System.err.println("Export rejected: duplicate artifact name: " + path);
            return;
        }
        byte[] retainedData = data.clone();
        artifacts.put(path, retainedData);
    }
}

MemoryXamlSaver saver = new MemoryXamlSaver();
Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions options = new XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(false);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!saver.valid) {
    System.err.println("Export rejected: the artifact collection is invalid.");
    return;
}

Map<String, byte[]> entries = new LinkedHashMap<>();
Set<String> entryNames = new TreeSet<>(String.CASE_INSENSITIVE_ORDER);
for (Map.Entry<String, byte[]> artifact : saver.artifacts.entrySet()) {
    String entryName = artifact.getKey().replace('\\', '/');
    String[] segments = entryName.split("/", -1);
    boolean unsafeName = entryName.startsWith("/") || entryName.contains(":");
    for (String segment : segments) {
        unsafeName |= segment.trim().isEmpty() || segment.equals(".") || segment.equals("..");
    }

    if (unsafeName || !entryNames.add(entryName)) {
        System.err.println("Export rejected: unsafe or duplicate artifact name: " + artifact.getKey());
        return;
    }
    entries.put(entryName, artifact.getValue());
}

Path archivePath = Paths.get("xaml-" + UUID.randomUUID() + ".zip");
try {
    OutputStream output = Files.newOutputStream(archivePath, StandardOpenOption.CREATE_NEW, StandardOpenOption.WRITE);
    try (OutputStream archiveOutput = output; ZipOutputStream archive = new ZipOutputStream(archiveOutput)) {
        for (Map.Entry<String, byte[]> artifact : entries.entrySet()) {
            ZipEntry entry = new ZipEntry(artifact.getKey());
            archive.putNextEntry(entry);
            archive.write(artifact.getValue());
            archive.closeEntry();
        }
    }

    // Katalog ZIP został zakończony zamknięciem przed zgłoszeniem powodzenia.
    System.out.println("Saved " + entries.size() + " artifacts to " + archivePath);
} catch (IOException exception) {
    System.err.println("Archive persistence failed: " + exception.getMessage());
}
```

Przykład używa [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) do zapisania jednego lokalnego archiwum; sam eksporter nie zapisuje luźnych plików XAML ani obrazów. W przypadku zdalnego przechowywania zamień etap zapisu archiwum na przesyłanie zebranych tablic bajtów. Używaj identyfikatora zadania eksportu wraz z pełną względną nazwą artefaktu jako klucza blob lub przechowuj identyfikator zadania, względną nazwę i dane binarne w wierszu bazy danych. Publikuj zadanie dopiero po zakończeniu wszystkich przesyłek lub po zatwierdzeniu transakcji bazy danych. Wyczyść częściowy wynik, jeśli utrwalenie się nie powiedzie.

W przypadku dużych prezentacji niestandardowy zapis może utrwalać każdy artefakt bezpośrednio w magazynie aplikacji, aby uniknąć przechowywania dodatkowej kopii całego eksportu w pamięci aplikacji. Zachowaj każdy wywołanie zwrotne synchronicznie z perspektywy eksportera: zwracaj się dopiero po akceptacji bajtów przez docelowy magazyn i pozwól, aby błędy dotarły do wywołującego.

### **Zachowanie nazw zasobów i weryfikacja odwołań**

- Normalizuj separatery ścieżek, gdy docelowy system tego wymaga, ale zachowaj katalogi względne. Nie używaj wyłącznie [Path.getFileName](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Path.html#getFileName--) chyba że każda wygenerowana nazwa jest znana jako unikalna i odwołania do zasobów pozostają prawidłowe.
- Zastosuj walidację nazw specyficzną dla docelowego miejsca. Przy zapisie luźnych plików odrzucaj ścieżki zaczynające się od korzenia oraz segmenty traversalu, rozwiązuj docelową ścieżkę przy użyciu [Path.toAbsolutePath](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Path.html#toAbsolutePath--), i upewnij się, że pozostaje pod zamierzonym katalogiem eksportu, uwzględniając separator katalogów w sprawdzaniu zawartości. Używaj katalogu kontrolowanego przez aplikację, bez łączy symbolicznych mogących przekierować zapis.
- Używaj osobnego zapisu i przestrzeni nazw magazynowania dla każdego zadania eksportu. Wykrywaj kolizje po normalizacji separatorów i zgodnie z zasadami rozróżniania wielkości liter w docelowym systemie.
- Przed publikacją parsuj każdy dokument XAML jako XML i sprawdzaj jego odwołania do zasobów plikowych, takich jak atrybuty `Source` lub `ImageSource` obrazu. Rozwiązuj każdy względny URI względem katalogu zawierającego artefakt XAML, normalizuj otrzymaną nazwę magazynu i potwierdzaj, że odpowiadający klucz mapy, wpis ZIP lub przechowywany obiekt istnieje. Traktuj zewnętrzne URI i wyrażenia markup XAML oddzielnie od nazw plików względnych.

Na przykład, jeśli `pres/Slide_1.xaml` odwołuje się do `images/image1.png`, przechowywany zasób musi być dostępny jako `pres/images/image1.png`. Zachowanie jedynie `image1.png` spowodowałoby zerwanie tego powiązania. W magazynie obiektów zachowaj taką samą strukturę pod prefiksem zadania i udostępnij te URL‑e zasobów konsumentowi XAML. Otwórz ponownie utworzone ZIP, aby zweryfikować nazwy wpisów i bajty zasobów oraz załaduj reprezentatywne slajdy w docelowym środowisku XAML, aby potwierdzić prawidłowe rozpoznawanie obrazów.

## **FAQ**

**Jak mogę zapewnić przewidywalne czcionki, jeśli oryginalna czcionka nie jest dostępna na komputerze?**

Wywołaj [setDefaultRegularFont](https://reference.aspose.com/slides/pl/java/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) w [XamlOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/xamloptions/) — jest ona używana jako czcionka awaryjna podczas eksportu, gdy oryginał jest nieobecny. Nie gwarantuje to, że wygenerowany XAML odwołuje się do czcionki awaryjnej lub że czcionka będzie dostępna na docelowej maszynie. Upewnij się, że czcionki odwoływane przez XAML są dostępne w środowisku, w którym jest wyświetlany.

**Czy wyeksportowany XAML jest przeznaczony wyłącznie dla WPF, czy może być używany w innych stosach XAML?**

Aspose.Slides eksportuje XAML WPF poprzez swoje publiczne API. Zgodność z innymi stosami XAML, takimi jak UWP i Xamarin.Forms, nie jest gwarantowana. Przetestuj wygenerowany znacznik w docelowym środowisku.

**Czy ukryte slajdy są obsługiwane i jak mogę zapobiec ich domyślnemu eksportowi?**

Domyślnie ukryte slajdy nie są uwzględniane. Możesz kontrolować to zachowanie za pomocą [setExportHiddenSlides](https://reference.aspose.com/slides/pl/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) w [XamlOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/xamloptions/) — pozostaw je wyłączone, jeśli nie potrzebujesz ich eksportować.