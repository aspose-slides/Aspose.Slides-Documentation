---
title: Gerenciar workbooks de gráficos em apresentações em .NET
linktitle: Workbook de Gráfico
type: docs
weight: 70
url: /pt/net/chart-workbook/
keywords:
- workbook de gráfico
- dados de gráfico
- célula de workbook
- rótulo de dados
- planilha
- fonte de dados
- workbook externo
- dados externos
- cache de gráfico
- recuperação de workbook
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Descubra Aspose.Slides para .NET: gerencie facilmente workbooks de gráficos em formatos PowerPoint e OpenDocument para otimizar os dados da sua apresentação."
---
## **Visão geral**

Este artigo explica como trabalhar com pastas de trabalho de gráficos no Aspose.Slides. Ele mostra como ler e gravar dados de gráfico através de streams de pastas de trabalho, usar células de pasta de trabalho como rótulos de dados de gráfico, acessar coleções de planilhas e especificar o tipo de fonte de dados para os valores do gráfico. Também aborda o trabalho com pastas de trabalho externas como fontes de dados de gráfico. Os exemplos demonstram como criar e atribuir uma pasta de trabalho externa, recuperar o caminho de uma pasta de trabalho externa vinculada a um gráfico e editar os dados do gráfico quando a pasta de trabalho está disponível.

## **Ler e gravar dados de gráfico de uma pasta de trabalho**
Aspose.Slides fornece os métodos [ReadWorkbookStream](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdata/readworkbookstream/) e [WriteWorkbookStream](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdata/writeworkbookstream/) que permitem ler e gravar pastas de trabalho de dados de gráfico (contendo dados de gráfico editados com Aspose.Cells). **Nota** que os dados do gráfico precisam estar organizados da mesma forma ou ter uma estrutura semelhante à fonte.

Este código C# demonstra uma operação de exemplo:

```c#
using (Presentation pres = new Presentation("chart.pptx"))
{
    Chart chart = (Chart) pres.Slides[0].Shapes[0];
    IChartData data = chart.ChartData;

    MemoryStream stream = data.ReadWorkbookStream();

    data.Series.Clear();
    data.Categories.Clear();

    stream.Position = 0;
    data.WriteWorkbookStream(stream);
}
```

## **Definir uma célula de WorkBook como rótulo de dados de gráfico**
1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/).
2. Obtenha a referência de um slide através de seu índice.
3. Adicione um gráfico de Bolha com alguns dados.
4. Acesse a série do gráfico.
5. Defina a célula da pasta de trabalho como um rótulo de dados.
6. Salve a apresentação.

Este código C# mostra como definir uma célula de workbook como um rótulo de dados de gráfico:

