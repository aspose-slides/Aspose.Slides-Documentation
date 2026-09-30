---
title: Verwalten von Zeilen und Spalten in PowerPoint-Tabellen mit C++
linktitle: Zeilen und Spalten
type: docs
weight: 20
url: /de/cpp/manage-rows-and-columns/
keywords:
- Tabellenzeile
- Tabellenspalte
- erste Zeile
- Tabellenkopf
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
- C++
- Aspose.Slides
description: "Verwalten Sie Tabellenzeilen und -spalten in PowerPoint mit Aspose.Slides für C++ und beschleunigen Sie die Bearbeitung von Präsentationen und Datenaktualisierungen."
---
## **Einleitung**

Aspose.Slides for C++ ermöglicht es Ihnen, Tabellenstruktur und -formatierung in PowerPoint‑Präsentationen über die Klasse [Tabelle](https://reference.aspose.com/slides/cpp/aspose.slides/table/) und die Schnittstelle [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) zu verwalten. Sie können eine Header‑Zeile festlegen, Zeilen und Spalten klonen oder entfernen und Textformatierung auf eine gesamte Zeile oder Spalte anwenden.

Dieser Artikel erklärt diese Vorgänge anhand von C++‑Beispielen. Er zeigt auch, wie man das Stil‑Preset einer Tabelle abruft, um es wiederzuverwenden. Zeilen‑ und Spaltenindizes einer Tabelle beginnen bei Null.

## **Steuerung der Zeilenhöhe**

Verwenden Sie [IRow::set_MinimalHeight](https://reference.aspose.com/slides/cpp/aspose.slides/irow/set_minimalheight/), um die minimale Höhe einer Zeile in Punkten festzulegen. Es ist eine Untergrenze, keine feste Höhe. [IRow::get_Height](https://reference.aspose.com/slides/cpp/aspose.slides/irow/get_height/) gibt die tatsächliche Höhe zurück; dieser Wert kann nicht direkt gesetzt werden. Greifen Sie über [ITable::get_Rows](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_rows/) auf die Zeile zu.

Das Beispiel lädt [row-height-input.pptx](row-height-input.pptx), das eine Tabelle als erste Form auf der ersten Folie enthält. Die erste Zeile beginnt bei 70 Punkten. Die Zellen verwenden 18‑Punkt‑Arial‑Text, Zeilenumbruch und 6‑Punkt‑Oben‑ und -Unten‑Abstände; der längere Text in der zweiten Spalte wird über mehrere Zeilen umgebrochen. Das Beispiel erhöht die Mindesthöhe auf 100 Punkte, dann reduziert sie auf 20 Punkte, gibt nach jeder Änderung die tatsächliche Höhe aus und speichert beide Ergebnisse.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IRow.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"row-height-input.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));
auto row = table->get_Rows()->idx_get(0);

row->set_MinimalHeight(100);
Console::WriteLine(u"Increased: minimum = {0:F1}, actual = {1:F1} pt", row->get_MinimalHeight(), row->get_Height());
presentation->Save(u"row-height-increased.pptx", SaveFormat::Pptx);

row->set_MinimalHeight(20);
Console::WriteLine(u"Decreased: minimum = {0:F1}, actual = {1:F1} pt", row->get_MinimalHeight(), row->get_Height());
presentation->Save(u"row-height-decreased.pptx", SaveFormat::Pptx);
```

Mit der bereitgestellten Präsentation fügt das Erhöhen der Mindesthöhe der Zeile zusätzlichen Raum hinzu. Das Reduzieren entfernt diesen zusätzlichen Raum, aber die tatsächliche Höhe bleibt größer als 20 Punkte, weil Text und Zellabstände mehr Platz benötigen. Das alleinige Reduzieren der Mindesthöhe kann die Zeile nicht unter den von ihrem Inhalt benötigten Raum zwingen.

Mehrere Faktoren beeinflussen die tatsächliche Höhe:

- **Text und Schriftgröße:** Längerer Text, explizite Zeilenumbrüche oder eine größere Schriftart können mehr vertikalen Platz erfordern.
- **Umbruch und Spaltenbreite:** Bei aktiviertem Umbruch kann das Reduzieren der Spaltenbreite mit [IColumn::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/icolumn/set_width/) mehr Zeilen erzeugen. Eine breitere Spalte kann den vertikalen Platzbedarf reduzieren.
- **Zellabstände:** [ICell::set_MarginTop](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_margintop/) und [ICell::set_MarginBottom](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginbottom/) steuern die Abstände, die vertikalen Raum hinzufügen. [ICell::set_MarginLeft](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginleft/) und [ICell::set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginright/) steuern die Abstände, die die für Text verfügbare Breite verringern und zusätzlichen Umbruch verursachen können.

Für diese Tabelle ohne zusammengeführte Zellen bestimmt die Zelle, die am meisten vertikalen Raum benötigt, die inhaltlich getriebene Untergrenze für die gesamte Zeile. Um die Zeile zu verkürzen, müssen Sie ggf. den Text kürzen, die Schriftgröße oder Abstände reduzieren oder eine Spalte verbreitern.

Die untenstehenden Bilder zeigen dieselbe Tabelle im gleichen Maßstab. In dem hier gezeigten .NET‑Referenzlauf betrugen die tatsächlichen Höhen 70, 100 und 55,2 Punkte: die letzte Zeile blieb höher als ihr Minimum von 20 Punkten. Exakte Textmessungen können je nach in Ihrer Umgebung verfügbaren Schriftarten variieren. Laden Sie die gespeicherten Ergebnisse herunter: [erhöhtes Minimum](row-height-increased.pptx) und [verringertes Minimum](row-height-decreased.pptx).

| Original: Minimum 70 pt, tatsächlich 70 pt | Erhöht: Minimum 100 pt, tatsächlich 100 pt | Verringert: Minimum 20 pt, tatsächlich 55,2 pt |
| --- | --- | --- |
| ![Originaltabelle mit einer ersten Zeile von 70 Punkten.](row-height-before.png) | ![Tabelle nach Erhöhen des Minimalwerts der ersten Zeile auf 100 Punkte.](row-height-increased.png) | ![Tabelle nach Verringern des Minimalwerts der ersten Zeile auf 20 Punkte; umbrochener Text hält die Zeile höher als das Minimum.](row-height-decreased.png) |

## **Erste Zeile als Header festlegen**

Verwenden Sie die Methode [set_FirstRow](https://reference.aspose.com/slides/cpp/aspose.slides/itable/set_firstrow/), um die erste Zeile für die Header‑Formatierung zu markieren. Ihr Aussehen hängt vom auf die Tabelle angewendeten Tabellenvorlagestil ab.

1. Laden Sie die Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Greifen Sie auf die erste Folie zu.
3. Greifen Sie auf die Tabelle zu, die als erste Form auf der Folie gespeichert ist.
4. Aktivieren Sie die Header‑Formatierung für deren erste Zeile.
5. Speichern Sie die modifizierte Präsentation.

Das Beispiel benötigt `table.pptx` mit einer Tabelle als erste Form auf der ersten Folie. Es aktiviert die Header‑Formatierung für die erste Zeile und speichert `First_row_header.pptx`.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));
table->set_FirstRow(true);

presentation->Save(u"First_row_header.pptx", SaveFormat::Pptx);
```

## **Tabellenzeile oder -spalte klonen**

Klonen Sie Zeilen oder Spalten, um deren Inhalt und Formatierung wiederzuverwenden. Sie können eine Kopie am Ende der Tabelle anhängen oder an einer bestimmten Position einfügen.

1. Laden Sie die Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Greifen Sie auf die erste Folie zu.
3. Definieren Sie die Spaltenbreiten und Zeilenhöhen.
4. Fügen Sie mit der Methode [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) eine Tabelle hinzu.
5. Klonen Sie die erforderlichen Zeilen.
6. Klonen Sie die erforderlichen Spalten.
7. Speichern Sie die modifizierte Präsentation.

Das Beispiel benötigt `Test.pptx` mit mindestens einer Folie. Es erzeugt eine Tabelle mit drei Spalten und fünf Zeilen, wobei die Abmessungen in Punkten angegeben sind. Es hängt Kopien der ersten Zeile und Spalte an und fügt Kopien der zweiten Zeile und Spalte an Index 3 (der vierten Position) ein. Die resultierende Tabelle hat sieben Zeilen und fünf Spalten. Das Argument `false` deaktiviert das Klonen in benachbarte zusammengeführte Zeilen oder Spalten; diese Tabelle enthält keine zusammengeführten Zellen.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Table/ICell.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Test.pptx");
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 50, 50, 50 });
auto rowHeights = MakeArray<double>({ 50, 30, 30, 30, 30 });
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

