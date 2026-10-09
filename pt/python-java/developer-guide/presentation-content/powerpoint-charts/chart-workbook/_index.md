---
title: Gerenciar Workbooks de Gráficos em Apresentações Usando Python via Java
linktitle: Workbook de Gráfico
type: docs
weight: 70
url: /pt/python-java/chart-workbook/
keywords:
- workbook de gráfico
- dados do gráfico
- célula de workbook
- rótulo de dados
- planilha
- fonte de dados
- workbook externo
- dados externos
- cache de gráfico
- recuperação de workbook
- PowerPoint
- apresentação
- Python
- Java
- Aspose.Slides
description: "Descubra Aspose.Slides for Python via Java: gerencie facilmente workbooks de gráficos em formatos PowerPoint e OpenDocument para simplificar os dados da sua apresentação."
---
## **Visão geral**

Este artigo explica como trabalhar com workbooks de gráficos no Aspose.Slides. Ele mostra como ler e gravar dados de gráficos por meio de fluxos de workbook, usar células de workbook como rótulos de dados do gráfico, acessar coleções de planilhas e especificar o tipo de fonte de dados para os valores do gráfico.

Também cobre o trabalho com workbooks externos como fontes de dados de gráficos. Os exemplos demonstram como criar e atribuir um workbook externo, recuperar o caminho de um workbook externo vinculado a um gráfico e editar os dados do gráfico quando o workbook está disponível.

Para células de workbook que representam dados ausentes, veja [Controlar a Exibição de Células Vazias](/slides/pt/python-java/chart-series/) para a diferença entre uma célula vazia e zero, e uma comparação em gráfico de linhas dos modos de exibição disponíveis.

## **Incluir Dados de Linhas e Colunas Ocultas**

Use [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setPlotVisibleCellsOnly) para controlar se um gráfico plota dados de linhas e colunas de planilha ocultas. Defina como `True` para plotar apenas células visíveis, ou `False` para incluir tanto células visíveis quanto ocultas. Esta configuração controla a plotagem do gráfico; não oculta nem mostra linhas ou colunas da planilha.

A [apresentação de exemplo](hidden-source-data.pptx) contém um gráfico de colunas como a primeira forma no seu primeiro slide. A planilha incorporada, `Sheet1`, contém o seguinte intervalo de origem, `A1:C4`. A linha 3 e a coluna C estão ocultas, mas suas células ainda contêm valores.

| Linha da planilha | A: Mês | B: Varejo | C: Atacado (coluna oculta) |
| --- | --- | --- | --- |
| 2 | Janeiro | 10 | 30 |
| 3 (linha oculta) | Fevereiro | 40 | 60 |
| 4 | Março | 20 | 50 |

