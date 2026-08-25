---
title: Efektywne scalanie prezentacji w .NET
linktitle: Scalanie prezentacji
type: docs
weight: 40
url: /pl/net/merge-presentation/
keywords:
- scal PowerPoint
- scal prezentacje
- scal slajdy
- scal PPT
- scal PPTX
- scal ODP
- łącz PowerPoint
- łącz prezentacje
- łącz slajdy
- łącz PPT
- łącz PPTX
- łącz ODP
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak scalać prezentacje PowerPoint i OpenDocument w .NET, klonując slajdy, kontrolując mastery i układy, zmieniając rozmiar zawartości slajdów, zachowując sekcje oraz obsługując chronione lub duże pliki."
---
## **Przegląd**

Aspose.Slides for .NET scala prezentacje, kopiując slajdy z jednej [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) do drugiej. Główną operacją jest [ISlideCollection.AddClone](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection/addclone/), która może zachować formatowanie źródłowego slajdu lub dołączyć sklonowany slajd do mastera lub układu w docelowej prezentacji.

Ten artykuł opisuje najczęstsze scenariusze scalania:

- scalenie wszystkich slajdów przy zachowaniu ich źródłowego formatowania;
- scalenie wybranych slajdów;
- zastosowanie mastera z docelowej prezentacji;
- zastosowanie konkretnego układu z docelowej prezentacji;
- normalizacja różnych rozmiarów slajdów przed scaleniem;
- dodanie sklonowanych slajdów do sekcji;
- scalenie kilku prezentacji w jednym kompleksowym przepływie pracy;
- obsługa masterów, zasobów, notatek, komentarzy, multimediów, czcionek, haseł, dużych plików i kwestii wielowątkowości.

## **Jak klonowanie slajdów wpływa na mastery i układy**

Slajd dziedziczy dużą część swojego wyglądu z układu i mastera. Z tego powodu wybrany przeciążony wariant klonowania określa, w jaki sposób scalony slajd zostanie zintegrowany z docelową prezentacją.

Użyj [ISlideCollection.AddClone](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection/addclone/) w jeden z następujących sposobów:

- `AddClone(sourceSlide)` — zachowuje układ i formatowanie źródłowego slajdu. W razie potrzeby źródłowy master może zostać automatycznie sklonowany do prezentacji docelowej. Aspose.Slides śledzi automatycznie sklonowane mastery, aby powtarzające się slajdy korzystające z tego samego mastera nie powodowały wielokrotnego klonowania tego mastera.
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — dołącza sklonowany slajd do konkretnego docelowego [IMasterSlide](https://reference.aspose.com/slides/pl/net/aspose.slides/imasterslide/). Aspose.Slides szuka pasującego układu pod tym masterem według typu lub nazwy układu.
- `AddClone(sourceSlide, destinationLayout)` — dołącza sklonowany slajd bezpośrednio do konkretnego docelowego [ILayoutSlide](https://reference.aspose.com/slides/pl/net/aspose.slides/ilayoutslide/).

Master lub układ przekazany do przeciążenia `AddClone` musi należeć do **docelowej** prezentacji, a nie do prezentacji źródłowej.

## **Scal całe prezentacje i zachowaj formatowanie źródłowe**

Najprostsze scalanie kopiuję każdy slajd z prezentacji źródłowej do prezentacji docelowej. To właściwy wybór, gdy zaimportowane slajdy powinny zachować oryginalną tematykę, master i powiązania układów.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide);
}

destination.Save("merged.pptx", SaveFormat.Pptx);
```

W powstałej prezentacji może znajdować się wiele masterów, gdy źródło i cel używają różnych projektów. Jest to oczekiwane, gdy formatowanie źródłowe jest zachowywane celowo.

## **Scal wybrane slajdy**

Nie musisz klonować każdego slajdu. Poniższy przykład importuje tylko wybrane indeksy slajdów ze źródłowej prezentacji.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var slideIndexes = new[] { 0, 2, 4 };

foreach (var index in slideIndexes)
{
    destination.Slides.AddClone(source.Slides[index]);
}

destination.Save("merged-selected-slides.pptx", SaveFormat.Pptx);
```

