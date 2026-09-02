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
description: "Klone oder dupliziere PowerPoint-Folien schnell mit Aspose.Slides für Python via .NET. Folge unseren klaren Code-Beispielen und Tipps, um die PPT-Erstellung in Sekunden zu automatisieren, die Produktivität zu steigern und manuelle Arbeit zu eliminieren."
---
## **Einführung**

Klonen ist der Vorgang, eine exakte Kopie oder Replik eines Objekts zu erstellen. Aspose.Slides ermöglicht es Ihnen ebenfalls, jede Folie zu kopieren (klonen) und die geklonte Folie anschließend in die aktuelle Präsentation oder in eine andere geöffnete Präsentation einzufügen. Das Klonen von Folien erzeugt eine neue Folie, die Entwickler ändern können, ohne die ursprüngliche Folie zu beeinflussen. Es gibt mehrere Möglichkeiten, eine Folie zu klonen:

- Klonen am Ende einer Präsentation.
- Klonen an einer anderen Position innerhalb einer Präsentation.
- Klonen am Ende einer anderen Präsentation.
- Klonen an einer anderen Position in einer anderen Präsentation.
- Klonen an einer bestimmten Position in einer anderen Präsentation.

In Aspose.Slides für Python via .NET stellt die [slide collection](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidecollection/) des [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Objekts die Methoden `add_clone` und `insert_clone` bereit, um diese Arten des Folienklonens auszuführen.

## **Installation**

```bash
pip install aspose.slides
```

## **Klonen am Ende innerhalb derselben Präsentation**

Wenn Sie eine Folie innerhalb derselben Präsentation klonen und an das Ende der vorhandenen Folien anhängen möchten, verwenden Sie die Methode `add_clone`. Führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/).
2. Rufen Sie die SlideCollection vom [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Objekt ab.
3. Rufen Sie die Methode `add_clone` auf der [SlideCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidecollection/) auf und übergeben Sie die zu klonende Folie.
4. Speichern Sie die geänderte Präsentation.

Im folgenden Beispiel wird die erste Folie (Index 0) geklont und an das Ende der Präsentation angehängt.

```py
import aspose.slides as slides

# Instanziieren Sie die Klasse Presentation, um die Präsentationsdatei darzustellen.
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # Klonen Sie die gewünschte Folie an das Ende der Folienkollektion in derselben Präsentation.
    presentation.slides.add_clone(presentation.slides[0])
    # Speichern Sie die geänderte Präsentation auf dem Datenträger.
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Klonen an einer bestimmten Position innerhalb derselben Präsentation**

Wenn Sie eine Folie innerhalb derselben Präsentation klonen und an einer anderen Position platzieren möchten, verwenden Sie die Methode `insert_clone`:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/).
2. Rufen Sie die SlideCollection vom [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Objekt ab.
3. Rufen Sie die Methode `insert_clone` auf der [SlideCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidecollection/) auf und übergeben Sie die zu klonende Folie sowie den Zielindex für ihre neue Position.
4. Speichern Sie die geänderte Präsentation.

Im folgenden Beispiel wird die Folie mit Index 1 (Position 2) auf Index 2 (Position 3) innerhalb derselben Präsentation geklont.

```py
import aspose.slides as slides

# Instanziieren Sie die Klasse Presentation, um die Präsentationsdatei darzustellen.
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # Klonen Sie die gewünschte Folie an die angegebene Position (Index) innerhalb derselben Präsentation.
    presentation.slides.insert_clone(2, presentation.slides[1])
    # Speichern Sie die geänderte Präsentation auf dem Datenträger.
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Klonen am Ende einer anderen Präsentation**

Wenn Sie eine Folie von einer Präsentation klonen und an das Ende einer anderen Präsentation anhängen müssen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/) für die Quellpräsentation (diejenige, die die zu klonende Folie enthält).
2. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/) für die Zielpräsentation (in die die Folie eingefügt wird).
3. Rufen Sie die SlideCollection der Zielpräsentation ab.
4. Rufen Sie `add_clone` auf der Ziel-[SlideCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidecollection/) auf und übergeben Sie die Folie aus der Quellpräsentation.
5. Speichern Sie die geänderte Zielpräsentation.

Im folgenden Beispiel wird die Folie mit Index 0 in der Quellpräsentation an das Ende der Zielpräsentation geklont.

```py
import aspose.slides as slides

# Instanziieren Sie die Klasse Presentation, um die Quellpräsentationsdatei darzustellen.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Instanziieren Sie die Klasse Presentation für die Ziel-PPTX (wo die Folie geklont wird).
    with slides.Presentation() as target_presentation:
        # Klonen Sie die gewünschte Folie aus der Quellpräsentation an das Ende der Folienkollektion in der Zielpräsentation.
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # Speichern Sie die Zielpräsentation auf dem Datenträger.
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Klonen an einer bestimmten Position in einer anderen Präsentation**

Wenn Sie eine Folie von einer Präsentation klonen und an einer bestimmten Position in einer anderen Präsentation einfügen müssen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/) für die Quellpräsentation (die die zu klonende Folie enthält).
2. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/) für die Zielpräsentation (in die die Folie eingefügt wird).
3. Rufen Sie die SlideCollection der Zielpräsentation ab.
4. Rufen Sie die Methode `insert_clone` auf der Ziel-[SlideCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidecollection/) auf und übergeben Sie die Folie aus der Quellpräsentation sowie den gewünschten Zielindex.
5. Speichern Sie die geänderte Zielpräsentation.

Im folgenden Beispiel wird die Folie mit Index 0 in der Quellpräsentation auf Index 2 (Position 3) in der Zielpräsentation geklont.

```py
import aspose.slides as slides

