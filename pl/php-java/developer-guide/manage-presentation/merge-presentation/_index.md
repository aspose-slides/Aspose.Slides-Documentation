---
title: Efektywne scalanie prezentacji w PHP
linktitle: Scalanie prezentacji
type: docs
weight: 40
url: /pl/php-java/merge-presentation/
keywords:
- scal PowerPoint
- scal prezentacje
- scal slajdy
- scal PPT
- scal PPTX
- scal ODP
- połącz PowerPoint
- połącz prezentacje
- połącz slajdy
- połącz PPT
- połącz PPTX
- połącz ODP
- PHP
- Aspose.Slides
description: "Dowiedz się, jak scalać prezentacje PowerPoint i OpenDocument w PHP, klonując slajdy, kontrolując mastery i układy, zmieniając rozmiar zawartości slajdów, zachowując sekcje oraz obsługując chronione lub duże pliki."
---
## **Przegląd**

Aspose.Slides for PHP via Java scala prezentacje, klonując slajdy z jednej [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) do drugiej. Główną operacją jest [SlideCollection::addClone()](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slidecollection/addclone/), który może zachować formatowanie źródłowego slajdu lub dołączyć sklonowany slajd do mastera lub układu w prezentacji docelowej.

W tym artykule omówiono najczęstsze scenariusze scalania:

- scal wszystkie slajdy, zachowując ich formatowanie źródłowe;
- scal wybrane slajdy;
- zastosuj master z prezentacji docelowej;
- zastosuj określony układ z prezentacji docelowej;
- znormalizuj różne rozmiary slajdów przed scaleniem;
- dodaj sklonowane slajdy do sekcji;
- scal kilka prezentacji w jednym procesie end‑to‑end;
- obsłuż mastery, zasoby, notatki, komentarze, multimedia, czcionki, hasła, duże pliki i kwestie wielowątkowości.

## **Jak klonowanie slajdów wpływa na mastery i układy**

Slajd dziedziczy dużą część wyglądu z jego układu i mastera. Z tego powodu wybrany przeciążony wariant klonowania określa, w jaki sposób scalony slajd zostanie włączony do prezentacji docelowej.

Użyj [SlideCollection::addClone()](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slidecollection/addclone/) w jednej z następujących form:

