---
title: Soluzione funzionante per il ridimensionamento del foglio di lavoro
type: docs
weight: 130
url: /it/cpp/working-solution-for-worksheet-resizing/
keywords:
- OLE
- immagine di anteprima
- ridimensionamento immagine
- Excel
- foglio di lavoro
- PowerPoint
- presentazione
- C++
- Aspose.Slides per C++
description: "Soluzione funzionante per il ridimensionamento del foglio di lavoro nelle presentazioni PowerPoint usando C++"
---
{{% alert color="info" title="Note" %}}

I fogli di lavoro Excel incorporati come oggetti OLE in una presentazione PowerPoint usando i componenti Aspose possono ridimensionarsi in modo inatteso dopo la prima attivazione. Questo comportamento crea una differenza visiva evidente tra l'oggetto OLE prima e dopo l'attivazione. Questo articolo spiega il problema e descrive due modi per risolverlo.

{{% /alert %}}

## **Contesto**

Nell'articolo [Gestisci OLE](/slides/it/cpp/manage-ole/), abbiamo spiegato come aggiungere un frame OLE a una presentazione PowerPoint usando Aspose.Slides per C++. Per risolvere il [problema di anteprima dell'oggetto](/slides/it/cpp/object-preview-issue-when-adding-oleobjectframe/), abbiamo assegnato un'immagine dell'area del foglio di lavoro selezionata al frame dell'oggetto OLE. Nella presentazione risultante, quando fai doppio clic sul frame OLE che mostra l'immagine del foglio di lavoro, il workbook di Excel viene attivato. Gli utenti finali possono apportare le modifiche desiderate al vero workbook di Excel e poi tornare alla diapositiva facendo clic al di fuori del workbook di Excel attivato. La dimensione del frame OLE cambierà quando l'utente torna alla diapositiva. Il fattore di ridimensionamento varrà a seconda della dimensione del frame OLE e del workbook Excel incorporato.

## **Causa del ridimensionamento**

Poiché il workbook Excel ha la propria dimensione della finestra, tenta di mantenere la dimensione originale al primo avvio. D'altro canto, il frame dell'oggetto OLE ha la propria dimensione. Secondo Microsoft, quando il workbook Excel è attivato, Excel e PowerPoint negoziano la dimensione per garantire che mantenga le proporzioni corrette nel processo di incorporamento. Il ridimensionamento avviene in base alle differenze tra la dimensione della finestra di Excel e le dimensioni e la posizione del frame OLE.

## **Soluzione funzionante**

Ci sono due soluzioni possibili per evitare l'effetto di ridimensionamento.

- Scala il frame OLE nella presentazione PowerPoint per far corrispondere l'altezza e la larghezza totali delle righe e colonne selezionate.
- Mantieni costante la dimensione del frame OLE e scala le righe e colonne selezionate per adattarle al suo interno.

### **Scala le dimensioni del frame OLE**

Questo approccio imposta la dimensione del frame OLE per far corrispondere l'altezza e la larghezza totali delle righe e colonne selezionate nel foglio di lavoro Excel incorporato.

L'esempio carica un workbook Excel esistente e seleziona le prime 10 righe e le prime 13 colonne del suo primo foglio di lavoro usando indici base zero. [WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) definisce l'intervallo visualizzato. L'anteprima è renderizzata a 96 DPI e le sue dimensioni in pixel sono convertite in punti usando 72 punti per pollice. [ShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addoleobjectframe/) incorpora il workbook modificato in un frame con quelle dimensioni. L'anteprima è assegnata tramite [OleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/get_substitutepictureformat/) per sostituire il segnaposto "EMBEDDED OLE OBJECT" nella presentazione salvata.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <drawing/image.h>
#include <system/array.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// Set the displayed size when the workbook file is used as an OLE object in PowerPoint.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
auto imageStream = CreateOleImage(cellRange, imageResolution);

// Get the width and height of the OLE image in points.
auto image = Image::FromStream(imageStream);
auto imageWidth = image->get_Width() * 72.0f / imageResolution;
auto imageHeight = image->get_Height() * 72.0f / imageResolution;

// We need to use the modified workbook.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Add the OLE image to the presentation resources.
auto oleImage = presentation->get_Images()->AddImage(image);
image->Dispose();

// Create the OLE object frame.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

L'aiutante di anteprima utilizza [PageSetup::SetPrintArea](https://reference.aspose.com/cells/cpp/aspose.cells/pagesetup/setprintarea/) per selezionare l'intervallo e rimuove margini, intestazioni e piè di pagina. Con [ImageOrPrintOptions::SetOnlyArea](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/imageorprintoptions/setonlyarea/) abilitato, [SheetRender::ToImage](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/sheetrender/toimage/) renderizza l'intervallo come immagine PNG. L'aiutante copia i dati dell'immagine renderizzata in un nuovo stream di memoria posizionato all'inizio per l'uso nella presentazione.

