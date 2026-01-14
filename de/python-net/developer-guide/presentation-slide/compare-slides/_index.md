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
description: "Vergleichen Sie PowerPoint- und OpenDocument-Präsentationen programmgesteuert mit Aspose.Slides für Python via .NET. Identifizieren Sie Folienunterschiede im Code schnell."
---

## **Zwei Folien vergleichen**
Die Methode `equals` wurde zur Klasse [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/) hinzugefügt. Sie gibt true zurück für Folien/Layouts und Folien/Masterfolien, die in ihrer Struktur und ihrem statischen Inhalt identisch sind.

Zwei Folien sind gleich, wenn alle Formen, Stile, Texte, Animationen und andere Einstellungen usw. übereinstimmen. Der Vergleich berücksichtigt nicht eindeutige Identifier‑Werte, z.B. SlideId, und keinen dynamischen Inhalt, z.B. den aktuellen Datumswert in einem Datums‑Platzhalter.
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

[Hidden status](https://reference.aspose.com/slides/python-net/aspose.slides/slide/hidden/) ist eine Eigenschaft auf Präsentations-/Wiedergabeebene, nicht visueller Inhalt. Die Gleichheit zweier bestimmter Folien wird durch ihre Struktur und ihren statischen Inhalt bestimmt; die bloße Tatsache, dass eine Folie ausgeblendet ist, macht die Folien nicht unterschiedlich.

**Werden Hyperlinks und deren Parameter berücksichtigt?**

Ja. Links sind Teil des statischen Inhalts einer Folie. Wenn die URL oder die Hyperlink‑Aktion unterschiedlich ist, wird dies in der Regel als Unterschied im statischen Inhalt betrachtet.

**Wenn ein Diagramm auf eine externe Excel‑Datei verweist, werden die Inhalte dieser Datei berücksichtigt?**

Nein. Der Vergleich wird anhand der Folien selbst durchgeführt. Externe Datenquellen werden im Allgemeinen nicht zum Vergleichszeitpunkt ausgelesen; es wird nur das berücksichtigt, was in der Struktur und im statischen Zustand der Folie vorhanden ist.