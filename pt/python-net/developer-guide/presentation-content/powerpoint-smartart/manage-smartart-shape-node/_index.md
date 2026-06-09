---
title: Gerenciar nós de forma SmartArt em apresentações usando Python
linktitle: Nó de Forma SmartArt
type: docs
weight: 30
url: /pt/python-net/manage-smartart-shape-node/
keywords:
- Nó SmartArt
- Nó filho
- Adicionar nó
- Posição do nó
- Acessar nó
- Remover nó
- Posição personalizada
- Nó assistente
- Formato de preenchimento
- Renderizar nó
- PowerPoint
- Apresentação
- Python
- Aspose.Slides
description: "Gerencie nós de forma SmartArt em PPT, PPTX e ODP com Aspose.Slides for Python via .NET. Obtenha exemplos de código claros e dicas para otimizar suas apresentações."
---
## **Visão geral**

Os gráficos SmartArt em apresentações do PowerPoint são organizados por meio de nós que contêm texto e definem a estrutura do diagrama. Aspose.Slides permite trabalhar com esses nós SmartArt programaticamente: adicionar novos nós e nós filho, inserir nós filho em uma posição específica, acessar nós existentes e ler seu texto, nível e posição.

Este artigo explica como gerenciar nós de formas SmartArt. Ele mostra como remover nós, trabalhar com nós filho por índice ou posição, transformar um nó assistente em um nó normal, ajustar a posição, tamanho e rotação das formas de nós SmartArt, definir formatos de preenchimento dos nós e gerar uma imagem miniatura para um nó filho SmartArt.

## **Adicionar Nó SmartArt**
Aspose.Slides for Python via .NET forneceu a API mais simples para gerenciar as formas SmartArt da maneira mais fácil. O código de exemplo a seguir ajudará a adicionar nós e nós filho dentro da forma SmartArt.

- Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) e carregue a apresentação com a Forma SmartArt.
- Obtenha a referência do primeiro slide usando seu Índice.
- Percorra todas as formas dentro do primeiro slide.
- Verifique se a forma é do tipo SmartArt e faça o typecast da forma selecionada para SmartArt se for SmartArt.
- Adicione um novo Nó na NodeCollection da forma SmartArt e defina o texto no TextFrame.
- Agora, adicione um Nó Filho no Nó SmartArt recém‑adicionado e defina o texto no TextFrame.
- Salve a Apresentação.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Carregar a apresentação desejada
with slides.Presentation(path + "AddNodes.pptx") as pres:
    # Percorrer todas as formas dentro do primeiro slide
    for shape in pres.slides[0].shapes:

        # Verificar se a forma é do tipo SmartArt
        if type(shape) is art.SmartArt:
            # Adicionar um novo nó SmartArt
            node1 = shape.all_nodes.add_node()
            # Adicionar texto
            node1.text_frame.text = "Test"

            # Adicionar novo nó filho no nó pai. Ele será adicionado ao final da coleção
            new_node = node1.child_nodes.add_node()

            # Adicionar texto
            new_node.text_frame.text = "New Node Added"

    # Salvar apresentação
    pres.save("AddSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Adicionar Nó SmartArt em Posição Específica**
No código de exemplo a seguir explicamos como adicionar os nós filho pertencentes aos respectivos nós da forma SmartArt em uma posição específica.

- Crie uma instância da classe `Presentation`.
- Obtenha a referência do primeiro slide usando seu Índice.
- Adicione uma forma SmartArt do tipo StackedList no slide acessado.
- Acesse o primeiro nó na forma SmartArt adicionada.
- Agora, adicione o Nó Filho para o Nó selecionado na posição 2 e defina seu texto.
- Salve a Apresentação.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Criando uma instância de apresentação
with slides.Presentation() as pres:
    # Acessar o slide da apresentação
    slide = pres.slides[0]

    # Adicionar Smart Art IShape
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.STACKED_LIST)

    # Acessar o nó SmartArt no índice 0
    node = smart.all_nodes[0]

    # Adicionar novo nó filho na posição 2 no nó pai
    chNode = node.child_nodes.add_node_by_position(2)

    # Adicionar texto
    chNode.text_frame.text = "Sample text Added"

    # Salvar apresentação
    pres.save("AddSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```




## **Acessar Nó SmartArt**
O código de exemplo a seguir ajudará a acessar nós dentro da forma SmartArt. Observe que você não pode alterar o LayoutType do SmartArt, pois ele é somente leitura e é definido apenas quando a forma SmartArt é adicionada.

- Crie uma instância da classe `Presentation` e carregue a apresentação com a Forma SmartArt.
- Obtenha a referência do primeiro slide usando seu Índice.
- Percorra todas as formas dentro do primeiro slide.
- Verifique se a forma é do tipo SmartArt e faça o typecast da forma selecionada para SmartArt se for SmartArt.
- Percorra todos os Nós dentro da Forma SmartArt.
- Acesse e exiba informações como posição do Nó SmartArt, nível e Texto.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Carregar a apresentação desejada
with slides.Presentation(path + "AccessSmartArt.pptx") as pres:
    # Percorrer todas as formas dentro do primeiro slide
    for shape in pres.slides[0].shapes:
        # Verificar se a forma é do tipo SmartArt
        if type(shape) is art.SmartArt:
            # Percorrer todos os nós dentro do SmartArt
            for i in range(len(shape.all_nodes)):
                # Acessar o nó SmartArt no índice i
                node = shape.all_nodes[i]

                # Imprimir os parâmetros do nó SmartArt
                print("i = {0}, text = {1},  level = {2}, position = {3}".format(i, node.text_frame.text, node.level, node.position))
```

  


## **Acessar Nó Filho SmartArt**
O código de exemplo a seguir ajudará a acessar os nós filho pertencentes aos respectivos nós da forma SmartArt.

- Crie uma instância da classe PresentationEx e carregue a apresentação com a Forma SmartArt.
- Obtenha a referência do primeiro slide usando seu Índice.
- Percorra todas as formas dentro do primeiro slide.
- Verifique se a forma é do tipo SmartArt e faça o typecast da forma selecionada para SmartArtEx se for SmartArt.
- Percorra todos os Nós dentro da Forma SmartArt.
- Para cada Nó da forma SmartArt selecionado, percorra todos os Nós Filho dentro do nó específico.
- Acesse e exiba informações como posição do Nó Filho, nível e Texto.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Carregar a apresentação desejada
with slides.Presentation(path + "AccessChildNodes.pptx") as pres:
    # Percorrer todas as formas dentro do primeiro slide
    for shape in pres.slides[0].shapes:
        # Verificar se a forma é do tipo SmartArt
        if type(shape) is art.SmartArt:
            # Percorrer todos os nós dentro do SmartArt
            for node0 in shape.all_nodes:
                # Percorrendo os nós filho
                for j in range(len(node0.child_nodes)):
                    # Acessar o nó filho no nó SmartArt
                    node = node0.child_nodes[j]

                    # Imprimir os parâmetros do nó filho do SmartArt
                    print("j = {0}, text = {1},  level = {2}, position = {3}".format(j, node.text_frame.text, node.level, node.position))

```



## **Acessar Nó Filho SmartArt em Posição Específica**
Neste exemplo, aprenderemos a acessar os nós filho em posições específicas pertencentes aos respectivos nós da forma SmartArt.

- Crie uma instância da classe `Presentation`.
- Obtenha a referência do primeiro slide usando seu Índice.
- Adicione uma forma SmartArt do tipo StackedList.
- Acesse a forma SmartArt adicionada.
- Acesse o nó no índice 0 da forma SmartArt acessada.
- Agora, acesse o Nó Filho na posição 1 do nó SmartArt acessado usando o método GetNodeByPosition().
- Acesse e exiba informações como posição do Nó Filho, nível e Texto.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Instanciar a apresentação
with slides.Presentation() as pres:
    # Acessar o primeiro slide
    slide = pres.slides[0]
    # Adicionar a forma SmartArt no primeiro slide
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.STACKED_LIST)
    # Acessar o nó SmartArt no índice 0
    node = smart.all_nodes[0]
    # Acessar o nó filho na posição 1 no nó pai
    position = 1
    chNode = node.child_nodes[position] 
    # Imprimir os parâmetros do nó filho do SmartArt
    print("j = {0}, text = {1},  level = {2}, position = {3}".format(position, chNode.text_frame.text, chNode.level, chNode.position))
