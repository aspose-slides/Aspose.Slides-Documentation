---
title: Tworzenie i stosowanie efektów WordArt w Pythonie przy użyciu Java
linktitle: WordArt
type: docs
weight: 110
url: /pl/python-java/wordart/
keywords:
- WordArt
- tworzenie WordArt
- szablon WordArt
- efekt WordArt
- efekt cienia
- efekt odbicia
- efekt poświaty
- transformacja WordArt
- efekt 3D
- efekt zewnętrznego cienia
- efekt wewnętrznego cienia
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Tworzenie i dostosowywanie efektów WordArt w Aspose.Slides dla Pythona przy użyciu Java. Ten przewodnik krok po kroku pomaga programistom ulepszyć prezentacje profesjonalnym tekstem w Pythonie przy użyciu Java."
---
## **Przegląd**

Efekty WordArt umożliwiają stylizowanie tekstu przy użyciu wypełnień, konturów, cieni, odbić, poświaty, transformacji i formatowania 3D. Ten artykuł wyjaśnia, jak tworzyć i dostosowywać te efekty w prezentacjach PowerPoint przy użyciu Aspose.Slides for Python via Java, bez zainstalowanego Microsoft Office.

## **Utwórz prosty szablon WordArt i zastosuj go do tekstu**

Poniższe przykłady tworzą prosty styl WordArt poprzez ustawienie tekstu, czcionki, wypełnienia wzorem i konturu.

Każdy przykład tworzy nową prezentację i dodaje prostokąt do pierwszego slajdu; nie jest wymagany plik wejściowy. Pierwszy przykład ustawia tekst na „Aspose.Slides”. Pozycja i wymiary kształtu są mierzone w punktach:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)
    text_frame = auto_shape.getTextFrame()

    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
finally:
    presentation.dispose()
```

Ustaw czcionkę na Arial Black o rozmiarze 36 punktów, aby formatowanie było bardziej widoczne:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)
finally:
    presentation.dispose()
```

Zastosuj wzór [SmallGrid](https://reference.aspose.com/slides/pl/python-java/aspose.slides/patternstyle/#SmallGrid) z ciemnopomarańczowym kolorem pierwszego planu i białym tłem, a następnie dodaj czarny kontur tekstu o szerokości 1 punktu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, PatternStyle, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)

    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern)
    dark_orange = Color(255, 140, 0)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(dark_orange)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE)
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid)

    portion.getPortionFormat().getLineFormat().setWidth(1)
    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
finally:
    presentation.dispose()
```

Wynikowy tekst:

![The simple WordArt template](WordArt_template.png)

## **Zastosuj inne efekty WordArt**

Poniższe przykłady pokazują, jak zastosować cienie, odbicia, poświatę, transformacje i efekty 3D do tekstu.

### **Zastosuj efekty zewnętrznego cienia**

Zewnętrzny cień dodaje głębię, umieszczając cień za tekstem. Możesz dostosować jego kolor, kierunek, odległość, promień rozmycia, skalę i pochylenie.

Ten przykład wywołuje [enableOuterShadowEffect](https://reference.aspose.com/slides/pl/python-java/aspose.slides/effectformat/#enableOuterShadowEffect) i ustawia czarny cień z promieniem rozmycia 4 punkty, kierunkiem 230 stopni oraz odległością 30 punktów. Wartość skali 100 zachowuje rozmiar cienia, a poziome pochylenie przechyla go o 20 stopni. Transformacja alfa ustawia jego krycie na 32%:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, FontData, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)

    portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect()
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.BLACK)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(100)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(30)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(20)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32)
finally:
    presentation.dispose()
```

Wynikowy tekst:

![The Outer Shadow effect](outer_shadow_effect.png)

{{% alert color="info" title="Uwaga" %}}
- Gdy zewnętrzne i wbudowane cienie są używane razem, stosowany jest tylko zewnętrzny cień.
- Jeśli zewnętrzne i wewnętrzne cienie są używane jednocześnie, wynikowy efekt zależy od wersji PowerPointa. Na przykład w PowerPoint 2013 efekt jest podwójny, natomiast w PowerPoint 2007 stosowany jest tylko zewnętrzny cień.
{{% /alert %}}

