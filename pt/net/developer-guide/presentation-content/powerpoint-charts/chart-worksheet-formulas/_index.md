---
title: Aplicar Fórmulas de Planilha de Gráfico em Apresentações no .NET
linktitle: Fórmulas de Planilha
type: docs
weight: 70
url: /pt/net/chart-worksheet-formulas/
keywords:
- planilha de gráfico
- planilha de gráfico
- fórmula de gráfico
- fórmula de planilha
- fórmula de planilha
- pasta de trabalho de dados do gráfico
- cálculo de fórmula
- cultura preferencial
- fórmula específica de cultura
- DBCS
- constante lógica
- constante numérica
- constante de texto
- constante de erro
- operador aritmético
- operador de comparação
- estilo A1
- estilo R1C1
- função predefinida
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Aplicar fórmulas no estilo Excel em planilhas de gráficos do Aspose.Slides para .NET, recalcular valores e usar os resultados em gráficos do PowerPoint."
---
## **Visão geral**

Os gráficos do PowerPoint geralmente armazenam seus dados de origem em uma planilha incorporada. No Aspose.Slides for .NET, você pode acessar essa planilha por meio da pasta de trabalho de dados do gráfico, gravar valores de entrada, atribuir fórmulas a células, calcular fórmulas suportadas e usar as células calculadas como dados do gráfico.

Este artigo explica o fluxo de trabalho completo de fórmulas: criar um gráfico, preencher sua planilha, atribuir fórmulas no estilo A1 ou R1C1, recalculá‑las, ler os valores calculados, conectar essas células a uma série do gráfico e salvar a apresentação. Também descreve a sintaxe de fórmula suportada, o subconjunto de funções interno, valores em cache, fórmulas não suportadas e erros específicos de planilha.

## **Planilhas de Gráficos e Fórmulas**

Uma planilha de gráfico contém as categorias, nomes de séries e valores usados por um gráfico. No PowerPoint, você pode inspecionar a planilha abrindo o editor de dados do gráfico:

![Gráfico do PowerPoint com sua planilha incorporada aberta, mostrando dados de categoria e série](chart-worksheet-formulas_1.png)

No Aspose.Slides, a planilha é exposta por meio do [chart data workbook](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdataworkbook/). Use a propriedade [Formula](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdatacell/formula/) para fórmulas no estilo A1 e a propriedade [R1C1Formula](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdatacell/r1c1formula/) para fórmulas no estilo R1C1. Depois de alterar células de entrada ou fórmulas, chame [CalculateFormulas](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) para recalcular as fórmulas suportadas e atualizar os valores correspondentes das células.

Uma célula calculada ainda expõe seu resultado por meio da propriedade [Value](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdatacell/value/). Isso é importante quando você precisa inspecionar o resultado de uma fórmula no código ou usar a célula como um ponto de dados do gráfico.

## **Criar um Gráfico e Calcular Fórmulas da Planilha**

O exemplo a seguir demonstra um fluxo de trabalho de ponta a ponta. Ele cria um gráfico de colunas agrupadas, limpa os dados de exemplo, grava valores trimestrais de receita e despesa, calcula lucro com fórmulas, lê os resultados, usa as células calculadas como valores do gráfico e salva a apresentação.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 350);
var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
workbook.Clear(worksheetIndex);

var category1 = workbook.GetCell(worksheetIndex, "A2", "Q1");
var category2 = workbook.GetCell(worksheetIndex, "A3", "Q2");
var category3 = workbook.GetCell(worksheetIndex, "A4", "Q3");

workbook.GetCell(worksheetIndex, "B1", "Revenue");
workbook.GetCell(worksheetIndex, "C1", "Expenses");
workbook.GetCell(worksheetIndex, "D1", "Profit");

workbook.GetCell(worksheetIndex, "B2").Value = 120.0;
workbook.GetCell(worksheetIndex, "C2").Value = 80.0;
workbook.GetCell(worksheetIndex, "B3").Value = 150.0;
workbook.GetCell(worksheetIndex, "C3").Value = 95.0;
workbook.GetCell(worksheetIndex, "B4").Value = 135.0;
workbook.GetCell(worksheetIndex, "C4").Value = 110.0;

var profit1 = workbook.GetCell(worksheetIndex, "D2");
var profit2 = workbook.GetCell(worksheetIndex, "D3");
var profit3 = workbook.GetCell(worksheetIndex, "D4");

