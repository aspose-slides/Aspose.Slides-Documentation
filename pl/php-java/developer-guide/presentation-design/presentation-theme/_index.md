---
title: Zarządzanie motywami prezentacji w PHP
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
- Zewnętrzny motyw
- THMX
- Kolor motywu
- Dodatkowa paleta
- Czcionka motywu
- Styl motywu
- Efekt motywu
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Główne motywy prezentacji w Aspose.Slides dla PHP przy użyciu Java, służące do tworzenia, dostosowywania i konwertowania plików PowerPoint z zachowaniem spójnej identyfikacji wizualnej."
---
## **Wprowadzenie**

Motyw prezentacji definiuje skoordynowany zestaw kolorów, czcionek, stylów tła, wypełnień, linii i efektów. Obiekty świadome motywu odwołują się do tych wspólnych definicji zamiast przechowywać każdą właściwość wizualną jako stałą wartość, dzięki czemu zmiana motywu może jednocześnie zaktualizować wiele obiektów.

W Aspose.Slides motyw na poziomie prezentacji jest dostępny poprzez [Presentation.getMasterTheme](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/). Prezentacja może również zawierać nadpisania motywu na niższych poziomach. Master może nadpisać motyw prezentacji poprzez [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/pl/php-java/aspose.slides/masterthememanager/), natomiast układ lub pojedynczy slajd może nadpisać odziedziczony motyw poprzez [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/pl/php-java/aspose.slides/baseoverridethememanager/). W praktyce efektywny motyw slajdu jest ustalany poprzez łańcuch dziedziczenia: motyw prezentacji, nadpisanie mastera, nadpisanie układu i nadpisanie slajdu.

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

Poniższe sekcje przedstawiają najczęstsze scenariusze pracy z motywem: przeglądanie motywu, zmiana kolorów i czcionek, kopiowanie lub zastosowanie motywu, aktualizacja stylów tła i efektów oraz odczyt wartości efektywnych po rozwiązaniu dziedziczenia i nadpisań.

## **Przeglądanie motywu**

Obiekt [MasterTheme](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mastertheme/) udostępnia schemat kolorów, schemat czcionek i schemat formatów motywu poprzez [MasterTheme.getColorScheme](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mastertheme/) oraz [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mastertheme/). Przeglądanie tych kolekcji przed ich modyfikacją jest szczególnie przydatne, gdy prezentacja pochodzi z zewnętrznego źródła, ponieważ liczba i zawartość wpisów stylów może się różnić.

Poniższy przykład odczytuje główne właściwości motywu i podaje, ile stylów tła, wypełnień, linii i efektów jest przechowywanych w motywie:

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

Jeśli plik używa wielu masterów, nie zakładaj, że każdy slajd ma taki sam efektywny motyw. Przejrzyj master powiązany ze slajdem i użyj przepływu pracy z efektywnym motywem przedstawionego później w tym artykule, gdy mogą występować nadpisania układu lub slajdu.

## **Zmiana kolorów motywu**

