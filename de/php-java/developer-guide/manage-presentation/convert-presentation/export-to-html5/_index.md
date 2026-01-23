---
title: Präsentationen nach HTML5 in PHP konvertieren
linktitle: Präsentation nach HTML5
type: docs
weight: 40
url: /de/php-java/export-to-html5/
keywords:
- PowerPoint nach HTML5
- OpenDocument nach HTML5
- Präsentation nach HTML5
- Folie nach HTML5
- PPT nach HTML5
- PPTX nach HTML5
- ODP nach HTML5
- PPT als HTML5 speichern
- PPTX als HTML5 speichern
- ODP als HTML5 speichern
- PPT nach HTML5 exportieren
- PPTX nach HTML5 exportieren
- ODP nach HTML5 exportieren
- PHP
- Aspose.Slides
description: "Exportieren Sie PowerPoint- und OpenDocument-Präsentationen in responsives HTML5 mit Aspose.Slides für PHP über Java. Bewahren Sie Formatierung, Animationen und Interaktivität."
---

Aspose.Slides unterstützt den HTML5-Export. Der hier beschriebene Export nach HTML5 ermöglicht es Ihnen, PowerPoint ohne Web-Erweiterungen oder Abhängigkeiten in HTML zu konvertieren. Auf diese Weise können Sie mit eigenen Vorlagen sehr flexible Optionen anwenden, die den Exportvorgang sowie das resultierende HTML, CSS, JavaScript und die Animationsattribute definieren. 

## **PowerPoint nach HTML5 exportieren**

Dieser PHP‑Code zeigt, wie Sie eine Präsentation ohne Web‑Erweiterungen und Abhängigkeiten nach HTML5 exportieren:
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

Auf diese Weise können Sie Einstellungen für Form‑Animationen und Folienübergänge festlegen:
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

Dieses Java‑Beispiel demonstriert den Standard‑PowerPoint‑nach‑HTML‑Prozess:
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


In diesem Fall wird der Präsentationsinhalt über SVG in einer Form wie dieser gerendert:
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


{{% alert title="Hinweis" color="warning" %}} 

Wenn Sie diese Methode zum Exportieren von PowerPoint nach HTML verwenden, können Sie aufgrund der SVG‑Darstellung keine Stile anwenden oder bestimmte Elemente animieren. 

{{% /alert %}}

## **PowerPoint nach HTML5‑Folienansicht exportieren**

**Aspose.Slides** ermöglicht es Ihnen, eine PowerPoint‑Präsentation in ein HTML5‑Dokument zu konvertieren, in dem die Folien in einem Folienansichtsmodus dargestellt werden. In diesem Fall sehen Sie beim Öffnen der resultierenden HTML5‑Datei in einem Browser die Präsentation im Folienansichtsmodus auf einer Webseite. 

Dieser PHP‑Code demonstriert den Exportvorgang von PowerPoint zur HTML5‑Folienansicht:
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


## **Präsentationen in HTML5‑Dokumente mit Kommentaren konvertieren**

Kommentare in PowerPoint sind ein Werkzeug, das es Benutzern ermöglicht, Anmerkungen oder Feedback zu Folien zu hinterlassen. Sie sind besonders nützlich in kollaborativen Projekten, bei denen mehrere Personen ihre Vorschläge oder Anmerkungen zu bestimmten Folienelementen hinzufügen können, ohne den Hauptinhalt zu ändern. Jeder Kommentar zeigt den Namen des Autors, sodass leicht nachverfolgt werden kann, wer die Anmerkung hinterlassen hat.

Angenommen, wir haben die folgende PowerPoint‑Präsentation in der Datei "sample.pptx" gespeichert.

![Zwei Kommentare auf der Präsentationsfolie](two_comments_pptx.png)

Wenn Sie eine PowerPoint‑Präsentation in ein HTML5‑Dokument konvertieren, können Sie leicht festlegen, ob Kommentare aus der Präsentation im Ausgabedokument enthalten sein sollen. Dazu müssen Sie die Anzeigeparameter für Kommentare in der `getNotesCommentsLayouting`‑Methode der `Html5Options`‑Klasse angeben.

Das folgende Codebeispiel konvertiert eine Präsentation in ein HTML5‑Dokument, wobei Kommentare rechts neben den Folien angezeigt werden.
```php
$html5Options = new Html5Options();
$html5Options->getNotesCommentsLayouting()->setCommentsPosition(CommentsPositions::Right);

$presentation = new Presentation("sample.pptx");
$presentation->save("output.html", SaveFormat::Html5, $html5Options);
$presentation->dispose();
```


Das "output.html"-Dokument ist im Bild unten zu sehen.

![Die Kommentare im ausgegebenen HTML5-Dokument](two_comments_html5.png)

## **FAQ**

**Kann ich steuern, ob Objektanimationen und Folienübergänge in HTML5 abgespielt werden?**

Ja, HTML5 bietet separate Optionen zum Aktivieren oder Deaktivieren von [Form‑Animationen](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/setanimateshapes/) und [Folienübergängen](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/setanimatetransitions/).

**Werden Kommentare unterstützt und wo können sie relativ zur Folie platziert werden?**

Ja, Kommentare können in HTML5 hinzugefügt und (zum Beispiel rechts von der Folie) über [Layout‑Einstellungen](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setSlidesLayoutOptions) für Notizen und Kommentare positioniert werden.

**Kann ich Links, die JavaScript aufrufen, aus Sicherheits- oder CSP-Gründen überspringen?**

Ja, es gibt eine [Einstellung](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks), die es ermöglicht, Hyperlinks mit JavaScript‑Aufrufen beim Speichern zu überspringen. Dies hilft, strenge Sicherheitsrichtlinien einzuhalten.