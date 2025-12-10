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
description: "Verwalten Sie Tabellenzellen in PowerPoint mühelos mit Aspose.Slides für Java. Lernen Sie, Zellen schnell zuzugreifen, zu ändern und zu formatieren für nahtlose Folienautomatisierung."
---

## **Identifizieren einer zusammengeführten Tabellenzelle**
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2. Rufen Sie die Tabelle von der ersten Folie ab. 
3. Iterieren Sie über die Zeilen und Spalten der Tabelle, um zusammengeführte Zellen zu finden.
4. Geben Sie eine Meldung aus, wenn zusammengeführte Zellen gefunden werden.

Dieser Java-Code zeigt Ihnen, wie Sie zusammengeführte Tabellenzellen in einer Präsentation identifizieren:
```java
Presentation pres = new Presentation("SomePresentationWithTable.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); // angenommen, dass Slide#0.Shape#0 eine Tabelle ist
    for (int i = 0; i < table.getRows().size(); i++)
    {
        for (int j = 0; j < table.getColumns().size(); j++)
        {
            ICell currentCell = table.getRows().get_Item(i).get_Item(j);
            if (currentCell.isMergedCell())
            {
                System.out.println(String.format("Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.",
                        i, j, currentCell.getRowSpan(), currentCell.getColSpan(), currentCell.getFirstRowIndex(), currentCell.getFirstColumnIndex()));
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Entfernen von Tabellenzellenrändern**
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2. Rufen Sie die Referenz einer Folie über ihren Index ab. 
3. Definieren Sie ein Array von Spalten mit Breite.
4. Definieren Sie ein Array von Zeilen mit Höhe.
5. Fügen Sie über die Methode [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) eine Tabelle zur Folie hinzu.
6. Iterieren Sie über jede Zelle, um die oberen, unteren, rechten und linken Ränder zu entfernen.
7. Speichern Sie die geänderte Präsentation als PPTX-Datei.

Dieser Java-Code zeigt Ihnen, wie Sie die Ränder von Tabellenzellen entfernen:
```java
// Instanziiert die Presentation-Klasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Greift auf die erste Folie zu
    Slide sld = (Slide)pres.getSlides().get_Item(0);

    // Definiert Spalten mit Breiten und Zeilen mit Höhen
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Fügt der Folie ein Tabellenshape hinzu
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Legt das Randformat für jede Zelle fest
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill);
        }
    }

    // Schreibt die PPTX-Datei auf die Festplatte
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Nummerierung in zusammengeführten Zellen**
Wenn wir 2 Paare von Zellen (1, 1) x (2, 1) und (1, 2) x (2, 2) zusammenführen, wird die resultierende Tabelle nummeriert. Dieser Java-Code demonstriert den Vorgang:
```java
// Instanziert die Presentation-Klasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Greift auf die erste Folie zu
    ISlide sld = pres.getSlides().get_Item(0);

    // Definiert Spalten mit Breiten und Zeilen mit Höhen
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Fügt der Folie ein Tabellenshape hinzu
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Legt das Randformat für jede Zelle fest
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // Führt Zellen (1, 1) x (2, 1) zusammen
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // Führt Zellen (1, 2) x (2, 2) zusammen
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


Wir führen dann die Zellen weiter zusammen, indem wir (1, 1) und (1, 2) zusammenführen. Das Ergebnis ist eine Tabelle mit einer großen zusammengeführten Zelle in der Mitte: 
```java
// Instanziert die Presentation-Klasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Greift auf die erste Folie zu
    ISlide sld = pres.getSlides().get_Item(0);

    // Definiert Spalten mit Breiten und Zeilen mit Höhen
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Fügt der Folie ein Tabellenshape hinzu
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Legt das Randformat für jede Zelle fest
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // Führt Zellen (1, 1) x (2, 1) zusammen
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // Führt Zellen (1, 2) x (2, 2) zusammen
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // Führt Zellen (1, 1) x (1, 2) zusammen
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(1, 2), true);
    
	// Schreibt die PPTX-Datei auf die Festplatte
    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Nummerierung in einer geteilten Zelle**
In vorherigen Beispielen, wenn Tabellenzellen zusammengeführt wurden, änderte sich die Numerierung oder das Nummernsystem in anderen Zellen nicht. 

Dieses Mal nehmen wir eine reguläre Tabelle (eine Tabelle ohne zusammengeführte Zellen) und versuchen dann, die Zelle (1,1) zu teilen, um eine spezielle Tabelle zu erhalten. Sie sollten die Nummerierung dieser Tabelle beachten, die möglicherweise ungewöhnlich erscheint. Das ist jedoch die Art und Weise, wie Microsoft PowerPoint Tabellenzellen nummeriert, und Aspose.Slides tut dasselbe.

