---
title: "Konwertuj prezentacje do HTML5 w PHP"
linktitle: "Prezentacja do HTML5"
type: docs
weight: 40
url: /pl/php-java/export-to-html5/
keywords:
- "PowerPoint do HTML5"
- "OpenDocument do HTML5"
- "prezentacja do HTML5"
- "slajd do HTML5"
- "PPT do HTML5"
- "PPTX do HTML5"
- "ODP do HTML5"
- "zapisz PPT jako HTML5"
- "zapisz PPTX jako HTML5"
- "zapisz ODP jako HTML5"
- "eksportuj PPT do HTML5"
- "eksportuj PPTX do HTML5"
- "eksportuj ODP do HTML5"
- "PHP"
- "Aspose.Slides"
description: "Eksportuj prezentacje PowerPoint i OpenDocument do responsywnego HTML5 przy użyciu Aspose.Slides dla PHP poprzez Javę. Zachowaj formatowanie, animacje i interaktywność."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak konwertować prezentacje PowerPoint do HTML5 przy użyciu Aspose.Slides. Omówiono podstawowy eksport HTML5 bez rozszerzeń internetowych ani dodatkowych zależności, a także opcje kontrolowania animacji kształtów i przejść slajdów. Artykuł pokazuje także standardowy proces eksportu PowerPoint‑do‑HTML, wyjaśnia, jak generować wyjście HTML5 w trybie widoku slajdu oraz demonstruje, jak włączyć komentarze w wyeksportowanym dokumencie poprzez skonfigurowanie ich układu.

## **Eksport PowerPoint do HTML5**

Ten kod PHP pokazuje, jak wyeksportować prezentację do HTML5 bez rozszerzeń i zależności:

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

W tym przypadku otrzymujesz czysty HTML. 

{{% /alert %}}

Możesz w ten sposób określić ustawienia animacji kształtów i przejść slajdów:

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

## **Eksport PowerPoint do HTML**

Ten kod Java demonstruje standardowy proces eksportu PowerPoint do HTML:

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

W tym przypadku zawartość prezentacji jest renderowana przy użyciu SVG w formie takiej jak poniżej:

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

Dokument „output.html” jest pokazany na poniższym obrazie.

![The comments in the output HTML5 document](two_comments_html5.png)

## **FAQ**

**Czy mogę kontrolować, czy animacje obiektów i przejścia slajdów będą odtwarzane w HTML5?**

Tak, HTML5 zapewnia osobne opcje włączania lub wyłączania [shape animations](https://reference.aspose.com/slides/pl/php-java/aspose.slides/html5options/setanimateshapes/) oraz [slide transitions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/html5options/setanimatetransitions/).

**Czy obsługiwany jest eksport komentarzy i gdzie można je umieścić względem slajdu?**

Tak, komentarze można dodać w HTML5 i umieścić (na przykład po prawej stronie slajdu) przy użyciu [layout settings](https://reference.aspose.com/slides/pl/php-java/aspose.slides/html5options/#setSlidesLayoutOptions) dla notatek i komentarzy.

**Czy mogę pominąć linki wywołujące JavaScript ze względów bezpieczeństwa lub CSP?**

Tak, istnieje [setting](https://reference.aspose.com/slides/pl/php-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks), które pozwala pominąć hiperłącza zawierające wywołania JavaScript podczas zapisywania. Pomaga to spełnić rygorystyczne zasady bezpieczeństwa.