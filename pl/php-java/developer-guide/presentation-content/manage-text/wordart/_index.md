---
title: Tworzenie i stosowanie efektów WordArt w PHP
linktitle: WordArt
type: docs
weight: 110
url: /pl/php-java/wordart/
keywords:
- WordArt
- tworzenie WordArt
- szablon WordArt
- efekt WordArt
- efekt cienia
- efekt odbicia
- efekt poświaty
- przekształcenie WordArt
- efekt 3D
- efekt zewnętrznego cienia
- efekt wewnętrznego cienia
- PHP
- Aspose.Slides
description: "Tworzenie i dostosowywanie efektów WordArt w Aspose.Slides for PHP via Java. Ten przewodnik krok po kroku pomaga programistom ulepszyć prezentacje profesjonalnym tekstem w PHP."
---
## **Przegląd**

Efekty WordArt umożliwiają stylizowanie tekstu przy użyciu wypełnień, konturów, cieni, odbić, poświaty, przekształceń i formatowania 3D. Ten artykuł wyjaśnia, jak tworzyć i dostosowywać te efekty w prezentacjach PowerPoint przy użyciu Aspose.Slides for PHP via Java, bez zainstalowanego Microsoft Office.

## **Utworzenie prostego szablonu WordArt i zastosowanie go do tekstu**

Poniższe przykłady tworzą prosty styl WordArt poprzez ustawienie tekstu, czcionki, wypełnienia wzorem i konturu.

Każdy przykład tworzy nową prezentację i dodaje prostokąt do pierwszego slajdu; nie jest wymaga pliku wejściowego. Pierwszy przykład ustawia tekst na "Aspose.Slides". Pozycja i wymiary kształtu są mierzone w punktach:

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);
    $textFrame = $autoShape->getTextFrame();

    $portion = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
} finally {
    $presentation->dispose();
}
```

Ustaw czcionkę na Arial Black o rozmiarze 36 punktów, aby formatowanie było bardziej widoczne:

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);
} finally {
    $presentation->dispose();
}
```

Zastosuj wzór [SmallGrid](https://reference.aspose.com/slides/pl/php-java/aspose.slides/patternstyle/#SmallGrid) z ciemnopomarańczowym pierwszym planem i białym tłem, a następnie dodaj czarny kontur tekstu o szerokości 1 punktu:

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\PatternStyle;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);

    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
    $darkOrange = new Java("java.awt.Color", 255, 140, 0);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor($darkOrange);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::SmallGrid);

    $portion->getPortionFormat()->getLineFormat()->setWidth(1);
    $portion->getPortionFormat()->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
} finally {
    $presentation->dispose();
}
```

Wynikowy tekst:

![Prosty szablon WordArt](WordArt_template.png)

## **Zastosowanie innych efektów WordArt**

Poniższe przykłady pokazują, jak zastosować cienie, odbicia, poświatę, przekształcenia i efekty 3D do tekstu.

### **Zastosowanie efektu zewnętrznego cienia**

Zewnętrzny cień dodaje głębi, umieszczając cień za tekstem. Możesz dostosować jego kolor, kierunek, odległość, promień rozmycia, skalę i pochylenie.

Ten przykład wywołuje [enableOuterShadowEffect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/effectformat/#enableOuterShadowEffect--) i ustawia czarny cień z promieniem rozmycia 4 punkty, kierunkiem 230 stopni oraz odległością 30 punktów. Wartość skali 100 zachowuje rozmiar cienia, a pochylenie poziome przechyla go o 20 stopni. Transformacja alfa ustawia jego nieprzezroczystość na 32%:

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);

    $portion->getPortionFormat()->getEffectFormat()->enableOuterShadowEffect();
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleHorizontal(100);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleVertical(100);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setBlurRadius(4);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDirection(230);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDistance(30);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewHorizontal(20);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewVertical(0);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->getColorTransform()->add(ColorTransformOperation::SetAlpha, 0.32);
} finally {
    $presentation->dispose();
}
```

Wynikowy tekst:

![Efekt zewnętrznego cienia](outer_shadow_effect.png)

{{% alert color="info" title="Uwaga" %}}
- Gdy jednocześnie używane są zewnętrzne i wstępnie ustawione cienie, stosowany jest tylko zewnętrzny cień.
- Jeśli jednocześnie używane są cienie zewnętrzne i wewnętrzne, ostateczny efekt zależy od wersji PowerPointa. Na przykład w PowerPoint 2013 efekt jest podwojony, natomiast w PowerPoint 2007 stosowany jest tylko zewnętrzny cień.
{{% /alert %}}

