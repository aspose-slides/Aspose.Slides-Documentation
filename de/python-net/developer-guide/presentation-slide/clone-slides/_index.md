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
description: "Klonen oder duplizieren Sie PowerPoint-Folien schnell mit Aspose.Slides für Python via .NET. Folgen Sie unseren klaren Codebeispielen und Tipps, um die PPT-Erstellung in Sekunden zu automatisieren, die Produktivität zu steigern und manuelle Arbeit zu vermeiden."
---
## **Einführung**

Klonen ist der Vorgang, eine exakte Kopie oder Replik eines Objekts zu erstellen. Aspose.Slides ermöglicht es Ihnen ebenfalls, jede Folie zu kopieren (zu klonen) und die geklonte Folie in die aktuelle Präsentation oder in eine andere geöffnete Präsentation einzufügen. Das Klonen von Folien erstellt eine neue Folie, die Entwickler ändern können, ohne die Originalfolie zu beeinflussen. Es gibt mehrere Möglichkeiten, eine Folie zu klonen:

- Klonen am Ende einer Präsentation.
- Klonen an einer anderen Position innerhalb einer Präsentation.
- Klonen am Ende einer anderen Präsentation.
- Klonen an einer anderen Position in einer anderen Präsentation.
- Klonen an einer bestimmten Position in einer anderen Präsentation.

In Aspose.Slides for Python via .NET stellt die [Foliensammlung](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidecollection/) des [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Objekts die Methoden `add_clone` und `insert_clone` zur Verfügung, um diese Arten des Folienklonens auszuführen.

## **Installation**

```bash
pip install aspose.slides
```

## **Klonen am Ende innerhalb derselben Präsentation**

Wenn Sie eine Folie innerhalb derselben Präsentation klonen und an das Ende der vorhandenen Folien anhängen möchten, verwenden Sie die Methode `add_clone`. Befolgen Sie diese Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)-Klasse.
1. Rufen Sie die Foliensammlung des [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)-Objekts ab.
1. Rufen Sie die Methode `add_clone` auf der [SlideCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidecollection/) auf und übergeben Sie die zu klonende Folie.
1. Speichern Sie die geänderte Präsentation.

Im folgenden Beispiel wird die erste Folie (Index 0) geklont und an das Ende der Präsentation angehängt.

```py
import aspose.slides as slides

# Instanzieren der Presentation-Klasse, um die Präsentationsdatei darzustellen.
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # Klone die gewünschte Folie an das Ende der Foliensammlung in derselben Präsentation.
    presentation.slides.add_clone(presentation.slides[0])
    # Speichere die geänderte Präsentation auf die Festplatte.
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Klonen an einer bestimmten Position innerhalb derselben Präsentation**

Wenn Sie eine Folie innerhalb derselben Präsentation klonen und an einer anderen Position einfügen möchten, verwenden Sie die Methode `insert_clone`:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)-Klasse.
1. Rufen Sie die Foliensammlung des [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)-Objekts ab.
1. Rufen Sie die Methode `insert_clone` auf der [SlideCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidecollection/) auf und übergeben Sie die zu klonende Folie sowie den Ziel‑Index für die neue Position.
1. Speichern Sie die geänderte Präsentation.

Im folgenden Beispiel wird die Folie bei Index 1 (Position 2) nach Index 2 (Position 3) innerhalb derselben Präsentation geklont.

```py
import aspose.slides as slides

# Instanziieren der Presentation-Klasse, um die Präsentationsdatei darzustellen.
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # Klone die gewünschte Folie an die angegebene Position (Index) innerhalb derselben Präsentation.
    presentation.slides.insert_clone(2, presentation.slides[1])
    # Speichere die geänderte Präsentation auf die Festplatte.
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Klonen am Ende einer anderen Präsentation**

Wenn Sie eine Folie aus einer Präsentation klonen und an das Ende einer anderen Präsentation anhängen möchten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)-Klasse für die Quellpräsentation (diejenige, die die zu klonende Folie enthält).
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)-Klasse für die Zielpräsentation (wo die Folie hinzugefügt wird).
1. Rufen Sie die Foliensammlung aus der Zielpräsentation ab.
1. Rufen Sie `add_clone` auf der Ziel-[SlideCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidecollection/) auf und übergeben Sie die Folie aus der Quellpräsentation.
1. Speichern Sie die geänderte Zielpräsentation.

Im folgenden Beispiel wird die Folie bei Index 0 in der Quellpräsentation an das Ende der Zielpräsentation geklont.

```py
import aspose.slides as slides

# Instanziieren der Presentation-Klasse, um die Quellpräsentationsdatei darzustellen.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Instanziieren der Presentation-Klasse für die Ziel-PPTX (wo die Folie geklont wird).
    with slides.Presentation() as target_presentation:
        # Klonen Sie die gewünschte Folie aus der Quellpräsentation an das Ende der Folienkollektion in der Zielpräsentation.
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # Speichern Sie die Zielpräsentation auf dem Datenträger.
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Klonen an einer bestimmten Position in einer anderen Präsentation**

Wenn Sie eine Folie aus einer Präsentation klonen und an einer bestimmten Position in einer anderen Präsentation einfügen müssen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)-Klasse für die Quellpräsentation (diejenige, die die zu klonende Folie enthält).
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)-Klasse für die Zielpräsentation (wo die Folie hinzugefügt wird).
1. Rufen Sie die Foliensammlung aus der Zielpräsentation ab.
1. Rufen Sie die Methode `insert_clone` auf der Ziel-[SlideCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidecollection/) auf und übergeben Sie die Folie aus der Quellpräsentation sowie den gewünschten Ziel‑Index.
1. Speichern Sie die geänderte Zielpräsentation.

Im folgenden Beispiel wird die Folie bei Index 0 in der Quellpräsentation nach Index 2 (Position 3) in der Zielpräsentation geklont.

```py
import aspose.slides as slides

