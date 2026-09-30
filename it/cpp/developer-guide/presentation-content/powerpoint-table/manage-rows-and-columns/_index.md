---
title: Gestisci righe e colonne nelle tabelle PowerPoint usando C++
linktitle: Righe e colonne
type: docs
weight: 20
url: /it/cpp/manage-rows-and-columns/
keywords:
- riga della tabella
- colonna della tabella
- prima riga
- intestazione della tabella
- clona riga
- clona colonna
- copia riga
- copia colonna
- rimuovi riga
- rimuovi colonna
- formattazione testo riga
- formattazione testo colonna
- stile della tabella
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Gestisci le righe e le colonne delle tabelle in PowerPoint con Aspose.Slides per C++ e velocizza la modifica delle presentazioni e l'aggiornamento dei dati."
---
## **Introduzione**

Aspose.Slides for C++ ti consente di gestire la struttura e la formattazione delle tabelle nelle presentazioni PowerPoint tramite la classe [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/) e l'interfaccia [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/). È possibile designare una riga di intestazione, clonare o rimuovere righe e colonne e applicare la formattazione del testo a un'intera riga o colonna.

Questo articolo spiega queste operazioni con esempi C++. Mostra anche come recuperare il preset di stile di una tabella per poterlo riutilizzare. Gli indici di righe e colonne della tabella sono basati su zero.

## **Controllare l'altezza della riga**

