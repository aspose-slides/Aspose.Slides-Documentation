---
title: Efektywne łączenie prezentacji na Androidzie
linktitle: Łączenie prezentacji
type: docs
weight: 40
url: /pl/androidjava/merge-presentation/
keywords:
- scalanie PowerPoint
- scalanie prezentacji
- scalanie slajdów
- scalanie PPT
- scalanie PPTX
- scalanie ODP
- łączenie PowerPoint
- łączenie prezentacji
- łączenie slajdów
- łączenie PPT
- łączenie PPTX
- łączenie ODP
- Android
- Java
- Aspose.Slides
description: Dowiedz się, jak na Androidzie scalać prezentacje PowerPoint i OpenDocument, klonując slajdy, kontrolując mastery i układy, zmieniając rozmiar treści slajdów, zachowując sekcje oraz obsługując zabezpieczone lub duże pliki.
---
## **Przegląd**

Aspose.Slides for Android via Java łączy prezentacje, kopiując slajdy z jednej [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) do drugiej. Główną operacją jest [ISlideCollection.addClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-), która może zachować formatowanie źródłowego slajdu lub dołączyć sklonowany slajd do mastera lub układu w prezentacji docelowej.

W tym artykule omówiono najczęstsze scenariusze scalania:

- scalenie wszystkich slajdów przy zachowaniu formatowania źródłowego;
- scalenie wybranych slajdów;
- zastosowanie mastera z prezentacji docelowej;
- zastosowanie określonego układu z prezentacji docelowej;
- normalizacja różnych rozmiarów slajdów przed scalaniem;
- dodanie sklonowanych slajdów do sekcji;
- scalenie kilku prezentacji w jednym procesie end‑to‑end;
- obsługa masterów, zasobów, notatek, komentarzy, multimediów, czcionek, haseł, dużych plików i zagadnień związanych z wielowątkowością.

## **Jak klonowanie slajdów wpływa na mastery i układy**

Slajd dziedziczy dużą część wyglądu z układu i mastera. Z tego powodu wybrany przeciążony sposób klonowania określa, jak scalony slajd zostanie włączony do prezentacji docelowej.

Użyj [ISlideCollection.addClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islidecollection/) w jednej z następujących form:

- `addClone(sourceSlide)` — zachowuje układ i formatowanie źródłowego slajdu. W razie potrzeby źródłowy master może być automatycznie sklonowany do prezentacji docelowej. Aspose.Slides śledzi automatycznie sklonowane mastery, aby powtarzające się slajdy korzystające z tego samego mastera nie powodowały wielokrotnego klonowania.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — dołącza sklonowany slajd do określonego [IMasterSlide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imasterslide/). Aspose.Slides szuka pasującego układu pod tym masterem według typu lub nazwy układu.
- `addClone(sourceSlide, destinationLayout)` — dołącza sklonowany slajd bezpośrednio do określonego [ILayoutSlide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilayoutslide/).

Master lub układ przekazany do przeciążenia `addClone` musi należeć do **prezentacji docelowej**, a nie do źródłowej.

## **Scalanie całych prezentacji i zachowanie formatowania źródłowego**

Najprostsze scalenie kopiowanie każdego slajdu ze źródłowej prezentacji do docelowej. Jest to właściwy wybór, gdy importowane slajdy powinny zachować oryginalny motyw, master i powiązania układu.

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

W rezultacie prezentacja może zawierać wiele masterów, gdy źródło i cel używają różnych projektów. Jest to oczekiwane, gdy formatowanie źródłowe jest zachowywane świadomie.

## **Scalanie wybranych slajdów**

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

Sprawdzaj indeksy slajdów przed klonowaniem, gdy pochodzą one od użytkownika lub z zewnętrznej konfiguracji.

## **Scalanie slajdów przy użyciu mastera docelowego**

Użyj przeciążenia [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) gdy importowane slajdy mają korzystać z mastera, który już należy do prezentacji docelowej.

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

Aspose.Slides wybiera odpowiedni układ pod wskazanym masterem, dopasowując typ lub nazwę układu źródłowego. Jeśli nie istnieje odpowiedni układ i `allowCloneMissingLayout` jest `true`, układ źródłowy zostaje sklonowany, aby slajd mógł zostać dodany. Jeśli jest `false`, zostaje rzucony [PptxEditException](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pptxeditexception/).

