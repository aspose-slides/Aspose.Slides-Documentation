---
title: Effektive Shape-Eigenschaften aus Präsentationen mit Python abrufen
linktitle: Effektive Eigenschaften
type: docs
weight: 50
url: /de/python-net/shape-effective-properties/
keywords:
- Shape-Eigenschaften
- Kameraeigenschaften
- Lichtanlage
- Formabsatz
- Textfeld
- Textstil
- Schriftgröße
- Füllformat
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Aspose.Slides für Python via .NET effektive Shape-Eigenschaften berechnet und anwendet, um präzises PowerPoint- und OpenDocument-Rendering zu ermöglichen."
---

## **Übersicht**

In diesem Thema lernen Sie die Konzepte der **effektiven** und **lokalen** Eigenschaften kennen. Wenn Werte direkt auf den folgenden Ebenen festgelegt werden:

1. In den Texteigenschaften eines Textabschnitts auf der Folie.  
2. Im Texteigenschaftsstil der Prototyp‑Shape auf dem Layout‑ oder Master‑Slide (falls das Textfeld einen hat).  
3. In den globalen Texteinstellungen der Präsentation.

werden diese Werte **lokale** Werte genannt. Auf jeder Ebene können **lokale** Werte definiert oder weggelassen werden. Wenn die Anwendung bestimmen muss, wie der Textabschnitt dargestellt werden soll, verwendet sie die **effektiven** Werte. Sie können die effektiven Werte erhalten, indem Sie die Methode `get_effective` auf dem lokalen Format aufrufen.

Das folgende Beispiel zeigt, wie man die effektiven Werte für ein Textfeld‑Format und ein Textabschnitt‑Format abruft.

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

Aspose.Slides für Python via .NET ermöglicht das Abrufen der effektiven Kameraeigenschaften. Die Klasse [ICameraEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icameraeffectivedata/) stellt ein unveränderliches Objekt dar, das diese Eigenschaften enthält. Eine Instanz von [ICameraEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icameraeffectivedata/) wird über [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/) bereitgestellt, die die effektiven Werte für die Klasse [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) liefert.

Das folgende Beispiel zeigt, wie man die effektiven Kameraeigenschaften abruft:

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

	three_d_effective_data = shape.three_d_format.get_effective()

	print("= Effektive Kameraeigenschaften =")
	print("Typ:", str(three_d_effective_data.camera.camera_type))
	print("Sichtfeld:", str(three_d_effective_data.camera.field_of_view_angle))
	print("Zoom:", str(three_d_effective_data.camera.zoom))
```

## **Effektive Light‑Rig‑Eigenschaften abrufen**

Aspose.Slides für Python via .NET ermöglicht das Abrufen der effektiven Eigenschaften eines Light‑Rigs. Die Klasse [ILightRigEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilightrigeffectivedata/) stellt ein unveränderliches Objekt dar, das diese Eigenschaften enthält. Eine Instanz von [ILightRigEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilightrigeffectivedata/) wird über [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/) bereitgestellt, die die effektiven Werte für die Klasse [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) liefert.

Das folgende Beispiel zeigt, wie man die effektiven Light‑Rig‑Eigenschaften abruft:

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

	three_d_effective_data = shape.three_d_format.get_effective()

	print("= Effektive Light‑Rig‑Eigenschaften =")
	print("Typ:", str(three_d_effective_data.light_rig.light_type))
	print("Richtung:", str(three_d_effective_data.light_rig.direction))
```

## **Effektive Shape‑Bevel‑Eigenschaften abrufen**

Aspose.Slides für Python via .NET ermöglicht das Abrufen der effektiven Eigenschaften eines Shape‑Bevels. Die Klasse [IShapeBevelEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ishapebeveleffectivedata/) stellt ein unveränderliches Objekt dar, das die Face‑Relief‑ (Bevel‑) Eigenschaften einer Shape enthält. Eine Instanz von [IShapeBevelEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ishapebeveleffectivedata/) wird über [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/) bereitgestellt, die die effektiven Werte für die Klasse [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) liefert.

