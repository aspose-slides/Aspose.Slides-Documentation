---
title: Gerenciar Pastas de Trabalho de Gráficos em Apresentações Usando Python via Java
linktitle: Pasta de Trabalho de Gráfico
type: docs
weight: 70
url: /pt/python-java/chart-workbook/
keywords:
- pasta de trabalho de gráfico
- dados de gráfico
- célula de pasta de trabalho
- rótulo de dados
- planilha
- fonte de dados
- pasta de trabalho externa
- dados externos
- cache de gráfico
- recuperação de pasta de trabalho
- PowerPoint
- apresentação
- Python
- Java
- Aspose.Slides
description: "Descubra o Aspose.Slides para Python via Java: gerencie facilmente pastas de trabalho de gráficos em formatos PowerPoint e OpenDocument para simplificar os dados da sua apresentação."
---
## **Visão geral**

Este artigo explica como trabalhar com pastas de trabalho de gráfico no Aspose.Slides. Ele mostra como ler e gravar dados de gráfico por meio de fluxos de pastas de trabalho, usar células de pasta de trabalho como rótulos de dados de gráfico, acessar coleções de planilhas e especificar o tipo de origem de dados para os valores do gráfico.

Também aborda o trabalho com pastas de trabalho externas como fontes de dados de gráfico. Os exemplos demonstram como criar e atribuir uma pasta de trabalho externa, recuperar o caminho de uma pasta de trabalho externa vinculada a um gráfico e editar os dados do gráfico quando a pasta de trabalho está disponível.

Para células de pasta de trabalho que representam dados ausentes, veja [Controlar a Exibição de Células Vazias](/slides/pt/python-java/chart-series/) para a diferença entre uma célula vazia e zero, e uma comparação em gráfico de linhas dos modos de exibição disponíveis.

## **Incluir Dados de Linhas e Colunas Ocultas**

