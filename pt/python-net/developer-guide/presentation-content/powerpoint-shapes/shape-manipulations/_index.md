---
title: Gerenciar formas em apresentações usando Python
linktitle: Manipulação de Formas
type: docs
weight: 40
url: /pt/python-net/shape-manipulations/
keywords:
- Forma PowerPoint
- Forma de apresentação
- Forma no slide
- Encontrar forma
- Clonar forma
- Remover forma
- Ocultar forma
- Alterar ordem da forma
- Obter ID da forma Interop
- Texto alternativo da forma
- Formatos de layout da forma
- Forma como SVG
- Forma para SVG
- Alinhar forma
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Aprenda a criar, editar e otimizar formas no Aspose.Slides for Python via .NET e entregar apresentações PowerPoint e OpenDocument de alto desempenho."
---
## **Visão geral**

Este guia apresenta a manipulação de formas no Aspose.Slides para Python via .NET. Aprenda padrões práticos para encontrar formas (incluindo por Texto Alternativo), duplicar, excluir ou ocultar, reordenar, alinhar e espelhar, ler IDs e formatação baseada em layout, e exportar formas individuais para SVG usando as APIs [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) e [Shape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/).

## **Encontrar formas nos slides**

O PowerPoint identifica as formas apenas por IDs internos. Atribua um Texto Alternativo único à forma de destino no PowerPoint, depois abra a apresentação com o Aspose.Slides para Python, percorra as formas do slide e selecione aquela cujo Texto Alternativo corresponda. O método `find_shape` implementa essa abordagem e retorna a forma correspondente.

```py
import aspose.slides as slides

# Encontra uma forma em um slide pelo seu texto alternativo.
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# Instancia a classe Presentation que representa um arquivo de apresentação.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Encontra a forma com Texto Alternativo "Shape1".
    shape = find_shape(slide, "Shape1")
    if shape is not None:
        print("Shape name:", shape.name)
```

## **Clonar formas**

Para clonar formas de um slide de origem para um novo slide no Aspose.Slides, siga estas etapas:

1. Crie um [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) a partir do arquivo de origem.  
1. Obtenha o slide de origem pelo índice e sua coleção de formas.  
1. Recupere um layout em branco do slide mestre.  
1. Adicione um slide vazio usando esse layout e obtenha suas formas.  
1. Clone as formas para o slide de destino.  
1. Salve a apresentação como PPTX.

O exemplo de código a seguir clona formas de um slide para outro.

```py
import aspose.slides as slides

# Instancia a classe Presentation.
with slides.Presentation("sample.pptx") as presentation:
    source_shapes = presentation.slides[0].shapes
    blank_layout = presentation.masters[0].layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    target_slide = presentation.slides.add_empty_slide(blank_layout)
    target_shapes = target_slide.shapes
	
    target_shapes.add_clone(source_shapes[1], 50, 150 + source_shapes[0].height)
    target_shapes.add_clone(source_shapes[2])
    target_shapes.insert_clone(0, source_shapes[0], 50, 150)

    # Salva a apresentação no disco.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Remover formas**

O Aspose.Slides permite remover qualquer forma de um slide. Por exemplo, para excluir uma forma do primeiro slide pelo seu Texto Alternativo, siga estas etapas:

1. Crie uma instância de [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) e carregue o arquivo.  
1. Acesse o primeiro slide da coleção de slides.  
1. Encontre a forma pelo valor do Texto Alternativo.  
1. Remova a forma da coleção de formas do slide.  
1. Salve a apresentação no disco no formato PPTX.

```py
import aspose.slides as slides

# Encontra uma forma em um slide pelo seu texto alternativo.
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# Instancia a classe Presentation que representa um arquivo de apresentação.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Encontra a forma com Texto Alternativo "User Defined".
    shape = find_shape(slide, "User Defined")
    # Remove a forma.
    slide.shapes.remove(shape)
    # Salva a apresentação no disco.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Ocultar formas**

O Aspose.Slides permite ocultar qualquer forma em um slide. Por exemplo, para ocultar uma forma no primeiro slide pelo seu Texto Alternativo, siga estas etapas:

