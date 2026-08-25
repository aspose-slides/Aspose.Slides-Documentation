---
title: Beheer fotoframes in presentaties met Java
linktitle: Fotoframe
type: docs
weight: 10
url: /nl/java/picture-frame/
keywords:
- fotoframe
- fotoframe toevoegen
- fotoframe maken
- ingesloten afbeelding
- gekoppelde afbeelding
- afbeelding extraheren
- rasterafbeelding
- SVG-afbeelding
- afbeelding bijsnijden
- bijgesneden gebieden verwijderen
- afbeelding comprimeren
- StretchOffset
- fotoframe opmaak
- relatieve schaal
- afbeeldingseffect
- beeldverhouding
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Maak, formatteer, koppel, snijd bij, extraheer en comprimeer fotoframes in presentaties met Aspose.Slides voor Java."
---
## **Overzicht**

Een fotoframe is een dia‑vorm die een afbeelding weergeeft. In Aspose.Slides zijn de afbeeldingsbron en de vorm die deze weergeeft afzonderlijke objecten: een [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) bezit ingesloten afbeeldingsbronnen via zijn [IImageCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iimagecollection/), terwijl een [IPictureFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipictureframe/) de positie, grootte, lijnopmaak, rotatie, bijsnijden, afbeeldingseffecten en andere frame‑niveau instellingen regelt.

Deze scheiding is nuttig wanneer dezelfde afbeelding meer dan één keer wordt weergegeven. Voeg de afbeelding één keer toe aan de presentatie, bewaar de geretourneerde [IPPImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ippimage/), en gebruik die afbeeldingsbron bij het maken van fotoframes.

Fotoframes kunnen rasterafbeeldingen zoals PNG of JPEG en vector‑SVG‑afbeeldingen bevatten. Ze kunnen ook naar gekoppelde afbeeldingen verwijzen in plaats van de afbeeldingsbytes in de presentatie op te slaan. De keuze beïnvloedt draagbaarheid, bestandsgrootte, extractie en exportgedrag, dus het is handig om vóór het toepassen van opmaak of optimalisatie te bepalen hoe de afbeelding moet worden opgeslagen.

## **Een ingesloten afbeelding toevoegen en opmaken**

Voor een ingesloten afbeelding voeg je de afbeeldingsgegevens toe aan de presentatie en maak je een fotoframe met [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-). De afbeelding wordt onderdeel van het presentatiepakket, zodat de presentatie zelf‑containend blijft wanneer deze naar een andere computer wordt verplaatst.

Het volgende voorbeeld voegt een JPEG‑afbeelding toe, creëert een frame met de oorspronkelijke afmetingen van de afbeelding en past lijnopmaak en rotatie toe:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

Het fotoframe regelt de weergegeven geometrie; het wijzigen van de frame‑grootte verandert de oorspronkelijke pixelafmetingen die in de ingesloten afbeeldingsbron zijn opgeslagen. Dit onderscheid wordt belangrijk bij later bijsnijden of comprimeren van een afbeelding.

## **Relatieve schaal gebruiken**

[IPictureFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipictureframe/) biedt relatieve breedte‑ en hoogteschaling voor het frame via [setRelativeScaleWidth](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) en [setRelativeScaleHeight](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-). Een waarde van `1.0` komt overeen met 100 % van de oorspronkelijke afbeeldingsgrootte. Relatieve schaal is handig wanneer een workflow de verhouding tot de bronafbeeldingsgrootte moet behouden in plaats van de finale afmetingen handmatig te berekenen.

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

Relatieve schaal wijzigt de schaalinstellingen van het frame; het her-sampled of comprimeert de ingesloten afbeelding niet.

## **Ingesloten en gekoppelde afbeeldingen**

Een ingesloten afbeelding slaat afbeeldingsgegevens op binnen de presentatie en is daardoor de veiligste keuze voor draagbaarheid en voorspelbare weergave. Een gekoppelde afbeelding slaat een externe locatie op via de [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-)‑methode in plaats van de afbeeldingsgegevens op dezelfde manier in te sluiten.

