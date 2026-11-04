---
title: "Formeffekte in Präsentationen auf Android anwenden"
linktitle: "Formeffekt"
type: docs
weight: 30
url: /de/androidjava/shape-effect/
keywords:
- "Formeffekt"
- "Schatteneffekt"
- "Reflexionseffekt"
- "Leuchteffekt"
- "Weiche Kanten Effekt"
- "Effektformat"
- "PowerPoint"
- "Präsentation"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Transformieren Sie Ihre PPT- und PPTX-Dateien mit fortgeschrittenen Formeffekten mithilfe von Aspose.Slides für Android via Java — erstellen Sie in Sekunden eindrucksvolle, professionelle Folien."
---
## **Einleitung**

Während Effekte in PowerPoint verwendet werden können, um eine Form hervorzuheben, unterscheiden sie sich von [Füllungen](/slides/de/androidjava/shape-formatting/#gradient-fill) oder Konturen. Mit PowerPoint‑Effekten können Sie überzeugende Spiegelungen einer Form erzeugen, den Schein einer Form verbreiten usw.

![Shape effect](shape-effect.png)

PowerPoint bietet sechs Effekte, die auf Formen angewendet werden können. Sie können einer Form einen oder mehrere Effekte zuweisen.

Einige Kombinationen von Effekten sehen besser aus als andere. Aus diesem Grund bietet PowerPoint Optionen unter **Preset**. Die Preset‑Optionen sind Kombinationen aus zwei oder mehr Effekten, die bekanntermaßen gut aussehen. So müssen Sie beim Auswählen eines Presets keine Zeit damit verbringen, verschiedene Effekte zu testen oder zu kombinieren, um eine passende Kombination zu finden.

Aspose.Slides stellt Eigenschaften und Methoden in der Klasse [EffectFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/) bereit, mit denen Sie dieselben Effekte auf Formen in PowerPoint‑Präsentationen anwenden können.

## **Schatteneffekt anwenden**

Aspose.Slides für Android via Java unterstützt äußere und innere Schatten für Formen. Sie können deren Farbe, Richtung, Abstand und Weichzeichnungsradius an das Design Ihrer Präsentation anpassen.

### **Außenschatten anwenden**

Verwenden Sie einen Außenschatten, um eine Karte oder ein Panel gegenüber dem Folienhintergrund hervorzuheben. Der Schatten erstreckt sich über die Formkanten hinaus und vermittelt den Eindruck, dass die Form über der Folie schwebt. Passen Sie Farbe, Richtung, Abstand und Weichzeichnungsradius an die Beleuchtung und das Styling Ihrer Vorlage an.

Dieser Java‑Code zeigt, wie Sie den [outer shadow effect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getOuterShadowEffect--) auf ein Rechteck anwenden:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.rgb(169, 169, 169));
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Shadow effect](shadow_effect.png)

### **Innenschatten anwenden**

Wenn Sie das visuelle Styling einer Vorlage reproduzieren, verwenden Sie einen Innenschatten, um einer Karte oder einem Panel ein vertieftes Aussehen zu verleihen. Ein Außenschatten erstreckt sich außerhalb der Form und lässt sie erhöht erscheinen, während ein Innenschatten die Innenseite ihrer Kanten abdunkelt.

Rufen Sie [enableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#enableInnerShadowEffect--) auf und konfigurieren Sie anschließend den Schatten, der von [getInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getInnerShadowEffect--) zurückgegeben wird. Größere Werte für den Weichzeichnungsradius erzeugen weichere Kanten.

Dieses Java‑Beispiel erzeugt eine hellblaue Karte mit einem dunkelgrauen Innenschatten und speichert sie als PPTX‑Datei. Die Schattenrichtung beträgt 225 Grad, der Abstand 7 Punkte und der Weichzeichnungsradius 6 Punkte:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(173, 216, 230));
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    shape.getEffectFormat().enableInnerShadowEffect();
    IInnerShadow shadow = shape.getEffectFormat().getInnerShadowEffect();
    shadow.getShadowColor().setColor(Color.rgb(105, 105, 105));
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Light blue rectangle with an inner shadow](inner_shadow_effect.png)

