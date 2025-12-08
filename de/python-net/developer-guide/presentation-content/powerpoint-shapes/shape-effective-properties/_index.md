---
title: Ermitteln von Shape-Effektiven Eigenschaften aus Präsentationen mit Python
linktitle: Effektive Eigenschaften
type: docs
weight: 50
url: /de/python-net/shape-effective-properties/
keywords:
- Shape-Eigenschaften
- Kameraeigenschaften
- Lichtanlage
- Bevel-Form
- Textrahmen
- Textstil
- Schriftgröße
- Füllformat
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Aspose.Slides für Python via .NET effektive Shape-Eigenschaften berechnet und anwendet, um eine präzise PowerPoint- und OpenDocument-Darstellung zu ermöglichen."
---

## **Übersicht**

In diesem Thema lernen Sie die Konzepte der **effective** und **local** Eigenschaften kennen. Wenn Werte direkt auf den folgenden Ebenen festgelegt werden:

1. In den Eigenschaften des Textabschnitts auf der Folie.
2. Im Textstil der Prototypform im Layout oder in der Masterfolie (falls der Textrahmen einen hat).
3. In den globalen Texteinstellungen der Präsentation.

Diese Werte werden **local** Werte genannt. Auf jeder Ebene können **local** Werte definiert oder weggelassen werden. Wenn die Anwendung bestimmen muss, wie der Textabschnitt angezeigt werden soll, verwendet sie die **effective** Werte. Sie können die **effective** Werte erhalten, indem Sie die Methode `get_effective` im lokalen Format aufrufen.

Das folgende Beispiel zeigt, wie Sie die **effective** Werte für ein Textfeldformat und ein Textabschnittsformat erhalten.
```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    local_text_frame_format = shape.text_frame.text_frame_format
    effective_text_frame_format = local_text_frame_format.get_effective()

    local_portion_format = shape.text_frame.paragraphs[0].portions[0].portion_format
    effective_portion_format = local_portion_format.get_effective()
```


## **Effective Kameraeigenschaften abrufen**

Aspose.Slides für Python via .NET ermöglicht das Abrufen der **effective** Kameraeigenschaften. Die Klasse [ICameraEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icameraeffectivedata/) stellt ein unveränderliches Objekt dar, das diese Eigenschaften enthält. Eine Instanz von [ICameraEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icameraeffectivedata/) wird über [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/) bereitgestellt, die die **effective** Werte für die Klasse [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) liefert.

Das folgende Beispiel zeigt, wie Sie die **effective** Kameraeigenschaften abrufen:
```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

	three_d_effective_data = shape.three_d_format.get_effective()

	print("= Effective camera properties =")
	print("Type:", str(three_d_effective_data.camera.camera_type))
	print("Field of view:", str(three_d_effective_data.camera.field_of_view_angle))
	print("Zoom:", str(three_d_effective_data.camera.zoom))
```


## **Effective Lichtriggeigenschaften abrufen**

Aspose.Slides für Python via .NET ermöglicht das Abrufen der **effective** Eigenschaften eines Lichtriggs. Die Klasse [ILightRigEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilightrigeffectivedata/) stellt ein unveränderliches Objekt dar, das diese Eigenschaften enthält. Eine Instanz von [ILightRigEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilightrigeffectivedata/) wird über [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/) bereitgestellt, die die **effective** Werte für die Klasse [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) liefert.

Das folgende Beispiel zeigt, wie Sie die **effective** Lichtriggeigenschaften abrufen:
```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

	three_d_effective_data = shape.three_d_format.get_effective()

	print("= Effective light rig properties =")
	print("Type:", str(three_d_effective_data.light_rig.light_type))
	print("Direction:", str(three_d_effective_data.light_rig.direction))
```


## **Effective Forminhaltseigenschaften abrufen**

Aspose.Slides für Python via .NET ermöglicht das Abrufen der **effective** Eigenschaften einer Forminhalt (Bevel). Die Klasse [IShapeBevelEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ishapebeveleffectivedata/) stellt ein unveränderliches Objekt dar, das die Face-Relief‑(Bevel‑)Eigenschaften einer Form enthält. Eine Instanz von [IShapeBevelEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ishapebeveleffectivedata/) wird über [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/) bereitgestellt, die die **effective** Werte für die Klasse [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) liefert.

