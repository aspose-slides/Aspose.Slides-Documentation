---
title: "Anwenden von Formeffekten in Präsentationen mit Java"
linktitle: "Formeffekt"
type: docs
weight: 30
url: /de/java/shape-effect/
keywords:
  - "Formeffekt"
  - "Schatteneffekt"
  - "Reflexionseffekt"
  - "Leuchteffekt"
  - "Weiche Kanten Effekt"
  - "Effektformat"
  - "PowerPoint"
  - "Präsentation"
  - "Java"
  - "Aspose.Slides"
description: "Transformieren Sie Ihre PPT- und PPTX-Dateien mit fortschrittlichen Formeffekten mithilfe von Aspose.Slides für Java – erstellen Sie beeindruckende, professionelle Folien in Sekunden."
---
## **Einleitung**

Während Effekte in PowerPoint verwendet werden können, um eine Form hervorzustellen, unterscheiden sie sich von [Füllungen](/slides/de/java/shape-formatting/#gradient-fill) oder Konturen. Mit PowerPoint‑Effekten können Sie überzeugende Spiegelungen einer Form erzeugen, das Leuchten einer Form verbreiten usw.

![Shape effect](shape-effect.png)

PowerPoint bietet sechs Effekte, die auf Formen angewendet werden können. Sie können einer Form einen oder mehrere Effekte zuweisen.

Einige Kombinationen von Effekten sehen besser aus als andere. Aus diesem Grund stellt PowerPoint Optionen unter **Preset** bereit. Die Preset‑Optionen sind Kombinationen aus zwei oder mehr Effekten, von denen bekannt ist, dass sie gut aussehen. So müssen Sie beim Auswählen eines Presets nicht Zeit damit verschwenden, verschiedene Effekte zu testen oder zu kombinieren, um eine passende Kombination zu finden.

Aspose.Slides bietet Eigenschaften und Methoden in der Klasse [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/), mit denen Sie dieselben Effekte auf Formen in PowerPoint‑Präsentationen anwenden können.

## **Einen Schatteneffekt anwenden**

Aspose.Slides für Java unterstützt äußere und innere Schatten für Formen. Sie können deren Farbe, Richtung, Abstand und Weichzeichnungsradius an das Design Ihrer Präsentation anpassen.

### **Einen äußeren Schatten anwenden**

Verwenden Sie einen äußeren Schatten, um eine Karte oder ein Panel vor dem Folienhintergrund hervorzuheben. Der Schatten erstreckt sich über die Kanten der Form hinaus und erzeugt den Eindruck, dass die Form über der Folie schwebt. Passen Sie Farbe, Richtung, Abstand und Weichzeichnungsradius an die Beleuchtung und das Styling Ihrer Vorlage an.

Dieser Java‑Code zeigt, wie man den [outer shadow effect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getOuterShadowEffect--) auf ein Rechteck anwendet:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(new Color(169, 169, 169));
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Shadow effect](shadow_effect.png)

#### **Die Schattenrichtung steuern, wenn sich eine Form dreht**

