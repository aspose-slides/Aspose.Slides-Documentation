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
- neues PPT
- PPTX erstellen
- neues PPTX
- ODP erstellen
- neues ODP
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erstellen Sie Präsentationen in .NET mit Aspose.Slides - erstellen Sie PPT-, PPTX- und ODP-Dateien, nutzen Sie die OpenDocument-Unterstützung und speichern Sie sie programmgesteuert für zuverlässige Ergebnisse."
---
## **Übersicht**

Dieser Artikel zeigt, wie man in Aspose.Slides eine Präsentation erstellt, auf ihrer ersten Folie ein Textfeld hinzufügt und das Ergebnis als Datei speichert. Er zeigt außerdem, wie man eine leere Präsentation erstellt und speichert sowie wie man eine vorhandene Präsentation in einem unterstützten Format öffnet und in ein anderes Format speichert. Ein kurzer FAQ am Ende beantwortet häufige Fragen zu Formaten, Vorlagen, Foliengröße, Einheiten, Speichernutzung, Threading, Lizenzierung, digitalen Signaturen und VBA‑Unterstützung.

Bevor Sie beginnen, fügen Sie Ihrem Projekt Aspose.Slides über NuGet hinzu. Siehe [Installation](/slides/de/net/installation/) für das zu verwendende Paket unter Windows, Linux und macOS.

## **PowerPoint‑Präsentation erstellen**

Um eine Präsentation zu erstellen und ein Textfeld auf ihrer ersten Folie zu platzieren, folgen Sie diesen Schritten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/). Eine neue Präsentation enthält bereits eine leere Folie.
2. Rufen Sie diese Folie aus der Sammlung [Slides](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/slides/de/) über ihren Index 0 ab.
3. Fügen Sie mit der Methode [AddAutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/ishapecollection/addautoshape/) ein Rechteck hinzu und setzen Sie dessen [text](https://reference.aspose.com/slides/de/net/aspose.slides/itextframe/text/).
4. Speichern Sie die Präsentation als PPTX-Datei mit der Methode [Save](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/save/).

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);
```

Die obere linke Ecke des Rechtecks ist 50 Punkte vom linken Rand und 50 Punkte vom oberen Rand der Folie entfernt, und das Rechteck ist 400 Punkte breit und 100 Punkte hoch. Die gespeicherte Datei enthält eine Folie mit diesem Rechteck und dessen Text. Ohne Lizenz fügt Aspose.Slides jedem gespeicherten Folie ein Evaluierungswasserzeichen hinzu; siehe [Licensing](/slides/de/net/licensing/).

## **Präsentation erstellen und speichern**

<a name="csharp-create-save-presentation"></a>

Um eine leere Präsentation zu erstellen und zu speichern, erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/) und speichern sie in einem beliebigen Format der Aufzählung [SaveFormat](https://reference.aspose.com/slides/de/net/aspose.slides.export/saveformat/). Das Ergebnis ist eine Präsentation mit einer leeren Folie.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.Save("OutputPresentation.pptx", SaveFormat.Pptx);
```

## **Präsentation öffnen und speichern**

<a name="csharp-open-save-presentation"></a>

Um eine Präsentation von einem Format in ein anderes zu konvertieren, öffnen Sie sie, indem Sie ihren Pfad an den Konstruktor [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/presentation/) übergeben, und speichern sie anschließend im Ziel‑format. Aspose.Slides erkennt das Eingabeformat, wie PPT, PPTX oder ODP, anhand der Datei selbst.

Das nachstehende Beispiel erwartet eine OpenDocument‑Präsentation mit dem Namen *Sample.odp* im Arbeitsverzeichnis und speichert sie als PPTX.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.odp");
presentation.Save("OutputPresentation.pptx", SaveFormat.Pptx);
```

## **FAQ**

### In welchen Formaten kann ich eine neue Präsentation speichern?

Sie können nach [PPTX, PPT und ODP](/slides/de/net/save-presentation/) speichern und in [PDF](/slides/de/net/convert-powerpoint-to-pdf/), [XPS](/slides/de/net/convert-powerpoint-to-xps/), [HTML](/slides/de/net/convert-powerpoint-to-html/), [SVG](/slides/de/net/render-a-slide-as-an-svg-image/) und [Bilder](/slides/de/net/convert-powerpoint-to-png/) exportieren, unter anderem.

### Kann ich von einer Vorlage (POTX/POTM) ausgehen und als reguläres PPTX speichern?

Ja. Laden Sie die Vorlage und speichern Sie sie im gewünschten Format; POTX/POTM/PPTM und ähnliche Formate werden [unterstützt](/slides/de/net/supported-file-formats/).

### Wie kann ich die Foliengröße bzw. das Seitenverhältnis beim Erstellen einer Präsentation steuern?

Stellen Sie die [slide size](/slides/de/net/slide-size/) ein (einschließlich Voreinstellungen wie 4:3 und 16:9 oder benutzerdefinierte Abmessungen) und wählen Sie, wie der Inhalt skaliert werden soll.

### In welchen Einheiten werden Größen und Koordinaten gemessen?

In Punkten: 1 Zoll entspricht 72 Einheiten.

### Wie gehe ich mit sehr großen Präsentationen (mit vielen Mediendateien) um, um den Speicherverbrauch zu reduzieren?

Verwenden Sie [BLOB management strategies](/slides/de/net/manage-blob/), begrenzen Sie den Speicher im Arbeitsspeicher, indem Sie temporäre Dateien nutzen, und bevorzugen Sie dateibasierte Workflows gegenüber rein speicherinternen Streams.

### Kann ich Präsentationen parallel erstellen/speichern?

Sie können nicht dieselbe [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/) Instanz von [multiple threads](/slides/de/net/multithreading/) aus bedienen. Führen Sie separate, isolierte Instanzen pro Thread oder Prozess aus.

### Wie entferne ich das Testwasserzeichen und die Einschränkungen?

[Apply a license](/slides/de/net/licensing/) einmal pro Prozess. Die Lizenz‑XML darf nicht verändert werden, und die Lizenzkonfiguration sollte synchronisiert werden, wenn mehrere Threads beteiligt sind.

### Kann ich das von mir erstellte PPTX digital signieren?

Ja. [Digital signatures](/slides/de/net/digital-signature-in-powerpoint/) (Hinzufügen und Überprüfen) werden für Präsentationen unterstützt.

### Werden Makros (VBA) in erstellten Präsentationen unterstützt?

Ja. Sie können [create/edit VBA projects](/slides/de/net/presentation-via-vba/) verwenden und makrofähige Dateien wie PPTM/PPSM speichern.