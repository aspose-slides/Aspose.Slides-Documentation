---
title: Gerenciar formas de apresentação em Python
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
- Obter ID de forma interop
- Texto alternativo da forma
- Ponto de ajuste da forma
- Ajuste de forma pré-definido
- Geometria da forma
- Formatos de layout da forma
- Forma como SVG
- Forma para SVG
- Alinhar forma
- Inverter forma
- PowerPoint
- Apresentação
- Python
- Aspose.Slides
description: "Aprenda como identificar, ajustar, clonar, remover, ocultar, reorganizar, exportar, alinhar e inverter formas de apresentação com Aspose.Slides for Python via .NET."
---
## **Visão geral**

Aspose.Slides for Python via .NET representa as formas em um slide como uma [ShapeCollection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shapecollection/) ordenada. A coleção é tanto o local onde você encontra e modifica formas quanto a fonte da ordem de empilhamento: o índice `0` é a forma mais ao fundo, enquanto o último índice é a forma mais ao frente.

Este artigo segue esse modelo. Primeiro explica como identificar uma forma de forma confiável e modificar pontos de ajuste pré‑definidos, depois mostra como clonar, remover, ocultar e reorganizar formas. As seções finais cobrem formatação em nível de layout, exportação para SVG, alinhamento e configurações de inversão. Cada exemplo é independente, de modo que você pode usar apenas as operações necessárias ao seu fluxo de trabalho.

## **Identificar e encontrar formas**

Os índices da coleção são convenientes ao processar um arquivo conhecido, mas não são identificadores estáveis. Adicionar, remover ou reordenar uma forma pode mudar seu índice. Escolha um identificador de acordo com a forma como a apresentação é criada e mantida:

- [Shape.name](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/name/) é útil para modelos controlados por desenvolvedores e é fácil de inspecionar no Painel de seleção do PowerPoint. Os nomes podem ser editados e não são garantidos como únicos, portanto estabeleça uma convenção de nomenclatura se o código depender deles.
- [Shape.alternative_text](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/alternative_text/) é útil quando uma descrição de acessibilidade ou uma tag fornecida pelo autor já identifica a forma. É visível para os usuários, pode ser localizado ou reescrito para acessibilidade e não é garantido como único. Não reutilize silenciosamente texto de acessibilidade significativo como chave de banco de dados.
- [Shape.office_interop_shape_id](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/office_interop_shape_id/) é um identificador somente‑leitura que é único dentro de um slide e corresponde ao ID de forma usado pela interoperabilidade do PowerPoint. Use‑o ao integrar com o PowerPoint ou quando precisar de uma referência inequívoca durante a vida útil de uma forma. Uma forma clonada ou recriada é uma forma diferente e recebe seu próprio ID.

A propriedade relacionada [Shape.unique_id](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/unique_id/) tem escopo de apresentação, mas destina‑se a add‑ins e pode ser reatribuída. Não deve ser tratada como uma chave externa permanente. Se a identidade a longo prazo for essencial, mantenha o mapeamento em dados da aplicação e valide se a forma esperada ainda existe.

O exemplo a seguir procura por `name` com comparação exata e informa o ID de interop no escopo do slide. Quando o modelo não contém a forma esperada, o código relata esse resultado em vez de continuar com o objeto errado.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    target_shape = None
    for shape in slide.shapes:
        if shape.name == "RevenueChart":
            target_shape = shape
            break

    if target_shape is None:
        print("The shape 'RevenueChart' was not found on slide 1.")
    else:
        print("Found {}; interop ID: {}".format(target_shape.name, target_shape.office_interop_shape_id))
```

Quando uma operação é específica a um tipo de forma, verifique o tipo antes de usar membros específicos. Este exemplo atualiza texto e texto alternativo somente se o objeto nomeado for um [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/).

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    candidate = None
    for shape in slide.shapes:
        if shape.name == "StatusLabel":
            candidate = shape
            break

    if isinstance(candidate, slides.AutoShape):
        candidate.text_frame.text = "Approved"
        candidate.alternative_text = "Approval status: approved"
        presentation.save("identified-shape.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("'StatusLabel' is missing or is not an AutoShape.")
```

## **Identificar e modificar ajustes pré‑definidos de forma**

