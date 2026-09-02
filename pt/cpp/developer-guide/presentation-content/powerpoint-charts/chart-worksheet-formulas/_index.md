---
title: Aplicar fórmulas de planilha de gráfico em apresentações usando C++
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
- pasta de trabalho de dados de gráfico
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
- C++
- Aspose.Slides
description: "Aplicar fórmulas no estilo Excel em planilhas de gráficos do Aspose.Slides para C++, recalcular valores e usar os resultados em gráficos do PowerPoint."
---
## **Visão geral**

Os gráficos do PowerPoint geralmente armazenam seus dados de origem em uma planilha incorporada. No Aspose.Slides for C++, você pode acessar essa planilha por meio da pasta de trabalho de dados do gráfico, gravar valores de entrada, atribuir fórmulas a células, calcular fórmulas suportadas e usar as células calculadas como dados do gráfico.

Este artigo explica o fluxo completo de fórmula: criar um gráfico, preencher sua planilha, atribuir fórmulas no estilo A1 ou R1C1, recalculá‑las, ler os valores calculados, conectar essas células a uma série do gráfico e salvar a apresentação. Ele também descreve a sintaxe de fórmula suportada, o subconjunto de funções integradas, valores armazenados em cache, fórmulas não suportadas e erros específicos de planilhas.

## **Planilhas de gráfico e fórmulas**

Uma planilha de gráfico contém as categorias, nomes de séries e valores usados por um gráfico. No PowerPoint, você pode inspecionar a planilha abrindo o editor de dados do gráfico:

![Gráfico do PowerPoint com sua planilha incorporada aberta, mostrando dados de categoria e série](chart-worksheet-formulas_1.png)

No Aspose.Slides, a planilha é exposta através da interface [IChartDataWorkbook](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/ichartdataworkbook/). Use [IChartDataCell::set_Formula](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/ichartdatacell/set_formula/) para fórmulas no estilo A1 e [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) para fórmulas no estilo R1C1. Após alterar células de entrada ou fórmulas, chame [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) para recalcular as fórmulas suportadas e atualizar os valores correspondentes das células.

Uma célula calculada ainda expõe seu resultado através de [IChartDataCell::get_Value](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/ichartdatacell/get_value/). Isso é importante quando você precisa inspecionar o resultado de uma fórmula no código ou usar a célula como ponto de dados do gráfico.

## **Criar um gráfico e calcular fórmulas da planilha**

O exemplo a seguir demonstra um fluxo de trabalho completo. Ele cria um gráfico de colunas agrupadas, limpa os dados de exemplo, grava valores trimestrais de receita e despesa, calcula lucro com fórmulas, lê os resultados, usa as células calculadas como valores do gráfico e salva a apresentação.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 350.0f);
auto chartData = chart->get_ChartData();
auto workbook = chartData->get_ChartDataWorkbook();
const int32_t worksheetIndex = 0;

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();
workbook->Clear(worksheetIndex);

auto category1 = workbook->GetCell(worksheetIndex, u"A2", ObjectExt::Box<String>(u"Q1"));
auto category2 = workbook->GetCell(worksheetIndex, u"A3", ObjectExt::Box<String>(u"Q2"));
auto category3 = workbook->GetCell(worksheetIndex, u"A4", ObjectExt::Box<String>(u"Q3"));

workbook->GetCell(worksheetIndex, u"B1", ObjectExt::Box<String>(u"Revenue"));
workbook->GetCell(worksheetIndex, u"C1", ObjectExt::Box<String>(u"Expenses"));
workbook->GetCell(worksheetIndex, u"D1", ObjectExt::Box<String>(u"Profit"));

