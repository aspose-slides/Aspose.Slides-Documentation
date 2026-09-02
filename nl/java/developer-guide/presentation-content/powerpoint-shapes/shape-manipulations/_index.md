---
title: Beheer presentatiesvormen in Java
linktitle: Vormmanipulatie
type: docs
weight: 40
url: /nl/java/shape-manipulations/
keywords:
- PowerPoint-vorm
- presentatievorm
- vorm op dia
- vorm vinden
- vorm klonen
- vorm verwijderen
- vorm verbergen
- volgorde van vorm wijzigen
- interop-vorm-ID ophalen
- alternatieve tekst van vorm
- vormlay-outformaten
- vorm als SVG
- vorm naar SVG
- vorm uitlijnen
- vorm spiegelen
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe u presentatiesvormen kunt identificeren, klonen, verwijderen, verbergen, herschikken, exporteren, uitlijnen en spiegelen met Aspose.Slides voor Java."
---
## **Overzicht**

Aspose.Slides for Java stelt de vormen op een dia voor als een geordende [IShapeCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishapecollection/). De collectie is zowel de plaats waar je vormen vindt en wijzigt als de bron van hun stapelvolgorde: index `0` is de vorm die het verst achteraan staat, terwijl de laatste index de vorm is die het verst vooraan staat.

Dit artikel volgt dat model. Het legt eerst uit hoe je een vorm betrouwbaar kunt identificeren en toont vervolgens hoe je vormen kunt klonen, verwijderen, verbergen en herschikken. De laatste secties behandelen opmaak op lay-outniveau, SVG‑export, uitlijning en spiegelinstellingen. Elk voorbeeld staat op zichzelf, zodat je alleen die bewerkingen kunt gebruiken die jouw workflow vereist.

## **Identificeer en vind vormen**

Collectie‑indexen zijn handig bij het verwerken van een bekend bestand, maar ze zijn geen stabiele identifiers. Het toevoegen, verwijderen of herschikken van een vorm kan de index wijzigen. Kies een identifier op basis van hoe de presentatie is gemaakt en onderhouden:

