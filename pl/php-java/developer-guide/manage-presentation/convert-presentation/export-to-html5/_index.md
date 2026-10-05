---
title: Konwertuj prezentacje do HTML5 w PHP
linktitle: Prezentacja do HTML5
type: docs
weight: 40
url: /pl/php-java/export-to-html5/
keywords:
- PowerPoint do HTML5
- OpenDocument do HTML5
- prezentacja do HTML5
- slajd do HTML5
- PPT do HTML5
- PPTX do HTML5
- ODP do HTML5
- zapisz PPT jako HTML5
- zapisz PPTX jako HTML5
- zapisz ODP jako HTML5
- eksportuj PPT do HTML5
- eksportuj PPTX do HTML5
- eksportuj ODP do HTML5
- PHP
- Aspose.Slides
description: "Eksportuj prezentacje PowerPoint i OpenDocument do responsywnego HTML5 przy użyciu Aspose.Slides dla PHP poprzez Java. Zachowaj formatowanie, animacje i interaktywność."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak konwertować prezentacje PowerPoint do formatu HTML5 przy użyciu Aspose.Slides dla PHP poprzez Java. Omówiono podstawowy eksport, kontrolę animacji kształtów i przejść slajdów oraz układ komentarzy. Porównano również wynik HTML5 z wyjściem opartym na SVG, które jest generowane przy standardowym eksporcie HTML.

## **Eksport PowerPoint do HTML5**

Poniższy przykład ładuje prezentację z katalogu roboczego i zapisuje ją w formacie HTML5. Używa domyślnych ustawień eksportu; kolejny przykład pokazuje, jak jawnie sterować odtwarzaniem animacji. Zamień ścieżkę wejściową na ścieżkę do własnej prezentacji.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("pres.html", SaveFormat::Html5);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Oprócz dokumentu HTML eksport zapisuje powiązane pliki CSS i JavaScript służące do stylizacji slajdów, animacji, efektów i nawigacji. Zachowaj te pliki razem z dokumentem HTML przy przenoszeniu lub publikowaniu wyniku. Generowana strona ładuje również jQuery i Anime.js z publicznych CDN‑ów; bez nich nawigacja po slajdach i animacje nie działają.
{{% /alert %}}

Aby wyeksportować bez odtwarzania animacji kształtów lub przejść slajdów, przekaż `false` do [setAnimateShapes](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateShapes) i [setAnimateTransitions](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateTransitions) w [Html5Options](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/). Te ustawienia są niezależne, więc możesz włączyć jedno, wyłączając drugie. Przykład eksportuje prezentację z wyłączonymi obiema rodzajami animacji w wygenerowanej stronie.

```php
use aspose\slides\Html5Options;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$html5Options = new Html5Options();
$html5Options->setAnimateShapes(false);
$html5Options->setAnimateTransitions(false);

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("pres5.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

## **Eksport PowerPoint do HTML**

Standardowy eksport HTML używa innego podejścia renderowania: zawartość slajdu jest reprezentowana przez SVG wewnątrz strony HTML. Poniższy przykład konwertuje prezentację na dokument HTML przy użyciu tego podejścia renderowania.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("pres.html", SaveFormat::Html);
} finally {
    $presentation->dispose();
}
```

Uproszczony znacznik poniżej ilustruje strukturę wygenerowanej strony. Element SVG zawiera wyrenderowaną zawartość slajdu; tekst zastępczy reprezentuje tę zawartość i nie jest literalnym wynikiem eksportu.

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Warning" color="warning" %}}
Eksport oparty na SVG nie udostępnia kształtów PowerPoint jako oddzielnych elementów HTML. Użyj eksportu HTML5, gdy potrzebujesz opcji animacji kształtów i przejść slajdów demonstrowanych w tym artykule.
{{% /alert %}}

## **Eksport PowerPoint do widoku slajdów HTML5**

Eksport HTML5 tworzy stronę do przeglądania i nawigacji po slajdach prezentacji w przeglądarce. Ten przykład włącza zarówno [setAnimateShapes](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateShapes), jak i [setAnimateTransitions](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateTransitions), aby wyeksportowany widok slajdów mógł odtwarzać efekty z oryginalnej prezentacji.

Użyj prezentacji, która już zawiera animacje kształtów i przejścia slajdów, aby zobaczyć efekt tych ustawień. Ich włączenie nie dodaje nowych efektów do slajdów, które ich nie mają. Po eksporcie otwórz wygenerowany dokument HTML5 w przeglądarce z dostępnymi plikami pomocniczymi.

