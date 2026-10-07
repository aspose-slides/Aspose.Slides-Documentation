---
title: Gestisci le celle della tabella nelle presentazioni con C++
linktitle: Gestisci le celle
type: docs
weight: 30
url: /it/cpp/manage-cells/
keywords:
- cella della tabella
- unire celle
- rimuovere bordo
- dividere cella
- immagine nella cella
- colore di sfondo
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Gestisci le celle delle tabelle PowerPoint in C++: identifica le celle unite, rimuovi i bordi, dividi le celle e imposta colori di sfondo e immagini con Aspose.Slides per C++."
---
## **Panoramica**

Aspose.Slides consente di accedere e modificare le celle di una tabella nelle presentazioni PowerPoint. Questo articolo spiega come identificare le celle di tabella unite, rimuovere i bordi delle celle, gestire la numerazione delle celle dopo il merge o lo split delle celle, cambiare il colore di sfondo di una cella e aggiungere un'immagine all'interno di una cella di tabella. Gli esempi mostrano come creare o aprire una presentazione, ottenere una tabella da una diapositiva, aggiornare la formattazione della cella tramite le proprietà della cella e salvare la presentazione modificata come file PPTX.

Aspose.Slides utilizza indici a base zero per accedere alle celle della tabella nell'ordine `(column, row)`.

## **Identificare una Cella di Tabella Unita**

L'esempio apre una presentazione esistente e accede alla prima forma nella prima diapositiva come tabella. Suppone che la diapositiva e la forma esistano e che la forma sia una tabella. Quindi itera su tutte le righe e le colonne e utilizza [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) per identificare le celle nelle regioni unite. Per ogni corrispondenza, stampa le coordinate della cella nell'ordine `row;column`, [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/), [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/), e le coordinate di inizio della regione, [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) e [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/).

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IColumnCollection.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation_with_table.pptx");
auto slide = presentation->get_Slide(0);
auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto rowCount = table->get_Rows()->get_Count();
for (auto rowIndex = 0; rowIndex < rowCount; rowIndex++)
{
    auto columnCount = table->get_Columns()->get_Count();
    for (auto columnIndex = 0; columnIndex < columnCount; columnIndex++)
    {
        auto cell = table->idx_get(columnIndex, rowIndex);
        if (cell->get_IsMergedCell())
        {
            Console::WriteLine(u"Cell {0};{1} belongs to a merged region with RowSpan={2} and ColSpan={3} starting at {4};{5}.", rowIndex, columnIndex, cell->get_RowSpan(), cell->get_ColSpan(), cell->get_FirstRowIndex(), cell->get_FirstColumnIndex());
        }
    }
}
```

## **Rimuovere i Bordi delle Celle della Tabella**

Crea una [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) e aggiungi una tabella alla sua prima diapositiva con [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/). Le larghezze delle colonne, le altezze delle righe e la posizione della tabella sono specificate in punti. L'esempio imposta tutti e quattro i bordi della cella su [FillType::NoFill](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/), rendendoli invisibili.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/FillType.h>
#include <DOM/ILineFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <system/enumerator_adapter.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({50, 50, 50, 50});
auto rowHeights = MakeArray<double>({50, 30, 30, 30, 30});
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

for (const auto& row : IterateOver(table->get_Rows()))
    for (const auto& cell : IterateOver(row))
    {
        cell->get_CellFormat()->get_BorderTop()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderRight()->get_FillFormat()->set_FillType(FillType::NoFill);
    }

presentation->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Unire Celle della Tabella**

Utilizza [MergeCells](https://reference.aspose.com/slides/cpp/aspose.slides/itable/mergecells/) per combinare un intervallo rettangolare di celle della tabella in una singola cella. Specifica le celle agli angoli in alto a sinistra e in basso a destra dell'intervallo. L'ultimo argomento controlla se l'unione può includere celle al di fuori dell'intervallo specificato; `false` mantiene l'unione entro quell'intervallo.

L'esempio crea una tabella 4x4 con colonne e righe da 70 punti, quindi unisce le quattro celle centrali da `(1, 1)` a `(2, 2)`. La cella risultante occupa due colonne e due righe, mentre la griglia sottostante della tabella mantiene quattro colonne e quattro righe. Per accedere al contenuto o alla formattazione della cella unita, utilizza la sua posizione in alto a sinistra: `table->idx_get(1, 1)` in questo esempio. Le altre posizioni nell'intervallo unito rimangono parte della griglia della tabella, quindi gli indici delle celle fuori dall'intervallo non cambiano.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({70, 70, 70, 70});
auto rowHeights = MakeArray<double>({70, 70, 70, 70});
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 2), false);

presentation->Save(u"merged_cells.pptx", SaveFormat::Pptx);
```

