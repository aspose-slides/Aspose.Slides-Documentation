---
title: Převod prezentací do HTML5 v Pythonu
linktitle: Export do HTML5
type: docs
weight: 40
url: /cs/python-net/export-to-html5/
keywords:
- PowerPoint do HTML5
- OpenDocument do HTML5
- prezentace do HTML5
- snímek do HTML5
- PPT do HTML5
- PPTX do HTML5
- ODP do HTML5
- převést PowerPoint
- převést OpenDocument
- převést prezentaci
- převést snímek
- export HTML5
- export prezentace
- export snímku
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Exportovat prezentace PowerPoint a OpenDocument do responzivního HTML5 pomocí Aspose.Slides pro Python přes .NET. Zachovat formátování, animace a interaktivitu."
---
## **Přehled**

Tento článek vysvětluje, jak převést prezentace PowerPoint do HTML5 pomocí Aspose.Slides. Pokrývá základní export do HTML5 bez webových rozšíření nebo dalších závislostí, stejně jako možnosti řízení animací tvarů a přechodů snímků. Článek také ukazuje standardní proces exportu PowerPoint → HTML, vysvětluje, jak vygenerovat výstup HTML5 v režimu zobrazení snímků, a demonstruje, jak zahrnout komentáře do exportovaného dokumentu nakonfigurováním jejich rozvržení.

## **Export PowerPoint do HTML5**

Tento python kód ukazuje, jak exportovat prezentaci do HTML5 bez webových rozšíření a závislostí:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML5)
```

{{% alert color="primary" %}} 
V tomto případě získáte čisté HTML. 
{{% /alert %}}

Možná budete chtít tímto způsobem zadat nastavení animací tvarů a přechodů snímků:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    options = slides.export.Html5Options()
    options.animate_shapes = False
    options.animate_transitions = False

    presentation.save("index.html", slides.export.SaveFormat.HTML5, options)
```

## **Export PowerPoint do HTML**

Tento python kód demonstruje standardní proces exportu PowerPoint → HTML:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML)
```

V tomto případě je obsah prezentace vykreslen pomocí SVG ve formátu jako je tento:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Poznámka" color="warning" %}} 
Když použijete tuto metodu pro export PowerPoint do HTML, kvůli vykreslování SVG nebudete moci aplikovat styly ani animovat konkrétní prvky. 
{{% /alert %}}

## **Export PowerPoint do HTML5 v režimu zobrazení snímků**

**Aspose.Slides** umožňuje převést prezentaci PowerPoint do HTML5 dokumentu, ve kterém jsou snímky prezentovány v režimu zobrazení snímků. V tomto případě, když otevřete výsledný soubor HTML5 v prohlížeči, uvidíte prezentaci v režimu zobrazení snímků na webové stránce. 

Tento Python kód demonstruje proces exportu PowerPoint → HTML5 Slide View:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    # Exportovat prezentaci obsahující přechody snímků, animace a animace tvarů do HTML5
    options = slides.export.Html5Options()
    options.animate_shapes = True
    options.animate_transitions = True

    # Uložit prezentaci
    pres.save("HTML5-slide-view.html", slides.export.SaveFormat.HTML5, options)
```

## **Převod prezentace do HTML5 dokumentu s komentáři**

Komentáře v PowerPointu jsou nástrojem, který umožňuje uživatelům zanechat poznámky nebo zpětnou vazbu k snímkům prezentace. Jsou zvláště užitečné v kolaborativních projektech, kde může více lidí přidávat své návrhy nebo připomínky k určitým prvkům snímku, aniž by měnili hlavní obsah. Každý komentář zobrazuje jméno autora, což usnadňuje sledovat, kdo připomínku přidal.

Předpokládejme, že máme následující prezentaci PowerPoint uloženou v souboru „sample.pptx“.

![Dva komentáře na snímku prezentace](two_comments_pptx.png)

Při převodu prezentace PowerPoint do HTML5 dokumentu můžete snadno určit, zda zahrnout komentáře z prezentace do výstupního dokumentu. K tomu je třeba nastavit parametry zobrazení komentářů ve vlastnosti `notes_comments_layouting` třídy [Html5Options](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/html5options/).

Následující ukázka kódu převádí prezentaci do HTML5 dokumentu s komentáři zobrazenými vpravo od snímků.
```py
html5_options = Html5Options()
html5_options.notes_comments_layouting.comments_position = CommentsPositions.RIGHT

with Presentation("sample.pptx") as presentation:
    presentation.save("output.html", SaveFormat.HTML5, html5_options)
```

Dokument „output.html“ je zobrazen na obrázku níže.

![Komentáře ve výstupním HTML5 dokumentu](two_comments_html5.png)

## **Často kladené otázky**

**Mohu řídit, zda se v HTML5 přehrávají animace objektů a přechody snímků?**

Ano, HTML5 poskytuje samostatné možnosti pro povolení nebo zakázání [animací tvarů](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/html5options/animate_shapes/) a [přechodů snímků](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/html5options/animate_transitions/).

**Je podpora výstupu komentářů zajištěna a kde je lze umístit vzhledem k snímku?**

Ano, komentáře lze přidat v HTML5 a umístit (například vpravo od snímku) pomocí [nastavení rozvržení](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/html5options/notes_comments_layouting/) pro poznámky a komentáře.

**Mohu přeskočit odkazy, které volají JavaScript, z bezpečnostních nebo CSP důvodů?**

Ano, existuje [nastavení](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/html5options/skip_java_script_links/), které umožňuje při ukládání přeskočit hypertextové odkazy s voláním JavaScriptu. To pomáhá splnit přísné bezpečnostní politiky.