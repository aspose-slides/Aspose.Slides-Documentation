---
title: Tworzenie i zastosowanie efektów WordArt w JavaScript
linktitle: WordArt
type: docs
weight: 110
url: /pl/nodejs-java/wordart/
keywords:
- WordArt
- tworzenie WordArt
- szablon WordArt
- efekt WordArt
- efekt cienia
- efekt wyświetlania
- efekt poświaty
- przekształcenie WordArt
- efekt 3D
- efekt zewnętrznego cienia
- efekt wewnętrznego cienia
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Twórz i dostosowuj efekty WordArt w Aspose.Slides dla Node.js. Ten przewodnik krok po kroku pomaga programistom udoskonalić prezentacje profesjonalnym tekstem."
---
## **Przegląd**

Efekty WordArt pozwalają dodać wizualnie atrakcyjny, stylizowany tekst do prezentacji PowerPoint. Dzięki Aspose.Slides programiści mogą programowo tworzyć, dostosowywać i zarządzać WordArt tak jak w Microsoft PowerPoint — bez konieczności instalacji pakietu Office. Ten artykuł przedstawia przegląd pracy z WordArt, w tym jak stosować przekształcenia tekstu, style wypełnień, kontury, cienie i inne opcje formatowania, aby treść prezentacji była bardziej wyrazista i angażująca. WordArt pozwala traktować tekst jako obiekt graficzny. Składa się z efektów lub specjalnych modyfikacji stosowanych do tekstu, aby był bardziej atrakcyjny lub zauważalny.

## **Tworzenie prostego szablonu WordArt i zastosowanie go do tekstu**

**Używanie Aspose.Slides**

Najpierw tworzymy prosty tekst przy użyciu tego kodu JavaScript:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    var textFrame = autoShape.getTextFrame();
    var portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
Teraz ustawiamy wysokość czcionki tekstu na większą wartość, aby efekt był bardziej widoczny, przy pomocy tego kodu:

```javascript
var fontData = new aspose.slides.FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```

**Używanie Microsoft PowerPoint**

Przejdź do menu efektów WordArt w programie Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Z menu po prawej możesz wybrać wstępnie zdefiniowany efekt WordArt. Z menu po lewej możesz określić ustawienia nowego WordArt. 

Oto niektóre dostępne parametry lub opcje:

![todo:image_alt_text](image-20200930114015-3.png)

**Używanie Aspose.Slides**