Formas de geometria pré‑definida podem expor pontos de ajuste que controlam recursos como tamanho de cantos, proporções de setas ou ângulos de arcos. Acesse‑os através da coleção somente‑leitura [GeometryShape.adjustments](https://reference.aspose.com/slides/pt/python-net/aspose.slides/geometryshape/adjustments/). A própria coleção é fornecida pela forma, mas cada [AdjustValue](https://reference.aspose.com/slides/pt/python-net/aspose.slides/adjustvalue/) contém um valor que pode ser alterado.

Não confie apenas em um índice de coleção fixo. Percorra os ajustes e inspecione a propriedade somente‑leitura [AdjustValue.type](https://reference.aspose.com/slides/pt/python-net/aspose.slides/adjustvalue/type/), cujo valor [ShapeAdjustmentType](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shapeadjustmenttype/) descreve o que o ajuste controla. A propriedade somente‑leitura [AdjustValue.name](https://reference.aspose.com/slides/pt/python-net/aspose.slides/adjustvalue/name/) fornece informações adicionais de identificação e é especialmente útil quando um pré‑definido contém mais de um ajuste com o mesmo tipo semântico.

Use a propriedade de valor que corresponde ao significado do ajuste:

| Tipo de ajuste | Propósito | Valor a alterar |
|---|---|---|
| `CORNER_SIZE` | Tamanho dos cantos arredondados | [raw_value](https://reference.aspose.com/slides/pt/python-net/aspose.slides/adjustvalue/raw_value/) |
| `ARROW_TAIL_THICKNESS` | Espessura da cauda da seta | `raw_value` |
| `ARROWHEAD_LENGTH` | Comprimento da ponta da seta | `raw_value` |
| `ARROWHEAD_WIDTH` | Largura da ponta da seta | `raw_value` |
| `START_ANGLE` | Ângulo inicial de uma pizza ou arco | [angle_value](https://reference.aspose.com/slides/pt/python-net/aspose.slides/adjustvalue/angle_value/) |
| `END_ANGLE` | Ângulo final de uma pizza ou arco | `angle_value` |

`type` e `name` não podem ser atribuídos. `raw_value` é um inteiro de leitura/escrita nas unidades nativas de geometria do pré‑definido, enquanto `angle_value` é um ângulo de leitura/escrita em graus. O número, a ordem, o significado e o intervalo válido de ajustes dependem do pré‑definido [GeometryShape.shape_type](https://reference.aspose.com/slides/pt/python-net/aspose.slides/geometryshape/shape_type/). Um valor válido para um pré‑definido pode ser inválido ou ter efeito diferente em outro.

Quando `type` é `ShapeAdjustmentType.CUSTOM`, a API não reconhece um significado semântico padrão. Inspecione `name`, o tipo do pré‑definido e o valor existente, e deixe o ajuste inalterado a menos que o significado e o intervalo esperados sejam conhecidos. Mesmo para tipos reconhecidos, verifique se o mesmo tipo ocorre mais de uma vez antes de selecionar um valor. O artigo [Connector](/slides/pt/python-net/connector/) mostra essa situação com ajustes de curvatura de conectores.

O exemplo completo a seguir cria versões padrão e modificadas de três formas pré‑definidas. Ele percorre cada ajuste, relata seu `name` e `type`, altera valores relacionados ao tamanho via `raw_value`, altera ângulos via `angle_value` e salva o resultado. A coluna da esquerda mantém a geometria padrão; a coluna da direita mostra o retângulo arredondado, a seta de quatro vias e a pizza ajustados.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Adicionar cabeçalhos para as colunas de forma padrão e ajustada.
    default_column_label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 20, 250, 30)
    default_column_label.text_frame.text = "Default preset geometry"
    adjusted_column_label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 390, 20, 250, 30)
    adjusted_column_label.text_frame.text = "Modified adjustment values"

    slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 80, 70, 160, 70)
    modified_rounded_rectangle = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 430, 70, 160, 70)
    modified_rounded_rectangle.name = "ModifiedRoundedRectangle"

    slide.shapes.add_auto_shape(slides.ShapeType.QUAD_ARROW, 80, 180, 160, 110)
    modified_arrow = slide.shapes.add_auto_shape(slides.ShapeType.QUAD_ARROW, 430, 180, 160, 110)
    modified_arrow.name = "ModifiedQuadArrow"

    slide.shapes.add_auto_shape(slides.ShapeType.PIE, 95, 330, 130, 130)
    modified_pie = slide.shapes.add_auto_shape(slides.ShapeType.PIE, 445, 330, 130, 130)
    modified_pie.name = "ModifiedPie"

    shapes_to_adjust = [modified_rounded_rectangle, modified_arrow, modified_pie]

    for shape in shapes_to_adjust:
        for adjustment in shape.adjustments:
            print("{} / {}: {}".format(shape.name, adjustment.name, adjustment.type.name))

            if adjustment.type == slides.ShapeAdjustmentType.CORNER_SIZE:
                adjustment.raw_value = 5000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROW_TAIL_THICKNESS:
                adjustment.raw_value = 25000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROWHEAD_LENGTH:
                adjustment.raw_value = 30000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROWHEAD_WIDTH:
                adjustment.raw_value = 40000
            elif adjustment.type == slides.ShapeAdjustmentType.START_ANGLE:
                adjustment.angle_value = 30
            elif adjustment.type == slides.ShapeAdjustmentType.END_ANGLE:
                adjustment.angle_value = 300
            elif adjustment.type == slides.ShapeAdjustmentType.CUSTOM:
                print("Custom adjustment '{}' was not changed.".format(adjustment.name))

    presentation.save("preset-shape-adjustments.pptx", slides.export.SaveFormat.PPTX)
```

Verificar o tipo semântico antes de alterar um valor deixa o código explícito quanto à sua intenção e evita assumir que um determinado índice de coleção tem o mesmo significado em diferentes formas pré‑definidas.

## **Modificar a coleção de formas**

Os métodos de adicionar, clonar, remover e reordenar operam na coleção imediatamente. Se uma operação altera o número ou a ordem das formas, não continue a depender de índices capturados antes dessa operação.

### **Clonar uma forma**

[ShapeCollection.add_clone](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shapecollection/add_clone/) cria uma cópia independente e a anexa à coleção de destino. [ShapeCollection.insert_clone](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shapecollection/insert_clone/) também cria uma cópia, mas a coloca em um índice de ordem Z especificado. As sobrecargas que aceitam coordenadas movem o clone sem mudar seu tamanho; sobrecargas com largura e altura podem redimensioná‑lo também.

O exemplo cria um slide de destino, clona um retângulo rotulado para a frente e insere um segundo clone na parte de trás. Alterações em qualquer clone não modificam a forma original.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    source_slide = presentation.slides[0]
    source_shape = source_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 180, 60)
    source_shape.name = "SourceLabel"
    source_shape.text_frame.text = "Source"

    blank_layout = presentation.masters[0].layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    destination_slide = presentation.slides.add_empty_slide(blank_layout)

    front_clone_shape = destination_slide.shapes.add_clone(source_shape, 80, 80)
    front_clone_shape.name = "FrontClone"
    if isinstance(front_clone_shape, slides.AutoShape):
        front_clone_shape.text_frame.text = "Front clone"
    else:
        print("The front clone is not an AutoShape; its text was not changed.")

    back_clone_shape = destination_slide.shapes.insert_clone(0, source_shape, 80, 180)
    back_clone_shape.name = "BackClone"
    if isinstance(back_clone_shape, slides.AutoShape):
        back_clone_shape.text_frame.text = "Back clone"
    else:
        print("The back clone is not an AutoShape; its text was not changed.")

    presentation.save("cloned-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Clonar copia o conteúdo e a formatação da forma, incluindo seu nome e texto alternativo. Atribua novos identificadores lógicos ao clone quando esses valores precisarem ser únicos. Recursos usados por formas complexas são gerenciados pela apresentação, mas um clone continua sendo um novo item da coleção com uma nova identidade de forma.

### **Remover formas**

[ShapeCollection.remove](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shapecollection/remove/) exclui um objeto de forma específico de sua coleção. Ao remover múltiplas correspondências durante iteração indexada, percorra do final para que cada índice restante permaneça válido.

Este exemplo remove todas as formas com um nome designado. Ele lê `slide.shapes[index]`, não um item de coleção fixo, e não faz casting desnecessário da forma.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    keep_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 140, 60)
    keep_shape.name = "Keep"

    first_temporary_shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 220, 40, 80, 80)
    first_temporary_shape.name = "Temporary"

    second_temporary_shape = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 340, 40, 100, 80)
    second_temporary_shape.name = "Temporary"

    for index in range(len(slide.shapes) - 1, -1, -1):
        shape = slide.shapes[index]
        if shape.name == "Temporary":
            slide.shapes.remove(shape)

    presentation.save("removed-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Após a remoção, a contagem de formas e os índices das formas subsequentes mudam. Referências a formas não afetadas permanecem mais confiáveis que índices salvos. Considere também conectores, animações e outros recursos da apresentação que possam referir‑se ao objeto removido; remover uma forma visível pode mudar mais do que a aparência do slide.

### **Ocultar uma forma**

Definir [Shape.hidden](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/hidden/) como `True` mantém a forma na coleção, mas impede que ela apareça na apresentação normal. Seu índice, formatação e conteúdo permanecem disponíveis ao código, portanto ocultar é adequado para elementos opcionais que podem ser restaurados posteriormente.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    visible_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 160, 60)
    visible_shape.name = "VisibleLabel"

    optional_shape = slide.shapes.add_auto_shape(slides.ShapeType.MOON, 240, 40, 100, 100)
    optional_shape.name = "OptionalDecoration"

    for shape in slide.shapes:
        if shape.name == "OptionalDecoration":
            shape.hidden = True

    presentation.save("hidden-shape.pptx", slides.export.SaveFormat.PPTX)
```

Ocultar não é exclusão nem segurança. O objeto ainda pode ser descoberto e desocultado por um usuário ou por código, e continua fazendo parte do arquivo de apresentação.

### **Alterar a ordem Z**

Formas sobrepostas são pintadas na ordem da coleção. [ShapeCollection.reorder](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shapecollection/reorder/) move uma forma existente para um índice alvo sem cloná‑la. O índice `0` é o fundo; `len(slide.shapes) - 1` é a frente.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    blue_rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 220, 120)
    blue_rectangle.name = "BlueRectangle"
    blue_rectangle.fill_format.fill_type = slides.FillType.SOLID
    blue_rectangle.fill_format.solid_fill_color.color = draw.Color.steel_blue

    orange_ellipse = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 180, 140, 220, 120)
    orange_ellipse.name = "OrangeEllipse"
    orange_ellipse.fill_format.fill_type = slides.FillType.SOLID
    orange_ellipse.fill_format.solid_fill_color.color = draw.Color.orange

    slide.shapes.reorder(len(slide.shapes) - 1, blue_rectangle)
    presentation.save("reordered-shapes.pptx", slides.export.SaveFormat.PPTX)
