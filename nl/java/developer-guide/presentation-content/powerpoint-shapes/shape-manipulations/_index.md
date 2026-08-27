---
title: Beheer presentatie‑vormen in Java
linktitle: Vormbewerkingen
type: docs
weight: 40
url: /nl/java/shape-manipulations/
keywords:
- PowerPoint‑vorm
- presentatie‑vorm
- vorm op dia
- vorm vinden
- vorm klonen
- vorm verwijderen
- vorm verbergen
- vormvolgorde wijzigen
- interop‑vorm‑ID ophalen
- alternatieve tekst van vorm
- aanpassingspunt van vorm
- preset‑vormaanpassing
- vorm‑geometrie
- vorm‑lay‑out‑formaten
- vorm als SVG
- vorm naar SVG
- vorm uitlijnen
- vorm spiegelen
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe u presentatie‑vormen kunt identificeren, aanpassen, klonen, verwijderen, verbergen, opnieuw ordenen, exporteren, uitlijnen en spiegelen met Aspose.Slides voor Java."
---
## **Overzicht**

Aspose.Slides voor Java vertegenwoordigt de vormen op een dia als een geordende [IShapeCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishapecollection/). De collectie is zowel de plek waar je vormen vindt en wijzigt als de bron van hun stapelvolgorde: index `0` is de meest achterste vorm, terwijl de laatste index de voorste vorm is.

Dit artikel volgt dat model. Het legt eerst uit hoe je een vorm betrouwbaar kunt identificeren en vooraf ingestelde aanpassingspunten kunt wijzigen, en toont vervolgens hoe je vormen kunt klonen, verwijderen, verbergen en herschikken. De laatste secties behandelen opmaak op lay-outniveau, SVG-export, uitlijning en spiegelinstellingen. Elk voorbeeld is onafhankelijk, zodat je alleen de bewerkingen kunt gebruiken die jouw workflow vereist.

## **Identificeren en vinden van vormen**

Collectie‑indexen zijn handig bij het verwerken van een bekend bestand, maar ze zijn geen stabiele identifiers. Het toevoegen, verwijderen of herschikken van een vorm kan de index wijzigen. Kies een identifier op basis van hoe de presentatie is gemaakt en onderhouden:

