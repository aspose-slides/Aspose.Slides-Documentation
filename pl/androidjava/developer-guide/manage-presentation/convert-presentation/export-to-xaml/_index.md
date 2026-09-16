---
title: Eksportowanie prezentacji do XAML na Androidzie
linktitle: Prezentacja do XAML
type: docs
weight: 30
url: /pl/androidjava/export-to-xaml/
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
- Android
- Java
- Aspose.Slides
description: "Konwertuj slajdy PowerPoint i OpenDocument do XAML w języku Java przy użyciu Aspose.Slides dla Androida — szybkie, rozwiązanie bez Office, które zachowuje układ."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak eksportować prezentacje PowerPoint do XAML przy użyciu Aspose.Slides dla Androida w Javie. Zawiera krótkie wprowadzenie do XAML, pokazuje, jak zapisać prezentację do XAML z ustawieniami domyślnymi oraz demonstruje, jak dostosować eksport przy użyciu [XamlOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/xamloptions/), w tym eksport ukrytych slajdów. Artykuł odpowiada również na kilka typowych pytań dotyczących czcionek zapasowych, kompatybilności stosu XAML oraz zachowania eksportu ukrytych slajdów.

## **O XAML**

XAML to język znaczników oparty na XML, używany do opisywania interfejsów użytkownika w frameworkach takich jak WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) i Xamarin.Forms.

Można pracować z plikami XAML w projektancie wizualnym lub pisać i edytować znacznik bezpośrednio.

## **Eksportowanie prezentacji do XAML z opcjami domyślnymi**

Poniższy przykład w Javie pokazuje, jak wyeksportować prezentację do XAML z ustawieniami domyślnymi:

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

Domyślnie wyeksportowane slajdy są zapisywane w podfolderze `pres` bieżącego katalogu roboczego procesu. Folder jest tworzony automatycznie, a wszystkie wymagane obrazy są tam również zapisywane.

Nazwa folderu wyjściowego jest pobierana z nazwy pliku źródłowego bez jego rozszerzenia. Dla `pres.pptx` pliki wyjściowe mają nazwy `pres/Slide_1.xaml`, `pres/Slide_2.xaml` i tak dalej. Nawet jeśli przekażesz ścieżkę bezwzględną do prezentacji wejściowej, folder wyjściowy jest tworzony względem bieżącego katalogu roboczego, a nie obok pliku wejściowego.

W Androidzie użyj pliku wejściowego dostępnego dla aplikacji. Bieżący katalog roboczy może nie być zapisywalny; użyj własnego zapisywacza wyjścia, aby zachować eksport w pamięci lub zapisać go w pamięci aplikacji, jak pokazano poniżej. Wygenerowany XAML WPF jest przeznaczony dla kompatybilnego odbiorcy i nie jest zasobem układu Androida.

## **Eksportowanie prezentacji do XAML z opcjami niestandardowymi**

Użyj interfejsu [IXamlOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ixamloptions/), aby kontrolować sposób, w jaki Aspose.Slides eksportuje prezentację do XAML.

Aby zapisać wynik w niestandardowej lokalizacji, zaimplementuj [IXamlOutputSaver](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ixamloutputsaver/) i przekaż instancję własnej implementacji do metody [setOutputSaver](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) z klasy [XamlOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/xamloptions/).

Aby uwzględnić ukryte slajdy w wyjściu XAML, wywołaj [setExportHiddenSlides](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) z wartością `true`, jak pokazano w poniższym przykładzie w Javie:

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

Eksport XAML może wygenerować dokument XAML dla każdego wyeksportowanego slajdu oraz osobne obrazy i zasoby pomocnicze. Przypisz własny [IXamlOutputSaver](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ixamloutputsaver/) do [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-), aby otrzymywać te artefakty zamiast używać domyślnego zapisywacza systemu plików. Rozpocznij eksport przy użyciu przeciążenia [Presentation.save](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) specyficznego dla XAML, które przyjmuje opcje XAML.

### **Zrozumienie cyklu życia wywołań zwrotnych**

Eksporter wywołuje [IXamlOutputSaver.save](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) osobno dla każdego wygenerowanego artefaktu:

- `path` identyfikuje artefakt i może zawierać katalogi względne. Zachowaj tę informację, ponieważ XAML może odwoływać się do zasobów przy użyciu ścieżek względnych.
- `data` zawiera bajty artefaktu. Obrazy i inne zasoby binarne nie powinny być dekodowane jako tekst.
- Zapisywacz jest odpowiedzialny za zachowanie lub utrwalenie danych przed zwróceniem. Przykłady kopiują każdą tablicę bajtów do pamięci należącej do aplikacji.
- Traktuj eksport jako udany tylko wtedy, gdy operacja zapisu prezentacji zwróci wynik i wszystkie wywołania zwrotne zakończą się pomyślnie. Nie pomijaj błędów zapisu ani nie uruchamiaj nieobserwowanych zapisów w tle. Jeśli trwałość nastąpi później, zgłoś ogólny sukces dopiero po pomyślnym zakończeniu tego kroku.

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) ma również zastosowanie do własnego zapisywacza. Ustawienie domyślne, `false`, wyklucza dokumenty XAML ukrytych slajdów. Przekazanie `true` obejmuje je oraz wszystkie zasoby wymagane do ich eksportu. Liczba zasobów zależy od prezentacji; nie zakładaj jednego wywołania zwrotnego na slajd ani stałej kolejności wywołań.

### **Eksport do pamięci i inspekcja artefaktów**

Ten kompletny przykład ładuje `pres.pptx`, zbiera każdy artefakt w [Map<String, byte[]>](https://docs.oracle.com/javase/8/docs/api/java/util/Map.html) i wypisuje jego nazwę, typ oraz liczbę bajtów. Zachowuje podane nazwy dokładnie. Powtarzające się nazwy oznaczają, że kolekcja jest nieprawidłowa, zamiast cicho nadpisywać artefakt. Przykład sprawdza to przed użyciem wyników.

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

    // Dekoduj tylko XAML i tylko wtedy, gdy potrzebna jest inspekcja tekstowa.
    if (isXaml && inspectXamlText) {
        String markup = new String(artifact.getValue(), StandardCharsets.UTF_8);
        System.out.println(markup);
    }
}
```

Sprawdzenia rozszerzeń są przydatne przy inspekcji; zachowaj wszystkie artefakty, w tym nieznane typy zasobów. Pozostaw bajty niezmienione przy ich przechowywaniu lub transmisji. Używaj konstruktora [String](https://docs.oracle.com/javase/8/docs/api/java/lang/String.html#String-byte:A-java.nio.charset.Charset-) z kodowaniem UTF-8 wyłącznie dla XAML, który wymaga przetwarzania tekstowego.

### **Pakowanie zebranych artefaktów w archiwum ZIP**

Ten odrębny przykład zbiera eksport, weryfikuje nazwy i zapisuje oryginalne bajty do archiwum ZIP. Zamień `/path/to/app/files` na ścieżkę zwróconą przez metodę [getFilesDir](https://developer.android.com/reference/android/content/Context#getFilesDir()) twojego kontekstu Androida. Unikalna nazwa archiwum rozdziela jednoczesne zadania eksportu. Wpisy ZIP używają ukośników i zachowują katalogi względne. Niebezpieczne nazwy lub nazwy, które kolidują po normalizacji, odrzucają cały pakiet przed jego zapisaniem.

```java
import com.aspose.slides.*;
import java.util.LinkedHashMap;
import java.util.Map;
import java.io.IOException;
import java.io.File;
import java.io.FileOutputStream;
import java.util.Set;
import java.util.TreeSet;
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