### **Zastosuj efekty odbicia**

Odbicie tworzy lustrzaną kopię tekstu. Dostosuj jego pozycję, skalę, rozmycie i krycie, aby kontrolować wygląd.

Ten przykład wywołuje [enableReflectionEffect](https://reference.aspose.com/slides/pl/python-java/aspose.slides/effectformat/#enableReflectionEffect) i odwraca odbicie pionowo przy skali -100%. Używa promienia rozmycia 0,5 punktu i odległości 4,72 punktu. Krycie zmniejsza się z 60% do 0,9% pomiędzy pozycjami 0% i 60% wzdłuż odbicia:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, RectangleAlignment, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)

    portion.getPortionFormat().getEffectFormat().enableReflectionEffect()
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(0)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(60)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(60)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(0.9)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.BottomLeft)
finally:
    presentation.dispose()
```

Wynikowy tekst:

![The Reflection effect](reflection_effect.png)

### **Zastosuj efekty poświaty**

Poświata dodaje miękki, kolorowy kontur wokół tekstu. Dostosuj jej kolor, krycie i promień, aby kontrolować efekt.

Ten przykład wywołuje [enableGlowEffect](https://reference.aspose.com/slides/pl/python-java/aspose.slides/effectformat/#enableGlowEffect) i stosuje czerwoną poświatę z kryciem 54% oraz promieniem 7 punktów:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, FontData, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)

    portion.getPortionFormat().getEffectFormat().enableGlowEffect()
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setColor(Color.RED)
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54)
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7)
finally:
    presentation.dispose()
```

Wynikowy tekst:

![The Glow effect](glow_effect.png)

### **Zastosuj transformacje WordArt**

Transformacje WordArt wyginają, rozciągają lub deformują blok tekstu.

Ustaw [setTransform](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframeformat/#setTransform) na [ArchUpPour](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textshapetype/#ArchUpPour), aby zakrzywić cały ramkę tekstu w górę:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, TextShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")
    text_frame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour)
finally:
    presentation.dispose()
