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
- presentazione
- C++
- Aspose.Slides
description: "Correggi il ridimensionamento inatteso dei grafici in PPTX quando si utilizzano oggetti OLE Excel incorporati con Aspose.Slides per C++. Imposta dimensioni fisse del grafico per mantenere coerenti le dimensioni del grafico e del frame OLE."
---
## **Contesto**

I grafici Excel incorporati come oggetti OLE nelle presentazioni PowerPoint utilizzando i componenti Aspose possono cambiare dimensione dopo la prima attivazione. Ciò può provocare una differenza evidente nell'aspetto del grafico prima e dopo l'attivazione. Questo articolo spiega perché avviene il ridimensionamento e mostra come evitarlo facendo corrispondere le dimensioni fisse del grafico al frame OLE.

In [Crea grafici Excel e incorporali come oggetti OLE nelle presentazioni](/slides/it/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), abbiamo spiegato come creare un grafico Excel con Aspose.Cells per C++ e incorporarlo in una presentazione PowerPoint usando Aspose.Slides per C++. Per affrontare il [problema di anteprima oggetto](/slides/it/cpp/object-preview-issue-when-adding-oleobjectframe/), abbiamo assegnato l'immagine del grafico al frame OLE del grafico. nella presentazione risultante, quando si fa doppio clic sul frame OLE che visualizza l'immagine del grafico, il grafico Excel viene attivato. Gli utenti possono modificare la cartella di lavoro Excel incorporata e poi tornare alla diapositiva facendo clic fuori dalla cartella di lavoro attivata. Le dimensioni del frame OLE cambiano quando l'utente ritorna alla diapositiva, e il fattore di ridimensionamento varia a seconda delle dimensioni originali sia del frame OLE sia della cartella di lavoro Excel incorporata.

## **Causa del ridimensionamento**

La cartella di lavoro Excel incorporata ha proprie dimensioni della finestra, che Excel tenta di mantenere quando l'oggetto viene attivato per la prima volta. Il frame OLE nella diapositiva ha dimensioni definite indipendentemente. Quando la cartella di lavoro Excel viene attivata, Excel e PowerPoint negoziano le dimensioni dell'oggetto per mantenere le proporzioni nell'ambito del processo di incorporamento. Le differenze tra la finestra della cartella di lavoro e il frame OLE possono quindi causare il ridimensionamento dell'oggetto.

## **Soluzione funzionante**

Fai corrispondere la dimensione del grafico al frame OLE nella diapositiva e mantieni le dimensioni del grafico indipendenti dalla finestra della cartella di lavoro. Questa soluzione funziona con una nuova presentazione o con un modello esistente.

L'esempio richiede Aspose.Cells per C++ e Aspose.Slides per C++. Crea un semplice grafico a colonne su un foglio grafico attivo e incorpora la cartella di lavoro in formato XLS. Nessuna immagine di anteprima del grafico è assegnata; il grafico diventa visibile quando l'oggetto OLE viene attivato in PowerPoint.

Inserisci il codice di esempio nel punto di ingresso della tua applicazione, con le dichiarazioni di include a livello di file. Inizializza Aspose.Cells prima di creare i suoi oggetti e rilascia le sue risorse dopo che quelli sono stati distrutti. L'esempio copia il vettore di byte della cartella di lavoro restituito da Aspose.Cells nell'array accettato da Aspose.Slides.

