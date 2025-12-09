---
title: WordArt‑Effekte in Python erstellen und anwenden
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
- 3D‑Effekt
- Außen‑Schatteneffekt
- Innen‑Schatteneffekt
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie WordArt‑Effekte in Aspose.Slides für Python via .NET erstellen und anpassen. Diese Schritt‑für‑Schritt‑Anleitung hilft Entwicklern, Präsentationen mit stilvollem, professionellem Text in Python zu verbessern."
---

## **Über WordArt?**
WordArt oder Word Art ist eine Funktion, mit der Sie Texteffekte anwenden können, damit Texte hervorstechen. Mit WordArt können Sie beispielsweise einen Text umreißen oder mit einer Farbe (oder einem Farbverlauf) füllen, 3D‑Effekte hinzufügen usw. Außerdem können Sie die Form eines Textes kippen, biegen und strecken.

{{% alert color="primary"%}} 
WordArt ermöglicht es, einen Text wie ein grafisches Objekt zu behandeln. WordArt besteht aus Effekten oder speziellen Modifikationen von Texten, um sie attraktiver oder auffälliger zu machen. 
{{% /alert %}} 

**WordArt in Microsoft PowerPoint**

Um WordArt in Microsoft PowerPoint zu verwenden, müssen Sie eine der vordefinierten WordArt‑Vorlagen auswählen. Eine WordArt‑Vorlage ist ein Satz von Effekten, die auf einen Text oder dessen Form angewendet werden.

**WordArt in Aspose.Slides**

In Aspose.Slides für Python via .NET 20.10 haben wir die Unterstützung für WordArt implementiert und die Funktion in nachfolgenden Aspose.Slides‑Versionen für Python via .NET verbessert.

Mit Aspose.Slides für Python via .NET können Sie ganz einfach Ihre eigene WordArt‑Vorlage (ein einzelner Effekt oder eine Kombination von Effekten) in Python erstellen und auf Texte anwenden.

## Erstellen einer einfachen WordArt‑Vorlage und Anwenden auf einen Text

**Verwendung von Aspose.Slides** 

Zunächst erstellen wir einen einfachen Text mit folgendem Python‑Code: 
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

Nun setzen wir die Schriftgröße des Textes auf einen größeren Wert, um den Effekt deutlicher zu machen, mit diesem Code:
```py 
    fontData = slides.FontData("Arial Black")
    portion.portion_format.latin_font = fontData
    portion.portion_format.font_height = 36
```


**Verwendung von Microsoft PowerPoint**

Gehen Sie zum WordArt‑Effektmenü in Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Im rechten Menü können Sie einen vordefinierten WordArt‑Effekt auswählen. Im linken Menü können Sie die Einstellungen für ein neues WordArt festlegen.

Dies sind einige der verfügbaren Parameter oder Optionen:

![todo:image_alt_text](image-20200930114015-3.png)

**Verwendung von Aspose.Slides**

Hier wenden wir die SmallGrid‑Musterfarbe auf den Text an und fügen mit diesem Code einen schwarzen Textrahmen mit Breite 1 hinzu:
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

## Anwenden weiterer WordArt‑Effekte

**Verwendung von Microsoft PowerPoint**

Über die Programmoberfläche können Sie diese Effekte auf einen Text, Textblock, eine Form oder ein ähnliches Element anwenden:

![todo:image_alt_text](image-20200930114129-5.png)

Beispielsweise können Schatten-, Reflexions‑ und Leuchteffekte auf einen Text angewendet werden; 3D‑Format‑ und 3D‑Dreh‑Effekte können auf einen Textblock angewendet werden; die Eigenschaft „Soft Edges“ kann auf ein Formobjekt angewendet werden (sie bleibt wirksam, wenn keine 3D‑Format‑Eigenschaft gesetzt ist).

### Anwenden von Schatteneffekten

Hier setzen wir nur Eigenschaften, die einen Text betreffen. Wir wenden den Schatteneffekt auf einen Text mit folgendem Python‑Code an:
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


Die Aspose.Slides‑API unterstützt drei Schattenarten: OuterShadow, InnerShadow und PresetShadow.

Mit PresetShadow können Sie einen Schatten für einen Text anwenden (unter Verwendung vordefinierter Werte).

**Verwendung von Microsoft PowerPoint**

In PowerPoint können Sie nur einen Schatten‑Typ verwenden. Beispiel:

![todo:image_alt_text](image-20200930114225-6.png)

**Verwendung von Aspose.Slides**

Aspose.Slides erlaubt tatsächlich das gleichzeitige Anwenden zweier Schattenarten: InnerShadow und PresetShadow.

