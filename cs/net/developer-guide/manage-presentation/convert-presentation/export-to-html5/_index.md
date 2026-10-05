---
title: Převod prezentací do HTML5 v .NET
linktitle: Prezentace do HTML5
type: docs
weight: 40
url: /cs/net/export-to-html5/
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
- .NET
- C#
- Aspose.Slides
description: "Exportujte prezentace PowerPoint a OpenDocument do responzivního HTML5 pomocí Aspose.Slides pro .NET. Zachovejte formátování, animace a interaktivitu."
---
## **Přehled**

Tento článek vysvětluje, jak převést prezentace PowerPoint do HTML5 pomocí Aspose.Slides pro .NET. Pokrývá základní export, řízení animací tvarů a přechodů snímků a rozvržení komentářů. Také porovnává výstup HTML5 s výstupem založeným na SVG při standardním exportu HTML.

## **Export PowerPoint do HTML5**

Následující příklad načte prezentaci z pracovního adresáře a uloží ji ve formátu HTML5. Používá výchozí nastavení exportu; další příklad ukazuje, jak explicitně řídit přehrávání animací. Nahraďte vstupní cestu cestou k vaší prezentaci.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres.html", SaveFormat.Html5);
```

{{% alert color="info" title="Note" %}}
Kromě HTML dokumentu export zapisuje podpůrné soubory CSS a JavaScript pro stylování snímků, animace, efekty a navigaci. Uchovávejte tyto soubory spolu s HTML dokumentem při přesunu nebo publikaci výstupu. Generovaná stránka také načítá jQuery a Anime.js z veřejných CDN; bez nich nefunguje navigace mezi snímky ani animace.
{{% /alert %}}

Aby se export neprováděly animace tvarů ani přechody snímků, nastavte [AnimateShapes](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) a [AnimateTransitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/) na `false` v [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/). Tato nastavení jsou nezávislá, takže můžete povolit jedno a zakázat druhé. Příklad exportuje prezentaci s oběma typy animací zakázanými v generované stránce.

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

## **Export PowerPoint do HTML**

Standardní export do HTML používá odlišný přístup k renderování: obsah snímků je reprezentován jako SVG uvnitř HTML stránky. Následující příklad převádí prezentaci do HTML dokumentu pomocí tohoto přístupu k renderování.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres.html", SaveFormat.Html);
```

Níže uvedený zjednodušený markup ilustruje strukturu generované stránky. Prvek SVG obsahuje vykreslený obsah snímku; text zástupného symbolu představuje tento obsah a není doslovným výstupem exportu.

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
Export založený na SVG neodhaluje tvary PowerPointu jako jednotlivé HTML prvky. Použijte export do HTML5, pokud potřebujete možnosti animace tvarů a přechodů snímků, které jsou v tomto článku předvedeny.
{{% /alert %}}

## **Export PowerPoint do HTML5 zobrazení snímků**

Export do HTML5 vytvoří stránku pro prohlížení a navigaci snímků prezentace v prohlížeči. Tento příklad povoluje jak [AnimateShapes](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) tak [AnimateTransitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/), aby exportované zobrazení snímků mohlo přehrávat efekty ze zdrojové prezentace.

Použijte prezentaci, která již obsahuje animace tvarů a přechody snímků, abyste viděli efekt těchto nastavení. Povolení neznamená přidání nových efektů do snímků, které žádné nemají. Po exportu otevřete generovaný HTML5 dokument v prohlížeči se dostupnými podpůrnými soubory.

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

## **Převod prezentace do HTML5 dokumentu s komentáři**

Můžete zahrnout existující komentáře ke snímkům do výstupu HTML5, aby čtenáři viděli zpětnou vazbu vedle obsahu snímku. Příklad v této sekci předpokládá, že zdrojová prezentace obsahuje komentáře, jak je znázorněno níže. Exportuje tyto komentáře; nevytváří nové.

![Dva komentáře na snímku prezentace](two_comments_pptx.png)

Přiřaďte objekt [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/) k vlastnosti [SlidesLayoutOptions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/slideslayoutoptions/) třídy [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/). Nastavte [CommentsPosition](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/commentsposition/) na `Right` z výčtu [CommentsPositions](https://reference.aspose.com/slides/net/aspose.slides.export/commentspositions/), aby se komentáře umístily vpravo od každého snímku.

Následující příklad exportuje prezentaci do HTML5 s tímto rozvržením komentářů. Prezentace bez komentářů nebude obsahovat žádný text komentáře k zobrazení.

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

Obrázek níže ukazuje exportovaný HTML5 dokument s komentáři zobrazenými vedle snímku.

![Komentáře ve výstupním HTML5 dokumentu](two_comments_html5.png)

## **Vyloučit JavaScriptové hypertextové odkazy během exportu**

Předpokládejme, že `hyperlinks.pptx` obsahuje propojený text s cílem `javascript:alert('Hello')` a běžný odkaz `https://example.com/`. Chcete-li během exportu vyloučit JavaScriptový hypertextový odkaz, nastavte [SaveOptions.SkipJavaScriptLinks](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) na `true`. Výchozí hodnota je `false`, takže tyto odkazy nejsou filtrovány, pokud nepovolíte tuto možnost.

Následující příklad načte prezentaci z pracovního adresáře a exportuje ji pomocí [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/):

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options { SkipJavaScriptLinks = true };

using var presentation = new Presentation("hyperlinks.pptx");
presentation.Save("filtered-html5.html", SaveFormat.Html5, html5Options);
```

Exportovaný soubor vynechává JavaScriptový hypertextový odkaz, přičemž zachovává jeho text a běžný HTTPS odkaz. Zdrojová prezentace zůstává nezměněna.

Tato možnost filtruje JavaScriptové hypertextové odkazy; neodstraňuje všechny skripty nebo jiný aktivní obsah a také nezaručuje soulad s CSP. Například výstup HTML5 stále zahrnuje skripty pro navigaci mezi snímky a animace.

## **FAQ**

**Mohu kontrolovat, zda se animace objektů a přechody snímků v HTML5 přehrávají?**

Ano, export do HTML5 poskytuje samostatné možnosti pro povolení nebo zakázání [animace tvarů](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) a [přechody snímků](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/).

**Jsou komentáře podporovány a kde je lze umístit vzhledem ke snímku?**

Ano, existující komentáře lze zahrnout do výstupu HTML5 a umístit (například vpravo od snímku) pomocí [nastavení rozvržení](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/slideslayoutoptions/) pro poznámky a komentáře.

**Mohu přeskočit odkazy, které volají JavaScript, z bezpečnostních nebo CSP důvodů?**

Ano, nastavení [SkipJavaScriptLinks](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) vám umožní během ukládání přeskočit hypertextové odkazy s voláním JavaScriptu. Výchozí hodnota je `false`. Viz [Vyloučit JavaScriptové hypertextové odkazy během exportu](/slides/cs/net/export-to-html5/#exclude-javascript-hyperlinks-during-export) pro jednoduchý příklad exportu do HTML, HTML5 a PDF a rozsah filtru. Toto nastavení neodstraňuje JavaScript používaný prohlížečem HTML5 pro navigaci a animace.