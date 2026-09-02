---
title: Aplicar fórmulas de planilha de gráfico em apresentações no Android
linktitle: Fórmulas da planilha
type: docs
weight: 70
url: /pt/androidjava/chart-worksheet-formulas/
keywords:
- planilha de gráfico
- planilha de gráfico
- fórmula de gráfico
- fórmula de planilha
- fórmula de planilha
- pasta de trabalho de dados de gráfico
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
- Android
- Java
- Aspose.Slides
description: "Aplicar fórmulas no estilo Excel em planilhas de gráfico do Aspose.Slides para Android via Java, recalcular valores e usar os resultados em gráficos do PowerPoint."
---
## **Visão geral**

Os gráficos do PowerPoint geralmente armazenam seus dados de origem em uma planilha incorporada. No Aspose.Slides for Android via Java, você pode acessar essa planilha por meio da pasta de trabalho de dados do gráfico, gravar valores de entrada, atribuir fórmulas a células, calcular fórmulas suportadas e usar as células calculadas como dados do gráfico.

Este artigo explica o fluxo completo de fórmulas: criar um gráfico, preencher sua planilha, atribuir fórmulas no estilo A1 ou R1C1, recalculá‑las, ler os valores calculados, conectar essas células a uma série de gráfico e salvar a apresentação. Também descreve a sintaxe de fórmulas suportada, o subconjunto de funções incorporadas, valores em cache, fórmulas não suportadas e erros específicos de planilha.

## **Planilhas de gráfico e fórmulas**

Uma planilha de gráfico contém as categorias, nomes de séries e valores usados por um gráfico. No PowerPoint, você pode inspecionar a planilha abrindo o editor de dados do gráfico:

![Gráfico do PowerPoint com sua planilha incorporada aberta, mostrando dados de categoria e série](chart-worksheet-formulas_1.png)

No Aspose.Slides, a planilha é exposta por meio da interface [IChartDataWorkbook](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ichartdataworkbook/). Use [IChartDataCell.setFormula](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) para fórmulas no estilo A1 e [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) para fórmulas no estilo R1C1. Depois de alterar células de entrada ou fórmulas, chame [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) para recalcular as fórmulas suportadas e atualizar os valores correspondentes das células.

