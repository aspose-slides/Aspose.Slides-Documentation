---
title: Tworzenie i zastosowanie efektów WordArt w PHP
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
- efekt wyświetlania
- efekt poświaty
- transformacja WordArt
- efekt 3D
- efekt zewnętrznego cienia
- efekt wewnętrznego cienia
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Tworzenie i dostosowywanie efektów WordArt w Aspose.Slides dla PHP via Java. Ten przewodnik krok po kroku pomaga programistom wzbogacić prezentacje profesjonalnym tekstem."
---
## **Przegląd**

Efekty WordArt pozwalają dodawać wizualnie atrakcyjny, stylizowany tekst do prezentacji PowerPoint. Dzięki Aspose.Slides programiści mogą programowo tworzyć, dostosowywać i zarządzać WordArt tak jak w Microsoft PowerPoint — bez konieczności instalowania Office. W tym artykule przedstawiono omówienie pracy z WordArt, w tym jak stosować transformacje tekstu, style wypełnień, obrysów, cieni i inne opcje formatowania, aby treść prezentacji była bardziej ekspresyjna i angażująca. WordArt umożliwia traktowanie tekstu jako obiektu graficznego. Składa się z efektów lub specjalnych modyfikacji stosowanych do tekstu, aby był on bardziej atrakcyjny lub zauważalny.

## **Utwórz prosty szablon WordArt i zastosuj go do tekstu**

**Korzystanie z Aspose.Slides** 

Najpierw tworzymy prosty tekst przy użyciu tego kodu PHP:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $autoShape->getTextFrame();
    $portion = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
Teraz ustawiamy wysokość czcionki tekstu na większą wartość, aby efekt był bardziej widoczny, za pomocą tego kodu:

```php
  $fontData = new FontData("Arial Black");
  $portion->getPortionFormat()->setLatinFont($fontData);
  $portion->getPortionFormat()->setFontHeight(36);

```

**Korzystanie z Microsoft PowerPoint**

Przejdź do menu efektów WordArt w Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Z menu po prawej możesz wybrać wstępnie zdefiniowany efekt WordArt. Z menu po lewej możesz określić ustawienia nowego WordArt. 

Oto niektóre dostępne parametry lub opcje:

![todo:image_alt_text](image-20200930114015-3.png)

**Korzystanie z Aspose.Slides**

