---
title: Foliengröße anpassen
linktitle: Foliengröße
type: docs
weight: 70
url: /de/net/slide-size/
keywords: "Foliengröße festlegen, Präsentationsabmessungen anpassen, PowerPoint-Seitenverhältnis, C#, Csharp, .NET, Aspose.Slides"
description: "Erfahren Sie, wie Sie Foliengrößen oder Seitenverhältnisse in PowerPoint mit C# oder .NET und Aspose.Slides anpassen und ändern."
---

## **Anpassen von Foliengrößen und Seitenverhältnissen in PowerPoint**

Aspose.Slides for .NET bietet umfassende Werkzeuge zum Anpassen der Foliengröße und des Seitenverhältnisses in PowerPoint‑Präsentationen, was sowohl für den Druck als auch für die Anzeige auf Bildschirmen entscheidend ist.

### **Beliebte Foliengrößen und Seitenverhältnisse**

- **Standard (4:3‑Seitenverhältnis)**: Ideal für ältere Bildschirme und Geräte.  
- **Widescreen (16:9‑Seitenverhältnis)**: Empfohlen für moderne Projektoren und Displays.

Stellen Sie die Konsistenz in Ihrer gesamten Präsentation sicher, da eine einzelne Foliengröße und ein einheitliches Seitenverhältnis für alle Folien gelten. Für optimale Ergebnisse legen Sie die Folienabmessungen zu Beginn des Erstellungsprozesses fest, um Komplikationen zu vermeiden.

{{% alert color="primary" %}} 
Standardmäßig verwenden mit Aspose.Slides erstellte Präsentationen das 4:3‑Seitenverhältnis. 
{{% /alert %}}

## **Wie man die Foliengröße in PowerPoint ändert**

Dieses Beispiel zeigt, wie man die Foliengröße einer Präsentation mit Aspose.Slides in C# ändert:
```csharp
using (Presentation pres = new Presentation("presentation-4x3.pptx"))
{
    pres.SlideSize.SetSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.Save("presentation-16x9.pptx", SaveFormat.Pptx);
}
```


## **Benutzerdefinierte Foliengrößen angeben**

Die Anpassung der Foliengröße an Ihre spezifischen Bedürfnisse, etwa für besondere Layouts auf Papier oder spezielle Bildschirmvorgaben, kann vorteilhaft sein. So setzen Sie eine benutzerdefinierte Foliengröße mit Aspose.Slides for .NET:
```csharp
using (Presentation pres = new Presentation("presentation.pptx"))
{
    pres.SlideSize.SetSize(780, 540, SlideSizeScaleType.DoNotScale); // A4 Papiergröße
    pres.Save("presentation-a4.pptx", SaveFormat.Pptx);
}
```


## **Umgang mit Folieninhalten nach dem Ändern der Größe**

Nach dem Ändern der Größe können Folieninhalte verzerrt werden. Sie können steuern, wie Aspose.Slides dieses Resizing verwaltet:

- **`DoNotScale`**: Objekte in ihrer Originalgröße belassen, um eine Skalierung zu vermeiden.  
- **`EnsureFit`**: Objekte verkleinern, damit sie in kleinere Folien passen, wodurch Inhaltsverlust verhindert wird.  
- **`Maximize`**: Objekte vergrößern, um größere Folien ästhetisch konsistent zu füllen.

Beispiel für die Verwendung der Einstellung `Maximize` bei der Anpassung der Foliengröße:
```csharp
using (Presentation pres = new Presentation("presentation.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```


## **FAQ**

**Kann ich eine benutzerdefinierte Foliengröße mit anderen Einheiten als Zoll festlegen (z. B. Punkte oder Millimeter)?**

Ja. Aspose.Slides verwendet intern Punkte, wobei 1 Punkt 1/72 Zoll entspricht. Sie können jede Einheit (wie Millimeter oder Zentimeter) in Punkte umrechnen und die umgerechneten Werte zur Definition von Folienbreite und -höhe verwenden.

**Beeinflusst eine sehr große benutzerdefinierte Foliengröße die Leistung und den Speicherverbrauch beim Rendern?**

Ja. Größere Folienabmessungen (in Punkten) in Kombination mit einer höheren Render‑Skalierung führen zu erhöhtem Speicherverbrauch und längeren Verarbeitungszeiten. Ziel ist eine praktikable Foliengröße; passen Sie die Rendering‑Skalierung nur bei Bedarf an, um die gewünschte Ausgabequalität zu erreichen.

**Kann ich eine nicht‑standardmäßige Foliengröße definieren und dann Folien aus Präsentationen zusammenführen, die unterschiedliche Größen haben?**

Sie können nicht [Präsentationen zusammenführen](/slides/de/net/merge-presentation/), solange die Folien unterschiedliche Größen haben – passen Sie zunächst eine Präsentation an die Größe der anderen an. Beim Ändern der Foliengröße können Sie über die [SlideSizeScaleType]‑Option festlegen, wie vorhandene Inhalte behandelt werden. Nach dem Angleichen der Größen können Sie Folien zusammenführen und dabei das Format beibehalten.

**Kann ich Thumbnails für einzelne Formen oder bestimmte Bereiche einer Folie erzeugen, und berücksichtigen diese die neue Foliengröße?**

Ja. Aspose.Slides kann Thumbnails für [gesamte Folien](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/) sowie für [ausgewählte Formen](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) rendern. Die resultierenden Bilder spiegeln die aktuelle Foliengröße und das Seitenverhältnis wider, wodurch ein konsistenter Bildausschnitt und eine korrekte Geometrie gewährleistet sind.