1. Crie uma instância de [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) e carregue o arquivo.  
1. Acesse o primeiro slide da coleção de slides.  
1. Encontre a forma pelo valor do Texto Alternativo.  
1. Oculte a forma.  
1. Salve a apresentação no disco em formato PPTX.

```py
# Encontra uma forma em um slide pelo seu texto alternativo.
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# Instancia a classe Presentation que representa um arquivo de apresentação.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Encontra a forma com Texto Alternativo "User Defined".
    shape = find_shape(slide, "User Defined")
    # Oculta a forma.
    shape.hidden = True
    # Salva a apresentação no disco.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Alterar a ordem das formas**

O Aspose.Slides permite que os desenvolvedores reordenem formas (alterem sua ordem Z). O reordenamento determina qual forma aparece à frente ou atrás. Por exemplo, para reordenar duas formas no primeiro slide, siga os passos abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).  
1. Acesse o primeiro slide.  
1. Adicione a primeira forma (por exemplo, um retângulo).  
1. Adicione a segunda forma (por exemplo, um triângulo).  
1. Reordene as formas movendo a segunda forma para a primeira posição na coleção.  
1. Salve a apresentação no disco.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Adiciona duas formas ao slide.
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 150)
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 20, 200, 200, 150)
    # Move a segunda forma para a primeira posição.
    slide.shapes.reorder(0, shape2)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Obter o ID de forma Interop**

O Aspose.Slides permite obter o identificador exclusivo de uma forma no escopo do slide, ao contrário da propriedade `unique_id`, que é única em toda a apresentação. A propriedade `office_interop_shape_id` está disponível na classe [Shape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/). Seu valor corresponde ao `Id` do objeto `Microsoft.Office.Interop.PowerPoint.Shape`. Um trecho de código de exemplo é mostrado abaixo.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # Obtém o identificador exclusivo da forma dentro do slide.
    officeInteropShapeId = presentation.slides[0].shapes[0].office_interop_shape_id
```

## **Definir o texto alternativo para formas**

O Aspose.Slides permite que os desenvolvedores definam texto alternativo para qualquer forma. Você pode usar o texto alternativo para identificar e localizar formas em uma apresentação. A propriedade de texto alternativo pode ser lida e escrita tanto pelo Aspose.Slides quanto pelo Microsoft PowerPoint. Ao marcar formas com essa propriedade, você pode posteriormente removê‑las, ocultá‑las ou reordená‑las em um slide.

Para definir o texto alternativo de uma forma, siga estas etapas:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).  
1. Acesse o primeiro slide.  
1. Adicione uma forma ao slide.  
1. Defina o texto alternativo.  
1. Salve a apresentação no disco.

```py
import aspose.slides as slides

# Instancia a classe Presentation que representa um arquivo PPTX.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    # Adiciona uma forma.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 40, 150, 50)
    # Define o texto alternativo para a forma.
    shape.alternative_text = "User Defined"
    # Salva a apresentação no disco.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Acessar formatos de layout para formas**

O Aspose.Slides oferece uma API simples para acessar formatos de layout de formas. Esta seção demonstra como acessar os formatos de layout.

```py
import aspose.slides as slides

