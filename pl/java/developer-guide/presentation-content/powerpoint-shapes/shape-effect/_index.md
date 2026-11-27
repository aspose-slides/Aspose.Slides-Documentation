---
title: Zastosowanie efektów kształtów w prezentacjach przy użyciu Javy
linktitle: Efekt kształtu
type: docs
weight: 30
url: /pl/java/shape-effect/
keywords:
- efekt kształtu
- efekt cienia
- efekt odbicia
- efekt poświaty
- efekt miękkich krawędzi
- format efektu
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Transformuj swoje pliki PPT i PPTX za pomocą zaawansowanych efektów kształtów wykorzystując Aspose.Slides for Java — twórz efektowne, profesjonalne slajdy w kilka sekund."
---
## **Wprowadzenie**

Podczas gdy efekty w PowerPoint mogą być używane, aby wyróżnić kształt, różnią się od [wypełnień](/slides/pl/java/shape-formatting/#gradient-fill) lub konturów. Używając efektów PowerPoint, można tworzyć przekonujące odbicia na kształcie, rozprzestrzeniać poświatę kształtu itp.

![Efekt kształtu](shape-effect.png)

PowerPoint udostępnia sześć efektów, które można zastosować do kształtów. Można zastosować jeden lub więcej efektów do kształtu.

Niektóre kombinacje efektów wyglądają lepiej niż inne. Z tego powodu PowerPoint udostępnia opcje w sekcji **Preset**. Opcje Preset są kombinacjami dwóch lub więcej efektów, które są uznane za atrakcyjne. W ten sposób, wybierając preset, nie musisz marnować czasu na testowanie lub łączenie różnych efektów w celu znalezienia dobrej kombinacji.

Aspose.Slides udostępnia właściwości i metody w klasie [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/), które pozwalają zastosować te same efekty do kształtów w prezentacjach PowerPoint.

## **Zastosowanie efektu cienia**

Aspose.Slides for Java obsługuje cienie zewnętrzne i wewnętrzne dla kształtów. Możesz dostosować ich kolor, kierunek, odległość i promień rozmycia, aby pasowały do projektu prezentacji.

### **Zastosowanie cienia zewnętrznego**

Użyj cienia zewnętrznego, aby karta lub panel wyróżniały się na tle slajdu. Cień wykracza poza krawędzie kształtu, tworząc wrażenie, że kształt jest unoszony nad slajdem. Dostosuj jego kolor, kierunek, odległość i promień rozmycia, aby pasowały do oświetlenia i stylu szablonu.

Ten kod Java pokazuje, jak zastosować [outer shadow effect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getOuterShadowEffect--) do prostokąta:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(new Color(169, 169, 169));
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Efekt cienia](shadow_effect.png)

#### **Kontrolowanie kierunku cienia przy obrocie kształtu**

