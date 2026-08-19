---
title: Efektywne scalanie prezentacji w Javie
linktitle: Scalanie prezentacji
type: docs
weight: 40
url: /pl/java/merge-presentation/
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
- Java
- Aspose.Slides
description: "Dowiedz się, jak scalać prezentacje PowerPoint i OpenDocument w Javie, klonując slajdy, kontrolując mastery i układy, zmieniając rozmiar zawartości slajdów, zachowując sekcje oraz obsługując chronione lub duże pliki."
---
## **Przegląd**

Aspose.Slides for Java scala prezentacje poprzez klonowanie slajdów z jednej [Prezentacja](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) do drugiej. Główną operacją jest [ISlideCollection.addClone](https://reference.aspose.com/slides/pl/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-), która może zachować formatowanie źródłowego slajdu lub dołączyć sklonowany slajd do mastera lub układu w docelowej prezentacji.

Ten artykuł opisuje najczęstsze scenariusze łączenia:

- scal wszystkie slajdy, zachowując ich formatowanie źródłowe;
- scal wybrane slajdy;
- zastosuj master z docelowej prezentacji;
- zastosuj konkretny układ z docelowej prezentacji;
- normalizuj różne rozmiary slajdów przed scaleniem;
- dodaj sklonowane slajdy do sekcji;
- scal kilka prezentacji w jeden kompleksowy proces;
- obsłuż mastery, zasoby, notatki, komentarze, multimedia, czcionki, hasła, duże pliki oraz kwestie wielowątkowości.

## **Jak klonowanie slajdów wpływa na mastery i układy**

Slajd dziedziczy dużą część swojego wyglądu z układu i mastera. Z tego powodu wybrany overload klonowania określa, jak scalony slajd zostanie włączony do docelowej prezentacji.

Użyj [ISlideCollection.addClone](https://reference.aspose.com/slides/pl/java/com.aspose.slides/islidecollection/) w jednej z następujących metod:

- `addClone(sourceSlide)` — zachowuje układ i formatowanie źródłowego slajdu. W razie potrzeby źródłowy master może zostać automatycznie sklonowany do docelowej prezentacji. Aspose.Slides śledzi automatycznie klonowane mastery, więc powtarzające się slajdy używające tego samego mastera nie powodują jego wielokrotnego klonowania.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — dołącza sklonowany slajd do określonego docelowego [IMasterSlide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imasterslide/). Aspose.Slides szuka pasującego układu pod tym masterem według typu układu lub nazwy.
- `addClone(sourceSlide, destinationLayout)` — dołącza sklonowany slajd bezpośrednio do określonego docelowego [ILayoutSlide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ilayoutslide/).

Master lub układ przekazany do overloadu `addClone` musi należeć do **docelowej** prezentacji, nie do źródłowej.

## **Scal całe prezentacje i zachowaj formatowanie źródłowe**

Najprostszym scaleniem jest skopiowanie każdego slajdu ze źródłowej prezentacji do docelowej. To właściwy wybór, gdy zaimportowane slajdy powinny zachować oryginalny motyw, master i powiązania układów.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide);
    }

    destination.save("merged.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Powstała prezentacja może zawierać wiele masterów, gdy źródło i cel używają różnych projektów. Jest to oczekiwane, gdy formatowanie źródła jest celowo zachowywane.

## **Scal wybrane slajdy**

Nie musisz klonować każdego slajdu. Poniższy przykład importuje tylko wybrane indeksy slajdów ze źródłowej prezentacji.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    int[] slideIndexes = { 0, 2, 4 };

    for (int index : slideIndexes) {
        destination.getSlides().addClone(source.getSlides().get_Item(index));
    }

    destination.save("merged-selected-slides.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Sprawdź poprawność indeksów slajdów przed klonowaniem, gdy pochodzą one od użytkownika lub z zewnętrznej konfiguracji.

## **Scal slajdy przy użyciu docelowego mastera**

Użyj overloadu [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/pl/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) gdy zaimportowane slajdy mają korzystać z mastera, który już należy do docelowej prezentacji.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    IMasterSlide destinationMaster = destination.getMasters().get_Item(0);

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, destinationMaster, true);
    }

    destination.save("merged-with-destination-master.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Aspose.Slides wybiera odpowiedni układ pod określonym masterem, dopasowując typ lub nazwę układu źródłowego. Jeśli nie istnieje odpowiedni układ i `allowCloneMissingLayout` ma wartość `true`, układ źródłowy jest klonowany, aby można było dodać slajd. Jeśli jest `false`, zostaje rzucony [PptxEditException](https://reference.aspose.com/slides/pl/java/com.aspose.slides/pptxeditexception/).

Użyj `false`, gdy chcesz, aby scalanie zakończyło się niepowodzeniem zamiast wprowadzania dodatkowego układu do docelowego mastera.

## **Scal slajdy przy użyciu konkretnego docelowego układu**

Użyj overloadu [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/pl/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) gdy dokładnie wiesz, którego docelowego układu mają używać zaimportowane slajdy.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    ILayoutSlide destinationLayout = destination.getLayoutSlides().get_Item(0);

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, destinationLayout);
    }

    destination.save("merged-with-destination-layout.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Zastosowanie docelowego układu zmienia dziedziczoną relację układu; nie przetwarza treści slajdu źródłowego. Jeśli układy źródłowy i docelowy mają różne struktury placeholderów, sprawdź wynik, aby potwierdzić, że odziedziczone formatowanie i zachowanie placeholderów są właściwe.

## **Scal prezentacje o różnych rozmiarach slajdów**

Prezentacje o różnych wymiarach slajdów można scalać, ale klonowanie slajdu do prezentacji o innym rozmiarze nie przekształca automatycznie jego treści do nowego płótna. Kształty mogą więc wyglądać na przesunięte, nieoczekiwanie skalowane lub poza widocznym obszarem slajdu.

Praktycznym podejściem jest zmiana rozmiaru źródłowej prezentacji przed klonowaniem. Metoda [SlideSize.setSize](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slidesize/#setSize-float-float-int-) może skalować istniejącą treść przy zmianie wymiarów slajdu. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slidesizescaletype/) skaluje zawartość, aby zmieściła się w żądanym rozmiarze.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    Dimension2D sourceSize = source.getSlideSize().getSize();
    Dimension2D destinationSize = destination.getSlideSize().getSize();

    if (sourceSize.getWidth() != destinationSize.getWidth() || 
        sourceSize.getHeight() != destinationSize.getHeight()) {
        source.getSlideSize().setSize(
            (float) destinationSize.getWidth(), 
            (float) destinationSize.getHeight(), 
            SlideSizeScaleType.EnsureFit);
    }

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide);
    }

    destination.save("merged-same-slide-size.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Zmiana rozmiaru modyfikuje obiekt źródłowej prezentacji w pamięci. Jeśli potrzebujesz niezmienionej oryginalnej prezentacji źródłowej do innych operacji, otwórz osobną instancję do scalania.

## **Scal slajdy do sekcji prezentacji**

Podstawowa pętla klonowania slajdów nie odtwarza hierarchii sekcji w źródłowej prezentacji. Jeśli sekcje są istotne w wyniku, utwórz lub wybierz sekcje w docelowej prezentacji i wyraźnie klonuj slajdy do nich przy użyciu [addClone(ISlide, ISection)](https://reference.aspose.com/slides/pl/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISSlide-com.aspose.slides.ISection-).

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    ISection importedSection = destination.getSections().appendEmptySection("Imported slides");

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, importedSection);
    }

    destination.save("merged-with-section.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Sklonowane slajdy są dołączane do określonej docelowej sekcji. Aby zachować wiele sekcji źródłowych, odtwórz je w docelowej prezentacji i mapuj każdy slajd źródłowy do odpowiadającej sekcji docelowej.

## **Bezpieczne scalanie wielu prezentacji**

Poniższy przykład end-to-end używa pierwszej prezentacji jako docelowej, normalizuje rozmiar slajdu każdego dodatkowego źródła, utrzymuje każde źródło otwarte tylko w czasie kopiowania i zapisuje końcowy plik raz.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

String[] inputFiles = { "part1.pptx", "part2.pptx", "part3.pptx" };

Presentation merged = new Presentation(inputFiles[0]);
try {
    Dimension2D mergedSize = merged.getSlideSize().getSize();

    for (int fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        Presentation source = new Presentation(inputFiles[fileIndex]);
        try {
            Dimension2D sourceSize = source.getSlideSize().getSize();

            if (sourceSize.getWidth() != mergedSize.getWidth() || 
                sourceSize.getHeight() != mergedSize.getHeight()) {
                source.getSlideSize().setSize(
                    (float) mergedSize.getWidth(), 
                    (float) mergedSize.getHeight(), 
                    SlideSizeScaleType.EnsureFit);
            }

            for (ISlide slide : source.getSlides()) {
                merged.getSlides().addClone(slide);
            }
        } finally {
            source.dispose();
        }
    }

    merged.save("merged.pptx", SaveFormat.Pptx);
} finally {
    merged.dispose();
}
```

Jest to przydatna podstawa do zachowania formatowania źródłowego zaimportowanych slajdów. Jeśli wynik ma używać jednego docelowego motywu, zamień prostą wywołanie `addClone(slide)` na odpowiedni overload destination-master lub destination-layout przedstawiony wcześniej.

## **Praktyczne rozważania**

### **Mastery, układy i wierność formatowania**

Domyślne klonowanie slajdów może automatycznie przenieść wymagany master źródłowy do docelowej prezentacji. Aspose.Slides utrzymuje wewnętrzny rejestr automatycznie klonowanych masterów, aby uniknąć wielokrotnego klonowania tego samego mastera. Ręcznie klonowane mastery nie są śledzone w tym rejestrze, więc unikaj wstępnego klonowania masterów, chyba że potrzebujesz wyraźnej kontroli nad strukturą mastera.

Nie zakładaj, że dwa mastery lub układy o tej samej nazwie są wizualnie równoważne. Jeśli szablon korporacyjny ma kontrolować ostateczny wygląd, wybierz wyraźnie docelowy master lub układ i zweryfikuj wynik po scaleniu.

### **Notatki i komentarze**

Notatki prelegenta i komentarze do slajdów są powiązane z treścią slajdu i są kopiowane przy klonowaniu slajdu. Aspose.Slides udostępnia także dedykowane API dla [presentation notes](https://docs.aspose.com/slides/pl/java/presentation-notes/) i [presentation comments](https://docs.aspose.com/slides/pl/java/presentation-comments/).

Jeśli formatowanie strony z notatkami jest istotne, zweryfikuj połączoną prezentację, ponieważ mastery notatek są obiektami na poziomie prezentacji i mogą różnić się między plikami źródłowymi. W procesach przeglądania zweryfikuj również autorów komentarzy oraz komentarze wątkowe po połączeniu plików od różnych autorów lub szablonów.

### **Obrazy, audio, wideo, obiekty OLE i linki zewnętrzne**

Slajdy mogą odwoływać się do zasobów na poziomie prezentacji, takich jak obrazy, osadzone audio, osadzone wideo i dane OLE. Klonuj sam slajd, a nie tylko jego widoczne kształty, aby Aspose.Slides mógł utrzymać powiązania slajdu z jego zasobami.

Zasoby osadzone i linkowane powinny być traktowane odrębnie. Linkowane audio, wideo, obiekt OLE lub hiperłącze pozostają zależne od zewnętrznego docelowego zasobu; klonowanie slajdu nie zamienia linku zewnętrznego w treść osadzoną. Testuj ścieżki i adresy URL zasobów linkowanych w środowisku, w którym otwierana będzie połączona prezentacja.

Aspose.Slides wyraźnie śledzi automatycznie klonowane mastery, ale nie należy tego traktować jako ogólnej gwarancji, że identyczne zasoby binarne z niepowiązanych prezentacji źródłowych zawsze zostaną odlicowane. Jeśli rozmiar pliku wyjściowego ma znaczenie, sprawdź połączony pakiet i zmierz wynik zamiast polegać na domyślnej deduplikacji.

### **Osadzone czcionki i dostępność czcionek**

Czcionki są zarządzane na poziomie prezentacji. Jeśli typografia ma pozostać spójna między komputerami, nie zakładaj, że samo klonowanie slajdów gwarantuje dostępność każdej wymaganej czcionki w docelowym środowisku. Możesz sprawdzić osadzone czcionki za pomocą [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) i zarządzać ich osadzaniem explicite, jak opisano w [Embed Fonts in Presentations](https://docs.aspose.com/slides/pl/java/embedded-font/).

Sprawdź również, czy masz prawo osadzać czcionki użyte w plikach źródłowych. Licencje czcionek mogą ograniczać osadzanie.

### **Prezentacje zabezpieczone hasłem**

Źródło zabezpieczone hasłem musi zostać poprawnie otwarte, zanim jego slajdy będą mogły być klonowane. Podaj hasło za pomocą [LoadOptions.setPassword](https://reference.aspose.com/slides/pl/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-).

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation source = new Presentation("protected.pptx", loadOptions);
try {
    // Pracuj z odszyfrowaną prezentacją.
} finally {
    source.dispose();
}
```

Otwieranie zaszyfrowanego źródła nie powoduje automatycznego zastosowania tej samej ochrony do docelowej prezentacji. Skonfiguruj ochronę wyjściową oddzielnie, gdy jest wymagana.

### **Duże prezentacje i zużycie pamięci**

Duże prezentacje zawierające obrazy wysokiej rozdzielczości, audio, wideo lub inne duże obiekty binarne mogą zużywać znaczne ilości pamięci. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) zapewnia kontrolę nad obsługą BLOB‑ów i użyciem plików tymczasowych. Zobacz [Manage Presentation BLOBs](https://docs.aspose.com/slides/pl/java/manage-blob/) po strategie dotyczące dużych plików.

W przypadku dużych plików, w miarę możliwości wczytuj z ścieżek plików, zwalniaj każdą źródłową prezentację zaraz po jej scałowaniu i unikaj wielokrotnego zapisywania wyników pośrednich, chyba że proces wymaga punktów kontrolnych.

### **Bezpieczeństwo wątkowe**

Nie wczytuj, nie modyfikuj, nie zapisuj ani nie klonuj tej samej [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) jednocześnie z wielu wątków. Trzymaj każdą instancję prezentacji w ramach jednej operacji scalania. Jeśli równolegle uruchamiasz niezależne zadania, używaj oddzielnych instancji prezentacji i stosuj się do [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/pl/java/multithreading/).

## **FAQ**

**Jak zachować oryginalny projekt każdej prezentacji źródłowej?**

Użyj [`addClone(sourceSlide)`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) bez podawania docelowego mastera lub układu. Aspose.Slides może automatycznie sklonować master źródłowy, gdy jest potrzebny zaimportowanemu slajdowi.

**Jak sprawić, aby zaimportowane slajdy używały docelowego motywu?**

Użyj overloadu, który przyjmuje docelowy master. Przekaż master z docelowej prezentacji, nie ze źródłowej. Aspose.Slides spróbuje dopasować każdy slajd źródłowy do odpowiedniego układu pod tym masterem.

**Kiedy powinienem użyć konkretnego docelowego układu zamiast docelowego mastera?**

Użyj konkretnego układu, gdy każdy zaimportowany slajd ma korzystać z jednego znanego układu. Użyj mastera, gdy chcesz, aby Aspose.Slides wybierał spośród układów tego mastera na podstawie typu lub nazwy układu źródłowego.

**Czy można scalać prezentacje o różnych rozmiarach slajdów?**

Tak, ale zawartość slajdu nie jest automatycznie przekształcana do wymiarów docelowych. Zmniejsz rozmiar źródłowej prezentacji najpierw, gdy potrzebne jest przewidywalne rozmieszczenie, na przykład przy użyciu [SlideSize.setSize](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slidesize/#setSize-float-float-int-) i [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slidesizescaletype/).

**Czy mogę scalić prezentacje PPT, PPTX i ODP w jeden plik?**

Tak. Wczytaj każdą źródłową prezentację, sklonuj wymagane slajdy do jednej docelowej i zapisz cel w obsługiwanym formacie wyjściowym. Ponieważ formaty prezentacji nie obsługują dokładnie tego samego zestawu funkcji, zweryfikuj złożoną treść po scalaniu między formatami. Zobacz [Supported File Formats](https://docs.aspose.com/slides/pl/java/supported-file-formats/).

**Czy sekcje źródłowe są zachowywane automatycznie?**

Nie przy użyciu podstawowej pętli, która tylko klonuje slajdy. Odtwórz wymagane sekcje w docelowej prezentacji i użyj overloadu sekcji [addClone](https://reference.aspose.com/slides/pl/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) gdy struktura sekcji musi być zachowana.

**Czy notatki prelegenta i komentarze są zachowywane?**

Są kopiowane wraz ze sklonowanym slajdem. W procesach zależnych od stylizacji mastera notatek, autorów komentarzy lub danych przeglądu wątkowego, zweryfikuj wynik po scaleniu, ponieważ scenariusze te obejmują struktury na poziomie prezentacji oraz treść slajdu.

**Co się dzieje z audio, wideo, obiektami OLE i hiperłączami?**

Zawartość osadzona jest przenoszona jako część relacji zasobów sklonowanego slajdu. Linki zewnętrzne pozostają zewnętrzne, więc ich docelowe pliki lub adresy URL muszą być nadal dostępne po scaleniu.

**Czy osadzone czcionki ze wszystkich źródeł są gwarantowane w połączonej prezentacji?**

Nie polegaj wyłącznie na klonowaniu slajdów w celu udostępnienia czcionek. Sprawdź osadzone czcionki w docelowej prezentacji i wyraźnie zarządzaj osadzaniem czcionek lub dostępnością czcionek zewnętrznych, gdy typografia jest istotna.

**Jak scalić plik zabezpieczony hasłem?**

Otwórz go przy użyciu właściwego [LoadOptions.setPassword](https://reference.aspose.com/slides/pl/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), a następnie normalnie klonuj jego slajdy. Ochrona wyjściowa jest konfigurowana oddzielnie.

**Jak powinienem obsługiwać bardzo duże prezentacje?**

Używaj zarządzania BLOB‑ami, gdy duże obiekty binarne dominują zużycie pamięci, preferuj wczytywanie z ścieżek plików dla bardzo dużych plików, szybko zwalniaj źródłowe prezentacje i zapisuj końcowy wynik tylko w razie potrzeby.

**Czy mogę scalać slajdy z wielu wątków?**

Nie używaj jednej [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) jednocześnie w wielu wątkach. Trzymaj każdą operację scalania izolowaną w własnych instancjach prezentacji.