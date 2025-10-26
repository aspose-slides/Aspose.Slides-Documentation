---
title: Ermitteln Sie wirksame Formeigenschaften aus Präsentationen mit Python
linktitle: Wirksame Eigenschaften
type: docs
weight: 50
url: /de/python-net/developer-guide/presentation-content/powerpoint-shapes/shape-effective-properties/
keywords:
- Formeigenschaften
- Kameraeigenschaften
- Lichtsystem
- Fasenform
- Textrahmen
- Textstil
- Schriftgröße
- Füllformat
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Entdecken Sie, wie Aspose.Slides für Python via .NET wirksame Formeigenschaften berechnet und anwendet, um eine präzise PowerPoint- und OpenDocument‑Darstellung zu ermöglichen."
---

## **Übersicht**

In diesem Thema lernen Sie die Konzepte der **wirksamen** und **lokalen** Eigenschaften kennen. Wenn Werte direkt auf den folgenden Ebenen festgelegt werden:

1. In den Texteigenschaften des Textabschnitts auf der Folie.  
2. Im Textstil der Prototyp‑Form auf dem Layout‑ oder Master‑Slide (wenn der Textabschnitt einen hat).  
3. In den globalen Texteinstellungen der Präsentation.

werden diese Werte **lokale** Werte genannt. Auf jeder Ebene können **lokale** Werte definiert oder weggelassen werden. Wenn die Anwendung bestimmen muss, wie der Textabschnitt dargestellt werden soll, verwendet sie die **wirksamen** Werte. Sie können die wirksamen Werte erhalten, indem Sie die Methode `get_effective` auf dem lokalen Format aufrufen.

Das folgende Beispiel zeigt, wie man die wirksamen Werte für ein Textrahmen‑Format und ein Textabschnitt‑Format abruft.

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    local_text_frame_format = shape.text_frame.text_frame_format
    effective_text_frame_format = local_text_frame_format.get_effective()

    local_portion_format = shape.text_frame.paragraphs[0].portions[0].portion_format
    effective_portion_format = local_portion_format.get_effective()
```

## **Wirksame Kameraeigenschaften abrufen**

Aspose.Slides für Python via .NET ermöglicht das Abrufen der wirksamen Kameraeigenschaften. Die Klasse [ICameraEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icameraeffectivedata/) repräsentiert ein unveränderliches Objekt, das diese Eigenschaften enthält. Eine Instanz von [ICameraEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icameraeffectivedata/) wird über [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/) bereitgestellt, das die wirksamen Werte für die Klasse [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) liefert.

Das folgende Beispiel zeigt, wie man die wirksamen Kameraeigenschaften erhält:

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

	three_d_effective_data = shape.three_d_format.get_effective()

	print("= Wirksame Kameraeigenschaften =")
	print("Typ:", str(three_d_effective_data.camera.camera_type))
	print("Blickwinkel:", str(three_d_effective_data.camera.field_of_view_angle))
	print("Zoom:", str(three_d_effective_data.camera.zoom))
```

## **Wirksame Light‑Rig‑Eigenschaften abrufen**

Aspose.Slides für Python via .NET ermöglicht das Abrufen der wirksamen Eigenschaften eines Light‑Rigs. Die Klasse [ILightRigEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilightrigeffectivedata/) repräsentiert ein unveränderliches Objekt, das diese Eigenschaften enthält. Eine Instanz von [ILightRigEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilightrigeffectivedata/) wird über [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/) bereitgestellt, das die wirksamen Werte für die Klasse [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) liefert.

Das folgende Beispiel zeigt, wie man die wirksamen Light‑Rig‑Eigenschaften erhält:

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

	three_d_effective_data = shape.three_d_format.get_effective()

	print("= Wirksame Light‑Rig‑Eigenschaften =")
	print("Typ:", str(three_d_effective_data.light_rig.light_type))
	print("Richtung:", str(three_d_effective_data.light_rig.direction))
