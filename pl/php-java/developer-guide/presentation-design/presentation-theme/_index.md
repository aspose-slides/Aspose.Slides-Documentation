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
description: "Główne motywy prezentacji w Aspose.Slides dla PHP poprzez Java, umożliwiające tworzenie, dostosowywanie i konwertowanie plików PowerPoint z zachowaniem spójnej identyfikacji wizualnej."
---
## **Wprowadzenie**

Motyw prezentacji definiuje skoordynowany zestaw kolorów, czcionek, stylów tła, wypełnień, linii i efektów. Obiekty świadome motywu odwołują się do tych współdzielonych definicji zamiast przechowywać każdą właściwość wizualną jako stałą wartość, dzięki czemu zmiana motywu może jednocześnie zaktualizować wiele obiektów.

W Aspose.Slides motyw na poziomie prezentacji jest dostępny poprzez [Presentation::getMasterTheme](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/). Prezentacja może także zawierać nadpisania motywu na niższych poziomach. Master może nadpisać motyw prezentacji za pomocą [MasterThemeManager::getOverrideTheme](https://reference.aspose.com/slides/php-java/aspose.slides/masterthememanager/), natomiast układ lub pojedynczy slajd może nadpisać odziedziczony motyw za pomocą [BaseOverrideThemeManager::getOverrideTheme](https://reference.aspose.com/slides/php-java/aspose.slides/baseoverridethememanager/). W praktyce skuteczny motyw dla slajdu jest rozwiązywany poprzez ten łańcuch dziedziczenia: motyw prezentacji, nadpisanie master, nadpisanie układu i nadpisanie slajdu.

![Komponenty motywu: kolory, czcionki, style tła i efekty](theme-constituents.png)

Poniższe sekcje pokazują najczęstsze przepływy pracy z motywem: sprawdzanie motywu, zmiana kolorów i czcionek, kopiowanie lub zastosowanie motywu, aktualizacja stylów tła i efektów oraz odczyt skutecznych wartości po rozwiązaniu dziedziczenia i nadpisań.

## **Sprawdzanie motywu**

Obiekt [MasterTheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/) udostępnia schemat kolorów, schemat czcionek i schemat formatów motywu za pomocą [MasterTheme::getColorScheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/), [MasterTheme::getFontScheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/) oraz [MasterTheme::getFormatScheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/). Sprawdzanie tych kolekcji przed ich zmianą jest szczególnie przydatne, gdy prezentacja pochodzi z zewnętrznego źródła, ponieważ liczba i zawartość wpisów stylów może się różnić.

Poniższy przykład odczytuje podstawowe właściwości motywu i podaje, ile stylów tła, wypełnienia, linii i efektów jest przechowywanych w motywie:

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

Jeśli plik używa wielu masterów, nie zakładaj, że każdy slajd ma ten sam skuteczny motyw. Sprawdź master powiązany ze slajdem i użyj przepływu pracy ze skutecznym motywem pokazanym później w tym artykule, gdy mogą występować nadpisania układu lub slajdu.

## **Zmiana kolorów motywu**

Wypełnienia, linie i tekst świadome motywu mogą odwoływać się do logicznego koloru z wyliczenia [SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/schemecolor/). Gdy zmienisz odpowiedni wpis w [ColorScheme](https://reference.aspose.com/slides/php-java/aspose.slides/colorscheme/), wszystkie obiekty, które nadal odwołują się do tego koloru motywu, zostaną rozwiązane względem nowej wartości. Obiekty używające bezpośredniego koloru RGB nie zostaną zmienione przez aktualizację koloru motywu.

Poniższy kompleksowy przykład tworzy kształt używający `Accent4`, zmienia kolor motywu `Accent4` na czerwony, zapisuje prezentację, otwiera ją ponownie i wypisuje skuteczny kolor wypełnienia:

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

### **Używanie kolorów z dodatkowej palety**

PowerPoint generuje jaśniejsze i ciemniejsze warianty z koloru motywu poprzez przekształcenia kolorów. Aspose.Slides udostępnia te przekształcenia za pomocą wyliczenia [ColorTransformOperation](https://reference.aspose.com/slides/php-java/aspose.slides/colortransformoperation/).

![Główne kolory motywu oraz jaśniejsze i ciemniejsze kolory wygenerowane z dodatkowej palety](additional-palette-colors.png)

**1** – Główne kolory motywu.  
**2** – Jaśniejsze i ciemniejsze warianty pochodzące od głównych kolorów motywu.

Poniższy przykład tworzy sześć prostokątów opartych na `Accent4`, stosuje przekształcenia luminancji do pięciu z nich i zapisuje wynik:

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

Warianty te pozostają oparte na kolorze motywu. Jeśli później `Accent4` zostanie zmieniony, przekształcone kolory zostaną przeliczone na podstawie nowej wartości `Accent4`.

### **Mapowanie wartości `SchemeColor` na sloty `ColorScheme`**

Wyliczenie [SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/schemecolor/) używa `Text1`, `Background1`, `Text2` i `Background2`, podczas gdy [ColorScheme](https://reference.aspose.com/slides/php-java/aspose.slides/colorscheme/) udostępnia te same sloty motywu jako `Dark1`, `Light1`, `Dark2` i `Light2`. Mapowanie jest stałe:

* `Text1` = `Dark1`  
* `Background1` = `Light1`  
* `Text2` = `Dark2`  
* `Background2` = `Light2`

Są to alternatywne nazwy tych samych slotów motywu; nie są to wartości dynamicznie konwertowane z jednej formy na drugą.

## **Zmiana czcionek motywu**

Schemat czcionek motywu zawiera zestaw głównych czcionek dla nagłówków i zestaw pobocznych czcionek dla treści. Metody [FontScheme::getMajor](https://reference.aspose.com/slides/php-java/aspose.slides/fontscheme/) i [FontScheme::getMinor](https://reference.aspose.com/slides/php-java/aspose.slides/fontscheme/) udostępniają te zestawy.

Identyfikatory czcionek kompatybilnych z PowerPoint mogą być używane w formatowaniu tekstu:

* `+mn-lt` – Czcionka tekstu podstawowego Latin (Minor Latin Font)  
* `+mj-lt` – Czcionka nagłówka Latin (Major Latin Font)  
* `+mn-ea` – Czcionka tekstu podstawowego East Asian (Minor East Asian Font)  
* `+mj-ea` – Czcionka nagłówka East Asian (Major East Asian Font)  
* `+mn-cs` – Czcionka tekstu podstawowego Complex Script (Minor Complex Script Font)  
* `+mj-cs` – Czcionka nagłówka Complex Script (Major Complex Script Font)

Poniższy przykład tworzy jeden nagłówek używający głównej czcionki Latin i jedną linię treści używającą pobocznej czcionki Latin. Następnie zmienia czcionki motywu i zapisuje wynik:

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

Nagłówek podąża za główną czcionką, a treść podąża za czcionką poboczną. Tekst z explicite określoną nazwą czcionki zamiast identyfikatora motywu nie przesiąknie automatycznie przy zmianie schematu czcionek motywu.

Zbiory głównych i pobocznych czcionek mogą także zawierać mapowania czcionek dla poszczególnych systemów pisma, takich jak cyrylica, arabski, japoński, gruziński i thaana. Aby je przeglądać, dodawać, zamieniać lub usuwać, zobacz [Script-Specific Theme Fonts](/slides/pl/php-java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Więcej informacji o czcionkach w prezentacji znajdziesz w [PowerPoint Fonts](/slides/pl/php-java/powerpoint-fonts/).
{{% /alert %}}

### **Rozwiązywanie odwołań do czcionek motywu**

Podczas sprawdzania tekstu, [FontData::getFontName](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/) może zwrócić odwołanie do motywu, takie jak `+mn-lt`, zamiast nazwy rodziny czcionek. Wywołaj [FontData::getFontName](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/) z odpowiednimi danymi skutecznego motywu, aby rozwiązać to odwołanie. Prefiksy `+mj` i `+mn` wybierają zestawy czcionek głównych i pobocznych; przyrostki `-lt`, `-ea` i `-cs` wybierają odpowiednio czcionki Latin, East Asian i Complex Script.

Uzyskaj skuteczny motyw poprzez [Slide::createThemeEffective](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) na obiekcie, którego motyw ma zastosowanie do sprawdzanego tekstu. Dla zwykłego tekstu na slajdzie wywołaj tę metodę na slajdzie, aby kontekst zawierał odziedziczony motyw i lokalne nadpisania. Przy sprawdzaniu układu lub samego mastera użyj jego własnego skutecznego motywu. Nie zakładaj, że motyw pierwszego mastera ma zastosowanie do każdego slajdu.

Poniższy przykład tworzy fragment tekstu, który explicite odwołuje się do czcionki pobocznej Latin. Inicjuje schemat czcionek slajdu poprzez [OverrideTheme::initFontSchemeFromInherited](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/) i ustawia główne i poboczne rodziny Latin na `Arial` i `Calibri`, co czyni wynik powtarzalnym bez pliku wejściowego.

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $theme = $slide->getThemeManager()->getOverrideTheme();
    $theme->initFontSchemeFromInherited();
    $theme->getFontScheme()->getMajor()->setLatinFont(new FontData("Arial"));
    $theme->getFontScheme()->getMinor()->setLatinFont(new FontData("Calibri"));

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 60);
    $shape->getTextFrame()->setText("Text using the minor theme font");

    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));

    $font = $portion->getPortionFormat()->getLatinFont();
    $effectiveTheme = $slide->createThemeEffective();
    echo $font->getFontName() . " -> " . $font->getFontName($effectiveTheme) . PHP_EOL;

    $explicitFont = new FontData("Verdana");
    echo $explicitFont->getFontName() . " -> " . $explicitFont->getFontName($effectiveTheme) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Wynik to `+mn-lt -> Calibri` oraz `Verdana -> Verdana`. Przechowywane odwołanie pozostaje niezmienione, podczas gdy explicite podana rodzina czcionki jest zwracana tak, jak jest. Gdyby fragment używał `+mj-lt`, rozwiązałby się do `Arial` w tym motywie.

Rozwiązywanie odwołania do motywu identyfikuje rodzinę czcionki określoną przez motyw. Nie sprawdza dostępności czcionki ani nie określa pliku czcionki ostatecznie używanego po podstawieniu lub fallbacku glifów podczas renderowania. Zobacz [Font Selection Sequence](/slides/pl/php-java/font-selection-sequence/) i [Font Substitution](/slides/pl/php-java/font-substitution/) dla tych oddzielnych kroków.

## **Kopiowanie lub zastosowanie motywu**

Poniższe przepływy rozwiązują różne problemy związane z motywem.

### **Zastosowanie zewnętrznego motywu do slajdów zależnych od mastera**

Użyj [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) gdy masz plik motywu PowerPoint (`.thmx`) i chcesz przestyliować każdy slajd zależny od konkretnego mastera. Wybierz master z kolekcji [Presentation::getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), reprezentowanej przez [MasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/), i przekaż ścieżkę do pliku motywu metodzie.

Metoda wykonuje następujące operacje:

1. Tworzy nowy master slajd na podstawie wybranego mastera.  
1. Zastosowuje zewnętrzny motyw do nowego mastera.  
1. Przypisuje nowego mastera do wszystkich slajdów, które wcześniej zależały od wybranego mastera.  
1. Zwraca nowo utworzony [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/).

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

Nieprawidłowy, uszkodzony lub nieobsługiwany motyw może spowodować [PptxReadException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxreadexception/). Waliduj ścieżki podane przez użytkowników, obsługuj błędy dostępu do systemu plików i zapisuj prezentację dopiero po pomyślnym zastosowaniu motywu.

Jedynie slajdy zależne od wybranego mastera są ponownie przypisane. Slajdy powiązane z innymi masterami zachowują swoje istniejące mastery i motywy. Kolory, czcionki, wypełnienia, linie, tła i efekty świadome motywu są rozwiązywane względem zewnętrznego motywu. Bezpośrednio przypisane kolory, czcionki, wypełnienia i inne explicite formatowanie mogą pozostać niezmienione. Nadpisania na poziomie układu i slajdu mogą również mieć pierwszeństwo przed wartościami odziedziczonymi z nowego mastera.

Motyw może odwoływać się do czcionek, które nie są dostępne w środowisku uruchomieniowym. Dla spójnego renderowania i eksportu zainstaluj wymagane czcionki, udostępnij je poprzez [custom font sources](/slides/pl/php-java/custom-font/), lub skonfiguruj [font substitution](/slides/pl/php-java/font-substitution/).

To bezpośredni przepływ na poziomie mastera: metoda przyjmuje ścieżkę do pliku `.thmx` i nie wymaga ręcznego tworzenia nadpisań motywu na poziomie slajdu lub układu.

### **Zastosowanie różnych zewnętrznych motywów w prezentacji z wieloma masterami**

Gdy właściwy master nie jest znany z góry, pobierz go z reprezentatywnego slajdu za pomocą [Slide::getLayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) i [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/). Przechowaj oryginalne odniesienia do masterów przed zastosowaniem jakichkolwiek motywów, ponieważ każde wywołanie tworzy kolejny master w prezentacji.

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

Pierwsze wywołanie wpływa tylko na slajdy zależne od `$firstGroupMaster`, a drugie wywołanie wpływa tylko na slajdy zależne od `$secondGroupMaster`. Slajdy należące do innych masterów nie zostaną przestyliowane.

### **Zachowanie źródłowego motywu przy przenoszeniu slajdów**

Jeśli chcesz przenieść slajd do innej prezentacji i zachować jego oryginalny projekt, sklonuj źródłowego mastera do docelowej prezentacji przy pomocy [MasterSlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/), a następnie sklonuj slajd przy pomocy [SlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) i sklonowanego mastera. To przenosi master, jego układy i powiązany motyw razem.

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

Jest to preferowany przepływ, gdy źródłowy slajd musi wyglądać tak samo w miejscu docelowym. Proste klonowanie zawartości na niepowiązany master docelowy może zmienić kolory, czcionki, tła i efekty sterowane przez motyw.

### **Zastosowanie wartości motywu do istniejącego slajdu**

Jeśli docelowy slajd musi pozostać na bieżącym masterze i układzie, zainicjuj nadpisanie na poziomie slajdu z motywu źródłowego. Metody [OverrideTheme::initColorSchemeFrom](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/), [OverrideTheme::initFontSchemeFrom](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/) i [OverrideTheme::initFormatSchemeFrom](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/) kopiują trzy główne komponenty motywu do nadpisania.

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

To zmienia motyw używany przez ten slajd bez zmiany motywu dziedziczonego przez inne slajdy. Aby usunąć lokalne nadpisanie i powrócić do wartości odziedziczonych, wywołaj [OverrideTheme::clear](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/).

### **Zastosowanie nadpisania motywu do układu**

Nadpisanie na poziomie układu ma zastosowanie do slajdów używających tego układu, chyba że konkretny slajd ma własne nadpisanie. Te same metody inicjalizacji mogą być użyte poprzez [LayoutSlideThemeManager](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslidethememanager/):

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

Użyj motywu mastera lub prezentacji, gdy wiele układów i slajdów ma współdzielić ten sam podstawowy projekt, nadpisania układu, gdy rodzina układów wymaga innego stylu, oraz nadpisania slajdu tylko w prawdziwych wyjątkach. Nadmierne nadpisania na poziomie slajdu utrudniają późniejsze globalne zmiany motywu.

## **Aktualizacja stylów tła motywu**

Wypełnienia tła motywu są przechowywane w [FormatScheme::getBackgroundFillStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/). PowerPoint może prezentować w interfejsie więcej opcji tła niż liczba rzeczywiście przechowywanych definicji w tej kolekcji, ponieważ UI może łączyć wypełnienia motywu z kolorami motywu i innymi odwołaniami stylów.

![Galeria stylów tła PowerPoint dla motywu prezentacji](presentation-design_8.png)

Przed użyciem stylu tła, sprawdź przechowywaną kolekcję i bieżący [Background::getStyleIndex](https://reference.aspose.com/slides/php-java/aspose.slides/background/). Indeks stylu `0` oznacza brak wypełnienia tematycznego; dodatnie wartości są odwołaniami do stylów tła motywu. To różni się od indeksowania kolekcji PHP bezpośrednio, gdzie `get_Item(0)` oznacza pierwszy przechowywany element. Nie zakładaj, że każda prezentacja zawiera tę samą liczbę stylów wypełnień tła.

Poniższy przykład podaje liczbę dostępnych wypełnień tła, przypisuje odwołanie tematyczne do pierwszego mastera i zapisuje prezentację:

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

Widoczny wynik zależy od wpisu motywu, do którego odwołuje się master, oraz od ewentualnych nadpisań tła na poziomie układu lub slajdu. Jeśli slajd używa własnego tła, zmiana tylko tła mastera może nie zmieni tego slajdu. Użyj [Background::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/background/) gdy potrzebujesz znać ostateczne tło po zastosowaniu dziedziczenia.

{{% alert color="warning" title="Warning" %}}
Nie traktuj indeksu stylu jako indeksu zerowego w kolekcji. Unikaj także twardego kodowania numeru stylu z jednego pliku i zakładania, że ma ten sam wygląd w innym pliku; definicje stylów motywu są specyficzne dla prezentacji.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Dla bezpośredniego formatowania tła i dziedziczenia tła zobacz [Presentation Background](/slides/pl/php-java/presentation-background/).
{{% /alert %}}

## **Aktualizacja efektów motywu**

Schemat formatu motywu zawiera oddzielne kolekcje stylów wypełnień, linii i efektów udostępniane przez [FormatScheme::getFillStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/), [FormatScheme::getLineStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/), oraz [FormatScheme::getEffectStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/). Typowe motywy Office często zawierają trzy główne wpisy stylów, które wizualnie odpowiadają subtelnemu, umiarkowanemu i intensywnemu formatowaniu, ale kod powinien sprawdzać każdą kolekcję zamiast zakładać stałą liczbę.

![Subtelne, umiarkowane i intensywne efekty motywu zastosowane do tego samego kształtu](presentation-design_10.png)

W PHP indeksowanie tych kolekcji jest zerowo‑bazowe: `get_Item(0)` to pierwszy przechowywany styl, a `get_Item(2)` to trzeci. Indeksy stylów odniesień kształtu to odrębna koncepcja, udostępniona przez [ShapeStyle](https://reference.aspose.com/slides/php-java/aspose.slides/shapestyle/). Modyfikacja stylu motywu wpływa na kształty odwołujące się do tego stylu; kształty z bezpośrednim formatowaniem mogą pozostać niezmienione.

Poniższy przykład sprawdza, czy wymagane wpisy stylów istnieją, zmienia pierwszy styl linii, trzeci styl wypełnienia oraz włącza zewnętrzny cień w trzecim stylu efektu, a następnie zapisuje wynik:

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

Dla kształtów odwołujących się do tych slotów, pierwszy styl linii motywu staje się czerwony, trzeci styl wypełnienia motywu staje się jednolitym zielonym lasu, a trzeci styl efektu zyskuje zewnętrzny cień o odległości 10 punktów. Dokładny wizualny rezultat nadal zależy od tego, które sloty stylu odwołują się poszczególne kształty i czy bezpośrednie formatowanie nie nadpisuje motywu.

![Style efektów motywu po zmianie linii, wypełnienia i ustawień cienia](presentation-design_11.png)

## **Wybór stylów wypełnień i linii motywu dla kształtu**

Kształt może wybierać wypełnienie i obrys niezależnie poprzez [ShapeStyle::setFillStyleIndex](https://reference.aspose.com/slides/php-java/aspose.slides/shapestyle/#setFillStyleIndex) i [ShapeStyle::setLineStyleIndex](https://reference.aspose.com/slides/php-java/aspose.slides/shapestyle/#setLineStyleIndex). Dla obu metod indeks `1` wybiera pierwszy wpis w odpowiedniej kolekcji motywu (`get_Item(0)`), a indeks `2` wybiera drugi (`get_Item(1)`).

Poniższy przykład ustawia dwa style wypełnień (złoty i niebieski niebo) oraz dwa style linii (ciemny niebieski 6 pt i ciemny czerwony 12 pt) w domyślnym motywie nowej prezentacji. Zapisuje slajd w trzech etapach, aby można było porównać wyniki w PowerPoint.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $styles = $presentation->getMasterTheme()->getFormatScheme();

    $goldFill = $styles->getFillStyles()->get_Item(0);
    $goldFill->setFillType(FillType::Solid);
    $goldFill->getSolidFillColor()->setColor(new Java("java.awt.Color", 255, 215, 0));
    $blueFill = $styles->getFillStyles()->get_Item(1);
    $blueFill->setFillType(FillType::Solid);
    $blueFill->getSolidFillColor()->setColor(new Java("java.awt.Color", 135, 206, 235));

    $thinLine = $styles->getLineStyles()->get_Item(0);
    $thinLine->getFillFormat()->setFillType(FillType::Solid);
    $thinLine->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 139));
    $thinLine->setWidth(6);
    $thickLine = $styles->getLineStyles()->get_Item(1);
    $thickLine->getFillFormat()->setFillType(FillType::Solid);
    $thickLine->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 139, 0, 0));
    $thickLine->setWidth(12);

    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    $left = $shapes->addAutoShape(ShapeType::Rectangle, 100, 205, 200, 130);
    $right = $shapes->addAutoShape(ShapeType::Rectangle, 420, 205, 200, 130);
    $left->getShapeStyle()->setFillStyleIndex(1);
    $right->getShapeStyle()->setFillStyleIndex(2);
    $left->getShapeStyle()->setLineStyleIndex(1);
    $right->getShapeStyle()->setLineStyleIndex(1);
    $presentation->save("01-initial.pptx", SaveFormat::Pptx);

    $right->getShapeStyle()->setLineStyleIndex(2);
    $presentation->save("02-line-changed.pptx", SaveFormat::Pptx);

    $goldFill->getSolidFillColor()->setColor(new Java("java.awt.Color", 46, 139, 87));
    $presentation->save("03-theme-changed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| Style początkowe | Zmiana prawego obrysu | Edycja pierwszego wypełnienia motywu |
|:---:|:---:|:---:|
| ![Złote i niebieskie niebo prostokąty z dopasowanymi cienkimi ciemnymi niebieskimi obrysami](theme-style-initial.png) | ![Prostokąt niebieski niebo ma teraz grubą ciemną czerwoną obwódkę](theme-style-line-changed.png) | ![Lewy prostokąt jest teraz zielony, a oba obrysy pozostały niezmienione](theme-style-fill-changed.png) |

Wybranie innego stylu linii zmienia jedynie obrys prawego prostokąta. Edycja pierwszego wypełnienia motywu aktualizuje każdy kształt, który go używa. Tutaj tylko lewy prostokąt staje się zielony.

Na istniejącym kształcie lokalny kolor wypełnienia, kolor linii lub szerokość linii mogą nadpisać tę część stylu motywu. Jeśli zmiana indeksu stylu nie daje widocznego efektu, sprawdź [direct formatting](/slides/pl/php-java/shape-formatting/) kształtu.

## **Określenie, czy skuteczne wypełnienie jednolite używa koloru motywu**

Wypełnienie może być przechowywane bezpośrednio na obiekcie lub odziedziczone z paragrafu, układu, mastera, stylu motywu lub innego poziomu formatowania. Wywołaj [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/), aby rozwiązać tę hierarchię w niezmienne dane skutecznego wypełnienia. Najpierw sprawdź wynik `getFillType`. Tylko gdy jest `FillType::Solid`, należy odczytać właściwości wypełnienia jednolitego.

Dla wypełnienia jednolitego, `getSolidFillColor` zwraca ostateczną renderowaną wartość RGB po dziedziczeniu, wyszukiwaniu w motywie i zastosowaniu przekształceń kolorów. Metoda `getSolidFillSchemeColor` zwraca odpowiadający logiczny slot [SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/schemecolor/), taki jak `Text1` lub `Accent6`. Wartość `SchemeColor::NotDefined` oznacza, że skuteczne wypełnienie jednolite nie opiera się na kolorze schematu. W przepływie, w którym wypełnienia są albo kolorami motywu, albo bezpośrednimi kolorami RGB, ta wartość identyfikuje wypełnienie RGB.

Nie używaj wyłącznie lokalnej wartości [ColorFormat::getSchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/), aby klasyfikować wypełnienie. Na przykład fragment tekstu może nie mieć lokalnie zdefiniowanego koloru schematu, więc jego lokalna wartość to `NotDefined`, podczas gdy skuteczne wypełnienie dziedziczy kolor motywu i rozwiązuje się do `Text1` lub `Accent6`. Natomiast `getSolidFillSchemeColor` mówi, który logiczny slot motywu wygenerował skuteczny kolor, ale nie informuje, z którego poziomu hierarchii pochodzi.

Poniższy przykład ładuje prezentację, audytuje zarówno wypełnienia kształtów, jak i wypełnienia fragmentów tekstu, wypisuje każdą ostateczną wartość RGB i powiązany kolor schematu oraz flaguje wypełnienia jednolite, które nie będą śledzić zmian koloru motywu:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SchemeColor;

$auditFill = function (string $objectName, $localFill): void {
    $effectiveFill = $localFill->getEffective();

    if (java_values($effectiveFill->getFillType()) != FillType::Solid) {
        echo $objectName . ": fill type = " . java_values($effectiveFill->getFillType()) . "; not a solid fill." . PHP_EOL;
        return;
    }

    $rgb = $effectiveFill->getSolidFillColor();
    $effectiveSchemeColor = java_values($effectiveFill->getSolidFillSchemeColor());
    $localSchemeColor = java_values($localFill->getSolidFillColor()->getSchemeColor());

    echo sprintf("%s: RGB = #%02X%02X%02X", $objectName, java_values($rgb->getRed()), java_values($rgb->getGreen()), java_values($rgb->getBlue())) . PHP_EOL;
    echo $objectName . ": local scheme = " . $localSchemeColor . ", effective scheme = " . $effectiveSchemeColor . PHP_EOL;

    if ($effectiveSchemeColor == SchemeColor::NotDefined) {
        echo $objectName . ": direct RGB or another non-scheme fill; audit as theme-independent." . PHP_EOL;
    } else {
        echo $objectName . ": theme-dependent through " . $effectiveSchemeColor . "." . PHP_EOL;
    }
};

$autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
$presentation = new Presentation("input.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);

        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            $shapeName = "Slide " . ($slideIndex + 1) . ", shape " . ($shapeIndex + 1);
            $auditFill($shapeName, $shape->getFillFormat());

            if (java_instanceof($shape, $autoShapeClass)) {
                $paragraphCount = java_values($shape->getTextFrame()->getParagraphs()->getCount());
                for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
                    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);

                    $portionCount = java_values($paragraph->getPortions()->getCount());
                    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
                        $portion = $paragraph->getPortions()->get_Item($portionIndex);
                        $portionName = $shapeName . ", paragraph " . ($paragraphIndex + 1) . ", portion " . ($portionIndex + 1);
                        $auditFill($portionName, $portion->getPortionFormat()->getFillFormat());
                    }
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Gałąź `NotDefined` dostarcza listę audytu wypełnień jednolitych, które nie będą reagować na zmiany w slotach kolorów motywu. Przejrzyj te obiekty, gdy prezentacja ma podążać za nową paletą marki. Zgłoszona wartość RGB wciąż pokazuje aktualny wygląd, a wartość schematu wyjaśnia, czy ten wygląd jest połączony z motywem.

Obiekty formatów skutecznych są migawkami. Po zmianie motywu prezentacji, nadpisania motywu lub dowolnego odziedziczonego formatowania, wywołaj ponownie `getEffective` i odczytaj nowe skuteczne dane wypełnienia przed porównaniem lub raportowaniem kolorów.

## **Odczyt skutecznych wartości motywu**

Surowe obiekty motywu mówią, co jest zdefiniowane na danym poziomie. Skuteczne wartości mówią, co slajd lub kształt faktycznie używa po rozwiązaniu dziedziczenia i lokalnych nadpisań. Dla slajdu, wywołaj [BaseOverrideThemeManager::createThemeEffective](https://reference.aspose.com/slides/php-java/aspose.slides/baseoverridethememanager/). Dla tła, użyj [Background::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/background/), a dla wypełnienia, użyj [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/).

Poniższy przykład odczytuje skuteczny motyw, tło i pierwsze wypełnienie kształtu ze slajdu:

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

Używaj danych skutecznych do diagnostyki renderowania, walidacji i porównań. Jeśli sprawdzasz tylko [Presentation::getMasterTheme](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), możesz przeoczyć nadpisanie mastera, układu, slajdu lub kształtu, które zmienia ostateczny wygląd.

## **FAQ**

**Czy zastosowanie zewnętrznego motywu wpływa na każdy slajd w prezentacji?**

Nie. [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) przypisuje tylko slajdy zależne od wybranego mastera. Slajdy używające innych masterów zachowują swoje istniejące motywy.

**Czy mogę zastosować motyw do jednego slajdu bez zmiany mastera?**

Tak. Użyj [SlideThemeManager](https://reference.aspose.com/slides/php-java/aspose.slides/slidethememanager/) slajdu i zainicjuj jego nadpisanie motywu. Zmiana pozostaje lokalna dla tego slajdu; inne slajdy nadal dziedziczą swoje istniejące motywy.

**Jaki jest najbezpieczniejszy sposób przeniesienia motywu z jednej prezentacji do drugiej?**

Podczas przenoszenia slajdu i zachowania jego wyglądu źródłowego, sklonuj źródłowego mastera do docelowej prezentacji i sklonuj slajd z tym masterem przy użyciu [MasterSlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/) oraz [SlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/). To zachowuje master, układy i motyw razem.

**Jak mogę zobaczyć skuteczne wartości po dziedziczeniu i nadpisaniach?**

Użyj [BaseOverrideThemeManager::createThemeEffective](https://reference.aspose.com/slides/php-java/aspose.slides/baseoverridethememanager/) dla slajdu lub układu oraz odpowiednich metod danych skutecznych dla obiektów formatów, takich jak [Background::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/background/) i [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/). Te API zwracają rozstrzygnięte wartości po zastosowaniu dziedziczenia i nadpisań.