L'esempio crea una nuova presentazione con un frame OLE di 9.5 × 4 pollici posizionato a 0.5 pollici dal margine sinistro e a 1 pollice dall'alto. Le coordinate e le dimensioni della diapositiva sono in punti (72 punti per pollice). Per una presentazione esistente, vedi [Usa un modello](#use-a-template).

## **Imposta una dimensione fissa del grafico**

Imposta [Chart::SetSizeWithWindow](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/setsizewithwindow/) a false in modo che le dimensioni del grafico siano indipendenti dalla finestra della cartella di lavoro. Imposta le dimensioni di [Chart::GetChartObject](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/getchartobject/) tramite [Shape::SetWidth](https://reference.aspose.com/cells/cpp/aspose.cells.drawing/shape/setwidth/) e [Shape::SetHeight](https://reference.aspose.com/cells/cpp/aspose.cells.drawing/shape/setheight/), convertendo i punti in pixel usando 96 pixel per pollice: un frame di 684 × 288 punti corrisponde a un grafico di 912 × 384 pixel. Imposta [Chart::SetPrintSize](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/setprintsize/) sul valore Custom di [PrintSizeType](https://reference.aspose.com/cells/cpp/aspose.cells/printsizetype/). L'esempio incorpora la cartella di lavoro con [IShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addoleobjectframe/) e salva una presentazione con un frame OLE di 9.5 × 4 pollici.

```cpp
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Chart.h"
#include "Aspose.Cells/ChartCollection.h"
#include "Aspose.Cells/ChartShape.h"
#include "Aspose.Cells/ChartType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/PrintSizeType.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/SeriesCollection.h"
#include "Aspose.Cells/SheetType.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include <algorithm>
#include <cstdint>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;

Aspose::Cells::Startup();
{
    Aspose::Cells::Workbook workbook;
    auto dataSheet = workbook.GetWorksheets().Get(0);
    dataSheet.SetName(u"Data");
    dataSheet.GetCells().Get(u"A1").PutValue(10);
    dataSheet.GetCells().Get(u"A2").PutValue(20);

    auto chartSheetIndex = workbook.GetWorksheets().Add(Aspose::Cells::SheetType::Chart);
    auto chartSheet = workbook.GetWorksheets().Get(chartSheetIndex);
    auto chartIndex = chartSheet.GetCharts().Add(Aspose::Cells::Charts::ChartType::Column, 0, 0, 20, 10);
    auto chart = chartSheet.GetCharts().Get(chartIndex);
    chart.GetNSeries().Add(u"Data!A1:A2", true);
    workbook.GetWorksheets().SetActiveSheetIndex(chartSheetIndex);

    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Le coordinate e le dimensioni della diapositiva sono in punti (72 punti per pollice).
    auto width = 684.f; // 9,5 pollici.
    auto height = 288.f; // 4 pollici.

    chart.SetSizeWithWindow(false);
    // Converti i punti in pixel del grafico usando 96 pixel per pollice.
    chart.GetChartObject().SetWidth(static_cast<int32_t>(width / 72.f * 96.f));
    chart.GetChartObject().SetHeight(static_cast<int32_t>(height / 72.f * 96.f));
    chart.SetPrintSize(Aspose::Cells::PrintSizeType::Custom);

    auto workbookData = workbook.Save(Aspose::Cells::SaveFormat::Excel97To2003);
    // Copia il vettore di byte di Cells nell'array accettato da Slides.
    auto workbookBytes = System::MakeArray<uint8_t>(workbookData.GetLength(), 0);
    std::copy(workbookData.GetData(), workbookData.GetData() + workbookData.GetLength(), workbookBytes->data_ptr());
    auto dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookBytes, u"xls");
    slide->get_Shapes()->AddOleObjectFrame(36, 72, width, height, dataInfo);

    presentation->Save(u"chart-fixed-size.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
    presentation->Dispose();
}
Aspose::Cells::Cleanup();
```

## **Usa un modello**

La logica di dimensionamento è la stessa per una presentazione esistente. Per adattare l'esempio:

1. Carica la presentazione modello invece di creare una presentazione vuota.  
2. Verifica che la prima diapositiva contenga almeno tre forme, quindi utilizza la forma all'indice 2 come segnaposto.  
3. Prendi la larghezza e l'altezza del frame da quella forma invece di usare i valori fissi 684 e 288. Mantieni inalterati i calcoli delle dimensioni.  
4. Aggiungi il frame OLE nella posizione del segnaposto invece delle coordinate fisse 36 e 72.  
5. Rimuovi il segnaposto prima di salvare la presentazione.

## **FAQ**

**Perché il mio grafico Excel incorporato cambia dimensione dopo averlo attivato in PowerPoint?**  
Questo accade perché Excel tenta di ripristinare le dimensioni originali della finestra al primo avvio, mentre il frame OLE in PowerPoint ha proprie dimensioni. PowerPoint ed Excel negoziano le dimensioni per mantenere il rapporto d'aspetto, il che può provocare il ridimensionamento.

**Come posso mantenere coerenti le dimensioni del grafico e del frame OLE?**  
Imposta dimensioni fisse del grafico che corrispondano al frame OLE e utilizza una dimensione di stampa del grafico personalizzata prima di incorporare la cartella di lavoro. L'esempio sopra mostra le impostazioni necessarie e le conversioni di unità.

**È sufficiente far corrispondere le dimensioni della finestra della cartella di lavoro?**  
Far corrispondere solo le dimensioni della finestra della cartella di lavoro non impedisce in modo affidabile al frame OLE di cambiare dimensione dopo l'attivazione. Usa dimensioni fisse del grafico come mostrato nell'esempio.

**Questa soluzione funziona sia con presentazioni basate su modello sia con presentazioni nuove?**  
Sì. Per un modello, utilizza le dimensioni e la posizione del segnaposto. Per una nuova presentazione, specifica direttamente le dimensioni e la posizione del frame.

**Posso utilizzare questo esempio con grafici creati in altri programmi di foglio di calcolo?**  
L'esempio utilizza una cartella di lavoro Excel creata con Aspose.Cells. Non dimostra il comportamento di attivazione per altri programmi di foglio di calcolo.

## **Sezioni correlate**

- [Crea grafici Excel e incorporali come oggetti OLE nelle presentazioni](/slides/it/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)