---
title: Obter propriedades efetivas de formas de apresentações com Python
linktitle: Propriedades efetivas
type: docs
weight: 50
url: /pt/python-net/shape-effective-properties/
keywords:
- propriedades de forma
- propriedades de câmera
- conjunto de luzes
- forma chanfrada
- quadro de texto
- estilo de texto
- altura da fonte
- formato de preenchimento
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Descubra como o Aspose.Slides para Python via .NET calcula e aplica propriedades efetivas de forma para renderização precisa do PowerPoint."
---
## **Visão geral**

Este tópico explica a diferença entre propriedades **locais** e **efetivas**. Valores locais são valores definidos diretamente em um nível específico de formatação, como:

1. Propriedades de porção em um slide.
1. Estilos de texto de forma protótipo em um layout ou slide mestre, quando a forma de quadro de texto da porção tem um.
1. Configurações de texto globais em uma apresentação.

Valores locais podem ser definidos ou omitidos em qualquer nível. Quando o Aspose.Slides precisa da formatação final “como renderizada”, ele resolve a cadeia de herança e devolve valores **efetivos**. Você pode obtê-los chamando o método `get_effective` no objeto de formatação local.

O exemplo a seguir mostra como obter valores efetivos. Ele assume que a primeira forma do primeiro slide é um [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/) com um quadro de texto e pelo menos uma porção.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    local_text_frame_format = shape.text_frame.text_frame_format
    effective_text_frame_format = local_text_frame_format.get_effective()

    paragraph = shape.text_frame.paragraphs[0]
    portion = paragraph.portions[0]
    local_portion_format = portion.portion_format
    effective_portion_format = local_portion_format.get_effective()
```

{{% alert color="primary" %}}
Os dados de formatação efetiva representam a formatação calculada atual após a aplicação da herança. Na implementação atual, alguns objetos de dados efetivos, como [IPortionFormatEffectiveData](https://reference.aspose.com/slides/pt/python-net/aspose.slides/iportionformateffectivedata/), podem ser armazenados em cache internamente. Chamar `get_effective` novamente após alterar a formatação pai ou herdada pode atualizar o cache, e um objeto obtido anteriormente pode não representar mais o estado anterior. Se precisar preservar valores efetivos para reutilização posterior, copie as propriedades necessárias, como altura da fonte, cor de preenchimento, estilo da fonte ou alinhamento, para seu próprio objeto de dados.
{{% /alert %}}

## **Obter propriedades efetivas de uma câmera**

O Aspose.Slides permite obter propriedades efetivas de uma câmera. O tipo [ICameraEffectiveData](https://reference.aspose.com/slides/pt/python-net/aspose.slides/icameraeffectivedata/) representa um objeto imutável que contém propriedades efetivas da câmera. Uma instância de [ICameraEffectiveData](https://reference.aspose.com/slides/pt/python-net/aspose.slides/icameraeffectivedata/) é exposta através de [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ithreedformateffectivedata/), que fornece valores efetivos para [ThreeDFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides/threedformat/).

O exemplo de código a seguir mostra como obter propriedades efetivas para a câmera. Ele assume que a primeira forma do primeiro slide possui formatação 3D.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    camera = three_d_effective_data.camera

    camera_type = camera.camera_type
    field_of_view_angle = camera.field_of_view_angle
    zoom = camera.zoom

    print("= Effective camera properties =")
    print("Type: " + str(camera_type))
    print("Field of view: " + str(field_of_view_angle))
    print("Zoom: " + str(zoom))
```

## **Obter propriedades efetivas de um Light Rig**

O Aspose.Slides permite obter propriedades efetivas de um Light Rig. O tipo [ILightRigEffectiveData](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ilightrigeffectivedata/) representa um objeto imutável que contém propriedades efetivas do conjunto de luzes. Uma instância de [ILightRigEffectiveData](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ilightrigeffectivedata/) é exposta através de [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ithreedformateffectivedata/), que fornece valores efetivos para [ThreeDFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides/threedformat/).

O exemplo de código a seguir mostra como obter propriedades efetivas para o Light Rig. Ele assume que a primeira forma do primeiro slide possui formatação 3D.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    light_rig = three_d_effective_data.light_rig

    light_type = light_rig.light_type
    direction = light_rig.direction

    print("= Effective light rig properties =")
    print("Type: " + str(light_type))
    print("Direction: " + str(direction))
