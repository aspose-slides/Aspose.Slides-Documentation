---
title: Präsentationszugänglichkeit in Python über Java verwalten
linktitle: Präsentationszugänglichkeit
type: docs
weight: 30
url: /de/python-java/presentation-accessibility/
keywords:
- Präsentationszugänglichkeit
- Als dekorativ kennzeichnen
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Entdecken Sie, wie Aspose.Slides für Python über Java die automatisierte Überprüfung der Präsentationszugänglichkeit in PPT-, PPTX- und ODP-Dateien unterstützt - das Erlebnis für Bildschirmleser verbessert und die Konformität erhöht."
---
## **Einleitung**

Barrierefreiheit von Präsentationen stellt sicher, dass Personen, die unterstützende Technologien verwenden – wie Bildschirmleser, Braille‑Displays oder reine Tastaturnavigation – Ihre Folien ebenso verstehen und navigieren können wie sehende Nutzer mit Maus. Gute Praxis konzentriert sich auf eine klare Lesereihenfolge, sinnvolle alternative Texte für informative Grafiken, ausreichenden Farbkontrast, lesbare Typografie, beschreibende Link‑Texte und das Vermeiden von Bedeutungsübermittlung ausschließlich über Farbe oder Position. Wird Barrierefreiheit von Anfang an geplant, entsteht eine klarere Struktur, konsistentere Grafiken und Inhalte, die jeden Betrachter ohne Umwege erreichen.

## **Als dekorativ kennzeichnen**

„Als dekorativ kennzeichnen“ markiert rein ornamentale Visuals, sodass Bildschirmleser sie überspringen, Hintergrundgeräusche reduzieren und der Fokus auf sinnvolle Inhalte bleibt. Anwenden sollte man dies auf Hintergründe, Verzierungselemente und Abstandshalter – niemals auf Diagramme, Icons oder Bilder, die Informationen vermitteln. Aspose.Slides stellt diese Markierung für Erkennung und Validierung bereit und ermöglicht automatisierte Barrierefreiheitsprüfungen sowie Bereinigungen.

![Als dekorativ kennzeichnen](mark_as_decorative.png)

Der folgende Codeausschnitt zeigt, wie ermittelt wird, ob eine Form als dekorativ gekennzeichnet ist.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    print(f"Is shape decorative: {shape.isDecorative()}")
finally:
    presentation.dispose()
```