table->idx_get(0, 0)->get_TextFrame()->set_Text(u"Row 1 Cell 1");
table->idx_get(1, 0)->get_TextFrame()->set_Text(u"Row 1 Cell 2");
table->get_Rows()->AddClone(table->get_Rows()->idx_get(0), false);

table->idx_get(0, 1)->get_TextFrame()->set_Text(u"Row 2 Cell 1");
table->idx_get(1, 1)->get_TextFrame()->set_Text(u"Row 2 Cell 2");
table->get_Rows()->InsertClone(3, table->get_Rows()->idx_get(1), false);

table->get_Columns()->AddClone(table->get_Columns()->idx_get(0), false);
table->get_Columns()->InsertClone(3, table->get_Columns()->idx_get(1), false);

presentation->Save(u"table_out.pptx", SaveFormat::Pptx);
```

## **Zeile oder Spalte aus einer Tabelle entfernen**

Entfernen Sie Zeilen oder Spalten, die in einer Tabelle nicht mehr benötigt werden. Das Entfernen eines Elements verschiebt die Indizes der nachfolgenden Zeilen bzw. Spalten.

1. Erstellen Sie eine Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Greifen Sie auf die erste Folie zu.
3. Definieren Sie die Spaltenbreiten und Zeilenhöhen.
4. Fügen Sie mit der Methode [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) eine Tabelle hinzu.
5. Entfernen Sie die zweite Zeile und die zweite Spalte.
6. Speichern Sie die modifizierte Präsentation.

Dieses Beispiel erstellt eine 3 × 3‑Tabelle und entfernt die Zeile und Spalte an Index 1, sodass eine 2 × 2‑Tabelle in `TestTable_out.pptx` verbleibt. Die Abmessungen sind in Punkten angegeben. Das Argument `false` deaktiviert das Entfernen benachbarter zusammengeführter Zeilen oder Spalten; diese Tabelle enthält keine zusammengeführten Zellen.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IColumnCollection.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 100, 50, 30 });
auto rowHeights = MakeArray<double>({ 30, 50, 30 });
auto table = slide->get_Shapes()->AddTable(100, 100, columnWidths, rowHeights);

table->get_Rows()->RemoveAt(1, false);
table->get_Columns()->RemoveAt(1, false);

presentation->Save(u"TestTable_out.pptx", SaveFormat::Pptx);
```

