---
title: Aplicar Fórmulas de Planilha de Gráfico em Apresentações com Python
linktitle: Fórmulas de Planilha
type: docs
weight: 70
url: /pt/python-net/chart-worksheet-formulas/
keywords:
- planilha de gráfico
- planilha de gráfico
- fórmula de gráfico
- fórmula de planilha
- fórmula de planilha
- fonte de dados
- constante lógica
- constante numérica
- constante de cadeia
- constante de erro
- constante aritmética
- operador de comparação
- estilo A1
- estilo R1C1
- função predefinida
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Aplicar fórmulas ao estilo Excel no Aspose.Slides para Python via planilhas de gráfico .NET e automatizar relatórios em arquivos PPT, PPTX e ODP."
---
## **Visão geral**

Uma planilha de gráfico é a fonte de dados por trás de um gráfico em uma apresentação. Ela armazena os nomes de categorias e séries juntamente com os valores numéricos exibidos pelo gráfico. No Aspose.Slides, essa planilha está disponível por meio do chart data workbook, que permite trabalhar com os dados do gráfico programaticamente.

Este artigo explica como usar fórmulas de planilha em dados de gráfico para que os valores das células possam ser calculados e atualizados automaticamente em vez de serem inseridos manualmente. Ele mostra como atribuir fórmulas, usar referências no estilo A1 e no estilo R1C1, recalcular as fórmulas do workbook e trabalhar com as constantes, operadores, referências de célula e funções predefinidas suportadas para planilhas de gráfico em apresentações.

## **Sobre a fórmula de planilha de gráfico na apresentação**
**Planilha de gráfico** (ou planilha de worksheet) em uma apresentação é a fonte de dados do gráfico. A planilha de gráfico contém dados, que são representados no gráfico de forma gráfica. Quando você cria um gráfico no PowerPoint, a planilha associada a esse gráfico também é criada automaticamente. A planilha de gráfico é criada para todos os tipos de gráficos: gráfico de linhas, gráfico de barras, gráfico sunburst, gráfico de pizza etc. Para ver a planilha de gráfico no PowerPoint, você deve dar um duplo clique no gráfico:

![todo:image_alt_text](chart-worksheet-formulas_1.png)



A planilha de gráfico contém os nomes dos elementos do gráfico (Nome da Categoria: *Category1*, Nome da Série) e uma tabela com dados numéricos apropriados a essas categorias e séries. Por padrão, quando você cria um novo gráfico, os dados da planilha de gráfico são definidos com os dados padrão. Em seguida, você pode alterar os dados da planilha manualmente.

Normalmente, o gráfico representa dados complexos (por exemplo, analistas financeiros, analistas científicos), tendo células que são calculadas a partir dos valores em outras células ou de outros dados dinâmicos. Calcular o valor da célula manualmente e codificá‑lo rigidamente na célula dificulta alterá‑lo no futuro. Se você alterar o valor de uma determinada célula, todas as células dependentes dela precisarão ser atualizadas também. Além disso, os dados da tabela podem depender de dados de outras tabelas, criando um esquema de dados de apresentação complexo que precisa ser atualizado de forma fácil e flexível.

**Fórmula de planilha de gráfico** em uma apresentação é uma expressão para calcular e atualizar automaticamente os dados da planilha de gráfico. A fórmula de planilha define a lógica de cálculo dos dados para uma determinada célula ou conjunto de células. A fórmula de planilha é uma fórmula matemática ou lógica, que usa: referências de célula, funções matemáticas, operadores lógicos, operadores aritméticos, funções de conversão, constantes de cadeia, etc. A definição da fórmula é escrita em uma célula, e essa célula não contém um valor simples. A fórmula de planilha calcula o valor e o devolve, então esse valor é atribuído à célula. As fórmulas de planilha de gráfico em apresentações são na verdade as mesmas que as fórmulas do Excel, e há suporte às mesmas funções padrão, operadores e constantes para sua implementação.

