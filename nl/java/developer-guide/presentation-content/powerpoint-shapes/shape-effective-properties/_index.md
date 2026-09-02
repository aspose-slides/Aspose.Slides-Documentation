---
title: Shape‑effectieve eigenschappen uit presentaties ophalen in Java
linktitle: Effectieve eigenschappen
type: docs
weight: 50
url: /nl/java/shape-effective-properties/
keywords:
- shape‑eigenschappen
- camera‑eigenschappen
- licht‑rig
- bevel‑vorm
- tekstframe
- tekststijl
- letterhoogte
- vulopmaak
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe u Aspose.Slides voor Java kunt gebruiken om lokale, geërfde en effectieve vormopmaak in PowerPoint‑presentaties te onderscheiden."
---
## **Begrijp lokale, geërfde en effectieve eigenschappen**

PowerPoint‑opmaak kan van verschillende plaatsen komen. De waarde die rechtstreeks op een object is opgeslagen, is de **lokale waarde**. Als die waarde niet is ingesteld, kijkt PowerPoint naar bovenliggende opmaakbronnen, zoals een alinea‑standaard, een tekst‑stijl, een lay‑out‑ of masterslide, een thema of standaardinstellingen op presentatieniveau. Die waarden zijn **geërfde waarden**. De waarde die overblijft nadat de volledige hiërarchie is opgelost, is de **effectieve waarde** — de waarde die wordt gebruikt om het object weer te geven.

