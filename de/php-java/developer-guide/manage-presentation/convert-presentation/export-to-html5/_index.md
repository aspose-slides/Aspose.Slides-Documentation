---
title: Export nach HTML5
type: docs
weight: 40
url: /de/php-java/export-nach-html5/
keywords:
- PowerPoint nach HTML
- Folien nach HTML
- HTML5
- HTML-Export
- Präsentation exportieren
- Präsentation konvertieren
- Folien konvertieren
- PHP
- Aspose.Slides für PHP über Java
description: "PowerPoint nach HTML5 in PHP exportieren"
---

{{% alert title="Info" color="info" %}}

In [Aspose.Slides 21.9](/slides/de/php-java/aspose-slides-for-java-21-9-release-notes/) haben wir die Unterstützung für HTML5-Export implementiert.

{{% /alert %}} 

Der Exportprozess nach HTML5 ermöglicht es Ihnen, PowerPoint ohne Web-Erweiterungen oder Abhängigkeiten in HTML zu konvertieren. So können Sie mit Ihren eigenen Vorlagen sehr flexible Optionen anwenden, die den Exportprozess und die resultierenden HTML-, CSS-, JavaScript- und Animationsattribute definieren. 

## **PowerPoint nach HTML5 exportieren**

Dieser PHP-Code zeigt, wie Sie eine Präsentation ohne Web-Erweiterungen und Abhängigkeiten nach HTML5 exportieren:

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

In diesem Fall erhalten Sie sauberes HTML. 

{{% /alert %}}

Sie können auf diese Weise Einstellungen für Formenanimationen und Folienübergänge festlegen:

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

## **PowerPoint nach HTML exportieren**

Dieses Java-Dokument demonstriert den Standardprozess zum Exportieren von PowerPoint nach HTML:

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

In diesem Fall wird der Präsentationsinhalt durch SVG in folgender Form gerendert:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> DER FOLIENINHALT WIRD HIER EINGEFÜGT </g>
     </svg>
</div>
</body>
```php

```

{{% alert title="Hinweis" color="warning" %}} 

Wenn Sie diese Methode verwenden, um PowerPoint nach HTML zu exportieren, können Sie aufgrund des SVG-Renderings keine Stile anwenden oder bestimmte Elemente animieren. 

{{% /alert %}}

## **PowerPoint nach HTML5-Folienansicht exportieren**

**Aspose.Slides** ermöglicht es Ihnen, eine PowerPoint-Präsentation in ein HTML5-Dokument zu konvertieren, in dem die Folien im Modus der Folienansicht dargestellt werden. In diesem Fall sehen Sie die Präsentation im Folienansichtsmodus auf einer Webseite, wenn Sie die resultierende HTML5-Datei in einem Browser öffnen. 

Dieser PHP-Code demonstriert den Exportprozess von PowerPoint nach HTML5-Folienansicht:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $html5Options = new Html5Options();
    $html5Options->setAnimateShapes(true);
    $html5Options->setAnimateTransitions(true);
    $pres->save("HTML5-Folienansicht.html", SaveFormat::Html5, $html5Options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## Konvertieren einer Präsentation in ein HTML5-Dokument mit Kommentaren

Kommentare in PowerPoint sind ein Werkzeug, das es Benutzern ermöglicht, Anmerkungen oder Feedback zu den Folien der Präsentation zu hinterlassen. Sie sind besonders nützlich in kollaborativen Projekten, in denen mehrere Personen ihre Vorschläge oder Anmerkungen zu bestimmten Folienelementen hinzufügen können, ohne den Hauptinhalt zu ändern. Jeder Kommentar zeigt den Namen des Autors an, was es einfach macht, nachzuvollziehen, wer den Hinweis gegeben hat.

Angenommen, wir haben die folgende PowerPoint-Präsentation, die in der Datei "sample.pptx" gespeichert ist.

![Zwei Kommentare auf der Präsentationsfolie](two_comments_pptx.png)

Wenn Sie eine PowerPoint-Präsentation in ein HTML5-Dokument konvertieren, können Sie leicht angeben, ob Kommentare aus der Präsentation im Ausgabedokument enthalten sein sollen. Dazu müssen Sie die Anzeigeparameter für Kommentare in der `getNotesCommentsLayouting`-Methode der Klasse `Html5Options` festlegen.

Das folgende Codebeispiel konvertiert eine Präsentation in ein HTML5-Dokument, wobei die Kommentare rechts von den Folien angezeigt werden.
```php
$html5Options = new Html5Options();
$html5Options->getNotesCommentsLayouting()->setCommentsPosition(CommentsPositions::Right);

$presentation = new Presentation("sample.pptx");
$presentation->save("output.html", SaveFormat::Html5, $html5Options);
$presentation->dispose();
```

Das Dokument "output.html" wird in dem Bild unten angezeigt.

![Die Kommentare im ausgegebenen HTML5-Dokument](two_comments_html5.png)