Em [**Aspose.Slides**](https://products.aspose.com/slides/pt/python-net/) a planilha de gráfico é representada com a propriedade [**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/ichartdata/) do tipo [**IChartDataWorkbook**](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/ichartdataworkbook/). A fórmula de planilha pode ser atribuída e alterada com a propriedade [**formula**](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/ichartdatacell/). As funcionalidades a seguir são suportadas para fórmulas no Aspose.Slides:

- Constantes lógicas
- Constantes numéricas
- Constantes de cadeia
- Constantes de erro
- Operadores aritméticos
- Operadores de comparação
- Referências de célula no estilo A1
- Referências de célula no estilo R1C1
- Funções predefinidas

Normalmente, as planilhas armazenam os últimos valores calculados das fórmulas. Se, após o carregamento da apresentação, os dados do gráfico não foram alterados, a propriedade **IChartDataCell.Value** retorna esses valores ao ler. Mas, se os dados da planilha foram alterados, ao ler a propriedade **ChartDataCell.Value** ocorre a **CellUnsupportedDataException** para as fórmulas não suportadas. Isso ocorre porque, quando as fórmulas são analisadas com sucesso, as dependências das células são determinadas e a corretude dos últimos valores é verificada. Porém, se a fórmula não puder ser analisada, a corretude do valor da célula não pode ser garantida.

## **Adicionar fórmula de planilha de gráfico à apresentação**
Primeiro, adicione um gráfico com alguns dados de exemplo ao primeiro slide de uma nova apresentação com [add_chart](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ishapecollection/). A planilha do gráfico é criada automaticamente e pode ser acessada com a propriedade [**chart_data_workbook**](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/ichartdata/):

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 150, 150, 500, 300)
    workbook = chart.chart_data.chart_data_workbook
    # ...
```

Vamos escrever alguns valores nas células com a propriedade [**value**](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/ichartdatacell/) do tipo **Object**, que significa que você pode definir qualquer valor para a propriedade:

```py
    workbook.get_cell(0, "F2").value = -2.5
    workbook.get_cell(0, "G3").value = 6.3
    workbook.get_cell(0, "H4").value = 3
```

Agora, para escrever uma fórmula na célula, você pode usar a propriedade [**formula**](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/ichartdatacell/):

```py
    workbook.get_cell(0, "B2").formula = "F2+G3+H4+1"
```

*Nota*: [**IChartDataCell.Formula**](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/ichartdatacell/) é usada para definir referências de célula no estilo A1.

Para definir a referência de célula [r1c1_formula](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/ichartdatacell/), você pode usar a propriedade [**r1c1_formula**](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/ichartdatacell/):

```py
    workbook.get_cell(0, "C2").r1c1_formula = "R[1]C[4]/R[2]C[5]"
```

Em seguida, use o método [**calculate_formulas**](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdataworkbook/) para calcular todas as fórmulas dentro do workbook e atualizar os valores correspondentes das células:

```py
    workbook.calculate_formulas()
    print(workbook.get_cell(0, "B2").value) # 7.8
    print(workbook.get_cell(0, "C2").value) # 2.1
