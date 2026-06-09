---
title: Criar Gráficos do Excel e Incorporá‑los em Apresentações como Objetos OLE
type: docs
weight: 50
url: /pt/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Gráfico do Excel
- incorporar gráfico
- objeto OLE
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Crie gráficos do Excel e incorpore‑los como objetos OLE em apresentações PowerPoint e OpenDocument com C#/.NET. Guia passo a passo com exemplos de código."
---
## **Contexto**

No PowerPoint, usar gráficos editáveis para exibir dados graficamente é uma prática comum. Aspose oferece suporte à criação de gráficos do Excel com Aspose.Cells para .NET, e esses gráficos podem ser incorporados como objetos OLE em slides do PowerPoint através do Aspose.Slides para .NET. Este artigo aborda as etapas necessárias e fornece exemplos de código C# para criar um gráfico do Excel e incorporá‑lo como objeto OLE em uma apresentação PowerPoint usando Aspose.Cells e Aspose.Slides.

## **Passos Necessários**

A sequência de etapas a seguir é necessária para criar e incorporar um gráfico do Excel como objeto OLE em um slide do PowerPoint:

1. Crie um gráfico do Excel usando Aspose.Cells.
1. Defina o tamanho OLE do gráfico do Excel usando Aspose.Cells.
1. Obtenha uma imagem do gráfico do Excel com Aspose.Cells.
1. Incorpore o gráfico do Excel como um objeto OLE em uma apresentação PPTX usando Aspose.Slides.
1. Substitua a imagem "EMBEDDED OLE OBJECT" pela imagem obtida na etapa 3 para resolver o [problema de visualização do objeto](/slides/pt/net/object-preview-issue-when-adding-oleobjectframe/).
1. Salve a apresentação no disco no formato PPTX.

## **Implementação dos Passos Necessários**

A implementação em C# das etapas acima é a seguinte:

```cs
// Etapa - 1: Criar um gráfico do Excel usando Aspose.Cells.
// ---------------------------------------------------
// Criar uma pasta de trabalho.
Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook();
// Adicionar um gráfico do Excel.
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(workbook, chartRows, chartCols);

// Etapa - 2: Definir o tamanho OLE do gráfico usando Aspose.Cells.
// -----------------------------------------------------------
workbook.Worksheets.SetOleSize(0, chartRows, 0, chartCols);

// Etapa - 3: Obter a imagem do gráfico com Aspose.Cells.
// -------------------------------------------------------
Bitmap chartImage = workbook.Worksheets[chartSheetIndex].Charts[0].ToImage();
// Salvar a pasta de trabalho em um fluxo.
MemoryStream workbookStream = workbook.SaveToStream();

// Etapa - 4 E 5
// ==============
// Etapa - 4: Incorporar o gráfico como um objeto OLE dentro de uma apresentação .ppt usando Aspose.Slides.
// ------------------------------------------------------------------------------------------
// Etapa - 5: Substituir a imagem "EMBEDDED OLE OBJECT" pela imagem obtida na etapa 3 para resolver o Problema de Visualização do Objeto.
// --------------------------------------------------------------------------------------------------------------------
// Criar uma apresentação.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    // Adicionar a pasta de trabalho ao slide.
    AddExcelChartInPresentation(presentation, slide, workbookStream, chartImage);

    // Etapa - 6: Salvar a apresentação resultante no disco.
    // -----------------------------------------------
    presentation.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

```cs
static int AddExcelChartInWorkbook(Aspose.Cells.Workbook workbook, int chartRows, int chartCols)
{
    // Um array de nomes de células.
    string[] cellNames = new string[]
    {
        "A1", "A2", "A3", "A4",
        "B1", "B2", "B3", "B4",
        "C1", "C2", "C3", "C4",
        "D1", "D2", "D3", "D4",
        "E1", "E2", "E3", "E4"
    };

    // Um array de valores de células.
    int[] cellValues = new int[]
    {
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25
    };

    // Adicionar uma nova planilha para preencher células com dados.
    int dataSheetIndex = workbook.Worksheets.Add();
    Aspose.Cells.Worksheet dataSheet = workbook.Worksheets[dataSheetIndex];
    string sheetName = "DataSheet";
    dataSheet.Name = sheetName;

    // Preencher a planilha de dados com valores.
    for (int i = 0; i < cellNames.Length; i++)
    {
        string cellName = cellNames[i];
        int cellValue = cellValues[i];
        dataSheet.Cells[cellName].PutValue(cellValue);
    }

    // Adicionar uma planilha de gráfico.
    int chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
    Aspose.Cells.Worksheet chartSheet = workbook.Worksheets[chartSheetIndex];
    chartSheet.Name = "ChartSheet";

    // Adicionar um gráfico à planilha de gráfico com séries de dados da planilha de dados.
    int chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, chartRows, 0, chartCols);
    Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIndex];
    chart.NSeries.Add(sheetName + "!A1:E1", false);
    chart.NSeries.Add(sheetName + "!A2:E2", false);
    chart.NSeries.Add(sheetName + "!A3:E3", false);
    chart.NSeries.Add(sheetName + "!A4:E4", false);

    // Definir a planilha de gráfico como a planilha ativa.
    workbook.Worksheets.ActiveSheetIndex = chartSheetIndex;
    return chartSheetIndex;
}
```

```cs
static void AddExcelChartInPresentation(Presentation presentation, ISlide slide, Stream workbookStream, Bitmap chartImage)
{
    float oleWidth = presentation.SlideSize.Size.Width;
    float oleHeight = presentation.SlideSize.Size.Height;

    byte[] oleData = new byte[workbookStream.Length];
    workbookStream.Position = 0;
    workbookStream.Read(oleData, 0, oleData.Length);

    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleData, "xls");
    IOleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(0, 0, oleWidth, oleHeight, dataInfo);

    using (MemoryStream imageStream = new MemoryStream())
    {
        chartImage.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);

	    imageStream.Position = 0;
        IPPImage ppImage = presentation.Images.AddImage(imageStream);

        oleFrame.SubstitutePictureFormat.Picture.Image = ppImage;
    }
}
```

A apresentação criada pelo método acima conterá o gráfico do Excel como um objeto OLE que pode ser ativado ao clicar duas vezes na moldura do objeto OLE.

## **Conclusão**

Usando Aspose.Cells para .NET juntamente com Aspose.Slides para .NET, podemos criar qualquer gráfico do Excel suportado pelo Aspose.Cells e incorporá‑lo como um objeto OLE em um slide do PowerPoint. O tamanho OLE do gráfico do Excel também pode ser definido. Os usuários finais podem então editar o gráfico do Excel como qualquer outro objeto OLE.

## **Seções Relacionadas**

- [Solução Funcional para Redimensionamento de Gráficos em PPTX](/slides/pt/net/working-solution-for-chart-resizing-in-pptx/)
- [Problema de Visualização do Objeto ao Adicionar OleObjectFrame](/slides/pt/net/object-preview-issue-when-adding-oleobjectframe/)
- [Atualizar Objetos OLE Automaticamente Usando um Add‑In do PowerPoint](/slides/pt/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)