---
title: WordArt-Effekte in Python via Java erstellen und anwenden
linktitle: WordArt
type: docs
weight: 110
url: /de/python-java/wordart/
keywords:
- WordArt
- WordArt erstellen
- WordArt-Vorlage
- WordArt-Effekt
- Schatteneffekt
- Reflexionseffekt
- Leuchteffekt
- WordArt-Transformation
- 3D-Effekt
- Außen-Schatten-Effekt
- Innen-Schatten-Effekt
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "WordArt-Effekte in Aspose.Slides für Python via Java erstellen und anpassen. Diese Schritt-für-Schritt-Anleitung hilft Entwicklern, Präsentationen mit professionellem Text in Python via Java zu verbessern."
---
## **Übersicht**

WordArt-Effekte ermöglichen es Ihnen, visuell ansprechenden, stilisierten Text zu Ihren PowerPoint-Präsentationen hinzuzufügen. Mit Aspose.Slides können Entwickler WordArt programmgesteuert erstellen, anpassen und verwalten – genau wie in Microsoft PowerPoint – ohne dass Office installiert sein muss. Dieser Artikel bietet einen Überblick über die Arbeit mit WordArt, einschließlich der Anwendung von Texttransformationen, Füllstilen, Konturen, Schatten und anderen Formatierungsoptionen, um den Inhalt Ihrer Präsentation ausdrucksvoller und ansprechender zu gestalten. WordArt ermöglicht es, Text als grafisches Objekt zu behandeln. Es besteht aus Effekten oder speziellen Modifikationen, die auf Text angewendet werden, um ihn attraktiver oder auffälliger zu machen.

## **Erstellen einer einfachen WordArt‑Vorlage und Anwenden auf Text**

**Verwendung von Aspose.Slides**

Zuerst erstellen wir einfachen Text mit diesem Python‑Code:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()

    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
finally:
    presentation.dispose()
```
Als Nächstes erhöhen wir die Schriftgröße, um den Effekt deutlicher zu machen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpame.startJVM()

from asposeslides.api import FontData, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    font_data = FontData("Arial Black")
    portion_format = portion.getPortionFormat()
    portion_format.setLatinFont(font_data)
    portion_format.setFontHeight(36)
finally:
    presentation.dispose()
```

**Verwendung von Microsoft PowerPoint**

Gehen Sie im Microsoft PowerPoint zum WordArt‑Effekte‑Menü:

![WordArt‑Effekte‑Menü in PowerPoint](image-20200930113926-1.png)

Im Menü rechts können Sie einen vordefinierten WordArt‑Effekt auswählen. Im Menü links können Sie die Einstellungen für neue WordArt festlegen.

Dies sind einige der verfügbaren Parameter oder Optionen:

![WordArt‑Formatierungsoptionen](image-20200930114015-3.png)

**Verwendung von Aspose.Slides**