Wypełnienia, linie i tekst świadome motywu mogą odwoływać się do logicznego koloru z wyliczenia [SchemeColor](https://reference.aspose.com/slides/pl/php-java/aspose.slides/schemecolor/). Gdy zmienisz odpowiedni wpis w [ColorScheme](https://reference.aspose.com/slides/pl/php-java/aspose.slides/colorscheme/), wszystkie obiekty, które nadal odwołują się do tego koloru motywu, są rozwiązywane względem nowej wartości. Obiekty używające bezpośredniego koloru RGB nie są zmieniane przez aktualizację koloru motywu.

Poniższy kompleksowy przykład tworzy kształt używający `Accent4`, zmienia kolor `Accent4` motywu na czerwony, zapisuje prezentację, otwiera ją ponownie i wypisuje efektywny kolor wypełnienia:

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

Ponieważ prostokąt pozostaje połączony z `Accent4`, jego widoczny kolor staje się czerwony po zmianie motywu. Jeśli zamienisz kolor schematu na bezpośredni kolor w kształcie, późniejsze zmiany `Accent4` nie będą już wpływać na to wypełnienie.

### **Używanie kolorów z dodatkowej palety**

PowerPoint generuje jaśniejsze i ciemniejsze warianty koloru motywu poprzez zastosowanie transformacji koloru. Aspose.Slides udostępnia te transformacje poprzez wyliczenie [ColorTransformOperation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/colortransformoperation/).

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** – Główne kolory motywu.  
**2** – Jaśniejsze i ciemniejsze warianty wygenerowane z głównych kolorów motywu.

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

Warianty te pozostają oparte na kolorze motywu. Jeśli `Accent4` zostanie później zmieniony, przeliczone kolory zostaną ponownie obliczone na podstawie nowej wartości `Accent4`.

### **Mapowanie wartości `SchemeColor` na pozycje `ColorScheme`**

Wyliczenie [SchemeColor](https://reference.aspose.com/slides/pl/php-java/aspose.slides/schemecolor/) używa `Text1`, `Background1`, `Text2` i `Background2`, natomiast [ColorScheme](https://reference.aspose.com/slides/pl/php-java/aspose.slides/colorscheme/) udostępnia te same pozycje motywu jako `Dark1`, `Light1`, `Dark2` i `Light2`. Mapowanie jest stałe:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Są to alternatywne nazwy tych samych pozycji motywu; nie są to wartości dynamicznie konwertowane z jednej formy na drugą.

## **Zmiana czcionek motywu**

Schemat czcionek motywu zawiera zestaw głównych czcionek dla nagłówków oraz zestaw pomocniczych czcionek dla tekstu podstawowego. Metody [FontScheme.getMajor](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontscheme/) i [FontScheme.getMinor](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontscheme/) udostępniają te zestawy.

Identyfikatory czcionek zgodne z PowerPoint można używać w formatowaniu tekstu:

* `+mn-lt` – Czcionka podstawowa łacińska (Minor Latin Font)
* `+mj-lt` – Czcionka nagłówka łacińska (Major Latin Font)
* `+mn-ea` – Czcionka podstawowa wschodnioazjatycka (Minor East Asian Font)
* `+mj-ea` – Czcionka nagłówka wschodnioazjatycka (Major East Asian Font)

Poniższy przykład tworzy jeden nagłówek używający głównej łacińskiej czcionki motywu oraz jedną linię tekstu używającą pomocniczej łacińskiej czcionki motywu. Następnie zmienia czcionki motywu i zapisuje wynik:

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

Nagłówek podąża za czcionką główną, a tekst podstawowy za czcionką pomocniczą. Tekst, który ma wyraźnie określoną nazwę czcionki zamiast identyfikatora motywu, nie zostanie automatycznie zmieniony po zmianie schematu czcionek motywu.

Zbiory czcionek głównych i pomocniczych mogą również zawierać mapowania czcionek dla poszczególnych systemów pisma, takich jak cyrylica, arabski, japoński, gruziński i thaana. Aby przeglądać, dodawać, zastępować lub usuwać te mapowania, zobacz [Script-Specific Theme Fonts](/slides/pl/php-java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Więcej informacji o czcionkach w prezentacji znajdziesz w [PowerPoint Fonts](/slides/pl/php-java/powerpoint-fonts/).
{{% /alert %}}

## **Kopiowanie lub zastosowanie motivu**

Poniższe przepływy pracy rozwiązują różne problemy związane z motywem.

### **Zastosowanie zewnętrznego motywu do slajdów zależnych od mastera**

Użyj [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/pl/php-java/aspose.slides/masterslide/) gdy posiadasz plik motywu PowerPoint (`.thmx`) i chcesz przystrojenić każdy slajd zależny od konkretnego mastera. Wybierz master z kolekcji [Presentation::getMasters](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/), reprezentowanej przez [MasterSlideCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/masterslidecollection/), i przekaż ścieżkę do pliku motywu metodzie.

Metoda wykonuje następujące operacje:

1. Tworzy nowy slajd master na podstawie wybranego mastera.  
1. Zastosowuje zewnętrzny motyw do nowego mastera.  
1. Przypisuje nowy master wszystkim slajdom, które wcześniej zależały od wybranego mastera.  
1. Zwraca nowo utworzony [MasterSlide](https://reference.aspose.com/slides/pl/php-java/aspose.slides/masterslide/).

Poniższy przykład stosuje zewnętrzny motyw do slajdów zależnych od pierwszego mastera i zapisuje prezentację:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $selectedMaster = $presentation->getMasters()->get_Item(0);
    $themedMaster = $selectedMaster->applyExternalThemeToDependingSlides("corporate-theme.thmx");

    echo "Created master: " . java_values($themedMaster->getName()) . PHP_EOL;
    $presentation->save("presentation-with-external-theme.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Nieprawidłowy, uszkodzony lub nieobsługiwany motyw może spowodować [PptxReadException](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pptxreadexception/). Waliduj ścieżki podawane przez użytkowników, obsługuj błędy dostępu do systemu plików i zapisuj prezentację dopiero po pomyślnym zastosowaniu motywu.

Tylko slajdy zależne od wybranego mastera są ponownie przypisane. Slajdy powiązane z innymi masterami zachowują swoje istniejące mastery i motywy. Kolory, czcionki, wypełnienia, linie, tła i efekty świadome motywu są rozwiązywane względem zewnętrznego motywu. Bezpośrednio przypisane kolory, czcionki, wypełnienia i inne wyraźne formatowanie mogą pozostać niezmienione. Nadpisania na poziomie układu i slajdu mogą również mieć pierwszeństwo przed wartościami odziedziczonymi z nowego mastera.

Motyw może odwoływać się do czcionek, które nie są dostępne w środowisku uruchomieniowym. W celu zapewnienia spójnego renderowania i eksportu zainstaluj wymagane czcionki, udostępnij je poprzez [custom font sources](/slides/pl/php-java/custom-font/), lub skonfiguruj [font substitution](/slides/pl/php-java/font-substitution/).

Jest to bezpośredni przepływ pracy na poziomie mastera: metoda przyjmuje ścieżkę do pliku `.thmx` i nie wymaga ręcznego tworzenia nadpisań tematycznych na poziomie slajdu lub układu.

### **Zastosowanie różnych zewnętrznych motywów w prezentacji z wieloma masterami**

Gdy odpowiedni master nie jest znany z góry, pobierz go z reprezentatywnego slajdu przy użyciu [Slide::getLayoutSlide](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slide/) i [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/pl/php-java/aspose.slides/layoutslide/). Przechowaj oryginalne referencje masterów przed zastosowaniem jakichkolwiek motywów, ponieważ każde wywołanie tworzy kolejny master w prezentacji.

Poniższy przykład używa slajdów z dwóch sekcji, aby zlokalizować ich mastery i stosuje inny zewnętrzny motyw do każdej grupy:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("multi-master-presentation.pptx");
try {
    if (java_values($presentation->getSlides()->size()) < 5) {
        echo "The presentation does not contain the expected representative slides." . PHP_EOL;
    } else {
        $firstGroupMaster = $presentation->getSlides()->get_Item(0)->getLayoutSlide()->getMasterSlide();
        $secondGroupMaster = $presentation->getSlides()->get_Item(4)->getLayoutSlide()->getMasterSlide();

        if (java_values($firstGroupMaster->getSlideId()) === java_values($secondGroupMaster->getSlideId())) {
            echo "The representative slides use the same master." . PHP_EOL;
        } else {
            $firstThemedMaster = $firstGroupMaster->applyExternalThemeToDependingSlides("blue-theme.thmx");
            $secondThemedMaster = $secondGroupMaster->applyExternalThemeToDependingSlides("green-theme.thmx");

            echo "First themed master: " . java_values($firstThemedMaster->getName()) . PHP_EOL;
            echo "Second themed master: " . java_values($secondThemedMaster->getName()) . PHP_EOL;
            $presentation->save("multi-master-with-external-themes.pptx", SaveFormat::Pptx);
        }
    }
} finally {
    $presentation->dispose();
}
```

Pierwsze wywołanie wpływa tylko na slajdy zależne od `$firstGroupMaster`, a drugie wywołanie wpływa wyłącznie na slajdy zależne od `$secondGroupMaster`. Slajdy należące do jakiegokolwiek innego mastera nie są przystrojone.

### **Zachowanie źródłowego motywu przy przenoszeniu slajdów**

Jeśli chcesz przenieść slajd do innej prezentacji i zachować jego oryginalny projekt, sklonuj źródłowego mastera do prezentacji docelowej przy użyciu [MasterSlideCollection.addClone](https://reference.aspose.com/slides/pl/php-java/aspose.slides/masterslidecollection/), a następnie sklonuj slajd wraz ze sklonowanym masterem przy użyciu [SlideCollection.addClone](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slidecollection/). To przenosi master, jego układy oraz powiązany motyw razem.

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

Jest to preferowany przepływ, gdy źródłowy slajd ma wyglądać identycznie w miejscu docelowym. Proste klonowanie zawartości na niepowiązany master docelowy może zmienić kolory, czcionki, tła i efekty sterowane przez motyw.

### **Zastosowanie wartości motywu do istniejącego slajdu**

Jeśli docelowy slajd ma pozostać na swoim bieżącym masterze i układzie, zainicjuj nadpisanie na poziomie slajdu na podstawie źródłowego motywu. Metody [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/pl/php-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/pl/php-java/aspose.slides/overridetheme/) i [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/pl/php-java/aspose.slides/overridetheme/) kopiują trzy główne komponenty motywu do nadpisania.

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

To zmienia motyw używany przez ten slajd, nie zmieniając motywu dziedziczonego przez inne slajdy. Aby usunąć lokalne nadpisanie i powrócić do wartości odziedziczonych, wywołaj [OverrideTheme.clear](https://reference.aspose.com/slides/pl/php-java/aspose.slides/overridetheme/).

### **Zastosowanie nadpisania motywu do układu**

Nadpisanie na poziomie układu ma zastosowanie do slajdów używających tego układu, chyba że konkretny slajd posiada własne nadpisanie. Te same metody inicjalizacyjne można używać poprzez [LayoutSlideThemeManager](https://reference.aspose.com/slides/pl/php-java/aspose.slides/layoutslidethememanager/):

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

Używaj motywu na poziomie mastera lub prezentacji, gdy wiele układów i slajdów ma współdzielić tę samą bazową konstrukcję, nadpisania układu, gdy rodzina układów wymaga odmiennego stylu, oraz nadpisania slajdu tylko w prawdziwych wyjątkach. Nadmierne nadpisania na poziomie slajdu utrudniają przewidywanie efektów późniejszych globalnych zmian motywu.

## **Aktualizacja stylów tła motywu**

Wypełnienia tła motywu są przechowywane w [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/pl/php-java/aspose.slides/formatscheme/). PowerPoint może prezentować w interfejsie więcej opcji tła niż liczba definicji wypełnień fizycznie zapisanych w tej kolekcji, ponieważ UI może łączyć wypełnienia motywu z kolorami motywu i innymi odwołaniami stylów.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

Przed użyciem stylu tła przejrzyj przechowywaną kolekcję i bieżącą wartość [Background.getStyleIndex](https://reference.aspose.com/slides/pl/php-java/aspose.slides/background/). Indeks stylu `0` oznacza brak tematycznego wypełnienia; wartości dodatnie są odwołaniami do stylu tła motywu. To różni się od indeksowania samej kolekcji w PHP, gdzie `get_Item(0)` oznacza pierwszy zapisany element. Nie zakładaj, że każda prezentacja zawiera taką samą liczbę stylów wypełnień tła.

Poniższy przykład podaje liczbę dostępnych wypełnień tła, przypisuje odwołanie do tematycznego tła pierwszemu masterowi i zapisuje prezentację:

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

Widoczny rezultat zależy od wpisu motywu odwoływanego przez master oraz od ewentualnych nadpisań tła na poziomie układu lub slajdu. Jeśli slajd używa własnego tła, zmiana samego tła mastera może nie wpłynąć na ten slajd. Użyj [Background.getEffective](https://reference.aspose.com/slides/pl/php-java/aspose.slides/background/) gdy potrzebujesz znać ostateczne tło po zastosowaniu dziedziczenia.

{{% alert color="warning" title="Warning" %}}
Nie traktuj indeksu stylu jako zerowego indeksu kolekcji. Unikaj także twardego kodowania numeru stylu z jednego pliku i zakładania, że będzie miał taki sam wygląd w innym pliku; definicje stylów motywu są specyficzne dla prezentacji.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Informacje o bezpośrednim formatowaniu tła i dziedziczeniu tła znajdziesz w [Presentation Background](/slides/pl/php-java/presentation-background/).
{{% /alert %}}

## **Aktualizacja efektów motywu**

Schemat formatu motywu zawiera oddzielne kolekcje stylów wypełnień, linii i efektów, udostępniane poprzez [FormatScheme.getFillStyles](https://reference.aspose.com/slides/pl/php-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/pl/php-java/aspose.slides/formatscheme/) oraz [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/pl/php-java/aspose.slides/formatscheme/). Typowe motywy Office często zawierają trzy główne wpisy stylów, które wizualnie odpowiadają subtelnym, umiarkowanym i intensywnym formatowaniom, ale kod powinien sprawdzać każdą kolekcję zamiast zakładać stałą liczbę elementów.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

Kiedy uzyskujesz dostęp do tych kolekcji w PHP, indeks kolekcji jest zerowy: `get_Item(0)` jest pierwszym zapisanym stylem, a `get_Item(2)` trzecim. Indeksy referencji stylu kształtu to odrębna koncepcja, udostępniona przez [ShapeStyle](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapestyle/). Modyfikacja stylu motywu wpływa na kształty, które odwołują się do tego stylu; kształty z bezpośrednim formatowaniem mogą pozostać niezmienione.

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

Dla kształtów odwołujących się do tych slotów pierwszy styl linii motywu staje się czerwony, trzeci styl wypełnienia motywu staje się jednolitym zielonym lasem, a trzeci styl efektu zyskuje zewnętrzny cień o odległości 10 punktów. Dokładny efekt wizualny nadal zależy od tego, które sloty stylu są odwoływane przez poszczególne kształty i czy bezpośrednie formatowanie nie nadpisuje motywu.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **Odczyt efektywnych wartości motywu**

Surowe obiekty motywu pokazują, co jest zdefiniowane na danym poziomie. Efektywne wartości mówią, czego rzeczywiście używa slajd lub kształt po rozwiązaniu dziedziczenia i lokalnych nadpisań. Dla slajdu wywołaj [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/pl/php-java/aspose.slides/baseoverridethememanager/). Dla tła użyj [Background.getEffective](https://reference.aspose.com/slides/pl/php-java/aspose.slides/background/), a dla wypełnienia [FillFormat.getEffective](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fillformat/).

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

Używaj danych efektywnych do diagnostyki renderowania, walidacji i porównań. Jeśli przeglądasz tylko [Presentation.getMasterTheme](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/), możesz przeoczyć nadpisania mastera, układu, slajdu lub kształtu, które zmieniają ostateczny wygląd.

## **FAQ**

**Czy zastosowanie zewnętrznego motywu wpływa na każdy slajd w prezentacji?**

Nie. [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/pl/php-java/aspose.slides/masterslide/) przypisuje tylko slajdy zależne od wybranego mastera. Slajdy używające innych masterów zachowują swoje istniejące motywy.

**Czy mogę zastosować motyw do pojedynczego slajdu bez zmiany mastera?**

Tak. Użyj [SlideThemeManager](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slidethememanager/) slajdu i zainicjuj jego nadpisanie motywu. Zmiana pozostaje lokalna dla tego slajdu; inne slajdy nadal będą dziedziczyć swoje istniejące motywy.

**Jaki jest najbezpieczniejszy sposób przeniesienia motywu z jednej prezentacji do drugiej?**

Przy przenoszeniu slajdu i zachowaniu jego pierwotnego wyglądu, sklonuj źródłowego mastera do docelowej prezentacji i sklonuj slajd z tym masterem, używając [MasterSlideCollection.addClone](https://reference.aspose.com/slides/pl/php-java/aspose.slides/masterslidecollection/) oraz [SlideCollection.addClone](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slidecollection/). To utrzymuje master, układy i motyw razem.

**Jak mogę zobaczyć efektywne wartości po dziedziczeniu i nadpisaniach?**

Użyj [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/pl/php-java/aspose.slides/baseoverridethememanager/) dla slajdu lub układu oraz odpowiednich metod zwracających dane efektywne dla obiektów formatowania, takich jak [Background.getEffective](https://reference.aspose.com/slides/pl/php-java/aspose.slides/background/) i [FillFormat.getEffective](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fillformat/). Te API zwracają rozwiązywane wartości po zastosowaniu dziedziczenia i nadpisań.