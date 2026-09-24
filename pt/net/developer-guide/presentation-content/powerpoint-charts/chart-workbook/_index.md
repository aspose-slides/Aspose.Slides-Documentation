---
title: Gerenciar Workbooks de Gráficos em Apresentações em .NET
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
description: "Descubra Aspose.Slides para .NET: gerencie facilmente workbooks de gráficos em formatos PowerPoint e OpenDocument para otimizar os dados de sua apresentação."
---
## **Visão geral**

Este artigo explica como trabalhar com livros de gráficos em Aspose.Slides. Ele mostra como ler e gravar dados de gráficos através de streams de livro de trabalho, usar células de livro de trabalho como rótulos de dados de gráfico, acessar coleções de planilhas e especificar o tipo de origem de dados para valores de gráfico.

Também aborda o uso de workbooks externos como fontes de dados de gráficos. Os exemplos demonstram como criar e atribuir um workbook externo, recuperar o caminho de um workbook externo vinculado a um gráfico e editar os dados do gráfico quando o workbook está disponível.

Para células de workbook que representam dados ausentes, veja [Control the Display of Empty Cells](/slides/pt/net/chart-series/) para a diferença entre uma célula vazia e zero, e uma comparação de gráfico de linhas dos modos de exibição disponíveis.

## **Ler e Gravar Dados de Gráfico de um Livro de Trabalho**
Aspose.Slides fornece os métodos [ReadWorkbookStream](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdata/readworkbookstream/) e [WriteWorkbookStream](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdata/writeworkbookstream/) que permitem ler e gravar workbooks de dados de gráfico (contendo dados de gráfico editados com Aspose.Cells). **Nota** que os dados do gráfico precisam estar organizados da mesma maneira ou ter uma estrutura semelhante à fonte.

Este código C# demonstra uma operação de exemplo:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;

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

### **Validar Layout do Gráfico Após Modificação do Livro de Trabalho**

Quando você substitui um workbook incorporado por um modificado, o gráfico mantém suas coleções originais de séries e categorias. Essa incompatibilidade pode fazer com que [IChart.ValidateChartLayout](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichart/validatechartlayout/) falhe com um erro de índice fora do intervalo. Limpe as séries e categorias existentes antes de escrever o workbook atualizado de volta ao gráfico.

```csharp
// Após modificar o stream do workbook (ex., usando Aspose.Cells)
using var updatedWorkbook = chartData.ReadWorkbookStream();

// Limpar referências de dados existentes.
chartData.Series.Clear();
chartData.Categories.Clear();

updatedWorkbook.Position = 0;
chartData.WriteWorkbookStream(updatedWorkbook);

chart.ValidateChartLayout();
```

Limpar as coleções garante que a estrutura de dados do gráfico seja consistente com o novo workbook, permitindo que `ValidateChartLayout` seja concluído sem erros.

## **Definir uma Célula de WorkBook como Rótulo de Dados do Gráfico**
1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) .
2. Obtenha a referência de um slide através do seu índice.
3. Adicione um gráfico de Bolha com alguns dados.
4. Acesse as séries do gráfico.
5. Defina a célula do workbook como um rótulo de dados.
6. Salve a apresentação.

Este código C# demonstra como definir uma célula de workbook como rótulo de dados de gráfico:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;

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

## **Gerenciar Planilhas**

Este código C# demonstra uma operação onde a propriedade [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) é usada para acessar uma coleção de planilhas:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using (Presentation pres = new Presentation())
{
   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
   IChartDataWorkbook wb =  chart.ChartData.ChartDataWorkbook;
   for (int i = 0; i < wb.Worksheets.Count; i++)
      Console.WriteLine(wb.Worksheets[i].Name);
}
```

## **Especificar o Tipo de Origem de Dados**

Este código C# mostra como especificar um tipo para uma origem de dados:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

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

## **Detectar Formatos de Workbook Incorporados Não Suportados**

Aspose.Slides não suporta o formato de workbook binário do Excel (.xlsb) que pode ser incorporado em alguns gráficos. Você pode usar a propriedade `EmbeddedWorkbookType` em [IChartData](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdata/) juntamente com a enumeração [WorkbookType](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/workbooktype/) para detectar formatos não suportados e ignorar esses gráficos.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

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

## **Workbook Externo**

Aspose.Slides suporta o uso de workbooks externos como fonte de dados para gráficos.

### **Criar um Workbook Externo**

Usando os métodos **`ReadWorkbookStream`** e **`SetExternalWorkbook`**, você pode criar um workbook externo do zero ou tornar um workbook interno externo.

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

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

### **Definir um Workbook Externo**

Usando o método **`SetExternalWorkbook`**, você pode atribuir um workbook externo a um gráfico como sua fonte de dados. Este método também pode ser usado para atualizar o caminho para o workbook externo (se este tiver sido movido).

Embora você não possa editar os dados em workbooks armazenados em locais ou recursos remotos, ainda pode usar esses workbooks como fonte de dados externa. Se o caminho relativo para um workbook externo for fornecido, ele será convertido automaticamente para um caminho completo.

Este código C# mostra como definir um workbook externo:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

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

* Quando o valor de `ChartData` está definido como `false`, apenas o caminho do workbook é atualizado — os dados do gráfico não serão carregados ou atualizados a partir do workbook de destino. Você pode usar essa configuração quando o workbook de destino não existir ou não estiver disponível.
* Quando o valor de `ChartData` está definido como `true`, os dados do gráfico são atualizados a partir do workbook de destino.

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
	IChartData chartData = chart.ChartData;

	(chartData as ChartData).SetExternalWorkbook("http://path/doesnt/exists", false);

	pres.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
}
```