workbook->GetCell(worksheetIndex, u"B2")->set_Value(ObjectExt::Box<double>(120.0));
workbook->GetCell(worksheetIndex, u"C2")->set_Value(ObjectExt::Box<double>(80.0));
workbook->GetCell(worksheetIndex, u"B3")->set_Value(ObjectExt::Box<double>(150.0));
workbook->GetCell(worksheetIndex, u"C3")->set_Value(ObjectExt::Box<double>(95.0));
workbook->GetCell(worksheetIndex, u"B4")->set_Value(ObjectExt::Box<double>(135.0));
workbook->GetCell(worksheetIndex, u"C4")->set_Value(ObjectExt::Box<double>(110.0));

auto profit1 = workbook->GetCell(worksheetIndex, u"D2");
auto profit2 = workbook->GetCell(worksheetIndex, u"D3");
auto profit3 = workbook->GetCell(worksheetIndex, u"D4");

profit1->set_Formula(u"B2-C2");
profit2->set_Formula(u"B3-C3");
profit3->set_Formula(u"B4-C4");

workbook->CalculateFormulas();

auto q1Profit = profit1->get_Value(); // 40
auto q2Profit = profit2->get_Value(); // 55
auto q3Profit = profit3->get_Value(); // 25

chartData->get_Categories()->Add(category1);
chartData->get_Categories()->Add(category2);
chartData->get_Categories()->Add(category3);

auto profitSeries = chartData->get_Series()->Add(workbook->GetCell(worksheetIndex, u"D1"), chart->get_Type());
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit1);
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit2);
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit3);
profitSeries->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

presentation->Save(u"chart-formulas.pptx", SaveFormat::Pptx);
```

Os pontos de dados do gráfico referenciam `D2:D4`, portanto o gráfico usa os valores de lucro calculados. Não há chamada separada de atualização do gráfico nesse fluxo: recalcule a pasta de trabalho primeiro, depois use ou salve os dados do gráfico que apontam para as células calculadas.

## **Usar fórmulas no estilo A1**

A notação A1 identifica colunas com letras e linhas com números. Atribua expressões no estilo A1 através de [IChartDataCell::set_Formula](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/ichartdatacell/set_formula/).

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"C3")->set_Value(ObjectExt::Box<int32_t>(10));
workbook->GetCell(0, u"F2")->set_Value(ObjectExt::Box<int32_t>(2));
workbook->GetCell(0, u"G2")->set_Value(ObjectExt::Box<int32_t>(3));
workbook->GetCell(0, u"H2")->set_Value(ObjectExt::Box<int32_t>(4));

auto cell = workbook->GetCell(0, u"A2");
cell->set_Formula(u"C3+SUM(F2:H2)");

workbook->CalculateFormulas();

auto value = cell->get_Value(); // 19
```

Formas de referência A1 comuns são:

| Referência | Relativo | Absoluto | Misto |
|---|---|---|---|
| Célula | `A2` | `$A$2` | `A$2`, `$A2` |
| Linha | `2:2` | `$2:$2` | — |
| Coluna | `A:A` | `$A:$A` | — |
| Intervalo | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Referências relativas podem mudar quando uma fórmula é movida ou copiada por uma aplicação de planilha. Referências absolutas mantêm ambas as coordenadas fixas, enquanto referências mistas fixam apenas uma linha ou uma coluna.

## **Usar fórmulas no estilo R1C1**

A notação R1C1 identifica linhas e colunas numericamente. Referências relativas usam deslocamentos entre colchetes. Atribua essa sintaxe através de [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/).

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"B2")->set_Value(ObjectExt::Box<int32_t>(12));
workbook->GetCell(0, u"C2")->set_Value(ObjectExt::Box<int32_t>(5));

auto cell = workbook->GetCell(0, u"D2");
cell->set_R1C1Formula(u"RC[-2]-RC[-1]");

workbook->CalculateFormulas();

