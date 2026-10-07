---
title: Verwalten von Tabellenzellen in Präsentationen auf Android
linktitle: Zellen verwalten
type: docs
weight: 30
url: /de/androidjava/manage-cells/
keywords:
- Tabellenzelle
- Zellen zusammenführen
- Rahmen entfernen
- Zelle teilen
- Bild in Zelle
- Hintergrundfarbe
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Verwalten von PowerPoint-Tabellenzellen unter Android: zusammengeführte Zellen identifizieren, Rahmen entfernen, Zellen teilen und Hintergrundfarben sowie Bilder mit Aspose.Slides für Android über Java festlegen."
---
## **Übersicht**

Aspose.Slides ermöglicht den Zugriff auf Tabellenzellen in PowerPoint‑Präsentationen und deren Modifikation. Dieser Artikel erklärt, wie man zusammengeführte Tabellenzellen erkennt, Zellrahmen entfernt, mit Zellnummerierung nach dem Zusammenführen oder Teilen von Zellen arbeitet, die Hintergrundfarbe einer Zelle ändert und ein Bild innerhalb einer Tabellenzelle hinzufügt. Die Beispiele zeigen, wie man eine Präsentation erstellt oder öffnet, eine Tabelle von einer Folie abruft, Zellformatierungen über Zellen‑Eigenschaften aktualisiert und die modifizierte Präsentation als PPTX‑Datei speichert.

Aspose.Slides verwendet nullbasierte Indizes, um Tabellenzellen in der Reihenfolge `(column, row)` zu adressieren.

## **Identifizieren einer zusammengefügten Tabellenzelle**

Das Beispiel öffnet eine vorhandene Präsentation und greift auf die erste Form auf der ersten Folie als Tabelle zu. Es wird vorausgesetzt, dass die Folie und die Form existieren und dass die Form eine Tabelle ist. Anschließend wird über alle Zeilen und Spalten iteriert und [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) verwendet, um Zellen in zusammengeführten Bereichen zu identifizieren. Für jede Übereinstimmung werden die Zellkoordinaten in der Reihenfolge `row;column`, [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--), [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--), und die Startkoordinaten des Bereichs, [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) und [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) ausgegeben.

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

## **Entfernen von Tabellenzellenrahmen**

Erstellen Sie ein [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) und fügen Sie seiner ersten Folie mit [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) eine Tabelle hinzu. Spaltenbreiten, Zeilenhöhen und die Position der Tabelle werden in Punkt angegeben. Das Beispiel setzt alle vier Zellrahmen auf [FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) und macht sie unsichtbar.

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

Verwenden Sie [mergeCells](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-), um einen rechteckigen Bereich von Tabellenzellen zu einer Zelle zu kombinieren. Geben Sie die Zellen an den oberen linken und unteren rechten Ecken des Bereichs an. Das letzte Argument steuert, ob das Zusammenführen Zellen außerhalb des angegebenen Bereichs einschließen darf; `false` hält das Zusammenführen innerhalb dieses Bereichs.

Das Beispiel erstellt eine 4 × 4‑Tabelle mit 70‑Punkt‑Spalten und -Zeilen und verbindet dann die vier mittleren Zellen von `(1, 1)` bis `(2, 2)`. Die resultierende Zelle erstreckt sich über zwei Spalten und zwei Zeilen, während das zugrunde liegende Raster der Tabelle vier Spalten und vier Zeilen beibehält. Um auf den Inhalt oder das Format der zusammengeführten Zelle zuzugreifen, verwenden Sie ihre obere linke Position: `table.get_Item(1, 1)` in diesem Beispiel. Die anderen Positionen im zusammengeführten Bereich bleiben Teil des Tabellengitters, sodass sich die Indizes der Zellen außerhalb des Bereichs nicht ändern.

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

Das Zusammenführen von Zellen im vorherigen Beispiel erhält das Tabellengitter. Das Aufteilen einer Zelle kann eine neue Spalte im Gitter einführen und die Spaltenindizes der rechts davon liegenden Zellen ändern. Aspose.Slides folgt dem Tabellengittermodell von PowerPoint.

Dieses Beispiel erstellt eine 4 × 4‑Tabelle mit 70‑Punkt‑Spalten und -Zeilen und ruft [splitByWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByWidth-double-) für die Zelle `(1, 1)` auf. Die Hälfte der 70‑Punkt‑Breite der Zelle wird übergeben, um zwei Zellen gleicher Breite zu erzeugen.

Nach diesem Aufteilen werden die beiden Hälften über `table.get_Item(1, 1)` und `table.get_Item(2, 1)` angesprochen. Das Tabellengitter besitzt jetzt fünf Spalten: Zellen, die ursprünglich in den Spalten 2 und 3 waren, verschieben sich zu den Spalten 3 bzw. 4. Die Zeilenindizes bleiben unverändert. Verwenden Sie diese aktualisierten Spaltenindizes, wenn Sie nach dem Aufteilen auf Zellen zugreifen.

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

