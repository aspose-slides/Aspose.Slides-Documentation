---
title: Converti le presentazioni in HTML5 in PHP
linktitle: Presentazione in HTML5
type: docs
weight: 40
url: /it/php-java/export-to-html5/
keywords:
- PowerPoint in HTML5
- OpenDocument in HTML5
- presentazione in HTML5
- diapositiva in HTML5
- PPT in HTML5
- PPTX in HTML5
- ODP in HTML5
- salva PPT come HTML5
- salva PPTX come HTML5
- salva ODP come HTML5
- esporta PPT in HTML5
- esporta PPTX in HTML5
- esporta ODP in HTML5
- PHP
- Aspose.Slides
description: "Esporta presentazioni PowerPoint e OpenDocument in HTML5 reattivo con Aspose.Slides per PHP via Java. Conserva formattazione, animazioni e interattività."
---
## **Panoramica**

Questo articolo spiega come convertire le presentazioni PowerPoint in HTML5 utilizzando Aspose.Slides. Copre l'esportazione di base in HTML5 senza estensioni web o dipendenze aggiuntive, nonché le opzioni per controllare le animazioni delle forme e le transizioni delle diapositive. L'articolo mostra anche il processo standard di esportazione da PowerPoint a HTML, spiega come generare output HTML5 in modalità visualizzazione diapositiva e dimostra come includere i commenti nel documento esportato configurandone il layout.

## **Esporta PowerPoint in HTML5**

Questo codice PHP mostra come esportare una presentazione in HTML5 senza estensioni web e dipendenze:

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
In questo caso, otterrai HTML pulito. 
{{% /alert %}}

Potresti voler specificare le impostazioni per le animazioni delle forme e le transizioni delle diapositive in questo modo:

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

## **Esporta PowerPoint in HTML**

Questo esempio Java dimostra il processo standard di esportazione da PowerPoint a HTML:

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

In questo caso, il contenuto della presentazione viene renderizzato tramite SVG in una forma come questa:

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

Il documento "output.html" è mostrato nell'immagine seguente.

![I commenti nel documento HTML5 di output](two_comments_html5.png)

## **Domande frequenti**

**Posso controllare se le animazioni degli oggetti e le transizioni delle diapositive verranno riprodotte in HTML5?**

Sì, HTML5 fornisce opzioni separate per abilitare o disabilitare le [animazioni delle forme](https://reference.aspose.com/slides/it/php-java/aspose.slides/html5options/setanimateshapes/) e le [transizioni delle diapositive](https://reference.aspose.com/slides/it/php-java/aspose.slides/html5options/setanimatetransitions/).

**L'output dei commenti è supportato, e dove possono essere posizionati rispetto alla diapositiva?**

Sì, è possibile aggiungere commenti in HTML5 e posizionarli (ad esempio, a destra della diapositiva) tramite le [impostazioni di layout](https://reference.aspose.com/slides/it/php-java/aspose.slides/html5options/#setSlidesLayoutOptions) per note e commenti.

**Posso omettere i collegamenti che invocano JavaScript per motivi di sicurezza o CSP?**

Sì, esiste un [impostazione](https://reference.aspose.com/slides/it/php-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) che consente di omettere i collegamenti ipertestuali con chiamate JavaScript durante il salvataggio. Questo aiuta a rispettare politiche di sicurezza rigorose.