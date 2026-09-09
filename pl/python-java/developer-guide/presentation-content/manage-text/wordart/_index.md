---
title: Utwórz i zastosuj efekty WordArt w Pythonie poprzez Java
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
description: "Utwórz i dostosuj efekty WordArt w Aspose.Slides dla Pythona poprzez Java. Ten przewodnik krok po kroku pomaga programistom ulepszyć prezentacje profesjonalnym tekstem w Pythonie poprzez Java."
---
## **Przegląd**

Efekty WordArt pozwalają dodać atrakcyjny wizualnie, stylizowany tekst do prezentacji PowerPoint. Dzięki Aspose.Slides programiści mogą programowo tworzyć, dostosowywać i zarządzać WordArt tak jak w Microsoft PowerPoint — bez potrzeby instalacji Office. Ten artykuł przedstawia przegląd pracy z WordArt, w tym jak stosować transformacje tekstu, style wypełnienia, kontury, cienie i inne opcje formatowania, aby treść prezentacji była bardziej ekspresyjna i angażująca. WordArt pozwala traktować tekst jako obiekt graficzny. Składa się z efektów lub specjalnych modyfikacji stosowanych do tekstu, aby był bardziej atrakcyjny lub zauważalny.

## **Utwórz prosty szablon WordArt i zastosuj go do tekstu**

**Używanie Aspose.Slides**

Najpierw tworzymy prosty tekst przy użyciu tego kodu w Pythonie:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()

    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
finally:
    presentation.dispose()
```
Następnie zwiększamy rozmiar czcionki, aby efekt był bardziej widoczny:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    font_data = FontData("Arial Black")
    portion_format = portion.getPortionFormat()
    portion_format.setLatinFont(font_data)
    portion_format.setFontHeight(36)
finally:
    presentation.dispose()
```

**Używanie Microsoft PowerPoint**

Przejdź do menu efektów WordArt w Microsoft PowerPoint:

![Menu efektów WordArt w PowerPoint](image-20200930113926-1.png)

Z menu po prawej możesz wybrać gotowy efekt WordArt. Z menu po lewej możesz określić ustawienia nowego WordArt.

Oto niektóre dostępne parametry lub opcje:

![Opcje formatowania WordArt](image-20200930114015-3.png)

**Używanie Aspose.Slides**

