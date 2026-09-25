---
title: "Erstellen und Anwenden von WordArt‑Effekten in Node.js"
linktitle: "WordArt"
type: docs
weight: 110
url: /de/nodejs-java/wordart/
keywords:
- WordArt
- WordArt erstellen
- WordArt‑Vorlage
- WordArt‑Effekt
- Schatten‑Effekt
- Reflexions‑Effekt
- Leuchte‑Effekt
- WordArt‑Transformation
- 3D‑Effekt
- äußerer Schatten‑Effekt
- innerer Schatten‑Effekt
- Node.js
- JavaScript
- Aspose.Slides
description: "Erstellen und Anpassen von WordArt‑Effekten in Aspose.Slides für Node.js via Java. Diese Schritt‑für‑Schritt‑Anleitung hilft Entwicklern, Präsentationen mit professionellem Text in Node.js zu verbessern."
---
## **Übersicht**

WordArt‑Effekte ermöglichen das Gestalten von Text mit Füllungen, Konturen, Schatten, Reflexionen, Leuchteffekten, Transformationen und 3D‑Formatierung. Dieser Artikel erklärt, wie diese Effekte in PowerPoint-Präsentationen mithilfe von Aspose.Slides für Node.js via Java erstellt und angepasst werden können, ohne dass Microsoft Office installiert ist.

## **Einfaches WordArt‑Template erstellen und auf Text anwenden**

Die folgenden Beispiele erstellen einen einfachen WordArt‑Stil, indem sie Text, Schriftart, Musterfüllung und Kontur festlegen.

Jedes Beispiel erstellt eine neue Präsentation und fügt ihrer ersten Folie ein Rechteck hinzu; eine Eingabedatei ist nicht erforderlich. Das erste Beispiel setzt den Text auf "Aspose.Slides". Die Position und Abmessungen der Form werden in Punkten gemessen:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);
    const textFrame = autoShape.getTextFrame();

    const portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    presentation.dispose();
}
```

Setze die Schriftart auf Arial Black mit 36 Punkten, um die Formatierung deutlicher zu machen:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);
} finally {
    presentation.dispose();
}
```

Wende ein [SmallGrid](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/patternstyle/#SmallGrid) Muster mit einem dunkelorangenen Vordergrund und einem weißen Hintergrund an und füge anschließend eine schwarze Textkontur mit einer Breite von 1 Punkt hinzu:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
    const darkOrange = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(darkOrange);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.SmallGrid));

    portion.getPortionFormat().getLineFormat().setWidth(1);
    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
} finally {
    presentation.dispose();
}
```

Der resultierende Text:

![The simple WordArt template](WordArt_template.png)

## **Weitere WordArt‑Effekte anwenden**

Die folgenden Beispiele zeigen, wie Schatten, Reflexionen, Leuchteffekte, Transformationen und 3D‑Effekte auf Text angewendet werden.

### **Äußere Schatteneffekte anwenden**

Ein äußerer Schatten verleiht Tiefe, indem er einen Schatten hinter dem Text platziert. Sie können seine Farbe, Richtung, Entfernung, Unschärferadius, Skalierung und Schrägstellung anpassen.

Dieses Beispiel ruft [enableOuterShadowEffect](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/effectformat/#enableOuterShadowEffect) auf und legt einen schwarzen Schatten mit einem Unschärferadius von 4 Punkten, einer Richtung von 230 Grad und einer Entfernung von 30 Punkten fest. Skalierungswerte von 100 erhalten die Schattengröße, während die horizontale Schrägstellung ihn um 20 Grad kippt. Die Alpha‑Transformation setzt die Deckkraft auf 32 %:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(30);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(20);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, java.newFloat(0.32));
} finally {
    presentation.dispose();
}
```

Der resultierende Text:

