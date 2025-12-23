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
description: "Erstellen Sie Präsentationen mit Aspose.Slides für PHP via Java — erzeugen Sie PPT-, PPTX- und ODP-Dateien und speichern Sie sie programmatisch für zuverlässige Ergebnisse."
---

## **Erstellen einer Präsentation**

Um eine einfache gerade Linie zu einer ausgewählten Folie der Präsentation hinzuzufügen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der Klasse Presentation.  
2. Rufen Sie die Referenz einer Folie über ihren Index ab.  
3. Fügen Sie ein AutoShape vom Typ Linie hinzu, indem Sie die Methode addAutoShape des Shapes-Objekts verwenden.  
4. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Im untenstehenden Beispiel haben wir eine Linie zur ersten Folie der Präsentation hinzugefügt.
```php
  # Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
  $pres = new Presentation();
  try {
    # Holen Sie die erste Folie
    $slide = $pres->getSlides()->get_Item(0);
    # Fügen Sie ein AutoShape vom Typ Linie hinzu
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    $pres->save("NewPresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**In welchen Formaten kann ich eine neue Präsentation speichern?**

Sie können in [PPTX, PPT und ODP](/slides/de/php-java/save-presentation/) speichern und in [PDF](/slides/de/php-java/convert-powerpoint-to-pdf/), [XPS](/slides/de/php-java/convert-powerpoint-to-xps/), [HTML](/slides/de/php-java/convert-powerpoint-to-html/), [SVG](/slides/de/php-java/convert-powerpoint-to-png/) und [Bilder](/slides/de/php-java/convert-powerpoint-to-png/) exportieren, unter anderem.

**Kann ich von einer Vorlage (POTX/POTM) starten und als reguläres PPTX speichern?**

Ja. Laden Sie die Vorlage und speichern Sie sie im gewünschten Format; POTX/POTM/PPTM und ähnliche Formate [werden unterstützt](/slides/de/php-java/supported-file-formats/).

**Wie kann ich die Foliengröße/Seitenverhältnis beim Erstellen einer Präsentation steuern?**

Stellen Sie die [Foliengröße](/slides/de/php-java/slide-size/) ein (einschließlich Voreinstellungen wie 4:3 und 16:9 oder benutzerdefinierte Abmessungen) und wählen Sie, wie der Inhalt skaliert werden soll.

**In welchen Einheiten werden Größen und Koordinaten gemessen?**

In Punkten: 1 Zoll entspricht 72 Einheiten.

**Wie gehe ich mit sehr großen Präsentationen (mit vielen Mediendateien) um, um den Speicherverbrauch zu reduzieren?**

Verwenden Sie [BLOB‑Verwaltungsstrategien](/slides/de/php-java/manage-blob/), begrenzen Sie den Speicher im Arbeitsspeicher durch die Nutzung temporärer Dateien und bevorzugen Sie dateibasierte Workflows gegenüber rein speicherbasierten Streams.

**Kann ich Präsentationen parallel erstellen/speichern?**

Sie können nicht gleichzeitig auf dieselbe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) Instanz aus [mehreren Threads](/slides/de/php-java/multithreading/) zugreifen. Führen Sie separate, isolierte Instanzen pro Thread oder Prozess aus.

**Wie entferne ich das Testwasserzeichen und die Einschränkungen?**

[Wenden Sie eine Lizenz](/slides/de/php-java/licensing/) pro Prozess an. Die Lizenz‑XML darf nicht geändert werden, und die Lizenzkonfiguration sollte synchronisiert werden, wenn mehrere Threads beteiligt sind.

**Kann ich das erstellte PPTX digital signieren?**

Ja. [Digitale Signaturen](/slides/de/php-java/digital-signature-in-powerpoint/) (Hinzufügen und Verifizieren) werden für Präsentationen unterstützt.

**Werden Makros (VBA) in erstellten Präsentationen unterstützt?**

Ja. Sie können [VBA‑Projekte erstellen/bearbeiten](/slides/de/php-java/presentation-via-vba/) und makrofähige Dateien wie PPTM/PPSM speichern.