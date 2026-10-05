---
title: Konwertowanie prezentacji na HTML5 w Javie
linktitle: Prezentacja do HTML5
type: docs
weight: 40
url: /pl/java/export-to-html5/
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
- Java
- Aspose.Slides
description: "Eksportuj prezentacje PowerPoint i OpenDocument do responsywnego HTML5 przy użyciu Aspose.Slides for Java. Zachowaj formatowanie, animacje i interaktywność."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak konwertować prezentacje PowerPoint na HTML5 przy użyciu Aspose.Slides for Java. Omówiono podstawowy eksport, kontrolę animacji kształtów i przejść slajdów oraz układ komentarzy. Porównano również wyniki HTML5 z wyjściem opartym na SVG w standardowym eksporcie HTML.

## **Eksport prezentacji PowerPoint do HTML5**

Poniższy przykład ładuje prezentację z bieżącego katalogu i zapisuje ją w formacie HTML5. Używa domyślnych ustawień eksportu; kolejny przykład pokazuje, jak jawnie kontrolować odtwarzanie animacji. Zamień ścieżkę wejściową na ścieżkę do własnej prezentacji.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres.html", SaveFormat.Html5);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Oprócz dokumentu HTML, eksport zapisuje dodatkowe pliki CSS i JavaScript wspierające stylizację slajdów, animacje, efekty i nawigację. Trzymaj te pliki razem z dokumentem HTML przy przenoszeniu lub publikowaniu wyniku. Wygenerowana strona ładuje także jQuery i Anime.js z publicznych CDN; bez nich nawigacja i animacje slajdów nie działają.
{{% /alert %}}

Aby wyeksportować bez odtwarzania animacji kształtów lub przejść slajdów, przekaż `false` do [setAnimateShapes](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) i [setAnimateTransitions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) w [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/). Te ustawienia są niezależne, więc można włączyć jedno, wyłączając drugie. Przykład eksportuje prezentację z wyłączonymi obydwoma typami animacji w wygenerowanej stronie.

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setAnimateShapes(false);
html5Options.setAnimateTransitions(false);

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres5.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **Eksport prezentacji PowerPoint do HTML**

Standardowy eksport HTML używa innego podejścia renderowania: zawartość slajdu jest reprezentowana przez SVG wewnątrz strony HTML. Poniższy przykład konwertuje prezentację na dokument HTML przy użyciu tego podejścia renderowania.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Uproszczony znacznik poniżej ilustruje strukturę wygenerowanej strony. Element SVG zawiera wyrenderowaną zawartość slajdu; tekst zastępczy reprezentuje tę zawartość i nie jest dosłownym wynikiem eksportu.

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
Eksport oparty na SVG nie udostępnia kształtów PowerPoint jako osobnych elementów HTML. Użyj eksportu HTML5, gdy potrzebne są opcje animacji kształtów i przejść slajdów przedstawione w tym artykule.
{{% /alert %}}

## **Eksport prezentacji PowerPoint do widoku slajdów HTML5**

Eksport HTML5 tworzy stronę do przeglądania i nawigacji po slajdach prezentacji w przeglądarce. Ten przykład włącza zarówno [setAnimateShapes](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-), jak i [setAnimateTransitions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-), aby wyeksportowany widok slajdów mógł odtwarzać efekty z oryginalnej prezentacji.

Użyj prezentacji, która już zawiera animacje kształtów i przejścia slajdów, aby zobaczyć efekt tych ustawień. Włączenie ich nie dodaje nowych efektów do slajdów, które ich nie mają. Po eksporcie otwórz wygenerowany dokument HTML5 w przeglądarce, mając dostępne powiązane pliki.

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setAnimateShapes(true);
html5Options.setAnimateTransitions(true);

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **Konwertuj prezentację na dokument HTML5 z komentarzami**

