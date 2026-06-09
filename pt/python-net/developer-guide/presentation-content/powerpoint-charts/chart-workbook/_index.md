---
title: Gerenciar workbooks de gráficos em apresentações com Python
linktitle: Workbook de Gráfico
type: docs
weight: 70
url: /pt/python-net/chart-workbook/
keywords:
- workbook de gráfico
- dados de gráfico
- célula de workbook
- rótulo de dados
- planilha
- fonte de dados
- workbook externo
- dados externos
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Descubra o Aspose.Slides para Python via .NET: gerencie facilmente workbooks de gráficos em formatos PowerPoint e OpenDocument para simplificar os dados da sua apresentação."
---
## **Visão geral**

Este artigo explica como trabalhar com pastas de trabalho de gráficos no Aspose.Slides. Ele mostra como ler e gravar dados de gráfico por meio de streams de pastas de trabalho, usar células da pasta de trabalho como rótulos de dados do gráfico, acessar coleções de planilhas e especificar o tipo de origem de dados para os valores do gráfico.

Também aborda o trabalho com pastas de trabalho externas como fontes de dados de gráficos. Os exemplos demonstram como criar e atribuir uma pasta de trabalho externa, recuperar o caminho de uma pasta de trabalho externa vinculada a um gráfico e editar os dados do gráfico quando a pasta de trabalho está disponível.

## **Ler e gravar dados de gráfico a partir de uma pasta de trabalho**

Aspose.Slides fornece métodos para ler e gravar pastas de trabalho de dados de gráfico (que contêm dados de gráfico editados com Aspose.Cells). **Nota:** Os dados do gráfico devem estar organizados da mesma forma ou ter uma estrutura semelhante à origem.

The following Python code demonstrates a sample operation:

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

## **Definir uma célula de Workbook como rótulo de dados de gráfico**

Às vezes é necessário que os rótulos do gráfico venham diretamente das células na pasta de trabalho de dados subjacente. Aspose.Slides permite vincular rótulos de dados a células específicas da pasta de trabalho, de modo que o texto do rótulo reflita sempre o valor da célula. O exemplo abaixo mostra como habilitar rótulos de valor a partir de célula e apontar rótulos selecionados para células personalizadas na pasta de trabalho do gráfico.

1. Crie uma instância da classe [Presentation](https://docs.aspose.com/slides/pt/python-net/api-reference/aspose.slides/presentation/).
2. Obtenha uma referência ao slide pelo índice.
3. Adicione um gráfico de bolhas com dados de exemplo.
4. Acesse a série do gráfico.
5. Use uma célula de workbook como rótulo de dados.
6. Salve a apresentação.

The following Python code shows how to set a workbook cell as a chart data label:

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

## **Detectar formatos de workbook incorporados não suportados**

Aspose.Slides não oferece suporte ao formato de workbook binário do Excel (.xlsb) que pode ser incorporado em alguns gráficos. Você pode usar a propriedade `embedded_workbook_type` em [ChartData](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdata/) juntamente com a enumeração [WorkbookType](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/workbooktype/) para detectar formatos não suportados e ignorar esses gráficos.

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
            # O workbook incorporado está no formato .xlsb, que não é suportado.
            continue

        # Leia ou modifique os dados do workbook do gráfico aqui.
```

## **Workbooks externos**

Aspose.Slides oferece suporte ao uso de workbooks externos como fonte de dados para gráficos.

### **Definir workbooks externos**

Usando o método [ChartData.set_external_workbook](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdata/set_external_workbook/), você pode atribuir um workbook externo a um gráfico como sua fonte de dados. Esse método também pode atualizar o caminho para um workbook externo se ele tiver sido movido.

Embora não seja possível editar dados em workbooks armazenados em locais remotos ou recursos, ainda é possível usar esses workbooks como fontes de dados externas. Se você fornecer um caminho relativo para um workbook externo, ele será convertido automaticamente em um caminho completo.

The following Python code shows how to set an external workbook:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    chart.chart_data.set_external_workbook("external_workbook.xlsx")

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

O parâmetro `update_chart_data` do método [set_external_workbook](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdata/set_external_workbook/) especifica se o workbook do Excel será carregado.

- Quando `update_chart_data` está definido como `False`, apenas o caminho do workbook é atualizado; os dados do gráfico não são carregados ou atualizados a partir do workbook de destino. Use essa configuração quando o workbook de destino não existir ou estiver indisponível.
- Quando `update_chart_data` está definido como `True`, os dados do gráfico são carregados e atualizados a partir do workbook de destino.

### **Criar workbooks externos**

Usando os métodos [read_workbook_stream](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) e [set_external_workbook](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdata/set_external_workbook/), você pode criar um workbook externo do zero ou converter um workbook interno em um externo.

This Python code demonstrates the external workbook creation process:

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

### **Obter o caminho do workbook da fonte de dados externa para um gráfico**

Às vezes os dados de um gráfico estão vinculados a um workbook Excel externo em vez dos dados incorporados da apresentação. Com Aspose.Slides, você pode inspecionar a fonte de dados do gráfico e, se for um workbook externo, ler o caminho completo do workbook.

1. Crie uma instância da classe [Presentation](https://docs.aspose.com/slides/pt/python-net/api-reference/aspose.slides/presentation/).
2. Obtenha uma referência ao slide pelo seu índice.
3. Obtenha uma referência ao shape do gráfico.
4. Obtenha a fonte ([ChartDataSourceType](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdatasourcetype/)) que representa a fonte de dados do gráfico.
5. Verifique se o tipo de fonte corresponde ao tipo de fonte de dados de workbook externo.

The following Python code demonstrates the operation:

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

Você pode editar dados em workbooks externos da mesma forma que edita dados em workbooks internos. Se um workbook externo não puder ser carregado, uma exceção será lançada.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Perguntas frequentes**

**Posso determinar se um gráfico específico está vinculado a um workbook externo ou incorporado?**

Sim. Um gráfico possui um [data source type](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdata/data_source_type/) e um [path to an external workbook](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdata/external_workbook_path/); se a fonte for um workbook externo, você pode ler o caminho completo para garantir que um arquivo externo está sendo usado.

**Caminhos relativos para workbooks externos são suportados, e como eles são armazenados?**

Sim. Se você especificar um caminho relativo, ele será convertido automaticamente em um caminho absoluto. Isso é conveniente para portabilidade do projeto; entretanto, esteja ciente de que a apresentação armazenará o caminho absoluto no arquivo PPTX.

**Posso usar workbooks localizados em recursos/compartilhamentos de rede?**

Sim, esses workbooks podem ser usados como fonte de dados externa. Porém, a edição de workbooks remotos diretamente pelo Aspose.Slides não é suportada — eles podem ser usados apenas como origem.

**O Aspose.Slides sobrescreve o XLSX externo ao salvar a apresentação?**

Não. A apresentação armazena um [link to the external file](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdata/external_workbook_path/) e o utiliza para ler os dados. O arquivo externo em si não é modificado quando a apresentação é salva.

**O que devo fazer se o arquivo externo estiver protegido por senha?**

Aspose.Slides não aceita senha ao vincular. Uma abordagem comum é remover a proteção antecipadamente ou preparar uma cópia descriptografada (por exemplo, usando [Aspose.Cells](/cells/python-net/)) e vincular a essa cópia.

**Vários gráficos podem referenciar o mesmo workbook externo?**

Sim. Cada gráfico armazena seu próprio link. Se todos apontarem para o mesmo arquivo, a atualização desse arquivo será refletida em cada gráfico na próxima vez que os dados forem carregados.