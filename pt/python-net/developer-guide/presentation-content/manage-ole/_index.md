---
title: Gerenciar OLE em Apresentações usando Python
linktitle: Gerenciar OLE
type: docs
weight: 40
url: /pt/python-net/manage-ole/
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
- Aspose.Slides
description: "Otimize o gerenciamento de objetos OLE em arquivos PowerPoint e OpenDocument com Aspose.Slides for Python via .NET. Incorpore, atualize e exporte conteúdo OLE de forma contínua."
---
## **Introdução**

{{% alert title="Info" color="info" %}}

**OLE (Object Linking & Embedding)** é uma tecnologia da Microsoft que permite que dados e objetos criados em um aplicativo sejam vinculados ou incorporados em outro.

{{% /alert %}}

Por exemplo, um gráfico criado no Microsoft Excel e colocado em um slide do PowerPoint é um objeto OLE.

- Um objeto OLE pode aparecer como um ícone. Clicar duas vezes no ícone abre o objeto no aplicativo associado (por exemplo, Excel) ou solicita que você escolha um aplicativo para abrir ou editar.
- Um objeto OLE pode exibir seu conteúdo (por exemplo, um gráfico). Nesse caso, o PowerPoint ativa o objeto incorporado, carrega a interface do gráfico e permite que você edite os dados do gráfico dentro do PowerPoint.

Aspose.Slides for Python permite inserir objetos OLE em slides como quadros de objeto OLE ([OleObjectFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/oleobjectframe/)).

## **Adicionar objetos OLE a slides**

Se você já criou um gráfico no Microsoft Excel e deseja incorporá‑lo em um slide como um quadro de objeto OLE usando Aspose.Slides for Python, siga estas etapas:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
1. Obtenha uma referência ao slide pelo seu índice.
1. Leia o arquivo Excel em um array de bytes.
1. Adicione um [OleObjectFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/oleobjectframe/) ao slide, fornecendo o array de bytes e outros detalhes do objeto OLE.
1. Salve a apresentação modificada como um arquivo PPTX.

No exemplo abaixo, um gráfico de um arquivo Excel é incorporado em um slide como um [OleObjectFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/oleobjectframe/).

**Observação:** O construtor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/pt/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/) recebe a extensão de arquivo do objeto incorporável como seu segundo parâmetro. O PowerPoint usa essa extensão para identificar o tipo de arquivo e selecionar o aplicativo apropriado para abrir o objeto OLE.

```py
with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[0]

    # Prepare os dados para o objeto OLE.
    with open("book.xlsx", "rb") as file_stream:
        file_data = file_stream.read()
        data_info = slides.dom.ole.OleEmbeddedDataInfo(file_data, "xlsx")

    # Adicione um quadro de objeto OLE ao slide.
    ole_frame = slide.shapes.add_ole_object_frame(0, 0, slide_size.width, slide_size.height, data_info)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Adicionar objetos OLE vinculados**

Aspose.Slides for Python permite adicionar um [OleObjectFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/oleobjectframe/) que vincula a um arquivo em vez de incorporar seus dados.

O exemplo Python a seguir mostra como adicionar um [OleObjectFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/oleobjectframe/) vinculado a um arquivo Excel em um slide:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Adicione um quadro de objeto OLE com um arquivo Excel vinculado.
    slide.shapes.add_ole_object_frame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Acessar objetos OLE**

Se um objeto OLE já estiver incorporado em um slide, você pode acessá‑lo da seguinte forma:

1. Carregue a apresentação que contém o objeto OLE incorporado criando uma instância da classe Presentation.
1. Obtenha uma referência ao slide pelo seu índice.
1. Acesse a forma OleObjectFrame.
1. Depois de obter o quadro de objeto OLE, execute as operações necessárias nele.

O exemplo abaixo acessa o quadro de objeto OLE — um gráfico Excel incorporado — e recupera seus dados de arquivo. Neste exemplo, usamos um PPTX que possui uma única forma no primeiro slide.

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # Obtenha os dados do arquivo incorporado.
        file_data = ole_frame.embedded_data.embedded_file_data

        # Obtenha a extensão do arquivo incorporado.
        file_extension = ole_frame.embedded_data.embedded_file_extension

        # ...
```

### **Acessar propriedades de objeto OLE vinculado**

