---
title: Soluzione funzionante per il ridimensionamento dei grafici in PPTX
type: docs
weight: 60
url: /it/cpp/working-solution-for-chart-resizing-in-pptx/
keywords:
- ridimensionamento del grafico
- grafico Excel
- oggetto OLE
- incorporare grafico
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Correggi il ridimensionamento inaspettato dei grafici nei file PPTX quando si utilizzano oggetti OLE Excel incorporati con Aspose.Slides per C++. Scopri due metodi con codice per mantenere le dimensioni coerenti."
---
## **Contesto**

È stato osservato che i grafici Excel incorporati come oggetti OLE in una presentazione PowerPoint attraverso componenti Aspose vengono ridimensionati a una scala non specificata dopo la prima attivazione. Questo comportamento provoca una differenza visiva notevole nella presentazione tra lo stato del grafico prima e dopo l'attivazione. Il team di Aspose ha investigato il problema in dettaglio e ha trovato una soluzione. Questo articolo descrive le cause del problema e la relativa correzione.

Nel [articolo precedente](/slides/it/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), abbiamo spiegato come creare un grafico Excel con Aspose.Cells per C++ e incorporarlo in una presentazione PowerPoint utilizzando Aspose.Slides per C++. Per affrontare il [problema di anteprima dell'oggetto](/slides/it/cpp/object-preview-issue-when-adding-oleobjectframe/), abbiamo assegnato l'immagine del grafico al frame OLE del grafico. Nella presentazione di output, quando si fa doppio clic sul frame OLE che visualizza l'immagine del grafico, il grafico Excel viene attivato. Gli utenti finali possono apportare le modifiche desiderate nella cartella di lavoro Excel sottostante e poi tornare alla diapositiva corrispondente facendo clic al di fuori della cartella di lavoro attivata. La dimensione del frame OLE cambia quando l'utente torna alla diapositiva, e il fattore di ridimensionamento varia a seconda delle dimensioni originali sia del frame OLE sia della cartella di lavoro Excel incorporata.

## **Causa del ridimensionamento**

Poiché la cartella di lavoro Excel ha una sua dimensione della finestra, tenta di mantenere le dimensioni originali alla prima attivazione. Tuttavia, il frame OLE ha una sua dimensione. Secondo Microsoft, quando la cartella di lavoro Excel viene attivata, Excel e PowerPoint negoziano le dimensioni e mantengono le proporzioni corrette come parte del processo di incorporamento. A seconda delle differenze tra la dimensione della finestra di Excel e quella del frame OLE (o della sua posizione), si verifica il ridimensionamento.

## **Soluzione funzionante**

Esistono due possibili scenari per creare presentazioni PowerPoint utilizzando Aspose.Slides per C++.

**Scenario 1:** Creare una presentazione basata su un modello esistente.

**Scenario 2:** Creare una presentazione da zero.

La soluzione che forniamo qui si applica a entrambi gli scenari. La base di tutti gli approcci di soluzione è la stessa: **la dimensione della finestra dell'oggetto OLE incorporato deve corrispondere al frame OLE nella diapositiva PowerPoint**. Discuteremo ora i due approcci a questa soluzione.

## **Primo approccio**

In questo approccio, impareremo come impostare la dimensione della finestra della cartella di lavoro Excel incorporata affinché corrisponda alla dimensione del frame OLE nella diapositiva PowerPoint.

**Scenario 1** 

Supponiamo di aver definito un modello e di voler creare presentazioni basate su di esso. Immaginiamo che nel modello ci sia una forma all'indice 2 dove vogliamo posizionare un frame OLE contenente una cartella di lavoro Excel incorporata. In questo scenario, la dimensione del frame OLE è predefinita — corrisponde alla dimensione della forma all'indice 2 nel modello. Tutto ciò che dobbiamo fare è impostare la dimensione della finestra della cartella di lavoro uguale a quella della forma. Il seguente frammento di codice soddisfa questo scopo:

```cpp
System::SharedPtr<System::IO::MemoryStream> ToSlidesMemoryStream(intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> inputStream)
{
    auto outputBuffer = System::MakeArray<uint8_t>(inputStream->GetLength(), inputStream->GetBuffer()->ArrayPoint());
    auto outputStream = System::MakeObject<System::IO::MemoryStream>(outputBuffer);

    return outputStream;
}
```

```cpp
// Definisci la dimensione del grafico con una finestra. 
chart->SetSizeWithWindow(true);

auto shape = slide->get_Shape(2);

// Imposta la larghezza della finestra della cartella di lavoro in pollici (divisa per 72 poiché PowerPoint utilizza 72 pixel per pollice).
workbook->GetISettings()->SetWindowWidthInch(shape->get_Width() / 72.f);

// Imposta l'altezza della finestra della cartella di lavoro in pollici.
workbook->GetISettings()->SetWindowHeightInch(shape->get_Height() / 72.f);

// Salva la cartella di lavoro in un flusso di memoria.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream3(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// Create an OLE object frame with the embedded Excel data.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    shape->get_X(), 
    shape->get_Y(), 
    shape->get_Width(), 
    shape->get_Height(),
    dataInfo);
```

**Scenario 2** 

Diciamo di voler creare una presentazione da zero e includere un frame OLE di qualsiasi dimensione con una cartella di lavoro Excel incorporata. Nel frammento di codice seguente, creiamo un frame OLE alto 4 pollici e largo 9,5 pollici a x = 0,5 pollici e y = 1 pollice sulla diapositiva. Impostiamo quindi la finestra della cartella di lavoro Excel alla stessa dimensione — 4 pollici di altezza e 9,5 pollici di larghezza.

```cpp
// Altezza desiderata.
int32_t desiredHeight = 288; // 4 pollici (4 * 72)

// Larghezza desiderata.
int32_t desiredWidth = 684; // 9.5 pollici (9.5 * 72)

// Definisci la dimensione del grafico con una finestra. 
chart->SetSizeWithWindow(true);

// Imposta la larghezza della finestra della cartella di lavoro in pollici.
workbook->GetISettings()->SetWindowWidthInch(desiredWidth / 72.f);

// Imposta l'altezza della finestra della cartella di lavoro in pollici.
workbook->GetISettings()->SetWindowHeightInch(desiredHeight / 72.f);

// Salva la cartella di lavoro in un flusso di memoria.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// Crea un frame OLE con i dati Excel incorporati.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    36.0f,
    72.0f, 
    desiredWidth, 
    desiredHeight,
    dataInfo);
```

## **Secondo approccio**

In questo approccio, impareremo come impostare la dimensione del grafico nella cartella di lavoro Excel incorporata in modo che corrisponda alla dimensione del frame OLE nella diapositiva PowerPoint. Questo approccio è utile quando la dimensione del grafico è nota in anticipo e non cambierà mai.

**Scenario 1** 

Supponiamo di aver definito un modello e di voler creare presentazioni basate su di esso. Immaginiamo che nel modello ci sia una forma all'indice 2 dove intendiamo posizionare un frame OLE contenente una cartella di lavoro Excel incorporata. In questo scenario, la dimensione del frame OLE è predefinita — corrisponde alla dimensione della forma all'indice 2 nel modello. Tutto ciò che dobbiamo fare è impostare la dimensione del grafico nella cartella di lavoro pari a quella della forma. Il seguente frammento di codice soddisfa questo scopo:

```cpp
// Definisci la dimensione del grafico senza una finestra. 
chart->SetSizeWithWindow(false);

auto shape = slide->get_Shape(2);

// Imposta la larghezza del grafico in pixel (moltiplica per 96 poiché Excel utilizza 96 pixel per pollice).    
chart->GetIChartObject()->SetWidth((int32_t)(shape->get_Width() / 72.f * 96.f));

// Imposta l'altezza del grafico in pixel.
chart->GetIChartObject()->SetHeight((int32_t)(shape->get_Height() / 72.f) * 96.f);

// Definisci la dimensione di stampa del grafico.
chart->SetPrintSize(Aspose::Cells::PrintSizeType::PrintSizeType_Custom);

// Salva la cartella di lavoro in un flusso di memoria.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// Crea un frame OLE con i dati Excel incorporati.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    shape->get_X(), 
    shape->get_Y(), 
    shape->get_Width(),
    shape->get_Height(),
    dataInfo);
```

**Scenario 2** 

Supponiamo di voler creare una presentazione da zero e includere un frame OLE di qualsiasi dimensione con una cartella di lavoro Excel incorporata. Nel frammento di codice seguente, creiamo un frame OLE con un’altezza di 4 pollici e una larghezza di 9,5 pollici sulla diapositiva a x = 0,5 pollici e y = 1 pollice. Impostiamo anche la dimensione del grafico corrispondente alle stesse dimensioni: un’altezza di 4 pollici e una larghezza di 9,5 pollici.

```cpp
// Altezza desiderata.
int32_t desiredHeight = 288; // 4 pollici (4 * 576)

// Larghezza desiderata.
int32_t desiredWidth = 684; // 9.5 pollici(9.5 * 576)

// Definisci la dimensione del grafico senza una finestra. 
chart->SetSizeWithWindow(false);

// Imposta la larghezza del grafico in pixel.    
chart->GetIChartObject()->SetWidth((int32_t)((desiredWidth / 72.f) * 96.f));

// Imposta l'altezza del grafico in pixel.
chart->GetIChartObject()->SetHeight((int32_t)((desiredHeight / 72.f) * 96.f));

// Salva la cartella di lavoro in un flusso di memoria.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// Crea un frame OLE con i dati Excel incorporati.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    36.0f, 
    72.0f, 
    desiredWidth, 
    desiredHeight,
    dataInfo);
```

## **Conclusione**

Esistono due approcci per risolvere il problema del ridimensionamento del grafico. La scelta dell'approccio dipende dai requisiti e dal caso d'uso. Entrambi gli approcci funzionano allo stesso modo sia che le presentazioni siano create da un modello sia da zero. Inoltre, non vi è alcun limite alla dimensione del frame OLE in questa soluzione.

## **FAQ**

**Perché il mio grafico Excel incorporato cambia dimensione dopo averlo attivato in PowerPoint?**

Questo accade perché Excel tenta di ripristinare la dimensione originale della finestra al primo avvio, mentre il frame OLE in PowerPoint ha le proprie dimensioni. PowerPoint ed Excel negoziano la dimensione per mantenere le proporzioni, il che può causare il ridimensionamento.

**È possibile prevenire completamente questo problema di ridimensionamento?**

Sì. Abbinando la dimensione della finestra della cartella di lavoro Excel o la dimensione del grafico alla dimensione del frame OLE prima dell'incorporamento, è possibile mantenere le dimensioni del grafico coerenti.

**Quale approccio dovrei adottare, impostare la dimensione della finestra della cartella di lavoro o impostare la dimensione del grafico?**

Usa **Approach 1 (window size)** se desideri mantenere le proporzioni della cartella di lavoro e possibilmente consentire il ridimensionamento successivo.  
Usa **Approach 2 (chart size)** se le dimensioni del grafico sono fisse e non cambieranno dopo l'incorporamento.

**Questi metodi funzioneranno sia con presentazioni basate su modello sia con nuove presentazioni?**

Sì. Entrambi gli approcci funzionano allo stesso modo per le presentazioni create da modelli e da zero.

**Esiste un limite alla dimensione del frame OLE?**

No. È possibile impostare il frame OLE a qualsiasi dimensione purché si adatti correttamente alla dimensione della cartella di lavoro o del grafico.

**Posso utilizzare questi metodi con grafici creati in altri programmi di foglio di calcolo?**

Gli esempi sono progettati per grafici Excel creati con Aspose.Cells, ma i principi si applicano ad altri programmi di foglio di calcolo compatibili con OLE purché supportino opzioni di dimensionamento simili.

## **Sezioni correlate**

- [Creare grafici Excel e incorporarli come oggetti OLE nelle presentazioni](/slides/it/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)