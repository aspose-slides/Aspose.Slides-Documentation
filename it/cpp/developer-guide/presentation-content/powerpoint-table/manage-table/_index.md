---
title: Gestire le tabelle delle presentazioni in C++
linktitle: Gestire la tabella
type: docs
weight: 10
url: /it/cpp/manage-table/
keywords:
- aggiungere tabella
- creare tabella
- accedere tabella
- rapporto d'aspetto
- allineare testo
- formattazione testo
- stile tabella
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Crea e modifica tabelle nelle diapositive PowerPoint con Aspose.Slides per C++. Scopri esempi di codice semplici per ottimizzare i tuoi flussi di lavoro con le tabelle."
---
## **Introduzione**

Le tabelle in PowerPoint organizzano le informazioni in righe e colonne, rendendo più facile la lettura e il confronto dei valori.

Aspose.Slides fornisce la classe [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/) , l'interfaccia [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) , la classe [Cell](https://reference.aspose.com/slides/cpp/aspose.slides/cell/) , l'interfaccia [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) e altri tipi per permettere di creare, aggiornare e gestire le tabelle nelle presentazioni.

## **Creare una tabella da zero**

Creare una tabella specificando la sua posizione, le larghezze delle colonne e le altezze delle righe. Dopo averla aggiunta a una diapositiva, è possibile formattare i bordi delle celle, unire le celle e inserire del testo.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Ottenere un riferimento alla diapositiva tramite il suo indice.
3. Definire un array di larghezze di colonna in punti.
4. Definire un array di altezze di riga in punti.
5. Aggiungere un oggetto [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) alla diapositiva tramite il metodo [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) .
6. Iterare su ciascun [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) per applicare la formattazione ai bordi superiore, inferiore, destro e sinistro.
7. Unire le prime due celle della prima riga della tabella.
8. Accedere alla cella unita tramite il suo metodo [get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_textframe/) .
9. Impostare il testo nella cella unita.
10. Salvare la presentazione modificata.

L'esempio seguente crea una tabella con tre colonne e cinque righe in (100, 50) punti. Applica bordi rossi con spessore di 5 punti, unisce le prime due celle nella prima riga e salva il risultato come `table.pptx`.

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 50, 50, 50 });
auto rowHeights = System::MakeArray<double>({ 50, 30, 30, 30, 30 });
auto table = slide->get_Shapes()->AddTable(100.0f, 50.0f, columnWidths, rowHeights);

for (const auto& row : table->get_Rows())
{
    for (const auto& cell : row)
    {
        auto cellFormat = cell->get_CellFormat();

        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderBottom()->set_Width(5);

        cellFormat->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderLeft()->set_Width(5);

        cellFormat->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderRight()->set_Width(5);
    }
}

table->MergeCells(table->idx_get(0, 0), table->idx_get(1, 0), false);
table->idx_get(0, 0)->get_TextFrame()->set_Text(u"Merged Cells");

presentation->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Numerazione in una tabella standard**

Nelle tabelle standard, gli indici delle celle sono basati su zero e utilizzano l'ordine (colonna, riga). La prima cella ha indice (0, 0).

Ad esempio, le celle in una tabella con 4 colonne e 4 righe sono numerate in questo modo:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Questo esempio crea la tabella 4 × 4 illustrata sopra, con larghezze delle colonne e altezze delle righe di 70 punti e bordi rossi con spessore di 5 punti. Le coordinate illustrano gli indici delle celle; l'esempio lascia le celle vuote e salva la tabella come `StandardTables_out.pptx`.

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 70, 70, 70, 70 });
auto rowHeights = System::MakeArray<double>({ 70, 70, 70, 70 });
auto table = slide->get_Shapes()->AddTable(100.0f, 50.0f, columnWidths, rowHeights);

for (const auto& row : table->get_Rows())
{
    for (const auto& cell : row)
    {
        auto cellFormat = cell->get_CellFormat();
        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderBottom()->set_Width(5);

        cellFormat->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderLeft()->set_Width(5);

        cellFormat->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderRight()->set_Width(5);
    }
}

