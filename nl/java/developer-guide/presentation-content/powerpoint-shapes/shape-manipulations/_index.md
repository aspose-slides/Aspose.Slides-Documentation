---
title: Beheer presentatievormen in Java
linktitle: Vormmanipulatie
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
- voorgedefinieerde vormaanpassing
- vormgeometrie
- vorm‑lay-outformaten
- vorm als SVG
- vorm naar SVG
- vorm uitlijnen
- vorm spiegelen
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe u presentatievormen kunt identificeren, aanpassen, klonen, verwijderen, verbergen, herschikken, exporteren, uitlijnen en spiegelen met Aspose.Slides voor Java."
---
## **Overzicht**

Aspose.Slides for Java vertegenwoordigt de vormen op een dia als een geordende [IShapeCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishapecollection/). De collectie is zowel de plek waar u vormen vindt en wijzigt als de bron van hun stapelvolgorde: index `0` is de achterste vorm, terwijl de laatste index de voorste vorm is.

Dit artikel volgt dat model. Het legt eerst uit hoe u een vorm betrouwbaar kunt identificeren en vooraf ingestelde aanpassingspunten van een vorm kunt wijzigen, en laat vervolgens zien hoe u vormen kunt klonen, verwijderen, verbergen en herschikken. De laatste secties behandelen op lay-outniveau formatteren, SVG-export, uitlijning en spiegelinstellingen. Elk voorbeeld staat op zichzelf, zodat u alleen de bewerkingen kunt gebruiken die uw workflow nodig heeft.

## **Identificeren en vinden van vormen**

Collectie‑indexen zijn handig bij het verwerken van een bekend bestand, maar ze zijn geen stabiele identificatoren. Het toevoegen, verwijderen of herschikken van een vorm kan de index wijzigen. Kies een identificator op basis van hoe de presentatie wordt gemaakt en onderhouden:

- [Name](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/#getName--) is nuttig voor door ontwikkelaars beheerde sjablonen en is gemakkelijk te inspecteren in het selectiepaneel van PowerPoint. Namen kunnen worden bewerkt en zijn niet gegarandeerd uniek, dus stel een naamgevingsconventie vast als code ervan afhankelijk is.
- [AlternativeText](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/#getAlternativeText--) is handig wanneer een toegankelijkheidsbeschrijving of een door de auteur toegevoegde tag de vorm al identificeert. Het is zichtbaar voor gebruikers, kan worden gelokaliseerd of herschreven voor toegankelijkheid, en is niet gegarandeerd uniek. Gebruik betekenisvolle toegankelijkheidstekst niet stilletjes als een databasesleutel.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--) is een alleen‑lezen‑identificator die uniek is binnen een dia en overeenkomt met de vorm‑ID die PowerPoint‑interop gebruikt. Gebruik deze wanneer u integreert met PowerPoint of wanneer u een ondubbelzinnige referentie nodig hebt gedurende de levensduur van een vorm. Een gekloonde of opnieuw gemaakte vorm is een andere vorm en krijgt een eigen ID.

De gerelateerde [getUniqueId](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/#getUniqueId--)‑methode retourneert een identificator met presentatiescope, maar die identificator is bedoeld voor add‑ins en kan worden herkend. Hij moet niet worden beschouwd als een permanente externe sleutel. Als langdurige identiteit essentieel is, bewaar dan de mapping in toepassingsdata en controleer of de verwachte vorm nog bestaat.

Voor een praktisch voorbeeld van het lezen en bijwerken van zowel de alternatieve‑tekstitel als de beschrijving, zie [Manage Alternative Text Titles and Descriptions](/slides/nl/java/presentation-accessibility/). Gebruik alternatieve tekst om de betekenis van het visuele element uit te leggen aan lezers, en houd deze gescheiden van vorm‑namen die door code worden gebruikt om vormen te vinden.

Het volgende voorbeeld zoekt op naam met een exacte vergelijking en rapporteert de interop‑ID met diascop. Wanneer de sjabloon de verwachte vorm niet bevat, meldt de code dat resultaat in plaats van door te gaan met het verkeerde object.

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

Wanneer een bewerking specifiek is voor een vormtype, controleer dan de interface voordat u type‑specifieke leden gebruikt. Dit voorbeeld werkt tekst en alternatieve tekst alleen bij als het benoemde object een [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/) is.

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

## **Identificeren en wijzigen van vooraf ingestelde vorm‑aanpassingen**

Vooraf ingestelde geometrievormen kunnen aanpassingspunten blootgeven die kenmerken regelen, zoals hoekgrootte, pijlenverhoudingen of booghoeken. Benader ze via de alleen‑lezen [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/nl/java/com.aspose.slides/igeometryshape/#getAdjustments--)‑collectie. De collectie zelf wordt geleverd door de vorm, maar elke [IAdjustValue](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iadjustvalue/) bevat een waarde die kan worden gewijzigd.

Vertrouw niet uitsluitend op een vaste collectie‑index. Loop door de aanpassingen en inspecteer de alleen‑lezen‑methode [getType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iadjustvalue/#getType--) waarvan de waarde van het [ShapeAdjustmentType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/shapeadjustmenttype/) beschrijft wat de aanpassing regelt. De alleen‑lezen‑methode [getName](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iadjustvalue/#getName--) geeft extra identificatie‑informatie en is vooral nuttig wanneer een preset meer dan één aanpassing met hetzelfde semantische type bevat.

Gebruik de waardemethode die overeenkomt met de betekenis van de aanpassing:

| Aanpassingstype | Doel | Waarde om te wijzigen |
|---|---|---|
| `CornerSize` | Grootte van afgeronde hoeken | [setRawValue](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iadjustvalue/#setRawValue-long-) |
| `ArrowTailThickness` | Dikte van een pijpstaart | `setRawValue` |
| `ArrowheadLength` | Lengte van een pijpkop | `setRawValue` |
| `ArrowheadWidth` | Breedte van een pijpkop | `setRawValue` |
| `StartAngle` | Beginhoek van een taart- of boogvorm | [setAngleValue](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iadjustvalue/#setAngleValue-float-) |
| `EndAngle` | Eindhoek van een taart- of boogvorm | `setAngleValue` |

`getType` en `getName` retourneren alleen‑lezen‑informatie. `getRawValue` en `setRawValue` werken met een geheel getal in de native‑eenheden van de preset‑geometrie, terwijl `getAngleValue` en `setAngleValue` werken met een hoek in graden. Het aantal, de volgorde, de betekenis en het geldige bereik van de aanpassingen hangen af van de preset‑[ShapeType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/igeometryshape/#getShapeType--). Een waarde die geldig is voor de ene preset kan ongeldige of een ander effect hebben voor een andere.

Wanneer `getType` `ShapeAdjustmentType.Custom` retourneert, herkent de API geen standaard semantische betekenis. Inspecteer `getName`, het preset‑type en de bestaande waarde, en laat de aanpassing ongewijzigd tenzij de verwachte betekenis en het bereik bekend zijn. Zelfs voor herkende types, controleer of hetzelfde type meer dan eens voorkomt voordat u een waarde kiest. Het artikel over [Connector](/slides/nl/java/connector/) toont deze situatie met bocht‑aanpassingen van connectoren.

Het volgende volledige voorbeeld maakt standaard‑ en gewijzigde versies van drie preset‑vormen. Het loopt door elke aanpassing, rapporteert de naam en het type, wijzigt grootte‑gerelateerde waarden via `setRawValue`, wijzigt hoeken via `setAngleValue`, en slaat het resultaat op. De linkerkolom behoudt de standaardgeometrie; de rechterkolom toont de aangepaste afgeronde rechthoek, vier‑richting‑pijl en taart.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Voegt kopteksten toe voor de kolommen met standaard- en aangepaste vormen.
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

Het controleren van het semantische type vóór het wijzigen van een waarde maakt de code expliciet over de bedoeling en voorkomt aannames dat een bepaalde collectie‑index dezelfde betekenis heeft bij verschillende preset‑vormen.

## **De vormcollectie wijzigen**

De methoden add, clone, remove en reorder werken direct op de collectie. Als een bewerking het aantal of de volgorde van vormen verandert, baseer u zich daarna niet meer op indexen die vóór die bewerking zijn vastgelegd.

### **Een vorm klonen**

[addClone](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) maakt een onafhankelijk exemplaar en voegt het toe aan de doel‑collectie. [insertClone](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) maakt eveneens een kopie, maar plaatst deze op een opgegeven z‑order‑index. De overloads die coördinaten accepteren verplaatsen de kloon zonder de grootte te veranderen; overloads met breedte en hoogte kunnen deze ook aanpassen.

Het voorbeeld maakt een doel‑dia, kloont een gelabelde rechthoek naar de voorkant, en voegt een tweede kloon toe aan de achterkant. Wijzigingen aan een van beide klonen wijzigen de bronvorm niet.

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

Klonen kopieert de inhoud en opmaak van de vorm, inclusief naam en alternatieve tekst. Ken nieuwe logische identificatoren toe aan de kloon wanneer die waarden uniek moeten zijn. Bronnen die door complexe vormen worden gebruikt, worden beheerd door de presentatie, maar een kloon blijft een nieuw collectie‑item met een nieuwe vorm‑identiteit.

### **Vormen verwijderen**

[remove](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) verwijdert een specifiek vormobject uit zijn collectie. Wanneer u meerdere overeenkomsten tijdens een geïndexeerde iteratie wilt verwijderen, loop dan van achteren naar voren zodat elke overgebleven index geldig blijft.

Dit voorbeeld verwijdert elke vorm met een bepaalde naam. Het leest de vorm op de huidige index, niet een vaste collectie‑item, en cast de vorm niet onnodig.

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

Na verwijdering veranderen het aantal vormen en de indexen van de latere vormen. Verwijzingen naar onbewerkte vormen blijven betrouwbaarder dan opgeslagen indexen. Houd ook rekening met connectoren, animaties en andere presentatiefuncties die naar het verwijderde object kunnen verwijzen; het verwijderen van een zichtbare vorm kan meer veranderen dan alleen het uiterlijk van de dia.

### **Een vorm verbergen**

Het instellen van [Hidden](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/#setHidden-boolean-) op `true` houdt de vorm in de collectie, maar voorkomt dat deze verschijnt in de normale diavoorstelling. De index, opmaak en inhoud blijven beschikbaar voor code, dus verbergen is geschikt voor optionele elementen die later eventueel hersteld kunnen worden.

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

Verbergen is geen verwijderen of beveiliging. Het object kan nog steeds worden gevonden en zichtbaar worden gemaakt door een gebruiker of door code, en blijft onderdeel van het presentatie‑bestand.

### **De Z‑order wijzigen**

Opeenvolgende vormen worden getekend in de volgorde van de collectie. [reorder](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) verplaatst een bestaande vorm naar een doel‑index zonder deze te klonen. Index `0` is de achterkant; `size() - 1` is de voorkant.

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

De rechthoek wordt eerst gemaakt en staat aanvankelijk achter de ellips. Het verplaatsen naar de laatste index brengt deze naar voren. Voltooi de z‑order pas nadat u alle gerelateerde vormen hebt toegevoegd of gekloond, want die bewerkingen voegen nieuwe collectie‑items toe of voegen ze in en kunnen de beoogde stapel wijzigen.

## **Vormen op lay‑outdia’s inspecteren**

Normale dia’s, layout‑dia’s en master‑dia’s hebben afzonderlijke vormcollecties. Een vorm in een layout‑collectie is niet hetzelfde object als een vergelijkbaar gepositioneerde vorm op een normale dia. Inspecteer layout‑vormen wanneer u de door een layout geleverde opmaak moet begrijpen of wijzigen.

Het volgende voorbeeld leest voor elke layout‑vorm de [FillFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/#getFillFormat--) en [LineFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/#getLineFormat--) zonder ervan uit te gaan dat elke vorm een `AutoShape` is.

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

Het bewerken van een layout kan meerdere dia’s beïnvloeden die deze gebruiken. Controleer vóór het wijzigen van een layout‑vorm of een normale dia het object erft of een lokale overschrijving bevat, en test elke dia die die layout gebruikt.

## **Een vorm exporteren naar SVG**

[writeAsSvg](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) schrijft de gerenderde inhoud van één vorm naar een stream. Het resultaat bevat alleen de vorm, niet de volledige dia‑achtergrond of naburige vormen.

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

Houd de presentatie open tijdens het renderen. De output hangt af van de opmaak van de vorm en van bronnen zoals lettertypen en afbeeldingen. Als u de volledige compositie nodig heeft, exporteer dan de dia in plaats van een individuele vorm. De aanroeper bezit de stream en moet deze sluiten.

## **Vormen uitlijnen**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) heeft overloads die ofwel alle vormen of geselecteerde collectie‑indexen uitlijnen. [ShapesAlignmentType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/shapesalignmenttype/) specificeert de rand, het midden of de verdelingsmodus. Stel `alignToSlide` in op `true` om de dia‑randen te gebruiken; stel in op `false` om de geselecteerde vormen relatief ten opzichte van elkaar uit te lijnen.

Dit voorbeeld lineert drie vormen uit op de bovenrand van de dia. De geretourneerde vormreferenties worden direct voor uitlijning omgezet naar hun huidige indexen.

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

Uitlijnen verandert posities, niet de z‑order. Relatieve uitlijning vereist normaal gezien minstens twee vormen, terwijl horizontale of verticale verdeling voldoende vormen nodig heeft om de afstand te bepalen. Herbereken indexen als u de collectie wijzigt vóór het aanroepen van de methode.

## **Een vorm spiegelen**

De [ShapeFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/shapeframe/)‑klasse bewaart positie, grootte, horizontale en verticale spiegelinstellingen en rotatie. De waarden `getFlipH` en `getFlipV` gebruiken [NullableBool](https://reference.aspose.com/slides/nl/java/com.aspose.slides/nullablebool/): `True` schakelt de spiegel in, `False` schakelt hem uit, en `NotDefined` behoudt de ongespecificeerde/standaardstatus.

De invoerpresentatie hieronder bevat één niet‑gespiegelde vorm.

![The shape before flipping](shape_to_be_flipped.png)

Het voorbeeld behoudt elke andere frame‑waarde en vervangt alleen de twee spiegelinstellingen. Dit is belangrijk omdat het toewijzen van een nieuw [Frame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) het volledige frame vervangt.

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

De opgeslagen vorm is horizontaal en verticaal gespiegeld, terwijl positie, grootte en rotatie behouden blijven.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Moet ik een collectie‑index gebruiken als vorm‑identificator?**

Alleen voor kortstondige verwerking wanneer de collectie niet verandert vóórdat de index wordt gebruikt. Geef de voorkeur aan een gevalideerde `Name`‑ of `AlternativeText`‑conventie voor aangemaakte sjablonen, of `OfficeInteropShapeId` voor interop‑werk met diascop.

**Verwijdert verbergen van een vorm hem uit de z‑order?**

Nee. Een verborgen vorm blijft in de collectie op dezelfde index. Hij kan worden gevonden, herschikt, bewerkt of opnieuw zichtbaar gemaakt.

**Waarom verscheen een gekloonde vorm voor een andere vorm?**

`addClone` voegt de kloon toe aan het einde van de collectie, wat de voorkant van de z‑order is. Gebruik `insertClone` om de initiële index te kiezen of `reorder` nadat alle vormen zijn toegevoegd.

**Kan ik een vaste index gebruiken om een preset‑vormaanpassing te identificeren?**

Alleen na het valideren van de exacte preset en collectie‑indeling. Geef de voorkeur aan itereren door `IGeometryShape.getAdjustments` en controleer `IAdjustValue.getType`; gebruik `IAdjustValue.getName` als extra informatie wanneer hetzelfde semantische type meer dan één keer voorkomt.