Use [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chart/#setPlotVisibleCellsOnly) para controlar se um gráfico traça dados de linhas e colunas de planilha ocultas. Defina como `True` para traçar apenas células visíveis ou como `False` para incluir tanto células visíveis quanto ocultas. Essa configuração controla o traçado do gráfico; não oculta ou exibe linhas ou colunas da planilha.

Baixe [hidden-source-data.pptx](hidden-source-data.pptx) e coloque-o no diretório de trabalho. Seu primeiro slide contém um gráfico de colunas como a primeira forma. A planilha incorporada, `Sheet1`, contém a faixa de origem `A1:C4`. A linha 3 e a coluna C estão ocultas, mas suas células ainda contêm valores.

| Linha da planilha | A: Mês | B: Varejo | C: Atacado (coluna oculta) |
| --- | --- | --- | --- |
| 2 | Janeiro | 10 | 30 |
| 3 (linha oculta) | Fevereiro | 40 | 60 |
| 4 | Março | 20 | 50 |

Acesse as células de origem através de [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdata/#getChartDataWorkbook) e leia [ChartDataCell.isHidden](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdatacell/#isHidden) para inspecionar seu status de ocultação. Esse método relata o status oculto sem alterá‑lo. Neste arquivo, B2 está visível, B3 pertence à linha oculta e C2 pertence à coluna oculta; o exemplo imprime `False`, `True` e `True`, respectivamente.

Para este exemplo, atualize os dados do gráfico após mudar a configuração de traçado: retenha a pasta de trabalho incorporada com [readWorkbookStream](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdata/#readWorkbookStream) e recarregue‑a com [writeWorkbookStream](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdata/#writeWorkbookStream). Ao incluir todas as células, também use [setRange](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdata/#setRange) para restaurar a faixa completa, incluindo a categoria de Fevereiro ocultada. Simplesmente mudar a bandeira não é suficiente para atualizar os dados de gráfico em cache e os rótulos de categoria deste exemplo.

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

            # Atualizar os dados do gráfico a partir da pasta de trabalho incorporada.
            chart.getChartData().writeWorkbookStream(workbook_data)
            if not visible_only:
                # Restaurar a faixa de origem completa, incluindo categorias ocultas.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

O exemplo salva `hidden_cells_True.pptx` contendo apenas os valores de Varejo visíveis (10 e 20) e `hidden_cells_False.pptx` com todos os seis valores. As imagens abaixo ilustram os dois modos de traçado. A linha 3 e a coluna C permanecem ocultas em ambas as pastas de trabalho incorporadas.

| Apenas células visíveis (`True`) | Todas as células (`False`) |
| --- | --- |
| ![Apenas células visíveis: Valores de Varejo 10 e 20 para Janeiro e Março.](hidden_cells_True.png) | ![Todas as células: Valores de Varejo e Atacado para Janeiro, Fevereiro e Março.](hidden_cells_False.png) |

Uma célula oculta contendo um valor difere de uma célula vazia. [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chart/#setDisplayBlanksAs) controla como valores ausentes são exibidos; não inclui ou exclui dados de origem ocultos. Veja [Controlar a Exibição de Células Vazias](/slides/pt/python-java/chart-series/#control-the-display-of-empty-cells) para um exemplo.

## **Ler e Gravar Dados de Gráfico de uma Pasta de Trabalho**

Aspose.Slides for Python via Java fornece os métodos [readWorkbookStream](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdata/#readWorkbookStream) e [writeWorkbookStream](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdata/#writeWorkbookStream) que permitem ler e gravar pastas de trabalho de dados de gráfico (contendo dados de gráfico editados com Aspose.Cells). **Note** que os dados do gráfico precisam estar organizados da mesma forma ou ter uma estrutura semelhante à fonte.

Este exemplo abre `chart.pptx`, que deve conter um gráfico como a primeira forma no seu primeiro slide. Ele lê a pasta de trabalho incorporada para um array de bytes, limpa as séries e categorias existentes e grava a mesma pasta de trabalho de volta. As alterações permanecem em memória; o exemplo não salva a apresentação.

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

### **Validar Layout do Gráfico Após Modificação da Pasta de Trabalho**

Quando você substitui uma pasta de trabalho incorporada por uma modificada, o gráfico mantém suas coleções originais de séries e categorias. Essa incompatibilidade pode fazer com que [Chart.validateChartLayout](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chart/#validateChartLayout) falhe com um erro de índice fora do intervalo. Limpe as séries e categorias existentes antes de gravar a pasta de trabalho atualizada de volta ao gráfico. Este exemplo requer `chart.pptx` com um gráfico como a primeira forma no seu primeiro slide. O comentário indica onde a edição da pasta de trabalho ocorreria; o exemplo executável grava a pasta de trabalho original de volta e valida o layout em memória.

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

        # Modifique os bytes da pasta de trabalho aqui, por exemplo, usando Aspose.Cells.

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
        chart.validateChartLayout()
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Limpar as coleções remove referências de dados obsoletas antes que a pasta de trabalho seja gravada de volta. Recrie quaisquer mapeamentos de séries e categorias necessários para a pasta de trabalho atualizada antes de usar o gráfico.

## **Definir uma Célula da Pasta de Trabalho como Rótulo de Dados do Gráfico**

Você pode usar texto de células da pasta de trabalho como rótulos de dados do gráfico. Os passos a seguir mostram como vincular os rótulos em um gráfico de bolhas às células em sua pasta de trabalho de dados.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
2. Acesse o primeiro slide pelo seu índice baseado em zero.
3. Adicione um gráfico de bolhas com dados padrão.
4. Acesse as séries do gráfico.
5. Defina a célula da pasta de trabalho como um rótulo de dados.
6. Salve a apresentação.

Este exemplo abre `chart2.pptx`, que deve conter ao menos um slide, e adiciona um gráfico de bolhas com dados padrão. Ele usa as células A10:A12 na planilha 0 para os três primeiros rótulos da primeira série, habilita rótulos a partir de células e salva o resultado em `resultchart.pptx`.

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

O método [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdataworkbook/#getWorksheets) fornece acesso às planilhas em uma pasta de trabalho de gráfico. Este exemplo cria um gráfico de pizza com dados padrão e imprime cada nome de planilha no console.

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

## **Especificar o Tipo de Origem de Dados**

Este exemplo cria um gráfico de colunas 3D com dados padrão e define dois nomes de série usando diferentes origens de dados. O primeiro nome usa um literal de string; o segundo usa a célula C1 na planilha 0. A enumeração [DataSourceType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/datasourcetype/) seleciona a origem para cada nome. O resultado é salvo em `pres.pptx`.

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

## **Detectar Formatos de Pasta de Trabalho Incorporada Não Suportados**

Aspose.Slides não oferece suporte ao formato de pasta de trabalho Excel binária (.xlsb) que pode ser incorporado em alguns gráficos. Você pode usar o método [getEmbeddedWorkbookType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) em [ChartData](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdata/) junto com a enumeração [WorkbookType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/workbooktype/) para detectar formatos não suportados e ignorar esses gráficos. Este exemplo inspeciona as formas no primeiro slide de `sample.pptx`, ignora formas que não sejam gráficos e imprime uma mensagem de diagnóstico para cada gráfico com uma pasta de trabalho .xlsb incorporada.

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
        # Leia ou modifique os dados da pasta de trabalho de gráfico suportados aqui.
finally:
    presentation.dispose()
```

## **Pasta de Trabalho Externa**

Aspose.Slides oferece suporte ao uso de pastas de trabalho externas como fonte de dados para gráficos.

### **Criar uma Pasta de Trabalho Externa**

Use [readWorkbookStream](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdata/#readWorkbookStream) e [setExternalWorkbook](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdata/#setExternalWorkbook) para exportar a pasta de trabalho de gráfico incorporada para um arquivo e vincular o gráfico a essa pasta de trabalho externa.

Este exemplo cria um gráfico de pizza com dados padrão, grava sua pasta de trabalho em `externalWorkbook1.xlsx` e completa a gravação do arquivo antes de atribuir o arquivo como fonte de dados do gráfico. Ele salva a apresentação vinculada em `externalWorkbook.pptx`.

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

### **Definir uma Pasta de Trabalho Externa**

Usando o método [setExternalWorkbook](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdata/#setExternalWorkbook), você pode atribuir uma pasta de trabalho externa a um gráfico como sua fonte de dados. Esse método também pode ser usado para atualizar o caminho para a pasta de trabalho externa (se esta tiver sido movida).

Embora você não possa editar os dados em pastas de trabalho armazenadas em locais remotos ou recursos, ainda pode usá‑las como fonte de dados externa. Se for fornecido um caminho relativo para uma pasta de trabalho externa, ele será convertido automaticamente para um caminho completo.

Este exemplo requer `externalWorkbook.xlsx` no diretório de trabalho. Sua planilha chamada `Sheet1` deve conter um nome de série em B1, nomes de categoria em A2:A4 e valores numéricos em B2:B4. O exemplo cria um gráfico de pizza, vincula a pasta de trabalho e usa [setRange](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdata/#setRange) para mapear A1:B4 para uma série e três categorias. Ele salva o resultado em `Presentation_with_externalWorkbook.pptx`.

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

O parâmetro `updateChartData` de [setExternalWorkbook](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdata/#setExternalWorkbook) controla se a pasta de trabalho é carregada.

* Quando `updateChartData` é `False`, somente o caminho da pasta de trabalho é atualizado. Os dados do gráfico não são carregados nem atualizados a partir da pasta de trabalho de destino, de modo que a pasta de trabalho pode estar indisponível.
* Quando `updateChartData` é `True`, os dados do gráfico são atualizados a partir da pasta de trabalho de destino.

O exemplo a seguir atribui uma URL de espaço reservado com `updateChartData` definido como `False`. Ele mantém os dados padrão do gráfico de pizza e salva a apresentação sem carregar a pasta de trabalho indisponível.

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

### **Obter o Caminho da Pasta de Trabalho da Fonte de Dados Externa de um Gráfico**

Para identificar a pasta de trabalho vinculada a um gráfico, primeiro verifique se o gráfico usa uma fonte de dados externa. Se usar, você pode recuperar o caminho da pasta de trabalho seguindo estes passos.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
2. Acesse o primeiro slide pelo seu índice baseado em zero.
3. Verifique se a primeira forma é um gráfico.
4. Leia o tipo de origem de dados do gráfico.
5. Se a origem for uma pasta de trabalho externa, leia seu caminho.

Este exemplo abre `externalWorkbook.pptx`, criado no exemplo anterior, e inspeciona a primeira forma no primeiro slide. Se for um gráfico vinculado a uma pasta de trabalho externa, o exemplo imprime [getExternalWorkbookPath](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) no console. Em seguida, salva uma cópia da apresentação em `Result.pptx`.

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

Você pode editar os dados em pastas de trabalho externas da mesma forma que faz alterações no conteúdo de pastas de trabalho internas. Quando uma pasta de trabalho externa não pode ser carregada, uma exceção é lançada.

Este exemplo requer `presentation.pptx` com um gráfico como a primeira forma no primeiro slide e uma pasta de trabalho externa acessível. Ele define o valor da célula do primeiro ponto de dados da primeira série para 100 e salva a apresentação em `presentation_out.pptx`. A edição de valores de células pode atualizar o arquivo XLSX externo vinculado, portanto use uma cópia se precisar preservar a pasta de trabalho original.

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

### **Recuperar uma Pasta de Trabalho do Cache do Gráfico**

Se um gráfico usar uma pasta de trabalho externa que esteja ausente ou indisponível, Aspose.Slides pode reconstruir a pasta de trabalho do gráfico a partir dos dados em cache na apresentação. Crie [LoadOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/loadoptions/), chame [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions) e defina [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/pt/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) como `True` antes de abrir a apresentação.

O exemplo Python a seguir abre `presentation.pptx`, cujo primeiro shape no primeiro slide deve ser um gráfico que referencia uma pasta de trabalho externa indisponível, e acessa os dados recuperados através de [Chart.getChartData](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chart/#getChartData) e [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdata/#getChartDataWorkbook):

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

        # Leia ou modifique os dados da pasta de trabalho recuperada aqui.
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Se a pasta de trabalho externa estiver indisponível e a recuperação estiver desativada, Aspose.Slides lança uma exceção. Ative a recuperação apenas quando o uso dos dados de gráfico em cache for uma alternativa aceitável, pois o cache pode não conter alterações feitas na pasta de trabalho externa após a última atualização da apresentação.

## **Perguntas Frequentes**

**Posso determinar se um gráfico específico está vinculado a uma pasta de trabalho externa ou incorporada?**

Sim. Um gráfico possui um [tipo de origem de dados](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdata/#getDataSourceType) e um [caminho para uma pasta de trabalho externa](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdata/#getExternalWorkbookPath); se a origem for uma pasta de trabalho externa, você pode ler o caminho completo para garantir que um arquivo externo está sendo usado.

**Caminhos relativos para pastas de trabalho externas são suportados e como são armazenados?**

Sim. Se você especificar um caminho relativo, ele é convertido automaticamente para um caminho absoluto. A apresentação armazena o caminho absoluto no arquivo PPTX, portanto mover a pasta de trabalho pode exigir a atualização do link.

**Posso usar pastas de trabalho localizadas em recursos ou compartilhamentos de rede?**

Sim, essas pastas de trabalho podem ser usadas como fonte de dados externa. No entanto, a edição direta de pastas de trabalho remotas a partir do Aspose.Slides não é suportada — elas podem ser usadas apenas como fonte.

**O Aspose.Slides sobrescreve o XLSX externo ao salvar a apresentação?**

A apresentação armazena um [link para o arquivo externo](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdata/#getExternalWorkbookPath). Editar dados de gráfico baseados em células também pode atualizar o arquivo XLSX local vinculado. Use uma cópia da pasta de trabalho se o original precisar permanecer inalterado.

**O que fazer se o arquivo externo estiver protegido por senha?**

Aspose.Slides não aceita senha ao criar o vínculo. Uma abordagem comum é remover a proteção antecipadamente ou preparar uma cópia descriptografada (por exemplo, usando [Aspose.Cells](https://reference.aspose.com/cells/python-java/)) e vincular a essa cópia.

**Vários gráficos podem referenciar a mesma pasta de trabalho externa?**

Sim. Cada gráfico armazena seu próprio link. Se todos apontarem para o mesmo arquivo, a atualização desse arquivo será refletida em cada gráfico na próxima vez que os dados forem carregados.