```

## **Obter propriedades efetivas de uma forma Bevel**

O Aspose.Slides permite obter propriedades efetivas de um bevel de forma. O tipo [IShapeBevelEffectiveData](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ishapebeveleffectivedata/) representa um objeto imutável que contém propriedades efetivas de relevo de superfície para uma forma. Uma instância de [IShapeBevelEffectiveData](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ishapebeveleffectivedata/) é exposta através de [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ithreedformateffectivedata/), que fornece valores efetivos para [ThreeDFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides/threedformat/).

O exemplo de código a seguir mostra como obter propriedades efetivas para o bevel superior de uma forma. Ele assume que a primeira forma do primeiro slide possui formatação 3D.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    top_bevel = three_d_effective_data.bevel_top

    bevel_type = top_bevel.bevel_type
    bevel_width = top_bevel.width
    bevel_height = top_bevel.height

    print("= Effective shape's top face relief properties =")
    print("Type: " + str(bevel_type))
    print("Width: " + str(bevel_width))
    print("Height: " + str(bevel_height))
```

## **Obter propriedades efetivas de um quadro de texto**

Usando o Aspose.Slides, você pode obter propriedades efetivas de um quadro de texto. O tipo [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/pt/python-net/aspose.slides/itextframeformateffectivedata/) contém propriedades de formatação efetiva do quadro de texto.

O exemplo de código a seguir mostra como obter propriedades de formatação efetiva do quadro de texto. Ele assume que a primeira forma do primeiro slide é um [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/) com um quadro de texto.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    text_frame_format = shape.text_frame.text_frame_format
    effective_text_frame_format = text_frame_format.get_effective()

    anchoring_type = effective_text_frame_format.anchoring_type
    autofit_type = effective_text_frame_format.autofit_type
    text_vertical_type = effective_text_frame_format.text_vertical_type
    margin_left = effective_text_frame_format.margin_left
    margin_top = effective_text_frame_format.margin_top
    margin_right = effective_text_frame_format.margin_right
    margin_bottom = effective_text_frame_format.margin_bottom

    print("Anchoring type: " + str(anchoring_type))
    print("Autofit type: " + str(autofit_type))
    print("Text vertical type: " + str(text_vertical_type))
    print("Margins")
    print("   Left: " + str(margin_left))
    print("   Top: " + str(margin_top))
    print("   Right: " + str(margin_right))
    print("   Bottom: " + str(margin_bottom))
```

## **Obter propriedades efetivas de um estilo de texto**

Usando o Aspose.Slides, você pode obter propriedades efetivas de um estilo de texto. O tipo [ITextStyleEffectiveData](https://reference.aspose.com/slides/pt/python-net/aspose.slides/itextstyleeffectivedata/) contém propriedades efetivas do estilo de texto.

O exemplo de código a seguir mostra como obter propriedades efetivas do estilo de texto. Ele assume que a primeira forma do primeiro slide é um [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/) com um quadro de texto.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    text_frame_format = shape.text_frame.text_frame_format
    text_style = text_frame_format.text_style
    effective_text_style = text_style.get_effective()
    level_count = 9

    for level_index in range(level_count):
        effective_style_level = effective_text_style.get_level(level_index)
        depth = effective_style_level.depth
        indent = effective_style_level.indent
        alignment = effective_style_level.alignment
        font_alignment = effective_style_level.font_alignment

        print("= Effective paragraph formatting for style level #" + str(level_index) + " =")

        print("Depth: " + str(depth))
        print("Indent: " + str(indent))
        print("Alignment: " + str(alignment))
        print("Font alignment: " + str(font_alignment))
```

## **Obter o valor efetivo da altura da fonte**

