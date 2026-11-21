---
title: Ändern der Foliengröße in einer Präsentation mit .NET
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
description: "Erfahren Sie, wie Sie Folien in PPT-, PPTX- und ODP-Dateien mit .NET und Aspose.Slides schnell ändern können, um Präsentationen für jeden Bildschirm zu optimieren, ohne Qualitätsverlust."
---
## **Einführung**

Aspose.Slides für .NET bietet umfassende Werkzeuge zum Anpassen der Foliengröße und des Seitenverhältnisses in PowerPoint‑Präsentationen, die sowohl für den Druck als auch für die Anzeige auf dem Bildschirm entscheidend sind.

Beliebte Foliengrößen und Verhältnisse:

- **Standard (4:3 Seitenverhältnis)**: Ideal für ältere Bildschirme und Geräte.
- **Widescreen (16:9 Seitenverhältnis)**: Empfohlen für moderne Projektoren und Displays.

Stellen Sie die Konsistenz Ihrer gesamten Präsentation sicher, indem Sie eine einheitliche Foliengröße und ein einheitliches Seitenverhältnis für alle Folien verwenden. Für optimale Ergebnisse sollten Sie die Folienabmessungen zu Beginn des Erstellungsprozesses Ihrer Präsentation festlegen, um Komplikationen zu vermeiden.

{{% alert color="info" %}} 
Standardmäßig verwenden mit Aspose.Slides erstellte Präsentationen das Standard‑Seitenverhältnis 4:3.
{{% /alert %}}

Notiz- und Handzettelseiten haben andere Abmessungen als reguläre Folien. Siehe [Notizseitengröße](/slides/de/net/notes-size/) um ihre Größe und Ausrichtung zu ändern.

## **So ändern Sie die Foliengröße in einer Präsentation**

Dieses Beispiel zeigt, wie Sie die Foliengröße einer Präsentation mit Aspose.Slides in C# ändern:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation-4x3.pptx"))
{
    pres.SlideSize.SetSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.Save("presentation-16x9.pptx", SaveFormat.Pptx);
}
```

## **Benutzerdefinierte Foliengrößen angeben**

Die Foliengröße an Ihre spezifischen Anforderungen anzupassen, etwa für einzigartige Papierformate oder Bildschirmvorgaben, kann vorteilhaft sein. Hier erfahren Sie, wie Sie mit Aspose.Slides für .NET eine benutzerdefinierte Foliengröße festlegen:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation.pptx"))
{
    pres.SlideSize.SetSize(780, 540, SlideSizeScaleType.DoNotScale); // A4-Papiergröße
    pres.Save("presentation-a4.pptx", SaveFormat.Pptx);
}
```

## **Umgang mit Folieninhalten nach der Größenänderung**

Nach der Größenänderung können Folieninhalte verzerrt werden. Sie können steuern, wie Aspose.Slides diese Anpassung handhabt:

- **`DoNotScale`**: Objekte in ihrer ursprünglichen Größe belassen, um Skalierung zu vermeiden.
- **`EnsureFit`**: Objekte skalieren, um auf kleinere Folien zu passen, und Inhaltsverlust verhindern.
- **`Maximize`**: Objekte vergrößern, um zu größeren Folien zu passen und ästhetische Konsistenz zu gewährleisten.

Beispiel für die Verwendung der Einstellung `Maximize` zur Anpassung der Foliengröße:

```csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("presentation.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```

## **FAQ**

### Kann ich eine benutzerdefinierte Foliengröße mit anderen Einheiten als Zoll festlegen (zum Beispiel Punkte oder Millimeter)?

Ja. Aspose.Slides verwendet intern Punkte, wobei 1 Punkt 1/72 Zoll entspricht. Sie können jede Einheit (wie Millimeter oder Zentimeter) in Punkte umrechnen und die umgerechneten Werte verwenden, um die Folienbreite und -höhe festzulegen.

### Wirkt sich eine sehr große benutzerdefinierte Foliengröße auf die Leistung und den Speicherverbrauch beim Rendern aus?

Ja. Größere Folienabmessungen (in Punkten) in Kombination mit einer höheren Render‑Skala führen zu einem erhöhten Speicherverbrauch und längeren Verarbeitungszeiten. Streben Sie eine praktische Foliengröße an und passen Sie die Render‑Skala nur bei Bedarf an, um die gewünschte Ausgabequalität zu erreichen.

### Kann ich eine nicht standardmäßige Foliengröße definieren und dann Folien aus Präsentationen zusammenführen, die unterschiedliche Größen haben?

Sie können nicht [Präsentationen zusammenführen](/slides/de/net/merge-presentation/) durchführen, solange die Präsentationen unterschiedliche Foliengrößen haben – passen Sie zunächst eine Präsentation an die andere an. Beim Ändern der Foliengröße können Sie wählen, wie vorhandene Inhalte über die Option [SlideSizeScaleType](https://reference.aspose.com/slides/de/net/aspose.slides/slidesizescaletype/) behandelt werden. Nach der Angleichung der Größen können Sie Folien zusammenführen und dabei das Format beibehalten.

### Kann ich Miniaturansichten für einzelne Formen oder bestimmte Bereiche einer Folie erzeugen, und werden sie die neue Foliengröße berücksichtigen?

Ja. Aspose.Slides kann Miniaturansichten für [gesamte Folien](https://reference.aspose.com/slides/de/net/aspose.slides/slide/getimage/) sowie für [ausgewählte Formen](https://reference.aspose.com/slides/de/net/aspose.slides/shape/getimage/) rendern. Die resultierenden Bilder spiegeln die aktuelle Foliengröße und das Seitenverhältnis wider und gewährleisten einheitliche Bildrahmung und Geometrie.