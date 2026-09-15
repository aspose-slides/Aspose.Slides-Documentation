---
title: Integrar Dados do Excel em Apresentações PowerPoint
linktitle: Integração com Excel
type: docs
weight: 330
url: /pt/python-java/excel-integration/
keywords:
- Excel
- pasta de trabalho
- ler Excel
- integrar Excel
- fonte de dados
- mala direta
- importar tabela
- Excel para PowerPoint
- PowerPoint
- apresentação
- Python
- Java
- Aspose.Slides
description: "Leia dados de pastas de trabalho Excel no Aspose.Slides para Python via Java usando a API ExcelDataWorkbook. Carregue planilhas e células e use os valores para gerar apresentações PowerPoint orientadas a dados."
---
## **Introdução**

Apresentações do PowerPoint são uma maneira poderosa de exibir e comunicar informações. Elas são frequentemente usadas em conjunto com pastas de trabalho do Excel, onde o Excel serve como uma excelente fonte de dados estruturados e o PowerPoint se destaca ao visualizar esses dados para o público.

Existem muitos cenários práticos onde combinar Excel e PowerPoint é essencial: mala direta, preenchimento de tabelas de dados, geração de um slide por registro de dados (geração em lote de slides), criação de materiais de treinamento e consolidação de vários relatórios do Excel em uma única apresentação, entre outros.

Até agora, a implementação desses recursos com a API Aspose.Slides exigia depender de soluções de terceiros como Aspose.Cells. Embora essas ferramentas sejam robustas, podem ser excessivamente complexas e caras para usuários que precisam apenas de funcionalidades básicas de integração de dados.

## **Como funciona**

Para facilitar e tornar mais eficiente o trabalho com dados do Excel, o Aspose.Slides introduziu novas classes para ler dados de pastas de trabalho do Excel e importar conteúdo para uma apresentação. Esse recurso abre poderosas novas possibilidades para os usuários da API que desejam usar o Excel como fonte de dados em seus fluxos de trabalho de apresentação.

A nova funcionalidade é projetada para acesso a dados de uso geral e não está integrada ao Presentation Document Object Model (DOM). Isso significa *não permite editar ou salvar arquivos do Excel* — seu único objetivo é abrir pastas de trabalho e navegar em seu conteúdo para recuperar dados de células.

