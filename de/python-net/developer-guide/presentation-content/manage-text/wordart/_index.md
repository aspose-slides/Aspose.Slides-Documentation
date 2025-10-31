---
title: WordArt-Effekte in Python erstellen und anwenden
linktitle: WordArt
type: docs
weight: 110
url: /de/python-net/wordart/
keywords:
- WordArt
- WordArt erstellen
- WordArt-Vorlage
- WordArt-Effekt
- Schatteneffekt
- Anzeigeeffekt
- Leuchteffekt
- WordArt-Transformation
- 3D-Effekt
- Außenschatten-Effekt
- Innenschatten-Effekt
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie WordArt-Effekte in Aspose.Slides für Python via .NET erstellen und anpassen. Diese Schritt‑für‑Schritt‑Anleitung hilft Entwicklern, Präsentationen mit stilvollem, professionellem Text in Python zu verbessern."
---

## **Über WordArt?**
WordArt oder Word Art ist eine Funktion, mit der Sie Texteffekte anwenden können, damit sie hervorstechen. Mit WordArt können Sie beispielsweise einen Text umranden oder ihn mit einer Farbe (oder einem Farbverlauf) füllen, 3D‑Effekte hinzufügen usw. Außerdem können Sie die Form eines Textes schräg stellen, biegen und strecken. 

{{% alert color="primary" %}} 
WordArt ermöglicht es Ihnen, einen Text wie ein grafisches Objekt zu behandeln. WordArt besteht aus Effekten oder speziellen Modifikationen von Texten, um sie attraktiver oder auffälliger zu machen. 
{{% /alert %}} 

**WordArt in Microsoft PowerPoint**

Um WordArt in Microsoft PowerPoint zu verwenden, müssen Sie eine der vordefinierten WordArt‑Vorlagen auswählen. Eine WordArt‑Vorlage ist ein Satz von Effekten, der auf einen Text oder dessen Form angewendet wird. 

**WordArt in Aspose.Slides**

In Aspose.Slides für Python via .NET 20.10 haben wir die Unterstützung für WordArt implementiert und die Funktion in nachfolgenden Aspose.Slides‑Releases weiter verbessert. 

Mit Aspose.Slides für Python via .NET können Sie einfach Ihre eigene WordArt‑Vorlage (ein einzelner Effekt oder eine Kombination von Effekten) in Python erstellen und sie auf Texte anwenden. 

## Erstellen einer einfachen WordArt‑Vorlage und Anwenden auf einen Text

**Verwendung von Aspose.Slides** 

Zuerst erstellen wir einen einfachen Text mit folgendem Python‑Code: 

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

Nun setzen wir die Schriftgröße des Textes auf einen höheren Wert, um den Effekt besser sichtbar zu machen:

```py 
    fontData = slides.FontData("Arial Black")
    portion.portion_format.latin_font = fontData
    portion.portion_format.font_height = 36
```

**Verwendung von Microsoft PowerPoint**

Gehen Sie zum WordArt‑Effekte‑Menü in Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Im rechten Menü können Sie einen vordefinierten WordArt‑Effekt wählen. Im linken Menü können Sie die Einstellungen für ein neues WordArt festlegen. 

Dies sind einige der verfügbaren Parameter oder Optionen:

![todo:image_alt_text](image-20200930114015-3.png)

**Verwendung von Aspose.Slides**

Hier wenden wir die SmallGrid‑Musterfarbe auf den Text an und fügen mit folgendem Code einen 1‑Pixel‑breiten schwarzen Textrahmen hinzu:

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

## Anwenden anderer WordArt‑Effekte

**Verwendung von Microsoft PowerPoint**

Über die Programmoberfläche können Sie diese Effekte auf einen Text, Textblock, eine Form oder ein ähnliches Element anwenden:

![todo:image_alt_text](image-20200930114129-5.png)

Beispielsweise können Schatten-, Reflexions‑ und Leuchte‑Effekte auf einen Text angewendet werden; 3D‑Format‑ und 3D‑Dreh‑Effekte auf einen Textblock; die Eigenschaft „Weiche Kanten“ kann auf ein Formobjekt angewendet werden (sie wirkt weiterhin, wenn keine 3D‑Format‑Eigenschaft gesetzt ist). 

### Anwenden von Schatten‑Effekten

Hier setzen wir ausschließlich Eigenschaften, die sich nur auf den Text beziehen. Wir wenden den Schatten‑Effekt auf einen Text mit folgendem Python‑Code an:

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

Aspose.Slides‑API unterstützt drei Schattenarten: OuterShadow, InnerShadow und PresetShadow. 

Mit PresetShadow können Sie einen Schatten für einen Text (mit voreingestellten Werten) anwenden. 

