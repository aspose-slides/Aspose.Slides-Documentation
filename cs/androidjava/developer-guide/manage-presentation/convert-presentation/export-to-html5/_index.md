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
description: "Exportujte prezentace PowerPoint a OpenDocument do responzivního HTML5 pomocí Aspose.Slides pro Android v Javě. Zachovejte formátování, animace a interaktivitu."
---
## **Přehled**

Tento článek vysvětluje, jak pomocí Aspose.Slides převést prezentace PowerPoint do HTML5. Pokrývá základní export do HTML5 bez webových rozšíření nebo dalších závislostí, stejně jako možnosti řízení animací tvarů a přechodů mezi snímky. Článek také ukazuje standardní proces exportu PowerPointu do HTML, vysvětluje, jak vygenerovat výstup HTML5 v režimu zobrazení snímků, a demonstruje, jak zahrnout komentáře do exportovaného dokumentu nastavením jejich rozvržení.

## **Export PowerPointu do HTML5**

Tento Java kód ukazuje, jak exportovat prezentaci do HTML5 bez webových rozšíření a závislostí:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html5);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 
V tomto případě získáte čisté HTML. 
{{% /alert %}}

Můžete chtít tímto způsobem zadat nastavení pro animace tvarů a přechody snímků:

```java
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

## **Export PowerPointu do HTML**

Tento Java kód demonstruje standardní proces převodu PowerPointu do HTML:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
}
```

V tomto případě je obsah prezentace vykreslen pomocí SVG v podobě jako níže:

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
Když použijete tuto metodu pro export PowerPointu do HTML, kvůli renderování SVG nebudete moci aplikovat styly ani animovat konkrétní prvky. 
{{% /alert %}}

## **Export PowerPointu do HTML5 v režimu snímku**

**Aspose.Slides** vám umožňuje převést prezentaci PowerPoint do dokumentu HTML5, ve kterém jsou snímky zobrazeny v režimu zobrazení snímků. V takovém případě, když otevřete výsledný soubor HTML5 v prohlížeči, uvidíte prezentaci v režimu zobrazení snímků na webové stránce. 

Tento Java kód demonstruje proces exportu PowerPointu do HTML5 v režimu snímku:

```java
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

Komentáře v PowerPointu jsou nástrojem, který uživatelům umožňuje zanechat poznámky nebo zpětnou vazbu k snímkům prezentace. Jsou zvláště užitečné v kolaborativních projektech, kde může více lidí přidávat své návrhy nebo připomínky k jednotlivým prvkům snímku, aniž by měnili hlavní obsah. Každý komentář zobrazuje jméno autora, což usnadňuje sledovat, kdo připomínku zanechal.

Předpokládejme, že máme následující prezentaci PowerPoint uloženou v souboru "sample.pptx".

![Two comments on the presentation slide](two_comments_pptx.png)

Když převádíte prezentaci PowerPoint do dokumentu HTML5, můžete snadno určit, zda zahrnout komentáře z prezentace do výstupního dokumentu. K tomu je nutné nastavit parametry zobrazení komentářů v metodě `getNotesCommentsLayouting` třídy [Html5Options](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/html5options/).

Následující ukázkový kód převádí prezentaci do dokumentu HTML5 s komentáři zobrazenými vpravo od snímků.
```java
Html5Options html5Options = new Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(CommentsPositions.Right);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

Dokument "output.html" je zobrazen na obrázku níže.

![The comments in the output HTML5 document](two_comments_html5.png)

## **Často kladené otázky**

**Mohu kontrolovat, zda se animace objektů a přechody snímků v HTML5 přehrávají?**

Ano, HTML5 poskytuje samostatné možnosti pro povolení nebo zakázání [animací tvarů](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) a [přechodů snímků](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).

**Je podpora výstupu komentářů zahrnuta a kde mohou být umístěny vzhledem ke snímku?**

Ano, komentáře lze v HTML5 přidat a umístit (například vpravo od snímku) pomocí [nastavení rozvržení](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) pro poznámky a komentáře.

**Mohu přeskočit odkazy, které volají JavaScript, z bezpečnostních nebo CSP důvodů?**

Ano, existuje [nastavení](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-), které umožňuje během ukládání přeskočit hypertextové odkazy s voláním JavaScriptu. To pomáhá splnit přísné bezpečnostní politiky.