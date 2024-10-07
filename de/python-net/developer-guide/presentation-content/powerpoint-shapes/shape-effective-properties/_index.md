---
title: Effektive Eigenschaften von Formen
type: docs
weight: 50
url: /python-net/shape-effective-properties/
keywords: "Formeigenschaften, Kameraeinstellungen, Lichtrig, Fasenform, Textfeld, Textstil, Schriftgrößenwert, Füllformat für Tabelle, PowerPoint-Präsentation, Python, Aspose.Slides für Python via .NET"
description: "Erhalten Sie effektive Formeigenschaften in PowerPoint-Präsentationen in Python"
---

In diesem Thema werden wir über **effektive** und **lokale** Eigenschaften sprechen. Wenn wir Werte direkt auf diesen Ebenen festlegen

1. In Abschnittseigenschaften auf der Folie des Abschnitts.
1. In Prototyp-Form-Textstil auf Layout- oder Masterfolie (wenn das Textfeldform des Abschnitts eines hat).
1. In den globalen Texteinstellungen der Präsentation.

dann werden diese Werte als **lokale** Werte bezeichnet. Auf jeder Ebene können **lokale** Werte definiert oder weggelassen werden. Aber schließlich, wenn es darum geht, den Moment zu erreichen, in dem die Anwendung wissen muss, wie der Abschnitt aussehen soll, verwendet sie **effektive** Werte. Sie können effektive Werte erhalten, indem Sie die Methode **getEffective()** vom lokalen Format verwenden.

Das folgende Beispiel zeigt, wie man effektive Werte erhält.

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation1.pptx") as pres:
    shape = pres.slides[0].shapes[0]

    localTextFrameFormat = shape.text_frame.text_frame_format
    effectiveTextFrameFormat = localTextFrameFormat.get_effective()

    localPortionFormat = shape.text_frame.paragraphs[0].portions[0].portion_format
    effectivePortionFormat = localPortionFormat.get_effective()
```



## **Effektive Eigenschaften der Kamera abrufen**
Aspose.Slides für Python via .NET ermöglicht es Entwicklern, effektive Eigenschaften der Kamera zu erhalten. Zu diesem Zweck wurde die Klasse **CameraEffectiveData** in Aspose.Slides hinzugefügt. Die Klasse CameraEffectiveData stellt ein unveränderliches Objekt dar, das die effektiven Kameraeigenschaften enthält. Eine Instanz der Klasse **CameraEffectiveData** wird als Teil der Klasse **ThreeDFormatEffectiveData** verwendet, die ein Paar effektiver Werte für die ThreeDFormat-Klasse ist.

Das folgende Codebeispiel zeigt, wie man effektive Eigenschaften für die Kamera erhält.

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation1.pptx") as pres:
	threeDEffectiveData = pres.slides[0].shapes[0].three_d_format.get_effective()

	print("= Effektive Kameraeigenschaften =")
	print("Typ: " + str(threeDEffectiveData.camera.camera_type))
	print("Sichtfeld: " + str(threeDEffectiveData.camera.field_of_view_angle))
	print("Zoom: " + str(threeDEffectiveData.camera.zoom))
```


## **Effektive Eigenschaften der Lichtrig abrufen**
Aspose.Slides für Python via .NET ermöglicht es Entwicklern, effektive Eigenschaften der Lichtrig zu erhalten. Zu diesem Zweck wurde die Klasse **LightRigEffectiveData** in Aspose.Slides hinzugefügt. Die Klasse LightRigEffectiveData stellt ein unveränderliches Objekt dar, das die effektiven Eigenschaften der Lichtrig enthält. Eine Instanz der Klasse **LightRigEffectiveData** wird als Teil der Klasse **ThreeDFormatEffectiveData** verwendet, die ein Paar effektiver Werte für die ThreeDFormat-Klasse ist.

Das folgende Codebeispiel zeigt, wie man effektive Eigenschaften für die Lichtrig erhält.

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation1.pptx") as pres:
	threeDEffectiveData = pres.slides[0].shapes[0].three_d_format.get_effective()

	print("= Effektive Lichtrig-Eigenschaften =")
	print("Typ: " + str(threeDEffectiveData.light_rig.light_type))
	print("Richtung: " + str(threeDEffectiveData.light_rig.direction))
