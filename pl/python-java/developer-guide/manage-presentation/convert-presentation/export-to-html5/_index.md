---
title: Konwersja prezentacji do HTML5 w Pythonie przy użyciu Javy
linktitle: Prezentacja do HTML5
type: docs
weight: 40
url: /pl/python-java/export-to-html5/
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
- Java
- Aspose.Slides
description: "Eksportuj prezentacje PowerPoint i OpenDocument do responsywnego HTML5 przy użyciu Aspose.Slides dla Pythona przy użyciu Javy. Zachowaj formatowanie, animacje i interaktywność."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak konwertować prezentacje PowerPoint do formatu HTML5 przy użyciu Aspose.Slides dla Pythona poprzez Javę. Omówiono podstawowy eksport, kontrolę animacji kształtów i przejść slajdów oraz układ komentarzy. Porównano również wynikowy HTML5 z wyjściem opartym na SVG, które generuje standardowy eksport HTML.

Przykłady wymagają Aspose.Slides dla Pythona poprzez Javę oraz zgodnego środowiska wykonawczego Java. Umieść pliki wejściowe w bieżącym katalogu roboczym. Każdy przykład uruchamia JVM tylko wtedy, gdy nie jest już uruchomiony.

## **Eksport PowerPoint do HTML5**

Poniższy przykład wczytuje prezentację z katalogu roboczego i zapisuje ją w formacie HTML5. Używa domyślnych ustawień eksportu; kolejny przykład pokazuje, jak ręcznie kontrolować odtwarzanie animacji. Zamień ścieżkę wejściową na ścieżkę do swojej prezentacji.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres.html", SaveFormat.Html5)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Uwaga" %}}

Oprócz dokumentu HTML eksport zapisuje powiązane pliki CSS i JavaScript potrzebne do stylizacji slajdów, animacji, efektów i nawigacji. Trzymaj te pliki razem z dokumentem HTML przy przenoszeniu lub publikowaniu wyników. Generowana strona ładuje także jQuery i Anime.js z publicznych CDN‑ów; bez nich nawigacja i animacje slajdów nie będą działać.

{{% /alert %}}

Aby wyeksportować bez odtwarzania animacji kształtów lub przejść slajdów, przekaż `False` do [setAnimateShapes](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateShapes) i [setAnimateTransitions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateTransitions) w [Html5Options](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/). Ustawienia te są niezależne, więc możesz włączyć jedno, wyłączając drugie. Przykład eksportuje prezentację z wyłączonymi oboma typami animacji w wygenerowanej stronie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

html5_options = Html5Options()
html5_options.setAnimateShapes(False)
html5_options.setAnimateTransitions(False)

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres5.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **Eksport PowerPoint do HTML**

Standardowy eksport HTML używa innego podejścia renderowania: zawartość slajdu jest reprezentowana jako SVG wewnątrz strony HTML. Poniższy przykład konwertuje prezentację do dokumentu HTML przy użyciu tej metody renderowania.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres.html", SaveFormat.Html)
finally:
    presentation.dispose()
