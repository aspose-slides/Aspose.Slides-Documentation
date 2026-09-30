---
title: Verwalten von Zeilen und Spalten in PowerPoint-Tabellen mit Java
linktitle: Zeilen und Spalten
type: docs
weight: 20
url: /de/java/manage-rows-and-columns/
keywords:
- Tabellenzeile
- Tabellenspalte
- erste Zeile
- Tabellenkopfzeile
- Zeile klonen
- Spalte klonen
- Zeile kopieren
- Spalte kopieren
- Zeile entfernen
- Spalte entfernen
- Zeilentextformatierung
- Spaltentextformatierung
- Tabellenstil
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Verwalten Sie Tabellenzeilen und -spalten in PowerPoint mit Aspose.Slides für Java und beschleunigen Sie die Bearbeitung von Präsentationen sowie Datenaktualisierungen."
---
## **Einführung**

Aspose.Slides for Java ermöglicht es Ihnen, Tabellenstruktur und -formatierung in PowerPoint‑Präsentationen über die Klasse [Table](https://reference.aspose.com/slides/java/com.aspose.slides/table/) und das Interface [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) zu verwalten. Sie können eine Kopfzeilenzeile festlegen, Zeilen und Spalten klonen oder entfernen und Textformatierung auf eine ganze Zeile oder Spalte anwenden.

Dieser Artikel erklärt diese Vorgänge anhand von Java‑Beispielen. Er zeigt außerdem, wie Sie das Stil‑Preset einer Tabelle abrufen können, um es wiederzuverwenden. Zeilen‑ und Spaltenindizes von Tabellen beginnen bei Null.

## **Zeilenhöhe steuern**

Verwenden Sie [IRow.setMinimalHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#setMinimalHeight-double-), um die minimale Höhe einer Zeile in Punkt festzulegen. Es ist eine Untergrenze, keine feste Höhe. [IRow.getHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#getHeight--) gibt die tatsächliche Höhe zurück. Greifen Sie über [ITable.getRows](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#getRows--) auf die Zeile zu.

Das Beispiel lädt [row-height-input.pptx](row-height-input.pptx), das eine Tabelle als erstes Shape auf der ersten Folie enthält. Die erste Zeile beginnt bei 70 Punkt. Die Zellen verwenden 18‑Punkt‑Arial‑Text, Zeilenumbruch und 6 Punkt‑Abstände oben und unten; der längere Text in der zweiten Spalte bricht in mehrere Zeilen um. Das Beispiel erhöht das Minimum auf 100 Punkt, reduziert es anschließend auf 20 Punkt, gibt nach jeder Änderung die tatsächliche Höhe aus und speichert beide Ergebnisse.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("row-height-input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);
    IRow row = table.getRows().get_Item(0);

    row.setMinimalHeight(100);
    System.out.printf("Increased: minimum = %.1f, actual = %.1f pt%n", row.getMinimalHeight(), row.getHeight());
    presentation.save("row-height-increased.pptx", SaveFormat.Pptx);

    row.setMinimalHeight(20);
    System.out.printf("Decreased: minimum = %.1f, actual = %.1f pt%n", row.getMinimalHeight(), row.getHeight());
    presentation.save("row-height-decreased.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Mit der bereitgestellten Präsentation fügt das Erhöhen des Minimums der Zeile zusätzlichen Raum hinzu. Das Verringern entfernt diesen zusätzlichen Raum, aber die tatsächliche Höhe bleibt größer als 20 Punkt, weil Text und Zellabstände mehr Platz benötigen. Das reine Reduzieren des Minimums kann die Zeile nicht unter den von ihrem Inhalt benötigten Platz zwingen.

Mehrere Faktoren beeinflussen die tatsächliche Höhe:

- **Text und Schriftgröße:** Längerer Text, explizite Zeilenumbrüche oder eine größere Schrift können mehr vertikalen Raum benötigen.
- **Zeilenumbruch und Spaltenbreite:** Bei aktiviertem Zeilenumbruch kann das Verringern der Spaltenbreite mit [IColumn.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icolumn/#setWidth-double-) mehr Zeilen erzeugen. Eine breitere Spalte kann den vertikalen Platzbedarf reduzieren.
- **Zellabstände:** [ICell.setMarginTop](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginTop-double-) und [ICell.setMarginBottom](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginBottom-double-) fügen vertikalen Abstand hinzu. [ICell.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginLeft-double-) und [ICell.setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginRight-double-) verkleinern die für Text verfügbare Breite und können zusätzlichen Zeilenumbruch verursachen.

Für diese Tabelle ohne zusammengeführte Zellen bestimmt die Zelle, die den meisten vertikalen Raum benötigt, die inhaltlich getriebene Untergrenze für die gesamte Zeile. Um die Zeile kürzer zu machen, müssen Sie ggf. den Text kürzen, die Schriftgröße oder die Abstände reduzieren oder eine Spalte verbreitern.

Die unten gezeigten Bilder stellen dieselbe Tabelle im gleichen Maßstab dar. In den illustrierten Ergebnissen betrugen die tatsächlichen Höhen 70, 100 und 55,2 Punkt: Die letzte Zeile blieb höher als ihr Minimum von 20 Punkt. Exakte Textmessungen können je nach in Ihrer Umgebung verfügbaren Schriften variieren. Laden Sie die gespeicherten Ergebnisse herunter: [increased minimum](row-height-increased.pptx) und [decreased minimum](row-height-decreased.pptx).

| Original: minimum 70 pt, actual 70 pt | Increased: minimum 100 pt, actual 100 pt | Decreased: minimum 20 pt, actual 55.2 pt |
| --- | --- | --- |
| ![Originaltabelle mit einer 70‑Punkt‑ersten Zeile.](row-height-before.png) | ![Tabelle nach Erhöhung des Minimums der ersten Zeile auf 100 Punkt.](row-height-increased.png) | ![Tabelle nach Reduzierung des Minimums der ersten Zeile auf 20 Punkt; umgebrochener Text hält die Zeile höher als das Minimum.](row-height-decreased.png) |

## **Erste Zeile als Kopfzeile festlegen**

Verwenden Sie die Methode [setFirstRow](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#setFirstRow-boolean-), um die erste Zeile für die Kopfzeilenformatierung zu markieren. Das Aussehen hängt vom auf die Tabelle angewendeten Tabellenstil ab.

1. Laden Sie die Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Greifen Sie auf die erste Folie zu.
3. Greifen Sie auf die Tabelle zu, die als erstes Shape auf der Folie gespeichert ist.
4. Aktivieren Sie die Kopfzeilenformatierung für ihre erste Zeile.
5. Speichern Sie die geänderte Präsentation.

Das Beispiel benötigt `table.pptx` mit einer Tabelle als erstes Shape auf der ersten Folie. Es aktiviert die Kopfzeilenformatierung für die erste Zeile und speichert `First_row_header.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);
    table.setFirstRow(true);

    presentation.save("First_row_header.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Eine Tabellenzeile oder -spalte klonen**

Klonen Sie Zeilen oder Spalten, um deren Inhalt und Formatierung wiederzuverwenden. Sie können eine Kopie an das Ende der Tabelle anhängen oder an einer bestimmten Position einfügen.

1. Laden Sie die Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Greifen Sie auf die erste Folie zu.
3. Definieren Sie die Spaltenbreiten und Zeilenhöhen.
4. Fügen Sie eine Tabelle mit der Methode [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) hinzu.
5. Klonen Sie die benötigten Zeilen.
6. Klonen Sie die benötigten Spalten.
7. Speichern Sie die geänderte Präsentation.

Das Beispiel benötigt `Test.pptx` mit mindestens einer Folie. Es erstellt eine Tabelle mit drei Spalten und fünf Zeilen, wobei die Abmessungen in Punkt angegeben sind. Es hängt Kopien der ersten Zeile und Spalte an und fügt Kopien der zweiten Zeile und Spalte an Index 3 (der vierten Position) ein. Die resultierende Tabelle hat sieben Zeilen und fünf Spalten. Das Argument `false` deaktiviert das Klonen in angrenzende zusammengeführte Zeilen oder Spalten; diese Tabelle enthält keine zusammengeführten Zellen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 50, 50, 50 };
    double[] rowHeights = new double[] { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    table.getRows().addClone(table.getRows().get_Item(0), false);

    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);

    presentation.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Eine Zeile oder Spalte aus einer Tabelle entfernen**

Entfernen Sie Zeilen oder Spalten, die in einer Tabelle nicht mehr benötigt werden. Das Entfernen eines Elements verschiebt die Indizes der nachfolgenden Zeilen oder Spalten.

1. Erstellen Sie eine Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Greifen Sie auf die erste Folie zu.
3. Definieren Sie die Spaltenbreiten und Zeilenhöhen.
4. Fügen Sie eine Tabelle mit der Methode [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) hinzu.
5. Entfernen Sie die zweite Zeile und die zweite Spalte.
6. Speichern Sie die geänderte Präsentation.

Dieses Beispiel erstellt eine 3 × 3‑Tabelle und entfernt die Zeile und Spalte an Index 1, sodass eine 2 × 2‑Tabelle in `TestTable_out.pptx` entsteht. Die Abmessungen sind in Punkt angegeben. Das Argument `false` deaktiviert das Entfernen angrenzender zusammengeführter Zeilen oder Spalten; diese Tabelle enthält keine zusammengeführten Zellen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 100, 50, 30 };
    double[] rowHeights = new double[] { 30, 50, 30 };
    ITable table = slide.getShapes().addTable(100, 100, columnWidths, rowHeights);

    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);

    presentation.save("TestTable_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Textformatierung auf Zeilenebene festlegen**

Wenden Sie Textformatierung auf eine gesamte Zeile an, um die Zellen konsistent zu halten. Sie können Schriftarteigenschaften, Absatzformatierung und Textausrichtung festlegen, ohne jede Zelle einzeln zu formatieren.

1. Laden Sie die Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Greifen Sie auf die Tabelle auf der ersten Folie zu.
3. Verwenden Sie [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) für die erste Zeile.
4. Verwenden Sie [setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) und [setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) für die erste Zeile.
5. Verwenden Sie [setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) für die zweite Zeile.
6. Speichern Sie die geänderte Präsentation.

Das Beispiel benötigt `table.pptx` mit einer Tabelle als erstes Shape auf der ersten Folie und mindestens zwei Zeilen. Es wendet 25‑Punkt‑Text, rechtsbündige Ausrichtung und einen rechten Absatzabstand von 20 Punkt auf die erste Zeile an und setzt dann vertikalen Text in der zweiten Zeile.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.getRows().get_Item(0).setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getRows().get_Item(0).setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.getRows().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("row_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Textformatierung auf Spaltenebene festlegen**

Wenden Sie Textformatierung auf eine gesamte Spalte an, um die Zellen konsistent zu halten. Sie können Schriftarteigenschaften, Absatzformatierung und Textausrichtung festlegen, ohne jede Zelle einzeln zu formatieren.

1. Laden Sie die Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Greifen Sie auf die Tabelle auf der ersten Folie zu.
3. Verwenden Sie [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) für die erste Spalte.
4. Verwenden Sie [setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) und [setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) für die erste Spalte.
5. Verwenden Sie [setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) für die zweite Spalte.
6. Speichern Sie die geänderte Präsentation.

Das Beispiel benötigt `table.pptx` mit einer Tabelle als erstes Shape auf der ersten Folie und mindestens zwei Spalten. Es wendet 25‑Punkt‑Text, rechtsbündige Ausrichtung und einen rechten Absatzabstand von 20 Punkt auf die erste Spalte an und setzt dann vertikalen Text in der zweiten Spalte.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.getColumns().get_Item(0).setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("column_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tabellenstil‑Eigenschaften abrufen**

Verwenden Sie die Methode [getStylePreset](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#getStylePreset--) , um das auf eine Tabelle angewendete Preset abzurufen und auf einer anderen Tabelle wiederzuverwenden. Dies identifiziert das Preset statt einzelner Zellenformat‑Überschreibungen.

Das Beispiel erstellt eine Tabelle, wendet [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/java/com.aspose.slides/tablestylepreset/#DarkStyle1) an und liest das Preset wieder aus. Es gibt den ganzzahligen Wert zu `DarkStyle1` aus und speichert die Tabelle in `table.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 100, 150 };
    double[] rowHeights = new double[] { 5, 5, 5 };
    ITable table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(TableStylePreset.DarkStyle1);

    int stylePreset = table.getStylePreset();
    System.out.println(stylePreset);

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Kann ich PowerPoint‑Designs/‑Stile auf eine bereits erstellte Tabelle anwenden?**

Ja. Die Tabelle erbt das Design der Folie/ des Layouts/ des Masters und Sie können dennoch Füllungen, Rahmen und Textfarben darüber hinaus überschreiben.

**Kann ich Tabellenzeilen wie in Excel sortieren?**

Nein, Aspose.Slides‑Tabellen besitzen keine integrierte Sortier‑ oder Filterfunktion. Sortieren Sie Ihre Daten zunächst im Speicher und füllen Sie dann die Tabellenzeilen in dieser Reihenfolge erneut.

**Kann ich banded (gestreifte) Spalten haben und gleichzeitig individuelle Farben für bestimmte Zellen beibehalten?**

Ja. Aktivieren Sie banded Spalten und überschreiben Sie dann bestimmte Zellen mit lokaler Formatierung; die Formatierung auf Zellebene hat Vorrang vor dem Tabellenstil.