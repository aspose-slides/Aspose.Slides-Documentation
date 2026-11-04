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
description: "Transformieren Sie Ihre PPT- und PPTX-Dateien mit erweiterten Formeffekten mithilfe von Aspose.Slides für Java – erstellen Sie in Sekunden eindrucksvolle, professionelle Folien."
---
## **Einführung**

Obwohl Effekte in PowerPoint verwendet werden können, um eine Form hervorzustechen, unterscheiden sie sich von [Füllungen](/slides/de/java/shape-formatting/#gradient-fill) oder Konturen. Mit PowerPoint‑Effekten können Sie überzeugende Spiegelungen einer Form erzeugen, den Schein einer Form verbreiten usw.

![Formeffekt](shape-effect.png)

PowerPoint bietet sechs Effekte, die auf Formen angewendet werden können. Sie können einen oder mehrere Effekte auf eine Form anwenden.

Einige Kombinationen von Effekten sehen besser aus als andere. Aus diesem Grund stellt PowerPoint Optionen unter **Voreinstellung** bereit. Die Voreinstellungs‑Optionen sind Kombinationen von zwei oder mehr Effekten, von denen bekannt ist, dass sie gut aussehen. Auf diese Weise müssen Sie beim Auswählen einer Voreinstellung nicht Zeit damit verbringen, verschiedene Effekte zu testen oder zu kombinieren, um eine passende Kombination zu finden.

Aspose.Slides stellt Eigenschaften und Methoden in der Klasse [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/) bereit, mit denen Sie dieselben Effekte auf Formen in PowerPoint‑Präsentationen anwenden können.

## **Schatteneffekt anwenden**

Aspose.Slides for Java unterstützt äußere und innere Schatten für Formen. Sie können deren Farbe, Richtung, Abstand und Unschärferadius an das Design Ihrer Präsentation anpassen.

### **Äußeren Schatten anwenden**

Verwenden Sie einen äußeren Schatten, um eine Karte oder ein Panel gegenüber dem Folienhintergrund hervorzuheben. Der Schatten erstreckt sich über die Kanten der Form hinaus und erweckt den Eindruck, dass die Form über der Folie schwebt. Passen Sie Farbe, Richtung, Abstand und Unschärferadius an die Beleuchtung und das Styling Ihrer Vorlage an.

Dieser Java‑Code zeigt, wie Sie den [äußeren Schatteneffekt](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getOuterShadowEffect--) auf ein Rechteck anwenden:

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

### **Inneren Schatten anwenden**

Wenn Sie das visuelle Styling einer Vorlage reproduzieren, verwenden Sie einen inneren Schatten, um einer Karte oder einem Panel ein vertieftes Aussehen zu verleihen. Ein äußerer Schatten erstreckt sich außerhalb der Form und lässt sie erhöht wirken, während ein innerer Schatten die Innenseiten ihrer Kanten abdunkelt.

Rufen Sie [enableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#enableInnerShadowEffect--) auf und konfigurieren Sie dann den Schatten, der von [getInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getInnerShadowEffect--) zurückgegeben wird. Größere Unschärferadiuswerte erzeugen weichere Kanten.

Dieses Java‑Beispiel erstellt eine hellblaue Karte mit einem dunkelgrauen inneren Schatten und speichert sie als PPTX‑Datei. Die Schattenrichtung beträgt 225° , ihr Abstand 7 Punkte und ihr Unschärferadius 6 Punkte:

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

![Hellblaues Rechteck mit innerem Schatten](inner_shadow_effect.png)

Um den inneren Schatten zu entfernen, rufen Sie [disableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#disableInnerShadowEffect--) im Effektformat der Form auf.

## **Reflexionseffekt anwenden**

Um einen Reflexionseffekt in Aspose.Slides for Java anzuwenden, können Sie Formen eine spiegelähnliche Reflexion hinzufügen und Parameter wie Abstand, Transparenz und Größe anpassen. Dieser Effekt verbessert die Ästhetik Ihrer Präsentationen, indem er Formen ein gepflegteres und anspruchsvolleres Aussehen verleiht. Mit einfachem Code lässt er sich leicht implementieren und ermöglicht eine schnelle Anwendung über mehrere Elemente hinweg für ein einheitliches Design.

Dieser Java‑Code zeigt, wie Sie den [Reflexionseffekt](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getReflectionEffect--) auf eine Form anwenden:

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

Um einen Leuchteffekt auf eine Form in Aspose.Slides for Java anzuwenden, können Sie eine weiche, leuchtende Aura um Formen hinzufügen und Eigenschaften wie Farbe und Größe einstellen. Dieser Effekt hilft, Formen hervorzuheben und verleiht Ihrer Präsentation ein attraktives, aufmerksamkeitsstarkes visuelles Element. Er lässt sich mit minimalem Code umsetzen und verbessert das Gesamtbild Ihrer Folien.

Dieser Java‑Code zeigt, wie Sie den [Leuchteffekt](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getGlowEffect--) auf eine Form anwenden:

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

Um einen weichen Kanten‑Effekt in Aspose.Slides for Java anzuwenden, können Sie einen sanften, unscharfen Übergang um die Kanten einer Form erzeugen. Dieser Effekt verleiht ein subtileres und raffinierteres Aussehen, ideal für Designs, die ein sanftes, weicheres Erscheinungsbild benötigen. Sie können Parameter wie den Radius leicht anpassen, um den gewünschten Effekt über verschiedene Formen in Ihrer Präsentation zu erzielen.

Dieser Java‑Code zeigt, wie Sie den [weichen Kanten‑Effekt](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getSoftEdgeEffect--) auf eine Form anwenden:

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

## **Weichzeichner‑Effekt anwenden**

Verwenden Sie den Form‑Weichzeichner, um die Füllung und Kontur einer Form zu verwischen, während die Form bearbeitbar bleibt. Rufen Sie [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) im Effektformat der Form auf. Der Radius wird in Punkten (1/72 Zoll) gemessen: Verwenden Sie einen nicht‑negativen Wert, wobei größere Werte einen stärkeren Weichzeichner erzeugen. Ein Radius von 0 lässt das Aussehen unverändert.

Die Einstellung [getGrow](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/#getGrow--) steuert die sichtbaren Grenzen des Effekts. Bei `false` wird der Weichzeichner auf die ursprünglich gemalten Grenzen, einschließlich der Kontur, beschränkt. Bei `true` kann der Weichzeichner über diese Grenzen hinausgehen. Keine der beiden Einstellungen ändert die Position oder Größe der Form.

Der untenstehende Vergleich verwendet durchgehend dieselbe Füllung, Kontur und Formabmessungen. Die obere Reihe nutzt `grow = false`; die untere Reihe nutzt `grow = true`.

![Originales Rechteck im Vergleich mit Unschärferadien von 5 und 15 Punkten, bei deaktiviertem und aktiviertem Grow](shape_blur_comparison.png)

Dieses Java‑Beispiel erstellt ein oranges Rechteck mit einer dunkelblauen Kontur, wendet einen Weichzeichner von 5 Punkten an und aktualisiert ihn anschließend auf 15 Punkte, indem es erneut [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) aufruft. Beide unscharfen Zustände werden gespeichert, dann wird [disableBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disableBlurEffect--) aufgerufen und die Form ohne Weichzeichner gespeichert.

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

Der Form‑Weichzeichner beeinflusst Füllung und Kontur gemeinsam. Ein weicher Kanten‑Effekt lässt die Kanten der Form ausblenden, während ein Schatten‑Weichzeichner nur den Schatten verwischt. Bildtransformations‑Effekte wirken auf Bildinhalte; dieses Beispiel wendet den Weichzeichner direkt auf das Effektformat der Form an, ohne die Form in ein Bild zu konvertieren.

## **FAQ**

**Kann ich mehrere Effekte auf dieselbe Form anwenden?**

Ja, Sie können verschiedene Effekte, wie Schatten, Reflexion und Leuchteffekt, auf eine einzelne Form kombinieren, um ein dynamischeres Aussehen zu erzielen.

**Auf welche Formen kann ich Effekte anwenden?**

Sie können Effekte auf verschiedene Formen anwenden, darunter Autoformen, Diagramme, Tabellen, Bilder, SmartArt‑Objekte, OLE‑Objekte und mehr.

**Kann ich Effekte auf gruppierte Formen anwenden?**

Ja, Sie können Effekte auf gruppierte Formen anwenden. Der Effekt wird auf die gesamte Gruppe angewendet.