```

Wynikowy tekst:

![The WordArt transformation](transform_effect.png)

{{% alert color="info" title="Uwaga" %}}
Aspose.Slides for Python via Java udostępnia zestaw predefiniowanych [typów transformacji](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textshapetype/).
{{% /alert %}}

### **Zastosuj efekty 3D do kształtów i tekstu**

Możesz zastosować efekty 3D do kształtu lub jego tekstu. Bryły, ekstruzja, oświetlenie i ustawienia kamery kontrolują wynikowy wygląd.

Poniższy przykład używa [ThreeDFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/threedformat/) do dodania okrągłych brył, pomarańczowej ekstruzji i ciemnoczerwonego konturu prostokąta. Wymiary brył, wysokość ekstruzji, szerokość konturu i głębokość są mierzone w punktach. Materiał plastikowy, zrównoważone oświetlenie obrócone o 40 stopni wokół osi Z oraz perspektywiczna kamera definiują jego wygląd:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)
    auto_shape.getTextFrame().setText("Aspose.Slides")

    auto_shape.getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle)
    auto_shape.getThreeDFormat().getBevelBottom().setHeight(10.5)
    auto_shape.getThreeDFormat().getBevelBottom().setWidth(10.5)

    auto_shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    auto_shape.getThreeDFormat().getBevelTop().setHeight(12.5)
    auto_shape.getThreeDFormat().getBevelTop().setWidth(11)

    orange = Color(255, 165, 0)
    auto_shape.getThreeDFormat().getExtrusionColor().setColor(orange)
    auto_shape.getThreeDFormat().setExtrusionHeight(6)

    dark_red = Color(139, 0, 0)
    auto_shape.getThreeDFormat().getContourColor().setColor(dark_red)
    auto_shape.getThreeDFormat().setContourWidth(1.5)

    auto_shape.getThreeDFormat().setDepth(3)

    auto_shape.getThreeDFormat().setMaterial(MaterialPresetType.Plastic)

    auto_shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    auto_shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)
    auto_shape.getThreeDFormat().getLightRig().setRotation(0, 0, 40)

    auto_shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

Wynikowy kształt:

![The shape 3D effect](shape_3D_effect.png)

Ten przykład stosuje podobne formatowanie 3D do tekstu za pomocą [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframeformat/#getThreeDFormat). Mniejsze bryły kształtują krawędzie liter, a ekstruzja i oświetlenie nadają tekstowi głębię:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)
    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")

    text_frame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle)
    text_frame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5)
    text_frame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5)

    text_frame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    text_frame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4)
    text_frame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4)

    orange = Color(255, 165, 0)
    text_frame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(orange)
    text_frame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6)

    dark_red = Color(139, 0, 0)
    text_frame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(dark_red)
    text_frame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5)

    text_frame.getTextFrameFormat().getThreeDFormat().setDepth(3)

    text_frame.getTextFrameFormat().getThreeDFormat().setMaterial(MaterialPresetType.Plastic)

    text_frame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    text_frame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)
    text_frame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40)

    text_frame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

Wynikowy tekst:

![The text 3D effect](text_3D_effect.png)

{{% alert color="info" title="Uwaga" %}}
Zastosowanie efektów 3D do tekstu lub ich kształtów — oraz interakcja między tymi efektami — podlega określonym regułom. Rozważ scenę obejmującą zarówno tekst, jak i kształt, w którym się znajduje. Efekt 3D obejmuje trójwymiarową reprezentację obiektu oraz scenę, w której jest umieszczony.
- Jeśli scena jest ustawiona zarówno dla kształtu, jak i tekstu, scena kształtu ma pierwszeństwo, a scena tekstu jest ignorowana.
- Jeśli kształt nie ma własnej sceny, ale posiada reprezentację 3D, używana jest scena tekstu.
- Jeśli kształt nie ma żadnego efektu 3D, jest traktowany jako płaski, a efekt 3D stosowany jest wyłącznie do tekstu.
Te zachowania odnoszą się do metod [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/pl/python-java/aspose.slides/threedformat/#getLightRig) i [ThreeDFormat.getCamera](https://reference.aspose.com/slides/pl/python-java/aspose.slides/threedformat/#getCamera).
{{% /alert %}}

Aby zachować tekst płaski i czytelny, jednocześnie zachowując formatowanie 3D kształtu, zobacz [Utrzymaj tekst płaski na kształcie 3D](/slides/pl/python-java/3d-presentation/) w celu porównania obu ustawień oraz pełnego przykładu w Pythonie.

## **FAQ**

**Czy mogę używać efektów WordArt z różnymi czcionkami lub skryptami (np. arabski, chiński)?**

Tak, Aspose.Slides for Python via Java obsługuje Unicode i działa ze wszystkimi głównymi czcionkami oraz skryptami. Efekty WordArt, takie jak cień, wypełnienie i kontur, mogą być stosowane niezależnie od języka, choć dostępność czcionek i renderowanie mogą zależeć od czcionek systemowych.

**Czy mogę zastosować efekty WordArt do elementów mastera slajdu?**

Tak, możesz zastosować efekty WordArt do kształtów na slajdach master, w tym do pól zastępczych tytułu, stopek lub tekstu w tle. Zmiany wprowadzone w układzie master będą odzwierciedlane we wszystkich powiązanych slajdach.

**Czy efekty WordArt wpływają na rozmiar pliku prezentacji?**

Nieznacznie. Efekty WordArt, takie jak cienie, poświaty i wypełnienia gradientowe, mogą nieco zwiększyć rozmiar pliku ze względu na dodatkowe metadane formatowania, ale różnica jest zazwyczaj pomijalna.

**Czy mogę podejrzeć wynik efektów WordArt bez zapisywania prezentacji?**

Tak, możesz renderować slajdy zawierające WordArt do obrazów (np. PNG, JPEG) za pomocą [Slide.getImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slide/#getImage), lub renderować poszczególne kształty za pomocą [Shape.getImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getImage). Umożliwia to podgląd wyniku w pamięci lub na ekranie przed zapisaniem lub eksportowaniem pełnej prezentacji.