```cpp
#include <system/array.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/ImageOrPrintOptions.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/PageSetup.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/SheetRender.h"
#include "Aspose.Cells/Worksheet.h"

using namespace System;
using namespace System::IO;

SharedPtr<MemoryStream> CreateOleImage(Aspose::Cells::Range cellRange, int imageResolution)
{
    auto pageSetup = cellRange.GetWorksheet().GetPageSetup();
    pageSetup.SetPrintArea(cellRange.GetAddress());
    pageSetup.SetLeftMargin(0);
    pageSetup.SetRightMargin(0);
    pageSetup.SetTopMargin(0);
    pageSetup.SetBottomMargin(0);
    pageSetup.ClearHeaderFooter();

    Aspose::Cells::ImageOrPrintOptions imageOptions;
    imageOptions.SetImageType(Aspose::Cells::ImageType::Png);
    imageOptions.SetVerticalResolution(imageResolution);
    imageOptions.SetHorizontalResolution(imageResolution);
    imageOptions.SetOnePagePerSheet(true);
    imageOptions.SetOnlyArea(true);

    Aspose::Cells::SheetRender sheetRender(cellRange.GetWorksheet(), imageOptions);
    auto renderData = sheetRender.ToImage(0);
    auto imageData = MakeObject<Array<uint8_t>>(renderData.GetLength(), renderData.GetData());
    auto imageStream = MakeObject<MemoryStream>(imageData);
    sheetRender.Dispose();

    return imageStream;
}
```

### **Scala le dimensioni dell'intervallo di celle**

Questo approccio scala le altezze delle righe selezionate e le larghezze delle colonne selezionate per far corrispondere una dimensione personalizzata del frame OLE.

L'esempio carica un workbook Excel esistente e seleziona le prime 10 righe e le prime 13 colonne del suo primo foglio di lavoro usando indici base zero. [WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) definisce l'intervallo visualizzato, e l'aiutante sottostante scala quell'intervallo per adattarlo a un frame largo 400 punti e alto 100 punti. Dopo aver salvato il workbook modificato in un array di byte, [ShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addoleobjectframe/) lo incorpora nella dimensione specificata. Un'anteprima renderizzata a 96 DPI è assegnata tramite [OleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/get_substitutepictureformat/), così la presentazione salvata mostra le celle selezionate invece del segnaposto predefinito.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/array.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;

Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// Imposta le dimensioni visualizzate quando il file del workbook è usato come oggetto OLE in PowerPoint.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

// Scala l'intervallo di celle per adattarlo alle dimensioni del frame.
auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

auto imageStream = CreateOleImage(cellRange, imageResolution);

// È necessario utilizzare il workbook modificato.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Aggiungi l'immagine OLE alle risorse della presentazione.
auto oleImage = presentation->get_Images()->AddImage(imageStream);
imageStream->Dispose();

// Crea il frame dell'oggetto OLE.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