Das folgende Beispiel zeigt, wie man die effektiven Bevel‑Eigenschaften einer Shape abruft:

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

	three_d_effective_data = shape.three_d_format.get_effective()

	print("= Effektive Eigenschaften des Shape‑Obereinschnitts =")
	print("Typ:", str(three_d_effective_data.bevel_top.bevel_type))
	print("Breite:", str(three_d_effective_data.bevel_top.width))
	print("Höhe:", str(three_d_effective_data.bevel_top.height))
```

## **Effektive Textfeld‑Eigenschaften abrufen**

Mit Aspose.Slides für Python via .NET können Sie die effektiven Eigenschaften eines Textfelds abrufen. Die Klasse [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/itextframeformateffectivedata/) enthält die effektiven Textfeld‑Formatierungseigenschaften.

Das folgende Beispiel zeigt, wie man die effektiven Textfeld‑Formatierungseigenschaften abruft:

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
	shape = presentation.slides[0].shapes[0]

	text_frame_format_effective_data = shape.text_frame.text_frame_format.get_effective()

	print("Verankerungstyp:", str(text_frame_format_effective_data.anchoring_type))
	print("Autofit‑Typ:", str(text_frame_format_effective_data.autofit_type))
	print("Vertikaler Texttyp:", str(text_frame_format_effective_data.text_vertical_type))
	print("Ränder")
	print("   Links:", str(text_frame_format_effective_data.margin_left))
	print("   Oben:", str(text_frame_format_effective_data.margin_top))
	print("   Rechts:", str(text_frame_format_effective_data.margin_right))
	print("   Unten:", str(text_frame_format_effective_data.margin_bottom))
```

## **Effektive Textstil‑Eigenschaften abrufen**

Mit Aspose.Slides für Python via .NET können Sie die effektiven Eigenschaften eines Textstils abrufen. Die Klasse [ITextStyleEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/itextstyleeffectivedata/) enthält die effektiven Textstil‑Eigenschaften.

Das folgende Beispiel zeigt, wie man die effektiven Textstil‑Eigenschaften abruft:

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    effective_text_style = shape.text_frame.text_frame_format.text_style.get_effective()

    for i in range(8):
        effectiveStyleLevel = effective_text_style.get_level(i)
        print(f"= Effektive Absatzformatierung für Stil‑Stufe #{str(i)} =")

        print("Tiefe:", str(effectiveStyleLevel.depth))
        print("Einzug:", str(effectiveStyleLevel.indent))
        print("Ausrichtung:", str(effectiveStyleLevel.alignment))
        print("Schriftartausrichtung:", str(effectiveStyleLevel.font_alignment))
```

## **Effektive Schriftgröße abrufen**

Mit Aspose.Slides für Python via .NET können Sie die effektive Schriftgröße abrufen. Das nachfolgende Beispiel zeigt, wie sich die effektive Schriftgröße eines Textabschnitts ändert, wenn Sie lokale Schriftgrößenwerte auf verschiedenen Ebenen der Präsentationsstruktur festlegen.

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

    print("Effektive Schriftgröße unmittelbar nach Erstellung:")
    print("Abschnitt #0:", portion0.portion_format.get_effective().font_height)
    print("Abschnitt #1:", portion1.portion_format.get_effective().font_height)

    presentation.default_text_style.get_level(0).default_portion_format.font_height = 24

    print("Effektive Schriftgröße nach Festlegung der Standard‑Schriftgröße für die gesamte Präsentation:")
    print("Abschnitt #0:", portion0.portion_format.get_effective().font_height)
    print("Abschnitt #1:", portion1.portion_format.get_effective().font_height)

    paragraph.paragraph_format.default_portion_format.font_height = 40

    print("Effektive Schriftgröße nach Festlegung der Standard‑Schriftgröße für den Absatz:")
    print("Abschnitt #0:", portion0.portion_format.get_effective().font_height)
    print("Abschnitt #1:", portion1.portion_format.get_effective().font_height)

    paragraph.portions[0].portion_format.font_height = 55

    print("Effektive Schriftgröße nach Festlegung der Schriftgröße für Abschnitt #0:")
    print("Abschnitt #0:", portion0.portion_format.get_effective().font_height)
    print("Abschnitt #1:", portion1.portion_format.get_effective().font_height)

    paragraph.portions[1].portion_format.font_height = 18

    print("Effektive Schriftgröße nach Festlegung der Schriftgröße für Abschnitt #1:")
    print("Abschnitt #0:", portion0.portion_format.get_effective().font_height)
    print("Abschnitt #1:", portion1.portion_format.get_effective().font_height)

    presentation.save("SetLocalFontHeightValues.pptx",slides.export.SaveFormat.PPTX)
```

