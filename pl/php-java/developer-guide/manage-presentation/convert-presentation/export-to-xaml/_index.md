---
title: Eksportowanie prezentacji do XAML w PHP
linktitle: Prezentacja do XAML
type: docs
weight: 30
url: /pl/php-java/export-to-xaml/
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
- eksportuj PPT do XAML
- eksportuj PPTX do XAML
- eksportuj ODP do XAML
- PHP
- Aspose.Slides
description: "Konwertuj slajdy PowerPoint i OpenDocument do XAML przy użyciu Aspose.Slides dla PHP przez Java — szybkie, wolne od Office rozwiązanie zachowujące układ."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak wyeksportować prezentacje PowerPoint do XAML przy użyciu Aspose.Slides. Zawiera krótkie wprowadzenie do XAML, pokazuje, jak zapisać prezentację do XAML z ustawieniami domyślnymi oraz demonstruje, jak dostosować eksport przy użyciu [XamlOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/xamloptions/), w tym eksportowanie ukrytych slajdów. Artykuł odpowiada również na kilka często zadawanych pytań dotyczących czcionek awaryjnych, zgodności stosu XAML oraz zachowania eksportu ukrytych slajdów.

## **O XAML**

XAML jest językiem znaczników opartym na XML, używanym do opisywania interfejsów użytkownika w frameworkach takich jak WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) i Xamarin.Forms.

Możesz pracować z plikami XAML w projektancie wizualnym albo pisać i edytować znacznik bezpośrednio.

## **Eksportowanie prezentacji do XAML z opcjami domyślnymi**

Poniższy przykład PHP pokazuje, jak wyeksportować prezentację do XAML z ustawieniami domyślnymi. Zainicjuj PHP Java Bridge i załaduj `aspose.slides.php` przed uruchomieniem przykładów w tym artykule. Umieść `pres.pptx` w katalogu roboczym serwera Java Bridge lub podaj absolutną ścieżkę dostępną dla tego serwera.

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $presentation->save($options);
} finally {
    $presentation->dispose();
}
```

Domyślnie wyeksportowane slajdy są zapisywane w podfolderze `pres` bieżącego katalogu roboczego serwera Java Bridge. Folder jest tworzony automatycznie, a wymagane obrazy są tam również zapisywane.

Nazwa folderu wyjściowego jest pobierana z nazwy pliku źródłowego bez rozszerzenia. Dla `pres.pptx` pliki wyjściowe noszą nazwy `pres/Slide_1.xaml`, `pres/Slide_2.xaml` i tak dalej. Nawet jeśli podasz absolutną ścieżkę do prezentacji wejściowej, folder wyjściowy jest tworzony względem bieżącego katalogu roboczego serwera Java Bridge, a nie obok pliku wejściowego.

## **Eksportowanie prezentacji do XAML z opcjami niestandardowymi**

Użyj interfejsu [IXamlOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ixamloptions/), aby kontrolować, jak Aspose.Slides eksportuje prezentację do XAML.

Aby zapisać wynik w niestandardowej lokalizacji, dostarcz proxy Java implementujące [IXamlOutputSaver](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ixamloutputsaver/) i przekaż instancję swojej implementacji do metody [setOutputSaver](https://reference.aspose.com/slides/pl/php-java/aspose.slides/xamloptions/#setOutputSaver) interfejsu [XamlOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/xamloptions/).

Aby uwzględnić ukryte slajdy w wyjściu XAML, wywołaj [setExportHiddenSlides](https://reference.aspose.com/slides/pl/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) z wartością `true`, jak pokazano w poniższym przykładzie PHP:

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setExportHiddenSlides(true);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}
```

## **Uchwycenie wszystkich wygenerowanych artefaktów XAML**

