---
title: Tworzenie i stosowanie efektów WordArt na Androidzie
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
- efekt wyświetlania
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
description: "Utwórz i dostosuj efekty WordArt w Aspose.Slides dla Androida. Ten przewodnik krok po kroku pomaga programistom ulepszyć prezentacje profesjonalnym tekstem w Javie."
---
## **Przegląd**

Efekty WordArt pozwalają dodać wizualnie atrakcyjny, stylizowany tekst do Twoich prezentacji PowerPoint. Dzięki Aspose.Slides programiści mogą programowo tworzyć, dostosowywać i zarządzać WordArt tak jak w Microsoft PowerPoint — bez konieczności instalacji Office. Ten artykuł przedstawia przegląd pracy z WordArt, w tym jak stosować transformacje tekstu, style wypełnień, kontury, cienie i inne opcje formatowania, aby treść prezentacji była bardziej ekspresyjna i angażująca. WordArt umożliwia traktowanie tekstu jako obiektu graficznego. Składa się z efektów lub specjalnych modyfikacji zastosowanych do tekstu, aby uczynić go bardziej atrakcyjnym lub zauważalnym.

## **Utwórz prosty szablon WordArt i zastosuj go do tekstu**

**Przy użyciu Aspose.Slides** 

Najpierw tworzymy prosty tekst przy użyciu tego kodu Java:

``` java
import com.aspose.slides.*;

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
Teraz ustawiamy wysokość czcionki tekstu na większą wartość, aby efekt był bardziej widoczny, przy pomocy tego kodu:

``` java 
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    IPortion portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    FontData fontData = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(fontData);
    portion.getPortionFormat().setFontHeight(36);
} finally {
    if (pres != null) pres.dispose();
}

```

**Przy użyciu Microsoft PowerPoint**

Przejdź do menu efektów WordArt w Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Z menu po prawej możesz wybrać gotowy efekt WordArt. Z menu po lewej możesz określić ustawienia nowego WordArt. 

Oto niektóre dostępne parametry lub opcje:

![todo:image_alt_text](image-20200930114015-3.png)

**Przy użyciu Aspose.Slides**

Tutaj stosujemy wzorzec koloru [SmallGrid](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/PatternStyle#SmallGrid) do tekstu i dodajemy czarną obwódkę o szerokości 1, używając tego kodu:

``` java 
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.ORANGE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
} finally {
    if (pres != null) pres.dispose();
}
```

Wynikowy tekst:

![todo:image_alt_text](image-20200930114108-4.png)

## **Zastosuj inne efekty WordArt**

**Przy użyciu Microsoft PowerPoint**

Z interfejsu programu możesz zastosować te efekty do tekstu, bloku tekstowego, kształtu lub podobnego elementu:

![todo:image_alt_text](image-20200930114129-5.png)

Na przykład efekty Cień, Odbicie i Poświata mogą być zastosowane do tekstu; formaty 3D i obroty 3D mogą być zastosowane do bloku tekstowego; właściwość Miękkie krawędzie może być zastosowana do obiektu Shape (działa także, gdy nie jest ustawiona żadna własność Format 3D). 

### **Zastosuj efekty cienia**

Tutaj chcemy ustawić właściwości dotyczące wyłącznie tekstu. Stosujemy efekt cienia do tekstu przy użyciu tego kodu w Javie:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

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
} finally {
    if (pres != null) pres.dispose();
}
```

API Aspose.Slides obsługuje trzy typy cieni: OuterShadow, InnerShadow i PresetShadow. 

Przy użyciu PresetShadow możesz zastosować cień do tekstu (korzystając z wartości predefiniowanych). 

**Przy użyciu Microsoft PowerPoint**

W PowerPoint możesz używać jednego typu cienia. Oto przykład:

![todo:image_alt_text](image-20200930114225-6.png)

**Przy użyciu Aspose.Slides**

Aspose.Slides pozwala właściwie zastosować dwa typy cieni jednocześnie: InnerShadow i PresetShadow.

**Uwaga:**

- Gdy OuterShadow i PresetShadow są używane razem, zastosowany zostaje tylko efekt OuterShadow. 
- Jeśli OuterShadow i InnerShadow są używane jednocześnie, wynikowy efekt zależy od wersji PowerPoint. Na przykład w PowerPoint 2013 efekt jest podwajany. Natomiast w PowerPoint 2007 zastosowany zostaje efekt OuterShadow. 

### **Zastosuj efekty odbicia do tekstu**

Dodajemy odbicie do tekstu przy pomocy tego fragmentu kodu w Javie:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

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
} finally {
    if (pres != null) pres.dispose();
}
```

### **Zastosuj efekty poświaty do tekstu**

Stosujemy efekt poświaty do tekstu, aby błyszczał lub wyróżniał się, używając tego kodu:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    portion.getPortionFormat().getEffectFormat().enableGlowEffect();
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
} finally {
    if (pres != null) pres.dispose();
}
```

Wynik operacji:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="info" %}} 

Możesz zmienić parametry cienia, odbicia i poświaty. Właściwości efektów są ustawiane osobno dla każdej części tekstu. 

{{% /alert %}} 

### **Użyj transformacji w WordArt**

Używamy właściwości Transform (obowiązującej dla całego bloku tekstu) przy pomocy tego kodu:
``` java 
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
} finally {
    if (pres != null) pres.dispose();
}

```

Wynik:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="info" %}} 

Zarówno Microsoft PowerPoint, jak i Aspose.Slides for Android via Java udostępniają określoną liczbę predefiniowanych typów transformacji.

{{% /alert %}} 

**Przy użyciu PowerPoint**

