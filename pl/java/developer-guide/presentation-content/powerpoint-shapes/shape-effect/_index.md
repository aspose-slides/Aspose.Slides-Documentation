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
description: "Przekształć swoje pliki PPT i PPTX dzięki zaawansowanym efektom kształtów przy użyciu Aspose.Slides dla Javy — twórz efektowne, profesjonalne slajdy w kilka sekund."
---
## **Wprowadzenie**

Podczas gdy efekty w PowerPoint mogą być używane, aby wyróżnić kształt, różnią się od [wypełnień](/slides/pl/java/shape-formatting/#gradient-fill) lub konturów. Korzystając z efektów PowerPoint, możesz tworzyć przekonujące odbicia na kształcie, rozpraszać poświatę kształtu itp.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint oferuje sześć efektów, które można zastosować do kształtów. Możesz zastosować jeden lub więcej efektów do kształtu. 

* Niektóre kombinacje efektów wyglądają lepiej niż inne. Z tego powodu w PowerPoint dostępne są opcje **Preset**. Opcje Preset to w zasadzie znane, dobrze wyglądające kombinacje dwóch lub więcej efektów. Dzięki wyborowi presetu nie musisz tracić czasu na testowanie lub łączenie różnych efektów, aby znaleźć dobrą kombinację.

Aspose.Slides udostępnia właściwości i metody w klasie [EffectFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/EffectFormat), które pozwalają stosować te same efekty do kształtów w prezentacjach PowerPoint.

## **Zastosuj efekt cienia**

Ten kod Java pokazuje, jak zastosować efekt zewnętrznego cienia ([OuterShadowEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/EffectFormat#setOuterShadowEffect--)) do prostokąta:

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.DARK_GRAY);
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zastosuj efekt odbicia**

Ten kod Java pokazuje, jak zastosować efekt odbicia do kształtu:

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom);
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(55);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(4);

    pres.save("reflection.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zastosuj efekt poświaty**

Ten kod Java pokazuje, jak zastosować efekt poświaty do kształtu:

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableGlowEffect();
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    pres.save("glow.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zastosuj efekt miękkich krawędzi**

Ten kod Java pokazuje, jak zastosować miękkie krawędzie do kształtu:

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(15);

    pres.save("softEdges.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Czy mogę zastosować wiele efektów do tego samego kształtu?**

Tak, możesz łączyć różne efekty, takie jak cień, odbicie i poświata, na jednym kształcie, aby uzyskać bardziej dynamiczny wygląd.

**Na jakie kształty mogę zastosować efekty?**

Możesz stosować efekty do różnych kształtów, w tym autokształtów, wykresów, tabel, obrazów, obiektów SmartArt, obiektów OLE i innych.

**Czy mogę zastosować efekty do grupowanych kształtów?**

Tak, możesz zastosować efekty do grupowanych kształtów. Efekt zostanie zastosowany do całej grupy.