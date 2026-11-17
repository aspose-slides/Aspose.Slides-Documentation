---
title: Tabellenzellen in Präsentationen unter Android verwalten
linktitle: Zellen verwalten
type: docs
weight: 30
url: /de/androidjava/manage-cells/
keywords:
- Tabellenzelle
- Zellen zusammenführen
- Rand entfernen
- Zelle aufteilen
- Bild in Zelle
- Hintergrundfarbe
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Verwalten Sie PowerPoint-Tabellenzellen unter Android: Erkennen Sie zusammengeführte Zellen, entfernen Sie Ränder, teilen Sie Zellen und setzen Sie Hintergrundfarben und Bilder mit Aspose.Slides für Android via Java."
---
## **Übersicht**

Aspose.Slides ermöglicht den Zugriff auf Tabellenzellen in PowerPoint‑Präsentationen und deren Bearbeitung. Dieser Artikel erklärt, wie zusammengeführte Tabellenzellen erkannt, Zellränder entfernt, die Zell‑Nummerierung nach dem Zusammenführen oder Aufteilen von Zellen verwaltet, die Hintergrundfarbe einer Zelle geändert und ein Bild in einer Tabellenzelle eingefügt wird. Die Beispiele zeigen, wie eine Präsentation erstellt oder geöffnet, eine Tabelle von einer Folie abgerufen, die Zellformatierung über Zell‑Eigenschaften aktualisiert und die geänderte Präsentation als PPTX‑Datei gespeichert wird.

Aspose.Slides verwendet nullbasierte Indizes, um Tabellenzellen in der Reihenfolge `(Spalte, Zeile)` zu adressieren.

## **Zusammengeführte Tabellenzelle erkennen**

