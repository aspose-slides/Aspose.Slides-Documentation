---
title: Gerenciar Pastas de Trabalho de Gráficos em Apresentações com Python
linktitle: Pasta de Trabalho de Gráfico
type: docs
weight: 70
url: /pt/python-net/chart-workbook/
keywords:
- pasta de trabalho de gráfico
- dados de gráfico
- célula da pasta de trabalho
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
- Aspose.Slides
description: "Descubra Aspose.Slides para Python via .NET: gerencie facilmente pastas de trabalho de gráficos nos formatos PowerPoint e OpenDocument para simplificar os dados da sua apresentação."
---
## **Visão geral**

Este artigo explica como trabalhar com pastas de trabalho de gráficos no Aspose.Slides. Ele mostra como ler e gravar dados de gráficos por meio de fluxos de pastas de trabalho, usar células da pasta de trabalho como rótulos de dados do gráfico, acessar coleções de planilhas e especificar o tipo de origem dos dados para os valores do gráfico.

Também aborda o uso de pastas de trabalho externas como fontes de dados para gráficos. Os exemplos demonstram como criar e atribuir uma pasta de trabalho externa, recuperar o caminho de uma pasta de trabalho externa vinculada a um gráfico e editar os dados do gráfico quando a pasta de trabalho está disponível.

Para células de pasta de trabalho que representam dados ausentes, consulte [Control the Display of Empty Cells](/slides/pt/python-net/chart-series/) para entender a diferença entre uma célula vazia e zero, e uma comparação de gráfico de linhas dos modos de exibição disponíveis.

## **Incluir dados de linhas e colunas ocultas**

Use [Chart.plot_visible_cells_only](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chart/plot_visible_cells_only/) para controlar se um gráfico plota dados de linhas e colunas de planilha ocultas. Defina como `True` para plotar somente células visíveis, ou `False` para incluir tanto células visíveis quanto ocultas. Essa configuração controla a plotagem do gráfico; não oculta nem exibe linhas ou colunas da planilha.

Faça download de [hidden-source-data.pptx](hidden-source-data.pptx) e coloque-o no diretório de trabalho. Seu primeiro slide contém um gráfico de colunas como a primeira forma. A planilha incorporada, `Sheet1`, contém o intervalo de origem `A1:C4`. A linha 3 e a coluna C estão ocultas, mas suas células ainda contêm valores.

| Linha da planilha | A: Mês | B: Varejo | C: Atacado (coluna oculta) |
| --- | --- | --- | --- |
| 2 | Janeiro | 10 | 30 |
| 3 (linha oculta) | Fevereiro | 40 | 60 |
| 4 | Março | 20 | 50 |

Acesse as células de origem através de [ChartData.chart_data_workbook](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) e leia [ChartDataCell.is_hidden](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdatacell/is_hidden/) para inspecionar seu status de ocultação. Essa propriedade é somente leitura. Neste arquivo, B2 está visível, B3 pertence à linha oculta e C2 pertence à coluna oculta; o exemplo imprime `False`, `True` e `True`, respectivamente.