## **Dividere Celle della Tabella**

L'unione delle celle nell'esempio precedente preserva la griglia della tabella. Dividere una cella può introdurre una nuova colonna nella griglia e modificare gli indici di colonna delle celle alla sua destra. Aspose.Slides segue il modello di griglia delle tabelle di PowerPoint.

Questo esempio crea una tabella 4x4 con colonne e righe da 70 punti e chiama [SplitByWidth](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbywidth/) sulla cella `(1, 1)`. La metà della larghezza di 70 punti della cella viene passata per creare due celle di larghezza uguale.

Dopo questa divisione, le due metà sono accessibili come `table->idx_get(1, 1)` e `table->idx_get(2, 1)`. La griglia della tabella ora ha cinque colonne: le celle originariamente nelle colonne 2 e 3 passano alle colonne 3 e 4, rispettivamente. Gli indici di riga rimangono invariati. Utilizza questi indici di colonna aggiornati quando accedi alle celle dopo la divisione.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({70, 70, 70, 70});
auto rowHeights = MakeArray<double>({70, 70, 70, 70});
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

table->idx_get(1, 1)->SplitByWidth(table->idx_get(1, 1)->get_Width() / 2);

presentation->Save(u"split_cells.pptx", SaveFormat::Pptx);
```

### **Dividere Celle Unite per Span di Riga o Colonna**

Per predisporre le celle modello unite alla popolazione dei dati, utilizza [SplitByRowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyrowspan/) per dividere lungo un confine di riga esistente, o [SplitByColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbycolspan/) per dividere lungo un confine di colonna.

L'argomento `index` conta le righe nella parte superiore o le colonne nella parte sinistra della divisione; è relativo alla regione unita:

- Divisione di riga: `0 < index <` [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/).

- Divisione di colonna: `0 < index <` [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/).

L'esempio presuppone che una presentazione abbia una tabella come prima forma nella prima diapositiva, con `(1, 2)` e `(1, 3)` unite verticalmente. Partendo dalla posizione inferiore, utilizza [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) e [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) per individuare l'origine e verifica entrambi gli span. `SplitByRowSpan(1)` quindi separa le righe 2 e 3 per i nomi dei prodotti. Per un'unione orizzontale di due colonne, usa invece `SplitByColSpan(1)`.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/ITextFrame.h>
#include <system/console.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table_template.pptx");
auto slide = presentation->get_Slide(0);
auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto selectedCell = table->idx_get(1, 3);
auto firstColumnIndex = selectedCell->get_FirstColumnIndex();
auto firstRowIndex = selectedCell->get_FirstRowIndex();
auto mergedCell = table->idx_get(firstColumnIndex, firstRowIndex);

if (mergedCell->get_IsMergedCell() && mergedCell->get_RowSpan() == 2 && mergedCell->get_ColSpan() == 1)
{
    mergedCell->SplitByRowSpan(1);

    // Recupera le celle risultanti dalla tabella dopo la divisione.
    auto upperCell = table->idx_get(firstColumnIndex, firstRowIndex);
    auto lowerCell = table->idx_get(firstColumnIndex, firstRowIndex + 1);
    Console::WriteLine(u"Upper cell merged: {0}", upperCell->get_IsMergedCell());
    Console::WriteLine(u"Lower cell merged: {0}", lowerCell->get_IsMergedCell());

    upperCell->get_TextFrame()->set_Text(u"Product A");
    lowerCell->get_TextFrame()->set_Text(u"Product B");

    presentation->Save(u"split_template.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"Select a merged region spanning exactly two rows and one column.");
}
```

La griglia della tabella e gli indici delle celle circostanti rimangono invariati. Recupera le celle risultanti mediante le loro coordinate; qui, entrambe hanno span di 1 e [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) restituisce `False`. Regioni più grandi possono rimanere parzialmente unite dopo una divisione.

