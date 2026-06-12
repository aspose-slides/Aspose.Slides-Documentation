---
title: "Gestire righe e colonne nelle tabelle PowerPoint con C++"
linktitle: "Righe e colonne"
type: docs
weight: 20
url: /it/cpp/manage-rows-and-columns/
keywords:
- "riga tabella"
- "colonna tabella"
- "prima riga"
- "intestazione tabella"
- "clona riga"
- "clona colonna"
- "copia riga"
- "copia colonna"
- "rimuovi riga"
- "rimuovi colonna"
- "formattazione testo riga"
- "formattazione testo colonna"
- "stile tabella"
- "PowerPoint"
- "presentazione"
- "C++"
- "Aspose.Slides"
description: "Gestisci righe e colonne delle tabelle in PowerPoint con Aspose.Slides per C++ e velocizza la modifica delle presentazioni e l'aggiornamento dei dati."
---
## **Introduzione**

Per consentire di gestire le righe e le colonne di una tabella in una presentazione PowerPoint, Aspose.Slides fornisce la classe [Table](https://reference.aspose.com/slides/it/cpp/aspose.slides/table/), l'interfaccia [ITable](https://reference.aspose.com/slides/it/cpp/aspose.slides/itable/) e molti altri tipi. 

## **Imposta la prima riga come intestazione**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation) e carica la presentazione. 
2. Ottieni il riferimento a una diapositiva tramite il suo indice. 
3. Crea un oggetto [ITable](https://reference.aspose.com/slides/it/cpp/aspose.slides/itable/) e impostalo a null. 
4. Scorri tutti gli oggetti [IShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/) per trovare la tabella pertinente. 
5. Imposta la prima riga della tabella come intestazione. 

Questo codice C++ mostra come impostare la prima riga di una tabella come intestazione:

```c++
// Istanzia la classe Presentation 
auto pres = System::MakeObject<Presentation>(u"table.pptx");

// Accede alla prima diapositiva
auto sld = pres->get_Slides()->idx_get(0);

// Inizializza il TableEx nullo
SharedPtr<ITable> tbl;

// Itera tra le forme e imposta un riferimento alla tabella
for (const auto& shp : sld->get_Shapes())
{
    if (ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// Imposta la prima riga di una tabella come intestazione 
tbl->set_FirstRow(true);
```

## **Clona una riga o una colonna della tabella**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation) e carica la presentazione, 
2. Ottieni il riferimento a una diapositiva tramite il suo indice. 
3. Definisci un array di `columnWidth`. 
4. Definisci un array di `rowHeight`. 
5. Aggiungi un oggetto [ITable](https://reference.aspose.com/slides/it/cpp/aspose.slides/itable/) alla diapositiva tramite il metodo [AddTable()](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishapecollection/addtable/). 
6. Clona la riga della tabella. 
7. Clona la colonna della tabella. 
8. Salva la presentazione modificata. 

Questo codice C++ mostra come clonare una riga o una colonna di una tabella PowerPoint:

```c++
 // Il percorso della directory dei documenti.
const String outPath = u"../out/CloningInTable_out.pptx";

// Istanzia la classe Presentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accede alla prima diapositiva
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Definisce le colonne con larghezze e le righe con altezze
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Aggiunge una forma tabella alla diapositiva
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// Imposta il formato del bordo per ogni cella
for (int x = 0; x < table->get_Rows()->get_Count(); x++)
{
	SharedPtr<IRow> row = table->get_Rows()->idx_get(x);
	for (int y = 0; y < row->get_Count(); y++)
	{
		SharedPtr<ICell> cell = row->idx_get(y);

		cell->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
		cell->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
		cell->get_BorderTop()->set_Width(5);

		cell->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
		cell->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
		cell->get_BorderBottom()->set_Width(5);

		cell->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
		cell->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
		cell->get_BorderLeft()->set_Width(5);

		cell->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
		cell->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
		cell->get_BorderRight()->set_Width(5);

	}

}

table->idx_get(0, 0)->get_TextFrame()->set_Text(u"00");
table->idx_get(0, 1)->get_TextFrame()->set_Text(u"01");
table->idx_get(0, 2)->get_TextFrame()->set_Text(u"02");
table->idx_get(0, 3)->get_TextFrame()->set_Text(u"03");
table->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
table->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
table->idx_get(1, 1)->get_TextFrame()->set_Text(u"11");
table->idx_get(2, 1)->get_TextFrame()->set_Text(u"21");

//AddClone aggiunge una riga alla fine della tabella
table->get_Rows()->AddClone(table->get_Rows()->idx_get(0), false);

//InsertClone aggiunge una riga in una posizione specifica nella tabella
table->get_Rows()->InsertClone(2, table->get_Rows()->idx_get(0), false);

//AddClone aggiunge una colonna alla fine della tabella
table->get_Columns()->AddClone(table->get_Columns()->idx_get(0), false);

//InsertClone aggiunge una colonna in una posizione specifica nella tabella
table->get_Columns()->InsertClone(2, table->get_Columns()->idx_get(0), false);


// Salva la presentazione su disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Rimuovi una riga o una colonna da una tabella**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation) e carica la presentazione, 
2. Ottieni il riferimento a una diapositiva tramite il suo indice. 
3. Definisci un array di `columnWidth`. 
4. Definisci un array di `rowHeight`. 
5. Aggiungi un oggetto [ITable](https://reference.aspose.com/slides/it/cpp/aspose.slides/itable/) alla diapositiva tramite il metodo [AddTable()](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishapecollection/addtable/). 
6. Rimuovi la riga della tabella. 
7. Rimuovi la colonna della tabella. 
8. Salva la presentazione modificata. 

Questo codice C++ mostra come rimuovere una riga o una colonna da una tabella:

```c++
// Il percorso della directory dei documenti.
const String outPath = u"../out/RemovingRowColumn_out.pptx";

// Istanzia la classe Presentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accede alla prima diapositiva
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Definisce le colonne con larghezze e le righe con altezze
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Aggiunge una forma tabella alla diapositiva
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);

table->get_Rows()->RemoveAt(1, false);
table->get_Columns()->RemoveAt(1, false);


// Unisce le celle (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Unisce le celle (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// Salva la presentazione su disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Imposta la formattazione del testo a livello di riga della tabella**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation) e carica la presentazione, 
2. Ottieni il riferimento a una diapositiva tramite il suo indice. 
3. Accedi all'oggetto [ITable](https://reference.aspose.com/slides/it/cpp/aspose.slides/itable/) pertinente dalla diapositiva. 
4. Imposta l'altezza del carattere delle celle della prima riga con [set_FontHeight()](https://reference.aspose.com/slides/it/cpp/aspose.slides/baseportionformat/set_fontheight/). 
5. Imposta l'allineamento delle celle della prima riga con [set_Alignment()](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraphformat/set_alignment/) e il margine destro con [set_MarginRight()](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraphformat/set_marginright/). 
6. Imposta il tipo di testo verticale delle celle della seconda riga con [set_TextVerticalType()](https://reference.aspose.com/slides/it/cpp/aspose.slides/textframeformat/set_textverticaltype/). 
7. Salva la presentazione modificata. 

Questo codice C++ dimostra l'operazione.

```c++
// Crea un'istanza della classe Presentation
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slides()->idx_get(0);

auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
// Supponiamo che la prima forma nella prima diapositiva sia una tabella
// Imposta l'altezza del carattere delle celle della prima riga
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->get_Rows()->idx_get(0)->SetTextFormat(portionFormat);

// Imposta l'allineamento del testo e il margine destro delle celle della prima riga
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->get_Rows()->idx_get(0)->SetTextFormat(paragraphFormat);

// Imposta il tipo di testo verticale delle celle della seconda riga
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->get_Rows()->idx_get(1)->SetTextFormat(textFrameFormat);

// Salva la presentazione su disco
presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Imposta la formattazione del testo a livello di colonna della tabella**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation) e carica la presentazione, 
2. Ottieni il riferimento a una diapositiva tramite il suo indice. 
3. Accedi all'oggetto [ITable](https://reference.aspose.com/slides/it/cpp/aspose.slides/itable/) pertinente dalla diapositiva. 
4. Imposta l'altezza del carattere delle celle della prima colonna con [set_FontHeight()](https://reference.aspose.com/slides/it/cpp/aspose.slides/baseportionformat/set_fontheight/). 
5. Imposta l'allineamento delle celle della prima colonna con [set_Alignment()](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraphformat/set_alignment/) e il margine destro con [set_MarginRight()](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraphformat/set_marginright/). 
6. Imposta il tipo di testo verticale delle celle della seconda colonna con [set_TextVerticalType()](https://reference.aspose.com/slides/it/cpp/aspose.slides/textframeformat/set_textverticaltype/). 
7. Salva la presentazione modificata. 

Questo codice C++ dimostra l'operazione: 

```c++
// Crea un'istanza della classe Presentation
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);

auto someTable = System::AsCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
// Supponiamo che la prima forma nella prima diapositiva sia una tabella

// Imposta l'altezza del carattere delle celle della prima colonna
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->get_Columns()->idx_get(0)->SetTextFormat(portionFormat);

// Imposta l'allineamento del testo e il margine destro delle celle della prima colonna in un'unica chiamata
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->get_Columns()->idx_get(0)->SetTextFormat(paragraphFormat);

// Imposta il tipo di testo verticale delle celle della seconda colonna
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->get_Columns()->idx_get(1)->SetTextFormat(textFrameFormat);

pres->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Ottieni le proprietà dello stile della tabella**

Aspose.Slides consente di recuperare le proprietà di stile di una tabella in modo da poterle utilizzare per un'altra tabella o altrove. Questo codice C++ mostra come ottenere le proprietà di stile da uno stile predefinito della tabella:

```c++
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Posso applicare temi/stili di PowerPoint a una tabella già creata?**

Sì. La tabella eredita il tema della diapositiva/layout/master e puoi comunque sovrascrivere riempimenti, bordi e colori del testo sopra quel tema.

**Posso ordinare le righe della tabella come in Excel?**

No, le tabelle di Aspose.Slides non hanno ordinamento o filtri integrati. Ordina i dati in memoria prima, quindi ricrea le righe della tabella nell'ordine desiderato.

**Posso avere colonne a bande (striate) mantenendo colori personalizzati su celle specifiche?**

Sì. Attiva le colonne a bande, poi sovrascrivi le celle specifiche con formattazione locale; la formattazione a livello di cella ha precedenza sullo stile della tabella.