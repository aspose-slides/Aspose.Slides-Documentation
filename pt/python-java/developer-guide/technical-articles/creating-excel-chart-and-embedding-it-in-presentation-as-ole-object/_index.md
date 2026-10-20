---
title: Criar gráficos do Excel e incorporá-los em apresentações como objetos OLE
type: docs
weight: 30
url: /pt/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Gráfico do Excel
- incorporar gráfico
- objeto OLE
- PowerPoint
- apresentação
- Python
- Java
- Aspose.Slides
description: "Criar um gráfico do Excel com Aspose.Cells para Python via Java e incorporar a pasta de trabalho em uma apresentação do PowerPoint com Aspose.Slides, incluindo uma pré-visualização do gráfico."
---
## **Visão geral**

Este artigo mostra como criar um gráfico de colunas do Excel com Aspose.Cells para Python via Java e incorporar sua pasta de trabalho em uma apresentação do PowerPoint com Aspose.Slides para Python via Java. A pasta de trabalho incorporada contém tanto os dados de origem quanto o gráfico. Uma visualização PNG separada exibe o gráfico no slide antes de o objeto OLE ser ativado.

O resultado é um objeto Excel incorporado, não um gráfico nativo do PowerPoint. Editar a pasta de trabalho via OLE requer um aplicativo de desktop que suporte ativação OLE e uma instalação compatível do Excel.

## **Pré-requisitos**

Instale os pacotes Python `aspose-cells` e `aspose-slides-java` e um runtime Java compatível. Importe ambos os pacotes antes de iniciar a JVM para que suas bibliotecas Java estejam disponíveis para o JPype. O Microsoft Office não é necessário para gerar a apresentação com essas bibliotecas.

Nenhum arquivo de entrada é necessário: o exemplo cria os dados e o gráfico na memória, depois grava `OutputChart.pptx` no diretório de trabalho atual. Aplique licenças para ambos os produtos ao executar fora do modo de avaliação.

## **Como a incorporação funciona**

1. Crie uma pasta de trabalho com uma planilha de dados e uma planilha de gráfico.  
2. Torne a planilha de gráfico ativa para que a pasta de trabalho abra no gráfico.  
3. Defina o intervalo de exibição OLE da pasta de trabalho e renderize o gráfico para PNG.  
4. Salve a pasta de trabalho como XLSX na memória e incorpore esses bytes em um slide.  
5. Atribua o PNG como pré-visualização do objeto OLE e salve a apresentação como PPTX.

