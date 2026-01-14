---
title: PowerPoint-Folien in Python klonen
linktitle: Folien klonen
type: docs
weight: 40
url: /de/python-net/clone-slides/
keywords:
- Folie klonen
- Folie kopieren
- Folie speichern
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Klone oder dupliziere PowerPoint-Folien schnell mit Aspose.Slides für Python via .NET. Befolge unsere klaren Code-Beispiele und Tipps, um die Erstellung von PPTs in Sekunden zu automatisieren, die Produktivität zu steigern und manuelle Arbeit zu eliminieren."
---

## **Übersicht**

Klonen ist der Vorgang, eine exakte Kopie oder Replik eines Objekts zu erstellen. Aspose.Slides for Python via .NET ermöglicht das Klonen beliebiger Folien und das Einfügen dieser Kopie in die aktuelle Präsentation oder eine andere geöffnete Präsentation. Der Klonvorgang erzeugt eine neue Folie, die Sie ändern können, ohne das Original zu beeinflussen.

- Eine Folie am Ende innerhalb derselben Präsentation klonen.
- Eine Folie an einer bestimmten Position innerhalb derselben Präsentation klonen.
- Eine Folie am Ende einer anderen Präsentation klonen.
- Eine Folie an einer bestimmten Position in einer anderen Präsentation klonen.
- Eine Folie mit ihrer Masterfolie in eine andere Präsentation klonen.

In Aspose.Slides for Python via .NET stellt die [slide collection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) des [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Objekts die Methoden `add_clone` und `insert_clone` zur Verfügung, um diese Arten des Folienklonens durchzuführen.

## **Klonen am Ende innerhalb derselben Präsentation**

Wenn Sie eine Folie innerhalb derselben Präsentation klonen und an das Ende der vorhandenen Folien anhängen möchten, verwenden Sie die Methode `add_clone`. Führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Rufen Sie die Foliensammlung des [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Objekts ab.
1. Rufen Sie die Methode `add_clone` auf der [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/), wobei Sie die zu klonende Folie übergeben.
1. Speichern Sie die geänderte Präsentation.

Im folgenden Beispiel wird die erste Folie (Index 0) geklont und an das Ende der Präsentation angehängt.
```py
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, um die Präsentationsdatei darzustellen.
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # Klonen Sie die gewünschte Folie an das Ende der Foliensammlung in derselben Präsentation.
    presentation.slides.add_clone(presentation.slides[0])
    # Speichern Sie die modifizierte Präsentation auf der Festplatte.
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Klonen an einer bestimmten Position innerhalb derselben Präsentation**

Wenn Sie eine Folie innerhalb derselben Präsentation klonen und an einer anderen Position platzieren möchten, verwenden Sie die Methode `insert_clone`:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Rufen Sie die Foliensammlung des [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Objekts ab.
1. Rufen Sie die Methode `insert_clone` auf der [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/), wobei Sie die zu klonende Folie und den Zielindex für ihre neue Position übergeben.
1. Speichern Sie die geänderte Präsentation.

Im folgenden Beispiel wird die Folie mit Index 0 (Position 1) zu Index 1 (Position 2) innerhalb derselben Präsentation geklont.
```py
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, um die Präsentationsdatei darzustellen.
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # Klonen Sie die gewünschte Folie an die angegebene Position (Index) innerhalb derselben Präsentation.
    presentation.slides.insert_clone(2, presentation.slides[1])
    # Speichern Sie die modifizierte Präsentation auf der Festplatte.
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Klonen am Ende einer anderen Präsentation**

Wenn Sie eine Folie aus einer Präsentation klonen und an das Ende einer anderen Präsentation anhängen müssen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) für die Quellpräsentation (diejenige, die die zu klonende Folie enthält).
1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) für die Zielpräsentation (in die die Folie eingefügt wird).
1. Rufen Sie die Foliensammlung der Zielpräsentation ab.
1. Rufen Sie `add_clone` auf der Ziel-[SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/), wobei Sie die Folie aus der Quellpräsentation übergeben.
1. Speichern Sie die geänderte Zielpräsentation.

Im folgenden Beispiel wird die Folie mit Index 0 der Quellpräsentation an das Ende der Zielpräsentation geklont.
```py
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, um die Quelldatei der Präsentation darzustellen.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Instanziieren Sie die Presentation-Klasse für die Ziel-PPTX (wo die Folie geklont wird).
    with slides.Presentation() as target_presentation:
        # Klonen Sie die gewünschte Folie aus der Quellpräsentation an das Ende der Foliensammlung in der Zielpräsentation.
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # Speichern Sie die Zielpräsentation auf der Festplatte.
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Klonen an einer bestimmten Position in einer anderen Präsentation**

Wenn Sie eine Folie aus einer Präsentation klonen und in einer anderen Präsentation an einer bestimmten Position einfügen müssen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) für die Quellpräsentation (diejenige, die die zu klonende Folie enthält).
1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) für die Zielpräsentation (in die die Folie eingefügt wird).
1. Rufen Sie die Foliensammlung der Zielpräsentation ab.
1. Rufen Sie die Methode `insert_clone` auf der Ziel-[SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/), wobei Sie die Folie aus der Quellpräsentation und den gewünschten Zielindex übergeben.
1. Speichern Sie die geänderte Zielpräsentation.

Im folgenden Beispiel wird die Folie mit Index 0 der Quellpräsentation zu Index 1 (Position 2) in der Zielpräsentation geklont.
```py
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, um die Quellpräsentationsdatei darzustellen.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Instanziieren Sie die Presentation-Klasse für die Ziel-PPTX (wo die Folie geklont werden soll).
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # Fügen Sie einen Klon der ersten Folie aus der Quelle an Index 2 in der Zielpräsentation ein.
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # Speichern Sie die Zielpräsentation auf der Festplatte.
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Klonen einer Folie mit ihrer Masterfolie in eine andere Präsentation**

