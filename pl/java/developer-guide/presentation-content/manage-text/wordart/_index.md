---
title: Tworzenie i stosowanie efektów WordArt w Javie
linktitle: WordArt
type: docs
weight: 110
url: /pl/java/wordart/
keywords:
- WordArt
- tworzenie WordArt
- szablon WordArt
- efekt WordArt
- efekt cienia
- efekt wyświetlania
- efekt poświaty
- transformacja WordArt
- efekt 3D
- efekt zewnętrznego cienia
- efekt wewnętrznego cienia
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Tworzenie i dostosowywanie efektów WordArt w Aspose.Slides dla Javy. Ten przewodnik krok po kroku pomaga programistom ulepszyć prezentacje profesjonalnym tekstem w Javie."
---
## **Przegląd**

Efekty WordArt pozwalają dodać wizualnie atrakcyjny, stylizowany tekst do prezentacji PowerPoint. Dzięki Aspose.Slides programiści mogą programowo tworzyć, dostosowywać i zarządzać WordArt tak samo jak w Microsoft PowerPoint — bez konieczności instalowania Office. Ten artykuł przedstawia przegląd pracy z WordArt, w tym stosowanie transformacji tekstu, stylów wypełnienia, konturów, cieni i innych opcji formatowania, aby zawartość prezentacji była bardziej wyrazista i angażująca. WordArt pozwala traktować tekst jako obiekt graficzny. Składa się z efektów lub specjalnych modyfikacji stosowanych do tekstu, aby uczynić go bardziej atrakcyjnym lub zauważalnym.

## **Tworzenie prostego szablonu WordArt i stosowanie go do tekstu**

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
Teraz ustawiamy wysokość czcionki tekstu na większą wartość, aby efekt był bardziej widoczny, za pomocą tego kodu:

``` java 
FontData fontData = new FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```

**Używanie Microsoft PowerPoint**

Przejdź do menu efektów WordArt w Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Z menu po prawej możesz wybrać gotowy efekt WordArt. Z menu po lewej możesz określić ustawienia nowego WordArt. 

Oto niektóre dostępne parametry lub opcje:

![todo:image_alt_text](image-20200930114015-3.png)

**Używanie Aspose.Slides**

