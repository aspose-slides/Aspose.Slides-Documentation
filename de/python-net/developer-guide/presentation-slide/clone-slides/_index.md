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
description: "PowerPoint-Folien schnell klonen oder duplizieren mit Aspose.Slides für Python via .NET. Folgen Sie unseren klaren Code-Beispielen und Tipps, um die PPT-Erstellung in Sekunden zu automatisieren, die Produktivität zu steigern und manuelle Arbeit zu eliminieren."
---

## **Übersicht**

Cloning ist der Vorgang, bei dem eine exakte Kopie oder Replik eines Objekts erstellt wird. Aspose.Slides für Python via .NET ermöglicht das Klonen einer beliebigen Folie und das Einfügen dieser Kopie in die aktuelle Präsentation oder in eine andere geöffnete Präsentation. Der Klonvorgang erzeugt eine neue Folie, die Sie ändern können, ohne das Original zu beeinflussen.

Es gibt mehrere Möglichkeiten, eine Folie zu klonen:

- Klonen einer Folie am Ende innerhalb derselben Präsentation.
- Klonen einer Folie an einer bestimmten Position innerhalb derselben Präsentation.
- Klonen einer Folie am Ende einer anderen Präsentation.
- Klonen einer Folie an einer bestimmten Position in einer anderen Präsentation.
- Klonen einer Folie mit ihrer Masterfolie in eine andere Präsentation.