### **Zastosowanie efektu odbicia**

Odbicie tworzy lustrzane odbicie tekstu. Dostosuj jego pozycję, skalę, rozmycie i nieprzezroczystość, aby kontrolować wygląd.

Ten przykład wywołuje [enableReflectionEffect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/effectformat/#enableReflectionEffect--) i odwraca odbicie pionowo ze skalą -100%. Używa promienia rozmycia 0,5 punktu oraz odległości 4,72 punktu. Nieprzezroczystość zmniejsza się z 60% do 0,9% między pozycjami 0% i 60% wzdłuż odbicia:

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\RectangleAlignment;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);

    $portion->getPortionFormat()->getEffectFormat()->enableReflectionEffect();
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setBlurRadius(0.5);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDistance(4.72);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartPosAlpha(0);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndPosAlpha(60);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDirection(90);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleHorizontal(100);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleVertical(-100);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartReflectionOpacity(60);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndReflectionOpacity(0.9);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment::BottomLeft);
} finally {
    $presentation->dispose();
}
```

Wynikowy tekst:

![Efekt odbicia](reflection_effect.png)

### **Zastosowanie efektu poświaty**

Poświata dodaje miękki, kolorowy kontur wokół tekstu. Dostosuj jej kolor, nieprzezroczystość i promień, aby kontrolować efekt.

Ten przykład wywołuje [enableGlowEffect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/effectformat/#enableGlowEffect--) i stosuje czerwoną poświatę z 54% nieprzezroczystością oraz promieniem 7 punktów:

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);

    $portion->getPortionFormat()->getEffectFormat()->enableGlowEffect();
    $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->setColor(java("java.awt.Color")->RED);
    $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->getColorTransform()->add(ColorTransformOperation::SetAlpha, 0.54);
    $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->setRadius(7);
} finally {
    $presentation->dispose();
}
```

Wynikowy tekst:

![Efekt poświaty](glow_effect.png)

### **Zastosowanie przekształceń WordArt**

Przekształcenia WordArt wyginają, rozciągają lub deformują blok tekstu.

