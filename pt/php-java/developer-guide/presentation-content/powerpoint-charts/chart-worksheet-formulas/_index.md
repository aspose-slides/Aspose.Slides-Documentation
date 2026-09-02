---
title: Aplicar fórmulas de planilha de gráfico em apresentações em PHP
linktitle: Fórmulas de planilha
type: docs
weight: 70
url: /pt/php-java/chart-worksheet-formulas/
keywords:
- planilha de gráfico
- planilha de gráfico
- fórmula de gráfico
- fórmula de planilha
- fórmula de planilha
- pasta de dados do gráfico
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
- PHP
- Aspose.Slides
description: "Aplicar fórmulas no estilo Excel em planilhas de gráfico do Aspose.Slides para PHP via Java, recalcular valores e usar os resultados em gráficos do PowerPoint."
---
## **Visão geral**

Os gráficos do PowerPoint geralmente armazenam seus dados de origem em uma planilha incorporada. No Aspose.Slides para PHP via Java, você pode acessar essa planilha por meio da pasta de trabalho de dados do gráfico, gravar valores de entrada, atribuir fórmulas às células, calcular fórmulas suportadas e usar as células calculadas como dados do gráfico.

Este artigo explica o fluxo completo de trabalho de fórmulas: criar um gráfico, preencher sua planilha, atribuir fórmulas no estilo A1 ou R1C1, recalculá‑las, ler os valores calculados, conectar essas células a uma série de gráfico e salvar a apresentação. Também descreve a sintaxe de fórmula suportada, o subconjunto de funções embutidas, valores em cache, fórmulas não suportadas e erros específicos de planilha.

## **Planilhas de Gráficos e Fórmulas**

Uma planilha de gráfico contém as categorias, nomes das séries e valores usados por um gráfico. No PowerPoint, você pode inspecionar a planilha abrindo o editor de dados do gráfico:

![Gráfico do PowerPoint com sua planilha incorporada aberta, mostrando dados de categoria e série](chart-worksheet-formulas_1.png)

