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

Tento článek vysvětluje, jak převést prezentace PowerPoint do HTML5 pomocí Aspose.Slides pro Python via Java. Popisuje základní export, řízení animací tvarů a přechodů snímků a rozvržení komentářů. Dále porovnává výstup HTML5 s výstupem založeným na SVG při standardním exportu HTML.

Příklady vyžadují Aspose.Slides pro Python via Java a kompatibilní Java runtime. Umístěte vstupní prezentace do aktuálního pracovního adresáře. Každý příklad spustí JVM pouze pokud již neběží.

## **Export PowerPoint do HTML5**

Následující příklad načte prezentaci z pracovního adresáře a uloží ji ve formátu HTML5. Používá výchozí nastavení exportu; další příklad ukazuje, jak explicitně řídit přehrávání animací. Nahraďte vstupní cestu cestou k vaší prezentaci.

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
Kromě HTML dokumentu export zapisuje podporující CSS a JavaScript soubory pro stylování snímků, animace, efekty a navigaci. Uchovávejte tyto soubory spolu s HTML dokumentem při přesunu nebo publikování výstupu. Vygenerovaná stránka také načítá jQuery a Anime.js z veřejných CDN; bez nich nefunguje navigace mezi snímky ani animace.
{{% /alert %}}

Pro export bez přehrávání animací tvarů nebo přechodů snímků předávejte `False` metodám [setAnimateShapes](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateShapes) a [setAnimateTransitions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateTransitions) v [Html5Options](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/). Tato nastavení jsou nezávislá, takže můžete zapnout jedno a vypnout druhé. Příklad exportuje prezentaci s vypnutými oběma typy animací ve vygenerované stránce.

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

## **Export PowerPoint do HTML**

Standardní export do HTML používá odlišný renderovací přístup: obsah snímku je reprezentován pomocí SVG uvnitř HTML stránky. Následující příklad převádí prezentaci do HTML dokumentu pomocí tohoto renderovacího přístupu.

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

Níže uvedený zjednodušený markup ilustruje strukturu vygenerované stránky. SVG prvek obsahuje vykreslený obsah snímku; text zástupného symbolu představuje tento obsah a není doslovným výstupem exportu.

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
Export založený na SVG neukazuje tvary PowerPoint jako samostatné HTML elementy. Použijte export do HTML5, když potřebujete možnosti animace tvarů a přechodů snímků, které jsou v tomto článku předvedeny.
{{% /alert %}}

## **Export PowerPoint do HTML5 zobrazení snímků**

Export do HTML5 vytváří stránku pro prohlížení a navigaci snímky prezentace v prohlížeči. Tento příklad povoluje jak [setAnimateShapes](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateShapes), tak [setAnimateTransitions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateTransitions), aby exportované zobrazení snímků mohlo přehrávat efekty ze zdrojové prezentace.

Použijte prezentaci, která již obsahuje animace tvarů a přechody snímků, abyste viděli efekt těchto nastavení. jejich povolení nepřidá nové efekty na snímky, které žádné nemají. Po exportu otevřete vygenerovaný HTML5 dokument v prohlížeči s dostupnými podpůrnými soubory.

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

## **Převod prezentace na HTML5 dokument s komentáři**

Můžete zahrnout existující komentáře ke snímkům do výstupu HTML5, aby čtenáři viděli zpětnou vazbu vedle obsahu snímku. Příklad v této sekci předpokládá, že zdrojová prezentace obsahuje komentáře, jak je znázorněno níže. Exportuje tyto komentáře; nevytváří nové.

![Dva komentáře na snímku prezentace](two_comments_pptx.png)

Předávejte objekt [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-java/aspose.slides/notescommentslayoutingoptions/) metodě [setSlidesLayoutOptions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) třídy [Html5Options](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/). Použijte [setCommentsPosition](https://reference.aspose.com/slides/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) pro výběr `Right` z výčtu [CommentsPositions](https://reference.aspose.com/slides/python-java/aspose.slides/commentspositions/), aby se komentáře umístily vpravo od každého snímku.

Následující příklad exportuje prezentaci do HTML5 s tímto rozvržením komentářů. Prezentace bez komentářů nebude mít žádný text komentáře k zobrazení.

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

![Komentáře ve výstupním HTML5 dokumentu](two_comments_html5.png)

## **Vyloučení JavaScriptových hyperodkazů během exportu**

Předpokládejme, že `hyperlinks.pptx` obsahuje propojený text s cílem `javascript:alert('Hello')` a běžný odkaz `https://example.com/`. Pro vyloučení JavaScriptového hyperodkazu během exportu předávejte `True` metodě [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks). Výchozí hodnota je `False`, takže tyto odkazy nejsou filtrovány, pokud nepovolíte tuto možnost.

Následující příklad načte prezentaci z pracovního adresáře a exportuje ji pomocí [Html5Options](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/):

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

Exportovaný soubor vynechá JavaScriptový hyperodkaz a zachová jeho text a běžný HTTPS odkaz. Zdrojová prezentace zůstane beze změny.

Tato volba filtruje JavaScriptové hyperodkazy; neodstraňuje všechny skripty ani jiný aktivní obsah a nezaručuje shodu s CSP. Například výstup HTML5 stále obsahuje skripty pro navigaci snímků a animace.

## **Často kladené otázky**

**Mohu kontrolovat, zda se v HTML5 přehrávají animace objektů a přechody snímků?**

Ano, export do HTML5 poskytuje samostatné možnosti pro povolení nebo zakázání [animace tvarů](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateShapes) a [přechody snímků](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateTransitions).

**Jsou komentáře podporovány a kde je lze umístit vzhledem k snímku?**

Ano, existující komentáře lze zahrnout do výstupu HTML5 a umístit (například vpravo od snímku) pomocí [nastavení rozvržení](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) pro poznámky a komentáře.

**Mohu přeskočit odkazy, které volají JavaScript, z bezpečnostních nebo CSP důvodů?**

Ano, nastavení [setSkipJavaScriptLinks](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) vám umožňuje během ukládání přeskočit hyperodkazy s voláním JavaScriptu. Výchozí hodnota je `False`. Viz [Vyloučení JavaScriptových hyperodkazů během exportu](/slides/cs/python-java/export-to-html5/#exclude-javascript-hyperlinks-during-export) pro příklad exportu do HTML5 a rozsah filtru. Toto nastavení neodstraňuje JavaScript používaný prohlížečem HTML5 pro navigaci a animace.