profit1.Formula = "B2-C2";
profit2.Formula = "B3-C3";
profit3.Formula = "B4-C4";

workbook.CalculateFormulas();

var q1Profit = Convert.ToDouble(profit1.Value); // 40
var q2Profit = Convert.ToDouble(profit2.Value); // 55
var q3Profit = Convert.ToDouble(profit3.Value); // 25

Console.WriteLine($"Q1 profit: {q1Profit}");
Console.WriteLine($"Q2 profit: {q2Profit}");
Console.WriteLine($"Q3 profit: {q3Profit}");

chart.ChartData.Categories.Add(category1);
chart.ChartData.Categories.Add(category2);
chart.ChartData.Categories.Add(category3);

var profitSeries = chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, "D1"), chart.Type);
profitSeries.DataPoints.AddDataPointForBarSeries(profit1);
profitSeries.DataPoints.AddDataPointForBarSeries(profit2);
profitSeries.DataPoints.AddDataPointForBarSeries(profit3);
profitSeries.Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("chart-formulas.pptx", SaveFormat.Pptx);
```

Os pontos de dados do gráfico referenciam `D2:D4`, portanto o gráfico usa os valores de lucro calculados. Não há chamada separada de atualização de gráfico neste fluxo de trabalho: recalcule a pasta de trabalho primeiro, depois use ou salve os dados do gráfico que apontam para as células calculadas.

## **Usar Fórmulas no Estilo A1**

A notação A1 identifica colunas com letras e linhas com números. Atribua expressões no estilo A1 através de [IChartDataCell.Formula](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdatacell/formula/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "C3").Value = 10;
workbook.GetCell(0, "F2").Value = 2;
workbook.GetCell(0, "G2").Value = 3;
workbook.GetCell(0, "H2").Value = 4;

var cell = workbook.GetCell(0, "A2");
cell.Formula = "C3+SUM(F2:H2)";

workbook.CalculateFormulas();

var value = cell.Value; // 19
```

Formas de referência A1 comuns são:

| Referência | Relativa | Absoluta | Mista |
|---|---|---|---|
| Célula | `A2` | `$A$2` | `A$2`, `$A2` |
| Linha | `2:2` | `$2:$2` | — |
| Coluna | `A:A` | `$A:$A` | — |
| Intervalo | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Referências relativas podem mudar quando uma fórmula é movida ou copiada por uma aplicação de planilha. Referências absolutas mantêm ambas as coordenadas fixas, enquanto referências mistas fixam apenas uma linha ou uma coluna.

## **Usar Fórmulas no Estilo R1C1**

A notação R1C1 identifica linhas e colunas numericamente. Referências relativas usam deslocamentos entre colchetes. Atribua essa sintaxe através de [IChartDataCell.R1C1Formula](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdatacell/r1c1formula/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "B2").Value = 12;
workbook.GetCell(0, "C2").Value = 5;

var cell = workbook.GetCell(0, "D2");
cell.R1C1Formula = "RC[-2]-RC[-1]";

workbook.CalculateFormulas();

var value = cell.Value; // 7
```

Formas de referência R1C1 comuns são:

| Referência | Relativa | Absoluta | Mista |
|---|---|---|---|
| Célula | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Linha | `R[2]` | `R2` | — |
| Coluna | `C[3]` | `C3` | — |
| Intervalo | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Por exemplo, na célula `D2`, `RC[-2]` significa a célula na mesma linha duas colunas à esquerda (`B2`).

## **Constantes e Operadores de Fórmula**

O avaliador de fórmulas interno suporta valores lógicos, literais numéricos, strings, valores de erro de planilha, operadores aritméticos e operadores de comparação.

### **Constantes e Literais**

| Tipo | Exemplos | Observações |
|---|---|---|
| Lógico | `TRUE`, `FALSE` | Pode ser usado diretamente em expressões lógicas como `A2=TRUE`. |
| Numérico | `1`, `0.5`, `.3`, `1E-2` | Notação comum e científica são suportadas. |
| Texto | `"abc"`, `"2/3/2020 12:00"` | Literais de texto são delimitados por aspas duplas dentro da fórmula. |
| Resultado de erro | `#DIV/0!`, `#N/A`, `#REF!` | Uma fórmula válida pode avaliar para um valor de erro de planilha em vez de um resultado normal. |

