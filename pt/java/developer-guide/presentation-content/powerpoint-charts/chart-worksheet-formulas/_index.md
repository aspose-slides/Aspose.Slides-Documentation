---
title: Aplicar fórmulas de planilha de gráfico em apresentações usando Java
linktitle: Fórmulas de planilha
type: docs
weight: 70
url: /pt/java/chart-worksheet-formulas/
keywords:
- planilha de gráfico
- planilha de gráfico
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
- função pré-definida
- PowerPoint
- apresentação
- Java
- Aspose.Slides
description: "Aplicar fórmulas no estilo Excel nas planilhas de gráfico do Aspose.Slides para Java e automatizar relatórios em arquivos PPT e PPTX."
---
## **Visão geral**

Uma planilha de gráfico é a fonte de dados por trás de um gráfico em uma apresentação. Ela armazena nomes de categorias e séries juntamente com os valores numéricos exibidos pelo gráfico. No Aspose.Slides, essa planilha está disponível por meio da pasta de trabalho de dados de gráfico, que permite trabalhar com os dados do gráfico programaticamente.

Este artigo explica como usar fórmulas de planilha em dados de gráfico para que os valores das células sejam calculados e atualizados automaticamente em vez de inseridos manualmente. Ele mostra como atribuir fórmulas, usar referências no estilo A1 e R1C1, recalcular fórmulas da pasta de trabalho e trabalhar com as constantes, operadores, referências de célula e funções predefinidas suportadas para planilhas de gráfico em apresentações.

## **Sobre fórmulas de planilha de gráfico em apresentações**
**Planilha de gráfico** (ou planilha de gráfico) em uma apresentação é a fonte de dados do gráfico. A planilha de gráfico contém dados, que são representados no gráfico de forma gráfica. Quando você cria um gráfico no PowerPoint, a planilha associada a esse gráfico é criada automaticamente também. A planilha de gráfico é criada para todos os tipos de gráficos: gráfico de linhas, gráfico de barras, gráfico sunburst, gráfico de pizza, etc. Para ver a planilha de gráfico no PowerPoint, clique duas vezes no gráfico:

![todo:image_alt_text](chart-worksheet-formulas_1.png)


A planilha de gráfico contém os nomes dos elementos do gráfico (Nome da Categoria: *Category1*, Nome da Série) e uma tabela com dados numéricos adequados a essas categorias e séries. Por padrão, quando você cria um novo gráfico – os dados da planilha de gráfico são definidos com os dados padrão. Depois você pode alterar os dados da planilha manualmente.

Normalmente, o gráfico representa dados complexos (por exemplo, analistas financeiros, analistas científicos), tendo células que são calculadas a partir dos valores em outras células ou de outros dados dinâmicos. Calcular o valor da célula manualmente e codificá‑lo rigidamente na célula dificulta sua alteração futura. Se você alterar o valor de uma certa célula, todas as células dependentes dela precisarão ser atualizadas também. Além disso, os dados da tabela podem depender dos dados de outras tabelas, criando um esquema de dados de apresentação complexo que precisa ser atualizado de forma fácil e flexível.

**Fórmula de planilha de gráfico** em uma apresentação é uma expressão para calcular e atualizar automaticamente os dados da planilha de gráfico. A fórmula de planilha define a lógica de cálculo dos dados para uma determinada célula ou conjunto de células. A fórmula de planilha é uma fórmula matemática ou lógica, que usa: referências de célula, funções matemáticas, operadores lógicos, operadores aritméticos, funções de conversão, constantes de string etc. A definição da fórmula é escrita em uma célula, e essa célula não contém um valor simples. A fórmula de planilha calcula o valor e o devolve, então esse valor é atribuído à célula. As fórmulas de planilha de gráfico em apresentações são, na prática, as mesmas que as fórmulas do Excel, e suportam as mesmas funções padrão, operadores e constantes para sua implementação.

Em [**Aspose.Slides**](https://products.aspose.com/slides/pt/java/) a planilha de gráfico é representada com 
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IChartData#getChartDataWorkbook--) método do
[**IChartDataWorkbook**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IChartDataWorkbook) tipo. 
A fórmula de planilha pode ser atribuída e alterada com 
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) método. 
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


