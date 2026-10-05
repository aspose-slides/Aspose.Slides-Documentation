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

Tento článek vysvětluje, jak převést prezentace PowerPoint do HTML5 pomocí Aspose.Slides pro Node.js přes Java. Popisuje základní export, řízení animací tvarů a přechodů snímků a rozvržení komentářů. Také porovnává výstup HTML5 s výstupem založeným na SVG při standardním exportu HTML.

## **Export PowerPoint do HTML5**

Následující příklad načte prezentaci ze pracovního adresáře a uloží ji ve formátu HTML5. Používá výchozí nastavení exportu; další příklad ukazuje, jak explicitně řídit přehrávání animací. Nahraďte vstupní cestu cestou k vaší prezentaci.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres.html", aspose.slides.SaveFormat.Html5);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Kromě HTML dokumentu export zapisuje podpůrné soubory CSS a JavaScript pro stylování snímků, animace, efekty a navigaci. Uchovejte tyto soubory spolu s HTML dokumentem při přesunu nebo publikaci výstupu. Vygenerovaná stránka také načítá jQuery a Anime.js z veřejných CDN; bez nich nefunguje navigace mezi snímky ani animace.
{{% /alert %}}

Pro export bez přehrávání animací tvarů nebo přechodů snímků předáte `false` metodám [setAnimateShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-) a [setAnimateTransitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-) v [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/). Tato nastavení jsou nezávislá, takže můžete jedno povolit a druhé zakázat. Příklad exportuje prezentaci s vypnutými oba typy animací ve vygenerované stránce.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setAnimateShapes(false);
html5Options.setAnimateTransitions(false);

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **Export PowerPoint do HTML**

Standardní export do HTML používá odlišný přístup k renderování: obsah snímku je v HTML stránce reprezentován pomocí SVG. Následující příklad převádí prezentaci do HTML dokumentu pomocí tohoto renderovacího přístupu.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres.html", aspose.slides.SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Níže uvedený zjednodušený markup ilustruje strukturu vygenerované stránky. Prvek SVG obsahuje vykreslený obsah snímku; text zástupného znaku představuje tento obsah a nejedná se o doslovný výstup exportu.

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
Export založený na SVG neukazuje tvary PowerPointu jako samostatné HTML elementy. Použijte export do HTML5, pokud potřebujete možnosti animace tvarů a přechodů snímků uvedené v tomto článku.
{{% /alert %}}

## **Export PowerPoint do HTML5 zobrazení snímků**

Export do HTML5 vytváří stránku pro prohlížení a navigaci mezi snímky prezentace v prohlížeči. Tento příklad povoluje jak [setAnimateShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-), tak [setAnimateTransitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-), aby exportované zobrazení snímků mohlo přehrávat efekty ze zdrojové prezentace.

Použijte prezentaci, která již obsahuje animace tvarů a přechody snímků, abyste viděli vliv těchto nastavení. jejich povolení nepřidá nové efekty do snímků, které žádné nemají. Po exportu otevřete vygenerovaný HTML5 dokument v prohlížeči se všemi podpůrnými soubory.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setAnimateShapes(true);
html5Options.setAnimateTransitions(true);

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("HTML5-slide-view.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **Převod prezentace do HTML5 dokumentu s komentáři**

Můžete zahrnout existující komentáře ke snímkům do výstupu HTML5, aby čtenáři viděli zpětnou vazbu vedle obsahu snímku. Příklad v této sekci předpokládá, že zdrojová prezentace obsahuje komentáře, jak je znázorněno níže. Exportuje tyto komentáře; nevytváří nové.

![Dva komentáře na snímku prezentace](two_comments_pptx.png)

Předání objektu [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notescommentslayoutingoptions/) metodě [setSlidesLayoutOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setSlidesLayoutOptions-aspose.slides.ISlidesLayoutOptions-) třídy [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/). Použijte [setCommentsPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition-int-), abyste vybrali `Right` z enumerace [CommentsPositions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentspositions/), čímž umístíte komentáře vpravo od každého snímku.

Následující příklad exportuje prezentaci do HTML5 s tímto rozvržením komentářů. Prezentace bez komentářů nebude mít žádný text komentáře k zobrazení.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);

const html5Options = new aspose.slides.Html5Options();
html5Options.setSlidesLayoutOptions(layoutOptions);

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

![Komentáře ve výstupním HTML5 dokumentu](two_comments_html5.png)

## **Vyloučení JavaScriptových hyperodkazů při exportu**

Předpokládejme, že `hyperlinks.pptx` obsahuje odkazovaný text s cílem `javascript:alert('Hello')` a běžný odkaz `https://example.com/`. Pro vyloučení JavaScriptového hyperodkazu při exportu předáte `true` metodě [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-). Výchozí hodnota je `false`, takže tyto odkazy nejsou filtrovány, pokud nepovolíte tuto možnost.

Následující příklad načte prezentaci ze pracovního adresáře a exportuje ji pomocí [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setSkipJavaScriptLinks(true);

const presentation = new aspose.slides.Presentation("hyperlinks.pptx");
try {
    presentation.save("filtered-html5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

Exportovaný soubor vynechává JavaScriptový hyperodkaz a zachovává jeho text i běžný HTTPS odkaz. Zdrojová prezentace zůstává beze změny.

Tato možnost filtruje JavaScriptové hyperodkazy; neodstraňuje všechny skripty ani jiný aktivní obsah a neposkytuje záruku souladu s CSP. Například výstup HTML5 i nadále obsahuje skripty pro navigaci mezi snímky a animace.

## **FAQ**

**Mohu ovládat, zda se animace objektů a přechody snímků v HTML5 přehrají?**

Ano, export do HTML5 nabízí samostatné možnosti pro povolení nebo zakázání [shape animations](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-) a [slide transitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-).

**Jsou komentáře podporovány a kde je lze umístit vzhledem ke snímku?**

Ano, existující komentáře mohou být zahrnuty do výstupu HTML5 a umístěny (například vpravo od snímku) prostřednictvím [layout settings](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setSlidesLayoutOptions-aspose.slides.ISlidesLayoutOptions-) pro poznámky a komentáře.

**Mohu přeskočit odkazy vyvolávající JavaScript z důvodů zabezpečení nebo CSP?**

Ano, nastavení [setSkipJavaScriptLinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) umožňuje při ukládání přeskočit hyperodkazy s voláním JavaScriptu. Výchozí hodnota je `false`. Viz [Exclude JavaScript Hyperlinks During Export](/slides/cs/nodejs-java/export-to-html5/#exclude-javascript-hyperlinks-during-export) pro příklad exportu do HTML5 a rozsah filtru. Toto nastavení neodstraňuje JavaScript používaný HTML5 prohlížečem pro navigaci a animace.