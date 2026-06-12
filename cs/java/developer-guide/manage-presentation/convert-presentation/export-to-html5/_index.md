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

Tento článek vysvětluje, jak převést prezentace PowerPoint do HTML5 pomocí Aspose.Slides. Popisuje základní export do HTML5 bez webových rozšíření nebo dalších závislostí, stejně jako možnosti řízení animací tvarů a přechodů snímků. Článek také ukazuje standardní proces exportu z PowerPointu do HTML, vysvětluje, jak vygenerovat výstup HTML5 v režimu zobrazení snímků, a demonstruje, jak zahrnout komentáře do exportovaného dokumentu pomocí nastavení jejich rozložení.

## **Export PowerPointu do HTML5**

Tento kód v jazyce Java ukazuje, jak exportovat prezentaci do HTML5 bez webových rozšíření a závislostí:

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

Můžete také specifikovat nastavení pro animace tvarů a přechody snímků tímto způsobem:

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

Tento kód v jazyce Java demonstruje standardní proces převodu PowerPointu do HTML:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
}
```

V tomto případě je obsah prezentace vykreslen pomocí SVG v následujícím tvaru:

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
Při použití této metody pro export PowerPointu do HTML kvůli vykreslení SVG nebudete moci aplikovat styly ani animovat konkrétní prvky. 
{{% /alert %}}

## **Export PowerPointu do HTML5 v režimu zobrazení snímků**

**Aspose.Slides** umožňuje převést prezentaci PowerPoint do HTML5 dokumentu, ve kterém jsou snímky zobrazeny v režimu zobrazení snímků. V tomto případě se po otevření výsledného souboru HTML5 v prohlížeči prezentace zobrazí na webové stránce v režimu zobrazení snímků. 

Tento kód v jazyce Java demonstruje proces exportu PowerPointu do HTML5 v režimu zobrazení snímků:

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

## **Převod prezentací do HTML5 dokumentů s komentáři**

Komentáře v PowerPointu jsou nástroj, který umožňuje uživatelům přidávat poznámky nebo zpětnou vazbu k snímkům prezentace. Jsou zvlášť užitečné v kolaborativních projektech, kde více lidí může přidávat své návrhy nebo připomínky k jednotlivým prvkům snímku, aniž by měnili hlavní obsah. Každý komentář zobrazuje jméno autora, což usnadňuje sledovat, kdo připomínku přidal.

Předpokládejme, že máme následující prezentaci PowerPoint uloženou v souboru „sample.pptx“.

![Two comments on the presentation slide](two_comments_pptx.png)

Když převádíte prezentaci PowerPoint do HTML5 dokumentu, můžete snadno určit, zda se mají do výstupního dokumentu zahrnout komentáře z prezentace. K tomu je nutné nastavit parametry zobrazení komentářů v metodě `getNotesCommentsLayouting` třídy [Html5Options](https://reference.aspose.com/slides/cs/java/com.aspose.slides/html5options/).

Následující příklad kódu převádí prezentaci do HTML5 dokumentu s komentáři zobrazovanými napravo od snímků.
```java
Html5Options html5Options = new Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(CommentsPositions.Right);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

Dokument „output.html“ je zobrazen na obrázku níže.

![The comments in the output HTML5 document](two_comments_html5.png)

## **FAQ**

**Mohu ovládat, zda se animace objektů a přechody snímků spustí v HTML5?**

Ano, HTML5 poskytuje samostatné možnosti pro povolení nebo zakázání [shape animations](https://reference.aspose.com/slides/cs/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) a [slide transitions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).

**Je podpora výstupu komentářů zajištěna a kde lze komentáře umístit vzhledem ke snímku?**

Ano, komentáře lze v HTML5 přidat a umístit (například napravo od snímku) pomocí [layout settings](https://reference.aspose.com/slides/cs/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) pro poznámky a komentáře.

**Mohu přeskočit odkazy, které volají JavaScript, kvůli bezpečnosti nebo CSP?**

Ano, existuje [setting](https://reference.aspose.com/slides/cs/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-), který umožňuje během ukládání vynechat hypertextové odkazy s voláním JavaScriptu. To pomáhá dodržovat přísné bezpečnostní politiky.