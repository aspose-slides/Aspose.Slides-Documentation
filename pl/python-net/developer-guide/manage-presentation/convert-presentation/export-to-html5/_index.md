---
title: Konwertuj prezentacje do HTML5 w Pythonie
linktitle: Prezentacja do HTML5
type: docs
weight: 40
url: /pl/python-net/export-to-html5/
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
- Python
- Aspose.Slides
description: "Eksportuj prezentacje PowerPoint i OpenDocument do responsywnego HTML5 przy użyciu Aspose.Slides for Python via .NET. Zachowaj formatowanie, animacje i interaktywność."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak konwertować prezentacje PowerPoint do formatu HTML5 przy użyciu Aspose.Slides for Python via .NET. Opisuje podstawowy eksport, kontrolę animacji kształtów i przejść slajdów oraz układ komentarzy. Porównuje także wyjście HTML5 z wyjściem opartym na SVG w standardowym eksporcie HTML.

## **Eksportuj PowerPoint do HTML5**

Poniższy przykład ładuje prezentację z katalogu roboczego i zapisuje ją w formacie HTML5. Używa domyślnych ustawień eksportu; kolejny przykład pokazuje, jak explicite kontrolować odtwarzanie animacji. Zamień ścieżkę wejściową na ścieżkę do swojej prezentacji.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres.html", slides.export.SaveFormat.HTML5)
```

{{% alert color="info" title="Note" %}}
Oprócz dokumentu HTML eksport zapisuje wspierające pliki CSS i JavaScript służące do stylizacji slajdów, animacji, efektów i nawigacji. Trzymaj te pliki razem z dokumentem HTML podczas przenoszenia lub publikowania wyniku. Wygenerowana strona również ładuje jQuery i Anime.js z publicznych CDN‑ów; bez nich nawigacja slajdów i animacje nie działają.
{{% /alert %}}

Aby wyeksportować bez odtwarzania animacji kształtów ani przejść slajdów, ustaw [animate_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) i [animate_transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/) na `False` w [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/). Te ustawienia są niezależne, więc możesz włączyć jedno, wyłączając drugie. Przykład eksportuje prezentację z wyłączonymi oboma typami animacji w wygenerowanej stronie.

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.animate_shapes = False
html5_options.animate_transitions = False

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres5.html", slides.export.SaveFormat.HTML5, html5_options)
```

## **Eksportuj PowerPoint do HTML**

Standardowy eksport HTML używa innego podejścia renderowania: zawartość slajdu jest reprezentowana jako SVG wewnątrz strony HTML. Poniższy przykład konwertuje prezentację do dokumentu HTML przy użyciu tego sposobu renderowania.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres.html", slides.export.SaveFormat.HTML)
```

Poniższy uproszczony znacznik ilustruje strukturę wygenerowanej strony. Element SVG zawiera wyrenderowaną zawartość slajdu; tekst zastępczy reprezentuje tę zawartość i nie jest rzeczywistym wyjściem eksportu.

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
Eksport oparty na SVG nie udostępnia kształtów PowerPoint jako oddzielnych elementów HTML. Użyj eksportu HTML5, gdy potrzebujesz opcji animacji kształtów i przejść slajdów przedstawionych w tym artykule.
{{% /alert %}}

## **Eksportuj PowerPoint do widoku slajdów HTML5**

Eksport HTML5 tworzy stronę do przeglądania i nawigacji po slajdach prezentacji w przeglądarce. Ten przykład włącza zarówno [animate_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) jak i [animate_transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/), aby wyeksportowany widok slajdów mógł odtwarzać efekty z pierwotnej prezentacji.

Użyj prezentacji, która już zawiera animacje kształtów i przejścia slajdów, aby zobaczyć efekt tych ustawień. Włączenie ich nie dodaje nowych efektów do slajdów, które ich nie mają. Po eksporcie otwórz wygenerowany dokument HTML5 w przeglądarce, mając dostępne jego pliki pomocnicze.

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.animate_shapes = True
html5_options.animate_transitions = True

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("HTML5-slide-view.html", slides.export.SaveFormat.HTML5, html5_options)
```

