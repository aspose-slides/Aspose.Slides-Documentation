---
title: Konwertuj prezentacje do HTML5 w Pythonie za pomocą Java
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
description: "Eksportuj prezentacje PowerPoint i OpenDocument do responsywnego HTML5 za pomocą Aspose.Slides dla Pythona poprzez Java. Zachowaj formatowanie, animacje i interaktywność."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak konwertować prezentacje PowerPoint na HTML5 przy użyciu Aspose.Slides. Obejmuje podstawowy eksport HTML5 bez dodatkowych rozszerzeń internetowych, a także opcje kontrolowania animacji kształtów i przejść slajdów. Artykuł pokazuje także standardowy proces eksportu PowerPoint do HTML, wyjaśnia, jak generować wyjście HTML5 w trybie widoku slajdów oraz prezentuje, jak dołączyć komentarze do wyeksportowanego dokumentu poprzez skonfigurowanie ich układu.

Przykłady wymagają Aspose.Slides for Python via Java oraz zgodnego środowiska uruchomieniowego Java. Umieść `pres.pptx` (lub `sample.pptx` dla przykładu z komentarzami) w bieżącym katalogu roboczym. Każdy przykład uruchamia JVM tylko wtedy, gdy nie jest już uruchomiony.

## **Eksport PowerPoint do HTML5**

Użyj [Presentation.save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#save) z [SaveFormat.Html5](https://reference.aspose.com/slides/pl/python-java/aspose.slides/saveformat/#Html5), aby wyeksportować prezentację bez dodatkowych rozszerzeń internetowych:

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

{{% alert color="info" title="Note" %}} 

Eksporter HTML5 tworzy treść HTML do wyświetlania w przeglądarce. 

{{% /alert %}}

Użyj [Html5Options](https://reference.aspose.com/slides/pl/python-java/aspose.slides/html5options/), aby skonfigurować eksport. Wywołaj [setAnimateShapes](https://reference.aspose.com/slides/pl/python-java/aspose.slides/html5options/#setAnimateShapes) i [setAnimateTransitions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/html5options/#setAnimateTransitions) z wartością `False`, aby wyłączyć animacje kształtów i przejścia slajdów:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    html5_options = Html5Options()
    html5_options.setAnimateShapes(False)
    html5_options.setAnimateTransitions(False)

    presentation.save("pres5.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **Eksport PowerPoint do HTML**

Użyj [SaveFormat.Html](https://reference.aspose.com/slides/pl/python-java/aspose.slides/saveformat/#Html) dla standardowego eksportu HTML. Zobacz [Convert PowerPoint to HTML](/slides/pl/python-java/convert-powerpoint-to-html/) po więcej opcji:

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

W tym przypadku zawartość prezentacji jest renderowana jako SVG w formie takiej jak poniżej:

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

Standardowy eksport HTML renderuje zawartość slajdu przy użyciu SVG i nie oferuje opcji animacji kształtów i przejść slajdów dostępnych w HTML5. 

{{% /alert %}}

## **Eksport PowerPoint do widoku slajdów HTML5**

**Aspose.Slides** umożliwia konwersję prezentacji PowerPoint na dokument HTML5, w którym slajdy są wyświetlane w trybie widoku slajdów. W takim przypadku, po otwarciu wygenerowanego pliku HTML5 w przeglądarce, zobaczysz prezentację w trybie widoku slajdów na stronie internetowej.

Poniższy kod Pythona demonstruje proces eksportu PowerPoint do widoku slajdów HTML5:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    html5_options = Html5Options()
    html5_options.setAnimateShapes(True)
    html5_options.setAnimateTransitions(True)

    presentation.save("HTML5-slide-view.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **Konwersja prezentacji na dokumenty HTML5 z komentarzami**

Komentarze w PowerPoint to narzędzie, które pozwala użytkownikom zostawiać notatki lub opinie na slajdach prezentacji. Są szczególnie przydatne w projektach współpracy, gdzie wiele osób może dodawać swoje sugestie lub uwagi do konkretnych elementów slajdu bez zmieniania głównej treści. Każdy komentarz wyświetla nazwę autora, co ułatwia śledzenie, kto zostawił daną uwagę.

Załóżmy, że mamy następującą prezentację PowerPoint zapisaną w pliku „sample.pptx”.

![Two comments on the presentation slide](two_comments_pptx.png)

Podczas konwersji prezentacji PowerPoint na dokument HTML5 możesz łatwo określić, czy uwzględnić komentarze z prezentacji w dokumencie wyjściowym. Aby to zrobić, przekaż parametry wyświetlania komentarzy do metody [setSlidesLayoutOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) klasy [Html5Options](https://reference.aspose.com/slides/pl/python-java/aspose.slides/html5options/).

Użyj [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/notescommentslayoutingoptions/) oraz [setCommentsPosition](https://reference.aspose.com/slides/pl/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) z [CommentsPositions.Right](https://reference.aspose.com/slides/pl/python-java/aspose.slides/commentspositions/#Right). Poniższy przykład kodu konwertuje prezentację na dokument HTML5 z komentarzami wyświetlanymi po prawej stronie slajdów.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, NotesCommentsLayoutingOptions, Html5Options, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setCommentsPosition(CommentsPositions.Right)

    html5_options = Html5Options()
    html5_options.setSlidesLayoutOptions(layout_options)

    presentation.save("output.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

Dokument „output.html” jest pokazany na obrazku poniżej.

![The comments in the output HTML5 document](two_comments_html5.png)

## **FAQ**

**Czy mogę kontrolować, czy animacje obiektów i przejścia slajdów będą odtwarzane w HTML5?**

Tak, HTML5 udostępnia oddzielne opcje włączania lub wyłączania [animacji kształtów](https://reference.aspose.com/slides/pl/python-java/aspose.slides/html5options/#setAnimateShapes) oraz [przejść slajdów](https://reference.aspose.com/slides/pl/python-java/aspose.slides/html5options/#setAnimateTransitions).

**Czy obsługa wyjścia z komentarzami jest dostępna i gdzie można je umieścić względem slajdu?**

Tak, komentarze mogą być dodane w HTML5 i umieszczone (na przykład po prawej stronie slajdu) za pomocą [ustawień układu](https://reference.aspose.com/slides/pl/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) dla notatek i komentarzy.

**Czy mogę pominąć linki wywołujące JavaScript ze względów bezpieczeństwa lub CSP?**

Tak, istnieje [ustawienie](https://reference.aspose.com/slides/pl/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks), które pozwala pominąć hiperłącza z wywołaniami JavaScript podczas zapisu. Usuwa to takie hiperłącza; nie gwarantuje jednak, że wszystkie wygenerowane skrypty HTML5 spełniają politykę Content Security Policy witryny.