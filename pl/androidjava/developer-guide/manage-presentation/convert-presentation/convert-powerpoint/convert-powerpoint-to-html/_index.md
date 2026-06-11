---
title: Konwertuj prezentacje PowerPoint do HTML na Androidzie
linktitle: PowerPoint do HTML
type: docs
weight: 30
url: /pl/androidjava/convert-powerpoint-to-html/
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
- Android
- Java
- Aspose.Slides
description: "Konwertuj prezentacje PowerPoint do HTML na Androidzie. Użyj Aspose.Slides dla Androida poprzez Java, aby eksportować pliki PPT i PPTX, wybrane slajdy, notatki, czcionki, obrazy, SVG i multimedia."
---
## **Przegląd**

Aspose.Slides for Android via Java może zapisywać prezentacje PowerPoint jako HTML bez Microsoft PowerPoint. Podstawowa konwersja to jednorazowe wczytanie [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) i wywołanie `save` z [SaveFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/saveformat/). Użyj [HtmlOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/htmloptions/) gdy potrzebujesz kontrolować układ, czcionki, obrazy, notatki, komentarze, wyjście SVG lub powiązane zasoby.

Niniejszy przewodnik koncentruje się na praktycznych scenariuszach eksportu HTML:

- Eksportuj całą prezentację lub wybrane slajdy.
- Generuj HTML o stałym układzie, responsywny lub oparty na SVG.
- Dołącz notatki prelegenta i komentarze.
- Kontroluj jakość obrazów i przycięte dane obrazów.
- Osadź czcionki lub zapisz pliki czcionek osobno.
- Wybierz sposób zapisu i odwołań do zewnętrznych zasobów oraz plików multimedialnych.

Domyślnie eksport HTML tworzy samodzielny dokument HTML, w którym większość zasobów jest osadzona. Jest to wygodne przy udostępnianiu jednego pliku, ale może zwiększyć rozmiar wyjścia. Przy publikacji w Internecie rozważ użycie zewnętrznych zasobów, niższą rozdzielczość DPI obrazów oraz osadzanie tylko tych czcionek, które nie są pewnie dostępne w docelowym środowisku.

## **Konwertuj prezentację do HTML**

Aby wyeksportować prezentację do HTML, wczytaj ją przy użyciu [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) i zapisz przy użyciu [SaveFormat.Html](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/saveformat/).

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Ten przykład zapisuje jeden plik HTML. Obiekt prezentacji jest zwalniany w bloku `finally`, co zwalnia uchwyty plików oraz zasoby renderowania po eksporcie.

## **Użyj HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/htmloptions/) jest główną klasą konfiguracyjną dla eksportu HTML. Typowe ustawienia obejmują:

- `SlidesLayoutOptions`: dodaje notatki, komentarze, materiały pomocnicze lub inne informacje o układzie.
- `HtmlFormatter`: zmienia strukturę dokumentu HTML lub deleguje formatowanie do kontrolera.
- `SlideImageFormat`: zmienia sposób reprezentacji slajdów, np. jako SVG.
- `PicturesCompression`: kontroluje DPI obrazu i rozmiar wyjścia.
- `DeletePicturesCroppedAreas`: zachowuje lub usuwa przycięte dane obrazów.
- `SvgResponsiveLayout`: sprawia, że wyeksportowana zawartość SVG dostosowuje się do swojego kontenera.
- `ShowHiddenSlides`: uwzględnia ukryte slajdy, gdy jest to wymagane.

Poniższe sekcje pokazują najczęstsze opcje osobno, abyś mógł połączyć tylko te, które potrzebuje Twój proces pracy.

## **Konwertuj wybrane slajdy do HTML**

Przeciążenie `Presentation.save` przyjmujące numery slajdów używa pozycji slajdów liczonych od 1. Pętla poniżej zapisuje każdy slajd do oddzielnego pliku HTML.

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

Użyj tego wzorca, gdy strona internetowa lub aplikacja wymaga jednej strony HTML na slajd. Jeśli każdy slajd ma mieć ten sam układ, utwórz jedną instancję [HtmlOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/htmloptions/) i przekaż ją do każdego wywołania `save`.

