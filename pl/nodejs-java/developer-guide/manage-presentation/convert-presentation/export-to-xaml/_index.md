---
title: Eksportowanie prezentacji do XAML w JavaScript
linktitle: Prezentacja do XAML
type: docs
weight: 30
url: /pl/nodejs-java/export-to-xaml/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Konwertuj slajdy PowerPoint i OpenDocument do XAML w JavaScript przy użyciu Aspose.Slides — szybkie rozwiązanie bez Office, które zachowuje układ."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak eksportować prezentacje PowerPoint do XAML przy użyciu Aspose.Slides. Zawiera krótki wstęp do XAML, pokazuje, jak zapisać prezentację do XAML z ustawieniami domyślnymi, oraz demonstruje, jak dostosować eksport przy użyciu [XamlOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/xamloptions/), w tym eksportowanie ukrytych slajdów. Artykuł także odpowiada na kilka często zadawanych pytań dotyczących czcionek zapasowych, kompatybilności stosu XAML oraz zachowania eksportu ukrytych slajdów.

## **O XAML**

XAML jest językiem znaczników opartym na XML, używanym do opisywania interfejsów użytkownika w ramach takich jak WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) oraz Xamarin.Forms.

Możesz pracować z plikami XAML w projektancie wizualnym lub pisać i edytować znacznik bezpośrednio.

## **Eksportowanie prezentacji do XAML z ustawieniami domyślnymi**

Poniższy przykład JavaScript pokazuje, jak eksportować prezentację do XAML z ustawieniami domyślnymi:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xamlOptions = new aspose.slides.XamlOptions();
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

Domyślnie wyeksportowane slajdy są zapisywane w podfolderze `input` bieżącego katalogu roboczego procesu. Folder jest tworzony automatycznie, a wszystkie wymagane obrazy są tam również zapisywane.

Nazwa folderu wyjściowego jest pobierana z nazwy pliku źródłowego bez jego rozszerzenia. W Aspose.Slides dla Node.js via Java 26.8 eksportowanie `input.pptx` tworzy zagnieżdżoną ścieżkę taką jak `input/input/Slide_1.xaml`. Zachowaj pełne wygenerowane ścieżki podczas obsługi wyjścia. Domyślne wyjście jest względne względem bieżącego katalogu roboczego, a niekoniecznie obok pliku wejściowego.

## **Eksportowanie prezentacji do XAML z opcjami niestandardowymi**

Użyj interfejsu [IXamlOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ixamloptions/) do kontrolowania, jak Aspose.Slides eksportuje prezentację do XAML.

Aby zapisać wyjście w niestandardowej lokalizacji, zaimplementuj [IXamlOutputSaver](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ixamloutputsaver/) i przekaż instancję własnej implementacji do metody [setOutputSaver](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) klasy [XamlOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/xamloptions/).

Aby uwzględnić ukryte slajdy w wyjściu XAML, wywołaj [setExportHiddenSlides](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) z wartością `true`, jak pokazano w poniższym przykładzie JavaScript:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xamlOptions = new aspose.slides.XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

## **Przechwytywanie wszystkich wygenerowanych artefaktów XAML**