Para este exemplo, atualize os dados do gráfico após alterar a configuração de plotagem: retenha a pasta de trabalho incorporada com [read_workbook_stream](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) e recarregue-a com [write_workbook_stream](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdata/write_workbook_stream/). Ao incluir todas as células, use também [set_range](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdata/set_range/) para restaurar o intervalo completo, incluindo a categoria de fevereiro ocultada. Simplesmente mudar a flag não é suficiente para atualizar os dados em cache deste exemplo nem os rótulos de categoria.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("hidden-source-data.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        workbook = chart.chart_data.chart_data_workbook
        print(f"B2 hidden: {workbook.get_cell(0, 'B2').is_hidden}")
        print(f"B3 hidden: {workbook.get_cell(0, 'B3').is_hidden}")
        print(f"C2 hidden: {workbook.get_cell(0, 'C2').is_hidden}")

        workbook_stream = chart.chart_data.read_workbook_stream()
        for visible_only in [True, False]:
            chart.plot_visible_cells_only = visible_only

            # Atualizar os dados do gráfico a partir da pasta de trabalho incorporada.
            workbook_stream.seek(0)
            chart.chart_data.write_workbook_stream(workbook_stream)
            if not visible_only:
                # Restaurar o intervalo de origem completo, incluindo categorias ocultas.
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

O exemplo salva `hidden_cells_True.pptx` contendo apenas os valores de Varejo visíveis (10 e 20), e `hidden_cells_False.pptx` com todos os seis valores. As imagens abaixo foram renderizadas das apresentações salvas após serem reabertas; ambos os arquivos mantêm a configuração de plotagem atribuída. A linha 3 e a coluna C permanecem ocultas em ambas as pastas de trabalho incorporadas.

| Apenas células visíveis (`True`) | Todas as células (`False`) |
| --- | --- |
| ![Apenas células visíveis: valores de Varejo 10 e 20 para Janeiro e Março.](hidden_cells_True.png) | ![Todas as células: valores de Varejo e Atacado para Janeiro, Fevereiro e Março.](hidden_cells_False.png) |

Uma célula oculta que contém um valor é diferente de uma célula vazia. [Chart.display_blanks_as](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chart/display_blanks_as/) controla como valores ausentes são exibidos; não inclui nem exclui fontes de dados ocultas. Consulte [Control the Display of Empty Cells](/slides/pt/python-net/chart-series/#control-the-display-of-empty-cells) para um exemplo.

## **Ler e gravar dados de gráfico a partir de uma pasta de trabalho**

Aspose.Slides para Python via .NET fornece os métodos [read_workbook_stream](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) e [write_workbook_stream](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) que permitem ler e gravar pastas de trabalho de dados de gráficos (contendo dados de gráficos editados com Aspose.Cells). **Note** que os dados do gráfico precisam estar organizados da mesma forma ou ter uma estrutura semelhante à fonte.

Este exemplo abre `chart.pptx`, que deve conter um gráfico como a primeira forma em seu primeiro slide. Ele lê a pasta de trabalho incorporada em um fluxo, limpa as séries e categorias existentes e grava a mesma pasta de trabalho de volta. As alterações permanecem em memória; o exemplo não salva a apresentação.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
    else:
        print("The first shape is not a chart.")
```

### **Validar o layout do gráfico após modificação da pasta de trabalho**

Quando você substitui uma pasta de trabalho incorporada por uma modificada, o gráfico mantém suas coleções originais de séries e categorias. Essa incompatibilidade pode fazer com que [Chart.validate_chart_layout](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chart/validate_chart_layout/) falhe com um erro de índice fora do intervalo. Limpe as séries e categorias existentes antes de gravar a pasta de trabalho atualizada de volta no gráfico. Este exemplo requer `chart.pptx` com um gráfico como a primeira forma no primeiro slide. O comentário indica onde a edição da pasta de trabalho ocorreria; o exemplo executável grava a pasta de trabalho original de volta e valida o layout em memória.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        # Modificar o fluxo da pasta de trabalho aqui, por exemplo, usando Aspose.Cells.

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
        chart.validate_chart_layout()
    else:
        print("The first shape is not a chart.")
```

Limpar as coleções remove referências de dados obsoletas antes que a pasta de trabalho seja gravada novamente. Reconstrua quaisquer mapeamentos de séries e categorias necessários para a pasta de trabalho atualizada antes de usar o gráfico.

## **Definir uma célula da pasta de trabalho como rótulo de dados do gráfico**

É possível usar texto de células da pasta de trabalho como rótulos de dados do gráfico. Os passos a seguir mostram como vincular os rótulos em um gráfico de bolhas a células em sua pasta de trabalho de dados.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) .
1. Acesse o primeiro slide pelo índice base zero.
1. Adicione um gráfico de bolhas com dados padrão.
1. Acesse as séries do gráfico.
1. Defina a célula da pasta de trabalho como rótulo de dados.
1. Salve a apresentação.

Este exemplo abre `chart2.pptx`, que deve conter ao menos um slide, e adiciona um gráfico de bolhas com dados padrão. Ele usa as células A10:A12 na planilha 0 para os três primeiros rótulos da primeira série, habilita rótulos a partir de células e salva o resultado em `resultchart.pptx`.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart2.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    series = chart.chart_data.series[0]
    workbook = chart.chart_data.chart_data_workbook

    series.labels.default_data_label_format.show_label_value_from_cell = True
    series.labels[0].value_from_cell = workbook.get_cell(0, "A10", "Label 0 cell value")
    series.labels[1].value_from_cell = workbook.get_cell(0, "A11", "Label 1 cell value")
    series.labels[2].value_from_cell = workbook.get_cell(0, "A12", "Label 2 cell value")

    presentation.save("resultchart.pptx", slides.export.SaveFormat.PPTX)
```

## **Gerenciar planilhas**

A propriedade [ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) fornece acesso às planilhas em uma pasta de trabalho de gráfico. Este exemplo cria um gráfico de pizza com dados padrão e imprime cada nome de planilha no console.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 500)
    workbook = chart.chart_data.chart_data_workbook

    for worksheet in workbook.worksheets:
        print(worksheet.name)
```

## **Especificar o tipo de origem dos dados**

Este exemplo cria um gráfico de colunas 3D com dados padrão e define dois nomes de séries usando diferentes origens de dados. O primeiro nome usa um literal de string; o segundo usa a célula C1 na planilha 0. A enumeração [DataSourceType](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/datasourcetype/) seleciona a origem para cada nome. O resultado é salvo em `pres.pptx`.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)
    literal_name = chart.chart_data.series[0].name

    literal_name.data_source_type = charts.DataSourceType.STRING_LITERALS
    literal_name.data = "LiteralString"

    cell_name = chart.chart_data.series[1].name
    name_cell = chart.chart_data.chart_data_workbook.get_cell(0, "C1", "NewCell")
    cell_name.data_source_type = charts.DataSourceType.WORKSHEET
    cell_name.data = name_cell

    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Detectar formatos de pasta de trabalho incorporada não suportados**

