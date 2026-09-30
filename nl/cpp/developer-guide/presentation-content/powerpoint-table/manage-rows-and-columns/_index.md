---
title: Beheer rijen en kolommen in PowerPoint‑tabellen met C++
linktitle: Rijen en kolommen
type: docs
weight: 20
url: /nl/cpp/manage-rows-and-columns/
keywords:
- tabelrij
- tabelkolom
- eerste rij
- tabelkop
- rij klonen
- kolom klonen
- rij kopiëren
- kolom kopiëren
- rij verwijderen
- kolom verwijderen
- rijtekstopmaak
- kolomtekstopmaak
- tabelstijl
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Beheer tabelrijen en -kolommen in PowerPoint met Aspose.Slides voor C++ en versnel het bewerken van presentaties en het bijwerken van gegevens."
---
## **Inleiding**

Aspose.Slides for C++ laat u tabelstructuur en opmaak in PowerPoint‑presentaties beheren via de [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/) klasse en de [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) interface. U kunt een header‑rij aanwijzen, rijen en kolommen klonen of verwijderen, en tekstopmaak toepassen op een hele rij of kolom.

Dit artikel legt deze bewerkingen uit met C++‑voorbeelden. Het laat ook zien hoe u een tabel‑stijl‑preset kunt ophalen zodat u deze opnieuw kunt gebruiken. Rijen‑ en kolom‑indices in een tabel zijn nul‑gebaseerd.

## **Rijhoogte regelen**

