---
title: Solução Funcional para Redimensionamento de Gráficos em PPTX
type: docs
weight: 40
url: /pt/python-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- redimensionamento de gráfico
- gráfico do Excel
- objeto OLE
- incorporar gráfico
- PowerPoint
- OpenDocument
- apresentação
- Python
- Java
- Aspose.Slides
description: "Corrija o redimensionamento inesperado de gráficos em PPTX ao usar objetos OLE do Excel incorporados com Aspose.Slides for Python via Java. Aprenda dois métodos com código para manter os tamanhos consistentes."
---
## **Contexto**

Foi observado que gráficos do Excel incorporados como objetos OLE em uma apresentação do PowerPoint por meio dos componentes Aspose são redimensionados para uma escala não especificada após sua primeira ativação. Esse comportamento causa uma diferença visual perceptível na apresentação entre os estados antes e depois da ativação do gráfico. A equipe da Aspose investigou o problema em detalhes e encontrou uma solução. Este artigo descreve as causas do problema e a correção correspondente.

No [artigo anterior](/slides/pt/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), explicamos como criar um gráfico do Excel com Aspose.Cells for Python via Java e incorporá‑lo em uma apresentação do PowerPoint usando Aspose.Slides for Python via Java. Para resolver o [problema de visualização do objeto](/slides/pt/python-java/object-preview-issue-when-adding-oleobjectframe/), atribuímos a imagem do gráfico ao quadro do objeto OLE do gráfico. Na apresentação de saída, ao clicar duas vezes no quadro do objeto OLE que exibe a imagem do gráfico, o gráfico do Excel é ativado. Os usuários finais podem fazer quaisquer alterações desejadas na pasta de trabalho do Excel subjacente e, em seguida, retornar ao slide correspondente clicando fora da pasta de trabalho ativada. O tamanho do quadro do objeto OLE muda quando o usuário volta ao slide, e o fator de redimensionamento varia dependendo dos tamanhos originais tanto do quadro do objeto OLE quanto da pasta de trabalho do Excel incorporada.

## **Causa do Redimensionamento**

Como a pasta de trabalho do Excel possui seu próprio tamanho de janela, ela tenta manter seu tamanho original na primeira ativação. O quadro do objeto OLE, porém, tem seu próprio tamanho. Segundo a Microsoft, quando a pasta de trabalho do Excel é ativada, Excel e PowerPoint negociam o tamanho e mantêm as proporções corretas como parte do processo de incorporação. Dependendo das diferenças entre o tamanho da janela do Excel e o tamanho ou posição do quadro do objeto OLE, ocorre o redimensionamento.

## **Solução Funcional**

Existem dois cenários possíveis para criar apresentações do PowerPoint usando Aspose.Slides for Python via Java.

**Cenário 1:** Criar uma apresentação com base em um modelo existente.

**Cenário 2:** Criar uma apresentação do zero.

A solução que fornecemos aqui se aplica a ambos os cenários. O fundamento de todas as abordagens de solução é o mesmo: **o tamanho da janela do objeto OLE incorporado deve corresponder ao quadro do objeto OLE no slide do PowerPoint**. Agora discutiremos as duas abordagens para essa solução.

## **Primeira Abordagem**

Nesta abordagem, aprenderemos como definir o tamanho da janela da pasta de trabalho do Excel incorporada de modo que ele corresponda ao tamanho do quadro do objeto OLE no slide do PowerPoint.

**Cenário 1**

Suponha que tenhamos definido um modelo e queiramos criar apresentações com base nele. Imagine que exista uma forma no índice 2 do modelo onde desejamos colocar um quadro OLE contendo uma pasta de trabalho do Excel incorporada. Nesse cenário, o tamanho do quadro do objeto OLE é pré‑definido — corresponde ao tamanho da forma no índice 2 do modelo. Tudo o que precisamos fazer é definir o tamanho da janela da pasta de trabalho igual ao tamanho dessa forma. O trecho de código a seguir cumpre esse propósito:

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Carregue a pasta de trabalho do Excel que contém o gráfico.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(2)

    # Defina o tamanho da janela da pasta de trabalho em polegadas (PowerPoint usa 72 pontos por polegada).
    workbook.getSettings().setWindowWidthInch(shape.getWidth() / 72.0)
    workbook.getSettings().setWindowHeightInch(shape.getHeight() / 72.0)

    # Salve a pasta de trabalho em um fluxo de memória.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Crie um quadro de objeto OLE com os dados do Excel incorporados.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), data_info)
finally:
    presentation.dispose()
```

**Cenário 2**

Vamos supor que queiramos criar uma apresentação do zero e incluir um quadro OLE de qualquer tamanho com uma pasta de trabalho do Excel incorporada. No trecho de código a seguir, criamos um quadro OLE com 4 polegadas de altura e 9,5 polegadas de largura em x = 0,5 polegadas e y = 1 polegada no slide. Em seguida, definimos a janela da pasta de trabalho do Excel para o mesmo tamanho — 4 polegadas de altura e 9,5 polegadas de largura.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Carregue a pasta de trabalho do Excel que contém o gráfico.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    desired_height = 288  # 4 polegadas (4 * 72).
    desired_width = 684  # 9.5 polegadas (9.5 * 72).

    # Defina o tamanho do gráfico com uma janela.
    chart.setSizeWithWindow(True)

    # Defina o tamanho da janela da pasta de trabalho em polegadas (PowerPoint usa 72 pontos por polegada).
    workbook.getSettings().setWindowWidthInch(desired_width / 72.0)
    workbook.getSettings().setWindowHeightInch(desired_height / 72.0)

    # Salve a pasta de trabalho em um fluxo de memória.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Crie um quadro de objeto OLE com os dados do Excel incorporados.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(36.0, 72.0, desired_width, desired_height, data_info)
finally:
    presentation.dispose()
```

