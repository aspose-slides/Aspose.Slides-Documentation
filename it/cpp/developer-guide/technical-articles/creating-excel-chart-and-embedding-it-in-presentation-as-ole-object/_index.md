---
title: Crea grafici Excel e incorporali nelle presentazioni come oggetti OLE
type: docs
weight: 40
url: /it/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Grafico Excel
- incorpora grafico
- oggetto OLE
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Crea un grafico Excel con Aspose.Cells per C++ e incorpora la cartella di lavoro in una presentazione PowerPoint con Aspose.Slides, includendo un'anteprima del grafico."
---
## **Panoramica**

Questo articolo mostra come creare un grafico a colonne di Excel con Aspose.Cells per C++ e incorporare la sua cartella di lavoro in una presentazione PowerPoint con Aspose.Slides per C++. La cartella di lavoro incorporata contiene sia i dati di origine sia il grafico. Un'anteprima PNG separata visualizza il grafico sulla diapositiva prima che l'oggetto OLE venga attivato.

Il risultato è un oggetto Excel incorporato, non un grafico PowerPoint nativo. Modificare la cartella di lavoro tramite OLE richiede un'applicazione desktop che supporti l'attivazione OLE e un'installazione di Excel compatibile.

## **Prerequisiti**

Configura il tuo progetto C++ con gli header e le librerie per Aspose.Cells per C++ e Aspose.Slides per C++. Posiziona il codice di esempio nel punto di ingresso della tua applicazione, con le dichiarazioni include a livello di file. Microsoft Office non è richiesto per generare la presentazione con queste librerie.

Nessun file di input è richiesto: l'esempio crea i dati e il grafico in memoria, quindi scrive `OutputChart.pptx` nella directory di lavoro corrente. Applica le licenze per entrambi i prodotti quando esegui al di fuori della modalità di valutazione.

## **Come funziona l'incorporamento**

1. Crea una cartella di lavoro con un foglio dati e un foglio grafico.  
2. Rendi attivo il foglio grafico in modo che la cartella di lavoro si apra sul grafico.  
3. Imposta l'intervallo di visualizzazione OLE della cartella di lavoro e genera il grafico in PNG.  
4. Salva la cartella di lavoro come XLSX in memoria e incorpora quei byte in una diapositiva.  
5. Assegna il PNG come anteprima dell'oggetto OLE e salva la presentazione come PPTX.

L'intervallo di visualizzazione della cartella di lavoro e il riquadro sulla diapositiva hanno ruoli diversi. [WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) prende indici di riga e colonna di inizio/fine basati su zero. [ChartCollection::Add](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chartcollection/add/) prende invece la riga superiore, la colonna sinistra, la riga inferiore e la colonna destra. L'esempio utilizza l'indice di riga 55 e l'indice di colonna 25 come limiti in basso a destra; questi valori sono scelte di layout, non il numero di righe o colonne di dati.

Il riquadro della diapositiva utilizza i punti. L'esempio lo adatta all'interno della diapositiva e lo centra preservando il rapporto d'aspetto del PNG, invece di allungare l'anteprima per riempire la diapositiva.

## **Crea e incorpora il grafico**

Il seguente esempio completo popola `DataSheet` con quattro righe e cinque colonne di valori. Ogni riga diventa una serie del grafico. `ChartSheet` è selezionato come foglio attivo prima che la cartella di lavoro venga salvata.

La cartella di lavoro è salvata esplicitamente come XLSX, corrispondente all'estensione `xlsx` passata a [OleEmbeddedDataInfo](https://reference.aspose.com/slides/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/). Il PNG è caricato da uno stream in memoria senza una conversione bitmap intermedia. Aspose.Cells restituisce vettori di byte, che l'esempio copia nel tipo di array accettato da Aspose.Slides. Inizializza Aspose.Cells prima di usare i suoi oggetti e rilascia le sue risorse dopo che quegli oggetti sono stati distrutti. Assegnandolo attraverso [IOleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/get_substitutepictureformat/) sostituisce il segnaposto OLE predefinito.

