---
title: Gerenciar OLE em Apresentações Usando Python
linktitle: Gerenciar OLE
type: docs
weight: 40
url: /pt/python-java/manage-ole/
keywords:
- objeto OLE
- Vinculação e Incorporação de Objetos
- adicionar OLE
- incorporar OLE
- adicionar objeto
- incorporar objeto
- adicionar arquivo
- incorporar arquivo
- objeto vinculado
- arquivo vinculado
- alterar OLE
- ícone OLE
- título OLE
- extrair OLE
- extrair objeto
- extrair arquivo
- PowerPoint
- apresentação
- Python
- Java
- Aspose.Slides
description: "Otimize o gerenciamento de objetos OLE em arquivos PowerPoint e OpenDocument com Aspose.Slides para Python via Java. Incorpore, atualize e exporte conteúdo OLE de forma perfeita."
---
## **Introdução**

{{% alert color="info" title="Note" %}}
OLE (Object Linking & Embedding) é uma tecnologia da Microsoft que permite que dados e objetos criados em um aplicativo sejam inseridos em outro aplicativo por meio de vinculação ou incorporação.
{{% /alert %}}

Considere um gráfico criado no MS Excel. O gráfico é então colocado dentro de um slide do PowerPoint. Esse gráfico do Excel é considerado um objeto OLE.

- Um objeto OLE pode aparecer como um ícone. Nesse caso, ao clicar duas vezes no ícone, o gráfico é aberto em seu aplicativo associado (Excel), ou é solicitado que você selecione um aplicativo para abrir ou editar o objeto.
- Um objeto OLE pode exibir seu conteúdo real, como o conteúdo de um gráfico. Nesse caso, o gráfico é ativado no PowerPoint, a interface do gráfico é carregada e você pode modificar os dados do gráfico dentro do PowerPoint.

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/pt/python-java/) permite inserir objetos OLE em slides como quadros de objeto OLE ([OleObjectFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/oleobjectframe/)).

## **Adicionar Quadros de Objeto OLE a Slides**

Assumindo que você já tenha criado um gráfico no Microsoft Excel e queira incorporá‑lo em um slide como um quadro de objeto OLE usando Aspose.Slides for Python via Java, você pode fazer assim:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) .
2. Obtenha a referência de um slide através de seu índice.
3. Leia o arquivo Excel como um array de bytes.
4. Adicione o [OleObjectFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/oleobjectframe/) ao slide contendo o array de bytes e outras informações sobre o objeto OLE.
5. Grave a apresentação modificada como um arquivo PPTX.

No exemplo abaixo, adicionamos um gráfico de um arquivo Excel a um slide como um quadro de objeto OLE usando Aspose.Slides for Python via Java.  
**Nota** que o construtor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/pt/python-java/aspose.slides/oleembeddeddatainfo/) recebe uma extensão de objeto incorporável como segundo parâmetro. Essa extensão permite que o PowerPoint interprete corretamente o tipo de arquivo e escolha o aplicativo correto para abrir esse objeto OLE.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    slide = presentation.getSlides().get_Item(0)

    # Preparar dados para o objeto OLE.
    file_data = Path("book.xlsx").read_bytes()
    file_data = jpype.JArray(jpype.JByte)(file_data)
    data_info = OleEmbeddedDataInfo(file_data, "xlsx")

    # Adicionar o quadro de objeto OLE ao slide.
    frame_width = jpype.JFloat(slide_size.getWidth())
    frame_height = jpype.JFloat(slide_size.getHeight())
    slide.getShapes().addOleObjectFrame(0, 0, frame_width, frame_height, data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Adicionar Quadros de Objeto OLE Vinculados**

Aspose.Slides for Python via Java permite adicionar um [OleObjectFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/oleobjectframe/) sem incorporar dados, mas apenas com um link para o arquivo.

Este código Python mostra como adicionar um [OleObjectFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/oleobjectframe/) com um arquivo Excel vinculado a um slide:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Adicionar um quadro de objeto OLE com um arquivo Excel vinculado.
    slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Acessar Quadros de Objeto OLE**

Se um objeto OLE já estiver incorporado em um slide, você pode encontrá‑lo ou acessá‑lo facilmente desta forma:

1. Carregue uma apresentação com o objeto OLE incorporado criando uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) .
2. Obtenha a referência do slide usando seu índice.
3. Acesse a forma [OleObjectFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/oleobjectframe/). Em nosso exemplo, usamos o PPTX criado anteriormente que possui apenas uma forma no primeiro slide. Em seguida, verificamos que o objeto era um [OleObjectFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/oleobjectframe/). Este era o quadro de objeto OLE desejado para ser acessado.
4. Depois de acessar o quadro de objeto OLE, você pode executar qualquer operação nele.

