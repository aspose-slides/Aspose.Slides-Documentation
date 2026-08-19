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
- pasta de trabalho de dados do gráfico
- cálculo de fórmula
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
- Python
- Aspose.Slides
description: "Aplique fórmulas no estilo Excel nas planilhas de gráfico do Aspose.Slides para Python via .NET, recalcule os valores e use os resultados em gráficos do PowerPoint."
---
## **Visão geral**

Os gráficos do PowerPoint normalmente armazenam seus dados de origem em uma planilha incorporada. No Aspose.Slides para Python via .NET, você pode acessar essa planilha através da pasta de trabalho de dados do gráfico, gravar valores de entrada, atribuir fórmulas às células, calcular as fórmulas suportadas e usar as células calculadas como dados do gráfico.

Este artigo explica o fluxo completo de fórmulas: criar um gráfico, preencher sua planilha, atribuir fórmulas no estilo A1 ou R1C1, recalculá‑las, ler os valores calculados, conectar essas células a uma série de gráfico e salvar a apresentação. Também descreve a sintaxe de fórmula suportada, o subconjunto de funções embutidas, valores em cache, fórmulas não suportadas e erros específicos de planilha.

## **Planilhas de Gráficos e Fórmulas**

Uma planilha de gráfico contém as categorias, nomes de séries e valores usados por um gráfico. No PowerPoint, você pode inspecionar a planilha abrindo o editor de dados do gráfico:

![Gráfico do PowerPoint com sua planilha incorporada aberta, mostrando dados de categoria e série](chart-worksheet-formulas_1.png)

No Aspose.Slides, a planilha é exposta através do [chart data workbook](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/ichartdataworkbook/). Use a propriedade [formula](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/ichartdatacell/formula/) para fórmulas no estilo A1 e a propriedade [r1c1_formula](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) para fórmulas no estilo R1C1. Após alterar células de entrada ou fórmulas, chame [calculate_formulas](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) para recalcular as fórmulas suportadas e atualizar os valores correspondentes das células.

Uma célula calculada ainda expõe seu resultado através da propriedade [value](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/ichartdatacell/value/). Isso é importante quando você precisa inspecionar o resultado de uma fórmula no código ou usar a célula como ponto de dados do gráfico.

## **Criar um Gráfico e Calcular Fórmulas da Planilha**

O exemplo a seguir demonstra um fluxo de trabalho completo. Ele cria um gráfico de colunas agrupadas, limpa os dados de exemplo, grava valores trimestrais de receita e despesa, calcula o lucro com fórmulas, lê os resultados, usa as células calculadas como valores do gráfico e salva a apresentação.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 350)
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    workbook.clear(worksheet_index)

    category1 = workbook.get_cell(worksheet_index, "A2", "Q1")
    category2 = workbook.get_cell(worksheet_index, "A3", "Q2")
    category3 = workbook.get_cell(worksheet_index, "A4", "Q3")

    workbook.get_cell(worksheet_index, "B1", "Revenue")
    workbook.get_cell(worksheet_index, "C1", "Expenses")
    workbook.get_cell(worksheet_index, "D1", "Profit")

    workbook.get_cell(worksheet_index, "B2").value = 120.0
    workbook.get_cell(worksheet_index, "C2").value = 80.0
    workbook.get_cell(worksheet_index, "B3").value = 150.0
    workbook.get_cell(worksheet_index, "C3").value = 95.0
    workbook.get_cell(worksheet_index, "B4").value = 135.0
    workbook.get_cell(worksheet_index, "C4").value = 110.0

    profit1 = workbook.get_cell(worksheet_index, "D2")
    profit2 = workbook.get_cell(worksheet_index, "D3")
    profit3 = workbook.get_cell(worksheet_index, "D4")

    profit1.formula = "B2-C2"
    profit2.formula = "B3-C3"
    profit3.formula = "B4-C4"

    workbook.calculate_formulas()

    q1_profit = profit1.value  # 40
    q2_profit = profit2.value  # 55
    q3_profit = profit3.value  # 25

    print(f"Q1 profit: {q1_profit}")
    print(f"Q2 profit: {q2_profit}")
    print(f"Q3 profit: {q3_profit}")

    chart.chart_data.categories.add(category1)
    chart.chart_data.categories.add(category2)
    chart.chart_data.categories.add(category3)

    profit_series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, "D1"), chart.type)
    profit_series.data_points.add_data_point_for_bar_series(profit1)
    profit_series.data_points.add_data_point_for_bar_series(profit2)
    profit_series.data_points.add_data_point_for_bar_series(profit3)
    profit_series.labels.default_data_label_format.show_value = True

    presentation.save("chart-formulas.pptx", slides.export.SaveFormat.PPTX)
