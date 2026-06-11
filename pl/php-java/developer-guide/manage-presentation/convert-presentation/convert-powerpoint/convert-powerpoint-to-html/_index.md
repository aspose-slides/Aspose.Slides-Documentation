---
title: Konwertuj prezentacje PowerPoint do HTML w PHP
linktitle: PowerPoint do HTML
type: docs
weight: 30
url: /pl/php-java/convert-powerpoint-to-html/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- konwertuj slajd
- konwertuj PPT
- konwertuj PPTX
- PowerPoint do HTML
- prezentacja do HTML
- slajd do HTML
- PPT do HTML
- PPTX do HTML
- zapisz PowerPoint jako HTML
- zapisz prezentację jako HTML
- zapisz slajd jako HTML
- zapisz PPT jako HTML
- zapisz PPTX jako HTML
- eksportuj PPT do HTML
- eksportuj PPTX do HTML
- PHP
- Aspose.Slides
description: "Konwertuj prezentacje PowerPoint do HTML w PHP. Użyj Aspose.Slides do eksportu plików PPT i PPTX, wybranych slajdów, notatek, czcionek, obrazów, SVG i multimediów."
---
## **Przegląd**

Aspose.Slides for PHP via Java może zapisywać prezentacje PowerPoint jako HTML bez Microsoft PowerPoint. Podstawowa konwersja polega na jednorazowym wczytaniu [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) i wywołaniu `save` z [SaveFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/saveformat/). Użyj [HtmlOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/htmloptions/), gdy potrzebujesz kontrolować eksportowany układ, czcionki, obrazy, notatki, komentarze, wyjście SVG lub powiązane zasoby.

Ten przewodnik koncentruje się na praktycznych scenariuszach eksportu HTML:

- Eksport całej prezentacji lub wybranych slajdów.
- Generowanie HTML o stałym układzie, responsywnym lub opartym na SVG.
- Dołączanie notatek prelegenta i komentarzy.
- Kontrola jakości obrazów i przyciętych danych obrazu.
- Osadzanie czcionek lub zapisywanie plików czcionek osobno.
- Wybór sposobu zapisu i odwoływania się do zewnętrznych zasobów i plików multimedialnych.

Domyślnie eksport HTML tworzy samodzielny dokument HTML, w którym większość zasobów jest osadzona. Jest to wygodne przy udostępnianiu jednego pliku, ale może zwiększyć rozmiar wyjścia. Przy publikacji w sieci rozważ użycie zasobów zewnętrznych, niższe DPI obrazów i osadzanie jedynie czcionek, które nie są pewnie dostępne w docelowym środowisku.

## **Konwertowanie prezentacji do HTML**

Aby wyeksportować prezentację do HTML, wczytaj ją przy pomocy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) i zapisz przy użyciu [SaveFormat.Html](https://reference.aspose.com/slides/pl/php-java/aspose.slides/saveformat/).

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.html", SaveFormat::Html);
} finally {
    $presentation->dispose();
}
```

Ten przykład zapisuje jeden plik HTML. Obiekt prezentacji jest zwalniany w bloku `finally`, co zwalnia uchwyty do plików i zasoby renderujące po eksporcie.

## **Użycie HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/htmloptions/) jest główną klasą konfiguracji dla eksportu HTML. Typowe ustawienia obejmują:

- `SlidesLayoutOptions`: dodaje notatki, komentarze, materiały pomocnicze lub inne informacje układu.
- `HtmlFormatter`: zmienia strukturę dokumentu HTML lub deleguje formatowanie do kontrolera.
- `SlideImageFormat`: zmienia sposób reprezentacji slajdów, np. jako SVG.
- `PicturesCompression`: kontroluje DPI obrazu i rozmiar wyjścia.
- `DeletePicturesCroppedAreas`: zachowuje lub usuwa przycięte dane obrazu.
- `SvgResponsiveLayout`: sprawia, że wyeksportowana zawartość SVG dostosowuje się do swojego kontenera.
- `ShowHiddenSlides`: dołącza ukryte slajdy, gdy jest to wymagane.

Poniższe sekcje przedstawiają najczęstsze opcje oddzielnie, abyś mógł połączyć tylko te, które są potrzebne w Twoim przepływie pracy.

## **Konwertowanie wybranych slajdów do HTML**

Przeciążenie `save`, które przyjmuje numery slajdów, używa numeracji od 1. Pętla poniżej zapisuje każdy slajd do osobnego pliku HTML.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());

    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slideNumber = $slideIndex + 1;
        $slideNumbers = array($slideNumber);
        $htmlFileName = "slide-" . $slideNumber . ".html";

        $presentation->save($htmlFileName, $slideNumbers, SaveFormat::Html);
    }
} finally {
    $presentation->dispose();
}
```

