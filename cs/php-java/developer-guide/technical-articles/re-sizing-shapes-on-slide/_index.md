---
title: Změna velikosti tvarů na snímcích prezentace v PHP
type: docs
weight: 130
url: /cs/php-java/resizing-shapes-on-slide/
aliases:
  - /php-java/re-sizing-shapes-on-slide/
  - /cs/php-java/re-sizing-shapes-on-slide/
keywords:
  - změna velikosti tvaru
  - změna velikosti tvaru
  - PowerPoint
  - OpenDocument
  - prezentace
  - PHP
  - Aspose.Slides
description: "Jednoduše změňte velikost tvarů na snímcích PowerPoint a OpenDocument pomocí Aspose.Slides pro PHP přes Java—automatizujte úpravy rozvržení snímků a zvyšte produktivitu."
---
## **Přehled**

Když změníte velikost snímku prezentace, může být také nutné změnit velikost a umístění jejích tvarů, aby odpovídaly novým rozměrům. Tento článek ukazuje, jak ručně škálovat tvary a jak zacházet s tabulkami na snímcích, hlavních snímcích a rozvrzích.

## **Změna velikosti tvarů**

Aby se zachovala relativní poloha a velikost každého tvaru, vynásobte jeho vodorovné souřadnice a šířku poměrem nové šířky snímku k původní šířce. Na svislé souřadnice a výšku použijte odpovídající poměr výšky.

První příklad načte prezentaci, jejíž snímky neobsahují tabulky, změní velikost snímku na formát A4 a uloží výsledek. Používá [SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/) s [SlideSizeScaleType::DoNotScale](https://reference.aspose.com/slides/php-java/aspose.slides/slidesizescaletype/), aby následná smyčka řídila škálování. Poměry jsou bezrozměrné; pozice a rozměry tvarů jsou měřeny v bodech. Různé poměry šířky a výšky mohou tvary deformovat a změna rozměrů tvaru nemění velikost jeho písma.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SlideSizeType;

$presentation = new Presentation("sample.pptx");
try {
    // Vypočítejte nezávislé horizontální a vertikální měřítkové faktory.
    $originalSize = $presentation->getSlideSize()->getSize();
    $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
    $targetSize = $presentation->getSlideSize()->getSize();
    $widthRatio = java_values($targetSize->getWidth()) / java_values($originalSize->getWidth());
    $heightRatio = java_values($targetSize->getHeight()) / java_values($originalSize->getHeight());

    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            $shape->setWidth(java_values($shape->getWidth()) * $widthRatio);
            $shape->setHeight(java_values($shape->getHeight()) * $heightRatio);
            $shape->setX(java_values($shape->getX()) * $widthRatio);
            $shape->setY(java_values($shape->getY()) * $heightRatio);
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Tabulky vyžadují samostatné zpracování: škálujte šířky jejich sloupců a výšky řádků místo přiřazování celkové šířky a výšky tabulky. Výšky řádků mohou zůstat větší, než je požadováno, pokud obsah buňky vyžaduje více místa.
{{% /alert %}}

Druhý příklad podporuje tabulky a zpracovává tvary na hlavních snímcích a rozvrzích i na jednotlivých snímcích před uložením změněné prezentace. Jeho pomocná třída zpracovává každou [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) škálováním šířek sloupců pomocí [Column::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/column/setwidth/) a minimálních výšek řádků pomocí [Row::setMinimalHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/setminimalheight/). Poté škáluje pozici tabulky, aniž by samostatně škálovala její celkové rozměry.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SlideSizeType;

class ShapeResizer {
    public function resizeShapes($shapes, $widthRatio, $heightRatio) {
        $tableClass = new JavaClass("com.aspose.slides.Table");
        for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
            $shape = $shapes->get_Item($shapeIndex);
            if (java_instanceof($shape, $tableClass)) {
                $table = $shape;
                // Rozměry tabulky jsou řízeny šířkami sloupců a výškami řádků.
                for ($columnIndex = 0; $columnIndex < java_values($table->getColumns()->size()); $columnIndex++) {
                    $column = $table->getColumns()->get_Item($columnIndex);
                    $column->setWidth(java_values($column->getWidth()) * $widthRatio);
                }

                for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
                    $row = $table->getRows()->get_Item($rowIndex);
                    $row->setMinimalHeight(java_values($row->getMinimalHeight()) * $heightRatio);
                }
            }
            else {
                $shape->setWidth(java_values($shape->getWidth()) * $widthRatio);
                $shape->setHeight(java_values($shape->getHeight()) * $heightRatio);
            }

            $shape->setX(java_values($shape->getX()) * $widthRatio);
            $shape->setY(java_values($shape->getY()) * $heightRatio);
        }
    }
}