**Verwendung von Microsoft PowerPoint**

In PowerPoint können Sie nur einen Schatten‑Typ verwenden. Beispiel:

![todo:image_alt_text](image-20200930114225-6.png)

**Verwendung von Aspose.Slides**

Aspose.Slides erlaubt tatsächlich, zwei Schattenarten gleichzeitig anzuwenden: InnerShadow und PresetShadow.

**Hinweise:**

- Werden OuterShadow und PresetShadow zusammen verwendet, wird nur der OuterShadow‑Effekt angewendet. 
- Bei gleichzeitiger Verwendung von OuterShadow und InnerShadow hängt das Ergebnis vom PowerPoint‑Version ab. In PowerPoint 2013 wird der Effekt verdoppelt, in PowerPoint 2007 wird nur der OuterShadow‑Effekt angewendet. 

### Anwenden von Anzeige‑Effekten auf Texte

Wir fügen dem Text mit folgendem Python‑Beispiel einen Anzeige‑Effekt hinzu:

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

### Anwenden von Leuchte‑Effekt auf Texte

Wir wenden den Leuchte‑Effekt auf den Text an, damit er leuchtet oder hervorsticht:

```py 
    portion.portion_format.effect_format.enable_glow_effect()
    portion.portion_format.effect_format.glow_effect.color.r = 255
    portion.portion_format.effect_format.glow_effect.color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.54)
    portion.portion_format.effect_format.glow_effect.radius = 7
```

Das Ergebnis der Operation:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 
Sie können die Parameter für Schatten, Anzeige und Leuchte ändern. Die Eigenschaften der Effekte werden für jeden Teil des Textes separat gesetzt. 
{{% /alert %}} 

### Verwendung von Transformationen in WordArt

Wir nutzen die Transform‑Eigenschaft (für den gesamten Textblock) mit folgendem Code:
```py 
textFrame.text_frame_format.transform = slides.TextShapeType.ARCH_UP_POUR
```

Das Ergebnis:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 
Sowohl Microsoft PowerPoint als auch Aspose.Slides für Python via .NET bieten eine Reihe vordefinierter Transformationsarten. 
{{% /alert %}} 

**Verwendung in PowerPoint**

Zum Zugriff auf vordefinierte Transformationsarten gehen Sie über: **Format** → **TextEffect** → **Transform**  

**Verwendung in Aspose.Slides**

Zum Auswählen einer Transformationsart verwenden Sie das `TextShapeType`‑Enum.  

### Anwenden von 3D‑Effekten auf Texte und Formen

Wir setzen einen 3D‑Effekt auf eine Textform mit folgendem Beispiel:

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

Wir wenden einen 3D‑Effekt auf den Text mit folgendem Python‑Code an:

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
Die Anwendung von 3D‑Effekten auf Texte oder deren Formen sowie die Interaktion zwischen den Effekten folgen bestimmten Regeln. 

Betrachten Sie eine Szene für einen Text und die Form, die diesen Text enthält. Der 3D‑Effekt beinhaltet die 3D‑Objektdarstellung und die Szene, in die das Objekt eingefügt wird. 

- Wenn die Szene sowohl für die Form als auch für den Text gesetzt ist, hat die Form‑Szene Vorrang – die Text‑Szene wird ignoriert. 
- Fehlt der Form eine eigene Szene, aber sie hat eine 3D‑Darstellung, wird die Text‑Szene verwendet. 
- Andernfalls – wenn die Form ursprünglich keinen 3D‑Effekt hat – bleibt die Form flach und der 3D‑Effekt wird nur auf den Text angewendet. 

Die Beschreibungen beziehen sich auf die Eigenschaften [ThreeDFormat.LightRig](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) und [ThreeDFormat.Camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/). 
{{% /alert %}} 

