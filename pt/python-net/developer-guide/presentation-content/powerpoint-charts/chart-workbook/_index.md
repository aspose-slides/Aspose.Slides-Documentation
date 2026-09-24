---
title: Gerenciar pastas de trabalho de gráfico em apresentações com Python
linktitle: Pasta de trabalho de gráfico
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
description: "Descubra Aspose.Slides para Python via .NET: gerencie facilmente pastas de trabalho de gráfico em formatos PowerPoint e OpenDocument para simplificar os dados da sua apresentação."
---
## **Visão geral**

Este artigo explica como trabalhar com pastas de trabalho de gráfico no Aspose.Slides. Ele mostra como ler e gravar dados de gráfico por meio de streams de pasta de trabalho, usar células da pasta de trabalho como rótulos de dados do gráfico, acessar coleções de planilhas e especificar o tipo de origem de dados para os valores do gráfico.

Também cobre o trabalho com pastas de trabalho externas como fontes de dados de gráfico. Os exemplos demonstram como criar e atribuir uma pasta de trabalho externa, recuperar o caminho de uma pasta de trabalho externa vinculada a um gráfico e editar dados do gráfico quando a pasta de trabalho está disponível.

Para células da pasta de trabalho que representam dados ausentes, veja [Controlar a Exibição de Células Vazias](/slides/pt/python-net/chart-series/) para a diferença entre uma célula vazia e zero, e uma comparação de gráfico de linhas dos modos de exibição disponíveis.

## **Ler e gravar dados de gráfico a partir de uma pasta de trabalho**

O Aspose.Slides fornece métodos para ler e gravar pastas de trabalho de dados de gráfico (que contêm dados de gráfico editados com Aspose.Cells). **Observação:** Os dados do gráfico devem estar organizados da mesma forma ou ter uma estrutura semelhante à fonte.

O código Python a seguir demonstra uma operação de exemplo:

```py
import aspose.slides as slides

with slides.Presentation("chart.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]

    data_stream = chart.chart_data.read_workbook_stream()

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    data_stream.seek(0)
    chart.chart_data.write_workbook_stream(data_stream)
```

### **Validar o layout do gráfico após modificação da pasta de trabalho**

Quando você substitui uma pasta de trabalho incorporada por uma modificada, o gráfico mantém suas coleções originais de séries e categorias. Essa incompatibilidade pode fazer com que [IChart.validate_chart_layout](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/ichart/validate_chart_layout/) falhe com um erro de índice fora do intervalo. Limpe as séries e categorias existentes antes de gravar a pasta de trabalho atualizada de volta no gráfico.

```python
# Após modificar o stream da pasta de trabalho (por exemplo, usando Aspose.Cells)
updated_workbook = chart_data.read_workbook_stream()

# Limpar referências de dados existentes.
chart_data.series.clear()
chart_data.categories.clear()

updated_workbook.seek(0)
chart_data.write_workbook_stream(updated_workbook)

chart.validate_chart_layout()
```

Limpar as coleções garante que a estrutura de dados do gráfico esteja consistente com a nova pasta de trabalho, permitindo que `validate_chart_layout` seja concluído sem erros.

## **Definir uma célula da pasta de trabalho como rótulo de dados do gráfico**

Às vezes, você precisa de rótulos de gráfico que venham diretamente de células na pasta de trabalho de dados subjacente. O Aspose.Slides permite vincular rótulos de dados a células específicas da pasta de trabalho, de modo que o texto do rótulo sempre reflita o valor da célula. O exemplo abaixo mostra como habilitar rótulos de valor-de-célula e apontar rótulos selecionados para células personalizadas na pasta de trabalho do gráfico.

1. Crie uma instância da classe [Presentation](https://docs.aspose.com/slides/pt/python-net/api-reference/aspose.slides/presentation/).
2. Obtenha uma referência ao slide pelo índice.
3. Adicione um gráfico de bolhas com dados de exemplo.
4. Acesse as séries do gráfico.
5. Use uma célula da pasta de trabalho como rótulo de dados.
6. Salve a apresentação.

O código Python a seguir mostra como definir uma célula da pasta de trabalho como rótulo de dados do gráfico:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Instanciar a classe Presentation que representa um arquivo de apresentação.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)

    series = chart.chart_data.series[0]

    series.labels.default_data_label_format.show_label_value_from_cell = True

    workbook = chart.chart_data.chart_data_workbook

    series.labels[0].value_from_cell = workbook.get_cell(0, "A10", "Label 0")
    series.labels[1].value_from_cell = workbook.get_cell(0, "A11", "Label 1")
    series.labels[2].value_from_cell = workbook.get_cell(0, "A12", "Label 2")

    presentation.save("chart.pptx", slides.export.SaveFormat.PPTX)
