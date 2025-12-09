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
description: "Erstellen Sie Präsentationen in .NET mit Aspose.Slides – erzeugen Sie PPT-, PPTX- und ODP-Dateien, profitieren Sie von der OpenDocument-Unterstützung und speichern Sie sie programmgesteuert für zuverlässige Ergebnisse."
---

## **PowerPoint-Präsentation erstellen**
Um eine einfache gerade Linie zu einer ausgewählten Folie der Präsentation hinzuzufügen, folgen Sie bitte den nachstehenden Schritten:

1. Erstellen Sie eine Instanz der Klasse Presentation.  
1. Rufen Sie die Referenz einer Folie über deren Index ab.  
1. Fügen Sie mit der Methode AddAutoShape, die vom Shapes-Objekt bereitgestellt wird, eine AutoShape vom Typ Linie hinzu.  
1. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

Im nachfolgenden Beispiel haben wir eine Linie zur ersten Folie der Präsentation hinzugefügt.
```c#
 // Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
using (Presentation presentation = new Presentation())
{
    // Holen Sie die erste Folie
    ISlide slide = presentation.Slides[0];

    // Fügen Sie eine AutoShape vom Typ Linie hinzu
    slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);
    presentation.Save("NewPresentation_out.pptx", SaveFormat.Pptx);
}
```


## **Präsentation erstellen und speichern**

<a name="csharp-create-save-presentation"><strong>Schritte: Präsentation in C# erstellen und speichern</strong></a>

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)-Klasse.  
2. Speichern Sie _Presentation_ in ein beliebiges von [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/) unterstütztes Format.  
```c#
Presentation presentation = new Presentation();

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```


## **Präsentation öffnen und speichern**

<a name="csharp-open-save-presentation"><strong>Schritte: Präsentation in C# öffnen und speichern</strong></a>

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)-Klasse mit einem beliebigen Format, z. B. PPT, PPTX, ODP usw.  
2. Speichern Sie _Presentation_ in ein beliebiges von [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/) unterstütztes Format.  
```c#
 // Laden Sie eine beliebige unterstützte Datei in Presentation, z. B. ppt, pptx, odp usw.
Presentation presentation = new Presentation("Sample.odp");

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```


## **FAQ**

**In welche Formate kann ich eine neue Präsentation speichern?**

Sie können in [PPTX, PPT und ODP](/slides/de/net/save-presentation/) speichern und in [PDF](/slides/de/net/convert-powerpoint-to-pdf/), [XPS](/slides/de/net/convert-powerpoint-to-xps/), [HTML](/slides/de/net/convert-powerpoint-to-html/), [SVG](/slides/de/net/convert-powerpoint-to-png/) und [Bilder](/slides/de/net/convert-powerpoint-to-png/) exportieren, unter anderem.

**Kann ich von einer Vorlage (POTX/POTM) aus starten und als reguläres PPTX speichern?**

Ja. Laden Sie die Vorlage und speichern Sie sie in das gewünschte Format; POTX/POTM/PPTM und ähnliche Formate [werden unterstützt](/slides/de/net/supported-file-formats/).

**Wie kann ich die Foliengröße bzw. das Seitenverhältnis beim Erstellen einer Präsentation steuern?**

Legen Sie die [Foliegröße](/slides/de/net/slide-size/) (einschließlich Vorgaben wie 4:3 und 16:9 oder benutzerdefinierter Abmessungen) fest und bestimmen Sie, wie der Inhalt skaliert werden soll.

**In welchen Einheiten werden Größen und Koordinaten gemessen?**

In Punkten: 1 Zoll entspricht 72 Einheiten.

**Wie gehe ich mit sehr großen Präsentationen (mit vielen Mediendateien) um, um den Speicherverbrauch zu reduzieren?**

Verwenden Sie [BLOB‑Verwaltungsstrategien](/slides/de/net/manage-blob/), beschränken Sie den Speicher im Arbeitsspeicher durch die Nutzung temporärer Dateien und bevorzugen Sie dateibasierte Workflows gegenüber rein speicherbasierten Streams.

**Kann ich Präsentationen parallel erstellen/speichern?**

Sie können nicht dieselbe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Instanz von [mehreren Threads](/slides/de/net/multithreading/) aus gleichzeitig benutzen. Führen Sie separate, isolierte Instanzen pro Thread oder Prozess aus.

**Wie entferne ich das Testwasserzeichen und die Einschränkungen?**

[Wenden Sie eine Lizenz](/slides/de/net/licensing/) pro Prozess an. Die Lizenz‑XML darf nicht verändert werden, und die Lizenzinitialisierung sollte synchronisiert werden, wenn mehrere Threads beteiligt sind.

**Kann ich das von mir erstellte PPTX digital signieren?**

Ja. [Digitale Signaturen](/slides/de/net/digital-signature-in-powerpoint/) (Erstellung und Prüfung) werden für Präsentationen unterstützt.

**Werden Makros (VBA) in erstellten Präsentationen unterstützt?**

Ja. Sie können [VBA‑Projekte erstellen/bearbeiten](/slides/de/net/presentation-via-vba/) und makro‑aktivierte Dateien wie PPTM/PPSM speichern.