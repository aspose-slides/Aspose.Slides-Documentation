---
title: "Hämta effektiva formegenskaper från presentationer i Java"
linktitle: "Effektiva egenskaper"
type: docs
weight: 50
url: /sv/java/shape-effective-properties/
keywords:
- formegenskaper
- kameraegenskaper
- ljusrigg
- avfasningsform
- textram
- textstil
- teckenhöjd
- fyllningsformat
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Lär dig hur du använder Aspose.Slides för Java för att särskilja lokal, ärvd och effektiv formeformattering i PowerPoint‑presentationer."
---
## **Förstå lokala, ärvda och effektiva egenskaper**

PowerPoint‑formatering kan komma från flera ställen. Värdet som lagras direkt på ett objekt är dess **lokala värde**. Om det värdet inte är angivet tittar PowerPoint på föräldra‑formateringskällor, såsom standardvärde för ett stycke, en textstil, en layout‑ eller mästarmal, ett tema eller standardvärden på presentationsnivå. Dessa värden är **ärvda värden**. Värdet som återstår efter att hela hierarkin har lösts är **effektiva värdet** — värdet som används för att rendera objektet.

Till exempel kanske en textdel inte definierar sin egen teckenhöjd. Dess lokala [getFontHeight](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ibaseportionformat/#getFontHeight--) värde blir då `Float.NaN`, vilket betyder "inte angivet här". Delen kan ärva en höjd från sitt stycke, presentationens standard‑textstil eller en annan tillämplig källa. Att anropa [getEffective](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iportionformat/#getEffective--) på delens format returnerar den slutgiltigt lösta höjden.

Använd de två typerna av formateringsdata för olika ändamål:

- Läs eller ändra ett lokalt formatobjekt, till exempel [IPortionFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iportionformat/), när du behöver kontrollera var ett värde definieras.
- Läs ett effektivt datobjekt, till exempel [IPortionFormatEffectiveData](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iportionformateffectivedata/), när du behöver det slutgiltiga, renderade resultatet. Effektiva data är skrivskyddade.

## **Jämför lokala, ärvda och effektiva värden**

Det följande kompletta exemplet skapar en form och tillämpar teckenhöjder på presentations‑, stycke‑ och delnivå. Varje steg skriver ut de värden som definierats på dessa nivåer och det resulterande effektiva värdet för samma textdel. Det visar också varför effektiva data måste läsas igen efter formateringsändringar.

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

            // Definiera ärvda värden på två olika nivåer.
            presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20);
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);

            printFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

            // Ett lokalt värde på delen åsidosätter båda ärvda värden.
            portion.getPortionFormat().setFontHeight(36);
            printFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

            // Att ändra ett ärvt värde åsidosätter inte ett befintligt lokalt värde.
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30);
            printFontHeights("The local value still has priority", presentation, paragraph, portion);

            // Rensa det lokala värdet. Delen ärver nu från stycket igen.
            portion.getPortionFormat().setFontHeight(Float.NaN);
            printFontHeights("The local value is cleared", presentation, paragraph, portion);

            // Rensa styckets värde. Presentationens standardvärde levererar nu resultatet.
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

        // Läs effektiva data efter föregående ändringar.
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