Aspose.Slides não suporta o formato binário de pasta de trabalho Excel (.xlsb) que pode ser incorporado em alguns gráficos. Você pode usar a propriedade [embedded_workbook_type](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) em [ChartData](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdata/) junto com a enumeração [WorkbookType](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/workbooktype/) para detectar formatos não suportados e ignorar esses gráficos. Este exemplo inspeciona as formas no primeiro slide de `sample.pptx`, ignora formas que não são gráficos e imprime uma mensagem de diagnóstico para cada gráfico com uma pasta de trabalho .xlsb incorporada.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, charts.Chart):
            continue

        chart_data = shape.chart_data
        is_internal_workbook = chart_data.data_source_type == charts.ChartDataSourceType.INTERNAL_WORKBOOK
        is_binary_macro = chart_data.embedded_workbook_type == charts.WorkbookType.WORKBOOK_BINARY_MACRO

        if is_internal_workbook and is_binary_macro:
            print("Skipping a chart with an unsupported .xlsb workbook.")
            continue

        # Ler ou modificar dados de pasta de trabalho de gráfico suportados aqui.
```

## **Pasta de trabalho externa**

Aspose.Slides oferece suporte ao uso de pastas de trabalho externas como fonte de dados para gráficos.

### **Criar uma pasta de trabalho externa**

Use [read_workbook_stream](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) e [set_external_workbook](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdata/set_external_workbook/) para exportar uma pasta de trabalho de gráfico incorporada para um arquivo e vincular o gráfico a essa pasta de trabalho externa.

Este exemplo cria um gráfico de pizza com dados padrão, grava sua pasta de trabalho em `externalWorkbook1.xlsx` e fecha o fluxo de saída antes de atribuir o arquivo como fonte de dados do gráfico. Ele salva a apresentação vinculada em `externalWorkbook.pptx`.

```python
from pathlib import Path
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600)
    workbook_path = str(Path("externalWorkbook1.xlsx").resolve())

    workbook_stream = chart.chart_data.read_workbook_stream()
    workbook_data = workbook_stream.read()
    with open(workbook_path, "wb") as file_stream:
        file_stream.write(workbook_data)

    chart.chart_data.set_external_workbook(workbook_path)
    presentation.save("externalWorkbook.pptx", slides.export.SaveFormat.PPTX)