```

## **Wirksame Form‑Fasen‑Eigenschaften abrufen**

Aspose.Slides für Python via .NET ermöglicht das Abrufen der wirksamen Eigenschaften einer Form‑Fase. Die Klasse [IShapeBevelEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ishapebeveleffectivedata/) repräsentiert ein unveränderliches Objekt, das die Fasen‑Eigenschaften einer Form enthält. Eine Instanz von [IShapeBevelEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ishapebeveleffectivedata/) wird über [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/) bereitgestellt, das die wirksamen Werte für die Klasse [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) liefert.

Das folgende Beispiel zeigt, wie man die wirksamen Eigenschaften einer Form‑Fase erhält:

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

	three_d_effective_data = shape.three_d_format.get_effective()

	print("= Wirksame Fasen‑Eigenschaften der Formoberfläche =")
	print("Typ:", str(three_d_effective_data.bevel_top.bevel_type))
	print("Breite:", str(three_d_effective_data.bevel_top.width))
	print("Höhe:", str(three_d_effective_data.bevel_top.height))
```

## **Wirksame Textrahmen‑Eigenschaften abrufen**

Mit Aspose.Slides für Python via .NET können Sie die wirksamen Eigenschaften eines Textrahmens ermitteln. Die Klasse [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/itextframeformateffectivedata/) enthält die wirksamen Formatierungseigenschaften des Textrahmens.

Das folgende Beispiel zeigt, wie man die wirksamen Textrahmen‑Formatierungs‑Eigenschaften abruft:

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
	shape = presentation.slides[0].shapes[0]

	text_frame_format_effective_data = shape.text_frame.text_frame_format.get_effective()

	print("Verankerungstyp:", str(text_frame_format_effective_data.anchoring_type))
	print("Automatischer Anpassungstyp:", str(text_frame_format_effective_data.autofit_type))
	print("Vertikaler Texttyp:", str(text_frame_format_effective_data.text_vertical_type))
	print("Ränder")
	print("   Links:", str(text_frame_format_effective_data.margin_left))
	print("   Oben:", str(text_frame_format_effective_data.margin_top))
	print("   Rechts:", str(text_frame_format_effective_data.margin_right))
	print("   Unten:", str(text_frame_format_effective_data.margin_bottom))
```

## **Wirksame Textstil‑Eigenschaften abrufen**

Mit Aspose.Slides für Python via .NET können Sie die wirksamen Eigenschaften eines Textstils ermitteln. Die Klasse [ITextStyleEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/itextstyleeffectivedata/) enthält die wirksamen Textstil‑Eigenschaften.

Das folgende Beispiel zeigt, wie man die wirksamen Textstil‑Eigenschaften erhält:

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    effective_text_style = shape.text_frame.text_frame_format.text_style.get_effective()

    for i in range(8):
        effectiveStyleLevel = effective_text_style.get_level(i)
        print(f"= Wirksame Absatzformatierung für Stilstufe #{str(i)} =")

        print("Tiefe:", str(effectiveStyleLevel.depth))
        print("Einzug:", str(effectiveStyleLevel.indent))
        print("Ausrichtung:", str(effectiveStyleLevel.alignment))
        print("Schriftausrichtung:", str(effectiveStyleLevel.font_alignment))
```

## **Wirksame Schriftgröße ermitteln**

Mit Aspose.Slides für Python via .NET können Sie die wirksame Schriftgröße ermitteln. Das nachfolgende Beispiel demonstriert, wie sich die wirksame Schriftgröße eines Textabschnitts ändert, wenn Sie lokale Schriftgrößen‑Werte auf verschiedenen Ebenen der Präsentationsstruktur festlegen.

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

    print("Wirksame Schriftgröße unmittelbar nach Erstellung:")
    print("Abschnitt #0:", portion0.portion_format.get_effective().font_height)
    print("Abschnitt #1:", portion1.portion_format.get_effective().font_height)

    presentation.default_text_style.get_level(0).default_portion_format.font_height = 24

    print("Wirksame Schriftgröße nach Festlegung der Standard‑Schriftgröße für die gesamte Präsentation:")
    print("Abschnitt #0:", portion0.portion_format.get_effective().font_height)
    print("Abschnitt #1:", portion1.portion_format.get_effective().font_height)

    paragraph.paragraph_format.default_portion_format.font_height = 40

    print("Wirksame Schriftgröße nach Festlegung der Standard‑Schriftgröße für den Absatz:")
    print("Abschnitt #0:", portion0.portion_format.get_effective().font_height)
    print("Abschnitt #1:", portion1.portion_format.get_effective().font_height)

    paragraph.portions[0].portion_format.font_height = 55

    print("Wirksame Schriftgröße nach Festlegung der Schriftgröße für Abschnitt #0:")
    print("Abschnitt #0:", portion0.portion_format.get_effective().font_height)
    print("Abschnitt #1:", portion1.portion_format.get_effective().font_height)

    paragraph.portions[1].portion_format.font_height = 18

    print("Wirksame Schriftgröße nach Festlegung der Schriftgröße für Abschnitt #1:")
    print("Abschnitt #0:", portion0.portion_format.get_effective().font_height)
    print("Abschnitt #1:", portion1.portion_format.get_effective().font_height)

    presentation.save("SetLocalFontHeightValues.pptx",slides.export.SaveFormat.PPTX)
