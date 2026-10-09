---
title: Zastosowanie efektów kształtów w prezentacjach przy użyciu Pythona w Java
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
description: "Przekształć swoje pliki PPT i PPTX za pomocą zaawansowanych efektów kształtów korzystając z Aspose.Slides for Python via Java — twórz efektowne, profesjonalne slajdy w kilka sekund."
---
## **Wstęp**

Chociaż efekty w programie PowerPoint mogą być używane do wyróżnienia kształtu, różnią się od [wypełnień](/slides/pl/python-java/shape-formatting/#gradient-fill) lub konturów. Korzystając z efektów PowerPoint, możesz tworzyć przekonujące odbicia na kształcie, rozpraszać poświatę kształtu itp.

![Efekt kształtu](shape-effect.png)

Program PowerPoint udostępnia sześć efektów, które można zastosować do kształtów. Możesz zastosować jeden lub więcej efektów do kształtu.

Niektóre kombinacje efektów wyglądają lepiej niż inne. Z tego powodu PowerPoint oferuje opcje w sekcji **Preset**. Opcje Preset to kombinacje dwóch lub więcej efektów, które są znane z dobrego wyglądu. Dzięki temu, wybierając preset, nie musisz tracić czasu na testowanie lub łączenie różnych efektów w celu znalezienia odpowiedniej kombinacji.

Aspose.Slides udostępnia właściwości i metody w klasie [EffectFormat](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/), które pozwalają stosować te same efekty do kształtów w prezentacjach PowerPoint.

## **Zastosuj efekt cienia**

Aspose.Slides for Python via Java obsługuje zewnętrzne i wewnętrzne cienie dla kształtów. Możesz dostosować ich kolor, kierunek, odległość i promień rozmycia, aby pasowały do projektu prezentacji.

### **Zastosuj zewnętrzny cień**

Użyj zewnętrznego cienia, aby karta lub panel wyróżniały się na tle slajdu. Cień wykracza poza krawędzie kształtu, tworząc wrażenie, że kształt jest uniesiony nad slajdem. Dostosuj jego kolor, kierunek, odległość i promień rozmycia, aby pasowały do oświetlenia i stylu szablonu.

Ten kod w Pythonie pokazuje, jak zastosować [efekt zewnętrznego cienia](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getOuterShadowEffect) do prostokąta:

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

![Efekt cienia](shadow_effect.png)

### **Zastosuj wewnętrzny cień**

Podczas odtwarzania wizualnego stylu szablonu użyj wewnętrznego cienia, aby nadać karcie lub panelowi wklęsły wygląd. Zewnętrzny cień rozciąga się poza kształt i sprawia, że wydaje się podniesiony, podczas gdy wewnętrzny cień zacienia wnętrze jego krawędzi.

Wywołaj [enableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enableInnerShadowEffect), a następnie skonfiguruj cień zwrócony przez [getInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getInnerShadowEffect). Większe wartości promienia rozmycia dają łagodniejsze krawędzie.

Ten przykład w Pythonie tworzy jasnoniebieską kartę z ciemnoszarym wewnętrznym cieniem i zapisuje ją jako plik PPTX. Kierunek cienia wynosi 225 stopni, jego odległość to 7 punktów, a promień rozmycia to 6 punktów:

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

![Jasnoniebieski prostokąt z wewnętrznym cieniem](inner_shadow_effect.png)

Aby usunąć wewnętrzny cień, wywołaj [disableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableInnerShadowEffect) na formacie efektu kształtu.

## **Zastosuj efekt odbicia**

Aby zastosować efekt odbicia w Aspose.Slides for Python via Java, możesz dodać lustrzane odbicie do kształtów, dostosowując parametry takie jak odległość, przejrzystość i rozmiar. Ten efekt podnosi estetykę prezentacji, nadając kształtom bardziej dopracowany i wyrafinowany wygląd. Jest łatwy do wdrożenia przy użyciu prostego kodu, umożliwiając szybkie zastosowanie na wielu elementach dla spójnego projektu.

Ten kod w Pythonie pokazuje, jak zastosować [efekt odbicia](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getReflectionEffect) do kształtu:

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

![Efekt odbicia](reflection_effect.png)

## **Zastosuj efekt poświaty**

Aby zastosować efekt poświaty do kształtu w Aspose.Slides for Python via Java, możesz dodać miękką, świetlistą aurę wokół kształtów, dostosowując właściwości takie jak kolor i rozmiar. Efekt ten pomaga wyróżnić kształty i dodaje atrakcyjny, przyciągający uwagę element wizualny do prezentacji. Jest łatwy do wdrożenia przy minimalnym kodzie, poprawiając ogólny wygląd slajdów.

Ten kod w Pythonie pokazuje, jak zastosować [efekt poświaty](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getGlowEffect) do kształtu:

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

![Efekt poświaty](glow_effect.png)

## **Zastosuj efekt miękkich krawędzi**

Aby zastosować efekt miękkich krawędzi w Aspose.Slides for Python via Java, możesz stworzyć płynne, rozmyte przejście wokół krawędzi kształtu. Ten efekt nadaje subtelniejszy i bardziej wyrafinowany wygląd, idealny dla projektów wymagających delikatnego, łagodnego wyglądu. Możesz łatwo dostosować parametry, takie jak promień, aby uzyskać pożądany efekt na różnych kształtach w prezentacji.

Ten kod w Pythonie pokazuje, jak zastosować [efekt miękkich krawędzi](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getSoftEdgeEffect) do kształtu:

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

![Efekt miękkich krawędzi](soft_edges_effect.png)

## **FAQ**

**Czy mogę zastosować wiele efektów do tego samego kształtu?**

Tak, możesz łączyć różne efekty, takie jak cień, odbicie i poświata, na jednym kształcie, aby uzyskać bardziej dynamiczny wygląd.

**Do jakich kształtów mogę zastosować efekty?**

Efekty można stosować do różnych kształtów, w tym automatycznych kształtów, wykresów, tabel, obrazów, obiektów SmartArt, obiektów OLE i innych.

**Czy mogę zastosować efekty do grupowanych kształtów?**

Tak, możesz zastosować efekty do grupowanych kształtów. Efekt zostanie zastosowany do całej grupy.