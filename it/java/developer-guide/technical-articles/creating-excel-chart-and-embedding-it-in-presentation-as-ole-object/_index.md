---
title: Creare grafici Excel e incorporarli nelle presentazioni come oggetti OLE
type: docs
weight: 30
url: /it/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Grafico Excel
- incorporare grafico
- oggetto OLE
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Crea grafici Excel e incorporali come oggetti OLE in presentazioni PowerPoint e OpenDocument con Java. Guida passo passo con esempi di codice."
---
## **Contesto**

In PowerPoint, l'uso di grafici modificabili per visualizzare i dati in modo grafico è una pratica comune. Aspose supporta la creazione di grafici Excel con Aspose.Cells per Java, e questi grafici possono quindi essere incorporati come oggetti OLE nelle diapositive PowerPoint tramite Aspose.Slides per Java. Questo articolo descrive i passaggi necessari e fornisce esempi di codice Java per creare un grafico Excel e incorporarlo come oggetto OLE in una presentazione PowerPoint usando Aspose.Cells e Aspose.Slides.

## **Passaggi richiesti**

La seguente sequenza di passaggi è necessaria per creare e incorporare un grafico Excel come oggetto OLE in una diapositiva PowerPoint:

1. Creare un grafico Excel utilizzando Aspose.Cells.
2. Impostare le dimensioni OLE del grafico Excel utilizzando Aspose.Cells.
3. Ottenere un'immagine del grafico Excel con Aspose.Cells.
4. Incorporare il grafico Excel come oggetto OLE in una presentazione PPTX utilizzando Aspose.Slides.
5. Sostituire l'immagine "EMBEDDED OLE OBJECT" con l'immagine ottenuta al passaggio 3 per risolvere il [problema di anteprima dell'oggetto](/slides/it/java/object-preview-issue-when-adding-oleobjectframe/).
6. Salvare la presentazione su disco in formato PPTX.

## **Implementazione dei passaggi richiesti**

L'implementazione Java dei passaggi precedenti è la seguente:

```java
// Crea una cartella di lavoro.
Workbook workbook = new Workbook();

// Aggiungi un grafico Excel.
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(workbook, chartRows, chartCols);

// Imposta le dimensioni OLE del grafico.
workbook.getWorksheets().setOleSize(0, chartRows, 0, chartCols);

// Ottieni l'immagine del grafico e salvala in uno stream.
com.aspose.cells.ImageOrPrintOptions printOptions = new com.aspose.cells.ImageOrPrintOptions();
printOptions.setImageFormat(com.aspose.cells.ImageFormat.getPng());
ByteArrayOutputStream imageStream = new ByteArrayOutputStream();
workbook.getWorksheets().get(chartSheetIndex).getCharts().get(0).toImage(imageStream, printOptions);

// Salva la cartella di lavoro in uno stream.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream(); 
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);

// Crea una presentazione.
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Aggiungi la cartella di lavoro a una diapositiva.
AddExcelChartInPresentation(presentation, slide, workbookStream.toByteArray(), imageStream.toByteArray());

// Salva la presentazione su disco.
presentation.save("OutputChart.pptx", SaveFormat.Pptx);
presentation.dispose();
```

```java
static void AddExcelChartInPresentation(Presentation presentation, ISlide slide, byte[] workbookArray, byte[] chartImage) throws Exception
{
    double oleHeight = presentation.getSlideSize().getSize().getHeight();
    double oleWidth = presentation.getSlideSize().getSize().getWidth();
 
    // Crea un oggetto LoadOptions EXCEL_97_TO_2003.
    com.aspose.cells.LoadOptions loadOptions = new com.aspose.cells.LoadOptions(com.aspose.cells.FileFormatType.EXCEL_97_TO_2003);         
    Workbook workbook = new Workbook(new ByteArrayInputStream(workbookArray),loadOptions);
 
    IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(0f, 0f, (float)oleWidth, (float)oleHeight, "Excel.Sheet.8", workbookArray);
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(presentation.getImages().addImage(new ByteArrayInputStream(chartImage)));
}
```

```java
static int AddExcelChartInWorkbook(Workbook workbook, int chartRows, int chartCols)
{
    // Un array di nomi di celle.
    String[] cellNames = new String[]
    {
        "A1", "A2", "A3", "A4",
        "B1", "B2", "B3", "B4",
        "C1", "C2", "C3", "C4",
        "D1", "D2", "D3", "D4",
        "E1", "E2", "E3", "E4"
    };

    // Un array di dati delle celle.
    int[] cellValues = new int[]
    {
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25
    };

    // Aggiungi un nuovo foglio di lavoro per popolare le celle con i dati.
    int dataSheetIndex = workbook.getWorksheets().add();
    Worksheet dataSheet = workbook.getWorksheets().get(dataSheetIndex);
    String sheetName = "DataSheet";
    dataSheet.setName(sheetName);

    // Popola il foglio dati con i dati.
    int size = Array.getLength(cellNames);
    for (int i = 0; i < size; i++)
    {
        String cellName = cellNames[i];
        int cellValue = cellValues[i];
        dataSheet.getCells().get(cellName).setValue(cellValue);
    }

    // Aggiungi un foglio grafico.
    int worksheetIndex = workbook.getWorksheets().add(SheetType.CHART);
    Worksheet chartSheet = workbook.getWorksheets().get(worksheetIndex);
    chartSheet.setName("ChartSheet");
    int chartSheetIndex = chartSheet.getIndex();

    // Aggiungi un grafico al foglio grafico con le serie di dati dal foglio dati.
    int chartIndex = chartSheet.getCharts().add(ChartType.COLUMN, 0, chartRows, 0, chartCols);
    Chart chart = chartSheet.getCharts().get(chartIndex);
    
    chart.getNSeries().add(sheetName + "!A1:E1", false);
    chart.getNSeries().add(sheetName + "!A2:E2", false);
    chart.getNSeries().add(sheetName + "!A3:E3", false);
    chart.getNSeries().add(sheetName + "!A4:E4", false);

    // Imposta il foglio grafico come foglio attivo.
    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
    return chartSheetIndex;
}
```

La presentazione creata con il metodo sopra conterrà il grafico Excel come oggetto OLE che può essere attivato facendo doppio clic sul frame dell'oggetto OLE.

## **Conclusione**

Utilizzando Aspose.Cells per Java insieme a Aspose.Slides per Java, possiamo creare qualsiasi grafico Excel supportato da Aspose.Cells e incorporare il grafico come oggetto OLE in una diapositiva PowerPoint. È inoltre possibile definire le dimensioni OLE del grafico Excel. Gli utenti finali possono quindi modificare il grafico Excel come qualsiasi altro oggetto OLE.

## **Sezioni correlate**

- [Soluzione funzionante per il ridimensionamento dei grafici in PPTX](/slides/it/java/working-solution-for-chart-resizing-in-pptx/)
- [Problema di anteprima dell'oggetto quando si aggiunge OleObjectFrame](/slides/it/java/object-preview-issue-when-adding-oleobjectframe/)
- [Aggiorna gli oggetti OLE automaticamente usando un componente aggiuntivo PowerPoint](/slides/it/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)