In Aspose.Slides für Python via .NET stellt die [Folien-Sammlung](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) des [Präsentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Objekts die Methoden `add_clone` und `insert_clone` bereit, um diese Arten von Folienklonen durchzuführen.

## **Klonen am Ende innerhalb derselben Präsentation**

Wenn Sie eine Folie innerhalb derselben Präsentation klonen und an das Ende der vorhandenen Folien anhängen möchten, verwenden Sie die Methode `add_clone`. Führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der [Präsentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.
1. Holen Sie die Folien-Sammlung vom [Präsentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Objekt.
1. Rufen Sie die Methode `add_clone` auf der [Folien-Sammlung](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) auf und übergeben Sie die zu klonende Folie.
1. Speichern Sie die geänderte Präsentation.

Im folgenden Beispiel wird die erste Folie (Index 0) geklont und an das Ende der Präsentation angehängt.
```py
import aspose.slides as slides

# Erstellen Sie eine Instanz der Presentation-Klasse, um die Präsentationsdatei zu repräsentieren.
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # Klonen Sie die gewünschte Folie an das Ende der Folien-Sammlung in derselben Präsentation.
    presentation.slides.add_clone(presentation.slides[0])
    # Speichern Sie die geänderte Präsentation auf dem Datenträger.
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Klonen an einer bestimmten Position innerhalb derselben Präsentation**

Wenn Sie eine Folie innerhalb derselben Präsentation klonen und an einer anderen Position platzieren möchten, verwenden Sie die Methode `insert_clone`:

1. Erstellen Sie eine Instanz der [Präsentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.
1. Holen Sie die Folien-Sammlung vom [Präsentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Objekt.
1. Rufen Sie die Methode `insert_clone` auf der [Folien-Sammlung](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) auf und übergeben Sie die zu klonende Folie sowie den Ziel‑Index für die neue Position.
1. Speichern Sie die geänderte Präsentation.

Im folgenden Beispiel wird die Folie mit Index 0 (Position 1) auf Index 1 (Position 2) innerhalb derselben Präsentation geklont.
```py
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, um die Präsentationsdatei darzustellen.
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # Klonen Sie die gewünschte Folie an die angegebene Position (Index) innerhalb derselben Präsentation.
    presentation.slides.insert_clone(2, presentation.slides[1])
    # Speichern Sie die geänderte Präsentation auf dem Datenträger.
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Klonen am Ende einer anderen Präsentation**

Wenn Sie eine Folie aus einer Präsentation klonen und an das Ende einer anderen Präsentation anhängen müssen:

1. Erstellen Sie eine Instanz der [Präsentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse für die Quellpräsentation (die Folie enthält, die geklont werden soll).
1. Erstellen Sie eine Instanz der [Präsentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse für die Zielpräsentation (wo die Folie hinzugefügt wird).
1. Holen Sie die Folien-Sammlung der Zielpräsentation.
1. Rufen Sie `add_clone` auf der Ziel‑[Folien-Sammlung](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) auf und übergeben Sie die Folie aus der Quellpräsentation.
1. Speichern Sie die geänderte Zielpräsentation.

Im folgenden Beispiel wird die Folie mit Index 0 in der Quellpräsentation am Ende der Zielpräsentation geklont.
```py
import aspose.slides as slides

# Instanziieren Sie die Presentation‑Klasse, um die Quelldatei der Präsentation darzustellen.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Instanziieren Sie die Presentation‑Klasse für die Ziel‑PPTX (wo die Folie geklont wird).
    with slides.Presentation() as target_presentation:
        # Klonen Sie die gewünschte Folie aus der Quellpräsentation an das Ende der Folien‑Sammlung in der Zielpräsentation.
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # Speichern Sie die Zielpräsentation auf dem Datenträger.
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Klonen an einer bestimmten Position in einer anderen Präsentation**

Wenn Sie eine Folie aus einer Präsentation klonen und an einer bestimmten Position in einer anderen Präsentation einfügen müssen:

1. Erstellen Sie eine Instanz der [Präsentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse für die Quellpräsentation (die Folie enthält, die geklont werden soll).
1. Erstellen Sie eine Instanz der [Präsentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse für die Zielpräsentation (wo die Folie hinzugefügt wird).
1. Holen Sie die Folien-Sammlung der Zielpräsentation.
1. Rufen Sie die Methode `insert_clone` auf der Ziel‑[Folien-Sammlung](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) auf und übergeben Sie die Folie aus der Quellpräsentation sowie den gewünschten Ziel‑Index.
1. Speichern Sie die geänderte Zielpräsentation.

Im folgenden Beispiel wird die Folie mit Index 0 in der Quellpräsentation auf Index 1 (Position 2) in der Zielpräsentation geklont.
```py
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, um die Quelldatei der Präsentation darzustellen.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Instanziieren Sie die Presentation-Klasse für die Ziel-PPTX (wo die Folie geklont werden soll).
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # Fügen Sie einen Klon der ersten Folie aus der Quelle an Index 2 in der Zielpräsentation ein.
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # Speichern Sie die Zielpräsentation auf dem Datenträger.
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Klonen einer Folie mit ihrer Masterfolie in eine andere Präsentation**

Wenn Sie eine Folie **mit ihrer Masterfolie** aus einer Präsentation klonen und in einer anderen verwenden möchten, klonen Sie zunächst die erforderliche Masterfolie aus der Quellpräsentation in die Zielpräsentation. Verwenden Sie dann diesen Ziel‑Master beim Klonen der Folie. Die Methode `add_clone(Slide, MasterSlide)` erwartet eine **Masterfolie der Zielpräsentation**, nicht der Quelle.

So klonen Sie eine Folie mit ihrer Masterfolie:

1. Erstellen Sie eine Instanz der [Präsentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse für die Quellpräsentation (die Folie enthält, die geklont werden soll).
1. Erstellen Sie eine Instanz der [Präsentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse für die Zielpräsentation.
1. Greifen Sie auf die zu klonende Quellfolie und deren Masterfolie zu.
1. Holen Sie die [MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/) aus der Master‑Sammlung der Zielpräsentation.
1. Rufen Sie `add_clone` auf der Ziel‑[MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/) auf und übergeben Sie die Quell‑Masterfolie, um sie in das Ziel zu klonen.
1. Holen Sie die [Folien-Sammlung](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) aus der Folien‑Sammlung der Zielpräsentation.
1. Rufen Sie `add_clone` auf der Ziel‑[Folien-Sammlung](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) auf und übergeben Sie die Quellfolie sowie den geklonten Ziel‑Master.
1. Speichern Sie die geänderte Zielpräsentation.

Im folgenden Beispiel wird die Folie mit Index 0 in der Quellpräsentation am Ende der Zielpräsentation geklont, wobei der Master aus der Quelle geklont wurde.
```py
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, um die Quelldatei der Präsentation darzustellen.
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # Instanziieren Sie die Presentation-Klasse für die Zielpräsentation, in die die Folie geklont wird.
    with slides.Presentation() as target_presentation:
        # Holen Sie die erste Folie aus der Quellpräsentation.
        source_slide = source_presentation.slides[0]
        # Holen Sie die Masterfolie, die von der ersten Folie verwendet wird.
        source_master = source_slide.layout_slide.master_slide
        # Klonen Sie die Masterfolie in die Master‑Sammlung der Zielpräsentation.
        cloned_master = target_presentation.masters.add_clone(source_master)
        # Klonen Sie die Folie aus der Quellpräsentation an das Ende der Zielpräsentation unter Verwendung der geklonten Masterfolie.
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # Speichern Sie die Zielpräsentation auf dem Datenträger.
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Klonen am Ende in einem angegebenen Abschnitt**

Mit Aspose.Slides für Python via .NET können Sie eine Folie aus einem Abschnitt einer Präsentation klonen und in einen anderen Abschnitt derselben Präsentation einfügen. Verwenden Sie hierfür die Methode `add_clone(Slide, Section)` des [Folien-Sammlung](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/)-Interfaces.

Das folgende Python‑Beispiel zeigt, wie eine Folie geklont und der Clone in einen angegebenen Abschnitt eingefügt wird:
```py
import aspose.slides as slides

# Erstelle eine neue leere Präsentation.
with slides.Presentation() as presentation:
    # Füge eine leere Folie basierend auf dem Layout der ersten Folie hinzu.
    slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Füge der neuen Folie eine Ellipse-Form hinzu; diese Folie wird später geklont.
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100)
    # Füge eine weitere leere Folie basierend auf dem Layout der ersten Folie hinzu.
    slide2 = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Erstelle einen Abschnitt mit dem Namen "Section2", der bei slide2 beginnt.
    section = presentation.sections.add_section("Section2", slide2)
    # Klone die zuvor erstellte Folie in den Abschnitt "Section2".
    presentation.slides.add_clone(slide, section)
    # Speichere die Präsentation als PPTX-Datei.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Werden Sprecher‑Notizen und Reviewer‑Kommentare geklont?**

Ja. Die Notizenseite und die Review‑Kommentare werden in den Clone übernommen. Wenn Sie sie nicht benötigen, [entfernen Sie sie](/slides/de/python-net/presentation-notes/) nach dem Einfügen.

**Wie werden Diagramme und ihre Datenquellen behandelt?**

Das Diagrammobjekt, die Formatierung und die eingebetteten Daten werden kopiert. Wenn das Diagramm mit einer externen Quelle (z. B. einer OLE‑eingebetteten Arbeitsmappe) verknüpft war, bleibt diese Verknüpfung als [OLE‑Objekt](/slides/de/python-net/manage-ole/) erhalten. Nach dem Verschieben zwischen Dateien sollten Sie die Datenverfügbarkeit und das Aktualisierungsverhalten prüfen.

**Kann ich die Einfügeposition und die Abschnitte für den Clone steuern?**

Ja. Sie können den Clone an einem bestimmten Folien‑Index einfügen und ihn in einen ausgewählten [Abschnitt](/slides/de/python-net/slide-section/) verschieben. Wenn der Ziel‑Abschnitt nicht existiert, erstellen Sie ihn zuerst und verschieben dann die Folie hinein.