### **Obter o Caminho do Workbook de Fonte de Dados Externa de um Gráfico**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/).
2. Obtenha a referência de um slide através do seu índice.
3. Crie um objeto para a forma de gráfico.
4. Crie um objeto para o tipo de origem (`ChartDataSourceType`) que representa a fonte de dados do gráfico.
5. Especifique a condição relevante com base no tipo de origem sendo o mesmo que o tipo de fonte de dados do workbook externo.

Este código C# demonstra a operação:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

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

### **Editar Dados do Gráfico**

Você pode editar os dados em workbooks externos da mesma forma que faz alterações no conteúdo de workbooks internos. Quando um workbook externo não pode ser carregado, uma exceção é lançada.

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation.pptx"))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;
    ChartData chartData = (ChartData)chart.ChartData;
                   

    chartData.Series[0].DataPoints[0].Value.AsCell.Value = 100;
    pres.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```

### **Recuperar um Workbook do Cache do Gráfico**

Se um gráfico usa um workbook externo que está ausente ou indisponível, Aspose.Slides pode reconstruir o workbook do gráfico a partir dos dados armazenados em cache na apresentação. Crie [LoadOptions](https://reference.aspose.com/slides/pt/net/aspose.slides/loadoptions/), configure seu [SpreadsheetOptions](https://reference.aspose.com/slides/pt/net/aspose.slides/loadoptions/spreadsheetoptions/), e defina [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/pt/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) como `true` antes de abrir a apresentação.

O exemplo C# a seguir abre uma apresentação cujo gráfico referencia um workbook externo indisponível e acessa os dados recuperados através de [IChart.ChartData](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichart/chartdata/) e [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdata/chartdataworkbook/):

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

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

Se o workbook externo estiver indisponível e a recuperação estiver desativada, Aspose.Slides lança uma `InvalidOperationException`. Habilite a recuperação apenas quando usar os dados de gráfico em cache for uma alternativa aceitável, pois o cache pode não conter alterações feitas no workbook externo após a última atualização da apresentação.

## **Perguntas Frequentes**

**Posso determinar se um gráfico específico está vinculado a um workbook externo ou incorporado?**

Sim. Um gráfico tem um [tipo de fonte de dados](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/chartdata/datasourcetype/) e um [caminho para um workbook externo](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/chartdata/externalworkbookpath/); se a origem for um workbook externo, você pode ler o caminho completo para garantir que um arquivo externo está sendo usado.

**Os caminhos relativos para workbooks externos são suportados e como são armazenados?**

Sim. Se você especificar um caminho relativo, ele é convertido automaticamente em um caminho absoluto. Isso é conveniente para a portabilidade do projeto; porém, esteja ciente de que a apresentação armazenará o caminho absoluto no arquivo PPTX.

**Posso usar workbooks localizados em recursos ou compartilhamentos de rede?**

Sim, esses workbooks podem ser usados como fonte de dados externa. Contudo, a edição direta de workbooks remotos a partir do Aspose.Slides não é suportada — eles podem ser usados apenas como fonte.

**O Aspose.Slides sobrescreve o XLSX externo ao salvar a apresentação?**

Não. A apresentação armazena um [link para o arquivo externo](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/chartdata/externalworkbookpath/) e o utiliza para ler os dados. O arquivo externo em si não é modificado quando a apresentação é salva.

**O que devo fazer se o arquivo externo estiver protegido por senha?**

Aspose.Slides não aceita senha ao vincular. Uma abordagem comum é remover a proteção antecipadamente ou preparar uma cópia descriptografada (por exemplo, usando [Aspose.Cells](/cells/net/)) e vincular a essa cópia.

**Vários gráficos podem referenciar o mesmo workbook externo?**

Sim. Cada gráfico armazena seu próprio link. Se todos apontarem para o mesmo arquivo, a atualização desse arquivo será refletida em cada gráfico na próxima vez que os dados forem carregados.