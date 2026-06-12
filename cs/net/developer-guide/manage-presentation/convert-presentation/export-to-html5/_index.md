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

Tento článek vysvětluje, jak převést prezentace PowerPoint do formátu HTML5 pomocí Aspose.Slides. Popisuje základní export do HTML5 bez webových rozšíření nebo dalších závislostí, stejně jako možnosti řízení animací tvarů a přechodů mezi snímky. Článek také ukazuje standardní proces exportu PowerPoint do HTML, vysvětluje, jak vygenerovat výstup HTML5 v režimu zobrazení snímků, a demonstruje, jak do exportovaného dokumentu zahrnout komentáře konfigurací jejich rozložení.

## **Export PowerPointu do HTML5**

C# kód ukazuje, jak exportovat prezentaci do HTML5 bez webových rozšíření a závislostí:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html5);
}
```

{{% alert color="primary" %}} 
V tomto případě získáte čisté HTML. 
{{% /alert %}}

Můžete také specifikovat nastavení animací tvarů a přechodů mezi snímky tímto způsobem:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres5.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = false,
       AnimateTransitions = false
   });
}
```

## **Export PowerPointu do HTML**

C# kód demonstruje standardní proces převodu PowerPointu do HTML:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html);
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

{{% alert title="Poznámka" color="warning" %}} 
Když použijete tuto metodu pro export PowerPointu do HTML, kvůli vykreslování SVG nebudete moci aplikovat styly ani animovat konkrétní prvky. 
{{% /alert %}}

## **Export PowerPointu do HTML5 zobrazení snímků**

**Aspose.Slides** umožňuje převést prezentaci PowerPoint do HTML5 dokumentu, ve kterém jsou snímky zobrazeny v režimu zobrazení snímků. V tomto případě, když otevřete výsledný HTML5 soubor v prohlížeči, uvidíte prezentaci v režimu zobrazení snímků na webové stránce. 

C# kód demonstruje proces exportu PowerPointu do HTML5 v režimu zobrazení snímků:

```c#
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

Komentáře v PowerPointu jsou nástroj, který uživatelům umožňuje zanechat poznámky nebo zpětnou vazbu k snímkům prezentace. Jsou zvláště užitečné v kolaborativních projektech, kde může více lidí přidávat své návrhy nebo připomínky k určitým prvkům snímku, aniž by měnili hlavní obsah. Každý komentář zobrazuje jméno autora, což usnadňuje sledovat, kdo poznámku přidal.

Řekněme, že máme následující PowerPoint prezentaci uloženou v souboru "sample.pptx".

![Dva komentáře na snímku prezentace](two_comments_pptx.png)

Když převádíte PowerPoint prezentaci do HTML5 dokumentu, můžete snadno určit, zda zahrnout komentáře z prezentace do výstupního dokumentu. K tomu je třeba nastavit parametry zobrazení komentářů v vlastnosti `NotesCommentsLayouting` třídy [Html5Options](https://reference.aspose.com/slides/cs/net/aspose.slides.export/html5options/).

Následující příklad kódu převádí prezentaci do HTML5 dokumentu s komentáři zobrazenými vpravo od snímků.
```cs
var html5Options = new Html5Options
{
    NotesCommentsLayouting =
    {
        CommentsPosition = CommentsPositions.Right
    }
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.html", SaveFormat.Html5, html5Options);
```

Dokument "output.html" je zobrazen na obrázku níže.

![Komentáře ve výstupním HTML5 dokumentu](two_comments_html5.png)

## **Často kladené otázky**

**Mohu řídit, zda se v HTML5 přehrávají animace objektů a přechody mezi snímky?**

Ano, HTML5 poskytuje samostatné možnosti pro povolení nebo zakázání [animací tvarů](https://reference.aspose.com/slides/cs/net/aspose.slides.export/html5options/animateshapes/) a [přechodů mezi snímky](https://reference.aspose.com/slides/cs/net/aspose.slides.export/html5options/animatetransitions/).

**Je podpora výstupu komentářů a kde je lze umístit vzhledem k snímkům?**

Ano, komentáře lze v HTML5 přidat a umístit (například vpravo od snímku) pomocí [nastavení rozložení](https://reference.aspose.com/slides/cs/net/aspose.slides.export/html5options/notescommentslayouting/) pro poznámky a komentáře.

**Mohu vynechat odkazy, které spouštějí JavaScript, z důvodů bezpečnosti nebo CSP?**

Ano, existuje [nastavení](https://reference.aspose.com/slides/cs/net/aspose.slides.export/saveoptions/skipjavascriptlinks/), které umožňuje během ukládání vynechat hypertextové odkazy s voláním JavaScriptu. To pomáhá dodržovat přísné bezpečnostní zásady.