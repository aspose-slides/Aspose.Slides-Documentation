---
title: Formeffektive Eigenschaften aus Präsentationen auf Android abrufen
linktitle: Effektive Eigenschaften
type: docs
weight: 50
url: /de/androidjava/shape-effective-properties/
keywords:
- Formeigenschaften
- Kameraeigenschaften
- Licht-Rig
- Abschrägungsform
- Textrahmen
- Textstil
- Schriftgröße
- Füllformat
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Aspose.Slides für Android via Java verwenden, um lokale, geerbte und effektive Formformatierungen in PowerPoint‑Präsentationen zu unterscheiden."
---
## **Verstehen lokaler, geerbter und effektiver Eigenschaften**

PowerPoint-Formatierungen können von mehreren Stellen stammen. Der direkt auf einem Objekt gespeicherte Wert ist sein **lokaler Wert**. Ist dieser Wert nicht festgelegt, prüft PowerPoint die übergeordneten Formatierungsquellen, z. B. die Absatz‑Standardwerte, einen Textstil, ein Layout‑ oder Master‑Folie, ein Design oder Präsentations‑Standardwerte. Diese Werte sind **geerbte Werte**. Der Wert, der nach Auflösung der gesamten Hierarchie verbleibt, ist der **effektive Wert** — der zum Rendern des Objekts verwendete Wert.

Beispielsweise definiert ein Textabschnitt möglicherweise nicht seine eigene Schriftgröße. Sein lokaler [getFontHeight](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibaseportionformat/#getFontHeight--) Wert ist dann `Float.NaN`, was „hier nicht gesetzt“ bedeutet. Der Abschnitt kann eine Höhe von seinem Absatz, dem Standard‑Textstil der Präsentation oder einer anderen zutreffenden Quelle erben. Ein Aufruf von [getEffective](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iportionformat/#getEffective--) auf das Abschnittsformat liefert die endgültig aufgelöste Höhe.

Verwenden Sie die beiden Arten von Formatierungsdaten für unterschiedliche Zwecke:

- Lesen oder ändern Sie ein lokales Formatobjekt, z. B. [IPortionFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iportionformat/), wenn Sie steuern müssen, wo ein Wert definiert ist.
- Lese ein effektives Datenobjekt, z. B. [IPortionFormatEffectiveData](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iportionformateffectivedata/), wenn Sie das endgültige, gerenderte Ergebnis benötigen. Effektive Daten sind schreibgeschützt.

## **Vergleich lokaler, geerbter und effektiver Werte**

Das folgende vollständige Beispiel erstellt eine Form und wendet Schriftgrößen auf Präsentations‑, Absatz‑ und Abschnittsebene an. Jeder Schritt gibt die auf diesen Ebenen definierten Werte sowie den resultierenden effektiven Wert für denselben Textabschnitt aus. Es zeigt auch, warum effektive Daten nach Formatierungsänderungen erneut gelesen werden müssen.

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

            // Definieren geerbter Werte auf zwei unterschiedlichen Ebenen.
            presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20);
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);

            printFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

            // Ein lokaler Wert im Abschnitt überschreibt beide geerbten Werte.
            portion.getPortionFormat().setFontHeight(36);
            printFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

            // Das Ändern eines geerbten Werts überschreibt keinen vorhandenen lokalen Wert.
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30);
            printFontHeights("The local value still has priority", presentation, paragraph, portion);

            // Lösche den lokalen Wert. Der Abschnitt erbt jetzt wieder vom Absatz.
            portion.getPortionFormat().setFontHeight(Float.NaN);
            printFontHeights("The local value is cleared", presentation, paragraph, portion);

            // Lösche den Absatzwert. Der Präsentationsstandard liefert jetzt das Ergebnis.
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

        // Lese effektive Daten nach den vorherigen Änderungen.
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

