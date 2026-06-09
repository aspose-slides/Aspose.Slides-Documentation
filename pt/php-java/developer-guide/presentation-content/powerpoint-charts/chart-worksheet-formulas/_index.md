---
title: Aplicar fórmulas de planilha de gráfico em apresentações usando PHP
linktitle: Fórmulas de Planilha
type: docs
weight: 70
url: /pt/php-java/chart-worksheet-formulas/
keywords:
- planilha de gráfico
- planilha de trabalho de gráfico
- fórmula de gráfico
- fórmula de planilha
- fórmula de planilha
- fonte de dados
- constante lógica
- constante numérica
- constante de texto
- constante de erro
- constante aritmética
- operador de comparação
- estilo A1
- estilo R1C1
- função predefinida
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Aplique fórmulas no estilo Excel no Aspose.Slides para PHP via planilhas de gráfico Java e automatize relatórios em arquivos PPT e PPTX."
---
## **Visão geral**

Uma planilha de gráfico é a fonte de dados por trás de um gráfico em uma apresentação. Ela armazena os nomes de categorias e séries juntamente com os valores numéricos exibidos pelo gráfico. No Aspose.Slides, esta planilha está disponível por meio do workbook de dados do gráfico, que permite trabalhar com os dados do gráfico programaticamente.

Este artigo explica como usar fórmulas de planilha nos dados do gráfico para que os valores das células possam ser calculados e atualizados automaticamente em vez de serem inseridos manualmente. Ele mostra como atribuir fórmulas, usar referências nos estilos A1 e R1C1, recalcular fórmulas do workbook e trabalhar com as constantes, operadores, referências de célula e funções predefinidas suportadas para planilhas de gráfico em apresentações.

## **Sobre fórmulas de planilha de gráfico em apresentações**

**Planilha de gráfico** (ou planilha de trabalho do gráfico) em uma apresentação é a fonte de dados do gráfico. A planilha contém os dados, que são representados no gráfico de forma gráfica. Quando você cria um gráfico no PowerPoint, a planilha associada a esse gráfico é criada automaticamente. A planilha de gráfico é criada para todos os tipos de gráficos: gráfico de linhas, gráfico de barras, gráfico de explosão solar, gráfico de pizza etc. Para ver a planilha de gráfico no PowerPoint, basta clicar duas vezes no gráfico:

![todo:image_alt_text](chart-worksheet-formulas_1.png)


A planilha contém os nomes dos elementos do gráfico (Nome da Categoria: *Category1*, Nome da Série) e uma tabela com dados numéricos correspondentes a essas categorias e séries. Por padrão, quando você cria um novo gráfico, os dados da planilha são definidos com os valores padrão. Depois você pode alterar os dados da planilha manualmente.

Normalmente, o gráfico representa dados complexos (por exemplo, analistas financeiros, analistas científicos), contendo células que são calculadas a partir de valores em outras células ou de outros dados dinâmicos. Calcular o valor da célula manualmente e codificá‑lo fixamente na célula dificulta sua alteração futura. Se você mudar o valor de uma determinada célula, todas as células dependentes também precisarão ser atualizadas. Além disso, os dados da tabela podem depender de dados de outras tabelas, criando um esquema de dados de apresentação complexo que precisa ser atualizado de maneira fácil e flexível.

**Fórmula de planilha de gráfico** em uma apresentação é uma expressão que calcula e atualiza automaticamente os dados da planilha de gráfico. A fórmula define a lógica de cálculo dos dados para uma célula ou conjunto de células. A fórmula pode ser matemática ou lógica, usando: referências de célula, funções matemáticas, operadores lógicos, operadores aritméticos, funções de conversão, constantes de texto etc. A definição da fórmula é escrita em uma célula, que então não contém um valor simples. A fórmula calcula o valor e o devolve, e esse valor é atribuído à célula. As fórmulas de planilha de gráfico em apresentações são, na prática, as mesmas que as fórmulas do Excel, e suportam as mesmas funções, operadores e constantes padrão.