- `addClone(sourceSlide)` — zachowuje układ i formatowanie źródłowego slajdu. W razie potrzeby master źródła może zostać automatycznie sklonowany do prezentacji docelowej. Aspose.Slides automatycznie śledzi sklonowane mastery, tak aby powtarzające się slajdy używające tego samego mastera nie powodowały wielokrotnego klonowania.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — dołącza sklonowany slajd do konkretnego [MasterSlide](https://reference.aspose.com/slides/pl/php-java/aspose.slides/masterslide/) w prezentacji docelowej. Aspose.Slides szuka pasującego układu pod tym masterem według typu lub nazwy układu.
- `addClone(sourceSlide, destinationLayout)` — dołącza sklonowany slajd bezpośrednio do konkretnego [LayoutSlide](https://reference.aspose.com/slides/pl/php-java/aspose.slides/layoutslide/) w prezentacji docelowej.

Master lub układ przekazany do przeciążenia `addClone` musi należeć do **prezentacji docelowej**, a nie do prezentacji źródłowej.

## **Scalanie całych prezentacji i zachowanie formatowania źródła**

Najprostsze scalanie kopiuje każdy slajd z prezentacji źródłowej do prezentacji docelowej. To odpowiedni wybór, gdy zaimportowane slajdy mają zachować oryginalny motyw, master i powiązania układu.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

W rezultacie prezentacja może zawierać wiele masterów, gdy źródło i cel używają różnych szablonów. Jest to oczekiwane, gdy formatowanie źródła jest celowo zachowywane.

## **Scalanie wybranych slajdów**

Nie musisz klonować każdego slajdu. Poniższy przykład importuje tylko wybrane indeksy slajdów ze źródłowej prezentacji.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $slideIndexes = [0, 2, 4];

        foreach ($slideIndexes as $index) {
            $destination->getSlides()->addClone($source->getSlides()->get_Item($index));
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-selected-slides.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Waliduj indeksy slajdów przed klonowaniem, gdy pochodzą one od użytkownika lub z zewnętrznej konfiguracji.

## **Scalanie slajdów przy użyciu mastera docelowego**

Użyj przeciążenia [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slidecollection/addclone/), gdy zaimportowane slajdy mają korzystać z mastera, który już należy do prezentacji docelowej.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $destinationMaster = $destination->getMasters()->get_Item(0);

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $destinationMaster, true);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-destination-master.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Aspose.Slides wybiera odpowiedni układ pod określonym masterem, dopasowując typ lub nazwę układu źródłowego. Jeśli nie istnieje pasujący układ i `allowCloneMissingLayout` jest `true`, układ źródłowy jest klonowany, aby slajd mógł zostać dodany. Jeśli jest `false`, zostaje rzucony [PptxEditException](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pptxeditexception/).

Użyj `false`, gdy chcesz, aby scalanie zakończyło się błędem zamiast wprowadzania dodatkowego układu do mastera docelowego.

## **Scalanie slajdów przy użyciu konkretnego układu docelowego**

Użyj przeciążenia [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slidecollection/addclone/), gdy dokładnie wiesz, który układ docelowy mają używać zaimportowane slajdy.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $destinationLayout = $destination->getLayoutSlides()->get_Item(0);

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $destinationLayout);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-destination-layout.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Zastosowanie układu docelowego zmienia dziedziczoną relację układu; nie przerysowuje zawartości slajdu źródłowego. Jeśli układy źródłowy i docelowy mają różne struktury placeholderów, sprawdź wynik, aby potwierdzić, że odziedziczone formatowanie i zachowanie placeholderów jest prawidłowe.

## **Scalanie prezentacji o różnych rozmiarach slajdów**

Prezentacje o różnych wymiarach slajdów mogą być scalane, ale klonowanie slajdu do prezentacji o innym rozmiarze nie przerysowuje automatycznie jego zawartości do nowego płótna. Kształty mogą więc być przesunięte, przeskalowane nieoczekiwanie lub znajdować się poza widoczną częścią slajdu.

Praktycznym podejściem jest zmiana rozmiaru prezentacji źródłowej przed klonowaniem. Metoda [SlideSize::setSize()](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slidesize/setsize/) może skalować istniejącą zawartość przy jednoczesnej zmianie wymiarów slajdu. [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slidesizescaletype/) skaluje zawartość, aby pasowała do żądanego rozmiaru.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $sourceWidth = java_values($source->getSlideSize()->getSize()->getWidth());
        $sourceHeight = java_values($source->getSlideSize()->getSize()->getHeight());
        $destinationWidth = java_values($destination->getSlideSize()->getSize()->getWidth());
        $destinationHeight = java_values($destination->getSlideSize()->getSize()->getHeight());

        if ($sourceWidth != $destinationWidth || $sourceHeight != $destinationHeight) {
            $source->getSlideSize()->setSize($destinationWidth, $destinationHeight, SlideSizeScaleType::EnsureFit);
        }

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-same-slide-size.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Zmiana rozmiaru modyfikuje obiekt prezentacji źródłowej w pamięci. Jeśli potrzebujesz niezmienionej wersji źródła do innych operacji, otwórz oddzielną instancję dla scalania.

## **Scalanie slajdów do sekcji prezentacji**

Podstawowa pętla klonowania slajdów nie odtwarza hierarchii sekcji źródłowej prezentacji. Jeśli sekcje mają znaczenie w wyniku, utwórz lub wybierz sekcje w prezentacji docelowej i klonuj slajdy do nich explicite, używając [addClone(Slide, Section)](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slidecollection/addclone/).

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $importedSection = $destination->getSections()->appendEmptySection("Imported slides");

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $importedSection);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-section.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Sklonowane slajdy są dołączane do wskazanej sekcji docelowej. Aby zachować kilka sekcji źródłowych, odtwórz te sekcje w docelowej prezentacji i mapuj każdy slajd źródłowy do odpowiadającej sekcji docelowej.