Zweryfikuj indeksy slajdów przed klonowaniem, gdy pochodzą od użytkownika lub z zewnętrznej konfiguracji.

## **Scal slajdy przy użyciu docelowego mastera**

Użyj przeciążenia [AddClone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection/addclone/), gdy zaimportowane slajdy mają korzystać z mastera, który już należy do prezentacji docelowej.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var destinationMaster = destination.Masters[0];

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, destinationMaster, allowCloneMissingLayout: true);
}

destination.Save("merged-with-destination-master.pptx", SaveFormat.Pptx);
```

Aspose.Slides wybiera odpowiedni układ pod wskazanym masterem, dopasowując typ lub nazwę układu źródłowego. Jeśli nie istnieje pasujący układ i `allowCloneMissingLayout` jest `true`, układ źródłowy jest klonowany, aby slajd mógł zostać dodany. Jeśli jest `false`, wyrzucany jest [PptxEditException](https://reference.aspose.com/slides/pl/net/aspose.slides/pptxeditexception/).

Użyj `false`, gdy chcesz, aby scalenie zakończyło się błędem zamiast wprowadzania dodatkowego układu do docelowego mastera.

## **Scal slajdy przy użyciu konkretnego docelowego układu**

Użyj przeciążenia [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection/addclone/), gdy dokładnie wiesz, którego układu docelowego mają używać zaimportowane slajdy.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var destinationLayout = destination.LayoutSlides[0];

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, destinationLayout);
}

destination.Save("merged-with-destination-layout.pptx", SaveFormat.Pptx);
```

Zastosowanie docelowego układu zmienia odziedziczoną relację układu; nie redesignuje treści slajdu źródłowego. Jeśli układy źródłowy i docelowy mają różne struktury placeholderów, sprawdź wynik, aby potwierdzić, że odziedziczone formatowanie i zachowanie placeholderów są właściwe.

## **Scal prezentacje o różnych rozmiarach slajdów**

Prezentacje o różnych wymiarach slajdów mogą być scalane, ale klonowanie slajdu do prezentacji o innym rozmiarze nie redesignuje automatycznie jego zawartości dla nowego płótna. Kształty mogą więc zostać przemieszone, nieoczekiwanie skalowane lub znajdować się poza widoczną powierzchnią slajdu.

Praktycznym podejściem jest zmiana rozmiaru prezentacji źródłowej przed klonowaniem. Metoda [SlideSize.SetSize](https://reference.aspose.com/slides/pl/net/aspose.slides/slidesize/setsize/) może skalować istniejącą zawartość przy zmianie wymiarów slajdu. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/pl/net/aspose.slides/slidesizescaletype/) skaluje zawartość, aby dopasować ją do żądanego rozmiaru.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

if (source.SlideSize.Size.Width != destination.SlideSize.Size.Width || 
    source.SlideSize.Size.Height != destination.SlideSize.Size.Height)
{
    source.SlideSize.SetSize(
        destination.SlideSize.Size.Width, 
        destination.SlideSize.Size.Height, 
        SlideSizeScaleType.EnsureFit);
}

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide);
}

destination.Save("merged-same-slide-size.pptx", SaveFormat.Pptx);
```

Zmiana rozmiaru modyfikuje obiekt prezentacji źródłowej w pamięci. Jeśli potrzebujesz niezmienionej oryginalnej prezentacji źródłowej do innych operacji, otwórz osobną instancję do scalania.

## **Scal slajdy do sekcji prezentacji**

Podstawowa pętla klonowania slajdów nie odtwarza hierarchii sekcji prezentacji źródłowej. Jeśli sekcje mają znaczenie w wyniku, utwórz lub wybierz sekcje w prezentacji docelowej i klonuj slajdy do nich wyraźnie za pomocą [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection/addclone/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var importedSection = destination.Sections.AppendEmptySection("Imported slides");

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, importedSection);
}

destination.Save("merged-with-section.pptx", SaveFormat.Pptx);
```