Hier wenden wir die Musterfüllung [PatternStyle.SmallGrid](https://reference.aspose.com/slides/de/python-java/aspose.slides/patternstyle/#SmallGrid) auf den Text an und fügen mit diesem Code einen schwarzen Textrahmen hinzu:

```python
import jpide
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PatternStyle, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getFillFormat().setFillType(FillType.Pattern)
    pattern_format = portion_format.getFillFormat().getPatternFormat()
    pattern_format.getForeColor().setColor(Color.ORANGE)
    pattern_format.getBackColor().setColor(Color.WHITE)
    pattern_format.setPatternStyle(PatternStyle.SmallGrid)

    line_format = portion_format.getLineFormat()
    line_format.getFillFormat().setFillType(FillType.Solid)
    line_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
finally:
    presentation.dispose()
```

Der resultierende Text:

![Text mit Musterfüllung und schwarzem Kontur](image-20200930114108-4.png)

## **Anwenden weiterer WordArt‑Effekte**

**Verwendung von Microsoft PowerPoint**

Über die Programmoberfläche können Sie diese Effekte auf Text, einen Textblock, eine Form oder ein ähnliches Element anwenden:

![Text‑ und Formeffekte in PowerPoint](image-20200930114129-5.png)

Beispielsweise können Schatten‑, Reflexions‑ und Leuchteffekte auf Text angewendet werden; 3D‑Format‑ und 3D‑Drehungseffekte können auf einen Textblock angewendet werden; der Effekt „Weiche Kanten“ kann auf eine Form angewendet werden (er bleibt wirksam, auch wenn kein 3D‑Format‑Effekt eingestellt ist).

### **Anwenden von Schatteneffekten**

Der folgende Python‑Code wendet einen Schatteneffekt ausschließlich auf Text an:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getEffectFormat().enableOuterShadowEffect()
    outer_shadow = portion_format.getEffectFormat().getOuterShadowEffect()
    outer_shadow.getShadowColor().setColor(Color.BLACK)
    outer_shadow.setScaleHorizontal(100)
    outer_shadow.setScaleVertical(65)
    outer_shadow.setBlurRadius(4.73)
    outer_shadow.setDirection(230)
    outer_shadow.setDistance(2)
    outer_shadow.setSkewHorizontal(30)
    outer_shadow.setSkewVertical(0)
    outer_shadow.getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32)
finally:
    presentation.dispose()
```

Die Aspose.Slides‑API unterstützt drei Arten von Schatten: [OuterShadow](https://reference.aspose.com/slides/de/python-java/aspose.slides/outershadow/), [InnerShadow](https://reference.aspose.com/slides/de/python-java/aspose.slides/innershadow/) und [PresetShadow](https://reference.aspose.com/slides/de/python-java/aspose.slides/presetshadow/).

Mit [PresetShadow](https://reference.aspose.com/slides/de/python-java/aspose.slides/presetshadow/) können Sie einen Schatten auf Text mit vordefinierten Werten anwenden.

**Verwendung von Microsoft PowerPoint**

In PowerPoint können Sie einen Schattentyp verwenden. Hier ein Beispiel:

![Schatteneinstellungen in PowerPoint](image-20200930114225-6.png)

**Verwendung von Aspose.Slides**

Aspose.Slides ermöglicht tatsächlich, gleichzeitig zwei Schattenarten anzuwenden: [InnerShadow](https://reference.aspose.com/slides/de/python-java/aspose.slides/innershadow/) und [PresetShadow](https://reference.aspose.com/slides/de/python-java/aspose.slides/presetshadow/).

**Hinweise:**

- Wenn [OuterShadow](https://reference.aspose.com/slides/de/python-java/aspose.slides/outershadow/) und [PresetShadow](https://reference.aspose.com/slides/de/python-java/aspose.slides/presetshadow/) zusammen verwendet werden, wird nur der [OuterShadow]-Effekt angewendet.
- Wenn [OuterShadow](https://reference.aspose.com/slides/de/python-java/aspose.slides/outershadow/) und [InnerShadow](https://reference.aspose.com/slides/de/python-java/aspose.slides/innershadow/) gleichzeitig verwendet werden, hängt der resultierende bzw. angewandte Effekt von der PowerPoint‑Version ab. Beispielsweise wird in PowerPoint 2013 der Effekt verdoppelt. In PowerPoint 2007 wird jedoch der [OuterShadow]-Effekt angewendet.

### **Reflexion auf Text anwenden**

Wir fügen dem Text mittels dieses Codebeispiels in Python via Java eine Reflexion hinzu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RectangleAlignment, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getEffectFormat().enableReflectionEffect()
    reflection = portion_format.getEffectFormat().getReflectionEffect()
    reflection.setBlurRadius(0.5)
    reflection.setDistance(4.72)
    reflection.setStartPosAlpha(0)
    reflection.setEndPosAlpha(60)
    reflection.setDirection(90)
    reflection.setScaleHorizontal(100)
    reflection.setScaleVertical(-100)
    reflection.setStartReflectionOpacity(60)
    reflection.setEndReflectionOpacity(0.9)
    reflection.setRectangleAlign(RectangleAlignment.BottomLeft)
finally:
    presentation.dispose()
```

