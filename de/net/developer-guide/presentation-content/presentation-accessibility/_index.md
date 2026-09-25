---
title: Verwalten der Präsentationszugänglichkeit in .NET
linktitle: Präsentationszugänglichkeit
type: docs
weight: 30
url: /de/net/presentation-accessibility/
keywords:
- Präsentationszugänglichkeit
- Alternativtext
- Titel des Alternativtexts
- Beschreibung des Alternativtexts
- Als dekorativ markieren
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Automatisieren Sie Prüfungen zur Präsentationszugänglichkeit in PPT-, PPTX- und ODP-Dateien mit Aspose.Slides für .NET - verbessern Sie das Erlebnis von Screenreadern und erhöhen Sie die Konformität."
---
## **Einführung**

Alternativtext hilft Personen, die unterstützende Technologien verwenden, die Bedeutung von Bildern, Diagrammen und anderen informativen Formen zu verstehen. Dieser Artikel erklärt, wie man alternative Texttitel und Beschreibungen mit Aspose.Slides für .NET liest und aktualisiert, Zugänglichkeitsbeschreibungen von Shape‑Namen im Code unterscheidet und prüft, ob ein Shape als dekorativ markiert ist.

Diese Funktionen unterstützen die Zugänglichkeit von Präsentationen, garantieren sie aber nicht. Lesereihenfolge, Farbkontrast, Textlesbarkeit und weitere Zugänglichkeitsanforderungen müssen ebenfalls überprüft werden.

## **Verwalten von alternativen Texttiteln und Beschreibungen**

Verwenden Sie Alternativtext, um die Bedeutung von Bildern, Diagrammen und anderen informativen Formen Personen zu erklären, die sie nicht sehen können. Die folgenden Eigenschaften dienen unterschiedlichen Zwecken:

| Eigenschaft oder Inhalt | Zweck |
| --- | --- |
| [AlternativeTextTitle](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/alternativetexttitle/) | Ein kurzer Titel für die alternative Beschreibung. |
| [AlternativeText](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/alternativetext/) | Eine aussagekräftige Beschreibung des Inhalts oder Zwecks des Shapes im Kontext der Folie. |
| [Name](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/name/) | Der Name des Shapes, den Code verwenden kann, um ein bestimmtes Shape in der Präsentation zu finden. |
| Visible text | Auf der Folie angezeigter Inhalt, wie z. B. der Text eines Shapes oder der Titel und die Beschriftungen eines Diagramms. Das Aktualisieren des Alternativtexts ändert diesen Inhalt nicht. |

Wenn eine Präsentation als Vorlage wiederverwendet wird, kann der Code ein Shape über seinen [Name](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/name/) finden, bevor es aktualisiert wird. Dieser Name dient einem anderen Zweck als der Alternativtext, der erklärt, was die visuelle Darstellung dem Leser vermittelt. Die Suche nach dem Namen ermöglicht es Autoren, Beschreibungen zu verbessern oder zu übersetzen, ohne zu ändern, wie der Code das Shape findet. Namen können bearbeitet werden und sind nicht garantiert eindeutig, prüfen Sie also, dass der Name dem beabsichtigten Shape entspricht; siehe [Identify and Find Shapes](/slides/de/net/shape-manipulations/#identify-and-find-shapes).

Das folgende Beispiel erfordert `input.pptx` mit einem Bild eines Büroeingangs als erstes Shape auf der ersten Folie. Das Bild sollte nicht als dekorativ markiert sein. Das Beispiel liest und gibt den aktuellen alternativen Texttitel und die Beschreibung aus, aktualisiert beide Werte und speichert die Präsentation als `output.pptx`. Passen Sie die Formulierung an das tatsächliche Bild und die Informationen, die es vermittelt, an.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var shape = presentation.Slides[0].Shapes[0];

Console.WriteLine($"Alternative text title: {shape.AlternativeTextTitle}");
Console.WriteLine($"Alternative text description: {shape.AlternativeText}");

shape.AlternativeTextTitle = "Office entrance";
shape.AlternativeText = "The office entrance has a wheelchair ramp to the right of the steps.";

presentation.Save("output.pptx", SaveFormat.Pptx);
```

Allein das Hinzufügen von Alternativtext garantiert keine Zugänglichkeit der Präsentation oder die Einhaltung von Zugänglichkeitsstandards. Überprüfen Sie die Beschreibungen auf Genauigkeit und Relevanz und prüfen Sie zudem die Lesereihenfolge, den Farbkontrast, lesbaren Text und andere Zugänglichkeitsanforderungen. Informative Visuals sollten nicht als dekorativ markiert werden; der nächste Abschnitt zeigt, wie man [IsDecorative](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/isdecorative/) liest.

## **Als dekorativ markieren**

Die Markierung als dekorativ kennzeichnet rein ornamentale Visuals, sodass Screenreader sie überspringen, Rauschen reduzieren und die Konzentration auf bedeutungsvolle Inhalte lenken. Wenden Sie sie auf Hintergründe, Verzierungen und Abstandhalter an – niemals auf Diagramme, Symbole oder Bilder, die Informationen vermitteln. Aspose.Slides stellt diese Kennzeichnung für Erkennung und Validierung bereit, wodurch automatisierte Zugänglichkeitsprüfungen und Aufräumarbeiten ermöglicht werden.

![Als dekorativ markieren](mark_as_decorative.png)

Das folgende Codebeispiel zeigt, wie man ermittelt, ob ein Shape als dekorativ markiert ist.

```cs
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var shape = presentation.Slides[0].Shapes[0];
Console.WriteLine($"Is shape decorative: {shape.IsDecorative}");
```

## **FAQ**

**Was soll ich in den alternativen Texttitel und die Beschreibung einfügen?**

Verwenden Sie einen kurzen Titel, um das Thema zu identifizieren, und eine Beschreibung, um die Informationen zu erklären, die die Visualisierung im Kontext der Folie vermittelt. Bei einem Diagramm beschreiben Sie den relevanten Trend oder Vergleich, anstatt nur „Diagramm“ zu sagen.

**Sollte ich Alternativtext verwenden, um Shapes in einer Vorlage zu finden?**

Bevorzugen Sie es, das Shape über seinen [Name](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/name/) zu finden und zu prüfen, ob es das erwartete Shape ist. Alternativtext kann bearbeitet oder übersetzt werden, was Code, der nach einer genauen Beschreibung sucht, brechen kann; siehe [Identify and Find Shapes](/slides/de/net/shape-manipulations/).

**Wann sollte ein Shape als dekorativ markiert werden?**

Verwenden Sie die dekorative Kennzeichnung für Visuals, die keine Informationen hinzufügen, wie ornamentale Verzierungen. Bilder und Diagramme, die Bedeutung vermitteln, benötigen stattdessen eine passende Beschreibung.

**Macht das Hinzufügen von Alternativtext eine Präsentation vollständig zugänglich?**

Nein. Alternativtext deckt nur einen Teil der Zugänglichkeit ab. Überprüfen Sie zusätzlich die Lesereihenfolge, den Farbkontrast, die Lesbarkeit des Textes und andere relevante Anforderungen; das alleinige Setzen dieser Eigenschaften stellt keine Konformität sicher.