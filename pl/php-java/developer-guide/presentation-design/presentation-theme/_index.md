---
title: Zarządzanie motywami prezentacji w PHP
linktitle: Motyw prezentacji
type: docs
weight: 10
url: /pl/php-java/presentation-theme/
keywords:
- motyw PowerPoint
- motyw prezentacji
- motyw slajdu
- ustaw motyw
- zmień motyw
- zarządzaj motywem
- kolor motywu
- dodatkowa paleta
- czcionka motywu
- styl motywu
- efekt motywu
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Główne motywy prezentacji w Aspose.Slides dla PHP poprzez Java, umożliwiające tworzenie, dostosowywanie i konwertowanie plików PowerPoint z zachowaniem spójnej identyfikacji wizualnej."
---
## **Wprowadzenie**

Motyw prezentacji definiuje skoordynowany zestaw kolorów, czcionek, stylów tła, wypełnień, linii i efektów. Obiekty uwzględniające motyw odwołują się do tych współdzielonych definicji zamiast przechowywać każdą właściwość wizualną jako stałą wartość, dzięki czemu zmiana motywu może jednocześnie zaktualizować wiele obiektów.

W Aspose.Slides motyw na poziomie prezentacji jest dostępny przez [Presentation.getMasterTheme](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/). Prezentacja może również zawierać nadpisania motywu na niższych poziomach. Master może nadpisać motyw prezentacji przez [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/pl/php-java/aspose.slides/masterthememanager/), natomiast układ lub pojedynczy slajd może nadpisać odziedziczony motyw przez [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/pl/php-java/aspose.slides/baseoverridethememanager/). W praktyce efektywny motyw dla slajdu jest określany poprzez łańcuch dziedziczenia: motyw prezentacji, nadpisanie mastera, nadpisanie układu i nadpisanie slajdu.

![Komponenty motywu: kolory, czcionki, style tła i efekty](theme-constituents.png)

Poniższe sekcje prezentują najczęstsze scenariusze pracy z motywem: sprawdzenie motywu, zmiana kolorów i czcionek, kopiowanie lub zastosowanie motywu, aktualizacja stylów tła i efektów oraz odczyt efektywnych wartości po rozwiązaniu dziedziczenia i nadpisań.

## **Sprawdź motyw**

Obiekt [MasterTheme](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mastertheme/) udostępnia schemat kolorów, schemat czcionek i schemat formatów motywu poprzez [MasterTheme.getColorScheme](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mastertheme/) i [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mastertheme/). Inspekcja tych kolekcji przed ich zmianą jest szczególnie przydatna, gdy prezentacja pochodzi ze źródła zewnętrznego, ponieważ liczba i zawartość wpisów stylów może się różnić.