Gekoppelde afbeeldingen kunnen de hoeveelheid afbeeldingsdata in de PPTX verminderen, maar ze introduceren een externe afhankelijkheid. Het gekoppelde bestand moet toegankelijk blijven voor de applicatie die de presentatie opent of rendert. Als het pad wijzigt, het bestand wordt verplaatst of de bron niet beschikbaar is, wordt de gekoppelde afbeelding mogelijk niet weergegeven zoals verwacht. Voor presentaties die moeten worden gemaild, gearchiveerd of gerenderd in geïsoleerde omgevingen, zijn ingesloten afbeeldingen doorgaans betrouwbaarder.

### **Een gekoppelde afbeelding toevoegen**

Het volgende voorbeeld maakt een fotoframe aan en wijst het naar een lokaal afbeeldingsbestand. Het behandelt alleen afbeeldingskoppelingen; videokoppelingen behoren tot een aparte mediastream en worden expres niet in dit voorbeeld gemengd.

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

Gebruik koppelingen wanneer extern bestandsbeheer opzettelijk is. Gebruik ze niet enkel als vervanging voor compressie: een kleine PPTX met defecte afbeeldingsafhankelijkheden is meestal minder bruikbaar dan een grotere zelf‑containende presentatie.

## **Afbeeldingen extraheren uit fotoframes**

Controleer vóór het extraheren van een afbeelding uit een bestaande presentatie of een vorm daadwerkelijk een [IPictureFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipictureframe/) is en of deze een ingesloten afbeelding bevat. Gekoppelde fotoframes bevatten mogelijk geen afbeeldingsbytes die op dezelfde manier kunnen worden geëxtraheerd.

### **Een rasterafbeelding extraheren**

De moderne afbeeldings‑API gebruikt [IImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iimage/) rechtstreeks en vereist niet de oudere Java‑afbeeldingswrapper. Het volgende voorbeeld vindt de eerste ingesloten rasterafbeelding op een dia en slaat deze op als PNG:

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

