---
title: Převod prezentací do HTML5 v PHP
linktitle: Prezentace do HTML5
type: docs
weight: 40
url: /cs/php-java/export-to-html5/
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
- PHP
- Aspose.Slides
description: "Exportujte prezentace PowerPoint a OpenDocument do responzivního HTML5 pomocí Aspose.Slides pro PHP přes Java. Zachovejte formátování, animace a interaktivitu."
---
## **Přehled**

Tento článek vysvětluje, jak převést prezentace PowerPoint do HTML5 pomocí Aspose.Slides pro PHP přes Java. Pokrývá základní export, řízení animací tvarů a přechodů snímků a rozvržení komentářů. Také porovnává výstup HTML5 s výstupem založeným na SVG při standardním exportu do HTML.

## **Export PowerPoint do HTML5**

Následující příklad načte prezentaci z pracovního adresáře a uloží ji ve formátu HTML5. Používá výchozí nastavení exportu; další příklad ukazuje, jak explicitně řídit přehrávání animací. Nahraďte vstupní cestu cestou k vaší prezentaci.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("pres.html", SaveFormat::Html5);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Poznámka" %}}
Kromě HTML dokumentu export také vytvoří podpůrné soubory CSS a JavaScript pro stylování snímků, animace, efekty a navigaci. Uchovávejte tyto soubory spolu s HTML dokumentem při přesunu nebo publikování výstupu. Generovaná stránka také načítá jQuery a Anime.js z veřejných CDN; bez nich nefunguje navigace mezi snímky ani animace.
{{% /alert %}}

Aby byl export proveden bez přehrávání animací tvarů nebo přechodů snímků, předávejte `false` metodám [setAnimateShapes](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateShapes) a [setAnimateTransitions](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateTransitions) v [Html5Options](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/). Tato nastavení jsou nezávislá, takže můžete povolit jedno a zakázat druhé. Příklad exportuje prezentaci s oběma typy animací zakázanými v generované stránce.

```php
use aspose\slides\Html5Options;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$html5Options = new Html5Options();
$html5Options->setAnimateShapes(false);
$html5Options->setAnimateTransitions(false);

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("pres5.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

## **Export PowerPoint do HTML**

Standardní export do HTML používá odlišný způsob vykreslování: obsah snímků je reprezentován pomocí SVG v HTML stránce. Následující příklad převádí prezentaci do HTML dokumentu pomocí tohoto přístupu.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("pres.html", SaveFormat::Html);
} finally {
    $presentation->dispose();
}
```

Zjednodušený značkovací kód níže ilustruje strukturu generované stránky. Prvek SVG obsahuje vykreslený obsah snímku; zástupný text představuje tento obsah a není skutečným výstupem exportu.

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
Export založený na SVG neodhaluje tvary PowerPointu jako jednotlivé HTML elementy. Použijte export HTML5, pokud potřebujete možnosti animace tvarů a přechodů snímků ukázané v tomto článku.
{{% /alert %}}

## **Export PowerPoint do HTML5 – zobrazení snímků**

Export HTML5 vytváří stránku pro prohlížení a navigaci snímků prezentace v prohlížeči. Tento příklad povoluje jak [setAnimateShapes](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateShapes) a [setAnimateTransitions](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateTransitions), aby exportované zobrazení snímků mohlo přehrávat efekty ze zdrojové prezentace.

Použijte prezentaci, která již obsahuje animace tvarů a přechody snímků, abyste viděli účinek těchto nastavení. Povolení jich nepřidá nové efekty na snímky, které žádné nemají. Po exportu otevřete generovaný dokument HTML5 v prohlížeči s dostupnými podpůrnými soubory.