Tutaj stosujemy kolor wzoru [SmallGrid](https://reference.aspose.com/slides/pl/java/com.aspose.slides/PatternStyle#SmallGrid) do tekstu i dodajemy czarną obwódkę o szerokości 1 przy użyciu tego kodu:

``` java 
portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.ORANGE);
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
```

Wynikowy tekst:

![todo:image_alt_text](image-20200930114108-4.png)

## **Stosowanie innych efektów WordArt**

**Używanie Microsoft PowerPoint**

Z interfejsu programu możesz zastosować te efekty do tekstu, bloku tekstowego, kształtu lub podobnego elementu:

![todo:image_alt_text](image-20200930114129-5.png)

Na przykład efekty Cień, Odbicie i Poświata mogą być zastosowane do tekstu; efekty Format 3D i Obrót 3D mogą być zastosowane do bloku tekstowego; właściwość Miękkie krawędzie może być zastosowana do obiektu Shape (działa ona również, gdy nie jest ustawiona właściwość Format 3D). 

### **Stosowanie efektów cienia**

Tutaj zamierzamy ustawić właściwości odnoszące się wyłącznie do tekstu. Stosujemy efekt cienia do tekstu przy użyciu tego kodu w Javie:

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

Przy użyciu PresetShadow możesz zastosować cień do tekstu (korzystając z wartości wstępnych). 

**Używanie Microsoft PowerPoint**

W PowerPoint możesz używać jednego typu cienia. Oto przykład:

![todo:image_alt_text](image-20200930114225-6.png)

**Używanie Aspose.Slides**

Aspose.Slides pozwala na jednoczesne zastosowanie dwóch typów cieni: InnerShadow i PresetShadow.

{{% alert color="primary" %}} 

**Uwaga:**

- Kiedy OuterShadow i PresetShadow są używane razem, stosowany jest tylko efekt OuterShadow. 
- Jeśli OuterShadow i InnerShadow są używane jednocześnie, wynikowy lub zastosowany efekt zależy od wersji PowerPoint. Na przykład w PowerPoint 2013 efekt jest podwajany. Natomiast w PowerPoint 2007 stosowany jest efekt OuterShadow. 

{{% /alert %}} 

### **Stosowanie wyświetlania do tekstów**

Dodajemy wyświetlanie do tekstu za pomocą tego przykładu kodu w Javie:

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

### **Stosowanie efektu poświaty do tekstów**

Stosujemy efekt poświaty do tekstu, aby go rozświetlić lub wyróżnić, przy użyciu tego kodu:

``` java
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```

Wynik operacji:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Możesz zmieniać parametry cienia, wyświetlania i poświaty. Właściwości efektów są ustawiane osobno dla każdej części tekstu. 

{{% /alert %}} 

### **Używanie transformacji w WordArt**

Używamy właściwości Transform (obowiązującej dla całego bloku tekstu) przy pomocy tego kodu:
``` java 
textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
```

Wynik:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Zarówno Microsoft PowerPoint, jak i Aspose.Slides dla Javy udostępniają określoną liczbę wstępnie zdefiniowanych typów transformacji. 

{{% /alert %}} 

**Używanie PowerPoint**

Aby uzyskać dostęp do wstępnie zdefiniowanych typów transformacji, przejdź do: **Format** -> **TextEffect** -> **Transform**

**Używanie Aspose.Slides**

Aby wybrać typ transformacji, użyj wyliczenia TextShapeType. 

### **Stosowanie efektów 3D do tekstów i kształtów**

Ustawiamy efekt 3D dla kształtu tekstowego przy pomocy tego przykładu kodu:

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

Wynikowy tekst i jego kształt:

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

Zastosowanie efektów 3D do tekstów lub ich kształtów oraz interakcje między efektami opierają się na określonych zasadach. 

Rozważ scenę dla tekstu i kształtu zawierającego ten tekst. Efekt 3D zawiera reprezentację obiektu 3D oraz scenę, na której obiekt został umieszczony. 

- Gdy scena jest ustawiona zarówno dla figury, jak i dla tekstu, scena figury ma wyższy priorytet — scena tekstu jest ignorowana. 
- Gdy figura nie ma własnej sceny, ale posiada reprezentację 3D, używana jest scena tekstu. 
- W przeciwnym razie — gdy kształt początkowo nie ma efektu 3D — kształt jest płaski i efekt 3D jest stosowany wyłącznie do tekstu. 

Te opisy są powiązane z metodami ThreeDFormat.getLightRig() i ThreeDFormat.getCamera(). 

{{% /alert %}} 

## **Stosowanie efektów zewnętrznego cienia do tekstów**
Aspose.Slides dla Javy udostępnia klasy [**IOuterShadow**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ioutershadow/) i [**IInnerShadow**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iinnershadow/), które pozwalają zastosować efekty cienia do tekstu zawartego w [TextFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/textframe/). Przejdź przez następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation).  
2. Pobierz referencję do slajdu, używając jego indeksu.  
3. Dodaj AutoShape typu Rectangle do slajdu.  
4. Uzyskaj dostęp do TextFrame powiązanego z AutoShape.  
5. Ustaw właściwość FillType AutoShape na NoFill.  
6. Zainstancjuj klasę OuterShadow.  
7. Ustaw BlurRadius cienia.  
8. Ustaw Direction cienia.  
9. Ustaw Distance cienia.  
10. Ustaw RectanglelAlign na TopLeft.  
11. Ustaw PresetColor cienia na Black.  
12. Zapisz prezentację jako plik [PPTX](https://docs.fileformat.com/presentation/pptx/).  

Ten przykładowy kod w Javie — implementacja powyższych kroków — pokazuje, jak zastosować efekt zewnętrznego cienia do tekstu:

```java
Presentation pres = new Presentation();
try {
    // Pobierz referencję do slajdu
    ISlide sld = pres.getSlides().get_Item(0);

    // Dodaj AutoShape typu Rectangle
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

## **Stosowanie efektu wewnętrznego cienia do kształtów**
Przejdź przez następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation).  
2. Pobierz referencję do slajdu.  
3. Dodaj AutoShape typu Rectangle.  
4. Włącz efekt InnerShadowEffect.  
5. Ustaw wszystkie niezbędne parametry.  
6. Ustaw ColorType jako Scheme.  
7. Ustaw Scheme Color.  
8. Zapisz prezentację jako plik [PPTX](https://docs.fileformat.com/presentation/pptx/).  

Ten przykładowy kod (oparty na powyższych krokach) pokazuje, jak dodać łącze między dwoma kształtami w Javie:

```java
Presentation pres = new Presentation();
try {
    // Pobierz referencję do slajdu
    ISlide slide = pres.getSlides().get_Item(0);

    // Dodaj AutoShape typu Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Dodaj TextFrame do prostokąta
    ashp.addTextFrame("Aspose TextBox");
    IPortion port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormat pf = port.getPortionFormat();
    pf.setFontHeight(50);

    // Włącz InnerShadowEffect
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

**Czy mogę używać efektów WordArt z różnymi czcionkami lub skryptami (np. arabskim, chińskim)?**

Tak, Aspose.Slides obsługuje Unicode i działa ze wszystkimi głównymi czcionkami i skryptami. Efekty WordArt, takie jak cień, wypełnienie i kontur, mogą być stosowane niezależnie od języka, choć dostępność czcionek i renderowanie mogą zależeć od czcionek systemowych.

**Czy mogę zastosować efekty WordArt do elementów master slajdu?**

Tak, możesz stosować efekty WordArt do kształtów na slajdach wzorcowych, w tym do pól tytułowych, stopek lub tekstu tła. Zmiany w układzie master będą odzwierciedlone na wszystkich powiązanych slajdach.

**Czy efekty WordArt wpływają na rozmiar pliku prezentacji?**

Nieznacznie. Efekty WordArt, takie jak cienie, poświaty i wypełnienia gradientowe, mogą nieco zwiększyć rozmiar pliku ze względu na dodatkowe metadane formatowania, ale różnica zazwyczaj jest pomijalna.

**Czy mogę podglądnąć wynik efektów WordArt bez zapisywania prezentacji?**

Tak, możesz renderować slajdy zawierające WordArt do obrazów (np. PNG, JPEG) używając metody `getImage` z interfejsu [IShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishape/) lub [ISlide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/islide/). Umożliwia to podgląd wyniku w pamięci lub na ekranie przed zapisaniem lub wyeksportowaniem pełnej prezentacji.