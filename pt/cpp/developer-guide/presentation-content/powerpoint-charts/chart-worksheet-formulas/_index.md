---
title: Aplicar Fórmulas de Planilha de Gráfico em Apresentações Usando C++
linktitle: Fórmulas de Planilha
type: docs
weight: 70
url: /pt/cpp/chart-worksheet-formulas/
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
- C++
- Aspose.Slides
description: "Aplicar fórmulas no estilo Excel no Aspose.Slides para planilhas de gráfico C++ e automatizar relatórios em arquivos PPT e PPTX."
---
## **Visão geral**

Uma planilha de gráfico é a fonte de dados por trás de um gráfico em uma apresentação. Ela armazena nomes de categorias e séries juntamente com os valores numéricos exibidos pelo gráfico. No Aspose.Slides, essa planilha está disponível por meio da pasta de trabalho de dados do gráfico, que permite trabalhar com os dados do gráfico programaticamente.

Este artigo explica como usar fórmulas de planilha em dados de gráfico para que os valores das células possam ser calculados e atualizados automaticamente em vez de serem inseridos manualmente. Ele mostra como atribuir fórmulas, usar referências nos estilos A1 e R1C1, recalcular fórmulas da pasta de trabalho e trabalhar com as constantes, operadores, referências de célula e funções predefinidas suportadas para planilhas de gráfico em apresentações.

## **Sobre Fórmulas de Planilha de Gráfico em Apresentações**
**Planilha de gráfico** (ou planilha de gráfico) em uma apresentação é a fonte de dados do gráfico. A planilha de gráfico contém dados, que são representados no gráfico de forma gráfica. Quando você cria um gráfico no PowerPoint, a planilha associada a esse gráfico é criada automaticamente também. A planilha de gráfico é criada para todos os tipos de gráficos: gráfico de linhas, gráfico de barras, gráfico sunburst, gráfico de pizza, etc. Para ver a planilha de gráfico no PowerPoint, deve‑se clicar duas vezes no gráfico:

![todo:image_alt_text](chart-worksheet-formulas_1.png)

A planilha de gráfico contém os nomes dos elementos do gráfico (Nome da categoria: *Category1*, Nome da série) e uma tabela com dados numéricos adequados a essas categorias e séries. Por padrão, quando você cria um novo gráfico – os dados da planilha de gráfico são definidos com os dados padrão. Em seguida, você pode mudar os dados da planilha manualmente.

Geralmente, o gráfico representa dados complicados (por exemplo, analistas financeiros, analistas científicos), tendo células que são calculadas a partir dos valores em outras células ou de outros dados dinâmicos. Calcular o valor da célula manualmente e codificá‑lo na célula dificulta a alteração futura. Se você mudar o valor de uma determinada célula, todas as células dependentes dela precisarão ser atualizadas também. Além disso, os dados da tabela podem depender dos dados de outras tabelas, criando um esquema de dados de apresentação complexo que precisa ser atualizado de forma fácil e flexível.

**Fórmula de planilha de gráfico** em uma apresentação é uma expressão para calcular e atualizar automaticamente os dados da planilha de gráfico. A fórmula de planilha define a lógica de cálculo dos dados para uma certa célula ou conjunto de células. A fórmula de planilha é uma fórmula matemática ou lógica, que usa: referências de célula, funções matemáticas, operadores lógicos, operadores aritméticos, funções de conversão, constantes de string, etc. A definição da fórmula é escrita em uma célula, e essa célula não contém um valor simples. A fórmula de planilha calcula o valor e o retorna, então esse valor é atribuído à célula. As fórmulas de planilha de gráfico em apresentações são, na prática, as mesmas que as fórmulas do Excel, e existem as mesmas funções, operadores e constantes padrão suportados para sua implementação.