```

## **Constantes lógicas**
Você pode usar constantes lógicas como *FALSE* e *TRUE* em fórmulas de célula:

## **Constantes numéricas**
Números podem ser usados em notação comum ou científica para criar fórmulas de planilha de gráfico:

## **Constantes de cadeia**
Constante de cadeia (ou literal) é um valor específico que é usado como está e não muda. Constantes de cadeia podem ser: datas, textos, números etc.:

## **Constantes de erro**
Às vezes não é possível calcular o resultado pela fórmula. Nesse caso, o código de erro é exibido na célula em vez do seu valor. Cada tipo de erro tem um código específico:

- #DIV/0! - a fórmula tenta dividir por zero.
- #GETTING_DATA - pode ser exibido em uma célula enquanto seu valor ainda está sendo calculado.
- #N/A - informação ausente ou indisponível. Algumas causas podem ser: as células usadas na fórmula estão vazias, um caractere de espaço extra, erro de ortografia etc.
- #NAME? - uma certa célula ou outro objeto de fórmula não pode ser encontrado pelo seu nome.
- #NULL! - pode aparecer quando há um erro na fórmula, como:  (,) ou um caractere de espaço usado em vez de dois‑pontos (:).
- #NUM! - o número na fórmula pode ser inválido, muito longo ou muito pequeno etc.
- #REF! - referência de célula inválida.
- #VALUE! - tipo de valor inesperado. Por exemplo, valor de cadeia atribuído a uma célula numérica.

## **Operadores aritméticos**
Você pode usar todos os operadores aritméticos em fórmulas de planilha de gráfico:

|**Operador**|**Significado**|**Exemplo**|
| :- | :- | :- |
|+ (sinal de adição)|Adição ou sinal positivo unário|2 + 3|
|- (sinal de subtração)|Subtração ou negação|2 - 3<br>-3|
|* (asterisco)|Multiplicação|2 * 3|
|/ (barra)|Divisão|2 / 3|
|% (porcentagem)|Porcentagem|30%|
|^ (circunflexo)|Exponenciação|2 ^ 3|

*Nota*: Para alterar a ordem de avaliação, coloque entre parênteses a parte da fórmula que deve ser calculada primeiro.

## **Operadores de comparação**
Você pode comparar os valores das células com os operadores de comparação. Quando dois valores são comparados usando esses operadores, o resultado é um valor lógico *TRUE* ou *FALSE*:

|**Operador**|**Significado**|**Significado**|
| :- | :- | :- |
|= (igual)|Igual a|A2 = 3|
|<> (diferente)|Diferente de|A2 <> 3|
|> (maior que)|Maior que|A2 > 3|
|>= (maior ou igual)|Maior ou igual a|A2 >= 3|
|< (menor que)|Menor que|A2 < 3|
|<= (menor ou igual)|Menor ou igual a|A2 <= 3|

## **Referências de célula no estilo A1**
**Referências de célula no estilo A1** são usadas nas planilhas, onde a coluna tem um identificador de letra (ex.: "*A*") e a linha tem um identificador numérico (ex.: "*1*"). Referências de célula no estilo A1 podem ser usadas da seguinte forma:

|**Referência de célula**|**Exemplo**|**Absoluta**|**Relativa**|**Mista**|
| :- | :- | :- | :- | :- |
|Célula|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Linha|$2:$2|2:2|-|
|Coluna|$A:$A|A:A|-|
|Intervalo|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

Aqui está um exemplo de como usar referência de célula no estilo A1 em uma fórmula:

## **Referências de célula no estilo R1C1**
**Referências de célula no estilo R1C1** são usadas nas planilhas, onde tanto a linha quanto a coluna têm identificador numérico. Referências de célula no estilo R1C1 podem ser usadas da seguinte forma:

|**Referência de célula**|**Exemplo**|**Absoluta**|**Relativa**|**Mista**|
| :- | :- | :- | :- | :- |
|Célula|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Linha|R2|R[2]|-|
|Coluna|C3|C[3]|-|
|Intervalo|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

Aqui está um exemplo de como usar referência de célula no estilo A1 em uma fórmula:

## **Funções predefinidas**
Existem funções predefinidas que podem ser usadas nas fórmulas para simplificar sua implementação. Essas funções encapsulam as operações mais usadas, como:

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

Sim. Aspose.Slides suporta workbooks externos como [fonte de dados do gráfico](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdatasourcetype/), o que permite usar fórmulas de um XLSX fora da apresentação.

**Fórmulas de gráfico podem referenciar planilhas dentro do mesmo workbook pelo nome da planilha?**

Sim. As fórmulas seguem o modelo padrão de referência do Excel, portanto você pode referenciar outras planilhas dentro do mesmo workbook ou de um workbook externo. Para referências externas, inclua o caminho e o nome do workbook usando a sintaxe do Excel.