```



## **Remover Nó SmartArt**
Neste exemplo, aprenderemos a remover os nós dentro da forma SmartArt.

- Crie uma instância da classe `Presentation` e carregue a apresentação com a Forma SmartArt.
- Obtenha a referência do primeiro slide usando seu Índice.
- Percorra todas as formas dentro do primeiro slide.
- Verifique se a forma é do tipo SmartArt e faça o typecast da forma selecionada para SmartArt se for SmartArt.
- Verifique se o SmartArt tem mais de 0 nós.
- Selecione o nó SmartArt a ser excluído.
- Agora, remova o nó selecionado usando o método RemoveNode() e salve a Apresentação.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Carregar a apresentação desejada
with slides.Presentation(path + "RemoveNode.pptx") as pres:
    # Percorrer todas as formas dentro do primeiro slide
    for shape in pres.slides[0].shapes:
        # Verificar se a forma é do tipo SmartArt
        if type(shape) is art.SmartArt:
            # Fazer typecast da forma para SmartArtEx
            if len(shape.all_nodes) > 0:
                # Acessar o nó SmartArt no índice 0
                node = shape.all_nodes[0]

                # Remover o nó selecionado
                shape.all_nodes.remove_node(node)

    # Salvar apresentação
    pres.save("RemoveSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Remover Nó SmartArt em Posição Específica**
Neste exemplo, aprenderemos a remover os nós dentro da forma SmartArt em uma posição específica.

- Crie uma instância da classe `Presentation` e carregue a apresentação com a Forma SmartArt.
- Obtenha a referência do primeiro slide usando seu Índice.
- Percorra todas as formas dentro do primeiro slide.
- Verifique se a forma é do tipo SmartArt e faça o typecast da forma selecionada para SmartArt se for SmartArt.
- Selecione o nó da forma SmartArt no índice 0.
- Agora, verifique se o nó SmartArt selecionado tem mais de 2 nós filho.
- Agora, remova o nó na Posição 1 usando o método RemoveNodeByPosition().
- Salve a Apresentação.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Carregar a apresentação desejada
with slides.Presentation(path + "RemoveNodeSpecificPosition.pptx") as pres:             
    # Percorrer todas as formas dentro do primeiro slide
    for shape in pres.slides[0].shapes:
        # Verificar se a forma é do tipo SmartArt
        if type(shape) is art.SmartArt:
            # Fazer typecast da forma para SmartArt
            if len(shape.all_nodes) > 0:
                # Acessar o nó SmartArt no índice 0
                node = shape.all_nodes[0]
                if len(node.child_nodes) >= 2:
                    # Remover o nó filho na posição 1
                    node.child_nodes.remove_node(1)

    # Salvar apresentação
    pres.save("RemoveSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Definir Posição Personalizada para Nó Filho em SmartArt**
Agora o Aspose.Slides for Python via .NET oferece suporte para definir as propriedades X e Y do SmartArtShape. O trecho de código abaixo mostra como definir posição, tamanho e rotação personalizados do SmartArtShape; observe também que a adição de novos nós provoca um recálculo das posições e tamanhos de todos os nós.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Carregar a apresentação desejada
with slides.Presentation(path + "AccessChildNodes.pptx") as pres: 
	smart = pres.slides[0].shapes.add_smart_art(20, 20, 600, 500, art.SmartArtLayoutType.ORGANIZATION_CHART)

	# Mover a forma SmartArt para nova posição
	node = smart.all_nodes[1]
	shape = node.shapes[1]
	shape.x += (shape.width * 2)
	shape.y -= (shape.height / 2)

	# Alterar as larguras da forma SmartArt
	node = smart.all_nodes[2]
	shape = node.shapes[1]
	shape.width += (shape.width / 2)

	# Alterar a altura da forma SmartArt
	node = smart.all_nodes[3]
	shape = node.shapes[1]
	shape.height += (shape.height / 2)

	# Alterar a rotação da forma SmartArt
	node = smart.all_nodes[4]
	shape = node.shapes[1]
	shape.rotation = 90

	pres.save("SmartArt.pptx", slides.export.SaveFormat.PPTX)
```



## **Verificar Nó Assistente**
No código de exemplo a seguir investigaremos como identificar Nós Assistentes na coleção de nós SmartArt e alterá‑los.

