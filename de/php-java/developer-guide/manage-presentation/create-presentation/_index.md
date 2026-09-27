---
title: Präsentationen in PHP erstellen
linktitle: Präsentation erstellen
type: docs
weight: 10
url: /de/php-java/create-presentation/
keywords:
- Präsentation erstellen
- neue Präsentation
- PPT erstellen
- neue PPT
- PPTX erstellen
- neue PPTX
- ODP erstellen
- neue ODP
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Erstellen Sie Präsentationen mit Aspose.Slides für PHP via Java — erzeugen Sie PPT-, PPTX- und ODP-Dateien und speichern Sie sie programmgesteuert für zuverlässige Ergebnisse."
---
## **Übersicht**

Dieser Artikel zeigt, wie man eine Präsentation in Aspose.Slides erstellt, eine Textbox zur ersten Folie hinzufügt und das Ergebnis als Datei speichert. Er zeigt außerdem, wie man eine leere Präsentation erstellt und speichert sowie wie man eine vorhandene Präsentation in einem unterstützten Format öffnet und in ein anderes Format speichert. Ein kurzer FAQ am Ende behandelt häufige Fragen zu Formaten, Vorlagen, Foliengrößen, Einheiten, Speicherverbrauch, Threading, Lizenzierung, digitalen Signaturen und VBA‑Unterstützung.

Bevor Sie beginnen, installieren Sie Aspose.Slides für PHP via Java mit Composer und starten Sie die PHP/Java Bridge in Apache Tomcat. Siehe [Installation](/slides/de/php-java/installation/) für die vollständige Einrichtung. Die nachfolgenden Beispiele gehen davon aus, dass Tomcat unter `localhost:8080` läuft und der Composer-`vendor`-Ordner neben dem Skript liegt.

## **PowerPoint-Präsentation erstellen**