Sklonowane slajdy są dołączane do określonej sekcji docelowej. Aby zachować kilka sekcji źródłowych, wylicz [Presentation.Sections](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/sections/), pobierz aktualne slajdy każdej sekcji źródłowej za pomocą [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/pl/net/aspose.slides/isection/getslideslistofsection/), odtwórz sekcje w docelowej prezentacji i klonuj każdy zwrócony slajd do odpowiadającej mu sekcji docelowej. Zobacz [Manage Slide Sections](/slides/pl/net/slide-section/) po kompletny przykład enumeracji sekcji, w tym sekcje puste i zmiany strukturalne.

## **Scal wiele prezentacji bezpiecznie**

Poniższy przykład end‑to‑end używa pierwszej prezentacji jako docelowej, normalizuje rozmiar slajdu każdej dodatkowej prezentacji źródłowej, trzyma każdą prezentację otwartą tylko w czasie kopiowania i zapisuje finalny plik raz.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var inputFiles = new[] { "part1.pptx", "part2.pptx", "part3.pptx" };

using var merged = new Presentation(inputFiles[0]);

for (var fileIndex = 1; fileIndex < inputFiles.Length; fileIndex++)
{
    using var source = new Presentation(inputFiles[fileIndex]);

    if (source.SlideSize.Size.Width != merged.SlideSize.Size.Width || 
        source.SlideSize.Size.Height != merged.SlideSize.Size.Height)
    {
        source.SlideSize.SetSize(
            merged.SlideSize.Size.Width, 
            merged.SlideSize.Size.Height, 
            SlideSizeScaleType.EnsureFit);
    }

    foreach (var slide in source.Slides)
    {
        merged.Slides.AddClone(slide);
    }
}

