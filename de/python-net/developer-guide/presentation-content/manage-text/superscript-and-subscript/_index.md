---
title: Verwalten von Hoch- und Tiefgestellt in Python
linktitle: Hoch- und Tiefgestellt
type: docs
weight: 80
url: /de/python-net/superscript-and-subscript/
keywords:
- Hochgestellt
- Tiefgestellt
- Hochgestellt hinzufügen
- Tiefgestellt hinzufügen
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Meistern Sie Hoch- und Tiefgestellt in Aspose.Slides für Python über .NET und verbessern Sie Ihre Präsentationen mit professioneller Textformatierung für maximale Wirkung."
---

## **Hoch- und Tiefgestellt Text hinzufügen**

Sie können Hoch- und Tiefgestellt‑Text zu jedem Absatzabschnitt hinzufügen. In Aspose.Slides verwenden Sie die `escapement`‑Eigenschaft der [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/)‑Klasse, um dies zu steuern.

`escapement` ist ein Prozentsatz von **-100% bis 100%**:

- **> 0** → Hochgestellt (z. B. 25% = leichte Anhebung; 100% = volles Hochstellen)
- **0** → Grundlinie (kein Hoch‑ oder Tiefstellen)
- **< 0** → Tiefgestellt (z. B. -25% = leichte Absenkung; -100% = volles Tiefstellen)

Schritte:

1. Erstellen Sie eine [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) und holen Sie eine Folie.
2. Fügen Sie eine Rechteck-[AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) hinzu und greifen Sie auf dessen [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) zu.
3. Löschen Sie vorhandene Absätze.
4. Für Hochgestellt: Erstellen Sie einen Absatz und einen Portion, setzen Sie `portion.portion_format.escapement` auf einen Wert zwischen **0 und 100**, setzen Sie den Text und fügen Sie die Portion hinzu.
5. Für Tiefgestellt: Erstellen Sie einen weiteren Absatz und Portion, setzen Sie `escapement` auf einen Wert zwischen **-100 und 0**, setzen Sie den Text und fügen Sie die Portion hinzu.
6. Speichern Sie die Präsentation als PPTX.
```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    # Folie holen.
    slide = presentation.slides[0]

    # Textfeld erstellen.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)
    shape.text_frame.paragraphs.clear()

    # Absatz für hochgestellten Text erstellen.
    superscript_paragraph = slides.Paragraph()

    # Textabschnitt mit normalem Text erstellen.
    portion1 = slides.Portion()
    portion1.text = "SlideTitle"
    superscript_paragraph.portions.add(portion1)

    # Textabschnitt mit hochgestelltem Text erstellen.
    superscript_portion = slides.Portion()
    superscript_portion.portion_format.escapement = 30
    superscript_portion.text = "TM"
    superscript_paragraph.portions.add(superscript_portion)

    # Absatz für tiefgestellten Text erstellen.
    subscript_paragraph = slides.Paragraph()

    # Textabschnitt mit normalem Text erstellen.
    portion2 = slides.Portion()
    portion2.text = "a"
    subscript_paragraph.portions.add(portion2)

    # Textabschnitt mit tiefgestelltem Text erstellen.
    subscript_portion = slides.Portion()
    subscript_portion.portion_format.escapement = -25
    subscript_portion.text = "i"
    subscript_paragraph.portions.add(subscript_portion)

    # Absätze zum Textfeld hinzufügen.
    shape.text_frame.paragraphs.add(superscript_paragraph)
    shape.text_frame.paragraphs.add(subscript_paragraph)

    presentation.save("TestOut.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Kann ich Hoch‑ oder Tiefgestellt in Tabellen und anderen Containern anwenden, nicht nur in normalen Textfeldern?**

Ja. Sie können Text als Hoch‑ oder Tiefgestellt formatieren, wenn das Objekt ein [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) bereitstellt (einschließlich Tabellenzellen). Die Formatierung gilt für Textabschnitte innerhalb dieses Rahmens.

**Bleiben Hoch‑ und Tiefgestellt‑Formate beim Exportieren zu PDF, HTML oder Bildern erhalten?**

Ja. Aspose.Slides bewahrt die Hoch‑ und Tiefgestellt‑Formatierung beim Export in gängige Formate wie [PDF](/slides/de/python-net/convert-powerpoint-to-pdf/), [HTML](/slides/de/python-net/convert-powerpoint-to-html/) und [Raster‑Bilder](/slides/de/python-net/convert-powerpoint-to-png/), weil die Rendering‑Pipeline die Formatierung auf Portionsebene respektiert.

**Kann ich Hoch‑ oder Tiefgestellt mit Hyperlinks im selben Textfragment kombinieren?**

Ja. [Hyperlinks](/slides/de/python-net/manage-hyperlinks/) werden auf Portionsebene (Fragment) zugewiesen, sodass eine Portion gleichzeitig einen Hyperlink haben und als Hoch‑ oder Tiefgestellt formatiert sein kann.