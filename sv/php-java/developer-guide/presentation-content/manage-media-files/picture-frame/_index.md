---
title: Hantera bildramar i presentationer med PHP
linktitle: Bildram
type: docs
weight: 10
url: /sv/php-java/picture-frame/
keywords:
- bildram
- lägga till bildram
- skapa bildram
- inbäddad bild
- länkad bild
- extrahera bild
- rasterbild
- SVG-bild
- beskära bild
- ta bort beskurna områden
- komprimera bild
- StretchOffset
- bildramformatering
- relativ skalning
- bildeffekt
- bildförhållande
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Skapa, formatera, länka, beskära, extrahera och komprimera bildramar i presentationer med Aspose.Slides för PHP via Java."
---
## **Översikt**

En bildram är ett bildformulär i en presentation som visar en bild. I Aspose.Slides är bildresursen och formen som visar den separata objekt: en [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) äger inbäddade bildresurser via sin [ImageCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/imagecollection/), medan en [PictureFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pictureframe/) styr bildens position, storlek, linjeformatering, rotation, beskärning, bild‑effekter och andra ram‑nivåinställningar.

Denna separation är användbar när samma bild visas mer än en gång. Lägg till bilden i presentationen en gång, behåll den returnerade [PPImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ppimage/), och använd den bildresursen när du skapar bildramar.

Bildramar kan innehålla rasterbilder såsom PNG eller JPEG och vektor‑SVG‑bilder. De kan också referera till länkade bilder istället för att lagra bild‑bytarna i presentationen. Valet påverkar portabilitet, filstorlek, extrahering och exportbeteende, så det är bra att bestämma hur bilden ska lagras innan formatering eller optimering appliceras.

## **Lägg till och formatera en inbäddad bild**

För en inbäddad bild, lägg till bilddata i presentationen och skapa en bildram med [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapecollection/addpictureframe/). Bilden blir en del av presentationspaketet, så presentationen förblir självständig när den flyttas till en annan dator.

