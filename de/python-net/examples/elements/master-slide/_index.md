---
title: Masterfolie
type: docs
weight: 30
url: /de/python-net/examples/elements/master-slide/
keywords:
- Masterfolie
- Masterfolie hinzufügen
- Zugriff auf Masterfolie
- Masterfolie entfernen
- Unbenutzte Masterfolie
- Codebeispiele
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Verwalten Sie Masterfolien in Python mit Aspose.Slides: Erstellen, Bearbeiten, Klonen und Formatieren von Themen, Hintergründen, Platzhaltern, um Folien in PowerPoint und OpenDocument zu vereinheitlichen."
---
Masterfolien stellen die oberste Ebene der Folienvererbungshierarchie in PowerPoint dar. Eine **Masterfolie** definiert gemeinsame Designelemente wie Hintergründe, Logos und Textformatierung. **Layoutfolien** erben von Masterfolien, und **Normalfolien** erben von Layoutfolien.

Dieser Artikel zeigt, wie man Masterfolien mit Aspose.Slides for Python via .NET erstellt, ändert und verwaltet.

## **Masterfolie hinzufügen**

Dieses Beispiel zeigt, wie man eine neue Masterfolie erstellt, indem man die Standardfolie klont.

```py
def add_master_slide():
    with slides.Presentation() as presentation:

        # Klonen Sie die Standard-Masterfolie.
        default_master_slide = presentation.masters[0]
        new_master = presentation.masters.add_clone(default_master_slide)

        presentation.save("master_slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Tipp 1:** Masterfolien bieten die Möglichkeit, ein einheitliches Branding oder gemeinsam genutzte Designelemente auf alle Folien anzuwenden. Änderungen an der Masterfolie werden automatisch auf abhängige Layout‑ und Normalfolien übertragen.

> 💡 **Tipp 2:** Alle Formen oder Formatierungen, die einer Masterfolie hinzugefügt werden, werden von Layoutfolien und wiederum von allen Normalfolien, die diese Layouts verwenden, übernommen.  
> Das untenstehende Bild veranschaulicht, wie ein Textfeld, das zu einer Masterfolie hinzugefügt wurde, automatisch auf der Endfolie dargestellt wird.

![Beispiel für Mastervererbung](master-slide-banner.png)

## **Zugriff auf eine Masterfolie**

Sie können auf Masterfolien über die Sammlung `Presentation.masters` zugreifen. So rufen Sie sie ab und arbeiten mit ihnen:

```py
def access_master_slide():
    with slides.Presentation("master_slide.pptx") as presentation:
        # Zugriff auf die erste Masterfolie.
        first_master_slide = presentation.masters[0]
```

## **Masterfolie entfernen**

Masterfolien können entweder nach Index oder per Referenz entfernt werden.

```py
def remove_master_slide():
    with slides.Presentation("master_slide.pptx") as presentation:

        # Entfernen nach Index.
        presentation.masters.remove_at(0)

        # Oder entfernen per Referenz.
        first_master_slide = presentation.masters[0]
        presentation.masters.remove(first_master_slide)

        presentation.save("master_slide_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Unbenutzte Masterfolien entfernen**

Einige Präsentationen enthalten Masterfolien, die nicht verwendet werden. Das Entfernen dieser Folien kann die Dateigröße reduzieren.

```py
def remove_unused_master_slides():
    with slides.Presentation("master_slide.pptx") as presentation:

        # Entfernen Sie alle nicht verwendeten Masterfolien (auch solche, die als Preserve markiert sind).
        presentation.masters.remove_unused(True)

        presentation.save("master_slides_removed.pptx", slides.export.SaveFormat.PPTX)
```

> ⚙️ **Tipp:** Verwenden Sie `remove_unused(True)`, um unbenutzte Masterfolien zu bereinigen und die Präsentationsgröße zu minimieren.