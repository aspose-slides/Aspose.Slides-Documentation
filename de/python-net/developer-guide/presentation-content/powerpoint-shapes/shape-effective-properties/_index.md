---
title: Effektive Formeigenschaften aus Präsentationen mit Python abrufen
linktitle: Effektive Eigenschaften
type: docs
weight: 50
url: /de/python-net/shape-effective-properties/
keywords:
- Formeigenschaften
- Kameraeigenschaften
- Lichtanlage
- Faseform
- Textfeld
- Textstil
- Schriftgröße
- Füllformat
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Entdecken Sie, wie Aspose.Slides für Python via .NET effektive Formeigenschaften berechnet und anwendet, um präzises PowerPoint- und OpenDocument-Rendering zu gewährleisten."
---

## **Übersicht**

In diesem Thema lernen Sie die Konzepte der **effektiven** und **lokalen** Eigenschaften kennen. Wenn Werte direkt auf den folgenden Ebenen gesetzt werden:

1. In den Texteigenschaften des Textabschnitts auf der Folie.
2. Im Textstil der Prototypform auf dem Layout oder der Masterfolie (falls das Textfeld einen hat).
3. In den globalen Texteinstellungen der Präsentation.

werden diese Werte **lokale** Werte genannt. Auf jeder Ebene können **lokale** Werte definiert oder weggelassen werden. Wenn die Anwendung bestimmen muss, wie der Textabschnitt erscheinen soll, verwendet sie die **effektiven** Werte. Sie können die effektiven Werte erhalten, indem Sie die Methode `get_effective` auf dem lokalen Format aufrufen.

Das folgende Beispiel zeigt, wie Sie die effektiven Werte für ein Textfeldformat und ein Textabschnittsformat erhalten.

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    local_text_frame_format = shape.text_frame.text_frame_format
    effective_text_frame_format = local_text_frame_format.get_effective()

    local_portion_format = shape.text_frame.paragraphs[0].portions[0].portion_format
    effective_portion_format = local_portion_format.get_effective()
```

## **Effektive Kameraeigenschaften abrufen**

Aspose.Slides für Python via .NET ermöglicht das Abrufen der effektiven Kameraeigenschaften. Die [ICameraEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icameraeffectivedata/) Klasse stellt ein unveränderliches Objekt dar, das diese Eigenschaften enthält. Eine Instanz von [ICameraEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icameraeffectivedata/) wird über [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/) bereitgestellt, das die effektiven Werte für die [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) Klasse liefert.

Das folgende Beispiel zeigt, wie man die effektiven Kameraeigenschaften erhält:

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

## **Effektive Light‑Rig‑Eigenschaften abrufen**

Aspose.Slides für Python via .NET ermöglicht das Abrufen der effektiven Eigenschaften einer Lichtanlage. Die [ILightRigEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilightrigeffectivedata/) Klasse stellt ein unveränderliches Objekt dar, das diese Eigenschaften enthält. Eine Instanz von [ILightRigEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilightrigeffectivedata/) wird über [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/) bereitgestellt, das die effektiven Werte für die [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) Klasse liefert.

Das folgende Beispiel zeigt, wie man die effektiven Light‑Rig‑Eigenschaften erhält:

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

	three_d_effective_data = shape.three_d_format.get_effective()

	print("= Effective light rig properties =")
	print("Type:", str(three_d_effective_data.light_rig.light_type))
	print("Direction:", str(three_d_effective_data.light_rig.direction))
```

## **Effektive Form‑Fasen‑Eigenschaften abrufen**

Aspose.Slides für Python via .NET ermöglicht das Abrufen der effektiven Eigenschaften einer Form‑Fase. Die [IShapeBevelEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ishapebeveleffectivedata/) Klasse stellt ein unveränderliches Objekt dar, das die Fasen‑Eigenschaften einer Form enthält. Eine Instanz von [IShapeBevelEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ishapebeveleffectivedata/) wird über [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/) bereitgestellt, das die effektiven Werte für die [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) Klasse liefert.

Das folgende Beispiel zeigt, wie man die effektiven Eigenschaften einer Form‑Fase erhält:

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

## **Effektive Textfeld‑Eigenschaften abrufen**

Mit Aspose.Slides für Python via .NET können Sie die effektiven Eigenschaften eines Textfelds abrufen. Die [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/itextframeformateffectivedata/) Klasse enthält die effektiven Formatierungseigenschaften des Textfelds.