```

Os pontos de dados do gráfico referenciam `D2:D4`, portanto o gráfico usa os valores de lucro calculados. Não há chamada separada de atualização de gráfico neste fluxo: recalcule a pasta de trabalho primeiro, depois use ou salve os dados do gráfico que apontam para as células calculadas.

## **Usar Fórmulas no Estilo A1**

A notação A1 identifica colunas com letras e linhas com números. Atribua expressões no estilo A1 através de [IChartDataCell.formula](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/ichartdatacell/formula/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "C3").value = 10
    workbook.get_cell(0, "F2").value = 2
    workbook.get_cell(0, "G2").value = 3
    workbook.get_cell(0, "H2").value = 4

    cell = workbook.get_cell(0, "A2")
    cell.formula = "C3+SUM(F2:H2)"

    workbook.calculate_formulas()

    value = cell.value  # 19
```

Formas de referência A1 comuns são:

| Referência | Relativa | Absoluta | Mista |
|---|---|---|---|
| Cell | `A2` | `$A$2` | `A$2`, `$A2` |
| Row | `2:2` | `$2:$2` | — |
| Column | `A:A` | `$A:$A` | — |
| Range | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Referências relativas podem mudar quando uma fórmula é movida ou copiada por uma aplicação de planilha. Referências absolutas mantêm ambas as coordenadas fixas, enquanto referências mistas fixam apenas uma linha ou uma coluna.

## **Usar Fórmulas no Estilo R1C1**

A notação R1C1 identifica linhas e colunas numericamente. Referências relativas usam deslocamentos entre colchetes. Atribua essa sintaxe através de [IChartDataCell.r1c1_formula](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "B2").value = 12
    workbook.get_cell(0, "C2").value = 5

    cell = workbook.get_cell(0, "D2")
    cell.r1c1_formula = "RC[-2]-RC[-1]"

    workbook.calculate_formulas()

    value = cell.value  # 7
```

Formas de referência R1C1 comuns são:

| Referência | Relativa | Absoluta | Mista |
|---|---|---|---|
| Cell | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Row | `R[2]` | `R2` | — |
| Column | `C[3]` | `C3` | — |
| Range | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Por exemplo, na célula `D2`, `RC[-2]` significa a célula na mesma linha duas colunas à esquerda (`B2`).

## **Constantes e Operadores de Fórmula**

O avaliador de fórmulas embutido suporta valores lógicos, literais numéricos, strings, valores de erro de planilha, operadores aritméticos e operadores de comparação.

### **Constantes e Literais**

| Tipo | Exemplos | Observações |
|---|---|---|
| Logical | `TRUE`, `FALSE` | Pode ser usado diretamente em expressões lógicas como `A2=TRUE`. |
| Numeric | `1`, `0.5`, `.3`, `1E-2` | Notação comum e científica são suportadas. |
| String | `"abc"`, `"2/3/2020 12:00"` | Literais de texto são delimitados por aspas duplas dentro da fórmula. |
| Error result | `#DIV/0!`, `#N/A`, `#REF!` | Uma fórmula válida pode avaliar para um valor de erro de planilha em vez de um resultado normal. |

Este exemplo usa vários tipos de constante:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "A2").value = False
    workbook.get_cell(0, "B2").formula = "A2=TRUE"
    workbook.get_cell(0, "C2").formula = "1+0.5"
    workbook.get_cell(0, "D2").formula = ".3*1E-2"
    workbook.get_cell(0, "E2").formula = "\"abc\""
    workbook.get_cell(0, "F2").formula = "2/0"

    workbook.calculate_formulas()

    logical_value = workbook.get_cell(0, "B2").value  # Falso
    numeric_value = workbook.get_cell(0, "C2").value  # 1.5
    scientific_value = workbook.get_cell(0, "D2").value  # 0.003
    string_value = workbook.get_cell(0, "E2").value  # abc
    error_value = workbook.get_cell(0, "F2").value  # #DIV/0!
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

O Aspose.Slides inclui um avaliador de fórmulas embutido para planilhas de gráficos, mas não é um motor de cálculo completo do Excel. O conjunto de funções documentado está limitado às funções abaixo. Não presuma que uma função arbitrária do Excel possa ser recalculada por [calculate_formulas](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/).