```

O retângulo é criado primeiro e inicialmente fica atrás da elipse. Movê‑lo para o índice final coloca‑o à frente. Finalize a ordem Z depois de adicionar ou clonar todas as formas relacionadas, pois essas operações acrescentam ou inserem novos itens na coleção e podem alterar a pilha pretendida.

## **Inspecionar formas em slides de layout**

Slides normais, slides de layout e slides mestre possuem coleções de formas separadas. Uma forma em uma coleção de layout não é o mesmo objeto que uma forma posicionada de forma semelhante em um slide normal. Inspecione as formas de layout quando precisar entender ou mudar a formatação fornecida por um layout.

O exemplo a seguir lê o [Shape.fill_format](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/fill_format/) e o [Shape.line_format](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/line_format/) de cada forma de layout sem assumir que toda forma seja um `AutoShape`.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        for shape in layout_slide.shapes:
            fill_type = shape.fill_format.fill_type
            line_width = shape.line_format.width
            print("{} / {}: fill={}, line width={}".format(layout_slide.name, shape.name, fill_type, line_width))
```

Editar um layout pode afetar múltiplos slides que o utilizam. Antes de mudar uma forma de layout, determine se um slide normal herda o objeto ou contém uma substituição local, e teste cada slide que usa esse layout.

## **Exportar uma forma para SVG**

