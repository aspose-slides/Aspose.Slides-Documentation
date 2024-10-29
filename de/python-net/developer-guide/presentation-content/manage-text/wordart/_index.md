---
title: WordArt
type: docs
weight: 110
url: /de/python-net/wordart/
keywords: "WordArt, Wort Kunst, WordArt erstellen, WordArt Vorlage, WordArt Effekte, Schatteneffekte, Anzeigeeffekte, Glüheffekte, WordArt Transformationen, 3D Effekte, äußere Schatteneffekte, innere Schatteneffekte, Python, Aspose.Slides für Python über .NET"
description: "Fügen Sie WordArt und Effekte in PowerPoint-Präsentationen in Python oder Aspose.Slides für Python über .NET hinzu, bearbeiten Sie sie und verwalten Sie sie."
---

## **Was ist WordArt?**
WordArt oder Wort Kunst ist eine Funktion, die es Ihnen ermöglicht, Texteffekte anzuwenden, um sie hervorzuheben. Mit WordArt können Sie beispielsweise einen Text umranden oder ihn mit einer Farbe (oder einem Farbverlauf) füllen, 3D-Effekte hinzufügen usw. Sie können auch die Form eines Textes kippen, biegen und dehnen.

{{% alert color="primary" %}} 

WordArt ermöglicht es Ihnen, einen Text wie ein grafisches Objekt zu behandeln. WordArt besteht aus Effekten oder speziellen Modifikationen, die auf Texte angewendet werden, um sie attraktiver oder auffälliger zu machen.

{{% /alert %}} 

**WordArt in Microsoft PowerPoint**

Um WordArt in Microsoft PowerPoint zu verwenden, müssen Sie eine der vordefinierten WordArt-Vorlagen auswählen. Eine WordArt-Vorlage ist eine Reihe von Effekten, die auf einen Text oder seine Form angewendet werden.

**WordArt in Aspose.Slides**

In Aspose.Slides für Python über .NET 20.10 haben wir die Unterstützung für WordArt implementiert und die Funktion in den anschließenden Versionen von Aspose.Slides für Python über .NET verbessert.

Mit Aspose.Slides für Python über .NET können Sie einfach Ihre eigene WordArt-Vorlage (einen Effekt oder eine Kombination von Effekten) in Python erstellen und sie auf Texte anwenden.

## Erstellen einer einfachen WordArt-Vorlage und Anwenden auf einen Text

**Verwendung von Aspose.Slides** 

Zuerst erstellen wir einen einfachen Text mit diesem Python-Code: 

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    textFrame = autoShape.text_frame

    portion = textFrame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"

    pres.save("wordart-1.pptx", slides.export.SaveFormat.PPTX)
```
Jetzt setzen wir die Schriftgröße des Textes auf einen größeren Wert, um den Effekt durch diesen Code auffälliger zu machen:

```py 
    fontData = slides.FontData("Arial Black")
    portion.portion_format.latin_font = fontData
    portion.portion_format.font_height = 36
```

**Verwendung von Microsoft PowerPoint**

Gehen Sie zu dem WordArt-Effekte-Menü in Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Aus dem Menü auf der rechten Seite können Sie einen vordefinierten WordArt-Effekt auswählen. Aus dem Menü auf der linken Seite können Sie die Einstellungen für eine neue WordArt festlegen.

Dies sind einige der verfügbaren Parameter oder Optionen:

![todo:image_alt_text](image-20200930114015-3.png)

**Verwendung von Aspose.Slides**

Hier wenden wir die SmallGrid-Musterfarbe auf den Text an und fügen einen schwarzen Textrahmen mit einer Breite von 1 hinzu, indem wir diesen Code verwenden:

```py 
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = draw.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = draw.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.SMALL_GRID
                
    portion.portion_format.line_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.line_format.fill_format.solid_fill_color.color = draw.Color.black
