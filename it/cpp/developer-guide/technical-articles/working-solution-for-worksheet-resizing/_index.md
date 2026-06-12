---
title: Soluzione funzionante per il ridimensionamento dei fogli di lavoro
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
description: "Soluzione funzionante per il ridimensionamento dei fogli di lavoro nelle presentazioni PowerPoint utilizzando C++"
---
{{% alert color="primary" %}}

È stato osservato che i fogli di lavoro Excel incorporati come oggetti OLE in una presentazione PowerPoint tramite componenti Aspose vengono ridimensionati a una scala non identificata dopo la prima attivazione. Questo comportamento crea una differenza visiva evidente nella presentazione tra gli stati pre‑ e post‑attivazione dell’oggetto OLE. Abbiamo esaminato questo problema in dettaglio e fornito una soluzione, che è descritta in questo articolo.

{{% /alert %}}

## **Contesto**

Nell'articolo [Gestisci OLE](/slides/it/cpp/manage-ole/), abbiamo spiegato come aggiungere un riquadro OLE a una presentazione PowerPoint utilizzando Aspose.Slides per C++. Per affrontare il [problema anteprima oggetto](/slides/it/cpp/object-preview-issue-when-adding-oleobjectframe/), abbiamo assegnato un'immagine dell'area del foglio di lavoro selezionata al riquadro OLE. Nella presentazione di output, quando si fa doppio clic sul riquadro OLE che visualizza l'immagine del foglio, il workbook Excel viene attivato. Gli utenti finali possono apportare le modifiche desiderate al workbook Excel reale e poi tornare alla diapositiva facendo clic al di fuori del workbook Excel attivato. La dimensione del riquadro OLE cambierà quando l'utente ritorna alla diapositiva. Il fattore di ridimensionamento varierà a seconda delle dimensioni del riquadro OLE e del workbook Excel incorporato.

## **Causa del ridimensionamento**

Poiché il workbook Excel ha una propria dimensione della finestra, cerca di mantenere la sua dimensione originale alla prima attivazione. D'altra parte, il riquadro OLE ha una propria dimensione. Secondo Microsoft, quando il workbook Excel è attivato, Excel e PowerPoint negoziano la dimensione per garantire che mantenga le proporzioni corrette come parte del processo di incorporamento. Il ridimensionamento avviene in base alle differenze tra la dimensione della finestra di Excel e le dimensioni e la posizione del riquadro OLE.

## **Soluzione funzionante**

Esistono due possibili soluzioni per evitare l'effetto di ridimensionamento.

- Scala la dimensione del riquadro OLE nella presentazione PowerPoint per corrispondere all'altezza e alla larghezza del numero desiderato di righe e colonne nel riquadro OLE.
- Mantieni costante la dimensione del riquadro OLE e scala le dimensioni delle righe e colonne partecipanti per adattarle alla dimensione del riquadro OLE selezionato.

### **Scala la dimensione del riquadro OLE**

In questo approccio, impareremo come impostare la dimensione del riquadro OLE del workbook Excel incorporato per corrispondere alla dimensione cumulativa delle righe e colonne partecipanti nel foglio di lavoro Excel.

Supponiamo di avere un foglio Excel modello e di volerlo aggiungere a una presentazione come riquadro OLE. In questo scenario, la dimensione del riquadro OLE verrà prima calcolata in base alle altezze cumulative delle righe e alle larghezze cumulative delle colonne delle righe e colonne partecipanti nel workbook. Successivamente, imposteremo la dimensione del riquadro OLE su questo valore calcolato. Per evitare il messaggio rosso "EMBEDDED OLE OBJECT" per il riquadro OLE in PowerPoint, cattureremo anche un'immagine delle parti desiderate delle righe e colonne nel workbook e la imposteremo come immagine del riquadro OLE.

```cpp
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

```cpp
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

### **Scala la dimensione dell'intervallo di celle**

In questo approccio, impareremo come scalare le altezze delle righe partecipanti e la larghezza delle colonne partecipanti per corrispondere a una dimensione personalizzata del riquadro OLE.

Supponiamo di avere un foglio Excel modello e di volerlo aggiungere a una presentazione come riquadro OLE. In questo scenario, imposteremo la dimensione del riquadro OLE e scaleremo le dimensioni delle righe e delle colonne che partecipano all'area del riquadro OLE. Successivamente salveremo il workbook in uno stream per applicare le modifiche e lo convertirà in un array di byte per aggiungerlo al riquadro OLE. Per evitare il messaggio rosso "EMBEDDED OLE OBJECT" per il riquadro OLE in PowerPoint, cattureremo anche un'immagine delle parti desiderate delle righe e colonne nel workbook e la imposteremo come immagine del riquadro OLE.

```cpp
Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// Imposta la dimensione visualizzata quando il file di workbook viene usato come oggetto OLE in PowerPoint.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

// Scala l'intervallo di celle per adattarlo alle dimensioni del riquadro.
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

// Create the OLE object frame.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

```cpp
/// <param name="width">L'ampiezza prevista dell'intervallo di celle in punti.</param>
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

```cpp
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

{{% alert color="primary" %}}

Esistono due approcci per risolvere il problema di ridimensionamento del foglio di lavoro. La scelta dell'approccio appropriato dipende dai requisiti specifici e dal caso d'uso. Entrambi gli approcci funzionano allo stesso modo, sia che le presentazioni siano create da un modello o da zero. Inoltre, non vi è alcun limite alla dimensione del riquadro OLE in questa soluzione.

{{% /alert %}}

## **FAQ**

**Perché un foglio di lavoro Excel incorporato cambia dimensione quando viene attivato per la prima volta in PowerPoint?**

Questo accade perché Excel tenta di mantenere la dimensione originale della finestra quando viene attivato, mentre il riquadro OLE in PowerPoint ha le proprie dimensioni. PowerPoint ed Excel negoziano la dimensione per mantenere le proporzioni, il che può causare il ridimensionamento.

**È possibile prevenire del tutto questo problema di ridimensionamento?**

Sì. Scalando il riquadro OLE per adattarlo alla dimensione dell'intervallo di celle Excel o scalando l'intervallo di celle per adattarlo alla dimensione desiderata del riquadro OLE, è possibile evitare il ridimensionamento indesiderato.

**Quale metodo di scalatura dovrei usare, scalatura del riquadro OLE o scalatura dell'intervallo di celle?**

Seleziona **scalatura del riquadro OLE** se desideri mantenere le dimensioni originali delle righe e colonne di Excel. Seleziona **scalatura dell'intervallo di celle** se desideri una dimensione fissa per il riquadro OLE nella tua presentazione.

**Queste soluzioni funzioneranno se la mia presentazione è basata su un modello?**

Sì. Entrambe le soluzioni funzionano per presentazioni create da modelli e da zero.

**Esiste un limite alla dimensione del riquadro OLE quando si utilizzano questi metodi?**

No. È possibile impostare il riquadro OLE di qualsiasi dimensione, purché la scala sia impostata in modo appropriato.

**Esiste un modo per evitare il testo segnaposto "EMBEDDED OLE OBJECT" in PowerPoint?**

Sì. Catturando un'istantanea dell'intervallo di celle Excel target e impostandola come immagine segnaposto del riquadro OLE, è possibile visualizzare un'immagine di anteprima personalizzata al posto del segnaposto predefinito.

## **Articoli correlati**

[Creare un grafico Excel e incorporarlo in una presentazione come oggetto OLE](/slides/it/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)