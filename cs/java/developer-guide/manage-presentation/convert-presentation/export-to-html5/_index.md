---
title: Převod prezentací do HTML5 v Javě
linktitle: Prezentace do HTML5
type: docs
weight: 40
url: /cs/java/export-to-html5/
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
- Java
- Aspose.Slides
description: "Exportujte prezentace PowerPoint a OpenDocument do responzivního HTML5 pomocí Aspose.Slides pro Java. Zachovejte formátování, animace a interaktivitu."
---
## **Přehled**

Tento článek vysvětluje, jak převést prezentace PowerPoint do HTML5 pomocí Aspose.Slides pro Java. Popisuje základní export, řízení animací tvarů a přechodů snímků a rozvržení komentářů. Také porovnává výstup HTML5 s výstupem založeným na SVG při standardním exportu HTML.

## **Export PowerPoint do HTML5**

Následující příklad načte prezentaci z pracovního adresáře a uloží ji ve formátu HTML5. Používá výchozí nastavení exportu; další příklad ukazuje, jak výslovně řídit přehrávání animací. Nahraďte vstupní cestu cestou k vaší prezentaci.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres.html", SaveFormat.Html5);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Kromě HTML dokumentu export zapisuje podporující soubory CSS a JavaScript pro stylování snímků, animace, efekty a navigaci. Uchovávejte tyto soubory spolu s HTML dokumentem při přesunu nebo publikování výstupu. Vygenerovaná stránka také načítá jQuery a Anime.js z veřejných CDN; bez nich nefunguje navigace mezi snímky ani animace.
{{% /alert %}}

Pro export bez přehrávání animací tvarů nebo přechodů snímků předávejte `false` metodám [setAnimateShapes](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) a [setAnimateTransitions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) v [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/). Tato nastavení jsou nezávislá, takže můžete povolit jedno a zakázat druhé. Příklad exportuje prezentaci s oběma typy animací zakázanými ve vygenerované stránce.

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setAnimateShapes(false);
html5Options.setAnimateTransitions(false);

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres5.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **Export PowerPoint do HTML**

Standardní export do HTML používá jiný přístup k vykreslování: obsah snímku je reprezentován pomocí SVG uvnitř HTML stránky. Následující příklad převádí prezentaci do HTML dokumentu pomocí tohoto přístupu k vykreslování.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Níže uvedený zjednodušený markup ilustruje strukturu vygenerované stránky. Prvek SVG obsahuje vykreslený obsah snímku; zástupný text představuje tento obsah a není doslovným výstupem exportu.

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
Export založený na SVG neexponuje tvary PowerPoint jako jednotlivé HTML elementy. Použijte export do HTML5, pokud potřebujete možnosti animace tvarů a přechodů snímků ukázané v tomto článku.
{{% /alert %}}

## **Export PowerPoint do HTML5 zobrazení snímků**

Export do HTML5 vytvoří stránku pro prohlížení a navigaci snímků prezentace v prohlížeči. Tento příklad povoluje jak [setAnimateShapes](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-), tak [setAnimateTransitions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-), aby exportované zobrazení snímků mohlo přehrávat efekty ze zdrojové prezentace.

Použijte prezentaci, která již obsahuje animace tvarů a přechody snímků, abyste viděli efekt těchto nastavení. Povolení nepřidá nové efekty k snímkům, které je nemají. Po exportu otevřete vygenerovaný HTML5 dokument v prohlížeči s dostupnými podpůrnými soubory.

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setAnimateShapes(true);
html5Options.setAnimateTransitions(true);

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **Převod prezentace do HTML5 dokumentu s komentáři**

Můžete zahrnout existující komentáře ke snímkům do výstupu HTML5, aby čtenáři viděli zpětnou vazbu vedle obsahu snímku. Příklad v této sekci předpokládá, že zdrojová prezentace obsahuje komentáře, jak je znázorněno níže. Exportuje tyto komentáře; nevytváří nové.

![Dva komentáře na snímku prezentace](two_comments_pptx.png)

Předávejte objekt [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/notescommentslayoutingoptions/) metodě [setSlidesLayoutOptions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) třídy [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/). Použijte [setCommentsPosition](https://reference.aspose.com/slides/java/com.aspose.slides/notescommentslayoutingoptions/#setCommentsPosition-int-) k výběru `Right` z výčtu [CommentsPositions](https://reference.aspose.com/slides/java/com.aspose.slides/commentspositions/), aby se komentáře umístily vpravo od každého snímku.

Následující příklad exportuje prezentaci do HTML5 s tímto rozvržením komentářů. Prezentace bez komentářů nebude mít žádný text komentáře k zobrazení.

```java
import com.aspose.slides.*;

NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
layoutOptions.setCommentsPosition(CommentsPositions.Right);

Html5Options html5Options = new Html5Options();
html5Options.setSlidesLayoutOptions(layoutOptions);

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

![Komentáře ve výstupním HTML5 dokumentu](two_comments_html5.png)

## **Vyloučení JavaScriptových hyperodkazů během exportu**

Předpokládejme, že `hyperlinks.pptx` obsahuje propojený text s cílem `javascript:alert('Hello')` a běžný odkaz `https://example.com/`. Pro vyloučení JavaScriptového hyperodkazu během exportu předávejte `true` metodě [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-). Výchozí hodnota je `false`, takže tyto odkazy nejsou filtrovány, pokud nepovolíte tuto možnost.

Následující příklad načte prezentaci z pracovního adresáře a exportuje ji pomocí [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/):

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setSkipJavaScriptLinks(true);

Presentation presentation = new Presentation("hyperlinks.pptx");
try {
    presentation.save("filtered-html5.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

Exportovaný soubor vynechá JavaScriptový hyperodkaz a zachová jeho text a běžný HTTPS odkaz. Zdrojová prezentace zůstane nezměněna.

Tato volba filtruje JavaScriptové hyperodkazy; neodstraňuje všechny skripty ani jiný aktivní obsah a také nezaručuje shodu s CSP. Například výstup HTML5 stále obsahuje skripty pro navigaci mezi snímky a animace.

## **Často kladené dotazy**

**Mohu řídit, zda se animace objektů a přechody snímků v HTML5 přehrávají?**

Ano, export do HTML5 poskytuje samostatné možnosti pro povolení nebo zakázání [animací tvarů](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) a [přechodů snímků](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).

**Jsou komentáře podporovány a kde je lze umístit vzhledem ke snímku?**

Ano, existující komentáře lze zahrnout do výstupu HTML5 a umístit (například vpravo od snímku) pomocí [nastavení rozvržení](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) pro poznámky a komentáře.

**Mohu přeskočit odkazy, které volají JavaScript, z bezpečnostních důvodů nebo kvůli CSP?**

Ano, nastavení [setSkipJavaScriptLinks](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) vám umožňuje přeskočit hyperodkazy s voláním JavaScriptu během ukládání. Výchozí hodnota je `false`. Viz [Vyloučení JavaScriptových hyperodkazů během exportu](/slides/cs/java/export-to-html5/#exclude-javascript-hyperlinks-during-export) pro příklad exportu do HTML5 a rozsah filtru. Toto nastavení neodstraňuje JavaScript používaný prohlížečem HTML5 pro navigaci a animace.