with slides.Presentation(folder_path + "sample.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        fill_formats = list(map(lambda shape: shape.fill_format, layout_slide.shapes))
        line_formats = list(map(lambda shape: shape.line_format, layout_slide.shapes))
```

## **Renderizar formas como SVG**

O Aspose.Slides suporta renderização de formas como SVG. O método `write_as_svg` (e suas sobrecargas) na classe [Shape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/) permite salvar o conteúdo de uma forma como uma imagem SVG. O trecho de código abaixo mostra como exportar uma forma para um arquivo SVG.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    with open("output.svg", "wb") as image_stream:
        # Obtém a primeira forma no primeiro slide.
        shape = presentation.slides[0].shapes[0]
        shape.write_as_svg(image_stream)
```

## **Alinhar forma**

Usando o método `align_shape` na classe [SlidesUtil](https://reference.aspose.com/slides/pt/python-net/aspose.slides.util/slideutil/), você pode:

* Alinhar formas em relação às margens de um slide (veja o Exemplo 1).  
* Alinhar formas em relação umas às outras (veja o Exemplo 2).

A enumeração [ShapesAlignmentType](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shapesalignmenttype/) define as opções de alinhamento disponíveis.

**Exemplo 1**

Este código Python mostra como alinhar as formas com índices 1, 2 e 4 à borda superior do slide:

```py
import aspose.slides as slides

align_type = slides.ShapesAlignmentType.ALIGN_TOP
slide_indices = [1, 2, 4]

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    slides.util.SlideUtil.align_shapes(align_type, True, slide, slide_indices)
```

**Exemplo 2**

Este exemplo Python mostra como alinhar todas as formas em uma coleção em relação à forma mais baixa da coleção:

```py
import aspose.slides as slides

align_type = slides.ShapesAlignmentType.ALIGN_BOTTOM

with slides.Presentation("sample.pptx") as presentation:
    slides.util.SlideUtil.align_shapes(align_type, False, presentation.slides[0])
```

## **Propriedades de espelhamento**

No Aspose.Slides, a classe [ShapeFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shapeframe/) fornece controle sobre o espelhamento horizontal e vertical das formas por meio das propriedades `flip_h` e `flip_v`. Ambas as propriedades são do tipo [NullableBool](https://reference.aspose.com/slides/pt/python-net/aspose.slides/nullablebool/), permitindo valores `TRUE` para indicar espelhamento, `FALSE` para nenhum espelhamento ou `NOT_DEFINED` para usar o comportamento padrão. Esses valores são acessíveis a partir do [Frame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/frame/) de uma forma.

Para modificar as configurações de espelhamento, uma nova instância de [ShapeFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shapeframe/) é construída com a posição e o tamanho atuais da forma, os valores desejados para `flip_h` e `flip_v` e o ângulo de rotação. Atribuir essa instância ao [Frame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/frame/) da forma e salvar a apresentação aplica as transformações de espelhamento e as grava no arquivo de saída.

Suponha que temos um arquivo sample.pptx no qual o primeiro slide contém uma única forma com configurações de espelhamento padrão, como mostrado abaixo.

![A forma a ser espelhada](shape_to_be_flipped.png)

O exemplo de código a seguir obtém as propriedades de espelhamento atuais da forma e a espelha tanto horizontal quanto verticalmente.

```py
with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    # Recupera a propriedade de espelhamento horizontal da forma.
    horizontal_flip = shape.frame.flip_h
    print("Horizontal flip:", horizontal_flip)

    # Recupera a propriedade de espelhamento vertical da forma.
    vertical_flip = shape.frame.flip_v
    print("Vertical flip:", vertical_flip)

    x, y = shape.frame.x, shape.frame.y
    width, height = shape.frame.width, shape.frame.height
    flip_h, flip_v = slides.NullableBool.TRUE, slides.NullableBool.TRUE  # Espelha horizontalmente e verticalmente.
    rotation = shape.frame.rotation

    shape.frame = slides.ShapeFrame(x, y, width, height, flip_h, flip_v, rotation)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

O resultado:

![A forma espelhada](flipped_shape.png)

## **FAQ**

**Posso combinar formas (união/interseção/subtração) em um slide como em um editor de desktop?**

Não existe uma API de operação booleana integrada. Você pode aproximar isso construindo o contorno desejado por conta própria — por exemplo, calcular a geometria resultante (via [GeometryPath](https://reference.aspose.com/slides/pt/python-net/aspose.slides/geometrypath/)) e criar uma nova forma com esse contorno, opcionalmente removendo as originais.

**Como posso controlar a ordem de empilhamento (z-order) para que uma forma permaneça sempre “no topo”?**

Altere a ordem de inserção/movimento dentro da coleção de [shapes](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slide/shapes/) do slide. Para resultados previsíveis, finalize a ordem Z após todas as outras modificações do slide.

**Posso “travar” uma forma para impedir que usuários a editem no PowerPoint?**

Sim. Defina os [flags de proteção a nível de forma](/slides/pt/python-net/applying-protection-to-presentation/) (por exemplo, bloquear seleção, movimentação, redimensionamento, edição de texto). Se necessário, reflita as restrições no mestre ou no layout. Observe que isso é proteção ao nível da UI, não um recurso de segurança; para proteção mais forte, combine com restrições a nível de arquivo, como recomendações de somente‑leitura ou senhas ([read‑only recommendations or passwords](/slides/pt/python-net/password-protected-presentation/)).