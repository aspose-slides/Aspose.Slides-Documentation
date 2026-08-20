---
title: Beheer afbeeldingskaders in presentaties op Android
linktitle: Afbeeldingskader
type: docs
weight: 10
url: /nl/androidjava/picture-frame/
keywords:
- afbeeldingskader
- afbeeldingskader toevoegen
- afbeeldingskader maken
- ingesloten afbeelding
- gekoppelde afbeelding
- afbeelding extraheren
- rasterafbeelding
- SVG-afbeelding
- afbeelding bijsnijden
- bijgesneden gebieden verwijderen
- afbeelding comprimeren
- StretchOffset
- opmaak van afbeeldingskader
- relatieve schaal
- afbeeldingseffect
- beeldverhouding
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Maak, formatteer, koppel, snijd bij, extraheer en comprimeer afbeeldingskaders in presentaties met Aspose.Slides voor Android via Java."
---
## **Overzicht**

Een afbeeldingskader is een diavorm die een afbeelding weergeeft. In Aspose.Slides zijn de afbeeldingsbron en de vorm die de afbeelding toont afzonderlijke objecten: een [Presentatie](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) bezit ingesloten afbeeldingsbronnen via zijn [IImageCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iimagecollection/), terwijl een [IPictureFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipictureframe/) de positie, grootte, lijnopmaak, rotatie, bijsnijden, afbeeldingeffecten en andere kaderinggerelateerde instellingen van de afbeelding regelt.

Deze scheiding is handig wanneer dezelfde afbeelding meer dan één keer wordt getoond. Voeg de afbeelding eenmaal toe aan de presentatie, bewaar de geretourneerde [IPPImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ippimage/), en gebruik die afbeeldingsbron bij het maken van afbeeldingskaders.

Afbeeldingskaders kunnen rasterafbeeldingen zoals PNG of JPEG en vector‑SVG‑afbeeldingen bevatten. Ze kunnen ook verwijzen naar gekoppelde afbeeldingen in plaats van de afbeeldingsbytes in de presentatie op te slaan. De keuze heeft invloed op draagbaarheid, bestandsgrootte, extractie‑ en exportgedrag, dus het is nuttig om vóór het toepassen van opmaak of optimalisatie te bepalen hoe de afbeelding moet worden opgeslagen.

## **Een ingesloten afbeelding toevoegen en opmaken**

Voor een ingesloten afbeelding voeg je de afbeeldingsgegevens toe aan de presentatie en maak je een afbeeldingskader met [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-). De afbeelding wordt onderdeel van het presentatiedossier, waardoor de presentatie autonoom blijft wanneer deze naar een andere computer wordt verplaatst.