```php
use aspose\slides\Html5Options;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$html5Options = new Html5Options();
$html5Options->setAnimateShapes(true);
$html5Options->setAnimateTransitions(true);

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("HTML5-slide-view.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

## **Konwertuj prezentację na dokument HTML5 z komentarzami**

Możesz uwzględnić istniejące komentarze slajdów w wyniku HTML5, aby czytelnicy mogli zobaczyć opinie obok zawartości slajdu. Przykład w tej sekcji zakłada, że źródłowa prezentacja zawiera komentarze, co ilustruje poniższy zrzut. Eksportuje on te komentarze; nie tworzy nowych.

![Dwa komentarze na slajdzie prezentacji](two_comments_pptx.png)

Przekaż obiekt [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/notescommentslayoutingoptions/) do metody [setSlidesLayoutOptions](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setSlidesLayoutOptions) klasy [Html5Options](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/). Użyj [setCommentsPosition](https://reference.aspose.com/slides/php-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition), aby wybrać `Right` z wyliczenia [CommentsPositions](https://reference.aspose.com/slides/php-java/aspose.slides/commentspositions/), co umieści komentarze po prawej stronie każdego slajdu.

Poniższy przykład eksportuje prezentację do HTML5 z tym układem komentarzy. Prezentacja bez komentarzy nie będzie zawierała tekstu komentarzy do wyświetlenia.

```php
use aspose\slides\CommentsPositions;
use aspose\slides\Html5Options;
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$layoutOptions = new NotesCommentsLayoutingOptions();
$layoutOptions->setCommentsPosition(CommentsPositions::Right);

$html5Options = new Html5Options();
$html5Options->setSlidesLayoutOptions($layoutOptions);

$presentation = new Presentation("sample.pptx");
try {
    $presentation->save("output.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

Obraz poniżej pokazuje wyeksportowany dokument HTML5 z komentarzami wyświetlanymi obok slajdu.

![Komentarze w wyjściowym dokumencie HTML5](two_comments_html5.png)

## **Wyklucz odnośniki JavaScript podczas eksportu**

Załóżmy, że `hyperlinks.pptx` zawiera tekst z odnośnikiem `javascript:alert('Hello')` oraz zwykły odnośnik `https://example.com/`. Aby wykluczyć odnośnik JavaScript podczas eksportu, przekaż `true` do [SaveOptions::setSkipJavaScriptLinks](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks). Domyślnie jest to `false`, więc te odnośniki nie są filtrowane, chyba że włączysz tę opcję.

Poniższy przykład ładuje prezentację z katalogu roboczego i eksportuje ją przy użyciu [Html5Options](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/):

```php
use aspose\slides\Html5Options;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$html5Options = new Html5Options();
$html5Options->setSkipJavaScriptLinks(true);

$presentation = new Presentation("hyperlinks.pptx");
try {
    $presentation->save("filtered-html5.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

Wyeksportowany plik pomija odnośnik JavaScript, zachowując jego tekst oraz zwykły odnośnik HTTPS. Źródłowa prezentacja pozostaje niezmieniona.

Ta opcja filtruje odnośniki JavaScript; nie usuwa wszystkich skryptów ani innych treści aktywnych oraz nie gwarantuje zgodności z CSP. Na przykład wyjście HTML5 nadal zawiera skrypty potrzebne do nawigacji po slajdach i animacji.

## **FAQ**

**Czy mogę kontrolować, czy animacje obiektów i przejścia slajdów będą odtwarzane w HTML5?**

Tak, eksport HTML5 zapewnia osobne opcje włączenia lub wyłączenia [animacji kształtów](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateShapes) i [przejść slajdów](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateTransitions).

**Czy komentarze są obsługiwane i gdzie można je umieścić względem slajdu?**

Tak, istniejące komentarze mogą być uwzględnione w wyniku HTML5 i umieszczone (na przykład po prawej stronie slajdu) poprzez [ustawienia układu](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setSlidesLayoutOptions) dla notatek i komentarzy.

**Czy mogę pominąć odnośniki wywołujące JavaScript ze względów bezpieczeństwa lub CSP?**

Tak, ustawienie [setSkipJavaScriptLinks](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) pozwala pominąć odnośniki z wywołaniami JavaScript podczas zapisu. Domyślnie jest `false`. Zobacz [Wyklucz odnośniki JavaScript podczas eksportu](/slides/pl/php-java/export-to-html5/#exclude-javascript-hyperlinks-during-export) po przykład eksportu HTML5 i zakres filtru. To ustawienie nie usuwa JavaScript używanego przez przeglądarkę HTML5 do nawigacji i animacji.