# Instanziieren der Presentation-Klasse, um die Quellpräsentationsdatei darzustellen.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Instanziieren der Presentation-Klasse für die Ziel-PPTX (wo die Folie geklont werden soll).
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # Ein Klon der ersten Folie aus der Quelle an Index 2 in der Zielpräsentation einfügen.
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # Speichern der Zielpräsentation auf der Festplatte.
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Klonen einer Folie mit ihrer Masterfolie in eine andere Präsentation**

Wenn Sie eine Folie **mit ihrer Masterfolie** aus einer Präsentation klonen und in einer anderen verwenden müssen, klonen Sie zunächst die erforderliche Masterfolie aus der Quellpräsentation in die Zielpräsentation. Verwenden Sie dann diesen Ziel‑Master beim Klonen der Folie. Die Methode `add_clone(Slide, MasterSlide)` erwartet eine **Masterfolie aus der Zielpräsentation**, nicht aus der Quelle.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)-Klasse für die Quellpräsentation (diejenige, die die zu klonende Folie enthält).
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)-Klasse für die Zielpräsentation.
1. Greifen Sie auf die Quellfolie zu, die geklont werden soll, und auf deren Masterfolie.
1. Rufen Sie die [MasterSlideCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/masterslidecollection/) aus der Master‑Sammlung der Zielpräsentation ab.
1. Rufen Sie `add_clone` auf der Ziel-[MasterSlideCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/masterslidecollection/) auf und übergeben Sie den Quell‑Master, um ihn in die Zielpräsentation zu klonen.
1. Rufen Sie die [SlideCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidecollection/) aus der Folien‑Sammlung der Zielpräsentation ab.
1. Rufen Sie `add_clone` auf der Ziel-[SlideCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidecollection/) auf und übergeben Sie die Quellfolie sowie den geklonten Ziel‑Master.
1. Speichern Sie die geänderte Zielpräsentation.

Im folgenden Beispiel wird die Folie bei Index 0 in der Quellpräsentation an das Ende der Zielpräsentation geklont, wobei der aus der Quelle geklonte Master verwendet wird.

```py
import aspose.slides as slides

# Instanziieren der Presentation-Klasse, um die Quellpräsentationsdatei darzustellen.
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # Instanziieren der Presentation-Klasse für die Zielpräsentation, in die die Folie geklont wird.
    with slides.Presentation() as target_presentation:
        # Erste Folie aus der Quellpräsentation holen.
        source_slide = source_presentation.slides[0]
        # Masterfolie, die von der ersten Folie verwendet wird, holen.
        source_master = source_slide.layout_slide.master_slide
        # Masterfolie in die Mastersammlung der Zielpräsentation klonen.
        cloned_master = target_presentation.masters.add_clone(source_master)
        # Folie aus der Quellpräsentation an das Ende der Zielpräsentation klonen, wobei die geklonte Masterfolie verwendet wird.
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # Zielpräsentation auf die Festplatte speichern.
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Klonen am Ende in einem angegebenen Abschnitt**

Mit Aspose.Slides for Python via .NET können Sie eine Folie aus einem Abschnitt einer Präsentation klonen und in einen anderen Abschnitt derselben Präsentation einfügen. Verwenden Sie dafür die Methode `add_clone(Slide, Section)` der Klasse [SlideCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidecollection/).

Das folgende Python‑Beispiel zeigt, wie man eine Folie klont und die Kopie in einen angegebenen Abschnitt einfügt:

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

## **Sicherstellen einer übereinstimmenden Foliengröße**

Beim Klonen von Folien in eine andere Präsentation sollten Sie sicherstellen, dass die Zielpräsentation dieselbe Foliengröße wie die Quelle hat. Bei unterschiedlichen Foliengrößen skaliert Aspose.Slides die geklonten Formen nicht automatisch – ihre ursprünglichen Koordinaten und Abmessungen bleiben erhalten, was dazu führen kann, dass Inhalte falsch ausgerichtet sind oder über die Folienränder hinausgehen.

Sie können die Foliengröße der Zielpräsentation vor dem Klonen von Master und Folie auf die Größe der Quelle einstellen:

```py
source_size = source_presentation.slide_size.size

target_presentation.slide_size.set_size(
    source_size.width, source_size.height, slides.SlideSizeScaleType.DO_NOT_SCALE)
```

Machen Sie dies, bevor Sie den Master und die Folie klonen.

## **FAQ**

### Werden Rednernotizen und Prüferkommentare geklont?

Ja. Die Notizenseite und die Prüferkommentare werden in den Klon übernommen. Wenn Sie sie nicht möchten, [entfernen Sie sie](/slides/de/python-net/presentation-notes/) nach dem Einfügen.

### Wie werden Diagramme und deren Datenquellen behandelt?

Das Diagrammobjekt, die Formatierung und die eingebetteten Daten werden kopiert. Wenn das Diagramm mit einer externen Quelle verknüpft war (z.B. einer OLE‑eingebetteten Arbeitsmappe), bleibt diese Verknüpfung als [OLE‑Objekt](/slides/de/python-net/manage-ole/) erhalten. Nach dem Verschieben zwischen Dateien sollten Sie die Datenverfügbarkeit und das Aktualisierungsverhalten prüfen.

**Kann ich die Einfügeposition und Abschnitte für den Klon steuern?**

Ja. Sie können den Klon an einem bestimmten Folien‑Index einfügen und ihn in einen gewählten [Abschnitt](/slides/de/python-net/slide-section/) verschieben. Falls der Zielabschnitt nicht existiert, erstellen Sie ihn zuerst und verschieben Sie dann die Folie hinein.
