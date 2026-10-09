---
title: Formeffekte in Präsentationen mit Python via Java anwenden
linktitle: Formeffekt
type: docs
weight: 30
url: /de/python-java/shape-effect/
keywords:
- Formeffekt
- Schatteneffekt
- Spiegelungseffekt
- Leuchteffekt
- Weiche Kanten Effekt
- Effektformat
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Transformieren Sie Ihre PPT- und PPTX-Dateien mit fortgeschrittenen Formeffekten mithilfe von Aspose.Slides für Python via Java - erstellen Sie in Sekunden eindrucksvolle, professionelle Folien."
---
## **Einführung**

Während Effekte in PowerPoint verwendet werden können, um eine Form hervorzuheben, unterscheiden sie sich von [Füllungen](/slides/de/python-java/shape-formatting/#gradient-fill) oder Konturen. Mit PowerPoint‑Effekten können Sie überzeugende Spiegelungen auf einer Form erzeugen, das Leuchten einer Form ausbreiten usw.

![Formeffekt](shape-effect.png)

PowerPoint bietet sechs Effekte, die auf Formen angewendet werden können. Sie können ein oder mehrere Effekte auf eine Form anwenden.

Einige Kombinationen von Effekten sehen besser aus als andere. Aus diesem Grund stellt PowerPoint Optionen unter **Preset** bereit. Die Preset‑Optionen sind Kombinationen aus zwei oder mehr Effekten, die bekanntermaßen gut aussehen. Auf diese Weise müssen Sie beim Auswählen eines Presets keine Zeit mehr damit verbringen, verschiedene Effekte zu testen oder zu kombinieren, um eine schöne Kombination zu finden.

Aspose.Slides stellt Eigenschaften und Methoden unter der [EffectFormat](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/)‑Klasse bereit, mit denen Sie dieselben Effekte auf Formen in PowerPoint‑Präsentationen anwenden können.

## **Schatteneffekt anwenden**

Aspose.Slides für Python via Java unterstützt äußere und innere Schatten für Formen. Sie können deren Farbe, Richtung, Abstand und Unschärferadius an das Design Ihrer Präsentation anpassen.

### **Außenschatten anwenden**

Verwenden Sie einen Außenschatten, um eine Karte oder ein Panel gegenüber dem Folienhintergrund hervorzuheben. Der Schatten reicht über die Kanten der Form hinaus und erzeugt den Eindruck, dass die Form über der Folie schwebt. Passen Sie Farbe, Richtung, Abstand und Unschärferadius an das Licht und das Styling Ihrer Vorlage an.

Dieser Python‑Code zeigt, wie man den [Außenschatten‑Effekt](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getOuterShadowEffect) auf ein Rechteck anwendet:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100)
    shape.getEffectFormat().enableOuterShadowEffect()
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color(169, 169, 169))
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10)
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45)

    presentation.save("shadow_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Schatteneffekt](shadow_effect.png)

### **Innenschatten anwenden**

Wenn Sie das visuelle Styling einer Vorlage reproduzieren, verwenden Sie einen Innenschatten, um einer Karte oder einem Panel ein eingelassenes Aussehen zu geben. Ein Außenschatten erstreckt sich außerhalb der Form und lässt sie erhöht erscheinen, während ein Innenschatten die Inside‑Kanten abschattet.

Rufen Sie [enableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enableInnerShadowEffect) auf und konfigurieren Sie dann den Schatten, der von [getInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getInnerShadowEffect) zurückgegeben wird. Größere Unschärferadius‑Werte erzeugen weichere Kanten.

Dieses Python‑Beispiel erstellt eine hellblaue Karte mit einem dunkelgrauen Innenschatten und speichert sie als PPTX‑Datei. Die Schattenrichtung beträgt 225 Grad, der Abstand 7 Punkte und der Unschärferadius 6 Punkte:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(173, 216, 230))
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    shape.getEffectFormat().enableInnerShadowEffect()
    shadow = shape.getEffectFormat().getInnerShadowEffect()
    shadow.getShadowColor().setColor(Color(105, 105, 105))
    shadow.setDirection(225)
    shadow.setDistance(7)
    shadow.setBlurRadius(6)

    presentation.save("inner_shadow_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Hellblaues Rechteck mit einem Innenschatten](inner_shadow_effect.png)

Um den Innenschatten zu entfernen, rufen Sie [disableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableInnerShadowEffect) im EffectFormat der Form auf.

## **Spiegelungseffekt anwenden**

Um einen Spiegelungseffekt in Aspose.Slides für Python via Java anzuwenden, können Sie einer Form eine spiegelähnliche Reflexion hinzufügen und Parameter wie Abstand, Transparenz und Größe anpassen. Dieser Effekt verbessert die Ästhetik Ihrer Präsentationen, indem er Formen ein polierteres und anspruchsvolleres Aussehen verleiht. Er lässt sich mit einfachem Code leicht implementieren und ermöglicht eine schnelle Anwendung auf mehrere Elemente für ein konsistentes Design.

Dieser Python‑Code zeigt, wie man den [Spiegelungseffekt](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getReflectionEffect) auf eine Form anwendet:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RectangleAlignment, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100)
    shape.getEffectFormat().enableReflectionEffect()
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom)
    shape.getEffectFormat().getReflectionEffect().setDirection(90)
    shape.getEffectFormat().getReflectionEffect().setDistance(40)
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2)

    presentation.save("reflection_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Spiegelungseffekt](reflection_effect.png)

## **Leuchteffekt anwenden**

Um einen Leuchteffekt auf eine Form in Aspose.Slides für Python via Java anzuwenden, können Sie einen weichen, leuchtenden Schimmer um Formen hinzufügen und Eigenschaften wie Farbe und Größe anpassen. Dieser Effekt hilft, Formen hervorzuheben und verleiht Ihrer Präsentation ein attraktives, auffälliges visuelles Element. Er lässt sich mit minimalem Code leicht umsetzen und verbessert das Gesamtbild Ihrer Folien.

Dieser Python‑Code zeigt, wie man den [Leuchteffekt](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getGlowEffect) auf eine Form anwendet:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100)
    shape.getEffectFormat().enableGlowEffect()
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA)
    shape.getEffectFormat().getGlowEffect().setRadius(15)

    presentation.save("glow_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Leuchteffekt](glow_effect.png)

## **Weiche Kanten Effekt anwenden**

Um einen weichen Kanten‑Effekt in Aspose.Slides für Python via Java anzuwenden, können Sie einen sanften, unscharfen Übergang um die Kanten einer Form erzeugen. Dieser Effekt verleiht ein dezenteres und raffinierteres Aussehen, ideal für Designs, die ein sanftes Erscheinungsbild benötigen. Sie können Parameter wie den Radius einfach anpassen, um den gewünschten Effekt auf verschiedene Formen in Ihrer Präsentation zu erzielen.

Dieser Python‑Code zeigt, wie man den [Weiche‑Kanten‑Effekt](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getSoftEdgeEffect) auf eine Form anwendet:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150)
    shape.getEffectFormat().enableSoftEdgeEffect()
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8)

    presentation.save("soft_edges_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Weiche Kanten Effekt](soft_edges_effect.png)

## **FAQ**

**Kann ich mehrere Effekte auf dieselbe Form anwenden?**

Ja, Sie können verschiedene Effekte wie Schatten, Spiegelung und Leuchten auf einer einzigen Form kombinieren, um ein dynamischeres Erscheinungsbild zu erzielen.

**Auf welche Formen kann ich Effekte anwenden?**

Sie können Effekte auf verschiedene Formen anwenden, einschließlich Autoformen, Diagrammen, Tabellen, Bildern, SmartArt‑Objekten, OLE‑Objekten und mehr.

**Kann ich Effekte auf gruppierte Formen anwenden?**

Ja, Sie können Effekte auf gruppierte Formen anwenden. Der Effekt wird dann auf die gesamte Gruppe angewendet.