Aspose.Slides permite acessar as propriedades de um quadro de objeto OLE vinculado.

O exemplo Python abaixo verifica se um objeto OLE está vinculado e, se estiver, recupera o caminho para o arquivo vinculado:

```py
with slides.Presentation("sample.ppt") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # Verifique se o objeto OLE está vinculado.
        if ole_frame.is_object_link:
            # Imprima o caminho completo do arquivo vinculado.
            print("OLE object frame is linked to:", ole_frame.link_path_long)

            # Imprima o caminho relativo do arquivo vinculado, se presente.
            # Somente apresentações .ppt podem conter um caminho relativo.
            if ole_frame.link_path_relative:
                print("OLE object frame relative path:", ole_frame.link_path_relative)
```

## **Alterar dados do objeto OLE**

{{% alert color="primary" %}}

Nesta seção, o exemplo de código abaixo usa [Aspose.Cells for Python via .NET](/cells/python-net/).

{{% /alert %}}

Se um objeto OLE já estiver incorporado em um slide, você pode acessá‑lo e modificar seus dados da seguinte forma:

1. Carregue a apresentação criando uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
1. Obtenha o slide de destino pelo seu índice.
1. Acesse a forma [OleObjectFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/oleobjectframe/).
1. Depois de obter o quadro de objeto OLE, execute as operações necessárias nele.
1. Crie um objeto `Workbook` e leia os dados OLE.
1. Abra a `Worksheet` desejada e edite os dados.
1. Salve o `Workbook` atualizado em um fluxo.
1. Substitua os dados do objeto OLE usando esse fluxo.

No exemplo abaixo, um quadro de objeto OLE (um gráfico Excel incorporado) é acessado e seus dados de arquivo são modificados para atualizar o gráfico. O exemplo usa um PPTX previamente criado que contém uma única forma no primeiro slide.

