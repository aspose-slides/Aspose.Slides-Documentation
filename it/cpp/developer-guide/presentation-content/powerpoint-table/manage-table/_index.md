---
title: Gestisci Tabelle delle Presentazioni in C++
linktitle: Gestisci Tabella
type: docs
weight: 10
url: /it/cpp/manage-table/
keywords:
- aggiungi tabella
- crea tabella
- accedi tabella
- rapporto d'aspetto
- allinea testo
- formattazione testo
- stile tabella
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Crea e modifica tabelle nelle diapositive PowerPoint con Aspose.Slides per C++. Scopri esempi di codice semplici per ottimizzare i tuoi flussi di lavoro con le tabelle."
---
## **Introduzione**

Una tabella in PowerPoint è un modo efficiente per visualizzare e rappresentare informazioni. Le informazioni in una griglia di celle (disposte in righe e colonne) sono chiare e facili da capire.

Aspose.Slides fornisce la classe [Table](https://reference.aspose.com/slides/it/cpp/aspose.slides/table/) , l'interfaccia [ITable](https://reference.aspose.com/slides/it/cpp/aspose.slides/itable/) , la classe [Cell](https://reference.aspose.com/slides/it/cpp/aspose.slides/cell/) , l'interfaccia [ICell](https://reference.aspose.com/slides/it/cpp/aspose.slides/icell/) e altri tipi per consentire di creare, aggiornare e gestire tabelle in tutti i tipi di presentazioni. 

## **Crea una Tabella da Zero**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) .
2. Ottieni un riferimento alla diapositiva tramite il suo indice. 
3. Definisci un array di `columnWidth`.
4. Definisci un array di `rowHeight`.
5. Aggiungi un oggetto [ITable](https://reference.aspose.com/slides/it/cpp/aspose.slides/itable/) alla diapositiva tramite il metodo [AddTable()](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishapecollection/addtable/) .
6. Itera attraverso ciascun [ICell](https://reference.aspose.com/slides/it/cpp/aspose.slides/icell/) per applicare la formattazione ai bordi superiore, inferiore, destro e sinistro.
7. Unisci le prime due celle della prima riga della tabella. 
8. Accedi al [TextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/textframe/) di una [ICell](https://reference.aspose.com/slides/it/cpp/aspose.slides/icell/) . 
9. Aggiungi del testo al [TextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/textframe/) .
10. Salva la presentazione modificata.

Questo codice C++ mostra come creare una tabella in una presentazione:

```c++
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
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

// Instanzia una classe Presentation che rappresenta un file PPTX
auto pres = System::MakeObject<Presentation>();

// Accede alla prima diapositiva
auto sld = pres->get_Slides()->idx_get(0);

// Definisce le colonne con larghezze e le righe con altezze
auto dblCols = System::MakeArray<double>({ 50, 50, 50 });
auto dblRows = System::MakeArray<double>({ 50, 30, 30, 30, 30 });

// Aggiunge una forma tabella alla diapositiva
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Imposta il formato del bordo per ogni cella
for (int32_t row = 0; row < tbl->get_Rows()->get_Count(); row++)
{
    for (int32_t cell = 0; cell < tbl->get_Rows()->idx_get(row)->get_Count(); cell++)
    {
        auto cellFormat = tbl->get_Rows()->idx_get(row)->idx_get(cell)->get_CellFormat();

        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType((FillType::Solid));
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
// Unisce le celle 1 e 2 della riga 1
tbl->MergeCells(tbl->get_Rows()->idx_get(0)->idx_get(0), tbl->get_Rows()->idx_get(1)->idx_get(1), false);

// Aggiunge del testo alla cella unita
tbl->get_Rows()->idx_get(0)->idx_get(0)->get_TextFrame()->set_Text(u"Merged Cells");

// Salva la presentazione su disco
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Numerazione in una Tabella Standard**

In una tabella standard, la numerazione delle celle è semplice e basata su zero. La prima cella in una tabella è indicizzata come 0,0 (colonna 0, riga 0). 

Ad esempio, le celle in una tabella con 4 colonne e 4 righe sono numerate in questo modo:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Questo codice C++ mostra come specificare la numerazione per le celle in una tabella:

```c++
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
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

// Instanzia una classe Presentation che rappresenta un file PPTX
auto pres = System::MakeObject<Presentation>();

// Accede alla prima diapositiva
auto sld = pres->get_Slides()->idx_get(0);

// Definisce le colonne con larghezze e le righe con altezze
auto dblCols = System::MakeArray<double>({ 70, 70, 70, 70 });
auto dblRows = System::MakeArray<double>({ 70, 70, 70, 70 });

// Aggiunge una forma tabella alla diapositiva
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Imposta il formato del bordo per ogni cella
for (const auto& row : tbl->get_Rows())
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

// Salva la presentazione su disco
pres->Save(u"StandardTables_out.pptx", SaveFormat::Pptx);
```

## **Accedi a una Tabella Esistente**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) .

2. Ottieni un riferimento alla diapositiva contenente la tabella tramite il suo indice. 

3. Crea un oggetto [ITable](https://reference.aspose.com/slides/it/cpp/aspose.slides/itable/) e impostalo a null.

4. Itera attraverso tutti gli oggetti [IShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/) finché non trovi la tabella.

   Se sospetti che la diapositiva in uso contenga una sola tabella, puoi semplicemente controllare tutte le forme che contiene. Quando una forma è identificata come tabella, puoi eseguire il cast a oggetto [Table](https://reference.aspose.com/slides/it/cpp/aspose.slides/table/) . Ma se la diapositiva contiene più tabelle, è consigliabile cercare la tabella necessaria tramite il suo [set_AlternativeText()](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/set_alternativetext/) .

5. Usa l'oggetto [ITable](https://reference.aspose.com/slides/it/cpp/aspose.slides/itable/) per lavorare con la tabella. Nell'esempio sotto, abbiamo aggiunto una nuova riga alla tabella.

6. Salva la presentazione modificata.

Questo codice C++ mostra come accedere e lavorare con una tabella esistente:

```c++
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Instanzia una classe Presentation che rappresenta un file PPTX
auto pres = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");

// Accede alla prima diapositiva
auto sld = pres->get_Slides()->idx_get(0);

// Inizializza una tabella nulla
System::SharedPtr<ITable> tbl;

// Itera tra le forme e imposta un riferimento alla tabella trovata
for (const auto& shp : System::IterateOver(sld->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// Imposta il testo per la prima colonna della seconda riga
tbl->idx_get(0, 1)->get_TextFrame()->set_Text(u"New");

// Salva la presentazione modificata su disco
pres->Save(u"table1_out.pptx", SaveFormat::Pptx);
```

## **Trova la Cella che Possiede un Text Frame**

Quando un codice generico di elaborazione del testo riceve un [ITextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/) da una tabella, utilizza [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/get_parentcell/) per recuperare la [ICell](https://reference.aspose.com/slides/it/cpp/aspose.slides/icell/) proprietaria. Per un text frame di una cella di tabella, [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/get_parentcell/) restituisce il proprietario e [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/get_parentshape/) restituisce `nullptr`, anche se la tabella stessa è una forma.

Le coordinate della cella sono disponibili tramite i metodi di sola lettura [ICell::get_FirstColumnIndex](https://reference.aspose.com/slides/it/cpp/aspose.slides/icell/get_firstcolumnindex/) e [ICell::get_FirstRowIndex](https://reference.aspose.com/slides/it/cpp/aspose.slides/icell/get_firstrowindex/) . [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/get_parentcell/) fornisce anche una navigazione di sola lettura: restituisce il proprietario ma non ne cambia la proprietà. Verifica sempre che la cella restituita non sia `nullptr` prima di usarla.

Per un esempio completo che identifica i proprietari di celle di tabella e di forme, incluse le forme associate ai nodi SmartArt, vedi [Search and Replace Text](/slides/it/cpp/search-and-replace-text/) .

## **Allinea il Testo in una Tabella**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) .
2. Ottieni un riferimento alla diapositiva tramite il suo indice. 
3. Aggiungi un oggetto [ITable](https://reference.aspose.com/slides/it/cpp/aspose.slides/itable/) alla diapositiva. 
4. Accedi a un oggetto [ITextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/) dalla tabella. 
5. Accedi all'[IParagraph](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraph/) dell'[ITextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/) .
6. Allinea il testo verticalmente.
7. Salva la presentazione modificata.

Questo codice C++ mostra come allineare il testo in una tabella:

```c++
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
#include <DOM/ISlideCollection.h>
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

// Crea un'istanza della classe Presentation
auto presentation = System::MakeObject<Presentation>();

// Ottiene la prima diapositiva
auto slide = presentation->get_Slides()->idx_get(0);

// Definisce le colonne con larghezze e le righe con altezze
auto dblCols = System::MakeArray<double>({ 120, 120, 120, 120 });
auto dblRows = System::MakeArray<double>({ 100, 100, 100, 100 });

// Aggiunge la forma tabella alla diapositiva
auto tbl = slide->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);
tbl->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
tbl->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
tbl->idx_get(3, 0)->get_TextFrame()->set_Text(u"30");

// Accede al frame di testo
auto txtFrame = tbl->idx_get(0, 0)->get_TextFrame();

// Crea l'oggetto Paragraph per il frame di testo
auto paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// Crea l'oggetto Portion per il paragrafo
auto portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Text here");
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// Allinea il testo verticalmente
auto cell = tbl->idx_get(0, 0);
cell->set_TextAnchorType(TextAnchorType::Center);
cell->set_TextVerticalType(TextVerticalType::Vertical270);

// Salva la Presentazione su disco
presentation->Save(u"Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
```

## **Imposta la Formattazione del Testo a Livello di Tabella**

1. Crea un'istanza della [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) .
2. Ottieni un riferimento alla diapositiva tramite il suo indice. 
3. Accedi a un oggetto [ITable](https://reference.aspose.com/slides/it/cpp/aspose.slides/itable/) dalla diapositiva.
4. Imposta il [set_FontHeight()](https://reference.aspose.com/slides/it/cpp/aspose.slides/baseportionformat/set_fontheight/) per il testo. 
5. Imposta il [set_Alignment()](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraphformat/set_alignment/) e il [set_MarginRight()](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraphformat/set_marginright/) . 
6. Imposta il [set_TextVerticalType()](https://reference.aspose.com/slides/it/cpp/aspose.slides/textframeformat/set_textverticaltype/) .
7. Salva la presentazione modificata. 

Questo codice C++ mostra come applicare le opzioni di formattazione preferite al testo in una tabella:

```c++
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
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

// Crea un'istanza della classe Presentation
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

// Supponiamo che la prima forma nella prima diapositiva sia una tabella
auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// Imposta l'altezza del carattere delle celle della tabella
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->SetTextFormat(portionFormat);

// Imposta l'allineamento del testo e il margine destro delle celle della tabella in un'unica chiamata
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->SetTextFormat(paragraphFormat);

// Imposta il tipo di orientamento verticale del testo delle celle della tabella
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->SetTextFormat(textFrameFormat);

presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Ottieni le Proprietà di Stile della Tabella**

Aspose.Slides consente di recuperare le proprietà di stile per una tabella in modo da poterle utilizzare per un’altra tabella o altrove. Questo codice C++ mostra come ottenere le proprietà di stile da uno stile predefinito di tabella:

```c++
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <DOM/TableStylePreset.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Blocca il Rapporto d'Aspetto di una Tabella**

Il rapporto d'aspetto di una forma geometrica è il rapporto delle sue dimensioni in diverse dimensioni. Aspose.Slides fornisce la proprietà `AspectRatioLocked()` per consentire di bloccare l'impostazione del rapporto d'aspetto per tabelle e altre forme. 

Questo codice C++ mostra come bloccare il rapporto d'aspetto per una tabella:

```c++
#include <DOM/IGraphicalObjectLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto table = System::ExplicitCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());


table->get_GraphicalObjectLock()->set_AspectRatioLocked(!table->get_GraphicalObjectLock()->get_AspectRatioLocked());

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Posso abilitare la direzione di lettura da destra a sinistra (RTL) per un'intera tabella e il testo nelle sue celle?**

Sì. La tabella espone un metodo [set_RightToLeft](https://reference.aspose.com/slides/it/cpp/aspose.slides/table/set_righttoleft/) e i paragrafi hanno [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/it/cpp/aspose.slides/paragraphformat/set_righttoleft/) . L'uso di entrambi garantisce l'ordine RTL corretto e il rendering all'interno delle celle.

**Come posso impedire agli utenti di spostare o ridimensionare una tabella nel file finale?**

Usa [shape locks](/slides/it/cpp/applying-protection-to-presentation/) per disabilitare lo spostamento, il ridimensionamento, la selezione, ecc. Questi blocchi si applicano anche alle tabelle.

**È supportato inserire un'immagine all'interno di una cella come sfondo?**

Sì. È possibile impostare un [picture fill](https://reference.aspose.com/slides/it/cpp/aspose.slides/picturefillformat/) per una cella; l'immagine coprirà l'area della cella secondo la modalità scelta (stretch o tile).