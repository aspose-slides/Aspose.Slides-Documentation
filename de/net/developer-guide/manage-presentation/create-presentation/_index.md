---
title: Präsentation erstellen in .NET
linktitle: Präsentation erstellen
type: docs
weight: 10
url: /de/net/create-presentation/
keywords: "PowerPoint erstellen, PPTX, PPT, Präsentation erstellen, Präsentation initialisieren, C#, .NET"
description: "Programmgesteuertes Erstellen von PowerPoint‑Präsentationen in C# z. B. PPT, PPTX, ODP usw."
---

## **PowerPoint-Präsentation erstellen**
Um einer ausgewählten Folie der Präsentation eine einfache gerade Linie hinzuzufügen, führen Sie die nachstehenden Schritte aus:

1. Erstellen Sie eine Instanz der Presentation-Klasse.
2. Holen Sie die Referenz einer Folie über deren Index.
3. Fügen Sie ein AutoShape vom Typ Linie mithilfe der AddAutoShape-Methode hinzu, die vom Shapes-Objekt bereitgestellt wird.
4. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

Im nachstehenden Beispiel haben wir eine Linie zur ersten Folie der Präsentation hinzugefügt.
```c#
 // Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
 using (Presentation presentation = new Presentation())
 {
     // Holen Sie die erste Folie
     ISlide slide = presentation.Slides[0];

     // Fügen Sie ein AutoShape vom Typ Linie hinzu
     slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);
     presentation.Save("NewPresentation_out.pptx", SaveFormat.Pptx);
 }
```


## **Präsentation erstellen und speichern**

<a name="csharp-create-save-presentation"><strong>Schritte: Präsentation erstellen und speichern in C#</strong></a>

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) Klasse.
2. Speichern Sie _Presentation_ in ein beliebiges von [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/) unterstütztes Format.
```c#
Presentation presentation = new Presentation();

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```


## **Präsentation öffnen und speichern**

<a name="csharp-open-save-presentation"><strong>Schritte: Präsentation öffnen und speichern in C#</strong></a>

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) Klasse mit einem beliebigen Format, z. B. PPT, PPTX, ODP usw.
2. Speichern Sie _Presentation_ in ein beliebiges von [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/) unterstütztes Format.
```c#
// Laden Sie eine beliebige unterstützte Datei in Presentation, z. B. ppt, pptx, odp usw.
Presentation presentation = new Presentation("Sample.odp");

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```


## **FAQ**

**In welche Formate kann ich eine neue Präsentation speichern?**

Sie können in [PPTX, PPT und ODP](/slides/de/net/save-presentation/) speichern und in [PDF](/slides/de/net/convert-powerpoint-to-pdf/), [XPS](/slides/de/net/convert-powerpoint-to-xps/), [HTML](/slides/de/net/convert-powerpoint-to-html/), [SVG](/slides/de/net/convert-powerpoint-to-png/) und [Bilder](/slides/de/net/convert-powerpoint-to-png/) exportieren, unter anderem.

**Kann ich von einer Vorlage (POTX/POTM) starten und als reguläres PPTX speichern?**

Ja. Laden Sie die Vorlage und speichern Sie sie im gewünschten Format; POTX/POTM/PPTM und ähnliche Formate werden [unterstützt](/slides/de/net/supported-file-formats/).

**Wie steuere ich die Foliengröße bzw. das Seitenverhältnis beim Erstellen einer Präsentation?**

Legen Sie die [Foliengröße](/slides/de/net/slide-size/) fest (einschließlich Voreinstellungen wie 4:3 und 16:9 oder benutzerdefinierter Abmessungen) und bestimmen Sie, wie Inhalte skaliert werden sollen.

**In welchen Einheiten werden Größe und Koordinaten gemessen?**

In Punkten: 1 Zoll entspricht 72 Einheiten.

**Wie gehe ich mit sehr großen Präsentationen (mit vielen Mediendateien) um, um den Speicherverbrauch zu reduzieren?**

Verwenden Sie [BLOB‑Verwaltungsstrategien](/slides/de/net/manage-blob/), begrenzen Sie den Speicher im Arbeitsspeicher durch Nutzung temporärer Dateien und bevorzugen Sie dateibasierte Workflows gegenüber rein speicherinterner Streams.

**Kann ich Präsentationen parallel erstellen/speichern?**

Sie können nicht dieselbe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Instanz von [mehreren Threads](/slides/de/net/multithreading/) aus bearbeiten. Führen Sie für jeden Thread oder Prozess separate, isolierte Instanzen aus.

**Wie entferne ich das Testwasserzeichen und die Einschränkungen?**

[Wenden Sie eine Lizenz](/slides/de/net/licensing/) pro Prozess an. Die Lizenz‑XML muss unverändert bleiben, und die Lizenz­konfiguration sollte synchronisiert werden, wenn mehrere Threads beteiligt sind.

**Kann ich das von mir erstellte PPTX digital signieren?**

Ja. [Digitale Signaturen](/slides/de/net/digital-signature-in-powerpoint/) (Hinzufügen und Überprüfen) werden für Präsentationen unterstützt.

**Werden Makros (VBA) in erstellten Präsentationen unterstützt?**

Ja. Sie können [VBA‑Projekte erstellen/bearbeiten](/slides/de/net/presentation-via-vba/) und makrofähige Dateien wie PPTM/PPSM speichern.