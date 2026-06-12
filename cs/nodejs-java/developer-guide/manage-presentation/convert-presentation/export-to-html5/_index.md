---
title: Převod prezentací do HTML5 v JavaScriptu
linktitle: Prezentace do HTML5
type: docs
weight: 40
url: /cs/nodejs-java/export-to-html5/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Exportujte prezentace PowerPoint a OpenDocument do responzivního HTML5 pomocí Aspose.Slides pro Node.js. Zachovejte formátování, animace a interaktivitu."
---
## **Přehled**

Tento článek vysvětluje, jak převést prezentace PowerPoint do HTML5 pomocí Aspose.Slides. Popisuje základní export do HTML5 bez webových rozšíření nebo dalších závislostí, stejně jako možnosti řízení animací tvarů a přechodů mezi snímky. Článek také ukazuje standardní proces exportu z PowerPointu do HTML, vysvětluje, jak vygenerovat výstup HTML5 v režimu zobrazení snímků, a demonstruje, jak zahrnout komentáře do exportovaného dokumentu nastavením jejich rozložení.

## **Export PowerPoint do HTML5**

Tento JavaScriptový kód ukazuje, jak exportovat prezentaci do HTML5 bez webových rozšíření a závislostí:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.html", aspose.slides.SaveFormat.Html5);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" %}} 
V tomto případě získáte čistý HTML. 
{{% /alert %}}

Můžete také zadat nastavení pro animace tvarů a přechody snímků tímto způsobem:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var html5Options = new aspose.slides.Html5Options();
    html5Options.setAnimateShapes(false);
    html5Options.setAnimateTransitions(false);
    pres.save("pres5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Export PowerPoint do HTML**

Tento JavaScript demonstruje standardní proces exportu PowerPointu do HTML:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.html", aspose.slides.SaveFormat.Html);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
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

{{% alert title="Note" color="warning" %}} 
Při použití této metody pro export PowerPointu do HTML nebudete moci aplikovat styly ani animovat konkrétní prvky kvůli vykreslování SVG. 
{{% /alert %}}

## **Export PowerPoint do HTML5 zobrazení snímků**

**Aspose.Slides** umožňuje převést prezentaci PowerPoint do HTML5 dokumentu, ve kterém jsou snímky prezentovány v režimu zobrazení snímků. V takovém případě, když otevřete výsledný soubor HTML5 v prohlížeči, zobrazí se prezentace v režimu zobrazení snímků na webové stránce.

Tento JavaScriptový kód demonstruje proces exportu PowerPointu do HTML5 v režimu zobrazení snímků:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var html5Options = new aspose.slides.Html5Options();
    html5Options.setAnimateShapes(true);
    html5Options.setAnimateTransitions(true);
    pres.save("HTML5-slide-view.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Převod prezentace do HTML5 dokumentu s komentáři**

Komentáře v PowerPointu jsou nástrojem, který uživatelům umožňuje zanechat poznámky nebo zpětnou vazbu na snímcích prezentace. Jsou zvláště užitečné v kolaborativních projektech, kde více lidí může přidávat své návrhy nebo připomínky k jednotlivým prvkům snímku, aniž by měnili hlavní obsah. Každý komentář zobrazí jméno autora, což usnadňuje sledovat, kdo připomínku zanechal.

Předpokládejme, že máme následující prezentaci PowerPoint uloženou v souboru "sample.pptx".

![Dva komentáře na snímku prezentace](two_comments_pptx.png)

Když převádíte prezentaci PowerPoint do HTML5 dokumentu, můžete snadno určit, zda zahrnout komentáře z prezentace do výstupního dokumentu. K tomu je potřeba nastavit parametry zobrazení komentářů ve vlastnosti `notes_comments_layouting` třídy [Html5Options](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/html5options/).

Následující ukázkový kód převádí prezentaci do HTML5 dokumentu s komentáři zobrazenými vpravo od snímků.
```javascript
let html5Options = new aspose.slides.Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(aspose.slides.CommentsPositions.Right);

let presentation = new aspose.slides.Presentation("sample.pptx");
presentation.save("output.html", aspose.slides.SaveFormat.Html5, html5Options);
presentation.dispose();
```

Dokument "output.html" je zobrazen na obrázku níže.

![Komentáře ve výstupním HTML5 dokumentu](two_comments_html5.png)

## **Často kladené otázky**

**Mohu řídit, zda se animace objektů a přechody snímků spustí v HTML5?**  
Ano, HTML5 poskytuje samostatné možnosti pro povolení nebo zakázání [animací tvarů](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/html5options/setanimateshapes/) a [přechodů snímků](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/html5options/setanimatetransitions/).

**Je podpora výstupu komentářů k dispozici a kde mohou být umístěny vzhledem k snímku?**  
Ano, komentáře lze v HTML5 přidat a umístit (například vpravo od snímku) pomocí [nastavení rozložení](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/html5options/#setNotesCommentsLayouting) pro poznámky a komentáře.

**Mohu vynechat odkazy, které volají JavaScript, z bezpečnostních nebo CSP důvodů?**  
Ano, existuje [nastavení](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks), které umožňuje během ukládání přeskočit hypertextové odkazy s voláním JavaScriptu. To pomáhá dodržovat přísné bezpečnostní zásady.