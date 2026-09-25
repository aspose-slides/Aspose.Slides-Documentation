---
title: Beheer presentatievormen op Android
linktitle: Vormmanipulatie
type: docs
weight: 40
url: /nl/androidjava/shape-manipulations/
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
- voorgeinstelde vormaanpassing
- vormgeometrie
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
description: "Leer hoe u presentatie‑vormen kunt identificeren, aanpassen, klonen, verwijderen, verbergen, opnieuw ordenen, exporteren, uitlijnen en spiegelen met Aspose.Slides voor Android via Java."
---
## **Overzicht**

Aspose.Slides for Android via Java stelt de vormen op een dia voor als een geordende [IShapeCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishapecollection/). De collectie is zowel de plek waar je vormen vindt en wijzigt als de bron van hun stapelvolgorde: index `0` is de vorm die het verst achteraan staat, terwijl de laatste index de vorm is die het verst vooraan staat.

Dit artikel volgt dat model. Het legt eerst uit hoe je een vorm betrouwbaar kunt identificeren en vooraf ingestelde aanpassingspunten kunt wijzigen, en laat vervolgens zien hoe je vormen kunt klonen, verwijderen, verbergen en opnieuw ordenen. De laatste secties behandelen opmaak op layout‑niveau, SVG‑export, uitlijning en spiegelinstellingen. Elk voorbeeld staat op zichzelf, zodat je alleen de bewerkingen kunt gebruiken die jouw workflow vereist.

## **Vormen identificeren en vinden**

Collectie‑indexen zijn handig bij het verwerken van een bekend bestand, maar ze zijn geen stabiele identifiers. Het toevoegen, verwijderen of opnieuw ordenen van een vorm kan de index wijzigen. Kies een identifier op basis van hoe de presentatie is gemaakt en onderhouden:

- [Name](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/#getName--) is nuttig voor door ontwikkelaars beheerde sjablonen en is eenvoudig te inspecteren in het selectiepaneel van PowerPoint. Namen kunnen worden bewerkt en zijn niet gegarandeerd uniek, dus stel een naamgevingsconventie vast als code ervan afhankelijk is.
- [AlternativeText](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/#getAlternativeText--) is handig wanneer een toegankelijkheidsbeschrijving of een door de auteur toegevoegde tag de vorm al identificeert. Het is zichtbaar voor gebruikers, kan worden gelokaliseerd of herschreven voor toegankelijkheid, en is niet gegarandeerd uniek. Gebruik een betekenisvolle toegankelijkheidstekst niet stilletjes als databasesleutel.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) is een alleen‑lezen identifier die uniek is binnen een dia en overeenkomt met de vorm‑ID die PowerPoint‑interop gebruikt. Gebruik deze wanneer je integreert met PowerPoint of wanneer je een ondubbelzinnige referentie nodig hebt gedurende de levensduur van een vorm. Een gekloonde of opnieuw aangemaakte vorm is een andere vorm en krijgt een eigen ID.

De verwante [getUniqueId](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/#getUniqueId--)‑methode retourneert een identifier met presentatie‑bereik, maar die identifier is bedoeld voor add‑ins en kan worden herverdeeld. Hij mag niet worden behandeld als een permanente externe sleutel. Als langdurige identiteit essentieel is, bewaar dan de mapping in toepassingsdata en controleer of de verwachte vorm nog steeds bestaat.

Voor een praktisch voorbeeld van het lezen en bijwerken van zowel de alternatieve‑tekst‑titel als -beschrijving, zie [Manage Alternative Text Titles and Descriptions](/slides/nl/androidjava/presentation-accessibility/). Gebruik alternatieve tekst om de betekenis van het visuele element aan lezers uit te leggen, en houd deze gescheiden van vorm‑namen die door code worden gebruikt om vormen te vinden.

Het volgende voorbeeld zoekt op naam met een exacte vergelijking en rapporteert de interop‑ID die binnen de dia geldt. Wanneer de sjabloon de verwachte vorm niet bevat, meldt de code dat resultaat in plaats van door te gaan met het verkeerde object.

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

Wanneer een bewerking specifiek is voor een bepaald vormtype, controleer dan de interface voordat je type‑specifieke leden gebruikt. Dit voorbeeld werkt tekst en alternatieve tekst alleen bij als het benoemde object een [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) is.

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

## **Identificeren en aanpassen van vooraf ingestelde vormaanpassingen**

Vooraf ingestelde geometrievormen kunnen aanpassingspunten blootleggen die eigenschappen zoals hoekkleur, pijlpatroon of booghoeken regelen. Toegang krijg je via de alleen‑lezen [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/igeometryshape/#getAdjustments--) collectie. De collectie zelf wordt geleverd door de vorm, maar elk [IAdjustValue](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iadjustvalue/) bevat een waarde die kan worden gewijzigd.

Vertrouw niet uitsluitend op een vaste collectie‑index. Loop door de aanpassingen en inspecteer de alleen‑lezen [getType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iadjustvalue/#getType--)‑methode, waarvan de [ShapeAdjustmentType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/shapeadjustmenttype/)‑waarde aangeeft wat de aanpassing regelt. De alleen‑lezen [getName](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iadjustvalue/#getName--)‑methode biedt extra identificatie‑informatie en is vooral nuttig wanneer een preset meer dan één aanpassing met hetzelfde semantische type bevat.

Gebruik de waardemethode die past bij de betekenis van de aanpassing:

| Aanpassingstype | Doel | Waarde om te wijzigen |
|---|---|---|
| `CornerSize` | Grootte van afgeronde hoeken | [setRawValue](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iadjustvalue/#setRawValue-long-) |
| `ArrowTailThickness` | Dikte van een pijlstaaart | `setRawValue` |
| `ArrowheadLength` | Lengte van een pijlpunt | `setRawValue` |
| `ArrowheadWidth` | Breedte van een pijlpunt | `setRawValue` |
| `StartAngle` | Starthoek van een taart‑ of boogsegment | [setAngleValue](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iadjustvalue/#setAngleValue-float-) |
| `EndAngle` | Eindhoek van een taart‑ of boogsegment | `setAngleValue` |

`getType` en `getName` leveren alleen‑lezen informatie. `getRawValue` en `setRawValue` werken met een geheel getal in de native eenheden van de preset‑geometrie, terwijl `getAngleValue` en `setAngleValue` werken met een hoek in graden. Het aantal, de volgorde, de betekenis en het geldige bereik van aanpassingen hangen af van het preset‑[ShapeType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/igeometryshape/#getShapeType--). Een waarde die geldig is voor de ene preset kan ongeldig zijn of een ander effect hebben voor een andere.

Wanneer `getType` `ShapeAdjustmentType.Custom` retourneert, herkent de API geen standaard semantische betekenis. Inspecteer `getName`, het preset‑type en de bestaande waarde, en laat de aanpassing ongewijzigd tenzij de verwachte betekenis en range bekend zijn. Zelfs voor herkende types, controleer of hetzelfde type meer dan één keer voorkomt voordat je een waarde selecteert. Het artikel over [Connector](/slides/nl/androidjava/connector/) toont deze situatie met connector‑buig‑aanpassingen.

Het volgende volledige voorbeeld maakt standaard‑ en aangepaste versies van drie preset‑vormen. Het doorloopt elke aanpassing, meldt zijn naam en type, wijzigt grootte‑gerelateerde waarden via `setRawValue`, wijzigt hoeken via `setAngleValue` en slaat het resultaat op. De linker kolom behoudt de standaardgeometrie; de rechter kolom toont de aangepaste afgeronde rechthoek, vierweg‑pijl en taart‑segment.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Voegt kopteksten toe voor de standaard- en aangepaste vormkolommen.
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

De semantische type controleren voordat je een waarde wijzigt, maakt de code expliciet in zijn intentie en voorkomt aannames dat een bepaalde collectie‑index dezelfde betekenis heeft bij verschillende preset‑vormen.

## **Vormcollectie aanpassen**

De add‑, clone‑, remove‑ en reorder‑methodes werken meteen op de collectie. Als een bewerking het aantal of de volgorde van vormen wijzigt, vertrouw dan niet langer op indexen die vóór die bewerking zijn vastgelegd.

### **Een vorm klonen**

[addClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) maakt een onafhankelijke kopie en voegt die toe aan de doelcollectie. [insertClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) maakt ook een kopie, maar plaatst deze op een opgegeven z‑order‑index. De overloads die coördinaten accepteren verplaatsen de kloon zonder de grootte te wijzigen; overloads met breedte en hoogte kunnen deze eveneens aanpassen.

Het voorbeeld maakt een doel‑dia, klont een gelabelde rechthoek naar voren en voegt een tweede kloon achterin in. Wijzigingen aan een van beide klonen wijzigen de bronvorm niet.

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

Klonen kopieert de inhoud en opmaak van de vorm, inclusief naam en alternatieve tekst. Ken nieuwe logische identifiers toe aan de kloon wanneer die waarden uniek moeten zijn. Resources die complexe vormen gebruiken, worden door de presentatie beheerd, maar een kloon blijft een nieuw collectie‑item met een nieuwe vormidentiteit.

### **Vormen verwijderen**

[remove](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) verwijdert een specifiek vormobject uit zijn collectie. Wanneer je meerdere overeenkomsten wilt verwijderen tijdens een geïndexeerde iteratie, loop dan van het einde zodat elke overgebleven index geldig blijft.

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

Na het verwijderen veranderen het aantal vormen en de indexen van latere vormen. Verwijzingen naar ongewijzigde vormen blijven betrouwbaarder dan opgeslagen indexen. Houd ook rekening met connectoren, animaties en andere presentatiefuncties die naar het verwijderde object kunnen verwijzen; het verwijderen van een zichtbare vorm kan meer veranderen dan alleen het uiterlijk van de dia.

### **Een vorm verbergen**

Het instellen van [Hidden](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/#setHidden-boolean-) op `true` houdt de vorm in de collectie, maar voorkomt dat deze verschijnt in de normale diavoorstelling. Zijn index, opmaak en inhoud blijven beschikbaar voor code, zodat verbergen geschikt is voor optionele elementen die later eventueel hersteld kunnen worden.

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

Verbergen is geen verwijdering of beveiliging. Het object kan nog steeds worden gevonden en ontgrendeld door een gebruiker of door code, en blijft deel uitmaken van het presentatie‑bestand.

### **De Z‑volgorde wijzigen**

Overschrijdende vormen worden getekend in de volgorde van de collectie. [reorder](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) verplaatst een bestaande vorm naar een doel‑index zonder deze te klonen. Index `0` is de achterste; `size() - 1` is de voorste.

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

De rechthoek wordt eerst aangemaakt en begint achter de ellips. Verplaatsing naar de laatste index brengt deze naar voren. Voltooi de Z‑volgorde nadat je alle gerelateerde vormen hebt toegevoegd of gekloond, want die bewerkingen voegen nieuwe collectie‑items toe of wijzigen de stapel.

## **Vormen inspecteren op layoutdia's**

Normale dia's, layout‑dia's en master‑dia's hebben aparte vormcollecties. Een vorm in een layout‑collectie is niet hetzelfde object als een soortgelijke vorm op een normale dia. Inspecteer layout‑vormen wanneer je de door een layout geleverde opmaak moet begrijpen of wijzigen.

Het volgende voorbeeld leest voor elke layout‑vorm de [FillFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/#getFillFormat--) en [LineFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/#getLineFormat--) zonder aan te nemen dat elke vorm een `AutoShape` is.

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

Het bewerken van een layout kan meerdere dia's beïnvloeden die de layout gebruiken. Voordat je een layout‑vorm wijzigt, bepaal of een normale dia het object erft of een lokale overschrijving bevat, en test elke dia die die layout gebruikt.

## **Een vorm exporteren naar SVG**

[writeAsSvg](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) schrijft de gerenderde inhoud van één vorm naar een stream. Het resultaat bevat alleen de vorm, niet de volledige achtergrond van de dia of naburige vormen.

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

Houd de presentatie geopend tijdens het renderen. De output hangt af van de opmaak van de vorm en van resources zoals lettertypen en afbeeldingen. Als je de volledige compositie nodig hebt, exporteer dan de dia in plaats van een individuele vorm. De aanroeper bezit de stream en moet deze sluiten.

## **Vormen uitlijnen**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) heeft overloads die ofwel alle vormen of geselecteerde collectie‑indexen uitlijnt. [ShapesAlignmentType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/shapesalignmenttype/) geeft de rand, middellijn of distributiemodus aan. Stel `alignToSlide` in op `true` om de randen van de dia te gebruiken; stel in op `false` om de geselecteerde vormen ten opzichte van elkaar uit te lijnen.

Dit voorbeeld lijnt drie vormen uit met de bovenrand van de dia. De geretourneerde vorm‑referenties worden meteen vóór de uitlijning omgezet naar hun huidige indexen.

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

Uitlijnen wijzigt posities, niet de Z‑volgorde. Relatieve uitlijning vereist normaal gesproken minstens twee vormen, terwijl horizontale of verticale distributie voldoende vormen nodig heeft om de afstand te bepalen. Herbereken indexen als je de collectie wijzigt vóór het aanroepen van de methode.

## **Een vorm spiegelen**

[ShapeFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/shapeframe/) slaat positie, grootte, horizontale en verticale spiegelinstellingen en rotatie op. Zijn `getFlipH`‑ en `getFlipV`‑waarden gebruiken [NullableBool](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/nullablebool/): `True` schakelt de spiegel in, `False` schakelt hem uit, en `NotDefined` behoudt de ongedefinieerde/standaardstatus.

De invoerpresentatie hieronder bevat één niet‑gespiegelde vorm.

![De vorm voordat deze gespiegeld is](shape_to_be_flipped.png)

Het voorbeeld behoudt elke andere frame‑waarde en vervangt alleen de twee spiegelinstellingen. Dit is belangrijk omdat het toewijzen van een nieuw [Frame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) het volledige frame vervangt.

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

De opgeslagen vorm is zowel horizontaal als verticaal gespiegeld, terwijl positie, grootte en rotatie behouden blijven.

![De vorm na het spiegelen](flipped_shape.png)

## **FAQ**

**Moet ik een collectie‑index gebruiken als vorm‑identificator?**

Alleen voor kortstondige verwerking wanneer de collectie niet verandert vóórdat de index wordt gebruikt. Geef de voorkeur aan een gevalideerde `Name`‑ of `AlternativeText`‑conventie voor sjablonen, of `OfficeInteropShapeId` voor interop‑werk binnen een dia.

**Verwijdert het verbergen van een vorm deze uit de Z‑volgorde?**

Nee. Een verborgen vorm blijft in de collectie op dezelfde index. Hij kan worden gevonden, opnieuw geordend, bewerkt of weer zichtbaar gemaakt.

**Waarom verscheen een gekloonde vorm voor een andere vorm?**

`addClone` voegt de kloon toe aan het einde van de collectie, wat de voorste positie in de Z‑volgorde is. Gebruik `insertClone` om een specifieke start‑index te kiezen of `reorder` nadat alle vormen zijn toegevoegd.

**Kan ik een vaste index gebruiken om een vooraf ingestelde vormaanpassing te identificeren?**

Alleen na het valideren van de exacte preset en de collectie‑structuur. Geef de voorkeur aan itereren door `IGeometryShape.getAdjustments` en het controleren van `IAdjustValue.getType`; gebruik `IAdjustValue.getName` als extra informatie wanneer hetzelfde semantische type meer dan één keer voorkomt.