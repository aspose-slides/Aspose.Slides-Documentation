---
title: Criar Gráficos do Excel e Incorporá-los em Apresentações como Objetos OLE
type: docs
weight: 30
url: /pt/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Gráfico do Excel
- incorporar gráfico
- Objeto OLE
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Crie gráficos do Excel e incorpore-os como objetos OLE em apresentações PowerPoint e OpenDocument com Java. Guia passo a passo com exemplos de código."
---
## **Contexto**

No PowerPoint, usar gráficos editáveis para exibir dados graficamente é uma prática comum. Aspose oferece suporte à criação de gráficos do Excel com Aspose.Cells para Java, e esses gráficos podem então ser incorporados como objetos OLE em slides do PowerPoint através do Aspose.Slides para Java. Este artigo aborda as etapas necessárias e fornece exemplos de código Java para criar um gráfico do Excel e incorporá‑lo como um objeto OLE em uma apresentação PowerPoint usando Aspose.Cells e Aspose.Slides.

## **Etapas Necessárias**

A sequência de etapas a seguir é necessária para criar e incorporar um gráfico do Excel como um objeto OLE em um slide do PowerPoint:

1. Criar um gráfico do Excel usando Aspose.Cells.
1. Definir o tamanho OLE do gráfico do Excel usando Aspose.Cells.
1. Obter uma imagem do gráfico do Excel com Aspose.Cells.
1. Incorporar o gráfico do Excel como um objeto OLE em uma apresentação PPTX usando Aspose.Slides.
1. Substituir a imagem "EMBEDDED OLE OBJECT" pela imagem obtida na etapa 3 para resolver o [problema de visualização do objeto](/slides/pt/java/object-preview-issue-when-adding-oleobjectframe/).
1. Salvar a apresentação em disco no formato PPTX.

## **Implementação das Etapas Necessárias**

A implementação em Java das etapas acima é a seguinte:

```java
// Criar uma pasta de trabalho.
Workbook workbook = new Workbook();

// Adicionar um gráfico do Excel.
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(workbook, chartRows, chartCols);

// Definir o tamanho OLE do gráfico.
workbook.getWorksheets().setOleSize(0, chartRows, 0, chartCols);

// Obter a imagem do gráfico e salvá‑la em um fluxo.
com.aspose.cells.ImageOrPrintOptions printOptions = new com.aspose.cells.ImageOrPrintOptions();
printOptions.setImageFormat(com.aspose.cells.ImageFormat.getPng());
ByteArrayOutputStream imageStream = new ByteArrayOutputStream();
workbook.getWorksheets().get(chartSheetIndex).getCharts().get(0).toImage(imageStream, printOptions);

// Salvar a pasta de trabalho em um fluxo.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream(); 
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);

// Criar uma apresentação.
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Adicionar a pasta de trabalho a um slide.
AddExcelChartInPresentation(presentation, slide, workbookStream.toByteArray(), imageStream.toByteArray());

// Salvar a apresentação no disco.
presentation.save("OutputChart.pptx", SaveFormat.Pptx);
presentation.dispose();
```

```java
static void AddExcelChartInPresentation(Presentation presentation, ISlide slide, byte[] workbookArray, byte[] chartImage) throws Exception
{
    double oleHeight = presentation.getSlideSize().getSize().getHeight();
    double oleWidth = presentation.getSlideSize().getSize().getWidth();
 
    // Criar um objeto LoadOptions EXCEL_97_TO_2003.
    com.aspose.cells.LoadOptions loadOptions = new com.aspose.cells.LoadOptions(com.aspose.cells.FileFormatType.EXCEL_97_TO_2003);         
    Workbook workbook = new Workbook(new ByteArrayInputStream(workbookArray),loadOptions);
 
    IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(0f, 0f, (float)oleWidth, (float)oleHeight, "Excel.Sheet.8", workbookArray);
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(presentation.getImages().addImage(new ByteArrayInputStream(chartImage)));
}
```

```java
static int AddExcelChartInWorkbook(Workbook workbook, int chartRows, int chartCols)
{
    // Um array de nomes de células.
    String[] cellNames = new String[]
    {
        "A1", "A2", "A3", "A4",
        "B1", "B2", "B3", "B4",
        "C1", "C2", "C3", "C4",
        "D1", "D2", "D3", "D4",
        "E1", "E2", "E3", "E4"
    };

    // Um array de dados das células.
    int[] cellValues = new int[]
    {
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25
    };

    // Adicionar uma nova planilha para preencher as células com dados.
    int dataSheetIndex = workbook.getWorksheets().add();
    Worksheet dataSheet = workbook.getWorksheets().get(dataSheetIndex);
    String sheetName = "DataSheet";
    dataSheet.setName(sheetName);

    // Preencher a planilha de dados com os valores.
    int size = Array.getLength(cellNames);
    for (int i = 0; i < size; i++)
    {
        String cellName = cellNames[i];
        int cellValue = cellValues[i];
        dataSheet.getCells().get(cellName).setValue(cellValue);
    }

    // Adicionar uma planilha de gráfico.
    int worksheetIndex = workbook.getWorksheets().add(SheetType.CHART);
    Worksheet chartSheet = workbook.getWorksheets().get(worksheetIndex);
    chartSheet.setName("ChartSheet");
    int chartSheetIndex = chartSheet.getIndex();

    // Adicionar um gráfico à planilha de gráfico com séries de dados da planilha de dados.
    int chartIndex = chartSheet.getCharts().add(ChartType.COLUMN, 0, chartRows, 0, chartCols);
    Chart chart = chartSheet.getCharts().get(chartIndex);
    
    chart.getNSeries().add(sheetName + "!A1:E1", false);
    chart.getNSeries().add(sheetName + "!A2:E2", false);
    chart.getNSeries().add(sheetName + "!A3:E3", false);
    chart.getNSeries().add(sheetName + "!A4:E4", false);

    // Definir a planilha de gráfico como a planilha ativa.
    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
    return chartSheetIndex;
}
```

A apresentação criada pelo método acima conterá o gráfico do Excel como um objeto OLE que pode ser ativado ao clicar duas vezes na moldura do objeto OLE.

## **Conclusão**

Usando Aspose.Cells para Java junto com Aspose.Slides para Java, podemos criar qualquer gráfico do Excel suportado pelo Aspose.Cells e incorporá‑lo como um objeto OLE em um slide do PowerPoint. O tamanho OLE do gráfico do Excel também pode ser definido. Os usuários finais podem então editar o gráfico do Excel como qualquer outro objeto OLE.

## **Seções Relacionadas**

- [Solução Funcional para Redimensionamento de Gráficos em PPTX](/slides/pt/java/working-solution-for-chart-resizing-in-pptx/)
- [Problema de Visualização do Objeto ao Adicionar OleObjectFrame](/slides/pt/java/object-preview-issue-when-adding-oleobjectframe/)
- [Atualizar Objetos OLE Automaticamente Usando um Add-In do PowerPoint](/slides/pt/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)