**Hinweise:**

- Wenn OuterShadow und PresetShadow zusammen verwendet werden, wird nur der OuterShadow‑Effekt angewendet. 
- Wenn OuterShadow und InnerShadow gleichzeitig verwendet werden, hängt der resultierende Effekt von der PowerPoint‑Version ab. In PowerPoint 2013 wird der Effekt verdoppelt, in PowerPoint 2007 wird nur der OuterShadow‑Effekt angewendet. 

### Anwenden von Anzeigeeffekten auf Texte

Wir fügen dem Text über dieses Python‑Beispiel Anzeigeeffekte hinzu:
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


### Anwenden von Leuchteffekten auf Texte

Wir wenden den Leuchteffekt auf den Text an, damit er glänzt oder hervorgehoben wird, mit folgendem Code:
```py 
    portion.portion_format.effect_format.enable_glow_effect()
    portion.portion_format.effect_format.glow_effect.color.r = 255
    portion.portion_format.effect_format.glow_effect.color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.54)
    portion.portion_format.effect_format.glow_effect.radius = 7
```


Das Ergebnis:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary"%}} 
Sie können die Parameter für Schatten, Anzeige und Leuchteffekt ändern. Die Eigenschaften der Effekte werden für jeden Textabschnitt separat gesetzt. 
{{% /alert %}} 

### Verwendung von Transformationen in WordArt

Wir verwenden die Transform‑Eigenschaft (gilt für den gesamten Textblock) mit folgendem Code:
```py 
textFrame.text_frame_format.transform = slides.TextShapeType.ARCH_UP_POUR
```


Das Ergebnis:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary"%}} 
Sowohl Microsoft PowerPoint als auch Aspose.Slides für Python via .NET bieten eine Reihe vordefinierter Transformationstypen. 
{{% /alert %}} 

**Verwendung von PowerPoint**

Um vordefinierte Transformationstypen aufzurufen, gehen Sie über: **Format** → **TextEffect** → **Transform**

**Verwendung von Aspose.Slides**

Zum Auswählen eines Transformationstyps verwenden Sie das Enum TextShapeType. 

### Anwenden von 3D‑Effekten auf Texte und Formen

Wir setzen einen 3D‑Effekt auf eine Textform mit folgendem Beispielcode:
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

Wir wenden mit diesem Python‑Code einen 3D‑Effekt auf den Text an:
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


Das Ergebnis:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary"%}} 
Die Anwendung von 3D‑Effekten auf Texte oder deren Formen sowie die Interaktion zwischen Effekten folgen bestimmten Regeln. 

Betrachten Sie eine Szene für einen Text und die Form, die diesen Text enthält. Der 3D‑Effekt umfasst die 3D‑Objektdarstellung und die Szene, in der das Objekt platziert ist. 

- Wenn die Szene sowohl für die Figur als auch für den Text gesetzt ist, hat die Figur‑Szene höhere Priorität – die Text‑Szene wird ignoriert. 
- Wenn die Figur keine eigene Szene hat, aber eine 3D‑Darstellung, wird die Text‑Szene verwendet. 
- Andernfalls – wenn die Form ursprünglich keinen 3D‑Effekt hat – ist die Form flach und der 3D‑Effekt wird nur auf den Text angewendet. 

Die Beschreibungen beziehen sich auf die Eigenschaften [ThreeDFormat.LightRig](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) und [ThreeDFormat.Camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/). 
{{% /alert %}} 