![The Outer Shadow effect](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Wenn äußere und voreingestellte Schatten zusammen verwendet werden, wird nur der äußere Schatten angewendet.
- Wenn äußere und innere Schatten gleichzeitig verwendet werden, hängt der resultierende Effekt von der PowerPoint‑Version ab. Beispiel: In PowerPoint 2013 wird der Effekt verdoppelt, während in PowerPoint 2007 nur der äußere Schatten angewendet wird.
{{% /alert %}}

### **Reflexionseffekte anwenden**

Eine Reflexion erzeugt eine gespiegelte Kopie des Textes. Passen Sie Position, Skalierung, Unschärfe und Deckkraft an, um das Erscheinungsbild zu steuern.

Dieses Beispiel ruft [enableReflectionEffect](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/effectformat/#enableReflectionEffect) auf und spiegelt die Reflexion vertikal mit einer Skalierung von -100 %. Es verwendet einen Unschärferadius von 0.5 Punkt und eine Entfernung von 4.72 Punkt. Die Deckkraft nimmt von 60 % auf 0.9 % zwischen den Positionen 0 % und 60 % entlang der Reflexion ab:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableReflectionEffect();
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(java.newFloat(0));
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(java.newFloat(60));
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(java.newFloat(60));
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(java.newFloat(0.9));
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(java.newByte(aspose.slides.RectangleAlignment.BottomLeft));
} finally {
    presentation.dispose();
}
```

Der resultierende Text:

![The Reflection effect](reflection_effect.png)

### **Leuchteffekte anwenden**

Ein Leuchteffekt fügt dem Text eine sanfte farbige Kontur hinzu. Passen Sie Farbe, Deckkraft und Radius an, um den Effekt zu steuern.

Dieses Beispiel ruft [enableGlowEffect](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/effectformat/#enableGlowEffect) auf und wendet ein rotes Leuchten mit 54 % Deckkraft und einem Radius von 7 Punkten an:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableGlowEffect();
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, java.newFloat(0.54));
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
} finally {
    presentation.dispose();
}
```

Der resultierende Text:

![The Glow effect](glow_effect.png)

### **WordArt‑Transformationen anwenden**

WordArt‑Transformationen biegen, strecken oder verzerren einen Textblock.

Setzen Sie [setTransform](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframeformat/#setTransform) auf [ArchUpPour](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textshapetype/#ArchUpPour), um den gesamten Textrahmen nach oben zu krümmen:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");
    textFrame.getTextFrameFormat().setTransform(java.newByte(aspose.slides.TextShapeType.ArchUpPour));
} finally {
    presentation.dispose();
}
```

Der resultierende Text:

![The WordArt transformation](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides für Node.js via Java stellt eine Menge vordefinierter [Transformationstypen](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textshapetype/) bereit.
{{% /alert %}}

### **3D‑Effekte auf Formen und Text anwenden**

Sie können 3D‑Effekte auf eine Form oder deren Text anwenden. Abschrägungen, Extrusion, Beleuchtung und Kameraeinstellungen bestimmen das resultierende Aussehen.

Das folgende Beispiel verwendet [ThreeDFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/threedformat/) , um dem Rechteck kreisförmige Abschrägungen, orangefarbene Extrusion und eine dunkelrote Kontur hinzuzufügen. Die Abschrägungsmaße, Extrusionshöhe, Konturbreite und Tiefe werden in Punkten gemessen. Ein Kunststoffmaterial, ausgewogene Beleuchtung, um 40 Grad um die Z‑Achse rotiert, und eine Perspektivkamera definieren das Aussehen:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);
    autoShape.getTextFrame().setText("Aspose.Slides");

    autoShape.getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
    autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);

    autoShape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
    autoShape.getThreeDFormat().getBevelTop().setWidth(11);

    const orange = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    autoShape.getThreeDFormat().getExtrusionColor().setColor(orange);
    autoShape.getThreeDFormat().setExtrusionHeight(6);

    const darkRed = java.newInstanceSync("java.awt.Color", 139, 0, 0);
    autoShape.getThreeDFormat().getContourColor().setColor(darkRed);
    autoShape.getThreeDFormat().setContourWidth(1.5);

    autoShape.getThreeDFormat().setDepth(3);

    autoShape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);

    autoShape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
    autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

Der resultierende Form:

![The shape 3D effect](shape_3D_effect.png)

Dieses Beispiel wendet eine ähnliche 3D‑Formatierung auf den Text mittels [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) an. Kleinere Abschrägungen formen die Buchstabenränder, während Extrusion und Beleuchtung dem Text Tiefe verleihen:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);
    const textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);

    const orange = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(orange);
    textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

    const darkRed = java.newInstanceSync("java.awt.Color", 139, 0, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(darkRed);
    textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);

    textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);

    textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);

    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

Der resultierende Text:

![The text 3D effect](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
Die Anwendung von 3D‑Effekten auf Text oder deren Formen – und die Interaktion zwischen diesen Effekten – wird durch spezifische Regeln gesteuert. Betrachten Sie eine Szene, die sowohl den Text als auch die Form, die ihn enthält, beinhaltet. Ein 3D‑Effekt umfasst die 3D‑Darstellung des Objekts und die Szene, in der es platziert ist.

- Wenn für sowohl die Form als auch den Text eine Szene festgelegt ist, hat die Szene der Form Vorrang und die Szene des Textes wird ignoriert.
- Wenn die Form keine eigene Szene hat, aber eine 3D‑Darstellung besitzt, wird die Szene des Textes verwendet.
- Wenn die Form überhaupt keinen 3D‑Effekt hat, wird sie als flach behandelt und der 3D‑Effekt wird nur auf den Text angewendet.

Diese Verhaltensweisen beziehen sich auf die Methoden [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/threedformat/#getLightRig) und [ThreeDFormat.getCamera](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/threedformat/#getCamera).
{{% /alert %}}

Um den Text flach und lesbar zu halten, während die 3D‑Formatierung der Form beibehalten wird, siehe [Keep Text Flat on a 3D Shape](/slides/de/nodejs-java/3d-presentation/) für einen Vergleich beider Einstellungen und ein vollständiges JavaScript‑Beispiel.

## **FAQ**

**Kann ich WordArt‑Effekte mit verschiedenen Schriftarten oder Skripten (z. B. Arabisch, Chinesisch) verwenden?**

Ja, Aspose.Slides für Node.js via Java unterstützt Unicode und funktioniert mit allen gängigen Schriftarten und Skripten. WordArt‑Effekte wie Schatten, Füllung und Kontur können unabhängig von der Sprache angewendet werden, wobei die Verfügbarkeit und Darstellung von Schriftarten von den Systemschriftarten abhängen kann.

**Kann ich WordArt‑Effekte auf Elemente des Folienmasters anwenden?**

Ja, Sie können WordArt‑Effekte auf Formen in Masterfolien anwenden, einschließlich Titel‑Platzhaltern, Fußzeilen oder Hintergrundtext. Änderungen am Master‑Layout werden auf alle zugehörigen Folien übertragen.

**Beeinflussen WordArt‑Effekte die Dateigröße der Präsentation?**

Leicht. WordArt‑Effekte wie Schatten, Leuchteffekte und Farbverlauf‑Füllungen können die Dateigröße aufgrund zusätzlicher Formatierungs‑Metadaten geringfügig erhöhen, jedoch ist der Unterschied in der Regel vernachlässigbar.

**Kann ich das Ergebnis von WordArt‑Effekten ansehen, ohne die Präsentation zu speichern?**

Ja, Sie können Folien mit WordArt in Bilder (z. B. PNG, JPEG) rendern, indem Sie [Slide.getImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slide/#getImage) verwenden, oder einzelne Formen mit [Shape.getImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shape/#getImage) rendern. So können Sie das Ergebnis im Speicher oder auf dem Bildschirm ansehen, bevor Sie die gesamte Präsentation speichern oder exportieren.