Bijvoorbeeld, een tekstgedeelte definieert misschien niet zijn eigen letterhoogte. Zijn lokale [getFontHeight](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibaseportionformat/#getFontHeight--) waarde is dan `Float.NaN`, wat betekent “niet hier ingesteld”. Het gedeelte kan een hoogte erven van zijn alinea, de standaard‑tekst‑stijl van de presentatie, of een andere van toepassing zijnde bron. Het aanroepen van [getEffective](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iportionformat/#getEffective--) op het gedeelte‑formaat retourneert de uiteindelijk opgeloste hoogte.

Gebruik de twee soorten opmaakgegevens voor verschillende doeleinden:

- Lees of wijzig een lokaal opmaakobject, zoals [IPortionFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iportionformat/), wanneer je wilt controleren waar een waarde is gedefinieerd.
- Lees een effectief gegevensobject, zoals [IPortionFormatEffectiveData](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iportionformateffectivedata/), wanneer je het uiteindelijke, gerenderde resultaat nodig hebt. Effectieve gegevens zijn alleen‑lezen.

## **Vergelijk lokale, geërfde en effectieve waarden**

Het volgende volledige voorbeeld maakt een vorm aan en past letterhoogtes toe op presentatieniveau, alinea‑niveau en gedeelte‑niveau. Elke stap drukt de waarden af die op die niveaus zijn gedefinieerd en de resulterende effectieve waarde voor hetzelfde tekstgedeelte. Het laat ook zien waarom effectieve gegevens opnieuw moeten worden gelezen na opmaakwijzigingen.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, false);
            ITextFrame textFrame = shape.addTextFrame("Effective formatting");
            IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
            IPortion portion = paragraph.getPortions().get_Item(0);

            // Definieer geërfde waarden op twee verschillende niveaus.
            presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20);
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);

            printFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

            // Een lokale waarde op het gedeelte overschrijft beide geërfde waarden.
            portion.getPortionFormat().setFontHeight(36);
            printFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

            // Het wijzigen van een geërfde waarde overschrijft geen bestaande lokale waarde.
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30);
            printFontHeights("The local value still has priority", presentation, paragraph, portion);

            // Wis de lokale waarde. Het gedeelte erft nu opnieuw van de alinea.
            portion.getPortionFormat().setFontHeight(Float.NaN);
            printFontHeights("The local value is cleared", presentation, paragraph, portion);

            // Wis de alinea‑waarde. De presentatiestandaard levert nu het resultaat.
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(Float.NaN);
            printFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

            presentation.save("effective-properties.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }

    private static void printFontHeights(String caption, Presentation presentation, IParagraph paragraph, IPortion portion) {
        float presentationValue = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight();
        float paragraphValue = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight();
        float localValue = portion.getPortionFormat().getFontHeight();

        // Lees effectieve gegevens na de voorafgaande wijzigingen.
        float effectiveValue = portion.getPortionFormat().getEffective().getFontHeight();

        System.out.println(caption);
        System.out.println("  Presentation default: " + formatLocalValue(presentationValue));
        System.out.println("  Paragraph default:    " + formatLocalValue(paragraphValue));
        System.out.println("  Portion local:        " + formatLocalValue(localValue));
        System.out.println("  Portion effective:    " + effectiveValue);
    }

    private static String formatLocalValue(float value) {
        return Float.isNaN(value) ? "<not set>" : Float.toString(value);
    }
}
```

De prioriteit in dit voorbeeld is lokale opmaak van het gedeelte, daarna alinea‑opmaak, en vervolgens de standaard van de presentatie. Andere objecten kunnen verschillende erf‑ketens hebben, maar het principe blijft hetzelfde: een specifiekere expliciete waarde wint, en [getEffective](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iportionformat/#getEffective--) retourneert het eindresultaat.

## **Verkrijg effectieve teksteigenschappen**

Tekstopmaak is verdeeld over verschillende objecten:

- [ITextFrameFormat.getEffective()](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframeformat/#getEffective--) lost tekst‑frame‑eigenschappen op zoals marges, verankering, autofit en verticale tekstrichting.
- [ITextStyle.getEffective()](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextstyle/#getEffective--) lost alinea‑opmaak op voor elk tekststijl‑niveau.
- [IParagraphFormat.getEffective()](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraphformat/#getEffective--) lost alinea‑eigenschappen op zoals uitlijning, inspringen en opsommingstekens.
- [IPortionFormat.getEffective()](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iportionformat/#getEffective--) lost teken‑eigenschappen op zoals letterhoogte, lettertype, kleur, vet en cursief.

Voor het volgende voorbeeld moet `text-formatting.pptx` ten minste één dia en één [AutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/autoshape/) met een niet‑lege tekstframe bevatten. De AutoShape kan zich op elke positie in de vormverzameling bevinden; de code zoekt naar een geschikt object en valideert dit voordat het wordt gebruikt.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation("text-formatting.pptx");
        try {
            if (presentation.getSlides().size() == 0) {
                throw new IllegalStateException("The presentation contains no slides.");
            }

            IAutoShape shape = findAutoShapeWithText(presentation.getSlides().get_Item(0));
            if (shape == null) {
                throw new IllegalStateException("The first slide must contain an AutoShape with non-empty text.");
            }

            ITextFrame textFrame = shape.getTextFrame();
            IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
            IPortion portion = paragraph.getPortions().get_Item(0);

            ITextFrameFormatEffectiveData textFrameEffective = textFrame.getTextFrameFormat().getEffective();
            IParagraphFormatEffectiveData paragraphEffective = paragraph.getParagraphFormat().getEffective();
            IPortionFormatEffectiveData portionEffective = portion.getPortionFormat().getEffective();

            System.out.println("Text frame margins:");
            System.out.println("  Left: " + textFrameEffective.getMarginLeft());
            System.out.println("  Top: " + textFrameEffective.getMarginTop());
            System.out.println("  Right: " + textFrameEffective.getMarginRight());
            System.out.println("  Bottom: " + textFrameEffective.getMarginBottom());
            System.out.println("Paragraph alignment: " + paragraphEffective.getAlignment());
            System.out.println("Font height: " + portionEffective.getFontHeight());
            System.out.println("Bold: " + portionEffective.getFontBold());

            ITextStyleEffectiveData effectiveTextStyle = textFrame.getTextFrameFormat().getTextStyle().getEffective();
            for (int level = 0; level < 9; level++) {
                IParagraphFormatEffectiveData levelEffective = effectiveTextStyle.getLevel(level);
                System.out.println("Level " + level + " indent: " + levelEffective.getIndent());
            }
        } finally {
            presentation.dispose();
        }
    }

    private static IAutoShape findAutoShapeWithText(ISlide slide) {
        for (IShape candidate : slide.getShapes()) {
            if (candidate instanceof IAutoShape && hasNonEmptyText((IAutoShape)candidate)) {
                return (IAutoShape)candidate;
            }
        }
        return null;
    }

    private static boolean hasNonEmptyText(IAutoShape shape) {
        if (shape.getTextFrame() == null) {
            return false;
        }
        if (shape.getTextFrame().getParagraphs().getCount() == 0) {
            return false;
        }
        return shape.getTextFrame().getParagraphs().get_Item(0).getPortions().getCount() > 0;
    }
}
```