- [Name](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/#getName--) is handig voor door ontwikkelaars beheerde sjablonen en is gemakkelijk te bekijken in het selectiepaneel van PowerPoint. Namen kunnen worden aangepast en zijn niet gegarandeerd uniek, dus stel een naamconventie in als code ervan afhankelijk is.
- [AlternativeText](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/#getAlternativeText--) is bruikbaar wanneer een toegankelijkheidsbeschrijving of een door de auteur toegevoegde tag de vorm al identificeert. Het is zichtbaar voor gebruikers, kan worden gelokaliseerd of herschreven voor toegankelijkheid, en is niet gegarandeerd uniek. Gebruik betekenisvolle toegankelijkheidstekst niet stilletjes als een databaseksleutel.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--) is een alleen‑lezen identifier die uniek is binnen een dia en overeenkomt met de shape‑ID die PowerPoint‑interop gebruikt. Gebruik deze wanneer je integreert met PowerPoint of wanneer je een ondubbelzinnige referentie nodig hebt gedurende de levensduur van een vorm. Een gekloonde of opnieuw aangemaakte vorm is een andere vorm en krijgt een eigen ID.

De gerelateerde [getUniqueId](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/#getUniqueId--)‑methode retourneert een identifier met presentatieschaal, maar die identifier is bedoeld voor add‑ins en kan opnieuw worden toegewezen. Het mag niet worden behandeld als een permanente externe sleutel. Als een langetermijn‑identiteit essentieel is, bewaar dan de mapping in applicatiedata en controleer dat de verwachte vorm nog steeds bestaat.

Het volgende voorbeeld zoekt op naam met een exacte vergelijking en geeft de interop‑ID binnen de dia weer. Wanneer de sjabloon de verwachte vorm niet bevat, meldt de code dat resultaat in plaats van door te gaan met het verkeerde object.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape targetShape = null;
    for (IShape shape : slide.getShapes()) {
        if ("RevenueChart".equals(shape.getName())) {
            targetShape = shape;
            break;
        }
    }

    if (targetShape == null) {
        System.out.println("The shape 'RevenueChart' was not found on slide 1.");
    } else {
        System.out.println("Found " + targetShape.getName() + "; interop ID: " + targetShape.getOfficeInteropShapeId());
    }
} finally {
    presentation.dispose();
}
```

Wanneer een bewerking specifiek is voor een type vorm, controleer dan de interface voordat je type‑specifieke leden gebruikt. Dit voorbeeld werkt tekst en alternatieve tekst bij alleen als het genoemde object een [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/) is.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape candidate = null;
    for (IShape shape : slide.getShapes()) {
        if ("StatusLabel".equals(shape.getName())) {
            candidate = shape;
            break;
        }
    }

    if (candidate instanceof IAutoShape) {
        IAutoShape autoShape = (IAutoShape) candidate;
        autoShape.getTextFrame().setText("Approved");
        autoShape.setAlternativeText("Approval status: approved");
        presentation.save("identified-shape.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("'StatusLabel' is missing or is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

## **Wijzig de vormcollectie**

De methoden om toe te voegen, te klonen, te verwijderen en te herschikken werken direct op de collectie. Als een bewerking het aantal of de volgorde van vormen verandert, vertrouw dan niet meer op indexen die vóór die bewerking zijn vastgelegd.

### **Kloon een vorm**

[addClone](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) maakt een onafhankelijk exemplaar en voegt het toe aan de doelcollectie. [insertClone](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) maakt eveneens een kopie, maar plaatst deze op een opgegeven z‑order‑index. De overloads die coördinaten accepteren verplaatsen de kloon zonder de grootte te wijzigen; overloads met breedte en hoogte kunnen deze ook aanpassen.

Het voorbeeld maakt een doeldia, kloont een gelabelde rechthoek naar de voorkant en voegt een tweede kloon toe aan de achterkant. Wijzigingen in een van de klonen wijzigen de oorspronkelijke vorm niet.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide sourceSlide = presentation.getSlides().get_Item(0);
    IAutoShape sourceShape = sourceSlide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 180, 60);
    sourceShape.setName("SourceLabel");
    sourceShape.getTextFrame().setText("Source");

    ILayoutSlide blankLayout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);
    ISlide destinationSlide = presentation.getSlides().addEmptySlide(blankLayout);

    IShape frontCloneShape = destinationSlide.getShapes().addClone(sourceShape, 80, 80);
    frontCloneShape.setName("FrontClone");
    if (frontCloneShape instanceof IAutoShape) {
        IAutoShape frontClone = (IAutoShape) frontCloneShape;
        frontClone.getTextFrame().setText("Front clone");
    } else {
        System.out.println("The front clone is not an AutoShape; its text was not changed.");
    }

    IShape backCloneShape = destinationSlide.getShapes().insertClone(0, sourceShape, 80, 180);
    backCloneShape.setName("BackClone");
    if (backCloneShape instanceof IAutoShape) {
        IAutoShape backClone = (IAutoShape) backCloneShape;
        backClone.getTextFrame().setText("Back clone");
    } else {
        System.out.println("The back clone is not an AutoShape; its text was not changed.");
    }

    presentation.save("cloned-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Klonen kopieert de inhoud en opmaak van de vorm, inclusief de naam en alternatieve tekst. Ken nieuwe logische identifiers toe aan de kloon wanneer die waarden uniek moeten zijn. Resources die door complexe vormen worden gebruikt, worden beheerd door de presentatie, maar een kloon blijft een nieuw collectie‑item met een nieuwe vorm‑identiteit.

### **Verwijder vormen**

[remove](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) verwijdert een specifiek vormobject uit zijn collectie. Wanneer je meerdere overeenkomsten wilt verwijderen tijdens een geïndexeerde iteratie, loop dan van het einde zodat elke overgebleven index geldig blijft.

Dit voorbeeld verwijdert elke vorm met een aangewezen naam. Het leest de vorm op de huidige index, niet een vaste collectie‑item, en cast de vorm niet onnodig.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape keepShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 140, 60);
    keepShape.setName("Keep");

    IAutoShape firstTemporaryShape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 220, 40, 80, 80);
    firstTemporaryShape.setName("Temporary");

    IAutoShape secondTemporaryShape = slide.getShapes().addAutoShape(ShapeType.Triangle, 340, 40, 100, 80);
    secondTemporaryShape.setName("Temporary");

    for (int i = slide.getShapes().size() - 1; i >= 0; i--) {
        IShape shape = slide.getShapes().get_Item(i);
        if ("Temporary".equals(shape.getName())) {
            slide.getShapes().remove(shape);
        }
    }

    presentation.save("removed-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Na verwijdering veranderen het aantal vormen en de indexen van de latere vormen. Verwijzingen naar niet‑aangedane vormen blijven betrouwbaarder dan opgeslagen indexen. Houd ook rekening met connectoren, animaties en andere presentatiefuncties die naar het verwijderde object kunnen verwijzen; het verwijderen van een zichtbare vorm kan meer dan alleen het uiterlijk van de dia wijzigen.

### **Verberg een vorm**

Het instellen van [Hidden](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/#setHidden-boolean-) op `true` houdt de vorm in de collectie, maar voorkomt dat deze verschijnt in de normale diavoorstelling. De index, opmaak en inhoud blijven beschikbaar voor code, dus verbergen is geschikt voor optionele elementen die later eventueel weer kunnen worden hersteld.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape visibleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 160, 60);
    visibleShape.setName("VisibleLabel");

    IAutoShape optionalShape = slide.getShapes().addAutoShape(ShapeType.Moon, 240, 40, 100, 100);
    optionalShape.setName("OptionalDecoration");

    for (IShape shape : slide.getShapes()) {
        if ("OptionalDecoration".equals(shape.getName())) {
            shape.setHidden(true);
        }
    }

    presentation.save("hidden-shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Verbergen is geen verwijdering of beveiliging. Het object kan nog steeds worden gevonden en onzichtbaar worden gemaakt door een gebruiker of door code, en blijft deel uitmaken van het presentatie‑bestand.

### **Wijzig de Z‑order**

Overlap‑vormen worden getekend in de volgorde van de collectie. [reorder](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) verplaatst een bestaande vorm naar een doel‑index zonder deze te klonen. Index `0` is de achterkant; `size() - 1` is de voorkant.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape blueRectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 220, 120);
    blueRectangle.setName("BlueRectangle");
    blueRectangle.getFillFormat().setFillType(FillType.Solid);
    blueRectangle.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    IAutoShape orangeEllipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 180, 140, 220, 120);
    orangeEllipse.setName("OrangeEllipse");
    orangeEllipse.getFillFormat().setFillType(FillType.Solid);
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De rechthoek wordt eerst aangemaakt en staat aanvankelijk achter de ellips. Door deze naar de laatste index te verplaatsen, komt hij voor. Finaliseer de z‑order nadat je alle gerelateerde vormen hebt toegevoegd of gekloond, want die bewerkingen voegen nieuwe collectie‑items toe of voegen ze in en kunnen de beoogde stapel wijzigen.

## **Inspecteer vormen op lay‑outdia's**

Normale dia's, lay‑outdia's en masters hebben aparte vormcollecties. Een vorm in een lay‑outcollectie is niet hetzelfde object als een vergelijkbaar gepositioneerde vorm op een normale dia. Inspecteer lay‑outvormen wanneer je de door een lay‑out geleverde opmaak moet begrijpen of wijzigen.

Het volgende voorbeeld leest voor elke lay‑outvorm de [FillFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/#getFillFormat--) en [LineFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/#getLineFormat--) zonder ervan uit te gaan dat elke vorm een `AutoShape` is.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ILayoutSlide layoutSlide : presentation.getLayoutSlides()) {
        for (IShape shape : layoutSlide.getShapes()) {
            int fillType = shape.getFillFormat().getFillType();
            double lineWidth = shape.getLineFormat().getWidth();
            System.out.println(layoutSlide.getName() + " / " + shape.getName() + ": fill=" + fillType + ", line width=" + lineWidth);
        }
    }
} finally {
    presentation.dispose();
}
```

Het bewerken van een lay‑out kan meerdere dia's die de lay‑out gebruiken beïnvloeden. Voordat je een lay‑outvorm wijzigt, bepaal of een normale dia het object erft of een lokale overschrijving bevat, en test elke dia die die lay‑out gebruikt.

## **Exporteer een vorm naar SVG**

[writeAsSvg](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) schrijft de gerenderde inhoud van één vorm naar een stream. Het resultaat bevat de vorm, niet de volledige dia‑achtergrond of naburige vormen.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() == 0) {
        System.out.println("Slide 1 does not contain a shape to export.");
    } else {
        IShape shape = slide.getShapes().get_Item(0);
        try (FileOutputStream svgStream = new FileOutputStream("shape.svg")) {
            shape.writeAsSvg(svgStream);
        } catch (IOException exception) {
            System.out.println("The SVG file could not be written: " + exception.getMessage());
        }
    }
} finally {
    presentation.dispose();
}
```

Houd de presentatie open tijdens het renderen. De output hangt af van de opmaak van de vorm en van resources zoals lettertypen en afbeeldingen. Als je de hele compositie nodig hebt, exporteer dan de dia in plaats van een individuele vorm. De aanroeper bezit de stream en moet deze sluiten.

## **Lijn vormen uit**

De [SlideUtil.alignShapes](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-)‑overloads lijnen ofwel alle vormen uit of geselecteerde collectie‑indexen. [ShapesAlignmentType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/shapesalignmenttype/) geeft de rand, middellijn of distributiemodus aan. Stel `alignToSlide` in op `true` om de dia‑randen te gebruiken; stel in op `false` om de geselecteerde vormen ten opzichte van elkaar uit te lijnen.

Dit voorbeeld lijn drie vormen uit op de bovenrand van de dia. De geretourneerde vormreferenties worden direct vóór uitlijning omgezet naar hun huidige indexen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape firstShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 60, 80, 120, 50);
    IAutoShape secondShape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 240, 160, 120, 50);
    IAutoShape thirdShape = slide.getShapes().addAutoShape(ShapeType.Triangle, 420, 240, 120, 50);
    firstShape.setName("FirstAlignedShape");
    secondShape.setName("SecondAlignedShape");
    thirdShape.setName("ThirdAlignedShape");

    int[] shapeIndexes = {slide.getShapes().indexOf(firstShape), slide.getShapes().indexOf(secondShape), slide.getShapes().indexOf(thirdShape)};

    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
    presentation.save("aligned-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Uitlijning wijzigt de posities, niet de z‑order. Relatieve uitlijning vereist doorgaans minstens twee vormen, terwijl horizontale of verticale distributie genoeg vormen nodig heeft om de afstand te bepalen. Herbereken de indexen als je de collectie wijzigt vóór het aanroepen van de methode.

## **Spiegel een vorm**

De [ShapeFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/shapeframe/)‑klasse slaat positie, grootte, horizontale en verticale spiegelinstellingen en rotatie op. De `getFlipH`‑ en `getFlipV`‑waarden gebruiken [NullableBool](https://reference.aspose.com/slides/nl/java/com.aspose.slides/nullablebool/): `True` schakelt de spiegel in, `False` schakelt deze uit, en `NotDefined` behoudt de ongedefinieerde/standaard status.

De invoerpresentatie hieronder bevat één niet‑gespiegelde vorm.

![The shape before flipping](shape_to_be_flipped.png)

Het voorbeeld behoudt alle andere frame‑waarden en vervangt alleen de twee spiegel‑instellingen. Dit is belangrijk omdat het toewijzen van een nieuw [Frame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) het volledige frame vervangt.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IShapeFrame frame = shape.getFrame();

    System.out.println("Horizontal flip before change: " + frame.getFlipH());
    System.out.println("Vertical flip before change: " + frame.getFlipV());

    shape.setFrame(new ShapeFrame(frame.getX(), frame.getY(), frame.getWidth(), frame.getHeight(), NullableBool.True, NullableBool.True, frame.getRotation()));

    presentation.save("flipped-shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De opgeslagen vorm wordt horizontaal en verticaal gespiegeld terwijl positie, grootte en rotatie behouden blijven.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Moet ik een collectie‑index gebruiken als vorm‑identifier?**

Alleen voor kort‑lopende verwerking wanneer de collectie niet verandert voordat de index wordt gebruikt. Geef de voorkeur aan een gevalideerde `Name`‑ of `AlternativeText`‑conventie voor vervaardigde sjablonen, of `OfficeInteropShapeId` voor interop‑werk op dia‑niveau.

**Verwijdert het verbergen van een vorm deze uit de z‑order?**

Nee. Een verborgen vorm blijft in de collectie op dezelfde index. Ze kan worden gevonden, herschikt, bewerkt of weer zichtbaar gemaakt.

**Waarom verscheen een gekloonde vorm voor een andere vorm?**

`addClone` plakt de kloon aan het einde van de collectie, dat is de voorkant van de z‑order. Gebruik `insertClone` om de initiële index te kiezen of `reorder` nadat alle vormen zijn toegevoegd.