Följande exempel lägger till en JPEG‑bild, skapar en ram med bildens ursprungliga dimensioner och applicerar linjeformatering och rotation:

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 100, $image->getWidth(), $image->getHeight(), $image);
    $pictureFrame->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $pictureFrame->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pictureFrame->getLineFormat()->setWidth(3);
    $pictureFrame->setRotation(15);

    $presentation->save("picture-frame.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Bildramen styr den visade geometrin; att ändra ramens storlek ändrar inte de ursprungliga pixel‑dimensionerna som lagras i den inbäddade bildresursen. Denna skillnad blir viktig när bilden beskärs eller komprimeras senare.

## **Använd relativ skalning**

[PictureFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pictureframe/) exponerar relativ bredd‑ och höjds­skalning för ramen via [setRelativeScaleWidth](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pictureframe/setrelativescalewidth/) och [setRelativeScaleHeight](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pictureframe/setrelativescaleheight/). Värdet `1.0` motsvarar 100 % av den ursprungliga bildstorleken. Relativ skalning är användbar när ett arbetsflöde måste bevara förhållandet till källbildens storlek istället för att beräkna slutdimensioner manuellt.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, $image);
    $pictureFrame->setRelativeScaleWidth(1.35);
    $pictureFrame->setRelativeScaleHeight(0.8);

    $presentation->save("relative-scale.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Relativ skalning ändrar ramens skalanvändning; den återprovar eller komprimerar inte den inbäddade bilden.

## **Inbäddade och länkade bilder**

En inbäddad bild lagrar bilddata i presentationen och är därför det säkraste valet för portabilitet och förutsägbar rendering. En länkad bild lagrar en extern plats via metoden [Picture::setLinkPathLong](https://reference.aspose.com/slides/sv/php-java/aspose.slides/picture/setlinkpathlong/) istället för att bädda in bilddata på samma sätt.

Länkade bilder kan minska mängden bilddata som lagras i PPTX, men de introducerar ett externt beroende. Den länkade filen måste förbli åtkomlig för programmet som öppnar eller renderar presentationen. Om sökvägen ändras, filen flyttas eller resursen blir otillgänglig, visas den länkade bilden kanske inte som förväntat. För presentationer som måste e‑postas, arkiveras eller renderas i isolerade miljöer är inbäddade bilder vanligtvis mer pålitliga.

### **Lägg till en länkad bild**

Följande exempel skapar en bildram och pekar den på en lokal bildfil. Det handlar endast om bildlänkning; videolänkning är ett separat mediearbetsflöde och blandas medvetet inte in i detta exempel.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 320, 180, null);
    $linkedImageFile = new Java("java.io.File", "linked-image.jpg");
    $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong($linkedImageFile->getAbsolutePath());

    $presentation->save("linked-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Använd länkar när extern filhantering är avsiktlig. Använd dem inte bara som ersättning för komprimering: en liten PPTX med brutna bildberoenden är vanligtvis mindre användbar än en större självständig presentation.

## **Extrahera bilder från bildramar**

Innan du extraherar en bild från en befintlig presentation, kontrollera att en form faktiskt är en [PictureFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pictureframe/) och att den innehåller en inbäddad bild. Länkade bildramar kan sakna bild‑bytar som kan extraheras på samma sätt.

### **Extrahera en rasterbild**

Det moderna bild‑API:t använder [IImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/iimage/) direkt. Följande exempel hittar den första inbäddade rasterbilden på en bild och sparar den som PNG:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            continue;
        }

        $embeddedImage = $shape->getPictureFormat()->getPicture()->getImage();
        if (java_is_null($embeddedImage) || !java_is_null($embeddedImage->getSvgImage())) {
            continue;
        }

        $rasterImage = $embeddedImage->getImage();
        try {
            $rasterImage->save("extracted-image.png", ImageFormat::Png);
        } finally {
            if (!java_is_null($rasterImage)) {
                $rasterImage->dispose();
            }
        }
        break;
    }
} finally {
    $presentation->dispose();
}
```

Att spara via [IImage::save](https://reference.aspose.com/slides/sv/php-java/aspose.slides/iimage/#save) konverterar den extraherade bilden till det begärda utdataformatet. Om du behöver de kodade bytarna som lagras i presentationen snarare än en konverterad rasterfil, använd bildresursens binära data istället.

### **Extrahera en SVG‑bild**

För en SVG‑bild exponerar [PPImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ppimage/) ett [SvgImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/svgimage/)-objekt. Detta låter dig hämta SVG‑data direkt i stället för att rasterisera bilden först.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            continue;
        }

        $embeddedImage = $shape->getPictureFormat()->getPicture()->getImage();
        $svgImage = java_is_null($embeddedImage) ? null : $embeddedImage->getSvgImage();
        if ($svgImage === null || java_is_null($svgImage)) {
            continue;
        }

        $outputStream = new Java("java.io.FileOutputStream", "extracted-image.svg");
        try {
            $outputStream->write($svgImage->getSvgData());
        } finally {
            $outputStream->close();
        }
        break;
    }
} finally {
    $presentation->dispose();
}
```