```c#
string lbl0 = "Label 0 cell value";
string lbl1 = "Label 1 cell value";
string lbl2 = "Label 2 cell value";

// Instancia uma classe de apresentação que representa um arquivo de apresentação 
using (Presentation pres = new Presentation("chart2.pptx"))
{
    ISlide slide = pres.Slides[0];


    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);

    IChartSeriesCollection series = chart.ChartData.Series;

    series[0].Labels.DefaultDataLabelFormat.ShowLabelValueFromCell = true;

    IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

    series[0].Labels[0].ValueFromCell = wb.GetCell(0, "A10", lbl0);
    series[0].Labels[1].ValueFromCell = wb.GetCell(0, "A11", lbl1);
    series[0].Labels[2].ValueFromCell = wb.GetCell(0, "A12", lbl2);

    pres.Save("resultchart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Gerenciar planilhas**
Este código C# demonstra uma operação onde a propriedade [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) é usada para acessar uma coleção de planilhas:

``` csharp
using (Presentation pres = new Presentation())
{
   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
   IChartDataWorkbook wb =  chart.ChartData.ChartDataWorkbook;
   for (int i = 0; i < wb.Worksheets.Count; i++)
      Console.WriteLine(wb.Worksheets[i].Name);
}
```

## **Especificar o tipo de fonte de dados**
Este código C# mostra como especificar um tipo para uma fonte de dados:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue val = chart.ChartData.Series[0].Name;
    
    val.DataSourceType = DataSourceType.StringLiterals;
    val.Data = "LiteralString";

    val = chart.ChartData.Series[1].Name;
    val.Data = chart.ChartData.ChartDataWorkbook.GetCell(0, "B1", "NewCell");

    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Detectar formatos de workbook incorporados não suportados**
Aspose.Slides não suporta o formato de workbook binário do Excel (.xlsb) que pode ser incorporado em alguns gráficos. Você pode usar a propriedade `EmbeddedWorkbookType` em [IChartData](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdata/) juntamente com a enumeração [WorkbookType](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/workbooktype/) para detectar formatos não suportados e pular esses gráficos.

```csharp
using (var presentation = new Presentation("sample.pptx"))
{
    var slide = presentation.Slides[0];

    foreach (var shape in slide.Shapes)
    {
        if (shape is not IChart chart) continue;

        var chartData = chart.ChartData;

        if (chartData.DataSourceType == ChartDataSourceType.InternalWorkbook &&
            chartData.EmbeddedWorkbookType == WorkbookType.WorkbookBinaryMacro)
        {
            // O workbook incorporado está no formato .xlsb, que não é suportado.
            continue;
        }

        // Leia ou modifique os dados do workbook do gráfico aqui.
    }
}
```

## **Pasta de trabalho externa**
{{% alert color="primary" %}} 
No [Aspose.Slides 19.4](https://docs.aspose.com/slides/pt/net/aspose-slides-for-net-19-4-release-notes/), implementamos suporte a workbooks externos como fonte de dados para gráficos.
{{% /alert %}} 

### **Criar um workbook externo**
Usando os métodos **`ReadWorkbookStream`** e **`SetExternalWorkbook`**, você pode criar um workbook externo do zero ou tornar um workbook interno externo.

Este código C# demonstra o processo de criação de um workbook externo:

```c#
using (Presentation pres = new Presentation())
{
    const string workbookPath = "externalWorkbook1.xlsx";

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600);
    using (FileStream fileStream = new FileStream(workbookPath, FileMode.Create))
    {
        byte[] workbookData = chart.ChartData.ReadWorkbookStream().ToArray();
        fileStream.Write(workbookData, 0, workbookData.Length);
    }
    
    chart.ChartData.SetExternalWorkbook(Path.GetFullPath(workbookPath));

    pres.Save("externalWorkbook.pptx", SaveFormat.Pptx);
}
```

### **Definir um workbook externo**
Usando o método **`SetExternalWorkbook`**, você pode atribuir um workbook externo a um gráfico como sua fonte de dados. Este método também pode ser usado para atualizar o caminho para o workbook externo (se este tiver sido movido).

Embora você não possa editar os dados em workbooks armazenados em locais ou recursos remotos, ainda pode usar esses workbooks como fonte de dados externa. Se um caminho relativo para um workbook externo for fornecido, ele será convertido automaticamente para um caminho completo.

Este código C# mostra como definir um workbook externo:

```c#
// O caminho para o diretório de documentos.
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, false);
    IChartData chartData = chart.ChartData;
                    
    chartData.SetExternalWorkbook(Path.GetFullPath("externalWorkbook.xlsx"));
                  

    chartData.Series.Add(chartData.ChartDataWorkbook.GetCell(0, "B1"), ChartType.Pie);
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B2"));
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B3"));
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B4"));

    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A2"));
    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A3"));
    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A4"));
    pres.Save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
}
```

O parâmetro `ChartData` (sob o método `SetExternalWorkbook`) é usado para especificar se um workbook Excel será carregado ou não. 

* Quando o valor de `ChartData` está definido como `false`, somente o caminho do workbook é atualizado — os dados do gráfico não serão carregados ou atualizados a partir do workbook de destino. Você pode desejar usar esta configuração quando o workbook de destino não existir ou não estiver disponível. 
* Quando o valor de `ChartData` está definido como `true`, os dados do gráfico são atualizados a partir do workbook de destino.

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
	IChartData chartData = chart.ChartData;

	(chartData as ChartData).SetExternalWorkbook("http://path/doesnt/exists", false);

	pres.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
}
```

### **Obter o caminho do workbook da fonte de dados externa de um gráfico**
1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/).
2. Obtenha a referência de um slide através de seu índice.
3. Crie um objeto para a forma do gráfico.
4. Crie um objeto para o tipo de origem (`ChartDataSourceType`) que representa a fonte de dados do gráfico.
5. Especifique a condição relevante com base no tipo de origem sendo o mesmo do tipo de fonte de dados do workbook externo.

