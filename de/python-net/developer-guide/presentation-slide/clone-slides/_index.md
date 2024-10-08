---
title: Folien klonen
type: docs
weight: 40
url: /de/python-net/clone-slides/
keywords: "Folie klonen, Folie kopieren, Folienkopie speichern, PowerPoint, Präsentation, Python, Aspose.Slides"
description: "PowerPoint-Folie in Python klonen"
---

## **Folien in der Präsentation klonen**
Klonen ist der Prozess, eine exakte Kopie oder Replik von etwas zu erstellen. Aspose.Slides für Python über .NET ermöglicht es ebenfalls, eine Kopie oder einen Klon einer beliebigen Folie zu erstellen und diesen geklonten Folie dann in die aktuelle oder eine andere geöffnete Präsentation einzufügen. Der Prozess des Folienklonens erstellt eine neue Folie, die von Entwicklern verändert werden kann, ohne die ursprüngliche Folie zu verändern. Es gibt mehrere mögliche Wege, eine Folie zu klonen:

- Folie am Ende innerhalb einer Präsentation klonen.
- Folie an einer anderen Position innerhalb der Präsentation klonen.
- Folie am Ende in einer anderen Präsentation klonen.
- Folie an einer anderen Position in einer anderen Präsentation klonen.
- Folie an einer bestimmten Position in einer anderen Präsentation klonen.

