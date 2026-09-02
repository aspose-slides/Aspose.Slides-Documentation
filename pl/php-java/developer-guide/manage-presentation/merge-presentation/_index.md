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
description: "Dowiedz się, jak scalać prezentacje PowerPoint i OpenDocument w PHP, klonując slajdy, kontrolując mastery i układy, zmieniając rozmiar zawartości slajdów, zachowując sekcje oraz obsługując pliki chronione lub duże."
---
## **Przegląd**

Aspose.Slides dla PHP przy użyciu Java łączy prezentacje poprzez klonowanie slajdów z jednej [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) do drugiej. Główną operacją jest [SlideCollection::addClone()](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slidecollection/addclone/), który może zachować formatowanie źródłowego slajdu lub dołączyć sklonowany slajd do mastera lub układu w prezentacji docelowej.

Ten artykuł opisuje najczęstsze scenariusze scalania:

- scal wszystkie slajdy zachowując ich formatowanie źródłowe;
- scal wybrane slajdy;
- zastosuj master z prezentacji docelowej;
- zastosuj określony układ z prezentacji docelowej;
- znormalizuj różne rozmiary slajdów przed scaleniem;
- dodaj sklonowane slajdy do sekcji;
- scal kilka prezentacji w jednym przepływie end‑to‑end;
- obsłuż mastery, zasoby, notatki, komentarze, multimedia, czcionki, hasła, duże pliki i kwestie wielowątkowości.

## **Jak klonowanie slajdów wpływa na mastery i układy**

Slajd dziedziczy dużą część swojego wyglądu z układu i mastera. Z tego powodu wybrany przeciążony wariant klonowania określa, jak scentralizowany slajd zostanie włączony do prezentacji docelowej.

Użyj [SlideCollection::addClone()](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slidecollection/addclone/) w jeden z następujących sposobów:

- `addClone(sourceSlide)` — zachowuje układ i formatowanie źródłowego slajdu. W razie potrzeby źródłowy master może być automatycznie sklonowany do prezentacji docelowej. Aspose.Slides śledzi automatycznie sklonowane mastery, aby powtarzające się slajdy używające tego samego źródłowego mastera nie powodowały jego wielokrotnego klonowania.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — dołącza sklonowany slajd do określonego docelowego [MasterSlide](https://reference.aspose.com/slides/pl/php-java/aspose.slides/masterslide/). Aspose.Slides wyszukuje pasujący układ pod tym masterem według typu układu lub nazwy.
- `addClone(sourceSlide, destinationLayout)` — dołącza sklonowany slajd bezpośrednio do określonego docelowego [LayoutSlide](https://reference.aspose.com/slides/pl/php-java/aspose.slides/layoutslide/).

Master lub układ przekazany do przeciążenia `addClone` musi należeć do **prezentacji docelowej**, a nie do prezentacji źródłowej.

## **Scal całe prezentacje i zachowaj formatowanie źródłowe**

Najprostsze scalanie kopiuje każdy slajd z prezentacji źródłowej do prezentacji docelowej. Jest to odpowiedni wybór, gdy importowane slajdy mają zachować oryginalną tematykę, master i powiązania układów.

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

Wynikowa prezentacja może zawierać wiele masterów, gdy źródło i cel używają różnych projektów. Jest to oczekiwane, gdy formatowanie źródłowe jest świadomie zachowywane.

## **Scal wybrane slajdy**

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

Zweryfikuj indeksy slajdów przed klonowaniem, gdy pochodzą one od użytkownika lub z zewnętrznej konfiguracji.

## **Scal slajdy przy użyciu mastera docelowego**

Użyj przeciążenia [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slidecollection/addclone/) gdy importowane slajdy mają podążać za masterem, który już należy do prezentacji docelowej.

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

Użyj `false`, gdy chcesz, aby scalanie zakończyło się niepowodzeniem zamiast wprowadzania dodatkowego układu do mastera docelowego.

## **Scal slajdy przy użyciu określonego układu docelowego**

Użyj przeciążenia [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slidecollection/addclone/) gdy dokładnie wiesz, którego układu docelowego mają używać importowane slajdy.

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

Zastosowanie układu docelowego zmienia dziedziczoną relację układu; nie redesignuje treści slajdu źródłowego. Jeśli układy źródłowy i docelowy mają różne struktury placeholderów, sprawdź wynik, aby potwierdzić, że odziedziczone formatowanie i zachowanie placeholderów są odpowiednie.

## **Scal prezentacje o różnych rozmiarach slajdów**

Prezentacje o różnych wymiarach slajdów mogą być scalane, ale klonowanie slajdu do prezentacji o innym rozmiarze nie redesignuje automatycznie jego treści dla nowego płótna. Kształty mogą więc być przesunięte, nieoczekiwanie skalowane lub znajdować się poza widoczną powierzchnią slajdu.

Praktycznym podejściem jest zmiana rozmiaru prezentacji źródłowej przed klonowaniem. Metoda [SlideSize::setSize()](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slidesize/setsize/) może skalować istniejącą treść przy zmianie wymiarów slajdu. [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slidesizescaletype/) skaluje treść, aby pasowała do żądanego rozmiaru.

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

Zmiana rozmiaru modyfikuje obiekt prezentacji źródłowej w pamięci. Jeśli potrzebujesz zachować niezmienioną oryginalną prezentację źródłową do innych operacji, otwórz osobną instancję do scalania.

## **Scal slajdy w sekcję prezentacji**

Podstawowa pętla klonowania slajdów nie odtwarza hierarchii sekcji w prezentacji źródłowej. Jeśli sekcje mają znaczenie w wyniku, utwórz lub wybierz sekcje w prezentacji docelowej i klonuj slajdy do nich jawnie przy użyciu [addClone(Slide, Section)](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slidecollection/addclone/).

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

Sklonowane slajdy są dopisywane do określonej sekcji docelowej. Aby zachować kilka sekcji źródłowych, wylicz [Presentation::getSections](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation/#getSections), pobierz bieżące slajdy każdej sekcji źródłowej za pomocą [Section::getSlidesListOfSection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Section/#getSlidesListOfSection), odtwórz sekcje w prezentacji docelowej i klonuj każdy zwrócony slajd do odpowiadającej sekcji docelowej. Zobacz [Manage Slide Sections](/slides/pl/php-java/slide-section/) po kompletny przykład wyliczania sekcji, w tym puste sekcje i zmiany strukturalne.

## **Bezpieczne scalanie wielu prezentacji**

Poniższy przykład end‑to‑end używa pierwszej prezentacji jako docelowej, normalizuje rozmiar slajdu każdej dodatkowej prezentacji źródłowej, trzyma każdą prezentację otwartą tylko podczas kopiowania i zapisuje finalny plik raz.

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

Jest to przydatna baza do zachowania formatowania źródłowego importowanych slajdów. Jeśli wyjściowy wynik musi używać jednego motywu docelowego, zamień proste wywołanie `addClone($slide)` na odpowiednie przeciążenie mastera lub układu docelowego pokazane wcześniej.

## **Practical Considerations**

### **Mastery, układy i wierność formatowania**

Domyślne klonowanie slajdów może automatycznie przenieść wymagany master źródłowy do prezentacji docelowej. Aspose.Slides utrzymuje wewnętrzny rejestr automatycznie klonowanych masterów, aby uniknąć wielokrotnego klonowania tego samego mastera. Ręcznie klonowane mastery nie są śledzone w tym rejestrze, więc unikaj wstępnego klonowania masterów, chyba że potrzebujesz wyraźnej kontroli nad strukturą mastera.

Nie zakładaj, że dwa mastery lub układy o tej samej nazwie są wizualnie równoważne. Jeśli szablon korporacyjny ma kontrolować ostateczny wygląd, wybierz wyraźnie master lub układ docelowy i zweryfikuj wynik po scaleniu.

### **Notes and Comments**

Notatki prelegenta i komentarze slajdów są powiązane z treścią slajdu i są kopiowane podczas klonowania slajdu. Aspose.Slides udostępnia także dedykowane API dla [presentation notes](/slides/pl/php-java/presentation-notes/) i [presentation comments](/slides/pl/php-java/presentation-comments/).

Jeśli formatowanie strony notatek jest ważne, sprawdź scaloną prezentację, ponieważ mastery notatek są obiektami na poziomie prezentacji i mogą się różnić między plikami źródłowymi. W przepływach recenzji sprawdzaj także autorów komentarzy i komentarze wątkowe po połączeniu plików od różnych autorów lub szablonów.

### **Obrazy, audio, wideo, obiekty OLE i linki zewnętrzne**

Slajdy mogą odwoływać się do zasobów na poziomie prezentacji, takich jak obrazy, osadzone audio, osadzone wideo i dane OLE. Klonuj sam slajd, a nie tylko widoczne kształty, aby Aspose.Slides mógł utrzymać relacje slajdu do jego zasobów.

Zasoby osadzone i linkowane należy traktować inaczej. Linkowane audio, wideo, obiekt OLE lub hiperłącze pozostaje zależne od zewnętrznego celu; klonowanie slajdu nie zmienia linku zewnętrznego w treść osadzoną. Testuj ścieżki i adresy URL zasobów linkowanych w środowisku, w którym otwierana będzie scalona prezentacja.

Aspose.Slides wyraźnie śledzi automatycznie klonowane mastery, ale nie należy tego traktować jako ogólnej gwarancji, że identyczne zasoby binarne z niezwiązanych prezentacji źródłowych zawsze zostaną zduplikowane. Jeśli rozmiar pliku wyjściowego jest ważny, przeanalizuj scalony pakiet i zmierz wynik zamiast polegać na domyślnej deduplikacji.

### **Czcionki osadzone i dostępność czcionek**

Czcionki są zarządzane na poziomie prezentacji. Jeśli typografia musi pozostać spójna na różnych maszynach, nie zakładaj, że klonowanie slajdów samo w sobie zapewnia dostępność każdej wymagalnej czcionki w środowisku docelowym. Możesz sprawdzić osadzone czcionki przy pomocy [FontsManager::getEmbeddedFonts()](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontsmanager/getembeddedfonts/) i zarządzać ich osadzaniem tak, jak opisano w [Embed Fonts in Presentations](/slides/pl/php-java/embedded-font/).

Również zweryfikuj, czy masz prawo osadzać czcionki użyte w plikach źródłowych. Licencje czcionek mogą ograniczać możliwość ich osadzania.

### **Prezentacje zabezpieczone hasłem**

Źródło zabezpieczone hasłem musi być otwarte pomyślnie, zanim jego slajdy będą mogły zostać sklonowane. Podaj hasło poprzez [LoadOptions::setPassword()](https://reference.aspose.com/slides/pl/php-java/aspose.slides/loadoptions/setpassword/).

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

Otwarcie zaszyfrowanego źródła nie nakłada automatycznie tej samej ochrony na prezentację docelową. Ochronę wyjściową konfiguruje się oddzielnie, gdy jest wymagana.

### **Duże prezentacje i zużycie pamięci**

Duże prezentacje zawierające obrazy wysokiej rozdzielczości, audio, wideo lub inne duże obiekty binarne mogą zużywać znaczną ilość pamięci. [LoadOptions::getBlobManagementOptions()](https://reference.aspose.com/slides/pl/php-java/aspose.slides/loadoptions/getblobmanagementoptions/) zapewnia kontrolę nad obsługą BLOB‑ów i użyciem plików tymczasowych. Zobacz [Open Presentations](/slides/pl/php-java/open-presentation/#open-large-presentations) po przykład obsługi dużych plików w PHP via Java.

W przypadku dużych plików preferuj ładowanie z ścieżek plików, gdy to możliwe, zwalniaj każdą prezentację źródłową natychmiast po jej scaleniu i unikaj wielokrotnego zapisywania wyników pośrednich, chyba że przepływ wymaga punktów kontrolnych.

### **Bezpieczeństwo wątków**

Nie ładuj, nie modyfikuj, nie zapisuj ani nie klonuj instancji [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) w wielu wątkach. Operacje te nie są wspierane w środowisku PHP via Java w trybie wielowątkowym. Jeśli potrzebujesz równoległych zadań scalania, uruchom je w oddzielnych procesach jednowątkowych, przy czym każdy proces używa własnych instancji prezentacji, i postępuj zgodnie z [Aspose.Slides multithreading guidance](/slides/pl/php-java/multithreading/).

## **FAQ**

**Jak zachować oryginalny projekt każdej prezentacji źródłowej?**

Użyj [SlideCollection::addClone](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slidecollection/addclone/) bez podawania mastera lub układu docelowego. Aspose.Slides może automatycznie sklonować master źródłowy, gdy jest potrzebny importowanemu slajdowi.

**Jak sprawić, aby importowane slajdy używały motywu docelowego?**

Użyj przeciążenia, które przyjmuje master docelowy. Przekaż master z prezentacji docelowej, nie ze źródłowej. Aspose.Slides spróbuje dopasować każdy slajd źródłowy do odpowiedniego układu pod tym masterem.

**Kiedy używać konkretnego układu docelowego zamiast mastera docelowego?**

Użyj konkretnego układu, gdy każdy importowany slajd ma używać jednego znanego układu. Użyj mastera, gdy chcesz, aby Aspose.Slides wybrał odpowiedni układ spośród tego mastera na podstawie typu lub nazwy układu źródłowego.

**Czy można scalać prezentacje o różnych rozmiarach slajdów?**

Tak, ale treść slajdów nie jest automatycznie redesignowana pod nowe wymiary. Zmien rozmiar prezentacji źródłowej najpierw, gdy potrzebne jest przewidywalne rozmieszczenie, np. przy użyciu [SlideSize::setSize()](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slidesize/setsize/) i [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slidesizescaletype/).

**Czy mogę scalić prezentacje PPT, PPTX i ODP w jeden plik?**

Tak. Wczytaj każdą prezentację źródłową, sklonuj wymagane slajdy do jednej prezentacji docelowej i zapisz ją w obsługiwanym formacie wyjściowym. Ponieważ formaty prezentacji nie obsługują dokładnie tego samego zestawu funkcji, zweryfikuj złożoną treść po scalaniu międzyformatowym. Zobacz [Supported File Formats](/slides/pl/php-java/supported-file-formats/).

**Czy sekcje źródłowe są zachowywane automatycznie?**

Nie, nie przy podstawowej pętli, która jedynie klonuje slajdy. Utwórz wymagane sekcje w prezentacji docelowej i użyj przeciążenia sekcji [addClone](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slidecollection/addclone/) gdy struktura sekcji musi być zachowana.

**Czy notatki prelegenta i komentarze są zachowywane?**

Są kopiowane wraz ze sklonowanym slajdem. W przepływach zależnych od stylu mastera notatek, autorów komentarzy lub wątków recenzenckich, zweryfikuj scalony wynik, ponieważ te scenariusze obejmują zarówno struktury na poziomie prezentacji, jak i treść slajdów.

**Co się dzieje z audio, wideo, obiektami OLE i hiperłączami?**

Zawartość osadzona jest przenoszona jako część relacji zasobów sklonowanego slajdu. Linki zewnętrzne pozostają zewnętrzne, więc ich docelowe pliki lub adresy URL muszą być dostępne po scaleniu.

**Czy osadzone czcionki ze wszystkich źródeł są gwarantowane w scalonej prezentacji?**

Nie polegaj wyłącznie na klonowaniu slajdów w celu wdrożenia czcionek. Sprawdź osadzone czcionki w docelowej prezentacji i zarządzaj ich osadzaniem lub dostępnością zewnętrzną, gdy typografia jest istotna.

**Jak scalić plik zabezpieczony hasłem?**

Otwórz go przy użyciu właściwego [LoadOptions::setPassword()](https://reference.aspose.com/slides/pl/php-java/aspose.slides/loadoptions/setpassword/), a następnie normalnie sklonuj jego slajdy. Ochronę wyjściową konfiguruje się oddzielnie.

**Jak postępować z bardzo dużymi prezentacjami?**

Używaj zarządzania BLOB‑ami, gdy duże obiekty binarne dominują zużycie pamięci, preferuj ładowanie z ścieżek plików dla bardzo dużych plików, zwalniaj prezentacje źródłowe niezwłocznie po scaleniu i zapisuj finalny wynik tylko w razie potrzeby.

**Czy mogę scalać slajdy z wielu wątków?**

Ładowanie, zapisywanie lub klonowanie prezentacji w wielu wątkach nie jest obsługiwane w PHP via Java. Dla równoległych zadań używaj oddzielnych procesów jednowątkowych i utrzymuj instancje prezentacji odseparowane w każdym procesie.