---
title: Tabellenzellen in Präsentationen mit Java verwalten
linktitle: Zellen verwalten
type: docs
weight: 30
url: /de/java/manage-cells/
keywords:
- Tabellenzelle
- Zellen zusammenführen
- Rand entfernen
- Zelle teilen
- Bild in Zelle
- Hintergrundfarbe
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Verwalten Sie PowerPoint-Tabellenzellen in Java: Erkennen zusammengeführter Zellen, Entfernen von Rändern, Aufteilen von Zellen und Festlegen von Hintergrundfarben und Bildern mit Aspose.Slides für Java."
---
## **Übersicht**

Aspose.Slides ermöglicht das Zugreifen und Ändern von Tabellenzellen in PowerPoint‑Präsentationen. Dieser Artikel erklärt, wie man zusammengeführte Tabellenzellen erkennt, Zellenränder entfernt, mit Zellnummerierung nach dem Zusammenführen oder Aufteilen von Zellen arbeitet, die Hintergrundfarbe einer Zelle ändert und ein Bild in einer Tabellenzelle einfügt. Die Beispiele zeigen, wie man eine Präsentation erstellt oder öffnet, eine Tabelle aus einer Folie erhält, die Zellformatierung über Zelleigenschaften aktualisiert und die geänderte Präsentation als PPTX‑Datei speichert.

Aspose.Slides verwendet nullbasierte Indizes, um Tabellenzellen in der Reihenfolge `(column, row)` zu adressieren.

## **Identifizieren einer zusammengeführten Tabellenzelle**

Das Beispiel öffnet eine vorhandene Präsentation und greift auf die erste Form auf der ersten Folie als Tabelle zu. Es wird davon ausgegangen, dass die Folie und die Form existieren und dass die Form eine Tabelle ist. Anschließend iteriert es über alle Zeilen und Spalten und verwendet [isMergedCell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#isMergedCell--) , um Zellen in zusammengeführten Bereichen zu identifizieren. Für jede Übereinstimmung gibt es die Zellkoordinaten in der Reihenfolge `row;column`, [getRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getRowSpan--) , [getColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getColSpan--) und die Startkoordinaten des Bereichs, [getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) und [getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--) aus.

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

Erstellen Sie eine [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) und fügen Sie mit [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) eine Tabelle auf ihrer ersten Folie hinzu. Spaltenbreiten, Zeilenhöhen und die Tabellenposition werden in Punkt angegeben. Das Beispiel setzt alle vier Zellenränder auf [FillType.NoFill](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) , wodurch sie unsichtbar werden.

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

## **Zusammenführen von Tabellenzellen**

Verwenden Sie [mergeCells](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-) , um einen rechteckigen Bereich von Tabellenzellen zu einer Zelle zu kombinieren. Geben Sie die Zellen in der oberen linken bzw. unteren rechten Ecke des Bereichs an. Das letzte Argument steuert, ob das Zusammenführen Zellen außerhalb des angegebenen Bereichs einschließen darf; `false` hält das Zusammenführen innerhalb dieses Bereichs.

Das Beispiel erstellt eine 4‑mal‑4‑Tabelle mit 70‑Punkt‑Spalten und -Zeilen und führt dann die vier mittleren Zellen von `(1, 1)` bis `(2, 2)` zusammen. Die resultierende Zelle erstreckt sich über zwei Spalten und zwei Zeilen, während das zugrunde liegende Raster der Tabelle vier Spalten und vier Zeilen beibehält. Um auf den Inhalt oder die Formatierung der zusammengeführten Zelle zuzugreifen, verwenden Sie deren obere linke Position: `table.get_Item(1, 1)` in diesem Beispiel. Die anderen Positionen im zusammengeführten Bereich bleiben Teil des Tabellenrasters, sodass sich die Indizes von Zellen außerhalb des Bereichs nicht ändern.

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

Das Zusammenführen von Zellen im vorherigen Beispiel bewahrt das Raster der Tabelle. Das Aufteilen einer Zelle kann eine neue Rasterspalte einführen und die Spaltenindizes der Zellen rechts davon ändern. Aspose.Slides folgt dem Tabellengittermodell von PowerPoint.

Dieses Beispiel erstellt eine 4‑mal‑4‑Tabelle mit 70‑Punkt‑Spalten und -Zeilen und ruft [splitByWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByWidth-double-) für die Zelle `(1, 1)` auf. Die Hälfte der 70‑Punkt‑Breite der Zelle wird übergeben, um zwei gleich breite Zellen zu erzeugen.

Nach diesem Aufteilen werden die beiden Hälften über `table.get_Item(1, 1)` und `table.get_Item(2, 1)` angesprochen. Das Tabellengitter hat jetzt fünf Spalten: Zellen, die ursprünglich in den Spalten 2 und 3 waren, verschieben sich zu den Spalten 3 bzw. 4. Zeilenindizes bleiben unverändert. Verwenden Sie diese aktualisierten Spaltenindizes, wenn Sie nach dem Aufteilen auf Zellen zugreifen.

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

### **Zusammengeführte Zellen nach Zeilen‑ oder Spalten‑Spanne aufteilen**

Um zusammengeführte Vorlagenzellen für die Datenbefüllung vorzubereiten, verwenden Sie [splitByRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByRowSpan-int-) , um entlang einer vorhandenen Zeilen­grenze zu teilen, oder [splitByColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByColSpan-int-) , um entlang einer Spaltengrenze zu teilen.

Das Argument `index` zählt Zeilen im oberen Teil bzw. Spalten im linken Teil der Teilung; es ist relativ zum zusammengeführten Gebiet:

- Zeilen‑Aufteilung: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getRowSpan--).
- Spalten‑Aufteilung: `0 < index <` [getColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getColSpan--).