Dieser Java-Code demonstriert den beschriebenen Vorgang:
```java
// Instanziert die Presentation-Klasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Greift auf die erste Folie zu
    ISlide sld = pres.getSlides().get_Item(0);

    // Definiert Spalten mit Breiten und Zeilen mit Höhen
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Fügt der Folie ein Tabellenshape hinzu
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Legt das Randformat für jede Zelle fest
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // Führt Zellen (1, 1) x (2, 1) zusammen
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // Führt Zellen (1, 2) x (2, 2) zusammen
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // Teilt Zelle (1, 1)
    tbl.get_Item(1, 1).splitByWidth(tbl.get_Item(2, 1).getWidth() / 2);

	// Schreibt die PPTX-Datei auf die Festplatte
    pres.save("SplitCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Ändern der Hintergrundfarbe einer Tabellenzelle**
Dieser Java-Code zeigt Ihnen, wie Sie die Hintergrundfarbe einer Tabellenzelle ändern:
```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 50, 50, 50, 50, 50 };

    // erstelle eine neue Tabelle
    ITable table = slide.getShapes().addTable(50, 50, dblCols, dblRows);

    // setze die Hintergrundfarbe für eine Zelle
    ICell cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid);
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **Ein Bild in einer Tabellenzelle einfügen**
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2. Rufen Sie die Referenz einer Folie über ihren Index ab.
3. Definieren Sie ein Array von Spalten mit Breite.
4. Definieren Sie ein Array von Zeilen mit Höhe.
5. Fügen Sie über die Methode [AddTable](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) eine Tabelle zur Folie hinzu.
6. Erstellen Sie ein `Images`-Objekt, das die Bilddatei enthält.
7. Fügen Sie das Bild `IImage` zum Objekt `IPPImage` hinzu.
8. Setzen Sie das `FillFormat` der Tabellenzelle auf `Picture`.
9. Fügen Sie das Bild zur ersten Zelle der Tabelle hinzu.
10. Speichern Sie die geänderte Präsentation als PPTX-Datei

Dieser Java-Code zeigt Ihnen, wie Sie ein Bild in eine Tabellenzelle einfügen, wenn Sie eine Tabelle erstellen:
```java
// Instanziert die Presentation-Klasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Greift auf die erste Folie zu
    ISlide islide = pres.getSlides().get_Item(0);

    // Definiert Spalten mit Breiten und Zeilen mit Höhen
    double[] dblCols = {150, 150, 150, 150};
    double[] dblRows = {100, 100, 100, 100, 90};

    // Fügt der Folie ein Tabellenshape hinzu
    ITable tbl = islide.getShapes().addTable(50, 50, dblCols, dblRows);

    // Erstellt ein IPPImage-Objekt mit der Bilddatei
    IPPImage picture;
    IImage image = Images.fromFile("image.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Fügt das Bild zur ersten Tabellenzelle hinzu
    ICellFormat cellFormat = tbl.get_Item(0, 0).getCellFormat();
    cellFormat.getFillFormat().setFillType(FillType.Picture);
    cellFormat.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    cellFormat.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Speichert die PPTX-Datei auf dem Datenträger
    pres.save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Kann ich für die einzelnen Seiten einer Zelle unterschiedliche Linienstärken und -stile festlegen?**

Ja. Die [top](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderTop--)/[bottom](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderBottom--)/[left](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderLeft--)/[right](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderRight--) Ränder haben separate Eigenschaften, sodass die Dicke und der Stil jeder Seite unterschiedlich sein können. Dies ergibt sich logisch aus der seitenspezifischen Randsteuerung für eine Zelle, die im Artikel gezeigt wird.

**Was passiert mit dem Bild, wenn ich die Spalten-/Zeilengröße ändere, nachdem ich ein Bild als Hintergrund der Zelle festgelegt habe?**

Das Verhalten hängt vom [fill mode](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/) (Strecken/Kacheln) ab. Beim Strecken passt sich das Bild an die neue Zelle an; beim Kacheln werden die Kacheln neu berechnet. Der Artikel erwähnt die Anzeige­modi von Bildern in einer Zelle.

**Kann ich einem gesamten Zellinhalt einen Hyperlink zuweisen?**

[Hyperlinks](/slides/de/java/manage-hyperlinks/) werden auf Textebene (Portion) innerhalb des Textrahmens der Zelle oder auf Ebene der gesamten Tabelle/Form festgelegt. In der Praxis ordnen Sie den Link einer Portion oder dem gesamten Text in der Zelle zu.

**Kann ich innerhalb einer einzelnen Zelle verschiedene Schriften festlegen?**

Ja. Der Textrahmen einer Zelle unterstützt [portions](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) (Läufe) mit unabhängiger Formatierung – Schriftfamilie, Stil, Größe und Farbe.