Tutaj stosujemy kolor wzoru [SmallGrid](https://reference.aspose.com/slides/pl/php-java/aspose.slides/patternstyle/#SmallGrid) do tekstu i dodajemy czarną obwódkę o szerokości 1 za pomocą tego kodu:

```php
  $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->ORANGE);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle->SmallGrid);
  $portion->getPortionFormat()->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $portion->getPortionFormat()->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

```

Wynikowy tekst:

![todo:image_alt_text](image-20200930114108-4.png)

## **Zastosuj inne efekty WordArt**

**Korzystanie z Microsoft PowerPoint**

Z interfejsu programu możesz zastosować te efekty do tekstu, bloku tekstowego, kształtu lub podobnego elementu:

![todo:image_alt_text](image-20200930114129-5.png)

Na przykład efekty Cień, Refleksja i Poświata mogą być zastosowane do tekstu; efekty Format 3D i Obrót 3D mogą być zastosowane do bloku tekstowego; właściwość Miękkie krawędzie może być zastosowana do obiektu Shape (działa ona również, gdy nie jest ustawiona właściwość Format 3D). 

### **Zastosuj efekty cienia**

Tutaj zamierzamy ustawić właściwości dotyczące wyłącznie tekstu. Stosujemy efekt cienia do tekstu przy użyciu tego kodu:

```php
  $portion->getPortionFormat()->getEffectFormat()->enableOuterShadowEffect();
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor(java("java.awt.Color")->BLACK);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleHorizontal(100);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleVertical(65);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setBlurRadius(4.73);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDirection(230);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDistance(2);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewHorizontal(30);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewVertical(0);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->getColorTransform()->add(ColorTransformOperation->SetAlpha, 0.32);

```

API Aspose.Slides obsługuje trzy typy cieni: OuterShadow, InnerShadow i PresetShadow. 

Przy użyciu PresetShadow możesz zastosować cień do tekstu (korzystając z wartości presetowanych). 

**Korzystanie z Microsoft PowerPoint**

W PowerPoint możesz używać jednego typu cienia. Oto przykład:

![todo:image_alt_text](image-20200930114225-6.png)

**Korzystanie z Aspose.Slides**

Aspose.Slides faktycznie pozwala zastosować dwa typy cieni jednocześnie: InnerShadow i PresetShadow.

**Uwaga:**

- Gdy OuterShadow i PresetShadow są używane razem, stosowany jest tylko efekt OuterShadow. 
- Jeśli OuterShadow i InnerShadow są używane jednocześnie, zastosowany efekt zależy od wersji PowerPoint. Na przykład w PowerPoint 2013 efekt jest podwajany. Natomiast w PowerPoint 2007 stosowany jest efekt OuterShadow. 

### **Zastosuj efekty refleksji do tekstu**

Dodajemy refleksję do tekstu za pomocą tego przykładu kodu:

```php
  $portion->getPortionFormat()->getEffectFormat()->enableReflectionEffect();
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setBlurRadius(0.5);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDistance(4.72);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartPosAlpha(0.0);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndPosAlpha(60.0);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDirection(90);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleHorizontal(100);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleVertical(-100);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartReflectionOpacity(60.0);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndReflectionOpacity(0.9);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment->BottomLeft);
```

### **Zastosuj efekty poświaty do tekstu**

Stosujemy efekt poświaty do tekstu, aby błyszczał lub wyróżniał się, używając tego kodu:

```php
  $portion->getPortionFormat()->getEffectFormat()->enableGlowEffect();
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->setR(255);
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->getColorTransform()->add(ColorTransformOperation->SetAlpha, 0.54);
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->setRadius(7);
```

Wynik operacji:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Możesz zmienić parametry cienia, refleksji i poświaty. Właściwości efektów są ustawiane osobno dla każdej części tekstu. 

{{% /alert %}} 

### **Użyj transformacji w WordArt**

Używamy właściwości Transform (obowiązującej dla całego bloku tekstu) przy pomocy tego kodu:
```php
  $textFrame->getTextFrameFormat()->setTransform(TextShapeType::ArchUpPour);
```

Wynik:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Zarówno Microsoft PowerPoint, jak i Aspose.Slides for PHP via Java udostępniają pewną liczbę wstępnie zdefiniowanych typów transformacji.

{{% /alert %}} 

**Korzystanie z PowerPoint**

Aby uzyskać dostęp do wstępnie zdefiniowanych typów transformacji, przejdź do: **Format** -> **TextEffect** -> **Transform**

**Korzystanie z Aspose.Slides**

Aby wybrać typ transformacji, użyj wyliczenia TextShapeType. 

### **Zastosuj efekty 3D do tekstu i kształtów**

Ustawiamy efekt 3D dla kształtu tekstowego przy użyciu tego przykładowego kodu:

```php
  $autoShape->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
  $autoShape->getThreeDFormat()->getBevelBottom()->setHeight(10.5);
  $autoShape->getThreeDFormat()->getBevelBottom()->setWidth(10.5);
  $autoShape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
  $autoShape->getThreeDFormat()->getBevelTop()->setHeight(12.5);
  $autoShape->getThreeDFormat()->getBevelTop()->setWidth(11);
  $autoShape->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->ORANGE);
  $autoShape->getThreeDFormat()->setExtrusionHeight(6);
  $autoShape->getThreeDFormat()->getContourColor()->setColor(java("java.awt.Color")->RED);
  $autoShape->getThreeDFormat()->setContourWidth(1.5);
  $autoShape->getThreeDFormat()->setDepth(3);
  $autoShape->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
  $autoShape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
  $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
  $autoShape->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
  $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

Wynikowy tekst i jego kształt:

![todo:image_alt_text](image-20200930114816-9.png)

Stosujemy efekt 3D do tekstu za pomocą tego kodu PHP:

```php
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setHeight(3.5);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setWidth(3.5);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setHeight(4);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setWidth(4);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->ORANGE);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setExtrusionHeight(6);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getContourColor()->setColor(java("java.awt.Color")->RED);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setContourWidth(1.5);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setDepth(3);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

Wynik operacji:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

Stosowanie efektów 3D do tekstów lub ich kształtów oraz interakcje między efektami opierają się na określonych regułach. 

Rozważ scenę dla tekstu i kształtu zawierającego ten tekst. Efekt 3D obejmuje reprezentację obiektu 3D oraz scenę, na której obiekt został umieszczony. 

- Gdy scena jest ustawiona zarówno dla figury, jak i tekstu, scena figury ma wyższy priorytet – scena tekstu jest ignorowana. 
- Gdy figura nie ma własnej sceny, ale posiada reprezentację 3D, używana jest scena tekstu. 
- W przeciwnym razie – gdy kształt pierwotnie nie ma efektu 3D – kształt jest płaski i efekt 3D jest stosowany tylko do tekstu. 

Te opisy są powiązane z metodami ThreeDFormat.getLightRig() i ThreeDFormat.getCamera(). 

{{% /alert %}} 