Możesz dołączyć istniejące komentarze slajdów do wyjścia HTML5, aby czytelnicy mogli zobaczyć uwagi obok zawartości slajdu. Przykład w tej sekcji zakłada, że źródłowa prezentacja zawiera komentarze, jak przedstawiono poniżej. Eksportuje te komentarze; nie tworzy nowych.

![Dwa komentarze na slajdzie prezentacji](two_comments_pptx.png)

Przekaż obiekt [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/notescommentslayoutingoptions/) do metody [setSlidesLayoutOptions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) klasy [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/). Użyj [setCommentsPosition](https://reference.aspose.com/slides/java/com.aspose.slides/notescommentslayoutingoptions/#setCommentsPosition-int-), aby wybrać `Right` z wyliczenia [CommentsPositions](https://reference.aspose.com/slides/java/com.aspose.slides/commentspositions/), co umieści komentarze po prawej stronie każdego slajdu.

Poniższy przykład eksportuje prezentację do HTML5 z tym układem komentarzy. Prezentacja bez komentarzy nie będzie miała tekstu komentarzy do wyświetlenia.

```java
import com.aspose.slides.*;

NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
layoutOptions.setCommentsPosition(CommentsPositions.Right);

Html5Options html5Options = new Html5Options();
html5Options.setSlidesLayoutOptions(layoutOptions);

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

Obraz poniżej pokazuje wyeksportowany dokument HTML5 z komentarzami wyświetlanymi obok slajdu.

![Komentarze w wyjściowym dokumencie HTML5](two_comments_html5.png)

## **Wyklucz hiperłącza JavaScript podczas eksportu**

Załóżmy, że `hyperlinks.pptx` zawiera podłączony tekst z celem `javascript:alert('Hello')` oraz zwykłe łącze `https://example.com/`. Aby wykluczyć hiperłącze JavaScript podczas eksportu, przekaż `true` do [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-). Domyślnie jest to `false`, więc te łącza nie są filtrowane, chyba że włączysz opcję.

Poniższy przykład ładuje prezentację z bieżącego katalogu i eksportuje ją przy użyciu [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/):

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setSkipJavaScriptLinks(true);

Presentation presentation = new Presentation("hyperlinks.pptx");
try {
    presentation.save("filtered-html5.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

Wyeksportowany plik pomija hiperłącze JavaScript, zachowując jego tekst oraz zwykłe łącze HTTPS. Źródłowa prezentacja pozostaje niezmieniona.

Ta opcja filtruje hiperłącza JavaScript; nie usuwa wszystkich skryptów ani innej aktywnej treści, ani nie gwarantuje zgodności z CSP. Na przykład wyjście HTML5 nadal zawiera skrypty do nawigacji po slajdach i animacji.

## **FAQ**

**Czy mogę kontrolować, czy animacje obiektów i przejścia slajdów będą odtwarzane w HTML5?**  
Tak, eksport HTML5 udostępnia osobne opcje umożliwiające włączenie lub wyłączenie [animacje kształtów](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) i [przejścia slajdów](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).

**Czy obsługiwane są komentarze i gdzie można je umieścić względem slajdu?**  
Tak, istniejące komentarze mogą być dołączone do wyjścia HTML5 i umieszczone (na przykład po prawej stronie slajdu) za pomocą [ustawienia układu](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) dla notatek i komentarzy.

**Czy mogę pominąć łącza wywołujące JavaScript ze względów bezpieczeństwa lub CSP?**  
Tak, ustawienie [setSkipJavaScriptLinks](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) pozwala pominąć hiperłącza z wywołaniami JavaScript podczas zapisywania. Domyślnie jest `false`. Zobacz [Wyklucz hiperłącza JavaScript podczas eksportu](/slides/pl/java/export-to-html5/#exclude-javascript-hyperlinks-during-export) po przykład eksportu HTML5 i zakres filtru. To ustawienie nie usuwa JavaScript używanego przez przeglądarkę HTML5 do nawigacji i animacji.