Das folgende Beispiel zeigt, wie Sie die **effective** Eigenschaften eines Forminhalt (Bevel) abrufen:
```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

	three_d_effective_data = shape.three_d_format.get_effective()

	print("= Effective shape's top face relief properties =")
	print("Type:", str(three_d_effective_data.bevel_top.bevel_type))
	print("Width:", str(three_d_effective_data.bevel_top.width))
	print("Height:", str(three_d_effective_data.bevel_top.height))
```


## **Effective Textrahmeneigenschaften abrufen**

Mit Aspose.Slides für Python via .NET können Sie die **effective** Eigenschaften eines Textrahmens abrufen. Die Klasse [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/itextframeformateffectivedata/) enthält die **effective** Formatierungseigenschaften des Textrahmens.

Das folgende Beispiel zeigt, wie Sie die **effective** Textrahmenformatierungseigenschaften abrufen:
```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
	shape = presentation.slides[0].shapes[0]

	text_frame_format_effective_data = shape.text_frame.text_frame_format.get_effective()

	print("Anchoring type:", str(text_frame_format_effective_data.anchoring_type))
	print("Autofit type:", str(text_frame_format_effective_data.autofit_type))
	print("Text vertical type:", str(text_frame_format_effective_data.text_vertical_type))
	print("Margins")
	print("   Left:", str(text_frame_format_effective_data.margin_left))
	print("   Top:", str(text_frame_format_effective_data.margin_top))
	print("   Right:", str(text_frame_format_effective_data.margin_right))
	print("   Bottom:", str(text_frame_format_effective_data.margin_bottom))
```


## **Effective Textstileigenschaften abrufen**

Mit Aspose.Slides für Python via .NET können Sie die **effective** Eigenschaften eines Textstils abrufen. Die Klasse [ITextStyleEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/itextstyleeffectivedata/) enthält die **effective** Textstileigenschaften.

Das folgende Beispiel zeigt, wie Sie die **effective** Textstileigenschaften abrufen:
```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    effective_text_style = shape.text_frame.text_frame_format.text_style.get_effective()

    for i in range(8):
        effectiveStyleLevel = effective_text_style.get_level(i)
        print(f"= Effective paragraph formatting for style level #{str(i)} =")

        print("Depth:", str(effectiveStyleLevel.depth))
        print("Indent:", str(effectiveStyleLevel.indent))
        print("Alignment:", str(effectiveStyleLevel.alignment))
        print("Font alignment:", str(effectiveStyleLevel.font_alignment))
```


## **Effective Schriftgradhöhe abrufen**

Mit Aspose.Slides für Python via .NET können Sie die **effective** Schriftgradhöhe abrufen. Das folgende Beispiel demonstriert, wie sich die **effective** Schriftgradhöhe eines Textabschnitts ändert, wenn Sie lokale Schriftgradhöhenwerte auf verschiedenen Ebenen der Präsentationsstruktur festlegen.
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 75, False)

    shape.add_text_frame("")
    paragraph = shape.text_frame.paragraphs[0]

    portion0 = slides.Portion("Sample text with first portion")
    portion1 = slides.Portion(" and second portion.")

    paragraph.portions.add(portion0)
    paragraph.portions.add(portion1)

    print("Effective font height just after creation:")
    print("Portion #0:", portion0.portion_format.get_effective().font_height)
    print("Portion #1:", portion1.portion_format.get_effective().font_height)

    presentation.default_text_style.get_level(0).default_portion_format.font_height = 24

    print("Effective font height after setting entire presentation default font height:")
    print("Portion #0:", portion0.portion_format.get_effective().font_height)
    print("Portion #1:", portion1.portion_format.get_effective().font_height)

    paragraph.paragraph_format.default_portion_format.font_height = 40

    print("Effective font height after setting paragraph default font height:")
    print("Portion #0:", portion0.portion_format.get_effective().font_height)
    print("Portion #1:", portion1.portion_format.get_effective().font_height)

    paragraph.portions[0].portion_format.font_height = 55

    print("Effective font height after setting portion #0 font height:")
    print("Portion #0:", portion0.portion_format.get_effective().font_height)
    print("Portion #1:", portion1.portion_format.get_effective().font_height)

    paragraph.portions[1].portion_format.font_height = 18

    print("Effective font height after setting portion #1 font height:")
    print("Portion #0:", portion0.portion_format.get_effective().font_height)
    print("Portion #1:", portion1.portion_format.get_effective().font_height)

    presentation.save("SetLocalFontHeightValues.pptx",slides.export.SaveFormat.PPTX)