merged.Save("merged.pptx", SaveFormat.Pptx);
```

Jest to przydatna baza do zachowania formatowania źródłowego zaimportowanych slajdów. Jeśli wynik ma używać jednego motywu docelowego, zastąp proste wywołanie `AddClone(slide)` odpowiednim przeciążeniem mastera lub układu docelowego pokazanym wcześniej.

## **Praktyczne uwagi**

### **Mastery, układy i wierność formatowania**

Domyślne klonowanie slajdów może automatycznie przenieść wymagany master źródłowy do prezentacji docelowej. Aspose.Slides utrzymuje wewnętrzny rejestr automatycznie sklonowanych masterów, aby uniknąć wielokrotnego klonowania tego samego mastera. Ręcznie sklonowane mastery nie są śledzone przez ten rejestr, więc unikaj wstępnego klonowania masterów, chyba że potrzebujesz wyraźnej kontroli nad strukturą mastera.

Nie zakładaj, że dwa mastery lub układy o tej samej nazwie są wizualnie równoważne. Jeśli korporacyjny szablon ma kontrolować ostateczny wygląd, wybierz wyraźnie master lub układ docelowy i zweryfikuj wynik po scaleniu.

### **Notatki i komentarze**

Notatki prelegenta i komentarze slajdów są powiązane z zawartością slajdu i są kopiowane przy klonowaniu slajdu. Aspose.Slides udostępnia także dedykowane API dla [presentation notes](/slides/pl/net/presentation-notes/) i [presentation comments](/slides/pl/net/presentation-comments/).

Jeśli formatowanie strony notatek jest istotne, zweryfikuj scaloną prezentację, ponieważ mastery notatek są obiektami poziomu prezentacji i mogą różnić się między plikami źródłowymi. W procesach przeglądu sprawdzaj również autorów komentarzy i wątki komentarzy po połączeniu plików od różnych autorów lub szablonów.

### **Obrazy, audio, wideo, obiekty OLE i linki zewnętrzne**

Slajdy mogą odwoływać się do zasobów poziomu prezentacji, takich jak obrazy, osadzone audio, osadzone wideo i dane OLE. Klonuj sam slajd zamiast kopiować tylko widoczne kształty, aby Aspose.Slides mógł utrzymać zależności slajdu do jego zasobów.

Zasoby osadzone i linkowane należy traktować odrębnie. Linkowany audio, wideo, obiekt OLE lub hiperlink pozostaje zależny od zewnętrznego celu; klonowanie slajdu nie zamienia linku zewnętrznego w treść osadzoną. Testuj ścieżki i adresy URL zasobów linkowanych w środowisku, w którym otwierana będzie scalona prezentacja.

Aspose.Slides wyraźnie śledzi automatycznie sklonowane mastery, ale nie należy tego traktować jako ogólnej gwarancji, że identyczne zasoby binarne z niepowiązanych prezentacji źródłowych zawsze zostaną zduplikowane. Jeśli rozmiar pliku wyjściowego jest istotny, przeanalizuj scalony pakiet i zmierz wynik zamiast polegać na domyślnym deduplikowaniu.

### **Czcionki wbudowane i dostępność czcionek**

Czcionki są zarządzane na poziomie prezentacji. Jeśli typografia ma pozostać spójna na różnych maszynach, nie zakładaj, że klonowanie slajdów samo w sobie zapewni dostępność każdej wymaganej czcionki w środowisku docelowym. Możesz sprawdzić wbudowane czcionki za pomocą [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/pl/net/aspose.slides/fontsmanager/getembeddedfonts/) i zarządzać osadzaniem explicite, jak opisano w [Embed Fonts in Presentations](/slides/pl/net/embedded-font/).

Również zweryfikuj, czy masz prawo do osadzania czcionek używanych w plikach źródłowych. Licencje czcionek mogą ograniczać ich osadzanie.

### **Prezentacje chronione hasłem**

Źródło chronione hasłem musi zostać pomyślnie otwarte, zanim jego slajdy będą mogły być klonowane. Podaj hasło poprzez [LoadOptions.Password](https://reference.aspose.com/slides/pl/net/aspose.slides/loadoptions/password/).

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "YOUR_PASSWORD" };

using var source = new Presentation("protected.pptx", loadOptions);
```

Otwarcie zaszyfrowanego źródła nie nakłada automatycznie takiej samej ochrony na prezentację docelową. Ochronę wyjściową konfiguruj osobno, gdy jest wymagana.

### **Duże prezentacje i wykorzystanie pamięci**

Duże prezentacje zawierające obrazy wysokiej rozdzielczości, audio, wideo lub inne duże obiekty binarne mogą zużywać znaczną ilość pamięci. [LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/pl/net/aspose.slides/loadoptions/blobmanagementoptions/) zapewnia kontrolę nad obsługą BLOB‑ów i użyciem plików tymczasowych. Zobacz [Manage Presentation BLOBs](/slides/pl/net/manage-blob/) po strategie dla dużych plików.

W przypadku dużych plików, kiedy to możliwe, preferuj ładowanie z ścieżek plików, zwalniaj każdą prezentację źródłową natychmiast po scaleniu i unikaj wielokrotnego zapisywania wyników pośrednich, chyba że przepływ pracy wymaga punktów kontrolnych.

### **Bezpieczeństwo wątków**

Nie ładuj, nie modyfikuj, nie zapisuj ani nie klonuj tej samej [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) jednocześnie z wielu wątków. Trzymaj każdą instancję prezentacji w ramach jednej operacji scalania. Jeśli równolegle przetwarzasz niezależne zadania, używaj odrębnych instancji prezentacji i stosuj się do wytycznych [Aspose.Slides multithreading guidance](/slides/pl/net/multithreading/).

## **FAQ**

**Jak zachować oryginalny projekt każdej prezentacji źródłowej?**

Użyj [AddClone](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection/addclone/) bez podawania mastera lub układu docelowego. Aspose.Slides może automatycznie sklonować master źródłowy, gdy jest wymagany przez importowany slajd.