```cpp
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Chart.h"
#include "Aspose.Cells/ChartCollection.h"
#include "Aspose.Cells/ChartType.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/SeriesCollection.h"
#include "Aspose.Cells/SheetType.h"
#include "Aspose.Cells/U16String.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
#include <DOM/IImageCollection.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <Util/Images.h>
#include <drawing/size_f.h>
#include <system/array.h>
#include <system/io/memory_stream.h>
#include <algorithm>
#include <IImage.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;

// Inizializza Cells prima di creare qualsiasi suo oggetto.
Aspose::Cells::Startup();
{
    Aspose::Cells::Workbook workbook;
    auto dataSheet = workbook.GetWorksheets().Get(0);
    dataSheet.SetName(u"DataSheet");

    int32_t values[4][5] =
    {
        { 67, 44, 46, 43, 24 },
        { 86, 64, 97, 29, 40 },
        { 68, 89, 78, 69, 38 },
        { 91, 48, 60, 26, 25 }
    };

    for (auto row = 0; row < 4; row++)
    {
        for (auto column = 0; column < 5; column++)
        {
            dataSheet.GetCells().Get(row, column).PutValue(values[row][column]);
        }
    }

    auto chartSheetIndex = workbook.GetWorksheets().Add(Aspose::Cells::SheetType::Chart);
    auto chartSheet = workbook.GetWorksheets().Get(chartSheetIndex);
    chartSheet.SetName(u"ChartSheet");

    auto lastChartRow = 55;
    auto lastChartColumn = 25;
    auto chartIndex = chartSheet.GetCharts().Add(Aspose::Cells::Charts::ChartType::Column, 0, 0, lastChartRow, lastChartColumn);
    auto chart = chartSheet.GetCharts().Get(chartIndex);
    const char16_t* seriesRanges[] = { u"DataSheet!A1:E1", u"DataSheet!A2:E2", u"DataSheet!A3:E3", u"DataSheet!A4:E4" };
    for (auto range : seriesRanges)
    {
        chart.GetNSeries().Add(range, false);
    }

    workbook.GetWorksheets().SetActiveSheetIndex(chartSheetIndex);
    workbook.GetWorksheets().SetOleSize(0, lastChartRow, 0, lastChartColumn);

    // Genera l'anteprima del grafico e serializza separatamente la cartella di lavoro modificabile.
    auto chartImageData = chart.ToImage(Aspose::Cells::Drawing::ImageType::Png);
    auto workbookData = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);

    // Copia i buffer di Cells nel tipo di array utilizzato da Slides.
    auto toSlidesArray = [](const Aspose::Cells::Vector<uint8_t>& buffer)
    {
        auto result = System::MakeArray<uint8_t>(buffer.GetLength(), 0);
        std::copy(buffer.GetData(), buffer.GetData() + buffer.GetLength(), result->data_ptr());
        return result;
    };
    auto chartImageBytes = toSlidesArray(chartImageData);
    auto workbookBytes = toSlidesArray(workbookData);
    auto chartImageStream = System::MakeObject<System::IO::MemoryStream>(chartImageBytes);
    auto chartImage = Images::FromStream(chartImageStream);

    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);
    auto slideSize = presentation->get_SlideSize()->get_Size();

    // Adatta l'anteprima alla diapositiva senza modificare il rapporto d'aspetto.
    auto scale = (std::min)(slideSize.get_Width() / chartImage->get_Width(), slideSize.get_Height() / chartImage->get_Height());
    auto frameWidth = chartImage->get_Width() * scale;
    auto frameHeight = chartImage->get_Height() * scale;
    auto frameX = (slideSize.get_Width() - frameWidth) / 2;
    auto frameY = (slideSize.get_Height() - frameHeight) / 2;

    auto embeddedData = System::MakeObject<OleEmbeddedDataInfo>(workbookBytes, u"xlsx");
    auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
    auto previewImage = presentation->get_Images()->AddImage(chartImage);
    oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(previewImage);

    presentation->Save(u"OutputChart.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
    presentation->Dispose();
    chartImage->Dispose();
    chartImageStream->Dispose();
}
// Rilascia le risorse di Cells dopo che tutti gli oggetti Cells sono stati distrutti.
Aspose::Cells::Cleanup();
```

## **Risultato previsto**

`OutputChart.pptx` contiene una diapositiva con una cartella di lavoro Excel incorporata e un'anteprima del grafico. La cartella di lavoro contiene i dati originali e un grafico a colonne con quattro serie. L'anteprima è centrata sulla diapositiva e ne conserva le proporzioni.

![Grafico a colonne di Excel visualizzato come anteprima di una cartella di lavoro incorporata](excel-chart-ole-preview.png)

In un ambiente desktop PowerPoint compatibile con Excel disponibile, fai doppio clic sull'oggetto per attivare e modificare la cartella di lavoro incorporata. L'attivazione e la modifica dipendono dal supporto OLE dell'applicazione host e dalle impostazioni di sicurezza.

## **FAQ**

**Perché è necessaria un'immagine di anteprima?**

La cartella di lavoro incorporata e la sua anteprima sulla diapositiva sono contenuti separati. Fornisci un'immagine del grafico in modo che la diapositiva mostri il grafico invece del segnaposto predefinito "EMBEDDED OLE OBJECT". Vedi [Problema di anteprima dell'oggetto quando si aggiunge OleObjectFrame](/slides/it/cpp/object-preview-issue-when-adding-oleobjectframe/).

**L'anteprima si aggiorna automaticamente quando modifico la cartella di lavoro nel codice?**

Considera l'anteprima come un'istantanea. Quando aggiorni i dati della cartella di lavoro programmaticamente, rigenera l'immagine del grafico e sostituisci sia l'anteprima sia i dati della cartella di lavoro incorporata.

**Posso usare XLS invece di XLSX?**

Sì. Salva la cartella di lavoro in formato XLS e usa `xls` come estensione dei dati incorporati. L'estensione deve corrispondere al formato reale della cartella di lavoro; cambiare solo l'estensione non converte i dati.

**Perché l'oggetto potrebbe cambiare dimensione dopo l'attivazione?**

L'applicazione host può aggiornare la presentazione dell'oggetto OLE quando attiva la cartella di lavoro. L'intervallo di visualizzazione OLE della cartella di lavoro e le dimensioni del riquadro della diapositiva sono entrambe rilevanti. Vedi [Soluzione funzionante per il ridimensionamento del grafico in PPTX](/slides/it/cpp/working-solution-for-chart-resizing-in-pptx/).

## **Sezioni correlate**

- [Soluzione funzionante per il ridimensionamento del grafico in PPTX](/slides/it/cpp/working-solution-for-chart-resizing-in-pptx/)
- [Problema di anteprima dell'oggetto quando si aggiunge OleObjectFrame](/slides/it/cpp/object-preview-issue-when-adding-oleobjectframe/)