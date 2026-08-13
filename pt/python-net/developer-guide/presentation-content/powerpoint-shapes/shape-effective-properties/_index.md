---
title: Obter Propriedades Efetivas de Forma de Apresentações em Python
linktitle: Propriedades Efetivas
type: docs
weight: 50
url: /pt/python-net/shape-effective-properties/
keywords:
- propriedades de forma
- propriedades de câmera
- rig de iluminação
- forma chanfrada
- quadro de texto
- estilo de texto
- altura da fonte
- formato de preenchimento
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Aprenda como usar Aspose.Slides para Python via .NET para distinguir a formatação local, herdada e efetiva de formas em apresentações PowerPoint."
---
## **Entender Propriedades Locais, Herdadas e Efetivas**

A formatação do PowerPoint pode vir de vários locais. O valor armazenado diretamente em um objeto é seu **valor local**. Se esse valor não estiver definido, o PowerPoint procura fontes de formatação pai, como o padrão de parágrafo, um estilo de texto, um layout ou slide mestre, um tema ou valores padrão ao nível da apresentação. Esses valores são **valores herdados**. O valor que resta após a resolução de toda a hierarquia é o **valor efetivo**, que é usado para renderizar o objeto.

Por exemplo, uma parte de texto pode não definir sua própria altura de fonte. Seu [font_height](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ibaseportionformat/font_height/) local então é `float("nan")`, que significa “não definido aqui”. A parte pode herdar uma altura do seu parágrafo, do estilo de texto padrão da apresentação ou de outra fonte aplicável. Chamar [get_effective](https://reference.aspose.com/slides/pt/python-net/aspose.slides/iportionformat/get_effective/) no formato da parte retorna a altura final resolvida.

Use os dois tipos de dados de formatação para propósitos diferentes:

- Leia ou altere um objeto de formato local, como [IPortionFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides/iportionformat/), quando precisar controlar onde um valor é definido.
- Leia um objeto de dados efetivos, como [IPortionFormatEffectiveData](https://reference.aspose.com/slides/pt/python-net/aspose.slides/iportionformateffectivedata/), quando precisar do resultado final renderizado. Dados efetivos são somente leitura.

## **Comparar Valores Locais, Herdados e Efetivos**

O exemplo completo a seguir cria uma forma e aplica alturas de fonte nos níveis de apresentação, parágrafo e parte. Cada etapa imprime os valores definidos nesses níveis e o valor efetivo resultante para a mesma parte de texto. Também demonstra por que os dados efetivos devem ser lidos novamente após alterações de formatação.

```python
import math

import aspose.slides as slides


def format_local_value(value):
    return "<not set>" if math.isnan(value) else str(value)


def print_font_heights(caption, presentation, paragraph, portion):
    presentation_value = presentation.default_text_style.get_level(0).default_portion_format.font_height
    paragraph_value = paragraph.paragraph_format.default_portion_format.font_height
    local_value = portion.portion_format.font_height

    # Leia os dados efetivos após as alterações precedentes.
    effective_value = portion.portion_format.get_effective().font_height

    print(caption)
    print("  Presentation default: " + format_local_value(presentation_value))
    print("  Paragraph default:    " + format_local_value(paragraph_value))
    print("  Portion local:        " + format_local_value(local_value))
    print("  Portion effective:    " + str(effective_value))


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 500, 80, False)
    text_frame = shape.add_text_frame("Effective formatting")
    paragraph = text_frame.paragraphs[0]
    portion = paragraph.portions[0]

    # Defina valores herdados em dois níveis diferentes.
    presentation.default_text_style.get_level(0).default_portion_format.font_height = 20
    paragraph.paragraph_format.default_portion_format.font_height = 28

    print_font_heights("The portion inherits from the paragraph", presentation, paragraph, portion)

    # Um valor local na parte sobrescreve ambos os valores herdados.
    portion.portion_format.font_height = 36
    print_font_heights("A local value overrides inherited values", presentation, paragraph, portion)

    # Alterar um valor herdado não sobrescreve um valor local existente.
    paragraph.paragraph_format.default_portion_format.font_height = 30
    print_font_heights("The local value still has priority", presentation, paragraph, portion)

    # Limpe o valor local. A parte agora herda novamente do parágrafo.
    portion.portion_format.font_height = float("nan")
    print_font_heights("The local value is cleared", presentation, paragraph, portion)

    # Limpe o valor do parágrafo. O padrão da apresentação agora fornece o resultado.
    paragraph.paragraph_format.default_portion_format.font_height = float("nan")
    print_font_heights("The paragraph value is cleared", presentation, paragraph, portion)

    presentation.save("effective-properties.pptx", slides.export.SaveFormat.PPTX)
```

A prioridade neste exemplo é a formatação local da parte, seguida pela formatação do parágrafo e, por fim, o padrão da apresentação. Outros objetos podem ter cadeias de herança diferentes, mas o princípio é o mesmo: um valor explícito mais específico tem precedência, e [get_effective](https://reference.aspose.com/slides/pt/python-net/aspose.slides/iportionformat/get_effective/) retorna o resultado final.

## **Obter Propriedades de Texto Efetivas**

A formatação de texto está dividida entre vários objetos:

- [ITextFrameFormat.get_effective()](https://reference.aspose.com/slides/pt/python-net/aspose.slides/itextframeformat/get_effective/) resolve propriedades do quadro de texto, como margens, ancoragem, ajuste automático e direção vertical do texto.
- [ITextStyle.get_effective()](https://reference.aspose.com/slides/pt/python-net/aspose.slides/itextstyle/get_effective/) resolve a formatação de parágrafo para cada nível de estilo de texto.
- [IParagraphFormat.get_effective()](https://reference.aspose.com/slides/pt/python-net/aspose.slides/iparagraphformat/get_effective/) resolve propriedades do parágrafo, como alinhamento, recuo e marcadores.
- [IPortionFormat.get_effective()](https://reference.aspose.com/slides/pt/python-net/aspose.slides/iportionformat/get_effective/) resolve propriedades de caracteres, como altura da fonte, tipo de letra, cor, negrito e itálico.

Para o próximo exemplo, `text-formatting.pptx` deve conter ao menos um slide e um [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/) com um quadro de texto não vazio. O AutoShape pode estar em qualquer posição na coleção de formas; o código procura um objeto adequado e o valida antes de usar.

```python
import aspose.slides as slides


def has_non_empty_text(shape):
    if not isinstance(shape, slides.AutoShape):
        return False
    if shape.text_frame is None:
        return False
    if shape.text_frame.paragraphs.count == 0:
        return False
    return shape.text_frame.paragraphs[0].portions.count > 0


with slides.Presentation("text-formatting.pptx") as presentation:
    if presentation.slides.count == 0:
        raise RuntimeError("The presentation contains no slides.")

    shape = None
    for candidate in presentation.slides[0].shapes:
        if has_non_empty_text(candidate):
            shape = candidate
            break

    if shape is None:
        raise RuntimeError("The first slide must contain an AutoShape with non-empty text.")

    text_frame = shape.text_frame
    paragraph = text_frame.paragraphs[0]
    portion = paragraph.portions[0]

    text_frame_effective = text_frame.text_frame_format.get_effective()
    paragraph_effective = paragraph.paragraph_format.get_effective()
    portion_effective = portion.portion_format.get_effective()

    print("Text frame margins:")
    print("  Left: " + str(text_frame_effective.margin_left))
    print("  Top: " + str(text_frame_effective.margin_top))
    print("  Right: " + str(text_frame_effective.margin_right))
    print("  Bottom: " + str(text_frame_effective.margin_bottom))
    print("Paragraph alignment: " + str(paragraph_effective.alignment))
    print("Font height: " + str(portion_effective.font_height))
    print("Bold: " + str(portion_effective.font_bold))

    effective_text_style = text_frame.text_frame_format.text_style.get_effective()
    for level in range(9):
        level_effective = effective_text_style.get_level(level)
        print("Level " + str(level) + " indent: " + str(level_effective.indent))
```

## **Obter Propriedades 3D Efetivas**

[IThreeDFormat.get_effective()](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ithreedformat/get_effective/) devolve um objeto [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ithreedformateffectivedata/) que agrupa todas as configurações 3D resolvidas. Suas propriedades [camera](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ithreedformateffectivedata/camera/), [light_rig](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ithreedformateffectivedata/light_rig/), [bevel_top](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ithreedformateffectivedata/bevel_top/) e [bevel_bottom](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ithreedformateffectivedata/bevel_bottom/) expõem os respectivos dados efetivos. Ler essas configurações relacionadas em conjunto facilita a compreensão da aparência 3D final de uma forma.

Para este exemplo, `shape-3d.pptx` deve conter ao menos uma forma no primeiro slide. Aplique configurações de câmera 3D, iluminação ou chanfro a essa forma se quiser que a saída contenha valores diferentes dos padrão.

```python
import aspose.slides as slides


with slides.Presentation("shape-3d.pptx") as presentation:
    if presentation.slides.count == 0 or presentation.slides[0].shapes.count == 0:
        raise RuntimeError("The first slide must contain a shape.")

    shape = presentation.slides[0].shapes[0]
    three_d_effective = shape.three_d_format.get_effective()

    print("Camera:")
    print("  Type: " + str(three_d_effective.camera.camera_type))
    print("  Field of view: " + str(three_d_effective.camera.field_of_view_angle))
    print("  Zoom: " + str(three_d_effective.camera.zoom))

    print("Light rig:")
    print("  Type: " + str(three_d_effective.light_rig.light_type))
    print("  Direction: " + str(three_d_effective.light_rig.direction))

    print("Top bevel:")
    print("  Type: " + str(three_d_effective.bevel_top.bevel_type))
    print("  Width: " + str(three_d_effective.bevel_top.width))
    print("  Height: " + str(three_d_effective.bevel_top.height))
```

## **Obter Formatação de Tabela Efetiva**

A formatação de tabelas pode provir do estilo da tabela e de formatos aplicados a toda a tabela, a uma coluna, a uma linha ou a uma célula individual. Em conflitos entre preenchimentos definidos explicitamente, a prioridade é célula, linha, coluna e, por fim, a tabela inteira. O formato efetivo de uma célula é o formato final usado para desenhá‑la.

Para este exemplo, `table-formatting.pptx` deve conter ao menos uma tabela no primeiro slide. A tabela deve ter ao menos uma linha e uma coluna. O código procura um [Table](https://reference.aspose.com/slides/pt/python-net/aspose.slides/table/) em vez de assumir que `shapes[0]` é uma tabela.

```python
import aspose.slides as slides


with slides.Presentation("table-formatting.pptx") as presentation:
    if presentation.slides.count == 0:
        raise RuntimeError("The presentation contains no slides.")

    table = None
    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    if table is None:
        raise RuntimeError("The first slide must contain a table.")

    if table.rows.count == 0 or table.columns.count == 0:
        raise RuntimeError("The table must contain at least one cell.")

    table_effective = table.table_format.get_effective()
    row_effective = table.rows[0].row_format.get_effective()
    column_effective = table.columns[0].column_format.get_effective()
    cell_effective = table.rows[0][0].cell_format.get_effective()

    print("Table fill: " + str(table_effective.fill_format.fill_type))
    print("Row fill: " + str(row_effective.fill_format.fill_type))
    print("Column fill: " + str(column_effective.fill_format.fill_type))
    print("Final cell fill: " + str(cell_effective.fill_format.fill_type))
```

Se precisar da cor em vez apenas do tipo de preenchimento, primeiro verifique o [fill_type](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ifillformateffectivedata/fill_type/) efetivo e, então, leia a propriedade que se aplica a esse tipo, por exemplo, [solid_fill_color](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ifillformateffectivedata/solid_fill_color/) para um preenchimento sólido.

## **Reler Dados Efetivos Após Alterações**

Dados efetivos descrevem a hierarquia de formatação no momento em que são resolvidos. Chame `get_effective` novamente após alterar qualquer elemento que possa participar dessa hierarquia, incluindo:

- a formatação local do objeto;
- padrões de parágrafo ou quadro de texto;
- um estilo de tabela, tabela, coluna, linha ou formato de célula;
- formatação de layout ou slide mestre;
- dados de tema ou padrões ao nível da apresentação;
- o layout ou mestre atribuído a um slide.

Não mantenha um objeto de dados efetivos como um instantâneo permanente. Aspose.Slides pode armazenar alguns dados efetivos em cache internamente, e uma chamada posterior a `get_effective` pode atualizar esses dados. Se precisar comparar valores antes e depois de uma mudança, copie os valores escalares necessários, como altura da fonte, cor, alinhamento ou largura do chanfro, para suas próprias variáveis antes de efetuar a alteração.

Para mudar um valor, atualize o objeto de formato local apropriado e então chame `get_effective` para verificar o resultado. Os próprios objetos de dados efetivos são somente leitura.

## **FAQ**

**Como posso saber qual nível forneceu um valor efetivo?**

Dados efetivos contêm o valor final, não sua origem. Inspecione os objetos locais aplicáveis do nível mais específico para fora. Para texto, isso pode incluir a parte, o parágrafo, o quadro de texto, o layout, o mestre, o tema e os padrões da apresentação. Valores indefinidos como `float("nan")` ou `None` indicam que a busca continua para outro nível.

**O que acontece quando nenhum nível define uma propriedade?**

Aspose.Slides resolve o padrão apropriado do PowerPoint ou da biblioteca. Esse valor resolvido aparece nos dados efetivos mesmo que nenhum objeto local o defina explicitamente.

**Por que um valor efetivo às vezes é igual ao valor local?**

O valor local venceu o cálculo de herança. Isso é esperado quando a propriedade está explicitamente configurada no objeto e nenhuma regra mais específica a substitui.

**Quando devo usar dados locais em vez de dados efetivos?**

Use dados locais para inspecionar ou editar um nível específico de formatação. Use dados efetivos quando precisar da aparência final após a herança, regras de tema e estilos aplicáveis terem sido resolvidos. O [exemplo completo de comparação](#compare-local-inherited-and-effective-values) demonstra ambos no mesmo fluxo de trabalho.