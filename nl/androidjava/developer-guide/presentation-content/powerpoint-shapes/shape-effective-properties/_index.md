---
title: Vorm effectieve eigenschappen ophalen vanuit presentaties op Android
linktitle: Effectieve eigenschappen
type: docs
weight: 50
url: /nl/androidjava/shape-effective-properties/
keywords:
- vormeigenschappen
- camera-eigenschappen
- licht-rig
- afschuining vorm
- tekst-frame
- tekst-stijl
- letterhoogte
- opvulformaat
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Leer hoe u Aspose.Slides voor Android via Java kunt gebruiken om lokale, geërfde en effectieve vormopmaak in PowerPoint-presentaties te onderscheiden."
---
## **Begrijp lokale, geërfde en effectieve eigenschappen**

PowerPoint-opmaak kan uit meerdere bronnen komen. De waarde die rechtstreeks op een object wordt opgeslagen, is de **lokale waarde**. Als die waarde niet is ingesteld, kijkt PowerPoint naar bovenliggende opmaakbronnen, zoals een alinea‑standaard, een tekst‑stijl, een lay‑out‑ of master‑dia, een thema of standaardinstellingen op presentatieniveau. Die waarden zijn **geërfde waarden**. De waarde die overblijft nadat de volledige hiërarchie is doorlopen, is de **effectieve waarde** — de waarde die wordt gebruikt om het object weer te geven.

Bijvoorbeeld, een tekstdelen kan haar eigen lettergrootte niet definiëren. De lokale [getFontHeight](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibaseportionformat/#getFontHeight--) waarde is dan `Float.NaN`, wat betekent "hier niet ingesteld". Het deel kan een hoogte erven van de alinea, de standaardtekst‑stijl van de presentatie, of een andere toepasselijke bron. Het aanroepen van [getEffective](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iportionformat/#getEffective--) op het deel‑formaat geeft de uiteindelijk opgeloste hoogte terug.

Gebruik de twee soorten opmaakdata voor verschillende doeleinden:

- Lees of wijzig een lokaal opmaakobject, zoals [IPortionFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iportionformat/), wanneer u moet bepalen waar een waarde wordt gedefinieerd.
- Lees een effectief data‑object, zoals [IPortionFormatEffectiveData](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iportionformateffectivedata/), wanneer u het uiteindelijke, gerenderde resultaat nodig hebt. Effectieve data is alleen‑lezen.

## **Vergelijk lokale, geërfde en effectieve waarden**

Het volgende volledige voorbeeld maakt een vorm aan en past letterhoogtes toe op presentatie‑, alinea‑ en gedeelte‑niveau. Elke stap toont de waarden die op die niveaus zijn gedefinieerd en de resulterende effectieve waarde voor hetzelfde tekstdelen. Het laat ook zien waarom effectieve data opnieuw moet worden gelezen na opmaakwijzigingen.

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

            // Een geërfde waarde wijzigen overschrijft geen bestaande lokale waarde.
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30);
            printFontHeights("The local value still has priority", presentation, paragraph, portion);

            // Verwijder de lokale waarde. Het gedeelte erft nu opnieuw van de alinea.
            portion.getPortionFormat().setFontHeight(Float.NaN);
            printFontHeights("The local value is cleared", presentation, paragraph, portion);

            // Verwijder de alinea‑waarde. De standaardwaarde van de presentatie levert nu het resultaat.
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

        // Lees effectieve data na de vorige wijzigingen.
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

