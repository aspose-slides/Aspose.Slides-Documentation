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
description: "Exportujte prezentace PowerPoint a OpenDocument do responsivního HTML5 pomocí Aspose.Slides pro .NET. Zachovejte formátování, animace a interaktivitu."
---
## **Přehled**

Tento článek vysvětluje, jak převést prezentace PowerPoint do HTML5 pomocí Aspose.Slides. Pokrývá základní export do HTML5 i možnosti řízení animací tvarů a přechodů mezi snímky. Článek také ukazuje standardní proces exportu z PowerPointu do HTML, popisuje, jak vygenerovat výstup HTML5 v režimu zobrazení snímků, a demonstruje, jak zahrnout komentáře do exportovaného dokumentu nastavením jejich rozvržení.

## **Export PowerPoint do HTML5**

Tento C# kód ukazuje, jak exportovat prezentaci do HTML5:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html5);
}
```

{{% alert color="info" %}} 

Kromě HTML dokumentu export zapisuje také přidružené soubory, na které odkazuje: `pres.css`, `master.css`, `animation.js`, `effects.js` a `navigation.js`. Vygenerovaná stránka také načítá jQuery a Anime.js z veřejných CDN; bez nich nefunguje navigace mezi snímky ani animace. 

{{% /alert %}}

Možná budete chtít nastavit možnosti pro animace tvarů a přechody mezi snímky tímto způsobem:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres5.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = false,
       AnimateTransitions = false
   });
}
```

## **Export PowerPoint do HTML**

Tento C# ukazuje standardní proces exportu z PowerPointu do HTML:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html);
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

{{% alert title="Note" color="warning" %}} 

Když použijete tuto metodu pro export PowerPointu do HTML, kvůli vykreslování SVG nebudete moci aplikovat styly ani animovat konkrétní prvky. 

{{% /alert %}}

## **Export PowerPoint do HTML5 v režimu zobrazení snímků**

**Aspose.Slides** umožňuje převést prezentaci PowerPoint do HTML5 dokumentu, ve kterém jsou snímky zobrazeny v režimu zobrazení snímků. V takovém případě, když otevřete výsledný HTML5 soubor v prohlížeči, uvidíte prezentaci v režimu zobrazení snímků na webové stránce. 

Tento C# kód demonstruje proces exportu PowerPointu do HTML5 v režimu zobrazení snímků:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("HTML5-slide-view.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = true,
       AnimateTransitions = true
   });
}
```

## **Převod prezentace do HTML5 dokumentu s komentáři**

Komentáře v PowerPointu jsou nástroj, který uživatelům umožňuje zanechat poznámky nebo zpětnou vazbu k jednotlivým snímkům. Jsou zvláště užitečné v kolaborativních projektech, kde může více lidí přidávat své návrhy nebo poznámky k určitým prvkům snímku, aniž by měnili hlavní obsah. Každý komentář zobrazuje jméno autora, což usnadňuje sledovat, kdo poznámku přidal.

Předpokládejme, že máme následující prezentaci PowerPoint uloženou v souboru „sample.pptx“.

![Two comments on the presentation slide](two_comments_pptx.png)

Když převádíte prezentaci PowerPoint do HTML5 dokumentu, můžete snadno určit, zda chcete do výstupního dokumentu zahrnout komentáře z prezentace. K tomu je třeba nastavit parametry zobrazení komentářů ve vlastnosti `NotesCommentsLayouting` třídy [Html5Options](https://reference.aspose.com/slides/cs/net/aspose.slides.export/html5options/).

Následující ukázkový kód převádí prezentaci do HTML5 dokumentu s komentáři zobrazenými vpravo od snímků.
```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        CommentsPosition = CommentsPositions.Right
    }
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.html", SaveFormat.Html5, html5Options);
```

Dokument „output.html“ je zobrazen na obrázku níže.

![The comments in the output HTML5 document](two_comments_html5.png)

## **Často kladené otázky**

### Mohu kontrolovat, zda se v HTML5 přehrávají animace objektů a přechody mezi snímky?

Ano, HTML5 poskytuje samostatné možnosti pro povolení nebo zakázání [animací tvarů](https://reference.aspose.com/slides/cs/net/aspose.slides.export/html5options/animateshapes/) a [přechodů mezi snímky](https://reference.aspose.com/slides/cs/net/aspose.slides.export/html5options/animatetransitions/).

### Je podpora výstupu komentářů dostupná a kde lze komentáře umístit vzhledem k snímku?

Ano, komentáře lze v HTML5 přidat a umístit (například vpravo od snímku) prostřednictvím [nastavení rozvržení](https://reference.aspose.com/slides/cs/net/aspose.slides.export/html5options/notescommentslayouting/) pro poznámky a komentáře.

### Mohu přeskočit odkazy, které vyvolávají JavaScript, z bezpečnostních nebo CSP důvodů?

Ano, existuje [nastavení](https://reference.aspose.com/slides/cs/net/aspose.slides.export/saveoptions/skipjavascriptlinks/), které umožňuje při ukládání přeskočit hypertextové odkazy s JavaScriptovým voláním. To pomáhá splnit přísné bezpečnostní politiky.