Das folgende Beispiel zeigt, wie man die effektiven Textfeld‑Formatierungseigenschaften erhält:

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

## **Effektive Textstil‑Eigenschaften abrufen**

Mit Aspose.Slides für Python via .NET können Sie die effektiven Eigenschaften eines Textstils abrufen. Die [ITextStyleEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/itextstyleeffectivedata/) Klasse enthält die effektiven Textstileigenschaften.

Das folgende Beispiel zeigt, wie man die effektiven Textstileigenschaften erhält:

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

## **Effektive Schriftgröße abrufen**

Mit Aspose.Slides für Python via .NET können Sie die effektive Schriftgröße abrufen. Das folgende Beispiel demonstriert, wie sich die effektive Schriftgröße eines Textabschnitts ändert, wenn Sie lokale Schriftgrößenwerte auf unterschiedlichen Ebenen der Präsentationsstruktur festlegen.

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

## **Effektives Tabellen‑Füllformat abrufen**

Mit Aspose.Slides für Python via .NET können Sie das effektive Füllformat für verschiedene logische Teile einer Tabelle abrufen. Die [IFillFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/) Klasse enthält die effektiven Füllformat-Eigenschaften. Beachten Sie, dass Zellformatierungen immer Vorrang vor Zeilenformatierungen haben, eine Zeilenformatierung Vorrang vor Spaltenformatierung hat und eine Spaltenformatierung Vorrang vor der gesamten Tabelle hat.

Daher werden letztlich die Eigenschaften von [ICellFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icellformateffectivedata/) verwendet, um die Tabelle zu zeichnen. Das folgende Beispiel zeigt, wie man das effektive Füllformat für die verschiedenen Tabellenebenen erhält:

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

**Wie kann ich erkennen, dass ich einen „Snapshot“ und kein „Live‑Objekt“ erhalten habe, und wann sollte ich effektive Eigenschaften erneut auslesen?**

EffectiveData‑Objekte sind unveränderliche Snapshots der zum Zeitpunkt des Aufrufs berechneten Werte. Wenn Sie lokale oder geerbte Einstellungen der Form ändern, rufen Sie die effektiven Daten erneut ab, um die aktualisierten Werte zu erhalten.

**Wirkt sich das Ändern des Layouts/der Master‑Folien auf bereits abgerufene effektive Eigenschaften aus?**

Ja, jedoch erst, nachdem Sie sie erneut ausgelesen haben. Ein bereits erhaltenes EffectiveData‑Objekt aktualisiert sich nicht von selbst – fordern Sie es nach Änderungen am Layout oder Master erneut an.

**Kann ich Werte über EffectiveData ändern?**

Nein. EffectiveData ist schreibgeschützt. Ändern Sie die lokalen Formatierungsobjekte (Form/Text/3D usw.) und holen Sie anschließend die effektiven Werte erneut.

**Was passiert, wenn eine Eigenschaft weder auf Form‑Ebene, noch im Layout/Master, noch in den globalen Einstellungen gesetzt ist?**

Der effektive Wert wird durch den Standardmechanismus (PowerPoint/Aspose.Slides‑Standards) ermittelt. Dieser aufgelöste Wert wird Teil des EffectiveData‑Snapshots.

**Kann ich anhand eines effektiven Schriftwerts erkennen, welche Ebene die Größe bzw. die Schriftart bereitgestellt hat?**

Nicht direkt. EffectiveData liefert den endgültigen Wert. Um die Quelle zu finden, prüfen Sie die lokalen Werte auf Portion‑/Paragraph‑/Text‑Frame‑Ebene sowie die Textstile im Layout/Master/der Präsentation, um zu sehen, wo die erste explizite Definition vorkommt.

**Warum sehen EffectiveData‑Werte manchmal identisch zu den lokalen aus?**

Weil der lokale Wert letztlich endgültig war (keine höhere Vererbung nötig). In solchen Fällen stimmt der effektive Wert mit dem lokalen überein.

**Wann sollte ich effektive Eigenschaften verwenden und wann nur lokale?**

Verwenden Sie EffectiveData, wenn Sie das „wie gerenderte“ Ergebnis nach vollständiger Vererbung benötigen (z. B. zum Angleichen von Farben, Einzügen oder Größen). Wenn Sie Formatierungen auf einer bestimmten Ebene ändern wollen, bearbeiten Sie die lokalen Eigenschaften und lesen Sie bei Bedarf EffectiveData erneut, um das Ergebnis zu prüfen.