### **Aufteilen zusammengeführter Zellen nach Zeilen‑ oder Spalten‑Spannweite**

Um zusammengeführte Vorlagencellen für die Datenbefüllung vorzubereiten, verwenden Sie [splitByRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByRowSpan-int-), um entlang einer bestehenden Zeilen­grenze zu teilen, oder [splitByColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByColSpan-int-), um entlang einer Spalten­grenze zu teilen.

Das Argument `index` zählt Zeilen im oberen Teil bzw. Spalten im linken Teil der Teilung; es bezieht sich relativ auf das zusammengeführte Gebiet:

- Zeilen‑Teilung: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--).
- Spalten‑Teilung: `0 < index <` [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--).

Das Beispiel geht davon aus, dass eine Präsentation eine Tabelle als erste Form auf der ersten Folie enthält, wobei `(1, 2)` und `(1, 3)` vertikal zusammengeführt sind. Ausgehend von der unteren Position verwendet es [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) und [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) , um den Ursprung zu ermitteln, und prüft beide Spannweiten. `splitByRowSpan(1)` trennt dann die Zeilen 2 und 3 für Produktnamen. Für eine horizontale Zwei‑Spalten‑Zusammenführung verwenden Sie stattdessen `splitByColSpan(1)`.

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

        // Rufen Sie die nach dem Aufteilen resultierenden Zellen aus der Tabelle ab.
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

Das Tabellengitter und die umgebenden Zellindizes bleiben unverändert. Rufen Sie die resultierenden Zellen über ihre Koordinaten ab; hier haben beide eine Spannweite von 1 und [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) gibt `false` zurück. Größere Bereiche können nach einer Teilung teilweise zusammengeblieben sein.

Der ursprüngliche Text und seine Formatierung bleiben in der oberen (bzw. linken) Zelle; die neue Zelle ist leer, erbt jedoch die Zellformatierung wie Füllung, Rahmen und Ränder. Befüllen Sie die Zellen nach dem Aufteilen und setzen Sie bei Bedarf die Textformatierung explizit.

Die gespeicherte Präsentation enthält separate „Product A“ und „Product B“ Zellen, wobei die Zellformatierung der Vorlage erhalten bleibt. Siehe die [Cell‑API‑Referenz](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/) für Details.

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

## **Ändern der Hintergrundfarbe einer Tabellenzelle**

Dieses Beispiel erstellt eine Tabelle mit 150‑Punkt‑Spalten und 50‑Punkt‑Zeilen. Es verwendet [setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) , um eine einfarbige Füllung auszuwählen, und setzt die von [getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--) zurückgegebene Farbe für die Zelle `(2, 3)` (dritte Spalte, vierte Zeile) auf Rot.

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

## **Ein Bild in einer Tabellenzelle einfügen**

Platzieren Sie das Eingabebild im Arbeitsverzeichnis, bevor Sie dieses Beispiel ausführen. Es lädt das Bild mit [Images.fromFile](https://reference.aspose.com/slides/androidjava/com.aspose.slides/images/#fromFile-java.lang.String-) und fügt es der Bildsammlung der Präsentation mit [addImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-) hinzu. Anschließend weist es das Bild dem Bildfüllmodus der Zelle `(0, 0)`, der ersten Zelle der Tabelle, zu.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) streckt das Bild, um die Zelle auszufüllen, was das Seitenverhältnis verändern kann. Spaltenbreiten und Zeilenhöhen werden in Punkt angegeben. Das geladene Bild wird in einem `finally`‑Block freigegeben, nachdem es zur Präsentation hinzugefügt wurde.

## **FAQ**

**Kann ich verschiedene Linienstärken und -stile für verschiedene Seiten einer einzelnen Zelle festlegen?**

Ja. Die [oben](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderTop--)/[unten](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderBottom--)/[links](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderLeft--)/[rechts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderRight--) Rahmen besitzen separate Eigenschaften, sodass die Dicke und der Stil jeder Seite unterschiedlich sein können.

**Was passiert mit dem Bild, wenn ich die Spalten‑/Zeilengröße ändere, nachdem ein Bild als Hintergrund der Zelle festgelegt wurde?**

Das Verhalten hängt vom [fill mode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) (stretch/tile) ab. Beim Strecken passt sich das Bild der neuen Zelle an; beim Kacheln werden die Kacheln neu berechnet.

**Kann ich einem Hyperlink den gesamten Inhalt einer Zelle zuweisen?**

[Hyperlinks](/slides/de/androidjava/manage-hyperlinks/) werden auf Textebene (Portion) innerhalb des Textfelds der Zelle oder auf Ebene der gesamten Tabelle/Form gesetzt. In der Praxis weist man den Link einer Portion oder dem gesamten Text in der Zelle zu.

**Kann ich verschiedene Schriftarten innerhalb einer einzelnen Zelle festlegen?**

Ja. Das Textfeld einer Zelle unterstützt [Portionen](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) (Runs) mit unabhängiger Formatierung – Schriftfamilie, Stil, Größe und Farbe.