Este exemplo usa vários tipos de constante:

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "A2").Value = false;
workbook.GetCell(0, "B2").Formula = "A2=TRUE";
workbook.GetCell(0, "C2").Formula = "1+0.5";
workbook.GetCell(0, "D2").Formula = ".3*1E-2";
workbook.GetCell(0, "E2").Formula = "\"abc\"";
workbook.GetCell(0, "F2").Formula = "2/0";

workbook.CalculateFormulas();

var logicalValue = workbook.GetCell(0, "B2").Value; // Falso
var numericValue = workbook.GetCell(0, "C2").Value; // 1.5
var scientificValue = workbook.GetCell(0, "D2").Value; // 0.003
var stringValue = workbook.GetCell(0, "E2").Value; // abc
var errorValue = workbook.GetCell(0, "F2").Value; // #DIV/0!
```

### **Operadores Aritméticos**

| Operador | Significado | Exemplo |
|---|---|---|
| `+` | Adição ou sinal positivo unário | `2+3` |
| `-` | Subtração ou negação | `2-3`, `-3` |
| `*` | Multiplicação | `2*3` |
| `/` | Divisão | `2/3` |
| `%` | Percentual | `30%` |
| `^` | Exponenciação | `2^3` |

Use parênteses para tornar a ordem de avaliação explícita, por exemplo `(A2+B2)*C2`.

### **Operadores de Comparação**

Expressões de comparação retornam valores lógicos.

| Operador | Significado | Exemplo |
|---|---|---|
| `=` | Igual a | `A2=3` |
| `<>` | Diferente de | `A2<>3` |
| `>` | Maior que | `A2>3` |
| `>=` | Maior ou igual a | `A2>=3` |
| `<` | Menor que | `A2<3` |
| `<=` | Menor ou igual a | `A2<=3` |

## **Funções Predefinidas Suportadas**

O Aspose.Slides inclui um avaliador de fórmulas interno para planilhas de gráficos, mas não é um motor de cálculo completo do Excel. O conjunto de funções documentado está limitado às funções abaixo. Não presuma que uma função arbitrária do Excel possa ser recalculada por [CalculateFormulas](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/).

| Função | Propósito ou forma suportada | Exemplo |
|---|---|---|
| `ABS` | Valor absoluto | `ABS(A2)` |
| `AVERAGE` | Média aritmética | `AVERAGE(B2:B5)` |
| `CEILING` | Arredonda um número para cima até um múltiplo | `CEILING(A2,5)` |
| `CHOOSE` | Seleciona um valor por índice | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Concatena valores de texto | `CONCAT(A2,B2)` |
| `CONCATENATE` | Concatena valores de texto | `CONCATENATE(A2," ",B2)` |
| `DATE` | Cria um valor de data usando o sistema de datas 1900 | `DATE(2026,8,19)` |
| `DAYS` | Retorna o número de dias entre datas | `DAYS(B2,A2)` |
| `FIND` | Encontra um valor de texto dentro de outro | `FIND("-",A2)` |
| `FINDB` | Busca de texto orientada a bytes | `FINDB("a",A2)` |
| `IF` | Resultado condicional | `IF(A2>0,A2,0)` |
| `INDEX` | Forma de referência | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Forma vetorial | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Forma vetorial | `MATCH(A2,B2:B5,0)` |
| `MAX` | Valor máximo | `MAX(B2:B5)` |
| `SUM` | Soma valores | `SUM(B2:B5)` |
| `VLOOKUP` | Busca vertical | `VLOOKUP(A2,B2:D10,3,FALSE)` |

As restrições mostradas na tabela são significativas: `INDEX` é documentado em forma de referência, enquanto `LOOKUP` e `MATCH` são documentados em suas formas vetoriais. `DATE` usa o sistema de datas 1900. Recursos e funções não listados aqui devem ser tratados como não suportados pelo avaliador de fórmulas do Aspose.Slides, salvo documentação separada.

## **Calcular Fórmulas com uma Cultura Preferencial**

Algumas funções da pasta de trabalho interpretam texto de acordo com regras específicas de cultura. Isso é especialmente importante para funções destinadas a idiomas que usam conjuntos de caracteres de dois bytes (DBCS). Para calcular tais fórmulas corretamente, crie [LoadOptions](https://reference.aspose.com/slides/pt/net/aspose.slides/loadoptions/), configure [ISpreadsheetOptions.PreferredCulture](https://reference.aspose.com/slides/pt/net/aspose.slides/ispreadsheetoptions/preferredculture/) através de [LoadOptions.SpreadsheetOptions](https://reference.aspose.com/slides/pt/net/aspose.slides/loadoptions/spreadsheetoptions/) e então carregue a apresentação.

O exemplo a seguir seleciona a cultura japonesa, abre uma apresentação com as opções de carregamento configuradas e chama [IChartDataWorkbook.CalculateFormulas](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) para cada pasta de trabalho de gráfico:

```csharp
using System.Globalization;
using Aspose.Slides;
using Aspose.Slides.Charts;