presentation->Save(u"StandardTables_out.pptx", SaveFormat::Pptx);
```

## **Accedere a una tabella esistente**

Le tabelle sono archiviate nella collezione di forme di una diapositiva. Iterare tra le forme per individuare una tabella, quindi utilizzare l'interfaccia [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) per leggere o aggiornare le sue celle.

1. Caricare la presentazione usando la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Ottenere un riferimento alla diapositiva che contiene la tabella tramite il suo indice.
3. Iterare tra gli oggetti [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) e fermarsi quando viene trovata una tabella. Se la diapositiva contiene diverse tabelle, usare [get_AlternativeText](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_alternativetext/) per identificare quella desiderata.
4. Aggiornare il testo nella cella target.
5. Salvare la presentazione modificata.

L'esempio seguente apre `UpdateExistingTable.pptx` e trova la prima tabella nella prima diapositiva. Imposta la cella alla colonna 0, riga 1 a `New` e salva il risultato come `table1_out.pptx`. L'input deve contenere almeno una diapositiva, e la prima tabella su quella diapositiva deve avere almeno una colonna e due righe.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");
auto slide = presentation->get_Slide(0);
System::SharedPtr<ITable> table;

for (const auto& shape : System::IterateOver(slide->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shape))
    {
        table = System::ExplicitCast<ITable>(shape);
        break;
    }
}

if (table != nullptr)
{
    table->idx_get(0, 1)->get_TextFrame()->set_Text(u"New");
    presentation->Save(u"table1_out.pptx", SaveFormat::Pptx);
}
```