O intervalo de exibição da pasta de trabalho e a moldura no slide têm papéis diferentes. [setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) recebe índices de linha e coluna de início/fim baseados em zero. [ChartCollection.add](https://reference.aspose.com/cells/python-java/asposecells.api/chartcollection/#add) recebe, em vez disso, a linha superior, coluna esquerda, linha inferior e coluna direita. O exemplo usa o índice de linha 55 e o índice de coluna 25 como limites inferiores direitos; esses valores são escolhas de layout, não o número de linhas ou colunas de dados.

A moldura do slide usa pontos. O exemplo a encaixa dentro do slide e a centraliza, preservando a proporção do PNG, em vez de esticar a pré-visualização para preencher o slide.

## **Criar e incorporar o gráfico**

O exemplo completo a seguir preenche `DataSheet` com quatro linhas e cinco colunas de valores. Cada linha se torna uma série do gráfico. `ChartSheet` é selecionada como a planilha ativa antes de salvar a pasta de trabalho.

A pasta de trabalho é salva explicitamente como XLSX, correspondendo à extensão `xlsx` passada para [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-java/aspose.slides/oleembeddeddatainfo/). Fluxos de byte-array Java mantêm a pasta de trabalho e a imagem na memória e fornecem os arrays de bytes necessários às APIs Java. O PNG é carregado diretamente de seus bytes sem uma conversão intermediária de bitmap. Atribuí‑lo por meio de [getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) substitui o placeholder padrão OLE.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ChartType, SheetType, ImageOrPrintOptions, ImageType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Images, OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

workbook = Workbook()
try:
    data_sheet = workbook.getWorksheets().get(0)
    data_sheet.setName("DataSheet")

    values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25],
    ]
    for row, row_values in enumerate(values):
        for column, value in enumerate(row_values):
            data_sheet.getCells().get(row, column).putValue(jpype.JInt(value))

    chart_sheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(chart_sheet_index)
    chart_sheet.setName("ChartSheet")

    last_chart_row = 55
    last_chart_column = 25
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, 0, last_chart_row, last_chart_column)
    chart = chart_sheet.getCharts().get(chart_index)
    for row in range(1, len(values) + 1):
        chart.getNSeries().add(f"DataSheet!A{row}:E{row}", False)

    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)
    workbook.getWorksheets().setOleSize(0, last_chart_row, 0, last_chart_column)

    # Renderizar a pré-visualização do gráfico e serializar a pasta de trabalho editável separadamente.
    image_options = ImageOrPrintOptions()
    image_options.setImageType(ImageType.PNG)
    chart_image_stream = ByteArrayOutputStream()
    chart.toImage(chart_image_stream, image_options)
    chart_image_bytes = chart_image_stream.toByteArray()

    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.XLSX)
    workbook_bytes = workbook_stream.toByteArray()

    chart_image = Images.fromData(chart_image_bytes)
    try:
        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)
            slide_width = presentation.getSlideSize().getSize().getWidth()
            slide_height = presentation.getSlideSize().getSize().getHeight()

            # Ajustar a pré-visualização dentro do slide sem alterar sua proporção.
            scale = min(slide_width / chart_image.getWidth(), slide_height / chart_image.getHeight())
            frame_width = chart_image.getWidth() * scale
            frame_height = chart_image.getHeight() * scale
            frame_x = (slide_width - frame_width) / 2
            frame_y = (slide_height - frame_height) / 2

            embedded_data = OleEmbeddedDataInfo(workbook_bytes, "xlsx")
            ole_frame = slide.getShapes().addOleObjectFrame(frame_x, frame_y, frame_width, frame_height, embedded_data)
            preview_image = presentation.getImages().addImage(chart_image)
            ole_frame.getSubstitutePictureFormat().getPicture().setImage(preview_image)

            presentation.save("OutputChart.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        chart_image.dispose()
finally:
    workbook.dispose()
```

## **Resultado esperado**

`OutputChart.pptx` contém um slide com uma pasta de trabalho Excel incorporada e uma pré-visualização do gráfico. A pasta de trabalho contém os dados originais e um gráfico de colunas com quatro séries. A pré-visualização está centralizada no slide e mantém suas proporções.

![Gráfico de colunas do Excel exibido como pré-visualização de uma pasta de trabalho incorporada](excel-chart-ole-preview.png)

Em um ambiente de desktop PowerPoint compatível com Excel disponível, clique duas vezes no objeto para ativar e editar a pasta de trabalho incorporada. A ativação e a edição dependem do suporte OLE e das configurações de segurança do aplicativo host.

## **FAQ**

**Por que uma imagem de pré-visualização é necessária?**

A pasta de trabalho incorporada e sua pré-visualização no slide são conteúdos separados. Forneça uma imagem do gráfico para que o slide mostre o gráfico em vez do placeholder padrão "EMBEDDED OLE OBJECT". Veja [Problema de pré-visualização de objeto ao adicionar OleObjectFrame](/slides/pt/python-java/object-preview-issue-when-adding-oleobjectframe/).

**A pré-visualização é atualizada automaticamente quando eu altero a pasta de trabalho no código?**

Considere a pré-visualização como uma captura. Ao atualizar os dados da pasta de trabalho programaticamente, regenere a imagem do gráfico e substitua a pré-visualização, assim como os dados da pasta de trabalho incorporada.

**Posso usar XLS em vez de XLSX?**

Sim. Salve a pasta de trabalho no formato XLS e use `xls` como a extensão dos dados incorporados. A extensão deve corresponder ao formato real da pasta de trabalho; alterar apenas a extensão não converte os dados.

**Por que o objeto pode mudar de tamanho após a ativação?**

O aplicativo host pode atualizar a apresentação do objeto OLE quando ele ativa a pasta de trabalho. Tanto o intervalo de exibição OLE da pasta de trabalho quanto as dimensões da moldura do slide são importantes. Veja [Solução funcional para redimensionamento de gráfico em PPTX](/slides/pt/python-java/working-solution-for-chart-resizing-in-pptx/).

## **Seções relacionadas**

- [Solução funcional para redimensionamento de gráfico em PPTX](/slides/pt/python-java/working-solution-for-chart-resizing-in-pptx/)
- [Problema de pré-visualização de objeto ao adicionar OleObjectFrame](/slides/pt/python-java/object-preview-issue-when-adding-oleobjectframe/)