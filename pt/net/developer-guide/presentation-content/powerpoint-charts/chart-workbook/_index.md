---
title: Gerenciar Pastas de Trabalho de Gráficos em Apresentações no .NET
linktitle: Pasta de Trabalho de Gráfico
type: docs
weight: 70
url: /pt/net/chart-workbook/
keywords:
- pasta de trabalho de gráfico
- dados de gráfico
- célula de pasta de trabalho
- rótulo de dados
- planilha
- fonte de dados
- pasta de trabalho externa
- dados externos
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Descubra o Aspose.Slides para .NET: gerencie facilmente pastas de trabalho de gráficos em formatos PowerPoint e OpenDocument para otimizar os dados da sua apresentação."
---
## **Visão geral**

Este artigo explica como trabalhar com pastas de trabalho de gráficos no Aspose.Slides. Ele mostra como ler e gravar dados de gráficos por meio de streams de pastas de trabalho, usar células da pasta de trabalho como rótulos de dados do gráfico, acessar coleções de planilhas e especificar o tipo de origem de dados para os valores do gráfico.

Também aborda o trabalho com pastas de trabalho externas como fontes de dados de gráficos. Os exemplos demonstram como criar e atribuir uma pasta de trabalho externa, recuperar o caminho de uma pasta de trabalho externa vinculada a um gráfico e editar os dados do gráfico quando a pasta de trabalho está disponível.

## **Ler e gravar dados de gráfico a partir de uma pasta de trabalho**
Aspose.Slides fornece os [ReadWorkbookStream](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdata/readworkbookstream/) e [WriteWorkbookStream](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdata/writeworkbookstream/) métodos que permitem ler e gravar pastas de trabalho de dados de gráficos (contendo dados de gráficos editados com Aspose.Cells). **Note** que os dados do gráfico devem ser organizados da mesma maneira ou ter uma estrutura semelhante à fonte.

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

## **Definir uma célula da Pasta de Trabalho como rótulo de dados do gráfico**
1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/).
2. Obtenha a referência de um slide por meio de seu índice.
3. Adicione um gráfico de bolhas com alguns dados.
4. Acesse as séries do gráfico.
5. Defina a célula da pasta de trabalho como um rótulo de dados.
6. Salve a apresentação.

Este código C# mostra como definir uma célula da pasta de trabalho como rótulo de dados do gráfico:

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

## **Gerenciar Planilhas**

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

## **Especificar o tipo de origem de dados**

Este código C# mostra como especificar um tipo para uma origem de dados:

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

## **Detectar formatos de pasta de trabalho incorporados não suportados**

Aspose.Slides não oferece suporte ao formato de pasta de trabalho binária do Excel (.xlsb) que pode ser incorporado em alguns gráficos. Você pode usar a propriedade `EmbeddedWorkbookType` em [IChartData](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdata/) juntamente com a enumeração [WorkbookType](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/workbooktype/) para detectar formatos não suportados e pular esses gráficos.

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
            // Pasta de trabalho incorporada está no formato .xlsb, que não é suportado.
            continue;
        }

        // Ler ou modificar os dados da pasta de trabalho do gráfico aqui.
    }
}
```

## **Pasta de Trabalho Externa**

{{% alert color="primary" %}} 
No [Aspose.Slides 19.4](https://docs.aspose.com/slides/pt/net/aspose-slides-for-net-19-4-release-notes/), implementamos suporte para pastas de trabalho externas como fonte de dados para gráficos.
{{% /alert %}} 

### **Criar uma Pasta de Trabalho Externa**
Usando os métodos **`ReadWorkbookStream`** e **`SetExternalWorkbook`**, você pode criar uma pasta de trabalho externa do zero ou tornar uma pasta de trabalho interna externa.

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

### **Definir uma Pasta de Trabalho Externa**
Usando o método **`SetExternalWorkbook`**, você pode atribuir uma pasta de trabalho externa a um gráfico como sua fonte de dados. Esse método também pode ser usado para atualizar o caminho da pasta de trabalho externa (se esta foi movida).

Embora não seja possível editar os dados em pastas de trabalho armazenadas em locais ou recursos remotos, ainda assim você pode usar essas pastas como fonte de dados externa. Se for fornecido um caminho relativo para uma pasta de trabalho externa, ele será convertido automaticamente para um caminho completo.

Este código C# mostra como definir uma pasta de trabalho externa:

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

O parâmetro `ChartData` (sob o método `SetExternalWorkbook`) é usado para especificar se uma pasta de trabalho Excel será carregada ou não. 

* Quando o valor de `ChartData` é definido como `false`, apenas o caminho da pasta de trabalho é atualizado — os dados do gráfico não serão carregados ou atualizados a partir da pasta de trabalho de destino. Use essa configuração quando a pasta de trabalho de destino não existir ou estiver indisponível. 
* Quando o valor de `ChartData` é definido como `true`, os dados do gráfico são atualizados a partir da pasta de trabalho de destino.

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
	IChartData chartData = chart.ChartData;

	(chartData as ChartData).SetExternalWorkbook("http://path/doesnt/exists", false);

	pres.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
}
```

