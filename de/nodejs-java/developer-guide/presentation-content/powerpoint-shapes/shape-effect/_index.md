---
title: Formeffekte in Präsentationen mit JavaScript anwenden
linktitle: Formeffekt
type: docs
weight: 30
url: /de/nodejs-java/shape-effect/
keywords:
- Formeffekt
- Schatteneffekt
- Reflexionseffekt
- Leuchteffekt
- Weiche Kanten Effekt
- Effektformat
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Transformieren Sie Ihre PPT- und PPTX-Dateien mit fortschrittlichen Formeffekten mithilfe von JavaScript und Aspose.Slides für Node.js — erstellen Sie beeindruckende, professionelle Folien in Sekundenschnelle."
---
## **Einleitung**

Während Effekte in PowerPoint verwendet werden können, um eine Form hervorzuheben, unterscheiden sie sich von [Füllungen](/slides/de/nodejs-java/shape-formatting/#gradient-fill) oder Konturen. Mit PowerPoint‑Effekten können Sie überzeugende Spiegelungen einer Form erzeugen, den Schein einer Form verbreiten usw.

![Formeffekt](shape-effect.png)

PowerPoint stellt sechs Effekte bereit, die auf Formen angewendet werden können. Sie können einer Form einen oder mehrere Effekte zuweisen.

Einige Kombinationen von Effekten sehen besser aus als andere. Aus diesem Grund bietet PowerPoint Optionen unter **Preset**. Die Preset‑Optionen sind Kombinationen aus zwei oder mehr Effekten, die bekanntermaßen gut aussehen. Auf diese Weise müssen Sie beim Auswählen eines Presets keine Zeit damit verschwenden, verschiedene Effekte zu testen oder zu kombinieren, um eine passende Kombination zu finden.

Aspose.Slides stellt Eigenschaften und Methoden in der Klasse [EffectFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/) bereit, mit denen Sie dieselben Effekte auf Formen in PowerPoint‑Präsentationen anwenden können.

## **Einen Schatteneffekt anwenden**

Aspose.Slides für Node.js via Java unterstützt äußere und innere Schatten für Formen. Sie können deren Farbe, Richtung, Abstand und Weichzeichneradius an das Design Ihrer Präsentation anpassen.

### **Äußeren Schatten anwenden**

Verwenden Sie einen äußeren Schatten, um eine Karte oder ein Panel gegenüber dem Folienhintergrund hervorzuheben. Der Schatten erstreckt sich über die Kanten der Form hinaus und erzeugt den Eindruck, dass die Form über der Folie schwebt. Passen Sie deren Farbe, Richtung, Abstand und Weichzeichneradius an die Beleuchtung und das Styling Ihrer Vorlage an.

Dieser JavaScript‑Code zeigt, wie man den [äußeren Schatteneffekt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getOuterShadowEffect) auf ein Rechteck anwendet:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    const color = java.newInstanceSync("java.awt.Color", 169, 169, 169);
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(color);
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Schatteneffekt](shadow_effect.png)

#### **Steuerung der Schattenrichtung, wenn sich eine Form dreht**

Standardmäßig rotiert der äußere Schatten mit der Form. Um Formen mit unterschiedlichen Drehungen aus derselben Richtung beleuchtet erscheinen zu lassen, rufen Sie [setRotateShadowWithShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/outershadow/#setRotateShadowWithShape) mit `false` auf und verwenden Sie [setDirection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/outershadow/#setDirection), um ihren Schatten dieselbe Richtung zu geben.

Das Beispiel erzeugt zwei blaue Pfeile mit grauen Schatten, die um 42 Punkte nach rechts verschoben sind (0°). Anschließend wird die Folie dupliziert und beide Pfeile um 90° im Uhrzeigersinn gedreht.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const before = presentation.getSlides().get_Item(0);
    
    const left = before.getShapes().addAutoShape(aspose.slides.ShapeType.RightArrow, 55, 130, 110, 60);
    left.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 70, 130, 180);
    left.getFillFormat().getSolidFillColor().setColor(fillColor);
    left.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    left.getEffectFormat().enableOuterShadowEffect();
    const shadow = left.getEffectFormat().getOuterShadowEffect();
    const shadowColor = java.getStaticFieldValue("java.awt.Color", "GRAY");
    shadow.getShadowColor().setColor(shadowColor);
    shadow.setDirection(0);
    shadow.setDistance(42);
    shadow.setBlurRadius(0);
    shadow.setRotateShadowWithShape(true);

    const right = before.getShapes().addClone(left);
    right.setX(395);
    right.getEffectFormat().getOuterShadowEffect().setRotateShadowWithShape(false);

    const after = presentation.getSlides().addClone(before);
    const arrows = after.getShapes();
    for (let i = 0; i < arrows.size(); i++) {
        arrows.get_Item(i).setRotation(90);
    }

    presentation.save("arrow_shadows.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Auf der zweiten Folie wirft der linke Pfeil seinen Schatten nach unten, während der rechte Pfeil seinen Schatten weiterhin nach rechts wirft. Die konfigurierte Richtung bleibt für beide Schatten bei 0°.

![PowerPoint-Darstellung vor und nach einer 90°-Drehung. Beide Schatten beginnen rechts. Nach der Drehung bewegt sich der Schatten unter den linken Pfeil und bleibt rechts vom rechten Pfeil.](arrow-shadow-rotation.png)

### **Inneren Schatten anwenden**

Wenn Sie das visuelle Design einer Vorlage nachbilden, verwenden Sie einen inneren Schatten, um einer Karte oder einem Panel ein vertieftes Aussehen zu verleihen. Ein äußerer Schatten erstreckt sich außerhalb der Form und lässt sie erhaben wirken, während ein innerer Schatten die Innenseiten ihrer Konturen schattiert.

Rufen Sie [enableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enableInnerShadowEffect) auf und konfigurieren Sie anschließend den von [getInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getInnerShadowEffect) zurückgegebenen Schatten. Größere Werte für den Weichzeichneradius erzeugen weichere Kanten.

Dieses JavaScript‑Beispiel erstellt eine hellblaue Karte mit einem dunkelgrauen inneren Schatten und speichert sie als PPTX‑Datei. Die Schattenrichtung beträgt 225 Grad, der Abstand beträgt 7 Punkte und der Weichzeichneradius beträgt 6 Punkte:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 173, 216, 230);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    shape.getEffectFormat().enableInnerShadowEffect();
    const shadow = shape.getEffectFormat().getInnerShadowEffect();
    const color = java.newInstanceSync("java.awt.Color", 105, 105, 105);
    shadow.getShadowColor().setColor(color);
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Hellblaues Rechteck mit innerem Schatten](inner_shadow_effect.png)

