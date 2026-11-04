---
title: Zastosowanie efektów kształtów w prezentacjach przy użyciu PHP
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
description: "Przekształć swoje pliki PPT i PPTX za pomocą zaawansowanych efektów kształtów wykorzystując Aspose.Slides for PHP via Java — twórz efektowne, profesjonalne slajdy w kilka sekund."
---
## **Wprowadzenie**

Efekty w programie PowerPoint można wykorzystać, aby wyróżnić kształt, ale różnią się od [wypełnień](/slides/pl/php-java/shape-formatting/#gradient-fill) lub konturów. Korzystając z efektów PowerPoint, możesz tworzyć przekonujące odbicia kształtu, rozprzestrzeniać poświatę kształtu itp.

![Efekt kształtu](shape-effect.png)

PowerPoint udostępnia sześć efektów, które można zastosować do kształtów. Możesz zastosować jeden lub więcej efektów do jednego kształtu.

Niektóre kombinacje efektów wyglądają lepiej niż inne. Z tego powodu PowerPoint oferuje opcje w ramach **Predefiniowane**. Opcje Predefiniowane to kombinacje dwóch lub więcej efektów, które wiadomo, że wyglądają dobrze. Dzięki temu, wybierając predefiniowany zestaw, nie musisz tracić czasu na testowanie lub łączenie różnych efektów w poszukiwaniu udanej kombinacji.

Aspose.Slides udostępnia właściwości i metody w klasie [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/), które pozwalają zastosować te same efekty do kształtów w prezentacjach PowerPoint.

## **Zastosuj efekt cienia**

Aspose.Slides for PHP via Java obsługuje cienie zewnętrzne i wewnętrzne dla kształtów. Możesz dostosować ich kolor, kierunek, odległość i promień rozmycia, aby pasowały do projektu prezentacji.

### **Zastosuj cień zewnętrzny**

Użyj cienia zewnętrznego, aby wyróżnić kartę lub panel na tle slajdu. Cień wykracza poza krawędzie kształtu, tworząc wrażenie, że kształt jest uniesiony nad slajdem. Dostosuj jego kolor, kierunek, odległość i promień rozmycia, aby pasowały do oświetlenia i stylu szablonu.

Ten kod PHP pokazuje, jak zastosować [efekt cienia zewnętrznego](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getOuterShadowEffect) do prostokąta:

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

### **Zastosuj cień wewnętrzny**

Podczas odtwarzania wizualnego stylu szablonu użyj cienia wewnętrznego, aby nadać karcie lub panelowi wklęsły wygląd. Cień zewnętrzny rozciąga się poza kształt i sprawia, że wygląda na podniesiony, podczas gdy cień wewnętrzny zacienia wewnętrzne krawędzie.

Wywołaj [enableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enableInnerShadowEffect), a następnie skonfiguruj cień zwrócony przez [getInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getInnerShadowEffect). Większe wartości promienia rozmycia powodują łagodniejsze krawędzie.

Ten przykład PHP tworzy jasno niebieską kartę z ciemnoszarym cieniem wewnętrznym i zapisuje ją jako plik PPTX. Kierunek cienia wynosi 225 stopni, odległość 7 punktów, a promień rozmycia 6 punktów:

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

![Jasnoniebieski prostokąt z cieniem wewnętrznym](inner_shadow_effect.png)

Aby usunąć cień wewnętrzny, wywołaj [disableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableInnerShadowEffect) na formacie efektu kształtu.

## **Zastosuj efekt odbicia**

Aby zastosować efekt odbicia w Aspose.Slides for PHP via Java, możesz dodać lustrzane odbicie do kształtów, regulując parametry takie jak odległość, przezroczystość i rozmiar. Efekt ten podnosi estetykę prezentacji, nadając kształtom bardziej dopracowany i wyrafinowany wygląd. Jest łatwy do wdrożenia przy użyciu prostego kodu, umożliwiając szybkie zastosowanie w wielu elementach dla spójnego projektu.

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

Aby zastosować efekt poświaty do kształtu w Aspose.Slides for PHP via Java, możesz dodać miękką, świetlistą aurę wokół kształtów, regulując właściwości takie jak kolor i rozmiar. Efekt ten pomaga wyróżnić kształty i dodaje atrakcyjny, przyciągający wzrok element wizualny do prezentacji. Jest łatwy do wdrożenia przy minimalnym kodzie, podnosząc ogólny wygląd slajdów.

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

Aby zastosować efekt miękkich krawędzi w Aspose.Slides for PHP via Java, możesz stworzyć płynne, rozmyte przejście wokół krawędzi kształtu. Efekt ten dodaje subtelny i wyrafinowany wygląd, idealny dla projektów wymagających delikatnego, łagodniejszego wyglądu. Łatwo możesz regulować parametry, takie jak promień, aby uzyskać pożądany efekt w różnych kształtach w prezentacji.

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

## **Zastosuj efekt rozmycia**

Użyj rozmycia kształtu, aby złagodzić wypełnienie i kontur kształtu, zachowując jednocześnie możliwość edycji kształtu. Wywołaj [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) na formacie efektu kształtu. Promień jest mierzony w punktach (1/72 cala): użyj wartości nieujemnej, przy czym większe wartości powodują silniejsze rozmycie. Promień równy zero nie zmienia wyglądu.

Ustawienie [getGrow](https://reference.aspose.com/slides/php-java/aspose.slides/blur/#getGrow) kontroluje widoczne granice efektu. Przy `false` rozmycie jest przycięte do pierwotnych pomalowanych granic, w tym konturu. Przy `true` rozmycie może wykraczać poza te granice. Żadne z ustawień nie zmienia położenia ani wymiarów kształtu.

Poniższe porównanie używa tego samego wypełnienia, konturu i wymiarów kształtu w całej demonstracji. Górny rząd używa `grow = false`; dolny rząd używa `grow = true`.

![Oryginalny prostokąt porównany z promieniami rozmycia 5 i 15 punktów, przy wyłączonym i włączonym grow](shape_blur_comparison.png)

Ten przykład PHP tworzy pomarańczowy prostokąt z ciemnoniebieskim konturem, stosuje rozmycie o promieniu 5 punktów, a następnie aktualizuje je do rozmycia o promieniu 15 punktów, ponownie wywołując [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect). Zapisuje oba stany rozmycia, a potem wywołuje [disableBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableBlurEffect) i zapisuje kształt bez rozmycia.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 80, 160, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 0, 0, 139);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
    $shape->getLineFormat()->setWidth(8);

    $shape->getEffectFormat()->setBlurEffect(5, false);
    $presentation->save("shape_blur_5.pptx", SaveFormat::Pptx);

    $shape->getEffectFormat()->setBlurEffect(15, true);
    $presentation->save("shape_blur_15.pptx", SaveFormat::Pptx);

    $shape->getEffectFormat()->disableBlurEffect();
    $presentation->save("shape_blur_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Rozmycie kształtu wpływa jednocześnie na wypełnienie i kontur. Efekt miękkich krawędzi rozjaśnia krawędzie kształtu, natomiast rozmycie cienia złagodzi tylko cień. Efekty transformacji obrazu działają na zawartość obrazu; ten przykład stosuje rozmycie bezpośrednio do formatu efektu kształtu, bez konwersji kształtu na obraz.

## **FAQ**

**Czy mogę zastosować wiele efektów do tego samego kształtu?**

Tak, możesz łączyć różne efekty, takie jak cień, odbicie i poświata, na jednym kształcie, aby uzyskać bardziej dynamiczny wygląd.

**Do jakich kształtów mogę zastosować efekty?**

Możesz stosować efekty do różnych kształtów, w tym automatycznych kształtów, wykresów, tabel, obrazów, obiektów SmartArt, obiektów OLE i innych.

**Czy mogę zastosować efekty do grupowanych kształtów?**

Tak, możesz zastosować efekty do grupowanych kształtów. Efekt zostanie zastosowany do całej grupy.