Das Beispiel geht davon aus, dass eine Präsentation eine Tabelle als erste Form auf der ersten Folie enthält, wobei `(1, 2)` und `(1, 3)` vertikal zusammengeführt sind. Ausgehend von der unteren Position verwendet es [getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--) und [getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) , um den Ursprung zu ermitteln und prüft beide Spannen. `splitByRowSpan(1)` trennt dann die Zeilen 2 und 3 für Produktnamen. Für eine horizontale Zusammenführung über zwei Spalten verwenden Sie stattdessen `splitByColSpan(1)`.

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

        // Die resultierenden Zellen aus der Tabelle nach dem Aufteilen abrufen.
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

Das Tabellengitter und die umgebenden Zellenindizes bleiben unverändert. Rufen Sie die resultierenden Zellen über ihre Koordinaten ab; hier haben beide eine Spanne von 1 und [isMergedCell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#isMergedCell--) gibt `false` aus. Größere Bereiche können nach einem Aufteilen teilweise zusammengeführt bleiben.

Der ursprüngliche Text und seine Formatierung bleiben in der oberen (bzw. linken) Zelle; die neue Zelle ist leer, erbt jedoch die Zellformatierung wie Füllung, Ränder und Abstände. Füllen Sie die Zellen nach dem Aufteilen und setzen Sie alle erforderlichen Textformatierungen explizit.

Die gespeicherte Präsentation enthält separate "Product A"‑ und "Product B"‑Zellen, wobei die Zellformatierung der Vorlage erhalten bleibt. Siehe die [Cell‑API‑Referenz](https://reference.aspose.com/slides/java/com.aspose.slides/cell/) für Details.

## **Ändern der Hintergrundfarbe einer Tabellenzelle**

Dieses Beispiel erstellt eine Tabelle mit 150‑Punkt‑Spalten und 50‑Punkt‑Zeilen. Es verwendet [setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) , um eine einfarbige Füllung auszuwählen, und setzt die von [getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--) zurückgegebene Farbe für die Zelle `(2, 3)` (dritte Spalte, vierte Zeile) auf Rot.

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

## **Ein Bild in einer Tabellenzelle einfügen**

Legen Sie das Eingabebild vor dem Ausführen dieses Beispiels im Arbeitsverzeichnis ab. Es lädt das Bild mit [Images.fromFile](https://reference.aspose.com/slides/java/com.aspose.slides/images/#fromFile-java.lang.String-) und fügt es der Bildsammlung der Präsentation mit [addImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-) hinzu. Anschließend weist es das Bild der Bildfüllung der Zelle `(0, 0)`, der ersten Zelle in der Tabelle, zu.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/) dehnt das Bild, um die Zelle zu füllen, was das Seitenverhältnis ändern kann. Spaltenbreiten und Zeilenhöhen sind in Punkt angegeben. Das geladene Bild wird in einem `finally`‑Block nach dem Hinzufügen zur Präsentation freigegeben.

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

**Kann ich für die einzelnen Seiten einer Zelle unterschiedliche Linienstärken und -stile festlegen?**

Ja. Die [oben](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderTop--)/[unten](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderBottom--)/[links](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderLeft--)/[rechts](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderRight--)‑Ränder haben separate Eigenschaften, sodass die Dicke und der Stil jeder Seite unterschiedlich sein können.

**Was passiert mit dem Bild, wenn ich die Spalten‑/Zeilengröße ändere, nachdem ich ein Bild als Hintergrund der Zelle festgelegt habe?**

Das Verhalten hängt vom [Füllmodus](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/) (stretch/tiling) ab. Beim Dehnen passt sich das Bild der neuen Zelle an; beim Kacheln werden die Kacheln neu berechnet.

**Kann ich einem Zellinhalt einen Hyperlink zuweisen?**

[Hyperlinks](/slides/de/java/manage-hyperlinks/) werden auf Textebene (Portion) innerhalb des Textfeldes der Zelle oder auf Ebene der gesamten Tabelle/Form gesetzt. In der Praxis weist man den Link einer Portion oder dem gesamten Text in der Zelle zu.

**Kann ich in einer einzelnen Zelle unterschiedliche Schriftarten festlegen?**

Ja. Das Textfeld einer Zelle unterstützt [Portionen](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) (Läufe) mit unabhängiger Formatierung – Schriftfamilie, Stil, Größe und Farbe.