var loadOptions = new LoadOptions
{
    SpreadsheetOptions = new SpreadsheetOptions
    {
        PreferredCulture = CultureInfo.GetCultureInfo("ja-JP")
    }
};

using var presentation = new Presentation("presentation.pptx", loadOptions);

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IChart chart)
        {
            chart.ChartData.ChartDataWorkbook.CalculateFormulas();
        }
    }
}
```

A cultura preferencial faz parte da configuração de carregamento da apresentação, portanto especifique‑a antes de criar a instância de [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/). Use a cultura esperada pelas fórmulas da pasta de trabalho; por exemplo, use `ja-JP` para fórmulas que devem seguir as regras de cálculo DBCS japonesas.

## **Recalcular e Valores em Cache**

Arquivos de planilha costumam armazenar tanto a fórmula quanto seu último valor calculado. O Aspose.Slides pode, portanto, ler um valor em cache de [IChartDataCell.Value](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdatacell/value/) quando uma apresentação é carregada e os dados do gráfico relevantes não foram alterados.

Depois de mudar células de entrada ou fórmulas, não confie em um resultado em cache antigo. Chame [IChartDataWorkbook.CalculateFormulas](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) antes de ler valores calculados ou salvar dados do gráfico que dependam deles.

Para fórmulas fora do subconjunto suportado, o Aspose.Slides pode não conseguir analisar a fórmula ou estabelecer suas dependências. Se a pasta de trabalho foi modificada, o valor em cache anterior não pode ser considerado confiável. Nessa situação, ler o valor de uma célula com dados não suportados pode gerar [CellUnsupportedDataException](https://reference.aspose.com/slides/pt/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Se o seu gráfico depende de funções do Excel que o Aspose.Slides não avalia, calcule essas fórmulas com um motor de planilha que as suporte e grave os valores resultantes de volta na pasta de trabalho do gráfico. Não substitua fórmulas não suportadas por valores adivinhados.

## **Tratar Erros de Fórmula**

Existem dois tipos diferentes de problemas a distinguir.

Uma fórmula pode ser válida mas produzir um resultado de erro de planilha como `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` ou `#VALUE!`. Nesse caso, o token de erro é um resultado de célula e pode ser retornado através de `Value`.