```py
import io
import aspose.slides as slides
import aspose.cells as cells

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        with io.BytesIO(ole_frame.embedded_data.embedded_file_data) as ole_stream:
            # Leia os dados do objeto OLE como um objeto Workbook.
            workbook = cells.Workbook(ole_stream)

        with io.BytesIO() as new_ole_stream:
            # Modifique os dados da planilha.
            workbook.worksheets.get(0).cells.get(0, 4).put_value("E")
            workbook.worksheets.get(0).cells.get(1, 4).put_value(12)
            workbook.worksheets.get(0).cells.get(2, 4).put_value(14)
            workbook.worksheets.get(0).cells.get(3, 4).put_value(15)

            file_options = cells.OoxmlSaveOptions(cells.SaveFormat.XLSX)
            workbook.save(new_ole_stream, file_options)

            # Altere os dados do objeto do quadro OLE.
            new_data = slides.dom.ole.OleEmbeddedDataInfo(new_ole_stream.getvalue(), ole_frame.embedded_data.embedded_file_extension)
            ole_frame.set_embedded_data(new_data)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Incorporar arquivos em slides**

Além de gráficos Excel, Aspose.Slides for Python permite incorporar outros tipos de arquivo em slides. Por exemplo, você pode inserir arquivos HTML, PDF e ZIP como objetos. Quando o usuário clica duas vezes em um objeto inserido, ele abre automaticamente no aplicativo associado ou o usuário é solicitado a escolher um programa adequado.

Este código Python mostra como incorporar arquivos HTML e ZIP em um slide:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("sample.html", "rb") as html_stream:
        html_data = html_stream.read()

    html_data_info = slides.dom.ole.OleEmbeddedDataInfo(html_data, "html")
    html_ole_frame = slide.shapes.add_ole_object_frame(150, 120, 50, 50, html_data_info)
    html_ole_frame.is_object_icon = True

    with open("sample.zip", "rb") as zip_stream:
        zip_data = zip_stream.read()

    zip_data_info = slides.dom.ole.OleEmbeddedDataInfo(zip_data, "zip")
    zip_ole_frame = slide.shapes.add_ole_object_frame(150, 220, 50, 50, zip_data_info)
    zip_ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Definir tipos de arquivo para objetos incorporados**

Ao trabalhar com apresentações, pode ser necessário substituir objetos OLE antigos por novos ou trocar um objeto OLE não suportado por um suportado. Aspose.Slides for Python permite definir o tipo de arquivo de um objeto incorporado, permitindo atualizar os dados do quadro OLE ou sua extensão de arquivo.

Este código Python mostra como definir o tipo de arquivo do objeto OLE incorporado para `zip`:

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    file_extension = ole_frame.embedded_data.embedded_file_extension
    file_data = ole_frame.embedded_data.embedded_file_data

    print(f"Current embedded file extension is: {file_extension}")

    # Alterar o tipo de arquivo para ZIP.
    ole_frame.set_embedded_data(slides.dom.ole.OleEmbeddedDataInfo(file_data, "zip"))

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Definir imagens de ícone e títulos para objetos incorporados**

Depois de incorporar um objeto OLE, uma visualização baseada em ícone é adicionada automaticamente. Essa visualização é o que os usuários veem antes de acessar ou abrir o objeto OLE. Se desejar usar uma imagem e um texto específicos na visualização, você pode definir a imagem de ícone e o título usando Aspose.Slides for Python.

Este código Python mostra como definir a imagem de ícone e o título para um objeto incorporado:

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # Adicione uma imagem aos recursos da apresentação.
    with slides.Images.from_file("image.png") as image:
        ole_image = presentation.images.add_image(image)

    # Defina um título e a imagem para a visualização OLE.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Impedir que quadros de objeto OLE sejam redimensionados e reposicionados**

Depois de adicionar um objeto OLE vinculado a um slide, o PowerPoint pode solicitar a atualização de links ao abrir a apresentação. Selecionar Atualizar Links pode alterar o tamanho e a posição do quadro de objeto OLE porque o PowerPoint atualiza a visualização com os dados do objeto vinculado. Para impedir que o PowerPoint solicite a atualização dos dados do objeto, defina a propriedade `update_automatic` da classe [OleObjectFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/oleobjectframe/) como `False`:

```py
ole_frame.update_automatic = False
```

## **Extrair arquivos incorporados**

Aspose.Slides for Python permite extrair arquivos incorporados em slides como objetos OLE da seguinte forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) que contém os objetos OLE que você deseja extrair.
1. Percorra todas as formas na apresentação e localize as formas OLEObjectFrame.
1. Recupere os dados do arquivo incorporado de cada [OLEObjectFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/oleobjectframe/) e grave-os no disco.

O código Python a seguir mostra como extrair arquivos incorporados em um slide como objetos OLE:

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for index, shape in enumerate(slide.shapes):
        if isinstance(shape, slides.OleObjectFrame):
            ole_frame = shape

            file_data = ole_frame.embedded_data.embedded_file_data
            file_extension = ole_frame.embedded_data.embedded_file_extension

            file_path = f"OLE_object_{index}{file_extension}"
            with open(file_path, 'wb') as file_stream:
                file_stream.write(file_data)
```

## **FAQ**

**O conteúdo OLE será renderizado ao exportar slides para PDF/imagens?**

O que está visível no slide é renderizado — o ícone/imagem de substituição (visualização). O conteúdo OLE "ao vivo" não é executado durante a renderização. Se necessário, defina sua própria imagem de visualização para garantir a aparência esperada no PDF exportado.

**Como posso bloquear um objeto OLE em um slide para que os usuários não possam mover/editar no PowerPoint?**

Bloqueie a forma: Aspose.Slides fornece [bloqueios no nível da forma](/slides/pt/python-net/applying-protection-to-presentation/). Isso não é criptografia, mas impede efetivamente edições e movimentos acidentais.

**Por que um objeto Excel vinculado "salta" ou muda de tamanho ao abrir a apresentação?**

O PowerPoint pode atualizar a visualização do OLE vinculado. Para uma aparência estável, siga as práticas da [Solução de funcionamento para redimensionamento de planilhas](/slides/pt/python-net/working-solution-for-worksheet-resizing/) — ajuste o quadro ao intervalo ou dimensione o intervalo para um quadro fixo e defina uma imagem de substituição apropriada.

**Os caminhos relativos para objetos OLE vinculados serão preservados no formato PPTX?**

No PPTX, as informações de "caminho relativo" não estão disponíveis — apenas o caminho completo. Caminhos relativos são encontrados no formato PPT mais antigo. Para portabilidade, prefira caminhos absolutos confiáveis/URIs acessíveis ou incorporação.