## **Textformatierung auf Zeilenebene festlegen**

Wenden Sie Textformatierung auf eine gesamte Zeile an, um deren Zellen konsistent zu halten. Sie können Schriftarteigenschaften, Absatzformatierung und Textausrichtung festlegen, ohne jede Zelle einzeln zu formatieren.

1. Laden Sie die Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Greifen Sie auf die Tabelle auf der ersten Folie zu.
3. Setzen Sie die Schriftgröße mit [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) für die erste Zeile.
4. Setzen Sie die Ausrichtung und den rechten Absatzabstand mit [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) und [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) für die erste Zeile.
5. Setzen Sie die Textausrichtung mit [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) für die zweite Zeile.
6. Speichern Sie die modifizierte Präsentation.

Das Beispiel benötigt `table.pptx` mit einer Tabelle als erste Form auf der ersten Folie und mindestens zwei Zeilen. Es wendet 25‑Punkt‑Text, Rechtsbündigkeit und einen 20‑Punkt‑rechten Absatzabstand auf die erste Zeile an und setzt dann vertikalen Text in der zweiten Zeile.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/PortionFormat.h>
#include <DOM/ParagraphFormat.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextFrameFormat.h>
#include <DOM/TextVerticalType.h>
#include <DOM/Table/IRow.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto portionFormat = MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25);
table->get_Rows()->idx_get(0)->SetTextFormat(portionFormat);

