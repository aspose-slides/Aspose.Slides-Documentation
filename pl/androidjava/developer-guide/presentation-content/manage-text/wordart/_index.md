---
title: Tworzenie i stosowanie efektów WordArt w Androidzie
linktitle: WordArt
type: docs
weight: 110
url: /pl/androidjava/wordart/
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
- Android
- Java
- Aspose.Slides
description: "Tworzenie i dostosowywanie efektów WordArt w Aspose.Slides dla Androida. Ten przewodnik krok po kroku pomaga programistom ulepszyć prezentacje profesjonalnym tekstem w Javie."
---
## **Przegląd**

Efekty WordArt pozwalają dodać wizualnie atrakcyjny, stylizowany tekst do prezentacji PowerPoint. Dzięki Aspose.Slides programiści mogą programowo tworzyć, dostosowywać i zarządzać WordArt tak jak w Microsoft PowerPoint — bez konieczności instalacji Office. Ten artykuł przedstawia przegląd pracy z WordArt, w tym jak stosować transformacje tekstu, style wypełnień, obrysy, cienie i inne opcje formatowania, aby treść prezentacji była bardziej wyrazista i angażująca. WordArt umożliwia traktowanie tekstu jako obiektu graficznego. Składa się z efektów lub specjalnych modyfikacji stosowanych do tekstu, aby był bardziej atrakcyjny lub zauważalny.

## **Utwórz prosty szablon WordArt i zastosuj go do tekstu**

**Używanie Aspose.Slides** 

Najpierw tworzymy prosty tekst przy użyciu tego kodu Java:

``` java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();

    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    if (pres != null) pres.dispose();
}
```
Teraz ustawiamy wysokość czcionki tekstu na większą wartość, aby efekt był bardziej widoczny, używając tego kodu:

``` java 
FontData fontData = new FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```

**Używanie Microsoft PowerPoint**

Przejdź do menu efektów WordArt w Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Z menu po prawej możesz wybrać predefiniowany efekt WordArt. Z menu po lewej możesz określić ustawienia nowego WordArt. 

Oto niektóre z dostępnych parametrów lub opcji:

![todo:image_alt_text](image-20200930114015-3.png)

**Używanie Aspose.Slides**