Standardmäßig rotiert der äußere Schatten mit der Form. Um Formen mit unterschiedlichen Drehungen aus derselben Richtung beleuchtet erscheinen zu lassen, rufen Sie [setRotateShadowWithShape](https://reference.aspose.com/slides/java/com.aspose.slides/ioutershadow/#setRotateShadowWithShape-boolean-) mit `false` auf und verwenden Sie [setDirection](https://reference.aspose.com/slides/java/com.aspose.slides/ioutershadow/#setDirection-float-), um den Schatten dieselbe Richtung zu geben.

Das Beispiel erstellt zwei blaue Pfeile mit grauen Schatten, die um 42 Punkte nach rechts (0°) versetzt sind. Anschließend wird die Folie dupliziert und beide Pfeile um 90° im Uhrzeigersinn gedreht.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide before = presentation.getSlides().get_Item(0);

    IAutoShape left = before.getShapes().addAutoShape(ShapeType.RightArrow, 55, 130, 110, 60);
    left.getFillFormat().setFillType(FillType.Solid);
    left.getFillFormat().getSolidFillColor().setColor(new Color(70, 130, 180));
    left.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    left.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = left.getEffectFormat().getOuterShadowEffect();
    shadow.getShadowColor().setColor(Color.GRAY);
    shadow.setDirection(0);
    shadow.setDistance(42);
    shadow.setBlurRadius(0);
    shadow.setRotateShadowWithShape(true);

    IShape right = before.getShapes().addClone(left);
    right.setX(395);
    right.getEffectFormat().getOuterShadowEffect().setRotateShadowWithShape(false);

    ISlide after = presentation.getSlides().addClone(before);
    for (IShape arrow : after.getShapes()) {
        arrow.setRotation(90);
    }

    presentation.save("arrow_shadows.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Auf der zweiten Folie wirft der linke Pfeil seinen Schatten nach unten, während der rechte Pfeil seinen Schatten weiterhin nach rechts wirft. Die konfigurierte Richtung bleibt für beide Schatten bei 0°.

![PowerPoint rendering before and after a 90° rotation. Both shadows start on the right. After rotation, the shadow moves below the left arrow and stays to the right of the right arrow.](arrow-shadow-rotation.png)

### **Einen inneren Schatten anwenden**

Wenn Sie das visuelle Styling einer Vorlage reproduzieren, verwenden Sie einen inneren Schatten, um einer Karte oder einem Panel ein vertieftes Aussehen zu verleihen. Ein äußerer Schatten erstreckt sich außerhalb der Form und lässt sie erhöht erscheinen, während ein innerer Schatten die Innenseiten ihrer Kanten abdunkelt.

Rufen Sie [enableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#enableInnerShadowEffect--) auf und konfigurieren Sie den Schatten, der von [getInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getInnerShadowEffect--) zurückgegeben wird. Größere Werte für den Weichzeichnungsradius erzeugen weichere Kanten.

Dieses Java‑Beispiel erstellt eine hellblaue Karte mit einem dunkelgrauen inneren Schatten und speichert sie als PPTX‑Datei. Die Schattenrichtung beträgt 225 Grad, der Abstand 7 Punkte und der Weichzeichnungsradius 6 Punkte:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(173, 216, 230));
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    shape.getEffectFormat().enableInnerShadowEffect();
    IInnerShadow shadow = shape.getEffectFormat().getInnerShadowEffect();
    shadow.getShadowColor().setColor(new Color(105, 105, 105));
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Light blue rectangle with an inner shadow](inner_shadow_effect.png)

Um den inneren Schatten zu entfernen, rufen Sie [disableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#disableInnerShadowEffect--) auf dem Effektformat der Form auf.

### **Ein voreingestelltes Schattenformat anwenden, ändern und entfernen**

Rufen Sie [enablePresetShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#enablePresetShadowEffect--) auf und verwenden Sie [setPreset](https://reference.aspose.com/slides/java/com.aspose.slides/ipresetshadow/#setPreset-int-), um einen [PresetShadowType](https://reference.aspose.com/slides/java/com.aspose.slides/presetshadowtype/) auszuwählen. Um den Stil zu wechseln, ändern Sie das Preset derselben Form. Rufen Sie [disablePresetShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disablePresetShadowEffect--) auf, um den Schatten zu entfernen und dabei Füllung und Kontur zu erhalten.

Dieses Beispiel zeigt vier Stufen nebeneinander auf einer Folie. Beide Schatten sind um 10 Punkte versetzt. Eine Richtung von 225° platziert den ersten Schatten oben links vom Rechteck, und 45° platziert den zweiten unten rechts.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(800, 120, SlideSizeScaleType.DoNotScale);
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IAutoShape shape = shapes.addAutoShape(ShapeType.Rectangle, 15, 30, 170, 60);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(70, 130, 180));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
    shape.getTextFrame().setText("No shadow");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shape.getEffectFormat().enablePresetShadowEffect();
    IPresetShadow shadow = shape.getEffectFormat().getPresetShadowEffect();
    shadow.setPreset(PresetShadowType.TopLeftDropShadow);
    shadow.setDistance(10);
    shadow.setDirection(225);
    shape.getTextFrame().setText("TopLeftDropShadow");
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shadow.setPreset(PresetShadowType.BottomRightDropShadow);
    shadow.setDirection(45);
    shape.getTextFrame().setText("BottomRightDropShadow");
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shape.getEffectFormat().disablePresetShadowEffect();
    shape.getTextFrame().setText("No shadow");

    presentation.save("preset_shadows.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Original | Erstes Preset | Zweites Preset | Nach Entfernung |
| :---: | :---: | :---: | :---: |
| ![No shadow](preset_shadow_original.png) | ![TopLeftDropShadow](preset_shadow_top_left.png) | ![BottomRightDropShadow](preset_shadow_bottom_right.png) | ![No shadow after removal](preset_shadow_removed.png) |

## **Einen Reflexionseffekt anwenden**

Um einen Reflexionseffekt in Aspose.Slides für Java anzuwenden, können Sie einer Form eine spiegelnde Reflexion hinzufügen und Parameter wie Abstand, Transparenz und Größe anpassen. Dieser Effekt verbessert das ästhetische Erscheinungsbild Ihrer Präsentationen, indem er Formen ein polierteres und anspruchsvolleres Aussehen verleiht. Die Implementierung ist einfach und ermöglicht eine schnelle Anwendung über mehrere Elemente hinweg für ein konsistentes Design.

Dieser Java‑Code zeigt, wie man den [reflection effect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getReflectionEffect--) auf eine Form anwendet:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom);
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(40);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2);

    presentation.save("reflection_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Reflection effect](reflection_effect.png)

## **Einen Leuchteffekt anwenden**

Um einen Leuchteffekt auf eine Form in Aspose.Slides für Java anzuwenden, können Sie eine weiche, leuchtende Aura um Formen hinzufügen und Eigenschaften wie Farbe und Größe anpassen. Dieser Effekt lässt Formen hervortreten und verleiht Ihrer Präsentation ein attraktives, auffälliges visuelles Element. Die Implementierung ist mit minimalem Codeaufwand einfach und verbessert das Gesamtbild Ihrer Folien.

Dieser Java‑Code zeigt, wie man den [glow effect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getGlowEffect--) auf eine Form anwendet:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableGlowEffect();
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    presentation.save("glow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Glow effect](glow_effect.png)

## **Einen Weiche‑Kanten‑Effekt anwenden**

Um einen Weiche‑Kanten‑Effekt in Aspose.Slides für Java anzuwenden, können Sie einen sanften, verschwommenen Übergang um die Ränder einer Form erzeugen. Dieser Effekt verleiht ein dezenteres und raffinierteres Aussehen, ideal für Designs, die ein sanftes, weicheres Erscheinungsbild benötigen. Sie können Parameter wie den Radius leicht anpassen, um den gewünschten Effekt über verschiedene Formen Ihrer Präsentation hinweg zu erzielen.

Dieser Java‑Code zeigt, wie man den [soft edges effect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getSoftEdgeEffect--) auf eine Form anwendet:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8);

    presentation.save("soft_edges_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Soft edges effect](soft_edges_effect.png)

## **Einen Weichzeichner‑Effekt anwenden**

Verwenden Sie den Form‑Weichzeichner, um die Füllung und Kontur einer Form zu verwischen, während die Form editierbar bleibt. Rufen Sie [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) auf dem Effektformat der Form auf. Der Radius wird in Punkten (1/72 Zoll) gemessen: Verwenden Sie einen nicht‑negativen Wert, wobei größere Werte einen stärkeren Weichzeichner erzeugen. Ein Radius von 0 lässt das Aussehen unverändert.

Die Einstellung [getGrow](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/#getGrow--) steuert die sichtbaren Grenzen des Effekts. Bei `false` wird der Weichzeichner auf die ursprünglich gemalten Grenzen, einschließlich der Kontur, beschränkt. Bei `true` kann der Weichzeichner über diese Grenzen hinausreichen. Keine der beiden Einstellungen verändert die Position oder Größe der Form.

Der Vergleich unten verwendet durchgehend dieselbe Füllung, Kontur und Formabmessungen. Die obere Zeile verwendet `grow = false`; die untere Zeile verwendet `grow = true`.

![Original rectangle compared with blur radii of 5 and 15 points, with grow disabled and enabled](shape_blur_comparison.png)

Dieses Java‑Beispiel erstellt ein orangefarbenes Rechteck mit einer dunkelblauen Kontur, wendet einen Weichzeichner von 5 Punkten an und aktualisiert es anschließend auf einen Weichzeichner von 15 Punkten, indem es erneut [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) aufruft. Beide verwischten Zustände werden gespeichert, dann wird [disableBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disableBlurEffect--) aufgerufen und die Form ohne Weichzeichner gespeichert.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
    shape.getLineFormat().setWidth(8);

    shape.getEffectFormat().setBlurEffect(5, false);
    presentation.save("shape_blur_5.pptx", SaveFormat.Pptx);

    shape.getEffectFormat().setBlurEffect(15, true);
    presentation.save("shape_blur_15.pptx", SaveFormat.Pptx);

    shape.getEffectFormat().disableBlurEffect();
    presentation.save("shape_blur_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Form‑Weichzeichner wirkt sich gleichzeitig auf Füllung und Kontur aus. Ein Weiche‑Kanten‑Effekt verwischt die Ränder der Form, während ein Schatten‑Weichzeichner nur den Schatten verwischt. Bild‑Transformations‑Effekte arbeiten am Bildinhalt; dieses Beispiel wendet den Weichzeichner direkt auf das Effektformat der Form an, ohne die Form in ein Bild zu konvertieren.

## **FAQ**

**Kann ich mehrere Effekte auf dieselbe Form anwenden?**

Ja, Sie können verschiedene Effekte, wie Schatten, Reflexion und Leuchteffekt, auf einer einzelnen Form kombinieren, um ein dynamischeres Aussehen zu erzielen.

**Auf welche Formen kann ich Effekte anwenden?**

Sie können Effekte auf verschiedene Formen anwenden, einschließlich Autoformen, Diagrammen, Tabellen, Bildern, SmartArt‑Objekten, OLE‑Objekten und mehr.

**Kann ich Effekte auf gruppierte Formen anwenden?**

Ja, Sie können Effekte auf gruppierte Formen anwenden. Der Effekt wird auf die gesamte Gruppe angewendet.