Acesse as células de origem através de [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) e leia [ChartDataCell.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#isHidden) para inspecionar seu status de ocultação. Este método relata o status de ocultação sem alterá‑lo. Neste arquivo, B2 está visível, B3 pertence à linha oculta e C2 pertence à coluna oculta; o exemplo imprime `False`, `True` e `True`, respectivamente.

Para este exemplo, atualize os dados do gráfico após alterar a configuração de plotagem: retenha o workbook incorporado com [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) e recarregue‑o com [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream). Ao incluir todas as células, use também [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) para restaurar o intervalo completo, incluindo a categoria de fevereiro ocultada. Simplesmente mudar a flag é insuficiente para atualizar os dados de gráfico em cache e os rótulos de categoria deste exemplo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("hidden-source-data.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        workbook = chart.getChartData().getChartDataWorkbook()
        print("B2 hidden:", workbook.getCell(0, "B2").isHidden())
        print("B3 hidden:", workbook.getCell(0, "B3").isHidden())
        print("C2 hidden:", workbook.getCell(0, "C2").isHidden())

        workbook_data = chart.getChartData().readWorkbookStream()
        for visible_only in (True, False):
            chart.setPlotVisibleCellsOnly(visible_only)

            # Atualizar os dados do gráfico a partir do workbook incorporado.
            chart.getChartData().writeWorkbookStream(workbook_data)
            if not visible_only:
                # Restaurar o intervalo de origem completo, incluindo categorias ocultas.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

O exemplo salva duas versões da apresentação: uma com apenas os valores de Varejo visíveis (10 e 20) e outra com todos os seis valores. As imagens abaixo ilustram os dois modos de plotagem. A linha 3 e a coluna C permanecem ocultas em ambos os workbooks incorporados.

| Apenas células visíveis (`True`) | Todas as células (`False`) |
| --- | --- |
| ![Apenas células visíveis: valores de Varejo 10 e 20 para Janeiro e Março.](hidden_cells_True.png) | ![Todas as células: valores de Varejo e Atacado para Janeiro, Fevereiro e Março.](hidden_cells_False.png) |

Uma célula oculta que contém um valor é diferente de uma célula vazia. [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) controla como valores ausentes são exibidos; não inclui nem exclui dados de origem ocultos. Veja [Controlar a Exibição de Células Vazias](/slides/pt/python-java/chart-series/#control-the-display-of-empty-cells) para um exemplo.

## **Recuperar o Intervalo de Dados de um Gráfico**

Antes de atualizar os dados do workbook em uma apresentação existente, inspecione os intervalos de origem para identificar quais células da planilha cada gráfico usa. O método [ChartData.getRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getRange) retorna o intervalo de dados atual como uma fórmula qualificada da planilha, como `Sheet1!$A$1:$D$5`. Aqui, `Sheet1` é o nome da planilha, `!` a separa do intervalo de células e `$A$1:$D$5` identifica as células A1 até D5, inclusive. Os sinais de dólar indicam referências absolutas de linha e coluna.

O método lê o intervalo atual sem alterar o gráfico ou seu workbook. Se o gráfico não usar um workbook como fonte de dados, ele lança `InvalidOperationException`. Para mais informações, consulte a [ChartData API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/).

Este exemplo abre uma apresentação e verifica as formas diretamente em cada slide para gráficos. Ele imprime o nome de cada gráfico e o intervalo de origem. Se um gráfico não usar um workbook, ele imprime uma mensagem e continua para o próximo gráfico.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

InvalidOperationException = jpype.JClass("com.aspose.slides.exceptions.InvalidOperationException")

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, Chart):
                try:
                    data_range = shape.getChartData().getRange()
                    print(f"{shape.getName()}: {data_range}")
                except InvalidOperationException:
                    print(f"{shape.getName()}: The chart does not use a workbook as its data source.")
finally:
    presentation.dispose()
```

## **Ler e Gravar Dados de Gráfico a partir de um Workbook**

Aspose.Slides for Python via Java fornece os métodos [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) e [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream) que permitem ler e gravar workbooks de dados de gráficos (contendo dados de gráfico editados com Aspose.Cells). **Note** que os dados do gráfico precisam estar organizados da mesma maneira ou possuir uma estrutura semelhante à da origem.

Este exemplo usa uma apresentação com um gráfico como a primeira forma no seu primeiro slide. Ele lê o workbook incorporado em um array de bytes, limpa as séries e categorias existentes e grava o mesmo workbook de volta. As alterações permanecem na memória; o exemplo não salva a apresentação.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    
    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        workbook_data = chart_data.readWorkbookStream()

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

### **Validar o Layout do Gráfico Após Modificação do Workbook**

Quando você substitui um workbook incorporado por um modificado, o gráfico retém suas coleções originais de séries e categorias. Essa incompatibilidade pode fazer com que [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) falhe com um erro de índice fora do intervalo. Limpe as séries e categorias existentes antes de gravar o workbook atualizado de volta ao gráfico. Este exemplo usa um gráfico que é a primeira forma no primeiro slide. O comentário marca onde a edição do workbook ocorreria; o exemplo executável grava o workbook original de volta e valida o layout na memória.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        workbook_data = chart_data.readWorkbookStream()

        # Modifique os bytes do workbook aqui, por exemplo, usando Aspose.Cells.

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
        chart.validateChartLayout()
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Limpar as coleções remove referências de dados obsoletas antes que o workbook seja gravado de volta. Reconstrua quaisquer mapeamentos de séries e categorias necessários para o workbook atualizado antes de usar o gráfico.

## **Definir uma Célula do Workbook como Rótulo de Dados do Gráfico**

Você pode usar texto de células do workbook como rótulos de dados do gráfico.

Este exemplo adiciona um gráfico de bolhas com dados padrão ao primeiro slide de uma apresentação existente. Ele usa as células A10:A12 na planilha 0 para os três primeiros rótulos da primeira série, habilita rótulos a partir de células e salva a apresentação atualizada.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart2.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    label_values = ["Label 0 cell value", "Label 1 cell value", "Label 2 cell value"]
    
    chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, True)
    series = chart.getChartData().getSeries()
    data_labels = series.get_Item(0).getLabels()
    data_labels.getDefaultDataLabelFormat().setShowLabelValueFromCell(True)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(3):
        label_cell = workbook.getCell(0, f"A{10 + i}", label_values[i])
        data_labels.get_Item(i).setValueFromCell(label_cell)

    presentation.save("resultchart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Gerenciar Planilhas**

O método [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getWorksheets) fornece acesso às planilhas em um workbook de gráfico. Este exemplo cria um gráfico de pizza com dados padrão e imprime cada nome de planilha no console.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 500)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(workbook.getWorksheets().size()):
        print(workbook.getWorksheets().get_Item(i).getName())
finally:
    presentation.dispose()
```

## **Especificar o Tipo de Fonte de Dados**

Este exemplo cria um gráfico de colunas 3D com dados padrão e define dois nomes de série usando fontes de dados diferentes. O primeiro nome usa um literal de string; o segundo usa a célula C1 na planilha 0. A enumeração [DataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/) seleciona a fonte para cada nome. O exemplo salva a apresentação com os nomes de série atualizados.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, True)
    literal_name = chart.getChartData().getSeries().get_Item(0).getName()
    literal_name.setDataSourceType(DataSourceType.StringLiterals)
    literal_name.setData("LiteralString")
    cell_name = chart.getChartData().getSeries().get_Item(1).getName()
    name_cell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell")
    cell_name.setDataSourceType(DataSourceType.Worksheet)
    cell_name.setData(name_cell)
    
    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Detectar Formatos de Workbook Incorporado Não Compatíveis**

Aspose.Slides não oferece suporte ao formato de workbook binário do Excel (.xlsb) que pode ser incorporado em alguns gráficos. Você pode usar o método [getEmbeddedWorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) em [ChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/) junto com a enumeração [WorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/workbooktype/) para detectar formatos não suportados e pular esses gráficos. Este exemplo inspeciona as formas no primeiro slide de uma apresentação existente, ignora formas que não são gráficos e imprime uma mensagem diagnóstica para cada gráfico com um workbook .xlsb incorporado.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, ChartDataSourceType, Presentation, WorkbookType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, Chart):
            continue

        chart_data = shape.getChartData()

        is_internal_workbook = chart_data.getDataSourceType() == ChartDataSourceType.InternalWorkbook
        is_binary_macro = chart_data.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro

        if is_internal_workbook and is_binary_macro:
            print("Skipping a chart with an unsupported .xlsb workbook.")
            continue
        # Leia ou modifique os dados do workbook de gráfico suportados aqui.