Usa [IRow::set_MinimalHeight](https://reference.aspose.com/slides/cpp/aspose.slides/irow/set_minimalheight/) per impostare l'altezza minima di una riga in punti. È un limite inferiore, non un'altezza fissa. [IRow::get_Height](https://reference.aspose.com/slides/cpp/aspose.slides/irow/get_height/) restituisce l'altezza effettiva; questo valore non può essere impostato direttamente. Accedi alla riga tramite [ITable::get_Rows](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_rows/).

L'esempio carica [row-height-input.pptx](row-height-input.pptx), che contiene una tabella come prima forma nella prima diapositiva. La sua prima riga inizia a 70 punti. Le celle utilizzano testo Arial da 18 punti, con a capo automatico e margini superiore e inferiore di 6 punti; il testo più lungo nella seconda colonna si suddivide su più righe. L'esempio aumenta il minimo a 100 punti, poi lo diminuisce a 20 punti, stampa l'altezza reale dopo ogni modifica e salva entrambi i risultati.

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

Con la presentazione fornita, aumentare il minimo aggiunge spazio alla riga. Ridurlo rimuove quello spazio extra, ma l'altezza reale rimane superiore a 20 punti perché il testo e i margini delle celle necessitano di più spazio. Ridurre solo il minimo non può forzare la riga al di sotto dello spazio richiesto dal suo contenuto.

Diversi fattori influiscono sull'altezza reale:

- **Testo e dimensione del carattere:** testo più lungo, interruzioni di riga esplicite o un carattere più grande possono richiedere più spazio verticale.
- **A capo automatico e larghezza colonna:** con l'avvolgimento abilitato, ridurre la larghezza della colonna con [IColumn::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/icolumn/set_width/) può produrre più righe. Una colonna più larga può ridurre lo spazio richiesto verticalmente.
- **Margini delle celle:** [ICell::set_MarginTop](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_margintop/) e [ICell::set_MarginBottom](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginbottom/) controllano i margini che aggiungono spazio verticale. [ICell::set_MarginLeft](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginleft/) e [ICell::set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginright/) controllano i margini che riducono la larghezza disponibile per il testo e possono causare ulteriori a capo.

Per questa tabella senza celle unite, la cella che necessita del maggior spazio verticale determina il limite inferiore determinato dal contenuto per l'intera riga. Per rendere la riga più corta, potrebbe essere necessario accorciare il testo, ridurre la dimensione del carattere o i margini, o allargare una colonna.

Le immagini sotto mostrano la stessa tabella alla stessa scala. Nell'esecuzione di riferimento .NET mostrata qui, le altezze reali erano 70, 100 e 55.2 punti: la riga finale è rimasta più alta del minimo di 20 punti. Le misurazioni precise del testo possono variare a seconda dei caratteri disponibili nel tuo ambiente. Scarica i risultati salvati: [minimo aumentato](row-height-increased.pptx) e [minimo diminuito](row-height-decreased.pptx).

| Originale: minimo 70 pt, reale 70 pt | Aumentato: minimo 100 pt, reale 100 pt | Ridotto: minimo 20 pt, reale 55.2 pt |
| --- | --- | --- |
| ![Tabella originale con prima riga di 70 punti.](row-height-before.png) | ![Tabella dopo aver aumentato il minimo della prima riga a 100 punti.](row-height-increased.png) | ![Tabella dopo aver diminuito il minimo della prima riga a 20 punti; il testo a capo mantiene la riga più alta del minimo.](row-height-decreased.png) |

## **Impostare la prima riga come intestazione**

Usa il metodo [set_FirstRow](https://reference.aspose.com/slides/cpp/aspose.slides/itable/set_firstrow/) per contrassegnare la prima riga per la formattazione dell'intestazione. Il suo aspetto dipende dallo stile della tabella applicato.

1. Carica la presentazione con la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Accedi alla prima diapositiva.
3. Accedi alla tabella memorizzata come prima forma sulla diapositiva.
4. Abilita la formattazione dell'intestazione per la sua prima riga.
5. Salva la presentazione modificata.

L'esempio richiede `table.pptx` con una tabella come prima forma nella prima diapositiva. Abilita la formattazione dell'intestazione per la prima riga e salva `First_row_header.pptx`.

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

## **Clonare una riga o colonna di tabella**

Clona righe o colonne per riutilizzare il loro contenuto e formattazione. Puoi aggiungere una copia alla fine della tabella o inserirla in una posizione specifica.

1. Carica la presentazione con la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Accedi alla prima diapositiva.
3. Definisci le larghezze delle colonne e le altezze delle righe.
4. Aggiungi una tabella con il metodo [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/).
5. Clona le righe richieste.
6. Clona le colonne richieste.
7. Salva la presentazione modificata.

L'esempio richiede `Test.pptx` con almeno una diapositiva. Crea una tabella con tre colonne e cinque righe, con dimensioni specificate in punti. Aggiunge copie della prima riga e colonna, poi inserisce copie della seconda riga e colonna all'indice 3 (la quarta posizione). La tabella risultante ha sette righe e cinque colonne. L'argomento `false` disabilita il clonaggio in righe o colonne unite adiacenti; questa tabella non contiene celle unite.

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

## **Rimuovere una riga o colonna da una tabella**

Rimuovi righe o colonne che non sono più necessarie in una tabella. La rimozione di un elemento sposta gli indici delle righe o colonne successive.

1. Crea una presentazione con la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Accedi alla prima diapositiva.
3. Definisci le larghezze delle colonne e le altezze delle righe.
4. Aggiungi una tabella con il metodo [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/).
5. Rimuovi la seconda riga e la seconda colonna.
6. Salva la presentazione modificata.

Questo esempio crea una tabella 3x3 e rimuove la riga e la colonna all'indice 1, lasciando una tabella 2x2 in `TestTable_out.pptx`. Le dimensioni sono in punti. L'argomento `false` disabilita la rimozione di righe o colonne unite adiacenti; questa tabella non contiene celle unite.

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

## **Impostare la formattazione del testo a livello di riga della tabella**

Applica la formattazione del testo a un'intera riga per mantenere le celle coerenti. Puoi impostare le proprietà del carattere, la formattazione del paragrafo e la direzione del testo senza formattare ogni cella singolarmente.

1. Carica la presentazione con la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Accedi alla tabella nella prima diapositiva.
3. Imposta l'altezza del carattere con [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) per la prima riga.
4. Imposta l'allineamento e il margine destro del paragrafo con [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) e [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) per la prima riga.
5. Imposta la direzione del testo con [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) per la seconda riga.
6. Salva la presentazione modificata.

L'esempio richiede `table.pptx` con una tabella come prima forma nella prima diapositiva e almeno due righe. Applica testo da 25 punti, allineamento a destra e un margine destro del paragrafo di 20 punti alla prima riga, poi imposta il testo verticale nella seconda riga.

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

## **Impostare la formattazione del testo a livello di colonna della tabella**

Applica la formattazione del testo a un'intera colonna per mantenere le celle coerenti. Puoi impostare le proprietà del carattere, la formattazione del paragrafo e la direzione del testo senza formattare ogni cella singolarmente.

1. Carica la presentazione con la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Accedi alla tabella nella prima diapositiva.
3. Imposta l'altezza del carattere con [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) per la prima colonna.
4. Imposta l'allineamento e il margine destro del paragrafo con [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) e [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) per la prima colonna.
5. Imposta la direzione del testo con [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) per la seconda colonna.
6. Salva la presentazione modificata.

L'esempio richiede `table.pptx` con una tabella come prima forma nella prima diapositiva e almeno due colonne. Applica testo da 25 punti, allineamento a destra e un margine destro del paragrafo di 20 punti alla prima colonna, poi imposta il testo verticale nella seconda colonna.

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

## **Ottenere le proprietà dello stile della tabella**

Usa il metodo [get_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_stylepreset/) per recuperare il preset applicato a una tabella e riutilizzarlo su un'altra tabella. Questo identifica il preset invece delle sovrascritture di formattazione delle singole celle.

L'esempio crea una tabella, applica [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/cpp/aspose.slides/tablestylepreset/), e legge nuovamente il preset. Stampa `DarkStyle1` e salva la tabella in `table.pptx`.

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

## **FAQ**

**Posso applicare temi/stili di PowerPoint a una tabella già creata?**

Sì. La tabella eredita il tema della diapositiva/layout/master e puoi comunque sovrascrivere riempimenti, bordi e colori del testo sopra quel tema.

**Posso ordinare le righe della tabella come in Excel?**

No, le tabelle di Aspose.Slides non dispongono di ordinamento o filtri incorporati. Ordina i dati in memoria prima, quindi riempi nuovamente le righe della tabella in quell'ordine.

**Posso avere colonne a bande (a strisce) mantenendo colori personalizzati su celle specifiche?**

Sì. Attiva le colonne a bande, poi sovrascrivi celle specifiche con formattazione locale; la formattazione a livello di cella ha precedenza sullo stile della tabella.