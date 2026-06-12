---
title: Ridimensionare le forme nelle diapositive di presentazione
type: docs
weight: 100
url: /it/cpp/re-sizing-shapes-on-slide/
keywords:
- ridimensionare forma
- cambiare dimensione forma
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Ridimensiona facilmente le forme su diapositive PowerPoint e OpenDocument con Aspose.Slides per C++ — automatizza le regolazioni del layout delle diapositive e aumenta la produttività."
---
## **Panoramica**

Una delle domande più comuni dei clienti di Aspose.Slides per C++ è come ridimensionare le forme in modo che, quando le dimensioni della diapositiva cambiano, i dati non vengano tagliati. Questo breve articolo tecnico mostra come farlo.

## **Ridimensionare le forme**

Per impedire che le forme vengano disallineate quando le dimensioni della diapositiva cambiano, aggiorna la posizione e le dimensioni di ogni forma affinché si conformino al nuovo layout della diapositiva.

```cpp
// Carica il file di presentazione.
auto presentation = MakeObject<Presentation>(u"sample.ppt");

// Ottieni le dimensioni originali della diapositiva.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Modifica le dimensioni della diapositiva senza ridimensionare le forme esistenti.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);

// Ottieni le nuove dimensioni della diapositiva.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

// Ridimensiona e riposiziona le forme su ogni diapositiva.
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // Ridimensiona le dimensioni della forma.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Ridimensiona la posizione della forma.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="primary" %}} 
Se una diapositiva contiene una tabella, il codice sopra non funzionerà correttamente. In tal caso, è necessario ridimensionare ogni cella della tabella.
{{% /alert %}} 

Utilizza il codice seguente per ridimensionare le diapositive che contengono tabelle. Per le tabelle, impostare la larghezza o l’altezza è un caso speciale: è necessario regolare le altezze delle righe e le larghezze delle colonne individuali per modificare le dimensioni complessive della tabella.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Ottieni le dimensioni originali della diapositiva.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Modifica le dimensioni della diapositiva senza ridimensionare le forme esistenti.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
//presentation.SlideSize.Orientation = SlideOrienation.Portrait;

// Ottieni le nuove dimensioni della diapositiva.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

for (auto&& master : presentation->get_Masters())
{
    for (auto&& shape : master->get_Shapes())
    {
        // Ridimensiona le dimensioni della forma.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Ridimensiona la posizione della forma.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }

    for (auto&& layoutSlide : master->get_LayoutSlides())
    {
        for (auto&& shape : layoutSlide->get_Shapes())
        {
            // Ridimensiona le dimensioni della forma.
            shape->set_Height(shape->get_Height() * heightRatio);
            shape->set_Width(shape->get_Width() * widthRatio);

            // Ridimensiona la posizione della forma.
            shape->set_Y(shape->get_Y() * heightRatio);
            shape->set_X(shape->get_X() * widthRatio);
        }
    }
}

for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // Ridimensiona le dimensioni della forma.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Ridimensiona la posizione della forma.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);

        if (ObjectExt::Is<ITable>(shape))
        {
            SharedPtr<ITable> table = ExplicitCast<ITable>(shape);
            for (auto&& row : table->get_Rows())
            {
                row->set_MinimalHeight(row->get_MinimalHeight() * heightRatio);
            }
            for (auto&& column : table->get_Columns())
            {
                column->set_Width(column->get_Width() * widthRatio);
            }
        }
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Domande frequenti**

**Perché le forme risultano distorte o tagliate dopo il ridimensionamento di una diapositiva?**

Durante il ridimensionamento di una diapositiva, le forme mantengono la loro posizione e dimensione originali a meno che la scala non venga modificata esplicitamente. Questo può far sì che il contenuto venga ritagliato o che le forme risultino disallineate.

**Il codice fornito funziona per tutti i tipi di forma?**

L’esempio di base funziona per la maggior parte dei tipi di forma (caselle di testo, immagini, grafici, ecc.). Tuttavia, per le tabelle è necessario gestire righe e colonne separatamente, poiché l’altezza e la larghezza di una tabella sono determinate dalle dimensioni delle singole celle.

**Come ridimensionare le tabelle durante il ridimensionamento di una diapositiva?**

È necessario iterare tutte le righe e le colonne della tabella e ridimensionare proporzionalmente altezza e larghezza, come mostrato nel secondo esempio di codice.

**Questo ridimensionamento funziona per le diapositive master e le diapositive layout?**

Sì, ma è necessario iterare anche su [Masters](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/get_masters/) e [Layout slides](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/get_layoutslides/) e applicare la stessa logica di ridimensionamento alle loro forme per garantire la coerenza nella presentazione.

**Posso modificare l’orientamento di una diapositiva (ritratto/paesaggio) insieme al ridimensionamento?**

Sì. È possibile utilizzare [presentation->get_SlideSize()->set_Orientation](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidesize/set_orientation/) per cambiare l’orientamento. Assicurati di impostare la logica di scala di conseguenza per preservare il layout.

**Esiste un limite alle dimensioni della diapositiva che posso impostare?**

Aspose.Slides supporta dimensioni personalizzate, ma dimensioni molto grandi possono influire sulle prestazioni o sulla compatibilità con alcune versioni di PowerPoint.

**Come posso impedire che le forme con rapporto d’aspetto fisso diventino distorte?**

È possibile verificare il metodo `get_AspectRatioLocked` della forma prima di ridimensionare. Se è bloccato, regola la larghezza o l’altezza proporzionalmente invece di scalarle singolarmente.