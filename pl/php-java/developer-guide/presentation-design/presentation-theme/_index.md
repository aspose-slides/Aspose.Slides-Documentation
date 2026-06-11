---
title: Zarządzaj motywami prezentacji w PHP
linktitle: Motyw prezentacji
type: docs
weight: 10
url: /pl/php-java/presentation-theme/
keywords:
- Motyw PowerPoint
- Motyw prezentacji
- Motyw slajdu
- Ustaw motyw
- Zmień motyw
- Zarządzaj motywem
- Kolor motywu
- Dodatkowa paleta
- Czcionka motywu
- Styl motywu
- Efekt motywu
- PowerPoint
- OpenDocument
- Prezentacja
- PHP
- Aspose.Slides
description: "Zarządzaj motywami prezentacji w Aspose.Slides dla PHP za pomocą Java, aby tworzyć, dostosowywać i konwertować pliki PowerPoint z zachowaniem spójnej identyfikacji wizualnej."
---
## **Wprowadzenie**

Motyw prezentacji definiuje właściwości elementów projektowych. Wybierając motyw prezentacji, w zasadzie wybierasz określony zestaw elementów wizualnych i ich właściwości.

W programie PowerPoint motyw składa się z kolorów, [czcionek](/slides/pl/php-java/powerpoint-fonts/), [stylów tła](/slides/pl/php-java/presentation-background/), oraz efektów.

![theme-constituents](theme-constituents.png)

## **Zmień kolor motywu**

Motyw PowerPoint używa określonego zestawu kolorów dla różnych elementów na slajdzie. Jeśli nie podoba Ci się zestaw kolorów, możesz je zmienić, stosując nowe kolory dla motywu. Aby umożliwić wybór nowego koloru motywu, Aspose.Slides udostępnia wartości w wyliczeniu [SchemeColor](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SchemeColor).

Ten kod PHP pokazuje, jak zmienić kolor akcentu w motywie:
```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Możesz w ten sposób określić efektywną wartość uzyskanego koloru:
```php
  $fillEffective = $shape->getFillFormat()->getEffective();
  $effectiveColor = $fillEffective->getSolidFillColor();
  echo(sprintf("Color [A=%d, R=%d, G=%d, B=%d]", $effectiveColor->getAlpha(), $effectiveColor->getRed(), $effectiveColor->getGreen(), $effectiveColor->getBlue()));

```

Aby dalej zilustrować operację zmiany koloru, tworzymy kolejny element i przypisujemy mu kolor akcentu (z początkowej operacji). Następnie zmieniamy kolor w motywie:
```php
  $otherShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 120, 100, 100);
  $otherShape->getFillFormat()->setFillType(FillType::Solid);
  $otherShape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
  $pres->getMasterTheme()->getColorScheme()->getAccent4()->setColor(java("java.awt.Color")->RED);