Ustaw `false`, gdy chcesz, aby scalenie zakończyło się niepowodzeniem zamiast wprowadzania dodatkowego układu do mastera docelowego.

## **Scalanie slajdów przy użyciu określonego układu docelowego**

Użyj przeciążenia [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) gdy dokładnie wiesz, którego układu docelowego mają używać importowane slajdy.

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

Zastosowanie układu docelowego zmienia odziedziczoną relację układu; nie przekształca treści slajdu źródłowego. Jeśli układy źródłowy i docelowy mają różne struktury placeholderów, sprawdź wynik, aby potwierdzić, że odziedziczone formatowanie i zachowanie placeholderów są odpowiednie.

## **Scalanie prezentacji o różnych rozmiarach slajdów**

Prezentacje o różnych wymiarach slajdów można scalać, ale klonowanie slajdu do prezentacji o innym rozmiarze nie przekształca automatycznie jego zawartości do nowego płótna. Dlatego kształty mogą być przesunięte, niespodziewanie skalowane lub znajdować się poza widoczną częścią slajdu.

Praktycznym podejściem jest zmiana rozmiaru prezentacji źródłowej przed klonowaniem. Metoda [SlideSize.setSize](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) może skalować istniejącą zawartość przy jednoczesnej zmianie wymiarów slajdu. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slidesizescaletype/) skaluje zawartość, aby dopasować ją do żądanego rozmiaru.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    SizeF sourceSize = source.getSlideSize().getSize();
    SizeF destinationSize = destination.getSlideSize().getSize();

    if (sourceSize.getWidth() != destinationSize.getWidth() || 
        sourceSize.getHeight() != destinationSize.getHeight()) {
        source.getSlideSize().setSize(
            destinationSize.getWidth(), 
            destinationSize.getHeight(), 
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

Zmiana rozmiaru modyfikuje obiekt prezentacji źródłowej w pamięci. Jeśli potrzebujesz niezmienionej wersji źródłowej dla innych operacji, otwórz osobną instancję na czas scalania.

## **Scalanie slajdów do sekcji prezentacji**

Podstawowa pętla klonowania slajdów nie odtwarza hierarchii sekcji źródłowej prezentacji. Jeśli sekcje mają znaczenie w wyniku, utwórz lub wybierz sekcje w prezentacji docelowej i klonuj slajdy do nich explicite przy użyciu [addClone(ISlide, ISection)](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-).

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

Sklonowane slajdy są dołączane do określonej sekcji docelowej. Aby zachować wiele sekcji źródłowych, wylicz [Presentation.getSections](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#getSections--), pobierz bieżące slajdy każdej sekcji źródłowej za pomocą [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--), odtwórz sekcje w docelowej prezentacji i sklonuj każdy zwrócony slajd do odpowiadającej sekcji docelowej. Zobacz [Manage Slide Sections](/slides/pl/androidjava/slide-section/) po kompletny przykład enumeracji sekcji, w tym sekcje puste i zmiany strukturalne.

## **Bezpieczne scalanie wielu prezentacji**

Poniższy przykład end‑to‑end używa pierwszej prezentacji jako docelowej, normalizuje rozmiar slajdu każdej dodatkowej źródłowej, utrzymuje każdą źródłową otwartą tylko podczas kopiowania i zapisuje ostateczny plik jednorazowo.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

String[] inputFiles = { "part1.pptx", "part2.pptx", "part3.pptx" };

Presentation merged = new Presentation(inputFiles[0]);
try {
    SizeF mergedSize = merged.getSlideSize().getSize();

    for (int fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        Presentation source = new Presentation(inputFiles[fileIndex]);
        try {
            SizeF sourceSize = source.getSlideSize().getSize();

            if (sourceSize.getWidth() != mergedSize.getWidth() || 
                sourceSize.getHeight() != mergedSize.getHeight()) {
                source.getSlideSize().setSize(
                    mergedSize.getWidth(), 
                    mergedSize.getHeight(), 
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

Jest to przydatna baza do zachowania formatowania źródłowego importowanych slajdów. Jeśli wynikowa prezentacja ma używać jednego motywu docelowego, zastąp prostą wywołanie `addClone(slide)` odpowiednim przeciążeniem mastera lub układu docelowego, przedstawionym wcześniej.

## **Praktyczne uwagi**

### **Mastery, układy i wierność formatowania**

Domyślne klonowanie slajdów może automatycznie przenieść wymagany master źródłowy do prezentacji docelowej. Aspose.Slides utrzymuje wewnętrzny rejestr automatycznie sklonowanych masterów, aby uniknąć wielokrotnego klonowania tego samego mastera. Mastery sklonowane ręcznie nie są rejestrowane, więc unikaj wstępnego klonowania masterów, chyba że potrzebna jest pełna kontrola nad strukturą mastera.

Nie zakładaj, że dwa mastery lub układy o tej samej nazwie są wizualnie równoważne. Jeśli szablon korporacyjny musi kontrolować ostateczny wygląd, wybierz wyraźnie master lub układ docelowy i zweryfikuj rezultat po scaleniu.

### **Notatki i komentarze**

Notatki prelegenta i komentarze slajdów są powiązane z treścią slajdu i kopiowane przy klonowaniu. Aspose.Slides udostępnia także dedykowane API dla [presentation notes](/slides/pl/androidjava/presentation-notes/) i [presentation comments](/slides/pl/androidjava/presentation-comments/).

Jeśli formatowanie strony notatek jest istotne, zweryfikuj scaloną prezentację, ponieważ mastery notatek są obiektami poziomu prezentacji i mogą się różnić pomiędzy plikami źródłowymi. W procesach przeglądu sprawdzaj także autorów komentarzy oraz wątki komentarzy po połączeniu plików od różnych autorów lub szablonów.

### **Obrazy, dźwięk, wideo, obiekty OLE i linki zewnętrzne**

Slajdy mogą odwoływać się do zasobów poziomu prezentacji, takich jak obrazy, osadzone dźwięki, wideo i dane OLE. Klonuj cały slajd, a nie tylko widoczne kształty, aby Aspose.Slides mógł zachować zależności slajdu do zasobów.

Zasoby osadzone i linkowane należy traktować inaczej. Linkowany dźwięk, wideo, obiekt OLE lub hiperłącze pozostaje zależny od zewnętrznego docelowego pliku; klonowanie slajdu nie zamienia linku zewnętrznego w treść osadzoną. Testuj ścieżki i adresy URL zasobów linkowanych w środowisku, w którym otwierana będzie scalona prezentacja.

Aspose.Slides śledzi automatycznie sklonowane mastery, ale nie należy tego traktować jako ogólnej gwarancji, że identyczne zasoby binarne z niepowiązanych prezentacji będą zawsze deduplikowane. Jeśli rozmiar pliku wyjściowego jest istotny, przeanalizuj pakiet wynikowy i zmierz rozmiar zamiast polegać na domyślnej deduplikacji.

### **Osadzone czcionki i ich dostępność**

Czcionki zarządzane są na poziomie prezentacji. Jeśli typografia ma pozostać spójna na różnych maszynach, nie zakładaj, że samodzielne klonowanie slajdów zapewnia dostępność wszystkich wymaganych czcionek w środowisku docelowym. Możesz sprawdzić osadzone czcionki przy pomocy [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) i zarządzać osadzaniem tak, jak opisano w [Embed Fonts in Presentations](/slides/pl/androidjava/embedded-font/).

Sprawdź także, czy masz prawo do osadzania czcionek użytych w plikach źródłowych. Licencje czcionek mogą ograniczać ich osadzanie.

### **Prezentacje zabezpieczone hasłem**

Źródło zabezpieczone hasłem musi zostać pomyślnie otwarte, zanim jego slajdy będą mogły zostać sklonowane. Hasło podaje się przez [LoadOptions.setPassword](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-).

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

Otworzenie zaszyfrowanego źródła nie powoduje automatycznego zastosowania tej samej ochrony do prezentacji docelowej. Ochronę wyjściową konfiguruje się oddzielnie, gdy jest wymagana.

### **Duże prezentacje i zużycie pamięci**

Duże prezentacje zawierające obrazy wysokiej rozdzielczości, dźwięk, wideo lub inne duże obiekty binarne mogą znacząco obciążać pamięć. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) udostępnia kontrolę nad obsługą BLOB‑ów i użyciem plików tymczasowych. Zobacz [Manage Presentation BLOBs](/slides/pl/androidjava/manage-blob/) po strategie dla dużych plików.

W przypadku dużych plików w miarę możliwości ładuj je z ścieżek plików, zwalniaj każdą prezentację źródłową natychmiast po jej scalceniu i unikaj wielokrotnego zapisywania wyników pośrednich, chyba że przepływ wymaga punktów kontrolnych.

### **Bezpieczeństwo wątków**

Nie ładuj, nie modyfikuj, nie zapisuj ani nie klonuj tej samej instancji [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) jednocześnie z wielu wątków. Trzymaj każdą instancję prezentacji w obrębie jednej operacji scalania. Jeśli równolegle przetwarzasz niezależne zadania, używaj odrębnych instancji prezentacji i stosuj wytyczne [Aspose.Slides multithreading guidance](/slides/pl/androidjava/multithreading/).

## **FAQ**

**Jak zachować oryginalny projekt każdej prezentacji źródłowej?**

Użyj [addClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) bez podawania mastera lub układu docelowego. Aspose.Slides może automatycznie sklonować master źródłowy, gdy jest wymagany przez importowany slajd.

**Jak sprawić, by importowane slajdy używały motywu docelowego?**

Użyj przeciążenia przyjmującego master docelowy. Przekaż master z prezentacji docelowej, a nie ze źródłowej. Aspose.Slides spróbuje dopasować każdy slajd źródłowy do odpowiedniego układu pod tym masterem.

**Kiedy używać określonego układu docelowego zamiast mastera?**

Użyj konkretnego układu, gdy każdy importowany slajd ma korzystać z jednego znanego układu. Użyj mastera, gdy chcesz, aby Aspose.Slides wybrał układ spośród dostępnych w tym masterze na podstawie typu lub nazwy układu źródłowego.

**Czy można scalać prezentacje o różnych rozmiarach slajdów?**

Tak, ale zawartość slajdu nie jest automatycznie przekształcana do nowych wymiarów. Najpierw zmień rozmiar prezentacji źródłowej, np. przy pomocy [SlideSize.setSize](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) i [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slidesizescaletype/).

**Czy mogę scalać pliki PPT, PPTX i ODP w jeden plik?**

Tak. Załaduj każdą prezentację źródłową, sklonuj wymagane slajdy do jednej prezentacji docelowej i zapisz ją w obsługiwanym formacie wyjściowym. Ponieważ formaty prezentacji nie obsługują dokładnie tego samego zestawu funkcji, po połączeniach między formatami sprawdź złożoną treść. Zobacz [Supported File Formats](/slides/pl/androidjava/supported-file-formats/).

**Czy sekcje źródłowe są zachowywane automatycznie?**

Nie, w podstawowej pętli klonującej tylko slajdy. Aby zachować struktury sekcji, odtwórz wymagane sekcje w prezentacji docelowej i użyj przeciążenia sekcji [addClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-), gdy struktura sekcji musi być utrzymana.

**Czy notatki prelegenta i komentarze są zachowywane?**

Są kopiowane wraz ze sklonowanym slajdem. W przepływach zależnych od stylizacji mastera notatek, autorów komentarzy lub wątków przeglądowych zweryfikuj wynik, ponieważ scenariusze te obejmują struktury poziomu prezentacji oraz treść slajdu.

**Co się dzieje z dźwiękiem, wideo, obiektami OLE i hyperlinkami?**

Zawartość osadzona jest przenoszona jako część relacji zasobów sklonowanego slajdu. Linki zewnętrzne pozostają zewnętrzne, więc ich docelowe pliki lub adresy URL muszą być nadal dostępne po scaleniu.

**Czy osadzone czcionki ze wszystkich źródeł są gwarantowane w scalonej prezentacji?**

Nie polegaj wyłącznie na klonowaniu slajdów w celu wdrożenia czcionek. Sprawdź osadzone czcionki w docelowej prezentacji i zarządzaj ich osadzaniem lub dostępnością zewnętrzną, gdy typografia jest istotna.

**Jak scalać plik zabezpieczony hasłem?**

Otwórz go przy użyciu odpowiedniego [LoadOptions.setPassword](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), a następnie normalnie klonuj jego slajdy. Ochronę wyjściową konfiguruje się osobno.

**Jak radzić sobie z bardzo dużymi prezentacjami?**

Używaj zarządzania BLOB‑ami, gdy duże obiekty binarne dominują zużycie pamięci, preferuj ładowanie z ścieżek plików dla bardzo dużych plików, szybko zwalniaj prezentacje źródłowe i zapisuj wynik końcowy dopiero wtedy, gdy jest to konieczne.

**Czy mogę scalać slajdy z wielu wątków?**

Nie używaj tej samej instancji [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) jednocześnie w wielu wątkach. Każdą operację scalania izoluj w oddzielnych instancjach prezentacji.