Domyślnie cień zewnętrzny obraca się razem z kształtem. Aby kształty o różnych obrotach były oświetlone z tego samego kierunku, wywołaj [setRotateShadowWithShape](https://reference.aspose.com/slides/java/com.aspose.slides/ioutershadow/#setRotateShadowWithShape-boolean-) z wartością `false` i użyj [setDirection](https://reference.aspose.com/slides/java/com.aspose.slides/ioutershadow/#setDirection-float-) aby nadać ich cieniom ten sam kierunek.

Przykład tworzy dwie niebieskie strzałki z szarymi cieniami odsuniętymi o 42 punkty w prawo (0°). Następnie duplikuje slajd i obraca obie strzałki o 90° zgodnie z ruchem wskazówek zegara.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide before = presentation.getSlides().get_Item(0);

    IAutoShape left = before.getShapes().addAutoShape(ShapeType.RightArrow, 55, 130, 110, 60);
    left.getFillFormat().setFillType(FillType.Solid);
    left.getFillFormat().getSolidFillColor().setColor(new Color(70, 130, 180));
    left.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    left.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = left.getEffectFormat().getOuterShadowEffect();
    shadow.getShadowColor().setColor(Color.GRAY);
    shadow.setDirection(0);
    shadow.setDistance(42);
    shadow.setBlurRadius(0);
    shadow.setRotateShadowWithShape(true);

    IShape right = before.getShapes().addClone(left);
    right.setX(395);
    right.getEffectFormat().getOuterShadowEffect().setRotateShadowWithShape(false);

    ISlide after = presentation.getSlides().addClone(before);
    for (IShape arrow : after.getShapes()) {
        arrow.setRotation(90);
    }

    presentation.save("arrow_shadows.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Na drugim slajdzie lewa strzałka rzuca cień w dół, podczas gdy prawy cień nadal skierowany jest w prawo. Skonfigurowany kierunek pozostaje 0° dla obu cieni.

![Renderowanie PowerPoint przed i po obrocie o 90°. Oba cienie początkowo znajdują się po prawej stronie. Po obrocie cień przemieszcza się pod lewą strzałkę i pozostaje po prawej stronie prawej strzałki.](arrow-shadow-rotation.png)

### **Zastosowanie cienia wewnętrznego**

Podczas odtwarzania stylu wizualnego szablonu użyj cienia wewnętrznego, aby nadać karcie lub panelowi wklęsły wygląd. Cień zewnętrzny rozciąga się poza kształt i sprawia, że wydaje się podniesiony, podczas gdy cień wewnętrzny zacienia wewnętrzne krawędzie.

Wywołaj [enableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#enableInnerShadowEffect--), a następnie skonfiguruj cień zwrócony przez [getInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getInnerShadowEffect--). Większe wartości promienia rozmycia dają łagodniejsze krawędzie.

Ten przykład Java tworzy jasnoniebieską kartę z ciemnoszarym cieniem wewnętrznym i zapisuje ją jako plik PPTX. Kierunek cienia wynosi 225 stopni, odległość 7 punktów, a promień rozmycia 6 punktów:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(173, 216, 230));
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    shape.getEffectFormat().enableInnerShadowEffect();
    IInnerShadow shadow = shape.getEffectFormat().getInnerShadowEffect();
    shadow.getShadowColor().setColor(new Color(105, 105, 105));
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Jasnoniebieski prostokąt z cieniem wewnętrznym](inner_shadow_effect.png)

Aby usunąć cień wewnętrzny, wywołaj [disableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#disableInnerShadowEffect--) na formacie efektu kształtu.

### **Zastosowanie, zmiana i usunięcie cienia Preset**

Wywołaj [enablePresetShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#enablePresetShadowEffect--) i użyj [setPreset](https://reference.aspose.com/slides/java/com.aspose.slides/ipresetshadow/#setPreset-int-), aby wybrać [PresetShadowType](https://reference.aspose.com/slides/java/com.aspose.slides/presetshadowtype/). Aby przełączyć style, zmień preset na tym samym kształcie. Wywołaj [disablePresetShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disablePresetShadowEffect--) aby usunąć cień, zachowując wypełnienie i kontur.

Ten przykład pokazuje cztery etapy obok siebie na jednym slajdzie. Oba cienie są odsunięte o 10 punktów. Kierunek 225° umieszcza pierwszy cień powyżej i po lewej stronie prostokąta, a 45° umieszcza drugi cień poniżej i po prawej stronie.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(800, 120, SlideSizeScaleType.DoNotScale);
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IAutoShape shape = shapes.addAutoShape(ShapeType.Rectangle, 15, 30, 170, 60);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(70, 130, 180));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
    shape.getTextFrame().setText("No shadow");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shape.getEffectFormat().enablePresetShadowEffect();
    IPresetShadow shadow = shape.getEffectFormat().getPresetShadowEffect();
    shadow.setPreset(PresetShadowType.TopLeftDropShadow);
    shadow.setDistance(10);
    shadow.setDirection(225);
    shape.getTextFrame().setText("TopLeftDropShadow");
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shadow.setPreset(PresetShadowType.BottomRightDropShadow);
    shadow.setDirection(45);
    shape.getTextFrame().setText("BottomRightDropShadow");
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shape.getEffectFormat().disablePresetShadowEffect();
    shape.getTextFrame().setText("No shadow");

    presentation.save("preset_shadows.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Oryginalny | Pierwszy preset | Drugi preset | Po usunięciu |
| :---: | :---: | :---: | :---: |
| ![No shadow](preset_shadow_original.png) | ![TopLeftDropShadow](preset_shadow_top_left.png) | ![BottomRightDropShadow](preset_shadow_bottom_right.png) | ![No shadow after removal](preset_shadow_removed.png) |

## **Zastosowanie efektu odbicia**

Aby zastosować efekt odbicia w Aspose.Slides for Java, możesz dodać lustrzane odbicie do kształtów, regulując parametry takie jak odległość, przezroczystość i rozmiar. Efekt ten podnosi estetykę prezentacji, nadając kształtom bardziej wypolerowany i wyrafinowany wygląd. Łatwo go zaimplementować przy użyciu prostego kodu, co umożliwia szybkie zastosowanie go w wielu elementach dla spójnego projektu.

Ten kod Java pokazuje, jak zastosować [reflection effect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getReflectionEffect--) do kształtu:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom);
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(40);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2);

    presentation.save("reflection_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Efekt odbicia](reflection_effect.png)

## **Zastosowanie efektu poświaty**

Aby zastosować efekt poświaty do kształtu w Aspose.Slides for Java, możesz dodać miękką, świetlistą aurę wokół kształtów, regulując właściwości takie jak kolor i rozmiar. Efekt ten pomaga wyróżnić kształty i dodaje atrakcyjny, przyciągający wzrok element wizualny do Twojej prezentacji. Jest łatwy do wdrożenia przy minimalnym kodzie, podnosząc ogólny wygląd slajdów.

Ten kod Java pokazuje, jak zastosować [glow effect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getGlowEffect--) do kształtu:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableGlowEffect();
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    presentation.save("glow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Efekt poświaty](glow_effect.png)

## **Zastosowanie efektu miękkich krawędzi**

Aby zastosować efekt miękkich krawędzi w Aspose.Slides for Java, możesz stworzyć płynne, rozmyte przejście wokół brzegów kształtu. Efekt ten dodaje subtelniejszy i bardziej wyrafinowany wygląd, idealny dla projektów wymagających delikatnego, łagodniejszego wyglądu. Łatwo możesz regulować parametry, takie jak promień, aby uzyskać pożądany efekt w różnych kształtach prezentacji.

Ten kod Java pokazuje, jak zastosować [soft edges effect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getSoftEdgeEffect--) do kształtu:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8);

    presentation.save("soft_edges_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Efekt miękkich krawędzi](soft_edges_effect.png)

## **Zastosowanie efektu rozmycia**

Użyj rozmycia kształtu, aby zmiękczyć wypełnienie i kontur, zachowując możliwość edycji kształtu. Wywołaj [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) na formacie efektu kształtu. Promień jest mierzony w punktach (1/72 cala): użyj wartości nieujemnej, przy czym większe wartości dają silniejsze rozmycie. Promień równy zero pozostawia wygląd niezmieniony.

Ustawienie [getGrow](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/#getGrow--) kontroluje widoczne granice efektu. Przy `false` rozmycie jest przycięte do oryginalnych granic malowanych, w tym konturu. Przy `true` rozmycie może wykraczać poza te granice. Żadne z ustawień nie zmienia położenia ani wymiarów kształtu.

Poniższe porównanie używa tego samego wypełnienia, konturu i wymiarów kształtu w całej prezentacji. Górny wiersz używa `grow = false`; dolny wiersz używa `grow = true`.

![Oryginalny prostokąt porównany z promieniami rozmycia 5 i 15 punktów, z wyłączonym i włączonym grow](shape_blur_comparison.png)

Ten przykład Java tworzy pomarańczowy prostokąt z ciemnoniebieskim konturem, stosuje rozmycie o promieniu 5 punktów, a następnie aktualizuje je do 15 punktów, ponownie wywołując [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-). Zapisuje oba stany rozmyte, potem wywołuje [disableBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disableBlurEffect--) i zapisuje kształt bez rozmycia.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
    shape.getLineFormat().setWidth(8);

    shape.getEffectFormat().setBlurEffect(5, false);
    presentation.save("shape_blur_5.pptx", SaveFormat.Pptx);

    shape.getEffectFormat().setBlurEffect(15, true);
    presentation.save("shape_blur_15.pptx", SaveFormat.Pptx);

    shape.getEffectFormat().disableBlurEffect();
    presentation.save("shape_blur_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Rozmycie kształtu wpływa jednocześnie na wypełnienie i kontur. Efekt miękkich krawędzi rozmywa krawędzie całego kształtu, podczas gdy rozmycie cienia zmiękcza tylko cień. Efekty transformacji obrazu działają na zawartość obrazu; ten przykład stosuje rozmycie bezpośrednio do formatu efektu kształtu, bez konwersji kształtu na obraz.

## **FAQ**

**Czy mogę zastosować wiele efektów do tego samego kształtu?**

Tak, możesz łączyć różne efekty, takie jak cień, odbicie i poświata, na jednym kształcie, aby uzyskać bardziej dynamiczny wygląd.

**Do jakich kształtów mogę zastosować efekty?**

Możesz stosować efekty do różnych kształtów, w tym autokształtów, wykresów, tabel, obrazów, obiektów SmartArt, obiektów OLE i innych.

**Czy mogę zastosować efekty do grupowanych kształtów?**

Tak, możesz zastosować efekty do grupowanych kształtów. Efekt zostanie zastosowany do całej grupy.