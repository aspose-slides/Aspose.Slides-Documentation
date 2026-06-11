---
title: Konwertowanie prezentacji PowerPoint do HTML w Javie
linktitle: PowerPoint do HTML
type: docs
weight: 30
url: /pl/java/convert-powerpoint-to-html/
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
- Java
- Aspose.Slides
description: "Konwertuj prezentacje PowerPoint do HTML w Javie. Użyj Aspose.Slides do eksportu plików PPT i PPTX, wybranych slajdów, notatek, czcionek, obrazów, SVG i multimediów."
---
## **Przegląd**

Aspose.Slides for Java może zapisywać prezentacje PowerPoint jako HTML bez Microsoft PowerPoint. Podstawowa konwersja polega na jednorazowym załadowaniu [Prezentacja](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) i wywołaniu `save` z [SaveFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/saveformat/). Użyj [HtmlOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/htmloptions/), gdy potrzebujesz kontrolować układ eksportu, czcionki, obrazy, notatki, komentarze, wyjście SVG lub powiązane zasoby.

Ten przewodnik koncentruje się na praktycznych scenariuszach eksportu HTML:

- Eksport całej prezentacji lub wybranych slajdów.
- Generowanie HTML o stałym układzie, responsywnym lub opartym na SVG.
- Dołączanie notatek prelegenta i komentarzy.
- Kontrola jakości obrazu i przyciętych danych obrazu.
- Osadzanie czcionek lub zapisywanie plików czcionek osobno.
- Wybór sposobu zapisu i odniesień do zewnętrznych zasobów oraz plików multimedialnych.

Domyślnie eksport HTML tworzy samodzielny dokument HTML, w którym większość zasobów jest osadzona. To wygodne przy udostępnianiu jednego pliku, ale może zwiększyć rozmiar wyjścia. Przy publikacji w sieci rozważ użycie zasobów zewnętrznych, niższe DPI obrazów i osadzanie tylko tych czcionek, które nie są pewnie dostępne w docelowym środowisku.

## **Konwertowanie prezentacji do HTML**

