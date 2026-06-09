---
title: Gerenciar Temas de Apresentação PowerPoint em Python
linktitle: Tema da Apresentação
type: docs
weight: 10
url: /pt/python-net/presentation-theme/
keywords:
- tema PowerPoint
- tema de apresentação
- tema de slide
- definir tema
- alterar tema
- gerenciar tema
- cor do tema
- paleta adicional
- fonte do tema
- estilo do tema
- efeito do tema
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Domine temas de apresentação no Aspose.Slides para Python via .NET para criar, personalizar e converter arquivos PowerPoint com identidade visual consistente."
---
## **Introdução**

Um tema de apresentação define as propriedades de seus elementos de design. Ao selecionar um tema, você está escolhendo um conjunto coordenado de elementos visuais e suas propriedades.

No PowerPoint, um tema inclui cores, [fontes](/slides/pt/python-net/powerpoint-fonts/), [estilos de fundo](/slides/pt/python-net/presentation-background/), e efeitos.

![theme-constituents](theme-constituents.png)

## **Alterar a Cor do Tema**

Um tema do PowerPoint usa um conjunto específico de cores para diferentes elementos em um slide. Se você não gostar dos padrões, pode alterá‑los aplicando novas cores de tema. Para permitir que você selecione uma nova cor de tema, o Aspose.Slides fornece valores na enumeração [SchemeColor](https://reference.aspose.com/slides/pt/python-net/aspose.slides/schemecolor/) .

Este código Python mostra como mudar a cor de destaque de um tema:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
```

Você pode determinar o valor efetivo da cor resultante da seguinte forma:

```python
fill_effective = shape.fill_format.get_effective()
print("{0} ({1})".format(fill_effective.solid_fill_color.name, fill_effective.solid_fill_color))

# Saída de exemplo:
#
# ff8064a2 (Cor [A=255, R=128, G=100, B=162])
```

Para demonstrar ainda mais a alteração de cor, criamos outro elemento, atribuímos a ele a cor de destaque da etapa inicial e, em seguida, atualizamos a cor do tema.

```python
other_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 120, 100, 100)
other_shape.fill_format.fill_type = slides.FillType.SOLID
other_shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

presentation.master_theme.color_scheme.accent4.color = draw.Color.red
```

A nova cor é aplicada automaticamente a ambos os elementos.

### **Definir uma Cor de Tema a partir da Paleta Adicional**

Quando você aplica transformações de luminância à cor principal do tema (1), cores da paleta adicional (2) são geradas. Você pode então definir e recuperar essas cores de tema.

![additional-palette-colors](additional-palette-colors.png)

**1** — Cores principais do tema  
**2** — Cores da paleta adicional

Este código Python demonstra como as cores da paleta adicional são derivadas da cor principal do tema e, em seguida, usadas em formas:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Realce 4
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 50, 50)

    shape1.fill_format.fill_type = slides.FillType.SOLID
    shape1.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

    # Realce 4, Mais claro 80%
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 50, 50)

    shape2.fill_format.fill_type = slides.FillType.SOLID
    shape2.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.2)
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.8)

    # Realce 4, Mais claro 60%
    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 50, 50)

    shape3.fill_format.fill_type = slides.FillType.SOLID
    shape3.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.4)
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.6)

    # Realce 4, Mais claro 40%
    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 50, 50)

    shape4.fill_format.fill_type = slides.FillType.SOLID
    shape4.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.6)
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.4)

    # Realce 4, Mais escuro 25%
    shape5 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 250, 50, 50)

    shape5.fill_format.fill_type = slides.FillType.SOLID
    shape5.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape5.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.75)

    # Realce 4, Mais escuro 50%
    shape6 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 50, 50)

    shape6.fill_format.fill_type = slides.FillType.SOLID
    shape6.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape6.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.5)

    presentation.save("example.pptx", slides.export.SaveFormat.PPTX)
```

### **Mapear `SchemeColor` para as Cores `ColorScheme`**

