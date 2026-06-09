---
title: Integrar Dados do Excel em Apresentações PowerPoint
linktitle: Integração Excel
type: docs
weight: 330
url: /pt/python-net/excel-integration/
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
- Aspose.Slides
description: "Ler dados de pastas de trabalho do Excel no Aspose.Slides usando a API ExcelDataWorkbook. Carregar planilhas e células e usar os valores para gerar apresentações PowerPoint orientadas por dados."
---
## **Introdução**

As apresentações do PowerPoint são uma forma poderosa de exibir e comunicar informações. Elas são frequentemente usadas em conjunto com pastas de trabalho do Excel, onde o Excel serve como uma excelente fonte de dados estruturados e o PowerPoint se destaca ao visualizar esses dados para o público.

Existem muitos cenários práticos em que combinar Excel e PowerPoint é essencial: mala direta, preenchimento de tabelas de dados, geração de um slide por registro de dados (geração em lote de slides), criação de materiais de treinamento e consolidação de vários relatórios do Excel em uma única apresentação, entre outros.

Até agora, implementar esses recursos com a API Aspose.Slides exigia depender de soluções de terceiros como Aspose.Cells. Embora essas ferramentas sejam robustas, podem ser excessivamente complexas e caras para usuários que precisam apenas de funcionalidade básica de integração de dados.

## **Como funciona**

Para facilitar o trabalho com dados do Excel e torná‑lo mais enxuto, a Aspose.Slides introduziu novas classes para ler dados de pastas de trabalho do Excel e importar conteúdo para uma apresentação. Esse recurso abre novas possibilidades poderosas para usuários da API que desejam usar o Excel como fonte de dados em seus fluxos de trabalho de apresentação.

A nova funcionalidade foi projetada para acesso genérico a dados e não está integrada ao Modelo de Objeto de Documento da Apresentação (DOM). Isso significa que *não permite editar ou salvar arquivos do Excel* — seu único objetivo é abrir pastas de trabalho e navegar por seu conteúdo para recuperar valores de células.