Uma célula calculada ainda expõe seu resultado por meio de [IChartDataCell.getValue](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ichartdatacell/#getValue--). Isso é importante quando você precisa inspecionar o resultado de uma fórmula no código ou usar a célula como ponto de dados do gráfico.

## **Criar um gráfico e calcular fórmulas da planilha**

O exemplo a seguir demonstra um fluxo de trabalho de ponta a ponta. Ele cria um gráfico de colunas agrupadas, limpa os dados de exemplo, grava valores trimestrais de receita e despesa, calcula lucro com fórmulas, lê os resultados, usa as células calculadas como valores do gráfico e salva a apresentação.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 350);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    workbook.clear(worksheetIndex);

    IChartDataCell category1 = workbook.getCell(worksheetIndex, "A2", "Q1");
    IChartDataCell category2 = workbook.getCell(worksheetIndex, "A3", "Q2");
    IChartDataCell category3 = workbook.getCell(worksheetIndex, "A4", "Q3");

    workbook.getCell(worksheetIndex, "B1", "Revenue");
    workbook.getCell(worksheetIndex, "C1", "Expenses");
    workbook.getCell(worksheetIndex, "D1", "Profit");

    workbook.getCell(worksheetIndex, "B2").setValue(120.0);
    workbook.getCell(worksheetIndex, "C2").setValue(80.0);
    workbook.getCell(worksheetIndex, "B3").setValue(150.0);
    workbook.getCell(worksheetIndex, "C3").setValue(95.0);
    workbook.getCell(worksheetIndex, "B4").setValue(135.0);
    workbook.getCell(worksheetIndex, "C4").setValue(110.0);

    IChartDataCell profit1 = workbook.getCell(worksheetIndex, "D2");
    IChartDataCell profit2 = workbook.getCell(worksheetIndex, "D3");
    IChartDataCell profit3 = workbook.getCell(worksheetIndex, "D4");

    profit1.setFormula("B2-C2");
    profit2.setFormula("B3-C3");
    profit3.setFormula("B4-C4");

    workbook.calculateFormulas();

    double q1Profit = ((Number) profit1.getValue()).doubleValue(); // 40
    double q2Profit = ((Number) profit2.getValue()).doubleValue(); // 55
    double q3Profit = ((Number) profit3.getValue()).doubleValue(); // 25

    System.out.println("Q1 profit: " + q1Profit);
    System.out.println("Q2 profit: " + q2Profit);
    System.out.println("Q3 profit: " + q3Profit);

    chart.getChartData().getCategories().add(category1);
    chart.getChartData().getCategories().add(category2);
    chart.getChartData().getCategories().add(category3);

    IChartSeries profitSeries = chart.getChartData().getSeries().add(workbook.getCell(worksheetIndex, "D1"), chart.getType());
    profitSeries.getDataPoints().addDataPointForBarSeries(profit1);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit2);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit3);
    profitSeries.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("chart-formulas.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Os pontos de dados do gráfico referenciam `D2:D4`, portanto o gráfico usa os valores de lucro calculados. Não há chamada separada de atualização do gráfico neste fluxo: recalcule a pasta de trabalho primeiro, depois use ou salve os dados do gráfico que apontam para as células calculadas.

## **Usar fórmulas no estilo A1**

A notação A1 identifica colunas com letras e linhas com números. Atribua expressões no estilo A1 através de [IChartDataCell.setFormula](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "C3").setValue(10);
    workbook.getCell(0, "F2").setValue(2);
    workbook.getCell(0, "G2").setValue(3);
    workbook.getCell(0, "H2").setValue(4);

    IChartDataCell cell = workbook.getCell(0, "A2");
    cell.setFormula("C3+SUM(F2:H2)");

    workbook.calculateFormulas();

    Object value = cell.getValue(); // 19
} finally {
    presentation.dispose();
}
```

Formas de referência A1 comuns são:

| Referência | Relativa | Absoluta | Mista |
|---|---|---|---|
| Célula | `A2` | `$A$2` | `A$2`, `$A2` |
| Linha | `2:2` | `$2:$2` | — |
| Coluna | `A:A` | `$A:$A` | — |
| Intervalo | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Referências relativas podem mudar quando uma fórmula é movida ou copiada por uma aplicação de planilha. Referências absolutas mantêm ambas as coordenadas fixas, enquanto referências mistas fixam apenas uma linha ou uma coluna.

## **Usar fórmulas no estilo R1C1**

A notação R1C1 identifica linhas e colunas numericamente. Referências relativas usam deslocamentos entre colchetes. Atribua essa sintaxe através de [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "B2").setValue(12);
    workbook.getCell(0, "C2").setValue(5);

    IChartDataCell cell = workbook.getCell(0, "D2");
    cell.setR1C1Formula("RC[-2]-RC[-1]");

    workbook.calculateFormulas();

    Object value = cell.getValue(); // 7
} finally {
    presentation.dispose();
}
```

Formas de referência R1C1 comuns são:

| Referência | Relativa | Absoluta | Mista |
|---|---|---|---|
| Célula | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Linha | `R[2]` | `R2` | — |
| Coluna | `C[3]` | `C3` | — |
| Intervalo | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Por exemplo, na célula `D2`, `RC[-2]` significa a célula na mesma linha duas colunas à esquerda (`B2`).

## **Constantes e operadores de fórmula**

O avaliador de fórmulas incorporado oferece valores lógicos, literais numéricos, cadeias de texto, valores de erro de planilha, operadores aritméticos e operadores de comparação.

### **Constantes e literais**

| Tipo | Exemplos | Observações |
|---|---|---|
| Lógico | `TRUE`, `FALSE` | Pode ser usado diretamente em expressões lógicas, como `A2=TRUE`. |
| Numérico | `1`, `0.5`, `.3`, `1E-2` | Notação comum e notação científica são suportadas. |
| Texto | `"abc"`, `"2/3/2020 12:00"` | Literais de texto são delimitados por aspas duplas dentro da fórmula. |
| Resultado de erro | `#DIV/0!`, `#N/A`, `#REF!` | Uma fórmula válida pode avaliar para um valor de erro de planilha em vez de um resultado normal. |