Aby wyeksportować prezentację do HTML, załaduj ją za pomocą [Prezentacja](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) i zapisz przy użyciu [SaveFormat.Html](https://reference.aspose.com/slides/pl/java/com.aspose.slides/saveformat/).

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Ten przykład zapisuje jeden plik HTML. Obiekt prezentacji jest usuwany w bloku `finally`, co zwalnia uchwyty plików i zasoby renderowania po eksporcie.

## **Użycie HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/htmloptions/) jest główną klasą konfiguracyjną eksportu HTML. Typowe ustawienia obejmują:

- `SlidesLayoutOptions`: dodaje notatki, komentarze, materiały rozdawane lub inne informacje o układzie.
- `HtmlFormatter`: zmienia strukturę dokumentu HTML lub deleguje formatowanie do kontrolera.
- `SlideImageFormat`: zmienia sposób reprezentacji slajdów, na przykład jako SVG.
- `PicturesCompression`: kontroluje DPI obrazu i rozmiar wyjścia.
- `DeletePicturesCroppedAreas`: zachowuje lub usuwa przycięte dane obrazu.
- `SvgResponsiveLayout`: sprawia, że wyeksportowana zawartość SVG dostosowuje się do swojego kontenera.
- `ShowHiddenSlides`: dołącza ukryte slajdy, gdy jest to wymagane.

Poniższe sekcje pokazują najczęściej używane opcje osobno, abyś mógł łączyć tylko te, które są potrzebne w Twoim procesie.

## **Konwertowanie wybranych slajdów do HTML**

Przeciążenie `Presentation.save`, które przyjmuje numery slajdów, używa numeracji od 1. Pętla poniżej zapisuje każdy slajd do osobnego pliku HTML.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();

    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        int slideNumber = slideIndex + 1;
        int[] slideNumbers = { slideNumber };
        String htmlFileName = "slide-" + slideNumber + ".html";

        presentation.save(htmlFileName, slideNumbers, SaveFormat.Html);
    }
} finally {
    presentation.dispose();
}
```

Użyj tego wzorca, gdy strona internetowa lub aplikacja wymaga jednej strony HTML na slajd. Jeśli każdy slajd ma mieć ten sam układ, utwórz jedną instancję [HtmlOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/htmloptions/) i przekaż ją do każdego wywołania `save`.

## **Tworzenie responsywnego HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/pl/java/com.aspose.slides/responsivehtmlcontroller/) zapewnia responsywne wyjście HTML poprzez [HtmlFormatter](https://reference.aspose.com/slides/pl/java/com.aspose.slides/htmlformatter/). Użyj go, gdy wyeksportowana strona ma lepiej dostosowywać się do szerokości przeglądarki.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    ResponsiveHtmlController controller = new ResponsiveHtmlController();
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(controller);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-responsive.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Aby uzyskać responsywny układ oparty na SVG, ustaw `SvgResponsiveLayout` w [HtmlOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/htmloptions/). Jest to przydatne, gdy zawartość slajdu jest eksportowana jako skalowalny znacznik SVG.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setSvgResponsiveLayout(true);

    presentation.save("presentation-svg-responsive.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **Dołączanie notatek prelegenta i komentarzy**

Użyj [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/notescommentslayoutingoptions/) poprzez `HtmlOptions.setSlidesLayoutOptions`, aby dodać notatki prelegenta lub komentarze. Notatki i komentarze są domyślnie ukryte, chyba że określisz ich pozycje.

Załóżmy, że źródłowa prezentacja zawiera notatki prelegenta:

![Slajd z notatkami prelegenta w PowerPoint](slide_with_notes.png)

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
    layoutOptions.setNotesPosition(NotesPositions.BottomFull);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setSlidesLayoutOptions(layoutOptions);

    presentation.save("presentation-with-notes.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Poniższy kod eksportuje treść slajdu z notatkami prelegenta pod slajdem.

![Wyjście HTML ze slajdem i notatkami prelegenta](HTML_with_notes.png)

Aby wyeksportować komentarze, ustaw `CommentsPosition`, na przykład na `CommentsPositions.Right` lub `CommentsPositions.Bottom`. Jeśli potrzebujesz tylko komentarzy, pomiń `NotesPosition`. Jeśli potrzebujesz zarówno notatek, jak i komentarzy, ustaw obie właściwości.

## **Kontrola jakości obrazu i przyciętych obszarów**

Eksport HTML może kompresować obrazy slajdów, aby zmniejszyć rozmiar wyjścia. Ustaw `PicturesCompression` na wartość z [PicturesCompression](https://reference.aspose.com/slides/pl/java/com.aspose.slides/picturescompression/), gdy potrzebujesz wyższej jakości obrazu.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setPicturesCompression(PicturesCompression.Dpi150);

    presentation.save("presentation-dpi-150.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Domyślnie przycięte obszary obrazów mogą być usuwane z wyeksportowanego wyniku. Zachowuj przycięte dane tylko wtedy, gdy użytkownicy muszą móc odzyskać lub przeanalizować ukryte części obrazu. Zachowanie ich może zwiększyć rozmiar HTML.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setDeletePicturesCroppedAreas(false);

    presentation.save("presentation-with-cropped-areas.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **Dodawanie CSS**

Dla prostego stylowania przekaż łańcuch CSS do `HtmlFormatter.createDocumentFormatter`. Zmienia to otaczający dokument HTML, podczas gdy Aspose.Slides nadal renderuje zawartość slajdu.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    String cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    HtmlFormatter formatter = HtmlFormatter.createDocumentFormatter(cssRules, true);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-styled.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Aby dodać własny nagłówek dokumentu, połączony plik CSS lub własny znacznik wokół slajdów i kształtów, zaimplementuj [IHtmlFormattingController](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ihtmlformattingcontroller/) i przekaż go do [HtmlFormatter](https://reference.aspose.com/slides/pl/java/com.aspose.slides/htmlformatter/) metodą `createCustomFormatter`.

## **Osadzanie czcionek**

Jeśli docelowe środowisko może nie mieć zainstalowanych czcionek użytych w prezentacji, osadź czcionki w HTML przy pomocy [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/pl/java/com.aspose.slides/embedallfontshtmlcontroller/). Osadzanie poprawia wierność wizualną, ale zwiększa rozmiar wyjścia.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    String[] fontNamesToExclude = { "Arial" };
    EmbedAllFontsHtmlController fontController = new EmbedAllFontsHtmlController(fontNamesToExclude);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-embedded-fonts.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Wyklucz czcionki tylko wtedy, gdy jesteś pewny, że docelowe przeglądarki lub systemy już je udostępniają. Dla czcionek firmowych lub mniej popularnych osadzanie jest zazwyczaj bezpieczniejsze.

## **Linkowanie plików czcionek zamiast ich osadzania**

Aby zmniejszyć rozmiar pliku HTML, możesz zapisać dane czcionek w osobnych plikach WOFF i dodać reguły `@font-face` do HTML. Poniższy pomocnik rozszerza [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/pl/java/com.aspose.slides/embedallfontshtmlcontroller/) i nadpisuje metodę `writeFont`.

```java
class LinkedFontsHtmlController extends EmbedAllFontsHtmlController {
    private final java.nio.file.Path fontOutputDirectory;
    private final String fontUrlPrefix;