Il testo originale e la sua formattazione rimangono nella cella superiore (o sinistra); la nuova cella è vuota ma eredita la formattazione della cella, come riempimento, bordi e margini. Popola le celle dopo la divisione e imposta esplicitamente qualsiasi formattazione del testo necessaria.

La presentazione salvata contiene celle separate "Product A" e "Product B" con la formattazione della cella del modello mantenuta. Consulta il [Cell API Reference](https://reference.aspose.com/slides/cpp/aspose.slides/cell/) per i dettagli.

## **Modificare il Colore di Sfondo della Cella della Tabella**

Questo esempio crea una tabella con colonne da 150 punti e righe da 50 punti. Utilizza [set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) per selezionare un riempimento solido e [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/) per accedere al colore di riempimento e impostarlo a rosso per la cella `(2, 3)`, nella terza colonna e quarta riga.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/Table/ICellFormat.h>
#include <drawing/color.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({150, 150, 150, 150});
auto rowHeights = MakeArray<double>({50, 50, 50, 50, 50});
auto table = slide->get_Shapes()->AddTable(50, 50, columnWidths, rowHeights);

auto cell = table->idx_get(2, 3);
cell->get_CellFormat()->get_FillFormat()->set_FillType(FillType::Solid);
cell->get_CellFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

presentation->Save(u"cell_background_color.pptx", SaveFormat::Pptx);
```

## **Aggiungere un'Immagine All'interno di una Cella della Tabella**

Posiziona l'immagine di input nella directory di lavoro prima di eseguire questo esempio. Carica l'immagine con [Images::FromFile](https://reference.aspose.com/slides/cpp/aspose.slides/images/fromfile/) e la aggiunge alla collezione di immagini della presentazione con [AddImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimagecollection/addimage/). Quindi assegna l'immagine al riempimento immagine della cella `(0, 0)`, la prima cella della tabella.

[PictureFillMode::Stretch](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) allunga l'immagine per riempire la cella, il che può modificare il suo rapporto d'aspetto. Le larghezze delle colonne e le altezze delle righe sono in punti. L'immagine caricata viene rilasciata dopo essere stata aggiunta alla presentazione.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/FillType.h>
#include <DOM/IImageCollection.h>
#include <IImage.h>
#include <DOM/IPPImage.h>
#include <DOM/IFillFormat.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Table/ICellFormat.h>
#include <Util/Images.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({150, 150, 150, 150});
auto rowHeights = MakeArray<double>({100, 100, 100, 100, 90});
auto table = slide->get_Shapes()->AddTable(50, 50, columnWidths, rowHeights);

auto image = Images::FromFile(u"aspose_logo.jpg");
auto ppImage = presentation->get_Images()->AddImage(image);
image->Dispose();

table->idx_get(0, 0)->get_CellFormat()->get_FillFormat()->set_FillType(FillType::Picture);
table->idx_get(0, 0)->get_CellFormat()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
table->idx_get(0, 0)->get_CellFormat()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(ppImage);

presentation->Save(u"table_cell_with_image.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Posso impostare spessori e stili di linea diversi per i vari lati di una singola cella?**

Sì. I bordi [superiore](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_bordertop/)/[inferiore](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderbottom/)/[sinistro](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderleft/)/[destro](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderright/) hanno proprietà separate, quindi lo spessore e lo stile di ciascun lato possono differire.

**Cosa succede all'immagine se modifico la dimensione della colonna/riga dopo aver impostato un'immagine come sfondo della cella?**

Il comportamento dipende dalla [modalità di riempimento](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) (stretch/tile). Con lo stretching, l'immagine si adatta alla nuova cella; con il tiling, le piastrelle vengono ricalcolate.

**Posso assegnare un collegamento ipertestuale a tutto il contenuto di una cella?**

[Collegamenti ipertestuali](/slides/it/cpp/manage-hyperlinks/) vengono impostati a livello di testo (porzione) all'interno del frame di testo della cella o a livello dell'intera tabella/forma. In pratica, assegni il collegamento a una porzione o a tutto il testo nella cella.

**Posso impostare caratteri diversi all'interno di una singola cella?**

Sì. Il frame di testo di una cella supporta le [porzioni](https://reference.aspose.com/slides/cpp/aspose.slides/portion/) (run) con formattazione indipendente—famiglia di caratteri, stile, dimensione e colore.