```

## **Gerenciar planilhas**

O código Python a seguir demonstra como usar a propriedade `worksheets` para acessar a coleção de planilhas:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 500)

    workbook = chart.chart_data.chart_data_workbook
    for i in range(len(workbook.worksheets)):
        print(workbook.worksheets[i].name)
```

## **Especificar o tipo de origem de dados**

O código Python a seguir mostra como especificar um tipo de origem de dados:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)

    series_name = chart.chart_data.series[0].name
    series_name.data_source_type = slides.charts.DataSourceType.STRING_LITERALS
    series_name.data = "LiteralString"

    series_name = chart.chart_data.series[1].name
    series_name.data = chart.chart_data.chart_data_workbook.get_cell(0, "B1", "NewCell")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Detectar formatos de pasta de trabalho incorporados não suportados**

O Aspose.Slides não oferece suporte ao formato de pasta de trabalho binária do Excel (.xlsb) que pode ser incorporado em alguns gráficos. Você pode usar a propriedade `embedded_workbook_type` em [ChartData](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdata/) juntamente com a enumeração [WorkbookType](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/workbooktype/) para detectar formatos não suportados e ignorar esses gráficos.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, charts.Chart):
            continue

        chart = shape
        chart_data = chart.chart_data

        if (chart_data.data_source_type == charts.ChartDataSourceType.INTERNAL_WORKBOOK and
                chart_data.embedded_workbook_type == charts.WorkbookType.WORKBOOK_BINARY_MACRO):
            # A pasta de trabalho incorporada está no formato .xlsb, que não é suportado.
            continue

        # Leia ou modifique os dados da pasta de trabalho do gráfico aqui.
```

## **Pastas de trabalho externas**

O Aspose.Slides oferece suporte ao uso de pastas de trabalho externas como fonte de dados para gráficos.

### **Definir pastas de trabalho externas**

Usando o método [ChartData.set_external_workbook](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdata/set_external_workbook/), você pode atribuir uma pasta de trabalho externa a um gráfico como sua fonte de dados. Esse método também pode atualizar o caminho para uma pasta de trabalho externa se ela tiver sido movida.

Embora não seja possível editar dados em pastas de trabalho armazenadas em locais ou recursos remotos, você ainda pode usá‑las como fontes de dados externas. Se você fornecer um caminho relativo para uma pasta de trabalho externa, ele será convertido automaticamente para um caminho completo.

O código Python a seguir mostra como definir uma pasta de trabalho externa:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    # Passe False para que apenas o caminho seja armazenado: a pasta de trabalho de destino não precisa existir ainda.
    chart.chart_data.set_external_workbook("external_workbook.xlsx", False)

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

O parâmetro `update_chart_data` do método [set_external_workbook](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdata/set_external_workbook/) especifica se a pasta de trabalho Excel será carregada.

- Quando `update_chart_data` está definido como `False`, apenas o caminho da pasta de trabalho é atualizado; os dados do gráfico não são carregados nem atualizados a partir da pasta de trabalho de destino. Use essa configuração quando a pasta de trabalho de destino não existir ou estiver indisponível.
- Quando `update_chart_data` está definido como `True` (padrão), os dados do gráfico são carregados e atualizados a partir da pasta de trabalho de destino. Se essa pasta de trabalho não puder ser aberta, uma exceção com a mensagem "External workbook is not available" será lançada.

### **Criar pastas de trabalho externas**

Usando os métodos [read_workbook_stream](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) e [set_external_workbook](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdata/set_external_workbook/), você pode criar uma pasta de trabalho externa do zero ou converter uma pasta de trabalho interna em uma externa.

Este código Python demonstra o processo de criação da pasta de trabalho externa:

```python
import pathlib
import aspose.slides as slides
import aspose.slides.charts as charts

workbook_path = "external_workbook.xlsx"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600)

    workbook_data = chart.chart_data.read_workbook_stream().read()

    with open(workbook_path, "wb") as file_stream:
        file_stream.write(workbook_data)

    full_path = str(pathlib.Path(workbook_path).resolve())
    chart.chart_data.set_external_workbook(full_path)

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

### **Obter o caminho da pasta de trabalho de fonte de dados externa para um gráfico**

Às vezes, os dados de um gráfico estão vinculados a uma pasta de trabalho Excel externa em vez dos dados incorporados da apresentação. Com o Aspose.Slides, você pode inspecionar a fonte de dados do gráfico e, se for uma pasta de trabalho externa, ler o caminho completo da pasta de trabalho.

