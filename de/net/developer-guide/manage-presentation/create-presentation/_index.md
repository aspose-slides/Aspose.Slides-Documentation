---
title: Präsentationen in .NET erstellen
linktitle: Präsentation erstellen
type: docs
weight: 10
url: /de/net/create-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "Erstellen Sie Präsentationen in .NET mit Aspose.Slides—produzieren Sie PPT-, PPTX- und ODP-Dateien, profitieren Sie von OpenDocument-Unterstützung und speichern Sie sie programmgesteuert für zuverlässige Ergebnisse."
---

## **PowerPoint-Präsentation erstellen**
Um einer ausgewählten Folie der Präsentation eine einfache gerade Linie hinzuzufügen, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der Klasse Presentation.
2. Holen Sie die Referenz einer Folie, indem Sie deren Index verwenden.
3. Fügen Sie mit der AddAutoShape-Methode des Shapes-Objekts ein AutoShape vom Typ Linie hinzu.
4. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Im nachstehenden Beispiel haben wir eine Linie zur ersten Folie der Präsentation hinzugefügt.
```c#
// Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
using (Presentation presentation = new Presentation())
{
    // Erhalte die erste Folie
    ISlide slide = presentation.Slides[0];

    // Füge ein AutoShape vom Typ Linie hinzu
    slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);
    presentation.Save("NewPresentation_out.pptx", SaveFormat.Pptx);
}
```


## **Präsentation erstellen und speichern**

<a name="csharp-create-save-presentation"><strong>Schritte: Präsentation in C# erstellen und speichern</strong></a>

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Speichern Sie _Presentation_ in ein beliebiges von [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/) unterstütztes Format.
```c#
Presentation presentation = new Presentation();

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```


## **Präsentation öffnen und speichern**

<a name="csharp-open-save-presentation"><strong>Schritte: Präsentation in C# öffnen und speichern</strong></a>

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) mit beliebigem Format, z. B. PPT, PPTX, ODP usw.
2. Speichern Sie _Presentation_ in ein beliebiges von [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/) unterstütztes Format.
```c#
// Laden Sie jede unterstützte Datei in Presentation, z. B. ppt, pptx, odp usw.
Presentation presentation = new Presentation("Sample.odp");

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```


## **FAQ**

**In welchen Formaten kann ich eine neue Präsentation speichern?**

Sie können in [PPTX, PPT und ODP](/slides/de/net/save-presentation/) speichern und in [PDF](/slides/de/net/convert-powerpoint-to-pdf/), [XPS](/slides/de/net/convert-powerpoint-to-xps/), [HTML](/slides/de/net/convert-powerpoint-to-html/), [SVG](/slides/de/net/convert-powerpoint-to-png/) und [Bilder](/slides/de/net/convert-powerpoint-to-png/) exportieren, unter anderem.

**Kann ich von einer Vorlage (POTX/POTM) starten und als reguläres PPTX speichern?**

Ja. Laden Sie die Vorlage und speichern Sie sie im gewünschten Format; POTX/POTM/PPTM und ähnliche Formate werden [unterstützt](/slides/de/net/supported-file-formats/).

**Wie kann ich die Foliengröße bzw. das Seitenverhältnis beim Erstellen einer Präsentation steuern?**

Stellen Sie die [Foliengröße](/slides/de/net/slide-size/) ein (einschließlich Vorgaben wie 4:3 und 16:9 oder benutzerdefinierter Abmessungen) und wählen Sie, wie der Inhalt skaliert werden soll.

**In welchen Einheiten werden Größen und Koordinaten gemessen?**

In Punkt: 1 Zoll entspricht 72 Einheiten.

**Wie gehe ich mit sehr großen Präsentationen (mit vielen Mediendateien) um, um den Speicherverbrauch zu reduzieren?**

Verwenden Sie [BLOB‑Verwaltungsstrategien](/slides/de/net/manage-blob/), begrenzen Sie die In‑Memory‑Speicherung durch Nutzung temporärer Dateien und bevorzugen Sie dateibasierte Workflows gegenüber rein speicherbasierten Streams.

**Kann ich Präsentationen parallel erstellen/speichern?**

Sie können nicht dieselbe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) Instanz von [mehreren Threads](/slides/de/net/multithreading/) aus betreiben. Verwenden Sie separate, isolierte Instanzen pro Thread oder Prozess.

**Wie entferne ich das Testwasserzeichen und die Einschränkungen?**

[Wenden Sie eine Lizenz](/slides/de/net/licensing/) pro Prozess an. Die Lizenz‑XML darf nicht verändert werden, und die Lizenzkonfiguration sollte synchronisiert werden, wenn mehrere Threads beteiligt sind.

**Kann ich das von mir erstellte PPTX digital signieren?**

Ja. [Digitale Signaturen](/slides/de/net/digital-signature-in-powerpoint/) (Hinzufügen und Überprüfen) werden für Präsentationen unterstützt.

**Werden Makros (VBA) in erstellten Präsentationen unterstützt?**

Ja. Sie können [VBA‑Projekte erstellen/bearbeiten](/slides/de/net/presentation-via-vba/) und makroaktivierte Dateien wie PPTM/PPSM speichern.