## **Äußere Schatteneffekte auf Texte anwenden**
Aspose.Slides für Python via .NET stellt die Klassen [**IOuterShadow**](https://reference.aspose.com/slides/python-net/aspose.slides.effects/ioutershadow/) und [**IInnerShadow**](https://reference.aspose.com/slides/python-net/aspose.slides.effects/iinnershadow/) bereit, mit denen Sie Schatteneffekte auf einen Text in einem TextFrame anwenden können. Gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie sich die Referenz einer Folie über deren Index.  
3. Fügen Sie der Folie ein AutoShape vom Typ Rectangle hinzu.  
4. Greifen Sie auf das TextFrame des AutoShape zu.  
5. Setzen Sie den FillType des AutoShape auf NoFill.  
6. Instanziieren Sie die OuterShadow‑Klasse.  
7. Setzen Sie den BlurRadius des Schattens.  
8. Setzen Sie die Direction des Schattens.  
9. Setzen Sie den Distance des Schattens.  
10. Setzen Sie RectanglelAlign auf TopLeft.  
11. Setzen Sie die PresetColor des Schattens auf Black.  
12. Schreiben Sie die Präsentation als PPTX‑Datei.

Dieser Beispielcode in Python – eine Umsetzung der oben genannten Schritte – zeigt, wie Sie den äußeren Schatteneffekt auf einen Text anwenden:
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:

    # Referenz der Folie holen
    sld = pres.slides[0]

    # AutoShape vom Typ Rechteck hinzufügen
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    # TextFrame zum Rechteck hinzufügen
    ashp.add_text_frame("Aspose TextBox")

    # Shape-Füllung deaktivieren, falls wir den Schatten des Textes erhalten wollen
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Äußeren Schatten hinzufügen und alle notwendigen Parameter setzen
    ashp.effect_format.enable_outer_shadow_effect()
    shadow = ashp.effect_format.outer_shadow_effect
    shadow.blur_radius = 4.0
    shadow.direction = 45
    shadow.distance = 3
    shadow.rectangle_align = slides.RectangleAlignment.TOP_LEFT
    shadow.shadow_color.preset_color = slides.PresetColor.BLACK

    #Präsentation auf die Festplatte schreiben
    pres.save("pres_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Inneren Schatteneffekt auf Formen anwenden**
Gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie sich die Referenz der Folie.  
3. Fügen Sie ein AutoShape vom Typ Rectangle hinzu.  
4. Aktivieren Sie InnerShadowEffect.  
5. Setzen Sie alle notwendigen Parameter.  
6. Setzen Sie ColorType auf Scheme.  
7. Setzen Sie die Scheme Color.  
8. Schreiben Sie die Präsentation als [PPTX](https://docs.fileformat.com/presentation/pptx/)‑Datei.

Dieser Beispielcode (basierend auf den obigen Schritten) zeigt, wie Sie in Python einen Connector zwischen zwei Formen hinzufügen:
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    # Referenz einer Folie holen
    slide = presentation.slides[0]

    # AutoShape vom Typ Rechteck hinzufügen
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 400, 300)
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # TextFrame zum Rechteck hinzufügen
    ashp.add_text_frame("Aspose TextBox")
    port = ashp.text_frame.paragraphs[0].portions[0]
    pf = port.portion_format
    pf.font_height = 50

    # inner_shadow_effect aktivieren    
    ef = pf.effect_format
    ef.enable_inner_shadow_effect()

    # Alle notwendigen Parameter setzen
    ef.inner_shadow_effect.blur_radius = 8.0
    ef.inner_shadow_effect.direction = 90.0
    ef.inner_shadow_effect.distance = 6.0
    ef.inner_shadow_effect.shadow_color.b = 189

    # ColorType auf Scheme setzen
    ef.inner_shadow_effect.shadow_color.color_type = slides.ColorType.SCHEME

    # Scheme-Farbe setzen
    ef.inner_shadow_effect.shadow_color.scheme_color = slides.SchemeColor.ACCENT1

    # Präsentation speichern
    presentation.save("WordArt_out.pptx", slides.export.SaveFormat.PPTX)
```



## **FAQ**

**Kann ich WordArt‑Effekte mit unterschiedlichen Schriftarten oder Skripten (z. B. Arabisch, Chinesisch) verwenden?**

Ja, Aspose.Slides unterstützt Unicode und funktioniert mit allen gängigen Schriftarten und Skripten. WordArt‑Effekte wie Schatten, Füllung und Kontur können unabhängig von der Sprache angewendet werden, wobei die Verfügbarkeit und Darstellung von der Systemschrift abhängen kann.

**Kann ich WordArt‑Effekte auf Elemente des Folien‑Masters anwenden?**

Ja, Sie können WordArt‑Effekte auf Formen im Master‑Folienlayout anwenden, einschließlich Titelplatzhaltern, Fußzeilen oder Hintergrundtexten. Änderungen am Master‑Layout werden auf alle zugehörigen Folien übertragen.

**Beeinflussen WordArt‑Effekte die Dateigröße der Präsentation?**

Leicht. WordArt‑Effekte wie Schatten, Leuchten und Farbverläufe können die Dateigröße geringfügig erhöhen, da zusätzliche Formatierungs‑Metadaten gespeichert werden, aber der Unterschied ist in der Regel vernachlässigbar.

**Kann ich das Ergebnis von WordArt‑Effekten sehen, ohne die Präsentation zu speichern?**

Ja, Sie können Folien mit WordArt in Bilder (z. B. PNG, JPEG) rendern, indem Sie die `get_image`‑Methode der [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)‑ oder [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/)‑Klassen verwenden. Damit können Sie das Ergebnis im Speicher oder auf dem Bildschirm prüfen, bevor Sie die vollständige Präsentation speichern oder exportieren.