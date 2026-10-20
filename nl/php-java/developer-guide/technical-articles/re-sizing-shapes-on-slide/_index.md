---
title: Vormen aanpassen op presentatiedia's in PHP
type: docs
weight: 130
url: /nl/php-java/resizing-shapes-on-slide/
aliases:
  - /php-java/re-sizing-shapes-on-slide/
  - /nl/php-java/re-sizing-shapes-on-slide/
keywords:
- vorm aanpassen
- vormgrootte wijzigen
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Pas eenvoudig vormen aan op PowerPoint- en OpenDocument-dias met Aspose.Slides voor PHP via Java - automatiseer dia-indelingsaanpassingen en verhoog de productiviteit."
---
## **Overzicht**

Wanneer u de diaformaat van een presentatie wijzigt, moet u mogelijk ook de vormen herschalen en verplaatsen zodat ze passen binnen de nieuwe afmetingen. Dit artikel laat zien hoe u vormen handmatig kunt schalen en hoe u tabellen op dia's, masters en lay‑outs kunt behandelen.

## **Vormen herschalen**

Om de relatieve positie en grootte van elke vorm te behouden, vermenigvuldigt u de horizontale coördinaten en de breedte met de verhouding van de nieuwe dia‑breedte ten opzichte van de oorspronkelijke breedte. Pas de overeenkomstige hoogtverhouding toe op de verticale coördinaten en de hoogte.

Het eerste voorbeeld laadt een presentatie waarvan de dia's geen tabellen bevatten, wijzigt het diaformaat naar A4 en slaat het resultaat op. Het gebruikt [SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/) met [SlideSizeScaleType::DoNotScale](https://reference.aspose.com/slides/php-java/aspose.slides/slidesizescaletype/) zodat de daaropvolgende lus de schaalvergroting regelt. De verhoudingen zijn eenheidloos; vormposities en -afmetingen worden gemeten in punten. Verschillende breedte‑ en hoogteverhoudingen kunnen vormen vervormen, en het wijzigen van de afmetingen van een vorm schaalt de lettergrootten niet.

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
Tabellen vereisen afzonderlijke behandeling: schaalt hun kolombreedtes en rijhoogtes in plaats van de totale breedte en hoogte van de tabel toe te wijzen. Rijhoogtes kunnen groter blijven dan gevraagd wanneer de celinhoud meer ruimte vereist.
{{% /alert %}}

Het tweede voorbeeld ondersteunt tabellen en verwerkt vormen op masters en lay‑outs, evenals op individuele dia's, voordat de aangepaste presentatie wordt opgeslagen. De helper behandelt elke [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) door kolombreedtes te schalen met [Column::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/column/setwidth/) en minimale rijhoogtes met [Row::setMinimalHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/setminimalheight/). Vervolgens schaalt hij de positie van de tabel zonder de totale afmetingen afzonderlijk te schalen.

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
                // Tabelafmetingen worden bepaald door kolombreedtes en rijhoogtes.
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

    // Vormen schalen die gedefinieerd zijn op masters en lay‑outs, evenals op individuele dia's.
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

## **Veelgestelde vragen**

**Waarom worden vormen vervormd of afgeknipt na het wijzigen van een diaformaat?**

Als u het diaformaat wijzigt zonder de vormen te schalen, behouden ze hun oorspronkelijke posities en afmetingen en kunnen ze buiten de dia uitsteken. Het schalen van breedte en hoogte met verschillende verhoudingen kan vormen ook vervormen.

**Werkt de meegeleverde code voor alle vormtypen?**

Het eerste voorbeeld wijzigt de grenzen van vormen rechtstreeks en is bedoeld voor dia's zonder tabellen. Het tweede voorbeeld behandelt tabellen apart. Controleer de resulterende lay‑out, met name tekst en tabellen, omdat deze voorbeelden de lettergroottes niet schalen en de inhoud van tabellen de rijhoogtes kan beperken.

**Hoe schaalt u tabellen bij het wijzigen van een diaformaat?**

Schaal kolombreedtes met de breedte‑verhouding en minimale rijhoogtes met de hoogte‑verhouding, en schaalt vervolgens de positie van de tabel, zoals getoond in het tweede voorbeeld.

**Werkt deze aanpassing ook voor masters en lay‑outdia's?**

Ja. Het tweede voorbeeld doorloopt [Presentation::getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getmasters/) en voor elke master de [MasterSlide::getLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/getlayoutslides/) en past dezelfde aanpassingslogica toe op hun vormen.

**Kan ik de oriëntatie van een dia (staand/liggend) wijzigen samen met het aanpassen van de grootte?**

Ja. Roep [SlideSize::setOrientation](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setorientation/) aan nadat u het diaformaat hebt gewijzigd en vóór het lezen van de doeldimensies, zodat de schaalfactoren de uiteindelijke oriëntatie weerspiegelen.

**Is er een limiet aan het diaformaat dat ik kan instellen?**

U kunt aangepaste dia‑afmetingen opgeven met [SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/). De ondersteunde afmetingen hangen ook af van het presentatieformaat en de applicatie die het bestand opent.

**Hoe kan ik voorkomen dat vormen met een vaste beeldverhouding vervormd raken?**

Gebruik dezelfde schaalfactor voor breedte en hoogte. Om de oorspronkelijke lay‑out binnen de nieuwe dia‑afmetingen te laten passen, gebruikt u de kleinere van de breedte‑ en hoogte‑verhoudingen voor zowel de afmetingen als de posities. Dit behoudt de verhoudingen, maar kan onbenutte ruimte langs één rand achterlaten.