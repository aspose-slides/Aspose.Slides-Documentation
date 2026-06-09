---
title: Aplicar fórmulas de planilha de gráfico em apresentações em .NET
linktitle: Fórmulas de planilha
type: docs
weight: 70
url: /pt/net/chart-worksheet-formulas/
keywords:
- planilha de gráfico
- planilha de gráfico
- fórmula de gráfico
- fórmula de planilha
- fórmula de planilha
- fonte de dados
- constante lógica
- constante numérica
- constante de string
- constante de erro
- constante aritmética
- operador de comparação
- estilo A1
- estilo R1C1
- função predefinida
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Aplicar fórmulas no estilo Excel no Aspose.Slides para .NET em planilhas de gráfico e automatizar relatórios em arquivos PPT e PPTX."
---
## **Visão geral**

Uma planilha de gráfico é a fonte de dados por trás de um gráfico em uma apresentação. Ela armazena nomes de categorias e séries juntamente com os valores numéricos exibidos pelo gráfico. No Aspose.Slides, essa planilha está disponível por meio da pasta de trabalho de dados do gráfico, que permite trabalhar com os dados do gráfico programaticamente.

Este artigo explica como usar fórmulas de planilha em dados de gráfico para que os valores das células possam ser calculados e atualizados automaticamente em vez de serem inseridos manualmente. Ele mostra como atribuir fórmulas, usar referências no estilo A1 e no estilo R1C1, recalcular fórmulas da pasta de trabalho e trabalhar com as constantes, operadores, referências de célula e funções predefinidas suportadas para planilhas de gráfico em apresentações.

## **Sobre as fórmulas de planilha de gráfico em apresentações**
**Planilha de gráfico** (ou planilha de gráfico) em uma apresentação é a fonte de dados do gráfico. A planilha de gráfico contém dados, que são representados no gráfico de forma gráfica. Quando você cria um gráfico no PowerPoint, a planilha associada a esse gráfico é criada automaticamente também. A planilha de gráfico é criada para todos os tipos de gráficos: gráfico de linhas, gráfico de barras, gráfico de explosão, gráfico de pizza etc. Para ver a planilha de gráfico no PowerPoint, você deve clicar duas vezes no gráfico:

![todo:image_alt_text](chart-worksheet-formulas_1.png)

A planilha de gráfico contém os nomes dos elementos do gráfico (Nome da Categoria: *Category1*, Nome da Série) e uma tabela com dados numéricos adequados a essas categorias e séries. Por padrão, quando você cria um novo gráfico, os dados da planilha de gráfico são definidos com os dados padrão. Em seguida, você pode alterar os dados da planilha manualmente.

Normalmente, o gráfico representa dados complexos (por exemplo, analistas financeiros, analistas científicos), possuindo células que são calculadas a partir dos valores de outras células ou de outros dados dinâmicos. Calcular o valor da célula manualmente e codificá‑lo diretamente na célula dificulta sua alteração futura. Se você alterar o valor de uma determinada célula, todas as células dependentes dela precisarão ser atualizadas também. Além disso, os dados da tabela podem depender dos dados de outras tabelas, criando um esquema de dados de apresentação complexo que precisa ser atualizado de forma fácil e flexível.

**Fórmula de planilha de gráfico** em uma apresentação é uma expressão para calcular e atualizar automaticamente os dados da planilha de gráfico. A fórmula de planilha define a lógica de cálculo dos dados para uma célula ou um conjunto de células. A fórmula de planilha é uma fórmula matemática ou lógica, que utiliza: referências de célula, funções matemáticas, operadores lógicos, operadores aritméticos, funções de conversão, constantes de string, etc. A definição da fórmula é escrita em uma célula, e essa célula não contém um valor simples. A fórmula de planilha calcula o valor e o devolve, então esse valor é atribuído à célula. As fórmulas de planilha de gráfico em apresentações são, na prática, as mesmas que as fórmulas do Excel, e há suporte às mesmas funções padrão, operadores e constantes para sua implementação.