Este exemplo usa vários tipos de constantes:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "A2").setValue(false);
    workbook.getCell(0, "B2").setFormula("A2=TRUE");
    workbook.getCell(0, "C2").setFormula("1+0.5");
    workbook.getCell(0, "D2").setFormula(".3*1E-2");
    workbook.getCell(0, "E2").setFormula("\"abc\"");
    workbook.getCell(0, "F2").setFormula("2/0");

    workbook.calculateFormulas();

    Object logicalValue = workbook.getCell(0, "B2").getValue(); // falso
    Object numericValue = workbook.getCell(0, "C2").getValue(); // 1.5
    Object scientificValue = workbook.getCell(0, "D2").getValue(); // 0.003
    Object stringValue = workbook.getCell(0, "E2").getValue(); // abc
    Object errorValue = workbook.getCell(0, "F2").getValue(); // #DIV/0!
} finally {
    presentation.dispose();
}
```

### **Operadores aritméticos**

| Operador | Significado | Exemplo |
|---|---|---|
| `+` | Adição ou sinal positivo | `2+3` |
| `-` | Subtração ou negação | `2-3`, `-3` |
| `*` | Multiplicação | `2*3` |
| `/` | Divisão | `2/3` |
| `%` | Percentual | `30%` |
| `^` | Exponenciação | `2^3` |

Use parênteses para tornar a ordem de avaliação explícita, por exemplo `(A2+B2)*C2`.

### **Operadores de comparação**

Expressões de comparação retornam valores lógicos.

| Operador | Significado | Exemplo |
|---|---|---|
| `=` | Igual a | `A2=3` |
| `<>` | Diferente de | `A2<>3` |
| `>` | Maior que | `A2>3` |
| `>=` | Maior ou igual a | `A2>=3` |
| `<` | Menor que | `A2<3` |
| `<=` | Menor ou igual a | `A2<=3` |

## **Funções predefinidas suportadas**

O Aspose.Slides inclui um avaliador de fórmulas incorporado para planilhas de gráfico, mas não é um mecanismo de cálculo completo do Excel. O conjunto de funções documentado está limitado às funções abaixo. Não presuma que uma função arbitrária do Excel possa ser recalculada por [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--).

| Função | Finalidade ou forma suportada | Exemplo |
|---|---|---|
| `ABS` | Valor absoluto | `ABS(A2)` |
| `AVERAGE` | Média aritmética | `AVERAGE(B2:B5)` |
| `CEILING` | Arredondar um número para cima até um múltiplo | `CEILING(A2,5)` |
| `CHOOSE` | Selecionar um valor por índice | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Concatenar valores de texto | `CONCAT(A2,B2)` |
| `CONCATENATE` | Concatenar valores de texto | `CONCATENATE(A2," ",B2)` |
| `DATE` | Criar um valor de data usando o sistema de datas 1900 | `DATE(2026,8,19)` |
| `DAYS` | Retornar o número de dias entre datas | `DAYS(B2,A2)` |
| `FIND` | Encontrar um texto dentro de outro | `FIND("-",A2)` |
| `FINDB` | Busca de texto orientada a bytes | `FINDB("a",A2)` |
| `IF` | Resultado condicional | `IF(A2>0,A2,0)` |
| `INDEX` | Forma de referência | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Forma vetorial | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Forma vetorial | `MATCH(A2,B2:B5,0)` |
| `MAX` | Valor máximo | `MAX(B2:B5)` |
| `SUM` | Somar valores | `SUM(B2:B5)` |
| `VLOOKUP` | Pesquisa vertical | `VLOOKUP(A2,B2:D10,3,FALSE)` |

As restrições mostradas na tabela são significativas: `INDEX` é documentado em forma de referência, enquanto `LOOKUP` e `MATCH` são documentados em suas formas vetoriais. `DATE` usa o sistema de datas 1900. Recursos e funções não listados aqui devem ser tratados como não suportados pelo avaliador de fórmulas do Aspose.Slides, salvo documentação separada.

## **Calcular fórmulas com cultura preferencial**

Algumas funções da pasta de trabalho interpretam texto de acordo com regras específicas de cultura. Isso é particularmente importante para funções destinadas a idiomas que utilizam conjuntos de caracteres de dois bytes (DBCS). Para calcular essas fórmulas corretamente, crie um [LoadOptions](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/loadoptions/), defina a cultura preferencial com [SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/spreadsheetoptions/#setPreferredCulture-java.util.Locale-), atribua as opções de planilha através de [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-), e então carregue a apresentação.

O exemplo a seguir seleciona a cultura japonesa, abre uma apresentação com as opções de carregamento configuradas e chama [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) para cada pasta de trabalho de gráfico:

```java
import com.aspose.slides.*;
import java.util.Locale;

