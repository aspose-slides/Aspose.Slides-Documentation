---
title: Verwalten der Präsentationszugänglichkeit in .NET
linktitle: Präsentationszugänglichkeit
type: docs
weight: 30
url: /de/net/presentation-accessibility/
keywords:
- Präsentationszugänglichkeit
- Als dekorativ markieren
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Automatisieren Sie Prüfungen zur Präsentationszugänglichkeit in PPT-, PPTX- und ODP-Dateien mit Aspose.Slides für .NET – verbessern Sie das Erlebnis von Screenreadern und erhöhen Sie die Konformität."
---

## **Übersicht**

Barrierefreiheit von Präsentationen stellt sicher, dass Personen, die unterstützende Technologien verwenden – wie Screenreader, Braille‑Displays oder rein tastaturbasierte Navigation – Ihre Folien genauso gut verstehen und navigieren können wie sehende, mit Maus arbeitende Zuschauer. Gute Praxis konzentriert sich auf eine klare Lesereihenfolge, sinnvolle Alternativtexte für informative Grafiken, ausreichenden Farbkontrast, gut lesbare Typografie, beschreibende Link‑Texte und darauf, Bedeutungen nicht ausschließlich über Farbe oder Position zu vermitteln. Wenn Barrierefreiheit von Anfang an geplant wird, entsteht eine sauberere Struktur, konsistentere Visualisierungen und Inhalte, die jeden Betrachter ohne Umwege erreichen.

## **Als dekorativ kennzeichnen**

Die Markierung “Als dekorativ” kennzeichnet rein ornamentale Visuals, sodass Screenreader sie überspringen, was das Rauschen reduziert und den Fokus auf bedeutungsvolle Inhalte legt. Wenden Sie sie auf Hintergründe, Verzierungen und Abstandshalter an – niemals auf Diagramme, Symbole oder Bilder, die Informationen vermitteln. Aspose.Slides stellt dieses Flag für Erkennung und Validierung bereit und ermöglicht automatisierte Barrierefreiheitsprüfungen und Bereinigungen.

![Als dekorativ kennzeichnen](mark_as_decorative.png)

Das folgende Codebeispiel zeigt, wie ermittelt wird, ob eine Form als dekorativ markiert ist.
```cs
using var presentation = new Presentation("sample.pptx");

var shape = presentation.Slides[0].Shapes[0];
Console.WriteLine($"Is shape decorative: {shape.IsDecorative}");
```