finally:
    presentation.dispose()
```

## **Workbook Externo**

Aspose.Slides oferece suporte ao uso de workbooks externos como fonte de dados para gráficos.

### **Criar um Workbook Externo**

Use [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) e [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) para exportar um workbook de gráfico incorporado para um arquivo e vincular o gráfico a esse workbook externo.

Este exemplo cria um gráfico de pizza com dados padrão e exporta seu workbook. Ele conclui a gravação do arquivo antes de atribuir o workbook externo como fonte de dados do gráfico, então salva a apresentação vinculada.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600)
    workbook_path = Path("externalWorkbook1.xlsx").resolve()
    workbook_data = chart.getChartData().readWorkbookStream()
    Path(workbook_path).write_bytes(bytes(workbook_data))
    chart.getChartData().setExternalWorkbook(str(workbook_path))

    presentation.save("externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Definir um Workbook Externo**

Usando o método [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook), você pode atribuir um workbook externo a um gráfico como sua fonte de dados. Este método também pode ser usado para atualizar o caminho para o workbook externo (se este último tiver sido movido).

Embora você não possa editar os dados em workbooks armazenados em locais remotos ou recursos, ainda pode usá‑los como fonte de dados externa. Se for fornecido um caminho relativo para um workbook externo, ele será convertido automaticamente para um caminho completo.

Este exemplo usa um workbook externo cuja planilha chamada `Sheet1` contém um nome de série em B1, nomes de categoria em A2:A4 e valores numéricos em B2:B4. O exemplo cria um gráfico de pizza, vincula o workbook e usa [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) para mapear A1:B4 para uma série e três categorias. Ele salva a apresentação com o gráfico vinculado.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    workbook_path = str(Path("externalWorkbook.xlsx").resolve())
    chart_data.setExternalWorkbook(workbook_path)
    chart_data.setRange("Sheet1!$A$1:$B$4")

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O parâmetro `updateChartData` de [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) controla se o workbook é carregado.

* Quando `updateChartData` é `False`, apenas o caminho do workbook é atualizado. Os dados do gráfico não são carregados nem atualizados a partir do workbook de destino, portanto o workbook pode estar indisponível.
* Quando `updateChartData` é `True`, os dados do gráfico são atualizados a partir do workbook de destino.

O exemplo a seguir atribui uma URL de placeholder com `updateChartData` definido como `False`. Ele mantém os dados padrão do gráfico de pizza e salva a apresentação sem carregar o workbook indisponível.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", False)

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Obter o Caminho do Workbook de Fonte de Dados Externa de um Gráfico**

Para identificar o workbook vinculado a um gráfico, verifique se o gráfico usa uma fonte de dados externa e recupere seu caminho de workbook.

Este exemplo inspeciona a primeira forma no primeiro slide de uma apresentação com um workbook externo vinculado. Se for um gráfico vinculado a um workbook externo, o exemplo imprime [getExternalWorkbookPath](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) no console. Em seguida, salva uma cópia da apresentação.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, ChartDataSourceType, Presentation, SaveFormat

presentation = Presentation("externalWorkbook.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        if chart_data.getDataSourceType() == ChartDataSourceType.ExternalWorkbook:
            print(chart_data.getExternalWorkbookPath())
        else:
            print("The chart does not use an external workbook.")
    else:
        print("The first shape is not a chart.")

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Editar Dados do Gráfico**

Você pode editar os dados em workbooks externos da mesma forma que faz alterações no conteúdo de workbooks internos. Quando um workbook externo não pode ser carregado, uma exceção é lançada.

Este exemplo usa um gráfico que é a primeira forma no primeiro slide e está vinculado a um workbook externo acessível. Ele define o valor respaldado por célula do primeiro ponto de dados na primeira série para 100 e salva a apresentação atualizada. Editar valores de célula pode atualizar o arquivo XLSX externo vinculado, portanto use uma cópia se precisar preservar o workbook original.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        series = chart.getChartData().getSeries()
        if series.size() > 0 and series.get_Item(0).getDataPoints().size() > 0:
            value_cell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell()
            if value_cell is not None:
                value_cell.setValue(jpype.JInt(100))
                presentation.save("presentation_out.pptx", SaveFormat.Pptx)
            else:
                print("The first data point is not linked to a workbook cell.")
        else:
            print("The chart has no data points to edit.")
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

### **Recuperar um Workbook a partir do Cache do Gráfico**

Se um gráfico usar um workbook externo que esteja ausente ou indisponível, Aspose.Slides pode reconstruir o workbook do gráfico a partir dos dados em cache na apresentação. Crie [LoadOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/), chame [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions) e defina [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) como `True` antes de abrir a apresentação.

O exemplo Python a seguir recupera dados de workbook para um gráfico que é a primeira forma no primeiro slide e faz referência a um workbook externo indisponível. Ele acessa os dados recuperados através de [Chart.getChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getChartData) e [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, LoadOptions, Presentation, SpreadsheetOptions

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setRecoverWorkbookFromChartCache(True)

load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        recovered_workbook = chart.getChartData().getChartDataWorkbook()

        # Leia ou modifique os dados do workbook recuperado aqui.
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Se o workbook externo estiver indisponível e a recuperação estiver desativada, Aspose.Slides lançará uma exceção. Habilite a recuperação somente quando usar os dados de gráfico em cache for uma alternativa aceitável, pois o cache pode não conter alterações feitas no workbook externo após a última atualização da apresentação.

## **FAQ**

**Posso determinar se um gráfico específico está vinculado a um workbook externo ou incorporado?**

Sim. Um gráfico possui um [data source type](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType) e um [path to an external workbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath); se a fonte for um workbook externo, você pode ler o caminho completo para garantir que um arquivo externo está sendo usado.

**Caminhos relativos para workbooks externos são suportados e como são armazenados?**

Sim. Se você especificar um caminho relativo, ele será convertido automaticamente para um caminho absoluto. A apresentação armazena o caminho absoluto no arquivo PPTX, portanto mover o workbook pode requerer a atualização do link.

**Posso usar workbooks localizados em recursos/redes compartilhadas?**

Sim, esses workbooks podem ser usados como fonte de dados externa. Contudo, a edição direta de workbooks remotos a partir do Aspose.Slides não é suportada — eles podem ser usados apenas como fonte.

**O Aspose.Slides sobrescreve o XLSX externo ao salvar a apresentação?**

A apresentação armazena um [link to the external file](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath). Editar dados de gráfico respaldados por célula também pode atualizar o arquivo XLSX local vinculado. Use uma cópia do workbook se o original precisar permanecer inalterado.

**O que fazer se o arquivo externo estiver protegido por senha?**

Aspose.Slides não aceita senha ao vincular. Uma abordagem comum é remover a proteção previamente ou preparar uma cópia descriptografada (por exemplo, usando [Aspose.Cells](https://reference.aspose.com/cells/python-java/)) e vincular a essa cópia.

**Vários gráficos podem referenciar o mesmo workbook externo?**

Sim. Cada gráfico armazena seu próprio link. Se todos apontarem para o mesmo arquivo, atualizar esse arquivo será refletido em cada gráfico na próxima vez que os dados forem carregados.