```

Nowy kolor zostaje automatycznie zastosowany w obu elementach.

### **Ustaw kolor motywu z dodatkowej palety**

Kiedy stosujesz transformacje luminancji do głównego koloru motywu(1), powstają kolory z dodatkowej palety(2). Możesz wtedy ustawiać i pobierać te kolory motywu. 

![additional-palette-colors](additional-palette-colors.png)

**1** - Główne kolory motywu

**2** - Kolory z dodatkowej palety.

Ten kod PHP demonstruje operację, w której kolory dodatkowej palety są uzyskiwane z głównego koloru motywu i następnie używane w kształtach:
```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Akcent 4
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 50, 50);
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    # Akcent 4, Jaśniejszy 80%
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 50, 50);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.2);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.8);
    # Akcent 4, Jaśniejszy 60%
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 50, 50);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.6);
    # Akcent 4, Jaśniejszy 40%
    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 50, 50);
    $shape4->getFillFormat()->setFillType(FillType::Solid);
    $shape4->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.6);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.4);
    # Akcent 4, Ciemniejszy 25%
    $shape5 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 250, 50, 50);
    $shape5->getFillFormat()->setFillType(FillType::Solid);
    $shape5->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape5->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.75);
    # Akcent 4, Ciemniejszy 50%
    $shape6 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 50, 50);
    $shape6->getFillFormat()->setFillType(FillType::Solid);
    $shape6->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape6->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.5);
    $presentation->save($path . "example_accent4.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

### **Mapuj `SchemeColor` na kolory `ColorScheme`**

Pracując z [SchemeColor](https://reference.aspose.com/slides/pl/php-java/aspose.slides/schemecolor/), możesz zauważyć, że zawiera następujące wartości kolorów motywu:
`Background1`, `Background2`, `Text1`, and `Text2`.

Jednak `Presentation::getMasterTheme()::getColorScheme()` zwraca [ColorScheme](https://reference.aspose.com/slides/pl/php-java/aspose.slides/colorscheme/), które udostępnia odpowiadające kolory jako:
`Dark1`, `Dark2`, `Light1`, and `Light2`.

Różnica dotyczy wyłącznie nazewnictwa. Wartości odnoszą się do tych samych slotów kolorów motywu, a mapowanie jest stałe:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Nie ma dynamicznej konwersji między `Text`/`Background` a `Dark`/`Light`. Są to po prostu alternatywne nazwy tych samych kolorów motywu.

Różnica w nazewnictwie pochodzi z terminologii Microsoft Office. Starsze wersje Office używały `Dark 1`, `Light 1`, `Dark 2` i `Light 2`, natomiast nowsze wersje interfejsu wyświetlają te same sloty jako `Text 1`, `Background 1`, `Text 2` i `Background 2`.

## **Zmień czcionkę motywu**

Aby umożliwić wybór czcionek dla motywów i innych celów, Aspose.Slides używa następujących specjalnych identyfikatorów (podobnych do tych używanych w PowerPoint):

* **+mn-lt** - Czcionka ciała (łacińska) (Minor Latin Font)
* **+mj-lt** - Czcionka tytułu (łacińska) (Major Latin Font)
* **+mn-ea** - Czcionka ciała (azjatycka) (Minor East Asian Font)
* **+mj-ea** - Czcionka ciała (azjatycka) (Major East Asian Font)

Ten kod PHP pokazuje, jak przypisać czcionkę łacińską do elementu motywu:
```php
  $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
  $paragraph = new Paragraph();
  $portion = new Portion("Theme text format");
  $paragraph->getPortions()->add($portion);
  $shape->getTextFrame()->getParagraphs()->add($paragraph);
  $portion->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));

```

Ten kod PHP pokazuje, jak zmienić czcionkę motywu prezentacji:
```php
  $pres->getMasterTheme()->getFontScheme()->getMinor()->setLatinFont(new FontData("Arial"));

```

Czcionka we wszystkich polach tekstowych zostanie zaktualizowana.
{{% alert color="primary" title="TIP" %}} 

You may want to see [PowerPoint fonts](/slides/pl/php-java/powerpoint-fonts/).
{{% /alert %}}

## **Zmień styl tła motywu**

Domyślnie aplikacja PowerPoint udostępnia 12 wstępnie zdefiniowanych teł, ale w typowej prezentacji zapisane są tylko 3 z tych 12 teł. 

![todo:image_alt_text](presentation-design_8.png)

Na przykład po zapisaniu prezentacji w aplikacji PowerPoint możesz uruchomić ten kod PHP, aby dowiedzieć się, ile wstępnie zdefiniowanych teł znajduje się w prezentacji:
```php
  $pres = new Presentation("pres.pptx");
  try {
    $numberOfBackgroundFills = $pres->getMasterTheme()->getFormatScheme()->getBackgroundFillStyles()->size();
    echo("Number of background fill styles for theme is " . $numberOfBackgroundFills);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" %}} 

Using the [BackgroundFillStyles](https://reference.aspose.com/slides/pl/php-java/aspose.slides/FormatScheme#getBackgroundFillStyles--) property from the [FormatScheme](https://reference.aspose.com/slides/pl/php-java/aspose.slides/FormatScheme) class, you can add or access the background style in a PowerPoint theme.
{{% /alert %}} 

Korzystając z właściwości [BackgroundFillStyles](https://reference.aspose.com/slides/pl/php-java/aspose.slides/FormatScheme#getBackgroundFillStyles--) klasy [FormatScheme](https://reference.aspose.com/slides/pl/php-java/aspose.slides/FormatScheme), możesz dodać lub uzyskać dostęp do stylu tła w motywie PowerPoint.
```php
  $pres->getMasters()->get_Item(0)->getBackground()->setStyleIndex(2);
```

**Poradnik indeksu**: 0 oznacza brak wypełnienia. Indeks zaczyna się od 1.
{{% alert color="primary" title="TIP" %}} 

You may want to see [PowerPoint Background](/slides/pl/php-java/presentation-background/).
{{% /alert %}}

## **Zmień efekt motywu**

Motyw PowerPoint zazwyczaj zawiera 3 wartości dla każdej tablicy stylów. Tablice te są łączone w te 3 efekty: subtelny, umiarkowany i intensywny. Na przykład, oto wynik zastosowania efektów do konkretnego kształtu:
![todo:image_alt_text](presentation-design_10.png)

Korzystając z 3 właściwości ([FillStyles](https://reference.aspose.com/slides/pl/php-java/aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/pl/php-java/aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/pl/php-java/aspose.slides/FormatScheme#getEffectStyles--)) klasy [FormatScheme](https://reference.aspose.com/slides/pl/php-java/aspose.slides/FormatScheme) możesz zmieniać elementy w motywie (jeszcze bardziej elastycznie niż opcje w PowerPoint).
```php
  $pres = new Presentation("Subtle_Moderate_Intense.pptx");
  try {
    $pres->getMasterTheme()->getFormatScheme()->getLineStyles()->get_Item(0)->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->getMasterTheme()->getFormatScheme()->getFillStyles()->get_Item(2)->setFillType(FillType::Solid);
    $pres->getMasterTheme()->getFormatScheme()->getFillStyles()->get_Item(2)->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $pres->getMasterTheme()->getFormatScheme()->getEffectStyles()->get_Item(2)->getEffectFormat()->getOuterShadowEffect()->setDistance(10.0);
    $pres->save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Powstałe zmiany w kolorze wypełnienia, typie wypełnienia, efekcie cienia itp:
![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**Czy mogę zastosować motyw do pojedynczego slajdu bez zmiany mastera?**

Tak. Aspose.Slides obsługuje nadpisywanie motywu na poziomie slajdu, więc możesz zastosować lokalny motyw tylko do tego slajdu, zachowując niezmieniony motyw główny (poprzez [SlideThemeManager](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slidethememanager/)).

**Jaki jest najbezpieczniejszy sposób przeniesienia motywu z jednej prezentacji do drugiej?**

[Klonuj slajdy](/slides/pl/php-java/clone-slides/) wraz z ich masterem do docelowej prezentacji. Dzięki temu zachowany zostaje oryginalny master, układy i powiązany motyw, tak aby wygląd pozostał spójny.

**Jak mogę zobaczyć „efektywne” wartości po całym dziedziczeniu i nadpisaniach?**

Użyj widoków „efektywnych” API [/slides/pl/php-java/shape-effective-properties/] dla motywu/koloru/czcionki/efektu. Zwracają one rozwiązane, ostateczne właściwości po zastosowaniu mastera oraz ewentualnych lokalnych nadpisań.