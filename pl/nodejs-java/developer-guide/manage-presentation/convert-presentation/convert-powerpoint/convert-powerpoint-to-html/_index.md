---
title: Konwertuj prezentacje PowerPoint do HTML w Node.js
linktitle: PowerPoint do HTML
type: docs
weight: 30
url: /pl/nodejs-java/convert-powerpoint-to-html/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Konwertuj prezentacje PowerPoint do HTML w Node.js. Użyj Aspose.Slides dla Node.js poprzez Java, aby wyeksportować pliki PPT i PPTX, wybrane slajdy, notatki, czcionki, obrazy, SVG oraz multimedia."
---
## **Przegląd**

Aspose.Slides for Node.js przez Java może zapisywać prezentacje PowerPoint jako HTML bez Microsoft PowerPoint. Podstawowa konwersja to jednorazowe wczytanie [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) i wywołanie `save` z [SaveFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/saveformat/). Użyj [HtmlOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/htmloptions/) gdy potrzebujesz kontrolować układ eksportu, czcionki, obrazy, notatki, komentarze, wyjście SVG lub powiązane zasoby.

Ten przewodnik skupia się na praktycznych scenariuszach eksportu HTML:

- Eksportuj całą prezentację lub wybrane slajdy.
- Generuj HTML o stałym układzie, responsywny lub oparty na SVG.
- Dołącz notatki prelegenta i komentarze.
- Kontroluj jakość obrazu i przycięte dane obrazu.
- Osadzaj czcionki lub zapisuj pliki czcionek osobno.
- Wybierz sposób zapisu i odwoływania się do zasobów zewnętrznych oraz plików multimedialnych.

Domyślnie eksport HTML tworzy dokument HTML zawierający większość zasobów wbudowanych. Jest to wygodne przy udostępnianiu jednego pliku, ale może zwiększyć rozmiar wyjścia. Przy publikacji w sieci rozważ użycie zasobów zewnętrznych, niższego DPI obrazów i osadzanie tylko czcionek, które nie są pewnie dostępne w docelowym środowisku.

## **Konwertowanie prezentacji do HTML**

Aby wyeksportować prezentację do HTML, wczytaj ją przy pomocy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) i zapisz przy użyciu [SaveFormat.Html](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/saveformat/).

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", aspose.slides.SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Ten przykład zapisuje jeden plik HTML. Obiekt prezentacji jest zwalniany w bloku `finally`, co zwalnia uchwyty plików i zasoby renderujące po eksporcie.

## **Użycie HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/htmloptions/) jest główną klasą konfiguracyjną eksportu HTML. Typowe ustawienia obejmują:

- `SlidesLayoutOptions`: dodaje notatki, komentarze, materiały rozdawnicze lub inne informacje o układzie.
- `HtmlFormatter`: zmienia strukturę dokumentu HTML lub deleguje formatowanie do kontrolera.
- `SlideImageFormat`: zmienia sposób reprezentacji slajdów, np. jako SVG.
- `PicturesCompression`: kontroluje DPI obrazu i rozmiar wyjściowy.
- `DeletePicturesCroppedAreas`: zachowuje lub usuwa przycięte dane obrazu.
- `SvgResponsiveLayout`: sprawia, że wyeksportowana zawartość SVG dopasowuje się do swojego kontenera.
- `ShowHiddenSlides`: włącza ukryte slajdy, gdy jest to wymagane.

Poniższe sekcje prezentują najczęściej używane opcje osobno, abyś mógł połączyć tylko te, które są potrzebne w Twoim przepływie pracy.

## **Konwertowanie wybranych slajdów do HTML**

