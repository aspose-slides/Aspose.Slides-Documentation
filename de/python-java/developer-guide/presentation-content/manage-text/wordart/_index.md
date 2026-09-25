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
- äußerer Schatteneffekt
- innerer Schatteneffekt
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Erstellen und Anpassen von WordArt-Effekten in Aspose.Slides für Python via Java. Diese schrittweise Anleitung hilft Entwicklern, Präsentationen mit professionellem Text in Python via Java zu verbessern."
---
## **Übersicht**

WordArt‑Effekte ermöglichen es, Text mit Füllungen, Konturen, Schatten, Reflexionen, Leuchten, Transformationen und 3D‑Formatierung zu gestalten. Dieser Artikel erklärt, wie Sie diese Effekte in PowerPoint‑Präsentationen mit Aspose.Slides für Python via Java erstellen und anpassen, ohne dass Microsoft Office installiert sein muss.

## **Erstellen einer einfachen WordArt‑Vorlage und Anwenden auf Text**

Die folgenden Beispiele erzeugen einen einfachen WordArt‑Stil, indem sie Text, Schriftart, Musterfüllung und Kontur festlegen.

Jedes Beispiel erstellt eine neue Präsentation und fügt ihrer ersten Folie ein Rechteck hinzu; eine Eingabedatei ist nicht erforderlich. Das erste Beispiel setzt den Text auf „Aspose.Slides“. Die Position und die Abmessungen der Form werden in Punkten angegeben:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)
    text_frame = auto_shape.getTextFrame()

    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
finally:
    presentation.dispose()
```

Setzen Sie die Schriftart auf Arial Black mit 36 Pt, um die Formatierung deutlicher zu machen:

```python
import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)
finally:
    presentation.dispose()
```

Wenden Sie ein [SmallGrid](https://reference.aspose.com/slides/de/python-java/aspose.slides/patternstyle/#SmallGrid)‑Muster mit einem dunkelorangefarbenen Vordergrund und einem weißen Hintergrund an und fügen Sie eine schwarze Textkontur mit einer Breite von 1 Pt hinzu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, PatternStyle, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)

    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern)
    dark_orange = Color(255, 140, 0)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(dark_orange)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE)
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid)

    portion.getPortionFormat().getLineFormat().setWidth(1)
    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
finally:
    presentation.dispose()
```

Der resultierende Text:

![The simple WordArt template](WordArt_template.png)

## **Weitere WordArt‑Effekte anwenden**

Die folgenden Beispiele zeigen, wie Sie Schatten, Reflexionen, Leuchten, Transformationen und 3D‑Effekte auf Text anwenden.

### **Äußere Schatten‑Effekte anwenden**

Ein äußerer Schatten verleiht Tiefe, indem er hinter dem Text platziert wird. Sie können Farbe, Richtung, Abstand, Unschärferadius, Skalierung und Schrägstellung anpassen.

Dieses Beispiel ruft [enableOuterShadowEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/effectformat/#enableOuterShadowEffect) auf und setzt einen schwarzen Schatten mit einem Unschärferadius von 4 Pt, einer Richtung von 230° und einem Abstand von 30 Pt. Skalierungswerte von 100 erhalten die Schattengröße, während eine horizontale Schrägstellung ihn um 20° neigt. Die Alpha‑Transformation setzt die Deckkraft auf 32 %:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, FontData, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)

    portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect()
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.BLACK)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(100)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(30)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(20)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32)
finally:
    presentation.dispose()