Gebruik [IRow::set_MinimalHeight](https://reference.aspose.com/slides/cpp/aspose.slides/irow/set_minimalheight/) om de minimale hoogte van een rij in punten in te stellen. Het is een ondergrens, geen vaste hoogte. [IRow::get_Height](https://reference.aspose.com/slides/cpp/aspose.slides/irow/get_height/) geeft de werkelijke hoogte terug; deze waarde kan niet rechtstreeks worden ingesteld. Toegang tot de rij via [ITable::get_Rows](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_rows/).

Het voorbeeld laadt [row-height-input.pptx](row-height-input.pptx), dat een tabel bevat als het eerste object op de eerste dia. De eerste rij begint op 70 punten. De cellen gebruiken 18‑punt Arial‑tekst, omloop en 6‑punt marges boven en onder; de langere tekst in de tweede kolom wordt op meerdere regels weergegeven. Het voorbeeld verhoogt het minimum naar 100 punten, verlaagt het vervolgens naar 20 punten, drukt de werkelijke hoogte na elke wijziging af en slaat beide resultaten op.

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

Met de meegeleverde presentatie voegt het verhogen van het minimum ruimte toe aan de rij. Het verlagen verwijdert die extra ruimte, maar de werkelijke hoogte blijft groter dan 20 punten omdat de tekst en celmarges meer ruimte nodig hebben. Alleen het minimum verlagen kan de rij niet onder de ruimte dwingen die de inhoud vereist.

Enkele factoren die de werkelijke hoogte beïnvloeden:

- **Tekst en lettergrootte:** langere tekst, expliciete regeleinden of een groter lettertype kan meer verticale ruimte vereisen.  
- **Omloop en kolombreedte:** wanneer omloop ingeschakeld is, kan het verkleinen van de kolombreedte met [IColumn::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/icolumn/set_width/) meer regels opleveren. Een bredere kolom kan de benodigde verticale ruimte verminderen.  
- **Celmarges:** [ICell::set_MarginTop](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_margintop/) en [ICell::set_MarginBottom](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginbottom/) regelen de marges die verticale ruimte toevoegen. [ICell::set_MarginLeft](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginleft/) en [ICell::set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginright/) beperken de breedte die beschikbaar is voor tekst en kunnen extra omloop veroorzaken.

Voor deze tabel zonder samengevoegde cellen bepaalt de cel die de meeste verticale ruimte nodig heeft de inhoud‑gedreven ondergrens voor de hele rij. Om de rij korter te maken, moet u mogelijk de tekst inkorten, de lettergrootte of marges verkleinen, of een kolom breder maken.

De afbeeldingen hieronder tonen dezelfde tabel op dezelfde schaal. In de referentie‑.NET‑run die hier wordt getoond, waren de werkelijke hoogtes 70, 100 en 55.2 punten: de laatste rij bleef hoger dan het minimum van 20 punten. Exacte tekstmetingen kunnen variëren afhankelijk van de lettertypen die in uw omgeving beschikbaar zijn. Download de opgeslagen resultaten: [verhoogd minimum](row-height-increased.pptx) en [verlaagd minimum](row-height-decreased.pptx).

| Origineel: minimum 70 pt, werkelijk 70 pt | Verhoogd: minimum 100 pt, werkelijk 100 pt | Verlaagd: minimum 20 pt, werkelijk 55.2 pt |
| --- | --- | --- |
| ![Originele tabel met een eerste rij van 70 punten.](row-height-before.png) | ![Tabel na het verhogen van de minimale hoogte van de eerste rij naar 100 punten.](row-height-increased.png) | ![Tabel na het verlagen van de minimale hoogte van de eerste rij naar 20 punten; omgebroken tekst houdt de rij hoger dan het minimum.](row-height-decreased.png) |

## **Eerste rij als header instellen**

Gebruik de [set_FirstRow](https://reference.aspose.com/slides/cpp/aspose.slides/itable/set_firstrow/)‑methode om de eerste rij te markeren voor header‑opmaak. Het uiterlijk hangt af van de tabel‑stijl die op de tabel is toegepast.

1. Laad de presentatie met de klasse [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).  
2. Open de eerste dia.  
3. Open de tabel die is opgeslagen als het eerste object op de dia.  
4. Schakel header‑opmaak in voor de eerste rij.  
5. Sla de aangepaste presentatie op.

Het voorbeeld vereist `table.pptx` met een tabel als het eerste object op de eerste dia. Het schakelt header‑opmaak in voor de eerste rij en slaat `First_row_header.pptx` op.

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

## **Een tabelrij of -kolom klonen**

Kloon rijen of kolommen om hun inhoud en opmaak opnieuw te gebruiken. U kunt een kopie aan het einde van de tabel toevoegen of deze op een specifieke positie invoegen.

1. Laad de presentatie met de klasse [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).  
2. Open de eerste dia.  
3. Definieer de kolombreedtes en rijhoogtes.  
4. Voeg een tabel toe met de [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/)‑methode.  
5. Kloon de benodigde rijen.  
6. Kloon de benodigde kolommen.  
7. Sla de aangepaste presentatie op.

Het voorbeeld vereist `Test.pptx` met minstens één dia. Het maakt een tabel met drie kolommen en vijf rijen, met afmetingen opgegeven in punten. Het voegt kopieën van de eerste rij en kolom toe aan het einde, en voegt vervolgens kopieën van de tweede rij en kolom in op index 3 (de vierde positie). De resulterende tabel heeft zeven rijen en vijf kolommen. Het argument `false` schakelt klonen in aangrenzende samengevoegde rijen of kolommen uit; deze tabel heeft geen samengevoegde cellen.

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

## **Een rij of kolom uit een tabel verwijderen**

Verwijder rijen of kolommen die niet langer nodig zijn in een tabel. Het verwijderen van een item verschuift de indices van de daaropvolgende rijen of kolommen.

1. Maak een presentatie met de klasse [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).  
2. Open de eerste dia.  
3. Definieer de kolombreedtes en rijhoogtes.  
4. Voeg een tabel toe met de [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/)‑methode.  
5. Verwijder de tweede rij en tweede kolom.  
6. Sla de aangepaste presentatie op.

Dit voorbeeld maakt een drie‑bij‑drie‑tabel en verwijdert de rij en kolom op index 1, waardoor een twee‑bij‑twee‑tabel overblijft in `TestTable_out.pptx`. De afmetingen zijn in punten. Het argument `false` schakelt het verwijderen van aangrenzende samengevoegde rijen of kolommen uit; deze tabel heeft geen samengevoegde cellen.

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

## **Tekstopmaak instellen op rijniveau van de tabel**

Pas tekstopmaak toe op een volledige rij zodat de cellen consistent blijven. U kunt lettertype‑eigenschappen, alinea‑opmaak en tekstrichting instellen zonder elke cel afzonderlijk te formatteren.

1. Laad de presentatie met de klasse [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).  
2. Open de tabel op de eerste dia.  
3. Stel de letterhoogte in met [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) voor de eerste rij.  
4. Stel de uitlijning en de rechter alinea‑marge in met [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) en [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) voor de eerste rij.  
5. Stel de tekstrichting in met [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) voor de tweede rij.  
6. Sla de aangepaste presentatie op.

Het voorbeeld vereist `table.pptx` met een tabel als eerste object op de eerste dia en minstens twee rijen. Het past 25‑punt tekst, rechts uitlijnen en een rechter alinea‑marge van 20 punt toe op de eerste rij, en zet verticale tekst in de tweede rij.

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

## **Tekstopmaak instellen op kolomniveau van de tabel**

Pas tekstopmaak toe op een volledige kolom zodat de cellen consistent blijven. U kunt lettertype‑eigenschappen, alinea‑opmaak en tekstrichting instellen zonder elke cel afzonderlijk te formatteren.

1. Laad de presentatie met de klasse [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).  
2. Open de tabel op de eerste dia.  
3. Stel de letterhoogte in met [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) voor de eerste kolom.  
4. Stel de uitlijning en de rechter alinea‑marge in met [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) en [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) voor de eerste kolom.  
5. Stel de tekstrichting in met [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) voor de tweede kolom.  
6. Sla de aangepaste presentatie op.

Het voorbeeld vereist `table.pptx` met een tabel als eerste object op de eerste dia en minstens twee kolommen. Het past 25‑punt tekst, rechts uitlijnen en een rechter alinea‑marge van 20 punt toe op de eerste kolom, en zet verticale tekst in de tweede kolom.

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

## **Tabelstijleigenschappen ophalen**

Gebruik de [get_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_stylepreset/)‑methode om de preset die op een tabel is toegepast op te halen en opnieuw te gebruiken op een andere tabel. Dit identificeert de preset in plaats van individuele cel‑opmaakoverschrijvingen.

Het voorbeeld maakt een tabel, past [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/cpp/aspose.slides/tablestylepreset/) toe en leest de preset terug. Het drukt `DarkStyle1` af en slaat de tabel op in `table.pptx`.

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

## **Veelgestelde vragen**

**Kan ik PowerPoint‑thema’s/stijlen toepassen op een tabel die al bestaat?**

Ja. De tabel erft het thema van de dia/lay‑out/master, en u kunt nog steeds opvullingen, randen en tekstkleuren bovenop dat thema overschrijven.

**Kan ik tabelrijen sorteren zoals in Excel?**

Nee, Aspose.Slides‑tabellen hebben geen ingebouwde sortering of filters. Sorteer uw gegevens eerst in het geheugen en vul vervolgens de tabelrijen in die volgorde opnieuw.

**Kan ik afwisselend (gestreept) gekleurde kolommen hebben terwijl ik aangepaste kleuren behoud voor specifieke cellen?**

Ja. Schakel afwisselende kolommen in, en overschrijf vervolgens specifieke cellen met lokale opmaak; opmaak op celniveau heeft voorrang boven de tabel‑stijl.