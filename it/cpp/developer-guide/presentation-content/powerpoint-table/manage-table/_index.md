---
title: Gestire le tabelle delle presentazioni in C++
linktitle: Gestisci tabella
type: docs
weight: 10
url: /it/cpp/manage-table/
keywords:
- aggiungere tabella
- creare tabella
- accedere tabella
- rapporto d'aspetto
- allineare testo
- formattazione del testo
- stile della tabella
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Crea e modifica tabelle nelle diapositive PowerPoint con Aspose.Slides per C++. Scopri esempi di codice semplici per ottimizzare i tuoi flussi di lavoro con le tabelle."
---
## **Introduzione**

Una tabella in PowerPoint è un modo efficiente per visualizzare e rappresentare le informazioni. Le informazioni in una griglia di celle (disposte in righe e colonne) sono chiare e facili da comprendere.

Aspose.Slides fornisce la classe [Table](https://reference.aspose.com/slides/it/cpp/aspose.slides/table/), l’interfaccia [ITable](https://reference.aspose.com/slides/it/cpp/aspose.slides/itable/), la classe [Cell](https://reference.aspose.com/slides/it/cpp/aspose.slides/cell/), l’interfaccia [ICell](https://reference.aspose.com/slides/it/cpp/aspose.slides/icell/) e altri tipi per consentire di creare, aggiornare e gestire le tabelle in tutti i tipi di presentazioni. 

## **Creare una Tabella da Zero**

1. Creare un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).  
2. Ottenere il riferimento a una diapositiva tramite il suo indice.  
3. Definire un array di `columnWidth`.  
4. Definire un array di `rowHeight`.  
5. Aggiungere un oggetto [ITable](https://reference.aspose.com/slides/it/cpp/aspose.slides/itable/) alla diapositiva tramite il metodo [AddTable()](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishapecollection/addtable/).  
6. Iterare su ciascun [ICell](https://reference.aspose.com/slides/it/cpp/aspose.slides/icell/) per applicare la formattazione ai bordi superiore, inferiore, destro e sinistro.  
7. Unire le prime due celle della prima riga della tabella.  
8. Accedere al [TextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/textframe/) di una [ICell](https://reference.aspose.com/slides/it/cpp/aspose.slides/icell/).  
9. Aggiungere del testo al [TextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/textframe/).  
10. Salvare la presentazione modificata.

Questo codice C++ mostra come creare una tabella in una presentazione:

```c++
// Instanzia una classe Presentation che rappresenta un file PPTX
auto pres = System::MakeObject<Presentation>();

// Accede alla prima diapositiva
auto sld = pres->get_Slides()->idx_get(0);

// Definisce colonne con larghezze e righe con altezze
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

In una tabella standard, la numerazione delle celle è semplice e basata su zero. La prima cella di una tabella ha indice 0,0 (colonna 0, riga 0). 

Ad esempio, le celle in una tabella con 4 colonne e 4 righe sono numerate così:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Questo codice C++ mostra come specificare la numerazione per le celle di una tabella:

```c++
// Instanzia una classe Presentation che rappresenta un file PPTX
auto pres = System::MakeObject<Presentation>();

// Accede alla prima diapositiva
auto sld = pres->get_Slides()->idx_get(0);

// Definisce colonne con larghezze e righe con altezze
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

## **Accedere a una Tabella Esistente**

1. Creare un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).  

2. Ottenere il riferimento alla diapositiva contenente la tabella tramite il suo indice.  

3. Creare un oggetto [ITable](https://reference.aspose.com/slides/it/cpp/aspose.slides/itable/) e impostarlo a null.  

4. Iterare su tutti gli oggetti [IShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/) finché non viene trovata la tabella.  

   Se sospetti che la diapositiva contenga una sola tabella, puoi semplicemente controllare tutte le forme al suo interno. Quando una forma è identificata come tabella, puoi effettuare il cast a oggetto [Table](https://reference.aspose.com/slides/it/cpp/aspose.slides/table/). Se la diapositiva contiene più tabelle, è preferibile cercare la tabella desiderata tramite il metodo [set_AlternativeText()](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/set_alternativetext/).  

5. Utilizzare l’oggetto [ITable](https://reference.aspose.com/slides/it/cpp/aspose.slides/itable/) per lavorare con la tabella. Nell’esempio seguente, abbiamo aggiunto una nuova riga alla tabella.  

6. Salvare la presentazione modificata.

Questo codice C++ mostra come accedere e lavorare con una tabella esistente:

```c++
// Instanzia una classe Presentation che rappresenta un file PPTX
auto pres = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");

// Accede alla prima diapositiva
auto sld = pres->get_Slides()->idx_get(0);

// Inizializza una tabella nulla
System::SharedPtr<ITable> tbl;

// Itera attraverso le forme e imposta un riferimento alla tabella trovata
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

## **Allineare il Testo in una Tabella**

1. Creare un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).  
2. Ottenere il riferimento a una diapositiva tramite il suo indice.  
3. Aggiungere un oggetto [ITable](https://reference.aspose.com/slides/it/cpp/aspose.slides/itable/) alla diapositiva.  
4. Accedere a un oggetto [ITextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/) dalla tabella.  
5. Accedere al [IParagraph](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraph/) dell’[ITextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/).  
6. Allineare il testo verticalmente.  
7. Salvare la presentazione modificata.

Questo codice C++ mostra come allineare il testo in una tabella:

```c++
// Crea un'istanza della classe Presentation
auto presentation = System::MakeObject<Presentation>();

// Ottiene la prima diapositiva 
auto slide = presentation->get_Slides()->idx_get(0);

// Definisce colonne con larghezze e righe con altezze
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

## **Impostare la Formattazione del Testo a Livello di Tabella**

1. Creare un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).  
2. Ottenere il riferimento a una diapositiva tramite il suo indice.  
3. Accedere a un oggetto [ITable](https://reference.aspose.com/slides/it/cpp/aspose.slides/itable/) dalla diapositiva.  
4. Impostare il valore di [set_FontHeight()](https://reference.aspose.com/slides/it/cpp/aspose.slides/baseportionformat/set_fontheight/) per il testo.  
5. Impostare [set_Alignment()](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraphformat/set_alignment/) e [set_MarginRight()](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraphformat/set_marginright/).  
6. Impostare [set_TextVerticalType()](https://reference.aspose.com/slides/it/cpp/aspose.slides/textframeformat/set_textverticaltype/).  
7. Salvare la presentazione modificata.  

Questo codice C++ mostra come applicare le opzioni di formattazione preferite al testo di una tabella:

```c++
// Crea un'istanza della classe Presentation
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

// Supponiamo che la prima forma sulla prima diapositiva sia una tabella
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

## **Ottenere le Proprietà di Stile della Tabella**

Aspose.Slides consente di recuperare le proprietà di stile di una tabella in modo da poterle utilizzare per un’altra tabella o altrove. Questo codice C++ mostra come ottenere le proprietà di stile da uno stile predefinito di tabella:

```c++
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Bloccare il Rapporto d'Aspetto di una Tabella**

Il rapporto d’aspetto di una forma geometrica è il rapporto tra le sue dimensioni in diverse direzioni. Aspose.Slides fornisce la proprietà `AspectRatioLocked()` per consentire di bloccare l’impostazione del rapporto d’aspetto per tabelle e altre forme. 

Questo codice C++ mostra come bloccare il rapporto d’aspetto per una tabella:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto table = System::ExplicitCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());


table->get_GraphicalObjectLock()->set_AspectRatioLocked(!table->get_GraphicalObjectLock()->get_AspectRatioLocked());

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Posso abilitare la direzione di lettura da destra a sinistra (RTL) per un’intera tabella e per il testo nelle sue celle?**

Sì. La tabella espone il metodo [set_RightToLeft](https://reference.aspose.com/slides/it/cpp/aspose.slides/table/set_righttoleft/), e i paragrafi hanno [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/it/cpp/aspose.slides/paragraphformat/set_righttoleft/). L’utilizzo di entrambi garantisce l’ordine RTL corretto e il rendering all’interno delle celle.

**Come posso impedire agli utenti di spostare o ridimensionare una tabella nel file finale?**

Utilizzare i [blocco forme](/slides/it/cpp/applying-protection-to-presentation/) per disabilitare spostamento, ridimensionamento, selezione, ecc. questi blocchi si applicano anche alle tabelle.

**È supportato l’inserimento di un’immagine all’interno di una cella come sfondo?**

Sì. È possibile impostare un [riempimento immagine](https://reference.aspose.com/slides/it/cpp/aspose.slides/picturefillformat/) per una cella; l’immagine coprirà l’area della cella secondo la modalità scelta (stretch o tile).