Przeciążenie `Presentation.save`, które przyjmuje numery slajdów, używa indeksów zaczynających się od 1. Pętla poniżej zapisuje każdy slajd do osobnego pliku HTML.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideCount = presentation.getSlides().size();

    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        let slideNumber = slideIndex + 1;
        let slideNumbers = java.newArray("int", [slideNumber]);
        let htmlFileName = "slide-" + slideNumber + ".html";

        presentation.save(htmlFileName, slideNumbers, aspose.slides.SaveFormat.Html);
    }
} finally {
    presentation.dispose();
}
```

Użyj tego wzorca, gdy strona internetowa lub aplikacja wymaga jednej strony HTML na slajd. Jeśli wszystkie slajdy mają mieć ten sam układ, utwórz jedną instancję [HtmlOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/htmloptions/) i przekaż ją każdemu wywołaniu `save`.

## **Tworzenie responsywnego HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/responsivehtmlcontroller/) zapewnia responsywne wyjście HTML poprzez [HtmlFormatter](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/htmlformatter/). Użyj go, gdy eksportowana strona ma lepiej dostosowywać się do szerokości przeglądarki.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let controller = new aspose.slides.ResponsiveHtmlController();
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(controller);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-responsive.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

W przypadku responsywnego układu opartego na SVG, ustaw `SvgResponsiveLayout` na [HtmlOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/htmloptions/). Jest to przydatne, gdy treść slajdu jest eksportowana jako skalowalny znacznik SVG.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setSvgResponsiveLayout(true);

    presentation.save("presentation-svg-responsive.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **Dołączanie notatek prelegenta i komentarzy**

Użyj [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/notescommentslayoutingoptions/) poprzez `HtmlOptions.setSlidesLayoutOptions`, aby włączyć notatki prelegenta lub komentarze. Notatki i komentarze są domyślnie ukryte, chyba że określisz ich pozycje.

Załóżmy, że źródłowa prezentacja zawiera notatki prelegenta:

![Slajd z notatkami prelegenta w PowerPoint](slide_with_notes.png)

Poniższy kod eksportuje treść slajdu wraz z notatkami prelegenta pod slajdem.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    layoutOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setSlidesLayoutOptions(layoutOptions);

    presentation.save("presentation-with-notes.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Wyjściowy HTML zawiera obszar notatek:

![Wyjściowy HTML ze slajdem i notatkami prelegenta](HTML_with_notes.png)

Aby wyeksportować komentarze, ustaw `CommentsPosition`, np. na `CommentsPositions.Right` lub `CommentsPositions.Bottom`. Jeśli potrzebujesz tylko komentarzy, pomiń `NotesPosition`. Jeśli potrzebujesz zarówno notatek, jak i komentarzy, ustaw obie właściwości.

## **Kontrola jakości obrazu i przyciętych obszarów**

Eksport HTML może kompresować obrazy slajdów, aby zmniejszyć rozmiar wyjścia. Ustaw `PicturesCompression` na wartość z [PicturesCompression](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/picturescompression/), gdy potrzebujesz wyższej jakości obrazu.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setPicturesCompression(aspose.slides.PicturesCompression.Dpi150);

    presentation.save("presentation-dpi-150.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Domyślnie przycięte obszary obrazów mogą być usuwane z wyeksportowanego wyjścia. Zachowuj przycięte dane tylko wtedy, gdy użytkownicy muszą mieć możliwość ich odzyskania lub inspekcji. Zachowanie ich może zwiększyć rozmiar HTML.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setDeletePicturesCroppedAreas(false);

    presentation.save("presentation-with-cropped-areas.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **Dodawanie CSS**

Dla prostego stylowania przekaż ciąg CSS do `HtmlFormatter.createDocumentFormatter`. Zmienia to otaczający dokument HTML, podczas gdy Aspose.Slides nadal renderuje zawartość slajdu.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    let formatter = aspose.slides.HtmlFormatter.createDocumentFormatter(cssRules, true);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-styled.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Dla własnego nagłówka dokumentu, powiązanego pliku CSS lub własnego znacznika wokół slajdów i kształtów, użyj [HtmlFormatter](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/htmlformatter/) z kontrolerem formatowania.

## **Osadzanie czcionek**

Jeśli w docelowym środowisku czcionki użyte w prezentacji mogą nie być zainstalowane, osadź czcionki w HTML przy pomocy [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/embedallfontshtmlcontroller/). Osadzanie poprawia wierność wizualną, ale zwiększa rozmiar wyjścia.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let fontNamesToExclude = java.newArray("java.lang.String", ["Arial"]);
    let fontController = new aspose.slides.EmbedAllFontsHtmlController(fontNamesToExclude);
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(fontController);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-embedded-fonts.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Wykluczaj czcionki tylko wtedy, gdy masz pewność, że docelowe przeglądarki lub systemy już je posiadają. Dla czcionek firmowych lub mniej popularnych osadzanie jest zazwyczaj bezpieczniejsze.

## **Łączenie plików czcionek zamiast ich osadzania**

Aby zmniejszyć rozmiar pliku HTML, możesz zapisać dane czcionki do osobnych plików WOFF i dodać reguły `@font-face` do HTML. W Node.js przez Java scenariusz ten zwykle realizowany jest małą klasą pomocniczą Java, która rozszerza [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/embedallfontshtmlcontroller/), zapisuje bajty czcionki do katalogu wyjściowego i wstrzykuje reguły `@font-face` do wygenerowanego HTML. Skompiluj tę pomocnicę, dodaj ją do ścieżki klas Node.js, a następnie utwórz jej instancję w JavaScript przy pomocy `java.newInstanceSync`.

Tworząc taką pomocnicę, wybierz dwa ścieżki celowo:

- Ścieżka wyjścia w systemie plików, gdzie zapisywane są wygenerowane pliki czcionek.
- Ścieżka URL, którą przeglądarka używa z dokumentu HTML do ładowania tych plików czcionek.

## **Zapisywanie zasobów zewnętrznie**

HTML zawierający wszystkie zasoby jest łatwy do przenoszenia, ale wbudowane zasoby Base64 mogą sprawić, że plik będzie duży. Jeśli aplikacja wymaga zewnętrznych plików obrazu, czcionki, audio lub wideo, użyj kontrolera eksportu, który zapisuje zasoby do wybranego katalogu i generuje adresy URL widoczne w przeglądarce. Utrzymuj zgodność ścieżki systemu plików i ścieżki URL z układem wdrożenia.

## **Eksportowanie plików multimedialnych**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/videoplayerhtmlcontroller/) eksportuje pliki wideo i audio oraz generuje HTML, który może je odtwarzać w przeglądarce. Jego konstruktor przyjmuje:

- `path`: katalog, w którym będą zapisywane wygenerowane pliki multimedialne.
- `fileName`: nazwa generowanego pliku HTML.
- `baseUri`: absolutny prefiks URI używany w linkach HTML do plików multimedialnych.

Jeśli plik HTML znajduje się w `html-output/presentation.html`, a pliki multimedialne są zapisywane w `html-output/media`, `path` powinien wskazywać katalog multimediów na dysku, natomiast `baseUri` powinien wskazywać ten sam katalog z perspektywy przeglądarki. Dla podglądu lokalnego możesz zbudować URI `file:///` z katalogu multimediów. Dla wdrożonej aplikacji użyj absolutnego adresu URL publikowanego katalogu multimediów.