**Jak sprawić, aby zaimportowane slajdy używały docelowego motywu?**

Użyj przeciążenia, które akceptuje master docelowy. Przekaż master z prezentacji docelowej, nie ze źródłowej. Aspose.Slides spróbuje dopasować każdy slajd źródłowy do odpowiedniego układu pod tym masterem.

**Kiedy używać konkretnego układu docelowego zamiast mastera docelowego?**

Użyj konkretnego układu, gdy każdy importowany slajd ma korzystać z jednego znanego układu. Użyj mastera, gdy chcesz, aby Aspose.Slides wybierał spośród układów tego mastera na podstawie typu lub nazwy układu źródłowego.

**Czy prezentacje o różnych rozmiarach slajdów mogą być scalane?**

Tak, ale zawartość slajdu nie jest automatycznie redesignowana pod nowe wymiary. Najpierw zmień rozmiar prezentacji źródłowej, np. przy użyciu [SlideSize.SetSize](https://reference.aspose.com/slides/pl/net/aspose.slides/slidesize/setsize/) i [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/pl/net/aspose.slides/slidesizescaletype/).

**Czy mogę scalić pliki PPT, PPTX i ODP w jeden plik?**

Tak. Załaduj każdą prezentację źródłową, sklonuj potrzebne slajdy do jednej prezentacji docelowej i zapisz ją w obsługiwanym formacie wyjściowym. Ponieważ formaty prezentacji nie obsługują dokładnie tego samego zestawu funkcji, po scaleniu międzyformatowym sprawdź złożoną zawartość. Zobacz [Supported File Formats](/slides/pl/net/supported-file-formats/).

**Czy sekcje źródłowe są zachowywane automatycznie?**

Nie w podstawowej pętli, która tylko klonuje slajdy. Utwórz wymagane sekcje w prezentacji docelowej i użyj przeciążenia sekcji [AddClone](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection/addclone/), gdy struktura sekcji musi być zachowana.

**Czy notatki prelegenta i komentarze są zachowywane?**

Są kopiowane wraz ze sklonowanym slajdem. W przepływach zależnych od stylizacji mastera notatek, autorów komentarzy lub danych przeglądu wątkowego, zweryfikuj scalony wynik, ponieważ scenariusze te obejmują struktury na poziomie prezentacji oraz zawartość slajdów.

**Co się dzieje z audio, wideo, obiektami OLE i hiperłączami?**

Zawartość osadzona jest przenoszona jako część relacji zasobów sklonowanego slajdu. Linki zewnętrzne pozostają zewnętrzne, więc ich docelowe pliki lub adresy URL muszą być nadal dostępne po scaleniu.

**Czy wbudowane czcionki ze wszystkich źródeł są gwarantowane w scalonej prezentacji?**

Nie polegaj wyłącznie na klonowaniu slajdów w kwestii wdrażania czcionek. Sprawdź wbudowane czcionki w prezentacji docelowej i zarządzaj ich osadzaniem lub dostępnością czcionek zewnętrznych, gdy typografia jest istotna.

**Jak scalić plik chroniony hasłem?**

Otwórz go z prawidłowym [LoadOptions.Password](https://reference.aspose.com/slides/pl/net/aspose.slides/loadoptions/password/), a następnie normalnie klonuj jego slajdy. Ochronę wyjściową konfiguruje się osobno.

**Jak postępować z bardzo dużymi prezentacjami?**

Używaj zarządzania BLOB, gdy duże obiekty binarne dominują użycie pamięci, preferuj ładowanie z ścieżek plików dla bardzo dużych plików, szybko zwalniaj prezentacje źródłowe po ich scaleniu i zapisuj wynik końcowy tylko wtedy, gdy jest to konieczne.

**Czy mogę scalac slajdy z wielu wątków?**

Nie używaj jednej instancji [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) jednocześnie w wielu wątkach. Trzymaj każdą operację scalania w oddzielnych instancjach prezentacji.