Wenn Sie eine Folie **mit ihrer Masterfolie** aus einer Präsentation klonen und in einer anderen verwenden müssen, klonen Sie zunächst die benötigte Masterfolie aus der Quellpräsentation in die Zielpräsentation. Verwenden Sie dann diese Ziel‑Masterfolie beim Klonen der Folie. Die Methode `add_clone(Slide, MasterSlide)` erwartet eine **Masterfolie aus der Zielpräsentation**, nicht aus der Quelle.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) für die Quellpräsentation (diejenige, die die zu klonende Folie enthält).
1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) für die Zielpräsentation.
1. Greifen Sie auf die zu klonende Quellfolie und deren Masterfolie zu.
1. Rufen Sie die [MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/) aus der Mastersammlung der Zielpräsentation ab.
1. Rufen Sie `add_clone` auf der Ziel-[MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/), wobei Sie den Quell‑Master übergeben, um ihn in die Zielpräsentation zu klonen.
1. Rufen Sie die [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) aus der Foliensammlung der Zielpräsentation ab.
1. Rufen Sie `add_clone` auf der Ziel-[SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/), wobei Sie die Quellfolie und die geklonte Ziel‑Masterfolie übergeben.
1. Speichern Sie die geänderte Zielpräsentation.

Im folgenden Beispiel wird die Folie mit Index 0 der Quellpräsentation an das Ende der Zielpräsentation geklont, wobei die aus der Quelle geklonte Masterfolie verwendet wird.
```py
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, um die Quellpräsentationsdatei darzustellen.
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # Instanziieren Sie die Presentation-Klasse für die Zielpräsentation, in der die Folie geklont wird.
    with slides.Presentation() as target_presentation:
        # Holen Sie die erste Folie aus der Quellpräsentation.
        source_slide = source_presentation.slides[0]
        # Holen Sie die Masterfolie, die von der ersten Folie verwendet wird.
        source_master = source_slide.layout_slide.master_slide
        # Klonen Sie die Masterfolie in die Master-Sammlung der Zielpräsentation.
        cloned_master = target_presentation.masters.add_clone(source_master)
        # Klonen Sie die Folie aus der Quellpräsentation an das Ende der Zielpräsentation unter Verwendung der geklonten Masterfolie.
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # Speichern Sie die Zielpräsentation auf der Festplatte.
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Klonen am Ende in einem angegebenen Abschnitt**

Mit Aspose.Slides for Python via .NET können Sie eine Folie aus einem Abschnitt einer Präsentation klonen und in einen anderen Abschnitt derselben Präsentation einfügen. Verwenden Sie hierfür die Methode `add_clone(Slide, Section)` der Klasse [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/).

Das folgende Python‑Beispiel zeigt, wie man eine Folie klont und den Klon in einen angegebenen Abschnitt einfügt:
```py
import aspose.slides as slides

# Erstellen Sie eine neue leere Präsentation.
with slides.Presentation() as presentation:
    # Fügen Sie eine leere Folie basierend auf dem Layout der ersten Folie hinzu.
    slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Fügen Sie der neuen Folie eine Ellipse-Form hinzu; diese Folie wird später geklont.
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100)
    # Fügen Sie eine weitere leere Folie basierend auf dem Layout der ersten Folie hinzu.
    slide2 = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Erstellen Sie einen Abschnitt mit dem Namen "Section2", der bei slide2 beginnt.
    section = presentation.sections.add_section("Section2", slide2)
    # Klonen Sie die zuvor erstellte Folie in den Abschnitt "Section2".
    presentation.slides.add_clone(slide, section)
    # Speichern Sie die Präsentation als PPTX-Datei.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Werden Sprechernotizen und Prüferkommentare geklont?**

Ja. Die Notizenseite und die Prüferkommentare werden in den Klon übernommen. Wenn Sie sie nicht benötigen, [entfernen Sie sie](/slides/de/python-net/presentation-notes/) nach dem Einfügen.

**Wie werden Diagramme und ihre Datenquellen behandelt?**

Das Diagrammobjekt, die Formatierung und die eingebetteten Daten werden kopiert. Wenn das Diagramm mit einer externen Quelle verknüpft war (z. B. einer OLE‑eingebetteten Arbeitsmappe), bleibt diese Verknüpfung als [OLE‑Objekt](/slides/de/python-net/manage-ole/) erhalten. Nach dem Verschieben zwischen Dateien sollten Sie die Datenverfügbarkeit und das Aktualisierungsverhalten überprüfen.

**Kann ich die Einfügeposition und die Abschnitte für den Klon steuern?**

Ja. Sie können den Klon an einem bestimmten Folien‑Index einfügen und ihn in einen ausgewählten [Abschnitt](/slides/de/python-net/slide-section/) verschieben. Wenn der Ziel‑Abschnitt nicht existiert, erstellen Sie ihn zuerst und verschieben dann die Folie dorthin.