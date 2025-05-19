---
title: Verwalten von Hoch- und Tiefstellung in Python
linktitle: Hoch- und Tiefstellung
type: docs
weight: 80
url: /de/python-net/superscript-and-subscript/
keywords:
- Hochstellung
- Tiefstellung
- Hochstellung hinzufügen
- Tiefstellung hinzufügen
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Meistern Sie Hoch- und Tiefstellung in Aspose.Slides für Python via .NET und verleihen Sie Ihren Präsentationen mit professioneller Textformatierung maximale Wirkung."
---

## **Verwalten von Hoch- und Tiefgestellt Text**
Sie können hochgestellten und tiefgestellten Text innerhalb eines beliebigen Absatzes hinzufügen. Um hochgestellten oder tiefgestellten Text in einem Aspose.Slides Textfeld hinzuzufügen, muss man die **Escapement**-Eigenschaften der PortionFormat-Klasse verwenden.

Diese Eigenschaft gibt den hochgestellten oder tiefgestellten Text zurück oder setzt ihn (Wert von -100 % (tiefgestellt) bis 100 % (hochgestellt)). Zum Beispiel:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
- Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
- Fügen Sie der Folie eine IAutoShape vom Typ Rechteck hinzu.
- Greifen Sie auf das ITextFrame zu, das mit der IAutoShape verbunden ist.
- Löschen Sie bestehende Absätze.
- Erstellen Sie ein neues Absatzobjekt, um hochgestellten Text zu halten, und fügen Sie es der IParagraphs-Sammlung des ITextFrame hinzu.
- Erstellen Sie ein neues Portionsobjekt.
- Setzen Sie die Escapement-Eigenschaft für die Portion zwischen 0 und 100, um hochgestellten Text hinzuzufügen. (0 bedeutet kein Hochgestellt)
- Setzen Sie etwas Text für die Portion und fügen Sie dann diesen in die Portionssammlung des Absatzes hinzu.
- Erstellen Sie ein neues Absatzobjekt, um tiefgestellten Text zu halten, und fügen Sie es der IParagraphs-Sammlung des ITextFrame hinzu.
- Erstellen Sie ein neues Portionsobjekt.
- Setzen Sie die Escapement-Eigenschaft für die Portion zwischen 0 und -100, um tiefgestellten Text hinzuzufügen. (0 bedeutet kein Tiefgestellt)
- Setzen Sie etwas Text für die Portion und fügen Sie dann diesen in die Portionssammlung des Absatzes ein.
- Speichern Sie die Präsentation als PPTX-Datei.

Die Umsetzung der obigen Schritte ist unten angegeben.

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    # Folie erhalten
    slide = presentation.slides[0]

    # Textfeld erstellen
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)
    textFrame = shape.text_frame
    textFrame.paragraphs.clear()

    # Absatz für hochgestellten Text erstellen
    superPar = slides.Paragraph()

    # Portion mit normalem Text erstellen
    portion1 = slides.Portion()
    portion1.text = "SlideTitle"
    superPar.portions.add(portion1)

    # Portion mit hochgestelltem Text erstellen
    superPortion = slides.Portion()
    superPortion.portion_format.escapement = 30
    superPortion.text = "TM"
    superPar.portions.add(superPortion)

    # Absatz für tiefgestellten Text erstellen
    paragraph2 = slides.Paragraph()

    # Portion mit normalem Text erstellen
    portion2 = slides.Portion()
    portion2.text = "a"
    paragraph2.portions.add(portion2)

    # Portion mit tiefgestelltem Text erstellen
    subPortion = slides.Portion()
    subPortion.portion_format.escapement = -25
    subPortion.text = "i"
    paragraph2.portions.add(subPortion)

    # Absätze zum Textfeld hinzufügen
    textFrame.paragraphs.add(superPar)
    textFrame.paragraphs.add(paragraph2)

    presentation.save("TestOut.pptx", slides.export.SaveFormat.PPTX)
```