### **Leuchteffekt auf Text anwenden**

Wir wenden den Leuchteffekt auf den Text an, damit er leuchtet oder hervorsticht, mit folgendem Code:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getEffectFormat().enableGlowEffect()
    glow = portion_format.getEffectFormat().getGlowEffect()
    glow.getColor().setR(jpype.JByte(-1))
    glow.getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54)
    glow.setRadius(7)
finally:
    presentation.dispose()
```

Das Ergebnis der Operation:

![Text mit Leuchteffekt](image-20200930114621-7.png)

{{% alert color="info" title="Note" %}}
Sie können die Parameter für Schatten, Reflexion und Leuchten ändern. Die Eigenschaften der Effekte werden für jeden Textabschnitt separat festgelegt.
{{% /alert %}}

### **Verwendung von Transformationen in WordArt**

Verwenden Sie [TextFrameFormat.setTransform](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframeformat/#setTransform), um den gesamten Textblock zu transformieren:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, TextShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")

    text_frame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour)
finally:
    presentation.dispose()
```

Das Ergebnis:

![Text mit Bogen‑Transformation](image-20200930114712-8.png)

{{% alert color="info" title="Note" %}}
Sowohl Microsoft PowerPoint als auch Aspose.Slides für Python via Java bieten eine bestimmte Anzahl vordefinierter Transformationstypen.
{{% /alert %}}

**Verwendung von PowerPoint**

Um vordefinierte Transformationstypen zu öffnen, gehen Sie zu: **Format** -> **TextEffect** -> **Transform**

**Verwendung von Aspose.Slides**

