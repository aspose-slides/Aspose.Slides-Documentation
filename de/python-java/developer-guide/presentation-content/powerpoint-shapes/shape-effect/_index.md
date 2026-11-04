---
title: Anwenden von Formeffekten in Präsentationen mit Python über Java
linktitle: Formeffekt
type: docs
weight: 30
url: /de/python-java/shape-effect/
keywords:
- Formeffekt
- Schatteneffekt
- Reflexionseffekt
- Leuchteffekt
- Weiche Kanten Effekt
- Effektformat
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Transformieren Sie Ihre PPT- und PPTX-Dateien mit erweiterten Formeffekten mithilfe von Aspose.Slides für Python über Java – erstellen Sie in Sekunden beeindruckende, professionelle Folien."
---
## **Einleitung**

Während Effekte in PowerPoint verwendet werden können, um eine Form hervorzuheben, unterscheiden sie sich von [Füllungen](/slides/de/python-java/shape-formatting/#gradient-fill) oder Konturen. Mit PowerPoint‑Effekten können Sie überzeugende Spiegelungen einer Form erzeugen, den Schein einer Form verbreiten usw.

![Formeffekt](shape-effect.png)

PowerPoint bietet sechs Effekte, die auf Formen angewendet werden können. Sie können einen oder mehrere Effekte auf eine Form anwenden.

Einige Kombinationen von Effekten sehen besser aus als andere. Aus diesem Grund stellt PowerPoint Optionen unter **Preset** bereit. Die Preset‑Optionen sind Kombinationen aus zwei oder mehr Effekten, von denen bekannt ist, dass sie gut aussehen. Auf diese Weise müssen Sie beim Auswählen eines Presets keine Zeit damit verschwenden, verschiedene Effekte zu testen oder zu kombinieren, um eine passende Kombination zu finden.

Aspose.Slides stellt Eigenschaften und Methoden in der Klasse [EffectFormat](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/) zur Verfügung, mit denen Sie dieselben Effekte auf Formen in PowerPoint‑Präsentationen anwenden können.

## **Schatteneffekt anwenden**

Aspose.Slides für Python über Java unterstützt äußere und innere Schatten für Formen. Sie können Farbe, Richtung, Abstand und Unschärferadius an das Design Ihrer Präsentation anpassen.

### **Äußeren Schatten anwenden**

Verwenden Sie einen äußeren Schatten, um eine Karte oder ein Feld gegenüber dem Folienhintergrund hervorzuheben. Der Schatten erstreckt sich über die Kanten der Form hinaus und erzeugt den Eindruck, dass die Form über der Folie schwebt. Passen Sie Farbe, Richtung, Abstand und Unschärferadius an die Beleuchtung und das Styling Ihrer Vorlage an.

Dieser Python‑Code zeigt, wie man den [äußeren Schatteneffekt](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getOuterShadowEffect) auf ein Rechteck anwendet:

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

### **Innenen Schatten anwenden**

Wenn Sie das visuelle Styling einer Vorlage wiedergeben, verwenden Sie einen inneren Schatten, um einer Karte oder einem Feld ein eingelassenes Erscheinungsbild zu verleihen. Ein äußerer Schatten erstreckt sich außerhalb der Form und lässt sie erhöht erscheinen, während ein innerer Schatten die Innenseite ihrer Kanten abschattet.

Rufen Sie [enableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enableInnerShadowEffect) auf und konfigurieren Sie anschließend den von [getInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getInnerShadowEffect) zurückgegebenen Schatten. Größere Unschärferadiuswerte erzeugen weichere Kanten.

Dieses Python‑Beispiel erstellt eine hellblaue Karte mit einem dunkelgrauen inneren Schatten und speichert sie als PPTX‑Datei. Die Schattenrichtung beträgt 225 Grad, der Abstand 7 Punkte und der Unschärferadius 6 Punkte:

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

![Hellblaues Rechteck mit innerem Schatten](inner_shadow_effect.png)

Um den inneren Schatten zu entfernen, rufen Sie [disableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableInnerShadowEffect) im Effektformat der Form auf.

## **Reflexionseffekt anwenden**

Um in Aspose.Slides für Python über Java einen Reflexionseffekt anzuwenden, können Sie Formen eine spiegelähnliche Reflexion hinzufügen und Parameter wie Abstand, Transparenz und Größe anpassen. Dieser Effekt verbessert die Ästhetik Ihrer Präsentationen, indem er Formen ein polierteres und raffinierteres Aussehen verleiht. Er lässt sich mit einfachem Code leicht umsetzen und ermöglicht eine schnelle Anwendung auf mehrere Elemente für ein konsistentes Design.

Dieser Python‑Code zeigt, wie man den [Reflexionseffekt](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getReflectionEffect) auf eine Form anwendet:

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

![Reflexionseffekt](reflection_effect.png)

## **Leuchteffekt anwenden**

Um in Aspose.Slides für Python über Java einen Leuchteffekt auf eine Form anzuwenden, können Sie eine weiche, leuchtende Aura um Formen hinzufügen und Eigenschaften wie Farbe und Größe anpassen. Dieser Effekt lässt Formen hervorstechen und fügt Ihrer Präsentation ein attraktives, auffälliges visuelles Element hinzu. Er lässt sich mit minimalem Code leicht umsetzen und verbessert das Gesamtbild Ihrer Folien.

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

## **Weiche Kanten anwenden**

Um in Aspose.Slides für Python über Java einen weichen Kanten‑Effekt anzuwenden, können Sie einen glatten, verschwommenen Übergang um die Kanten einer Form erzeugen. Dieser Effekt verleiht ein subtileres und verfeinertes Aussehen, ideal für Designs, die ein sanftes, weicheres Erscheinungsbild benötigen. Sie können Parameter wie den Radius einfach anpassen, um den gewünschten Effekt bei verschiedenen Formen in Ihrer Präsentation zu erzielen.

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

![Weiche Kanten‑Effekt](soft_edges_effect.png)

## **Weichzeichner‑Effekt anwenden**

Verwenden Sie Form‑Weichzeichnen, um die Füllung und Kontur einer Form zu mildern, während die Form bearbeitbar bleibt. Rufen Sie [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) im Effektformat der Form auf. Der Radius wird in Punkten (1/72 Zoll) gemessen: Verwenden Sie einen nichtnegativen Wert, wobei größere Werte stärkere Unschärfe erzeugen. Ein Radius von Null lässt das Aussehen unverändert.

Die Einstellung [getGrow](https://reference.aspose.com/slides/python-java/aspose.slides/blur/#getGrow) steuert die sichtbaren Grenzen des Effekts. Bei `False` wird die Unschärfe an die ursprünglichen gemalten Grenzen, einschließlich der Kontur, geklippt. Bei `True` kann die Unschärfe über diese Grenzen hinausgehen. Keine der Einstellungen ändert die Position oder Abmessungen der Form.

Der Vergleich unten verwendet durchgehend dieselbe Füllung, Kontur und Formabmessungen. Die obere Zeile verwendet `grow = False`; die untere Zeile verwendet `grow = True`.

![Originales Rechteck im Vergleich mit Unschärferadien von 5 und 15 Punkten, bei deaktiviertem und aktiviertem Grow](shape_blur_comparison.png)

Dieses Python‑Beispiel erstellt ein oranges Rechteck mit einer dunkelblauen Kontur, wendet eine Unschärfe von 5 Punkten an und aktualisiert es anschließend auf eine Unschärfe von 15 Punkten, indem es erneut [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) aufruft. Es speichert beide unscharfen Zustände, ruft dann [disableBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableBlurEffect) auf und speichert die Form ohne Unschärfe.

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

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 80, 160, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(255, 165, 0))
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
    shape.getLineFormat().setWidth(8)

    shape.getEffectFormat().setBlurEffect(5, False)
    presentation.save("shape_blur_5.pptx", SaveFormat.Pptx)

    shape.getEffectFormat().setBlurEffect(15, True)
    presentation.save("shape_blur_15.pptx", SaveFormat.Pptx)

    shape.getEffectFormat().disableBlurEffect()
    presentation.save("shape_blur_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Form‑Weichzeichnen wirkt sich sowohl auf die Füllung als auch auf die Kontur aus. Ein Weiche‑Kanten‑Effekt verblasst die Kanten der Form, während Schatten‑Weichzeichnen nur den Schatten mildert. Bild‑Transformations‑Effekte arbeiten am Bildinhalt; dieses Beispiel wendet die Unschärfe direkt auf das Effektformat der Form an, ohne die Form in ein Bild zu konvertieren.

## **FAQ**

**Kann ich mehrere Effekte auf dieselbe Form anwenden?**

Ja, Sie können verschiedene Effekte, wie Schatten, Reflexion und Leuchten, auf einer einzelnen Form kombinieren, um ein dynamischeres Erscheinungsbild zu erzeugen.

**Auf welche Formen kann ich Effekte anwenden?**

Sie können Effekte auf verschiedene Formen anwenden, einschließlich AutoFormen, Diagrammen, Tabellen, Bildern, SmartArt‑Objekten, OLE‑Objekten und mehr.

**Kann ich Effekte auf gruppierte Formen anwenden?**

Ja, Sie können Effekte auf gruppierte Formen anwenden. Der Effekt wird auf die gesamte Gruppe angewendet.