## **Segunda Abordagem**

Nesta abordagem, aprenderemos como definir o tamanho do gráfico na pasta de trabalho do Excel incorporada para que ele corresponda ao tamanho do quadro do objeto OLE no slide do PowerPoint. Essa abordagem é útil quando o tamanho do gráfico é conhecido antecipadamente e nunca mudará.

**Cenário 1**

Suponha que tenhamos definido um modelo e queiramos criar apresentações com base nele. Imagine que exista uma forma no índice 2 do modelo onde pretendemos colocar um quadro OLE contendo uma pasta de trabalho do Excel incorporada. Nesse cenário, o tamanho do quadro OLE é pré‑definido — corresponde ao tamanho da forma no índice 2 do modelo. Tudo o que precisamos fazer é definir o tamanho do gráfico na pasta de trabalho igual ao tamanho dessa forma. O trecho de código a seguir cumpre esse propósito:

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Carregue a pasta de trabalho do Excel que contém o gráfico.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(2)

    # Defina o tamanho do gráfico sem uma janela.
    chart.setSizeWithWindow(False)

    # Defina o tamanho do gráfico em pixels (Excel usa 96 pixels por polegada).
    chart.getChartObject().setWidth(int((shape.getWidth() / 72.0) * 96.0))
    chart.getChartObject().setHeight(int((shape.getHeight() / 72.0) * 96.0))

    # Defina o tamanho de impressão do gráfico.
    chart.setPrintSize(PrintSizeType.CUSTOM)

    # Salve a pasta de trabalho em um fluxo de memória.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Crie um quadro de objeto OLE com os dados do Excel incorporados.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), data_info)
finally:
    presentation.dispose()
```

**Cenário 2**:

Suponha que queiramos criar uma apresentação do zero e incluir um quadro OLE de qualquer tamanho com uma pasta de trabalho do Excel incorporada. No trecho de código a seguir, criamos um quadro OLE com altura de 4 polegadas e largura de 9,5 polegadas no slide em x = 0,5 polegadas e y = 1 polegada. Também definimos o tamanho correspondente do gráfico para as mesmas dimensões: altura de 4 polegadas e largura de 9,5 polegadas.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Carregue a pasta de trabalho do Excel que contém o gráfico.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    desired_height = 288  # 4 polegadas (4 * 72).
    desired_width = 684  # 9.5 polegadas (9.5 * 72).

    # Defina o tamanho do gráfico sem uma janela.
    chart.setSizeWithWindow(False)

    # Defina o tamanho do gráfico em pixels (Excel usa 96 pixels por polegada).
    chart.getChartObject().setWidth(int((desired_width / 72.0) * 96.0))
    chart.getChartObject().setHeight(int((desired_height / 72.0) * 96.0))

    # Salve a pasta de trabalho em um fluxo de memória.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Crie um quadro de objeto OLE com os dados do Excel incorporados.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(36.0, 72.0, desired_width, desired_height, data_info)
finally:
    presentation.dispose()
```

## **Conclusão**

Existem duas abordagens para corrigir o problema de redimensionamento do gráfico. A escolha da abordagem depende dos requisitos e do caso de uso. Ambas as abordagens funcionam da mesma forma, seja quando as apresentações são criadas a partir de um modelo ou do zero. Além disso, não há limite para o tamanho do quadro do objeto OLE nessa solução.

## **Perguntas Frequentes**

**Por que o gráfico do Excel incorporado muda de tamanho após ser ativado no PowerPoint?**

Isso ocorre porque o Excel tenta restaurar o tamanho original da janela na primeira ativação, enquanto o quadro do objeto OLE no PowerPoint possui dimensões próprias. PowerPoint e Excel negociam o tamanho para manter a proporção, o que pode causar o redimensionamento.

**É possível evitar esse problema de redimensionamento totalmente?**

Sim. Ao fazer com que o tamanho da janela da pasta de trabalho do Excel ou o tamanho do gráfico correspondam ao tamanho do quadro OLE antes da incorporação, você pode manter os tamanhos dos gráficos consistentes.

**Qual abordagem devo adotar, ajustar o tamanho da janela da pasta de trabalho ou ajustar o tamanho do gráfico?**

Use **Abordagem 1 (tamanho da janela)** se desejar manter a proporção da pasta de trabalho e possivelmente permitir redimensionamento futuro.  
Use **Abordagem 2 (tamanho do gráfico)** se as dimensões do gráfico forem fixas e não mudarem após a incorporação.

**Esses métodos funcionam tanto com apresentações baseadas em modelo quanto com apresentações novas?**

Sim. Ambas as abordagens funcionam da mesma forma para apresentações criadas a partir de modelos e a partir do zero.

**Existe um limite para o tamanho do quadro do objeto OLE?**

Não. Você pode definir o quadro OLE em qualquer tamanho, contanto que ele seja dimensionado adequadamente em relação ao tamanho da pasta de trabalho ou do gráfico.

**Posso usar esses métodos com gráficos criados em outros programas de planilha?**

Os exemplos são projetados para gráficos do Excel criados com Aspose.Cells, mas os princípios se aplicam a outros programas de planilha compatíveis com OLE, desde que suportem opções de dimensionamento semelhantes.

## **Seções Relacionadas**

- [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/pt/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)