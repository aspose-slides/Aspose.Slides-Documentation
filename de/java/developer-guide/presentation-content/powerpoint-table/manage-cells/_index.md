---
title: Tabellenzellen in Präsentationen mit Java verwalten
linktitle: Zellen verwalten
type: docs
weight: 30
url: /de/java/manage-cells/
keywords:
- Tabellenzelle
- Zellen zusammenführen
- Rahmen entfernen
- Zelle teilen
- Bild in Zelle
- Hintergrundfarbe
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Verwalten Sie PowerPoint-Tabellenzellen in Java: Erkennen zusammengeführter Zellen, Entfernen von Rahmen, Teilen von Zellen und Festlegen von Hintergrundfarben und Bildern mit Aspose.Slides für Java."
---
## **Übersicht**

Aspose.Slides ermöglicht den Zugriff auf Tabellenzellen in PowerPoint-Präsentationen und deren Bearbeitung. Dieser Artikel erklärt, wie man zusammengeführte Tabellenzellen erkennt, Zellrahmen entfernt, mit der Zellnummerierung nach dem Zusammenführen oder Aufteilen von Zellen arbeitet, die Hintergrundfarbe einer Zelle ändert und ein Bild in einer Tabellenzelle hinzufügt. Die Beispiele zeigen, wie man eine Präsentation erstellt oder öffnet, eine Tabelle von einer Folie abruft, die Zellenformatierung über Zelleigenschaften aktualisiert und die geänderte Präsentation als PPTX-Datei speichert.

Aspose.Slides verwendet nullbasierte Indizes, um Tabellenzellen in der Reihenfolge `(Spalte, Zeile)` zuzugreifen.

## **Erkennen einer zusammengeführten Tabellenzelle**