L'aiutante di scaling calcola rapporti separati di larghezza e altezza per l'intervallo selezionato, preservando le larghezze relative delle colonne e le altezze relative delle righe. Converte le dimensioni calcolate da punti a pollici prima di applicarle con [Cells::SetColumnWidthInch](https://reference.aspose.com/cells/cpp/aspose.cells/cells/setcolumnwidthinch/) e [Cells::SetRowHeightInch](https://reference.aspose.com/cells/cpp/aspose.cells/cells/setrowheightinch/). L'intervallo selezionato deve avere larghezza e altezza diverse da zero.

```cpp
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/CellsUnitType.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/Worksheet.h"

/// <param name="width">La larghezza prevista dell'intervallo di celle in punti.</param>
/// <param name="height">L'altezza prevista dell'intervallo di celle in punti.</param>
void ScaleCellRange(Aspose::Cells::Range cellRange, float width, float height)
{
    auto rangeWidth = cellRange.GetWidth();
    auto rangeHeight = cellRange.GetHeight();

    for (int i = 0; i < cellRange.GetColumnCount(); i++)
    {
        auto columnIndex = cellRange.GetFirstColumn() + i;
        auto columnWidth = cellRange.GetWorksheet().GetCells().GetColumnWidth(columnIndex, false, Aspose::Cells::CellsUnitType::Point);

        auto newColumnWidth = columnWidth * width / rangeWidth;
        auto widthInInches = newColumnWidth / 72;
        cellRange.GetWorksheet().GetCells().SetColumnWidthInch(columnIndex, widthInInches);
    }

    for (int i = 0; i < cellRange.GetRowCount(); i++)
    {
        auto rowIndex = cellRange.GetFirstRow() + i;
        auto rowHeight = cellRange.GetWorksheet().GetCells().GetRowHeight(rowIndex, false, Aspose::Cells::CellsUnitType::Point);

        auto newRowHeight = rowHeight * height / rangeHeight;
        auto heightInInches = newRowHeight / 72;
        cellRange.GetWorksheet().GetCells().SetRowHeightInch(rowIndex, heightInInches);
    }
}
```

Questo aiutante di anteprima renderizza l'intervallo ridimensionato usando [SheetRender::ToImage](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/sheetrender/toimage/). Utilizza [PageSetup::SetPrintArea](https://reference.aspose.com/cells/cpp/aspose.cells/pagesetup/setprintarea/) per limitare la stampa a quell'intervallo, rimuove margini, intestazioni e piè di pagina, e restituisce uno stream PNG posizionato all'inizio.

```cpp
#include <system/array.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/ImageOrPrintOptions.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/PageSetup.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/SheetRender.h"
#include "Aspose.Cells/Worksheet.h"

using namespace System;
using namespace System::IO;

SharedPtr<MemoryStream> CreateOleImage(Aspose::Cells::Range cellRange, int imageResolution)
{
    auto pageSetup = cellRange.GetWorksheet().GetPageSetup();
    pageSetup.SetPrintArea(cellRange.GetAddress());
    pageSetup.SetLeftMargin(0);
    pageSetup.SetRightMargin(0);
    pageSetup.SetTopMargin(0);
    pageSetup.SetBottomMargin(0);
    pageSetup.ClearHeaderFooter();

    Aspose::Cells::ImageOrPrintOptions imageOptions;
    imageOptions.SetImageType(Aspose::Cells::ImageType::Png);
    imageOptions.SetVerticalResolution(imageResolution);
    imageOptions.SetHorizontalResolution(imageResolution);
    imageOptions.SetOnePagePerSheet(true);
    imageOptions.SetOnlyArea(true);

    Aspose::Cells::SheetRender sheetRender(cellRange.GetWorksheet(), imageOptions);
    auto renderData = sheetRender.ToImage(0);
    auto imageData = MakeObject<Array<uint8_t>>(renderData.GetLength(), renderData.GetData());
    auto imageStream = MakeObject<MemoryStream>(imageData);
    sheetRender.Dispose();

    return imageStream;
}
```

## **Conclusione**

{{% alert color="info" title="Note" %}}

Ci sono due approcci per risolvere il problema di ridimensionamento del foglio di lavoro. Scegli l'approccio che meglio si adatta alle tue esigenze e al caso d'uso. Entrambi gli approcci funzionano allo stesso modo, sia che le presentazioni siano create da un modello sia da zero. Inoltre, non esiste alcun limite alla dimensione del frame OLE in questa soluzione.

{{% /alert %}}

## **FAQ**

**Perché un foglio di lavoro Excel incorporato cambia dimensione quando viene attivato per la prima volta in PowerPoint?**

Questo accade perché Excel tenta di mantenere la dimensione originale della finestra quando è attivato, mentre il frame OLE in PowerPoint ha proprie dimensioni. PowerPoint ed Excel negoziano la dimensione per mantenere le proporzioni, il che può causare il ridimensionamento.

**È possibile evitare completamente questo problema di ridimensionamento?**

Sì. Scalando il frame OLE per adattarlo alle dimensioni dell'intervallo di celle Excel o scalando l'intervallo di celle per adattarlo alla dimensione desiderata del frame OLE, è possibile prevenire il ridimensionamento indesiderato.

**Quale metodo di scaling dovrei usare, scaling del frame OLE o scaling dell'intervallo di celle?**

Seleziona **OLE frame scaling** se vuoi mantenere le dimensioni originali delle righe e colonne di Excel. Seleziona **cell range scaling** se desideri una dimensione fissa per il frame OLE nella tua presentazione.

**Queste soluzioni funzioneranno se la mia presentazione è basata su un modello?**

Sì. Entrambe le soluzioni funzionano per presentazioni create da modelli e da zero.

**Esiste un limite alla dimensione del frame OLE quando si usano questi metodi?**

No. Puoi impostare il frame OLE a qualsiasi dimensione purché la scala sia impostata correttamente.

**C'è un modo per evitare il testo segnaposto "EMBEDDED OLE OBJECT" in PowerPoint?**

Sì. Scattando un'istantanea dell'intervallo di celle Excel target e impostandola come immagine segnaposto del frame OLE, puoi visualizzare un'immagine di anteprima personalizzata al posto del segnaposto predefinito.

## **Articoli correlati**

[Creare un grafico Excel e incorporarlo in una presentazione come oggetto OLE](/slides/it/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)