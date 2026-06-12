---
title: Gestisci le celle della tabella nelle presentazioni usando C++
linktitle: Gestisci Celle
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
description: "Gestisci facilmente le celle delle tabelle in PowerPoint con Aspose.Slides per C++. Impara ad accedere, modificare e stilizzare le celle rapidamente per un'automazione fluida delle diapositive."
---
## **Panoramica**

Aspose.Slides consente di accedere e modificare le celle delle tabelle nelle presentazioni PowerPoint. Questo articolo spiega come identificare le celle unite, rimuovere i bordi delle celle, gestire la numerazione delle celle dopo l’unione o la divisione, modificare il colore di sfondo di una cella e aggiungere un’immagine all’interno di una cella di una tabella. Gli esempi mostrano come creare o aprire una presentazione, recuperare una tabella da una diapositiva, aggiornare la formattazione delle celle tramite le proprietà della cella e salvare la presentazione modificata come file PPTX.

## **Identificare una cella unita**
1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation).
2. Recuperare la tabella dalla prima diapositiva. 
3. Iterare attraverso le righe e le colonne della tabella per trovare le celle unite.
4. Stampare un messaggio quando vengono trovate celle unite.

Questo codice C++ mostra come identificare le celle unite in una presentazione:

``` cpp
auto pres = System::MakeObject<Presentation>(u"SomePresentationWithTable.pptx");
auto table = System::AsCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// assuming that Slide#0.Shape#0 is a table
for (int32_t i = 0; i < table->get_Rows()->get_Count(); i++)
{
    for (int32_t j = 0; j < table->get_Columns()->get_Count(); j++)
    {
        auto currentCell = table->get_Rows()->idx_get(i)->idx_get(j);
        if (currentCell->get_IsMergedCell())
        {
            Console::WriteLine(String::Format(u"Cell {0};{1} is a part of merged cell with RowSpan={2} and ColSpan={3} starting from Cell {4};{5}.", 
                i, j, currentCell->get_RowSpan(), currentCell->get_ColSpan(), currentCell->get_FirstRowIndex(), currentCell->get_FirstColumnIndex()));
        }
    }
}
```

## **Rimuovere i bordi delle celle della tabella**
1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation).
2. Ottenere un riferimento a una diapositiva mediante il suo indice. 
3. Definire un array di colonne con larghezza.
4. Definire un array di righe con altezza.
5. Aggiungere una tabella alla diapositiva tramite il metodo `AddTable`.
6. Iterare attraverso ogni cella per cancellare i bordi superiore, inferiore, destro e sinistro.
7. Salvare la presentazione modificata come file PPTX.

Questo codice C++ mostra come rimuovere i bordi dalle celle della tabella:

``` cpp
// Istanzia la classe Presentation che rappresenta un file PPTX
auto pres = MakeObject<Presentation>();
// Accede alla prima diapositiva
auto sld = pres->get_Slides()->idx_get(0);

// Definisce le colonne con larghezze e le righe con altezze
auto dblCols = MakeArray<double>({ 50, 50, 50, 50 });
auto dblRows = MakeArray<double>({ 50, 30, 30, 30, 30 });

// Aggiunge una forma tabella alla diapositiva
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Imposta il formato del bordo per ogni cella
for (const auto& row : System::IterateOver(tbl->get_Rows()))
{
    for (const auto& cell : System::IterateOver(row))
    {
        cell->get_CellFormat()->get_BorderTop()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderRight()->get_FillFormat()->set_FillType(FillType::NoFill);
    }
}

// Scrive il file PPTX su disco
pres->Save(u"table_out.pptx", SaveFormat::Pptx);
```

## **Numerazione nelle celle unite**
Se uniamo 2 coppie di celle (1, 1) × (2, 1) e (1, 2) × (2, 2), la tabella risultante sarà numerata. Questo codice C# dimostra il processo:

```c++
const String outPath = u"../out/MergeCells_out.pptx";

// Carica la presentazione desiderata
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
// Unisce le celle (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Unisce le celle (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// Salva il file PPTX su disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

Successivamente uniamo ulteriormente le celle unendo (1, 1) e (1, 2). Il risultato è una tabella contenente una grande cella unita al centro:

```c++
// Il percorso della directory dei documenti.
const String outPath = u"../out/MergeCells_out.pptx";

// Carica la presentazione desiderata
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

// Unisce le celle (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Unisce le celle (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// Salva il file PPTX su disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Numerazione in una cella divisa**
Negli esempi precedenti, quando le celle della tabella venivano unite, la numerazione o il sistema di numerazione nelle altre celle non cambiava. 

Questa volta prendiamo una tabella regolare (una tabella senza celle unite) e poi proviamo a dividere la cella (1,1) per ottenere una tabella speciale. Prestate attenzione alla numerazione di questa tabella, che può apparire strana. Tuttavia, è il modo in cui Microsoft PowerPoint numera le celle delle tabelle e Aspose.Slides si comporta allo stesso modo. 