No Aspose.Slides, a planilha é exposta através da classe [ChartDataWorkbook](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdataworkbook/). Use [ChartDataCell::setFormula](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdatacell/#setFormula) para fórmulas no estilo A1 e [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdatacell/#setR1C1Formula) para fórmulas no estilo R1C1. Depois de alterar células de entrada ou fórmulas, chame [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) para recalcular as fórmulas suportadas e atualizar os valores correspondentes das células.

Uma célula calculada ainda expõe seu resultado por meio de [ChartDataCell::getValue](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdatacell/#getValue). Isso é importante quando você precisa inspecionar o resultado de uma fórmula no código ou usar a célula como ponto de dados do gráfico.

## **Criar um Gráfico e Calcular Fórmulas da Planilha**

O exemplo a seguir demonstra um fluxo de trabalho de ponta a ponta. Ele cria um gráfico de colunas agrupadas, limpa os dados de exemplo, grava valores trimestrais de receita e despesa, calcula o lucro com fórmulas, lê os resultados, usa as células calculadas como valores do gráfico e salva a apresentação.

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 350);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $workbook->clear($worksheetIndex);

    $category1 = $workbook->getCell($worksheetIndex, "A2", "Q1");
    $category2 = $workbook->getCell($worksheetIndex, "A3", "Q2");
    $category3 = $workbook->getCell($worksheetIndex, "A4", "Q3");

    $workbook->getCell($worksheetIndex, "B1", "Revenue");
    $workbook->getCell($worksheetIndex, "C1", "Expenses");
    $workbook->getCell($worksheetIndex, "D1", "Profit");

    $workbook->getCell($worksheetIndex, "B2")->setValue(120.0);
    $workbook->getCell($worksheetIndex, "C2")->setValue(80.0);
    $workbook->getCell($worksheetIndex, "B3")->setValue(150.0);
    $workbook->getCell($worksheetIndex, "C3")->setValue(95.0);
    $workbook->getCell($worksheetIndex, "B4")->setValue(135.0);
    $workbook->getCell($worksheetIndex, "C4")->setValue(110.0);

    $profit1 = $workbook->getCell($worksheetIndex, "D2");
    $profit2 = $workbook->getCell($worksheetIndex, "D3");
    $profit3 = $workbook->getCell($worksheetIndex, "D4");

    $profit1->setFormula("B2-C2");
    $profit2->setFormula("B3-C3");
    $profit3->setFormula("B4-C4");

    $workbook->calculateFormulas();

    $q1Profit = java_values($profit1->getValue()); // 40
    $q2Profit = java_values($profit2->getValue()); // 55
    $q3Profit = java_values($profit3->getValue()); // 25

    echo "Q1 profit: " . $q1Profit . PHP_EOL;
    echo "Q2 profit: " . $q2Profit . PHP_EOL;
    echo "Q3 profit: " . $q3Profit . PHP_EOL;

    $chart->getChartData()->getCategories()->add($category1);
    $chart->getChartData()->getCategories()->add($category2);
    $chart->getChartData()->getCategories()->add($category3);

    $profitSeries = $chart->getChartData()->getSeries()->add($workbook->getCell($worksheetIndex, "D1"), $chart->getType());
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit1);
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit2);
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit3);
    $profitSeries->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);

    $presentation->save("chart-formulas.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Os pontos de dados do gráfico referenciam `D2:D4`, portanto o gráfico usa os valores de lucro calculados. Não há chamada separada de atualização de gráfico neste fluxo: recalcule a pasta de trabalho primeiro, depois use ou salve os dados do gráfico que apontam para as células calculadas.

## **Usar Fórmulas no Estilo A1**

A notação A1 identifica colunas com letras e linhas com números. Atribua expressões no estilo A1 através de [ChartDataCell::setFormula](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdatacell/#setFormula).

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "C3")->setValue(10);
    $workbook->getCell(0, "F2")->setValue(2);
    $workbook->getCell(0, "G2")->setValue(3);
    $workbook->getCell(0, "H2")->setValue(4);

    $cell = $workbook->getCell(0, "A2");
    $cell->setFormula("C3+SUM(F2:H2)");

    $workbook->calculateFormulas();

    $value = java_values($cell->getValue()); // 19
} finally {
    $presentation->dispose();
}
```

Formas comuns de referência A1 são:

| Referência | Relativa | Absoluta | Mista |
|---|---|---|---|
| Célula | `A2` | `$A$2` | `A$2`, `$A2` |
| Linha | `2:2` | `$2:$2` | — |
| Coluna | `A:A` | `$A:$A` | — |
| Intervalo | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Referências relativas podem mudar quando uma fórmula é movida ou copiada por uma aplicação de planilha. Referências absolutas mantêm ambas as coordenadas fixas, enquanto referências mistas fixam apenas uma linha ou uma coluna.

## **Usar Fórmulas no Estilo R1C1**

A notação R1C1 identifica linhas e colunas numericamente. Referências relativas usam deslocamentos entre colchetes. Atribua essa sintaxe através de [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdatacell/#setR1C1Formula).

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "B2")->setValue(12);
    $workbook->getCell(0, "C2")->setValue(5);

    $cell = $workbook->getCell(0, "D2");
    $cell->setR1C1Formula("RC[-2]-RC[-1]");

    $workbook->calculateFormulas();

    $value = java_values($cell->getValue()); // 7
} finally {
    $presentation->dispose();
}
```

Formas comuns de referência R1C1 são:

| Referência | Relativa | Absoluta | Mista |
|---|---|---|---|
| Célula | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Linha | `R[2]` | `R2` | — |
| Coluna | `C[3]` | `C3` | — |
| Intervalo | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Por exemplo, na célula `D2`, `RC[-2]` significa a célula na mesma linha duas colunas à esquerda (`B2`).