```

### **Definir uma pasta de trabalho externa**

Usando o método [set_external_workbook](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdata/set_external_workbook/), você pode atribuir uma pasta de trabalho externa a um gráfico como sua fonte de dados. Esse método também pode ser usado para atualizar o caminho da pasta de trabalho externa (se ela tiver sido movida).

Embora não seja possível editar os dados em pastas de trabalho armazenadas em locais remotos ou recursos, ainda é possível usá‑las como fonte de dados externa. Se for fornecido um caminho relativo para uma pasta de trabalho externa, ele será convertido automaticamente em um caminho completo.

Este exemplo requer `externalWorkbook.xlsx` no diretório de trabalho. Sua planilha chamada `Sheet1` deve conter um nome de série em B1, nomes de categorias em A2:A4 e valores numéricos em B2:B4. O exemplo cria um gráfico de pizza, vincula a pasta de trabalho e usa [set_range](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdata/set_range/) para mapear A1:B4 para uma série e três categorias. Ele salva o resultado em `Presentation_with_externalWorkbook.pptx`.

```python
from pathlib import Path
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart_data = chart.chart_data
    workbook_path = str(Path("externalWorkbook.xlsx").resolve())

    chart_data.set_external_workbook(workbook_path)
    chart_data.set_range("Sheet1!$A$1:$B$4")

    presentation.save("Presentation_with_externalWorkbook.pptx", slides.export.SaveFormat.PPTX)
```

O parâmetro `update_chart_data` de [set_external_workbook](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdata/set_external_workbook/) controla se a pasta de trabalho será carregada.

* Quando `update_chart_data` é `False`, apenas o caminho da pasta de trabalho é atualizado. Os dados do gráfico não são carregados nem atualizados a partir da pasta de trabalho de destino, de modo que a pasta de trabalho pode estar indisponível.
* Quando `update_chart_data` é `True`, os dados do gráfico são atualizados a partir da pasta de trabalho de destino.

O exemplo a seguir atribui um URL de espaço reservado com `update_chart_data` definido como `False`. Ele mantém os dados padrão do gráfico de pizza e salva a apresentação sem carregar a pasta de trabalho indisponível.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)

    chart.chart_data.set_external_workbook("https://example.com/unavailable-workbook.xlsx", False)
    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **Obter o caminho da pasta de trabalho de origem de dados externa de um gráfico**

Para identificar a pasta de trabalho vinculada a um gráfico, primeiro verifique se o gráfico usa uma fonte de dados externa. Se usar, você pode recuperar o caminho da pasta de trabalho seguindo estes passos.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) .
1. Acesse o primeiro slide pelo índice base zero.
1. Verifique se a primeira forma é um gráfico.
1. Leia o tipo de origem dos dados do gráfico.
1. Se a origem for uma pasta de trabalho externa, leia seu caminho.

Este exemplo abre `externalWorkbook.pptx`, criado no exemplo anterior, e inspeciona a primeira forma no primeiro slide. Se for um gráfico vinculado a uma pasta de trabalho externa, o exemplo imprime [external_workbook_path](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdata/external_workbook_path/) no console. Em seguida, salva uma cópia da apresentação em `Result.pptx`.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("externalWorkbook.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        if chart_data.data_source_type == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
            print(chart_data.external_workbook_path)
        else:
            print("The chart does not use an external workbook.")
    else:
        print("The first shape is not a chart.")

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

### **Editar dados do gráfico**

É possível editar os dados em pastas de trabalho externas da mesma forma que se altera o conteúdo de pastas de trabalho internas. Quando uma pasta de trabalho externa não pode ser carregada, uma exceção é lançada.

Este exemplo requer `presentation.pptx` com um gráfico como a primeira forma no primeiro slide e uma pasta de trabalho externa acessível. Ele define o valor baseado em célula do primeiro ponto de dados da primeira série como 100 e salva a apresentação em `presentation_out.pptx`. A edição de valores de célula pode atualizar o arquivo XLSX externo vinculado, portanto use uma cópia se precisar preservar a pasta de trabalho original.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        series = chart.chart_data.series
        if len(series) > 0 and len(series[0].data_points) > 0:
            value_cell = series[0].data_points[0].value.as_cell
            if value_cell is not None:
                value_cell.value = 100
                presentation.save("presentation_out.pptx", slides.export.SaveFormat.PPTX)
            else:
                print("The first data point is not linked to a workbook cell.")
        else:
            print("The chart has no data points to edit.")
    else:
        print("The first shape is not a chart.")
```