Użyj tego wzorca, gdy strona internetowa lub aplikacja wymaga jednej strony HTML na slajd. Jeśli każdy slajd ma mieć ten sam układ, utwórz jedną instancję [HtmlOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/htmloptions/) i przekaż ją do każdego wywołania `save`.

## **Tworzenie responsywnego HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/pl/php-java/aspose.slides/responsivehtmlcontroller/) zapewnia responsywne wyjście HTML poprzez [HtmlFormatter](https://reference.aspose.com/slides/pl/php-java/aspose.slides/htmlformatter/). Użyj go, gdy wyeksportowana strona ma lepiej dostosowywać się do szerokości przeglądarki.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $controller = new ResponsiveHtmlController();
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($controller);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-responsive.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Dla responsywnego układu opartego na SVG ustaw `SvgResponsiveLayout` na [HtmlOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/htmloptions/). Jest to przydatne, gdy treść slajdu jest eksportowana jako skalowalny znacznik SVG.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setSvgResponsiveLayout(true);

    $presentation->save("presentation-svg-responsive.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

## **Dołączanie notatek prelegenta i komentarzy**

Użyj [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/notescommentslayoutingoptions/) przez `HtmlOptions.SlidesLayoutOptions`, aby dołączyć notatki prelegenta lub komentarze. Notatki i komentarze są domyślnie ukryte, chyba że określisz ich pozycje.

Załóżmy, że źródłowa prezentacja zawiera notatki prelegenta:

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

Poniższy kod eksportuje treść slajdu wraz z notatkami prelegenta pod slajdem.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $layoutOptions = new NotesCommentsLayoutingOptions();
    $layoutOptions->setNotesPosition(NotesPositions::BottomFull);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setSlidesLayoutOptions($layoutOptions);

    $presentation->save("presentation-with-notes.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Wyeksportowany HTML zawiera obszar notatek:

![HTML output with the slide and speaker notes](HTML_with_notes.png)

Aby wyeksportować komentarze, ustaw `CommentsPosition`, np. na `CommentsPositions.Right` lub `CommentsPositions.Bottom`. Jeśli potrzebujesz tylko komentarzy, pomiń `NotesPosition`. Jeśli potrzebujesz zarówno notatek, jak i komentarzy, ustaw obie właściwości.

## **Kontrola jakości obrazu i przyciętych obszarów**

Eksport HTML może kompresować obrazy slajdów, aby zmniejszyć rozmiar wyjścia. Ustaw `PicturesCompression` na wartość z [PicturesCompression](https://reference.aspose.com/slides/pl/php-java/aspose.slides/picturescompression/), gdy potrzebna jest wyższa jakość obrazu.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setPicturesCompression(PicturesCompression::Dpi150);

    $presentation->save("presentation-dpi-150.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Domyślnie przycięte obszary obrazów mogą być usuwane z wyeksportowanego wyniku. Zachowuj przycięte dane tylko wtedy, gdy użytkownicy muszą móc je odzyskać lub zbadać ukryte części obrazu. Zachowanie ich może zwiększyć rozmiar HTML.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setDeletePicturesCroppedAreas(false);

    $presentation->save("presentation-with-cropped-areas.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

## **Dodawanie CSS**

Dla prostego stylowania przekaż ciąg CSS do [HtmlFormatter](https://reference.aspose.com/slides/pl/php-java/aspose.slides/htmlformatter/) przez `createDocumentFormatter`. Zmienia to otaczający dokument HTML, podczas gdy Aspose.Slides nadal renderuje treść slajdu.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    $showSlideTitle = true;
    $formatter = java("com.aspose.slides.HtmlFormatter")->createDocumentFormatter($cssRules, $showSlideTitle);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-styled.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Dla własnego nagłówka dokumentu, powiązanego pliku CSS lub własnego znacznika wokół slajdów i kształtów użyj własnego kontrolera formatowania i przekaż go do [HtmlFormatter](https://reference.aspose.com/slides/pl/php-java/aspose.slides/htmlformatter/) przy pomocy `createCustomFormatter`.

## **Osadzanie czcionek**

Jeśli docelowe środowisko może nie mieć zainstalowanych czcionek używanych w prezentacji, osadź czcionki w HTML przy pomocy [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/pl/php-java/aspose.slides/embedallfontshtmlcontroller/). Osadzanie poprawia wierność wizualną, ale zwiększa rozmiar wyjścia.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $arrayClass = new JavaClass("java.lang.reflect.Array");
    $stringClass = new JavaClass("java.lang.String");

    $fontNamesToExclude = $arrayClass->newInstance($stringClass, 1);
    $arrayClass->set($fontNamesToExclude, 0, new Java("java.lang.String", "Calibri"));

    $fontController = new EmbedAllFontsHtmlController(java_values($fontNamesToExclude));
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($fontController);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-embedded-fonts.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Wykluczaj czcionki tylko wtedy, gdy jesteś pewny, że przeglądarki lub systemy docelowe już je zapewniają. Dla czcionek marki lub mniej popularnych czcionek osadzanie jest zazwyczaj bezpieczniejsze.

## **Linkowanie plików czcionek zamiast ich osadzania**

Aby zmniejszyć rozmiar pliku HTML, możesz zapisać dane czcionek w oddzielnych plikach WOFF i dodać reguły `@font-face` do HTML. W PHP via Java scenariusz ten zwykle realizuje mała klasa pomocnicza Java, która rozszerza [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/pl/php-java/aspose.slides/embedallfontshtmlcontroller/), zapisuje bajty czcionek do katalogu wyjściowego i wstawia reguły `@font-face` do generowanego HTML. Skompiluj tę pomocniczą klasę, dodaj ją do classpathu PHP Java Bridge, a następnie zainicjuj z PHP przy pomocy `new Java(...)`.

Tworząc taką pomocnicę, dobierz dwa ścieżki celowo:

- Ścieżka wyjściowa w systemie plików, w której zapisywane są wygenerowane pliki czcionek.
- Ścieżka URL, której przeglądarka używa z dokumentu HTML do ładowania tych plików czcionek.

## **Zapisywanie zasobów zewnętrznie**

Samodzielny HTML jest łatwy do przenoszenia, ale osadzone zasoby Base64 mogą sprawić, że plik będzie duży. Jeśli aplikacja wymaga zewnętrznych plików obrazów, dostarcz własny kontroler link/ embed do konstruktora [HtmlOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/htmloptions/).

Externalizując zasoby, dobierz dwa ścieżki celowo:

- Ścieżka wyjściowa w systemie plików, w której aplikacja zapisuje wygenerowane obrazy, czcionki, audio lub wideo.
- Ścieżka URL, której przeglądarka używa z dokumentu HTML do ładowania tych plików.

Utrzymuj te ścieżki spójne z układem wdrożenia, aby wygenerowany HTML mógł ładować swoje zasoby zewnętrzne po przeniesieniu na serwer WWW lub do innego katalogu.

## **Eksportowanie plików multimedialnych**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/pl/php-java/aspose.slides/videoplayerhtmlcontroller/) eksportuje pliki wideo i audio oraz generuje HTML, który może je odtwarzać w przeglądarce. Jego konstruktor przyjmuje:

- `path`: katalog wyjściowy używany przez wygenerowany HTML i pliki multimedialne.
- `fileName`: nazwa generowanego pliku HTML.
- `baseUri`: absolutny prefiks URI używany w linkach HTML do plików multimedialnych.

Jeśli plik HTML znajduje się w `html-output/presentation.html`, `path` powinien wskazywać na `html-output`, a `baseUri` powinien wskazywać na ten sam katalog z punktu widzenia przeglądarki. Do podglądu lokalnego możesz zbudować URI `file:///` z katalogu wyjściowego. W aplikacji wdrożonej użyj bezwzględnego URL opublikowanego katalogu wyjściowego.

```php
$outputDirectory = getcwd() . DIRECTORY_SEPARATOR . "html-output";

if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$htmlFileName = "presentation.html";
$outputDirectoryPath = realpath($outputDirectory);
$outputDirectoryPath = str_replace("\\", "/", $outputDirectoryPath);
$outputBaseUri = "file:///" . ltrim($outputDirectoryPath, "/") . "/";

$presentation = new Presentation();
$videoStream = null;
try {
    $videoFilePath = getcwd() . DIRECTORY_SEPARATOR . "intro.mp4";
    $videoStream = new Java("java.io.FileInputStream", $videoFilePath);
    $video = $presentation->getVideos()->addVideo($videoStream, LoadingStreamBehavior::ReadStreamAndRelease);
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addVideoFrame(20, 20, 480, 270, $video);

    $controller = new VideoPlayerHtmlController($outputDirectory, $htmlFileName, $outputBaseUri);
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($controller);
    $svgOptions = new SVGOptions($controller);
    $slideImageFormat = SlideImageFormat::svg($svgOptions);

    $htmlOptions = new HtmlOptions($controller);
    $htmlOptions->setHtmlFormatter($formatter);
    $htmlOptions->setSlideImageFormat($slideImageFormat);

    $htmlFilePath = $outputDirectory . DIRECTORY_SEPARATOR . $htmlFileName;
    $presentation->save($htmlFilePath, SaveFormat::Html, $htmlOptions);
} finally {
    if ($videoStream !== null) {
        $videoStream->close();
    }

    $presentation->dispose();
}
```

Używaj katalogów wyjściowych unikalnych dla każdego zadania eksportu, szczególnie w aplikacjach serwerowych. Wspólne ścieżki wyjściowe mogą powodować nadpisywanie plików z różnych konwersji.

## **Wydajność i zarządzanie zasobami**

Konwersja HTML jest operacją renderowania, więc czas przetwarzania i zużycie pamięci zależą od liczby slajdów, rozdzielczości obrazów, czcionek, efektów, wykresów i osadzonych mediów. Wyższe wartości DPI w `PicturesCompression`, osadzone czcionki, wyjście SVG i zachowanie przyciętych obszarów obrazu mogą poprawić wierność, ale zazwyczaj zwiększają rozmiar wyjścia.

Dla konwersji wsadowej:

- Zwalniaj każdą instancję [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) niezwłocznie.
- Używaj osobnych katalogów wyjściowych dla różnych zadań.
- Unikaj osadzania powszechnych czcionek, chyba że wymaga tego wierność.
- Obniż DPI obrazu, gdy HTML służy do podglądu lub miniatur.
- Trzymaj źródłową prezentację, wygenerowany HTML i zasoby zewnętrzne razem, aż do ustalenia ostatecznych ścieżek wdrożenia.

## **FAQ**

**Czy hiperlinki są zachowywane w wyjściu HTML?**

Tak. Hiperlinki w prezentacji są eksportowane do HTML i pozostają klikalne, gdy docelowy adres URL jest prawidłowy.

**Czy mogę konwertować prezentacje do HTML równolegle?**

Tak, ale nie współdziel jedną instancję [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) pomiędzy wątkami. Przetwarzaj różne pliki przy użyciu osobnych instancji prezentacji, osobnych strumieni i osobnych katalogów wyjściowych.

**Czy obiekt Presentation jest bezpieczny wątkowo?**

Nie. Jedna instancja [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) powinna być wczytana, modyfikowana, zapisana i zwolniona na jednym wątku. Do pracy równoległej twórz niezależną instancję dla każdego wątku lub procesu.

**Dlaczego wygenerowany plik HTML jest duży?**

Domyślny eksport może osadzać zasoby bezpośrednio w HTML. Osadzone czcionki, obrazy o wysokim DPI, media, zawartość SVG oraz zachowane przycięte obszary obrazu również zwiększają rozmiar. Użyj zasobów zewnętrznych, wyklucz powszechne czcionki z osadzania i obniż `PicturesCompression`, gdy mniejszy rozmiar wyjścia jest ważniejszy niż maksymalna wierność.

**Dlaczego rozmiar czcionki w PowerPoint, np. 24 pt, pojawia się jako 17,999819 pt w HTML?**

Może to wynikać z różnic w modelach DPI używanych przez PowerPoint i HTML. PowerPoint przechowuje rozmiary tekstu w punktach typograficznych opartych na 72 DPI, podczas gdy układ HTML opiera się na pikselach CSS w modelu 96 DPI. Podczas eksportu Aspose.Slides przelicza rozmiar czcionki między tymi systemami, co może wprowadzić drobne różnice zaokrągleń.

Wartości te nie oznaczają rzeczywistej zmiany widocznego rozmiaru czcionki. Są jedynie matematycznym efektem ubocznym konwersji metryk tekstu między PowerPoint a HTML.

**Jak powinienem wybrać baseUri przy eksporcie multimediów?**

Wybierz `baseUri` z perspektywy przeglądarki i przekaż go jako absolutny URI. Do podglądu lokalnego możesz go wyprowadzić z katalogu wyjściowego jako URI pliku Java. W wdrożeniu użyj bezwzględnego URL opublikowanego katalogu multimediów. Ścieżka systemowa `path` i przeglądarkowa `baseUri` nie muszą być tym samym ciągiem, ale muszą opisywać tę samą lokalizację zasobu.

**Czy mogę dołączyć ukryte slajdy?**

Tak. Ustaw `ShowHiddenSlides` na `true` na [HtmlOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/htmloptions/), gdy ukryte slajdy muszą być eksportowane.