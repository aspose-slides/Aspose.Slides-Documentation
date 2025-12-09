---
title: Präsentationsfolien in Python vergleichen
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
description: "Vergleichen Sie PowerPoint- und OpenDocument-Präsentationen programmgesteuert mit Aspose.Slides für Python über .NET. Erkennen Sie Folienunterschiede im Code schnell."
---

## **Zwei Folien vergleichen**
Die Equals‑Methode wurde dem Interface [IBaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseslide/) und der Klasse [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/) hinzugefügt. Sie liefert true für Folien/Layouts und Master‑Folien, die in ihrer Struktur und ihrem statischen Inhalt identisch sind.

Zwei Folien sind gleich, wenn alle Formen, Stile, Texte, Animationen und weitere Einstellungen übereinstimmen etc. Der Vergleich berücksichtigt keine eindeutigen Identifier‑Werte, z. B. SlideId, und keinen dynamischen Inhalt, z. B. den aktuellen Datumswert im Date Placeholder.
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

**Beeinflusst die Tatsache, dass eine Folie ausgeblendet ist, den Vergleich der Folien selbst?**

[Hidden status](https://reference.aspose.com/slides/python-net/aspose.slides/slide/hidden/) ist eine Eigenschaft auf Präsentations‑/Wiedergabe‑Ebene, nicht visueller Inhalt. Die Gleichheit zweier bestimmter Folien wird durch ihre Struktur und ihren statischen Inhalt bestimmt; die reine Tatsache, dass eine Folie ausgeblendet ist, macht die Folien nicht unterschiedlich.

**Werden Hyperlinks und deren Parameter berücksichtigt?**

Ja. Links sind Teil des statischen Inhalts einer Folie. Wenn die URL oder die Hyperlink‑Aktion abweicht, wird dies normalerweise als Unterschied im statischen Inhalt angesehen.

**Wenn ein Diagramm auf eine externe Excel‑Datei verweist, werden die Inhalte dieser Datei berücksichtigt?**

Nein. Der Vergleich erfolgt anhand der Folien selbst. Externe Datenquellen werden in der Regel zum Vergleich nicht ausgelesen; es werden nur die in der Folienstruktur und im statischen Zustand vorhandenen Inhalte berücksichtigt.