Aby uzyskać dostęp do predefiniowanych typów transformacji, przejdź do: **Format** -> **TextEffect** -> **Transform**

**Przy użyciu Aspose.Slides**

Aby wybrać typ transformacji, użyj wyliczenia TextShapeType. 

### **Zastosuj efekty 3D do tekstu i kształtów**

Ustawiamy efekt 3D dla kształtu tekstowego przy pomocy tego przykładowego kodu:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    autoShape.getTextFrame().setText("Aspose.Slides");

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
} finally {
    if (pres != null) pres.dispose();
}
```

Wynikowy tekst i jego kształt:

![todo:image_alt_text](image-20200930114816-9.png)

Stosujemy efekt 3D do tekstu przy pomocy tego kodu Java:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

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
} finally {
    if (pres != null) pres.dispose();
}
```

Wynik operacji:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="info" %}} 

Zastosowanie efektów 3D do tekstów lub ich kształtów oraz interakcje między efektami opierają się na określonych regułach. 

Rozważ scenę dla tekstu i kształtu zawierającego ten tekst. Efekt 3D zawiera reprezentację obiektu 3D oraz scenę, na której obiekt został umieszczony. 

- Gdy scena jest ustawiona zarówno dla figury, jak i dla tekstu, scena figury ma wyższy priorytet — scena tekstu jest ignorowana. 
- Gdy figura nie ma własnej sceny, ale ma reprezentację 3D, używana jest scena tekstu. 
- W przeciwnym razie — gdy kształt pierwotnie nie ma efektu 3D — kształt jest płaski i efekt 3D jest stosowany tylko do tekstu. 

Opisy te są powiązane z metodami ThreeDFormat.getLightRig() i ThreeDFormat.getCamera().

{{% /alert %}} 

## **Zastosuj zewnętrzne cienie do tekstu**
Aspose.Slides for Android via Java udostępnia klasy [**IOuterShadow**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ioutershadow/) i [**IInnerShadow**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iinnershadow/), które pozwalają stosować efekty cieni do tekstu zawartego w [TextFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/textframe/). Postępuj zgodnie z poniższymi krokami:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation).  
2. Pobierz referencję slajdu, używając jego indeksu.  
3. Dodaj AutoShape typu Rectangle do slajdu.  
4. Uzyskaj dostęp do TextFrame powiązanego z AutoShape.  
5. Ustaw właściwość FillType AutoShape na NoFill.  
6. Zainstaluj klasę OuterShadow.  
7. Ustaw BlurRadius cienia.  
8. Ustaw Direction cienia.  
9. Ustaw Distance cienia.  
10. Ustaw RectangleAlign na TopLeft.  
11. Ustaw PresetColor cienia na Black.  
12. Zapisz prezentację jako plik [PPTX](https://docs.fileformat.com/presentation/pptx/).

Ten przykładowy kod w Javie — implementacja powyższych kroków — pokazuje, jak zastosować efekt zewnętrznego cienia do tekstu:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Pobierz referencję do slajdu
    ISlide sld = pres.getSlides().get_Item(0);

    // Dodaj AutoShape typu Prostokąt
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Dodaj TextFrame do prostokąta
    ashp.addTextFrame("Aspose TextBox");

    // Wyłącz wypełnienie kształtu, aby uzyskać cień tekstu
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Dodaj zewnętrzny cień i ustaw wszystkie niezbędne parametry
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    // Zapisz prezentację na dysk
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zastosuj wewnętrzne cienie do kształtów**
Postępuj według tych kroków:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation).  
2. Pobierz referencję slajdu.  
3. Dodaj AutoShape typu Rectangle.  
4. Włącz InnerShadowEffect.  
5. Ustaw wszystkie niezbędne parametry.  
6. Ustaw ColorType na Scheme.  
7. Ustaw Scheme Color.  
8. Zapisz prezentację jako plik [PPTX](https://docs.fileformat.com/presentation/pptx/).

Ten przykładowy kod (oparty na powyższych krokach) pokazuje, jak zastosować wewnętrzny cień do tekstu w Javie:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Pobierz referencję do slajdu
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

    // Ustaw ColorType na Scheme
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

### Czy mogę używać efektów WordArt z różnymi czcionkami lub skryptami (np. arabskim, chińskim)?

Tak, Aspose.Slides obsługuje Unicode i działa ze wszystkimi głównymi czcionkami i skryptami. Efekty WordArt, takie jak cień, wypełnienie i kontur, mogą być stosowane niezależnie od języka, choć dostępność czcionek i renderowanie mogą zależeć od czcionek systemowych.

### Czy mogę stosować efekty WordArt do elementów mastera slajdów?

Tak, możesz stosować efekty WordArt do kształtów na slajdach master, w tym do miejsc na tytuł, stopki lub tekstu w tle. Zmiany w układzie master będą odzwierciedlane na wszystkich powiązanych slajdach.

### Czy efekty WordArt wpływają na rozmiar pliku prezentacji?

Nieznacznie. Efekty WordArt, takie jak cienie, poświaty i wypełnienia gradientowe, mogą nieco zwiększyć rozmiar pliku ze względu na dodatkowe metadane formatowania, ale różnica jest zazwyczaj pomijalna.

### Czy mogę podglądać rezultat efektów WordArt bez zapisywania prezentacji?

Tak, możesz renderować slajdy zawierające WordArt do obrazów (np. PNG, JPEG) przy użyciu metody `getImage` z interfejsów [IShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/) lub [ISlide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islide/). Dzięki temu możesz podglądać rezultat w pamięci lub na ekranie przed zapisaniem albo wyeksportowaniem pełnej prezentacji.