```

Der resultierende Text:

![todo:image_alt_text](image-20200930114108-4.png)

## Anwenden anderer WordArt-Effekte

**Verwendung von Microsoft PowerPoint**

Von der Benutzeroberfläche des Programms aus können Sie diese Effekte auf einen Text, Textblock, Form oder ähnliches Element anwenden:

![todo:image_alt_text](image-20200930114129-5.png)

Zum Beispiel können Schatten-, Reflexions- und Glüheffekte auf einen Text angewendet werden; 3D-Format- und 3D-Rotations-Effekte können auf einen Textblock angewendet werden; die Weiche Kanten-Eigenschaft kann auf ein Formenobjekt angewendet werden (sie hat immer noch einen Effekt, wenn keine 3D-Format-Eigenschaft gesetzt ist).

### Anwenden von Schatteneffekten

Hier beabsichtigen wir, die Eigenschaften nur in Bezug auf einen Text festzulegen. Wir wenden den Schatteneffekt auf einen Text an, indem wir diesen Code in Python verwenden:

```py 
    portion.portion_format.effect_format.enable_outer_shadow_effect()
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.black
    portion.portion_format.effect_format.outer_shadow_effect.scale_horizontal = 100
    portion.portion_format.effect_format.outer_shadow_effect.scale_vertical = 65
    portion.portion_format.effect_format.outer_shadow_effect.blur_radius = 4.73
    portion.portion_format.effect_format.outer_shadow_effect.direction = 230
    portion.portion_format.effect_format.outer_shadow_effect.distance = 2
    portion.portion_format.effect_format.outer_shadow_effect.skew_horizontal = 30
    portion.portion_format.effect_format.outer_shadow_effect.skew_vertical = 0
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.32)
```

Die Aspose.Slides-API unterstützt drei Arten von Schatten: OuterShadow, InnerShadow und PresetShadow.

Mit PresetShadow können Sie einen Schatten für einen Text anwenden (unter Verwendung von vordefinierten Werten).

**Verwendung von Microsoft PowerPoint**

In PowerPoint können Sie eine Art von Schatten verwenden. Hier ist ein Beispiel:

![todo:image_alt_text](image-20200930114225-6.png)

**Verwendung von Aspose.Slides**

Aspose.Slides ermöglicht es Ihnen tatsächlich, zwei Arten von Schatten gleichzeitig anzuwenden: InnerShadow und PresetShadow.

**Hinweise:**

- Wenn OuterShadow und PresetShadow zusammen verwendet werden, wird nur der OuterShadow-Effekt angewendet.
- Wenn OuterShadow und InnerShadow gleichzeitig verwendet werden, hängt der resultierende oder angewandte Effekt von der PowerPoint-Version ab. Zum Beispiel, in PowerPoint 2013 wird der Effekt verdoppelt. Aber in PowerPoint 2007 wird der OuterShadow-Effekt angewendet.

### Anwenden von Anzeige auf Texte

Wir fügen die Anzeige zu dem Text durch dieses Python-Codebeispiel hinzu:

```py 
    portion.portion_format.effect_format.enable_reflection_effect()
    portion.portion_format.effect_format.reflection_effect.blur_radius = 0.5 
    portion.portion_format.effect_format.reflection_effect.distance = 4.72 
    portion.portion_format.effect_format.reflection_effect.start_pos_alpha = 0 
    portion.portion_format.effect_format.reflection_effect.end_pos_alpha = 60
    portion.portion_format.effect_format.reflection_effect.direction = 90 
    portion.portion_format.effect_format.reflection_effect.scale_horizontal = 100 
    portion.portion_format.effect_format.reflection_effect.scale_vertical = -100
    portion.portion_format.effect_format.reflection_effect.start_reflection_opacity = 60
    portion.portion_format.effect_format.reflection_effect.end_reflection_opacity = 0.9
    portion.portion_format.effect_format.reflection_effect.rectangle_align = slides.RectangleAlignment.BOTTOM_LEFT  
```

### Anwenden des Glüheffekts auf Texte

Wir wenden den Glüheffekt auf den Text an, um ihn zum Leuchten oder Hervorstechen zu bringen, indem wir diesen Code verwenden:

```py 
    portion.portion_format.effect_format.enable_glow_effect()
    portion.portion_format.effect_format.glow_effect.color.r = 255
    portion.portion_format.effect_format.glow_effect.color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.54)
    portion.portion_format.effect_format.glow_effect.radius = 7
