---
title: Optimera bildhantering i presentationer med PHP
linktitle: Hantera bilder
type: docs
weight: 10
url: /sv/php-java/image/
keywords:
- lägga till bild
- lägga till foto
- ersätta bild
- bildsamling
- bildram
- länkad bild
- bakgrund
- lägga till PNG
- lägga till JPG
- lägga till SVG
- SVG till former
- externa SVG-resurser
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Lär dig hur du lägger till, återanvänder, länkar, ersätter och hanterar raster- och SVG-bilder i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för PHP via Java."
---
## **Introduktion**

Aspose.Slides för PHP via Java erbjuder flera sätt att arbeta med bilder, och varje sätt har ett annat syfte. Du kan lagra en bild i en presentation, visa den i en bildram, använda den som en bildbakgrund, länka till en extern bild, ersätta en delad bildresurs eller konvertera SVG-innehåll till redigerbara former.

Denna artikel fokuserar på bildresurser och hur de används i en presentation. För beskärning, transparens, effekter, töjning och annan formatering som tillämpas på en enskild bildram, se [Picture Frame](/slides/sv/php-java/picture-frame/).

## **Förstå bildmodellen**

Följande API‑koncept är nära besläktade men inte utbytbara:

- Den [presentation image collection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/imagecollection/) lagrar bildresurser som används av presentationen. Använd [ImageCollection::addImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/imagecollection/) för att lägga till bilddata och få en [PPImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ppimage/)‑resurs.
- En [picture frame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pictureframe/) är en form som visar en bild på en bild, layout eller master. Använd [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapecollection/addpictureframe/) för att placera en bildresurs på en bild.
- En bildbakgrund använder en bild som en del av bildens fyllning snarare än som en form. Den beter sig därför inte som en picture frame.
- [PPImage::replaceImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ppimage/) ersätter en bildresurs. Om flera presentationselement använder den resursen, använder de alla ersättningen.
- Att konvertera en SVG till former skapar redigerbara bildformer. Efter konverteringen hanteras innehållet inte längre som en bildresurs.

Ett typiskt arbetsflöde är därför: lägg till bilddata i bildsamlingen, erhåll en [PPImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ppimage/), och använd sedan den resursen i en eller flera bildramar eller fyllningar.

## **Lägg till en inbäddad bild**

För att infoga en lokal bild, läs in filen, lägg till den i bildsamlingen och skapa en bildram som använder den returnerade `PPImage`.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $image = Images::fromFile("photo.png");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, $ppImage);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Bilden som läggs till på detta sätt är inbäddad i presentationen, så den resulterande filen är inte beroende av att den ursprungliga bildfilen fortfarande är tillgänglig.

### **Lägg till en bild från webben**