Das Beispiel öffnet eine vorhandene Präsentation und greift auf die erste Form auf der ersten Folie als Tabelle zu. Es wird davon ausgegangen, dass Folie und Form existieren und dass die Form eine Tabelle ist. Anschließend wird über alle Zeilen und Spalten iteriert und die Methode [isMergedCell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#isMergedCell--) verwendet, um Zellen in zusammengeführten Bereichen zu identifizieren. Für jede Übereinstimmung werden die Zellkoordinaten in der Reihenfolge `Zeile;Spalte` ausgegeben, sowie [getRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getRowSpan--), [getColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getColSpan--), und die Startkoordinaten des Bereichs, [getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) und [getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--).

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

## **Entfernen von Tabellenzellenrändern**

Erstellen Sie eine [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) und fügen Sie ihrer ersten Folie mit [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) eine Tabelle hinzu. Spaltenbreiten, Zeilenhöhen und die Tabellenposition werden in Punkten angegeben. Das Beispiel setzt alle vier Zellrahmen auf [FillType.NoFill](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/), sodass sie unsichtbar sind.

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

## **Diagonale Zellrahmen hinzufügen**

Verwenden Sie [getBorderDiagonalDown](https://reference.aspose.com/slides/java/com.aspose.slides/icellformat/#getBorderDiagonalDown--) um eine Linie von der oberen linken Ecke zur unteren rechten Ecke zu zeichnen, und [getBorderDiagonalUp](https://reference.aspose.com/slides/java/com.aspose.slides/icellformat/#getBorderDiagonalUp--) um eine Linie von der unteren linken Ecke zur oberen rechten Ecke zu zeichnen. Eine Diagonale kann einen Eckkopf markieren; beide Diagonalen können ein X bilden, um eine Zelle als nicht anwendbar zu kennzeichnen.

Jede Diagonale ist ein [ILineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/). In ihrem [getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getFillFormat--) verwenden Sie [setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) um [FillType.Solid](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) auszuwählen und über [getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--) eine Farbe zu bestimmen. Die Linienbreite wird in Punkten mit [setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setWidth-double-) festgelegt.

Das Beispiel erstellt drei Zellen in einer Zeile: eine rote diagonale nach unten, eine blaue diagonale nach oben und beide Diagonalen. Die oberen, unteren, linken und rechten Zellrahmen bleiben unverändert.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

Eine Diagonale ist eine Formatierungseigenschaft, kein Zellsplit. Jede Zelle behält einen einzelnen Textrahmen, der über [getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getTextFrame--) zugänglich ist; die Bereiche auf beiden Seiten einer Diagonale können nicht unabhängig voneinander bearbeitet werden.

![Drei Tabellenzellen mit einer roten diagonalen Linie von oben links nach unten rechts, einer blauen diagonalen Linie von unten links nach oben rechts und beiden Diagonalen, die ein X bilden.](diagonal-cell-borders.png)

*Von links nach rechts: abwärts gerichtete Diagonale (rot, 3 pt), aufwärts gerichtete Diagonale (blau, 5 pt) und beide Diagonalen.*

## **Zusammenführen von Tabellenzellen**

Verwenden Sie [mergeCells](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-) um einen rechteckigen Bereich von Tabellenzellen zu einer Zelle zu kombinieren. Geben Sie die Zellen in den oberen linken bzw. unteren rechten Ecken des Bereichs an. Das letzte Argument steuert, ob das Zusammenführen Zellen außerhalb des angegebenen Bereichs einschließen darf; `false` hält das Zusammenführen innerhalb dieses Bereichs.

Das Beispiel erstellt eine 4 × 4‑Tabelle mit 70‑Punkt‑Spalten und -Zeilen und verbindet dann die vier mittleren Zellen von `(1, 1)` bis `(2, 2)`. Die resultierende Zelle erstreckt sich über zwei Spalten und zwei Zeilen, während das zugrunde liegende Raster der Tabelle vier Spalten und vier Zeilen beibehält. Um auf den Inhalt oder die Formatierung der zusammengeführten Zelle zuzugreifen, verwenden Sie ihre obere linke Position: `table.get_Item(1, 1)` in diesem Beispiel. Die anderen Positionen im zusammengeführten Bereich bleiben Teil des Tabellengitters, sodass die Indizes der Zellen außerhalb des Bereichs unverändert bleiben.

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

## **Aufteilen von Tabellenzellen**

Das Zusammenführen von Zellen im vorherigen Beispiel erhält das Tabellengitter. Das Aufteilen einer Zelle kann eine neue Gitterspalte einführen und die Spaltenindizes der Zellen rechts davon ändern. Aspose.Slides folgt dem Tabellenrastermodell von PowerPoint.

Dieses Beispiel erstellt eine 4 × 4‑Tabelle mit 70‑Punkt‑Spalten und -Zeilen und ruft [splitByWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByWidth-double-) für die Zelle `(1, 1)` auf. Die Hälfte der 70‑Punkt‑Breite wird übergeben, um zwei gleich breite Zellen zu erzeugen.

Nach diesem Split werden die beiden Hälften über `table.get_Item(1, 1)` und `table.get_Item(2, 1)` angesprochen. Das Tabellengitter hat nun fünf Spalten: Zellen, die ursprünglich in den Spalten 2 und 3 lagen, verschieben sich zu den Spalten 3 bzw. 4. Die Zeilenindizes bleiben unverändert. Verwenden Sie diese aktualisierten Spaltenindizes, wenn Sie nach dem Split auf Zellen zugreifen.

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
[![Eine nicht zusammengeführte 70-Punkt-Zelle teilt sich in zwei 35-Punkt-Zellen, fügt eine fünfte Rasterspalte hinzu und verschiebt die Indizes rechts davon.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*Die Breitenaufteilung betrifft Zelle (1, 1) unter Verwendung nullbasierter (Spalte, Zeile)-Indizes. Andere Zeilen behalten eine Zelle, die beide neuen Spaltenpositionen überspannt.*
<!-- visual-explanation:manage-cells:end -->

### **Zusammengeführte Zellen nach Zeilen- oder Spaltenbereich aufteilen**

Um zusammengeführte Vorlagenzellen für die Datenbefüllung vorzubereiten, verwenden Sie [splitByRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByRowSpan-int-) um entlang einer bestehenden Zeilengrenze zu splitten, oder [splitByColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByColSpan-int-) um entlang einer Spaltengrenze zu splitten.

Das `index`‑Argument zählt Zeilen im oberen Teil oder Spalten im linken Teil des Splits; es ist relativ zum zusammengeführten Bereich:

- Zeilenaufteilung: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getRowSpan--).
- Spaltenaufteilung: `0 < index <` [getColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getColSpan--).

Das Beispiel geht davon aus, dass eine Präsentation eine Tabelle als erste Form auf der ersten Folie enthält, wobei `(1, 2)` und `(1, 3)` vertikal zusammengeführt sind. Ausgehend von der unteren Position verwendet es [getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--) und [getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) um den Ursprung zu lokalisieren und prüft beide Spannen. `splitByRowSpan(1)` trennt dann die Zeilen 2 und 3 für Produktnamen. Für eine horizontale Zwei‑Spalten‑Zusammenführung verwenden Sie stattdessen `splitByColSpan(1)`.

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

Das Tabellengitter und die umgebenden Zellindizes bleiben unverändert. Rufen Sie die resultierenden Zellen über ihre Koordinaten ab; hier haben beide eine Spanne von 1 und [isMergedCell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#isMergedCell--) gibt `false` aus. Größere Bereiche können nach einem Split teilweise zusammengeführt bleiben.

Der ursprüngliche Text und seine Formatierung verbleiben in der oberen (bzw. linken) Zelle; die neue Zelle ist leer, erbt jedoch die Zellformatierung wie Füllung, Rahmen und Ränder. Befüllen Sie die Zellen nach dem Split und setzen Sie ggf. die Textformatierung explizit.

Die gespeicherte Präsentation enthält separate „Product A“‑ und „Product B“‑Zellen, wobei die Formatierung der Vorlage erhalten bleibt. Siehe die [Cell API Reference](https://reference.aspose.com/slides/java/com.aspose.slides/cell/) für Details.

### **Eine Zelle bei einer bestimmten Höhe aufteilen**

[splitByHeight](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByHeight-double-) nimmt die Höhe des oberen Teils in Punkten. [splitByRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByRowSpan-int-) nimmt die Anzahl vorhandener Gitterzeilen im oberen Teil. Um eine 40‑Punkt‑Zelle in der rechten Spalte zu zentrieren, subtrahieren Sie 40 von der tatsächlichen Zellhöhe und teilen den verbleibenden Raum gleichmäßig darüber und darunter auf.

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

Der erste Split fügt eine Gitterzeile hinzu und lässt die unteren 90 Punkte in Zelle `(1, 1)` unverändert. Der zweite Split teilt diese Zelle in eine 40‑Punkt‑Mittelzelle und eine 50‑Punkt‑Unteren‑Zelle. Die rechte Spalte hat nun drei Zellen mit Höhen von 50, 40 bzw. 50 Punkten von oben nach unten. Die linke Zelle erstreckt sich über alle drei Zeilen und behält ihre ursprüngliche Höhe von 140 Punkten bei.

![Die linke Zelle erstreckt sich über die gesamte Tabellenhöhe neben drei Zellen mit 'Middle' in der Mitte.](split-by-height.png)

## **Hintergrundfarbe der Tabellenzelle ändern**

Dieses Beispiel erstellt eine Tabelle mit 150‑Punkt‑Spalten und 50‑Punkt‑Zeilen. Es verwendet [setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) um eine Vollfüllung auszuwählen und setzt die über [getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--) zurückgegebene Farbe für Zelle `(2, 3)` (dritte Spalte, vierte Zeile) auf Rot.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **Ein Bild in eine Tabellenzelle einfügen**

Legen Sie das Eingabebild vor dem Ausführen dieses Beispiels in das Arbeitsverzeichnis. Das Bild wird mit [Images.fromFile](https://reference.aspose.com/slides/java/com.aspose.slides/images/#fromFile-java.lang.String-) geladen und mit [addImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-) zur Bildsammlung der Präsentation hinzugefügt. Anschließend wird das Bild dem Bildfüllmodus der Zelle `(0, 0)` (erste Zelle der Tabelle) zugewiesen.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/) streckt das Bild, um die Zelle zu füllen, was das Seitenverhältnis ändern kann. Spaltenbreiten und Zeilenhöhen sind in Punkten angegeben. Das geladene Bild wird im `finally`‑Block entsorgt, nachdem es zur Präsentation hinzugefügt wurde.

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

**Kann ich unterschiedliche Linienstärken und -stile für verschiedene Seiten einer einzelnen Zelle festlegen?**

Ja. Die [top](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderTop--)/[bottom](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderBottom--)/[left](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderLeft--)/[right](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderRight--)‑Ränder haben separate Eigenschaften, sodass die Dicke und der Stil jeder Seite unterschiedlich sein können.

**Was passiert mit dem Bild, wenn ich die Spalten‑/Zeilengröße ändere, nachdem ich ein Bild als Hintergrund der Zelle festgelegt habe?**

Das Verhalten hängt vom [fill mode](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/) (stretch/tile) ab. Beim Strecken passt sich das Bild der neuen Zelle an, beim Kacheln werden die Kacheln neu berechnet.

**Kann ich einem Hyperlink dem gesamten Inhalt einer Zelle zuweisen?**

[Hyperlinks](/slides/de/java/manage-hyperlinks/) werden auf Textebene (Portion) innerhalb des Textrahmens der Zelle oder auf Ebene der gesamten Tabelle/Form gesetzt. In der Praxis weisen Sie den Link einer Portion oder dem gesamten Text in der Zelle zu.

**Kann ich verschiedene Schriftarten innerhalb einer einzelnen Zelle verwenden?**

Ja. Der Textrahmen einer Zelle unterstützt [portions](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) (Läufe) mit unabhängiger Formatierung – Schriftfamilie, Stil, Größe und Farbe.