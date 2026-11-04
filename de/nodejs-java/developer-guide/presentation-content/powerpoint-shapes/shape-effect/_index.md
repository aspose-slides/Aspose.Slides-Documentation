---
title: Formeffekte in Präsentationen mit JavaScript anwenden
linktitle: Formeffekt
type: docs
weight: 30
url: /de/nodejs-java/shape-effect/
keywords:
- Formeffekt
- Schatteneffekt
- Spiegelungseffekt
- Leuchteffekt
- Weiche Kanten Effekt
- Effektformat
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Transformieren Sie Ihre PPT‑ und PPTX‑Dateien mit fortschrittlichen Formeffekten mithilfe von JavaScript und Aspose.Slides für Node.js – erstellen Sie beeindruckende, professionelle Folien in Sekundenschnelle."
---
## **Einführung**

Während Effekte in PowerPoint verwendet werden können, um eine Form hervorzuheben, unterscheiden sie sich von [Füllungen](/slides/de/nodejs-java/shape-formatting/#gradient-fill) oder Konturen. Mit PowerPoint‑Effekten können Sie überzeugende Spiegelungen einer Form erzeugen, den Schein einer Form verbreiten usw.

![Formeffekt](shape-effect.png)

PowerPoint bietet sechs Effekte, die auf Formen angewendet werden können. Sie können einer Form einen oder mehrere Effekte zuweisen.

Einige Kombinationen von Effekten sehen besser aus als andere. Aus diesem Grund bietet PowerPoint Optionen unter **Voreinstellung**. Die Voreinstellung‑Optionen sind Kombinationen aus zwei oder mehr Effekten, die bekanntermaßen gut aussehen. Auf diese Weise müssen Sie beim Auswählen einer Voreinstellung keine Zeit damit verbringen, verschiedene Effekte zu testen oder zu kombinieren, um eine passende Kombination zu finden.

Aspose.Slides stellt Eigenschaften und Methoden in der Klasse [EffectFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/) bereit, mit denen Sie dieselben Effekte auf Formen in PowerPoint‑Präsentationen anwenden können.

## **Schatteneffekt anwenden**

Aspose.Slides für Node.js via Java unterstützt äußere und innere Schatten für Formen. Sie können deren Farbe, Richtung, Abstand und Weichzeichnungsradius an das Design Ihrer Präsentation anpassen.

### **Äußeren Schatten anwenden**

Verwenden Sie einen äußeren Schatten, um eine Karte oder ein Panel gegenüber dem Folienhintergrund hervorzuheben. Der Schatten erstreckt sich über die Kanten der Form hinaus und erzeugt den Eindruck, dass die Form über der Folie schwebt. Passen Sie Farbe, Richtung, Abstand und Weichzeichnungsradius an die Beleuchtung und das Layout Ihrer Vorlage an.

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

### **Inneren Schatten anwenden**

Wenn Sie das visuelle Design einer Vorlage nachbilden, verwenden Sie einen inneren Schatten, um einer Karte oder einem Panel ein vertieftes Erscheinungsbild zu verleihen. Ein äußerer Schatten erstreckt sich außerhalb der Form und lässt sie erhöht wirken, während ein innerer Schatten die Innenseite ihrer Kanten schattiert.

Rufen Sie [enableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enableInnerShadowEffect) auf und konfigurieren Sie anschließend den von [getInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getInnerShadowEffect) zurückgegebenen Schatten. Größere Werte für den Weichzeichnungsradius erzeugen weichere Kanten.

Dieses JavaScript‑Beispiel erzeugt eine hellblaue Karte mit einem dunkelgrauen inneren Schatten und speichert sie als PPTX‑Datei. Die Schattenrichtung beträgt 225 Grad, der Abstand  7 Punkte und der Weichzeichnungsradius 6 Punkte:

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

## **Spiegelungseffekt anwenden**

Um einen Spiegelungseffekt in Aspose.Slides für Node.js via Java anzuwenden, können Sie Formen eine spiegelähnliche Reflexion hinzufügen und dabei Parameter wie Abstand, Transparenz und Größe anpassen. Dieser Effekt verbessert die Ästhetik Ihrer Präsentationen, indem er Formen ein saubereres und anspruchsvolleres Aussehen verleiht. Er lässt sich mit einfachem Code leicht umsetzen und ermöglicht eine schnelle Anwendung auf mehrere Elemente für ein einheitliches Design.

Dieser JavaScript‑Code zeigt, wie man den [Spiegelungseffekt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getReflectionEffect) auf eine Form anwendet:

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

![Spiegelungseffekt](reflection_effect.png)

## **Leuchteffekt anwenden**

Um einen Leuchteffekt auf eine Form in Aspose.Slides für Node.js via Java anzuwenden, können Sie eine weiche, leuchtende Aura um Formen hinzufügen und Eigenschaften wie Farbe und Größe anpassen. Dieser Effekt lässt Formen hervortreten und fügt Ihrer Präsentation ein attraktives, auffälliges visuelles Element hinzu. Er lässt sich mit minimalem Code leicht umsetzen und verbessert das Gesamtbild Ihrer Folien.

Dieser JavaScript‑Code zeigt, wie man den [Leuchteffekt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getGlowEffect) auf eine Form anwendet:

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

## **Weiche Kanten anwenden**

Um einen weichen Kanten‑Effekt in Aspose.Slides für Node.js via Java anzuwenden, können Sie einen sanften, unscharfen Übergang um die Kanten einer Form erzeugen. Dieser Effekt verleiht ein dezenteres und raffinierteres Aussehen, ideal für Designs, die ein sanftes, weicheres Erscheinungsbild benötigen. Sie können Parameter wie den Radius leicht anpassen, um den gewünschten Effekt bei verschiedenen Formen in Ihrer Präsentation zu erzielen.

Dieser JavaScript‑Code zeigt, wie man den [Weiche Kanten](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getSoftEdgeEffect) auf eine Form anwendet:

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

![Weiche Kanten](soft_edges_effect.png)

## **Unschärfeeffekt anwenden**

Verwenden Sie Formunscharf, um die Füllung und Kontur einer Form zu mildern, während die Form bearbeitbar bleibt. Rufen Sie [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect) im Effektformat der Form auf. Der Radius wird in Punkten (1/72 Zoll) gemessen: Verwenden Sie einen nicht‑negativen Wert, wobei größere Werte eine stärkere Unschärfe erzeugen. Ein Radius von Null lässt das Aussehen unverändert.

Die Einstellung [getGrow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blur/#getGrow) steuert die sichtbaren Grenzen des Effekts. Bei `false` wird die Unschärfe auf die ursprünglichen gemalten Grenzen, einschließlich der Kontur, beschränkt. Bei `true` kann die Unschärfe über diese Grenzen hinausgehen. Keine der beiden Einstellungen verändert die Position oder Abmessungen der Form.

Der Vergleich unten verwendet durchgehend dieselbe Füllung, Kontur und Formabmessungen. Die obere Zeile verwendet `grow = false`; die untere Zeile verwendet `grow = true`.

![Originales Rechteck im Vergleich mit Unschärferadien von 5 und 15 Punkten, mit deaktiviertem und aktiviertem Grow](shape_blur_comparison.png)

Dieses JavaScript‑Beispiel erzeugt ein oranges Rechteck mit einer dunkelblauen Kontur, wendet eine 5‑Punkte‑Unschärfe an und aktualisiert es anschließend auf eine 15‑Punkte‑Unschärfe, indem es erneut [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect) aufruft. Es speichert beide unscharfen Zustände, ruft dann [disableBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableBlurEffect) auf und speichert die Form ohne Unschärfe.

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

Formunscharf wirkt sich sowohl auf die Füllung als auch auf die Kontur aus. Ein Weiche‑Kanten‑Effekt verblasst die Kanten der Form, während Schatten‑Unscharf nur den Schatten weicher macht. Bildtransformations‑Effekte wirken auf Bildinhalte; dieses Beispiel wendet die Unschärfe direkt auf das Effektformat der Form an, ohne die Form in ein Bild zu konvertieren.

## **FAQ**

**Kann ich mehrere Effekte auf dieselbe Form anwenden?**

Ja, Sie können verschiedene Effekte, wie Schatten, Spiegelung und Leuchten, auf einer einzigen Form kombinieren, um ein dynamischeres Erscheinungsbild zu erzeugen.

**Auf welche Formen kann ich Effekte anwenden?**

Sie können Effekte auf verschiedene Formen anwenden, einschließlich Autoformen, Diagrammen, Tabellen, Bildern, SmartArt‑Objekten, OLE‑Objekten und mehr.

**Kann ich Effekte auf gruppierte Formen anwenden?**

Ja, Sie können Effekte auf gruppierte Formen anwenden. Der Effekt wird auf die gesamte Gruppe angewendet.