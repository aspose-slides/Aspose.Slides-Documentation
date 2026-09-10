---
title: Gerenciar pastas de trabalho de gráficos em apresentações usando Python via Java
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
description: "Descubra Aspose.Slides para Python via Java: gerencie facilmente pastas de trabalho de gráficos em formatos PowerPoint e OpenDocument para simplificar os dados da sua apresentação."
---
## **Visão geral**

Este artigo explica como trabalhar com pastas de trabalho de gráficos no Aspose.Slides. Ele demonstra como ler e gravar dados de gráfico por meio de fluxos de pasta de trabalho, usar células da pasta de trabalho como rótulos de dados do gráfico, acessar coleções de planilhas e especificar o tipo de fonte de dados para os valores do gráfico.

Também aborda o uso de pastas de trabalho externas como fontes de dados de gráficos. Os exemplos mostram como criar e atribuir uma pasta de trabalho externa, recuperar o caminho de uma pasta de trabalho externa vinculada a um gráfico e editar os dados do gráfico quando a pasta de trabalho está disponível.

## **Ler e gravar dados de gráfico de uma pasta de trabalho**
Aspose.Slides fornece os métodos [readWorkbookStream](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdata/#readWorkbookStream) e [writeWorkbookStream](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdata/#writeWorkbookStream) que permitem ler e gravar pastas de trabalho de dados de gráfico (contendo dados de gráfico editados com Aspose.Cells). **Nota** que os dados do gráfico precisam estar organizados da mesma maneira ou ter uma estrutura semelhante à fonte.

Este código Python demonstra uma operação de exemplo:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()
    workbook_data = chart_data.readWorkbookStream()
    chart_data.getSeries().clear()
    chart_data.getCategories().clear()
    chart_data.writeWorkbookStream(workbook_data)
finally:
    presentation.dispose()
```

### **Validar o layout do gráfico após a modificação da pasta de trabalho**

Ao substituir uma pasta de trabalho incorporada por uma modificada, o gráfico mantém suas coleções originais de séries e categorias. Essa inconsistência pode fazer com que [Chart.validateChartLayout](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chart/#validateChartLayout) lance uma `ArgumentOutOfRangeException` (parâmetro: index). Para evitar a exceção, limpe as séries e categorias existentes **antes** de gravar a pasta de trabalho atualizada de volta ao gráfico.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

from pathlib import Path

# Leia a pasta de trabalho após modificá‑la (por exemplo, usando Aspose.Cells).
updated_workbook = Path("updatedWorkbook.xlsx").read_bytes()

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()

    # Limpe as referências de dados existentes.
    chart_data.getSeries().clear()
    chart_data.getCategories().clear()
    chart_data.writeWorkbookStream(jpype.JArray(jpype.JByte)(updated_workbook))
    chart.validateChartLayout()
finally:
    presentation.dispose()
```

Limpar as coleções garante que a estrutura dos dados do gráfico esteja alinhada com a nova pasta de trabalho, permitindo que [validateChartLayout](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chart/#validateChartLayout) seja concluído sem erros.

## **Definir uma célula da pasta de trabalho como rótulo de dados do gráfico**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
1. Obtenha a referência de um slide por seu índice.
1. Adicione um gráfico de Bolhas com alguns dados.
1. Acesse a série do gráfico.
1. Defina a célula da pasta de trabalho como um rótulo de dados.
1. Salve a apresentação.

Este código Python mostra como definir uma célula da pasta de trabalho como rótulo de dados do gráfico:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart2.pptx")
try:
    label_values = ["Label 0 cell value", "Label 1 cell value", "Label 2 cell value"]
    slide = presentation.getSlides().get_Item(0)
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

## **Gerenciar planilhas**

Este código Python demonstra uma operação onde o método [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdataworkbook/#getWorksheets) é usado para acessar uma coleção de planilhas:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 500)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(workbook.getWorksheets().size()):
        print(workbook.getWorksheets().get_Item(i).getName())
finally:
    presentation.dispose()
```

## **Especificar o tipo de fonte de dados**

Este código Python mostra como especificar um tipo para uma fonte de dados:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, True)
    series_name = chart.getChartData().getSeries().get_Item(0).getName()
    series_name.setDataSourceType(DataSourceType.StringLiterals)
    series_name.setData("LiteralString")
    series_name = chart.getChartData().getSeries().get_Item(1).getName()
    name_cell = chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell")
    series_name.setData(name_cell)
    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Detectar formatos de pasta de trabalho incorporada não suportados**

Aspose.Slides não oferece suporte ao formato de pasta de trabalho binária do Excel (.xlsb) que pode ser incorporado em alguns gráficos. Você pode usar o método [getEmbeddedWorkbookType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) em [ChartData](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdata/) juntamente com a enumeração [WorkbookType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/workbooktype/) para detectar formatos não suportados e ignorar esses gráficos.

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
        if chart_data.getDataSourceType() == ChartDataSourceType.InternalWorkbook and chart_data.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro:
            # Pasta de trabalho incorporada está no formato .xlsb, que não é suportado.
            continue
        # Leia ou modifique os dados da pasta de trabalho do gráfico aqui.
finally:
    presentation.dispose()
```

### **Criar uma pasta de trabalho externa**

Usando os métodos [readWorkbookStream](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdata/#readWorkbookStream) e [setExternalWorkbook](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdata/#setExternalWorkbook), você pode criar uma pasta de trabalho externa do zero ou tornar uma pasta de trabalho interna externa.

Este código Python demonstra o processo de criação da pasta de trabalho externa:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    workbook_path = "externalWorkbook1.xlsx"
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600)
    workbook_data = chart.getChartData().readWorkbookStream()
    Path(workbook_path).write_bytes(bytes(workbook_data))
    chart.getChartData().setExternalWorkbook(workbook_path)
    presentation.save("externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Definir uma pasta de trabalho externa**

Usando o método [setExternalWorkbook](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdata/#setExternalWorkbook), você pode atribuir uma pasta de trabalho externa a um gráfico como sua fonte de dados. Esse método também pode ser usado para atualizar o caminho da pasta de trabalho externa (caso ela tenha sido movida).

Embora não seja possível editar os dados em pastas de trabalho armazenadas em locais remotos ou recursos, você ainda pode usá‑las como fonte de dados externa. Se for fornecido um caminho relativo para uma pasta de trabalho externa, ele será convertido automaticamente em um caminho completo.

Este código Python mostra como definir uma pasta de trabalho externa:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, False)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("externalWorkbook.xlsx")
    workbook = chart_data.getChartDataWorkbook()
    series_name_cell = workbook.getCell(0, "B1")
    series = chart_data.getSeries().add(series_name_cell, ChartType.Pie)
    for row in range(2, 5):
        value_cell = workbook.getCell(0, f"B{row}")
        series.getDataPoints().addDataPointForPieSeries(value_cell)
    for row in range(2, 5):
        category_cell = workbook.getCell(0, f"A{row}")
        chart_data.getCategories().add(category_cell)
    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O segundo parâmetro (`bool`) do método [setExternalWorkbook](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdata/#setExternalWorkbook) é usado para especificar se uma pasta de trabalho do Excel será carregada ou não.

* Quando seu valor é definido como `False`, apenas o caminho da pasta de trabalho é atualizado — os dados do gráfico não serão carregados nem atualizados a partir da pasta de trabalho de destino. Use essa configuração quando a pasta de trabalho de destino não existir ou não estiver disponível.  
* Quando seu valor é definido como `True`, os dados do gráfico são atualizados a partir da pasta de trabalho de destino.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("http://path/doesnt/exists", False)
    presentation.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Obter o caminho da pasta de trabalho fonte de dados externa de um gráfico**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
1. Obtenha a referência de um slide por seu índice.
1. Crie um objeto para a forma de gráfico.
1. Crie um objeto para o tipo de fonte ([ChartDataSourceType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdatasourcetype/)) que representa a fonte de dados do gráfico.
1. Especifique a condição relevante com base no tipo de fonte ser o mesmo que o tipo de fonte de dados da pasta de trabalho externa.

Este código Python demonstra a operação:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartDataSourceType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(1)
    chart = slide.getShapes().get_Item(0)
    source_type = chart.getChartData().getDataSourceType()
    if source_type == ChartDataSourceType.ExternalWorkbook:
        path = chart.getChartData().getExternalWorkbookPath()
    presentation.save("result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Editar dados do gráfico**

Você pode editar os dados em pastas de trabalho externas da mesma forma que altera o conteúdo de pastas de trabalho internas. Quando uma pasta de trabalho externa não pode ser carregada, uma exceção é lançada.

Este código Python é uma implementação do processo descrito:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()
    chart_data.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(jpype.JInt(100))
    presentation.save("presentation_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Recuperar uma pasta de trabalho do cache do gráfico**

Se um gráfico usar uma pasta de trabalho externa que esteja ausente ou indisponível, Aspose.Slides pode reconstruir a pasta de trabalho do gráfico a partir dos dados em cache na apresentação. Crie um objeto [LoadOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/loadoptions/), configure‑o com [SpreadsheetOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/spreadsheetoptions/), e chame [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/pt/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) com `True` antes de abrir a apresentação.

O exemplo Python a seguir abre uma apresentação cujo gráfico referencia uma pasta de trabalho externa indisponível e acessa os dados recuperados por meio de [Chart.getChartData](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chart/#getChartData) e [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdata/#getChartDataWorkbook):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SpreadsheetOptions

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setRecoverWorkbookFromChartCache(True)
load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    recovered_workbook = chart.getChartData().getChartDataWorkbook()

    # Leia ou modifique os dados da pasta de trabalho recuperada aqui.
finally:
    presentation.dispose()
```

Se a pasta de trabalho externa estiver indisponível e a recuperação estiver desativada, Aspose.Slides lança uma exceção. Ative a recuperação somente quando o uso dos dados de gráfico em cache for uma alternativa aceitável, pois o cache pode não conter alterações feitas na pasta de trabalho externa após a última atualização da apresentação.

## **FAQ**

**Posso determinar se um gráfico específico está vinculado a uma pasta de trabalho externa ou incorporada?**

Sim. Um gráfico possui um [data source type](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdata/#getDataSourceType) e um [caminho para uma pasta de trabalho externa](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdata/#getExternalWorkbookPath); se a fonte for uma pasta de trabalho externa, você pode ler o caminho completo para garantir que um arquivo externo está sendo usado.

**Caminhos relativos para pastas de trabalho externas são suportados e como são armazenados?**

Sim. Se você especificar um caminho relativo, ele será convertido automaticamente em um caminho absoluto. Isso facilita a portabilidade do projeto; porém, esteja ciente de que a apresentação armazenará o caminho absoluto no arquivo PPTX.

**Posso usar pastas de trabalho localizadas em recursos ou compartilhamentos de rede?**

Sim, essas pastas de trabalho podem ser usadas como fonte de dados externa. Contudo, a edição direta de pastas de trabalho remotas a partir do Aspose.Slides não é suportada — elas podem ser usadas apenas como fonte.

**O Aspose.Slides sobrescreve o XLSX externo ao salvar a apresentação?**

Não. A apresentação armazena um [link para o arquivo externo](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) e o utiliza para leitura dos dados. O arquivo externo em si não é modificado ao salvar a apresentação.

**O que fazer se o arquivo externo estiver protegido por senha?**

Aspose.Slides não aceita senha ao criar o vínculo. Uma abordagem comum é remover a proteção antecipadamente ou preparar uma cópia descriptografada (por exemplo, usando [Aspose.Cells](/cells/python-java/)) e vincular a essa cópia.

**Vários gráficos podem referenciar a mesma pasta de trabalho externa?**

Sim. Cada gráfico armazena seu próprio link. Se todos apontarem para o mesmo arquivo, a atualização desse arquivo será refletida em cada gráfico na próxima carga dos dados.