---
title: Zastosowanie efektów kształtów w prezentacjach przy użyciu Pythona przez Java
linktitle: Efekt kształtu
type: docs
weight: 30
url: /pl/python-java/shape-effect/
keywords:
- efekt kształtu
- efekt cienia
- efekt odbicia
- efekt poświaty
- efekt miękkich krawędzi
- format efektu
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Przekształć swoje pliki PPT i PPTX za pomocą zaawansowanych efektów kształtów przy użyciu Aspose.Slides dla Pythona przez Java — twórz efektowne, profesjonalne slajdy w kilka sekund."
---
## **Wprowadzenie**

Efekty w programie PowerPoint można używać, aby wyróżnić kształt, ale różnią się od [wypełnień](/slides/pl/python-java/shape-formatting/#gradient-fill) lub konturów. Korzystając z efektów PowerPoint, możesz tworzyć przekonujące odbicia na kształcie, rozpraszać poświatę kształtu itp.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint udostępnia sześć efektów, które można zastosować do kształtów. Możesz zastosować jeden lub więcej efektów do kształtu. 

* Niektóre kombinacje efektów wyglądają lepiej niż inne. Z tego powodu PowerPoint udostępnia opcje w sekcji **Preset**. Opcje Preset to zasadniczo kombinacje dwóch lub więcej efektów, które wiadomo, że wyglądają dobrze. Dzięki temu, wybierając ustawienie wstępne, nie będziesz musiał marnować czasu na testowanie lub łączenie różnych efektów w poszukiwaniu dobrej kombinacji.

Aspose.Slides udostępnia właściwości i metody w klasie [EffectFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/effectformat/) które pozwalają zastosować te same efekty do kształtów w prezentacjach PowerPoint.

## **Zastosuj efekt cienia**

Ten kod w Pythonie pokazuje, jak zastosować zewnętrzny efekt cienia ([EffectFormat.getOuterShadowEffect](https://reference.aspose.com/slides/pl/python-java/aspose.slides/effectformat/#getOuterShadowEffect)) do prostokąta:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150)

    shape.getEffectFormat().enableOuterShadowEffect()
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.DARK_GRAY)
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10)
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zastosuj efekt odbicia**

Ten kod w Pythonie pokazuje, jak zastosować efekt odbicia do kształtu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RectangleAlignment, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150)

    shape.getEffectFormat().enableReflectionEffect()
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom)
    shape.getEffectFormat().getReflectionEffect().setDirection(90)
    shape.getEffectFormat().getReflectionEffect().setDistance(55)
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(4)

    presentation.save("reflection.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zastosuj efekt poświaty**

Ten kod w Pythonie pokazuje, jak zastosować efekt poświaty do kształtu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150)

    shape.getEffectFormat().enableGlowEffect()
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA)
    shape.getEffectFormat().getGlowEffect().setRadius(15)

    presentation.save("glow.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zastosuj efekt miękkich krawędzi**

Ten kod w Pythonie pokazuje, jak zastosować efekt miękkich krawędzi do kształtu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150)

    shape.getEffectFormat().enableSoftEdgeEffect()
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(15)

    presentation.save("softEdges.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Czy mogę zastosować wiele efektów do tego samego kształtu?**

Tak, możesz łączyć różne efekty, takie jak cień, odbicie i poświata, na jednym kształcie, aby uzyskać bardziej dynamiczny wygląd.

**Do jakich kształtów mogę zastosować efekty?**

Możesz stosować efekty do różnych kształtów, w tym autokształtów, wykresów, tabel, obrazów, obiektów SmartArt, obiektów OLE i innych.

**Czy mogę zastosować efekty do grupowanych kształtów?**

Tak, możesz stosować efekty do grupowanych kształtów. Efekt zostanie zastosowany do całej grupy.