In Aspose.Slides für Python über .NET stellt eine Sammlung von [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) Objekten, die vom [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Objekt bereitgestellt werden, die Methoden [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) und [insert_clone](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) zur Verfügung, um die obigen Arten des Folienklonens durchzuführen.

## **Folie am Ende innerhalb einer Präsentation klonen**
Wenn Sie eine Folie klonen und dann innerhalb derselben Präsentationsdatei am Ende der bestehenden Folien verwenden möchten, verwenden Sie die Methode [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) gemäß den unten aufgeführten Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Instanziieren Sie die [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) Klasse, indem Sie sich auf die von dem [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Objekt bereitgestellte Folienkollektion beziehen.
2. Rufen Sie die vom [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) Objekt bereitgestellte [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) Methode auf und übergeben Sie die zu klonende Folie als Parameter an die [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) Methode.
3. Schreiben Sie die modifizierte Präsentationsdatei.

Im folgenden Beispiel haben wir eine Folie (die sich an der ersten Position – Nullindex – der Präsentation befindet) an das Ende der Präsentation geklont.

```py
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei repräsentiert
with slides.Presentation(path + "CloneWithinSamePresentationToEnd.pptx") as pres:
    # Klonen Sie die gewünschte Folie an das Ende der Sammlung von Folien in derselben Präsentation
    slds = pres.slides

    slds.add_clone(pres.slides[0])

    # Schreiben Sie die modifizierte Präsentation auf die Festplatte
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Folie an einer anderen Position innerhalb der Präsentation klonen**
Wenn Sie eine Folie klonen und dann innerhalb derselben Präsentationsdatei, aber an einer anderen Position verwenden möchten, verwenden Sie die Methode [insert_clone](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/):

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Instanziieren Sie die Klasse, indem Sie sich auf die von dem [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Objekt bereitgestellte **Slides**-Kollektion beziehen.
1. Rufen Sie die vom [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) Objekt bereitgestellte [insert_clone](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) Methode auf und übergeben Sie die zu klonende Folie zusammen mit dem Index für die neue Position als Parameter an die [insert_clone](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) Methode.
1. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Im folgenden Beispiel haben wir eine Folie (die sich an dem Nullindex – Position 1 – der Präsentation befindet) nach Index 1 – Position 2 – der Präsentation geklont.

```py
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei repräsentiert
with slides.Presentation(path + "CloneWithInSamePresentation.pptx") as pres:
    # Klonen Sie die gewünschte Folie an das Ende der Sammlung von Folien in derselben Präsentation
    slds = pres.slides

    # Klonen Sie die gewünschte Folie an den angegebenen Index in derselben Präsentation
    slds.insert_clone(2, pres.slides[1])

    # Schreiben Sie die modifizierte Präsentation auf die Festplatte
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Folie am Ende in einer anderen Präsentation klonen**
Wenn Sie eine Folie aus einer Präsentation klonen und in einer anderen Präsentationsdatei am Ende der bestehenden Folien verwenden müssen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse, die die Präsentation enthält, aus der die Folie geklont wird.
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse, die die Zielpräsentation enthält, zu der die Folie hinzugefügt werden soll.
1. Instanziieren Sie die [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) Klasse, indem Sie sich auf die von dem Zielpräsentationsobjekt bereitgestellte **Slides**-Kollektion beziehen.
1. Rufen Sie die vom [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) Objekt bereitgestellte [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) Methode auf und übergeben Sie die Folie aus der Quellpräsentation als Parameter an die [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) Methode.
1. Schreiben Sie die modifizierte Zielpräsentationsdatei.

Im folgenden Beispiel haben wir eine Folie (von dem ersten Index der Quellpräsentation) an das Ende der Zielpräsentation geklont.

```py
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, um die Quellpräsentationsdatei zu laden
with slides.Presentation(path + "CloneAtEndOfAnother.pptx") as srcPres:
    # Instanziieren Sie die Presentation-Klasse für die Ziel-PPTX (wo die Folie geklont werden soll)
    with slides.Presentation() as destPres:
        # Klonen Sie die gewünschte Folie aus der Quellpräsentation an das Ende der Sammlung von Folien in der Zielpräsentation
        slds = destPres.slides
        slds.add_clone(srcPres.slides[0])

        # Schreiben Sie die Zielpräsentation auf die Festplatte
        destPres.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Folie an einer anderen Position in einer anderen Präsentation klonen**
Wenn Sie eine Folie aus einer Präsentation klonen und in einer anderen Präsentationsdatei an einer bestimmten Position verwenden müssen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse, die die Quellpräsentation enthält, aus der die Folie geklont wird.
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse, die die Präsentation enthält, zu der die Folie hinzugefügt wird.
1. Instanziieren Sie die [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) Klasse, indem Sie sich auf die von dem Zielpräsentationsobjekt bereitgestellte Folienkollektion beziehen.
1. Rufen Sie die vom [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) Objekt bereitgestellte [insert_clone](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) Methode auf und übergeben Sie die Folie aus der Quellpräsentation zusammen mit der gewünschten Position als Parameter an die [insert_clone](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) Methode.
1. Schreiben Sie die modifizierte Zielpräsentationsdatei.

Im folgenden Beispiel haben wir eine Folie (von dem Nullindex der Quellpräsentation) an Index 1 (Position 2) der Zielpräsentation geklont.

```py
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, um die Quellpräsentationsdatei zu laden
with slides.Presentation(path + "CloneAtEndOfAnother.pptx") as srcPres:
    # Instanziieren Sie die Presentation-Klasse für die Ziel-PPTX (wo die Folie geklont werden soll)
    with slides.Presentation("Aspose2_out.pptx") as destPres:
        slds = destPres.slides
        slds.insert_clone(2, srcPres.slides[0])

        # Schreiben Sie die Zielpräsentation auf die Festplatte
        destPres.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Folie an einer bestimmten Position in einer anderen Präsentation klonen**
Wenn Sie eine Folie mit einem Master aus einer Präsentation klonen und in einer anderen Präsentation verwenden müssen, müssen Sie zuerst den gewünschten Master aus der Quellpräsentation in die Zielpräsentation klonen. Dann müssen Sie diesen Master verwenden, um die Folie mit Master zu klonen. Die **add_clone(ISlide, IMasterSlide)** erwartet einen Master aus der Zielpräsentation anstelle von der Quellpräsentation. Um die Folie mit einem Master zu klonen, folgen Sie bitte den folgenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse, die die Quellpräsentation enthält, aus der die Folie geklont wird.
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse, die die Zielpräsentation enthält, zu der die Folie geklont wird.
1. Greifen Sie auf die Folie zu, die geklont werden soll, zusammen mit dem Master.
1. Instanziieren Sie die [IMasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/) Klasse, indem Sie sich auf die von dem Zielpräsentationsobjekt bereitgestellte Masters-Kollektion beziehen.
1. Rufen Sie die vom [IMasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/) Objekt bereitgestellte [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) Methode auf und übergeben Sie den Master aus der Quell-PPTX, der geklont werden soll, als Parameter an die [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) Methode.
1. Instanziieren Sie die [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) Klasse, indem Sie den Bezug auf die von dem Zielpräsentationsobjekt bereitgestellte Folienkollektion einrichten.
2. Rufen Sie die vom [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) Objekt bereitgestellte [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) Methode auf und übergeben Sie die Folie aus der Quellpräsentation, die geklont werden soll, und den Master Slide als Parameter an die [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) Methode.
3. Schreiben Sie die modifizierte Zielpräsentationsdatei.

Im folgenden Beispiel haben wir eine Folie mit Master (die sich am Nullindex der Quellpräsentation befindet) an das Ende der Zielpräsentation geklont, wobei ein Master aus der Quellfolie verwendet wird.

```py
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, um die Quellpräsentationsdatei zu laden
with slides.Presentation(path + "CloneToAnotherPresentationWithMaster.pptx") as srcPres:
    # Instanziieren Sie die Presentation-Klasse für die Zielpräsentation (wo die Folie geklont werden soll)
    with slides.Presentation() as destPres:
        # Instanziieren Sie ISlide aus der Sammlung von Folien in der Quellpräsentation zusammen mit
        # Masterfolie
        sourceSlide = srcPres.slides[0]
        sourceMaster = sourceSlide.layout_slide.master_slide

        # Klonen Sie die gewünschte Masterfolie aus der Quellpräsentation in die Sammlung von Masterfolien in der
        # Zielpräsentation
        masters = destPres.masters
        destMaster = sourceSlide.layout_slide.master_slide

        # Klonen Sie die gewünschte Masterfolie aus der Quellpräsentation in die Sammlung von Masterfolien in der
        # Zielpräsentation
        iSlide = masters.add_clone(sourceMaster)

        # Klonen Sie die gewünschte Folie aus der Quellpräsentation mit dem gewünschten Master an das Ende der
        # Sammlung von Folien in der Zielpräsentation
        slds = destPres.slides
        slds.add_clone(sourceSlide, iSlide, True)

        # Klonen Sie die gewünschte Masterfolie aus der Quellpräsentation in die Sammlung von Masterfolien in der
        # Zielpräsentation, speichern Sie die Zielpräsentation auf die Festplatte
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## Folie am Ende in einem bestimmten Abschnitt klonen

Mit Aspose.Slides für Python über .NET können Sie eine Folie aus einem Abschnitt einer Präsentation klonen und diese Folie in einen anderen Abschnitt derselben Präsentation einfügen. In diesem Fall müssen Sie die [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) Methode aus dem [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) Interface verwenden.

Dieser Python-Code zeigt Ihnen, wie man eine Folie klont und die geklonte Folie in einen bestimmten Abschnitt einfügt:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100) # zu klonende Folie

    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    section = pres.sections.add_section("Section2", slide2)

    pres.slides.add_clone(slide, section)

    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```