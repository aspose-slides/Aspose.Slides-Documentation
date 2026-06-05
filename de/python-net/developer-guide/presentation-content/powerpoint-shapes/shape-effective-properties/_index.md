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
- Abgeschrägte Form
- Textfeld
- Textstil
- Schriftgröße
- Füllformat
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Entdecken Sie, wie Aspose.Slides für Python via .NET effektive Formeigenschaften berechnet und anwendet, um eine präzise PowerPoint‑Darstellung zu gewährleisten."
---
## **Übersicht**

Dieses Thema erklärt den Unterschied zwischen **lokalen** und **effektiven** Eigenschaften. Lokale Werte sind Werte, die direkt auf einer bestimmten Formatierungsebene festgelegt werden, z. B.:

1. Abschnittseigenschaften auf einer Folie.
1. Textstile von Prototypformen auf einem Layout‑ oder Master‑Folie, wenn die Form des Textfelds des Abschnitts einen hat.
1. Globale Texteinstellungen in einer Präsentation.

Lokale Werte können auf jeder Ebene definiert oder weggelassen werden. Wenn Aspose.Slides die endgültige „wie gerenderte“ Formatierung benötigt, löst es die Vererbungskette auf und gibt **effektive** Werte zurück. Sie können diese erhalten, indem Sie die Methode `get_effective` auf dem lokalen Formatobjekt aufrufen.

Das folgende Beispiel zeigt, wie man effektive Werte erhält. Es wird angenommen, dass die erste Form auf der ersten Folie ein [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/) mit einem Textfeld und mindestens einem Abschnitt ist.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    local_text_frame_format = shape.text_frame.text_frame_format
    effective_text_frame_format = local_text_frame_format.get_effective()

    paragraph = shape.text_frame.paragraphs[0]
    portion = paragraph.portions[0]
    local_portion_format = portion.portion_format
    effective_portion_format = local_portion_format.get_effective()
```

{{% alert color="primary" %}}
Effektive Formatierungsdaten stellen die aktuell berechnete Formatierung dar, nachdem die Vererbung angewendet wurde. In der aktuellen Implementierung können einige effektive Datenobjekte, wie z. B. [IPortionFormatEffectiveData](https://reference.aspose.com/slides/de/python-net/aspose.slides/iportionformateffectivedata/), intern zwischengespeichert werden. Ein erneuter Aufruf von `get_effective` nach einer Änderung der übergeordneten oder vererbten Formatierung kann die zwischengespeicherten Daten aktualisieren, und ein zuvor erhaltenes Objekt stellt möglicherweise nicht mehr den früheren Zustand dar. Wenn Sie effektive Werte für spätere Verwendung behalten müssen, kopieren Sie die erforderlichen Eigenschaften, wie Schriftgröße, Füllfarbe, Schriftstil oder Ausrichtung, in Ihr eigenes Datenobjekt.
{{% /alert %}}

## **Effektive Eigenschaften einer Kamera abrufen**

Aspose.Slides ermöglicht das Abrufen effektiver Eigenschaften einer Kamera. Der Typ [ICameraEffectiveData](https://reference.aspose.com/slides/de/python-net/aspose.slides/icameraeffectivedata/) stellt ein unveränderliches Objekt dar, das effektive Kameraeigenschaften enthält. Eine [ICameraEffectiveData](https://reference.aspose.com/slides/de/python-net/aspose.slides/icameraeffectivedata/)‑Instanz wird über [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/de/python-net/aspose.slides/ithreedformateffectivedata/) bereitgestellt, das effektive Werte für [ThreeDFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides/threedformat/) liefert.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    camera = three_d_effective_data.camera

    camera_type = camera.camera_type
    field_of_view_angle = camera.field_of_view_angle
    zoom = camera.zoom

    print("= Effective camera properties =")
    print("Type: " + str(camera_type))
    print("Field of view: " + str(field_of_view_angle))
    print("Zoom: " + str(zoom))
```

## **Effektive Eigenschaften einer Lichtanlage abrufen**