```javascript
let fs = require("fs");
let path = require("path");

let outputDirectory = path.join(process.cwd(), "html-output");
let mediaDirectory = path.join(outputDirectory, "media");
fs.mkdirSync(mediaDirectory, { recursive: true });

let htmlFileName = "presentation.html";
let mediaBaseUri = "file:///" + mediaDirectory.replace(/\\/g, "/") + "/";

let presentation = new aspose.slides.Presentation();
try {
    let videoFilePath = path.join(process.cwd(), "intro.mp4");
    let videoBytes = Array.from(fs.readFileSync(videoFilePath));
    let videoData = java.newArray("byte", videoBytes);

    let video = presentation.getVideos().addVideo(videoData);
    let slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addVideoFrame(20, 20, 480, 270, video);

    let controller = new aspose.slides.VideoPlayerHtmlController(mediaDirectory, htmlFileName, mediaBaseUri);
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(controller);
    let svgOptions = new aspose.slides.SVGOptions(controller);
    let slideImageFormat = aspose.slides.SlideImageFormat.svg(svgOptions);

    let htmlOptions = new aspose.slides.HtmlOptions(controller);
    htmlOptions.setHtmlFormatter(formatter);
    htmlOptions.setSlideImageFormat(slideImageFormat);

    let htmlFilePath = path.join(outputDirectory, htmlFileName);
    presentation.save(htmlFilePath, aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Używaj katalogów wyjściowych unikalnych dla każdego zadania eksportu, szczególnie w aplikacjach serwerowych. Wspólne katalogi wyjściowe mogą powodować nadpisywanie plików z różnych konwersji.

## **Wydajność i zarządzanie zasobami**

Konwersja HTML jest operacją renderowania, więc czas przetwarzania i zużycie pamięci zależą od liczby slajdów, rozdzielczości obrazów, czcionek, efektów, wykresów i osadzonych mediów. Wyższe wartości DPI w `PicturesCompression`, osadzone czcionki, wyjście SVG i zachowane przycięte obszary obrazów mogą poprawić wierność, ale zazwyczaj zwiększają rozmiar wyjścia.

Dla konwersji wsadowej:

- Jak najszybciej zwalniaj każdą instancję [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
- Używaj osobnych katalogów wyjściowych dla poszczególnych zadań.
- Unikaj osadzania powszechnych czcionek, chyba że wymaga tego wierność wizualna.
- Obniż DPI obrazu, gdy HTML służy podglądowi lub miniaturkom.
- Trzymaj źródłową prezentację, wygenerowany HTML i zasoby zewnętrzne razem, aż ścieżki wdrożenia będą ostateczne.

## **FAQ**

**Czy hiperłącza są zachowywane w wyjściowym HTML?**

Tak. Hiperłącza w prezentacji są eksportowane do HTML i pozostają klikalne, gdy docelowy adres URL jest prawidłowy.

**Czy mogę konwertować prezentacje do HTML równolegle?**

Tak, ale nie udostępniaj jednej instancji [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) pomiędzy wątkami. Przetwarzaj różne pliki przy użyciu oddzielnych instancji prezentacji, oddzielnych strumieni i oddzielnych katalogów wyjściowych. Zobacz [multithreading guidance](/slides/pl/nodejs-java/multithreading/) po szczegóły.

**Czy obiekt Presentation jest bezpieczny wątkowo?**

Nie. Jedna instancja [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) powinna być wczytana, zmodyfikowana, zapisana i zwolniona w jednym wątku. Do pracy równoległej twórz niezależną instancję dla każdego wątku lub procesu.

**Dlaczego wygenerowany plik HTML jest duży?**

Domyślny eksport może osadzać zasoby bezpośrednio w HTML. Osadzone czcionki, obrazy o wysokim DPI, multimedia, zawartość SVG oraz zachowane przycięte obszary obrazów również zwiększają rozmiar. Użyj zasobów zewnętrznych, wyklucz powszechne czcionki z osadzania i obniż `PicturesCompression`, gdy mniejszy rozmiar jest ważniejszy niż maksymalna wierność.

**Dlaczego rozmiar czcionki PowerPoint 24 pt pojawia się jako 17.999819 pt w HTML?**

Może się tak stać, ponieważ PowerPoint i HTML używają różnych modeli DPI. PowerPoint przechowuje rozmiary tekstu w punktach typograficznych opartych na 72 DPI, podczas gdy układ HTML opiera się na pikselach CSS w modelu 96 DPI. Podczas eksportu Aspose.Slides przelicza rozmiar czcionki między tymi systemami, co może wprowadzić niewielkie różnice zaokrągleń.

Wartości te nie wskazują na rzeczywistą zmianę widocznego rozmiaru czcionki. Są jedynie matematycznym skutkiem ubocznym konwersji metryk tekstu między PowerPoint a HTML.

**Jak wybrać baseUri przy eksporcie multimediów?**

Wybierz `baseUri` z perspektywy przeglądarki i przekaż go jako absolutny URI. Dla podglądu lokalnego możesz go wyprowadzić z katalogu wyjściowego jako URI `file:///`. Dla wdrożenia użyj absolutnego adresu URL publikowanego katalogu multimediów. Ścieżka systemu plików `path` i `baseUri` przeglądarki nie muszą być tym samym ciągiem, ale muszą opisywać to samo położenie zasobu.

**Czy mogę uwzględnić ukryte slajdy?**

Tak. Ustaw `ShowHiddenSlides` na `true` na [HtmlOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/htmloptions/), gdy ukryte slajdy muszą być wyeksportowane.