```


## **Effektive Eigenschaften der Fasenform abrufen**
Aspose.Slides für Python via .NET ermöglicht es Entwicklern, effektive Eigenschaften der Fasenform zu erhalten. Zu diesem Zweck wurde die Klasse **ShapeBevelEffectiveData** in Aspose.Slides hinzugefügt. Die Klasse ShapeBevelEffectiveData stellt ein unveränderliches Objekt dar, das die effektiven Gesichtsrelief-Eigenschaften der Form enthält. Eine Instanz der Klasse **ShapeBevelEffectiveData** wird als Teil der Klasse **ThreeDFormatEffectiveData** verwendet, die ein Paar effektiver Werte für die ThreeDFormat-Klasse ist.

Das folgende Codebeispiel zeigt, wie man effektive Eigenschaften für die Fasenform erhält.

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation1.pptx") as pres:
	threeDEffectiveData = pres.slides[0].shapes[0].three_d_format.get_effective()

	print("= Effektive oberen Gesichtsrelief-Eigenschaften der Form =")
	print("Typ: " + str(threeDEffectiveData.bevel_top.bevel_type))
	print("Breite: " + str(threeDEffectiveData.bevel_top.width))
	print("Höhe: " + str(threeDEffectiveData.bevel_top.height))
```



## **Effektive Eigenschaften des Textfelds abrufen**
Mit Aspose.Slides für Python via .NET können Sie effektive Eigenschaften des Textfelds abrufen. Zu diesem Zweck wurde die Klasse **TextFrameFormatEffectiveData** in Aspose.Slides hinzugefügt, die effektive Formatierungseigenschaften des Textfelds enthält.

Das folgende Codebeispiel zeigt, wie man effektive Formatierungseigenschaften des Textfelds erhält.

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation1.pptx") as pres:
	shape = pres.slides[0].shapes[0]

	textFrameFormat = shape.text_frame.text_frame_format
	effectiveTextFrameFormat = textFrameFormat.get_effective()


	print("Ankerungsart: " + str(effectiveTextFrameFormat.anchoring_type))
	print("Autofit-Typ: " + str(effectiveTextFrameFormat.autofit_type))
	print("Textvertikaltyp: " + str(effectiveTextFrameFormat.text_vertical_type))
	print("Ränder")
	print("   Links: " + str(effectiveTextFrameFormat.margin_left))
	print("   Oben: " + str(effectiveTextFrameFormat.margin_top))
	print("   Rechts: " + str(effectiveTextFrameFormat.margin_right))
	print("   Unten: " + str(effectiveTextFrameFormat.margin_bottom))
```



## **Effektive Eigenschaften des Textstils abrufen**
Mit Aspose.Slides für Python via .NET können Sie effektive Eigenschaften des Textstils abrufen. Zu diesem Zweck wurde die Klasse **TextStyleEffectiveData** in Aspose.Slides hinzugefügt, die effektive Eigenschaften des Textstils enthält.

Das folgende Codebeispiel zeigt, wie man effektive Eigenschaften des Textstils erhält.

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation1.pptx") as pres:
    shape = pres.slides[0].shapes[0]

    effectiveTextStyle = shape.text_frame.text_frame_format.text_style.get_effective()

    for i in range(8):
        effectiveStyleLevel = effectiveTextStyle.get_level(i)
        print("= Effektive Absatzformatierung für Stil-Ebene #" + str(i) + " =")

        print("Tiefe: " + str(effectiveStyleLevel.depth))
        print("Einzug: " + str(effectiveStyleLevel.indent))
        print("Ausrichtung: " + str(effectiveStyleLevel.alignment))
        print("Schriftausrichtung: " + str(effectiveStyleLevel.font_alignment))

```