1. Crie uma instância da classe [Presentation](https://docs.aspose.com/slides/pt/python-net/api-reference/aspose.slides/presentation/).
2. Obtenha uma referência ao slide pelo seu índice.
3. Obtenha uma referência ao shape do gráfico.
4. Obtenha a fonte ([ChartDataSourceType](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdatasourcetype/)) que representa a origem dos dados do gráfico.
5. Verifique se o tipo da fonte corresponde ao tipo de fonte de pasta de trabalho externa.

O código Python a seguir demonstra a operação:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart_with_external_workbook.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    source_type = chart.chart_data.data_source_type
    if source_type == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
        print(chart.chart_data.external_workbook_path)
```

### **Editar dados do gráfico**

Você pode editar dados em pastas de trabalho externas da mesma forma que edita dados em pastas de trabalho internas. Se uma pasta de trabalho externa não puder ser carregada, uma exceção será lançada.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Recuperar uma pasta de trabalho do cache do gráfico**

Se um gráfico usar uma pasta de trabalho externa que esteja ausente ou indisponível, o Aspose.Slides pode reconstruir a pasta de trabalho do gráfico a partir dos dados armazenados em cache na apresentação. Crie [LoadOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides/loadoptions/), então habilite [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/pt/python-net/aspose.slides.spreadsheetoptions/recover_workbook_from_chart_cache/) através de [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/pt/python-net/aspose.slides/loadoptions/spreadsheet_options/) antes de abrir a apresentação.

O exemplo Python a seguir abre uma apresentação cujo gráfico faz referência a uma pasta de trabalho externa indisponível e acessa os dados recuperados por meio de [Chart.chart_data](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chart/chart_data/) e [ChartData.chart_data_workbook](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    chart = presentation.slides[0].shapes[0]
    recovered_workbook = chart.chart_data.chart_data_workbook

    # Leia ou modifique os dados da pasta de trabalho recuperada aqui.
```

Se a pasta de trabalho externa estiver indisponível e a recuperação estiver desativada, o Aspose.Slides lançará uma exceção. Habilite a recuperação somente quando usar os dados de gráfico em cache for uma alternativa aceitável, pois o cache pode não conter alterações feitas na pasta de trabalho externa após a última atualização da apresentação.

## **FAQ**

**Posso determinar se um gráfico específico está vinculado a uma pasta de trabalho externa ou incorporada?**

Sim. Um gráfico possui um [data source type](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdata/data_source_type/) e um [path to an external workbook](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdata/external_workbook_path/); se a fonte for uma pasta de trabalho externa, você pode ler o caminho completo para garantir que um arquivo externo está sendo usado.

**Caminhos relativos para pastas de trabalho externas são suportados e como são armazenados?**

Sim. Se você especificar um caminho relativo, ele será convertido automaticamente em um caminho absoluto. Isso facilita a portabilidade do projeto; porém, a apresentação armazenará o caminho absoluto no arquivo PPTX.

**Posso usar pastas de trabalho localizadas em recursos/redes compartilhadas?**

Sim, essas pastas de trabalho podem ser usadas como fonte de dados externa. Contudo, editar pastas de trabalho remotas diretamente a partir do Aspose.Slides não é suportado—elas podem ser usadas apenas como fonte.

**O Aspose.Slides sobrescreve o XLSX externo ao salvar a apresentação?**

Somente se você editou os dados do gráfico. A apresentação armazena um [link to the external file](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdata/external_workbook_path/) e o usa para leitura, de modo que abrir e salvar a apresentação deixa a pasta de trabalho intacta. No entanto, valores alterados através dos dados do gráfico (veja [Edit Chart Data](#edit-chart-data) acima) são gravados de volta na pasta de trabalho externa quando a apresentação é salva—trabalhe em uma cópia se o original precisar permanecer inalterado.

**O que fazer se o arquivo externo estiver protegido por senha?**

O Aspose.Slides não aceita senha ao criar o vínculo. Uma abordagem comum é remover a proteção antecipadamente ou preparar uma cópia descriptografada (por exemplo, usando [Aspose.Cells](/cells/python-net/)) e vincular a essa cópia.

**Múltiplos gráficos podem referenciar a mesma pasta de trabalho externa?**

Sim. Cada gráfico armazena seu próprio vínculo. Se todos apontarem para o mesmo arquivo, a atualização desse arquivo será refletida em cada gráfico na próxima carga dos dados.