---
title: Převod prezentací do HTML5 v Pythonu přes Java
linktitle: Prezentace do HTML5
type: docs
weight: 40
url: /cs/python-java/export-to-html5/
keywords:
- PowerPoint do HTML5
- OpenDocument do HTML5
- prezentace do HTML5
- snímek do HTML5
- PPT do HTML5
- PPTX do HTML5
- ODP do HTML5
- uložit PPT jako HTML5
- uložit PPTX jako HTML5
- uložit ODP jako HTML5
- exportovat PPT do HTML5
- exportovat PPTX do HTML5
- exportovat ODP do HTML5
- Python
- Java
- Aspose.Slides
description: "Exportujte prezentace PowerPoint a OpenDocument do responzivního HTML5 pomocí Aspose.Slides pro Python přes Java. Zachovejte formátování, animace a interaktivitu."
---
## **Přehled**

Tento článek vysvětluje, jak převést prezentace PowerPoint do HTML5 pomocí Aspose.Slides. Popisuje základní export do HTML5 bez dalších webových rozšíření a také možnosti řízení animací tvarů a přechodů snímků. Článek také ukazuje standardní proces exportu z PowerPointu do HTML, vysvětluje, jak vygenerovat výstup HTML5 v režimu zobrazení snímků, a demonstruje, jak zahrnout komentáře do exportovaného dokumentu nastavením jejich rozložení.

Příklady vyžadují Aspose.Slides pro Python přes Java a kompatibilní Java runtime. Umístěte `pres.pptx` (nebo `sample.pptx` pro příklad s komentáři) do aktuálního pracovního adresáře. Každý příklad spustí JVM pouze pokud již neběží.

## **Export PowerPointu do HTML5**

Použijte [Presentation.save](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#save) s [SaveFormat.Html5](https://reference.aspose.com/slides/cs/python-java/aspose.slides/saveformat/#Html5) k exportu prezentace bez dalších webových rozšíření:

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

{{% alert color="info" title="Poznámka" %}} 
Exportér HTML5 vytváří HTML obsah pro prohlížení v prohlížeči. 
{{% /alert %}}

Použijte [Html5Options](https://reference.aspose.com/slides/cs/python-java/aspose.slides/html5options/) k nastavení exportu. Zavolejte [setAnimateShapes](https://reference.aspose.com/slides/cs/python-java/aspose.slides/html5options/#setAnimateShapes) a [setAnimateTransitions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/html5options/#setAnimateTransitions) s hodnotou `False` pro zakázání animací tvarů a přechodů snímků:

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

## **Export PowerPointu do HTML**

Použijte [SaveFormat.Html](https://reference.aspose.com/slides/cs/python-java/aspose.slides/saveformat/#Html) pro standardní export do HTML. Další možnosti najdete v [Převod PowerPointu do HTML](/slides/cs/python-java/convert-powerpoint-to-html/):

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

V tomto případě je obsah prezentace vykreslen pomocí SVG ve formě jako je tato:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Varování" color="warning" %}} 
Standardní export do HTML vykresluje obsah snímků pomocí SVG a neposkytuje možnosti animace tvarů a přechodů snímků v HTML5. 
{{% /alert %}}

## **Export PowerPointu do HTML5 zobrazení snímků**

**Aspose.Slides** vám umožňuje převést prezentaci PowerPoint do HTML5 dokumentu, ve kterém jsou snímky zobrazeny v režimu zobrazení snímků. V tomto případě, když otevřete výsledný soubor HTML5 v prohlížeči, uvidíte prezentaci v režimu zobrazení snímků na webové stránce.

Tento Python kód demonstruje proces exportu PowerPointu do HTML5 zobrazení snímků:

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

## **Převod prezentací do HTML5 dokumentů s komentáři**

Komentáře v PowerPointu jsou nástroj, který uživatelům umožňuje zanechat poznámky nebo zpětnou vazbu ke snímkům prezentace. Jsou zvláště užitečné v kolaborativních projektech, kde může více lidí přidávat své návrhy nebo připomínky k jednotlivým prvkům snímků, aniž by měnili hlavní obsah. Každý komentář zobrazuje jméno autora, což usnadňuje sledovat, kdo poznámku zanechal.

Řekněme, že máme následující prezentaci PowerPoint uloženou v souboru „sample.pptx“.

![Dva komentáře na snímku prezentace](two_comments_pptx.png)

Při převodu prezentace PowerPoint do HTML5 dokumentu můžete snadno určit, zda zahrnout komentáře z prezentace do výstupního dokumentu. K tomu předáte parametry zobrazování komentářů metodě [setSlidesLayoutOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) třídy [Html5Options](https://reference.aspose.com/slides/cs/python-java/aspose.slides/html5options/).

Použijte [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/notescommentslayoutingoptions/) a [setCommentsPosition](https://reference.aspose.com/slides/cs/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) s [CommentsPositions.Right](https://reference.aspose.com/slides/cs/python-java/aspose.slides/commentspositions/#Right). Následující ukázka kódu převádí prezentaci do HTML5 dokumentu s komentáři zobrazenými vpravo od snímků.

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

Dokument „output.html“ je zobrazen na obrázku níže.

![Komentáře ve výstupním HTML5 dokumentu](two_comments_html5.png)

## **Často kladené otázky**

**Mohu ovládat, zda se animace objektů a přechody snímků v HTML5 přehrají?**

Ano, HTML5 poskytuje samostatné možnosti pro povolení nebo zakázání [animací tvarů](https://reference.aspose.com/slides/cs/python-java/aspose.slides/html5options/#setAnimateShapes) a [přechodů snímků](https://reference.aspose.com/slides/cs/python-java/aspose.slides/html5options/#setAnimateTransitions).

**Je podpora výstupu komentářů zajištěna a kde lze komentáře umístit vzhledem k snímku?**

Ano, komentáře lze přidat v HTML5 a umístit (například vpravo od snímku) pomocí [nastavení rozložení](https://reference.aspose.com/slides/cs/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) pro poznámky a komentáře.

**Mohu přeskočit odkazy, které volají JavaScript, z bezpečnostních nebo CSP důvodů?**

Ano, existuje [nastavení](https://reference.aspose.com/slides/cs/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks), které umožňuje během ukládání přeskočit odkazy s voláním JavaScriptu. Toto odstraní tyto odkazy; samo o sobě však nezaručuje, že všechny vygenerované HTML5 skripty splňují Content Security Policy webu.