No núcleo desse recurso está a nova classe [ExcelDataWorkbook](https://reference.aspose.com/slides/pt/python-net/aspose.slides.excel/exceldataworkbook/). Essa classe permite carregar uma pasta de trabalho do Excel a partir de um arquivo local ou de um fluxo. Após o carregamento, ela oferece várias sobrecargas do método [get_cell](https://reference.aspose.com/slides/pt/python-net/aspose.slides.excel/exceldataworkbook/get_cell/), que podem ser usadas para recuperar células específicas pela sua posição (por exemplo, índices de linha e coluna ou intervalos nomeados).

Cada chamada ao [get_cell](https://reference.aspose.com/slides/pt/python-net/aspose.slides.excel/exceldataworkbook/get_cell/) devolve uma instância da classe [ExcelDataCell](https://reference.aspose.com/slides/pt/python-net/aspose.slides.excel/exceldatacell/). Esse objeto representa uma única célula na pasta de trabalho do Excel e fornece acesso ao seu valor de forma simples e intuitiva.

#### **Importar um gráfico do Excel**

O próximo passo para ampliar a funcionalidade é a classe [ExcelWorkbookImporter](https://reference.aspose.com/slides/pt/python-net/aspose.slides.importing/excelworkbookimporter/). Essa classe utilitária fornece funcionalidades para importar conteúdo de uma pasta de trabalho do Excel para uma apresentação. Ela contém várias sobrecargas do método [add_chart_from_workbook](https://reference.aspose.com/slides/pt/python-net/aspose.slides.importing/excelworkbookimporter/add_chart_from_workbook/), que ajudam a recuperar o gráfico selecionado da pasta de trabalho do Excel especificada e adicioná‑lo ao final da coleção de formas fornecida nas coordenadas especificadas.

Resumindo, trata‑se de uma API leve e direta para leitura de dados do Excel — exatamente o que muitos desenvolvedores precisam sem a sobrecarga de uma biblioteca completa de processamento de planilhas.

## **Vamos codar**

### **Exemplo de cenário de Mala Direta**

No exemplo a seguir, implementaremos um cenário simples de Mala Direta gerando várias apresentações com base nos dados armazenados em uma pasta de trabalho do Excel.

Para começar, precisamos de duas coisas:
1. Uma pasta de trabalho do Excel contendo os dados

![Exemplo de dados do Excel](example1_image0.png)

2. Modelo de apresentação do PowerPoint

![Exemplo de modelo do PowerPoint](example1_image1.png)

```py
import aspose.slides as slides

# Carregar a pasta de trabalho do Excel com os dados dos funcionários.
workbook = slides.excel.ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# Carregar o modelo de apresentação.
with slides.Presentation("PresentationTemplate.pptx") as template_presentation:

    # Percorrer as linhas do Excel (excluindo o cabeçalho na linha 0).
    for row_index in range(1, 5):

        # Criar uma nova apresentação para cada registro de funcionário.
        with slides.Presentation() as employee_presentation:

            # Remover o slide em branco padrão.
            employee_presentation.slides.remove_at(0)

            # Clonar o slide do modelo na nova apresentação.
            slide = employee_presentation.slides.add_clone(template_presentation.slides[0])

            # Obter parágrafos da forma alvo (presume que o índice da forma 1 está sendo usado).
            paragraphs = slide.shapes[1].text_frame.paragraphs

            # Substituir os marcadores de posição pelos dados do Excel.
            employee_name = workbook.get_cell(worksheet_index, row_index, 0).value
            name_portion = paragraphs[0].portions[0]
            name_portion.text = name_portion.text.replace("{{EmployeeName}}", employee_name)

            department = workbook.get_cell(worksheet_index, row_index, 1).value
            department_portion = paragraphs[1].portions[0]
            department_portion.text = department_portion.text.replace("{{Department}}", department)

            years_of_service = str(workbook.get_cell(worksheet_index, row_index, 2).value)
            years_portion = paragraphs[2].portions[0]
            years_portion.text = years_portion.text.replace("{{YearsOfService}}", years_of_service)

            # Salvar a apresentação personalizada em um arquivo separado.
            employee_presentation.save(f"{employee_name} Report.pptx", slides.export.SaveFormat.PPTX)
```

![Resultado](example1_image2.png)

### **Exemplo de Tabela do Excel**

No segundo exemplo, simplesmente copiamos dados de uma tabela do Excel e os exibimos em um slide do PowerPoint de forma mais visualmente atraente.

Neste exemplo, reutilizamos a mesma pasta de trabalho do Excel do primeiro exemplo, que contém uma tabela simples de funcionários.

```py
# Carregar a pasta de trabalho do Excel contendo os dados dos funcionários.
workbook = slides.excel.ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# Criar uma nova apresentação PowerPoint.
with slides.Presentation() as presentation:

    # Adicionar uma forma de tabela ao primeiro slide.
    table = presentation.slides[0].shapes.add_table(
        50, 200,
        [200, 200, 200],
        [30, 30, 30, 30, 30]
    )

    # Preencher a tabela do PowerPoint com os dados da pasta de trabalho do Excel.
    for row_index in range(0, 5):
        for column_index in range(0, 3):
            cell_value = str(workbook.get_cell(worksheet_index, row_index, column_index).value)
            table.columns[column_index][row_index].text_frame.text = cell_value

    # Salvar a apresentação resultante em um arquivo.
    presentation.save("Table.pptx", slides.export.SaveFormat.PPTX)
```

![Resultado](example2_image0.png)

### **Exemplo de Importação de um Gráfico do Excel**

Neste exemplo, importamos um gráfico da primeira planilha da pasta de trabalho do Excel usada no exemplo anterior. O gráfico será vinculado à pasta de trabalho externa na apresentação resultante.

Primeiro, adicionamos um gráfico de pizza à pasta de trabalho do Excel com base na tabela de funcionários.

![Exemplo de gráfico do Excel](example3_image0.png)

```py
# Criar uma nova apresentação PowerPoint.
with slides.Presentation() as presentation:
    # Obter a coleção de formas do primeiro slide.
    shapes = presentation.slides[0].shapes

    # Importar o gráfico chamado "Chart 1" da primeira planilha da pasta de trabalho e adicioná-lo à coleção de formas.
    slides.importing.ExcelWorkbookImporter.add_chart_from_workbook(
        shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", False)

    # Salvar a apresentação resultante em um arquivo.
    presentation.save("Chart.pptx", slides.export.SaveFormat.PPTX)
```

![Resultado](example3_image1.png)

### **Exemplo de Importação de Todos os Gráficos do Excel**

Imagine que você possui uma pasta de trabalho do Excel cheia de gráficos e precisa importá‑los todos para uma apresentação. Cada gráfico deve ser colocado em um novo slide.

O código a seguir itera por todas as planilhas no arquivo Excel de origem, extrai os gráficos de cada planilha e adiciona cada gráfico a um slide separado usando um layout de slide em branco. Na apresentação resultante, apenas os dados do gráfico serão incorporados, não a pasta de trabalho inteira.

```py
# Carregar a pasta de trabalho do Excel contendo os dados dos funcionários.
workbook = slides.excel.ExcelDataWorkbook("ExcelWithCharts.xlsx")

# Criar uma nova apresentação PowerPoint.
with slides.Presentation() as presentation:
    # Recuperar o layout de slide em branco.
    blank_layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    # Obter os nomes de todas as planilhas contidas na pasta de trabalho do Excel.
    worksheet_names = workbook.get_worksheet_names()

    for name in worksheet_names:
        # Recuperar um dicionário que mapeia índices de gráficos para nomes de gráficos da planilha.
        worksheet_charts = workbook.get_charts_from_worksheet(name)
        
        for chart in worksheet_charts:
            # Adicionar um novo slide usando o layout em branco.
            slide = presentation.slides.add_empty_slide(blank_layout)

            # Importar o gráfico especificado da pasta de trabalho do Excel para a coleção de formas do slide.
            slides.importing.ExcelWorkbookImporter.add_chart_from_workbook(
                slide.shapes, 10, 10, workbook, name, chart.key, False)

    # Salvar a apresentação resultante em um arquivo.
    presentation.save("Charts.pptx", slides.export.SaveFormat.PPTX)
```

## **Resumo**

Esse mecanismo, disponível diretamente no Aspose.Slides, combina o trabalho com dados do Excel e apresentações em um único local. Ele permite criar slides com gráficos visuais e dados apresentados como tabelas do Excel — sem bibliotecas adicionais ou integrações complexas.