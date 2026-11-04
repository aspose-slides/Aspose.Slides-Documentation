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
description: "Przekształć swoje pliki PPT i PPTX za pomocą zaawansowanych efektów kształtów przy użyciu Aspose.Slides dla Javy - twórz efektowne, profesjonalne slajdy w kilka sekund."
---
## **Wprowadzenie**

Podczas gdy efekty w PowerPoint mogą być używane, aby wyróżnić kształt, różnią się od [wypełnień](/slides/pl/java/shape-formatting/#gradient-fill) lub obrysów. Korzystając z efektów PowerPoint, możesz tworzyć przekonujące odbicia na kształcie, rozpraszać poświatę kształtu itp.

![Efekt kształtu](shape-effect.png)

PowerPoint udostępnia sześć efektów, które można zastosować do kształtów. Możesz zastosować jeden lub więcej efektów do kształtu.

Niektóre kombinacje efektów wyglądają lepiej niż inne. Z tego powodu PowerPoint oferuje opcje w sekcji **Preset**. Opcje Preset to kombinacje dwóch lub więcej efektów, które są znane jako dobrze wyglądające. W ten sposób, wybierając preset, nie będziesz musiał tracić czasu na testowanie lub łączenie różnych efektów w celu znalezienia odpowiedniej kombinacji.

Aspose.Slides udostępnia właściwości i metody w klasie [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/) , które pozwalają zastosować te same efekty do kształtów w prezentacjach PowerPoint.

## **Zastosowanie efektu cienia**

Aspose.Slides dla Javy obsługuje zewnętrzne i wewnętrzne cienie dla kształtów. Możesz dostosować ich kolor, kierunek, odległość i promień rozmycia, aby pasowały do projektu prezentacji.

### **Zastosowanie zewnętrznego cienia**

Użyj zewnętrznego cienia, aby karta lub panel wyróżniały się na tle slajdu. Cień rozciąga się poza krawędzie kształtu, tworząc wrażenie, że kształt jest uniesiony nad slajdem. Dostosuj jego kolor, kierunek, odległość i promień rozmycia, aby pasowały do oświetlenia i stylu szablonu.

Ten kod Java pokazuje, jak zastosować [efekt zewnętrznego cienia](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getOuterShadowEffect--) do prostokąta:

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

### **Zastosowanie wewnętrznego cienia**

Podczas odtwarzania wizualnego stylu szablonu użyj wewnętrznego cienia, aby nadać karcie lub panelowi wklęsły wygląd. Zewnętrzny cień rozciąga się poza kształt i sprawia, że wygląda na podniesiony, natomiast wewnętrzny cień przyciemnia wnętrze jego krawędzi.

Wywołaj [enableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#enableInnerShadowEffect--), a następnie skonfiguruj cień zwrócony przez [getInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getInnerShadowEffect--). Większe wartości promienia rozmycia powodują łagodniejsze krawędzie.

Ten przykład Java tworzy jasnoniebieską kartę z ciemnoszarym wewnętrznym cieniem i zapisuje ją jako plik PPTX. Kierunek cienia wynosi 225 stopni, jego odległość to 7 punktów, a promień rozmycia to 6 punktów:

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

![Jasnoniebieski prostokąt z wewnętrznym cieniem](inner_shadow_effect.png)

Aby usunąć wewnętrzny cień, wywołaj [disableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#disableInnerShadowEffect--) na formacie efektu kształtu.

## **Zastosowanie efektu odbicia**

Aby zastosować efekt odbicia w Aspose.Slides dla Javy, możesz dodać lustrzane odbicie do kształtów, dostosowując parametry takie jak odległość, przezroczystość i rozmiar. Ten efekt poprawia estetykę prezentacji, nadając kształtom bardziej wyrafinowany i dopracowany wygląd. Jest łatwy do wdrożenia przy użyciu prostego kodu, umożliwiając szybkie zastosowanie na wielu elementach w celu uzyskania spójnego projektu.

Ten kod Java pokazuje, jak zastosować [efekt odbicia](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getReflectionEffect--) do kształtu:

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

Aby zastosować efekt poświaty do kształtu w Aspose.Slides dla Javy, możesz dodać miękką, świetlistą aurę wokół kształtów, dostosowując właściwości takie jak kolor i rozmiar. Ten efekt pomaga wyróżnić kształty i dodaje atrakcyjny, przyciągający wzrok element wizualny do prezentacji. Jest łatwy do wdrożenia przy minimalnym kodzie, poprawiając ogólny wygląd slajdów.

Ten kod Java pokazuje, jak zastosować [efekt poświaty](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getGlowEffect--) do kształtu:

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

Aby zastosować efekt miękkich krawędzi w Aspose.Slides dla Javy, możesz stworzyć płynne, rozmyte przejście wokół krawędzi kształtu. Ten efekt dodaje subtelniejszy i bardziej wyrafinowany wygląd, idealny dla projektów wymagających delikatnego, łagodnego wyglądu. Możesz łatwo dostosować parametry takie jak promień, aby uzyskać pożądany efekt na różnych kształtach w prezentacji.

Ten kod Java pokazuje, jak zastosować [efekt miękkich krawędzi](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getSoftEdgeEffect--) do kształtu:

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

Użyj rozmycia kształtu, aby zmiękczyć wypełnienie i obrys kształtu, zachowując jednocześnie możliwość edycji. Wywołaj [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) na formacie efektu kształtu. Promień jest mierzony w punktach (1/72 cala): użyj wartości nieujemnej, przy czym większe wartości powodują silniejsze rozmycie. Promień równy zero pozostawia wygląd niezmieniony.

Ustawienie [getGrow](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/#getGrow--) kontroluje widoczne granice efektu. Przy `false` rozmycie jest przycięte do oryginalnych pomalowanych granic, włączając obrys. Przy `true` rozmycie może wykraczać poza te granice. Żadne z ustawień nie zmienia pozycji ani wymiarów kształtu.

Poniższe porównanie używa tego samego wypełnienia, obrysu i wymiarów kształtu w całym przykładzie. Górny wiersz używa `grow = false`; dolny wiersz używa `grow = true`.

![Oryginalny prostokąt porównany z promieniami rozmycia 5 i 15 punktów, przy wyłączonym i włączonym grow](shape_blur_comparison.png)

Ten przykład Java tworzy pomarańczowy prostokąt z ciemnoniebieskim obrysem, nakłada rozmycie o promieniu 5 punktów, a następnie aktualizuje je do rozmycia o promieniu 15 punktów, ponownie wywołując [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-). Zapisuje oba rozmyte stany, a następnie wywołuje [disableBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disableBlurEffect--) i zapisuje kształt bez rozmycia.

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

Rozmycie kształtu wpływa jednocześnie na wypełnienie i obrys. Efekt miękkich krawędzi przyciemnia krawędzie kształtu, podczas gdy rozmycie cienia zmiękcza tylko cień. Efekty transformacji obrazu działają na zawartość obrazu; ten przykład nakłada rozmycie bezpośrednio na format efektu kształtu, bez konwertowania go na obraz.

## **FAQ**

**Czy mogę zastosować wiele efektów do tego samego kształtu?**

Tak, możesz łączyć różne efekty, takie jak cień, odbicie i poświata, na jednym kształcie, aby uzyskać bardziej dynamiczny wygląd.

**Jakie kształty mogę poddać efektom?**

Możesz stosować efekty do różnych kształtów, w tym autokształtów, wykresów, tabel, obrazów, obiektów SmartArt, obiektów OLE i innych.

**Czy mogę zastosować efekty do grupowanych kształtów?**

Tak, możesz zastosować efekty do grupowanych kształtów. Efekt zostanie zastosowany do całej grupy.