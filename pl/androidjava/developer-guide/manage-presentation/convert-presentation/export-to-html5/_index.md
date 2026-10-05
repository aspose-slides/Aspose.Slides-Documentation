---
title: Konwertuj prezentacje do HTML5 na Androidzie
linktitle: Prezentacja do HTML5
type: docs
weight: 40
url: /pl/androidjava/export-to-html5/
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
- Android
- Java
- Aspose.Slides
description: "Eksportuj prezentacje PowerPoint i OpenDocument do responsywnego HTML5 za pomocą Aspose.Slides dla Androida w Javie. Zachowaj formatowanie, animacje i interaktywność."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak konwertować prezentacje PowerPoint do formatu HTML5 za pomocą Aspose.Slides dla Androida przy użyciu Javy. Omówiono podstawowy eksport, kontrolę animacji kształtów i przejść slajdów oraz układ komentarzy. Porównano także wynik HTML5 z wynikiem opartym na SVG w standardowym eksporcie HTML.

## **Eksport PowerPoint do HTML5**

Poniższy przykład wczytuje prezentację z bieżącego katalogu i zapisuje ją w formacie HTML5. Używa domyślnych ustawień eksportu; kolejny przykład pokazuje, jak jawnie sterować odtwarzaniem animacji. Zastąp ścieżkę wejściową ścieżką do swojej prezentacji.

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
Oprócz dokumentu HTML, eksport zapisuje pomocnicze pliki CSS i JavaScript służące do stylizacji slajdów, animacji, efektów i nawigacji. Trzymaj te pliki razem z dokumentem HTML przy przenoszeniu lub publikowaniu wyniku. Wygenerowana strona ładuje również jQuery i Anime.js z publicznych CDN‑ów; bez nich nawigacja i animacje slajdów nie działają.
{{% /alert %}}

Aby wyeksportować bez odtwarzania animacji kształtów lub przejść slajdów, przekaż `false` do [setAnimateShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) i [setAnimateTransitions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) w [Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/). Te ustawienia są niezależne, więc możesz włączyć jedno, a wyłączyć drugie. Przykład eksportuje prezentację z wyłączonymi obiema typami animacji w wygenerowanej stronie.

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

## **Eksport PowerPoint do HTML**

Standardowy eksport HTML używa innego podejścia renderowania: zawartość slajdu jest przedstawiona jako SVG wewnątrz strony HTML. Poniższy przykład konwertuje prezentację na dokument HTML przy użyciu tego podejścia renderowania.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Uproszczony znacznik poniżej ilustruje strukturę wygenerowanej strony. Element SVG zawiera wyrenderowaną treść slajdu; tekst zastępczy reprezentuje tę treść i nie jest dosłownym wynikiem eksportu.

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
Eksport oparty na SVG nie udostępnia kształtów PowerPoint jako osobnych elementów HTML. Użyj eksportu HTML5, gdy potrzebujesz opcji animacji kształtów i przejść slajdów przedstawionych w tym artykule.
{{% /alert %}}

## **Eksport PowerPoint do widoku slajdów HTML5**

Eksport HTML5 tworzy stronę do przeglądania i nawigacji po slajdach prezentacji w przeglądarce. Ten przykład włącza zarówno [setAnimateShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) i [setAnimateTransitions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-), aby wyeksportowany widok slajdów mógł odtwarzać efekty z oryginalnej prezentacji.

Użyj prezentacji, która już zawiera animacje kształtów i przejścia slajdów, aby zobaczyć efekt tych ustawień. Włączenie ich nie dodaje nowych efektów do slajdów, które ich nie mają. Po eksporcie otwórz wygenerowany dokument HTML5 w przeglądarce z dostępnymi plikami pomocniczymi.

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

Możesz dołączyć istniejące komentarze slajdów do wyjścia HTML5, aby czytelnicy mogli zobaczyć uwagi obok treści slajdu. Przykład w tej sekcji zakłada, że źródłowa prezentacja zawiera komentarze, jak przedstawiono poniżej. Eksportuje te komentarze; nie tworzy nowych.

![Dwa komentarze na slajdzie prezentacji](two_comments_pptx.png)

Przekaż obiekt [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/notescommentslayoutingoptions/) do metody [setSlidesLayoutOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) klasy [Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/). Użyj [setCommentsPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/notescommentslayoutingoptions/#setCommentsPosition-int-), aby wybrać `Right` z wyliczenia [CommentsPositions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/commentspositions/) i umieścić komentarze po prawej stronie każdego slajdu.

Poniższy przykład eksportuje prezentację do HTML5 z takim układem komentarzy. Prezentacja bez komentarzy nie będzie zawierać tekstu komentarzy do wyświetlenia.

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

![Komentarze w wyjściowym dokumencie HTML5](two_comments_html5.png)

## **Wyklucz odnośniki JavaScript podczas eksportu**

Załóżmy, że `hyperlinks.pptx` zawiera tekst z odnośnikiem o docelowym adresie `javascript:alert('Hello')` oraz zwykły odnośnik `https://example.com/`. Aby wykluczyć odnośnik JavaScript podczas eksportu, przekaż `true` do [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-). Domyślnie jest to `false`, więc te odnośniki nie są filtrowane, dopóki nie włączysz tej opcji.

Poniższy przykład wczytuje prezentację z bieżącego katalogu i eksportuje ją przy użyciu [Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/):

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

Wyeksportowany plik pomija odnośnik JavaScript, zachowując jego tekst oraz zwykły odnośnik HTTPS. Źródłowa prezentacja pozostaje niezmieniona.

Ta opcja filtruje odnośniki JavaScript; nie usuwa wszystkich skryptów ani innych aktywnych treści, ani nie gwarantuje zgodności z CSP. Na przykład wyjście HTML5 wciąż zawiera skrypty do nawigacji po slajdach i animacji.

## **FAQ**

**Czy mogę kontrolować, czy animacje obiektów i przejścia slajdów będą odtwarzane w HTML5?**

Tak, eksport HTML5 udostępnia oddzielne opcje włączania lub wyłączania [animacje kształtów](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) i [przejścia slajdów](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).

**Czy komentarze są obsługiwane i gdzie można je umieścić względem slajdu?**

Tak, istniejące komentarze mogą być uwzględnione w wyjściu HTML5 i rozmieszczone (na przykład po prawej stronie slajdu) przy użyciu [ustawień układu](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) dla notatek i komentarzy.

**Czy mogę pominąć odnośniki wywołujące JavaScript ze względów bezpieczeństwa lub CSP?**

Tak, ustawienie [setSkipJavaScriptLinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) pozwala pominąć odnośniki z wywołaniami JavaScript podczas zapisu. Domyślnie jest to `false`. Zobacz [Wyklucz odnośniki JavaScript podczas eksportu](/slides/pl/androidjava/export-to-html5/#exclude-javascript-hyperlinks-during-export) dla przykładu eksportu HTML5 i zakresu filtru. To ustawienie nie usuwa JavaScript używanego przez podgląd HTML5 do nawigacji i animacji.