```

Der resultierende Text:

![The Outer Shadow effect](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Wenn äußere und vordefinierte Schatten zusammen verwendet werden, wird nur der äußere Schatten angewendet.
- Werden äußere und innere Schatten gleichzeitig verwendet, hängt das Ergebnis von der PowerPoint‑Version ab. In PowerPoint 2013 wird der Effekt verdoppelt, in PowerPoint 2007 wird nur der äußere Schatten angewendet.
{{% /alert %}}

### **Reflexions‑Effekte anwenden**

Eine Reflexion erzeugt eine gespiegelte Kopie des Textes. Position, Skalierung, Unschärfe und Deckkraft können angepasst werden, um das Aussehen zu steuern.

Dieses Beispiel ruft [enableReflectionEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/effectformat/#enableReflectionEffect) auf und spiegelt die Reflexion vertikal mit einer Skalierung von –100 %. Es verwendet einen Unschärferadius von 0,5 Pt und einen Abstand von 4,72 Pt. Die Deckkraft sinkt von 60 % auf 0,9 % zwischen den Positionen 0 % und 60 % entlang der Reflexion:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, RectangleAlignment, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)

    portion.getPortionFormat().getEffectFormat().enableReflectionEffect()
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(0)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(60)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(60)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(0.9)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.BottomLeft)
finally:
    presentation.dispose()
```

Der resultierende Text:

![The Reflection effect](reflection_effect.png)

### **Leuchten‑Effekte anwenden**

Ein Leuchten fügt dem Text eine weiche farbige Kontur hinzu. Farbe, Deckkraft und Radius können angepasst werden, um den Effekt zu steuern.

Dieses Beispiel ruft [enableGlowEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/effectformat/#enableGlowEffect) auf und wendet ein rotes Leuchten mit 54 % Deckkraft und einem Radius von 7 Pt an:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, FontData, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)

    portion.getPortionFormat().getEffectFormat().enableGlowEffect()
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setColor(Color.RED)
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54)
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7)
finally:
    presentation.dispose()
```

Der resultierende Text:

![The Glow effect](glow_effect.png)

### **WordArt‑Transformationen anwenden**

WordArt‑Transformationen biegen, dehnen oder verzerren einen Textblock.

Setzen Sie [setTransform](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframeformat/#setTransform) auf [ArchUpPour](https://reference.aspose.com/slides/de/python-java/aspose.slides/textshapetype/#ArchUpPour), um den gesamten Textrahmen nach oben zu biegen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, TextShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")
    text_frame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour)
finally:
    presentation.dispose()
```

Der resultierende Text:

![The WordArt transformation](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides für Python via Java bietet eine Reihe vordefinierter [Transformationstypen](https://reference.aspose.com/slides/de/python-java/aspose.slides/textshapetype/).
{{% /alert %}}

### **3D‑Effekte auf Formen und Text anwenden**

Sie können 3D‑Effekte sowohl auf eine Form als auch auf deren Text anwenden. Abschrägungen, Extrusion, Beleuchtung und Kameraeinstellungen steuern das Ergebnis.

Das folgende Beispiel verwendet [ThreeDFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/threedformat/), um dem Rechteck runde Abschrägungen, orangefarbene Extrusion und einen dunkelroten Kontur hinzuzufügen. Abschrägungs‑ und Extrusionsmaße, Konturbreite und Tiefe werden in Punkten angegeben. Ein Kunststoff‑Material, ausgeglichenes Licht, um 40° um die Z‑Achse gedreht, und eine perspektivische Kamera bestimmen das Aussehen:

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

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)
    auto_shape.getTextFrame().setText("Aspose.Slides")

    auto_shape.getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle)
    auto_shape.getThreeDFormat().getBevelBottom().setHeight(10.5)
    auto_shape.getThreeDFormat().getBevelBottom().setWidth(10.5)

    auto_shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    auto_shape.getThreeDFormat().getBevelTop().setHeight(12.5)
    auto_shape.getThreeDFormat().getBevelTop().setWidth(11)

    orange = Color(255, 165, 0)
    auto_shape.getThreeDFormat().getExtrusionColor().setColor(orange)
    auto_shape.getThreeDFormat().setExtrusionHeight(6)

    dark_red = Color(139, 0, 0)
    auto_shape.getThreeDFormat().getContourColor().setColor(dark_red)
    auto_shape.getThreeDFormat().setContourWidth(1.5)

    auto_shape.getThreeDFormat().setDepth(3)

    auto_shape.getThreeDFormat().setMaterial(MaterialPresetType.Plastic)

    auto_shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    auto_shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)
    auto_shape.getThreeDFormat().getLightRig().setRotation(0, 0, 40)

    auto_shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

Die resultierende Form:

![The shape 3D effect](shape_3D_effect.png)