Um den Innenschatten zu entfernen, rufen Sie [disableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#disableInnerShadowEffect--) auf dem Effektformat der Form auf.

## **Reflexionseffekt anwenden**

Um einen Reflexionseffekt in Aspose.Slides für Android via Java anzuwenden, können Sie Formen einen spiegelähnlichen Glanz hinzufügen und Parameter wie Abstand, Transparenz und Größe anpassen. Dieser Effekt verbessert die Ästhetik Ihrer Präsentationen, indem er Formen ein polierteres und anspruchsvolleres Aussehen verleiht. Er lässt sich mit einfachem Code leicht umsetzen und ermöglicht eine schnelle Anwendung auf mehrere Elemente für ein konsistentes Design.

Dieser Java‑Code zeigt, wie Sie den [reflection effect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getReflectionEffect--) auf eine Form anwenden:

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

## **Leuchteffekt anwenden**

Um einen Leuchteffekt auf eine Form in Aspose.Slides für Android via Java anzuwenden, können Sie einen weichen, leuchtenden Schimmer um Formen hinzufügen und Eigenschaften wie Farbe und Größe anpassen. Dieser Effekt lässt Formen hervorstechen und fügt Ihrer Präsentation ein attraktiv‑auffälliges visuelles Element hinzu. Er lässt sich mit minimalem Code leicht implementieren und verbessert das Gesamtbild Ihrer Folien.

Dieser Java‑Code zeigt, wie Sie den [glow effect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getGlowEffect--) auf eine Form anwenden:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

## **Weiche Kanten‑Effekt anwenden**

Um einen weichen Kanten‑Effekt in Aspose.Slides für Android via Java anzuwenden, können Sie einen sanften, unscharfen Übergang um die Ränder einer Form erzeugen. Dieser Effekt verleiht ein dezenteres und verfeinertes Aussehen, ideal für Designs, die ein sanftes Erscheinungsbild benötigen. Sie können Parameter wie den Radius leicht anpassen, um den gewünschten Effekt auf verschiedene Formen in Ihrer Präsentation zu erzielen.

Dieser Java‑Code zeigt, wie Sie den [soft edges effect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getSoftEdgeEffect--) auf eine Form anwenden:

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

## **Unschärfe‑Effekt anwenden**

Verwenden Sie Form‑Unschärfe, um Füllung und Kontur einer Form zu mildern, während die Form bearbeitbar bleibt. Rufen Sie [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) auf dem Effektformat der Form auf. Der Radius wird in Punkten (1/72 Zoll) gemessen: Verwenden Sie einen nicht‑negativen Wert, wobei größere Werte zu stärkerer Unschärfe führen. Ein Radius von Null lässt das Aussehen unverändert.

Die Einstellung [getGrow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iblur/#getGrow--) steuert die sichtbaren Grenzen des Effekts. Bei `false` wird die Unschärfe auf die ursprünglich gemalten Grenzen, einschließlich der Kontur, beschränkt. Bei `true` kann die Unschärfe über diese Grenzen hinausgehen. Keine der beiden Einstellungen verändert Position oder Abmessungen der Form.

Der Vergleich unten verwendet durchgehend dieselbe Füllung, Kontur und Formabmessungen. Die obere Reihe verwendet `grow = false`; die untere Reihe verwendet `grow = true`.

![Original rectangle compared with blur radii of 5 and 15 points, with grow disabled and enabled](shape_blur_comparison.png)

Dieses Java‑Beispiel erstellt ein oranges Rechteck mit einer dunkelblauen Kontur, wendet eine 5‑Punkt‑Unschärfe an und erhöht anschließend die Unschärfe auf 15 Punkte, indem es erneut [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) aufruft. Beide unscharfen Zustände werden gespeichert, danach wird [disableBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#disableBlurEffect--) aufgerufen und die Form ohne Unschärfe gespeichert.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
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

Form‑Unschärfe wirkt sich gleichzeitig auf Füllung und Kontur aus. Ein weicher Kanten‑Effekt verblasst die Ränder der Form, während Schatten‑Unschärfe nur den Schatten mildert. Bild‑Transformations‑Effekte arbeiten am Bildinhalt; dieses Beispiel wendet Unschärfe direkt auf das Effektformat der Form an, ohne die Form in ein Bild zu konvertieren.

## **FAQ**

**Kann ich mehrere Effekte auf dieselbe Form anwenden?**

Ja, Sie können verschiedene Effekte wie Schatten, Reflexion und Leuchteffekt auf einer einzigen Form kombinieren, um ein dynamischeres Aussehen zu erzielen.

**Auf welche Formen kann ich Effekte anwenden?**

Sie können Effekte auf verschiedene Formen anwenden, einschließlich Autoformen, Diagrammen, Tabellen, Bildern, SmartArt‑Objekten, OLE‑Objekten und mehr.

**Kann ich Effekte auf gruppierte Formen anwenden?**

Ja, Sie können Effekte auf gruppierte Formen anwenden. Der Effekt wird dann auf die gesamte Gruppe angewendet.