No exemplo abaixo, um quadro de objeto OLE (um objeto de gráfico Excel incorporado em um slide) e seus dados de arquivo são acessados.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        # Obter os dados do arquivo incorporado.
        file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()

        # Obter a extensão do arquivo incorporado.
        file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()

        # ...
finally:
    presentation.dispose()
```

### **Acessar Propriedades do Quadro de Objeto OLE Vinculado**

Aspose.Slides permite acessar as propriedades do quadro de objeto OLE vinculado.

Este código Python mostra como verificar se um objeto OLE está vinculado e então obter o caminho do arquivo vinculado:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.ppt")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        # Verificar se o objeto OLE está vinculado.
        if ole_frame.isObjectLink():
            # Imprimir o caminho completo do arquivo vinculado.
            print("OLE object frame is linked to: " + str(ole_frame.getLinkPathLong()))

            # Imprimir o caminho relativo do arquivo vinculado, se presente.
            # Apenas apresentações PPT podem conter o caminho relativo.
            relative_path = ole_frame.getLinkPathRelative()
            if relative_path is not None and not relative_path.isEmpty():
                print("OLE object frame relative path: " + str(relative_path))
finally:
    presentation.dispose()
```

## **Alterar Dados do Objeto OLE**

{{% alert color="info" title="Note" %}}
Nesta seção, o exemplo de código abaixo usa [Aspose.Cells for Python via Java](https://products.aspose.com/cells/python-java/).
{{% /alert %}}

Se um objeto OLE já estiver incorporado em um slide, você pode acessar facilmente esse objeto e modificar seus dados desta forma:

1. Carregue uma apresentação com o objeto OLE incorporado criando uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) .
2. Obtenha a referência do slide através do seu índice.
3. Acesse a forma do quadro de objeto OLE. Em nosso exemplo, usamos o PPTX criado anteriormente que possui uma forma no primeiro slide. Em seguida, verificamos que o objeto era um [OleObjectFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/oleobjectframe/). Este era o quadro de objeto OLE desejado para ser acessado.
4. Depois de acessar o quadro de objeto OLE, você pode executar qualquer operação nele.
5. Crie um objeto [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) e acesse os dados OLE.
6. Acesse a [Worksheet](https://reference.aspose.com/cells/python-java/asposecells.api/worksheet/) desejada e altere os dados.
7. Salve o [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) atualizado em um stream.
8. Altere os dados do objeto OLE a partir do stream.

No exemplo abaixo, um quadro de objeto OLE (um objeto de gráfico Excel incorporado em um slide) é acessado, e seus dados de arquivo são modificados para atualizar os dados do gráfico.

```python
import jpype
import asposeslides
import asposecells

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, OleObjectFrame, Presentation, SaveFormat
from asposecells.api import Workbook, OoxmlSaveOptions
from asposecells.api import SaveFormat as CellsSaveFormat
from java.io import ByteArrayInputStream, ByteArrayOutputStream

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()
        ole_stream = ByteArrayInputStream(file_data)

        # Ler os dados do objeto OLE como um objeto Workbook.
        workbook = Workbook(ole_stream)

        new_ole_stream = ByteArrayOutputStream()

        # Modificar os dados da pasta de trabalho.
        cells = workbook.getWorksheets().get(0).getCells()
        cells.get(0, 4).putValue("E")
        cells.get(1, 4).putValue(jpype.JInt(12))
        cells.get(2, 4).putValue(jpype.JInt(14))
        cells.get(3, 4).putValue(jpype.JInt(15))

        file_options = OoxmlSaveOptions(CellsSaveFormat.XLSX)
        workbook.save(new_ole_stream, file_options)

        # Alterar os dados do objeto do quadro OLE.
        new_file_data = new_ole_stream.toByteArray()
        new_data = OleEmbeddedDataInfo(new_file_data, ole_frame.getEmbeddedData().getEmbeddedFileExtension())
        ole_frame.setEmbeddedData(new_data)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Incorporar Outros Tipos de Arquivo em Slides**

Além de gráficos Excel, Aspose.Slides for Python via Java permite incorporar outros tipos de arquivos em slides. Por exemplo, você pode inserir arquivos HTML, PDF e ZIP como objetos. Quando um usuário clica duas vezes no objeto inserido, ele é aberto automaticamente no programa relevante, ou o usuário é solicitado a selecionar um programa apropriado para abri‑lo.

Este código Python mostra como incorporar HTML e ZIP em um slide:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    html_data = Path("sample.html").read_bytes()
    html_data = jpype.JArray(jpype.JByte)(html_data)
    html_data_info = OleEmbeddedDataInfo(html_data, "html")
    html_ole_frame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, html_data_info)
    html_ole_frame.setObjectIcon(True)

    zip_data = Path("sample.zip").read_bytes()
    zip_data = jpype.JArray(jpype.JByte)(zip_data)
    zip_data_info = OleEmbeddedDataInfo(zip_data, "zip")
    zip_ole_frame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zip_data_info)
    zip_ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Definir Tipos de Arquivo para Objetos Incorporados**

Ao trabalhar com apresentações, pode ser necessário substituir objetos OLE antigos por novos ou substituir um objeto OLE não suportado por um suportado. Aspose.Slides for Python via Java permite definir o tipo de arquivo para um objeto incorporado, permitindo atualizar os dados do quadro OLE ou sua extensão.

Este código Python mostra como definir o tipo de arquivo para um objeto OLE incorporado como `zip`:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()
    file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()

    print("Current embedded file extension is: " + str(file_extension))

    # Alterar o tipo de arquivo para ZIP.
    data_info = OleEmbeddedDataInfo(file_data, "zip")
    ole_frame.setEmbeddedData(data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Definir Imagens de Ícone e Títulos para Objetos Incorporados**

Após incorporar um objeto OLE, uma pré‑visualização composta por uma imagem de ícone é adicionada automaticamente. Essa pré‑visualização é o que os usuários veem antes de acessar ou abrir o objeto OLE. Se desejar usar uma imagem e texto específicos como elementos na pré‑visualização, você pode definir a imagem de ícone e o título usando Aspose.Slides for Python via Java.

Este código Python mostra como definir a imagem de ícone e o título para um objeto incorporado:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    # Adicionar uma imagem aos recursos da apresentação.
    image_data = Path("image.png").read_bytes()
    image_data = jpype.JArray(jpype.JByte)(image_data)
    ole_image = presentation.getImages().addImage(image_data)

    # Definir um título e a imagem para a visualização OLE.
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Impedir que um Quadro de Objeto OLE Seja Redimensionado e Reposicionado**

Depois de adicionar um objeto OLE vinculado a um slide de apresentação, ao abrir a apresentação no PowerPoint, pode aparecer uma mensagem solicitando a atualização dos links. Clicar no botão "Update Links" pode alterar o tamanho e a posição do quadro de objeto OLE porque o PowerPoint atualiza os dados do objeto OLE vinculado e atualiza a pré‑visualização do objeto. Para impedir que o PowerPoint solicite a atualização dos dados do objeto, defina o método [setUpdateAutomatic](https://reference.aspose.com/slides/pt/python-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) da classe [OleObjectFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/oleobjectframe/) como `False`:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    ole_frame.setUpdateAutomatic(False)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Extrair Arquivos Incorporados**

Aspose.Slides for Python via Java permite extrair os arquivos incorporados em slides como objetos OLE desta forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) contendo os objetos OLE que você pretende extrair.
2. Percorra todas as formas na apresentação e acesse as formas [OleObjectFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/oleobjectframe/).
3. Acesse os dados dos arquivos incorporados a partir dos quadros de objeto OLE e grave‑os no disco.

Este código Python mostra como extrair arquivos incorporados em um slide como objetos OLE:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)

        if isinstance(shape, OleObjectFrame):
            ole_frame = shape

            file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()
            file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()

            file_path = Path(f"OLE_object_{index}.{str(file_extension).lstrip('.')}")
            file_path.write_bytes(bytes(file_data))
finally:
    presentation.dispose()
```

## **FAQ**

**O conteúdo OLE será renderizado ao exportar slides para PDF/imagens?**  
O que está visível no slide é renderizado — o ícone/imagem substituta (pré‑visualização). O conteúdo OLE “ao vivo” não é executado durante a renderização. Se necessário, defina sua própria imagem de pré‑visualização para garantir a aparência esperada no PDF exportado.

**Como posso bloquear um objeto OLE em um slide para que os usuários não possam movê‑lo/edita‑lo no PowerPoint?**  
Bloqueie a forma: Aspose.Slides fornece [bloqueios em nível de forma](/slides/pt/python-java/applying-protection-to-presentation/). Isso não é criptografia, mas impede efetivamente edições e movimentos acidentais.

**Por que um objeto Excel vinculado “salta” ou altera o tamanho ao abrir a apresentação?**  
O PowerPoint pode atualizar a pré‑visualização do OLE vinculado. Para uma aparência estável, siga as práticas da [Solução Funcional para Redimensionamento de Planilhas](/slides/pt/python-java/working-solution-for-worksheet-resizing/) — ajuste o quadro ao intervalo ou dimensione o intervalo para um quadro fixo e defina uma imagem substituta apropriada.

**Os caminhos relativos para objetos OLE vinculados serão preservados no formato PPTX?**  
No PPTX, as informações de “caminho relativo” não estão disponíveis — apenas o caminho completo. Caminhos relativos são encontrados no formato PPT mais antigo. Para portabilidade, prefira caminhos absolutos confiáveis/URIs acessíveis ou incorporação.