File exportDirectory = new File("/path/to/app/files");
try {
    File archiveFile = File.createTempFile("xaml-", ".zip", exportDirectory);
    try (FileOutputStream archiveOutput = new FileOutputStream(archiveFile); ZipOutputStream archive = new ZipOutputStream(archiveOutput)) {
        for (Map.Entry<String, byte[]> artifact : entries.entrySet()) {
            ZipEntry entry = new ZipEntry(artifact.getKey());
            archive.putNextEntry(entry);
            archive.write(artifact.getValue());
            archive.closeEntry();
        }
    }

    // Katalog ZIP został sfinalizowany zamknięciem przed zgłoszeniem sukcesu.
    System.out.println("Saved " + entries.size() + " artifacts to " + archiveFile);
} catch (IOException exception) {
    System.err.println("Archive persistence failed: " + exception.getMessage());
}
```

Przykład używa [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) do zapisu jednego lokalnego archiwum; sam eksporter nie zapisuje luźnych plików XAML ani obrazów. W przypadku przechowywania zdalnego, zamień etap zapisu archiwum na przesyłanie zebranych tablic bajtów. Użyj identyfikatora zadania eksportu plus pełnej względnej nazwy artefaktu jako klucza blob, lub przechowuj identyfikator zadania, względną nazwę i dane binarne w wierszu bazy danych. Publikuj zadanie dopiero po zakończeniu wszystkich przesyłek lub zatwierdzeniu transakcji bazy danych. Usuń częściowy wynik, jeśli trwałość się nie powiedzie.

W przypadku dużych prezentacji własny zapisywacz może utrwalać każdy artefakt bezpośrednio w pamięci aplikacji, aby uniknąć przechowywania dodatkowej kopii całego eksportu w pamięci. Utrzymuj każde wywołanie zwrotne synchroniczne z perspektywy eksportera: zwracaj się dopiero po przyjęciu bajtów przez docelowy magazyn i pozwól na propagowanie błędów do wywołującego.

### **Zachowanie nazw zasobów i weryfikacja odwołań**

- Normalizuj separatery ścieżek, gdy tego wymaga miejsce docelowe, ale zachowaj katalogi względne. Nie używaj wyłącznie [File.getName](https://developer.android.com/reference/java/io/File#getName()) chyba że każda wygenerowana nazwa jest znana jako unikalna i odwołania do zasobów pozostają ważne.
- Stosuj walidację nazw specyficzną dla docelowego miejsca. Przy zapisie luźnych plików odrzucaj ścieżki rozpoczynające się od korzenia oraz segmenty traversalu, rozwiąż docelowy katalog przy użyciu [File.getCanonicalPath](https://developer.android.com/reference/java/io/File#getCanonicalPath()) i sprawdź, czy pozostaje pod zamierzonym katalogiem eksportu, uwzględniając separator katalogu w kontroli przynależności. Używaj katalogu kontrolowanego przez aplikację, bez dowiązań symbolicznych, które mogłyby przekierować zapisy.
- Używaj osobnego zapisywacza i przestrzeni nazw przechowywania dla każdego zadania eksportu. Wykrywaj kolizje po normalizacji separatorów i zgodnie z regułami czułości na wielkość liter miejsca docelowego.
- Przed publikacją przeanalizuj każdy dokument XAML jako XML i sprawdź jego odwołania do zasobów opartych na plikach, takich jak atrybuty `Source` lub `ImageSource`. Rozwiąż każdy względny URI względem katalogu zawierającego artefakt XAML, znormalizuj powstałą nazwę przechowywania i potwierdź, że odpowiedni klucz mapy, wpis ZIP lub zapisany obiekt istnieje. Traktuj zewnętrzne URI i wyrażenia markup XAML oddzielnie od względnych nazw plików.

Na przykład, jeśli `pres/Slide_1.xaml` odwołuje się do `images/image1.png`, przechowywany zasób musi być dostępny jako `pres/images/image1.png`. Zachowanie jedynie `image1.png` przerwałoby to powiązanie. W przechowywaniu obiektowym zachowaj tę samą strukturę pod prefiksem zadania i udostępnij te URL‑e zasobów odbiorcy XAML. Otwórz ponownie gotowy ZIP, aby zweryfikować nazwy wpisów i bajty zasobów, oraz załaduj przykładowe slajdy w docelowym środowisku XAML, aby potwierdzić prawidłowe rozwiązywanie obrazów.

## **FAQ**

**Jak mogę zapewnić przewidywalne czcionki, gdy oryginalna czcionka nie jest dostępna na maszynie?**

Wywołaj [setDefaultRegularFont](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) w [XamlOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/xamloptions/) — jest ona używana jako czcionka zapasowa podczas eksportu, gdy oryginał jest brakujący. Nie gwarantuje to, że wygenerowany XAML odwołuje się do czcionki zapasowej lub że czcionka będzie dostępna na docelowej maszynie. Upewnij się, że czcionki odwoływane w XAML są dostępne w środowisku, w którym jest wyświetlany.

**Czy wyeksportowany XAML jest przeznaczony wyłącznie dla WPF, czy może być używany w innych stosach XAML?**

Aspose.Slides eksportuje XAML WPF za pośrednictwem swojego publicznego API. Kompatybilność z innymi stosami XAML, takimi jak UWP i Xamarin.Forms, nie jest gwarantowana. Przetestuj wygenerowany znacznik w docelowym środowisku.

**Czy ukryte slajdy są obsługiwane i jak mogę zapobiec ich domyślnemu eksportowi?**

Domyślnie ukryte slajdy nie są uwzględniane. Możesz kontrolować to zachowanie za pomocą [setExportHiddenSlides](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) w [XamlOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/xamloptions/) — pozostaw je wyłączone, jeśli nie potrzebujesz ich eksportować.