Att behålla SVG‑innehållet som SVG bevarar vektor‑källan i presentationen. Rasterexporter som PNG eller JPEG renderar nödvändigtvis vektor­innehållet till pixlar. PDF‑ eller SVG‑bildexport är också en renderingsoperation, så de exporterade grafikerna bör inte betraktas som en exakt byte‑för‑byte‑kopia av den inbäddade SVG:n; använd den inbäddade [SvgImage::getSvgData](https://reference.aspose.com/slides/sv/php-java/aspose.slides/svgimage/getsvgdata/)‑datan när den ursprungliga vektorresursen själv krävs.

## **Beskär en bild**

Beskärning ändrar vilken del av en bild som är synlig i ramen. Beskärningsvärdena på [PictureFillFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/picturefillformat/) är procentandelar av källbildens dimensioner. Beskärning tar initialt inte bort de dolda pixlarna från den inbäddade bilden; den ändrar bara den synliga regionen.

Följande exempel hittar en bildram på ett säkert sätt och applicerar beskärningsvärden:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $pictureFrame->getPictureFormat()->setCropLeft(23.6);
        $pictureFrame->getPictureFormat()->setCropRight(21.5);
        $pictureFrame->getPictureFormat()->setCropTop(3);
        $pictureFrame->getPictureFormat()->setCropBottom(31);
        $presentation->save("cropped-image.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Eftersom de dolda bildbytarna fortfarande finns kvar kan beskärningen ändras senare utan att förlora de ursprungliga pixlarna. Om filstorlek är viktigare än återhämtningsmöjlighet kan de beskurna regionerna fysiskt tas bort enligt nästa avsnitt.

## **Ta bort beskurna bilddata**

[PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/sv/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) tar bort bilddata utanför den aktuella beskärningsrektangeln och returnerar den resulterande bildresursen. Detta kan minska filstorleken, men det är en destruktiv optimering: efter att presentationen sparats är de borttagna pixlarna inte längre tillgängliga för en senare avbeskärning.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("cropped-image.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $croppedImage = $pictureFrame->getPictureFormat()->deletePictureCroppedAreas();
        if (!java_is_null($croppedImage)) {
            $presentation->save("cropped-data-removed.pptx", SaveFormat::Pptx);
        }
    }
} finally {
    $presentation->dispose();
}
```

Metoden kan lägga till en ny bildresurs i presentationen. Om den ursprungliga bilden även används av andra bildramar, behöver de fortfarande sin befintliga resurs, så att radera beskurna områden inte nödvändigtvis minskar det totala antalet bilder. Att beskära WMF‑ eller EMF‑innehåll med denna metod rasteriserar det beskurna resultatet till PNG.

## **Komprimera rasterbilder**

[PictureFillFormat::compressImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) minskar rasterbildens upplösning i förhållande till den storlek som bilden visas i. Den kan också ta bort beskurna regioner i samma operation. Metoden returnerar `true` när bilden har storleksändrats eller beskärts och `false` när ingen förändring var nödvändig.

Använd ett fördefinierat [PicturesCompression](https://reference.aspose.com/slides/sv/php-java/aspose.slides/picturescompression/)‑värde när en standard mål‑upplösning är tillräcklig:

```php
use aspose\slides\PicturesCompression;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $compressed = $pictureFrame->getPictureFormat()->compressImage(true, PicturesCompression::Dpi150);
        echo $compressed ? "The image was compressed." : "No compression was necessary.";
        $presentation->save("compressed-image.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Ett eget positivt DPI‑värde kan skickas istället för ett fördefinierat värde när ett specifikt mål krävs.

Kompression är avsedd för rasterbilder. SVG‑ och metafil‑innehåll minskas inte av detta rasterkompressionsarbetsflöde. Kom också ihåg att lägre upplösning och borttagna beskurna regioner inte kan återställas från den optimerade presentationen. Välj en mål‑upplösning baserat på den största storlek som bilden faktiskt kommer att visas eller exporteras i, snarare än att globalt använda den lägsta DPI‑nivån.

## **Hantera bildtransform‑effekter**

För ett komplett arbetsflöde som täcker ljusstyrka, kontrast, färgtransformeringar, suddighet, alfa‑effekter, ordnade kedjor, inspektion, borttagning och round‑trip‑verifiering, se [Image Transform Effects](/php-java/image-transform-effects/).

## **Lås bildramens geometri**

[PictureFrameLock](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pictureframelock/)‑inställningarna styr vilka redigeringsåtgärder som är inaktiverade för en bildram. Till exempel bevarar [setAspectRatioLocked](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) formens proportioner medan den ändras i storlek.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 100, $image->getWidth(), $image->getHeight(), $image);
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);

    $presentation->save("locked-picture-frame.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Låset gäller bildramformen. Det tvingar inte källbilden att återprovas eller permanent förändras till samma bildförhållande.

## **Justera StretchOffset‑värdena**

När bildfylningsläget är stretch definierar stretch‑offset‑värdena på [PictureFillFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/picturefillformat/) fyllningsrektangeln relativt bildramens begränsningsruta. Positiva procent skapar ett indrag från en kant, medan negativa procent skapar ett utstickande.

Detta skiljer sig från beskärning. Beskärningsvärden väljer vilken del av källbilden som är synlig; stretch‑offset ändrar rektangeln som den synliga bildfyllningen sträcks in i.

```php
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 400, 300, $image);
    $pictureFrame->getPictureFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $pictureFrame->getPictureFormat()->setStretchOffsetLeft(12);
    $pictureFrame->getPictureFormat()->setStretchOffsetRight(12);
    $pictureFrame->getPictureFormat()->setStretchOffsetTop(8);
    $pictureFrame->getPictureFormat()->setStretchOffsetBottom(8);

    $presentation->save("stretch-offsets.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Använd stretch‑offset för fyllningsplacering. Använd beskärnings‑egenskaper när målet är att dölja kanter i källbilden.

## **Lagring, filstorlek och exportaspekter**

De viktigaste avvägningarna blir enklare att hantera när bildlagring och bildram‑formatering behandlas separat:

- **Inbäddade bilder** gör presentationen självständig och är det mest pålitliga valet för delning och server‑sida rendering, men stora rasterbilder ökar PPTX‑storlek och minnesanvändning.
- **Länkade bilder** kan hålla paketet mindre, men presentationen är beroende av att externa filer förblir tillgängliga på de lagrade sökvägarna eller platserna.
- **Beskärning** är initialt icke‑destruktiv. De dolda pixlarna förblir inbäddade tills beskurna områden explicit tas bort eller avlägsnas vid komprimering.
- **Komprimering** kan minska filstorleken avsevärt för överdimensionerade rasterbilder, men den offrar källupplösning. Den bör appliceras efter att den avsedda storleken på bilden på bilden är känd.
- **SVG‑bilder** bör behållas som SVG när vektor‑bevarande är viktigt. Extrahera den inbäddade SVG:n direkt när du behöver vektorresursen själv. Raster‑slide‑exporter konverterar alltid den renderade sliden till pixlar.
- **Upprepade bilder** bör återanvända en befintlig [PPImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ppimage/)‑resurs när det är möjligt i stället för att upprepade gånger ladda samma fil i presentationsarbetsflödet.

För stora presentationer är bildoptimering vanligtvis mest effektiv när den utförs selektivt: behåll logotyper och diagram som vektor­innehåll, komprimera fotografier enligt deras faktiska visningsstorlek, ta bort beskurna pixlar endast när senare redigering inte krävs, och undvik externa länkar om inte beroendehantering är en del av distributionsdesignen.

## **FAQ**

**Vad är skillnaden mellan en bildram och en bildresurs?**

En [PPImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ppimage/) representerar en bildresurs som är associerad med presentationen. En [PictureFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pictureframe/) är en form på en bild som visar en bild och lagrar ram‑nivå‑geometri och formatering såsom storlek, rotation, beskärningsvärden, effekter och lås.

**Ska jag bädda in eller länka bilder?**

Bädda in bilder när presentationen måste vara portabel, arkiverad eller renderas utan åtkomst till externa resurser. Länka bilder endast när det är avsiktligt att hålla bildfiler utanför PPTX och de externa platserna kan underhållas på ett pålitligt sätt.

**Minskar beskärning PPTX‑filstorleken?**

Inte i sig. Vanliga beskärningsinställningar döljer delar av källbilden men behåller de underliggande pixlarna. Använd [PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/sv/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) eller bildkomprimering med borttagning av beskurna områden när dessa pixlar kan tas bort permanent.

**Kan jag återställa bildkvaliteten efter kompression?**

Nej. Kompression kan reducera lagrad raster‑upplösning, och att ta bort beskurna regioner kastar bort bilddata. Behåll originalbilden utanför presentationen om senare högupplöst redigering kan behövas.

**Hur bör SVG‑bilder hanteras?**

Behåll SVG‑innehållet som SVG när vektor‑fidelity är viktig. Den inbäddade [SvgImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/svgimage/) kan extraheras direkt. Rendering av en slide till ett rasterformat som PNG eller JPEG rasteriserar SVG:n som en del av slide‑bilden.

**Hur kan jag undvika osäkra typ­kastningar när jag läser befintliga slides?**

Kontrollera formtypen innan du använder bild‑ram‑specifika medlemmar. En `java_instanceof`‑kontroll mot [PictureFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pictureframe/) undviker ogiltiga kast och låter koden hantera slides som inte innehåller bildramar.