Um den inneren Schatten zu entfernen, rufen Sie [disableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableInnerShadowEffect) im Effektformat der Form auf.

### **Preset‑Schatten anwenden, ändern und entfernen**

Rufen Sie [enablePresetShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enablePresetShadowEffect) auf und verwenden Sie [setPreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presetshadow/#setPreset), um einen [PresetShadowType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presetshadowtype/) auszuwählen. Um den Stil zu wechseln, ändern Sie das Preset an derselben Form. Rufen Sie [disablePresetShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disablePresetShadowEffect) auf, um den Schatten zu entfernen und dabei die Füllung und Kontur beizubehalten.

Dieses Beispiel zeigt vier Stufen nebeneinander auf einer Folie. Beide Schatten sind um 10 Punkte versetzt. Eine Richtung von 225° positioniert den ersten Schatten oberhalb und links vom Rechteck, und 45° positioniert den zweiten darunter und rechts.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(800, 120, aspose.slides.SlideSizeScaleType.DoNotScale);
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const shape = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 15, 30, 170, 60);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 70, 130, 180);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const lineColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(lineColor);
    shape.getTextFrame().setText("No shadow");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shape.getEffectFormat().enablePresetShadowEffect();
    const shadow = shape.getEffectFormat().getPresetShadowEffect();
    shadow.setPreset(aspose.slides.PresetShadowType.TopLeftDropShadow);
    shadow.setDistance(10);
    shadow.setDirection(225);
    shape.getTextFrame().setText("TopLeftDropShadow");
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shadow.setPreset(aspose.slides.PresetShadowType.BottomRightDropShadow);
    shadow.setDirection(45);
    shape.getTextFrame().setText("BottomRightDropShadow");
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shape.getEffectFormat().disablePresetShadowEffect();
    shape.getTextFrame().setText("No shadow");

    presentation.save("preset_shadows.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Original | Erstes Preset | Zweites Preset | Nach Entfernung |
| :---: | :---: | :---: | :---: |
| ![Kein Schatten](preset_shadow_original.png) | ![ObenLinksDropShadow](preset_shadow_top_left.png) | ![UntenRechtsDropShadow](preset_shadow_bottom_right.png) | ![Kein Schatten nach Entfernung](preset_shadow_removed.png) |

## **Reflexionseffekt anwenden**

Um einen Reflexionseffekt in Aspose.Slides für Node.js via Java anzuwenden, können Sie Formen einen spiegelartigen Reflexionseffekt hinzufügen und Parameter wie Abstand, Transparenz und Größe anpassen. Dieser Effekt verbessert die Ästhetik Ihrer Präsentationen, indem er Formen ein polierteres und anspruchsvolleres Aussehen verleiht. Er lässt sich mit einfachem Code leicht implementieren, wodurch eine schnelle Anwendung auf mehrere Elemente für ein konsistentes Design möglich ist.

Dieser JavaScript‑Code zeigt, wie man den [reflection effect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getReflectionEffect) auf eine Form anwendet:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(java.newByte(aspose.slides.RectangleAlignment.Bottom));
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(40);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2);

    presentation.save("reflection_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Reflexionseffekt](reflection_effect.png)

## **Leuchteffekt anwenden**

Um einen Leuchteffekt auf eine Form in Aspose.Slides für Node.js via Java anzuwenden, können Sie eine weiche, leuchtende Aura um Formen hinzufügen und Eigenschaften wie Farbe und Größe anpassen. Dieser Effekt hilft, Formen hervorzuheben und verleiht Ihrer Präsentation ein attraktives, auffälliges visuelles Element. Er lässt sich mit minimalem Code leicht implementieren und verbessert das Gesamtbild Ihrer Folien.

Dieser JavaScript‑Code zeigt, wie man den [glow effect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getGlowEffect) auf eine Form anwendet:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableGlowEffect();
    const color = java.getStaticFieldValue("java.awt.Color", "MAGENTA");
    shape.getEffectFormat().getGlowEffect().getColor().setColor(color);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    presentation.save("glow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Leuchteffekt](glow_effect.png)

## **Weiche Kanten‑Effekt anwenden**

Um einen weichen Kanten‑Effekt in Aspose.Slides für Node.js via Java anzuwenden, können Sie einen glatten, unscharfen Übergang um die Kanten einer Form erzeugen. Dieser Effekt verleiht ein subtileres und raffinierteres Aussehen, ideal für Designs, die ein sanftes, weicheres Erscheinungsbild benötigen. Sie können Parameter wie den Radius leicht anpassen, um den gewünschten Effekt über verschiedene Formen in Ihrer Präsentation zu erzielen.

Dieser JavaScript‑Code zeigt, wie man den [soft edges effect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getSoftEdgeEffect) auf eine Form anwendet:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8);

    presentation.save("soft_edges_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Weiche Kanten Effekt](soft_edges_effect.png)

## **Weichzeichner‑Effekt anwenden**

Verwenden Sie Form‑Weichzeichnen, um die Füllung und Kontur einer Form zu mildern, während die Form editierbar bleibt. Rufen Sie [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect) im Effektformat der Form auf. Der Radius wird in Punkten (1/72 Zoll) gemessen: Verwenden Sie einen nicht‑negativen Wert; größere Werte erzeugen einen stärkeren Weichzeichner. Ein Radius von Null lässt das Aussehen unverändert.

Die [getGrow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blur/#getGrow)-Einstellung steuert die sichtbaren Grenzen des Effekts. Bei `false` wird der Weichzeichner auf die ursprünglich gemalten Grenzen, einschließlich der Kontur, beschränkt. Bei `true` kann der Weichzeichner über diese Grenzen hinausgehen. Keine der beiden Einstellungen ändert die Position oder Abmessungen der Form.

Der Vergleich unten verwendet durchgehend dieselbe Füllung, Kontur und Formabmessungen. Die obere Zeile verwendet `grow = false`; die untere Zeile verwendet `grow = true`.

![Originales Rechteck im Vergleich mit Weichzeichner‑Radien von 5 und 15 Punkten, bei deaktiviertem und aktiviertem Grow](shape_blur_comparison.png)

Dieses JavaScript‑Beispiel erstellt ein orangefarbenes Rechteck mit einer dunkelblauen Kontur, wendet einen 5‑Punkte‑Weichzeichner an und aktualisiert es anschließend auf einen 15‑Punkte‑Weichzeichner, indem es [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect) erneut aufruft. Es speichert beide weichgezeichneten Zustände, ruft dann [disableBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableBlurEffect) auf und speichert die Form ohne Weichzeichnen.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const lineColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(lineColor);
    shape.getLineFormat().setWidth(8);

    shape.getEffectFormat().setBlurEffect(5, false);
    presentation.save("shape_blur_5.pptx", aspose.slides.SaveFormat.Pptx);

    shape.getEffectFormat().setBlurEffect(15, true);
    presentation.save("shape_blur_15.pptx", aspose.slides.SaveFormat.Pptx);

    shape.getEffectFormat().disableBlurEffect();
    presentation.save("shape_blur_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Form‑Weichzeichnen beeinflusst sowohl Füllung als auch Kontur. Ein weicher Kanten‑Effekt verblasst die Kanten der Form, während Schatten‑Weichzeichnen nur den Schatten mildert. Bild‑Transformations‑Effekte wirken auf Bildinhalte; dieses Beispiel wendet den Weichzeichner direkt auf das Effektformat der Form an, ohne die Form in ein Bild zu konvertieren.

## **FAQ**

**Kann ich mehrere Effekte auf dieselbe Form anwenden?**

Ja, Sie können verschiedene Effekte, wie Schatten, Reflexion und Leuchten, auf einer einzelnen Form kombinieren, um ein dynamischeres Aussehen zu erzeugen.

**Auf welche Formen kann ich Effekte anwenden?**

Sie können Effekte auf verschiedene Formen anwenden, darunter Autoshapes, Diagramme, Tabellen, Bilder, SmartArt‑Objekte, OLE‑Objekte und mehr.

**Kann ich Effekte auf gruppierte Formen anwenden?**

Ja, Sie können Effekte auf gruppierte Formen anwenden. Der Effekt wird auf die gesamte Gruppe angewendet.