auto value = cell->get_Value(); // 7
```

Formas de referência R1C1 comuns são:

| Referência | Relativo | Absoluto | Misto |
|---|---|---|---|
| Célula | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Linha | `R[2]` | `R2` | — |
| Coluna | `C[3]` | `C3` | — |
| Intervalo | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Por exemplo, na célula `D2`, `RC[-2]` significa a célula na mesma linha duas colunas à esquerda (`B2`).

## **Constantes e operadores de fórmula**

O avaliador de fórmulas incorporado suporta valores lógicos, literais numéricos, strings, valores de erro de planilha, operadores aritméticos e operadores de comparação.

### **Constantes e literais**

| Tipo | Exemplos | Observações |
|---|---|---|
| Lógico | `TRUE`, `FALSE` | Pode ser usado diretamente em expressões lógicas, como `A2=TRUE`. |
| Numérico | `1`, `0.5`, `.3`, `1E-2` | Notação comum e científica são suportadas. |
| Texto | `"abc"`, `"2/3/2020 12:00"` | Literais de texto são delimitados por aspas duplas dentro da fórmula. |
| Resultado de erro | `#DIV/0!`, `#N/A`, `#REF!` | Uma fórmula válida pode avaliar para um valor de erro de planilha em vez de um resultado normal. |

Este exemplo usa vários tipos de constante:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"A2")->set_Value(ObjectExt::Box<bool>(false));
workbook->GetCell(0, u"B2")->set_Formula(u"A2=TRUE");
workbook->GetCell(0, u"C2")->set_Formula(u"1+0.5");
workbook->GetCell(0, u"D2")->set_Formula(u".3*1E-2");
workbook->GetCell(0, u"E2")->set_Formula(u"\"abc\"");
workbook->GetCell(0, u"F2")->set_Formula(u"2/0");

workbook->CalculateFormulas();

auto logicalValue = workbook->GetCell(0, u"B2")->get_Value(); // Falso
auto numericValue = workbook->GetCell(0, u"C2")->get_Value(); // 1.5
auto scientificValue = workbook->GetCell(0, u"D2")->get_Value(); // 0.003
auto stringValue = workbook->GetCell(0, u"E2")->get_Value(); // abc
auto errorValue = workbook->GetCell(0, u"F2")->get_Value(); // Erro #DIV/0!
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

O Aspose.Slides inclui um avaliador de fórmulas interno para planilhas de gráfico, mas não é um motor completo de cálculo do Excel. O conjunto de funções documentado está limitado às funções abaixo. Não presuma que uma função arbitrária do Excel possa ser recalculada por [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/).

| Função | Propósito ou forma suportada | Exemplo |
|---|---|---|
| `ABS` | Valor absoluto | `ABS(A2)` |
| `AVERAGE` | Média aritmética | `AVERAGE(B2:B5)` |
| `CEILING` | Arredonda um número para cima até um múltiplo | `CEILING(A2,5)` |
| `CHOOSE` | Seleciona um valor por índice | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Concatena valores de texto | `CONCAT(A2,B2)` |
| `CONCATENATE` | Concatena valores de texto | `CONCATENATE(A2," ",B2)` |
| `DATE` | Cria um valor de data usando o sistema de data 1900 | `DATE(2026,8,19)` |
| `DAYS` | Retorna o número de dias entre datas | `DAYS(B2,A2)` |
| `FIND` | Procura um texto dentro de outro | `FIND("-",A2)` |
| `FINDB` | Busca orientada a bytes | `FINDB("a",A2)` |
| `IF` | Resultado condicional | `IF(A2>0,A2,0)` |
| `INDEX` | Forma de referência | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Forma vetorial | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Forma vetorial | `MATCH(A2,B2:B5,0)` |
| `MAX` | Valor máximo | `MAX(B2:B5)` |
| `SUM` | Soma valores | `SUM(B2:B5)` |
| `VLOOKUP` | Procura vertical | `VLOOKUP(A2,B2:D10,3,FALSE)` |

