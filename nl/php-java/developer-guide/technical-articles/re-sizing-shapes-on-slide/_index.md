---
title: Vormgrootte aanpassen in presentatiedia's met PHP
type: docs
weight: 130
url: /nl/php-java/resizing-shapes-on-slide/
aliases:
  - /nl/php-java/re-sizing-shapes-on-slide/
keywords:
  - vormgrootte aanpassen
  - vormgrootte wijzigen
  - PowerPoint
  - OpenDocument
  - presentatie
  - PHP
  - Aspose.Slides
description: "Pas eenvoudig de grootte van vormen op PowerPoint- en OpenDocument-dia's aan met Aspose.Slides voor PHP via Java—automatiseer dia‑lay‑outaanpassingen en verhoog de productiviteit."
---
## **Overzicht**

Wanneer u de dia‑grootte van een presentatie wijzigt, moet u mogelijk ook de vormen aanpassen en verplaatsen zodat ze passen bij de nieuwe afmetingen. Dit artikel toont hoe u vormen handmatig schaalt en hoe u met tabellen op dia’s, masters en lay‑outs omgaat.

## **Vormen aanpassen**

Om de relatieve positie en grootte van elke vorm te behouden, vermenigvuldigt u de horizontale coördinaten en de breedte met de verhouding van de nieuwe dia‑breedte ten opzichte van de oorspronkelijke breedte. Pas de overeenkomstige hoogtedeling toe op de verticale coördinaten en de hoogte.

Het eerste voorbeeld laadt een presentatie waarvan de dia’s geen tabellen bevatten, wijzigt de dia‑grootte naar A4 en slaat het resultaat op. Het gebruikt [SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/) met [SlideSizeScaleType::DoNotScale](https://reference.aspose.com/slides/php-java/aspose.slides/slidesizescaletype/) zodat de daaropvolgende lus de schaal regelt. De verhoudingen zijn eenheidsloos; vormposities en -afmetingen worden gemeten in punten. Verschillende breedte‑ en hoogteverhoudingen kunnen vormen vervormen, en het wijzigen van de afmetingen van een vorm schaalt de lettergroottes niet.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SlideSizeType;

$presentation = new Presentation("sample.pptx");
try {
    // Bereken onafhankelijke horizontale en verticale schaalfactoren.
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
Tabellen vereisen afzonderlijke verwerking: schaal hun kolombreedtes en rijhoogtes in plaats van de totale breedte en hoogte van de tabel toe te wijzen. Rijhoogtes kunnen groter blijven dan gevraagd als de celinhoud meer ruimte nodig heeft.
{{% /alert %}}

Het tweede voorbeeld ondersteunt tabellen en verwerkt vormen op masters en lay‑outs evenals individuele dia’s voordat de aangepaste presentatie wordt opgeslagen. Zijn hulpprogramma behandelt elke [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) door kolombreedtes te schalen met [Column::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/column/setwidth/) en minimale rijhoogtes met [Row::setMinimalHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/setminimalheight/). Vervolgens schaalt het de positie van de tabel zonder de totale afmetingen afzonderlijk te schalen.

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
                // Tabelafmetingen worden gecontroleerd door kolombreedtes en rijhoogtes.
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
    // Bereken onafhankelijke horizontale en verticale schaalfactoren.
    $originalSize = $presentation->getSlideSize()->getSize();
    $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
    $targetSize = $presentation->getSlideSize()->getSize();
    $widthRatio = java_values($targetSize->getWidth()) / java_values($originalSize->getWidth());
    $heightRatio = java_values($targetSize->getHeight()) / java_values($originalSize->getHeight());

    $resizer = new ShapeResizer();

    // Schaalt vormen gedefinieerd op masters en lay‑outs evenals individuele dia’s.
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

## **FAQ**

**Waarom zijn vormen vervormd of afgesneden na het wijzigen van de dia‑grootte?**

Als u de dia‑grootte wijzigt zonder de vormen te schalen, behouden ze hun oorspronkelijke posities en afmetingen en kunnen ze buiten de dia uitsteken. Het schalen van breedte en hoogte met verschillende verhoudingen kan vormen ook vervormen.

**Werkt de meegeleverde code voor alle vormtypes?**

Het eerste voorbeeld wijzigt de vormgrenzen rechtstreeks en is bedoeld voor dia’s zonder tabellen. Het tweede voorbeeld behandelt tabellen afzonderlijk. Controleer de resulterende lay‑out, met name tekst en tabellen, omdat deze voorbeelden geen lettergroottes schalen en tabelinhoud de rijhoogtes kan beperken.

**Hoe schaalt ik tabellen bij het wijzigen van de dia‑grootte?**

Schaal kolombreedtes met de breedte‑verhouding en minimale rijhoogtes met de hoogte‑verhouding, en schaalt vervolgens de positie van de tabel, zoals getoond in het tweede voorbeeld.

**Werkt deze aanpassing voor master‑dia’s en lay‑outdia’s?**

Ja. Het tweede voorbeeld iterereert door [Presentation::getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getmasters/) en door de [MasterSlide::getLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/getlayoutslides/) van elke master en past dezelfde aanpassingslogica toe op hun vormen.

**Kan ik de oriëntatie van een dia (portret/landschap) aanpassen naast de grootte?**

Ja. Roep [SlideSize::setOrientation](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setorientation/) aan nadat u de dia‑grootte hebt gewijzigd en vóór het lezen van de doelafmetingen, zodat de schaalfactoren de uiteindelijke oriëntatie weerspiegelen.

**Is er een limiet aan de dia‑grootte die ik kan instellen?**

U kunt aangepaste dia‑afmetingen opgeven met [SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/). De ondersteunde afmetingen hangen ook af van het presentatie‑formaat en de applicatie die het bestand opent.

**Hoe kan ik voorkomen dat vormen met een vaste beeldverhouding vervormd worden?**

Gebruik dezelfde schaalfactor voor breedte en hoogte. Om de oorspronkelijke lay‑out in de nieuwe dia‑afmetingen te laten passen, gebruikt u de kleinste van de breedte‑ en hoogteverhoudingen voor zowel afmetingen als posities. Dit behoudt de verhoudingen, maar kan lege ruimte langs één rand achterlaten.