Tutaj stosujemy wypełnienie wzorem [PatternStyle.SmallGrid](https://reference.aspose.com/slides/pl/python-java/aspose.slides/patternstyle/#SmallGrid) do tekstu i dodajemy czarną obwódkę tekstu przy użyciu tego kodu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PatternStyle, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getFillFormat().setFillType(FillType.Pattern)
    pattern_format = portion_format.getFillFormat().getPatternFormat()
    pattern_format.getForeColor().setColor(Color.ORANGE)
    pattern_format.getBackColor().setColor(Color.WHITE)
    pattern_format.setPatternStyle(PatternStyle.SmallGrid)

    line_format = portion_format.getLineFormat()
    line_format.getFillFormat().setFillType(FillType.Solid)
    line_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
finally:
    presentation.dispose()
```

Powstały tekst:

![Tekst z wypełnieniem wzorem i czarną obwódką](image-20200930114108-4.png)

## **Stosowanie innych efektów WordArt**

**Używanie Microsoft PowerPoint**

Z interfejsu programu możesz zastosować te efekty do tekstu, bloku tekstowego, kształtu lub podobnego elementu:

![Efekty tekstu i kształtu w PowerPoint](image-20200930114129-5.png)

Na przykład, efekty Cień, Refleksja i Poświata można zastosować do tekstu; efekty Format 3D i Obrót 3D można zastosować do bloku tekstowego; efekt Miękkie krawędzie można zastosować do kształtu (działa również, gdy nie ustawiono efektu Format 3D).

### **Stosowanie efektów Cienia**

Poniższy kod w Pythonie stosuje efekt cienia wyłącznie do tekstu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getEffectFormat().enableOuterShadowEffect()
    outer_shadow = portion_format.getEffectFormat().getOuterShadowEffect()
    outer_shadow.getShadowColor().setColor(Color.BLACK)
    outer_shadow.setScaleHorizontal(100)
    outer_shadow.setScaleVertical(65)
    outer_shadow.setBlurRadius(4.73)
    outer_shadow.setDirection(230)
    outer_shadow.setDistance(2)
    outer_shadow.setSkewHorizontal(30)
    outer_shadow.setSkewVertical(0)
    outer_shadow.getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32)
finally:
    presentation.dispose()
```

API Aspose.Slides obsługuje trzy typy cieni: [OuterShadow](https://reference.aspose.com/slides/pl/python-java/aspose.slides/outershadow/), [InnerShadow](https://reference.aspose.com/slides/pl/python-java/aspose.slides/innershadow/), i [PresetShadow](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presetshadow/).

Za pomocą [PresetShadow](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presetshadow/) możesz zastosować cień do tekstu przy użyciu gotowych wartości.

**Używanie Microsoft PowerPoint**

W PowerPoint można używać jednego typu cienia. Oto przykład:

![Ustawienia cienia w PowerPoint](image-20200930114225-6.png)

**Używanie Aspose.Slides**

Aspose.Slides faktycznie pozwala na jednoczesne zastosowanie dwóch typów cieni: [InnerShadow](https://reference.aspose.com/slides/pl/python-java/aspose.slides/innershadow/) i [PresetShadow](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presetshadow/).

**Uwaga:**

- Gdy jednocześnie używane są [OuterShadow](https://reference.aspose.com/slides/pl/python-java/aspose.slides/outershadow/) i [PresetShadow](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presetshadow/), stosowany jest tylko efekt [OuterShadow](https://reference.aspose.com/slides/pl/python-java/aspose.slides/outershadow/).
- Jeśli jednocześnie używane są [OuterShadow](https://reference.aspose.com/slides/pl/python-java/aspose.slides/outershadow/) i [InnerShadow](https://reference.aspose.com/slides/pl/python-java/aspose.slides/innershadow/), wynikowy lub zastosowany efekt zależy od wersji PowerPoint. Na przykład w PowerPoint 2013 efekt jest podwojony. Natomiast w PowerPoint 2007 stosowany jest efekt [OuterShadow](https://reference.aspose.com/slides/pl/python-java/aspose.slides/outershadow/).

### **Zastosuj odbicie do tekstu**

Dodajemy odbicie do tekstu przy pomocy tego przykładu kodu w Pythonie przez Java:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RectangleAlignment, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getEffectFormat().enableReflectionEffect()
    reflection = portion_format.getEffectFormat().getReflectionEffect()
    reflection.setBlurRadius(0.5)
    reflection.setDistance(4.72)
    reflection.setStartPosAlpha(0)
    reflection.setEndPosAlpha(60)
    reflection.setDirection(90)
    reflection.setScaleHorizontal(100)
    reflection.setScaleVertical(-100)
    reflection.setStartReflectionOpacity(60)
    reflection.setEndReflectionOpacity(0.9)
    reflection.setRectangleAlign(RectangleAlignment.BottomLeft)
finally:
    presentation.dispose()
```

### **Zastosuj efekt poświaty do tekstu**

Stosujemy efekt poświaty do tekstu, aby go rozświetlić lub wyróżnić, używając tego kodu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getEffectFormat().enableGlowEffect()
    glow = portion_format.getEffectFormat().getGlowEffect()
    glow.getColor().setR(jpype.JByte(-1))
    glow.getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54)
    glow.setRadius(7)
finally:
    presentation.dispose()
```

Wynik operacji:

![Tekst z efektem poświaty](image-20200930114621-7.png)

{{% alert color="info" title="Note" %}}
Możesz zmienić parametry cienia, odbicia i poświaty. Właściwości efektów są ustawiane oddzielnie dla każdej części tekstu.
{{% /alert %}}

### **Używanie transformacji w WordArt**

Użyj [TextFrameFormat.setTransform](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframeformat/#setTransform) aby przekształcić cały blok tekstowy:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, TextShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")

    text_frame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour)
finally:
    presentation.dispose()
```

Wynik:

![Tekst z transformacją łuku](image-20200930114712-8.png)

{{% alert color="info" title="Note" %}}
Zarówno Microsoft PowerPoint, jak i Aspose.Slides dla Pythona przez Java udostępniają pewną liczbę wstępnie zdefiniowanych typów transformacji.
{{% /alert %}}

**Używanie PowerPoint**

Aby uzyskać dostęp do wstępnie zdefiniowanych typów transformacji, przejdź do: **Format** -> **TextEffect** -> **Transform**

**Używanie Aspose.Slides**

Aby wybrać typ transformacji, użyj wyliczenia [TextShapeType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textshapetype/).

### **Zastosuj efekty 3D do tekstu i kształtów**

Stosujemy efekt 3D do kształtu tekstowego za pomocą tego przykładowego kodu:

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
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    auto_shape.getTextFrame().setText("Aspose.Slides")

    three_d_format = auto_shape.getThreeDFormat()
    three_d_format.getBevelBottom().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelBottom().setHeight(10.5)
    three_d_format.getBevelBottom().setWidth(10.5)

    three_d_format.getBevelTop().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelTop().setHeight(12.5)
    three_d_format.getBevelTop().setWidth(11)

    three_d_format.getExtrusionColor().setColor(Color.ORANGE)
    three_d_format.setExtrusionHeight(6)

    three_d_format.getContourColor().setColor(Color.RED)
    three_d_format.setContourWidth(1.5)

    three_d_format.setDepth(3)

    three_d_format.setMaterial(MaterialPresetType.Plastic)

    three_d_format.getLightRig().setDirection(LightingDirection.Top)
    three_d_format.getLightRig().setLightType(LightRigPresetType.Balanced)
    three_d_format.getLightRig().setRotation(0, 0, 40)

    three_d_format.getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

Powstały tekst i jego kształt:

![Kształt tekstu z efektami 3D](image-20200930114816-9.png)

Stosujemy efekt 3D do tekstu przy użyciu tego kodu w Pythonie:

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
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")

    three_d_format = text_frame.getTextFrameFormat().getThreeDFormat()
    three_d_format.getBevelBottom().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelBottom().setHeight(3.5)
    three_d_format.getBevelBottom().setWidth(3.5)

    three_d_format.getBevelTop().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelTop().setHeight(4)
    three_d_format.getBevelTop().setWidth(4)

    three_d_format.getExtrusionColor().setColor(Color.ORANGE)
    three_d_format.setExtrusionHeight(6)

    three_d_format.getContourColor().setColor(Color.RED)
    three_d_format.setContourWidth(1.5)

    three_d_format.setDepth(3)

    three_d_format.setMaterial(MaterialPresetType.Plastic)

    three_d_format.getLightRig().setDirection(LightingDirection.Top)
    three_d_format.getLightRig().setLightType(LightRigPresetType.Balanced)
    three_d_format.getLightRig().setRotation(0, 0, 40)

    three_d_format.getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

Wynik operacji:

![Tekst z efektami 3D](image-20200930114905-10.png)

{{% alert color="info" title="Note" %}}
Zastosowanie efektów 3D do tekstu lub jego kształtów oraz interakcje między efektami opierają się na określonych zasadach.

Rozważ scenę dla tekstu i kształtu zawierającego ten tekst. Efekt 3D zawiera reprezentację obiektu 3D oraz scenę, w której obiekt jest umieszczony.

- Gdy scena jest ustawiona zarówno dla kształtu, jak i dla tekstu, priorytet ma scena kształtu — scena tekstu jest ignorowana.
- Gdy kształt nie ma własnej sceny, ale posiada reprezentację 3D, używana jest scena tekstu.
- W przeciwnym razie — gdy kształt pierwotnie nie ma efektu 3D — kształt jest płaski i efekt 3D jest stosowany tylko do tekstu.

Reguły te dotyczą metod [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/pl/python-java/aspose.slides/threedformat/#getLightRig) i [ThreeDFormat.getCamera](https://reference.aspose.com/slides/pl/python-java/aspose.slides/threedformat/#getCamera).
{{% /alert %}}

## **Zastosuj efekty zewnętrznego cienia do tekstu**

Aspose.Slides dla Pythona przez Java udostępnia klasy [OuterShadow](https://reference.aspose.com/slides/pl/python-java/aspose.slides/outershadow/) i [InnerShadow](https://reference.aspose.com/slides/pl/python-java/aspose.slides/innershadow/), które pozwalają zastosować efekty cienia do tekstu w [TextFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframe/). Postępuj zgodnie z następującymi krokami:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) .
2. Uzyskaj odwołanie do slajdu, używając jego indeksu.
3. Dodaj prostokątny kształt do slajdu.
4. Uzyskaj dostęp do ramki tekstowej powiązanej z kształtem.
5. Wyłącz wypełnienie kształtu.
6. Włącz efekt zewnętrznego cienia.
7. Ustaw promień rozmycia cienia.
8. Ustaw kierunek cienia.
9. Ustaw odległość cienia.
10. Wyrównaj cień do góry po lewej.
11. Ustaw kolor cienia na czarny.
12. Zapisz prezentację jako plik [PPTX](https://docs.fileformat.com/presentation/pptx/) .

Ten przykładowy kod w Pythonie przez Java — implementacja powyższych kroków — pokazuje, jak zastosować efekt zewnętrznego cienia do tekstu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetColor, RectangleAlignment, SaveFormat, ShapeType

presentation = Presentation()
try:
    # Uzyskaj odwołanie do slajdu
    slide = presentation.getSlides().get_Item(0)

    # Dodaj AutoShape typu Rectangle
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50)

    # Dodaj TextFrame do prostokąta
    auto_shape.addTextFrame("Aspose TextBox")

    # Wyłącz wypełnienie kształtu, jeśli chcemy uzyskać cień tekstu
    auto_shape.getFillFormat().setFillType(FillType.NoFill)

    # Dodaj zewnętrzny cień i ustaw wszystkie potrzebne parametry
    auto_shape.getEffectFormat().enableOuterShadowEffect()
    shadow = auto_shape.getEffectFormat().getOuterShadowEffect()
    shadow.setBlurRadius(4.0)
    shadow.setDirection(45)
    shadow.setDistance(3)
    shadow.setRectangleAlign(RectangleAlignment.TopLeft)
    shadow.getShadowColor().setPresetColor(PresetColor.Black)

    # Zapisz prezentację na dysk
    presentation.save("pres_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zastosuj efekt wewnętrznego cienia do kształtów**

Postępuj zgodnie z poniższymi krokami:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) .
2. Uzyskaj odwołanie do slajdu.
3. Dodaj prostokątny kształt.
4. Włącz efekt wewnętrznego cienia.
5. Ustaw wszystkie niezbędne parametry.
6. Ustaw typ koloru cienia na użycie koloru motywu.
7. Ustaw kolor motywu.
8. Zapisz prezentację jako plik [PPTX](https://docs.fileformat.com/presentation/pptx/) .

Ten przykładowy kod (oparty na powyższych krokach) pokazuje, jak zastosować efekt wewnętrznego cienia do tekstu w kształcie w Pythonie przez Java:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorType, FillType, Presentation, SaveFormat, SchemeColor, ShapeType

presentation = Presentation()
try:
    # Uzyskaj odwołanie do slajdu
    slide = presentation.getSlides().get_Item(0)

    # Dodaj AutoShape typu Rectangle
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300)
    auto_shape.getFillFormat().setFillType(FillType.NoFill)

    # Dodaj TextFrame do prostokąta
    auto_shape.addTextFrame("Aspose TextBox")
    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion_format = portion.getPortionFormat()
    portion_format.setFontHeight(50)

    # Włącz efekt wewnętrznego cienia
    effect_format = portion_format.getEffectFormat()
    effect_format.enableInnerShadowEffect()

    # Ustaw wszystkie niezbędne parametry
    inner_shadow = effect_format.getInnerShadowEffect()
    inner_shadow.setBlurRadius(8.0)
    inner_shadow.setDirection(90.0)
    inner_shadow.setDistance(6.0)
    inner_shadow.getShadowColor().setB(jpype.JByte(-67))

    # Ustaw ColorType jako Scheme
    inner_shadow.getShadowColor().setColorType(ColorType.Scheme)

    # Ustaw kolor schematu
    inner_shadow.getShadowColor().setSchemeColor(SchemeColor.Accent1)

    # Zapisz prezentację
    presentation.save("WordArt_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Czy mogę używać efektów WordArt z różnymi czcionkami lub skryptami (np. arabskim, chińskim)?**

Tak, Aspose.Slides obsługuje Unicode i współpracuje ze wszystkimi głównymi czcionkami i skryptami. Efekty WordArt, takie jak cień, wypełnienie i obrys, mogą być stosowane niezależnie od języka, choć dostępność czcionek i renderowanie mogą zależeć od czcionek systemowych.

**Czy mogę zastosować efekty WordArt do elementów master slajdu?**

Tak, możesz stosować efekty WordArt do kształtów na slajdach master, w tym do pól tytułowych, stopek lub tekstu w tle. Zmiany w układzie master będą odzwierciedlane we wszystkich powiązanych slajdach.

**Czy efekty WordArt wpływają na rozmiar pliku prezentacji?**

Nieznacznie. Efekty WordArt, takie jak cienie, poświaty i wypełnienia gradientowe, mogą nieco zwiększyć rozmiar pliku ze względu na dodatkowe metadane formatowania, ale różnica zwykle jest pomijalna.

**Czy mogę podglądać wynik efektów WordArt bez zapisywania prezentacji?**

Tak, możesz renderować slajdy zawierające WordArt do obrazów (np. PNG, JPEG) używając [Shape.getImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getImage) lub [Slide.getImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slide/#getImage). To pozwala podglądać wynik w pamięci lub na ekranie przed zapisaniem lub wyeksportowaniem pełnej prezentacji.