## **Constantes e Operadores de Fórmula**

O avaliador de fórmulas embutido suporta valores lógicos, literais numéricos, cadeias de texto, valores de erro de planilha, operadores aritméticos e operadores de comparação.

### **Constantes e Literais**

| Tipo | Exemplos | Observações |
|---|---|---|
| Lógico | `TRUE`, `FALSE` | Pode ser usado diretamente em expressões lógicas como `A2=TRUE`. |
| Numérico | `1`, `0.5`, `.3`, `1E-2` | Notação comum e científica são suportadas. |
| Texto | `"abc"`, `"2/3/2020 12:00"` | Literais de texto são delimitados por aspas duplas dentro da fórmula. |
| Resultado de erro | `#DIV/0!`, `#N/A`, `#REF!` | Uma fórmula válida pode avaliar para um valor de erro de planilha em vez de um resultado normal. |

Este exemplo usa vários tipos de constante:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "A2")->setValue(false);
    $workbook->getCell(0, "B2")->setFormula("A2=TRUE");
    $workbook->getCell(0, "C2")->setFormula("1+0.5");
    $workbook->getCell(0, "D2")->setFormula(".3*1E-2");
    $workbook->getCell(0, "E2")->setFormula("\"abc\"");
    $workbook->getCell(0, "F2")->setFormula("2/0");

    $workbook->calculateFormulas();

    $logicalValue = java_values($workbook->getCell(0, "B2")->getValue()); // falso
    $numericValue = java_values($workbook->getCell(0, "C2")->getValue()); // 1.5
    $scientificValue = java_values($workbook->getCell(0, "D2")->getValue()); // 0.003
    $stringValue = java_values($workbook->getCell(0, "E2")->getValue()); // abc
    $errorValue = java_values($workbook->getCell(0, "F2")->getValue()); // #DIV/0!
} finally {
    $presentation->dispose();
}
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