Het volgende voorbeeld voegt een JPEG‑afbeelding toe, maakt een kader met de oorspronkelijke afmetingen van de afbeelding en past lijnopmaak en rotatie toe:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pictureFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pictureFrame.getLineFormat().setWidth(3);
    pictureFrame.setRotation(15);

    presentation.save("picture-frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het afbeeldingskader bepaalt de weergegeven geometrie; het wijzigen van de kadergrootte verandert de oorspronkelijke pixelafmetingen die in de ingesloten afbeeldingsbron zijn opgeslagen. Dit onderscheid wordt belangrijk bij later bijsnijden of comprimeren van een afbeelding.

## **Relatieve schaal gebruiken**

[IPictureFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipictureframe/) biedt relatieve breedte‑ en hoogte‑schaal voor het kader via [setRelativeScaleWidth](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) en [setRelativeScaleHeight](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-). Een waarde van `1.0` komt overeen met 100 % van de oorspronkelijke afbeeldingsgrootte. Relatieve schaal is nuttig wanneer een workflow de verhouding tot de bronafbeeldingsgrootte moet behouden in plaats van de uiteindelijke afmetingen handmatig te berekenen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image);
    pictureFrame.setRelativeScaleWidth(1.35f);
    pictureFrame.setRelativeScaleHeight(0.8f);

    presentation.save("relative-scale.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Relatieve schaal wijzigt de schaalinstellingen van het kader; het herschaalt of comprimeert de ingesloten afbeelding niet.

## **Ingesloten en gekoppelde afbeeldingen**

Een ingesloten afbeelding slaat afbeeldingsgegevens op binnen de presentatie en is daarmee de veiligste keuze voor draagbaarheid en voorspelbare weergave. Een gekoppelde afbeelding slaat een externe locatie op via de [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-)‑methode in plaats van de afbeeldingsgegevens in te sluiten.

Gekoppelde afbeeldingen kunnen de hoeveelheid afbeeldingsdata in de PPTX verminderen, maar ze introduceren een externe afhankelijkheid. Het gekoppelde bestand moet toegankelijk blijven voor de toepassing die de presentatie opent of rendert. Als het pad verandert, het bestand wordt verplaatst of de bron niet beschikbaar is, wordt het gekoppelde beeld mogelijk niet zoals verwacht weergegeven. Voor presentaties die moeten worden gemaild, gearchiveerd of gerenderd in geïsoleerde omgevingen, zijn ingesloten afbeeldingen doorgaans betrouwbaarder.

### **Een gekoppelde afbeelding toevoegen**

Het volgende voorbeeld maakt een afbeeldingskader en wijst dit naar een lokaal afbeeldingsbestand. Het behandelt alleen afbeeldingskoppelingen; videokoppelingen zijn een aparte mediastroom en worden bewust niet in dit voorbeeld gemengd.

```java
import com.aspose.slides.*;
import java.io.File;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, null);
    File linkedImageFile = new File("linked-image.jpg");
    String linkPath = linkedImageFile.getAbsolutePath();
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong(linkPath);

    presentation.save("linked-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Gebruik koppelingen wanneer extern bestandsbeheer opzettelijk is. Gebruik ze niet enkel als vervanging voor compressie: een kleine PPTX met gebroken afbeeldingsafhankelijkheden is meestal minder bruikbaar dan een grotere, zelf‑behorende presentatie.

## **Afbeeldingen uit afbeeldingskaders extraheren**

Controleer vóór het extraheren van een afbeelding uit een bestaande presentatie of een vorm daadwerkelijk een [IPictureFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipictureframe/) is en of deze een ingesloten afbeelding bevat. Gekoppelde afbeeldingskaders bevatten mogelijk geen afbeeldingsbytes die op dezelfde manier geëxtraheerd kunnen worden.

### **Een rasterafbeelding extraheren**

De moderne afbeelding‑API gebruikt direct [IImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iimage/) en vereist de oudere Java‑afbeeldingswrapper niet. Het volgende voorbeeld zoekt de eerste ingesloten rasterafbeelding op een dia en slaat deze op als PNG:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IPictureFrame)) {
            continue;
        }

        IPictureFrame pictureFrame = (IPictureFrame) shape;
        IPPImage embeddedImage = pictureFrame.getPictureFormat().getPicture().getImage();
        if (embeddedImage == null || embeddedImage.getSvgImage() != null) {
            continue;
        }

        IImage rasterImage = embeddedImage.getImage();
        try {
            rasterImage.save("extracted-image.png", ImageFormat.Png);
        } finally {
            rasterImage.dispose();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

Opslaan via [IImage.save](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) converteert de geëxtraheerde afbeelding naar het gevraagde uitvoerformaat. Als je de gecodeerde bytes wilt die in de presentatie zijn opgeslagen in plaats van een geconverteerd rasterbestand, gebruik dan de binaire gegevens van de afbeeldingsbron.

### **Een SVG‑afbeelding extraheren**

Voor een SVG‑afbeelding geeft de [IPPImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ippimage/) een [ISvgImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isvgimage/)‑object vrij. Hiermee kun je de SVG‑gegevens direct ophalen in plaats van de afbeelding eerst te rasteren.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IPictureFrame)) {
            continue;
        }

        IPictureFrame pictureFrame = (IPictureFrame) shape;
        IPPImage embeddedImage = pictureFrame.getPictureFormat().getPicture().getImage();
        ISvgImage svgImage = embeddedImage != null ? embeddedImage.getSvgImage() : null;
        if (svgImage == null) {
            continue;
        }

        byte[] svgData = svgImage.getSvgData();
        FileOutputStream outputStream = new FileOutputStream("extracted-image.svg");
        try {
            outputStream.write(svgData);
        } finally {
            outputStream.close();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

Het bewaren van SVG‑inhoud als SVG behoudt de vectorbron binnen de presentatie. Raster‑exporten zoals PNG of JPEG moeten die vectorinhoud renderen tot pixels. PDF‑ of SVG‑dia‑export is ook een render‑bewerking, dus de geëxporteerde graphics mogen niet worden beschouwd als een byte‑voor‑byte‑kopie van de oorspronkelijke ingesloten SVG; gebruik de ingesloten [ISvgImage.getSvgData](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isvgimage/#getSvgData--)‑gegevens wanneer de oorspronkelijke vectorbron zelf vereist is.

## **Een afbeelding bijsnijden**

Bijsnijden bepaalt welk deel van een afbeelding binnen het kader zichtbaar is. De bijsnijdwaarden op [IPictureFillFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipicturefillformat/) zijn percentages van de bronafbeeldingsafmetingen. Bijsnijden verwijdert de verborgen pixels niet onmiddellijk uit de ingesloten afbeelding; het verandert alleen het zichtbare gebied.

Het volgende voorbeeld zoekt veilig een afbeeldingskader en past bijsnijdwaarden toe:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        pictureFrame.getPictureFormat().setCropLeft(23.6f);
        pictureFrame.getPictureFormat().setCropRight(21.5f);
        pictureFrame.getPictureFormat().setCropTop(3f);
        pictureFrame.getPictureFormat().setCropBottom(31f);
        presentation.save("cropped-image.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Omdat de verborgen afbeeldingsdata nog aanwezig is, kan de bijsnijding later worden aangepast zonder de originele pixels te verliezen. Als bestandsgrootte belangrijker is dan omkeerbaarheid, kunnen de bijgesneden regio's fysiek worden verwijderd zoals beschreven in de volgende sectie.

## **Bijsneden afbeeldingsdata verwijderen**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) verwijdert afbeeldingsdata buiten het huidige bijsnijd‑rechthoek en retourneert de resulterende afbeeldingsbron. Dit kan de bestandsgrootte verkleinen, maar het is een destructieve optimalisatie: nadat de presentatie is opgeslagen, zijn de verwijderde pixels niet meer beschikbaar voor een latere ontbijsnijd‑bewerking.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("cropped-image.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IPPImage croppedImage = pictureFrame.getPictureFormat().deletePictureCroppedAreas();
        if (croppedImage != null) {
            presentation.save("cropped-data-removed.pptx", SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

De methode kan een nieuwe afbeeldingsbron aan de presentatie toevoegen. Als de oorspronkelijke afbeelding ook door andere afbeeldingskaders wordt gebruikt, hebben die kaders nog steeds hun bestaande bron nodig, zodat het verwijderen van bijgesneden gebieden niet per se het totale aantal afbeeldingen vermindert. Het bijsnijden van WMF‑ of EMF‑inhoud met deze methode rastert het bijgesneden resultaat naar PNG.

## **Rasterafbeeldingen comprimeren**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) vermindert de resolutie van een rasterafbeelding ten opzichte van de grootte waarin de afbeelding wordt weergegeven. Het kan ook bijgesneden regio's in dezelfde bewerking verwijderen. De methode retourneert `true` wanneer de afbeelding is verkleind of bijgesneden en `false` wanneer geen wijziging nodig was.

Gebruik een vooraf gedefinieerde [PicturesCompression](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/picturescompression/)‑waarde wanneer een standaarddoelresolutie voldoende is:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        boolean compressed = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);
        System.out.println(compressed ? "The image was compressed." : "No compression was necessary.");
        presentation.save("compressed-image.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Een aangepaste positieve DPI‑waarde kan worden doorgegeven in plaats van een vooraf gedefinieerde waarde wanneer een specifiek doel vereist is.

Compressie is bedoeld voor rasterafbeeldingen. SVG‑ en metabestand‑inhoud wordt niet gereduceerd door deze raster‑compressieworkflow. Houd er ook rekening mee dat een lagere resolutie en verwijderde bijgesneden regio's niet kunnen worden hersteld uit de geoptimaliseerde presentatie. Kies een doelresolutie gebaseerd op de grootste weergave‑ of exportgrootte van de afbeelding in plaats van globaal de laagste DPI toe te passen.

## **Afbeeldingeffecten inspecteren**

Afbeeldingeffecten worden opgeslagen op de afbeelding die door het kader wordt gebruikt. De afbeeldingstransformatiereeks kan effecten bevatten zoals vaste alfa‑modulatie voor transparantie en luminantie voor helderheid en contrast. Het onderstaande voorbeeld leest veilig beide soorten effecten van het eerste afbeeldingskader op een dia:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        for (IImageTransformOperation effect : imageTransform) {
            if (effect instanceof IAlphaModulateFixed) {
                IAlphaModulateFixed alphaModulateFixed = (IAlphaModulateFixed) effect;
                float transparency = 100 - alphaModulateFixed.getAmount();
                System.out.println("Transparency: " + transparency);
            }

            if (effect instanceof ILuminance) {
                ILuminance luminanceEffect = (ILuminance) effect;
                ILuminanceEffectiveData luminance = luminanceEffect.getEffective();
                System.out.println("Brightness: " + luminance.getBrightness());
                System.out.println("Contrast: " + luminance.getContrast());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Deze effecten wijzigen hoe de afbeelding in het kader wordt gerenderd; ze herschrijven niet de originele ingesloten afbeeldingsbytes.

## **Geometrie van het afbeeldingskader vergrendelen**

De [IPictureFrameLock](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipictureframelock/)‑instellingen bepalen welke bewerkingsacties voor een afbeeldingskader zijn uitgeschakeld. Bijvoorbeeld, [setAspectRatioLocked](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) behoudt de proporties van de vorm terwijl deze wordt geschaald.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);

    presentation.save("locked-picture-frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De vergrendeling heeft betrekking op de vorm van het afbeeldingskader. Het dwingt de bronafbeelding niet om te worden herschaald of permanent omgezet naar dezelfde beeldverhouding.

## **De StretchOffset‑waarden aanpassen**

Wanneer de opvullingsmodus van de afbeelding is ingesteld op rek, bepalen de stretch‑offset‑waarden op [IPictureFillFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipicturefillformat/) het opvul‑rechthoek ten opzichte van de omhullende van het afbeeldingskader. Positieve percentages creëren een inspringing vanaf een rand, terwijl negatieve percentages een uitstulping creëren.

Dit verschilt van bijsnijden. Bijsnijdwaarden bepalen welk deel van de bronafbeelding zichtbaar is; stretch‑offsets wijzigen het rechthoek waarin de zichtbare afbeelding‑opvulling wordt uitgerekt.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image);
    pictureFrame.getPictureFormat().setPictureFillMode(PictureFillMode.Stretch);
    pictureFrame.getPictureFormat().setStretchOffsetLeft(12f);
    pictureFrame.getPictureFormat().setStretchOffsetRight(12f);
    pictureFrame.getPictureFormat().setStretchOffsetTop(8f);
    pictureFrame.getPictureFormat().setStretchOffsetBottom(8f);

    presentation.save("stretch-offsets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Gebruik stretch‑offsets voor plaatsing van de opvulling. Gebruik bijsnijd‑eigenschappen wanneer je de randen van de bronafbeelding wilt verbergen.

## **Opslag, bestandsgrootte en exportoverwegingen**

De belangrijkste afwegingen zijn makkelijker te beheren wanneer afbeeldingopslag en kadering‑opmaak afzonderlijk worden behandeld:

- **Ingesloten afbeeldingen** maken de presentatie autonoom en zijn het meest betrouwbaar voor delen en server‑side rendering, maar grote rasterafbeeldingen vergroten de PPTX‑grootte en het geheugenverbruik.
- **Gekoppelde afbeeldingen** kunnen het pakket kleiner houden, maar de presentatie is afhankelijk van externe bestanden die beschikbaar moeten blijven op de opgeslagen paden of locaties.
- **Bijsnijden** is aanvankelijk niet‑destructief. De verborgen pixels blijven ingesloten totdat bijgesneden gebieden expliciet worden verwijderd of tijdens compressie worden weggehaald.
- **Compressie** kan de bestandsgrootte aanzienlijk verkleinen voor te grote rasterafbeeldingen, maar gaat ten koste van de bronresolutie. Het moet worden toegepast nadat de beoogde weergavegrootte op de dia bekend is.
- **SVG‑afbeeldingen** moeten als SVG behouden blijven wanneer vectorbehoud belangrijk is. Extraheer de ingesloten SVG direct wanneer je de vectorbron zelf nodig hebt. Raster‑dia‑exporten converteren altijd de gerenderde dia naar pixels.
- **Herhaalde afbeeldingen** moeten een bestaande [IPPImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ippimage/)‑bron hergebruiken wanneer mogelijk in plaats van steeds opnieuw hetzelfde bestand in de presentatieworkflow te laden.

Voor grote presentaties is afbeeldingoptimalisatie meestal het meest effectief wanneer selectief wordt toegepast: behoud logo’s en diagrammen als vectorinhoud, comprimeer foto’s volgens hun werkelijke weergavegrootte, verwijder bijgesneden pixels alleen wanneer latere bewerking niet vereist is, en vermijd externe koppelingen tenzij afhankelijkheidsbeheer deel uitmaakt van het implementatie‑ontwerp.

## **FAQ**

**Wat is het verschil tussen een afbeeldingskader en een afbeeldingsbron?**

Een [IPPImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ippimage/) vertegenwoordigt een afbeeldingsbron die aan de presentatie is gekoppeld. Een [IPictureFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipictureframe/) is een vorm op een dia die een afbeelding weergeeft en kadering‑gerelateerde geometrie en opmaak opslaat, zoals grootte, rotatie, bijsnijdwaarden, effecten en vergrendelingen.

**Moet ik afbeeldingen insluiten of koppelen?**

Sluit afbeeldingen in wanneer de presentatie draagbaar, gearchiveerd of gerenderd moet kunnen worden zonder toegang tot externe bronnen. Koppel afbeeldingen alleen wanneer het buiten de PPTX houden van afbeeldingsbestanden opzettelijk is en de externe locaties betrouwbaar kunnen worden onderhouden.

**Vermindert bijsnijden de PPTX‑grootte?**

Niet op zichzelf. Normale bijsnijdinstellingen verbergen delen van de bronafbeelding maar behouden de onderliggende pixels. Gebruik [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) of compressie met verwijdering van bijgesneden gebieden wanneer die pixels permanent kunnen worden weggegooid.

**Kan ik de beeldkwaliteit herstellen na compressie?**

Nee. Compressie kan de opgeslagen rasterresolutie verlagen, en het verwijderen van bijgesneden regio’s wist afbeeldingsdata. Bewaar de originele bronafbeelding buiten de presentatie als later bewerken met hoge resolutie vereist kan zijn.

**Hoe moeten SVG‑afbeeldingen worden behandeld?**

Behoud SVG‑inhoud als SVG wanneer vector‑fidelity belangrijk is. De ingesloten [ISvgImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isvgimage/) kan direct worden geëxtraheerd. Het renderen van een dia naar een rasterformaat zoals PNG of JPEG rastert de SVG als onderdeel van de dia‑afbeelding.

**Hoe kan ik onveilige casts vermijden bij het lezen van bestaande dia’s?**

Controleer het vormtype voordat je leden gebruikt die specifiek zijn voor afbeeldingskaders. Een `instanceof`‑controle tegen [IPictureFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipictureframe/) voorkomt ongeldige casts en laat de code dia’s die geen afbeeldingskaders bevatten, correct afhandelen.