auto paragraphFormat = MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20);
table->get_Rows()->idx_get(0)->SetTextFormat(paragraphFormat);

auto textFrameFormat = MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
table->get_Rows()->idx_get(1)->SetTextFormat(textFrameFormat);

presentation->Save(u"row_formatting.pptx", SaveFormat::Pptx);
```

## **Textformatierung auf Spaltenebene festlegen**

Wenden Sie Textformatierung auf eine gesamte Spalte an, um deren Zellen konsistent zu halten. Sie können Schriftarteigenschaften, Absatzformatierung und Textausrichtung festlegen, ohne jede Zelle einzeln zu formatieren.

1. Laden Sie die Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Greifen Sie auf die Tabelle auf der ersten Folie zu.
3. Setzen Sie die Schriftgröße mit [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) für die erste Spalte.
4. Setzen Sie die Ausrichtung und den rechten Absatzabstand mit [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) und [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) für die erste Spalte.
5. Setzen Sie die Textausrichtung mit [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) für die zweite Spalte.
6. Speichern Sie die modifizierte Präsentation.

Das Beispiel benötigt `table.pptx` mit einer Tabelle als erste Form auf der ersten Folie und mindestens zwei Spalten. Es wendet 25‑Punkt‑Text, Rechtsbündigkeit und einen 20‑Punkt‑rechten Absatzabstand auf die erste Spalte an und setzt dann vertikalen Text in der zweiten Spalte.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/PortionFormat.h>
#include <DOM/ParagraphFormat.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextFrameFormat.h>
#include <DOM/TextVerticalType.h>
#include <DOM/Table/IColumn.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto portionFormat = MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25);
table->get_Columns()->idx_get(0)->SetTextFormat(portionFormat);

auto paragraphFormat = MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20);
table->get_Columns()->idx_get(0)->SetTextFormat(paragraphFormat);

auto textFrameFormat = MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
table->get_Columns()->idx_get(1)->SetTextFormat(textFrameFormat);

presentation->Save(u"column_formatting.pptx", SaveFormat::Pptx);
```

## **Tabellenstil‑Eigenschaften abrufen**

Verwenden Sie die Methode [get_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_stylepreset/), um das auf eine Tabelle angewendete Preset abzurufen und es auf einer anderen Tabelle wiederzuverwenden. Dies identifiziert das Preset statt einzelner Zellformatierungs‑Überschreibungen.

Das Beispiel erstellt eine Tabelle, wendet [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/cpp/aspose.slides/tablestylepreset/) an und liest das Preset wieder aus. Es gibt `DarkStyle1` aus und speichert die Tabelle in `table.pptx`.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <DOM/TableStylePreset.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 100, 150 });
auto rowHeights = MakeArray<double>({ 5, 5, 5 });
auto table = slide->get_Shapes()->AddTable(10, 10, columnWidths, rowHeights);
table->set_StylePreset(TableStylePreset::DarkStyle1);

Console::WriteLine(u"{0}", table->get_StylePreset());

presentation->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Häufig gestellte Fragen**

**Kann ich PowerPoint-Themen/–Stile auf eine bereits erstellte Tabelle anwenden?**

Ja. Die Tabelle erbt das Folien‑/Layout‑/Master‑Thema, und Sie können dennoch Füllungen, Rahmen und Textfarben über diesem Thema überschreiben.

**Kann ich Tabellenzeilen wie in Excel sortieren?**

Nein, Aspose.Slides‑Tabellen besitzen keine integrierte Sortier‑ oder Filterfunktion. Sortieren Sie Ihre Daten zuerst im Speicher und fügen Sie dann die Tabellenzeilen in dieser Reihenfolge wieder ein.

**Kann ich banded (gestreifte) Spalten haben und gleichzeitig benutzerdefinierte Farben für bestimmte Zellen beibehalten?**

Ja. Aktivieren Sie gestreifte Spalten und überschreiben Sie dann einzelne Zellen mit lokaler Formatierung; die Formatierung auf Zellebene hat Vorrang vor dem Tabellenstil.