## **Utwórz responsywny HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/responsivehtmlcontroller/) zapewnia responsywny wyjściowy HTML poprzez [HtmlFormatter](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/htmlformatter/). Użyj go, gdy wyeksportowana strona ma lepiej dopasowywać się do szerokości przeglądarki.

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

W przypadku responsywnego układu opartego na SVG, ustaw `SvgResponsiveLayout` w [HtmlOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/htmloptions/). Jest to przydatne, gdy zawartość slajdu jest eksportowana jako skalowalny znacznik SVG.

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

## **Dołącz notatki prelegenta i komentarze**

Użyj [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/notescommentslayoutingoptions/) poprzez `HtmlOptions.SlidesLayoutOptions`, aby dołączyć notatki prelegenta lub komentarze. Notatki i komentarze są domyślnie ukryte, chyba że określisz ich pozycje.

Załóżmy, że źródłowa prezentacja zawiera notatki prelegenta:

![Slajd z notatkami prelegenta w PowerPoint](slide_with_notes.png)

Poniższy kod eksportuje zawartość slajdu wraz z notatkami prelegenta pod slajdem.

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

Wyeksportowany HTML zawiera obszar notatek:

![Wyjście HTML ze slajdem i notatkami prelegenta](HTML_with_notes.png)

Aby wyeksportować komentarze, ustaw `CommentsPosition`, na przykład na `CommentsPositions.Right` lub `CommentsPositions.Bottom`. Jeśli potrzebujesz tylko komentarzy, pomiń `NotesPosition`. Jeśli potrzebujesz zarówno notatek, jak i komentarzy, ustaw obie właściwości.

## **Kontroluj jakość obrazu i przycięte obszary**

Eksport HTML może kompresować obrazy slajdów, aby zmniejszyć rozmiar wyjścia. Ustaw `PicturesCompression` na wartość z [PicturesCompression](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/picturescompression/), gdy potrzebna jest wyższa jakość obrazu.

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

Domyślnie przycięte obszary obrazów mogą być usuwane z wyjścia. Zachowaj przycięte dane tylko wtedy, gdy użytkownicy muszą móc odzyskać lub przejrzeć te ukryte części obrazu. Ich zachowanie może zwiększyć rozmiar HTML.

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

## **Dodaj CSS**

Do prostego stylowania przekaż ciąg CSS do `HtmlFormatter.createDocumentFormatter`. Zmienia to otaczający dokument HTML, podczas gdy Aspose.Slides kontynuuje renderowanie zawartości slajdu.

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

Aby uzyskać niestandardowy nagłówek dokumentu, połączony plik CSS lub niestandardowy znacznik wokół slajdów i kształtów, zaimplementuj [IHtmlFormattingController](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ihtmlformattingcontroller/) i przekaż go do [HtmlFormatter](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/htmlformatter/) przy użyciu `createCustomFormatter`.

## **Osadź czcionki**

Jeśli w docelowym środowisku mogą nie być zainstalowane czcionki użyte w prezentacji, osadź czcionki w HTML za pomocą [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/embedallfontshtmlcontroller/). Osadzanie poprawia wierność wizualną, ale zwiększa rozmiar wyjścia.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    String[] fontNamesToExclude = { "Arial", "Calibri" };
    EmbedAllFontsHtmlController fontController = new EmbedAllFontsHtmlController(fontNamesToExclude);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-embedded-fonts.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Wyklucz czcionki tylko wtedy, gdy masz pewność, że docelowe przeglądarki lub systemy już je dostarczają. W przypadku czcionek firmowych lub mniej popularnych, osadzanie jest zazwyczaj bezpieczniejsze.

## **Linkuj pliki czcionek zamiast je osadzać**

Aby zmniejszyć rozmiar pliku HTML, możesz zapisać dane czcionek do osobnych plików WOFF i dodać reguły `@font-face` do HTML. Pomocnik poniżej rozszerza [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/embedallfontshtmlcontroller/) i nadpisuje `writeFont`.