As restrições mostradas na tabela são significativas: `INDEX` é documentado na forma de referência, enquanto `LOOKUP` e `MATCH` são documentados nas suas formas vetoriais. `DATE` usa o sistema de data 1900. Recursos e funções não listados aqui devem ser considerados não suportados pelo avaliador de fórmulas do Aspose.Slides, a menos que sejam documentados separadamente.

## **Recalculação e valores em cache**

Arquivos de planilha costumam armazenar tanto a fórmula quanto seu último valor calculado. O Aspose.Slides pode ler um valor em cache de [IChartDataCell::get_Value](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/ichartdatacell/get_value/) quando uma apresentação é carregada e os dados do gráfico relevantes não foram alterados.

Depois de mudar células de entrada ou fórmulas, não confie em um resultado em cache antigo. Chame [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) antes de ler valores calculados ou salvar dados do gráfico que dependam deles.

Para fórmulas fora do subconjunto suportado, o Aspose.Slides pode não conseguir analisar a fórmula ou determinar suas dependências. Se a pasta de trabalho foi modificada, o valor em cache anterior não pode mais ser considerado confiável. Nessa situação, ler o valor de uma célula com dados não suportados pode gerar [CellUnsupportedDataException](https://reference.aspose.com/slides/pt/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Se seu gráfico depende de funções do Excel que o Aspose.Slides não avalia, calcule essas fórmulas com um motor de planilha que as suporte e escreva os valores resultantes de volta na pasta de trabalho do gráfico. Não substitua fórmulas não suportadas por valores adivinhados.

## **Tratar erros de fórmula**

Existem dois tipos diferentes de problemas a distinguir.

Uma fórmula pode ser válida, mas produzir um resultado de erro de planilha como `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` ou `#VALUE!`. Nesse caso, o token de erro é um resultado de célula e pode ser retornado através de [IChartDataCell::get_Value](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/ichartdatacell/get_value/).

Uma fórmula também pode falhar no nível de análise, referência, dependência ou dados suportados. O Aspose.Slides fornece exceções específicas de planilha para esses casos: [CellInvalidFormulaException](https://reference.aspose.com/slides/pt/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/pt/cpp/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/pt/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/) e [CellUnsupportedDataException](https://reference.aspose.com/slides/pt/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Quando as fórmulas vêm de modelos ou entrada do usuário, trate essas exceções ao redor da recalculação e do acesso ao valor:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Spreadsheet/CellCircularReferenceException.h>
#include <Spreadsheet/CellInvalidFormulaException.h>
#include <Spreadsheet/CellInvalidReferenceException.h>
#include <Spreadsheet/CellUnsupportedDataException.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Spreadsheet;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto cell = workbook->GetCell(0, u"A2");
cell->set_Formula(u"SUM(B2:B5)");

try
{
    workbook->CalculateFormulas();
    auto value = cell->get_Value();
}
catch (CellInvalidFormulaException&)
{
    // Manipular uma fórmula inválida.
}
catch (CellInvalidReferenceException&)
{
    // Manipular uma referência de célula inválida.
}
catch (CellCircularReferenceException&)
{
    // Manipular uma referência circular.
}
catch (CellUnsupportedDataException&)
{
    // Manipular dados de planilha não suportados.
}
```

## **Limitações práticas**

O suporte a fórmulas em planilhas de gráfico é destinado a um subconjunto definido de cálculos de planilha, não à compatibilidade total com o Excel. Tenha essas restrições em mente ao projetar um fluxo de trabalho de relatórios:

- Use apenas as constantes, operadores, referências e funções documentadas quando precisar que o Aspose.Slides recalcule fórmulas.
- Recalcule após mudar células das quais os resultados das fórmulas dependem.
- Considere valores em cache de apresentações carregadas como instantâneos, não como substituição da recalculação após edições.
- Teste fórmulas de modelos existentes antes de confiar em seus valores calculados, especialmente quando utilizam funções fora da lista documentada.
- Para fórmulas que exigem um motor completo de cálculo de planilha, calcule-as externamente e depois atualize a pasta de trabalho do gráfico com os valores resultantes.

## **FAQ**

**Qual a diferença entre `set_Formula` e `set_R1C1Formula`?**

[IChartDataCell::set_Formula](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/ichartdatacell/set_formula/) armazena uma expressão no estilo A1 como `B2-C2`. [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) armazena uma expressão no estilo R1C1 como `RC[-2]-RC[-1]`. Use a notação que melhor corresponde a como você gera ou copia fórmulas.

**Preciso ler a própria célula ou seu valor após o cálculo?**

[IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) retorna um `IChartDataCell`. Para obter o resultado calculado, leia o valor da célula via [IChartDataCell::get_Value](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/ichartdatacell/get_value/) após a recalculação.

**Quando devo chamar `CalculateFormulas`?**

Chame [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) depois de mudar valores de entrada ou fórmulas e antes de depender dos resultados calculados. Isso atualiza os valores das fórmulas que o avaliador interno suporta.

**O Aspose.Slides suporta todas as funções do Excel?**

Não. O avaliador interno suporta um subconjunto documentado de funções. Funções fora desse subconjunto não devem ser presumidas como recalculáveis corretamente. Se for necessária compatibilidade total com fórmulas do Excel, execute o cálculo com um motor de planilha adequado e grave os valores finais na pasta de trabalho do gráfico.

**O que acontece se uma apresentação carregada contiver uma fórmula não suportada?**

Se os dados do gráfico não foram alterados, a pasta de trabalho pode ainda conter um valor em cache calculado anteriormente. Depois que os dados relacionados forem modificados, esse valor em cache pode não ser mais válido. Acessar uma célula cuja fórmula não pode ser tratada pode gerar [CellUnsupportedDataException](https://reference.aspose.com/slides/pt/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/).

**Valores de erro de fórmula são iguais a exceções C++?**

Não. Um resultado como `#DIV/0!` é um valor de planilha produzido por um cálculo válido. Exceções como [CellInvalidFormulaException](https://reference.aspose.com/slides/pt/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/) ou [CellCircularReferenceException](https://reference.aspose.com/slides/pt/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/) indicam que a fórmula não pôde ser processada normalmente.

**Um gráfico é atualizado automaticamente quando uma célula de fórmula muda?**

Uma série de gráfico pode referenciar células da pasta de trabalho. Recalcule a pasta de trabalho primeiro, depois salve ou renderize a apresentação. Se os pontos de dados do gráfico referenciam as células calculadas, o gráfico usa esses valores atualizados; nenhum método de atualização separado do gráfico é necessário para esse fluxo.

**Os gráficos podem usar uma pasta de trabalho Excel externa?**

Sim, os dados do gráfico podem ser configurados para usar uma pasta de trabalho externa através da API de dados do gráfico. Contudo, o fluxo de cálculo de fórmula descrito neste artigo refere‑se à pasta de trabalho de dados do gráfico e ao subconjunto de fórmulas avaliado pelo Aspose.Slides. Não presuma que [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) fornece recalculação completa de fórmulas arbitrárias em um arquivo XLSX externo.

**Posso usar fórmulas que referenciam outra planilha ou pasta de trabalho?**

Referências no estilo Excel podem existir em pastas de trabalho de gráfico, mas a avaliação de fórmula é limitada ao analisador e ao conjunto de funções suportados. Se uma referência cruzada de planilha ou externa for essencial, valide essa fórmula exatamente com a versão do Aspose.Slides que você está usando. Para fluxos que exigem ampla compatibilidade de referências do Excel, calcule a pasta de trabalho externamente e grave os valores resolvidos de volta nos dados do gráfico.

**As strings de fórmula devem começar com `=`?**

Os exemplos da API Aspose.Slides atribuem expressões como `B2-C2` ou `SUM(B2:B5)` sem um `=` inicial. Usar essa forma mantém as fórmulas geradas consistentes com os exemplos documentados da API.