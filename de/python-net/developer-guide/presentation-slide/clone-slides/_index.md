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
description: "Klonen oder duplizieren Sie PowerPoint-Folien schnell mit Aspose.Slides für Python via .NET. Folgen Sie unseren klaren Codebeispielen und Tipps, um PPT-Erstellung in Sekunden zu automatisieren, die Produktivität zu steigern und manuelle Arbeit zu vermeiden."
---
## **Einleitung**

Klonen ist der Vorgang, bei dem eine exakte Kopie oder ein Duplikat von etwas erstellt wird. Aspose.Slides ermöglicht es Ihnen außerdem, beliebige Folien zu kopieren (zu klonen) und die geklonte Folie anschließend in die aktuelle Präsentation oder in eine andere geöffnete Präsentation einzufügen. Das Klonen von Folien erzeugt eine neue Folie, die Entwickler ändern können, ohne die Originalfolie zu beeinflussen. Es gibt mehrere Möglichkeiten, eine Folie zu klonen:

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

Wenn Sie eine Folie innerhalb derselben Präsentation klonen und an das Ende der vorhandenen Folien anhängen möchten, verwenden Sie die Methode `add_clone`. Gehen Sie dabei wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Klasse.
1. Rufen Sie die Folien‑Collection vom [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Objekt ab.
1. Rufen Sie die Methode `add_clone` auf der [SlideCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidecollection/) auf und übergeben Sie die zu klonende Folie.
1. Speichern Sie die geänderte Präsentation.

Im folgenden Beispiel wird die erste Folie (Index 0) geklont und an das Ende der Präsentation angehängt.

```py
import aspose.slides as slides

# Instanziieren der Presentation-Klasse, um die Präsentationsdatei zu repräsentieren.
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # Klonen der gewünschten Folie an das Ende der Foliensammlung in derselben Präsentation.
    presentation.slides.add_clone(presentation.slides[0])
    # Speichern der modifizierten Präsentation auf dem Datenträger.
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Klonen an einer bestimmten Position innerhalb derselben Präsentation**

Wenn Sie eine Folie innerhalb derselben Präsentation klonen und an einer anderen Position platzieren möchten, verwenden Sie die Methode `insert_clone`:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Klasse.
1. Rufen Sie die Folien‑Collection vom [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Objekt ab.
1. Rufen Sie die Methode `insert_clone` auf der [SlideCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidecollection/) auf und übergeben Sie die zu klonende Folie sowie den Ziel‑Index für die neue Position.
1. Speichern Sie die geänderte Präsentation.

Im folgenden Beispiel wird die Folie bei Index 1 (Position 2) zu Index 2 (Position 3) innerhalb derselben Präsentation geklont.

```py
import aspose.slides as slides

# Instanziieren der Presentation-Klasse, um die Präsentationsdatei zu repräsentieren.
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # Klonen der gewünschten Folie an die angegebene Position (Index) innerhalb derselben Präsentation.
    presentation.slides.insert_clone(2, presentation.slides[1])
    # Speichern der modifizierten Präsentation auf dem Datenträger.
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Klonen am Ende einer anderen Präsentation**

Wenn Sie eine Folie aus einer Präsentation klonen und an das Ende einer anderen Präsentation anhängen müssen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Klasse für die Quell‑Präsentation (diejenige, die die zu klonende Folie enthält).
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Klasse für die Ziel‑Präsentation (wo die Folie hinzugefügt werden soll).
1. Rufen Sie die Folien‑Collection der Ziel‑Präsentation ab.
1. Rufen Sie `add_clone` auf der Ziel‑[SlideCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidecollection/) auf und übergeben Sie die Folie aus der Quell‑Präsentation.
1. Speichern Sie die geänderte Ziel‑Präsentation.

Im folgenden Beispiel wird die Folie bei Index 0 in der Quell‑Präsentation an das Ende der Ziel‑Präsentation geklont.

```py
import aspose.slides as slides

# Instanziieren der Presentation-Klasse, um die Quellpräsentationsdatei zu repräsentieren.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Instanziieren der Presentation-Klasse für die Ziel-PPTX (wo die Folie geklont wird).
    with slides.Presentation() as target_presentation:
        # Klonen der gewünschten Folie aus der Quellpräsentation an das Ende der Foliensammlung in der Zielpräsentation.
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # Speichern der Zielpräsentation auf dem Datenträger.
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Klonen an einer bestimmten Position in einer anderen Präsentation**

Wenn Sie eine Folie aus einer Präsentation klonen und an einer bestimmten Position in einer anderen Präsentation einfügen müssen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Klasse für die Quell‑Präsentation (die Folie, die geklont werden soll, ist enthalten).
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Klasse für die Ziel‑Präsentation (wo die Folie hinzugefügt werden soll).
1. Rufen Sie die Folien‑Collection der Ziel‑Präsentation ab.
1. Rufen Sie die Methode `insert_clone` auf der Ziel‑[SlideCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidecollection/) auf und übergeben Sie die Folie aus der Quell‑Präsentation sowie den gewünschten Ziel‑Index.
1. Speichern Sie die geänderte Ziel‑Präsentation.

Im folgenden Beispiel wird die Folie bei Index 0 in der Quell‑Präsentation zu Index 2 (Position 3) in der Ziel‑Präsentation geklont.

```py
import aspose.slides as slides

# Instanziieren der Presentation-Klasse, um die Quellpräsentationsdatei zu repräsentieren.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Instanziieren der Presentation-Klasse für die Ziel-PPTX (wo die Folie geklont werden soll).
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # Einfügen eines Klons der ersten Folie aus der Quelle an Index 2 in der Zielpräsentation.
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # Speichern der Zielpräsentation auf dem Datenträger.
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Klonen einer Folie mit ihrer Master‑Folien in eine andere Präsentation**

Wenn Sie eine Folie **mit ihrem Master** aus einer Präsentation klonen und in einer anderen verwenden möchten, klonen Sie zuerst die erforderliche Master‑Folien aus der Quell‑Präsentation in die Ziel‑Präsentation. Verwenden Sie anschließend diesen Ziel‑Master beim Klonen der Folie. Die Methode `add_clone(Slide, MasterSlide)` erwartet einen **Master‑Slide aus der Ziel‑Präsentation**, nicht aus der Quelle.

So klonen Sie eine Folie mit ihrem Master:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Klasse für die Quell‑Präsentation (die Folie, die geklont werden soll, ist enthalten).
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Klasse für die Ziel‑Präsentation.
1. Greifen Sie auf die zu klonende Quell‑Folien und deren Master‑Folien zu.
1. Rufen Sie die [MasterSlideCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/masterslidecollection/) der Ziel‑Präsentation ab.
1. Rufen Sie `add_clone` auf der Ziel‑[MasterSlideCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/masterslidecollection/) auf und übergeben Sie den Quell‑Master, um ihn in die Ziel‑Präsentation zu klonen.
1. Rufen Sie die [SlideCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidecollection/) der Ziel‑Präsentation ab.
1. Rufen Sie `add_clone` auf der Ziel‑[SlideCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidecollection/) auf und übergeben Sie die Quell‑Folien sowie den geklonten Ziel‑Master.
1. Speichern Sie die geänderte Ziel‑Präsentation.

Im folgenden Beispiel wird die Folie bei Index 0 in der Quell‑Präsentation an das Ende der Ziel‑Präsentation geklont, wobei der aus der Quelle geklonte Master verwendet wird.

```py
import aspose.slides as slides

# Instanziieren der Presentation-Klasse, um die Quellpräsentationsdatei zu repräsentieren.
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # Instanziieren der Presentation-Klasse für die Zielpräsentation, in die die Folie geklont wird.
    with slides.Presentation() as target_presentation:
        # Abrufen der ersten Folie aus der Quellpräsentation.
        source_slide = source_presentation.slides[0]
        # Abrufen der Master-Folie, die von der ersten Folie verwendet wird.
        source_master = source_slide.layout_slide.master_slide
        # Klonen der Master-Folie in die Master-Collection der Zielpräsentation.
        cloned_master = target_presentation.masters.add_clone(source_master)
        # Klonen der Folie aus der Quellpräsentation an das Ende der Zielpräsentation unter Verwendung des geklonten Masters.
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # Speichern der Zielpräsentation auf dem Datenträger.
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Klonen am Ende in einem angegebenen Abschnitt**

Mit Aspose.Slides für Python via .NET können Sie eine Folie aus einem Abschnitt einer Präsentation klonen und in einen anderen Abschnitt derselben Präsentation einfügen. Verwenden Sie hierfür die Methode `add_clone(Slide, Section)` der Klasse [SlideCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidecollection/).

Das folgende Python‑Beispiel zeigt, wie man eine Folie klont und den Klon in einen angegebenen Abschnitt einfügt:

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

## **Übereinstimmende Foliengröße sicherstellen**

Beim Klonen von Folien in eine andere Präsentation muss die Ziel‑Präsentation dieselbe Foliengröße wie die Quell‑Präsentation besitzen. Wenn die Foliengrößen unterschiedlich sind, skaliert Aspose.Slides die geklonten Objekte nicht automatisch – deren ursprüngliche Koordinaten und Abmessungen bleiben erhalten, was zu Fehlstellungen oder zum Überschreiten der Folienränder führen kann.

Sie können die Foliengröße der Ziel‑Präsentation vor dem Klonen von Master‑ und Folien an die Quell‑Präsentation anpassen:

```py
source_size = source_presentation.slide_size.size

target_presentation.slide_size.set_size(
    source_size.width, source_size.height, slides.SlideSizeScaleType.DO_NOT_SCALE)
```

Führen Sie dies aus, bevor Sie den Master und die Folie klonen.

## **FAQ**

### Werden Sprecher‑Notizen und Prüferkommentare geklont?

Ja. Die Notizenseite und die Überprüfungskommentare werden in den Klon übernommen. Wenn Sie diese nicht benötigen, [entfernen Sie sie](/slides/de/python-net/presentation-notes/) nach dem Einfügen.

### Wie werden Diagramme und ihre Datenquellen behandelt?

Das Diagramm‑Objekt, die Formatierung und eingebettete Daten werden kopiert. Wenn das Diagramm mit einer externen Quelle verknüpft war (z. B. einer OLE‑eingebetteten Arbeitsmappe), bleibt diese Verknüpfung als [OLE‑Objekt](/slides/de/python-net/manage-ole/) erhalten. Nach dem Verschieben zwischen Dateien sollten Sie die Datenverfügbarkeit und das Aktualisierungsverhalten prüfen.

### Kann ich die Einfügeposition und die Abschnitte für den Klon steuern?

Ja. Sie können den Klon an einem bestimmten Folien‑Index einfügen und ihn einem gewünschten [Abschnitt](/slides/de/python-net/slide-section/) zuordnen. Existiert der Ziel‑Abschnitt nicht, erstellen Sie ihn zuerst und verschieben Sie anschließend die Folie dorthin.