## **Effektiven Schriftgrößenwert abrufen**
Mit Aspose.Slides für Python via .NET können Sie effektive Eigenschaften der Schriftgröße abrufen. Hier ist der Code, der zeigt, wie sich der effektive Schriftgrößenwert des Abschnitts ändert, nachdem lokale Schriftgrößenwerte auf verschiedenen Ebenen der Präsentationsstruktur festgelegt wurden.

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    newShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 75, False)
    newShape.add_text_frame("")
    newShape.text_frame.paragraphs[0].portions.clear()

    portion0 = slides.Portion("Beispieltext mit erstem Abschnitt")
    portion1 = slides.Portion(" und zweitem Abschnitt.")

    newShape.text_frame.paragraphs[0].portions.add(portion0)
    newShape.text_frame.paragraphs[0].portions.add(portion1)

    print("Effektive Schriftgröße sofort nach der Erstellung:")
    print("Abschnitt #0: " + str(portion0.portion_format.get_effective().font_height))
    print("Abschnitt #1: " + str(portion1.portion_format.get_effective().font_height))

    pres.default_text_style.get_level(0).default_portion_format.font_height = 24

    print("Effektive Schriftgröße nach Festlegung der Standard-Schriftgröße für die gesamte Präsentation:")
    print("Abschnitt #0: " + str(portion0.portion_format.get_effective().font_height))
    print("Abschnitt #1: " + str(portion1.portion_format.get_effective().font_height))

    newShape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 40

    print("Effektive Schriftgröße nach Festlegung der Standard-Schriftgröße für den Absatz:")
    print("Abschnitt #0: " + str(portion0.portion_format.get_effective().font_height))
    print("Abschnitt #1: " + str(portion1.portion_format.get_effective().font_height))

    newShape.text_frame.paragraphs[0].portions[0].portion_format.font_height = 55

    print("Effektive Schriftgröße nach Festlegung der Schriftgröße des Abschnitts #0:")
    print("Abschnitt #0: " + str(portion0.portion_format.get_effective().font_height))
    print("Abschnitt #1: " + str(portion1.portion_format.get_effective().font_height))

    newShape.text_frame.paragraphs[0].portions[1].portion_format.font_height = 18

    print("Effektive Schriftgröße nach Festlegung der Schriftgröße des Abschnitts #1:")
    print("Abschnitt #0: " + str(portion0.portion_format.get_effective().font_height))
    print("Abschnitt #1: " + str(portion1.portion_format.get_effective().font_height))

    pres.save("SetLocalFontHeightValues.pptx",slides.export.SaveFormat.PPTX)
```


## **Effektives Füllformat für Tabelle abrufen**
Mit Aspose.Slides für Python via .NET können Sie effektive Füllformatierungen für verschiedene logische Teile einer Tabelle abrufen. Zu diesem Zweck wurde das Interface **IFillFormatEffectiveData** in Aspose.Slides hinzugefügt, das effektive Füllformatierungseigenschaften enthält. Bitte beachten Sie, dass die Zellenformatierung immer eine höhere Priorität als die Zeilenformatierung hat, eine Zeile hat eine höhere Priorität als eine Spalte und eine Spalte hat eine höhere Priorität als die gesamte Tabelle.

Somit werden schließlich die Eigenschaften von **CellFormatEffectiveData** immer verwendet, um die Tabelle zu zeichnen. Das folgende Codebeispiel zeigt, wie man effektive Füllformatierungen für verschiedene logische Teile einer Tabelle erhält.

```py
import aspose.slides as slides

with slides.Presentation(path + "pres.pptx") as pres:
	tbl = pres.slides[0].shapes[0]
	tableFormatEffective = tbl.table_format.get_effective()
	rowFormatEffective = tbl.rows[0].row_format.get_effective()
	columnFormatEffective = tbl.columns[0].column_format.get_effective()
	cellFormatEffective = tbl[0, 0].cell_format.get_effective()

	tableFillFormatEffective = tableFormatEffective.fill_format
	rowFillFormatEffective = rowFormatEffective.fill_format
	columnFillFormatEffective = columnFormatEffective.fill_format
	cellFillFormatEffective = cellFormatEffective.fill_format
```