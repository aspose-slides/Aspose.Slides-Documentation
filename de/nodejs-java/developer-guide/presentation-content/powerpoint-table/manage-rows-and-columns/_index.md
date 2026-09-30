---
title: "Tabellenzeilen und -spalten in PowerPoint mit JavaScript verwalten"
linktitle: "Zeilen und Spalten"
type: docs
weight: 20
url: /de/nodejs-java/manage-rows-and-columns/
keywords:
- "Tabellenzeile"
- "Tabellenspalte"
- "erste Zeile"
- "Tabellenkopf"
- "Zeile klonen"
- "Spalte klonen"
- "Zeile kopieren"
- "Spalte kopieren"
- "Zeile entfernen"
- "Spalte entfernen"
- "Zeilentextformatierung"
- "Spaltentextformatierung"
- "Tabellenstil"
- "PowerPoint"
- "Präsentation"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Verwalten Sie Tabellenzeilen und -spalten in PowerPoint mit JavaScript und Aspose.Slides für Node.js über Java und beschleunigen Sie die Bearbeitung von Präsentationen und Datenaktualisierungen."
---
## **Einleitung**

Aspose.Slides for Node.js via Java lets you manage table structure and formatting in PowerPoint presentations through the [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) class. Sie können eine Header‑Zeile festlegen, Zeilen und Spalten duplizieren oder entfernen und Textformatierung auf eine gesamte Zeile oder Spalte anwenden.

Dieser Artikel erklärt diese Vorgänge anhand von JavaScript‑Beispielen. Er zeigt außerdem, wie Sie das Stil‑Preset einer Tabelle abrufen können, um es wiederzuverwenden. Zeilen‑ und Spaltenindizes einer Tabelle beginnen bei Null.

## **Steuerung der Zeilenhöhe**