Tutaj stosujemy kolor wzoru [SmallGrid](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/PatternStyle#SmallGrid) do tekstu i dodajemy czarną obwódkę o szerokości 1, używając tego kodu:

```javascript
portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.SmallGrid));
portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
```

Otrzymany tekst:

![todo:image_alt_text](image-20200930114108-4.png)

## **Zastosowanie innych efektów WordArt**

**Używanie Microsoft PowerPoint**

Z klasy programu możesz zastosować te efekty do tekstu, bloku tekstowego, kształtu lub podobnego elementu:

![todo:image_alt_text](image-20200930114129-5.png)

Na przykład efekty Cień, Odbicie i Poświata można zastosować do tekstu; formaty 3D i obroty 3D można zastosować do bloku tekstowego; właściwość Miękkie krawędzie można zastosować do obiektu Shape (działa ona również, gdy nie jest ustawiona żadna właściwość Format 3D). 

### **Stosowanie efektów cienia**

Tutaj zamierzamy ustawić właściwości dotyczące wyłącznie tekstu. Stosujemy efekt cienia na tekst przy użyciu tego kodu w JavaScript:

```javascript
portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(65);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4.73);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(2);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(30);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, 0.32);
```

API Aspose.Slides obsługuje trzy typy cieni: OuterShadow, InnerShadow i PresetShadow. 

Za pomocą PresetShadow możesz zastosować cień do tekstu (korzystając z wartości wstępnych). 

**Używanie Microsoft PowerPoint**

W programie PowerPoint możesz używać jednego typu cienia. Oto przykład:

![todo:image_alt_text](image-20200930114225-6.png)

**Używanie Aspose.Slides**

Aspose.Slides w rzeczywistości pozwala zastosować dwa typy cieni jednocześnie: InnerShadow i PresetShadow.

**Uwagi:**

- Gdy jednocześnie używane są OuterShadow i PresetShadow, stosowany jest tylko efekt OuterShadow. 
- Jeśli OuterShadow i InnerShadow są używane jednocześnie, wynikowy lub zastosowany efekt zależy od wersji PowerPoint. Na przykład w PowerPoint 2013 efekt jest podwajany, natomiast w PowerPoint 2007 stosowany jest efekt OuterShadow. 

### **Zastosowanie wyświetlania do tekstów**

Dodajemy wyświetlanie do tekstu przy użyciu tego przykładu kodu w JavaScript:

```javascript
portion.getPortionFormat().getEffectFormat().enableReflectionEffect();
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(0.0);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(60.0);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(60.0);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(0.9);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(aspose.slides.RectangleAlignment.BottomLeft);
```

### **Zastosowanie efektu poświaty do tekstów**

Stosujemy efekt poświaty na tekst, aby go rozświetlić lub wyróżnić, przy użyciu tego kodu:

```javascript
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR(255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, 0.54);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```

Wynik operacji:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Możesz zmienić parametry cienia, wyświetlania i poświaty. Właściwości efektów są ustawiane osobno dla każdej części tekstu. 

{{% /alert %}} 

### **Użycie przekształceń w WordArt**

Używamy właściwości Transform (obowiązującej dla całego bloku tekstu) przy pomocy tego kodu:
```javascript
textFrame.getTextFrameFormat().setTransform(java.newByte(aspose.slides.TextShapeType.ArchUpPour));
```

Wynik:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Zarówno Microsoft PowerPoint, jak i Aspose.Slides dla Node.js via Java oferują pewną liczbę wstępnie zdefiniowanych typów przekształceń.

{{% /alert %}} 

**Używanie PowerPoint**

Aby uzyskać dostęp do wstępnie zdefiniowanych typów przekształceń, przejdź przez: **Format** -> **TextEffect** -> **Transform**

**Używanie Aspose.Slides**

Aby wybrać typ przekształcenia, użyj wyliczenia TextShapeType. 

### **Zastosowanie efektów 3D do tekstów i kształtów**

Ustawiamy efekt 3D dla kształtu tekstowego przy użyciu tego przykładowego kodu:

```javascript
autoShape.getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);
autoShape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
autoShape.getThreeDFormat().getBevelTop().setWidth(11);
autoShape.getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
autoShape.getThreeDFormat().setExtrusionHeight(6);
autoShape.getThreeDFormat().getContourColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
autoShape.getThreeDFormat().setContourWidth(1.5);
autoShape.getThreeDFormat().setDepth(3);
autoShape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
autoShape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
```

Otrzymany tekst i jego kształt:

![todo:image_alt_text](image-20200930114816-9.png)

Stosujemy efekt 3D na tekst przy użyciu tego kodu JavaScript:

```javascript
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);
textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);
textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);
textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);
textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);
textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
```

Wynik operacji:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

Stosowanie efektów 3D do tekstów lub ich kształtów oraz interakcje między efektami opierają się na określonych zasadach. 

Rozważ scenę dla tekstu oraz kształt zawierający ten tekst. Efekt 3D zawiera reprezentację obiektu 3D oraz scenę, w której obiekt został umieszczony. 

- Gdy scena jest ustawiona zarówno dla figury, jak i tekstu, scena figury ma wyższy priorytet — scena tekstu jest ignorowana. 
- Gdy figura nie ma własnej sceny, ale posiada reprezentację 3D, używana jest scena tekstu. 
- W przeciwnym razie — gdy kształt pierwotnie nie ma efektu 3D — kształt jest płaski i efekt 3D jest stosowany wyłącznie do tekstu. 

Opisy te są powiązane z metodami ThreeDFormat.getLightRig() i ThreeDFormat.getCamera(). 

{{% /alert %}} 

## **Zastosowanie efektu OuterShadow do tekstów**

Aspose.Slides dla Node.js via Java udostępnia klasy [**OuterShadow**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/outershadow/) i [**InnerShadow**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/innershadow/), które pozwalają zastosować efekty cienia do tekstu zawartego w [TextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/). Przejdź przez następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation).
2. Uzyskaj odniesienie do slajdu, używając jego indeksu.
3. Dodaj AutoShape typu Rectangle do slajdu.
4. Uzyskaj dostęp do TextFrame powiązanego z AutoShape.
5. Ustaw właściwość FillType AutoShape na NoFill.
6. Utwórz instancję klasy OuterShadow.
7. Ustaw BlurRadius cienia.
8. Ustaw Direction cienia.
9. Ustaw Distance cienia.
10. Ustaw RectanglelAlign na TopLeft.
11. Ustaw PresetColor cienia na Black.
12. Zapisz prezentację jako plik [PPTX](https://docs.fileformat.com/presentation/pptx/) .

Ten przykładowy kod w języku Java — implementacja powyższych kroków — pokazuje, jak zastosować efekt OuterShadow do tekstu:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Pobierz odniesienie do slajdu
    var sld = pres.getSlides().get_Item(0);
    // Dodaj AutoShape typu Rectangle
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // Dodaj TextFrame do prostokąta
    ashp.addTextFrame("Aspose TextBox");
    // Wyłącz wypełnienie kształtu, jeśli chcemy uzyskać cień tekstu
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Dodaj zewnętrzny cień i ustaw wszystkie niezbędne parametry
    ashp.getEffectFormat().enableOuterShadowEffect();
    var shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(aspose.slides.RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(aspose.slides.PresetColor.Black);
    // Zapisz prezentację na dysku
    pres.save("pres_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Zastosowanie efektu InnerShadow do kształtów**

Przejdź przez następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation).
2. Uzyskaj odniesienie do slajdu.
3. Dodaj AutoShape typu Rectangle.
4. Włącz InnerShadowEffect.
5. Ustaw wszystkie niezbędne parametry.
6. Ustaw ColorType na Scheme.
7. Ustaw Scheme Color.
8. Zapisz prezentację jako plik [PPTX](https://docs.fileformat.com/presentation/pptx/) .

Ten przykładowy kod (oparty na powyższych krokach) pokazuje, jak dodać łącznik między dwoma kształtami w JavaScript:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Pobierz odniesienie do slajdu
    var slide = pres.getSlides().get_Item(0);
    // Dodaj AutoShape typu Rectangle
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Dodaj TextFrame do prostokąta
    ashp.addTextFrame("Aspose TextBox");
    var port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    var pf = port.getPortionFormat();
    pf.setFontHeight(50);
    // Włącz efekt wewnętrznego cienia
    var ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();
    // Ustaw wszystkie niezbędne parametry
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB(189);
    // Ustaw ColorType jako Scheme
    ef.getInnerShadowEffect().getShadowColor().setColorType(aspose.slides.ColorType.Scheme);
    // Ustaw Scheme Color
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(aspose.slides.SchemeColor.Accent1);
    // Zapisz prezentację
    pres.save("WordArt_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Czy mogę używać efektów WordArt z różnymi czcionkami lub skryptami (np. arabski, chiński)?**

Tak, Aspose.Slides obsługuje Unicode i współpracuje ze wszystkimi popularnymi czcionkami i skryptami. Efekty WordArt, takie jak cień, wypełnienie i obramowanie, mogą być stosowane niezależnie od języka, choć dostępność czcionek i renderowanie mogą zależeć od czcionek zainstalowanych w systemie.

**Czy mogę stosować efekty WordArt do elementów mastera slajdów?**

Tak, możesz stosować efekty WordArt do kształtów na slajdach master, w tym do pól tytułu, stopek lub tekstu tła. Zmiany wprowadzone w układzie mastera zostaną odzwierciedlone we wszystkich powiązanych slajdach.

**Czy efekty WordArt wpływają na rozmiar pliku prezentacji?**

Nieznacznie. Efekty WordArt, takie jak cienie, poświaty i wypełnienia gradientowe, mogą nieco zwiększyć rozmiar pliku ze względu na dodatkowe metadane formatowania, ale różnica jest zazwyczaj pomijalna.

**Czy mogę podglądać wynik efektów WordArt bez zapisywania prezentacji?**

Tak, możesz renderować slajdy zawierające WordArt do obrazów (np. PNG, JPEG) przy użyciu metody `getImage` z klas [Shape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/) lub [Slide](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slide/). Pozwala to na podgląd wyniku w pamięci lub na ekranie przed zapisaniem lub wyeksportowaniem całej prezentacji.