# Instanziieren Sie die Klasse Presentation, um die Quellpräsentationsdatei darzustellen.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Instanziieren Sie die Klasse Presentation für die Ziel-PPTX (wo die Folie geklont werden soll).
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # Fügen Sie einen Klon der ersten Folie aus der Quelle an Index 2 in der Zielpräsentation ein.
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # Speichern Sie die Zielpräsentation auf dem Datenträger.
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Klonen einer Folie mit ihrer Masterfolie in eine andere Präsentation**

Wenn Sie eine Folie **mit ihrem Master** von einer Präsentation klonen und in einer anderen verwenden müssen, klonen Sie zunächst die benötigte Masterfolie von der Quellpräsentation in die Zielpräsentation. Verwenden Sie dann diesen Ziel‑Master beim Klonen der Folie. Die Methode `add_clone(Slide, MasterSlide)` erwartet eine **Masterfolie aus der Zielpräsentation**, nicht aus der Quelle.

Um eine Folie mit ihrem Master zu klonen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/) für die Quellpräsentation (die die zu klonende Folie enthält).
2. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/) für die Zielpräsentation.
3. Greifen Sie auf die zu klonende Quellfolie und deren Masterfolie zu.
4. Rufen Sie die [MasterSlideCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/masterslidecollection/) aus der Master‑Sammlung der Zielpräsentation ab.
5. Rufen Sie `add_clone` auf der Ziel-[MasterSlideCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/masterslidecollection/) auf und übergeben Sie den Quell‑Master, um ihn in das Ziel zu klonen.
6. Rufen Sie die [SlideCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidecollection/) aus der Folien‑Sammlung der Zielpräsentation ab.
7. Rufen Sie `add_clone` auf der Ziel-[SlideCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidecollection/) auf und übergeben Sie die Quellfolie sowie den geklonten Ziel‑Master.
8. Speichern Sie die geänderte Zielpräsentation.

Im folgenden Beispiel wird die Folie mit Index 0 in der Quellpräsentation an das Ende der Zielpräsentation geklont, wobei der aus der Quelle geklonte Master verwendet wird.

```py
import aspose.slides as slides

# Instanziieren Sie die Presentation‑Klasse, um die Quellpräsentationsdatei darzustellen.
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # Instanziieren Sie die Presentation‑Klasse für die Zielpräsentation, in die die Folie geklont wird.
    with slides.Presentation() as target_presentation:
        # Holen Sie die erste Folie aus der Quellpräsentation.
        source_slide = source_presentation.slides[0]
        # Holen Sie die Masterfolie, die von der ersten Folie verwendet wird.
        source_master = source_slide.layout_slide.master_slide
        # Klonen Sie die Masterfolie in die Master‑Sammlung der Zielpräsentation.
        cloned_master = target_presentation.masters.add_clone(source_master)
        # Klonen Sie die Folie aus der Quellpräsentation an das Ende der Zielpräsentation unter Verwendung des geklonten Masters.
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # Speichern Sie die Zielpräsentation auf dem Datenträger.
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Klonen am Ende in einem angegebenen Abschnitt**

Mit Aspose.Slides für Python via .NET können Sie eine Folie aus einem Abschnitt einer Präsentation klonen und in einen anderen Abschnitt derselben Präsentation einfügen. Verwenden Sie dafür die Methode `add_clone(Slide, Section)` der Klasse [SlideCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidecollection/).

Das folgende Python‑Beispiel zeigt, wie man eine Folie klont und den Klon in einen angegebenen Abschnitt einfügt:

```py
import aspose.slides as slides

# Erstellen Sie eine neue leere Präsentation.
with slides.Presentation() as presentation:
    # Fügen Sie eine leere Folie basierend auf dem Layout der ersten Folie hinzu.
    slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Fügen Sie der neuen Folie eine Ellipse‑Form hinzu; diese Folie wird später geklont.
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100)
    # Fügen Sie eine weitere leere Folie basierend auf dem Layout der ersten Folie hinzu.
    slide2 = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Erstellen Sie einen Abschnitt mit dem Namen "Section2", der bei slide2 beginnt.
    section = presentation.sections.add_section("Section2", slide2)
    # Klonen Sie die zuvor erstellte Folie in den Abschnitt "Section2".
    presentation.slides.add_clone(slide, section)
    # Speichern Sie die Präsentation als PPTX‑Datei.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

### Werden Rednernotizen und Prüferkommentare geklont?

Ja. Die Notizenseite und Überprüfungskommentare werden in den Klon übernommen. Wenn Sie sie nicht wünschen, [entfernen Sie sie](/slides/de/python-net/presentation-notes/) nach dem Einfügen.

### Wie werden Diagramme und deren Datenquellen behandelt?

Das Diagrammobjekt, die Formatierung und eingebetteten Daten werden kopiert. Wenn das Diagramm mit einer externen Quelle verknüpft war (z. B. einer OLE‑eingebetteten Arbeitsmappe), bleibt diese Verknüpfung als ein [OLE object](/slides/de/python-net/manage-ole/) erhalten. Nach dem Verschieben zwischen Dateien sollten Sie die Datenverfügbarkeit und das Aktualisierungsverhalten überprüfen.

### Kann ich die Einfügeposition und Abschnitte für den Klon steuern?

Ja. Sie können den Klon an einem bestimmten Folien‑Index einfügen und ihn in einen gewählten [section](/slides/de/python-net/slide-section/) platzieren. Wenn der Zielabschnitt nicht existiert, erstellen Sie ihn zuerst und verschieben Sie dann die Folie hinein.