```

## **Wirksames Tabellen‑Füllformat ermitteln**

Mit Aspose.Slides für Python via .NET können Sie das wirksame Füllformat für verschiedene logische Teile einer Tabelle ermitteln. Die Klasse [IFillFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/) enthält die wirksamen Füllformat‑Eigenschaften. Beachten Sie, dass die Zellenformatierung immer Vorrang vor der Zeilenformatierung hat, eine Zeile Vorrang vor einer Spalte hat und eine Spalte Vorrang vor der gesamten Tabelle hat.

Daher werden letztlich die Eigenschaften von [ICellFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icellformateffectivedata/) verwendet, um die Tabelle zu zeichnen. Das folgende Beispiel zeigt, wie man das wirksame Füllformat für die verschiedenen Tabellenebenen erhält:

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

**Wie kann ich erkennen, ob ich einen „Snapshot“ bzw. ein „Live‑Objekt“ erhalten habe, und wann sollte ich wirksame Eigenschaften erneut auslesen?**

EffectiveData‑Objekte sind unveränderliche Schnappschüsse der zum Aufrufzeitpunkt berechneten Werte. Ändern Sie lokale oder geerbte Einstellungen der Form, rufen Sie die EffectiveData erneut ab, um die aktualisierten Werte zu erhalten.

**Wirkt sich das Ändern des Layout‑/Master‑Slides auf bereits abgerufene wirksame Eigenschaften aus?**

Ja, jedoch erst, nachdem Sie sie erneut ausgelesen haben. Ein bereits erhaltenes EffectiveData‑Objekt aktualisiert sich nicht selbst – fordern Sie es nach einer Layout‑ oder Master‑Änderung erneut an.

**Kann ich Werte über EffectiveData ändern?**

Nein. EffectiveData ist schreibgeschützt. Änderungen müssen an den lokalen Formatierungsobjekten (Form/Text/3D usw.) vorgenommen und anschließend die wirksamen Werte erneut abgerufen werden.

**Was passiert, wenn eine Eigenschaft weder auf Form‑, noch auf Layout‑/Master‑, noch auf globaler Ebene gesetzt ist?**

Der wirksame Wert wird durch den Standard‑Mechanismus (PowerPoint/Aspose.Slides‑Standardwerte) ermittelt. Dieser aufgelöste Wert wird Teil des EffectiveData‑Snapshots.

**Kann ich anhand eines wirksamen Schriftwertes erkennen, welche Ebene die Größe bzw. den Schriftschnitt bereitgestellt hat?**

Nicht direkt. EffectiveData liefert den endgültigen Wert. Um die Quelle zu ermitteln, prüfen Sie die lokalen Werte des Abschnitts/Absatzes/Textrahmens und die Textstile im Layout/Master/der Präsentation, um die erste explizite Definition zu finden.

**Warum sehen EffectiveData‑Werte manchmal identisch zu den lokalen aus?**

Weil der lokale Wert letztlich final war (keine höhere Vererbung erforderlich). In solchen Fällen stimmt der wirksame Wert mit dem lokalen Wert überein.

**Wann sollte ich wirksame Eigenschaften verwenden und wann nur lokale?**

Verwenden Sie EffectiveData, wenn Sie das „wie gerenderte“ Ergebnis nach vollständiger Vererbung benötigen (z. B. zum Angleichen von Farben, Einzügen oder Größen). Wenn Sie Formatierungen gezielt auf einer bestimmten Ebene ändern wollen, modifizieren Sie lokale Eigenschaften und lesen Sie ggf. anschließend EffectiveData erneut, um das Ergebnis zu prüfen.