Dieses Beispiel wendet eine ähnliche 3D‑Formatierung auf den Text über [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframeformat/#getThreeDFormat) an. Kleinere Abschrägungen formen die Buchstabenränder, während Extrusion und Beleuchtung dem Text Tiefe verleihen:

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

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)
    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")

    text_frame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle)
    text_frame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5)
    text_frame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5)

    text_frame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    text_frame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4)
    text_frame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4)

    orange = Color(255, 165, 0)
    text_frame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(orange)
    text_frame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6)

    dark_red = Color(139, 0, 0)
    text_frame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(dark_red)
    text_frame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5)

    text_frame.getTextFrameFormat().getThreeDFormat().setDepth(3)

    text_frame.getTextFrameFormat().getThreeDFormat().setMaterial(MaterialPresetType.Plastic)

    text_frame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    text_frame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)
    text_frame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40)

    text_frame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

Der resultierende Text:

![The text 3D effect](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
Die Anwendung von 3D‑Effekten auf Text oder deren Formen – und die Interaktion zwischen diesen Effekten – unterliegt bestimmten Regeln. Betrachten Sie ein Szenario, in dem sowohl Text als auch die ihn umgebende Form vorhanden sind. Ein 3D‑Effekt umfasst die 3D‑Darstellung des Objekts und die Szene, in der es platziert ist.

- Wenn für sowohl die Form als auch den Text eine Szene festgelegt ist, hat die Szene der Form Vorrang und die Szene des Textes wird ignoriert.
- Verfügt die Form nicht über eine eigene Szene, aber über eine 3D‑Darstellung, wird die Szene des Textes verwendet.
- Hat die Form überhaupt keinen 3D‑Effekt, wird sie als flach behandelt und der 3D‑Effekt wird nur auf den Text angewendet.

Diese Verhaltensweisen beziehen sich auf die Methoden [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/de/python-java/aspose.slides/threedformat/#getLightRig) und [ThreeDFormat.getCamera](https://reference.aspose.com/slides/de/python-java/aspose.slides/threedformat/#getCamera).
{{% /alert %}}

Um Text flach und lesbar zu halten und gleichzeitig die 3D‑Formatierung der Form beizubehalten, siehe [Keep Text Flat on a 3D Shape](/slides/de/python-java/3d-presentation/) für einen Vergleich beider Einstellungen und ein vollständiges Python‑Beispiel.

## **FAQ**

**Kann ich WordArt‑Effekte mit verschiedenen Schriften oder Skripten (z. B. Arabisch, Chinesisch) verwenden?**

Ja, Aspose.Slides für Python via Java unterstützt Unicode und funktioniert mit allen gängigen Schriften und Skripten. WordArt‑Effekte wie Schatten, Füllung und Kontur können unabhängig von der Sprache angewendet werden, wobei die Verfügbarkeit von Schriften und das Rendering vom System abhängen können.

**Kann ich WordArt‑Effekte auf Elemente der Folienmaster anwenden?**

Ja, Sie können WordArt‑Effekte auf Formen in Master‑Folien anwenden, einschließlich Titel‑Platzhaltern, Fußzeilen oder Hintergrundtext. Änderungen am Master‑Layout werden in allen zugehörigen Folien übernommen.

**Beeinflussen WordArt‑Effekte die Dateigröße der Präsentation?**

Leicht. WordArt‑Effekte wie Schatten, Leuchten und Farbverläufe können die Dateigröße geringfügig erhöhen, da zusätzliche Formatierungs‑Metadaten hinzugefügt werden, aber der Unterschied ist in der Regel vernachlässigbar.

**Kann ich das Ergebnis von WordArt‑Effekten anzeigen, ohne die Präsentation zu speichern?**

Ja, Sie können Folien, die WordArt enthalten, zu Bildern (z. B. PNG, JPEG) rendern mittels [Slide.getImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/slide/#getImage) oder einzelne Formen mit [Shape.getImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getImage). Damit können Sie das Ergebnis im Speicher oder auf dem Bildschirm prüfen, bevor Sie die gesamte Präsentation speichern oder exportieren.