Em [**Aspose.Slides**](https://products.aspose.com/slides/pt/net/) a planilha de gráfico é representada pela propriedade [**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdata/properties/chartdataworkbook) do tipo [**IChartDataWorkbook**](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdataworkbook). A fórmula de planilha pode ser atribuída e alterada com a propriedade [**IChartDataCell.Formula**](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdatacell/properties/formula). As funcionalidades a seguir são suportadas para fórmulas no Aspose.Slides:

- Constantes lógicas
- Constantes numéricas
- Constantes de string
- Constantes de erro
- Operadores aritméticos
- Operadores de comparação
- Referências de célula no estilo A1
- Referências de célula no estilo R1C1
- Funções predefinidas

Normalmente, as planilhas armazenam os últimos valores calculados das fórmulas. Se após o carregamento da apresentação os dados do gráfico não forem alterados, a propriedade **IChartDataCell.Value** retorna esses valores ao ler. Mas, se os dados da planilha foram alterados, ao ler a propriedade **ChartDataCell.Value** ocorre a **CellUnsupportedDataException** para as fórmulas não suportadas. Isso ocorre porque, quando as fórmulas são analisadas com sucesso, as dependências das células são determinadas e a correção dos últimos valores é verificada. Contudo, se a fórmula não puder ser analisada, a correção do valor da célula não pode ser garantida.

## **Adicionar uma fórmula de planilha de gráfico a uma apresentação**
Primeiro, adicione um gráfico com alguns dados de exemplo ao primeiro slide de uma nova apresentação usando [IShapeCollection.Shapes.AddChart](https://reference.aspose.com/slides/pt/net/aspose.slides.ishapecollection/addchart/methods/1). A planilha do gráfico é criada automaticamente e pode ser acessada com a propriedade [**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdata/properties/chartdataworkbook):

``` csharp

using (var presentation = new Presentation())

{

    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 150, 150, 500, 300);

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // ...

}

```

Vamos gravar alguns valores em células com a propriedade [**IChartDataCell.Value**](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdatacell/properties/value) do tipo **Object**, o que significa que você pode definir qualquer valor para a propriedade:

``` csharp

workbook.GetCell(0, "F2").Value = -2.5;

workbook.GetCell(0, "G3").Value = 6.3;

workbook.GetCell(0, "H4").Value = 3;

```

Agora, para escrever uma fórmula na célula, você pode usar a propriedade [**IChartDataCell.Formula**](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdatacell/properties/formula):

``` csharp
workbook.GetCell(0, "B2").Formula = "F2+G3+H4+1";
```

*Observação*: a propriedade [**IChartDataCell.Formula**](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdatacell/properties/formula) é usada para definir referências de célula no estilo A1.

Para definir a referência de célula [R1C1Formula](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdatacell/properties/r1c1formula), você pode usar a propriedade [**IChartDataCell.R1C1Formula**](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdatacell/properties/r1c1formula):

``` csharp
workbook.GetCell(0, "C2").R1C1Formula = "R[1]C[4]/R[2]C[5]";
```

Em seguida, use o método [**IChartDataWorkbook.CalculateFormulas**](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/chartdataworkbook/methods/calculateformulas) para calcular todas as fórmulas na pasta de trabalho e atualizar os valores correspondentes das células:

``` csharp
workbook.CalculateFormulas();

object value1 = workbook.GetCell(0, "B2"); // 7.8

object value2 = workbook.GetCell(0, "C2"); // 2.1

```

## **Constantes lógicas**
Você pode usar constantes lógicas como *FALSE* e *TRUE* em fórmulas de célula:

## **Constantes numéricas**
Números podem ser usados em notações comuns ou científicas para criar fórmulas de planilha de gráfico:

## **Constantes de string**
Uma constante de string (ou literal) é um valor específico usado como está e que não muda. Constantes de string podem ser: datas, textos, números etc.:

## **Constantes de erro**
Às vezes não é possível calcular o resultado pela fórmula. Nesse caso, o código de erro é exibido na célula em vez do seu valor. Cada tipo de erro tem um código específico:

- #DIV/0! – a fórmula tenta dividir por zero.
- #GETTING_DATA – pode ser exibido em uma célula enquanto seu valor ainda está sendo calculado.
- #N/A – a informação está ausente ou não disponível. Algumas razões podem ser: as células usadas na fórmula estão vazias, um caractere de espaço extra, erro de digitação etc.
- #NAME? – uma certa célula ou outro objeto de fórmula não pode ser encontrado pelo nome.
- #NULL! – pode aparecer quando há um erro na fórmula, como:  (,) ou um espaço usado em vez de dois‑pontos (:).
- #NUM! – o número na fórmula pode ser inválido, muito longo ou muito pequeno etc.
- #REF! – referência de célula inválida.
- #VALUE! – tipo de valor inesperado. Por exemplo, valor de string definido em célula numérica.

## **Operadores aritméticos**
Você pode usar todos os operadores aritméticos em fórmulas de planilha de gráfico:

|**Operador**|**Significado**|**Exemplo**|
| :- | :- | :- |
|+ (sinal de adição)|Adição ou sinal positivo unário|2 + 3|
|- (sinal de subtração)|Subtração ou negação|2 - 3<br>-3|
|* (asterisco)|Multiplicação|2 * 3|
|/ (barra)|Divisão|2 / 3|
|% (por cento)|Porcentagem|30%|
|^ (acento circunflexo)|Exponenciação|2 ^ 3|

*Observação*: para mudar a ordem de avaliação, coloque entre parênteses a parte da fórmula que deve ser calculada primeiro.

## **Operadores de comparação**
Você pode comparar os valores das células com os operadores de comparação. Quando dois valores são comparados usando esses operadores, o resultado é um valor lógico *TRUE* ou *FALSE*:

|**Operador**|**Significado**|**Exemplo**|
| :- | :- | :- |
|= (igualdade)|Igual a|A2 = 3|
|<> (diferente)|Diferente de|A2 <> 3|
|> (maior que)|Maior que|A2 > 3|
|>= (maior ou igual)|Maior ou igual a|A2 >= 3|
|< (menor que)|Menor que|A2 < 3|
|<= (menor ou igual)|Menor ou igual a|A2 <= 3|

## **Referências de célula no estilo A1**
**Referências de célula no estilo A1** são usadas para as planilhas, onde a coluna tem um identificador de letra (por exemplo, "*A*") e a linha tem um identificador numérico (por exemplo, "*1*"). As referências no estilo A1 podem ser usadas da seguinte forma:

|**Referência de célula**|**Exemplo**|||
| :- | :- | :- | :- |
||Absoluta|Relativa|Mista|
|Célula|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Linha|$2:$2|2:2|-|
|Coluna|$A:$A|A:A|-|
|Intervalo|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

Aqui está um exemplo de como usar referência de célula no estilo A1 em uma fórmula:

## **Referências de célula no estilo R1C1**
**Referências de célula no estilo R1C1** são usadas para as planilhas, onde tanto a linha quanto a coluna têm identificadores numéricos. As referências no estilo R1C1 podem ser usadas da seguinte forma:

|**Referência de célula**|**Exemplo**|||
| :- | :- | :- | :- |
||Absoluta|Relativa|Mista|
|Célula|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Linha|R2|R[2]|-|
|Coluna|C3|C[3]|-|
|Intervalo|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

Aqui está um exemplo de como usar referência de célula no estilo A1 em uma fórmula:

## **Funções predefinidas**
Existem funções predefinidas que podem ser usadas nas fórmulas para simplificar sua implementação. Essas funções encapsulam as operações mais comumente usadas, como:

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (sistema de data 1900)
- DAYS
- FIND
- FINDB
- IF
- INDEX (forma de referência)
- LOOKUP (forma vetorial)
- MATCH (forma vetorial)
- MAX
- SUM
- VLOOKUP

## **FAQ**

**Arquivos Excel externos são suportados como fonte de dados para um gráfico com fórmulas?**

Sim. O Aspose.Slides suporta pastas de trabalho externas como [fonte de dados do gráfico](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/chartdatasourcetype/), o que permite usar fórmulas de um XLSX fora da apresentação.

**As fórmulas de gráfico podem referenciar planilhas dentro da mesma pasta de trabalho pelo nome da planilha?**

Sim. As fórmulas seguem o modelo padrão de referência do Excel, portanto você pode referenciar outras planilhas dentro da mesma pasta de trabalho ou uma pasta de trabalho externa. Para referências externas, inclua o caminho e o nome da pasta de trabalho usando a sintaxe do Excel.