De prioriteit in dit voorbeeld is lokale opmaak van het gedeelte, vervolgens alinea‑opmaak, daarna de presentatie‑standaard. Andere objecten kunnen andere erfenis‑ketens hebben, maar het principe blijft hetzelfde: een meer specifieke expliciete waarde wint, en [getEffective](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iportionformat/#getEffective--) geeft het uiteindelijke resultaat terug.

## **Haalt effectieve tekst‑eigenschappen op**

Tekstopmaak is verdeeld over verschillende objecten:

- [ITextFrameFormat.getEffective()](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframeformat/#getEffective--) bepaalt tekst‑frame‑eigenschappen zoals marges, verankering, autofit en verticale tekstrichting.
- [ITextStyle.getEffective()](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextstyle/#getEffective--) bepaalt alinea‑opmaak voor elk tekst‑stijl‑niveau.
- [IParagraphFormat.getEffective()](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraphformat/#getEffective--) bepaalt alinea‑eigenschappen zoals uitlijning, inspringing en opsommingstekens.
- [IPortionFormat.getEffective()](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iportionformat/#getEffective--) bepaalt teken‑eigenschappen zoals letterhoogte, lettertype, kleur, vet en cursief.

Voor het volgende voorbeeld moet `text-formatting.pptx` minstens één dia en één [AutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/autoshape/) met een niet‑lege tekst‑frame bevatten. De AutoShape kan zich op elke positie in de vormverzameling bevinden; de code zoekt naar een geschikt object en valideert dit vóór gebruik.

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

## **Haalt effectieve 3D‑eigenschappen op**

[IThreeDFormat.getEffective()](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/#getEffective--) retourneert één [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformateffectivedata/) object dat alle opgeloste 3D‑instellingen groepeert. Zijn methoden [getCamera](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformateffectivedata/#getCamera--), [getLightRig](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformateffectivedata/#getLightRig--), [getBevelTop](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformateffectivedata/#getBevelTop--) en [getBevelBottom](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformateffectivedata/#getBevelBottom--) onthullen de overeenkomstige effectieve data. Het gezamenlijk lezen van deze gerelateerde instellingen maakt het makkelijker om de uiteindelijke 3D‑weergave van een vorm te begrijpen.

Voor dit voorbeeld moet `shape-3d.pptx` minstens één vorm op de eerste dia bevatten. Pas 3D‑camera‑, verlichtings‑ of afschuining‑instellingen toe op die vorm als u wilt dat de uitvoer andere waarden dan de standaard bevat.

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

## **Haalt effectieve tabel‑opmaak op**

Tabelopmaak kan afkomstig zijn van de tabel‑stijl en van opmaak die toegepast wordt op de hele tabel, een kolom, een rij of een individuele cel. Bij conflicten tussen expliciet gedefinieerde vullingen is de prioriteit cel, rij, kolom en daarna de hele tabel. Het effectieve formaat van een cel is het uiteindelijke formaat dat wordt gebruikt om die cel te tekenen.

Voor dit voorbeeld moet `table-formatting.pptx` minstens één tabel op de eerste dia bevatten. De tabel moet minstens één rij en één kolom hebben. De code zoekt naar een [ITable](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itable/) in plaats van te veronderstellen dat `getShapes().get_Item(0)` een tabel is.

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

Als u de kleur nodig heeft in plaats van alleen het vultype, controleer dan eerst de effectieve [getFillType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ifillformateffectivedata/#getFillType-- ) en lees daarna de methode die bij dat type hoort — bijvoorbeeld [getSolidFillColor](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ifillformateffectivedata/#getSolidFillColor--) voor een effen vulling.

## **Lees effectieve data opnieuw na wijzigingen**

Effectieve data beschrijft de opmaak‑hiërarchie op het moment dat deze wordt bepaald. Roep `getEffective` opnieuw aan nadat u iets hebt gewijzigd dat deel kan uitmaken van die hiërarchie, inclusief:

- de lokale opmaak van het object;
- alinea‑ of tekst‑frame‑standaarden;
- een tabel‑stijl, tabel, kolom, rij of cel‑opmaak;
- lay‑out‑ of master‑dia‑opmaak;
- themagegevens of standaardinstellingen op presentatieniveau;
- de lay‑out of master die aan een dia is toegewezen.

Bewaar geen effectief data‑object als een permanente momentopname. Aspose.Slides kan sommige effectieve data intern cachen, en een latere `getEffective`‑aanroep kan die data verversen. Als u waarden vóór en na een wijziging wilt vergelijken, kopieer dan de scalare waarden die u nodig heeft — zoals een letterhoogte, kleur, uitlijning of profielbreedte — naar eigen variabelen voordat u de wijziging doorvoert.

Om een waarde te wijzigen, werk het juiste lokale opmaakobject bij en roep daarna `getEffective` aan om het resultaat te verifiëren. Effectieve data‑objecten zelf zijn alleen‑lezen.

## **FAQ**

**Hoe kan ik zien op welk niveau een effectieve waarde is geleverd?**

Effectieve data bevat de uiteindelijke waarde, niet de bron. Inspecteer de toepasselijke lokale objecten van het meest specifieke niveau naar buiten. Voor tekst kan dit het gedeelte, de alinea, het tekst‑frame, de lay‑out, de master, het thema en de presentatiestandaarden omvatten. Onbepaalde waarden zoals `Float.NaN` of `null` geven aan dat de zoektocht doorgaat naar een ander niveau.

**Wat gebeurt er wanneer geen enkel niveau een eigenschap definieert?**

Aspose.Slides bepaalt de juiste PowerPoint‑ of bibliotheek‑standaard. Die opgeloste waarde verschijnt in de effectieve data, hoewel geen lokaal object deze expliciet definieert.

**Waarom komt een effectieve waarde soms overeen met de lokale waarde?**

De lokale waarde won de erfenis‑berekening. Dit is te verwachten wanneer de eigenschap expliciet op het object is ingesteld en geen specifiekere regel deze overschrijft.

**Wanneer moet ik lokale data gebruiken in plaats van effectieve data?**

Gebruik lokale data om een specifiek opmaakniveau te inspecteren of te bewerken. Gebruik effectieve data wanneer u de uiteindelijke weergave nodig heeft na erfenis, thema‑regels en toepasselijke stijlen. Het [complete vergelijkingsvoorbeeld](#compare-local-inherited-and-effective-values) toont beide in dezelfde workflow.