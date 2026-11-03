---
title: Správa zástupných prvků prezentace v PHP
linktitle: Správa zástupných prvků
type: docs
weight: 10
url: /cs/php-java/manage-placeholder/
keywords:
- zástupný prvek
- textový zástupný prvek
- obrázkový zástupný prvek
- grafický zástupný prvek
- obsahový zástupný prvek
- výzva
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Naučte se, jak prohlížet a upravovat textové, obrázkové, grafické a obsahové zástupné prvky a pochopit dědičnost zástupných prvků pomocí Aspose.Slides pro PHP přes Java."
---
## **Přehled**

Zástupný prvek je tvar, který rezervuje pozici pro konkrétní typ obsahu v šabloně prezentace. Běžnými příklady jsou zástupné prvky pro nadpis, tělo, obrázek, graf a obecné účely. Na rozdíl od běžného tvaru může zástupný prvek dědit svou pozici, velikost, formátování a další nastavení z rozložení snímku nebo z hlavního snímku.

Aspose.Slides poskytuje informace o zástupných prvcích prostřednictvím metody [Shape::getPlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getplaceholder/). Metoda vrací objekt [Placeholder](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/) nebo `null` pro běžný tvar. Použijte [Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) k určení, co je zástupný prvek určen k obsahu.

Typ tvaru je stále důležitý i poté, co znáte typ zástupného prvku:

- Prázdný textový, obrázkový, grafický nebo obsahový zástupný prvek je obvykle reprezentován pomocí [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
- Vyplněný zástupný prvek obrázku může být reprezentován pomocí [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/).
- Vyplněný zástupný prvek grafu může být reprezentován pomocí [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/).
- Obsahový zástupný prvek může obsahovat několik typů obsahu. Zkontrolujte jak [Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/), tak runtime třídu tvaru, místo abyste předpokládali, že každý zástupný prvek je [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) popisuje roli zástupného prvku; nezaručuje runtime třídu tvaru. Vždy provádějte kontrolu typu před přístupem k textovým, obrázkovým, grafovým, tabulkovým nebo mediálním členům.
{{% /alert %}}

## **Pochopení dědičnosti zástupných prvků**

Zástupné prvky tvoří hierarchii:

1. Hlavní snímek definuje opakovaně použitelné styly a v některých případech zástupné prvky na úrovni hlavního snímku.
2. Rozložení snímku určuje uspořádání používané jedním nebo více běžnými snímky a může dědit z hlavního snímku.
3. Běžný snímek obsahuje zástupné prvky pro daný snímek a může dědit z jeho rozložení.

Voláním [Shape::getBasePlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getbaseplaceholder/) se posunete o úroveň výše v této hierarchii. Zástupný prvek snímku obvykle vrací svůj zástupný prvek rozložení; zástupný prvek rozložení může vrátit svůj hlavní zástupný prvek. Metoda vrací `null`, pokud tvar nemá základní zástupný prvek.

Následující příklad vypíše zástupné prvky na prvním snímku a zobrazí jejich základní zástupné prvky:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        $shapeClass = $shape->getClass();
        $shapeClassNameValue = $shapeClass->getSimpleName();
        $shapeClassName = java_values($shapeClassNameValue);
        echo "Slide placeholder: " . $placeholderType . "; shape class: " . $shapeClassName . PHP_EOL;

        $layoutPlaceholder = $shape->getBasePlaceholder();
        if (!java_is_null($layoutPlaceholder)) {
            $layoutPlaceholderInfo = $layoutPlaceholder->getPlaceholder();
            if (!java_is_null($layoutPlaceholderInfo)) {
                $layoutPlaceholderTypeValue = $layoutPlaceholderInfo->getType();
                $layoutPlaceholderType = java_values($layoutPlaceholderTypeValue);
                echo "  Layout placeholder: " . $layoutPlaceholderType . PHP_EOL;
            }

            $masterPlaceholder = $layoutPlaceholder->getBasePlaceholder();
            if (!java_is_null($masterPlaceholder)) {
                $masterPlaceholderInfo = $masterPlaceholder->getPlaceholder();
                if (!java_is_null($masterPlaceholderInfo)) {
                    $masterPlaceholderTypeValue = $masterPlaceholderInfo->getType();
                    $masterPlaceholderType = java_values($masterPlaceholderTypeValue);
                    echo "  Master placeholder: " . $masterPlaceholderType . PHP_EOL;
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Úprava zástupného prvku na běžném snímku vytvoří nebo změní lokální přepsání pro tento snímek. Úprava souvisejícího rozložení nebo hlavního snímku může ovlivnit všechny snímky, které stále dědí toto nastavení. Lokální běžný tvar nemá základní zástupný prvek a nezačne dědit jen proto, že zabírá stejné souřadnice.

## **Odstranění stavu zástupného prvku**

Při úpravě šablony použijte [Shape::removePlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/removeplaceholder/) abyste zachovali existující objekt jako běžný tvar. Jeho [getPlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getplaceholder/) metoda vrací `null`, ale tvar zůstává ve sbírce snímku. Naopak [ShapeCollection::remove](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/remove/) odstraní tvar z této sbírky.

Následující příklad vyžaduje `template.pptx` s alespoň jedním snímkem a neprázdným textovým zástupným prvkem na prvním snímku. Použijte zástupný prvek s formátováním děděným z jeho rozložení nebo hlavního snímku, abyste viděli efekt odstranění tohoto vztahu. Příklad kontroluje, že stejný tvar zůstává, znovu volá metodu na nyní běžném tvaru a výsledek uloží.

{{% alert color="warning" title="Warning" %}}
Odstranění stavu zástupného prvku automaticky neuchovává děděná nastavení vzhledu. Níže uvedený příklad úmyslně ponechává tato nastavení nezměněna, takže výstup může vypadat jinak. Tvar, jehož pozice a velikost jsou zcela děděny, může po volání mít nulové souřadnice a rozměry a stát se neviditelným, i když zůstává ve sbírce.
{{% /alert %}}

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $found = false;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (!java_instanceof($shape, $autoShapeClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        $textFrame = $shape->getTextFrame();
        if (java_is_null($placeholder) || java_is_null($textFrame)) {
            continue;
        }

        $textValue = $textFrame->getText();
        if (java_is_null($textValue)) {
            continue;
        }
        $text = java_values($textValue);
        if ($text === "") {
            continue;
        }

        $shape->removePlaceholder();

        $placeholder = $shape->getPlaceholder();
        $retainedShape = $slide->getShapes()->get_Item($shapeIndex);
        $sameShapeValue = $shape->equals($retainedShape);
        $sameShape = java_values($sameShapeValue);
        $remainingCountValue = $slide->getShapes()->size();
        $remainingCount = java_values($remainingCountValue);
        echo "Placeholder removed: " . (java_is_null($placeholder) ? "true" : "false") . PHP_EOL;
        echo "Same shape retained: " . ($sameShape ? "true" : "false") . PHP_EOL;
        echo "Shape count unchanged: " . ($remainingCount === $shapeCount ? "true" : "false") . PHP_EOL;

        // Volání metody na běžném tvaru nemá žádný efekt.
        $shape->removePlaceholder();
        $found = true;
        break;
    }

    if ($found) {
        $presentation->save("placeholder-status-removed.pptx", SaveFormat::Pptx);
    } else {
        echo "No nonempty text placeholder was found on the first slide." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Pro odpovídající zástupný prvek všechny tři kontroly vrátí `true`. Text zůstane, ale děděná pozice, velikost, rotace, písmo, zarovnání odstavce, okraje textového rámce, svislé ukotvení, výplň a nastavení čáry se mohou změnit, když je vztah zástupného prvku odstraněn. Například děděné formátování nadpisu může přejít na běžné formátování textu. Viz [Slide Layout](/slides/cs/php-java/slide-layout/) pro více informací o rozloženích.

Aby byl zachován zamýšlený vzhled, zachyťte vypočtenou pozici, velikost a rotaci před voláním a zkopírujte požadované hodnoty efektivního formátování do samostatných proměnných. Získejte tyto hodnoty pomocí [PortionFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/geteffective/), [ParagraphFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/geteffective/), [TextFrameFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/geteffective/), [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/geteffective/), a [LineFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/geteffective/). Nespoléhejte se pouze na uchování objektů efektivního formátu, protože jejich hodnoty textového formátování se mohou po odstranění vztahu změnit. Výslovně aplikujte zachycené hodnoty na běžný tvar následně, včetně rodiny písma, velikosti, stylu, barvy, nastavení odstavce, nastavení textového rámce, výplně a čáry použité ve vaší šabloně.

Děděná geometrie tvaru může také vyžadovat explicitní přiřazení pomocí [GeometryShape::setShapeType](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setShapeType). Pro obdélníkový textový zástupný prvek to znamená přiřadit [ShapeType::Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/shapetype/); obnovení pouze výplně a čáry nemusí obnovit viditelný obdélník. Šablony s dalšími efekty nebo složitějším formátováním také vyžadují, aby byla tato nastavení řešena.

## **Změna textu v zástupném prvku**

Zástupné prvky nadpisu, centrovaného nadpisu, podnadpisu, těla a textu obvykle podporují text. Před použitím jeho metody [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/gettextframe/) zkontrolujte, zda se jedná o [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).

Tento příklad aktualizuje první zástupný prvek nadpisu na prvním snímku a uloží výsledek:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $titleShape = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $autoShapeClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) {
            $titleShape = $shape;
            break;
        }
    }

    if ($titleShape === null) {
        throw new RuntimeException("The first slide does not contain a title placeholder.");
    }

    $titleShape->getTextFrame()->setText("Quarterly Business Review");
    $presentation->save("title-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Tento vzor se vyhýbá zacházení s obrázkovými, grafickými, tabulkovými nebo mediálními zástupnými prvky jako s objekty [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/). Také identifikuje zástupný prvek podle účelu místo spoléhaní se na křehký index tvaru.

## **Nastavení textu výzvy v rozložení**

Text výzvy je návrhová instrukce zobrazena v prázdném zástupném prvku, například *Klikněte pro přidání nadpisu*. Nastavte vlastní text výzvy v zástupném prvku rozložení místo pokusu o jeho získání přes sbírku tvarů běžného snímku. Přístup k rozložení získáte pomocí [Slide::getLayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getLayoutSlide) a iterujte přes sbírku vrácenou metodou [BaseSlide::getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes).

Následující příklad mění výzvy nadpisu a podnadpisu v rozložení použitém na prvním snímku:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $slide->getLayoutSlide();
    $shapes = $layoutSlide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $autoShapeClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) {
            $shape->getTextFrame()->setText("Enter a concise slide title");
        } elseif ($placeholderType === PlaceholderType::Subtitle) {
            $shape->getTextFrame()->setText("Enter a subtitle or reporting period");
        }
    }

    $presentation->save("custom-placeholder-prompts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Text výzvy není běžný obsah snímku. Je určen pro prázdné zástupné prvky v editačních aplikacích jako PowerPoint. Jakmile uživatel nebo program zadá skutečný obsah, výzva se již nezobrazuje. Změna výzvy také nenahrazuje existující text na snímcích, které používají dané rozložení.

## **Aktualizace obrázkového zástupného prvku**

Existují dva případy, které je třeba řešit:

- Pokud je obrázkový zástupný prvek již vyplněn a reprezentován pomocí [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/), nahraďte obrázek pomocí [PictureFillFormat::getPicture](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/getpicture/) a [Picture::setImage](https://reference.aspose.com/slides/php-java/aspose.slides/picture/#setImage).
- Pokud je stále prázdný zástupný prvek, přidejte obrázkový rám na souřadnice zástupného prvku pomocí [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addpictureframe/) a odstraňte prázdný zástupný prvek.

Následující příklad podporuje oba případy a uloží prezentaci:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("picture-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $pictureFrameClass = new JavaClass("com.aspose.slides.PictureFrame");
    $picturePlaceholder = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Picture) {
            $picturePlaceholder = $shape;
            break;
        }
    }

    if ($picturePlaceholder === null) {
        throw new RuntimeException("The first slide does not contain a picture placeholder.");
    }

    $imageData = file_get_contents("replacement.png");
    $image = $presentation->getImages()->addImage($imageData);

    if (java_instanceof($picturePlaceholder, $pictureFrameClass)) {
        $picture = $picturePlaceholder->getPictureFormat()->getPicture();
        $picture->setImage($image);
    } else {
        $x = $picturePlaceholder->getX();
        $y = $picturePlaceholder->getY();
        $width = $picturePlaceholder->getWidth();
        $height = $picturePlaceholder->getHeight();
        $shapes->addPictureFrame(ShapeType::Rectangle, $x, $y, $width, $height, $image);
        $shapes->remove($picturePlaceholder);
    }

    $presentation->save("picture-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Nahrazení vytvořené pro prázdný zástupný prvek je lokální obrázkový rám, nikoli nový zástupný prvek, protože [Shape::getPlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getplaceholder/) neposkytuje setter. Uchovává rezervovanou pozici, ale již nedědí chování specifické pro zástupný prvek. Pokud je zachování vztahu zástupného prvku podstatné, nejprve připravte a vyplňte zástupný prvek v PowerPointu, poté aktualizujte výsledný [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) pomocí Aspose.Slides.

Pro průhlednost obrazu, ořezávání a další efekty specifické pro obrázek viz [Manage Picture Frames](/slides/cs/php-java/picture-frame/). Tyto operace patří k obrázkovému rámu nebo výplni obrázku, nikoli k metadatům zástupného prvku.

## **Práce s grafovými a obsahovými zástupnými prvky**

Vyplněný grafový zástupný prvek může být reprezentován pomocí [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/). Tento příklad najde takový graf podle typu zástupného prvku i runtime třídy, změní jeho nadpis a uloží soubor:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("chart-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $chartClass = new JavaClass("com.aspose.slides.Chart");
    $placeholderChart = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $chartClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Chart) {
            $placeholderChart = $shape;
            break;
        }
    }

    if ($placeholderChart === null) {
        throw new RuntimeException("The first slide does not contain a populated chart placeholder.");
    }

    $placeholderChart->setTitle(true);
    $placeholderChart->getChartTitle()->addTextFrameForOverriding("Quarterly Revenue");
    $presentation->save("chart-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Obecný obsahový zástupný prvek má obvykle [PlaceholderType::Object](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/). V PowerPointu funguje jako spouštěč několika typů obsahu, včetně grafů, tabulek, diagramů, obrázků a médií. Po jeho naplnění zkontrolujte skutečnou třídu tvaru, abyste zjistili, co obsahuje. Specializovaná rozložení mohou také odhalit [PlaceholderType::Chart](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/), nebo [PlaceholderType::Diagram](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/).

Aspose.Slides nepřevádí prázdný [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) zástupný prvek na [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/) pouhým změněním [Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/). Typ nelze změnit skrze třídu. Pro programové vyplnění prázdného grafu nebo obsahové oblasti přidejte požadovaný objekt na souřadnice zástupného prvku a poté odstraňte prázdný zástupný prvek. Následující příklad to provádí pro graf:

```php
use aspose\slides\ChartType;
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("content-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $targetPlaceholder = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Chart || $placeholderType === PlaceholderType::Object) {
            $targetPlaceholder = $shape;
            break;
        }
    }

    if ($targetPlaceholder === null) {
        throw new RuntimeException("The first slide does not contain a chart or content placeholder.");
    }

    $x = $targetPlaceholder->getX();
    $y = $targetPlaceholder->getY();
    $width = $targetPlaceholder->getWidth();
    $height = $targetPlaceholder->getHeight();
    $chart = $shapes->addChart(ChartType::ClusteredColumn, $x, $y, $width, $height);
    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("Quarterly Revenue");
    $shapes->remove($targetPlaceholder);
    $presentation->save("content-placeholder-replaced-with-chart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Přidaný graf je běžný lokální graf. Zabírá oblast zástupného prvku, ale ne DĚDÍ z rozložení zástupného prvku. Použijte věnované [chart management articles](/slides/cs/php-java/powerpoint-charts/) když potřebujete nahradit jeho kategorie, řady nebo data sešitu.

## **Kompletní příklad: Aktualizace textového nebo obrazového obsahu**

Následující end-to-end příklad otevře šablonu, prohledá první snímek na zástupný prvek nadpisu nebo obrázku, zkontroluje typy zástupného prvku a tvaru, aktualizuje odpovídající obsah a uloží výstup. Příklad úmyslně nepředpokládá index tvaru ani nezachází se všemi zástupnými prvky jako se stejnou třídou.

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $pictureFrameClass = new JavaClass("com.aspose.slides.PictureFrame");
    $updated = false;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);

        if (($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) && java_instanceof($shape, $autoShapeClass)) {
            $shape->getTextFrame()->setText("Quarterly Business Review");
            $updated = true;
            break;
        }

        if ($placeholderType === PlaceholderType::Picture) {
            $imageData = file_get_contents("replacement.png");
            $image = $presentation->getImages()->addImage($imageData);

            if (java_instanceof($shape, $pictureFrameClass)) {
                $picture = $shape->getPictureFormat()->getPicture();
                $picture->setImage($image);
            } else {
                $x = $shape->getX();
                $y = $shape->getY();
                $width = $shape->getWidth();
                $height = $shape->getHeight();
                $shapes->addPictureFrame(ShapeType::Rectangle, $x, $y, $width, $height, $image);
                $shapes->remove($shape);
            }

            $updated = true;
            break;
        }
    }

    if (!$updated) {
        throw new RuntimeException("No supported title or picture placeholder was found on the first slide.");
    }

    $presentation->save("placeholder-content-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Často kladené dotazy**

**Co je základní zástupný prvek?**

Základní zástupný prvek je odpovídající tvar na rozložení nebo hlavním snímku, ze kterého jiný zástupný prvek dědí. Použijte [Shape::getBasePlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getbaseplaceholder/) k jeho získání. Běžný lokální tvar vrací `null`, protože není součástí hierarchie zástupných prvků.

**Mohu změnit všechny nadpisy snímků úpravou zástupného prvku rozložení?**

Můžete změnit děděné formátování nebo text výzvy prostřednictvím rozložení, ale existující obsah nadpisu je uložen na běžných snímcích. Pro nahrazení skutečného textu nadpisu v celé prezentaci iterujte přes snímky a aktualizujte každý zástupný prvek nadpisu.

**Jak spravovat zástupné prvky data, čísla snímku, záhlaví a zápatí?**

Použijte správce záhlaví a zápatí na odpovídajícím úrovni snímku, rozložení, hlavního snímku, poznámek nebo rozdělaných listů. Viz [Manage Presentation Header and Footer](/slides/cs/php-java/presentation-header-and-footer/) pro kompletní příklady.