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

Tento článek vysvětluje, jak převést prezentace PowerPoint do HTML5 pomocí Aspose.Slides. Pokrývá základní export do HTML5 bez webových rozšíření nebo dalších závislostí, stejně jako možnosti řízení animací tvarů a přechodů snímků. Článek také ukazuje standardní proces exportu PowerPoint do HTML, vysvětluje, jak generovat výstup HTML5 v režimu zobrazení snímku, a demonstruje, jak zahrnout komentáře do exportovaného dokumentu nastavením jejich rozložení.

## **Export PowerPoint do HTML5**

Tento PHP kód ukazuje, jak exportovat prezentaci do HTML5 bez webových rozšíření a závislostí:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save("pres.html", SaveFormat::Html5);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 
V tomto případě získáte čisté HTML. 
{{% /alert %}}

Můžete také zadat nastavení pro animace tvarů a přechody snímků tímto způsobem:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $html5Options = new Html5Options();
    $html5Options->setAnimateShapes(false);
    $html5Options->setAnimateTransitions(false);
    $pres->save("pres5.html", SaveFormat::Html5, $html5Options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Export PowerPoint do HTML**

Tento Java ukazuje standardní proces převodu PowerPoint do HTML:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save("pres.html", SaveFormat::Html);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
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
```php

```

{{% alert title="Note" color="warning" %}} 

When you use this method to export PowerPoint to HTML, due to the SVG rendering, you will not be to apply styles or animate specific elements. 

{{% /alert %}}

## **Export PowerPoint to HTML5 Slide View**

**Aspose.Slides** allows you to convert a PowerPoint presentation to an HTML5 document in which the slides are presented in a slide view mode. In this case, when you open the resulting HTML5 file in a browser, you see the presentation in slide view mode on a web page. 

This PHP code demonstrates the PowerPoint to HTML5 Slide View export process:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $html5Options = new Html5Options();
    $html5Options->setAnimateShapes(true);
    $html5Options->setAnimateTransitions(true);
    $pres->save("HTML5-slide-view.html", SaveFormat::Html5, $html5Options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Convert Presentations to HTML5 Documents with Comments**

Comments in PowerPoint are a tool that allows users to leave notes or feedback on presentation slides. They are especially useful in collaborative projects, where multiple people can add their suggestions or remarks to specific slide elements without altering the main content. Each comment shows the author's name, making it easy to track who left the remark.

Let's say we have the following PowerPoint presentation saved in the "sample.pptx" file.

![Two comments on the presentation slide](two_comments_pptx.png)

When you convert a PowerPoint presentation to an HTML5 document, you can easily specify whether to include comments from the presentation in the output document. To do this, you need to specify the display parameters for comments in the `getNotesCommentsLayouting` method of the `Html5Options` class.

The following code example converts a presentation to an HTML5 document with comments displayed to the right of the slides.
```php
$html5Options = new Html5Options();
$html5Options->getNotesCommentsLayouting()->setCommentsPosition(CommentsPositions::Right);

$presentation = new Presentation("sample.pptx");
$presentation->save("output.html", SaveFormat::Html5, $html5Options);
$presentation->dispose();

Dokument „output.html“ je zobrazen na obrázku níže.

![The comments in the output HTML5 document](two_comments_html5.png)

## **FAQ**

**Mohu řídit, zda se v HTML5 přehrávají animace objektů a přechody snímků?**

Ano, HTML5 poskytuje samostatné možnosti pro povolení nebo zakázání [shape animations](https://reference.aspose.com/slides/cs/php-java/aspose.slides/html5options/setanimateshapes/) a [slide transitions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/html5options/setanimatetransitions/).

**Je podpora výstupu komentářů zahrnuta a kde mohou být umístěny vzhledem ke snímku?**

Ano, komentáře lze v HTML5 přidat a umístit (například vpravo od snímku) prostřednictvím [layout settings](https://reference.aspose.com/slides/cs/php-java/aspose.slides/html5options/#setSlidesLayoutOptions) pro poznámky a komentáře.

**Mohu vynechat odkazy, které volají JavaScript, z důvodu zabezpečení nebo CSP?**

Ano, existuje [setting](https://reference.aspose.com/slides/cs/php-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks), který umožňuje při ukládání přeskočit hypertextové odkazy s voláním JavaScriptu. To pomáhá splnit přísné bezpečnostní politiky.