Poniższy przykład odczytuje podstawowe właściwości motywu i informuje, ile stylów tła, wypełnień, linii i efektów jest przechowywanych w motywie:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $theme = $presentation->getMasterTheme();
    echo "Theme name: " . $theme->getName() . PHP_EOL;
    echo "Accent 1: " . $theme->getColorScheme()->getAccent1()->getColor() . PHP_EOL;
    echo "Major Latin font: " . $theme->getFontScheme()->getMajor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Minor Latin font: " . $theme->getFontScheme()->getMinor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Background fill styles: " . java_values($theme->getFormatScheme()->getBackgroundFillStyles()->size()) . PHP_EOL;
    echo "Fill styles: " . java_values($theme->getFormatScheme()->getFillStyles()->size()) . PHP_EOL;
    echo "Line styles: " . java_values($theme->getFormatScheme()->getLineStyles()->size()) . PHP_EOL;
    echo "Effect styles: " . java_values($theme->getFormatScheme()->getEffectStyles()->size()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Jeśli plik używa wielu masterów, nie zakładaj, że każdy slajd ma taki sam efektywny motyw. Sprawdź master powiązany ze slajdem i użyj workflowu efektywnego motywu pokazanego dalej w tym artykule, gdy mogą istnieć nadpisania układu lub slajdu.

## **Zmień kolory motywu**

Wypełnienia, linie i tekst świadome motywu mogą odwoływać się do logicznego koloru z wyliczenia [SchemeColor](https://reference.aspose.com/slides/pl/php-java/aspose.slides/schemecolor/). Gdy zmienisz odpowiadający wpis w [ColorScheme](https://reference.aspose.com/slides/pl/php-java/aspose.slides/colorscheme/), wszystkie obiekty nadal odwołujące się do tego koloru motywu zostaną zaktualizowane do nowej wartości. Obiekty używające bezpośredniego koloru RGB nie zostaną zmienione przez aktualizację koloru motywu.

Poniższy przykład end‑to‑end tworzy kształt używający `Accent4`, zmienia kolor `Accent4` motywu na czerwony, zapisuje prezentację, otwiera ją ponownie i wypisuje efektywny kolor wypełnienia:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SchemeColor;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $presentation->getMasterTheme()->getColorScheme()->getAccent4()->setColor(java("java.awt.Color")->RED);
    $presentation->save("theme-color.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$savedPresentation = new Presentation("theme-color.pptx");
try {
    $savedSlide = $savedPresentation->getSlides()->get_Item(0);
    $savedShape = $savedSlide->getShapes()->get_Item(0);
    $effectiveColor = $savedShape->getFillFormat()->getEffective()->getSolidFillColor();
    echo sprintf("Effective fill color: A=%d, R=%d, G=%d, B=%d", java_values($effectiveColor->getAlpha()), java_values($effectiveColor->getRed()), java_values($effectiveColor->getGreen()), java_values($effectiveColor->getBlue())) . PHP_EOL;
} finally {
    $savedPresentation->dispose();
}
```

Ponieważ prostokąt pozostaje powiązany z `Accent4`, jego widoczny kolor staje się czerwony po zmianie motywu. Jeśli zamienisz kolor schematu na bezpośredni kolor w kształcie, późniejsze zmiany `Accent4` nie będą już wpływać na to wypełnienie.

### **Użyj kolorów z dodatkowej palety**

PowerPoint generuje jaśniejsze i ciemniejsze warianty z koloru motywu, stosując transformacje kolorów. Aspose.Slides udostępnia te transformacje poprzez wyliczenie [ColorTransformOperation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/colortransformoperation/).

![Główne kolory motywu oraz jaśniejsze i ciemniejsze kolory wygenerowane z dodatkowej palety](additional-palette-colors.png)

**1** – Główne kolory motywu.  
**2** – Jaśniejsze i ciemniejsze warianty pochodzące od głównych kolorów motywu.

Poniższy przykład tworzy sześć prostokątów opartych na `Accent4`, stosuje transformacje luminancji do pięciu z nich i zapisuje wynik:

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SchemeColor;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 50, 50);
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);

    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 50, 50);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.2);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.8);

    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 50, 50);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.6);

    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 50, 50);
    $shape4->getFillFormat()->setFillType(FillType::Solid);
    $shape4->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.6);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.4);

    $shape5 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 250, 50, 50);
    $shape5->getFillFormat()->setFillType(FillType::Solid);
    $shape5->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape5->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.75);

    $shape6 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 50, 50);
    $shape6->getFillFormat()->setFillType(FillType::Solid);
    $shape6->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape6->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.5);

    $presentation->save("theme-color-palette.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Te warianty pozostają oparte na kolorze motywu. Jeśli `Accent4` zmieni się później, przeliczone kolory zostaną ponownie wyliczone z nowej wartości `Accent4`.

### **Mapuj wartości `SchemeColor` na sloty `ColorScheme`**

Wyliczenie [SchemeColor](https://reference.aspose.com/slides/pl/php-java/aspose.slides/schemecolor/) używa `Text1`, `Background1`, `Text2` i `Background2`, podczas gdy [ColorScheme](https://reference.aspose.com/slides/pl/php-java/aspose.slides/colorscheme/) udostępnia te same sloty motywu jako `Dark1`, `Light1`, `Dark2` i `Light2`. Mapowanie jest stałe:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Są to alternatywne nazwy tych samych slotów motywu; nie są to wartości dynamicznie konwertowane z jednej formy na drugą.

## **Zmień czcionki motywu**

Schemat czcionek motywu zawiera zestaw głównych czcionek dla nagłówków i zestaw pobocznych czcionek dla tekstu podstawowego. Metody [FontScheme.getMajor](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontscheme/) i [FontScheme.getMinor](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontscheme/) udostępniają te zestawy.

Identyfikatory czcionek motywu zgodne z PowerPoint mogą być używane w formatowaniu tekstu:

* `+mn-lt` – Czcionka tekstu podstawowego łacińska (Minor Latin Font)
* `+mj-lt` – Czcionka nagłówka łacińska (Major Latin Font)
* `+mn-ea` – Czcionka tekstu podstawowego wschodnioazjatycka (Minor East Asian Font)
* `+mj-ea` – Czcionka nagłówka wschodnioazjatycka (Major East Asian Font)

Poniższy przykład tworzy jeden nagłówek używający głównej łacińskiej czcionki motywu oraz jedną linię tekstu podstawowego używającą pobocznej łacińskiej czcionki motywu. Następnie zmienia czcionki motywu i zapisuje wynik:

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $heading = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 500, 60);
    $heading->getTextFrame()->setText("Theme heading");
    $heading->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLatinFont(new FontData("+mj-lt"));

    $body = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 120, 500, 60);
    $body->getTextFrame()->setText("Theme body text");
    $body->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));

    $presentation->getMasterTheme()->getFontScheme()->getMajor()->setLatinFont(new FontData("Aptos Display"));
    $presentation->getMasterTheme()->getFontScheme()->getMinor()->setLatinFont(new FontData("Arial"));
    $presentation->save("theme-fonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Nagłówek podąża za czcionką główną, a tekst podstawowy podąża za czcionką poboczną. Tekst, który ma explicite określoną nazwę czcionki zamiast identyfikatora motywu, nie zostanie automatycznie zmieniony, gdy schemat czcionek motywu ulegnie zmianie.

{{% alert color="info" title="Tip" %}}
Aby uzyskać więcej informacji o czcionkach w prezentacjach, zobacz [PowerPoint Fonts](/slides/pl/php-java/powerpoint-fonts/).
{{% /alert %}}

## **Kopiuj lub zastosuj motyw**

Istnieją dwa typowe workflowy, które rozwiązują różne problemy.

### **Zachowaj motyw źródłowy przy przenoszeniu slajdów**

Jeśli chcesz przenieść slajd do innej prezentacji i zachować jego pierwotny wygląd, sklonuj źródłowy master do docelowej prezentacji przy użyciu [MasterSlideCollection.addClone](https://reference.aspose.com/slides/pl/php-java/aspose.slides/masterslidecollection/), a następnie sklonuj slajd przy użyciu [SlideCollection.addClone](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slidecollection/) i sklonowanego mastera. Dzięki temu master, jego układy i powiązany motyw zostają przeniesione razem.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $sourceSlide = $source->getSlides()->get_Item(0);
        $sourceMaster = $sourceSlide->getLayoutSlide()->getMasterSlide();
        $clonedMaster = $target->getMasters()->addClone($sourceMaster);
        $target->getSlides()->addClone($sourceSlide, $clonedMaster, true);
        $target->save("theme-preserved.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

Jest to preferowany workflow, gdy źródłowy slajd musi wyglądać tak samo w miejscu docelowym. Proste kopiowanie zawartości na niepowiązany master docelowy może zmienić kolory, czcionki, tła i efekty sterowane przez motyw.

### **Zastosuj wartości motywu do istniejącego slajdu**

Jeśli docelowy slajd musi pozostać na bieżącym masterze i układzie, zainicjuj nadpisanie na poziomie slajdu z motywu źródłowego. Metody [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/pl/php-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/pl/php-java/aspose.slides/overridetheme/) i [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/pl/php-java/aspose.slides/overridetheme/) kopiują trzy główne komponenty motywu do nadpisania.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $targetSlide = $target->getSlides()->get_Item(0);
        $overrideTheme = $targetSlide->getThemeManager()->getOverrideTheme();
        $overrideTheme->initColorSchemeFrom($source->getMasterTheme()->getColorScheme());
        $overrideTheme->initFontSchemeFrom($source->getMasterTheme()->getFontScheme());
        $overrideTheme->initFormatSchemeFrom($source->getMasterTheme()->getFormatScheme());
        $target->save("theme-applied-to-slide.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

Zmienia to motyw używany przez ten slajd, nie zmieniając motywu dziedziczonego przez inne slajdy. Aby usunąć lokalne nadpisanie i powrócić do wartości dziedziczonych, wywołaj [OverrideTheme.clear](https://reference.aspose.com/slides/pl/php-java/aspose.slides/overridetheme/).

### **Zastosuj nadpisanie motywu do układu**

Nadpisanie na poziomie układu dotyczy slajdów używających tego układu, chyba że konkretny slajd ma własne nadpisanie. Te same metody inicjalizacji można użyć przez [LayoutSlideThemeManager](https://reference.aspose.com/slides/pl/php-java/aspose.slides/layoutslidethememanager/):

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $targetSlide = $target->getSlides()->get_Item(0);
        $overrideTheme = $targetSlide->getLayoutSlide()->getThemeManager()->getOverrideTheme();
        $overrideTheme->initColorSchemeFrom($source->getMasterTheme()->getColorScheme());
        $overrideTheme->initFontSchemeFrom($source->getMasterTheme()->getFontScheme());
        $overrideTheme->initFormatSchemeFrom($source->getMasterTheme()->getFormatScheme());
        $target->save("theme-applied-to-layout.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

Użyj motywu na poziomie mastera lub prezentacji, gdy wiele układów i slajdów ma współdzielić ten sam podstawowy projekt, nadpisania układu, gdy jedna rodzina układów wymaga innego stylu, oraz nadpisania slajdu tylko w prawdziwych wyjątkach. Nadmierne nadpisania na poziomie slajdu utrudniają późniejsze globalne zmiany motywu.

## **Zaktualizuj style tła motywu**

Wypełnienia tła motywu są przechowywane w [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/pl/php-java/aspose.slides/formatscheme/). PowerPoint może prezentować więcej opcji tła w interfejsie niż liczba definicji wypełnień faktycznie zapisanych w tej kolekcji, ponieważ UI może łączyć wypełnienia motywu z kolorami motywu i innymi odniesieniami stylów.

![Galeria stylów tła PowerPoint dla motywu prezentacji](presentation-design_8.png)

Przed użyciem stylu tła, sprawdź przechowywaną kolekcję i bieżący [Background.getStyleIndex](https://reference.aspose.com/slides/pl/php-java/aspose.slides/background/). Indeks stylu `0` oznacza brak wypełnienia motywu; dodatnie wartości są odniesieniami do stylu tła motywu. To różni się od indeksowania kolekcji PHP bezpośrednio, gdzie `get_Item(0)` oznacza pierwszy zapisany element. Nie zakładaj, że każda prezentacja zawiera taką samą liczbę stylów wypełnień tła.

Poniższy przykład zgłasza liczbę dostępnych wypełnień tła, przypisuje odniesienie do motywu tła pierwszemu masterowi i zapisuje prezentację:

```php
use aspose\slides\BackgroundType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $backgroundStyleCount = java_values($presentation->getMasterTheme()->getFormatScheme()->getBackgroundFillStyles()->size());
    echo "Background fill styles: " . $backgroundStyleCount . PHP_EOL;
    if ($backgroundStyleCount === 0) {
        throw new RuntimeException("The presentation theme does not contain background fill styles.");
    }

    $masterSlide = $presentation->getMasters()->get_Item(0);
    $masterSlide->getBackground()->setType(BackgroundType::Themed);
    $masterSlide->getBackground()->setStyleIndex(1);
    $presentation->save("theme-background.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Widoczny wynik zależy od wpisu motywu, do którego odnosi się master, oraz od wszelkich nadpisań tła na poziomie układu lub slajdu. Jeśli slajd używa własnego tła, zmiana jedynie tła mastera może nie wpłynąć na ten slajd. Użyj [Background.getEffective](https://reference.aspose.com/slides/pl/php-java/aspose.slides/background/) gdy potrzebujesz znać ostateczne tło po zastosowaniu dziedziczenia.

{{% alert color="warning" title="Warning" %}}
Nie traktuj indeksu stylu jako indeksu zero‑bazowego kolekcji. Unikaj także twardego kodowania numeru stylu z jednego pliku i zakładania, że będzie miał taki sam wygląd w innym pliku; definicje stylów motywu są specyficzne dla prezentacji.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
W sprawach bezpośredniego formatowania tła i dziedziczenia tła zobacz [Presentation Background](/slides/pl/php-java/presentation-background/).
{{% /alert %}}

## **Zaktualizuj efekty motywu**

Schemat formatów motywu zawiera oddzielne kolekcje stylów wypełnień, linii i efektów, udostępniane przez [FormatScheme.getFillStyles](https://reference.aspose.com/slides/pl/php-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/pl/php-java/aspose.slides/formatscheme/) i [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/pl/php-java/aspose.slides/formatscheme/). Typowe motywy Office często zawierają trzy główne wpisy stylów, które wizualnie odpowiadają subtelnemu, umiarkowanemu i intensywnemu formatowaniu, ale kod powinien sprawdzać każdą kolekcję zamiast zakładać stałą liczbę.

![Subtelne, umiarkowane i intensywne efekty motywu zastosowane do tego samego kształtu](presentation-design_10.png)

Podczas dostępu do tych kolekcji w PHP indeks kolekcji jest zero‑bazowy: `get_Item(0)` to pierwszy zapisany styl, a `get_Item(2)` to trzeci. Indeksy referencji stylu kształtu to odrębny koncept, udostępniany przez [ShapeStyle](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapestyle/). Modyfikacja stylu motywu wpływa na kształty, które odwołują się do tego stylu; kształty z bezpośrednim formatowaniem mogą pozostać niezmienione.

Poniższy przykład sprawdza, czy wymagane wpisy stylów istnieją, zmienia pierwszy styl linii, zmienia trzeci styl wypełnienia, włącza zewnętrzny cień w trzecim stylu efektu i zapisuje wynik:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    $formatScheme = $presentation->getMasterTheme()->getFormatScheme();
    if (java_values($formatScheme->getLineStyles()->size()) < 1 || java_values($formatScheme->getFillStyles()->size()) < 3 || java_values($formatScheme->getEffectStyles()->size()) < 3) {
        throw new RuntimeException("The theme does not contain the style entries required by this example.");
    }

    $formatScheme->getLineStyles()->get_Item(0)->getFillFormat()->setFillType(FillType::Solid);
    $formatScheme->getLineStyles()->get_Item(0)->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $formatScheme->getFillStyles()->get_Item(2)->setFillType(FillType::Solid);
    $formatScheme->getFillStyles()->get_Item(2)->getSolidFillColor()->setColor(new Java("java.awt.Color", 34, 139, 34));
    $effectFormat = $formatScheme->getEffectStyles()->get_Item(2)->getEffectFormat();
    $effectFormat->enableOuterShadowEffect();
    $effectFormat->getOuterShadowEffect()->setDistance(10.0);
    $presentation->save("theme-effects.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Dla kształtów odwołujących się do tych slotów, pierwszy styl linii motywu staje się czerwony, trzeci styl wypełnienia motywu staje się jednolitym zielonym lasem, a trzeci styl efektu otrzymuje zewnętrzny cień z odległością 10 punktów. Dokładny wynik wizualny nadal zależy od tego, które sloty stylów każdy kształt odwołuje oraz czy bezpośrednie formatowanie nie nadpisuje motywu.

![Style efektów motywu po zmianie ustawień linii, wypełnienia i cienia](presentation-design_11.png)

## **Odczytaj efektywne wartości motywu**

Surowe obiekty motywu informują, co jest zdefiniowane na danym poziomie. Efektywne wartości mówią, co slajd lub kształt faktycznie używa po rozwiązaniu dziedziczenia i lokalnych nadpisań. Dla slajdu wywołaj [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/pl/php-java/aspose.slides/baseoverridethememanager/). Dla tła użyj [Background.getEffective](https://reference.aspose.com/slides/pl/php-java/aspose.slides/background/), a dla wypełnienia [FillFormat.getEffective](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fillformat/).

Poniższy przykład odczytuje efektywny motyw, tło i pierwsze wypełnienie kształtu ze slajdu:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $effectiveTheme = $slide->getThemeManager()->createThemeEffective();
    $effectiveBackground = $slide->getBackground()->getEffective();
    echo "Effective major Latin font: " . $effectiveTheme->getFontScheme()->getMajor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Effective minor Latin font: " . $effectiveTheme->getFontScheme()->getMinor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Effective background fill type: " . java_values($effectiveBackground->getFillFormat()->getFillType()) . PHP_EOL;
    if (java_values($slide->getShapes()->size()) > 0) {
        $effectiveFill = $slide->getShapes()->get_Item(0)->getFillFormat()->getEffective();
        echo "First shape effective fill type: " . java_values($effectiveFill->getFillType()) . PHP_EOL;
        if (java_values($effectiveFill->getFillType()) == FillType::Solid) {
            $effectiveColor = $effectiveFill->getSolidFillColor();
            echo sprintf("First shape effective fill color: A=%d, R=%d, G=%d, B=%d", java_values($effectiveColor->getAlpha()), java_values($effectiveColor->getRed()), java_values($effectiveColor->getGreen()), java_values($effectiveColor->getBlue())) . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

Używaj danych efektywnych do diagnostyki renderowania, walidacji i porównań. Jeśli sprawdzasz jedynie [Presentation.getMasterTheme](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/), możesz przegapić nadpisanie mastera, układu, slajdu lub kształtu, które zmienia ostateczny wygląd.

## **FAQ**

**Czy mogę zastosować motyw do pojedynczego slajdu bez zmiany mastera?**

Tak. Użyj [SlideThemeManager](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slidethememanager/) slajdu i zainicjuj jego nadpisanie motywu. Zmiana pozostaje lokalna dla tego slajdu; inne slajdy wciąż dziedziczą istniejące motywy.

**Jaki jest najbezpieczniejszy sposób przeniesienia motywu z jednej prezentacji do drugiej?**

Podczas przenoszenia slajdu i zachowania jego pierwotnego wyglądu, sklonuj źródłowy master do docelowej prezentacji i sklonuj slajd z tym masterem, używając [MasterSlideCollection.addClone](https://reference.aspose.com/slides/pl/php-java/aspose.slides/masterslidecollection/) i [SlideCollection.addClone](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slidecollection/). Dzięki temu master, układy i motyw zostają przeniesione razem.

**Jak mogę zobaczyć efektywne wartości po dziedziczeniu i nadpisaniach?**

Użyj [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/pl/php-java/aspose.slides/baseoverridethememanager/) dla motywu slajdu lub układu oraz odpowiednich metod danych efektywnych dla obiektów formatowania, takich jak [Background.getEffective](https://reference.aspose.com/slides/pl/php-java/aspose.slides/background/) i [FillFormat.getEffective](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fillformat/). Te API zwracają wartości po zastosowaniu dziedziczenia i nadpisań.