Opslaan via [IImage.save](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iimage/#save-java.lang.String-int-) converteert de geëxtraheerde afbeelding naar het gevraagde uitvoerformaat. Als je de gecodeerde bytes wilt die in de presentatie zijn opgeslagen in plaats van een geconverteerd rasterbestand, gebruik dan de binaire data van de afbeeldingsbron.

### **Een SVG‑afbeelding extraheren**

Voor een SVG‑afbeelding maakt de [IPPImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ippimage/) een [ISvgImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isvgimage/)‑object beschikbaar. Hiermee kun je de SVG‑data direct ophalen in plaats van de afbeelding eerst te rasteren.

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

SVG‑inhoud behouden als SVG behoudt de vectorbron binnen de presentatie. Raster‑exports zoals PNG of JPEG renderen die vectorinhoud onvermijdelijk naar pixels. PDF‑ of SVG‑dia‑export is eveneens een renderoperatie, dus de geëxporteerde grafieken moeten niet worden gezien als een bit‑voor‑bit kopie van de oorspronkelijke ingesloten SVG; gebruik de ingesloten [ISvgImage.getSvgData](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isvgimage/#getSvgData--)‑data wanneer de originele vectorresource zelf nodig is.

## **Een afbeelding bijsnijden**

Bijsnijden verandert welk deel van een afbeelding zichtbaar is binnen het frame. De bijsnijdwaarden op [IPictureFillFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipicturefillformat/) zijn percentages van de bronafbeeldingsafmetingen. Bijsnijden verwijdert de verborgen pixels niet meteen uit de ingesloten afbeelding; het wijzigt alleen het zichtbare gebied.

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

Omdat de verborgen afbeeldingsdata nog aanwezig is, kan de bijsnijding later worden aangepast zonder de originele pixels te verliezen. Als bestandsgrootte belangrijker is dan omkeerbaarheid, kunnen de bijgesneden gebieden fysiek worden verwijderd zoals in de volgende sectie wordt beschreven.

## **Bijsneden afbeeldingsgegevens verwijderen**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) verwijdert afbeeldingsdata buiten het huidige bijsnijd‑rechthoek en retourneert de resulterende afbeeldingsbron. Dit kan de bestandsgrootte verkleinen, maar is een destructieve optimalisatie: nadat de presentatie is opgeslagen, zijn de verwijderde pixels niet meer beschikbaar voor een latere ontbijsnijd‑operatie.

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

De methode kan een nieuwe afbeeldingsbron aan de presentatie toevoegen. Als de oorspronkelijke afbeelding ook door andere fotoframes wordt gebruikt, hebben die frames nog steeds hun bestaande bron nodig, dus het verwijderen van bijgesneden gebieden verkleint niet per se het totale aantal afbeeldingen. Het bijsnijden van WMF‑ of EMF‑inhoud met deze methode rastert het bijgesneden resultaat naar PNG.

## **Rasterafbeeldingen comprimeren**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) vermindert de resolutie van rasterafbeeldingen ten opzichte van de grootte waarin de afbeelding wordt weergegeven. Het kan ook bijgesneden gebieden in dezelfde bewerking verwijderen. De methode retourneert `true` wanneer de afbeelding is vergroot of bijgesneden en `false` wanneer er geen wijziging nodig was.

Gebruik een vooraf gedefinieerde [PicturesCompression](https://reference.aspose.com/slides/nl/java/com.aspose.slides/picturescompression/)‑waarde wanneer een standaarddoelresolutie voldoende is:

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

Een aangepaste positieve DPI‑waarde kan in plaats van een vooraf gedefinieerde waarde worden opgegeven wanneer een specifieke doelresolutie vereist is.

Compressie is bedoeld voor rasterafbeeldingen. SVG‑ en metafile‑inhoud wordt niet gereduceerd door deze raster‑compressieworkflow. Vergeet ook niet dat een lagere resolutie en verwijderde bijgesneden gebieden niet kunnen worden hersteld uit de geoptimaliseerde presentatie. Kies een doelresolutie op basis van de grootste weergave‑ of exportgrootte waarvoor de afbeelding daadwerkelijk zal worden bekeken, in plaats van wereldwijd de laagste DPI toe te passen.

## **Afbeeldingstransformatie‑effecten beheren**

Voor een volledige workflow die helderheid, contrast, kleursomzettingen, vervaging, alfa‑effecten, geordende ketens, inspectie, verwijdering en round‑trip‑verificatie omvat, zie [Image Transform Effects](/slides/nl/java/image-transform-effects/).

## **Fotoframe‑geometrie vergrendelen**

De [IPictureFrameLock](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipictureframelock/)‑instellingen bepalen welke bewerkingstoestanden voor een fotoframe zijn uitgeschakeld. Bijvoorbeeld, [setAspectRatioLocked](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) behoudt de proporties van de vorm terwijl deze wordt geschaald.

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

De vergrendeling wordt toegepast op de fotoframe‑vorm. Het dwingt de bronafbeelding niet om opnieuw gesampled te worden of permanent dezelfde beeldverhouding aan te nemen.

## **De StretchOffset‑waarden aanpassen**

Wanneer de vulmodus van de afbeelding op stretch staat, definiëren de stretch‑offset‑waarden op [IPictureFillFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipicturefillformat/) het vulrechthoek ten opzichte van de omgrenzende doos van het fotoframe. Positieve percentages creëren een inspringing vanaf een rand, terwijl negatieve percentages een uitsprong veroorzaken.

Dit verschilt van bijsnijden. Bijsnijdwaarden bepalen welk deel van de bronafbeelding zichtbaar is; stretch‑offsets wijzigen het rechthoek waarin de zichtbare afbeelding wordt uitgerekt.

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

Gebruik stretch‑offsets voor vulplaatsing. Gebruik bijsnijd‑eigenschappen wanneer het doel is om de randen van de bronafbeelding te verbergen.

## **Opslag, bestandsgrootte en export‑overwegingen**

De belangrijkste afwegingen zijn makkelijker te beheren wanneer afbeeldingsopslag en fotoframe‑opmaak afzonderlijk worden behandeld:

- **Ingesloten afbeeldingen** maken de presentatie zelf‑containend en zijn het meest betrouwbaar voor delen en server‑side rendering, maar grote rasterafbeeldingen vergroten de PPTX‑grootte en het geheugenverbruik.
- **Gekoppelde afbeeldingen** kunnen het pakket kleiner houden, maar de presentatie is afhankelijk van externe bestanden die beschikbaar blijven op de opgeslagen paden of locaties.
- **Bijsnijden** is aanvankelijk niet‑destructief. De verborgen pixels blijven ingesloten totdat bijgesneden gebieden expliciet worden verwijderd of tijdens compressie worden weggehaald.
- **Compressie** kan de bestandsgrootte aanzienlijk verkleinen voor te grote rasterafbeeldingen, maar gaat ten koste van de bronresolutie. Het moet worden toegepast nadat de beoogde on‑slide grootte bekend is.
- **SVG‑afbeeldingen** moeten behouden blijven als SVG wanneer vectorbehoud belangrijk is. Extraheer de ingesloten SVG direct wanneer je de vectorresource zelf nodig hebt. Raster‑dia‑exports converteren altijd de gerenderde dia naar pixels.
- **Herhaalde afbeeldingen** moeten, waar mogelijk, een bestaande [IPPImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ippimage/)‑resource hergebruiken in plaats van herhaaldelijk hetzelfde bestand in de presentatieworkflow te laden.

Voor grote presentaties is beeldoptimalisatie meestal het meest effectief wanneer ze selectief wordt uitgevoerd: houd logo’s en diagrammen als vectorinhoud, comprimeer foto’s volgens hun werkelijke weergavegrootte, verwijder bijgesneden pixels alleen wanneer later bewerken niet meer nodig is, en vermijd externe koppelingen tenzij afhankelijkheidsbeheer deel uitmaakt van het implementatie‑ontwerp.

## **FAQ**

**Wat is het verschil tussen een fotoframe en een afbeeldingsbron?**

Een [IPPImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ippimage/) vertegenwoordigt een afbeeldingsbron die aan de presentatie is gekoppeld. Een [IPictureFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipictureframe/) is een vorm op een dia die een afbeelding weergeeft en frame‑niveau geometrie en opmaak opslaat, zoals grootte, rotatie, bijsnijdwaarden, effecten en vergrendelingen.

**Moet ik afbeeldingen insluiten of koppelen?**

Sluit afbeeldingen in wanneer de presentatie draagbaar, gearchiveerd of gerenderd moet kunnen worden zonder toegang tot externe bronnen. Koppel afbeeldingen alleen wanneer het opzettelijk is om afbeeldingsbestanden buiten de PPTX te houden en de externe locaties betrouwbaar kunnen worden onderhouden.

**Vermindert bijsnijden de bestandsgrootte van de PPTX?**

Niet op zichzelf. Normale bijsnijdinstellingen verbergen delen van de bronafbeelding maar behouden de onderliggende pixels. Gebruik [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) of beeldcompressie met verwijdering van bijgesneden gebieden wanneer die pixels permanent kunnen worden verwijderd.

**Kan ik de beeldkwaliteit herstellen na compressie?**

Nee. Compressie kan de opgeslagen rasterresolutie verlagen en het verwijderen van bijgesneden gebieden verwijdert afbeeldingsdata. Bewaar de originele bronafbeelding buiten de presentatie als later bewerken met hoge resolutie vereist kan zijn.

**Hoe moeten SVG‑afbeeldingen worden behandeld?**

Behoud SVG‑inhoud als SVG wanneer vector‑fidelity belangrijk is. De ingesloten [ISvgImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isvgimage/) kan direct geëxtraheerd worden. Het renderen van een dia naar een rasterformaat zoals PNG of JPEG rastert de SVG als onderdeel van de dia‑afbeelding.

**Hoe kan ik onveilige casts vermijden bij het lezen van bestaande dia’s?**

Controleer het vormtype voordat je foto‑frame‑specifieke leden gebruikt. Een `instanceof`‑controle tegen [IPictureFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipictureframe/) voorkomt ongeldige casts en stelt de code in staat om dia’s die geen fotoframes bevatten correct af te handelen.