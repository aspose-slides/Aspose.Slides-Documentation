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
description: "Przekształć swoje pliki PPT i PPTX za pomocą zaawansowanych efektów kształtów przy użyciu Aspose.Slides dla Javy — twórz efektowne, profesjonalne slajdy w kilka sekund."
---
## **Wprowadzenie**

Podczas gdy efekty w PowerPoint mogą być używane, aby wyróżnić kształt, różnią się od [wypełnień](/slides/pl/java/shape-formatting/#gradient-fill) lub konturów. Korzystając z efektów PowerPoint, możesz tworzyć przekonujące odbicia na kształcie, rozprzestrzeniać poświatę kształtu itp.

![Efekt kształtu](shape-effect.png)

PowerPoint udostępnia sześć efektów, które można zastosować do kształtów. Możesz zastosować jeden lub więcej efektów do kształtu.

Niektóre kombinacje efektów wyglądają lepiej niż inne. Z tego powodu PowerPoint oferuje opcje w sekcji **Preset**. Opcje Preset to kombinacje dwóch lub więcej efektów, które są uznane za estetyczne. Dzięki temu, wybierając preset, nie musisz tracić czasu na testowanie lub łączenie różnych efektów w poszukiwaniu ładnej kombinacji.

Aspose.Slides udostępnia własności i metody w klasie [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/), które pozwalają zastosować te same efekty do kształtów w prezentacjach PowerPoint.

## **Zastosowanie efektu cienia**

Aspose.Slides for Java obsługuje cienie zewnętrzne i wewnętrzne dla kształtów. Możesz dostosować ich kolor, kierunek, odległość i promień rozmycia, aby pasowały do projektu Twojej prezentacji.

### **Zastosowanie cienia zewnętrznego**

Użyj cienia zewnętrznego, aby karta lub panel wyróżniały się na tle tła slajdu. Cień rozciąga się poza krawędzie kształtu, tworząc wrażenie, że kształt jest podniesiony nad slajd. Dostosuj jego kolor, kierunek, odległość i promień rozmycia, aby pasowały do oświetlenia i stylu Twojego szablonu.

This Java code shows how to apply the [efekt cienia zewnętrznego](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getOuterShadowEffect--) to a rectangle:

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

### **Zastosowanie cienia wewnętrznego**

Podczas odtwarzania wizualnego stylu szablonu, użyj cienia wewnętrznego, aby nadać karcie lub panelowi wklęsły wygląd. Cień zewnętrzny rozciąga się poza kształt i sprawia, że wygląda on na podniesiony, podczas gdy cień wewnętrzny przyciemnia wnętrze jego krawędzi.

Wywołaj [enableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#enableInnerShadowEffect--), a następnie skonfiguruj cień zwrócony przez [getInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getInnerShadowEffect--). Większe wartości promienia rozmycia dają miększe krawędzie.

Ten przykład w Javie tworzy jasnoniebieską kartę z ciemnoszarym cieniem wewnętrznym i zapisuje ją jako plik PPTX. Kierunek cienia wynosi 225 stopni, jego odległość to 7 punktów, a promień rozmycia to 6 punktów:

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

## **Zastosowanie efektu odbicia**

Aby zastosować efekt odbicia w Aspose.Slides for Java, możesz dodać lustrzane odbicie do kształtów, regulując parametry takie jak odległość, przezroczystość i rozmiar. Ten efekt podnosi estetykę Twoich prezentacji, nadając kształtom bardziej wyrafinowany i dopracowany wygląd. Jest łatwy do wdrożenia przy użyciu prostego kodu, umożliwiając szybkie zastosowanie na wielu elementach w celu uzyskania spójnego projektu.

This Java code shows how to apply the [efekt odbicia](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getReflectionEffect--) to a shape:

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

Aby zastosować efekt poświaty do kształtu w Aspose.Slides for Java, możesz dodać miękką, świetlistą aurę wokół kształtów, regulując właściwości takie jak kolor i rozmiar. Ten efekt pomaga wyróżnić kształty i dodaje atrakcyjny, przyciągający uwagę element wizualny do Twojej prezentacji. Jest łatwy do wdrożenia przy minimalnym kodzie, podnosząc ogólny wygląd Twoich slajdów.

This Java code shows how to apply the [efekt poświaty](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getGlowEffect--) to a shape:

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

Aby zastosować efekt miękkich krawędzi w Aspose.Slides for Java, możesz stworzyć płynne, rozmyte przejście wokół krawędzi kształtu. Ten efekt dodaje subtelniejszy i bardziej wyrafinowany wygląd, idealny dla projektów wymagających delikatnego, łagodniejszego wyglądu. Możesz łatwo dostosować parametry, takie jak promień, aby osiągnąć pożądany efekt na różnych kształtach w swojej prezentacji.

This Java code shows how to apply the [efekt miękkich krawędzi](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getSoftEdgeEffect--) to a shape:

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

## **FAQ**

**Czy mogę zastosować wiele efektów do tego samego kształtu?**

Tak, możesz łączyć różne efekty, takie jak cień, odbicie i poświata, na jednym kształcie, aby uzyskać bardziej dynamiczny wygląd.

**Do jakich kształtów mogę zastosować efekty?**

Możesz zastosować efekty do różnych kształtów, w tym autokształtów, wykresów, tabel, obrazów, obiektów SmartArt, obiektów OLE i innych.

**Czy mogę zastosować efekty do grupowanych kształtów?**

Tak, możesz zastosować efekty do grupowanych kształtów. Efekt zostanie zastosowany do całej grupy.