Normalmente, as planilhas armazenam os últimos valores calculados das fórmulas. Se, após o carregamento da apresentação, os dados do gráfico não foram alterados – [**IChartDataCell.getValue**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IChartDataCell#getValue--) método retorna esses valores durante a leitura. Mas, se os dados da planilha foram alterados, ao ler a propriedade **ChartDataCell.Value** é lançada a exceção [**CellUnsupportedDataException**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/CellUnsupportedDataException) para as fórmulas não suportadas. Isso ocorre porque, quando as fórmulas são analisadas com sucesso, as dependências das células são determinadas e a correção dos últimos valores é verificada. Porém, se a fórmula não puder ser analisada, a correção do valor da célula não pode ser garantida.

## **Adicionar uma fórmula de planilha de gráfico a uma apresentação**
Primeiro, adicione um gráfico ao primeiro slide de uma nova apresentação com 
[IShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IShapeCollection#addChart-int-float-float-float-float-). 
A planilha do gráfico é criada automaticamente e pode ser acessada com 
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IChartData#getChartDataWorkbook--) método:



```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 150, 150, 500, 300);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    // ...
} finally {
    if (pres != null) pres.dispose();
}
```

Vamos escrever alguns valores em células com 
[**IChartDataCell.setValue**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IChartDataCell#setValue-java.lang.Object-) propriedade 
do tipo **Object**, que significa que você pode definir qualquer valor na propriedade:

```java
workbook.getCell(0, "F2").setValue(-2.5);

workbook.getCell(0, "G3").setValue(6.3);

workbook.getCell(0, "H4").setValue(3);
```

Agora, para escrever uma fórmula na célula, você pode usar o 
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) método:

*Nota*: [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) método é usado para definir referências de célula no estilo A1. 

Para definir a referência de célula [R1C1Formula](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IChartDataCell#getR1C1Formula--) , você pode usar o método [**IChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IChartDataCell#setR1C1Formula-java.lang.String-):

Então, se você tentar ler os valores das células B2 e C2, eles serão calculados:

```java
Object value1 = cell1.getValue(); // 7.8

Object value2 = cell2.getValue(); // 2.1
```

## **Constantes lógicas**
Você pode usar constantes lógicas como *FALSE* e *TRUE* em fórmulas de célula:

```java
workbook.getCell(0, "A2").setValue(false);
IChartDataCell cell = workbook.getCell(0, "B2");
cell.setFormula("A2 = TRUE");
Object value = cell.getValue(); // o valor contém o booleano "false"
```

## **Constantes numéricas**
Números podem ser usados em notação comum ou científica para criar fórmulas de planilha de gráfico:

```java
workbook.getCell(0, "A2").setFormula("1 + 0.5");
workbook.getCell(0, "B2").setFormula(".3 * 1E-2");
```

## **Constantes de string**
Constante de string (ou literal) é um valor específico que é usado como está e não muda. Constantes de string podem ser: datas, textos, números etc.:

```java
workbook.getCell(0, "A2").setFormula("\"abc\"");
workbook.getCell(0, "B2").setFormula("\"2/3/2020 12:00\"");
```

## **Constantes de erro**
Às vezes não é possível calcular o resultado pela fórmula. Nesse caso, o código de erro é exibido na célula em vez de seu valor. Cada tipo de erro tem um código específico:

- #DIV/0! - a fórmula tenta dividir por zero.
- #GETTING_DATA - pode ser exibido em uma célula enquanto seu valor ainda está sendo calculado.
- #N/A - informação está ausente ou indisponível. Algumas causas podem ser: as células usadas na fórmula estão vazias, um caractere de espaço extra, erro de digitação etc.
- #NAME? - uma certa célula ou outro objeto de fórmula não pode ser encontrado pelo nome. 
- #NULL! - pode aparecer quando há um erro na fórmula, como:  (,) ou um caractere de espaço usado em vez de dois‑pontos (:).
- #NUM! - o número na fórmula pode ser inválido, muito longo ou muito pequeno etc.
- #REF! - referência de célula inválida.
- #VALUE! - tipo de valor inesperado. Por exemplo, valor de string atribuído a célula numérica.

```java
IChartDataCell cell = workbook.getCell(0, "A2");
cell.setFormula("2 / 0");
Object value = cell.getValue(); // o valor contém a string "#DIV/0!"
```

## **Operadores aritméticos**
Você pode usar todos os operadores aritméticos em fórmulas de planilha de gráfico:

|**Operador**|**Significado**|**Exemplo**|
| :- | :- | :- |
|+ (sinal de mais)|Adição ou sinal unário positivo|2 + 3|
|- (sinal de menos)|Subtração ou negação|2 - 3<br>-3|
|* (asterisco)|Multiplicação|2 * 3|
|/ (barra)|Divisão|2 / 3|
|% (porcentagem)|Porcentagem|30%|
|^ (circunflexo)|Exponenciação|2 ^ 3|

*Nota*: Para alterar a ordem de avaliação, envolva em parênteses a parte da fórmula que deve ser calculada primeiro.

## **Operadores de comparação**
Você pode comparar os valores das células com os operadores de comparação. Quando dois valores são comparados usando esses operadores, o resultado é um valor lógico *TRUE* ou FALSE:

|**Operador**|**Significado**|**Exemplo**|
| :- | :- | :- |
|= (igualdade)|Igual a|A2 = 3|
|<> (diferença)|Diferente de|A2 <> 3|
|> (maior que)|Maior que|A2 > 3|
|>= (maior ou igual)|Maior ou igual a|A2 >= 3|
|< (menor que)|Menor que|A2 < 3|
|<= (menor ou igual)|Menor ou igual a|A2 <= 3|

## **Referências de célula no estilo A1**
**Referências de célula no estilo A1** são usadas para planilhas, onde a coluna tem um identificador de letra (por exemplo, "*A*") e a linha tem um identificador numérico (por exemplo, "*1*"). As referências de célula no estilo A1 podem ser usadas da seguinte forma:

|**Referência de célula**|**Exemplo**|||
| :- | :- | :- | :- |
||Absoluta|Relativa|Mista|
|Célula|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Linha|$2:$2|2:2|-|
|Coluna|$A:$A|A:A|-|
|Intervalo|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


Aqui está um exemplo de como usar referência de célula no estilo A1 em uma fórmula:

```java
workbook.getCell(0, "A2").setFormula("C3 + SUM(F2:H5)");
```

## **Referências de célula no estilo R1C1**
**Referências de célula no estilo R1C1** são usadas para planilhas, onde tanto a linha quanto a coluna têm identificador numérico. As referências de célula no estilo R1C1 podem ser usadas da seguinte forma:

|**Referência de célula**|**Exemplo**|||
| :- | :- | :- | :- |
||Absoluta|Relativa|Mista|
|Célula|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Linha|R2|R[2]|-|
|Coluna|C3|C[3]|-|
|Intervalo|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


Aqui está um exemplo de como usar referência de célula no estilo A1 em uma fórmula:

```java
workbook.getCell(0, "A2").setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```

## **Funções predefinidas**
Existem funções predefinidas que podem ser usadas nas fórmulas para simplificar sua implementação. Essas funções encapsulam as operações mais utilizadas, como: 

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

**Os arquivos Excel externos são suportados como fonte de dados para um gráfico com fórmulas?**

Sim. O Aspose.Slides suporta pastas de trabalho externas como [fonte de dados de gráfico](https://reference.aspose.com/slides/pt/java/com.aspose.slides/chartdatasourcetype/), permitindo usar fórmulas de um XLSX fora da apresentação.

**As fórmulas de gráfico podem referenciar planilhas dentro da mesma pasta de trabalho pelo nome da planilha?**

Sim. As fórmulas seguem o modelo padrão de referência do Excel, portanto você pode referenciar outras planilhas dentro da mesma pasta de trabalho ou de uma pasta de trabalho externa. Para referências externas, inclua o caminho e o nome da pasta de trabalho usando a sintaxe do Excel.