---
title: Správa zástupných prvků prezentace v PHP
linktitle: Spravovat zástupné prvky
type: docs
weight: 10
url: /cs/php-java/manage-placeholder/
keywords:
- zástupný prvek
- textový zástupný prvek
- obrazový zástupný prvek
- grafický zástupný prvek
- obsahový zástupný prvek
- výzva text
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Naučte se, jak prohlížet a upravovat textové, obrázkové, grafické a obsahové zástupné prvky a pochopit dědičnost zástupných prvků pomocí Aspose.Slides pro PHP přes Java."
---
## **Přehled**

Zástupný prvek je tvar, který rezervuje pozici pro konkrétní typ obsahu v šabloně prezentace. Běžné příklady jsou zástupné prvky pro název, tělo, obrázek, graf a obecné účely obsahu. Na rozdíl od běžného tvaru může zástupný prvek dědit svou pozici, velikost, formátování a další nastavení z rozvržení snímku nebo hlavního snímku.

Aspose.Slides poskytuje informace o zástupných prvcích prostřednictvím metody [Shape::getPlaceholder](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/getplaceholder/). Metoda vrací objekt [Placeholder](https://reference.aspose.com/slides/cs/php-java/aspose.slides/placeholder/) nebo `null` pro běžný tvar. Použijte [Placeholder::getType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/placeholder/gettype/) k určení, co je zástupný prvek určen k obsahu.

Třída tvaru je i po zjištění typu zástupného prvku stále důležitá:

- Prázdný textový, obrázkový, grafický nebo obsahový zástupný prvek je obvykle reprezentován pomocí [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/).
- Vyplněný obrázkový zástupný prvek může být reprezentován pomocí [PictureFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pictureframe/).
- Vyplněný grafický zástupný prvek může být reprezentován pomocí [Chart](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chart/).
- Obsahový zástupný prvek může obsahovat několik typů obsahu. Zkontrolujte jak [Placeholder::getType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/placeholder/gettype/), tak runtime třídu tvaru místo předpokladu, že každý zástupný prvek je [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder::getType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/placeholder/gettype/) popisuje roli zástupného prvku; nezaručuje runtime třídu tvaru. Vždy použijte kontrolu typu před přístupem k textu, obrázku, grafu, tabulce nebo mediálním členům.
{{% /alert %}}

## **Pochopte dědičnost zástupných prvků**

Zástupné prvky tvoří hierarchii:

1. Hlavní snímek definuje opakovaně použitelné styly a v některých případech i zástupné prvky na úrovni hlavního snímku.
2. Rozložení snímku určuje uspořádání používané jedním nebo více běžnými snímky a může dědit z hlavního snímku.
3. Běžný snímek obsahuje zástupné prvky pro tento snímek a může dědit z jeho rozložení.

Voláním [Shape::getBasePlaceholder](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/getbaseplaceholder/) se posunete o úroveň výše v této hierarchii. Zástupný prvek snímku obvykle vrací svůj zástupný prvek rozložení; zástupný prvek rozložení může vrátit svůj hlavní zástupný prvek. Metoda vrací `null`, když tvar nemá základní zástupný prvek.

Následující příklad vypíše zástupné prvky na prvním snímku a uvádí jejich základní zástupné prvky:

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

Úprava zástupného prvku na běžném snímku vytvoří nebo změní místní přepsání pro tento snímek. Úprava souvisejícího rozložení nebo hlavního snímku může ovlivnit všechny snímky, které stále dědí toto nastavení. Místní běžný tvar nemá základní zástupný prvek a nezačíná dědit jen proto, že obsazuje stejné souřadnice.

## **Změna textu v zástupném prvku**

Název, centrovaný název, podtitul, tělo a textové zástupné prvky obvykle podporují text. Zkontrolujte [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) před použitím jeho [getTextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/gettextframe/) metody.

Tento příklad aktualizuje první zástupný prvek názvu na prvním snímku a uloží výsledek:

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

Tento vzor zabraňuje zacházení s obrázkovými, grafickými, tabulkovými nebo mediálními zástupnými prvky jako s objekty [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/). Také identifikuje zástupný prvek podle účelu místo spoléhaní na křehký index tvaru.

## **Nastavení výzvy textu v rozložení**

Výzva (prompt text) je návrhová instrukce zobrazovaná v prázdném zástupném prvku, například *Klikněte pro přidání názvu*. Nastavte vlastní výzvu na zástupném prvku rozložení místo pokusu o dosažení přes kolekci tvarů běžného snímku. Přístup k rozložení získáte přes [Slide::getLayoutSlide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slide/#getLayoutSlide) a iterujte přes kolekci vrácenou metodou [BaseSlide::getShapes](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseslide/#getShapes).

Následující příklad mění výzvy názvu a podtitulu v rozložení použitém prvním snímkem:

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

Výzva není běžný obsah snímku. Je určena pro prázdné zástupné prvky v editovacích aplikacích, jako je PowerPoint. Jakmile uživatel nebo program dodá skutečný obsah, výzva už není zobrazena. Změna výzvy také nenahrazuje existující text na snímcích, které rozložení používají.

## **Aktualizace obrázkového zástupného prvku**

Existují dva případy k řešení:

- Pokud je obrázkový zástupný prvek již vyplněn a reprezentován jako [PictureFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pictureframe/), nahraďte obrázek pomocí [PictureFillFormat::getPicture](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturefillformat/getpicture/) a [SlidesPicture::setImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidespicture/setimage/).
- Pokud je stále prázdný, přidejte obrázkový rámec na souřadnice zástupného prvku pomocí [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/addpictureframe/) a odstraňte prázdný zástupný prvek.

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

Náhrada vytvořená pro prázdný zástupný prvek je místní obrázkový rámec, nikoli nový zástupný prvek, protože [Shape::getPlaceholder](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/getplaceholder/) neposkytuje setter. Zachovává vyhrazenou pozici, ale již nedědí chování specifické pro zástupný prvek. Pokud je zachování vztahu k zástupnému prvku podstatné, připravte a vyplňte zástupný prvek v PowerPointu nejdříve, poté aktualizujte vzniklý [PictureFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pictureframe/) pomocí Aspose.Slides.

Pro průhlednost obrázku, ořez a další efekty specifické pro obrázek viz [Manage Picture Frames](/slides/cs/php-java/picture-frame/). Tyto operace patří k obrázkovému rámci nebo výplni obrázku, nikoli k metadatům zástupného prvku.

## **Práce s grafovými a obsahovými zástupnými prvky**

Vyplněný grafový zástupný prvek může být reprezentován pomocí [Chart](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chart/). Tento příklad najde takový graf podle typu zástupného prvku i runtime třídy, změní jeho název a uloží soubor:

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

Obecný obsahový zástupný prvek obvykle má [PlaceholderType::Object](https://reference.aspose.com/slides/cs/php-java/aspose.slides/placeholdertype/). V PowerPointu funguje jako spouštěč pro několik typů obsahu, včetně grafů, tabulek, diagramů, obrázků a médií. Po naplnění zkontrolujte skutečnou třídu tvaru, abyste zjistili, co obsahuje. Specializovaná rozložení mohou také exponovat [PlaceholderType::Chart](https://reference.aspose.com/slides/cs/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/cs/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/cs/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/cs/php-java/aspose.slides/placeholdertype/), nebo [PlaceholderType::Diagram](https://reference.aspose.com/slides/cs/php-java/aspose.slides/placeholdertype/).

Aspose.Slides nepřevádí prázdný [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) zástupný prvek na [Chart](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chart/) pouhým změněním [Placeholder::getType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/placeholder/gettype/); typ nelze změnit přes třídu. Pro naplnění prázdného grafu nebo obsahové oblasti programově přidejte požadovaný objekt na souřadnice zástupného prvku a pak odstraňte prázdný zástupný prvek. Následující příklad to provádí pro graf:

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

Přidaný graf je obyčejný místní graf. Zabírá oblast zástupného prvku, ale nedědí z rozložení zástupného prvku. Použijte věnované [chart management articles](/slides/cs/php-java/powerpoint-charts/) když potřebujete nahradit jeho kategorie, řady nebo data sešitu.

## **Kompletní příklad: aktualizace textového nebo obrazového obsahu**

Následující end-to-end příklad otevře šablonu, prohledá první snímek buď po názvu, nebo po obrázkovém zástupném prvku, zkontroluje typy zástupného prvku a tvaru, aktualizuje odpovídající obsah a uloží výstup. Příklad úmyslně nevyužívá předpoklad o indexu tvaru ani neprovádí všechny zástupné prvky jako stejnou třídu.

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

## **FAQ**

**Co je základní zástupný prvek?**

Základní zástupný prvek je odpovídající tvar na rozložení nebo hlavním snímku, ze kterého jiný zástupný prvek dědí. Použijte [Shape::getBasePlaceholder](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/getbaseplaceholder/) pro jeho získání. Běžný místní tvar vrací `null`, protože není součástí hierarchie zástupných prvků.

**Mohu změnit všechny názvy snímků úpravou zástupného prvku v rozložení?**

Můžete změnit zděděné formátování nebo výzvu textu prostřednictvím rozložení, ale existující titulek je uložen na běžných snímcích. Pro nahrazení skutečného titulního textu v celé prezentaci iterujte snímky a aktualizujte každý titulek.

**Jak spravovat zástupné prvky data, čísla snímku, záhlaví a zápatí?**

Použijte správce záhlaví a zápatí na odpovídajícím rozsahu snímku, rozložení, hlavního snímku, poznámek nebo výstřižků. Viz [Manage Presentation Header and Footer](/slides/cs/php-java/presentation-header-and-footer/) pro kompletní příklady.