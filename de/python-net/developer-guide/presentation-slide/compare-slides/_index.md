---
title: Vergleiche Folien
type: docs
weight: 50
url: /de/python-net/compare-slides/
keywords: "Vergleiche PowerPoint-Folien, Vergleiche zwei Folien, Präsentation, Python, Aspose.Slides"
description: "Vergleiche PowerPoint-Präsentationsfolien in Python"
---

## **Vergleiche Zwei Folien**
Die Equals-Methode wurde zur [IBaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseslide/) Schnittstelle und zur [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/) Klasse hinzugefügt. Sie gibt true für Folien/Layout und Folien/Hauptfolien zurück, die in ihrer Struktur und ihrem statischen Inhalt identisch sind.

Zwei Folien sind gleich, wenn alle Formen, Stile, Texte, Animationen und andere Einstellungen usw. übereinstimmen. Der Vergleich berücksichtigt keine einzigartigen Identifikatorwerte, z.B. SlideId und dynamischen Inhalt, z.B. den aktuellen Datumswert im Datumsplatzhalter.

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as p1:
    with slides.Presentation(path + "HelloWorld.pptx") as p2:
        for i in range(len(p1.masters)):
            for j in range(len(p2.masters)):
                if p1.masters[i] == p2.masters[j]:
                    print("MasterSlide#{0} der Präsentation1 ist gleich MasterSlide#{1} der Präsentation2".format(i,j))
```