Das Beispiel öffnet eine vorhandene Präsentation und greift auf die erste Form auf der ersten Folie als Tabelle zu. Es wird davon ausgegangen, dass Folie und Form existieren und die Form eine Tabelle ist. Anschließend wird über alle Zeilen und Spalten iteriert und [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) verwendet, um Zellen in zusammengeführten Bereichen zu erkennen. Für jede Übereinstimmung werden die Zellenkoordinaten in `Zeile;Spalte`‑Reihenfolge, [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--), [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--), sowie die Startkoordinaten des Bereichs, [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) und [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) ausgegeben.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation_with_table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    int rowCount = table.getRows().size();
    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
    {
        int columnCount = table.getColumns().size();
        for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
        {
            ICell cell = table.get_Item(columnIndex, rowIndex);
            if (cell.isMergedCell())
            {
                System.out.printf("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.%n", rowIndex, columnIndex, cell.getRowSpan(), cell.getColSpan(), cell.getFirstRowIndex(), cell.getFirstColumnIndex());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Tabellenzell‑Ränder entfernen**

Erstellen Sie ein [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) und fügen Sie seiner ersten Folie mit [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) eine Tabelle hinzu. Spaltenbreiten, Zeilenhöhen und die Tabellenposition werden in Punkten angegeben. Das Beispiel setzt alle vier Zellränder auf [FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/), wodurch sie unsichtbar werden.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 50, 50, 50, 50 };
    double[] rowHeights = { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill);
        }

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Diagonale Zellränder hinzufügen**

Verwenden Sie [getBorderDiagonalDown](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icellformat/#getBorderDiagonalDown--) um eine Linie von der oberen linken Ecke zur unteren rechten Ecke zu zeichnen, und [getBorderDiagonalUp](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icellformat/#getBorderDiagonalUp--) um eine Linie von der unteren linken Ecke zur oberen rechten Ecke zu zeichnen. Eine Diagonale kann als Kopfzeilen‑Kennzeichnung dienen; beide Diagonalen können ein X bilden, um eine Zelle als nicht anwendbar zu kennzeichnen.

Jede Diagonale ist ein [ILineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/). In dessen [getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getFillFormat--) verwenden Sie [setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) um [FillType.Solid](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) auszuwählen und wählen eine Farbe über [getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--). Setzen Sie die Linienbreite in Punkten mit [setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setWidth-double-).

Das Beispiel erstellt drei Zellen in einer Zeile: eine rote nach unten gerichtete Diagonale, eine blaue nach oben gerichtete Diagonale und beide Diagonalen. Die oberen, unteren, linken und rechten Zellränder bleiben unverändert.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 210, 210, 210 };
    double[] rowHeights = { 160 };
    ITable table = slide.getShapes().addTable(45, 130, columnWidths, rowHeights);

    ILineFormat downwardBorder = table.get_Item(0, 0).getCellFormat().getBorderDiagonalDown();
    downwardBorder.getFillFormat().setFillType(FillType.Solid);
    downwardBorder.getFillFormat().getSolidFillColor().setColor(Color.RED);
    downwardBorder.setWidth(3);

    ILineFormat upwardBorder = table.get_Item(1, 0).getCellFormat().getBorderDiagonalUp();
    upwardBorder.getFillFormat().setFillType(FillType.Solid);
    upwardBorder.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    upwardBorder.setWidth(5);

    ILineFormat crossDownwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalDown();
    crossDownwardBorder.getFillFormat().setFillType(FillType.Solid);
    crossDownwardBorder.getFillFormat().getSolidFillColor().setColor(Color.RED);
    crossDownwardBorder.setWidth(3);

    ILineFormat crossUpwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalUp();
    crossUpwardBorder.getFillFormat().setFillType(FillType.Solid);
    crossUpwardBorder.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    crossUpwardBorder.setWidth(5);

    presentation.save("diagonal_cell_borders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Eine Diagonale ist eine Formatierungseigenschaft, keine Zellaufteilung. Jede Zelle behält einen einzelnen TextFrame, zu dem Sie über [getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getTextFrame--) zugreifen; die Bereiche auf beiden Seiten einer Diagonale können nicht unabhängig voneinander bearbeitet werden.

Die gespeicherte Tabelle, gerendert in Microsoft PowerPoint:

![Three table cells showing a red diagonal from top-left to bottom-right, a blue diagonal from bottom-left to top-right, and both diagonals forming an X.](diagonal-cell-borders.png)

*Links nach rechts: nach unten gerichtete Diagonale (rot, 3 pt), nach oben gerichtete Diagonale (blau, 5 pt) und beide Diagonalen.*

## **Tabellenzellen zusammenführen**

Verwenden Sie [mergeCells](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-), um einen rechteckigen Bereich von Tabellenzellen zu einer einzigen Zelle zu kombinieren. Geben Sie die Zellen an den oberen linken und unteren rechten Ecken des Bereichs an. Das letzte Argument steuert, ob das Zusammenführen Zellen außerhalb des angegebenen Bereichs einschließen darf; `false` hält das Zusammenführen innerhalb dieses Bereichs.

Das Beispiel erstellt eine 4 × 4‑Tabelle mit 70‑Punkt‑Spalten und -Zeilen und führt die vier mittleren Zellen von `(1, 1)` bis `(2, 2)` zusammen. Die resultierende Zelle erstreckt sich über zwei Spalten und zwei Zeilen, während das zugrunde liegende Gitter der Tabelle vier Spalten und vier Zeilen beibehält. Um auf den Inhalt oder die Formatierung der zusammengeführten Zelle zuzugreifen, verwenden Sie deren obere linke Position: `table.get_Item(1, 1)` in diesem Beispiel. Die anderen Positionen im zusammengeführten Bereich bleiben Teil des Tabellengitters, sodass die Indizes von Zellen außerhalb des Bereichs unverändert bleiben.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), false);

    presentation.save("merged_cells.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tabellenzellen aufteilen**

Das Zusammenführen von Zellen im vorherigen Beispiel erhält das Tabellengitter. Das Aufteilen einer Zelle kann eine neue Gitterspalte einführen und die Spaltenindizes der rechts davon liegenden Zellen ändern. Aspose.Slides folgt dem PowerPoint‑Tabellengittermodell.

Dieses Beispiel erstellt eine 4 × 4‑Tabelle mit 70‑Punkt‑Spalten und -Zeilen und ruft [splitByWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByWidth-double-) für die Zelle `(1, 1)` auf. Die Hälfte der 70‑Punkt‑Breite der Zelle wird übergeben, um zwei Zellen gleicher Breite zu erzeugen.

Nach diesem Aufteilen werden die beiden Hälften über `table.get_Item(1, 1)` und `table.get_Item(2, 1)` angesprochen. Das Tabellengitter hat nun fünf Spalten: Zellen, die ursprünglich in Spalte 2 bzw. 3 waren, verschieben sich zu Spalte 3 bzw. 4. Zeilenindizes bleiben unverändert. Verwenden Sie diese aktualisierten Spaltenindizes, wenn Sie nach dem Aufteilen auf Zellen zugreifen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2);

    presentation.save("split_cells.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

<!-- visual-explanation:manage-cells:start -->
[![An unmerged 70-point cell splits into two 35-point cells, adding a fifth grid column and shifting the indices to its right.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*Die Breitenaufteilung betrifft Zelle (1, 1) unter Verwendung nullbasierter (Spalte, Zeile)‑Indizes. Andere Zeilen behalten eine Zelle, die beide neuen Spaltenpositionen überspannt.*
<!-- visual-explanation:manage-cells:end -->

### **Zusammengeführte Zellen nach Zeilen‑ oder Spalten‑Spannweite aufteilen**

Um zusammengeführte Vorlagenzellen für die Datenbefüllung vorzubereiten, verwenden Sie [splitByRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByRowSpan-int-), um entlang einer bestehenden Zeilen­grenze zu teilen, oder [splitByColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByColSpan-int-), um entlang einer Spalten­grenze zu teilen.

Das Argument `index` zählt Zeilen im oberen Teil bzw. Spalten im linken Teil der Aufteilung; es ist relativ zum zusammengeführten Bereich:

- Zeilenaufteilung: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--).
- Spaltenaufteilung: `0 < index <` [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--).

Das Beispiel geht davon aus, dass eine Präsentation eine Tabelle als erste Form auf der ersten Folie enthält, wobei `(1, 2)` und `(1, 3)` vertikal zusammengeführt sind. Ausgehend von der unteren Position verwendet es [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) und [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) um den Ursprung zu ermitteln und prüft beide Spannweiten. `splitByRowSpan(1)` trennt dann die Zeilen 2 und 3 für Produktnamen. Für eine horizontale Zusammenführung von zwei Spalten verwenden Sie stattdessen `splitByColSpan(1)`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table_template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    ICell selectedCell = table.get_Item(1, 3);
    int firstColumnIndex = selectedCell.getFirstColumnIndex();
    int firstRowIndex = selectedCell.getFirstRowIndex();
    ICell mergedCell = table.get_Item(firstColumnIndex, firstRowIndex);

    if (mergedCell.isMergedCell() && mergedCell.getRowSpan() == 2 && mergedCell.getColSpan() == 1)
    {
        mergedCell.splitByRowSpan(1);

        // Rufen Sie die resultierenden Zellen aus der Tabelle nach dem Aufteilen ab.
        ICell upperCell = table.get_Item(firstColumnIndex, firstRowIndex);
        ICell lowerCell = table.get_Item(firstColumnIndex, firstRowIndex + 1);
        System.out.println("Upper cell merged: " + upperCell.isMergedCell());
        System.out.println("Lower cell merged: " + lowerCell.isMergedCell());

        upperCell.getTextFrame().setText("Product A");
        lowerCell.getTextFrame().setText("Product B");

        presentation.save("split_template.pptx", SaveFormat.Pptx);
    }
    else
    {
        System.out.println("Select a merged region spanning exactly two rows and one column.");
    }
} finally {
    presentation.dispose();
}
```

Das Tabellengitter und die umliegenden Zellindizes bleiben unverändert. Rufen Sie die resultierenden Zellen über ihre Koordinaten ab; beide haben Spannweiten von 1 und [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) gibt `false` aus. Größere Bereiche können nach einer Aufteilung teilweise zusammengeführt bleiben.

Der ursprüngliche Text und seine Formatierung verbleiben in der oberen (bzw. linken) Zelle; die neue Zelle ist leer, erbt jedoch Zellformatierungen wie Füllung, Ränder und Randabstände. Befüllen Sie die Zellen nach dem Aufteilen und setzen Sie etwaige Textformatierungen ausdrücklich.

Die gespeicherte Präsentation enthält separate „Product A“‑ und „Product B“‑Zellen, wobei die Zellformatierung der Vorlage erhalten bleibt. Siehe die [Cell API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/) für Details.

### **Eine Zelle bei einer bestimmten Höhe aufteilen**

[splitByHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByHeight-double-) nimmt die Höhe des oberen Teils in Punkten. [splitByRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByRowSpan-int-) nimmt die Anzahl der bestehenden Gitterzeilen im oberen Teil. Um eine 40‑Punkt‑Zelle in der rechten Spalte zu zentrieren, subtrahieren Sie 40 von der tatsächlichen Höhe der Zelle und teilen den verbleibenden Raum gleichmäßig über und unter ihr.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 160, 160 };
    double[] rowHeights = { 140 };

    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);
    table.get_Item(0, 0).getTextFrame().setText("Left");

    double height = table.get_Item(1, 0).getHeight();
    double margin = (height - 40) / 2;

    table.get_Item(1, 0).splitByHeight(margin);
    table.get_Item(1, 1).splitByHeight(40);
    table.get_Item(1, 1).getTextFrame().setText("Middle");

    presentation.save("split_by_height.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Der erste Aufteilungsschritt fügt eine Gitterzeile hinzu und lässt die unteren 90 Punkte in Zelle `(1, 1)` stehen. Der zweite Aufteilungsschritt teilt diese Zelle in eine 40‑Punkt‑Mittelzelle und eine 50‑Punkt‑Unterzelle. Die rechte Spalte enthält nun drei Zellen mit Höhen von 50, 40 bzw. 50 Punkten von oben nach unten. Die linke Zelle erstreckt sich über alle drei Zeilen und behält ihre ursprüngliche Höhe von 140 Punkten bei.

![The left cell spans the full table height beside three cells with Middle in the center.](split-by-height.png)

## **Hintergrundfarbe der Tabellenzelle ändern**

Dieses Beispiel erstellt eine Tabelle mit 150‑Punkt‑Spalten und 50‑Punkt‑Zeilen. Es verwendet [setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) um eine einfarbige Füllung auszuwählen und setzt die über [getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--) erhaltene Farbe auf Rot für Zelle `(2, 3)`, also die dritte Spalte und vierte Zeile.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 150, 150, 150, 150 };
    double[] rowHeights = { 50, 50, 50, 50, 50 };
    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    ICell cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid);
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ein Bild in einer Tabellenzelle einfügen**

Legen Sie das Eingabebild im Arbeitsverzeichnis ab, bevor Sie dieses Beispiel ausführen. Es lädt das Bild mit [Images.fromFile](https://reference.aspose.com/slides/androidjava/com.aspose.slides/images/#fromFile-java.lang.String-) und fügt es der Bildsammlung der Präsentation mit [addImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-) hinzu. Anschließend wird das Bild dem Bildfüllungs‑Modus der Zelle `(0, 0)`, der ersten Zelle der Tabelle, zugewiesen.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) streckt das Bild, sodass die Zelle vollständig gefüllt wird, was das Seitenverhältnis ändern kann. Spaltenbreiten und Zeilenhöhen sind in Punkten angegeben. Das geladene Bild wird in einem `finally`‑Block freigegeben, nachdem es der Präsentation hinzugefügt wurde.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 150, 150, 150, 150 };
    double[] rowHeights = { 100, 100, 100, 100, 90 };
    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    IPPImage ppImage;
    IImage image = Images.fromFile("aspose_logo.jpg");
    try {
        ppImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(FillType.Picture);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);

    presentation.save("table_cell_with_image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Kann ich unterschiedliche Linienstärken und -stile für die verschiedenen Seiten einer einzelnen Zelle festlegen?**

Ja. Die [top](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderTop--)/[bottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderBottom--)/[left](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderLeft--)/[right](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderRight--)‑Ränder besitzen separate Eigenschaften, sodass Dicke und Stil jeder Seite unterschiedlich sein können.

**Was passiert mit dem Bild, wenn ich die Spalten‑/Zeilen‑Größe ändere, nachdem ich ein Bild als Zell‑Hintergrund festgelegt habe?**

Das Verhalten hängt vom [fill mode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) (stretch/tile) ab. Beim Strecken passt sich das Bild der neuen Zelle an, beim Kacheln werden die Kacheln neu berechnet.

**Kann ich einem Hyperlink den gesamten Inhalt einer Zelle zuweisen?**

[Hyperlinks](/slides/de/androidjava/manage-hyperlinks/) werden auf Textebene (Portion) innerhalb des TextFrames einer Zelle oder auf Ebene der gesamten Tabelle/Form gesetzt. Praktisch ordnen Sie den Link einer Portion oder dem gesamten Text in der Zelle zu.

**Kann ich verschiedene Schriftarten innerhalb einer einzelnen Zelle festlegen?**

Ja. Der TextFrame einer Zelle unterstützt [portions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) (Läufe) mit unabhängiger Formatierung – Schriftfamilie, Stil, Größe und Farbe.