### **Obter o caminho da pasta de trabalho fonte de dados externa de um gráfico**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/).
2. Obtenha a referência de um slide por meio de seu índice.
3. Crie um objeto para a forma do gráfico.
4. Crie um objeto para o tipo de origem (`ChartDataSourceType`) que representa a fonte de dados do gráfico.
5. Especifique a condição relevante com base no tipo de origem sendo o mesmo que o tipo de fonte de dados da pasta de trabalho externa.

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

### **Editar Dados do Gráfico**

Você pode editar os dados em pastas de trabalho externas da mesma forma que altera o conteúdo de pastas de trabalho internas. Quando uma pasta de trabalho externa não pode ser carregada, uma exceção é lançada.

```c#
using (Presentation pres = new Presentation("presentation.pptx"))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;
    ChartData chartData = (ChartData)chart.ChartData;
                   

    chartData.Series[0].DataPoints[0].Value.AsCell.Value = 100;
    pres.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Posso determinar se um gráfico específico está vinculado a uma pasta de trabalho externa ou embutida?**

Sim. Um gráfico possui um [tipo de origem de dados](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/chartdata/datasourcetype/) e um [caminho para uma pasta de trabalho externa](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/chartdata/externalworkbookpath/); se a origem for uma pasta de trabalho externa, você pode ler o caminho completo para garantir que um arquivo externo está sendo usado.

**Caminhos relativos para pastas de trabalho externas são suportados e como são armazenados?**

Sim. Se você especificar um caminho relativo, ele será convertido automaticamente em um caminho absoluto. Isso facilita a portabilidade do projeto; entretanto, esteja ciente de que a apresentação armazenará o caminho absoluto no arquivo PPTX.

**Posso usar pastas de trabalho localizadas em recursos ou compartilhamentos de rede?**

Sim, essas pastas podem ser usadas como fonte de dados externa. No entanto, editar pastas de trabalho remotas diretamente pelo Aspose.Slides não é suportado — elas podem ser usadas apenas como fonte.

**O Aspose.Slides sobrescreve o XLSX externo ao salvar a apresentação?**

Não. A apresentação armazena um [link para o arquivo externo](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/chartdata/externalworkbookpath/) e o utiliza para leitura dos dados. O arquivo externo em si não é modificado ao salvar a apresentação.

**O que devo fazer se o arquivo externo estiver protegido por senha?**

Aspose.Slides não aceita senha ao vincular. Uma abordagem comum é remover a proteção antecipadamente ou preparar uma cópia descriptografada (por exemplo, usando [Aspose.Cells](/cells/net/)) e vincular a essa cópia.

**Múltiplos gráficos podem referenciar a mesma pasta de trabalho externa?**

Sim. Cada gráfico armazena seu próprio link. Se todos apontarem para o mesmo arquivo, a atualização desse arquivo será refletida em cada gráfico na próxima vez que os dados forem carregados.