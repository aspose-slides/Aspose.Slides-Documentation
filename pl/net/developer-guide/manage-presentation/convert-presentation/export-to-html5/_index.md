---
title: Konwertuj prezentacje do HTML5 w .NET
linktitle: Prezentacja do HTML5
type: docs
weight: 40
url: /pl/net/export-to-html5/
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
- .NET
- C#
- Aspose.Slides
description: "Eksportuj prezentacje PowerPoint i OpenDocument do responsywnego HTML5 przy użyciu Aspose.Slides dla .NET. Zachowaj formatowanie, animacje i interaktywność."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak konwertować prezentacje PowerPoint do HTML5 przy użyciu Aspose.Slides dla .NET. Omówiono podstawowy eksport, kontrolę animacji kształtów i przejść slajdów oraz układ komentarzy. Porównano także wyjście HTML5 z wyjściem opartym na SVG standardowego eksportu HTML.

## **Eksport PowerPoint do HTML5**

Poniższy przykład ładuje prezentację z katalogu roboczego i zapisuje ją w formacie HTML5. Używa domyślnych ustawień eksportu; kolejny przykład pokazuje, jak kontrolować odtwarzanie animacji w sposób jawny. Zastąp ścieżkę wejściową ścieżką do swojej prezentacji.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres.html", SaveFormat.Html5);
```

{{% alert color="info" title="Note" %}}
Poza dokumentem HTML, eksport zapisuje wspierające pliki CSS i JavaScript do stylizacji slajdów, animacji, efektów i nawigacji. Trzymaj te pliki razem z dokumentem HTML przy przenoszeniu lub publikowaniu wyniku. Generowana strona również ładuje jQuery i Anime.js z publicznych CDN‑ów; bez nich nawigacja slajdów i animacje nie działają.
{{% /alert %}}

Aby wyeksportować bez odtwarzania animacji kształtów lub przejść slajdów, ustaw [AnimateShapes](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) i [AnimateTransitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/) na `false` w [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/). Te ustawienia są niezależne, więc możesz włączyć jedno, a wyłączyć drugie. Przykład eksportuje prezentację z wyłączonymi obiema typami animacji w wygenerowanej stronie.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    AnimateShapes = false,
    AnimateTransitions = false
};

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres5.html", SaveFormat.Html5, html5Options);
```

## **Eksport PowerPoint do HTML**

Standardowy eksport HTML używa innego podejścia renderowania: zawartość slajdu jest reprezentowana jako SVG wewnątrz strony HTML. Poniższy przykład konwertuje prezentację do dokumentu HTML przy użyciu tego podejścia renderowania.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres.html", SaveFormat.Html);
```

Uproszczony znacznik poniżej ilustruje strukturę wygenerowanej strony. Element SVG zawiera renderowaną zawartość slajdu; tekst zastępczy reprezentuje tę zawartość i nie jest dosłownym wynikiem eksportu.

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

Eksport HTML5 tworzy stronę do przeglądania i nawigacji po slajdach prezentacji w przeglądarce. Ten przykład włącza zarówno [AnimateShapes](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) i [AnimateTransitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/), aby wyeksportowany widok slajdów mógł odtwarzać efekty z prezentacji źródłowej.

Użyj prezentacji, która już zawiera animacje kształtów i przejścia slajdów, aby zobaczyć efekt tych ustawień. Włączenie ich nie dodaje nowych efektów do slajdów, które ich nie mają. Po eksporcie otwórz wygenerowany dokument HTML5 w przeglądarce z dostępnymi plikami pomocniczymi.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    AnimateShapes = true,
    AnimateTransitions = true
};

using var presentation = new Presentation("pres.pptx");
presentation.Save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
```

## **Konwersja prezentacji do dokumentu HTML5 z komentarzami**

Możesz uwzględnić istniejące komentarze slajdów w wyjściu HTML5, aby czytelnicy mogli zobaczyć opinie obok zawartości slajdu. Przykład w tej sekcji zakłada, że prezentacja źródłowa zawiera komentarze, jak pokazano poniżej. Eksportuje te komentarze; nie tworzy nowych.

![Dwa komentarze na slajdzie prezentacji](two_comments_pptx.png)

Przypisz obiekt [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/) do właściwości [SlidesLayoutOptions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/slideslayoutoptions/) klasy [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/). Ustaw [CommentsPosition](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/commentsposition/) na `Right` z wyliczenia [CommentsPositions](https://reference.aspose.com/slides/net/aspose.slides.export/commentspositions/), aby umieścić komentarze po prawej stronie każdego slajdu.

Poniższy przykład eksportuje prezentację do HTML5 z takim układem komentarzy. Prezentacja bez komentarzy nie będzie miała tekstu komentarza do wyświetlenia.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var layoutOptions = new NotesCommentsLayoutingOptions
{
    CommentsPosition = CommentsPositions.Right
};

var html5Options = new Html5Options
{
    SlidesLayoutOptions = layoutOptions
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.html", SaveFormat.Html5, html5Options);
```

![Komentarze w wyjściowym dokumencie HTML5](two_comments_html5.png)

## **Wykluczenie odnośników JavaScript podczas eksportu**

Załóżmy, że `hyperlinks.pptx` zawiera tekst z linkiem o docelowym adresie `javascript:alert('Hello')` oraz zwykły link `https://example.com/`. Aby wykluczyć odnośnik JavaScript podczas eksportu, ustaw [SaveOptions.SkipJavaScriptLinks](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) na `true`. Domyślnie jest `false`, więc te linki nie są filtrowane, chyba że włączysz opcję.

Poniższy przykład ładuje prezentację z katalogu roboczego i eksportuje ją przy użyciu [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/):

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options { SkipJavaScriptLinks = true };

using var presentation = new Presentation("hyperlinks.pptx");
presentation.Save("filtered-html5.html", SaveFormat.Html5, html5Options);
```

Wyeksportowany plik pomija odnośnik JavaScript, zachowując jednocześnie jego tekst oraz zwykły link HTTPS. Prezentacja źródłowa pozostaje niezmieniona.

Ta opcja filtruje odnośniki JavaScript; nie usuwa wszystkich skryptów ani innej aktywnej zawartości, ani nie gwarantuje zgodności z CSP. Na przykład wyjście HTML5 nadal zawiera skrypty do nawigacji po slajdach i animacji.

## **FAQ**

**Czy mogę kontrolować, czy animacje obiektów i przejścia slajdów będą odtwarzane w HTML5?**

Tak, eksport HTML5 udostępnia oddzielne opcje włączania lub wyłączania [animacji kształtów](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) i [przejść slajdów](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/).

**Czy komentarze są obsługiwane i gdzie można je umieścić względem slajdu?**

Tak, istniejące komentarze mogą być uwzględnione w wyjściu HTML5 i rozmieszczone (na przykład po prawej stronie slajdu) za pomocą [ustawień układu](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/slideslayoutoptions/) dla notatek i komentarzy.

**Czy mogę pominąć odnośniki wywołujące JavaScript ze względów bezpieczeństwa lub CSP?**

Tak, ustawienie [SkipJavaScriptLinks](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) umożliwia pomijanie odnośników z wywołaniami JavaScript podczas zapisywania. Domyślnie jest `false`. Zobacz [Wykluczenie odnośników JavaScript podczas eksportu](/slides/pl/net/export-to-html5/#exclude-javascript-hyperlinks-during-export) po prosty przykład eksportu HTML, HTML5 i PDF oraz zakres filtru. To ustawienie nie usuwa JavaScriptu używanego przez przeglądarkę HTML5 do nawigacji i animacji.