## **Konwertuj prezentację na dokument HTML5 z komentarzami**

Możesz dołączyć istniejące komentarze slajdów do wyjścia HTML5, aby czytelnicy mogli zobaczyć opinie obok zawartości slajdu. Przykład w tej sekcji zakłada, że źródłowa prezentacja zawiera komentarze, jak pokazano poniżej. Eksportuje te komentarze; nie tworzy nowych.

![Dwa komentarze na slajdzie prezentacji](two_comments_pptx.png)

Przypisz obiekt [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/) do własności [slides_layout_options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/slides_layout_options/) klasy [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/). Ustaw [comments_position](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/comments_position/) na `RIGHT` z wyliczenia [CommentsPositions](https://reference.aspose.com/slides/python-net/aspose.slides.export/commentspositions/), aby umieścić komentarze po prawej stronie każdego slajdu.

Poniższy przykład eksportuje prezentację do HTML5 z tym układem komentarzy. Prezentacja bez komentarzy nie będzie mieć tekstu komentarza do wyświetlenia.

```python
import aspose.slides as slides

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.comments_position = slides.export.CommentsPositions.RIGHT

html5_options = slides.export.Html5Options()
html5_options.slides_layout_options = layout_options

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.html", slides.export.SaveFormat.HTML5, html5_options)
```

![Komentarze w wygenerowanym dokumencie HTML5](two_comments_html5.png)

## **Wyklucz odnośniki JavaScript podczas eksportu**

Załóżmy, że `hyperlinks.pptx` zawiera tekst z odnośnikiem prowadzącym do `javascript:alert('Hello')` oraz zwykły odnośnik `https://example.com/`. Aby wykluczyć odnośnik JavaScript podczas eksportu, ustaw [Html5Options.skip_java_script_links](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/skip_java_script_links/) na `True`. Domyślnie jest `False`, więc te odnośniki nie są filtrowane, dopóki nie włączysz tej opcji.

Poniższy przykład ładuje prezentację z katalogu roboczego i eksportuje ją przy użyciu [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/):

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.skip_java_script_links = True

with slides.Presentation("hyperlinks.pptx") as presentation:
    presentation.save("filtered-html5.html", slides.export.SaveFormat.HTML5, html5_options)
```

Wyeksportowany plik pomija odnośnik JavaScript, zachowując jego tekst oraz zwykły odnośnik HTTPS. Źródłowa prezentacja pozostaje niezmieniona.

Ta opcja filtruje odnośniki JavaScript; nie usuwa wszystkich skryptów ani innych aktywnych treści, ani nie zapewnia zgodności z CSP. Na przykład wyjście HTML5 nadal zawiera skrypty do nawigacji po slajdach i animacji.

## **FAQ**

**Czy mogę kontrolować, czy animacje obiektów i przejścia slajdów będą odtwarzane w HTML5?**

Tak, eksport HTML5 oferuje osobne opcje włączania lub wyłączania [animacje kształtów](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) oraz [przejścia slajdów](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/).

**Czy komentarze są obsługiwane i gdzie można je umieścić względem slajdu?**

Tak, istniejące komentarze mogą być dołączone do wyjścia HTML5 i rozmieszczone (na przykład po prawej stronie slajdu) za pomocą [ustawień układu](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/slides_layout_options/) dla notatek i komentarzy.

**Czy mogę pominąć odnośniki wywołujące JavaScript ze względów bezpieczeństwa lub CSP?**

Tak, ustawienie [skip_java_script_links](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/skip_java_script_links/) pozwala pominąć odnośniki z wywołaniami JavaScript podczas zapisu. Domyślnie jest `False`. Zobacz [Wyklucz odnośniki JavaScript podczas eksportu](/slides/pl/python-net/export-to-html5/#exclude-javascript-hyperlinks-during-export) po przykład eksportu HTML5 i zakres filtru. To ustawienie nie usuwa JavaScriptu używanego przez przeglądarkę HTML5 do nawigacji i animacji.