```

Das Ergebnis der Operation:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Sie können die Parameter für Schatten, Anzeige und Glühen ändern. Die Effekteigenschaften werden separat für jeden Teil des Textes festgelegt. 

{{% /alert %}} 

### Verwendung von Transformationen in WordArt

Wir verwenden die Transform-Eigenschaft (die dem gesamten Textblock innewohnt) durch diesen Code:
```py 
textFrame.text_frame_format.transform = slides.TextShapeType.ARCH_UP_POUR
```

Das Ergebnis:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Sowohl Microsoft PowerPoint als auch Aspose.Slides für Python über .NET bieten eine bestimmte Anzahl vordefinierter Transformationsarten. 

{{% /alert %}} 

**Verwendung von PowerPoint**

Um auf vordefinierte Transformationsarten zuzugreifen, gehen Sie zu: **Format** -> **TextEffekt** -> **Transformieren**

**Verwendung von Aspose.Slides**

Um einen Transformationstyp auszuwählen, verwenden Sie die TextShapeType-Enum. 

### Anwenden von 3D-Effekten auf Texte und Formen

Wir setzen einen 3D-Effekt auf einen Textblock mit diesem Beispielcode:

```py 
    autoShape.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    autoShape.three_d_format.bevel_bottom.height = 10.5
    autoShape.three_d_format.bevel_bottom.width = 10.5

    autoShape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    autoShape.three_d_format.bevel_top.height = 12.5
    autoShape.three_d_format.bevel_top.width = 11

    autoShape.three_d_format.extrusion_color.color = draw.Color.orange
    autoShape.three_d_format.extrusion_height = 6

    autoShape.three_d_format.contour_color.color = draw.Color.dark_red
    autoShape.three_d_format.contour_width = 1.5

    autoShape.three_d_format.depth = 3

    autoShape.three_d_format.material = slides.MaterialPresetType.PLASTIC

    autoShape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    autoShape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    autoShape.three_d_format.light_rig.set_rotation(0, 0, 40)

    autoShape.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

Der resultierende Text und seine Form:

![todo:image_alt_text](image-20200930114816-9.png)

Wir wenden einen 3D-Effekt auf den Text mit diesem Python-Code an:

```py 
    textFrame.text_frame_format.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    textFrame.text_frame_format.three_d_format.bevel_bottom.height = 3.5
    textFrame.text_frame_format.three_d_format.bevel_bottom.width = 3.5

    textFrame.text_frame_format.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    textFrame.text_frame_format.three_d_format.bevel_top.height = 4
    textFrame.text_frame_format.three_d_format.bevel_top.width = 4

    textFrame.text_frame_format.three_d_format.extrusion_color.color = draw.Color.orange
    textFrame.text_frame_format.three_d_format.extrusion_height= 6

    textFrame.text_frame_format.three_d_format.contour_color.color = draw.Color.dark_red
    textFrame.text_frame_format.three_d_format.contour_width = 1.5

    textFrame.text_frame_format.three_d_format.depth= 3

    textFrame.text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC

    textFrame.text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    textFrame.text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    textFrame.text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)

    textFrame.text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

Das Ergebnis der Operation:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

Die Anwendung von 3D-Effekten auf Texte oder deren Formen und die Interaktionen zwischen den Effekten basieren auf bestimmten Regeln.

Betrachten Sie eine Szene für einen Text und die Form, die diesen Text enthält. Der 3D-Effekt enthält die 3D-Objektdarstellung und die Szene, in der das Objekt platziert wurde.

- Wenn die Szene sowohl für die Figur als auch für den Text festgelegt ist, hat die Figurenszene die höhere Priorität – die Textszene wird ignoriert. 
- Wenn die Figur keine eigene Szene hat, aber eine 3D-Darstellung hat, wird die Textszene verwendet. 
- Andernfalls – wenn die Form ursprünglich keinen 3D-Effekt hat – ist die Form flach und der 3D-Effekt wird nur auf den Text angewendet. 

Die Beschreibungen sind mit den [ThreeDFormat.LightRig](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) und [ThreeDFormat.Camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) Eigenschaften verbunden.

{{% /alert %}} 

## **Äußere Schatteneffekte auf Texte anwenden**
Aspose.Slides für Python über .NET bietet die [**IOuterShadow**](https://reference.aspose.com/slides/python-net/aspose.slides.effects/ioutershadow/) und [**IInnerShadow**](https://reference.aspose.com/slides/python-net/aspose.slides.effects/iinnershadow/) Klassen, die Ihnen ermöglichen, Schatteneffekte auf einen Text anzuwenden, der von TextFrame getragen wird. Gehen Sie diese Schritte durch:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
3. Fügen Sie der Folie eine AutoShape vom Typ Rechteck hinzu.
4. Greifen Sie auf das TextFrame zu, das mit der AutoShape verbunden ist.
5. Setzen Sie den FillType der AutoShape auf NoFill.
6. Instanziieren Sie die OuterShadow-Klasse.
7. Setzen Sie den BlurRadius des Schattens.
8. Setzen Sie die Richtung des Schattens.
9. Setzen Sie die Distanz des Schattens.
10. Setzen Sie das RectangleAlign auf TopLeft.
11. Setzen Sie die PresetColor des Schattens auf Schwarz.
12. Schreiben Sie die Präsentation als PPTX-Datei.

Dieser Beispielcode in Python – eine Implementierung der oben genannten Schritte – zeigt Ihnen, wie Sie den äußeren Schatteneffekt auf einen Text anwenden:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:

    # Get reference of the slide
    sld = pres.slides[0]

    # Add an AutoShape of Rectangle type
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    # Add TextFrame to the Rectangle
    ashp.add_text_frame("Aspose TextBox")

    # Disable shape fill in case we want to get shadow of text
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Add outer shadow and set all necessary parameters
    ashp.effect_format.enable_outer_shadow_effect()
    shadow = ashp.effect_format.outer_shadow_effect
    shadow.blur_radius = 4.0
    shadow.direction = 45
    shadow.distance = 3
    shadow.rectangle_align = slides.RectangleAlignment.TOP_LEFT
    shadow.shadow_color.preset_color = slides.PresetColor.BLACK

    #Write the presentation to disk
    pres.save("pres_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Inner Shadow Effekt auf Formen anwenden**
Gehen Sie diese Schritte durch:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Erhalten Sie eine Referenz der Folie.
3. Fügen Sie eine AutoShape vom Typ Rechteck hinzu.
4. Aktivieren Sie den InnerShadowEffect.
5. Setzen Sie alle notwendigen Parameter.
6. Setzen Sie den ColorType auf Scheme.
7. Setzen Sie die Scheme-Farbe.
8. Schreiben Sie die Präsentation als [PPTX](https://docs.fileformat.com/presentation/pptx/) Datei.

Dieser Beispielcode (basierend auf den oben genannten Schritten) zeigt Ihnen, wie Sie einen Connector zwischen zwei Formen in Python hinzufügen:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    # Get reference of a slide
    slide = presentation.slides[0]

    # Add an AutoShape of Rectangle type
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 400, 300)
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Add TextFrame to the Rectangle
    ashp.add_text_frame("Aspose TextBox")
    port = ashp.text_frame.paragraphs[0].portions[0]
    pf = port.portion_format
    pf.font_height = 50

    # Enable inner_shadow_effect    
    ef = pf.effect_format
    ef.enable_inner_shadow_effect()

    # Set all necessary parameters
    ef.inner_shadow_effect.blur_radius = 8.0
    ef.inner_shadow_effect.direction = 90.0
    ef.inner_shadow_effect.distance = 6.0
    ef.inner_shadow_effect.shadow_color.b = 189

    # Set ColorType as Scheme
    ef.inner_shadow_effect.shadow_color.color_type = slides.ColorType.SCHEME

    # Set Scheme Color
    ef.inner_shadow_effect.shadow_color.scheme_color = slides.SchemeColor.ACCENT1

    # Save Presentation
    presentation.save("WordArt_out.pptx", slides.export.SaveFormat.PPTX)
```