## **Außenschatten‑Effekte auf Texte anwenden**
Aspose.Slides für Python via .NET stellt die Klassen [**IOuterShadow**](https://reference.aspose.com/slides/python-net/aspose.slides.effects/ioutershadow/) und [**IInnerShadow**](https://reference.aspose.com/slides/python-net/aspose.slides.effects/iinnershadow/) bereit, mit denen Sie Schatten‑Effekte auf einen Text in einem TextFrame anwenden können. Vorgehensweise:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie die Referenz einer Folie über deren Index.  
3. Fügen Sie der Folie eine AutoShape vom Typ Rechteck hinzu.  
4. Greifen Sie auf das TextFrame der AutoShape zu.  
5. Setzen Sie den FillType der AutoShape auf NoFill.  
6. Instanziieren Sie die OuterShadow‑Klasse.  
7. Legen Sie den BlurRadius des Schattens fest.  
8. Bestimmen Sie die Richtung des Schattens.  
9. Setzen Sie den Abstand des Schattens.  
10. Setzen Sie RectangleAlign auf TopLeft.  
11. Setzen Sie die PresetColor des Schattens auf Black.  
12. Speichern Sie die Präsentation als PPTX‑Datei.  

Dieses Beispiel in Python demonstriert die Schritte:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:

    # Hole Referenz der Folie
    sld = pres.slides[0]

    # Füge eine AutoShape vom Typ Rechteck hinzu
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    # Füge dem Rechteck ein TextFrame hinzu
    ashp.add_text_frame("Aspose TextBox")

    # Deaktiviere die Formfüllung, falls wir den Textschatten erhalten wollen
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Füge äußeren Schatten hinzu und setze alle notwendigen Parameter
    ashp.effect_format.enable_outer_shadow_effect()
    shadow = ashp.effect_format.outer_shadow_effect
    shadow.blur_radius = 4.0
    shadow.direction = 45
    shadow.distance = 3
    shadow.rectangle_align = slides.RectangleAlignment.TOP_LEFT
    shadow.shadow_color.preset_color = slides.PresetColor.BLACK

    # Schreibe die Präsentation auf die Festplatte
    pres.save("pres_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Innenschatten‑Effekt auf Formen anwenden**
Vorgehensweise:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie die Referenz einer Folie.  
3. Fügen Sie der Folie eine AutoShape vom Typ Rechteck hinzu.  
4. Aktivieren Sie InnerShadowEffect.  
5. Setzen Sie alle notwendigen Parameter.  
6. Setzen Sie ColorType auf Scheme.  
7. Legen Sie die Scheme‑Farbe fest.  
8. Speichern Sie die Präsentation als [PPTX](https://docs.fileformat.com/presentation/pptx/)‑Datei.  

Dieses Beispiel zeigt, wie Sie in Python einen Connector zwischen zwei Formen hinzufügen:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    # Hole Referenz einer Folie
    slide = presentation.slides[0]

    # Füge eine AutoShape vom Typ Rechteck hinzu
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 400, 300)
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Füge dem Rechteck ein TextFrame hinzu
    ashp.add_text_frame("Aspose TextBox")
    port = ashp.text_frame.paragraphs[0].portions[0]
    pf = port.portion_format
    pf.font_height = 50

    # Aktiviere inner_shadow_effect    
    ef = pf.effect_format
    ef.enable_inner_shadow_effect()

    # Setze alle notwendigen Parameter
    ef.inner_shadow_effect.blur_radius = 8.0
    ef.inner_shadow_effect.direction = 90.0
    ef.inner_shadow_effect.distance = 6.0
    ef.inner_shadow_effect.shadow_color.b = 189

    # Setze ColorType auf Scheme
    ef.inner_shadow_effect.shadow_color.color_type = slides.ColorType.SCHEME

    # Setze Scheme-Farbe
    ef.inner_shadow_effect.shadow_color.scheme_color = slides.SchemeColor.ACCENT1

    # Speicher die Präsentation
    presentation.save("WordArt_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Kann ich WordArt‑Effekte mit verschiedenen Schriftarten oder Schriftsystemen (z. B. Arabisch, Chinesisch) verwenden?**

Ja, Aspose.Slides unterstützt Unicode und funktioniert mit allen gängigen Schriftarten und Schriftsystemen. WordArt‑Effekte wie Schatten, Füllung und Umriss können unabhängig von der Sprache angewendet werden, wobei die Verfügbarkeit und das Rendering der Schriftart vom jeweiligen System abhängen.

**Kann ich WordArt‑Effekte auf Elemente des Folienmasters anwenden?**

Ja, Sie können WordArt‑Effekte auf Formen in Master‑Folien anwenden, einschließlich Titel‑Platzhaltern, Fußzeilen oder Hintergrundtext. Änderungen am Master‑Layout werden in allen zugehörigen Folien übernommen.

**Beeinflussen WordArt‑Effekte die Dateigröße der Präsentation?**

Leicht. Effekte wie Schatten, Leuchte und Farbverläufe können die Dateigröße geringfügig erhöhen, da zusätzliche Formatierungs‑Metadaten hinzugefügt werden, aber der Unterschied ist in der Regel vernachlässigbar.

**Kann ich das Ergebnis von WordArt‑Effekten sehen, ohne die Präsentation zu speichern?**

Ja, Sie können Folien, die WordArt enthalten, mit der `get_image`‑Methode aus den Klassen [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) oder [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) in Bilder (z. B. PNG, JPEG) rendern. Damit können Sie das Ergebnis im Speicher oder auf dem Bildschirm prüfen, bevor Sie die gesamte Präsentation speichern oder exportieren.