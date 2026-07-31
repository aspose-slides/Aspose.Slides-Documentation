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
- Vollgröße-Folie
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
description: "Erfahren Sie, wie Sie Folien in PPT-, PPTX- und ODP-Dateien mit .NET und Aspose.Slides schnell skalieren, um Präsentationen für jeden Bildschirm zu optimieren, ohne Qualitätsverlust."
---
## **Einleitung**

Aspose.Slides für .NET bietet umfassende Werkzeuge, um die Foliengröße und das Seitenverhältnis in PowerPoint‑Präsentationen anzupassen – ein entscheidender Faktor sowohl für den Druck als auch für die Anzeige auf Bildschirmen. 

Beliebte Foliengrößen und Seitenverhältnisse:

- **Standard (4:3‑Seitenverhältnis)**: Ideal für ältere Bildschirme und Geräte.
- **Widescreen (16:9‑Seitenverhältnis)**: Empfohlen für moderne Projektoren und Displays.

Stellen Sie Konsistenz in Ihrer gesamten Präsentation sicher, da eine einheitliche Foliengröße und ein einheitliches Seitenverhältnis für alle Folien gelten. Für optimale Ergebnisse legen Sie die Folienabmessungen zu Beginn des Erstellungsprozesses Ihrer Präsentation fest, um Komplikationen zu vermeiden.

{{% alert color="primary" %}} 
Standardmäßig verwenden mit Aspose.Slides erstellte Präsentationen das Standard‑Seitenverhältnis 4:3.
{{% /alert %}}

## **So ändern Sie die Foliengröße in einer Präsentation**

Dieses Beispiel zeigt, wie Sie die Foliengröße einer Präsentation mit Aspose.Slides in C# ändern:

```csharp
using (Presentation pres = new Presentation("presentation-4x3.pptx"))
{
    pres.SlideSize.SetSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.Save("presentation-16x9.pptx", SaveFormat.Pptx);
}
```

## **Benutzerdefinierte Foliengrößen festlegen**

Die Anpassung der Foliengröße an Ihre spezifischen Anforderungen – etwa für besondere Papierformate oder Bildschirmspezifikationen – kann vorteilhaft sein. So setzen Sie eine benutzerdefinierte Foliengröße mit Aspose.Slides für .NET:

```csharp
using (Presentation pres = new Presentation("presentation.pptx"))
{
    pres.SlideSize.SetSize(780, 540, SlideSizeScaleType.DoNotScale); // A4 Papiergröße
    pres.Save("presentation-a4.pptx", SaveFormat.Pptx);
}
```

## **Folieninhalt nach der Größenänderung verarbeiten**

Nach dem Ändern der Größe können Folieninhalte verzerrt werden. Sie können steuern, wie Aspose.Slides diese Größenanpassung behandelt:

- **`DoNotScale`**: Objekte in ihrer Originalgröße belassen, um Skalierung zu vermeiden.
- **`EnsureFit`**: Objekte skalieren, damit sie auf kleinere Folien passen, und Inhaltsverlust verhindern.
- **`Maximize`**: Objekte vergrößern, um zu größeren Folien zu passen und ein ästhetisch konsistentes Ergebnis zu erzielen.

Beispiel für die Verwendung der Einstellung `Maximize` bei der Foliengrößenanpassung:

```csharp
using (Presentation pres = new Presentation("presentation.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```

## **FAQ**

**Kann ich eine benutzerdefinierte Foliengröße mit anderen Einheiten als Zoll festlegen (z. B. Punkte oder Millimeter)?**

Ja. Aspose.Slides verwendet intern Punkte, wobei 1 Punkt 1/72 Zoll entspricht. Sie können jede Einheit (wie Millimeter oder Zentimeter) in Punkte umrechnen und die konvertierten Werte zur Definition von Folienbreite und -höhe verwenden.

**Wirkt sich eine sehr große benutzerdefinierte Foliengröße auf die Leistung und den Speicherverbrauch beim Rendern aus?**

Ja. Größere Folienabmessungen (in Punkten) in Kombination mit einem höheren Render‑Skalierungsfaktor führen zu höherem Speicherverbrauch und längeren Verarbeitungszeiten. Ziel sollte eine praktikable Foliengröße sein; passen Sie die Render‑Skalierung nur bei Bedarf an, um die gewünschte Ausgabequalität zu erreichen.

**Kann ich eine nicht‑standardmäßige Foliengröße definieren und dann Folien aus Präsentationen mit unterschiedlichen Größen zusammenführen?**

Sie können nicht [Präsentationen zusammenführen](/slides/de/net/merge-presentation/), solange sie unterschiedliche Foliengrößen haben – passen Sie zuerst eine Präsentation an die Größe der anderen an. Beim Ändern der Foliengröße können Sie wählen, wie vorhandene Inhalte über die Option [SlideSizeScaleType](https://reference.aspose.com/slides/de/net/aspose.slides/slidesizescaletype/) behandelt werden. Nach der Angleichung der Größen können Sie Folien zusammenführen und das Format beibehalten.

**Kann ich Miniaturansichten für einzelne Formen oder bestimmte Bereiche einer Folie erzeugen, und berücksichtigen sie die neue Foliengröße?**

Ja. Aspose.Slides kann Miniaturansichten für [gesamte Folien](https://reference.aspose.com/slides/de/net/aspose.slides/slide/getimage/) sowie für [ausgewählte Formen](https://reference.aspose.com/slides/de/net/aspose.slides/shape/getimage/) rendern. Die resultierenden Bilder spiegeln die aktuelle Foliengröße und das Seitenverhältnis wider, wodurch ein konsistenter Bildausschnitt und korrekte Geometrie gewährleistet sind.