---
title: Gerenciar livros de trabalho de gráficos em apresentações com Python
linktitle: Livro de trabalho de gráfico
type: docs
weight: 70
url: /pt/python-net/chart-workbook/
keywords:
- livro de trabalho de gráfico
- dados do gráfico
- célula de livro de trabalho
- rótulo de dados
- planilha
- fonte de dados
- livro de trabalho externo
- dados externos
- cache de gráfico
- recuperação de livro de trabalho
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Descubra o Aspose.Slides para Python via .NET: gerencie facilmente livros de trabalho de gráficos em formatos PowerPoint e OpenDocument para simplificar os dados da sua apresentação."
---
## **Visão geral**

Este artigo explica como trabalhar com livros de trabalho de gráfico no Aspose.Slides. Ele mostra como ler e gravar dados de gráfico por meio de fluxos de livros de trabalho, usar células de livro de trabalho como rótulos de dados de gráfico, acessar coleções de planilhas e especificar o tipo de fonte de dados para os valores do gráfico.

Também aborda o trabalho com livros de trabalho externos como fontes de dados de gráfico. Os exemplos demonstram como criar e atribuir um livro de trabalho externo, recuperar o caminho de um livro de trabalho externo vinculado a um gráfico e editar os dados do gráfico quando o livro de trabalho está disponível.

## **Ler e gravar dados de gráfico a partir de um livro de trabalho**

O Aspose.Slides fornece métodos para ler e gravar livros de trabalho de dados de gráfico (que contêm dados de gráfico editados com o Aspose.Cells). **Observação:** os dados do gráfico devem estar organizados da mesma forma ou ter uma estrutura semelhante à fonte.

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

### **Validar layout do gráfico após modificação do livro de trabalho**

Quando você substitui um livro de trabalho incorporado por um modificado, o gráfico mantém suas coleções originais de séries e categorias. Essa incompatibilidade pode fazer com que [IChart.validate_chart_layout](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/ichart/validate_chart_layout/) falhe com um erro de índice fora do intervalo. Limpe as séries e categorias existentes antes de gravar o livro de trabalho atualizado de volta ao gráfico.

```python
# Depois de modificar o fluxo do livro de trabalho (por exemplo, usando Aspose.Cells)
updated_workbook = chart_data.read_workbook_stream()

# Limpar referências de dados existentes.
chart_data.series.clear()
chart_data.categories.clear()

updated_workbook.seek(0)
chart_data.write_workbook_stream(updated_workbook)

chart.validate_chart_layout()
```

Limpar as coleções garante que a estrutura dos dados do gráfico seja consistente com o novo livro de trabalho, permitindo que `validate_chart_layout` seja concluído sem erros.

## **Definir uma célula de livro de trabalho como rótulo de dados de gráfico**

Às vezes, você precisa de rótulos de gráfico que venham diretamente de células no livro de trabalho de dados subjacente. O Aspose.Slides permite vincular rótulos de dados a células específicas do livro de trabalho, de modo que o texto do rótulo reflita sempre o valor da célula. O exemplo abaixo mostra como habilitar rótulos de valor a partir de célula e apontar rótulos selecionados para células personalizadas no livro de trabalho do gráfico.