Um eine Präsentation zu erstellen und eine Textbox auf der ersten Folie zu platzieren, folgen Sie diesen Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/)‑Klasse. Eine neue Präsentation enthält bereits eine leere Folie.
2. Rufen Sie diese Folie aus der von [Presentation::getSlides](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/getslides/) zurückgegebenen Sammlung anhand ihres Index 0 ab.
3. Fügen Sie mit der Methode [ShapeCollection::addAutoShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/shapecollection/addautoshape/) ein Rechteck hinzu und setzen Sie dessen Text mit [TextFrame::setText](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/settext/).
4. Speichern Sie die Präsentation als PPTX‑Datei mit der Methode [Presentation::save](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/save/).

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/de/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    $shape->getTextFrame()->setText("Hello, Aspose.Slides!");
    $presentation->save(__DIR__ . "/hello.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Die beiden `require_once`‑Zeilen laden den PHP/Java‑Bridge‑Client von Tomcat und die Aspose.Slides‑Klassen aus dem Composer‑Paket. Die obere linke Ecke des Rechtecks liegt 50 Punkte vom linken Rand und 50 Punkte vom oberen Rand der Folie entfernt, und das Rechteck ist 400 Punkte breit und 100 Punkte hoch. Die gespeicherte Datei enthält eine Folie mit diesem Rechteck und dessen Text. Ohne Lizenz fügt Aspose.Slides jedem gespeicherten Blatt ein Evaluations‑Wasserzeichen hinzu; siehe [Licensing](/slides/de/php-java/licensing/).

{{% alert color="info" title="Note" %}}
Aspose.Slides liest und schreibt Dateien innerhalb von Tomcat, nicht in Ihrem PHP‑Prozess, sodass ein relativer Pfad wie `"hello.pptx"` relativ zum Arbeitsverzeichnis von Tomcat aufgelöst wird. Die Beispiele auf dieser Seite erstellen absolute Pfade mit `__DIR__`, sodass die Dateien neben dem Skript gelesen und gespeichert werden.
{{% /alert %}}

## **Präsentation erstellen und speichern**

Um eine leere Präsentation zu erstellen und zu speichern, erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/)‑Klasse und speichern Sie sie in einem beliebigen Format der Aufzählung [SaveFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/saveformat/). Das Ergebnis ist eine Präsentation mit einer leeren Folie.

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/de/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $presentation->save(__DIR__ . "/OutputPresentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Präsentation öffnen und speichern**

Um eine Präsentation von einem Format in ein anderes zu konvertieren, öffnen Sie sie, indem Sie ihren Pfad dem [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/)‑Konstruktor übergeben, und speichern Sie sie anschließend im Zielformat. Aspose.Slides erkennt das Eingabeformat, wie PPT, PPTX oder ODP, anhand der Datei selbst.

Das untenstehende Beispiel geht von einer OpenDocument‑Präsentation namens *Sample.odp* neben dem Skript aus und speichert sie als PPTX.

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/de/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation(__DIR__ . "/Sample.odp");
try {
    $presentation->save(__DIR__ . "/OutputPresentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

### In welchen Formaten kann ich eine neue Präsentation speichern?

Sie können in [PPTX, PPT und ODP](/slides/de/php-java/save-presentation/) speichern und in [PDF](/slides/de/php-java/convert-powerpoint-to-pdf/), [XPS](/slides/de/php-java/convert-powerpoint-to-xps/), [HTML](/slides/de/php-java/convert-powerpoint-to-html/), [SVG](/slides/de/php-java/render-a-slide-as-an-svg-image/) und [Bilder](/slides/de/php-java/convert-powerpoint-to-png/) exportieren, unter anderem.

### Kann ich von einer Vorlage (POTX/POTM) starten und als reguläres PPTX speichern?

Ja. Laden Sie die Vorlage und speichern Sie sie im gewünschten Format; POTX/POTM/PPTM und ähnliche Formate werden [unterstützt](/slides/de/php-java/supported-file-formats/).

### Wie kann ich die Foliengröße bzw. das Seitenverhältnis beim Erstellen einer Präsentation steuern?

Legen Sie die [Foliengröße](/slides/de/php-java/slide-size/) fest (einschließlich Vorgaben wie 4:3 und 16:9 oder benutzerdefinierte Abmessungen) und bestimmen Sie, wie der Inhalt skaliert werden soll.

### In welchen Einheiten werden Größen und Koordinaten gemessen?

In Punkten: 1 Zoll entspricht 72 Einheiten.

### Wie gehe ich mit sehr großen Präsentationen (mit vielen Mediendateien) um, um den Speicherverbrauch zu reduzieren?

Verwenden Sie [BLOB‑Verwaltungsstrategien](/slides/de/php-java/manage-blob/), begrenzen Sie den Speicher im Arbeitsspeicher durch Nutzung temporärer Dateien und bevorzugen Sie dateibasierte Workflows gegenüber rein speicherbasierten Streams.

### Kann ich Präsentationen parallel erstellen/speichern?

Sie können nicht dieselbe [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/)‑Instanz aus [mehreren Threads](/slides/de/php-java/multithreading/) gleichzeitig benutzen. Verwenden Sie separate, isolierte Instanzen pro Thread oder Prozess.

### Wie entferne ich das Test‑Wasserzeichen und die Einschränkungen?

[Wenden Sie eine Lizenz](/slides/de/php-java/licensing/) pro Prozess an. Die Lizenz‑XML darf nicht verändert werden, und die Lizenz‑Initialisierung sollte synchronisiert werden, wenn mehrere Threads beteiligt sind.

### Kann ich das erstellte PPTX digital signieren?

Ja. [Digitale Signaturen](/slides/de/php-java/digital-signature-in-powerpoint/) (Hinzufügen und Überprüfen) werden für Präsentationen unterstützt.

### Werden Makros (VBA) in erstellten Präsentationen unterstützt?

Ja. Sie können [VBA‑Projekte erstellen/bearbeiten](/slides/de/php-java/presentation-via-vba/) und makrofähige Dateien wie PPTM/PPSM speichern.