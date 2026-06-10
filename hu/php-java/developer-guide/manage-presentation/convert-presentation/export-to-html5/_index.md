---
title: Prezentációk konvertálása HTML5-re PHP-ben
linktitle: Prezentáció HTML5-re
type: docs
weight: 40
url: /hu/php-java/export-to-html5/
keywords:
- PowerPoint HTML5-re
- OpenDocument HTML5-re
- prezentáció HTML5-re
- dia HTML5-re
- PPT HTML5-re
- PPTX HTML5-re
- ODP HTML5-re
- PPT mentése HTML5-ként
- PPTX mentése HTML5-ként
- ODP mentése HTML5-ként
- PPT exportálása HTML5-re
- PPTX exportálása HTML5-re
- ODP exportálása HTML5-re
- PHP
- Aspose.Slides
description: "PowerPoint és OpenDocument prezentációk exportálása reszponzív HTML5-re az Aspose.Slides PHP-hez Java-n keresztül. Megőrzi a formázást, animációkat és az interaktivitást."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan lehet a PowerPoint‑prezentációkat HTML5‑re konvertálni az Aspose.Slides segítségével. Bemutatja az egyszerű HTML5‑exportálást webkiegészítők vagy további függőségek nélkül, valamint az alakzatanimációk és diákátmenetek vezérlésének beállítási lehetőségeit. A cikk továbbá bemutatja a szabványos PowerPoint‑HTML exportfolyamatot, elmagyarázza, hogyan lehet HTML5‑kimenetet létrehozni dianézet módban, és megmutatja, hogyan lehet megjegyzéseket belefoglalni az exportált dokumentumba a elrendezésük konfigurálásával.

## **PowerPoint exportálása HTML5-re**

Ez a PHP‑kód bemutatja, hogyan exportálhat egy prezentációt HTML5‑re webkiegészítők és függőségek nélkül:

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
Ebben az esetben tiszta HTML-et kap. 
{{% /alert %}}

Így adhatja meg a beállításokat az alakzatanimációk és a diákátmenetek számára:

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

## **PowerPoint exportálása HTML-re**

Ez a Java kód bemutatja a szabványos PowerPoint‑HTML folyamatot:

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

Ebben az esetben a prezentáció tartalma SVG‑ként jelenik meg a következő módon:

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

"output.html" dokumentum az alábbi képen látható.

![A megjegyzések az output HTML5 dokumentumban](two_comments_html5.png)

## **GYIK**

**Szabályozhatom, hogy az objektumanimációk és a diákátmenetek lejátszódjanak-e HTML5‑ben?**

Igen, a HTML5 külön beállításokat biztosít a [alakzatanimációk](https://reference.aspose.com/slides/hu/php-java/aspose.slides/html5options/setanimateshapes/) és a [diákátmenetek](https://reference.aspose.com/slides/hu/php-java/aspose.slides/html5options/setanimatetransitions/) engedélyezésére vagy letiltására.

**Támogatottak-e a megjegyzések kimenete, és hol helyezhetők el a diához képest?**

Igen, a megjegyzések hozzáadhatók HTML5‑ben, és például a dia jobb oldalára pozicionálhatók a [elrendezési beállítások](https://reference.aspose.com/slides/hu/php-java/aspose.slides/html5options/#setSlidesLayoutOptions) segítségével a jegyzetek és megjegyzések számára.

**Kihagyhatom a JavaScript‑hívásokat tartalmazó linkeket biztonsági vagy CSP‑ok miatt?**

Igen, van egy [beállítás](https://reference.aspose.com/slides/hu/php-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks), amely lehetővé teszi, hogy a mentés során kihagyja a JavaScript‑hívásokat tartalmazó hiperhivatkozásokat. Ez segít a szigorú biztonsági szabályok betartásában.