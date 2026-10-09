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
description: "Przekształć swoje pliki PPT i PPTX za pomocą zaawansowanych efektów kształtów przy użyciu Aspose.Slides for PHP via Java — twórz efektowne, profesjonalne slajdy w kilka sekund."
---
## **Wstęp**

Podczas gdy efekty w programie PowerPoint mogą być używane do wyróżniania kształtu, różnią się od [wypełnień](/slides/pl/php-java/shape-formatting/#gradient-fill) lub konturów. Korzystając z efektów PowerPoint, możesz tworzyć przekonujące odbicia na kształcie, rozprzestrzeniać poświatę kształtu itp.

![Efekt kształtu](shape-effect.png)

PowerPoint oferuje sześć efektów, które można zastosować do kształtów. Możesz zastosować jeden lub więcej efektów do kształtu.

Niektóre kombinacje efektów wyglądają lepiej niż inne. Z tego powodu PowerPoint udostępnia opcje w sekcji **Preset**. Opcje Preset to kombinacje dwóch lub więcej efektów, które wiadomo, że wyglądają dobrze. Dzięki temu, wybierając preset, nie będziesz musiał tracić czasu na testowanie lub łączenie różnych efektów w celu znalezienia ładnej kombinacji.

Aspose.Slides udostępnia własności i metody w klasie [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/) pozwalające zastosować te same efekty do kształtów w prezentacjach PowerPoint.

## **Zastosuj efekt cienia**

Aspose.Slides for PHP via Java obsługuje zewnętrzne i wewnętrzne cienie dla kształtów. Możesz dostosować ich kolor, kierunek, odległość i promień rozmycia, aby pasowały do projektu prezentacji.

### **Zastosuj zewnętrzny cień**

Użyj zewnętrznego cienia, aby karta lub panel wyróżniały się na tle tła slajdu. Cień rozciąga się poza krawędzie kształtu, tworząc wrażenie, że kształt jest uniesiony nad slajdem. Dostosuj jego kolor, kierunek, odległość i promień rozmycia, aby pasowały do oświetlenia i stylu szablonu.

Ten kod PHP pokazuje, jak zastosować [zewnętrzny efekt cienia](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getOuterShadowEffect) do prostokąta:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableOuterShadowEffect();
    $shadowColor = new Java("java.awt.Color", 169, 169, 169);
    $shape->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor($shadowColor);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDistance(10);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDirection(45);

    $presentation->save("shadow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Efekt cienia](shadow_effect.png)

### **Zastosuj wewnętrzny cień**

Podczas odtwarzania wizualnego stylu szablonu użyj wewnętrznego cienia, aby nadać karcie lub panelowi wklęsły wygląd. Zewnętrzny cień rozciąga się poza kształt i sprawia, że wydaje się uniesiony, podczas gdy wewnętrzny cień przyciemnia wewnętrzne krawędzie.

Wywołaj [enableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enableInnerShadowEffect), a następnie skonfiguruj cień zwrócony przez [getInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getInnerShadowEffect). Większe wartości promienia rozmycia powodują łagodniejsze krawędzie.

Ten przykład PHP tworzy jasnoniebieską kartę z ciemnoszarym wewnętrznym cieniem i zapisuje ją jako plik PPTX. Kierunek cienia wynosi 225 stopni, odległość to 7 punktów, a promień rozmycia to 6 punktów:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 173, 216, 230);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $shape->getEffectFormat()->enableInnerShadowEffect();
    $shadow = $shape->getEffectFormat()->getInnerShadowEffect();
    $shadowColor = new Java("java.awt.Color", 105, 105, 105);
    $shadow->getShadowColor()->setColor($shadowColor);
    $shadow->setDirection(225);
    $shadow->setDistance(7);
    $shadow->setBlurRadius(6);

    $presentation->save("inner_shadow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Jasnoniebieski prostokąt z wewnętrznym cieniem](inner_shadow_effect.png)

Aby usunąć wewnętrzny cień, wywołaj [disableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableInnerShadowEffect) na formacie efektu kształtu.

## **Zastosuj efekt odbicia**

Aby zastosować efekt odbicia w Aspose.Slides for PHP via Java, możesz dodać lustrzane odbicie do kształtów, dostosowując parametry takie jak odległość, przezroczystość i rozmiar. Efekt ten podnosi estetykę prezentacji, nadając kształtom bardziej dopracowany i wyrafinowany wygląd. Łatwo go zaimplementować przy użyciu prostego kodu, umożliwiając szybkie zastosowanie na wielu elementach w celu uzyskania spójnego projektu.

Ten kod PHP pokazuje, jak zastosować [efekt odbicia](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getReflectionEffect) do kształtu:

```php
use aspose\slides\Presentation;
use aspose\slides\RectangleAlignment;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableReflectionEffect();
    $shape->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment::Bottom);
    $shape->getEffectFormat()->getReflectionEffect()->setDirection(90);
    $shape->getEffectFormat()->getReflectionEffect()->setDistance(40);
    $shape->getEffectFormat()->getReflectionEffect()->setBlurRadius(2);

    $presentation->save("reflection_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Efekt odbicia](reflection_effect.png)

## **Zastosuj efekt poświaty**

Aby zastosować efekt poświaty do kształtu w Aspose.Slides for PHP via Java, możesz dodać miękką, świecącą aurę wokół kształtów, dostosowując właściwości takie jak kolor i rozmiar. Efekt ten pomaga wyróżnić kształty i dodaje atrakcyjny, przyciągający wzrok element wizualny do Twojej prezentacji. Łatwo go zaimplementować przy minimalnym kodzie, podnosząc ogólny wygląd slajdów.

Ten kod PHP pokazuje, jak zastosować [efekt poświaty](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getGlowEffect) do kształtu:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableGlowEffect();
    $shape->getEffectFormat()->getGlowEffect()->getColor()->setColor(java("java.awt.Color")->MAGENTA);
    $shape->getEffectFormat()->getGlowEffect()->setRadius(15);

    $presentation->save("glow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Efekt poświaty](glow_effect.png)

## **Zastosuj efekt miękkich krawędzi**

Aby zastosować efekt miękkich krawędzi w Aspose.Slides for PHP via Java, możesz stworzyć płynne, rozmyte przejście wokół krawędzi kształtu. Efekt ten dodaje subtelny i wyrafinowany wygląd, idealny dla projektów wymagających delikatniejszego wyglądu. Łatwo możesz dostosować parametry, takie jak promień, aby uzyskać pożądany efekt w różnych kształtach w swojej prezentacji.

Ten kod PHP pokazuje, jak zastosować [efekt miękkich krawędzi](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getSoftEdgeEffect) do kształtu:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableSoftEdgeEffect();
    $shape->getEffectFormat()->getSoftEdgeEffect()->setRadius(8);

    $presentation->save("soft_edges_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Efekt miękkich krawędzi](soft_edges_effect.png)

## **FAQ**

**Czy mogę zastosować wiele efektów do tego samego kształtu?**

Tak, możesz łączyć różne efekty, takie jak cień, odbicie i poświata, na jednym kształcie, aby uzyskać bardziej dynamiczny wygląd.

**Do jakich kształtów mogę zastosować efekty?**

Możesz stosować efekty do różnych kształtów, w tym autoshape'ów, wykresów, tabel, obrazów, obiektów SmartArt, obiektów OLE i innych.

**Czy mogę zastosować efekty do grupowanych kształtów?**

Tak, możesz zastosować efekty do grupowanych kształtów. Efekt zostanie zastosowany do całej grupy.