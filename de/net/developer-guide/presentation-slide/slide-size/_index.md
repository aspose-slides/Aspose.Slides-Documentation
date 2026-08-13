---
title: Foliengröße einer Präsentation in .NET ändern
linktitle: Foliengröße
type: docs
weight: 70
url: /de/net/slide-size/
keywords:
- Foliengröße
- Seitenverhältnis
- Standard
- Breitbild
- 4:3
- 16:9
- Foliengröße festlegen
- Foliengröße ändern
- Benutzerdefinierte Foliengröße
- Spezielle Foliengröße
- Einzigartige Foliengröße
- Vollformatfolie
- Bildschirmtyp
- Nicht skalieren
- Passend skalieren
- Maximieren
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie Folien in PPT-, PPTX- und ODP-Dateien mit .NET und Aspose.Slides schnell skalieren und Präsentationen für jeden Bildschirm optimieren, ohne Qualitätsverlust."
---
## **Einleitung**

Aspose.Slides für .NET bietet umfassende Werkzeuge zum Anpassen der Foliengröße und des Seitenverhältnisses in PowerPoint-Präsentationen, die sowohl für den Druck als auch für die Bildschirmanzeige entscheidend sind. 

Beliebte Foliengrößen und -verhältnisse:

- **Standard (4:3 Seitenverhältnis)**: Ideal für ältere Bildschirme und Geräte.
- **Breitbild (16:9 Seitenverhältnis)**: Empfohlen für moderne Projektoren und Anzeigen.

Stellen Sie die Konsistenz Ihrer gesamten Präsentation sicher, da eine einheitliche Foliengröße und ein einheitliches Seitenverhältnis für alle Folien gelten. Für optimale Ergebnisse setzen Sie die Folienmaße zu Beginn des Erstellungsprozesses Ihrer Präsentation, um Komplikationen zu vermeiden.

{{% alert color="info" %}} 
Standardmäßig verwenden mit Aspose.Slides erstellte Präsentationen das Standard‑Seitenverhältnis 4:3.
{{% /alert %}}

## **Wie man die Foliengröße in einer Präsentation ändert**

Dieses Beispiel zeigt, wie man die Foliengröße einer Präsentation mit Aspose.Slides in C# ändert:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation-4x3.pptx"))
{
    pres.SlideSize.SetSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.Save("presentation-16x9.pptx", SaveFormat.Pptx);
}
```

## **Benutzerdefinierte Foliengrößen festlegen**

Die Anpassung der Foliengröße an Ihre spezifischen Bedürfnisse, z. B. für besondere Papierformate oder Bildschirmspezifikationen, kann vorteilhaft sein. So legen Sie eine benutzerdefinierte Foliengröße mit Aspose.Slides für .NET fest:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation.pptx"))
{
    pres.SlideSize.SetSize(780, 540, SlideSizeScaleType.DoNotScale); // A4-Papiergröße
    pres.Save("presentation-a4.pptx", SaveFormat.Pptx);
}
```

## **Folieninhalt nach der Größenänderung behandeln**

Nach dem Ändern der Größe können Inhalte der Folie verzerrt werden. Sie können steuern, wie Aspose.Slides diese Größenänderung verwaltet:

- **`DoNotScale`**: Objekte in ihrer Originalgröße belassen, um Skalierung zu vermeiden.
- **`EnsureFit`**: Objekte skalieren, damit sie auf kleinere Folien passen, und so Inhaltsverlust verhindern.
- **`Maximize`**: Objekte vergrößern, damit sie zu größeren Folien passen, um ästhetische Konsistenz zu gewährleisten.

Beispiel für die Verwendung der Einstellung `Maximize` zur Anpassung der Foliengröße:

```csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("presentation.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```

## **FAQ**

### Kann ich eine benutzerdefinierte Foliengröße mit anderen Einheiten als Zoll festlegen (z. B. Punkten oder Millimetern)?

Ja. Aspose.Slides verwendet intern Punkte, wobei 1 Punkt 1/72 Zoll entspricht. Sie können jede Einheit (wie Millimeter oder Zentimeter) in Punkte umrechnen und die umgerechneten Werte zur Definition von Folienbreite und -höhe verwenden.

### Wirkt sich eine sehr große benutzerdefinierte Foliengröße während des Renderings auf Leistung und Speicherverbrauch aus?

Ja. Größere Folienabmessungen (in Punkten) in Kombination mit einer höheren Rendering‑Skala führen zu erhöhtem Speicherverbrauch und längeren Verarbeitungszeiten. Ziel ist eine praktische Foliengröße, und die Rendering‑Skala sollte nur bei Bedarf angepasst werden, um die gewünschte Ausgabequalität zu erreichen.

### Kann ich eine nicht‑standardmäßige Foliengröße definieren und dann Folien aus Präsentationen zusammenführen, die unterschiedliche Größen haben?

Sie können nicht [Präsentationen zusammenführen](/slides/de/net/merge-presentation/), solange sie unterschiedliche Foliengrößen haben – zuerst müssen Sie eine Präsentation an die andere anpassen. Beim Ändern der Foliengröße können Sie über die Option [SlideSizeScaleType](https://reference.aspose.com/slides/de/net/aspose.slides/slidesizescaletype/) festlegen, wie vorhandener Inhalt behandelt wird. Nach dem Angleichen der Größen können Sie Folien zusammenführen und dabei die Formatierung beibehalten.

### Kann ich Miniaturansichten für einzelne Formen oder bestimmte Bereiche einer Folie erzeugen, und berücksichtigen sie die neue Foliengröße?

Ja. Aspose.Slides kann Miniaturansichten für [gesamte Folien](https://reference.aspose.com/slides/de/net/aspose.slides/slide/getimage/) sowie für [ausgewählte Formen](https://reference.aspose.com/slides/de/net/aspose.slides/shape/getimage/) rendern. Die erzeugten Bilder spiegeln die aktuelle Foliengröße und das Seitenverhältnis wider und sorgen für eine konsistente Bildkomposition und Geometrie.