Per ridimensionare una riga in una tabella esistente e comprendere perché la sua altezza reale può superare l'altezza minima richiesta, vedere [Controllare l'altezza della riga](/slides/it/cpp/manage-rows-and-columns/#control-row-height).

## **Trovare la cella che possiede un TextFrame**

Quando del codice generico di elaborazione del testo riceve un [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) da una tabella, usare [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) per recuperare la [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) proprietaria. Per un frame di testo di una cella di tabella, [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) restituisce il proprietario e [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentshape/) restituisce `nullptr`, anche se la tabella stessa è una forma.

Le coordinate della cella sono disponibili tramite i metodi di sola lettura [ICell::get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) e [ICell::get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) . Anche [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) fornisce una navigazione di sola lettura: restituisce il proprietario ma non ne cambia la proprietà. Controllare sempre se la cella restituita è `nullptr` prima di usarla.

Per un esempio completo che identifica i proprietari di celle di tabella e di forme, incluse le forme associate a nodi SmartArt, vedere [Cerca e sostituisci testo](/slides/it/cpp/search-and-replace-text/).

## **Allineare il testo in una tabella**

È possibile controllare l'ancoraggio verticale e la direzione del testo delle singole celle della tabella. L'esempio in questa sezione centra il testo nella prima cella e lo ruota di 270 gradi.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Ottenere un riferimento alla diapositiva tramite il suo indice.
3. Aggiungere un oggetto [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) alla diapositiva.
4. Accedere a un oggetto [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) dalla tabella.
5. Accedere al primo [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) e impostare il suo testo e colore.
6. Impostare l'ancoraggio verticale della cella e la direzione del testo usando [set_TextAnchorType](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_textanchortype/) e [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_textverticaltype/) .
7. Salvare la presentazione modificata.

Questo esempio crea una tabella 4 × 4 con larghezze delle colonne di 120 punti e altezze delle righe di 100 punti. Formatta il testo nella cella (0, 0), aggiunge valori alle celle rimanenti nella prima riga e salva il risultato come `Vertical_Align_Text_out.pptx`.

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ITable.h>
#include <DOM/TextAnchorType.h>
#include <DOM/TextVerticalType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 120, 120, 120, 120 });
auto rowHeights = System::MakeArray<double>({ 100, 100, 100, 100 });
auto table = slide->get_Shapes()->AddTable(100.0f, 50.0f, columnWidths, rowHeights);

table->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
table->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
table->idx_get(3, 0)->get_TextFrame()->set_Text(u"30");

auto cell = table->idx_get(0, 0);
auto paragraph = cell->get_TextFrame()->get_Paragraphs()->idx_get(0);

auto portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Text here");
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

cell->set_TextAnchorType(TextAnchorType::Center);
cell->set_TextVerticalType(TextVerticalType::Vertical270);

presentation->Save(u"Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
```

## **Impostare la formattazione del testo a livello di tabella**

Usare [SetTextFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibulktextformattable/settextformat/) per applicare la formattazione del testo a tutte le celle di una tabella. Le sue sovraccariche accettano la formattazione di porzione, paragrafo e frame di testo, così è possibile impostare queste proprietà senza iterare tra le singole celle.

1. Caricare la presentazione usando la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Ottenere un riferimento alla diapositiva tramite il suo indice.
3. Accedere a un oggetto [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) dalla diapositiva.
4. Impostare la dimensione del font usando [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) per il testo.
5. Impostare l'allineamento del paragrafo e il margine destro usando [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) e [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) .
6. Impostare la direzione del testo usando [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) .
7. Salvare la presentazione modificata.

L'esempio seguente apre `table.pptx`, che deve contenere almeno una diapositiva con una tabella come sua prima forma. Imposta la dimensione del font a 25 punti, allinea a destra i paragrafi con un margine destro di 20 punti e rende il testo verticale. La presentazione formattata è salvata come `result.pptx`.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ParagraphFormat.h>
#include <DOM/PortionFormat.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextFrameFormat.h>
#include <DOM/TextVerticalType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));

auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
table->SetTextFormat(portionFormat);

auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
table->SetTextFormat(paragraphFormat);

auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
table->SetTextFormat(textFrameFormat);

presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Ottenere le proprietà di stile della tabella**

Usare [get_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_stylepreset/) per leggere lo stile predefinito di una tabella e [set_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/set_stylepreset/) per assegnarlo. Questo esempio applica [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/cpp/aspose.slides/tablestylepreset/) a una tabella, stampa il nome del preset e assegna lo stesso preset a una seconda tabella. Entrambe le tabelle sono salvate in `table-style.pptx`.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <DOM/TableStylePreset.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 100, 150 });
auto rowHeights = System::MakeArray<double>({ 5, 5, 5 });
auto table = slide->get_Shapes()->AddTable(10, 10, columnWidths, rowHeights);
table->set_StylePreset(TableStylePreset::DarkStyle1);

auto stylePreset = table->get_StylePreset();
System::Console::WriteLine(u"Table style preset: {0}", stylePreset);

auto anotherTable = slide->get_Shapes()->AddTable(10, 100, columnWidths, rowHeights);
anotherTable->set_StylePreset(stylePreset);

presentation->Save(u"table-style.pptx", SaveFormat::Pptx);
```

## **Bloccare il rapporto d'aspetto di una tabella**

Il rapporto d'aspetto di una tabella è il rapporto tra la sua larghezza e la sua altezza. Usare [set_AspectRatioLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/set_aspectratiolocked/) per bloccare questo rapporto per una tabella.

L'esempio seguente apre `pres.pptx`, che deve contenere almeno una diapositiva con una tabella come sua prima forma. Stampa lo stato corrente del blocco, abilita il blocco del rapporto d'aspetto, stampa lo stato aggiornato (`True`) e salva il risultato come `pres-out.pptx`.

```cpp
#include <DOM/IGraphicalObjectLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto slide = presentation->get_Slide(0);

auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

table->get_GraphicalObjectLock()->set_AspectRatioLocked(true);
Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

presentation->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Posso abilitare la direzione di lettura da destra a sinistra (RTL) per un'intera tabella e per il testo nelle sue celle?**

Sì. La tabella espone un metodo [set_RightToLeft](https://reference.aspose.com/slides/cpp/aspose.slides/table/set_righttoleft/) , e i paragrafi hanno [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphformat/set_righttoleft/) . Usare entrambi garantisce l'ordine RTL corretto e il rendering all'interno delle celle.

**Come posso impedire agli utenti di spostare o ridimensionare una tabella nel file finale?**

Utilizzare i [blocchi forma](/slides/it/cpp/applying-protection-to-presentation/) per disabilitare lo spostamento, il ridimensionamento, la selezione, ecc. Questi blocchi si applicano anche alle tabelle.

**È supportato l'inserimento di un'immagine all'interno di una cella come sfondo?**

Sì. È possibile impostare un [riempimento immagine](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/) per una cella; l'immagine coprirà l'area della cella secondo la modalità scelta (stretch o tile).