Uma fórmula também pode falhar no nível de análise, referência, dependência ou dados suportados. O Aspose.Slides fornece exceções específicas de planilha para esses casos: [CellInvalidFormulaException](https://reference.aspose.com/slides/pt/net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/pt/net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/pt/net/aspose.slides.spreadsheet/cellcircularreferenceexception/) e [CellUnsupportedDataException](https://reference.aspose.com/slides/pt/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Quando as fórmulas vêm de modelos ou da entrada do usuário, trate essas exceções ao redor da recalculação e do acesso ao valor:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Spreadsheet;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;
var cell = workbook.GetCell(0, "A2");
cell.Formula = "SUM(B2:B5)";

try
{
    workbook.CalculateFormulas();
    Console.WriteLine(cell.Value);
}
catch (CellInvalidFormulaException ex)
{
    Console.Error.WriteLine($"Invalid formula: {ex.Message}");
}
catch (CellInvalidReferenceException ex)
{
    Console.Error.WriteLine($"Invalid cell reference: {ex.Message}");
}
catch (CellCircularReferenceException ex)
{
    Console.Error.WriteLine($"Circular reference: {ex.Message}");
}
catch (CellUnsupportedDataException ex)
{
    Console.Error.WriteLine($"Unsupported spreadsheet data: {ex.Message}");
}
```

## **Limitações Práticas**

O suporte a fórmulas em planilhas de gráficos destina‑se a um subconjunto definido de cálculos de planilha, não a compatibilidade total com o Excel. Mantenha essas restrições em mente ao projetar um fluxo de trabalho de relatórios:

- Use apenas as constantes, operadores, referências e funções documentadas quando precisar que o Aspose.Slides recalcule fórmulas.
- Recalcule após alterar células das quais os resultados das fórmulas dependem.
- Considere os valores em cache de apresentações carregadas como instantâneos, não como substituto da recalculação após edições.
- Teste as fórmulas de modelos existentes antes de confiar em seus valores calculados, especialmente quando usarem funções fora da lista documentada.
- Para fórmulas que exigem um motor de cálculo completo de planilha, calcule‑as externamente e depois atualize a pasta de trabalho do gráfico com os valores resultantes.

## **FAQ**

**Qual a diferença entre `Formula` e `R1C1Formula`?**

[Formula](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdatacell/formula/) armazena uma expressão no estilo A1 como `B2-C2`. [R1C1Formula](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdatacell/r1c1formula/) armazena uma expressão no estilo R1C1 como `RC[-2]-RC[-1]`. Use a notação que melhor corresponda à forma como você gera ou copia fórmulas.

**Preciso ler a própria célula ou seu valor após o cálculo?**

[IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdataworkbook/getcell/) retorna um `IChartDataCell`. Para obter o resultado calculado, leia a propriedade [Value](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdatacell/value/) dessa célula após a recalculação.

**Quando devo chamar `CalculateFormulas`?**

Chame [CalculateFormulas](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) depois de mudar valores de entrada ou fórmulas e antes de depender dos resultados calculados. Isso atualiza os valores das fórmulas que o avaliador interno suporta.

**O Aspose.Slides suporta todas as funções do Excel?**

Não. O avaliador interno suporta um subconjunto documentado de funções. Funções fora desse subconjunto não devem ser presumidas como recalculáveis corretamente. Se for necessária compatibilidade total com fórmulas do Excel, execute o cálculo com um motor de planilha adequado e grave os valores finais na pasta de trabalho do gráfico.

**O que acontece se uma apresentação carregada contiver uma fórmula não suportada?**

Se os dados do gráfico não foram alterados, a pasta de trabalho pode ainda conter um valor em cache calculado anteriormente. Após a modificação dos dados relacionados, esse valor em cache pode não ser mais válido. Acessar uma célula cuja fórmula não pode ser tratada pode gerar [CellUnsupportedDataException](https://reference.aspose.com/slides/pt/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

**Os valores de erro de fórmula são os mesmos que exceções .NET?**

Não. Um resultado como `#DIV/0!` é um valor de planilha produzido por um cálculo válido. Exceções como [CellInvalidFormulaException](https://reference.aspose.com/slides/pt/net/aspose.slides.spreadsheet/cellinvalidformulaexception/) ou [CellCircularReferenceException](https://reference.aspose.com/slides/pt/net/aspose.slides.spreadsheet/cellcircularreferenceexception/) indicam que a fórmula não pôde ser processada normalmente.

**Um gráfico é atualizado automaticamente quando uma célula de fórmula muda?**

Uma série de gráfico pode referenciar células da pasta de trabalho. Recalcule a pasta de trabalho primeiro, depois salve ou renderize a apresentação. Se os pontos de dados do gráfico referenciam as células calculadas, o gráfico usa esses valores atualizados; nenhum método de atualização de gráfico separado é necessário neste fluxo de trabalho.

**Os gráficos podem usar uma pasta de trabalho Excel externa?**

Sim, os dados do gráfico podem ser configurados para usar uma pasta de trabalho externa através da API de dados do gráfico. Contudo, o fluxo de cálculo de fórmulas descrito neste artigo refere‑se à pasta de trabalho de dados do gráfico e ao subconjunto de fórmulas avaliado pelo Aspose.Slides. Não presuma que [CalculateFormulas](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) forneça recalculação completa de fórmulas arbitrárias em um arquivo XLSX externo.

**Posso usar fórmulas que referenciam outra planilha ou pasta de trabalho?**

Referências no estilo Excel podem existir em pastas de trabalho de gráficos, mas a avaliação de fórmulas é limitada ao analisador e ao conjunto de funções suportados. Se uma referência cruzada de planilha ou externa for essencial, valide a fórmula exata com a versão do Aspose.Slides que você está usando. Para fluxos que exigem ampla compatibilidade de referências do Excel, calcule a pasta de trabalho externamente e grave os valores resolvidos de volta nos dados do gráfico.

**As strings de fórmula devem começar com `=`?**

Os exemplos da API Aspose.Slides atribuem expressões como `B2-C2` ou `SUM(B2:B5)` sem `=` inicial. Usar essa forma mantém as fórmulas geradas consistentes com os exemplos documentados da API.