## **Effektives Tabellen‑Füllformat abrufen**

Mit Aspose.Slides für Python via .NET können Sie das effektive Füllformat für verschiedene logische Teile einer Tabelle abrufen. Die Klasse [IFillFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/) enthält die effektiven Füllformat‑Eigenschaften. Beachten Sie, dass die Zellformatierung immer Vorrang vor der Zeilenformatierung hat, eine Zeile hat Vorrang vor einer Spalte und eine Spalte hat Vorrang vor der gesamten Tabelle.

Deshalb werden letztlich die Eigenschaften von [ICellFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icellformateffectivedata/) verwendet, um die Tabelle zu zeichnen. Das folgende Beispiel zeigt, wie man das effektive Füllformat für die verschiedenen Tabellenniveaus abruft:

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

**Wie kann ich erkennen, ob ich einen „Snapshot“ und nicht ein „Live‑Objekt“ erhalten habe, und wann sollte ich effektive Eigenschaften erneut auslesen?**

EffectiveData‑Objekte sind unveränderliche Snapshots der zum Zeitpunkt des Aufrufs berechneten Werte. Wenn Sie lokale oder geerbte Einstellungen der Shape ändern, rufen Sie die effektiven Daten erneut ab, um die aktualisierten Werte zu erhalten.

**Wirkt sich das Ändern des Layout‑/Master‑Slides auf bereits abgerufene effektive Eigenschaften aus?**

Ja, jedoch erst nach erneutem Auslesen. Ein bereits erhaltenes EffectiveData‑Objekt aktualisiert sich nicht selbst – fordern Sie es nach einer Layout‑ oder Master‑Änderung erneut an.

**Kann ich Werte über EffectiveData ändern?**

Nein. EffectiveData ist schreibgeschützt. Änderungen müssen an den lokalen Formatierungsobjekten (Shape/Text/3D usw.) vorgenommen werden; anschließend können Sie die effektiven Werte erneut abrufen.

**Was passiert, wenn eine Eigenschaft weder auf Shape‑Ebene, noch im Layout/Master und nicht in den globalen Einstellungen gesetzt ist?**

Der effektive Wert wird durch den Standardmechanismus (PowerPoint/Aspose.Slides‑Standardeinstellungen) bestimmt. Dieser aufgelöste Wert wird Teil des EffectiveData‑Snapshots.

**Kann ich aus einem effektiven Schriftwert erkennen, auf welcher Ebene Größe oder Schriftart festgelegt wurde?**

Nicht direkt. EffectiveData liefert den endgültigen Wert. Um die Herkunft zu ermitteln, prüfen Sie die lokalen Werte auf Portion/Paragraph/Text‑Frame‑Ebene sowie die Textstile im Layout/Master/Präsentation, um die erste explizite Definition zu finden.

**Warum sehen EffectiveData‑Werte manchmal genauso aus wie die lokalen Werte?**

Weil der lokale Wert letztlich endgültig war (keine höhere Vererbung nötig). In solchen Fällen stimmt der effektive Wert mit dem lokalen Wert überein.

**Wann sollte ich effektive Eigenschaften verwenden und wann nur mit lokalen arbeiten?**

Verwenden Sie EffectiveData, wenn Sie das „wie gerenderte“ Ergebnis nach Anwendung aller Vererbungen benötigen (z. B. zum Abgleichen von Farben, Einzügen oder Größen). Möchten Sie Formatierungen gezielt auf einer bestimmten Ebene ändern, bearbeiten Sie die lokalen Eigenschaften und lesen Sie bei Bedarf EffectiveData erneut, um das Ergebnis zu prüfen.