När en bild är tillgänglig via HTTP eller HTTPS, hämta dess byte, lägg till dem i presentationens bildsamling och använd den returnerade bildresursen på samma sätt som en lokal bild.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $imageUrl = new Java("java.net.URL", "https://example.com/image.png");
    $connection = $imageUrl->openConnection();
    $connection->setConnectTimeout(10000);
    $connection->setReadTimeout(10000);

    $inputStream = $connection->getInputStream();
    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    try {
        $buffer = $Array->newInstance($Byte, 8192);
        $bufferLength = $Array->getLength($buffer);

        while (($bytesRead = java_values($inputStream->read($buffer, 0, $bufferLength))) != -1) {
            $outputStream->write($buffer, 0, $bytesRead);
        }

        $ppImage = $presentation->getImages()->addImage($outputStream->toByteArray());
        $slide = $presentation->getSlides()->get_Item(0);
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, $ppImage);
    } finally {
        if (!java_is_null($inputStream)) {
            $inputStream->close();
        }
        $outputStream->close();
    }

    $presentation->save("presentation-from-web.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

I långlivade applikationer, återanvänd en HTTP‑klient eller en anslutningshanteringsstrategi som är lämplig för applikationen snarare än att upprepade gånger skapa onödig nätverksinfrastruktur. Validera också fjärr‑URL:er, svarsstorlekar och innehållstyper när källan inte är betrodd.

## **Återanvänd bilder på flera bilder**

Om samma bild behövs mer än en gång, lägg till den i presentationen en gång och återanvänd den returnerade [PPImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ppimage/) när du skapar ytterligare bildramar. Detta undviker att upprepade gånger ladda samma källdata och gör förhållandet mellan den delade bildresursen och dess användningar tydligt.

För grafik som ska visas automatiskt på många bilder, som en företagslogotyp, överväg att placera bildramen på en [slide master](/slides/sv/php-java/slide-master/) eller layout istället för att lägga till en motsvarande form på varje bild.

## **Använd en bild som bildbakgrund**

En bakgrundsbild tilldelas bildens fyllning; den läggs inte till som en picture‑frame‑form. Detta är användbart när bilden ska täcka bildbakgrunden och inte ska manipuleras som ett normalt bildobjekt.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = Images::fromFile("background.jpg");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Picture);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    $presentation->save("background-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

För ytterligare bakgrundsalternativ, inklusive master‑ och layoutbakgrunder, se [Presentation Background](/slides/sv/php-java/presentation-background/).

## **Inbäddade bilder och länkade bilder**

Inbäddade och länkade bilder har olika kompromisser när det gäller portabilitet och filstorlek:

- **Inbäddad bild:** bilddata lagras i presentationen. Presentationen är självständig, men filstorleken inkluderar bilddata.
- **Länkad bild:** presentationen lagrar en sökväg eller URL till en extern bild. Detta kan minska presentationens storlek, men den externa resursen måste förbli tillgänglig när presentationen öppnas eller renderas.

En länkad bild kan skapas genom att tilldela den externa sökvägen eller URL:en via [Picture::setLinkPathLong](https://reference.aspose.com/slides/sv/php-java/aspose.slides/picture/) istället för att bädda in bilddata.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, null);
    $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://example.com/image.png");

    $presentation->save("linked-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Använd länkade bilder endast när distributionsmiljön på ett pålitligt sätt kan komma åt den externa resursen. För presentationer som måste fungera offline eller flyttas mellan system är inbäddade bilder vanligtvis säkrare.

## **Arbeta med SVG‑bilder**

SVG är ett vektorformat, så det kan vara användbart för ikoner, diagram och annan grafik som ska skalas utan samma förlust av detaljer som rasterbilder. Aspose.Slides stödjer SVG både som en bildresurs och som källa för redigerbara bildformer.

### **Lägg till en SVG som bild**

Skapa en [SvgImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/svgimage/), lägg till den i bildsamlingen och placera den resulterande bildresursen i en bildram.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SvgImage;

$presentation = new Presentation();
try {
    $svgContent = file_get_contents("icon.svg");
    $svgImage = new SvgImage($svgContent);

    $ppImage = $presentation->getImages()->addImage($svgImage);
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 200, $ppImage);

    $presentation->save("svg-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **SVG‑filer med externa resurser**

En SVG kan referera till externa bilder, stilmallar eller typsnitt. För dessa fall erbjuder [SvgImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/svgimage/) konstruktorer som accepterar en [ExternalResourceResolver](https://reference.aspose.com/slides/sv/php-java/aspose.slides/externalresourceresolver/) och en bas‑URI. Resolvern kan kartlägga en relativ URI till en tillåten absolut URI och returnera en ström för den begärda resursen.

Resolvern gör externa resurser tillgängliga medan Aspose.Slides bearbetar SVG:n, men den omskriver inte SVG:n till ett självständigt dokument. Om SVG:n måste förbli portabel, bädda in dess nödvändiga resurser i själva SVG:n, till exempel genom att använda `data:`‑URI:er för länkade bilder.

När SVG‑filer kommer från opålitliga källor, begränsa de scheman, filplatser och värdar som resolvern kan komma åt. Nätverks‑resolvers bör också tillämpa tidsgränser, begränsningar för svarsstorlek och innehållsvalidering.

### **Konvertera SVG till redigerbara former**

Aspose.Slides kan konvertera en SVG till en grupp av redigerbara bildformer, liknande motsvarande PowerPoint‑kommando.

![PowerPoint Popup Menu](img_01_01.png)

Använd överlagringen [ShapeCollection::addGroupShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapecollection/addgroupshape/) som accepterar en [SvgImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/svgimage/) för att utföra konverteringen.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SvgImage;

$presentation = new Presentation();
try {
    $svgContent = file_get_contents("diagram.svg");
    $svgImage = new SvgImage($svgContent);

    $slideSize = $presentation->getSlideSize()->getSize();
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addGroupShape($svgImage, 0, 0, $slideSize->getWidth(), $slideSize->getHeight());

    $presentation->save("editable-svg-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Använd SVG‑till‑former‑konvertering när enskilda vektorelement behöver redigeras som PowerPoint‑former. Om SVG:n bara behöver visas är det enklare att behålla den som en bild och undvika att skapa många separata former.

## **Ersätt en befintlig bildresurs**

Använd [PPImage::replaceImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ppimage/) när du vill ersätta en befintlig bildresurs. Detta är särskilt användbart för delad grafik som logotyper.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $imageToReplace = $presentation->getImages()->get_Item(0);

    $replacementImage = Images::fromFile("new-logo.png");
    try {
        $imageToReplace->replaceImage($replacementImage);
    } finally {
        if (!java_is_null($replacementImage)) {
            $replacementImage->dispose();
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Om flera bildramar, bakgrunder, masters eller layouter använder samma bildresurs, uppdaterar ersättningen av resursen alla dessa användningar. Om bara en bildram ska ändras, tilldela en annan bild till den ramen istället för att ersätta den delade resursen.

`PPImage::replaceImage` ger också överlagringar som accepterar en byte‑array eller en annan [PPImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ppimage/).

## **Praktisk vägledning för bildhantering**

### **Kontrollera presentationens storlek**

Stora rasterbilder kan göra en presentation onödigt stor. Använd källbilder med dimensioner som passar deras avsedda visningsstorlek, återanvänd delade bildresurser där det är möjligt och undvik att bädda in upprepade kopior av samma fullupplösta grafik.

För rasterbilder som redan har placerats i bildramar kan [PictureFillFormat::compressImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/picturefillformat/) minska bilddata enligt den valda upplösningen och beskärningsinställningarna. Detta är bildram‑bearbetning snarare än hantering av bildsamlingen, så se [Picture Frame](/slides/sv/php-java/picture-frame/) för relaterade formateringsåtgärder.

### **Välj mellan inbäddat och länkat innehåll**

Inbäddning gör presentationen portabel eftersom all nödvändig bilddata följer med filen. Länkning kan minska filstorleken, men det introducerar ett externt beroende. Använd länkar endast när det beroendet är acceptabelt och stabilt.

### **Återanvänd delad varumärkesgrafik**

För upprepade logotyper, vattenstämplar eller dekorativ grafik, använd en bildresurs och återanvänd den. Om grafiken tillhör presentationens design snarare än bildens innehåll, placera den på en master eller layout så att den ärvs av de relevanta bilderna.

### **Håll SVG‑resurser portabla**

En självständig SVG är lättare att flytta och rendera konsekvent än en SVG som är beroende av externa filer eller nätverksresurser. När det är möjligt, bädda in nödvändiga resurser innan du importerar SVG:n. Konvertera SVG till former endast när de enskilda vektorelementen behöver redigeras.

### **Använd det moderna plattformsoberoende bild‑API‑et**

För ny PHP‑via‑Java‑kod, använd Aspose.Slides [IImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/iimage/) och [Images](https://reference.aspose.com/slides/sv/php-java/aspose.slides/images/)‑API:erna i stället för det äldre offentliga API‑et baserat på `java.awt.image.BufferedImage`. Se [Modern API](/slides/sv/php-java/modern-api/) för migrationsvägledning.

WMF och EMF kräver särskild hänsyn. När dessa format passerar genom en [IImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/iimage/), konverterar [ImageCollection::addImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/imagecollection/) metafilen till en raster‑PNG‑representation innan den infogas. Om det är viktigt att bevara metafildata, använd en ström‑baserad [ImageCollection::addImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/imagecollection/)‑överlagring i stället. Att generera EMF‑innehåll från kalkylblad eller andra produkter är ett separat integrationsarbetsflöde och ligger utanför räckvidden för den här artikeln.

## **FAQ**

**Vad är skillnaden mellan bildsamlingen och en bildram?**

Bildsamlingen lagrar återanvändbara bildresurser. En bildram är en bildform som visar en av dessa resurser och ger bildspecifik formatering såsom beskärning och effekter.

**Vad är det bästa sättet att ersätta samma logotyp överallt?**

Om logotypen redan delas som en bildresurs, ersätt den resursen med [PPImage::replaceImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ppimage/). För presentation‑omfattande varumärkesprofilering kan placering av logotypen på en master eller layout också minska duplicerat bildinnehåll.

**Varför försvinner en länkad bild på en annan dator?**

En länkad bild är beroende av sin externa fil eller URL. Om den resursen inte kan nås från den andra datorn kan den länkade bilden bli otillgänglig. Bädda in bilden när presentationen måste vara självständig.

**Kan en infogad SVG redigeras som PowerPoint‑former?**

Ja. Konvertera SVG:n med [ShapeCollection::addGroupShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapecollection/addgroupshape/); den resulterande gruppen innehåller redigerbara bildformer snarare än en SVG‑bild.

**Hur kan jag hålla presentationer med många bilder mindre?**

Återanvänd delade bildresurser, undvik onödigt stora rasterkällor, komprimera lämpliga rasterbilder när det är lämpligt, håll återkommande varumärkesgrafik på masters eller layouter, och använd länkade bilder endast när ett externt beroende är acceptabelt.