```php
use aspose\slides\Html5Options;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$html5Options = new Html5Options();
$html5Options->setAnimateShapes(true);
$html5Options->setAnimateTransitions(true);

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("HTML5-slide-view.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

## **Převod prezentace do dokumentu HTML5 s komentáři**

Můžete zahrnout existující komentáře ke snímkům do výstupu HTML5, aby čtenáři viděli připomínky vedle obsahu snímku. Příklad v této sekci předpokládá, že zdrojová prezentace obsahuje komentáře, jak je znázorněno níže. Exportuje tyto komentáře; nevytváří nové.

![Dva komentáře na snímku prezentace](two_comments_pptx.png)

Předejte objekt [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/notescommentslayoutingoptions/) metodě [setSlidesLayoutOptions](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setSlidesLayoutOptions) třídy [Html5Options](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/). Použijte [setCommentsPosition](https://reference.aspose.com/slides/php-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) a vyberte `Right` z výčtu [CommentsPositions](https://reference.aspose.com/slides/php-java/aspose.slides/commentspositions/), aby se komentáře umístily napravo od každého snímku.

Následující příklad exportuje prezentaci do HTML5 s tímto rozvržením komentářů. Prezentace bez komentářů nebude mít žádný text komentáře k zobrazení.

```php
use aspose\slides\CommentsPositions;
use aspose\slides\Html5Options;
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$layoutOptions = new NotesCommentsLayoutingOptions();
$layoutOptions->setCommentsPosition(CommentsPositions::Right);

$html5Options = new Html5Options();
$html5Options->setSlidesLayoutOptions($layoutOptions);

$presentation = new Presentation("sample.pptx");
try {
    $presentation->save("output.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

![Komentáře v výstupním dokumentu HTML5](two_comments_html5.png)

## **Vyloučení JavaScriptových hyperodkazů během exportu**

Předpokládejme, že `hyperlinks.pptx` obsahuje propojený text s cílem `javascript:alert('Hello')` a běžný odkaz `https://example.com/`. Chcete-li při exportu vyloučit JavaScriptový hyperodkaz, předávejte `true` metodě [SaveOptions::setSkipJavaScriptLinks](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks). Výchozí hodnota je `false`, takže tyto odkazy nejsou filtrovány, pokud tuto možnost neaktivujete.

Následující příklad načte prezentaci z pracovního adresáře a exportuje ji pomocí [Html5Options](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/):

```php
use aspose\slides\Html5Options;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$html5Options = new Html5Options();
$html5Options->setSkipJavaScriptLinks(true);

$presentation = new Presentation("hyperlinks.pptx");
try {
    $presentation->save("filtered-html5.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

Exportovaný soubor vynechá JavaScriptový hyperodkaz a zachová jeho text a běžný HTTPS odkaz. Zdrojová prezentace zůstane nezměněna.

Tato možnost filtruje JavaScriptové hyperodkazy; neodstraňuje všechny skripty ani jiný aktivní obsah a nezaručuje shodu s CSP. Například výstup HTML5 stále zahrnuje skripty pro navigaci mezi snímky a animace.

## **Často kladené otázky**

**Mohu řídit, zda se animace objektů a přechody snímků v HTML5 přehrávají?**

Ano, export HTML5 poskytuje samostatné možnosti pro povolení nebo zakázání [shape animations](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateShapes) a [slide transitions](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateTransitions).

**Jsou komentáře podporovány a kde je lze umístit vzhledem ke snímku?**

Ano, existující komentáře lze zahrnout do výstupu HTML5 a umístit (například napravo od snímku) pomocí [layout settings](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setSlidesLayoutOptions) pro poznámky a komentáře.

**Mohu vynechat odkazy, které volají JavaScript z bezpečnostních nebo CSP důvodů?**

Ano, nastavení [setSkipJavaScriptLinks](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) umožňuje při ukládání přeskočit hyperodkazy s voláním JavaScriptu. Výchozí hodnota je `false`. Viz [Vyloučení JavaScriptových hyperodkazů během exportu](/slides/cs/php-java/export-to-html5/#exclude-javascript-hyperlinks-during-export) pro příklad exportu HTML5 a rozsah filtru. Toto nastavení neodstraňuje JavaScript používaný HTML5 prohlížečem pro navigaci a animace.