Questo codice C++ dimostra il processo descritto:

```c++
// Il percorso della directory dei documenti.
const String outPath = u"../out/CellSplit_out.pptx";

// Carica la presentazione desiderata
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

// Unisce le celle (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Unisce le celle (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);

// Divide la cella (1, 1).
table->idx_get(1, 1)->SplitByWidth(table->idx_get(2, 1)->get_Width() / 2);

// Salva il file PPTX su disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Modificare il colore di sfondo della cella della tabella**

Questo codice C++ mostra come modificare il colore di sfondo di una cella della tabella:

``` cpp

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
        
auto dblCols = System::MakeArray<double>({150, 150, 150, 150});
auto dblRows = System::MakeArray<double>({50, 50, 50, 50, 50});
        
// crea una nuova tabella
auto table = slide->get_Shapes()->AddTable(50.0f, 50.0f, dblCols, dblRows);
        
// imposta il colore di sfondo per una cella 
System::SharedPtr<ICell> cell = table->idx_get(2, 3);
cell->get_CellFormat()->get_FillFormat()->set_FillType(Aspose::Slides::FillType::Solid);
cell->get_CellFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        
presentation->Save(u"cell_background_color.pptx", Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Aggiungere un'immagine all'interno di una cella della tabella**
1. Creare un'istanza della classe `Presentation`.
2. Ottenere un riferimento a una diapositiva mediante il suo indice.
3. Definire un array di colonne con larghezza.
4. Definire un array di righe con altezza.
5. Aggiungere una tabella alla diapositiva tramite il metodo `AddTable`. 
6. Creare un oggetto `Bitmap` per contenere il file immagine.
7. Aggiungere l’immagine bitmap all’oggetto `IPPImage`.
8. Impostare il `FillFormat` della cella della tabella su `Picture`.
9. Aggiungere l’immagine alla prima cella della tabella.
10. Salvare la presentazione modificata come file PPTX

Questo codice C# mostra come inserire un’immagine all’interno di una cella della tabella durante la creazione della tabella:

```c++
// Il percorso della directory dei documenti.
const String outPath = u"../out/Image_In_TableCell_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// Carica la presentazione desiderata
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accede alla prima diapositiva
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Definisce le colonne con larghezze e le righe con altezze
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 150);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 100);
System::ArrayPtr<double> total_for_Cat = System::MakeObject<System::Array<double>>(5, 0);

// Aggiunge una forma tabella alla diapositiva
auto tbl = islide->get_Shapes()->AddTable(50, 50, dblCols, dblRows);

// Ottiene l'immagine
auto img = Images::FromFile(ImagePath);

// Aggiunge un'immagine alla raccolta di immagini della presentazione
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(img);


// Aggiunge l'immagine alla prima cella della tabella
tbl->idx_get(0, 0)->get_FillFormat()->set_FillType(FillType::Picture);
tbl->idx_get(0, 0)->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
tbl->idx_get(0, 0)->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(imgx);

// Salva il file PPTX su disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **FAQ**

**Posso impostare spessori e stili di linea diversi per i lati di una singola cella?**

Sì. I bordi [superiore](https://reference.aspose.com/slides/it/cpp/aspose.slides/cellformat/get_bordertop/), [inferiore](https://reference.aspose.com/slides/it/cpp/aspose.slides/cellformat/get_borderbottom/), [sinistro](https://reference.aspose.com/slides/it/cpp/aspose.slides/cellformat/get_borderleft/) e [destro](https://reference.aspose.com/slides/it/cpp/aspose.slides/cellformat/get_borderright/) hanno proprietà separate, quindi lo spessore e lo stile di ciascun lato possono differire. Questo deriva logicamente dal controllo dei bordi per lato di una cella mostrato nell’articolo.

**Cosa succede all’immagine se modifico la dimensione della colonna/riga dopo aver impostato un’immagine come sfondo della cella?**

Il comportamento dipende dalla [modalità di riempimento](https://reference.aspose.com/slides/it/cpp/aspose.slides/picturefillmode/) (stretch/tile). Con lo stretching, l’immagine si adatta alla nuova cella; con il tiling, le piastrelle vengono ricalcolate. L’articolo menziona le modalità di visualizzazione dell’immagine in una cella.

**Posso assegnare un collegamento ipertestuale all’intero contenuto di una cella?**

[Hyperlinks](/slides/it/cpp/manage-hyperlinks/) vengono impostati a livello di porzione di testo all’interno del frame di testo della cella o a livello dell’intera tabella/forma. In pratica, si assegna il collegamento a una porzione o a tutto il testo nella cella.

**Posso impostare caratteri diversi all’interno di una singola cella?**

Sì. Il frame di testo di una cella supporta le [porzioni](https://reference.aspose.com/slides/it/cpp/aspose.slides/portion/) (run) con formattazione indipendente—famiglia di caratteri, stile, dimensione e colore.