## **Bezpieczne scalanie wielu prezentacji**

Poniższy przykład end‑to‑end używa pierwszej prezentacji jako docelowej, normalizuje rozmiar slajdu każdego dodatkowego źródła, trzyma każde źródło otwarte tylko podczas kopiowania i zapisuje finalny plik jednorazowo.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$inputFiles = ["part1.pptx", "part2.pptx", "part3.pptx"];

$merged = new Presentation($inputFiles[0]);
try {
    $mergedWidth = java_values($merged->getSlideSize()->getSize()->getWidth());
    $mergedHeight = java_values($merged->getSlideSize()->getSize()->getHeight());

    for ($fileIndex = 1; $fileIndex < count($inputFiles); $fileIndex++) {
        $source = new Presentation($inputFiles[$fileIndex]);
        try {
            $sourceWidth = java_values($source->getSlideSize()->getSize()->getWidth());
            $sourceHeight = java_values($source->getSlideSize()->getSize()->getHeight());

            if ($sourceWidth != $mergedWidth || $sourceHeight != $mergedHeight) {
                $source->getSlideSize()->setSize($mergedWidth, $mergedHeight, SlideSizeScaleType::EnsureFit);
            }

            foreach ($source->getSlides() as $slide) {
                $merged->getSlides()->addClone($slide);
            }
        } finally {
            $source->dispose();
        }
    }

    $merged->save("merged.pptx", SaveFormat::Pptx);
} finally {
    $merged->dispose();
}
```

Jest to przydatna podstawa do zachowania formatowania źródła importowanych slajdów. Jeśli wynik ma używać jednego motywu docelowego, zamień proste wywołanie `addClone($slide)` na odpowiednie przeciążenie mastera lub układu docelowego pokazane wcześniej.

## **Praktyczne uwagi**

### **Mastery, układy i wierność formatowania**

Domyślne klonowanie slajdów może automatycznie przenieść wymagany master źródła do prezentacji docelowej. Aspose.Slides utrzymuje wewnętrzny rejestr automatycznie klonowanych masterów, aby uniknąć wielokrotnego klonowania tego samego mastera. Ręcznie klonowane mastery nie są śledzone przez ten rejestr, więc unikaj wstępnego klonowania masterów, chyba że potrzebna jest jawna kontrola nad strukturą mastera.

Nie zakładaj, że dwa mastery lub układy o tej samej nazwie są wizualnie równoważne. Jeśli szablon korporacyjny musi kontrolować ostateczny wygląd, wybierz jawnie master lub układ docelowy i zweryfikuj wynik po scaleniu.

### **Notatki i komentarze**

Notatki prelegenta i komentarze slajdu są powiązane z zawartością slajdu i są kopiowane podczas klonowania slajdu. Aspose.Slides udostępnia także dedykowane API dla [presentation notes](https://docs.aspose.com/slides/pl/php-java/presentation-notes/) i [presentation comments](https://docs.aspose.com/slides/pl/php-java/presentation-comments/).

Jeśli formatowanie strony notatek jest ważne, sprawdź scaloną prezentację, ponieważ mastery notatek są obiektami poziomu prezentacji i mogą różnić się między plikami źródłowymi. W scenariuszach przeglądu zweryfikuj także autorów komentarzy i wątki komentarzy po połączeniu plików od różnych autorów lub szablonów.

### **Obrazy, audio, wideo, obiekty OLE i linki zewnętrzne**

Slajdy mogą odwoływać się do zasobów na poziomie prezentacji, takich jak obrazy, osadzone audio, wideo oraz dane OLE. Klonuj cały slajd, a nie tylko widoczne kształty, aby Aspose.Slides mogło zachować powiązania slajdu z jego zasobami.

Zasoby osadzone i linkowane należy traktować inaczej. Linkowane audio, wideo, obiekt OLE lub hiperlink pozostają zależne od zewnętrznego docelowego zasobu; klonowanie slajdu nie zmienia linku zewnętrznego w treść osadzoną. Przetestuj ścieżki i URL‑e zasobów linkowanych w środowisku, w którym otwierana będzie scalona prezentacja.

Aspose.Slides wyraźnie śledzi automatycznie klonowane mastery, ale nie należy tego traktować jako ogólnej gwarancji, że identyczne binarne zasoby z niepowiązanych źródeł będą zawsze deduplikowane. Jeśli rozmiar pliku wyjściowego ma znaczenie, przeanalizuj scalony pakiet i zmierz wynik zamiast polegać na domyślnej deduplikacji.

### **Osadzone czcionki i dostępność czcionek**

Czcionki są zarządzane na poziomie prezentacji. Jeśli typografia musi pozostać spójna na różnych maszynach, nie zakładaj, że klonowanie slajdów samo w sobie zapewnia dostępność wszystkich potrzebnych czcionek w docelowym środowisku. Możesz sprawdzić osadzone czcionki przy użyciu [FontsManager::getEmbeddedFonts()](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontsmanager/getembeddedfonts/) i zarządzać ich osadzaniem, jak opisano w [Embed Fonts in Presentations](https://docs.aspose.com/slides/pl/php-java/embedded-font/).

Upewnij się również, że masz prawo do osadzania czcionek używanych w plikach źródłowych. Licencje czcionek mogą ograniczać możliwość osadzania.

### **Prezentacje chronione hasłem**

Źródło chronione hasłem musi zostać pomyślnie otwarte, zanim jego slajdy będą mogły być klonowane. Podaj hasło przy pomocy [LoadOptions::setPassword()](https://reference.aspose.com/slides/pl/php-java/aspose.slides/loadoptions/setpassword/).

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("YOUR_PASSWORD");

$source = new Presentation("protected.pptx", $loadOptions);
try {
    // Pracuj z odszyfrowaną prezentacją.
} finally {
    $source->dispose();
}
```

