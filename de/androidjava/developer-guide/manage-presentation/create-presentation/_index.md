---
title: Präsentationen unter Android erstellen
linktitle: Präsentation erstellen
type: docs
weight: 10
url: /de/androidjava/create-presentation/
keywords:
- Präsentation erstellen
- neue Präsentation
- PPT erstellen
- neues PPT
- PPTX erstellen
- neues PPTX
- ODP erstellen
- neues ODP
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erstellen Sie Präsentationen in Java mit Aspose.Slides für Android — erzeugen Sie PPT-, PPTX- und ODP-Dateien, profitieren Sie von OpenDocument‑Unterstützung und speichern Sie sie programmgesteuert für zuverlässige Ergebnisse."
---

## **PowerPoint-Präsentation erstellen**
Um einer ausgewählten Folie der Präsentation eine einfache gerade Linie hinzuzufügen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der Klasse Presentation.
2. Holen Sie die Referenz einer Folie, indem Sie deren Index verwenden.
3. Fügen Sie mit der von Shapes bereitgestellten Methode addAutoShape eine AutoShape vom Typ Linie hinzu.
4. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Im untenstehenden Beispiel haben wir eine Linie zur ersten Folie der Präsentation hinzugefügt.
```java
// Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
Presentation pres = new Presentation();
try {
    // Holen Sie die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);

    // Fügen Sie eine AutoShape vom Typ Linie hinzu
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    pres.save("NewPresentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**In welchen Formaten kann ich eine neue Präsentation speichern?**

Sie können in [PPTX, PPT und ODP](/slides/de/androidjava/save-presentation/) speichern und in [PDF](/slides/de/androidjava/convert-powerpoint-to-pdf/), [XPS](/slides/de/androidjava/convert-powerpoint-to-xps/), [HTML](/slides/de/androidjava/convert-powerpoint-to-html/), [SVG](/slides/de/androidjava/convert-powerpoint-to-png/) und [Bilder](/slides/de/androidjava/convert-powerpoint-to-png/) exportieren, unter anderem.

**Kann ich von einer Vorlage (POTX/POTM) ausgehen und als reguläres PPTX speichern?**

Ja. Laden Sie die Vorlage und speichern Sie sie im gewünschten Format; POTX/POTM/PPTM und ähnliche Formate werden [unterstützt](/slides/de/androidjava/supported-file-formats/).

**Wie kann ich die Foliengröße bzw. das Seitenverhältnis beim Erstellen einer Präsentation steuern?**

Stellen Sie die [Foliengröße](/slides/de/androidjava/slide-size/) ein (einschließlich Voreinstellungen wie 4:3 und 16:9 oder benutzerdefinierte Abmessungen) und wählen Sie, wie der Inhalt skaliert werden soll.

**In welchen Einheiten werden Größen und Koordinaten gemessen?**

In Punkt: 1 Zoll entspricht 72 Einheiten.

**Wie gehe ich mit sehr großen Präsentationen (mit vielen Mediendateien) um, um den Speicherverbrauch zu reduzieren?**

Verwenden Sie [BLOB‑Verwaltungsstrategien](/slides/de/androidjava/manage-blob/), begrenzen Sie den Speicher im Arbeitsspeicher durch Nutzung temporärer Dateien und bevorzugen Sie dateibasierte Workflows gegenüber rein speicherbasierten Streams.

**Kann ich Präsentationen parallel erstellen/speichern?**

Sie können nicht dieselbe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) Instanz von [mehreren Threads](/slides/de/androidjava/multithreading/) aus verwenden. Führen Sie für jeden Thread oder Prozess separate, isolierte Instanzen aus.

**Wie entferne ich das Testwasserzeichen und die Einschränkungen?**

[Wenden Sie eine Lizenz an](/slides/de/androidjava/licensing/) einmal pro Prozess. Das Lizenz‑XML muss unverändert bleiben, und die Lizenzkonfiguration sollte synchronisiert werden, wenn mehrere Threads beteiligt sind.

**Kann ich die von mir erstellte PPTX digital signieren?**

Ja. [Digitale Signaturen](/slides/de/androidjava/digital-signature-in-powerpoint/) (Hinzufügen und Verifizieren) werden für Präsentationen unterstützt.

**Werden Makros (VBA) in erstellten Präsentationen unterstützt?**

Ja. Sie können [VBA‑Projekte erstellen/bearbeiten](/slides/de/androidjava/presentation-via-vba/) und makrofähige Dateien wie PPTM/PPSM speichern.