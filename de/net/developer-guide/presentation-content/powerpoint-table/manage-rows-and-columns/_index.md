---
title: Verwalten von Zeilen und Spalten in PowerPoint-Tabellen in .NET
linktitle: Zeilen und Spalten
type: docs
weight: 20
url: /de/net/manage-rows-and-columns/
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
- .NET
- C#
- Aspose.Slides
description: "Verwalten Sie Tabellenzeilen und -spalten in PowerPoint mit Aspose.Slides für .NET und beschleunigen Sie die Bearbeitung von Präsentationen und Datenaktualisierungen."
---
## **Einführung**

Aspose.Slides für .NET ermöglicht die Verwaltung von Tabellenstruktur und -formatierung in PowerPoint‑Präsentationen über die Klasse [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) und das Interface [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/). Sie können eine Kopfzeilenzeile festlegen, Zeilen und Spalten klonen oder entfernen und Textformatierung auf eine gesamte Zeile oder Spalte anwenden.

Dieser Artikel erklärt diese Vorgänge mit C#‑Beispielen. Er zeigt außerdem, wie Sie das Stil‑Preset einer Tabelle abrufen können, um es erneut zu verwenden. Zeilen‑ und Spaltenindizes einer Tabelle beginnen bei Null.

## **Zeilenhöhe steuern**