Otwarcie zaszyfrowanego źródła nie nakłada automatycznie tej samej ochrony na prezentację docelową. Konfiguruj ochronę wyjścia osobno, gdy jest wymagana.

### **Duże prezentacje i zużycie pamięci**

Duże prezentacje zawierające obrazy wysokiej rozdzielczości, audio, wideo lub inne duże obiekty binarne mogą zużywać znaczne ilości pamięci. [LoadOptions::getBlobManagementOptions()](https://reference.aspose.com/slides/pl/php-java/aspose.slides/loadoptions/getblobmanagementoptions/) udostępnia kontrolę nad obsługą BLOB‑ów i użyciem plików tymczasowych. Zobacz [Open Presentations](https://docs.aspose.com/slides/pl/php-java/open-presentation/#open-large-presentations) po przykład dużych plików w PHP via Java.

W przypadku dużych plików preferuj ładowanie z ścieżek plików, gdy to możliwe, zwalniaj każdą prezentację źródłową natychmiast po jej scaleniu i unikaj wielokrotnego zapisywania wyników pośrednich, chyba że proces wymaga punktów kontrolnych.

### **Bezpieczeństwo wątków**

Nie ładuj, nie modyfikuj, nie zapisuj ani nie klonuj instancji [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) w wielu wątkach. Operacje te nie są wspierane w środowisku PHP via Java. Jeśli potrzebujesz równoległych zadań scalania, uruchom je w osobnych jednowątkowych procesach, przy czym każdy proces używa własnych instancji prezentacji, i postępuj zgodnie z [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/pl/php-java/multithreading/).

## **FAQ**

**Jak zachować oryginalny projekt każdej prezentacji źródłowej?**

Użyj [`addClone(sourceSlide)`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slidecollection/addclone/) bez podawania mastera lub układu docelowego. Aspose.Slides może automatycznie sklonować master źródła, gdy jest potrzebny dla importowanego slajdu.

**Jak sprawić, aby importowane slajdy używały motywu docelowego?**

Użyj przeciążenia, które przyjmuje master docelowy. Przekaż master z prezentacji docelowej, a nie ze źródłowej. Aspose.Slides spróbuje dopasować każdy slajd źródłowy do odpowiedniego układu pod tym masterem.

**Kiedy wybrać konkretny układ docelowy zamiast mastera docelowego?**

Wybierz konkretny układ, gdy każdy importowany slajd ma korzystać z jednego znanego układu. Użyj mastera, gdy chcesz, aby Aspose.Slides wybrał spośród układów tego mastera na podstawie typu lub nazwy układu źródłowego.

**Czy można scalać prezentacje o różnych rozmiarach slajdów?**

Tak, ale zawartość slajdu nie jest automatycznie przystosowywana do wymiarów docelowych. Zmień rozmiar prezentacji źródłowej najpierw, np. przy użyciu [SlideSize::setSize()](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slidesize/setsize/) i [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slidesizescaletype/).

**Czy mogę scalać pliki PPT, PPTX i ODP w jeden plik?**

Tak. Załaduj każdą prezentację źródłową, sklonuj wymagane slajdy do jednej prezentacji docelowej i zapisz ją w obsługiwanym formacie wyjściowym. Ponieważ formaty prezentacji nie obsługują dokładnie tego samego zestawu funkcji, zweryfikuj złożoną zawartość po scalaniu międzyformatowym. Zobacz [Supported File Formats](https://docs.aspose.com/slides/pl/php-java/supported-file-formats/).

**Czy sekcje źródłowe są zachowywane automatycznie?**

Nie, w podstawowej pętli, która tylko klonuje slajdy, nie są. Odtwórz wymagane sekcje w prezentacji docelowej i użyj przeciążenia sekcji [addClone](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slidecollection/addclone/), gdy struktura sekcji musi być zachowana.

**Czy notatki prelegenta i komentarze są zachowywane?**

Są kopiowane wraz ze sklonowanym slajdem. W przepływach zależnych od stylizacji mastera notatek, autorów komentarzy lub danych recenzji wątkowych, zweryfikuj wynik scalania, ponieważ te scenariusze obejmują struktury na poziomie prezentacji oraz treść slajdu.

**Co się dzieje z audio, wideo, obiektami OLE i hiperłączami?**

Zawartość osadzona jest przenoszona jako część powiązań zasobów sklonowanego slajdu. Linki zewnętrzne pozostają zewnętrzne, więc ich docelowe pliki lub adresy URL muszą być nadal dostępne po scaleniu.

**Czy osadzone czcionki ze wszystkich źródeł są gwarantowane w scalonej prezentacji?**

Nie polegaj wyłącznie na klonowaniu slajdów w kwestii wdrażania czcionek. Sprawdź osadzone czcionki w prezentacji docelowej i zarządzaj ich osadzaniem lub dostępnością zewnętrzną, gdy typografia jest istotna.

**Jak scalić plik chroniony hasłem?**

Otwórz go przy użyciu odpowiedniego [LoadOptions::setPassword()](https://reference.aspose.com/slides/pl/php-java/aspose.slides/loadoptions/setpassword/), a następnie normalnie klonuj jego slajdy. Ochrona wyjścia jest konfigurowana osobno.

**Jak postępować z bardzo dużymi prezentacjami?**

Używaj zarządzania BLOB, gdy duże obiekty binarne dominują zużycie pamięci, preferuj ładowanie z ścieżek plików dla bardzo dużych plików, szybko zwalniaj prezentacje źródłowe i zapisuj ostateczny wynik dopiero wtedy, gdy jest to konieczne.

**Czy mogę scalać slajdy z wielu wątków?**

Ładowanie, zapisywanie lub klonowanie [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) w wielu wątkach nie jest wspierane w PHP via Java. Dla równoległej pracy użyj oddzielnych jednowątkowych procesów i utrzymuj instancje prezentacji izolowane w każdym procesie.