    LinkedFontsHtmlController(
            java.nio.file.Path fontOutputDirectory,
            String fontUrlPrefix) throws java.io.IOException {
        super(new String[0]);
        this.fontOutputDirectory = fontOutputDirectory;
        this.fontUrlPrefix = fontUrlPrefix.endsWith("/") ? fontUrlPrefix : fontUrlPrefix + "/";

        java.nio.file.Files.createDirectories(fontOutputDirectory);
    }

    @Override
    public void writeFont(
            IHtmlGenerator generator,
            IFontData originalFont,
            IFontData substitutedFont,
            String fontStyle,
            String fontWeight,
            byte[] fontData) {
        try {
            IFontData font = substitutedFont == null ? originalFont : substitutedFont;
            String safeFontName = makeSafeFileName(font.getFontName());
            String safeFontStyle = fontStyle == null || fontStyle.trim().isEmpty() ? "normal" : fontStyle;
            String safeFontWeight = fontWeight == null || fontWeight.trim().isEmpty() ? "normal" : fontWeight;
            String fontFileName = safeFontName + "-" + safeFontStyle + "-" + safeFontWeight + ".woff";
            java.nio.file.Path fontFilePath = fontOutputDirectory.resolve(fontFileName);

            java.nio.file.Files.write(fontFilePath, fontData);

            String encodedFontFileName = java.net.URLEncoder.encode(fontFileName, "UTF-8");
            String fontUrl = fontUrlPrefix + encodedFontFileName.replace("+", "%20");
            String escapedBackslashes = font.getFontName().replace("\\", "\\\\");
            String fontFamily = escapedBackslashes.replace("'", "\\'");

            generator.addHtml("<style>");
            generator.addHtml("@font-face {");
            generator.addHtml("font-family: '" + fontFamily + "';");
            generator.addHtml("font-style: " + safeFontStyle + ";");
            generator.addHtml("font-weight: " + safeFontWeight + ";");
            generator.addHtml("src: url('" + fontUrl + "') format('woff');");
            generator.addHtml("}");
            generator.addHtml("</style>");
        } catch (java.io.IOException exception) {
            throw new RuntimeException("Unable to write an exported font.", exception);
        }
    }

    private String makeSafeFileName(String fileName) {
        String invalidCharacters = "\\/:*?\"<>|";
        char[] safeCharacters = fileName.toCharArray();

        for (int characterIndex = 0; characterIndex < safeCharacters.length; characterIndex++) {
            if (invalidCharacters.indexOf(safeCharacters[characterIndex]) >= 0) {
                safeCharacters[characterIndex] = '_';
            }
        }

        return new String(safeCharacters);
    }
}