- [Name](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/#getName--) is nuttig voor door ontwikkelaars beheerde sjablonen en is makkelijk te bekijken in het selectie‑paneel van PowerPoint. Namen kunnen worden bewerkt en zijn niet gegarandeerd uniek, dus stel een naamgevingsconventie op als code ervan afhankelijk is.
- [AlternativeText](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/#getAlternativeText--) is nuttig wanneer een toegankelijkheidsbeschrijving of een door de auteur toegevoegde tag de vorm al identificeert. Het is zichtbaar voor gebruikers, kan worden gelokaliseerd of herschreven voor toegankelijkheid, en is niet gegarandeerd uniek. Gebruik betekenisvolle toegankelijkheidstekst niet stilzwijgend als databasesleutel.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--) is een alleen‑lezen identifier die uniek is binnen een dia en overeenkomt met de vorm‑ID die PowerPoint‑interop gebruikt. Gebruik deze wanneer je integreert met PowerPoint of wanneer je een ondubbelzinnige referentie nodig hebt gedurende de levensduur van een vorm. Een gekloonde of opnieuw aangemaakte vorm is een andere vorm en krijgt een eigen ID.

De gerelateerde [getUniqueId](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/#getUniqueId--) methode retourneert een identifier met presentatiescope, maar die identifier is bedoeld voor add‑ins en kan worden hergebruikt. Hij mag niet worden behandeld als een permanente externe sleutel. Als langdurige identiteit essentieel is, bewaar de mapping in applicatiedata en valideer dat de verwachte vorm nog bestaat.

Het volgende voorbeeld zoekt op naam met een exacte vergelijking en rapporteert de dia‑gescope‑interop‑ID. Wanneer de sjabloon de verwachte vorm niet bevat, rapporteert de code dat resultaat in plaats van door te gaan met het verkeerde object.

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

Wanneer een bewerking specifiek is voor een bepaald vormtype, controleer dan de interface voordat je type‑specifieke leden gebruikt. Dit voorbeeld werkt tekst en alternatieve tekst bij alleen als het benoemde object een [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/) is.

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

## **Identificeren en aanpassen van preset‑vormaanpassingen**

Preset‑geometrievormen kunnen aanpassingspunten blootleggen die aspecten zoals hoekgrootte, pijlverhoudingen of booghoeken besturen. Toegang krijgen tot die punten gebeurt via de alleen‑lezen collectie [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/nl/java/com.aspose.slides/igeometryshape/#getAdjustments--) . De collectie zelf wordt door de vorm geleverd, maar elk [IAdjustValue](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iadjustvalue/) bevat een waarde die kan worden gewijzigd.

Vertrouw niet alleen op een vaste collectie‑index. Doorloop de aanpassingen en inspecteer de alleen‑lezen [getType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iadjustvalue/#getType--) methode, waarvan de [ShapeAdjustmentType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/shapeadjustmenttype/) waarde beschrijft wat de aanpassing bestuurt. De alleen‑lezen [getName](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iadjustvalue/#getName--) methode geeft extra identificatie‑informatie en is vooral nuttig wanneer een preset meer dan één aanpassing met hetzelfde semantische type bevat.

Gebruik de waardemethode die overeenkomt met de betekenis van de aanpassing:

| Adjustment type | Purpose | Value to change |
|---|---|---|
| `CornerSize` | Size of rounded corners | [setRawValue](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iadjustvalue/#setRawValue-long-) |
| `ArrowTailThickness` | Thickness of an arrow tail | `setRawValue` |
| `ArrowheadLength` | Length of an arrowhead | `setRawValue` |
| `ArrowheadWidth` | Width of an arrowhead | `setRawValue` |
| `StartAngle` | Start angle of a pie or arc | [setAngleValue](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iadjustvalue/#setAngleValue-float-) |
| `EndAngle` | End angle of a pie or arc | `setAngleValue` |

`getType` en `getName` geven alleen‑lezen informatie terug. `getRawValue` en `setRawValue` werken met een geheel getal in de native geometrie‑eenheden van de preset, terwijl `getAngleValue` en `setAngleValue` werken met een hoek in graden. Het aantal, de volgorde, de betekenis en het geldige bereik van aanpassingen hangen af van het preset‑[ShapeType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/igeometryshape/#getShapeType--). Een waarde die geldig is voor de ene preset kan ongeldig zijn of een ander effect hebben voor een andere.

Wanneer `getType` `ShapeAdjustmentType.Custom` retourneert, herkent de API geen standaard semantische betekenis. Inspecteer `getName`, het preset‑type en de bestaande waarde, en laat de aanpassing ongewijzigd tenzij de verwachte betekenis en het bereik bekend zijn. Zelfs voor erkende types, controleer of hetzelfde type meer dan eens voorkomt voordat je een waarde selecteert. Het artikel [Connector](/slides/nl/java/connector/) toont deze situatie met buig‑aanpassingen van connectoren.

Het volgende volledige voorbeeld maakt standaard‑ en aangepaste versies van drie preset‑vormen. Het doorloopt elke aanpassing, rapporteert de naam en het type, wijzigt grootte‑gerelateerde waarden via `setRawValue`, wijzigt hoeken via `setAngleValue` en slaat het resultaat op. De linkerkolom behoudt de standaardgeometrie; de rechterkolom toont het aangepaste afgeronde rechthoek, de vier‑weg‑pijl en de taart.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Voegt kopteksten toe voor de kolommen met standaard en aangepaste vorm.
    IAutoShape defaultColumnLabel = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 20, 250, 30);
    defaultColumnLabel.getTextFrame().setText("Default preset geometry");
    IAutoShape adjustedColumnLabel = slide.getShapes().addAutoShape(ShapeType.Rectangle, 390, 20, 250, 30);
    adjustedColumnLabel.getTextFrame().setText("Modified adjustment values");

    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
    IGeometryShape modifiedRoundedRectangle = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
    modifiedRoundedRectangle.setName("ModifiedRoundedRectangle");

    slide.getShapes().addAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110);
    IGeometryShape modifiedArrow = slide.getShapes().addAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110);
    modifiedArrow.setName("ModifiedQuadArrow");

    slide.getShapes().addAutoShape(ShapeType.Pie, 95, 330, 130, 130);
    IGeometryShape modifiedPie = slide.getShapes().addAutoShape(ShapeType.Pie, 445, 330, 130, 130);
    modifiedPie.setName("ModifiedPie");

    IGeometryShape[] shapesToAdjust = {
        modifiedRoundedRectangle,
        modifiedArrow,
        modifiedPie
    };

    for (IGeometryShape shape : shapesToAdjust) {
        for (int adjustmentIndex = 0; adjustmentIndex < shape.getAdjustments().size(); adjustmentIndex++) {
            IAdjustValue adjustment = shape.getAdjustments().get_Item(adjustmentIndex);
            System.out.println(shape.getName() + " / " + adjustment.getName() + ": " + adjustment.getType());

            switch (adjustment.getType()) {
                case ShapeAdjustmentType.CornerSize:
                    adjustment.setRawValue(5000);
                    break;
                case ShapeAdjustmentType.ArrowTailThickness:
                    adjustment.setRawValue(25000);
                    break;
                case ShapeAdjustmentType.ArrowheadLength:
                    adjustment.setRawValue(30000);
                    break;
                case ShapeAdjustmentType.ArrowheadWidth:
                    adjustment.setRawValue(40000);
                    break;
                case ShapeAdjustmentType.StartAngle:
                    adjustment.setAngleValue(30);
                    break;
                case ShapeAdjustmentType.EndAngle:
                    adjustment.setAngleValue(300);
                    break;
                case ShapeAdjustmentType.Custom:
                    System.out.println("Custom adjustment '" + adjustment.getName() + "' was not changed.");
                    break;
            }
        }
    }

    presentation.save("preset-shape-adjustments.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het controleren van het semantische type vóór het wijzigen van een waarde maakt de code expliciet over de intentie en voorkomt de veronderstelling dat een bepaalde collectie‑index dezelfde betekenis heeft bij verschillende preset‑vormen.

## **Aanpassen van de vormcollectie**

De methoden voor toevoegen, klonen, verwijderen en herschikken werken direct op de collectie. Als een bewerking het aantal of de volgorde van vormen wijzigt, vertrouw dan niet langer op indexen die vóór die bewerking zijn vastgelegd.

### **Kloon een vorm**

[addClone](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) maakt een onafhankelijke kopie en voegt deze toe aan de doelcollectie. [insertClone](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) maakt ook een kopie, maar plaatst deze op een opgegeven z‑order‑index. De overloads die coördinaten accepteren verplaatsen de kloon zonder de grootte te wijzigen; overloads met breedte en hoogte kunnen hem ook aanpassen.

Het voorbeeld maakt een bestemmingsdia, kloont een gelabelde rechthoek naar de voorgrond en voegt een tweede kloon toe aan de achtergrond. Wijzigingen aan een van de klonen wijzigen de brondvorm niet.

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

Klonen kopieert de inhoud en opmaak van de vorm, inclusief naam en alternatieve tekst. Ken nieuwe logische identifiers toe aan de kloon wanneer die waarden uniek moeten zijn. Hulpbronnen die door complexe vormen worden gebruikt, worden beheerd door de presentatie, maar een kloon blijft een nieuw collectie‑item met een nieuwe vorm‑identiteit.

### **Verwijder vormen**

[remove](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) verwijdert een specifiek vormobject uit zijn collectie. Wanneer je meerdere overeenkomsten verwijdert tijdens een geïndexeerde iteratie, doorloop dan van achteren zodat elke resterende index geldig blijft.

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

Na verwijdering veranderen het aantal vormen en de indexen van latere vormen. Referenties naar ongewijzigde vormen blijven betrouwbaarder dan opgeslagen indexen. Houd ook rekening met connectoren, animaties en andere presentatiefuncties die naar het verwijderde object kunnen verwijzen; het verwijderen van een zichtbare vorm kan meer veranderen dan alleen het uiterlijk van de dia.

### **Verberg een vorm**

Het instellen van [Hidden](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/#setHidden-boolean-) op `true` houdt de vorm in de collectie, maar voorkomt dat deze verschijnt in de normale diavoorstelling. De index, opmaak en inhoud blijven beschikbaar voor code, zodat verbergen geschikt is voor optionele elementen die later kunnen worden hersteld.

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

Verbergen is geen verwijdering of beveiliging. Het object kan nog steeds worden gevonden en onzichtbaar gemaakt door een gebruiker of door code, en het blijft deel uitmaken van het presentatie‑bestand.

### **Verander de Z‑volgorde**

Overlappende vormen worden getekend in de volgorde van de collectie. [reorder](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) verplaatst een bestaande vorm naar een doel‑index zonder deze te klonen. Index `0` is de achtergrond; `size() - 1` is de voorgrond.

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

De rechthoek wordt eerst gemaakt en zit initieel achter de ellips. Het verplaatsen naar de laatste index brengt hem naar voren. Finaliseer de z‑volgorde nadat je alle gerelateerde vormen hebt toegevoegd of gekloond, want die bewerkingen voegen nieuwe collectie‑items toe of voegen ze in en kunnen de gewenste stapel wijzigen.

## **Inspecteer vormen op lay-outdia's**

Normale dia's, lay-outdia's en masters hebben afzonderlijke vormcollecties. Een vorm in een lay-outcollectie is niet hetzelfde object als een soortgelijke vorm op een normale dia. Inspecteer lay‑out‑vormen wanneer je de opmaak die door een lay-out wordt geleverd moet begrijpen of wijzigen.

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

Het bewerken van een lay-out kan meerdere dia's die de lay-out gebruiken beïnvloeden. Bepaal vóór het wijzigen van een lay‑out‑vorm of een normale dia het object erft of een lokale overschrijving bevat, en test elke dia die die lay-out gebruikt.

## **Exporteer een vorm naar SVG**

[writeAsSvg](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) schrijft de gerenderde inhoud van één vorm naar een stroom. Het resultaat bevat alleen de vorm, niet de volledige dia‑achtergrond of naburige vormen.

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

Houd de presentatie open tijdens het renderen. De output hangt af van de opmaak van de vorm en van hulpbronnen zoals lettertypen en afbeeldingen. Als je de volledige compositie nodig hebt, exporteer dan de dia in plaats van één afzonderlijke vorm. De aanroeper bezit de stroom en moet deze sluiten.

## **Lijn vormen uit**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) overloads lijnen ofwel alle vormen of geselecteerde collectie‑indexen uit. [ShapesAlignmentType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/shapesalignmenttype/) specificeert de rand, middenlijn of distributiemodus. Stel `alignToSlide` in op `true` om de randen van de dia te gebruiken; stel in op `false` om de geselecteerde vormen ten opzichte van elkaar uit te lijnen.

Dit voorbeeld lijn drie vormen uit naar de bovenrand van de dia. De geretourneerde vormreferenties worden direct vóór het uitlijnen omgezet naar hun huidige indexen.

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

Uitlijning wijzigt posities, niet de z‑volgorde. Relatieve uitlijning vereist normaal gezien minstens twee vormen, terwijl horizontale of verticale distributie genoeg vormen nodig heeft om de afstand te definiëren. Herbereken indexen als je de collectie wijzigingen vóór het aanroepen van de methode.

## **Spiegel een vorm**

De klasse [ShapeFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/shapeframe/) slaat positie, grootte, horizontale en verticale spiegelinstellingen en rotatie op. Zijn `getFlipH` en `getFlipV` waarden gebruiken [NullableBool](https://reference.aspose.com/slides/nl/java/com.aspose.slides/nullablebool/): `True` activeert de spiegel, `False` schakelt deze uit, en `NotDefined` behoudt de ongespecificeerde/standaard status.

De invoerpresentatie hieronder bevat één niet‑gespiegelde vorm.

![De vorm vóór het spiegelen](shape_to_be_flipped.png)

Het voorbeeld behoudt alle andere frame‑waarden en vervangt alleen de twee spiegelinstellingen. Dit is belangrijk omdat het toewijzen van een nieuw [Frame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) het volledige frame vervangt.

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

De opgeslagen vorm is horizontaal en verticaal gespiegeld terwijl positie, grootte en rotatie behouden blijven.

![De vorm na het spiegelen](flipped_shape.png)

## **FAQ**

**Moet ik een collectie‑index gebruiken als vormidentifier?**

Alleen voor kortstondige verwerking wanneer de collectie niet verandert vóórdat de index wordt gebruikt. Geef de voorkeur aan een gevalideerde `Name`‑ of `AlternativeText`‑conventie voor opgestelde sjablonen, of `OfficeInteropShapeId` voor interop‑werk op diavolume.

**Verwijdert verbergen van een vorm deze uit de Z‑volgorde?**

Nee. Een verborgen vorm blijft in de collectie op dezelfde index. Hij kan worden gevonden, herschikt, bewerkt of opnieuw zichtbaar gemaakt.

**Waarom verscheen een gekloonde vorm voor een andere vorm?**

`addClone` voegt de kloon toe aan het einde van de collectie, wat de voorgrond van de Z‑volgorde is. Gebruik `insertClone` om de initiële index te kiezen of `reorder` nadat alle vormen zijn toegevoegd.

**Kan ik een vaste index gebruiken om een preset‑vormaanpassing te identificeren?**

Alleen na het valideren van de exacte preset en collectie‑lay‑out. Geef de voorkeur aan itereren door `IGeometryShape.getAdjustments` en controleren van `IAdjustValue.getType`; gebruik `IAdjustValue.getName` als extra informatie wanneer hetzelfde semantische type meer dan eenmaal voorkomt.