```java
class LinkedFontsHtmlController extends EmbedAllFontsHtmlController {
    private final String fontOutputDirectory;
    private final String fontUrlPrefix;

    LinkedFontsHtmlController(
            String fontOutputDirectory,
            String fontUrlPrefix) throws java.io.IOException {
        super(new String[0]);
        this.fontOutputDirectory = fontOutputDirectory;
        this.fontUrlPrefix = fontUrlPrefix.endsWith("/") ? fontUrlPrefix : fontUrlPrefix + "/";
        
        File dirs = new File(fontOutputDirectory);
        dirs.mkdirs();
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
            String fontFilePath = fontOutputDirectory + "/" + fontFileName;

            FileOutputStream fos = new FileOutputStream(fontFilePath);
            fos.write(fontData);
            fos.close();

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

String outputDirectory = System.getProperty("user.dir") + "/html-output";
String fontsDirectory = outputDirectory + "/fonts";
File dir = new File("path/to/folder");
dir.mkdir();

Presentation presentation = new Presentation("presentation.pptx");
try {
    LinkedFontsHtmlController fontController = new LinkedFontsHtmlController(fontsDirectory, "fonts");
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    String htmlFilePath = outputDirectory + "/presentation.html";
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

W tym przykładzie pliki czcionek są zapisywane w `html-output/fonts`, a HTML odwołuje się do nich za pomocą adresów URL, takich jak `fonts/BrandFont-normal-400.woff`. Jeśli plik HTML i czcionki są wdrażane w innym miejscu, wybierz `fontUrlPrefix`, aby pasował do wdrożonej ścieżki URL.

## **Zapisz zasoby zewnętrznie**

Samodzielny HTML jest łatwy do przenoszenia, ale osadzone zasoby Base64 mogą zwiększyć rozmiar pliku. Jeśli Twoja aplikacja potrzebuje zewnętrznych plików obrazów, zaimplementuj [ILinkEmbedController](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilinkembedcontroller/) i przekaż go do konstruktora [HtmlOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/htmloptions/).

Podczas externalizacji zasobów wybierz dwa ścieżki celowo:

- Ścieżka wyjścia w systemie plików, w której aplikacja zapisuje wygenerowane obrazy, czcionki, audio lub wideo.
- Ścieżka URL, której przeglądarka używa z dokumentu HTML do ładowania tych plików.

## **Eksportuj pliki multimedialne**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/videoplayerhtmlcontroller/) eksportuje pliki wideo i audio oraz zapisuje HTML, który może je odtwarzać w przeglądarce. Jego konstruktor przyjmuje:

- `path`: katalog, w którym będą zapisywane wygenerowane pliki multimedialne.
- `fileName`: nazwa generowanego pliku HTML.
- `baseUri`: absolutny prefiks URI używany w linkach HTML do plików multimedialnych.

Jeśli plik HTML to `html-output/presentation.html`, a pliki multimedialne są zapisywane w `html-output/media`, `path` powinien wskazywać katalog mediów na dysku, natomiast `baseUri` powinien wskazywać ten sam katalog z perspektywy przeglądarki. Do podglądu lokalnego możesz zbudować URI `file:///` z katalogu mediów. Dla wdrożonej aplikacji użyj absolutnego URL opublikowanego katalogu multimedialnego.

