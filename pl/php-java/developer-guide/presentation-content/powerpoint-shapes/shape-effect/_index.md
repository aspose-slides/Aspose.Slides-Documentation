---
title: Zastosuj efekty kształtów w prezentacjach przy użyciu PHP
linktitle: Efekt kształtu
type: docs
weight: 30
url: /pl/php-java/shape-effect/
keywords:
- efekt kształtu
- efekt cienia
- efekt odbicia
- efekt poświaty
- efekt miękkich krawędzi
- format efektu
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Przekształć swoje pliki PPT i PPTX za pomocą zaawansowanych efektów kształtów, korzystając z Aspose.Slides dla PHP przez Java — twórz efektowne, profesjonalne slajdy w kilka sekund."
---
## **Wprowadzenie**

Podczas gdy efekty w PowerPoint można wykorzystać, aby wyróżnić kształt, różnią się one od [wypełnień](/slides/pl/php-java/shape-formatting/#gradient-fill) lub konturów. Korzystając z efektów PowerPoint, możesz tworzyć przekonujące odbicia na kształcie, rozprzestrzeniać poświatę kształtu itp.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint udostępnia sześć efektów, które można zastosować do kształtów. Możesz zastosować jeden lub więcej efektów do kształtu. 

* Niektóre kombinacje efektów wyglądają lepiej niż inne. Z tego powodu opcje PowerPoint znajdują się pod **Preset**. Opcje Preset to w zasadzie znana, dobrze wyglądająca kombinacja dwóch lub więcej efektów. Dzięki wyborowi presetu nie musisz tracić czasu na testowanie lub łączenie różnych efektów, aby znaleźć dobrą kombinację.

Aspose.Slides udostępnia właściwości i metody w klasie [EffectFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/EffectFormat), które pozwalają zastosować te same efekty do kształtów w prezentacjach PowerPoint.

## **Zastosowanie efektu cienia**

Ten kod PHP pokazuje, jak zastosować efekt zewnętrznego cienia ([OuterShadowEffect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/EffectFormat#setOuterShadowEffect--)) do prostokąta:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableOuterShadowEffect();
    $shape->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor(java("java.awt.Color")->DARK_GRAY);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDistance(10);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDirection(45);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Zastosowanie efektu odbicia**

Ten kod PHP pokazuje, jak zastosować efekt odbicia do kształtu:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableReflectionEffect();
    $shape->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment->Bottom);
    $shape->getEffectFormat()->getReflectionEffect()->setDirection(90);
    $shape->getEffectFormat()->getReflectionEffect()->setDistance(55);
    $shape->getEffectFormat()->getReflectionEffect()->setBlurRadius(4);
    $pres->save("reflection.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Zastosowanie efektu poświaty**

Ten kod PHP pokazuje, jak zastosować efekt poświaty do kształtu:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableGlowEffect();
    $shape->getEffectFormat()->getGlowEffect()->getColor()->setColor(java("java.awt.Color")->MAGENTA);
    $shape->getEffectFormat()->getGlowEffect()->setRadius(15);
    $pres->save("glow.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Zastosowanie efektu miękkich krawędzi**

Ten kod PHP pokazuje, jak zastosować miękkie krawędzie do kształtu:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableSoftEdgeEffect();
    $shape->getEffectFormat()->getSoftEdgeEffect()->setRadius(15);
    $pres->save("softEdges.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Czy mogę zastosować wiele efektów do tego samego kształtu?**

Tak, możesz łączyć różne efekty, takie jak cień, odbicie i poświata, na jednym kształcie, aby uzyskać bardziej dynamiczny wygląd.

**Do jakich kształtów mogę zastosować efekty?**

Możesz stosować efekty do różnych kształtów, w tym autokształtów, wykresów, tabel, obrazów, obiektów SmartArt, obiektów OLE i innych.

**Czy mogę zastosować efekty do grupowanych kształtów?**

Tak, możesz stosować efekty do grupowanych kształtów. Efekt zostanie zastosowany do całej grupy.