$presentation = new Presentation("sample.pptx");
try {
    // Vypočítejte nezávislé horizontální a vertikální měřítkové faktory.
    $originalSize = $presentation->getSlideSize()->getSize();
    $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
    $targetSize = $presentation->getSlideSize()->getSize();
    $widthRatio = java_values($targetSize->getWidth()) / java_values($originalSize->getWidth());
    $heightRatio = java_values($targetSize->getHeight()) / java_values($originalSize->getHeight());

    $resizer = new ShapeResizer();

    // Změňte velikost tvarů definovaných na hlavních snímcích a rozvrzích i na jednotlivých snímcích.
    for ($masterIndex = 0; $masterIndex < java_values($presentation->getMasters()->size()); $masterIndex++) {
        $master = $presentation->getMasters()->get_Item($masterIndex);
        $resizer->resizeShapes($master->getShapes(), $widthRatio, $heightRatio);

        for ($layoutSlideIndex = 0; $layoutSlideIndex < java_values($master->getLayoutSlides()->size()); $layoutSlideIndex++) {
            $layoutSlide = $master->getLayoutSlides()->get_Item($layoutSlideIndex);
            $resizer->resizeShapes($layoutSlide->getShapes(), $widthRatio, $heightRatio);
        }
    }

    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $resizer->resizeShapes($slide->getShapes(), $widthRatio, $heightRatio);
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

## **Často kladené otázky**

**Proč jsou tvary po změně velikosti snímku deformované nebo oříznuté?**

Pokud změníte velikost snímku bez škálování tvarů, zachovají si své původní umístění a rozměry a mohou přesahovat okraj snímku. Škálování šířky a výšky různými poměry může také tvary deformovat.

**Funguje poskytnutý kód pro všechny typy tvarů?**

První příklad mění ohraničení tvarů přímo a je určen pro snímky bez tabulek. Druhý příklad zpracovává tabulky samostatně. Zkontrolujte výsledné rozvržení, zejména text a tabulky, protože tyto příklady neskálují velikost písma a obsah tabulky může omezovat výšku řádků.

**Jak změnit velikost tabulek při změně velikosti snímku?**

Škálujte šířky sloupců podle poměru šířky a minimální výšky řádků podle poměru výšky, potom škálujte pozici tabulky, jak je ukázáno ve druhém příkladu.

**Bude tato změna velikosti fungovat pro hlavní snímky a rozvrhové snímky?**

Ano. Druhý příklad prochází [Presentation::getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getmasters/) a každým hlavním snímkem [MasterSlide::getLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/getlayoutslides/) a aplikuje stejnou logiku změny velikosti na jejich tvary.

**Mohu změnit orientaci snímku (svislá/vodorovná) spolu se změnou velikosti?**

Ano. Zavolejte [SlideSize::setOrientation](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setorientation/) po změně velikosti snímku a před načtením cílových rozměrů, aby škálovací faktory odrážely konečnou orientaci.

**Existuje omezení velikosti snímku, kterou mohu nastavit?**

Můžete zadat vlastní rozměry snímku pomocí [SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/). Podporované rozměry také závisí na formátu prezentace a aplikaci, která soubor otevře.

**Jak mohu zabránit, aby tvary s pevným poměrem stran byly deformovány?**

Použijte stejný škálovací faktor pro šířku i výšku. Pro umístění původního rozvržení do nových rozměrů snímku použijte menší z poměrů šířky a výšky pro obě rozměry a pozice. To zachová proporce, ale může na jedné straně zanechat nevyužitý prostor.