Ao trabalhar com [SchemeColor](https://reference.aspose.com/slides/pt/python-net/aspose.slides/schemecolor/), você pode notar que ele contém os seguintes valores de cor de tema:

`BACKGROUND1`, `BACKGROUND2`, `TEXT1` e `TEXT2`.

Entretanto, `Presentation.master_theme.color_scheme` retorna [ColorScheme](https://reference.aspose.com/slides/pt/python-net/aspose.slides.theme/colorscheme/), que expõe as cores correspondentes como:

`dark1`, `dark2`, `light1` e `light2`.

Essa diferença está apenas na nomenclatura. Esses valores referem‑se aos mesmos slots de cor de tema e o mapeamento é fixo:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

Não há conversão dinâmica entre `TEXT`/`BACKGROUND` e `dark`/`light`. Elas são simplesmente nomes alternativos para as mesmas cores de tema.

Essa diferença de nomenclatura vem da terminologia do Microsoft Office. Versões mais antigas do Office usavam `Dark 1`, `Light 1`, `Dark 2` e `Light 2`, enquanto versões mais recentes da interface exibem os mesmos slots como `Text 1`, `Background 1`, `Text 2` e `Background 2`.

## **Alterar a Fonte do Tema**

Para permitir que você selecione fontes para temas e outros propósitos, o Aspose.Slides usa esses identificadores especiais (semelhantes aos do PowerPoint):

- **+mn-lt** — Fonte do Corpo Latin (Fonte Latina Menor)
- **+mj-lt** — Fonte do Título Latin (Fonte Latina Maior)
- **+mn-ea** — Fonte do Corpo East Asian (Fonte Leste‑Asiática Menor)
- **+mj-ea** — Fonte do Título East Asian (Fonte Leste‑Asiática Maior)

Este código Python mostra como atribuir a fonte Latin a um elemento de tema:

```python
portion = slides.Portion("Theme text format")
portion.portion_format.latin_font = slides.FontData("+mn-lt")

paragraph = slides.Paragraph()
paragraph.portions.add(portion)

shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
shape.text_frame.paragraphs.add(paragraph)
```

Este exemplo Python mostra como alterar a fonte do tema da apresentação:

```python
presentation.master_theme.font_scheme.minor.latin_font = slides.FontData("Arial")
```

Todas as caixas de texto serão atualizadas para a nova fonte.

{{% alert color="primary" title="DICA" %}}
Para mais informações, veja [Fontes Mestre do PowerPoint com Python](/slides/pt/python-net/powerpoint-fonts/).
{{% /alert %}}

## **Alterar o Estilo de Fundo do Tema**

Por padrão, o PowerPoint fornece 12 fundos predefinidos, mas uma apresentação típica armazena apenas 3 deles.

![todo:image_alt_text](presentation-design_8.png)

Por exemplo, depois de salvar uma apresentação no PowerPoint, você pode executar o seguinte código Python para determinar quantos fundos predefinidos ela contém:

```python
with slides.Presentation() as presentation:
    number_of_background_fills = len(presentation.master_theme.format_scheme.background_fill_styles)
    print(f"Number of theme background fill styles: {number_of_background_fills}")
```

{{% alert color="warning" %}}
Usando a propriedade `background_fill_styles` da classe [FormatScheme](https://reference.aspose.com/slides/pt/python-net/aspose.slides.theme/formatscheme/) , você pode adicionar ou acessar estilos de fundo em um tema do PowerPoint.
{{% /alert %}}

Este exemplo Python mostra como definir o fundo da apresentação:

```python
presentation.masters[0].background.style_index = 2  # 0 denota sem preenchimento; a indexação começa em 1.
```

{{% alert color="primary" title="DICA" %}}
Para mais informações, veja [Gerenciar Fundos de Apresentação em Python](/slides/pt/python-net/presentation-background/).
{{% /alert %}}

## **Alterar os Efeitos do Tema**

Um tema do PowerPoint normalmente inclui três valores em cada array de estilo. Esses arrays combinam‑se em três níveis de efeito: sutil, moderado e intenso. Por exemplo, aqui está o resultado quando esses efeitos são aplicados a uma forma específica:

![todo:image_alt_text](presentation-design_10.png)

Usando as três propriedades — `FillStyles`, `LineStyles` e `EffectStyles` — da classe [FormatScheme](https://reference.aspose.com/slides/pt/python-net/aspose.slides.theme/formatscheme/) , você pode modificar elementos do tema (de forma ainda mais flexível que no PowerPoint).

Este código Python mostra como alterar um efeito do tema modificando partes desses elementos:

```python
with slides.Presentation("sample.pptx") as presentation:
    presentation.master_theme.format_scheme.line_styles[0].fill_format.solid_fill_color.color = draw.Color.red
    presentation.master_theme.format_scheme.fill_styles[2].fill_type = slides.FillType.SOLID
    presentation.master_theme.format_scheme.fill_styles[2].solid_fill_color.color = draw.Color.forest_green
    presentation.master_theme.format_scheme.effect_styles[2].effect_format.outer_shadow_effect.distance = 10

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

As alterações resultantes incluem atualizações da cor de preenchimento, tipo de preenchimento, efeito de sombra e outras propriedades:

![todo:image_alt_text](presentation-design_11.png)

## **Perguntas Frequentes**

**Posso aplicar um tema a um único slide sem alterar o mestre?**  
Sim. O Aspose.Slides suporta substituições de tema por slide, permitindo aplicar um tema local apenas a esse slide enquanto mantém o tema mestre intacto (por meio do [SlideThemeManager](https://reference.aspose.com/slides/pt/python-net/aspose.slides.theme/slidethememanager/)).

**Qual é a maneira mais segura de transferir um tema de uma apresentação para outra?**  
[Clone slides](/slides/pt/python-net/clone-slides/) junto com seu mestre na apresentação de destino. Isso preserva o mestre original, os layouts e o tema associado, de modo que a aparência permaneça consistente.

**Como posso ver os valores "efetivos" após toda herança e substituições?**  
Use as "visualizações efetivas" da API ["effective" views](/slides/pt/python-net/shape-effective-properties/) para tema/cor/fonte/efeito. Elas retornam as propriedades resolvidas e finais após aplicar o mestre mais quaisquer substituições locais.