```

Uproszczony znacznik poniżej ilustruje strukturę wygenerowanej strony. Element SVG zawiera wyrenderowaną treść slajdu; tekst zastępczy przedstawia tę treść i nie jest dosłownym wynikiem eksportu.

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Ostrzeżenie" color="warning" %}}

Eksport oparty na SVG nie udostępnia kształtów PowerPoint jako oddzielnych elementów HTML. Użyj eksportu HTML5, gdy potrzebujesz opcji animacji kształtów i przejść slajdów przedstawionych w tym artykule.

{{% /alert %}}

## **Eksport PowerPoint do widoku slajdów HTML5**

Eksport HTML5 tworzy stronę umożliwiającą przeglądanie i nawigację po slajdach prezentacji w przeglądarce. Ten przykład włącza zarówno [setAnimateShapes](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateShapes), jak i [setAnimateTransitions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateTransitions), dzięki czemu wyeksportowany widok slajdów może odtwarzać efekty z oryginalnej prezentacji.

Użyj prezentacji, która już zawiera animacje kształtów i przejścia slajdów, aby zobaczyć efekt tych ustawień. Włączenie ich nie dodaje nowych efektów do slajdów, które ich nie mają. Po eksporcie otwórz wygenerowany dokument HTML5 w przeglądarce, mając dostęp do powiązanych plików.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

html5_options = Html5Options()
html5_options.setAnimateShapes(True)
html5_options.setAnimateTransitions(True)

presentation = Presentation("pres.pptx")
try:
    presentation.save("HTML5-slide-view.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **Konwertuj prezentację do dokumentu HTML5 z komentarzami**

Możesz dołączyć istniejące komentarze slajdów do wyjścia HTML5, aby czytelnicy mogli zobaczyć uwagi obok treści slajdu. Przykład w tej sekcji wymaga, aby źródłowa prezentacja zawierała komentarze, jak pokazano poniżej. Eksportuje te komentarze; nie tworzy nowych.

![Dwa komentarze na slajdzie prezentacji](two_comments_pptx.png)

Przekaż obiekt [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-java/aspose.slides/notescommentslayoutingoptions/) do metody [setSlidesLayoutOptions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) klasy [Html5Options](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/). Użyj [setCommentsPosition](https://reference.aspose.com/slides/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition), aby wybrać `Right` z wyliczenia [CommentsPositions](https://reference.aspose.com/slides/python-java/aspose.slides/commentspositions/) i umieścić komentarze po prawej stronie każdego slajdu.

Poniższy przykład eksportuje prezentację do HTML5 z takim układem komentarzy. Prezentacja bez komentarzy nie będzie zawierać tekstu komentarzy do wyświetlenia.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, Html5Options, NotesCommentsLayoutingOptions, Presentation, SaveFormat

layout_options = NotesCommentsLayoutingOptions()
layout_options.setCommentsPosition(CommentsPositions.Right)

html5_options = Html5Options()
html5_options.setSlidesLayoutOptions(layout_options)

presentation = Presentation("sample.pptx")
try:
    presentation.save("output.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

Obraz poniżej pokazuje wyeksportowany dokument HTML5 z komentarzami wyświetlanymi obok slajdu.

![Komentarze w wyjściowym dokumencie HTML5](two_comments_html5.png)

## **Wyklucz odnośniki JavaScript podczas eksportu**

Załóżmy, że `hyperlinks.pptx` zawiera tekst z odnośnikiem `javascript:alert('Hello')` oraz zwykły odnośnik `https://example.com/`. Aby wykluczyć odnośnik JavaScript podczas eksportu, przekaż `True` do [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks). Domyślnie jest to `False`, więc odnośniki nie są filtrowane, dopóki nie włączysz tej opcji.

Poniższy przykład wczytuje prezentację z katalogu roboczego i eksportuje ją przy użyciu [Html5Options](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

html5_options = Html5Options()
html5_options.setSkipJavaScriptLinks(True)

presentation = Presentation("hyperlinks.pptx")
try:
    presentation.save("filtered-html5.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

Wyeksportowany plik pomija odnośnik JavaScript, zachowując jego tekst oraz zwykły odnośnik HTTPS. Źródłowa prezentacja pozostaje niezmieniona.

Ta opcja filtruje odnośniki JavaScript; nie usuwa wszystkich skryptów ani innej aktywnej zawartości, ani nie gwarantuje zgodności z CSP. Na przykład wyjściowy HTML5 nadal zawiera skrypty niezbędne do nawigacji i animacji slajdów.

## **FAQ**

**Czy mogę kontrolować, czy animacje obiektów i przejścia slajdów będą odtwarzane w HTML5?**

Tak, eksport HTML5 oferuje oddzielne opcje włączania lub wyłączania [shape animations](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateShapes) oraz [slide transitions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateTransitions).

**Czy komentarze są obsługiwane i gdzie można je umieścić względem slajdu?**

Tak, istniejące komentarze mogą zostać dołączone do wyjścia HTML5 i umieszczone (na przykład po prawej stronie slajdu) za pomocą [layout settings](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) dla notatek i komentarzy.

**Czy mogę pominąć odnośniki wywołujące JavaScript ze względów bezpieczeństwa lub CSP?**

Tak, ustawienie [setSkipJavaScriptLinks](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) pozwala pominąć odnośniki z wywołaniami JavaScript podczas zapisu. Domyślnie jest to `False`. Zobacz [Exclude JavaScript Hyperlinks During Export](/slides/pl/python-java/export-to-html5/#exclude-javascript-hyperlinks-during-export) po przykład eksportu HTML5 i zakres filtru. To ustawienie nie usuwa JavaScript używanego przez przeglądarkę HTML5 do nawigacji i animacji.