Usando o Aspose.Slides, você pode obter a altura efetiva da fonte. O código a seguir demonstra como a altura efetiva da fonte de uma porção muda após valores locais de altura da fonte serem definidos em diferentes níveis da estrutura da apresentação.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    auto_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 75, False)
    auto_shape.add_text_frame("")

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    first_portion = slides.Portion("Sample text with first portion")
    second_portion = slides.Portion(" and second portion.")

    paragraph.portions.add(first_portion)
    paragraph.portions.add(second_portion)

    print("Effective font height just after creation:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    default_text_style_level = presentation.default_text_style.get_level(0)
    default_text_style_level.default_portion_format.font_height = 24

    print("Effective font height after setting the presentation default font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    paragraph.paragraph_format.default_portion_format.font_height = 40

    print("Effective font height after setting paragraph default font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    first_portion.portion_format.font_height = 55

    print("Effective font height after setting portion #0 font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    second_portion.portion_format.font_height = 18

    print("Effective font height after setting portion #1 font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    presentation.save("SetLocalFontHeightValues.pptx", slides.export.SaveFormat.PPTX)
```

## **Obter o formato de preenchimento efetivo para uma tabela**

Usando o Aspose.Slides, você pode obter formatação de preenchimento efetiva para diferentes partes de uma tabela. O tipo [IFillFormatEffectiveData](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ifillformateffectivedata/) contém propriedades de formatação de preenchimento efetivas. A formatação de célula tem prioridade maior que a formatação de linha, a formatação de linha tem prioridade maior que a formatação de coluna, e a formatação de coluna tem prioridade maior que a formatação de toda a tabela.

Como resultado, as propriedades de [ICellFormatEffectiveData](https://reference.aspose.com/slides/pt/python-net/aspose.slides/icellformateffectivedata/) são usadas para desenhar a célula da tabela. O exemplo de código a seguir mostra como obter formatação de preenchimento efetiva para diferentes partes da tabela. Ele assume que a primeira forma do primeiro slide é uma [Table](https://reference.aspose.com/slides/pt/python-net/aspose.slides/table/).

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    table = presentation.slides[0].shapes[0]
    first_row = table.rows[0]
    first_column = table.columns[0]
    first_cell = first_row[0]

    table_format_effective = table.table_format.get_effective()
    row_format_effective = first_row.row_format.get_effective()
    column_format_effective = first_column.column_format.get_effective()
    cell_format_effective = first_cell.cell_format.get_effective()

    table_fill_format_effective = table_format_effective.fill_format
    row_fill_format_effective = row_format_effective.fill_format
    column_fill_format_effective = column_format_effective.fill_format
    cell_fill_format_effective = cell_format_effective.fill_format
```

## **Perguntas frequentes**

**O `get_effective` retorna um instantâneo?**

Nem sempre. Dados efetivos representam a formatação calculada após a aplicação da herança, mas alguns objetos de dados efetivos podem ser armazenados em cache internamente. Uma chamada subsequente a `get_effective` pode recalcular a formatação e atualizar o cache, de modo que um objeto obtido anteriormente não deve ser tratado como um instantâneo permanente.

**Quando devo ler as propriedades efetivas novamente?**

Chame `get_effective` novamente após alterar a formatação local, estilos pai, formatação de layout, formatação mestre ou valores padrão ao nível da apresentação. A próxima chamada reavalia a hierarquia de formatação e devolve o resultado efetivo atual.

**Alterar ou remover um slide de layout/mestre afeta as propriedades efetivas que já foram obtidas?**

Sim, mas a alteração só se reflete na próxima chamada `get_effective`. Se uma fonte de formatação pai for alterada ou removida, os dados efetivos obtidos anteriormente podem ficar desatualizados. Quando `get_effective` for chamado novamente, o Aspose.Slides reavalia a árvore de formatação e as fontes, cores, tamanhos ou outros valores resultantes podem mudar.

**Posso modificar valores através de objetos de dados efetivos?**

Não. Objetos de dados efetivos expõem valores calculados. Faça alterações nos objetos de formatação local e, então, obtenha os valores efetivos novamente.

**O que acontece se uma propriedade não estiver definida no nível da forma, nem no layout/mestre, nem nas configurações globais?**

O valor efetivo é determinado pelo mecanismo padrão, que inclui os padrões do PowerPoint e do Aspose.Slides. Esse valor resolvido passa a fazer parte dos dados efetivos atuais.

**A partir de um valor de fonte efetivo, posso saber qual nível forneceu o tamanho ou o tipo de letra?**

Não diretamente. Dados efetivos retornam o valor final. Para descobrir a origem, verifique os valores locais na porção, parágrafo, quadro de texto e estilos de texto nos níveis de layout, mestre e apresentação para ver onde aparece a primeira definição explícita.

**Por que os valores efetivos às vezes parecem idênticos aos locais?**

Porque o valor local acabou sendo final (nenhuma herança de nível superior foi necessária). Nesses casos, o valor efetivo coincide com o local.

**Quando devo usar propriedades efetivas e quando devo trabalhar apenas com as locais?**

Use dados efetivos quando precisar do resultado “como renderizado” depois que toda a herança for aplicada, como para alinhar cores, recuos ou tamanhos. Se precisar preservar esses valores independentemente de alterações de formatação posteriores, copie as propriedades necessárias para seu próprio objeto. Se precisar alterar a formatação em um nível específico, modifique as propriedades locais e, se necessário, leia os dados efetivos novamente para verificar o resultado.