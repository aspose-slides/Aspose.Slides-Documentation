---
title: Formeffekte in Präsentationen mit PHP anwenden
linktitle: Formeffekt
type: docs
weight: 30
url: /de/php-java/shape-effect/
keywords:
- Formeffekt
- Schatteneffekt
- Spiegeleffekt
- Leuchteffekt
- Weichkanteneffekt
- Effektformat
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Transformieren Sie Ihre PPT- und PPTX-Dateien mit fortgeschrittenen Formeffekten mithilfe von Aspose.Slides für PHP via Java – erstellen Sie innerhalb von Sekunden eindrucksvolle, professionelle Folien."
---
## **Einführung**

Während Effekte in PowerPoint verwendet werden können, um eine Form hervorzuheben, unterscheiden sie sich von [Füllungen](/slides/de/php-java/shape-formatting/#gradient-fill) oder Konturen. Mit PowerPoint‑Effekten können Sie überzeugende Spiegelungen einer Form erzeugen, das Leuchten einer Form verbreiten usw.

![Formeffekt](shape-effect.png)

PowerPoint bietet sechs Effekte, die auf Formen angewendet werden können. Sie können einer Form einen oder mehrere Effekte zuweisen.

Einige Kombinationen von Effekten sehen besser aus als andere. Aus diesem Grund stellt PowerPoint Optionen unter **Preset** bereit. Die Preset‑Optionen sind Kombinationen aus zwei oder mehr Effekten, die bekanntermaßen gut aussehen. Auf diese Weise müssen Sie bei Auswahl eines Presets nicht Zeit damit verbringen, verschiedene Effekte zu testen oder zu kombinieren, um eine passende Kombination zu finden.

Aspose.Slides bietet Eigenschaften und Methoden in der Klasse [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/), mit denen Sie dieselben Effekte auf Formen in PowerPoint‑Präsentationen anwenden können.

## **Einen Schatteneffekt anwenden**

Aspose.Slides für PHP via Java unterstützt äußere und innere Schatten für Formen. Sie können deren Farbe, Richtung, Abstand und Unschärferadius an das Design Ihrer Präsentation anpassen.

### **Äußeren Schatten anwenden**

Verwenden Sie einen äußeren Schatten, um eine Karte oder ein Panel gegenüber dem Folienhintergrund hervorzuheben. Der Schatten erstreckt sich über die Kanten der Form hinaus und erweckt den Eindruck, dass die Form über der Folie schwebt. Passen Sie Farbe, Richtung, Abstand und Unschärferadius an die Beleuchtung und das Styling Ihrer Vorlage an.

Dieser PHP‑Code zeigt, wie der [äußere Schatteneffekt](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getOuterShadowEffect) auf ein Rechteck angewendet wird:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableOuterShadowEffect();
    $shadowColor = new Java("java.awt.Color", 169, 169, 169);
    $shape->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor($shadowColor);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDistance(10);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDirection(45);

    $presentation->save("shadow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Schatteneffekt](shadow_effect.png)

### **Inneren Schatten anwenden**

Wenn Sie das visuelle Styling einer Vorlage reproduzieren, verwenden Sie einen inneren Schatten, um einer Karte oder einem Panel ein vertieftes Erscheinungsbild zu verleihen. Ein äußerer Schatten erstreckt sich außerhalb der Form und lässt sie erhöht erscheinen, während ein innerer Schatten das Innere ihrer Kanten abschattet.

Rufen Sie [enableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enableInnerShadowEffect) auf und konfigurieren Sie anschließend den Schatten, der von [getInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getInnerShadowEffect) zurückgegeben wird. Größere Unschärferadiuswerte ergeben weichere Kanten.

Dieses PHP‑Beispiel erstellt eine hellblaue Karte mit einem dunkelgrauen inneren Schatten und speichert sie als PPTX‑Datei. Die Schattenrichtung beträgt 225 Grad, der Abstand 7 Punkte und der Unschärferadius 6 Punkte:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 173, 216, 230);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $shape->getEffectFormat()->enableInnerShadowEffect();
    $shadow = $shape->getEffectFormat()->getInnerShadowEffect();
    $shadowColor = new Java("java.awt.Color", 105, 105, 105);
    $shadow->getShadowColor()->setColor($shadowColor);
    $shadow->setDirection(225);
    $shadow->setDistance(7);
    $shadow->setBlurRadius(6);

    $presentation->save("inner_shadow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Hellblaues Rechteck mit innerem Schatten](inner_shadow_effect.png)

Um den inneren Schatten zu entfernen, rufen Sie [disableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableInnerShadowEffect) im Effektformat der Form auf.

### **Preset‑Schatten anwenden, ändern und entfernen**

Rufen Sie [enablePresetShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enablePresetShadowEffect) auf, um einen Preset‑Schatten zu aktivieren. Verwenden Sie [setPreset](https://reference.aspose.com/slides/php-java/aspose.slides/presetshadow/#setPreset), um einen [PresetShadowType](https://reference.aspose.com/slides/php-java/aspose.slides/presetshadowtype/) auszuwählen oder zu einem anderen Stil derselben Form zu wechseln. Rufen Sie [disablePresetShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disablePresetShadowEffect) auf, um den Schatten zu entfernen, während Füllung und Kontur erhalten bleiben.

Dieses PHP‑Beispiel klont das Rechteck nach jedem der ersten drei Schritte, sodass Sie alle vier Stufen nebeneinander auf einer Folie vergleichen können. Beide Schatten sind um 10 Punkte versetzt. Eine Richtung von 225° positioniert den ersten Schatten oben links vom Rechteck, und 45° positioniert den zweiten unten rechts.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\PresetShadowType;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(800, 120, SlideSizeScaleType::DoNotScale);
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    $shape = $shapes->addAutoShape(ShapeType::Rectangle, 15, 30, 170, 60);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 70, 130, 180);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $lineFill = $shape->getLineFormat()->getFillFormat();
    $lineFill->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 0, 0, 139);
    $lineFill->getSolidFillColor()->setColor($lineColor);
    $shape->getTextFrame()->setText("No shadow");
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(14);
    $shapes->addClone($shape);

    $shape->setX(215);
    $effects = $shape->getEffectFormat();
    $effects->enablePresetShadowEffect();
    $shadow = $effects->getPresetShadowEffect();
    $shadow->setPreset(PresetShadowType::TopLeftDropShadow);
    $shadow->setDistance(10);
    $shadow->setDirection(225);
    $shape->getTextFrame()->setText("TopLeftDropShadow");
    $shapes->addClone($shape);

    $shape->setX(415);
    $shadow->setPreset(PresetShadowType::BottomRightDropShadow);
    $shadow->setDirection(45);
    $shape->getTextFrame()->setText("BottomRightDropShadow");
    $shapes->addClone($shape);

    $shape->setX(615);
    $effects->disablePresetShadowEffect();
    $shape->getTextFrame()->setText("No shadow");

    $presentation->save("preset_shadows.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| Original | Erste Vorgabe | Zweite Vorgabe | Nach Entfernung |
| :---: | :---: | :---: | :---: |
| ![Kein Schatten](preset_shadow_original.png) | ![TopLeftDropShadow](preset_shadow_top_left.png) | ![BottomRightDropShadow](preset_shadow_bottom_right.png) | ![Kein Schatten nach Entfernung](preset_shadow_removed.png) |

## **Einen Spiegeleffekt anwenden**

Um in Aspose.Slides für PHP via Java einen Spiegeleffekt anzuwenden, können Sie einer Form eine spiegelähnliche Reflexion hinzufügen und Parameter wie Abstand, Transparenz und Größe anpassen. Dieser Effekt verbessert die Ästhetik Ihrer Präsentationen, indem er Formen ein polierteres und anspruchsvolleres Aussehen verleiht. Die Implementierung ist mit einfachem Code leicht umzusetzen und ermöglicht eine schnelle Anwendung auf mehrere Elemente für ein einheitliches Design.

Dieser PHP‑Code zeigt, wie der [Spiegeleffekt](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getReflectionEffect) auf eine Form angewendet wird:

```php
use aspose\slides\Presentation;
use aspose\slides\RectangleAlignment;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableReflectionEffect();
    $shape->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment::Bottom);
    $shape->getEffectFormat()->getReflectionEffect()->setDirection(90);
    $shape->getEffectFormat()->getReflectionEffect()->setDistance(40);
    $shape->getEffectFormat()->getReflectionEffect()->setBlurRadius(2);

    $presentation->save("reflection_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Spiegeleffekt](reflection_effect.png)

## **Einen Leuchteffekt anwenden**

Um einen Leuchteffekt auf eine Form in Aspose.Slides für PHP via Java anzuwenden, können Sie eine weiche, leuchtende Aura um Formen hinzufügen und Eigenschaften wie Farbe und Größe anpassen. Dieser Effekt lässt Formen hervortreten und fügt Ihrer Präsentation ein attraktives, auffälliges visuelles Element hinzu. Er lässt sich mit minimalem Code leicht implementieren und verbessert das Gesamtbild Ihrer Folien.

Dieser PHP‑Code zeigt, wie der [Leuchteffekt](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getGlowEffect) auf eine Form angewendet wird:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableGlowEffect();
    $shape->getEffectFormat()->getGlowEffect()->getColor()->setColor(java("java.awt.Color")->MAGENTA);
    $shape->getEffectFormat()->getGlowEffect()->setRadius(15);

    $presentation->save("glow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Leuchteffekt](glow_effect.png)

## **Einen Weichkant‑Effekt anwenden**

Um einen Weichkant‑Effekt in Aspose.Slides für PHP via Java anzuwenden, können Sie einen sanften, verschwommenen Übergang um die Kanten einer Form erzeugen. Dieser Effekt verleiht ein dezenteres und raffinierteres Aussehen, perfekt für Designs, die ein sanftes Erscheinungsbild benötigen. Sie können Parameter wie den Radius leicht anpassen, um das gewünschte Ergebnis bei verschiedenen Formen in Ihrer Präsentation zu erzielen.

Dieser PHP‑Code zeigt, wie der [Weichkant‑Effekt](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getSoftEdgeEffect) auf eine Form angewendet wird:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableSoftEdgeEffect();
    $shape->getEffectFormat()->getSoftEdgeEffect()->setRadius(8);

    $presentation->save("soft_edges_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Weichkant‑Effekt](soft_edges_effect.png)

## **Einen Unschärfe‑Effekt anwenden**

Verwenden Sie Form‑Unschärfe, um die Füllung und Kontur einer Form zu mildern und die Form gleichzeitig bearbeitbar zu halten. Rufen Sie [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) im Effektformat der Form auf. Der Radius wird in Punkten (1/72 Zoll) gemessen: Verwenden Sie einen nicht-negativen Wert, wobei größere Werte stärkere Unschärfe erzeugen. Ein Radius von null lässt das Aussehen unverändert.

Die Einstellung [getGrow](https://reference.aspose.com/slides/php-java/aspose.slides/blur/#getGrow) steuert die sichtbaren Grenzen des Effekts. Bei `false` wird die Unschärfe auf die ursprünglichen gemalten Grenzen, einschließlich der Kontur, beschnitten. Bei `true` kann die Unschärfe über diese Grenzen hinausreichen. Keine der Einstellungen ändert die Position oder Abmessungen der Form.

Der nachfolgende Vergleich verwendet durchgehend dieselbe Füllung, Kontur und Formabmessungen. Die obere Zeile verwendet `grow = false`; die untere Zeile verwendet `grow = true`.

![Originales Rechteck im Vergleich mit Unschärferadien von 5 und 15 Punkten, bei deaktiviertem bzw. aktiviertem Grow](shape_blur_comparison.png)

Dieses PHP‑Beispiel erstellt ein orangefarbenes Rechteck mit einer dunkelblauen Kontur, wendet eine Unschärfe von 5 Punkten an und aktualisiert es anschließend zu einer Unschärfe von 15 Punkten, indem es erneut [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) aufruft. Beide unscharfen Zustände werden gespeichert, dann wird [disableBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableBlurEffect) aufgerufen und die Form ohne Unschärfe gespeichert.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 80, 160, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 0, 0, 139);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
    $shape->getLineFormat()->setWidth(8);

    $shape->getEffectFormat()->setBlurEffect(5, false);
    $presentation->save("shape_blur_5.pptx", SaveFormat::Pptx);

    $shape->getEffectFormat()->setBlurEffect(15, true);
    $presentation->save("shape_blur_15.pptx", SaveFormat::Pptx);

    $shape->getEffectFormat()->disableBlurEffect();
    $presentation->save("shape_blur_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Form‑Unschärfe wirkt sich gleichzeitig auf Füllung und Kontur aus. Ein Weichkant‑Effekt verblasst die Kanten der Form, während Schatten‑Unschärfe nur den Schatten mildert. Bild‑Transformations‑Effekte wirken auf Bildinhalte; dieses Beispiel wendet Unschärfe direkt auf das Effektformat der Form an, ohne die Form in ein Bild zu konvertieren.

## **FAQ**

**Kann ich mehrere Effekte auf dieselbe Form anwenden?**

Ja, Sie können verschiedene Effekte wie Schatten, Reflexion und Leuchteffekt auf einer einzelnen Form kombinieren, um ein dynamischeres Erscheinungsbild zu erzielen.

**Auf welche Formen kann ich Effekte anwenden?**

Sie können Effekte auf verschiedene Formen anwenden, darunter Autoformen, Diagramme, Tabellen, Bilder, SmartArt‑Objekte, OLE‑Objekte und mehr.

**Kann ich Effekte auf gruppierte Formen anwenden?**

Ja, Sie können Effekte auf gruppierte Formen anwenden. Der Effekt wird auf die gesamte Gruppe angewendet.