### **Recuperar uma pasta de trabalho a partir do cache do gráfico**

Se um gráfico usar uma pasta de trabalho externa que esteja ausente ou indisponível, Aspose.Slides pode reconstruir a pasta de trabalho do gráfico a partir dos dados em cache na apresentação. Crie [LoadOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides/loadoptions/), configure sua [spreadsheet_options](https://reference.aspose.com/slides/pt/python-net/aspose.slides/loadoptions/spreadsheet_options/), e defina [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/pt/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) como `True` antes de abrir a apresentação.

O exemplo Python a seguir abre `presentation.pptx`, cujo primeiro shape no primeiro slide deve ser um gráfico que referencia uma pasta de trabalho externa indisponível, e acessa os dados recuperados através de [Chart.chart_data](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chart/chart_data/) e [ChartData.chart_data_workbook](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) :

```python
import aspose.slides as slides
import aspose.slides.charts as charts

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        recovered_workbook = chart.chart_data.chart_data_workbook

        # Ler ou modificar os dados da pasta de trabalho recuperada aqui.
    else:
        print("The first shape is not a chart.")
```

Se a pasta de trabalho externa estiver indisponível e a recuperação estiver desativada, Aspose.Slides lançará uma exceção. Habilite a recuperação somente quando o uso dos dados de gráfico em cache for uma alternativa aceitável, pois o cache pode não conter alterações feitas na pasta de trabalho externa após a última atualização da apresentação.

## **FAQ**

**Posso determinar se um gráfico específico está vinculado a uma pasta de trabalho externa ou incorporada?**

Sim. Um gráfico possui um [data source type](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdata/data_source_type/) e um [path to an external workbook](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdata/external_workbook_path/); se a origem for uma pasta de trabalho externa, você pode ler o caminho completo para confirmar que um arquivo externo está sendo usado.

**Caminhos relativos para pastas de trabalho externas são suportados e como são armazenados?**

Sim. Se você especificar um caminho relativo, ele será convertido automaticamente em um caminho absoluto. A apresentação armazena o caminho absoluto no arquivo PPTX, portanto mover a pasta de trabalho pode exigir a atualização do vínculo.

**Posso usar pastas de trabalho localizadas em recursos/rede compartilhada?**

Sim, essas pastas de trabalho podem ser usadas como fonte de dados externa. Contudo, a edição direta de pastas de trabalho remotas a partir do Aspose.Slides não é suportada — elas podem ser usadas apenas como fonte.

**O Aspose.Slides sobrescreve o XLSX externo ao salvar a apresentação?**

A apresentação armazena um [link para o arquivo externo](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdata/external_workbook_path/). Editar dados de gráfico baseados em células pode também atualizar o arquivo XLSX local vinculado. Use uma cópia da pasta de trabalho se o original precisar permanecer inalterado.

**O que fazer se o arquivo externo estiver protegido por senha?**

Aspose.Slides não aceita senha ao criar o vínculo. Uma abordagem comum é remover a proteção antecipadamente ou preparar uma cópia descriptografada (por exemplo, usando [Aspose.Cells](https://reference.aspose.com/cells/python-net/)) e vincular a essa cópia.

**Múltiplos gráficos podem referenciar a mesma pasta de trabalho externa?**

Sim. Cada gráfico armazena seu próprio link. Se todos apontarem para o mesmo arquivo, a atualização desse arquivo será refletida em cada gráfico na próxima vez que os dados forem carregados.