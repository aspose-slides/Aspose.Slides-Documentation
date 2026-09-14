---
title: Präsentationsfolien in Python vergleichen
linktitle: Folien vergleichen
type: docs
weight: 50
url: /de/python-java/compare-slides/
keywords:
- Folien vergleichen
- Folienvergleich
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Vergleichen Sie PowerPoint- und OpenDocument-Präsentationen programmgesteuert mit Aspose.Slides für Python via Java. Erkennen Sie Folienunterschiede im Code schnell."
---
## **Übersicht**

Aspose.Slides ermöglicht den Vergleich von Folien, Layout‑Folien und Master‑Folien mithilfe der [equals](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseslide/#equals)‑Methode, die von der Klasse [BaseSlide](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseslide/) bereitgestellt wird. Diese Methode gibt `True` zurück, wenn die verglichenen Folien in ihrer Struktur und ihrem statischen Inhalt identisch sind.

## **Zwei Folien vergleichen**

Die [equals](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseslide/#equals)‑Methode in der Klasse [BaseSlide](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseslide/) gibt `True` für Folien, Layout‑Folien und Master‑Folien zurück, die in Struktur und statischem Inhalt identisch sind.

Zwei Folien sind gleich, wenn alle ihre Formen, Stile, Texte, Animationen und anderen Einstellungen gleich sind. Der Vergleich berücksichtigt keine eindeutigen Bezeichnerwerte wie Folien‑IDs oder dynamische Inhalte wie das aktuelle Datum in einem Datums‑Platzhalter.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

source_presentation = Presentation("AccessSlides.pptx")
try:
    target_presentation = Presentation("HelloWorld.pptx")
    try:
        for i in range(source_presentation.getMasters().size()):
            for j in range(target_presentation.getMasters().size()):
                if source_presentation.getMasters().get_Item(i).equals(target_presentation.getMasters().get_Item(j)):
                    print(f"AccessSlides MasterSlide#{i} is equal to HelloWorld MasterSlide#{j}")
    finally:
        target_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **FAQ**

**Hat die Tatsache, dass eine Folie ausgeblendet ist, Einfluss auf den Vergleich der Folien selbst?**

[Hidden status](https://reference.aspose.com/slides/de/python-java/aspose.slides/slide/#getHidden) ist eine Präsentations‑/Wiedergabe‑Ebene‑Eigenschaft, kein visueller Inhalt. Die Gleichheit zweier bestimmter Folien wird durch ihre Struktur und ihren statischen Inhalt bestimmt; die bloße Tatsache, dass eine Folie ausgeblendet ist, macht die Folien nicht unterschiedlich.

**Werden Hyperlinks und deren Parameter berücksichtigt?**

Ja. Links sind Teil des statischen Inhalts einer Folie. Wenn die URL oder die Hyperlink‑Aktion abweicht, wird dies in der Regel als Unterschied im statischen Inhalt behandelt.

**Wenn ein Diagramm auf eine externe Excel‑Datei verweist, werden die Inhalte dieser Datei berücksichtigt?**

Nein. Der Vergleich wird anhand der Folien selbst durchgeführt. Externe Datenquellen werden in der Regel zum Vergleich nicht gelesen; es wird nur das berücksichtigt, was in der Struktur und im statischen Zustand der Folie vorhanden ist.