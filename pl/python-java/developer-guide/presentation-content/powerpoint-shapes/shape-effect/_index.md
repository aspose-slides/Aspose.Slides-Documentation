---
title: Zastosowanie efektów kształtów w prezentacjach przy użyciu Pythona via Java
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
description: "Przekształć swoje pliki PPT i PPTX za pomocą zaawansowanych efektów kształtu wykorzystując Aspose.Slides for Python via Java — twórz efektowne, profesjonalne slajdy w kilka sekund."
---
## **Wstęp**

Podczas gdy efekty w PowerPoint mogą być używane, aby wyróżnić kształt, różnią się od [wypełnień](/slides/pl/python-java/shape-formatting/#gradient-fill) lub konturów. Korzystając z efektów PowerPoint, możesz tworzyć przekonujące odbicia na kształcie, rozpraszać poświatę kształtu itp.

![Efekt kształtu](shape-effect.png)

PowerPoint udostępnia sześć efektów, które można zastosować do kształtów. Możesz zastosować jeden lub więcej efektów do kształtu.

Niektóre kombinacje efektów wyglądają lepiej niż inne. Z tego powodu PowerPoint oferuje opcje w sekcji **Preset**. Opcje Preset to kombinacje dwóch lub więcej efektów, które są uznawane za atrakcyjne. Dzięki temu, wybierając preset, nie musisz marnować czasu na testowanie lub łączenie różnych efektów w celu znalezienia dobrej kombinacji.

Aspose.Slides udostępnia właściwości i metody w klasie [EffectFormat](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/), które pozwalają zastosować te same efekty do kształtów w prezentacjach PowerPoint.

## **Zastosowanie efektu cienia**

Aspose.Slides for Python via Java obsługuje cienie zewnętrzne i wewnętrzne dla kształtów. Możesz dostosować ich kolor, kierunek, odległość i promień rozmycia, aby dopasować je do projektu prezentacji.

### **Zastosowanie cienia zewnętrznego**

Użyj cienia zewnętrznego, aby karta lub panel wyróżniały się na tle slajdu. Cień rozciąga się poza krawędzie kształtu, tworząc wrażenie, że kształt jest uniesiony nad slajdem. Dostosuj jego kolor, kierunek, odległość i promień rozmycia, aby pasowały do oświetlenia i stylu szablonu.

Ten kod Pythona pokazuje, jak zastosować [efekt cienia zewnętrznego](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getOuterShadowEffect) do prostokąta:

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

### **Zastosowanie cienia wewnętrznego**

Podczas odtwarzania wizualnego stylu szablonu użyj cienia wewnętrznego, aby nadać karcie lub panelowi wpuszczony wygląd. Cień zewnętrzny rozciąga się poza kształt i sprawia, że wygląda na podniesiony, podczas gdy cień wewnętrzny zacienia wewnętrzne krawędzie.

Wywołaj [enableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enableInnerShadowEffect), a następnie skonfiguruj cień zwrócony przez [getInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getInnerShadowEffect). Większe wartości promienia rozmycia dają łagodniejsze krawędzie.

Ten przykład w Pythonie tworzy jasnoniebieską kartę z ciemnoszarym cieniem wewnętrznym i zapisuje ją jako plik PPTX. Kierunek cienia wynosi 225 stopni, jego odległość to 7 punktów, a promień rozmycia to 6 punktów:

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

![Jasnoniebieski prostokąt z cieniem wewnętrznym](inner_shadow_effect.png)

Aby usunąć cień wewnętrzny, wywołaj [disableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableInnerShadowEffect) na formacie efektów kształtu.

### **Zastosowanie, zmiana i usunięcie cienia Preset**

Wywołaj [enablePresetShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enablePresetShadowEffect), a następnie użyj [setPreset](https://reference.aspose.com/slides/python-java/aspose.slides/presetshadow/#setPreset), aby wybrać [PresetShadowType](https://reference.aspose.com/slides/python-java/aspose.slides/presetshadowtype/). Aby zmienić style, zmień preset na tym samym kształcie. Wywołaj [disablePresetShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disablePresetShadowEffect), aby usunąć cień, zachowując wypełnienie i kontur.

Przykład klonuje prostokąt na każdym etapie, abyś mógł porównać wszystkie cztery stany obok siebie na jednym slajdzie. Oba cienie są przesunięte o 10 punktów. Kierunek 225° umieszcza pierwszy cień powyżej i po lewej stronie prostokąta. Kierunek 45° umieszcza drugi cień poniżej i po prawej stronie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetShadowType, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(800, 120, SlideSizeScaleType.DoNotScale)
    shapes = presentation.getSlides().get_Item(0).getShapes()

    shape = shapes.addAutoShape(ShapeType.Rectangle, 15, 30, 170, 60)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(70, 130, 180))
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
    text_frame = shape.getTextFrame()
    text_frame.setText("No shadow")
    paragraph_format = text_frame.getParagraphs().get_Item(0).getParagraphFormat()
    paragraph_format.getDefaultPortionFormat().setFontHeight(14)
    shapes.addClone(shape)

    shape.setX(shape.getX() + 200)
    shape.getEffectFormat().enablePresetShadowEffect()
    shadow = shape.getEffectFormat().getPresetShadowEffect()
    shadow.setPreset(PresetShadowType.TopLeftDropShadow)
    shadow.setDistance(10)
    shadow.setDirection(225)
    text_frame.setText("TopLeftDropShadow")
    shapes.addClone(shape)

    shape.setX(shape.getX() + 200)
    shadow.setPreset(PresetShadowType.BottomRightDropShadow)
    shadow.setDirection(45)
    text_frame.setText("BottomRightDropShadow")
    shapes.addClone(shape)

    shape.setX(shape.getX() + 200)
    shape.getEffectFormat().disablePresetShadowEffect()
    text_frame.setText("No shadow")

    presentation.save("preset_shadows.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| Oryginalny | Pierwszy preset | Drugi preset | Po usunięciu |
| :---: | :---: | :---: | :---: |
| ![Brak cienia](preset_shadow_original.png) | ![Cień w lewym górnym rogu](preset_shadow_top_left.png) | ![Cień w prawym dolnym rogu](preset_shadow_bottom_right.png) | ![Brak cienia po usunięciu](preset_shadow_removed.png) |

## **Zastosowanie efektu odbicia**

Aby zastosować efekt odbicia w Aspose.Slides for Python via Java, możesz dodać lustrzane odbicie do kształtów, regulując parametry takie jak odległość, przezroczystość i rozmiar. Efekt ten podnosi estetykę prezentacji, nadając kształtom bardziej wyrafinowany i dopracowany wygląd. Jest łatwy do wdrożenia przy użyciu prostego kodu, umożliwiając szybkie zastosowanie na wielu elementach dla spójnego projektu.

Ten kod Pythona pokazuje, jak zastosować [efekt odbicia](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getReflectionEffect) do kształtu:

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

## **Zastosowanie efektu poświaty**

Aby zastosować efekt poświaty do kształtu w Aspose.Slides for Python via Java, możesz dodać miękką, świetlną aurę wokół kształtów, regulując właściwości takie jak kolor i rozmiar. Efekt ten pomaga wyróżnić kształty i dodaje atrakcyjny, przyciągający wzrok element wizualny do Twojej prezentacji. Jest łatwy do wdrożenia przy minimalnym kodzie, podnosząc ogólny wygląd slajdów.

Ten kod Pythona pokazuje, jak zastosować [efekt poświaty](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getGlowEffect) do kształtu:

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

## **Zastosowanie efektu miękkich krawędzi**

Aby zastosować efekt miękkich krawędzi w Aspose.Slides for Python via Java, możesz stworzyć płynne, rozmazane przejście wokół krawędzi kształtu. Efekt ten dodaje subtelniejszy i bardziej wyrafinowany wygląd, idealny dla projektów wymagających delikatnego, łagodniejszego wyglądu. Możesz łatwo dostosować parametry, takie jak promień, aby uzyskać pożądany efekt w różnych kształtach w prezentacji.

Ten kod Pythona pokazuje, jak zastosować [efekt miękkich krawędzi](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getSoftEdgeEffect) do kształtu:

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

## **Zastosowanie efektu rozmycia**

Użyj rozmycia kształtu, aby zmiękczyć wypełnienie i kontur kształtu, zachowując możliwość edycji kształtu. Wywołaj [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) na formacie efektów kształtu. Promień jest mierzony w punktach (1/72 cala): użyj wartości nieujemnej, przy czym większe wartości powodują silniejsze rozmycie. Promień równy zero pozostawia wygląd niezmieniony.

Ustawienie [getGrow](https://reference.aspose.com/slides/python-java/aspose.slides/blur/#getGrow) kontroluje widoczne granice efektu. Przy `False` rozmycie jest przycinane do pierwotnych malowanych granic, włącznie z konturem. Przy `True` rozmycie może wykraczać poza te granice. Żadne z ustawień nie zmienia pozycji ani wymiarów kształtu.

Porównanie poniżej używa tego samego wypełnienia, konturu i wymiarów kształtu w całej demonstracji. Górny wiersz używa `grow = False`; dolny wiersz używa `grow = True`.

![Oryginalny prostokąt porównany z promieniami rozmycia 5 i 15 punktów, przy wyłączonym i włączonym grow](shape_blur_comparison.png)

Ten przykład w Pythonie tworzy pomarańczowy prostokąt z ciemnoniebieskim konturem, nakłada rozmycie o promieniu 5 punktów, a następnie aktualizuje je do rozmycia 15 punktów, ponownie wywołując [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect). Zapisuje oba stany rozmyte, następnie wywołuje [disableBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableBlurEffect) i zapisuje kształt bez rozmycia.

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

Rozmycie kształtu wpływa jednocześnie na wypełnienie i kontur. Efekt miękkich krawędzi przyciemnia krawędzie kształtu, podczas gdy rozmycie cienia zmiękcza tylko cień. Efekty przekształcenia obrazu działają na zawartość obrazu; ten przykład stosuje rozmycie bezpośrednio do formatu efektów kształtu, bez konwertowania go na obraz.

## **FAQ**

**Czy mogę zastosować wiele efektów do tego samego kształtu?**

Tak, możesz łączyć różne efekty, takie jak cień, odbicie i poświata, na jednym kształcie, aby uzyskać bardziej dynamiczny wygląd.

**Jakie kształty mogę poddać efektom?**

Możesz stosować efekty do różnych kształtów, w tym autokształtów, wykresów, tabel, obrazów, obiektów SmartArt, obiektów OLE i innych.

**Czy mogę stosować efekty do grupowanych kształtów?**

Tak, możesz stosować efekty do grupowanych kształtów. Efekt zostanie zastosowany do całej grupy.