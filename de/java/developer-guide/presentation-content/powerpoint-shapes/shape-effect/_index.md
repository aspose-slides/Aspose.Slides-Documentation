---
title: Formeffekte in Präsentationen mit Java anwenden
linktitle: Formeffekt
type: docs
weight: 30
url: /de/java/shape-effect/
keywords:
- Formeffekt
- Schatteneffekt
- Reflexionseffekt
- Leuchteffekt
- Weiche Kanten Effekt
- Effektformat
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Transformieren Sie Ihre PPT- und PPTX-Dateien mit fortschrittlichen Formeffekten mithilfe von Aspose.Slides für Java — erstellen Sie beeindruckende, professionelle Folien in Sekundenschnelle."
---
## **Einführung**

Während Effekte in PowerPoint verwendet werden können, um eine Form hervorstechen zu lassen, unterscheiden sie sich von [Füllungen](/slides/de/java/shape-formatting/#gradient-fill) oder Konturen. Mit PowerPoint‑Effekten können Sie überzeugende Reflexionen einer Form erzeugen, den Leuchteffekt einer Form verbreiten usw.

![Formeffekt](shape-effect.png)

PowerPoint bietet sechs Effekte, die auf Formen angewendet werden können. Sie können einer Form einen oder mehrere Effekte zuweisen.

Einige Kombinationen von Effekten sehen besser aus als andere. Aus diesem Grund stellt PowerPoint Optionen unter **Preset** bereit. Die Preset‑Optionen sind Kombinationen aus zwei oder mehr Effekten, die bekanntermaßen gut aussehen. Auf diese Weise müssen Sie durch Auswahl einer Vorgabe nicht Zeit damit verbringen, verschiedene Effekte zu testen oder zu kombinieren, um eine ansprechende Kombination zu finden.

Aspose.Slides stellt Eigenschaften und Methoden in der Klasse [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/) bereit, die es Ihnen ermöglichen, dieselben Effekte auf Formen in PowerPoint‑Präsentationen anzuwenden.

## **Schatteneffekt anwenden**

Aspose.Slides für Java unterstützt äußere und innere Schatten für Formen. Sie können deren Farbe, Richtung, Abstand und Weichzeichnungsradius an das Design Ihrer Präsentation anpassen.

### **Außenschatten anwenden**

Verwenden Sie einen Außenschatten, um eine Karte oder ein Panel gegenüber dem Folienhintergrund hervorzuheben. Der Schatten erstreckt sich über die Kanten der Form hinaus und erzeugt den Eindruck, dass die Form über der Folie schwebt. Passen Sie Farbe, Richtung, Abstand und Weichzeichnungsradius an die Beleuchtung und das Styling Ihrer Vorlage an.

Dieser Java‑Code zeigt, wie man den [Außenschatten‑Effekt](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getOuterShadowEffect--) auf ein Rechteck anwendet:
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

![Schatteneffekt](shadow_effect.png)

### **Innenschatten anwenden**

Wenn Sie das visuelle Styling einer Vorlage nachbilden, verwenden Sie einen Innenschatten, um einer Karte oder einem Panel ein vertieftes Aussehen zu verleihen. Ein Außenschatten erstreckt sich außerhalb der Form und lässt sie erhöht erscheinen, während ein Innenschatten die Innenseiten ihrer Kanten abschattet.

Rufen Sie [enableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#enableInnerShadowEffect--) auf und konfigurieren Sie anschließend den Schatten, der von [getInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getInnerShadowEffect--) zurückgegeben wird. Größere Werte für den Weichzeichnungsradius erzeugen weichere Kanten.

Dieses Java‑Beispiel erstellt eine hellblaue Karte mit einem dunkelgrauen Innenschatten und speichert sie als PPTX‑Datei. Die Schattenrichtung beträgt 225 Grad, der Abstand 7 Punkte und der Weichzeichnungsradius 6 Punkte:
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

![Hellblaues Rechteck mit Innenschatten](inner_shadow_effect.png)

Um den Innenschatten zu entfernen, rufen Sie [disableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#disableInnerShadowEffect--) im EffectFormat der Form auf.

### **Vorgabe‑Schatten anwenden, ändern und entfernen**

Rufen Sie [enablePresetShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#enablePresetShadowEffect--) auf und verwenden Sie [setPreset](https://reference.aspose.com/slides/java/com.aspose.slides/ipresetshadow/#setPreset-int-) , um einen [PresetShadowType](https://reference.aspose.com/slides/java/com.aspose.slides/presetshadowtype/) auszuwählen. Um den Stil zu wechseln, ändern Sie die Vorgabe bei derselben Form. Rufen Sie [disablePresetShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disablePresetShadowEffect--) auf, um den Schatten zu entfernen, wobei Füllung und Kontur erhalten bleiben.

Dieses Beispiel zeigt vier Phasen nebeneinander auf einer Folie. Beide Schatten sind um 10 Punkte versetzt. Eine Richtung von 225 ° positioniert den ersten Schatten oberhalb und links vom Rechteck, und 45 ° positioniert den zweiten darunter und rechts.
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

| Original | Erste Vorgabe | Zweite Vorgabe | Nach Entfernung |
| :---: | :---: | :---: | :---: |
| ![No shadow](preset_shadow_original.png) | ![TopLeftDropShadow](preset_shadow_top_left.png) | ![BottomRightDropShadow](preset_shadow_bottom_right.png) | ![No shadow after removal](preset_shadow_removed.png) |

## **Reflexionseffekt anwenden**

Um in Aspose.Slides für Java einen Reflexionseffekt anzuwenden, können Sie Formen eine spiegelnde Reflexion hinzufügen und Parameter wie Abstand, Transparenz und Größe anpassen. Dieser Effekt verbessert die Ästhetik Ihrer Präsentationen, indem er Formen ein polierteres und anspruchsvolleres Aussehen verleiht. Er lässt sich mit einfachem Code leicht implementieren und ermöglicht eine schnelle Anwendung auf mehrere Elemente für ein einheitliches Design.

Dieser Java‑Code zeigt, wie man den [Reflexionseffekt](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getReflectionEffect--) auf eine Form anwendet:
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

![Reflexionseffekt](reflection_effect.png)

## **Leuchteffekt anwenden**

Um in Aspose.Slides für Java einen Leuchteffekt auf eine Form anzuwenden, können Sie eine weiche, leuchtende Aura um Formen hinzufügen und Eigenschaften wie Farbe und Größe anpassen. Dieser Effekt lässt Formen hervortreten und fügt Ihrem Vortrag ein attraktives, auffälliges visuelles Element hinzu. Er lässt sich mit minimalem Code leicht implementieren und verbessert das Gesamterscheinungsbild Ihrer Folien.

Dieser Java‑Code zeigt, wie man den [Leuchteffekt](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getGlowEffect--) auf eine Form anwendet:
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

![Leuchteffekt](glow_effect.png)

## **Weiche Kanten‑Effekt anwenden**

Um in Aspose.Slides für Java einen Weiche‑Kanten‑Effekt anzuwenden, können Sie einen sanften, unscharfen Übergang rund um die Kanten einer Form erzeugen. Dieser Effekt verleiht ein dezenteres und raffinierteres Aussehen, ideal für Designs, die ein sanftes, weicheres Erscheinungsbild benötigen. Sie können Parameter wie den Radius leicht anpassen, um den gewünschten Effekt bei verschiedenen Formen in Ihrer Präsentation zu erzielen.

Dieser Java‑Code zeigt, wie man den [Weiche‑Kanten‑Effekt](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getSoftEdgeEffect--) auf eine Form anwendet:
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

![Weiche Kanten‑Effekt](soft_edges_effect.png)

## **Weichzeichnungs‑Effekt anwenden**

Verwenden Sie Formen‑Unschärfe, um die Füllung und Kontur einer Form zu verwischen, während die Form editierbar bleibt. Rufen Sie [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) im EffectFormat der Form auf. Der Radius wird in Punkten (1/72 Zoll) gemessen: Verwenden Sie einen nicht‑negativen Wert, wobei größere Werte eine stärkere Unschärfe erzeugen. Ein Radius von Null lässt das Aussehen unverändert.

Die Einstellung [getGrow](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/#getGrow--) bestimmt die sichtbaren Grenzen des Effekts. Bei `false` wird die Unschärfe auf die ursprünglichen gemalten Grenzen, einschließlich der Kontur, zugeschnitten. Bei `true` kann die Unschärfe über diese Grenzen hinausgehen. Keine der beiden Einstellungen verändert die Position oder die Abmessungen der Form.

Der Vergleich unten verwendet durchgehend dieselbe Füllung, Kontur und Formabmessungen. Die obere Zeile verwendet `grow = false`; die untere Zeile verwendet `grow = true`.

![Ursprüngliches Rechteck im Vergleich mit Unschärferadien von 5 und 15 Punkten, mit deaktiviertem und aktiviertem Grow](shape_blur_comparison.png)

Dieses Java‑Beispiel erstellt ein orangefarbenes Rechteck mit einer dunkelblauen Kontur, wendet eine Unschärfe von 5 Punkten an und aktualisiert es anschließend auf eine Unschärfe von 15 Punkten, indem es erneut [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) aufruft. Es speichert beide unscharfen Zustände, ruft dann [disableBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disableBlurEffect--) auf und speichert die Form ohne Unschärfe.
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

Form‑Unschärfe wirkt sich sowohl auf die Füllung als auch auf die Kontur aus. Ein Weiche‑Kanten‑Effekt verblasst die Kanten der Form, während Schatten‑Unschärfe nur den Schatten weicher macht. Bild‑Transformationseffekte arbeiten am Bildinhalt; dieses Beispiel wendet die Unschärfe direkt auf das EffectFormat der Form an, ohne die Form in ein Bild zu konvertieren.

## **FAQ**

**Kann ich mehrere Effekte auf dieselbe Form anwenden?**

Ja, Sie können verschiedene Effekte, wie Schatten, Reflexion und Leuchteffekt, auf einer einzelnen Form kombinieren, um ein dynamischeres Aussehen zu erzielen.

**Auf welche Formen kann ich Effekte anwenden?**

Sie können Effekte auf verschiedene Formen anwenden, einschließlich Autoformen, Diagrammen, Tabellen, Bildern, SmartArt‑Objekten, OLE‑Objekten und mehr.

**Kann ich Effekte auf gruppierte Formen anwenden?**

Ja, Sie können Effekte auf gruppierte Formen anwenden. Der Effekt wird auf die gesamte Gruppe angewendet.