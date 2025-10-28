---
title: Folien in Python vergleichen
linktitle: Folien vergleichen
type: docs
weight: 50
url: /de/python-net/compare-slides/
keywords:
- Folien vergleichen
- Folienvergleich
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Vergleichen Sie PowerPoint- und OpenDocument-Präsentationen programmgesteuert mit Aspose.Slides für Python via .NET. Identifizieren Sie Folienunterschiede im Code schnell."
---

## **Zwei Folien vergleichen**
Equals‑Methode wurde dem Interface [IBaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseslide/) und der Klasse [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/) hinzugefügt. Sie liefert **true** für Folien‑/Layout‑ und Master‑Folien, die in Struktur und statischem Inhalt identisch sind.

Zwei Folien sind gleich, wenn alle Formen, Stile, Texte, Animationen und sonstigen Einstellungen übereinstimmen. Die Prüfung berücksichtigt keine eindeutigen Bezeichner‑Werte, z. B. SlideId, und keinen dynamischen Inhalt, z. B. das aktuelle Datum in einem Datums‑Platzhalter.

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as p1:
    with slides.Presentation(path + "HelloWorld.pptx") as p2:
        for i in range(len(p1.masters)):
            for j in range(len(p2.masters)):
                if p1.masters[i] == p2.masters[j]:
                    print("Presentation1 MasterSlide#{0} is equal to Presentation2 MasterSlide#{1}".format(i,j))
```

## **FAQ**

**Beeinflusst der versteckte Status einer Folie den Vergleich der Folien selbst?**

[Hidden status](https://reference.aspose.com/slides/python-net/aspose.slides/slide/hidden/) ist eine Eigenschaft auf Präsentations‑/Wiedergabe‑Ebene, nicht Teil des sichtbaren Inhalts. Die Gleichheit zweier bestimmter Folien wird durch ihre Struktur und ihren statischen Inhalt bestimmt; das bloße Verstecken einer Folie macht die Folien nicht unterschiedlich.

**Werden Hyperlinks und ihre Parameter berücksichtigt?**

Ja. Links gehören zum statischen Inhalt einer Folie. Wenn die URL oder die Hyperlink‑Aktion abweicht, wird dies in der Regel als Unterschied im statischen Inhalt gewertet.

**Wenn ein Diagramm auf eine externe Excel‑Datei verweist, werden die Inhalte dieser Datei berücksichtigt?**

Nein. Der Vergleich erfolgt ausschließlich anhand der Folien selbst. Externe Datenquellen werden im Allgemeinen zum Vergleichszeitpunkt nicht eingelesen; es wird nur das berücksichtigt, was in der Struktur und im statischen Zustand der Folie vorhanden ist.