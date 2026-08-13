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

Tento článek vysvětluje, jak převést prezentace PowerPoint do HTML5 pomocí Aspose.Slides. Pokrývá základní export do HTML5 bez webových rozšíření a dalších závislostí, stejně jako možnosti řízení animací tvarů a přechodů snímků. Článek také ukazuje standardní proces exportu z PowerPointu do HTML, popisuje, jak vygenerovat výstup HTML5 v režimu zobrazení snímků, a demonstruje, jak do exportovaného dokumentu zahrnout komentáře nastavením jejich rozvržení.

## **Export prezentace PowerPoint do HTML5**

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

{{% alert color="info" %}} 
V tomto případě získáte čisté HTML. 
{{% /alert %}}

Nastavení animací tvarů a přechodů snímků můžete specifikovat takto:

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

## **Export prezentace PowerPoint do HTML**

Tento Java příklad demonstruje standardní proces exportu z PowerPointu do HTML:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
}
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
Při použití této metody k exportu PowerPointu do HTML nebudete moci aplikovat styly ani animovat konkrétní prvky kvůli vykreslování SVG. 
{{% /alert %}}

## **Export prezentace PowerPoint do HTML5 v režimu zobrazení snímků**

**Aspose.Slides** umožňuje převést prezentaci PowerPoint do dokumentu HTML5, ve kterém jsou snímky zobrazeny v režimu zobrazení snímků. V tomto případě, když otevřete vzniklý soubor HTML5 v prohlížeči, uvidíte prezentaci v režimu zobrazení snímků na webové stránce. 

Tento Java kód demonstruje proces exportu PowerPointu do HTML5 v režimu zobrazení snímků:

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

## **Převod prezentací do dokumentů HTML5 s komentáři**

Komentáře v PowerPointu jsou nástroj, který uživatelům umožňuje zanechat poznámky nebo zpětnou vazbu na snímcích prezentace. Jsou obzvláště užitečné v kolaborativních projektech, kde může více lidí přidávat své návrhy nebo připomínky k jednotlivým prvkům snímku, aniž by měnili hlavní obsah. Každý komentář zobrazuje jméno autora, což usnadňuje sledovat, kdo připomínku zanechal.

Předpokládejme, že máme následující prezentaci PowerPoint uloženou v souboru „sample.pptx“.

![Two comments on the presentation slide](two_comments_pptx.png)

Když převádíte prezentaci PowerPoint do dokumentu HTML5, můžete snadno určit, zda zahrnout komentáře z prezentace do výstupního dokumentu. K tomu předejte parametry zobrazení komentářů metodě `setSlidesLayoutOptions` třídy [Html5Options](https://reference.aspose.com/slides/cs/java/com.aspose.slides/html5options/).

Následující ukázkový kód převádí prezentaci do dokumentu HTML5 s komentáři zobrazenými vpravo od snímků.
```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();

NotesCommentsLayoutingOptions layoutingOptions = new NotesCommentsLayoutingOptions();
layoutingOptions.setCommentsPosition(CommentsPositions.Right);
html5Options.setSlidesLayoutOptions(layoutingOptions);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

Dokument „output.html“ je zobrazen na obrázku níže.

![The comments in the output HTML5 document](two_comments_html5.png)

## **Často kladené otázky**

### Mohu řídit, zda se v HTML5 přehrávají animace objektů a přechody snímků?

Ano, HTML5 poskytuje samostatné možnosti pro povolení nebo zakázání [shape animations](https://reference.aspose.com/slides/cs/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) a [slide transitions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).

### Je podpora výstupu komentářů, a kde lze komentáře umístit vzhledem k snímku?

Ano, komentáře lze v HTML5 přidat a umístit (například vpravo od snímku) pomocí [layout settings](https://reference.aspose.com/slides/cs/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) pro poznámky a komentáře.

### Mohu vynechat odkazy, které volají JavaScript, z bezpečnostních nebo CSP důvodů?

Ano, existuje [setting](https://reference.aspose.com/slides/cs/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) který umožňuje během ukládání přeskočit hypertextové odkazy s voláním JavaScriptu. To pomáhá dodržovat přísné bezpečnostní zásady.