O Aspose.Slides inclui um avaliador de fórmulas embutido para planilhas de gráfico, mas não é um mecanismo completo de cálculo do Excel. O conjunto de funções documentado está limitado às funções abaixo. Não presuma que uma função arbitrária do Excel possa ser recalculada por [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdataworkbook/#calculateFormulas).

| Função | Propósito ou forma suportada | Exemplo |
|---|---|---|
| `ABS` | Valor absoluto | `ABS(A2)` |
| `AVERAGE` | Média aritmética | `AVERAGE(B2:B5)` |
| `CEILING` | Arredonda um número para cima até um múltiplo | `CEILING(A2,5)` |
| `CHOOSE` | Seleciona um valor por índice | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Junta valores de texto | `CONCAT(A2,B2)` |
| `CONCATENATE` | Junta valores de texto | `CONCATENATE(A2," ",B2)` |
| `DATE` | Cria um valor de data usando o sistema de datas 1900 | `DATE(2026,8,19)` |
| `DAYS` | Retorna o número de dias entre datas | `DAYS(B2,A2)` |
| `FIND` | Encontra um texto dentro de outro | `FIND("-",A2)` |
| `FINDB` | Busca de texto orientada a bytes | `FINDB("a",A2)` |
| `IF` | Resultado condicional | `IF(A2>0,A2,0)` |
| `INDEX` | Forma de referência | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Forma vetorial | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Forma vetorial | `MATCH(A2,B2:B5,0)` |
| `MAX` | Valor máximo | `MAX(B2:B5)` |
| `SUM` | Soma valores | `SUM(B2:B5)` |
| `VLOOKUP` | Busca vertical | `VLOOKUP(A2,B2:D10,3,FALSE)` |

As restrições mostradas na tabela são significativas: `INDEX` é documentado na forma de referência, enquanto `LOOKUP` e `MATCH` são documentados em suas formas vetoriais. `DATE` usa o sistema de datas 1900. Recursos e funções não listados aqui devem ser considerados não suportados pelo avaliador de fórmulas do Aspose.Slides, a menos que estejam documentados separadamente.

## **Recálculo e Valores em Cache**

Arquivos de planilha costumam armazenar tanto a fórmula quanto seu último valor calculado. O Aspose.Slides pode, portanto, ler um valor em cache de [ChartDataCell::getValue](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdatacell/#getValue) quando uma apresentação é carregada e os dados do gráfico relevantes não foram alterados.

Depois de mudar células de entrada ou fórmulas, não confie em um resultado antigo em cache. Chame [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) antes de ler valores calculados ou salvar dados do gráfico que dependem deles.

Para fórmulas fora do subconjunto suportado, o Aspose.Slides pode não conseguir analisar a fórmula ou estabelecer suas dependências. Se a pasta de trabalho foi modificada, o valor em cache anterior pode não ser mais confiável. Nessa situação, ler o valor de uma célula com dados não suportados pode gerar [CellUnsupportedDataException](https://reference.aspose.com/slides/pt/php-java/aspose.slides/cellunsupporteddataexception/).

Se seu gráfico depender de funções do Excel que o Aspose.Slides não avalia, calcule essas fórmulas com um mecanismo de planilha que as suporte e escreva os valores resultantes de volta na pasta de trabalho do gráfico. Não substitua fórmulas não suportadas por valores adivinhados.

## **Manipular Erros de Fórmula**

Existem dois tipos diferentes de problemas a distinguir.

Uma fórmula pode ser válida, mas produzir um resultado de erro de planilha como `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` ou `#VALUE!`. Nesse caso, o token de erro é um resultado de célula e pode ser retornado por meio de [ChartDataCell::getValue](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdatacell/#getValue).

Uma fórmula também pode falhar no nível de análise, referência, dependência ou dados suportados. O Aspose.Slides fornece exceções específicas de planilha para esses casos: [CellInvalidFormulaException](https://reference.aspose.com/slides/pt/php-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/pt/php-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/pt/php-java/aspose.slides/cellcircularreferenceexception/) e [CellUnsupportedDataException](https://reference.aspose.com/slides/pt/php-java/aspose.slides/cellunsupporteddataexception/).

Em PHP via Java, exceções Java são expostas através de `JavaException`. Quando as fórmulas vêm de modelos ou entrada do usuário, trate‑as ao redor do recálculo e do acesso ao valor. A exceção Java reportada no stack trace identifica a falha específica da planilha:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $cell = $workbook->getCell(0, "A2");
    $cell->setFormula("SUM(B2:B5)");

    try {
        $workbook->calculateFormulas();
        echo java_values($cell->getValue()) . PHP_EOL;
    } catch (JavaException $ex) {
        $ex->printStackTrace();
    }
} finally {
    $presentation->dispose();
}
```

## **Limitações Práticas**

O suporte a fórmulas em planilhas de gráfico destina‑se a um subconjunto definido de cálculos de planilha, não à compatibilidade total com o Excel. Tenha essas restrições em mente ao projetar um fluxo de trabalho de relatório:

- Use apenas as constantes, operadores, referências e funções documentadas quando precisar que o Aspose.Slides recalcule fórmulas.
- Recalcule após alterar células das quais os resultados das fórmulas dependem.
- Considere os valores em cache de apresentações carregadas como instantâneos, não como substitutos para recálculo após edições.
- Teste fórmulas de modelos existentes antes de confiar em seus valores calculados, especialmente quando usarem funções fora da lista documentada.
- Para fórmulas que exigem um mecanismo de cálculo completo de planilha, calcule‑as externamente e depois atualize a pasta de trabalho do gráfico com os valores resultantes.

## **FAQ**

**Qual é a diferença entre [ChartDataCell::setFormula](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdatacell/#setFormula) e [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdatacell/#setR1C1Formula)?**

[ChartDataCell::setFormula](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdatacell/#setFormula) armazena uma expressão no estilo A1, como `B2-C2`. [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdatacell/#setR1C1Formula) armazena uma expressão no estilo R1C1, como `RC[-2]-RC[-1]`. Use a notação que melhor corresponda à forma como você gera ou copia fórmulas.

**Preciso ler a própria célula ou seu valor após o cálculo?**

[ChartDataWorkbook::getCell](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdataworkbook/#getCell) retorna um [ChartDataCell](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdatacell/). Para obter o resultado calculado, chame o método [ChartDataCell::getValue](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdatacell/#getValue) dessa célula após o recálculo.

**Quando devo chamar [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdataworkbook/#calculateFormulas)?**

Chame [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) após alterar valores de entrada ou fórmulas e antes de depender dos resultados calculados. Isso atualiza os valores das fórmulas que o avaliador embutido suporta.

**O Aspose.Slides suporta todas as funções do Excel?**

Não. O avaliador embutido suporta um subconjunto documentado de funções. Funções fora desse subconjunto não devem ser presumidas como recalculáveis corretamente. Se for necessária compatibilidade total com fórmulas do Excel, realize o cálculo com um mecanismo de planilha adequado e grave os valores finais na pasta de trabalho do gráfico.

**O que acontece se uma apresentação carregada contiver uma fórmula não suportada?**

Se os dados do gráfico não foram alterados, a pasta de trabalho pode ainda conter um valor em cache calculado anteriormente. Após modificar os dados relacionados, esse valor em cache pode não ser mais válido. Acessar uma célula cuja fórmula não pode ser tratada pode gerar [CellUnsupportedDataException](https://reference.aspose.com/slides/pt/php-java/aspose.slides/cellunsupporteddataexception/).

**Valores de erro de fórmula são os mesmos que exceções PHP?**

Não. Um resultado como `#DIV/0!` é um valor de planilha produzido por um cálculo válido. Falhas no processamento da planilha, como [CellInvalidFormulaException](https://reference.aspose.com/slides/pt/php-java/aspose.slides/cellinvalidformulaexception/) ou [CellCircularReferenceException](https://reference.aspose.com/slides/pt/php-java/aspose.slides/cellcircularreferenceexception/), são exceções Java expostas ao PHP através de `JavaException`.

**Um gráfico é atualizado automaticamente quando uma célula de fórmula muda?**

Uma série de gráfico pode referenciar células da pasta de trabalho. Recalcule a pasta de trabalho primeiro, depois salve ou renderize a apresentação. Se os pontos de dados do gráfico referenciam as células calculadas, o gráfico usa esses valores de célula atualizados; nenhum método separado de atualização de gráfico é necessário para este fluxo.

**Gráficos podem usar uma pasta de trabalho Excel externa?**

Sim, os dados do gráfico podem ser configurados para usar uma pasta de trabalho externa via a API de dados do gráfico. Contudo, o fluxo de cálculo de fórmulas descrito neste artigo refere‑se à pasta de trabalho de dados do gráfico e ao subconjunto de fórmulas avaliado pelo Aspose.Slides. Não presuma que [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) forneça recálculo completo de fórmulas arbitrárias em um arquivo XLSX externo.

**Posso usar fórmulas que referenciam outra planilha ou pasta de trabalho?**

Referências no estilo Excel podem existir em pastas de trabalho de gráficos, mas a avaliação de fórmulas é limitada pelo analisador e conjunto de funções suportados. Se uma referência cruzada de planilha ou externa for essencial, valide a fórmula exata com a versão do Aspose.Slides que você está usando. Para fluxos que exigem ampla compatibilidade de referências do Excel, calcule a pasta de trabalho externamente e grave os valores resolvidos de volta nos dados do gráfico.

**As strings de fórmula devem começar com `=`?**

Os exemplos da API Aspose.Slides atribuem expressões como `B2-C2` ou `SUM(B2:B5)` sem um `=` inicial. Usar essa forma mantém as fórmulas geradas consistentes com os exemplos documentados da API.