1. Crie uma instância da classe [Presentation](https://docs.aspose.com/slides/pt/python-net/api-reference/aspose.slides/presentation/).
1. Obtenha uma referência ao slide pelo índice.
1. Adicione um gráfico de bolhas com dados de exemplo.
1. Acesse as séries do gráfico.
1. Use uma célula de livro de trabalho como rótulo de dados.
1. Salve a apresentação.

O código Python a seguir mostra como definir uma célula de livro de trabalho como rótulo de dados de gráfico:

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

## **Especificar o tipo de fonte de dados**

O código Python a seguir mostra como especificar um tipo de fonte de dados:

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

## **Detectar formatos de livro de trabalho incorporado não suportados**

O Aspose.Slides não oferece suporte ao formato de livro de trabalho binário do Excel (.xlsb) que pode ser incorporado em alguns gráficos. Você pode usar a propriedade `embedded_workbook_type` em [ChartData](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdata/) juntamente com a enumeração [WorkbookType](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/workbooktype/) para detectar formatos não suportados e ignorar esses gráficos.

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
            # Livro de trabalho embutido está no formato .xlsb, que não é suportado.
            continue

        # Ler ou modificar os dados do livro de trabalho do gráfico aqui.
```

## **Livros de trabalho externos**

O Aspose.Slides oferece suporte ao uso de livros de trabalho externos como fonte de dados para gráficos.

### **Definir livros de trabalho externos**

Usando o método [ChartData.set_external_workbook](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdata/set_external_workbook/), você pode atribuir um livro de trabalho externo a um gráfico como sua fonte de dados. Esse método também pode atualizar o caminho para um livro de trabalho externo se ele tiver sido movido.

Embora você não possa editar dados em livros de trabalho armazenados em locais ou recursos remotos, ainda pode usar esses livros de trabalho como fontes de dados externas. Se você fornecer um caminho relativo para um livro de trabalho externo, ele será convertido automaticamente em um caminho completo.

O código Python a seguir mostra como definir um livro de trabalho externo:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    # Passe False para que apenas o caminho seja armazenado: o workbook de destino não precisa existir ainda.
    chart.chart_data.set_external_workbook("external_workbook.xlsx", False)

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

O parâmetro `update_chart_data` do método [set_external_workbook](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdata/set_external_workbook/) especifica se o livro de trabalho Excel será carregado.

- Quando `update_chart_data` for definido como `False`, somente o caminho do livro de trabalho será atualizado; os dados do gráfico não serão carregados nem atualizados a partir do livro de trabalho de destino. Use essa configuração quando o livro de trabalho de destino não existir ou estiver indisponível.
- Quando `update_chart_data` for definido como `True` (padrão), os dados do gráfico são carregados e atualizados a partir do livro de trabalho de destino. Se esse livro de trabalho não puder ser aberto, será lançada uma exceção com a mensagem "External workbook is not available".

### **Criar livros de trabalho externos**

Usando os métodos [read_workbook_stream](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) e [set_external_workbook](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdata/set_external_workbook/), você pode criar um livro de trabalho externo do zero ou converter um livro de trabalho interno em um externo.

Este código Python demonstra o processo de criação de um livro de trabalho externo:

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

### **Obter o caminho do livro de trabalho de fonte de dados externa de um gráfico**

Às vezes, os dados de um gráfico estão vinculados a um livro de trabalho Excel externo em vez dos dados incorporados da apresentação. Com o Aspose.Slides, você pode inspecionar a fonte de dados do gráfico e, se for um livro de trabalho externo, ler o caminho completo do livro de trabalho.

1. Crie uma instância da classe [Presentation](https://docs.aspose.com/slides/pt/python-net/api-reference/aspose.slides/presentation/).
1. Obtenha uma referência ao slide pelo índice.
1. Obtenha uma referência à forma de gráfico.
1. Obtenha a fonte ([ChartDataSourceType](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdatasourcetype/)) que representa a fonte de dados do gráfico.
1. Verifique se o tipo da fonte corresponde ao tipo de fonte de livro de trabalho externo.

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

### **Editar dados de gráfico**

Você pode editar dados em livros de trabalho externos da mesma forma que edita dados em livros de trabalho internos. Se um livro de trabalho externo não puder ser carregado, será lançada uma exceção.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Recuperar um livro de trabalho do cache do gráfico**

Se um gráfico usar um livro de trabalho externo que esteja ausente ou indisponível, o Aspose.Slides pode reconstruir o livro de trabalho do gráfico a partir dos dados armazenados em cache na apresentação. Crie [LoadOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides/loadoptions/), então habilite [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/pt/python-net/aspose.slides.spreadsheetoptions/recover_workbook_from_chart_cache/) por meio de [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/pt/python-net/aspose.slides/loadoptions/spreadsheet_options/) antes de abrir a apresentação.

O exemplo Python a seguir abre uma apresentação cujo gráfico faz referência a um livro de trabalho externo indisponível e acessa os dados recuperados por meio de [Chart.chart_data](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chart/chart_data/) e [ChartData.chart_data_workbook](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    chart = presentation.slides[0].shapes[0]
    recovered_workbook = chart.chart_data.chart_data_workbook

    # Ler ou modificar os dados do workbook recuperado aqui.
```

Se o livro de trabalho externo estiver indisponível e a recuperação estiver desativada, o Aspose.Slides lança uma exceção. Habilite a recuperação somente quando usar os dados de gráfico em cache for uma alternativa aceitável, pois o cache pode não conter alterações feitas no livro de trabalho externo depois que a apresentação foi atualizada pela última vez.

## **FAQ**

**Posso determinar se um gráfico específico está vinculado a um livro de trabalho externo ou incorporado?**

Sim. Um gráfico possui um [data source type](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdata/data_source_type/) e um [path to an external workbook](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdata/external_workbook_path/); se a fonte for um livro de trabalho externo, você pode ler o caminho completo para garantir que um arquivo externo está sendo usado.

**Caminhos relativos para livros de trabalho externos são suportados e como são armazenados?**

Sim. Se você especificar um caminho relativo, ele será convertido automaticamente em um caminho absoluto. Isso facilita a portabilidade do projeto; porém, esteja ciente de que a apresentação armazenará o caminho absoluto no arquivo PPTX.

**Posso usar livros de trabalho localizados em recursos ou compartilhamentos de rede?**

Sim, esses livros de trabalho podem ser usados como fonte de dados externa. Contudo, a edição direta de livros de trabalho remotos a partir do Aspose.Slides não é suportada — eles podem ser usados apenas como fonte.

**O Aspose.Slides sobrescreve o XLSX externo ao salvar a apresentação?**

Somente se você editou os dados do gráfico. A apresentação armazena um [link to the external file](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdata/external_workbook_path/) e o utiliza para ler os dados, de modo que abrir e salvar a apresentação deixa o livro de trabalho intacto. Entretanto, os valores alterados através dos dados do gráfico (veja [Edit Chart Data](#edit-chart-data) acima) são escritos de volta no livro de trabalho externo quando a apresentação é salva — trabalhe em uma cópia se o original precisar permanecer inalterado.

**O que devo fazer se o arquivo externo estiver protegido por senha?**

O Aspose.Slides não aceita senha ao criar o vínculo. Uma abordagem comum é remover a proteção antecipadamente ou preparar uma cópia descriptografada (por exemplo, usando [Aspose.Cells](/cells/python-net/)) e vincular a essa cópia.

**Múltiplos gráficos podem referenciar o mesmo livro de trabalho externo?**

Sim. Cada gráfico armazena seu próprio link. Se todos apontarem para o mesmo arquivo, a atualização desse arquivo será refletida em cada gráfico na próxima vez que os dados forem carregados.