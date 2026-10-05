---
title: Převod prezentací do HTML5 v Pythonu
linktitle: Prezentace do HTML5
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
- uložit PPT jako HTML5
- uložit PPTX jako HTML5
- uložit ODP jako HTML5
- exportovat PPT do HTML5
- exportovat PPTX do HTML5
- exportovat ODP do HTML5
- Python
- Aspose.Slides
description: "Exportujte prezentace PowerPoint a OpenDocument do responzivního HTML5 pomocí Aspose.Slides pro Python přes .NET. Zachovejte formátování, animace a interaktivitu."
---
## **Přehled**

Tento článek vysvětluje, jak převést prezentace PowerPoint do HTML5 pomocí Aspose.Slides pro Python prostřednictvím .NET. Pokrývá základní export, řízení animací tvarů a přechodů snímků a rozvržení komentářů. Také porovnává výstup HTML5 se SVG‑založeným výstupem standardního exportu HTML.

## **Export PowerPoint do HTML5**

Následující příklad načte prezentaci ze pracovního adresáře a uloží ji ve formátu HTML5. Používá výchozí nastavení exportu; další příklad ukazuje, jak explicitně ovládat přehrávání animací. Nahraďte vstupní cestu cestou k vaší prezentaci.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres.html", slides.export.SaveFormat.HTML5)
```

{{% alert color="info" title="Note" %}}
Kromě HTML dokumentu export zapisuje podpůrné soubory CSS a JavaScript pro stylování snímků, animace, efekty a navigaci. Uchovávejte tyto soubory spolu s HTML dokumentem při přesunu nebo publikování výstupu. Generovaná stránka také načítá jQuery a Anime.js z veřejných CDN; bez nich navigace snímků a animace nefungují.
{{% /alert %}}

Chcete‑li exportovat bez přehrávání animací tvarů nebo přechodů snímků, nastavte [animate_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) a [animate_transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/) na `False` v [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/). Tato nastavení jsou nezávislá, takže můžete povolit jedno a zakázat druhé. Příklad exportuje prezentaci s oběma typy animací zakázanými v generované stránce.
```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.animate_shapes = False
html5_options.animate_transitions = False

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres5.html", slides.export.SaveFormat.HTML5, html5_options)
```

## **Export PowerPoint do HTML**

Standardní export HTML používá odlišný způsob vykreslování: obsah snímku je reprezentován pomocí SVG uvnitř HTML stránky. Následující příklad převádí prezentaci do HTML dokumentu pomocí tohoto způsobu vykreslování.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres.html", slides.export.SaveFormat.HTML)
```

Zjednodušený markup níže ilustruje strukturu generované stránky. Prvek SVG obsahuje vykreslený obsah snímku; zástupný text představuje tento obsah a není doslovným výstupem exportu.

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
Export založený na SVG neexponuje tvary PowerPointu jako samostatné HTML elementy. Použijte export do HTML5, pokud potřebujete možnosti animací tvarů a přechodů snímků, které jsou v tomto článku předvedeny.
{{% /alert %}}

## **Export PowerPoint do zobrazení snímků HTML5**

Export do HTML5 vytváří stránku pro prohlížení a navigaci snímky prezentace v prohlížeči. Tento příklad povoluje jak [animate_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/), tak [animate_transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/), aby exportované zobrazení snímků mohlo přehrávat efekty ze zdrojové prezentace.

Použijte prezentaci, která již obsahuje animace tvarů a přechody snímků, abyste viděli efekt těchto nastavení. Povolení neznamená přidání nových efektů k snímkům, které je nemají. Po exportu otevřete generovaný HTML5 dokument v prohlížeči s dostupnými podpůrnými soubory.

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.animate_shapes = True
html5_options.animate_transitions = True

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("HTML5-slide-view.html", slides.export.SaveFormat.HTML5, html5_options)
```

## **Převod prezentace do HTML5 dokumentu s komentáři**

Můžete zahrnout existující komentáře snímků do výstupu HTML5, aby čtenáři viděli zpětnou vazbu vedle obsahu snímku. Příklad v této části předpokládá, že zdrojová prezentace obsahuje komentáře, jak je znázorněno níže. Exportuje tyto komentáře; nevytváří nové.

![Dva komentáře na snímku prezentace](two_comments_pptx.png)

Přiřaďte objekt [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/) vlastnosti [slides_layout_options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/slides_layout_options/) třídy [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/). Nastavte [comments_position](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/comments_position/) na `RIGHT` z výčtu [CommentsPositions](https://reference.aspose.com/slides/python-net/aspose.slides.export/commentspositions/), aby se komentáře umístily vpravo od každého snímku.

Následující příklad exportuje prezentaci do HTML5 s tímto rozvržením komentářů. Prezentace bez komentářů nebude mít žádný text komentáře k zobrazení.

```python
import aspose.slides as slides

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.comments_position = slides.export.CommentsPositions.RIGHT

html5_options = slides.export.Html5Options()
html5_options.slides_layout_options = layout_options

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.html", slides.export.SaveFormat.HTML5, html5_options)
```

![Komentáře ve výstupním dokumentu HTML5](two_comments_html5.png)

## **Vynechat JavaScript odkazy během exportu**

Předpokládejme, že `hyperlinks.pptx` obsahuje propojený text s cílem `javascript:alert('Hello')` a běžný odkaz `https://example.com/`. Chcete‑li během exportu vynechat JavaScript odkaz, nastavte [Html5Options.skip_java_script_links](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/skip_java_script_links/) na `True`. Výchozí hodnota je `False`, takže tyto odkazy nejsou filtrovány, pokud tuto možnost nepovolíte.

Následující příklad načte prezentaci ze pracovního adresáře a exportuje ji pomocí [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/):

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.skip_java_script_links = True

with slides.Presentation("hyperlinks.pptx") as presentation:
    presentation.save("filtered-html5.html", slides.export.SaveFormat.HTML5, html5_options)
```

Exportovaný soubor vynechává JavaScript odkaz, přičemž zachovává jeho text a běžný HTTPS odkaz. Zdrojová prezentace zůstává nezměněna.

Tato možnost filtruje JavaScript odkazy; neodstraňuje všechny skripty ani jiný aktivní obsah, ani nezaručuje soulad s CSP. Například výstup HTML5 stále zahrnuje skripty pro navigaci snímků a animace.

## **Často kladené otázky**

**Mohu řídit, zda se v HTML5 přehrávají animace objektů a přechody snímků?**

Ano, export do HTML5 poskytuje samostatné možnosti pro povolení nebo zakázání [shape animations](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) a [slide transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/).

**Jsou komentáře podporovány a kde je lze umístit vzhledem k snímku?**

Ano, existující komentáře lze zahrnout do výstupu HTML5 a umístit (například vpravo od snímku) přes [layout settings](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/slides_layout_options/) pro poznámky a komentáře.

**Mohu vynechat odkazy, které volají JavaScript, z bezpečnostních nebo CSP důvodů?**

Ano, nastavení [skip_java_script_links](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/skip_java_script_links/) umožňuje během ukládání přeskočit hypertextové odkazy s voláním JavaScriptu. Výchozí hodnota je `False`. Viz [Vynechat JavaScript odkazy během exportu](/slides/cs/python-net/export-to-html5/#exclude-javascript-hyperlinks-during-export) pro příklad exportu do HTML5 a rozsah filtru. Toto nastavení neodstraňuje JavaScript používaný HTML5 prohlížečem pro navigaci a animace.