Ustaw [setTransform](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframeformat/#setTransform-int-) na [ArchUpPour](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textshapetype/#ArchUpPour), aby wygiąć cały ramkę tekstową w górę:

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\TextShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("Aspose.Slides");
    $textFrame->getTextFrameFormat()->setTransform(TextShapeType::ArchUpPour);
} finally {
    $presentation->dispose();
}
```

Wynikowy tekst:

![Przekształcenie WordArt](transform_effect.png)

{{% alert color="info" title="Uwaga" %}}
Aspose.Slides for PHP via Java udostępnia zestaw wstępnie zdefiniowanych [typów przekształceń](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textshapetype/).
{{% /alert %}}

### **Zastosowanie efektów 3D do kształtów i tekstu**

Możesz zastosować efekty 3D do kształtu lub jego tekstu. Krawędzie, ekstruzja, oświetlenie i ustawienia kamery kontrolują końcowy wygląd.

Poniższy przykład używa [ThreeDFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/threedformat/), aby dodać okrągłe krawędzie, pomarańczową ekstruzję i ciemnoczerwony kontur do prostokąta. Wymiary krawędzi, wysokość ekstruzji, szerokość konturu i głębokość są mierzone w punktach. Materiał plastikowy, zrównoważone oświetlenie obrócone o 40 stopni wokół osi Z oraz kamera perspektywiczna definiują jego wygląd:

```php
use aspose\slides\BevelPresetType;
use aspose\slides\CameraPresetType;
use aspose\slides\LightRigPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);
    $autoShape->getTextFrame()->setText("Aspose.Slides");

    $autoShape->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
    $autoShape->getThreeDFormat()->getBevelBottom()->setHeight(10.5);
    $autoShape->getThreeDFormat()->getBevelBottom()->setWidth(10.5);

    $autoShape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $autoShape->getThreeDFormat()->getBevelTop()->setHeight(12.5);
    $autoShape->getThreeDFormat()->getBevelTop()->setWidth(11);

    $orange = new Java("java.awt.Color", 255, 165, 0);
    $autoShape->getThreeDFormat()->getExtrusionColor()->setColor($orange);
    $autoShape->getThreeDFormat()->setExtrusionHeight(6);

    $darkRed = new Java("java.awt.Color", 139, 0, 0);
    $autoShape->getThreeDFormat()->getContourColor()->setColor($darkRed);
    $autoShape->getThreeDFormat()->setContourWidth(1.5);

    $autoShape->getThreeDFormat()->setDepth(3);

    $autoShape->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);

    $autoShape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    $autoShape->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);

    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);
} finally {
    $presentation->dispose();
}
```

Wynikowy kształt:

![Efekt 3D kształtu](shape_3D_effect.png)

Ten przykład stosuje podobne formatowanie 3D do tekstu przy użyciu [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframeformat/#getThreeDFormat--). Mniejsze krawędzie kształtują krawędzie liter, a ekstruzja i oświetlenie nadają tekstowi głębię:

```php
use aspose\slides\BevelPresetType;
use aspose\slides\CameraPresetType;
use aspose\slides\LightRigPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);
    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("Aspose.Slides");

    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setHeight(3.5);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setWidth(3.5);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setHeight(4);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setWidth(4);

    $orange = new Java("java.awt.Color", 255, 165, 0);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getExtrusionColor()->setColor($orange);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->setExtrusionHeight(6);

    $darkRed = new Java("java.awt.Color", 139, 0, 0);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getContourColor()->setColor($darkRed);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->setContourWidth(1.5);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->setDepth(3);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);
} finally {
    $presentation->dispose();
}
```

Wynikowy tekst:

![Efekt 3D tekstu](text_3D_effect.png)

{{% alert color="info" title="Uwaga" %}}
Zastosowanie efektów 3D do tekstu lub ich kształtów — oraz interakcja między tymi efektami — jest regulowana określonymi zasadami. Rozważ scenę obejmującą zarówno tekst, jak i kształt go zawierający. Efekt 3D obejmuje trójwymiarową reprezentację obiektu oraz scenę, w której jest umieszczony.

- Jeśli scena jest ustawiona zarówno dla kształtu, jak i tekstu, scenę kształtu ma pierwszeństwo, a scena tekstu jest ignorowana.
- Jeśli kształt nie ma własnej sceny, ale posiada reprezentację 3D, używana jest scena tekstu.
- Jeśli kształt nie ma wcale efektu 3D, traktowany jest jako płaski, a efekt 3D jest stosowany wyłącznie do tekstu.

Te zachowania odnoszą się do metod [ThreeDFormat::getLightRig](https://reference.aspose.com/slides/pl/php-java/aspose.slides/threedformat/#getLightRig--) i [ThreeDFormat::getCamera](https://reference.aspose.com/slides/pl/php-java/aspose.slides/threedformat/#getCamera--).
{{% /alert %}}

Więcej przykładów formatowania 3D znajdziesz w [Tworzenie efektów 3D w prezentacjach przy użyciu PHP](/slides/pl/php-java/3d-presentation/).

## **FAQ**

**Czy mogę używać efektów WordArt z różnymi czcionkami lub skryptami (np. arabski, chiński)?**

Tak, Aspose.Slides for PHP via Java obsługuje Unicode i działa ze wszystkimi popularnymi czcionkami i skryptami. Efekty WordArt, takie jak cień, wypełnienie i kontur, można stosować niezależnie od języka, choć dostępność czcionek i ich renderowanie mogą zależeć od czcionek systemowych.

**Czy mogę zastosować efekty WordArt do elementów mastera slajdu?**

Tak, możesz zastosować efekty WordArt do kształtów na slajdach master, w tym do pól tytułu, stopki lub tekstu tła. Zmiany wprowadzone w układzie master zostaną odzwierciedlone we wszystkich powiązanych slajdach.

**Czy efekty WordArt wpływają na rozmiar pliku prezentacji?**

Nieznacznie. Efekty WordArt, takie jak cienie, poświaty i wypełnienia gradientowe, mogą nieco zwiększyć rozmiar pliku ze względu na dodatkowe metadane formatowania, ale różnica zazwyczaj jest pomijalna.

**Czy mogę podglądać wynik efektów WordArt bez zapisywania prezentacji?**

Tak, możesz renderować slajdy zawierające WordArt do obrazów (np. PNG, JPEG) przy użyciu [Slide::getImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slide/#getImage--), lub renderować poszczególne kształty przy użyciu [Shape::getImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/#getImage--). Dzięki temu możesz podglądać wynik w pamięci lub na ekranie przed zapisaniem lub wyeksportowaniem pełnej prezentacji.