Aspose.Slides ermöglicht das Abrufen effektiver Eigenschaften einer Lichtanlage. Der Typ [ILightRigEffectiveData](https://reference.aspose.com/slides/de/python-net/aspose.slides/ilightrigeffectivedata/) stellt ein unveränderliches Objekt dar, das effektive Eigenschaften der Lichtanlage enthält. Eine [ILightRigEffectiveData](https://reference.aspose.com/slides/de/python-net/aspose.slides/ilightrigeffectivedata/)‑Instanz wird über [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/de/python-net/aspose.slides/ithreedformateffectivedata/) bereitgestellt, das effektive Werte für [ThreeDFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides/threedformat/) liefert.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    light_rig = three_d_effective_data.light_rig

    light_type = light_rig.light_type
    direction = light_rig.direction

    print("= Effective light rig properties =")
    print("Type: " + str(light_type))
    print("Direction: " + str(direction))
```

## **Effektive Eigenschaften einer Abschrägung einer Form**

Aspose.Slides ermöglicht das Abrufen effektiver Eigenschaften einer Formabschrägung. Der Typ [IShapeBevelEffectiveData](https://reference.aspose.com/slides/de/python-net/aspose.slides/ishapebeveleffectivedata/) stellt ein unveränderliches Objekt dar, das effektive Flächenrelief‑Eigenschaften für eine Form enthält. Eine [IShapeBevelEffectiveData](https://reference.aspose.com/slides/de/python-net/aspose.slides/ishapebeveleffectivedata/)‑Instanz wird über [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/de/python-net/aspose.slides/ithreedformateffectivedata/) bereitgestellt, das effektive Werte für [ThreeDFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides/threedformat/) liefert.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    top_bevel = three_d_effective_data.bevel_top

    bevel_type = top_bevel.bevel_type
    bevel_width = top_bevel.width
    bevel_height = top_bevel.height

    print("= Effective shape's top face relief properties =")
    print("Type: " + str(bevel_type))
    print("Width: " + str(bevel_width))
    print("Height: " + str(bevel_height))
```

## **Effektive Eigenschaften eines Textfelds abrufen**

Mit Aspose.Slides können Sie effektive Eigenschaften eines Textfelds erhalten. Der Typ [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/de/python-net/aspose.slides/itextframeformateffectivedata/) enthält effektive Formatierungseigenschaften des Textfelds.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    text_frame_format = shape.text_frame.text_frame_format
    effective_text_frame_format = text_frame_format.get_effective()

    anchoring_type = effective_text_frame_format.anchoring_type
    autofit_type = effective_text_frame_format.autofit_type
    text_vertical_type = effective_text_frame_format.text_vertical_type
    margin_left = effective_text_frame_format.margin_left
    margin_top = effective_text_frame_format.margin_top
    margin_right = effective_text_frame_format.margin_right
    margin_bottom = effective_text_frame_format.margin_bottom

    print("Anchoring type: " + str(anchoring_type))
    print("Autofit type: " + str(autofit_type))
    print("Text vertical type: " + str(text_vertical_type))
    print("Margins")
    print("   Left: " + str(margin_left))
    print("   Top: " + str(margin_top))
    print("   Right: " + str(margin_right))
    print("   Bottom: " + str(margin_bottom))
```

## **Effektive Eigenschaften eines Textstils abrufen**

Mit Aspose.Slides können Sie effektive Eigenschaften eines Textstils erhalten. Der Typ [ITextStyleEffectiveData](https://reference.aspose.com/slides/de/python-net/aspose.slides/itextstyleeffectivedata/) enthält effektive Eigenschaften des Textstils.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    text_frame_format = shape.text_frame.text_frame_format
    text_style = text_frame_format.text_style
    effective_text_style = text_style.get_effective()
    level_count = 9

    for level_index in range(level_count):
        effective_style_level = effective_text_style.get_level(level_index)
        depth = effective_style_level.depth
        indent = effective_style_level.indent
        alignment = effective_style_level.alignment
        font_alignment = effective_style_level.font_alignment

        print("= Effective paragraph formatting for style level #" + str(level_index) + " =")

        print("Depth: " + str(depth))
        print("Indent: " + str(indent))
        print("Alignment: " + str(alignment))
        print("Font alignment: " + str(font_alignment))
```

## **Den effektiven Schriftgrößenwert abrufen**

Mit Aspose.Slides können Sie die effektive Schriftgröße ermitteln. Der folgende Code zeigt, wie sich die effektive Schriftgröße eines Abschnitts ändert, nachdem lokale Schriftgrößenwerte auf verschiedenen Präsentations‑Strukturebenen festgelegt wurden.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    auto_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 75, False)
    auto_shape.add_text_frame("")

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    first_portion = slides.Portion("Sample text with first portion")
    second_portion = slides.Portion(" and second portion.")

    paragraph.portions.add(first_portion)
    paragraph.portions.add(second_portion)

    print("Effective font height just after creation:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    default_text_style_level = presentation.default_text_style.get_level(0)
    default_text_style_level.default_portion_format.font_height = 24

    print("Effective font height after setting the presentation default font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    paragraph.paragraph_format.default_portion_format.font_height = 40

    print("Effective font height after setting paragraph default font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    first_portion.portion_format.font_height = 55

    print("Effective font height after setting portion #0 font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    second_portion.portion_format.font_height = 18

    print("Effective font height after setting portion #1 font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    presentation.save("SetLocalFontHeightValues.pptx", slides.export.SaveFormat.PPTX)
```

## **Effektives Füllformat für eine Tabelle abrufen**

Mit Aspose.Slides können Sie effektive Füllformatierungen für verschiedene Tabellenteile erhalten. Der Typ [IFillFormatEffectiveData](https://reference.aspose.com/slides/de/python-net/aspose.slides/ifillformateffectivedata/) enthält effektive Füllformatierungs‑Eigenschaften. Zellenformatierung hat höhere Priorität als Zeilenformatierung, Zeilenformatierung hat höhere Priorität als Spaltenformatierung, und Spaltenformatierung hat höhere Priorität als die Gesamttabelle.

Infolgedessen werden die Eigenschaften von [ICellFormatEffectiveData](https://reference.aspose.com/slides/de/python-net/aspose.slides/icellformateffectivedata/) verwendet, um die Tabellenzelle zu zeichnen. Der folgende Code zeigt, wie man effektive Füllformatierung für verschiedene Tabellenteile erhalten kann. Es wird angenommen, dass die erste Form auf der ersten Folie eine [Table](https://reference.aspose.com/slides/de/python-net/aspose.slides/table/) ist.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    table = presentation.slides[0].shapes[0]
    first_row = table.rows[0]
    first_column = table.columns[0]
    first_cell = first_row[0]

    table_format_effective = table.table_format.get_effective()
    row_format_effective = first_row.row_format.get_effective()
    column_format_effective = first_column.column_format.get_effective()
    cell_format_effective = first_cell.cell_format.get_effective()

    table_fill_format_effective = table_format_effective.fill_format
    row_fill_format_effective = row_format_effective.fill_format
    column_fill_format_effective = column_format_effective.fill_format
    cell_fill_format_effective = cell_format_effective.fill_format
```

## **FAQ**

**Gibt `get_effective` einen Schnappschuss zurück?**

Nicht immer. Effektive Daten stellen die berechnete Formatierung nach Anwendung der Vererbung dar, jedoch können einige effektive Datenobjekte intern zwischengespeichert werden. Ein nachfolgender Aufruf von `get_effective` kann die Formatierung neu berechnen und die zwischengespeicherten Daten aktualisieren, sodass ein zuvor erhaltenes Objekt nicht als dauerhafter Schnappschuss angesehen werden sollte.

**Wann sollte ich effektive Eigenschaften erneut auslesen?**

Rufen Sie `get_effective` erneut auf, nachdem Sie lokale Formatierungen, übergeordnete Stile, Layout‑Formatierungen, Master‑Formatierungen oder Präsentations‑Standardeinstellungen geändert haben. Der nächste Aufruf wertet die Formatierungshierarchie neu aus und gibt das aktuelle effektive Ergebnis zurück.

**Wirkt sich das Ändern oder Entfernen einer Layout‑/Master‑Folie auf bereits abgerufene effektive Eigenschaften aus?**

Ja, jedoch wird die Änderung erst beim nächsten Aufruf von `get_effective` berücksichtigt. Wenn eine übergeordnete Formatierungsquelle geändert oder entfernt wird, können zuvor erhaltene effektive Daten veraltet sein. Sobald `get_effective` erneut aufgerufen wird, bewertet Aspose.Slides den Formatierungsbaum neu und die resultierenden Schriftarten, Farben, Größen oder andere Werte können sich ändern.

**Kann ich Werte über effektive Datenobjekte ändern?**

Nein. Effektive Datenobjekte geben nur berechnete Werte wieder. Änderungen sollten an den lokalen Formatierungsobjekten vorgenommen werden, danach können die effektiven Werte erneut abgefragt werden.

**Was passiert, wenn ein Property weder auf Form‑Ebene, noch im Layout/Master, noch in den globalen Einstellungen gesetzt ist?**

Der effektive Wert wird durch den Standard‑Mechanismus bestimmt, der die Vorgaben von PowerPoint und Aspose.Slides umfasst. Dieser ermittelte Wert wird Teil der aktuellen effektiven Daten.

**Kann ich aus einem effektiven Schriftwert erkennen, welche Ebene Größe oder Schriftart bereitgestellt hat?**

Nicht direkt. Effektive Daten geben nur den endgültigen Wert zurück. Um die Quelle zu ermitteln, prüfen Sie die lokalen Werte im Abschnitt, Absatz, Textfeld und den Textstilen auf Layout‑, Master‑ und Präsentationsebene, um zu sehen, wo die erste explizite Definition vorkommt.

**Warum sehen effektive Werte manchmal identisch mit den lokalen aus?**

Weil der lokale Wert letztlich endgültig war (keine höhere Vererbung erforderlich war). In solchen Fällen entspricht der effektive Wert dem lokalen.

**Wann sollte ich effektive Eigenschaften verwenden und wann nur mit lokalen arbeiten?**

Verwenden Sie effektive Daten, wenn Sie das „wie gerenderte“ Ergebnis nach Anwendung aller Vererbungen benötigen, z. B. zum Abstimmen von Farben, Einzügen oder Größen. Wenn Sie diese Werte unabhängig von späteren Formatierungsänderungen bewahren müssen, kopieren Sie die erforderlichen Eigenschaften in ein eigenes Objekt. Wenn Sie die Formatierung auf einer bestimmten Ebene ändern möchten, passen Sie die lokalen Eigenschaften an und lesen Sie ggf. die effektiven Daten erneut aus, um das Ergebnis zu überprüfen.