```


## **Effective Tabellenfüllformat abrufen**

Mit Aspose.Slides für Python via .NET können Sie das **effective** Füllformat für verschiedene logische Teile einer Tabelle abrufen. Die Klasse [IFillFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/) enthält die **effective** Füllformatierungs‑Eigenschaften. Beachten Sie, dass die Zellenformatierung stets höhere Priorität hat als die Zeilenformatierung, eine Zeile höhere Priorität als eine Spalte und eine Spalte höhere Priorität als die gesamte Tabelle.

Daher werden letztlich die Eigenschaften von [ICellFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icellformateffectivedata/) verwendet, um die Tabelle zu zeichnen. Das folgende Beispiel zeigt, wie Sie das **effective** Füllformat für die verschiedenen Tabellenniveaus abrufen:
```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
	table = presentation.slides[0].shapes[0]

	table_format_effective = table.table_format.get_effective()
	row_format_effective = table.rows[0].row_format.get_effective()
	column_format_effective = table.columns[0].column_format.get_effective()
	cell_format_effective = table[0, 0].cell_format.get_effective()

	table_fill_format_effective = table_format_effective.fill_format
	row_fill_format_effective = row_format_effective.fill_format
	column_fill_format_effective = column_format_effective.fill_format
	cell_fill_format_effective = cell_format_effective.fill_format
```


## **FAQ**

**Wie kann ich erkennen, ob ich einen „Snapshot“ statt eines „Live‑Objekts“ erhalten habe, und wann sollte ich die **effective** Eigenschaften erneut auslesen?**

**EffectiveData**‑Objekte sind unveränderliche Schnappschüsse von berechneten Werten zum Zeitpunkt des Aufrufs. Wenn Sie lokale oder geerbte Einstellungen der Form ändern, lesen Sie die **effective** Daten erneut, um die aktualisierten Werte zu erhalten.

**Wirkt sich das Ändern des Layouts/der Masterfolie auf bereits abgerufene **effective** Eigenschaften aus?**

Ja, jedoch erst, nachdem Sie sie erneut gelesen haben. Ein bereits erhaltenes **EffectiveData**‑Objekt aktualisiert sich nicht selbst – fordern Sie es nach einer Änderung des Layouts oder Masters erneut an.

**Kann ich Werte über **EffectiveData** verändern?**

Nein. **EffectiveData** ist schreibgeschützt. Nehmen Sie Änderungen in den lokalen Formatierungsobjekten (Form/Text/3D usw.) vor und holen Sie sich anschließend ggf. erneut die **effective** Werte.

**Was passiert, wenn ein Property weder auf Form‑Ebene, noch im Layout/Master, noch in den globalen Einstellungen gesetzt ist?**

Der **effective** Wert wird durch den Standard‑Mechanismus (PowerPoint/Aspose.Slides‑Standardwerte) bestimmt. Dieser aufgelöste Wert wird Teil des **EffectiveData**‑Snapshots.

**Kann ich aus einem **effective** Schriftwert ableiten, welche Ebene die Größe bzw. die Schriftart bereitgestellt hat?**

Nicht direkt. **EffectiveData** liefert den endgültigen Wert. Um die Quelle zu finden, prüfen Sie die lokalen Werte auf Abschnitt/Absatz/Textrahmen‑Ebene und die Textstile im Layout/Master/Präsentation, um zu sehen, wo die erste explizite Definition vorkommt.

**Warum sehen **EffectiveData**‑Werte manchmal identisch mit den lokalen aus?**

Weil der lokale Wert letztlich final ist (keine höhere Ebene musste vererbt werden). In solchen Fällen stimmt der **effective** Wert mit dem lokalen überein.

**Wann sollte ich **effective** Eigenschaften verwenden und wann nur mit lokalen arbeiten?**

Verwenden Sie **EffectiveData**, wenn Sie das „wie gerenderte“ Ergebnis nach vollständiger Vererbung benötigen (z. B. zum Ausrichten von Farben, Einzügen oder Größen). Wenn Sie die Formatierung auf einer bestimmten Ebene ändern wollen, bearbeiten Sie die lokalen Eigenschaften und lesen Sie ggf. anschließend **EffectiveData** erneut, um das Ergebnis zu prüfen.