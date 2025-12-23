---
title: Präsentationen nach HTML5 in PHP konvertieren
linktitle: Präsentation zu HTML5
type: docs
weight: 40
url: /de/php-java/export-to-html5/
keywords:
- PowerPoint zu HTML5
- OpenDocument zu HTML5
- Präsentation zu HTML5
- Folie zu HTML5
- PPT zu HTML5
- PPTX zu HTML5
- ODP zu HTML5
- PPT als HTML5 speichern
- PPTX als HTML5 speichern
- ODP als HTML5 speichern
- PPT zu HTML5 exportieren
- PPTX zu HTML5 exportieren
- ODP zu HTML5 exportieren
- PHP
- Aspose.Slides
description: "Exportieren Sie PowerPoint‑ und OpenDocument‑Präsentationen zu responsivem HTML5 mit Aspose.Slides für PHP via Java. Formatierung, Animationen und Interaktivität beibehalten."
---

{{% alert title="Info" color="info" %}}

In [Aspose.Slides 21.9](/slides/de/php-java/aspose-slides-for-java-21-9-release-notes/) haben wir die Unterstützung für den HTML5‑Export implementiert.

{{% /alert %}} 

Der Export nach HTML5 ermöglicht es, PowerPoint ohne Web‑Erweiterungen oder Abhängigkeiten in HTML zu konvertieren. Dabei können Sie mit eigenen Vorlagen sehr flexible Optionen anwenden, die den Exportprozess sowie das resultierende HTML, CSS, JavaScript und die Animationsattribute definieren. 

## **Export PowerPoint to HTML5**

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

Sie können auf diese Weise Einstellungen für Form‑Animationen und Folienübergänge festlegen:
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


## **Export PowerPoint to HTML**

Dieses Java‑Beispiel demonstriert den Standard‑PowerPoint‑zu‑HTML‑Prozess:
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


In diesem Fall wird der Präsentationsinhalt über SVG in folgender Form gerendert:
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

Wenn Sie diese Methode zum Exportieren von PowerPoint nach HTML verwenden, können Sie aufgrund des SVG‑Renderings keine Styles anwenden oder einzelne Elemente animieren. 

{{% /alert %}}

## **Export PowerPoint to HTML5 Slide View**

**Aspose.Slides** ermöglicht die Konvertierung einer PowerPoint‑Präsentation in ein HTML5‑Dokument, bei dem die Folien in einem Folien‑Ansichtsmodus dargestellt werden. Öffnen Sie die resultierende HTML5‑Datei in einem Browser, wird die Präsentation im Folien‑Ansichtsmodus auf der Webseite angezeigt. 

Dieser PHP‑Code demonstriert den Exportprozess von PowerPoint zu HTML5 Slide View:
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

Kommentare in PowerPoint sind ein Werkzeug, das es Benutzern ermöglicht, Notizen oder Feedback zu Folien zu hinterlassen. Sie sind besonders nützlich in kollaborativen Projekten, bei denen mehrere Personen ihre Vorschläge oder Anmerkungen zu bestimmten Folienelementen hinzufügen können, ohne den Hauptinhalt zu verändern. Jeder Kommentar zeigt den Namen des Autors, sodass leicht nachverfolgt werden kann, wer die Anmerkung hinterlassen hat.

Nehmen wir an, wir haben die folgende PowerPoint‑Präsentation in der Datei „sample.pptx“ gespeichert.

![Two comments on the presentation slide](two_comments_pptx.png)

Wenn Sie eine PowerPoint‑Präsentation in ein HTML5‑Dokument konvertieren, können Sie leicht festlegen, ob Kommentare aus der Präsentation im Ausgabedokument enthalten sein sollen. Dazu müssen Sie die Anzeigeparameter für Kommentare in der Methode `getNotesCommentsLayouting` der Klasse `Html5Options` angeben.

Das folgende Codebeispiel konvertiert eine Präsentation in ein HTML5‑Dokument, wobei Kommentare rechts neben den Folien angezeigt werden.
```php
$html5Options = new Html5Options();
$html5Options->getNotesCommentsLayouting()->setCommentsPosition(CommentsPositions::Right);

$presentation = new Presentation("sample.pptx");
$presentation->save("output.html", SaveFormat::Html5, $html5Options);
$presentation->dispose();
```


Das Dokument „output.html“ wird im Bild unten gezeigt.

![The comments in the output HTML5 document](two_comments_html5.png)

## **FAQ**

**Kann ich steuern, ob Objektanimationen und Folienübergänge in HTML5 wiedergegeben werden?**

Ja, HTML5 bietet separate Optionen zum Aktivieren oder Deaktivieren von [shape animations](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/setanimateshapes/) und [slide transitions](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/setanimatetransitions/).

**Wird die Ausgabe von Kommentaren unterstützt und wo können sie relativ zur Folie platziert werden?**

Ja, Kommentare können in HTML5 hinzugefügt und (z. B. rechts von der Folie) über [layout settings](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setSlidesLayoutOptions) für Notizen und Kommentare positioniert werden.

**Kann ich Links, die JavaScript ausführen, aus Sicherheits‑ oder CSP‑Gründen überspringen?**

Ja, es gibt eine [setting](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks), die es ermöglicht, Hyperlinks mit JavaScript‑Aufrufen beim Speichern zu überspringen.