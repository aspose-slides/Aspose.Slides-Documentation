---
title: Konwertuj prezentacje do HTML5 w JavaScript
linktitle: Prezentacja do HTML5
type: docs
weight: 40
url: /pl/nodejs-java/export-to-html5/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Eksportuj prezentacje PowerPoint i OpenDocument do responsywnego HTML5 z Aspose.Slides dla Node.js. Zachowaj formatowanie, animacje i interaktywność."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak konwertować prezentacje PowerPoint do formatu HTML5 przy użyciu Aspose.Slides dla Node.js za pośrednictwem Javy. Obejmuje podstawowy eksport, kontrolę animacji kształtów i przejść slajdów oraz układ komentarzy. Porównuje także wynikowy HTML5 z wyjściem opartym na SVG standardowego eksportu HTML.

## **Eksportuj PowerPoint do HTML5**

Poniższy przykład wczytuje prezentację z katalogu roboczego i zapisuje ją w formacie HTML5. Używa domyślnych ustawień eksportu; kolejny przykład pokazuje, jak jawnie kontrolować odtwarzanie animacji. Zamień ścieżkę wejściową na ścieżkę do swojej prezentacji.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres.html", aspose.slides.SaveFormat.Html5);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Oprócz dokumentu HTML, eksport zapisuje dodatkowe pliki CSS i JavaScript służące do stylizacji slajdów, animacji, efektów i nawigacji. Trzymaj te pliki razem z dokumentem HTML przy przenoszeniu lub publikowaniu wyniku. Wygenerowana strona również ładuje jQuery i Anime.js z publicznych CDN; bez nich nawigacja po slajdach i animacje nie działają.
{{% /alert %}}

Aby wyeksportować bez odtwarzania animacji kształtów lub przejść slajdów, przekaż `false` do [setAnimateShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-) i [setAnimateTransitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-) w [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/). Te ustawienia są niezależne, więc możesz włączyć jedno, wyłączając drugie. Przykład eksportuje prezentację z wyłączonymi obiema typami animacji w wygenerowanej stronie.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setAnimateShapes(false);
html5Options.setAnimateTransitions(false);

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **Eksportuj PowerPoint do HTML**

Standardowy eksport HTML używa innego podejścia renderowania: zawartość slajdu jest reprezentowana przez SVG wewnątrz strony HTML. Poniższy przykład konwertuje prezentację do dokumentu HTML przy użyciu tego podejścia renderowania.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres.html", aspose.slides.SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Uproszczony znacznik poniżej ilustruje strukturę wygenerowanej strony. Element SVG zawiera wyrenderowaną zawartość slajdu; tekst zastępczy reprezentuje tę zawartość i nie jest rzeczywistym wynikiem eksportu.

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
Eksport oparty na SVG nie udostępnia kształtów PowerPoint jako pojedynczych elementów HTML. Użyj eksportu HTML5, gdy potrzebujesz opcji animacji kształtów i przejść slajdów przedstawionych w tym artykule.
{{% /alert %}}

## **Eksportuj PowerPoint do widoku slajdów HTML5**

Eksport HTML5 tworzy stronę do przeglądania i nawigacji po slajdach prezentacji w przeglądarce. Ten przykład włącza zarówno [setAnimateShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-) jak i [setAnimateTransitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-), aby wyświetlany widok slajdów mógł odtwarzać efekty z oryginalnej prezentacji.

Użyj prezentacji, która już zawiera animacje kształtów i przejścia slajdów, aby zobaczyć efekt tych ustawień. Ich włączenie nie dodaje nowych efektów do slajdów, które ich nie mają. Po eksporcie otwórz wygenerowany dokument HTML5 w przeglądarce z dostępnymi plikami pomocniczymi.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setAnimateShapes(true);
html5Options.setAnimateTransitions(true);

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("HTML5-slide-view.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **Konwertuj prezentację na dokument HTML5 z komentarzami**

Możesz uwzględnić istniejące komentarze slajdów w wyjściu HTML5, aby czytelnicy mogli zobaczyć opinie obok zawartości slajdu. Przykład w tej sekcji zakłada, że źródłowa prezentacja zawiera komentarze, co ilustruje poniższy przykład. Eksportuje te komentarze; nie tworzy nowych.

![Dwa komentarze na slajdzie prezentacji](two_comments_pptx.png)

Przekaż obiekt [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notescommentslayoutingoptions/) do metody [setSlidesLayoutOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setSlidesLayoutOptions-aspose.slides.ISlidesLayoutOptions-) klasy [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/). Użyj [setCommentsPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition-int-) aby wybrać `Right` z wyliczenia [CommentsPositions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentspositions/), aby umieścić komentarze po prawej stronie każdego slajdu.

Poniższy przykład eksportuje prezentację do HTML5 z tym układem komentarzy. Prezentacja bez komentarzy nie będzie miała żadnego tekstu komentarza do wyświetlenia.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);

const html5Options = new aspose.slides.Html5Options();
html5Options.setSlidesLayoutOptions(layoutOptions);

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

![Komentarze w wygenerowanym dokumencie HTML5](two_comments_html5.png)

## **Wyklucz hiperłącza JavaScript podczas eksportu**

Załóżmy, że `hyperlinks.pptx` zawiera tekst z odnośnikiem `javascript:alert('Hello')` oraz zwykły odnośnik `https://example.com/`. Aby wykluczyć hiperłącze JavaScript podczas eksportu, przekaż `true` do [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-). Domyślna wartość to `false`, więc te odnośniki nie są filtrowane, chyba że włączysz tę opcję.

Poniższy przykład wczytuje prezentację z katalogu roboczego i eksportuje ją przy użyciu [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setSkipJavaScriptLinks(true);

const presentation = new aspose.slides.Presentation("hyperlinks.pptx");
try {
    presentation.save("filtered-html5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

Wyeksportowany plik pomija hiperłącze JavaScript, zachowując jednocześnie jego tekst i zwykły odnośnik HTTPS. Źródłowa prezentacja pozostaje niezmieniona.

Ta opcja filtruje hiperłącza JavaScript; nie usuwa wszystkich skryptów ani innej aktywnej zawartości, ani nie gwarantuje zgodności z CSP. Na przykład wyjście HTML5 nadal zawiera skrypty do nawigacji po slajdach i animacji.

## **FAQ**

**Czy mogę kontrolować, czy animacje obiektów i przejścia slajdów będą odtwarzane w HTML5?**

Tak, eksport HTML5 udostępnia osobne opcje włączania lub wyłączania [shape animations](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-) i [slide transitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-).

**Czy komentarze są obsługiwane i gdzie mogą być umieszczone względem slajdu?**

Tak, istniejące komentarze mogą być uwzględnione w wyjściu HTML5 i umieszczone (na przykład po prawej stronie slajdu) za pomocą [layout settings](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setSlidesLayoutOptions-aspose.slides.ISlidesLayoutOptions-) dla notatek i komentarzy.

**Czy mogę pominąć odnośniki wywołujące JavaScript ze względów bezpieczeństwa lub CSP?**

Tak, ustawienie [setSkipJavaScriptLinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) pozwala pominąć hiperłącza z wywołaniami JavaScript podczas zapisywania. Domyślna wartość to `false`. Zobacz [Exclude JavaScript Hyperlinks During Export](/slides/pl/nodejs-java/export-to-html5/#exclude-javascript-hyperlinks-during-export) po przykład eksportu HTML5 i zakres filtru. To ustawienie nie usuwa JavaScript używanego przez przeglądarkę HTML5 do nawigacji i animacji.