## **Verkrijg effectieve 3D‑eigenschappen**

[IThreeDFormat.getEffective()](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ithreedformat/#getEffective--) retourneert één [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ithreedformateffectivedata/) object dat alle opgeloste 3D‑instellingen groepeert. De methoden [getCamera](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ithreedformateffectivedata/#getCamera--), [getLightRig](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ithreedformateffectivedata/#getLightRig--), [getBevelTop](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ithreedformateffectivedata/#getBevelTop--) en [getBevelBottom](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ithreedformateffectivedata/#getBevelBottom--) geven de overeenkomstige effectieve gegevens weer. Het gezamenlijk lezen van deze gerelateerde instellingen maakt het makkelijker om het uiteindelijke 3D‑Uiterlijk van een vorm te begrijpen.

Voor dit voorbeeld moet `shape-3d.pptx` ten minste één vorm op de eerste dia bevatten. Pas 3D‑camera‑, verlichting‑ of afrondingsinstellingen toe op die vorm als je wilt dat de uitvoer andere waarden dan de standaard bevat.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation("shape-3d.pptx");
        try {
            if (presentation.getSlides().size() == 0 || presentation.getSlides().get_Item(0).getShapes().size() == 0) {
                throw new IllegalStateException("The first slide must contain a shape.");
            }

            IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
            IThreeDFormatEffectiveData threeDEffective = shape.getThreeDFormat().getEffective();

            System.out.println("Camera:");
            System.out.println("  Type: " + threeDEffective.getCamera().getCameraType());
            System.out.println("  Field of view: " + threeDEffective.getCamera().getFieldOfViewAngle());
            System.out.println("  Zoom: " + threeDEffective.getCamera().getZoom());

            System.out.println("Light rig:");
            System.out.println("  Type: " + threeDEffective.getLightRig().getLightType());
            System.out.println("  Direction: " + threeDEffective.getLightRig().getDirection());

            System.out.println("Top bevel:");
            System.out.println("  Type: " + threeDEffective.getBevelTop().getBevelType());
            System.out.println("  Width: " + threeDEffective.getBevelTop().getWidth());
            System.out.println("  Height: " + threeDEffective.getBevelTop().getHeight());
        } finally {
            presentation.dispose();
        }
    }
}
```

## **Verkrijg effectieve tabelopmaak**

Tabelopmaak kan afkomstig zijn van de tabel‑stijl en van opmaken die zijn toegepast op de hele tabel, een kolom, een rij of een individuele cel. Bij conflicten tussen expliciet gedefinieerde opvullingen is de prioriteit: cel, rij, kolom en vervolgens de hele tabel. De effectieve opmaak van een cel is de uiteindelijke opmaak die wordt gebruikt om die cel te tekenen.

Voor dit voorbeeld moet `table-formatting.pptx` ten minste één tabel op de eerste dia bevatten. De tabel moet ten minste één rij en één kolom hebben. De code zoekt naar een [ITable](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itable/) in plaats van ervan uit te gaan dat `getShapes().get_Item(0)` een tabel is.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation("table-formatting.pptx");
        try {
            if (presentation.getSlides().size() == 0) {
                throw new IllegalStateException("The presentation contains no slides.");
            }

            ITable table = findTable(presentation.getSlides().get_Item(0));
            if (table == null) {
                throw new IllegalStateException("The first slide must contain a table.");
            }
            if (table.getRows().size() == 0 || table.getColumns().size() == 0) {
                throw new IllegalStateException("The table must contain at least one cell.");
            }

            ITableFormatEffectiveData tableEffective = table.getTableFormat().getEffective();
            IRowFormatEffectiveData rowEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
            IColumnFormatEffectiveData columnEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
            ICellFormatEffectiveData cellEffective = table.get_Item(0, 0).getCellFormat().getEffective();

            System.out.println("Table fill: " + tableEffective.getFillFormat().getFillType());
            System.out.println("Row fill: " + rowEffective.getFillFormat().getFillType());
            System.out.println("Column fill: " + columnEffective.getFillFormat().getFillType());
            System.out.println("Final cell fill: " + cellEffective.getFillFormat().getFillType());
        } finally {
            presentation.dispose();
        }
    }

    private static ITable findTable(ISlide slide) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ITable) {
                return (ITable)shape;
            }
        }
        return null;
    }
}
```

