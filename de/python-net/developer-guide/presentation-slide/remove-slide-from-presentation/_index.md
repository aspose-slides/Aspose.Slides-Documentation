---
title: Folie aus der Präsentation entfernen
type: docs
weight: 30
url: /python-net/remove-slide-from-presentation/
keywords: "Folie entfernen, Folie löschen, PowerPoint, Präsentation, Python, Aspose.Slides"
description: "Folie aus PowerPoint nach Referenz oder Index in Python entfernen"

---

Wenn eine Folie (oder deren Inhalt) überflüssig wird, können Sie sie löschen. Aspose.Slides bietet die [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse, die [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) kapselt, die ein Repository für alle Folien in einer Präsentation ist. Mithilfe von Zeigern (Referenz oder Index) für ein bekanntes [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) Objekt können Sie die Folie angeben, die Sie entfernen möchten.

## **Folie nach Referenz entfernen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Holen Sie eine Referenz der Folie, die Sie entfernen möchten, über ihre ID oder ihren Index.
1. Entfernen Sie die referenzierte Folie aus der Präsentation.
1. Speichern Sie die modifizierte Präsentation.

Dieser Python-Code zeigt Ihnen, wie Sie eine Folie über ihre Referenz entfernen:

```python
import aspose.slides as slides

# Instanziiert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
with slides.Presentation(path + "RemoveSlideUsingReference.pptx") as pres:
    # Greift auf eine Folie über ihren Index in der Folienkollektion zu
    slide = pres.slides[0]

    # Entfernt eine Folie über ihre Referenz
    pres.slides.remove(slide)

    # Speichert die modifizierte Präsentation
    pres.save("modified_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Folie nach Index entfernen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Entfernen Sie die Folie aus der Präsentation über ihre Indexposition.
1. Speichern Sie die modifizierte Präsentation.

Dieser Python-Code zeigt Ihnen, wie Sie eine Folie über ihren Index entfernen:

```python
import aspose.slides as slides

# Instanziiert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
with slides.Presentation(path + "RemoveSlideUsingIndex.pptx") as pres:
    # Entfernt eine Folie über ihren Folienindex
    pres.slides.remove_at(0)

    # Speichert die modifizierte Präsentation
    pres.save("modified_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Nicht verwendete Layoutfolie entfernen**

Aspose.Slides bietet die Methode `remove_unused_layout_slides(pres)` (aus der [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) Klasse), um unerwünschte und nicht verwendete Layoutfolien zu löschen. Dieser Python-Code zeigt Ihnen, wie Sie eine Layoutfolie aus einer PowerPoint-Präsentation entfernen:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slides.lowcode.Compress.remove_unused_layout_slides(pres)
    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

## **Nicht verwendete Masterfolie entfernen**

Aspose.Slides bietet die Methode `remove_unused_master_slides(pres)` (aus der [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) Klasse), um unerwünschte und nicht verwendete Masterfolien zu löschen. Dieser Python-Code zeigt Ihnen, wie Sie eine Masterfolie aus einer PowerPoint-Präsentation entfernen:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slides.lowcode.Compress.remove_unused_master_slides(pres)
    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```