| Função | Propósito ou forma suportada | Exemplo |
|---|---|---|
| `ABS` | Valor absoluto | `ABS(A2)` |
| `AVERAGE` | Média aritmética | `AVERAGE(B2:B5)` |
| `CEILING` | Arredonda um número para cima até um múltiplo | `CEILING(A2,5)` |
| `CHOOSE` | Seleciona um valor por índice | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Concatena valores de texto | `CONCAT(A2,B2)` |
| `CONCATENATE` | Concatena valores de texto | `CONCATENATE(A2," ",B2)` |
| `DATE` | Cria um valor de data usando o sistema de datas de 1900 | `DATE(2026,8,19)` |
| `DAYS` | Retorna o número de dias entre datas | `DAYS(B2,A2)` |
| `FIND` | Encontra um texto dentro de outro | `FIND("-",A2)` |
| `FINDB` | Busca de texto orientada a bytes | `FINDB("a",A2)` |
| `IF` | Resultado condicional | `IF(A2>0,A2,0)` |
| `INDEX` | Forma de referência | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Forma vetorial | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Forma vetorial | `MATCH(A2,B2:B5,0)` |
| `MAX` | Valor máximo | `MAX(B2:B5)` |
| `SUM` | Soma valores | `SUM(B2:B5)` |
| `VLOOKUP` | Procura vertical | `VLOOKUP(A2,B2:D10,3,FALSE)` |

As restrições mostradas na tabela são significativas: `INDEX` é documentado na forma de referência, enquanto `LOOKUP` e `MATCH` são documentados nas suas formas vetoriais. `DATE` usa o sistema de datas de 1900. Recursos e funções não listados aqui devem ser considerados não suportados pelo avaliador de fórmulas do Aspose.Slides, a menos que sejam documentados separadamente.

## **Recalculo e Valores em Cache**

Arquivos de planilha costumam armazenar tanto a fórmula quanto seu último valor calculado. O Aspose.Slides pode, portanto, ler um valor em cache de [IChartDataCell.value](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/ichartdatacell/value/) quando uma apresentação é carregada e os dados do gráfico relevantes não foram alterados.

Após alterar células de entrada ou fórmulas, não confie em um resultado em cache antigo. Chame [ChartDataWorkbook.calculate_formulas](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) antes de ler valores calculados ou salvar dados do gráfico que dependam deles.