Eksport XAML może wygenerować dokument XAML dla każdego wyeksportowanego slajdu oraz osobne obrazy i zasoby pomocnicze. Przypisz własny [IXamlOutputSaver](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ixamloutputsaver/) do [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/xamloptions/#setOutputSaver), aby otrzymywać te artefakty zamiast używać domyślnego zapisu w systemie plików. Rozpocznij eksport przy użyciu przeciążonej metody [Presentation.save](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#save) akceptującej opcje XAML.

W Node.js zaimplementuj interfejs Java przy użyciu `java.newProxy` z pakietu `java` używanego przez Aspose.Slides. Utrzymuj proxy dostępny, dopóki eksport się nie zakończy.

### **Zrozumienie cyklu życia wywołań zwrotnych**

Eksporter wywołuje metodę [IXamlOutputSaver.save](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) osobno dla każdego wygenerowanego artefaktu:

- `path` identyfikuje artefakt i może zawierać katalogi względne. Zachowaj tę informację, ponieważ XAML może odwoływać się do zasobów przy użyciu ścieżek względnych.
- `data` zawiera bajty artefaktu. Obrazy i inne zasoby binarne nie powinny być dekodowane jako tekst.
- Zapisujący jest odpowiedzialny za zachowanie lub trwałe przechowanie danych przed zwróceniem. Przykłady kopiują każdą tablicę bajtów Java do bufora Node.js własnościowego aplikacji.
- Traktuj eksport jako pomyślny tylko wtedy, gdy operacja zapisu prezentacji zwróci, a każdy wywołanie zwrotne zakończy się pomyślnie. Nie pomijaj błędów przechowywania ani nie uruchamiaj niezauważonych zapisów w tle. Jeśli utrwalenie nastąpi później, zgłoś ogólny sukces dopiero po pomyślnym zakończeniu tego kroku.

[setExportHiddenSlides](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) dotyczy również niestandardowego zapisu. Domyślne ustawienie, `false`, wyklucza dokumenty XAML ukrytych slajdów. Przekazanie `true` uwzględnia je oraz wszelkie zasoby wymagane do ich eksportu. Liczba zasobów zależy od prezentacji; nie zakładaj jednego wywołania zwrotnego na slajd ani stałej kolejności wywołań.

### **Eksport do pamięci i inspekcja artefaktów**

Ten kompletny przykład ładuje `input.pptx`, zbiera każdy artefakt w mapie JavaScript nazw → buforów i wypisuje jego nazwę, typ oraz liczbę bajtów. Zachowuje dokładnie podane nazwy. Zduplikowane nazwy oznaczają nieprawidłową kolekcję zamiast cichego nadpisania artefaktu. Przykład sprawdza to przed użyciem wyników.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const artifacts = new Map();
let valid = true;
const saver = java.newProxy("com.aspose.slides.IXamlOutputSaver", {
    save: function(path, data) {
        const name = String(path);
        if (artifacts.has(name)) {
            valid = false;
            console.error("Export rejected: duplicate artifact name: " + name);
            return;
        }
        const retainedData = Buffer.from(data);
        artifacts.set(name, retainedData);
    }
});

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(true);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!valid) {
    console.error("Export rejected: the artifact collection is invalid.");
} else {
    const inspectXamlText = false;
    for (const [name, data] of artifacts) {
        const isXaml = /\.xaml$/i.test(name);
        const isImage = /\.(png|jpg|jpeg|gif|bmp|tif|tiff|svg)$/i.test(name);
        const kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
        console.log(name + ": " + data.length + " bytes (" + kind + ")");

        // Dekoduj tylko XAML i tylko wtedy, gdy potrzebna jest tekstowa inspekcja.
        if (isXaml && inspectXamlText) {
            console.log(data.toString("utf8"));
        }
    }
}
```

Sprawdzanie rozszerzeń jest przydatne przy inspekcji; zachowaj wszystkie artefakty, w tym nieznane typy zasobów. Przechowuj bajty niezmienione podczas zapisu lub transmisji. Używaj dekodowania UTF‑8 wyłącznie dla XAML, który wymaga przetwarzania tekstowego.

### **Pakowanie zebranych artefaktów w archiwum ZIP**

Ten niezależny przykład zbiera eksport, weryfikuje jego nazwy i zapisuje oryginalne bajty do archiwum ZIP przy użyciu mostu Java. ZIP jest tworzony w pamięci przed zapisaniem na dysk. Unikalna nazwa archiwum rozdziela jednoczesne zadania eksportu. Wpisy ZIP używają ukośników i zachowują katalogi względne. Niebezpieczne nazwy lub nazwy kolidujące po normalizacji odrzucają cały pakiet przed zapisem.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const artifacts = new Map();
let valid = true;
const saver = java.newProxy("com.aspose.slides.IXamlOutputSaver", {
    save: function(path, data) {
        const name = String(path);
        if (artifacts.has(name)) {
            valid = false;
            console.error("Export rejected: duplicate artifact name: " + name);
            return;
        }
        const retainedData = Buffer.from(data);
        artifacts.set(name, retainedData);
    }
});

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(false);
    presentation.save(options);
} finally {
    presentation.dispose();
}

const entries = new Map();
const entryNames = new Set();
for (const [name, data] of artifacts) {
    const entryName = name.replace(/\\/g, "/");
    const segments = entryName.split("/");
    const unsafeName = entryName.startsWith("/") || entryName.includes(":") || segments.some(segment => segment.trim() === "" || segment === "." || segment === "..");
    const comparisonName = entryName.toLowerCase();
    if (unsafeName || entryNames.has(comparisonName)) {
        valid = false;
        console.error("Export rejected: unsafe or duplicate artifact name: " + name);
        break;
    }
    entryNames.add(comparisonName);
    entries.set(entryName, data);
}

if (!valid) {
    console.error("Export rejected: the artifact collection is invalid.");
} else {
    const fs = require("node:fs");
    const crypto = require("node:crypto");
    const archivePath = "xaml-" + crypto.randomUUID() + ".zip";
    const output = java.newInstanceSync("java.io.ByteArrayOutputStream");
    const archive = java.newInstanceSync("java.util.zip.ZipOutputStream", output);
    try {
        for (const [name, data] of entries) {
            const entry = java.newInstanceSync("java.util.zip.ZipEntry", name);
            archive.putNextEntry(entry);
            const signedBytes = Array.from(data, value => value > 127 ? value - 256 : value);
            const bytes = java.newArray("byte", signedBytes);
            archive.write(bytes);
            archive.closeEntry();
        }
    } finally {
        archive.close();
    }

    // Zamknięcie finalizuje katalog ZIP przed zapisaniem archiwum.
    const archiveData = Buffer.from(output.toByteArray());
    try {
        fs.writeFileSync(archivePath, archiveData, { flag: "wx" });
        console.log("Saved " + entries.size + " artifacts to " + archivePath);
    } catch (error) {
        console.error("Archive persistence failed: " + error.message);
    }
}
```