Als je de kleur nodig hebt in plaats van alleen het opvultype, controleer dan eerst de effectieve [getFillType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifillformateffectivedata/#getFillType--) en lees vervolgens de methode die voor dat type geldt — bijvoorbeeld [getSolidFillColor](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifillformateffectivedata/#getSolidFillColor--) voor een effen opvulling.

## **Lees effectieve gegevens opnieuw na wijzigingen**

Effectieve gegevens beschrijven de opmaakhiërarchie op het moment dat deze is opgelost. Roep `getEffective` opnieuw aan nadat je iets hebt gewijzigd dat aan die hiërarchie kan deelnemen, inclusief:

- de lokale opmaak van het object;
- standaardinstellingen voor alinea’s of tekst‑frames;
- een tabel‑stijl, tabel, kolom, rij of cel‑opmaak;
- lay‑out‑ of masterslide‑opmaak;
- themagegevens of standaardinstellingen op presentatieniveau;
- de lay‑out of master die aan een dia is toegewezen.

Bewaar geen effectief gegevensobject als permanente momentopname. Aspose.Slides kan sommige effectieve gegevens intern cachen, en een latere oproep van `getEffective` kan die gegevens vernieuwen. Als je waarden vóór en na een wijziging wilt vergelijken, kopieer dan de scalare waarden die je nodig hebt — bijvoorbeeld een letterhoogte, kleur, uitlijning of kanteldikte — naar je eigen variabelen voordat je de wijziging doorvoert.

Om een waarde te wijzigen, werk je het juiste lokale opmaakobject bij en roep je daarna `getEffective` aan om het resultaat te verifiëren. Effectieve gegevensobjecten zijn zelf alleen‑lezen.

## **FAQ**

**Hoe kan ik bepalen op welk niveau een effectieve waarde is geleverd?**

Effectieve gegevens bevatten de uiteindelijke waarde, niet de bron ervan. Inspecteer de toepasselijke lokale objecten vanaf het meest specifieke niveau naar buiten. Voor tekst kan dit het gedeelte, de alinea, het tekstframe, de lay‑out, de master, het thema en de standaardinstellingen van de presentatie omvatten. Niet‑gedefinieerde waarden zoals `Float.NaN` of `null` geven aan dat de zoektocht doorgaat naar een hoger niveau.

**Wat gebeurt er als geen enkel niveau een eigenschap definieert?**

Aspose.Slides lost de toepasselijke PowerPoint‑ of bibliotheek‑standaard op. Die opgeloste waarde verschijnt in de effectieve gegevens, ook al definieert geen lokaal object deze expliciet.

**Waarom is een effectieve waarde soms gelijk aan de lokale waarde?**

De lokale waarde heeft de erf‑berekening gewonnen. Dit gebeurt wanneer de eigenschap expliciet op het object is ingesteld en geen specifiekere regel deze overschrijft.

**Wanneer moet ik lokale gegevens gebruiken in plaats van effectieve gegevens?**

Gebruik lokale gegevens om een specifiek opmaak‑niveau te inspecteren of te bewerken. Gebruik effectieve gegevens wanneer je het uiteindelijke uiterlijk nodig hebt na erf‑regels, themaregels en toepasselijke stijlen. Het [complete vergelijkingsvoorbeeld](#compare-local-inherited-and-effective-values) toont beide in dezelfde workflow.