Para fórmulas fora do subconjunto suportado, o Aspose.Slides pode ser incapaz de analisar a fórmula ou estabelecer suas dependências. Se a pasta de trabalho foi modificada, o valor em cache anterior não pode mais ser considerado confiável. Nesse caso, ler o valor de uma célula com dados não suportados pode gerar [CellUnsupportedDataException](https://reference.aspose.com/slides/pt/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Se seu gráfico depende de funções do Excel que o Aspose.Slides não avalia, calcule essas fórmulas com um motor de planilha que as suporte e grave os valores resultantes de volta na pasta de trabalho do gráfico. Não substitua fórmulas não suportadas por valores adivinhados.

## **Tratar Erros de Fórmula**

Existem dois tipos diferentes de problemas a distinguir.

Uma fórmula pode ser válida, mas produzir um resultado de erro de planilha como `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` ou `#VALUE!`. Nesse caso, o token de erro é um resultado de célula e pode ser retornado através de `value`.

Uma fórmula também pode falhar no nível de análise, referência, dependência ou dados suportados. O Aspose.Slides fornece exceções específicas de planilha para esses casos: [CellInvalidFormulaException](https://reference.aspose.com/slides/pt/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/pt/python-net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/pt/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/), e [CellUnsupportedDataException](https://reference.aspose.com/slides/pt/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Quando as fórmulas vêm de modelos ou da entrada do usuário, trate essas exceções ao redor da recalculação e do acesso ao valor:

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.slides.spreadsheet as spreadsheet

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook
    cell = workbook.get_cell(0, "A2")
    cell.formula = "SUM(B2:B5)"

    try:
        workbook.calculate_formulas()
        print(cell.value)
    except spreadsheet.CellInvalidFormulaException as ex:
        print(f"Invalid formula: {ex}")
    except spreadsheet.CellInvalidReferenceException as ex:
        print(f"Invalid cell reference: {ex}")
    except spreadsheet.CellCircularReferenceException as ex:
        print(f"Circular reference: {ex}")
    except spreadsheet.CellUnsupportedDataException as ex:
        print(f"Unsupported spreadsheet data: {ex}")
```

## **Limitações Práticas**

O suporte a fórmulas em planilhas de gráficos destina‑se a um subconjunto definido de cálculos de planilha, não à compatibilidade total com o Excel. Tenha essas restrições em mente ao projetar um fluxo de trabalho de relatórios:

- Use apenas as constantes, operadores, referências e funções documentadas quando precisar que o Aspose.Slides recalcule as fórmulas.
- Recalcule após alterar células das quais os resultados das fórmulas dependem.
- Considere os valores em cache de apresentações carregadas como instantâneos, não como substitutos da recalculação após edições.
- Teste as fórmulas de modelos existentes antes de confiar em seus valores calculados, especialmente quando utilizam funções fora da lista documentada.
- Para fórmulas que exigem um motor completo de cálculo de planilha, calcule‑as externamente e depois atualize a pasta de trabalho do gráfico com os valores resultantes.

## **Perguntas Frequentes**

**Qual é a diferença entre `formula` e `r1c1_formula`?**

[formula](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/ichartdatacell/formula/) armazena uma expressão no estilo A1, como `B2-C2`. [r1c1_formula](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) armazena uma expressão no estilo R1C1, como `RC[-2]-RC[-1]`. Use a notação que melhor corresponda à forma como você gera ou copia as fórmulas.

**Preciso ler a própria célula ou seu valor após o cálculo?**

[ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) devolve um `IChartDataCell`. Para obter o resultado calculado, leia a propriedade [value](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/ichartdatacell/value/) dessa célula após a recalculação.

**Quando devo chamar `calculate_formulas`?**

Chame [calculate_formulas](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) após alterar valores de entrada ou fórmulas e antes de depender dos resultados calculados. Isso atualiza os valores das fórmulas que o avaliador interno suporta.

**O Aspose.Slides suporta todas as funções do Excel?**

Não. O avaliador interno suporta um subconjunto documentado de funções. Funções fora desse subconjunto não devem ser presumidas como recalculáveis corretamente. Se for necessária compatibilidade total com fórmulas do Excel, execute o cálculo com um motor de planilha adequado e grave os valores finais na pasta de trabalho do gráfico.

**O que acontece se uma apresentação carregada contiver uma fórmula não suportada?**

Se os dados do gráfico não foram alterados, a pasta de trabalho pode ainda conter um valor em cache calculado anteriormente. Após a modificação dos dados relacionados, esse valor em cache pode não ser mais válido. Acessar uma célula cuja fórmula não pode ser tratada pode gerar [CellUnsupportedDataException](https://reference.aspose.com/slides/pt/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

**Os valores de erro de fórmula são iguais às exceções do Python?**

Não. Um resultado como `#DIV/0!` é um valor de planilha produzido por um cálculo válido. Exceções como [CellInvalidFormulaException](https://reference.aspose.com/slides/pt/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/) ou [CellCircularReferenceException](https://reference.aspose.com/slides/pt/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/) indicam que a fórmula não pôde ser processada normalmente.

**Um gráfico é atualizado automaticamente quando uma célula de fórmula muda?**

Uma série de gráfico pode referenciar células da pasta de trabalho. Recalcule a pasta de trabalho primeiro, depois salve ou renderize a apresentação. Se os pontos de dados do gráfico referenciam as células calculadas, o gráfico usa esses valores atualizados; nenhum método de atualização de gráfico separado é necessário nesse fluxo.

**Os gráficos podem usar uma pasta de trabalho Excel externa?**

Sim, os dados do gráfico podem ser configurados para usar uma pasta de trabalho externa através da API de dados do gráfico. Contudo, o fluxo de cálculo de fórmula descrito neste artigo refere‑se à pasta de trabalho de dados do gráfico e ao subconjunto de fórmulas avaliado pelo Aspose.Slides. Não presuma que [calculate_formulas](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) forneça recalculação completa de fórmulas arbitrárias em um arquivo XLSX externo.

**Posso usar fórmulas que referenciam outra planilha ou pasta de trabalho?**

Referências ao estilo Excel podem existir em pastas de trabalho de gráficos, mas a avaliação de fórmulas é limitada ao analisador e ao conjunto de funções suportados. Se uma referência cruzada de planilha ou externa for essencial, valide essa fórmula exata com a versão do Aspose.Slides que você está usando. Para fluxos que requerem ampla compatibilidade de referências do Excel, calcule a pasta de trabalho externamente e grave os valores resolvidos de volta aos dados do gráfico.

**As strings de fórmula devem começar com `=`?**

Os exemplos da API Aspose.Slides atribuem expressões como `B2-C2` ou `SUM(B2:B5)` sem o `=` inicial. Usar essa forma mantém as fórmulas geradas consistentes com os exemplos documentados da API.