Em [**Aspose.Slides**](https://products.aspose.com/slides/pt/php-java/) a planilha de gráfico é representada pelo método
[**ChartData::getChartDataWorkbook**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdata/#getChartDataWorkbook) do tipo
[**ChartDataWorkbook**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdataworkbook/).
A fórmula da planilha pode ser atribuída e alterada com o método
[**ChartDataCell::setFormula**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdatacell/#setFormula).
A funcionalidade a seguir é suportada para fórmulas no Aspose.Slides:

- Constantes lógicas
- Constantes numéricas
- Constantes de texto
- Constantes de erro
- Operadores aritméticos
- Operadores de comparação
- Referências de célula no estilo A1
- Referências de célula no estilo R1C1
- Funções predefinidas


Normalmente, as planilhas armazenam os últimos valores calculados das fórmulas. Se, após o carregamento da apresentação, os dados do gráfico não forem alterados, o método [**ChartDataCell::getValue**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdatacell/#getValue) retorna esses valores ao ler. Contudo, se os dados da planilha foram alterados, ao ler o valor ele lança a exceção [**CellUnsupportedDataException**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/CellUnsupportedDataException) para fórmulas não suportadas. Isso ocorre porque, quando as fórmulas são analisadas com sucesso, as dependências das células são determinadas e a correção dos últimos valores é verificada. Se a fórmula não puder ser analisada, a correção do valor da célula não pode ser garantida.

## **Adicionar uma fórmula de planilha de gráfico a uma apresentação**

Primeiro, adicione um gráfico ao primeiro slide de uma nova apresentação com
[ShapeCollection::addChart](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapecollection/#addChart).
A planilha do gráfico é criada automaticamente e pode ser acessada com o método
[**ChartData::getChartDataWorkbook**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdata/#getChartDataWorkbook):

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 150, 150, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    # ...
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Vamos escrever alguns valores em células com o método
[**ChartDataCell::setValue**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdatacell/#setValue) do tipo **Object**, que significa que você pode definir qualquer valor:

```php
  $workbook->getCell(0, "F2")->setValue(-2.5);
  $workbook->getCell(0, "G3")->setValue(6.3);
  $workbook->getCell(0, "H4")->setValue(3);

```

Agora, para escrever uma fórmula na célula, você pode usar o método
[**ChartDataCell::setFormula**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdatacell/#setFormula).

*Nota*: O método [**ChartDataCell::setFormula**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdatacell/#setFormula) é usado para definir referências de célula no estilo A1. 

Para definir uma fórmula no estilo R1C1, você pode usar o método
[**ChartDataCell::setR1C1Formula**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdatacell/#setR1C1Formula).

Então, se você tentar ler os valores das células B2 e C2, eles serão calculados:

```php
  $value1 = $cell1->getValue();// 7.8

  $value2 = $cell2->getValue();// 2.1


```

## **Constantes lógicas**

Você pode usar constantes lógicas como *FALSE* e *TRUE* em fórmulas de célula:

```php
  $workbook->getCell(0, "A2")->setValue(false);
  $cell = $workbook->getCell(0, "B2");
  $cell->setFormula("A2 = TRUE");
  $value = $cell->getValue();// o valor contém o booleano "false"


```

## **Constantes numéricas**

Números podem ser usados em notação decimal ou científica para criar fórmulas de planilha de gráfico:

```php
  $workbook->getCell(0, "A2")->setFormula("1 + 0.5");
  $workbook->getCell(0, "B2")->setFormula(".3 * 1E-2");

```

## **Constantes de texto**

Constante de string (ou literal) é um valor específico usado tal como está e que não muda. Constantes de texto podem ser: datas, textos, números etc.:

```php
  $workbook->getCell(0, "A2")->setFormula("\"abc\"");
  $workbook->getCell(0, "B2")->setFormula("\"2/3/2020 12:00\"");

```

## **Constantes de erro**

Às vezes não é possível calcular o resultado da fórmula. Nesse caso, o código de erro é exibido na célula em vez do seu valor. Cada tipo de erro possui um código específico:

- #DIV/0! – a fórmula tenta dividir por zero.
- #GETTING_DATA – pode ser exibido em uma célula enquanto seu valor ainda está sendo calculado.
- #N/A – informação ausente ou indisponível. Algumas causas podem ser: células usadas na fórmula vazias, espaço extra, erro ortográfico etc.
- #NAME? – uma célula ou outro objeto de fórmula não pode ser encontrado pelo nome.
- #NULL! – pode ocorrer quando há um erro na fórmula, como:  (,) ou um espaço usado em vez de dois‑pontos (:).
- #NUM! – número na fórmula pode ser inválido, muito longo ou muito pequeno etc.
- #REF! – referência de célula inválida.
- #VALUE! – tipo de valor inesperado. Por exemplo, valor de texto atribuído a célula numérica.

```php
  $cell = $workbook->getCell(0, "A2");
  $cell->setFormula("2 / 0");
  $value = $cell->getValue();// o valor contém a string "#DIV/0!"


```

## **Operadores aritméticos**

Você pode usar todos os operadores aritméticos em fórmulas de planilha de gráfico:

|**Operador**|**Significado**|**Exemplo**|
| :- | :- | :- |
|+ (sinal de adição)|Adição ou soma unária|2 + 3|
|- (sinal de subtração)|Subtração ou negação|2 - 3<br>-3|
|* (asterisco)|Multiplicação|2 * 3|
|/ (barra)|Divisão|2 / 3|
|% (sinal de porcentagem)|Porcentagem|30%|
|^ (circunflexo)|Exponenciação|2 ^ 3|

*Nota*: Para alterar a ordem de avaliação, coloque entre parênteses a parte da fórmula que deve ser calculada primeiro.

## **Operadores de comparação**

Você pode comparar os valores das células com os operadores de comparação. Quando dois valores são comparados usando esses operadores, o resultado é um valor lógico *TRUE* ou FALSE:

|**Operador**|**Significado**|**Exemplo**|
| :- | :- | :- |
|= (igual)|Igual a|A2 = 3|
|<> (diferente)|Diferente de|A2 <> 3|
|> (maior que)|Maior que|A2 > 3|
|>= (maior ou igual)|Maior ou igual a|A2 >= 3|
|< (menor que)|Menor que|A2 < 3|
|<= (menor ou igual)|Menor ou igual a|A2 <= 3|

## **Referências de célula no estilo A1**

**Referências de célula no estilo A1** são usadas em planilhas onde a coluna tem um identificador de letra (por exemplo, "*A*") e a linha tem um identificador numérico (por exemplo, "*1*"). As referências no estilo A1 podem ser usadas da seguinte forma:

|**Referência de célula**|**Exemplo**| | |
| :- | :- | :- | :- |
| | Absoluta | Relativa | Mista |
|Célula|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Linha|$2:$2|2:2|-|
|Coluna|$A:$A|A:A|-|
|Intervalo|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

Exemplo de uso de referência A1 em fórmula:

```php
  $workbook->getCell(0, "A2")->setFormula("C3 + SUM(F2:H5)");

```

## **Referências de célula no estilo R1C1**

**Referências de célula no estilo R1C1** são usadas em planilhas onde tanto a linha quanto a coluna têm identificadores numéricos. As referências no estilo R1C1 podem ser usadas da seguinte forma:

|**Referência de célula**|**Exemplo**| | |
| :- | :- | :- | :- |
| | Absoluta | Relativa | Mista |
|Célula|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Linha|R2|R[2]|-|
|Coluna|C3|C[3]|-|
|Intervalo|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

Exemplo de uso de referência R1C1 em fórmula:

```php
  $workbook->getCell(0, "A2")->setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");

```

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

Sim. O Aspose.Slides suporta workbooks externos como [fonte de dados de gráfico](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdatasourcetype/), permitindo que você use fórmulas de um XLSX fora da apresentação.

**As fórmulas do gráfico podem referenciar planilhas dentro do mesmo workbook pelo nome da planilha?**

Sim. As fórmulas seguem o modelo padrão de referência do Excel, de modo que você pode referenciar outras planilhas dentro do mesmo workbook ou de um workbook externo. Para referências externas, inclua o caminho e o nome do workbook usando a sintaxe do Excel.