Locale japaneseCulture = Locale.forLanguageTag("ja-JP");

ISpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setPreferredCulture(japaneseCulture);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IChart) {
                IChart chart = (IChart) shape;
                chart.getChartData().getChartDataWorkbook().calculateFormulas();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

A cultura preferencial faz parte da configuração de carregamento da apresentação, portanto especifique‑a antes de criar a instância de [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/). Use a cultura esperada pelas fórmulas da pasta de trabalho; por exemplo, use `ja-JP` para fórmulas que devem seguir as regras de cálculo DBCS japonesas.

## **Recalcular e valores em cache**

Arquivos de planilha costumam armazenar tanto a fórmula quanto seu último valor calculado. O Aspose.Slides pode ler um valor em cache de [IChartDataCell.getValue](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ichartdatacell/#getValue--) quando a apresentação é carregada e os dados de gráfico relevantes não foram alterados.

Depois de mudar células de entrada ou fórmulas, não confie em um resultado em cache antigo. Chame [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) antes de ler valores calculados ou salvar dados de gráfico que dependam deles.

Para fórmulas fora do subconjunto suportado, o Aspose.Slides pode ser incapaz de analisar a fórmula ou estabelecer suas dependências. Se a pasta de trabalho foi modificada, o valor em cache anterior não pode mais ser considerado confiável. Nesse caso, ler o valor de uma célula com dados não suportados pode gerar [CellUnsupportedDataException](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/cellunsupporteddataexception/).

Se o seu gráfico depende de funções do Excel que o Aspose.Slides não avalia, calcule essas fórmulas com um motor de planilha que as suporte e escreva os valores resultantes de volta na pasta de trabalho do gráfico. Não substitua fórmulas não suportadas por valores estimados.

## **Tratar erros de fórmula**

Existem dois tipos diferentes de problemas a serem distinguidos.

Uma fórmula pode ser válida mas produzir um resultado de erro de planilha, como `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` ou `#VALUE!`. Nesse caso, o token de erro é um resultado de célula e pode ser retornado por [IChartDataCell.getValue](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ichartdatacell/#getValue--).

Uma fórmula também pode falhar na análise, referência, dependência ou nível de dados suportados. O Aspose.Slides fornece exceções específicas de planilha para esses casos: [CellInvalidFormulaException](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/cellcircularreferenceexception/) e [CellUnsupportedDataException](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/cellunsupporteddataexception/).

Quando as fórmulas provêm de modelos ou entrada do usuário, trate essas exceções ao redor da recalculação e do acesso ao valor:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell cell = workbook.getCell(0, "A2");
    cell.setFormula("SUM(B2:B5)");

    try {
        workbook.calculateFormulas();
        System.out.println(cell.getValue());
    } catch (CellInvalidFormulaException ex) {
        System.err.println("Invalid formula: " + ex.getMessage());
    } catch (CellInvalidReferenceException ex) {
        System.err.println("Invalid cell reference: " + ex.getMessage());
    } catch (CellCircularReferenceException ex) {
        System.err.println("Circular reference: " + ex.getMessage());
    } catch (CellUnsupportedDataException ex) {
        System.err.println("Unsupported spreadsheet data: " + ex.getMessage());
    }
} finally {
    presentation.dispose();
}
```

## **Limitações práticas**

O suporte a fórmulas em planilhas de gráficos destina‑se a um subconjunto definido de cálculos de planilha, não à compatibilidade total com o Excel. Tenha essas restrições em mente ao projetar um fluxo de trabalho de relatórios:

- Use apenas as constantes, operadores, referências e funções documentadas quando precisar que o Aspose.Slides recalcule fórmulas.
- Recalcule após alterar células das quais os resultados das fórmulas dependem.
- Considere os valores em cache de apresentações carregadas como instantâneos, não como substitutos da recalculação após edições.
- teste fórmulas de modelos existentes antes de confiar em seus valores calculados, sobretudo quando utilizarem funções fora da lista documentada.
- Para fórmulas que requerem um motor completo de cálculo de planilha, calcule‑as externamente e então atualize a pasta de trabalho do gráfico com os valores resultantes.

## **FAQ**

**Qual a diferença entre [IChartDataCell.setFormula](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) e [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-)?**

[IChartDataCell.setFormula](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) armazena uma expressão no estilo A1, como `B2-C2`. [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) armazena uma expressão no estilo R1C1, como `RC[-2]-RC[-1]`. Use a notação que melhor corresponda à forma como você gera ou copia as fórmulas.

**Preciso ler a própria célula ou apenas seu valor após a cálculo?**

[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-java.lang.String-) devolve um [IChartDataCell](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ichartdatacell/). Para obter o resultado calculado, chame o método [IChartDataCell.getValue](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ichartdatacell/#getValue--) dessa célula após a recalculação.

**Quando devo chamar [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--)?**

Chame [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) depois de mudar valores de entrada ou fórmulas e antes de depender dos resultados calculados. Isso atualiza os valores das fórmulas que o avaliador incorporado suporta.

**O Aspose.Slides suporta todas as funções do Excel?**

Não. O avaliador incorporado suporta um subconjunto documentado de funções. Funções fora desse subconjunto não devem ser presumidas como recalculáveis corretamente. Se for necessária compatibilidade total com fórmulas do Excel, execute o cálculo com um motor de planilha adequado e grave os valores finais na pasta de trabalho do gráfico.

**O que acontece se uma apresentação carregada contiver uma fórmula não suportada?**

Se os dados do gráfico não foram alterados, a pasta de trabalho ainda pode conter um valor em cache calculado anteriormente. Após a modificação dos dados relacionados, esse valor em cache pode deixar de ser válido. Acessar uma célula cuja fórmula não pode ser tratada pode gerar [CellUnsupportedDataException](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/cellunsupporteddataexception/).

**Valores de erro de fórmula são iguais a exceções Java?**

Não. Um resultado como `#DIV/0!` é um valor de planilha produzido por um cálculo válido. Exceções como [CellInvalidFormulaException](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/cellinvalidformulaexception/) ou [CellCircularReferenceException](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/cellcircularreferenceexception/) indicam que a fórmula não pode ser processada normalmente.

**Um gráfico é atualizado automaticamente quando uma célula de fórmula muda?**

Uma série de gráfico pode referenciar células da pasta de trabalho. Recalcule a pasta de trabalho primeiro, depois salve ou renderize a apresentação. Se os pontos de dados do gráfico referenciam as células calculadas, o gráfico usará esses valores atualizados; não há necessidade de um método de atualização de gráfico separado.

**Os gráficos podem usar uma pasta de trabalho Excel externa?**

Sim, os dados do gráfico podem ser configurados para usar uma pasta de trabalho externa através da API de dados do gráfico. No entanto, o fluxo de cálculo de fórmulas descrito neste artigo refere‑se à pasta de trabalho de dados do gráfico e ao subconjunto de fórmulas avaliado pelo Aspose.Slides. Não presuma que [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) forneça recalculação completa de fórmulas arbitrárias em um arquivo XLSX externo.

**Posso usar fórmulas que referenciam outra planilha ou pasta de trabalho?**

Referências ao estilo Excel podem existir em pastas de trabalho de gráficos, mas a avaliação de fórmulas é limitada ao analisador e ao conjunto de funções suportados. Se uma referência cruzada ou externa for essencial, valide a fórmula exata com a versão do Aspose.Slides que você está usando. Para fluxos que exigem ampla compatibilidade de referências do Excel, calcule a pasta de trabalho externamente e grave os valores resolvidos de volta aos dados do gráfico.

**As strings de fórmula devem começar com `=`?**

Os exemplos da API Aspose.Slides atribuem expressões como `B2-C2` ou `SUM(B2:B5)` sem o `=` inicial. Usar essa forma mantém as fórmulas geradas consistentes com os exemplos documentados da API.