## **Zastosuj efekty zewnętrznego cienia do tekstu**
Aspose.Slides for PHP via Java udostępnia klasy [OuterShadow](https://reference.aspose.com/slides/pl/php-java/aspose.slides/outershadow/) i [InnerShadow](https://reference.aspose.com/slides/pl/php-java/aspose.slides/innershadow/), które pozwalają stosować efekty cienia do tekstu zawartego w [TextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/). Postępuj zgodnie z poniższymi krokami:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/). 
2. Uzyskaj odniesienie do slajdu, używając jego indeksu. 
3. Dodaj AutoShape typu Rectangle do slajdu. 
4. Uzyskaj dostęp do TextFrame skojarzonego z AutoShape. 
5. Ustaw FillType AutoShape na NoFill. 
6. Utwórz instancję klasy OuterShadow. 
7. Ustaw BlurRadius cienia. 
8. Ustaw Direction cienia. 
9. Ustaw Distance cienia. 
10. Ustaw RectanglelAlign na TopLeft. 
11. Ustaw PresetColor cienia na Black. 
12. Zapisz prezentację jako plik [PPTX](https://docs.fileformat.com/presentation/pptx/). 

Ten przykładowy kod — implementacja powyższych kroków — pokazuje, jak zastosować efekt zewnętrznego cienia do tekstu:

```php
  $pres = new Presentation();
  try {
    # Pobierz referencję do slajdu
    $sld = $pres->getSlides()->get_Item(0);
    # Dodaj AutoShape typu Rectangle
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # Dodaj TextFrame do Rectangle
    $ashp->addTextFrame("Aspose TextBox");
    # Wyłącz wypełnienie kształtu, jeśli chcemy uzyskać cień tekstu
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Dodaj zewnętrzny cień i ustaw wszystkie niezbędne parametry
    $ashp->getEffectFormat()->enableOuterShadowEffect();
    $shadow = $ashp->getEffectFormat()->getOuterShadowEffect();
    $shadow->setBlurRadius(4.0);
    $shadow->setDirection(45);
    $shadow->setDistance(3);
    $shadow->setRectangleAlign(RectangleAlignment->TopLeft);
    $shadow->getShadowColor()->setPresetColor(PresetColor->Black);
    # Zapisz prezentację na dysku
    $pres->save("pres_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Zastosuj efekty wewnętrznego cienia do kształtów**
Postępuj według następujących kroków:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/). 
2. Pobierz odniesienie do slajdu. 
3. Dodaj AutoShape typu Rectangle. 
4. Włącz InnerShadowEffect. 
5. Ustaw wszystkie niezbędne parametry. 
6. Ustaw ColorType jako Scheme. 
7. Ustaw Scheme Color. 
8. Zapisz prezentację jako plik [PPTX](https://docs.fileformat.com/presentation/pptx/). 

Ten przykładowy kod (oparty na powyższych krokach) pokazuje, jak dodać łącznik pomiędzy dwoma kształtami:

```php
  $pres = new Presentation();
  try {
    # Pobierz referencję do slajdu
    $slide = $pres->getSlides()->get_Item(0);
    # Dodaj AutoShape typu Rectangle
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 400, 300);
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Dodaj TextFrame do Rectangle
    $ashp->addTextFrame("Aspose TextBox");
    $port = $ashp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $pf = $port->getPortionFormat();
    $pf->setFontHeight(50);
    # Włącz InnerShadowEffect
    $ef = $pf->getEffectFormat();
    $ef->enableInnerShadowEffect();
    # Ustaw wszystkie niezbędne parametry
    $ef->getInnerShadowEffect()->setBlurRadius(8.0);
    $ef->getInnerShadowEffect()->setDirection(90.0);
    $ef->getInnerShadowEffect()->setDistance(6.0);
    $ef->getInnerShadowEffect()->getShadowColor()->setB(189);
    # Ustaw ColorType jako Scheme
    $ef->getInnerShadowEffect()->getShadowColor()->setColorType(ColorType::Scheme);
    # Ustaw Scheme Color
    $ef->getInnerShadowEffect()->getShadowColor()->setSchemeColor(SchemeColor->Accent1);
    # Zapisz prezentację
    $pres->save("WordArt_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Czy mogę używać efektów WordArt z różnymi czcionkami lub skryptami (np. arabski, chiński)?**  

Tak, Aspose.Slides obsługuje Unicode i działa ze wszystkimi głównymi czcionkami oraz skryptami. Efekty WordArt, takie jak cień, wypełnienie i obrys, mogą być stosowane niezależnie od języka, choć dostępność czcionek i renderowanie mogą zależeć od czcionek systemowych.

**Czy mogę stosować efekty WordArt do elementów master slajdu?**  

Tak, możesz stosować efekty WordArt do kształtów na slajdach master, w tym do pól placeholderów tytułu, stopek lub tekstu w tle. Zmiany w układzie master będą odzwierciedlone we wszystkich powiązanych slajdach.

**Czy efekty WordArt wpływają na rozmiar pliku prezentacji?**  

Nieznacznie. Efekty WordArt, takie jak cienie, poświaty i wypełnienia gradientowe, mogą nieco zwiększyć rozmiar pliku ze względu na dodatkowe metadane formatowania, ale różnica jest zwykle pomijalna.

**Czy mogę podejrzeć wynik efektów WordArt bez zapisywania prezentacji?**  

Tak, możesz renderować slajdy zawierające WordArt do obrazów (np. PNG, JPEG) przy użyciu metody `getImage` z klasy [Shape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/) lub [Slide](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slide/). Dzięki temu możesz podejrzeć wynik w pamięci lub na ekranie przed zapisaniem lub wyeksportowaniem pełnej prezentacji.