---
title: Ändern der Foliengröße einer Präsentation in .NET
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
descriptions: "Erfahren Sie, wie Sie Folien in PPT-, PPTX- und ODP-Dateien mit .NET und Aspose.Slides schnell skalieren, Präsentationen für jeden Bildschirm optimieren, ohne Qualität zu verlieren."
---

## **Anpassen von Foliengrößen und Seitenverhältnissen in einer Präsentation**

Aspose.Slides for .NET bietet umfassende Werkzeuge zum Anpassen der Foliengröße und des Seitenverhältnisses in PowerPoint‑Präsentationen, die sowohl für den Druck als auch für die Anzeige auf Bildschirmen entscheidend sind. 

### **Beliebte Foliengrößen und Verhältnisse**

- **Standard (4:3 Seitenverhältnis)**: Ideal für ältere Bildschirme und Geräte.
  
- **Widescreen (16:9 Seitenverhältnis)**: Empfohlen für moderne Projektoren und Bildschirme.

Stellen Sie die Konsistenz Ihrer gesamten Präsentation sicher, da eine einheitliche Foliengröße und ein einheitliches Seitenverhältnis für alle Folien gelten. Für optimale Ergebnisse legen Sie die Folienabmessungen zu Beginn des Erstellungsprozesses fest, um Komplikationen zu vermeiden.

{{% alert color="primary" %}} 
Standardmäßig verwenden Präsentationen, die mit Aspose.Slides erstellt wurden, das Standard‑Seitenverhältnis 4:3.
{{% /alert %}}

## **Wie Sie die Foliengröße in einer Präsentation ändern**

Dieses Beispiel zeigt, wie die Foliengröße einer Präsentation mit Aspose.Slides in C# geändert wird:
```csharp
using (Presentation pres = new Presentation("presentation-4x3.pptx"))
{
    pres.SlideSize.SetSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.Save("presentation-16x9.pptx", SaveFormat.Pptx);
}
```


## **Benutzerdefinierte Foliengrößen festlegen**

Die Anpassung der Foliengröße an Ihre spezifischen Bedürfnisse, etwa für besondere Papierformate oder Bildschirmvorgaben, kann vorteilhaft sein. So legen Sie eine benutzerdefinierte Foliengröße mit Aspose.Slides für .NET fest:
```csharp
using (Presentation pres = new Presentation("presentation.pptx"))
{
    pres.SlideSize.SetSize(780, 540, SlideSizeScaleType.DoNotScale); // A4-Papiergröße
    pres.Save("presentation-a4.pptx", SaveFormat.Pptx);
}
```


## **Umgang mit Folieninhalten nach dem Ändern der Größe**

Nach dem Ändern der Größe können Folieninhalte verzerrt werden. Sie können steuern, wie Aspose.Slides dieses Resizing handhabt:

- **`DoNotScale`**: Objekte in ihrer Originalgröße belassen, um Skalierung zu vermeiden.
- **`EnsureFit`**: Objekte skalieren, damit sie auf kleinere Folien passen und Inhaltsverlust verhindert wird.
- **`Maximize`**: Objekte vergrößern, damit sie zu größeren Folien passen und ästhetische Konsistenz gewährleistet ist.

Beispiel für die Verwendung der Einstellung `Maximize` zur Anpassung der Foliengröße:
```csharp
using (Presentation pres = new Presentation("presentation.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```


## **FAQ**

**Kann ich eine benutzerdefinierte Foliengröße mit anderen Einheiten als Zoll festlegen (z. B. Punkte oder Millimeter)?**

Ja. Aspose.Slides verwendet intern Punkte, wobei 1 Punkt 1/72 Zoll entspricht. Sie können jede Einheit (z. B. Millimeter oder Zentimeter) in Punkte umrechnen und die umgerechneten Werte zur Definition von Folienbreite und -höhe verwenden.

**Wird eine sehr große benutzerdefinierte Foliengröße die Leistung und den Speicherverbrauch beim Rendern beeinträchtigen?**

Ja. Größere Folienabmessungen (in Punkten) in Kombination mit einem höheren Render‑Skalenfaktor führen zu erhöhtem Speicherverbrauch und längeren Verarbeitungszeiten. Streben Sie eine praktische Foliengröße an und passen Sie den Render‑Skalenfaktor nur bei Bedarf an, um die gewünschte Ausgabequalität zu erzielen.

**Kann ich eine nicht‑standardmäßige Foliengröße festlegen und dann Folien aus Präsentationen, die unterschiedliche Größen haben, zusammenführen?**

Sie können nicht [Präsentationen zusammenführen](/slides/de/net/merge-presentation/) durchführen, solange die Präsentationen unterschiedliche Foliengrößen haben – zuerst müssen Sie eine Präsentation auf die Größe der anderen anpassen. Beim Ändern der Foliengröße können Sie über die Option [SlideSizeScaleType](https://reference.aspose.com/slides/net/aspose.slides/slidesizescaletype/) festlegen, wie vorhandene Inhalte behandelt werden. Nach der Angleichung der Größen können Sie Folien zusammenführen und dabei die Formatierung beibehalten.

**Kann ich Miniaturbilder für einzelne Formen oder bestimmte Bereiche einer Folie erzeugen, und berücksichtigen sie die neue Foliengröße?**

Ja. Aspose.Slides kann Miniaturbilder für [gesamte Folien](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/) sowie für [ausgewählte Formen](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) rendern. Die resultierenden Bilder widerspiegeln die aktuelle Foliengröße und das Seitenverhältnis und gewährleisten eine konsistente Bildausschnitt‑ und Geometrie.