- Crie uma instância da classe PresentationEx e carregue a apresentação com a Forma SmartArt.
- Obtenha a referência do segundo slide usando seu Índice.
- Percorra todas as formas dentro do primeiro slide.
- Verifique se a forma é do tipo SmartArt e faça o typecast da forma selecionada para SmartArtEx se for SmartArt.
- Percorra todos os nós dentro da forma SmartArt e verifique se são Nós Assistentes.
- Altere o status do Nó Assistente para nó normal.
- Salve a Apresentação.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Criando uma instância de apresentação
with slides.Presentation(path + "AssistantNode.pptx") as pres: 
    # Percorrer todas as formas dentro do primeiro slide
    for shape in pres.slides[0].shapes:
        # Verificar se a forma é do tipo SmartArt
        if type(shape) is art.SmartArt:
            # Percorrendo todos os nós da forma SmartArt
            for node in shape.all_nodes:
                tc = node.text_frame.text
                # Verificar se o nó é um nó Assistente
                if node.is_assistant:
                    # Definir o nó Assistente como falso e transformá-lo em nó normal
                    node.is_assistant = False
    # Salvar apresentação
    pres.save("ChangeAssitantNode_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Definir Formato de Preenchimento do Nó**
O Aspose.Slides for Python via .NET possibilita adicionar formas SmartArt personalizadas e definir seus formatos de preenchimento. Este artigo explica como criar e acessar formas SmartArt e definir seu formato de preenchimento usando o Aspose.Slides for Python via .NET.

- Crie uma instância da classe `Presentation`.
- Obtenha a referência de um slide usando seu índice.
- Adicione uma forma SmartArt definindo seu LayoutType.
- Defina o FillFormat para os nós da forma SmartArt.
- Grave a apresentação modificada como um arquivo PPTX.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as presentation: 
    # Acessando o slide
    slide = presentation.slides[0]

    # Adicionando forma SmartArt e nós
    chevron = slide.shapes.add_smart_art(10, 10, 800, 60, art.SmartArtLayoutType.CLOSED_CHEVRON_PROCESS)
    node = chevron.all_nodes.add_node()
    node.text_frame.text = "Some text"

    # Definindo a cor de preenchimento do nó
    for item in node.shapes:
        item.fill_format.fill_type = slides.FillType.SOLID
        item.fill_format.solid_fill_color.color = draw.Color.red

    # Salvando a apresentação
    presentation.save("FillFormat_SmartArt_ShapeNode_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Gerar Miniatura do Nó Filho SmartArt**
Os desenvolvedores podem gerar uma miniatura do nó filho de um SmartArt seguindo as etapas abaixo:

1. Instancie a classe `Presentation` que representa o arquivo PPTX.
2. Adicione SmartArt.
3. Obtenha a referência de um nó usando seu Índice
4. Obtenha a imagem da miniatura.
5. Salve a imagem da miniatura em qualquer formato de imagem desejado.

O exemplo abaixo gera uma miniatura do nó filho SmartArt

```py
import aspose.slides as slides
import aspose.slides.smartart as art

# Instanciar a classe Presentation que representa o arquivo PPTX
with slides.Presentation() as presentation: 
    # Adicionar SmartArt 
    smart = pres.slides[0].shapes.add_smart_art(10, 10, 400, 300, art.SmartArtLayoutType.BASIC_CYCLE)

    # Obter a referência de um nó usando seu Índice  
    node = smart.nodes[1]

    # Obter miniatura
    with node.shapes[0].get_image() as bmp:
        # salvar miniatura
        bmp.save("SmartArt_ChildNote_Thumbnail_out.jpeg", slides.ImageFormat.JPEG)
```

## **FAQ**

**A animação de SmartArt é suportada?**

Sim. SmartArt é tratado como uma forma regular, portanto você pode [aplicar animações padrão](/slides/pt/python-net/shape-animation/) (entrada, saída, ênfase, caminhos de movimento) e ajustar o tempo. Você também pode animar formas dentro dos nós SmartArt quando necessário.

**Como posso localizar de forma confiável um SmartArt específico em um slide se seu ID interno for desconhecido?**

Atribua e pesquise por [texto alternativo](https://reference.aspose.com/slides/pt/python-net/aspose.slides.smartart/smartart/alternative_text/). Definir um AltText distinto no SmartArt permite encontrá‑lo programaticamente sem depender de identificadores internos.

**A aparência do SmartArt será preservada ao converter a apresentação para PDF?**

Sim. O Aspose.Slides renderiza o SmartArt com alta fidelidade visual durante a [exportação para PDF](/slides/pt/python-net/convert-powerpoint-to-pdf/), preservando layout, cores e efeitos.

**Posso extrair uma imagem de todo o SmartArt (para visualizações ou relatórios)?**

Sim. Você pode renderizar uma forma SmartArt para [formatos raster](https://reference.aspose.com/slides/pt/python-net/aspose.slides.smartart/smartart/get_image/) ou para [SVG](https://reference.aspose.com/slides/pt/python-net/aspose.slides.smartart/smartart/write_as_svg/) para saída vetorial escalável, tornando-a adequada para miniaturas, relatórios ou uso na web.