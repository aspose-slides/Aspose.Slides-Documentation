---
title: Zastosowanie efektów kształtów w prezentacjach przy użyciu JavaScript
linktitle: Efekt kształtu
type: docs
weight: 30
url: /pl/nodejs-java/shape-effect/
keywords:
- efekt kształtu
- efekt cienia
- efekt odbicia
- efekt poświaty
- efekt miękkich krawędzi
- format efektu
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Przekształć swoje pliki PPT i PPTX za pomocą zaawansowanych efektów kształtów, używając JavaScript i Aspose.Slides dla Node.js — twórz efektowne, profesjonalne slajdy w kilka sekund."
---
## **Wprowadzenie**

Podczas gdy efekty w PowerPoint można wykorzystać, aby wyróżnić kształt, różnią się one od [wypełnień](/slides/pl/nodejs-java/shape-formatting/#gradient-fill) lub konturów. Korzystając z efektów PowerPoint, można stworzyć przekonujące odbicia kształtu, rozproszyć poświatę kształtu itp.

<img src="shape-effect.png" alt="efekt-kształtu" style="zoom:50%;" />

* PowerPoint udostępnia sześć efektów, które można zastosować do kształtów. Można zastosować jeden lub więcej efektów do jednego kształtu.  

* Niektóre kombinacje efektów wyglądają lepiej niż inne. Z tego powodu opcje PowerPoint znajdują się w sekcji **Preset**. Opcje Preset to w zasadzie sprawdzona, atrakcyjna kombinacja dwóch lub więcej efektów. Dzięki temu, wybierając gotowy preset, nie musisz tracić czasu na testowanie lub łączenie różnych efektów w poszukiwaniu udanej kombinacji.

Aspose.Slides udostępnia właściwości i metody w klasie [EffectFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/EffectFormat), które pozwalają zastosować te same efekty do kształtów w prezentacjach PowerPoint.

## **Zastosowanie efektu cienia**

Ten kod JavaScript pokazuje, jak zastosować efekt zewnętrznego cienia ([getOuterShadowEffect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/EffectFormat#getOuterShadowEffect)) do prostokąta:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(java.getStaticFieldValue("java.awt.Color", "DARK_GRAY"));
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Zastosowanie efektu odbicia**

Ten kod JavaScript pokazuje, jak zastosować efekt odbicia do kształtu:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(aspose.slides.RectangleAlignment.Bottom);
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(55);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(4);
    pres.save("reflection.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Zastosowanie efektu poświaty**

Ten kod JavaScript pokazuje, jak zastosować efekt poświaty do kształtu:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableGlowEffect();
    shape.getEffectFormat().getGlowEffect().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
    shape.getEffectFormat().getGlowEffect().setRadius(15);
    pres.save("glow.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Zastosowanie efektu miękkich krawędzi**

Ten kod JavaScript pokazuje, jak zastosować miękkie krawędzie do kształtu:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(15);
    pres.save("softEdges.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Czy mogę zastosować wiele efektów do tego samego kształtu?**

Tak, możesz łączyć różne efekty, takie jak cień, odbicie i poświata, na jednym kształcie, aby stworzyć bardziej dynamiczny wygląd.

**Do jakich kształtów mogę stosować efekty?**

Efekty można stosować do różnych kształtów, w tym do autokształtów, wykresów, tabel, obrazów, obiektów SmartArt, obiektów OLE i innych.

**Czy mogę stosować efekty do grupowanych kształtów?**

Tak, możesz stosować efekty do grupowanych kształtów. Efekt zostanie zastosowany do całej grupy.