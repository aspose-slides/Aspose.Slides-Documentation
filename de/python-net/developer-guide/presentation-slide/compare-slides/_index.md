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
description: "PowerPoint- und OpenDocument-Präsentationen programmgesteuert mit Aspose.Slides für Python via .NET vergleichen. Folienunterschiede im Code schnell erkennen."
---

## **Zwei Folien vergleichen**
Die **Equals**‑Methode wurde zur [IBaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseslide/)‑Schnittstelle und zur [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/)‑Klasse hinzugefügt. Sie gibt *true* zurück für Folien‑/Layout‑ und Folien‑Master‑Slides, die hinsichtlich ihrer Struktur und ihres statischen Inhalts identisch sind.

Zwei Folien sind gleich, wenn alle Formen, Stile, Texte, Animationen und sonstigen Einstellungen übereinstimmen usw. Der Vergleich berücksichtigt keine eindeutigen Identifikatorwerte, z. B. *SlideId*, und keinen dynamischen Inhalt, z. B. das aktuelle Datum in einem Datums‑Platzhalter.

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

**Hat die Tatsache, dass eine Folie ausgeblendet ist, Einfluss auf den Vergleich der Folien selbst?**

[Hidden status](https://reference.aspose.com/slides/python-net/aspose.slides/slide/hidden/) ist eine Eigenschaft auf Präsentations‑/Abspiel‑Ebene, nicht ein visueller Inhalt. Die Gleichheit zweier bestimmter Folien wird durch ihre Struktur und ihren statischen Inhalt bestimmt; allein das Ausblenden einer Folie macht die Folien nicht unterschiedlich.

**Werden Hyperlinks und deren Parameter berücksichtigt?**

Ja. Links sind Teil des statischen Inhalts einer Folie. Wenn die URL oder die Hyperlink‑Aktion abweicht, wird dies in der Regel als Unterschied im statischen Inhalt behandelt.

**Falls ein Diagramm auf eine externe Excel‑Datei verweist, werden die Inhalte dieser Datei berücksichtigt?**

Nein. Der Vergleich erfolgt anhand der Folien selbst. Externe Datenquellen werden im Allgemeinen nicht zur Vergleichszeit gelesen; es wird nur das berücksichtigt, was in der Struktur und im statischen Zustand der Folie vorhanden ist.