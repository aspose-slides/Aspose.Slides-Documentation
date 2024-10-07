---
title: Zellen verwalten
type: docs
weight: 30
url: /androidjava/manage-cells/
keywords: "Tabelle, zusammengeführte Zellen, geteilte Zellen, Bild in Tabellenzelle, Java, Aspose.Slides für Android über Java"
description: "Tabellenzellen in PowerPoint-Präsentationen in Java"
---


## **Zusammengeführte Tabellenzelle identifizieren**
1. Erstellen Sie eine Instanz der  [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
2. Holen Sie die Tabelle von der ersten Folie. 
3. Durchlaufen Sie die Zeilen und Spalten der Tabelle, um zusammengeführte Zellen zu finden.
4. Geben Sie eine Nachricht aus, wenn zusammengeführte Zellen gefunden werden.

Dieser Java-Code zeigt, wie man zusammengeführte Tabellenzellen in einer Präsentation identifiziert:

```java
Presentation pres = new Presentation("SomePresentationWithTable.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); // geht davon aus, dass Slide#0.Shape#0 eine Tabelle ist
    for (int i = 0; i < table.getRows().size(); i++)
    {
        for (int j = 0; j < table.getColumns().size(); j++)
        {
            ICell currentCell = table.getRows().get_Item(i).get_Item(j);
            if (currentCell.isMergedCell())
            {
                System.out.println(String.format("Zelle %d;%d ist Teil einer zusammengeführten Zelle mit RowSpan=%d und ColSpan=%d, die von Zelle %d;%d beginnt.",
                        i, j, currentCell.getRowSpan(), currentCell.getColSpan(), currentCell.getFirstRowIndex(), currentCell.getFirstColumnIndex()));
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Rahmen der Tabellenzellen entfernen**
1. Erstellen Sie eine Instanz der  [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
2. Holen Sie sich einen Verweis auf die Folie über ihren Index. 
3. Definieren Sie ein Array von Spalten mit Breite.
4. Definieren Sie ein Array von Zeilen mit Höhe.
5. Fügen Sie der Folie über die [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) Methode eine Tabelle hinzu.
6. Durchlaufen Sie jede Zelle, um die oberen, unteren, rechten und linken Rahmen zu löschen.
7. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Java-Code zeigt, wie man die Rahmen von Tabellenzellen entfernt:

```java
// Instanziiert die Präsentationsklasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Greift auf die erste Folie zu
    Slide sld = (Slide)pres.getSlides().get_Item(0);

    // Definiert Spalten mit Breiten und Zeilen mit Höhen
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Fügt der Folie eine Tabellenform hinzu
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Setzt das Rahmenformat für jede Zelle
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

    // Schreibt die PPTX auf die Festplatte
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Nummerierung in zusammengeführten Zellen**
Wenn wir 2 Paare von Zellen (1, 1) x (2, 1) und (1, 2) x (2, 2) zusammenführen, wird die resultierende Tabelle nummeriert. Dieser Java-Code demonstriert den Prozess:

```java
// Instanziiert die Präsentationsklasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Greift auf die erste Folie zu
    ISlide sld = pres.getSlides().get_Item(0);

    // Definiert Spalten mit Breiten und Zeilen mit Höhen
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Fügt der Folie eine Tabellenform hinzu
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Setzt das Rahmenformat für jede Zelle
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
// Instanziiert die Präsentationsklasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Greift auf die erste Folie zu
    ISlide sld = pres.getSlides().get_Item(0);

    // Definiert Spalten mit Breiten und Zeilen mit Höhen
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Fügt der Folie eine Tabellenform hinzu
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Setzt das Rahmenformat für jede Zelle
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

## **Nummerierung in geteilten Zellen**
In den vorherigen Beispielen, als Tabellenzellen zusammengeführt wurden, änderte sich die Numeration oder das Nummerierungssystem in anderen Zellen nicht. 

Diesmal nehmen wir eine reguläre Tabelle (eine Tabelle ohne zusammengeführte Zellen) und versuchen dann, die Zelle (1,1) zu teilen, um eine spezielle Tabelle zu erhalten. Sie sollten auf die Nummerierung dieser Tabelle achten, die als seltsam angesehen werden kann. Dennoch ist das die Art und Weise, wie Microsoft PowerPoint Tabellenzellen nummeriert, und Aspose.Slides macht dasselbe. 

Dieser Java-Code demonstriert den beschriebenen Prozess:

```java
// Instanziiert die Präsentationsklasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Greift auf die erste Folie zu
    ISlide sld = pres.getSlides().get_Item(0);

    // Definiert Spalten mit Breiten und Zeilen mit Höhen
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Fügt der Folie eine Tabellenform hinzu
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Setzt das Rahmenformat für jede Zelle
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

    // Teilt die Zelle (1, 1)
    tbl.get_Item(1, 1).splitByWidth(tbl.get_Item(2, 1).getWidth() / 2);

    // Schreibt die PPTX-Datei auf die Festplatte
    pres.save("SplitCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Hintergrundfarbe der Tabellenzelle ändern**

Dieser Java-Code zeigt, wie man die Hintergrundfarbe einer Tabellenzelle ändert:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 50, 50, 50, 50, 50 };

    // erstelle eine neue Tabelle
    ITable table = slide.getShapes().addTable(50, 50, dblCols, dblRows);

    // setzte die Hintergrundfarbe für eine Zelle 
    ICell cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid);
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Bild in Tabellenzelle hinzufügen**

1. Erstellen Sie eine Instanz der  [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
2. Holen Sie sich einen Verweis auf die Folie über ihren Index.
3. Definieren Sie ein Array von Spalten mit Breite.
4. Definieren Sie ein Array von Zeilen mit Höhe.
5. Fügen Sie der Folie über die [AddTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) Methode eine Tabelle hinzu.
6. Erstellen Sie ein `Images` Objekt, um die Bilddatei zu halten.
7. Fügen Sie das `IImage` Bild zum `IPPImage` Objekt hinzu.
8. Setzen Sie das `FillFormat` für die Tabellenzelle auf `Picture`.
9. Fügen Sie das Bild zur ersten Zelle der Tabelle hinzu.
10. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Java-Code zeigt, wie man ein Bild in eine Tabellenzelle einfügt, wenn man eine Tabelle erstellt:

```java
// Instanziiert die Präsentationsklasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Greift auf die erste Folie zu
    ISlide islide = pres.getSlides().get_Item(0);

    // Definiert Spalten mit Breiten und Zeilen mit Höhen
    double[] dblCols = {150, 150, 150, 150};
    double[] dblRows = {100, 100, 100, 100, 90};

    // Fügt der Folie eine Tabellenform hinzu
    ITable tbl = islide.getShapes().addTable(50, 50, dblCols, dblRows);

    // Erstellen eines IPPImage-Objekts mit der Bilddatei
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

    // Speichert die PPTX-Datei auf Disk
    pres.save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```