Eksport XAML może generować dokument XAML dla każdego wyeksportowanego slajdu oraz osobne obrazy i zasoby pomocnicze. Przypisz niestandardowy [IXamlOutputSaver](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ixamloutputsaver/) do [XamlOptions::setOutputSaver](https://reference.aspose.com/slides/pl/php-java/aspose.slides/xamloptions/#setOutputSaver), aby otrzymywać te artefakty zamiast używać domyślnego zapisu na systemie plików. Rozpocznij eksport przy użyciu specyficznej dla XAML przeciążonej metody [Presentation::save](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#save), która akceptuje opcje XAML.

Funkcja `java_closure` w PHP Java Bridge udostępnia obiekt PHP jako interfejs Java. Utrzymuj zarówno saver PHP, jak i jego proxy, w życiu aż do zakończenia eksportu. Łącza interfejsu wskazują na API Java zaimplementowane przez proxy.

### **Zrozumienie cyklu życia wywołań zwrotnych**

Eksporter wywołuje [IXamlOutputSaver::save](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) osobno dla każdego wygenerowanego artefaktu:

- `path` identyfikuje artefakt i może zawierać katalogi względne. Zachowaj tę informację, ponieważ XAML może odwoływać się do zasobów przy użyciu ścieżek względnych.
- `data` zawiera bajty artefaktu. Obrazy i inne zasoby binarne nie powinny być dekodowane jako tekst.
- Saver jest odpowiedzialny za zachowanie lub zapisanie danych przed zwróceniem. Przykłady konwertują każdą tablicę bajtów Java na binarny ciąg PHP zarządzany przez aplikację.
- Traktuj eksport jako udany tylko wtedy, gdy operacja zapisu prezentacji zwróci wynik i każdy wywołanie zwrotne zakończy się pomyślnie. Nie ukrywaj błędów przechowywania ani nie rozpoczynaj nieobserwowanych zapisów w tle. Jeśli trwałość odbywa się później, zgłaszaj ogólny sukces dopiero po pomyślnym zakończeniu tego kroku.

[XamlOptions::setExportHiddenSlides](https://reference.aspose.com/slides/pl/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) ma również zastosowanie do niestandardowego saver'a. Domyślne ustawienie, `false`, wyklucza dokumenty XAML ukrytych slajdów. Przekazanie `true` uwzględnia je oraz wszystkie zasoby wymagane do ich eksportu. Liczba zasobów zależy od prezentacji; nie zakładaj jednego wywołania zwrotnego na slajd ani stałej kolejności wywołań.

### **Eksport do pamięci i inspekcja artefaktów**

Ten kompletny przykład ładuje `pres.pptx`, zbiera każdy artefakt w asocjacyjną tablicę PHP zawierającą ciągi binarne i wypisuje jego nazwę, typ oraz liczbę bajtów. Zachowuje dokładnie podane nazwy. Duplikujące się nazwy oznaczają kolekcję jako nieprawidłową zamiast cichego nadpisywania artefaktu. Przykład sprawdza to przed użyciem wyników.

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

class MemoryXamlSaver {
    public $artifacts = [];
    public $valid = true;

    public function save($path, $data) {
        $name = (string) java_values($path);
        if (array_key_exists($name, $this->artifacts)) {
            $this->valid = false;
            echo "Export rejected: duplicate artifact name: " . $name . PHP_EOL;
            return;
        }
        $bytes = java_values($data);
        if (is_string($bytes)) {
            $binary = $bytes;
        } else {
            $binary = "";
            foreach ($bytes as $byte) {
                $binary .= chr($byte & 0xff);
            }
        }
        $this->artifacts[$name] = $binary;
    }
}

$saver = new MemoryXamlSaver();
$proxy = java_closure($saver, null, java("com.aspose.slides.IXamlOutputSaver"));
$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setOutputSaver($proxy);
    $options->setExportHiddenSlides(true);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}

if (!$saver->valid) {
    echo "Export rejected: the artifact collection is invalid." . PHP_EOL;
    return;
}

$inspectXamlText = false;
foreach ($saver->artifacts as $name => $bytes) {
    $extension = strtolower(pathinfo($name, PATHINFO_EXTENSION));
    $isXaml = $extension === "xaml";
    $isImage = in_array($extension, ["png", "jpg", "jpeg", "gif", "bmp", "tif", "tiff", "svg"], true);
    $kind = $isXaml ? "slide XAML" : ($isImage ? "image" : "supporting resource");
    echo $name . ": " . strlen($bytes) . " bytes (" . $kind . ")" . PHP_EOL;

    // Tylko XAML jest traktowany jako tekst UTF-8 do opcjonalnej inspekcji.
    if ($isXaml && $inspectXamlText) {
        echo $bytes . PHP_EOL;
    }
}
```

Sprawdzanie rozszerzeń jest przydatne podczas inspekcji; zachowaj wszystkie artefakty, w tym nieznane typy zasobów. Pozostaw bajty niezmienione przy przechowywaniu lub transmisji. Ciągi PHP mogą przechowywać dane binarne, w tym bajty zerowe. Traktuj ciąg jako tekst UTF‑8 tylko podczas inspekcji XAML; nie transkoduj bajtów obrazu ani zasobów.

### **Spakowanie zebranych artefaktów w archiwum ZIP**

Ten odrębny przykład zbiera eksport, weryfikuje jego nazwy i zapisuje oryginalne bajty w archiwum ZIP. Specjalnie utworzony katalog zadania oddziela równoczesne zadania eksportu. Przykład wymaga rozszerzenia PHP Phar z obsługą ZIP. Wpisy ZIP używają ukośników forward slash i zachowują katalogi względne. Niebezpieczne nazwy lub nazwy kolidujące po normalizacji odrzucają cały pakiet przed zapisem.

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

class MemoryXamlSaver {
    public $artifacts = [];
    public $valid = true;

    public function save($path, $data) {
        $name = (string) java_values($path);
        if (array_key_exists($name, $this->artifacts)) {
            $this->valid = false;
            echo "Export rejected: duplicate artifact name: " . $name . PHP_EOL;
            return;
        }
        $bytes = java_values($data);
        if (is_string($bytes)) {
            $binary = $bytes;
        } else {
            $binary = "";
            foreach ($bytes as $byte) {
                $binary .= chr($byte & 0xff);
            }
        }
        $this->artifacts[$name] = $binary;
    }
}

$saver = new MemoryXamlSaver();
$proxy = java_closure($saver, null, java("com.aspose.slides.IXamlOutputSaver"));
$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setOutputSaver($proxy);
    $options->setExportHiddenSlides(false);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}

if (!$saver->valid) {
    echo "Export rejected: the artifact collection is invalid." . PHP_EOL;
    return;
}

$entries = [];
$entryNames = [];
foreach ($saver->artifacts as $name => $bytes) {
    $entryName = str_replace("\\", "/", $name);
    $unsafeName = substr($entryName, 0, 1) === "/" || strpos($entryName, ":") !== false;
    foreach (explode("/", $entryName) as $segment) {
        $unsafeName = $unsafeName || trim($segment) === "" || $segment === "." || $segment === "..";
    }
    $key = strtolower($entryName);
    if ($unsafeName || isset($entryNames[$key])) {
        echo "Export rejected: unsafe or duplicate artifact name: " . $name . PHP_EOL;
        return;
    }
    $entryNames[$key] = true;
    $entries[$entryName] = $bytes;
}

$jobDirectory = "xaml-" . bin2hex(random_bytes(16));
if (!mkdir($jobDirectory, 0700)) {
    echo "Cannot create the export directory." . PHP_EOL;
    return;
}
$archivePath = $jobDirectory . "/export.zip";
try {
    $archive = new PharData($archivePath, 0, null, Phar::ZIP);
    foreach ($entries as $name => $bytes) {
        $archive->addFromString($name, $bytes);
    }
    unset($archive);
    echo "Saved " . count($entries) . " artifacts to " . $archivePath . PHP_EOL;
} catch (Throwable $exception) {
    unset($archive);
    echo "Archive persistence failed: " . $exception->getMessage() . PHP_EOL;
}
```

Przykład używa [PharData](https://www.php.net/manual/en/class.phardata.php) do zapisu jednego lokalnego archiwum ZIP w katalogu roboczym procesu PHP; sam eksporter nie zapisuje luźnych plików XAML ani obrazów. W przypadku zdalnego przechowywania zastąp etap zapisu archiwum przesyłaniem zebranych ciągów binarnych. Użyj identyfikatora zadania eksportu plus pełnej względnej nazwy artefaktu jako klucza blob, lub przechowaj identyfikator zadania, względną nazwę i dane binarne w wierszu bazy danych. Publikuj zadanie dopiero po zakończeniu wszystkich przesyłek lub po zatwierdzeniu transakcji bazy danych. Usuń częściowy wynik, jeśli zapis się nie powiedzie.

W przypadku dużych prezentacji niestandardowy saver może zapisywać każdy artefakt bezpośrednio w magazynie aplikacji, aby uniknąć przechowywania dodatkowej kopii całego eksportu w pamięci aplikacji. Trzymaj każde wywołanie zwrotne synchroniczne z perspektywy eksportera: zwracaj wynik dopiero po zaakceptowaniu bajtów przez docelowe miejsce i pozwól, aby błędy dotarły do wywołującego.

### **Zachowanie nazw zasobów i weryfikacja odwołań**

- Normalizuj separatory ścieżek, gdy docelowe miejsce tego wymaga, ale zachowaj katalogi względne. Nie używaj jedynie [basename](https://www.php.net/manual/en/function.basename.php), chyba że każda wygenerowana nazwa jest znana jako unikalna i odwołania do zasobów pozostają prawidłowe.
- Zastosuj walidację nazw specyficzną dla docelowego miejsca. Przy zapisywaniu luźnych plików odrzuć ścieżki z korzeniem i segmenty traversalu, przekształć cel w ścieżkę absolutną i sprawdź, czy pozostaje pod zamierzonym katalogiem eksportu, uwzględniając separator katalogu w kontroli przynależności. Używaj katalogu kontrolowanego przez aplikację, bez linków symbolicznych, które mogłyby przekierować zapisy.
- Używaj osobnego saver'a i przestrzeni nazw storage dla każdego zadania eksportu. Wykrywaj kolizje po normalizacji separatora i zgodnie z regułami rozróżniania wielkości znaków w docelowym miejscu.
- Przed publikacją przetwórz każdy dokument XAML jako XML i sprawdź jego odwołania do zasobów plikowych, takie jak atrybuty obrazu `Source` lub `ImageSource`. Rozwiąż każdy względny URI względem katalogu zawierającego artefakt XAML, znormalizuj powstałą nazwę magazynu i potwierdź, że istnieje odpowiadający klucz mapy, wpis ZIP lub zapisany obiekt. Traktuj zewnętrzne URI i wyrażenia markup XAML oddzielnie od nazw plików względnych.

Na przykład, jeśli `pres/Slide_1.xaml` odwołuje się do `images/image1.png`, przechowywany zasób musi być dostępny jako `pres/images/image1.png`. Zachowanie jedynie `image1.png` przerwałoby tę zależność. W przypadku przechowywania obiektowego zachowaj tę samą strukturę pod prefiksem zadania i udostępnij te URL‑e zasobów konsumentowi XAML. Otwórz ponownie zakończone archiwum ZIP, aby zweryfikować nazwy wpisów i bajty zasobów, oraz załaduj przykładowe slajdy w docelowym środowisku XAML, aby potwierdzić prawidłowe rozwiązywanie obrazów.

## **FAQ**

**Jak mogę zapewnić przewidywalne czcionki, jeśli oryginalna czcionka nie jest dostępna na komputerze?**

Wywołaj [setDefaultRegularFont](https://reference.aspose.com/slides/pl/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) w [XamlOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/xamloptions/) — jest używany jako czcionka awaryjna podczas eksportu, gdy oryginalna brakuje. Nie gwarantuje to, że wygenerowany XAML odwołuje się do czcionki awaryjnej lub że czcionka będzie dostępna na docelowym komputerze. Upewnij się, że czcionki odwoływane w XAML są dostępne w środowisku, w którym jest wyświetlany.

**Czy wyeksportowany XAML jest przeznaczony wyłącznie dla WPF, czy może być używany także w innych stosach XAML?**

Aspose.Slides eksportuje XAML WPF poprzez publiczne API. Zgodność z innymi stosami XAML, takimi jak UWP i Xamarin.Forms, nie jest gwarantowana. Przetestuj wygenerowany znacznik w docelowym środowisku.

**Czy ukryte slajdy są obsługiwane i jak mogę zapobiec ich domyślnemu eksportowi?**

Domyślnie ukryte slajdy nie są uwzględniane. Możesz kontrolować to zachowanie za pomocą [setExportHiddenSlides](https://reference.aspose.com/slides/pl/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) w [XamlOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/xamloptions/) — pozostaw je wyłączone, jeśli nie potrzebujesz ich eksportować.