No núcleo desse recurso está a nova classe [ExcelDataWorkbook](https://reference.aspose.com/slides/pt/python-java/aspose.slides/exceldataworkbook/). Essa classe permite carregar uma pasta de trabalho do Excel a partir de um arquivo local ou de um stream. Após o carregamento, ela fornece várias sobrecargas do método [ExcelDataWorkbook.getCell](https://reference.aspose.com/slides/pt/python-java/aspose.slides/exceldataworkbook/#getCell), que podem ser usadas para recuperar células específicas pela sua posição (por exemplo, índices de linha e coluna ou intervalos nomeados).

Cada chamada a [ExcelDataWorkbook.getCell](https://reference.aspose.com/slides/pt/python-java/aspose.slides/exceldataworkbook/#getCell) retorna um objeto [ExcelDataCell](https://reference.aspose.com/slides/pt/python-java/aspose.slides/exceldatacell/). Esse objeto representa uma única célula na pasta de trabalho Excel e fornece acesso ao seu valor de maneira simples e intuitiva.

#### **Importar um gráfico do Excel**

O próximo passo para ampliar a funcionalidade é a classe [ExcelWorkbookImporter](https://reference.aspose.com/slides/pt/python-java/aspose.slides/excelworkbookimporter/). Essa classe utilitária fornece funcionalidade para importar conteúdo de uma pasta de trabalho do Excel para uma apresentação. Ela contém várias sobrecargas do método [ExcelWorkbookImporter.addChartFromWorkbook](https://reference.aspose.com/slides/pt/python-java/aspose.slides/excelworkbookimporter/#addChartFromWorkbook), que ajudam a recuperar o gráfico selecionado da pasta de trabalho Excel especificada e adicioná-lo ao final da coleção de formas fornecida nas coordenadas especificadas.

#### **Importar uma tabela do Excel**

A classe [ExcelWorkbookImporter](https://reference.aspose.com/slides/pt/python-java/aspose.slides/excelworkbookimporter/) também contém várias sobrecargas do método [ExcelWorkbookImporter.addTableFromWorkbook](https://reference.aspose.com/slides/pt/python-java/aspose.slides/excelworkbookimporter/#addTableFromWorkbook). Esses métodos permitem importar um intervalo de células especificado de uma planilha especificada e adicioná-lo como tabela ao final da coleção de formas fornecida nas coordenadas especificadas.

Resumindo, trata‑se de uma API leve e direta para ler dados do Excel — exatamente o que muitos desenvolvedores precisam sem a sobrecarga de uma biblioteca completa de processamento de planilhas.

## **Vamos codificar**

### **Exemplo de cenário de mala direta**

No exemplo a seguir, implementaremos um cenário simples de mala direta gerando várias apresentações com base nos dados armazenados em uma pasta de trabalho do Excel.

Para começar, precisamos de duas coisas:

1. Uma pasta de trabalho do Excel contendo os dados

![Exemplo de dados do Excel](example1_image0.png)

2. Um modelo de apresentação PowerPoint

![Exemplo de modelo PowerPoint](example1_image1.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, Presentation, SaveFormat

# Carregar a pasta de trabalho Excel com dados dos funcionários.
workbook = ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# Carregar o modelo de apresentação.
template_presentation = Presentation("PresentationTemplate.pptx")

try:
    # Percorrer as linhas do Excel (excluindo o cabeçalho na linha 0).
    for row_index in range(1, 5):

        # Criar uma apresentação para cada registro de funcionário.
        employee_presentation = Presentation()

        try:
            # Remover o slide em branco padrão.
            employee_presentation.getSlides().removeAt(0)

            # Clonar o slide modelo na apresentação.
            slide = employee_presentation.getSlides().addClone(template_presentation.getSlides().get_Item(0))

            # Obter parágrafos da forma de destino (presume que o índice da forma 1 é usado).
            paragraphs = slide.getShapes().get_Item(1).getTextFrame().getParagraphs()

            # Substituir os marcadores de posição pelos dados do Excel.
            employee_name = str(workbook.getCell(worksheet_index, row_index, 0).getValue())
            name_portion = paragraphs.get_Item(0).getPortions().get_Item(0)
            name_portion.setText(str(name_portion.getText()).replace("{{EmployeeName}}", employee_name))

            department = str(workbook.getCell(worksheet_index, row_index, 1).getValue())
            department_portion = paragraphs.get_Item(1).getPortions().get_Item(0)
            department_portion.setText(str(department_portion.getText()).replace("{{Department}}", department))

            years_of_service = str(workbook.getCell(worksheet_index, row_index, 2).getValue())
            years_portion = paragraphs.get_Item(2).getPortions().get_Item(0)
            years_portion.setText(str(years_portion.getText()).replace("{{YearsOfService}}", years_of_service))

            # Salvar a apresentação personalizada em um arquivo separado.
            employee_presentation.save(f"{employee_name} Report.pptx", SaveFormat.Pptx)
        finally:
            employee_presentation.dispose()
finally:
    template_presentation.dispose()
```

![Resultado](example1_image2.png)

### **Exemplo de tabela do Excel**

No segundo exemplo, copiamos simplesmente os dados de uma tabela do Excel e os exibimos em um slide do PowerPoint em um formato visualmente mais atraente.

Neste exemplo, reutilizamos a mesma pasta de trabalho do Excel do primeiro exemplo, que contém uma tabela simples de funcionários.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, Presentation, SaveFormat

# Carregar a pasta de trabalho Excel contendo os dados dos funcionários.
workbook = ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# Criar uma apresentação PowerPoint.
presentation = Presentation()

try:
    # Adicionar uma forma de tabela ao primeiro slide.
    column_widths = jpype.JArray(jpype.JDouble)([200, 200, 200])
    row_heights = jpype.JArray(jpype.JDouble)([30, 30, 30, 30, 30])
    table = presentation.getSlides().get_Item(0).getShapes().addTable(50, 200, column_widths, row_heights)

    # Preencher a tabela PowerPoint com dados da pasta de trabalho Excel.
    for row_index in range(5):
        for column_index in range(3):
            cell_value = str(workbook.getCell(worksheet_index, row_index, column_index).getValue())
            table.getColumns().get_Item(column_index).get_Item(row_index).getTextFrame().setText(cell_value)

    # Salvar a apresentação resultante em um arquivo.
    presentation.save("Table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Resultado](example2_image0.png)

### **Exemplo de importação de gráfico do Excel**

Neste exemplo, importamos um gráfico da primeira planilha da pasta de trabalho do Excel usada no exemplo anterior. O gráfico será vinculado à pasta de trabalho externa na apresentação resultante.

Primeiro, adicionamos um gráfico de pizza à pasta de trabalho do Excel com base na tabela de funcionários.

![Exemplo de gráfico do Excel](example3_image0.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelWorkbookImporter, Presentation, SaveFormat

# Criar uma apresentação PowerPoint.
presentation = Presentation()
try:
    # Obter a coleção de formas do primeiro slide.
    shapes = presentation.getSlides().get_Item(0).getShapes()

    # Importar o gráfico chamado "Chart 1" da primeira planilha da pasta de trabalho e adicioná-lo à coleção de formas.
    ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", False)

    # Salvar a apresentação resultante em um arquivo.
    presentation.save("Chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Resultado](example3_image1.png)

### **Exemplo de importação de todos os gráficos do Excel**

Imagine que você tem uma pasta de trabalho do Excel repleta de gráficos e precisa importá-los todos para uma apresentação. Cada gráfico deve ser colocado em um novo slide.

O código a seguir itera por todas as planilhas do arquivo Excel de origem, extrai os gráficos de cada planilha e adiciona cada gráfico a um slide separado usando um layout de slide em branco. Na apresentação resultante, somente os dados do gráfico serão incorporados, não a pasta de trabalho inteira.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, ExcelWorkbookImporter, Presentation, SaveFormat, SlideLayoutType

# Carregar a pasta de trabalho Excel contendo os dados dos funcionários.
workbook = ExcelDataWorkbook("ExcelWithCharts.xlsx")

# Criar uma apresentação PowerPoint.
presentation = Presentation()
try:
    # Recuperar o layout de slide em branco.
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    # Remover o slide padrão para que o resultado contenha um slide por gráfico.
    presentation.getSlides().removeAt(0)

    # Obter os nomes de todas as planilhas contidas na pasta de trabalho Excel.
    worksheet_names = workbook.getWorksheetNames()

    for name in worksheet_names:
        # Recuperar um mapa que associa índices de gráficos a nomes de gráficos para a planilha.
        worksheet_charts = workbook.getChartsFromWorksheet(name)

        for chart in worksheet_charts:
            # Adicionar um slide usando o layout em branco.
            slide = presentation.getSlides().addEmptySlide(blank_layout)

            # Importar o gráfico especificado da pasta de trabalho Excel para a coleção de formas do slide.
            ExcelWorkbookImporter.addChartFromWorkbook(slide.getShapes(), 10, 10, workbook, name, chart.getKey(), False)

    # Salvar a apresentação resultante em um arquivo.
    presentation.save("Charts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Exemplo de importação de tabela do Excel**

Neste exemplo, importamos uma tabela formatada de uma planilha Excel diretamente para uma apresentação PowerPoint.

A planilha Excel de origem contém uma tabela formatada com dados de funcionários:

![Exemplo de tabela do Excel](example4_image0.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelWorkbookImporter, Presentation, SaveFormat

# Criar uma apresentação PowerPoint.
presentation = Presentation()
try:
    # Obter o primeiro slide e sua coleção de formas.
    slide = presentation.getSlides().get_Item(0)
    shapes = slide.getShapes()

    # Importar a tabela da primeira planilha da pasta de trabalho e adicioná-la à coleção de formas.
    ExcelWorkbookImporter.addTableFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "A1:C5")

    # Salvar a apresentação resultante em um arquivo.
    presentation.save("FormattedTable.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Resultado](example4_image1.png)

## **Resumo**

Esse mecanismo, disponível diretamente no Aspose.Slides, combina o trabalho com dados do Excel e apresentações em um único local. Ele permite criar slides com gráficos visuais e dados apresentados como tabelas do Excel — sem quaisquer bibliotecas adicionais ou integrações complexas.