Tutaj stosujemy wzór koloru [SmallGrid](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/PatternStyle#SmallGrid) do tekstu i dodajemy czarną obwódkę o szerokości 1, używając tego kodu:

``` java 
portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.ORANGE);
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
```

Uzyskany tekst:

![todo:image_alt_text](image-20200930114108-4.png)

## **Zastosuj inne efekty WordArt**

**Używanie Microsoft PowerPoint**

Z interfejsu programu możesz zastosować te efekty do tekstu, bloku tekstowego, kształtu lub podobnego elementu:

![todo:image_alt_text](image-20200930114129-5.png)

Na przykład efekty Cień, Odbicie i Poświata można zastosować do tekstu; formatowanie 3D i obrót 3D można zastosować do bloku tekstowego; właściwość Miękkie Krawędzie można zastosować do obiektu kształtu (działa ona również, gdy nie ustawiono właściwości Format 3D). 

### **Zastosuj efekty cienia**

Tutaj zamierzamy ustawić właściwości dotyczące wyłącznie tekstu. Stosujemy efekt cienia do tekstu przy użyciu tego kodu w Java:

``` java
portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.BLACK);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(65);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4.73);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(2);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(30);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32f);
```

API Aspose.Slides obsługuje trzy typy cieni: OuterShadow, InnerShadow i PresetShadow. 

Przy użyciu PresetShadow możesz zastosować cień do tekstu (korzystając z wartości predefiniowanych). 

**Używanie Microsoft PowerPoint**

W PowerPoint można używać jednego typu cienia. Oto przykład:

![todo:image_alt_text](image-20200930114225-6.png)

**Używanie Aspose.Slides**

Aspose.Slides faktycznie pozwala zastosować dwa typy cieni jednocześnie: InnerShadow i PresetShadow.

**Uwaga:**

- Gdy OuterShadow i PresetShadow są używane razem, stosowany jest tylko efekt OuterShadow. 
- Jeśli OuterShadow i InnerShadow są używane jednocześnie, wynikowy lub zastosowany efekt zależy od wersji PowerPoint. Na przykład w PowerPoint 2013 efekt jest podwajany. W PowerPoint 2007 stosowany jest efekt OuterShadow. 

### **Zastosuj efekty odbicia do tekstu**

Dodajemy odbicie do tekstu przy użyciu tego przykładu kodu w Java:

``` java
portion.getPortionFormat().getEffectFormat().enableReflectionEffect();
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(0f);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(60f);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(60f);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(0.9f);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.BottomLeft);   
```

### **Zastosuj efekty poświaty do tekstu**

Stosujemy efekt poświaty do tekstu, aby się świecił lub wyróżniał, używając tego kodu:

``` java
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```

Wynik operacji:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Możesz zmienić parametry cienia, odbicia i poświaty. Właściwości efektów są ustawiane osobno dla każdej części tekstu. 

{{% /alert %}} 

### **Użyj transformacji w WordArt**

Używamy właściwości Transform (obowiązującej dla całego bloku tekstu) poprzez ten kod:
``` java 
textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
```

Wynik:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Zarówno Microsoft PowerPoint, jak i Aspose.Slides dla Androida w Javie oferują pewną liczbę predefiniowanych typów transformacji.

{{% /alert %}} 

**Użycie PowerPoint**

Aby uzyskać dostęp do predefiniowanych typów transformacji, przejdź przez: **Format** -> **TextEffect** -> **Transform**

**Używanie Aspose.Slides**

Aby wybrać typ transformacji, użyj wyliczenia TextShapeType. 

### **Zastosuj efekty 3D do tekstu i kształtów**

Ustawiamy efekt 3D dla kształtu tekstowego przy użyciu tego przykładowego kodu:

``` java
autoShape.getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);

autoShape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
autoShape.getThreeDFormat().getBevelTop().setWidth(11);

autoShape.getThreeDFormat().getExtrusionColor().setColor(Color.ORANGE);
autoShape.getThreeDFormat().setExtrusionHeight(6);

autoShape.getThreeDFormat().getContourColor().setColor(Color.RED);
autoShape.getThreeDFormat().setContourWidth(1.5);

autoShape.getThreeDFormat().setDepth(3);

autoShape.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

autoShape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);

autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
```

Uzyskany tekst i jego kształt:

![todo:image_alt_text](image-20200930114816-9.png)

Stosujemy efekt 3D do tekstu przy użyciu tego kodu Java:

``` java
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);

textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);

textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(Color.ORANGE);
textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(Color.RED);
textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);

textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);

textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);

textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
```

Wynik operacji:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

Stosowanie efektów 3D do tekstów lub ich kształtów oraz interakcje między efektami opierają się na określonych zasadach. 

Rozważ scenę dla tekstu i kształtu zawierającego ten tekst. Efekt 3D zawiera reprezentację obiektu 3D oraz scenę, na której obiekt został umieszczony. 

- Gdy scena jest ustawiona zarówno dla figury, jak i tekstu, scena figury ma wyższy priorytet — scena tekstu jest ignorowana. 
- Gdy figura nie posiada własnej sceny, ale ma reprezentację 3D, używana jest scena tekstu. 
- W przeciwnym razie — gdy kształt pierwotnie nie ma efektu 3D — kształt pozostaje płaski, a efekt 3D jest stosowany tylko do tekstu. 

Te opisy są powiązane z metodami ThreeDFormat.getLightRig() i ThreeDFormat.getCamera(). 

{{% /alert %}} 

## **Zastosuj efekty zewnętrznego cienia do tekstu**
Aspose.Slides dla Androida w Javie udostępnia klasy [**IOuterShadow**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ioutershadow/) i [**IInnerShadow**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iinnershadow/), które pozwalają stosować efekty cienia do tekstu umieszczonego w [TextFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/textframe/). Przejdź przez następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation) .
2. Uzyskaj odwołanie do slajdu, używając jego indeksu.
3. Dodaj AutoShape typu Rectangle do slajdu.
4. Uzyskaj dostęp do TextFrame powiązanego z AutoShape.
5. Ustaw właściwość FillType AutoShape na NoFill.
6. Zainicjuj klasę OuterShadow.
7. Ustaw BlurRadius cienia.
8. Ustaw Direction cienia.
9. Ustaw Distance cienia.
10. Ustaw RectanglelAlign na TopLeft.
11. Ustaw PresetColor cienia na Black.
12. Zapisz prezentację jako plik [PPTX](https://docs.fileformat.com/presentation/pptx/) .

Ten przykładowy kod w Javie — implementacja powyższych kroków — pokazuje, jak zastosować efekt zewnętrznego cienia do tekstu:

```java
Presentation pres = new Presentation();
try {
    // Pobierz odwołanie do slajdu
    ISlide sld = pres.getSlides().get_Item(0);

    // Dodaj AutoShape typu Prostokąt
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Dodaj TextFrame do prostokąta
    ashp.addTextFrame("Aspose TextBox");

    // Wyłącz wypełnienie kształtu, jeśli chcemy uzyskać cień tekstu
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Dodaj zewnętrzny cień i ustaw wszystkie niezbędne parametry
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    //Zapisz prezentację na dysku
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zastosuj efekty wewnętrznego cienia do kształtów**
Przejdź przez następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation) .
2. Uzyskaj odwołanie do slajdu.
3. Dodaj AutoShape typu Rectangle.
4. Włącz InnerShadowEffect.
5. Ustaw wszystkie niezbędne parametry.
6. Ustaw ColorType na Scheme.
7. Ustaw kolor Scheme.
8. Zapisz prezentację jako plik [PPTX](https://docs.fileformat.com/presentation/pptx/) .

Ten przykładowy kod (oparty na powyższych krokach) pokazuje, jak dodać łącze między dwoma kształtami w Javie:

```java
Presentation pres = new Presentation();
try {
    // Pobierz odwołanie do slajdu
    ISlide slide = pres.getSlides().get_Item(0);

    // Dodaj AutoShape typu Prostokąt
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Dodaj TextFrame do prostokąta
    ashp.addTextFrame("Aspose TextBox");
    IPortion port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormat pf = port.getPortionFormat();
    pf.setFontHeight(50);

    // Włącz efekt wewnętrznego cienia
    IEffectFormat ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();

    // Ustaw wszystkie niezbędne parametry
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0F);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB((byte)189);

    // Ustaw ColorType jako Scheme
    ef.getInnerShadowEffect().getShadowColor().setColorType(ColorType.Scheme);

    // Ustaw kolor schematu
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // Zapisz prezentację
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Czy mogę używać efektów WordArt z różnymi czcionkami lub skryptami (np. arabski, chiński)?**

Tak, Aspose.Slides obsługuje Unicode i współpracuje ze wszystkimi głównymi czcionkami i skryptami. Efekty WordArt, takie jak cień, wypełnienie i obrys, można zastosować niezależnie od języka, choć dostępność czcionek i renderowanie mogą zależeć od czcionek systemowych.

**Czy mogę zastosować efekty WordArt do elementów mastera slajdu?**

Tak, możesz stosować efekty WordArt do kształtów na slajdach master, w tym symboli tytułu, stopki lub tekstu tła. Zmiany w układzie mastera będą odzwierciedlane na wszystkich powiązanych slajdach.

**Czy efekty WordArt wpływają na rozmiar pliku prezentacji?**

Nieznacznie. Efekty WordArt, takie jak cienie, poświaty i gradientowe wypełnienia, mogą nieco zwiększyć rozmiar pliku ze względu na dodatkowe metadane formatowania, ale różnica jest zazwyczaj pomijalna.

**Czy mogę podglądnąć wynik efektów WordArt bez zapisywania prezentacji?**

Tak, możesz renderować slajdy zawierające WordArt do obrazów (np. PNG, JPEG) używając metody `getImage` z interfejsów [IShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/) lub [ISlide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islide/). Pozwala to na podgląd wyniku w pamięci lub na ekranie przed zapisaniem lub wyeksportowaniem pełnej prezentacji.