```java
String outputDirectory = System.getProperty("user.dir") + "/html-output";
String mediaDirectory = outputDirectory + "/media";
File outDir = new File(outputDirectory);
outDir.mkdir();
File mediaDir = new File(mediaDirectory);
mediaDir.mkdir();

String htmlFileName = "presentation.html";
String mediaBaseUri = mediaDirectory;

Presentation presentation = new Presentation();
try {
    byte[] videoData = ...;// intro.mp4

    IVideo video = presentation.getVideos().addVideo(videoData);
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addVideoFrame(20, 20, 480, 270, video);

    String mediaDirectoryPath = mediaDirectory;
    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(mediaDirectoryPath, htmlFileName, mediaBaseUri);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(controller);
    SVGOptions svgOptions = new SVGOptions(controller);
    SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

    HtmlOptions htmlOptions = new HtmlOptions(controller);
    htmlOptions.setHtmlFormatter(formatter);
    htmlOptions.setSlideImageFormat(slideImageFormat);

    String htmlFilePath = outputDirectory + "/" + htmlFileName;
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Używaj katalogów wyjściowych unikalnych dla każdego zadania eksportu, szczególnie w aplikacjach serwerowych. Wspólne ścieżki wyjściowe mogą powodować nadpisywanie plików z różnych konwersji.

## **Wydajność i zarządzanie zasobami**

Konwersja HTML jest operacją renderowania, więc czas przetwarzania i użycie pamięci zależą od liczby slajdów, rozdzielczości obrazu, czcionek, efektów, wykresów i osadzonych multimediów. Wyższe wartości DPI `PicturesCompression`, osadzone czcionki, wyjście SVG oraz zachowane przycięte obszary obrazów mogą poprawić wierność, ale zazwyczaj zwiększają rozmiar wyjścia.

Podczas konwersji wsadowej:

- Niezwłocznie zwalniaj każdą instancję [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/).
- Używaj oddzielnych katalogów wyjściowych dla oddzielnych zadań.
- Unikaj osadzania powszechnych czcionek, chyba że wymaga tego wierność.
- Obniż DPI obrazów, gdy HTML służy do podglądu lub miniatur.
- Trzymaj źródłową prezentację, wygenerowany HTML i zasoby zewnętrzne razem, aż ścieżki wdrożenia będą ostateczne.

## **FAQ**

**Czy hiperłącza są zachowywane w wyjściu HTML?**

Tak. Hiperłącza w prezentacji są eksportowane do HTML i pozostają klikalne, gdy docelowy URL jest prawidłowy.

**Czy mogę konwertować prezentacje do HTML równolegle?**

Tak, ale nie udostępniaj jednej instancji [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) między wątkami. Przetwarzaj różne pliki przy użyciu oddzielnych instancji prezentacji, oddzielnych strumieni i oddzielnych katalogów wyjściowych. Zobacz [poradnik wielowątkowości](/slides/pl/androidjava/multithreading/) po szczegóły.

**Czy obiekt Presentation jest bezpieczny wątkowo?**

Nie. Jedna instancja [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) powinna być ładowana, modyfikowana, zapisywana i zwalniana w jednym wątku. Do pracy równoległej utwórz niezależną instancję na każdy wątek lub proces.

**Dlaczego wygenerowany plik HTML jest duży?**

Domyślny eksport może osadzać zasoby bezpośrednio w HTML. Osadzone czcionki, obrazy o wysokim DPI, multimedia, zawartość SVG oraz zachowane przycięte obszary obrazów również zwiększają rozmiar. Używaj zasobów zewnętrznych, wykluczaj powszechne czcionki z osadzania i obniżaj `PicturesCompression`, gdy mniejszy rozmiar wyjścia jest ważniejszy niż maksymalna wierność.

**Dlaczego rozmiar czcionki w PowerPoint, np. 24 pt, pojawia się jako 17,999819 pt w HTML?**

Może to wynikać z tego, że PowerPoint i HTML używają różnych modeli DPI. PowerPoint przechowuje rozmiary tekstu w punktach typograficznych opartych na 72 DPI, podczas gdy układ HTML opiera się na pikselach CSS w modelu 96 DPI. Podczas eksportu prezentacji do HTML przez Aspose.Slides rozmiar czcionki jest przeliczany pomiędzy tymi systemami i konwersja może wprowadzić niewielkie różnice zaokrągleń.

Wartości te nie oznaczają rzeczywistej zmiany wizualnej rozmiaru czcionki. Są jedynie matematycznym skutkiem ubocznym konwersji metryk tekstu między PowerPoint a HTML.

**Jak powinienem wybrać baseUri przy eksporcie multimediów?**

Wybierz `baseUri` z perspektywy przeglądarki i przekaż go jako absolutny URI. Do podglądu lokalnego możesz go uzyskać z katalogu wyjściowego przy użyciu `mediaDirectory.toUri().toString()`. Dla wdrożenia użyj absolutnego URL opublikowanego katalogu multimedialnego. Systemowy `path` i przeglądarkowy `baseUri` nie muszą być tym samym ciągiem, ale muszą opisywać tę samą lokalizację zasobu.

**Czy mogę uwzględnić ukryte slajdy?**

Tak. Ustaw `ShowHiddenSlides` na `true` w [HtmlOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/htmloptions/), gdy ukryte slajdy muszą być eksportowane.