Die Priorität in diesem Beispiel ist die lokale Formatierung des Abschnitts, dann die Absatzformatierung und schließlich die Präsentations‑Standardeinstellung. Andere Objekte können unterschiedliche Vererbungsketten haben, aber das Prinzip ist dasselbe: ein spezifischer, expliziter Wert gewinnt, und [getEffective](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iportionformat/#getEffective--) liefert das Endergebnis.

## **Effektive Texteigenschaften abrufen**

Textformatierung ist auf mehrere Objekte verteilt:

- [ITextFrameFormat.getEffective()](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframeformat/#getEffective--) löst Text‑Frame‑Eigenschaften wie Ränder, Verankerung, AutoFit und vertikale Textausrichtung auf.
- [ITextStyle.getEffective()](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextstyle/#getEffective--) löst Absatzformatierungen für jede Textebenen‑Stufe auf.
- [IParagraphFormat.getEffective()](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iparagraphformat/#getEffective--) löst Absatz‑Eigenschaften wie Ausrichtung, Einzüge und Aufzählungszeichen auf.
- [IPortionFormat.getEffective()](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iportionformat/#getEffective--) löst Zeichen‑Eigenschaften wie Schriftgröße, Schriftart, Farbe, Fett und Kursiv auf.

Für das nächste Beispiel muss `text-formatting.pptx` mindestens eine Folie und eine [AutoShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/autoshape/) mit einem nicht leeren Textfeld enthalten. Die AutoShape kann an beliebiger Position in der Formensammlung stehen; der Code sucht nach einem geeigneten Objekt und prüft es, bevor es verwendet wird.

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

## **Effektive 3D‑Eigenschaften abrufen**

[IThreeDFormat.getEffective()](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/#getEffective--) gibt ein [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformateffectivedata/) Objekt zurück, das alle aufgelösten 3D‑Einstellungen gruppiert. Seine Methoden [getCamera](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformateffectivedata/#getCamera--), [getLightRig](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformateffectivedata/#getLightRig--), [getBevelTop](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformateffectivedata/#getBevelTop--) und [getBevelBottom](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformateffectivedata/#getBevelBottom--) stellen die entsprechenden effektiven Daten bereit. Das gleichzeitige Auslesen dieser verwandten Einstellungen erleichtert das Verständnis des endgültigen 3D‑Erscheinungsbildes einer Form.

Für dieses Beispiel muss `shape-3d.pptx` mindestens eine Form auf der ersten Folie enthalten. Wenden Sie 3D‑Kamera-, Beleuchtungs‑ oder Abschrägungs‑Einstellungen auf diese Form an, wenn die Ausgabe Werte enthalten soll, die von den Standardwerten abweichen.

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

## **Effektive Tabellenformatierung abrufen**

Tabellenformatierungen können aus dem Tabellenstil sowie aus Formaten stammen, die auf die gesamte Tabelle, eine Spalte, eine Zeile oder eine einzelne Zelle angewendet werden. Bei Konflikten zwischen explizit definierten Füllungen hat die Priorität Zelle, Zeile, Spalte und dann die gesamte Tabelle. Das effektive Format einer Zelle ist das endgültige Format, das zum Zeichnen dieser Zelle verwendet wird.

Für dieses Beispiel muss `table-formatting.pptx` mindestens eine Tabelle auf der ersten Folie enthalten. Die Tabelle muss mindestens eine Zeile und eine Spalte besitzen. Der Code sucht nach einem [ITable](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itable/), anstatt anzunehmen, dass `getShapes().get_Item(0)` eine Tabelle ist.

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

Wenn Sie die Farbe und nicht nur den Fülltyp benötigen, prüfen Sie zunächst den effektiven [getFillType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ifillformateffectivedata/#getFillType--), und lesen Sie dann die Methode, die zu diesem Typ passt — z. B. [getSolidFillColor](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ifillformateffectivedata/#getSolidFillColor--) für eine einfarbige Füllung.

## **Effektive Daten nach Änderungen erneut lesen**

Effektive Daten beschreiben die Formatierungshierarchie zum Zeitpunkt ihrer Auflösung. Rufen Sie `getEffective` erneut auf, nachdem Sie etwas geändert haben, das an dieser Hierarchie teilnehmen kann, einschließlich:

- der lokalen Formatierung des Objekts;
- Absatz‑ oder Text‑Frame‑Standardwerte;
- eines Tabellenstils, einer Tabelle, Spalte, Zeile oder Zellenformat;
- Layout‑ oder Master‑Folienformatierung;
- Design‑Daten oder Präsentations‑Standardwerte;
- das dem Folie zugewiesene Layout oder den Master.

Bewahren Sie ein effektives Datenobjekt nicht als permanente Momentaufnahme auf. Aspose.Slides kann einige effektive Daten intern zwischenspeichern, und ein späterer Aufruf von `getEffective` kann diese Daten aktualisieren. Wenn Sie Werte vor und nach einer Änderung vergleichen müssen, kopieren Sie die benötigten Skalare — wie Schriftgröße, Farbe, Ausrichtung oder Abschrägungsbreite — in eigene Variablen, bevor Sie die Änderung vornehmen.

Um einen Wert zu ändern, aktualisieren Sie das entsprechende lokale Formatobjekt und rufen anschließend `getEffective` auf, um das Ergebnis zu prüfen. Effektive Datenobjekte selbst sind schreibgeschützt.

## **FAQ**

**Wie kann ich erkennen, welche Ebene einen effektiven Wert geliefert hat?**

Effektive Daten enthalten den endgültigen Wert, jedoch nicht dessen Herkunft. Untersuchen Sie die entsprechenden lokalen Objekte von der spezifischsten Ebene nach außen. Für Text kann dies den Abschnitt, Absatz, Text‑Frame, Layout, Master, das Design und die Präsentations‑Standardwerte umfassen. Nicht definierte Werte wie `Float.NaN` oder `null` zeigen an, dass die Suche auf eine weitere Ebene fortgesetzt wird.

**Was passiert, wenn keine Ebene eine Eigenschaft definiert?**

Aspose.Slides ermittelt den entsprechenden PowerPoint‑ oder Bibliotheksstandard. Dieser aufgelöste Wert erscheint in den effektiven Daten, obwohl kein lokales Objekt ihn explizit definiert.

**Warum entspricht ein effektiver Wert manchmal dem lokalen Wert?**

Der lokale Wert hat die Vererberechnung gewonnen. Das ist zu erwarten, wenn die Eigenschaft explizit am Objekt gesetzt ist und keine spezifischere Regel sie überschreibt.

**Wann sollte ich lokale Daten anstelle von effektiven Daten verwenden?**

Verwenden Sie lokale Daten, um ein bestimmtes Formatierungsebene zu inspizieren oder zu bearbeiten. Verwenden Sie effektive Daten, wenn Sie das endgültige Erscheinungsbild nach Vererbung, Design‑Regeln und angewandten Stilen benötigen. Das [vollständige Vergleichsbeispiel](#compare-local-inherited-and-effective-values) demonstriert beides im selben Arbeitsablauf.