Verwenden Sie [Row.setMinimalHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#setMinimalHeight-double-) , um die minimale Höhe einer Zeile in Punkten festzulegen. Es ist eine Untergrenze, keine feste Höhe. [Row.getHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#getHeight--) gibt die tatsächliche Höhe zurück. Greifen Sie über [Table.getRows](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getRows--) auf die Zeile zu.

Das Beispiel lädt [row-height-input.pptx](row-height-input.pptx), das eine Tabelle als erstes Shape auf der ersten Folie enthält. Die erste Zeile beginnt bei 70 Punkten. Die Zellen verwenden 18‑Punkt‑Arial‑Text, Zeilenumbruch und 6‑Punkt‑Abstände oben und unten; der längere Text in der zweiten Spalte wird auf mehrere Zeilen umgebrochen. Das Beispiel erhöht das Minimum auf 100 Punkte, reduziert es dann auf 20 Punkte, gibt nach jeder Änderung die tatsächliche Höhe aus und speichert beide Ergebnisse.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("row-height-input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    const row = table.getRows().get_Item(0);

    row.setMinimalHeight(100);
    console.log("Increased: minimum = " + row.getMinimalHeight().toFixed(1) + ", actual = " + row.getHeight().toFixed(1) + " pt");
    presentation.save("row-height-increased.pptx", slides.SaveFormat.Pptx);

    row.setMinimalHeight(20);
    console.log("Decreased: minimum = " + row.getMinimalHeight().toFixed(1) + ", actual = " + row.getHeight().toFixed(1) + " pt");
    presentation.save("row-height-decreased.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bei der bereitgestellten Präsentation fügt das Erhöhen des Minimums der Zeile zusätzlichen Platz hinzu. Das Verringern entfernt diesen zusätzlichen Platz, aber die tatsächliche Höhe bleibt größer als 20 Punkte, da Text und Zellabstände mehr Raum benötigen. Das alleinige Reduzieren des Minimums kann die Zeile nicht unter den von ihrem Inhalt benötigten Platz zwingen.

Mehrere Faktoren beeinflussen die tatsächliche Höhe:

- **Text und Schriftgröße:** langer Text, explizite Zeilenumbrüche oder eine größere Schrift können mehr vertikalen Raum benötigen.
- **Umbruch und Spaltenbreite:** Bei aktiviertem Umbruch kann das Reduzieren der Spaltenbreite mit [Column.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/column/#setWidth-double-) mehr Zeilen erzeugen. Eine breitere Spalte kann den vertikalen Platzbedarf verringern.
- **Zellabstände:** [Cell.setMarginTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginTop-double-) und [Cell.setMarginBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginBottom-double-) fügen vertikalen Raum hinzu. [Cell.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginLeft-double-) und [Cell.setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginRight-double-) verringern die für Text verfügbare Breite und können zusätzlichen Umbruch verursachen.

Bei dieser Tabelle ohne zusammengeführte Zellen bestimmt die Zelle, die den meisten vertikalen Platz benötigt, die inhaltlich getriebene Untergrenze für die gesamte Zeile. Um die Zeile kürzer zu machen, müssen Sie möglicherweise den Text verkürzen, die Schriftgröße oder die Abstände reduzieren oder eine Spalte verbreitern.

Die unten gezeigten Bilder zeigen dieselbe Tabelle im gleichen Maßstab. In den dargestellten Ergebnissen betrugen die tatsächlichen Höhen 70, 100 und 55,2 Punkte: die letzte Zeile blieb höher als ihr Minimum von 20 Punkten. Exakte Textmaße können je nach in Ihrer Umgebung verfügbaren Schriften variieren. Laden Sie die gespeicherten Ergebnisse herunter: [erhöhtes Minimum](row-height-increased.pptx) und [reduziertes Minimum](row-height-decreased.pptx).

| Original: Mindestwert 70 pt, tatsächlicher Wert 70 pt | Erhöht: Mindestwert 100 pt, tatsächlicher Wert 100 pt | Verringert: Mindestwert 20 pt, tatsächlicher Wert 55.2 pt |
| --- | --- | --- |
| ![Originaltabelle mit einer ersten Zeile von 70 Punkten.](row-height-before.png) | ![Tabelle nach Erhöhen des Minimums der ersten Zeile auf 100 Punkte.](row-height-increased.png) | ![Tabelle nach Verringern des Minimums der ersten Zeile auf 20 Punkte; umgebrochener Text hält die Zeile höher als das Minimum.](row-height-decreased.png) |

## **Erste Zeile als Kopfzeile festlegen**

Verwenden Sie die Methode [setFirstRow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setFirstRow-boolean-) , um die erste Zeile für die Kopfzeilenformatierung zu markieren. Das Aussehen hängt vom auf die Tabelle angewendeten Tabellenstil ab.

1. Laden Sie die Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Greifen Sie auf die erste Folie zu.
3. Greifen Sie auf die Tabelle zu, die als erstes Shape auf der Folie gespeichert ist.
4. Aktivieren Sie die Kopfzeilenformatierung für deren erste Zeile.
5. Speichern Sie die geänderte Präsentation.

Das Beispiel benötigt `table.pptx` mit einer Tabelle als erstes Shape auf der ersten Folie. Es aktiviert die Kopfzeilenformatierung für die erste Zeile und speichert `First_row_header.pptx`.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    table.setFirstRow(true);

    presentation.save("First_row_header.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Zeile oder Spalte einer Tabelle klonen**

Klonen Sie Zeilen oder Spalten, um deren Inhalt und Formatierung wiederzuverwenden. Sie können eine Kopie am Ende der Tabelle anhängen oder an einer bestimmten Position einfügen.

1. Laden Sie die Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Greifen Sie auf die erste Folie zu.
3. Definieren Sie die Spaltenbreiten und Zeilenhöhen.
4. Fügen Sie eine Tabelle mit der Methode [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---) hinzu.
5. Klonen Sie die erforderlichen Zeilen.
6. Klonen Sie die erforderlichen Spalten.
7. Speichern Sie die geänderte Präsentation.

Das Beispiel benötigt `Test.pptx` mit mindestens einer Folie. Es erstellt eine Tabelle mit drei Spalten und fünf Zeilen, wobei die Abmessungen in Punkten angegeben sind. Es hängt Kopien der ersten Zeile und Spalte an und fügt Kopien der zweiten Zeile und Spalte an Index 3 (der vierten Position) ein. Die resultierende Tabelle hat sieben Zeilen und fünf Spalten. Das Argument `false` deaktiviert das Klonen in benachbarte zusammengeführte Zeilen oder Spalten; diese Tabelle hat keine zusammengeführten Zellen.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("Test.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    table.getRows().addClone(table.getRows().get_Item(0), false);

    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);

    presentation.save("table_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Entfernen einer Zeile oder Spalte aus einer Tabelle**

Entfernen Sie Zeilen oder Spalten, die in einer Tabelle nicht mehr benötigt werden. Das Entfernen eines Elements verschiebt die Indizes der nachfolgenden Zeilen oder Spalten.

1. Erstellen Sie eine Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Greifen Sie auf die erste Folie zu.
3. Definieren Sie die Spaltenbreiten und Zeilenhöhen.
4. Fügen Sie eine Tabelle mit der Methode [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---) hinzu.
5. Entfernen Sie die zweite Zeile und die zweite Spalte.
6. Speichern Sie die geänderte Präsentation.

Dieses Beispiel erstellt eine 3 × 3‑Tabelle und entfernt die Zeile und Spalte an Index 1, sodass eine 2 × 2‑Tabelle in `TestTable_out.pptx` verbleibt. Die Abmessungen sind in Punkten angegeben. Das Argument `false` deaktiviert das Entfernen benachbarter zusammengeführter Zeilen oder Spalten; diese Tabelle hat keine zusammengeführten Zellen.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 50, 30]);
    const rowHeights = java.newArray("double", [30, 50, 30]);
    const table = slide.getShapes().addTable(100, 100, columnWidths, rowHeights);

    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);

    presentation.save("TestTable_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Textformatierung auf Zeilenebene der Tabelle festlegen**

Wenden Sie Textformatierung auf eine gesamte Zeile an, um die Konsistenz der Zellen zu gewährleisten. Sie können Schriftarteigenschaften, Absatzformatierung und Textausrichtung festlegen, ohne jede Zelle einzeln zu formatieren.

1. Laden Sie die Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Greifen Sie auf die Tabelle auf der ersten Folie zu.
3. Verwenden Sie [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) für die erste Zeile.
4. Verwenden Sie [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) und [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) für die erste Zeile.
5. Verwenden Sie [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) für die zweite Zeile.
6. Speichern Sie die geänderte Präsentation.

Das Beispiel benötigt `table.pptx` mit einer Tabelle als erstes Shape auf der ersten Folie und mindestens zwei Zeilen. Es wendet 25‑Punkt‑Text, Rechtsbündigkeit und einen 20‑Punkt‑rechten Absatzabstand auf die erste Zeile an und setzt dann vertikalen Text in der zweiten Zeile.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);

    const portionFormat = new slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.getRows().get_Item(0).setTextFormat(portionFormat);

    const paragraphFormat = new slides.ParagraphFormat();
    paragraphFormat.setAlignment(slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getRows().get_Item(0).setTextFormat(paragraphFormat);

    const textFrameFormat = new slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(slides.TextVerticalType.Vertical));
    table.getRows().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("row_formatting.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Textformatierung auf Spaltenebene der Tabelle festlegen**

Wenden Sie Textformatierung auf eine gesamte Spalte an, um die Konsistenz der Zellen zu gewährleisten. Sie können Schriftarteigenschaften, Absatzformatierung und Textausrichtung festlegen, ohne jede Zelle einzeln zu formatieren.

1. Laden Sie die Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Greifen Sie auf die Tabelle auf der ersten Folie zu.
3. Verwenden Sie [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) für die erste Spalte.
4. Verwenden Sie [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) und [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) für die erste Spalte.
5. Verwenden Sie [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) für die zweite Spalte.
6. Speichern Sie die geänderte Präsentation.

Das Beispiel benötigt `table.pptx` mit einer Tabelle als erstes Shape auf der ersten Folie und mindestens zwei Spalten. Es wendet 25‑Punkt‑Text, Rechtsbündigkeit und einen 20‑Punkt‑rechten Absatzabstand auf die erste Spalte an und setzt dann vertikalen Text in der zweiten Spalte.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);

    const portionFormat = new slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.getColumns().get_Item(0).setTextFormat(portionFormat);

    const paragraphFormat = new slides.ParagraphFormat();
    paragraphFormat.setAlignment(slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    const textFrameFormat = new slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(slides.TextVerticalType.Vertical));
    table.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("column_formatting.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tabellenstil‑Eigenschaften abrufen**

Verwenden Sie die Methode [getStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getStylePreset--) , um das auf eine Tabelle angewendete Preset abzurufen und es auf einer anderen Tabelle wiederzuverwenden. Damit wird das Preset identifiziert statt einzelner Zellformatierungs‑Overrides.

Das Beispiel erstellt eine Tabelle, wendet [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tablestylepreset/#DarkStyle1) an und liest das Preset zurück. Es gibt den Ganzzahlwert aus, der `DarkStyle1` entspricht, und speichert die Tabelle in `table.pptx`.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 150]);
    const rowHeights = java.newArray("double", [5, 5, 5]);
    const table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(slides.TableStylePreset.DarkStyle1);

    const stylePreset = table.getStylePreset();
    console.log(stylePreset);

    presentation.save("table.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Kann ich PowerPoint‑Designs/‑Stile auf eine bereits erstellte Tabelle anwenden?**  
Ja. Die Tabelle erbt das Folien‑/Layout‑/Master‑Theme, und Sie können nach wie vor Füllungen, Rahmen und Textfarben über diesem Theme hinweg überschreiben.

**Kann ich Tabellzeilen wie in Excel sortieren?**  
Nein, Aspose.Slides‑Tabellen besitzen keine integrierte Sortierung oder Filter. Sortieren Sie Ihre Daten zuerst im Speicher und füllen Sie dann die Tabellzeilen in dieser Reihenfolge neu.

**Kann ich banded (gestreifte) Spalten haben und dabei benutzerdefinierte Farben für bestimmte Zellen beibehalten?**  
Ja. Schalten Sie banded Spalten ein und überschreiben Sie dann bestimmte Zellen mit lokaler Formatierung; die Zellenformatierung hat Vorrang vor dem Tabellenstil.