java.nio.file.Path outputDirectory = java.nio.file.Paths.get(System.getProperty("user.dir"), "html-output");
java.nio.file.Path fontsDirectory = outputDirectory.resolve("fonts");
java.nio.file.Files.createDirectories(outputDirectory);

Presentation presentation = new Presentation("presentation.pptx");
try {
    LinkedFontsHtmlController fontController = new LinkedFontsHtmlController(fontsDirectory, "fonts");
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    java.nio.file.Path htmlFilePath = outputDirectory.resolve("presentation.html");
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

W tym przykładzie pliki czcionek są zapisywane w `html-output/fonts`, a HTML odwołuje się do nich za pomocą URL‑ów, takich jak `fonts/BrandFont-normal-400.woff`. Jeśli plik HTML i czcionki są wdrażane w innym miejscu, wybierz `fontUrlPrefix`, aby pasował do wdrożonej ścieżki URL.

## **Zewnętrzne zapisywanie zasobów**

Samodzielny HTML jest łatwy do przenoszenia, ale osadzone zasoby Base64 mogą uczynić plik duży. Jeśli Twoja aplikacja potrzebuje zewnętrznych plików obrazów, zaimplementuj [ILinkEmbedController](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ilinkembedcontroller/) i przekaż go do konstruktora [HtmlOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/htmloptions/).

Podczas eksternelizacji zasobów wybierz dwie ścieżki świadomie:

- Ścieżka wyjścia w systemie plików, w której aplikacja zapisuje wygenerowane obrazy, czcionki, dźwięki lub wideo.
- Ścieżka URL, której przeglądarka używa w dokumencie HTML do ładowania tych plików.

## **Eksportowanie plików multimedialnych**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/pl/java/com.aspose.slides/videoplayerhtmlcontroller/) eksportuje pliki wideo i audio oraz tworzy HTML, który może je odtwarzać w przeglądarce. Jego konstruktor przyjmuje:

- `path`: katalog, w którym będą zapisywane wygenerowane pliki multimedialne.
- `fileName`: nazwa generowanego pliku HTML.
- `baseUri`: absolutny prefiks URI używany w odnośnikach HTML do plików multimedialnych.

Jeśli plik HTML to `html-output/presentation.html`, a pliki multimedialne są zapisywane w `html-output/media`, `path` powinien wskazywać katalog mediów na dysku, natomiast `baseUri` powinien wskazywać ten sam katalog z perspektywy przeglądarki. Do podglądu lokalnego możesz zbudować URI `file:///` z katalogu mediów. W aplikacji wdrożonej użyj absolutnego URL opublikowanego katalogu mediów.

```java
java.nio.file.Path outputDirectory = java.nio.file.Paths.get(System.getProperty("user.dir"), "html-output");
java.nio.file.Path mediaDirectory = outputDirectory.resolve("media");
java.nio.file.Files.createDirectories(outputDirectory);
java.nio.file.Files.createDirectories(mediaDirectory);

String htmlFileName = "presentation.html";
String mediaBaseUri = mediaDirectory.toUri().toString();

Presentation presentation = new Presentation();
try {
    java.nio.file.Path videoFilePath = java.nio.file.Paths.get("intro.mp4");
    byte[] videoData = java.nio.file.Files.readAllBytes(videoFilePath);

    IVideo video = presentation.getVideos().addVideo(videoData);
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addVideoFrame(20, 20, 480, 270, video);

    String mediaDirectoryPath = mediaDirectory.toString();
    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(mediaDirectoryPath, htmlFileName, mediaBaseUri);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(controller);
    SVGOptions svgOptions = new SVGOptions(controller);
    SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

    HtmlOptions htmlOptions = new HtmlOptions(controller);
    htmlOptions.setHtmlFormatter(formatter);
    htmlOptions.setSlideImageFormat(slideImageFormat);

    java.nio.file.Path htmlFilePath = outputDirectory.resolve(htmlFileName);
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Używaj katalogów wyjściowych unikalnych dla każdego zadania eksportu, szczególnie w aplikacjach serwerowych. Wspólne ścieżki wyjściowe mogą powodować nadpisywanie plików z różnych konwersji.

## **Wydajność i zarządzanie zasobami**

Konwersja HTML to operacja renderowania, więc czas przetwarzania i zużycie pamięci zależą od liczby slajdów, rozdzielczości obrazów, czcionek, efektów, wykresów i osadzonych mediów. Wyższe wartości DPI w `PicturesCompression`, osadzone czcionki, wyjście SVG i zachowane przycięte obszary obrazów mogą poprawić wierność, ale zwykle zwiększają rozmiar wyjścia.

Przy konwersji wsadowej:

- Natychmiast zwalniaj każdą instancję [Prezentacja](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/).
- Używaj oddzielnych katalogów wyjściowych dla poszczególnych zadań.
- Unikaj osadzania popularnych czcionek, chyba że wymaga tego dokładność.
- Obniż DPI obrazu, gdy HTML służy do podglądu lub miniatur.
- Trzymaj źródłową prezentację, wygenerowany HTML i zasoby zewnętrzne razem, aż ścieżki wdrożeniowe będą ostateczne.

## **FAQ**

**Czy hiperlinki są zachowane w wyjściu HTML?**  
Tak. Hiperlinki w prezentacji są eksportowane do HTML i pozostają klikalne, o ile docelowy adres URL jest prawidłowy.

**Czy mogę konwertować prezentacje do HTML równolegle?**  
Tak, ale nie współdziel jedną instancję [Prezentacja](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) między wątkami. Przetwarzaj różne pliki przy użyciu oddzielnych instancji prezentacji, oddzielnych strumieni i oddzielnych katalogów wyjściowych. Zobacz [multithreading guidance](/slides/pl/java/multithreading/) po szczegóły.

**Czy obiekt Presentation jest bezpieczny dla wątków?**  
Nie. Jedna instancja [Prezentacja](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) powinna być ładowana, modyfikowana, zapisywana i usuwana w jednym wątku. Do pracy równoległej twórz niezależną instancję na każdy wątek lub proces.

**Dlaczego wygenerowany plik HTML jest duży?**  
Domyślny eksport może osadzać zasoby bezpośrednio w HTML. Osadzone czcionki, obrazy o wysokim DPI, multimedia, zawartość SVG i zachowane przycięte obszary obrazów również zwiększają rozmiar. Użyj zasobów zewnętrznych, wyklucz popularne czcionki z osadzania i obniż `PicturesCompression`, gdy mniejszy rozmiar jest ważniejszy niż maksymalna wierność.

**Dlaczego rozmiar czcionki w PowerPoint, np. 24 pt, pojawia się jako 17,999819 pt w HTML?**  
Może się tak zdarzyć, ponieważ PowerPoint i HTML używają różnych modeli DPI. PowerPoint przechowuje rozmiary tekstu w punktach typograficznych opartych na 72 DPI, a układ HTML opiera się na pikselach CSS w modelu 96 DPI. Podczas eksportu Aspose.Slides konwertuje rozmiar czcionki między tymi systemami, co może wprowadzać niewielkie różnice zaokrągleń.

Wartości te nie wskazują na rzeczywistą zmianę wizualną rozmiaru czcionki. Są jedynie matematycznym skutkiem ubocznym konwersji metryk tekstu między PowerPoint a HTML.

**Jak powinienem wybrać baseUri przy eksporcie multimediów?**  
Wybierz `baseUri` z perspektywy przeglądarki i przekaż go jako absolutny URI. Do podglądu lokalnego możesz go wyprowadzić z katalogu wyjściowego metodą `mediaDirectory.toUri().toString()`. W wdrożeniu użyj absolutnego URL opublikowanego katalogu multimediów. Ścieżka systemowa `path` i przeglądarkowa `baseUri` nie muszą być tym samym łańcuchiem, ale muszą opisywać to samo położenie zasobu.

**Czy mogę uwzględnić ukryte slajdy?**  
Tak. Ustaw `ShowHiddenSlides` na `true` w [HtmlOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/htmloptions/), gdy ukryte slajdy muszą być eksportowane.