Um einen Transformationstyp auszuwählen, verwenden Sie die Aufzählung [TextShapeType](https://reference.aspose.com/slides/de/python-java/aspose.slides/textshapetype/).

### **3D‑Effekte auf Text und Formen anwenden**

Wir wenden mit diesem Beispielcode einen 3D‑Effekt auf eine Textform an:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    auto_shape.getTextFrame().setText("Aspose.Slides")

    three_d_format = auto_shape.getThreeDFormat()
    three_d_format.getBevelBottom().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelBottom().setHeight(10.5)
    three_d_format.getBevelBottom().setWidth(10.5)

    three_d_format.getBevelTop().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelTop().setHeight(12.5)
    three_d_format.getBevelTop().setWidth(11)

    three_d_format.getExtrusionColor().setColor(Color.ORANGE)
    three_d_format.setExtrusionHeight(6)

    three_d_format.getContourColor().setColor(Color.RED)
    three_d_format.setContourWidth(1.5)

    three_d_format.setDepth(3)

    three_d_format.setMaterial(MaterialPresetType.Plastic)

    three_d_format.getLightRig().setDirection(LightingDirection.Top)
    three_d_format.getLightRig().setLightType(LightRigPresetType.Balanced)
    three_d_format.getLightRig().setRotation(0, 0, 40)

    three_d_format.getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

Der resultierende Text und seine Form:

![Textform mit 3D‑Effekten](image-20200930114816-9.png)

Wir wenden mit diesem Python‑Code einen 3D‑Effekt auf den Text an:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")

    three_d_format = text_frame.getTextFrameFormat().getThreeDFormat()
    three_d_format.getBevelBottom().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelBottom().setHeight(3.5)
    three_d_format.getBevelBottom().setWidth(3.5)

    three_d_format.getBevelTop().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelTop().setHeight(4)
    three_d_format.getBevelTop().setWidth(4)

    three_d_format.getExtrusionColor().setColor(Color.ORANGE)
    three_d_format.setExtrusionHeight(6)

    three_d_format.getContourColor().setColor(Color.RED)
    three_d_format.setContourWidth(1.5)

    three_d_format.setDepth(3)

    three_d_format.setMaterial(MaterialPresetType.Plastic)

    three_d_format.getLightRig().setDirection(LightingDirection.Top)
    three_d_format.getLightRig().setLightType(LightRigPresetType.Balanced)
    three_d_format.getLightRig().setRotation(0, 0, 40)

    three_d_format.getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

Das Ergebnis der Operation:

![Text mit 3D‑Effekten](image-20200930114905-10.png)

{{% alert color="info" title="Note" %}}
Die Anwendung von 3D‑Effekten auf Text oder seine Formen und die Wechselwirkungen zwischen Effekten basieren auf bestimmten Regeln.

Betrachten Sie eine Szene für den Text und die Form, die den Text enthält. Der 3D‑Effekt enthält eine 3D‑Objektdarstellung und die Szene, in der das Objekt platziert ist.

- Wenn die Szene sowohl für die Form als auch für den Text festgelegt ist, hat die Formenszene Vorrang – die Textszene wird ignoriert.
- Wenn die Form keine eigene Szene hat, aber eine 3D‑Darstellung besitzt, wird die Textszene verwendet.
- Andernfalls – wenn die Form ursprünglich keinen 3D‑Effekt hat – ist die Form flach und der 3D‑Effekt wird nur auf den Text angewendet.

Diese Regeln beziehen sich auf die Methoden [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/de/python-java/aspose.slides/threedformat/#getLightRig) und [ThreeDFormat.getCamera](https://reference.aspose.com/slides/de/python-java/aspose.slides/threedformat/#getCamera).
{{% /alert %}}

## **Außen‑Schatten‑Effekte auf Text anwenden**

Aspose.Slides für Python via Java stellt die Klassen [OuterShadow](https://reference.aspose.com/slides/de/python-java/aspose.slides/outershadow/) und [InnerShadow](https://reference.aspose.com/slides/de/python-java/aspose.slides/innershadow/) bereit, mit denen Sie Schatteneffekte auf Text in einem [TextFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/) anwenden können. Führen Sie folgende Schritte aus:

1. Erstellen Sie eine Instanz der Klasse [Presentation] .
2. Holen Sie sich den Verweis auf eine Folie mittels ihres Index.
3. Fügen Sie der Folie eine rechteckige Form hinzu.
4. Greifen Sie auf den Textrahmen zu, der mit der Form verknüpft ist.
5. Deaktivieren Sie die Formfüllung.
6. Aktivieren Sie den Außen‑Schatten‑Effekt.
7. Legen Sie den Unschärferadius des Schattens fest.
8. Legen Sie die Richtung des Schattens fest.
9. Legen Sie den Abstand des Schattens fest.
10. Richten Sie den Schatten oben links aus.
11. Setzen Sie die Schattenfarbe auf Schwarz.
12. Speichern Sie die Präsentation als [PPTX]‑Datei.

Dieser Beispielcode in Python via Java – eine Umsetzung der oben genannten Schritte – zeigt, wie Sie den Außen‑Schatten‑Effekt auf Text anwenden:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetColor, RectangleAlignment, SaveFormat, ShapeType

presentation = Presentation()
try:
    # Referenz der Folie abrufen
    slide = presentation.getSlides().get_Item(0)

    # Ein AutoShape vom Typ Rechteck hinzufügen
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50)

    # TextFrame zum Rechteck hinzufügen
    auto_shape.addTextFrame("Aspose TextBox")

    # Formfüllung deaktivieren, falls wir den Schattierungseffekt des Textes erhalten wollen
    auto_shape.getFillFormat().setFillType(FillType.NoFill)

    # Äußeren Schatten hinzufügen und alle notwendigen Parameter festlegen
    auto_shape.getEffectFormat().enableOuterShadowEffect()
    shadow = auto_shape.getEffectFormat().getOuterShadowEffect()
    shadow.setBlurRadius(4.0)
    shadow.setDirection(45)
    shadow.setDistance(3)
    shadow.setRectangleAlign(RectangleAlignment.TopLeft)
    shadow.getShadowColor().setPresetColor(PresetColor.Black)

    # Präsentation auf die Festplatte speichern
    presentation.save("pres_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Inneren Schatten‑Effekt auf Formen anwenden**

Führen Sie folgende Schritte aus:

1. Erstellen Sie eine Instanz der Klasse [Presentation] .
2. Holen Sie sich einen Verweis auf die Folie.
3. Fügen Sie eine rechteckige Form hinzu.
4. Aktivieren Sie den inneren Schatten‑Effekt.
5. Legen Sie alle notwendigen Parameter fest.
6. Setzen Sie den Schattfarbe‑Typ, um eine Designfarbe zu verwenden.
7. Legen Sie die Designfarbe fest.
8. Speichern Sie die Präsentation als [PPTX]‑Datei.

Dieser Beispielcode (basierend auf den obigen Schritten) zeigt, wie Sie den inneren Schatten‑Effekt auf den Text in einer Form in Python via Java anwenden:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorType, FillType, Presentation, SaveFormat, SchemeColor, ShapeType

presentation = Presentation()
try:
    # Referenz der Folie abrufen
    slide = presentation.getSlides().get_Item(0)

    # Ein AutoShape vom Typ Rechteck hinzufügen
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300)
    auto_shape.getFillFormat().setFillType(FillType.NoFill)

    # TextFrame zum Rechteck hinzufügen
    auto_shape.addTextFrame("Aspose TextBox")
    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion_format = portion.getPortionFormat()
    portion_format.setFontHeight(50)

    # InnerShadowEffect aktivieren
    effect_format = portion_format.getEffectFormat()
    effect_format.enableInnerShadowEffect()

    # Alle notwendigen Parameter festlegen
    inner_shadow = effect_format.getInnerShadowEffect()
    inner_shadow.setBlurRadius(8.0)
    inner_shadow.setDirection(90.0)
    inner_shadow.setDistance(6.0)
    inner_shadow.getShadowColor().setB(jpype.JByte(-67))

    # ColorType als Schema setzen
    inner_shadow.getShadowColor().setColorType(ColorType.Scheme)

    # Schemafarbe setzen
    inner_shadow.getShadowColor().setSchemeColor(SchemeColor.Accent1)

    # Präsentation speichern
    presentation.save("WordArt_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Kann ich WordArt‑Effekte mit verschiedenen Schriftarten oder Skripten (z. B. Arabisch, Chinesisch) verwenden?**

Ja, Aspose.Slides unterstützt Unicode und funktioniert mit allen gängigen Schriftarten und Skripten. WordArt‑Effekte wie Schatten, Füllung und Kontur können unabhängig von der Sprache angewendet werden, wobei die Verfügbarkeit und Darstellung von Schriftarten vom System abhängen können.

**Kann ich WordArt‑Effekte auf Elemente des Folienmasters anwenden?**

Ja, Sie können WordArt‑Effekte auf Formen in Masterfolien anwenden, einschließlich Titel‑Platzhaltern, Fußzeilen oder Hintergrundtext. Änderungen am Master‑Layout werden auf alle zugehörigen Folien übertragen.

**Beeinflussen WordArt‑Effekte die Dateigröße der Präsentation?**

Ein wenig. WordArt‑Effekte wie Schatten, Leuchten und Farbverläufe können die Dateigröße durch zusätzliche Formatierungs‑Metadaten geringfügig erhöhen, jedoch ist der Unterschied in der Regel vernachlässigbar.

**Kann ich das Ergebnis von WordArt‑Effekten ansehen, ohne die Präsentation zu speichern?**

Ja, Sie können Folien, die WordArt enthalten, mit [Shape.getImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getImage) oder [Slide.getImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/slide/#getImage) in Bilder (z. B. PNG, JPEG) rendern. So können Sie das Ergebnis im Speicher oder auf dem Bildschirm ansehen, bevor Sie die komplette Präsentation speichern oder exportieren.