Este código C# demonstra a operação:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ISlide slide = pres.Slides[1];
    IChart chart = (IChart)slide.Shapes[0];
    ChartDataSourceType sourceType = chart.ChartData.DataSourceType;
    if (sourceType == ChartDataSourceType.ExternalWorkbook)
    {
        string path = chart.ChartData.ExternalWorkbookPath;
    }
    
    // Salva a apresentação
    pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

### **Editar dados do gráfico**
Você pode editar os dados em workbooks externos da mesma forma que faz alterações no conteúdo de workbooks internos. Quando um workbook externo não pode ser carregado, uma exceção é lançada.

Este código C# é uma implementação do processo descrito:

```c#
using (Presentation pres = new Presentation("presentation.pptx"))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;
    ChartData chartData = (ChartData)chart.ChartData;
                   

    chartData.Series[0].DataPoints[0].Value.AsCell.Value = 100;
    pres.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```

### **Recuperar um workbook do cache do gráfico**
Se um gráfico usa um workbook externo que está ausente ou indisponível, Aspose.Slides pode reconstruir o workbook do gráfico a partir dos dados armazenados em cache na apresentação. Crie [LoadOptions](https://reference.aspose.com/slides/pt/net/aspose.slides/loadoptions/), configure seu [SpreadsheetOptions](https://reference.aspose.com/slides/pt/net/aspose.slides/loadoptions/spreadsheetoptions/) e defina [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/pt/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) como `true` antes de abrir a apresentação.

O exemplo C# a seguir abre uma apresentação cujo gráfico referencia um workbook externo indisponível e acessa os dados recuperados através de [IChart.ChartData](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichart/chartdata/) e [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdata/chartdataworkbook/):

```csharp
var loadOptions = new LoadOptions
{
    SpreadsheetOptions = new SpreadsheetOptions
    {
        RecoverWorkbookFromChartCache = true
    }
};

using var presentation = new Presentation("presentation.pptx", loadOptions);

var chart = (IChart)presentation.Slides[0].Shapes[0];
var recoveredWorkbook = chart.ChartData.ChartDataWorkbook;

// Read or modify the recovered workbook data here.
```

Se o workbook externo estiver indisponível e a recuperação estiver desativada, Aspose.Slides lança um `InvalidOperationException`. Habilite a recuperação apenas quando o uso dos dados de gráfico em cache for uma alternativa aceitável, pois o cache pode não conter alterações feitas no workbook externo após a última atualização da apresentação.

## **Perguntas frequentes**
**Posso determinar se um gráfico específico está vinculado a um workbook externo ou incorporado?**  
Sim. Um gráfico possui um [tipo de fonte de dados](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/chartdata/datasourcetype/) e um [caminho para um workbook externo](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/chartdata/externalworkbookpath/); se a fonte for um workbook externo, você pode ler o caminho completo para garantir que um arquivo externo está sendo usado.

**Caminhos relativos para workbooks externos são suportados, e como eles são armazenados?**  
Sim. Se você especificar um caminho relativo, ele será convertido automaticamente para um caminho absoluto. Isso é conveniente para a portabilidade do projeto; porém, esteja ciente de que a apresentação armazenará o caminho absoluto no arquivo PPTX.

**Posso usar workbooks localizados em recursos/rede compartilhada?**  
Sim, esses workbooks podem ser usados como fonte de dados externa. Contudo, editar workbooks remotos diretamente pelo Aspose.Slides não é suportado — eles podem ser usados apenas como fonte.

**O Aspose.Slides sobrescreve o XLSX externo ao salvar a apresentação?**  
Não. A apresentação armazena um [link para o arquivo externo](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/chartdata/externalworkbookpath/) e o utiliza para ler os dados. O arquivo externo em si não é modificado quando a apresentação é salva.

**O que devo fazer se o arquivo externo estiver protegido por senha?**  
Aspose.Slides não aceita senha ao vincular. Uma abordagem comum é remover a proteção previamente ou preparar uma cópia descriptografada (por exemplo, usando [Aspose.Cells](/cells/net/)) e vincular a essa cópia.

**Vários gráficos podem referenciar o mesmo workbook externo?**  
Sim. Cada gráfico armazena seu próprio link. Se todos apontarem para o mesmo arquivo, a atualização desse arquivo será refletida em cada gráfico na próxima vez que os dados forem carregados.