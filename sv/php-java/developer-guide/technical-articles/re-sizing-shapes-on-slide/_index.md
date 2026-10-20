---
title: Ändra storlek på former i presentationsbilder i PHP
type: docs
weight: 130
url: /sv/php-java/resizing-shapes-on-slide/
aliases:
  - /php-java/omskala-former-på-bild/
  - /sv/php-java/re-sizing-shapes-on-slide/
keywords:
  - ändra storlek på form
  - ändra formstorlek
  - PowerPoint
  - OpenDocument
  - presentation
  - PHP
  - Aspose.Slides
description: "Enkel ändring av storlek på former i PowerPoint- och OpenDocument-bilder med Aspose.Slides för PHP via Java—automatisera justering av bildlayout och öka produktiviteten."
---
## **Översikt**

När du ändrar en presentations bildstorlek kan det också vara nödvändigt att ändra storlek på och flytta om dess former för att passa de nya dimensionerna. Denna artikel visar hur man skalar former manuellt och hur man hanterar tabeller på bilder, mastern och layouter.

## **Ändra storlek på former**

För att bevara varje formes relativa position och storlek, multiplicera dess horisontella koordinater och bredd med förhållandet mellan den nya bildbredden och originalbredden. Tillämpa motsvarande höjdförhållande på dess vertikala koordinater och höjd.

Det första exemplet laddar en presentation vars bilder inte innehåller tabeller, ändrar bildstorleken till A4 och sparar resultatet. Det använder [SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/) med [SlideSizeScaleType::DoNotScale](https://reference.aspose.com/slides/php-java/aspose.slides/slidesizescaletype/) så att den efterföljande loopen styr skalningen. Förhållandena har ingen enhet; formernas positioner och dimensioner mäts i punkter. Olika bredd‑ och höjdförhållanden kan förvränga former, och ändring av en formes dimensioner skalar inte dess teckenstorlekar.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SlideSizeType;

$presentation = new Presentation("sample.pptx");
try {
        // Beräkna oberoende horisontella och vertikala skalningsfaktorer.
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
Tabeller kräver separat hantering: skala deras kolumnbredder och radhöjder istället för att tilldela tabellens totala bredd och höjd. Radhöjder kan förbli större än begärt om cellinnehållet kräver mer utrymme.
{{% /alert %}}

Det andra exemplet stödjer tabeller och bearbetar former på mastern och layouter samt enskilda bilder innan den ändrade presentationen sparas. Dess hjälparutrustning hanterar varje [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) genom att skala kolumnbredder med [Column::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/column/setwidth/) och minsta radhöjder med [Row::setMinimalHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/setminimalheight/). Därefter skalas tabellens position utan att separerat skala dess övergripande dimensioner.

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
                // Tabellens dimensioner styrs av kolumnbredder och radhöjder.
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
    // Beräkna oberoende horisontella och vertikala skalningsfaktorer.
    $originalSize = $presentation->getSlideSize()->getSize();
    $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
    $targetSize = $presentation->getSlideSize()->getSize();
    $widthRatio = java_values($targetSize->getWidth()) / java_values($originalSize->getWidth());
    $heightRatio = java_values($targetSize->getHeight()) / java_values($originalSize->getHeight());

    $resizer = new ShapeResizer();

    // Ändra storlek på former definierade på mastern och layouter samt enskilda bilder.
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

## **Vanliga frågor**

**Varför blir former förvrängda eller avklippta efter att en bild har ändrats i storlek?**

Om du ändrar bildstorleken utan att skala formerna behåller de sina ursprungliga positioner och dimensioner och kan sträcka sig utanför bilden. Att skala bredd och höjd med olika förhållanden kan också förvränga former.

**Fungerar den medföljande koden för alla typer av former?**

Det första exemplet ändrar formens gränser direkt och är avsett för bilder utan tabeller. Det andra exemplet hanterar tabeller separat. Kontrollera den resulterande layouten, särskilt text och tabeller, eftersom dessa exempel inte skalar teckenstorlekar och tabellinnehåll kan begränsa radhöjder.

**Hur ändrar jag storlek på tabeller när jag ändrar storlek på en bild?**

Skala kolumnbredder med breddförhållandet och minsta radhöjder med höjdförhållandet, skala sedan tabellens position, så som visat i det andra exemplet.

**Fungerar denna storleksändring för masternbilder och layoutbilder?**

Ja. Det andra exemplet itererar genom [Presentation::getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getmasters/) och varje masterns [MasterSlide::getLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/getlayoutslides/) och tillämpar samma storleksändringslogik på deras former.

**Kan jag ändra orienteringen på en bild (porträtt/landskap) samtidigt som jag ändrar storlek?**

Ja. Anropa [SlideSize::setOrientation](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setorientation/) efter att du har ändrat bildstorleken och innan du läser mål‑dimensionerna, så att skalningsfaktorerna speglar den slutgiltiga orienteringen.

**Finns det någon begränsning för bildstorleken jag kan ange?**

Du kan ange anpassade bilddimensioner med [SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/). De stödda dimensionerna beror också på presentationsformatet och programmet som används för att öppna filen.

**Hur kan jag förhindra att former med ett fast bildförhållande blir förvrängda?**

Använd samma skalningsfaktor för bredd och höjd. För att få den ursprungliga layouten att passa inom de nya bilddimensionerna, använd den mindre av bredd‑ och höjdförhållandena för både dimensioner och positioner. Detta bevarar proportionerna men kan lämna oanvänt utrymme längs en kant.