[Shape.write_as_svg](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/write_as_svg/) grava o conteúdo renderizado de uma forma em um fluxo. O resultado contém apenas a forma, não o fundo inteiro do slide nem as formas vizinhas.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) == 0:
        print("Slide 1 does not contain a shape to export.")
    else:
        shape = slide.shapes[0]
        with open("shape.svg", "wb") as svg_stream:
            shape.write_as_svg(svg_stream)
```

Mantenha a apresentação aberta durante a renderização. A saída depende da formatação da forma e de recursos como fontes e imagens. Se precisar da composição completa, exporte o slide em vez de uma forma individual. O chamador possui o fluxo e deve fechá‑lo.

## **Alinhar formas**

Os overloads [SlideUtil.align_shapes](https://reference.aspose.com/slides/pt/python-net/aspose.slides.util/slideutil/align_shapes/) alinham ou todas as formas ou índices de coleção selecionados. [ShapesAlignmentType](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shapesalignmenttype/) especifica a borda, a linha central ou o modo de distribuição. Defina `align_to_slide` como `True` para usar as bordas do slide; defina como `False` para alinhar as formas selecionadas entre si.

Este exemplo alinha três formas ao topo do slide. Seus índices atuais são resolvidos imediatamente antes do alinhamento.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    first_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 60, 80, 120, 50)
    second_shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 240, 160, 120, 50)
    third_shape = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 420, 240, 120, 50)
    first_shape.name = "FirstAlignedShape"
    second_shape.name = "SecondAlignedShape"
    third_shape.name = "ThirdAlignedShape"

    shape_indexes = [
        slide.shapes.index_of(first_shape),
        slide.shapes.index_of(second_shape),
        slide.shapes.index_of(third_shape)
    ]

    slides.util.SlideUtil.align_shapes(slides.ShapesAlignmentType.ALIGN_TOP, True, slide, shape_indexes)
    presentation.save("aligned-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Alinhamento altera posições, não a ordem Z. O alinhamento relativo normalmente requer ao menos duas formas, enquanto a distribuição horizontal ou vertical precisa de formas suficientes para definir o espaçamento. Recalcule os índices se modificar a coleção antes de chamar o método.

## **Inverter uma forma**

A classe [ShapeFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides.shapeframe/) armazena posição, tamanho, configurações de inversão horizontal e vertical e rotação. Seus valores `flip_h` e `flip_v` usam [NullableBool](https://reference.aspose.com/slides/pt/python-net/aspose.slides/nullablebool/): `TRUE` habilita a inversão, `FALSE` a desabilita, e `NOT_DEFINED` preserva o estado não especificado ou padrão.

A apresentação de entrada abaixo contém uma forma não invertida.

![The shape before flipping](shape_to_be_flipped.png)

O exemplo preserva todos os demais valores do frame e substitui apenas as duas configurações de inversão. Isso é importante porque atribuir um novo [Shape.frame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/frame/) substitui o frame completo.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    frame = shape.frame

    print("Horizontal flip before change:", frame.flip_h)
    print("Vertical flip before change:", frame.flip_v)

    shape.frame = slides.ShapeFrame(
        frame.x, frame.y, frame.width, frame.height,
        slides.NullableBool.TRUE, slides.NullableBool.TRUE, frame.rotation)

    presentation.save("flipped-shape.pptx", slides.export.SaveFormat.PPTX)
```

A forma salva é espelhada horizontal e verticalmente enquanto mantém sua posição, tamanho e rotação.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Devo usar um índice de coleção como identificador de forma?**

Somente para processamento de curta duração, quando a coleção não mudará antes do uso do índice. Prefira uma convenção validada de `name` ou `alternative_text` para modelos criados, ou `office_interop_shape_id` para trabalhos de interop no escopo do slide.

**Ocultar uma forma a remove da ordem Z?**

Não. Uma forma ocultada permanece na coleção no mesmo índice. Ela pode ser encontrada, reordenada, editada ou tornada visível novamente.

**Por que uma forma clonada apareceu à frente de outra forma?**

`add_clone` anexa o clone ao final da coleção, que corresponde à frente da ordem Z. Use `insert_clone` para escolher o índice inicial ou `reorder` depois que todas as formas forem adicionadas.

**Posso usar um índice fixo para identificar um ajuste de forma pré‑definido?**

Somente após validar o pré‑definido exato e o layout da coleção. Prefira iterar através de `GeometryShape.adjustments` e verificar `AdjustValue.type`; use `AdjustValue.name` como informação adicional quando o mesmo tipo semântico aparecer mais de uma vez.