Prioriteten i detta exempel är delens lokala formatering, därefter styckeformatering och sedan presentationsstandard. Andra objekt kan ha olika arvskedjor, men principen är densamma: ett mer specifikt explicit värde vinner, och [getEffective](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iportionformat/#getEffective--) returnerar det slutgiltiga resultatet.

## **Hämta effektiva textegenskaper**

Textformatering är uppdelad på flera objekt:

- [ITextFrameFormat.getEffective()](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframeformat/#getEffective--) löser text‑ramegenskaper såsom marginaler, förankring, autofit och vertikal textriktning.
- [ITextStyle.getEffective()](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextstyle/#getEffective--) löser styckeformatering för varje textstilsnivå.
- [IParagraphFormat.getEffective()](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iparagraphformat/#getEffective--) löser styckegenskaper såsom justering, indrag och punktlistor.
- [IPortionFormat.getEffective()](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iportionformat/#getEffective--) löser teckenegenskaper såsom teckenhöjd, teckensnitt, färg, fetstil och kursiv.

För nästa exempel måste `text-formatting.pptx` innehålla minst en bild och en [AutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/autoshape/) med en icke‑tom textram. AutoShape kan finnas på vilken position som helst i formsamlingen; koden söker efter ett lämpligt objekt och validerar det innan det används.

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

## **Hämta effektiva 3D‑egenskaper**

[IThreeDFormat.getEffective()](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ithreedformat/#getEffective--) returnerar ett [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ithreedformateffectivedata/)‑objekt som samlar alla lösta 3D‑inställningar. Dess [getCamera](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ithreedformateffectivedata/#getCamera--), [getLightRig](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ithreedformateffectivedata/#getLightRig--), [getBevelTop](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ithreedformateffectivedata/#getBevelTop--) och [getBevelBottom](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ithreedformateffectivedata/#getBevelBottom--)‑metoder avslöjar motsvarande effektiva data. Att läsa dessa relaterade inställningar tillsammans gör det enklare att förstå den slutgiltiga 3D‑utseendet på en form.

För detta exempel måste `shape-3d.pptx` innehålla minst en form på sin första bild. Tillämpa 3D‑kamera, belysning eller fasthöjdsinställningar på den formen om du vill att resultatet ska innehålla andra värden än standardvärdena.

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

## **Hämta effektiv tabellformatering**

Tabellformatering kan komma från tabellstilen och från format som tillämpas på hela tabellen, en kolumn, en rad eller en enskild cell. Vid konflikter mellan explicit definierade fyllningar är prioriteten cell, rad, kolumn och sedan hela tabellen. Den effektiva formatet för en cell är det slutgiltiga format som används för att rita den cellen.

För detta exempel måste `table-formatting.pptx` innehålla minst en tabell på sin första bild. Tabellen måste ha minst en rad och en kolumn. Koden söker efter en [ITable](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itable/) istället för att anta att `getShapes().get_Item(0)` är en tabell.

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

Om du behöver färgen snarare än bara fyllningstypen, kontrollera först den effektiva [getFillType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ifillformateffectivedata/#getFillType--), och läs sedan metoden som gäller för den typen — till exempel [getSolidFillColor](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ifillformateffectivedata/#getSolidFillColor--) för en solid fyllning.

## **Läs om effektiva data efter ändringar**

Effektiva data beskriver formateringshierarkin vid den tidpunkt då den löses. Anropa `getEffective` igen efter att ha ändrat något som kan delta i den hierarkin, inklusive:

- objektets lokala formatering;
- stycke‑ eller textram‑standardvärden;
- en tabellstil, tabell, kolumn, rad eller cellformat;
- layout‑ eller mästarmal‑formatering;
- temadata eller standardvärden på presentationsnivå;
- layout‑ eller mästare som tilldelats en bild.

Behåll inte ett effektivt dataobjekt som en permanent ögonblicksbild. Aspose.Slides kan cachera vissa effektiva data internt, och ett senare `getEffective`‑anrop kan uppdatera dessa data. Om du behöver jämföra värden före och efter en ändring, kopiera de skalära värden du behöver — som teckenhöjd, färg, justering eller fasthöjd — till egna variabler innan du gör ändringen.

För att ändra ett värde, uppdatera det lämpliga lokala formatobjektet och anropa sedan `getEffective` för att verifiera resultatet. Effektiva dataobjekt är i sig skrivskyddade.

## **FAQ**

**Hur kan jag avgöra vilken nivå som levererade ett effektivt värde?**

Effektiva data innehåller det slutgiltiga värdet, inte dess källa. Inspektera de tillämpliga lokala objekten från den mest specifika nivån och utåt. För text kan detta inkludera delen, stycket, textramen, layouten, mästaren, temat och presentationsstandarder. Odefinierade värden såsom `Float.NaN` eller `null` indikerar att sökningen fortsätter på en annan nivå.

**Vad händer när ingen nivå definierar en egenskap?**

Aspose.Slides löser det lämpliga PowerPoint‑ eller biblioteksstandardvärdet. Det lösta värdet visas i de effektiva data även om inget lokalt objekt explicit definierar det.

**Varför är ett effektivt värde ibland lika med det lokala värdet?**

Det lokala värdet vann arvberäkningen. Detta är förväntat när egenskapen är explicit satt på objektet och ingen mer specifik regel åsidosätter den.

**När bör jag använda lokala data istället för effektiva data?**

Använd lokala data för att inspektera eller redigera en specifik formateringsnivå. Använd effektiva data när du behöver den slutgiltiga utseendet efter arv, temaregler och tillämpliga stilar har lösts. Detta [kompletta jämförelseexempel](#compare-local-inherited-and-effective-values) demonstrerar båda i samma arbetsflöde.