Em [**Aspose.Slides**](https://products.aspose.com/slides/pt/cpp/) a planilha de gráfico é representada com 
[**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea) do tipo 
[**IChartDataWorkbook**](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.charts.i_chart_data_workbook). 
A fórmula de planilha pode ser atribuída e alterada com 
[**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692). 
A funcionalidade a seguir é suportada para fórmulas no Aspose.Slides:

- Constantes lógicas
- Constantes numéricas
- Constantes de string
- Constantes de erro
- Operadores aritméticos
- Operadores de comparação
- Referências de célula no estilo A1
- Referências de célula no estilo R1C1
- Funções predefinidas



Normalmente, as planilhas armazenam os últimos valores calculados das fórmulas. Se, após o carregamento da apresentação, os dados do gráfico não forem alterados – **IChartDataCell.get_Value()** retorna esses valores ao ler. Mas, se os dados da planilha foram alterados, ao ler **ChartDataCell.get_Value()** ele lança a **CellUnsupportedDataException** para as fórmulas não suportadas. Isso ocorre porque, quando as fórmulas são analisadas com sucesso, as dependências das células são determinadas e a correção dos últimos valores é verificada. Se a fórmula não puder ser analisada, a correção do valor da célula não pode ser garantida.

## **Adicionar uma Fórmula de Planilha de Gráfico a uma Apresentação**
Primeiro, adicione um gráfico ao primeiro slide de uma nova apresentação com 
[IShapeCollection::AddChart()](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_shape_collection#a2cd4d47fc5c536012ee15b3a69486374). 
A planilha do gráfico é criada automaticamente e pode ser acessada com 
[**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea) :

``` cpp
auto presentation = System::MakeObject<Presentation>();
    
auto chart = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 150.0f, 150.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// ...
```

Vamos escrever alguns valores nas células com 
[**IChartDataCell.set_Value()**](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.charts.i_chart_data_cell#ad85809f520195e09225abae9002635ec) do tipo **Object**, o que significa que você pode passar qualquer valor para o método:

``` cpp
workbook->GetCell(0, u"F2")->set_Value(System::ObjectExt::Box<double>(-2.5));
workbook->GetCell(0, u"G3")->set_Value(System::ObjectExt::Box<double>(6.3));
workbook->GetCell(0, u"H4")->set_Value(System::ObjectExt::Box<int32_t>(3));
```

Agora, para escrever uma fórmula na célula, você pode usar o 
[**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692) :

*Nota*: [**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692) é usado para definir referências de célula no estilo A1. 

Para definir a referência de célula R1C1Formula, você pode usar o [**IChartDataCell::set_R1C1Formula()**](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.charts.i_chart_data_cell#a47f5825dd38d0dddb11ecc3a43d388c7) :

Em seguida, se você ler os valores das células B2 e C2, eles serão calculados:

``` cpp
auto value1 = cell1->get_Value(); // 7.8
auto value2 = cell2->get_Value(); // 2.1
```

## **Constantes Lógicas**
Você pode usar constantes lógicas como *FALSE* e *TRUE* em fórmulas de célula:

## **Constantes Numéricas**
Números podem ser usados em notação comum ou científica para criar fórmulas de planilha de gráfico:

## **Constantes de String**
Constante de string (ou literal) é um valor específico que é usado tal como está e não muda. Constantes de string podem ser: datas, textos, números, etc.:

## **Constantes de Erro**
Às vezes não é possível calcular o resultado pela fórmula. Nesse caso, o código de erro é mostrado na célula em vez do seu valor. Cada tipo de erro tem um código específico:

- #DIV/0! - a fórmula tenta dividir por zero.
- #GETTING_DATA - pode ser exibido em uma célula enquanto seu valor ainda está sendo calculado.
- #N/A - a informação está ausente ou não disponível. Algumas razões podem ser: as células usadas na fórmula estão vazias, um caractere de espaço extra, erro de digitação, etc.
- #NAME? - uma certa célula ou outro objeto de fórmula não pode ser encontrado pelo nome. 
- #NULL! - pode aparecer quando há um erro na fórmula, como:  (,) ou um caractere de espaço usado em vez de dois‑pontos (:).
- #NUM! - o número na fórmula pode ser inválido, muito grande ou muito pequeno, etc.
- #REF! - referência de célula inválida.
- #VALUE! - tipo de valor inesperado. Por exemplo, valor de string atribuído a célula numérica.

## **Operadores Aritméticos**
Você pode usar todos os operadores aritméticos em fórmulas de planilha de gráfico:

|**Operador** |**Significado** |**Exemplo**|
| :- | :- | :- |
|+ (sinal de mais) |Adição ou sinal unário positivo|2 + 3|
|- (sinal de menos) |Subtração ou negação |2 - 3<br>-3|
|* (asterisco)|Multiplicação |2 * 3|
|/ (barra)|Divisão |2 / 3|
|% (sinal de porcentagem) |Porcentagem |30%|
|^ (caret) |Exponenciação |2 ^ 3|

*Nota*: Para mudar a ordem de avaliação, envolva entre parênteses a parte da fórmula que deve ser calculada primeiro.

## **Operadores de Comparação**
Você pode comparar valores de células com os operadores de comparação. Quando dois valores são comparados usando esses operadores, o resultado é um valor lógico *TRUE* ou FALSE:

|**Operador** |**Significado** |**Exemplo**|
| :- | :- | :- |
|= (sinal de igual) |Igual a |A2 = 3|
|<> (sinal de diferente) |Diferente de|A2 <> 3|
|> (sinal maior que) |Maior que|A2 > 3|
|>= (sinal maior ou igual) |Maior ou igual a|A2 >= 3|
|< (sinal menor que) |Menor que|A2 < 3|
|<= (sinal menor ou igual) |Menor ou igual a|A2 <= 3|

## **Referências de Célula no Estilo A1**
**Referências de célula no estilo A1** são usadas para planilhas, onde a coluna tem um identificador de letra (por exemplo, "*A*") e a linha tem um identificador numérico (por exemplo, "*1*"). Referências de célula no estilo A1 podem ser usadas da seguinte forma:

|**Referência de célula**|**Exemplo**|||
| :- | :- | :- | :- |
||Absoluta |Relativa |Mista|
|Célula |$A$2 |A2|<p>A$2</p><p>$A2</p>|
|Linha |$2:$2 |2:2 |-|
|Coluna |$A:$A |A:A |-|
|Intervalo |$A$2:$C$4 |A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

Aqui está um exemplo de como usar referência de célula no estilo A1 em uma fórmula:

## **Referências de Célula no Estilo R1C1**
**Referências de célula no estilo R1C1** são usadas para planilhas, onde tanto a linha quanto a coluna têm identificador numérico. Referências de célula no estilo R1C1 podem ser usadas da seguinte forma:

|**Referência de célula**|**Exemplo**|||
| :- | :- | :- | :- |
||Absoluta |Relativa |Mista|
|Célula |R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Linha |R2|R[2]|-|
|Coluna |C3|C[3]|-|
|Intervalo |R2C3:R5C7|R[2]C[3]:R[5]C[7] |R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

Aqui está um exemplo de como usar referência de célula no estilo A1 em uma fórmula:

## **Funções Predefinidas**
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

Sim. O Aspose.Slides suporta pastas de trabalho externas como [fonte de dados do gráfico](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/chartdatasourcetype/), o que permite usar fórmulas de um XLSX fora da apresentação.

**Fórmulas de gráfico podem referenciar planilhas dentro da mesma pasta de trabalho pelo nome da planilha?**

Sim. As fórmulas seguem o modelo padrão de referência do Excel, portanto você pode referenciar outras planilhas dentro da mesma pasta de trabalho ou uma pasta de trabalho externa. Para referências externas, inclua o caminho e o nome da pasta de trabalho usando a sintaxe do Excel.