Przykład używa [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) do zapisania jednego lokalnego archiwum; sam eksporter nie zapisuje luźnych plików XAML ani obrazów. W przypadku przechowywania zdalnego zamień etap zapisu archiwum na przesyłanie zebranych tablic bajtów. Użyj identyfikatora zadania eksportu plus pełnej względnej nazwy artefaktu jako klucza blob lub przechowuj identyfikator zadania, względną nazwę i dane binarne w wierszu bazy danych. Publikuj zadanie dopiero po zakończeniu wszystkich przesłań lub zatwierdzeniu transakcji bazy danych. Usuń częściowy wynik, jeśli utrwalenie się nie powiedzie.

W przypadku dużych prezentacji niestandardowy zapis może utrwalać każdy artefakt bezpośrednio w magazynie aplikacji, aby uniknąć dodatkowego kopiowania całego eksportu w pamięci aplikacji. Zachowaj każde wywołanie zwrotne synchronicznie z perspektywy eksportera: zwróć się dopiero po zaakceptowaniu bajtów przez docelowy odbiorca i pozwól, aby błędy dotarły do wywołującego.

### **Zachowanie nazw zasobów i weryfikacja odwołań**

- Normalizuj separatorem ścieżek, gdy wymaga tego miejsce docelowe, ale zachowaj katalogi względne. Nie używaj tylko nazwy bazowej, chyba że każda wygenerowana nazwa jest znana jako unikalna i odwołania zasobów pozostają prawidłowe.
- Zastosuj walidację nazw specyficzną dla miejsca docelowego. Przy zapisie luźnych plików odrzuć ścieżki bezwzględne i segmenty traversalu, rozwiąż miejsce docelowe do ścieżki bezwzględnej i zweryfikuj, że pozostaje pod zamierzonym katalogiem eksportu, włączając separator katalogu w kontroli zawartości. Używaj katalogu kontrolowanego przez aplikację bez linków symbolicznych, które mogłyby przekierować zapisy.
- Używaj oddzielnego zapisu i przestrzeni nazw magazynu dla każdego zadania eksportu. Wykrywaj kolizje po normalizacji separatora i zgodnie z regułami czułości na wielkość liter miejsca docelowego.
- Przed publikacją analizuj każdy dokument XAML jako XML i sprawdzaj jego oparte na plikach odwołania do zasobów, takie jak atrybuty `Source` obrazu lub `ImageSource`. Rozwiąż każdy względny URI względem katalogu zawierającego artefakt XAML, znormalizuj uzyskaną nazwę przechowywania i potwierdź, że istnieje odpowiadający klucz mapy, wpis ZIP lub przechowywany obiekt. Traktuj zewnętrzne URI i wyrażenia markup XAML oddzielnie od względnych nazw plików.

Na przykład, jeśli `input/Slide_1.xaml` odwołuje się do `images/image1.png`, przechowywany zasób musi być dostępny jako `input/images/image1.png`. Zachowanie jedynie `image1.png` przerwałoby tę relację. W przechowywaniu obiektowym zachowaj tę samą strukturę pod prefiksem zadania i udostępnij te URL‑e zasobów konsumentowi XAML. Otwórz ponownie ukończony ZIP, aby zweryfikować nazwy wpisów i bajty zasobów oraz załaduj reprezentatywne slajdy w docelowym środowisku XAML, aby potwierdzić prawidłowe rozwiązywanie obrazów.

## **FAQ**

**Jak zapewnić przewidywalne czcionki, jeśli oryginalna czcionka nie jest dostępna na komputerze?**

Wywołaj [setDefaultRegularFont](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) w [XamlOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/xamloptions/) — jest on używany jako czcionka zapasowa podczas eksportu, gdy oryginał jest nieobecny. Nie gwarantuje to, że wygenerowany XAML odwołuje się do czcionki zapasowej lub że czcionka będzie dostępna na docelowej maszynie. Upewnij się, że czcionki odwoływane przez XAML są dostępne w środowisku, w którym jest wyświetlany.

**Czy wyeksportowany XAML jest przeznaczony wyłącznie dla WPF, czy może być używany w innych stosach XAML?**

Aspose.Slides eksportuje XAML WPF za pośrednictwem swojego publicznego API. Kompatybilność z innymi stosami XAML, takimi jak UWP i Xamarin.Forms, nie jest gwarantowana. Przetestuj wygenerowany znacznik w docelowym środowisku.

**Czy ukryte slajdy są obsługiwane i jak zapobiec ich domyślnemu eksportowi?**

Domyślnie ukryte slajdy nie są uwzględniane. Możesz kontrolować to zachowanie za pomocą [setExportHiddenSlides](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) w [XamlOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/xamloptions/) — pozostaw je wyłączone, jeśli nie potrzebujesz ich eksportować.