Verwenden Sie [IRow.MinimalHeight](https://reference.aspose.com/slides/net/aspose.slides/irow/minimalheight/), um die minimale Höhe einer Zeile in Punkt festzulegen. Dies ist eine Untergrenze, keine feste Höhe. [IRow.Height](https://reference.aspose.com/slides/net/aspose.slides/irow/height/) gibt die tatsächliche Höhe zurück und ist schreibgeschützt. Greifen Sie über [ITable.Rows](https://reference.aspose.com/slides/net/aspose.slides/itable/rows/) auf die Zeile zu.

Das Beispiel lädt [row-height-input.pptx](row-height-input.pptx), das auf der ersten Folie eine Tabelle als erstes Shape enthält. Die erste Zeile beginnt bei 70 Punkt. Die Zellen verwenden 18‑Punkt‑Arial‑Text, Zeilenumbruch und 6‑Punkt‑Abstand oben und unten; der längere Text in der zweiten Spalte wird auf mehrere Zeilen umbrochen. Das Beispiel erhöht die Mindesthöhe auf 100 Punkt, reduziert sie anschließend auf 20 Punkt, gibt nach jeder Änderung die tatsächliche Höhe aus und speichert beide Ergebnisse.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("row-height-input.pptx");
var table = (ITable)presentation.Slides[0].Shapes[0];
var row = table.Rows[0];

row.MinimalHeight = 100;
Console.WriteLine($"Increased: minimum = {row.MinimalHeight:F1}, actual = {row.Height:F1} pt");
presentation.Save("row-height-increased.pptx", SaveFormat.Pptx);

row.MinimalHeight = 20;
Console.WriteLine($"Decreased: minimum = {row.MinimalHeight:F1}, actual = {row.Height:F1} pt");
presentation.Save("row-height-decreased.pptx", SaveFormat.Pptx);
```

Bei der mitgelieferten Präsentation fügt das Erhöhen der Mindesthöhe der Zeile Abstand hinzu. Das Verringern entfernt diesen zusätzlichen Abstand, aber die tatsächliche Höhe bleibt größer als 20 Punkt, weil Text und Zellenränder mehr Platz benötigen. Das bloße Reduzieren der Mindesthöhe kann die Zeile nicht unter den von ihrem Inhalt benötigten Raum zwingen.

Mehrere Faktoren beeinflussen die tatsächliche Höhe:

- **Text und Schriftgröße:** Längerer Text, explizite Zeilenumbrüche oder eine größere Schrift können mehr vertikalen Platz benötigen.
- **Umbruch und Spaltenbreite:** Bei aktiviertem Umbruch kann eine engere [IColumn.Width](https://reference.aspose.com/slides/net/aspose.slides/icolumn/width/) mehr Zeilen erzeugen. Eine breitere Spalte kann den vertikalen Platzbedarf verringern.
- **Zellränder:** [ICell.MarginTop](https://reference.aspose.com/slides/net/aspose.slides/icell/margintop/) und [ICell.MarginBottom](https://reference.aspose.com/slides/net/aspose.slides/icell/marginbottom/) fügen vertikalen Raum hinzu. [ICell.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/icell/marginleft/) und [ICell.MarginRight](https://reference.aspose.com/slides/net/aspose.slides/icell/marginright/) verkleinern die für Text verfügbare Breite und können zusätzlichen Umbruch verursachen.

Für diese Tabelle ohne zusammengeführte Zellen bestimmt die Zelle, die den meisten vertikalen Raum benötigt, die inhaltlich getriebene Untergrenze für die gesamte Zeile. Um die Zeile zu verkürzen, müssen Sie möglicherweise den Text kürzen, die Schriftgröße oder die Ränder reduzieren oder eine Spalte verbreitern.

Die Abbildungen unten zeigen dieselbe Tabelle im gleichen Maßstab. In diesem Durchlauf betrugen die tatsächlichen Höhen 70, 100 und 55.2 Punkt: Die letzte Zeile blieb größer als ihr Minimum von 20 Punkt. Exakte Textmessungen können je nach in Ihrer Umgebung verfügbaren Schriften variieren. Laden Sie die gespeicherten Ergebnisse herunter: [erhöhtes Minimum](row-height-increased.pptx) und [reduziertes Minimum](row-height-decreased.pptx).

| Original: Minimum 70 pt, tatsächliche 70 pt | Erhöht: Minimum 100 pt, tatsächliche 100 pt | Reduziert: Minimum 20 pt, tatsächliche 55.2 pt |
| --- | --- | --- |
| ![Originaltabelle mit einer ersten Zeile von 70 Punkt.](row-height-before.png) | ![Tabelle nach Erhöhen des Minimums der ersten Zeile auf 100 Punkt.](row-height-increased.png) | ![Tabelle nach Reduzieren des Minimums der ersten Zeile auf 20 Punkt; umbrochener Text hält die Zeile höher als das Minimum.](row-height-decreased.png) |

## **Erste Zeile als Kopfzeile festlegen**

Verwenden Sie die Eigenschaft [FirstRow](https://reference.aspose.com/slides/net/aspose.slides/itable/firstrow/) , um die erste Zeile für die Kopfzeilenformatierung zu kennzeichnen. Ihr Aussehen hängt vom auf die Tabelle angewendeten Tabellenstil ab.

1. Laden Sie die Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Greifen Sie auf die erste Folie zu.
3. Greifen Sie auf die Tabelle zu, die als erstes Shape auf der Folie gespeichert ist.
4. Aktivieren Sie die Kopfzeilenformatierung für deren erste Zeile.
5. Speichern Sie die geänderte Präsentation.

Das Beispiel erfordert `table.pptx` mit einer Tabelle als erstes Shape auf der ersten Folie. Es aktiviert die Kopfzeilenformatierung für die erste Zeile und speichert `First_row_header.pptx`.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];
table.FirstRow = true;

presentation.Save("First_row_header.pptx", SaveFormat.Pptx);
```

## **Tabellenzeile oder -spalte klonen**

Klonen Sie Zeilen oder Spalten, um deren Inhalt und Formatierung wiederzuverwenden. Sie können eine Kopie am Ende der Tabelle anhängen oder an einer bestimmten Position einfügen.

1. Laden Sie die Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Greifen Sie auf die erste Folie zu.
3. Definieren Sie die Spaltenbreiten und Zeilenhöhen.
4. Fügen Sie eine Tabelle mit der Methode [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) hinzu.
5. Klonen Sie die gewünschten Zeilen.
6. Klonen Sie die gewünschten Spalten.
7. Speichern Sie die geänderte Präsentation.

Das Beispiel erfordert `Test.pptx` mit mindestens einer Folie. Es erstellt eine Tabelle mit drei Spalten und fünf Zeilen, wobei die Abmessungen in Punkten angegeben sind. Es hängt Kopien der ersten Zeile und Spalte an und fügt Kopien der zweiten Zeile und Spalte an Index 3 (der vierten Position) ein. Die resultierende Tabelle hat sieben Zeilen und fünf Spalten. Das Argument `false` deaktiviert das Klonen in benachbarte zusammengeführte Zeilen oder Spalten; diese Tabelle enthält keine zusammengeführten Zellen.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Test.pptx");
var slide = presentation.Slides[0];

var columnWidths = new double[] { 50, 50, 50 };
var rowHeights = new double[] { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table[0, 0].TextFrame.Text = "Row 1 Cell 1";
table[1, 0].TextFrame.Text = "Row 1 Cell 2";
table.Rows.AddClone(table.Rows[0], false);

table[0, 1].TextFrame.Text = "Row 2 Cell 1";
table[1, 1].TextFrame.Text = "Row 2 Cell 2";
table.Rows.InsertClone(3, table.Rows[1], false);

table.Columns.AddClone(table.Columns[0], false);
table.Columns.InsertClone(3, table.Columns[1], false);

presentation.Save("table_out.pptx", SaveFormat.Pptx);
```

## **Zeile oder Spalte aus einer Tabelle entfernen**

Entfernen Sie Zeilen oder Spalten, die in einer Tabelle nicht mehr benötigt werden. Das Entfernen eines Elements verschiebt die Indizes der nachfolgenden Zeilen oder Spalten.

1. Erstellen Sie eine Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Greifen Sie auf die erste Folie zu.
3. Definieren Sie die Spaltenbreiten und Zeilenhöhen.
4. Fügen Sie eine Tabelle mit der Methode [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) hinzu.
5. Entfernen Sie die zweite Zeile und die zweite Spalte.
6. Speichern Sie die geänderte Präsentation.

Dieses Beispiel erstellt eine 3 × 3‑Tabelle und entfernt die Zeile und Spalte an Index 1, sodass eine 2 × 2‑Tabelle in `TestTable_out.pptx` verbleibt. Die Abmessungen sind in Punkten angegeben. Das Argument `false` deaktiviert das Entfernen benachbarter zusammengeführter Zeilen oder Spalten; diese Tabelle enthält keine zusammengeführten Zellen.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 100, 50, 30 };
var rowHeights = new double[] { 30, 50, 30 };
var table = slide.Shapes.AddTable(100, 100, columnWidths, rowHeights);

table.Rows.RemoveAt(1, false);
table.Columns.RemoveAt(1, false);

presentation.Save("TestTable_out.pptx", SaveFormat.Pptx);
```

## **Textformatierung auf Zeilenebene festlegen**

Wenden Sie Textformatierung auf eine ganze Zeile an, um die Zellen einheitlich zu halten. Sie können Schriftarteigenschaften, Absatzformatierung und Textrichtung festlegen, ohne jede Zelle einzeln zu formatieren.

1. Laden Sie die Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Greifen Sie auf die Tabelle auf der ersten Folie zu.
3. Setzen Sie [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) für die erste Zeile.
4. Setzen Sie [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) und [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) für die erste Zeile.
5. Setzen Sie [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) für die zweite Zeile.
6. Speichern Sie die geänderte Präsentation.

Das Beispiel erfordert `table.pptx` mit einer Tabelle als erstes Shape auf der ersten Folie und mindestens zwei Zeilen. Es wendet 25‑Punkt‑Text, rechtsbündige Ausrichtung und einen rechten Absatzabstand von 20 Punkt auf die erste Zeile an und setzt dann vertikalen Text in der zweiten Zeile.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat { FontHeight = 25 };
table.Rows[0].SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat { Alignment = TextAlignment.Right, MarginRight = 20 };
table.Rows[0].SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat { TextVerticalType = TextVerticalType.Vertical };
table.Rows[1].SetTextFormat(textFrameFormat);

presentation.Save("row_formatting.pptx", SaveFormat.Pptx);
```

## **Textformatierung auf Spaltenebene festlegen**

Wenden Sie Textformatierung auf eine ganze Spalte an, um die Zellen einheitlich zu halten. Sie können Schriftarteigenschaften, Absatzformatierung und Textrichtung festlegen, ohne jede Zelle einzeln zu formatieren.

1. Laden Sie die Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Greifen Sie auf die Tabelle auf der ersten Folie zu.
3. Setzen Sie [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) für die erste Spalte.
4. Setzen Sie [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) und [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) für die erste Spalte.
5. Setzen Sie [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) für die zweite Spalte.
6. Speichern Sie die geänderte Präsentation.

Das Beispiel erfordert `table.pptx` mit einer Tabelle als erstes Shape auf der ersten Folie und mindestens zwei Spalten. Es wendet 25‑Punkt‑Text, rechtsbündige Ausrichtung und einen rechten Absatzabstand von 20 Punkt auf die erste Spalte an und setzt dann vertikalen Text in der zweiten Spalte.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat { FontHeight = 25 };
table.Columns[0].SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat { Alignment = TextAlignment.Right, MarginRight = 20 };
table.Columns[0].SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat { TextVerticalType = TextVerticalType.Vertical };
table.Columns[1].SetTextFormat(textFrameFormat);

presentation.Save("column_formatting.pptx", SaveFormat.Pptx);
```

## **Tabellenstil‑Eigenschaften abrufen**

Verwenden Sie die Eigenschaft [StylePreset](https://reference.aspose.com/slides/net/aspose.slides/itable/stylepreset/), um das auf eine Tabelle angewandte Preset abzurufen und es auf einer anderen Tabelle wiederzuverwenden. Dadurch wird das Preset identifiziert statt einzelner Zellformatierungs‑Überschreibungen.

Das Beispiel erstellt eine Tabelle, wendet [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/net/aspose.slides/tablestylepreset/) an und liest das Preset wieder aus. Es gibt `DarkStyle1` aus und speichert die Tabelle in `table.pptx`.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 100, 150 };
var rowHeights = new double[] { 5, 5, 5 };
var table = slide.Shapes.AddTable(10, 10, columnWidths, rowHeights);
table.StylePreset = TableStylePreset.DarkStyle1;

Console.WriteLine(table.StylePreset);

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Kann ich PowerPoint‑Designs/‑Stile auf eine bereits erstellte Tabelle anwenden?**

Ja. Die Tabelle erbt das Design der Folie/ des Layouts/ des Masters und Sie können trotzdem Füllungen, Rahmen und Textfarben darüber hinaus überschreiben.

**Kann ich Tabellenzeilen wie in Excel sortieren?**

Nein, Aspose.Slides‑Tabellen verfügen nicht über integrierte Sortier‑ oder Filterfunktionen. Sortieren Sie Ihre Daten zuerst im Speicher und befüllen Sie dann die Tabellenzeilen in dieser Reihenfolge erneut.

**Kann ich gestreifte Spalten haben und gleichzeitig benutzerdefinierte Farben für bestimmte Zellen beibehalten?**

Ja. Aktivieren Sie gestreifte Spalten und überschreiben Sie anschließend bestimmte Zellen mit lokaler Formatierung; die Zellenformatierung hat Vorrang vor dem Tabellenstil.