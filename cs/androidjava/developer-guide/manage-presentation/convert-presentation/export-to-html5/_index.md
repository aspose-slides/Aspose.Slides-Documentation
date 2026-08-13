---
title: Převod prezentací do HTML5 na Androidu
linktitle: Prezentace do HTML5
type: docs
weight: 40
url: /cs/androidjava/export-to-html5/
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
- Android
- Java
- Aspose.Slides
description: "Exportujte prezentace PowerPoint a OpenDocument do responzivního HTML5 pomocí Aspose.Slides pro Android v jazyce Java. Zachovejte formátování, animace a interaktivitu."
---
## **Přehled**

Tento článek vysvětluje, jak pomocí Aspose.Slides převést prezentace PowerPoint do HTML5. Popisuje základní export do HTML5 bez webových rozšíření nebo dalších závislostí, stejně jako možnosti řízení animací tvarů a přechodů snímků. Článek také ukazuje standardní proces exportu z PowerPointu do HTML, vysvětluje, jak generovat výstup HTML5 v režimu zobrazení snímků, a demonstruje, jak zahrnout komentáře do exportovaného dokumentu pomocí nastavení jejich rozvržení.

## **Export PowerPoint do HTML5**

Tento Java kód ukazuje, jak exportovat prezentaci do HTML5 bez webových rozšíření a závislostí:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html5);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}}V tomto případě získáte čisté HTML.{{% /alert %}}

Můžete takto zadat nastavení animací tvarů a přechodů snímků:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    Html5Options html5Options = new Html5Options();
    html5Options.setAnimateShapes(false);
    html5Options.setAnimateTransitions(false);
    
    pres.save("pres5.html", SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Export PowerPoint do HTML**

Tento Java kód demonstruje standardní proces převodu PowerPointu do HTML:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
}
```

V tomto případě je obsah prezentace vykreslen pomocí SVG ve formě jako níže:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Note" color="warning" %}}Při použití této metody pro export PowerPointu do HTML, kvůli vykreslování SVG nebudete moci použít styly ani animovat konkrétní prvky.{{% /alert %}}

## **Export PowerPoint do HTML5 ve zobrazení snímků**

**Aspose.Slides** umožňuje převést prezentaci PowerPoint do dokumentu HTML5, ve kterém jsou snímky zobrazeny v režimu zobrazení snímků. V takovém případě, když otevřete výsledný soubor HTML5 v prohlížeči, uvidíte prezentaci v režimu zobrazení snímků na webové stránce.

Tento Java kód demonstruje proces exportu PowerPointu do HTML5 ve zobrazení snímků:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    Html5Options html5Options = new Html5Options();
    html5Options.setAnimateShapes(true);
    html5Options.setAnimateTransitions(true);

    pres.save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Převod prezentace do dokumentu HTML5 s komentáři**

Komentáře v PowerPointu jsou nástroj, který umožňuje uživatelům zanechat poznámky nebo zpětnou vazbu na snímcích prezentace. Jsou zvláště užitečné při spolupracujících projektech, kde více lidí může přidat své návrhy nebo připomínky k jednotlivým prvkům snímku, aniž by měnili hlavní obsah. Každý komentář zobrazuje jméno autora, což usnadňuje sledovat, kdo připomínku zanechal.

Předpokládejme, že máme následující prezentaci PowerPoint uloženou v souboru "sample.pptx".

![Dva komentáře na snímku prezentace](two_comments_pptx.png)

Když převádíte prezentaci PowerPoint do dokumentu HTML5, můžete snadno určit, zda zahrnout komentáře z prezentace do výstupního dokumentu. K tomu je třeba předat parametry zobrazení komentářů metodě `setSlidesLayoutOptions` třídy [Html5Options](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/html5options/).

Následující ukázka kódu převádí prezentaci do dokumentu HTML5 s komentáři zobrazenými vpravo od snímků.
```java
import com.aspose.slides.*;

NotesCommentsLayoutingOptions layoutingOptions = new NotesCommentsLayoutingOptions();
layoutingOptions.setCommentsPosition(CommentsPositions.Right);

Html5Options html5Options = new Html5Options();
html5Options.setSlidesLayoutOptions(layoutingOptions);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

Dokument "output.html" je zobrazen na obrázku níže.

![Komentáře v výstupním dokumentu HTML5](two_comments_html5.png)

## **Často kladené otázky**

### Mohu řídit, zda se v HTML5 přehrávají animace objektů a přechody snímků?

Ano, HTML5 poskytuje samostatné možnosti pro povolení nebo zakázání [animací tvarů](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) a [přechodů snímků](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).

### Je podpora výstupu komentářů, a kde je lze umístit vzhledem k snímku?

Ano, komentáře lze v HTML5 přidat a umístit (například vpravo od snímku) prostřednictvím [nastavení rozvržení](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) pro poznámky a komentáře.

### Mohu přeskočit odkazy, které volají JavaScript, z bezpečnostních nebo CSP důvodů?

Ano, existuje [nastavení](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-), které umožňuje při ukládání vynechat hypertextové odkazy s voláním JavaScriptu. To pomáhá splňovat přísné bezpečnostní zásady.