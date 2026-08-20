---
title: Beheer presentatievormen op Android
linktitle: Vormmanipulatie
type: docs
weight: 40
url: /nl/androidjava/shape-manipulations/
keywords:
- PowerPoint-vorm
- presentatievorm
- vorm op dia
- vorm vinden
- vorm klonen
- vorm verwijderen
- vorm verbergen
- vormvolgorde wijzigen
- interop‑vorm‑ID ophalen
- alternatieve tekst van vorm
- vormlay-outformaten
- vorm als SVG
- vorm naar SVG
- vorm uitlijnen
- vorm spiegelen
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Leer hoe u presentatievormen kunt identificeren, klonen, verwijderen, verbergen, herordenen, exporteren, uitlijnen en spiegelen met Aspose.Slides voor Android via Java."
---
## **Overzicht**

Aspose.Slides for Android via Java vertegenwoordigt de vormen op een dia als een geordende [IShapeCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishapecollection/). De collectie is zowel de plaats waar u vormen vindt en wijzigt als de bron van hun stapelvolgorde: index `0` is de vorm achterin, terwijl de laatste index de voorste vorm is.

Dit artikel volgt dat model. Het legt eerst uit hoe u een vorm betrouwbaar kunt identificeren, daarna toont het hoe u vormen kunt klonen, verwijderen, verbergen en herordenen. De laatste secties behandelen opmaak op lay‑outniveau, SVG‑export, uitlijning en spiegelinstellingen. Elk voorbeeld staat op zichzelf, zodat u alleen de bewerkingen kunt gebruiken die uw workflow vereist.

## **Identificeer en vind vormen**

Collectie‑indexen zijn handig bij het verwerken van een bekend bestand, maar ze zijn geen stabiele identificatoren. Het toevoegen, verwijderen of herschikken van een vorm kan haar index wijzigen. Kies een identifier op basis van hoe de presentatie is gemaakt en onderhouden:

- [Name](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/#getName--) is nuttig voor door ontwikkelaars beheerde sjablonen en is makkelijk te inspecteren in het Selectiepaneel van PowerPoint. Namen kunnen worden bewerkt en zijn niet gegarandeerd uniek, dus stel een naamgevingsconventie vast als code erop vertrouwt.
- [AlternativeText](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/#getAlternativeText--) is handig wanneer een toegankelijkheidsbeschrijving of een door de auteur toegevoegde tag de vorm al identificeert. Het is zichtbaar voor gebruikers, kan worden gelokaliseerd of herschreven voor toegankelijkheid, en is niet gegarandeerd uniek. Gebruik betekenisvolle toegankelijkheidstekst niet stilletjes als databasesleutel.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) is een alleen‑lezen identifier die uniek is binnen een dia en overeenkomt met de shape‑ID die PowerPoint‑interop gebruikt. Gebruik deze bij integratie met PowerPoint of wanneer u een ondubbelzinnige referentie nodig heeft gedurende de levensduur van een vorm. Een gekloonde of opnieuw gecreëerde vorm is een andere vorm en krijgt een eigen ID.

De gerelateerde [getUniqueId](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/#getUniqueId--)‑methode retourneert een identifier met presentatiescope, maar die identifier is bedoeld voor add‑ins en kan worden hergebruikt. Deze mag niet worden behandeld als een permanente externe sleutel. Als langdurige identiteit essentieel is, bewaar dan de mapping in toepassingsdata en controleer of de verwachte vorm nog bestaat.

Het volgende voorbeeld zoekt op naam met een exacte vergelijking en rapporteert de dia‑gescope‑interop‑ID. Wanneer de sjabloon de verwachte vorm niet bevat, meldt de code dat resultaat in plaats van door te gaan met het verkeerde object.

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

Wanneer een bewerking specifiek is voor een bepaald vormtype, controleer dan de interface voordat u type‑specifieke leden gebruikt. Dit voorbeeld werkt tekst en alternatieve tekst bij alleen als het genoemde object een [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) is.

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

De add‑, clone‑, remove‑ en reorder‑methoden werken direct op de collectie. Als een bewerking het aantal of de volgorde van vormen wijzigt, vertrouw dan niet langer op indexen die vóór die bewerking zijn vastgelegd.

### **Kloon een vorm**

[addClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) maakt een onafhankelijke kopie en voegt deze toe aan de doelcollectie. [insertClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) maakt eveneens een kopie, maar plaatst deze op een opgegeven z‑order‑index. De overloads die coördinaten accepteren verplaatsen de kloon zonder de grootte te veranderen; overloads met breedte en hoogte kunnen deze tevens aanpassen.

Het voorbeeld maakt een bestemmingsdia, kloont een gelabelde rechthoek naar de voorzijde en voegt een tweede kloon toe aan de achterkant. Wijzigingen in een van beide klonen wijzigen de brondvorm niet.

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

Klonen kopieert de inhoud en opmaak van de vorm, inclusief naam en alternatieve tekst. Ken nieuwe logische identifiers toe aan de kloon wanneer deze waarden uniek moeten zijn. Bronnen die door complexe vormen worden gebruikt, worden door de presentatie beheerd, maar een kloon blijft een nieuw collectie‑item met een nieuwe vorm‑identiteit.

### **Verwijder vormen**

[remove](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) verwijdert een specifiek vormobject uit zijn collectie. Bij het verwijderen van meerdere overeenkomsten tijdens een geïndexeerde iteratie, doorloop de collectie van achteren zodat elke resterende index geldig blijft.

Dit voorbeeld verwijdert elke vorm met een opgegeven naam. Het leest de vorm op de huidige index, niet een vast collectie‑item, en cast de vorm niet onnodig.

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

Na het verwijderen veranderen het aantal vormen en de indexen van latere vormen. Referenties naar niet‑aangedane vormen blijven betrouwbaarder dan opgeslagen indexen. Houd ook rekening met connectoren, animaties en andere presentatiefuncties die naar het verwijderde object kunnen verwijzen; het verwijderen van een zichtbare vorm kan meer veranderen dan alleen het uiterlijk van de dia.

### **Verberg een vorm**

Het instellen van [Hidden](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/#setHidden-boolean-) op `true` houdt de vorm in de collectie, maar voorkomt dat deze verschijnt in de normale diavoorstelling. Haar index, opmaak en inhoud blijven beschikbaar voor code, dus verbergen is passend voor optionele elementen die later hersteld kunnen worden.

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

Verbergen is geen verwijdering of beveiliging. Het object kan nog steeds worden ontdekt en onzichtbaar worden gemaakt door een gebruiker of door code, en blijft deel uitmaken van het presentatie‑bestand.

### **Wijzig de Z‑volgorde**

Overlapende vormen worden geschilderd in de volgorde van de collectie. [reorder](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) verplaatst een bestaande vorm naar een doelindex zonder deze te klonen. Index `0` is de achterkant; `size() - 1` is de voorkant.

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
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De rechthoek wordt eerst gemaakt en staat aanvankelijk achter de ellips. Het verplaatsen naar de laatste index brengt hem naar de voorkant. Voltooi de Z‑volgorde na het toevoegen of klonen van alle gerelateerde vormen, want die bewerkingen voegen nieuwe collectie‑items toe of plaatsen ze in, waardoor de beoogde stapel kan veranderen.

## **Inspecteer vormen op lay‑outdia's**

Normale dia's, lay‑outdia's en masterdia's hebben afzonderlijke vormcollecties. Een vorm in een lay‑outcollectie is niet hetzelfde object als een vergelijkbaar gepositioneerde vorm op een normale dia. Inspecteer lay‑outvormen wanneer u de door een lay‑out geleverde opmaak wilt begrijpen of wijzigen.

Het volgende voorbeeld leest voor elke lay‑outvorm de [FillFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/#getFillFormat--) en [LineFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/#getLineFormat--) zonder aan te nemen dat elke vorm een `AutoShape` is.

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

Het bewerken van een lay‑out kan meerdere dia's die deze gebruiken beïnvloeden. Bepaal vóór het wijzigen van een lay‑outvorm of een normale dia het object erft of een lokale overschrijving bevat, en test elke dia die die lay‑out gebruikt.

## **Exporteer een vorm naar SVG**

[writeAsSvg](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) schrijft de gerenderde inhoud van één vorm naar een stream. Het resultaat bevat alleen de vorm, niet de volledige dia‑achtergrond of naburige vormen.

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

Houd de presentatie geopend tijdens het renderen. De output hangt af van de opmaak van de vorm en van bronnen zoals lettertypen en afbeeldingen. Als u de hele compositie nodig hebt, exporteer dan de dia in plaats van een individuele vorm. De aanroeper bezit de stream en moet deze sluiten.

## **Lijn vormen uit**

De [SlideUtil.alignShapes](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-)‑overloads lijnen ofwel alle vormen uit of geselecteerde collectie‑indexen. [ShapesAlignmentType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/shapesalignmenttype/) specificeert de rand, middellijn of distributiemodus. Stel `alignToSlide` in op `true` om de dia‑randen te gebruiken; stel in op `false` om de geselecteerde vormen ten opzichte van elkaar uit te lijnen.

Dit voorbeeld lijnt drie vormen uit langs de bovenrand van de dia. De geretourneerde vormreferenties worden direct vóór de uitlijning omgezet naar hun actuele indexen.

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

Uitlijning verandert posities, niet de Z‑volgorde. Relatieve uitlijning vereist normaal gezien minstens twee vormen, terwijl horizontale of verticale distributie voldoende vormen nodig heeft om de tussenruimte te bepalen. Herbereken indexen als u de collectie wijzigt vóór het aanroepen van de methode.

## **Spiegel een vorm**

De [ShapeFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/shapeframe/)‑klasse bewaart positie, grootte, horizontale en verticale spiegelinstellingen en rotatie. Zijn `getFlipH`‑ en `getFlipV`‑waarden gebruiken [NullableBool](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/nullablebool/): `True` schakelt de spiegel in, `False` schakelt deze uit, en `NotDefined` behoudt de ongedefinieerde/standaardstatus.

De invoerpresentatie hieronder bevat één niet‑gespiegelde vorm.

![The shape before flipping](shape_to_be_flipped.png)

Het voorbeeld behoudt alle andere frame‑waarden en vervangt alleen de twee spiegelinstellingen. Dit is belangrijk omdat het toewijzen van een nieuw [Frame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) het volledige frame vervangt.

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

**Moet ik een collectie-index gebruiken als vormidentificatie?**

Alleen voor kortstondige verwerking wanneer de collectie niet verandert voordat de index wordt gebruikt. Geef de voorkeur aan een gevalideerde `Name`‑ of `AlternativeText`‑conventie voor opgestelde sjablonen, of `OfficeInteropShapeId` voor interop‑werk binnen een dia.

**Verwijdert het verbergen van een vorm deze uit de Z‑volgorde?**

Nee. Een verborgen vorm blijft in de collectie op dezelfde index. Hij kan worden gevonden, herordenen, bewerkt of weer zichtbaar worden gemaakt.

**Waarom verscheen een gekloonde vorm voor een andere vorm?**

`addClone` voegt de kloon toe aan het einde van de collectie, wat de voorkant van de Z‑volgorde is. Gebruik `insertClone` om een initiële index te kiezen of `reorder` nadat alle vormen zijn toegevoegd.